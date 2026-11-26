// house-draw.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house_draw_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile(";base64,$", "");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("^(Speakers|Club Audio)$", "");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("Ceiling Light|Island Lighting|Bedroom Chandelier|Overhead Light", "");
        static readonly System.Text.RegularExpressions.Regex RX3 = JsRegExp.Compile("washer|dryer|dry-cleaning", "i");
        static readonly System.Text.RegularExpressions.Regex RX4 = JsRegExp.Compile("dartboard", "i");
        static readonly System.Text.RegularExpressions.Regex RX5 = JsRegExp.Compile("^#", "");
        static readonly System.Text.RegularExpressions.Regex RX6 = JsRegExp.Compile("arcade|pinball|pong|billiards|hockey|dance-mat|rhythm|game", "i");
        static readonly System.Text.RegularExpressions.Regex RX7 = JsRegExp.Compile("\\bDJ\\b|decks|turntable|booth", "i");
        static readonly System.Text.RegularExpressions.Regex RX8 = JsRegExp.Compile("shower", "i");
        static readonly System.Text.RegularExpressions.Regex RX9 = JsRegExp.Compile("Greenery|Planter|Plant Beds|Houseplant", "i");
        static readonly System.Text.RegularExpressions.Regex RX10 = JsRegExp.Compile("Clutter|Decor|Amenities|Bedroom Electronics|Reading Light|Prep Appliance|Beverage Maker", "");
        static readonly System.Text.RegularExpressions.Regex RX11 = JsRegExp.Compile("Table|Counter|Cabinetry|Island|Nightstand|Bedside|Drawer Chest|Vanity|Desk|Media Rack|Shelving|Club Bar|Cart|Stump", "");
        static readonly System.Text.RegularExpressions.Regex RX12 = JsRegExp.Compile("Storage", "");
        static readonly System.Text.RegularExpressions.Regex RX13 = JsRegExp.Compile("<path [^>]*\\/>(?=<\\/svg>$)", "");
        static readonly System.Text.RegularExpressions.Regex RX14 = JsRegExp.Compile("<\\/defs>((?:<path [^>]*\\/>){3})", "");
        static readonly System.Text.RegularExpressions.Regex RX15 = JsRegExp.Compile("<\\/defs><path d=\"[^\"]*\" fill=\"([^\"]*)\"", "");
        static readonly System.Text.RegularExpressions.Regex RX16 = JsRegExp.Compile("Doorway|Club Entrance|Entry & Divider", "");
        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V G_8, V _a5, V _a6, V _a7, V[] _rest3) => {
V RCSV_9 = default;
V RMAP_10 = default;
V SLOTCAT_11 = default;
V roleOf_12 = default;
V CEILS_13 = default;
V catOf_14 = default;
V BIGR_15 = default;
V edgeR_16 = default;
V X_17 = default;
V RD_18 = default;
V sh_19 = default;
V uri_20 = default;
V b64_21 = default;
V geo0_22 = default;
V reg_23 = default;
V r1_24 = default;
V IC_25 = default;
V NEED_26 = default;
V FIX_27 = default;
V RLAB_28 = default;
V RDOT_29 = default;
V FISHB_30 = default;
V BOARDH_31 = default;
V RODH_32 = default;
V MAPB_33 = default;
V SEASON_34 = default;
V MAPGRASS_35 = default;
V MAPROAD_36 = default;
V MAPDEAD_37 = default;
V MTB_38 = default;
V MTF_39 = default;
V MBU_40 = default;
V natSS_41 = default;
V n1_42 = default;
V natSkel_43 = default;
V natE_44 = default;
V natTree_45 = default;
V natBush_46 = default;
V natMap_47 = default;
V WIC_48 = default;
V rnd_49 = default;
V RAIN_50 = default;
V SNOW_51 = default;
V SPK_52 = default;
V mp_53 = default;
V plain_54 = default;
uri_20 = Fn((V _self55, int _argc56, V u_62, V _a59, V _a60, V _a61, V[] _rest57) => {
V i_63 = default;
V head_64 = default;
V body_65 = default;
if ((!(Truthy(u_62)) || !string.Equals(Typeof(u_62), "string"))) {
return ((V)(""));
}
if (SEqS(u_62, "data:image/gif;base64,R0lGODlhAQABAAAAACH5BAEKAAEALAAAAAABAAEAAAICTAEAOw==")) {
return ((V)(""));
}
if (!SEqN(Invoke(u_62, "indexOf", ((V)("data:image/svg+xml"))), 0D)) {
return u_62;
}
i_63 = Invoke(u_62, "indexOf", ((V)(",")));
head_64 = Invoke(u_62, "slice", ((V)(0D)), Add(i_63, ((V)(1D))));
body_65 = Invoke(u_62, "slice", Add(i_63, ((V)(1D))));
return (Truthy(Invoke(NewRegExp(RX0, ";base64,$", ""), "test", head_64)) ? Call(b64_21, V.Undef, body_65) : Call(G("decodeURIComponent"), V.Undef, body_65));
return default;
}, 1, "uri", false);
b64_21 = Fn((V _self66, int _argc67, V s_73, V _a70, V _a71, V _a72, V[] _rest68) => {
V A_74 = default;
V bytes_75 = default;
V buf_76 = default;
V bits_77 = default;
V i_78 = default;
V v_79 = default;
V @out_80 = default;
V j_81 = default;
V b_82 = default;
V cp_83 = default;
A_74 = ((V)("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"));
bytes_75 = Arr();
buf_76 = ((V)(0D));
bits_77 = ((V)(0D));
{
i_78 = ((V)(0D));
while (true) {
if (!(Lt(i_78, Get(s_73, "length")))) break;
v_79 = Invoke(A_74, "indexOf", GetK(s_73, i_78));
if (LtN(v_79, 0D)) {
goto _cont84;
}
buf_76 = ((V)(((double)(ToInt32(((double)(ToInt32(ToNum(buf_76)) << (int)(ToUint32(6D) & 31)))) | ToInt32(ToNum(v_79))))));
bits_77 = Add(bits_77, ((V)(6D)));
if (GeN(bits_77, 8D)) {
bits_77 = ((V)((ToNum(bits_77) - 8D)));
Invoke(bytes_75, "push", ((V)(((double)(ToInt32(((double)(ToInt32(ToNum(buf_76)) >> (int)(ToUint32(ToNum(bits_77)) & 31)))) & ToInt32(255D))))));
}
_cont84: ;
PostInc(ref i_78, 1D);
}
}
@out_80 = ((V)(""));
j_81 = ((V)(0D));
while (Lt(j_81, Get(bytes_75, "length"))) {
b_82 = GetIdx(bytes_75, PostInc(ref j_81, 1D));
if (LtN(b_82, 128D)) {
cp_83 = b_82;
} else {
if (LtN(b_82, 224D)) {
cp_83 = ((V)(((double)(ToInt32(((double)(ToInt32(((double)(ToInt32(ToNum(b_82)) & ToInt32(31D)))) << (int)(ToUint32(6D) & 31)))) | ToInt32(((double)(ToInt32(ToNum(GetIdx(bytes_75, PostInc(ref j_81, 1D)))) & ToInt32(63D))))))));
} else {
if (LtN(b_82, 240D)) {
cp_83 = ((V)(((double)(ToInt32(((double)(ToInt32(((double)(ToInt32(((double)(ToInt32(ToNum(b_82)) & ToInt32(15D)))) << (int)(ToUint32(12D) & 31)))) | ToInt32(((double)(ToInt32(((double)(ToInt32(ToNum(GetIdx(bytes_75, PostInc(ref j_81, 1D)))) & ToInt32(63D)))) << (int)(ToUint32(6D) & 31))))))) | ToInt32(((double)(ToInt32(ToNum(GetIdx(bytes_75, PostInc(ref j_81, 1D)))) & ToInt32(63D))))))));
} else {
cp_83 = ((V)(((double)(ToInt32(((double)(ToInt32(((double)(ToInt32(((double)(ToInt32(((double)(ToInt32(ToNum(b_82)) & ToInt32(7D)))) << (int)(ToUint32(18D) & 31)))) | ToInt32(((double)(ToInt32(((double)(ToInt32(ToNum(GetIdx(bytes_75, PostInc(ref j_81, 1D)))) & ToInt32(63D)))) << (int)(ToUint32(12D) & 31))))))) | ToInt32(((double)(ToInt32(((double)(ToInt32(ToNum(GetIdx(bytes_75, PostInc(ref j_81, 1D)))) & ToInt32(63D)))) << (int)(ToUint32(6D) & 31))))))) | ToInt32(((double)(ToInt32(ToNum(GetIdx(bytes_75, PostInc(ref j_81, 1D)))) & ToInt32(63D))))))));
}
}
}
@out_80 = Add(@out_80, Invoke(G("String"), "fromCodePoint", cp_83));
}
return @out_80;
return default;
}, 1, "b64", false);
reg_23 = Fn((V _self85, int _argc86, V id_92, V _a89, V _a90, V _a91, V[] _rest87) => {
V s_93 = default;
V e_94 = default;
V b_95 = default;
if (Truthy(GetK(Get(X_17, "CAT"), ((V)(JsStrBuf.Begin().S("R:").V(id_92).End()))))) {
return GetK(Get(X_17, "CAT"), ((V)(JsStrBuf.Begin().S("R:").V(id_92).End())));
}
s_93 = Get(Get(X_17, "RM"), "s");
e_94 = Get(Get(X_17, "RM"), "e");
b_95 = Get(X_17, "BIG");
if (Truthy(geo0_22)) {
Set(Get(X_17, "RM"), "s", Get(geo0_22, "s"));
Set(Get(X_17, "RM"), "e", Get(geo0_22, "e"));
Set(X_17, "BIG", Get(geo0_22, "b"));
}
try {
return Invoke(sh_19, "rnReg", id_92);
} finally {
Set(Get(X_17, "RM"), "s", s_93);
Set(Get(X_17, "RM"), "e", e_94);
Set(X_17, "BIG", b_95);
}
return default;
}, 1, "reg", false);
natSkel_43 = Fn((V _self96, int _argc97, V i_103, V _a100, V _a101, V _a102, V[] _rest98) => {
V L_104 = default;
V grow_105 = default;
L_104 = Arr();
grow_105 = Fn((V _arrowThis119, int _argc106, V x_112, V y_113, V a_114, V len_115, V[] _rest107) => {
V ex_120 = default;
double ey_121 = 0;
double n_122 = 0;
V w_116 = default;
V d_117 = default;
V k_118 = default;
w_116 = (_argc106 > 4 ? _rest107[0] : V.Undef);
d_117 = (_argc106 > 5 ? _rest107[1] : V.Undef);
k_118 = (_argc106 > 6 ? _rest107[2] : V.Undef);
ex_120 = Add(x_112, ((V)((FdLibm.Sin(ToNum(a_114)) * ToNum(len_115)))));
ey_121 = (ToNum(y_113) - (FdLibm.Cos(ToNum(a_114)) * ToNum(len_115)));
Invoke(L_104, "push", Arr(x_112, y_113, ex_120, ((V)(ey_121)), w_116, d_117));
if (GeN(d_117, 3D)) {
return default;
}
n_122 = (SEqN(d_117, 0D) ? 3D : (2D + (LtN(Call(rnd_49, V.Undef, Add(((V)((ToNum(i_103) * 50D))), k_118), ((V)(81D))), 0.5) ? 1D : 0D)));
{
double j_123 = 0;
j_123 = 0D;
while (true) {
if (!((j_123 < n_122))) break;
double sp_125 = 0;
sp_125 = (((j_123 - ((n_122 - 1D) / 2D)) * (SEqN(d_117, 0D) ? 0.62 : 0.55)) + ((ToNum(Call(rnd_49, V.Undef, ((V)((((ToNum(i_103) * 50D) + (ToNum(k_118) * 7D)) + j_123))), ((V)(82D)))) - 0.5) * 0.35));
Call(grow_105, V.Undef, ex_120, ((V)(ey_121)), Add(a_114, ((V)(sp_125))), ((V)((ToNum(len_115) * (0.72 + (ToNum(Call(rnd_49, V.Undef, Add(Add(((V)((ToNum(i_103) * 50D))), k_118), ((V)(j_123))), ((V)(83D)))) * 0.12))))), ((V)((ToNum(w_116) * 0.62))), Add(d_117, ((V)(1D))), ((V)((((ToNum(k_118) * 4D) + j_123) + 1D))));
j_123++;
}
}
return default;
}, 7, "", true);
Call(grow_105, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(((ToNum(Call(rnd_49, V.Undef, i_103, ((V)(84D)))) - 0.5) * 0.12))), ((V)(16D)), ((V)(4.6)), ((V)(0D)), ((V)(1D)));
return L_104;
return default;
}, 1, "natSkel", false);
natTree_45 = Fn((V _self126, int _argc127, V i_133, V x_134, V y_135, V s_136, V[] _rest128) => {
V L_140 = default;
V leaf_141 = default;
V bark_142 = default;
V barkHi_143 = default;
JsStrBuf o_144 = null;
JsStrBuf lb_145 = null;
JsStrBuf lh_146 = null;
V ends_147 = default;
double cx_148 = 0;
double cy_149 = 0;
V CL_150 = default;
V show_151 = default;
V v_137 = default;
V mx_138 = default;
V mix_139 = default;
v_137 = (_argc127 > 4 ? _rest128[0] : V.Undef);
mx_138 = (_argc127 > 5 ? _rest128[1] : V.Undef);
mix_139 = (_argc127 > 6 ? _rest128[2] : V.Undef);
L_140 = Call(natSkel_43, V.Undef, i_133);
leaf_141 = Call(natSS_41, V.Undef, ((V)(0.06)), ((V)(0.85)), v_137);
bark_142 = Call(mix_139, V.Undef, ((V)("#5d5650")), ((V)("#6b4a2e")), v_137);
barkHi_143 = Call(mix_139, V.Undef, ((V)("#8a8278")), ((V)("#a07a52")), v_137);
o_144 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"translate(").V(x_134).S(" ").V(y_135).S(") scale(").V(s_136).S(")\"><ellipse cx=\"7\" cy=\"23\" rx=\"").V(Call(n1_42, V.Undef, ((V)((10D + (12D * ToNum(leaf_141))))))).S("\" ry=\"").V(Call(n1_42, V.Undef, ((V)((3D + (2.4 * ToNum(leaf_141))))))).S("\" fill=\"#16200c\" opacity=\"").V(Invoke(((V)((0.22 + (0.2 * ToNum(leaf_141))))), "toFixed", ((V)(2D)))).S("\" filter=\"url(#mpNatBlur)\"/>").End());
lb_145 = new JsStrBuf("");
lh_146 = new JsStrBuf("");
Invoke(L_140, "forEach", Fn((V _arrowThis169, int _argc152, V _a154, V _a155, V _a156, V _a157, V[] _rest153) => {
V x0_160 = default;
V y0_162 = default;
V x1_164 = default;
V y1_166 = default;
V w_168 = default;
{ V _t158 = ListOf(_a154);
{ V _t159 = GetIdx(_t158, 0D);
x0_160 = _t159; }
{ V _t161 = GetIdx(_t158, 1D);
y0_162 = _t161; }
{ V _t163 = GetIdx(_t158, 2D);
x1_164 = _t163; }
{ V _t165 = GetIdx(_t158, 3D);
y1_166 = _t165; }
{ V _t167 = GetIdx(_t158, 4D);
w_168 = _t167; }
}
lb_145.S("<path d=\"M").V(Call(n1_42, V.Undef, x0_160)).S(" ").V(Call(n1_42, V.Undef, y0_162)).S("L").V(Call(n1_42, V.Undef, x1_164)).S(" ").V(Call(n1_42, V.Undef, y1_166)).S("\" stroke-width=\"").V(Call(n1_42, V.Undef, w_168)).S("\"/>");
lh_146.S("M").V(Call(n1_42, V.Undef, ((V)((ToNum(x0_160) - (ToNum(w_168) * 0.25)))))).S(" ").V(Call(n1_42, V.Undef, y0_162)).S("L").V(Call(n1_42, V.Undef, ((V)((ToNum(x1_164) - (ToNum(w_168) * 0.2)))))).S(" ").V(Call(n1_42, V.Undef, y1_166));
return default;
}, 1, "", true));
o_144.S("<g stroke=\"").V(Call(mix_139, V.Undef, bark_142, ((V)("#000000")), ((V)(0.35)))).S("\" stroke-linecap=\"round\" fill=\"none\" transform=\"translate(0.5 0.3)\">").S(lb_145.Str).S("</g><g stroke=\"").V(bark_142).S("\" stroke-linecap=\"round\" fill=\"none\">").S(lb_145.Str).S("</g><path d=\"").S(lh_146.Str).S("\" stroke=\"").V(barkHi_143).S("\" stroke-width=\"0.6\" stroke-linecap=\"round\" fill=\"none\" opacity=\"0.8\"/>").S("<path d=\"M-2.6 22q-3 0.2 -5.4 -0.8M2.6 22q3 0.3 5.6 -0.6M0 22q0.6 0.8 1.6 1.4\" stroke=\"").V(bark_142).S("\" stroke-width=\"1.5\" stroke-linecap=\"round\" fill=\"none\"/>");
ends_147 = Invoke(L_140, "filter", Fn((V _arrowThis177, int _argc170, V q_176, V _a173, V _a174, V _a175, V[] _rest171) => {
return (GeN(GetIdx(q_176, 5D), 2D) ? V.True : V.False);
}, 1, "", true));
cx_148 = (ToNum(Invoke(ends_147, "reduce", Fn((V _arrowThis186, int _argc178, V a_184, V q_185, V _a182, V _a183, V[] _rest179) => {
return Add(a_184, GetIdx(q_185, 2D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(ends_147, "length")));
cy_149 = (ToNum(Invoke(ends_147, "reduce", Fn((V _arrowThis195, int _argc187, V a_193, V q_194, V _a191, V _a192, V[] _rest188) => {
return Add(a_193, GetIdx(q_194, 3D));
}, 2, "", true), ((V)(0D)))) / ToNum(Get(ends_147, "length")));
CL_150 = Arr();
Invoke(ends_147, "forEach", Fn((V _arrowThis204, int _argc196, V q_202, V j_203, V _a200, V _a201, V[] _rest197) => {
double nn_205 = 0;
nn_205 = (SEqN(GetIdx(q_202, 5D), 3D) ? 19D : 9D);
{
double k_206 = 0;
k_206 = 0D;
while (true) {
if (!((k_206 < nn_205))) break;
V r_208 = default;
double a_209 = 0;
double d_210 = 0;
V px_211 = default;
V py_212 = default;
double lit_213 = 0;
r_208 = Call(rnd_49, V.Undef, ((V)((((ToNum(i_133) * 900D) + (ToNum(j_203) * 40D)) + k_206))), ((V)(91D)));
a_209 = (ToNum(Call(rnd_49, V.Undef, ((V)((((ToNum(i_133) * 900D) + (ToNum(j_203) * 40D)) + k_206))), ((V)(92D)))) * 6.283);
d_210 = ((SEqN(GetIdx(q_202, 5D), 3D) ? 5.8 : 4.4) * System.Math.Sqrt(ToNum(r_208)));
px_211 = Add(GetIdx(q_202, 2D), ((V)(((FdLibm.Cos(a_209) * d_210) * 1.2))));
py_212 = Add(GetIdx(q_202, 3D), ((V)(((FdLibm.Sin(a_209) * d_210) * 0.9))));
lit_213 = Max(0D, Min(1D, (((0.52 - ((ToNum(px_211) - cx_148) * 0.014)) - ((ToNum(py_212) - cy_149) * 0.024)) + ((ToNum(Call(rnd_49, V.Undef, ((V)((((ToNum(i_133) * 900D) + (ToNum(j_203) * 40D)) + k_206))), ((V)(93D)))) - 0.5) * 0.4))));
Invoke(CL_150, "push", Arr(px_211, py_212, ((V)((1.9 + (ToNum(Call(rnd_49, V.Undef, ((V)((((ToNum(i_133) * 900D) + (ToNum(j_203) * 40D)) + k_206))), ((V)(94D)))) * 1.5)))), ((V)((ToNum(Call(rnd_49, V.Undef, ((V)((((ToNum(i_133) * 900D) + (ToNum(j_203) * 40D)) + k_206))), ((V)(95D)))) * 3.14))), ((V)(lit_213)), Call(rnd_49, V.Undef, ((V)((((ToNum(i_133) * 900D) + (ToNum(j_203) * 40D)) + k_206))), ((V)(96D)))));
k_206++;
}
}
return default;
}, 2, "", true));
show_151 = Invoke(Invoke(CL_150, "filter", Fn((V _arrowThis230, int _argc223, V c_229, V _a226, V _a227, V _a228, V[] _rest224) => {
return (LtN(GetIdx(c_229, 5D), ((ToNum(leaf_141) * 1.02) + 0.02)) ? V.True : V.False);
}, 1, "", true)), "sort", Fn((V _arrowThis222, int _argc214, V p2_220, V q2_221, V _a218, V _a219, V[] _rest215) => {
return ((V)((ToNum(GetIdx(p2_220, 4D)) - ToNum(GetIdx(q2_221, 4D)))));
}, 2, "", true));
if (Truthy(Get(show_151, "length"))) {
V T_231 = default;
V P_232 = default;
JsStrBuf ms_233 = null;
JsStrBuf hi_234 = null;
V fa_235 = default;
T_231 = Arr(Call(mix_139, V.Undef, Get(mx_138, "tr1"), ((V)("#0e1a08")), ((V)(0.38))), Call(mix_139, V.Undef, Get(mx_138, "tr1"), ((V)("#0e1a08")), ((V)(0.12))), Call(mix_139, V.Undef, Get(mx_138, "tr1"), Get(mx_138, "tr0"), ((V)(0.38))), Call(mix_139, V.Undef, Get(mx_138, "tr0"), Get(mx_138, "tr1"), ((V)(0.3))), Call(mix_139, V.Undef, Get(mx_138, "tr0"), ((V)("#fff4c0")), ((V)(0.12))));
P_232 = Arr(((V)("")), ((V)("")), ((V)("")), ((V)("")), ((V)("")));
ms_233 = new JsStrBuf("");
Invoke(ends_147, "forEach", Fn((V _arrowThis243, int _argc236, V q_242, V _a239, V _a240, V _a241, V[] _rest237) => {
ms_233.V(Call(natE_44, V.Undef, Add(GetIdx(q_242, 2D), ((V)(0.6))), Add(GetIdx(q_242, 3D), ((V)(0.8))), ((V)(((SEqN(GetIdx(q_242, 5D), 3D) ? 5.6 : 4.4) * ToNum(leaf_141)))), ((V)(((SEqN(GetIdx(q_242, 5D), 3D) ? 4.6 : 3.6) * ToNum(leaf_141)))), ((V)(0D))));
return default;
}, 1, "", true));
Invoke(show_151, "forEach", Fn((V _arrowThis251, int _argc244, V c_250, V _a247, V _a248, V _a249, V[] _rest245) => {
double k_252 = 0;
k_252 = Min(4D, System.Math.Floor((ToNum(GetIdx(c_250, 4D)) * 5D)));
OpSetK(P_232, ((V)(k_252)), 0, Call(natE_44, V.Undef, GetIdx(c_250, 0D), GetIdx(c_250, 1D), GetIdx(c_250, 2D), ((V)((ToNum(GetIdx(c_250, 2D)) * 0.72))), GetIdx(c_250, 3D)));
return default;
}, 1, "", true));
hi_234 = new JsStrBuf("");
Invoke(Invoke(show_151, "filter", Fn((V _arrowThis268, int _argc261, V c_267, V _a264, V _a265, V _a266, V[] _rest262) => {
return (GtN(GetIdx(c_267, 4D), 0.72) ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _arrowThis260, int _argc253, V c_259, V _a256, V _a257, V _a258, V[] _rest254) => {
hi_234.V(Call(natE_44, V.Undef, ((V)((ToNum(GetIdx(c_259, 0D)) - 0.4))), ((V)((ToNum(GetIdx(c_259, 1D)) - 0.4))), ((V)((ToNum(GetIdx(c_259, 2D)) * 0.4))), ((V)((ToNum(GetIdx(c_259, 2D)) * 0.26))), GetIdx(c_259, 3D)));
return default;
}, 1, "", true));
o_144.S("<g><animateTransform attributeName=\"transform\" type=\"rotate\" values=\"-1.2 0 20;1.2 0 20;-1.2 0 20\" dur=\"").V(Invoke(((V)((4.8 + (ToNum(i_133) * 0.7)))), "toFixed", ((V)(1D)))).S("s\" repeatCount=\"indefinite\" calcMode=\"spline\" keySplines=\"0.45 0 0.55 1;0.45 0 0.55 1\"/>").S("<ellipse cx=\"").V(Call(n1_42, V.Undef, ((V)((cx_148 + 2D))))).S("\" cy=\"").V(Call(n1_42, V.Undef, ((V)((cy_149 + 6D))))).S("\" rx=\"").V(Call(n1_42, V.Undef, ((V)((12D * ToNum(leaf_141)))))).S("\" ry=\"").V(Call(n1_42, V.Undef, ((V)((6D * ToNum(leaf_141)))))).S("\" fill=\"#0e1a08\" opacity=\"").V(Invoke(((V)((0.3 * ToNum(leaf_141)))), "toFixed", ((V)(2D)))).S("\" filter=\"url(#mpNatBlur)\"/>").S("<path d=\"").S(ms_233.Str).S("\" fill=\"").V(Call(mix_139, V.Undef, Get(mx_138, "tr1"), ((V)("#0e1a08")), ((V)(0.45)))).S("\" opacity=\"").V(Invoke(((V)((0.9 * ToNum(leaf_141)))), "toFixed", ((V)(2D)))).S("\"/>").V(Invoke(Invoke(P_232, "map", Fn((V _arrowThis277, int _argc269, V d_275, V k_276, V _a273, V _a274, V[] _rest270) => {
return ((V)((Truthy(d_275) ? JsStrBuf.Begin().S("<path d=\"").V(d_275).S("\" fill=\"").V(GetK(T_231, k_276)).S("\"/>").End() : "")));
}, 2, "", true)), "join", ((V)("")))).S((((hi_234.Str).Length != 0) ? string.Concat("<path d=\"", hi_234.Str, "\" fill=\"#fffbe0\" opacity=\"0.28\"/>") : ""));
fa_235 = Call(natSS_41, V.Undef, ((V)(0.75)), ((V)(1D)), v_137);
if (GtN(fa_235, 0.01)) {
JsStrBuf fr_278 = null;
fr_278 = new JsStrBuf("");
{
double k_279 = 0;
k_279 = 0D;
while (true) {
if (!((k_279 < 7D))) break;
V c_281 = default;
c_281 = GetIdx(show_151, System.Math.Floor((ToNum(Call(rnd_49, V.Undef, ((V)(((ToNum(i_133) * 31D) + k_279))), ((V)(97D)))) * ToNum(Get(show_151, "length")))));
if (Truthy((c_281 is var _t282 && !Truthy(_t282) ? _t282 : (GtN(GetIdx(c_281, 4D), 0.35) ? V.True : V.False)))) {
fr_278.V(Call(natE_44, V.Undef, GetIdx(c_281, 0D), ((V)((ToNum(GetIdx(c_281, 1D)) - 0.4))), ((V)(0.9)), ((V)(0.9)), ((V)(0D))));
}
k_279++;
}
}
o_144.S("<path d=\"").S(fr_278.Str).S("\" fill=\"").S((NumTruthy((ToNum(i_133) % 2D)) ? "#f4b4c8" : "#c8282e")).S("\" opacity=\"").V(Invoke(((V)((0.9 * ToNum(fa_235)))), "toFixed", ((V)(2D)))).S("\"/>");
}
o_144.S("</g>");
}
if (LtN(leaf_141, 0.5)) {
o_144.S("<g opacity=\"0\"><animate attributeName=\"opacity\" values=\"0;0.9;0.9;0\" dur=\"").V(Add(((V)(6D)), i_133)).S("s\" repeatCount=\"indefinite\"/><animateTransform attributeName=\"transform\" type=\"translate\" values=\"0 0;6 30\" dur=\"").V(Add(((V)(6D)), i_133)).S("s\" repeatCount=\"indefinite\"/><path d=\"").V(Call(natE_44, V.Undef, ((V)((-8D))), ((V)((-4D))), ((V)(1.4)), ((V)(0.8)), ((V)(0.6)))).S("\" fill=\"#8a6a3a\"/></g>");
}
return ((V)(string.Concat(o_144.Str, "</g>")));
return default;
}, 7, "natTree", false);
natBush_46 = Fn((V _self283, int _argc284, V i_290, V x_291, V y_292, V rx_293, V[] _rest285) => {
V leaf_298 = default;
V tw_299 = default;
JsStrBuf o_300 = null;
JsStrBuf tws_301 = null;
V T_302 = default;
V P_303 = default;
V ry_294 = default;
V v_295 = default;
V mx_296 = default;
V mix_297 = default;
ry_294 = (_argc284 > 4 ? _rest285[0] : V.Undef);
v_295 = (_argc284 > 5 ? _rest285[1] : V.Undef);
mx_296 = (_argc284 > 6 ? _rest285[2] : V.Undef);
mix_297 = (_argc284 > 7 ? _rest285[3] : V.Undef);
leaf_298 = Call(natSS_41, V.Undef, ((V)(0.08)), ((V)(0.8)), v_295);
tw_299 = Call(mix_297, V.Undef, ((V)("#5d5650")), ((V)("#5a4128")), v_295);
o_300 = new JsStrBuf(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(n1_42, V.Undef, Add(x_291, ((V)(3D))))).S("\" cy=\"").V(Call(n1_42, V.Undef, Add(y_292, ((V)((ToNum(ry_294) * 0.8)))))).S("\" rx=\"").V(Call(n1_42, V.Undef, ((V)((ToNum(rx_293) * 1.1))))).S("\" ry=\"").V(Call(n1_42, V.Undef, ((V)((ToNum(ry_294) * 0.45))))).S("\" fill=\"#16200c\" opacity=\"0.3\" filter=\"url(#mpNatBlur)\"/>").End());
tws_301 = new JsStrBuf("");
{
double k_304 = 0;
k_304 = 0D;
while (true) {
if (!((k_304 < 9D))) break;
double a_306 = 0;
double l_307 = 0;
a_306 = (((-1.2) + (k_304 * 0.3)) + ((ToNum(Call(rnd_49, V.Undef, ((V)(((ToNum(i_290) * 20D) + k_304))), ((V)(101D)))) - 0.5) * 0.2));
l_307 = (ToNum(ry_294) * (1D + (ToNum(Call(rnd_49, V.Undef, ((V)(((ToNum(i_290) * 20D) + k_304))), ((V)(102D)))) * 0.5)));
tws_301.S("M").V(Call(n1_42, V.Undef, Add(x_291, ((V)((((k_304 - 4D) * ToNum(rx_293)) * 0.08)))))).S(" ").V(Call(n1_42, V.Undef, Add(y_292, ((V)((ToNum(ry_294) * 0.6)))))).S("l").V(Call(n1_42, V.Undef, ((V)(((FdLibm.Sin(a_306) * l_307) * 1.3))))).S(" ").V(Call(n1_42, V.Undef, ((V)(((-FdLibm.Cos(a_306)) * l_307)))));
k_304++;
}
}
o_300.S("<path d=\"").S(tws_301.Str).S("\" stroke=\"").V(tw_299).S("\" stroke-width=\"0.9\" stroke-linecap=\"round\" fill=\"none\"/>");
T_302 = Arr(Call(mix_297, V.Undef, Get(mx_296, "tr1"), ((V)("#0e1a08")), ((V)(0.38))), Call(mix_297, V.Undef, Get(mx_296, "tr1"), ((V)("#0e1a08")), ((V)(0.12))), Call(mix_297, V.Undef, Get(mx_296, "tr1"), Get(mx_296, "tr0"), ((V)(0.38))), Call(mix_297, V.Undef, Get(mx_296, "tr0"), Get(mx_296, "tr1"), ((V)(0.3))), Call(mix_297, V.Undef, Get(mx_296, "tr0"), ((V)("#fff4c0")), ((V)(0.12))));
P_303 = Arr(((V)("")), ((V)("")), ((V)("")), ((V)("")), ((V)("")));
if (GtN(leaf_298, 0.05)) {
o_300.S("<ellipse cx=\"").V(Call(n1_42, V.Undef, Add(x_291, ((V)(0.5))))).S("\" cy=\"").V(Call(n1_42, V.Undef, y_292)).S("\" rx=\"").V(Call(n1_42, V.Undef, ((V)(((ToNum(rx_293) * 0.9) * ToNum(leaf_298)))))).S("\" ry=\"").V(Call(n1_42, V.Undef, ((V)(((ToNum(ry_294) * 0.9) * ToNum(leaf_298)))))).S("\" fill=\"").V(Call(mix_297, V.Undef, Get(mx_296, "tr1"), ((V)("#0e1a08")), ((V)(0.45)))).S("\" opacity=\"").V(Invoke(((V)((0.9 * ToNum(leaf_298)))), "toFixed", ((V)(2D)))).S("\"/>");
}
{
double k_308 = 0;
k_308 = 0D;
while (true) {
if (!((k_308 < 110D))) break;
double a_310 = 0;
double r_311 = 0;
V px_312 = default;
double py_313 = 0;
double lit_314 = 0;
if (GtN(Call(rnd_49, V.Undef, ((V)(((ToNum(i_290) * 300D) + k_308))), ((V)(103D))), ((ToNum(leaf_298) * 1.02) + 0.02))) {
goto _cont309;
}
a_310 = (ToNum(Call(rnd_49, V.Undef, ((V)(((ToNum(i_290) * 300D) + k_308))), ((V)(104D)))) * 3.14);
r_311 = System.Math.Sqrt(ToNum(Call(rnd_49, V.Undef, ((V)(((ToNum(i_290) * 300D) + k_308))), ((V)(105D)))));
px_312 = Add(x_291, ((V)(((((FdLibm.Cos(a_310) * r_311) * ToNum(rx_293)) * 1.05) * (LtN(Call(rnd_49, V.Undef, ((V)(((ToNum(i_290) * 300D) + k_308))), ((V)(106D))), 0.5) ? (-1D) : 1D)))));
py_313 = (ToNum(Add(y_292, ((V)((ToNum(ry_294) * 0.4))))) - (((FdLibm.Sin(a_310) * r_311) * ToNum(ry_294)) * 1.5));
lit_314 = Max(0D, Min(1D, (((0.55 - (((ToNum(px_312) - ToNum(x_291)) / ToNum(rx_293)) * 0.25)) - (((py_313 - ToNum(y_292)) / ToNum(ry_294)) * 0.3)) + ((ToNum(Call(rnd_49, V.Undef, ((V)(((ToNum(i_290) * 300D) + k_308))), ((V)(107D)))) - 0.5) * 0.35))));
OpSetK(P_303, ((V)(Min(4D, System.Math.Floor((lit_314 * 5D))))), 0, Call(natE_44, V.Undef, px_312, ((V)(py_313)), Add(((V)(1.3)), Call(rnd_49, V.Undef, ((V)(((ToNum(i_290) * 300D) + k_308))), ((V)(108D)))), ((V)(1D)), ((V)((ToNum(Call(rnd_49, V.Undef, ((V)(((ToNum(i_290) * 300D) + k_308))), ((V)(109D)))) * 3D)))));
_cont309: ;
k_308++;
}
}
o_300.V(Invoke(Invoke(P_303, "map", Fn((V _arrowThis323, int _argc315, V d_321, V k_322, V _a319, V _a320, V[] _rest316) => {
return ((V)((Truthy(d_321) ? JsStrBuf.Begin().S("<path d=\"").V(d_321).S("\" fill=\"").V(GetK(T_302, k_322)).S("\"/>").End() : "")));
}, 2, "", true)), "join", ((V)(""))));
if (GtN(v_295, 0.72)) {
JsStrBuf fl_324 = null;
fl_324 = new JsStrBuf("");
{
double k_325 = 0;
k_325 = 0D;
while (true) {
if (!((k_325 < 5D))) break;
fl_324.V(Call(natE_44, V.Undef, Add(x_291, ((V)((((ToNum(Call(rnd_49, V.Undef, ((V)(((ToNum(i_290) * 9D) + k_325))), ((V)(110D)))) - 0.5) * ToNum(rx_293)) * 1.4)))), ((V)((ToNum(y_292) - ((ToNum(Call(rnd_49, V.Undef, ((V)(((ToNum(i_290) * 9D) + k_325))), ((V)(111D)))) * ToNum(ry_294)) * 0.9)))), ((V)(0.6)), ((V)(0.6)), ((V)(0D))));
k_325++;
}
}
o_300.S("<path d=\"").S(fl_324.Str).S("\" fill=\"").S((NumTruthy((ToNum(i_290) % 2D)) ? "#fff2a0" : "#f6b8d0")).S("\" opacity=\"").V(Invoke(Call(natSS_41, V.Undef, ((V)(0.72)), ((V)(1D)), v_295), "toFixed", ((V)(2D)))).S("\"/>");
}
return ((V)(o_300.Str));
return default;
}, 8, "natBush", false);
natMap_47 = Fn((V _self327, int _argc328, V v_334, V mx_335, V mix_336, V _a333, V[] _rest329) => {
double dead_337 = 0;
JsStrBuf B_338 = null;
V F_339 = default;
dead_337 = (1D - ToNum(v_334));
B_338 = new JsStrBuf(JsStrBuf.Begin().S("<defs><clipPath id=\"mpNatClip\"><path clip-rule=\"evenodd\" d=\"").V(MAPGRASS_35).S(" ").V(MAPROAD_36).S("\"/></clipPath><filter id=\"mpNatBlur\" x=\"-40%\" y=\"-80%\" width=\"180%\" height=\"260%\"><feGaussianBlur stdDeviation=\"1.6\"/></filter><filter id=\"mpNatBlur2\" x=\"-30%\" y=\"-60%\" width=\"160%\" height=\"220%\"><feGaussianBlur stdDeviation=\"7\"/></filter></defs><g clip-path=\"url(#mpNatClip)\">").End());
{
JsStrBuf lt_340 = null;
JsStrBuf dk_341 = null;
lt_340 = new JsStrBuf("");
dk_341 = new JsStrBuf("");
{
double k_342 = 0;
k_342 = 0D;
while (true) {
if (!((k_342 < 40D))) break;
double x_344 = 0;
double y_345 = 0;
V e_346 = default;
x_344 = (100D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_342)), ((V)(121D)))) * 690D));
y_345 = (72D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_342)), ((V)(122D)))) * 292D));
e_346 = ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(n1_42, V.Undef, ((V)(x_344)))).S("\" cy=\"").V(Call(n1_42, V.Undef, ((V)(y_345)))).S("\" rx=\"").V(Call(n1_42, V.Undef, ((V)((26D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_342)), ((V)(123D)))) * 40D)))))).S("\" ry=\"").V(Call(n1_42, V.Undef, ((V)((10D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_342)), ((V)(124D)))) * 14D)))))).S("\"/>").End()));
if (NumTruthy((k_342 % 2D))) {
lt_340.V(e_346);
} else {
dk_341.V(e_346);
}
k_342++;
}
}
B_338.S("<g filter=\"url(#mpNatBlur2)\"><g fill=\"").V(Call(mix_336, V.Undef, Call(mix_336, V.Undef, ((V)("#c8b07a")), ((V)("#d8f0a0")), v_334), Get(mx_335, "grass"), ((V)(0.4)))).S("\" opacity=\"0.32\">").S(lt_340.Str).S("</g><g fill=\"").V(Call(mix_336, V.Undef, Call(mix_336, V.Undef, ((V)("#4a3e26")), ((V)("#1e3a10")), v_334), Get(mx_335, "grass"), ((V)(0.35)))).S("\" opacity=\"0.3\">").S(dk_341.Str).S("</g></g>");
}
if ((dead_337 > 0.02)) {
JsStrBuf pt_347 = null;
JsStrBuf ck_348 = null;
pt_347 = new JsStrBuf("");
ck_348 = new JsStrBuf("");
{
double k_349 = 0;
k_349 = 0D;
while (true) {
if (!((k_349 < 14D))) break;
pt_347.S("<ellipse cx=\"").V(Call(n1_42, V.Undef, ((V)((110D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_349)), ((V)(41D)))) * 660D)))))).S("\" cy=\"").V(Call(n1_42, V.Undef, ((V)((80D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_349)), ((V)(42D)))) * 270D)))))).S("\" rx=\"").V(Call(n1_42, V.Undef, ((V)((14D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_349)), ((V)(43D)))) * 22D)))))).S("\" ry=\"").V(Call(n1_42, V.Undef, ((V)((5D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_349)), ((V)(44D)))) * 6D)))))).S("\"/>");
k_349++;
}
}
{
double k_351 = 0;
k_351 = 0D;
while (true) {
if (!((k_351 < 26D))) break;
double x_353 = 0;
double y_354 = 0;
x_353 = (110D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_351)), ((V)(51D)))) * 660D));
y_354 = (80D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_351)), ((V)(52D)))) * 270D));
ck_348.S("M").V(Call(n1_42, V.Undef, ((V)(x_353)))).S(" ").V(Call(n1_42, V.Undef, ((V)(y_354))));
{
double j_355 = 0;
j_355 = 0D;
while (true) {
if (!((j_355 < 5D))) break;
x_353 = (x_353 + ((ToNum(Call(rnd_49, V.Undef, ((V)(((k_351 * 6D) + j_355))), ((V)(53D)))) - 0.5) * 12D));
y_354 = (y_354 + ((ToNum(Call(rnd_49, V.Undef, ((V)(((k_351 * 6D) + j_355))), ((V)(54D)))) - 0.5) * 6D));
ck_348.S("L").V(Call(n1_42, V.Undef, ((V)(x_353)))).S(" ").V(Call(n1_42, V.Undef, ((V)(y_354))));
if ((j_355 == 2D)) {
ck_348.S("m0 0l").V(Call(n1_42, V.Undef, ((V)(((ToNum(Call(rnd_49, V.Undef, ((V)(k_351)), ((V)(55D)))) - 0.5) * 8D))))).S(" ").V(Call(n1_42, V.Undef, ((V)(((ToNum(Call(rnd_49, V.Undef, ((V)(k_351)), ((V)(56D)))) - 0.5) * 5D))))).S("M").V(Call(n1_42, V.Undef, ((V)(x_353)))).S(" ").V(Call(n1_42, V.Undef, ((V)(y_354))));
}
j_355++;
}
}
k_351++;
}
}
B_338.S("<g fill=\"#8a7a50\" opacity=\"").V(Invoke(((V)((0.45 * dead_337))), "toFixed", ((V)(2D)))).S("\" filter=\"url(#mpNatBlur)\">").S(pt_347.Str).S("</g><path d=\"").S(ck_348.Str).S("\" fill=\"none\" stroke=\"#3a2e1e\" stroke-width=\"0.7\" stroke-linecap=\"round\" opacity=\"").V(Invoke(((V)((0.55 * Pow(dead_337, 1.1)))), "toFixed", ((V)(2D)))).S("\"/>");
}
{
V BL_357 = default;
V g0_358 = default;
V g1_359 = default;
V g2_360 = default;
BL_357 = Arr(((V)("")), ((V)("")), ((V)("")));
{
double k_361 = 0;
k_361 = 0D;
while (true) {
if (!((k_361 < 640D))) break;
double x_363 = 0;
double y_364 = 0;
double h_365 = 0;
double lean_366 = 0;
x_363 = (96D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_361)), ((V)(131D)))) * 694D));
y_364 = (70D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_361)), ((V)(132D)))) * 296D));
h_365 = (1.6 + (ToNum(Call(rnd_49, V.Undef, ((V)(k_361)), ((V)(133D)))) * 2.2));
lean_366 = (((ToNum(Call(rnd_49, V.Undef, ((V)(k_361)), ((V)(134D)))) - 0.5) * 1.6) + (dead_337 * 0.9));
OpSetK(BL_357, ((V)((k_361 % 3D))), 0, ((V)(JsStrBuf.Begin().S("M").V(Call(n1_42, V.Undef, ((V)(x_363)))).S(" ").V(Call(n1_42, V.Undef, ((V)(y_364)))).S("l").V(Call(n1_42, V.Undef, ((V)(lean_366)))).S(" ").V(Call(n1_42, V.Undef, ((V)((-h_365))))).End())));
k_361++;
}
}
g0_358 = Call(mix_336, V.Undef, ((V)("#9a8450")), Call(mix_336, V.Undef, Get(mx_335, "grassD"), ((V)("#14300c")), ((V)(0.25))), v_334);
g1_359 = Call(mix_336, V.Undef, ((V)("#b9a066")), Get(mx_335, "grassD"), v_334);
g2_360 = Call(mix_336, V.Undef, ((V)("#d4c088")), Call(mix_336, V.Undef, Get(mx_335, "grass"), ((V)("#e8f8b0")), ((V)(0.35))), v_334);
B_338.S("<path d=\"").V(GetIdx(BL_357, 0D)).S("\" stroke=\"").V(g0_358).S("\" stroke-width=\"0.55\" stroke-linecap=\"round\" fill=\"none\" opacity=\"0.7\"/><path d=\"").V(GetIdx(BL_357, 1D)).S("\" stroke=\"").V(g1_359).S("\" stroke-width=\"0.5\" stroke-linecap=\"round\" fill=\"none\" opacity=\"0.6\"/><path d=\"").V(GetIdx(BL_357, 2D)).S("\" stroke=\"").V(g2_360).S("\" stroke-width=\"0.45\" stroke-linecap=\"round\" fill=\"none\" opacity=\"0.55\"/>");
}
if (GtN(v_334, 0.5)) {
V C_367 = default;
V P_368 = default;
C_367 = Arr(((V)("#ffffff")), ((V)("#ffe25a")), ((V)("#f4a8c8")), ((V)("#b9a0f0")));
P_368 = Arr(((V)("")), ((V)("")), ((V)("")), ((V)("")));
{
double k_369 = 0;
k_369 = 0D;
while (true) {
if (!((k_369 < 90D))) break;
double cx_371 = 0;
double cy_372 = 0;
cx_371 = (110D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_369)), ((V)(141D)))) * 660D));
cy_372 = (80D + (ToNum(Call(rnd_49, V.Undef, ((V)(k_369)), ((V)(142D)))) * 270D));
{
double j_373 = 0;
j_373 = 0D;
while (true) {
if (!((j_373 < 3D))) break;
OpSetK(P_368, ((V)((k_369 % 4D))), 0, Call(natE_44, V.Undef, ((V)((cx_371 + ((ToNum(Call(rnd_49, V.Undef, ((V)(((k_369 * 3D) + j_373))), ((V)(143D)))) - 0.5) * 5D)))), ((V)((cy_372 + ((ToNum(Call(rnd_49, V.Undef, ((V)(((k_369 * 3D) + j_373))), ((V)(144D)))) - 0.5) * 3D)))), ((V)(0.55)), ((V)(0.45)), ((V)(0D))));
j_373++;
}
}
k_369++;
}
}
B_338.S("<g opacity=\"").V(Invoke(Call(natSS_41, V.Undef, ((V)(0.5)), ((V)(1D)), v_334), "toFixed", ((V)(2D)))).S("\">").V(Invoke(Invoke(P_368, "map", Fn((V _arrowThis383, int _argc375, V d_381, V k_382, V _a379, V _a380, V[] _rest376) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(d_381).S("\" fill=\"").V(GetK(C_367, k_382)).S("\"/>").End()));
}, 2, "", true)), "join", ((V)("")))).S("</g>");
}
if ((dead_337 > 0.02)) {
B_338.S("<path d=\"").V(MAPGRASS_35).S("\" fill=\"#1e1a12\" opacity=\"").V(Invoke(((V)((0.3 * dead_337))), "toFixed", ((V)(2D)))).S("\"/>");
}
B_338.S("</g>").V(Invoke(Invoke(MTB_38, "map", Fn((V _arrowThis398, int _argc384, V _a386, V i_390, V _a388, V _a389, V[] _rest385) => {
V x_393 = default;
V y_395 = default;
V s_397 = default;
{ V _t391 = ListOf(_a386);
{ V _t392 = GetIdx(_t391, 0D);
x_393 = _t392; }
{ V _t394 = GetIdx(_t391, 1D);
y_395 = _t394; }
{ V _t396 = GetIdx(_t391, 2D);
s_397 = _t396; }
}
return Call(natTree_45, V.Undef, i_390, x_393, y_395, s_397, v_334, mx_335, mix_336);
}, 2, "", true)), "join", ((V)(""))));
F_339 = Add(Invoke(Invoke(MBU_40, "map", Fn((V _arrowThis415, int _argc399, V _a401, V i_405, V _a403, V _a404, V[] _rest400) => {
V x_408 = default;
V y_410 = default;
V rx_412 = default;
V ry_414 = default;
{ V _t406 = ListOf(_a401);
{ V _t407 = GetIdx(_t406, 0D);
x_408 = _t407; }
{ V _t409 = GetIdx(_t406, 1D);
y_410 = _t409; }
{ V _t411 = GetIdx(_t406, 2D);
rx_412 = _t411; }
{ V _t413 = GetIdx(_t406, 3D);
ry_414 = _t413; }
}
return Call(natBush_46, V.Undef, i_405, x_408, y_410, rx_412, ry_414, v_334, mx_335, mix_336);
}, 2, "", true)), "join", ((V)(""))), Invoke(Invoke(MTF_39, "map", Fn((V _arrowThis430, int _argc416, V _a418, V i_422, V _a420, V _a421, V[] _rest417) => {
V x_425 = default;
V y_427 = default;
V s_429 = default;
{ V _t423 = ListOf(_a418);
{ V _t424 = GetIdx(_t423, 0D);
x_425 = _t424; }
{ V _t426 = GetIdx(_t423, 1D);
y_427 = _t426; }
{ V _t428 = GetIdx(_t423, 2D);
s_429 = _t428; }
}
return Call(natTree_45, V.Undef, Add(i_422, ((V)(2D))), x_425, y_427, s_429, v_334, mx_335, mix_336);
}, 2, "", true)), "join", ((V)(""))));
return NewObj(2).Put("B", ((V)(B_338.Str))).Put("F", F_339).V;
return default;
}, 3, "natMap", false);
plain_54 = Fn((V _self431, int _argc432, V o_438, V _a435, V _a436, V _a437, V[] _rest433) => {
return Invoke(G("JSON"), "parse", Invoke(G("JSON"), "stringify", o_438, Fn((V _self439, int _argc440, V k_446, V v_447, V _a444, V _a445, V[] _rest441) => {
return (string.Equals(Typeof(v_447), "function") ? V.Undef : v_447);
return default;
}, 2, "", false)));
return default;
}, 1, "plain", false);
RCSV_9 = Arr(((V)("uploads/tamagotchi_house_renovation_catalog-17d94edd.csv")), ((V)("uploads/tamagotchi_house_renovation_catalog.csv")));
RMAP_10 = NewObj(8).Put("MOV", ((V)("movie"))).Put("LIV", ((V)("living"))).Put("KIT", ((V)("kitchen"))).Put("BTH", ((V)("bathroom"))).Put("BED", ((V)("bedroom"))).Put("YRD", ((V)("backyard"))).Put("CLB", ((V)("dance"))).Put("BCH", ((V)("beach"))).V;
SLOTCAT_11 = NewObj(56).Put("Wall Surface", ((V)("Walls"))).Put("Wall & Backsplash", ((V)("Walls"))).Put("Walls / Fence", ((V)("Walls"))).Put("Doorway", ((V)("Walls"))).Put("Window Treatment", ((V)("Walls"))).Put("Entry & Divider", ((V)("Walls"))).Put("Kitchen Window", ((V)("Walls"))).Put("Window / Balcony", ((V)("Walls"))).Put("Club Entrance", ((V)("Walls"))).Put("Wall Sconces", ((V)("Walls"))).Put("Wall Hangings", ((V)("Walls"))).Put("Wall Art", ((V)("Walls"))).Put("Mirror", ((V)("Walls"))).Put("Lighting", ((V)("Walls"))).Put("Wall Accent", ((V)("Walls"))).Put("Wall Storage", ((V)("Walls"))).Put("Wall Accents", ((V)("Walls"))).Put("Club Wall Art", ((V)("Walls"))).Put("Wall Quote", ((V)("Walls"))).Put("Wall Sign", ((V)("Walls"))).Put("Floor Surface", ((V)("Floor"))).Put("Ground Cover", ((V)("Floor"))).Put("Area Rug", ((V)("Floor"))).Put("Center Rug", ((V)("Floor"))).Put("Floor Mat", ((V)("Floor"))).Put("Patio Textile", ((V)("Floor"))).Put("Bedroom Rug", ((V)("Floor"))).Put("Floor Runners", ((V)("Floor"))).Put("Ceiling & Trim", ((V)("Ceiling"))).Put("Ceiling & Exhaust", ((V)("Ceiling"))).Put("Ceiling & Ventilation", ((V)("Ceiling"))).Put("Ceiling & Truss", ((V)("Ceiling"))).Put("Overhead Light", ((V)("Ceiling"))).Put("Ceiling Light", ((V)("Ceiling"))).Put("Island Lighting", ((V)("Ceiling"))).Put("Bedroom Chandelier", ((V)("Ceiling"))).Put("Main Club Light", ((V)("Ceiling"))).Put("Pergola / Canopy", ((V)("Ceiling"))).Put("LED Light Design", ((V)("Ceiling"))).Put("Main Screen", ((V)("Electronics"))).Put("Projector / Player", ((V)("Electronics"))).Put("Speakers", ((V)("Electronics"))).Put("Snack Station", ((V)("Electronics"))).Put("Beverage Cooler", ((V)("Electronics"))).Put("Media Center", ((V)("Electronics"))).Put("Fridge Progression", ((V)("Electronics"))).Put("Cooking Range", ((V)("Electronics"))).Put("Dishwashing", ((V)("Electronics"))).Put("Beverage Maker", ((V)("Electronics"))).Put("Prep Appliance", ((V)("Electronics"))).Put("Bedroom Electronics", ((V)("Electronics"))).Put("DJ Console", ((V)("Electronics"))).Put("Turntables / Mixers", ((V)("Electronics"))).Put("Club Audio", ((V)("Electronics"))).Put("Atmospheric FX", ((V)("Electronics"))).Put("Club Entertainment", ((V)("Electronics"))).V;
roleOf_12 = Fn((V _arrowThis455, int _argc448, V r_454, V _a451, V _a452, V _a453, V[] _rest449) => {
return (Get(r_454, "role") is var _t456 && Truthy(_t456) ? _t456 : ((V)((SEqS(Get(r_454, "slotName"), "Main Screen") ? "screen" : (SEqS(Get(r_454, "slotName"), "Projector / Player") ? "player" : (Truthy(Invoke(NewRegExp(RX1, "^(Speakers|Club Audio)$", ""), "test", Get(r_454, "slotName"))) ? "spk" : ""))))));
}, 1, "", true);
CEILS_13 = NewRegExp(RX2, "Ceiling Light|Island Lighting|Bedroom Chandelier|Overhead Light", "");
catOf_14 = Fn((V _arrowThis464, int _argc457, V r_463, V _a460, V _a461, V _a462, V[] _rest458) => {
return (Get(r_463, "catO") is var _t466 && Truthy(_t466) ? _t466 : (Truthy(Invoke(NewRegExp(RX4, "dartboard", "i"), "test", Get(r_463, "name"))) ? ((V)("Walls")) : (Truthy(Invoke(NewRegExp(RX3, "washer|dryer|dry-cleaning", "i"), "test", Get(r_463, "name"))) ? ((V)("Electronics")) : (GetK(SLOTCAT_11, Get(r_463, "slotName")) is var _t465 && Truthy(_t465) ? _t465 : ((V)("Furniture"))))));
}, 1, "", true);
BIGR_15 = NewObj(8).Put("living", ((V)(0.8))).Put("kitchen", ((V)(0.8))).Put("bathroom", ((V)(0.8))).Put("bedroom", ((V)(0.8))).Put("backyard", ((V)(0.72))).Put("dance", ((V)(0.8))).Put("movie", ((V)(0.8))).Put("beach", ((V)(0.72))).V;
edgeR_16 = Fn((V _arrowThis474, int _argc467, V y_473, V _a470, V _a471, V _a472, V[] _rest468) => {
double v_475 = 0;
if (LtN(y_473, 112D)) {
return ((V)(120D));
}
v_475 = ((400D - ToNum(y_473)) / 300D);
return ((V)(Max(0D, (426D - (600D * System.Math.Sqrt(Max(0D, (1D - (v_475 * v_475)))))))));
return default;
}, 1, "", true);
X_17 = Get(G_8, "House3D");
RD_18 = Get(G_8, "RenoDraw");
sh_19 = NewObj(11).Put("X", X_17).Put("SZ", NewObj(1).Put("a", NewObj(0).V).V).Put("rows", Arr()).Put("byId", New(G("Map"))).Put("texC", NewObj(0).V).Put("rnReg", Fn((V _self476, int _argc477, V id_483, V _a480, V _a481, V _a482, V[] _rest478) => {
V X_484 = default;
V key_485 = default;
V r_486 = default;
V Dr_487 = default;
V src_488 = default;
V A_489 = default;
V L_490 = default;
V fit_491 = default;
V k_492 = default;
X_484 = Get(_self476, "X");
key_485 = ((V)(JsStrBuf.Begin().S("R:").V(id_483).End()));
if (Truthy(GetK(Get(X_484, "CAT"), key_485))) {
return GetK(Get(X_484, "CAT"), key_485);
}
r_486 = (Get(_self476, "byId") is var _t493 && !Truthy(_t493) ? _t493 : Invoke(Get(_self476, "byId"), "get", id_483));
if (!(Truthy(r_486))) {
return V.Null;
}
Dr_487 = Invoke(_self476, "rnDraw", r_486, ((V)(0D)));
if (Truthy((((!(Truthy(Dr_487)) || !(Truthy(Get(Dr_487, "src")))) ? V.True : V.False) is var _t494 && Truthy(_t494) ? _t494 : Get(Dr_487, "surf")))) {
return V.Null;
}
src_488 = GetK(Get(X_484, "CAT"), ((V)(JsStrBuf.Begin().S("rv_").V(Get(r_486, "id")).S("_").V(Get(r_486, "tier")).S("_0_").V(Get(Invoke(_self476, "rnOpt", r_486), "st")).End())));
if (!(Truthy(src_488))) {
return V.Null;
}
A_489 = Object_assign(NewObj(0).V, src_488);
L_490 = Invoke(_self476, "rnLayer", r_486, Dr_487);
Invoke(Arr(((V)("fx")), ((V)("layers")), ((V)("wrap")), ((V)("glow")), ((V)("small")), ((V)("face")), ((V)("sign")), ((V)("txt"))), "forEach", Fn((V _arrowThis502, int _argc495, V k_501, V _a498, V _a499, V _a500, V[] _rest496) => {
return (DeleteK(A_489, k_501) ? V.True : V.False);
}, 1, "", true));
if (!SEqS(Get(A_489, "anim"), "tv")) {
Delete(A_489, "anim");
}
Object_assign(A_489, NewObj(10).Put("id", key_485).Put("reno", id_483).Put("rL", L_490).Put("n", Get(r_486, "name")).Put("room", GetK(RMAP_10, Get(r_486, "room"))).Put("lv", Get(r_486, "lv")).Put("price", Get(r_486, "cost")).Put("arch", (Get(src_488, "arch") is var _t504 && Truthy(_t504) ? _t504 : Invoke(GetIdx(Invoke(((V)(ToStrS((Get(Dr_487, "arch") is var _t503 && Truthy(_t503) ? _t503 : ((V)("")))))), "split", ((V)("."))), 0D), "replace", NewRegExp(RX5, "^#", ""), ((V)(""))))).Put("cols", Array_from(NewObj(1).Put("length", ((V)(Max(1D, ToNum(Get((Get(r_486, "colors") is var _t505 && Truthy(_t505) ? _t505 : Arr()), "length")))))).V, Fn((V _arrowThis512, int _argc506, V _a508, V _a509, V _a510, V _a511, V[] _rest507) => {
return GetIdx((Get(src_488, "cols") is var _t513 && Truthy(_t513) ? _t513 : Arr(NewObj(0).V)), 0D);
}, 0, "", true))).Put("_z0", (Get(src_488, "zs") is var _t514 && Truthy(_t514) ? _t514 : ((V)(1D)))).V);
if (!(Truthy(Get(A_489, "act")))) {
V nm_515 = default;
nm_515 = ((V)(ToStrS((Get(A_489, "n") is var _t516 && Truthy(_t516) ? _t516 : ((V)(""))))));
if (Truthy(Invoke(NewRegExp(RX6, "arcade|pinball|pong|billiards|hockey|dance-mat|rhythm|game", "i"), "test", nm_515))) {
Set(A_489, "act", ((V)("play")));
Set(A_489, "use", NewObj(2).Put("x", ((V)((-28D)))).Put("z", ((V)(50D))).V);
Set(A_489, "anim", ((V)("pulse")));
} else {
if (Truthy(Invoke(NewRegExp(RX7, "\\bDJ\\b|decks|turntable|booth", "i"), "test", nm_515))) {
Set(A_489, "act", ((V)("party")));
}
}
}
if (Truthy(((SEqS(Get(A_489, "arch"), "shower") ? V.True : V.False) is var _t519 && Truthy(_t519) ? _t519 : ((SEqS(Get(A_489, "act"), "wash") ? V.True : V.False) is var _t518 && !Truthy(_t518) ? _t518 : Invoke(NewRegExp(RX8, "shower", "i"), "test", ((V)(ToStrS((Get(A_489, "n") is var _t517 && Truthy(_t517) ? _t517 : ((V)(""))))))))))) {
Set(A_489, "act", ((V)("shower")));
}
if (Truthy(((!(Truthy(Get(A_489, "act"))) ? V.True : V.False) is var _t521 && !Truthy(_t521) ? _t521 : Invoke(NewRegExp(RX9, "Greenery|Planter|Plant Beds|Houseplant", "i"), "test", ((V)(ToStrS((Get(r_486, "slotName") is var _t520 && Truthy(_t520) ? _t520 : ((V)("")))))))))) {
Set(A_489, "act", ((V)("water")));
if (!(Truthy(Get(A_489, "use")))) {
Set(A_489, "use", NewObj(2).Put("x", ((V)((-((ToNum((Get(A_489, "w") is var _t522 && Truthy(_t522) ? _t522 : ((V)(40D)))) / 2D) + 14D))))).Put("z", ((V)(12D))).V);
}
}
if (SEqS(L_490, "floor")) {
Delete(A_489, "mount");
} else {
Set(A_489, "mount", ((V)("wall")));
if (Get(A_489, "elev").IsNullish) {
Set(A_489, "elev", ((V)(60D)));
}
}
if (SEqS(L_490, "floor")) {
V sn_523 = default;
sn_523 = ((V)(ToStrS((Get(r_486, "slotName") is var _t524 && Truthy(_t524) ? _t524 : ((V)(""))))));
if (Truthy((Get(src_488, "small") is var _t525 && Truthy(_t525) ? _t525 : Invoke(NewRegExp(RX10, "Clutter|Decor|Amenities|Bedroom Electronics|Reading Light|Prep Appliance|Beverage Maker", ""), "test", sn_523)))) {
Set(A_489, "small", ((V)(1D)));
Set(A_489, "noBlock", ((V)(1D)));
} else {
if (Truthy((Get(Dr_487, "top") is var _t526 && Truthy(_t526) ? _t526 : Invoke(NewRegExp(RX11, "Table|Counter|Cabinetry|Island|Nightstand|Bedside|Drawer Chest|Vanity|Desk|Media Rack|Shelving|Club Bar|Cart|Stump", ""), "test", sn_523)))) {
V th_527 = default;
th_527 = (Get(src_488, "topH") is var _t528 && Truthy(_t528) ? _t528 : ((V)(0D)));
if (!(Truthy(th_527))) {
try {
Invoke(Invoke(src_488, "build", Invoke(X_484, "pal", src_488, ((V)(0D))), ((V)(""))), "forEach", Fn((V _arrowThis536, int _argc529, V s0_535, V _a532, V _a533, V _a534, V[] _rest530) => {
return Invoke(Get(s0_535, "pts"), "forEach", Fn((V _arrowThis544, int _argc537, V q_543, V _a540, V _a541, V _a542, V[] _rest538) => {
if ((Gt(GetIdx(q_543, 1D), th_527) && (System.Math.Abs(ToNum(GetIdx(q_543, 0D))) < (ToNum(Get(src_488, "w")) * 0.45)))) {
th_527 = GetIdx(q_543, 1D);
}
return default;
}, 1, "", true));
}, 1, "", true));
} catch (System.Exception _ex545) {
V e_546 = default;
e_546 = Caught(_ex545);

}
}
if (GtN(th_527, 8D)) {
Set(A_489, "rTop", th_527);
}
}
}
}
if (!(Truthy(Get(X_484, "_rTopW")))) {
V tb_547 = default;
tb_547 = Get(X_484, "topOf");
Set(X_484, "topOf", Fn((V _arrowThis555, int _argc548, V t_554, V _a551, V _a552, V _a553, V[] _rest549) => {
V D0_556 = default;
D0_556 = GetK(Get(X_484, "CAT"), t_554);
return (Truthy((D0_556 is var _t559 && !Truthy(_t559) ? _t559 : Get(D0_556, "reno"))) ? ((V)((ToNum((Get(D0_556, "rTop") is var _t557 && Truthy(_t557) ? _t557 : ((V)(0D)))) * ToNum((Get(D0_556, "zs") is var _t558 && Truthy(_t558) ? _t558 : ((V)(1D))))))) : Call(tb_547, V.Undef, t_554));
return default;
}, 1, "", true));
Set(X_484, "_rTopW", ((V)(1D)));
}
fit_491 = GetK((Get(G("window"), "RenoFit") is var _t560 && Truthy(_t560) ? _t560 : NewObj(0).V), id_483);
if (Truthy((fit_491 is var _t561 && !Truthy(_t561) ? _t561 : ((System.Math.Abs((ToNum(fit_491) - 1D)) > 0.001) ? V.True : V.False)))) {
Set(A_489, "zs", ((V)((ToNum((Get(A_489, "zs") is var _t562 && Truthy(_t562) ? _t562 : ((V)(1D)))) * ToNum(fit_491)))));
OpSet(A_489, "w", 2, fit_491);
OpSet(A_489, "d", 2, fit_491);
if (Truthy(Get(A_489, "use"))) {
Set(A_489, "use", Object_assign(NewObj(0).V, Get(A_489, "use"), NewObj(2).Put("x", ((V)((ToNum(Get(Get(A_489, "use"), "x")) * ToNum(fit_491))))).Put("z", ((V)((ToNum(Get(Get(A_489, "use"), "z")) * ToNum(fit_491))))).V));
}
if (Truthy(Get(A_489, "seats"))) {
Set(A_489, "seats", Invoke(Get(A_489, "seats"), "map", Fn((V _arrowThis570, int _argc563, V q_569, V _a566, V _a567, V _a568, V[] _rest564) => {
return Object_assign(NewObj(0).V, q_569, NewObj(3).Put("x", ((V)((ToNum(Get(q_569, "x")) * ToNum(fit_491))))).Put("z", ((V)((ToNum(Get(q_569, "z")) * ToNum(fit_491))))).Put("h", ((V)((ToNum(Get(q_569, "h")) * ToNum(fit_491))))).V);
}, 1, "", true)));
}
}
k_492 = GetK(((Get(_self476, "SZ") is var _t571 && !Truthy(_t571) ? _t571 : Get(Get(_self476, "SZ"), "a")) is var _t572 && Truthy(_t572) ? _t572 : NewObj(0).V), Get(A_489, "arch"));
if (Truthy((k_492 is var _t573 && !Truthy(_t573) ? _t573 : ((System.Math.Abs((ToNum(k_492) - 1D)) > 0.001) ? V.True : V.False)))) {
Set(A_489, "zs", ((V)((ToNum((Get(A_489, "zs") is var _t574 && Truthy(_t574) ? _t574 : ((V)(1D)))) * ToNum(k_492)))));
OpSet(A_489, "w", 2, k_492);
OpSet(A_489, "d", 2, k_492);
if (Truthy(Get(A_489, "use"))) {
Set(A_489, "use", Object_assign(NewObj(0).V, Get(A_489, "use"), NewObj(2).Put("x", ((V)((ToNum(Get(Get(A_489, "use"), "x")) * ToNum(k_492))))).Put("z", ((V)((ToNum(Get(Get(A_489, "use"), "z")) * ToNum(k_492))))).V));
}
if (Truthy(Get(A_489, "seats"))) {
Set(A_489, "seats", Invoke(Get(A_489, "seats"), "map", Fn((V _arrowThis582, int _argc575, V q_581, V _a578, V _a579, V _a580, V[] _rest576) => {
return Object_assign(NewObj(0).V, q_581, NewObj(3).Put("x", ((V)((ToNum(Get(q_581, "x")) * ToNum(k_492))))).Put("z", ((V)((ToNum(Get(q_581, "z")) * ToNum(k_492))))).Put("h", ((V)((ToNum(Get(q_581, "h")) * ToNum(k_492))))).V);
}, 1, "", true)));
}
Set(A_489, "_uk", k_492);
}
SetK(Get(X_484, "CAT"), key_485, A_489);
return A_489;
return default;
}, 1, "rnReg", false)).Put("rnDraw", Fn((V _self583, int _argc584, V r_590, V ci_591, V rot_592, V st_593, V[] _rest585) => {
V D_595 = default;
V txt_594 = default;
txt_594 = (_argc584 > 4 ? _rest585[0] : V.Undef);
if (!(Truthy(r_590))) {
return V.Null;
}
Set(_self583, "rnDone", (Get(_self583, "rnDone") is var _t596 && Truthy(_t596) ? _t596 : NewObj(0).V));
D_595 = V.Null;
try {
D_595 = Invoke(Get(G("window"), "RenoDraw"), "draw", r_590, Invoke(_self583, "rnOpt", r_590, ci_591, rot_592, st_593, txt_594));
} catch (System.Exception _ex597) {
V e_598 = default;
e_598 = Caught(_ex597);
Invoke(G("console"), "warn", ((V)("reno")), Get(r_590, "id"), e_598);
}
SetK(Get(_self583, "rnDone"), Get(r_590, "id"), ((V)(1D)));
return D_595;
return default;
}, 5, "rnDraw", false)).Put("rnOpt", Fn((V _self599, int _argc600, V r_606, V ci_607, V rot_608, V st_609, V[] _rest601) => {
V txt_610 = default;
txt_610 = (_argc600 > 4 ? _rest601[0] : V.Undef);
return NewObj(5).Put("ci", ((V)(0D))).Put("st", (!st_609.IsNullish ? st_609 : (Truthy(Get(r_606, "modes")) ? GetIdx(Get(r_606, "modes"), 0D) : ((V)(""))))).Put("txt", (txt_610 is var _t611 && Truthy(_t611) ? _t611 : ((V)("")))).Put("ex", ((V)(""))).Put("rot", (rot_608.IsNullish ? V.Null : rot_608)).V;
return default;
}, 5, "rnOpt", false)).Put("rnLayer", Fn((V _self612, int _argc613, V r_619, V D_620, V _a617, V _a618, V[] _rest614) => {
if (Truthy((Invoke(CEILS_13, "test", Get(r_619, "slotName")) is var _t621 && Truthy(_t621) ? _t621 : (SEqS(Get(D_620, "mount"), "ceil") ? V.True : V.False)))) {
return ((V)("ceil"));
}
if ((SEqS(Get(D_620, "mount"), "wall") || (SEqS(Call(catOf_14, V.Undef, r_619), "Walls") && !(Truthy(Invoke(NewRegExp(RX12, "Storage", ""), "test", Get(r_619, "slotName"))))))) {
return ((V)("wall"));
}
return ((V)("floor"));
return default;
}, 2, "rnLayer", false)).Put("tightBB", Fn((V _self622, int _argc623, V Dr_629, V f_630, V _a627, V _a628, V[] _rest624) => {
V C_631 = default;
V g_632 = default;
if ((!(Truthy(Dr_629)) || !(Truthy(Get(Dr_629, "svg"))))) {
return V.Null;
}
C_631 = (Get(_self622, "_tbb") is var _t633 && Truthy(_t633) ? _t633 : Set(_self622, "_tbb", New(G("Map"))));
g_632 = Invoke(C_631, "get", Get(Dr_629, "svg"));
if (SEq(g_632, V.Undef)) {
g_632 = V.Null;
try {
V d_634 = default;
V s_635 = default;
V b_636 = default;
d_634 = Invoke(G("document"), "createElement", ((V)("div")));
Set(Get(d_634, "style"), "cssText", ((V)("position:fixed;left:-9999px;top:0;visibility:hidden")));
Set(d_634, "innerHTML", Get(Dr_629, "svg"));
Invoke(Get(G("document"), "body"), "appendChild", d_634);
s_635 = Invoke(d_634, "querySelector", ((V)("svg")));
b_636 = (s_635 is var _t637 && !Truthy(_t637) ? _t637 : Invoke(s_635, "getBBox"));
Invoke(d_634, "remove");
if (Truthy(((b_636 is var _t638 && !Truthy(_t638) ? _t638 : (GtN(Get(b_636, "width"), 1D) ? V.True : V.False)) is var _t639 && !Truthy(_t639) ? _t639 : (GtN(Get(b_636, "height"), 1D) ? V.True : V.False)))) {
g_632 = Arr(Get(b_636, "x"), Get(b_636, "y"), Get(b_636, "width"), Get(b_636, "height"));
}
} catch (System.Exception _ex640) {
V e_641 = default;
e_641 = Caught(_ex640);

}
if (GtN(Get(C_631, "size"), 300D)) {
Invoke(C_631, "clear");
}
Invoke(C_631, "set", Get(Dr_629, "svg"), g_632);
}
return (g_632 is var _t642 && !Truthy(_t642) ? _t642 : Arr(((V)((ToNum(GetIdx(g_632, 0D)) * ToNum(f_630)))), ((V)((ToNum(GetIdx(g_632, 1D)) * ToNum(f_630)))), ((V)((ToNum(GetIdx(g_632, 2D)) * ToNum(f_630)))), ((V)((ToNum(GetIdx(g_632, 3D)) * ToNum(f_630))))));
return default;
}, 2, "tightBB", false)).Put("rnTex", Fn((V _self643, int _argc644, V id_650, V slot_651, V _a648, V _a649, V[] _rest645) => {
V r_652 = default;
V key_653 = default;
V D_654 = default;
V s_655 = default;
V lastP_656 = default;
r_652 = Invoke(Get(_self643, "byId"), "get", id_650);
if (!(Truthy(r_652))) {
return ((V)(""));
}
key_653 = ((V)(JsStrBuf.Begin().V(id_650).S("|").V(slot_651).End()));
Set(_self643, "texC", (Get(_self643, "texC") is var _t657 && Truthy(_t657) ? _t657 : NewObj(0).V));
if ((SEqS(slot_651, "wallS") || SEqS(slot_651, "board"))) {
V D0_658 = default;
if (HasProperty(Get(_self643, "texC"), key_653)) {
return GetK(Get(_self643, "texC"), key_653);
}
D0_658 = Invoke(_self643, "rnDraw", r_652, ((V)(0D)));
return SetK(Get(_self643, "texC"), key_653, (!(Truthy(D0_658)) ? ((V)("")) : (SEqS(slot_651, "board") ? (Get(D0_658, "board") is var _t659 && Truthy(_t659) ? _t659 : ((V)(""))) : ((V)((Truthy(Get(D0_658, "side")) ? JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Invoke(Get(D0_658, "side"), "replace", ((V)("<svg ")), ((V)("<svg preserveAspectRatio=\"none\" "))))).End() : ""))))));
}
if (Truthy(GetK(Get(_self643, "texC"), key_653))) {
return GetK(Get(_self643, "texC"), key_653);
}
D_654 = Invoke(_self643, "rnDraw", r_652, ((V)(0D)));
if ((!(Truthy(D_654)) || !(Truthy(Get(D_654, "svg"))))) {
return ((V)(""));
}
if ((SEqS(slot_651, "fenceR") && !(Truthy(Get(D_654, "svgR"))))) {
return ((V)(""));
}
s_655 = Invoke((SEqS(slot_651, "fenceR") ? Get(D_654, "svgR") : Get(D_654, "svg")), "replace", ((V)("<svg ")), ((V)("<svg preserveAspectRatio=\"none\" ")));
lastP_656 = Fn((V _arrowThis667, int _argc660, V q_666, V _a663, V _a664, V _a665, V[] _rest661) => {
return Invoke(q_666, "replace", NewRegExp(RX13, "<path [^>]*\\/>(?=<\\/svg>$)", ""), ((V)("")));
}, 1, "", true);
if (Truthy(((SEqS(slot_651, "ceil") ? V.True : V.False) is var _t668 && !Truthy(_t668) ? _t668 : Get(D_654, "ceilRoom")))) {
return SetK(Get(_self643, "texC"), key_653, ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Invoke(Get(D_654, "ceilRoom"), "replace", ((V)("<svg ")), ((V)("<svg preserveAspectRatio=\"none\" "))))).End())));
}
if (SEqS(slot_651, "ceil")) {
s_655 = Invoke(Invoke(s_655, "replace", ((V)("viewBox=\"0 0 80 56\"")), ((V)("viewBox=\"0 0 80 26\""))), "replace", NewRegExp(RX14, "<\\/defs>((?:<path [^>]*\\/>){3})", ""), ((V)("</defs>")));
s_655 = Call(lastP_656, V.Undef, Call(lastP_656, V.Undef, s_655));
} else {
s_655 = Call(lastP_656, V.Undef, s_655);
if (SEqS(slot_651, "wall")) {
V m_669 = default;
m_669 = Invoke(s_655, "match", NewRegExp(RX15, "<\\/defs><path d=\"[^\"]*\" fill=\"([^\"]*)\"", ""));
if (Truthy(m_669)) {
s_655 = Invoke(s_655, "replace", ((V)("</defs>")), ((V)(JsStrBuf.Begin().S("</defs><rect x=\"-1\" y=\"-1\" width=\"82\" height=\"58\" fill=\"").V(GetIdx(m_669, 1D)).S("\"/>").End())));
}
}
}
return SetK(Get(_self643, "texC"), key_653, ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, s_655)).End())));
return default;
}, 2, "rnTex", false)).V;
geo0_22 = V.Null;
r1_24 = Fn((V _arrowThis677, int _argc670, V v_676, V _a673, V _a674, V _a675, V[] _rest671) => {
return ((V)((Round((ToNum(v_676) * 10D)) / 10D)));
}, 1, "", true);
IC_25 = NewObj(30).Put("sauna", ((V)("M4 20h16 M6 20v-6h12v6 M8 11c0-1.5 1-1.5 1-3s-1-1.5-1-3 M12 11c0-1.5 1-1.5 1-3s-1-1.5-1-3 M16 11c0-1.5 1-1.5 1-3s-1-1.5-1-3"))).Put("shower", ((V)("M4 21V7a4 4 0 0 1 4-4h2a4 4 0 0 1 4 4 M10 7h8l-1 3h-6z M12 13v2 M15 13.5v2 M18 13v2 M13.5 17.5v2 M16.5 17.5v2"))).Put("watch", ((V)("M3 6h18v11H3z M8 21h8 M12 17v4"))).Put("snuggle", ((V)("M12 20s-7.5-4.6-7.5-10.2A4.2 4.2 0 0 1 12 7.2a4.2 4.2 0 0 1 7.5 2.6C19.5 15.4 12 20 12 20z"))).Put("feed", ((V)("M4 12h16a8 8 0 0 1-16 0z M9 8c0-1.5 1-1.5 1-3 M14 8c0-1.5 1-1.5 1-3"))).Put("nap", ((V)("M20 14.5A8 8 0 1 1 9.5 4a6.5 6.5 0 0 0 10.5 10.5z"))).Put("sit", ((V)("M5 11V9a3 3 0 0 1 3-3h8a3 3 0 0 1 3 3v2 M3 11h18v6H3z M5 17v2 M19 17v2"))).Put("dance", ((V)("M9 18V6l10-2v12 M9 18a2.5 2.5 0 1 1-5 0a2.5 2.5 0 0 1 5 0z M19 16a2.5 2.5 0 1 1-5 0a2.5 2.5 0 0 1 5 0z"))).Put("snack", ((V)("M12 3a9 9 0 1 0 9 9 3 3 0 0 1-3-3 3 3 0 0 1-3-3 3 3 0 0 1-3-3z M8.5 11h.01 M12 15.5h.01 M15.5 13h.01"))).Put("cook", ((V)("M4 10h16v4a6 6 0 0 1-6 6h-4a6 6 0 0 1-6-6z M2 10h20 M9 6.5c0-1 1-1 1-2.5 M14 6.5c0-1 1-1 1-2.5"))).Put("bath", ((V)("M3 12h18v2a6 6 0 0 1-6 6H9a6 6 0 0 1-6-6z M6 12V6.5a2.5 2.5 0 0 1 5 0 M7 20l-1 2 M17 20l1 2"))).Put("wash", ((V)("M12 3s6 7 6 11a6 6 0 0 1-12 0c0-4 6-11 6-11z"))).Put("lights", ((V)("M9 18h6 M10 21h4 M12 3a6 6 0 0 0-4 10.5c.7.7 1 1.5 1 2.5h6c0-1 .3-1.8 1-2.5A6 6 0 0 0 12 3z"))).Put("ride", ((V)("M3 19c5 3 13 3 18 0 M8 16v-5l3-5 2 2h3l2 3-2 1.5V16"))).Put("play", ((V)("M4 13h7v7H4z M13 13h7v7h-7z M8.5 4h7v7h-7z"))).Put("perform", ((V)("M12 3a3 3 0 0 1 3 3v5a3 3 0 0 1-6 0V6a3 3 0 0 1 3-3z M6 11a6 6 0 0 0 12 0 M12 17v4"))).Put("party", ((V)("M12 3l2.2 5.6L20 9.5l-4.6 3.8L17 19.5 12 16.2 7 19.5l1.6-6.2L4 9.5l5.8-.9z"))).Put("swing", ((V)("M4 3h16 M6 3v15 M18 3v15 M9.5 3v11 M14.5 3v11 M8.5 14h7"))).Put("splash", ((V)("M3 15c2-2 4-2 6 0s4 2 6 0 4-2 6 0 M3 20c2-2 4-2 6 0s4 2 6 0 4-2 6 0 M12 3v7 M9 7.5l3 3 3-3"))).Put("dig", ((V)("M15 3l6 6 M18 6l-7 7 M11 13l-2-2-5 5a2.8 2.8 0 0 0 4 4l5-5z"))).Put("bounce", ((V)("M4 18h16 M6 18l2-4 M18 18l-2-4 M12 12a3 3 0 1 0 0-6 3 3 0 0 0 0 6z M12 3v1"))).Put("slide", ((V)("M4 20V6 M4 8h4 M8 8l12 12 M4 13h3"))).Put("swim", ((V)("M2 18c2-1.5 4-1.5 6 0s4 1.5 6 0 4-1.5 6 0 M2 13.5c2-1.5 4-1.5 6 0s4 1.5 6 0 4-1.5 6 0 M14 6a2.5 2.5 0 1 0 .01 0z"))).Put("fish", ((V)("M3 12c3-4.5 9-5.5 13-1-4 4.5-10 3.5-13 1z M16 11l5-3.5v9L16 13 M7.5 11h.01"))).Put("shell", ((V)("M12 20c-5 0-8-3-8-7 0-5 4-9 8-9s8 4 8 9c0 4-3 7-8 7z M12 20V7 M8 19l1-11 M16 19l-1-11"))).Put("sun", ((V)("M12 8a4 4 0 1 0 .01 0z M12 2v2 M12 20v2 M2 12h2 M20 12h2 M5 5l1.4 1.4 M17.6 17.6L19 19 M5 19l1.4-1.4 M17.6 6.4L19 5"))).Put("roast", ((V)("M4 20l9-9 M13.5 5.5a3 3 0 1 1 4.2 4.2 3 3 0 0 1-4.2-4.2z M6 22c-2-2-1-5 1-6 0 2 2 2 2 4"))).Put("build", ((V)("M3 20h18 M5 20v-8h5v8 M14 20v-6h5v6 M5 12l2.5-3 2.5 3 M7.5 9V4l3 1.2-3 1.2"))).Put("surf", ((V)("M4 20C9 6 15 3 20 4c1 5-1 11-16 16z M8 16l8-8"))).Put("treat", ((V)("M8 11a4 4 0 1 1 8 0 M7 11h10l-5 10z M12 7V4"))).V;
NEED_26 = NewObj(4).Put("h", NewObj(3).Put("ic", Get(IC_25, "feed")).Put("col", ((V)("#f28a1e"))).Put("low", ((V)("Hungry..."))).V).Put("c", NewObj(3).Put("ic", Get(IC_25, "wash")).Put("col", ((V)("#2ea3dc"))).Put("low", ((V)("Itchy..."))).V).Put("e", NewObj(3).Put("ic", Get(IC_25, "nap")).Put("col", ((V)("#5470e6"))).Put("low", ((V)("Sleepy..."))).V).Put("f", NewObj(3).Put("ic", Get(IC_25, "party")).Put("col", ((V)("#a24ef0"))).Put("low", ((V)("Bored..."))).V).V;
FIX_27 = NewObj(7).Put("kitchen", ((V)("h"))).Put("bathroom", ((V)("c"))).Put("bedroom", ((V)("e"))).Put("dance", ((V)("f"))).Put("backyard", ((V)("f"))).Put("movie", ((V)("f"))).Put("beach", ((V)("f"))).V;
RLAB_28 = NewObj(9).Put("living", ((V)("Living Room"))).Put("kitchen", ((V)("Kitchen"))).Put("bathroom", ((V)("Bathroom"))).Put("bedroom", ((V)("Bedroom"))).Put("backyard", ((V)("Backyard"))).Put("dance", ((V)("Dance Room"))).Put("movie", ((V)("Movie Room"))).Put("beach", ((V)("Beach"))).Put("style", ((V)("Walls & Floors"))).V;
RDOT_29 = NewObj(9).Put("living", ((V)("#e3946a"))).Put("kitchen", ((V)("#f2c255"))).Put("bathroom", ((V)("#5cc8f0"))).Put("bedroom", ((V)("#8fa7c9"))).Put("backyard", ((V)("#7fbd5e"))).Put("dance", ((V)("#8f7bff"))).Put("movie", ((V)("#c46a3e"))).Put("beach", ((V)("#e8b860"))).Put("style", ((V)("#c9a85a"))).V;
FISHB_30 = ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, ((V)("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"-14 -14 28 28\"><g><animateTransform attributeName=\"transform\" type=\"translate\" values=\"0 0;0 -2;0 0\" dur=\"1.6s\" repeatCount=\"indefinite\"/><circle r=\"11.5\" fill=\"#ffffff\" stroke=\"#45189a\" stroke-width=\"2\"/><path d=\"M-7 0c2.4-3.6 7-4.4 10-0.8-3 3.6-7.6 2.8-10 0.8z M3 -0.8l4-2.8v6.4l-4-2.6\" fill=\"#3fb0e0\" stroke=\"#1d4a9a\" stroke-width=\"1\" stroke-linejoin=\"round\"/><circle cx=\"-3.6\" cy=\"-1\" r=\"0.9\" fill=\"#1d4a9a\"/></g></svg>")))).End()));
BOARDH_31 = ((V)("<svg width=\"120\" height=\"120\" viewBox=\"0 0 120 120\" style=\"overflow:visible\"><ellipse cx=\"60\" cy=\"112\" rx=\"50\" ry=\"8\" fill=\"#0e4a6a\" opacity=\"0.25\"/><path d=\"M10 106Q58 90 112 103Q64 118 10 106Z\" fill=\"#ffe066\" stroke=\"#8a5d00\" stroke-width=\"1.8\" stroke-linejoin=\"round\"/><path d=\"M22 105Q60 97 100 103\" stroke=\"#e2554a\" stroke-width=\"2.6\" fill=\"none\"/><path d=\"M4 108q-6-4-2-9M8 112q-8 0-10-5\" stroke=\"#ffffff\" stroke-width=\"2\" fill=\"none\" stroke-linecap=\"round\" opacity=\"0.9\"/></svg>"));
RODH_32 = ((V)("<svg width=\"120\" height=\"120\" viewBox=\"0 0 120 120\" style=\"overflow:visible\"><path d=\"M66 78L118 18\" stroke=\"#6a4a2a\" stroke-width=\"3\" stroke-linecap=\"round\"/><path d=\"M118 18Q128 60 126 98\" stroke=\"#ffffff\" stroke-width=\"1\" fill=\"none\"/><g><animateTransform attributeName=\"transform\" type=\"translate\" values=\"0 0;0 2.5;0 0\" dur=\"1.4s\" repeatCount=\"indefinite\"/><circle cx=\"126\" cy=\"99\" r=\"3.4\" fill=\"#e2554a\" stroke=\"#ffffff\" stroke-width=\"1.2\"/></g><ellipse cx=\"126\" cy=\"103\" rx=\"7\" ry=\"2\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1.2\" opacity=\"0.8\"/></svg>"));
MAPB_33 = NewObj(8).Put("bedroom", NewObj(4).Put("sil", ((V)("M182 152 L204 102 H304 L326 152 H318 V206 H190 V152 Z"))).Put("lk", Arr(((V)(190D)), ((V)(150D)), ((V)(128D)), ((V)(56D)))).Put("lab", Arr(((V)(254D)), ((V)(128D)))).Put("c", Arr(((V)(254D)), ((V)(170D)))).V).Put("kitchen", NewObj(4).Put("sil", ((V)("M188 206 H320 V275 H188 Z"))).Put("lk", Arr(((V)(190D)), ((V)(208D)), ((V)(128D)), ((V)(66D)))).Put("lab", Arr(((V)(240D)), ((V)(292D)))).Put("c", Arr(((V)(254D)), ((V)(240D)))).V).Put("living", NewObj(4).Put("sil", ((V)("M310 190 L334 150 H454 L478 190 H470 V275 H318 V190 Z"))).Put("lk", Arr(((V)(318D)), ((V)(190D)), ((V)(152D)), ((V)(84D)))).Put("lab", Arr(((V)(394D)), ((V)(302D)))).Put("c", Arr(((V)(394D)), ((V)(230D)))).V).Put("dance", NewObj(4).Put("sil", ((V)("M340 152 V126 A54 44 0 0 1 448 126 V152 Z"))).Put("lk", Arr(((V)(342D)), ((V)(92D)), ((V)(104D)), ((V)(58D)))).Put("lab", Arr(((V)(394D)), ((V)(64D)))).Put("c", Arr(((V)(394D)), ((V)(118D)))).V).Put("bathroom", NewObj(4).Put("sil", ((V)("M462 159 L482 129 H566 L586 159 H578 V216 H470 V159 Z"))).Put("lk", Arr(((V)(470D)), ((V)(159D)), ((V)(108D)), ((V)(56D)))).Put("lab", Arr(((V)(524D)), ((V)(144D)))).Put("c", Arr(((V)(524D)), ((V)(177D)))).V).Put("backyard", NewObj(4).Put("sil", ((V)("M600 198 H732 V301 H600 Z"))).Put("lk", Arr(((V)(606D)), ((V)(206D)), ((V)(120D)), ((V)(90D)))).Put("lab", Arr(((V)(666D)), ((V)(328D)))).Put("c", Arr(((V)(666D)), ((V)(250D)))).V).Put("movie", NewObj(4).Put("sil", ((V)("M470 275 V215 H578 V275 Z"))).Put("lk", Arr(((V)(472D)), ((V)(223D)), ((V)(104D)), ((V)(48D)))).Put("lab", Arr(((V)(524D)), ((V)(282D)))).Put("c", Arr(((V)(524D)), ((V)(250D)))).V).Put("beach", NewObj(4).Put("sil", ((V)("M590 66 C618 72 616 140 650 170 C684 200 784 190 782 228 L796 226 C806 150 756 82 640 64 C622 62 604 62 590 66 Z"))).Put("lk", Arr(((V)(654D)), ((V)(108D)), ((V)(100D)), ((V)(70D)))).Put("lab", Arr(((V)(716D)), ((V)(52D)))).Put("c", Arr(((V)(714D)), ((V)(140D)))).V).V;
SEASON_34 = NewObj(3).Put("sunny", NewObj(6).Put("grass", Arr(((V)("#a2a68c")), ((V)("#7fd35a")))).Put("sand", Arr(((V)("#d6cfb6")), ((V)("#ffe39e")))).Put("sea0", Arr(((V)("#b7c9cf")), ((V)("#a2f0ff")))).Put("sea1", Arr(((V)("#7e9aa8")), ((V)("#2fb4e8")))).Put("tr0", Arr(((V)("#b2bb98")), ((V)("#b4f27c")))).Put("tr1", Arr(((V)("#6f8262")), ((V)("#3f9c32")))).V).Put("rainy", NewObj(6).Put("grass", Arr(((V)("#8d977e")), ((V)("#62b04f")))).Put("sand", Arr(((V)("#bdb6a0")), ((V)("#ddcb94")))).Put("sea0", Arr(((V)("#8fa3ab")), ((V)("#86c8da")))).Put("sea1", Arr(((V)("#5d7684")), ((V)("#2f82a8")))).Put("tr0", Arr(((V)("#97a283")), ((V)("#8cc96e")))).Put("tr1", Arr(((V)("#56684c")), ((V)("#2f7a32")))).V).Put("snowy", NewObj(6).Put("grass", Arr(((V)("#d6dade")), ((V)("#f4f9fd")))).Put("sand", Arr(((V)("#d2d0c8")), ((V)("#eef0ee")))).Put("sea0", Arr(((V)("#b4c4cc")), ((V)("#c4ecf8")))).Put("sea1", Arr(((V)("#7d94a2")), ((V)("#4fa6d0")))).Put("tr0", Arr(((V)("#dfe4e6")), ((V)("#ffffff")))).Put("tr1", Arr(((V)("#7f9488")), ((V)("#4f8a6a")))).V).V;
MAPGRASS_35 = ((V)("M88 248 C82 176 146 84 266 68 C384 54 518 58 590 68 C618 72 616 140 650 170 C684 200 784 190 782 228 C772 298 708 356 558 364 C420 372 266 370 170 346 C114 332 92 294 88 248 Z"));
MAPROAD_36 = ((V)("M378 280 C374 310 358 336 345 366 L343 384 L407 384 L405 366 C401 340 415 312 413 280 Z M574 262 C590 260 596 264 604 266 L602 292 C590 288 584 286 574 284 Z"));
MAPDEAD_37 = NewObj(6).Put("grass", ((V)("#6c6746"))).Put("sand", ((V)("#c4b896"))).Put("sea0", ((V)("#9fb0b2"))).Put("sea1", ((V)("#5f7682"))).Put("tr0", ((V)("#8f7f58"))).Put("tr1", ((V)("#4f4230"))).V;
MTB_38 = Arr(Arr(((V)(124D)), ((V)(182D)), ((V)(1.1))), Arr(((V)(566D)), ((V)(128D)), ((V)(1D))));
MTF_39 = Arr(Arr(((V)(118D)), ((V)(252D)), ((V)(0.65))), Arr(((V)(160D)), ((V)(300D)), ((V)(0.9))), Arr(((V)(232D)), ((V)(336D)), ((V)(0.75))), Arr(((V)(500D)), ((V)(338D)), ((V)(0.75))));
MBU_40 = Arr(Arr(((V)(196D)), ((V)(276D)), ((V)(12D)), ((V)(7D))), Arr(((V)(314D)), ((V)(278D)), ((V)(10D)), ((V)(6D))), Arr(((V)(474D)), ((V)(278D)), ((V)(10D)), ((V)(6D))), Arr(((V)(574D)), ((V)(276D)), ((V)(11D)), ((V)(7D))));
natSS_41 = Fn((V _arrowThis687, int _argc678, V a_684, V b_685, V x_686, V _a683, V[] _rest679) => {
double t_688 = 0;
t_688 = Max(0D, Min(1D, ((ToNum(x_686) - ToNum(a_684)) / (ToNum(b_685) - ToNum(a_684)))));
return ((V)(((t_688 * t_688) * (3D - (2D * t_688)))));
return default;
}, 3, "", true);
n1_42 = Fn((V _arrowThis696, int _argc689, V x_695, V _a692, V _a693, V _a694, V[] _rest690) => {
return Invoke(((V)((Round((ToNum(x_695) * 10D)) / 10D))), "toString");
}, 1, "", true);
natE_44 = Fn((V _arrowThis708, int _argc697, V x_703, V y_704, V rx_705, V ry_706, V[] _rest698) => {
double c_709 = 0;
double s2_710 = 0;
V a_707 = default;
a_707 = (_argc697 > 4 ? _rest698[0] : V.Undef);
c_709 = FdLibm.Cos(ToNum(a_707));
s2_710 = FdLibm.Sin(ToNum(a_707));
return ((V)(JsStrBuf.Begin().S("M").V(Call(n1_42, V.Undef, ((V)((ToNum(x_703) - (ToNum(rx_705) * c_709)))))).S(" ").V(Call(n1_42, V.Undef, ((V)((ToNum(y_704) - (ToNum(rx_705) * s2_710)))))).S("a").V(Call(n1_42, V.Undef, rx_705)).S(" ").V(Call(n1_42, V.Undef, ry_706)).S(" ").N(Round((ToNum(a_707) * 57.3))).S(" 1 0 ").V(Call(n1_42, V.Undef, ((V)(((2D * ToNum(rx_705)) * c_709))))).S(" ").V(Call(n1_42, V.Undef, ((V)(((2D * ToNum(rx_705)) * s2_710))))).S("a").V(Call(n1_42, V.Undef, rx_705)).S(" ").V(Call(n1_42, V.Undef, ry_706)).S(" ").N(Round((ToNum(a_707) * 57.3))).S(" 1 0 ").V(Call(n1_42, V.Undef, ((V)((((-2D) * ToNum(rx_705)) * c_709))))).S(" ").V(Call(n1_42, V.Undef, ((V)((((-2D) * ToNum(rx_705)) * s2_710))))).S("Z").End()));
return default;
}, 5, "", true);
WIC_48 = NewObj(3).Put("sunny", Arr(((V)("Sunny")), ((V)("#e8a21c")), ((V)("M12 8a4 4 0 1 0 0.01 0Z M12 2.5v2 M12 19.5v2 M2.5 12h2 M19.5 12h2 M5.3 5.3l1.4 1.4 M17.3 17.3l1.4 1.4 M5.3 18.7l1.4-1.4 M17.3 6.7l1.4-1.4")))).Put("rainy", Arr(((V)("Rainy")), ((V)("#3f7fc8")), ((V)("M7 15a4 4 0 0 1 .6-8A5 5 0 0 1 17 8a3.5 3.5 0 0 1 0 7Z M8.5 18l-1 3 M12.5 18l-1 3 M16.5 18l-1 3")))).Put("snowy", Arr(((V)("Snowy")), ((V)("#4fa6d0")), ((V)("M12 3v18 M4.2 7.5l15.6 9 M4.2 16.5l15.6-9 M9.5 4.5 12 7l2.5-2.5 M9.5 19.5 12 17l2.5 2.5")))).V;
rnd_49 = Fn((V _arrowThis719, int _argc711, V i_717, V k_718, V _a715, V _a716, V[] _rest712) => {
double x_720 = 0;
x_720 = (FdLibm.Sin(((ToNum(i_717) * 127.1) + (ToNum(k_718) * 311.7))) * 43758.5453);
return ((V)((x_720 - System.Math.Floor(x_720))));
return default;
}, 2, "", true);
RAIN_50 = Array_from(NewObj(1).Put("length", ((V)(70D))).V, Fn((V _arrowThis729, int _argc721, V __727, V i_728, V _a725, V _a726, V[] _rest722) => {
double x_730 = 0;
double d_731 = 0;
x_730 = Round((ToNum(Call(rnd_49, V.Undef, i_728, ((V)(1D)))) * 900D));
d_731 = (0.55 + (ToNum(Call(rnd_49, V.Undef, i_728, ((V)(2D)))) * 0.35));
return NewObj(4).Put("id", ((V)(JsStrBuf.Begin().S("r").V(i_728).End()))).Put("v", ((V)(JsStrBuf.Begin().N(x_730).S(" -20;").N((x_730 - 28D)).S(" 405").End()))).Put("d", ((V)(JsStrBuf.Begin().V(Invoke(((V)(d_731)), "toFixed", ((V)(2D)))).S("s").End()))).Put("b", ((V)(JsStrBuf.Begin().V(Invoke(((V)(((-ToNum(Call(rnd_49, V.Undef, i_728, ((V)(3D))))) * d_731))), "toFixed", ((V)(2D)))).S("s").End()))).V;
return default;
}, 2, "", true));
SNOW_51 = Array_from(NewObj(1).Put("length", ((V)(60D))).V, Fn((V _arrowThis740, int _argc732, V __738, V i_739, V _a736, V _a737, V[] _rest733) => {
double x_741 = 0;
double w_742 = 0;
double d_743 = 0;
x_741 = Round(((ToNum(Call(rnd_49, V.Undef, i_739, ((V)(4D)))) * 870D) - 10D));
w_742 = (8D + (ToNum(Call(rnd_49, V.Undef, i_739, ((V)(5D)))) * 14D));
d_743 = (6D + (ToNum(Call(rnd_49, V.Undef, i_739, ((V)(6D)))) * 6D));
return NewObj(5).Put("id", ((V)(JsStrBuf.Begin().S("s").V(i_739).End()))).Put("r", Invoke(((V)((1.2 + (ToNum(Call(rnd_49, V.Undef, i_739, ((V)(7D)))) * 1.9)))), "toFixed", ((V)(1D)))).Put("v", ((V)(JsStrBuf.Begin().N(x_741).S(" -10;").V(Call(r1_24, V.Undef, ((V)((x_741 + w_742))))).S(" 130;").V(Call(r1_24, V.Undef, ((V)((x_741 - w_742))))).S(" 270;").V(Call(r1_24, V.Undef, ((V)((x_741 + (w_742 * 0.5)))))).S(" 405").End()))).Put("d", ((V)(JsStrBuf.Begin().V(Invoke(((V)(d_743)), "toFixed", ((V)(1D)))).S("s").End()))).Put("b", ((V)(JsStrBuf.Begin().V(Invoke(((V)(((-ToNum(Call(rnd_49, V.Undef, i_739, ((V)(8D))))) * d_743))), "toFixed", ((V)(1D)))).S("s").End()))).V;
return default;
}, 2, "", true));
SPK_52 = Arr(Arr(((V)(44D)), ((V)(110D))), Arr(((V)(150D)), ((V)(150D))), Arr(((V)(560D)), ((V)(92D))), Arr(((V)(812D)), ((V)(238D))), Arr(((V)(290D)), ((V)(330D))), Arr(((V)(120D)), ((V)(340D))), Arr(((V)(740D)), ((V)(92D))), Arr(((V)(480D)), ((V)(30D))), Arr(((V)(620D)), ((V)(330D))), Arr(((V)(30D)), ((V)(330D))), Arr(((V)(130D)), ((V)(230D))), Arr(((V)(790D)), ((V)(330D))), Arr(((V)(250D)), ((V)(34D))), Arr(((V)(574D)), ((V)(300D))), Arr(((V)(660D)), ((V)(372D))), Arr(((V)(96D)), ((V)(60D))));
mp_53 = NewObj(3).Put("mapVals", Fn((V _self744, int _argc745, V GS_751, V _a748, V _a749, V _a750, V[] _rest746) => {
V X_752 = default;
V L_753 = default;
V cur_754 = default;
double tier_755 = 0;
V mx_756 = default;
V nAll_757 = default;
V nOpen_758 = default;
double f0_759 = 0;
double vit_760 = 0;
double f_761 = 0;
V sea_762 = default;
V SP_763 = default;
V dk_764 = default;
V mm_765 = default;
V W_766 = default;
V S_767 = default;
V going_768 = default;
V ml_769 = default;
V tiles_770 = default;
V gB_771 = default;
X_752 = Get(_self744, "X");
L_753 = Invoke(_self744, "lvl");
cur_754 = Get(Get(_self744, "state"), "cur");
tier_755 = (LtN(L_753, 5D) ? 0D : (LtN(L_753, 15D) ? 1D : (LtN(L_753, 25D) ? 2D : 3D)));
mx_756 = NewObj(17).Put("shabby", ((tier_755 == 0D) ? V.True : V.False)).Put("smoke", ((tier_755 >= 1D) ? V.True : V.False)).Put("fancy", ((tier_755 >= 3D) ? V.True : V.False)).Put("chimT", ((V)(((tier_755 == 0D) ? "rotate(-7 493 66)" : "rotate(0)")))).Put("sky0", ((V)(((tier_755 == 0D) ? "#b9cfdc" : "#9fd6f4")))).Put("sky1", ((V)(((tier_755 == 0D) ? "#e4ecef" : "#e8f6fc")))).Put("sunOp", ((V)(((tier_755 == 0D) ? 0.4 : 1D)))).Put("cloud", ((V)(((tier_755 == 0D) ? "#e6eaec" : "#ffffff")))).Put("hill", ((V)(((tier_755 == 0D) ? "#bcc79a" : "#b6d99a")))).Put("grass", ((V)(((tier_755 == 0D) ? "#a9b67e" : "#9fcf7a")))).Put("roof0", ((V)(((tier_755 == 0D) ? "#b88a6e" : ((tier_755 >= 3D) ? "#9a2a3a" : "#e3946a"))))).Put("roof1", ((V)(((tier_755 == 0D) ? "#8a6248" : ((tier_755 >= 3D) ? "#6a1a28" : "#c4651f"))))).Put("wall0", ((V)(((tier_755 == 0D) ? "#e0d4bc" : "#fbf1e2")))).Put("wall1", ((V)(((tier_755 == 0D) ? "#c4b496" : "#e8d4b4")))).Put("shingle", ((V)(((tier_755 == 0D) ? "#6a4a36" : ((tier_755 >= 3D) ? "#3f5bb8" : "#b25a38"))))).Put("eave", ((V)(((tier_755 == 0D) ? "#d9cdb5" : ((tier_755 >= 3D) ? "#ffd66b" : "#fffaf1"))))).Put("label", GetIdx(Arr(((V)("Run-down house")), ((V)("Cozy home")), ((V)("Lovely home")), ((V)("Royal palace"))), tier_755)).V;
nAll_757 = Get(Get(X_752, "RKEYS"), "length");
nOpen_758 = Get(Invoke(Get(X_752, "RKEYS"), "filter", Fn((V _arrowThis779, int _argc772, V rk_778, V _a775, V _a776, V _a777, V[] _rest773) => {
return Invoke(_self744, "isOpen", rk_778);
}, 1, "", true)), "length");
f0_759 = Max(0D, Min(1D, ((ToNum(nOpen_758) - 1D) / Max(1D, (ToNum(nAll_757) - 1D)))));
vit_760 = Max(0D, Min(1D, ((ToNum(L_753) - 1D) / 29D)));
f_761 = Min(f0_759, vit_760);
sea_762 = Invoke(_self744, "seasonNow");
SP_763 = GetK(SEASON_34, sea_762);
dk_764 = Fn((V _arrowThis787, int _argc780, V k_786, V _a783, V _a784, V _a785, V[] _rest781) => {
return (SEqS(sea_762, "snowy") ? GetIdx(GetK(SP_763, k_786), 0D) : (SEqS(sea_762, "rainy") ? Invoke(Get(X_752, "K"), "mix", GetK(MAPDEAD_37, k_786), ((V)("#3a3c40")), ((V)(0.12))) : GetK(MAPDEAD_37, k_786)));
}, 1, "", true);
mm_765 = Fn((V _arrowThis795, int _argc788, V k_794, V _a791, V _a792, V _a793, V[] _rest789) => {
return Invoke(Get(X_752, "K"), "mix", (Truthy(GetK(MAPDEAD_37, k_794)) ? Call(dk_764, V.Undef, k_794) : GetIdx(GetK(SP_763, k_794), 0D)), GetIdx(GetK(SP_763, k_794), 1D), ((V)(vit_760)));
}, 1, "", true);
W_766 = GetK(WIC_48, sea_762);
Object_assign(mx_756, NewObj(19).Put("grass", Call(mm_765, V.Undef, ((V)("grass")))).Put("sand", Call(mm_765, V.Undef, ((V)("sand")))).Put("sea0", Call(mm_765, V.Undef, ((V)("sea0")))).Put("sea1", Call(mm_765, V.Undef, ((V)("sea1")))).Put("tr0", Call(mm_765, V.Undef, ((V)("tr0")))).Put("tr1", Call(mm_765, V.Undef, ((V)("tr1")))).Put("sunny", (SEqS(sea_762, "sunny") ? V.True : V.False)).Put("rainy", (SEqS(sea_762, "rainy") ? V.True : V.False)).Put("snowy", (SEqS(sea_762, "snowy") ? V.True : V.False)).Put("sunOp", Call(r1_24, V.Undef, ((V)((0.55 + (0.45 * f_761)))))).Put("waveOp", Call(r1_24, V.Undef, ((V)((0.25 + (0.5 * f_761)))))).Put("glint", Call(r1_24, V.Undef, ((V)(((SEqS(sea_762, "sunny") ? 0.5 : (SEqS(sea_762, "snowy") ? 0.3 : 0.08)) * f_761))))).Put("cloud", (SEqS(sea_762, "rainy") ? ((V)("#c3cad1")) : Get(mx_756, "cloud"))).Put("rain", RAIN_50).Put("snow", SNOW_51).Put("wTxt", GetIdx(W_766, 0D)).Put("wCol", GetIdx(W_766, 1D)).Put("wIc", GetIdx(W_766, 2D)).Put("spk", Invoke(Invoke(SPK_52, "slice", ((V)(0D)), ((V)((SEqS(sea_762, "rainy") ? 0D : Round(((ToNum(Get(SPK_52, "length")) * f_761) * (SEqS(sea_762, "sunny") ? 1D : 0.7))))))), "map", Fn((V _arrowThis808, int _argc796, V _a798, V i_802, V _a800, V _a801, V[] _rest797) => {
V x_805 = default;
V y_807 = default;
{ V _t803 = ListOf(_a798);
{ V _t804 = GetIdx(_t803, 0D);
x_805 = _t804; }
{ V _t806 = GetIdx(_t803, 1D);
y_807 = _t806; }
}
return NewObj(4).Put("id", ((V)(JsStrBuf.Begin().S("k").V(i_802).End()))).Put("t", ((V)(JsStrBuf.Begin().S("translate(").V(x_805).S(" ").V(y_807).S(") scale(").V(Invoke(((V)((0.7 + (ToNum(Call(rnd_49, V.Undef, i_802, ((V)(9D)))) * 0.6)))), "toFixed", ((V)(2D)))).S(")").End()))).Put("d", ((V)(JsStrBuf.Begin().V(Invoke(((V)((2.2 + (ToNum(Call(rnd_49, V.Undef, i_802, ((V)(10D)))) * 1.6)))), "toFixed", ((V)(1D)))).S("s").End()))).Put("b", ((V)(JsStrBuf.Begin().V(Invoke(((V)(((-ToNum(Call(rnd_49, V.Undef, i_802, ((V)(11D))))) * 3D))), "toFixed", ((V)(1D)))).S("s").End()))).V;
}, 2, "", true))).V);
Set(mx_756, "seaBg", Invoke(Get(X_752, "K"), "mix", Get(mx_756, "sea0"), Get(mx_756, "sea1"), ((V)(0.6))));
Set(mx_756, "sandD", Invoke(Get(X_752, "K"), "mix", Get(mx_756, "sand"), ((V)("#8a6a3a")), ((V)(0.16))));
Object_assign(mx_756, NewObj(6).Put("grassHi", Invoke(Get(X_752, "K"), "mix", Get(mx_756, "grass"), ((V)("#ffffff")), ((V)((0.12 + (0.25 * f_761)))))).Put("grassD", Invoke(Get(X_752, "K"), "mix", Get(mx_756, "grass"), ((V)((SEqS(sea_762, "snowy") ? "#4a6070" : "#2f4a1a"))), ((V)(0.45)))).Put("yard", Invoke(Get(X_752, "K"), "mix", Get(mx_756, "grass"), ((V)("#ffffff")), ((V)(0.18)))).Put("chim", ((V)(((tier_755 == 0D) ? "rotate(-7 290 114)" : "rotate(0)")))).Put("flowerOp", ((V)(0D))).Put("vit", ((V)(vit_760))).V);
{
V nk_809 = default;
nk_809 = ((V)(JsStrBuf.Begin().S("r4|").V(sea_762).S("|").V(Invoke(((V)(vit_760)), "toFixed", ((V)(3D)))).S("|").V(Get(mx_756, "grass")).V(Get(mx_756, "tr0")).V(Get(mx_756, "tr1")).End()));
if ((!(Truthy(Get(_self744, "_nat"))) || !SEq(Get(Get(_self744, "_nat"), "k"), nk_809))) {
Set(_self744, "_nat", Object_assign(NewObj(1).Put("k", nk_809).V, Call(natMap_47, V.Undef, ((V)(vit_760)), mx_756, Get(Get(X_752, "K"), "mix"))));
}
}
S_767 = Get(_self744, "state");
going_768 = Get(S_767, "mapGo");
ml_769 = NewObj(0).V;
Invoke(Get(X_752, "RKEYS"), "forEach", Fn((V _arrowThis817, int _argc810, V rk_816, V _a813, V _a814, V _a815, V[] _rest811) => {
V open_818 = default;
V sh_819 = default;
V P_820 = default;
V fac_821 = default;
open_818 = Invoke(_self744, "isOpen", rk_816);
sh_819 = (Truthy(open_818) ? Invoke(_self744, "shellOf", rk_816) : V.Null);
P_820 = (sh_819 is var _t822 && !Truthy(_t822) ? _t822 : Get(sh_819, "P"));
fac_821 = Invoke(Get(X_752, "K"), "mix", (GetK(RDOT_29, rk_816) is var _t823 && Truthy(_t823) ? _t823 : ((V)("#e3946a"))), ((V)("#fbf1e2")), ((V)(0.58)));
if ((tier_755 == 0D)) {
fac_821 = Invoke(Get(X_752, "K"), "mix", fac_821, ((V)("#c9bca4")), ((V)(0.45)));
}
SetK(ml_769, rk_816, NewObj(4).Put("fac", (Truthy(open_818) ? fac_821 : ((V)("#b9ad98")))).Put("win", (Truthy(open_818) ? Invoke(Get(X_752, "K"), "mix", (((P_820 is var _t824 && !Truthy(_t824) ? _t824 : Get(P_820, "b0")) is var _t825 && Truthy(_t825) ? _t825 : GetK(RDOT_29, rk_816)) is var _t826 && Truthy(_t826) ? _t826 : ((V)("#e3946a"))), ((V)("#fff1c0")), ((V)(0.4))) : ((V)("#4a3f36")))).Put("lit", ((V)((Truthy(open_818) ? 1D : 0.25)))).Put("on", open_818).V);
return default;
}, 1, "", true));
tiles_770 = Invoke(Invoke(Get(X_752, "RKEYS"), "filter", Fn((V _arrowThis913, int _argc906, V rk_912, V _a909, V _a910, V _a911, V[] _rest907) => {
return GetK(MAPB_33, rk_912);
}, 1, "", true)), "map", Fn((V _arrowThis834, int _argc827, V rk_833, V _a830, V _a831, V _a832, V[] _rest828) => {
V B_835 = default;
V open_836 = default;
V lk_837 = default;
V here_838 = default;
V nk_839 = default;
V n_840 = default;
V hv_841 = default;
V x_842 = default;
V y_843 = default;
V w_844 = default;
V h_845 = default;
V LS_846 = default;
B_835 = GetK(MAPB_33, rk_833);
open_836 = Invoke(_self744, "isOpen", rk_833);
lk_837 = Get(GetK(Get(X_752, "ROOMS"), rk_833), "unlock");
here_838 = Invoke(Get(_self744, "cs"), "filter", Fn((V _arrowThis854, int _argc847, V o_853, V _a850, V _a851, V _a852, V[] _rest848) => {
return (SEq(Get(o_853, "room"), rk_833) ? V.True : V.False);
}, 1, "", true));
nk_839 = GetK(FIX_27, rk_833);
n_840 = (Truthy(nk_839) ? Get(Invoke(Get(_self744, "cs"), "filter", Fn((V _arrowThis862, int _argc855, V o_861, V _a858, V _a859, V _a860, V[] _rest856) => {
return (LtN(GetK(Get(o_861, "N"), nk_839), 40D) ? V.True : V.False);
}, 1, "", true)), "length") : ((V)(0D)));
hv_841 = ((SEq(Get(S_767, "mapHov"), rk_833) || SEq(going_768, rk_833)) ? V.True : V.False);
{ V _t863 = Get(B_835, "lk");
{ V _t864 = ListOf(_t863);
{ V _t865 = GetIdx(_t864, 0D);
x_842 = _t865; }
{ V _t866 = GetIdx(_t864, 1D);
y_843 = _t866; }
{ V _t867 = GetIdx(_t864, 2D);
w_844 = _t867; }
{ V _t868 = GetIdx(_t864, 3D);
h_845 = _t868; }
} }
LS_846 = (Truthy(Invoke(Arr(((V)("clouds")), ((V)("blueprint")), ((V)("construction")), ((V)("faded")), ((V)("ruined"))), "includes", Get(Get(_self744, "props"), "lockStyle"))) ? Get(Get(_self744, "props"), "lockStyle") : ((V)("planks")));
return Object_assign(Invoke(_self744, "lockVals", rk_833, LS_846, B_835, lk_837, open_836), NewObj(24).Put("id", rk_833).Put("sil", Get(B_835, "sil")).Put("lx", GetIdx(Get(B_835, "lab"), 0D)).Put("ly", GetIdx(Get(B_835, "lab"), 1D)).Put("glow", ((V)((Truthy((hv_841 is var _t869 && !Truthy(_t869) ? _t869 : open_836)) ? 1D : 0D)))).Put("lkOp", ((V)((Truthy(open_836) ? 0D : 1D)))).Put("sc", ((V)((Truthy(hv_841) ? 1.12 : 1D)))).Put("sbg", ((V)((Truthy(hv_841) ? (Truthy(open_836) ? "#ffe9a0" : (SEqS(LS_846, "planks") ? "#f3d9cf" : "#fff1c9")) : "#fff6e2")))).Put("planks", ((V)(JsStrBuf.Begin().S("M").V(Add(x_842, ((V)(6D)))).S(" ").V(Call(r1_24, V.Undef, Add(y_843, ((V)((ToNum(h_845) * 0.3)))))).S(" L").N((ToNum(Add(x_842, w_844)) - 6D)).S(" ").V(Call(r1_24, V.Undef, Add(y_843, ((V)((ToNum(h_845) * 0.58)))))).S(" M").V(Add(x_842, ((V)(8D)))).S(" ").V(Call(r1_24, V.Undef, Add(y_843, ((V)((ToNum(h_845) * 0.78)))))).S(" L").N((ToNum(Add(x_842, w_844)) - 8D)).S(" ").V(Call(r1_24, V.Undef, Add(y_843, ((V)((ToNum(h_845) * 0.42)))))).End()))).Put("locked", (!(Truthy(open_836)) ? V.True : V.False)).Put("lockTxt", ((V)(JsStrBuf.Begin().S("Lv ").V(lk_837).End()))).Put("name", GetK(RLAB_28, rk_833)).Put("here", (SEq(rk_833, cur_754) ? V.True : V.False)).Put("cur", ((V)((Truthy((open_836 is var _t870 && Truthy(_t870) ? _t870 : (!SEqS(LS_846, "planks") ? V.True : V.False))) ? "pointer" : "not-allowed")))).Put("go", Fn((V _arrowThis877, int _argc871, V _a873, V _a874, V _a875, V _a876, V[] _rest872) => {
return Invoke(_self744, "mapPick", rk_833);
}, 0, "go", true)).Put("hov", Fn((V _arrowThis884, int _argc878, V _a880, V _a881, V _a882, V _a883, V[] _rest879) => {
if (!SEq(Get(Get(_self744, "state"), "mapHov"), rk_833)) {
Invoke(_self744, "setState", NewObj(1).Put("mapHov", rk_833).V);
}
return default;
}, 0, "hov", true)).Put("unhov", Fn((V _arrowThis891, int _argc885, V _a887, V _a888, V _a889, V _a890, V[] _rest886) => {
if (SEq(Get(Get(_self744, "state"), "mapHov"), rk_833)) {
Invoke(_self744, "setState", NewObj(1).Put("mapHov", V.Null).V);
}
return default;
}, 0, "unhov", true)).Put("n", ((V)(ToStrS(n_840)))).Put("badge", (open_836 is var _t892 && !Truthy(_t892) ? _t892 : (GtN(n_840, 0D) ? V.True : V.False))).Put("nc", (Truthy(nk_839) ? Get(GetK(NEED_26, nk_839), "col") : ((V)("#000")))).Put("ni", (Truthy(nk_839) ? Get(GetK(NEED_26, nk_839), "ic") : ((V)("")))).Put("faces", Invoke(Invoke(here_838, "slice", ((V)(0D)), ((V)(3D))), "map", Fn((V _arrowThis900, int _argc893, V o_899, V _a896, V _a897, V _a898, V[] _rest894) => {
V lw_901 = default;
V src_902 = default;
lw_901 = Invoke(_self744, "lowest", o_899);
src_902 = ((V)(""));
try {
src_902 = (Invoke(Get(G("window"), "SquishSquad"), "src", Get(o_899, "id")) is var _t903 && Truthy(_t903) ? _t903 : ((V)("")));
} catch (System.Exception _ex904) {
V e_905 = default;
e_905 = Caught(_ex904);

}
return NewObj(5).Put("id", Get(o_899, "key")).Put("bg", ((V)((Truthy(src_902) ? JsStrBuf.Begin().S("url(\"").V(src_902).S("\")").End() : "none")))).Put("low", (LtN(GetK(Get(o_899, "N"), lw_901), 35D) ? V.True : V.False)).Put("lc", Get(GetK(NEED_26, lw_901), "col")).Put("name", Get(o_899, "name")).V;
return default;
}, 1, "", true))).Put("more", (GtN(Get(here_838, "length"), 3D) ? V.True : V.False)).Put("moreN", ((V)(JsStrBuf.Begin().S("+").N((ToNum(Get(here_838, "length")) - 3D)).End()))).V);
return default;
}, 1, "", true));
gB_771 = (going_768 is var _t914 && !Truthy(_t914) ? _t914 : GetK(MAPB_33, going_768));
return NewObj(7).Put("mx", mx_756).Put("ml", ml_769).Put("mapTiles", tiles_770).Put("mapO", ((V)((Truthy(gB_771) ? JsStrBuf.Begin().V(GetIdx(Get(gB_771, "c"), 0D)).S("px ").V(GetIdx(Get(gB_771, "c"), 1D)).S("px").End() : "50% 50%")))).Put("mapT", ((V)((Truthy(gB_771) ? "scale(2.6)" : (Truthy(Get(S_767, "mapIn")) ? "scale(1)" : "scale(0.92)"))))).Put("mapOp", ((V)((Truthy((Get(S_767, "mapIn") is var _t915 && Truthy(_t915) ? _t915 : gB_771)) ? 1D : 0D)))).Put("mapFade", ((V)((Truthy(gB_771) ? 1D : 0D)))).V;
return default;
}, 1, "mapVals", false)).Put("lockVals", Fn((V _self916, int _argc917, V rk_923, V LS_924, V B_925, V lk_926, V[] _rest918) => {
V x_928 = default;
V y_929 = default;
V w_930 = default;
V h_931 = default;
V cx_932 = default;
V cy_933 = default;
double s_934 = 0;
V sc_935 = default;
V puffs_936 = default;
V wisps_937 = default;
V P_938 = default;
V X0_939 = default;
V Y0_940 = default;
V chip_941 = default;
V open_927 = default;
open_927 = (_argc917 > 4 ? _rest918[0] : V.Undef);
{ V _t942 = Get(B_925, "lk");
{ V _t943 = ListOf(_t942);
{ V _t944 = GetIdx(_t943, 0D);
x_928 = _t944; }
{ V _t945 = GetIdx(_t943, 1D);
y_929 = _t945; }
{ V _t946 = GetIdx(_t943, 2D);
w_930 = _t946; }
{ V _t947 = GetIdx(_t943, 3D);
h_931 = _t947; }
} }
cx_932 = Add(x_928, ((V)((ToNum(w_930) / 2D))));
cy_933 = Add(y_929, ((V)((ToNum(h_931) / 2D))));
s_934 = Max(0.72, Min(1.1, (ToNum(h_931) / 64D)));
sc_935 = Invoke(((V)(s_934)), "toFixed", ((V)(2D)));
puffs_936 = Arr();
wisps_937 = Arr();
if (SEqS(LS_924, "clouds")) {
V sd_948 = default;
V hs_949 = default;
V bb_950 = default;
double bx_951 = 0;
double by_952 = 0;
double bw_953 = 0;
double bh_954 = 0;
double rr_955 = 0;
double nx_956 = 0;
double ny_957 = 0;
V add_958 = default;
double k_959 = 0;
double nt_960 = 0;
double ns_961 = 0;
sd_948 = Invoke(new ArrBuilder().Spread(rk_923).V, "reduce", Fn((V _arrowThis970, int _argc962, V a_968, V ch_969, V _a966, V _a967, V[] _rest963) => {
return Add(a_968, ((V)((ToNum(Invoke(ch_969, "charCodeAt", ((V)(0D)))) * 7.3))));
}, 2, "", true), ((V)(0D)));
hs_949 = Fn((V _arrowThis979, int _argc971, V a_977, V b_978, V _a975, V _a976, V[] _rest972) => {
double v_980 = 0;
v_980 = (FdLibm.Sin(ToNum(Add(((V)(((ToNum(a_977) * 127.1) + (ToNum(b_978) * 311.7)))), sd_948))) * 43758.5453);
return ((V)((v_980 - System.Math.Floor(v_980))));
return default;
}, 2, "", true);
bb_950 = Invoke(_self916, "silBox", Get(B_925, "sil"));
bx_951 = (ToNum(GetIdx(bb_950, 0D)) - 4D);
by_952 = (ToNum(GetIdx(bb_950, 1D)) - 4D);
bw_953 = ((ToNum(GetIdx(bb_950, 2D)) - ToNum(GetIdx(bb_950, 0D))) + 8D);
bh_954 = ((ToNum(GetIdx(bb_950, 3D)) - ToNum(GetIdx(bb_950, 1D))) + 8D);
rr_955 = Max(10D, Min(22D, (Min(bw_953, bh_954) * 0.32)));
nx_956 = Max(2D, System.Math.Ceiling((bw_953 / (rr_955 * 1.05))));
ny_957 = Max(1D, System.Math.Ceiling((bh_954 / (rr_955 * 1.05))));
add_958 = Fn((V _arrowThis991, int _argc981, V px_987, V py_988, V r_989, V k_990, V[] _rest982) => {
return Invoke(puffs_936, "push", NewObj(7).Put("id", ((V)(JsStrBuf.Begin().V(rk_923).S("p").V(k_990).End()))).Put("x", Call(r1_24, V.Undef, px_987)).Put("y", Call(r1_24, V.Undef, py_988)).Put("ro", Call(r1_24, V.Undef, Add(r_989, ((V)(2.2))))).Put("r", Call(r1_24, V.Undef, r_989)).Put("yh", Call(r1_24, V.Undef, ((V)((ToNum(py_988) - (ToNum(r_989) * 0.18)))))).Put("rh", Call(r1_24, V.Undef, ((V)((ToNum(r_989) * 0.78))))).V);
}, 4, "", true);
k_959 = 0D;
{
double j_992 = 0;
j_992 = 0D;
while (true) {
if (!((j_992 < ny_957))) break;
{
double i_994 = 0;
i_994 = 0D;
while (true) {
if (!((i_994 < nx_956))) break;
Call(add_958, V.Undef, ((V)(((bx_951 + (((i_994 + 0.5) * bw_953) / nx_956)) + (((ToNum(Call(hs_949, V.Undef, ((V)(i_994)), ((V)(j_992)))) - 0.5) * rr_955) * 0.7)))), ((V)(((by_952 + (((j_992 + 0.5) * bh_954) / ny_957)) + (((ToNum(Call(hs_949, V.Undef, ((V)(j_992)), ((V)((i_994 + 9D))))) - 0.5) * rr_955) * 0.6)))), ((V)((rr_955 * (0.8 + (ToNum(Call(hs_949, V.Undef, ((V)((i_994 + 3D))), ((V)((j_992 + 5D))))) * 0.55))))), ((V)(k_959++)));
i_994++;
}
}
j_992++;
}
}
nt_960 = Max(3D, Round((bw_953 / (rr_955 * 0.95))));
{
double i_996 = 0;
i_996 = 0D;
while (true) {
if (!((i_996 <= nt_960))) break;
Call(add_958, V.Undef, ((V)(((bx_951 + ((i_996 * bw_953) / nt_960)) + (((ToNum(Call(hs_949, V.Undef, ((V)(i_996)), ((V)(41D)))) - 0.5) * rr_955) * 0.5)))), ((V)(((by_952 + (rr_955 * 0.15)) - ((ToNum(Call(hs_949, V.Undef, ((V)(i_996)), ((V)(77D)))) * rr_955) * 0.55)))), ((V)((rr_955 * (0.55 + (ToNum(Call(hs_949, V.Undef, ((V)(i_996)), ((V)(31D)))) * 0.75))))), ((V)(k_959++)));
i_996++;
}
}
{
double i_998 = 0;
i_998 = 0D;
while (true) {
if (!((i_998 <= nt_960))) break;
Call(add_958, V.Undef, ((V)((bx_951 + ((i_998 * bw_953) / nt_960)))), ((V)(((by_952 + bh_954) - (rr_955 * 0.3)))), ((V)((rr_955 * (0.55 + (ToNum(Call(hs_949, V.Undef, ((V)(i_998)), ((V)(53D)))) * 0.3))))), ((V)(k_959++)));
i_998++;
}
}
ns_961 = Max(1D, Round((bh_954 / (rr_955 * 1.2))));
{
double j_1000 = 0;
j_1000 = 0D;
while (true) {
if (!((j_1000 <= ns_961))) break;
Call(add_958, V.Undef, ((V)(((bx_951 + (rr_955 * 0.1)) - ((ToNum(Call(hs_949, V.Undef, ((V)(j_1000)), ((V)(61D)))) * rr_955) * 0.3)))), ((V)((by_952 + ((j_1000 * bh_954) / ns_961)))), ((V)((rr_955 * (0.55 + (ToNum(Call(hs_949, V.Undef, ((V)(j_1000)), ((V)(67D)))) * 0.45))))), ((V)(k_959++)));
Call(add_958, V.Undef, ((V)((((bx_951 + bw_953) - (rr_955 * 0.1)) + ((ToNum(Call(hs_949, V.Undef, ((V)(j_1000)), ((V)(71D)))) * rr_955) * 0.3)))), ((V)((by_952 + ((j_1000 * bh_954) / ns_961)))), ((V)((rr_955 * (0.55 + (ToNum(Call(hs_949, V.Undef, ((V)(j_1000)), ((V)(73D)))) * 0.45))))), ((V)(k_959++)));
j_1000++;
}
}
Invoke(Arr(Arr(((V)(0.85)), ((V)((-0.25))), ((V)(0.42))), Arr(((V)(0.08)), ((V)(0.15)), ((V)(0.32)))), "forEach", Fn((V _arrowThis1016, int _argc1002, V _a1004, V i_1008, V _a1006, V _a1007, V[] _rest1003) => {
double r_1017 = 0;
double px_1018 = 0;
double py_1019 = 0;
V a_1011 = default;
V b_1013 = default;
V f_1015 = default;
{ V _t1009 = ListOf(_a1004);
{ V _t1010 = GetIdx(_t1009, 0D);
a_1011 = _t1010; }
{ V _t1012 = GetIdx(_t1009, 1D);
b_1013 = _t1012; }
{ V _t1014 = GetIdx(_t1009, 2D);
f_1015 = _t1014; }
}
r_1017 = (rr_955 * ToNum(f_1015));
px_1018 = ((bx_951 + (bw_953 * ToNum(a_1011))) + (Truthy(i_1008) ? (-rr_955) : rr_955));
py_1019 = (by_952 + (bh_954 * ToNum(b_1013)));
Invoke(wisps_937, "push", NewObj(10).Put("id", ((V)(JsStrBuf.Begin().V(rk_923).S("w").V(i_1008).End()))).Put("x", Call(r1_24, V.Undef, ((V)(px_1018)))).Put("y", Call(r1_24, V.Undef, ((V)(py_1019)))).Put("ro", Call(r1_24, V.Undef, ((V)((r_1017 + 2D))))).Put("r", Call(r1_24, V.Undef, ((V)(r_1017)))).Put("x2", Call(r1_24, V.Undef, ((V)((px_1018 + (r_1017 * 1.1)))))).Put("r2", Call(r1_24, V.Undef, ((V)((r_1017 * 0.75))))).Put("ro2", Call(r1_24, V.Undef, ((V)(((r_1017 * 0.75) + 2D))))).Put("v", ((V)((Truthy(i_1008) ? "0 0;-7 0;0 0" : "0 0;8 0;0 0")))).Put("d", ((V)(JsStrBuf.Begin().V(Invoke(((V)((6D + (ToNum(Call(hs_949, V.Undef, i_1008, ((V)(91D)))) * 3D)))), "toFixed", ((V)(1D)))).S("s").End()))).V);
return default;
}, 2, "", true));
}
P_938 = Fn((V _arrowThis1028, int _argc1020, V a_1026, V b_1027, V _a1024, V _a1025, V[] _rest1021) => {
return ((V)(JsStrBuf.Begin().V(Call(r1_24, V.Undef, Add(x_928, ((V)((ToNum(w_930) * ToNum(a_1026))))))).S(" ").V(Call(r1_24, V.Undef, Add(y_929, ((V)((ToNum(h_931) * ToNum(b_1027))))))).End()));
}, 2, "", true);
X0_939 = Fn((V _arrowThis1036, int _argc1029, V a_1035, V _a1032, V _a1033, V _a1034, V[] _rest1030) => {
return Call(r1_24, V.Undef, Add(x_928, ((V)((ToNum(w_930) * ToNum(a_1035))))));
}, 1, "", true);
Y0_940 = Fn((V _arrowThis1044, int _argc1037, V b_1043, V _a1040, V _a1041, V _a1042, V[] _rest1038) => {
return Call(r1_24, V.Undef, Add(y_929, ((V)((ToNum(h_931) * ToNum(b_1043))))));
}, 1, "", true);
chip_941 = (Truthy(open_927) ? NewObj(4).Put("chip", (false ? V.True : V.False)).Put("chipTxt", ((V)(""))).Put("chipBg", ((V)("transparent"))).Put("chipCol", ((V)("#000"))).V : (SEqS(LS_924, "blueprint") ? NewObj(4).Put("chip", (true ? V.True : V.False)).Put("chipTxt", ((V)(JsStrBuf.Begin().S("Coming \u00b7 Lv ").V(lk_926).End()))).Put("chipBg", ((V)("#3d7fc4"))).Put("chipCol", ((V)("#ffffff"))).V : (SEqS(LS_924, "faded") ? NewObj(4).Put("chip", (true ? V.True : V.False)).Put("chipTxt", ((V)(JsStrBuf.Begin().S("Lv ").V(lk_926).End()))).Put("chipBg", ((V)("#e9e2d6"))).Put("chipCol", ((V)("#8a7f70"))).V : (SEqS(LS_924, "ruined") ? NewObj(4).Put("chip", (true ? V.True : V.False)).Put("chipTxt", ((V)(JsStrBuf.Begin().S("Lv ").V(lk_926).End()))).Put("chipBg", ((V)("#2a1d14"))).Put("chipCol", ((V)("#e0b07a"))).V : NewObj(4).Put("chip", (false ? V.True : V.False)).Put("chipTxt", ((V)(""))).Put("chipBg", ((V)("transparent"))).Put("chipCol", ((V)("#000"))).V))));
return Object_assign(NewObj(28).Put("ls", NewObj(6).Put("planks", (SEqS(LS_924, "planks") ? V.True : V.False)).Put("clouds", (SEqS(LS_924, "clouds") ? V.True : V.False)).Put("blueprint", (SEqS(LS_924, "blueprint") ? V.True : V.False)).Put("construction", (SEqS(LS_924, "construction") ? V.True : V.False)).Put("faded", (SEqS(LS_924, "faded") ? V.True : V.False)).Put("ruined", (SEqS(LS_924, "ruined") ? V.True : V.False)).V).Put("lockIc", ((!(Truthy(open_927)) && SEqS(LS_924, "planks")) ? V.True : V.False)).Put("nameCol", ((V)(((!(Truthy(open_927)) && SEqS(LS_924, "faded")) ? "#9a8f80" : ((!(Truthy(open_927)) && SEqS(LS_924, "ruined")) ? "#6b5a48" : "#5b3418"))))).Put("lvTxt", ((V)(JsStrBuf.Begin().S("LV ").V(lk_926).End()))).Put("puffs", puffs_936).Put("wisps", wisps_937).Put("crk", ((V)(JsStrBuf.Begin().S("M").V(Call(P_938, V.Undef, ((V)(0.62)), ((V)(0.06)))).S(" L").V(Call(P_938, V.Undef, ((V)(0.57)), ((V)(0.24)))).S(" L").V(Call(P_938, V.Undef, ((V)(0.66)), ((V)(0.38)))).S(" L").V(Call(P_938, V.Undef, ((V)(0.6)), ((V)(0.56)))).S(" L").V(Call(P_938, V.Undef, ((V)(0.69)), ((V)(0.72)))).S(" L").V(Call(P_938, V.Undef, ((V)(0.64)), ((V)(0.9)))).S(" M").V(Call(P_938, V.Undef, ((V)(0.66)), ((V)(0.38)))).S(" L").V(Call(P_938, V.Undef, ((V)(0.78)), ((V)(0.48)))).S(" L").V(Call(P_938, V.Undef, ((V)(0.86)), ((V)(0.44)))).S(" M").V(Call(P_938, V.Undef, ((V)(0.6)), ((V)(0.56)))).S(" L").V(Call(P_938, V.Undef, ((V)(0.5)), ((V)(0.64)))).S(" M").V(Call(P_938, V.Undef, ((V)(0.1)), ((V)(0.94)))).S(" L").V(Call(P_938, V.Undef, ((V)(0.19)), ((V)(0.76)))).S(" L").V(Call(P_938, V.Undef, ((V)(0.15)), ((V)(0.62)))).S(" L").V(Call(P_938, V.Undef, ((V)(0.26)), ((V)(0.52)))).End()))).Put("web", Call(Fn((V _arrowThis1051, int _argc1045, V _a1047, V _a1048, V _a1049, V _a1050, V[] _rest1046) => {
double L_1052 = 0;
V ox_1053 = default;
V oy_1054 = default;
V A_1055 = default;
V pt_1056 = default;
V d_1057 = default;
L_1052 = (Min(ToNum(w_930), ToNum(h_931)) * 0.34);
ox_1053 = Add(x_928, ((V)(2D)));
oy_1054 = Add(y_929, ((V)(2D)));
A_1055 = Invoke(Arr(((V)(0D)), ((V)(22D)), ((V)(45D)), ((V)(68D)), ((V)(90D))), "map", Fn((V _arrowThis1065, int _argc1058, V d_1064, V _a1061, V _a1062, V _a1063, V[] _rest1059) => {
return ((V)(((ToNum(d_1064) * System.Math.PI) / 180D)));
}, 1, "", true));
pt_1056 = Fn((V _arrowThis1074, int _argc1066, V r_1072, V a_1073, V _a1070, V _a1071, V[] _rest1067) => {
return Arr(Call(r1_24, V.Undef, Add(ox_1053, ((V)((FdLibm.Cos(ToNum(a_1073)) * ToNum(r_1072)))))), Call(r1_24, V.Undef, Add(oy_1054, ((V)((FdLibm.Sin(ToNum(a_1073)) * ToNum(r_1072)))))));
}, 2, "", true);
d_1057 = Invoke(Invoke(A_1055, "map", Fn((V _arrowThis1082, int _argc1075, V a_1081, V _a1078, V _a1079, V _a1080, V[] _rest1076) => {
return ((V)(JsStrBuf.Begin().S("M").V(ox_1053).S(" ").V(oy_1054).S(" L").V(Invoke(Call(pt_1056, V.Undef, ((V)(L_1052)), a_1081), "join", ((V)(" ")))).End()));
}, 1, "", true)), "join", ((V)(" ")));
Invoke(Arr(((V)(0.35)), ((V)(0.65)), ((V)(0.95))), "forEach", Fn((V _arrowThis1090, int _argc1083, V f_1089, V _a1086, V _a1087, V _a1088, V[] _rest1084) => {
double r_1091 = 0;
r_1091 = (L_1052 * ToNum(f_1089));
{
double k_1092 = 0;
k_1092 = 0D;
while (true) {
if (!((k_1092 < (ToNum(Get(A_1055, "length")) - 1D)))) break;
V p_1094 = default;
V q_1095 = default;
V m_1096 = default;
p_1094 = Call(pt_1056, V.Undef, ((V)(r_1091)), GetIdx(A_1055, k_1092));
q_1095 = Call(pt_1056, V.Undef, ((V)(r_1091)), GetIdx(A_1055, (k_1092 + 1D)));
m_1096 = Call(pt_1056, V.Undef, ((V)((r_1091 * 0.82))), ((V)((ToNum(Add(GetIdx(A_1055, k_1092), GetIdx(A_1055, (k_1092 + 1D)))) / 2D))));
d_1057 = ((V)(JsStrBuf.Begin().V(d_1057).S(" M").V(Invoke(p_1094, "join", ((V)(" ")))).S(" Q").V(Invoke(m_1096, "join", ((V)(" ")))).S(" ").V(Invoke(q_1095, "join", ((V)(" ")))).End()));
k_1092++;
}
}
return default;
}, 1, "", true));
return d_1057;
return default;
}, 0, "", true), V.Undef)).Put("brdT", ((V)(JsStrBuf.Begin().S("translate(").V(Call(X0_939, V.Undef, ((V)(0.3)))).S(" ").V(Call(Y0_940, V.Undef, ((V)(0.14)))).S(") rotate(-28)").End()))).Put("brdL", Call(r1_24, V.Undef, ((V)((ToNum(h_931) * 0.72))))).Put("brdP", Call(Fn((V _arrowThis1103, int _argc1097, V _a1099, V _a1100, V _a1101, V _a1102, V[] _rest1098) => {
V l_1104 = default;
l_1104 = Call(r1_24, V.Undef, ((V)((ToNum(h_931) * 0.72))));
return ((V)(JsStrBuf.Begin().S("M-4 0 H4 V").V(Call(r1_24, V.Undef, ((V)((ToNum(l_1104) - 5D))))).S(" L2 ").V(l_1104).S(" L0 ").V(Call(r1_24, V.Undef, ((V)((ToNum(l_1104) - 6D))))).S(" L-2 ").V(Call(r1_24, V.Undef, ((V)((ToNum(l_1104) - 1D))))).S(" L-4 ").V(Call(r1_24, V.Undef, ((V)((ToNum(l_1104) - 4D))))).S(" Z").End()));
return default;
}, 0, "", true), V.Undef)).Put("brd2T", ((V)(JsStrBuf.Begin().S("translate(").V(Call(X0_939, V.Undef, ((V)(0.18)))).S(" ").V(Call(r1_24, V.Undef, ((V)((ToNum(Add(y_929, h_931)) - 6D))))).S(") rotate(-8)").End()))).Put("brd2W", Call(r1_24, V.Undef, ((V)((ToNum(w_930) * 0.34))))).Put("rub", Invoke(Arr(Arr(((V)(0.74)), ((V)(0D))), Arr(((V)(0.8)), ((V)(1D))), Arr(((V)(0.85)), ((V)(0D))), Arr(((V)(0.9)), ((V)(1D)))), "map", Fn((V _arrowThis1117, int _argc1105, V _a1107, V i_1111, V _a1109, V _a1110, V[] _rest1106) => {
V a_1114 = default;
V k_1116 = default;
{ V _t1112 = ListOf(_a1107);
{ V _t1113 = GetIdx(_t1112, 0D);
a_1114 = _t1113; }
{ V _t1115 = GetIdx(_t1112, 1D);
k_1116 = _t1115; }
}
return NewObj(3).Put("id", ((V)(JsStrBuf.Begin().V(rk_923).S("r").V(i_1111).End()))).Put("t", ((V)(JsStrBuf.Begin().S("translate(").V(Call(X0_939, V.Undef, a_1114)).S(" ").V(Call(r1_24, V.Undef, ((V)(((ToNum(Add(y_929, h_931)) - 2D) - (ToNum(k_1116) * 2D)))))).S(") rotate(").N(((ToNum(i_1111) * 37D) % 60D)).S(")").End()))).Put("s", Invoke(((V)((2.4 + ((ToNum(i_1111) % 2D) * 1.4)))), "toFixed", ((V)(1D)))).V;
}, 2, "", true))).Put("dust", Invoke(Arr(((V)(0.22)), ((V)(0.44)), ((V)(0.7)), ((V)(0.86))), "map", Fn((V _arrowThis1126, int _argc1118, V a_1124, V i_1125, V _a1122, V _a1123, V[] _rest1119) => {
return NewObj(5).Put("id", ((V)(JsStrBuf.Begin().V(rk_923).S("d").V(i_1125).End()))).Put("x", Call(X0_939, V.Undef, a_1124)).Put("v", ((V)(JsStrBuf.Begin().V(Call(r1_24, V.Undef, Add(y_929, ((V)(4D))))).S(";").V(Call(r1_24, V.Undef, ((V)((ToNum(Add(y_929, h_931)) - 4D))))).End()))).Put("d", ((V)(JsStrBuf.Begin().V(Invoke(((V)((3.2 + (ToNum(i_1125) * 0.7)))), "toFixed", ((V)(1D)))).S("s").End()))).Put("b", ((V)(JsStrBuf.Begin().S("-").V(Invoke(((V)((ToNum(i_1125) * 1.1))), "toFixed", ((V)(1D)))).S("s").End()))).V;
}, 2, "", true))).Put("lkT", ((V)(JsStrBuf.Begin().S("translate(").V(Call(r1_24, V.Undef, cx_932)).S(" ").V(Call(r1_24, V.Undef, cy_933)).S(") scale(").V(sc_935).S(")").End()))).Put("signT", ((V)(JsStrBuf.Begin().S("translate(").V(Call(r1_24, V.Undef, cx_932)).S(" ").V(Call(r1_24, V.Undef, Add(cy_933, ((V)(4D))))).S(") scale(").V(sc_935).S(")").End()))).Put("coneT", ((V)(JsStrBuf.Begin().S("translate(").V(Call(r1_24, V.Undef, ((V)((ToNum(Add(x_928, w_930)) - 14D))))).S(" ").V(Call(r1_24, V.Undef, ((V)((ToNum(Add(y_929, h_931)) - 3D))))).S(") scale(").V(sc_935).S(")").End()))).Put("clipId", ((V)(JsStrBuf.Begin().S("mp-cl-").V(rk_923).End()))).Put("clipUrl", ((V)(JsStrBuf.Begin().S("url(#mp-cl-").V(rk_923).S(")").End()))).Put("tx", Call(r1_24, V.Undef, ((V)((ToNum(x_928) - 30D))))).Put("tw", Call(r1_24, V.Undef, Add(w_930, ((V)(60D))))).Put("ty1", Call(Y0_940, V.Undef, ((V)(0.22)))).Put("ty2", Call(Y0_940, V.Undef, ((V)(0.66)))).Put("tr1", ((V)(JsStrBuf.Begin().S("rotate(-9 ").V(Call(r1_24, V.Undef, cx_932)).S(" ").V(Call(r1_24, V.Undef, cy_933)).S(")").End()))).Put("tr2", ((V)(JsStrBuf.Begin().S("rotate(7 ").V(Call(r1_24, V.Undef, cx_932)).S(" ").V(Call(r1_24, V.Undef, cy_933)).S(")").End()))).Put("bpSk", ((V)(JsStrBuf.Begin().S("M").V(Call(P_938, V.Undef, ((V)(0.32)), ((V)(0.82)))).S(" V").V(Call(Y0_940, V.Undef, ((V)(0.56)))).S(" H").V(Call(X0_939, V.Undef, ((V)(0.68)))).S(" V").V(Call(Y0_940, V.Undef, ((V)(0.82)))).S(" M").V(Call(P_938, V.Undef, ((V)(0.28)), ((V)(0.82)))).S(" H").V(Call(X0_939, V.Undef, ((V)(0.72)))).S(" M").V(Call(P_938, V.Undef, ((V)(0.32)), ((V)(0.66)))).S(" H").V(Call(X0_939, V.Undef, ((V)(0.68)))).S(" M").V(Call(P_938, V.Undef, ((V)(0.14)), ((V)(0.82)))).S(" V").V(Call(Y0_940, V.Undef, ((V)(0.48)))).S(" M").V(Call(P_938, V.Undef, ((V)(0.09)), ((V)(0.48)))).S(" H").V(Call(X0_939, V.Undef, ((V)(0.19)))).S(" L").V(Call(P_938, V.Undef, ((V)(0.165)), ((V)(0.34)))).S(" H").V(Call(X0_939, V.Undef, ((V)(0.115)))).S(" Z M").V(Call(P_938, V.Undef, ((V)(0.8)), ((V)(0.28)))).S(" H").V(Call(X0_939, V.Undef, ((V)(0.9)))).S(" V").V(Call(Y0_940, V.Undef, ((V)(0.46)))).S(" H").V(Call(X0_939, V.Undef, ((V)(0.8)))).S(" Z").End()))).Put("bpDim", ((V)(JsStrBuf.Begin().S("M").V(Call(r1_24, V.Undef, Add(x_928, ((V)(6D))))).S(" ").V(Call(r1_24, V.Undef, ((V)((ToNum(Add(y_929, h_931)) - 5D))))).S(" H").V(Call(r1_24, V.Undef, ((V)((ToNum(Add(x_928, w_930)) - 6D))))).S(" M").V(Call(r1_24, V.Undef, Add(x_928, ((V)(6D))))).S(" ").V(Call(r1_24, V.Undef, ((V)((ToNum(Add(y_929, h_931)) - 8D))))).S(" V").V(Call(r1_24, V.Undef, ((V)((ToNum(Add(y_929, h_931)) - 2D))))).S(" M").V(Call(r1_24, V.Undef, ((V)((ToNum(Add(x_928, w_930)) - 6D))))).S(" ").V(Call(r1_24, V.Undef, ((V)((ToNum(Add(y_929, h_931)) - 8D))))).S(" V").V(Call(r1_24, V.Undef, ((V)((ToNum(Add(y_929, h_931)) - 2D))))).End()))).V, chip_941);
return default;
}, 5, "lockVals", false)).Put("lowest", Fn((V _self1127, int _argc1128, V c_1134, V _a1131, V _a1132, V _a1133, V[] _rest1129) => {
return Invoke(Object_keys(Get(c_1134, "N")), "reduce", Fn((V _arrowThis1143, int _argc1135, V a_1141, V k_1142, V _a1139, V _a1140, V[] _rest1136) => {
return (Lt(GetK(Get(c_1134, "N"), k_1142), GetK(Get(c_1134, "N"), a_1141)) ? k_1142 : a_1141);
}, 2, "", true), ((V)("h")));
return default;
}, 1, "lowest", false)).V;
Set(G_8, "__house", NewObj(10).Put("init", Fn((V _self1144, int _argc1145, V _a1147, V _a1148, V _a1149, V _a1150, V[] _rest1146) => {
V i_1151 = default;
V t_1152 = default;
V rows_1153 = default;
X_17 = Get(G_8, "House3D");
RD_18 = Get(G_8, "RenoDraw");
Set(sh_19, "X", X_17);
geo0_22 = (Truthy(Get(X_17, "RM")) ? NewObj(3).Put("s", Get(Get(X_17, "RM"), "s")).Put("e", Get(Get(X_17, "RM"), "e")).Put("b", Get(X_17, "BIG")).V : V.Null);
Invoke(Object_keys((Get(X_17, "SZDEF") is var _t1162 && Truthy(_t1162) ? _t1162 : NewObj(0).V)), "forEach", Fn((V _self1154, int _argc1155, V a_1161, V _a1158, V _a1159, V _a1160, V[] _rest1156) => {
Invoke(X_17, "setSize", a_1161, GetK(Get(X_17, "SZDEF"), a_1161));
return default;
}, 1, "", false));
Set(Get(sh_19, "SZ"), "a", Object_assign(NewObj(0).V, (Get(X_17, "SZDEF") is var _t1163 && Truthy(_t1163) ? _t1163 : NewObj(0).V)));
Invoke((Get(X_17, "RKEYS") is var _t1184 && Truthy(_t1184) ? _t1184 : Arr()), "forEach", Fn((V _self1164, int _argc1165, V rk_1171, V _a1168, V _a1169, V _a1170, V[] _rest1166) => {
V R_1172 = default;
R_1172 = GetK(Get(X_17, "ROOMS"), rk_1171);
if (Truthy((((!(Truthy(R_1172)) ? V.True : V.False) is var _t1173 && Truthy(_t1173) ? _t1173 : Get(R_1172, "out")) is var _t1174 && Truthy(_t1174) ? _t1174 : Get(R_1172, "_w31")))) {
return default;
}
Set(R_1172, "_w31", ((V)(1D)));
Set(R_1172, "winX0", Get(R_1172, "winX"));
Set(R_1172, "winX", V.Null);
Set(R_1172, "artX0", Get(R_1172, "artX"));
Set(R_1172, "artX", V.Null);
Set(R_1172, "fixed", Invoke((Get(R_1172, "fixed") is var _t1183 && Truthy(_t1183) ? _t1183 : Arr()), "filter", Fn((V _self1175, int _argc1176, V a_1182, V _a1179, V _a1180, V _a1181, V[] _rest1177) => {
return (SEqS(GetIdx(a_1182, 0D), "hwin") ? V.True : V.False);
return default;
}, 1, "", false)));
return default;
}, 1, "", false));
{
i_1151 = ((V)(0D));
while (true) {
if (!(Lt(i_1151, Get(RCSV_9, "length")))) break;
t_1152 = (Truthy(Get(G_8, "__readFile")) ? Invoke(G_8, "__readFile", GetK(RCSV_9, i_1151)) : V.Null);
if (!(Truthy(t_1152))) {
goto _cont1185;
}
rows_1153 = Invoke(Invoke(RD_18, "edit", Invoke(RD_18, "parseCSV", t_1152)), "filter", Fn((V _self1186, int _argc1187, V x_1193, V _a1190, V _a1191, V _a1192, V[] _rest1188) => {
return (GetK(RMAP_10, Get(x_1193, "room")) is var _t1194 && !Truthy(_t1194) ? _t1194 : (!(Truthy(Invoke(NewRegExp(RX16, "Doorway|Club Entrance|Entry & Divider", ""), "test", Get(x_1193, "slotName")))) ? V.True : V.False));
return default;
}, 1, "", false));
if (Truthy(Get(rows_1153, "length"))) {
Set(sh_19, "rows", rows_1153);
Set(sh_19, "byId", New(G("Map"), Invoke(rows_1153, "map", Fn((V _self1195, int _argc1196, V x_1202, V _a1199, V _a1200, V _a1201, V[] _rest1197) => {
return Arr(Get(x_1202, "id"), x_1202);
return default;
}, 1, "", false))));
break;
}
_cont1185: ;
PostInc(ref i_1151, 1D);
}
}
return Get(Get(sh_19, "rows"), "length");
return default;
}, 0, "init", false)).Put("geo", Fn((V _self1203, int _argc1204, V rk_1210, V _a1207, V _a1208, V _a1209, V[] _rest1205) => {
if ((!(Truthy(X_17)) || !(Truthy(Get(X_17, "RM"))))) {
return default;
}
Set(X_17, "BIG", BIGR_15);
Set(Get(X_17, "RM"), "s", (GetK(BIGR_15, rk_1210) is var _t1211 && Truthy(_t1211) ? _t1211 : ((V)(1D))));
Set(Get(X_17, "RM"), "e", (SEqS(rk_1210, "dance") ? edgeR_16 : V.Null));
return default;
}, 1, "geo", false)).Put("variant", Fn((V _self1212, int _argc1213, V id_1219, V st_1220, V txt_1221, V rot_1222, V[] _rest1214) => {
V r_1223 = default;
V Dr_1224 = default;
V sF_1225 = default;
V A_1226 = default;
r_1223 = Invoke(Get(sh_19, "byId"), "get", id_1219);
if (!(Truthy(r_1223))) {
return ((V)("null"));
}
Dr_1224 = Invoke(sh_19, "rnDraw", r_1223, ((V)(0D)), (rot_1222.IsNullish ? V.Null : rot_1222), st_1220, txt_1221);
if (!(Truthy(Dr_1224))) {
return ((V)("null"));
}
sF_1225 = ((V)((Truthy((Get(Dr_1224, "srcF") is var _t1227 && !Truthy(_t1227) ? _t1227 : Get(Dr_1224, "srcB"))) ? 1D : 0D)));
A_1226 = Call(reg_23, V.Undef, id_1219);
return Invoke(G("JSON"), "stringify", NewObj(10).Put("src", Call(uri_20, V.Undef, (Truthy(sF_1225) ? Get(Dr_1224, "srcB") : (Get(Dr_1224, "src") is var _t1228 && Truthy(_t1228) ? _t1228 : ((V)("")))))).Put("srcF", (Truthy(sF_1225) ? Call(uri_20, V.Undef, Get(Dr_1224, "srcF")) : ((V)("")))).Put("whole", Call(uri_20, V.Undef, (Get(Dr_1224, "src") is var _t1229 && Truthy(_t1229) ? _t1229 : ((V)(""))))).Put("bb", (Get(Dr_1224, "bb") is var _t1230 && Truthy(_t1230) ? _t1230 : V.Null)).Put("tb", (Truthy((A_1226 is var _t1231 && !Truthy(_t1231) ? _t1231 : Get(A_1226, "mount"))) ? Invoke(sh_19, "tightBB", Dr_1224, ((V)(1D))) : V.Null)).Put("top", (Get(Dr_1224, "top") is var _t1232 && Truthy(_t1232) ? _t1232 : V.Null)).Put("players", (Truthy(Get(Dr_1224, "players")) ? Call(plain_54, V.Undef, Get(Dr_1224, "players")) : V.Null)).Put("fog", (Truthy(Get(Dr_1224, "fog")) ? Call(plain_54, V.Undef, Get(Dr_1224, "fog")) : V.Null)).Put("vac", (Truthy(Get(Dr_1224, "vac")) ? NewObj(2).Put("home", Call(plain_54, V.Undef, Get(Get(Dr_1224, "vac"), "home"))).Put("bb", Get(Get(Dr_1224, "vac"), "bb")).V : V.Null)).Put("screen", (Truthy(Get(Dr_1224, "screen")) ? Call(plain_54, V.Undef, Get(Dr_1224, "screen")) : V.Null)).V);
return default;
}, 4, "variant", false)).Put("vac", Fn((V _self1233, int _argc1234, V id_1240, V rot_1241, V _a1238, V _a1239, V[] _rest1235) => {
V r_1242 = default;
V Dr_1243 = default;
r_1242 = Invoke(Get(sh_19, "byId"), "get", id_1240);
if (!(Truthy(r_1242))) {
return ((V)("null"));
}
Dr_1243 = Invoke(sh_19, "rnDraw", r_1242, ((V)(0D)), (rot_1241.IsNullish ? V.Null : rot_1241), ((V)("")), ((V)("")));
if ((!(Truthy(Dr_1243)) || !(Truthy(Get(Dr_1243, "vac"))))) {
return ((V)("null"));
}
return Invoke(G("JSON"), "stringify", NewObj(3).Put("src", Call(uri_20, V.Undef, Get(Get(Dr_1243, "vac"), "src"))).Put("bb", Get(Get(Dr_1243, "vac"), "bb")).Put("home", Call(plain_54, V.Undef, Get(Get(Dr_1243, "vac"), "home"))).V);
return default;
}, 2, "vac", false)).Put("render", Fn((V _self1244, int _argc1245, V t_1251, V r_1252, V c_1253, V v_1254, V[] _rest1246) => {
V R_1255 = default;
V grads_1256 = default;
V D_1257 = default;
if (SEqN(Invoke(((V)(ToStrS(t_1251))), "indexOf", ((V)("R:"))), 0D)) {
Call(reg_23, V.Undef, Invoke(t_1251, "slice", ((V)(2D))));
}
R_1255 = Invoke(X_17, "render", t_1251, r_1252, c_1253, (v_1254 is var _t1258 && Truthy(_t1258) ? _t1258 : ((V)(""))));
if (!(Truthy(R_1255))) {
return ((V)("null"));
}
grads_1256 = NewObj(0).V;
Invoke((Get(R_1255, "gids") is var _t1269 && Truthy(_t1269) ? _t1269 : Arr()), "forEach", Fn((V _self1259, int _argc1260, V g_1266, V _a1263, V _a1264, V _a1265, V[] _rest1261) => {
V q_1267 = default;
q_1267 = (Get(X_17, "_GR") is var _t1268 && !Truthy(_t1268) ? _t1268 : Invoke(Get(X_17, "_GR"), "get", g_1266));
if (Truthy(q_1267)) {
SetK(grads_1256, g_1266, Call(plain_54, V.Undef, q_1267));
}
return default;
}, 1, "", false));
D_1257 = (GetK(Get(X_17, "CAT"), t_1251) is var _t1270 && Truthy(_t1270) ? _t1270 : NewObj(0).V);
return Invoke(G("JSON"), "stringify", NewObj(12).Put("bb", Get(R_1255, "bb")).Put("vb", Get(R_1255, "vb")).Put("gids", Get(R_1255, "gids")).Put("back", (Truthy(Get(D_1257, "reno")) ? Arr() : Call(plain_54, V.Undef, Get(R_1255, "back")))).Put("part", (Truthy(Get(D_1257, "reno")) ? Arr() : Call(plain_54, V.Undef, Get(R_1255, "part")))).Put("front", (Truthy(Get(D_1257, "reno")) ? Arr() : Call(plain_54, V.Undef, Get(R_1255, "front")))).Put("glow", (Get(R_1255, "glow") is var _t1271 && Truthy(_t1271) ? _t1271 : V.Null)).Put("face", Get(R_1255, "face")).Put("shadow", Get(R_1255, "shadow")).Put("contact", Get(R_1255, "contact")).Put("foot", Get(R_1255, "foot")).Put("grads", grads_1256).V);
return default;
}, 4, "render", false)).Put("shell", Fn((V _self1272, int _argc1273, V rk_1279, V sf_1280, V locks_1281, V _a1278, V[] _rest1274) => {
V L_1282 = default;
V Sh_1283 = default;
L_1282 = Invoke(G("JSON"), "parse", (locks_1281 is var _t1284 && Truthy(_t1284) ? _t1284 : ((V)("{}"))));
Sh_1283 = Invoke(X_17, "shell", rk_1279, Invoke(G("JSON"), "parse", (sf_1280 is var _t1285 && Truthy(_t1285) ? _t1285 : ((V)("{}")))), Fn((V _self1286, int _argc1287, V to_1293, V _a1290, V _a1291, V _a1292, V[] _rest1288) => {
return (GetK(L_1282, to_1293) is var _t1294 && Truthy(_t1294) ? _t1294 : ((V)(0D)));
return default;
}, 1, "", false));
return (Truthy(Sh_1283) ? Invoke(G("JSON"), "stringify", Call(plain_54, V.Undef, Sh_1283)) : ((V)("null")));
return default;
}, 3, "shell", false)).Put("tex", Fn((V _self1295, int _argc1296, V id_1302, V _a1299, V _a1300, V _a1301, V[] _rest1297) => {
V r_1303 = default;
V D0_1304 = default;
V T_1305 = default;
r_1303 = Invoke(Get(sh_19, "byId"), "get", id_1302);
if (!(Truthy(r_1303))) {
return ((V)("null"));
}
D0_1304 = (Invoke(sh_19, "rnDraw", r_1303, ((V)(0D))) is var _t1306 && Truthy(_t1306) ? _t1306 : NewObj(0).V);
T_1305 = Fn((V _self1307, int _argc1308, V k_1314, V _a1311, V _a1312, V _a1313, V[] _rest1309) => {
return Call(uri_20, V.Undef, Invoke(sh_19, "rnTex", id_1302, k_1314));
return default;
}, 1, "", false);
return Invoke(G("JSON"), "stringify", NewObj(24).Put("wall", Call(T_1305, V.Undef, ((V)("wall")))).Put("wallS", Call(T_1305, V.Undef, ((V)("wallS")))).Put("board", Call(T_1305, V.Undef, ((V)("board")))).Put("floor", Call(T_1305, V.Undef, ((V)("floor")))).Put("ceil", Call(T_1305, V.Undef, ((V)("ceil")))).Put("fence", Call(T_1305, V.Undef, ((V)("fence")))).Put("fenceR", Call(T_1305, V.Undef, ((V)("fenceR")))).Put("fW", (Get(D0_1304, "fW") is var _t1315 && Truthy(_t1315) ? _t1315 : ((V)(0D)))).Put("fWR", (Get(D0_1304, "fWR") is var _t1316 && Truthy(_t1316) ? _t1316 : ((V)(0D)))).Put("ceilRoom", (!(!(Truthy(Get(D0_1304, "ceilRoom")))) ? V.True : V.False)).Put("ceilBase", (Get(D0_1304, "ceilBase") is var _t1317 && Truthy(_t1317) ? _t1317 : ((V)("")))).Put("ceilTrim", (Get(D0_1304, "ceilTrim") is var _t1318 && Truthy(_t1318) ? _t1318 : ((V)("")))).Put("wallOne", Call(uri_20, V.Undef, (Get(D0_1304, "wallOne") is var _t1319 && Truthy(_t1319) ? _t1319 : ((V)(""))))).Put("wallOneR", Call(uri_20, V.Undef, (Get(D0_1304, "wallOneR") is var _t1320 && Truthy(_t1320) ? _t1320 : ((V)(""))))).Put("wallOneFull", (!(!(Truthy(Get(D0_1304, "wallOneFull")))) ? V.True : V.False)).Put("wallRnd", Call(uri_20, V.Undef, (Get(D0_1304, "wallRnd") is var _t1321 && Truthy(_t1321) ? _t1321 : ((V)(""))))).Put("floorRoom", (Truthy(Get(D0_1304, "floorRoom")) ? NewObj(2).Put("bg", Get(Get(D0_1304, "floorRoom"), "bg")).Put("layers", Invoke(Get(Get(D0_1304, "floorRoom"), "layers"), "map", Fn((V _self1322, int _argc1323, V l_1329, V _a1326, V _a1327, V _a1328, V[] _rest1324) => {
return Object_assign(NewObj(0).V, l_1329, NewObj(1).Put("url", Call(uri_20, V.Undef, Get(l_1329, "url"))).V);
return default;
}, 1, "", false))).V : V.Null)).Put("ylRoom", Call(uri_20, V.Undef, (Get(D0_1304, "ylRoom") is var _t1330 && Truthy(_t1330) ? _t1330 : ((V)(""))))).Put("win19", (!(!(Truthy(Get(D0_1304, "win19")))) ? V.True : V.False)).Put("src", Call(uri_20, V.Undef, (Get(D0_1304, "src") is var _t1331 && Truthy(_t1331) ? _t1331 : ((V)(""))))).Put("wallL", (Get(D0_1304, "wallL") is var _t1332 && Truthy(_t1332) ? _t1332 : ((V)("")))).Put("wallR", (Get(D0_1304, "wallR") is var _t1333 && Truthy(_t1333) ? _t1333 : ((V)("")))).Put("wallRoom", (Get(D0_1304, "wallRoom") is var _t1334 && Truthy(_t1334) ? _t1334 : ((V)("")))).Put("fH", (Get(D0_1304, "fH") is var _t1335 && Truthy(_t1335) ? _t1335 : ((V)(0D)))).V);
return default;
}, 1, "tex", false)).Put("beach", Fn((V _self1336, int _argc1337, V oJson_1343, V _a1340, V _a1341, V _a1342, V[] _rest1338) => {
V BE_1344 = default;
V o_1345 = default;
V dec_1346 = default;
V sc_1347 = default;
V props_1348 = default;
BE_1344 = Get(G_8, "Beach");
if (!(Truthy(BE_1344))) {
return ((V)("null"));
}
o_1345 = Invoke(G("JSON"), "parse", (oJson_1343 is var _t1349 && Truthy(_t1349) ? _t1349 : ((V)("{}"))));
Invoke(BE_1344, "setSeason", Get(o_1345, "season"));
dec_1346 = Fn((V _self1350, int _argc1351, V u_1357, V _a1354, V _a1355, V _a1356, V[] _rest1352) => {
u_1357 = ((V)(ToStrS((u_1357 is var _t1358 && Truthy(_t1358) ? _t1358 : ((V)(""))))));
return (SEqN(Invoke(u_1357, "indexOf", ((V)("data:image/svg+xml,"))), 0D) ? Call(G("decodeURIComponent"), V.Undef, Invoke(u_1357, "slice", ((V)(19D)))) : u_1357);
return default;
}, 1, "", false);
sc_1347 = Invoke(BE_1344, "scene", o_1345);
props_1348 = Invoke(Invoke(BE_1344, "props", NewObj(1).Put("season", Get(o_1345, "season")).V), "map", Fn((V _self1359, int _argc1360, V q_1366, V _a1363, V _a1364, V _a1365, V[] _rest1361) => {
return NewObj(8).Put("id", Get(q_1366, "id")).Put("x", Get(q_1366, "x")).Put("y", Get(q_1366, "y")).Put("w", Get(q_1366, "w")).Put("h", Get(q_1366, "h")).Put("ax", Get(q_1366, "ax")).Put("ay", Get(q_1366, "ay")).Put("src", Call(dec_1346, V.Undef, Get(q_1366, "src"))).V;
return default;
}, 1, "", false));
return Invoke(G("JSON"), "stringify", NewObj(7).Put("defs", Get(sc_1347, "defs")).Put("body", Get(sc_1347, "body")).Put("props", props_1348).Put("shells", Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D))), "map", Fn((V _self1367, int _argc1368, V k_1374, V _a1371, V _a1372, V _a1373, V[] _rest1369) => {
return Call(dec_1346, V.Undef, Invoke(BE_1344, "shellSvg", k_1374));
return default;
}, 1, "", false))).Put("fish", Call(dec_1346, V.Undef, FISHB_30)).Put("board", BOARDH_31).Put("rod", RODH_32).V);
return default;
}, 1, "beach", false)).Put("map", Fn((V _self1375, int _argc1376, V stJson_1382, V _a1379, V _a1380, V _a1381, V[] _rest1377) => {
V st_1383 = default;
V open_1384 = default;
V me_1385 = default;
V v_1386 = default;
st_1383 = Invoke(G("JSON"), "parse", stJson_1382);
open_1384 = NewObj(0).V;
Invoke((Get(st_1383, "open") is var _t1395 && Truthy(_t1395) ? _t1395 : Arr()), "forEach", Fn((V _self1387, int _argc1388, V r_1394, V _a1391, V _a1392, V _a1393, V[] _rest1389) => {
SetK(open_1384, r_1394, ((V)(1D)));
return default;
}, 1, "", false));
me_1385 = NewObj(11).Put("X", X_17).Put("props", NewObj(0).V).Put("state", NewObj(4).Put("cur", Get(st_1383, "cur")).Put("mapHov", (Get(st_1383, "mapHov") is var _t1396 && Truthy(_t1396) ? _t1396 : V.Null)).Put("mapGo", (Get(st_1383, "mapGo") is var _t1397 && Truthy(_t1397) ? _t1397 : V.Null)).Put("mapIn", (!(!(Truthy(Get(st_1383, "mapIn")))) ? V.True : V.False)).V).Put("cs", (Get(st_1383, "cs") is var _t1398 && Truthy(_t1398) ? _t1398 : Arr())).Put("_nat", Get(mp_53, "_nat")).Put("lvl", Fn((V _self1399, int _argc1400, V _a1402, V _a1403, V _a1404, V _a1405, V[] _rest1401) => {
return Get(st_1383, "lvl");
return default;
}, 0, "lvl", false)).Put("isOpen", Fn((V _self1406, int _argc1407, V r_1413, V _a1410, V _a1411, V _a1412, V[] _rest1408) => {
return (!(!(Truthy(GetK(open_1384, r_1413)))) ? V.True : V.False);
return default;
}, 1, "isOpen", false)).Put("seasonNow", Fn((V _self1414, int _argc1415, V _a1417, V _a1418, V _a1419, V _a1420, V[] _rest1416) => {
return Get(st_1383, "season");
return default;
}, 0, "seasonNow", false)).Put("shellOf", Fn((V _self1421, int _argc1422, V r_1428, V _a1425, V _a1426, V _a1427, V[] _rest1423) => {
return NewObj(1).Put("P", NewObj(1).Put("b0", GetK((Get(st_1383, "b0") is var _t1429 && Truthy(_t1429) ? _t1429 : NewObj(0).V), r_1428)).V).V;
return default;
}, 1, "shellOf", false)).Put("lowest", Get(mp_53, "lowest")).Put("lockVals", Get(mp_53, "lockVals")).V;
v_1386 = Invoke(Get(mp_53, "mapVals"), "call", me_1385, NewObj(0).V);
Set(mp_53, "_nat", Get(me_1385, "_nat"));
Set(Get(v_1386, "mx"), "nat", Get(me_1385, "_nat"));
return Invoke(G("JSON"), "stringify", Call(plain_54, V.Undef, v_1386));
return default;
}, 1, "map", false)).Put("piece", Fn((V _self1430, int _argc1431, V id_1437, V _a1434, V _a1435, V _a1436, V[] _rest1432) => {
V A_1438 = default;
A_1438 = Call(reg_23, V.Undef, id_1437);
return (Truthy(A_1438) ? Invoke(G("JSON"), "stringify", Call(plain_54, V.Undef, A_1438)) : ((V)("null")));
return default;
}, 1, "piece", false)).V);
return default;
}, 1, "", false), V.Undef, (!string.Equals(GTypeof("globalThis"), "undefined") ? G("globalThis") : GlobalV));
        }
    }
}
