// reno-plus27.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus27_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("<ellipse[^>]*\\/>", "g");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("<circle[^>]*\\/>", "");
        static readonly System.Text.RegularExpressions.Regex RX2 = JsRegExp.Compile("\"", "g");
        static readonly System.Text.RegularExpressions.Regex RX3 = JsRegExp.Compile(">", "g");
        static readonly System.Text.RegularExpressions.Regex RX4 = JsRegExp.Compile("<", "g");
        static readonly System.Text.RegularExpressions.Regex RX5 = JsRegExp.Compile("&", "g");
        public static void Run()
        {
Call(Named(boot_1412 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V shade_10 = default;
double PI_11 = 0;
V H_12 = default;
V rng_13 = default;
V an_14 = default;
V SPL_15 = default;
V f1_16 = default;
V n4_17 = default;
V rep_18 = default;
V FL_19 = default;
V fblot_20 = default;
V W_21 = default;
V polyW_22 = default;
V lineW_23 = default;
V crvW_24 = default;
V chip_25 = default;
V TR_26 = default;
V wk_27 = default;
V gv_28 = default;
V K_29 = default;
V pt_30 = default;
V quadW_31 = default;
V dot_32 = default;
V dotD_33 = default;
V rrW_34 = default;
V refl_35 = default;
V walk_36 = default;
V heel_37 = default;
V fYlino_38 = default;
V fDiner_39 = default;
V fQuarry_40 = default;
V fOak_41 = default;
V fCush_42 = default;
V band_43 = default;
V mould_44 = default;
V mkV_45 = default;
V CFRM_46 = default;
V at_47 = default;
V P2_48 = default;
V cE_49 = default;
V cHi_50 = default;
V cD_51 = default;
V cEl_52 = default;
V cShade_53 = default;
V cDoc_54 = default;
V cBlots_55 = default;
V cStain_56 = default;
V cWeb_57 = default;
V cAcou_58 = default;
V cBead_59 = default;
V cPots_60 = default;
V cTray_61 = default;
V cOnyx_62 = default;
V CEIL27_63 = default;
V CMEMO_64 = default;
V WALL27_65 = default;
V CB27_66 = default;
V BRASS_67 = default;
V HOOD27_68 = default;
V cardOf27_69 = default;
V N_70 = default;
V cam_71 = default;
V DEF11_72 = default;
V zsort_73 = default;
V lbox_74 = default;
V lcyl_75 = default;
V lsph_76 = default;
V DEF27_77 = default;
V lglow_78 = default;
V lring_79 = default;
V lswing_80 = default;
V lrot_81 = default;
V FLK27_82 = default;
V tube27_83 = default;
V front_84 = default;
V FLOOR27_85 = default;
V MEMO_86 = default;
V draw26_87 = default;
V WMEMO27_88 = default;
V edit26_89 = default;
if (_self1.IsNullish) _self1 = GlobalV;
fYlino_38 = Fn((V _self90, int _argc91, V _a93, V _a94, V _a95, V _a96, V[] _rest92) => {
V R_97 = default;
double NU_98 = 0;
double NV_99 = 0;
double gu_100 = 0;
double gy_101 = 0;
V T_102 = default;
V MISS_103 = default;
V CURL_104 = default;
V CRACK_105 = default;
JsStrBuf s_106 = null;
JsStrBuf hi_107 = null;
JsStrBuf lo_108 = null;
JsStrBuf mL_109 = null;
JsStrBuf mD_110 = null;
JsStrBuf ov_111 = null;
JsStrBuf cr_112 = null;
V miss_113 = default;
V curls_114 = default;
V path_115 = default;
if (_self90.IsNullish) _self90 = GlobalV;
R_97 = Call(rng_13, V.Undef, ((V)("ylino27")));
NU_98 = 12D;
NV_99 = 8D;
gu_100 = 0.0025;
gy_101 = 0.004;
T_102 = Arr(((V)("#e9c75e")), ((V)("#e3bd50")), ((V)("#efcd6a")), ((V)("#dcb348")), ((V)("#e6c25a")), ((V)("#f0d274")));
MISS_103 = ((V)("7,5"));
CURL_104 = NewObj(4).Put("10,7", ((V)(2D))).Put("2,3", ((V)(1D))).Put("5,0", ((V)(3D))).Put("0,6", ((V)(2D))).V;
CRACK_105 = Arr(((V)("3,6")), ((V)("8,2")), ((V)("9,5")), ((V)("1,1")), ((V)("6,4")), ((V)("11,3")));
s_106 = new JsStrBuf("<rect width=\"80\" height=\"56\" fill=\"#6a5124\"/>");
hi_107 = new JsStrBuf("");
lo_108 = new JsStrBuf("");
mL_109 = new JsStrBuf("");
mD_110 = new JsStrBuf("");
ov_111 = new JsStrBuf("");
cr_112 = new JsStrBuf("");
miss_113 = V.Null;
curls_114 = Arr();
{
double j_116 = 0;
j_116 = 0D;
while (true) {
if (!((j_116 < NV_99))) break;
{
double i_118 = 0;
i_118 = 0D;
while (true) {
if (!((i_118 < NU_98))) break;
V key_120 = default;
double u0_121 = 0;
double u1_122 = 0;
double y0_123 = 0;
double y1_124 = 0;
V col_125 = default;
double fl_126 = 0;
key_120 = ((V)(JsStrBuf.Begin().N(i_118).S(",").N(j_116).End()));
u0_121 = ((i_118 / NU_98) + gu_100);
u1_122 = (((i_118 + 1D) / NU_98) - gu_100);
y0_123 = ((j_116 / NV_99) + gy_101);
y1_124 = (((j_116 + 1D) / NV_99) - gy_101);
if (SEq(key_120, MISS_103)) {
miss_113 = Arr(((V)(u0_121)), ((V)(y0_123)), ((V)(u1_122)), ((V)(y1_124)));
goto _cont119;
}
col_125 = Call(shade_10, V.Undef, GetIdx(T_102, ((((i_118 * 5D) + (j_116 * 3D)) + ((double)(ToInt32((ToNum(Call(R_97, V.Undef)) * 4D)) | ToInt32(0D)))) % ToNum(Get(T_102, "length")))), ((V)((0.94 + (ToNum(Call(R_97, V.Undef)) * 0.09)))));
fl_126 = ((i_118 + j_116) % 2D);
s_106.S(string.Concat("<path d=\"", ToStr(Call(quadW_31, V.Undef, ((V)(u0_121)), ((V)(y0_123)), ((V)(u1_122)), ((V)(y1_124)))), "\" fill=\"", ToStr(col_125), "\"/>"));
{
double n_127 = 0;
n_127 = 0D;
while (true) {
if (!((n_127 < 4D))) break;
double a_129 = 0;
double b_130 = 0;
double ph_131 = 0;
V P_132 = default;
a_129 = (0.12 + (ToNum(Call(R_97, V.Undef)) * 0.76));
b_130 = (a_129 + ((ToNum(Call(R_97, V.Undef)) - 0.5) * 0.5));
ph_131 = (ToNum(Call(R_97, V.Undef)) * 6D);
P_132 = Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis140, int _argc133, V q_139, V _a136, V _a137, V _a138, V[] _rest134) => {
double t_141 = 0;
double m_142 = 0;
double tu_143 = 0;
double ty_144 = 0;
t_141 = (ToNum(q_139) / 5D);
m_142 = Min(0.95, Max(0.05, ((a_129 + ((b_130 - a_129) * t_141)) + (0.07 * FdLibm.Sin(((t_141 * 7D) + ph_131))))));
tu_143 = (NumTruthy(fl_126) ? m_142 : (0.04 + (t_141 * 0.92)));
ty_144 = (NumTruthy(fl_126) ? (0.04 + (t_141 * 0.92)) : m_142);
return Arr(((V)((u0_121 + ((u1_122 - u0_121) * tu_143)))), ((V)((y0_123 + ((y1_124 - y0_123) * ty_144)))));
return default;
}, 1, "", true));
if ((n_127 < 2D)) {
mL_109.V(Call(crvW_24, V.Undef, P_132));
} else {
mD_110.V(Call(crvW_24, V.Undef, P_132));
}
n_127++;
}
}
hi_107.V(Call(lineW_23, V.Undef, Arr(Arr(((V)(u0_121)), ((V)(y1_124))), Arr(((V)(u0_121)), ((V)(y0_123))), Arr(((V)(u1_122)), ((V)(y0_123))))));
lo_108.V(Call(lineW_23, V.Undef, Arr(Arr(((V)(u1_122)), ((V)(y0_123))), Arr(((V)(u1_122)), ((V)(y1_124))), Arr(((V)(u0_121)), ((V)(y1_124))))));
if (!GetK(CURL_104, key_120).IsNullish) {
Invoke(curls_114, "push", Arr(((V)(u0_121)), ((V)(y0_123)), ((V)(u1_122)), ((V)(y1_124)), GetK(CURL_104, key_120), col_125));
}
if (Truthy(Invoke(CRACK_105, "includes", key_120))) {
V P_145 = default;
V q_146 = default;
P_145 = Call(walk_36, V.Undef, R_97, ((V)((u0_121 + ((u1_122 - u0_121) * (0.2 + (ToNum(Call(R_97, V.Undef)) * 0.6)))))), ((V)(y0_123)), ((V)(((ToNum(Call(R_97, V.Undef)) - 0.5) * 0.006))), ((V)(((y1_124 - y0_123) / 5D))), ((V)(5D)), ((V)(0.012)));
SetIdx(GetIdx(P_145, (ToNum(Get(P_145, "length")) - 1D)), 1D, ((V)(y1_124)));
cr_112.S(string.Concat("<path d=\"", ToStr(Call(lineW_23, V.Undef, P_145)), "\" stroke=\"#fff0b8\" stroke-width=\"0.2\" fill=\"none\" stroke-linejoin=\"round\" opacity=\"0.8\" transform=\"translate(0.18 0.12)\"/><path d=\"", ToStr(Call(lineW_23, V.Undef, P_145)), "\" stroke=\"#4a3412\" stroke-width=\"0.3\" fill=\"none\" stroke-linejoin=\"round\"/>"));
if (LtN(Call(R_97, V.Undef), 0.6)) {
V q_147 = default;
q_147 = GetIdx(P_145, 2D);
cr_112.S(string.Concat("<path d=\"", ToStr(Call(chip_25, V.Undef, R_97, GetIdx(q_147, 0D), GetIdx(q_147, 1D), ((V)(0.45)), ((V)(5D)))), "\" fill=\"#2c2214\"/>"));
}
q_146 = GetIdx(P_145, 3D);
cr_112.S(string.Concat("<path d=\"", ToStr(Call(lineW_23, V.Undef, Call(walk_36, V.Undef, R_97, GetIdx(q_146, 0D), GetIdx(q_146, 1D), ((V)(((LtN(Call(R_97, V.Undef), 0.5) ? (-1D) : 1D) * 0.008))), ((V)(0.012)), ((V)(2D)), ((V)(0.008))))), "\" stroke=\"#4a3412\" stroke-width=\"0.18\" fill=\"none\"/>"));
}
_cont119: ;
i_118++;
}
}
j_116++;
}
}
s_106.S(string.Concat("<path d=\"", mL_109.Str, "\" stroke=\"#fbe49a\" stroke-width=\"0.5\" fill=\"none\" opacity=\"0.55\" stroke-linecap=\"round\"/><path d=\"", mD_110.Str, "\" stroke=\"#b88a28\" stroke-width=\"0.22\" fill=\"none\" opacity=\"0.5\" stroke-linecap=\"round\"/>"));
s_106.V(Invoke(Call(rep_18, V.Undef, ((V)(420D)), Fn((V _arrowThis154, int _argc148, V _a150, V _a151, V _a152, V _a153, V[] _rest149) => {
V u_155 = default;
V y_156 = default;
V p_157 = default;
u_155 = Call(R_97, V.Undef);
y_156 = Call(R_97, V.Undef);
p_157 = Call(W_21, V.Undef, u_155, y_156);
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_157, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_157, 1D))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)(((0.08 + (ToNum(Call(R_97, V.Undef)) * 0.14)) * ToNum(Call(K_29, V.Undef, y_156))))))), "\" fill=\"", (LtN(Call(R_97, V.Undef), 0.6) ? "#a9822c" : "#fff3c4"), "\" opacity=\"0.7\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
s_106.V(Call(fblot_20, V.Undef, ((V)("ylino")), ((V)(26D)), Arr(((V)("#f6dc80")), ((V)("#b8902e")), ((V)("#e0bb52"))), ((V)(0.35)), ((V)(6D))));
s_106.S(string.Concat("<path d=\"", hi_107.Str, "\" stroke=\"#fff0b0\" stroke-width=\"0.26\" fill=\"none\" opacity=\"0.75\"/><path d=\"", lo_108.Str, "\" stroke=\"#5e4518\" stroke-width=\"0.34\" fill=\"none\" opacity=\"0.75\"/>")).S(cr_112.Str);
s_106.S(string.Concat("<path d=\"", ToStr(TR_26), "\" fill=\"none\" stroke=\"#6e4e14\" stroke-width=\"8\" opacity=\"0.28\" filter=\"url(#fb3)\"/>"));
s_106.S("<g filter=\"url(#fb2)\">").V(Invoke(Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis164, int _argc158, V _a160, V _a161, V _a162, V _a163, V[] _rest159) => {
return Call(dot_32, V.Undef, ((V)((0.08 + (ToNum(Call(R_97, V.Undef)) * 0.28)))), ((V)((0.03 + (ToNum(Call(R_97, V.Undef)) * 0.22)))), ((V)((2D + (ToNum(Call(R_97, V.Undef)) * 3D)))), ((V)(string.Concat("fill=\"#8a5414\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.14 + (ToNum(Call(R_97, V.Undef)) * 0.12)))))), "\""))));
}, 0, "", true)), "join", ((V)("")))).S("</g>");
s_106.V(Invoke(Call(rep_18, V.Undef, ((V)(26D)), Fn((V _arrowThis171, int _argc165, V _a167, V _a168, V _a169, V _a170, V[] _rest166) => {
return Call(dot_32, V.Undef, ((V)((0.06 + (ToNum(Call(R_97, V.Undef)) * 0.34)))), ((V)((0.02 + (ToNum(Call(R_97, V.Undef)) * 0.3)))), ((V)((0.15 + (ToNum(Call(R_97, V.Undef)) * 0.35)))), ((V)(string.Concat("fill=\"#6e3e0c\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 + (ToNum(Call(R_97, V.Undef)) * 0.3)))))), "\""))));
}, 0, "", true)), "join", ((V)(""))));
s_106.V(Add(Call(dot_32, V.Undef, ((V)(0.3)), ((V)(0.2)), ((V)(2.3)), ((V)("fill=\"none\" stroke=\"#5a3410\" stroke-width=\"0.35\" opacity=\"0.45\""))), Call(dot_32, V.Undef, ((V)(0.3)), ((V)(0.2)), ((V)(2D)), ((V)("fill=\"none\" stroke=\"#5a3410\" stroke-width=\"0.18\" opacity=\"0.3\"")))));
path_115 = Call(crvW_24, V.Undef, Arr(Arr(((V)(0.46)), ((V)(1.08))), Arr(((V)(0.5)), ((V)(0.75))), Arr(((V)(0.56)), ((V)(0.45))), Arr(((V)(0.6)), ((V)(0.15))), Arr(((V)(0.6)), ((V)((-0.05))))));
s_106.S(string.Concat("<g filter=\"url(#fb3)\"><path d=\"", ToStr(path_115), "\" stroke=\"#8a6a22\" stroke-width=\"15\" fill=\"none\" opacity=\"0.14\"/><path d=\"", ToStr(path_115), "\" stroke=\"#fff4c8\" stroke-width=\"8\" fill=\"none\" opacity=\"0.32\"/></g>")).V(Call(heel_37, V.Undef, R_97, ((V)(18D)), ((V)(0.35)), ((V)(0.68))));
if (Truthy(miss_113)) {
V u0_172 = default;
V y0_173 = default;
V u1_174 = default;
V y1_175 = default;
JsStrBuf tw_176 = null;
{ V _t177 = miss_113;
{ V _t178 = ListOf(_t177);
{ V _t179 = GetIdx(_t178, 0D);
u0_172 = _t179; }
{ V _t180 = GetIdx(_t178, 1D);
y0_173 = _t180; }
{ V _t181 = GetIdx(_t178, 2D);
u1_174 = _t181; }
{ V _t182 = GetIdx(_t178, 3D);
y1_175 = _t182; }
} }
tw_176 = new JsStrBuf("");
{
V n_183 = default;
n_183 = ((V)(0D));
while (true) {
V n_183_it = n_183;
if (!(LtN(n_183_it, 7D))) break;
V yy_185 = default;
yy_185 = Add(y0_173, ((V)((((ToNum(y1_175) - ToNum(y0_173)) * ToNum(Add(n_183_it, ((V)(0.5))))) / 7D))));
tw_176.V(Call(crvW_24, V.Undef, Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis193, int _argc186, V q_192, V _a189, V _a190, V _a191, V[] _rest187) => {
return Arr(Add(u0_172, ((V)((((ToNum(u1_174) - ToNum(u0_172)) * ToNum(q_192)) / 5D)))), Add(yy_185, ((V)((0.006 * FdLibm.Sin(ToNum(Add(((V)((ToNum(q_192) * 1.3))), n_183_it))))))));
}, 1, "", true))));
n_183 = n_183_it;
PostInc(ref n_183, 1D);
}
}
ov_111.S(string.Concat("<path d=\"", ToStr(Call(quadW_31, V.Undef, ((V)((ToNum(u0_172) - gu_100))), ((V)((ToNum(y0_173) - gy_101))), Add(u1_174, ((V)(gu_100))), Add(y1_175, ((V)(gy_101))))), "\" fill=\"#241b10\"/><path d=\"", tw_176.Str, "\" stroke=\"#4a3a22\" stroke-width=\"0.4\" fill=\"none\"/><path d=\"", tw_176.Str, "\" stroke=\"#6a5634\" stroke-width=\"0.12\" fill=\"none\" transform=\"translate(0 -0.2)\"/>"));
ov_111.V(Invoke(Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis200, int _argc194, V _a196, V _a197, V _a198, V _a199, V[] _rest195) => {
V e_201 = default;
double side_202 = 0;
V u_203 = default;
V y_204 = default;
e_201 = Call(R_97, V.Undef);
side_202 = ((double)(ToInt32((ToNum(Call(R_97, V.Undef)) * 4D)) | ToInt32(0D)));
u_203 = ((side_202 == 0D) ? Add(u0_172, ((V)(0.004))) : ((side_202 == 1D) ? ((V)((ToNum(u1_174) - 0.004))) : Add(u0_172, ((V)(((ToNum(u1_174) - ToNum(u0_172)) * ToNum(e_201)))))));
y_204 = ((side_202 == 2D) ? Add(y0_173, ((V)(0.006))) : ((side_202 == 3D) ? ((V)((ToNum(y1_175) - 0.006))) : Add(y0_173, ((V)(((ToNum(y1_175) - ToNum(y0_173)) * ToNum(e_201)))))));
return ((V)(string.Concat("<path d=\"", ToStr(Call(chip_25, V.Undef, R_97, u_203, y_204, ((V)((0.6 + (ToNum(Call(R_97, V.Undef)) * 0.5)))), ((V)(6D)))), "\" fill=\"", ToStr(GetIdx(T_102, ((double)(ToInt32((ToNum(Call(R_97, V.Undef)) * 6D)) | ToInt32(0D))))), "\" stroke=\"#fff0b8\" stroke-width=\"0.12\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
ov_111.V(Invoke(Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis211, int _argc205, V _a207, V _a208, V _a209, V _a210, V[] _rest206) => {
return Call(dot_32, V.Undef, Add(u0_172, ((V)(((ToNum(u1_174) - ToNum(u0_172)) * ToNum(Call(R_97, V.Undef)))))), Add(y0_173, ((V)(((ToNum(y1_175) - ToNum(y0_173)) * ToNum(Call(R_97, V.Undef)))))), ((V)((0.12 + (ToNum(Call(R_97, V.Undef)) * 0.16)))), ((V)(string.Concat("fill=\"", (LtN(Call(R_97, V.Undef), 0.5) ? "#9a8a6a" : "#e8c460"), "\""))));
}, 0, "", true)), "join", ((V)(""))));
ov_111.S(string.Concat("<path d=\"", ToStr(Call(lineW_23, V.Undef, Arr(Arr(((V)((ToNum(u0_172) - gu_100))), Add(y1_175, ((V)(gy_101)))), Arr(((V)((ToNum(u0_172) - gu_100))), ((V)((ToNum(y0_173) - gy_101)))), Arr(Add(u1_174, ((V)(gu_100))), ((V)((ToNum(y0_173) - gy_101))))))), "\" stroke=\"#000000\" stroke-width=\"0.5\" fill=\"none\" opacity=\"0.4\"/>"));
}
Invoke(curls_114, "forEach", Fn((V _arrowThis231, int _argc212, V _a214, V _a215, V _a216, V _a217, V[] _rest213) => {
double cu_232 = 0;
double cy_233 = 0;
double sx_234 = 0;
double sy_235 = 0;
V tu_236 = default;
V ty_237 = default;
V A_238 = default;
V B_239 = default;
V Pa_240 = default;
V Pb_241 = default;
V Pt_242 = default;
V k_243 = default;
V T2_244 = default;
V lerp_245 = default;
V c1_246 = default;
V c2_247 = default;
V fl_248 = default;
V t1_249 = default;
V t2_250 = default;
V u0_220 = default;
V y0_222 = default;
V u1_224 = default;
V y1_226 = default;
V c_228 = default;
V col_230 = default;
{ V _t218 = ListOf(_a214);
{ V _t219 = GetIdx(_t218, 0D);
u0_220 = _t219; }
{ V _t221 = GetIdx(_t218, 1D);
y0_222 = _t221; }
{ V _t223 = GetIdx(_t218, 2D);
u1_224 = _t223; }
{ V _t225 = GetIdx(_t218, 3D);
y1_226 = _t225; }
{ V _t227 = GetIdx(_t218, 4D);
c_228 = _t227; }
{ V _t229 = GetIdx(_t218, 5D);
col_230 = _t229; }
}
cu_232 = ((ToNum(u1_224) - ToNum(u0_220)) * 0.55);
cy_233 = ((ToNum(y1_226) - ToNum(y0_222)) * 0.55);
sx_234 = ((SEqN(c_228, 1D) || SEqN(c_228, 2D)) ? (-1D) : 1D);
sy_235 = (GeN(c_228, 2D) ? (-1D) : 1D);
tu_236 = ((sx_234 < 0D) ? u1_224 : u0_220);
ty_237 = ((sy_235 < 0D) ? y1_226 : y0_222);
A_238 = Arr(Add(tu_236, ((V)((sx_234 * cu_232)))), ty_237);
B_239 = Arr(tu_236, Add(ty_237, ((V)((sy_235 * cy_233)))));
Pa_240 = CallSpread(W_21, V.Undef, new ArrBuilder().Spread(A_238).V);
Pb_241 = CallSpread(W_21, V.Undef, new ArrBuilder().Spread(B_239).V);
Pt_242 = Call(W_21, V.Undef, tu_236, ty_237);
k_243 = Call(K_29, V.Undef, ty_237);
T2_244 = Arr(Add(GetIdx(Pt_242, 0D), ((V)(((sx_234 * 0.9) * ToNum(k_243))))), ((V)((ToNum(GetIdx(Pt_242, 1D)) - (3.4 * ToNum(k_243))))));
lerp_245 = Fn((V _arrowThis260, int _argc251, V p_257, V q_258, V t_259, V _a256, V[] _rest252) => {
return Arr(Add(GetIdx(p_257, 0D), ((V)(((ToNum(GetIdx(q_258, 0D)) - ToNum(GetIdx(p_257, 0D))) * ToNum(t_259))))), Add(GetIdx(p_257, 1D), ((V)(((ToNum(GetIdx(q_258, 1D)) - ToNum(GetIdx(p_257, 1D))) * ToNum(t_259))))));
}, 3, "", true);
ov_111.S(string.Concat("<path d=\"", ToStr(Call(polyW_22, V.Undef, Arr(A_238, Arr(tu_236, ty_237), B_239))), "\" fill=\"#2a2012\"/>")).V(Invoke(Invoke(Arr(((V)(0.3)), ((V)(0.55)), ((V)(0.8))), "map", Fn((V _arrowThis268, int _argc261, V t_267, V _a264, V _a265, V _a266, V[] _rest262) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(pt_30, V.Undef, Call(lerp_245, V.Undef, Pa_240, Pt_242, t_267))), "L", ToStr(Call(pt_30, V.Undef, Call(lerp_245, V.Undef, Pb_241, Pt_242, t_267))), "\" stroke=\"#4e3c20\" stroke-width=\"0.22\"/>")));
}, 1, "", true)), "join", ((V)(""))));
ov_111.S(string.Concat("<path d=\"M", ToStr(Call(pt_30, V.Undef, Pa_240)), "L", ToStr(Call(f1_16, V.Undef, Add(GetIdx(Pt_242, 0D), ((V)(((sx_234 * 0.4) * ToNum(k_243))))))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(Pt_242, 1D), ((V)((0.4 * ToNum(k_243))))))), "L", ToStr(Call(pt_30, V.Undef, Pb_241)), "Z\" fill=\"#000000\" opacity=\"0.4\" filter=\"url(#fb1)\"/>"));
c1_246 = Call(lerp_245, V.Undef, Pa_240, T2_244, ((V)(0.5)));
c2_247 = Call(lerp_245, V.Undef, Pb_241, T2_244, ((V)(0.5)));
fl_248 = ((V)(string.Concat("M", ToStr(Call(pt_30, V.Undef, Pa_240)), "Q", ToStr(Call(f1_16, V.Undef, GetIdx(c1_246, 0D))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(c1_246, 1D), ((V)((0.5 * ToNum(k_243))))))), " ", ToStr(Call(pt_30, V.Undef, T2_244)), "Q", ToStr(Call(f1_16, V.Undef, GetIdx(c2_247, 0D))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(c2_247, 1D), ((V)((0.5 * ToNum(k_243))))))), " ", ToStr(Call(pt_30, V.Undef, Pb_241)), "Z")));
ov_111.S(string.Concat("<path d=\"", ToStr(fl_248), "\" fill=\"#8a6a2a\" transform=\"translate(0 0.35)\"/><path d=\"", ToStr(fl_248), "\" fill=\"", ToStr(Call(shade_10, V.Undef, col_230, ((V)(1.07)))), "\"/>"));
t1_249 = Call(lerp_245, V.Undef, T2_244, c1_246, ((V)(0.35)));
t2_250 = Call(lerp_245, V.Undef, T2_244, c2_247, ((V)(0.35)));
ov_111.S(string.Concat("<path d=\"M", ToStr(Call(pt_30, V.Undef, T2_244)), "L", ToStr(Call(pt_30, V.Undef, t1_249)), "Q", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Add(GetIdx(t1_249, 0D), GetIdx(t2_250, 0D))) / 2D))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(Add(GetIdx(t1_249, 1D), GetIdx(t2_250, 1D))) / 2D) - (0.5 * ToNum(k_243))))))), " ", ToStr(Call(pt_30, V.Undef, t2_250)), "Z\" fill=\"#8c867a\"/><path d=\"M", ToStr(Call(pt_30, V.Undef, Pa_240)), "Q", ToStr(Call(f1_16, V.Undef, GetIdx(c1_246, 0D))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(c1_246, 1D), ((V)((0.5 * ToNum(k_243))))))), " ", ToStr(Call(pt_30, V.Undef, T2_244)), "\" stroke=\"#fff4c8\" stroke-width=\"0.2\" fill=\"none\" opacity=\"0.8\"/>"));
return default;
}, 1, "", true));
return Call(FL_19, V.Undef, ((V)(string.Concat(s_106.Str, ov_111.Str))));
return default;
}, 0, "fYlino", false);
fDiner_39 = Fn((V _self269, int _argc270, V _a272, V _a273, V _a274, V _a275, V[] _rest271) => {
V R_276 = default;
double NU_277 = 0;
double NV_278 = 0;
double bu_279 = 0;
double by_280 = 0;
double ua_281 = 0;
double ub_282 = 0;
double ya_283 = 0;
V WT_284 = default;
V BK_285 = default;
double cu_286 = 0;
double cy_287 = 0;
JsStrBuf wh_288 = null;
JsStrBuf bk_289 = null;
JsStrBuf sw_290 = null;
JsStrBuf sb_291 = null;
JsStrBuf hi_292 = null;
JsStrBuf lo_293 = null;
JsStrBuf sc_294 = null;
JsStrBuf s_295 = null;
V RD1_296 = default;
V band_297 = default;
V trim_298 = default;
if (_self269.IsNullish) _self269 = GlobalV;
R_276 = Call(rng_13, V.Undef, ((V)("diner27")));
NU_277 = 12D;
NV_278 = 8D;
bu_279 = 0.032;
by_280 = 0.05;
ua_281 = (bu_279 + 0.008);
ub_282 = ((1D - bu_279) - 0.008);
ya_283 = (by_280 + 0.012);
WT_284 = Arr(((V)("#f4f1e9")), ((V)("#efebe1")), ((V)("#f7f5ef")), ((V)("#ebe6db")));
BK_285 = Arr(((V)("#1d1d21")), ((V)("#232328")), ((V)("#18181b")), ((V)("#28282d")));
cu_286 = ((ub_282 - ua_281) / NU_277);
cy_287 = ((1.03 - ya_283) / NV_278);
wh_288 = new JsStrBuf("");
bk_289 = new JsStrBuf("");
sw_290 = new JsStrBuf("");
sb_291 = new JsStrBuf("");
hi_292 = new JsStrBuf("");
lo_293 = new JsStrBuf("");
sc_294 = new JsStrBuf("");
s_295 = new JsStrBuf(string.Concat("<defs><clipPath id=\"d27f\"><path d=\"", ToStr(Call(quadW_31, V.Undef, ((V)(ua_281)), ((V)(ya_283)), ((V)(ub_282)), ((V)(1.06)))), "\"/></clipPath></defs><rect width=\"80\" height=\"56\" fill=\"#9a958c\"/>"));
{
double j_299 = 0;
j_299 = 0D;
while (true) {
if (!((j_299 < NV_278))) break;
{
double i_301 = 0;
i_301 = 0D;
while (true) {
if (!((i_301 < NU_277))) break;
double u0_303 = 0;
double u1_304 = 0;
double y0_305 = 0;
double y1_306 = 0;
V w_307 = default;
u0_303 = ((ua_281 + (i_301 * cu_286)) + 0.0015);
u1_304 = ((ua_281 + ((i_301 + 1D) * cu_286)) - 0.0015);
y0_305 = ((ya_283 + (j_299 * cy_287)) + 0.0022);
y1_306 = ((ya_283 + ((j_299 + 1D) * cy_287)) - 0.0022);
w_307 = ((((i_301 + j_299) % 2D) == 0D) ? V.True : V.False);
s_295.S(string.Concat("<path d=\"", ToStr(Call(quadW_31, V.Undef, ((V)(u0_303)), ((V)(y0_305)), ((V)(u1_304)), ((V)(y1_306)))), "\" fill=\"", ToStr((Truthy(w_307) ? Call(shade_10, V.Undef, GetIdx(WT_284, ((double)(ToInt32((ToNum(Call(R_276, V.Undef)) * 4D)) | ToInt32(0D)))), ((V)((0.98 + (ToNum(Call(R_276, V.Undef)) * 0.03))))) : GetIdx(BK_285, ((double)(ToInt32((ToNum(Call(R_276, V.Undef)) * 4D)) | ToInt32(0D)))))), "\"/>"));
{
double n_308 = 0;
n_308 = 0D;
while (true) {
if (!((n_308 < (Truthy(w_307) ? 14D : 8D)))) break;
double u_310 = 0;
double y_311 = 0;
V d_312 = default;
u_310 = (u0_303 + ((u1_304 - u0_303) * (0.06 + (ToNum(Call(R_276, V.Undef)) * 0.88))));
y_311 = (y0_305 + ((y1_306 - y0_305) * (0.06 + (ToNum(Call(R_276, V.Undef)) * 0.88))));
d_312 = Call(dotD_33, V.Undef, ((V)(u_310)), ((V)(y_311)), ((V)((0.08 + (ToNum(Call(R_276, V.Undef)) * 0.12)))));
if (Truthy(w_307)) {
if (LtN(Call(R_276, V.Undef), 0.7)) {
wh_288.V(d_312);
} else {
bk_289.V(d_312);
}
} else {
if (LtN(Call(R_276, V.Undef), 0.7)) {
sw_290.V(d_312);
} else {
sb_291.V(d_312);
}
}
n_308++;
}
}
hi_292.V(Call(lineW_23, V.Undef, Arr(Arr(((V)(u0_303)), ((V)(y1_306))), Arr(((V)(u0_303)), ((V)(y0_305))), Arr(((V)(u1_304)), ((V)(y0_305))))));
lo_293.V(Call(lineW_23, V.Undef, Arr(Arr(((V)(u1_304)), ((V)(y0_305))), Arr(((V)(u1_304)), ((V)(y1_306))), Arr(((V)(u0_303)), ((V)(y1_306))))));
if ((!(Truthy(w_307)) && LtN(Call(R_276, V.Undef), 0.35))) {
double u_313 = 0;
double y_314 = 0;
V p_315 = default;
V k_316 = default;
double l_317 = 0;
u_313 = (u0_303 + ((u1_304 - u0_303) * (0.2 + (ToNum(Call(R_276, V.Undef)) * 0.5))));
y_314 = (y0_305 + ((y1_306 - y0_305) * (0.2 + (ToNum(Call(R_276, V.Undef)) * 0.6))));
p_315 = Call(W_21, V.Undef, ((V)(u_313)), ((V)(y_314)));
k_316 = Call(K_29, V.Undef, ((V)(y_314)));
l_317 = ((1D + (ToNum(Call(R_276, V.Undef)) * 1.6)) * ToNum(k_316));
sc_294.S(string.Concat("<path d=\"M", ToStr(Call(pt_30, V.Undef, p_315)), "q", ToStr(Call(f1_16, V.Undef, ((V)((l_317 * 0.5))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.5) * ToNum(k_316)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(l_317)))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(Call(R_276, V.Undef)) - 0.5) * ToNum(k_316)))))), "\" stroke=\"#8a8a90\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.12 * ToNum(k_316)))))), "\" fill=\"none\" opacity=\"0.5\"/>"));
}
i_301++;
}
}
j_299++;
}
}
s_295.S(string.Concat("<g clip-path=\"url(#d27f)\"><path d=\"", wh_288.Str, "\" fill=\"#c9c2b2\"/><path d=\"", bk_289.Str, "\" fill=\"#8f897c\"/><path d=\"", sw_290.Str, "\" fill=\"#3e3e45\"/><path d=\"", sb_291.Str, "\" fill=\"#55555c\"/>")).S(string.Concat("<path d=\"", hi_292.Str, "\" stroke=\"#ffffff\" stroke-width=\"0.22\" fill=\"none\" opacity=\"0.45\"/><path d=\"", lo_293.Str, "\" stroke=\"#000000\" stroke-width=\"0.22\" fill=\"none\" opacity=\"0.35\"/>", sc_294.Str, "</g>"));
RD1_296 = ((V)("#c42d36"));
band_297 = Arr(Arr(Arr(((V)(0D)), ((V)((-0.03)))), Arr(((V)(1D)), ((V)((-0.03)))), Arr(((V)((1D - bu_279))), ((V)(by_280))), Arr(((V)(bu_279)), ((V)(by_280)))), Arr(Arr(((V)(0D)), ((V)((-0.03)))), Arr(((V)(bu_279)), ((V)(by_280))), Arr(((V)(bu_279)), ((V)(1.06))), Arr(((V)(0D)), ((V)(1.06)))), Arr(Arr(((V)(1D)), ((V)((-0.03)))), Arr(((V)(1D)), ((V)(1.06))), Arr(((V)((1D - bu_279))), ((V)(1.06))), Arr(((V)((1D - bu_279))), ((V)(by_280)))));
s_295.V(Add(Invoke(Invoke(band_297, "map", Fn((V _arrowThis325, int _argc318, V P_324, V _a321, V _a322, V _a323, V[] _rest319) => {
return ((V)(string.Concat("<path d=\"", ToStr(Call(polyW_22, V.Undef, P_324)), "\" fill=\"", ToStr(RD1_296), "\"/>")));
}, 1, "", true)), "join", ((V)(""))), Invoke(Call(rep_18, V.Undef, ((V)(140D)), Fn((V _arrowThis332, int _argc326, V _a328, V _a329, V _a330, V _a331, V[] _rest327) => {
double side_333 = 0;
double y_334 = 0;
V u_335 = default;
side_333 = ((double)(ToInt32((ToNum(Call(R_276, V.Undef)) * 3D)) | ToInt32(0D)));
y_334 = (NumTruthy(side_333) ? (ToNum(Call(R_276, V.Undef)) * 1.05) : ((-0.02) + (ToNum(Call(R_276, V.Undef)) * (by_280 + 0.01))));
u_335 = ((side_333 == 1D) ? ((V)((ToNum(Call(R_276, V.Undef)) * bu_279))) : ((side_333 == 2D) ? ((V)((1D - (ToNum(Call(R_276, V.Undef)) * bu_279)))) : Call(R_276, V.Undef)));
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(Call(W_21, V.Undef, u_335, ((V)(y_334))), 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(Call(W_21, V.Undef, u_335, ((V)(y_334))), 1D))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.1 * ToNum(Call(K_29, V.Undef, ((V)(y_334))))))))), "\" fill=\"#e86a70\" opacity=\"0.6\"/>")));
return default;
}, 0, "", true)), "join", ((V)("")))));
trim_298 = Call(lineW_23, V.Undef, Arr(Arr(((V)((ua_281 - 0.004))), ((V)(1.06))), Arr(((V)((ua_281 - 0.004))), ((V)((ya_283 - 0.006)))), Arr(((V)((ub_282 + 0.004))), ((V)((ya_283 - 0.006)))), Arr(((V)((ub_282 + 0.004))), ((V)(1.06)))));
s_295.S(string.Concat("<path d=\"", ToStr(trim_298), "\" stroke=\"#55585e\" stroke-width=\"0.95\" fill=\"none\" stroke-linejoin=\"miter\"/><path d=\"", ToStr(trim_298), "\" stroke=\"#d7dbe0\" stroke-width=\"0.6\" fill=\"none\"/><path d=\"", ToStr(trim_298), "\" stroke=\"#ffffff\" stroke-width=\"0.18\" fill=\"none\" transform=\"translate(-0.1 -0.12)\"/>"));
s_295.S(string.Concat("<path d=\"", ToStr(Call(lineW_23, V.Undef, Arr(Arr(((V)(0D)), ((V)((-0.03)))), Arr(((V)(bu_279)), ((V)(by_280)))))), "M", ToStr(Call(pt_30, V.Undef, Call(W_21, V.Undef, ((V)(1D)), ((V)((-0.03)))))), "L", ToStr(Call(pt_30, V.Undef, Call(W_21, V.Undef, ((V)((1D - bu_279))), ((V)(by_280))))), "\" stroke=\"#8a1c24\" stroke-width=\"0.2\"/>"));
s_295.V(Add(Add(Add(Call(heel_37, V.Undef, R_276, ((V)(22D)), ((V)(0.25)), ((V)(0.75))), Call(fblot_20, V.Undef, ((V)("diner")), ((V)(10D)), Arr(((V)("#ffffff")), ((V)("#cfcac0"))), ((V)(0.12)), ((V)(9D)))), Call(refl_35, V.Undef, ((V)(0.36)))), Call(refl_35, V.Undef, ((V)(0.12)), ((V)("#ff9aa0")))));
return Call(FL_19, V.Undef, ((V)(s_295.Str)));
return default;
}, 0, "fDiner", false);
fQuarry_40 = Fn((V _self336, int _argc337, V _a339, V _a340, V _a341, V _a342, V[] _rest338) => {
V R_343 = default;
double NU_344 = 0;
double NV_345 = 0;
double gu_346 = 0;
double gy_347 = 0;
V TC_348 = default;
JsStrBuf s_349 = null;
JsStrBuf tiles_350 = null;
JsStrBuf fx_351 = null;
JsStrBuf hi_352 = null;
JsStrBuf lo_353 = null;
V pits_354 = default;
V paw_355 = default;
if (_self336.IsNullish) _self336 = GlobalV;
R_343 = Call(rng_13, V.Undef, ((V)("quarry27")));
NU_344 = 15D;
NV_345 = 10D;
gu_346 = 0.0055;
gy_347 = 0.0085;
TC_348 = Arr(((V)("#b85a34")), ((V)("#c4663c")), ((V)("#a94f2e")), ((V)("#cf7448")), ((V)("#b9603a")), ((V)("#9e4a2c")), ((V)("#c86d40")), ((V)("#d27c52")));
s_349 = new JsStrBuf(string.Concat("<defs><radialGradient id=\"q27f\"><stop offset=\"0\" stop-color=\"#5a2410\" stop-opacity=\"0.38\"/><stop offset=\"1\" stop-color=\"#5a2410\" stop-opacity=\"0\"/></radialGradient><radialGradient id=\"q27l\"><stop offset=\"0\" stop-color=\"#ffc08a\" stop-opacity=\"0.35\"/><stop offset=\"1\" stop-color=\"#ffc08a\" stop-opacity=\"0\"/></radialGradient></defs><rect width=\"80\" height=\"56\" fill=\"#d6bc94\"/>", ""));
s_349.V(Invoke(Call(rep_18, V.Undef, ((V)(500D)), Fn((V _arrowThis362, int _argc356, V _a358, V _a359, V _a360, V _a361, V[] _rest357) => {
V u_363 = default;
V y_364 = default;
V p_365 = default;
u_363 = Call(R_343, V.Undef);
y_364 = Call(R_343, V.Undef);
p_365 = Call(W_21, V.Undef, u_363, y_364);
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_365, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_365, 1D))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.1 * ToNum(Call(K_29, V.Undef, y_364))))))), "\" fill=\"", (LtN(Call(R_343, V.Undef), 0.5) ? "#b89a70" : "#efdcbc"), "\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
tiles_350 = new JsStrBuf("");
fx_351 = new JsStrBuf("");
hi_352 = new JsStrBuf("");
lo_353 = new JsStrBuf("");
pits_354 = Arr(((V)("")), ((V)("")));
{
double j_366 = 0;
j_366 = 0D;
while (true) {
if (!((j_366 < NV_345))) break;
{
double i_368 = 0;
i_368 = 0D;
while (true) {
if (!((i_368 < NU_344))) break;
double u0_370 = 0;
double u1_371 = 0;
double y0_372 = 0;
double y1_373 = 0;
double ju_374 = 0;
double jy_375 = 0;
V J_376 = default;
V P_377 = default;
V col_378 = default;
double fu_379 = 0;
double fy_380 = 0;
V pf_381 = default;
V k_382 = default;
u0_370 = ((i_368 / NU_344) + gu_346);
u1_371 = (((i_368 + 1D) / NU_344) - gu_346);
y0_372 = ((j_366 / NV_345) + gy_347);
y1_373 = (((j_366 + 1D) / NV_345) - gy_347);
ju_374 = (gu_346 * 0.45);
jy_375 = (gy_347 * 0.45);
J_376 = Fn((V _arrowThis389, int _argc383, V _a385, V _a386, V _a387, V _a388, V[] _rest384) => {
return ((V)(((ToNum(Call(R_343, V.Undef)) - 0.5) * 2D)));
}, 0, "", true);
P_377 = Arr(Arr(((V)((u0_370 + (ToNum(Call(J_376, V.Undef)) * ju_374)))), ((V)((y0_372 + (ToNum(Call(J_376, V.Undef)) * jy_375))))), Arr(((V)((((u0_370 + u1_371) / 2D) + (ToNum(Call(J_376, V.Undef)) * ju_374)))), ((V)((y0_372 + ((ToNum(Call(J_376, V.Undef)) * jy_375) * 0.7))))), Arr(((V)((u1_371 + (ToNum(Call(J_376, V.Undef)) * ju_374)))), ((V)((y0_372 + (ToNum(Call(J_376, V.Undef)) * jy_375))))), Arr(((V)((u1_371 + ((ToNum(Call(J_376, V.Undef)) * ju_374) * 0.7)))), ((V)((((y0_372 + y1_373) / 2D) + (ToNum(Call(J_376, V.Undef)) * jy_375))))), Arr(((V)((u1_371 + (ToNum(Call(J_376, V.Undef)) * ju_374)))), ((V)((y1_373 + (ToNum(Call(J_376, V.Undef)) * jy_375))))), Arr(((V)((((u0_370 + u1_371) / 2D) + (ToNum(Call(J_376, V.Undef)) * ju_374)))), ((V)((y1_373 + ((ToNum(Call(J_376, V.Undef)) * jy_375) * 0.7))))), Arr(((V)((u0_370 + (ToNum(Call(J_376, V.Undef)) * ju_374)))), ((V)((y1_373 + (ToNum(Call(J_376, V.Undef)) * jy_375))))), Arr(((V)((u0_370 + ((ToNum(Call(J_376, V.Undef)) * ju_374) * 0.7)))), ((V)((((y0_372 + y1_373) / 2D) + (ToNum(Call(J_376, V.Undef)) * jy_375))))));
col_378 = Call(shade_10, V.Undef, GetIdx(TC_348, ((double)(ToInt32((ToNum(Call(R_343, V.Undef)) * ToNum(Get(TC_348, "length")))) | ToInt32(0D)))), ((V)((0.93 + (ToNum(Call(R_343, V.Undef)) * 0.12)))));
tiles_350.S(string.Concat("<path d=\"", ToStr(Call(polyW_22, V.Undef, P_377)), "\" fill=\"", ToStr(col_378), "\"/>"));
hi_352.V(Call(lineW_23, V.Undef, Arr(GetIdx(P_377, 6D), GetIdx(P_377, 7D), GetIdx(P_377, 0D), GetIdx(P_377, 1D), GetIdx(P_377, 2D))));
lo_353.V(Call(lineW_23, V.Undef, Arr(GetIdx(P_377, 2D), GetIdx(P_377, 3D), GetIdx(P_377, 4D), GetIdx(P_377, 5D), GetIdx(P_377, 6D))));
fu_379 = (u0_370 + ((u1_371 - u0_370) * (LtN(Call(R_343, V.Undef), 0.5) ? 0.25 : 0.75)));
fy_380 = (y0_372 + ((y1_373 - y0_372) * (LtN(Call(R_343, V.Undef), 0.5) ? 0.25 : 0.75)));
pf_381 = Call(W_21, V.Undef, ((V)(fu_379)), ((V)(fy_380)));
k_382 = Call(K_29, V.Undef, ((V)(fy_380)));
fx_351.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(pf_381, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(pf_381, 1D))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.4 * ToNum(k_382)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.9 * ToNum(k_382)))))), "\" fill=\"url(#q27f)\"/>"));
if (LtN(Call(R_343, V.Undef), 0.4)) {
V pl_390 = default;
pl_390 = Call(W_21, V.Undef, ((V)((u0_370 + ((u1_371 - u0_370) * (0.3 + (ToNum(Call(R_343, V.Undef)) * 0.4)))))), ((V)((y0_372 + ((y1_373 - y0_372) * (0.3 + (ToNum(Call(R_343, V.Undef)) * 0.4)))))));
fx_351.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(pl_390, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(pl_390, 1D))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.2 * ToNum(k_382)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.7 * ToNum(k_382)))))), "\" fill=\"url(#q27l)\"/>"));
}
{
double n_391 = 0;
n_391 = 0D;
while (true) {
if (!((n_391 < 4D))) break;
OpSetK(pits_354, ((V)((n_391 % 2D))), 0, Call(dotD_33, V.Undef, ((V)((u0_370 + ((u1_371 - u0_370) * (0.1 + (ToNum(Call(R_343, V.Undef)) * 0.8)))))), ((V)((y0_372 + ((y1_373 - y0_372) * (0.1 + (ToNum(Call(R_343, V.Undef)) * 0.8)))))), ((V)((0.07 + (ToNum(Call(R_343, V.Undef)) * 0.09))))));
n_391++;
}
}
i_368++;
}
}
j_366++;
}
}
s_349.S(tiles_350.Str).S(fx_351.Str).S(string.Concat("<path d=\"", ToStr(GetIdx(pits_354, 0D)), "\" fill=\"#5a2612\" opacity=\"0.6\"/><path d=\"", ToStr(GetIdx(pits_354, 1D)), "\" fill=\"#f6dcc0\" opacity=\"0.5\"/>"));
s_349.S(string.Concat("<path d=\"", hi_352.Str, "\" stroke=\"#f0a070\" stroke-width=\"0.26\" fill=\"none\" opacity=\"0.6\" stroke-linejoin=\"round\"/><path d=\"", lo_353.Str, "\" stroke=\"#6a2a12\" stroke-width=\"0.32\" fill=\"none\" opacity=\"0.55\" stroke-linejoin=\"round\"/>"));
s_349.S("<g filter=\"url(#fb1)\">").V(Invoke(Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis399, int _argc393, V _a395, V _a396, V _a397, V _a398, V[] _rest394) => {
return Call(dot_32, V.Undef, Call(R_343, V.Undef), ((V)((0.1 + (ToNum(Call(R_343, V.Undef)) * 0.9)))), ((V)((0.5 + (ToNum(Call(R_343, V.Undef)) * 0.9)))), ((V)(string.Concat("fill=\"#f4e6d4\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.18 + (ToNum(Call(R_343, V.Undef)) * 0.15)))))), "\""))));
}, 0, "", true)), "join", ((V)("")))).S("</g>");
paw_355 = Fn((V _arrowThis409, int _argc400, V u_406, V y_407, V a_408, V _a405, V[] _rest401) => {
V p_410 = default;
double k_411 = 0;
double sq_412 = 0;
p_410 = Call(W_21, V.Undef, u_406, y_407);
k_411 = (ToNum(Call(K_29, V.Undef, y_407)) * 1.35);
sq_412 = 0.62;
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(pt_30, V.Undef, p_410)), ") scale(", ToStr(Call(n4_17, V.Undef, ((V)(k_411)))), " ", ToStr(Call(n4_17, V.Undef, ((V)((k_411 * sq_412))))), ") rotate(", ToStr(a_408), ")\" fill=\"#6a2810\" opacity=\"0.78\"><ellipse cx=\"0\" cy=\"0.5\" rx=\"0.9\" ry=\"0.75\"/><ellipse cx=\"-1\" cy=\"-0.6\" rx=\"0.32\" ry=\"0.42\"/><ellipse cx=\"-0.36\" cy=\"-1.05\" rx=\"0.32\" ry=\"0.42\"/><ellipse cx=\"0.36\" cy=\"-1.05\" rx=\"0.32\" ry=\"0.42\"/><ellipse cx=\"1\" cy=\"-0.6\" rx=\"0.32\" ry=\"0.42\"/></g>")));
return default;
}, 3, "", true);
s_349.V(Add(Add(Call(paw_355, V.Undef, ((V)(0.62)), ((V)(0.55)), ((V)(20D))), Call(paw_355, V.Undef, ((V)(0.67)), ((V)(0.42)), ((V)(30D)))), Call(paw_355, V.Undef, ((V)(0.71)), ((V)(0.29)), ((V)(22D)))));
s_349.V(Add(Call(fblot_20, V.Undef, ((V)("quarry")), ((V)(18D)), Arr(((V)("#e08a5a")), ((V)("#7a3418"))), ((V)(0.16)), ((V)(8D))), Call(refl_35, V.Undef, ((V)(0.15)), ((V)("#ffe2c8")))));
return Call(FL_19, V.Undef, ((V)(s_349.Str)));
return default;
}, 0, "fQuarry", false);
fOak_41 = Fn((V _self413, int _argc414, V _a416, V _a417, V _a418, V _a419, V[] _rest415) => {
V R_420 = default;
double NP_421 = 0;
V PC_422 = default;
JsStrBuf s_423 = null;
JsStrBuf gr_424 = null;
JsStrBuf br_425 = null;
JsStrBuf cat_426 = null;
JsStrBuf kn_427 = null;
JsStrBuf ends_428 = null;
JsStrBuf pegs_429 = null;
JsStrBuf sc_430 = null;
JsStrBuf dn_431 = null;
JsStrBuf wh_432 = null;
JsStrBuf ck_433 = null;
if (_self413.IsNullish) _self413 = GlobalV;
R_420 = Call(rng_13, V.Undef, ((V)("oak27")));
NP_421 = 10D;
PC_422 = Arr(((V)("#a88664")), ((V)("#9c7a58")), ((V)("#b39270")), ((V)("#8f6e50")), ((V)("#a5835f")), ((V)("#b99a78")), ((V)("#987454")));
s_423 = new JsStrBuf("<rect width=\"80\" height=\"56\" fill=\"#2e1e12\"/>");
gr_424 = new JsStrBuf("");
br_425 = new JsStrBuf("");
cat_426 = new JsStrBuf("");
kn_427 = new JsStrBuf("");
ends_428 = new JsStrBuf("");
pegs_429 = new JsStrBuf("");
sc_430 = new JsStrBuf("");
dn_431 = new JsStrBuf("");
wh_432 = new JsStrBuf("");
ck_433 = new JsStrBuf("");
{
double i_434 = 0;
i_434 = 0D;
while (true) {
if (!((i_434 < NP_421))) break;
double u0_436 = 0;
double u1_437 = 0;
double cw_438 = 0;
double y_439 = 0;
u0_436 = (i_434 / NP_421);
u1_437 = ((i_434 + 1D) / NP_421);
cw_438 = (u1_437 - u0_436);
y_439 = ((-ToNum(Call(R_420, V.Undef))) * 0.6);
while ((y_439 < 1.03)) {
double L_440 = 0;
double ya_441 = 0;
double yb_442 = 0;
V Q_443 = default;
L_440 = (0.45 + (ToNum(Call(R_420, V.Undef)) * 0.75));
ya_441 = Max(y_439, (-0.02));
yb_442 = Min((y_439 + L_440), 1.04);
Q_443 = Call(rng_13, V.Undef, ((V)(JsStrBuf.Begin().S("oakp").N(i_434).S("_").V(Call(f1_16, V.Undef, ((V)(y_439)))).End())));
s_423.S(string.Concat("<path d=\"", ToStr(Call(quadW_31, V.Undef, ((V)((u0_436 + 0.0025))), ((V)(ya_441)), ((V)((u1_437 - 0.0025))), ((V)(yb_442)))), "\" fill=\"", ToStr(Call(shade_10, V.Undef, GetIdx(PC_422, ((double)(ToInt32((ToNum(Call(Q_443, V.Undef)) * ToNum(Get(PC_422, "length")))) | ToInt32(0D)))), ((V)((0.94 + (ToNum(Call(Q_443, V.Undef)) * 0.1)))))), "\"/>"));
Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis450, int _argc444, V _a446, V _a447, V _a448, V _a449, V[] _rest445) => {
double f_451 = 0;
double a_452 = 0;
double ph_453 = 0;
double w_454 = 0;
f_451 = (0.08 + (ToNum(Call(Q_443, V.Undef)) * 0.84));
a_452 = (0.02 + (ToNum(Call(Q_443, V.Undef)) * 0.05));
ph_453 = (ToNum(Call(Q_443, V.Undef)) * 6D);
w_454 = (1D + (ToNum(Call(Q_443, V.Undef)) * 2D));
gr_424.V(Call(crvW_24, V.Undef, Call(rep_18, V.Undef, ((V)(8D)), Fn((V _arrowThis462, int _argc455, V j_461, V _a458, V _a459, V _a460, V[] _rest456) => {
double t_463 = 0;
t_463 = (ToNum(j_461) / 7D);
return Arr(((V)((u0_436 + (cw_438 * Min(0.96, Max(0.04, (f_451 + (a_452 * FdLibm.Sin((((t_463 * w_454) * 3D) + ph_453)))))))))), ((V)((ya_441 + (t_463 * (yb_442 - ya_441))))));
return default;
}, 1, "", true))));
return default;
}, 0, "", true));
Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis470, int _argc464, V _a466, V _a467, V _a468, V _a469, V[] _rest465) => {
double f_471 = 0;
double t0_472 = 0;
double l_473 = 0;
f_471 = (0.05 + (ToNum(Call(Q_443, V.Undef)) * 0.9));
t0_472 = (ToNum(Call(Q_443, V.Undef)) * 0.8);
l_473 = (0.05 + (ToNum(Call(Q_443, V.Undef)) * 0.2));
br_425.V(Call(lineW_23, V.Undef, Arr(Arr(((V)((u0_436 + (cw_438 * f_471)))), ((V)((ya_441 + ((yb_442 - ya_441) * t0_472))))), Arr(((V)((u0_436 + (cw_438 * (f_471 + ((ToNum(Call(Q_443, V.Undef)) - 0.5) * 0.02)))))), ((V)((ya_441 + ((yb_442 - ya_441) * Min(1D, (t0_472 + l_473))))))))));
return default;
}, 0, "", true));
if (LtN(Call(Q_443, V.Undef), 0.45)) {
double uc_474 = 0;
double yc_475 = 0;
uc_474 = (u0_436 + (cw_438 * (0.3 + (ToNum(Call(Q_443, V.Undef)) * 0.4))));
yc_475 = (ya_441 + ((yb_442 - ya_441) * (0.2 + (ToNum(Call(Q_443, V.Undef)) * 0.5))));
{
double n_476 = 0;
n_476 = 1D;
while (true) {
if (!((n_476 <= 4D))) break;
double w_478 = 0;
double h_479 = 0;
w_478 = ((cw_438 * 0.09) * n_476);
h_479 = (0.035 * n_476);
cat_426.V(Call(crvW_24, V.Undef, Arr(Arr(((V)((uc_474 - w_478))), ((V)((yc_475 + h_479)))), Arr(((V)((uc_474 - (w_478 * 0.55)))), ((V)((yc_475 + (h_479 * 0.3))))), Arr(((V)(uc_474)), ((V)(yc_475))), Arr(((V)((uc_474 + (w_478 * 0.55)))), ((V)((yc_475 + (h_479 * 0.3))))), Arr(((V)((uc_474 + w_478))), ((V)((yc_475 + h_479)))))));
n_476++;
}
}
}
if (LtN(Call(Q_443, V.Undef), 0.4)) {
double ku_480 = 0;
double ky_481 = 0;
double r_482 = 0;
ku_480 = (u0_436 + (cw_438 * (0.25 + (ToNum(Call(Q_443, V.Undef)) * 0.5))));
ky_481 = (ya_441 + ((yb_442 - ya_441) * (0.2 + (ToNum(Call(Q_443, V.Undef)) * 0.6))));
r_482 = (0.45 + (ToNum(Call(Q_443, V.Undef)) * 0.35));
kn_427.V(Add(Add(Add(Call(dot_32, V.Undef, ((V)(ku_480)), ((V)(ky_481)), ((V)((r_482 * 1.6))), ((V)("fill=\"#6a4a30\" opacity=\"0.45\""))), Call(dot_32, V.Undef, ((V)(ku_480)), ((V)(ky_481)), ((V)(r_482)), ((V)("fill=\"#3e2616\"")))), Call(dot_32, V.Undef, ((V)(ku_480)), ((V)(ky_481)), ((V)((r_482 * 0.55))), ((V)("fill=\"#26160c\"")))), Call(dot_32, V.Undef, ((V)(ku_480)), ((V)(ky_481)), ((V)((r_482 * 1.25))), ((V)("fill=\"none\" stroke=\"#4a3020\" stroke-width=\"0.18\" opacity=\"0.7\"")))));
Call(rep_18, V.Undef, ((V)(2D)), Fn((V _arrowThis489, int _argc483, V _a485, V _a486, V _a487, V _a488, V[] _rest484) => {
ck_433.V(Call(lineW_23, V.Undef, Call(walk_36, V.Undef, Q_443, ((V)(ku_480)), ((V)(ky_481)), ((V)(((ToNum(Call(Q_443, V.Undef)) - 0.5) * 0.004))), ((V)(((LtN(Call(Q_443, V.Undef), 0.5) ? (-1D) : 1D) * 0.014))), ((V)(3D)), ((V)(0.004)))));
return default;
}, 0, "", true));
}
if (LtN(Call(Q_443, V.Undef), 0.35)) {
double cu_490 = 0;
double cy0_491 = 0;
cu_490 = (u0_436 + (cw_438 * (0.2 + (ToNum(Call(Q_443, V.Undef)) * 0.6))));
cy0_491 = (ya_441 + (((yb_442 - ya_441) * ToNum(Call(Q_443, V.Undef))) * 0.5));
ck_433.V(Call(lineW_23, V.Undef, Call(walk_36, V.Undef, Q_443, ((V)(cu_490)), ((V)(cy0_491)), ((V)(((ToNum(Call(Q_443, V.Undef)) - 0.5) * 0.003))), ((V)(0.025)), ((V)(4D)), ((V)(0.003)))));
}
{
double t_492 = 0;
t_492 = 0.12;
while (true) {
if (!((t_492 < 1D))) break;
double yy_494 = 0;
double h_495 = 0;
yy_494 = (ya_441 + ((yb_442 - ya_441) * t_492));
h_495 = (0.02 + (ToNum(Call(Q_443, V.Undef)) * 0.015));
sc_430.S(string.Concat("<path d=\"", ToStr(Call(quadW_31, V.Undef, ((V)((u0_436 + 0.003))), ((V)(yy_494)), ((V)((u1_437 - 0.003))), ((V)((yy_494 + h_495))))), "\" fill=\"", (LtN(Call(Q_443, V.Undef), 0.5) ? "#f4dcb8" : "#3a2414"), "\" opacity=\"0.08\"/>"));
t_492 = (t_492 + (0.14 + (ToNum(Call(Q_443, V.Undef)) * 0.08)));
}
}
Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis502, int _argc496, V _a498, V _a499, V _a500, V _a501, V[] _rest497) => {
V p_503 = default;
V k_504 = default;
p_503 = Call(W_21, V.Undef, ((V)((u0_436 + (cw_438 * (0.15 + (ToNum(Call(Q_443, V.Undef)) * 0.7)))))), ((V)((ya_441 + ((yb_442 - ya_441) * ToNum(Call(Q_443, V.Undef)))))));
k_504 = Call(K_29, V.Undef, ((V)((ya_441 + ((yb_442 - ya_441) * 0.5)))));
dn_431.S(string.Concat("<path d=\"M", ToStr(Call(pt_30, V.Undef, p_503)), "q", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(k_504)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_504)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.8 * ToNum(k_504)))))), " 0\" stroke=\"#3e2818\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.2 * ToNum(k_504)))))), "\" fill=\"none\" opacity=\"0.6\"/>"));
return default;
}, 0, "", true));
if (LtN(Call(Q_443, V.Undef), 0.3)) {
double wu_505 = 0;
double wy_506 = 0;
wu_505 = (u0_436 + (cw_438 * (0.2 + (ToNum(Call(Q_443, V.Undef)) * 0.6))));
wy_506 = (ya_441 + ((yb_442 - ya_441) * ToNum(Call(Q_443, V.Undef))));
Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis513, int _argc507, V _a509, V _a510, V _a511, V _a512, V[] _rest508) => {
return ((V)(wh_432.V(Call(dotD_33, V.Undef, ((V)((wu_505 + ((ToNum(Call(Q_443, V.Undef)) - 0.5) * 0.02)))), ((V)((wy_506 + ((ToNum(Call(Q_443, V.Undef)) - 0.5) * 0.04)))), ((V)(0.09)))).Str));
}, 0, "", true));
}
if ((y_439 > 0D)) {
ends_428.V(Call(lineW_23, V.Undef, Arr(Arr(((V)(u0_436)), ((V)(y_439))), Arr(((V)(u1_437)), ((V)(y_439))))));
}
Invoke(Arr(((V)(y_439)), ((V)((y_439 + L_440)))), "forEach", Fn((V _arrowThis521, int _argc514, V ye_520, V _a517, V _a518, V _a519, V[] _rest515) => {
if ((GtN(ye_520, 0D) && LtN(ye_520, 1.02))) {
Invoke(Arr(((V)(0.3)), ((V)(0.7))), "forEach", Fn((V _arrowThis529, int _argc522, V f_528, V _a525, V _a526, V _a527, V[] _rest523) => {
V ey_530 = default;
ey_530 = Add(ye_520, ((V)((SEqN(ye_520, y_439) ? 0.018 : (-0.018)))));
pegs_429.V(Call(polyW_22, V.Undef, Arr(Arr(((V)(((u0_436 + (cw_438 * ToNum(f_528))) - 0.004))), ((V)((ToNum(ey_530) - 0.006)))), Arr(((V)(((u0_436 + (cw_438 * ToNum(f_528))) + 0.004))), ((V)((ToNum(ey_530) - 0.006)))), Arr(((V)(((u0_436 + (cw_438 * ToNum(f_528))) + 0.004))), Add(ey_530, ((V)(0.006)))), Arr(((V)(((u0_436 + (cw_438 * ToNum(f_528))) - 0.004))), Add(ey_530, ((V)(0.006)))))));
return default;
}, 1, "", true));
}
return default;
}, 1, "", true));
y_439 = (y_439 + L_440);
}
i_434++;
}
}
s_423.S(sc_430.Str).S(string.Concat("<path d=\"", gr_424.Str, "\" stroke=\"#5a3c24\" stroke-width=\"0.17\" fill=\"none\" opacity=\"0.3\"/><path d=\"", br_425.Str, "\" stroke=\"#e2cfae\" stroke-width=\"0.1\" fill=\"none\" opacity=\"0.35\"/><path d=\"", cat_426.Str, "\" stroke=\"#5a3c24\" stroke-width=\"0.2\" fill=\"none\" opacity=\"0.32\"/>"));
s_423.S(kn_427.Str).S(string.Concat("<path d=\"", ck_433.Str, "\" stroke=\"#2a1a0e\" stroke-width=\"0.24\" fill=\"none\" stroke-linejoin=\"round\"/><path d=\"", ck_433.Str, "\" stroke=\"#c9a878\" stroke-width=\"0.1\" fill=\"none\" transform=\"translate(0.15 0.1)\" opacity=\"0.6\"/>")).S(dn_431.Str).S(string.Concat("<path d=\"", wh_432.Str, "\" fill=\"#24140a\"/>"));
s_423.S(string.Concat("<path d=\"", pegs_429.Str, "\" fill=\"#5a3a22\" stroke=\"#2e1c10\" stroke-width=\"0.15\"/>"));
s_423.V(Call(fblot_20, V.Undef, ((V)("oak")), ((V)(20D)), Arr(((V)("#c8b8a0")), ((V)("#6e5440")), ((V)("#b89a74"))), ((V)(0.22)), ((V)(8D))));
s_423.S(string.Concat("<path d=\"", ends_428.Str, "\" stroke=\"#2a1a0e\" stroke-width=\"0.32\" opacity=\"0.9\"/><path d=\"", ends_428.Str, "\" stroke=\"#e8cfa6\" stroke-width=\"0.12\" opacity=\"0.35\" transform=\"translate(0 0.22)\"/>"));
s_423.S(string.Concat("<path d=\"", ToStr(Invoke(Call(rep_18, V.Undef, ((V)((NP_421 - 1D))), Fn((V _arrowThis538, int _argc531, V i_537, V _a534, V _a535, V _a536, V[] _rest532) => {
return Call(lineW_23, V.Undef, Arr(Arr(((V)((ToNum(Add(i_537, ((V)(1D)))) / NP_421))), ((V)((-0.02)))), Arr(((V)((ToNum(Add(i_537, ((V)(1D)))) / NP_421))), ((V)(1.04)))));
}, 1, "", true)), "join", ((V)("")))), "\" stroke=\"#e8cfa6\" stroke-width=\"0.14\" opacity=\"0.3\" transform=\"translate(0.26 0)\"/>"));
s_423.V(Call(refl_35, V.Undef, ((V)(0.1)), ((V)("#fff0d8"))));
return Call(FL_19, V.Undef, ((V)(s_423.Str)));
return default;
}, 0, "fOak", false);
fCush_42 = Fn((V _self539, int _argc540, V _a542, V _a543, V _a544, V _a545, V[] _rest541) => {
V R_546 = default;
double NU_547 = 0;
double NV_548 = 0;
double y00_549 = 0;
double gu_550 = 0;
double gy_551 = 0;
double ru_552 = 0;
double ry_553 = 0;
V yj_554 = default;
V SC_555 = default;
JsStrBuf s_556 = null;
JsStrBuf gl_557 = null;
JsStrBuf pads_558 = null;
JsStrBuf clip_559 = null;
V vein_560 = default;
JsStrBuf cloud_561 = null;
JsStrBuf grey_562 = null;
JsStrBuf gold_563 = null;
JsStrBuf fine_564 = null;
if (_self539.IsNullish) _self539 = GlobalV;
R_546 = Call(rng_13, V.Undef, ((V)("cush27b")));
NU_547 = 4D;
NV_548 = 3D;
y00_549 = 0.05;
gu_550 = 0.0045;
gy_551 = 0.008;
ru_552 = 0.012;
ry_553 = 0.022;
yj_554 = Fn((V _arrowThis572, int _argc565, V j_571, V _a568, V _a569, V _a570, V[] _rest566) => {
return ((V)((y00_549 + ((ToNum(j_571) * (1D - y00_549)) / NV_548))));
}, 1, "", true);
SC_555 = Arr(((V)("#f4eee4")), ((V)("#f1eadf")), ((V)("#f6f1e8")), ((V)("#efe7da")));
s_556 = new JsStrBuf(string.Concat("<defs><radialGradient id=\"c27h\" cx=\"50%\" cy=\"62%\" r=\"65%\"><stop offset=\"0\" stop-color=\"#ffb062\" stop-opacity=\"0.2\"/><stop offset=\"1\" stop-color=\"#ffb062\" stop-opacity=\"0\"/></radialGradient>", "<linearGradient id=\"c27b\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8a5f1e\"/><stop offset=\"0.3\" stop-color=\"#f2cf7a\"/><stop offset=\"0.5\" stop-color=\"#fff0b8\"/><stop offset=\"0.7\" stop-color=\"#d9a84a\"/><stop offset=\"1\" stop-color=\"#8a5f1e\"/></linearGradient>", "<linearGradient id=\"c27g\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"0\" x2=\"30\" y2=\"0\"><stop offset=\"0\" stop-color=\"#fff4c8\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#fff4c8\" stop-opacity=\"0.95\"/><stop offset=\"1\" stop-color=\"#fff4c8\" stop-opacity=\"0\"/>", "<animateTransform attributeName=\"gradientTransform\" type=\"translate\" values=\"-40 0;-40 0;110 0\" keyTimes=\"0;0.45;1\" dur=\"9s\" repeatCount=\"indefinite\"/></linearGradient></defs><rect width=\"80\" height=\"56\" fill=\"#a87a32\"/>"));
gl_557 = new JsStrBuf("");
{
double i_573 = 0;
i_573 = 0D;
while (true) {
if (!((i_573 <= NU_547))) break;
gl_557.V(Call(lineW_23, V.Undef, Arr(Arr(((V)((i_573 / NU_547))), ((V)(y00_549))), Arr(((V)((i_573 / NU_547))), ((V)(1.05))))));
i_573++;
}
}
{
double j_575 = 0;
j_575 = 0D;
while (true) {
if (!((j_575 <= NV_548))) break;
gl_557.V(Call(lineW_23, V.Undef, Arr(Arr(((V)((-0.02))), Call(yj_554, V.Undef, ((V)(j_575)))), Arr(((V)(1.02)), Call(yj_554, V.Undef, ((V)(j_575)))))));
j_575++;
}
}
s_556.S(string.Concat("<path d=\"", gl_557.Str, "\" stroke=\"url(#c27b)\" stroke-width=\"0.9\" fill=\"none\"/><path d=\"", gl_557.Str, "\" stroke=\"#ffb45a\" stroke-width=\"2.6\" fill=\"none\" opacity=\"0.18\" filter=\"url(#fb2)\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.08;0.3;0.08")), ((V)(7D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "</path>"));
pads_558 = new JsStrBuf("");
clip_559 = new JsStrBuf("");
{
double j_577 = 0;
j_577 = 0D;
while (true) {
if (!((j_577 < NV_548))) break;
{
double i_579 = 0;
i_579 = 0D;
while (true) {
if (!((i_579 < NU_547))) break;
double u0_581 = 0;
double u1_582 = 0;
V y0_583 = default;
double y1_584 = 0;
double du_585 = 0;
double dy_586 = 0;
V col_587 = default;
u0_581 = ((i_579 / NU_547) + gu_550);
u1_582 = (((i_579 + 1D) / NU_547) - gu_550);
y0_583 = Add(Call(yj_554, V.Undef, ((V)(j_577))), ((V)(gy_551)));
y1_584 = (ToNum(Call(yj_554, V.Undef, ((V)((j_577 + 1D))))) - gy_551);
du_585 = (u1_582 - u0_581);
dy_586 = (y1_584 - ToNum(y0_583));
col_587 = Call(shade_10, V.Undef, GetIdx(SC_555, ((i_579 + (j_577 * 2D)) % 4D)), ((V)((0.99 + (ToNum(Call(R_546, V.Undef)) * 0.02)))));
pads_558.S(string.Concat("<path d=\"", ToStr(Call(rrW_34, V.Undef, ((V)(u0_581)), y0_583, ((V)(u1_582)), ((V)(y1_584)), ((V)(ru_552)), ((V)(ry_553)))), "\" fill=\"", ToStr(Call(shade_10, V.Undef, col_587, ((V)(0.8)))), "\"/><path d=\"", ToStr(Call(rrW_34, V.Undef, ((V)(u0_581)), y0_583, ((V)((u1_582 - (du_585 * 0.012)))), ((V)((y1_584 - (dy_586 * 0.03)))), ((V)(ru_552)), ((V)(ry_553)))), "\" fill=\"", ToStr(Call(shade_10, V.Undef, col_587, ((V)(0.92)))), "\"/>")).S(string.Concat("<path d=\"", ToStr(Call(rrW_34, V.Undef, ((V)((u0_581 + (du_585 * 0.016)))), Add(y0_583, ((V)((dy_586 * 0.025)))), ((V)((u1_582 - (du_585 * 0.02)))), ((V)((y1_584 - (dy_586 * 0.055)))), ((V)(ru_552)), ((V)(ry_553)))), "\" fill=\"", ToStr(col_587), "\"/>"));
clip_559.V(Call(rrW_34, V.Undef, ((V)((u0_581 + (du_585 * 0.016)))), Add(y0_583, ((V)((dy_586 * 0.025)))), ((V)((u1_582 - (du_585 * 0.02)))), ((V)((y1_584 - (dy_586 * 0.055)))), ((V)(ru_552)), ((V)(ry_553))));
i_579++;
}
}
j_577++;
}
}
s_556.S(string.Concat("<defs><clipPath id=\"c27c\"><path d=\"", clip_559.Str, "\"/></clipPath></defs>")).S(pads_558.Str);
vein_560 = Fn((V _arrowThis599, int _argc588, V c_594, V ph_595, V ph2_596, V amp_597, V[] _rest589) => {
V side_598 = default;
side_598 = (_argc588 > 4 ? _rest589[0] : V.Undef);
return Call(rep_18, V.Undef, ((V)(13D)), Fn((V _arrowThis607, int _argc600, V q_606, V _a603, V _a604, V _a605, V[] _rest601) => {
double y_608 = 0;
V x_609 = default;
y_608 = ((-0.05) + (ToNum(q_606) * 0.095));
x_609 = Add(Add(Add(c_594, ((V)((ToNum(amp_597) * FdLibm.Sin(ToNum(Add(((V)((y_608 * 3.2))), ph_595))))))), ((V)((0.03 * FdLibm.Sin(ToNum(Add(((V)((y_608 * 9D))), ph2_596))))))), ((V)((0.12 * y_608))));
return Arr((Truthy(side_598) ? ((V)((1D - ToNum(x_609)))) : x_609), ((V)(y_608)));
return default;
}, 1, "", true));
}, 5, "", true);
cloud_561 = new JsStrBuf("");
grey_562 = new JsStrBuf("");
gold_563 = new JsStrBuf("");
fine_564 = new JsStrBuf("");
Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis617, int _argc610, V k_616, V _a613, V _a614, V _a615, V[] _rest611) => {
double c_618 = 0;
double ph_619 = 0;
double ph2_620 = 0;
double amp_621 = 0;
c_618 = ((0.06 + (ToNum(k_616) * 0.11)) + (ToNum(Call(R_546, V.Undef)) * 0.04));
ph_619 = (ToNum(Call(R_546, V.Undef)) * 6D);
ph2_620 = (ToNum(Call(R_546, V.Undef)) * 6D);
amp_621 = (0.04 + (ToNum(Call(R_546, V.Undef)) * 0.05));
Invoke(Arr(((V)(0D)), ((V)(1D))), "forEach", Fn((V _arrowThis629, int _argc622, V sd_628, V _a625, V _a626, V _a627, V[] _rest623) => {
V d_630 = default;
d_630 = Call(crvW_24, V.Undef, Call(vein_560, V.Undef, ((V)(c_618)), ((V)(ph_619)), ((V)(ph2_620)), ((V)(amp_621)), sd_628));
cloud_561.V(d_630);
if (((ToNum(k_616) % 2D) == 0D)) {
gold_563.V(d_630);
} else {
grey_562.V(d_630);
}
Call(rep_18, V.Undef, ((V)(2D)), Fn((V _arrowThis637, int _argc631, V _a633, V _a634, V _a635, V _a636, V[] _rest632) => {
V P_638 = default;
double st_639 = 0;
P_638 = Call(vein_560, V.Undef, ((V)((c_618 + ((ToNum(Call(R_546, V.Undef)) - 0.5) * 0.05)))), ((V)((ph_619 + 0.4))), ((V)((ph2_620 + 1D))), ((V)((amp_621 * 0.6))), sd_628);
st_639 = (2D + ((double)(ToInt32((ToNum(Call(R_546, V.Undef)) * 6D)) | ToInt32(0D))));
fine_564.V(Call(crvW_24, V.Undef, Invoke(P_638, "slice", ((V)(st_639)), ((V)((st_639 + 4D))))));
return default;
}, 0, "", true));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
s_556.S(string.Concat("<g clip-path=\"url(#c27c)\"><g filter=\"url(#fb2)\"><path d=\"", cloud_561.Str, "\" stroke=\"#b9b2a8\" stroke-width=\"2.2\" fill=\"none\" opacity=\"0.35\"/></g><path d=\"", grey_562.Str, "\" stroke=\"#8e877e\" stroke-width=\"0.32\" fill=\"none\" opacity=\"0.75\"/>")).S(string.Concat("<path d=\"", gold_563.Str, "\" stroke=\"#b8893a\" stroke-width=\"0.5\" fill=\"none\" opacity=\"0.5\" filter=\"url(#fb1)\"/><path d=\"", gold_563.Str, "\" stroke=\"#c99a44\" stroke-width=\"0.22\" fill=\"none\"/><path d=\"", fine_564.Str, "\" stroke=\"#9a938a\" stroke-width=\"0.13\" fill=\"none\" opacity=\"0.6\"/>")).V(Call(fblot_20, V.Undef, ((V)("cush27")), ((V)(16D)), Arr(((V)("#ffffff")), ((V)("#e8dfd0"))), ((V)(0.35)), ((V)(9D)))).S("</g>");
{
double j_640 = 0;
j_640 = 0D;
while (true) {
if (!((j_640 < NV_548))) break;
{
double i_642 = 0;
i_642 = 0D;
while (true) {
if (!((i_642 < NU_547))) break;
double u0_644 = 0;
double u1_645 = 0;
V y0_646 = default;
double y1_647 = 0;
double du_648 = 0;
double dy_649 = 0;
u0_644 = ((i_642 / NU_547) + gu_550);
u1_645 = (((i_642 + 1D) / NU_547) - gu_550);
y0_646 = Add(Call(yj_554, V.Undef, ((V)(j_640))), ((V)(gy_551)));
y1_647 = (ToNum(Call(yj_554, V.Undef, ((V)((j_640 + 1D))))) - gy_551);
du_648 = (u1_645 - u0_644);
dy_649 = (y1_647 - ToNum(y0_646));
s_556.S(string.Concat("<path d=\"", ToStr(Call(rrW_34, V.Undef, ((V)((u0_644 + (du_648 * 0.1)))), Add(y0_646, ((V)((dy_649 * 0.1)))), ((V)((u1_645 - (du_648 * 0.2)))), ((V)((y1_647 - (dy_649 * 0.32)))), ((V)((ru_552 * 3D))), ((V)((ry_553 * 3D))))), "\" fill=\"#ffffff\" opacity=\"0.22\" filter=\"url(#fb2)\"/>")).S(string.Concat("<path d=\"", ToStr(Call(lineW_23, V.Undef, Arr(Arr(((V)((u0_644 + (du_648 * 0.018)))), ((V)((y1_647 - (dy_649 * 0.15))))), Arr(((V)((u0_644 + (du_648 * 0.018)))), Add(y0_646, ((V)((dy_649 * 0.06))))), Arr(((V)((u0_644 + (du_648 * 0.05)))), Add(y0_646, ((V)((dy_649 * 0.028))))), Arr(((V)((u1_645 - (du_648 * 0.06)))), Add(y0_646, ((V)((dy_649 * 0.028)))))))), "\" stroke=\"#ffffff\" stroke-width=\"0.32\" fill=\"none\" opacity=\"0.8\" stroke-linecap=\"round\"/>"));
i_642++;
}
}
j_640++;
}
}
s_556.S(string.Concat("<path d=\"", gl_557.Str, "\" stroke=\"#fff3c8\" stroke-width=\"0.14\" fill=\"none\" opacity=\"0.8\" transform=\"translate(-0.08 -0.1)\"/><path d=\"", gl_557.Str, "\" stroke=\"url(#c27g)\" stroke-width=\"0.6\" fill=\"none\"/>"));
{
double j_650 = 0;
j_650 = 1D;
while (true) {
if (!((j_650 < NV_548))) break;
{
double i_652 = 0;
i_652 = 1D;
while (true) {
if (!((i_652 < NU_547))) break;
double u_654 = 0;
V y_655 = default;
double a_656 = 0;
double b2_657 = 0;
V D_658 = default;
V di_659 = default;
V p_660 = default;
V k_661 = default;
u_654 = (i_652 / NU_547);
y_655 = Call(yj_554, V.Undef, ((V)(j_650)));
a_656 = 0.016;
b2_657 = 0.03;
D_658 = Call(polyW_22, V.Undef, Arr(Arr(((V)(u_654)), ((V)((ToNum(y_655) - b2_657)))), Arr(((V)((u_654 + a_656))), y_655), Arr(((V)(u_654)), Add(y_655, ((V)(b2_657)))), Arr(((V)((u_654 - a_656))), y_655)));
di_659 = Call(polyW_22, V.Undef, Arr(Arr(((V)(u_654)), ((V)((ToNum(y_655) - (b2_657 * 0.5))))), Arr(((V)((u_654 + (a_656 * 0.5)))), y_655), Arr(((V)(u_654)), Add(y_655, ((V)((b2_657 * 0.5))))), Arr(((V)((u_654 - (a_656 * 0.5)))), y_655)));
p_660 = Call(W_21, V.Undef, ((V)(u_654)), y_655);
k_661 = Call(K_29, V.Undef, y_655);
s_556.S(string.Concat("<path d=\"", ToStr(D_658), "\" fill=\"#000000\" opacity=\"0.25\" transform=\"translate(0.25 0.3)\" filter=\"url(#fb1)\"/><path d=\"", ToStr(D_658), "\" fill=\"url(#c27b)\" stroke=\"#7a5418\" stroke-width=\"0.15\"/><path d=\"", ToStr(di_659), "\" fill=\"#f6efe2\"/>")).S(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(p_660, 0D)) - (1.6 * ToNum(k_661))))))), " ", ToStr(Call(f1_16, V.Undef, GetIdx(p_660, 1D))), "H", ToStr(Call(f1_16, V.Undef, Add(GetIdx(p_660, 0D), ((V)((1.6 * ToNum(k_661))))))), "M", ToStr(Call(f1_16, V.Undef, GetIdx(p_660, 0D))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(p_660, 1D)) - (0.9 * ToNum(k_661))))))), "V", ToStr(Call(f1_16, V.Undef, Add(GetIdx(p_660, 1D), ((V)((0.9 * ToNum(k_661))))))), "\" stroke=\"#ffffff\" stroke-width=\"0.2\" stroke-linecap=\"round\" opacity=\"0\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0;0;0.95;0")), ((V)(6D)), ((V)(((-(i_652 + j_650)) * 1.3))), ((V)(" keyTimes=\"0;0.7;0.8;1\"")))), "</path>"));
i_652++;
}
}
j_650++;
}
}
s_556.S(string.Concat("<path d=\"", ToStr(TR_26), "\" fill=\"url(#c27h)\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.35;1;0.35")), ((V)(8D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "</path>"));
Invoke(Arr(Arr(((V)(0.4)), ((V)(0.66)), ((V)(0D))), Arr(((V)(0.72)), ((V)(0.4)), ((V)(3D)))), "forEach", Fn((V _arrowThis675, int _argc662, V _a664, V _a665, V _a666, V _a667, V[] _rest663) => {
V p_676 = default;
V k_677 = default;
V KT_678 = default;
V A_679 = default;
V u_670 = default;
V y_672 = default;
V b_674 = default;
{ V _t668 = ListOf(_a664);
{ V _t669 = GetIdx(_t668, 0D);
u_670 = _t669; }
{ V _t671 = GetIdx(_t668, 1D);
y_672 = _t671; }
{ V _t673 = GetIdx(_t668, 2D);
b_674 = _t673; }
}
p_676 = Call(W_21, V.Undef, u_670, y_672);
k_677 = Call(K_29, V.Undef, y_672);
KT_678 = ((V)(" keyTimes=\"0;0.2;0.55;1\""));
A_679 = Fn((V _arrowThis688, int _argc680, V at_686, V v_687, V _a684, V _a685, V[] _rest681) => {
return ((V)(string.Concat("<animate attributeName=\"", ToStr(at_686), "\" values=\"", ToStr(v_687), "\"", ToStr(KT_678), " dur=\"6s\" begin=\"", ToStr(Call(n4_17, V.Undef, ((V)((-ToNum(b_674)))))), "s\" repeatCount=\"indefinite\"/>")));
}, 2, "", true);
s_556.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_676, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_676, 1D))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((2.2 * ToNum(k_677)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((1D * ToNum(k_677)))))), "\" fill=\"#8a7a62\" opacity=\"0\" filter=\"url(#fb1)\">", ToStr(Call(A_679, V.Undef, ((V)("opacity")), ((V)("0;0.22;0;0")))), "</ellipse>")).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_676, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_676, 1D))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(k_677)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.28 * ToNum(k_677)))))), "\" fill=\"none\" stroke=\"#ffe2a8\" stroke-width=\"0.28\" opacity=\"0\">", ToStr(Call(A_679, V.Undef, ((V)("rx")), ((V)(string.Concat(ToStr(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(k_677)))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(k_677)))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((3.8 * ToNum(k_677)))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((3.8 * ToNum(k_677))))))))))), ToStr(Call(A_679, V.Undef, ((V)("ry")), ((V)(string.Concat(ToStr(Call(f1_16, V.Undef, ((V)((0.28 * ToNum(k_677)))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((0.28 * ToNum(k_677)))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((1.8 * ToNum(k_677)))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((1.8 * ToNum(k_677))))))))))), ToStr(Call(A_679, V.Undef, ((V)("opacity")), ((V)("0;0.8;0;0")))), "</ellipse>"));
return default;
}, 1, "", true));
s_556.S(string.Concat("<path d=\"", ToStr(Call(quadW_31, V.Undef, ((V)((-0.02))), ((V)((-0.03))), ((V)(1.02)), ((V)((y00_549 - 0.006))))), "\" fill=\"#2a1e14\"/><path d=\"", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(90D)), Fn((V _arrowThis696, int _argc689, V i_695, V _a692, V _a693, V _a694, V[] _rest690) => {
return Call(lineW_23, V.Undef, Arr(Arr(((V)(((ToNum(i_695) / 90D) + 0.003))), ((V)(0.006))), Arr(((V)(((ToNum(i_695) / 90D) + 0.003))), ((V)((y00_549 - 0.014))))));
}, 1, "", true)), "join", ((V)("")))), "\" stroke=\"#b8893a\" stroke-width=\"0.14\" opacity=\"0.7\"/>")).S(string.Concat("<path d=\"", ToStr(Call(lineW_23, V.Undef, Arr(Arr(((V)((-0.02))), ((V)(0.003))), Arr(((V)(1.02)), ((V)(0.003)))))), "\" stroke=\"#d9a84a\" stroke-width=\"0.3\"/><path d=\"", ToStr(Call(lineW_23, V.Undef, Arr(Arr(((V)((-0.02))), ((V)((y00_549 - 0.006)))), Arr(((V)(1.02)), ((V)((y00_549 - 0.006))))))), "\" stroke=\"url(#c27b)\" stroke-width=\"0.6\"/>"));
s_556.S(string.Concat("<path d=\"", ToStr(Call(lineW_23, V.Undef, Arr(Arr(((V)(0D)), ((V)((y00_549 - 0.002)))), Arr(((V)(1D)), ((V)((y00_549 - 0.002))))))), "\" stroke=\"#ffd99a\" stroke-width=\"1.8\" opacity=\"0.35\" filter=\"url(#fb2)\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.2;0.5;0.2")), ((V)(4D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "</path><path d=\"", ToStr(Call(lineW_23, V.Undef, Arr(Arr(((V)(0D)), ((V)((y00_549 - 0.002)))), Arr(((V)(1D)), ((V)((y00_549 - 0.002))))))), "\" stroke=\"#fff1cf\" stroke-width=\"0.2\"/>"));
Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis704, int _argc697, V i_703, V _a700, V _a701, V _a702, V[] _rest698) => {
double u_705 = 0;
V d_706 = default;
double dur_707 = 0;
double b_708 = 0;
u_705 = ((0.08 + (ToNum(i_703) * 0.14)) + ((ToNum(Call(R_546, V.Undef)) - 0.5) * 0.04));
d_706 = Call(crvW_24, V.Undef, Arr(Arr(((V)(u_705)), ((V)(0.95))), Arr(((V)((u_705 + ((0.5 - u_705) * 0.12)))), ((V)(0.6))), Arr(((V)((u_705 + ((0.5 - u_705) * 0.06)))), ((V)(0.3))), Arr(((V)(u_705)), ((V)((y00_549 + 0.008))))));
dur_707 = (5D + (ToNum(Call(R_546, V.Undef)) * 2D));
b_708 = ((-ToNum(Call(R_546, V.Undef))) * dur_707);
Call(rep_18, V.Undef, ((V)(2D)), Fn((V _arrowThis716, int _argc709, V q_715, V _a712, V _a713, V _a714, V[] _rest710) => {
double bb_717 = 0;
bb_717 = (b_708 - ((ToNum(q_715) * dur_707) / 2D));
s_556.S(string.Concat("<circle r=\"0.26\" fill=\"#ffe7a8\"><animateMotion path=\"", ToStr(d_706), "\" dur=\"", ToStr(Call(n4_17, V.Undef, ((V)(dur_707)))), "s\" begin=\"", ToStr(Call(n4_17, V.Undef, ((V)(bb_717)))), "s\" repeatCount=\"indefinite\"/><animate attributeName=\"r\" values=\"0.3;0.22;0.08\" dur=\"", ToStr(Call(n4_17, V.Undef, ((V)(dur_707)))), "s\" begin=\"", ToStr(Call(n4_17, V.Undef, ((V)(bb_717)))), "s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0;0.9;0.9;0\" keyTimes=\"0;0.12;0.85;1\" dur=\"", ToStr(Call(n4_17, V.Undef, ((V)(dur_707)))), "s\" begin=\"", ToStr(Call(n4_17, V.Undef, ((V)(bb_717)))), "s\" repeatCount=\"indefinite\"/></circle>"));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
s_556.V(Call(refl_35, V.Undef, ((V)(0.34)), ((V)("#fffaf0"))));
return Call(FL_19, V.Undef, ((V)(s_556.Str)));
return default;
}, 0, "fCush", false);
cAcou_58 = Fn((V _self718, int _argc719, V G_725, V _a722, V _a723, V _a724, V[] _rest720) => {
V R_726 = default;
double NU_727 = 0;
double NT_728 = 0;
double du_729 = 0;
double dt_730 = 0;
V TC_731 = default;
V gk_732 = default;
V MI_733 = default;
V SG_734 = default;
V FN_735 = default;
JsStrBuf s_736 = null;
JsStrBuf fis_737 = null;
JsStrBuf pin_738 = null;
JsStrBuf eD_739 = null;
JsStrBuf eL_740 = null;
JsStrBuf ov_741 = null;
JsStrBuf gu_742 = null;
if (_self718.IsNullish) _self718 = GlobalV;
R_726 = Call(rng_13, V.Undef, ((V)("acou27")));
NU_727 = 14D;
NT_728 = 5D;
du_729 = (1D / NU_727);
dt_730 = (1D / NT_728);
TC_731 = Arr(((V)("#e8e2cf")), ((V)("#e3dcc6")), ((V)("#ece7d7")), ((V)("#ded6bf")));
gk_732 = Fn((V _arrowThis751, int _argc743, V u_749, V t_750, V _a747, V _a748, V[] _rest744) => {
return ((V)(Max(0D, (1D - Hypot(((ToNum(u_749) - 0.18) / 0.26), ((ToNum(t_750) - 0.72) / 0.45))))));
}, 2, "", true);
MI_733 = Arr(((V)(4D)), ((V)(2D)));
SG_734 = Arr(((V)(9D)), ((V)(3D)));
FN_735 = Arr(((V)(2D)), ((V)(3D)));
s_736 = new JsStrBuf(string.Concat("<path d=\"", ToStr(Get(G_725, "tr")), "\" fill=\"#1c1813\"/>"));
fis_737 = new JsStrBuf("");
pin_738 = new JsStrBuf("");
eD_739 = new JsStrBuf("");
eL_740 = new JsStrBuf("");
ov_741 = new JsStrBuf("");
{
V j_752 = default;
j_752 = ((V)(0D));
while (true) {
V j_752_it = j_752;
if (!(LtN(j_752_it, NT_728))) break;
{
V i_754 = default;
i_754 = ((V)(0D));
while (true) {
V i_754_it = i_754;
if (!(LtN(i_754_it, NU_727))) break;
double u0_756 = 0;
double u1_757 = 0;
double t0_758 = 0;
double t1_759 = 0;
V @is_760 = default;
u0_756 = (ToNum(i_754_it) * du_729);
u1_757 = (u0_756 + du_729);
t0_758 = (ToNum(j_752_it) * dt_730);
t1_759 = (t0_758 + dt_730);
@is_760 = Fn((V _arrowThis768, int _argc761, V A_767, V _a764, V _a765, V _a766, V[] _rest762) => {
return ((SEq(GetIdx(A_767, 0D), i_754_it) && SEq(GetIdx(A_767, 1D), j_752_it)) ? V.True : V.False);
}, 1, "", true);
if (Truthy(((Call(@is_760, V.Undef, MI_733) is var _t769 && Truthy(_t769) ? _t769 : Call(@is_760, V.Undef, FN_735)) is var _t770 && Truthy(_t770) ? _t770 : Call(@is_760, V.Undef, SG_734)))) {
goto _cont755;
}
s_736.S(string.Concat("<path d=\"", ToStr(Invoke(G_725, "quad", ((V)(u0_756)), ((V)(t0_758)), ((V)(u1_757)), ((V)(t1_759)))), "\" fill=\"", ToStr(Call(shade_10, V.Undef, GetIdx(TC_731, ((double)(ToInt32((ToNum(Call(R_726, V.Undef)) * 4D)) | ToInt32(0D)))), ((V)(((1D - (0.14 * ToNum(Call(gk_732, V.Undef, ((V)((u0_756 + (du_729 / 2D)))), ((V)((t0_758 + (dt_730 / 2D)))))))) - (ToNum(Call(R_726, V.Undef)) * 0.03)))))), "\"/>"));
Call(rep_18, V.Undef, ((V)(11D)), Fn((V _arrowThis777, int _argc771, V _a773, V _a774, V _a775, V _a776, V[] _rest772) => {
V P_778 = default;
double l_779 = 0;
double a_780 = 0;
P_778 = Call(cE_49, V.Undef, G_725, ((V)((u0_756 + (du_729 * (0.06 + (ToNum(Call(R_726, V.Undef)) * 0.88)))))), ((V)((t0_758 + (dt_730 * (0.1 + (ToNum(Call(R_726, V.Undef)) * 0.8)))))));
l_779 = ((1.4 + (ToNum(Call(R_726, V.Undef)) * 2.2)) * ToNum(Get(P_778, "z")));
a_780 = (ToNum(Call(R_726, V.Undef)) * PI_11);
fis_737.S(string.Concat("M", ToStr(Call(f1_16, V.Undef, Get(P_778, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(P_778, "y"))), "q", ToStr(Call(f1_16, V.Undef, ((V)((((FdLibm.Cos(a_780) * l_779) * 0.5) + ((ToNum(Call(R_726, V.Undef)) - 0.5) * ToNum(Get(P_778, "z")))))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((((FdLibm.Sin(a_780) * l_779) * 0.5) * ToNum(Get(P_778, "q"))))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((FdLibm.Cos(a_780) * l_779))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((FdLibm.Sin(a_780) * l_779) * ToNum(Get(P_778, "q")))))))));
return default;
}, 0, "", true));
Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis787, int _argc781, V _a783, V _a784, V _a785, V _a786, V[] _rest782) => {
V P_788 = default;
P_788 = Call(cE_49, V.Undef, G_725, ((V)((u0_756 + (du_729 * (0.05 + (ToNum(Call(R_726, V.Undef)) * 0.9)))))), ((V)((t0_758 + (dt_730 * (0.08 + (ToNum(Call(R_726, V.Undef)) * 0.84)))))));
pin_738.V(Call(cD_51, V.Undef, Get(P_788, "x"), Get(P_788, "y"), ((V)((0.22 * ToNum(Get(P_788, "z"))))), ((V)(((0.22 * ToNum(Get(P_788, "z"))) * ToNum(Get(P_788, "q")))))));
return default;
}, 0, "", true));
eD_739.S("M").V(Invoke(G_725, "P", ((V)(u0_756)), ((V)((t0_758 + (dt_730 * 0.05)))))).S("L").V(Invoke(G_725, "P", ((V)(u1_757)), ((V)((t0_758 + (dt_730 * 0.05))))));
eL_740.S("M").V(Invoke(G_725, "P", ((V)(u0_756)), ((V)((t1_759 - (dt_730 * 0.05)))))).S("L").V(Invoke(G_725, "P", ((V)(u1_757)), ((V)((t1_759 - (dt_730 * 0.05))))));
_cont755: ;
i_754 = i_754_it;
PostInc(ref i_754, 1D);
}
}
j_752 = j_752_it;
PostInc(ref j_752, 1D);
}
}
s_736.S(string.Concat("<path d=\"", fis_737.Str, "\" stroke=\"#a59a80\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.42 * ToNum(Get(G_725, "s"))))))), "\" fill=\"none\" stroke-linecap=\"round\" opacity=\"0.75\"/><path d=\"", pin_738.Str, "\" fill=\"#9d927a\" opacity=\"0.7\"/>")).S(string.Concat("<path d=\"", eD_739.Str, "\" stroke=\"#a89c80\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.7 * ToNum(Get(G_725, "s"))))))), "\" opacity=\"0.5\"/><path d=\"", eL_740.Str, "\" stroke=\"#fbf8ef\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(Get(G_725, "s"))))))), "\" opacity=\"0.6\"/>"));
s_736.V(Add(Add(Call(cStain_56, V.Undef, G_725, ((V)(0.47)), ((V)(0.58)), ((V)(30D)), ((V)("ks1"))), Call(cStain_56, V.Undef, G_725, ((V)(0.83)), ((V)(0.3)), ((V)(20D)), ((V)("ks2")))), Call(cStain_56, V.Undef, G_725, ((V)(0.58)), ((V)(0.2)), ((V)(12D)), ((V)("ks4")))));
s_736.S("<g filter=\"url(#cb6)\">").V(Invoke(Call(rep_18, V.Undef, ((V)(8D)), Fn((V _arrowThis795, int _argc789, V _a791, V _a792, V _a793, V _a794, V[] _rest790) => {
V P_796 = default;
P_796 = Call(cE_49, V.Undef, G_725, ((V)((0.04 + (ToNum(Call(R_726, V.Undef)) * 0.32)))), ((V)((0.5 + (ToNum(Call(R_726, V.Undef)) * 0.5)))));
return Call(cEl_52, V.Undef, P_796, ((V)(((14D + (ToNum(Call(R_726, V.Undef)) * 20D)) * ToNum(Get(P_796, "z"))))), ((V)(((3D + (ToNum(Call(R_726, V.Undef)) * 3D)) * ToNum(Get(P_796, "z"))))), ((V)(string.Concat("fill=\"#a07a34\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.12 + (ToNum(Call(R_726, V.Undef)) * 0.12)))))), "\""))));
return default;
}, 0, "", true)), "join", ((V)("")))).S("</g>");
s_736.V(Invoke(Call(rep_18, V.Undef, ((V)(80D)), Fn((V _arrowThis803, int _argc797, V _a799, V _a800, V _a801, V _a802, V[] _rest798) => {
double u_804 = 0;
double t_805 = 0;
V P_806 = default;
u_804 = (0.02 + (ToNum(Call(R_726, V.Undef)) * 0.38));
t_805 = (0.42 + (ToNum(Call(R_726, V.Undef)) * 0.58));
P_806 = Call(cE_49, V.Undef, G_725, ((V)(u_804)), ((V)(t_805)));
return (GtN(Call(gk_732, V.Undef, ((V)(u_804)), ((V)(t_805))), (ToNum(Call(R_726, V.Undef)) * 0.8)) ? Call(cEl_52, V.Undef, P_806, ((V)((0.3 * ToNum(Get(P_806, "z"))))), ((V)(((0.3 * ToNum(Get(P_806, "z"))) * ToNum(Get(P_806, "q"))))), ((V)("fill=\"#6e4c1a\" opacity=\"0.6\""))) : ((V)("")));
return default;
}, 0, "", true)), "join", ((V)(""))));
{
double u0_807 = 0;
double t0_808 = 0;
V A_809 = default;
V a_810 = default;
V b_811 = default;
V z_812 = default;
V w_813 = default;
u0_807 = (ToNum(GetIdx(MI_733, 0D)) * du_729);
t0_808 = (ToNum(GetIdx(MI_733, 1D)) * dt_730);
A_809 = Fn((V _arrowThis822, int _argc814, V f_820, V g_821, V _a818, V _a819, V[] _rest815) => {
return Call(cE_49, V.Undef, G_725, ((V)((u0_807 + (du_729 * ToNum(f_820))))), ((V)((t0_808 + (dt_730 * ToNum(g_821))))));
}, 2, "", true);
s_736.S(string.Concat("<path d=\"", ToStr(Invoke(G_725, "quad", ((V)((u0_807 - 0.01))), ((V)((t0_808 + (dt_730 * 0.2)))), ((V)(((u0_807 + du_729) + 0.01))), ((V)((t0_808 + (dt_730 * 0.46)))))), "\" fill=\"#5c5850\"/><path d=\"M", ToStr(Invoke(G_725, "P", ((V)(u0_807)), ((V)((t0_808 + (dt_730 * 0.2)))))), "L", ToStr(Invoke(G_725, "P", ((V)((u0_807 + du_729))), ((V)((t0_808 + (dt_730 * 0.2)))))), "\" stroke=\"#9a958a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(Get(G_725, "s"))))))), "\"/>")).S("<g filter=\"url(#cb1)\">").V(Invoke(Invoke(Arr(Arr(((V)(0.08)), ((V)(0.75))), Arr(((V)(0.9)), ((V)(0.8))), Arr(((V)(0.2)), ((V)(0.95)))), "map", Fn((V _arrowThis834, int _argc823, V _a825, V _a826, V _a827, V _a828, V[] _rest824) => {
V P_835 = default;
V f_831 = default;
V g_833 = default;
{ V _t829 = ListOf(_a825);
{ V _t830 = GetIdx(_t829, 0D);
f_831 = _t830; }
{ V _t832 = GetIdx(_t829, 1D);
g_833 = _t832; }
}
P_835 = Call(A_809, V.Undef, f_831, g_833);
return Call(cEl_52, V.Undef, P_835, ((V)((4D * ToNum(Get(P_835, "z"))))), ((V)((1.4 * ToNum(Get(P_835, "z"))))), ((V)("fill=\"#e6a49a\" opacity=\"0.8\"")));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g>");
a_810 = Call(A_809, V.Undef, ((V)(0.25)), ((V)(0.55)));
b_811 = Call(A_809, V.Undef, ((V)(0.7)), ((V)(0.62)));
z_812 = Get(a_810, "z");
w_813 = ((V)(string.Concat("M", ToStr(Call(f1_16, V.Undef, Get(a_810, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(a_810, "y"))), "C", ToStr(Call(f1_16, V.Undef, Add(Get(a_810, "x"), ((V)((5D * ToNum(z_812))))))), " ", ToStr(Call(f1_16, V.Undef, Add(Get(a_810, "y"), ((V)((13D * ToNum(z_812))))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Get(b_811, "x")) - (4D * ToNum(z_812))))))), " ", ToStr(Call(f1_16, V.Undef, Add(Get(b_811, "y"), ((V)((15D * ToNum(z_812))))))), " ", ToStr(Call(f1_16, V.Undef, Get(b_811, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(b_811, "y"))))));
ov_741.S(string.Concat("<g>", ToStr(Call(at_47, V.Undef, ((V)("rotate")), ((V)(string.Concat("-4 ", ToStr(Call(f1_16, V.Undef, Get(a_810, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(a_810, "y"))), ";5 ", ToStr(Call(f1_16, V.Undef, Get(a_810, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(a_810, "y"))), ";-4 ", ToStr(Call(f1_16, V.Undef, Get(a_810, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(a_810, "y")))))), ((V)(6.5)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "<path d=\"", ToStr(w_813), "\" stroke=\"#2e2a24\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.3 * ToNum(z_812)))))), "\" fill=\"none\"/><path d=\"", ToStr(w_813), "\" stroke=\"#d9d2c0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.8 * ToNum(z_812)))))), "\" fill=\"none\"/></g>"));
}
{
double u0_836 = 0;
double t0_837 = 0;
double ua_838 = 0;
double ub_839 = 0;
double ta_840 = 0;
double tb_841 = 0;
V c_842 = default;
V z_843 = default;
double w_844 = 0;
double h_845 = 0;
double rb_846 = 0;
double sy_847 = 0;
V bl_848 = default;
V blades_849 = default;
JsStrBuf L_850 = null;
V box_851 = default;
V dp_852 = default;
V y0_853 = default;
V KT_854 = default;
u0_836 = (ToNum(GetIdx(FN_735, 0D)) * du_729);
t0_837 = (ToNum(GetIdx(FN_735, 1D)) * dt_730);
ua_838 = (u0_836 + (du_729 * 0.13));
ub_839 = (u0_836 + (du_729 * 0.87));
ta_840 = (t0_837 + (dt_730 * 0.2));
tb_841 = (t0_837 + (dt_730 * 0.8));
c_842 = Call(cE_49, V.Undef, G_725, ((V)((u0_836 + (du_729 / 2D)))), ((V)((t0_837 + (dt_730 / 2D)))));
z_843 = Get(c_842, "z");
w_844 = (ToNum(Invoke(G_725, "x", ((V)(ub_839)), Get(c_842, "y"))) - ToNum(Invoke(G_725, "x", ((V)(ua_838)), Get(c_842, "y"))));
h_845 = (ToNum(Invoke(G_725, "y", ((V)(tb_841)))) - ToNum(Invoke(G_725, "y", ((V)(ta_840)))));
rb_846 = (w_844 * 0.42);
sy_847 = (h_845 / w_844);
bl_848 = ((V)(string.Concat("M0 0C", ToStr(Call(f1_16, V.Undef, ((V)(((-0.42) * rb_846))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.25) * rb_846))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.36) * rb_846))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.95) * rb_846))))), " 0 ", ToStr(Call(f1_16, V.Undef, ((V)((-rb_846))))), "C", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * rb_846))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.92) * rb_846))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.22 * rb_846))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.3) * rb_846))))), " 0 0Z")));
blades_849 = Invoke(Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis862, int _argc855, V k_861, V _a858, V _a859, V _a860, V[] _rest856) => {
return ((V)(string.Concat("<path d=\"", ToStr(bl_848), "\" transform=\"rotate(", NumStr((ToNum(k_861) * 90D)), ")\" fill=\"#7e6c4c\" stroke=\"#4a3c26\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(z_843)))))), "\"/>")));
}, 1, "", true)), "join", ((V)("")));
L_850 = new JsStrBuf("");
Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis870, int _argc863, V k_869, V _a866, V _a867, V _a868, V[] _rest864) => {
double t_871 = 0;
t_871 = (ta_840 + (((tb_841 - ta_840) * ToNum(Add(k_869, ((V)(1D))))) / 6D));
L_850.S("M").V(Invoke(G_725, "P", ((V)(ua_838)), ((V)(t_871)))).S("L").V(Invoke(G_725, "P", ((V)(ub_839)), ((V)(t_871))));
return default;
}, 1, "", true));
box_851 = ((V)(JsStrBuf.Begin().S(string.Concat("<path d=\"", ToStr(Invoke(G_725, "quad", ((V)(u0_836)), ((V)(t0_837)), ((V)((u0_836 + du_729))), ((V)((t0_837 + dt_730))))), "\" fill=\"#d2c7a8\" stroke=\"#8c7a52\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(Get(G_725, "s"))))))), "\"/><path d=\"", ToStr(Invoke(G_725, "quad", ((V)((u0_836 + (du_729 * 0.05)))), ((V)((t0_837 + (dt_730 * 0.09)))), ((V)((u0_836 + (du_729 * 0.95)))), ((V)((t0_837 + (dt_730 * 0.91)))))), "\" fill=\"none\" stroke=\"#f0e8d0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(Get(G_725, "s"))))))), "\"/>")).S(string.Concat("<defs><clipPath id=\"k27f\"><path d=\"", ToStr(Invoke(G_725, "quad", ((V)(ua_838)), ((V)(ta_840)), ((V)(ub_839)), ((V)(tb_841)))), "\"/></clipPath></defs><path d=\"", ToStr(Invoke(G_725, "quad", ((V)(ua_838)), ((V)(ta_840)), ((V)(ub_839)), ((V)(tb_841)))), "\" fill=\"#1e1810\"/>")).S(string.Concat("<g clip-path=\"url(#k27f)\"><g transform=\"translate(", ToStr(Call(f1_16, V.Undef, Get(c_842, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(c_842, "y"))), ") scale(1 ", ToStr(Call(n4_17, V.Undef, ((V)(sy_847)))), ")\"><circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)(rb_846)))), "\" fill=\"#8a7650\" opacity=\"0.22\"/><g>", ToStr(Call(at_47, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(0.9)), ((V)(0D)), ((V)("")))), ToStr(blades_849), "</g><circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((rb_846 * 0.17))))), "\" fill=\"#3a3024\" stroke=\"#9a8660\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(z_843)))))), "\"/></g></g>")).S(string.Concat("<path d=\"", L_850.Str, "\" stroke=\"#4a3a20\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.5 * ToNum(z_843)))))), "\" transform=\"translate(0 ", ToStr(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(z_843)))))), ")\"/><path d=\"", L_850.Str, "\" stroke=\"#c9bc98\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1D * ToNum(z_843)))))), "\"/><path d=\"", L_850.Str, "\" stroke=\"#efe6cc\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(z_843)))))), "\" transform=\"translate(0 ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.3) * ToNum(z_843)))))), ")\"/>")).S("<g filter=\"url(#cb1)\">").V(Invoke(Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis878, int _argc872, V _a874, V _a875, V _a876, V _a877, V[] _rest873) => {
V P_879 = default;
P_879 = Call(cE_49, V.Undef, G_725, ((V)((ua_838 + ((ub_839 - ua_838) * ToNum(Call(R_726, V.Undef)))))), ((V)((ta_840 + ((tb_841 - ta_840) * ToNum(Call(R_726, V.Undef)))))));
return Call(cEl_52, V.Undef, P_879, ((V)(((1.5 + (ToNum(Call(R_726, V.Undef)) * 2D)) * ToNum(Get(P_879, "z"))))), ((V)((0.6 * ToNum(Get(P_879, "z"))))), ((V)(string.Concat("fill=\"#6a4e1e\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 + (ToNum(Call(R_726, V.Undef)) * 0.3)))))), "\""))));
return default;
}, 0, "", true)), "join", ((V)("")))).S("</g>").End()));
s_736.S(string.Concat("<g>", ToStr(Call(at_47, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;0 0;", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(z_843)))))), " 0;", ToStr(Call(f1_16, V.Undef, ((V)(((-0.4) * ToNum(z_843)))))), " 0;", ToStr(Call(f1_16, V.Undef, ((V)((0.25 * ToNum(z_843)))))), " 0;0 0"))), ((V)(3.4)), ((V)(0D)), ((V)(" keyTimes=\"0;0.72;0.78;0.84;0.9;1\"")))), ToStr(box_851), "</g>"));
dp_852 = Call(cE_49, V.Undef, G_725, ((V)((u0_836 + (du_729 * 0.6)))), ((V)((t0_837 + dt_730))));
y0_853 = Get(dp_852, "y");
KT_854 = ((V)(" keyTimes=\"0;0.7;0.86;0.87;1\" dur=\"7s\" repeatCount=\"indefinite\""));
ov_741.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, Get(dp_852, "x"))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, y0_853)), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.55 * ToNum(z_843)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(z_843)))))), "\" fill=\"#8a6420\"><animate attributeName=\"ry\" values=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(z_843)))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((0.9 * ToNum(z_843)))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((1.1 * ToNum(z_843)))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(z_843)))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(z_843)))))), "\"", ToStr(KT_854), "/><animate attributeName=\"cy\" values=\"", ToStr(Call(f1_16, V.Undef, y0_853)), ";", ToStr(Call(f1_16, V.Undef, Add(y0_853, ((V)((0.5 * ToNum(z_843))))))), ";", ToStr(Call(f1_16, V.Undef, Add(y0_853, ((V)((9D * ToNum(z_843))))))), ";", ToStr(Call(f1_16, V.Undef, y0_853)), ";", ToStr(Call(f1_16, V.Undef, y0_853)), "\"", ToStr(KT_854), "/><animate attributeName=\"opacity\" values=\"0.9;0.95;0;0;0.9\"", ToStr(KT_854), "/></ellipse>"));
}
gu_742 = new JsStrBuf("");
{
double i_880 = 0;
i_880 = 0D;
while (true) {
if (!((i_880 <= NU_727))) break;
gu_742.S("M").V(Invoke(G_725, "P", ((V)((i_880 * du_729))), ((V)(0D)))).S("L").V(Invoke(G_725, "P", ((V)((i_880 * du_729))), ((V)(1D))));
i_880++;
}
}
s_736.S(string.Concat("<path d=\"", gu_742.Str, "\" stroke=\"#7a6e56\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.6 * ToNum(Get(G_725, "s"))))))), "\" opacity=\"0.45\" transform=\"translate(", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(Get(G_725, "s"))))))), " 0)\"/><path d=\"", gu_742.Str, "\" stroke=\"#e9e2cc\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.1 * ToNum(Get(G_725, "s"))))))), "\"/>"));
{
double j_882 = 0;
j_882 = 1D;
while (true) {
if (!((j_882 < NT_728))) break;
V y_884 = default;
V z_885 = default;
V d_886 = default;
y_884 = Invoke(G_725, "y", ((V)((j_882 * dt_730))));
z_885 = Invoke(G_725, "z", y_884);
d_886 = Invoke(G_725, "hl", y_884);
s_736.S(string.Concat("<path d=\"", ToStr(d_886), "\" stroke=\"#7a6e56\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.5 * ToNum(z_885)))))), "\" opacity=\"0.45\" transform=\"translate(0 ", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(z_885)))))), ")\"/><path d=\"", ToStr(d_886), "\" stroke=\"#ece5d0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.1 * ToNum(z_885)))))), "\"/><path d=\"", ToStr(d_886), "\" stroke=\"#fffbf0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(z_885)))))), "\" transform=\"translate(0 ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.3) * ToNum(z_885)))))), ")\"/>"));
j_882++;
}
}
s_736.S("<g filter=\"url(#cb6)\">").V(Invoke(Invoke(Arr(Arr(((V)(0.16)), ((V)(0.75)), ((V)(30D))), Arr(((V)(0.3)), ((V)(0.92)), ((V)(22D))), Arr(((V)(0.06)), ((V)(0.55)), ((V)(18D)))), "map", Fn((V _arrowThis900, int _argc887, V _a889, V _a890, V _a891, V _a892, V[] _rest888) => {
V P_901 = default;
V u_895 = default;
V t_897 = default;
V r_899 = default;
{ V _t893 = ListOf(_a889);
{ V _t894 = GetIdx(_t893, 0D);
u_895 = _t894; }
{ V _t896 = GetIdx(_t893, 1D);
t_897 = _t896; }
{ V _t898 = GetIdx(_t893, 2D);
r_899 = _t898; }
}
P_901 = Call(cE_49, V.Undef, G_725, u_895, t_897);
return Call(cEl_52, V.Undef, P_901, ((V)((ToNum(r_899) * ToNum(Get(P_901, "z"))))), ((V)((5D * ToNum(Get(P_901, "z"))))), ((V)("fill=\"#8a6424\" opacity=\"0.16\"")));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g>");
{
double u0_902 = 0;
double u1_903 = 0;
double t0_904 = 0;
double t1_905 = 0;
V A_906 = default;
V B_907 = default;
V C2_908 = default;
V D2_909 = default;
double d_910 = 0;
V m_911 = default;
V poly_912 = default;
V ed_913 = default;
u0_902 = (ToNum(GetIdx(SG_734, 0D)) * du_729);
u1_903 = (u0_902 + du_729);
t0_904 = (ToNum(GetIdx(SG_734, 1D)) * dt_730);
t1_905 = (t0_904 + dt_730);
A_906 = Call(cE_49, V.Undef, G_725, ((V)(u0_902)), ((V)(t0_904)));
B_907 = Call(cE_49, V.Undef, G_725, ((V)(u1_903)), ((V)(t0_904)));
C2_908 = Call(cE_49, V.Undef, G_725, ((V)(u1_903)), ((V)(t1_905)));
D2_909 = Call(cE_49, V.Undef, G_725, ((V)(u0_902)), ((V)(t1_905)));
d_910 = (4.5 * ToNum(Get(B_907, "z")));
m_911 = Call(cE_49, V.Undef, G_725, ((V)((u0_902 + (du_729 * 0.62)))), ((V)((t0_904 + (dt_730 * 0.45)))));
poly_912 = ((V)(string.Concat("M", ToStr(Call(f1_16, V.Undef, Get(A_906, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(A_906, "y"))), "L", ToStr(Call(f1_16, V.Undef, Get(B_907, "x"))), " ", ToStr(Call(f1_16, V.Undef, Add(Get(B_907, "y"), ((V)(d_910))))), "L", ToStr(Call(f1_16, V.Undef, Get(C2_908, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(C2_908, "y"))), "L", ToStr(Call(f1_16, V.Undef, Get(D2_909, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(D2_909, "y"))), "Z")));
ed_913 = ((V)(string.Concat("M", ToStr(Call(f1_16, V.Undef, Get(A_906, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(A_906, "y"))), "L", ToStr(Call(f1_16, V.Undef, Get(B_907, "x"))), " ", ToStr(Call(f1_16, V.Undef, Add(Get(B_907, "y"), ((V)(d_910))))))));
ov_741.S(string.Concat("<defs><radialGradient id=\"k27w\" gradientUnits=\"userSpaceOnUse\" cx=\"", ToStr(Call(f1_16, V.Undef, Get(m_911, "x"))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, Get(m_911, "y"))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(Get(B_907, "x")) - ToNum(Get(A_906, "x"))) * 0.6))))), "\"><stop offset=\"0\" stop-color=\"#b3935a\"/><stop offset=\"0.6\" stop-color=\"#cdb98e\"/><stop offset=\"1\" stop-color=\"#ddd2b6\"/></radialGradient></defs>")).S(string.Concat("<path d=\"", ToStr(poly_912), "\" fill=\"#000000\" opacity=\"0.25\" filter=\"url(#cb1)\" transform=\"translate(0 ", ToStr(Call(f1_16, V.Undef, ((V)((0.8 * ToNum(Get(B_907, "z"))))))), ")\"/><path d=\"", ToStr(poly_912), "\" fill=\"url(#k27w)\"/>")).S(string.Concat("<path d=\"", ToStr(ed_913), "\" stroke=\"#8a7a5c\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(Get(B_907, "z"))))))), "\" transform=\"translate(0 ", ToStr(Call(f1_16, V.Undef, ((V)((0.7 * ToNum(Get(B_907, "z"))))))), ")\"/><path d=\"", ToStr(ed_913), "\" stroke=\"#f4eedf\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1D * ToNum(Get(B_907, "z"))))))), "\"/>")).V(Call(cStain_56, V.Undef, G_725, ((V)((u0_902 + (du_729 * 0.55)))), ((V)((t0_904 + (dt_730 * 0.55)))), ((V)(10D)), ((V)("ks3")))).S(string.Concat("<path d=\"M", ToStr(Invoke(G_725, "P", ((V)((u0_902 + (du_729 * 0.3)))), ((V)((t0_904 + (dt_730 * 0.25)))))), "L", ToStr(Invoke(G_725, "P", ((V)((u0_902 + (du_729 * 0.42)))), ((V)((t0_904 + (dt_730 * 0.5)))))), "L", ToStr(Invoke(G_725, "P", ((V)((u0_902 + (du_729 * 0.38)))), ((V)((t0_904 + (dt_730 * 0.7)))))), "L", ToStr(Invoke(G_725, "P", ((V)((u0_902 + (du_729 * 0.5)))), ((V)((t1_905 - (dt_730 * 0.05)))))), "\" stroke=\"#6e5a38\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(Get(G_725, "s"))))))), "\" fill=\"none\"/>"));
}
ov_741.V(Add(Call(cWeb_57, V.Undef, G_725, ((V)(0.995)), ((V)(1D)), ((V)(1.1)), ((V)(1D)), ((V)("#d8cfb6"))), Call(cWeb_57, V.Undef, G_725, ((V)(0.008)), ((V)(0.99)), ((V)(0.9)), ((V)(0D)), ((V)("#d8cfb6")))));
{
V P_914 = default;
V z_915 = default;
V c_916 = default;
P_914 = Call(cE_49, V.Undef, G_725, ((V)(0.93)), ((V)(0.62)));
z_915 = Get(P_914, "z");
c_916 = ((V)(string.Concat(ToStr(Call(f1_16, V.Undef, Get(P_914, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(P_914, "y"))))));
ov_741.S(string.Concat("<g>", ToStr(Call(at_47, V.Undef, ((V)("rotate")), ((V)(string.Concat("-8 ", ToStr(c_916), ";8 ", ToStr(c_916), ";-8 ", ToStr(c_916)))), ((V)(4.6)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "<path d=\"M", ToStr(c_916), "q", ToStr(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(z_915)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((4D * ToNum(z_915)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.3) * ToNum(z_915)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((8D * ToNum(z_915)))))), "\" stroke=\"#7a6a4a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(z_915)))))), "\" fill=\"none\" opacity=\"0.7\"/><ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Get(P_914, "x")) - (0.3 * ToNum(z_915))))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, Add(Get(P_914, "y"), ((V)((8D * ToNum(z_915))))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.8 * ToNum(z_915)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(z_915)))))), "\" fill=\"#6a5a3e\" opacity=\"0.7\"/></g>"));
}
return ((V)(JsStrBuf.Begin().S(s_736.Str).S(ov_741.Str).V(Call(cShade_53, V.Undef, G_725, ((V)(0.32)), ((V)(0.05)))).V(Call(mould_44, V.Undef, G_725, ((V)(2.4)), Arr(((V)("#ddd5bd"))), ((V)("#f8f3e4")))).End()));
return default;
}, 1, "cAcou", false);
cBead_59 = Fn((V _self917, int _argc918, V G_924, V _a921, V _a922, V _a923, V[] _rest919) => {
V R_925 = default;
double NB_926 = 0;
V BC_927 = default;
JsStrBuf s_928 = null;
JsStrBuf gv_929 = null;
JsStrBuf hl_930 = null;
JsStrBuf cg_931 = null;
JsStrBuf ch_932 = null;
JsStrBuf jn_933 = null;
JsStrBuf nl_934 = null;
JsStrBuf bL_935 = null;
JsStrBuf bD_936 = null;
JsStrBuf dr_937 = null;
if (_self917.IsNullish) _self917 = GlobalV;
R_925 = Call(rng_13, V.Undef, ((V)("bead27")));
NB_926 = 46D;
BC_927 = Arr(((V)("#f4ecd6")), ((V)("#f1e8d0")), ((V)("#f6efdc")), ((V)("#efe5cb")));
s_928 = new JsStrBuf(string.Concat("<path d=\"", ToStr(Get(G_924, "tr")), "\" fill=\"#f2e9d2\"/>"));
gv_929 = new JsStrBuf("");
hl_930 = new JsStrBuf("");
cg_931 = new JsStrBuf("");
ch_932 = new JsStrBuf("");
jn_933 = new JsStrBuf("");
nl_934 = new JsStrBuf("");
bL_935 = new JsStrBuf("");
bD_936 = new JsStrBuf("");
dr_937 = new JsStrBuf("");
{
double i_938 = 0;
i_938 = 0D;
while (true) {
if (!((i_938 < NB_926))) break;
double u0_940 = 0;
double u1_941 = 0;
double cu_942 = 0;
double bw_943 = 0;
u0_940 = (((i_938 / NB_926) * 1.1) - 0.05);
u1_941 = ((((i_938 + 1D) / NB_926) * 1.1) - 0.05);
cu_942 = ((u0_940 + u1_941) / 2D);
bw_943 = (u1_941 - u0_940);
s_928.S(string.Concat("<path d=\"", ToStr(Invoke(G_924, "quad", ((V)(u0_940)), ((V)(0D)), ((V)(u1_941)), ((V)(1D)))), "\" fill=\"", ToStr(Call(shade_10, V.Undef, GetIdx(BC_927, (((i_938 * 3D) + ((double)(ToInt32((ToNum(Call(R_925, V.Undef)) * 3D)) | ToInt32(0D)))) % 4D)), ((V)((0.985 + (ToNum(Call(R_925, V.Undef)) * 0.03)))))), "\"/>"));
gv_929.S("M").V(Invoke(G_924, "P", ((V)(u0_940)), ((V)(0D)))).S("L").V(Invoke(G_924, "P", ((V)(u0_940)), ((V)(1D))));
hl_930.S("M").V(Invoke(G_924, "P", ((V)((u0_940 + (bw_943 * 0.12)))), ((V)(0D)))).S("L").V(Invoke(G_924, "P", ((V)((u0_940 + (bw_943 * 0.12)))), ((V)(1D))));
cg_931.S("M").V(Invoke(G_924, "P", ((V)(cu_942)), ((V)(0D)))).S("L").V(Invoke(G_924, "P", ((V)(cu_942)), ((V)(1D))));
ch_932.S("M").V(Invoke(G_924, "P", ((V)((cu_942 + (bw_943 * 0.1)))), ((V)(0D)))).S("L").V(Invoke(G_924, "P", ((V)((cu_942 + (bw_943 * 0.1)))), ((V)(1D))));
if (((i_938 % 3D) == 1D)) {
double t_944 = 0;
t_944 = (0.15 + (ToNum(Call(R_925, V.Undef)) * 0.7));
jn_933.S("M").V(Invoke(G_924, "P", ((V)(u0_940)), ((V)(t_944)))).S("L").V(Invoke(G_924, "P", ((V)(u1_941)), ((V)(t_944))));
}
if (((i_938 % 2D) == 0D)) {
Invoke(Arr(((V)(0.2)), ((V)(0.5)), ((V)(0.82))), "forEach", Fn((V _arrowThis952, int _argc945, V t_951, V _a948, V _a949, V _a950, V[] _rest946) => {
V P_953 = default;
P_953 = Call(cE_49, V.Undef, G_924, ((V)((u0_940 + (bw_943 * 0.3)))), t_951);
nl_934.V(Call(cD_51, V.Undef, Get(P_953, "x"), Get(P_953, "y"), ((V)((0.32 * ToNum(Get(P_953, "z"))))), ((V)(((0.32 * ToNum(Get(P_953, "z"))) * ToNum(Get(P_953, "q")))))));
return default;
}, 1, "", true));
}
Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis960, int _argc954, V _a956, V _a957, V _a958, V _a959, V[] _rest955) => {
double u_961 = 0;
double t_962 = 0;
V d_963 = default;
u_961 = (u0_940 + (bw_943 * (0.2 + (ToNum(Call(R_925, V.Undef)) * 0.6))));
t_962 = (ToNum(Call(R_925, V.Undef)) * 0.9);
d_963 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(G_924, "P", ((V)(u_961)), ((V)(t_962)))).S("L").V(Invoke(G_924, "P", ((V)((u_961 + ((ToNum(Call(R_925, V.Undef)) - 0.5) * 0.002)))), ((V)(((t_962 + 0.04) + (ToNum(Call(R_925, V.Undef)) * 0.12)))))).End()));
if (LtN(Call(R_925, V.Undef), 0.5)) {
bL_935.V(d_963);
} else {
bD_936.V(d_963);
}
return default;
}, 0, "", true));
if (LtN(Call(R_925, V.Undef), 0.14)) {
V P_964 = default;
P_964 = Call(cE_49, V.Undef, G_924, ((V)(u0_940)), ((V)((0.1 + (ToNum(Call(R_925, V.Undef)) * 0.8)))));
dr_937.V(Call(cEl_52, V.Undef, P_964, ((V)((0.6 * ToNum(Get(P_964, "z"))))), ((V)(((1.1 * ToNum(Get(P_964, "z"))) * ToNum(Get(P_964, "q"))))), ((V)(string.Concat("fill=\"#f8f1de\" stroke=\"#d6c8a6\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.2 * ToNum(Get(P_964, "z"))))))), "\"")))));
}
i_938++;
}
}
s_928.S("<g filter=\"url(#cb1)\">").V(Invoke(Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis971, int _argc965, V _a967, V _a968, V _a969, V _a970, V[] _rest966) => {
V P_972 = default;
P_972 = Call(cE_49, V.Undef, G_924, Call(R_925, V.Undef), ((V)((0.08 + (ToNum(Call(R_925, V.Undef)) * 0.85)))));
return Call(cEl_52, V.Undef, P_972, ((V)((1.6 * ToNum(Get(P_972, "z"))))), ((V)((0.9 * ToNum(Get(P_972, "z"))))), ((V)("fill=\"#c9ae78\" opacity=\"0.28\"")));
return default;
}, 0, "", true)), "join", ((V)("")))).S("</g>");
s_928.S(string.Concat("<path d=\"", bL_935.Str, "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(Get(G_924, "s"))))))), "\" opacity=\"0.4\"/><path d=\"", bD_936.Str, "\" stroke=\"#d9cba8\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(Get(G_924, "s"))))))), "\" opacity=\"0.4\"/>")).S(string.Concat("<path d=\"", cg_931.Str, "\" stroke=\"#cbb98f\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.55 * ToNum(Get(G_924, "s"))))))), "\"/><path d=\"", ch_932.Str, "\" stroke=\"#fffaf0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(Get(G_924, "s"))))))), "\" opacity=\"0.8\"/>")).S(string.Concat("<path d=\"", gv_929.Str, "\" stroke=\"#b4a27a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1D * ToNum(Get(G_924, "s"))))))), "\"/><path d=\"", hl_930.Str, "\" stroke=\"#fffaf0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.7 * ToNum(Get(G_924, "s"))))))), "\"/><path d=\"", jn_933.Str, "\" stroke=\"#b4a27a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(Get(G_924, "s"))))))), "\"/>")).S(string.Concat("<path d=\"", nl_934.Str, "\" fill=\"#a8987a\"/>", dr_937.Str));
Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis980, int _argc973, V i_979, V _a976, V _a977, V _a978, V[] _rest974) => {
double u_981 = 0;
V a_982 = default;
V b_983 = default;
V m_984 = default;
double dur_985 = 0;
V bg_986 = default;
V KT_987 = default;
V d_988 = default;
u_981 = (0.26 + ((ToNum(i_979) % 3D) * 0.04));
a_982 = Call(cE_49, V.Undef, G_924, ((V)(u_981)), ((V)(0.99)));
b_983 = Call(cE_49, V.Undef, G_924, ((V)((u_981 + (NumTruthy((ToNum(i_979) % 2D)) ? 0.05 : (-0.04))))), ((V)((0.48 + ((ToNum(i_979) % 3D) * 0.06)))));
m_984 = Call(cE_49, V.Undef, G_924, ((V)(u_981)), ((V)(0.8)));
dur_985 = 8D;
bg_986 = Call(n4_17, V.Undef, ((V)((((-ToNum(i_979)) * dur_985) / 7D))));
KT_987 = ((V)(string.Concat(" keyTimes=\"0;0.25;1\" dur=\"", NumStr(dur_985), "s\" begin=\"", ToStr(bg_986), "s\" repeatCount=\"indefinite\"")));
d_988 = ((V)(string.Concat("M", ToStr(Call(f1_16, V.Undef, Get(a_982, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(a_982, "y"))), "Q", ToStr(Call(f1_16, V.Undef, Add(Get(m_984, "x"), ((V)(((NumTruthy((ToNum(i_979) % 2D)) ? 6D : (-6D)) * ToNum(Get(m_984, "z")))))))), " ", ToStr(Call(f1_16, V.Undef, Get(m_984, "y"))), " ", ToStr(Call(f1_16, V.Undef, Get(b_983, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(b_983, "y"))))));
s_928.S(string.Concat("<ellipse cx=\"0\" cy=\"0\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((5D * ToNum(Get(a_982, "z"))))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.6 * ToNum(Get(a_982, "z"))))))), "\" fill=\"#ffffff\" filter=\"url(#cb3)\" opacity=\"0\"><animateMotion path=\"", ToStr(d_988), "\" dur=\"", NumStr(dur_985), "s\" begin=\"", ToStr(bg_986), "s\" repeatCount=\"indefinite\"/>")).S(string.Concat("<animate attributeName=\"rx\" values=\"", ToStr(Call(f1_16, V.Undef, ((V)((4D * ToNum(Get(a_982, "z"))))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((9D * ToNum(Get(a_982, "z"))))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((18D * ToNum(Get(b_983, "z"))))))), "\"", ToStr(KT_987), "/><animate attributeName=\"ry\" values=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.4 * ToNum(Get(a_982, "z"))))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((2.4 * ToNum(Get(a_982, "z"))))))), ";", ToStr(Call(f1_16, V.Undef, ((V)((4.5 * ToNum(Get(b_983, "z"))))))), "\"", ToStr(KT_987), "/><animate attributeName=\"opacity\" values=\"0;0.7;0\"", ToStr(KT_987), "/></ellipse>"));
return default;
}, 1, "", true));
{
V P_989 = default;
V z_990 = default;
V hx_991 = default;
V hy_992 = default;
V ty_993 = default;
V Rr_994 = default;
JsStrBuf sp_995 = null;
P_989 = Call(cE_49, V.Undef, G_924, ((V)(0.7)), ((V)(0.36)));
z_990 = Get(P_989, "z");
hx_991 = Get(P_989, "x");
hy_992 = Get(P_989, "y");
ty_993 = Add(hy_992, ((V)((4.5 * ToNum(z_990)))));
Rr_994 = Call(rng_13, V.Undef, ((V)("herb27")));
sp_995 = new JsStrBuf("");
Call(rep_18, V.Undef, ((V)(11D)), Fn((V _arrowThis1003, int _argc996, V k_1002, V _a999, V _a1000, V _a1001, V[] _rest997) => {
double a_1004 = 0;
double L_1005 = 0;
V ex_1006 = default;
V ey_1007 = default;
V col_1008 = default;
a_1004 = (((ToNum(k_1002) - 5D) * 0.11) + ((ToNum(Call(Rr_994, V.Undef)) - 0.5) * 0.06));
L_1005 = ((7D + (ToNum(Call(Rr_994, V.Undef)) * 4D)) * ToNum(z_990));
ex_1006 = Add(hx_991, ((V)((FdLibm.Sin(a_1004) * L_1005))));
ey_1007 = Add(ty_993, ((V)((FdLibm.Cos(a_1004) * L_1005))));
col_1008 = GetIdx(Arr(((V)("#5e7a44")), ((V)("#6d8a4e")), ((V)("#7f9a58")), ((V)("#56703e"))), (ToNum(k_1002) % 4D));
sp_995.S(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, hx_991)), " ", ToStr(Call(f1_16, V.Undef, ty_993)), "Q", ToStr(Call(f1_16, V.Undef, Add(Add(hx_991, ((V)(((FdLibm.Sin(a_1004) * L_1005) * 0.5)))), ((V)(((ToNum(Call(Rr_994, V.Undef)) - 0.5) * ToNum(z_990))))))), " ", ToStr(Call(f1_16, V.Undef, Add(ty_993, ((V)((L_1005 * 0.5)))))), " ", ToStr(Call(f1_16, V.Undef, ex_1006)), " ", ToStr(Call(f1_16, V.Undef, ey_1007)), "\" stroke=\"", ToStr(col_1008), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(z_990)))))), "\" fill=\"none\" stroke-linecap=\"round\"/>"));
Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis1016, int _argc1009, V q_1015, V _a1012, V _a1013, V _a1014, V[] _rest1010) => {
double f_1017 = 0;
V x_1018 = default;
V y_1019 = default;
f_1017 = (0.3 + (ToNum(q_1015) * 0.17));
x_1018 = Add(hx_991, ((V)(((ToNum(ex_1006) - ToNum(hx_991)) * f_1017))));
y_1019 = Add(ty_993, ((V)(((ToNum(ey_1007) - ToNum(ty_993)) * f_1017))));
sp_995.S(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, x_1018)), " ", ToStr(Call(f1_16, V.Undef, y_1019)), "l", ToStr(Call(f1_16, V.Undef, ((V)((((NumTruthy((ToNum(q_1015) % 2D)) ? 1D : (-1D)) * 1.1) * ToNum(z_990)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.7 * ToNum(z_990)))))), "\" stroke=\"", ToStr(col_1008), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(z_990)))))), "\" stroke-linecap=\"round\"/>"));
return default;
}, 1, "", true));
if (((ToNum(k_1002) % 3D) == 0D)) {
sp_995.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ex_1006)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ey_1007)), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(z_990)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.1 * ToNum(z_990)))))), "\" fill=\"#8e7bb0\" transform=\"rotate(", ToStr(Call(f1_16, V.Undef, ((V)(((-a_1004) * 57D))))), " ", ToStr(Call(f1_16, V.Undef, ex_1006)), " ", ToStr(Call(f1_16, V.Undef, ey_1007)), ")\"/>"));
}
return default;
}, 1, "", true));
s_928.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, hx_991)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, hy_992)), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.8 * ToNum(z_990)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(z_990)))))), "\" fill=\"none\" stroke=\"#b08a4a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(z_990)))))), "\"/><g>", ToStr(Call(at_47, V.Undef, ((V)("rotate")), ((V)(string.Concat("-3 ", ToStr(Call(f1_16, V.Undef, hx_991)), " ", ToStr(Call(f1_16, V.Undef, hy_992)), ";3 ", ToStr(Call(f1_16, V.Undef, hx_991)), " ", ToStr(Call(f1_16, V.Undef, hy_992)), ";-3 ", ToStr(Call(f1_16, V.Undef, hx_991)), " ", ToStr(Call(f1_16, V.Undef, hy_992))))), ((V)(5.2)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))))).S(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, hx_991)), " ", ToStr(Call(f1_16, V.Undef, hy_992)), "V", ToStr(Call(f1_16, V.Undef, ty_993)), "\" stroke=\"#b89466\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(z_990)))))), "\"/>", sp_995.Str, "<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(hx_991) - (1.1 * ToNum(z_990))))))), " ", ToStr(Call(f1_16, V.Undef, Add(ty_993, ((V)((0.6 * ToNum(z_990))))))), "h", ToStr(Call(f1_16, V.Undef, ((V)((2.2 * ToNum(z_990)))))), "\" stroke=\"#c9a46a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.9 * ToNum(z_990)))))), "\" stroke-linecap=\"round\"/></g>"));
}
return ((V)(JsStrBuf.Begin().S(s_928.Str).V(Call(cShade_53, V.Undef, G_924, ((V)(0.24)), ((V)(0.05)))).V(Call(mould_44, V.Undef, G_924, ((V)(3.4)), Arr(((V)("#e6dcc0")), ((V)("#f4ecd8")), ((V)("#fffbf1"))), ((V)("#ffffff")))).End()));
return default;
}, 1, "cBead", false);
cPots_60 = Fn((V _self1020, int _argc1021, V G_1027, V _a1024, V _a1025, V _a1026, V[] _rest1022) => {
JsStrBuf s_1028 = null;
V can_1029 = default;
if (_self1020.IsNullish) _self1020 = GlobalV;
s_1028 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<path d=\"", ToStr(Get(G_1027, "tr")), "\" fill=\"#f4f3ef\"/>")).V(Call(cBlots_55, V.Undef, G_1027, ((V)("pot27b")), ((V)(8D)), Arr(((V)("#ffffff")), ((V)("#e7e5df"))), ((V)(0.5)), ((V)(90D)))).S(string.Concat("<defs><linearGradient id=\"k27v\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0.45\" stop-color=\"#9caf8b\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#9caf8b\" stop-opacity=\"0.2\"/></linearGradient>", "")).S("<radialGradient id=\"k27l\"><stop offset=\"0\" stop-color=\"#fffdf6\"/><stop offset=\"0.55\" stop-color=\"#fff3d2\"/><stop offset=\"1\" stop-color=\"#f2d9a0\"/></radialGradient><radialGradient id=\"k27h\"><stop offset=\"0\" stop-color=\"#fff2d2\" stop-opacity=\"0.6\"/><stop offset=\"1\" stop-color=\"#fff2d2\" stop-opacity=\"0\"/></radialGradient></defs>").S(string.Concat("<path d=\"", ToStr(Get(G_1027, "tr")), "\" fill=\"url(#k27v)\"/>")).End());
can_1029 = Fn((V _arrowThis1038, int _argc1030, V u_1036, V t_1037, V _a1034, V _a1035, V[] _rest1031) => {
V P_1039 = default;
V z_1040 = default;
double r_1041 = 0;
double ry_1042 = 0;
V L_1043 = default;
P_1039 = Call(cE_49, V.Undef, G_1027, u_1036, t_1037);
z_1040 = Get(P_1039, "z");
r_1041 = (10D * ToNum(z_1040));
ry_1042 = (r_1041 * ToNum(Get(P_1039, "q")));
L_1043 = NewObj(4).Put("x", Get(P_1039, "x")).Put("y", Call(cHi_50, V.Undef, G_1027, Get(P_1039, "y"), ((V)(1.02)))).Put("z", z_1040).Put("q", Get(P_1039, "q")).V;
return Add(Add(Add(Add(Add(Add(Add(Call(cEl_52, V.Undef, P_1039, ((V)((r_1041 * 2.6))), ((V)((ry_1042 * 2.6))), ((V)("fill=\"url(#k27h)\""))), Call(cEl_52, V.Undef, P_1039, ((V)((r_1041 * 1.04))), ((V)((ry_1042 * 1.04))), ((V)("fill=\"#000000\" opacity=\"0.12\"")), ((V)((0.5 * ToNum(z_1040)))))), Call(cEl_52, V.Undef, P_1039, ((V)(r_1041)), ((V)(ry_1042)), ((V)(string.Concat("fill=\"#fbfaf7\" stroke=\"#cdc9c0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(Get(G_1027, "s"))))))), "\""))))), Call(cEl_52, V.Undef, P_1039, ((V)((r_1041 * 0.8))), ((V)((ry_1042 * 0.8))), ((V)("fill=\"#d6d2c8\"")))), Invoke(Invoke(Arr(((V)(0.74)), ((V)(0.66)), ((V)(0.58))), "map", Fn((V _arrowThis1052, int _argc1044, V k_1050, V i_1051, V _a1048, V _a1049, V[] _rest1045) => {
return Call(cEl_52, V.Undef, NewObj(2).Put("x", Get(P_1039, "x")).Put("y", Add(Get(P_1039, "y"), ((V)((((ToNum(Get(L_1043, "y")) - ToNum(Get(P_1039, "y"))) * ToNum(Add(i_1051, ((V)(1D))))) / 4D))))).V, ((V)((r_1041 * ToNum(k_1050)))), ((V)((ry_1042 * ToNum(k_1050)))), ((V)(string.Concat("fill=\"none\" stroke=\"#bcb7ac\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.25 * ToNum(Get(G_1027, "s"))))))), "\""))));
}, 2, "", true)), "join", ((V)("")))), Call(cEl_52, V.Undef, L_1043, ((V)((r_1041 * 0.6))), ((V)((ry_1042 * 0.6))), ((V)("fill=\"#fff6dc\" opacity=\"0.7\" filter=\"url(#cb1)\"")))), Call(cEl_52, V.Undef, L_1043, ((V)((r_1041 * 0.44))), ((V)((ry_1042 * 0.44))), ((V)("fill=\"url(#k27l)\"")))), Call(cEl_52, V.Undef, NewObj(2).Put("x", ((V)((ToNum(Get(L_1043, "x")) - (r_1041 * 0.15))))).Put("y", ((V)((ToNum(Get(L_1043, "y")) - (ry_1042 * 0.12))))).V, ((V)((r_1041 * 0.14))), ((V)((ry_1042 * 0.1))), ((V)("fill=\"#ffffff\""))));
return default;
}, 2, "", true);
Invoke(Arr(((V)(0.3)), ((V)(0.7))), "forEach", Fn((V _arrowThis1060, int _argc1053, V t_1059, V _a1056, V _a1057, V _a1058, V[] _rest1054) => {
return Invoke(Arr(((V)(0.14)), ((V)(0.38)), ((V)(0.62)), ((V)(0.86))), "forEach", Fn((V _arrowThis1068, int _argc1061, V u_1067, V _a1064, V _a1065, V _a1066, V[] _rest1062) => {
return ((V)(s_1028.V(Call(can_1029, V.Undef, u_1067, t_1059)).Str));
}, 1, "", true));
}, 1, "", true));
{
V P_1069 = default;
V z_1070 = default;
double r_1071 = 0;
double ry_1072 = 0;
JsStrBuf h_1073 = null;
P_1069 = Call(cE_49, V.Undef, G_1027, ((V)(0.5)), ((V)(0.5)));
z_1070 = Get(P_1069, "z");
r_1071 = (11D * ToNum(z_1070));
ry_1072 = (r_1071 * ToNum(Get(P_1069, "q")));
h_1073 = new JsStrBuf("");
{
double a_1074 = 0;
a_1074 = (-1D);
while (true) {
if (!((a_1074 <= 1.001))) break;
{
double b_1076 = 0;
b_1076 = (-1D);
while (true) {
if (!((b_1076 <= 1.001))) break;
if ((((a_1074 * a_1074) + (b_1076 * b_1076)) < 0.86)) {
h_1073.V(Call(cD_51, V.Undef, Add(Get(P_1069, "x"), ((V)((a_1074 * r_1071)))), Add(Get(P_1069, "y"), ((V)((b_1076 * ry_1072)))), ((V)((0.18 * ToNum(z_1070)))), ((V)(((0.18 * ToNum(z_1070)) * ToNum(Get(P_1069, "q")))))));
}
b_1076 = (b_1076 + 0.11);
}
}
a_1074 = (a_1074 + 0.085);
}
}
s_1028.V(Add(Call(cEl_52, V.Undef, P_1069, ((V)((r_1071 * 1.06))), ((V)((ry_1072 * 1.06))), ((V)("fill=\"#000000\" opacity=\"0.1\"")), ((V)((0.4 * ToNum(z_1070))))), Call(cEl_52, V.Undef, P_1069, ((V)(r_1071)), ((V)(ry_1072)), ((V)(string.Concat("fill=\"#fbfaf7\" stroke=\"#cfcbc2\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(Get(G_1027, "s"))))))), "\"")))))).S(string.Concat("<path d=\"", h_1073.Str, "\" fill=\"#bfbab0\"/>"));
}
s_1028.S(string.Concat("<path d=\"", ToStr(Invoke(G_1027, "quad", ((V)(0.28)), ((V)(0.885)), ((V)(0.72)), ((V)(0.915)))), "\" fill=\"#2c2c2c\" stroke=\"#e6e4de\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(Get(G_1027, "s"))))))), "\"/><path d=\"M", ToStr(Invoke(G_1027, "P", ((V)(0.285)), ((V)(0.895)))), "L", ToStr(Invoke(G_1027, "P", ((V)(0.715)), ((V)(0.895)))), "M", ToStr(Invoke(G_1027, "P", ((V)(0.285)), ((V)(0.905)))), "L", ToStr(Invoke(G_1027, "P", ((V)(0.715)), ((V)(0.905)))), "\" stroke=\"#f4f3ef\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(Get(G_1027, "s"))))))), "\"/>"));
return ((V)(JsStrBuf.Begin().S(s_1028.Str).V(Call(cShade_53, V.Undef, G_1027, ((V)(0.22)), ((V)(0.05)))).V(Call(mould_44, V.Undef, G_1027, ((V)(1.4)), Arr(((V)("#4a4946"))), ((V)("#e9e7e1")))).End()));
return default;
}, 1, "cPots", false);
cTray_61 = Fn((V _self1078, int _argc1079, V G_1085, V _a1082, V _a1083, V _a1084, V[] _rest1080) => {
V R_1086 = default;
double u0_1087 = 0;
double u1_1088 = 0;
double t0_1089 = 0;
double t1_1090 = 0;
double mt_1091 = 0;
V O_1092 = default;
V hp_1093 = default;
V TS_1094 = default;
V US_1095 = default;
JsStrBuf s_1096 = null;
JsStrBuf sw_1097 = null;
JsStrBuf bn_1098 = null;
JsStrBuf v_1099 = null;
double NL_1100 = 0;
double NM_1101 = 0;
V GC_1102 = default;
double su_1103 = 0;
double st_1104 = 0;
JsStrBuf le_1105 = null;
JsStrBuf cr_1106 = null;
V side_1107 = default;
V rim_1108 = default;
if (_self1078.IsNullish) _self1078 = GlobalV;
R_1086 = Call(rng_13, V.Undef, ((V)("tray27")));
u0_1087 = 0.2;
u1_1088 = 0.8;
t0_1089 = 0.24;
t1_1090 = 0.8;
mt_1091 = 1.07;
O_1092 = Invoke(G_1085, "quad", ((V)(u0_1087)), ((V)(t0_1089)), ((V)(u1_1088)), ((V)(t1_1090)));
hp_1093 = Fn((V _arrowThis1118, int _argc1109, V u_1115, V t_1116, V m_1117, V _a1114, V[] _rest1110) => {
V y_1119 = default;
y_1119 = Invoke(G_1085, "y", t_1116);
return Arr(Invoke(G_1085, "x", u_1115, y_1119), Call(cHi_50, V.Undef, G_1085, y_1119, m_1117));
return default;
}, 3, "", true);
TS_1094 = Call(rep_18, V.Undef, ((V)(13D)), Fn((V _arrowThis1127, int _argc1120, V i_1126, V _a1123, V _a1124, V _a1125, V[] _rest1121) => {
return ((V)((t0_1089 + (((t1_1090 - t0_1089) * ToNum(i_1126)) / 12D))));
}, 1, "", true));
US_1095 = Call(rep_18, V.Undef, ((V)(25D)), Fn((V _arrowThis1135, int _argc1128, V i_1134, V _a1131, V _a1132, V _a1133, V[] _rest1129) => {
return ((V)((u0_1087 + (((u1_1088 - u0_1087) * ToNum(i_1134)) / 24D))));
}, 1, "", true));
s_1096 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<path d=\"", ToStr(Get(G_1085, "tr")), "\" fill=\"#eee2cc\"/>")).V(Call(cBlots_55, V.Undef, G_1085, ((V)("tray27b")), ((V)(10D)), Arr(((V)("#f8f0e2")), ((V)("#dccbb0")), ((V)("#f3e8d6"))), ((V)(0.55)), ((V)(60D)))).End());
sw_1097 = new JsStrBuf("");
bn_1098 = new JsStrBuf("");
Call(rep_18, V.Undef, ((V)(80D)), Fn((V _arrowThis1142, int _argc1136, V _a1138, V _a1139, V _a1140, V _a1141, V[] _rest1137) => {
V P_1143 = default;
double rx_1144 = 0;
double a0_1145 = 0;
double a1_1146 = 0;
V d_1147 = default;
P_1143 = Call(cE_49, V.Undef, G_1085, ((V)(((ToNum(Call(R_1086, V.Undef)) * 1.1) - 0.05))), ((V)((0.03 + (ToNum(Call(R_1086, V.Undef)) * 0.95)))));
rx_1144 = ((8D + (ToNum(Call(R_1086, V.Undef)) * 18D)) * ToNum(Get(P_1143, "z")));
a0_1145 = ((ToNum(Call(R_1086, V.Undef)) * 2D) * PI_11);
a1_1146 = ((a0_1145 + 0.9) + (ToNum(Call(R_1086, V.Undef)) * 1.3));
d_1147 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis1155, int _argc1148, V k_1154, V _a1151, V _a1152, V _a1153, V[] _rest1149) => {
double a_1156 = 0;
a_1156 = (a0_1145 + (((a1_1146 - a0_1145) * ToNum(k_1154)) / 8D));
return Call(P2_48, V.Undef, Arr(Add(Get(P_1143, "x"), ((V)((FdLibm.Cos(a_1156) * rx_1144)))), Add(Get(P_1143, "y"), ((V)(((FdLibm.Sin(a_1156) * rx_1144) * ToNum(Get(P_1143, "q"))))))));
return default;
}, 1, "", true)), "join", ((V)("L")))).End()));
if (LtN(Call(R_1086, V.Undef), 0.75)) {
sw_1097.S(string.Concat("<path d=\"", ToStr(d_1147), "\" stroke=\"", (LtN(Call(R_1086, V.Undef), 0.5) ? "#fbf4e6" : "#d6c4a4"), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)(((2D + (ToNum(Call(R_1086, V.Undef)) * 3.5)) * ToNum(Get(P_1143, "z"))))))), "\" fill=\"none\" stroke-linecap=\"round\" opacity=\"0.3\"/>"));
} else {
bn_1098.V(d_1147);
}
return default;
}, 0, "", true));
s_1096.S(string.Concat("<g filter=\"url(#cb3)\">", sw_1097.Str, "</g><path d=\"", bn_1098.Str, "\" stroke=\"#fffaf0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(Get(G_1085, "s"))))))), "\" fill=\"none\" opacity=\"0.6\" stroke-linecap=\"round\"/>")).S("<g filter=\"url(#cb6)\">").V(Invoke(Invoke(Arr(Arr(((V)(0.1)), ((V)(0.3))), Arr(((V)(0.9)), ((V)(0.55))), Arr(((V)(0.5)), ((V)(0.93)))), "map", Fn((V _arrowThis1168, int _argc1157, V _a1159, V _a1160, V _a1161, V _a1162, V[] _rest1158) => {
V P_1169 = default;
V u_1165 = default;
V t_1167 = default;
{ V _t1163 = ListOf(_a1159);
{ V _t1164 = GetIdx(_t1163, 0D);
u_1165 = _t1164; }
{ V _t1166 = GetIdx(_t1163, 1D);
t_1167 = _t1166; }
}
P_1169 = Call(cE_49, V.Undef, G_1085, u_1165, t_1167);
return Call(cEl_52, V.Undef, P_1169, ((V)((40D * ToNum(Get(P_1169, "z"))))), ((V)((6D * ToNum(Get(P_1169, "z"))))), ((V)("fill=\"#ffffff\" opacity=\"0.28\"")));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g>");
v_1099 = new JsStrBuf(string.Concat(string.Concat("<defs><linearGradient id=\"k27g\" gradientUnits=\"userSpaceOnUse\" x1=\"0\" y1=\"0\" x2=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Get(G_1085, "W")) * 0.12))))), "\" y2=\"0\"><stop offset=\"0\" stop-color=\"#fff6d0\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#fff6d0\" stop-opacity=\"0.85\"/><stop offset=\"1\" stop-color=\"#fff6d0\" stop-opacity=\"0\"/>"), string.Concat("<animateTransform attributeName=\"gradientTransform\" type=\"translate\" values=\"", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(Get(G_1085, "W"))) * 0.2))))), " 0;", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(Get(G_1085, "W"))) * 0.2))))), " 0;", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Get(G_1085, "W")) * 1.1))))), " 0\" keyTimes=\"0;0.5;1\" dur=\"11s\" repeatCount=\"indefinite\"/></linearGradient></defs><rect x=\"0\" y=\"0\" width=\"", ToStr(Call(f1_16, V.Undef, Get(G_1085, "W"))), "\" height=\"", ToStr(Call(f1_16, V.Undef, Get(G_1085, "H"))), "\" fill=\"#c9a24e\"/>")));
NL_1100 = 18D;
NM_1101 = 6D;
GC_1102 = Arr(((V)("#dcb862")), ((V)("#e2bf68")), ((V)("#d6b15a")), ((V)("#e8c872")), ((V)("#dfbb64")));
su_1103 = (((u1_1088 - u0_1087) + 0.04) / NL_1100);
st_1104 = (((t1_1090 - t0_1089) + 0.02) / NM_1101);
le_1105 = new JsStrBuf("");
cr_1106 = new JsStrBuf("");
{
double j_1170 = 0;
j_1170 = 0D;
while (true) {
if (!((j_1170 < NM_1101))) break;
{
double i_1172 = 0;
i_1172 = 0D;
while (true) {
if (!((i_1172 < NL_1100))) break;
double a_1174 = 0;
double b_1175 = 0;
double c_1176 = 0;
double d_1177 = 0;
V J_1178 = default;
V Q_1179 = default;
a_1174 = ((u0_1087 - 0.02) + (su_1103 * i_1172));
b_1175 = (a_1174 + su_1103);
c_1176 = (t0_1089 + (st_1104 * j_1170));
d_1177 = (c_1176 + st_1104);
J_1178 = Fn((V _arrowThis1186, int _argc1180, V _a1182, V _a1183, V _a1184, V _a1185, V[] _rest1181) => {
return ((V)(((ToNum(Call(R_1086, V.Undef)) - 0.5) * 0.004)));
}, 0, "", true);
Q_1179 = Arr(Call(hp_1093, V.Undef, Add(((V)(a_1174)), Call(J_1178, V.Undef)), Add(((V)(c_1176)), Call(J_1178, V.Undef)), ((V)(mt_1091))), Call(hp_1093, V.Undef, Add(((V)((b_1175 + 0.003))), Call(J_1178, V.Undef)), Add(((V)(c_1176)), Call(J_1178, V.Undef)), ((V)(mt_1091))), Call(hp_1093, V.Undef, Add(((V)((b_1175 + 0.003))), Call(J_1178, V.Undef)), ((V)((d_1177 + 0.008))), ((V)(mt_1091))), Call(hp_1093, V.Undef, Add(((V)(a_1174)), Call(J_1178, V.Undef)), ((V)((d_1177 + 0.008))), ((V)(mt_1091))));
v_1099.S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(Q_1179, "map", P2_48), "join", ((V)("L")))), "Z\" fill=\"", ToStr(Call(shade_10, V.Undef, GetIdx(GC_1102, ((double)(ToInt32((ToNum(Call(R_1086, V.Undef)) * ToNum(Get(GC_1102, "length")))) | ToInt32(0D)))), ((V)((0.98 + (ToNum(Call(R_1086, V.Undef)) * 0.04)))))), "\"/>"));
le_1105.S("M").V(Call(P2_48, V.Undef, GetIdx(Q_1179, 3D))).S("L").V(Call(P2_48, V.Undef, GetIdx(Q_1179, 0D))).S("L").V(Call(P2_48, V.Undef, GetIdx(Q_1179, 1D)));
if (LtN(Call(R_1086, V.Undef), 0.55)) {
V p1_1187 = default;
V p2_1188 = default;
V p3_1189 = default;
p1_1187 = Call(hp_1093, V.Undef, ((V)((a_1174 + (su_1103 * ToNum(Call(R_1086, V.Undef)))))), ((V)((c_1176 + (st_1104 * 0.1)))), ((V)(mt_1091)));
p2_1188 = Call(hp_1093, V.Undef, ((V)((a_1174 + (su_1103 * ToNum(Call(R_1086, V.Undef)))))), ((V)((c_1176 + (st_1104 * 0.5)))), ((V)(mt_1091)));
p3_1189 = Call(hp_1093, V.Undef, ((V)((a_1174 + (su_1103 * ToNum(Call(R_1086, V.Undef)))))), ((V)((c_1176 + (st_1104 * 0.9)))), ((V)(mt_1091)));
cr_1106.S(string.Concat("M", ToStr(Call(P2_48, V.Undef, p1_1187)), "L", ToStr(Call(P2_48, V.Undef, p2_1188)), "L", ToStr(Call(P2_48, V.Undef, p3_1189))));
}
i_1172++;
}
}
j_1170++;
}
}
v_1099.S(string.Concat("<path d=\"", le_1105.Str, "\" stroke=\"#fff0b0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(Get(G_1085, "s"))))))), "\" fill=\"none\" opacity=\"0.7\"/><path d=\"", cr_1106.Str, "\" stroke=\"#9a7428\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.25 * ToNum(Get(G_1085, "s"))))))), "\" fill=\"none\" opacity=\"0.6\"/><rect x=\"0\" y=\"0\" width=\"", ToStr(Call(f1_16, V.Undef, Get(G_1085, "W"))), "\" height=\"", ToStr(Call(f1_16, V.Undef, Get(G_1085, "H"))), "\" fill=\"url(#k27g)\"/>"));
side_1107 = Fn((V _arrowThis1198, int _argc1190, V u_1196, V col_1197, V _a1194, V _a1195, V[] _rest1191) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(TS_1094, "map", Fn((V _arrowThis1206, int _argc1199, V t_1205, V _a1202, V _a1203, V _a1204, V[] _rest1200) => {
return Call(P2_48, V.Undef, Call(hp_1093, V.Undef, u_1196, t_1205, ((V)(1D))));
}, 1, "", true)), "join", ((V)("L")))), "L", ToStr(Invoke(Invoke(Invoke(Invoke(TS_1094, "slice"), "reverse"), "map", Fn((V _arrowThis1214, int _argc1207, V t_1213, V _a1210, V _a1211, V _a1212, V[] _rest1208) => {
return Call(P2_48, V.Undef, Call(hp_1093, V.Undef, u_1196, t_1213, ((V)(mt_1091))));
}, 1, "", true)), "join", ((V)("L")))), "Z\" fill=\"", ToStr(col_1197), "\"/>")));
}, 2, "", true);
v_1099.V(Add(Call(side_1107, V.Undef, ((V)(u0_1087)), ((V)("#f4e9d6"))), Call(side_1107, V.Undef, ((V)(u1_1088)), ((V)("#e0d0b4"))))).S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(US_1095, "map", Fn((V _arrowThis1222, int _argc1215, V u_1221, V _a1218, V _a1219, V _a1220, V[] _rest1216) => {
return Call(P2_48, V.Undef, Call(hp_1093, V.Undef, u_1221, ((V)(t1_1090)), ((V)(1D))));
}, 1, "", true)), "join", ((V)("L")))), "L", ToStr(Invoke(Invoke(Invoke(Invoke(US_1095, "slice"), "reverse"), "map", Fn((V _arrowThis1230, int _argc1223, V u_1229, V _a1226, V _a1227, V _a1228, V[] _rest1224) => {
return Call(P2_48, V.Undef, Call(hp_1093, V.Undef, u_1229, ((V)(t1_1090)), ((V)(mt_1091))));
}, 1, "", true)), "join", ((V)("L")))), "Z\" fill=\"#fbf1de\"/>"));
rim_1108 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(TS_1094, "map", Fn((V _arrowThis1238, int _argc1231, V t_1237, V _a1234, V _a1235, V _a1236, V[] _rest1232) => {
return Call(P2_48, V.Undef, Call(hp_1093, V.Undef, ((V)(u0_1087)), t_1237, ((V)(mt_1091))));
}, 1, "", true)), "join", ((V)("L")))).S("L").V(Invoke(Invoke(US_1095, "map", Fn((V _arrowThis1246, int _argc1239, V u_1245, V _a1242, V _a1243, V _a1244, V[] _rest1240) => {
return Call(P2_48, V.Undef, Call(hp_1093, V.Undef, u_1245, ((V)(t1_1090)), ((V)(mt_1091))));
}, 1, "", true)), "join", ((V)("L")))).S("L").V(Invoke(Invoke(Invoke(Invoke(TS_1094, "slice"), "reverse"), "map", Fn((V _arrowThis1254, int _argc1247, V t_1253, V _a1250, V _a1251, V _a1252, V[] _rest1248) => {
return Call(P2_48, V.Undef, Call(hp_1093, V.Undef, ((V)(u1_1088)), t_1253, ((V)(mt_1091))));
}, 1, "", true)), "join", ((V)("L")))).End()));
v_1099.S(string.Concat("<path d=\"", ToStr(rim_1108), "\" stroke=\"#ffc874\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((7D * ToNum(Get(G_1085, "s"))))))), "\" fill=\"none\" filter=\"url(#cb3)\" opacity=\"0.6\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.4;0.8;0.4")), ((V)(7D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "</path><path d=\"", ToStr(rim_1108), "\" stroke=\"#fff2d0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(Get(G_1085, "s"))))))), "\" fill=\"none\"/>"));
s_1096.S(string.Concat("<path d=\"", ToStr(O_1092), "\" fill=\"none\" stroke=\"#ffd9a0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((12D * ToNum(Get(G_1085, "s"))))))), "\" opacity=\"0.25\" filter=\"url(#cb6)\"/><defs><clipPath id=\"k27t\"><path d=\"", ToStr(O_1092), "\"/></clipPath></defs><g clip-path=\"url(#k27t)\">", v_1099.Str, "</g>"));
s_1096.S(string.Concat("<path d=\"", ToStr(O_1092), "\" fill=\"none\" stroke=\"#fbf6ec\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((4D * ToNum(Get(G_1085, "s"))))))), "\"/><path d=\"", ToStr(O_1092), "\" fill=\"none\" stroke=\"#9e7424\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((2.2 * ToNum(Get(G_1085, "s"))))))), "\"/><path d=\"", ToStr(O_1092), "\" fill=\"none\" stroke=\"#e2b552\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.3 * ToNum(Get(G_1085, "s"))))))), "\"/><path d=\"", ToStr(O_1092), "\" fill=\"none\" stroke=\"#fff0b8\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(Get(G_1085, "s"))))))), "\" transform=\"translate(0 ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.4) * ToNum(Get(G_1085, "s"))))))), ")\"/>"));
return ((V)(JsStrBuf.Begin().S(s_1096.Str).V(Call(cShade_53, V.Undef, G_1085, ((V)(0.2)), ((V)(0.05)))).V(Call(mould_44, V.Undef, G_1085, ((V)(6D)), Arr(((V)("#dccdb2")), ((V)("#f6eee0")), ((V)("#d2c1a3")), ((V)("#fbf5ea")), ((V)("#e6d9c2"))), ((V)("#ffffff")), ((V)(string.Concat("<path d=\"", ToStr(Get(Call(band_43, V.Undef, G_1085, ((V)(6D)), ((V)(0D)), ((V)(1D))), "lip")), "\" stroke=\"#d4a548\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(Get(G_1085, "s"))))))), "\" fill=\"none\" transform=\"translate(0 ", ToStr(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(Get(G_1085, "s"))))))), ")\"/>"))))).End()));
return default;
}, 1, "cTray", false);
cOnyx_62 = Fn((V _self1255, int _argc1256, V G_1262, V _a1259, V _a1260, V _a1261, V[] _rest1257) => {
V R_1263 = default;
double NU_1264 = 0;
double NT_1265 = 0;
double du_1266 = 0;
double dt_1267 = 0;
V SL_1268 = default;
JsStrBuf s_1269 = null;
JsStrBuf bw_1270 = null;
JsStrBuf bands_1271 = null;
JsStrBuf gl_1272 = null;
if (_self1255.IsNullish) _self1255 = GlobalV;
R_1263 = Call(rng_13, V.Undef, ((V)("onyx27")));
NU_1264 = 4D;
NT_1265 = 3D;
du_1266 = (1D / NU_1264);
dt_1267 = (1D / NT_1265);
SL_1268 = Arr(((V)("#f6dfb2")), ((V)("#f3d7a2")), ((V)("#f8e5c0")), ((V)("#f1d29c")));
s_1269 = new JsStrBuf(string.Concat("<defs><linearGradient id=\"k27b\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#8a5f1e\"/><stop offset=\"0.35\" stop-color=\"#f2cf7a\"/><stop offset=\"0.5\" stop-color=\"#fff0b8\"/><stop offset=\"0.7\" stop-color=\"#d9a84a\"/><stop offset=\"1\" stop-color=\"#7a5418\"/></linearGradient>", "<radialGradient id=\"k27o\"><stop offset=\"0\" stop-color=\"#fffaf0\" stop-opacity=\"0.75\"/><stop offset=\"0.5\" stop-color=\"#ffe2a8\" stop-opacity=\"0.3\"/><stop offset=\"1\" stop-color=\"#ffd080\" stop-opacity=\"0\"/></radialGradient>", string.Concat("<radialGradient id=\"k27n\" cx=\"0.4\" cy=\"0.35\" r=\"0.7\"><stop offset=\"0\" stop-color=\"#fff6d8\"/><stop offset=\"0.4\" stop-color=\"#e8bc62\"/><stop offset=\"1\" stop-color=\"#8a5f1e\"/></radialGradient></defs><path d=\"", ToStr(Get(G_1262, "tr")), "\" fill=\"#e8c890\"/>")));
{
double j_1273 = 0;
j_1273 = 0D;
while (true) {
if (!((j_1273 < NT_1265))) break;
{
double i_1275 = 0;
i_1275 = 0D;
while (true) {
if (!((i_1275 < NU_1264))) break;
s_1269.S(string.Concat("<path d=\"", ToStr(Invoke(G_1262, "quad", ((V)(((i_1275 * du_1266) - (NumTruthy(i_1275) ? 0D : 0.05)))), ((V)((j_1273 * dt_1267))), ((V)((((i_1275 + 1D) * du_1266) + ((i_1275 == (NU_1264 - 1D)) ? 0.05 : 0D)))), ((V)(((j_1273 + 1D) * dt_1267))))), "\" fill=\"", ToStr(GetIdx(SL_1268, ((i_1275 + (j_1273 * 2D)) % 4D))), "\"/>"));
i_1275++;
}
}
j_1273++;
}
}
s_1269.V(Call(cBlots_55, V.Undef, G_1262, ((V)("onx1")), ((V)(12D)), Arr(((V)("#e2a556")), ((V)("#fff4dc")), ((V)("#d99a4c"))), ((V)(0.45)), ((V)(70D))));
bw_1270 = new JsStrBuf("");
bands_1271 = new JsStrBuf("");
Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis1284, int _argc1277, V f_1283, V _a1280, V _a1281, V _a1282, V[] _rest1278) => {
double c_1285 = 0;
double A_1286 = 0;
double fr_1287 = 0;
double ph_1288 = 0;
double A2_1289 = 0;
c_1285 = (((-0.05) + (ToNum(f_1283) * 0.22)) + (ToNum(Call(R_1263, V.Undef)) * 0.06));
A_1286 = (0.05 + (ToNum(Call(R_1263, V.Undef)) * 0.08));
fr_1287 = (4D + (ToNum(Call(R_1263, V.Undef)) * 5D));
ph_1288 = (ToNum(Call(R_1263, V.Undef)) * 6D);
A2_1289 = (0.02 + (ToNum(Call(R_1263, V.Undef)) * 0.02));
Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis1297, int _argc1290, V k_1296, V _a1293, V _a1294, V _a1295, V[] _rest1291) => {
double off_1298 = 0;
V col_1299 = default;
double w_1300 = 0;
V d_1301 = default;
off_1298 = (ToNum(k_1296) * (0.008 + (ToNum(Call(R_1263, V.Undef)) * 0.012)));
col_1299 = GetK(Arr(((V)("#fff3da")), ((V)("#d49a50")), ((V)("#f8e4bc")), ((V)("#bf8640")), ((V)("#ffffff")), ((V)("#e3b06a")), ((V)("#fff8ea"))), k_1296);
w_1300 = ((0.3 + (ToNum(Call(R_1263, V.Undef)) * 1.6)) * ToNum(Get(G_1262, "s")));
d_1301 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Call(rep_18, V.Undef, ((V)(27D)), Fn((V _arrowThis1309, int _argc1302, V q_1308, V _a1305, V _a1306, V _a1307, V[] _rest1303) => {
double u_1310 = 0;
double x_1311 = 0;
u_1310 = ((-0.05) + (ToNum(q_1308) * 0.0423));
x_1311 = System.Math.Abs((u_1310 - 0.5));
return Invoke(G_1262, "P", ((V)(u_1310)), ((V)((((c_1285 + off_1298) + (A_1286 * FdLibm.Sin(((x_1311 * fr_1287) + ph_1288)))) + (A2_1289 * FdLibm.Sin(((x_1311 * 17D) + (ph_1288 * 2D))))))));
return default;
}, 1, "", true)), "join", ((V)("L")))).End()));
bands_1271.S(string.Concat("<path d=\"", ToStr(d_1301), "\" stroke=\"", ToStr(col_1299), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)(w_1300)))), "\" fill=\"none\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 + (ToNum(Call(R_1263, V.Undef)) * 0.4)))))), "\" stroke-linejoin=\"round\"/>"));
if (SEqN(k_1296, 2D)) {
bw_1270.V(d_1301);
}
return default;
}, 1, "", true));
return default;
}, 1, "", true));
s_1269.S(string.Concat("<g filter=\"url(#cb1)\"><path d=\"", bw_1270.Str, "\" stroke=\"#d08c3c\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((5D * ToNum(Get(G_1262, "s"))))))), "\" fill=\"none\" opacity=\"0.35\"/></g>")).S(bands_1271.Str);
s_1269.V(Invoke(Call(rep_18, V.Undef, ((V)(110D)), Fn((V _arrowThis1318, int _argc1312, V _a1314, V _a1315, V _a1316, V _a1317, V[] _rest1313) => {
V P_1319 = default;
P_1319 = Call(cE_49, V.Undef, G_1262, Call(R_1263, V.Undef), Call(R_1263, V.Undef));
return Call(cEl_52, V.Undef, P_1319, ((V)((0.3 * ToNum(Get(P_1319, "z"))))), ((V)(((0.3 * ToNum(Get(P_1319, "z"))) * ToNum(Get(P_1319, "q"))))), ((V)(string.Concat("fill=\"", (LtN(Call(R_1263, V.Undef), 0.6) ? "#fffaf0" : "#b77a34"), "\" opacity=\"0.55\""))));
return default;
}, 0, "", true)), "join", ((V)(""))));
{
double j_1320 = 0;
j_1320 = 0D;
while (true) {
if (!((j_1320 < NT_1265))) break;
{
double i_1322 = 0;
i_1322 = 0D;
while (true) {
if (!((i_1322 < NU_1264))) break;
V P_1324 = default;
double w_1325 = 0;
double h_1326 = 0;
P_1324 = Call(cE_49, V.Undef, G_1262, ((V)(((i_1322 + 0.5) * du_1266))), ((V)(((j_1320 + 0.5) * dt_1267))));
w_1325 = (ToNum(Invoke(G_1262, "x", ((V)(((i_1322 + 1D) * du_1266))), Get(P_1324, "y"))) - ToNum(Invoke(G_1262, "x", ((V)((i_1322 * du_1266))), Get(P_1324, "y"))));
h_1326 = (ToNum(Invoke(G_1262, "y", ((V)(((j_1320 + 1D) * dt_1267))))) - ToNum(Invoke(G_1262, "y", ((V)((j_1320 * dt_1267))))));
s_1269.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, Get(P_1324, "x"))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, Get(P_1324, "y"))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((w_1325 * 0.6))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((h_1326 * 0.7))))), "\" fill=\"url(#k27o)\" opacity=\"0.6\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.45;0.85;0.45")), ((V)(9D)), ((V)((-((i_1322 * 2D) + (j_1320 * 3D))))), Call(SPL_15, V.Undef, ((V)(2D))))), "</ellipse>"));
i_1322++;
}
}
j_1320++;
}
}
s_1269.S(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(Get(G_1262, "W"))) * 0.4))))), "\" y=\"0\" width=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Get(G_1262, "W")) * 0.1))))), "\" height=\"", ToStr(Call(f1_16, V.Undef, Get(G_1262, "H"))), "\" fill=\"#ffffff\" opacity=\"0.14\" transform=\"skewX(-25)\">", ToStr(Call(at_47, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;0 0;", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Get(G_1262, "W")) * 1.7))))), " 0"))), ((V)(13D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.6;1\"")))), "</rect>"));
gl_1272 = new JsStrBuf("");
{
double i_1327 = 0;
i_1327 = 1D;
while (true) {
if (!((i_1327 < NU_1264))) break;
gl_1272.S("M").V(Invoke(G_1262, "P", ((V)((i_1327 * du_1266))), ((V)((-0.02))))).S("L").V(Invoke(G_1262, "P", ((V)((i_1327 * du_1266))), ((V)(1.02))));
i_1327++;
}
}
{
double j_1329 = 0;
j_1329 = 1D;
while (true) {
if (!((j_1329 < NT_1265))) break;
gl_1272.V(Invoke(G_1262, "hl", Invoke(G_1262, "y", ((V)((j_1329 * dt_1267))))));
j_1329++;
}
}
s_1269.S(string.Concat("<path d=\"", gl_1272.Str, "\" stroke=\"#7a5418\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.5 * ToNum(Get(G_1262, "s"))))))), "\" fill=\"none\"/><path d=\"", gl_1272.Str, "\" stroke=\"url(#k27b)\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1D * ToNum(Get(G_1262, "s"))))))), "\" fill=\"none\"/><path d=\"", gl_1272.Str, "\" stroke=\"#fff3c8\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.25 * ToNum(Get(G_1262, "s"))))))), "\" fill=\"none\" transform=\"translate(0 ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.25) * ToNum(Get(G_1262, "s"))))))), ")\"/>"));
{
V P_1331 = default;
V z_1332 = default;
V q_1333 = default;
double R0_1334 = 0;
V cx_1335 = default;
V cy_1336 = default;
V D_1337 = default;
JsStrBuf v_1338 = null;
V pp_1339 = default;
V vn_1340 = default;
V c1_1341 = default;
double rr_1342 = 0;
P_1331 = Call(cE_49, V.Undef, G_1262, ((V)(0.5)), ((V)(0.42)));
z_1332 = Get(P_1331, "z");
q_1333 = Get(P_1331, "q");
R0_1334 = (20D * ToNum(z_1332));
cx_1335 = Get(P_1331, "x");
cy_1336 = Get(P_1331, "y");
D_1337 = Fn((V _arrowThis1350, int _argc1343, V m_1349, V _a1346, V _a1347, V _a1348, V[] _rest1344) => {
return NewObj(2).Put("x", cx_1335).Put("y", Call(cHi_50, V.Undef, G_1262, cy_1336, m_1349)).V;
}, 1, "", true);
v_1338 = new JsStrBuf(JsStrBuf.Begin().V(Add(Add(Add(Add(Call(cEl_52, V.Undef, P_1331, ((V)((R0_1334 * 1.2))), ((V)(((R0_1334 * 1.2) * ToNum(q_1333)))), ((V)("fill=\"#000000\" opacity=\"0.18\" filter=\"url(#cb3)\"")), ((V)((0.8 * ToNum(z_1332))))), Call(cEl_52, V.Undef, P_1331, ((V)((R0_1334 * 1.1))), ((V)(((R0_1334 * 1.1) * ToNum(q_1333)))), ((V)(string.Concat("fill=\"url(#k27b)\" stroke=\"#6a4612\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(z_1332)))))), "\""))))), Call(cEl_52, V.Undef, P_1331, ((V)((R0_1334 * 0.96))), ((V)(((R0_1334 * 0.96) * ToNum(q_1333)))), ((V)("fill=\"#3a2410\"")))), Call(cEl_52, V.Undef, Call(D_1337, V.Undef, ((V)(1.025))), ((V)((R0_1334 * 0.8))), ((V)(((R0_1334 * 0.8) * ToNum(q_1333)))), ((V)("fill=\"#24160a\"")))), Call(cEl_52, V.Undef, Call(D_1337, V.Undef, ((V)(1.05))), ((V)((R0_1334 * 0.55))), ((V)(((R0_1334 * 0.55) * ToNum(q_1333)))), ((V)("fill=\"#160d05\""))))).S(string.Concat("<g>", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.3;0.75;0.3")), ((V)(5D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), ToStr(Call(cEl_52, V.Undef, Call(D_1337, V.Undef, ((V)(1.05))), ((V)((R0_1334 * 0.5))), ((V)(((R0_1334 * 0.5) * ToNum(q_1333)))), ((V)("fill=\"#ffd99a\" filter=\"url(#cb3)\"")))), "</g>")).End());
pp_1339 = Fn((V _arrowThis1359, int _argc1351, V r_1357, V b_1358, V _a1355, V _a1356, V[] _rest1352) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, ((V)((FdLibm.Cos(ToNum(b_1358)) * ToNum(r_1357)))))).S(" ").V(Call(f1_16, V.Undef, ((V)((FdLibm.Sin(ToNum(b_1358)) * ToNum(r_1357)))))).End()));
}, 2, "", true);
vn_1340 = Invoke(Call(rep_18, V.Undef, ((V)(20D)), Fn((V _arrowThis1367, int _argc1360, V k_1366, V _a1363, V _a1364, V _a1365, V[] _rest1361) => {
double a_1368 = 0;
a_1368 = (((ToNum(k_1366) / 20D) * 2D) * PI_11);
return ((V)(string.Concat("M", ToStr(Call(pp_1339, V.Undef, ((V)((R0_1334 * 0.28))), ((V)(a_1368)))), "Q", ToStr(Call(pp_1339, V.Undef, ((V)((R0_1334 * 0.62))), ((V)((a_1368 + 0.32))))), " ", ToStr(Call(pp_1339, V.Undef, ((V)((R0_1334 * 0.9))), ((V)((a_1368 + 0.75))))))));
return default;
}, 1, "", true)), "join", ((V)("")));
c1_1341 = Call(D_1337, V.Undef, ((V)(1.015)));
v_1338.S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_16, V.Undef, Get(c1_1341, "x"))), " ", ToStr(Call(f1_16, V.Undef, Get(c1_1341, "y"))), ") scale(1 ", ToStr(Call(n4_17, V.Undef, q_1333)), ")\"><g>", ToStr(Call(at_47, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(18D)), ((V)(0D)), ((V)("")))), "<path d=\"", ToStr(vn_1340), "\" stroke=\"#6a4612\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.6 * ToNum(z_1332)))))), "\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"", ToStr(vn_1340), "\" stroke=\"#d4a548\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.05 * ToNum(z_1332)))))), "\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"", ToStr(vn_1340), "\" stroke=\"#fff0b8\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(z_1332)))))), "\" fill=\"none\" stroke-linecap=\"round\" transform=\"translate(", ToStr(Call(f1_16, V.Undef, ((V)(((-0.3) * ToNum(z_1332)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.3) * ToNum(z_1332)))))), ")\"/></g>")).S(string.Concat("<circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((R0_1334 * 0.22))))), "\" fill=\"url(#k27n)\" stroke=\"#7a5418\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(z_1332)))))), "\"/><ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)(((-R0_1334) * 0.07))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)(((-R0_1334) * 0.08))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((R0_1334 * 0.08))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((R0_1334 * 0.05))))), "\" fill=\"#ffffff\" opacity=\"0.8\"/></g>"));
rr_1342 = (R0_1334 * 1.03);
v_1338.S(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cx_1335) - rr_1342))))), " ", ToStr(Call(f1_16, V.Undef, cy_1336)), "A", ToStr(Call(f1_16, V.Undef, ((V)(rr_1342)))), " ", ToStr(Call(f1_16, V.Undef, ((V)((rr_1342 * ToNum(q_1333)))))), " 0 0 1 ", ToStr(Call(f1_16, V.Undef, Add(cx_1335, ((V)((rr_1342 * 0.3)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cy_1336) - ((rr_1342 * ToNum(q_1333)) * 0.95)))))), "\" stroke=\"#fff6d0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(z_1332)))))), "\" fill=\"none\" stroke-linecap=\"round\"/>"));
Call(rep_18, V.Undef, ((V)(12D)), Fn((V _arrowThis1376, int _argc1369, V i_1375, V _a1372, V _a1373, V _a1374, V[] _rest1370) => {
double a0_1377 = 0;
V d_1378 = default;
double dur_1379 = 0;
V b_1380 = default;
a0_1377 = (((ToNum(i_1375) / 12D) * 2D) * PI_11);
d_1378 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis1388, int _argc1381, V k_1387, V _a1384, V _a1385, V _a1386, V[] _rest1382) => {
double f_1389 = 0;
double r_1390 = 0;
double a_1391 = 0;
f_1389 = (ToNum(k_1387) / 15D);
r_1390 = (R0_1334 * (3.2 - (2.9 * f_1389)));
a_1391 = (a0_1377 + (f_1389 * 2.2));
return Call(P2_48, V.Undef, Arr(Add(cx_1335, ((V)((FdLibm.Cos(a_1391) * r_1390)))), Add(cy_1336, ((V)(((FdLibm.Sin(a_1391) * r_1390) * ToNum(q_1333)))))));
return default;
}, 1, "", true)), "join", ((V)("L")))).End()));
dur_1379 = (6D + (ToNum(i_1375) % 4D));
b_1380 = Call(n4_17, V.Undef, ((V)(((-ToNum(i_1375)) * 0.7))));
v_1338.S(string.Concat("<circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(z_1332)))))), "\" fill=\"#ffe7a8\" opacity=\"0\"><animateMotion path=\"", ToStr(d_1378), "\" dur=\"", NumStr(dur_1379), "s\" begin=\"", ToStr(b_1380), "s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0;0.95;0.9;0\" keyTimes=\"0;0.15;0.8;1\" dur=\"", NumStr(dur_1379), "s\" begin=\"", ToStr(b_1380), "s\" repeatCount=\"indefinite\"/></circle>"));
return default;
}, 1, "", true));
s_1269.S(v_1338.Str);
}
s_1269.V(Invoke(Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis1399, int _argc1392, V i_1398, V _a1395, V _a1396, V _a1397, V[] _rest1393) => {
V P_1400 = default;
V z_1401 = default;
P_1400 = Call(cE_49, V.Undef, G_1262, ((V)((0.05 + (ToNum(Call(R_1263, V.Undef)) * 0.9)))), ((V)((0.05 + (ToNum(Call(R_1263, V.Undef)) * 0.9)))));
z_1401 = Get(P_1400, "z");
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Get(P_1400, "x")) - (1.4 * ToNum(z_1401))))))), " ", ToStr(Call(f1_16, V.Undef, Get(P_1400, "y"))), "H", ToStr(Call(f1_16, V.Undef, Add(Get(P_1400, "x"), ((V)((1.4 * ToNum(z_1401))))))), "M", ToStr(Call(f1_16, V.Undef, Get(P_1400, "x"))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Get(P_1400, "y")) - (0.9 * ToNum(z_1401))))))), "V", ToStr(Call(f1_16, V.Undef, Add(Get(P_1400, "y"), ((V)((0.9 * ToNum(z_1401))))))), "\" stroke=\"#fff8e0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.25 * ToNum(z_1401)))))), "\" stroke-linecap=\"round\" opacity=\"0\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0;0;0.9;0")), ((V)((5D + (ToNum(i_1398) % 4D)))), ((V)(((-ToNum(i_1398)) * 0.9))), ((V)(" keyTimes=\"0;0.7;0.8;1\"")))), "</path>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
return ((V)(JsStrBuf.Begin().S(s_1269.Str).V(Call(cShade_53, V.Undef, G_1262, ((V)(0.1)), ((V)(0.04)))).V(Call(mould_44, V.Undef, G_1262, ((V)(2.6)), Arr(((V)("#2a1e14")), ((V)("#7a5a2c")), ((V)("#c99a44"))), ((V)("#fff0c8")), ((V)(string.Concat("<path d=\"", ToStr(Get(Call(band_43, V.Undef, G_1262, ((V)(2.6)), ((V)(0D)), ((V)(1D))), "lip")), "\" stroke=\"#ffd99a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((3D * ToNum(Get(G_1262, "s"))))))), "\" fill=\"none\" filter=\"url(#cb3)\" opacity=\"0.5\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.3;0.65;0.3")), ((V)(6D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "</path>"))))).End()));
return default;
}, 1, "cOnyx", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((((((((RD_8 is var _t1402 && !Truthy(_t1402) ? _t1402 : Get(RD_8, "PLUS26")) is var _t1403 && !Truthy(_t1403) ? _t1403 : Get(RD_8, "H20")) is var _t1404 && !Truthy(_t1404) ? _t1404 : Get(RD_8, "H21")) is var _t1405 && !Truthy(_t1405) ? _t1405 : Get(RD_8, "H14")) is var _t1406 && !Truthy(_t1406) ? _t1406 : Get(RD_8, "H11")) is var _t1407 && !Truthy(_t1407) ? _t1407 : Get(RD_8, "N")) is var _t1408 && !Truthy(_t1408) ? _t1408 : Get(RD_8, "H13")) is var _t1409 && !Truthy(_t1409) ? _t1409 : Get(RD_8, "H10")) is var _t1410 && !Truthy(_t1410) ? _t1410 : X_9) is var _t1411 && !Truthy(_t1411) ? _t1411 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_1412.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS27"))) {
return default;
}
shade_10 = Get(Get(X_9, "K"), "shade");
PI_11 = System.Math.PI;
H_12 = Get(RD_8, "H10");
{ V _t1413 = H_12;
if (_t1413.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1413));
{ V _t1414 = Get(_t1413, "rng");
rng_13 = _t1414; }
{ V _t1415 = Get(_t1413, "an");
an_14 = _t1415; }
{ V _t1416 = Get(_t1413, "SPL");
SPL_15 = _t1416; }
{ V _t1417 = Get(_t1413, "f1");
f1_16 = _t1417; }
{ V _t1418 = Get(_t1413, "n4");
n4_17 = _t1418; }
{ V _t1419 = Get(_t1413, "rep");
rep_18 = _t1419; } }
{ V _t1420 = Get(RD_8, "H13");
if (_t1420.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1420));
{ V _t1421 = Get(_t1420, "FL");
FL_19 = _t1421; }
{ V _t1422 = Get(_t1420, "fblot");
fblot_20 = _t1422; } }
{ V _t1423 = Get(RD_8, "H20");
if (_t1423.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1423));
{ V _t1424 = Get(_t1423, "W");
W_21 = _t1424; }
{ V _t1425 = Get(_t1423, "polyW");
polyW_22 = _t1425; }
{ V _t1426 = Get(_t1423, "lineW");
lineW_23 = _t1426; }
{ V _t1427 = Get(_t1423, "crvW");
crvW_24 = _t1427; }
{ V _t1428 = Get(_t1423, "chip");
chip_25 = _t1428; } }
TR_26 = ((V)("M14 0H66L80 56H0Z"));
wk_27 = Fn((V _arrowThis1436, int _argc1429, V v_1435, V _a1432, V _a1433, V _a1434, V[] _rest1430) => {
return ((V)(((52D + (28D * ToNum(v_1435))) / 80D)));
}, 1, "", true);
gv_28 = Fn((V _arrowThis1444, int _argc1437, V t_1443, V _a1440, V _a1441, V _a1442, V[] _rest1438) => {
return ((V)((ToNum(t_1443) * (0.7 + (0.3 * ToNum(t_1443))))));
}, 1, "", true);
K_29 = Fn((V _arrowThis1452, int _argc1445, V y_1451, V _a1448, V _a1449, V _a1450, V[] _rest1446) => {
return (Truthy(Get(RD_8, "_FLAT")) ? ((V)(0.82)) : Call(wk_27, V.Undef, Call(gv_28, V.Undef, y_1451)));
}, 1, "", true);
pt_30 = Fn((V _arrowThis1460, int _argc1453, V p_1459, V _a1456, V _a1457, V _a1458, V[] _rest1454) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, GetIdx(p_1459, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(p_1459, 1D))).End()));
}, 1, "", true);
quadW_31 = Fn((V _arrowThis1471, int _argc1461, V u0_1467, V y0_1468, V u1_1469, V y1_1470, V[] _rest1462) => {
return Call(polyW_22, V.Undef, Arr(Arr(u0_1467, y0_1468), Arr(u1_1469, y0_1468), Arr(u1_1469, y1_1470), Arr(u0_1467, y1_1470)));
}, 4, "", true);
dot_32 = Fn((V _arrowThis1482, int _argc1472, V u_1478, V y_1479, V r_1480, V ex_1481, V[] _rest1473) => {
V p_1483 = default;
V k_1484 = default;
p_1483 = Call(W_21, V.Undef, u_1478, y_1479);
k_1484 = Call(K_29, V.Undef, y_1479);
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_1483, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_1483, 1D))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_1480) * ToNum(k_1484)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(r_1480) * ToNum(k_1484)) * (0.55 + (0.2 * ToNum(Call(gv_28, V.Undef, y_1479))))))))), "\" ", ToStr(ex_1481), "/>")));
return default;
}, 4, "", true);
dotD_33 = Fn((V _arrowThis1494, int _argc1485, V u_1491, V y_1492, V r_1493, V _a1490, V[] _rest1486) => {
V p_1495 = default;
V k_1496 = default;
double rx_1497 = 0;
double ry_1498 = 0;
p_1495 = Call(W_21, V.Undef, u_1491, y_1492);
k_1496 = Call(K_29, V.Undef, y_1492);
rx_1497 = (ToNum(r_1493) * ToNum(k_1496));
ry_1498 = (rx_1497 * (0.55 + (0.2 * ToNum(Call(gv_28, V.Undef, y_1492)))));
return ((V)(string.Concat("M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(p_1495, 0D)) - rx_1497))))), " ", ToStr(Call(f1_16, V.Undef, GetIdx(p_1495, 1D))), "a", ToStr(Call(f1_16, V.Undef, ((V)(rx_1497)))), " ", ToStr(Call(f1_16, V.Undef, ((V)(ry_1498)))), " 0 1 0 ", ToStr(Call(f1_16, V.Undef, ((V)((2D * rx_1497))))), " 0a", ToStr(Call(f1_16, V.Undef, ((V)(rx_1497)))), " ", ToStr(Call(f1_16, V.Undef, ((V)(ry_1498)))), " 0 1 0 ", ToStr(Call(f1_16, V.Undef, ((V)(((-2D) * rx_1497))))), " 0Z")));
return default;
}, 3, "", true);
rrW_34 = Fn((V _arrowThis1511, int _argc1499, V u0_1505, V y0_1506, V u1_1507, V y1_1508, V[] _rest1500) => {
V P_1512 = default;
V ru_1509 = default;
V ry_1510 = default;
ru_1509 = (_argc1499 > 4 ? _rest1500[0] : V.Undef);
ry_1510 = (_argc1499 > 5 ? _rest1500[1] : V.Undef);
P_1512 = Arr();
Invoke(Arr(Arr(((V)((ToNum(u1_1507) - ToNum(ru_1509)))), Add(y0_1506, ry_1510), ((V)(((-PI_11) / 2D)))), Arr(((V)((ToNum(u1_1507) - ToNum(ru_1509)))), ((V)((ToNum(y1_1508) - ToNum(ry_1510)))), ((V)(0D))), Arr(Add(u0_1505, ru_1509), ((V)((ToNum(y1_1508) - ToNum(ry_1510)))), ((V)((PI_11 / 2D)))), Arr(Add(u0_1505, ru_1509), Add(y0_1506, ry_1510), ((V)(PI_11)))), "forEach", Fn((V _arrowThis1526, int _argc1513, V _a1515, V _a1516, V _a1517, V _a1518, V[] _rest1514) => {
V cu_1521 = default;
V cy_1523 = default;
V a0_1525 = default;
{ V _t1519 = ListOf(_a1515);
{ V _t1520 = GetIdx(_t1519, 0D);
cu_1521 = _t1520; }
{ V _t1522 = GetIdx(_t1519, 1D);
cy_1523 = _t1522; }
{ V _t1524 = GetIdx(_t1519, 2D);
a0_1525 = _t1524; }
}
{
double i_1527 = 0;
i_1527 = 0D;
while (true) {
if (!((i_1527 <= 4D))) break;
V a_1529 = default;
a_1529 = Add(a0_1525, ((V)(((i_1527 / 8D) * PI_11))));
Invoke(P_1512, "push", Arr(Add(cu_1521, ((V)((ToNum(ru_1509) * FdLibm.Cos(ToNum(a_1529)))))), Add(cy_1523, ((V)((ToNum(ry_1510) * FdLibm.Sin(ToNum(a_1529))))))));
i_1527++;
}
}
return default;
}, 1, "", true));
return Call(polyW_22, V.Undef, P_1512);
return default;
}, 6, "", true);
refl_35 = Fn((V _arrowThis1538, int _argc1530, V op_1536, V col_1537, V _a1534, V _a1535, V[] _rest1531) => {
return ((V)(string.Concat("<g filter=\"url(#fb3)\"><path d=\"", ToStr(Call(polyW_22, V.Undef, Arr(Arr(((V)(0.17)), ((V)(0D))), Arr(((V)(0.33)), ((V)(0D))), Arr(((V)(0.37)), ((V)(0.5))), Arr(((V)(0.14)), ((V)(0.5)))))), "\" fill=\"", ToStr((col_1537 is var _t1539 && Truthy(_t1539) ? _t1539 : ((V)("#ffffff")))), "\" opacity=\"", ToStr(op_1536), "\"/><path d=\"", ToStr(Call(polyW_22, V.Undef, Arr(Arr(((V)(0.2)), ((V)(0D))), Arr(((V)(0.3)), ((V)(0D))), Arr(((V)(0.32)), ((V)(0.3))), Arr(((V)(0.18)), ((V)(0.3)))))), "\" fill=\"", ToStr((col_1537 is var _t1540 && Truthy(_t1540) ? _t1540 : ((V)("#ffffff")))), "\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(op_1536) * 0.8))))), "\"/>", ToStr(Call(dot_32, V.Undef, ((V)(0.55)), ((V)(0.22)), ((V)(7D)), ((V)(string.Concat("fill=\"", ToStr((col_1537 is var _t1541 && Truthy(_t1541) ? _t1541 : ((V)("#ffffff")))), "\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(op_1536) * 0.7))))), "\""))))), "</g>")));
}, 2, "", true);
walk_36 = Fn((V _arrowThis1555, int _argc1542, V R_1548, V u_1549, V y_1550, V du_1551, V[] _rest1543) => {
V P_1556 = default;
V dy_1552 = default;
V n_1553 = default;
V jit_1554 = default;
dy_1552 = (_argc1542 > 4 ? _rest1543[0] : V.Undef);
n_1553 = (_argc1542 > 5 ? _rest1543[1] : V.Undef);
jit_1554 = (_argc1542 > 6 ? _rest1543[2] : V.Undef);
P_1556 = Arr(Arr(u_1549, y_1550));
{
double i_1557 = 0;
i_1557 = 0D;
while (true) {
if (!(Lt(((V)(i_1557)), n_1553))) break;
u_1549 = Add(u_1549, Add(du_1551, ((V)(((ToNum(Call(R_1548, V.Undef)) - 0.5) * ToNum(jit_1554))))));
y_1550 = Add(y_1550, Add(dy_1552, ((V)((((ToNum(Call(R_1548, V.Undef)) - 0.5) * ToNum(jit_1554)) * 1.4)))));
Invoke(P_1556, "push", Arr(u_1549, y_1550));
i_1557++;
}
}
return P_1556;
return default;
}, 7, "", true);
heel_37 = Fn((V _arrowThis1569, int _argc1559, V R_1565, V n_1566, V u0_1567, V u1_1568, V[] _rest1560) => {
return Invoke(Call(rep_18, V.Undef, n_1566, Fn((V _arrowThis1576, int _argc1570, V _a1572, V _a1573, V _a1574, V _a1575, V[] _rest1571) => {
double y_1577 = 0;
V u_1578 = default;
V p_1579 = default;
V k_1580 = default;
double l_1581 = 0;
double a_1582 = 0;
y_1577 = (0.15 + (ToNum(Call(R_1565, V.Undef)) * 0.85));
u_1578 = Add(u0_1567, ((V)((ToNum(Call(R_1565, V.Undef)) * (ToNum(u1_1568) - ToNum(u0_1567))))));
p_1579 = Call(W_21, V.Undef, u_1578, ((V)(y_1577)));
k_1580 = Call(K_29, V.Undef, ((V)(y_1577)));
l_1581 = ((1D + (ToNum(Call(R_1565, V.Undef)) * 2.2)) * ToNum(k_1580));
a_1582 = ((ToNum(Call(R_1565, V.Undef)) - 0.5) * 1.4);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(pt_30, V.Undef, p_1579)), "q", ToStr(Call(f1_16, V.Undef, ((V)(((l_1581 * 0.5) * FdLibm.Cos(a_1582)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.4) * ToNum(k_1580)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((l_1581 * FdLibm.Cos(a_1582)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((l_1581 * FdLibm.Sin(a_1582)) * 0.5))))), "\" stroke=\"#2e2a26\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)(((0.14 + (ToNum(Call(R_1565, V.Undef)) * 0.22)) * ToNum(k_1580)))))), "\" stroke-linecap=\"round\" fill=\"none\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 + (ToNum(Call(R_1565, V.Undef)) * 0.35)))))), "\"/>")));
return default;
}, 0, "", true)), "join", ((V)("")));
}, 4, "", true);
{ V _t1583 = Get(RD_8, "H21");
if (_t1583.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1583));
{ V _t1584 = Get(_t1583, "band");
band_43 = _t1584; }
{ V _t1585 = Get(_t1583, "mould");
mould_44 = _t1585; }
{ V _t1586 = Get(_t1583, "mkV");
mkV_45 = _t1586; } }
CFRM_46 = Get(Get(RD_8, "H14"), "FRM");
{ V _t1587 = H_12;
if (_t1587.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1587));
{ V _t1588 = Get(_t1587, "at");
at_47 = _t1588; }
{ V _t1589 = Get(_t1587, "P2");
P2_48 = _t1589; } }
cE_49 = Fn((V _arrowThis1599, int _argc1590, V G_1596, V u_1597, V t_1598, V _a1595, V[] _rest1591) => {
V y_1600 = default;
y_1600 = Invoke(G_1596, "y", t_1598);
return NewObj(4).Put("x", Invoke(G_1596, "x", u_1597, y_1600)).Put("y", y_1600).Put("z", Invoke(G_1596, "z", y_1600)).Put("q", ((V)((0.28 + (0.22 * (1D - (ToNum(y_1600) / ToNum(Get(G_1596, "H"))))))))).V;
return default;
}, 3, "", true);
cHi_50 = Fn((V _arrowThis1610, int _argc1601, V G_1607, V y_1608, V m_1609, V _a1606, V[] _rest1602) => {
return ((V)((ToNum(Get(G_1607, "VY")) - ((ToNum(Get(G_1607, "VY")) - ToNum(y_1608)) * ToNum(m_1609)))));
}, 3, "", true);
cD_51 = Fn((V _arrowThis1621, int _argc1611, V x_1617, V y_1618, V rx_1619, V ry_1620, V[] _rest1612) => {
return ((V)(string.Concat("M", ToStr(Call(n4_17, V.Undef, ((V)((ToNum(x_1617) - ToNum(rx_1619)))))), " ", ToStr(Call(n4_17, V.Undef, y_1618)), "a", ToStr(Call(n4_17, V.Undef, rx_1619)), " ", ToStr(Call(n4_17, V.Undef, ry_1620)), " 0 1 0 ", ToStr(Call(n4_17, V.Undef, ((V)((2D * ToNum(rx_1619)))))), " 0a", ToStr(Call(n4_17, V.Undef, rx_1619)), " ", ToStr(Call(n4_17, V.Undef, ry_1620)), " 0 1 0 ", ToStr(Call(n4_17, V.Undef, ((V)(((-2D) * ToNum(rx_1619)))))), " 0")));
}, 4, "", true);
cEl_52 = Fn((V _arrowThis1633, int _argc1622, V P_1628, V rx_1629, V ry_1630, V ex_1631, V[] _rest1623) => {
V dy_1632 = default;
dy_1632 = (_argc1622 > 4 ? _rest1623[0] : V.Undef);
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, Get(P_1628, "x"))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, Add(Get(P_1628, "y"), (dy_1632 is var _t1634 && Truthy(_t1634) ? _t1634 : ((V)(0D)))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, rx_1629)), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ry_1630)), "\" ", ToStr(ex_1631), "/>")));
}, 5, "", true);
cShade_53 = Fn((V _arrowThis1644, int _argc1635, V G_1641, V a_1642, V b_1643, V _a1640, V[] _rest1636) => {
return ((V)(string.Concat("<defs><linearGradient id=\"k27s\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#000000\" stop-opacity=\"", ToStr(a_1642), "\"/><stop offset=\"0.7\" stop-color=\"#000000\" stop-opacity=\"0\"/><stop offset=\"0.92\" stop-color=\"#ffffff\" stop-opacity=\"", ToStr((b_1643 is var _t1645 && Truthy(_t1645) ? _t1645 : ((V)(0.05)))), "\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient></defs><path d=\"", ToStr(Get(G_1641, "tr")), "\" fill=\"url(#k27s)\"/>")));
}, 3, "", true);
cDoc_54 = Fn((V _arrowThis1654, int _argc1646, V G_1652, V body_1653, V _a1650, V _a1651, V[] _rest1647) => {
return ((V)(string.Concat("<defs><clipPath id=\"k27c\"><path d=\"", ToStr(Get(G_1652, "tr")), "\"/></clipPath>", ToStr(Invoke(G_1652, "b", ((V)(1D)))), ToStr(Invoke(G_1652, "b", ((V)(3D)))), ToStr(Invoke(G_1652, "b", ((V)(6D)))), "</defs><g clip-path=\"url(#k27c)\">", ToStr(body_1653), "</g>")));
}, 2, "", true);
cBlots_55 = Fn((V _arrowThis1667, int _argc1655, V G_1661, V sd_1662, V n_1663, V cols_1664, V[] _rest1656) => {
V R_1668 = default;
V op_1665 = default;
V w_1666 = default;
op_1665 = (_argc1655 > 4 ? _rest1656[0] : V.Undef);
w_1666 = (_argc1655 > 5 ? _rest1656[1] : V.Undef);
R_1668 = Call(rng_13, V.Undef, sd_1662);
return ((V)(JsStrBuf.Begin().S(string.Concat("<g filter=\"url(#cb6)\" opacity=\"", ToStr(op_1665), "\">")).V(Invoke(Call(rep_18, V.Undef, n_1663, Fn((V _arrowThis1676, int _argc1669, V i_1675, V _a1672, V _a1673, V _a1674, V[] _rest1670) => {
double t_1677 = 0;
V y_1678 = default;
V z_1679 = default;
t_1677 = (0.05 + (ToNum(Call(R_1668, V.Undef)) * 0.92));
y_1678 = Invoke(G_1661, "y", ((V)(t_1677)));
z_1679 = Invoke(G_1661, "z", y_1678);
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, Invoke(G_1661, "x", ((V)(((ToNum(Call(R_1668, V.Undef)) * 1.1) - 0.05))), y_1678))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, y_1678)), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Add(w_1666, ((V)((ToNum(Call(R_1668, V.Undef)) * ToNum(w_1666)))))) * ToNum(z_1679)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)(((4D + (ToNum(Call(R_1668, V.Undef)) * 5D)) * ToNum(z_1679)))))), "\" fill=\"", ToStr(GetIdx(cols_1664, (ToNum(i_1675) % ToNum(Get(cols_1664, "length"))))), "\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g>").End()));
return default;
}, 6, "", true);
cStain_56 = Fn((V _arrowThis1691, int _argc1680, V G_1686, V u_1687, V t_1688, V rw_1689, V[] _rest1681) => {
V P_1692 = default;
V Rr_1693 = default;
V pts_1694 = default;
V d_1695 = default;
V d2_1696 = default;
V sd_1690 = default;
sd_1690 = (_argc1680 > 4 ? _rest1681[0] : V.Undef);
P_1692 = Call(cE_49, V.Undef, G_1686, u_1687, t_1688);
Rr_1693 = Call(rng_13, V.Undef, sd_1690);
pts_1694 = Call(rep_18, V.Undef, ((V)(22D)), Fn((V _arrowThis1704, int _argc1697, V i_1703, V _a1700, V _a1701, V _a1702, V[] _rest1698) => {
double a_1705 = 0;
double k_1706 = 0;
a_1705 = (((ToNum(i_1703) / 22D) * 2D) * PI_11);
k_1706 = ((ToNum(rw_1689) * ToNum(Get(P_1692, "z"))) * (0.78 + (ToNum(Call(Rr_1693, V.Undef)) * 0.4)));
return Arr(Add(Get(P_1692, "x"), ((V)((FdLibm.Cos(a_1705) * k_1706)))), Add(Get(P_1692, "y"), ((V)(((FdLibm.Sin(a_1705) * k_1706) * ToNum(Get(P_1692, "q")))))));
return default;
}, 1, "", true));
d_1695 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_1694, "map", P2_48), "join", ((V)("L")))).S("Z").End()));
d2_1696 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Invoke(pts_1694, "map", Fn((V _arrowThis1718, int _argc1707, V _a1709, V _a1710, V _a1711, V _a1712, V[] _rest1708) => {
V x_1715 = default;
V y_1717 = default;
{ V _t1713 = ListOf(_a1709);
{ V _t1714 = GetIdx(_t1713, 0D);
x_1715 = _t1714; }
{ V _t1716 = GetIdx(_t1713, 1D);
y_1717 = _t1716; }
}
return Arr(Add(Get(P_1692, "x"), ((V)(((ToNum(x_1715) - ToNum(Get(P_1692, "x"))) * 0.6)))), Add(Get(P_1692, "y"), ((V)(((ToNum(y_1717) - ToNum(Get(P_1692, "y"))) * 0.6)))));
}, 1, "", true)), "map", P2_48), "join", ((V)("L")))).S("Z").End()));
return ((V)(string.Concat("<path d=\"", ToStr(d_1695), "\" fill=\"#cdb078\" opacity=\"0.38\"/><path d=\"", ToStr(d_1695), "\" fill=\"none\" stroke=\"#9c7642\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.1 * ToNum(Get(P_1692, "z"))))))), "\" opacity=\"0.55\"/><path d=\"", ToStr(d2_1696), "\" fill=\"#c4a264\" opacity=\"0.2\"/><path d=\"", ToStr(d2_1696), "\" fill=\"none\" stroke=\"#a8844e\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.7 * ToNum(Get(P_1692, "z"))))))), "\" opacity=\"0.42\"/>")));
return default;
}, 5, "", true);
cWeb_57 = Fn((V _arrowThis1731, int _argc1719, V G_1725, V u_1726, V t_1727, V r_1728, V[] _rest1720) => {
V P_1732 = default;
double z_1733 = 0;
V A_1734 = default;
double sx_1735 = 0;
V d_1736 = default;
V fl_1729 = default;
V col_1730 = default;
fl_1729 = (_argc1719 > 4 ? _rest1720[0] : V.Undef);
col_1730 = (_argc1719 > 5 ? _rest1720[1] : V.Undef);
P_1732 = Call(cE_49, V.Undef, G_1725, u_1726, t_1727);
z_1733 = (ToNum(Get(P_1732, "z")) * ToNum(r_1728));
A_1734 = Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis1744, int _argc1737, V k_1743, V _a1740, V _a1741, V _a1742, V[] _rest1738) => {
return ((V)((((ToNum(k_1743) / 5D) * PI_11) / 2D)));
}, 1, "", true));
sx_1735 = (Truthy(fl_1729) ? (-1D) : 1D);
d_1736 = Invoke(Invoke(A_1734, "map", Fn((V _arrowThis1752, int _argc1745, V a_1751, V _a1748, V _a1749, V _a1750, V[] _rest1746) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_16, V.Undef, Get(P_1732, "x"))).S(" ").V(Call(f1_16, V.Undef, Get(P_1732, "y"))).S("l").V(Call(f1_16, V.Undef, ((V)((((sx_1735 * FdLibm.Cos(ToNum(a_1751))) * 9D) * z_1733))))).S(" ").V(Call(f1_16, V.Undef, ((V)((((-FdLibm.Sin(ToNum(a_1751))) * 5D) * z_1733))))).End()));
}, 1, "", true)), "join", ((V)("")));
Invoke(Arr(((V)(0.35)), ((V)(0.65)), ((V)(0.95))), "forEach", Fn((V _arrowThis1760, int _argc1753, V k_1759, V _a1756, V _a1757, V _a1758, V[] _rest1754) => {
d_1736 = ((V)(JsStrBuf.Begin().V(d_1736).S("M").V(Invoke(Invoke(A_1734, "map", Fn((V _arrowThis1768, int _argc1761, V a_1767, V _a1764, V _a1765, V _a1766, V[] _rest1762) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, Add(Get(P_1732, "x"), ((V)(((((sx_1735 * FdLibm.Cos(ToNum(a_1767))) * 9D) * z_1733) * ToNum(k_1759))))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(Get(P_1732, "y")) - (((FdLibm.Sin(ToNum(a_1767)) * 5D) * z_1733) * ToNum(k_1759))))))).End()));
}, 1, "", true)), "join", ((V)("L")))).End()));
return default;
}, 1, "", true));
return ((V)(string.Concat("<path d=\"", ToStr(d_1736), "\" stroke=\"", ToStr(col_1730), "\" stroke-opacity=\"0.75\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(Get(G_1725, "s"))))))), "\" fill=\"none\"/>")));
return default;
}, 6, "", true);
CEIL27_63 = NewObj(5).Put("acou", cAcou_58).Put("bead", cBead_59).Put("pots", cPots_60).Put("tray", cTray_61).Put("onyx", cOnyx_62).V;
CMEMO_64 = NewObj(0).V;
WALL27_65 = NewObj(5).Put("acou", ((V)("#ddd0b0"))).Put("bead", ((V)("#e9dec4"))).Put("pots", ((V)("#a8b79b"))).Put("tray", ((V)("#d6c3a3"))).Put("onyx", ((V)("#ebe5da"))).V;
CB27_66 = NewObj(5).Put("acou", Arr(((V)("#e6dfca")), ((V)("#e4dcc6")))).Put("bead", Arr(((V)("#f2e9d2")), ((V)("#f4ecd8")))).Put("pots", Arr(((V)("#f4f3ef")), ((V)("#4a4946")))).Put("tray", Arr(((V)("#eee2cc")), ((V)("#f6eee0")))).Put("onyx", Arr(((V)("#f2d7a6")), ((V)("#c99a44")))).V;
BRASS_67 = ((V)("<stop offset=\"0\" stop-color=\"#8a5f1e\"/><stop offset=\"0.35\" stop-color=\"#f2cf7a\"/><stop offset=\"0.5\" stop-color=\"#fff0b8\"/><stop offset=\"0.7\" stop-color=\"#d9a84a\"/><stop offset=\"1\" stop-color=\"#8a5f1e\"/>"));
HOOD27_68 = NewObj(5).Put("acou", ((V)("<path d=\"M16 26H64V31H16Z\" fill=\"#8a6a2a\" opacity=\"0.14\"/>"))).Put("bead", ((V)(string.Concat("<rect x=\"27\" y=\"26\" width=\"26\" height=\"9\" fill=\"#f7f3ea\" stroke=\"#c4b99f\" stroke-width=\"0.3\"/><path d=\"M40 26V35M28.2 27.2H38.8V33.8H28.2ZM41.2 27.2H51.8V33.8H41.2Z\" stroke=\"#d2c8b0\" stroke-width=\"0.25\" fill=\"none\"/><circle cx=\"38.2\" cy=\"33\" r=\"0.35\" fill=\"#b08a4a\"/><circle cx=\"41.8\" cy=\"33\" r=\"0.35\" fill=\"#b08a4a\"/>", "<rect x=\"28\" y=\"35\" width=\"24\" height=\"2.6\" fill=\"#e6e6e2\" stroke=\"#9a9a96\" stroke-width=\"0.25\"/><rect x=\"28\" y=\"37\" width=\"24\" height=\"0.7\" fill=\"#55585a\"/><circle cx=\"49.5\" cy=\"36\" r=\"0.35\" fill=\"#7a7e80\"/><circle cx=\"48.3\" cy=\"36\" r=\"0.35\" fill=\"#7a7e80\"/><ellipse cx=\"40\" cy=\"39.4\" rx=\"9\" ry=\"1.4\" fill=\"#fff4d2\" opacity=\"0.6\"/>")))).Put("pots", ((V)(string.Concat("<defs><linearGradient id=\"k27m\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#868c91\"/><stop offset=\"0.35\" stop-color=\"#e9edf0\"/><stop offset=\"0.6\" stop-color=\"#b9bfc4\"/><stop offset=\"1\" stop-color=\"#787e83\"/></linearGradient></defs><rect x=\"36.4\" y=\"26\" width=\"7.2\" height=\"11.5\" fill=\"url(#k27m)\" stroke=\"#6c7276\" stroke-width=\"0.25\"/>", "<path d=\"M29.5 41.5L36.4 37.5H43.6L50.5 41.5Z\" fill=\"url(#k27m)\" stroke=\"#6c7276\" stroke-width=\"0.25\"/><rect x=\"29.5\" y=\"41.5\" width=\"21\" height=\"1.1\" fill=\"#5e6468\"/><path d=\"M38 27V37M42 27V37\" stroke=\"#ffffff\" stroke-width=\"0.15\" opacity=\"0.6\"/><ellipse cx=\"40\" cy=\"44\" rx=\"9.5\" ry=\"1.4\" fill=\"#fff4d2\" opacity=\"0.55\"/>")))).Put("tray", ((V)(JsStrBuf.Begin().S("<defs><linearGradient id=\"k27p\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#d6c6aa\"/><stop offset=\"0.4\" stop-color=\"#f6eddd\"/><stop offset=\"1\" stop-color=\"#c9b594\"/></linearGradient><linearGradient id=\"k27q\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\">").V(BRASS_67).S("</linearGradient></defs>").S("<path d=\"M34 26H46C46 32 49.5 36.5 53 40H27C30.5 36.5 34 32 34 26Z\" fill=\"url(#k27p)\" stroke=\"#b8a482\" stroke-width=\"0.25\"/><path d=\"M37 26C37 32 34.5 36.5 31.5 40M43 26C43 32 45.5 36.5 48.5 40\" stroke=\"#c99a44\" stroke-width=\"0.9\" fill=\"none\"/><path d=\"M36.8 26C36.8 32 34.3 36.5 31.3 40M42.8 26C42.8 32 45.3 36.5 48.3 40\" stroke=\"#fff0b8\" stroke-width=\"0.2\" fill=\"none\"/>").S("<rect x=\"26.4\" y=\"40\" width=\"27.2\" height=\"2.4\" rx=\"0.4\" fill=\"url(#k27q)\" stroke=\"#7a5418\" stroke-width=\"0.2\"/><path d=\"M27 40.5H53\" stroke=\"#fff3c8\" stroke-width=\"0.2\"/><ellipse cx=\"40\" cy=\"44.6\" rx=\"11\" ry=\"1.5\" fill=\"#fff0c8\" opacity=\"0.6\"/>").End()))).Put("onyx", ((V)("<defs><linearGradient id=\"k27x\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffd99a\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#ffd99a\" stop-opacity=\"0\"/></linearGradient></defs><rect x=\"16\" y=\"26\" width=\"48\" height=\"10\" fill=\"url(#k27x)\"/>"))).V;
cardOf27_69 = Fn((V _arrowThis1776, int _argc1769, V k_1775, V _a1772, V _a1773, V _a1774, V[] _rest1770) => {
V G_1777 = default;
V w_1778 = default;
G_1777 = Call(mkV_45, V.Undef, Get(CFRM_46, "card"));
w_1778 = GetK(WALL27_65, k_1775);
return ((V)(JsStrBuf.Begin().S(string.Concat("<path d=\"M16 26H64V56H16Z\" fill=\"", ToStr(w_1778), "\"/><path d=\"M0 0L16 26V56H0Z\" fill=\"", ToStr(Call(shade_10, V.Undef, w_1778, ((V)(0.88)))), "\"/><path d=\"M80 0L64 26V56H80Z\" fill=\"", ToStr(Call(shade_10, V.Undef, w_1778, ((V)(0.8)))), "\"/><path d=\"M16 26V56M64 26V56\" stroke=\"#000000\" stroke-opacity=\"0.2\" stroke-width=\"0.6\"/>")).V(Call(cDoc_54, V.Undef, G_1777, InvokeK(CEIL27_63, k_1775, G_1777))).S(string.Concat("<path d=\"", ToStr(Get(G_1777, "tr")), "\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.25\" stroke-width=\"0.5\"/>")).V(GetK(HOOD27_68, k_1775)).End()));
return default;
}, 1, "", true);
N_70 = Get(RD_8, "N");
{ V _t1779 = H_12;
if (_t1779.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1779));
{ V _t1780 = Get(_t1779, "cam");
cam_71 = _t1780; } }
{ V _t1781 = Get(RD_8, "H11");
if (_t1781.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1781));
{ V _t1782 = Get(_t1781, "DEF11");
DEF11_72 = _t1782; }
{ V _t1783 = Get(_t1781, "zsort");
zsort_73 = _t1783; } }
lbox_74 = Fn((V _arrowThis1792, int _argc1784, V C_1790, V o_1791, V _a1788, V _a1789, V[] _rest1785) => {
return Invoke(H_12, "box3", C_1790, Object_assign(NewObj(0).V, o_1791, NewObj(7).Put("mat", V.Null).Put("tpat", V.Null).Put("gl", ((V)((Truthy(Get(o_1791, "gl")) ? Min(ToNum(Get(o_1791, "gl")), 0.2) : 0D)))).Put("olw", ((V)(1D))).Put("olo", ((V)(0.95))).Put("olc", Call(shade_10, V.Undef, Get(o_1791, "col"), ((V)(0.32)))).Put("edge", ((V)(0.5))).V));
}, 2, "", true);
lcyl_75 = Fn((V _arrowThis1805, int _argc1793, V C_1799, V a_1800, V b_1801, V r_1802, V[] _rest1794) => {
V col_1803 = default;
V o_1804 = default;
col_1803 = (_argc1793 > 4 ? _rest1794[0] : V.Undef);
o_1804 = (_argc1793 > 5 ? _rest1794[1] : V.Undef);
return Invoke(H_12, "cyl3", C_1799, a_1800, b_1801, r_1802, col_1803, Object_assign(NewObj(1).Put("olw", ((V)(0.8))).V, (o_1804 is var _t1806 && Truthy(_t1806) ? _t1806 : NewObj(0).V), NewObj(3).Put("mat", ((o_1804 is var _t1807 && !Truthy(_t1807) ? _t1807 : Get(o_1804, "mat")) is var _t1808 && Truthy(_t1808) ? _t1808 : ((V)("plastic")))).Put("pat", V.Null).Put("olo", ((V)(0.95))).V));
}, 6, "", true);
lsph_76 = Fn((V _arrowThis1820, int _argc1809, V C_1815, V q_1816, V r_1817, V col_1818, V[] _rest1810) => {
V c_1821 = default;
V o_1819 = default;
o_1819 = (_argc1809 > 4 ? _rest1810[0] : V.Undef);
c_1821 = Invoke(C_1815, "P", q_1816);
return ((V)(JsStrBuf.Begin().V(Invoke(H_12, "sph", C_1815, q_1816, r_1817, col_1818, o_1819)).S(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(c_1821, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(c_1821, 1D))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_1817) * ToNum(Get(C_1815, "k"))))))), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_10, V.Undef, col_1818, ((V)(0.35)))), "\" stroke-width=\"0.5\"/>")).End()));
return default;
}, 5, "", true);
DEF27_77 = ((V)(JsStrBuf.Begin().V(DEF11_72).S("<filter id=\"l27b1\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"0.8\"/></filter><filter id=\"l27b3\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"3\"/></filter>").S("<radialGradient id=\"l27w\"><stop offset=\"0\" stop-color=\"#fff0c0\" stop-opacity=\"0.85\"/><stop offset=\"0.35\" stop-color=\"#ffd27a\" stop-opacity=\"0.35\"/><stop offset=\"1\" stop-color=\"#ffc060\" stop-opacity=\"0\"/></radialGradient>").S("<radialGradient id=\"l27c\"><stop offset=\"0\" stop-color=\"#f2fbff\" stop-opacity=\"0.85\"/><stop offset=\"0.35\" stop-color=\"#d8efff\" stop-opacity=\"0.3\"/><stop offset=\"1\" stop-color=\"#c4e4ff\" stop-opacity=\"0\"/></radialGradient>").S("<radialGradient id=\"l27a\"><stop offset=\"0\" stop-color=\"#fff6e2\" stop-opacity=\"0.9\"/><stop offset=\"0.4\" stop-color=\"#ffdca6\" stop-opacity=\"0.4\"/><stop offset=\"1\" stop-color=\"#ffc880\" stop-opacity=\"0\"/></radialGradient>").S("<radialGradient id=\"l27g\"><stop offset=\"0\" stop-color=\"#fff4d6\" stop-opacity=\"0.8\"/><stop offset=\"0.4\" stop-color=\"#ffe0a4\" stop-opacity=\"0.32\"/><stop offset=\"1\" stop-color=\"#ffd08a\" stop-opacity=\"0\"/></radialGradient>").End()));
lglow_78 = Fn((V _arrowThis1834, int _argc1822, V C_1828, V q_1829, V r_1830, V op_1831, V[] _rest1823) => {
V c_1835 = default;
V A_1832 = default;
V g_1833 = default;
A_1832 = (_argc1822 > 4 ? _rest1823[0] : V.Undef);
g_1833 = (_argc1822 > 5 ? _rest1823[1] : V.Undef);
c_1835 = Invoke(C_1828, "P", q_1829);
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(c_1835, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(c_1835, 1D))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_1830) * ToNum(Get(C_1828, "k"))))))), "\" fill=\"url(#", ToStr((g_1833 is var _t1836 && Truthy(_t1836) ? _t1836 : ((V)("l27w")))), ")\" opacity=\"", ToStr(op_1831), "\">", ToStr((A_1832 is var _t1837 && Truthy(_t1837) ? _t1837 : ((V)("")))), "</circle>")));
return default;
}, 6, "", true);
lring_79 = Fn((V _arrowThis1850, int _argc1838, V C_1844, V y_1845, V r_1846, V a0_1847, V[] _rest1839) => {
V a1_1848 = default;
V n_1849 = default;
a1_1848 = (_argc1838 > 4 ? _rest1839[0] : V.Undef);
n_1849 = (_argc1838 > 5 ? _rest1839[1] : V.Undef);
return Call(rep_18, V.Undef, Add(n_1849, ((V)(1D))), Fn((V _arrowThis1858, int _argc1851, V i_1857, V _a1854, V _a1855, V _a1856, V[] _rest1852) => {
V a_1859 = default;
a_1859 = Add(a0_1847, ((V)((((ToNum(a1_1848) - ToNum(a0_1847)) * ToNum(i_1857)) / ToNum(n_1849)))));
return Invoke(C_1844, "p", ((V)((ToNum(r_1846) * FdLibm.Sin(ToNum(a_1859))))), y_1845, ((V)((ToNum(r_1846) * FdLibm.Cos(ToNum(a_1859))))));
return default;
}, 1, "", true));
}, 6, "", true);
lswing_80 = Fn((V _arrowThis1871, int _argc1860, V C_1866, V q_1867, V deg_1868, V T_1869, V[] _rest1861) => {
V c_1872 = default;
V b_1870 = default;
b_1870 = (_argc1860 > 4 ? _rest1861[0] : V.Undef);
c_1872 = Call(P2_48, V.Undef, Invoke(C_1866, "P", q_1867));
return ((V)(string.Concat("<animateTransform attributeName=\"transform\" type=\"rotate\" values=\"", NumStr((-ToNum(deg_1868))), " ", ToStr(c_1872), ";", ToStr(deg_1868), " ", ToStr(c_1872), ";", NumStr((-ToNum(deg_1868))), " ", ToStr(c_1872), "\" dur=\"", ToStr(Call(n4_17, V.Undef, T_1869)), "s\" begin=\"", ToStr(Call(n4_17, V.Undef, (b_1870 is var _t1873 && Truthy(_t1873) ? _t1873 : ((V)(0D))))), "s\" repeatCount=\"indefinite\"", ToStr(Call(SPL_15, V.Undef, ((V)(2D)))), "/>")));
return default;
}, 5, "", true);
lrot_81 = Fn((V _arrowThis1884, int _argc1874, V p_1880, V deg_1881, V T_1882, V b_1883, V[] _rest1875) => {
V c_1885 = default;
c_1885 = Call(P2_48, V.Undef, p_1880);
return Call(at_47, V.Undef, ((V)("rotate")), ((V)(string.Concat(NumStr((-ToNum(deg_1881))), " ", ToStr(c_1885), ";", ToStr(deg_1881), " ", ToStr(c_1885), ";", NumStr((-ToNum(deg_1881))), " ", ToStr(c_1885)))), Call(n4_17, V.Undef, T_1882), Call(n4_17, V.Undef, (b_1883 is var _t1886 && Truthy(_t1886) ? _t1886 : ((V)(0D)))), Call(SPL_15, V.Undef, ((V)(2D))));
return default;
}, 4, "", true);
FLK27_82 = Fn((V _arrowThis1895, int _argc1887, V T_1893, V b_1894, V _a1891, V _a1892, V[] _rest1888) => {
return Call(an_14, V.Undef, ((V)("opacity")), ((V)("1;1;0.3;1;0.55;1;1")), T_1893, b_1894, ((V)(" keyTimes=\"0;0.6;0.62;0.64;0.66;0.69;1\"")));
}, 2, "", true);
tube27_83 = Fn((V _arrowThis1907, int _argc1896, V C_1902, V P_1903, V w_1904, V col_1905, V[] _rest1897) => {
V d_1908 = default;
V k_1909 = default;
V hi_1906 = default;
hi_1906 = (_argc1896 > 4 ? _rest1897[0] : V.Undef);
d_1908 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(P_1903, "map", P2_48), "join", ((V)("L")))).End()));
k_1909 = Get(C_1902, "k");
return ((V)(string.Concat("<path d=\"", ToStr(d_1908), "\" stroke=\"", ToStr(Call(shade_10, V.Undef, col_1905, ((V)(0.45)))), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(w_1904) * 1.35) * ToNum(k_1909)))))), "\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"", ToStr(d_1908), "\" stroke=\"", ToStr(col_1905), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(w_1904) * ToNum(k_1909)))))), "\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"", ToStr(d_1908), "\" stroke=\"", ToStr((hi_1906 is var _t1910 && Truthy(_t1910) ? _t1910 : ((V)("#fff0b8")))), "\" stroke-opacity=\"0.6\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(w_1904) * 0.3) * ToNum(k_1909)))))), "\" fill=\"none\" stroke-linecap=\"round\" transform=\"translate(0 ", ToStr(Call(f1_16, V.Undef, ((V)((((-ToNum(w_1904)) * 0.28) * ToNum(k_1909)))))), ")\"/>")));
return default;
}, 5, "", true);
front_84 = Fn((V _arrowThis1920, int _argc1911, V C_1917, V x_1918, V z_1919, V _a1916, V[] _rest1912) => {
return ((((ToNum(x_1918) * ToNum(GetIdx(Get(C_1917, "v"), 0D))) + (ToNum(z_1919) * ToNum(GetIdx(Get(C_1917, "v"), 2D)))) > 0D) ? V.True : V.False);
}, 3, "", true);
Set(N_70, "fluor27", Fn((V _arrowThis1928, int _argc1921, V S_1927, V _a1924, V _a1925, V _a1926, V[] _rest1922) => {
double T_1929 = 0;
double Y_1930 = 0;
double L_1931 = 0;
V D_1932 = default;
T_1929 = 40D;
Y_1930 = 22D;
L_1931 = 28D;
D_1932 = NewObj(5).Put("w", ((V)(64D))).Put("d", ((V)(14D))).Put("zs", ((V)(1.5))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis1939, int _argc1933, V _a1935, V _a1936, V _a1937, V _a1938, V[] _rest1934) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1932, "fx", Fn((V _arrowThis1947, int _argc1940, V ctx_1946, V _a1943, V _a1944, V _a1945, V[] _rest1941) => {
V C_1948 = default;
V k_1949 = default;
V s_1950 = default;
C_1948 = Call(cam_71, V.Undef, ctx_1946);
k_1949 = Get(C_1948, "k");
s_1950 = Call(lglow_78, V.Undef, C_1948, Arr(((V)(0D)), ((V)((Y_1930 - 6D))), ((V)(0D))), ((V)(48D)), ((V)(0.5)), Call(FLK27_82, V.Undef, ((V)(7.3)), ((V)(0D))), ((V)("l27c")));
Invoke(Arr(((V)((-22D))), ((V)(22D))), "forEach", Fn((V _arrowThis1958, int _argc1951, V x_1957, V _a1954, V _a1955, V _a1956, V[] _rest1952) => {
V a_1959 = default;
V b_1960 = default;
V d_1961 = default;
V da_1962 = default;
a_1959 = Invoke(C_1948, "p", x_1957, ((V)((T_1929 - 0.6))), ((V)(0D)));
b_1960 = Invoke(C_1948, "p", x_1957, ((V)((Y_1930 + 3D))), ((V)(0D)));
d_1961 = ((V)(string.Concat("M", ToStr(Call(P2_48, V.Undef, a_1959)), "L", ToStr(Call(P2_48, V.Undef, b_1960)))));
da_1962 = ((V)(string.Concat(ToStr(Call(f1_16, V.Undef, ((V)((1.2 * ToNum(k_1949)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(k_1949)))))))));
s_1950 = ((V)(JsStrBuf.Begin().V(s_1950).V(Call(lsph_76, V.Undef, C_1948, Arr(x_1957, ((V)((T_1929 - 0.6))), ((V)(0D))), ((V)(0.7)), ((V)("#8a867e")))).S(string.Concat("<path d=\"", ToStr(d_1961), "\" stroke=\"#4e4a44\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1D * ToNum(k_1949)))))), "\" stroke-dasharray=\"", ToStr(da_1962), "\"/><path d=\"", ToStr(d_1961), "\" stroke=\"#c4beb2\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(k_1949)))))), "\" stroke-dasharray=\"", ToStr(da_1962), "\"/>")).End()));
return default;
}, 1, "", true));
{
V a_1963 = default;
V m_1964 = default;
V b_1965 = default;
a_1963 = Invoke(C_1948, "p", ((V)((L_1931 - 2D))), ((V)((Y_1930 + 3D))), ((V)((-1.5))));
m_1964 = Invoke(C_1948, "p", ((V)((L_1931 + 7D))), ((V)((Y_1930 + 2D))), ((V)((-2D))));
b_1965 = Invoke(C_1948, "p", ((V)((L_1931 + 3D))), ((V)(T_1929)), ((V)((-2D))));
s_1950 = ((V)(JsStrBuf.Begin().V(s_1950).S(string.Concat("<path d=\"M", ToStr(Call(P2_48, V.Undef, a_1963)), "Q", ToStr(Call(P2_48, V.Undef, m_1964)), " ", ToStr(Call(P2_48, V.Undef, b_1965)), "\" stroke=\"#8a867c\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.75 * ToNum(k_1949)))))), "\" fill=\"none\"/><path d=\"M", ToStr(Call(P2_48, V.Undef, a_1963)), "Q", ToStr(Call(P2_48, V.Undef, m_1964)), " ", ToStr(Call(P2_48, V.Undef, b_1965)), "\" stroke=\"#d8d3c6\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(k_1949)))))), "\" fill=\"none\"/>")).End()));
}
s_1950 = Add(s_1950, Call(lbox_74, V.Undef, C_1948, NewObj(6).Put("c", Arr(((V)(0D)), ((V)(Y_1930)), ((V)(0D)))).Put("w", ((V)((2D * L_1931)))).Put("h", ((V)(3D))).Put("d", ((V)(5.4))).Put("col", ((V)("#e2dfd4"))).Put("r", ((V)(0.6))).V));
s_1950 = Add(s_1950, Invoke(Call(rep_18, V.Undef, ((V)(14D)), Fn((V _arrowThis1973, int _argc1966, V i_1972, V _a1969, V _a1970, V _a1971, V[] _rest1967) => {
V p_1974 = default;
p_1974 = Invoke(C_1948, "p", ((V)(((((-L_1931) + 3D) + (ToNum(i_1972) * 4D)) + (ToNum(i_1972) % 3D)))), ((V)((Y_1930 + 3D))), ((V)(((NumTruthy((ToNum(i_1972) % 2D)) ? 1D : (-1D)) * 1.2))));
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_1974, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_1974, 1D))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.4 * ToNum(k_1949)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(k_1949)))))), "\" fill=\"#8a7a5a\" opacity=\"0.3\"/>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
Invoke(Arr(((V)(((-L_1931) + 0.8))), ((V)((L_1931 - 0.8)))), "forEach", Fn((V _arrowThis1982, int _argc1975, V x_1981, V _a1978, V _a1979, V _a1980, V[] _rest1976) => {
return (s_1950 = Add(s_1950, Call(lbox_74, V.Undef, C_1948, NewObj(5).Put("c", Arr(x_1981, ((V)((Y_1930 - 2.4))), ((V)(0D)))).Put("w", ((V)(1.6))).Put("h", ((V)(2.4))).Put("d", ((V)(4.8))).Put("col", ((V)("#d6d2c4"))).V)));
}, 1, "", true));
Invoke(Arr(((V)((-1.25))), ((V)(1.25))), "forEach", Fn((V _arrowThis1991, int _argc1983, V z_1989, V i_1990, V _a1987, V _a1988, V[] _rest1984) => {
V a_1992 = default;
V b_1993 = default;
V e_1994 = default;
V ln_1995 = default;
a_1992 = Arr(((V)(((-L_1931) + 1.6))), ((V)((Y_1930 - 1.5))), z_1989);
b_1993 = Arr(((V)((L_1931 - 1.6))), ((V)((Y_1930 - 1.5))), z_1989);
e_1994 = Arr(((V)((L_1931 - 4.6))), ((V)((Y_1930 - 1.5))), z_1989);
s_1950 = Add(s_1950, Add(Add(Call(lcyl_75, V.Undef, C_1948, a_1992, b_1993, ((V)(1.05)), ((V)("#eef4f6")), NewObj(1).Put("olw", ((V)(0.3))).V), Call(lcyl_75, V.Undef, C_1948, a_1992, Arr(Add(GetIdx(a_1992, 0D), ((V)(1.6))), GetIdx(a_1992, 1D), z_1989), ((V)(1.1)), ((V)("#9aa0a2")), NewObj(1).Put("olw", ((V)(0.3))).V)), Call(lcyl_75, V.Undef, C_1948, Arr(((V)((ToNum(GetIdx(b_1993, 0D)) - 1.6))), GetIdx(b_1993, 1D), z_1989), b_1993, ((V)(1.1)), ((V)("#9aa0a2")), NewObj(1).Put("olw", ((V)(0.3))).V)));
if (Truthy(i_1990)) {
s_1950 = Add(s_1950, Add(Call(lcyl_75, V.Undef, C_1948, e_1994, Arr(((V)((ToNum(GetIdx(b_1993, 0D)) - 1.6))), GetIdx(b_1993, 1D), z_1989), ((V)(1.07)), ((V)("#5c544a")), NewObj(2).Put("ol", ((V)(0D))).Put("op", ((V)(0.7))).V), Call(lcyl_75, V.Undef, C_1948, Arr(Add(GetIdx(a_1992, 0D), ((V)(1.6))), GetIdx(a_1992, 1D), z_1989), Arr(Add(GetIdx(a_1992, 0D), ((V)(3D))), GetIdx(a_1992, 1D), z_1989), ((V)(1.07)), ((V)("#8a8274")), NewObj(2).Put("ol", ((V)(0D))).Put("op", ((V)(0.5))).V)));
}
ln_1995 = ((V)(string.Concat("M", ToStr(Call(P2_48, V.Undef, Invoke(C_1948, "P", Arr(Add(GetIdx(a_1992, 0D), ((V)(2.4))), GetIdx(a_1992, 1D), z_1989)))), "L", ToStr(Call(P2_48, V.Undef, Invoke(C_1948, "P", Arr(((V)((ToNum((Truthy(i_1990) ? GetIdx(e_1994, 0D) : GetIdx(b_1993, 0D))) - 0.8))), GetIdx(b_1993, 1D), z_1989)))))));
s_1950 = ((V)(JsStrBuf.Begin().V(s_1950).S(string.Concat("<g>", ToStr((Truthy(i_1990) ? Call(FLK27_82, V.Undef, ((V)(4.1)), ((V)((-1D)))) : ((V)("")))), "<path d=\"", ToStr(ln_1995), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.5 * ToNum(k_1949)))))), "\" stroke-linecap=\"round\" opacity=\"0.85\" filter=\"url(#l27b1)\"/><path d=\"", ToStr(ln_1995), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(k_1949)))))), "\" stroke-linecap=\"round\"/></g>")).End()));
return default;
}, 2, "", true));
Invoke(Arr(Arr(((V)((-9D))), ((V)((-1.25)))), Arr(((V)(14D)), ((V)(1.25)))), "forEach", Fn((V _arrowThis2007, int _argc1996, V _a1998, V _a1999, V _a2000, V _a2001, V[] _rest1997) => {
V p_2008 = default;
V x_2004 = default;
V z_2006 = default;
{ V _t2002 = ListOf(_a1998);
{ V _t2003 = GetIdx(_t2002, 0D);
x_2004 = _t2003; }
{ V _t2005 = GetIdx(_t2002, 1D);
z_2006 = _t2005; }
}
p_2008 = Invoke(C_1948, "p", x_2004, ((V)((Y_1930 - 2.2))), z_2006);
s_1950 = ((V)(JsStrBuf.Begin().V(s_1950).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_2008, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_2008, 1D))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(k_1949)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_1949)))))), "\" fill=\"#3a3026\" opacity=\"0.7\"/>")).End()));
return default;
}, 1, "", true));
{
V q_2009 = default;
V p_2010 = default;
V b_2011 = default;
q_2009 = Arr(((V)(5D)), ((V)((Y_1930 - 0.2))), ((V)(2.7)));
p_2010 = Invoke(C_1948, "P", q_2009);
b_2011 = Invoke(C_1948, "p", ((V)(5D)), ((V)((Y_1930 - 9D))), ((V)(2.7)));
s_1950 = ((V)(JsStrBuf.Begin().V(s_1950).S(string.Concat("<g>", ToStr(Call(lrot_81, V.Undef, p_2010, ((V)(6D)), ((V)(2.8)), ((V)((-0.4))))), "<path d=\"M", ToStr(Call(P2_48, V.Undef, p_2010)), "L", ToStr(Call(P2_48, V.Undef, b_2011)), "\" stroke=\"#8e8a80\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(k_1949)))))), "\" stroke-dasharray=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_1949)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.25 * ToNum(k_1949)))))), "\" stroke-linecap=\"round\"/>", ToStr(Call(lsph_76, V.Undef, C_1948, Arr(((V)(5D)), ((V)((Y_1930 - 9.6))), ((V)(2.7))), ((V)(0.6)), ((V)("#b8b2a6")))), "</g>")).End()));
}
return NewObj(3).Put("defs", DEF27_77).Put("front", s_1950).Put("bb", Invoke(C_1948, "bb", ((V)(5D)))).V;
return default;
}, 1, "", true));
return D_1932;
return default;
}, 1, "", true));
Set(N_70, "barn27", Fn((V _arrowThis2019, int _argc2012, V S_2018, V _a2015, V _a2016, V _a2017, V[] _rest2013) => {
double T_2020 = 0;
V GR_2021 = default;
V D_2022 = default;
V prof_2023 = default;
V rr_2024 = default;
T_2020 = 56D;
GR_2021 = ((V)("#2f5f4c"));
D_2022 = NewObj(5).Put("w", ((V)(36D))).Put("d", ((V)(36D))).Put("zs", ((V)(1.6))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis2031, int _argc2025, V _a2027, V _a2028, V _a2029, V _a2030, V[] _rest2026) => {
return Arr();
}, 0, "build", true)).V;
prof_2023 = Arr(Arr(((V)((T_2020 - 20D))), ((V)(2.6))), Arr(((V)((T_2020 - 21.6))), ((V)(4.8))), Arr(((V)((T_2020 - 24D))), ((V)(9D))), Arr(((V)((T_2020 - 27.5))), ((V)(13.2))), Arr(((V)((T_2020 - 30D))), ((V)(15.6))), Arr(((V)((T_2020 - 31D))), ((V)(16.2))));
rr_2024 = Fn((V _arrowThis2039, int _argc2032, V y_2038, V _a2035, V _a2036, V _a2037, V[] _rest2033) => {
{
double i_2040 = 0;
i_2040 = 1D;
while (true) {
if (!(Lt(((V)(i_2040)), Get(prof_2023, "length")))) break;
V ya_2042 = default;
V ra_2043 = default;
V yb_2044 = default;
V rb_2045 = default;
{ V _t2046 = GetIdx(prof_2023, (i_2040 - 1D));
{ V _t2047 = ListOf(_t2046);
{ V _t2048 = GetIdx(_t2047, 0D);
ya_2042 = _t2048; }
{ V _t2049 = GetIdx(_t2047, 1D);
ra_2043 = _t2049; }
} }
{ V _t2050 = GetIdx(prof_2023, i_2040);
{ V _t2051 = ListOf(_t2050);
{ V _t2052 = GetIdx(_t2051, 0D);
yb_2044 = _t2052; }
{ V _t2053 = GetIdx(_t2051, 1D);
rb_2045 = _t2053; }
} }
if (Ge(y_2038, yb_2044)) {
return Add(ra_2043, ((V)((((ToNum(rb_2045) - ToNum(ra_2043)) * (ToNum(ya_2042) - ToNum(y_2038))) / (ToNum(ya_2042) - ToNum(yb_2044))))));
}
i_2040++;
}
}
return ((V)(16.2));
return default;
}, 1, "", true);
Set(D_2022, "fx", Fn((V _arrowThis2061, int _argc2054, V ctx_2060, V _a2057, V _a2058, V _a2059, V[] _rest2055) => {
V C_2062 = default;
V k_2063 = default;
V R_2064 = default;
V sh_2065 = default;
V rim_2066 = default;
C_2062 = Call(cam_71, V.Undef, ctx_2060);
k_2063 = Get(C_2062, "k");
R_2064 = Call(rng_13, V.Undef, ((V)("barn27")));
sh_2065 = Call(lglow_78, V.Undef, C_2062, Arr(((V)(0D)), ((V)((T_2020 - 36D))), ((V)(0D))), ((V)(30D)), ((V)(0.7)), Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.6;0.85;0.6")), ((V)(5D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D)))));
{
V a_2067 = default;
V b_2068 = default;
V d_2069 = default;
a_2067 = Invoke(C_2062, "p", ((V)(0D)), ((V)((T_2020 - 1.4))), ((V)(0D)));
b_2068 = Invoke(C_2062, "p", ((V)(0D)), ((V)((T_2020 - 17D))), ((V)(0D)));
d_2069 = ((V)(string.Concat("M", ToStr(Call(P2_48, V.Undef, a_2067)), "L", ToStr(Call(P2_48, V.Undef, b_2068)))));
sh_2065 = ((V)(JsStrBuf.Begin().V(sh_2065).S(string.Concat("<path d=\"", ToStr(d_2069), "\" stroke=\"#3a2a1e\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1D * ToNum(k_2063)))))), "\"/><path d=\"", ToStr(d_2069), "\" stroke=\"#c9b08a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.75 * ToNum(k_2063)))))), "\" stroke-dasharray=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(k_2063)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(k_2063)))))), "\"/>")).End()));
}
sh_2065 = Add(sh_2065, Add(Call(lcyl_75, V.Undef, C_2062, Arr(((V)(0D)), ((V)((T_2020 - 17D))), ((V)(0D))), Arr(((V)(0D)), ((V)((T_2020 - 20.4))), ((V)(0D))), ((V)(2.2)), ((V)("#9a9c98")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.4))).V), Call(lcyl_75, V.Undef, C_2062, Arr(((V)(0D)), ((V)((T_2020 - 19.6))), ((V)(0D))), Arr(((V)(0D)), ((V)((T_2020 - 20.6))), ((V)(0D))), ((V)(3D)), ((V)("#8a8c88")), NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.4))).V)));
{
double i_2070 = 0;
i_2070 = 1D;
while (true) {
if (!(Lt(((V)(i_2070)), Get(prof_2023, "length")))) break;
sh_2065 = Add(sh_2065, Call(lcyl_75, V.Undef, C_2062, Arr(((V)(0D)), GetIdx(GetIdx(prof_2023, (i_2070 - 1D)), 0D), ((V)(0D))), Arr(((V)(0D)), GetIdx(GetIdx(prof_2023, i_2070), 0D), ((V)(0D))), GetIdx(GetIdx(prof_2023, (i_2070 - 1D)), 1D), GR_2021, NewObj(3).Put("r2", GetIdx(GetIdx(prof_2023, i_2070), 1D)).Put("ol", ((V)(0D))).Put("mat", ((V)("gloss"))).V));
i_2070++;
}
}
{
V H2_2072 = default;
H2_2072 = Arr();
Invoke(prof_2023, "forEach", Fn((V _arrowThis2084, int _argc2073, V _a2075, V _a2076, V _a2077, V _a2078, V[] _rest2074) => {
V y_2081 = default;
V r_2083 = default;
{ V _t2079 = ListOf(_a2075);
{ V _t2080 = GetIdx(_t2079, 0D);
y_2081 = _t2080; }
{ V _t2082 = GetIdx(_t2079, 1D);
r_2083 = _t2082; }
}
Invoke(H2_2072, "push", Invoke(C_2062, "p", ((V)((ToNum(r_2083) * FdLibm.Sin((ToNum(Get(C_2062, "thV")) - (PI_11 / 2D)))))), y_2081, ((V)((ToNum(r_2083) * FdLibm.Cos((ToNum(Get(C_2062, "thV")) - (PI_11 / 2D))))))));
return default;
}, 1, "", true));
Invoke(Invoke(Invoke(prof_2023, "slice"), "reverse"), "forEach", Fn((V _arrowThis2096, int _argc2085, V _a2087, V _a2088, V _a2089, V _a2090, V[] _rest2086) => {
V y_2093 = default;
V r_2095 = default;
{ V _t2091 = ListOf(_a2087);
{ V _t2092 = GetIdx(_t2091, 0D);
y_2093 = _t2092; }
{ V _t2094 = GetIdx(_t2091, 1D);
r_2095 = _t2094; }
}
return Invoke(H2_2072, "push", Invoke(C_2062, "p", ((V)((ToNum(r_2095) * FdLibm.Sin(ToNum(Add(Get(C_2062, "thV"), ((V)((PI_11 / 2D))))))))), y_2093, ((V)((ToNum(r_2095) * FdLibm.Cos(ToNum(Add(Get(C_2062, "thV"), ((V)((PI_11 / 2D)))))))))));
}, 1, "", true));
sh_2065 = ((V)(JsStrBuf.Begin().V(sh_2065).S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(H2_2072, "map", P2_48), "join", ((V)("L")))), "Z\" fill=\"none\" stroke=\"#16302a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(k_2063)))))), "\" stroke-linejoin=\"round\"/>")).End()));
}
Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis2104, int _argc2097, V i_2103, V _a2100, V _a2101, V _a2102, V[] _rest2098) => {
V a_2105 = default;
double y_2106 = 0;
V r0_2107 = default;
V p_2108 = default;
double w_2109 = 0;
a_2105 = Add(Get(C_2062, "thV"), ((V)(((ToNum(Call(R_2064, V.Undef)) - 0.5) * 2.4))));
y_2106 = (LtN(i_2103, 5D) ? ((T_2020 - 30.2) + (ToNum(Call(R_2064, V.Undef)) * 1.2)) : ((T_2020 - 22D) - (ToNum(Call(R_2064, V.Undef)) * 5D)));
r0_2107 = Add(Call(rr_2024, V.Undef, ((V)(y_2106))), ((V)(0.08)));
p_2108 = Invoke(C_2062, "p", ((V)((ToNum(r0_2107) * FdLibm.Sin(ToNum(a_2105))))), ((V)(y_2106)), ((V)((ToNum(r0_2107) * FdLibm.Cos(ToNum(a_2105))))));
w_2109 = (((0.45 + (ToNum(Call(R_2064, V.Undef)) * 0.6)) * ToNum(k_2063)) * FdLibm.Cos((ToNum(a_2105) - ToNum(Get(C_2062, "thV")))));
sh_2065 = ((V)(JsStrBuf.Begin().V(sh_2065).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_2108, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_2108, 1D))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((w_2109 + (0.25 * ToNum(k_2063))))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.55 * ToNum(k_2063)))))), "\" fill=\"#9fb8aa\" opacity=\"0.5\"/><ellipse cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_2108, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_2108, 1D))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)(w_2109)))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.38 * ToNum(k_2063)))))), "\" fill=\"#1a1c1a\"/>")).End()));
return default;
}, 1, "", true));
{
V P_2110 = default;
P_2110 = Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis2118, int _argc2111, V i_2117, V _a2114, V _a2115, V _a2116, V[] _rest2112) => {
double y_2119 = 0;
y_2119 = ((T_2020 - 20.6) - (ToNum(i_2117) * 1.2));
return Invoke(C_2062, "p", ((V)((ToNum(Call(rr_2024, V.Undef, ((V)(y_2119)))) * FdLibm.Sin((ToNum(Get(C_2062, "thV")) - 0.55))))), ((V)(y_2119)), ((V)((ToNum(Call(rr_2024, V.Undef, ((V)(y_2119)))) * FdLibm.Cos((ToNum(Get(C_2062, "thV")) - 0.55))))));
return default;
}, 1, "", true));
sh_2065 = ((V)(JsStrBuf.Begin().V(sh_2065).S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(P_2110, "map", P2_48), "join", ((V)("L")))), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.8 * ToNum(k_2063)))))), "\" fill=\"none\" opacity=\"0.5\" stroke-linecap=\"round\"/>")).End()));
}
rim_2066 = Fn((V _arrowThis2130, int _argc2120, V y_2126, V r0_2127, V w_2128, V col_2129, V[] _rest2121) => {
V P_2131 = default;
P_2131 = Call(lring_79, V.Undef, C_2062, y_2126, r0_2127, ((V)(((ToNum(Get(C_2062, "thV")) - (PI_11 / 2D)) - 0.15))), Add(Add(Get(C_2062, "thV"), ((V)((PI_11 / 2D)))), ((V)(0.15))), ((V)(26D)));
return ((V)(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(P_2131, "map", P2_48), "join", ((V)("L")))), "\" stroke=\"", ToStr(col_2129), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(w_2128) * ToNum(k_2063)))))), "\" fill=\"none\" stroke-linecap=\"round\"/>")));
return default;
}, 4, "", true);
sh_2065 = Add(sh_2065, Add(Add(Call(rim_2066, V.Undef, ((V)((T_2020 - 31.1))), ((V)(16.3)), ((V)(1.9)), ((V)("#cfcabe"))), Call(rim_2066, V.Undef, ((V)((T_2020 - 31D))), ((V)(16.3)), ((V)(1.4)), ((V)("#f1eee6")))), Call(rim_2066, V.Undef, ((V)((T_2020 - 30.7))), ((V)(16.4)), ((V)(0.45)), ((V)("#ffffff")))));
sh_2065 = ((V)(JsStrBuf.Begin().V(sh_2065).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(Invoke(C_2062, "p", ((V)(0D)), ((V)((T_2020 - 32.2))), ((V)(0D))), 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(Invoke(C_2062, "p", ((V)(0D)), ((V)((T_2020 - 32.2))), ((V)(0D))), 1D))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((11D * ToNum(k_2063)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.6 * ToNum(k_2063)))))), "\" fill=\"#fff2c8\" opacity=\"0.55\" filter=\"url(#l27b1)\"/>")).End()));
return NewObj(3).Put("defs", DEF27_77).Put("front", ((V)(JsStrBuf.Begin().V(Call(lcyl_75, V.Undef, C_2062, Arr(((V)(0D)), ((V)((T_2020 - 1.4))), ((V)(0D))), Arr(((V)(0D)), ((V)(T_2020)), ((V)(0D))), ((V)(3.6)), ((V)("#9a9c98")), NewObj(1).Put("mat", ((V)("metal"))).V)).S(string.Concat("<g>", ToStr(Call(lswing_80, V.Undef, C_2062, Arr(((V)(0D)), ((V)((T_2020 - 1.4))), ((V)(0D))), ((V)(1.8)), ((V)(6D)))), ToStr(sh_2065), "</g>")).End()))).Put("bb", Invoke(C_2062, "bb", ((V)(5D)))).V;
return default;
}, 1, "", true));
return D_2022;
return default;
}, 1, "", true));
Set(N_70, "globe27", Fn((V _arrowThis2139, int _argc2132, V S_2138, V _a2135, V _a2136, V _a2137, V[] _rest2133) => {
double T_2140 = 0;
V GD_2141 = default;
V XS_2142 = default;
double YC_2143 = 0;
double RG_2144 = 0;
V D_2145 = default;
T_2140 = 50D;
GD_2141 = ((V)("#c9a04a"));
XS_2142 = Arr(((V)((-20D))), ((V)(0D)), ((V)(20D)));
YC_2143 = 22D;
RG_2144 = 7.2;
D_2145 = NewObj(5).Put("w", ((V)(62D))).Put("d", ((V)(20D))).Put("zs", ((V)(1.5))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis2152, int _argc2146, V _a2148, V _a2149, V _a2150, V _a2151, V[] _rest2147) => {
return Arr();
}, 0, "build", true)).V;
Set(D_2145, "fx", Fn((V _arrowThis2160, int _argc2153, V ctx_2159, V _a2156, V _a2157, V _a2158, V[] _rest2154) => {
V C_2161 = default;
V k_2162 = default;
V v_2163 = default;
V s_2164 = default;
V L_2165 = default;
C_2161 = Call(cam_71, V.Undef, ctx_2159);
k_2162 = Get(C_2161, "k");
v_2163 = Get(C_2161, "v");
s_2164 = Call(lbox_74, V.Undef, C_2161, NewObj(7).Put("c", Arr(((V)(0D)), ((V)((T_2140 - 1.6))), ((V)(0D)))).Put("w", ((V)(50D))).Put("h", ((V)(1.6))).Put("d", ((V)(5D))).Put("col", GD_2141).Put("r", ((V)(1.2))).Put("gl", ((V)(0.2))).V);
L_2165 = Invoke(XS_2142, "map", Fn((V _arrowThis2174, int _argc2166, V x_2172, V i_2173, V _a2170, V _a2171, V[] _rest2167) => {
V top_2175 = default;
V cap_2176 = default;
V c_2177 = default;
double Rr_2178 = 0;
JsStrBuf g_2179 = null;
JsStrBuf rb_2180 = null;
JsStrBuf rf_2181 = null;
V bq_2182 = default;
V b_2183 = default;
V fl_2184 = default;
top_2175 = Arr(x_2172, ((V)((T_2140 - 1.6))), ((V)(0D)));
cap_2176 = Arr(x_2172, ((V)(((YC_2143 + RG_2144) + 2.2))), ((V)(0D)));
c_2177 = Invoke(C_2161, "P", Arr(x_2172, ((V)(YC_2143)), ((V)(0D))));
Rr_2178 = (RG_2144 * ToNum(k_2162));
g_2179 = new JsStrBuf(JsStrBuf.Begin().V(Call(lglow_78, V.Undef, C_2161, Arr(x_2172, ((V)((YC_2143 - 2D))), ((V)(0D))), ((V)(20D)), ((V)(0.55)), Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.45;0.75;0.45")), Add(((V)(4D)), i_2173), ((V)((-ToNum(i_2173)))), Call(SPL_15, V.Undef, ((V)(2D)))))).S(string.Concat("<path d=\"M", ToStr(Call(P2_48, V.Undef, Invoke(C_2161, "P", top_2175))), "L", ToStr(Call(P2_48, V.Undef, Invoke(C_2161, "P", cap_2176))), "\" stroke=\"#1e1a16\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(k_2162)))))), "\"/>")).End());
rb_2180 = new JsStrBuf("");
rf_2181 = new JsStrBuf("");
Call(rep_18, V.Undef, ((V)(18D)), Fn((V _arrowThis2192, int _argc2185, V j_2191, V _a2188, V _a2189, V _a2190, V[] _rest2186) => {
double a_2193 = 0;
V d_2194 = default;
a_2193 = (((ToNum(j_2191) / 18D) * 2D) * PI_11);
d_2194 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Call(rep_18, V.Undef, ((V)(13D)), Fn((V _arrowThis2202, int _argc2195, V m_2201, V _a2198, V _a2199, V _a2200, V[] _rest2196) => {
double lat_2203 = 0;
lat_2203 = ((-1.25) + ((2.5 * ToNum(m_2201)) / 12D));
return Call(P2_48, V.Undef, Invoke(C_2161, "P", Arr(Add(x_2172, ((V)(((RG_2144 * FdLibm.Cos(lat_2203)) * FdLibm.Sin(a_2193))))), ((V)((YC_2143 + (RG_2144 * FdLibm.Sin(lat_2203))))), ((V)(((RG_2144 * FdLibm.Cos(lat_2203)) * FdLibm.Cos(a_2193)))))));
return default;
}, 1, "", true)), "join", ((V)("L")))).End()));
if (Truthy(Call(front_84, V.Undef, C_2161, ((V)(FdLibm.Sin(a_2193))), ((V)(FdLibm.Cos(a_2193)))))) {
rf_2181.V(d_2194);
} else {
rb_2180.V(d_2194);
}
return default;
}, 1, "", true));
g_2179.S(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(c_2177, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(c_2177, 1D))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)(Rr_2178)))), "\" fill=\"#eef6f3\" opacity=\"0.16\"/><path d=\"", rb_2180.Str, "\" stroke=\"#b8c8c2\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(k_2162)))))), "\" fill=\"none\" opacity=\"0.45\"/>"));
bq_2182 = Arr(x_2172, ((V)((YC_2143 + 0.6))), ((V)(0D)));
b_2183 = Invoke(C_2161, "P", bq_2182);
fl_2184 = ((V)(string.Concat("M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(b_2183, 0D)) - (1.2 * ToNum(k_2162))))))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(b_2183, 1D), ((V)((0.5 * ToNum(k_2162))))))), "L", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(b_2183, 0D)) - (0.6 * ToNum(k_2162))))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(b_2183, 1D)) - (0.8 * ToNum(k_2162))))))), "L", ToStr(Call(f1_16, V.Undef, GetIdx(b_2183, 0D))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(b_2183, 1D), ((V)((0.5 * ToNum(k_2162))))))), "L", ToStr(Call(f1_16, V.Undef, Add(GetIdx(b_2183, 0D), ((V)((0.6 * ToNum(k_2162))))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(b_2183, 1D)) - (0.8 * ToNum(k_2162))))))), "L", ToStr(Call(f1_16, V.Undef, Add(GetIdx(b_2183, 0D), ((V)((1.2 * ToNum(k_2162))))))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(b_2183, 1D), ((V)((0.5 * ToNum(k_2162))))))))));
g_2179.V(Add(Call(lcyl_75, V.Undef, C_2161, Arr(x_2172, ((V)((YC_2143 + 5.2))), ((V)(0D))), Arr(x_2172, ((V)((YC_2143 + 3D))), ((V)(0D))), ((V)(0.9)), ((V)("#d9c08a")), NewObj(2).Put("op", ((V)(0.6))).Put("olw", ((V)(0.2))).V), Call(lsph_76, V.Undef, C_2161, bq_2182, ((V)(2.6)), ((V)("#f6d590")), NewObj(1).Put("op", ((V)(0.5))).V))).S(string.Concat("<g>", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.85;1;0.85")), ((V)((2.2 + (ToNum(i_2173) * 0.4)))), ((V)(((-ToNum(i_2173)) * 0.5))), Call(SPL_15, V.Undef, ((V)(2D))))), "<path d=\"", ToStr(fl_2184), "\" stroke=\"#ff9a2a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1D * ToNum(k_2162)))))), "\" fill=\"none\" opacity=\"0.7\" filter=\"url(#l27b1)\"/><path d=\"", ToStr(fl_2184), "\" stroke=\"#ffe08a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.28 * ToNum(k_2162)))))), "\" fill=\"none\" stroke-linejoin=\"round\"/></g>"));
g_2179.S(string.Concat("<path d=\"", rf_2181.Str, "\" stroke=\"#8ea29b\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.55 * ToNum(k_2162)))))), "\" fill=\"none\" opacity=\"0.35\" transform=\"translate(", ToStr(Call(f1_16, V.Undef, ((V)((0.2 * ToNum(k_2162)))))), " 0)\"/><path d=\"", rf_2181.Str, "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(k_2162)))))), "\" fill=\"none\" opacity=\"0.6\"/>")).S(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(c_2177, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(c_2177, 1D))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)(Rr_2178)))), "\" fill=\"none\" stroke=\"#9fb2ac\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(k_2162)))))), "\" opacity=\"0.8\"/>")).S(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(c_2177, 0D)) - (Rr_2178 * 0.78)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(c_2177, 1D)) - (Rr_2178 * 0.2)))))), "A", ToStr(Call(f1_16, V.Undef, ((V)((Rr_2178 * 0.82))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((Rr_2178 * 0.82))))), " 0 0 1 ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(c_2177, 0D)) - (Rr_2178 * 0.1)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(c_2177, 1D)) - (Rr_2178 * 0.8)))))), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.9 * ToNum(k_2162)))))), "\" fill=\"none\" opacity=\"0.7\" stroke-linecap=\"round\"/><circle cx=\"", ToStr(Call(f1_16, V.Undef, Add(GetIdx(c_2177, 0D), ((V)((Rr_2178 * 0.35)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(c_2177, 1D)) - (Rr_2178 * 0.5)))))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(k_2162)))))), "\" fill=\"#ffffff\" opacity=\"0.85\"/>"));
g_2179.V(Add(Call(lcyl_75, V.Undef, C_2161, Arr(x_2172, ((V)((YC_2143 + (RG_2144 * 0.93)))), ((V)(0D))), Arr(x_2172, ((V)(((YC_2143 + RG_2144) + 0.2))), ((V)(0D))), ((V)(2.4)), ((V)("#e8f0ec")), NewObj(2).Put("op", ((V)(0.5))).Put("olw", ((V)(0.3))).V), Call(lcyl_75, V.Undef, C_2161, Arr(x_2172, ((V)(((YC_2143 + RG_2144) + 2.4))), ((V)(0D))), Arr(x_2172, ((V)(((YC_2143 + RG_2144) - 0.2))), ((V)(0D))), ((V)(1.7)), GD_2141, NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.4))).V)));
return NewObj(2).Put("q", Arr(x_2172, ((V)(YC_2143)), ((V)(0D)))).Put("s", ((V)(string.Concat("<g>", ToStr(Call(lswing_80, V.Undef, C_2161, top_2175, ((V)(1.4)), ((V)((5.5 + (ToNum(i_2173) * 0.8)))), ((V)(((-ToNum(i_2173)) * 1.3))))), g_2179.Str, "</g>")))).V;
return default;
}, 2, "", true));
return NewObj(3).Put("defs", DEF27_77).Put("front", Add(s_2164, Call(zsort_73, V.Undef, C_2161, L_2165))).Put("bb", Invoke(C_2161, "bb", ((V)(5D)))).V;
return default;
}, 1, "", true));
return D_2145;
return default;
}, 1, "", true));
Set(N_70, "alab27", Fn((V _arrowThis2211, int _argc2204, V S_2210, V _a2207, V _a2208, V _a2209, V[] _rest2205) => {
double T_2212 = 0;
double YB_2213 = 0;
double L_2214 = 0;
V GD_2215 = default;
V XS_2216 = default;
V D_2217 = default;
T_2212 = 54D;
YB_2213 = 30D;
L_2214 = 30D;
GD_2215 = ((V)("#c9a04a"));
XS_2216 = Arr(((V)((-24D))), ((V)((-12D))), ((V)(0D)), ((V)(12D)), ((V)(24D)));
D_2217 = NewObj(5).Put("w", ((V)(70D))).Put("d", ((V)(22D))).Put("zs", ((V)(1.5))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis2224, int _argc2218, V _a2220, V _a2221, V _a2222, V _a2223, V[] _rest2219) => {
return Arr();
}, 0, "build", true)).V;
Set(D_2217, "fx", Fn((V _arrowThis2232, int _argc2225, V ctx_2231, V _a2228, V _a2229, V _a2230, V[] _rest2226) => {
V C_2233 = default;
V k_2234 = default;
V R_2235 = default;
V s_2236 = default;
V Ls_2237 = default;
C_2233 = Call(cam_71, V.Undef, ctx_2231);
k_2234 = Get(C_2233, "k");
R_2235 = Call(rng_13, V.Undef, ((V)("alab27")));
s_2236 = Call(lglow_78, V.Undef, C_2233, Arr(((V)(0D)), ((V)((YB_2213 - 14D))), ((V)(0D))), ((V)(52D)), ((V)(0.5)), Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.4;0.6;0.4")), ((V)(7D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D)))), ((V)("l27a")));
Invoke(Arr(((V)(((-L_2214) + 6D))), ((V)((L_2214 - 6D)))), "forEach", Fn((V _arrowThis2245, int _argc2238, V x_2244, V _a2241, V _a2242, V _a2243, V[] _rest2239) => {
s_2236 = Add(s_2236, Add(Call(lcyl_75, V.Undef, C_2233, Arr(x_2244, ((V)((T_2212 - 1.4))), ((V)(0D))), Arr(x_2244, ((V)(T_2212)), ((V)(0D))), ((V)(3.4)), GD_2215, NewObj(1).Put("mat", ((V)("metal"))).V), Call(lcyl_75, V.Undef, C_2233, Arr(x_2244, ((V)((YB_2213 + 1.8))), ((V)(0D))), Arr(x_2244, ((V)((T_2212 - 1.4))), ((V)(0D))), ((V)(0.45)), GD_2215, NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.35))).V)));
return default;
}, 1, "", true));
s_2236 = Add(s_2236, Call(lbox_74, V.Undef, C_2233, NewObj(6).Put("c", Arr(((V)(0D)), ((V)(YB_2213)), ((V)(0D)))).Put("w", ((V)((2D * L_2214)))).Put("h", ((V)(1.8))).Put("d", ((V)(1.8))).Put("col", ((V)("#c39a46"))).Put("gl", ((V)(0.2))).V));
s_2236 = Add(s_2236, Invoke(Call(rep_18, V.Undef, ((V)(30D)), Fn((V _arrowThis2253, int _argc2246, V i_2252, V _a2249, V _a2250, V _a2251, V[] _rest2247) => {
V p_2254 = default;
p_2254 = Invoke(C_2233, "p", Add(((V)((((-L_2214) + 1D) + (ToNum(i_2252) * 2D)))), Call(R_2235, V.Undef)), ((V)(((YB_2213 + 0.3) + (ToNum(Call(R_2235, V.Undef)) * 1.2)))), ((V)(0.95)));
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_2254, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_2254, 1D))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(k_2234)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_2234)))))), "\" fill=\"", (NumTruthy((ToNum(i_2252) % 2D)) ? "#8a6420" : "#ffe6a0"), "\" opacity=\"0.55\"/>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2262, int _argc2255, V sg_2261, V _a2258, V _a2259, V _a2260, V[] _rest2256) => {
V c_2263 = default;
c_2263 = Invoke(C_2233, "P", Arr(((V)((ToNum(sg_2261) * L_2214))), ((V)((YB_2213 + 0.9))), ((V)(0D))));
s_2236 = ((V)(JsStrBuf.Begin().V(s_2236).S(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, GetIdx(c_2263, 0D))), " ", ToStr(Call(f1_16, V.Undef, GetIdx(c_2263, 1D))), "c", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(sg_2261) * 1.6) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.4) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(sg_2261) * 2.4) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((1.4 * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(sg_2261) * 1.6) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((2.4 * ToNum(k_2234)))))), "c", ToStr(Call(f1_16, V.Undef, ((V)((((-ToNum(sg_2261)) * 0.8) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.9 * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((((-ToNum(sg_2261)) * 1.8) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.1 * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((((-ToNum(sg_2261)) * 1.4) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.8) * ToNum(k_2234)))))), "\" stroke=\"#6a4612\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.3 * ToNum(k_2234)))))), "\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, GetIdx(c_2263, 0D))), " ", ToStr(Call(f1_16, V.Undef, GetIdx(c_2263, 1D))), "c", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(sg_2261) * 1.6) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.4) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(sg_2261) * 2.4) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((1.4 * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(sg_2261) * 1.6) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((2.4 * ToNum(k_2234)))))), "c", ToStr(Call(f1_16, V.Undef, ((V)((((-ToNum(sg_2261)) * 0.8) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.9 * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((((-ToNum(sg_2261)) * 1.8) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.1 * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((((-ToNum(sg_2261)) * 1.4) * ToNum(k_2234)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.8) * ToNum(k_2234)))))), "\" stroke=\"", ToStr(GD_2215), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.85 * ToNum(k_2234)))))), "\" fill=\"none\" stroke-linecap=\"round\"/>")).End()));
return default;
}, 1, "", true));
{
V a_2264 = default;
V b_2265 = default;
a_2264 = Invoke(C_2233, "p", ((V)(((-L_2214) + 2D))), ((V)((YB_2213 + 1.6))), ((V)(0.9)));
b_2265 = Invoke(C_2233, "p", ((V)((L_2214 - 2D))), ((V)((YB_2213 + 1.6))), ((V)(0.9)));
s_2236 = ((V)(JsStrBuf.Begin().V(s_2236).S(string.Concat("<ellipse cx=\"0\" cy=\"0\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((2.2 * ToNum(k_2234)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(k_2234)))))), "\" fill=\"#fff6d0\" opacity=\"0\"><animateMotion path=\"M", ToStr(Call(P2_48, V.Undef, a_2264)), "L", ToStr(Call(P2_48, V.Undef, b_2265)), "\" dur=\"9s\" repeatCount=\"indefinite\" keyPoints=\"0;0;1\" keyTimes=\"0;0.55;1\" calcMode=\"linear\"/><animate attributeName=\"opacity\" values=\"0;0;0.9;0\" keyTimes=\"0;0.55;0.8;1\" dur=\"9s\" repeatCount=\"indefinite\"/></ellipse>")).End()));
}
Ls_2237 = Invoke(XS_2216, "map", Fn((V _arrowThis2274, int _argc2266, V x_2272, V i_2273, V _a2270, V _a2271, V[] _rest2267) => {
double y0_2275 = 0;
double y1_2276 = 0;
V a0_2277 = default;
V g_2278 = default;
JsStrBuf vn_2279 = null;
y0_2275 = (YB_2213 - 4D);
y1_2276 = (YB_2213 - 12.5);
a0_2277 = Get(C_2233, "thV");
g_2278 = Call(lglow_78, V.Undef, C_2233, Arr(x_2272, ((V)((y1_2276 - 2D))), ((V)(0D))), ((V)(15D)), ((V)(0.6)), Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.45;0.85;0.45")), ((V)(6D)), ((V)(((-ToNum(i_2273)) * 1.1))), Call(SPL_15, V.Undef, ((V)(2D)))), ((V)("l27a")));
g_2278 = Add(g_2278, Add(Call(lcyl_75, V.Undef, C_2233, Arr(x_2272, ((V)(YB_2213)), ((V)(0D))), Arr(x_2272, ((V)((y0_2275 + 0.7))), ((V)(0D))), ((V)(0.4)), GD_2215, NewObj(2).Put("mat", ((V)("metal"))).Put("olw", ((V)(0.3))).V), Call(lcyl_75, V.Undef, C_2233, Arr(x_2272, ((V)((y0_2275 + 0.9))), ((V)(0D))), Arr(x_2272, ((V)(y0_2275)), ((V)(0D))), ((V)(2.6)), GD_2215, NewObj(3).Put("mat", ((V)("metal"))).Put("r2", ((V)(3.6))).Put("olw", ((V)(0.35))).V)));
g_2278 = Add(g_2278, Call(lcyl_75, V.Undef, C_2233, Arr(x_2272, ((V)(y0_2275)), ((V)(0D))), Arr(x_2272, ((V)(y1_2276)), ((V)(0D))), ((V)(4.4)), ((V)("#f4e8d4")), NewObj(3).Put("r2", ((V)(5.6))).Put("olw", ((V)(0.5))).Put("olc", ((V)("#b89e7a"))).V));
vn_2279 = new JsStrBuf("");
Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis2287, int _argc2280, V m_2286, V _a2283, V _a2284, V _a2285, V[] _rest2281) => {
V b0_2288 = default;
V d_2289 = default;
b0_2288 = Add(a0_2277, ((V)(((ToNum(Call(R_2235, V.Undef)) - 0.5) * 2.2))));
d_2289 = Invoke(Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis2297, int _argc2290, V q_2296, V _a2293, V _a2294, V _a2295, V[] _rest2291) => {
double f_2298 = 0;
double y_2299 = 0;
double r0_2300 = 0;
V a_2301 = default;
f_2298 = (ToNum(q_2296) / 8D);
y_2299 = (y0_2275 - ((y0_2275 - y1_2276) * f_2298));
r0_2300 = (4.45 + (1.2 * f_2298));
a_2301 = Add(b0_2288, ((V)((0.45 * FdLibm.Sin(((f_2298 * 4D) + (ToNum(m_2286) * 1.7)))))));
return ((FdLibm.Cos((ToNum(a_2301) - ToNum(a0_2277))) > 0.15) ? Invoke(C_2233, "p", Add(x_2272, ((V)((r0_2300 * FdLibm.Sin(ToNum(a_2301)))))), ((V)(y_2299)), ((V)((r0_2300 * FdLibm.Cos(ToNum(a_2301)))))) : V.Null);
return default;
}, 1, "", true)), "filter", G("Boolean"));
if (GtN(Get(d_2289, "length"), 2D)) {
vn_2279.S("M").V(Invoke(Invoke(d_2289, "map", P2_48), "join", ((V)("L"))));
}
return default;
}, 1, "", true));
g_2278 = ((V)(JsStrBuf.Begin().V(g_2278).S(string.Concat("<path d=\"", vn_2279.Str, "\" stroke=\"#c8a676\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_2234)))))), "\" fill=\"none\" opacity=\"0.6\" stroke-linejoin=\"round\"/><path d=\"", vn_2279.Str, "\" stroke=\"#fffaf0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(k_2234)))))), "\" fill=\"none\" opacity=\"0.25\" transform=\"translate(", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(k_2234)))))), " 0)\"/>")).End()));
g_2278 = ((V)(JsStrBuf.Begin().V(g_2278).S(string.Concat("<g>", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.25;0.55;0.25")), ((V)(6D)), ((V)(((-ToNum(i_2273)) * 1.1))), Call(SPL_15, V.Undef, ((V)(2D))))), ToStr(Call(lcyl_75, V.Undef, C_2233, Arr(x_2272, ((V)(y0_2275)), ((V)(0D))), Arr(x_2272, ((V)(y1_2276)), ((V)(0D))), ((V)(4.42)), ((V)("#ffd9a0")), NewObj(3).Put("r2", ((V)(5.62))).Put("ol", ((V)(0D))).Put("noCap", ((V)(1D))).V)), "</g>")).End()));
{
V P_2302 = default;
P_2302 = Invoke(Call(lring_79, V.Undef, C_2233, ((V)(y1_2276)), ((V)(5.7)), ((V)((ToNum(a0_2277) - (PI_11 / 2D)))), Add(a0_2277, ((V)((PI_11 / 2D)))), ((V)(22D))), "map", Fn((V _arrowThis2310, int _argc2303, V q_2309, V _a2306, V _a2307, V _a2308, V[] _rest2304) => {
return Arr(((V)((ToNum(Add(GetIdx(q_2309, 0D), GetIdx(Invoke(C_2233, "p", x_2272, ((V)(0D)), ((V)(0D))), 0D))) - ToNum(GetIdx(Invoke(C_2233, "p", ((V)(0D)), ((V)(0D)), ((V)(0D))), 0D))))), ((V)((ToNum(Add(GetIdx(q_2309, 1D), GetIdx(Invoke(C_2233, "p", x_2272, ((V)(0D)), ((V)(0D))), 1D))) - ToNum(GetIdx(Invoke(C_2233, "p", ((V)(0D)), ((V)(0D)), ((V)(0D))), 1D))))));
}, 1, "", true));
g_2278 = Add(g_2278, Call(tube27_83, V.Undef, C_2233, P_2302, ((V)(0.55)), GD_2215));
}
return NewObj(2).Put("q", Arr(x_2272, ((V)(y0_2275)), ((V)(0D)))).Put("s", g_2278).V;
return default;
}, 2, "", true));
return NewObj(3).Put("defs", DEF27_77).Put("front", Add(s_2236, Call(zsort_73, V.Undef, C_2233, Ls_2237))).Put("bb", Invoke(C_2233, "bb", ((V)(5D)))).V;
return default;
}, 1, "", true));
return D_2217;
return default;
}, 1, "", true));
Set(N_70, "herb27", Fn((V _arrowThis2318, int _argc2311, V S_2317, V _a2314, V _a2315, V _a2316, V[] _rest2312) => {
double T_2319 = 0;
double YR_2320 = 0;
double RR_2321 = 0;
V GD_2322 = default;
V D_2323 = default;
T_2319 = 56D;
YR_2320 = 24D;
RR_2321 = 24D;
GD_2322 = ((V)("#c9a04a"));
D_2323 = NewObj(5).Put("w", ((V)(60D))).Put("d", ((V)(60D))).Put("zs", ((V)(1.4))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis2330, int _argc2324, V _a2326, V _a2327, V _a2328, V _a2329, V[] _rest2325) => {
return Arr();
}, 0, "build", true)).V;
Set(D_2323, "fx", Fn((V _arrowThis2338, int _argc2331, V ctx_2337, V _a2334, V _a2335, V _a2336, V[] _rest2332) => {
V C_2339 = default;
V k_2340 = default;
V R_2341 = default;
V th_2342 = default;
V LC_2343 = default;
V tufts_2344 = default;
V vines_2345 = default;
V dew_2346 = default;
V s_2347 = default;
V soil_2348 = default;
V ul_2349 = default;
V ud_2350 = default;
C_2339 = Call(cam_71, V.Undef, ctx_2337);
k_2340 = Get(C_2339, "k");
R_2341 = Call(rng_13, V.Undef, ((V)("herb27b")));
th_2342 = Get(C_2339, "thV");
LC_2343 = Arr(Arr(((V)("#5f8f3e")), ((V)("#7fae4e")), ((V)("#4e7a34"))), Arr(((V)("#6a4a6e")), ((V)("#83607e")), ((V)("#55385a"))), Arr(((V)("#4e6e48")), ((V)("#6a8a5a")), ((V)("#3e5a3a"))), Arr(((V)("#6f9a4a")), ((V)("#8fb85e")), ((V)("#5a8a3c"))));
tufts_2344 = NewObj(2).Put("f", ((V)(""))).Put("b", ((V)(""))).V;
vines_2345 = NewObj(2).Put("f", ((V)(""))).Put("b", ((V)(""))).V;
dew_2346 = Arr();
Call(rep_18, V.Undef, ((V)(40D)), Fn((V _arrowThis2358, int _argc2351, V i_2357, V _a2354, V _a2355, V _a2356, V[] _rest2352) => {
double a_2359 = 0;
double r0_2360 = 0;
V q_2361 = default;
V p_2362 = default;
double kd_2363 = 0;
V cl_2364 = default;
JsStrBuf g_2365 = null;
a_2359 = ((((ToNum(i_2357) / 40D) * 2D) * PI_11) + (ToNum(Call(R_2341, V.Undef)) * 0.08));
r0_2360 = (RR_2321 + ((ToNum(Call(R_2341, V.Undef)) - 0.5) * 2.2));
q_2361 = Arr(((V)((r0_2360 * FdLibm.Sin(a_2359)))), ((V)((YR_2320 + 1.4))), ((V)((r0_2360 * FdLibm.Cos(a_2359)))));
p_2362 = Invoke(C_2339, "P", q_2361);
kd_2363 = (((ToNum(i_2357) % 7D) == 3D) ? 1D : (((ToNum(i_2357) % 3D) == 0D) ? 2D : (((ToNum(i_2357) % 5D) == 1D) ? 3D : 0D)));
cl_2364 = GetIdx(LC_2343, kd_2363);
g_2365 = new JsStrBuf("");
if ((kd_2363 == 2D)) {
Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis2373, int _argc2366, V j_2372, V _a2369, V _a2370, V _a2371, V[] _rest2367) => {
double an2_2374 = 0;
double l_2375 = 0;
V ex_2376 = default;
double ey_2377 = 0;
an2_2374 = (((ToNum(j_2372) - 2.5) * 0.22) + ((ToNum(Call(R_2341, V.Undef)) - 0.5) * 0.1));
l_2375 = ((3D + (ToNum(Call(R_2341, V.Undef)) * 1.6)) * ToNum(k_2340));
ex_2376 = Add(GetIdx(p_2362, 0D), ((V)((FdLibm.Sin(an2_2374) * l_2375))));
ey_2377 = (ToNum(GetIdx(p_2362, 1D)) - (FdLibm.Cos(an2_2374) * l_2375));
g_2365.S(string.Concat("<path d=\"M", ToStr(Call(P2_48, V.Undef, p_2362)), "L", ToStr(Call(f1_16, V.Undef, ex_2376)), " ", ToStr(Call(f1_16, V.Undef, ((V)(ey_2377)))), "\" stroke=\"", ToStr(GetIdx(cl_2364, 2D)), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_2340)))))), "\"/>"));
Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis2385, int _argc2378, V m_2384, V _a2381, V _a2382, V _a2383, V[] _rest2379) => {
double f_2386 = 0;
V x_2387 = default;
V y_2388 = default;
f_2386 = (0.3 + (ToNum(m_2384) * 0.18));
x_2387 = Add(GetIdx(p_2362, 0D), ((V)(((ToNum(ex_2376) - ToNum(GetIdx(p_2362, 0D))) * f_2386))));
y_2388 = Add(GetIdx(p_2362, 1D), ((V)(((ey_2377 - ToNum(GetIdx(p_2362, 1D))) * f_2386))));
g_2365.S(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_2387) - (0.6 * ToNum(k_2340))))))), " ", ToStr(Call(f1_16, V.Undef, Add(y_2388, ((V)((0.3 * ToNum(k_2340))))))), "L", ToStr(Call(f1_16, V.Undef, x_2387)), " ", ToStr(Call(f1_16, V.Undef, y_2388)), "L", ToStr(Call(f1_16, V.Undef, Add(x_2387, ((V)((0.6 * ToNum(k_2340))))))), " ", ToStr(Call(f1_16, V.Undef, Add(y_2388, ((V)((0.3 * ToNum(k_2340))))))), "\" stroke=\"", ToStr(GetIdx(cl_2364, (ToNum(m_2384) % 2D))), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.25 * ToNum(k_2340)))))), "\" fill=\"none\"/>"));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
} else {
Call(rep_18, V.Undef, ((V)(((kd_2363 == 3D) ? 9D : 6D))), Fn((V _arrowThis2396, int _argc2389, V j_2395, V _a2392, V _a2393, V _a2394, V[] _rest2390) => {
double an2_2397 = 0;
double l_2398 = 0;
V cx_2399 = default;
double cy_2400 = 0;
double rx_2401 = 0;
double ry_2402 = 0;
an2_2397 = (((ToNum(j_2395) - ((kd_2363 == 3D) ? 4D : 2.5)) * ((kd_2363 == 3D) ? 0.3 : 0.45)) + ((ToNum(Call(R_2341, V.Undef)) - 0.5) * 0.2));
l_2398 = ((((kd_2363 == 3D) ? 1.6 : 2.4) * ToNum(k_2340)) * (0.7 + (ToNum(Call(R_2341, V.Undef)) * 0.6)));
cx_2399 = Add(GetIdx(p_2362, 0D), ((V)((FdLibm.Sin(an2_2397) * l_2398))));
cy_2400 = (ToNum(GetIdx(p_2362, 1D)) - ((FdLibm.Cos(an2_2397) * l_2398) * 0.9));
rx_2401 = (((kd_2363 == 3D) ? 0.45 : 0.85) * ToNum(k_2340));
ry_2402 = (((kd_2363 == 3D) ? 0.7 : 1.4) * ToNum(k_2340));
g_2365.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, cx_2399)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)(cy_2400)))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)(rx_2401)))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)(ry_2402)))), "\" fill=\"", ToStr(GetIdx(cl_2364, (ToNum(j_2395) % 3D))), "\" transform=\"rotate(", ToStr(Call(f1_16, V.Undef, ((V)((an2_2397 * 57D))))), " ", ToStr(Call(f1_16, V.Undef, cx_2399)), " ", ToStr(Call(f1_16, V.Undef, ((V)(cy_2400)))), ")\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, cx_2399)), " ", ToStr(Call(f1_16, V.Undef, ((V)((cy_2400 + (ry_2402 * 0.8)))))), "L", ToStr(Call(f1_16, V.Undef, cx_2399)), " ", ToStr(Call(f1_16, V.Undef, ((V)((cy_2400 - (ry_2402 * 0.7)))))), "\" stroke=\"", ToStr(Call(shade_10, V.Undef, GetIdx(cl_2364, (ToNum(j_2395) % 3D)), ((V)(1.3)))), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.12 * ToNum(k_2340)))))), "\" transform=\"rotate(", ToStr(Call(f1_16, V.Undef, ((V)((an2_2397 * 57D))))), " ", ToStr(Call(f1_16, V.Undef, cx_2399)), " ", ToStr(Call(f1_16, V.Undef, ((V)(cy_2400)))), ")\"/>"));
if ((SEqN(j_2395, 2D) && ((ToNum(i_2357) % 4D) == 0D))) {
Invoke(dew_2346, "push", Arr(cx_2399, ((V)((cy_2400 - (ry_2402 * 0.3))))));
}
return default;
}, 1, "", true));
}
if (((ToNum(i_2357) % 9D) == 4D)) {
g_2365.S(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_2362, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(p_2362, 1D)) - (3.4 * ToNum(k_2340))))))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(k_2340)))))), "\" fill=\"#f4efff\"/>"));
}
OpSetK(tufts_2344, ((V)((Truthy(Call(front_84, V.Undef, C_2339, ((V)(FdLibm.Sin(a_2359))), ((V)(FdLibm.Cos(a_2359))))) ? "f" : "b"))), 0, ((V)(string.Concat("<g>", ToStr(Call(lrot_81, V.Undef, p_2362, ((V)((4D + (ToNum(Call(R_2341, V.Undef)) * 3D)))), ((V)((3D + (ToNum(Call(R_2341, V.Undef)) * 2.4)))), ((V)(((-ToNum(Call(R_2341, V.Undef))) * 3D))))), g_2365.Str, "</g>"))));
return default;
}, 1, "", true));
Call(rep_18, V.Undef, ((V)(12D)), Fn((V _arrowThis2410, int _argc2403, V i_2409, V _a2406, V _a2407, V _a2408, V[] _rest2404) => {
double a_2411 = 0;
V q_2412 = default;
V p_2413 = default;
double len_2414 = 0;
V P_2415 = default;
JsStrBuf g_2416 = null;
a_2411 = ((((ToNum(i_2409) / 12D) * 2D) * PI_11) + 0.26);
q_2412 = Arr(((V)(((RR_2321 + 1.8) * FdLibm.Sin(a_2411)))), ((V)((YR_2320 + 0.6))), ((V)(((RR_2321 + 1.8) * FdLibm.Cos(a_2411)))));
p_2413 = Invoke(C_2339, "P", q_2412);
len_2414 = ((8D + ((ToNum(i_2409) * 7D) % 9D)) * ToNum(k_2340));
P_2415 = Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis2424, int _argc2417, V m_2423, V _a2420, V _a2421, V _a2422, V[] _rest2418) => {
return Arr(Add(GetIdx(p_2413, 0D), ((V)(((FdLibm.Sin(ToNum(Add(((V)((ToNum(m_2423) * 0.9))), i_2409))) * 0.7) * ToNum(k_2340))))), Add(GetIdx(p_2413, 1D), ((V)(((len_2414 * ToNum(m_2423)) / 6D)))));
}, 1, "", true));
g_2416 = new JsStrBuf(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(P_2415, "map", P2_48), "join", ((V)("L")))), "\" stroke=\"#4e6e3a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.25 * ToNum(k_2340)))))), "\" fill=\"none\"/>"));
Invoke(Invoke(P_2415, "slice", ((V)(1D))), "forEach", Fn((V _arrowThis2433, int _argc2425, V pp_2431, V m_2432, V _a2429, V _a2430, V[] _rest2426) => {
g_2416.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, Add(GetIdx(pp_2431, 0D), ((V)(((NumTruthy((ToNum(m_2432) % 2D)) ? 0.5 : (-0.5)) * ToNum(k_2340))))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(pp_2431, 1D))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.42 * ToNum(k_2340)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_2340)))))), "\" fill=\"", (NumTruthy((ToNum(m_2432) % 2D)) ? "#7fa05a" : "#5e8a44"), "\"/>"));
return default;
}, 2, "", true));
OpSetK(vines_2345, ((V)((Truthy(Call(front_84, V.Undef, C_2339, ((V)(FdLibm.Sin(a_2411))), ((V)(FdLibm.Cos(a_2411))))) ? "f" : "b"))), 0, ((V)(string.Concat("<g>", ToStr(Call(lrot_81, V.Undef, p_2413, ((V)(3D)), ((V)((4D + ((ToNum(i_2409) % 4D) * 0.6)))), ((V)(((-ToNum(i_2409)) * 0.5))))), g_2416.Str, "</g>"))));
return default;
}, 1, "", true));
s_2347 = Call(lglow_78, V.Undef, C_2339, Arr(((V)(0D)), ((V)((YR_2320 - 8D))), ((V)(0D))), ((V)(46D)), ((V)(0.55)), Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.4;0.65;0.4")), ((V)(6D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D)))), ((V)("l27g")));
s_2347 = Add(s_2347, Invoke(Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis2441, int _argc2434, V i_2440, V _a2437, V _a2438, V _a2439, V[] _rest2435) => {
double a_2442 = 0;
V b_2443 = default;
V t_2444 = default;
a_2442 = (((ToNum(i_2440) * PI_11) / 2D) + (PI_11 / 4D));
b_2443 = Invoke(C_2339, "p", ((V)((RR_2321 * FdLibm.Sin(a_2442)))), ((V)((YR_2320 + 1D))), ((V)((RR_2321 * FdLibm.Cos(a_2442)))));
t_2444 = Invoke(C_2339, "p", ((V)(0D)), ((V)((T_2319 - 1.4))), ((V)(0D)));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(P2_48, V.Undef, t_2444)), "L", ToStr(Call(P2_48, V.Undef, b_2443)), "\" stroke=\"#b8893a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.22 * ToNum(k_2340)))))), "\"/>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
soil_2348 = Call(lring_79, V.Undef, C_2339, ((V)((YR_2320 + 1.2))), ((V)(RR_2321)), ((V)(0D)), ((V)((2D * PI_11))), ((V)(48D)));
s_2347 = ((V)(JsStrBuf.Begin().V(s_2347).V(Get(vines_2345, "b")).S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(soil_2348, "map", P2_48), "join", ((V)("L")))), "Z\" stroke=\"#3a2a1c\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((3.4 * ToNum(k_2340)))))), "\" fill=\"none\"/>")).End()));
s_2347 = Add(s_2347, Add(Add(Call(tube27_83, V.Undef, C_2339, Call(lring_79, V.Undef, C_2339, ((V)((YR_2320 + 1D))), ((V)((RR_2321 + 1.8))), Add(th_2342, ((V)((PI_11 / 2D)))), Add(th_2342, ((V)(((3D * PI_11) / 2D)))), ((V)(30D))), ((V)(1.3)), GD_2322), Call(tube27_83, V.Undef, C_2339, Call(lring_79, V.Undef, C_2339, ((V)((YR_2320 + 1D))), ((V)((RR_2321 - 1.8))), Add(th_2342, ((V)((PI_11 / 2D)))), Add(th_2342, ((V)(((3D * PI_11) / 2D)))), ((V)(30D))), ((V)(1D)), GD_2322)), Get(tufts_2344, "b")));
ul_2349 = Call(lring_79, V.Undef, C_2339, ((V)((YR_2320 - 0.4))), ((V)(RR_2321)), ((V)((ToNum(th_2342) - (PI_11 / 2D)))), Add(th_2342, ((V)((PI_11 / 2D)))), ((V)(30D)));
ud_2350 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(ul_2349, "map", P2_48), "join", ((V)("L")))).End()));
s_2347 = ((V)(JsStrBuf.Begin().V(s_2347).S(string.Concat("<path d=\"", ToStr(ud_2350), "\" stroke=\"#ffd58a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((3D * ToNum(k_2340)))))), "\" fill=\"none\" filter=\"url(#l27b1)\" opacity=\"0.6\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.4;0.75;0.4")), ((V)(6D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "</path>")).End()));
s_2347 = ((V)(JsStrBuf.Begin().V(s_2347).V(Add(Add(Call(tube27_83, V.Undef, C_2339, Call(lring_79, V.Undef, C_2339, ((V)((YR_2320 + 1D))), ((V)((RR_2321 - 1.8))), ((V)((ToNum(th_2342) - (PI_11 / 2D)))), Add(th_2342, ((V)((PI_11 / 2D)))), ((V)(30D))), ((V)(1D)), GD_2322), Get(tufts_2344, "f")), Call(tube27_83, V.Undef, C_2339, Call(lring_79, V.Undef, C_2339, ((V)((YR_2320 + 1D))), ((V)((RR_2321 + 1.8))), ((V)((ToNum(th_2342) - (PI_11 / 2D)))), Add(th_2342, ((V)((PI_11 / 2D)))), ((V)(30D))), ((V)(1.3)), GD_2322))).S(string.Concat("<path d=\"", ToStr(ud_2350), "\" stroke=\"#fff3d4\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(k_2340)))))), "\" fill=\"none\"/>")).V(Get(vines_2345, "f")).End()));
s_2347 = Add(s_2347, Invoke(Invoke(dew_2346, "map", Fn((V _arrowThis2457, int _argc2445, V _a2447, V i_2451, V _a2449, V _a2450, V[] _rest2446) => {
V x_2454 = default;
V y_2456 = default;
{ V _t2452 = ListOf(_a2447);
{ V _t2453 = GetIdx(_t2452, 0D);
x_2454 = _t2453; }
{ V _t2455 = GetIdx(_t2452, 1D);
y_2456 = _t2455; }
}
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_2454) - (0.8 * ToNum(k_2340))))))), " ", ToStr(Call(f1_16, V.Undef, y_2456)), "H", ToStr(Call(f1_16, V.Undef, Add(x_2454, ((V)((0.8 * ToNum(k_2340))))))), "M", ToStr(Call(f1_16, V.Undef, x_2454)), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(y_2456) - (0.8 * ToNum(k_2340))))))), "V", ToStr(Call(f1_16, V.Undef, Add(y_2456, ((V)((0.8 * ToNum(k_2340))))))), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.2 * ToNum(k_2340)))))), "\" stroke-linecap=\"round\" opacity=\"0\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0;0;1;0")), ((V)((4D + (ToNum(i_2451) % 3D)))), ((V)(((-ToNum(i_2451)) * 0.8))), ((V)(" keyTimes=\"0;0.7;0.8;1\"")))), "</path>")));
}, 2, "", true)), "join", ((V)(""))));
return NewObj(3).Put("defs", DEF27_77).Put("front", Add(Call(lcyl_75, V.Undef, C_2339, Arr(((V)(0D)), ((V)((T_2319 - 1.4))), ((V)(0D))), Arr(((V)(0D)), ((V)(T_2319)), ((V)(0D))), ((V)(4.6)), GD_2322, NewObj(1).Put("mat", ((V)("metal"))).V), s_2347)).Put("bb", Invoke(C_2339, "bb", ((V)(6D)))).V;
return default;
}, 1, "", true));
return D_2323;
return default;
}, 1, "", true));
FLOOR27_85 = NewObj(5).Put("ylino", fYlino_38).Put("diner", fDiner_39).Put("quarry", fQuarry_40).Put("oak", fOak_41).Put("cush", fCush_42).V;
MEMO_86 = NewObj(0).V;
draw26_87 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis2466, int _argc2458, V r_2464, V o_2465, V _a2462, V _a2463, V[] _rest2459) => {
V res_2467 = default;
res_2467 = Call(draw26_87, V.Undef, r_2464, o_2465);
if (Truthy(((!(Truthy(res_2467)) ? V.True : V.False) is var _t2468 && Truthy(_t2468) ? _t2468 : Get(res_2467, "_p27")))) {
return res_2467;
}
try {
V f_2469 = default;
V c_2470 = default;
f_2469 = (Get(r_2464, "f27") is var _t2471 && !Truthy(_t2471) ? _t2471 : GetK(FLOOR27_85, Get(r_2464, "f27")));
if (Truthy((f_2469 is var _t2472 && !Truthy(_t2472) ? _t2472 : Get(res_2467, "surf")))) {
Set(res_2467, "_p27", ((V)(1D)));
Set(res_2467, "vb", ((V)("0 0 80 56")));
Set(res_2467, "svg", (GetK(MEMO_86, Get(r_2464, "f27")) is var _t2473 && Truthy(_t2473) ? _t2473 : SetK(MEMO_86, Get(r_2464, "f27"), Invoke(RD_8, "svgDoc", ((V)("0 0 80 56")), Arr(), Call(f_2469, V.Undef)))));
Set(res_2467, "src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Get(res_2467, "svg"))).End())));
}
c_2470 = (Get(r_2464, "c27") is var _t2474 && !Truthy(_t2474) ? _t2474 : GetK(CEIL27_63, Get(r_2464, "c27")));
if (Truthy((c_2470 is var _t2475 && !Truthy(_t2475) ? _t2475 : Get(res_2467, "surf")))) {
V M_2476 = default;
Set(res_2467, "_p27", ((V)(1D)));
Set(res_2467, "vb", ((V)("0 0 80 56")));
M_2476 = (GetK(CMEMO_64, Get(r_2464, "c27")) is var _t2485 && Truthy(_t2485) ? _t2485 : SetK(CMEMO_64, Get(r_2464, "c27"), Call(Fn((V _arrowThis2483, int _argc2477, V _a2479, V _a2480, V _a2481, V _a2482, V[] _rest2478) => {
V G_2484 = default;
G_2484 = Call(mkV_45, V.Undef, Get(CFRM_46, "room"));
return NewObj(2).Put("svg", Invoke(RD_8, "svgDoc", ((V)("0 0 80 56")), Arr(), Call(cardOf27_69, V.Undef, Get(r_2464, "c27")))).Put("room", Invoke(RD_8, "svgDoc", ((V)(JsStrBuf.Begin().S("0 0 ").V(Get(G_2484, "W")).S(" ").V(Get(G_2484, "H")).End())), Arr(), Call(cDoc_54, V.Undef, G_2484, Call(c_2470, V.Undef, G_2484)))).V;
return default;
}, 0, "", true), V.Undef)));
Set(res_2467, "svg", Get(M_2476, "svg"));
Set(res_2467, "src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Get(M_2476, "svg"))).End())));
Set(res_2467, "ceilRoom", Get(M_2476, "room"));
Set(res_2467, "ceilBase", GetIdx(GetK(CB27_66, Get(r_2464, "c27")), 0D));
Set(res_2467, "ceilTrim", GetIdx(GetK(CB27_66, Get(r_2464, "c27")), 1D));
}
} catch (System.Exception _ex2486) {
V e_2487 = default;
e_2487 = Caught(_ex2486);
Invoke(G("console"), "warn", ((V)("reno plus27")), Get(r_2464, "id"), e_2487);
}
return res_2467;
return default;
}, 2, "", true));
WMEMO27_88 = NewObj(0).V;
{
V blot_2488 = default;
V outlet_2489 = default;
V BB_2490 = default;
V SURF12_2491 = default;
double BT_2492 = 0;
double SR_2493 = 0;
V memo_2494 = default;
V capB_2495 = default;
V scf_2496 = default;
V bandC_2497 = default;
V lblot_2498 = default;
V wrapX_2499 = default;
V kDry_2500 = default;
V kVinyl_2501 = default;
V kHerr_2502 = default;
V kCop_2503 = default;
V kQtz_2504 = default;
V draw27w_2505 = default;
{ V _t2506 = Get(RD_8, "H12");
if (_t2506.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2506));
{ V _t2507 = Get(_t2506, "blot");
blot_2488 = _t2507; }
{ V _t2508 = Get(_t2506, "outlet");
outlet_2489 = _t2508; }
{ V _t2509 = Get(_t2506, "BB");
BB_2490 = _t2509; }
{ V _t2510 = Get(_t2506, "SURF12");
SURF12_2491 = _t2510; } }
BT_2492 = 24D;
SR_2493 = 1.4142135623730951D;
memo_2494 = Fn((V _arrowThis2519, int _argc2511, V k_2517, V f_2518, V _a2515, V _a2516, V[] _rest2512) => {
return Fn((V _arrowThis2526, int _argc2520, V _a2522, V _a2523, V _a2524, V _a2525, V[] _rest2521) => {
return (GetK(WMEMO27_88, k_2517) is var _t2527 && Truthy(_t2527) ? _t2527 : SetK(WMEMO27_88, k_2517, Call(f_2518, V.Undef)));
}, 0, "", true);
}, 2, "", true);
capB_2495 = Fn((V _arrowThis2536, int _argc2528, V col_2534, V h_2535, V _a2532, V _a2533, V[] _rest2529) => {
double t_2537 = 0;
t_2537 = (ToNum(BB_2490) - ToNum(h_2535));
return ((V)(string.Concat("<rect y=\"", ToStr(Call(f1_16, V.Undef, ((V)((t_2537 - 0.9))))), "\" width=\"80\" height=\"0.9\" fill=\"#000000\" opacity=\"0.14\" filter=\"url(#wb1)\"/><rect y=\"", ToStr(Call(f1_16, V.Undef, ((V)(t_2537)))), "\" width=\"80\" height=\"", ToStr(Call(f1_16, V.Undef, h_2535)), "\" fill=\"", ToStr(col_2534), "\"/><rect y=\"", ToStr(Call(f1_16, V.Undef, ((V)(t_2537)))), "\" width=\"80\" height=\"0.35\" fill=\"", ToStr(Call(shade_10, V.Undef, col_2534, ((V)(1.14)))), "\"/><rect y=\"", ToStr(Call(f1_16, V.Undef, ((V)((t_2537 + 0.55))))), "\" width=\"80\" height=\"0.2\" fill=\"", ToStr(Call(shade_10, V.Undef, col_2534, ((V)(0.8)))), "\"/><rect y=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(BB_2490) - 0.25))))), "\" width=\"80\" height=\"0.25\" fill=\"", ToStr(Call(shade_10, V.Undef, col_2534, ((V)(0.86)))), "\"/>")));
return default;
}, 2, "", true);
scf_2496 = Fn((V _arrowThis2548, int _argc2538, V seed_2544, V n_2545, V a_2546, V b_2547, V[] _rest2539) => {
V R_2549 = default;
R_2549 = Call(rng_13, V.Undef, seed_2544);
return Invoke(Call(rep_18, V.Undef, n_2545, Fn((V _arrowThis2556, int _argc2550, V _a2552, V _a2553, V _a2554, V _a2555, V[] _rest2551) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_2549, V.Undef)) * 78D))))), " ", ToStr(Call(f1_16, V.Undef, Add(Add(BB_2490, ((V)(0.5))), ((V)((ToNum(Call(R_2549, V.Undef)) * 1.6)))))), "h", ToStr(Call(f1_16, V.Undef, ((V)((0.6 + (ToNum(Call(R_2549, V.Undef)) * 1.6)))))), "\" stroke=\"", ToStr((LtN(Call(R_2549, V.Undef), 0.5) ? a_2546 : b_2547)), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.12 + (ToNum(Call(R_2549, V.Undef)) * 0.16)))))), "\" stroke-linecap=\"round\" opacity=\"0.6\"/>")));
}, 0, "", true)), "join", ((V)("")));
return default;
}, 4, "", true);
bandC_2497 = Fn((V _arrowThis2564, int _argc2557, V id_2563, V _a2560, V _a2561, V _a2562, V[] _rest2558) => {
return ((V)(string.Concat("<clipPath id=\"", ToStr(id_2563), "\"><rect y=\"", NumStr(BT_2492), "\" width=\"80\" height=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(BB_2490) - BT_2492))))), "\"/></clipPath>")));
}, 1, "", true);
lblot_2498 = Fn((V _arrowThis2578, int _argc2565, V seed_2571, V n_2572, V cols_2573, V op_2574, V[] _rest2566) => {
V R_2579 = default;
JsStrBuf o_2580 = null;
V sz_2575 = default;
V y0_2576 = default;
V y1_2577 = default;
sz_2575 = (_argc2565 > 4 ? _rest2566[0] : V.Undef);
y0_2576 = (_argc2565 > 5 ? _rest2566[1] : V.Undef);
y1_2577 = (_argc2565 > 6 ? _rest2566[2] : V.Undef);
R_2579 = Call(rng_13, V.Undef, seed_2571);
o_2580 = new JsStrBuf("<g filter=\"url(#wb2)\">");
Call(rep_18, V.Undef, n_2572, Fn((V _arrowThis2588, int _argc2581, V i_2587, V _a2584, V _a2585, V _a2586, V[] _rest2582) => {
double x_2589 = 0;
V y_2590 = default;
double rx_2591 = 0;
double ry_2592 = 0;
x_2589 = (ToNum(Call(R_2579, V.Undef)) * 80D);
y_2590 = Add(y0_2576, ((V)((ToNum(Call(R_2579, V.Undef)) * (ToNum(y1_2577) - ToNum(y0_2576))))));
rx_2591 = (ToNum(sz_2575) * (0.6 + (ToNum(Call(R_2579, V.Undef)) * 0.9)));
ry_2592 = (rx_2591 * (0.5 + (ToNum(Call(R_2579, V.Undef)) * 0.3)));
Invoke(Arr(((V)((-80D))), ((V)(0D)), ((V)(80D))), "forEach", Fn((V _arrowThis2600, int _argc2593, V dx_2599, V _a2596, V _a2597, V _a2598, V[] _rest2594) => {
V cx_2601 = default;
cx_2601 = Add(((V)(x_2589)), dx_2599);
if ((LtN(Add(cx_2601, ((V)(rx_2591))), (-3D)) || ((ToNum(cx_2601) - rx_2591) > 83D))) {
return default;
}
o_2580.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, cx_2601)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, y_2590)), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)(rx_2591)))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)(ry_2592)))), "\" fill=\"", ToStr(GetIdx(cols_2573, (ToNum(i_2587) % ToNum(Get(cols_2573, "length"))))), "\" opacity=\"", ToStr(op_2574), "\"/>"));
return default;
}, 1, "", true));
return default;
}, 1, "", true));
return ((V)(string.Concat(o_2580.Str, "</g>")));
return default;
}, 7, "", true);
wrapX_2499 = Fn((V _arrowThis2611, int _argc2602, V x_2608, V w_2609, V f_2610, V _a2607, V[] _rest2603) => {
return Invoke(Invoke(Invoke(Arr(((V)((-80D))), ((V)(0D)), ((V)(80D))), "filter", Fn((V _arrowThis2627, int _argc2620, V dx_2626, V _a2623, V _a2624, V _a2625, V[] _rest2621) => {
return ((GtN(Add(Add(x_2608, dx_2626), w_2609), (-1D)) && ((ToNum(Add(x_2608, dx_2626)) - ToNum(w_2609)) < 81D)) ? V.True : V.False);
}, 1, "", true)), "map", Fn((V _arrowThis2619, int _argc2612, V dx_2618, V _a2615, V _a2616, V _a2617, V[] _rest2613) => {
return Call(f_2610, V.Undef, Add(x_2608, dx_2618));
}, 1, "", true)), "join", ((V)("")));
}, 3, "", true);
kDry_2500 = Call(memo_2494, V.Undef, ((V)("k01")), Fn((V _arrowThis2634, int _argc2628, V _a2630, V _a2631, V _a2632, V _a2633, V[] _rest2629) => {
V R_2635 = default;
JsStrBuf s_2636 = null;
V sup_2637 = default;
V SP_2638 = default;
V run_2639 = default;
V board_2640 = default;
R_2635 = Call(rng_13, V.Undef, ((V)("kd01")));
s_2636 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"80\" height=\"56\" fill=\"#dcd2bd\"/>").V(Call(blot_2488, V.Undef, ((V)("kd01")), ((V)(32D)), Arr(((V)("#e3dac7")), ((V)("#d2c7b0")), ((V)("#d8cdb7"))), ((V)(0.4)), ((V)(3D)))).End());
Invoke(Arr(((V)(0D)), ((V)(40D)), ((V)(80D))), "forEach", Fn((V _arrowThis2648, int _argc2641, V x_2647, V _a2644, V _a2645, V _a2646, V[] _rest2642) => {
return ((V)(s_2636.S(string.Concat("<rect x=\"", NumStr((ToNum(x_2647) - 2.6)), "\" width=\"5.2\" height=\"56\" fill=\"#e7dfcd\" opacity=\"0.6\" filter=\"url(#wb2)\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_2647) - 1.05))))), " 0V56M", ToStr(Call(f1_16, V.Undef, Add(x_2647, ((V)(1.05))))), " 0V56\" stroke=\"#bdb197\" stroke-width=\"0.1\" opacity=\"0.55\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, Add(x_2647, ((V)(0.2))))), " 0V56\" stroke=\"#c9bea6\" stroke-width=\"0.08\" opacity=\"0.5\"/>")).Str));
}, 1, "", true));
s_2636.S("<rect y=\"26.4\" width=\"80\" height=\"4.2\" fill=\"#e7dfcd\" opacity=\"0.5\" filter=\"url(#wb2)\"/><path d=\"M0 27.6H80M0 29.4H80\" stroke=\"#bdb197\" stroke-width=\"0.08\" opacity=\"0.45\"/>");
{
double x_2649 = 0;
x_2649 = 4D;
while (true) {
if (!((x_2649 < 80D))) break;
{
double y_2651 = 0;
y_2651 = 4D;
while (true) {
if (!((y_2651 < 52D))) break;
double px_2653 = 0;
double py_2654 = 0;
if (LtN(Call(R_2635, V.Undef), 0.3)) {
goto _cont2652;
}
px_2653 = (x_2649 + ((ToNum(Call(R_2635, V.Undef)) - 0.5) * 0.6));
py_2654 = (y_2651 + ((ToNum(Call(R_2635, V.Undef)) - 0.5) * 0.6));
s_2636.S(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)(px_2653)))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)(py_2654)))), "\" r=\"0.34\" fill=\"#cbbfa6\"/><circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((px_2653 - 0.08))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((py_2654 - 0.1))))), "\" r=\"0.19\" fill=\"#efe8da\"/>")).S((LtN(Call(R_2635, V.Undef), 0.15) ? string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)(px_2653)))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)(py_2654)))), "\" r=\"0.62\" fill=\"none\" stroke=\"#a99c82\" stroke-width=\"0.08\" opacity=\"0.7\"/>") : ""));
_cont2652: ;
y_2651 = (y_2651 + 6D);
}
}
x_2649 = (x_2649 + 8D);
}
}
s_2636.S("<path d=\"M10.6 17.4Q12.4 15.8 15.6 16.6Q17.6 17.8 16.8 20.4Q15.4 22.4 12.2 21.8Q10 20.6 10.6 17.4Z\" fill=\"#e8e1d2\" opacity=\"0.75\"/><path d=\"M11.6 18.2q1.6 -1 3.4 -0.2M11.4 19.8q2 -0.8 4.6 0.2M12.4 21q1.4 -0.4 3 0\" stroke=\"#d9d0bd\" stroke-width=\"0.14\" fill=\"none\"/><path d=\"M10.6 17.4Q12.4 15.8 15.6 16.6\" stroke=\"#ffffff\" stroke-width=\"0.16\" fill=\"none\" opacity=\"0.8\"/>");
s_2636.S("<path d=\"M70.4 0L71 2.2L70.6 3.6L71.8 5.4L71.4 7.2L72.6 9.4\" stroke=\"#8f826a\" stroke-width=\"0.16\" fill=\"none\" stroke-linejoin=\"bevel\"/><path d=\"M70.6 0.2L71.2 2.3L70.8 3.7L72 5.5\" stroke=\"#ffffff\" stroke-width=\"0.08\" fill=\"none\" opacity=\"0.5\"/>");
Invoke(Arr(Arr(((V)(24.6)), ((V)(12.2))), Arr(((V)(55.2)), ((V)(9.8))), Arr(((V)(57.1)), ((V)(10.1)))), "forEach", Fn((V _arrowThis2666, int _argc2655, V _a2657, V _a2658, V _a2659, V _a2660, V[] _rest2656) => {
V x_2663 = default;
V y_2665 = default;
{ V _t2661 = ListOf(_a2657);
{ V _t2662 = GetIdx(_t2661, 0D);
x_2663 = _t2662; }
{ V _t2664 = GetIdx(_t2661, 1D);
y_2665 = _t2664; }
}
return ((V)(s_2636.S(string.Concat("<circle cx=\"", ToStr(x_2663), "\" cy=\"", ToStr(y_2665), "\" r=\"0.2\" fill=\"#5a4c38\"/><circle cx=\"", ToStr(Add(x_2663, ((V)(0.07)))), "\" cy=\"", ToStr(Add(y_2665, ((V)(0.07)))), "\" r=\"0.27\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.06\" opacity=\"0.6\"/>")).Str));
}, 1, "", true));
sup_2637 = ((V)(string.Concat(s_2636.Str, "<rect width=\"80\" height=\"56\" fill=\"url(#kdy)\"/>")));
s_2636.S("<rect width=\"80\" height=\"56\" fill=\"url(#kdy)\"/>");
s_2636.V(Add(Call(lblot_2498, V.Undef, ((V)("kdg")), ((V)(22D)), Arr(((V)("#b89048")), ((V)("#a07a38")), ((V)("#c49d58"))), ((V)(0.16)), ((V)(5D)), ((V)(22D)), ((V)(42D))), Call(lblot_2498, V.Undef, ((V)("kdg2")), ((V)(10D)), Arr(((V)("#94702f")), ((V)("#7a5a26"))), ((V)(0.14)), ((V)(3.4)), ((V)(28D)), ((V)(40D)))));
SP_2638 = Arr(((V)("#9a7434")), ((V)("#a8823e")), ((V)("#7a5a26")), ((V)("#b89250")), ((V)("#6a4c20")));
s_2636.V(Invoke(Call(rep_18, V.Undef, ((V)(260D)), Fn((V _arrowThis2673, int _argc2667, V _a2669, V _a2670, V _a2671, V _a2672, V[] _rest2668) => {
double x_2674 = 0;
double y_2675 = 0;
double r_2676 = 0;
V op_2677 = default;
x_2674 = (ToNum(Call(R_2635, V.Undef)) * 80D);
y_2675 = (32D + ((ToNum(Add(Add(Call(R_2635, V.Undef), Call(R_2635, V.Undef)), Call(R_2635, V.Undef))) - 1.5) * 9D));
r_2676 = (0.06 + ((ToNum(Call(R_2635, V.Undef)) * ToNum(Call(R_2635, V.Undef))) * 0.5));
op_2677 = Call(f1_16, V.Undef, ((V)((0.25 + (ToNum(Call(R_2635, V.Undef)) * 0.45)))));
return Call(wrapX_2499, V.Undef, ((V)(x_2674)), ((V)(r_2676)), Fn((V _arrowThis2685, int _argc2678, V x_2684, V _a2681, V _a2682, V _a2683, V[] _rest2679) => {
return ((V)(string.Concat(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, x_2684)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)(y_2675)))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)(r_2676)))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((r_2676 * (0.8 + (ToNum(Call(R_2635, V.Undef)) * 0.4))))))), "\" fill=\"", ToStr(GetIdx(SP_2638, System.Math.Floor((ToNum(Call(R_2635, V.Undef)) * 5D)))), "\" opacity=\"", ToStr(op_2677), "\"/>"), ((r_2676 > 0.28) ? string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_2684) - (r_2676 * 0.3)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((y_2675 - (r_2676 * 0.35)))))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((r_2676 * 0.32))))), "\" fill=\"#fff6dc\" opacity=\"0.55\"/>") : ""))));
}, 1, "", true));
return default;
}, 0, "", true)), "join", ((V)(""))));
run_2639 = Fn((V _arrowThis2697, int _argc2686, V x_2692, V y0_2693, V l_2694, V w_2695, V[] _rest2687) => {
V c_2696 = default;
c_2696 = (_argc2686 > 4 ? _rest2687[0] : V.Undef);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_2692) - (ToNum(w_2695) / 2D)))))), " ", ToStr(y0_2693), "V", ToStr(Call(f1_16, V.Undef, Add(y0_2693, l_2694))), "a", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(w_2695) / 2D))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(w_2695) * 0.7))))), " 0 0 0 ", ToStr(Call(f1_16, V.Undef, w_2695)), " 0V", ToStr(y0_2693), "Z\" fill=\"", ToStr(c_2696), "\" opacity=\"0.5\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_2692) - (ToNum(w_2695) * 0.18)))))), " ", ToStr(Call(f1_16, V.Undef, Add(y0_2693, ((V)(0.3))))), "V", ToStr(Call(f1_16, V.Undef, Add(y0_2693, l_2694))), "\" stroke=\"#fff2cc\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(w_2695) * 0.18))))), "\" opacity=\"0.5\"/>")));
}, 5, "", true);
Invoke(Arr(Arr(((V)(6.4)), ((V)(31D)), ((V)(3.2)), ((V)(0.3))), Arr(((V)(19.2)), ((V)(29.6)), ((V)(5.2)), ((V)(0.4))), Arr(((V)(35.2)), ((V)(31.6)), ((V)(6.8)), ((V)(0.5))), Arr(((V)(38.6)), ((V)(30.4)), ((V)(2.6)), ((V)(0.28))), Arr(((V)(47D)), ((V)(28.6)), ((V)(9.6)), ((V)(0.5))), Arr(((V)(58.6)), ((V)(32.2)), ((V)(3.6)), ((V)(0.32))), Arr(((V)(71.8)), ((V)(30D)), ((V)(4.6)), ((V)(0.38)))), "forEach", Fn((V _arrowThis2714, int _argc2698, V _a2700, V i_2704, V _a2702, V _a2703, V[] _rest2699) => {
V x_2707 = default;
V y_2709 = default;
V l_2711 = default;
V w_2713 = default;
{ V _t2705 = ListOf(_a2700);
{ V _t2706 = GetIdx(_t2705, 0D);
x_2707 = _t2706; }
{ V _t2708 = GetIdx(_t2705, 1D);
y_2709 = _t2708; }
{ V _t2710 = GetIdx(_t2705, 2D);
l_2711 = _t2710; }
{ V _t2712 = GetIdx(_t2705, 3D);
w_2713 = _t2712; }
}
return ((V)(s_2636.V(Call(run_2639, V.Undef, x_2707, y_2709, l_2711, w_2713, GetIdx(SP_2638, (ToNum(i_2704) % 5D)))).Str));
}, 2, "", true));
s_2636.S(string.Concat("<g opacity=\"0\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0;0.8;0.8;0")), ((V)(11D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.15;0.85;1\"")))), "<ellipse cx=\"47\" cy=\"38.9\" rx=\"0.36\" ry=\"0.48\" fill=\"#8a6428\">", ToStr(Call(an_14, V.Undef, ((V)("cy")), ((V)("38.7;39.3;39.3;45")), ((V)(11D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.6;0.82;1\" calcMode=\"spline\" keySplines=\"0.4 0 0.6 1;0 0 1 1;0.6 0 1 1\"")))), ToStr(Call(an_14, V.Undef, ((V)("ry")), ((V)("0.3;0.62;0.62;0.42")), ((V)(11D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.6;0.82;1\"")))), "</ellipse></g>"));
s_2636.S("<g filter=\"url(#wb2)\"><ellipse cx=\"27\" cy=\"40.6\" rx=\"3.6\" ry=\"2.4\" fill=\"#2a2018\" opacity=\"0.32\"/><ellipse cx=\"26.4\" cy=\"38.6\" rx=\"2\" ry=\"3.4\" fill=\"#2a2018\" opacity=\"0.2\"/></g><path d=\"M25 41.4q1.6 -2.4 1.2 -5.2q1.4 2.6 1 5.4\" stroke=\"#3a2c1e\" stroke-width=\"0.14\" fill=\"none\" opacity=\"0.4\"/>");
s_2636.V(Call(outlet_2489, V.Undef, ((V)(61.6)), ((V)(44.4)), ((V)("#e8e0cc")), ((V)("#5a5244")))).S("<rect x=\"61.6\" y=\"44.4\" width=\"1.5\" height=\"2.3\" rx=\"0.22\" fill=\"#9a7434\" opacity=\"0.3\"/><path d=\"M62.2 44.5l0.5 0.8l-0.3 0.5\" stroke=\"#8a806c\" stroke-width=\"0.07\" fill=\"none\"/><circle cx=\"62.35\" cy=\"45.55\" r=\"0.08\" fill=\"#c8c0ac\"/>");
board_2640 = ((V)("#7e6e58"));
return NewObj(6).Put("mat", ((V)(s_2636.Str))).Put("sup", sup_2637).Put("smat", Add(sup_2637, Call(outlet_2489, V.Undef, ((V)(61.6)), ((V)(44.4)), ((V)("#e8e0cc")), ((V)("#5a5244"))))).Put("board", board_2640).Put("defs", ((V)("<linearGradient id=\"kdy\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#c49d52\" stop-opacity=\"0.26\"/><stop offset=\"0.5\" stop-color=\"#c49d52\" stop-opacity=\"0.06\"/><stop offset=\"1\" stop-color=\"#c49d52\" stop-opacity=\"0\"/></linearGradient>"))).Put("ro", NewObj(3).Put("top", ((V)(0.05))).Put("ao", ((V)(0.17))).Put("board", ((V)(JsStrBuf.Begin().S(string.Concat("<rect y=\"", ToStr(BB_2490), "\" width=\"80\" height=\"0.55\" fill=\"", ToStr(Call(shade_10, V.Undef, board_2640, ((V)(1.25)))), "\"/>")).S("<path d=\"M18.2 53.6Q20.6 52.8 23.4 53.6Z\" fill=\"#9c8a6e\"/><path d=\"M18.2 53.6Q20.6 52.9 23.4 53.6\" stroke=\"#5a4c38\" stroke-width=\"0.1\" fill=\"none\"/><rect x=\"18.4\" y=\"53.6\" width=\"4.8\" height=\"0.4\" fill=\"#2a2018\" opacity=\"0.35\" filter=\"url(#wb1)\"/>").V(Call(scf_2496, V.Undef, ((V)("kdb")), ((V)(22D)), ((V)("#4e4232")), ((V)("#a8977a")))).S(string.Concat("<rect y=\"", ToStr(Call(f1_16, V.Undef, Add(BB_2490, ((V)(0.9))))), "\" width=\"80\" height=\"0.3\" fill=\"#9a7434\" opacity=\"0.35\"/>")).End()))).V).V;
return default;
}, 0, "", true));
kVinyl_2501 = Call(memo_2494, V.Undef, ((V)("k21")), Fn((V _arrowThis2721, int _argc2715, V _a2717, V _a2718, V _a2719, V _a2720, V[] _rest2716) => {
V R_2722 = default;
V PT_2723 = default;
JsStrBuf up_2724 = null;
V s_2725 = default;
JsStrBuf b_2726 = null;
V OFF_2727 = default;
V board_2728 = default;
R_2722 = Call(rng_13, V.Undef, ((V)("kv21")));
PT_2723 = ((V)("#f1ede3"));
up_2724 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"80\" height=\"56\" fill=\"#d3e6d8\"/>").V(Call(blot_2488, V.Undef, ((V)("kv21")), ((V)(26D)), Arr(((V)("#dcecdf")), ((V)("#c8dccd")), ((V)("#d6e8da"))), ((V)(0.4)), ((V)(3D)))).End());
{
double i_2729 = 0;
i_2729 = 0D;
while (true) {
if (!((i_2729 < 40D))) break;
up_2724.S(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, Add(((V)((i_2729 * 2D))), Call(R_2722, V.Undef)))), "\" width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1D + (ToNum(Call(R_2722, V.Undef)) * 2D)))))), "\" height=\"56\" fill=\"", (LtN(Call(R_2722, V.Undef), 0.5) ? "#ffffff" : "#9ab8a2"), "\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.03 + (ToNum(Call(R_2722, V.Undef)) * 0.04)))))), "\"/>"));
i_2729++;
}
}
up_2724.V(Invoke(Call(rep_18, V.Undef, ((V)(70D)), Fn((V _arrowThis2737, int _argc2731, V _a2733, V _a2734, V _a2735, V _a2736, V[] _rest2732) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_2722, V.Undef)) * 80D))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_2722, V.Undef)) * 56D))))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.1 + (ToNum(Call(R_2722, V.Undef)) * 0.12)))))), "\" fill=\"#b6cfbd\" opacity=\"0.5\"/>")));
}, 0, "", true)), "join", ((V)(""))));
s_2725 = ((V)(up_2724.Str));
b_2726 = new JsStrBuf("");
OFF_2727 = Arr(((V)(0D)), ((V)(0.42)), ((V)((-0.26))), ((V)(0.18)));
Invoke(OFF_2727, "forEach", Fn((V _arrowThis2746, int _argc2738, V o_2744, V i_2745, V _a2742, V _a2743, V[] _rest2739) => {
return ((V)(b_2726.S(string.Concat("<g transform=\"translate(0 ", ToStr(o_2744), ")\"><rect x=\"", NumStr((ToNum(i_2745) * 20D)), "\" y=\"", NumStr((BT_2492 - 1D)), "\" width=\"20\" height=\"", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(BB_2490) - BT_2492) + 2D))))), "\" fill=\"url(#kvp)\"/></g>")).Str));
}, 2, "", true));
b_2726.S("<rect y=\"").N(BT_2492).S("\" width=\"80\" height=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(BB_2490) - BT_2492))))).S("\" fill=\"url(#kvs)\"/>");
Invoke(Arr(((V)(0D)), ((V)(20D)), ((V)(40D)), ((V)(60D)), ((V)(80D))), "forEach", Fn((V _arrowThis2755, int _argc2747, V x_2753, V i_2754, V _a2751, V _a2752, V[] _rest2748) => {
return ((V)(b_2726.S(string.Concat("<path d=\"M", ToStr(x_2753), " ", NumStr(BT_2492), "V", ToStr(BB_2490), "\" stroke=\"#8f8a7e\" stroke-width=\"0.16\" opacity=\"0.7\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, Add(x_2753, ((V)(0.14))))), " ", NumStr(BT_2492), "V", ToStr(BB_2490), "\" stroke=\"#ffffff\" stroke-width=\"0.12\" opacity=\"0.8\"/>")).S((SEqN(i_2754, 2D) ? string.Concat("<rect x=\"", NumStr((ToNum(x_2753) - 0.12)), "\" y=\"", NumStr(BT_2492), "\" width=\"0.24\" height=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(BB_2490) - BT_2492))))), "\" fill=\"#d3e6d8\"/>") : "")).Str));
}, 2, "", true));
Invoke(Arr(Arr(((V)(12.6)), ((V)(33.4)), ((V)(1.3))), Arr(((V)(50.2)), ((V)(41.8)), ((V)(0.9))), Arr(((V)(27.4)), ((V)(46.6)), ((V)(1.1))), Arr(((V)(69D)), ((V)(30.2)), ((V)(0.8)))), "forEach", Fn((V _arrowThis2769, int _argc2756, V _a2758, V _a2759, V _a2760, V _a2761, V[] _rest2757) => {
V x_2764 = default;
V y_2766 = default;
V r_2768 = default;
{ V _t2762 = ListOf(_a2758);
{ V _t2763 = GetIdx(_t2762, 0D);
x_2764 = _t2763; }
{ V _t2765 = GetIdx(_t2762, 1D);
y_2766 = _t2765; }
{ V _t2767 = GetIdx(_t2762, 2D);
r_2768 = _t2767; }
}
return ((V)(b_2726.S(string.Concat("<ellipse cx=\"", ToStr(x_2764), "\" cy=\"", ToStr(Call(f1_16, V.Undef, Add(y_2766, ((V)((ToNum(r_2768) * 0.25)))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_2768) * 1.1))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_2768) * 0.75))))), "\" fill=\"#000000\" opacity=\"0.08\" filter=\"url(#wb1)\"/><ellipse cx=\"", ToStr(x_2764), "\" cy=\"", ToStr(y_2766), "\" rx=\"", ToStr(r_2768), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_2768) * 0.7))))), "\" fill=\"url(#kvb)\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_2764) - (ToNum(r_2768) * 0.6)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(y_2766) - (ToNum(r_2768) * 0.2)))))), "q", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_2768) * 0.4))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(r_2768)) * 0.45))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_2768) * 0.9))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(r_2768)) * 0.35))))), "\" stroke=\"#ffffff\" stroke-width=\"0.16\" fill=\"none\" opacity=\"0.85\"/>")).Str));
}, 1, "", true));
b_2726.S("<path d=\"M58.6 43.6L61.9 43.4L62.1 47.3L58.5 47.5Z\" fill=\"#d3e6d8\"/><path d=\"M58.6 43.6L60.2 43.5L61.9 43.4L62 45.2L62.1 47.3L60.4 47.4L58.5 47.5L58.6 45.6Z\" fill=\"none\" stroke=\"#8f8a7e\" stroke-width=\"0.1\"/>").V(Call(outlet_2489, V.Undef, ((V)(59.5)), ((V)(44.2)), ((V)("#f4f1e8")), ((V)("#5a5850"))));
b_2726.S("<ellipse cx=\"33\" cy=\"38\" rx=\"0.9\" ry=\"1.2\" fill=\"#c8b48a\" opacity=\"0.18\"/>");
b_2726.S("<path d=\"M40.12 24L45.4 24L40.12 30.2Z\" fill=\"#e8deb4\"/><path d=\"M40.6 24.6l3 0.3M40.6 25.8l2.2 0.6M40.5 27.2l1.4 0.4\" stroke=\"#cdbf8a\" stroke-width=\"0.1\" opacity=\"0.8\"/>").S(string.Concat("<g>", ToStr(Call(at_47, V.Undef, ((V)("rotate")), ((V)("0 40.2 24.4;-4 40.2 24.4;1 40.2 24.4;0 40.2 24.4")), ((V)(6.5)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(3D))))), "<path d=\"M45.4 24Q43.4 27.6 40.12 30.2Q42.6 30.4 44.6 29.2Q46.6 27 45.4 24Z\" fill=\"#000000\" opacity=\"0.18\" filter=\"url(#wb1)\"/><path d=\"M45.4 24Q43.4 27.6 40.12 30.2Q42 29.6 43.6 28.4Q45.6 26.6 45.4 24Z\" fill=\"#faf8f2\"/><path d=\"M45.4 24Q43.4 27.6 40.12 30.2\" stroke=\"#b8b2a4\" stroke-width=\"0.12\" fill=\"none\"/><path d=\"M44.6 25.6Q43.4 27.6 41.6 29.2\" stroke=\"#e0dbd0\" stroke-width=\"0.25\" fill=\"none\"/></g>"));
s_2725 = ((V)(JsStrBuf.Begin().V(s_2725).S(string.Concat("<g clip-path=\"url(#kvc)\">", b_2726.Str, "</g>")).End()));
s_2725 = ((V)(JsStrBuf.Begin().V(s_2725).S(string.Concat("<rect y=\"", NumStr(BT_2492), "\" width=\"80\" height=\"0.9\" fill=\"#000000\" opacity=\"0.12\" filter=\"url(#wb1)\"/><rect y=\"", NumStr((BT_2492 - 0.8)), "\" width=\"80\" height=\"0.9\" fill=\"#f6f4ee\"/><rect y=\"", NumStr((BT_2492 - 0.8)), "\" width=\"80\" height=\"0.25\" fill=\"#ffffff\"/><rect y=\"", ToStr(Call(f1_16, V.Undef, ((V)((BT_2492 - 0.05))))), "\" width=\"80\" height=\"0.15\" fill=\"#b9b4a8\"/>")).End()));
board_2728 = ((V)("#b5262c"));
return NewObj(6).Put("mat", s_2725).Put("sup", ((V)(up_2724.Str))).Put("smat", ((V)(up_2724.Str))).Put("board", board_2728).Put("defs", ((V)(JsStrBuf.Begin().V(Call(bandC_2497, V.Undef, ((V)("kvc")))).S("<pattern id=\"kvp\" width=\"4\" height=\"4\" patternUnits=\"userSpaceOnUse\"><rect width=\"4\" height=\"4\" fill=\"#bdb8ac\"/>").V(Invoke(Invoke(Arr(Arr(((V)(0.11)), ((V)(0.11)), ((V)(3.78))), Arr(((V)((-1.89))), ((V)(2.11)), ((V)(3.78))), Arr(((V)(2.11)), ((V)(2.11)), ((V)(3.78)))), "map", Fn((V _arrowThis2783, int _argc2770, V _a2772, V _a2773, V _a2774, V _a2775, V[] _rest2771) => {
V x_2778 = default;
V y_2780 = default;
V w_2782 = default;
{ V _t2776 = ListOf(_a2772);
{ V _t2777 = GetIdx(_t2776, 0D);
x_2778 = _t2777; }
{ V _t2779 = GetIdx(_t2776, 1D);
y_2780 = _t2779; }
{ V _t2781 = GetIdx(_t2776, 2D);
w_2782 = _t2781; }
}
return ((V)(string.Concat("<rect x=\"", ToStr(x_2778), "\" y=\"", ToStr(y_2780), "\" width=\"", ToStr(w_2782), "\" height=\"1.78\" fill=\"", ToStr(PT_2723), "\"/><rect x=\"", ToStr(x_2778), "\" y=\"", ToStr(y_2780), "\" width=\"", ToStr(w_2782), "\" height=\"0.18\" fill=\"#ffffff\" opacity=\"0.8\"/><rect x=\"", ToStr(x_2778), "\" y=\"", ToStr(Call(f1_16, V.Undef, Add(y_2780, ((V)(1.56))))), "\" width=\"", ToStr(w_2782), "\" height=\"0.22\" fill=\"#cfcabd\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, Add(x_2778, ((V)(0.6))))), " ", ToStr(Call(f1_16, V.Undef, Add(y_2780, ((V)(1.2))))), "l0.9 -0.8M", ToStr(Call(f1_16, V.Undef, Add(x_2778, ((V)(1.1))))), " ", ToStr(Call(f1_16, V.Undef, Add(y_2780, ((V)(1.3))))), "l0.5 -0.45\" stroke=\"#ffffff\" stroke-width=\"0.16\" opacity=\"0.9\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("</pattern>").S("<linearGradient id=\"kvs\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0.4\"><stop offset=\"0.15\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.3\" stop-color=\"#ffffff\" stop-opacity=\"0.16\"/><stop offset=\"0.45\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.7\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.8\" stop-color=\"#ffffff\" stop-opacity=\"0.1\"/><stop offset=\"0.9\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>").S("<radialGradient id=\"kvb\" cx=\"40%\" cy=\"35%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.7\"/><stop offset=\"0.6\" stop-color=\"#f1ede3\" stop-opacity=\"0.2\"/><stop offset=\"1\" stop-color=\"#8f8a7e\" stop-opacity=\"0.35\"/></radialGradient>").End()))).Put("ro", NewObj(3).Put("top", ((V)(0.06))).Put("ao", ((V)(0.12))).Put("board", ((V)(JsStrBuf.Begin().S(string.Concat("<rect y=\"", ToStr(BB_2490), "\" width=\"80\" height=\"0.5\" fill=\"#e0545a\"/><rect y=\"", ToStr(Call(f1_16, V.Undef, Add(BB_2490, ((V)(0.7))))), "\" width=\"80\" height=\"0.2\" fill=\"#ffffff\" opacity=\"0.35\"/>")).V(Call(scf_2496, V.Undef, ((V)("kvb")), ((V)(12D)), ((V)("#5a1014")), ((V)("#e87a7e")))).End()))).V).V;
return default;
}, 0, "", true));
kHerr_2502 = Call(memo_2494, V.Undef, ((V)("k41")), Fn((V _arrowThis2790, int _argc2784, V _a2786, V _a2787, V _a2788, V _a2789, V[] _rest2785) => {
V R_2791 = default;
double sc_2792 = 0;
double g_2793 = 0;
V WH_2794 = default;
V up_2795 = default;
V s_2796 = default;
JsStrBuf b_2797 = null;
V rp_2798 = default;
V brick_2799 = default;
V board_2800 = default;
R_2791 = Call(rng_13, V.Undef, ((V)("kh41")));
sc_2792 = (80D / ((18D * 2D) * SR_2493));
g_2793 = 0.11;
WH_2794 = Arr(((V)("#fbfcfa")), ((V)("#f5f7f4")), ((V)("#eff2ef")), ((V)("#f8f9f6")), ((V)("#f2f4f1")));
up_2795 = ((V)(JsStrBuf.Begin().S("<rect width=\"80\" height=\"56\" fill=\"#a9b698\"/>").V(Call(blot_2488, V.Undef, ((V)("kh41")), ((V)(30D)), Arr(((V)("#b3bfa3")), ((V)("#9fad8f")), ((V)("#aab798"))), ((V)(0.4)), ((V)(3.4)))).V(Invoke(Call(rep_18, V.Undef, ((V)(60D)), Fn((V _arrowThis2807, int _argc2801, V _a2803, V _a2804, V _a2805, V _a2806, V[] _rest2802) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_2791, V.Undef)) * 80D))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_2791, V.Undef)) * 56D))))), "\" r=\"0.12\" fill=\"#c4cfb6\" opacity=\"0.5\"/>")));
}, 0, "", true)), "join", ((V)("")))).End()));
s_2796 = up_2795;
b_2797 = new JsStrBuf(JsStrBuf.Begin().S("<rect y=\"").N(BT_2492).S("\" width=\"80\" height=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(BB_2490) - BT_2492))))).S("\" fill=\"#c9cdc6\"/>").End());
rp_2798 = Fn((V _arrowThis2818, int _argc2808, V x0_2814, V y0_2815, V x1_2816, V y1_2817, V[] _rest2809) => {
return Invoke(Arr(Arr(Add(x0_2814, ((V)(g_2793))), Add(y0_2815, ((V)(g_2793)))), Arr(((V)((ToNum(x1_2816) - g_2793))), Add(y0_2815, ((V)(g_2793)))), Arr(((V)((ToNum(x1_2816) - g_2793))), ((V)((ToNum(y1_2817) - g_2793)))), Arr(Add(x0_2814, ((V)(g_2793))), ((V)((ToNum(y1_2817) - g_2793))))), "map", Fn((V _arrowThis2830, int _argc2819, V _a2821, V _a2822, V _a2823, V _a2824, V[] _rest2820) => {
V x_2827 = default;
V y_2829 = default;
{ V _t2825 = ListOf(_a2821);
{ V _t2826 = GetIdx(_t2825, 0D);
x_2827 = _t2826; }
{ V _t2828 = GetIdx(_t2825, 1D);
y_2829 = _t2828; }
}
return Arr(((V)((((ToNum(x_2827) - ToNum(y_2829)) / SR_2493) * sc_2792))), ((V)(((((ToNum(Add(x_2827, y_2829)) / SR_2493) * sc_2792) + BT_2492) - 4D))));
}, 1, "", true));
}, 4, "", true);
brick_2799 = Fn((V _arrowThis2838, int _argc2831, V Q_2837, V _a2834, V _a2835, V _a2836, V[] _rest2832) => {
V xs_2839 = default;
V ys_2840 = default;
V d_2841 = default;
V c_2842 = default;
xs_2839 = Invoke(Q_2837, "map", Fn((V _arrowThis2850, int _argc2843, V p_2849, V _a2846, V _a2847, V _a2848, V[] _rest2844) => {
return GetIdx(p_2849, 0D);
}, 1, "", true));
ys_2840 = Invoke(Q_2837, "map", Fn((V _arrowThis2858, int _argc2851, V p_2857, V _a2854, V _a2855, V _a2856, V[] _rest2852) => {
return GetIdx(p_2857, 1D);
}, 1, "", true));
if ((((LtN(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(xs_2839).V), (-0.5)) || GtN(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(xs_2839).V), 80.5)) || LtN(InvokeSpread(G("Math"), "max", new ArrBuilder().Spread(ys_2840).V), (BT_2492 - 0.5))) || Gt(InvokeSpread(G("Math"), "min", new ArrBuilder().Spread(ys_2840).V), Add(BB_2490, ((V)(0.5)))))) {
return ((V)(""));
}
d_2841 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Q_2837, "map", pt_30), "join", ((V)("L")))).S("Z").End()));
c_2842 = GetIdx(WH_2794, System.Math.Floor((ToNum(Call(R_2791, V.Undef)) * 5D)));
return ((V)(string.Concat("<path d=\"", ToStr(d_2841), "\" fill=\"", ToStr(c_2842), "\"/><path d=\"", ToStr(d_2841), "\" fill=\"url(#khg)\"/><path d=\"M", ToStr(Call(pt_30, V.Undef, GetIdx(Q_2837, 3D))), "L", ToStr(Call(pt_30, V.Undef, GetIdx(Q_2837, 0D))), "L", ToStr(Call(pt_30, V.Undef, GetIdx(Q_2837, 1D))), "\" stroke=\"#ffffff\" stroke-width=\"0.14\" fill=\"none\"/><path d=\"M", ToStr(Call(pt_30, V.Undef, GetIdx(Q_2837, 1D))), "L", ToStr(Call(pt_30, V.Undef, GetIdx(Q_2837, 2D))), "L", ToStr(Call(pt_30, V.Undef, GetIdx(Q_2837, 3D))), "\" stroke=\"#c2c7c0\" stroke-width=\"0.12\" fill=\"none\"/>")));
return default;
}, 1, "", true);
{
double k_2859 = 0;
k_2859 = (-3D);
while (true) {
if (!((k_2859 < 21D))) break;
{
double n_2861 = 0;
n_2861 = (-6D);
while (true) {
if (!((n_2861 < 26D))) break;
double ox_2863 = 0;
double oy_2864 = 0;
ox_2863 = (n_2861 + (2D * k_2859));
oy_2864 = (n_2861 - (2D * k_2859));
b_2797.V(Add(Call(brick_2799, V.Undef, Call(rp_2798, V.Undef, ((V)(ox_2863)), ((V)(oy_2864)), ((V)((ox_2863 + 2D))), ((V)((oy_2864 + 1D))))), Call(brick_2799, V.Undef, Call(rp_2798, V.Undef, ((V)((ox_2863 + 2D))), ((V)((oy_2864 - 1D))), ((V)((ox_2863 + 3D))), ((V)((oy_2864 + 1D)))))));
n_2861++;
}
}
k_2859++;
}
}
b_2797.S("<g filter=\"url(#wb2)\"><path d=\"M12 26L20 26L14 52L6 52Z\" fill=\"#ffffff\" opacity=\"0.2\"/><path d=\"M52 26L57 26L51 52L46 52Z\" fill=\"#ffffff\" opacity=\"0.14\"/></g>");
b_2797.S(string.Concat("<rect x=\"-30\" y=\"", NumStr(BT_2492), "\" width=\"14\" height=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(BB_2490) - BT_2492))))), "\" fill=\"url(#khs)\" transform=\"skewX(-18)\">", ToStr(Call(an_14, V.Undef, ((V)("x")), ((V)("-30;110;110")), ((V)(15D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.45;1\"")))), "</rect>"));
b_2797.V(Call(outlet_2489, V.Undef, ((V)(65.4)), ((V)(44.2)), ((V)("#fbfbf8")), ((V)("#7a7e78"))));
s_2796 = ((V)(JsStrBuf.Begin().V(s_2796).S(string.Concat("<g clip-path=\"url(#khc)\">", b_2797.Str, "</g>")).End()));
s_2796 = ((V)(JsStrBuf.Begin().V(s_2796).S(string.Concat("<rect y=\"", ToStr(Call(f1_16, V.Undef, ((V)((BT_2492 + 0.4))))), "\" width=\"80\" height=\"0.8\" fill=\"#000000\" opacity=\"0.14\" filter=\"url(#wb1)\"/><rect y=\"", ToStr(Call(f1_16, V.Undef, ((V)((BT_2492 - 1D))))), "\" width=\"80\" height=\"1.3\" rx=\"0.6\" fill=\"url(#khb)\"/><rect y=\"", ToStr(Call(f1_16, V.Undef, ((V)((BT_2492 - 0.85))))), "\" width=\"80\" height=\"0.22\" fill=\"#ffffff\" opacity=\"0.9\"/>")).End()));
board_2800 = ((V)("#efeee8"));
return NewObj(6).Put("mat", s_2796).Put("sup", up_2795).Put("smat", up_2795).Put("board", board_2800).Put("defs", ((V)(JsStrBuf.Begin().V(Call(bandC_2497, V.Undef, ((V)("khc")))).S("<linearGradient id=\"khg\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.75\"/><stop offset=\"0.35\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.8\" stop-color=\"#9aa39c\" stop-opacity=\"0.08\"/><stop offset=\"1\" stop-color=\"#7d867f\" stop-opacity=\"0.2\"/></linearGradient>").S("<linearGradient id=\"khb\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.5\" stop-color=\"#f1f3ef\"/><stop offset=\"1\" stop-color=\"#c8cdc6\"/></linearGradient>").S("<linearGradient id=\"khs\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.3\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>").End()))).Put("ro", NewObj(3).Put("top", ((V)(0.07))).Put("ao", ((V)(0.12))).Put("board", Add(Call(capB_2495, V.Undef, board_2800, ((V)(1.1))), Call(scf_2496, V.Undef, ((V)("khb")), ((V)(6D)), ((V)("#c9c8c0")), ((V)("#ffffff"))))).V).V;
return default;
}, 0, "", true));
kCop_2503 = Call(memo_2494, V.Undef, ((V)("k61")), Fn((V _arrowThis2871, int _argc2865, V _a2867, V _a2868, V _a2869, V _a2870, V[] _rest2866) => {
V R_2872 = default;
JsStrBuf up_2873 = null;
V s_2874 = default;
JsStrBuf b_2875 = null;
JsStrBuf dk_2876 = null;
JsStrBuf lt_2877 = null;
V board_2878 = default;
R_2872 = Call(rng_13, V.Undef, ((V)("kc61")));
up_2873 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"80\" height=\"56\" fill=\"#e7dac2\"/>").V(Call(blot_2488, V.Undef, ((V)("kc61")), ((V)(30D)), Arr(((V)("#efe4d0")), ((V)("#dccdb2")), ((V)("#e9dcc4")), ((V)("#d6c5a6"))), ((V)(0.45)), ((V)(3.6)))).S("<g filter=\"url(#wb1)\">").End());
up_2873.V(Invoke(Call(rep_18, V.Undef, ((V)(90D)), Fn((V _arrowThis2885, int _argc2879, V _a2881, V _a2882, V _a2883, V _a2884, V[] _rest2880) => {
double x_2886 = 0;
double y_2887 = 0;
double l_2888 = 0;
double h_2889 = 0;
double w_2890 = 0;
V lt_2891 = default;
x_2886 = ((ToNum(Call(R_2872, V.Undef)) * 84D) - 2D);
y_2887 = ((ToNum(Call(R_2872, V.Undef)) * 58D) - 1D);
l_2888 = (3D + (ToNum(Call(R_2872, V.Undef)) * 7D));
h_2889 = ((ToNum(Call(R_2872, V.Undef)) - 0.5) * 3D);
w_2890 = (0.6 + (ToNum(Call(R_2872, V.Undef)) * 1.8));
lt_2891 = (LtN(Call(R_2872, V.Undef), 0.55) ? V.True : V.False);
return Call(wrapX_2499, V.Undef, ((V)(x_2886)), ((V)(l_2888)), Fn((V _arrowThis2899, int _argc2892, V xx_2898, V _a2895, V _a2896, V _a2897, V[] _rest2893) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, xx_2898)), " ", ToStr(Call(f1_16, V.Undef, ((V)(y_2887)))), "q", ToStr(Call(f1_16, V.Undef, ((V)((l_2888 / 2D))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(h_2889)))), " ", ToStr(Call(f1_16, V.Undef, ((V)(l_2888)))), " ", ToStr(Call(f1_16, V.Undef, ((V)((h_2889 * 0.3))))), "\" stroke=\"", (Truthy(lt_2891) ? "#f8f1e4" : "#cdbb9a"), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)(w_2890)))), "\" stroke-linecap=\"round\" fill=\"none\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((Truthy(lt_2891) ? 0.35 : 0.22))))), "\"/>")));
}, 1, "", true));
return default;
}, 0, "", true)), "join", ((V)("")))).S("</g>");
up_2873.V(Invoke(Call(rep_18, V.Undef, ((V)(40D)), Fn((V _arrowThis2906, int _argc2900, V _a2902, V _a2903, V _a2904, V _a2905, V[] _rest2901) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_2872, V.Undef)) * 80D))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_2872, V.Undef)) * 56D))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 + (ToNum(Call(R_2872, V.Undef)) * 0.9)))))), "\" ry=\"0.18\" fill=\"#ffffff\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.2 + (ToNum(Call(R_2872, V.Undef)) * 0.3)))))), "\"/>")));
}, 0, "", true)), "join", ((V)(""))));
s_2874 = ((V)(up_2873.Str));
b_2875 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<rect y=\"", NumStr(BT_2492), "\" width=\"80\" height=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(BB_2490) - BT_2492))))), "\" fill=\"url(#kcb)\"/>")).V(Call(lblot_2498, V.Undef, ((V)("kc61b")), ((V)(26D)), Arr(((V)("#d8996c")), ((V)("#93502e")), ((V)("#e8b07e")), ((V)("#7a3e24")), ((V)("#c07850")), ((V)("#b88a5a"))), ((V)(0.4)), ((V)(3.4)), ((V)(BT_2492)), BB_2490)).End());
dk_2876 = new JsStrBuf("");
lt_2877 = new JsStrBuf("");
{
double y_2907 = 0;
double j_2908 = 0;
y_2907 = (BT_2492 - 0.4);
j_2908 = 0D;
while (true) {
if (!(Lt(((V)(y_2907)), Add(BB_2490, ((V)(1.2)))))) break;
{
double x_2910 = 0;
x_2910 = ((j_2908 % 2D) * 0.82);
while (true) {
if (!((x_2910 < 80D))) break;
double px_2912 = 0;
double py_2913 = 0;
double r_2914 = 0;
V o1_2915 = default;
V o2_2916 = default;
px_2912 = (x_2910 + ((ToNum(Call(R_2872, V.Undef)) - 0.5) * 0.6));
py_2913 = (y_2907 + ((ToNum(Call(R_2872, V.Undef)) - 0.5) * 0.5));
r_2914 = (0.85 + (ToNum(Call(R_2872, V.Undef)) * 0.35));
o1_2915 = Call(f1_16, V.Undef, ((V)((0.25 + (ToNum(Call(R_2872, V.Undef)) * 0.25)))));
o2_2916 = Call(f1_16, V.Undef, ((V)((0.25 + (ToNum(Call(R_2872, V.Undef)) * 0.3)))));
dk_2876.V(Call(wrapX_2499, V.Undef, ((V)(px_2912)), ((V)(r_2914)), Fn((V _arrowThis2924, int _argc2917, V xx_2923, V _a2920, V _a2921, V _a2922, V[] _rest2918) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(xx_2923) - (r_2914 * 0.28)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((py_2913 - (r_2914 * 0.3)))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((r_2914 * 0.62))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((r_2914 * 0.5))))), "\" opacity=\"", ToStr(o1_2915), "\"/>")));
}, 1, "", true)));
lt_2877.V(Call(wrapX_2499, V.Undef, ((V)(px_2912)), ((V)(r_2914)), Fn((V _arrowThis2932, int _argc2925, V xx_2931, V _a2928, V _a2929, V _a2930, V[] _rest2926) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, Add(xx_2931, ((V)((r_2914 * 0.3)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((py_2913 + (r_2914 * 0.32)))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((r_2914 * 0.55))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((r_2914 * 0.42))))), "\" opacity=\"", ToStr(o2_2916), "\"/>")));
}, 1, "", true)));
x_2910 = (x_2910 + 1.64);
}
}
y_2907 = (y_2907 + 1.42);
j_2908++;
}
}
b_2875.S(string.Concat("<g filter=\"url(#kcf)\"><g fill=\"#5a2a12\">", dk_2876.Str, "</g><g fill=\"#ffd2a2\">", lt_2877.Str, "</g></g>"));
Invoke(Arr(((V)(0D)), ((V)(20D)), ((V)(40D)), ((V)(60D)), ((V)(80D))), "forEach", Fn((V _arrowThis2940, int _argc2933, V x_2939, V _a2936, V _a2937, V _a2938, V[] _rest2934) => {
b_2875.S(string.Concat("<rect x=\"", NumStr((ToNum(x_2939) - 0.45)), "\" y=\"", NumStr(BT_2492), "\" width=\"0.9\" height=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(BB_2490) - BT_2492))))), "\" fill=\"url(#kcs)\"/><rect x=\"", ToStr(Call(f1_16, V.Undef, Add(x_2939, ((V)(0.45))))), "\" y=\"", NumStr(BT_2492), "\" width=\"0.5\" height=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(BB_2490) - BT_2492))))), "\" fill=\"#5a2c14\" opacity=\"0.25\" filter=\"url(#wb1)\"/>"));
{
double y_2941 = 0;
y_2941 = (BT_2492 + 1.6);
while (true) {
if (!(Lt(((V)(y_2941)), BB_2490))) break;
b_2875.S(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, Add(x_2939, ((V)(0.15))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((y_2941 + 0.15))))), "\" r=\"0.42\" fill=\"#4a2410\" opacity=\"0.35\"/><circle cx=\"", ToStr(x_2939), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)(y_2941)))), "\" r=\"0.36\" fill=\"url(#kcr)\"/>"));
y_2941 = (y_2941 + 3.2);
}
}
return default;
}, 1, "", true));
b_2875.V(Call(outlet_2489, V.Undef, ((V)(67.4)), ((V)(44.2)), ((V)("#c27a48")), ((V)("#3a1c0c")))).S("<rect x=\"67.4\" y=\"44.2\" width=\"1.5\" height=\"2.3\" rx=\"0.22\" fill=\"url(#kcg2)\"/>");
s_2874 = ((V)(JsStrBuf.Begin().V(s_2874).S(string.Concat("<g clip-path=\"url(#kcc)\">", b_2875.Str, "</g>")).End()));
s_2874 = ((V)(JsStrBuf.Begin().V(s_2874).S(string.Concat("<rect y=\"", ToStr(Call(f1_16, V.Undef, ((V)((BT_2492 + 0.5))))), "\" width=\"80\" height=\"1\" fill=\"#3a1a08\" opacity=\"0.3\" filter=\"url(#wb1)\"/><rect y=\"", ToStr(Call(f1_16, V.Undef, ((V)((BT_2492 - 1.1))))), "\" width=\"80\" height=\"1.6\" rx=\"0.8\" fill=\"url(#kch)\"/><rect y=\"", ToStr(Call(f1_16, V.Undef, ((V)((BT_2492 - 0.85))))), "\" width=\"80\" height=\"0.2\" fill=\"#ffe6c4\" opacity=\"0.9\"/>")).End()));
board_2878 = ((V)("#4e3b2a"));
return NewObj(6).Put("mat", s_2874).Put("sup", ((V)(up_2873.Str))).Put("smat", ((V)(up_2873.Str))).Put("board", board_2878).Put("defs", ((V)(JsStrBuf.Begin().V(Call(bandC_2497, V.Undef, ((V)("kcc")))).S("<filter id=\"kcf\" x=\"-5%\" y=\"-5%\" width=\"110%\" height=\"110%\"><feGaussianBlur stdDeviation=\"0.2\"/></filter><linearGradient id=\"kcb\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#c07a50\"/><stop offset=\"0.5\" stop-color=\"#a9623c\"/><stop offset=\"1\" stop-color=\"#8a4c2c\"/></linearGradient>").S("<radialGradient id=\"kcd\" cx=\"50%\" cy=\"50%\" r=\"50%\" fx=\"62%\" fy=\"64%\"><stop offset=\"0\" stop-color=\"#c47646\" stop-opacity=\"0\"/><stop offset=\"0.45\" stop-color=\"#e8a878\" stop-opacity=\"0.35\"/><stop offset=\"0.78\" stop-color=\"#ffd2a4\" stop-opacity=\"0.75\"/><stop offset=\"0.86\" stop-color=\"#8a4626\" stop-opacity=\"0.65\"/><stop offset=\"1\" stop-color=\"#5e2e14\" stop-opacity=\"0\"/></radialGradient>").S("<radialGradient id=\"kcr\" cx=\"35%\" cy=\"32%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#ffe2bc\"/><stop offset=\"0.5\" stop-color=\"#c87a48\"/><stop offset=\"1\" stop-color=\"#6e3a1e\"/></radialGradient>").S("<linearGradient id=\"kcs\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8a4a28\"/><stop offset=\"0.4\" stop-color=\"#f2b482\"/><stop offset=\"0.7\" stop-color=\"#c47646\"/><stop offset=\"1\" stop-color=\"#7a3e20\"/></linearGradient>").S("<linearGradient id=\"kch\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffd8a8\"/><stop offset=\"0.35\" stop-color=\"#e09460\"/><stop offset=\"0.7\" stop-color=\"#a85c32\"/><stop offset=\"1\" stop-color=\"#6e3a1e\"/></linearGradient>").S("<linearGradient id=\"kcg\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffe0b0\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffe0b0\" stop-opacity=\"0.32\"/><stop offset=\"1\" stop-color=\"#ffe0b0\" stop-opacity=\"0\"/></linearGradient>").S("<linearGradient id=\"kcg2\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffd8a8\" stop-opacity=\"0.6\"/><stop offset=\"1\" stop-color=\"#6e3a1e\" stop-opacity=\"0.3\"/></linearGradient>").End()))).Put("ro", NewObj(3).Put("top", ((V)(0.06))).Put("ao", ((V)(0.14))).Put("board", Add(Add(Call(capB_2495, V.Undef, board_2878, ((V)(1.3))), Invoke(Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis2950, int _argc2943, V i_2949, V _a2946, V _a2947, V _a2948, V[] _rest2944) => {
return ((V)(string.Concat("<path d=\"M0 ", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(BB_2490) - 1.1) + (ToNum(i_2949) * 0.22)))))), "H80\" stroke=\"#2e2216\" stroke-width=\"0.06\" opacity=\"0.4\"/>")));
}, 1, "", true)), "join", ((V)("")))), Call(scf_2496, V.Undef, ((V)("kcb2")), ((V)(8D)), ((V)("#2e2216")), ((V)("#7a624a"))))).V).V;
return default;
}, 0, "", true));
kQtz_2504 = Call(memo_2494, V.Undef, ((V)("k81")), Fn((V _arrowThis2957, int _argc2951, V _a2953, V _a2954, V _a2955, V _a2956, V[] _rest2952) => {
V R_2958 = default;
JsStrBuf h_2959 = null;
V CL_2960 = default;
V PAL_2961 = default;
V vein_2962 = default;
V sv_2963 = default;
V half_2964 = default;
V stone_2965 = default;
double DX_2966 = 0;
double DY_2967 = 0;
double DW_2968 = 0;
double DH_2969 = 0;
V RCP_2970 = default;
V ic_2971 = default;
JsStrBuf pg_2972 = null;
V disp_2973 = default;
V board_2974 = default;
R_2958 = Call(rng_13, V.Undef, ((V)("kq81")));
h_2959 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"40\" height=\"56\" fill=\"#efe8db\"/>").S(string.Concat("<g clip-path=\"url(#kqh)\">", "")).V(Call(lblot_2498, V.Undef, ((V)("kq81")), ((V)(18D)), Arr(((V)("#f8f4ec")), ((V)("#e6dcc8")), ((V)("#f2ead8"))), ((V)(0.6)), ((V)(4D)), ((V)((-2D))), ((V)(58D)))).End());
CL_2960 = Arr(Arr(((V)(9D)), ((V)(8D)), ((V)(6D)), ((V)("a"))), Arr(((V)(27D)), ((V)(15D)), ((V)(5D)), ((V)("d"))), Arr(((V)(6D)), ((V)(29D)), ((V)(7D)), ((V)("d"))), Arr(((V)(22D)), ((V)(34D)), ((V)(4D)), ((V)("g"))), Arr(((V)(33D)), ((V)(42D)), ((V)(6D)), ((V)("a"))), Arr(((V)(12D)), ((V)(47D)), ((V)(5D)), ((V)("g"))), Arr(((V)(31D)), ((V)(4D)), ((V)(4D)), ((V)("g"))), Arr(((V)(17D)), ((V)(21D)), ((V)(3.4)), ((V)("a"))), Arr(((V)(37D)), ((V)(26D)), ((V)(3D)), ((V)("d"))), Arr(((V)(3D)), ((V)(52D)), ((V)(3.4)), ((V)("a"))));
PAL_2961 = NewObj(3).Put("a", Arr(((V)("#c48a4c")), ((V)("#d9a868")), ((V)("#a86a36")), ((V)("#e8c58e")), ((V)("#b47a40")))).Put("d", Arr(((V)("#2b2724")), ((V)("#4f4740")), ((V)("#6d655c")), ((V)("#857b70")), ((V)("#3a332e")))).Put("g", Arr(((V)("#8f877c")), ((V)("#b3aca0")), ((V)("#6e6760")), ((V)("#cfc8bc")))).V;
h_2959.S("<g filter=\"url(#wb2)\">").V(Invoke(Invoke(CL_2960, "map", Fn((V _arrowThis2990, int _argc2975, V _a2977, V _a2978, V _a2979, V _a2980, V[] _rest2976) => {
V x_2983 = default;
V y_2985 = default;
V r_2987 = default;
V t_2989 = default;
{ V _t2981 = ListOf(_a2977);
{ V _t2982 = GetIdx(_t2981, 0D);
x_2983 = _t2982; }
{ V _t2984 = GetIdx(_t2981, 1D);
y_2985 = _t2984; }
{ V _t2986 = GetIdx(_t2981, 2D);
r_2987 = _t2986; }
{ V _t2988 = GetIdx(_t2981, 3D);
t_2989 = _t2988; }
}
return ((V)(string.Concat("<ellipse cx=\"", ToStr(x_2983), "\" cy=\"", ToStr(y_2985), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_2987) * 1.5))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_2987) * 1.1))))), "\" fill=\"", (SEqS(t_2989, "a") ? "#e0b070" : (SEqS(t_2989, "d") ? "#a89e94" : "#cdc5b8")), "\" opacity=\"", NumStr((SEqS(t_2989, "a") ? 0.4 : 0.26)), "\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
vein_2962 = Fn((V _arrowThis3001, int _argc2991, V P_2997, V c_2998, V w_2999, V op_3000, V[] _rest2992) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(P_2997, "map", Fn((V _arrowThis3009, int _argc3002, V p_3008, V _a3005, V _a3006, V _a3007, V[] _rest3003) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, GetIdx(p_3008, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(p_3008, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))), "\" stroke=\"", ToStr(c_2998), "\" stroke-width=\"", ToStr(w_2999), "\" fill=\"none\" stroke-linejoin=\"round\" opacity=\"", ToStr(op_3000), "\"/>")));
}, 4, "", true);
sv_2963 = Fn((V _arrowThis3020, int _argc3010, V P_3016, V c_3017, V w_3018, V op_3019, V[] _rest3011) => {
JsStrBuf d_3021 = null;
d_3021 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(pt_30, V.Undef, GetIdx(P_3016, 0D))).End());
{
double j_3022 = 0;
j_3022 = 1D;
while (true) {
if (!((j_3022 < (ToNum(Get(P_3016, "length")) - 1D)))) break;
d_3021.S("Q").V(Call(pt_30, V.Undef, GetIdx(P_3016, j_3022))).S(" ").V(Call(pt_30, V.Undef, Arr(((V)((ToNum(Add(GetIdx(GetIdx(P_3016, j_3022), 0D), GetIdx(GetIdx(P_3016, (j_3022 + 1D)), 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(GetIdx(P_3016, j_3022), 1D), GetIdx(GetIdx(P_3016, (j_3022 + 1D)), 1D))) / 2D))))));
j_3022++;
}
}
return ((V)(string.Concat("<path d=\"", d_3021.Str, "L", ToStr(Call(pt_30, V.Undef, GetIdx(P_3016, (ToNum(Get(P_3016, "length")) - 1D)))), "\" stroke=\"", ToStr(c_3017), "\" stroke-width=\"", ToStr(w_3018), "\" fill=\"none\" stroke-linecap=\"round\" opacity=\"", ToStr(op_3019), "\"/>")));
return default;
}, 4, "", true);
{
double i_3024 = 0;
i_3024 = 0D;
while (true) {
if (!((i_3024 < (ToNum(Get(CL_2960, "length")) - 1D)))) break;
V A_3026 = default;
V B_3027 = default;
V P_3028 = default;
A_3026 = GetIdx(CL_2960, i_3024);
B_3027 = GetIdx(CL_2960, ((i_3024 + 3D) % ToNum(Get(CL_2960, "length"))));
P_3028 = Arr();
{
double j_3029 = 0;
j_3029 = 0D;
while (true) {
if (!((j_3029 <= 6D))) break;
double t_3031 = 0;
t_3031 = (j_3029 / 6D);
Invoke(P_3028, "push", Arr(Add(Add(GetIdx(A_3026, 0D), ((V)(((ToNum(GetIdx(B_3027, 0D)) - ToNum(GetIdx(A_3026, 0D))) * t_3031)))), ((V)(((ToNum(Call(R_2958, V.Undef)) - 0.5) * 4D)))), Add(Add(GetIdx(A_3026, 1D), ((V)(((ToNum(GetIdx(B_3027, 1D)) - ToNum(GetIdx(A_3026, 1D))) * t_3031)))), ((V)(((ToNum(Call(R_2958, V.Undef)) - 0.5) * 2.4))))));
j_3029++;
}
}
h_2959.S(string.Concat("<g filter=\"url(#wb1)\">", ToStr(Call(sv_2963, V.Undef, P_3028, ((V)("#cfc3ae")), ((V)(1.2)), ((V)(0.35)))), "</g>")).V(Call(sv_2963, V.Undef, P_3028, ((V)("#7a7064")), Call(f1_16, V.Undef, ((V)((0.08 + (ToNum(Call(R_2958, V.Undef)) * 0.14))))), ((V)(0.4)))).V(Call(sv_2963, V.Undef, Invoke(P_3028, "map", Fn((V _arrowThis3039, int _argc3032, V p_3038, V _a3035, V _a3036, V _a3037, V[] _rest3033) => {
return Arr(Add(GetIdx(p_3038, 0D), ((V)(0.25))), Add(GetIdx(p_3038, 1D), ((V)(0.18))));
}, 1, "", true)), ((V)("#ffffff")), ((V)(0.1)), ((V)(0.55))));
i_3024++;
}
}
Invoke(CL_2960, "forEach", Fn((V _arrowThis3055, int _argc3040, V _a3042, V _a3043, V _a3044, V _a3045, V[] _rest3041) => {
V C_3056 = default;
V cx_3048 = default;
V cy_3050 = default;
V r_3052 = default;
V t_3054 = default;
{ V _t3046 = ListOf(_a3042);
{ V _t3047 = GetIdx(_t3046, 0D);
cx_3048 = _t3047; }
{ V _t3049 = GetIdx(_t3046, 1D);
cy_3050 = _t3049; }
{ V _t3051 = GetIdx(_t3046, 2D);
r_3052 = _t3051; }
{ V _t3053 = GetIdx(_t3046, 3D);
t_3054 = _t3053; }
}
C_3056 = GetK(PAL_2961, t_3054);
h_2959.S("<g filter=\"url(#wb1)\">").V(Invoke(Call(rep_18, V.Undef, ((V)(14D)), Fn((V _arrowThis3063, int _argc3057, V _a3059, V _a3060, V _a3061, V _a3062, V[] _rest3058) => {
double a_3064 = 0;
double d_3065 = 0;
a_3064 = ((ToNum(Call(R_2958, V.Undef)) * 2D) * PI_11);
d_3065 = (Pow(ToNum(Call(R_2958, V.Undef)), 0.7) * ToNum(r_3052));
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, Add(cx_3048, ((V)(((FdLibm.Cos(a_3064) * d_3065) * 1.3)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, Add(cy_3050, ((V)((FdLibm.Sin(a_3064) * d_3065)))))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 + (ToNum(Call(R_2958, V.Undef)) * 1.1)))))), "\" fill=\"", ToStr(GetIdx(C_3056, System.Math.Floor((ToNum(Call(R_2958, V.Undef)) * ToNum(Get(C_3056, "length")))))), "\" opacity=\"0.35\"/>")));
return default;
}, 0, "", true)), "join", ((V)("")))).S("</g>");
h_2959.V(Invoke(Call(rep_18, V.Undef, ((V)(Round((26D + (ToNum(r_3052) * 5D))))), Fn((V _arrowThis3072, int _argc3066, V _a3068, V _a3069, V _a3070, V _a3071, V[] _rest3067) => {
double a_3073 = 0;
double d_3074 = 0;
V x_3075 = default;
V y_3076 = default;
double sz_3077 = 0;
double nv_3078 = 0;
double a0_3079 = 0;
V P_3080 = default;
V c_3081 = default;
V d2_3082 = default;
a_3073 = ((ToNum(Call(R_2958, V.Undef)) * 2D) * PI_11);
d_3074 = (Pow(ToNum(Call(R_2958, V.Undef)), 0.65) * ToNum(r_3052));
x_3075 = Add(cx_3048, ((V)(((FdLibm.Cos(a_3073) * d_3074) * 1.3))));
y_3076 = Add(cy_3050, ((V)((FdLibm.Sin(a_3073) * d_3074))));
sz_3077 = (0.18 + (((ToNum(Call(R_2958, V.Undef)) * ToNum(Call(R_2958, V.Undef))) * (0.5 + (ToNum(r_3052) * 0.11))) * (1.2 - ((d_3074 / ToNum(r_3052)) * 0.6))));
nv_3078 = (4D + System.Math.Floor((ToNum(Call(R_2958, V.Undef)) * 3D)));
a0_3079 = (ToNum(Call(R_2958, V.Undef)) * PI_11);
P_3080 = Call(rep_18, V.Undef, ((V)(nv_3078)), Fn((V _arrowThis3090, int _argc3083, V k_3089, V _a3086, V _a3087, V _a3088, V[] _rest3084) => {
double aa_3091 = 0;
double rr_3092 = 0;
aa_3091 = ((a0_3079 + (((ToNum(k_3089) / nv_3078) * 2D) * PI_11)) + ((ToNum(Call(R_2958, V.Undef)) - 0.5) * 0.6));
rr_3092 = (sz_3077 * (0.55 + (ToNum(Call(R_2958, V.Undef)) * 0.6)));
return Arr(Add(x_3075, ((V)(((FdLibm.Cos(aa_3091) * rr_3092) * 1.25)))), Add(y_3076, ((V)((FdLibm.Sin(aa_3091) * rr_3092)))));
return default;
}, 1, "", true));
c_3081 = GetIdx(C_3056, System.Math.Floor((ToNum(Call(R_2958, V.Undef)) * ToNum(Get(C_3056, "length")))));
d2_3082 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(P_3080, "map", pt_30), "join", ((V)("L")))).S("Z").End()));
return ((V)(string.Concat((LtN(Call(R_2958, V.Undef), 0.22) ? string.Concat("<path d=\"", ToStr(d2_3082), "\" fill=\"#fbf8f0\" opacity=\"0.7\"/>") : string.Concat("<path d=\"", ToStr(d2_3082), "\" fill=\"", ToStr(c_3081), "\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.45 + (ToNum(Call(R_2958, V.Undef)) * 0.4)))))), "\"/>")), string.Concat("<path d=\"M", ToStr(Call(pt_30, V.Undef, GetIdx(P_3080, 0D))), "L", ToStr(Call(pt_30, V.Undef, GetIdx(P_3080, 1D))), "\" stroke=\"", ToStr(Call(shade_10, V.Undef, c_3081, ((V)(1.45)))), "\" stroke-width=\"0.08\" opacity=\"0.6\"/>"), (LtN(Call(R_2958, V.Undef), 0.2) ? string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, x_3075)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, y_3076)), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((sz_3077 * 0.18))))), "\" fill=\"#ffffff\" opacity=\"0.8\"/>") : ""))));
return default;
}, 0, "", true)), "join", ((V)(""))));
return default;
}, 1, "", true));
h_2959.V(Invoke(Call(rep_18, V.Undef, ((V)(120D)), Fn((V _arrowThis3099, int _argc3093, V _a3095, V _a3096, V _a3097, V _a3098, V[] _rest3094) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_2958, V.Undef)) * 40D))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_2958, V.Undef)) * 56D))))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.06 + (ToNum(Call(R_2958, V.Undef)) * 0.14)))))), "\" fill=\"", (LtN(Call(R_2958, V.Undef), 0.6) ? "#3a332e" : "#c48a4c"), "\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 + (ToNum(Call(R_2958, V.Undef)) * 0.4)))))), "\"/>")));
}, 0, "", true)), "join", ((V)("")))).S("</g>");
half_2964 = ((V)(string.Concat("<g id=\"kqH\">", h_2959.Str, "</g>")));
stone_2965 = ((V)(JsStrBuf.Begin().V(half_2964).S("<use href=\"#kqH\" transform=\"translate(80 0) scale(-1 1)\"/>").S(string.Concat("<rect width=\"80\" height=\"56\" fill=\"url(#kqg)\" opacity=\"0.5\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.35;0.7;0.35")), ((V)(9D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "</rect><rect width=\"80\" height=\"56\" fill=\"url(#kqs)\"/>")).V(Invoke(Invoke(Arr(((V)(0D)), ((V)(40D)), ((V)(80D))), "map", Fn((V _arrowThis3107, int _argc3100, V x_3106, V _a3103, V _a3104, V _a3105, V[] _rest3101) => {
return ((V)(string.Concat("<rect x=\"", NumStr((ToNum(x_3106) - 0.22)), "\" width=\"0.44\" height=\"56\" fill=\"url(#kqb)\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
DX_2966 = 29D;
DY_2967 = 19.4;
DW_2968 = 22D;
DH_2969 = 13D;
RCP_2970 = Arr(Arr(((V)("Honey Cake")), ((V)("Step 2 of 5")), ((V)("#f0c46a"))), Arr(((V)("Lemon Pasta")), ((V)("Step 3 of 4")), ((V)("#f3e27a"))), Arr(((V)("Berry Tart")), ((V)("Step 1 of 6")), ((V)("#e88a9a"))));
ic_2971 = Arr(((V)(string.Concat("<ellipse cx=\"0\" cy=\"0.6\" rx=\"2.1\" ry=\"1\" fill=\"none\" stroke=\"#f2d9a0\" stroke-width=\"0.22\"/><path d=\"M-2.1 0.6Q-2 2.6 0 2.8Q2 2.6 2.1 0.6\" fill=\"none\" stroke=\"#f2d9a0\" stroke-width=\"0.22\"/><path d=\"M-0.6 -1.8l0.8 2.2M0.8 -2l-0.4 2.4\" stroke=\"#f0c46a\" stroke-width=\"0.2\"/>", ""))), ((V)(string.Concat("<circle r=\"2.1\" fill=\"none\" stroke=\"#f2d9a0\" stroke-width=\"0.22\"/><path d=\"M-1.2 -0.4q0.6 -0.8 1.2 0t1.2 0M-1.3 0.6q0.6 -0.8 1.2 0t1.2 0\" stroke=\"#f3e27a\" stroke-width=\"0.2\" fill=\"none\"/>", ""))), ((V)(string.Concat("<path d=\"M-2.2 0.4H2.2L1.6 2.2H-1.6Z\" fill=\"none\" stroke=\"#f2d9a0\" stroke-width=\"0.22\"/><circle cx=\"-0.9\" cy=\"-0.2\" r=\"0.5\" fill=\"#e88a9a\"/><circle cx=\"0.3\" cy=\"-0.5\" r=\"0.5\" fill=\"#d0607a\"/><circle cx=\"1.2\" cy=\"-0.1\" r=\"0.45\" fill=\"#e88a9a\"/>", ""))));
pg_2972 = new JsStrBuf("");
Invoke(RCP_2970, "forEach", Fn((V _arrowThis3122, int _argc3108, V _a3110, V i_3114, V _a3112, V _a3113, V[] _rest3109) => {
V ov_3123 = default;
V t_3117 = default;
V st_3119 = default;
V c_3121 = default;
{ V _t3115 = ListOf(_a3110);
{ V _t3116 = GetIdx(_t3115, 0D);
t_3117 = _t3116; }
{ V _t3118 = GetIdx(_t3115, 1D);
st_3119 = _t3118; }
{ V _t3120 = GetIdx(_t3115, 2D);
c_3121 = _t3120; }
}
ov_3123 = GetK(Arr(((V)("1;1;0;0;0;0;1")), ((V)("0;0;1;1;0;0;0")), ((V)("0;0;0;0;1;1;0"))), i_3114);
pg_2972.S(string.Concat("<g opacity=\"", NumStr((Truthy(i_3114) ? 0D : 1D)), "\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ov_3123, ((V)(30D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.3;0.333;0.633;0.667;0.967;1\"")))), "<g transform=\"translate(", NumStr((DX_2966 + 3.6)), " ", NumStr((DY_2967 + 4.6)), ")\">", ToStr(GetK(ic_2971, i_3114)), "</g><text x=\"", NumStr((DX_2966 + 7D)), "\" y=\"", NumStr((DY_2967 + 3.8)), "\" font-family=\"Georgia,'Times New Roman',serif\" font-size=\"2\" fill=\"#f6e4b8\" font-style=\"italic\">", ToStr(t_3117), "</text><text x=\"", NumStr((DX_2966 + 7D)), "\" y=\"", NumStr((DY_2967 + 5.6)), "\" font-family=\"Arial,Helvetica,sans-serif\" font-size=\"0.9\" fill=\"#c9b48a\" letter-spacing=\"0.08\">", ToStr(Invoke(st_3119, "toUpperCase")), "</text>")).V(Invoke(Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis3131, int _argc3124, V k_3130, V _a3127, V _a3128, V _a3129, V[] _rest3125) => {
return ((V)(string.Concat("<circle cx=\"", NumStr((DX_2966 + 7.3)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)(((DY_2967 + 7.2) + (ToNum(k_3130) * 1.15)))))), "\" r=\"0.2\" fill=\"", ToStr(c_3121), "\"/><rect x=\"", NumStr((DX_2966 + 8D)), "\" y=\"", ToStr(Call(f1_16, V.Undef, ((V)(((DY_2967 + 6.95) + (ToNum(k_3130) * 1.15)))))), "\" width=\"", ToStr(Call(f1_16, V.Undef, ((V)((5D + (((ToNum(k_3130) * 7D) + (ToNum(i_3114) * 3D)) % 6D)))))), "\" height=\"0.45\" rx=\"0.22\" fill=\"#e9d6aa\" opacity=\"0.55\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<rect x=\"", NumStr((DX_2966 + 1.4)), "\" y=\"", NumStr(((DY_2967 + DH_2969) - 1.6)), "\" width=\"", NumStr((DW_2968 - 2.8)), "\" height=\"0.35\" rx=\"0.17\" fill=\"#ffffff\" opacity=\"0.12\"/><rect x=\"", NumStr((DX_2966 + 1.4)), "\" y=\"", NumStr(((DY_2967 + DH_2969) - 1.6)), "\" width=\"1\" height=\"0.35\" rx=\"0.17\" fill=\"", ToStr(c_3121), "\">", ToStr(Call(an_14, V.Undef, ((V)("width")), ((V)(string.Concat("1;", NumStr((DW_2968 - 2.8))))), ((V)(10D)), ((V)((ToNum(i_3114) * 10D))))), "</rect></g>"));
return default;
}, 2, "", true));
disp_2973 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"", NumStr((DX_2966 - 0.5)), "\" y=\"", NumStr((DY_2967 - 0.5)), "\" width=\"", NumStr((DW_2968 + 1D)), "\" height=\"", NumStr((DH_2969 + 1D)), "\" rx=\"0.9\" fill=\"#000000\" opacity=\"0.3\" filter=\"url(#wb1)\"/><rect x=\"", NumStr((DX_2966 - 0.25)), "\" y=\"", NumStr((DY_2967 - 0.25)), "\" width=\"", NumStr((DW_2968 + 0.5)), "\" height=\"", NumStr((DH_2969 + 0.5)), "\" rx=\"0.8\" fill=\"url(#kqb)\"/><rect x=\"", NumStr(DX_2966), "\" y=\"", NumStr(DY_2967), "\" width=\"", NumStr(DW_2968), "\" height=\"", NumStr(DH_2969), "\" rx=\"0.6\" fill=\"#17130e\"/><rect x=\"", NumStr(DX_2966), "\" y=\"", NumStr(DY_2967), "\" width=\"", NumStr(DW_2968), "\" height=\"", NumStr(DH_2969), "\" rx=\"0.6\" fill=\"url(#kqd)\"/>")).S(pg_2972.Str).S(string.Concat("<g transform=\"translate(", NumStr(((DX_2966 + DW_2968) - 2.4)), " ", NumStr((DY_2967 + 2.4)), ")\"><circle r=\"1.3\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.2\" opacity=\"0.15\"/><circle r=\"1.3\" fill=\"none\" stroke=\"#f0c46a\" stroke-width=\"0.22\" stroke-dasharray=\"8.17\" stroke-dashoffset=\"0\" transform=\"rotate(-90)\">", ToStr(Call(an_14, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;8.17")), ((V)(10D)))), "</circle><text y=\"0.32\" text-anchor=\"middle\" font-family=\"Arial,Helvetica,sans-serif\" font-size=\"0.85\" fill=\"#f6e4b8\">12</text></g>")).S(string.Concat("<circle cx=\"", NumStr((DX_2966 + 15D)), "\" cy=\"", NumStr((DY_2967 + 9D)), "\" r=\"0.4\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.16\" opacity=\"0\">", ToStr(Call(an_14, V.Undef, ((V)("r")), ((V)("0.4;0.4;3")), ((V)(10D)), ((V)(9.4)), ((V)(" keyTimes=\"0;0.9;1\"")))), ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0;0;0.6;0")), ((V)(10D)), ((V)(9.4)), ((V)(" keyTimes=\"0;0.9;0.92;1\"")))), "</circle>")).S(string.Concat("<path d=\"M", NumStr((DX_2966 + 0.6)), " ", NumStr((DY_2967 + 0.6)), "H", NumStr((DX_2966 + 9D)), "L", NumStr((DX_2966 + 4D)), " ", NumStr(((DY_2967 + DH_2969) - 0.6)), "H", NumStr((DX_2966 + 0.6)), "Z\" fill=\"#ffffff\" opacity=\"0.06\"/>")).S(string.Concat("<g filter=\"url(#wb2)\"><rect x=\"", NumStr((DX_2966 - 1.5)), "\" y=\"", NumStr((DY_2967 + DH_2969)), "\" width=\"", NumStr((DW_2968 + 3D)), "\" height=\"2.4\" fill=\"#ffd89a\" opacity=\"0.2\"/></g>")).End()));
board_2974 = ((V)("#7c5c30"));
return NewObj(7).Put("mat", stone_2965).Put("one", disp_2973).Put("sup", stone_2965).Put("smat", stone_2965).Put("board", board_2974).Put("defs", ((V)(string.Concat("<clipPath id=\"kqh\"><rect width=\"40\" height=\"56\"/></clipPath><radialGradient id=\"kqg\" cx=\"50%\" cy=\"45%\" r=\"65%\"><stop offset=\"0\" stop-color=\"#fff2d0\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#ffe2a8\" stop-opacity=\"0\"/></radialGradient>", "<linearGradient id=\"kqs\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.14\"/><stop offset=\"0.4\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#5a4020\" stop-opacity=\"0.08\"/></linearGradient>", "<linearGradient id=\"kqb\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff0b8\"/><stop offset=\"0.4\" stop-color=\"#d8ac58\"/><stop offset=\"1\" stop-color=\"#8a6420\"/></linearGradient>", "<linearGradient id=\"kqd\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#3a2c1a\" stop-opacity=\"0.6\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0\"/></linearGradient>")))).Put("ro", NewObj(3).Put("top", ((V)(0.04))).Put("ao", ((V)(0.1))).Put("board", ((V)(JsStrBuf.Begin().S(string.Concat("<rect y=\"", ToStr(BB_2490), "\" width=\"80\" height=\"0.4\" fill=\"#f2d58a\"/><rect y=\"", ToStr(Call(f1_16, V.Undef, Add(BB_2490, ((V)(0.4))))), "\" width=\"80\" height=\"0.3\" fill=\"#fff0c0\" opacity=\"0.7\"/>")).V(Invoke(Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis3139, int _argc3132, V i_3138, V _a3135, V _a3136, V _a3137, V[] _rest3133) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(i_3138) * 5D) + 1D))))), "\" y=\"", ToStr(Call(f1_16, V.Undef, Add(BB_2490, ((V)(1D))))), "\" width=\"3\" height=\"0.9\" rx=\"0.2\" fill=\"#5a3e1a\" opacity=\"0.6\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<rect y=\"", ToStr(Call(f1_16, V.Undef, ((V)((56D - 0.4))))), "\" width=\"80\" height=\"0.4\" fill=\"#ffe2a0\" opacity=\"0.6\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.45;0.75;0.45")), ((V)(6D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "</rect>")).End()))).V).V;
return default;
}, 0, "", true));
Object_assign(SURF12_2491, NewObj(5).Put("k01dry", kDry_2500).Put("k21vin", kVinyl_2501).Put("k41herr", kHerr_2502).Put("k61cop", kCop_2503).Put("k81qtz", kQtz_2504).V);
draw27w_2505 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis3148, int _argc3140, V r_3146, V o_3147, V _a3144, V _a3145, V[] _rest3141) => {
V res_3149 = default;
res_3149 = Call(draw27w_2505, V.Undef, r_3146, o_3147);
if (Truthy(((((!(Truthy(res_3149)) || !(Truthy(Get(res_3149, "tile")))) || !(Truthy(Get(r_3146, "s12")))) ? V.True : V.False) is var _t3150 && Truthy(_t3150) ? _t3150 : Get(res_3149, "_one")))) {
return res_3149;
}
try {
V f_3151 = default;
V S_3152 = default;
f_3151 = GetK(SURF12_2491, Get(r_3146, "s12"));
S_3152 = (f_3151 is var _t3153 && !Truthy(_t3153) ? _t3153 : Call(f_3151, V.Undef));
if (Truthy((S_3152 is var _t3154 && !Truthy(_t3154) ? _t3154 : Get(S_3152, "one")))) {
V M_3155 = default;
Set(res_3149, "_one", ((V)(1D)));
M_3155 = (GetK(WMEMO27_88, ((V)(JsStrBuf.Begin().V(Get(r_3146, "s12")).S("|one").End()))) is var _t3158 && Truthy(_t3158) ? _t3158 : SetK(WMEMO27_88, ((V)(JsStrBuf.Begin().V(Get(r_3146, "s12")).S("|one").End())), NewObj(2).Put("card", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Invoke(RD_8, "svgDoc", ((V)("0 0 80 56")), Arr(), Invoke(Get(RD_8, "H12"), "tile", Object_assign(NewObj(0).V, S_3152, NewObj(1).Put("mat", Add(Get(S_3152, "mat"), Get(S_3152, "one"))).V))))).End()))).Put("one", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, ((V)(JsStrBuf.Begin().S("<svg xmlns=\"http://www.w3.org/2000/svg\" viewBox=\"0 0 80 56\" preserveAspectRatio=\"none\"><defs><filter id=\"wb2\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"1.3\"/></filter><filter id=\"wb1\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"0.45\"/></filter>").V((Get(S_3152, "defs") is var _t3157 && Truthy(_t3157) ? _t3157 : ((V)("")))).S("</defs>").V(Get(S_3152, "one")).S("</svg>").End())))).End()))).V));
Set(res_3149, "src", Get(M_3155, "card"));
Set(res_3149, "wallOne", Get(M_3155, "one"));
}
} catch (System.Exception _ex3159) {
V e_3160 = default;
e_3160 = Caught(_ex3159);
Invoke(G("console"), "warn", ((V)("reno plus27 wallOne")), Get(r_3146, "id"), e_3160);
}
return res_3149;
return default;
}, 2, "", true));
}
{
V WIN_3161 = default;
V WDEF_3162 = default;
V bev_3163 = default;
V ring_3164 = default;
V reveal_3165 = default;
V sill_3166 = default;
V cloud_3167 = default;
V drift_3168 = default;
V sway_3169 = default;
V tree_3170 = default;
V glassRef_3171 = default;
V pot_3172 = default;
V HB_3173 = default;
V herb_3174 = default;
V lblotW_3175 = default;
lblotW_3175 = Fn((V _self3176, int _argc3177, V R_3183, V _a3180, V _a3181, V _a3182, V[] _rest3178) => {
if (_self3176.IsNullish) _self3176 = GlobalV;
return ((V)(JsStrBuf.Begin().S("<g filter=\"url(#b1)\">").V(Invoke(Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis3190, int _argc3184, V _a3186, V _a3187, V _a3188, V _a3189, V[] _rest3185) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_16, V.Undef, ((V)(((-24D) + (ToNum(Call(R_3183, V.Undef)) * 48D)))))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)(((-27D) + (ToNum(Call(R_3183, V.Undef)) * 18D)))))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((1D + (ToNum(Call(R_3183, V.Undef)) * 2.4)))))).S("\" ry=\"").V(Call(f1_16, V.Undef, Add(((V)(0.6)), Call(R_3183, V.Undef)))).S("\" fill=\"#8a4a20\" opacity=\"0.28\"/>").End()));
}, 0, "", true)), "join", ((V)("")))).S("</g>").S("<path d=\"M-6 -20.4q0.8 -0.6 1.4 0.2t1.2 0.4M10 -12.8q0.6 0.8 1.4 0\" stroke=\"#3a2a1a\" stroke-width=\"0.14\" fill=\"none\"/><ellipse cx=\"-4.8\" cy=\"-20\" rx=\"1.2\" ry=\"0.9\" fill=\"#1e1a14\" opacity=\"0.5\"/>").End()));
return default;
}, 1, "lblotW", false);
WIN_3161 = Get(Get(RD_8, "H19"), "WIN19");
WDEF_3162 = ((V)(string.Concat("<filter id=\"b1\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"0.6\"/></filter><filter id=\"b2\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"1.6\"/></filter>", "<linearGradient id=\"gref\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.22\"/><stop offset=\"0.35\" stop-color=\"#ffffff\" stop-opacity=\"0.02\"/><stop offset=\"0.6\" stop-color=\"#ffffff\" stop-opacity=\"0.1\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>", "<linearGradient id=\"tc\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8e4426\"/><stop offset=\"0.35\" stop-color=\"#d4804e\"/><stop offset=\"0.6\" stop-color=\"#c06a3e\"/><stop offset=\"1\" stop-color=\"#7e3a20\"/></linearGradient>")));
bev_3163 = Fn((V _arrowThis3203, int _argc3191, V x_3197, V y_3198, V w_3199, V h_3200, V[] _rest3192) => {
V c_3201 = default;
V t_3202 = default;
c_3201 = (_argc3191 > 4 ? _rest3192[0] : V.Undef);
t_3202 = (_argc3191 > 5 ? _rest3192[1] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_16, V.Undef, x_3197)).S("\" y=\"").V(Call(f1_16, V.Undef, y_3198)).S("\" width=\"").V(Call(f1_16, V.Undef, w_3199)).S("\" height=\"").V(Call(f1_16, V.Undef, h_3200)).S("\" fill=\"").V(c_3201).S("\"/><path d=\"M").V(Call(f1_16, V.Undef, x_3197)).S(" ").V(Call(f1_16, V.Undef, y_3198)).S("h").V(Call(f1_16, V.Undef, w_3199)).S("l").N((-ToNum(t_3202))).S(" ").V(t_3202).S("h").V(Call(f1_16, V.Undef, ((V)((-(ToNum(w_3199) - (2D * ToNum(t_3202)))))))).S("v").V(Call(f1_16, V.Undef, ((V)((ToNum(h_3200) - (2D * ToNum(t_3202))))))).S("l").N((-ToNum(t_3202))).S(" ").V(t_3202).S("Z\" fill=\"#ffffff\" opacity=\"0.38\"/><path d=\"M").V(Call(f1_16, V.Undef, Add(x_3197, w_3199))).S(" ").V(Call(f1_16, V.Undef, Add(y_3198, h_3200))).S("h").V(Call(f1_16, V.Undef, ((V)((-ToNum(w_3199)))))).S("l").V(t_3202).S(" ").N((-ToNum(t_3202))).S("h").V(Call(f1_16, V.Undef, ((V)((ToNum(w_3199) - (2D * ToNum(t_3202))))))).S("v").V(Call(f1_16, V.Undef, ((V)((-(ToNum(h_3200) - (2D * ToNum(t_3202)))))))).S("l").V(t_3202).S(" ").N((-ToNum(t_3202))).S("Z\" fill=\"#000000\" opacity=\"0.2\"/>").End()));
}, 6, "", true);
ring_3164 = Fn((V _arrowThis3217, int _argc3204, V x0_3210, V y0_3211, V x1_3212, V y1_3213, V[] _rest3205) => {
V t_3214 = default;
V c_3215 = default;
V e_3216 = default;
t_3214 = (_argc3204 > 4 ? _rest3205[0] : V.Undef);
c_3215 = (_argc3204 > 5 ? _rest3205[1] : V.Undef);
e_3216 = (_argc3204 > 6 ? _rest3205[2] : V.Undef);
return Add(Add(Add(Call(bev_3163, V.Undef, x0_3210, y0_3211, ((V)((ToNum(x1_3212) - ToNum(x0_3210)))), t_3214, c_3215, e_3216), Call(bev_3163, V.Undef, x0_3210, ((V)((ToNum(y1_3213) - ToNum(t_3214)))), ((V)((ToNum(x1_3212) - ToNum(x0_3210)))), t_3214, c_3215, e_3216)), Call(bev_3163, V.Undef, x0_3210, Add(y0_3211, t_3214), t_3214, ((V)(((ToNum(y1_3213) - ToNum(y0_3211)) - (2D * ToNum(t_3214))))), c_3215, e_3216)), Call(bev_3163, V.Undef, ((V)((ToNum(x1_3212) - ToNum(t_3214)))), Add(y0_3211, t_3214), t_3214, ((V)(((ToNum(y1_3213) - ToNum(y0_3211)) - (2D * ToNum(t_3214))))), c_3215, e_3216));
}, 7, "", true);
reveal_3165 = Fn((V _arrowThis3230, int _argc3218, V x0_3224, V y0_3225, V x1_3226, V y1_3227, V[] _rest3219) => {
V d_3228 = default;
V c_3229 = default;
d_3228 = (_argc3218 > 4 ? _rest3219[0] : V.Undef);
c_3229 = (_argc3218 > 5 ? _rest3219[1] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(x0_3224).S(" ").V(y0_3225).S("H").V(x1_3226).S("L").N((ToNum(x1_3226) - ToNum(d_3228))).S(" ").V(Add(y0_3225, d_3228)).S("H").V(Add(x0_3224, d_3228)).S("Z\" fill=\"").V(Call(shade_10, V.Undef, c_3229, ((V)(0.62)))).S("\"/><path d=\"M").V(x0_3224).S(" ").V(y0_3225).S("L").V(Add(x0_3224, d_3228)).S(" ").V(Add(y0_3225, d_3228)).S("V").N((ToNum(y1_3227) - ToNum(d_3228))).S("L").V(x0_3224).S(" ").V(y1_3227).S("Z\" fill=\"").V(Call(shade_10, V.Undef, c_3229, ((V)(0.78)))).S("\"/><path d=\"M").V(x1_3226).S(" ").V(y0_3225).S("V").V(y1_3227).S("L").N((ToNum(x1_3226) - ToNum(d_3228))).S(" ").N((ToNum(y1_3227) - ToNum(d_3228))).S("V").V(Add(y0_3225, d_3228)).S("Z\" fill=\"").V(Call(shade_10, V.Undef, c_3229, ((V)(0.95)))).S("\"/><path d=\"M").V(x0_3224).S(" ").V(y1_3227).S("L").V(Add(x0_3224, d_3228)).S(" ").N((ToNum(y1_3227) - ToNum(d_3228))).S("H").N((ToNum(x1_3226) - ToNum(d_3228))).S("L").V(x1_3226).S(" ").V(y1_3227).S("Z\" fill=\"").V(Call(shade_10, V.Undef, c_3229, ((V)(1.06)))).S("\"/>").End()));
}, 6, "", true);
sill_3166 = Fn((V _arrowThis3242, int _argc3231, V x0_3237, V x1_3238, V y_3239, V c_3240, V[] _rest3232) => {
V d_3241 = default;
d_3241 = (_argc3231 > 4 ? _rest3232[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(x0_3237).S("\" y=\"").V(Add(y_3239, ((V)(2.6)))).S("\" width=\"").N((ToNum(x1_3238) - ToNum(x0_3237))).S("\" height=\"2\" fill=\"#000000\" opacity=\"0.22\" filter=\"url(#b1)\"/><path d=\"M").V(Add(x0_3237, d_3241)).S(" ").N((ToNum(y_3239) - ToNum(d_3241))).S("H").N((ToNum(x1_3238) - ToNum(d_3241))).S("L").V(x1_3238).S(" ").V(y_3239).S("H").V(x0_3237).S("Z\" fill=\"").V(Call(shade_10, V.Undef, c_3240, ((V)(1.08)))).S("\"/><rect x=\"").V(x0_3237).S("\" y=\"").V(y_3239).S("\" width=\"").N((ToNum(x1_3238) - ToNum(x0_3237))).S("\" height=\"3\" fill=\"").V(c_3240).S("\"/><rect x=\"").V(x0_3237).S("\" y=\"").V(y_3239).S("\" width=\"").N((ToNum(x1_3238) - ToNum(x0_3237))).S("\" height=\"0.4\" fill=\"#ffffff\" opacity=\"0.5\"/><rect x=\"").V(x0_3237).S("\" y=\"").V(Add(y_3239, ((V)(2.6)))).S("\" width=\"").N((ToNum(x1_3238) - ToNum(x0_3237))).S("\" height=\"0.4\" fill=\"#000000\" opacity=\"0.2\"/>").End()));
}, 5, "", true);
cloud_3167 = Fn((V _arrowThis3253, int _argc3243, V x_3249, V y_3250, V k_3251, V c_3252, V[] _rest3244) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(f1_16, V.Undef, x_3249)).S(" ").V(Call(f1_16, V.Undef, y_3250)).S(") scale(").V(Call(n4_17, V.Undef, k_3251)).S(")\"><ellipse cx=\"0.6\" cy=\"1.4\" rx=\"7\" ry=\"2.2\" fill=\"").V(Call(shade_10, V.Undef, c_3252, ((V)(0.86)))).S("\"/><ellipse rx=\"7\" ry=\"2.6\" fill=\"").V(c_3252).S("\"/><circle cx=\"-3\" cy=\"-1.6\" r=\"3\" fill=\"").V(c_3252).S("\"/><circle cx=\"1.4\" cy=\"-2.8\" r=\"3.8\" fill=\"").V(c_3252).S("\"/><circle cx=\"4.8\" cy=\"-0.9\" r=\"2.5\" fill=\"").V(c_3252).S("\"/><circle cx=\"0.4\" cy=\"-3.6\" r=\"1.6\" fill=\"#ffffff\" opacity=\"0.6\"/></g>").End()));
}, 4, "", true);
drift_3168 = Fn((V _arrowThis3263, int _argc3254, V q_3260, V w_3261, V d_3262, V _a3259, V[] _rest3255) => {
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(at_47, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;").V(Call(f1_16, V.Undef, w_3261)).S(" 0").End())), d_3262)).V(q_3260).S("<g transform=\"translate(").V(Call(f1_16, V.Undef, ((V)((-ToNum(w_3261)))))).S(" 0)\">").V(q_3260).S("</g></g>").End()));
}, 3, "", true);
sway_3169 = Fn((V _arrowThis3277, int _argc3264, V x_3270, V y_3271, V k_3272, V a_3273, V[] _rest3265) => {
V d_3274 = default;
V ph_3275 = default;
V inner_3276 = default;
d_3274 = (_argc3264 > 4 ? _rest3265[0] : V.Undef);
ph_3275 = (_argc3264 > 5 ? _rest3265[1] : V.Undef);
inner_3276 = (_argc3264 > 6 ? _rest3265[2] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(f1_16, V.Undef, x_3270)).S(" ").V(Call(f1_16, V.Undef, y_3271)).S(") scale(").V(Call(n4_17, V.Undef, k_3272)).S(")\"><g>").V(Call(at_47, V.Undef, ((V)("rotate")), ((V)(JsStrBuf.Begin().N((-ToNum(a_3273))).S(" 0 0;").V(a_3273).S(" 0 0;").N((-ToNum(a_3273))).S(" 0 0").End())), d_3274, ((V)((-ToNum(ph_3275)))), Call(SPL_15, V.Undef, ((V)(2D))))).V(inner_3276).S("</g></g>").End()));
}, 7, "", true);
tree_3170 = Fn((V _arrowThis3289, int _argc3278, V x_3284, V y_3285, V k_3286, V c_3287, V[] _rest3279) => {
V ph_3288 = default;
ph_3288 = (_argc3278 > 4 ? _rest3279[0] : V.Undef);
return Add(Call(sway_3169, V.Undef, x_3284, y_3285, k_3286, ((V)(0D)), ((V)(1D)), ((V)(0D)), ((V)("<path d=\"M-1 0L-0.7 -10H0.7L1 0Z\" fill=\"#6a4a2e\"/>"))), Call(sway_3169, V.Undef, x_3284, ((V)((ToNum(y_3285) - (8D * ToNum(k_3286))))), k_3286, ((V)(2.5)), Add(((V)(5D)), ph_3288), ph_3288, ((V)(JsStrBuf.Begin().S("<circle cx=\"-3.6\" cy=\"-3\" r=\"4.6\" fill=\"").V(Call(shade_10, V.Undef, c_3287, ((V)(0.85)))).S("\"/><circle cx=\"3.4\" cy=\"-3.6\" r=\"4.4\" fill=\"").V(Call(shade_10, V.Undef, c_3287, ((V)(0.9)))).S("\"/><circle cy=\"-7\" r=\"5.4\" fill=\"").V(c_3287).S("\"/><circle cx=\"-1.6\" cy=\"-8.6\" r=\"2.2\" fill=\"").V(Call(shade_10, V.Undef, c_3287, ((V)(1.2)))).S("\"/><circle cx=\"2.6\" cy=\"-5\" r=\"1.8\" fill=\"").V(Call(shade_10, V.Undef, c_3287, ((V)(1.12)))).S("\"/>").End()))));
}, 5, "", true);
glassRef_3171 = Fn((V _arrowThis3300, int _argc3290, V x_3296, V y_3297, V w_3298, V h_3299, V[] _rest3291) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(x_3296).S("\" y=\"").V(y_3297).S("\" width=\"").V(w_3298).S("\" height=\"").V(h_3299).S("\" fill=\"url(#gref)\"/><path d=\"M").V(Call(f1_16, V.Undef, Add(x_3296, ((V)((ToNum(w_3298) * 0.2)))))).S(" ").V(y_3297).S("L").V(Call(f1_16, V.Undef, Add(x_3296, ((V)((ToNum(w_3298) * 0.05)))))).S(" ").V(Add(y_3297, h_3299)).S("H").V(Call(f1_16, V.Undef, Add(x_3296, ((V)((ToNum(w_3298) * 0.12)))))).S("L").V(Call(f1_16, V.Undef, Add(x_3296, ((V)((ToNum(w_3298) * 0.27)))))).S(" ").V(y_3297).S("Z\" fill=\"#ffffff\" opacity=\"0.08\"/>").End()));
}, 4, "", true);
pot_3172 = Fn((V _arrowThis3312, int _argc3301, V x_3307, V y_3308, V w_3309, V h_3310, V[] _rest3302) => {
double t_3313 = 0;
V rim_3311 = default;
rim_3311 = (_argc3301 > 4 ? _rest3302[0] : V.Undef);
t_3313 = (ToNum(w_3309) * 0.8);
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_16, V.Undef, x_3307)).S("\" cy=\"").V(Call(f1_16, V.Undef, Add(y_3308, h_3310))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(w_3309) * 0.55))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(w_3309) * 0.12))))).S("\" fill=\"#000000\" opacity=\"0.28\" filter=\"url(#b1)\"/><path d=\"M").V(Call(f1_16, V.Undef, ((V)((ToNum(x_3307) - (ToNum(w_3309) / 2D)))))).S(" ").V(Call(f1_16, V.Undef, y_3308)).S("L").V(Call(f1_16, V.Undef, ((V)((ToNum(x_3307) - (t_3313 / 2D)))))).S(" ").V(Call(f1_16, V.Undef, Add(y_3308, h_3310))).S("H").V(Call(f1_16, V.Undef, Add(x_3307, ((V)((t_3313 / 2D)))))).S("L").V(Call(f1_16, V.Undef, Add(x_3307, ((V)((ToNum(w_3309) / 2D)))))).S(" ").V(Call(f1_16, V.Undef, y_3308)).S("Z\" fill=\"url(#tc)\"/>").S("<rect x=\"").V(Call(f1_16, V.Undef, ((V)(((ToNum(x_3307) - (ToNum(w_3309) / 2D)) - (ToNum(w_3309) * 0.06)))))).S("\" y=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(y_3308) - (ToNum(h_3310) * 0.2)))))).S("\" width=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(w_3309) * 1.12))))).S("\" height=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(h_3310) * 0.24))))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(w_3309) * 0.04))))).S("\" fill=\"").V((rim_3311 is var _t3314 && Truthy(_t3314) ? _t3314 : ((V)("#c8744a")))).S("\"/><rect x=\"").V(Call(f1_16, V.Undef, ((V)(((ToNum(x_3307) - (ToNum(w_3309) / 2D)) - (ToNum(w_3309) * 0.06)))))).S("\" y=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(y_3308) - (ToNum(h_3310) * 0.2)))))).S("\" width=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(w_3309) * 1.12))))).S("\" height=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(h_3310) * 0.06))))).S("\" fill=\"#f0b088\" opacity=\"0.7\"/><rect x=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(x_3307) - (ToNum(w_3309) / 2D)))))).S("\" y=\"").V(Call(f1_16, V.Undef, Add(y_3308, ((V)((ToNum(h_3310) * 0.04)))))).S("\" width=\"").V(Call(f1_16, V.Undef, w_3309)).S("\" height=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(h_3310) * 0.08))))).S("\" fill=\"#000000\" opacity=\"0.18\"/>").S("<ellipse cx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(x_3307) - (ToNum(w_3309) * 0.18)))))).S("\" cy=\"").V(Call(f1_16, V.Undef, Add(y_3308, ((V)((ToNum(h_3310) * 0.55)))))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(w_3309) * 0.08))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(h_3310) * 0.25))))).S("\" fill=\"#f4b890\" opacity=\"0.35\"/><ellipse cx=\"").V(Call(f1_16, V.Undef, Add(x_3307, ((V)((ToNum(w_3309) * 0.2)))))).S("\" cy=\"").V(Call(f1_16, V.Undef, Add(y_3308, ((V)((ToNum(h_3310) * 0.7)))))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(w_3309) * 0.12))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(h_3310) * 0.12))))).S("\" fill=\"#e8e4d4\" opacity=\"0.25\"/>").End()));
return default;
}, 5, "", true);
HB_3173 = NewObj(6).Put("basil", Fn((V _arrowThis3321, int _argc3315, V _a3317, V _a3318, V _a3319, V _a3320, V[] _rest3316) => {
JsStrBuf o_3322 = null;
o_3322 = new JsStrBuf("");
Invoke(Arr(Arr(((V)((-2.4))), ((V)((-3D))), ((V)((-40D)))), Arr(((V)(2.4)), ((V)((-3.4))), ((V)(40D))), Arr(((V)((-1.6))), ((V)((-6D))), ((V)((-25D)))), Arr(((V)(1.8)), ((V)((-6.4))), ((V)(25D))), Arr(((V)(0D)), ((V)((-8.8))), ((V)(0D))), Arr(((V)((-3.2))), ((V)((-1.4))), ((V)((-70D)))), Arr(((V)(3.2)), ((V)((-1.6))), ((V)(70D))), Arr(((V)((-0.6))), ((V)((-4.6))), ((V)((-8D))))), "forEach", Fn((V _arrowThis3337, int _argc3323, V _a3325, V i_3329, V _a3327, V _a3328, V[] _rest3324) => {
V x_3332 = default;
V y_3334 = default;
V a_3336 = default;
{ V _t3330 = ListOf(_a3325);
{ V _t3331 = GetIdx(_t3330, 0D);
x_3332 = _t3331; }
{ V _t3333 = GetIdx(_t3330, 1D);
y_3334 = _t3333; }
{ V _t3335 = GetIdx(_t3330, 2D);
a_3336 = _t3335; }
}
return ((V)(o_3322.S("<path d=\"M0 0Q").V(Call(f1_16, V.Undef, ((V)((ToNum(x_3332) * 0.3))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(y_3334) * 0.6))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(x_3332) * 0.8))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(y_3334) * 0.9))))).S("\" stroke=\"#4a7e32\" stroke-width=\"0.3\" fill=\"none\"/><g transform=\"translate(").V(x_3332).S(" ").V(y_3334).S(") rotate(").V(a_3336).S(")\"><ellipse rx=\"1.5\" ry=\"2.3\" fill=\"").S((NumTruthy((ToNum(i_3329) % 3D)) ? "#5fae42" : "#4e9a36")).S("\"/><path d=\"M0 2.1V-2\" stroke=\"#88c86a\" stroke-width=\"0.18\"/><ellipse cx=\"-0.5\" cy=\"-0.6\" rx=\"0.5\" ry=\"1\" fill=\"#9ad47a\" opacity=\"0.5\"/></g>").Str));
}, 2, "", true));
return ((V)(o_3322.Str));
return default;
}, 0, "basil", true)).Put("rose", Fn((V _arrowThis3344, int _argc3338, V _a3340, V _a3341, V _a3342, V _a3343, V[] _rest3339) => {
JsStrBuf o_3345 = null;
o_3345 = new JsStrBuf("");
Invoke(Arr(((V)((-24D))), ((V)((-11D))), ((V)(0D)), ((V)(12D)), ((V)(25D))), "forEach", Fn((V _arrowThis3354, int _argc3346, V a_3352, V i_3353, V _a3350, V _a3351, V[] _rest3347) => {
double L_3355 = 0;
double r_3356 = 0;
JsStrBuf d_3357 = null;
L_3355 = (9D + ((ToNum(i_3353) % 2D) * 2D));
r_3356 = ((ToNum(a_3352) * PI_11) / 180D);
d_3357 = new JsStrBuf("");
{
double t_3358 = 0;
t_3358 = 1.4;
while (true) {
if (!((t_3358 < L_3355))) break;
double x_3360 = 0;
double y_3361 = 0;
x_3360 = (FdLibm.Sin(r_3356) * t_3358);
y_3361 = ((-FdLibm.Cos(r_3356)) * t_3358);
d_3357.S("M").V(Call(f1_16, V.Undef, ((V)(x_3360)))).S(" ").V(Call(f1_16, V.Undef, ((V)(y_3361)))).S("l").V(Call(f1_16, V.Undef, ((V)((((-1.1) * FdLibm.Cos(r_3356)) - (0.5 * FdLibm.Sin(r_3356))))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((((-1.1) * FdLibm.Sin(r_3356)) + (0.5 * FdLibm.Cos(r_3356))) - 0.6))))).S("M").V(Call(f1_16, V.Undef, ((V)(x_3360)))).S(" ").V(Call(f1_16, V.Undef, ((V)(y_3361)))).S("l").V(Call(f1_16, V.Undef, ((V)(((1.1 * FdLibm.Cos(r_3356)) - (0.5 * FdLibm.Sin(r_3356))))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((((1.1 * FdLibm.Sin(r_3356)) - (0.5 * FdLibm.Cos(r_3356))) + 0.2) - 0.6))))).S("");
t_3358 = (t_3358 + 0.8);
}
}
o_3345.S("<path d=\"M0 0L").V(Call(f1_16, V.Undef, ((V)((FdLibm.Sin(r_3356) * L_3355))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((-FdLibm.Cos(r_3356)) * L_3355))))).S("\" stroke=\"#6a5a3e\" stroke-width=\"0.35\"/><path d=\"").S(d_3357.Str).S("\" stroke=\"").S((NumTruthy((ToNum(i_3353) % 2D)) ? "#47664c" : "#56785a")).S("\" stroke-width=\"0.34\" stroke-linecap=\"round\"/>");
return default;
}, 2, "", true));
return ((V)(o_3345.Str));
return default;
}, 0, "rose", true)).Put("chive", Fn((V _arrowThis3368, int _argc3362, V _a3364, V _a3365, V _a3366, V _a3367, V[] _rest3363) => {
JsStrBuf o_3369 = null;
o_3369 = new JsStrBuf("");
{
double i_3370 = 0;
i_3370 = 0D;
while (true) {
if (!((i_3370 < 12D))) break;
double a_3372 = 0;
double L_3373 = 0;
a_3372 = ((i_3370 - 5.5) * 0.12);
L_3373 = (8D + ((i_3370 * 7D) % 4D));
o_3369.S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)(((i_3370 - 5.5) * 0.25))))).S(" 0Q").V(Call(f1_16, V.Undef, ((V)(((FdLibm.Sin(a_3372) * L_3373) * 0.5))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((-L_3373) * 0.6))))).S(" ").V(Call(f1_16, V.Undef, ((V)((FdLibm.Sin(a_3372) * L_3373))))).S(" ").V(Call(f1_16, V.Undef, ((V)((-L_3373))))).S("\" stroke=\"").S((NumTruthy((i_3370 % 3D)) ? "#5c9a3c" : "#4c8a30")).S("\" stroke-width=\"0.42\" fill=\"none\" stroke-linecap=\"round\"/>");
i_3370++;
}
}
Invoke(Arr(Arr(((V)((-1.6))), ((V)((-10.2)))), Arr(((V)(1.4)), ((V)((-11D))))), "forEach", Fn((V _arrowThis3385, int _argc3374, V _a3376, V _a3377, V _a3378, V _a3379, V[] _rest3375) => {
V x_3382 = default;
V y_3384 = default;
{ V _t3380 = ListOf(_a3376);
{ V _t3381 = GetIdx(_t3380, 0D);
x_3382 = _t3381; }
{ V _t3383 = GetIdx(_t3380, 1D);
y_3384 = _t3383; }
}
return ((V)(o_3369.S("<circle cx=\"").V(x_3382).S("\" cy=\"").V(y_3384).S("\" r=\"1.3\" fill=\"#b07ac2\"/><circle cx=\"").N((ToNum(x_3382) - 0.4)).S("\" cy=\"").N((ToNum(y_3384) - 0.4)).S("\" r=\"0.6\" fill=\"#d4a8e0\"/>").Str));
}, 1, "", true));
return ((V)(o_3369.Str));
return default;
}, 0, "chive", true)).Put("thyme", Fn((V _arrowThis3392, int _argc3386, V _a3388, V _a3389, V _a3390, V _a3391, V[] _rest3387) => {
V Q_3393 = default;
JsStrBuf o_3394 = null;
Q_3393 = Call(rng_13, V.Undef, ((V)("thy")));
o_3394 = new JsStrBuf("");
{
double i_3395 = 0;
i_3395 = 0D;
while (true) {
if (!((i_3395 < 46D))) break;
double a_3397 = 0;
double d_3398 = 0;
a_3397 = (PI_11 * (0.08 + (0.84 * ToNum(Call(Q_3393, V.Undef)))));
d_3398 = (System.Math.Sqrt(ToNum(Call(Q_3393, V.Undef))) * 4.6);
o_3394.S("<circle cx=\"").V(Call(f1_16, V.Undef, ((V)((((-FdLibm.Cos(a_3397)) * d_3398) * 1.2))))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)(((-FdLibm.Sin(a_3397)) * d_3398))))).S("\" r=\"").V(Call(f1_16, V.Undef, ((V)((0.42 + (ToNum(Call(Q_3393, V.Undef)) * 0.3)))))).S("\" fill=\"").S((LtN(Call(Q_3393, V.Undef), 0.5) ? "#6f8f4a" : "#8aa65a")).S("\"/>");
i_3395++;
}
}
{
double i_3399 = 0;
i_3399 = 0D;
while (true) {
if (!((i_3399 < 6D))) break;
o_3394.S("<circle cx=\"").V(Call(f1_16, V.Undef, ((V)(((ToNum(Call(Q_3393, V.Undef)) - 0.5) * 8D))))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)(((-2.5) - (ToNum(Call(Q_3393, V.Undef)) * 2.4)))))).S("\" r=\"0.35\" fill=\"#e2b8d8\"/>");
i_3399++;
}
}
return ((V)(o_3394.Str));
return default;
}, 0, "thyme", true)).Put("mint", Fn((V _arrowThis3407, int _argc3401, V _a3403, V _a3404, V _a3405, V _a3406, V[] _rest3402) => {
JsStrBuf o_3408 = null;
o_3408 = new JsStrBuf("");
Invoke(Arr(Arr(((V)((-2.6))), ((V)((-2.6))), ((V)((-45D)))), Arr(((V)(2.6)), ((V)((-2.8))), ((V)(45D))), Arr(((V)((-1.4))), ((V)((-6.2))), ((V)((-20D)))), Arr(((V)(1.6)), ((V)((-6.6))), ((V)(22D))), Arr(((V)(0D)), ((V)((-9.4))), ((V)(0D))), Arr(((V)((-3.4))), ((V)((-5D))), ((V)((-55D))))), "forEach", Fn((V _arrowThis3422, int _argc3409, V _a3411, V _a3412, V _a3413, V _a3414, V[] _rest3410) => {
V x_3417 = default;
V y_3419 = default;
V a_3421 = default;
{ V _t3415 = ListOf(_a3411);
{ V _t3416 = GetIdx(_t3415, 0D);
x_3417 = _t3416; }
{ V _t3418 = GetIdx(_t3415, 1D);
y_3419 = _t3418; }
{ V _t3420 = GetIdx(_t3415, 2D);
a_3421 = _t3420; }
}
return ((V)(o_3408.S("<path d=\"M0 0L").V(Call(f1_16, V.Undef, ((V)((ToNum(x_3417) * 0.7))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(y_3419) * 0.8))))).S("\" stroke=\"#5a8a3a\" stroke-width=\"0.35\"/><g transform=\"translate(").V(x_3417).S(" ").V(y_3419).S(") rotate(").V(a_3421).S(")\"><ellipse rx=\"1.8\" ry=\"2.4\" fill=\"#72c46a\"/><ellipse rx=\"1.8\" ry=\"2.4\" fill=\"none\" stroke=\"#a8e0a0\" stroke-width=\"0.25\" stroke-dasharray=\"0.5 0.4\"/><path d=\"M0 2.2V-2.2M0 -0.4l-1 -0.8M0 0.6l1 -0.8\" stroke=\"#4a8a40\" stroke-width=\"0.16\"/></g>").Str));
}, 1, "", true));
return ((V)(o_3408.Str));
return default;
}, 0, "mint", true)).Put("pars", Fn((V _arrowThis3429, int _argc3423, V _a3425, V _a3426, V _a3427, V _a3428, V[] _rest3424) => {
JsStrBuf o_3430 = null;
o_3430 = new JsStrBuf("");
Invoke(Arr(Arr(((V)((-3D))), ((V)((-6D)))), Arr(((V)((-1.2))), ((V)((-8.6)))), Arr(((V)(1D)), ((V)((-9D)))), Arr(((V)(3D)), ((V)((-6.4)))), Arr(((V)(0D)), ((V)((-5D))))), "forEach", Fn((V _arrowThis3443, int _argc3431, V _a3433, V i_3437, V _a3435, V _a3436, V[] _rest3432) => {
V x_3440 = default;
V y_3442 = default;
{ V _t3438 = ListOf(_a3433);
{ V _t3439 = GetIdx(_t3438, 0D);
x_3440 = _t3439; }
{ V _t3441 = GetIdx(_t3438, 1D);
y_3442 = _t3441; }
}
o_3430.S("<path d=\"M0 0Q").V(Call(f1_16, V.Undef, ((V)((ToNum(x_3440) * 0.4))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(y_3442) * 0.5))))).S(" ").V(x_3440).S(" ").V(y_3442).S("\" stroke=\"#4e8a36\" stroke-width=\"0.3\" fill=\"none\"/>");
Invoke(Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)((-1D))), ((V)(0.5))), Arr(((V)(1D)), ((V)(0.4))), Arr(((V)((-0.5))), ((V)((-0.9)))), Arr(((V)(0.6)), ((V)((-0.8)))), Arr(((V)(0D)), ((V)(1D)))), "forEach", Fn((V _arrowThis3455, int _argc3444, V _a3446, V _a3447, V _a3448, V _a3449, V[] _rest3445) => {
V dx_3452 = default;
V dy_3454 = default;
{ V _t3450 = ListOf(_a3446);
{ V _t3451 = GetIdx(_t3450, 0D);
dx_3452 = _t3451; }
{ V _t3453 = GetIdx(_t3450, 1D);
dy_3454 = _t3453; }
}
return ((V)(o_3430.S("<circle cx=\"").V(Call(f1_16, V.Undef, Add(x_3440, ((V)((ToNum(dx_3452) * 1.2)))))).S("\" cy=\"").V(Call(f1_16, V.Undef, Add(y_3442, ((V)((ToNum(dy_3454) * 1.1)))))).S("\" r=\"0.85\" fill=\"").S((NumTruthy((ToNum(i_3437) % 2D)) ? "#3f8f3a" : "#4a9c42")).S("\"/>").Str));
}, 1, "", true));
o_3430.S("<circle cx=\"").N((ToNum(x_3440) - 0.4)).S("\" cy=\"").N((ToNum(y_3442) - 0.6)).S("\" r=\"0.4\" fill=\"#8fcf70\" opacity=\"0.6\"/>");
return default;
}, 2, "", true));
return ((V)(o_3430.Str));
return default;
}, 0, "pars", true)).V;
herb_3174 = Fn((V _arrowThis3467, int _argc3456, V k_3462, V x_3463, V y_3464, V sc_3465, V[] _rest3457) => {
V ph_3466 = default;
ph_3466 = (_argc3456 > 4 ? _rest3457[0] : V.Undef);
return Call(sway_3169, V.Undef, x_3463, y_3464, sc_3465, ((V)((2.2 + (ToNum(ph_3466) % 1.3)))), ((V)((4.2 + (ToNum(ph_3466) * 0.7)))), ph_3466, InvokeK(HB_3173, k_3462));
}, 5, "", true);
Set(WIN_3161, "khop", Fn((V _arrowThis3474, int _argc3468, V _a3470, V _a3471, V _a3472, V _a3473, V[] _rest3469) => {
V FC_3475 = default;
V R_3476 = default;
double GX_3477 = 0;
double GY0_3478 = 0;
double GY1_3479 = 0;
JsStrBuf s_3480 = null;
JsStrBuf sc_3481 = null;
FC_3475 = ((V)("#7a8270"));
R_3476 = Call(rng_13, V.Undef, ((V)("khop")));
GX_3477 = 25.6;
GY0_3478 = (-27.6);
GY1_3479 = (-8.4);
s_3480 = new JsStrBuf(JsStrBuf.Begin().S("<defs>").V(WDEF_3162).S("<linearGradient id=\"k\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#c3ccce\"/><stop offset=\"1\" stop-color=\"#e4e6da\"/></linearGradient><linearGradient id=\"gr\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#8a8468\" stop-opacity=\"0.05\"/><stop offset=\"1\" stop-color=\"#6a6248\" stop-opacity=\"0.4\"/></linearGradient>").S("<pattern id=\"ms\" width=\"0.7\" height=\"0.7\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 0.35H0.7M0.35 0V0.7\" stroke=\"#5a4030\" stroke-width=\"0.1\" stroke-opacity=\"0.55\"/></pattern><clipPath id=\"gc\"><rect x=\"").N((-GX_3477)).S("\" y=\"").N(GY0_3478).S("\" width=\"").N((2D * GX_3477)).S("\" height=\"").N((GY1_3479 - GY0_3478)).S("\"/></clipPath><clipPath id=\"sc\"><path d=\"M-25.6 -27.6H18L25.6 -21V-8.4H-25.6Z\"/></clipPath></defs>").End());
s_3480.S("<g filter=\"url(#b2)\"><path d=\"M-22 -2Q-21 3 -22.6 7M-8 -2Q-7.4 2 -8.6 5M14 -2Q15 4 13.6 8M26 -2Q26.6 1 25.8 4\" stroke=\"#9a5a2a\" stroke-width=\"1.6\" fill=\"none\" opacity=\"0.45\"/></g><path d=\"M-22 -2Q-21 3 -22.6 7M14 -2Q15 4 13.6 8\" stroke=\"#7a3e18\" stroke-width=\"0.4\" fill=\"none\" opacity=\"0.5\"/>");
s_3480.S("<rect x=\"-34\" y=\"-36\" width=\"68\" height=\"36\" fill=\"#000000\" opacity=\"0.2\" filter=\"url(#b2)\"/>").V(Call(ring_3164, V.Undef, ((V)((-33D))), ((V)((-35D))), ((V)(33D)), ((V)((-1.6))), ((V)(3.4)), FC_3475, ((V)(0.8)))).V(Call(reveal_3165, V.Undef, ((V)((-29.6))), ((V)((-31.6))), ((V)(29.6)), ((V)((-5D))), ((V)(3.4)), ((V)("#a19b90"))));
sc_3481 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-27\" y=\"-29\" width=\"54\" height=\"22\" fill=\"url(#k)\"/>").V(Call(drift_3168, V.Undef, Add(Call(cloud_3167, V.Undef, ((V)((-14D))), ((V)((-25D))), ((V)(0.7)), ((V)("#eef0ee"))), Call(cloud_3167, V.Undef, ((V)(12D)), ((V)((-26.4))), ((V)(0.5)), ((V)("#e8ebea")))), ((V)(54D)), ((V)(52D)))).End());
sc_3481.S("<path d=\"M-27 -17Q-14 -18.4 0 -17.2T27 -17.6V-7H-27Z\" fill=\"#5a4632\"/><path d=\"M-27 -14Q-10 -15 4 -14.2T27 -14.6V-7H-27Z\" fill=\"#4a3826\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis3488, int _argc3482, V _a3484, V _a3485, V _a3486, V _a3487, V[] _rest3483) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_16, V.Undef, ((V)(((-27D) + (ToNum(Call(R_3476, V.Undef)) * 54D)))))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)(((-14D) + (ToNum(Call(R_3476, V.Undef)) * 6D)))))).S("\" r=\"").V(Call(f1_16, V.Undef, ((V)((0.3 + (ToNum(Call(R_3476, V.Undef)) * 0.5)))))).S("\" fill=\"").S((LtN(Call(R_3476, V.Undef), 0.5) ? "#6e5a44" : "#3a2c1e")).S("\"/>").End()));
}, 0, "", true)), "join", ((V)(""))));
sc_3481.S("<g>").V(Call(at_47, V.Undef, ((V)("translate")), ((V)("-40 0;-40 0;40 0;40 0")), ((V)(26D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.35;0.85;1\"")))).S("<g transform=\"translate(0 -17.2)\"><path d=\"M0 0l-0.4 1.4M1 0l0.4 1.4\" stroke=\"#d07a7a\" stroke-width=\"0.3\"/><ellipse cy=\"-1.6\" rx=\"2.6\" ry=\"1.7\" fill=\"#8a8e98\"/><path d=\"M-2.4 -1.8L-4.4 -1.2L-2.2 -0.6Z\" fill=\"#5a5e68\"/><path d=\"M-1.2 -2.2Q0 -2.8 1.2 -2\" stroke=\"#6a6e78\" stroke-width=\"0.5\" fill=\"none\"/>").S("<g>").V(Call(at_47, V.Undef, ((V)("translate")), ((V)("0 0;0.6 0.5;0 0")), ((V)(0.6)))).S("<path d=\"M1.4 -2.4Q2.2 -3.4 2.4 -4\" stroke=\"#5a8a7a\" stroke-width=\"1.1\" fill=\"none\"/><circle cx=\"2.6\" cy=\"-4.4\" r=\"0.95\" fill=\"#7a7e88\"/><circle cx=\"2.9\" cy=\"-4.6\" r=\"0.2\" fill=\"#e88a30\"/><path d=\"M3.4 -4.3l0.7 0.2l-0.7 0.2Z\" fill=\"#3a3a3a\"/></g></g></g>");
sc_3481.S("<g>").V(Call(at_47, V.Undef, ((V)("translate")), ((V)("-20 0;20 0")), ((V)(70D)))).S("<g transform=\"translate(0 -16.6)\"><path d=\"M-1.4 0H1.6Q2.2 -0.6 2 -1\" stroke=\"#a89a7a\" stroke-width=\"0.6\" fill=\"none\" stroke-linecap=\"round\"/><circle cx=\"-0.2\" cy=\"-0.9\" r=\"1\" fill=\"#9a6a3a\"/><path d=\"M-0.2 -0.9m-0.5 0a0.5 0.5 0 1 1 0.7 0.3\" stroke=\"#6a4420\" stroke-width=\"0.2\" fill=\"none\"/><path d=\"M1.9 -1l0.4 -0.7M2.1 -0.9l0.6 -0.4\" stroke=\"#a89a7a\" stroke-width=\"0.12\"/></g></g>");
{
double i_3489 = 0;
i_3489 = 0D;
while (true) {
if (!((i_3489 < 26D))) break;
V x_3491 = default;
double h_3492 = 0;
double b_3493 = 0;
x_3491 = Add(((V)(((-26D) + (i_3489 * 2.05)))), Call(R_3476, V.Undef));
h_3492 = (2.5 + (ToNum(Call(R_3476, V.Undef)) * 5.5));
b_3493 = ((ToNum(Call(R_3476, V.Undef)) - 0.5) * 2D);
sc_3481.V(Call(sway_3169, V.Undef, x_3491, ((V)(((-16.4) + (ToNum(Call(R_3476, V.Undef)) * 0.8)))), ((V)(1D)), ((V)((4D + (ToNum(Call(R_3476, V.Undef)) * 3D)))), ((V)((2.6 + (ToNum(Call(R_3476, V.Undef)) * 2D)))), ((V)((ToNum(Call(R_3476, V.Undef)) * 3D))), ((V)(JsStrBuf.Begin().S("<path d=\"M-0.35 0Q").V(Call(f1_16, V.Undef, ((V)((b_3493 * 0.5))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((-h_3492) * 0.6))))).S(" ").V(Call(f1_16, V.Undef, ((V)(b_3493)))).S(" ").V(Call(f1_16, V.Undef, ((V)((-h_3492))))).S("Q").V(Call(f1_16, V.Undef, ((V)(((b_3493 * 0.4) + 0.3))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((-h_3492) * 0.5))))).S(" 0.35 0Z\" fill=\"").S((NumTruthy((i_3489 % 3D)) ? "#6e9a48" : "#5a8a3a")).S("\"/>").End()))));
i_3489++;
}
}
sc_3481.V(Call(sway_3169, V.Undef, ((V)((-9D))), ((V)((-16D))), ((V)(1D)), ((V)(5D)), ((V)(3.4)), ((V)(0.4)), ((V)(JsStrBuf.Begin().S("<path d=\"M0 0Q0.6 -4 0.2 -8\" stroke=\"#7a9a4a\" stroke-width=\"0.3\" fill=\"none\"/><circle cx=\"0.2\" cy=\"-8.6\" r=\"1.9\" fill=\"#ffffff\" opacity=\"0.55\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(12D)), Fn((V _arrowThis3501, int _argc3494, V i_3500, V _a3497, V _a3498, V _a3499, V[] _rest3495) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M0.2 -8.6l").V(Call(f1_16, V.Undef, ((V)((1.8 * FdLibm.Cos(((ToNum(i_3500) * PI_11) / 6D))))))).S(" ").V(Call(f1_16, V.Undef, ((V)((1.8 * FdLibm.Sin(((ToNum(i_3500) * PI_11) / 6D))))))).S("\" stroke=\"#ffffff\" stroke-width=\"0.1\" opacity=\"0.8\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<circle cx=\"0.2\" cy=\"-8.6\" r=\"0.4\" fill=\"#b8a878\"/>").End()))));
sc_3481.V(Call(sway_3169, V.Undef, ((V)(17D)), ((V)((-16.2))), ((V)(1D)), ((V)(3D)), ((V)(4D)), ((V)(1D)), ((V)(JsStrBuf.Begin().S("<path d=\"M0 0V-4.6\" stroke=\"#6a8a3a\" stroke-width=\"0.3\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis3509, int _argc3502, V i_3508, V _a3505, V _a3506, V _a3507, V[] _rest3503) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_16, V.Undef, ((V)((0.9 * FdLibm.Cos(((ToNum(i_3508) * PI_11) / 5D))))))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)(((-5.2) + (0.9 * FdLibm.Sin(((ToNum(i_3508) * PI_11) / 5D)))))))).S("\" rx=\"0.55\" ry=\"0.3\" transform=\"rotate(").N((ToNum(i_3508) * 36D)).S(" ").V(Call(f1_16, V.Undef, ((V)((0.9 * FdLibm.Cos(((ToNum(i_3508) * PI_11) / 5D))))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((-5.2) + (0.9 * FdLibm.Sin(((ToNum(i_3508) * PI_11) / 5D)))))))).S(")\" fill=\"#f2c83a\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<circle cy=\"-5.2\" r=\"0.55\" fill=\"#d89a2a\"/>").End()))));
sc_3481.S("<g clip-path=\"url(#sc)\"><rect x=\"-26\" y=\"-28\" width=\"52\" height=\"20\" fill=\"url(#ms)\"/><rect x=\"-26\" y=\"-28\" width=\"52\" height=\"20\" fill=\"#6a4a30\" opacity=\"0.1\"/>").V(Call(lblotW_3175, V.Undef, R_3476)).S("</g><path d=\"M18 -27.6L25.6 -21L21.8 -22.4Q19.6 -25 18 -27.6Z\" fill=\"url(#ms)\" stroke=\"#6a4a30\" stroke-width=\"0.12\"/><path d=\"M18 -27.6L25.6 -21\" stroke=\"#5a4030\" stroke-width=\"0.12\" stroke-dasharray=\"0.3 0.25\"/>");
s_3480.S("<g clip-path=\"url(#gc)\">").S(sc_3481.Str).S("<rect x=\"-27\" y=\"-29\" width=\"54\" height=\"22\" fill=\"url(#gr)\"/><rect x=\"-27\" y=\"-29\" width=\"54\" height=\"22\" fill=\"#a49c7c\" opacity=\"0.14\"/>").V(Call(glassRef_3171, V.Undef, ((V)((-25.6))), ((V)((-27.6))), ((V)(51.2)), ((V)(19.2)))).V(Invoke(Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis3516, int _argc3510, V _a3512, V _a3513, V _a3514, V _a3515, V[] _rest3511) => {
double x_3517 = 0;
x_3517 = ((-24D) + (ToNum(Call(R_3476, V.Undef)) * 48D));
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)(x_3517)))).S(" -27.4Q").V(Call(f1_16, V.Undef, ((V)((x_3517 + 0.3))))).S(" -20 ").V(Call(f1_16, V.Undef, ((V)((x_3517 - 0.2))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((-14D) + (ToNum(Call(R_3476, V.Undef)) * 5D)))))).S("\" stroke=\"#8a7e5a\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.3 + (ToNum(Call(R_3476, V.Undef)) * 0.4)))))).S("\" fill=\"none\" opacity=\"0.18\"/>").End()));
return default;
}, 0, "", true)), "join", ((V)("")))).S("</g>");
s_3480.S("<rect x=\"-25.6\" y=\"-27.6\" width=\"51.2\" height=\"1.4\" fill=\"#2a2a24\" opacity=\"0.5\"/>").V(Call(ring_3164, V.Undef, ((V)((-26.2))), ((V)((-26.4))), ((V)(26.2)), ((V)((-8D))), ((V)(1.9)), Call(shade_10, V.Undef, FC_3475, ((V)(0.95))), ((V)(0.5)))).V(Call(bev_3163, V.Undef, ((V)((-26.6))), ((V)((-27.4))), ((V)(53.2)), ((V)(2.4)), Call(shade_10, V.Undef, FC_3475, ((V)(1.05))), ((V)(0.5))));
Invoke(Arr(((V)((-24.4))), ((V)(24.4))), "forEach", Fn((V _arrowThis3525, int _argc3518, V x_3524, V _a3521, V _a3522, V _a3523, V[] _rest3519) => {
return ((V)(s_3480.S("<path d=\"M").V(x_3524).S(" -26L").V(Call(f1_16, V.Undef, ((V)((ToNum(x_3524) * 1.06))))).S(" -29.2\" stroke=\"#4a4a44\" stroke-width=\"0.55\"/><circle cx=\"").V(x_3524).S("\" cy=\"-26\" r=\"0.4\" fill=\"#3a3a34\"/>").Str));
}, 1, "", true));
s_3480.S("<g transform=\"translate(0 -26.2)\"><rect x=\"-2.4\" y=\"-0.8\" width=\"4.8\" height=\"1.6\" rx=\"0.4\" fill=\"#8a7a5a\"/><path d=\"M-1.6 0.8Q0 2.4 1.6 0.8\" stroke=\"#6a5a3a\" stroke-width=\"0.6\" fill=\"none\"/><circle r=\"0.35\" fill=\"#4a3a20\"/></g>");
s_3480.V(Invoke(Call(rep_18, V.Undef, ((V)(18D)), Fn((V _arrowThis3532, int _argc3526, V _a3528, V _a3529, V _a3530, V _a3531, V[] _rest3527) => {
V side_3533 = default;
double x_3534 = 0;
double y_3535 = 0;
side_3533 = Call(R_3476, V.Undef);
x_3534 = (LtN(side_3533, 0.5) ? ((-33D) + (ToNum(Call(R_3476, V.Undef)) * 66D)) : (LtN(Call(R_3476, V.Undef), 0.5) ? ((-32.4) + (ToNum(Call(R_3476, V.Undef)) * 2.4)) : (30D + (ToNum(Call(R_3476, V.Undef)) * 2.4))));
y_3535 = (LtN(side_3533, 0.5) ? (LtN(Call(R_3476, V.Undef), 0.5) ? ((-34.6) + (ToNum(Call(R_3476, V.Undef)) * 2.6)) : ((-4.6) + (ToNum(Call(R_3476, V.Undef)) * 2.6))) : ((-32D) + (ToNum(Call(R_3476, V.Undef)) * 28D)));
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)(x_3534)))).S(" ").V(Call(f1_16, V.Undef, ((V)(y_3535)))).S("l").V(Call(f1_16, V.Undef, ((V)((0.5 + (ToNum(Call(R_3476, V.Undef)) * 0.8)))))).S(" 0.2l-0.2 ").V(Call(f1_16, V.Undef, ((V)((0.5 + (ToNum(Call(R_3476, V.Undef)) * 0.5)))))).S("l").V(Call(f1_16, V.Undef, ((V)(((-0.6) - (ToNum(Call(R_3476, V.Undef)) * 0.8)))))).S(" -0.2Z\" fill=\"").S((LtN(Call(R_3476, V.Undef), 0.5) ? "#8a5a32" : "#9a948a")).S("\" opacity=\"0.85\"/>").End()));
return default;
}, 0, "", true)), "join", ((V)(""))));
s_3480.S("<path d=\"M-29.4 -31.4L-22 -31.4M-29.4 -31.4L-29.4 -24.6M-29.4 -31.4L-23.4 -26.2M-27 -31.4Q-27.4 -29 -29.4 -28.6M-24.6 -31.4Q-25.6 -27.6 -29.4 -26.6\" stroke=\"#ffffff\" stroke-width=\"0.1\" fill=\"none\" opacity=\"0.6\"/>");
s_3480.V(Call(sill_3166, V.Undef, ((V)((-35D))), ((V)(35D)), ((V)((-1.6))), ((V)("#aaa49a")), ((V)(1.2)))).S("<g transform=\"translate(8 -2)\"><ellipse rx=\"0.7\" ry=\"0.35\" fill=\"#2a2a26\"/><path d=\"M-0.2 -0.2l-0.8 -0.6M0.2 -0.2l0.8 -0.6\" stroke=\"#b8c4c8\" stroke-width=\"0.35\" opacity=\"0.7\"/></g>");
return NewObj(2).Put("vb", Arr(((V)((-36D))), ((V)((-38D))), ((V)(72D)), ((V)(44D)))).Put("s", ((V)(s_3480.Str))).V;
return default;
}, 0, "", true));
Set(WIN_3161, "kging", Fn((V _arrowThis3542, int _argc3536, V _a3538, V _a3539, V _a3540, V _a3541, V[] _rest3537) => {
V FC_3543 = default;
V R_3544 = default;
JsStrBuf s_3545 = null;
JsStrBuf sc_3546 = null;
V PEG_3547 = default;
JsStrBuf val_3548 = null;
V cur_3549 = default;
FC_3543 = ((V)("#fbf8f1"));
R_3544 = Call(rng_13, V.Undef, ((V)("kgn")));
s_3545 = new JsStrBuf(JsStrBuf.Begin().S("<defs>").V(WDEF_3162).S("<linearGradient id=\"k\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#7fbbe8\"/><stop offset=\"1\" stop-color=\"#d6eefa\"/></linearGradient><radialGradient id=\"sun\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff8d0\"/><stop offset=\"0.35\" stop-color=\"#fff0a0\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#fff0a0\" stop-opacity=\"0\"/></radialGradient>").S("<pattern id=\"gh\" width=\"2.4\" height=\"2.4\" patternUnits=\"userSpaceOnUse\"><rect width=\"2.4\" height=\"2.4\" fill=\"#fbf6f0\"/><rect width=\"1.2\" height=\"2.4\" fill=\"#d83a3a\" opacity=\"0.5\"/><rect width=\"2.4\" height=\"1.2\" fill=\"#d83a3a\" opacity=\"0.5\"/></pattern>").S("<pattern id=\"fo\" width=\"5\" height=\"40\" patternUnits=\"userSpaceOnUse\"><rect width=\"5\" height=\"40\" fill=\"url(#fg)\"/></pattern><linearGradient id=\"fg\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#000000\" stop-opacity=\"0.2\"/><stop offset=\"0.35\" stop-color=\"#ffffff\" stop-opacity=\"0.16\"/><stop offset=\"0.6\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.22\"/></linearGradient>").S("<linearGradient id=\"br\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff0b8\"/><stop offset=\"0.5\" stop-color=\"#d8a848\"/><stop offset=\"1\" stop-color=\"#8a6420\"/></linearGradient><clipPath id=\"gc\"><rect x=\"-36.6\" y=\"-4.6\" width=\"73.2\" height=\"62.6\"/></clipPath></defs>").End());
s_3545.S("<rect x=\"-42\" y=\"-11\" width=\"88\" height=\"80\" fill=\"#000000\" opacity=\"0.18\" filter=\"url(#b2)\"/>").V(Call(ring_3164, V.Undef, ((V)((-43D))), ((V)((-11D))), ((V)(43D)), ((V)(63D)), ((V)(5D)), FC_3543, ((V)(1.2)))).V(Call(bev_3163, V.Undef, ((V)((-46D))), ((V)((-15D))), ((V)(92D)), ((V)(4.6)), FC_3543, ((V)(0.8)))).V(Call(reveal_3165, V.Undef, ((V)((-38D))), ((V)((-6D))), ((V)(38D)), ((V)(63D)), ((V)(1.4)), ((V)("#e3ddd0"))));
sc_3546 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-37\" y=\"-5\" width=\"74\" height=\"64\" fill=\"url(#k)\"/><circle cx=\"-22\" cy=\"2\" r=\"14\" fill=\"url(#sun)\"/><circle cx=\"-22\" cy=\"2\" r=\"3.8\" fill=\"#fff6c8\"/>").V(Call(drift_3168, V.Undef, Add(Call(cloud_3167, V.Undef, ((V)((-6D))), ((V)(8D)), ((V)(0.9)), ((V)("#ffffff"))), Call(cloud_3167, V.Undef, ((V)(24D)), ((V)(3D)), ((V)(0.7)), ((V)("#ffffff")))), ((V)(74D)), ((V)(60D)))).End());
sc_3546.S("<path d=\"M-37 34Q-16 28 2 33T37 30V59H-37Z\" fill=\"#a6d0a0\"/><path d=\"M-37 42Q-8 37 14 42T37 40V59H-37Z\" fill=\"#86b77e\"/>");
sc_3546.V(Invoke(Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis3557, int _argc3550, V i_3556, V _a3553, V _a3554, V _a3555, V[] _rest3551) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").N(((-36D) + (ToNum(i_3556) * 7.6))).S("\" y=\"35\" width=\"2.2\" height=\"11\" fill=\"#f6f2e8\"/><path d=\"M").N(((-36D) + (ToNum(i_3556) * 7.6))).S(" 35l1.1 -1.4l1.1 1.4\" fill=\"#f6f2e8\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<rect x=\"-37\" y=\"38\" width=\"74\" height=\"1.2\" fill=\"#eeeae0\"/><rect x=\"-37\" y=\"43\" width=\"74\" height=\"1.2\" fill=\"#eeeae0\"/>");
sc_3546.V(Call(tree_3170, V.Undef, ((V)(27D)), ((V)(42D)), ((V)(2D)), ((V)("#5f9a4e")), ((V)(0.6))));
sc_3546.S("<g transform=\"translate(20 14)\"><g>").V(Call(at_47, V.Undef, ((V)("rotate")), ((V)("-6 0 0;6 0 0;-6 0 0")), ((V)(3.6)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))).S("<path d=\"M0 0V5\" stroke=\"#6a5a40\" stroke-width=\"0.2\"/><path d=\"M-2.6 6.4L0 4.6L2.6 6.4Z\" fill=\"#b8542e\"/><rect x=\"-1.8\" y=\"6.4\" width=\"3.6\" height=\"3.2\" fill=\"#e8d8a8\" opacity=\"0.9\"/><rect x=\"-1.8\" y=\"8.4\" width=\"3.6\" height=\"1.2\" fill=\"#c8a058\"/><rect x=\"-2.4\" y=\"9.6\" width=\"4.8\" height=\"0.6\" fill=\"#8a5a30\"/>").S("<g opacity=\"0\">").V(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0;0;1;1;0;0")), ((V)(14D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.4;0.45;0.75;0.8;1\"")))).S("<g transform=\"translate(-2.6 9.4)\"><ellipse cy=\"-1\" rx=\"1.3\" ry=\"0.9\" fill=\"#3a6ab8\"/><circle cx=\"-0.8\" cy=\"-1.8\" r=\"0.65\" fill=\"#3a6ab8\"/><ellipse cx=\"-0.2\" cy=\"-0.7\" rx=\"0.8\" ry=\"0.5\" fill=\"#f2e8d8\"/><path d=\"M-1.4 -1.8l-0.6 0.2l0.6 0.2Z\" fill=\"#2a2a2a\"/><path d=\"M1 -1l1.4 0.6\" stroke=\"#2a4a88\" stroke-width=\"0.5\"/></g></g></g></g>");
sc_3546.S("<path d=\"M-34 10V34M-34 10H-31\" stroke=\"#8a7a62\" stroke-width=\"0.8\"/><path d=\"M-32 11Q-12 17 10 12\" stroke=\"#ece6da\" stroke-width=\"0.18\" fill=\"none\"/>");
PEG_3547 = Fn((V _arrowThis3566, int _argc3558, V x_3564, V y_3565, V _a3562, V _a3563, V[] _rest3559) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(x_3564) - 0.25))))).S("\" y=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(y_3565) - 0.6))))).S("\" width=\"0.5\" height=\"1.4\" fill=\"#c49a5a\"/>").End()));
}, 2, "", true);
Invoke(Arr(Arr(((V)((-26D))), ((V)(12.6)), ((V)("shirt"))), Arr(((V)((-16D))), ((V)(14.2)), ((V)("sock"))), Arr(((V)((-12D))), ((V)(14.6)), ((V)("sock"))), Arr(((V)((-4D))), ((V)(14.4)), ((V)("towel")))), "forEach", Fn((V _arrowThis3581, int _argc3567, V _a3569, V i_3573, V _a3571, V _a3572, V[] _rest3568) => {
V p_3582 = default;
V x_3576 = default;
V y_3578 = default;
V k_3580 = default;
{ V _t3574 = ListOf(_a3569);
{ V _t3575 = GetIdx(_t3574, 0D);
x_3576 = _t3575; }
{ V _t3577 = GetIdx(_t3574, 1D);
y_3578 = _t3577; }
{ V _t3579 = GetIdx(_t3574, 2D);
k_3580 = _t3579; }
}
p_3582 = V.Undef;
if (SEqS(k_3580, "shirt")) {
p_3582 = ((V)("<path d=\"M-3 0L-5 1.6L-4 3.2L-2.6 2.6V8H2.6V2.6L4 3.2L5 1.6L3 0Q0 1.4 -3 0Z\" fill=\"#f2c14a\"/><path d=\"M-1 0.6Q0 1.6 1 0.6\" stroke=\"#d8a030\" stroke-width=\"0.2\" fill=\"none\"/><path d=\"M-2.6 5H2.6\" stroke=\"#e8b038\" stroke-width=\"0.3\" opacity=\"0.6\"/>"));
} else {
if (SEqS(k_3580, "sock")) {
p_3582 = ((V)(string.Concat("<path d=\"M-0.8 0H0.8V3.8Q0.8 5 2.2 5.2V6.4Q-0.8 6.6 -0.8 4.4Z\" fill=\"", (SEqN(i_3573, 1D) ? "#e86a6a" : "#6aa8e8"), "\"/><rect x=\"-0.8\" width=\"1.6\" height=\"0.8\" fill=\"#ffffff\" opacity=\"0.6\"/>")));
} else {
p_3582 = ((V)("<rect x=\"-3.2\" width=\"6.4\" height=\"8.4\" fill=\"#8cc8c0\"/><rect x=\"-3.2\" y=\"6.6\" width=\"6.4\" height=\"0.8\" fill=\"#ffffff\" opacity=\"0.7\"/><rect x=\"-3.2\" y=\"7.6\" width=\"6.4\" height=\"0.3\" fill=\"#ffffff\" opacity=\"0.7\"/>"));
}
}
sc_3546.S("<g transform=\"translate(").V(x_3576).S(" ").V(y_3578).S(")\"><g>").V(Call(at_47, V.Undef, ((V)("rotate")), ((V)("-5 0 0;6 0 0;-5 0 0")), ((V)((3D + (ToNum(i_3573) * 0.4)))), ((V)(((-ToNum(i_3573)) * 0.7))), Call(SPL_15, V.Undef, ((V)(2D))))).V(p_3582).S("</g>").V(Call(PEG_3547, V.Undef, ((V)((-0.6))), ((V)(0D)))).S("</g>");
return default;
}, 2, "", true));
s_3545.S("<g clip-path=\"url(#gc)\">").S(sc_3546.Str).V(Call(glassRef_3171, V.Undef, ((V)((-37D))), ((V)((-5D))), ((V)(74D)), ((V)(64D)))).S("</g>");
s_3545.V(Add(Add(Add(Call(ring_3164, V.Undef, ((V)((-36.6))), ((V)((-4.6))), ((V)(36.6)), ((V)(27.4)), ((V)(2.8)), FC_3543, ((V)(0.7))), Call(bev_3163, V.Undef, ((V)((-1D))), ((V)((-1.8))), ((V)(2D)), ((V)(26.4)), FC_3543, ((V)(0.4)))), Call(ring_3164, V.Undef, ((V)((-36.6))), ((V)(25D)), ((V)(36.6)), ((V)(58D)), ((V)(2.8)), FC_3543, ((V)(0.7)))), Call(bev_3163, V.Undef, ((V)((-36.6))), ((V)(24.6)), ((V)(73.2)), ((V)(3.4)), Call(shade_10, V.Undef, FC_3543, ((V)(0.98))), ((V)(0.6)))));
s_3545.S("<g transform=\"translate(0 26.2)\"><ellipse rx=\"3\" ry=\"1.1\" fill=\"#b8892e\"/><path d=\"M-2.2 -0.4Q0 -2.4 2.6 -1\" stroke=\"#e8c062\" stroke-width=\"0.8\" fill=\"none\" stroke-linecap=\"round\"/><circle cx=\"2.6\" cy=\"-1\" r=\"0.7\" fill=\"#f2d07a\"/></g>");
val_3548 = new JsStrBuf("<rect x=\"-40\" y=\"-8\" width=\"80\" height=\"9\" fill=\"url(#gh)\"/><rect x=\"-40\" y=\"-8\" width=\"80\" height=\"9\" fill=\"url(#fo)\"/>");
val_3548.S("<path d=\"M-40 1").V(Invoke(Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis3590, int _argc3583, V i_3589, V _a3586, V _a3587, V _a3588, V[] _rest3584) => {
return ((V)(JsStrBuf.Begin().S("Q").N(((-36D) + (ToNum(i_3589) * 8D))).S(" 4.6 ").N(((-32D) + (ToNum(i_3589) * 8D))).S(" 1").End()));
}, 1, "", true)), "join", ((V)("")))).S("V-8H-40Z\" fill=\"url(#gh)\"/><path d=\"M-40 1").V(Invoke(Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis3598, int _argc3591, V i_3597, V _a3594, V _a3595, V _a3596, V[] _rest3592) => {
return ((V)(JsStrBuf.Begin().S("Q").N(((-36D) + (ToNum(i_3597) * 8D))).S(" 4.6 ").N(((-32D) + (ToNum(i_3597) * 8D))).S(" 1").End()));
}, 1, "", true)), "join", ((V)("")))).S("V-8H-40Z\" fill=\"url(#fo)\"/><path d=\"M-40 1").V(Invoke(Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis3606, int _argc3599, V i_3605, V _a3602, V _a3603, V _a3604, V[] _rest3600) => {
return ((V)(JsStrBuf.Begin().S("Q").N(((-36D) + (ToNum(i_3605) * 8D))).S(" 4.6 ").N(((-32D) + (ToNum(i_3605) * 8D))).S(" 1").End()));
}, 1, "", true)), "join", ((V)("")))).S("\" stroke=\"#ffffff\" stroke-width=\"0.6\" fill=\"none\"/>");
s_3545.S("<rect x=\"-40\" y=\"1\" width=\"80\" height=\"3\" fill=\"#000000\" opacity=\"0.14\" filter=\"url(#b1)\"/>").S(val_3548.Str).S("<rect x=\"-41\" y=\"-8.6\" width=\"82\" height=\"1.2\" rx=\"0.6\" fill=\"url(#br)\"/>");
cur_3549 = Fn((V _arrowThis3616, int _argc3607, V x0_3613, V w_3614, V flip_3615, V _a3612, V[] _rest3608) => {
JsStrBuf o_3617 = null;
o_3617 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"").V(x0_3613).S("\" width=\"").V(w_3614).S("\" height=\"27\" fill=\"url(#gh)\"/><rect x=\"").V(x0_3613).S("\" width=\"").V(w_3614).S("\" height=\"27\" fill=\"url(#fo)\"/>").End());
o_3617.S("<path d=\"M").V(x0_3613).S(" 27").V(Invoke(Call(rep_18, V.Undef, ((V)(Round((ToNum(w_3614) / 5D)))), Fn((V _arrowThis3625, int _argc3618, V i_3624, V _a3621, V _a3622, V _a3623, V[] _rest3619) => {
return ((V)("q1.25 1 2.5 0t2.5 0"));
}, 1, "", true)), "join", ((V)("")))).S("V25H").V(x0_3613).S("Z\" fill=\"url(#gh)\"/><rect x=\"").V(x0_3613).S("\" y=\"25.4\" width=\"").V(w_3614).S("\" height=\"0.5\" fill=\"#ffffff\" opacity=\"0.7\"/>");
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(0 30)\"><g>").V(Call(at_47, V.Undef, ((V)("skewX")), ((V)(JsStrBuf.Begin().S("0;").N((Truthy(flip_3615) ? (-1.4) : 1.4)).S(";0;").N((Truthy(flip_3615) ? 0.8 : (-0.8))).S(";0").End())), ((V)((7D + (Truthy(flip_3615) ? 1.3 : 0D)))), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(4D))))).S(o_3617.Str).S("</g></g>").End()));
return default;
}, 3, "", true);
s_3545.S("<rect x=\"-38\" y=\"31\" width=\"76\" height=\"27\" fill=\"#000000\" opacity=\"0.1\" filter=\"url(#b1)\"/>").V(Call(cur_3549, V.Undef, ((V)((-37.5))), ((V)(36D)), ((V)(0D)))).V(Call(cur_3549, V.Undef, ((V)(1.5)), ((V)(36D)), ((V)(1D)))).S("<rect x=\"-39\" y=\"29.4\" width=\"78\" height=\"1.2\" rx=\"0.6\" fill=\"url(#br)\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(14D)), Fn((V _arrowThis3633, int _argc3626, V i_3632, V _a3629, V _a3630, V _a3631, V[] _rest3627) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_16, V.Undef, ((V)(((-36D) + (ToNum(i_3632) * 5.5)))))).S("\" cy=\"30\" r=\"0.8\" fill=\"none\" stroke=\"#c8983a\" stroke-width=\"0.35\"/>").End()));
}, 1, "", true)), "join", ((V)(""))));
s_3545.S("<path d=\"M-14 -0.4V7\" stroke=\"#e8e2d4\" stroke-width=\"0.12\"/><g transform=\"translate(-14 8.6)\"><g>").V(Call(at_47, V.Undef, ((V)("rotate")), ((V)("-10 0 -1.6;10 0 -1.6;-10 0 -1.6")), ((V)(4.4)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))).S("<path d=\"M0 -1.6L1.6 0L0 1.6L-1.6 0Z\" fill=\"#e8f4ff\" opacity=\"0.7\" stroke=\"#ffffff\" stroke-width=\"0.12\"/><path d=\"M0 -1.6L0.6 0L0 1.6\" fill=\"#b8d8ff\" opacity=\"0.5\"/></g></g>");
Invoke(Arr(Arr(((V)("#ff8a8a")), ((V)((-30D))), ((V)(61D))), Arr(((V)("#ffd27a")), ((V)((-27.6))), ((V)(61.6))), Arr(((V)("#9ae0a8")), ((V)((-25D))), ((V)(61.2))), Arr(((V)("#9ab8ff")), ((V)(30D)), ((V)(3D)))), "forEach", Fn((V _arrowThis3648, int _argc3634, V _a3636, V i_3640, V _a3638, V _a3639, V[] _rest3635) => {
V c_3643 = default;
V x_3645 = default;
V y_3647 = default;
{ V _t3641 = ListOf(_a3636);
{ V _t3642 = GetIdx(_t3641, 0D);
c_3643 = _t3642; }
{ V _t3644 = GetIdx(_t3641, 1D);
x_3645 = _t3644; }
{ V _t3646 = GetIdx(_t3641, 2D);
y_3647 = _t3646; }
}
return ((V)(s_3545.S("<ellipse cx=\"").V(x_3645).S("\" cy=\"").V(y_3647).S("\" rx=\"1\" ry=\"0.5\" fill=\"").V(c_3643).S("\" opacity=\"0.4\">").V(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.1;0.6;0.1")), ((V)(4.4)), ((V)((ToNum(i_3640) * 0.6))), Call(SPL_15, V.Undef, ((V)(2D))))).S("</ellipse>").Str));
}, 2, "", true));
s_3545.V(Add(Call(sill_3166, V.Undef, ((V)((-47D))), ((V)(47D)), ((V)(63D)), ((V)("#f1ece0")), ((V)(2D))), Call(bev_3163, V.Undef, ((V)((-39D))), ((V)(66D)), ((V)(78D)), ((V)(4D)), FC_3543, ((V)(0.7)))));
s_3545.V(Add(Call(pot_3172, V.Undef, ((V)(28D)), ((V)(58D)), ((V)(7D)), ((V)(5D)), ((V)("#c8744a"))), Call(sway_3169, V.Undef, ((V)(28D)), ((V)(57.4)), ((V)(1D)), ((V)(2D)), ((V)(5D)), ((V)(0.3)), ((V)(JsStrBuf.Begin().S("<path d=\"M0 0Q-2 -3 -3 -6M0 0Q1 -4 2.6 -7M0 0Q0 -3 -0.4 -4\" stroke=\"#5a7a3a\" stroke-width=\"0.35\" fill=\"none\"/>").V(Invoke(Invoke(Arr(Arr(((V)((-3.6))), ((V)((-1.6)))), Arr(((V)(3.2)), ((V)((-2D)))), Arr(((V)((-1D))), ((V)((-3D)))), Arr(((V)(1.8)), ((V)((-0.8))))), "map", Fn((V _arrowThis3660, int _argc3649, V _a3651, V _a3652, V _a3653, V _a3654, V[] _rest3650) => {
V x_3657 = default;
V y_3659 = default;
{ V _t3655 = ListOf(_a3651);
{ V _t3656 = GetIdx(_t3655, 0D);
x_3657 = _t3656; }
{ V _t3658 = GetIdx(_t3655, 1D);
y_3659 = _t3658; }
}
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(x_3657).S("\" cy=\"").V(y_3659).S("\" r=\"1.8\" fill=\"#5f9a46\"/><circle cx=\"").V(x_3657).S("\" cy=\"").V(y_3659).S("\" r=\"1\" fill=\"none\" stroke=\"#8a6a3a\" stroke-width=\"0.25\" opacity=\"0.5\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Invoke(Arr(Arr(((V)((-3D))), ((V)((-6.4)))), Arr(((V)(2.6)), ((V)((-7.4))))), "map", Fn((V _arrowThis3672, int _argc3661, V _a3663, V _a3664, V _a3665, V _a3666, V[] _rest3662) => {
V x_3669 = default;
V y_3671 = default;
{ V _t3667 = ListOf(_a3663);
{ V _t3668 = GetIdx(_t3667, 0D);
x_3669 = _t3668; }
{ V _t3670 = GetIdx(_t3667, 1D);
y_3671 = _t3670; }
}
return ((V)(JsStrBuf.Begin().V(Invoke(Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis3680, int _argc3673, V i_3679, V _a3676, V _a3677, V _a3678, V[] _rest3674) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_16, V.Undef, Add(x_3669, ((V)((1.2 * FdLibm.Cos((ToNum(i_3679) * 0.9)))))))).S("\" cy=\"").V(Call(f1_16, V.Undef, Add(y_3671, ((V)((1D * FdLibm.Sin((ToNum(i_3679) * 0.9)))))))).S("\" r=\"0.75\" fill=\"").S((NumTruthy((ToNum(i_3679) % 2D)) ? "#e8384a" : "#f0505e")).S("\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<circle cx=\"").N((ToNum(x_3669) - 0.3)).S("\" cy=\"").N((ToNum(y_3671) - 0.4)).S("\" r=\"0.4\" fill=\"#ff8a90\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).End())))));
return NewObj(2).Put("vb", Arr(((V)((-48D))), ((V)((-16D))), ((V)(96D)), ((V)(88D)))).Put("s", ((V)(s_3545.Str))).V;
return default;
}, 0, "", true));
Set(WIN_3161, "kgreen", Fn((V _arrowThis3687, int _argc3681, V _a3683, V _a3684, V _a3685, V _a3686, V[] _rest3682) => {
V R_3688 = default;
V O_3689 = default;
V F_3690 = default;
V FC_3691 = default;
V P_3692 = default;
V Q_3693 = default;
V shelf_3694 = default;
JsStrBuf s_3695 = null;
JsStrBuf sc_3696 = null;
V bar_3697 = default;
V potAt_3698 = default;
double v2_3699 = 0;
R_3688 = Call(rng_13, V.Undef, ((V)("kgr")));
O_3689 = Arr(((V)((-46D))), ((V)(46D)), ((V)((-22D))), ((V)(58D)));
F_3690 = Arr(((V)((-34D))), ((V)(34D)), ((V)((-16D))), ((V)(40D)));
FC_3691 = ((V)("#f4f2ea"));
P_3692 = Fn((V _arrowThis3709, int _argc3700, V sx_3706, V u_3707, V v_3708, V _a3705, V[] _rest3701) => {
V ox_3710 = default;
V fx_3711 = default;
V oy_3712 = default;
V fy_3713 = default;
ox_3710 = Add(GetIdx(O_3689, 0D), ((V)(((ToNum(GetIdx(O_3689, 1D)) - ToNum(GetIdx(O_3689, 0D))) * ToNum(sx_3706)))));
fx_3711 = Add(GetIdx(F_3690, 0D), ((V)(((ToNum(GetIdx(F_3690, 1D)) - ToNum(GetIdx(F_3690, 0D))) * ToNum(sx_3706)))));
oy_3712 = Add(GetIdx(O_3689, 2D), ((V)(((ToNum(GetIdx(O_3689, 3D)) - ToNum(GetIdx(O_3689, 2D))) * ToNum(v_3708)))));
fy_3713 = Add(GetIdx(F_3690, 2D), ((V)(((ToNum(GetIdx(F_3690, 3D)) - ToNum(GetIdx(F_3690, 2D))) * ToNum(v_3708)))));
return Arr(Add(ox_3710, ((V)(((ToNum(fx_3711) - ToNum(ox_3710)) * ToNum(u_3707))))), Add(oy_3712, ((V)(((ToNum(fy_3713) - ToNum(oy_3712)) * ToNum(u_3707))))));
return default;
}, 3, "", true);
Q_3693 = Fn((V _arrowThis3724, int _argc3714, V a_3720, V b_3721, V c_3722, V d_3723, V[] _rest3715) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Arr(a_3720, b_3721, c_3722, d_3723), "map", pt_30), "join", ((V)("L")))).S("Z").End()));
}, 4, "", true);
shelf_3694 = Fn((V _arrowThis3732, int _argc3725, V v_3731, V _a3728, V _a3729, V _a3730, V[] _rest3726) => {
return Call(Q_3693, V.Undef, Call(P_3692, V.Undef, ((V)(0D)), ((V)(0D)), v_3731), Call(P_3692, V.Undef, ((V)(1D)), ((V)(0D)), v_3731), Call(P_3692, V.Undef, ((V)(1D)), ((V)(1D)), v_3731), Call(P_3692, V.Undef, ((V)(0D)), ((V)(1D)), v_3731));
}, 1, "", true);
s_3695 = new JsStrBuf(JsStrBuf.Begin().S("<defs>").V(WDEF_3162).S("<linearGradient id=\"k\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#8cc4ea\"/><stop offset=\"1\" stop-color=\"#e2f2f6\"/></linearGradient><radialGradient id=\"sun\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fffbe0\"/><stop offset=\"0.4\" stop-color=\"#fff2b0\" stop-opacity=\"0.6\"/><stop offset=\"1\" stop-color=\"#fff2b0\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"zn\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#9aa4a6\"/><stop offset=\"1\" stop-color=\"#c8cfd0\"/></linearGradient><linearGradient id=\"bm\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff6c8\" stop-opacity=\"0.32\"/><stop offset=\"1\" stop-color=\"#fff6c8\" stop-opacity=\"0\"/></linearGradient>").S("<linearGradient id=\"br\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff0b8\"/><stop offset=\"0.5\" stop-color=\"#d8a848\"/><stop offset=\"1\" stop-color=\"#8a6420\"/></linearGradient><clipPath id=\"oc\"><rect x=\"-46\" y=\"-22\" width=\"92\" height=\"80\"/></clipPath></defs>").End());
s_3695.S("<rect x=\"-52\" y=\"-28\" width=\"104\" height=\"94\" fill=\"#000000\" opacity=\"0.18\" filter=\"url(#b2)\"/>");
sc_3696 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-46\" y=\"-22\" width=\"92\" height=\"80\" fill=\"url(#k)\"/><circle cx=\"26\" cy=\"-10\" r=\"22\" fill=\"url(#sun)\"/>").V(Call(drift_3168, V.Undef, Add(Call(cloud_3167, V.Undef, ((V)((-20D))), ((V)((-12D))), ((V)(0.9)), ((V)("#ffffff"))), Call(cloud_3167, V.Undef, ((V)(14D)), ((V)((-4D))), ((V)(0.6)), ((V)("#ffffff")))), ((V)(92D)), ((V)(70D)))).End());
sc_3696.S("<path d=\"M-46 22Q-24 14 0 20T46 16V58H-46Z\" fill=\"#a8d29a\"/><path d=\"M-46 30Q-20 24 6 30T46 27V58H-46Z\" fill=\"#88bd78\"/>").V(Call(tree_3170, V.Undef, ((V)((-30D))), ((V)(26D)), ((V)(1.8)), ((V)("#5f9a4e")), ((V)(0.2)))).V(Call(tree_3170, V.Undef, ((V)(36D)), ((V)(22D)), ((V)(1.4)), ((V)("#6fa85a")), ((V)(1.1))));
sc_3696.V(Invoke(Call(rep_18, V.Undef, ((V)(30D)), Fn((V _arrowThis3739, int _argc3733, V _a3735, V _a3736, V _a3737, V _a3738, V[] _rest3734) => {
double x_3740 = 0;
double y_3741 = 0;
x_3740 = ((-44D) + (ToNum(Call(R_3688, V.Undef)) * 88D));
y_3741 = (30D + (ToNum(Call(R_3688, V.Undef)) * 10D));
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_16, V.Undef, ((V)(x_3740)))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)(y_3741)))).S("\" r=\"").V(Call(f1_16, V.Undef, ((V)((0.5 + (ToNum(Call(R_3688, V.Undef)) * 0.5)))))).S("\" fill=\"").V(GetIdx(Arr(((V)("#f2a0c0")), ((V)("#ffffff")), ((V)("#f2d24a")), ((V)("#b8a0f0"))), System.Math.Floor((ToNum(Call(R_3688, V.Undef)) * 4D)))).S("\"/>").End()));
return default;
}, 0, "", true)), "join", ((V)(""))));
sc_3696.S("<g>").V(Call(at_47, V.Undef, ((V)("translate")), ((V)("-30 6;-10 -2;8 4;24 -4;8 2;-14 -4;-30 6")), ((V)(18D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(6D))))).S("<g>").V(Call(at_47, V.Undef, ((V)("scale")), ((V)("1 1;0.2 1;1 1")), ((V)(0.3)))).S("<path d=\"M0 0Q-2.4 -2.6 -2.6 -0.4Q-2 1.4 0 0Q2 1.4 2.6 -0.4Q2.4 -2.6 0 0Z\" fill=\"#f2a63a\"/><path d=\"M0 0Q-1.4 -1.4 -1.6 -0.4M0 0Q1.4 -1.4 1.6 -0.4\" stroke=\"#3a2a1a\" stroke-width=\"0.15\" fill=\"none\"/></g><path d=\"M0 -0.8V0.8\" stroke=\"#3a2a1a\" stroke-width=\"0.35\"/></g>");
s_3695.S("<g clip-path=\"url(#oc)\">").S(sc_3696.Str).S("</g>");
s_3695.S("<path d=\"").V(Call(Q_3693, V.Undef, Arr(GetIdx(O_3689, 0D), GetIdx(O_3689, 2D)), Arr(GetIdx(F_3690, 0D), GetIdx(F_3690, 2D)), Arr(GetIdx(F_3690, 0D), GetIdx(F_3690, 3D)), Arr(GetIdx(O_3689, 0D), GetIdx(O_3689, 3D)))).S("\" fill=\"#e6f2ea\" opacity=\"0.22\"/><path d=\"").V(Call(Q_3693, V.Undef, Arr(GetIdx(O_3689, 1D), GetIdx(O_3689, 2D)), Arr(GetIdx(F_3690, 1D), GetIdx(F_3690, 2D)), Arr(GetIdx(F_3690, 1D), GetIdx(F_3690, 3D)), Arr(GetIdx(O_3689, 1D), GetIdx(O_3689, 3D)))).S("\" fill=\"#ffffff\" opacity=\"0.14\"/><path d=\"").V(Call(Q_3693, V.Undef, Arr(GetIdx(O_3689, 0D), GetIdx(O_3689, 2D)), Arr(GetIdx(O_3689, 1D), GetIdx(O_3689, 2D)), Arr(GetIdx(F_3690, 1D), GetIdx(F_3690, 2D)), Arr(GetIdx(F_3690, 0D), GetIdx(F_3690, 2D)))).S("\" fill=\"#f6fbf8\" opacity=\"0.4\"/>").V(Call(glassRef_3171, V.Undef, GetIdx(F_3690, 0D), GetIdx(F_3690, 2D), ((V)((ToNum(GetIdx(F_3690, 1D)) - ToNum(GetIdx(F_3690, 0D))))), ((V)((ToNum(GetIdx(F_3690, 3D)) - ToNum(GetIdx(F_3690, 2D)))))));
bar_3697 = Fn((V _arrowThis3751, int _argc3742, V a_3748, V b_3749, V w_3750, V _a3747, V[] _rest3743) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(pt_30, V.Undef, a_3748)).S("L").V(Call(pt_30, V.Undef, b_3749)).S("\" stroke=\"").V(Call(shade_10, V.Undef, FC_3691, ((V)(0.8)))).S("\" stroke-width=\"").V(w_3750).S("\" stroke-linecap=\"round\"/><path d=\"M").V(Call(pt_30, V.Undef, a_3748)).S("L").V(Call(pt_30, V.Undef, b_3749)).S("\" stroke=\"").V(FC_3691).S("\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(w_3750) * 0.6))))).S("\" stroke-linecap=\"round\"/>").End()));
}, 3, "", true);
s_3695.V(Add(Add(Add(Add(Call(bar_3697, V.Undef, Arr(GetIdx(F_3690, 0D), GetIdx(F_3690, 2D)), Arr(GetIdx(F_3690, 1D), GetIdx(F_3690, 2D)), ((V)(1.6))), Call(bar_3697, V.Undef, Arr(GetIdx(F_3690, 0D), GetIdx(F_3690, 3D)), Arr(GetIdx(F_3690, 1D), GetIdx(F_3690, 3D)), ((V)(1.6)))), Call(bar_3697, V.Undef, Arr(GetIdx(F_3690, 0D), GetIdx(F_3690, 2D)), Arr(GetIdx(F_3690, 0D), GetIdx(F_3690, 3D)), ((V)(1.6)))), Call(bar_3697, V.Undef, Arr(GetIdx(F_3690, 1D), GetIdx(F_3690, 2D)), Arr(GetIdx(F_3690, 1D), GetIdx(F_3690, 3D)), ((V)(1.6)))), Call(bar_3697, V.Undef, Arr(((V)(0D)), GetIdx(F_3690, 2D)), Arr(((V)(0D)), GetIdx(F_3690, 3D)), ((V)(1.2)))));
Invoke(Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(1D)), ((V)(0D)))), "forEach", Fn((V _arrowThis3761, int _argc3752, V _a3754, V _a3755, V _a3756, V _a3757, V[] _rest3753) => {
V sx_3760 = default;
{ V _t3758 = ListOf(_a3754);
{ V _t3759 = GetIdx(_t3758, 0D);
sx_3760 = _t3759; }
}
s_3695.V(Add(Add(Call(bar_3697, V.Undef, Call(P_3692, V.Undef, sx_3760, ((V)(0D)), ((V)(0D))), Call(P_3692, V.Undef, sx_3760, ((V)(1D)), ((V)(0D))), ((V)(1.6))), Call(bar_3697, V.Undef, Call(P_3692, V.Undef, sx_3760, ((V)(0D)), ((V)(1D))), Call(P_3692, V.Undef, sx_3760, ((V)(1D)), ((V)(1D))), ((V)(1.6)))), Call(bar_3697, V.Undef, Call(P_3692, V.Undef, sx_3760, ((V)(0.5)), ((V)(0D))), Call(P_3692, V.Undef, sx_3760, ((V)(0.5)), ((V)(1D))), ((V)(1D)))));
return default;
}, 1, "", true));
s_3695.S("<path d=\"").V(Call(shelf_3694, V.Undef, ((V)(1D)))).S("\" fill=\"url(#zn)\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(70D)), Fn((V _arrowThis3768, int _argc3762, V _a3764, V _a3765, V _a3766, V _a3767, V[] _rest3763) => {
V sx_3769 = default;
V u_3770 = default;
V p_3771 = default;
double k_3772 = 0;
sx_3769 = Call(R_3688, V.Undef);
u_3770 = Call(R_3688, V.Undef);
p_3771 = Call(P_3692, V.Undef, sx_3769, u_3770, ((V)(1D)));
k_3772 = (1D - (0.27 * ToNum(u_3770)));
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_16, V.Undef, GetIdx(p_3771, 0D))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(p_3771, 1D)) - 0.3))))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)(((0.5 + (ToNum(Call(R_3688, V.Undef)) * 0.5)) * k_3772))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)(((0.3 + (ToNum(Call(R_3688, V.Undef)) * 0.25)) * k_3772))))).S("\" fill=\"").V(GetIdx(Arr(((V)("#d8d0c0")), ((V)("#b8b0a2")), ((V)("#e8e2d6")), ((V)("#a09888"))), System.Math.Floor((ToNum(Call(R_3688, V.Undef)) * 4D)))).S("\"/>").End()));
return default;
}, 0, "", true)), "join", ((V)(""))));
potAt_3698 = Fn((V _arrowThis3784, int _argc3773, V sx_3779, V u_3780, V v_3781, V h_3782, V[] _rest3774) => {
V p_3785 = default;
double k_3786 = 0;
V ph_3783 = default;
ph_3783 = (_argc3773 > 4 ? _rest3774[0] : V.Undef);
p_3785 = Call(P_3692, V.Undef, sx_3779, u_3780, v_3781);
k_3786 = (1D - (0.27 * ToNum(u_3780)));
return Add(Call(pot_3172, V.Undef, GetIdx(p_3785, 0D), ((V)((ToNum(GetIdx(p_3785, 1D)) - (4.6 * k_3786)))), ((V)((6.4 * k_3786))), ((V)((4.6 * k_3786)))), Call(herb_3174, V.Undef, h_3782, GetIdx(p_3785, 0D), ((V)((ToNum(GetIdx(p_3785, 1D)) - (5.6 * k_3786)))), ((V)((0.95 * k_3786))), ph_3783));
return default;
}, 5, "", true);
s_3695.V(Add(Add(Call(potAt_3698, V.Undef, ((V)(0.22)), ((V)(0.85)), ((V)(1D)), ((V)("chive")), ((V)(0.4))), Call(potAt_3698, V.Undef, ((V)(0.5)), ((V)(0.85)), ((V)(1D)), ((V)("rose")), ((V)(1.1)))), Call(potAt_3698, V.Undef, ((V)(0.78)), ((V)(0.85)), ((V)(1D)), ((V)("mint")), ((V)(2D)))));
v2_3699 = 0.52;
s_3695.S("<path d=\"").V(Call(shelf_3694, V.Undef, ((V)(v2_3699)))).S("\" fill=\"#e8f6f4\" opacity=\"0.4\"/><path d=\"M").V(Call(pt_30, V.Undef, Call(P_3692, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(v2_3699))))).S("L").V(Call(pt_30, V.Undef, Call(P_3692, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(v2_3699))))).S("\" stroke=\"#bfe0dc\" stroke-width=\"0.9\"/><path d=\"M").V(Call(pt_30, V.Undef, Call(P_3692, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(v2_3699))))).S("L").V(Call(pt_30, V.Undef, Call(P_3692, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(v2_3699))))).S("\" stroke=\"#ffffff\" stroke-width=\"0.25\" transform=\"translate(0 -0.3)\"/>").V(Invoke(Invoke(Arr(((V)(0.02)), ((V)(0.98))), "map", Fn((V _arrowThis3794, int _argc3787, V sx_3793, V _a3790, V _a3791, V _a3792, V[] _rest3788) => {
V p_3795 = default;
p_3795 = Call(P_3692, V.Undef, sx_3793, ((V)(0.2)), ((V)(v2_3699)));
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_16, V.Undef, GetIdx(p_3795, 0D))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(p_3795, 1D), ((V)(0.4))))).S("l").N((LtN(sx_3793, 0.5) ? 1.6 : (-1.6))).S(" 2.4\" stroke=\"url(#br)\" stroke-width=\"0.7\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)(""))));
s_3695.V(Add(Add(Call(potAt_3698, V.Undef, ((V)(0.25)), ((V)(0.5)), ((V)(v2_3699)), ((V)("thyme")), ((V)(0.8))), Call(potAt_3698, V.Undef, ((V)(0.5)), ((V)(0.5)), ((V)(v2_3699)), ((V)("pars")), ((V)(1.7)))), Call(potAt_3698, V.Undef, ((V)(0.75)), ((V)(0.5)), ((V)(v2_3699)), ((V)("basil")), ((V)(2.6)))));
s_3695.V(Add(Add(Call(potAt_3698, V.Undef, ((V)(0.18)), ((V)(0.22)), ((V)(1D)), ((V)("basil")), ((V)(0.2))), Call(potAt_3698, V.Undef, ((V)(0.5)), ((V)(0.22)), ((V)(1D)), ((V)("thyme")), ((V)(1.4)))), Call(potAt_3698, V.Undef, ((V)(0.82)), ((V)(0.22)), ((V)(1D)), ((V)("pars")), ((V)(2.2)))));
Invoke(Arr(Arr(((V)(0.18)), ((V)("BASIL"))), Arr(((V)(0.82)), ((V)("PARSLEY")))), "forEach", Fn((V _arrowThis3807, int _argc3796, V _a3798, V _a3799, V _a3800, V _a3801, V[] _rest3797) => {
V p_3808 = default;
V sx_3804 = default;
V t_3806 = default;
{ V _t3802 = ListOf(_a3798);
{ V _t3803 = GetIdx(_t3802, 0D);
sx_3804 = _t3803; }
{ V _t3805 = GetIdx(_t3802, 1D);
t_3806 = _t3805; }
}
p_3808 = Call(P_3692, V.Undef, sx_3804, ((V)(0.22)), ((V)(1D)));
s_3695.S("<g transform=\"translate(").V(Call(f1_16, V.Undef, Add(GetIdx(p_3808, 0D), ((V)(2.4))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(p_3808, 1D)) - 8.6))))).S(")\"><path d=\"M0 0V3.4\" stroke=\"#c8b088\" stroke-width=\"0.3\"/><rect x=\"-2.2\" y=\"-1.4\" width=\"4.4\" height=\"1.6\" rx=\"0.2\" fill=\"#f4ecd8\"/><text y=\"-0.2\" text-anchor=\"middle\" font-family=\"Arial,Helvetica,sans-serif\" font-weight=\"700\" font-size=\"0.9\" fill=\"#6a5a3a\">").V(t_3806).S("</text></g>");
return default;
}, 1, "", true));
s_3695.S("<g opacity=\"0.7\">").V(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.5;0.85;0.5")), ((V)(8D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))).S("<path d=\"M34 -16L46 -22L10 58L-4 58Z\" fill=\"url(#bm)\"/><path d=\"M18 -16L26 -16L-14 58L-22 58Z\" fill=\"url(#bm)\" opacity=\"0.6\"/></g>");
s_3695.S("<g>").V(Call(at_47, V.Undef, ((V)("translate")), ((V)("0 0;0 0;0 18")), ((V)(16D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.5;1\" calcMode=\"spline\" keySplines=\"0 0 1 1;0.5 0 1 1\"")))).S("<ellipse cx=\"-20\" cy=\"-8\" rx=\"0.5\" ry=\"0.7\" fill=\"#ffffff\" opacity=\"0.7\"/><path d=\"M-20 -8.4V-14\" stroke=\"#ffffff\" stroke-width=\"0.3\" opacity=\"0.3\"/></g>").V(Invoke(Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis3815, int _argc3809, V _a3811, V _a3812, V _a3813, V _a3814, V[] _rest3810) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_16, V.Undef, Add(GetIdx(F_3690, 0D), ((V)((ToNum(Call(R_3688, V.Undef)) * 68D)))))).S("\" cy=\"").V(Call(f1_16, V.Undef, Add(GetIdx(F_3690, 2D), ((V)((ToNum(Call(R_3688, V.Undef)) * 18D)))))).S("\" r=\"").V(Call(f1_16, V.Undef, ((V)((0.15 + (ToNum(Call(R_3688, V.Undef)) * 0.2)))))).S("\" fill=\"#ffffff\" opacity=\"0.5\"/>").End()));
}, 0, "", true)), "join", ((V)(""))));
s_3695.V(Add(Add(Call(ring_3164, V.Undef, ((V)((-50D))), ((V)((-26D))), ((V)(50D)), ((V)(61D)), ((V)(4D)), FC_3691, ((V)(1D))), Call(sill_3166, V.Undef, ((V)((-54D))), ((V)(54D)), ((V)(60D)), ((V)("#e8e2d4")), ((V)(2D)))), Call(bev_3163, V.Undef, ((V)((-46D))), ((V)(63D)), ((V)(92D)), ((V)(3.6)), FC_3691, ((V)(0.6)))));
s_3695.S("<g transform=\"translate(-40 55.8)\"><ellipse cx=\"2\" cy=\"4.4\" rx=\"4\" ry=\"0.8\" fill=\"#000000\" opacity=\"0.22\" filter=\"url(#b1)\"/><path d=\"M0 0H4.4L4.8 4.2H-0.4Z\" fill=\"url(#br)\"/><path d=\"M4.4 1.2L8.4 -2.6\" stroke=\"url(#br)\" stroke-width=\"0.9\" stroke-linecap=\"round\"/><ellipse cx=\"8.6\" cy=\"-2.8\" rx=\"0.7\" ry=\"1\" fill=\"#c8983a\" transform=\"rotate(40 8.6 -2.8)\"/><path d=\"M0 0Q2.2 -3.4 4.4 0\" stroke=\"#b8892e\" stroke-width=\"0.5\" fill=\"none\"/><rect x=\"0.6\" y=\"0.6\" width=\"0.6\" height=\"3\" fill=\"#fff4c8\" opacity=\"0.6\"/></g>");
return NewObj(2).Put("vb", Arr(((V)((-56D))), ((V)((-30D))), ((V)(112D)), ((V)(98D)))).Put("s", ((V)(s_3695.Str))).V;
return default;
}, 0, "", true));
Set(WIN_3161, "kaccord", Fn((V _arrowThis3822, int _argc3816, V _a3818, V _a3819, V _a3820, V _a3821, V[] _rest3817) => {
V R_3823 = default;
double N_3824 = 0;
double X0_3825 = 0;
double X1_3826 = 0;
double WP_3827 = 0;
double YT_3828 = 0;
double YB_3829 = 0;
double YC_3830 = 0;
double YM_3831 = 0;
V ST_3832 = default;
JsStrBuf s_3833 = null;
JsStrBuf sc_3834 = null;
JsStrBuf li_3835 = null;
V sm_3836 = default;
V KF_3837 = default;
V KT_3838 = default;
V E_3839 = default;
V vals_3840 = default;
V coupe_3841 = default;
R_3823 = Call(rng_13, V.Undef, ((V)("kac")));
N_3824 = 6D;
X0_3825 = (-62D);
X1_3826 = 62D;
WP_3827 = ((X1_3826 - X0_3825) / N_3824);
YT_3828 = (-22D);
YB_3829 = 40D;
YC_3830 = 9D;
YM_3831 = (YT_3828 + ((YB_3829 - YT_3828) * 0.36));
ST_3832 = ((V)("#1d1e20"));
s_3833 = new JsStrBuf(JsStrBuf.Begin().S("<defs>").V(WDEF_3162).S("<linearGradient id=\"k\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#9cc0da\"/><stop offset=\"0.55\" stop-color=\"#f4d6a8\"/><stop offset=\"1\" stop-color=\"#f8c88a\"/></linearGradient><radialGradient id=\"sun\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff4d0\"/><stop offset=\"0.3\" stop-color=\"#ffd48a\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#ffc06a\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"wn\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#8a5a36\"/><stop offset=\"1\" stop-color=\"#5a3620\"/></linearGradient><linearGradient id=\"wf\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#7a4a2a\"/><stop offset=\"0.2\" stop-color=\"#5e3a22\"/><stop offset=\"1\" stop-color=\"#3e2414\"/></linearGradient>").S("<linearGradient id=\"gl\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.3\"/><stop offset=\"0.4\" stop-color=\"#ffffff\" stop-opacity=\"0.05\"/><stop offset=\"1\" stop-color=\"#2a3a4a\" stop-opacity=\"0.12\"/></linearGradient>").S("<linearGradient id=\"br\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff0b8\"/><stop offset=\"0.5\" stop-color=\"#d8a848\"/><stop offset=\"1\" stop-color=\"#8a6420\"/></linearGradient><radialGradient id=\"bl\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff2c0\"/><stop offset=\"1\" stop-color=\"#ffd27a\" stop-opacity=\"0\"/></radialGradient><clipPath id=\"oc\"><rect x=\"-62\" y=\"-22\" width=\"124\" height=\"62\"/></clipPath></defs>").End());
s_3833.S("<rect x=\"-68\" y=\"-28\" width=\"138\" height=\"84\" fill=\"#000000\" opacity=\"0.18\" filter=\"url(#b2)\"/>");
sc_3834 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-62\" y=\"-22\" width=\"124\" height=\"62\" fill=\"url(#k)\"/><circle cx=\"34\" cy=\"12\" r=\"22\" fill=\"url(#sun)\"/><circle cx=\"34\" cy=\"12\" r=\"4.2\" fill=\"#fff2c8\"/>").V(Call(drift_3168, V.Undef, Add(Call(cloud_3167, V.Undef, ((V)((-30D))), ((V)((-14D))), ((V)(0.8)), ((V)("#fbe8d0"))), Call(cloud_3167, V.Undef, ((V)(10D)), ((V)((-17D))), ((V)(0.6)), ((V)("#fbe8d0")))), ((V)(124D)), ((V)(90D)))).End());
sc_3834.S("<path d=\"M-62 14Q-40 6 -20 12T20 9T62 12V40H-62Z\" fill=\"#c8a68a\"/><path d=\"M-62 18Q-34 13 -6 18T62 16V40H-62Z\" fill=\"#a88e76\"/>");
sc_3834.S("<path d=\"M-62 26H62V40H-62Z\" fill=\"#e8d6b8\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis3849, int _argc3842, V i_3848, V _a3845, V _a3846, V _a3847, V[] _rest3843) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").N(((-62D) + (ToNum(i_3848) * 16D))).S(" 26L").V(Call(f1_16, V.Undef, ((V)((((-62D) + (ToNum(i_3848) * 16D)) + (((ToNum(i_3848) * 16D) - 62D) * 0.3)))))).S(" 40\" stroke=\"#cdb894\" stroke-width=\"0.2\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M-62 31H62M-62 36H62\" stroke=\"#cdb894\" stroke-width=\"0.2\"/>");
sc_3834.V(Call(sway_3169, V.Undef, ((V)((-46D))), ((V)(30D)), ((V)(1D)), ((V)(1.5)), ((V)(6D)), ((V)(0.4)), ((V)(JsStrBuf.Begin().S("<path d=\"M-1 0L-0.6 -14H0.6L1 0Z\" fill=\"#6a5a46\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(14D)), Fn((V _arrowThis3857, int _argc3850, V i_3856, V _a3853, V _a3854, V _a3855, V[] _rest3851) => {
double a_3858 = 0;
double d_3859 = 0;
a_3858 = (((-PI_11) / 2D) + ((ToNum(i_3856) - 6.5) * 0.22));
d_3859 = (7D + ((ToNum(i_3856) % 3D) * 2D));
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_16, V.Undef, ((V)(((FdLibm.Cos(a_3858) * d_3859) * 0.8))))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)((((-14D) + ((FdLibm.Sin(a_3858) * d_3859) * 0.5)) + 4D))))).S("\" rx=\"3.6\" ry=\"1.8\" fill=\"").S((NumTruthy((ToNum(i_3856) % 2D)) ? "#8a9a6e" : "#7a8a5e")).S("\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).End())))).S("<path d=\"M-51 30H-41L-42 37H-50Z\" fill=\"#c8b8a0\"/><rect x=\"-51.6\" y=\"29\" width=\"11.2\" height=\"1.6\" fill=\"#ddd0b8\"/>");
li_3835 = new JsStrBuf("");
Invoke(Arr(Arr(((V)((-62D))), ((V)((-16D))), ((V)(0D)), ((V)((-10D))), ((V)("a"))), Arr(((V)(0D)), ((V)((-10D))), ((V)(62D)), ((V)((-18D))), ((V)("b")))), "forEach", Fn((V _arrowThis3878, int _argc3860, V _a3862, V j_3866, V _a3864, V _a3865, V[] _rest3861) => {
double my_3879 = 0;
V x0_3869 = default;
V y0_3871 = default;
V x1_3873 = default;
V y1_3875 = default;
V k_3877 = default;
{ V _t3867 = ListOf(_a3862);
{ V _t3868 = GetIdx(_t3867, 0D);
x0_3869 = _t3868; }
{ V _t3870 = GetIdx(_t3867, 1D);
y0_3871 = _t3870; }
{ V _t3872 = GetIdx(_t3867, 2D);
x1_3873 = _t3872; }
{ V _t3874 = GetIdx(_t3867, 3D);
y1_3875 = _t3874; }
{ V _t3876 = GetIdx(_t3867, 4D);
k_3877 = _t3876; }
}
my_3879 = (Max(ToNum(y0_3871), ToNum(y1_3875)) + 5D);
li_3835.S("<path d=\"M").V(x0_3869).S(" ").V(y0_3871).S("Q").V(Call(f1_16, V.Undef, ((V)((ToNum(Add(x0_3869, x1_3873)) / 2D))))).S(" ").V(Call(f1_16, V.Undef, ((V)((my_3879 + 3D))))).S(" ").V(x1_3873).S(" ").V(y1_3875).S("\" stroke=\"#3a3028\" stroke-width=\"0.25\" fill=\"none\"/>");
{
double i_3880 = 0;
i_3880 = 1D;
while (true) {
if (!((i_3880 < 9D))) break;
double t_3882 = 0;
double x_3883 = 0;
double y_3884 = 0;
t_3882 = (i_3880 / 9D);
x_3883 = (((((1D - t_3882) * (1D - t_3882)) * ToNum(x0_3869)) + ((((2D * t_3882) * (1D - t_3882)) * ToNum(Add(x0_3869, x1_3873))) / 2D)) + ((t_3882 * t_3882) * ToNum(x1_3873)));
y_3884 = (((((1D - t_3882) * (1D - t_3882)) * ToNum(y0_3871)) + (((2D * t_3882) * (1D - t_3882)) * (my_3879 + 3D))) + ((t_3882 * t_3882) * ToNum(y1_3875)));
li_3835.S("<circle cx=\"").V(Call(f1_16, V.Undef, ((V)(x_3883)))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)((y_3884 + 1.6))))).S("\" r=\"2.4\" fill=\"url(#bl)\" opacity=\"0.6\">").V(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.4;0.75;0.4")), ((V)((3D + (i_3880 % 3D)))), Add(((V)((i_3880 * 0.4))), j_3866), Call(SPL_15, V.Undef, ((V)(2D))))).S("</circle><path d=\"M").V(Call(f1_16, V.Undef, ((V)(x_3883)))).S(" ").V(Call(f1_16, V.Undef, ((V)(y_3884)))).S("v0.6\" stroke=\"#3a3028\" stroke-width=\"0.4\"/><ellipse cx=\"").V(Call(f1_16, V.Undef, ((V)(x_3883)))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)((y_3884 + 1.4))))).S("\" rx=\"0.55\" ry=\"0.8\" fill=\"#fff0c0\"/>");
i_3880++;
}
}
return default;
}, 2, "", true));
sc_3834.S("<g>").V(Call(at_47, V.Undef, ((V)("rotate")), ((V)("-0.6 0 -20;0.6 0 -20;-0.6 0 -20")), ((V)(7D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))).S(li_3835.Str).S("</g>");
sc_3834.V(Invoke(Invoke(Arr(((V)((-14D))), ((V)(14D))), "map", Fn((V _arrowThis3892, int _argc3885, V x_3891, V _a3888, V _a3889, V _a3890, V[] _rest3886) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(x_3891).S(" 34)\"><path d=\"M-3 0L-3.6 6M3 0L3.6 6M-2.6 3.4H2.6\" stroke=\"#3a3028\" stroke-width=\"0.4\"/><ellipse rx=\"3.6\" ry=\"1.1\" fill=\"#c8a878\"/><ellipse cy=\"-0.2\" rx=\"3.2\" ry=\"0.8\" fill=\"#dcc090\"/><path d=\"M-3 -0.2H3M-2.4 0.3H2.4\" stroke=\"#a8885a\" stroke-width=\"0.12\"/></g>").End()));
}, 1, "", true)), "join", ((V)(""))));
s_3833.S("<g clip-path=\"url(#oc)\">").S(sc_3834.Str).S("</g>");
s_3833.S("<path d=\"M-64 35H64L64 40H-64Z\" fill=\"url(#wn)\"/><path d=\"M-64 35H64\" stroke=\"#b07a4a\" stroke-width=\"0.3\"/>");
s_3833.V(Call(ring_3164, V.Undef, ((V)((-66D))), ((V)((-26D))), ((V)(66D)), ((V)(41D)), ((V)(4D)), ST_3832, ((V)(0.6)))).S("<rect x=\"-62\" y=\"-22.2\" width=\"124\" height=\"1\" fill=\"#3a3c40\"/><rect x=\"-62\" y=\"39.6\" width=\"124\" height=\"0.6\" fill=\"#3a3c40\"/>");
sm_3836 = Fn((V _arrowThis3900, int _argc3893, V x_3899, V _a3896, V _a3897, V _a3898, V[] _rest3894) => {
return ((V)(((ToNum(x_3899) * ToNum(x_3899)) * (3D - (2D * ToNum(x_3899))))));
}, 1, "", true);
KF_3837 = Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(0.14)), ((V)(0D))));
{
double i_3901 = 0;
i_3901 = 1D;
while (true) {
if (!((i_3901 <= 8D))) break;
Invoke(KF_3837, "push", Arr(((V)((0.14 + ((0.2 * i_3901) / 8D)))), Call(sm_3836, V.Undef, ((V)((i_3901 / 8D))))));
i_3901++;
}
}
Invoke(KF_3837, "push", Arr(((V)(0.62)), ((V)(1D))));
{
double i_3903 = 0;
i_3903 = 1D;
while (true) {
if (!((i_3903 <= 8D))) break;
Invoke(KF_3837, "push", Arr(((V)((0.62 + ((0.2 * i_3903) / 8D)))), ((V)((1D - ToNum(Call(sm_3836, V.Undef, ((V)((i_3903 / 8D))))))))));
i_3903++;
}
}
Invoke(KF_3837, "push", Arr(((V)(1D)), ((V)(0D))));
KT_3838 = ((V)(JsStrBuf.Begin().S(" keyTimes=\"").V(Invoke(Invoke(KF_3837, "map", Fn((V _arrowThis3912, int _argc3905, V k_3911, V _a3908, V _a3909, V _a3910, V[] _rest3906) => {
return Call(n4_17, V.Undef, GetIdx(k_3911, 0D));
}, 1, "", true)), "join", ((V)(";")))).S("\"").End()));
E_3839 = Fn((V _arrowThis3921, int _argc3913, V j_3919, V f_3920, V _a3917, V _a3918, V[] _rest3914) => {
double th_3922 = 0;
double x_3923 = 0;
double d_3924 = 0;
double k_3925 = 0;
th_3922 = (ToNum(f_3920) * 1.38);
x_3923 = (X0_3825 + ((ToNum(j_3919) * WP_3827) * FdLibm.Cos(th_3922)));
d_3924 = (((ToNum(j_3919) % 2D) * WP_3827) * FdLibm.Sin(th_3922));
k_3925 = (1D + (d_3924 * 0.0045));
return Arr(((V)(x_3923)), ((V)((YC_3830 + ((YT_3828 - YC_3830) * k_3925)))), ((V)((YC_3830 + ((YB_3829 - YC_3830) * k_3925)))), ((V)((YC_3830 + ((YM_3831 - YC_3830) * k_3925)))));
return default;
}, 2, "", true);
vals_3840 = Fn((V _arrowThis3933, int _argc3926, V fn_3932, V _a3929, V _a3930, V _a3931, V[] _rest3927) => {
return Invoke(Invoke(KF_3837, "map", Fn((V _arrowThis3943, int _argc3934, V _a3936, V _a3937, V _a3938, V _a3939, V[] _rest3935) => {
V f_3942 = default;
{ V _t3940 = ListOf(_a3936);
{ V _t3941 = GetIdx(_t3940, 1D);
f_3942 = _t3941; }
}
return Call(fn_3932, V.Undef, f_3942);
}, 1, "", true)), "join", ((V)(";")));
}, 1, "", true);
{
V i_3944 = default;
i_3944 = ((V)(0D));
while (true) {
V i_3944_it = i_3944;
if (!(LtN(i_3944_it, N_3824))) break;
V dP_3946 = default;
V dM_3947 = default;
V d0_3948 = default;
V A_3949 = default;
dP_3946 = Fn((V _arrowThis3957, int _argc3950, V f_3956, V _a3953, V _a3954, V _a3955, V[] _rest3951) => {
V a_3958 = default;
V b_3959 = default;
a_3958 = Call(E_3839, V.Undef, i_3944_it, f_3956);
b_3959 = Call(E_3839, V.Undef, Add(i_3944_it, ((V)(1D))), f_3956);
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_16, V.Undef, GetIdx(a_3958, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(a_3958, 1D))).S("L").V(Call(f1_16, V.Undef, GetIdx(b_3959, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(b_3959, 1D))).S("L").V(Call(f1_16, V.Undef, GetIdx(b_3959, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(b_3959, 2D))).S("L").V(Call(f1_16, V.Undef, GetIdx(a_3958, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(a_3958, 2D))).S("Z").End()));
return default;
}, 1, "", true);
dM_3947 = Fn((V _arrowThis3967, int _argc3960, V f_3966, V _a3963, V _a3964, V _a3965, V[] _rest3961) => {
V a_3968 = default;
V b_3969 = default;
a_3968 = Call(E_3839, V.Undef, i_3944_it, f_3966);
b_3969 = Call(E_3839, V.Undef, Add(i_3944_it, ((V)(1D))), f_3966);
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_16, V.Undef, GetIdx(a_3968, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(a_3968, 3D))).S("L").V(Call(f1_16, V.Undef, GetIdx(b_3969, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(b_3969, 3D))).End()));
return default;
}, 1, "", true);
d0_3948 = Call(dP_3946, V.Undef, ((V)(0D)));
A_3949 = Fn((V _arrowThis3978, int _argc3970, V nm_3976, V fn_3977, V _a3974, V _a3975, V[] _rest3971) => {
return ((V)(JsStrBuf.Begin().S("<animate attributeName=\"").V(nm_3976).S("\" values=\"").V(Call(vals_3840, V.Undef, fn_3977)).S("\" dur=\"36s\"").V(KT_3838).S(" repeatCount=\"indefinite\"/>").End()));
}, 2, "", true);
s_3833.S("<path d=\"").V(d0_3948).S("\" fill=\"#b8d0dc\" opacity=\"0.12\">").V(Call(A_3949, V.Undef, ((V)("d")), dP_3946)).S("</path><path d=\"").V(d0_3948).S("\" fill=\"url(#gl)\">").V(Call(A_3949, V.Undef, ((V)("d")), dP_3946)).S("</path><path d=\"").V(d0_3948).S("\" fill=\"#ffffff\" opacity=\"0.04\">").V(Call(A_3949, V.Undef, ((V)("d")), dP_3946)).V(Call(A_3949, V.Undef, ((V)("opacity")), Fn((V _arrowThis3986, int _argc3979, V f_3985, V _a3982, V _a3983, V _a3984, V[] _rest3980) => {
return Call(n4_17, V.Undef, ((V)((0.04 + ((NumTruthy((ToNum(i_3944_it) % 2D)) ? 0.05 : 0.3) * FdLibm.Sin((ToNum(f_3985) * 1.38)))))));
}, 1, "", true))).S("</path>").S("<path d=\"").V(d0_3948).S("\" fill=\"none\" stroke=\"").V(ST_3832).S("\" stroke-width=\"1.5\" stroke-linejoin=\"round\">").V(Call(A_3949, V.Undef, ((V)("d")), dP_3946)).S("</path><path d=\"").V(Call(dM_3947, V.Undef, ((V)(0D)))).S("\" stroke=\"").V(ST_3832).S("\" stroke-width=\"0.9\">").V(Call(A_3949, V.Undef, ((V)("d")), dM_3947)).S("</path><path d=\"").V(d0_3948).S("\" fill=\"none\" stroke=\"#5a5e66\" stroke-width=\"0.2\" transform=\"translate(-0.35 -0.35)\">").V(Call(A_3949, V.Undef, ((V)("d")), dP_3946)).S("</path>");
i_3944 = i_3944_it;
PostInc(ref i_3944, 1D);
}
}
{
V hP_3987 = default;
hP_3987 = Fn((V _arrowThis3995, int _argc3988, V f_3994, V _a3991, V _a3992, V _a3993, V[] _rest3989) => {
V e_3996 = default;
double k_3997 = 0;
e_3996 = Call(E_3839, V.Undef, ((V)(N_3824)), f_3994);
k_3997 = ((ToNum(GetIdx(e_3996, 2D)) - ToNum(GetIdx(e_3996, 1D))) / (YB_3829 - YT_3828));
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(e_3996, 0D)) - 1.4))))).S(" ").V(Call(f1_16, V.Undef, ((V)((YC_3830 - (5D * k_3997)))))).S("V").V(Call(f1_16, V.Undef, ((V)((YC_3830 + (5D * k_3997)))))).End()));
return default;
}, 1, "", true);
s_3833.S("<path d=\"").V(Call(hP_3987, V.Undef, ((V)(0D)))).S("\" stroke=\"url(#br)\" stroke-width=\"0.9\" stroke-linecap=\"round\"><animate attributeName=\"d\" values=\"").V(Call(vals_3840, V.Undef, hP_3987)).S("\" dur=\"36s\"").V(KT_3838).S(" repeatCount=\"indefinite\"/></path>");
}
s_3833.S("<path d=\"M-66 40H66L68 44H-68Z\" fill=\"url(#wn)\"/><path d=\"M-66 40.2H66\" stroke=\"#c08a58\" stroke-width=\"0.25\" opacity=\"0.8\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis4004, int _argc3998, V _a4000, V _a4001, V _a4002, V _a4003, V[] _rest3999) => {
double y_4005 = 0;
y_4005 = (40.6 + (ToNum(Call(R_3823, V.Undef)) * 3D));
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)(((-66D) + (ToNum(Call(R_3823, V.Undef)) * 40D)))))).S(" ").V(Call(f1_16, V.Undef, ((V)(y_4005)))).S("h").V(Call(f1_16, V.Undef, ((V)((20D + (ToNum(Call(R_3823, V.Undef)) * 60D)))))).S("\" stroke=\"#4a2a16\" stroke-width=\"0.12\" opacity=\"0.4\"/>").End()));
return default;
}, 0, "", true)), "join", ((V)("")))).S("<rect x=\"-68\" y=\"44\" width=\"136\" height=\"4.6\" fill=\"url(#wf)\"/><rect x=\"-68\" y=\"44\" width=\"136\" height=\"0.4\" fill=\"#d8a070\" opacity=\"0.7\"/><rect x=\"-68\" y=\"48.6\" width=\"136\" height=\"2\" fill=\"#000000\" opacity=\"0.25\" filter=\"url(#b1)\"/>");
s_3833.S("<g filter=\"url(#b2)\"><ellipse cx=\"0\" cy=\"42.4\" rx=\"40\" ry=\"1.8\" fill=\"#ffd89a\" opacity=\"0.25\"/></g>");
coupe_3841 = Fn((V _arrowThis4014, int _argc4006, V x_4012, V c_4013, V _a4010, V _a4011, V[] _rest4007) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(x_4012).S(" 42.6)\"><ellipse rx=\"2\" ry=\"0.4\" fill=\"#000000\" opacity=\"0.25\"/><path d=\"M-1.4 0H1.4L0.2 -0.4V-4L2.8 -5.6Q0 -7.2 -2.8 -5.6L-0.2 -4V-0.4Z\" fill=\"#ffffff\" opacity=\"0.35\" stroke=\"#ffffff\" stroke-width=\"0.15\" stroke-opacity=\"0.8\"/><path d=\"M-2.6 -5.6Q0 -4.4 2.6 -5.6Q0 -6.4 -2.6 -5.6Z\" fill=\"").V(c_4013).S("\" opacity=\"0.85\"/><circle cx=\"2.2\" cy=\"-6\" r=\"0.7\" fill=\"#f0a030\"/><path d=\"M-2 -5.8L-1 -6.6\" stroke=\"#ffffff\" stroke-width=\"0.2\" opacity=\"0.8\"/></g>").End()));
}, 2, "", true);
s_3833.V(Add(Call(coupe_3841, V.Undef, ((V)((-12D))), ((V)("#f08a4a"))), Call(coupe_3841, V.Undef, ((V)((-6D))), ((V)("#e8603a"))))).S("<g transform=\"translate(16 42.6)\"><ellipse rx=\"4.4\" ry=\"0.6\" fill=\"#000000\" opacity=\"0.25\"/><path d=\"M-4 -2.4Q0 0.8 4 -2.4Z\" fill=\"url(#br)\"/>").V(Invoke(Invoke(Arr(Arr(((V)((-2D))), ((V)((-2.6)))), Arr(((V)(0.4)), ((V)((-3D)))), Arr(((V)(2.4)), ((V)((-2.5)))), Arr(((V)((-0.8))), ((V)((-3.9)))), Arr(((V)(1.4)), ((V)((-4D))))), "map", Fn((V _arrowThis4026, int _argc4015, V _a4017, V _a4018, V _a4019, V _a4020, V[] _rest4016) => {
V x_4023 = default;
V y_4025 = default;
{ V _t4021 = ListOf(_a4017);
{ V _t4022 = GetIdx(_t4021, 0D);
x_4023 = _t4022; }
{ V _t4024 = GetIdx(_t4021, 1D);
y_4025 = _t4024; }
}
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(x_4023).S("\" cy=\"").V(y_4025).S("\" rx=\"1.4\" ry=\"1.1\" fill=\"#f2d43a\"/><ellipse cx=\"").N((ToNum(x_4023) - 0.4)).S("\" cy=\"").N((ToNum(y_4025) - 0.4)).S("\" rx=\"0.5\" ry=\"0.35\" fill=\"#fff4a0\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M-1 -4.8q1 -1.2 2 -0.6\" stroke=\"#4a7a2a\" stroke-width=\"0.4\" fill=\"none\"/></g>");
return NewObj(2).Put("vb", Arr(((V)((-72D))), ((V)((-30D))), ((V)(144D)), ((V)(84D)))).Put("s", ((V)(s_3833.Str))).V;
return default;
}, 0, "", true));
Set(WIN_3161, "khydro", Fn((V _arrowThis4033, int _argc4027, V _a4029, V _a4030, V _a4031, V _a4032, V[] _rest4028) => {
V R_4034 = default;
double GX_4035 = 0;
double GT_4036 = 0;
double GB_4037 = 0;
V ROWS_4038 = default;
JsStrBuf s_4039 = null;
JsStrBuf sc_4040 = null;
V lettuce_4041 = default;
V kale_4042 = default;
V straw_4043 = default;
V ROWP_4044 = default;
R_4034 = Call(rng_13, V.Undef, ((V)("khy")));
GX_4035 = 76D;
GT_4036 = (-40D);
GB_4037 = 90D;
ROWS_4038 = Arr(((V)((-16D))), ((V)(12D)), ((V)(40D)), ((V)(68D)));
s_4039 = new JsStrBuf(JsStrBuf.Begin().S("<defs>").V(WDEF_3162).S("<linearGradient id=\"k\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#a8c8e0\"/><stop offset=\"0.5\" stop-color=\"#f6dcb0\"/><stop offset=\"0.75\" stop-color=\"#f8c890\"/><stop offset=\"1\" stop-color=\"#e8b47a\"/></linearGradient><radialGradient id=\"sun\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff6d8\"/><stop offset=\"0.3\" stop-color=\"#ffdc98\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#ffc878\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"bg\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff2c0\"/><stop offset=\"0.35\" stop-color=\"#e8bc62\"/><stop offset=\"0.7\" stop-color=\"#b08032\"/><stop offset=\"1\" stop-color=\"#7a5418\"/></linearGradient><linearGradient id=\"bv\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8a6420\"/><stop offset=\"0.45\" stop-color=\"#f6dc96\"/><stop offset=\"1\" stop-color=\"#9a7228\"/></linearGradient>").S("<linearGradient id=\"gw\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffe2a0\" stop-opacity=\"0.32\"/><stop offset=\"1\" stop-color=\"#ffe2a0\" stop-opacity=\"0\"/></linearGradient><linearGradient id=\"bz\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#7a5a34\"/><stop offset=\"1\" stop-color=\"#3a2a18\"/></linearGradient>").S("<radialGradient id=\"lt\" cx=\"50%\" cy=\"70%\" r=\"60%\"><stop offset=\"0\" stop-color=\"#d8f0a0\"/><stop offset=\"0.6\" stop-color=\"#9ccc5a\"/><stop offset=\"1\" stop-color=\"#6a9a3a\"/></radialGradient><clipPath id=\"gc\"><rect x=\"-76\" y=\"-40\" width=\"152\" height=\"130\"/></clipPath></defs>").End());
s_4039.S("<rect x=\"-80\" y=\"-44\" width=\"160\" height=\"142\" fill=\"#000000\" opacity=\"0.16\" filter=\"url(#b2)\"/>");
sc_4040 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"-76\" y=\"-40\" width=\"152\" height=\"130\" fill=\"url(#k)\"/><circle cx=\"-34\" cy=\"34\" r=\"34\" fill=\"url(#sun)\"/><circle cx=\"-34\" cy=\"34\" r=\"5\" fill=\"#fff4d0\"/>").V(Call(drift_3168, V.Undef, Add(Add(Call(cloud_3167, V.Undef, ((V)((-50D))), ((V)((-28D))), ((V)(1.1)), ((V)("#fbeedc"))), Call(cloud_3167, V.Undef, ((V)(10D)), ((V)((-32D))), ((V)(0.8)), ((V)("#fbeedc")))), Call(cloud_3167, V.Undef, ((V)(46D)), ((V)((-20D))), ((V)(0.7)), ((V)("#f8e6d0")))), ((V)(152D)), ((V)(120D)))).End());
sc_4040.S("<g>").V(Call(at_47, V.Undef, ((V)("translate")), ((V)("-90 0;90 -10")), ((V)(40D)))).V(Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis4052, int _argc4045, V i_4051, V _a4048, V _a4049, V _a4050, V[] _rest4046) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").N((ToNum(i_4051) * 5D)).S(" ").N(((ToNum(i_4051) * 2D) - 22D)).S("q1 -1 2 0q1 -1 2 0\" stroke=\"#5a4a3a\" stroke-width=\"0.3\" fill=\"none\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
sc_4040.S("<path d=\"M-76 30Q-50 20 -26 28T22 22T76 26V90H-76Z\" fill=\"#b8a8a8\" opacity=\"0.7\"/><path d=\"M-76 38Q-40 32 0 37T76 35V90H-76Z\" fill=\"#9ab0b8\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis4060, int _argc4053, V i_4059, V _a4056, V _a4057, V _a4058, V[] _rest4054) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").N(((-60D) + (ToNum(i_4059) * 22D))).S(" ").N((40D + (ToNum(i_4059) % 2D))).S("h").N((8D + ((ToNum(i_4059) % 3D) * 3D))).S("\" stroke=\"#fff2d0\" stroke-width=\"0.4\" opacity=\"0.5\">").V(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.2;0.6;0.2")), Add(((V)(5D)), i_4059), i_4059, Call(SPL_15, V.Undef, ((V)(2D))))).S("</path>").End()));
}, 1, "", true)), "join", ((V)(""))));
sc_4040.S("<path d=\"M-76 50Q-30 42 10 48T76 46V90H-76Z\" fill=\"#a8b06a\"/><path d=\"M-76 62Q-20 54 30 60T76 58V90H-76Z\" fill=\"#8a9a52\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(14D)), Fn((V _arrowThis4068, int _argc4061, V i_4067, V _a4064, V _a4065, V _a4066, V[] _rest4062) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M-76 ").N((52D + (ToNum(i_4067) * 2.8))).S("Q0 ").N((44D + (ToNum(i_4067) * 3D))).S(" 76 ").N((50D + (ToNum(i_4067) * 2.8))).S("\" stroke=\"#6a7a3a\" stroke-width=\"0.3\" fill=\"none\" opacity=\"0.45\"/>").End()));
}, 1, "", true)), "join", ((V)(""))));
sc_4040.V(Invoke(Invoke(Arr(Arr(((V)((-62D))), ((V)(50D))), Arr(((V)((-56D))), ((V)(52D))), Arr(((V)(48D)), ((V)(48D))), Arr(((V)(56D)), ((V)(50D))), Arr(((V)(62D)), ((V)(49D)))), "map", Fn((V _arrowThis4081, int _argc4069, V _a4071, V i_4075, V _a4073, V _a4074, V[] _rest4070) => {
V x_4078 = default;
V y_4080 = default;
{ V _t4076 = ListOf(_a4071);
{ V _t4077 = GetIdx(_t4076, 0D);
x_4078 = _t4077; }
{ V _t4079 = GetIdx(_t4076, 1D);
y_4080 = _t4079; }
}
return Call(sway_3169, V.Undef, x_4078, y_4080, ((V)(1D)), ((V)(1.2)), Add(((V)(5D)), i_4075), i_4075, ((V)("<path d=\"M0 0Q-1.6 -6 0 -12Q1.6 -6 0 0Z\" fill=\"#4a6a3a\"/><path d=\"M0 0Q-0.6 -6 0 -11\" stroke=\"#6a8a4a\" stroke-width=\"0.3\" fill=\"none\"/>")));
}, 2, "", true)), "join", ((V)(""))));
s_4039.S("<g clip-path=\"url(#gc)\">").S(sc_4040.Str).S("<rect x=\"-76\" y=\"-40\" width=\"152\" height=\"130\" fill=\"url(#gref)\" opacity=\"0.6\"/></g>");
Invoke(Arr(((V)((-56D))), ((V)((-19D))), ((V)(19D)), ((V)(56D))), "forEach", Fn((V _arrowThis4089, int _argc4082, V x_4088, V _a4085, V _a4086, V _a4087, V[] _rest4083) => {
return ((V)(s_4039.S("<rect x=\"").N((ToNum(x_4088) - 0.5)).S("\" y=\"-40\" width=\"1\" height=\"130\" fill=\"url(#bv)\"/>").Str));
}, 1, "", true));
lettuce_4041 = Fn((V _arrowThis4096, int _argc4090, V _a4092, V _a4093, V _a4094, V _a4095, V[] _rest4091) => {
JsStrBuf o_4097 = null;
o_4097 = new JsStrBuf("");
{
double i_4098 = 0;
i_4098 = 0D;
while (true) {
if (!((i_4098 < 9D))) break;
double a_4100 = 0;
double d_4101 = 0;
a_4100 = (((-PI_11) / 2D) + ((i_4098 - 4D) * 0.36));
d_4101 = (NumTruthy((i_4098 % 2D)) ? 2.4 : 3.2);
o_4097.S("<ellipse cx=\"").V(Call(f1_16, V.Undef, ((V)((FdLibm.Cos(a_4100) * d_4101))))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)((((FdLibm.Sin(a_4100) * d_4101) * 0.8) - 1D))))).S("\" rx=\"2.2\" ry=\"1.7\" transform=\"rotate(").V(Call(f1_16, V.Undef, ((V)((((a_4100 * 180D) / PI_11) + 90D))))).S(" ").V(Call(f1_16, V.Undef, ((V)((FdLibm.Cos(a_4100) * d_4101))))).S(" ").V(Call(f1_16, V.Undef, ((V)((((FdLibm.Sin(a_4100) * d_4101) * 0.8) - 1D))))).S(")\" fill=\"url(#lt)\" stroke=\"#c8e890\" stroke-width=\"0.2\"/>");
i_4098++;
}
}
return ((V)(string.Concat(o_4097.Str, "<ellipse cy=\"-2.2\" rx=\"1.6\" ry=\"1.2\" fill=\"#e0f4b0\"/>")));
return default;
}, 0, "", true);
kale_4042 = Fn((V _arrowThis4108, int _argc4102, V _a4104, V _a4105, V _a4106, V _a4107, V[] _rest4103) => {
return Invoke(Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis4116, int _argc4109, V i_4115, V _a4112, V _a4113, V _a4114, V[] _rest4110) => {
double a_4117 = 0;
a_4117 = ((ToNum(i_4115) - 2.5) * 0.3);
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 0Q").V(Call(f1_16, V.Undef, ((V)(((FdLibm.Sin(a_4117) * 4D) - 1D))))).S(" ").V(Call(f1_16, V.Undef, ((V)((-4D))))).S(" ").V(Call(f1_16, V.Undef, ((V)((FdLibm.Sin(a_4117) * 6D))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((-7D) - (ToNum(i_4115) % 2D)))))).S("Q").V(Call(f1_16, V.Undef, ((V)(((FdLibm.Sin(a_4117) * 4D) + 1.4))))).S(" -3 0 0Z\" fill=\"").S((NumTruthy((ToNum(i_4115) % 2D)) ? "#3a6a5a" : "#4a7a64")).S("\" stroke=\"#6a9a84\" stroke-width=\"0.25\" stroke-dasharray=\"0.5 0.3\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
}, 0, "", true);
straw_4043 = Fn((V _arrowThis4125, int _argc4118, V j_4124, V _a4121, V _a4122, V _a4123, V[] _rest4119) => {
V o_4126 = default;
V berry_4127 = default;
o_4126 = Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis4135, int _argc4128, V i_4134, V _a4131, V _a4132, V _a4133, V[] _rest4129) => {
double a_4136 = 0;
a_4136 = ((ToNum(i_4134) - 1D) * 0.7);
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 0L").V(Call(f1_16, V.Undef, ((V)((FdLibm.Sin(a_4136) * 3D))))).S(" ").V(Call(f1_16, V.Undef, ((V)((-3.4))))).S("\" stroke=\"#4a7a2a\" stroke-width=\"0.3\"/><ellipse cx=\"").V(Call(f1_16, V.Undef, ((V)((FdLibm.Sin(a_4136) * 3D))))).S("\" cy=\"-3.8\" rx=\"1.5\" ry=\"1.1\" fill=\"#4e8a34\" stroke=\"#3a6a24\" stroke-width=\"0.15\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
o_4126 = ((V)(JsStrBuf.Begin().V(o_4126).S("<path d=\"M0.6 0.4Q2.6 3 2.2 6.4M-0.4 0.4Q-1.6 2.4 -1.2 4.6\" stroke=\"#6a8a3a\" stroke-width=\"0.25\" fill=\"none\"/>").End()));
berry_4127 = Fn((V _arrowThis4147, int _argc4137, V x_4143, V y_4144, V c_4145, V ani_4146, V[] _rest4138) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(x_4143).S(" ").N((ToNum(y_4144) - 0.6)).S("q1.2 0 1 1.2q-0.3 1.4 -1 1.8q-0.7 -0.4 -1 -1.8q-0.2 -1.2 1 -1.2Z\" fill=\"").V(c_4145).S("\">").V((Truthy(ani_4146) ? Call(an_14, V.Undef, ((V)("fill")), ((V)("#b8d86a;#e8463c;#d8303a;#b8d86a")), ((V)(24D)), ((V)((ToNum(j_4124) * 3D))), ((V)(" keyTimes=\"0;0.4;0.85;1\""))) : ((V)("")))).S("</path><circle cx=\"").N((ToNum(x_4143) - 0.3)).S("\" cy=\"").V(Add(y_4144, ((V)(0.2)))).S("\" r=\"0.12\" fill=\"#fff4b0\"/><circle cx=\"").V(Add(x_4143, ((V)(0.3)))).S("\" cy=\"").V(Add(y_4144, ((V)(0.6)))).S("\" r=\"0.12\" fill=\"#fff4b0\"/><path d=\"M").N((ToNum(x_4143) - 0.6)).S(" ").N((ToNum(y_4144) - 0.6)).S("l0.6 0.3l0.6 -0.3\" stroke=\"#4a8a2a\" stroke-width=\"0.3\" fill=\"none\"/>").End()));
}, 4, "", true);
o_4126 = ((V)(JsStrBuf.Begin().V(o_4126).V(Add(Call(berry_4127, V.Undef, ((V)(2.2)), ((V)(6.6)), ((V)("#e8463c")), ((V)((ToNum(j_4124) % 2D)))), Call(berry_4127, V.Undef, ((V)((-1.2))), ((V)(4.8)), ((V)("#d8303a")), ((V)(0D))))).S("<circle cx=\"-2\" cy=\"-1\" r=\"0.7\" fill=\"#ffffff\"/><circle cx=\"-2\" cy=\"-1\" r=\"0.25\" fill=\"#f2c83a\"/>").End()));
return o_4126;
return default;
}, 1, "", true);
ROWP_4044 = Arr(Arr(((V)("L")), ((V)("basil"))), Arr(((V)("S"))), Arr(((V)("K")), ((V)("pars"))), Arr(((V)("basil")), ((V)("thyme")), ((V)("mint")), ((V)("L"))));
Invoke(ROWS_4038, "forEach", Fn((V _arrowThis4156, int _argc4148, V y_4154, V ri_4155, V _a4152, V _a4153, V[] _rest4149) => {
V kinds_4157 = default;
kinds_4157 = GetK(ROWP_4044, ri_4155);
s_4039.S("<g filter=\"url(#b2)\"><path d=\"M-74 ").V(Add(y_4154, ((V)(3.6)))).S("H74L80 ").V(Add(y_4154, ((V)(26D)))).S("H-80Z\" fill=\"url(#gw)\" opacity=\"0.9\">").V(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.7;1;0.7")), ((V)(7D)), ((V)((ToNum(ri_4155) * 1.4))), Call(SPL_15, V.Undef, ((V)(2D))))).S("</path></g>");
{
double i_4158 = 0;
i_4158 = 0D;
while (true) {
if (!((i_4158 < 10D))) break;
double x_4160 = 0;
V k_4161 = default;
double ph_4162 = 0;
x_4160 = ((-67.5) + (i_4158 * 15D));
k_4161 = GetIdx(kinds_4157, (i_4158 % ToNum(Get(kinds_4157, "length"))));
ph_4162 = (((i_4158 * 0.37) + (ToNum(ri_4155) * 0.6)) % 3D);
s_4039.S("<ellipse cx=\"").V(Call(f1_16, V.Undef, ((V)(x_4160)))).S("\" cy=\"").V(Call(f1_16, V.Undef, Add(y_4154, ((V)(0.2))))).S("\" rx=\"2.6\" ry=\"0.6\" fill=\"#2a2014\"/>");
s_4039.V((SEqS(k_4161, "L") ? Call(sway_3169, V.Undef, ((V)(x_4160)), y_4154, ((V)(1.75)), ((V)(1.2)), ((V)((5D + ph_4162))), ((V)(ph_4162)), Call(lettuce_4041, V.Undef)) : (SEqS(k_4161, "K") ? Call(sway_3169, V.Undef, ((V)(x_4160)), y_4154, ((V)(1.6)), ((V)(1.8)), ((V)((4.6 + ph_4162))), ((V)(ph_4162)), Call(kale_4042, V.Undef)) : (SEqS(k_4161, "S") ? Call(sway_3169, V.Undef, ((V)(x_4160)), y_4154, ((V)(1.7)), ((V)(2.4)), ((V)((5D + ph_4162))), ((V)(ph_4162)), Call(straw_4043, V.Undef, ((V)(i_4158)))) : Call(herb_3174, V.Undef, k_4161, ((V)(x_4160)), y_4154, ((V)(1.15)), ((V)(ph_4162)))))));
i_4158++;
}
}
s_4039.S("<rect x=\"-76\" y=\"").V(y_4154).S("\" width=\"152\" height=\"3.4\" rx=\"1.2\" fill=\"url(#bg)\"/><rect x=\"-76\" y=\"").V(Add(y_4154, ((V)(0.4)))).S("\" width=\"152\" height=\"0.4\" fill=\"#fff6d0\" opacity=\"0.8\"/><rect x=\"-76\" y=\"").V(Add(y_4154, ((V)(3.4)))).S("\" width=\"152\" height=\"0.9\" fill=\"#3a2a14\" opacity=\"0.5\"/>");
s_4039.S("<rect x=\"-72\" y=\"").V(Add(y_4154, ((V)(4.4)))).S("\" width=\"144\" height=\"0.9\" rx=\"0.45\" fill=\"#8a6420\"/><rect x=\"-71\" y=\"").V(Add(y_4154, ((V)(5D)))).S("\" width=\"142\" height=\"0.35\" rx=\"0.18\" fill=\"#fff2c8\"/>");
if (LtN(ri_4155, 3D)) {
double x_4163 = 0;
x_4163 = (NumTruthy((ToNum(ri_4155) % 2D)) ? (-73D) : 73D);
s_4039.S("<path d=\"M").N(x_4163).S(" ").V(Add(y_4154, ((V)(3.4)))).S("V").V(GetK(ROWS_4038, Add(ri_4155, ((V)(1D))))).S("\" stroke=\"#e8f2f4\" stroke-width=\"0.5\" stroke-dasharray=\"1.2 0.9\" opacity=\"0.6\"><animate attributeName=\"stroke-dashoffset\" values=\"0;-4.2\" dur=\"0.9s\" repeatCount=\"indefinite\"/></path>");
}
Invoke(Arr(((V)((-38D))), ((V)(0D)), ((V)(38D))), "forEach", Fn((V _arrowThis4172, int _argc4164, V x_4170, V j_4171, V _a4168, V _a4169, V[] _rest4165) => {
return ((V)(s_4039.S("<ellipse cx=\"").V(Add(x_4170, ((V)((ToNum(ri_4155) * 4D))))).S("\" cy=\"").N((ToNum(y_4154) - 4D)).S("\" rx=\"1\" ry=\"0.6\" fill=\"#ffffff\" opacity=\"0\">").V(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0;0;0.45;0")), ((V)(9D)), ((V)(((ToNum(ri_4155) * 1.7) + (ToNum(j_4171) * 2.9)))), ((V)(" keyTimes=\"0;0.8;0.86;1\"")))).V(Call(an_14, V.Undef, ((V)("rx")), ((V)("1;1;1;7")), ((V)(9D)), ((V)(((ToNum(ri_4155) * 1.7) + (ToNum(j_4171) * 2.9)))), ((V)(" keyTimes=\"0;0.8;0.86;1\"")))).V(Call(an_14, V.Undef, ((V)("ry")), ((V)("0.6;0.6;0.6;3")), ((V)(9D)), ((V)(((ToNum(ri_4155) * 1.7) + (ToNum(j_4171) * 2.9)))), ((V)(" keyTimes=\"0;0.8;0.86;1\"")))).S("</ellipse>").Str));
}, 2, "", true));
return default;
}, 2, "", true));
s_4039.S("<rect x=\"-78\" y=\"84\" width=\"156\" height=\"12\" fill=\"url(#bz)\"/><rect x=\"-78\" y=\"84\" width=\"156\" height=\"0.6\" fill=\"#d8b070\"/><rect x=\"-78\" y=\"95.4\" width=\"156\" height=\"0.6\" fill=\"#ffe2a0\" opacity=\"0.7\">").V(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.5;0.8;0.5")), ((V)(6D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))).S("</rect>");
s_4039.V(Invoke(Call(rep_18, V.Undef, ((V)(26D)), Fn((V _arrowThis4180, int _argc4173, V i_4179, V _a4176, V _a4177, V _a4178, V[] _rest4174) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").N(((-75D) + (ToNum(i_4179) * 5.8))).S("\" y=\"86.2\" width=\"0.5\" height=\"7\" fill=\"#2a1e10\" opacity=\"0.5\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<rect x=\"46\" y=\"87\" width=\"24\" height=\"5.6\" rx=\"0.6\" fill=\"url(#bv)\"/><text x=\"58\" y=\"90.8\" text-anchor=\"middle\" font-family=\"Georgia,'Times New Roman',serif\" font-size=\"2\" fill=\"#4a3210\" letter-spacing=\"0.1\">pH 6.1 \u00b7 22\u00b0C</text>");
s_4039.S("<rect x=\"-77\" y=\"-41\" width=\"154\" height=\"132\" fill=\"none\" stroke=\"url(#bv)\" stroke-width=\"1.2\"/><rect x=\"-78.4\" y=\"-42.4\" width=\"156.8\" height=\"134.8\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.2\" stroke-width=\"0.6\"/>");
return NewObj(2).Put("vb", Arr(((V)((-82D))), ((V)((-46D))), ((V)(164D)), ((V)(144D)))).Put("s", ((V)(s_4039.Str))).V;
return default;
}, 0, "", true));
}
{
V camW_4181 = default;
V tanF_4182 = default;
V FR_4183 = default;
V box3_4184 = default;
V cyl3_4185 = default;
V WD_4186 = default;
V ext_4187 = default;
V DEF19_4188 = default;
V PP_4189 = default;
V poly3_4190 = default;
V line3_4191 = default;
V swayAt_4192 = default;
V ryOf_4193 = default;
V ell3_4194 = default;
V jar_4195 = default;
V mugH_4196 = default;
V mugC_4197 = default;
{ V _t4198 = H_12;
if (_t4198.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4198));
{ V _t4199 = Get(_t4198, "cam");
camW_4181 = _t4199; }
{ V _t4200 = Get(_t4198, "tanF");
tanF_4182 = _t4200; }
{ V _t4201 = Get(_t4198, "FR");
FR_4183 = _t4201; } }
{ V _t4202 = Get(RD_8, "H15");
if (_t4202.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4202));
{ V _t4203 = Get(_t4202, "box3");
box3_4184 = _t4203; }
{ V _t4204 = Get(_t4202, "cyl3");
cyl3_4185 = _t4204; } }
{ V _t4205 = Get(RD_8, "H12");
if (_t4205.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4205));
{ V _t4206 = Get(_t4205, "WD");
WD_4186 = _t4206; } }
{ V _t4207 = Get(RD_8, "H11");
if (_t4207.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4207));
{ V _t4208 = Get(_t4207, "ext");
ext_4187 = _t4208; } }
DEF19_4188 = Get(Get(RD_8, "H19"), "DEF19");
PP_4189 = Fn((V _arrowThis4217, int _argc4209, V C_4215, V p_4216, V _a4213, V _a4214, V[] _rest4210) => {
V q_4218 = default;
q_4218 = Invoke(C_4215, "P", p_4216);
return ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, GetIdx(q_4218, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(q_4218, 1D))).End()));
return default;
}, 2, "", true);
poly3_4190 = Fn((V _arrowThis4229, int _argc4219, V C_4225, V P_4226, V fill_4227, V ex_4228, V[] _rest4220) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Invoke(Invoke(P_4226, "map", Fn((V _arrowThis4237, int _argc4230, V p_4236, V _a4233, V _a4234, V _a4235, V[] _rest4231) => {
return Call(PP_4189, V.Undef, C_4225, p_4236);
}, 1, "", true)), "join", ((V)("L")))).S("Z\" fill=\"").V(fill_4227).S("\"").S((Truthy(ex_4228) ? JsStrBuf.Begin().S(" ").V(ex_4228).End() : "")).S("/>").End()));
}, 4, "", true);
line3_4191 = Fn((V _arrowThis4249, int _argc4238, V C_4244, V P_4245, V w_4246, V col_4247, V[] _rest4239) => {
V ex_4248 = default;
ex_4248 = (_argc4238 > 4 ? _rest4239[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Invoke(Invoke(P_4245, "map", Fn((V _arrowThis4257, int _argc4250, V p_4256, V _a4253, V _a4254, V _a4255, V[] _rest4251) => {
return Call(PP_4189, V.Undef, C_4244, p_4256);
}, 1, "", true)), "join", ((V)("L")))).S("\" stroke=\"").V(col_4247).S("\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(w_4246) * ToNum(Get(C_4244, "k"))))))).S("\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"").S((Truthy(ex_4248) ? JsStrBuf.Begin().S(" ").V(ex_4248).End() : "")).S("/>").End()));
}, 5, "", true);
swayAt_4192 = Fn((V _arrowThis4270, int _argc4258, V C_4264, V p_4265, V a_4266, V d_4267, V[] _rest4259) => {
V q_4271 = default;
V o_4272 = default;
V ph_4268 = default;
V inner_4269 = default;
ph_4268 = (_argc4258 > 4 ? _rest4259[0] : V.Undef);
inner_4269 = (_argc4258 > 5 ? _rest4259[1] : V.Undef);
q_4271 = Invoke(C_4264, "P", p_4265);
o_4272 = ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, GetIdx(q_4271, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(q_4271, 1D))).End()));
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(at_47, V.Undef, ((V)("rotate")), ((V)(JsStrBuf.Begin().N((-ToNum(a_4266))).S(" ").V(o_4272).S(";").V(a_4266).S(" ").V(o_4272).S(";").N((-ToNum(a_4266))).S(" ").V(o_4272).End())), d_4267, ((V)((-ToNum(ph_4268)))), Call(SPL_15, V.Undef, ((V)(2D))))).V(inner_4269).S("</g>").End()));
return default;
}, 6, "", true);
ryOf_4193 = Fn((V _arrowThis4284, int _argc4273, V C_4279, V x_4280, V y_4281, V z_4282, V[] _rest4274) => {
V a_4285 = default;
V b_4286 = default;
V r_4283 = default;
r_4283 = (_argc4273 > 4 ? _rest4274[0] : V.Undef);
a_4285 = Invoke(C_4279, "P", Arr(x_4280, y_4281, z_4282));
b_4286 = Invoke(C_4279, "P", Arr(x_4280, y_4281, Add(z_4282, r_4283)));
return ((V)(System.Math.Abs((ToNum(GetIdx(b_4286, 1D)) - ToNum(GetIdx(a_4285, 1D))))));
return default;
}, 5, "", true);
ell3_4194 = Fn((V _arrowThis4300, int _argc4287, V C_4293, V x_4294, V y_4295, V z_4296, V[] _rest4288) => {
V q_4301 = default;
V r_4297 = default;
V fill_4298 = default;
V ex_4299 = default;
r_4297 = (_argc4287 > 4 ? _rest4288[0] : V.Undef);
fill_4298 = (_argc4287 > 5 ? _rest4288[1] : V.Undef);
ex_4299 = (_argc4287 > 6 ? _rest4288[2] : V.Undef);
q_4301 = Invoke(C_4293, "P", Arr(x_4294, y_4295, z_4296));
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_16, V.Undef, GetIdx(q_4301, 0D))).S("\" cy=\"").V(Call(f1_16, V.Undef, GetIdx(q_4301, 1D))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(r_4297) * ToNum(Get(C_4293, "k"))))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)(Max(0.2, ToNum(Call(ryOf_4193, V.Undef, C_4293, x_4294, y_4295, z_4296, r_4297))))))).S("\" fill=\"").V(fill_4298).S("\"").S((Truthy(ex_4299) ? JsStrBuf.Begin().S(" ").V(ex_4299).End() : "")).S("/>").End()));
return default;
}, 7, "", true);
jar_4195 = Fn((V _arrowThis4316, int _argc4302, V C_4308, V x_4309, V y_4310, V z_4311, V[] _rest4303) => {
V b_4317 = default;
V t_4318 = default;
double rx_4319 = 0;
double ry_4320 = 0;
V g_4321 = default;
V body_4322 = default;
V r_4312 = default;
V h_4313 = default;
V inner_4314 = default;
V tint_4315 = default;
r_4312 = (_argc4302 > 4 ? _rest4303[0] : V.Undef);
h_4313 = (_argc4302 > 5 ? _rest4303[1] : V.Undef);
inner_4314 = (_argc4302 > 6 ? _rest4303[2] : V.Undef);
tint_4315 = (_argc4302 > 7 ? _rest4303[3] : V.Undef);
b_4317 = Invoke(C_4308, "P", Arr(x_4309, y_4310, z_4311));
t_4318 = Invoke(C_4308, "P", Arr(x_4309, Add(y_4310, h_4313), z_4311));
rx_4319 = (ToNum(r_4312) * ToNum(Get(C_4308, "k")));
ry_4320 = Max(0.3, ToNum(Call(ryOf_4193, V.Undef, C_4308, x_4309, y_4310, z_4311, r_4312)));
g_4321 = (tint_4315 is var _t4323 && Truthy(_t4323) ? _t4323 : ((V)("#dcefee")));
body_4322 = ((V)(JsStrBuf.Begin().S("M").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(t_4318, 0D)) - rx_4319))))).S(" ").V(Call(f1_16, V.Undef, GetIdx(t_4318, 1D))).S("L").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(b_4317, 0D)) - rx_4319))))).S(" ").V(Call(f1_16, V.Undef, GetIdx(b_4317, 1D))).S("A").V(Call(f1_16, V.Undef, ((V)(rx_4319)))).S(" ").V(Call(f1_16, V.Undef, ((V)(ry_4320)))).S(" 0 0 0 ").V(Call(f1_16, V.Undef, Add(GetIdx(b_4317, 0D), ((V)(rx_4319))))).S(" ").V(Call(f1_16, V.Undef, GetIdx(b_4317, 1D))).S("L").V(Call(f1_16, V.Undef, Add(GetIdx(t_4318, 0D), ((V)(rx_4319))))).S(" ").V(Call(f1_16, V.Undef, GetIdx(t_4318, 1D))).S("A").V(Call(f1_16, V.Undef, ((V)(rx_4319)))).S(" ").V(Call(f1_16, V.Undef, ((V)(ry_4320)))).S(" 0 0 1 ").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(t_4318, 0D)) - rx_4319))))).S(" ").V(Call(f1_16, V.Undef, GetIdx(t_4318, 1D))).S("Z").End()));
return ((V)(JsStrBuf.Begin().V((inner_4314 is var _t4324 && Truthy(_t4324) ? _t4324 : ((V)("")))).S("<path d=\"").V(body_4322).S("\" fill=\"").V(g_4321).S("\" opacity=\"0.32\"/><path d=\"").V(body_4322).S("\" fill=\"none\" stroke=\"#9fbcbc\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.25 * ToNum(Get(C_4308, "k"))))))).S("\" opacity=\"0.8\"/>").S("<ellipse cx=\"").V(Call(f1_16, V.Undef, GetIdx(t_4318, 0D))).S("\" cy=\"").V(Call(f1_16, V.Undef, GetIdx(t_4318, 1D))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)(rx_4319)))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)(ry_4320)))).S("\" fill=\"none\" stroke=\"#f4fbfb\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.45 * ToNum(Get(C_4308, "k"))))))).S("\" opacity=\"0.9\"/>").S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(b_4317, 0D)) - (rx_4319 * 0.62)))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(b_4317, 1D)) - (0.6 * ToNum(Get(C_4308, "k")))))))).S("L").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(t_4318, 0D)) - (rx_4319 * 0.62)))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(t_4318, 1D), ((V)((0.8 * ToNum(Get(C_4308, "k")))))))).S("\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.55 * ToNum(Get(C_4308, "k"))))))).S("\" opacity=\"0.75\"/><path d=\"M").V(Call(f1_16, V.Undef, Add(GetIdx(b_4317, 0D), ((V)((rx_4319 * 0.5)))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(b_4317, 1D)) - (1D * ToNum(Get(C_4308, "k")))))))).S("L").V(Call(f1_16, V.Undef, Add(GetIdx(t_4318, 0D), ((V)((rx_4319 * 0.5)))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(t_4318, 1D), ((V)((2D * ToNum(Get(C_4308, "k")))))))).S("\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.25 * ToNum(Get(C_4308, "k"))))))).S("\" opacity=\"0.5\"/>").End()));
return default;
}, 8, "", true);
mugH_4196 = Fn((V _arrowThis4339, int _argc4325, V C_4331, V x_4332, V y_4333, V z_4334, V[] _rest4326) => {
V P_4340 = default;
V r_4335 = default;
V h_4336 = default;
V col_4337 = default;
V side_4338 = default;
r_4335 = (_argc4325 > 4 ? _rest4326[0] : V.Undef);
h_4336 = (_argc4325 > 5 ? _rest4326[1] : V.Undef);
col_4337 = (_argc4325 > 6 ? _rest4326[2] : V.Undef);
side_4338 = (_argc4325 > 7 ? _rest4326[3] : V.Undef);
P_4340 = Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis4348, int _argc4341, V i_4347, V _a4344, V _a4345, V _a4346, V[] _rest4342) => {
double a_4349 = 0;
a_4349 = (((-PI_11) / 2D) + ((ToNum(i_4347) / 8D) * PI_11));
return Arr(Add(x_4332, ((V)((ToNum(side_4338) * ToNum(Add(r_4335, ((V)(((FdLibm.Cos(a_4349) * ToNum(h_4336)) * 0.28))))))))), Add(Add(y_4333, ((V)((ToNum(h_4336) * 0.5)))), ((V)(((FdLibm.Sin(a_4349) * ToNum(h_4336)) * 0.3)))), z_4334);
return default;
}, 1, "", true));
return Add(Call(line3_4191, V.Undef, C_4331, P_4340, ((V)(0.9)), Call(shade_10, V.Undef, col_4337, ((V)(0.6)))), Call(line3_4191, V.Undef, C_4331, P_4340, ((V)(0.55)), col_4337));
return default;
}, 8, "", true);
mugC_4197 = Fn((V _arrowThis4364, int _argc4350, V C_4356, V x_4357, V y_4358, V z_4359, V[] _rest4351) => {
V r_4360 = default;
V h_4361 = default;
V col_4362 = default;
V inner_4363 = default;
r_4360 = (_argc4350 > 4 ? _rest4351[0] : V.Undef);
h_4361 = (_argc4350 > 5 ? _rest4351[1] : V.Undef);
col_4362 = (_argc4350 > 6 ? _rest4351[2] : V.Undef);
inner_4363 = (_argc4350 > 7 ? _rest4351[3] : V.Undef);
return Call(cyl3_4185, V.Undef, C_4356, Arr(x_4357, y_4358, z_4359), Arr(x_4357, Add(y_4358, h_4361), z_4359), r_4360, col_4362, NewObj(4).Put("n", ((V)(20D))).Put("mat", ((V)("gloss"))).Put("capCol", col_4362).Put("cap", Fn((V _arrowThis4372, int _argc4365, V cr_4371, V _a4368, V _a4369, V _a4370, V[] _rest4366) => {
return ((V)(JsStrBuf.Begin().S("<circle r=\"").V(Call(f1_16, V.Undef, cr_4371)).S("\" fill=\"").V(Call(shade_10, V.Undef, col_4362, ((V)(1.08)))).S("\"/><circle r=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(cr_4371) * 0.84))))).S("\" fill=\"").V((inner_4363 is var _t4373 && Truthy(_t4373) ? _t4373 : Call(shade_10, V.Undef, col_4362, ((V)(0.72))))).S("\"/>").End()));
}, 1, "cap", true)).V);
}, 8, "", true);
Set(N_70, "pine27", Fn((V _arrowThis4381, int _argc4374, V S_4380, V _a4377, V _a4378, V _a4379, V[] _rest4375) => {
V D_4382 = default;
D_4382 = NewObj(5).Put("w", ((V)(98D))).Put("d", ((V)(26D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(46D))).Put("build", Fn((V _arrowThis4389, int _argc4383, V _a4385, V _a4386, V _a4387, V _a4388, V[] _rest4384) => {
return Arr();
}, 0, "build", true)).V;
Set(D_4382, "fx", Fn((V _arrowThis4397, int _argc4390, V ctx_4396, V _a4393, V _a4394, V _a4395, V[] _rest4391) => {
V C_4398 = default;
V R_4399 = default;
double PY_4400 = 0;
double PT_4401 = 0;
double PZ_4402 = 0;
V PN_4403 = default;
V RU_4404 = default;
V s_4405 = default;
V rust_4406 = default;
V gr_4407 = default;
V knot_4408 = default;
V top_4409 = default;
V front_4410 = default;
V hk_4411 = default;
V hq_4412 = default;
V k_4413 = default;
V tw_4414 = default;
V sp_4415 = default;
double Y_4416 = 0;
V sp1_4417 = default;
double A_4418 = 0;
V ax_4419 = default;
double PX_4420 = 0;
double PZp_4421 = 0;
V leaf_4422 = default;
JsStrBuf pl_4423 = null;
C_4398 = Call(camW_4181, V.Undef, ctx_4396);
R_4399 = Call(rng_13, V.Undef, ((V)("pine27")));
PY_4400 = 14D;
PT_4401 = (PY_4400 + 2.6);
PZ_4402 = 17.4;
PN_4403 = ((V)("#dab27a"));
RU_4404 = ((V)("#6e3f26"));
Call(ext_4187, V.Undef, C_4398, Arr(Arr(((V)((-50D))), ((V)((PT_4401 + 22D))), ((V)(0D))), Arr(((V)(50D)), ((V)((-16D))), ((V)(0D)))));
s_4405 = Call(WD_4186, V.Undef, C_4398, ((V)((-47D))), ((V)((PY_4400 - 0.6))), ((V)(0.05)), ((V)("<rect width=\"94\" height=\"5\" rx=\"2\" fill=\"#000000\" opacity=\"0.32\" filter=\"url(#m10b3)\"/>")));
Invoke(Arr(((V)((-32D))), ((V)(32D))), "forEach", Fn((V _arrowThis4431, int _argc4424, V x_4430, V _a4427, V _a4428, V _a4429, V[] _rest4425) => {
s_4405 = Add(s_4405, Call(WD_4186, V.Undef, C_4398, ((V)((ToNum(x_4430) - 1.6))), ((V)((-8D))), ((V)(0.05)), ((V)("<path d=\"M0.4 0Q0.2 6 1.2 10Q0.6 16 1.6 22\" stroke=\"#8a4a22\" stroke-width=\"1.4\" fill=\"none\" opacity=\"0.32\" filter=\"url(#m12b1)\"/><path d=\"M2 0Q2.6 5 2.2 9\" stroke=\"#a85a28\" stroke-width=\"0.6\" fill=\"none\" opacity=\"0.3\"/>"))));
return default;
}, 1, "", true));
s_4405 = Add(s_4405, Call(WD_4186, V.Undef, C_4398, ((V)((-44D))), ((V)(6D)), ((V)(0.05)), ((V)("<path d=\"M0 0H18\" stroke=\"#5a5a5a\" stroke-width=\"0.25\" opacity=\"0.4\"/><circle cx=\"62\" cy=\"-3\" r=\"0.35\" fill=\"#4a4036\" opacity=\"0.7\"/><circle cx=\"66\" cy=\"-2.6\" r=\"0.35\" fill=\"#4a4036\" opacity=\"0.7\"/>"))));
rust_4406 = Fn((V _arrowThis4440, int _argc4432, V w_4438, V h_4439, V _a4436, V _a4437, V[] _rest4433) => {
return Invoke(Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis4447, int _argc4441, V _a4443, V _a4444, V _a4445, V _a4446, V[] _rest4442) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_4399, V.Undef)) * ToNum(w_4438)))))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_4399, V.Undef)) * ToNum(h_4439)))))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((0.3 + (ToNum(Call(R_4399, V.Undef)) * 0.5)))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)((0.3 + (ToNum(Call(R_4399, V.Undef)) * 0.7)))))).S("\" fill=\"").S((LtN(Call(R_4399, V.Undef), 0.5) ? "#b8622e" : "#3a2416")).S("\" opacity=\"0.7\"/>").End()));
}, 0, "", true)), "join", ((V)("")));
}, 2, "", true);
Invoke(Arr(((V)((-32D))), ((V)(32D))), "forEach", Fn((V _arrowThis4455, int _argc4448, V x_4454, V _a4451, V _a4452, V _a4453, V[] _rest4449) => {
V a_4456 = default;
V b_4457 = default;
V dv_4458 = default;
double L_4459 = 0;
V u_4460 = default;
s_4405 = Add(s_4405, Call(box3_4184, V.Undef, C_4398, NewObj(7).Put("c", Arr(x_4454, ((V)((-9D))), ((V)(1.2)))).Put("w", ((V)(1.9))).Put("h", ((V)((PY_4400 + 8.8)))).Put("d", ((V)(1.2))).Put("col", RU_4404).Put("r", ((V)(0.2))).Put("dec", NewObj(1).Put("f", Call(rust_4406, V.Undef, ((V)(1.9)), ((V)((PY_4400 + 9D))))).V).V));
Invoke(Arr(((V)((-6D))), ((V)(2D)), ((V)(9D))), "forEach", Fn((V _arrowThis4468, int _argc4461, V y_4467, V _a4464, V _a4465, V _a4466, V[] _rest4462) => {
return (s_4405 = Add(s_4405, Call(cyl3_4185, V.Undef, C_4398, Arr(x_4454, y_4467, ((V)(1.8))), Arr(x_4454, y_4467, ((V)(2.3))), ((V)(0.55)), ((V)("#5a5048")), NewObj(1).Put("n", ((V)(10D))).V)));
}, 1, "", true));
a_4456 = Arr(((V)(0D)), ((V)((-7D))), ((V)(1.8)));
b_4457 = Arr(((V)(0D)), ((V)((PY_4400 - 1.6))), ((V)(14.4)));
dv_4458 = Arr(((V)(0D)), ((V)((ToNum(GetIdx(b_4457, 1D)) - ToNum(GetIdx(a_4456, 1D))))), ((V)((ToNum(GetIdx(b_4457, 2D)) - ToNum(GetIdx(a_4456, 2D))))));
L_4459 = Hypot(ToNum(GetIdx(dv_4458, 1D)), ToNum(GetIdx(dv_4458, 2D)));
u_4460 = Arr(((V)(0D)), ((V)((ToNum(GetIdx(dv_4458, 1D)) / L_4459))), ((V)((ToNum(GetIdx(dv_4458, 2D)) / L_4459))));
s_4405 = Add(s_4405, Call(box3_4184, V.Undef, C_4398, NewObj(8).Put("c", Arr(x_4454, GetIdx(a_4456, 1D), GetIdx(a_4456, 2D))).Put("ax", Arr(Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), u_4460, Arr(((V)(0D)), ((V)((-ToNum(GetIdx(u_4460, 2D))))), GetIdx(u_4460, 1D)))).Put("w", ((V)(1.4))).Put("h", ((V)(L_4459))).Put("d", ((V)(0.9))).Put("col", Call(shade_10, V.Undef, RU_4404, ((V)(0.9)))).Put("r", ((V)(0.1))).Put("dec", NewObj(1).Put("f", Call(rust_4406, V.Undef, ((V)(1.4)), ((V)(L_4459)))).V).V));
s_4405 = Add(s_4405, Call(box3_4184, V.Undef, C_4398, NewObj(7).Put("c", Arr(x_4454, ((V)((PY_4400 - 1.6))), ((V)(8.6)))).Put("w", ((V)(1.9))).Put("h", ((V)(1.6))).Put("d", ((V)(14D))).Put("col", RU_4404).Put("r", ((V)(0.2))).Put("dec", NewObj(2).Put("f", Call(rust_4406, V.Undef, ((V)(14D)), ((V)(1.6)))).Put("t", Call(rust_4406, V.Undef, ((V)(1.9)), ((V)(14D)))).V).V));
return default;
}, 1, "", true));
gr_4407 = Fn((V _arrowThis4479, int _argc4469, V w_4475, V h_4476, V n_4477, V sd_4478, V[] _rest4470) => {
V Q_4480 = default;
JsStrBuf o_4481 = null;
Q_4480 = Call(rng_13, V.Undef, sd_4478);
o_4481 = new JsStrBuf("");
{
double i_4482 = 0;
i_4482 = 0D;
while (true) {
if (!(Lt(((V)(i_4482)), n_4477))) break;
double y_4484 = 0;
double a_4485 = 0;
y_4484 = (ToNum(Call(Q_4480, V.Undef)) * ToNum(h_4476));
a_4485 = ((ToNum(Call(Q_4480, V.Undef)) - 0.5) * 0.6);
o_4481.S("<path d=\"M0 ").V(Call(f1_16, V.Undef, ((V)(y_4484)))).S("Q").V(Call(f1_16, V.Undef, ((V)((ToNum(w_4475) * 0.3))))).S(" ").V(Call(f1_16, V.Undef, ((V)((y_4484 + a_4485))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(w_4475) * 0.55))))).S(" ").V(Call(f1_16, V.Undef, ((V)((y_4484 - (a_4485 * 0.6)))))).S("T").V(Call(f1_16, V.Undef, w_4475)).S(" ").V(Call(f1_16, V.Undef, ((V)((y_4484 + (a_4485 * 0.3)))))).S("\" stroke=\"").S((LtN(Call(Q_4480, V.Undef), 0.5) ? "#a8783e" : "#c2914e")).S("\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.06 + (ToNum(Call(Q_4480, V.Undef)) * 0.12)))))).S("\" fill=\"none\" opacity=\"0.7\"/>");
i_4482++;
}
}
return ((V)(o_4481.Str));
return default;
}, 4, "", true);
knot_4408 = Fn((V _arrowThis4495, int _argc4486, V x_4492, V y_4493, V r_4494, V _a4491, V[] _rest4487) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(x_4492).S("\" cy=\"").V(y_4493).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(r_4494) * 1.7))))).S("\" ry=\"").V(r_4494).S("\" fill=\"#a8743a\" opacity=\"0.6\"/><ellipse cx=\"").V(x_4492).S("\" cy=\"").V(y_4493).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(r_4494) * 0.9))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(r_4494) * 0.55))))).S("\" fill=\"#6a4220\"/><ellipse cx=\"").N((ToNum(x_4492) - 0.2)).S("\" cy=\"").N((ToNum(y_4493) - 0.1)).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(r_4494) * 0.4))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(r_4494) * 0.25))))).S("\" fill=\"#3a2410\"/>").End()));
}, 3, "", true);
top_4409 = ((V)(JsStrBuf.Begin().V(Add(Add(Call(gr_4407, V.Undef, ((V)(94D)), ((V)(16.4)), ((V)(26D)), ((V)("pt"))), Call(knot_4408, V.Undef, ((V)(18D)), ((V)(6D)), ((V)(1.2)))), Call(knot_4408, V.Undef, ((V)(70D)), ((V)(11D)), ((V)(0.9))))).S("<circle cx=\"54\" cy=\"9\" r=\"3.6\" fill=\"none\" stroke=\"#6a4220\" stroke-width=\"0.7\" opacity=\"0.4\"/><circle cx=\"54\" cy=\"9\" r=\"3.2\" fill=\"#4a2a10\" opacity=\"0.12\"/>").S("<circle cx=\"31\" cy=\"12\" r=\"2.2\" fill=\"none\" stroke=\"#7a4a22\" stroke-width=\"0.25\" opacity=\"0.5\"/><path d=\"M8 14l6 -0.4M80 3l7 0.3\" stroke=\"#8a6438\" stroke-width=\"0.15\" opacity=\"0.6\"/>").End()));
front_4410 = ((V)(JsStrBuf.Begin().V(Call(gr_4407, V.Undef, ((V)(94D)), ((V)(2.6)), ((V)(4D)), ((V)("pf")))).S("<path d=\"M0 0.2H94\" stroke=\"#f2d4a0\" stroke-width=\"0.25\" opacity=\"0.8\"/>").V(Call(knot_4408, V.Undef, ((V)(40D)), ((V)(1.3)), ((V)(0.6)))).V(Invoke(Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis4502, int _argc4496, V _a4498, V _a4499, V _a4500, V _a4501, V[] _rest4497) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_4399, V.Undef)) * 92D))))).S(" ").V(Call(f1_16, V.Undef, ((V)((0.6 + (ToNum(Call(R_4399, V.Undef)) * 1.4)))))).S("l").V(Call(f1_16, V.Undef, ((V)((1D + (ToNum(Call(R_4399, V.Undef)) * 2D)))))).S(" 0.2\" stroke=\"#8a5a2a\" stroke-width=\"0.12\"/>").End()));
}, 0, "", true)), "join", ((V)("")))).End()));
s_4405 = Add(s_4405, Call(box3_4184, V.Undef, C_4398, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(PY_4400)), ((V)((0.6 + 8.4))))).Put("w", ((V)(94D))).Put("h", ((V)(2.6))).Put("d", ((V)(16.8))).Put("col", PN_4403).Put("r", ((V)(0.3))).Put("dec", NewObj(2).Put("f", front_4410).Put("t", top_4409).V).V));
Invoke(Arr(((V)((-44.2))), ((V)(44.2))), "forEach", Fn((V _arrowThis4510, int _argc4503, V x_4509, V _a4506, V _a4507, V _a4508, V[] _rest4504) => {
return (s_4405 = Add(s_4405, Call(box3_4184, V.Undef, C_4398, NewObj(6).Put("c", Arr(x_4509, ((V)(PY_4400)), ((V)((0.6 + 8.4))))).Put("w", ((V)(0.1))).Put("h", ((V)(2.6))).Put("d", ((V)(16.8))).Put("col", ((V)("#c8986a"))).Put("r", ((V)(0D))).V)));
}, 1, "", true));
hk_4411 = Arr(((V)(41D)), ((V)(PY_4400)), ((V)((PZ_4402 - 1.6))));
hq_4412 = Invoke(C_4398, "P", hk_4411);
k_4413 = Get(C_4398, "k");
tw_4414 = ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(hq_4412, 0D)) - (4.6 * ToNum(k_4413))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 1D), ((V)((1D * ToNum(k_4413))))))).S("L").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 0D), ((V)((4.6 * ToNum(k_4413))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 1D), ((V)((1D * ToNum(k_4413))))))).S("L").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 0D), ((V)((4.2 * ToNum(k_4413))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 1D), ((V)((13D * ToNum(k_4413))))))).S("Q").V(Call(f1_16, V.Undef, GetIdx(hq_4412, 0D))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 1D), ((V)((13.8 * ToNum(k_4413))))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(hq_4412, 0D)) - (4.2 * ToNum(k_4413))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 1D), ((V)((13D * ToNum(k_4413))))))).S("Z\" fill=\"url(#pnTw)\"/>").S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(hq_4412, 0D)) - (4.6 * ToNum(k_4413))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 1D), ((V)((1D * ToNum(k_4413))))))).S("Q").V(Call(f1_16, V.Undef, GetIdx(hq_4412, 0D))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(hq_4412, 1D)) - (0.4 * ToNum(k_4413))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 0D), ((V)((4.6 * ToNum(k_4413))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 1D), ((V)((1D * ToNum(k_4413))))))).S("Q").V(Call(f1_16, V.Undef, GetIdx(hq_4412, 0D))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 1D), ((V)((2.6 * ToNum(k_4413))))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(hq_4412, 0D)) - (4.6 * ToNum(k_4413))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 1D), ((V)((1D * ToNum(k_4413))))))).S("Z\" fill=\"#b82a2a\"/>").S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(hq_4412, 0D)) - (4.2 * ToNum(k_4413))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 1D), ((V)((11.6 * ToNum(k_4413))))))).S("H").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 0D), ((V)((4.2 * ToNum(k_4413))))))).S("\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(k_4413)))))).S("\" opacity=\"0.8\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis4518, int _argc4511, V i_4517, V _a4514, V _a4515, V _a4516, V[] _rest4512) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)(((ToNum(GetIdx(hq_4412, 0D)) - (4D * ToNum(k_4413))) + ((ToNum(i_4517) * 1.33) * ToNum(k_4413))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(hq_4412, 1D), ((V)((13D * ToNum(k_4413))))))).S("v").V(Call(f1_16, V.Undef, ((V)((0.9 * ToNum(k_4413)))))).S("\" stroke=\"#e8d8c8\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.18 * ToNum(k_4413)))))).S("\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).End()));
s_4405 = Add(s_4405, Add(Call(swayAt_4192, V.Undef, C_4398, hk_4411, ((V)(3D)), ((V)(4.6)), ((V)(0.3)), tw_4414), Call(line3_4191, V.Undef, C_4398, Arr(Arr(((V)(41D)), ((V)(PY_4400)), ((V)((PZ_4402 - 1.6)))), Arr(((V)(41D)), ((V)((PY_4400 - 0.8))), ((V)((PZ_4402 - 1.6)))), Arr(((V)(41.6)), ((V)((PY_4400 - 1.4))), ((V)((PZ_4402 - 1.2))))), ((V)(0.3)), ((V)("#c8a048")))));
sp_4415 = Invoke(C_4398, "P", Arr(((V)((-10D))), ((V)(PY_4400)), ((V)(10D))));
s_4405 = ((V)(JsStrBuf.Begin().V(s_4405).S("<g>").V(Call(at_47, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;0 ").V(Call(f1_16, V.Undef, ((V)((4D * ToNum(k_4413)))))).S(";0 ").V(Call(f1_16, V.Undef, ((V)((1.4 * ToNum(k_4413)))))).S(";0 0").End())), ((V)(9D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(3D))))).S("<path d=\"M").V(Call(f1_16, V.Undef, GetIdx(sp_4415, 0D))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(sp_4415, 1D)) - (9D * ToNum(k_4413))))))).S("V").V(Call(f1_16, V.Undef, Add(GetIdx(sp_4415, 1D), ((V)((6D * ToNum(k_4413))))))).S("\" stroke=\"#ffffff\" stroke-width=\"0.12\" opacity=\"0.7\"/><g transform=\"translate(").V(Call(f1_16, V.Undef, GetIdx(sp_4415, 0D))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(sp_4415, 1D), ((V)((6.6 * ToNum(k_4413))))))).S(") scale(").V(Call(f1_16, V.Undef, k_4413)).S(")\"><path d=\"M-1.4 -0.6l-0.8 -0.6M-1.4 0l-1 0M-1.4 0.6l-0.8 0.6M1.4 -0.6l0.8 -0.6M1.4 0l1 0M1.4 0.6l0.8 0.6\" stroke=\"#2a2420\" stroke-width=\"0.18\"/><ellipse rx=\"1\" ry=\"0.8\" fill=\"#2a2420\"/><circle cy=\"-0.8\" r=\"0.5\" fill=\"#3a3430\"/></g></g>").End()));
Y_4416 = PT_4401;
sp1_4417 = Add(Add(Add(Add(Call(line3_4191, V.Undef, C_4398, Arr(Arr(((V)((-40D))), ((V)((Y_4416 + 1D))), ((V)(6D))), Arr(((V)((-41.6))), ((V)((Y_4416 + 16D))), ((V)(5.4)))), ((V)(0.7)), ((V)("#c8945a"))), Call(ell3_4194, V.Undef, C_4398, ((V)((-41.7))), ((V)((Y_4416 + 16.6))), ((V)(5.4)), ((V)(1.4)), ((V)("#c8945a")))), Call(line3_4191, V.Undef, C_4398, Arr(Arr(((V)((-38.4))), ((V)((Y_4416 + 1D))), ((V)(6.6))), Arr(((V)((-37.4))), ((V)((Y_4416 + 14.4))), ((V)(7D)))), ((V)(0.6)), ((V)("#a87444")))), Call(poly3_4190, V.Undef, C_4398, Arr(Arr(((V)((-38.6))), ((V)((Y_4416 + 13.4))), ((V)(7D))), Arr(((V)((-35.6))), ((V)((Y_4416 + 13.8))), ((V)(7D))), Arr(((V)((-36D))), ((V)((Y_4416 + 18D))), ((V)(7D))), Arr(((V)((-38.4))), ((V)((Y_4416 + 17.4))), ((V)(7D)))), ((V)("#3a3a3a")))), Call(line3_4191, V.Undef, C_4398, Arr(Arr(((V)((-39D))), ((V)((Y_4416 + 1D))), ((V)(7.4))), Arr(((V)((-39.6))), ((V)((Y_4416 + 13D))), ((V)(7.8)))), ((V)(0.5)), ((V)("#d8a86a"))));
s_4405 = Add(s_4405, Add(Call(jar_4195, V.Undef, C_4398, ((V)((-39D))), ((V)(Y_4416)), ((V)(7D)), ((V)(3.6)), ((V)(9.4)), sp1_4417), Call(cyl3_4185, V.Undef, C_4398, Arr(((V)((-39D))), ((V)((Y_4416 + 9.4))), ((V)(7D))), Arr(((V)((-39D))), ((V)((Y_4416 + 10.4))), ((V)(7D))), ((V)(3.7)), ((V)("#b8b4a8")), NewObj(1).Put("n", ((V)(18D))).V)));
s_4405 = Add(s_4405, Call(WD_4186, V.Undef, C_4398, ((V)((-41.6))), ((V)((Y_4416 + 6.6))), ((V)(10.75)), ((V)(string.Concat("<rect width=\"5\" height=\"3.4\" rx=\"0.3\" fill=\"#f4ecd4\" opacity=\"0.9\"/><text x=\"2.5\" y=\"2.2\" text-anchor=\"middle\" font-family=\"", "'Segoe Print','Comic Sans MS',cursive", "\" font-size=\"1.3\" fill=\"#5a3a22\">spoons</text>")))));
s_4405 = Add(s_4405, Add(Add(Add(Call(mugH_4196, V.Undef, C_4398, ((V)((-27.6))), ((V)(Y_4416)), ((V)(7.6)), ((V)(3.2)), ((V)(7D)), ((V)("#f6f2ea")), ((V)((-1D)))), Call(mugC_4197, V.Undef, C_4398, ((V)((-27.6))), ((V)(Y_4416)), ((V)(7.6)), ((V)(3.2)), ((V)(7D)), ((V)("#f6f2ea")), ((V)("#6a4020")))), Call(WD_4186, V.Undef, C_4398, ((V)((-30.2))), ((V)((Y_4416 + 5.4))), ((V)(10.85)), ((V)("<text x=\"2.6\" y=\"1.4\" text-anchor=\"middle\" font-family=\"Arial,Helvetica,sans-serif\" font-weight=\"700\" font-size=\"1.6\" fill=\"#c83a2a\">#1 COOK</text>")))), Call(poly3_4190, V.Undef, C_4398, Arr(Arr(((V)((-25.4))), ((V)((Y_4416 + 7D))), ((V)(10.1))), Arr(((V)((-24.6))), ((V)((Y_4416 + 6.2))), ((V)(10.2))), Arr(((V)((-24.8))), ((V)((Y_4416 + 7D))), ((V)(10D)))), ((V)("#c8b8a0")))));
s_4405 = Add(s_4405, Add(Call(mugC_4197, V.Undef, C_4398, ((V)((-20D))), ((V)(Y_4416)), ((V)(5D)), ((V)(2.9)), ((V)(6.2)), ((V)("#e0a030"))), Call(mugH_4196, V.Undef, C_4398, ((V)((-20D))), ((V)(Y_4416)), ((V)(5D)), ((V)(2.9)), ((V)(6.2)), ((V)("#e0a030")), ((V)(1D)))));
s_4405 = Add(s_4405, Add(Add(Call(cyl3_4185, V.Undef, C_4398, Arr(((V)((-11.4))), ((V)(Y_4416)), ((V)(6.4))), Arr(((V)((-11.4))), ((V)((Y_4416 + 7D))), ((V)(6.4))), ((V)(2.8)), ((V)("#c4c8cc")), NewObj(2).Put("n", ((V)(18D))).Put("mat", ((V)("gloss"))).V), Call(cyl3_4185, V.Undef, C_4398, Arr(((V)((-11.4))), ((V)((Y_4416 + 1.2))), ((V)(6.4))), Arr(((V)((-11.4))), ((V)((Y_4416 + 5.8))), ((V)(6.4))), ((V)(2.86)), ((V)("#c8402e")), NewObj(1).Put("n", ((V)(18D))).V)), Call(WD_4186, V.Undef, C_4398, ((V)((-13.6))), ((V)((Y_4416 + 4.6))), ((V)(9.3)), ((V)("<text x=\"2.2\" y=\"0.6\" text-anchor=\"middle\" font-family=\"Georgia,serif\" font-weight=\"700\" font-size=\"1.5\" fill=\"#f6e8c0\">BEANS</text><ellipse cx=\"3.6\" cy=\"-0.6\" rx=\"0.9\" ry=\"1.6\" fill=\"#000000\" opacity=\"0.18\"/>")))));
A_4418 = 0.2;
ax_4419 = Arr(Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(FdLibm.Cos(A_4418))), ((V)((-FdLibm.Sin(A_4418))))), Arr(((V)(0D)), ((V)(FdLibm.Sin(A_4418))), ((V)(FdLibm.Cos(A_4418)))));
s_4405 = Add(s_4405, Call(box3_4184, V.Undef, C_4398, NewObj(8).Put("c", Arr(((V)(1D)), ((V)(Y_4416)), ((V)(3.4)))).Put("ax", ax_4419).Put("w", ((V)(12D))).Put("h", ((V)(15.6))).Put("d", ((V)(1.8))).Put("col", ((V)("#7a2a2a"))).Put("r", ((V)(0.3))).Put("dec", NewObj(2).Put("f", ((V)("<rect x=\"1\" y=\"1\" width=\"10\" height=\"13.6\" rx=\"0.4\" fill=\"none\" stroke=\"#e8c87a\" stroke-width=\"0.25\"/><text x=\"6\" y=\"5\" text-anchor=\"middle\" font-family=\"Georgia,serif\" font-style=\"italic\" font-size=\"1.7\" fill=\"#f2dca0\">Grandma's</text><text x=\"6\" y=\"7.2\" text-anchor=\"middle\" font-family=\"Georgia,serif\" font-size=\"1.5\" fill=\"#f2dca0\">Recipes</text><ellipse cx=\"4\" cy=\"11.6\" rx=\"1.6\" ry=\"1\" fill=\"#3a1414\" opacity=\"0.4\"/><rect y=\"9.4\" width=\"1.4\" height=\"1\" fill=\"#f6e8c0\"/>"))).Put("t", ((V)("<rect width=\"12\" height=\"1.8\" fill=\"#f2ead4\"/>"))).V).V));
s_4405 = Add(s_4405, Add(Call(cyl3_4185, V.Undef, C_4398, Arr(((V)(10.4)), ((V)(Y_4416)), ((V)(8D))), Arr(((V)(10.4)), ((V)((Y_4416 + 7D))), ((V)(8D))), ((V)(2.6)), ((V)("#2f5ba8")), NewObj(3).Put("n", ((V)(18D))).Put("mat", ((V)("gloss"))).Put("capCol", ((V)("#f4f4f0"))).V), Call(WD_4186, V.Undef, C_4398, ((V)(8.3)), ((V)((Y_4416 + 4.8))), ((V)(10.65)), ((V)("<text x=\"2.1\" y=\"0.6\" text-anchor=\"middle\" font-family=\"Arial,Helvetica,sans-serif\" font-weight=\"700\" font-size=\"1.4\" fill=\"#ffffff\">SALT</text><path d=\"M0.6 1.6h3\" stroke=\"#f2d04a\" stroke-width=\"0.4\"/>")))));
PX_4420 = 24D;
PZp_4421 = 9D;
s_4405 = Add(s_4405, Add(Call(cyl3_4185, V.Undef, C_4398, Arr(((V)(PX_4420)), ((V)(Y_4416)), ((V)(PZp_4421))), Arr(((V)(PX_4420)), ((V)((Y_4416 + 4.8))), ((V)(PZp_4421))), ((V)(3.4)), ((V)("#c06a3c")), NewObj(2).Put("n", ((V)(18D))).Put("capCol", ((V)("#4a3020"))).V), Call(cyl3_4185, V.Undef, C_4398, Arr(((V)(PX_4420)), ((V)((Y_4416 + 4.2))), ((V)(PZp_4421))), Arr(((V)(PX_4420)), ((V)((Y_4416 + 5.4))), ((V)(PZp_4421))), ((V)(3.8)), ((V)("#c8744a")), NewObj(2).Put("n", ((V)(18D))).Put("capCol", ((V)("#3a2618"))).V)));
leaf_4422 = Fn((V _arrowThis4531, int _argc4519, V x_4525, V y_4526, V z_4527, V sc_4528, V[] _rest4520) => {
V q_4532 = default;
V rot_4529 = default;
V c_4530 = default;
rot_4529 = (_argc4519 > 4 ? _rest4520[0] : V.Undef);
c_4530 = (_argc4519 > 5 ? _rest4520[1] : V.Undef);
q_4532 = Invoke(C_4398, "P", Arr(x_4525, y_4526, z_4527));
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(f1_16, V.Undef, GetIdx(q_4532, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(q_4532, 1D))).S(") rotate(").V(rot_4529).S(") scale(").V(Call(f1_16, V.Undef, ((V)((ToNum(Get(C_4398, "k")) * ToNum(sc_4528)))))).S(")\"><path d=\"M0 0C-1.6 -0.6 -1.8 -2.6 0 -3.4C1.8 -2.6 1.6 -0.6 0 0Z\" fill=\"").V(c_4530).S("\"/><path d=\"M0 -0.2V-3\" stroke=\"#d8e8a0\" stroke-width=\"0.12\" opacity=\"0.7\"/><path d=\"M-0.6 -2.2Q0 -2 0.4 -1.2\" stroke=\"#e8f0b0\" stroke-width=\"0.2\" opacity=\"0.5\"/></g>").End()));
return default;
}, 6, "", true);
pl_4423 = new JsStrBuf("");
Invoke(Arr(Arr(((V)((-1.6))), ((V)(8D)), ((V)(0.4)), ((V)((-30D)))), Arr(((V)(1.8)), ((V)(8.6)), ((V)(0.2)), ((V)(25D))), Arr(((V)(0D)), ((V)(10D)), ((V)((-0.6))), ((V)(0D))), Arr(((V)((-2.8))), ((V)(6.4)), ((V)(1D)), ((V)((-60D)))), Arr(((V)(2.8)), ((V)(6.8)), ((V)(0.8)), ((V)(55D))), Arr(((V)((-0.6))), ((V)(7D)), ((V)(1.6)), ((V)((-10D)))), Arr(((V)(1D)), ((V)(9.2)), ((V)(1D)), ((V)(15D)))), "forEach", Fn((V _arrowThis4549, int _argc4533, V _a4535, V i_4539, V _a4537, V _a4538, V[] _rest4534) => {
V dx_4542 = default;
V dy_4544 = default;
V dz_4546 = default;
V r_4548 = default;
{ V _t4540 = ListOf(_a4535);
{ V _t4541 = GetIdx(_t4540, 0D);
dx_4542 = _t4541; }
{ V _t4543 = GetIdx(_t4540, 1D);
dy_4544 = _t4543; }
{ V _t4545 = GetIdx(_t4540, 2D);
dz_4546 = _t4545; }
{ V _t4547 = GetIdx(_t4540, 3D);
r_4548 = _t4547; }
}
return ((V)(pl_4423.V(Call(leaf_4422, V.Undef, Add(((V)(PX_4420)), dx_4542), Add(((V)(Y_4416)), dy_4544), Add(((V)(PZp_4421)), dz_4546), ((V)(1.1)), r_4548, ((V)((NumTruthy((ToNum(i_4539) % 3D)) ? "#5aa04a" : "#7ab85a"))))).Str));
}, 2, "", true));
s_4405 = ((V)(JsStrBuf.Begin().V(s_4405).S(pl_4423.Str).End()));
Invoke(Arr(Arr(((V)((PX_4420 + 1.6))), ((V)(6D)), ((V)(0.4)), ((V)(0D))), Arr(((V)((PX_4420 + 3.4))), ((V)(4D)), ((V)(1.2)), ((V)(1.6)))), "forEach", Fn((V _arrowThis4565, int _argc4550, V _a4552, V _a4553, V _a4554, V _a4555, V[] _rest4551) => {
V root_4566 = default;
V tip_4567 = default;
V P_4568 = default;
V v_4569 = default;
V vx_4558 = default;
V n_4560 = default;
V dz_4562 = default;
V ph_4564 = default;
{ V _t4556 = ListOf(_a4552);
{ V _t4557 = GetIdx(_t4556, 0D);
vx_4558 = _t4557; }
{ V _t4559 = GetIdx(_t4556, 1D);
n_4560 = _t4559; }
{ V _t4561 = GetIdx(_t4556, 2D);
dz_4562 = _t4561; }
{ V _t4563 = GetIdx(_t4556, 3D);
ph_4564 = _t4563; }
}
root_4566 = Arr(vx_4558, ((V)((Y_4416 + 4D))), ((V)((PZp_4421 + 3D))));
tip_4567 = Arr(Add(vx_4558, ((V)(1.4))), Add(((V)((PY_4400 - 14D))), n_4560), Add(((V)((PZ_4402 + 0.6))), dz_4562));
P_4568 = Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis4577, int _argc4570, V i_4576, V _a4573, V _a4574, V _a4575, V[] _rest4571) => {
double t_4578 = 0;
t_4578 = (ToNum(i_4576) / 6D);
return Arr(Add(Add(GetIdx(root_4566, 0D), ((V)(((ToNum(GetIdx(tip_4567, 0D)) - ToNum(GetIdx(root_4566, 0D))) * t_4578)))), ((V)((FdLibm.Sin((t_4578 * 4D)) * 0.6)))), Add(Add(GetIdx(root_4566, 1D), ((V)(((((ToNum(GetIdx(tip_4567, 1D)) - ToNum(GetIdx(root_4566, 1D))) * t_4578) * t_4578) * 0.9)))), ((V)(((t_4578 > 0.3) ? 0D : (1.6 * t_4578))))), Add(GetIdx(root_4566, 2D), ((V)(((ToNum(GetIdx(tip_4567, 2D)) - ToNum(GetIdx(root_4566, 2D))) * Min(1D, (t_4578 * 2.4)))))));
return default;
}, 1, "", true));
v_4569 = Call(line3_4191, V.Undef, C_4398, P_4568, ((V)(0.32)), ((V)("#4a7a32")));
Invoke(Invoke(P_4568, "slice", ((V)(1D))), "forEach", Fn((V _arrowThis4587, int _argc4579, V p_4585, V i_4586, V _a4583, V _a4584, V[] _rest4580) => {
return (v_4569 = Add(v_4569, Call(leaf_4422, V.Undef, Add(GetIdx(p_4585, 0D), ((V)((NumTruthy((ToNum(i_4586) % 2D)) ? 0.6 : (-0.6))))), GetIdx(p_4585, 1D), GetIdx(p_4585, 2D), ((V)(0.85)), ((V)((NumTruthy((ToNum(i_4586) % 2D)) ? 50D : ((-40D) + ((180D * (((ToNum(i_4586) % 3D) == 2D) ? 1D : 0D)) * 0D))))), ((V)((NumTruthy((ToNum(i_4586) % 2D)) ? "#62a84e" : "#4e9440"))))));
}, 2, "", true));
s_4405 = Add(s_4405, Call(swayAt_4192, V.Undef, C_4398, root_4566, ((V)(2.4)), Add(((V)(5.4)), ph_4564), ph_4564, v_4569));
return default;
}, 1, "", true));
s_4405 = Add(s_4405, Add(Add(Call(cyl3_4185, V.Undef, C_4398, Arr(((V)(36D)), ((V)(Y_4416)), ((V)(8D))), Arr(((V)(36D)), ((V)((Y_4416 + 2.6))), ((V)(8D))), ((V)(4.2)), ((V)("#e8e2d0")), NewObj(3).Put("n", ((V)(20D))).Put("mat", ((V)("gloss"))).Put("capCol", ((V)("#e0d8c4"))).V), Call(cyl3_4185, V.Undef, C_4398, Arr(((V)(36D)), ((V)((Y_4416 + 2.6))), ((V)(8D))), Arr(((V)(36D)), ((V)((Y_4416 + 4.6))), ((V)(8D))), ((V)(3.8)), ((V)("#9ab8a8")), NewObj(3).Put("n", ((V)(20D))).Put("mat", ((V)("gloss"))).Put("capCol", ((V)("#8aa898"))).V)), Call(ell3_4194, V.Undef, C_4398, ((V)(36D)), ((V)((Y_4416 + 4.6))), ((V)(8D)), ((V)(1.4)), ((V)("#7a9888")))));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(DEF19_4188).S("<defs><pattern id=\"pnTw\" width=\"2.4\" height=\"2.4\" patternUnits=\"userSpaceOnUse\"><rect width=\"2.4\" height=\"2.4\" fill=\"#f4ece0\"/><rect width=\"1.2\" height=\"2.4\" fill=\"#c83030\" opacity=\"0.6\"/><rect width=\"2.4\" height=\"1.2\" fill=\"#c83030\" opacity=\"0.6\"/></pattern></defs>").End()))).Put("front", s_4405).Put("bb", Invoke(C_4398, "bb", ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_4382;
return default;
}, 1, "", true));
Set(N_70, "lam27", Fn((V _arrowThis4595, int _argc4588, V S_4594, V _a4591, V _a4592, V _a4593, V[] _rest4589) => {
V D_4596 = default;
D_4596 = NewObj(5).Put("w", ((V)(98D))).Put("d", ((V)(26D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(46D))).Put("build", Fn((V _arrowThis4603, int _argc4597, V _a4599, V _a4600, V _a4601, V _a4602, V[] _rest4598) => {
return Arr();
}, 0, "build", true)).V;
Set(D_4596, "fx", Fn((V _arrowThis4611, int _argc4604, V ctx_4610, V _a4607, V _a4608, V _a4609, V[] _rest4605) => {
V C_4612 = default;
V R_4613 = default;
V WH_4614 = default;
V EB_4615 = default;
double Y0_4616 = 0;
double HH_4617 = 0;
double DZ_4618 = 0;
V k_4619 = default;
V s_4620 = default;
V spk_4621 = default;
V fp_4622 = default;
double L0_4623 = 0;
double L1_4624 = 0;
double LW_4625 = 0;
double LC_4626 = 0;
V topDust_4627 = default;
V door_4628 = default;
V pc_4629 = default;
double R0x_4630 = 0;
double R1x_4631 = 0;
double RW_4632 = 0;
double RC_4633 = 0;
V IN_4634 = default;
V CARC_4635 = default;
double iz0_4636 = 0;
double iz1_4637 = 0;
double ix0_4638 = 0;
double ix1_4639 = 0;
double iy0_4640 = 0;
double iy1_4641 = 0;
double mid_4642 = 0;
V can_4643 = default;
double th_4644 = 0;
double hx_4645 = 0;
double hz_4646 = 0;
double dw_4647 = 0;
V ux_4648 = default;
V nz_4649 = default;
double cx_4650 = 0;
double cz_4651 = 0;
V AX_4652 = default;
V dFace_4653 = default;
V dBack_4654 = default;
double TY_4655 = 0;
C_4612 = Call(camW_4181, V.Undef, ctx_4610);
R_4613 = Call(rng_13, V.Undef, ((V)("lam27")));
WH_4614 = ((V)("#f2f1ea"));
EB_4615 = ((V)("#e8e2c8"));
Y0_4616 = 4D;
HH_4617 = 32D;
DZ_4618 = 14D;
k_4619 = Get(C_4612, "k");
Call(ext_4187, V.Undef, C_4612, Arr(Arr(((V)((-50D))), ((V)(((Y0_4616 + HH_4617) + 12D))), ((V)(0D))), Arr(((V)(50D)), ((V)((Y0_4616 - 14D))), ((V)(0D)))));
s_4620 = Call(WD_4186, V.Undef, C_4612, ((V)((-48D))), ((V)(((Y0_4616 + HH_4617) + 1D))), ((V)(0.05)), ((V)(JsStrBuf.Begin().S("<rect width=\"96\" height=\"").N((HH_4617 + 3D)).S("\" rx=\"2\" fill=\"#000000\" opacity=\"0.3\" filter=\"url(#m10b3)\"/>").End())));
s_4620 = Add(s_4620, Call(WD_4186, V.Undef, C_4612, ((V)((-44D))), ((V)((Y0_4616 - 0.6))), ((V)(0.06)), ((V)(JsStrBuf.Begin().S("<rect width=\"54\" height=\"14\" fill=\"url(#lmGl)\" opacity=\"0.9\">").V(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.9;0.9;0.3;0.9;0.5;0.9;0.9")), ((V)(13D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.7;0.71;0.73;0.74;0.76;1\"")))).S("</rect>").End()))));
spk_4621 = Fn((V _arrowThis4665, int _argc4656, V w_4662, V h_4663, V n_4664, V _a4661, V[] _rest4657) => {
return Invoke(Call(rep_18, V.Undef, n_4664, Fn((V _arrowThis4672, int _argc4666, V _a4668, V _a4669, V _a4670, V _a4671, V[] _rest4667) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_4613, V.Undef)) * ToNum(w_4662)))))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_4613, V.Undef)) * ToNum(h_4663)))))).S("\" r=\"").V(Call(f1_16, V.Undef, ((V)((0.07 + (ToNum(Call(R_4613, V.Undef)) * 0.08)))))).S("\" fill=\"#b8b4a4\" opacity=\"0.5\"/>").End()));
}, 0, "", true)), "join", ((V)("")));
}, 3, "", true);
fp_4622 = Fn((V _arrowThis4681, int _argc4673, V x_4679, V y_4680, V _a4677, V _a4678, V[] _rest4674) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(x_4679).S("\" cy=\"").V(y_4680).S("\" rx=\"0.7\" ry=\"0.95\" fill=\"#c8b890\" opacity=\"0.14\"/><ellipse cx=\"").V(Add(x_4679, ((V)(1.1)))).S("\" cy=\"").N((ToNum(y_4680) - 0.4)).S("\" rx=\"0.6\" ry=\"0.85\" fill=\"#c8b890\" opacity=\"0.12\"/>").End()));
}, 2, "", true);
L0_4623 = (-46D);
L1_4624 = 14D;
LW_4625 = (L1_4624 - L0_4623);
LC_4626 = ((L0_4623 + L1_4624) / 2D);
topDust_4627 = Fn((V _arrowThis4689, int _argc4682, V w_4688, V _a4685, V _a4686, V _a4687, V[] _rest4683) => {
return ((V)(JsStrBuf.Begin().S("<rect width=\"").V(w_4688).S("\" height=\"").N(DZ_4618).S("\" fill=\"#d8d2bc\" opacity=\"0.35\"/>").V(Call(spk_4621, V.Undef, w_4688, ((V)(DZ_4618)), ((V)(40D)))).S("<rect x=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(w_4688) * 0.3))))).S("\" y=\"2\" width=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(w_4688) * 0.3))))).S("\" height=\"").N((DZ_4618 - 4D)).S("\" fill=\"#ffffff\" opacity=\"0.18\"/>").End()));
}, 1, "", true);
s_4620 = Add(s_4620, Call(box3_4184, V.Undef, C_4612, NewObj(7).Put("c", Arr(((V)(LC_4626)), ((V)(Y0_4616)), ((V)((DZ_4618 / 2D))))).Put("w", ((V)(LW_4625))).Put("h", ((V)(HH_4617))).Put("d", ((V)(DZ_4618))).Put("col", WH_4614).Put("r", ((V)(0.2))).Put("dec", NewObj(3).Put("f", ((V)(JsStrBuf.Begin().S("<rect width=\"").N(LW_4625).S("\" height=\"").N(HH_4617).S("\" fill=\"none\" stroke=\"").V(EB_4615).S("\" stroke-width=\"0.8\"/>").End()))).Put("t", Call(topDust_4627, V.Undef, ((V)(LW_4625)))).Put("r", ((V)(JsStrBuf.Begin().S("<rect width=\"").N(DZ_4618).S("\" height=\"").N(HH_4617).S("\" fill=\"").V(EB_4615).S("\" opacity=\"0.4\"/>").V(Call(spk_4621, V.Undef, ((V)(DZ_4618)), ((V)(HH_4617)), ((V)(20D)))).End()))).V).V));
door_4628 = Fn((V _arrowThis4701, int _argc4690, V x0_4696, V w_4697, V sag_4698, V pull_4699, V[] _rest4691) => {
V cx_4702 = default;
V ax_4703 = default;
V ex_4700 = default;
ex_4700 = (_argc4690 > 4 ? _rest4691[0] : V.Undef);
cx_4702 = Add(x0_4696, ((V)((ToNum(w_4697) / 2D))));
ax_4703 = Arr(Arr(((V)(FdLibm.Cos(ToNum(sag_4698)))), ((V)(FdLibm.Sin(ToNum(sag_4698)))), ((V)(0D))), Arr(((V)((-FdLibm.Sin(ToNum(sag_4698))))), ((V)(FdLibm.Cos(ToNum(sag_4698)))), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return Add(Add(Call(box3_4184, V.Undef, C_4612, NewObj(9).Put("c", Arr(cx_4702, ((V)((Y0_4616 + 0.4))), ((V)((DZ_4618 + 0.45))))).Put("ax", ax_4703).Put("w", ((V)((ToNum(w_4697) - 0.6)))).Put("h", ((V)((HH_4617 - 0.8)))).Put("d", ((V)(0.9))).Put("col", WH_4614).Put("r", ((V)(0.1))).Put("edge", ((V)(0.5))).Put("dec", NewObj(1).Put("f", ((V)(JsStrBuf.Begin().S("<rect width=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(w_4697) - 0.6))))).S("\" height=\"").V(Call(f1_16, V.Undef, ((V)((HH_4617 - 0.8))))).S("\" fill=\"url(#lmS)\"/>").V(Call(spk_4621, V.Undef, w_4697, ((V)(HH_4617)), ((V)(30D)))).S("<rect width=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(w_4697) - 0.6))))).S("\" height=\"").V(Call(f1_16, V.Undef, ((V)((HH_4617 - 0.8))))).S("\" fill=\"none\" stroke=\"").V(EB_4615).S("\" stroke-width=\"0.35\"/>").V((ex_4700 is var _t4704 && Truthy(_t4704) ? _t4704 : ((V)("")))).End()))).V).V), Call(box3_4184, V.Undef, C_4612, NewObj(7).Put("c", Arr(Add(cx_4702, pull_4699), ((V)((Y0_4616 + 3D))), ((V)((DZ_4618 + 1.6))))).Put("ax", ax_4703).Put("w", ((V)(0.7))).Put("h", ((V)(8D))).Put("d", ((V)(0.6))).Put("col", ((V)("#c8ccd0"))).Put("r", ((V)(0.2))).V)), Invoke(Invoke(Arr(((V)((Y0_4616 + 3.6))), ((V)((Y0_4616 + 10.4)))), "map", Fn((V _arrowThis4712, int _argc4705, V y_4711, V _a4708, V _a4709, V _a4710, V[] _rest4706) => {
return Call(cyl3_4185, V.Undef, C_4612, Arr(Add(cx_4702, pull_4699), y_4711, ((V)((DZ_4618 + 0.9)))), Arr(Add(cx_4702, pull_4699), y_4711, ((V)((DZ_4618 + 1.4)))), ((V)(0.35)), ((V)("#a8acb0")), NewObj(1).Put("n", ((V)(8D))).V);
}, 1, "", true)), "join", ((V)(""))));
return default;
}, 5, "", true);
s_4620 = Add(s_4620, Add(Call(door_4628, V.Undef, ((V)(L0_4623)), ((V)((LW_4625 / 2D))), ((V)(0.012)), ((V)(((LW_4625 / 4D) - 2.2))), ((V)(JsStrBuf.Begin().V(Call(fp_4622, V.Undef, ((V)(25D)), ((V)(22D)))).S("<ellipse cx=\"8\" cy=\"9\" rx=\"3\" ry=\"1.6\" fill=\"#d0b070\" opacity=\"0.12\"/>").End()))), Call(door_4628, V.Undef, ((V)(LC_4626)), ((V)((LW_4625 / 2D))), ((V)(0D)), ((V)((-((LW_4625 / 4D) - 2.2)))), ((V)(JsStrBuf.Begin().V(Call(fp_4622, V.Undef, ((V)(4D)), ((V)(24D)))).S("<g transform=\"translate(16 9) rotate(-8)\"><path d=\"M-3 1.6Q-3.4 -1 -1 -1.6Q0 -3.4 1.6 -2.4Q2.4 -1 3.2 -0.8Q3.8 0.6 2.6 1.6Z\" fill=\"#7ac860\"/><circle cx=\"1.6\" cy=\"-2\" r=\"0.25\" fill=\"#2a2a2a\"/><path d=\"M-2.4 1.6v1M1.6 1.6v1\" stroke=\"#5aa840\" stroke-width=\"0.6\"/><path d=\"M-1 -1.2l0.6 -0.8l0.6 0.8\" fill=\"#f2d04a\"/></g>").End())))));
pc_4629 = Invoke(C_4612, "P", Arr(((V)((L0_4623 + 0.4))), ((V)((Y0_4616 + 0.4))), ((V)((DZ_4618 + 0.95)))));
s_4620 = ((V)(JsStrBuf.Begin().V(s_4620).S("<g>").V(Call(at_47, V.Undef, ((V)("rotate")), ((V)(JsStrBuf.Begin().S("0 ").V(Call(f1_16, V.Undef, GetIdx(pc_4629, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(pc_4629, 1D))).S(";-3 ").V(Call(f1_16, V.Undef, GetIdx(pc_4629, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(pc_4629, 1D))).S(";0 ").V(Call(f1_16, V.Undef, GetIdx(pc_4629, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(pc_4629, 1D))).End())), ((V)(7D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))).S("<path d=\"M").V(Call(f1_16, V.Undef, Add(GetIdx(pc_4629, 0D), ((V)((0.2 * ToNum(k_4619))))))).S(" ").V(Call(f1_16, V.Undef, GetIdx(pc_4629, 1D))).S("Q").V(Call(f1_16, V.Undef, Add(GetIdx(pc_4629, 0D), ((V)((3D * ToNum(k_4619))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(pc_4629, 1D), ((V)((1.6 * ToNum(k_4619))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(pc_4629, 0D), ((V)((6D * ToNum(k_4619))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(pc_4629, 1D), ((V)((0.8 * ToNum(k_4619))))))).S("q0.6 -0.8 -0.2 -1\" stroke=\"").V(EB_4615).S("\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(k_4619)))))).S("\" fill=\"none\" stroke-linecap=\"round\"/></g>").S("<path d=\"M").V(Call(f1_16, V.Undef, Add(GetIdx(pc_4629, 0D), ((V)((0.3 * ToNum(k_4619))))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(pc_4629, 1D)) - (0.2 * ToNum(k_4619))))))).S("h").V(Call(f1_16, V.Undef, ((V)((5.6 * ToNum(k_4619)))))).S("\" stroke=\"#b8a888\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(k_4619)))))).S("\" opacity=\"0.8\"/>").End()));
R0x_4630 = 16D;
R1x_4631 = 46D;
RW_4632 = (R1x_4631 - R0x_4630);
RC_4633 = ((R0x_4630 + R1x_4631) / 2D);
IN_4634 = ((V)("#e6e4da"));
CARC_4635 = Call(box3_4184, V.Undef, C_4612, NewObj(8).Put("c", Arr(((V)(RC_4633)), ((V)(Y0_4616)), ((V)((DZ_4618 / 2D))))).Put("w", ((V)(RW_4632))).Put("h", ((V)(HH_4617))).Put("d", ((V)(DZ_4618))).Put("col", WH_4614).Put("r", ((V)(0.2))).Put("hole", NewObj(1).Put("f", Arr(((V)(1.4)), ((V)(1.4)), ((V)(1.4)), ((V)(1.4)))).V).Put("dec", NewObj(2).Put("t", Call(topDust_4627, V.Undef, ((V)(RW_4632)))).Put("r", ((V)(JsStrBuf.Begin().S("<rect width=\"").N(DZ_4618).S("\" height=\"").N(HH_4617).S("\" fill=\"").V(EB_4615).S("\" opacity=\"0.4\"/>").End()))).V).V);
iz0_4636 = 0.8;
iz1_4637 = DZ_4618;
ix0_4638 = (R0x_4630 + 1.4);
ix1_4639 = (R1x_4631 - 1.4);
iy0_4640 = (Y0_4616 + 1.4);
iy1_4641 = ((Y0_4616 + HH_4617) - 1.4);
mid_4642 = (Y0_4616 + (HH_4617 / 2D));
s_4620 = Add(s_4620, Add(Call(poly3_4190, V.Undef, C_4612, Arr(Arr(((V)(ix0_4638)), ((V)(iy0_4640)), ((V)(iz0_4636))), Arr(((V)(ix1_4639)), ((V)(iy0_4640)), ((V)(iz0_4636))), Arr(((V)(ix1_4639)), ((V)(iy1_4641)), ((V)(iz0_4636))), Arr(((V)(ix0_4638)), ((V)(iy1_4641)), ((V)(iz0_4636)))), Call(shade_10, V.Undef, IN_4634, ((V)(0.86)))), Invoke(Get(RD_8, "H12"), "innerW", C_4612, ((V)(ix0_4638)), ((V)(ix1_4639)), ((V)(iy0_4640)), ((V)(iy1_4641)), ((V)(iz0_4636)), ((V)(iz1_4637)), IN_4634, ((V)(0.9)))));
s_4620 = Add(s_4620, Call(box3_4184, V.Undef, C_4612, NewObj(6).Put("c", Arr(((V)(RC_4633)), ((V)((mid_4642 - 0.6))), ((V)(((iz0_4636 + iz1_4637) / 2D))))).Put("w", ((V)((ix1_4639 - ix0_4638)))).Put("h", ((V)(1.2))).Put("d", ((V)(((iz1_4637 - iz0_4636) - 0.6)))).Put("col", WH_4614).Put("r", ((V)(0D))).V));
can_4643 = Fn((V _arrowThis4726, int _argc4713, V x_4719, V y_4720, V z_4721, V r_4722, V[] _rest4714) => {
V h_4723 = default;
V c_4724 = default;
V lbl_4725 = default;
h_4723 = (_argc4713 > 4 ? _rest4714[0] : V.Undef);
c_4724 = (_argc4713 > 5 ? _rest4714[1] : V.Undef);
lbl_4725 = (_argc4713 > 6 ? _rest4714[2] : V.Undef);
return Add(Add(Call(cyl3_4185, V.Undef, C_4612, Arr(x_4719, y_4720, z_4721), Arr(x_4719, Add(y_4720, h_4723), z_4721), r_4722, ((V)("#c4c8cc")), NewObj(2).Put("n", ((V)(16D))).Put("mat", ((V)("gloss"))).V), Call(cyl3_4185, V.Undef, C_4612, Arr(x_4719, Add(y_4720, ((V)((ToNum(h_4723) * 0.2)))), z_4721), Arr(x_4719, Add(y_4720, ((V)((ToNum(h_4723) * 0.82)))), z_4721), Add(r_4722, ((V)(0.05))), c_4724, NewObj(1).Put("n", ((V)(16D))).V)), (Truthy(lbl_4725) ? Call(WD_4186, V.Undef, C_4612, ((V)((ToNum(x_4719) - ToNum(r_4722)))), Add(y_4720, ((V)((ToNum(h_4723) * 0.62)))), Add(Add(z_4721, r_4722), ((V)(0.05))), ((V)(JsStrBuf.Begin().S("<text x=\"").V(r_4722).S("\" text-anchor=\"middle\" font-family=\"Arial,Helvetica,sans-serif\" font-weight=\"700\" font-size=\"1\" fill=\"#ffffff\">").V(lbl_4725).S("</text>").End()))) : ((V)(""))));
}, 7, "", true);
s_4620 = Add(s_4620, Add(Add(Add(Call(can_4643, V.Undef, ((V)(20.6)), ((V)(iy0_4640)), ((V)(5D)), ((V)(2.2)), ((V)(5.4)), ((V)("#2f7a3a")), ((V)("PEAS"))), Call(can_4643, V.Undef, ((V)(25.8)), ((V)(iy0_4640)), ((V)(6.4)), ((V)(2.2)), ((V)(5.4)), ((V)("#c8402e")), ((V)("SOUP")))), Call(cyl3_4185, V.Undef, C_4612, Arr(((V)(31.6)), ((V)(iy0_4640)), ((V)(6D))), Arr(((V)(31.6)), ((V)((iy0_4640 + 5.6))), ((V)(6D))), ((V)(2.6)), ((V)("#e8b86a")), NewObj(2).Put("n", ((V)(16D))).Put("capCol", ((V)("#c83a2a"))).V)), Call(cyl3_4185, V.Undef, C_4612, Arr(((V)(31.6)), ((V)((iy0_4640 + 5.6))), ((V)(6D))), Arr(((V)(31.6)), ((V)((iy0_4640 + 6.8))), ((V)(6D))), ((V)(2.7)), ((V)("#c83a2a")), NewObj(1).Put("n", ((V)(16D))).V)));
s_4620 = Add(s_4620, Call(box3_4184, V.Undef, C_4612, NewObj(7).Put("c", Arr(((V)(24D)), ((V)(mid_4642)), ((V)(6D)))).Put("w", ((V)(7D))).Put("h", ((V)(12D))).Put("d", ((V)(3D))).Put("col", ((V)("#f2c040"))).Put("r", ((V)(0.2))).Put("dec", NewObj(1).Put("f", ((V)("<rect width=\"7\" height=\"12\" fill=\"#f2c040\"/><circle cx=\"3.5\" cy=\"7\" r=\"2.4\" fill=\"#ffffff\"/><circle cx=\"3.5\" cy=\"7\" r=\"1.8\" fill=\"#d8903a\"/><text x=\"3.5\" y=\"3\" text-anchor=\"middle\" font-family=\"Arial,Helvetica,sans-serif\" font-weight=\"700\" font-size=\"1.4\" fill=\"#c83a2a\">O's</text>"))).V).V));
Invoke(Arr(Arr(((V)(30D)), ((V)("#c83a2a"))), Arr(((V)(33D)), ((V)("#6a8a3a"))), Arr(((V)(36D)), ((V)("#e0a030")))), "forEach", Fn((V _arrowThis4738, int _argc4727, V _a4729, V _a4730, V _a4731, V _a4732, V[] _rest4728) => {
V x_4735 = default;
V c_4737 = default;
{ V _t4733 = ListOf(_a4729);
{ V _t4734 = GetIdx(_t4733, 0D);
x_4735 = _t4734; }
{ V _t4736 = GetIdx(_t4733, 1D);
c_4737 = _t4736; }
}
return (s_4620 = Add(s_4620, Add(Call(cyl3_4185, V.Undef, C_4612, Arr(x_4735, ((V)(mid_4642)), ((V)(8.4))), Arr(x_4735, ((V)((mid_4642 + 4D))), ((V)(8.4))), ((V)(1.2)), ((V)("#f2f0e8")), NewObj(1).Put("n", ((V)(12D))).V), Call(cyl3_4185, V.Undef, C_4612, Arr(x_4735, ((V)((mid_4642 + 4D))), ((V)(8.4))), Arr(x_4735, ((V)((mid_4642 + 5D))), ((V)(8.4))), ((V)(1.25)), c_4737, NewObj(1).Put("n", ((V)(12D))).V))));
}, 1, "", true));
s_4620 = Add(s_4620, CARC_4635);
s_4620 = Add(s_4620, Add(Call(box3_4184, V.Undef, C_4612, NewObj(6).Put("c", Arr(((V)((-16D))), ((V)((Y0_4616 - 1.2))), ((V)(11D)))).Put("w", ((V)(50D))).Put("h", ((V)(1.2))).Put("d", ((V)(2D))).Put("col", ((V)("#e8e8e2"))).Put("r", ((V)(0.3))).V), Call(poly3_4190, V.Undef, C_4612, Arr(Arr(((V)((-40.6))), ((V)((Y0_4616 - 1.25))), ((V)(10.4))), Arr(((V)(8.6)), ((V)((Y0_4616 - 1.25))), ((V)(10.4))), Arr(((V)(8.6)), ((V)((Y0_4616 - 1.25))), ((V)(11.6))), Arr(((V)((-40.6))), ((V)((Y0_4616 - 1.25))), ((V)(11.6)))), ((V)("#fffbe6")), ((V)("opacity=\"0.9\"")))));
Invoke(Arr(Arr(((V)((-38D))), ((V)("#e86a5a")), ((V)(0D))), Arr(((V)((-30D))), ((V)("#5a9ad8")), ((V)(1.1))), Arr(((V)((-22D))), ((V)("#f2f2ea")), ((V)(2D)))), "forEach", Fn((V _arrowThis4752, int _argc4739, V _a4741, V _a4742, V _a4743, V _a4744, V[] _rest4740) => {
V hk_4753 = default;
V m_4754 = default;
V x_4747 = default;
V c_4749 = default;
V ph_4751 = default;
{ V _t4745 = ListOf(_a4741);
{ V _t4746 = GetIdx(_t4745, 0D);
x_4747 = _t4746; }
{ V _t4748 = GetIdx(_t4745, 1D);
c_4749 = _t4748; }
{ V _t4750 = GetIdx(_t4745, 2D);
ph_4751 = _t4750; }
}
hk_4753 = Arr(x_4747, ((V)(Y0_4616)), ((V)((DZ_4618 - 2.6))));
m_4754 = Add(Call(mugC_4197, V.Undef, C_4612, x_4747, ((V)((Y0_4616 - 7.8))), ((V)((DZ_4618 - 2.6))), ((V)(2.4)), ((V)(5.4)), c_4749), Call(mugH_4196, V.Undef, C_4612, x_4747, ((V)((Y0_4616 - 7.8))), ((V)((DZ_4618 - 2.6))), ((V)(2.4)), ((V)(5.4)), c_4749, ((V)(1D))));
s_4620 = Add(s_4620, Add(Call(line3_4191, V.Undef, C_4612, Arr(Arr(x_4747, ((V)(Y0_4616)), ((V)((DZ_4618 - 2.6)))), Arr(x_4747, ((V)((Y0_4616 - 1D))), ((V)((DZ_4618 - 2.6)))), Arr(Add(x_4747, ((V)(0.8))), ((V)((Y0_4616 - 1.6))), ((V)((DZ_4618 - 2.4))))), ((V)(0.28)), ((V)("#b8bcc0"))), Call(swayAt_4192, V.Undef, C_4612, Arr(Add(x_4747, ((V)(2.8))), ((V)((Y0_4616 - 1.4))), ((V)((DZ_4618 - 2.6)))), ((V)(3.2)), ((V)((3.8 + (ToNum(ph_4751) * 0.5)))), ph_4751, m_4754)));
return default;
}, 1, "", true));
th_4644 = 1.95;
hx_4645 = (R0x_4630 + 0.2);
hz_4646 = (DZ_4618 + 0.45);
dw_4647 = (RW_4632 - 0.6);
ux_4648 = Arr(((V)(FdLibm.Cos(th_4644))), ((V)(0D)), ((V)(FdLibm.Sin(th_4644))));
nz_4649 = Arr(((V)((-FdLibm.Sin(th_4644)))), ((V)(0D)), ((V)(FdLibm.Cos(th_4644))));
cx_4650 = (hx_4645 + ((ToNum(GetIdx(ux_4648, 0D)) * dw_4647) / 2D));
cz_4651 = (hz_4646 + ((ToNum(GetIdx(ux_4648, 2D)) * dw_4647) / 2D));
AX_4652 = Arr(ux_4648, Arr(((V)(0D)), ((V)(1D)), ((V)(0D))), nz_4649);
dFace_4653 = ((V)(JsStrBuf.Begin().S("<rect width=\"").V(Call(f1_16, V.Undef, ((V)(dw_4647)))).S("\" height=\"").V(Call(f1_16, V.Undef, ((V)((HH_4617 - 0.8))))).S("\" fill=\"url(#lmS)\"/>").V(Call(spk_4621, V.Undef, ((V)(dw_4647)), ((V)(HH_4617)), ((V)(26D)))).S("<rect width=\"").V(Call(f1_16, V.Undef, ((V)(dw_4647)))).S("\" height=\"").V(Call(f1_16, V.Undef, ((V)((HH_4617 - 0.8))))).S("\" fill=\"none\" stroke=\"").V(EB_4615).S("\" stroke-width=\"0.35\"/>").V(Call(fp_4622, V.Undef, ((V)((dw_4647 - 4D))), ((V)(20D)))).End()));
dBack_4654 = ((V)(JsStrBuf.Begin().S("<rect width=\"").V(Call(f1_16, V.Undef, ((V)(dw_4647)))).S("\" height=\"").V(Call(f1_16, V.Undef, ((V)((HH_4617 - 0.8))))).S("\" fill=\"#e2e0d6\"/><circle cx=\"").V(Call(f1_16, V.Undef, ((V)((dw_4647 - 2D))))).S("\" cy=\"4\" r=\"0.8\" fill=\"#b8bcc0\"/><circle cx=\"").V(Call(f1_16, V.Undef, ((V)((dw_4647 - 2D))))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)((HH_4617 - 5D))))).S("\" r=\"0.8\" fill=\"#b8bcc0\"/><rect x=\"").V(Call(f1_16, V.Undef, ((V)((dw_4647 - 3.4))))).S("\" y=\"3\" width=\"2.8\" height=\"2\" fill=\"#c8ccd0\"/><rect x=\"").V(Call(f1_16, V.Undef, ((V)((dw_4647 - 3.4))))).S("\" y=\"").V(Call(f1_16, V.Undef, ((V)((HH_4617 - 6D))))).S("\" width=\"2.8\" height=\"2\" fill=\"#c8ccd0\"/>").End()));
s_4620 = Add(s_4620, Call(box3_4184, V.Undef, C_4612, NewObj(8).Put("c", Arr(((V)(cx_4650)), ((V)((Y0_4616 + 0.4))), ((V)(cz_4651)))).Put("ax", AX_4652).Put("w", ((V)(dw_4647))).Put("h", ((V)((HH_4617 - 0.8)))).Put("d", ((V)(0.9))).Put("col", WH_4614).Put("r", ((V)(0.1))).Put("dec", NewObj(2).Put("f", dFace_4653).Put("b", dBack_4654).V).V));
{
double px_4755 = 0;
double pz_4756 = 0;
px_4755 = ((cx_4650 + (ToNum(GetIdx(ux_4648, 0D)) * ((dw_4647 / 2D) - 2.4))) + (ToNum(GetIdx(nz_4649, 0D)) * 1.2));
pz_4756 = ((cz_4651 + (ToNum(GetIdx(ux_4648, 2D)) * ((dw_4647 / 2D) - 2.4))) + (ToNum(GetIdx(nz_4649, 2D)) * 1.2));
s_4620 = Add(s_4620, Call(box3_4184, V.Undef, C_4612, NewObj(7).Put("c", Arr(((V)(px_4755)), ((V)((Y0_4616 + 3D))), ((V)(pz_4756)))).Put("ax", AX_4652).Put("w", ((V)(0.7))).Put("h", ((V)(8D))).Put("d", ((V)(0.6))).Put("col", ((V)("#c8ccd0"))).Put("r", ((V)(0.2))).V));
}
Invoke(Arr(((V)((Y0_4616 + 3D))), ((V)(((Y0_4616 + HH_4617) - 5D)))), "forEach", Fn((V _arrowThis4764, int _argc4757, V y_4763, V _a4760, V _a4761, V _a4762, V[] _rest4758) => {
return (s_4620 = Add(s_4620, Call(box3_4184, V.Undef, C_4612, NewObj(6).Put("c", Arr(((V)((R0x_4630 + 0.9))), y_4763, ((V)((DZ_4618 + 0.2))))).Put("w", ((V)(1.4))).Put("h", ((V)(2.2))).Put("d", ((V)(1D))).Put("col", ((V)("#b8bcc0"))).Put("r", ((V)(0.2))).V)));
}, 1, "", true));
TY_4655 = (Y0_4616 + HH_4617);
s_4620 = Add(s_4620, Call(box3_4184, V.Undef, C_4612, NewObj(7).Put("c", Arr(((V)((-30D))), ((V)(TY_4655)), ((V)(7D)))).Put("w", ((V)(14D))).Put("h", ((V)(6D))).Put("d", ((V)(9D))).Put("col", ((V)("#c8a060"))).Put("r", ((V)(0.8))).Put("dec", NewObj(2).Put("f", Add(Invoke(Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis4772, int _argc4765, V i_4771, V _a4768, V _a4769, V _a4770, V[] _rest4766) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 ").V(Add(i_4771, ((V)(0.5)))).S("H14\" stroke=\"#8a6430\" stroke-width=\"0.3\"/>").End()));
}, 1, "", true)), "join", ((V)(""))), Invoke(Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis4780, int _argc4773, V i_4779, V _a4776, V _a4777, V _a4778, V[] _rest4774) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").N(((ToNum(i_4779) * 1.4) + 0.7)).S(" 0V6\" stroke=\"#a87e44\" stroke-width=\"0.2\"/>").End()));
}, 1, "", true)), "join", ((V)(""))))).Put("t", ((V)("<rect x=\"1\" y=\"1\" width=\"12\" height=\"7\" fill=\"#5a3e20\" opacity=\"0.5\"/>"))).V).V));
s_4620 = Add(s_4620, Add(Call(cyl3_4185, V.Undef, C_4612, Arr(((V)((-12D))), ((V)(TY_4655)), ((V)(7D))), Arr(((V)((-12D))), ((V)((TY_4655 + 4D))), ((V)(7D))), ((V)(4.6)), ((V)("#2e5a8a")), NewObj(4).Put("n", ((V)(22D))).Put("mat", ((V)("gloss"))).Put("capCol", ((V)("#2e5a8a"))).Put("cap", Fn((V _arrowThis4788, int _argc4781, V cr_4787, V _a4784, V _a4785, V _a4786, V[] _rest4782) => {
return ((V)(JsStrBuf.Begin().S("<circle r=\"").V(Call(f1_16, V.Undef, cr_4787)).S("\" fill=\"#3a6a9a\"/><circle r=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(cr_4787) * 0.7))))).S("\" fill=\"none\" stroke=\"#e8c870\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(cr_4787) * 0.05))))).S("\"/><circle r=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(cr_4787) * 0.3))))).S("\" fill=\"#e8c870\" opacity=\"0.6\"/>").End()));
}, 1, "cap", true)).V), Call(WD_4186, V.Undef, C_4612, ((V)((-15.4))), ((V)((TY_4655 + 2.6))), ((V)(11.65)), ((V)("<text x=\"3.4\" text-anchor=\"middle\" font-family=\"Georgia,serif\" font-weight=\"700\" font-size=\"1.2\" fill=\"#f2dc98\">BUTTER</text>")))));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(DEF19_4188).S("<defs><linearGradient id=\"lmS\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.5\"/><stop offset=\"0.3\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.75\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#c8c4b0\" stop-opacity=\"0.25\"/></linearGradient><linearGradient id=\"lmGl\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff6d4\" stop-opacity=\"0.8\"/><stop offset=\"1\" stop-color=\"#fff6d4\" stop-opacity=\"0\"/></linearGradient></defs>").End()))).Put("front", s_4620).Put("bb", Invoke(C_4612, "bb", ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_4596;
return default;
}, 1, "", true));
{
V K2_4789 = default;
V box_4790 = default;
V cyl_4791 = default;
V ball_4792 = default;
V slab_4793 = default;
V slabX_4794 = default;
V disc_4795 = default;
V W__4796 = default;
V M__4797 = default;
V PL_4798 = default;
V em_4799 = default;
V rod_4800 = default;
V glue_4801 = default;
V face_4802 = default;
V qd_4803 = default;
K2_4789 = Get(X_9, "K");
{ V _t4804 = K2_4789;
if (_t4804.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4804));
{ V _t4805 = Get(_t4804, "box");
box_4790 = _t4805; }
{ V _t4806 = Get(_t4804, "cyl");
cyl_4791 = _t4806; }
{ V _t4807 = Get(_t4804, "ball");
ball_4792 = _t4807; }
{ V _t4808 = Get(_t4804, "slab");
slab_4793 = _t4808; }
{ V _t4809 = Get(_t4804, "slabX");
slabX_4794 = _t4809; }
{ V _t4810 = Get(_t4804, "disc");
disc_4795 = _t4810; } }
{ V _t4811 = Get(RD_8, "H16");
if (_t4811.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4811));
{ V _t4812 = Get(_t4811, "W_");
W__4796 = _t4812; }
{ V _t4813 = Get(_t4811, "M_");
M__4797 = _t4813; }
{ V _t4814 = Get(_t4811, "PL");
PL_4798 = _t4814; }
{ V _t4815 = Get(_t4811, "em");
em_4799 = _t4815; }
{ V _t4816 = Get(_t4811, "rod");
rod_4800 = _t4816; } }
{ V _t4817 = Get(RD_8, "H22");
if (_t4817.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4817));
{ V _t4818 = Get(_t4817, "glue");
glue_4801 = _t4818; } }
{ V _t4819 = Get(RD_8, "H23");
if (_t4819.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t4819));
{ V _t4820 = Get(_t4819, "face");
face_4802 = _t4820; }
{ V _t4821 = Get(_t4819, "qd");
qd_4803 = _t4821; } }
Set(N_70, "china27", Fn((V _arrowThis4829, int _argc4822, V S_4828, V _a4825, V _a4826, V _a4827, V[] _rest4823) => {
V PA_4830 = default;
V PD_4831 = default;
V MB_4832 = default;
V BR2_4833 = default;
double W_4834 = 0;
double Dp_4835 = 0;
double WU_4836 = 0;
double DU_4837 = 0;
double ZU_4838 = 0;
double Y1_4839 = 0;
double HU_4840 = 0;
double ZF_4841 = 0;
double BW_4842 = 0;
V SH_4843 = default;
V BAYS_4844 = default;
PA_4830 = ((V)("#ece6d6"));
PD_4831 = Call(shade_10, V.Undef, PA_4830, ((V)(0.9)));
MB_4832 = ((V)("#e9e6e0"));
BR2_4833 = ((V)("#c99a3e"));
W_4834 = 100D;
Dp_4835 = 40D;
WU_4836 = 96D;
DU_4837 = 20D;
ZU_4838 = ((((-Dp_4835) / 2D) + (DU_4837 / 2D)) + 1D);
Y1_4839 = 46D;
HU_4840 = 84D;
ZF_4841 = (ZU_4838 + (DU_4837 / 2D));
BW_4842 = ((WU_4836 - 8D) / 2D);
SH_4843 = Arr(((V)(76D)), ((V)(104D)));
BAYS_4844 = Arr();
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis4852, int _argc4845, V sg_4851, V _a4848, V _a4849, V _a4850, V[] _rest4846) => {
return Invoke(Arr(((V)((Y1_4839 + 2D))), Add(GetIdx(SH_4843, 0D), ((V)(1.6))), Add(GetIdx(SH_4843, 1D), ((V)(1.6)))), "forEach", Fn((V _arrowThis4861, int _argc4853, V b_4859, V j_4860, V _a4857, V _a4858, V[] _rest4854) => {
return Invoke(BAYS_4844, "push", NewObj(4).Put("cx", ((V)((ToNum(sg_4851) * ((BW_4842 / 2D) + 0.75))))).Put("b", b_4859).Put("t", (LtN(j_4860, 2D) ? GetK(SH_4843, j_4860) : ((V)(((Y1_4839 + 2D) + HU_4840))))).Put("j", j_4860).V);
}, 2, "", true));
}, 1, "", true));
return NewObj(4).Put("w", ((V)(104D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis4868, int _argc4862, V _a4864, V _a4865, V _a4866, V _a4867, V[] _rest4863) => {
V o_4869 = default;
V on_4870 = default;
V LC_4871 = default;
V CT_4872 = default;
V BS_4873 = default;
V TB_4874 = default;
V SB_4875 = default;
V BOT_4876 = default;
V plate_4877 = default;
V ST_4878 = default;
V fr_4879 = default;
o_4869 = Arr();
on_4870 = Call(glue_4801, V.Undef, o_4869);
Invoke(o_4869, "push", Call(box_4790, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((W_4834 - 8D))), ((V)(5D)), ((V)((Dp_4835 - 8D))), ((V)("#3a3630")), Call(W__4796, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
LC_4871 = Call(box_4790, V.Undef, ((V)(0D)), ((V)(5D)), ((V)(0D)), ((V)(W_4834)), ((V)(38D)), ((V)(Dp_4835)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V));
Invoke(o_4869, "push", LC_4871);
Invoke(Arr(((V)((-34.5))), ((V)(34.5))), "forEach", Fn((V _arrowThis4887, int _argc4880, V x_4886, V _a4883, V _a4884, V _a4885, V[] _rest4881) => {
V DR_4888 = default;
DR_4888 = GetIdx(Call(on_4870, V.Undef, LC_4871, Arr(Call(box_4790, V.Undef, x_4886, ((V)(7D)), ((V)(((Dp_4835 / 2D) + 0.45))), ((V)(28D)), ((V)(34D)), ((V)(0.8)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
Call(on_4870, V.Undef, DR_4888, Arr(Call(box_4790, V.Undef, x_4886, ((V)(7D)), ((V)(((Dp_4835 / 2D) + 1.15))), ((V)(28D)), ((V)(3D)), ((V)(0.6)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_4790, V.Undef, x_4886, ((V)(38D)), ((V)(((Dp_4835 / 2D) + 1.15))), ((V)(28D)), ((V)(3D)), ((V)(0.6)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_4790, V.Undef, ((V)((ToNum(x_4886) - 12.5))), ((V)(10D)), ((V)(((Dp_4835 / 2D) + 1.15))), ((V)(3D)), ((V)(28D)), ((V)(0.6)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_4790, V.Undef, Add(x_4886, ((V)(12.5))), ((V)(10D)), ((V)(((Dp_4835 / 2D) + 1.15))), ((V)(3D)), ((V)(28D)), ((V)(0.6)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_4790, V.Undef, x_4886, ((V)(10D)), ((V)(((Dp_4835 / 2D) + 0.95))), ((V)(22D)), ((V)(28D)), ((V)(0.1)), PD_4831, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(ball_4792, V.Undef, Add(x_4886, ((V)((LtN(x_4886, 0D) ? 10.6 : (-10.6))))), ((V)(23D)), ((V)(((Dp_4835 / 2D) + 1.9))), ((V)(1.1)), BR2_4833, Call(M__4797, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
Invoke(Arr(((V)(9D)), ((V)(20.4)), ((V)(31.8))), "forEach", Fn((V _arrowThis4896, int _argc4889, V y_4895, V _a4892, V _a4893, V _a4894, V[] _rest4890) => {
V DW_4897 = default;
DW_4897 = GetIdx(Call(on_4870, V.Undef, LC_4871, Arr(Call(box_4790, V.Undef, ((V)(0D)), y_4895, ((V)(((Dp_4835 / 2D) + 0.45))), ((V)(36D)), ((V)(10.4)), ((V)(0.8)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
Call(on_4870, V.Undef, DW_4897, Arr(Call(box_4790, V.Undef, ((V)(0D)), Add(y_4895, ((V)(1.6))), ((V)(((Dp_4835 / 2D) + 0.95))), ((V)(30D)), ((V)(7.2)), ((V)(0.1)), PD_4831, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(slabX_4794, V.Undef, ((V)(0D)), Add(y_4895, ((V)(5.2))), ((V)(((Dp_4835 / 2D) + 1.5))), ((V)(7D)), ((V)(1.4)), ((V)(1D)), BR2_4833, Call(M__4797, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("shine", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
CT_4872 = Call(box_4790, V.Undef, ((V)(0D)), ((V)(43D)), ((V)(0D)), ((V)((W_4834 + 4D))), ((V)(3D)), ((V)((Dp_4835 + 2D))), MB_4832, NewObj(3).Put("r", ((V)(0.8))).Put("mat", ((V)("cer"))).Put("shine", ((V)(1D))).V);
Invoke(o_4869, "push", CT_4872);
Call(on_4870, V.Undef, CT_4872, Arr(Call(slabX_4794, V.Undef, ((V)(0D)), ((V)(44.2)), ((V)(((Dp_4835 / 2D) + 1.05))), ((V)((W_4834 + 2D))), ((V)(0.2)), ((V)(0.05)), ((V)("#c8c2b8")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(cyl_4791, V.Undef, ((V)(28D)), ((V)(46D)), ((V)(13D)), ((V)(2D)), ((V)(6D)), ((V)("#f6f4ee")), NewObj(3).Put("n", ((V)(14D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.6))), Arr(((V)(1D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(6D)), ((V)(0D)), ((V)(0.7))))).V), Call(cyl_4791, V.Undef, ((V)(28D)), ((V)(52D)), ((V)(13D)), ((V)(7.4)), ((V)(0.8)), ((V)("#f6f4ee")), NewObj(2).Put("n", ((V)(20D))).Put("mat", ((V)("cer"))).V), Call(cyl_4791, V.Undef, ((V)(28D)), ((V)(52.8)), ((V)(13D)), ((V)(5.6)), ((V)(4.6)), ((V)("#f2dc8a")), NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(4.2)), ((V)(0D)), ((V)(1D))), Arr(((V)(4.6)), ((V)(0D)), ((V)(0.92))))).V), Call(cyl_4791, V.Undef, ((V)(28D)), ((V)(57.4)), ((V)(13D)), ((V)(5.2)), ((V)(0.6)), ((V)("#fbf6e6")), NewObj(1).Put("n", ((V)(18D))).V), Call(ball_4792, V.Undef, ((V)(26D)), ((V)(58D)), ((V)(11.4)), ((V)(0.9)), ((V)("#f2d43a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(ball_4792, V.Undef, ((V)(30D)), ((V)(58D)), ((V)(14D)), ((V)(0.9)), ((V)("#f2d43a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V), Call(cyl_4791, V.Undef, ((V)((-30D))), ((V)(46D)), ((V)(12D)), ((V)(5.6)), ((V)(1.2)), ((V)("#2f5ba8")), NewObj(2).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).V), Call(cyl_4791, V.Undef, ((V)((-30D))), ((V)(47.2)), ((V)(12D)), ((V)(3.6)), ((V)(5.4)), ((V)("#f6f4ee")), NewObj(3).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(2.6)), ((V)(0D)), ((V)(1D))), Arr(((V)(5D)), ((V)(0D)), ((V)(0.62))), Arr(((V)(5.4)), ((V)(0D)), ((V)(0.66))))).V), Call(ball_4792, V.Undef, ((V)((-30D))), ((V)(52.4)), ((V)(12D)), ((V)(1D)), ((V)("#2f5ba8")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
Invoke(o_4869, "push", Call(box_4790, V.Undef, ((V)(0D)), ((V)(Y1_4839)), ((V)(ZU_4838)), ((V)(WU_4836)), ((V)(2D)), ((V)(DU_4837)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis4905, int _argc4898, V sg_4904, V _a4901, V _a4902, V _a4903, V[] _rest4899) => {
return Invoke(o_4869, "push", Call(box_4790, V.Undef, ((V)((ToNum(sg_4904) * ((WU_4836 / 2D) - 2D)))), ((V)((Y1_4839 + 2D))), ((V)(ZU_4838)), ((V)(4D)), ((V)(HU_4840)), ((V)(DU_4837)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
BS_4873 = Call(slab_4793, V.Undef, ((V)(0D)), ((V)((Y1_4839 + 2D))), ((V)(((ZU_4838 - (DU_4837 / 2D)) + 1D))), ((V)((WU_4836 - 8D))), ((V)(HU_4840)), ((V)(2D)), ((V)("#f4ead2")), Call(W__4796, V.Undef, NewObj(1).Put("r", ((V)(0D))).V));
Invoke(o_4869, "push", BS_4873);
TB_4874 = Call(box_4790, V.Undef, ((V)(0D)), ((V)(((Y1_4839 + 2D) + HU_4840))), ((V)(ZU_4838)), ((V)(WU_4836)), ((V)(4D)), ((V)(DU_4837)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V));
Invoke(o_4869, "push", TB_4874);
Invoke(o_4869, "push", Call(box_4790, V.Undef, ((V)(0D)), ((V)(((Y1_4839 + 6D) + HU_4840))), ((V)((ZU_4838 + 0.8))), ((V)((WU_4836 + 6D))), ((V)(2.6)), ((V)((DU_4837 + 3.6))), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_4790, V.Undef, ((V)(0D)), ((V)(((Y1_4839 + 8.6) + HU_4840))), ((V)((ZU_4838 + 1.2))), ((V)((WU_4836 + 10D))), ((V)(3D)), ((V)((DU_4837 + 6D))), Call(shade_10, V.Undef, PA_4830, ((V)(1.03))), Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
Invoke(BAYS_4844, "forEach", Fn((V _arrowThis4913, int _argc4906, V B_4912, V _a4909, V _a4910, V _a4911, V[] _rest4907) => {
return Call(on_4870, V.Undef, BS_4873, Arr(Call(box_4790, V.Undef, Get(B_4912, "cx"), Add(Get(B_4912, "b"), ((V)(1D))), ((V)(((ZU_4838 - (DU_4837 / 2D)) + 2.05))), ((V)((BW_4842 - 3D))), ((V)(((ToNum(Get(B_4912, "t")) - ToNum(Get(B_4912, "b"))) - 2.4))), ((V)(0.1)), ((V)("#fff1cc")), Call(em_4799, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("op", ((V)(0.55))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
}, 1, "", true));
SB_4875 = Invoke(SH_4843, "map", Fn((V _arrowThis4921, int _argc4914, V y_4920, V _a4917, V _a4918, V _a4919, V[] _rest4915) => {
V Q_4922 = default;
Q_4922 = Call(box_4790, V.Undef, ((V)(0D)), y_4920, ((V)((ZU_4838 + 1D))), ((V)((WU_4836 - 8D))), ((V)(1.6)), ((V)((DU_4837 - 2D))), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V));
Invoke(o_4869, "push", Q_4922);
return Q_4922;
return default;
}, 1, "", true));
BOT_4876 = GetIdx(o_4869, (ToNum(Invoke(o_4869, "indexOf", BS_4873)) - 3D));
plate_4877 = Fn((V _arrowThis4934, int _argc4923, V x_4929, V y_4930, V z_4931, V r_4932, V[] _rest4924) => {
V P_4935 = default;
V par_4933 = default;
par_4933 = (_argc4923 > 4 ? _rest4924[0] : V.Undef);
P_4935 = Call(disc_4795, V.Undef, x_4929, Add(y_4930, r_4932), z_4931, r_4932, ((V)(0.7)), ((V)("#2f5ba8")), NewObj(3).Put("n", ((V)(20D))).Put("mat", ((V)("cer"))).Put("shine", ((V)(1D))).V);
Call(on_4870, V.Undef, par_4933, Arr(P_4935));
Call(on_4870, V.Undef, P_4935, Arr(Call(disc_4795, V.Undef, x_4929, Add(y_4930, r_4932), Add(z_4931, ((V)(0.7))), ((V)((ToNum(r_4932) * 0.9))), ((V)(0.05)), ((V)("#f8f6f0")), NewObj(2).Put("n", ((V)(20D))).Put("noOut", ((V)(1D))).V), Call(disc_4795, V.Undef, x_4929, Add(y_4930, r_4932), Add(z_4931, ((V)(0.75))), ((V)((ToNum(r_4932) * 0.62))), ((V)(0.05)), ((V)("#7a9ad0")), NewObj(2).Put("n", ((V)(18D))).Put("noOut", ((V)(1D))).V), Call(disc_4795, V.Undef, x_4929, Add(y_4930, r_4932), Add(z_4931, ((V)(0.8))), ((V)((ToNum(r_4932) * 0.5))), ((V)(0.05)), ((V)("#f8f6f0")), NewObj(2).Put("n", ((V)(18D))).Put("noOut", ((V)(1D))).V), Call(disc_4795, V.Undef, x_4929, Add(y_4930, r_4932), Add(z_4931, ((V)(0.85))), ((V)((ToNum(r_4932) * 0.26))), ((V)(0.05)), ((V)("#2f5ba8")), NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 5, "", true);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis4943, int _argc4936, V sg_4942, V _a4939, V _a4940, V _a4941, V[] _rest4937) => {
double bx_4944 = 0;
double yb_4945 = 0;
bx_4944 = (ToNum(sg_4942) * ((BW_4842 / 2D) + 0.75));
Invoke(Arr(((V)((-14D))), ((V)(0D)), ((V)(14D))), "forEach", Fn((V _arrowThis4953, int _argc4946, V dx_4952, V _a4949, V _a4950, V _a4951, V[] _rest4947) => {
return Call(plate_4877, V.Undef, Add(((V)(bx_4944)), dx_4952), Add(GetIdx(SH_4843, 1D), ((V)(1.6))), ((V)(((ZU_4838 - (DU_4837 / 2D)) + 2.4))), ((V)(6.4)), GetIdx(SB_4875, 1D));
}, 1, "", true));
Call(on_4870, V.Undef, GetIdx(SB_4875, 1D), Arr(Call(rod_4800, V.Undef, Arr(((V)(((bx_4944 - (BW_4842 / 2D)) + 0.4))), Add(GetIdx(SH_4843, 1D), ((V)(4.4))), ((V)(((ZU_4838 - (DU_4837 / 2D)) + 4.6)))), Arr(((V)(((bx_4944 + (BW_4842 / 2D)) - 0.4))), Add(GetIdx(SH_4843, 1D), ((V)(4.4))), ((V)(((ZU_4838 - (DU_4837 / 2D)) + 4.6)))), ((V)(0.35)), BR2_4833, Call(M__4797, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).V))));
Invoke(Arr(((V)((-13D))), ((V)(0D)), ((V)(13D))), "forEach", Fn((V _arrowThis4962, int _argc4954, V dx_4960, V i_4961, V _a4958, V _a4959, V[] _rest4955) => {
V x_4963 = default;
V yb_4964 = default;
x_4963 = Add(((V)(bx_4944)), dx_4960);
yb_4964 = Add(GetIdx(SH_4843, 0D), ((V)(1.6)));
Call(on_4870, V.Undef, GetIdx(SB_4875, 0D), Arr(Call(cyl_4791, V.Undef, x_4963, yb_4964, ((V)((ZU_4838 - 4D))), ((V)(5.2)), ((V)(1.3)), ((V)("#f6f4ee")), NewObj(2).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).V), Call(cyl_4791, V.Undef, x_4963, Add(yb_4964, ((V)(1.3))), ((V)((ZU_4838 - 4D))), ((V)(4.6)), ((V)(1.3)), ((V)("#f6f4ee")), NewObj(2).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).V), Call(cyl_4791, V.Undef, x_4963, Add(yb_4964, ((V)(2.6))), ((V)((ZU_4838 - 4D))), ((V)(4D)), ((V)(1.3)), ((V)("#f6f4ee")), NewObj(2).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).V)));
Call(on_4870, V.Undef, GetIdx(SB_4875, 0D), Arr(Call(cyl_4791, V.Undef, x_4963, yb_4964, ((V)((ZU_4838 + 5D))), ((V)(4D)), ((V)(0.6)), ((V)("#f6f4ee")), NewObj(2).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).V), Call(cyl_4791, V.Undef, x_4963, Add(yb_4964, ((V)(0.6))), ((V)((ZU_4838 + 5D))), ((V)(2.6)), ((V)(4D)), ((V)((SEqN(i_4961, 1D) ? "#2f5ba8" : "#f6f4ee"))), NewObj(3).Put("n", ((V)(16D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(1.2)), ((V)(0D)), ((V)(0.9))), Arr(((V)(4D)), ((V)(0D)), ((V)(1D))))).V), Call(cyl_4791, V.Undef, x_4963, Add(yb_4964, ((V)(4.4))), ((V)((ZU_4838 + 5D))), ((V)(2.4)), ((V)(0.2)), ((V)("#7a5030")), NewObj(2).Put("n", ((V)(14D))).Put("noOut", ((V)(1D))).V)));
return default;
}, 2, "", true));
yb_4945 = (Y1_4839 + 2D);
Call(on_4870, V.Undef, BOT_4876, Arr(Call(cyl_4791, V.Undef, ((V)((bx_4944 - 12D))), ((V)(yb_4945)), ((V)((ZU_4838 - 3D))), ((V)(6.6)), ((V)(1D)), ((V)("#f6f4ee")), NewObj(2).Put("n", ((V)(20D))).Put("mat", ((V)("cer"))).V), Call(cyl_4791, V.Undef, ((V)((bx_4944 - 12D))), ((V)((yb_4945 + 1D))), ((V)((ZU_4838 - 3D))), ((V)(6.6)), ((V)(1D)), ((V)("#2f5ba8")), NewObj(2).Put("n", ((V)(20D))).Put("mat", ((V)("cer"))).V), Call(cyl_4791, V.Undef, ((V)((bx_4944 - 12D))), ((V)((yb_4945 + 2D))), ((V)((ZU_4838 - 3D))), ((V)(6.6)), ((V)(1D)), ((V)("#f6f4ee")), NewObj(2).Put("n", ((V)(20D))).Put("mat", ((V)("cer"))).V), Call(cyl_4791, V.Undef, ((V)((bx_4944 - 12D))), ((V)((yb_4945 + 3D))), ((V)((ZU_4838 - 3D))), ((V)(6.6)), ((V)(1D)), ((V)("#f6f4ee")), NewObj(2).Put("n", ((V)(20D))).Put("mat", ((V)("cer"))).V)));
if (LtN(sg_4942, 0D)) {
Call(on_4870, V.Undef, BOT_4876, Arr(Call(cyl_4791, V.Undef, ((V)((bx_4944 + 8D))), ((V)(yb_4945)), ((V)((ZU_4838 - 1D))), ((V)(6D)), ((V)(9D)), ((V)("#f6f4ee")), NewObj(3).Put("n", ((V)(20D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(1D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))), Arr(((V)(8D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(9D)), ((V)(0D)), ((V)(0.5))))).V), Call(ball_4792, V.Undef, ((V)((bx_4944 + 8D))), ((V)((yb_4945 + 9D))), ((V)((ZU_4838 - 1D))), ((V)(1.2)), ((V)("#2f5ba8")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
} else {
Call(on_4870, V.Undef, BOT_4876, Arr(Call(cyl_4791, V.Undef, ((V)((bx_4944 + 8D))), ((V)(yb_4945)), ((V)((ZU_4838 - 1D))), ((V)(4.2)), ((V)(14D)), ((V)("#f6f4ee")), NewObj(3).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))), Arr(((V)(11D)), ((V)(0D)), ((V)(0.62))), Arr(((V)(14D)), ((V)(0D)), ((V)(0.8))))).V), Call(cyl_4791, V.Undef, ((V)((bx_4944 + 8D))), ((V)((yb_4945 + 5D))), ((V)((ZU_4838 - 1D))), ((V)(4.25)), ((V)(2D)), ((V)("#2f5ba8")), NewObj(2).Put("n", ((V)(18D))).Put("noOut", ((V)(1D))).V)));
}
return default;
}, 1, "", true));
ST_4878 = Call(box_4790, V.Undef, ((V)(0D)), ((V)((Y1_4839 + 2D))), ((V)((ZF_4841 - 0.4))), ((V)(3.4)), ((V)(HU_4840)), ((V)(1.2)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V));
Invoke(o_4869, "push", ST_4878);
fr_4879 = Arr();
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis4972, int _argc4965, V sg_4971, V _a4968, V _a4969, V _a4970, V[] _rest4966) => {
double x0_4973 = 0;
double x1_4974 = 0;
double cx_4975 = 0;
double w_4976 = 0;
double zf_4977 = 0;
x0_4973 = (GtN(sg_4971, 0D) ? 1.7 : (-((WU_4836 / 2D) - 4D)));
x1_4974 = (GtN(sg_4971, 0D) ? ((WU_4836 / 2D) - 4D) : (-1.7));
cx_4975 = ((x0_4973 + x1_4974) / 2D);
w_4976 = (x1_4974 - x0_4973);
zf_4977 = (ZF_4841 + 0.25);
Invoke(fr_4879, "push", Call(box_4790, V.Undef, ((V)(cx_4975)), ((V)((Y1_4839 + 2D))), ((V)(zf_4977)), ((V)(w_4976)), ((V)(2.6)), ((V)(0.6)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V)), Call(box_4790, V.Undef, ((V)(cx_4975)), ((V)(((Y1_4839 + HU_4840) - 0.6))), ((V)(zf_4977)), ((V)(w_4976)), ((V)(2.6)), ((V)(0.6)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V)), Call(box_4790, V.Undef, ((V)((x0_4973 + 1.2))), ((V)((Y1_4839 + 4.6))), ((V)(zf_4977)), ((V)(2.4)), ((V)((HU_4840 - 5.2))), ((V)(0.6)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V)), Call(box_4790, V.Undef, ((V)((x1_4974 - 1.2))), ((V)((Y1_4839 + 4.6))), ((V)(zf_4977)), ((V)(2.4)), ((V)((HU_4840 - 5.2))), ((V)(0.6)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V)));
Invoke(SH_4843, "forEach", Fn((V _arrowThis4985, int _argc4978, V y_4984, V _a4981, V _a4982, V _a4983, V[] _rest4979) => {
return Invoke(fr_4879, "push", Call(box_4790, V.Undef, ((V)(cx_4975)), ((V)((ToNum(y_4984) - 0.4))), ((V)(zf_4977)), ((V)((w_4976 - 4.8))), ((V)(2.4)), ((V)(0.6)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V)));
}, 1, "", true));
Invoke(Arr(Arr(((V)((Y1_4839 + 4.6))), ((V)((ToNum(GetIdx(SH_4843, 0D)) - 0.4)))), Arr(Add(GetIdx(SH_4843, 0D), ((V)(2D))), ((V)((ToNum(GetIdx(SH_4843, 1D)) - 0.4)))), Arr(Add(GetIdx(SH_4843, 1D), ((V)(2D))), ((V)(((Y1_4839 + HU_4840) - 0.6))))), "forEach", Fn((V _arrowThis4997, int _argc4986, V _a4988, V _a4989, V _a4990, V _a4991, V[] _rest4987) => {
V a_4994 = default;
V b_4996 = default;
{ V _t4992 = ListOf(_a4988);
{ V _t4993 = GetIdx(_t4992, 0D);
a_4994 = _t4993; }
{ V _t4995 = GetIdx(_t4992, 1D);
b_4996 = _t4995; }
}
return Invoke(fr_4879, "push", Call(box_4790, V.Undef, ((V)(cx_4975)), a_4994, ((V)((zf_4977 + 0.1))), ((V)(1.4)), ((V)((ToNum(b_4996) - ToNum(a_4994)))), ((V)(0.4)), PA_4830, Call(PL_4798, V.Undef, NewObj(1).Put("r", ((V)(0.1))).V)));
}, 1, "", true));
Invoke(fr_4879, "push", Call(ball_4792, V.Undef, ((V)((GtN(sg_4971, 0D) ? (x0_4973 + 2.6) : (x1_4974 - 2.6)))), ((V)((Y1_4839 + (HU_4840 / 2D)))), ((V)((zf_4977 + 1.2))), ((V)(0.9)), BR2_4833, Call(M__4797, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).V)));
return default;
}, 1, "", true));
Call(on_4870, V.Undef, ST_4878, fr_4879, Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return o_4869;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis5005, int _argc4998, V c_5004, V _a5001, V _a5002, V _a5003, V[] _rest4999) => {
V f0_5006 = default;
JsStrBuf f_5007 = null;
f0_5006 = Call(face_4802, V.Undef, c_5004, ((V)(0D)), ((V)(1D)));
if (LtN(f0_5006, 0.08)) {
return NewObj(0).V;
}
f_5007 = new JsStrBuf("");
Invoke(BAYS_4844, "forEach", Fn((V _arrowThis5016, int _argc5008, V B_5014, V i_5015, V _a5012, V _a5013, V[] _rest5009) => {
double x0_5017 = 0;
double x1_5018 = 0;
double z_5019 = 0;
x0_5017 = ((ToNum(Get(B_5014, "cx")) - (BW_4842 / 2D)) + 0.6);
x1_5018 = (ToNum(Add(Get(B_5014, "cx"), ((V)((BW_4842 / 2D))))) - 0.6);
z_5019 = ((ZU_4838 - (DU_4837 / 2D)) + 2.2);
f_5007.S("<path d=\"").V(Call(qd_4803, V.Undef, c_5004, Arr(Arr(((V)((x0_5017 + 4D))), ((V)((ToNum(Get(B_5014, "t")) - 0.3))), ((V)((z_5019 + 1D)))), Arr(((V)((x1_5018 - 4D))), ((V)((ToNum(Get(B_5014, "t")) - 0.3))), ((V)((z_5019 + 1D)))), Arr(((V)(x1_5018)), Add(Get(B_5014, "b"), ((V)(0.4))), ((V)((ZF_4841 - 1D)))), Arr(((V)(x0_5017)), Add(Get(B_5014, "b"), ((V)(0.4))), ((V)((ZF_4841 - 1D))))))).S("\" fill=\"url(#c54L)\" opacity=\"0.6\">").V(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.5;0.72;0.5")), ((V)(8D)), Call(n4_17, V.Undef, ((V)(((-ToNum(i_5015)) * 1.3)))), Call(SPL_15, V.Undef, ((V)(2D))))).S("</path>");
return default;
}, 2, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis5027, int _argc5020, V sg_5026, V _a5023, V _a5024, V _a5025, V[] _rest5021) => {
double x0_5028 = 0;
double x1_5029 = 0;
double z_5030 = 0;
double y0_5031 = 0;
double y1_5032 = 0;
double w_5033 = 0;
x0_5028 = (GtN(sg_5026, 0D) ? 1.7 : (-((WU_4836 / 2D) - 4D)));
x1_5029 = (GtN(sg_5026, 0D) ? ((WU_4836 / 2D) - 4D) : (-1.7));
z_5030 = (ZF_4841 + 0.3);
y0_5031 = (Y1_4839 + 2D);
y1_5032 = ((Y1_4839 + 2D) + HU_4840);
f_5007.S("<path d=\"").V(Call(qd_4803, V.Undef, c_5004, Arr(Arr(((V)(x0_5028)), ((V)(y1_5032)), ((V)(z_5030))), Arr(((V)(x1_5029)), ((V)(y1_5032)), ((V)(z_5030))), Arr(((V)(x1_5029)), ((V)(y0_5031)), ((V)(z_5030))), Arr(((V)(x0_5028)), ((V)(y0_5031)), ((V)(z_5030)))))).S("\" fill=\"#e6f4f6\" opacity=\"").V(Call(n4_17, V.Undef, ((V)((0.08 * ToNum(f0_5006)))))).S("\"/>");
w_5033 = (x1_5029 - x0_5028);
f_5007.S("<path d=\"").V(Call(qd_4803, V.Undef, c_5004, Arr(Arr(((V)((x0_5028 + (w_5033 * 0.12)))), ((V)(y1_5032)), ((V)(z_5030))), Arr(((V)((x0_5028 + (w_5033 * 0.3)))), ((V)(y1_5032)), ((V)(z_5030))), Arr(((V)((x0_5028 + (w_5033 * 0.08)))), ((V)(y0_5031)), ((V)(z_5030))), Arr(((V)(((x0_5028 - (w_5033 * 0.02)) + 0.2))), ((V)(y0_5031)), ((V)(z_5030)))))).S("\" fill=\"#ffffff\" opacity=\"").V(Call(n4_17, V.Undef, ((V)((0.12 * ToNum(f0_5006)))))).S("\"/><path d=\"").V(Call(qd_4803, V.Undef, c_5004, Arr(Arr(((V)((x0_5028 + (w_5033 * 0.42)))), ((V)(y1_5032)), ((V)(z_5030))), Arr(((V)((x0_5028 + (w_5033 * 0.47)))), ((V)(y1_5032)), ((V)(z_5030))), Arr(((V)((x0_5028 + (w_5033 * 0.3)))), ((V)(y0_5031)), ((V)(z_5030))), Arr(((V)((x0_5028 + (w_5033 * 0.25)))), ((V)(y0_5031)), ((V)(z_5030)))))).S("\" fill=\"#ffffff\" opacity=\"").V(Call(n4_17, V.Undef, ((V)((0.08 * ToNum(f0_5006)))))).S("\"/>");
return default;
}, 1, "", true));
return NewObj(2).Put("defs", ((V)("<linearGradient id=\"c54L\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff2c8\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#fff2c8\" stop-opacity=\"0\"/></linearGradient>"))).Put("front", ((V)(f_5007.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
}
{
V K2_5034 = default;
V box_5035 = default;
V cyl_5036 = default;
V ball_5037 = default;
V slab_5038 = default;
V slabX_5039 = default;
V disc_5040 = default;
V W__5041 = default;
V M__5042 = default;
V PL_5043 = default;
V em_5044 = default;
V rod_5045 = default;
V frame_5046 = default;
V glue_5047 = default;
V R0w_5048 = default;
V face_5049 = default;
V qd_5050 = default;
V FP_5051 = default;
V vY_5052 = default;
V KT_5053 = default;
V carousel_5054 = default;
V DEF74_5055 = default;
K2_5034 = Get(X_9, "K");
{ V _t5056 = K2_5034;
if (_t5056.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t5056));
{ V _t5057 = Get(_t5056, "box");
box_5035 = _t5057; }
{ V _t5058 = Get(_t5056, "cyl");
cyl_5036 = _t5058; }
{ V _t5059 = Get(_t5056, "ball");
ball_5037 = _t5059; }
{ V _t5060 = Get(_t5056, "slab");
slab_5038 = _t5060; }
{ V _t5061 = Get(_t5056, "slabX");
slabX_5039 = _t5061; }
{ V _t5062 = Get(_t5056, "disc");
disc_5040 = _t5062; } }
{ V _t5063 = Get(RD_8, "H16");
if (_t5063.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t5063));
{ V _t5064 = Get(_t5063, "W_");
W__5041 = _t5064; }
{ V _t5065 = Get(_t5063, "M_");
M__5042 = _t5065; }
{ V _t5066 = Get(_t5063, "PL");
PL_5043 = _t5066; }
{ V _t5067 = Get(_t5063, "em");
em_5044 = _t5067; }
{ V _t5068 = Get(_t5063, "rod");
rod_5045 = _t5068; }
{ V _t5069 = Get(_t5063, "frame");
frame_5046 = _t5069; } }
{ V _t5070 = Get(RD_8, "H22");
if (_t5070.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t5070));
{ V _t5071 = Get(_t5070, "glue");
glue_5047 = _t5071; }
{ V _t5072 = Get(_t5070, "R0");
R0w_5048 = _t5072; } }
{ V _t5073 = Get(RD_8, "H23");
if (_t5073.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t5073));
{ V _t5074 = Get(_t5073, "face");
face_5049 = _t5074; }
{ V _t5075 = Get(_t5073, "qd");
qd_5050 = _t5075; } }
FP_5051 = Fn((V _arrowThis5084, int _argc5076, V c_5082, V P_5083, V _a5080, V _a5081, V[] _rest5077) => {
V q_5085 = default;
q_5085 = Invoke(c_5082, "p", GetIdx(P_5083, 0D), GetIdx(P_5083, 1D), GetIdx(P_5083, 2D));
return Arr(GetIdx(q_5085, 0D), GetIdx(q_5085, 1D));
return default;
}, 2, "", true);
vY_5052 = Fn((V _arrowThis5093, int _argc5086, V c_5092, V _a5089, V _a5090, V _a5091, V[] _rest5087) => {
V a_5094 = default;
V b_5095 = default;
a_5094 = Invoke(c_5092, "p", ((V)(0D)), ((V)(0D)), ((V)(0D)));
b_5095 = Invoke(c_5092, "p", ((V)(0D)), ((V)(1D)), ((V)(0D)));
return Arr(((V)((ToNum(GetIdx(b_5095, 0D)) - ToNum(GetIdx(a_5094, 0D))))), ((V)((ToNum(GetIdx(b_5095, 1D)) - ToNum(GetIdx(a_5094, 1D))))));
return default;
}, 1, "", true);
KT_5053 = Fn((V _arrowThis5103, int _argc5096, V n_5102, V _a5099, V _a5100, V _a5101, V[] _rest5097) => {
return ((V)(JsStrBuf.Begin().S(" keyTimes=\"").V(Invoke(Call(rep_18, V.Undef, Add(n_5102, ((V)(1D))), Fn((V _arrowThis5111, int _argc5104, V i_5110, V _a5107, V _a5108, V _a5109, V[] _rest5105) => {
return Call(n4_17, V.Undef, ((V)((ToNum(i_5110) / ToNum(n_5102)))));
}, 1, "", true)), "join", ((V)(";")))).S("\"").End()));
}, 1, "", true);
carousel_5054 = Fn((V _arrowThis5125, int _argc5112, V c_5118, V cx_5119, V y0_5120, V cz_5121, V[] _rest5113) => {
double NK_5126 = 0;
V k_5127 = default;
V vy_5128 = default;
V C0_5129 = default;
V back_5130 = default;
V front_5131 = default;
JsStrBuf @base_5132 = null;
V tier_5133 = default;
V t1_5134 = default;
V t2_5135 = default;
V pa_5136 = default;
V pb_5137 = default;
V post_5138 = default;
V b1_5139 = default;
V bs_5140 = default;
V base1_5141 = default;
V base2_5142 = default;
V T_5122 = default;
V ph_5123 = default;
V cols_5124 = default;
T_5122 = (_argc5112 > 4 ? _rest5113[0] : V.Undef);
ph_5123 = (_argc5112 > 5 ? _rest5113[1] : V.Undef);
cols_5124 = (_argc5112 > 6 ? _rest5113[2] : V.Undef);
NK_5126 = 24D;
k_5127 = Get(c_5118, "k");
vy_5128 = Call(vY_5052, V.Undef, c_5118);
C0_5129 = Call(FP_5051, V.Undef, c_5118, Arr(cx_5119, y0_5120, cz_5121));
back_5130 = ((V)(""));
front_5131 = ((V)(""));
@base_5132 = new JsStrBuf("");
tier_5133 = Fn((V _arrowThis5155, int _argc5143, V y_5149, V r_5150, V n_5151, V jr_5152, V[] _rest5144) => {
JsStrBuf b_5156 = null;
JsStrBuf f_5157 = null;
V ctr_5158 = default;
double ry_5159 = 0;
V jh_5153 = default;
V ti_5154 = default;
jh_5153 = (_argc5143 > 4 ? _rest5144[0] : V.Undef);
ti_5154 = (_argc5143 > 5 ? _rest5144[1] : V.Undef);
b_5156 = new JsStrBuf("");
f_5157 = new JsStrBuf("");
ctr_5158 = Call(FP_5051, V.Undef, c_5118, Arr(cx_5119, y_5149, cz_5121));
ry_5159 = System.Math.Abs((ToNum(GetIdx(Call(FP_5051, V.Undef, c_5118, Arr(cx_5119, y_5149, Add(cz_5121, r_5150))), 1D)) - ToNum(GetIdx(ctr_5158, 1D))));
@base_5132.S("<ellipse cx=\"").V(Call(f1_16, V.Undef, GetIdx(ctr_5158, 0D))).S("\" cy=\"").V(Call(f1_16, V.Undef, Add(GetIdx(ctr_5158, 1D), ((V)((0.5 * ToNum(k_5127))))))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(Add(r_5150, ((V)(1.6)))) * ToNum(k_5127)))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)((((ry_5159 * ToNum(Add(r_5150, ((V)(1.6))))) / ToNum(r_5150)) + (0.5 * ToNum(k_5127))))))).S("\" fill=\"#6a4a14\"/><ellipse cx=\"").V(Call(f1_16, V.Undef, GetIdx(ctr_5158, 0D))).S("\" cy=\"").V(Call(f1_16, V.Undef, GetIdx(ctr_5158, 1D))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(Add(r_5150, ((V)(1.6)))) * ToNum(k_5127)))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)(((ry_5159 * ToNum(Add(r_5150, ((V)(1.6))))) / ToNum(r_5150)))))).S("\" fill=\"url(#k74b)\"/><ellipse cx=\"").V(Call(f1_16, V.Undef, GetIdx(ctr_5158, 0D))).S("\" cy=\"").V(Call(f1_16, V.Undef, GetIdx(ctr_5158, 1D))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((ToNum(Add(r_5150, ((V)(1.2)))) * ToNum(k_5127)))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)(((ry_5159 * ToNum(Add(r_5150, ((V)(1.2))))) / ToNum(r_5150)))))).S("\" fill=\"none\" stroke=\"#fff2c0\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.25 * ToNum(k_5127)))))).S("\" opacity=\"0.7\"/>");
{
double i_5160 = 0;
i_5160 = 0D;
while (true) {
if (!(Lt(((V)(i_5160)), n_5151))) break;
V pos_5162 = default;
V fr_5163 = default;
V col_5164 = default;
double hh_5165 = 0;
double rx_5166 = 0;
double ry2_5167 = 0;
V J_5168 = default;
V mv_5169 = default;
V op_5170 = default;
pos_5162 = Arr();
fr_5163 = Arr();
{
double j_5171 = 0;
j_5171 = 0D;
while (true) {
if (!((j_5171 <= NK_5126))) break;
V a_5173 = default;
V q_5174 = default;
a_5173 = Add(ph_5123, ((V)(((2D * PI_11) * ((i_5160 / ToNum(n_5151)) + (j_5171 / NK_5126))))));
q_5174 = Call(FP_5051, V.Undef, c_5118, Arr(Add(cx_5119, ((V)((FdLibm.Sin(ToNum(a_5173)) * ToNum(r_5150))))), y_5149, Add(cz_5121, ((V)((FdLibm.Cos(ToNum(a_5173)) * ToNum(r_5150)))))));
Invoke(pos_5162, "push", ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, GetIdx(q_5174, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(q_5174, 1D))).End())));
Invoke(fr_5163, "push", ((V)((Gt(GetIdx(q_5174, 1D), GetIdx(ctr_5158, 1D)) ? 1D : 0D))));
j_5171++;
}
}
col_5164 = GetIdx(cols_5124, ((i_5160 + (ToNum(ti_5154) * 3D)) % ToNum(Get(cols_5124, "length"))));
hh_5165 = (ToNum(jh_5153) * Hypot(ToNum(GetIdx(vy_5128, 0D)), ToNum(GetIdx(vy_5128, 1D))));
rx_5166 = (ToNum(jr_5152) * ToNum(k_5127));
ry2_5167 = Max(0.3, ((ry_5159 * ToNum(jr_5152)) / ToNum(r_5150)));
J_5168 = ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)((-rx_5166))))).S(" 0V").V(Call(f1_16, V.Undef, ((V)((-hh_5165))))).S("H").V(Call(f1_16, V.Undef, ((V)(rx_5166)))).S("V0A").V(Call(f1_16, V.Undef, ((V)(rx_5166)))).S(" ").V(Call(f1_16, V.Undef, ((V)(ry2_5167)))).S(" 0 0 1 ").V(Call(f1_16, V.Undef, ((V)((-rx_5166))))).S(" 0Z\" fill=\"").V(col_5164).S("\"/><path d=\"M").V(Call(f1_16, V.Undef, ((V)((-rx_5166))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((-hh_5165) * 0.82))))).S("V").V(Call(f1_16, V.Undef, ((V)((-hh_5165))))).S("H").V(Call(f1_16, V.Undef, ((V)(rx_5166)))).S("V").V(Call(f1_16, V.Undef, ((V)(((-hh_5165) * 0.82))))).S("Z\" fill=\"#f4f4ee\" opacity=\"0.5\"/>").S("<rect x=\"").V(Call(f1_16, V.Undef, ((V)((-rx_5166))))).S("\" y=\"").V(Call(f1_16, V.Undef, ((V)(((-hh_5165) * 0.6))))).S("\" width=\"").V(Call(f1_16, V.Undef, ((V)((2D * rx_5166))))).S("\" height=\"").V(Call(f1_16, V.Undef, ((V)((hh_5165 * 0.28))))).S("\" fill=\"#f6efdc\"/><path d=\"M").V(Call(f1_16, V.Undef, ((V)(((-rx_5166) * 0.6))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((-hh_5165) * 0.47))))).S("h").V(Call(f1_16, V.Undef, ((V)((rx_5166 * 1.2))))).S("\" stroke=\"#5a4020\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.18 * ToNum(k_5127)))))).S("\"/>").S("<ellipse cy=\"").V(Call(f1_16, V.Undef, ((V)((-hh_5165))))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((rx_5166 * 1.05))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)((ry2_5167 * 1.05))))).S("\" fill=\"url(#k74b)\"/><rect x=\"").V(Call(f1_16, V.Undef, ((V)(((-rx_5166) * 1.05))))).S("\" y=\"").V(Call(f1_16, V.Undef, ((V)(((-hh_5165) - (0.9 * ToNum(k_5127))))))).S("\" width=\"").V(Call(f1_16, V.Undef, ((V)((rx_5166 * 2.1))))).S("\" height=\"").V(Call(f1_16, V.Undef, ((V)((0.9 * ToNum(k_5127)))))).S("\" fill=\"url(#k74v)\"/><ellipse cy=\"").V(Call(f1_16, V.Undef, ((V)(((-hh_5165) - (0.9 * ToNum(k_5127))))))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((rx_5166 * 1.05))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)((ry2_5167 * 1.05))))).S("\" fill=\"#e8c46a\"/>").S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)(((-rx_5166) * 0.6))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((-hh_5165) * 0.1))))).S("V").V(Call(f1_16, V.Undef, ((V)(((-hh_5165) * 0.78))))).S("\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(k_5127)))))).S("\" opacity=\"0.55\"/>").End()));
mv_5169 = ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"translate\" values=\"").V(Invoke(pos_5162, "join", ((V)(";")))).S("\" dur=\"").V(T_5122).S("s\"").V(Call(KT_5053, V.Undef, ((V)(NK_5126)))).S(" repeatCount=\"indefinite\"/>").End()));
op_5170 = Fn((V _arrowThis5182, int _argc5175, V v_5181, V _a5178, V _a5179, V _a5180, V[] _rest5176) => {
return ((V)(JsStrBuf.Begin().S("<animate attributeName=\"opacity\" values=\"").V(Invoke(Invoke(fr_5163, "map", Fn((V _arrowThis5190, int _argc5183, V x_5189, V _a5186, V _a5187, V _a5188, V[] _rest5184) => {
return ((V)((SEq(x_5189, v_5181) ? 1D : 0D)));
}, 1, "", true)), "join", ((V)(";")))).S("\" dur=\"").V(T_5122).S("s\"").V(Call(KT_5053, V.Undef, ((V)(NK_5126)))).S(" calcMode=\"discrete\" repeatCount=\"indefinite\"/>").End()));
}, 1, "", true);
b_5156.S("<g opacity=\"").N((Truthy(GetIdx(fr_5163, 0D)) ? 0D : 1D)).S("\">").V(Call(op_5170, V.Undef, ((V)(0D)))).S("<g>").V(mv_5169).V(J_5168).S("</g></g>");
f_5157.S("<g opacity=\"").V(GetIdx(fr_5163, 0D)).S("\">").V(Call(op_5170, V.Undef, ((V)(1D)))).S("<g>").V(mv_5169).V(J_5168).S("</g></g>");
i_5160++;
}
}
return Arr(((V)(b_5156.Str)), ((V)(f_5157.Str)));
return default;
}, 6, "", true);
t1_5134 = Call(tier_5133, V.Undef, Add(y0_5120, ((V)(0.6))), ((V)(7.4)), ((V)(8D)), ((V)(1.5)), ((V)(4.4)), ((V)(0D)));
t2_5135 = Call(tier_5133, V.Undef, Add(y0_5120, ((V)(8.6))), ((V)(5.4)), ((V)(6D)), ((V)(1.3)), ((V)(3.8)), ((V)(1D)));
pa_5136 = Call(FP_5051, V.Undef, c_5118, Arr(cx_5119, y0_5120, cz_5121));
pb_5137 = Call(FP_5051, V.Undef, c_5118, Arr(cx_5119, Add(y0_5120, ((V)(15D))), cz_5121));
post_5138 = ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_16, V.Undef, GetIdx(pa_5136, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(pa_5136, 1D))).S("L").V(Call(f1_16, V.Undef, GetIdx(pb_5137, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(pb_5137, 1D))).S("\" stroke=\"#8a6420\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((1.3 * ToNum(k_5127)))))).S("\"/><path d=\"M").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(pa_5136, 0D)) - (0.3 * ToNum(k_5127))))))).S(" ").V(Call(f1_16, V.Undef, GetIdx(pa_5136, 1D))).S("L").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(pb_5137, 0D)) - (0.3 * ToNum(k_5127))))))).S(" ").V(Call(f1_16, V.Undef, GetIdx(pb_5137, 1D))).S("\" stroke=\"#fff0b8\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(k_5127)))))).S("\"/><circle cx=\"").V(Call(f1_16, V.Undef, GetIdx(pb_5137, 0D))).S("\" cy=\"").V(Call(f1_16, V.Undef, GetIdx(pb_5137, 1D))).S("\" r=\"").V(Call(f1_16, V.Undef, ((V)((1.3 * ToNum(k_5127)))))).S("\" fill=\"url(#k74b)\"/>").End()));
b1_5139 = Get(Invoke(((V)(@base_5132.Str)), "split", ((V)("<ellipse"))), "length");
_ = b1_5139;
bs_5140 = (Invoke(((V)(@base_5132.Str)), "match", NewRegExp(RX0, "<ellipse[^>]*\\/>", "g")) is var _t5191 && Truthy(_t5191) ? _t5191 : Arr());
base1_5141 = Invoke(Invoke(bs_5140, "slice", ((V)(0D)), ((V)(3D))), "join", ((V)("")));
base2_5142 = Invoke(Invoke(bs_5140, "slice", ((V)(3D))), "join", ((V)("")));
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_16, V.Undef, GetIdx(C0_5129, 0D))).S("\" cy=\"").V(Call(f1_16, V.Undef, Add(GetIdx(C0_5129, 1D), ((V)((1D * ToNum(k_5127))))))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((10D * ToNum(k_5127)))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)((3D * ToNum(k_5127)))))).S("\" fill=\"#000000\" opacity=\"0.25\" filter=\"url(#k74f)\"/>").V(base1_5141).V(GetIdx(t1_5134, 0D)).V(Invoke(post_5138, "replace", NewRegExp(RX1, "<circle[^>]*\\/>", ""), ((V)("")))).V(GetIdx(t1_5134, 1D)).V(base2_5142).V(GetIdx(t2_5135, 0D)).V(GetIdx(Invoke(post_5138, "match", NewRegExp(RX1, "<circle[^>]*\\/>", "")), 0D)).V(GetIdx(t2_5135, 1D)).End()));
return default;
}, 7, "", true);
DEF74_5055 = ((V)("<linearGradient id=\"k74b\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff0b8\"/><stop offset=\"0.45\" stop-color=\"#d8a848\"/><stop offset=\"1\" stop-color=\"#8a6420\"/></linearGradient><linearGradient id=\"k74v\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8a6420\"/><stop offset=\"0.4\" stop-color=\"#f6dc96\"/><stop offset=\"1\" stop-color=\"#9a7228\"/></linearGradient><filter id=\"k74f\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"1\"/></filter>"));
Set(N_70, "butler27", Fn((V _arrowThis5199, int _argc5192, V S_5198, V _a5195, V _a5196, V _a5197, V[] _rest5193) => {
V GR_5200 = default;
V GL_5201 = default;
V BR2_5202 = default;
V WAL_5203 = default;
V MB_5204 = default;
double W_5205 = 0;
double Dp_5206 = 0;
double WU_5207 = 0;
double DU_5208 = 0;
double ZU_5209 = 0;
double Y1_5210 = 0;
double HU_5211 = 0;
double ZF_5212 = 0;
V SH_5213 = default;
GR_5200 = ((V)("#2f4a3c"));
GL_5201 = Call(shade_10, V.Undef, GR_5200, ((V)(1.12)));
BR2_5202 = ((V)("#c99a3e"));
WAL_5203 = ((V)("#5a3820"));
MB_5204 = ((V)("#f2efe9"));
W_5205 = 100D;
Dp_5206 = 40D;
WU_5207 = 98D;
DU_5208 = 22D;
ZU_5209 = ((((-Dp_5206) / 2D) + (DU_5208 / 2D)) + 1D);
Y1_5210 = 46D;
HU_5211 = 84D;
ZF_5212 = (ZU_5209 + (DU_5208 / 2D));
SH_5213 = Arr(((V)(70D)), ((V)(94D)));
return NewObj(4).Put("w", ((V)(104D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis5220, int _argc5214, V _a5216, V _a5217, V _a5218, V _a5219, V[] _rest5215) => {
V o_5221 = default;
V on_5222 = default;
V R_5223 = default;
V LC_5224 = default;
V CT_5225 = default;
V vein_5226 = default;
V BS_5227 = default;
V TB_5228 = default;
V SB_5229 = default;
V BOT_5230 = default;
V can_5231 = default;
double yb_5232 = 0;
V RL_5233 = default;
o_5221 = Arr();
on_5222 = Call(glue_5047, V.Undef, o_5221);
R_5223 = Call(R0w_5048, V.Undef, ((V)("but27")));
Invoke(o_5221, "push", Call(box_5035, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((W_5205 - 6D))), ((V)(4D)), ((V)((Dp_5206 - 6D))), ((V)("#1e2a22")), Call(PL_5043, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
LC_5224 = Call(box_5035, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(W_5205)), ((V)(39D)), ((V)(Dp_5206)), GR_5200, Call(PL_5043, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V));
Invoke(o_5221, "push", LC_5224);
Call(on_5222, V.Undef, LC_5224, Arr(Call(slabX_5039, V.Undef, ((V)(0D)), ((V)(4.6)), ((V)(((Dp_5206 / 2D) + 0.05))), ((V)((W_5205 - 2D))), ((V)(0.6)), ((V)(0.1)), BR2_5202, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Invoke(Arr(((V)((-33D))), ((V)(33D))), "forEach", Fn((V _arrowThis5241, int _argc5234, V x_5240, V _a5237, V _a5238, V _a5239, V[] _rest5235) => {
V DR_5242 = default;
DR_5242 = GetIdx(Call(on_5222, V.Undef, LC_5224, Arr(Call(box_5035, V.Undef, x_5240, ((V)(7D)), ((V)(((Dp_5206 / 2D) + 0.45))), ((V)(32D)), ((V)(34D)), ((V)(0.8)), GR_5200, Call(PL_5043, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("shine", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
Call(on_5222, V.Undef, DR_5242, Arr(Call(box_5035, V.Undef, x_5240, ((V)(7D)), ((V)(((Dp_5206 / 2D) + 1.15))), ((V)(32D)), ((V)(3D)), ((V)(0.6)), GL_5201, Call(PL_5043, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_5035, V.Undef, x_5240, ((V)(38D)), ((V)(((Dp_5206 / 2D) + 1.15))), ((V)(32D)), ((V)(3D)), ((V)(0.6)), GL_5201, Call(PL_5043, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_5035, V.Undef, ((V)((ToNum(x_5240) - 14.5))), ((V)(10D)), ((V)(((Dp_5206 / 2D) + 1.15))), ((V)(3D)), ((V)(28D)), ((V)(0.6)), GL_5201, Call(PL_5043, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_5035, V.Undef, Add(x_5240, ((V)(14.5))), ((V)(10D)), ((V)(((Dp_5206 / 2D) + 1.15))), ((V)(3D)), ((V)(28D)), ((V)(0.6)), GL_5201, Call(PL_5043, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_5035, V.Undef, x_5240, ((V)(10D)), ((V)(((Dp_5206 / 2D) + 0.95))), ((V)(26D)), ((V)(28D)), ((V)(0.1)), Call(shade_10, V.Undef, GR_5200, ((V)(0.9))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(box_5035, V.Undef, Add(x_5240, ((V)((LtN(x_5240, 0D) ? 11D : (-11D))))), ((V)(30D)), ((V)(((Dp_5206 / 2D) + 1.75))), ((V)(1D)), ((V)(6D)), ((V)(0.8)), BR2_5202, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0.3))).Put("shine", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
Invoke(Arr(((V)(8D)), ((V)(19.6)), ((V)(31.2))), "forEach", Fn((V _arrowThis5251, int _argc5243, V y_5249, V j_5250, V _a5247, V _a5248, V[] _rest5244) => {
return Invoke(Arr(((V)((-8.4))), ((V)(8.4))), "forEach", Fn((V _arrowThis5259, int _argc5252, V x_5258, V _a5255, V _a5256, V _a5257, V[] _rest5253) => {
V DW_5260 = default;
DW_5260 = GetIdx(Call(on_5222, V.Undef, LC_5224, Arr(Call(box_5035, V.Undef, x_5258, y_5249, ((V)(((Dp_5206 / 2D) + 0.45))), ((V)(16D)), ((V)(10.6)), ((V)(0.8)), GR_5200, Call(PL_5043, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("shine", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
Call(on_5222, V.Undef, DW_5260, Arr(Call(box_5035, V.Undef, x_5258, Add(y_5249, ((V)(6.4))), ((V)(((Dp_5206 / 2D) + 0.95))), ((V)(6D)), ((V)(2.6)), ((V)(0.2)), BR2_5202, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0.2))).Put("shine", ((V)(1D))).V)), Call(box_5035, V.Undef, x_5258, Add(y_5249, ((V)(6.8))), ((V)(((Dp_5206 / 2D) + 1.2))), ((V)(4.6)), ((V)(1.8)), ((V)(0.05)), ((V)("#f6efdc")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(slabX_5039, V.Undef, x_5258, Add(y_5249, ((V)(2.6))), ((V)(((Dp_5206 / 2D) + 1.4))), ((V)(6D)), ((V)(1.4)), ((V)(1D)), BR2_5202, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("shine", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
}, 2, "", true));
CT_5225 = Call(box_5035, V.Undef, ((V)(0D)), ((V)(43D)), ((V)(0D)), ((V)((W_5205 + 4D))), ((V)(3D)), ((V)((Dp_5206 + 2D))), MB_5204, NewObj(3).Put("r", ((V)(0.8))).Put("mat", ((V)("cer"))).Put("shine", ((V)(1D))).V);
Invoke(o_5221, "push", CT_5225);
vein_5226 = Arr();
Invoke(Arr(Arr(((V)((-40D))), ((V)(3D)), ((V)(0.5)), ((V)(22D))), Arr(((V)((-6D))), ((V)((-8D))), ((V)((-0.3))), ((V)(30D))), Arr(((V)(20D)), ((V)(8D)), ((V)(0.7)), ((V)(18D))), Arr(((V)(36D)), ((V)((-4D))), ((V)((-0.6))), ((V)(20D)))), "forEach", Fn((V _arrowThis5276, int _argc5261, V _a5263, V _a5264, V _a5265, V _a5266, V[] _rest5262) => {
V x_5269 = default;
V z_5271 = default;
V yaw_5273 = default;
V L_5275 = default;
{ V _t5267 = ListOf(_a5263);
{ V _t5268 = GetIdx(_t5267, 0D);
x_5269 = _t5268; }
{ V _t5270 = GetIdx(_t5267, 1D);
z_5271 = _t5270; }
{ V _t5272 = GetIdx(_t5267, 2D);
yaw_5273 = _t5272; }
{ V _t5274 = GetIdx(_t5267, 3D);
L_5275 = _t5274; }
}
return Invoke(vein_5226, "push", Call(box_5035, V.Undef, x_5269, ((V)(46.02)), z_5271, L_5275, ((V)(0.04)), ((V)(0.35)), ((V)("#b8b0a4")), NewObj(3).Put("r", ((V)(0D))).Put("yaw", yaw_5273).Put("noOut", ((V)(1D))).V), Call(box_5035, V.Undef, Add(x_5269, ((V)(4D))), ((V)(46.03)), Add(z_5271, ((V)(1.2))), ((V)((ToNum(L_5275) * 0.5))), ((V)(0.04)), ((V)(0.2)), ((V)("#c8a868")), NewObj(3).Put("r", ((V)(0D))).Put("yaw", Add(yaw_5273, ((V)(0.3)))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
Call(on_5222, V.Undef, CT_5225, Invoke(vein_5226, "concat", Arr(Call(slabX_5039, V.Undef, ((V)(0D)), ((V)(44.2)), ((V)(((Dp_5206 / 2D) + 1.05))), ((V)((W_5205 + 2D))), ((V)(0.2)), ((V)(0.05)), ((V)("#c8c2b8")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V))));
Invoke(o_5221, "push", Call(box_5035, V.Undef, ((V)(0D)), ((V)(Y1_5210)), ((V)(ZU_5209)), ((V)(WU_5207)), ((V)(2D)), ((V)(DU_5208)), GR_5200, Call(PL_5043, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis5284, int _argc5277, V sg_5283, V _a5280, V _a5281, V _a5282, V[] _rest5278) => {
return Invoke(o_5221, "push", Call(box_5035, V.Undef, ((V)((ToNum(sg_5283) * ((WU_5207 / 2D) - 2D)))), ((V)((Y1_5210 + 2D))), ((V)(ZU_5209)), ((V)(4D)), ((V)(HU_5211)), ((V)(DU_5208)), GR_5200, Call(PL_5043, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
BS_5227 = Call(slab_5038, V.Undef, ((V)(0D)), ((V)((Y1_5210 + 2D))), ((V)(((ZU_5209 - (DU_5208 / 2D)) + 1D))), ((V)((WU_5207 - 8D))), ((V)(HU_5211)), ((V)(2D)), ((V)("#24382e")), Call(PL_5043, V.Undef, NewObj(1).Put("r", ((V)(0D))).V));
Invoke(o_5221, "push", BS_5227);
Call(on_5222, V.Undef, BS_5227, Arr(Call(slabX_5039, V.Undef, ((V)(0D)), ((V)((Y1_5210 + 9D))), ((V)(((ZU_5209 - (DU_5208 / 2D)) + 2.05))), ((V)((WU_5207 - 10D))), ((V)(0.5)), ((V)(0.1)), BR2_5202, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
TB_5228 = Call(box_5035, V.Undef, ((V)(0D)), ((V)(((Y1_5210 + 2D) + HU_5211))), ((V)(ZU_5209)), ((V)(WU_5207)), ((V)(4D)), ((V)(DU_5208)), GR_5200, Call(PL_5043, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V));
Invoke(o_5221, "push", TB_5228);
Invoke(o_5221, "push", Call(box_5035, V.Undef, ((V)(0D)), ((V)(((Y1_5210 + 6D) + HU_5211))), ((V)((ZU_5209 + 0.8))), ((V)((WU_5207 + 6D))), ((V)(2.6)), ((V)((DU_5208 + 3.6))), GR_5200, Call(PL_5043, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V)), Call(box_5035, V.Undef, ((V)(0D)), ((V)(((Y1_5210 + 8.6) + HU_5211))), ((V)((ZU_5209 + 1.2))), ((V)((WU_5207 + 10D))), ((V)(3D)), ((V)((DU_5208 + 6D))), GL_5201, Call(PL_5043, V.Undef, NewObj(2).Put("r", ((V)(0.8))).Put("shine", ((V)(1D))).V)));
Call(on_5222, V.Undef, TB_5228, Arr(Call(slabX_5039, V.Undef, ((V)(0D)), ((V)(((Y1_5210 + 5.4) + HU_5211))), ((V)(((ZU_5209 + (DU_5208 / 2D)) + 0.05))), ((V)(WU_5207)), ((V)(0.5)), ((V)(0.1)), BR2_5202, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
SB_5229 = Invoke(SH_5213, "map", Fn((V _arrowThis5292, int _argc5285, V y_5291, V _a5288, V _a5289, V _a5290, V[] _rest5286) => {
V Q_5293 = default;
Q_5293 = Call(box_5035, V.Undef, ((V)(0D)), y_5291, ((V)((ZU_5209 + 1D))), ((V)((WU_5207 - 8D))), ((V)(2.2)), ((V)((DU_5208 - 2D))), WAL_5203, Call(W__5041, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V));
Invoke(o_5221, "push", Q_5293);
Call(on_5222, V.Undef, Q_5293, Arr(Call(slabX_5039, V.Undef, ((V)(0D)), ((V)((ToNum(y_5291) - 0.05))), ((V)(((ZU_5209 + (DU_5208 / 2D)) - 2.6))), ((V)((WU_5207 - 10D))), ((V)(0.3)), ((V)(0.8)), ((V)("#fff1c4")), Call(em_5044, V.Undef, NewObj(1).Put("r", ((V)(0D))).V)), Call(slabX_5039, V.Undef, ((V)(0D)), Add(y_5291, ((V)(0.4))), ((V)(((ZU_5209 + (DU_5208 / 2D)) + 0.05))), ((V)((WU_5207 - 8D))), ((V)(1.4)), ((V)(0.1)), BR2_5202, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return Q_5293;
return default;
}, 1, "", true));
BOT_5230 = Invoke(o_5221, "find", Fn((V _arrowThis5301, int _argc5294, V q_5300, V _a5297, V _a5298, V _a5299, V[] _rest5295) => {
return (((SEq(Get(q_5300, "col"), GR_5200) && (System.Math.Abs((ToNum(GetIdx(GetIdx(Get(q_5300, "pts"), 0D), 1D)) - Y1_5210)) < 0.01)) ? V.True : V.False) is var _t5310 && !Truthy(_t5310) ? _t5310 : Invoke(Get(q_5300, "pts"), "some", Fn((V _arrowThis5309, int _argc5302, V p_5308, V _a5305, V _a5306, V _a5307, V[] _rest5303) => {
return ((System.Math.Abs((ToNum(GetIdx(p_5308, 1D)) - (Y1_5210 + 2D))) < 0.01) ? V.True : V.False);
}, 1, "", true)));
}, 1, "", true));
can_5231 = Fn((V _arrowThis5324, int _argc5311, V par_5317, V x_5318, V y_5319, V z_5320, V[] _rest5312) => {
V G_5325 = default;
V r_5321 = default;
V h_5322 = default;
V fill_5323 = default;
r_5321 = (_argc5311 > 4 ? _rest5312[0] : V.Undef);
h_5322 = (_argc5311 > 5 ? _rest5312[1] : V.Undef);
fill_5323 = (_argc5311 > 6 ? _rest5312[2] : V.Undef);
G_5325 = Call(cyl_5036, V.Undef, x_5318, y_5319, z_5320, r_5321, h_5322, fill_5323, NewObj(3).Put("n", ((V)(16D))).Put("mat", ((V)("cer"))).Put("shine", ((V)(1D))).V);
Call(on_5222, V.Undef, par_5317, Arr(G_5325));
Call(on_5222, V.Undef, G_5325, Arr(Call(cyl_5036, V.Undef, x_5318, Add(y_5319, h_5322), z_5320, ((V)((ToNum(r_5321) * 1.04))), ((V)(1.4)), WAL_5203, Call(W__5041, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(ball_5037, V.Undef, x_5318, Add(Add(y_5319, h_5322), ((V)(1.4))), z_5320, ((V)(0.7)), BR2_5202, Call(M__5042, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).V)), Call(box_5035, V.Undef, x_5318, Add(y_5319, ((V)((ToNum(h_5322) * 0.42)))), Add(Add(z_5320, r_5321), ((V)(0.05))), ((V)((ToNum(r_5321) * 1.1))), ((V)((ToNum(h_5322) * 0.28))), ((V)(0.05)), ((V)("#f6efdc")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
return default;
}, 7, "", true);
Invoke(Arr(Arr(((V)((-38D))), ((V)("#f2d48a")), ((V)(11D))), Arr(((V)((-29D))), ((V)("#f6f2e6")), ((V)(9D))), Arr(((V)((-20.4))), ((V)("#8a4a2a")), ((V)(10D))), Arr(((V)((-12D))), ((V)("#e0c890")), ((V)(8.6))), Arr(((V)(12D)), ((V)("#f2d48a")), ((V)(9.6))), Arr(((V)(20.4)), ((V)("#c86a3a")), ((V)(8D))), Arr(((V)(29D)), ((V)("#6a8a3a")), ((V)(10.4))), Arr(((V)(38D)), ((V)("#e8d8b0")), ((V)(9D)))), "forEach", Fn((V _arrowThis5340, int _argc5326, V _a5328, V i_5332, V _a5330, V _a5331, V[] _rest5327) => {
V x_5335 = default;
V col_5337 = default;
V h_5339 = default;
{ V _t5333 = ListOf(_a5328);
{ V _t5334 = GetIdx(_t5333, 0D);
x_5335 = _t5334; }
{ V _t5336 = GetIdx(_t5333, 1D);
col_5337 = _t5336; }
{ V _t5338 = GetIdx(_t5333, 2D);
h_5339 = _t5338; }
}
return Call(can_5231, V.Undef, GetIdx(SB_5229, 0D), x_5335, Add(GetIdx(SH_5213, 0D), ((V)(2.2))), ((V)(((ZU_5209 - 2D) + ((ToNum(i_5332) % 2D) * 3D)))), ((V)(3.2)), h_5339, col_5337);
}, 2, "", true));
Invoke(Arr(Arr(((V)((-30D))), ((V)("#c87a4a")), ((V)(6.4)), ((V)(9D))), Arr(((V)((-14D))), ((V)("#b86a3a")), ((V)(5D)), ((V)(7D))), Arr(((V)(30D)), ((V)("#c87a4a")), ((V)(5.6)), ((V)(8D)))), "forEach", Fn((V _arrowThis5356, int _argc5341, V _a5343, V _a5344, V _a5345, V _a5346, V[] _rest5342) => {
V P_5357 = default;
V x_5349 = default;
V col_5351 = default;
V r_5353 = default;
V h_5355 = default;
{ V _t5347 = ListOf(_a5343);
{ V _t5348 = GetIdx(_t5347, 0D);
x_5349 = _t5348; }
{ V _t5350 = GetIdx(_t5347, 1D);
col_5351 = _t5350; }
{ V _t5352 = GetIdx(_t5347, 2D);
r_5353 = _t5352; }
{ V _t5354 = GetIdx(_t5347, 3D);
h_5355 = _t5354; }
}
P_5357 = Call(cyl_5036, V.Undef, x_5349, Add(GetIdx(SH_5213, 1D), ((V)(2.2))), ((V)(ZU_5209)), r_5353, h_5355, col_5351, Call(M__5042, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("shine", ((V)(1D))).V));
Call(on_5222, V.Undef, GetIdx(SB_5229, 1D), Arr(P_5357));
Call(on_5222, V.Undef, P_5357, Arr(Call(cyl_5036, V.Undef, x_5349, ((V)((ToNum(Add(Add(GetIdx(SH_5213, 1D), ((V)(2.2))), h_5355)) - 0.8))), ((V)(ZU_5209)), Add(r_5353, ((V)(0.3))), ((V)(0.8)), ((V)("#e8a070")), Call(M__5042, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(rod_5045, V.Undef, Arr(((V)(((ToNum(x_5349) - ToNum(r_5353)) - 2.6))), ((V)((ToNum(Add(Add(GetIdx(SH_5213, 1D), ((V)(2.2))), h_5355)) - 2D))), ((V)(ZU_5209))), Arr(((V)((ToNum(x_5349) - ToNum(r_5353)))), ((V)((ToNum(Add(Add(GetIdx(SH_5213, 1D), ((V)(2.2))), h_5355)) - 2D))), ((V)(ZU_5209))), ((V)(0.5)), ((V)("#3a3a3a")), Call(M__5042, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(rod_5045, V.Undef, Arr(Add(x_5349, r_5353), ((V)((ToNum(Add(Add(GetIdx(SH_5213, 1D), ((V)(2.2))), h_5355)) - 2D))), ((V)(ZU_5209))), Arr(Add(Add(x_5349, r_5353), ((V)(2.6))), ((V)((ToNum(Add(Add(GetIdx(SH_5213, 1D), ((V)(2.2))), h_5355)) - 2D))), ((V)(ZU_5209))), ((V)(0.5)), ((V)("#3a3a3a")), Call(M__5042, V.Undef, NewObj(1).Put("n", ((V)(6D))).V))));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)(0D)), ((V)("#7a2a2a")), ((V)(13D))), Arr(((V)(2.6)), ((V)("#2f4a6a")), ((V)(12D))), Arr(((V)(5D)), ((V)("#e8dcc0")), ((V)(13.4))), Arr(((V)(7.4)), ((V)("#3a5a3a")), ((V)(11.6))), Arr(((V)(9.8)), ((V)("#c89a3a")), ((V)(12.6)))), "forEach", Fn((V _arrowThis5371, int _argc5358, V _a5360, V _a5361, V _a5362, V _a5363, V[] _rest5359) => {
V B_5372 = default;
V dx_5366 = default;
V col_5368 = default;
V h_5370 = default;
{ V _t5364 = ListOf(_a5360);
{ V _t5365 = GetIdx(_t5364, 0D);
dx_5366 = _t5365; }
{ V _t5367 = GetIdx(_t5364, 1D);
col_5368 = _t5367; }
{ V _t5369 = GetIdx(_t5364, 2D);
h_5370 = _t5369; }
}
B_5372 = Call(box_5035, V.Undef, Add(((V)(4D)), dx_5366), Add(GetIdx(SH_5213, 1D), ((V)(2.2))), ((V)((ZU_5209 - 2D))), ((V)(2.2)), h_5370, ((V)(9D)), col_5368, Call(PL_5043, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V));
Call(on_5222, V.Undef, GetIdx(SB_5229, 1D), Arr(B_5372));
Call(on_5222, V.Undef, B_5372, Arr(Call(box_5035, V.Undef, Add(((V)(4D)), dx_5366), Add(Add(GetIdx(SH_5213, 1D), ((V)(2.2))), ((V)((ToNum(h_5370) * 0.7)))), ((V)((ZU_5209 + 2.55))), ((V)(1.4)), ((V)(1D)), ((V)(0.05)), ((V)("#e8c870")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
yb_5232 = (Y1_5210 + 2D);
Invoke(Arr(Arr(((V)((-36D))), ((V)("#3a5a2a")), ((V)(16D))), Arr(((V)((-31D))), ((V)("#4a2a3a")), ((V)(15D))), Arr(((V)((-26D))), ((V)("#3a5a2a")), ((V)(16.4)))), "forEach", Fn((V _arrowThis5386, int _argc5373, V _a5375, V _a5376, V _a5377, V _a5378, V[] _rest5374) => {
V B_5387 = default;
V x_5381 = default;
V col_5383 = default;
V h_5385 = default;
{ V _t5379 = ListOf(_a5375);
{ V _t5380 = GetIdx(_t5379, 0D);
x_5381 = _t5380; }
{ V _t5382 = GetIdx(_t5379, 1D);
col_5383 = _t5382; }
{ V _t5384 = GetIdx(_t5379, 2D);
h_5385 = _t5384; }
}
B_5387 = Call(cyl_5036, V.Undef, x_5381, ((V)(yb_5232)), ((V)((ZU_5209 - 1D))), ((V)(2D)), ((V)((ToNum(h_5385) * 0.65))), col_5383, NewObj(3).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(h_5385) * 0.65))), ((V)(0D)), ((V)(1D))))).V);
Call(on_5222, V.Undef, BOT_5230, Arr(B_5387));
Call(on_5222, V.Undef, B_5387, Arr(Call(cyl_5036, V.Undef, x_5381, ((V)((yb_5232 + (ToNum(h_5385) * 0.65)))), ((V)((ZU_5209 - 1D))), ((V)(2D)), ((V)((ToNum(h_5385) * 0.35))), col_5383, NewObj(3).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(h_5385) * 0.12))), ((V)(0D)), ((V)(0.45))), Arr(((V)((ToNum(h_5385) * 0.35))), ((V)(0D)), ((V)(0.4))))).V), Call(box_5035, V.Undef, x_5381, ((V)((yb_5232 + (ToNum(h_5385) * 0.3)))), ((V)((ZU_5209 + 1.05))), ((V)(2.6)), ((V)(3.6)), ((V)(0.05)), ((V)("#f2e8d0")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
return default;
}, 1, "", true));
Call(on_5222, V.Undef, BOT_5230, Arr(Call(cyl_5036, V.Undef, ((V)(30D)), ((V)(yb_5232)), ((V)((ZU_5209 - 1D))), ((V)(6D)), ((V)(11D)), ((V)("#e8e0cc")), NewObj(4).Put("n", ((V)(18D))).Put("mat", ((V)("cer"))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(3D)), ((V)(0D)), ((V)(1D))), Arr(((V)(9D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(11D)), ((V)(0D)), ((V)(0.7))))).V)));
{
V L_5388 = default;
L_5388 = GetIdx(o_5221, (ToNum(Get(o_5221, "length")) - 1D));
Call(on_5222, V.Undef, L_5388, Arr(Call(cyl_5036, V.Undef, ((V)(30D)), ((V)((yb_5232 + 11D))), ((V)((ZU_5209 - 1D))), ((V)(4.4)), ((V)(1.2)), WAL_5203, Call(W__5041, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(box_5035, V.Undef, ((V)(30D)), ((V)((yb_5232 + 5D))), ((V)((ZU_5209 + 5.05))), ((V)(6D)), ((V)(2.6)), ((V)(0.05)), ((V)("#2f4a3c")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
}
RL_5233 = Call(rod_5045, V.Undef, Arr(((V)((-44D))), ((V)(60D)), ((V)(((ZU_5209 - (DU_5208 / 2D)) + 3.6)))), Arr(((V)(44D)), ((V)(60D)), ((V)(((ZU_5209 - (DU_5208 / 2D)) + 3.6)))), ((V)(0.6)), BR2_5202, Call(M__5042, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V));
Call(on_5222, V.Undef, BS_5227, Arr(RL_5233));
Call(on_5222, V.Undef, BS_5227, Invoke(Arr(((V)((-40D))), ((V)(40D))), "map", Fn((V _arrowThis5396, int _argc5389, V x_5395, V _a5392, V _a5393, V _a5394, V[] _rest5390) => {
return Call(rod_5045, V.Undef, Arr(x_5395, ((V)(60D)), ((V)(((ZU_5209 - (DU_5208 / 2D)) + 2D)))), Arr(x_5395, ((V)(60D)), ((V)(((ZU_5209 - (DU_5208 / 2D)) + 3.6)))), ((V)(0.5)), BR2_5202, Call(M__5042, V.Undef, NewObj(1).Put("n", ((V)(6D))).V));
}, 1, "", true)));
Invoke(Arr(((V)((-18D))), ((V)((-12D))), ((V)((-6D)))), "forEach", Fn((V _arrowThis5405, int _argc5397, V x_5403, V i_5404, V _a5401, V _a5402, V[] _rest5398) => {
return Call(on_5222, V.Undef, RL_5233, Arr(Call(rod_5045, V.Undef, Arr(x_5403, ((V)(59.4)), ((V)(((ZU_5209 - (DU_5208 / 2D)) + 3.6)))), Arr(x_5403, Add(((V)(49D)), i_5404), ((V)(((ZU_5209 - (DU_5208 / 2D)) + 3.6)))), ((V)(0.4)), ((V)("#c87a4a")), Call(M__5042, V.Undef, NewObj(2).Put("n", ((V)(6D))).Put("shine", ((V)(1D))).V)), Call(ball_5037, V.Undef, x_5403, Add(((V)(47.6)), i_5404), ((V)(((ZU_5209 - (DU_5208 / 2D)) + 3.6))), ((V)(1.6)), ((V)("#c87a4a")), Call(M__5042, V.Undef, NewObj(4).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).Put("sy", ((V)(0.6))).V))));
}, 2, "", true));
return o_5221;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis5413, int _argc5406, V c_5412, V _a5409, V _a5410, V _a5411, V[] _rest5407) => {
V f_5414 = default;
JsStrBuf g_5415 = null;
if (LtN(Call(face_5049, V.Undef, c_5412, ((V)(0D)), ((V)(1D))), 0.1)) {
return NewObj(0).V;
}
f_5414 = Add(Call(carousel_5054, V.Undef, c_5412, ((V)((-28D))), ((V)(46D)), ((V)(8D)), ((V)(30D)), ((V)(0D)), Arr(((V)("#c84a2a")), ((V)("#e8a030")), ((V)("#6a8a3a")), ((V)("#8a4a2a")), ((V)("#d8c070")), ((V)("#a83a2a")), ((V)("#4a6a2a")), ((V)("#e8c890")))), Call(carousel_5054, V.Undef, c_5412, ((V)(28D)), ((V)(46D)), ((V)(8D)), ((V)(36D)), ((V)(1.3)), Arr(((V)("#e8a030")), ((V)("#8a4a2a")), ((V)("#c84a2a")), ((V)("#4a6a2a")), ((V)("#d8c070")), ((V)("#6a3a2a")))));
g_5415 = new JsStrBuf("");
Invoke(Arr(((V)((-24D))), ((V)(0D)), ((V)(24D))), "forEach", Fn((V _arrowThis5424, int _argc5416, V x_5422, V i_5423, V _a5420, V _a5421, V[] _rest5417) => {
return ((V)(g_5415.S("<path d=\"").V(Call(qd_5050, V.Undef, c_5412, Arr(Arr(((V)((ToNum(x_5422) - 12D))), ((V)((ToNum(GetIdx(SH_5213, 0D)) - 0.2))), ((V)((ZU_5209 + 6D)))), Arr(Add(x_5422, ((V)(12D))), ((V)((ToNum(GetIdx(SH_5213, 0D)) - 0.2))), ((V)((ZU_5209 + 6D)))), Arr(Add(x_5422, ((V)(18D))), ((V)((ToNum(GetIdx(SH_5213, 0D)) - 12D))), ((V)(ZF_5212))), Arr(((V)((ToNum(x_5422) - 18D))), ((V)((ToNum(GetIdx(SH_5213, 0D)) - 12D))), ((V)(ZF_5212)))))).S("\" fill=\"url(#k74L)\" opacity=\"0.2\">").V(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.14;0.26;0.14")), ((V)(9D)), Call(n4_17, V.Undef, ((V)(((-ToNum(i_5423)) * 2D)))), Call(SPL_15, V.Undef, ((V)(2D))))).S("</path>").Str));
}, 2, "", true));
return NewObj(2).Put("defs", ((V)(JsStrBuf.Begin().V(DEF74_5055).S("<linearGradient id=\"k74L\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff2c8\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#fff2c8\" stop-opacity=\"0\"/></linearGradient>").End()))).Put("front", ((V)(JsStrBuf.Begin().S(g_5415.Str).V(f_5414).End()))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_70, "patis27", Fn((V _arrowThis5432, int _argc5425, V S_5431, V _a5428, V _a5429, V _a5430, V[] _rest5426) => {
V CR_5433 = default;
V BR2_5434 = default;
V BZ_5435 = default;
V PK_5436 = default;
double W_5437 = 0;
double Dp_5438 = 0;
double YB_5439 = 0;
double SW_5440 = 0;
double HS_5441 = 0;
double HC_5442 = 0;
double ZS_5443 = 0;
double ZC_5444 = 0;
double XS_5445 = 0;
V VO_5446 = default;
V SO_5447 = default;
V sx_5448 = default;
V sOp_5449 = default;
CR_5433 = ((V)("#f4ead9"));
BR2_5434 = ((V)("#c99a3e"));
BZ_5435 = ((V)("#4e3a22"));
PK_5436 = ((V)("#f4b6c4"));
W_5437 = 104D;
Dp_5438 = 42D;
YB_5439 = 6D;
SW_5440 = 26D;
HS_5441 = 104D;
HC_5442 = 120D;
ZS_5443 = (Dp_5438 / 2D);
ZC_5444 = ((Dp_5438 / 2D) + 1.5);
XS_5445 = ((W_5437 / 2D) - (SW_5440 / 2D));
VO_5446 = NewObj(5).Put("x0", ((V)((-20D)))).Put("x1", ((V)(20D))).Put("y0", ((V)((YB_5439 + 28D)))).Put("yA", ((V)((YB_5439 + 84D)))).Put("r", ((V)(20D))).V;
SO_5447 = NewObj(3).Put("y0", ((V)((YB_5439 + 40D)))).Put("y1", ((V)(((YB_5439 + HS_5441) - 7D)))).Put("i", ((V)(3.2))).V;
sx_5448 = Fn((V _arrowThis5457, int _argc5450, V sg_5456, V _a5453, V _a5454, V _a5455, V[] _rest5451) => {
return ((V)((ToNum(sg_5456) * XS_5445)));
}, 1, "", true);
sOp_5449 = Fn((V _arrowThis5465, int _argc5458, V sg_5464, V _a5461, V _a5462, V _a5463, V[] _rest5459) => {
return Arr(Add(((V)((ToNum(Call(sx_5448, V.Undef, sg_5464)) - (SW_5440 / 2D)))), Get(SO_5447, "i")), ((V)((ToNum(Add(Call(sx_5448, V.Undef, sg_5464), ((V)((SW_5440 / 2D))))) - ToNum(Get(SO_5447, "i"))))));
}, 1, "", true);
return NewObj(4).Put("w", ((V)(108D))).Put("d", ((V)(46D))).Put("build", Fn((V _arrowThis5472, int _argc5466, V _a5468, V _a5469, V _a5470, V _a5471, V[] _rest5467) => {
V o_5473 = default;
V on_5474 = default;
V PLN_5475 = default;
V C_5476 = default;
V SU_5477 = default;
V CAP_5478 = default;
o_5473 = Arr();
on_5474 = Call(glue_5047, V.Undef, o_5473);
PLN_5475 = Call(box_5035, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((W_5437 - 2D))), ((V)(YB_5439)), ((V)((Dp_5438 - 2D))), BZ_5435, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V));
Invoke(o_5473, "push", PLN_5475);
Call(on_5474, V.Undef, PLN_5475, Arr(Call(slabX_5039, V.Undef, ((V)(0D)), ((V)(0.6)), ((V)(((Dp_5438 / 2D) - 0.95))), ((V)((W_5437 - 4D))), ((V)(0.5)), ((V)(0.1)), ((V)("#ffe2a0")), Call(em_5044, V.Undef, NewObj(1).Put("r", ((V)(0D))).V)), Call(slabX_5039, V.Undef, ((V)(0D)), ((V)((YB_5439 - 0.8))), ((V)(((Dp_5438 / 2D) - 0.95))), ((V)((W_5437 - 4D))), ((V)(0.4)), ((V)(0.1)), ((V)("#f2d58a")), Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
C_5476 = Call(box_5035, V.Undef, ((V)(0D)), ((V)(YB_5439)), ((V)(0D)), ((V)(52D)), ((V)(HC_5442)), ((V)((Dp_5438 + 3D))), CR_5433, Call(PL_5043, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V));
Invoke(o_5473, "push", C_5476);
SU_5477 = Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis5486, int _argc5479, V sg_5485, V _a5482, V _a5483, V _a5484, V[] _rest5480) => {
V B_5487 = default;
B_5487 = Call(box_5035, V.Undef, Call(sx_5448, V.Undef, sg_5485), ((V)(YB_5439)), ((V)(0D)), ((V)(SW_5440)), ((V)(HS_5441)), ((V)(Dp_5438)), CR_5433, Call(PL_5043, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V));
Invoke(o_5473, "push", B_5487);
return B_5487;
return default;
}, 1, "", true));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis5495, int _argc5488, V sg_5494, V _a5491, V _a5492, V _a5493, V[] _rest5489) => {
double x_5496 = 0;
x_5496 = (ToNum(sg_5494) * 39.5);
Invoke(o_5473, "push", Call(box_5035, V.Undef, ((V)(x_5496)), ((V)((YB_5439 + HS_5441))), ((V)(0.5)), ((V)(27D)), ((V)(3D)), ((V)((Dp_5438 + 1D))), CR_5433, Call(PL_5043, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(box_5035, V.Undef, ((V)(x_5496)), ((V)(((YB_5439 + HS_5441) + 3D))), ((V)(0.5)), ((V)(27D)), ((V)(1.6)), ((V)((Dp_5438 + 2D))), BR2_5434, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("shine", ((V)(1D))).V)), Call(box_5035, V.Undef, ((V)(x_5496)), ((V)(((YB_5439 + HS_5441) + 4.6))), ((V)(0.5)), ((V)(27D)), ((V)(2.2)), ((V)((Dp_5438 + 3D))), CR_5433, Call(PL_5043, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V)));
return default;
}, 1, "", true));
Invoke(o_5473, "push", Call(box_5035, V.Undef, ((V)(0D)), ((V)((YB_5439 + HC_5442))), ((V)(0D)), ((V)(56D)), ((V)(3D)), ((V)((Dp_5438 + 5D))), CR_5433, Call(PL_5043, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(box_5035, V.Undef, ((V)(0D)), ((V)(((YB_5439 + HC_5442) + 3D))), ((V)(0D)), ((V)(58D)), ((V)(1.8)), ((V)((Dp_5438 + 6D))), BR2_5434, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("shine", ((V)(1D))).V)));
CAP_5478 = Call(box_5035, V.Undef, ((V)(0D)), ((V)(((YB_5439 + HC_5442) + 4.8))), ((V)(0D)), ((V)(60D)), ((V)(2.6)), ((V)((Dp_5438 + 7D))), CR_5433, Call(PL_5043, V.Undef, NewObj(2).Put("r", ((V)(0.8))).Put("shine", ((V)(1D))).V));
Invoke(o_5473, "push", CAP_5478);
Call(on_5474, V.Undef, CAP_5478, Arr(Call(cyl_5036, V.Undef, ((V)(0D)), ((V)(((YB_5439 + HC_5442) + 7.4))), ((V)(0D)), ((V)(3.2)), ((V)(1.2)), BR2_5434, Call(M__5042, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("shine", ((V)(1D))).V)), Call(ball_5037, V.Undef, ((V)(0D)), ((V)(((YB_5439 + HC_5442) + 10.4))), ((V)(0D)), ((V)(2.4)), BR2_5434, Call(M__5042, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(12D))).Put("shine", ((V)(1D))).V)), Call(ball_5037, V.Undef, ((V)(0D)), ((V)(((YB_5439 + HC_5442) + 13.4))), ((V)(0D)), ((V)(1.1)), ((V)("#d8283a")), Call(M__5042, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V))));
Call(on_5474, V.Undef, C_5476, Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis5504, int _argc5497, V sg_5503, V _a5500, V _a5501, V _a5502, V[] _rest5498) => {
return Call(box_5035, V.Undef, ((V)((ToNum(sg_5503) * 24.4))), ((V)((YB_5439 + 2D))), ((V)((ZC_5444 + 0.4))), ((V)(1.6)), ((V)((HC_5442 - 4D))), ((V)(0.8)), BR2_5434, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0.2))).Put("shine", ((V)(1D))).V));
}, 1, "", true)), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis5512, int _argc5505, V sg_5511, V _a5508, V _a5509, V _a5510, V[] _rest5506) => {
double x_5513 = 0;
V DW_5514 = default;
x_5513 = (ToNum(sg_5511) * 11.6);
DW_5514 = GetIdx(Call(on_5474, V.Undef, C_5476, Arr(Call(box_5035, V.Undef, ((V)(x_5513)), ((V)((YB_5439 + 4D))), ((V)((ZC_5444 + 0.45))), ((V)(21D)), ((V)(19D)), ((V)(0.9)), CR_5433, Call(PL_5043, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("shine", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
Call(on_5474, V.Undef, DW_5514, Arr(Call(box_5035, V.Undef, ((V)(x_5513)), ((V)((YB_5439 + 16.4))), ((V)((ZC_5444 + 1.05))), ((V)(8D)), ((V)(2.8)), ((V)(0.3)), BR2_5434, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0.2))).Put("shine", ((V)(1D))).V)), Call(box_5035, V.Undef, ((V)(x_5513)), ((V)((YB_5439 + 16.75))), ((V)((ZC_5444 + 1.25))), ((V)(6.6)), ((V)(2.1)), ((V)(0.05)), ((V)("#fff6ea")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(slabX_5039, V.Undef, ((V)(x_5513)), ((V)((YB_5439 + 8.6))), ((V)((ZC_5444 + 1.6))), ((V)(7.4)), ((V)(1.5)), ((V)(1.1)), BR2_5434, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("shine", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
Invoke(SU_5477, "forEach", Fn((V _arrowThis5523, int _argc5515, V B_5521, V j_5522, V _a5519, V _a5520, V[] _rest5516) => {
double sg_5524 = 0;
V x_5525 = default;
V x0_5526 = default;
V x1_5527 = default;
V y0_5528 = default;
V y1_5529 = default;
double z_5530 = 0;
double b_5531 = 0;
sg_5524 = (Truthy(j_5522) ? 1D : (-1D));
x_5525 = Call(sx_5448, V.Undef, ((V)(sg_5524)));
{ V _t5532 = Call(sOp_5449, V.Undef, ((V)(sg_5524)));
{ V _t5533 = ListOf(_t5532);
{ V _t5534 = GetIdx(_t5533, 0D);
x0_5526 = _t5534; }
{ V _t5535 = GetIdx(_t5533, 1D);
x1_5527 = _t5535; }
} }
y0_5528 = Get(SO_5447, "y0");
y1_5529 = Get(SO_5447, "y1");
z_5530 = (ZS_5443 + 0.05);
b_5531 = 0.8;
Call(on_5474, V.Undef, B_5521, Arr(Call(slabX_5039, V.Undef, x_5525, y1_5529, ((V)(z_5530)), ((V)(((ToNum(x1_5527) - ToNum(x0_5526)) + (2D * b_5531)))), ((V)(b_5531)), ((V)(0.3)), BR2_5434, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("shine", ((V)(1D))).V)), Call(slabX_5039, V.Undef, x_5525, ((V)((ToNum(y0_5528) - b_5531))), ((V)(z_5530)), ((V)(((ToNum(x1_5527) - ToNum(x0_5526)) + (2D * b_5531)))), ((V)(b_5531)), ((V)(0.3)), BR2_5434, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("shine", ((V)(1D))).V)), Call(box_5035, V.Undef, ((V)((ToNum(x0_5526) - (b_5531 / 2D)))), y0_5528, ((V)((z_5530 + 0.15))), ((V)(b_5531)), ((V)((ToNum(y1_5529) - ToNum(y0_5528)))), ((V)(0.3)), BR2_5434, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("shine", ((V)(1D))).V)), Call(box_5035, V.Undef, Add(x1_5527, ((V)((b_5531 / 2D)))), y0_5528, ((V)((z_5530 + 0.15))), ((V)(b_5531)), ((V)((ToNum(y1_5529) - ToNum(y0_5528)))), ((V)(0.3)), BR2_5434, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("shine", ((V)(1D))).V)), Call(ball_5037, V.Undef, ((sg_5524 < 0D) ? Add(x1_5527, ((V)(1.7))) : ((V)((ToNum(x0_5526) - 1.7)))), ((V)((ToNum(Add(y0_5528, y1_5529)) / 2D))), ((V)((ZS_5443 + 0.8))), ((V)(0.85)), BR2_5434, Call(M__5042, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
Invoke(Arr(((V)((YB_5439 + 3D))), ((V)((YB_5439 + 14.6))), ((V)((YB_5439 + 26.2)))), "forEach", Fn((V _arrowThis5543, int _argc5536, V y_5542, V _a5539, V _a5540, V _a5541, V[] _rest5537) => {
V DW_5544 = default;
DW_5544 = GetIdx(Call(on_5474, V.Undef, B_5521, Arr(Call(box_5035, V.Undef, x_5525, y_5542, ((V)((ZS_5443 + 0.45))), ((V)(21D)), ((V)(10.6)), ((V)(0.9)), CR_5433, Call(PL_5043, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("shine", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 0D);
Call(on_5474, V.Undef, DW_5544, Arr(Call(box_5035, V.Undef, x_5525, Add(y_5542, ((V)(6.6))), ((V)((ZS_5443 + 1.05))), ((V)(8D)), ((V)(2.6)), ((V)(0.3)), BR2_5434, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0.2))).Put("shine", ((V)(1D))).V)), Call(box_5035, V.Undef, x_5525, Add(y_5542, ((V)(6.9))), ((V)((ZS_5443 + 1.25))), ((V)(6.6)), ((V)(2D)), ((V)(0.05)), ((V)("#fff6ea")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(slabX_5039, V.Undef, x_5525, Add(y_5542, ((V)(2.4))), ((V)((ZS_5443 + 1.6))), ((V)(6.6)), ((V)(1.4)), ((V)(1.1)), BR2_5434, Call(M__5042, V.Undef, NewObj(2).Put("r", ((V)(0.5))).Put("shine", ((V)(1D))).V))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))));
return default;
}, 1, "", true));
return default;
}, 2, "", true));
return o_5473;
return default;
}, 0, "build", true)).Put("fx", Fn((V _arrowThis5552, int _argc5545, V c_5551, V _a5548, V _a5549, V _a5550, V[] _rest5546) => {
V f0_5553 = default;
V id_5554 = default;
V k_5555 = default;
V vy_5556 = default;
double hv_5557 = 0;
double eyS_5558 = 0;
V R_5559 = default;
JsStrBuf defs_5560 = null;
V P2_5561 = default;
V poly_5562 = default;
V RG_5563 = default;
V CY_5564 = default;
V el_5565 = default;
V el2_5566 = default;
V rc_5567 = default;
V shd_5568 = default;
V tw_5569 = default;
V walls_5570 = default;
V FR_5571 = default;
V WR_5572 = default;
V SPR_5573 = default;
V cup_5574 = default;
V MC_5575 = default;
V mac_5576 = default;
V CK_5577 = default;
V cake_5578 = default;
V GB_5579 = default;
V MS_5580 = default;
V jar_5581 = default;
V stand_5582 = default;
JsStrBuf @out_5583 = null;
V txt_5584 = default;
f0_5553 = Call(face_5049, V.Undef, c_5551, ((V)(0D)), ((V)(1D)));
if (LtN(f0_5553, 0.12)) {
return NewObj(0).V;
}
id_5554 = ((V)(JsStrBuf.Begin().S("k94").N(Round((ToNum(Invoke(G("Math"), "random")) * 1000000D))).End()));
k_5555 = Get(c_5551, "k");
vy_5556 = Call(vY_5052, V.Undef, c_5551);
hv_5557 = Hypot(ToNum(GetIdx(vy_5556, 0D)), ToNum(GetIdx(vy_5556, 1D)));
eyS_5558 = System.Math.Abs((ToNum(GetIdx(Call(FP_5051, V.Undef, c_5551, Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), 1D)) - ToNum(GetIdx(Call(FP_5051, V.Undef, c_5551, Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))), 1D))));
R_5559 = Call(rng_13, V.Undef, ((V)("patis27")));
defs_5560 = new JsStrBuf(JsStrBuf.Begin().V(DEF74_5055).S("<linearGradient id=\"").V(id_5554).S("y\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.4\"/><stop offset=\"0.35\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.7\" stop-color=\"#000000\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#3a1a10\" stop-opacity=\"0.3\"/></linearGradient>").S("<radialGradient id=\"").V(id_5554).S("r\" cx=\"35%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.55\"/><stop offset=\"0.45\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#3a1a10\" stop-opacity=\"0.3\"/></radialGradient>").S("<linearGradient id=\"").V(id_5554).S("w\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fbe4e6\"/><stop offset=\"1\" stop-color=\"#f0c0ca\"/></linearGradient>").S("<radialGradient id=\"").V(id_5554).S("g\" cx=\"50%\" cy=\"10%\" r=\"85%\"><stop offset=\"0\" stop-color=\"#fff6dc\" stop-opacity=\"0.8\"/><stop offset=\"1\" stop-color=\"#ffd8c8\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"").V(id_5554).S("a\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.28\"/><stop offset=\"1\" stop-color=\"#5a2030\" stop-opacity=\"0.2\"/></linearGradient>").S("<filter id=\"").V(id_5554).S("f\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"0.9\"/></filter>").End());
P2_5561 = Fn((V _arrowThis5592, int _argc5585, V P_5591, V _a5588, V _a5589, V _a5590, V[] _rest5586) => {
V q_5593 = default;
q_5593 = Call(FP_5051, V.Undef, c_5551, P_5591);
return ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, GetIdx(q_5593, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(q_5593, 1D))).End()));
return default;
}, 1, "", true);
poly_5562 = Fn((V _arrowThis5601, int _argc5594, V Ps_5600, V _a5597, V _a5598, V _a5599, V[] _rest5595) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Ps_5600, "map", P2_5561), "join", ((V)("L")))).S("Z").End()));
}, 1, "", true);
RG_5563 = ((V)(JsStrBuf.Begin().S("url(#").V(id_5554).S("r)").End()));
CY_5564 = ((V)(JsStrBuf.Begin().S("url(#").V(id_5554).S("y)").End()));
el_5565 = Fn((V _arrowThis5614, int _argc5602, V cx_5608, V cy_5609, V rx_5610, V ry_5611, V[] _rest5603) => {
V fill_5612 = default;
V ex_5613 = default;
fill_5612 = (_argc5602 > 4 ? _rest5603[0] : V.Undef);
ex_5613 = (_argc5602 > 5 ? _rest5603[1] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_16, V.Undef, cx_5608)).S("\" cy=\"").V(Call(f1_16, V.Undef, cy_5609)).S("\" rx=\"").V(Call(f1_16, V.Undef, rx_5610)).S("\" ry=\"").V(Call(f1_16, V.Undef, ry_5611)).S("\" fill=\"").V(fill_5612).S("\"").V((ex_5613 is var _t5615 && Truthy(_t5615) ? _t5615 : ((V)("")))).S("/>").End()));
}, 6, "", true);
el2_5566 = Fn((V _arrowThis5627, int _argc5616, V cx_5622, V cy_5623, V rx_5624, V ry_5625, V[] _rest5617) => {
V fill_5626 = default;
fill_5626 = (_argc5616 > 4 ? _rest5617[0] : V.Undef);
return Add(Call(el_5565, V.Undef, cx_5622, cy_5623, rx_5624, ry_5625, fill_5626), Call(el_5565, V.Undef, cx_5622, cy_5623, rx_5624, ry_5625, RG_5563));
}, 5, "", true);
rc_5567 = Fn((V _arrowThis5641, int _argc5628, V x_5634, V y_5635, V w_5636, V h_5637, V[] _rest5629) => {
V rr_5638 = default;
V fill_5639 = default;
V ex_5640 = default;
rr_5638 = (_argc5628 > 4 ? _rest5629[0] : V.Undef);
fill_5639 = (_argc5628 > 5 ? _rest5629[1] : V.Undef);
ex_5640 = (_argc5628 > 6 ? _rest5629[2] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_16, V.Undef, x_5634)).S("\" y=\"").V(Call(f1_16, V.Undef, y_5635)).S("\" width=\"").V(Call(f1_16, V.Undef, w_5636)).S("\" height=\"").V(Call(f1_16, V.Undef, h_5637)).S("\" rx=\"").V(Call(f1_16, V.Undef, rr_5638)).S("\" fill=\"").V(fill_5639).S("\"").V((ex_5640 is var _t5642 && Truthy(_t5642) ? _t5642 : ((V)("")))).S("/>").End()));
}, 7, "", true);
shd_5568 = Fn((V _arrowThis5650, int _argc5643, V r_5649, V _a5646, V _a5647, V _a5648, V[] _rest5644) => {
return Call(el_5565, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((ToNum(r_5649) * ToNum(k_5555)))), ((V)((ToNum(r_5649) * eyS_5558))), ((V)("#5a2a1a")), ((V)(" opacity=\"0.18\"")));
}, 1, "", true);
tw_5569 = Fn((V _arrowThis5661, int _argc5651, V q_5657, V sz_5658, V dur_5659, V beg_5660, V[] _rest5652) => {
double z_5662 = 0;
double h_5663 = 0;
z_5662 = (ToNum(sz_5658) * ToNum(k_5555));
h_5663 = (z_5662 * 0.25);
return ((V)(JsStrBuf.Begin().S("<path transform=\"translate(").V(Call(f1_16, V.Undef, GetIdx(q_5657, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(q_5657, 1D))).S(")\" d=\"M0 ").V(Call(f1_16, V.Undef, ((V)((-z_5662))))).S("L").V(Call(f1_16, V.Undef, ((V)(h_5663)))).S(" ").V(Call(f1_16, V.Undef, ((V)((-h_5663))))).S("L").V(Call(f1_16, V.Undef, ((V)(z_5662)))).S(" 0L").V(Call(f1_16, V.Undef, ((V)(h_5663)))).S(" ").V(Call(f1_16, V.Undef, ((V)(h_5663)))).S("L0 ").V(Call(f1_16, V.Undef, ((V)(z_5662)))).S("L").V(Call(f1_16, V.Undef, ((V)((-h_5663))))).S(" ").V(Call(f1_16, V.Undef, ((V)(h_5663)))).S("L").V(Call(f1_16, V.Undef, ((V)((-z_5662))))).S(" 0L").V(Call(f1_16, V.Undef, ((V)((-h_5663))))).S(" ").V(Call(f1_16, V.Undef, ((V)((-h_5663))))).S("Z\" fill=\"#ffffff\" opacity=\"0\">").V(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0;0.95;0")), dur_5659, Call(n4_17, V.Undef, beg_5660), Call(SPL_15, V.Undef, ((V)(2D))))).S("</path>").End()));
return default;
}, 4, "", true);
walls_5570 = Fn((V _arrowThis5677, int _argc5664, V x0_5670, V x1_5671, V y0_5672, V y1_5673, V[] _rest5665) => {
JsStrBuf w_5678 = null;
V za_5674 = default;
V zb2_5675 = default;
V col_5676 = default;
za_5674 = (_argc5664 > 4 ? _rest5665[0] : V.Undef);
zb2_5675 = (_argc5664 > 5 ? _rest5665[1] : V.Undef);
col_5676 = (_argc5664 > 6 ? _rest5665[2] : V.Undef);
w_5678 = new JsStrBuf("");
if (GtN(Call(face_5049, V.Undef, c_5551, ((V)(1D)), ((V)(0D))), 0D)) {
w_5678.S("<path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(x0_5670, y1_5673, za_5674), Arr(x0_5670, y1_5673, zb2_5675), Arr(x0_5670, y0_5672, zb2_5675), Arr(x0_5670, y0_5672, za_5674)))).S("\" fill=\"").V(Call(shade_10, V.Undef, col_5676, ((V)(0.8)))).S("\"/>");
}
if (GtN(Call(face_5049, V.Undef, c_5551, ((V)((-1D))), ((V)(0D))), 0D)) {
w_5678.S("<path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(x1_5671, y1_5673, za_5674), Arr(x1_5671, y1_5673, zb2_5675), Arr(x1_5671, y0_5672, zb2_5675), Arr(x1_5671, y0_5672, za_5674)))).S("\" fill=\"").V(Call(shade_10, V.Undef, col_5676, ((V)(0.92)))).S("\"/>");
}
return ((V)(JsStrBuf.Begin().S(w_5678.Str).S("<path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(x0_5670, y0_5672, za_5674), Arr(x1_5671, y0_5672, za_5674), Arr(x1_5671, y0_5672, zb2_5675), Arr(x0_5670, y0_5672, zb2_5675)))).S("\" fill=\"").V(Call(shade_10, V.Undef, col_5676, ((V)(1.04)))).S("\"/>").End()));
return default;
}, 7, "", true);
FR_5571 = Arr(((V)("#f8bccb")), ((V)("#c4ead6")), ((V)("#dccaf2")), ((V)("#fff2d4")), ((V)("#9a5e3e")), ((V)("#ffd2ac")));
WR_5572 = Arr(((V)("#f08aa0")), ((V)("#7cc8a8")), ((V)("#b49ae0")), ((V)("#e8c070")));
SPR_5573 = Arr(((V)("#f04a5a")), ((V)("#4ab0f0")), ((V)("#f6c040")), ((V)("#7cd07a")), ((V)("#ffffff")));
cup_5574 = Fn((V _arrowThis5686, int _argc5679, V i_5685, V _a5682, V _a5683, V _a5684, V[] _rest5680) => {
double h_5687 = 0;
double b_5688 = 0;
double t_5689 = 0;
V w_5690 = default;
V f_5691 = default;
V wp_5692 = default;
JsStrBuf s_5693 = null;
h_5687 = (3.4 * hv_5557);
b_5688 = (1.9 * ToNum(k_5555));
t_5689 = (2.5 * ToNum(k_5555));
w_5690 = GetIdx(WR_5572, (ToNum(i_5685) % 4D));
f_5691 = GetIdx(FR_5571, (ToNum(i_5685) % 6D));
wp_5692 = ((V)(JsStrBuf.Begin().S("M").V(Call(f1_16, V.Undef, ((V)((-b_5688))))).S(" 0L").V(Call(f1_16, V.Undef, ((V)((-t_5689))))).S(" ").V(Call(f1_16, V.Undef, ((V)((-h_5687))))).S("H").V(Call(f1_16, V.Undef, ((V)(t_5689)))).S("L").V(Call(f1_16, V.Undef, ((V)(b_5688)))).S(" 0Z").End()));
s_5693 = new JsStrBuf(JsStrBuf.Begin().V(Call(shd_5568, V.Undef, ((V)(2.4)))).S("<path d=\"").V(wp_5692).S("\" fill=\"").V(w_5690).S("\"/>").V(Invoke(Invoke(Arr(((V)((-0.6))), ((V)((-0.2))), ((V)(0.2)), ((V)(0.6))), "map", Fn((V _arrowThis5701, int _argc5694, V u_5700, V _a5697, V _a5698, V _a5699, V[] _rest5695) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)((ToNum(u_5700) * b_5688))))).S(" 0L").V(Call(f1_16, V.Undef, ((V)((ToNum(u_5700) * t_5689))))).S(" ").V(Call(f1_16, V.Undef, ((V)((-h_5687))))).S("\" stroke=\"").V(Call(shade_10, V.Undef, w_5690, ((V)(0.78)))).S("\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.22 * ToNum(k_5555)))))).S("\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"").V(wp_5692).S("\" fill=\"").V(CY_5564).S("\"/>").End());
s_5693.V(Add(Add(Call(el2_5566, V.Undef, ((V)(0D)), ((V)(((-h_5687) - (0.8 * hv_5557)))), ((V)((2.9 * ToNum(k_5555)))), ((V)((1.3 * hv_5557))), f_5691), Call(el2_5566, V.Undef, ((V)(0D)), ((V)(((-h_5687) - (2.1 * hv_5557)))), ((V)((2.2 * ToNum(k_5555)))), ((V)((1.15 * hv_5557))), f_5691)), Call(el2_5566, V.Undef, ((V)(0D)), ((V)(((-h_5687) - (3.2 * hv_5557)))), ((V)((1.35 * ToNum(k_5555)))), ((V)((0.95 * hv_5557))), f_5691)));
if (((ToNum(i_5685) % 2D) == 0D)) {
s_5693.S("<path d=\"M0 ").V(Call(f1_16, V.Undef, ((V)(((-h_5687) - (4.6 * hv_5557)))))).S("q").V(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(k_5555)))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((-1D) * hv_5557))))).S(" ").V(Call(f1_16, V.Undef, ((V)((1.1 * ToNum(k_5555)))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((-1.4) * hv_5557))))).S("\" stroke=\"#5a7a2a\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.22 * ToNum(k_5555)))))).S("\" fill=\"none\"/>").V(Call(el2_5566, V.Undef, ((V)(0D)), ((V)(((-h_5687) - (4.3 * hv_5557)))), ((V)((0.95 * ToNum(k_5555)))), ((V)((0.95 * ToNum(k_5555)))), ((V)("#d8283a"))));
} else {
s_5693.V(Invoke(Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis5709, int _argc5702, V j_5708, V _a5705, V _a5706, V _a5707, V[] _rest5703) => {
V a_5710 = default;
double r2_5711 = 0;
double x_5712 = 0;
double y_5713 = 0;
a_5710 = Add(((V)((ToNum(j_5708) * 1.05))), i_5685);
r2_5711 = (0.9 + ((ToNum(j_5708) % 3D) * 0.5));
x_5712 = ((FdLibm.Cos(ToNum(a_5710)) * r2_5711) * ToNum(k_5555));
y_5713 = ((-h_5687) - ((1.3 + ((ToNum(j_5708) % 3D) * 0.9)) * hv_5557));
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_16, V.Undef, ((V)((x_5712 - (0.3 * ToNum(k_5555))))))).S("\" y=\"").V(Call(f1_16, V.Undef, ((V)(y_5713)))).S("\" width=\"").V(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(k_5555)))))).S("\" height=\"").V(Call(f1_16, V.Undef, ((V)((0.22 * ToNum(k_5555)))))).S("\" fill=\"").V(GetIdx(SPR_5573, (ToNum(j_5708) % 5D))).S("\" transform=\"rotate(").N(((ToNum(j_5708) * 47D) % 180D)).S(" ").V(Call(f1_16, V.Undef, ((V)(x_5712)))).S(" ").V(Call(f1_16, V.Undef, ((V)(y_5713)))).S(")\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)(""))));
}
return ((V)(s_5693.Str));
return default;
}, 1, "", true);
MC_5575 = Arr(((V)("#f8bccb")), ((V)("#c4ead6")), ((V)("#dccaf2")), ((V)("#fff0a8")), ((V)("#ffc8a0")), ((V)("#b4dcf4")), ((V)("#c89a70")));
mac_5576 = Fn((V _arrowThis5721, int _argc5714, V i_5720, V _a5717, V _a5718, V _a5719, V[] _rest5715) => {
double rx_5722 = 0;
double sh_5723 = 0;
double fl_5724 = 0;
double st_5725 = 0;
V s_5726 = default;
double top_5727 = 0;
rx_5722 = (2.3 * ToNum(k_5555));
sh_5723 = (1.05 * hv_5557);
fl_5724 = (0.5 * hv_5557);
st_5725 = (((2D * sh_5723) + fl_5724) + (0.2 * hv_5557));
s_5726 = Call(shd_5568, V.Undef, ((V)(2.4)));
top_5727 = 0D;
{
double j_5728 = 0;
j_5728 = 0D;
while (true) {
if (!((j_5728 < 3D))) break;
V col_5730 = default;
double yb_5731 = 0;
V d2_5732 = default;
V da_5733 = default;
col_5730 = GetIdx(MC_5575, (ToNum(Add(i_5720, ((V)((j_5728 * 3D))))) % ToNum(Get(MC_5575, "length"))));
yb_5731 = ((-j_5728) * st_5725);
d2_5732 = Call(shade_10, V.Undef, col_5730, ((V)(0.82)));
da_5733 = ((V)(JsStrBuf.Begin().S(" stroke=\"").V(d2_5732).S("\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_5555)))))).S("\" stroke-dasharray=\"").V(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_5555)))))).S(" ").V(Call(f1_16, V.Undef, ((V)((0.25 * ToNum(k_5555)))))).S("\" fill=\"none\"/>").End()));
s_5726 = ((V)(JsStrBuf.Begin().V(s_5726).V(Add(Add(Add(Add(Call(rc_5567, V.Undef, ((V)((-rx_5722))), ((V)((yb_5731 - sh_5723))), ((V)((2D * rx_5722))), ((V)(sh_5723)), ((V)((sh_5723 / 2D))), col_5730), Call(rc_5567, V.Undef, ((V)((-rx_5722))), ((V)((yb_5731 - sh_5723))), ((V)((2D * rx_5722))), ((V)(sh_5723)), ((V)((sh_5723 / 2D))), CY_5564)), Call(rc_5567, V.Undef, ((V)(((-rx_5722) * 0.92))), ((V)(((yb_5731 - sh_5723) - fl_5724))), ((V)((rx_5722 * 1.84))), ((V)(fl_5724)), ((V)((fl_5724 / 2D))), ((V)("#fff8ee")))), Call(rc_5567, V.Undef, ((V)((-rx_5722))), ((V)(((yb_5731 - (2D * sh_5723)) - fl_5724))), ((V)((2D * rx_5722))), ((V)(sh_5723)), ((V)((sh_5723 / 2D))), col_5730)), Call(rc_5567, V.Undef, ((V)((-rx_5722))), ((V)(((yb_5731 - (2D * sh_5723)) - fl_5724))), ((V)((2D * rx_5722))), ((V)(sh_5723)), ((V)((sh_5723 / 2D))), CY_5564))).S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)(((-rx_5722) * 0.85))))).S(" ").V(Call(f1_16, V.Undef, ((V)((yb_5731 - (sh_5723 * 1.02)))))).S("H").V(Call(f1_16, V.Undef, ((V)((rx_5722 * 0.85))))).S("\"").V(da_5733).S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)(((-rx_5722) * 0.85))))).S(" ").V(Call(f1_16, V.Undef, ((V)((((yb_5731 - sh_5723) - fl_5724) + (0.1 * hv_5557)))))).S("H").V(Call(f1_16, V.Undef, ((V)((rx_5722 * 0.85))))).S("\"").V(da_5733).End()));
top_5727 = ((yb_5731 - (2D * sh_5723)) - fl_5724);
j_5728++;
}
}
return Add(s_5726, Call(el_5565, V.Undef, ((V)(((-0.4) * ToNum(k_5555)))), ((V)((top_5727 + (sh_5723 * 0.3)))), ((V)((rx_5722 * 0.6))), ((V)((sh_5723 * 0.2))), ((V)("#ffffff")), ((V)(" opacity=\"0.55\""))));
return default;
}, 1, "", true);
CK_5577 = Arr(Arr(((V)("#fff2f6")), ((V)("#f4a0b4"))), Arr(((V)("#fff6dc")), ((V)("#9a5e3e"))), Arr(((V)("#ecf8f0")), ((V)("#8ad0b0"))), Arr(((V)("#f6eeff")), ((V)("#c0a8e8"))), Arr(((V)("#fff2e2")), ((V)("#f2a868"))));
cake_5578 = Fn((V _arrowThis5742, int _argc5734, V i_5740, V sc_5741, V _a5738, V _a5739, V[] _rest5735) => {
V ic_5743 = default;
V sp_5744 = default;
double rx_5745 = 0;
double ry_5746 = 0;
double h_5747 = 0;
double d_5748 = 0;
V arc_5749 = default;
JsStrBuf s_5750 = null;
double by_5751 = 0;
double bw_5752 = 0;
double bh_5753 = 0;
V bp_5754 = default;
{ V _t5755 = GetIdx(CK_5577, (ToNum(i_5740) % 5D));
{ V _t5756 = ListOf(_t5755);
{ V _t5757 = GetIdx(_t5756, 0D);
ic_5743 = _t5757; }
{ V _t5758 = GetIdx(_t5756, 1D);
sp_5744 = _t5758; }
} }
rx_5745 = ((2.5 * ToNum(k_5555)) * ToNum(sc_5741));
ry_5746 = ((2.5 * eyS_5558) * ToNum(sc_5741));
h_5747 = ((3.2 * hv_5557) * ToNum(sc_5741));
d_5748 = ((1.1 * hv_5557) * ToNum(sc_5741));
arc_5749 = Fn((V _arrowThis5766, int _argc5759, V y_5765, V _a5762, V _a5763, V _a5764, V[] _rest5760) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_16, V.Undef, ((V)((-rx_5745))))).S(" ").V(Call(f1_16, V.Undef, y_5765)).S("A").V(Call(f1_16, V.Undef, ((V)(rx_5745)))).S(" ").V(Call(f1_16, V.Undef, ((V)(ry_5746)))).S(" 0 0 0 ").V(Call(f1_16, V.Undef, ((V)(rx_5745)))).S(" ").V(Call(f1_16, V.Undef, y_5765)).End()));
}, 1, "", true);
s_5750 = new JsStrBuf(JsStrBuf.Begin().V(Add(Add(Call(shd_5568, V.Undef, ((V)((2.8 * ToNum(sc_5741))))), Call(el_5565, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(rx_5745)), ((V)(ry_5746)), sp_5744)), Call(rc_5567, V.Undef, ((V)((-rx_5745))), ((V)((-h_5747))), ((V)((2D * rx_5745))), ((V)(h_5747)), ((V)(0D)), sp_5744))).S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)((-rx_5745))))).S(" ").V(Call(f1_16, V.Undef, ((V)((-h_5747))))).S("V0A").V(Call(f1_16, V.Undef, ((V)(rx_5745)))).S(" ").V(Call(f1_16, V.Undef, ((V)(ry_5746)))).S(" 0 0 0 ").V(Call(f1_16, V.Undef, ((V)(rx_5745)))).S(" 0V").V(Call(f1_16, V.Undef, ((V)((-h_5747))))).S("Z\" fill=\"").V(CY_5564).S("\"/>").S("<path d=\"").V(Call(arc_5749, V.Undef, ((V)(((-h_5747) * 0.45))))).S("\" stroke=\"").V(ic_5743).S("\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)(((0.45 * hv_5557) * ToNum(sc_5741)))))).S("\" fill=\"none\"/>").V(Call(el_5565, V.Undef, ((V)(0D)), ((V)((-h_5747))), ((V)(rx_5745)), ((V)(ry_5746)), ic_5743)).S("<path d=\"").V(Call(arc_5749, V.Undef, ((V)((-h_5747))))).S("\" stroke=\"").V(ic_5743).S("\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((d_5748 * 0.7))))).S("\" fill=\"none\"/>").End());
{
double j_5767 = 0;
j_5767 = 0D;
while (true) {
if (!((j_5767 < 5D))) break;
double t_5769 = 0;
t_5769 = (PI_11 * (0.1 + (0.2 * j_5767)));
s_5750.V(Call(el_5565, V.Undef, ((V)(((-rx_5745) * FdLibm.Cos(t_5769)))), ((V)((((-h_5747) + (ry_5746 * FdLibm.Sin(t_5769))) + (d_5748 * (0.35 + (0.35 * (j_5767 % 2D))))))), ((V)(((0.42 * ToNum(k_5555)) * ToNum(sc_5741)))), ((V)((d_5748 * 0.55))), ic_5743));
j_5767++;
}
}
s_5750.V(Call(el_5565, V.Undef, ((V)(0D)), ((V)((-h_5747))), ((V)(rx_5745)), ((V)(ry_5746)), RG_5563));
by_5751 = ((-h_5747) - ((0.1 * hv_5557) * ToNum(sc_5741)));
bw_5752 = ((1.2 * ToNum(k_5555)) * ToNum(sc_5741));
bh_5753 = ((2.2 * hv_5557) * ToNum(sc_5741));
bp_5754 = ((V)(JsStrBuf.Begin().S("M0 ").V(Call(f1_16, V.Undef, ((V)(by_5751)))).S("C").V(Call(f1_16, V.Undef, ((V)(((-bw_5752) * 1.3))))).S(" ").V(Call(f1_16, V.Undef, ((V)((by_5751 - (bh_5753 * 0.15)))))).S(" ").V(Call(f1_16, V.Undef, ((V)((-bw_5752))))).S(" ").V(Call(f1_16, V.Undef, ((V)((by_5751 - bh_5753))))).S(" 0 ").V(Call(f1_16, V.Undef, ((V)((by_5751 - bh_5753))))).S("C").V(Call(f1_16, V.Undef, ((V)(bw_5752)))).S(" ").V(Call(f1_16, V.Undef, ((V)((by_5751 - bh_5753))))).S(" ").V(Call(f1_16, V.Undef, ((V)((bw_5752 * 1.3))))).S(" ").V(Call(f1_16, V.Undef, ((V)((by_5751 - (bh_5753 * 0.15)))))).S(" 0 ").V(Call(f1_16, V.Undef, ((V)(by_5751)))).S("Z").End()));
s_5750.S("<path d=\"").V(bp_5754).S("\" fill=\"#e0303e\"/><path d=\"").V(bp_5754).S("\" fill=\"").V(RG_5563).S("\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis5777, int _argc5770, V j_5776, V _a5773, V _a5774, V _a5775, V[] _rest5771) => {
return Call(el_5565, V.Undef, ((V)(((((ToNum(j_5776) % 2D) - 0.5) * bw_5752) * 0.8))), ((V)((by_5751 - (bh_5753 * (0.3 + (ToNum(j_5776) * 0.15)))))), ((V)(((0.12 * ToNum(k_5555)) * ToNum(sc_5741)))), ((V)(((0.16 * ToNum(k_5555)) * ToNum(sc_5741)))), ((V)("#fff0a0")));
}, 1, "", true)), "join", ((V)("")))).V(Call(el_5565, V.Undef, ((V)(((-0.4) * bw_5752))), ((V)((by_5751 - (bh_5753 * 1.02)))), ((V)((bw_5752 * 0.55))), ((V)(((0.3 * ToNum(k_5555)) * ToNum(sc_5741)))), ((V)("#5aa040")))).V(Call(el_5565, V.Undef, ((V)((0.4 * bw_5752))), ((V)((by_5751 - (bh_5753 * 1.02)))), ((V)((bw_5752 * 0.55))), ((V)(((0.3 * ToNum(k_5555)) * ToNum(sc_5741)))), ((V)("#4a9038"))));
return ((V)(s_5750.Str));
return default;
}, 2, "", true);
GB_5579 = Arr(((V)("#f04a5a")), ((V)("#f6c040")), ((V)("#4ab0f0")), ((V)("#7cd07a")), ((V)("#f08ad0")), ((V)("#ffffff")), ((V)("#ff9a4a")));
MS_5580 = Arr(((V)("#fff6f8")), ((V)("#f8d0dc")), ((V)("#d8f0e4")), ((V)("#fff0c8")));
jar_5581 = Fn((V _arrowThis5785, int _argc5778, V kind_5784, V _a5781, V _a5782, V _a5783, V[] _rest5779) => {
double rx_5786 = 0;
double h_5787 = 0;
double ery_5788 = 0;
double lvl_5789 = 0;
V lol_5790 = default;
V s_5791 = default;
JsStrBuf cn_5792 = null;
rx_5786 = (3.3 * ToNum(k_5555));
h_5787 = (9D * hv_5557);
ery_5788 = (3.3 * eyS_5558);
lvl_5789 = (h_5787 * 0.78);
lol_5790 = (SEqS(kind_5784, "lolly") ? V.True : V.False);
s_5791 = Add(Call(shd_5568, V.Undef, ((V)(3.4))), Call(rc_5567, V.Undef, ((V)((-rx_5786))), ((V)((-h_5787))), ((V)((2D * rx_5786))), ((V)(h_5787)), ((V)((0.9 * ToNum(k_5555)))), ((V)("#e8f4f2")), ((V)(" opacity=\"0.45\""))));
cn_5792 = new JsStrBuf("");
if (SEqS(kind_5784, "gum")) {
{
double r_5793 = 0;
r_5793 = 0D;
while (true) {
if (!((r_5793 < 5D))) break;
{
double q_5795 = 0;
q_5795 = (-2D);
while (true) {
if (!((q_5795 <= 2D))) break;
double x_5797 = 0;
x_5797 = ((((q_5795 + ((r_5793 % 2D) * 0.5)) - 0.25) * 1.25) * ToNum(k_5555));
if ((System.Math.Abs(x_5797) > (rx_5786 - (0.7 * ToNum(k_5555))))) {
goto _cont5796;
}
cn_5792.V(Call(el2_5566, V.Undef, ((V)(x_5797)), ((V)(((-(0.8 + (r_5793 * 1.35))) * hv_5557))), ((V)((0.68 * ToNum(k_5555)))), ((V)((0.68 * ToNum(k_5555)))), GetIdx(GB_5579, ((((r_5793 * 3D) + q_5795) + 7D) % 7D))));
_cont5796: ;
q_5795++;
}
}
r_5793++;
}
}
}
if (SEqS(kind_5784, "bean")) {
V B_5798 = default;
B_5798 = Invoke(Call(rep_18, V.Undef, ((V)(22D)), Fn((V _arrowThis5814, int _argc5808, V _a5810, V _a5811, V _a5812, V _a5813, V[] _rest5809) => {
return Arr(((V)((((ToNum(Call(R_5559, V.Undef)) - 0.5) * 2D) * (rx_5786 - (0.8 * ToNum(k_5555)))))), ((V)(((-(0.6 + (ToNum(Call(R_5559, V.Undef)) * ((lvl_5789 / hv_5557) - 1.2)))) * hv_5557))), ((V)((ToNum(Call(R_5559, V.Undef)) * 180D))), GetIdx(GB_5579, ((double)(ToInt32((ToNum(Call(R_5559, V.Undef)) * 7D)) | ToInt32(0D)))));
}, 0, "", true)), "sort", Fn((V _arrowThis5807, int _argc5799, V p_5805, V q_5806, V _a5803, V _a5804, V[] _rest5800) => {
return ((V)((ToNum(GetIdx(q_5806, 1D)) - ToNum(GetIdx(p_5805, 1D)))));
}, 2, "", true));
cn_5792.V(Invoke(Invoke(B_5798, "map", Fn((V _arrowThis5830, int _argc5815, V _a5817, V _a5818, V _a5819, V _a5820, V[] _rest5816) => {
V x_5823 = default;
V y_5825 = default;
V a_5827 = default;
V col_5829 = default;
{ V _t5821 = ListOf(_a5817);
{ V _t5822 = GetIdx(_t5821, 0D);
x_5823 = _t5822; }
{ V _t5824 = GetIdx(_t5821, 1D);
y_5825 = _t5824; }
{ V _t5826 = GetIdx(_t5821, 2D);
a_5827 = _t5826; }
{ V _t5828 = GetIdx(_t5821, 3D);
col_5829 = _t5828; }
}
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(f1_16, V.Undef, x_5823)).S(" ").V(Call(f1_16, V.Undef, y_5825)).S(") rotate(").V(Call(f1_16, V.Undef, a_5827)).S(")\">").V(Call(el_5565, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((0.78 * ToNum(k_5555)))), ((V)((0.46 * ToNum(k_5555)))), col_5829)).V(Call(el_5565, V.Undef, ((V)(((-0.2) * ToNum(k_5555)))), ((V)(((-0.15) * ToNum(k_5555)))), ((V)((0.35 * ToNum(k_5555)))), ((V)((0.12 * ToNum(k_5555)))), ((V)("#ffffff")), ((V)(" opacity=\"0.6\"")))).S("</g>").End()));
}, 1, "", true)), "join", ((V)(""))));
}
if (SEqS(kind_5784, "mint")) {
{
double r_5831 = 0;
r_5831 = 0D;
while (true) {
if (!((r_5831 < 4D))) break;
{
double q_5833 = 0;
q_5833 = (-1D);
while (true) {
if (!((q_5833 <= 1D))) break;
double x_5835 = 0;
double y_5836 = 0;
x_5835 = ((((q_5833 + ((r_5831 % 2D) * 0.4)) - 0.2) * 1.9) * ToNum(k_5555));
y_5836 = ((-(1D + (r_5831 * 1.65))) * hv_5557);
cn_5792.V(Call(el_5565, V.Undef, ((V)(x_5835)), ((V)(y_5836)), ((V)((0.9 * ToNum(k_5555)))), ((V)((0.9 * ToNum(k_5555)))), ((V)("#ffffff")))).S("<circle cx=\"").V(Call(f1_16, V.Undef, ((V)(x_5835)))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)(y_5836)))).S("\" r=\"").V(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(k_5555)))))).S("\" fill=\"none\" stroke=\"#e83a4a\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(k_5555)))))).S("\" stroke-dasharray=\"").V(Call(f1_16, V.Undef, ((V)((0.52 * ToNum(k_5555)))))).S(" ").V(Call(f1_16, V.Undef, ((V)((0.52 * ToNum(k_5555)))))).S("\"/>").V(Call(el_5565, V.Undef, ((V)(x_5835)), ((V)(y_5836)), ((V)((0.9 * ToNum(k_5555)))), ((V)((0.9 * ToNum(k_5555)))), RG_5563));
q_5833++;
}
}
r_5831++;
}
}
}
if (SEqS(kind_5784, "cookie")) {
{
double j_5837 = 0;
j_5837 = 0D;
while (true) {
if (!((j_5837 < 6D))) break;
double y_5839 = 0;
y_5839 = ((-(0.7 + (j_5837 * 1.05))) * hv_5557);
cn_5792.V(Add(Add(Call(el_5565, V.Undef, ((V)(0D)), ((V)(y_5839)), ((V)((2.7 * ToNum(k_5555)))), ((V)(Max((0.3 * ToNum(k_5555)), (2.7 * eyS_5558)))), ((V)("#b87a3e"))), Call(el_5565, V.Undef, ((V)(0D)), ((V)((y_5839 - (0.3 * hv_5557)))), ((V)((2.6 * ToNum(k_5555)))), ((V)(Max((0.28 * ToNum(k_5555)), (2.6 * eyS_5558)))), ((V)("#dca868")))), Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis5847, int _argc5840, V q_5846, V _a5843, V _a5844, V _a5845, V[] _rest5841) => {
return Call(el_5565, V.Undef, ((V)((((ToNum(q_5846) - 1D) * 1.1) * ToNum(k_5555)))), ((V)(((y_5839 - (0.3 * hv_5557)) + ((((ToNum(q_5846) % 2D) - 0.5) * 0.4) * eyS_5558)))), ((V)((0.28 * ToNum(k_5555)))), ((V)((0.2 * ToNum(k_5555)))), ((V)("#4a2a18")));
}, 1, "", true)), "join", ((V)("")))));
j_5837++;
}
}
}
if (SEqS(kind_5784, "marsh")) {
{
double r_5848 = 0;
r_5848 = 0D;
while (true) {
if (!((r_5848 < 4D))) break;
{
double q_5850 = 0;
q_5850 = (-1D);
while (true) {
if (!((q_5850 <= 1D))) break;
double x_5852 = 0;
double y_5853 = 0;
x_5852 = ((((q_5850 + ((r_5848 % 2D) * 0.3)) - 0.15) * 1.85) * ToNum(k_5555));
y_5853 = ((-(0.4 + (r_5848 * 1.6))) * hv_5557);
cn_5792.V(Add(Call(rc_5567, V.Undef, ((V)((x_5852 - (0.8 * ToNum(k_5555))))), ((V)((y_5853 - (1.3 * hv_5557)))), ((V)((1.6 * ToNum(k_5555)))), ((V)((1.3 * hv_5557))), ((V)((0.45 * ToNum(k_5555)))), GetIdx(MS_5580, (((r_5848 + q_5850) + 4D) % 4D))), Call(rc_5567, V.Undef, ((V)((x_5852 - (0.8 * ToNum(k_5555))))), ((V)((y_5853 - (1.3 * hv_5557)))), ((V)((1.6 * ToNum(k_5555)))), ((V)((1.3 * hv_5557))), ((V)((0.45 * ToNum(k_5555)))), RG_5563)));
q_5850++;
}
}
r_5848++;
}
}
}
if (Truthy(lol_5790)) {
cn_5792.V(Add(Call(rc_5567, V.Undef, ((V)(((-rx_5786) + (0.3 * ToNum(k_5555))))), ((V)(((-lvl_5789) * 0.45))), ((V)(((2D * rx_5786) - (0.6 * ToNum(k_5555))))), ((V)((lvl_5789 * 0.45))), ((V)((0.6 * ToNum(k_5555)))), ((V)("#f8d0dc"))), Invoke(Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis5861, int _argc5854, V j_5860, V _a5857, V _a5858, V _a5859, V[] _rest5855) => {
return Call(el_5565, V.Undef, ((V)((((ToNum(Call(R_5559, V.Undef)) - 0.5) * 2D) * (rx_5786 - (0.8 * ToNum(k_5555)))))), ((V)(((-(0.3 + (ToNum(Call(R_5559, V.Undef)) * 0.35))) * lvl_5789))), ((V)((0.35 * ToNum(k_5555)))), ((V)((0.35 * ToNum(k_5555)))), GetIdx(GB_5579, (ToNum(j_5860) % 7D)));
}, 1, "", true)), "join", ((V)("")))));
}
s_5791 = ((V)(JsStrBuf.Begin().V(s_5791).S(cn_5792.Str).V(Call(rc_5567, V.Undef, ((V)((-rx_5786))), ((V)((-h_5787))), ((V)((2D * rx_5786))), ((V)(h_5787)), ((V)((0.9 * ToNum(k_5555)))), CY_5564, ((V)(" opacity=\"0.7\"")))).V(Call(rc_5567, V.Undef, ((V)(((-rx_5786) * 0.68))), ((V)(((-h_5787) * 0.92))), ((V)((0.5 * ToNum(k_5555)))), ((V)((h_5787 * 0.8))), ((V)((0.25 * ToNum(k_5555)))), ((V)("#ffffff")), ((V)(" opacity=\"0.5\"")))).V(Call(el_5565, V.Undef, ((V)(0D)), ((V)((-h_5787))), ((V)(rx_5786)), ((V)(ery_5788)), ((V)("none")), ((V)(JsStrBuf.Begin().S(" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.25 * ToNum(k_5555)))))).S("\" opacity=\"0.7\"").End())))).End()));
if (Truthy(lol_5790)) {
s_5791 = Add(s_5791, Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis5869, int _argc5862, V j_5868, V _a5865, V _a5866, V _a5867, V[] _rest5863) => {
double x_5870 = 0;
double ty_5871 = 0;
V col_5872 = default;
x_5870 = (((ToNum(j_5868) - 1D) * 1.6) * ToNum(k_5555));
ty_5871 = ((-h_5787) - ((2.4 + ((ToNum(j_5868) % 2D) * 1.5)) * hv_5557));
col_5872 = GetK(Arr(((V)("#f04a5a")), ((V)("#f6c040")), ((V)("#7cc8f0"))), j_5868);
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)((x_5870 * 0.5))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((-lvl_5789) * 0.5))))).S("L").V(Call(f1_16, V.Undef, ((V)(x_5870)))).S(" ").V(Call(f1_16, V.Undef, ((V)(ty_5871)))).S("\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.36 * ToNum(k_5555)))))).S("\"/>").V(Call(el_5565, V.Undef, ((V)(x_5870)), ((V)(ty_5871)), ((V)((1.6 * ToNum(k_5555)))), ((V)((1.6 * ToNum(k_5555)))), col_5872)).S("<circle cx=\"").V(Call(f1_16, V.Undef, ((V)(x_5870)))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)(ty_5871)))).S("\" r=\"").V(Call(f1_16, V.Undef, ((V)((0.95 * ToNum(k_5555)))))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.36 * ToNum(k_5555)))))).S("\" stroke-dasharray=\"").V(Call(f1_16, V.Undef, ((V)((1D * ToNum(k_5555)))))).S(" ").V(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(k_5555)))))).S("\"/>").V(Call(el_5565, V.Undef, ((V)(x_5870)), ((V)(ty_5871)), ((V)((1.6 * ToNum(k_5555)))), ((V)((1.6 * ToNum(k_5555)))), RG_5563)).End()));
return default;
}, 1, "", true)), "join", ((V)(""))));
} else {
s_5791 = Add(s_5791, Add(Add(Add(Add(Call(rc_5567, V.Undef, ((V)((-rx_5786))), ((V)(((-h_5787) + (0.2 * hv_5557)))), ((V)((2D * rx_5786))), ((V)((0.8 * hv_5557))), ((V)(0D)), ((V)("#f4a0b4"))), Call(el2_5566, V.Undef, ((V)((rx_5786 * 0.55))), ((V)(((-h_5787) + (0.6 * hv_5557)))), ((V)((0.6 * ToNum(k_5555)))), ((V)((0.45 * ToNum(k_5555)))), ((V)("#f08aa0")))), Call(rc_5567, V.Undef, ((V)(((-rx_5786) * 1.04))), ((V)(((-h_5787) - (1.2 * hv_5557)))), ((V)((2.08 * rx_5786))), ((V)((1.2 * hv_5557))), ((V)((0.3 * ToNum(k_5555)))), ((V)("url(#k74v)")))), Call(el_5565, V.Undef, ((V)(0D)), ((V)(((-h_5787) - (1.2 * hv_5557)))), ((V)((rx_5786 * 1.04))), ((V)((ery_5788 * 1.04))), ((V)("#e8c46a")))), Call(el2_5566, V.Undef, ((V)(0D)), ((V)((((-h_5787) - (1.2 * hv_5557)) - (0.7 * ToNum(k_5555))))), ((V)((0.9 * ToNum(k_5555)))), ((V)((0.9 * ToNum(k_5555)))), ((V)("#d8aa4e")))));
}
return s_5791;
return default;
}, 1, "", true);
stand_5582 = Fn((V _arrowThis5883, int _argc5873, V cx_5879, V y0_5880, V cz_5881, V T_5882, V[] _rest5874) => {
double NK_5884 = 0;
V post_5885 = default;
V pl_5886 = default;
V TI_5887 = default;
V YT_5888 = default;
V q0_5889 = default;
V s_5890 = default;
V qt_5891 = default;
NK_5884 = 24D;
post_5885 = Fn((V _arrowThis5900, int _argc5892, V ya_5898, V yb_5899, V _a5896, V _a5897, V[] _rest5893) => {
V a_5901 = default;
V b_5902 = default;
a_5901 = Call(FP_5051, V.Undef, c_5551, Arr(cx_5879, ya_5898, cz_5881));
b_5902 = Call(FP_5051, V.Undef, c_5551, Arr(cx_5879, yb_5899, cz_5881));
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_16, V.Undef, GetIdx(a_5901, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(a_5901, 1D))).S("L").V(Call(f1_16, V.Undef, GetIdx(b_5902, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(b_5902, 1D))).S("\" stroke=\"#a87a2a\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((1.2 * ToNum(k_5555)))))).S("\"/><path d=\"M").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(a_5901, 0D)) - (0.3 * ToNum(k_5555))))))).S(" ").V(Call(f1_16, V.Undef, GetIdx(a_5901, 1D))).S("L").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(b_5902, 0D)) - (0.3 * ToNum(k_5555))))))).S(" ").V(Call(f1_16, V.Undef, GetIdx(b_5902, 1D))).S("\" stroke=\"#fff0b8\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(k_5555)))))).S("\"/>").End()));
return default;
}, 2, "", true);
pl_5886 = Fn((V _arrowThis5911, int _argc5903, V y_5909, V r_5910, V _a5907, V _a5908, V[] _rest5904) => {
V q_5912 = default;
V rr_5913 = default;
q_5912 = Call(FP_5051, V.Undef, c_5551, Arr(cx_5879, y_5909, cz_5881));
rr_5913 = Add(r_5910, ((V)(1.2)));
return Add(Add(Add(Call(el_5565, V.Undef, GetIdx(q_5912, 0D), Add(GetIdx(q_5912, 1D), ((V)((0.9 * ToNum(k_5555))))), ((V)((ToNum(rr_5913) * ToNum(k_5555)))), ((V)((ToNum(rr_5913) * eyS_5558))), ((V)("#7a5418"))), Call(el_5565, V.Undef, GetIdx(q_5912, 0D), GetIdx(q_5912, 1D), ((V)((ToNum(rr_5913) * ToNum(k_5555)))), ((V)((ToNum(rr_5913) * eyS_5558))), ((V)("url(#k74b)")))), Call(el_5565, V.Undef, GetIdx(q_5912, 0D), GetIdx(q_5912, 1D), ((V)((ToNum(r_5910) * ToNum(k_5555)))), ((V)((ToNum(r_5910) * eyS_5558))), ((V)("#fff8f0")))), Call(el_5565, V.Undef, GetIdx(q_5912, 0D), GetIdx(q_5912, 1D), ((V)(((ToNum(r_5910) - 0.8) * ToNum(k_5555)))), ((V)(((ToNum(r_5910) - 0.8) * eyS_5558))), ((V)("none")), ((V)(JsStrBuf.Begin().S(" stroke=\"#f2c4cc\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(k_5555)))))).S("\" stroke-dasharray=\"").V(Call(f1_16, V.Undef, ((V)((0.5 * ToNum(k_5555)))))).S(" ").V(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(k_5555)))))).S("\"").End()))));
return default;
}, 2, "", true);
TI_5887 = Arr(Arr(Add(y0_5880, ((V)(3D))), ((V)(14D)), ((V)(8D)), cup_5574, ((V)(1D)), ((V)(0.78))), Arr(Add(y0_5880, ((V)(21D))), ((V)(11D)), ((V)(7D)), mac_5576, ((V)((-1D))), ((V)(0.78))), Arr(Add(y0_5880, ((V)(37D))), ((V)(8.5)), ((V)(5D)), Fn((V _arrowThis5921, int _argc5914, V i_5920, V _a5917, V _a5918, V _a5919, V[] _rest5915) => {
return Call(cake_5578, V.Undef, i_5920, ((V)(1D)));
}, 1, "", true), ((V)(1D)), ((V)(0.68))));
YT_5888 = Add(y0_5880, ((V)(51D)));
q0_5889 = Call(FP_5051, V.Undef, c_5551, Arr(cx_5879, y0_5880, cz_5881));
s_5890 = Add(Add(Call(el_5565, V.Undef, GetIdx(q0_5889, 0D), Add(GetIdx(q0_5889, 1D), ((V)((0.6 * ToNum(k_5555))))), ((V)((8D * ToNum(k_5555)))), ((V)((8D * eyS_5558))), ((V)("#5a2a1a")), ((V)(JsStrBuf.Begin().S(" opacity=\"0.22\" filter=\"url(#").V(id_5554).S("f)\"").End()))), Call(el_5565, V.Undef, GetIdx(q0_5889, 0D), GetIdx(q0_5889, 1D), ((V)((5D * ToNum(k_5555)))), ((V)((5D * eyS_5558))), ((V)("url(#k74b)")))), Call(post_5885, V.Undef, y0_5880, GetIdx(GetIdx(TI_5887, 0D), 0D)));
Invoke(TI_5887, "forEach", Fn((V _arrowThis5942, int _argc5922, V _a5924, V ti_5928, V _a5926, V _a5927, V[] _rest5923) => {
V ctr_5943 = default;
V yN_5944 = default;
JsStrBuf b_5945 = null;
JsStrBuf f_5946 = null;
V y_5931 = default;
V r_5933 = default;
V n_5935 = default;
V it_5937 = default;
V dir_5939 = default;
V ins_5941 = default;
{ V _t5929 = ListOf(_a5924);
{ V _t5930 = GetIdx(_t5929, 0D);
y_5931 = _t5930; }
{ V _t5932 = GetIdx(_t5929, 1D);
r_5933 = _t5932; }
{ V _t5934 = GetIdx(_t5929, 2D);
n_5935 = _t5934; }
{ V _t5936 = GetIdx(_t5929, 3D);
it_5937 = _t5936; }
{ V _t5938 = GetIdx(_t5929, 4D);
dir_5939 = _t5938; }
{ V _t5940 = GetIdx(_t5929, 5D);
ins_5941 = _t5940; }
}
ctr_5943 = Call(FP_5051, V.Undef, c_5551, Arr(cx_5879, y_5931, cz_5881));
yN_5944 = (LtN(ti_5928, 2D) ? GetIdx(GetK(TI_5887, Add(ti_5928, ((V)(1D)))), 0D) : YT_5888);
b_5945 = new JsStrBuf("");
f_5946 = new JsStrBuf("");
{
double i_5947 = 0;
i_5947 = 0D;
while (true) {
if (!(Lt(((V)(i_5947)), n_5935))) break;
V pos_5949 = default;
V fr_5950 = default;
V spr_5951 = default;
V mv_5952 = default;
V op_5953 = default;
pos_5949 = Arr();
fr_5950 = Arr();
spr_5951 = Call(it_5937, V.Undef, ((V)(i_5947)));
{
double j_5954 = 0;
j_5954 = 0D;
while (true) {
if (!((j_5954 <= NK_5884))) break;
V a_5956 = default;
V q_5957 = default;
a_5956 = Add(((V)((((ToNum(dir_5939) * 2D) * PI_11) * ((i_5947 / ToNum(n_5935)) + (j_5954 / NK_5884))))), ti_5928);
q_5957 = Call(FP_5051, V.Undef, c_5551, Arr(Add(cx_5879, ((V)(((FdLibm.Sin(ToNum(a_5956)) * ToNum(r_5933)) * ToNum(ins_5941))))), y_5931, Add(cz_5881, ((V)(((FdLibm.Cos(ToNum(a_5956)) * ToNum(r_5933)) * ToNum(ins_5941)))))));
Invoke(pos_5949, "push", ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, GetIdx(q_5957, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(q_5957, 1D))).End())));
Invoke(fr_5950, "push", ((V)((Gt(GetIdx(q_5957, 1D), GetIdx(ctr_5943, 1D)) ? 1D : 0D))));
j_5954++;
}
}
mv_5952 = ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"translate\" values=\"").V(Invoke(pos_5949, "join", ((V)(";")))).S("\" dur=\"").V(T_5882).S("s\"").V(Call(KT_5053, V.Undef, ((V)(NK_5884)))).S(" repeatCount=\"indefinite\"/>").End()));
op_5953 = Fn((V _arrowThis5965, int _argc5958, V v_5964, V _a5961, V _a5962, V _a5963, V[] _rest5959) => {
return ((V)(JsStrBuf.Begin().S("<animate attributeName=\"opacity\" values=\"").V(Invoke(Invoke(fr_5950, "map", Fn((V _arrowThis5973, int _argc5966, V x_5972, V _a5969, V _a5970, V _a5971, V[] _rest5967) => {
return ((V)((SEq(x_5972, v_5964) ? 1D : 0D)));
}, 1, "", true)), "join", ((V)(";")))).S("\" dur=\"").V(T_5882).S("s\"").V(Call(KT_5053, V.Undef, ((V)(NK_5884)))).S(" calcMode=\"discrete\" repeatCount=\"indefinite\"/>").End()));
}, 1, "", true);
b_5945.S("<g opacity=\"").N((Truthy(GetIdx(fr_5950, 0D)) ? 0D : 1D)).S("\">").V(Call(op_5953, V.Undef, ((V)(0D)))).S("<g>").V(mv_5952).V(spr_5951).S("</g></g>");
f_5946.S("<g opacity=\"").V(GetIdx(fr_5950, 0D)).S("\">").V(Call(op_5953, V.Undef, ((V)(1D)))).S("<g>").V(mv_5952).V(spr_5951).S("</g></g>");
i_5947++;
}
}
s_5890 = ((V)(JsStrBuf.Begin().V(s_5890).V(Call(pl_5886, V.Undef, y_5931, r_5933)).S(b_5945.Str).V(Call(post_5885, V.Undef, y_5931, yN_5944)).S(f_5946.Str).End()));
return default;
}, 2, "", true));
qt_5891 = Call(FP_5051, V.Undef, c_5551, Arr(cx_5879, YT_5888, cz_5881));
return ((V)(JsStrBuf.Begin().V(Add(s_5890, Call(pl_5886, V.Undef, YT_5888, ((V)(5.6))))).S("<g transform=\"translate(").V(Call(f1_16, V.Undef, GetIdx(qt_5891, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(qt_5891, 1D))).S(")\">").V(Call(cake_5578, V.Undef, ((V)(0D)), ((V)(1.7)))).S("</g>").End()));
return default;
}, 4, "", true);
@out_5583 = new JsStrBuf("");
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis5981, int _argc5974, V sg_5980, V _a5977, V _a5978, V _a5979, V[] _rest5975) => {
V x0_5982 = default;
V x1_5983 = default;
V y0_5984 = default;
V y1_5985 = default;
double z0_5986 = 0;
double zb_5987 = 0;
V cp_5988 = default;
JsStrBuf s_5989 = null;
V KS_5990 = default;
{ V _t5991 = Call(sOp_5449, V.Undef, sg_5980);
{ V _t5992 = ListOf(_t5991);
{ V _t5993 = GetIdx(_t5992, 0D);
x0_5982 = _t5993; }
{ V _t5994 = GetIdx(_t5992, 1D);
x1_5983 = _t5994; }
} }
y0_5984 = Get(SO_5447, "y0");
y1_5985 = Get(SO_5447, "y1");
z0_5986 = (ZS_5443 + 0.02);
zb_5987 = (ZS_5443 - 20D);
cp_5988 = ((V)(JsStrBuf.Begin().V(id_5554).S("c").N((GtN(sg_5980, 0D) ? 1D : 0D)).End()));
defs_5560.S("<clipPath id=\"").V(cp_5988).S("\"><path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(x0_5982, y1_5985, ((V)(z0_5986))), Arr(x1_5983, y1_5985, ((V)(z0_5986))), Arr(x1_5983, y0_5984, ((V)(z0_5986))), Arr(x0_5982, y0_5984, ((V)(z0_5986)))))).S("\"/></clipPath>");
s_5989 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(((V)((ToNum(x0_5982) - 8D))), Add(y1_5985, ((V)(8D))), ((V)(zb_5987))), Arr(Add(x1_5983, ((V)(8D))), Add(y1_5985, ((V)(8D))), ((V)(zb_5987))), Arr(Add(x1_5983, ((V)(8D))), ((V)((ToNum(y0_5984) - 8D))), ((V)(zb_5987))), Arr(((V)((ToNum(x0_5982) - 8D))), ((V)((ToNum(y0_5984) - 8D))), ((V)(zb_5987)))))).S("\" fill=\"url(#").V(id_5554).S("w)\"/>").End());
{
double x_5995 = 0;
x_5995 = (ToNum(x0_5982) - 8D);
while (true) {
if (!(Lt(((V)(x_5995)), Add(x1_5983, ((V)(8D)))))) break;
s_5989.S("<path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(((V)(x_5995)), Add(y1_5985, ((V)(8D))), ((V)((zb_5987 + 0.02)))), Arr(((V)((x_5995 + 1D))), Add(y1_5985, ((V)(8D))), ((V)((zb_5987 + 0.02)))), Arr(((V)((x_5995 + 1D))), ((V)((ToNum(y0_5984) - 8D))), ((V)((zb_5987 + 0.02)))), Arr(((V)(x_5995)), ((V)((ToNum(y0_5984) - 8D))), ((V)((zb_5987 + 0.02))))))).S("\" fill=\"#fff4f4\" opacity=\"0.5\"/>");
x_5995 = (x_5995 + 2.6);
}
}
s_5989.V(Call(walls_5570, V.Undef, x0_5982, x1_5983, y0_5984, y1_5985, ((V)(zb_5987)), ((V)(z0_5986)), ((V)("#f2c8d0")))).S("<path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(x0_5982, y1_5985, ((V)(zb_5987))), Arr(x1_5983, y1_5985, ((V)(zb_5987))), Arr(x1_5983, y0_5984, ((V)(zb_5987))), Arr(x0_5982, y0_5984, ((V)(zb_5987)))))).S("\" fill=\"url(#").V(id_5554).S("g)\"/>");
KS_5990 = (LtN(sg_5980, 0D) ? Arr(Arr(((V)("gum")), ((V)("lolly"))), Arr(((V)("mint")), ((V)("cookie"))), Arr(((V)("bean")), ((V)("marsh")))) : Arr(Arr(((V)("marsh")), ((V)("gum"))), Arr(((V)("cookie")), ((V)("bean"))), Arr(((V)("lolly")), ((V)("mint")))));
Invoke(Arr(y0_5984, Add(y0_5984, ((V)(19D))), Add(y0_5984, ((V)(38D)))), "forEach", Fn((V _arrowThis6005, int _argc5997, V y_6003, V si_6004, V _a6001, V _a6002, V[] _rest5998) => {
if (Truthy(si_6004)) {
s_5989.S("<path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(x0_5982, y_6003, ((V)(zb_5987))), Arr(x1_5983, y_6003, ((V)(zb_5987))), Arr(x1_5983, y_6003, ((V)((z0_5986 - 1D)))), Arr(x0_5982, y_6003, ((V)((z0_5986 - 1D))))))).S("\" fill=\"#eaf6f4\" opacity=\"0.45\"/><path d=\"M").V(Call(P2_5561, V.Undef, Arr(x0_5982, y_6003, ((V)((z0_5986 - 1D)))))).S("L").V(Call(P2_5561, V.Undef, Arr(x1_5983, y_6003, ((V)((z0_5986 - 1D)))))).S("\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(k_5555)))))).S("\" opacity=\"0.85\"/>");
}
Invoke(GetIdx(KS_5990, (2D - ToNum(si_6004))), "forEach", Fn((V _arrowThis6014, int _argc6006, V kd_6012, V ji_6013, V _a6010, V _a6011, V[] _rest6007) => {
V q_6015 = default;
q_6015 = Call(FP_5051, V.Undef, c_5551, Arr(Add(x0_5982, ((V)(((ToNum(x1_5983) - ToNum(x0_5982)) * (Truthy(ji_6013) ? 0.73 : 0.27))))), y_6003, ((V)((zb_5987 + 9D)))));
s_5989.S("<g transform=\"translate(").V(Call(f1_16, V.Undef, GetIdx(q_6015, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(q_6015, 1D))).S(")\">").V(Call(jar_5581, V.Undef, kd_6012)).S("</g>");
return default;
}, 2, "", true));
return default;
}, 2, "", true));
s_5989.V(Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis6023, int _argc6016, V i_6022, V _a6019, V _a6020, V _a6021, V[] _rest6017) => {
return Call(tw_5569, V.Undef, Call(FP_5051, V.Undef, c_5551, Arr(Add(Add(x0_5982, ((V)(3D))), ((V)((ToNum(Call(R_5559, V.Undef)) * ((ToNum(x1_5983) - ToNum(x0_5982)) - 6D))))), Add(Add(y0_5984, ((V)(6D))), ((V)((ToNum(Call(R_5559, V.Undef)) * ((ToNum(y1_5985) - ToNum(y0_5984)) - 12D))))), ((V)(z0_5986)))), ((V)(1.1)), ((V)((3.4 + (ToNum(i_6022) * 0.7)))), ((V)((-((ToNum(i_6022) * 1.7) + (GtN(sg_5980, 0D) ? 0.9 : 0D))))));
}, 1, "", true)), "join", ((V)(""))));
s_5989.S("<path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(x0_5982, y1_5985, ((V)(z0_5986))), Arr(x1_5983, y1_5985, ((V)(z0_5986))), Arr(x1_5983, y0_5984, ((V)(z0_5986))), Arr(x0_5982, y0_5984, ((V)(z0_5986)))))).S("\" fill=\"#fff6f0\" opacity=\"0.08\"/><path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(Add(x0_5982, ((V)(3D))), y1_5985, ((V)(z0_5986))), Arr(Add(x0_5982, ((V)(7D))), y1_5985, ((V)(z0_5986))), Arr(Add(x0_5982, ((V)(1D))), y0_5984, ((V)(z0_5986))), Arr(((V)((ToNum(x0_5982) - 3D))), y0_5984, ((V)(z0_5986)))))).S("\" fill=\"#ffffff\" opacity=\"0.1\"/><path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(Add(x0_5982, ((V)(9D))), y1_5985, ((V)(z0_5986))), Arr(Add(x0_5982, ((V)(10.4))), y1_5985, ((V)(z0_5986))), Arr(Add(x0_5982, ((V)(4.4))), y0_5984, ((V)(z0_5986))), Arr(Add(x0_5982, ((V)(3D))), y0_5984, ((V)(z0_5986)))))).S("\" fill=\"#ffffff\" opacity=\"0.07\"/>");
@out_5583.S("<g clip-path=\"url(#").V(cp_5988).S(")\">").S(s_5989.Str).S("</g>");
return default;
}, 1, "", true));
{
V x0_6024 = default;
V x1_6025 = default;
V y0_6026 = default;
V yA_6027 = default;
V r_6028 = default;
double z0_6029 = 0;
double zb_6030 = 0;
V cp_6031 = default;
V AR_6032 = default;
JsStrBuf s_6033 = null;
V bz_6034 = default;
V kq_6035 = default;
{ V _t6036 = VO_5446;
if (_t6036.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t6036));
{ V _t6037 = Get(_t6036, "x0");
x0_6024 = _t6037; }
{ V _t6038 = Get(_t6036, "x1");
x1_6025 = _t6038; }
{ V _t6039 = Get(_t6036, "y0");
y0_6026 = _t6039; }
{ V _t6040 = Get(_t6036, "yA");
yA_6027 = _t6040; }
{ V _t6041 = Get(_t6036, "r");
r_6028 = _t6041; } }
z0_6029 = (ZC_5444 + 0.02);
zb_6030 = (ZC_5444 - 34D);
cp_6031 = ((V)(JsStrBuf.Begin().V(id_5554).S("cv").End()));
AR_6032 = Invoke(Invoke(Arr(Arr(x0_6024, y0_6026, ((V)(z0_6029))), Arr(x1_6025, y0_6026, ((V)(z0_6029))), Arr(x1_6025, yA_6027, ((V)(z0_6029)))), "concat", Call(rep_18, V.Undef, ((V)(17D)), Fn((V _arrowThis6049, int _argc6042, V i_6048, V _a6045, V _a6046, V _a6047, V[] _rest6043) => {
double a_6050 = 0;
a_6050 = ((ToNum(i_6048) / 16D) * PI_11);
return Arr(((V)((ToNum(r_6028) * FdLibm.Cos(a_6050)))), Add(yA_6027, ((V)((ToNum(r_6028) * FdLibm.Sin(a_6050))))), ((V)(z0_6029)));
return default;
}, 1, "", true))), "concat", Arr(Arr(x0_6024, yA_6027, ((V)(z0_6029)))));
defs_5560.S("<clipPath id=\"").V(cp_6031).S("\"><path d=\"").V(Call(poly_5562, V.Undef, AR_6032)).S("\"/></clipPath>");
s_6033 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(((V)((ToNum(x0_6024) - 12D))), Add(Add(yA_6027, r_6028), ((V)(12D))), ((V)(zb_6030))), Arr(Add(x1_6025, ((V)(12D))), Add(Add(yA_6027, r_6028), ((V)(12D))), ((V)(zb_6030))), Arr(Add(x1_6025, ((V)(12D))), ((V)((ToNum(y0_6026) - 12D))), ((V)(zb_6030))), Arr(((V)((ToNum(x0_6024) - 12D))), ((V)((ToNum(y0_6026) - 12D))), ((V)(zb_6030)))))).S("\" fill=\"url(#").V(id_5554).S("w)\"/>").End());
{
double x_6051 = 0;
x_6051 = (ToNum(x0_6024) - 12D);
while (true) {
if (!(Lt(((V)(x_6051)), Add(x1_6025, ((V)(12D)))))) break;
s_6033.S("<path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(((V)(x_6051)), Add(Add(yA_6027, r_6028), ((V)(12D))), ((V)((zb_6030 + 0.02)))), Arr(((V)((x_6051 + 1.2))), Add(Add(yA_6027, r_6028), ((V)(12D))), ((V)((zb_6030 + 0.02)))), Arr(((V)((x_6051 + 1.2))), ((V)((ToNum(y0_6026) - 12D))), ((V)((zb_6030 + 0.02)))), Arr(((V)(x_6051)), ((V)((ToNum(y0_6026) - 12D))), ((V)((zb_6030 + 0.02))))))).S("\" fill=\"#fff4f4\" opacity=\"0.45\"/>");
x_6051 = (x_6051 + 3D);
}
}
s_6033.V(Call(walls_5570, V.Undef, x0_6024, x1_6025, y0_6026, Add(yA_6027, r_6028), ((V)(zb_6030)), ((V)(z0_6029)), ((V)("#f2c8d0")))).S("<path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(x0_6024, Add(yA_6027, r_6028), ((V)(zb_6030))), Arr(x1_6025, Add(yA_6027, r_6028), ((V)(zb_6030))), Arr(x1_6025, y0_6026, ((V)(zb_6030))), Arr(x0_6024, y0_6026, ((V)(zb_6030)))))).S("\" fill=\"url(#").V(id_5554).S("g)\">").V(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.75;1;0.75")), ((V)(7D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))).S("</path>");
s_6033.V(Add(Call(stand_5582, V.Undef, ((V)(0D)), y0_6026, ((V)((ZC_5444 - 17D))), ((V)(48D))), Invoke(Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis6060, int _argc6053, V i_6059, V _a6056, V _a6057, V _a6058, V[] _rest6054) => {
return Call(tw_5569, V.Undef, Call(FP_5051, V.Undef, c_5551, Arr(Add(Add(x0_6024, ((V)(4D))), ((V)((ToNum(Call(R_5559, V.Undef)) * 32D)))), Add(Add(y0_6026, ((V)(10D))), ((V)((ToNum(Call(R_5559, V.Undef)) * 60D)))), ((V)(z0_6029)))), ((V)(1.3)), ((V)((3D + (ToNum(i_6059) * 0.6)))), ((V)(((-ToNum(i_6059)) * 1.3))));
}, 1, "", true)), "join", ((V)("")))));
s_6033.S("<path d=\"").V(Call(poly_5562, V.Undef, AR_6032)).S("\" fill=\"#fff6f0\" opacity=\"0.07\"/><path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(Add(x0_6024, ((V)(5D))), Add(yA_6027, ((V)(18D))), ((V)(z0_6029))), Arr(Add(x0_6024, ((V)(11D))), Add(yA_6027, ((V)(18D))), ((V)(z0_6029))), Arr(Add(x0_6024, ((V)(3D))), y0_6026, ((V)(z0_6029))), Arr(((V)((ToNum(x0_6024) - 3D))), y0_6026, ((V)(z0_6029)))))).S("\" fill=\"#ffffff\" opacity=\"0.09\"/><path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(Add(x0_6024, ((V)(15D))), Add(yA_6027, ((V)(18D))), ((V)(z0_6029))), Arr(Add(x0_6024, ((V)(17D))), Add(yA_6027, ((V)(18D))), ((V)(z0_6029))), Arr(Add(x0_6024, ((V)(9D))), y0_6026, ((V)(z0_6029))), Arr(Add(x0_6024, ((V)(7D))), y0_6026, ((V)(z0_6029)))))).S("\" fill=\"#ffffff\" opacity=\"0.06\"/>");
@out_5583.S("<g clip-path=\"url(#").V(cp_6031).S(")\">").S(s_6033.Str).S("</g>");
bz_6034 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(AR_6032, "map", P2_5561), "join", ((V)("L")))).S("Z").End()));
@out_5583.S("<path d=\"").V(bz_6034).S("\" fill=\"none\" stroke=\"#b8882e\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((1.5 * ToNum(k_5555)))))).S("\" stroke-linejoin=\"round\"/><path d=\"").V(bz_6034).S("\" fill=\"none\" stroke=\"#f6dc96\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(k_5555)))))).S("\" stroke-linejoin=\"round\"/>");
kq_6035 = Call(FP_5051, V.Undef, c_5551, Arr(((V)(0D)), Add(Add(yA_6027, r_6028), ((V)(0.4))), ((V)((z0_6029 + 0.4)))));
@out_5583.V(Call(el_5565, V.Undef, GetIdx(kq_6035, 0D), GetIdx(kq_6035, 1D), ((V)((1.3 * ToNum(k_5555)))), ((V)((1.3 * ToNum(k_5555)))), ((V)("url(#k74b)"))));
}
txt_5584 = Fn((V _arrowThis6072, int _argc6061, V x_6067, V y_6068, V z_6069, V t_6070, V[] _rest6062) => {
V sz_6071 = default;
sz_6071 = (_argc6061 > 4 ? _rest6062[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(frame_5046, V.Undef, Get(c_5551, "p"), Arr(x_6067, y_6068, z_6069), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)((-1D))), ((V)(0D))))).S("\"><text text-anchor=\"middle\" font-family=\"Georgia,'Times New Roman',serif\" font-size=\"").V(sz_6071).S("\" fill=\"#8a5a3a\" letter-spacing=\"0.1\">").V(t_6070).S("</text></g>").End()));
}, 5, "", true);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis6080, int _argc6073, V sg_6079, V _a6076, V _a6077, V _a6078, V[] _rest6074) => {
return Invoke((LtN(sg_6079, 0D) ? Arr(((V)("COCOA")), ((V)("SPRINKLES")), ((V)("COOKIES"))) : Arr(((V)("FUDGE")), ((V)("MINTS")), ((V)("TOFFEE")))), "forEach", Fn((V _arrowThis6089, int _argc6081, V t_6087, V i_6088, V _a6085, V _a6086, V[] _rest6082) => {
return ((V)(@out_5583.V(Call(txt_5584, V.Undef, Call(sx_5448, V.Undef, sg_6079), ((V)((((YB_5439 + 3D) + (ToNum(i_6088) * 11.6)) + 7.35))), ((V)((ZS_5443 + 1.3))), t_6087, ((V)(1.25)))).Str));
}, 2, "", true));
}, 1, "", true));
@out_5583.V(Add(Call(txt_5584, V.Undef, ((V)((-11.6))), ((V)((YB_5439 + 17.35))), ((V)((ZC_5444 + 1.3))), ((V)("CAKES")), ((V)(1.4))), Call(txt_5584, V.Undef, ((V)(11.6)), ((V)((YB_5439 + 17.35))), ((V)((ZC_5444 + 1.3))), ((V)("TARTS")), ((V)(1.4)))));
{
double xa_6090 = 0;
double xb_6091 = 0;
double N_6092 = 0;
double yT_6093 = 0;
double yBt_6094 = 0;
double zT_6095 = 0;
double zB_6096 = 0;
double sc_6097 = 0;
JsStrBuf a_6098 = null;
V ra_6099 = default;
V rb_6100 = default;
xa_6090 = (-28D);
xb_6091 = 28D;
N_6092 = 8D;
yT_6093 = ((YB_5439 + HC_5442) - 1D);
yBt_6094 = ((YB_5439 + HC_5442) - 10D);
zT_6095 = (ZC_5444 + 0.2);
zB_6096 = (ZC_5444 + 8D);
sc_6097 = 2.4;
a_6098 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(((V)((xa_6090 + 2D))), ((V)((yBt_6094 - 0.5))), ((V)((ZC_5444 + 0.05)))), Arr(((V)((xb_6091 - 2D))), ((V)((yBt_6094 - 0.5))), ((V)((ZC_5444 + 0.05)))), Arr(((V)((xb_6091 - 2D))), ((V)((yBt_6094 - 7D))), ((V)((ZC_5444 + 0.05)))), Arr(((V)((xa_6090 + 2D))), ((V)((yBt_6094 - 7D))), ((V)((ZC_5444 + 0.05))))))).S("\" fill=\"#5a2030\" opacity=\"0.16\" filter=\"url(#").V(id_5554).S("f)\"/>").End());
Invoke(Arr(Arr(((V)(xa_6090)), Call(face_5049, V.Undef, c_5551, ((V)((-1D))), ((V)(0D)))), Arr(((V)(xb_6091)), Call(face_5049, V.Undef, c_5551, ((V)(1D)), ((V)(0D))))), "forEach", Fn((V _arrowThis6112, int _argc6101, V _a6103, V _a6104, V _a6105, V _a6106, V[] _rest6102) => {
V x_6109 = default;
V fv_6111 = default;
{ V _t6107 = ListOf(_a6103);
{ V _t6108 = GetIdx(_t6107, 0D);
x_6109 = _t6108; }
{ V _t6110 = GetIdx(_t6107, 1D);
fv_6111 = _t6110; }
}
if (GtN(fv_6111, 0D)) {
a_6098.S("<path d=\"").V(Call(poly_5562, V.Undef, Arr(Arr(x_6109, ((V)(yT_6093)), ((V)(zT_6095))), Arr(x_6109, ((V)(yBt_6094)), ((V)(zB_6096))), Arr(x_6109, ((V)(yBt_6094)), ((V)(zT_6095)))))).S("\" fill=\"").V(Call(shade_10, V.Undef, PK_5436, ((V)(0.8)))).S("\"/>");
}
return default;
}, 1, "", true));
{
double i_6113 = 0;
i_6113 = 0D;
while (true) {
if (!((i_6113 < N_6092))) break;
double u0_6115 = 0;
double u1_6116 = 0;
V col_6117 = default;
V d_6118 = default;
u0_6115 = (xa_6090 + (((xb_6091 - xa_6090) * i_6113) / N_6092));
u1_6116 = (xa_6090 + (((xb_6091 - xa_6090) * (i_6113 + 1D)) / N_6092));
col_6117 = (NumTruthy((i_6113 % 2D)) ? ((V)("#fff7ec")) : PK_5436);
d_6118 = Call(poly_5562, V.Undef, Invoke(Arr(Arr(((V)(u0_6115)), ((V)(yT_6093)), ((V)(zT_6095))), Arr(((V)(u1_6116)), ((V)(yT_6093)), ((V)(zT_6095)))), "concat", Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis6126, int _argc6119, V j_6125, V _a6122, V _a6123, V _a6124, V[] _rest6120) => {
double t_6127 = 0;
t_6127 = ((ToNum(j_6125) / 8D) * PI_11);
return Arr(((V)((u1_6116 - ((u1_6116 - u0_6115) * (0.5 - (0.5 * FdLibm.Cos(t_6127))))))), ((V)((yBt_6094 - (FdLibm.Sin(t_6127) * sc_6097)))), ((V)(zB_6096)));
return default;
}, 1, "", true))));
a_6098.S("<path d=\"").V(d_6118).S("\" fill=\"").V(col_6117).S("\"/><path d=\"").V(d_6118).S("\" fill=\"url(#").V(id_5554).S("a)\"/>");
i_6113++;
}
}
a_6098.S("<path d=\"M").V(Call(P2_5561, V.Undef, Arr(((V)(xa_6090)), ((V)(yBt_6094)), ((V)(zB_6096))))).S("L").V(Call(P2_5561, V.Undef, Arr(((V)(xb_6091)), ((V)(yBt_6094)), ((V)(zB_6096))))).S("\" stroke=\"#e890a4\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_5555)))))).S("\" opacity=\"0.7\"/>");
ra_6099 = Call(FP_5051, V.Undef, c_5551, Arr(((V)((xa_6090 - 1.2))), ((V)(yT_6093)), ((V)((zT_6095 + 0.3)))));
rb_6100 = Call(FP_5051, V.Undef, c_5551, Arr(((V)((xb_6091 + 1.2))), ((V)(yT_6093)), ((V)((zT_6095 + 0.3)))));
a_6098.S("<path d=\"M").V(Call(f1_16, V.Undef, GetIdx(ra_6099, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(ra_6099, 1D))).S("L").V(Call(f1_16, V.Undef, GetIdx(rb_6100, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(rb_6100, 1D))).S("\" stroke=\"#b8882e\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((1.1 * ToNum(k_5555)))))).S("\" stroke-linecap=\"round\"/><path d=\"M").V(Call(f1_16, V.Undef, GetIdx(ra_6099, 0D))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(ra_6099, 1D)) - (0.3 * ToNum(k_5555))))))).S("L").V(Call(f1_16, V.Undef, GetIdx(rb_6100, 0D))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(rb_6100, 1D)) - (0.3 * ToNum(k_5555))))))).S("\" stroke=\"#fff0b8\" stroke-width=\"").V(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_5555)))))).S("\" opacity=\"0.8\"/>").V(Call(el_5565, V.Undef, GetIdx(ra_6099, 0D), GetIdx(ra_6099, 1D), ((V)((1D * ToNum(k_5555)))), ((V)((1D * ToNum(k_5555)))), ((V)("url(#k74b)")))).V(Call(el_5565, V.Undef, GetIdx(rb_6100, 0D), GetIdx(rb_6100, 1D), ((V)((1D * ToNum(k_5555)))), ((V)((1D * ToNum(k_5555)))), ((V)("url(#k74b)"))));
@out_5583.S(a_6098.Str);
}
return NewObj(2).Put("defs", ((V)(defs_5560.Str))).Put("front", ((V)(@out_5583.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
}
{
V sp3_6128 = default;
V xe_6129 = default;
V SERIF_6130 = default;
V HAND_6131 = default;
V SANS_6132 = default;
V shW_6133 = default;
V sHook_6134 = default;
sp3_6128 = Fn((V _arrowThis6145, int _argc6135, V C_6141, V q_6142, V r_6143, V col_6144, V[] _rest6136) => {
V c_6146 = default;
c_6146 = Invoke(C_6141, "P", q_6142);
return ((V)(JsStrBuf.Begin().V(Invoke(H_12, "sph", C_6141, q_6142, r_6143, col_6144)).S(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(c_6146, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(c_6146, 1D))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_6143) * ToNum(Get(C_6141, "k"))))))), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_10, V.Undef, col_6144, ((V)(0.4)))), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.22 * ToNum(Get(C_6141, "k"))))))), "\" opacity=\"0.7\"/>")).End()));
return default;
}, 4, "", true);
xe_6129 = Fn((V _arrowThis6154, int _argc6147, V s_6153, V _a6150, V _a6151, V _a6152, V[] _rest6148) => {
return Invoke(Invoke(Invoke(Invoke(((V)(ToStrS(s_6153))), "replace", NewRegExp(RX5, "&", "g"), ((V)("&amp;"))), "replace", NewRegExp(RX4, "<", "g"), ((V)("&lt;"))), "replace", NewRegExp(RX3, ">", "g"), ((V)("&gt;"))), "replace", NewRegExp(RX2, "\"", "g"), ((V)("&quot;")));
}, 1, "", true);
SERIF_6130 = ((V)("Georgia,'Times New Roman',serif"));
HAND_6131 = ((V)("'Segoe Print','Comic Sans MS','Marker Felt',cursive"));
SANS_6132 = ((V)("Arial,Helvetica,sans-serif"));
shW_6133 = Fn((V _arrowThis6168, int _argc6155, V C_6161, V x_6162, V y_6163, V w_6164, V[] _rest6156) => {
V h_6165 = default;
V rx_6166 = default;
V op_6167 = default;
h_6165 = (_argc6155 > 4 ? _rest6156[0] : V.Undef);
rx_6166 = (_argc6155 > 5 ? _rest6156[1] : V.Undef);
op_6167 = (_argc6155 > 6 ? _rest6156[2] : V.Undef);
return Call(WD_4186, V.Undef, C_6161, Add(x_6162, ((V)(1.4))), ((V)((ToNum(y_6163) - 2.2))), ((V)(0.05)), ((V)(string.Concat("<rect width=\"", ToStr(Call(f1_16, V.Undef, w_6164)), "\" height=\"", ToStr(Call(f1_16, V.Undef, h_6165)), "\" rx=\"", ToStr((rx_6166 is var _t6169 && Truthy(_t6169) ? _t6169 : ((V)(1D)))), "\" fill=\"#000000\" opacity=\"", ToStr((op_6167 is var _t6170 && Truthy(_t6170) ? _t6170 : ((V)(0.3)))), "\" filter=\"url(#m10b3)\"/>"))));
}, 7, "", true);
sHook_6134 = Fn((V _arrowThis6183, int _argc6171, V C_6177, V x_6178, V yT_6179, V z_6180, V[] _rest6172) => {
V sc_6181 = default;
V col_6182 = default;
sc_6181 = (_argc6171 > 4 ? _rest6172[0] : V.Undef);
col_6182 = (_argc6171 > 5 ? _rest6172[1] : V.Undef);
return Call(WD_4186, V.Undef, C_6177, x_6178, yT_6179, z_6180, ((V)(string.Concat("<g transform=\"scale(", ToStr(sc_6181), ")\"><path d=\"M-1.2 1.4C-1.2 -0.4 1.2 -0.4 1.2 1.2V3.6C1.2 5.8 -1.2 5.8 -1.2 4.2\" stroke=\"", ToStr(col_6182), "\" stroke-width=\"0.5\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M-0.9 1.2C-0.9 0 0.9 0 0.9 1\" stroke=\"#ffffff\" stroke-width=\"0.15\" fill=\"none\" opacity=\"0.4\"/></g>"))));
}, 6, "", true);
Set(N_70, "menus27", Fn((V _arrowThis6191, int _argc6184, V S_6190, V _a6187, V _a6188, V _a6189, V[] _rest6185) => {
V D_6192 = default;
D_6192 = NewObj(5).Put("w", ((V)(86D))).Put("d", ((V)(12D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(44D))).Put("build", Fn((V _arrowThis6199, int _argc6193, V _a6195, V _a6196, V _a6197, V _a6198, V[] _rest6194) => {
return Arr();
}, 0, "build", true)).V;
Set(D_6192, "fx", Fn((V _arrowThis6207, int _argc6200, V ctx_6206, V _a6203, V _a6204, V _a6205, V[] _rest6201) => {
V C_6208 = default;
V R_6209 = default;
V k_6210 = default;
double RY_6211 = 0;
double RZ_6212 = 0;
double RR_6213 = 0;
V ln_6214 = default;
V pr_6215 = default;
V paper_6216 = default;
V pin_6217 = default;
V s_6218 = default;
V A_6219 = default;
V B_6220 = default;
V Cf_6221 = default;
V Dc_6222 = default;
V rollCap_6223 = default;
V flw_6224 = default;
double SW_6225 = 0;
double SHh_6226 = 0;
V tear_6227 = default;
V sh_6228 = default;
C_6208 = Call(camW_4181, V.Undef, ctx_6206);
R_6209 = Call(rng_13, V.Undef, ((V)("menus27")));
k_6210 = Get(C_6208, "k");
RY_6211 = 6D;
RZ_6212 = 6.4;
RR_6213 = 5.2;
Call(ext_4187, V.Undef, C_6208, Arr(Arr(((V)((-44D))), ((V)(50D)), ((V)(0D))), Arr(((V)(44D)), ((V)((-17D))), ((V)(0D))), Arr(((V)(44D)), ((V)((-17D))), ((V)(12D)))));
ln_6214 = Fn((V _arrowThis6241, int _argc6229, V x_6235, V y_6236, V w_6237, V n_6238, V[] _rest6230) => {
V dy_6239 = default;
V col_6240 = default;
dy_6239 = (_argc6229 > 4 ? _rest6230[0] : V.Undef);
col_6240 = (_argc6229 > 5 ? _rest6230[1] : V.Undef);
return Invoke(Call(rep_18, V.Undef, n_6238, Fn((V _arrowThis6249, int _argc6242, V i_6248, V _a6245, V _a6246, V _a6247, V[] _rest6243) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, x_6235)), "\" y=\"", ToStr(Call(f1_16, V.Undef, Add(y_6236, ((V)((ToNum(i_6248) * ToNum(dy_6239))))))), "\" width=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(w_6237) * (0.5 + (ToNum(Call(R_6209, V.Undef)) * 0.5))))))), "\" height=\"0.42\" fill=\"", ToStr((col_6240 is var _t6250 && Truthy(_t6250) ? _t6250 : ((V)("#3a3430")))), "\" opacity=\"0.55\"/>")));
}, 1, "", true)), "join", ((V)("")));
}, 6, "", true);
pr_6215 = Fn((V _arrowThis6261, int _argc6251, V x_6257, V y_6258, V n_6259, V dy_6260, V[] _rest6252) => {
return Invoke(Call(rep_18, V.Undef, n_6259, Fn((V _arrowThis6269, int _argc6262, V i_6268, V _a6265, V _a6266, V _a6267, V[] _rest6263) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, x_6257)), "\" y=\"", ToStr(Call(f1_16, V.Undef, Add(y_6258, ((V)((ToNum(i_6268) * ToNum(dy_6260))))))), "\" width=\"1.8\" height=\"0.42\" fill=\"#3a3430\" opacity=\"0.65\"/>")));
}, 1, "", true)), "join", ((V)("")));
}, 4, "", true);
paper_6216 = Fn((V _arrowThis6283, int _argc6270, V x_6276, V y_6277, V z_6278, V w_6279, V[] _rest6271) => {
V h_6280 = default;
V rot_6281 = default;
V body_6282 = default;
h_6280 = (_argc6270 > 4 ? _rest6271[0] : V.Undef);
rot_6281 = (_argc6270 > 5 ? _rest6271[1] : V.Undef);
body_6282 = (_argc6270 > 6 ? _rest6271[2] : V.Undef);
return Call(WD_4186, V.Undef, C_6208, x_6276, y_6277, z_6278, ((V)(string.Concat("<g transform=\"rotate(", ToStr(rot_6281), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(w_6279) / 2D))))), " 0)\"><rect x=\"0.5\" y=\"0.9\" width=\"", ToStr(w_6279), "\" height=\"", ToStr(h_6280), "\" fill=\"#000000\" opacity=\"0.22\" filter=\"url(#m12b1)\"/>", ToStr(body_6282), "</g>"))));
}, 7, "", true);
pin_6217 = Fn((V _arrowThis6293, int _argc6284, V x_6290, V y_6291, V col_6292, V _a6289, V[] _rest6285) => {
return Add(Add(Call(cyl3_4185, V.Undef, C_6208, Arr(x_6290, y_6291, ((V)(0.2))), Arr(x_6290, y_6291, ((V)(0.9))), ((V)(0.22)), ((V)("#c8ccd0")), NewObj(1).Put("n", ((V)(8D))).V), Call(cyl3_4185, V.Undef, C_6208, Arr(x_6290, y_6291, ((V)(0.9))), Arr(x_6290, y_6291, ((V)(2D))), ((V)(0.95)), col_6292, NewObj(3).Put("n", ((V)(14D))).Put("mat", ((V)("gloss"))).Put("r2", ((V)(0.7))).V)), Call(sp3_6128, V.Undef, C_6208, Arr(x_6290, y_6291, ((V)(2.3))), ((V)(0.85)), col_6292));
}, 3, "", true);
s_6218 = Call(WD_4186, V.Undef, C_6208, ((V)((-34D))), ((V)(33D)), ((V)(0.04)), ((V)("<circle r=\"0.35\" fill=\"#3a3028\" opacity=\"0.6\"/><circle cx=\"0.7\" cy=\"0.5\" r=\"0.6\" fill=\"#000000\" opacity=\"0.06\"/>")));
A_6219 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect width=\"22\" height=\"30\" fill=\"#f8f4ea\"/><rect width=\"22\" height=\"7\" fill=\"#c8302a\"/><text x=\"11\" y=\"4.2\" text-anchor=\"middle\" font-family=\"", ToStr(SERIF_6130), "\" font-weight=\"700\" font-size=\"3\" fill=\"#fff6e0\">TONY'S</text><text x=\"11\" y=\"6.3\" text-anchor=\"middle\" font-family=\"", ToStr(SANS_6132), "\" font-weight=\"700\" font-size=\"1.5\" fill=\"#ffe08a\" letter-spacing=\"0.3\">PIZZA \u00b7 SUBS</text>")).V(Invoke(Call(rep_18, V.Undef, ((V)(11D)), Fn((V _arrowThis6301, int _argc6294, V i_6300, V _a6297, V _a6298, V _a6299, V[] _rest6295) => {
return ((V)(string.Concat("<rect x=\"", NumStr((ToNum(i_6300) * 2D)), "\" y=\"7\" width=\"1\" height=\"1\" fill=\"#2f7a3a\"/><rect x=\"", NumStr(((ToNum(i_6300) * 2D) + 1D)), "\" y=\"7\" width=\"1\" height=\"1\" fill=\"#ffffff\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("<circle cx=\"6.5\" cy=\"13\" r=\"3.6\" fill=\"#e0a040\"/><circle cx=\"6.5\" cy=\"13\" r=\"3\" fill=\"#d84a2a\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis6309, int _argc6302, V i_6308, V _a6305, V _a6306, V _a6307, V[] _rest6303) => {
double a_6310 = 0;
a_6310 = (((ToNum(i_6308) / 6D) * PI_11) * 2D);
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((6.5 + (FdLibm.Cos(a_6310) * 1.7)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((13D + (FdLibm.Sin(a_6310) * 1.7)))))), "\" r=\"0.55\" fill=\"#9a2018\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))).S("<circle cx=\"6.5\" cy=\"13\" r=\"0.7\" fill=\"#f6e0a0\"/>").V(Call(ln_6214, V.Undef, ((V)(11.5)), ((V)(10.5)), ((V)(8D)), ((V)(5D)), ((V)(1.4)))).V(Call(ln_6214, V.Undef, ((V)(2D)), ((V)(18.5)), ((V)(14D)), ((V)(8D)), ((V)(1.3)))).V(Call(pr_6215, V.Undef, ((V)(18.2)), ((V)(18.5)), ((V)(8D)), ((V)(1.3)))).S("<rect x=\"7.33\" width=\"7.34\" height=\"30\" fill=\"#000000\" opacity=\"0.05\"/><path d=\"M7.33 0V30M14.67 0V30\" stroke=\"#c8bca4\" stroke-width=\"0.25\"/>").S("<ellipse cx=\"16\" cy=\"24\" rx=\"3.4\" ry=\"2.4\" fill=\"#d89a3a\" opacity=\"0.3\"/><ellipse cx=\"16.6\" cy=\"24.4\" rx=\"2\" ry=\"1.4\" fill=\"#c88a2a\" opacity=\"0.25\"/>").S(string.Concat("<text x=\"11\" y=\"28.6\" text-anchor=\"middle\" font-family=\"", ToStr(SANS_6132), "\" font-weight=\"700\" font-size=\"1.5\" fill=\"#c8302a\">555-0142</text>")).End()));
s_6218 = Add(s_6218, Call(paper_6216, V.Undef, ((V)((-41D))), ((V)(46D)), ((V)(0.1)), ((V)(22D)), ((V)(30D)), ((V)((-3D))), A_6219));
B_6220 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect width=\"20\" height=\"27\" fill=\"#c42a24\"/><rect x=\"1\" y=\"1\" width=\"18\" height=\"25\" fill=\"none\" stroke=\"#e8c050\" stroke-width=\"0.4\"/><rect x=\"2\" y=\"7.4\" width=\"16\" height=\"17.4\" fill=\"#fbf2dc\"/>", "")).S(string.Concat("<text x=\"10\" y=\"4.4\" text-anchor=\"middle\" font-family=\"", ToStr(SERIF_6130), "\" font-weight=\"700\" font-size=\"2.8\" fill=\"#f4d060\">GOLDEN WOK</text><text x=\"10\" y=\"6.4\" text-anchor=\"middle\" font-family=\"", ToStr(SANS_6132), "\" font-size=\"1.2\" fill=\"#f8e0a0\" letter-spacing=\"0.2\">FREE DELIVERY</text>")).S("<path d=\"M13.2 9.4h4.2l-0.6 4.2h-3z\" fill=\"#ffffff\" stroke=\"#8a2a20\" stroke-width=\"0.2\"/><path d=\"M14.4 9.4q0.9 -1.6 1.8 0\" stroke=\"#8a2a20\" stroke-width=\"0.2\" fill=\"none\"/>").V(Call(ln_6214, V.Undef, ((V)(3D)), ((V)(9.4)), ((V)(9D)), ((V)(4D)), ((V)(1.2)))).V(Call(ln_6214, V.Undef, ((V)(3D)), ((V)(15D)), ((V)(11D)), ((V)(7D)), ((V)(1.3)))).V(Call(pr_6215, V.Undef, ((V)(15.4)), ((V)(15D)), ((V)(7D)), ((V)(1.3)))).S(string.Concat("<text x=\"10\" y=\"25.4\" text-anchor=\"middle\" font-family=\"", ToStr(SANS_6132), "\" font-weight=\"700\" font-size=\"1.3\" fill=\"#f4d060\">LUNCH SPECIAL #7</text>")).End()));
s_6218 = Add(s_6218, Call(paper_6216, V.Undef, ((V)((-19D))), ((V)(47D)), ((V)(0.15)), ((V)(20D)), ((V)(27D)), ((V)(4D)), B_6220));
Cf_6221 = ((V)(JsStrBuf.Begin().S(string.Concat("<g>", ToStr(Call(at_47, V.Undef, ((V)("rotate")), ((V)("-0.6 9 0;0.8 9 0;-0.6 9 0")), ((V)(7D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "<rect width=\"18\" height=\"16.4\" fill=\"#f6d84a\"/><text x=\"9\" y=\"4.6\" text-anchor=\"middle\" font-family=\"", ToStr(HAND_6131), "\" font-weight=\"700\" font-size=\"3.3\" fill=\"#2f7a3a\">Taco Loco</text>")).S("<path d=\"M4 12a5 5 0 0 1 10 0z\" fill=\"#e8b040\" stroke=\"#b07a20\" stroke-width=\"0.3\"/><path d=\"M5 11.6q1 -2.4 2 -1.2q1 -2 2 -0.4q1 -1.8 2.2 0q0.8 -1 1.8 1.6\" fill=\"#6ab04a\"/><circle cx=\"7.2\" cy=\"10.4\" r=\"0.6\" fill=\"#d84a2a\"/><circle cx=\"10.6\" cy=\"10.2\" r=\"0.6\" fill=\"#d84a2a\"/>").V(Call(ln_6214, V.Undef, ((V)(2.4)), ((V)(13.4)), ((V)(13D)), ((V)(2D)), ((V)(1.2)), ((V)("#2a3a20")))).S(string.Concat("<g>", ToStr(Call(at_47, V.Undef, ((V)("rotate")), ((V)("0 0 16.4;4 0 16.4;-1 0 16.4;0 0 16.4")), ((V)(5.2)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(3D))))), "<path d=\"M0 16.4H18V21.4L16.6 22L15 21.3L13 22H0Z\" fill=\"#f8e070\"/><path d=\"M0 16.5H18\" stroke=\"#3a3020\" stroke-width=\"0.2\" stroke-dasharray=\"0.6 0.4\"/><text x=\"9\" y=\"19.4\" text-anchor=\"middle\" font-family=\"", ToStr(SANS_6132), "\" font-weight=\"700\" font-size=\"1.9\" fill=\"#c83a2a\">$2 OFF</text><text x=\"9\" y=\"21\" text-anchor=\"middle\" font-family=\"", ToStr(SANS_6132), "\" font-size=\"0.9\" fill=\"#3a3020\">any 3 tacos \u00b7 Tue only</text></g>")).S("<rect x=\"5\" y=\"-1.4\" width=\"8\" height=\"3\" fill=\"#f2eedc\" opacity=\"0.6\" transform=\"rotate(-4 9 0)\"/><path d=\"M5.2 -1.2v2.8M12.8 -1.6v2.8\" stroke=\"#ffffff\" stroke-width=\"0.15\" opacity=\"0.7\"/></g>").End()));
s_6218 = Add(s_6218, Call(paper_6216, V.Undef, ((V)((-1D))), ((V)(42D)), ((V)(0.2)), ((V)(18D)), ((V)(16.4)), ((V)((-5D))), Cf_6221));
Dc_6222 = ((V)(string.Concat("<rect width=\"14\" height=\"9\" fill=\"#fff8ee\"/><rect x=\"0.4\" y=\"0.4\" width=\"13.2\" height=\"8.2\" fill=\"none\" stroke=\"#c83a2a\" stroke-width=\"0.3\" stroke-dasharray=\"0.8 0.5\"/><text x=\"7\" y=\"3.4\" text-anchor=\"middle\" font-family=\"", ToStr(SERIF_6130), "\" font-weight=\"700\" font-size=\"1.8\" fill=\"#6a3a1a\">BURGER BARN</text><text x=\"7\" y=\"6.4\" text-anchor=\"middle\" font-family=\"", ToStr(SANS_6132), "\" font-weight=\"700\" font-size=\"2.2\" fill=\"#c83a2a\">2 for $5</text><path d=\"M10 7.6l2.6 -1\" stroke=\"#8a6a4a\" stroke-width=\"0.2\" opacity=\"0.5\"/>")));
s_6218 = Add(s_6218, Call(paper_6216, V.Undef, ((V)(19D)), ((V)(45D)), ((V)(0.25)), ((V)(14D)), ((V)(9D)), ((V)(7D)), Dc_6222));
s_6218 = Add(s_6218, Call(paper_6216, V.Undef, ((V)(25D)), ((V)(33D)), ((V)(0.3)), ((V)(9D)), ((V)(9D)), ((V)((-4D))), ((V)(string.Concat("<rect width=\"9\" height=\"9\" fill=\"#f6a8c4\"/><rect width=\"9\" height=\"1.6\" fill=\"#e890b0\"/><text x=\"4.5\" y=\"4.6\" text-anchor=\"middle\" font-family=\"", ToStr(HAND_6131), "\" font-size=\"1.7\" fill=\"#3a2a6a\">pizza</text><text x=\"4.5\" y=\"7\" text-anchor=\"middle\" font-family=\"", ToStr(HAND_6131), "\" font-weight=\"700\" font-size=\"2\" fill=\"#3a2a6a\">Fri!</text>")))));
s_6218 = Add(s_6218, Add(Add(Call(pin_6217, V.Undef, ((V)((-30D))), ((V)(44.4)), ((V)("#d83a2a"))), Call(pin_6217, V.Undef, ((V)((-8.6))), ((V)(45.4)), ((V)("#2f6ad0")))), Call(pin_6217, V.Undef, ((V)(26D)), ((V)(43.4)), ((V)("#3aa050")))));
s_6218 = Add(s_6218, Call(shW_6133, V.Undef, C_6208, ((V)((-19D))), ((V)((RY_6211 + 4D))), ((V)(38D)), ((V)(10D)), ((V)(4D)), ((V)(0.2))));
Invoke(Arr(((V)((-21D))), ((V)(21D))), "forEach", Fn((V _arrowThis6318, int _argc6311, V x_6317, V _a6314, V _a6315, V _a6316, V[] _rest6312) => {
s_6218 = Add(s_6218, Add(Add(Call(box3_4184, V.Undef, C_6208, NewObj(7).Put("c", Arr(x_6317, ((V)((RY_6211 - 5D))), ((V)(0.6)))).Put("w", ((V)(3.6))).Put("h", ((V)(9D))).Put("d", ((V)(1.2))).Put("col", ((V)("#eceae0"))).Put("r", ((V)(0.6))).Put("dec", (GtN(x_6317, 0D) ? NewObj(1).Put("f", ((V)("<path d=\"M0.6 2.6L1.6 4.2L1.2 5.4L2.4 7\" stroke=\"#7a766e\" stroke-width=\"0.2\" fill=\"none\"/>"))).V : V.Null)).V), Call(cyl3_4185, V.Undef, C_6208, Arr(x_6317, ((V)((RY_6211 - 7.4))), ((V)(1.2))), Arr(x_6317, ((V)((RY_6211 - 7.4))), ((V)(1.5))), ((V)(0.5)), ((V)("#b8bcc0")), NewObj(1).Put("n", ((V)(10D))).V)), Call(box3_4184, V.Undef, C_6208, NewObj(6).Put("c", Arr(x_6317, ((V)((RY_6211 - 1.3))), ((V)(3.8)))).Put("w", ((V)(2.2))).Put("h", ((V)(2.6))).Put("d", ((V)(5.2))).Put("col", ((V)("#eceae0"))).Put("r", ((V)(0.4))).V)));
return default;
}, 1, "", true));
s_6218 = Add(s_6218, Call(box3_4184, V.Undef, C_6208, NewObj(7).Put("c", Arr(((V)(21D)), ((V)((RY_6211 - 1.6))), ((V)(3.6)))).Put("w", ((V)(2.7))).Put("h", ((V)(3.2))).Put("d", ((V)(4.2))).Put("col", ((V)("#9ea1a6"))).Put("r", ((V)(0.3))).Put("dec", NewObj(2).Put("f", ((V)("<path d=\"M0.2 0.8L2.4 1.2M0.3 2.2L2.5 1.9\" stroke=\"#ffffff\" stroke-width=\"0.15\" opacity=\"0.5\"/>"))).Put("t", ((V)("<path d=\"M0.4 0.6L2.2 1.4M0.3 2.8L2.4 2.4\" stroke=\"#6a6c70\" stroke-width=\"0.15\"/>"))).V).V));
s_6218 = Add(s_6218, Call(cyl3_4185, V.Undef, C_6208, Arr(((V)((-21D))), ((V)(RY_6211)), ((V)(RZ_6212))), Arr(((V)(21D)), ((V)(RY_6211)), ((V)(RZ_6212))), ((V)(0.55)), ((V)("#d8d6cc")), NewObj(1).Put("n", ((V)(10D))).V));
rollCap_6223 = Fn((V _arrowThis6326, int _argc6319, V cr_6325, V _a6322, V _a6323, V _a6324, V[] _rest6320) => {
return ((V)(JsStrBuf.Begin().S(string.Concat("<circle r=\"", ToStr(Call(f1_16, V.Undef, cr_6325)), "\" fill=\"#f2efe6\"/>")).V(Invoke(Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis6334, int _argc6327, V i_6333, V _a6330, V _a6331, V _a6332, V[] _rest6328) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6325) * (0.36 + (ToNum(i_6333) * 0.12))))))), "\" fill=\"none\" stroke=\"#d6d0c2\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6325) * 0.015))))), "\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6325) * 0.3))))), "\" fill=\"#b88a58\"/><circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6325) * 0.23))))), "\" fill=\"#4a3628\"/>")).End()));
}, 1, "", true);
s_6218 = Add(s_6218, Call(cyl3_4185, V.Undef, C_6208, Arr(((V)((-18.4))), ((V)(RY_6211)), ((V)(RZ_6212))), Arr(((V)(18.4)), ((V)(RY_6211)), ((V)(RZ_6212))), ((V)(RR_6213)), ((V)("#f8f6f0")), NewObj(3).Put("n", ((V)(30D))).Put("capCol", ((V)("#f0ede4"))).Put("cap", rollCap_6223).V));
flw_6224 = Fn((V _arrowThis6344, int _argc6335, V x_6341, V y_6342, V sc_6343, V _a6340, V[] _rest6336) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(f1_16, V.Undef, x_6341)), " ", ToStr(Call(f1_16, V.Undef, y_6342)), ") scale(", ToStr(Call(f1_16, V.Undef, sc_6343)), ")\"><circle cx=\"-0.35\" r=\"0.3\" fill=\"#8aa6d8\"/><circle cx=\"0.35\" r=\"0.3\" fill=\"#8aa6d8\"/><circle cy=\"-0.35\" r=\"0.3\" fill=\"#8aa6d8\"/><circle cy=\"0.35\" r=\"0.3\" fill=\"#8aa6d8\"/><circle r=\"0.22\" fill=\"#f2d04a\"/></g>")));
}, 3, "", true);
s_6218 = Add(s_6218, Invoke(Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis6351, int _argc6345, V _a6347, V _a6348, V _a6349, V _a6350, V[] _rest6346) => {
double x_6352 = 0;
double a_6353 = 0;
V p_6354 = default;
x_6352 = ((-17D) + (ToNum(Call(R_6209, V.Undef)) * 34D));
a_6353 = ((ToNum(Call(R_6209, V.Undef)) - 0.3) * 1.8);
p_6354 = Invoke(C_6208, "P", Arr(((V)(x_6352)), ((V)((RY_6211 + (RR_6213 * FdLibm.Sin(a_6353))))), ((V)((RZ_6212 + (RR_6213 * FdLibm.Cos(a_6353)))))));
return Call(flw_6224, V.Undef, GetIdx(p_6354, 0D), GetIdx(p_6354, 1D), ((V)((ToNum(k_6210) * (0.5 + (0.5 * FdLibm.Cos(a_6353)))))));
return default;
}, 0, "", true)), "join", ((V)(""))));
s_6218 = Add(s_6218, Call(line3_4191, V.Undef, C_6208, Arr(Arr(((V)((-18.4))), ((V)((RY_6211 + (RR_6213 * FdLibm.Sin(1D))))), ((V)((RZ_6212 + (RR_6213 * FdLibm.Cos(1D)))))), Arr(((V)(18.4)), ((V)((RY_6211 + (RR_6213 * FdLibm.Sin(1D))))), ((V)((RZ_6212 + (RR_6213 * FdLibm.Cos(1D))))))), ((V)(0.14)), ((V)("#c8c2b4")), ((V)(string.Concat("stroke-dasharray=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(k_6210)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(k_6210)))))), "\"")))));
SW_6225 = 36.8;
SHh_6226 = 19D;
tear_6227 = Call(rep_18, V.Undef, ((V)(13D)), Fn((V _arrowThis6362, int _argc6355, V i_6361, V _a6358, V _a6359, V _a6360, V[] _rest6356) => {
return Arr(((V)((SW_6225 - ((ToNum(i_6361) * SW_6225) / 12D)))), ((V)(((SHh_6226 + (NumTruthy((ToNum(i_6361) % 2D)) ? 0.9 : 0D)) + (ToNum(Call(R_6209, V.Undef)) * 0.7)))));
}, 1, "", true));
sh_6228 = ((V)(JsStrBuf.Begin().S(string.Concat("<path d=\"M0 0H", NumStr(SW_6225), ToStr(Invoke(Invoke(tear_6227, "map", Fn((V _arrowThis6370, int _argc6363, V p_6369, V _a6366, V _a6367, V _a6368, V[] _rest6364) => {
return ((V)(JsStrBuf.Begin().S("L").V(Call(f1_16, V.Undef, GetIdx(p_6369, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(p_6369, 1D))).End()));
}, 1, "", true)), "join", ((V)("")))), "Z\" fill=\"#faf8f2\"/>")).V(Invoke(Call(rep_18, V.Undef, ((V)(60D)), Fn((V _arrowThis6378, int _argc6371, V i_6377, V _a6374, V _a6375, V _a6376, V[] _rest6372) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.5 + ((ToNum(i_6377) % 12D) * 3.05)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.6 + (System.Math.Floor((ToNum(i_6377) / 12D)) * 3.4)))))), "\" r=\"0.2\" fill=\"#e4e0d4\"/>")));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis6385, int _argc6379, V _a6381, V _a6382, V _a6383, V _a6384, V[] _rest6380) => {
return Call(flw_6224, V.Undef, ((V)((1.5 + (ToNum(Call(R_6209, V.Undef)) * 33.8)))), ((V)((2D + (ToNum(Call(R_6209, V.Undef)) * 15.6)))), ((V)(0.9)));
}, 0, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"M0 9.6H", NumStr(SW_6225), "\" stroke=\"#c8c2b4\" stroke-width=\"0.16\" stroke-dasharray=\"0.6 0.4\"/>")).S(string.Concat("<rect width=\"", NumStr(SW_6225), "\" height=\"2.6\" fill=\"url(#k04s)\"/><ellipse cx=\"27\" cy=\"13.6\" rx=\"1.3\" ry=\"1.7\" fill=\"#d8b060\" opacity=\"0.22\"/><path d=\"M", NumStr((SW_6225 - 0.2)), " 0V", NumStr(SHh_6226), "\" stroke=\"#d8d4c8\" stroke-width=\"0.3\"/>")).End()));
s_6218 = Add(s_6218, Call(swayAt_4192, V.Undef, C_6208, Arr(((V)(0D)), ((V)(RY_6211)), ((V)((RZ_6212 + RR_6213)))), ((V)(1.4)), ((V)(5.2)), ((V)(0.4)), Call(WD_4186, V.Undef, C_6208, ((V)(((-SW_6225) / 2D))), ((V)(RY_6211)), ((V)(((RZ_6212 + RR_6213) + 0.05))), sh_6228)));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(DEF19_4188).S("<defs><linearGradient id=\"k04s\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#000000\" stop-opacity=\"0.2\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0\"/></linearGradient></defs>").End()))).Put("front", s_6218).Put("bb", Invoke(C_6208, "bb", ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_6192;
return default;
}, 1, "", true));
Set(N_70, "knife27", Fn((V _arrowThis6393, int _argc6386, V S_6392, V _a6389, V _a6390, V _a6391, V[] _rest6387) => {
V D_6394 = default;
D_6394 = NewObj(5).Put("w", ((V)(100D))).Put("d", ((V)(10D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(44D))).Put("build", Fn((V _arrowThis6401, int _argc6395, V _a6397, V _a6398, V _a6399, V _a6400, V[] _rest6396) => {
return Arr();
}, 0, "build", true)).V;
Set(D_6394, "fx", Fn((V _arrowThis6409, int _argc6402, V ctx_6408, V _a6405, V _a6406, V _a6407, V[] _rest6403) => {
V C_6410 = default;
V R_6411 = default;
V id_6412 = default;
double Y0_6413 = 0;
V PN_6414 = default;
V NL_6415 = default;
V CH_6416 = default;
V items_6417 = default;
JsStrBuf chalk_6418 = null;
V ghost_6419 = default;
V msk_6420 = default;
V grain_6421 = default;
V face_6422 = default;
V bd_6423 = default;
V tw_6424 = default;
V s_6425 = default;
V bg_6426 = default;
V KN_6427 = default;
C_6410 = Call(camW_4181, V.Undef, ctx_6408);
R_6411 = Call(rng_13, V.Undef, ((V)("knife27")));
id_6412 = Invoke(C_6410, "u", ((V)("k24")));
Y0_6413 = 10D;
PN_6414 = ((V)("#c8965a"));
NL_6415 = Arr(((V)((-25D))), ((V)(54D)), ((V)(1.4)));
Call(ext_4187, V.Undef, C_6410, Arr(Arr(((V)((-48D))), ((V)(56D)), ((V)(0D))), Arr(((V)(48D)), ((V)(8D)), ((V)(0D))), Arr(((V)(48D)), ((V)(8D)), ((V)(8D)))));
CH_6416 = ((V)("#f2f0e8"));
items_6417 = Arr(Arr(((V)("Pancakes")), ((V)("#f6b8c8")), ((V)("$2"))), Arr(((V)("Tomato Soup")), ((V)("#f6e08a")), ((V)("$3"))), Arr(((V)("Mac & Cheese")), ((V)("#a8e0c0")), ((V)("$3"))), Arr(((V)("Apple Pie")), ((V)("#a8c8f0")), ((V)("$2"))));
chalk_6418 = new JsStrBuf(string.Concat("<text x=\"20\" y=\"8.4\" text-anchor=\"middle\" font-family=\"", ToStr(HAND_6131), "\" font-weight=\"700\" font-size=\"3.3\" fill=\"", ToStr(CH_6416), "\">Today's Menu</text><path d=\"M9 9.9q11 1.6 22 -0.4\" stroke=\"", ToStr(CH_6416), "\" stroke-width=\"0.35\" fill=\"none\" stroke-linecap=\"round\"/>"));
Invoke(items_6417, "forEach", Fn((V _arrowThis6442, int _argc6428, V _a6430, V i_6434, V _a6432, V _a6433, V[] _rest6429) => {
double y_6443 = 0;
V t_6437 = default;
V c_6439 = default;
V p_6441 = default;
{ V _t6435 = ListOf(_a6430);
{ V _t6436 = GetIdx(_t6435, 0D);
t_6437 = _t6436; }
{ V _t6438 = GetIdx(_t6435, 1D);
c_6439 = _t6438; }
{ V _t6440 = GetIdx(_t6435, 2D);
p_6441 = _t6440; }
}
y_6443 = (13.6 + (ToNum(i_6434) * 3.6));
chalk_6418.S(string.Concat("<path d=\"M0 0.6C-1 -0.2 -0.6 -1 0 -0.5C0.6 -1 1 -0.2 0 0.6Z\" transform=\"translate(5.6 ", ToStr(Call(f1_16, V.Undef, ((V)((y_6443 - 0.7))))), ")\" fill=\"none\" stroke=\"", ToStr(c_6439), "\" stroke-width=\"0.3\"/><text x=\"7.2\" y=\"", ToStr(Call(f1_16, V.Undef, ((V)(y_6443)))), "\" font-family=\"", ToStr(HAND_6131), "\" font-size=\"2.1\" fill=\"", ToStr(CH_6416), "\">", ToStr(Call(xe_6129, V.Undef, t_6437)), "</text><text x=\"26.4\" y=\"", ToStr(Call(f1_16, V.Undef, ((V)(y_6443)))), "\" text-anchor=\"end\" font-family=\"", ToStr(HAND_6131), "\" font-size=\"2\" fill=\"", ToStr(c_6439), "\">", ToStr(p_6441), "</text>"));
return default;
}, 2, "", true));
chalk_6418.S("<path d=\"M30.6 21.8h4l-0.7 3.6h-2.6z\" fill=\"none\" stroke=\"#f6b8c8\" stroke-width=\"0.3\"/><path d=\"M31.4 22.4l0.2 2.6M32.6 22.4v2.8M33.8 22.4l-0.2 2.6\" stroke=\"#f6b8c8\" stroke-width=\"0.15\"/><path d=\"M30.2 21.8q-0.2 -1.6 1.4 -1.6q0.4 -1.4 2 -0.8q1.6 -0.2 1.4 1.4q0.4 0.6 -0.4 1z\" fill=\"none\" stroke=\"").V(CH_6416).S("\" stroke-width=\"0.3\"/><circle cx=\"32.8\" cy=\"18.8\" r=\"0.6\" fill=\"none\" stroke=\"#f08080\" stroke-width=\"0.3\"/>").S("<path d=\"M31 13.6h3.2v2.6q0 1 -1 1h-1.2q-1 0 -1 -1z\" fill=\"none\" stroke=\"#a8c8f0\" stroke-width=\"0.3\"/><path d=\"M34.2 14.2q1.2 0 1.2 0.9q0 0.9 -1.2 0.9\" fill=\"none\" stroke=\"#a8c8f0\" stroke-width=\"0.3\"/><path d=\"M31.8 12.8q-0.6 -0.8 0 -1.6q0.6 -0.8 0 -1.6M33.4 12.8q-0.6 -0.8 0 -1.6q0.6 -0.8 0 -1.6\" fill=\"none\" stroke=\"").V(CH_6416).S("\" stroke-width=\"0.22\" opacity=\"0.8\"/>");
ghost_6419 = ((V)(JsStrBuf.Begin().V(Invoke(Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis6450, int _argc6444, V _a6446, V _a6447, V _a6448, V _a6449, V[] _rest6445) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((6D + (ToNum(Call(R_6411, V.Undef)) * 28D)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((5D + (ToNum(Call(R_6411, V.Undef)) * 22D)))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((4D + (ToNum(Call(R_6411, V.Undef)) * 5D)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.2 + (ToNum(Call(R_6411, V.Undef)) * 1.6)))))), "\" transform=\"rotate(", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(Call(R_6411, V.Undef)) - 0.5) * 30D))))), " 20 16)\" fill=\"#ffffff\" opacity=\"0.06\"/>")));
}, 0, "", true)), "join", ((V)("")))).S(string.Concat("<text x=\"20\" y=\"28\" text-anchor=\"middle\" font-family=\"", ToStr(HAND_6131), "\" font-size=\"1.8\" fill=\"#ffffff\" opacity=\"0.1\">Tues: tacos!</text>")).End()));
msk_6420 = ((V)(string.Concat("<defs><mask id=\"", ToStr(id_6412), "m\"><rect x=\"-2\" y=\"-2\" width=\"44\" height=\"36\" fill=\"#ffffff\"/>", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(110D)), Fn((V _arrowThis6457, int _argc6451, V _a6453, V _a6454, V _a6455, V _a6456, V[] _rest6452) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6411, V.Undef)) * 40D))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6411, V.Undef)) * 32D))))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.1 + (ToNum(Call(R_6411, V.Undef)) * 0.28)))))), "\" fill=\"#000000\"/>")));
}, 0, "", true)), "join", ((V)("")))), "</mask></defs>")));
grain_6421 = Invoke(Call(rep_18, V.Undef, ((V)(14D)), Fn((V _arrowThis6464, int _argc6458, V _a6460, V _a6461, V _a6462, V _a6463, V[] _rest6459) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6411, V.Undef)) * 33D))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6411, V.Undef)) * 32D))))), "h", ToStr(Call(f1_16, V.Undef, ((V)((2D + (ToNum(Call(R_6411, V.Undef)) * 5D)))))), "\" stroke=\"#9a6a3a\" stroke-width=\"0.15\" opacity=\"0.6\"/>")));
}, 0, "", true)), "join", ((V)("")));
face_6422 = ((V)(JsStrBuf.Begin().V(grain_6421).S("<path d=\"M0 0L2.4 2.4M40 0L37.6 2.4M0 32L2.4 29.6M40 32L37.6 29.6\" stroke=\"#8a6034\" stroke-width=\"0.2\"/><rect x=\"2.4\" y=\"2.4\" width=\"35.2\" height=\"27.2\" fill=\"#2c302e\"/>").V(ghost_6419).V(msk_6420).S(string.Concat("<g mask=\"url(#", ToStr(id_6412), "m)\" opacity=\"0.92\">", chalk_6418.Str, "</g>")).V(Invoke(Call(rep_18, V.Undef, ((V)(30D)), Fn((V _arrowThis6471, int _argc6465, V _a6467, V _a6468, V _a6469, V _a6470, V[] _rest6466) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((3D + (ToNum(Call(R_6411, V.Undef)) * 34D)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((28.4 + (ToNum(Call(R_6411, V.Undef)) * 1D)))))), "\" r=\"0.12\" fill=\"#ffffff\" opacity=\"0.3\"/>")));
}, 0, "", true)), "join", ((V)("")))).S("<rect x=\"2.4\" y=\"2.4\" width=\"35.2\" height=\"27.2\" fill=\"none\" stroke=\"#000000\" stroke-width=\"0.5\" opacity=\"0.4\"/>").End()));
bd_6423 = Call(shW_6133, V.Undef, C_6410, ((V)((-45D))), ((V)((Y0_6413 + 32D))), ((V)(40D)), ((V)(34D)), ((V)(1D)), ((V)(0.34)));
bd_6423 = Add(bd_6423, Call(box3_4184, V.Undef, C_6410, NewObj(7).Put("c", Arr(((V)((-25D))), ((V)(Y0_6413)), ((V)(1.2)))).Put("w", ((V)(40D))).Put("h", ((V)(32D))).Put("d", ((V)(2.4))).Put("col", PN_6414).Put("r", ((V)(0.4))).Put("dec", NewObj(2).Put("f", face_6422).Put("t", Invoke(Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis6478, int _argc6472, V _a6474, V _a6475, V _a6476, V _a6477, V[] _rest6473) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6411, V.Undef)) * 30D))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.4 + (ToNum(Call(R_6411, V.Undef)) * 1.6)))))), "h", ToStr(Call(f1_16, V.Undef, ((V)((3D + (ToNum(Call(R_6411, V.Undef)) * 5D)))))), "\" stroke=\"#9a6a3a\" stroke-width=\"0.15\" opacity=\"0.6\"/>")));
}, 0, "", true)), "join", ((V)("")))).V).V));
bd_6423 = Add(bd_6423, Call(box3_4184, V.Undef, C_6410, NewObj(7).Put("c", Arr(((V)((-25D))), ((V)((Y0_6413 - 2D))), ((V)(2D)))).Put("w", ((V)(38D))).Put("h", ((V)(2D))).Put("d", ((V)(4D))).Put("col", Call(shade_10, V.Undef, PN_6414, ((V)(0.95)))).Put("r", ((V)(0.3))).Put("dec", NewObj(1).Put("t", Invoke(Call(rep_18, V.Undef, ((V)(24D)), Fn((V _arrowThis6485, int _argc6479, V _a6481, V _a6482, V _a6483, V _a6484, V[] _rest6480) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6411, V.Undef)) * 38D))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6411, V.Undef)) * 4D))))), "\" r=\"0.14\" fill=\"#ffffff\" opacity=\"0.35\"/>")));
}, 0, "", true)), "join", ((V)("")))).V).V));
bd_6423 = Add(bd_6423, Add(Call(cyl3_4185, V.Undef, C_6410, Arr(((V)((-38D))), ((V)((Y0_6413 + 0.55))), ((V)(3D))), Arr(((V)((-33D))), ((V)((Y0_6413 + 0.55))), ((V)(3D))), ((V)(0.55)), ((V)("#f6f4ee")), NewObj(1).Put("n", ((V)(12D))).V), Call(cyl3_4185, V.Undef, C_6410, Arr(((V)((-31D))), ((V)((Y0_6413 + 0.5))), ((V)(2.6))), Arr(((V)((-27.6))), ((V)((Y0_6413 + 0.5))), ((V)(2.6))), ((V)(0.5)), ((V)("#f2a8c0")), NewObj(1).Put("n", ((V)(12D))).V)));
bd_6423 = Add(bd_6423, Add(Call(box3_4184, V.Undef, C_6410, NewObj(6).Put("c", Arr(((V)((-16D))), ((V)(Y0_6413)), ((V)(2.4)))).Put("w", ((V)(6.4))).Put("h", ((V)(1.1))).Put("d", ((V)(2.6))).Put("col", ((V)("#4a4f5a"))).Put("r", ((V)(0.2))).V), Call(box3_4184, V.Undef, C_6410, NewObj(7).Put("c", Arr(((V)((-16D))), ((V)((Y0_6413 + 1.1))), ((V)(2.4)))).Put("w", ((V)(6.4))).Put("h", ((V)(1.5))).Put("d", ((V)(2.6))).Put("col", ((V)("#d8b078"))).Put("r", ((V)(0.3))).Put("dec", NewObj(1).Put("f", ((V)(string.Concat("<text x=\"3.2\" y=\"1.1\" text-anchor=\"middle\" font-family=\"", ToStr(SANS_6132), "\" font-weight=\"700\" font-size=\"0.9\" fill=\"#7a4a22\">ERASER</text>")))).V).V)));
Invoke(Arr(((V)((-41D))), ((V)((-9D)))), "forEach", Fn((V _arrowThis6493, int _argc6486, V x_6492, V _a6489, V _a6490, V _a6491, V[] _rest6487) => {
return (bd_6423 = Add(bd_6423, Call(WD_4186, V.Undef, C_6410, x_6492, ((V)((Y0_6413 + 32.8))), ((V)(1.5)), ((V)("<circle r=\"0.6\" fill=\"none\" stroke=\"#b8a070\" stroke-width=\"0.3\"/>")))));
}, 1, "", true));
tw_6424 = Arr(Arr(((V)((-41D))), ((V)((Y0_6413 + 32.6))), ((V)(1.6))), NL_6415, Arr(((V)((-9D))), ((V)((Y0_6413 + 32.6))), ((V)(1.6))));
bd_6423 = Add(bd_6423, Add(Call(line3_4191, V.Undef, C_6410, tw_6424, ((V)(0.6)), ((V)("#a8844e"))), Call(line3_4191, V.Undef, C_6410, tw_6424, ((V)(0.3)), ((V)("#d8b884")), ((V)(string.Concat("stroke-dasharray=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(Get(C_6410, "k"))))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.4 * ToNum(Get(C_6410, "k"))))))), "\""))))));
s_6425 = Add(Add(Call(swayAt_4192, V.Undef, C_6410, NL_6415, ((V)(0.8)), ((V)(6.4)), ((V)(0D)), bd_6423), Call(cyl3_4185, V.Undef, C_6410, Arr(GetIdx(NL_6415, 0D), GetIdx(NL_6415, 1D), ((V)(0D))), Arr(GetIdx(NL_6415, 0D), GetIdx(NL_6415, 1D), ((V)(2.3))), ((V)(0.32)), ((V)("#8a8f96")), NewObj(1).Put("n", ((V)(8D))).V)), Call(sp3_6128, V.Undef, C_6410, Arr(GetIdx(NL_6415, 0D), GetIdx(NL_6415, 1D), ((V)(2.4))), ((V)(0.7)), ((V)("#9aa0a8"))));
bg_6426 = Invoke(Call(rep_18, V.Undef, ((V)(8D)), Fn((V _arrowThis6500, int _argc6494, V _a6496, V _a6497, V _a6498, V _a6499, V[] _rest6495) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6411, V.Undef)) * 30D))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.4 + (ToNum(Call(R_6411, V.Undef)) * 4.2)))))), "q", ToStr(Call(f1_16, V.Undef, ((V)((3D + (ToNum(Call(R_6411, V.Undef)) * 4D)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(Call(R_6411, V.Undef)) - 0.5) * 0.6))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((8D + (ToNum(Call(R_6411, V.Undef)) * 6D)))))), " 0\" stroke=\"#6a3a1c\" stroke-width=\"0.15\" fill=\"none\" opacity=\"0.55\"/>")));
}, 0, "", true)), "join", ((V)("")));
s_6425 = Add(s_6425, Add(Call(shW_6133, V.Undef, C_6410, ((V)(2D)), ((V)(35D)), ((V)(44D)), ((V)(5D)), ((V)(1D)), ((V)(0.3))), Call(box3_4184, V.Undef, C_6410, NewObj(7).Put("c", Arr(((V)(24D)), ((V)(30D)), ((V)(1.4)))).Put("w", ((V)(44D))).Put("h", ((V)(5D))).Put("d", ((V)(2.8))).Put("col", ((V)("#9a5f34"))).Put("r", ((V)(0.5))).Put("dec", NewObj(2).Put("f", ((V)(JsStrBuf.Begin().V(bg_6426).S("<circle cx=\"2.4\" cy=\"2.5\" r=\"0.7\" fill=\"#c9a24a\"/><path d=\"M1.9 2.5h1\" stroke=\"#7a5a1a\" stroke-width=\"0.2\"/><circle cx=\"41.6\" cy=\"2.5\" r=\"0.7\" fill=\"#c9a24a\"/><path d=\"M41.1 2.5h1\" stroke=\"#7a5a1a\" stroke-width=\"0.2\"/>").End()))).Put("t", Invoke(Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis6507, int _argc6501, V _a6503, V _a6504, V _a6505, V _a6506, V[] _rest6502) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6411, V.Undef)) * 32D))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.4 + (ToNum(Call(R_6411, V.Undef)) * 2D)))))), "h", ToStr(Call(f1_16, V.Undef, ((V)((4D + (ToNum(Call(R_6411, V.Undef)) * 6D)))))), "\" stroke=\"#6a3a1c\" stroke-width=\"0.15\" opacity=\"0.55\"/>")));
}, 0, "", true)), "join", ((V)("")))).V).V)));
KN_6427 = Arr(Arr(((V)(5.6)), ((V)(27D)), ((V)("M0 0V-17.6Q0 -20.6 1 -23Q3.4 -19.4 4.4 -13Q4.8 -5 4.6 0Z")), ((V)("M0.3 1.3H4.3L4.1 12.2Q2.3 13.4 0.5 12.2Z")), ((V)("#2a2624")), ((V)("<rect width=\"4.6\" height=\"1.3\" fill=\"#aab2b8\"/><circle cx=\"2.3\" cy=\"4\" r=\"0.42\" fill=\"#dfe3e6\"/><circle cx=\"2.3\" cy=\"7.4\" r=\"0.42\" fill=\"#dfe3e6\"/><circle cx=\"2.3\" cy=\"10.6\" r=\"0.42\" fill=\"#dfe3e6\"/><path d=\"M3.4 -0.4Q3.8 -6 3.5 -12.4Q2.8 -18 1.3 -21.6\" stroke=\"#ffffff\" stroke-width=\"0.3\" fill=\"none\" opacity=\"0.55\"/>"))), Arr(((V)(12.4)), ((V)(27.6)), ((V)("M0 0V-19.6Q0.2 -21.4 1.6 -21.6H3.1V0Z")), ((V)("M0 0.6H3.1V11Q1.55 12 0 11Z")), ((V)("#8a5a30")), ((V)(JsStrBuf.Begin().S("<rect width=\"3.1\" height=\"0.6\" fill=\"#c8ccd0\"/><path d=\"M3.1 -21").V(Invoke(Call(rep_18, V.Undef, ((V)(23D)), Fn((V _arrowThis6514, int _argc6508, V _a6510, V _a6511, V _a6512, V _a6513, V[] _rest6509) => {
return ((V)("q-0.5 0.45 0 0.9"));
}, 0, "", true)), "join", ((V)("")))).S("\" stroke=\"#88929a\" stroke-width=\"0.18\" fill=\"none\"/><path d=\"M0.8 2v8M2 3v7\" stroke=\"#6a4020\" stroke-width=\"0.15\"/>").End()))), Arr(((V)(18.8)), ((V)(27D)), ((V)("M0 0V-13Q0 -15.4 2.4 -15.4Q4 -15.2 4.4 -13V0Z")), ((V)("M0.3 1.2H4.1V11.4Q2.2 12.4 0.3 11.4Z")), ((V)("#d8b07a")), ((V)(JsStrBuf.Begin().S("<rect width=\"4.4\" height=\"1.2\" fill=\"#2a2624\"/>").V(Invoke(Invoke(Arr(((V)((-2.5))), ((V)((-5.5))), ((V)((-8.5))), ((V)((-11.5)))), "map", Fn((V _arrowThis6522, int _argc6515, V y_6521, V _a6518, V _a6519, V _a6520, V[] _rest6516) => {
return ((V)(string.Concat("<ellipse cx=\"3.2\" cy=\"", ToStr(y_6521), "\" rx=\"0.45\" ry=\"0.9\" fill=\"#9aa4ac\" opacity=\"0.6\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M1.2 3v7M2.8 3v7\" stroke=\"#b08a50\" stroke-width=\"0.15\"/>").End()))), Arr(((V)(25.6)), ((V)(28.6)), ((V)("M0 0V-7.6Q0.2 -9.4 2.8 -9.8Q2.9 -5 2.8 0Z")), ((V)("M0 0.2H2.8V7Q1.4 7.8 0 7Z")), ((V)("#c83a2a")), ((V)("<path d=\"M0.5 1v5.4\" stroke=\"#f08070\" stroke-width=\"0.3\" opacity=\"0.6\"/>"))), Arr(((V)(31.2)), ((V)(28.4)), ((V)("M0.2 0L0.9 -10.8Q1.3 -11.4 1.6 -10.8L2 0ZM1.6 0L2.4 -10.2Q2.8 -10.6 3 -10L3.4 0Z")), ((V)("")), ((V)("")), ((V)("<circle cx=\"1.8\" cy=\"0.4\" r=\"0.55\" fill=\"#6a7278\"/><ellipse cx=\"0.6\" cy=\"3.6\" rx=\"1.4\" ry=\"2.4\" fill=\"none\" stroke=\"#e8772a\" stroke-width=\"0.9\"/><ellipse cx=\"3\" cy=\"3.4\" rx=\"1.3\" ry=\"2.2\" fill=\"none\" stroke=\"#e8772a\" stroke-width=\"0.9\"/>"))));
Invoke(KN_6427, "forEach", Fn((V _arrowThis6542, int _argc6523, V _a6525, V _a6526, V _a6527, V _a6528, V[] _rest6524) => {
V x_6531 = default;
V y_6533 = default;
V bl_6535 = default;
V hd_6537 = default;
V hc_6539 = default;
V ex_6541 = default;
{ V _t6529 = ListOf(_a6525);
{ V _t6530 = GetIdx(_t6529, 0D);
x_6531 = _t6530; }
{ V _t6532 = GetIdx(_t6529, 1D);
y_6533 = _t6532; }
{ V _t6534 = GetIdx(_t6529, 2D);
bl_6535 = _t6534; }
{ V _t6536 = GetIdx(_t6529, 3D);
hd_6537 = _t6536; }
{ V _t6538 = GetIdx(_t6529, 4D);
hc_6539 = _t6538; }
{ V _t6540 = GetIdx(_t6529, 5D);
ex_6541 = _t6540; }
}
return (s_6425 = Add(s_6425, Call(WD_4186, V.Undef, C_6410, x_6531, y_6533, ((V)(2.85)), ((V)(string.Concat("<g transform=\"translate(0.45 0.7)\" opacity=\"0.28\" filter=\"url(#m12b1)\"><path d=\"", ToStr(bl_6535), "\" fill=\"#000000\"/>", (Truthy(hd_6537) ? string.Concat("<path d=\"", ToStr(hd_6537), "\" fill=\"#000000\"/>") : ""), "</g><path d=\"", ToStr(bl_6535), "\" fill=\"url(#k24st)\" stroke=\"#6a747c\" stroke-width=\"0.15\"/>", (Truthy(hd_6537) ? string.Concat("<path d=\"", ToStr(hd_6537), "\" fill=\"", ToStr(hc_6539), "\" stroke=\"", ToStr(Call(shade_10, V.Undef, hc_6539, ((V)(0.6)))), "\" stroke-width=\"0.15\"/>") : ""), ToStr(ex_6541)))))));
}, 1, "", true));
s_6425 = Add(s_6425, Add(Add(Call(cyl3_4185, V.Undef, C_6410, Arr(((V)(40.6)), ((V)(12D)), ((V)(3.4))), Arr(((V)(40.6)), ((V)(20D)), ((V)(3.4))), ((V)(0.9)), ((V)("#2a2624")), NewObj(1).Put("n", ((V)(12D))).V), Call(cyl3_4185, V.Undef, C_6410, Arr(((V)(40.6)), ((V)(19.8)), ((V)(3.4))), Arr(((V)(40.6)), ((V)(20.4)), ((V)(3.4))), ((V)(1.4)), ((V)("#b8c0c6")), NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("gloss"))).V)), Call(cyl3_4185, V.Undef, C_6410, Arr(((V)(40.6)), ((V)(20.4)), ((V)(3.4))), Arr(((V)(40.6)), ((V)(44D)), ((V)(3.4))), ((V)(0.55)), ((V)("#8a9098")), NewObj(2).Put("n", ((V)(12D))).Put("mat", ((V)("gloss"))).V)));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(DEF19_4188).S("<defs><linearGradient id=\"k24st\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8e98a0\"/><stop offset=\"0.45\" stop-color=\"#e8edf0\"/><stop offset=\"0.7\" stop-color=\"#c4ccd2\"/><stop offset=\"1\" stop-color=\"#f6f8fa\"/></linearGradient></defs>").End()))).Put("front", s_6425).Put("bb", Invoke(C_6410, "bb", ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_6394;
return default;
}, 1, "", true));
Set(N_70, "copper27", Fn((V _arrowThis6550, int _argc6543, V S_6549, V _a6546, V _a6547, V _a6548, V[] _rest6544) => {
V D_6551 = default;
D_6551 = NewObj(5).Put("w", ((V)(110D))).Put("d", ((V)(22D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(50D))).Put("build", Fn((V _arrowThis6558, int _argc6552, V _a6554, V _a6555, V _a6556, V _a6557, V[] _rest6553) => {
return Arr();
}, 0, "build", true)).V;
Set(D_6551, "fx", Fn((V _arrowThis6566, int _argc6559, V ctx_6565, V _a6562, V _a6563, V _a6564, V[] _rest6560) => {
V C_6567 = default;
V R_6568 = default;
double RY_6569 = 0;
double RZ_6570 = 0;
V IR_6571 = default;
V CU_6572 = default;
V BR_6573 = default;
double HY_6574 = 0;
V mkD_6575 = default;
V capCu_6576 = default;
V PANS_6577 = default;
V s_6578 = default;
C_6567 = Call(camW_4181, V.Undef, ctx_6565);
R_6568 = Call(rng_13, V.Undef, ((V)("copper27")));
RY_6569 = 32D;
RZ_6570 = 7.2;
IR_6571 = ((V)("#2b2724"));
CU_6572 = ((V)("#b8683a"));
BR_6573 = ((V)("#c99a3e"));
HY_6574 = (RY_6569 - 4.3);
Call(ext_4187, V.Undef, C_6567, Arr(Arr(((V)((-55D))), ((V)((RY_6569 + 4D))), ((V)(0D))), Arr(((V)(55D)), ((V)((-5D))), ((V)(0D))), Arr(((V)(55D)), ((V)((-5D))), ((V)(14D)))));
mkD_6575 = Fn((V _arrowThis6585, int _argc6579, V _a6581, V _a6582, V _a6583, V _a6584, V[] _rest6580) => {
return Call(rep_18, V.Undef, ((V)(22D)), Fn((V _arrowThis6592, int _argc6586, V _a6588, V _a6589, V _a6590, V _a6591, V[] _rest6587) => {
double a_6593 = 0;
double d_6594 = 0;
a_6593 = ((ToNum(Call(R_6568, V.Undef)) * 2D) * PI_11);
d_6594 = (System.Math.Sqrt(ToNum(Call(R_6568, V.Undef))) * 0.82);
return Arr(((V)((FdLibm.Cos(a_6593) * d_6594))), ((V)((FdLibm.Sin(a_6593) * d_6594))), ((V)((0.04 + (ToNum(Call(R_6568, V.Undef)) * 0.05)))));
return default;
}, 0, "", true));
}, 0, "", true);
capCu_6576 = Fn((V _arrowThis6602, int _argc6595, V dn_6601, V _a6598, V _a6599, V _a6600, V[] _rest6596) => {
return Fn((V _arrowThis6610, int _argc6603, V cr_6609, V _a6606, V _a6607, V _a6608, V[] _rest6604) => {
return ((V)(JsStrBuf.Begin().S(string.Concat("<circle r=\"", ToStr(Call(f1_16, V.Undef, cr_6609)), "\" fill=\"url(#k44cu)\"/>")).V(Invoke(Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis6618, int _argc6611, V i_6617, V _a6614, V _a6615, V _a6616, V[] _rest6612) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6609) * (0.24 + (ToNum(i_6617) * 0.19))))))), "\" fill=\"none\" stroke=\"", (NumTruthy((ToNum(i_6617) % 2D)) ? "#f6b882" : "#8a4424"), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6609) * 0.014))))), "\" opacity=\"0.45\"/>")));
}, 1, "", true)), "join", ((V)("")))).V(Invoke(Invoke(dn_6601, "map", Fn((V _arrowThis6632, int _argc6619, V _a6621, V _a6622, V _a6623, V _a6624, V[] _rest6620) => {
V x_6627 = default;
V y_6629 = default;
V r_6631 = default;
{ V _t6625 = ListOf(_a6621);
{ V _t6626 = GetIdx(_t6625, 0D);
x_6627 = _t6626; }
{ V _t6628 = GetIdx(_t6625, 1D);
y_6629 = _t6628; }
{ V _t6630 = GetIdx(_t6625, 2D);
r_6631 = _t6630; }
}
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_6627) * ToNum(cr_6609)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(y_6629) * ToNum(cr_6609)))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(r_6631) * ToNum(cr_6609)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(r_6631) * ToNum(cr_6609)) * 0.8))))), "\" fill=\"#7a3a1c\" opacity=\"0.25\"/><ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(x_6627) - (ToNum(r_6631) * 0.5)) * ToNum(cr_6609)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(y_6629) - (ToNum(r_6631) * 0.5)) * ToNum(cr_6609)))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(r_6631) * ToNum(cr_6609)) * 0.6))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(r_6631) * ToNum(cr_6609)) * 0.45))))), "\" fill=\"#ffd0a0\" opacity=\"0.35\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6609) * 0.2))))), "\" fill=\"none\" stroke=\"#7a3a1e\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6609) * 0.016))))), "\" opacity=\"0.6\"/><text y=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6609) * 0.035))))), "\" text-anchor=\"middle\" font-family=\"", ToStr(SERIF_6130), "\" font-size=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6609) * 0.085))))), "\" fill=\"#6a3018\" opacity=\"0.7\">CUIVRE</text>")).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_6609)) * 0.36))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_6609)) * 0.4))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6609) * 0.34))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6609) * 0.15))))), "\" transform=\"rotate(-38 ", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_6609)) * 0.36))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-ToNum(cr_6609)) * 0.4))))), ")\" fill=\"#ffe4c4\" opacity=\"0.4\"/><circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6609) * 0.97))))), "\" fill=\"none\" stroke=\"#6a2e16\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6609) * 0.03))))), "\" opacity=\"0.5\"/>")).End()));
}, 1, "", true);
}, 1, "", true);
PANS_6577 = Arr(Arr(((V)((-40D))), ((V)(9D)), ((V)(3.6)), ((V)(11D)), ((V)(0.8)), ((V)(6.2)), ((V)(0D))), Arr(((V)((-20.5))), ((V)(7D)), ((V)(6D)), ((V)(8D)), ((V)(1D)), ((V)(5.4)), ((V)(1.2))), Arr(((V)((-3.5))), ((V)(6D)), ((V)(5.4)), ((V)(7D)), ((V)(1D)), ((V)(5D)), ((V)(2.1))), Arr(((V)(11D)), ((V)(5D)), ((V)(4.6)), ((V)(6D)), ((V)(1.2)), ((V)(4.6)), ((V)(0.6))), Arr(((V)(23.5)), ((V)(3.4)), ((V)(3.6)), ((V)(7D)), ((V)(1.4)), ((V)(4.2)), ((V)(1.7))));
s_6578 = Call(shW_6133, V.Undef, C_6567, ((V)((-50D))), ((V)((RY_6569 + 1D))), ((V)(100D)), ((V)(2D)), ((V)(1D)), ((V)(0.25)));
Invoke(PANS_6577, "forEach", Fn((V _arrowThis6648, int _argc6633, V _a6635, V _a6636, V _a6637, V _a6638, V[] _rest6634) => {
double cy_6649 = 0;
V x_6641 = default;
V r_6643 = default;
V d_6645 = default;
V Lh_6647 = default;
{ V _t6639 = ListOf(_a6635);
{ V _t6640 = GetIdx(_t6639, 0D);
x_6641 = _t6640; }
{ V _t6642 = GetIdx(_t6639, 1D);
r_6643 = _t6642; }
{ V _t6644 = GetIdx(_t6639, 2D);
d_6645 = _t6644; }
{ V _t6646 = GetIdx(_t6639, 3D);
Lh_6647 = _t6646; }
}
cy_6649 = ((HY_6574 - ToNum(Lh_6647)) - ToNum(r_6643));
s_6578 = Add(s_6578, Call(WD_4186, V.Undef, C_6567, ((V)(((ToNum(x_6641) - ToNum(r_6643)) + 1.4))), ((V)((ToNum(Add(((V)(cy_6649)), r_6643)) - 2.6))), ((V)(0.05)), ((V)(string.Concat("<circle cx=\"", ToStr(r_6643), "\" cy=\"", ToStr(r_6643), "\" r=\"", ToStr(r_6643), "\" fill=\"#000000\" opacity=\"0.2\" filter=\"url(#m10b3)\"/>")))));
return default;
}, 1, "", true));
Invoke(Arr(((V)((-46D))), ((V)(46D))), "forEach", Fn((V _arrowThis6657, int _argc6650, V x_6656, V _a6653, V _a6654, V _a6655, V[] _rest6651) => {
s_6578 = Add(s_6578, Add(Add(Add(Call(cyl3_4185, V.Undef, C_6567, Arr(x_6656, ((V)(RY_6569)), ((V)(0D))), Arr(x_6656, ((V)(RY_6569)), ((V)(0.8))), ((V)(2.2)), IR_6571, NewObj(3).Put("n", ((V)(18D))).Put("capCol", Call(shade_10, V.Undef, IR_6571, ((V)(1.3)))).Put("cap", Fn((V _arrowThis6665, int _argc6658, V cr_6664, V _a6661, V _a6662, V _a6663, V[] _rest6659) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6664) * 0.6))))), "\" fill=\"none\" stroke=\"#4a4440\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cr_6664) * 0.1))))), "\"/>")));
}, 1, "cap", true)).V), Call(cyl3_4185, V.Undef, C_6567, Arr(x_6656, ((V)((RY_6569 - 5.4))), ((V)(0D))), Arr(x_6656, ((V)((RY_6569 - 5.4))), ((V)(0.6))), ((V)(1.1)), IR_6571, NewObj(1).Put("n", ((V)(14D))).V)), Call(line3_4191, V.Undef, C_6567, Arr(Arr(x_6656, ((V)((RY_6569 - 5.4))), ((V)(0.5))), Arr(x_6656, ((V)((RY_6569 - 4.2))), ((V)(2.6))), Arr(x_6656, ((V)((RY_6569 - 2.4))), ((V)(4.6))), Arr(x_6656, ((V)((RY_6569 - 0.8))), ((V)((RZ_6570 - 0.4))))), ((V)(0.45)), IR_6571)), Call(cyl3_4185, V.Undef, C_6567, Arr(x_6656, ((V)(RY_6569)), ((V)(0.8))), Arr(x_6656, ((V)(RY_6569)), ((V)(RZ_6570))), ((V)(0.55)), IR_6571, NewObj(1).Put("n", ((V)(10D))).V)));
return default;
}, 1, "", true));
s_6578 = Add(s_6578, Call(cyl3_4185, V.Undef, C_6567, Arr(((V)((-50D))), ((V)(RY_6569)), ((V)(RZ_6570))), Arr(((V)(50D)), ((V)(RY_6569)), ((V)(RZ_6570))), ((V)(0.85)), IR_6571, NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("gloss"))).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis6673, int _argc6666, V sg_6672, V _a6669, V _a6670, V _a6671, V[] _rest6667) => {
return (s_6578 = Add(s_6578, Add(Call(cyl3_4185, V.Undef, C_6567, Arr(((V)((ToNum(sg_6672) * 50D))), ((V)(RY_6569)), ((V)(RZ_6570))), Arr(((V)((ToNum(sg_6672) * 51D))), ((V)(RY_6569)), ((V)(RZ_6570))), ((V)(1.1)), BR_6573, NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("gloss"))).V), Call(sp3_6128, V.Undef, C_6567, Arr(((V)((ToNum(sg_6672) * 52.3))), ((V)(RY_6569)), ((V)(RZ_6570))), ((V)(1.4)), BR_6573))));
}, 1, "", true));
Invoke(PANS_6577, "forEach", Fn((V _arrowThis6695, int _argc6674, V _a6676, V _a6677, V _a6678, V _a6679, V[] _rest6675) => {
double cy_6696 = 0;
double z0_6697 = 0;
double z1_6698 = 0;
V g_6699 = default;
V x_6682 = default;
V r_6684 = default;
V d_6686 = default;
V Lh_6688 = default;
V a_6690 = default;
V du_6692 = default;
V ph_6694 = default;
{ V _t6680 = ListOf(_a6676);
{ V _t6681 = GetIdx(_t6680, 0D);
x_6682 = _t6681; }
{ V _t6683 = GetIdx(_t6680, 1D);
r_6684 = _t6683; }
{ V _t6685 = GetIdx(_t6680, 2D);
d_6686 = _t6685; }
{ V _t6687 = GetIdx(_t6680, 3D);
Lh_6688 = _t6687; }
{ V _t6689 = GetIdx(_t6680, 4D);
a_6690 = _t6689; }
{ V _t6691 = GetIdx(_t6680, 5D);
du_6692 = _t6691; }
{ V _t6693 = GetIdx(_t6680, 6D);
ph_6694 = _t6693; }
}
cy_6696 = ((HY_6574 - ToNum(Lh_6688)) - ToNum(r_6684));
z0_6697 = (RZ_6570 - (ToNum(d_6686) / 2D));
z1_6698 = (RZ_6570 + (ToNum(d_6686) / 2D));
g_6699 = Add(Add(Add(Add(Add(Call(cyl3_4185, V.Undef, C_6567, Arr(x_6682, ((V)(cy_6696)), ((V)(z0_6697))), Arr(x_6682, ((V)(cy_6696)), ((V)((z0_6697 + 0.7)))), Add(r_6684, ((V)(0.45))), Call(shade_10, V.Undef, CU_6572, ((V)(0.9))), NewObj(2).Put("n", ((V)(30D))).Put("mat", ((V)("gloss"))).V), Call(cyl3_4185, V.Undef, C_6567, Arr(x_6682, ((V)(cy_6696)), ((V)((z0_6697 + 0.7)))), Arr(x_6682, ((V)(cy_6696)), ((V)(z1_6698))), r_6684, CU_6572, NewObj(3).Put("n", ((V)(30D))).Put("mat", ((V)("gloss"))).Put("cap", Call(capCu_6576, V.Undef, Call(mkD_6575, V.Undef))).V)), Invoke(Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis6707, int _argc6700, V sg_6706, V _a6703, V _a6704, V _a6705, V[] _rest6701) => {
return Call(sp3_6128, V.Undef, C_6567, Arr(Add(x_6682, ((V)((ToNum(sg_6706) * 1.1)))), Add(Add(((V)(cy_6696)), r_6684), ((V)(0.1))), ((V)((z0_6697 + 1.5)))), ((V)(0.38)), Call(shade_10, V.Undef, CU_6572, ((V)(1.1))));
}, 1, "", true)), "join", ((V)("")))), Call(line3_4191, V.Undef, C_6567, Arr(Arr(x_6682, ((V)(HY_6574)), ((V)(RZ_6570))), Arr(x_6682, Add(Add(((V)(cy_6696)), r_6684), ((V)(0.4))), ((V)((z0_6697 + 1.5))))), ((V)(1.9)), IR_6571)), Call(line3_4191, V.Undef, C_6567, Arr(Arr(((V)((ToNum(x_6682) - 0.4))), ((V)((HY_6574 - 1.4))), ((V)((RZ_6570 + 0.1)))), Arr(((V)((ToNum(x_6682) - 0.4))), Add(Add(((V)(cy_6696)), r_6684), ((V)(0.9))), ((V)((z0_6697 + 1.6))))), ((V)(0.35)), ((V)("#6a625c")))), Call(WD_4186, V.Undef, C_6567, x_6682, ((V)(HY_6574)), ((V)((RZ_6570 + 0.3))), ((V)("<circle r=\"0.7\" fill=\"#14110f\"/>"))));
s_6578 = Add(s_6578, Call(swayAt_4192, V.Undef, C_6567, Arr(x_6682, ((V)((HY_6574 + 0.4))), ((V)(RZ_6570))), a_6690, du_6692, ph_6694, g_6699));
return default;
}, 1, "", true));
s_6578 = Add(s_6578, Call(swayAt_4192, V.Undef, C_6567, Arr(((V)(33.5)), ((V)((HY_6574 + 0.4))), ((V)(RZ_6570))), ((V)(1.3)), ((V)(4.4)), ((V)(0.9)), Add(Add(Add(Call(line3_4191, V.Undef, C_6567, Arr(Arr(((V)(33.5)), ((V)(HY_6574)), ((V)(RZ_6570))), Arr(((V)(33.5)), ((V)((HY_6574 - 13D))), ((V)((RZ_6570 + 0.8))))), ((V)(1.1)), IR_6571), Call(WD_4186, V.Undef, C_6567, ((V)(33.5)), ((V)(HY_6574)), ((V)((RZ_6570 + 0.2))), ((V)("<circle r=\"0.45\" fill=\"#14110f\"/>")))), Call(sp3_6128, V.Undef, C_6567, Arr(((V)(33.5)), ((V)((HY_6574 - 15.6))), ((V)((RZ_6570 + 1.2)))), ((V)(2.9)), CU_6572)), Call(line3_4191, V.Undef, C_6567, Arr(Arr(((V)(31D)), ((V)((HY_6574 - 14.9))), ((V)((RZ_6570 + 1.4)))), Arr(((V)(36D)), ((V)((HY_6574 - 14.9))), ((V)((RZ_6570 + 1.4))))), ((V)(0.3)), Call(shade_10, V.Undef, CU_6572, ((V)(1.3)))))));
{
double x_6708 = 0;
V g_6709 = default;
x_6708 = 43.5;
g_6709 = Add(Call(WD_4186, V.Undef, C_6567, ((V)(x_6708)), ((V)((HY_6574 - 0.2))), ((V)((RZ_6570 + 0.1))), ((V)(string.Concat("<circle r=\"0.8\" fill=\"none\" stroke=\"", ToStr(BR_6573), "\" stroke-width=\"0.35\"/>")))), Call(cyl3_4185, V.Undef, C_6567, Arr(((V)(x_6708)), ((V)((HY_6574 - 1D))), ((V)(RZ_6570))), Arr(((V)(x_6708)), ((V)((HY_6574 - 8D))), ((V)(RZ_6570))), ((V)(0.62)), BR_6573, NewObj(2).Put("n", ((V)(12D))).Put("mat", ((V)("gloss"))).V));
g_6709 = Add(g_6709, Call(WD_4186, V.Undef, C_6567, ((V)(x_6708)), ((V)((HY_6574 - 8D))), ((V)((RZ_6570 + 0.3))), Invoke(Invoke(Arr(((V)(3.2)), ((V)(2.2)), ((V)(1.1)), ((V)(0.25))), "map", Fn((V _arrowThis6718, int _argc6710, V w_6716, V i_6717, V _a6714, V _a6715, V[] _rest6711) => {
return ((V)(string.Concat("<path d=\"M0 0C", NumStr((-ToNum(w_6716))), " 3.6 ", NumStr((-ToNum(w_6716))), " 9 0 10.4C", ToStr(w_6716), " 9 ", ToStr(w_6716), " 3.6 0 0Z\" fill=\"none\" stroke=\"", (NumTruthy((ToNum(i_6717) % 2D)) ? "#b8bec4" : "#e4e8ec"), "\" stroke-width=\"0.24\"/>")));
}, 2, "", true)), "join", ((V)("")))));
s_6578 = Add(s_6578, Call(swayAt_4192, V.Undef, C_6567, Arr(((V)(x_6708)), ((V)((HY_6574 + 0.4))), ((V)(RZ_6570))), ((V)(1.5)), ((V)(3.9)), ((V)(2.4)), g_6709));
}
Invoke(Arr(((V)((-40D))), ((V)((-20.5))), ((V)((-3.5))), ((V)(11D)), ((V)(23.5)), ((V)(33.5)), ((V)(43.5))), "forEach", Fn((V _arrowThis6726, int _argc6719, V x_6725, V _a6722, V _a6723, V _a6724, V[] _rest6720) => {
return (s_6578 = Add(s_6578, Call(sHook_6134, V.Undef, C_6567, x_6725, ((V)((RY_6569 + 1D))), ((V)((RZ_6570 + 0.95))), ((V)(1D)), ((V)("#3a3532")))));
}, 1, "", true));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(DEF19_4188).S("<defs><radialGradient id=\"k44cu\" cx=\"38%\" cy=\"32%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#f6b886\"/><stop offset=\"0.35\" stop-color=\"#d07a48\"/><stop offset=\"0.75\" stop-color=\"#a85630\"/><stop offset=\"1\" stop-color=\"#7a3a20\"/></radialGradient></defs>").End()))).Put("front", s_6578).Put("bb", Invoke(C_6567, "bb", ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_6551;
return default;
}, 1, "", true));
Set(N_70, "winemap27", Fn((V _arrowThis6734, int _argc6727, V S_6733, V _a6730, V _a6731, V _a6732, V[] _rest6728) => {
V D_6735 = default;
D_6735 = NewObj(5).Put("w", ((V)(112D))).Put("d", ((V)(14D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(50D))).Put("build", Fn((V _arrowThis6742, int _argc6736, V _a6738, V _a6739, V _a6740, V _a6741, V[] _rest6737) => {
return Arr();
}, 0, "build", true)).V;
Set(D_6735, "fx", Fn((V _arrowThis6750, int _argc6743, V ctx_6749, V _a6746, V _a6747, V _a6748, V[] _rest6744) => {
V C_6751 = default;
V R_6752 = default;
V BR_6753 = default;
double FW_6754 = 0;
double FH_6755 = 0;
double Y0_6756 = 0;
double RY_6757 = 0;
double RZ_6758 = 0;
double HY_6759 = 0;
V mapArt_6760 = default;
JsStrBuf s_6761 = null;
C_6751 = Call(camW_4181, V.Undef, ctx_6749);
R_6752 = Call(rng_13, V.Undef, ((V)("winemap27")));
BR_6753 = ((V)("#c99a3e"));
FW_6754 = 42D;
FH_6755 = 30D;
Y0_6756 = 16D;
RY_6757 = 9D;
RZ_6758 = 4.2;
HY_6759 = (RY_6757 - 2.5);
Call(ext_4187, V.Undef, C_6751, Arr(Arr(((V)((-54D))), ((V)(((Y0_6756 + FH_6755) + 7D))), ((V)(0D))), Arr(((V)(54D)), ((V)((-14D))), ((V)(0D))), Arr(((V)(54D)), ((V)((-14D))), ((V)(8D)))));
mapArt_6760 = Fn((V _arrowThis6769, int _argc6762, V kd_6768, V _a6765, V _a6766, V _a6767, V[] _rest6763) => {
double W2_6770 = 0;
double H2_6771 = 0;
JsStrBuf m_6772 = null;
V vil_6773 = default;
V parc_6774 = default;
V PC_6775 = default;
V cart_6776 = default;
V rose_6777 = default;
W2_6770 = 28.4;
H2_6771 = 18D;
m_6772 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<rect width=\"", NumStr(W2_6770), "\" height=\"", NumStr(H2_6771), "\" fill=\"#ead8ae\"/>")).V(Invoke(Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis6784, int _argc6778, V _a6780, V _a6781, V _a6782, V _a6783, V[] _rest6779) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6752, V.Undef)) * W2_6770))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6752, V.Undef)) * H2_6771))))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.15 + (ToNum(Call(R_6752, V.Undef)) * 0.45)))))), "\" fill=\"#c09a5e\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.15 + (ToNum(Call(R_6752, V.Undef)) * 0.25)))))), "\"/>")));
}, 0, "", true)), "join", ((V)("")))).End());
vil_6773 = Fn((V _arrowThis6795, int _argc6785, V x_6791, V y_6792, V n_6793, V e_6794, V[] _rest6786) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(x_6791), "\" cy=\"", ToStr(y_6792), "\" r=\"0.32\" fill=\"#5a3a22\"/><text x=\"", ToStr(Call(f1_16, V.Undef, Add(x_6791, ((V)((Truthy(e_6794) ? (-0.6) : 0.6)))))), "\" y=\"", ToStr(Call(f1_16, V.Undef, Add(y_6792, ((V)(0.3))))), "\" text-anchor=\"", (Truthy(e_6794) ? "end" : "start"), "\" font-family=\"", ToStr(SERIF_6130), "\" font-style=\"italic\" font-size=\"0.85\" fill=\"#4a3020\">", ToStr(n_6793), "</text>")));
}, 4, "", true);
parc_6774 = Fn((V _arrowThis6808, int _argc6796, V x_6802, V y_6803, V w_6804, V h_6805, V[] _rest6797) => {
V r_6806 = default;
V c_6807 = default;
r_6806 = (_argc6796 > 4 ? _rest6797[0] : V.Undef);
c_6807 = (_argc6796 > 5 ? _rest6797[1] : V.Undef);
return ((V)(string.Concat("<g transform=\"rotate(", ToStr(r_6806), " ", ToStr(x_6802), " ", ToStr(y_6803), ")\"><rect x=\"", ToStr(x_6802), "\" y=\"", ToStr(y_6803), "\" width=\"", ToStr(w_6804), "\" height=\"", ToStr(h_6805), "\" fill=\"", ToStr(c_6807), "\" opacity=\"0.75\"/><rect x=\"", ToStr(x_6802), "\" y=\"", ToStr(y_6803), "\" width=\"", ToStr(w_6804), "\" height=\"", ToStr(h_6805), "\" fill=\"url(#k64h)\"/><rect x=\"", ToStr(x_6802), "\" y=\"", ToStr(y_6803), "\" width=\"", ToStr(w_6804), "\" height=\"", ToStr(h_6805), "\" fill=\"none\" stroke=\"#6a5030\" stroke-width=\"0.08\"/></g>")));
}, 6, "", true);
PC_6775 = Arr(((V)("#b4a06a")), ((V)("#a6ae78")), ((V)("#c49a7a")), ((V)("#b8946a")));
cart_6776 = Fn((V _arrowThis6818, int _argc6809, V x_6815, V t_6816, V sub_6817, V _a6814, V[] _rest6810) => {
return ((V)(string.Concat("<rect x=\"", ToStr(x_6815), "\" y=\"1\" width=\"11.4\" height=\"5\" fill=\"#f2e4c0\" stroke=\"#6a4a2a\" stroke-width=\"0.2\"/><rect x=\"", ToStr(Call(f1_16, V.Undef, Add(x_6815, ((V)(0.4))))), "\" y=\"1.4\" width=\"10.6\" height=\"4.2\" fill=\"none\" stroke=\"#6a4a2a\" stroke-width=\"0.1\"/><text x=\"", ToStr(Call(f1_16, V.Undef, Add(x_6815, ((V)(5.7))))), "\" y=\"3.5\" text-anchor=\"middle\" font-family=\"", ToStr(SERIF_6130), "\" font-style=\"italic\" font-weight=\"700\" font-size=\"1.6\" fill=\"#5a2a1e\">", ToStr(t_6816), "</text><text x=\"", ToStr(Call(f1_16, V.Undef, Add(x_6815, ((V)(5.7))))), "\" y=\"4.9\" text-anchor=\"middle\" font-family=\"", ToStr(SERIF_6130), "\" font-size=\"0.7\" fill=\"#5a3a22\" letter-spacing=\"0.08\">", ToStr(sub_6817), "</text>")));
}, 3, "", true);
rose_6777 = Fn((V _arrowThis6827, int _argc6819, V x_6825, V y_6826, V _a6823, V _a6824, V[] _rest6820) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(x_6825), " ", ToStr(y_6826), ")\"><circle r=\"1.3\" fill=\"none\" stroke=\"#5a3a22\" stroke-width=\"0.1\"/><path d=\"M0 -2L0.4 -0.4L2 0L0.4 0.4L0 2L-0.4 0.4L-2 0L-0.4 -0.4Z\" fill=\"#5a3a22\"/><path d=\"M0 -2L0.4 -0.4L0 0ZM2 0L0.4 0.4L0 0ZM0 2L-0.4 0.4L0 0ZM-2 0L-0.4 -0.4L0 0Z\" fill=\"#f2e4c0\"/><text y=\"-2.3\" text-anchor=\"middle\" font-family=\"", ToStr(SERIF_6130), "\" font-size=\"0.7\" fill=\"#5a3a22\">N</text></g>")));
}, 2, "", true);
if (SEqS(kd_6768, "bdx")) {
m_6772.V(Invoke(Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis6835, int _argc6828, V i_6834, V _a6831, V _a6832, V _a6833, V[] _rest6829) => {
return ((V)(string.Concat("<path d=\"M0 ", ToStr(Call(f1_16, V.Undef, ((V)((1D + (ToNum(i_6834) * 1.8)))))), "h", ToStr(Call(f1_16, V.Undef, ((V)((1.4 + (ToNum(Call(R_6752, V.Undef)) * 1.6)))))), "\" stroke=\"#7a9aa0\" stroke-width=\"0.18\" opacity=\"0.6\"/>")));
}, 1, "", true)), "join", ((V)(""))));
Invoke(Arr(Arr(((V)(5.4)), ((V)(4.6)), ((V)(2D)), ((V)(1.1)), ((V)(30D))), Arr(((V)(7.6)), ((V)(6D)), ((V)(2.2)), ((V)(1D)), ((V)(36D))), Arr(((V)(9.4)), ((V)(8D)), ((V)(1.8)), ((V)(1.2)), ((V)(42D))), Arr(((V)(12.4)), ((V)(8.4)), ((V)(2D)), ((V)(1D)), ((V)(38D))), Arr(((V)(13.8)), ((V)(10.6)), ((V)(2.2)), ((V)(1.1)), ((V)(30D))), Arr(((V)(16.4)), ((V)(11.8)), ((V)(1.8)), ((V)(1D)), ((V)(28D))), Arr(((V)(10D)), ((V)(11.2)), ((V)(2D)), ((V)(1D)), ((V)(40D))), Arr(((V)(17.6)), ((V)(15.6)), ((V)(2.2)), ((V)(1.2)), ((V)(10D))), Arr(((V)(22.4)), ((V)(12.4)), ((V)(2D)), ((V)(1.1)), ((V)((-10D)))), Arr(((V)(25D)), ((V)(13.2)), ((V)(2.2)), ((V)(1D)), ((V)((-6D)))), Arr(((V)(23D)), ((V)(16.6)), ((V)(2D)), ((V)(1D)), ((V)(4D))), Arr(((V)(19.6)), ((V)(9.6)), ((V)(1.8)), ((V)(1D)), ((V)(32D)))), "forEach", Fn((V _arrowThis6854, int _argc6836, V _a6838, V i_6842, V _a6840, V _a6841, V[] _rest6837) => {
V x_6845 = default;
V y_6847 = default;
V w_6849 = default;
V h_6851 = default;
V r_6853 = default;
{ V _t6843 = ListOf(_a6838);
{ V _t6844 = GetIdx(_t6843, 0D);
x_6845 = _t6844; }
{ V _t6846 = GetIdx(_t6843, 1D);
y_6847 = _t6846; }
{ V _t6848 = GetIdx(_t6843, 2D);
w_6849 = _t6848; }
{ V _t6850 = GetIdx(_t6843, 3D);
h_6851 = _t6850; }
{ V _t6852 = GetIdx(_t6843, 4D);
r_6853 = _t6852; }
}
return ((V)(m_6772.V(Call(parc_6774, V.Undef, x_6845, y_6847, w_6849, h_6851, r_6853, GetIdx(PC_6775, (ToNum(i_6842) % 4D)))).Str));
}, 2, "", true));
m_6772.S("<path d=\"M0 2.4C4 3.6 8 5.4 11 8.6C13.4 11 16.4 12.6 19.6 14.4\" stroke=\"#9ab2b2\" stroke-width=\"1.8\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M19.6 14.4C22 15.4 25 15.8 28.4 16.4M19.6 14.4C20.6 15.8 21.2 16.8 21.6 18\" stroke=\"#9ab2b2\" stroke-width=\"0.8\" fill=\"none\"/><path d=\"M0 2.4C4 3.6 8 5.4 11 8.6C13.4 11 16.4 12.6 19.6 14.4\" stroke=\"#6a8a90\" stroke-width=\"0.12\" fill=\"none\" opacity=\"0.6\"/>");
m_6772.V(Add(Add(Add(Add(Add(Add(Call(vil_6773, V.Undef, ((V)(6.4)), ((V)(4D)), ((V)("St-Est\u00e8phe"))), Call(vil_6773, V.Undef, ((V)(8.8)), ((V)(7.2)), ((V)("Pauillac")))), Call(vil_6773, V.Undef, ((V)(13.4)), ((V)(12.6)), ((V)("Margaux")), ((V)(1D)))), Call(vil_6773, V.Undef, ((V)(17.4)), ((V)(17.2)), ((V)("Pessac")), ((V)(1D)))), Call(vil_6773, V.Undef, ((V)(23.4)), ((V)(12D)), ((V)("St-\u00c9milion")))), Call(cart_6776, V.Undef, ((V)(16.2)), ((V)("Bordeaux")), ((V)("CARTE DES VIGNOBLES")))), Call(rose_6777, V.Undef, ((V)(3.6)), ((V)(15D)))));
} else {
m_6772.V(Invoke(Call(rep_18, V.Undef, ((V)(26D)), Fn((V _arrowThis6861, int _argc6855, V _a6857, V _a6858, V _a6859, V _a6860, V[] _rest6856) => {
double x_6862 = 0;
double y_6863 = 0;
x_6862 = (1D + (ToNum(Call(R_6752, V.Undef)) * 9D));
y_6863 = (7D + (ToNum(Call(R_6752, V.Undef)) * 10D));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)(x_6862)))), " ", ToStr(Call(f1_16, V.Undef, ((V)(y_6863)))), "l", ToStr(Call(f1_16, V.Undef, ((V)((0.4 + (ToNum(Call(R_6752, V.Undef)) * 0.4)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.8) - (ToNum(Call(R_6752, V.Undef)) * 0.4)))))), "\" stroke=\"#8a6a44\" stroke-width=\"0.12\" opacity=\"0.55\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
m_6772.S("<path d=\"M28.4 4C26 7 27.6 10 25.6 13C24 15.6 25.4 17 24.6 18\" stroke=\"#9ab2b2\" stroke-width=\"0.9\" fill=\"none\"/><path d=\"M24 1C21 5 17 8.4 13.6 11.4C11 13.6 8 15.6 5 17.6\" stroke=\"#8a5a3a\" stroke-width=\"0.3\" stroke-dasharray=\"0.8 0.4\" fill=\"none\"/>");
Call(rep_18, V.Undef, ((V)(12D)), Fn((V _arrowThis6871, int _argc6864, V i_6870, V _a6867, V _a6868, V _a6869, V[] _rest6865) => {
double t_6872 = 0;
double x_6873 = 0;
double y_6874 = 0;
t_6872 = (ToNum(i_6870) / 11D);
x_6873 = ((24D - (19D * t_6872)) + 1.2);
y_6874 = (1.4 + (16D * t_6872));
m_6772.V(Call(parc_6774, V.Undef, Call(f1_16, V.Undef, ((V)(x_6873))), Call(f1_16, V.Undef, ((V)(y_6874))), ((V)(2.4)), ((V)(1.1)), ((V)((-38D))), GetIdx(PC_6775, (ToNum(i_6870) % 4D))));
return default;
}, 1, "", true));
m_6772.V(Add(Add(Add(Add(Add(Call(vil_6773, V.Undef, ((V)(21.4)), ((V)(3.8)), ((V)("Gevrey")), ((V)(1D))), Call(vil_6773, V.Undef, ((V)(17.2)), ((V)(7.6)), ((V)("Nuits")), ((V)(1D)))), Call(vil_6773, V.Undef, ((V)(12.4)), ((V)(11.8)), ((V)("Beaune")), ((V)(1D)))), Call(vil_6773, V.Undef, ((V)(8.8)), ((V)(15D)), ((V)("Meursault")), ((V)(1D)))), Call(cart_6776, V.Undef, ((V)(1D)), ((V)("Bourgogne")), ((V)("C\u00d4TE D'OR")))), Call(rose_6777, V.Undef, ((V)(26.2)), ((V)(2.8)))));
}
return ((V)(string.Concat(m_6772.Str, string.Concat("<rect width=\"", NumStr(W2_6770), "\" height=\"", NumStr(H2_6771), "\" fill=\"url(#k64v)\"/><rect width=\"", NumStr(W2_6770), "\" height=\"", NumStr(H2_6771), "\" fill=\"none\" stroke=\"#6a4a2a\" stroke-width=\"0.25\"/>"))));
return default;
}, 1, "", true);
s_6761 = new JsStrBuf("");
Invoke(Arr(((V)((-25D))), ((V)(25D))), "forEach", Fn((V _arrowThis6883, int _argc6875, V cx_6881, V j_6882, V _a6879, V _a6880, V[] _rest6876) => {
double LY_6884 = 0;
V grain_6885 = default;
V face_6886 = default;
LY_6884 = ((Y0_6756 + FH_6755) + 3.6);
s_6761.V(Call(WD_4186, V.Undef, C_6751, ((V)(((ToNum(cx_6881) - (FW_6754 / 2D)) - 8D))), ((V)(((Y0_6756 + FH_6755) + 6D))), ((V)(0.04)), ((V)(string.Concat("<ellipse cx=\"", NumStr(((FW_6754 / 2D) + 8D)), "\" cy=\"14\" rx=\"", NumStr(((FW_6754 / 2D) + 5D)), "\" ry=\"16\" fill=\"#ffd890\" opacity=\"0.18\" filter=\"url(#m11b8)\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.14;0.24;0.14")), ((V)(9D)), ((V)((ToNum(j_6882) * 2D))), Call(SPL_15, V.Undef, ((V)(2D))))), "</ellipse>")))));
s_6761.V(Call(shW_6133, V.Undef, C_6751, ((V)((ToNum(cx_6881) - (FW_6754 / 2D)))), ((V)((Y0_6756 + FH_6755))), ((V)(FW_6754)), ((V)(FH_6755)), ((V)(0.6)), ((V)(0.38))));
grain_6885 = Invoke(Call(rep_18, V.Undef, ((V)(18D)), Fn((V _arrowThis6893, int _argc6887, V _a6889, V _a6890, V _a6891, V _a6892, V[] _rest6888) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6752, V.Undef)) * (FW_6754 - 8D)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6752, V.Undef)) * FH_6755))))), "h", ToStr(Call(f1_16, V.Undef, ((V)((2D + (ToNum(Call(R_6752, V.Undef)) * 6D)))))), "\" stroke=\"#2e1a0e\" stroke-width=\"0.18\" opacity=\"0.5\"/>")));
}, 0, "", true)), "join", ((V)("")));
face_6886 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect width=\"", NumStr(FW_6754), "\" height=\"", NumStr(FH_6755), "\" fill=\"url(#k64w)\"/>", ToStr(grain_6885), "<path d=\"M0 0L2.2 2.2M", NumStr(FW_6754), " 0L", NumStr((FW_6754 - 2.2)), " 2.2M0 ", NumStr(FH_6755), "L2.2 ", NumStr((FH_6755 - 2.2)), "M", NumStr(FW_6754), " ", NumStr(FH_6755), "L", NumStr((FW_6754 - 2.2)), " ", NumStr((FH_6755 - 2.2)), "\" stroke=\"#1e1008\" stroke-width=\"0.2\"/><rect x=\"0.25\" y=\"0.25\" width=\"", NumStr((FW_6754 - 0.5)), "\" height=\"", NumStr((FH_6755 - 0.5)), "\" fill=\"none\" stroke=\"#7a5236\" stroke-width=\"0.3\"/>")).S(string.Concat("<rect x=\"2.2\" y=\"2.2\" width=\"", NumStr((FW_6754 - 4.4)), "\" height=\"", NumStr((FH_6755 - 4.4)), "\" fill=\"none\" stroke=\"url(#k64g)\" stroke-width=\"0.9\"/><rect x=\"2.65\" y=\"2.65\" width=\"", NumStr((FW_6754 - 5.3)), "\" height=\"", NumStr((FH_6755 - 5.3)), "\" fill=\"#efe6d2\"/>")).V(Invoke(Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis6901, int _argc6894, V i_6900, V _a6897, V _a6898, V _a6899, V[] _rest6895) => {
return ((V)(string.Concat("<path d=\"M2.7 ", ToStr(Call(f1_16, V.Undef, ((V)((3D + (ToNum(i_6900) * 1.55)))))), "H", NumStr((FW_6754 - 2.7)), "\" stroke=\"#d8ccb2\" stroke-width=\"0.08\" opacity=\"0.45\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<rect x=\"6.3\" y=\"5.7\" width=\"29.4\" height=\"18.6\" fill=\"#fbf6ea\"/><g transform=\"translate(6.8 6.2)\">", ToStr(Call(mapArt_6760, V.Undef, ((V)((Truthy(j_6882) ? "bgn" : "bdx"))))), "</g><path d=\"M2.65 2.65H14L6 27.35H2.65Z\" fill=\"#ffffff\" opacity=\"0.07\"/><path d=\"M17 2.65H20L12 27.35H9Z\" fill=\"#ffffff\" opacity=\"0.05\"/>")).End()));
s_6761.V(Call(box3_4184, V.Undef, C_6751, NewObj(7).Put("c", Arr(cx_6881, ((V)(Y0_6756)), ((V)(1.3)))).Put("w", ((V)(FW_6754))).Put("h", ((V)(FH_6755))).Put("d", ((V)(2.6))).Put("col", ((V)("#4a2a18"))).Put("r", ((V)(0.3))).Put("dec", NewObj(2).Put("f", face_6886).Put("t", Invoke(Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis6908, int _argc6902, V _a6904, V _a6905, V _a6906, V _a6907, V[] _rest6903) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_6752, V.Undef)) * 32D))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.4 + (ToNum(Call(R_6752, V.Undef)) * 1.8)))))), "h", ToStr(Call(f1_16, V.Undef, ((V)((3D + (ToNum(Call(R_6752, V.Undef)) * 5D)))))), "\" stroke=\"#2e1a0e\" stroke-width=\"0.18\" opacity=\"0.5\"/>")));
}, 0, "", true)), "join", ((V)("")))).V).V));
s_6761.V(Call(WD_4186, V.Undef, C_6751, ((V)((ToNum(cx_6881) - (FW_6754 / 2D)))), ((V)(((Y0_6756 + FH_6755) + 0.2))), ((V)(2.65)), ((V)(string.Concat("<path d=\"M9 0H", NumStr((FW_6754 - 9D)), "L", NumStr(FW_6754), " ", NumStr(FH_6755), "H0Z\" fill=\"url(#k64l)\" opacity=\"0.5\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.42;0.58;0.42")), ((V)(9D)), ((V)((ToNum(j_6882) * 2D))), Call(SPL_15, V.Undef, ((V)(2D))))), "</path>")))));
s_6761.V(Add(Add(Add(Call(cyl3_4185, V.Undef, C_6751, Arr(cx_6881, ((V)((LY_6884 + 1D))), ((V)(0D))), Arr(cx_6881, ((V)((LY_6884 + 1D))), ((V)(0.6))), ((V)(1.5)), BR_6753, NewObj(2).Put("n", ((V)(16D))).Put("mat", ((V)("gloss"))).V), Call(line3_4191, V.Undef, C_6751, Arr(Arr(cx_6881, ((V)((LY_6884 + 1D))), ((V)(0.6))), Arr(cx_6881, ((V)((LY_6884 + 2.4))), ((V)(2.2))), Arr(cx_6881, ((V)((LY_6884 + 1.4))), ((V)(4.2)))), ((V)(0.55)), Call(shade_10, V.Undef, BR_6753, ((V)(0.85))))), Call(cyl3_4185, V.Undef, C_6751, Arr(((V)((ToNum(cx_6881) - 10D))), ((V)(LY_6884)), ((V)(4.6))), Arr(Add(cx_6881, ((V)(10D))), ((V)(LY_6884)), ((V)(4.6))), ((V)(1.25)), BR_6753, NewObj(3).Put("n", ((V)(16D))).Put("mat", ((V)("gloss"))).Put("capCol", Call(shade_10, V.Undef, BR_6753, ((V)(1.1)))).V)), Call(line3_4191, V.Undef, C_6751, Arr(Arr(((V)((ToNum(cx_6881) - 9.4))), ((V)((LY_6884 - 1D))), ((V)(5.35))), Arr(Add(cx_6881, ((V)(9.4))), ((V)((LY_6884 - 1D))), ((V)(5.35)))), ((V)(0.4)), ((V)("#fff2c4")), ((V)("opacity=\"0.9\"")))));
return default;
}, 2, "", true));
s_6761.V(Call(shW_6133, V.Undef, C_6751, ((V)((-48D))), ((V)((RY_6757 + 1D))), ((V)(96D)), ((V)(2D)), ((V)(1D)), ((V)(0.25))));
Invoke(Arr(((V)((-40D))), ((V)(40D))), "forEach", Fn((V _arrowThis6916, int _argc6909, V x_6915, V _a6912, V _a6913, V _a6914, V[] _rest6910) => {
return ((V)(s_6761.V(Add(Call(cyl3_4185, V.Undef, C_6751, Arr(x_6915, ((V)(RY_6757)), ((V)(0D))), Arr(x_6915, ((V)(RY_6757)), ((V)(0.6))), ((V)(1.4)), BR_6753, NewObj(2).Put("n", ((V)(16D))).Put("mat", ((V)("gloss"))).V), Call(cyl3_4185, V.Undef, C_6751, Arr(x_6915, ((V)(RY_6757)), ((V)(0.6))), Arr(x_6915, ((V)(RY_6757)), ((V)(RZ_6758))), ((V)(0.4)), BR_6753, NewObj(1).Put("n", ((V)(10D))).V))).Str));
}, 1, "", true));
s_6761.V(Call(cyl3_4185, V.Undef, C_6751, Arr(((V)((-48D))), ((V)(RY_6757)), ((V)(RZ_6758))), Arr(((V)(48D)), ((V)(RY_6757)), ((V)(RZ_6758))), ((V)(0.7)), BR_6753, NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("gloss"))).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis6924, int _argc6917, V sg_6923, V _a6920, V _a6921, V _a6922, V[] _rest6918) => {
return ((V)(s_6761.V(Add(Call(cyl3_4185, V.Undef, C_6751, Arr(((V)((ToNum(sg_6923) * 48D))), ((V)(RY_6757)), ((V)(RZ_6758))), Arr(((V)((ToNum(sg_6923) * 48.8))), ((V)(RY_6757)), ((V)(RZ_6758))), ((V)(1D)), BR_6753, NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("gloss"))).V), Call(sp3_6128, V.Undef, C_6751, Arr(((V)((ToNum(sg_6923) * 49.9))), ((V)(RY_6757)), ((V)(RZ_6758))), ((V)(1.1)), BR_6753))).Str));
}, 1, "", true));
Invoke(Arr(((V)("ladle")), ((V)("skim")), ((V)("slot")), ((V)("whisk")), ((V)("fish")), ((V)("fork")), ((V)("brush"))), "forEach", Fn((V _arrowThis6933, int _argc6925, V u_6931, V i_6932, V _a6929, V _a6930, V[] _rest6926) => {
double x_6934 = 0;
double y1_6935 = 0;
double zH_6936 = 0;
V g_6937 = default;
V nk_6938 = default;
x_6934 = ((-39D) + (ToNum(i_6932) * 13D));
y1_6935 = (HY_6759 - 8.8);
zH_6936 = (RZ_6758 + 0.6);
g_6937 = Add(Add(Add(Call(WD_4186, V.Undef, C_6751, ((V)(x_6934)), ((V)(HY_6759)), ((V)((RZ_6758 + 0.2))), ((V)(string.Concat("<circle r=\"0.75\" fill=\"none\" stroke=\"", ToStr(BR_6753), "\" stroke-width=\"0.32\"/>")))), Call(line3_4191, V.Undef, C_6751, Arr(Arr(((V)(x_6934)), ((V)((HY_6759 - 0.6))), ((V)(RZ_6758))), Arr(((V)(x_6934)), ((V)((HY_6759 - 7.6))), ((V)((RZ_6758 + 0.25))))), ((V)(1.35)), ((V)("#8a6438")))), Call(line3_4191, V.Undef, C_6751, Arr(Arr(((V)((x_6934 - 0.32))), ((V)((HY_6759 - 1D))), ((V)((RZ_6758 + 0.1)))), Arr(((V)((x_6934 - 0.32))), ((V)((HY_6759 - 7.2))), ((V)((RZ_6758 + 0.35))))), ((V)(0.35)), ((V)("#c8a070")), ((V)("opacity=\"0.8\"")))), Call(cyl3_4185, V.Undef, C_6751, Arr(((V)(x_6934)), ((V)((HY_6759 - 7.6))), ((V)((RZ_6758 + 0.25)))), Arr(((V)(x_6934)), ((V)(y1_6935)), ((V)((RZ_6758 + 0.3)))), ((V)((SEqS(u_6931, "brush") ? 1.05 : 0.78))), BR_6753, NewObj(2).Put("n", ((V)(12D))).Put("mat", ((V)("gloss"))).V));
nk_6938 = Fn((V _arrowThis6946, int _argc6939, V L_6945, V _a6942, V _a6943, V _a6944, V[] _rest6940) => {
return Add(Call(line3_4191, V.Undef, C_6751, Arr(Arr(((V)(x_6934)), ((V)(y1_6935)), ((V)((RZ_6758 + 0.3)))), Arr(((V)(x_6934)), ((V)((y1_6935 - ToNum(L_6945)))), ((V)(zH_6936)))), ((V)(0.55)), Call(shade_10, V.Undef, BR_6753, ((V)(0.9)))), Call(line3_4191, V.Undef, C_6751, Arr(Arr(((V)((x_6934 - 0.12))), ((V)(y1_6935)), ((V)((RZ_6758 + 0.35)))), Arr(((V)((x_6934 - 0.12))), ((V)((y1_6935 - ToNum(L_6945)))), ((V)(zH_6936)))), ((V)(0.15)), ((V)("#fff0c0")), ((V)("opacity=\"0.7\""))));
}, 1, "", true);
if (SEqS(u_6931, "ladle")) {
g_6937 = Add(g_6937, Add(Add(Call(nk_6938, V.Undef, ((V)(4.4))), Call(sp3_6128, V.Undef, C_6751, Arr(((V)(x_6934)), ((V)((y1_6935 - 6.8))), ((V)((RZ_6758 + 1.2)))), ((V)(2.5)), BR_6753)), Call(line3_4191, V.Undef, C_6751, Arr(Arr(((V)((x_6934 - 2.2))), ((V)((y1_6935 - 6.2))), ((V)((RZ_6758 + 1.4)))), Arr(((V)((x_6934 + 2.2))), ((V)((y1_6935 - 6.2))), ((V)((RZ_6758 + 1.4))))), ((V)(0.25)), ((V)("#fff0c0")))));
} else {
if (SEqS(u_6931, "skim")) {
double r_6947 = 0;
JsStrBuf m_6948 = null;
g_6937 = Add(g_6937, Call(nk_6938, V.Undef, ((V)(4D))));
r_6947 = 3.1;
m_6948 = new JsStrBuf("");
{
double q_6949 = 0;
q_6949 = (-2.4);
while (true) {
if (!((q_6949 <= 2.41))) break;
double h_6951 = 0;
h_6951 = System.Math.Sqrt(((r_6947 * r_6947) - (q_6949 * q_6949)));
m_6948.S(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)(q_6949)))), " ", ToStr(Call(f1_16, V.Undef, ((V)((-h_6951))))), "V", ToStr(Call(f1_16, V.Undef, ((V)(h_6951)))), "M", ToStr(Call(f1_16, V.Undef, ((V)((-h_6951))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(q_6949)))), "H", ToStr(Call(f1_16, V.Undef, ((V)(h_6951)))), "\" stroke=\"", ToStr(BR_6753), "\" stroke-width=\"0.14\"/>"));
q_6949 = (q_6949 + 0.8);
}
}
g_6937 = Add(g_6937, Call(WD_4186, V.Undef, C_6751, ((V)(x_6934)), ((V)(((y1_6935 - 4D) - r_6947))), ((V)(zH_6936)), ((V)(string.Concat("<circle r=\"", NumStr(r_6947), "\" fill=\"#2a1a0c\" opacity=\"0.15\"/>", m_6948.Str, "<circle r=\"", NumStr(r_6947), "\" fill=\"none\" stroke=\"url(#k64b)\" stroke-width=\"0.55\"/>")))));
} else {
if (SEqS(u_6931, "slot")) {
g_6937 = Add(g_6937, Add(Call(nk_6938, V.Undef, ((V)(3.4))), Call(WD_4186, V.Undef, C_6751, ((V)(x_6934)), ((V)((y1_6935 - 6.6))), ((V)(zH_6936)), ((V)(string.Concat("<ellipse rx=\"2.3\" ry=\"3.3\" fill=\"url(#k64b)\" stroke=\"#8a6420\" stroke-width=\"0.2\"/>", ToStr(Invoke(Invoke(Arr(((V)((-1.1))), ((V)(0D)), ((V)(1.1))), "map", Fn((V _arrowThis6959, int _argc6952, V sx_6958, V _a6955, V _a6956, V _a6957, V[] _rest6953) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(sx_6958) - 0.25))))), "\" y=\"-1.8\" width=\"0.5\" height=\"3.2\" rx=\"0.25\" fill=\"#3a2810\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<ellipse cx=\"-0.9\" cy=\"-1.8\" rx=\"0.6\" ry=\"1\" fill=\"#ffffff\" opacity=\"0.35\"/>"))))));
} else {
if (SEqS(u_6931, "whisk")) {
g_6937 = Add(g_6937, Call(WD_4186, V.Undef, C_6751, ((V)(x_6934)), ((V)(y1_6935)), ((V)(zH_6936)), Invoke(Invoke(Arr(((V)(2.6)), ((V)(1.8)), ((V)(0.9)), ((V)(0.2))), "map", Fn((V _arrowThis6968, int _argc6960, V w_6966, V j_6967, V _a6964, V _a6965, V[] _rest6961) => {
return ((V)(string.Concat("<path d=\"M0 0C", NumStr((-ToNum(w_6966))), " 3 ", NumStr((-ToNum(w_6966))), " 7.6 0 8.8C", ToStr(w_6966), " 7.6 ", ToStr(w_6966), " 3 0 0Z\" fill=\"none\" stroke=\"", (NumTruthy((ToNum(j_6967) % 2D)) ? "#b8bec4" : "#e4e8ec"), "\" stroke-width=\"0.22\"/>")));
}, 2, "", true)), "join", ((V)("")))));
} else {
if (SEqS(u_6931, "fish")) {
g_6937 = Add(g_6937, Add(Call(nk_6938, V.Undef, ((V)(3D))), Call(WD_4186, V.Undef, C_6751, ((V)(x_6934)), ((V)((y1_6935 - 3D))), ((V)(zH_6936)), ((V)(string.Concat("<path d=\"M-1.4 0H1.4L2.8 8.2Q0 9.2 -2.8 8.2Z\" fill=\"url(#k64b)\" stroke=\"#8a6420\" stroke-width=\"0.2\"/>", ToStr(Invoke(Invoke(Arr(((V)((-1.2))), ((V)((-0.4))), ((V)(0.4)), ((V)(1.2))), "map", Fn((V _arrowThis6976, int _argc6969, V sx_6975, V _a6972, V _a6973, V _a6974, V[] _rest6970) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(sx_6975) * 0.8))))), " 1.6L", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(sx_6975) * 1.3))))), " 7\" stroke=\"#3a2810\" stroke-width=\"0.4\" stroke-linecap=\"round\"/>")));
}, 1, "", true)), "join", ((V)(""))))))))));
} else {
if (SEqS(u_6931, "fork")) {
g_6937 = Add(g_6937, Add(Call(nk_6938, V.Undef, ((V)(1.2))), Call(WD_4186, V.Undef, C_6751, ((V)(x_6934)), ((V)((y1_6935 - 1.2))), ((V)(zH_6936)), ((V)("<path d=\"M-1.3 0H1.3V1.2H-1.3Z\" fill=\"url(#k64b)\"/><path d=\"M-1.1 1.2V8.4L-0.75 9.4L-0.4 8.4V1.2ZM0.4 1.2V8.4L0.75 9.4L1.1 8.4V1.2Z\" fill=\"url(#k64b)\" stroke=\"#8a6420\" stroke-width=\"0.12\"/>")))));
} else {
g_6937 = Add(g_6937, Call(WD_4186, V.Undef, C_6751, ((V)(x_6934)), ((V)(y1_6935)), ((V)(zH_6936)), ((V)(JsStrBuf.Begin().V(Invoke(Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis6984, int _argc6977, V j_6983, V _a6980, V _a6981, V _a6982, V[] _rest6978) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)(((-0.9) + (ToNum(j_6983) * 0.22)))))), " 0L", ToStr(Call(f1_16, V.Undef, ((V)(((-1.3) + (ToNum(j_6983) * 0.32)))))), " 5.6\" stroke=\"", (NumTruthy((ToNum(j_6983) % 2D)) ? "#e8d8b0" : "#d8c494"), "\" stroke-width=\"0.3\" stroke-linecap=\"round\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M-1.3 5.2H1.3\" stroke=\"#c8a868\" stroke-width=\"0.4\" opacity=\"0.6\"/>").End()))));
}
}
}
}
}
}
s_6761.V(Call(swayAt_4192, V.Undef, C_6751, Arr(((V)(x_6934)), ((V)((HY_6759 + 0.4))), ((V)(RZ_6758))), ((V)(1.1)), ((V)((4.8 + (ToNum(i_6932) * 0.37)))), ((V)((ToNum(i_6932) * 0.7))), g_6937));
return default;
}, 2, "", true));
Invoke(Arr(((V)((-39D))), ((V)((-26D))), ((V)((-13D))), ((V)(0D)), ((V)(13D)), ((V)(26D)), ((V)(39D))), "forEach", Fn((V _arrowThis6992, int _argc6985, V x_6991, V _a6988, V _a6989, V _a6990, V[] _rest6986) => {
return ((V)(s_6761.V(Call(sHook_6134, V.Undef, C_6751, x_6991, ((V)((RY_6757 + 0.85))), ((V)((RZ_6758 + 0.75))), ((V)(0.75)), ((V)("#b88a32")))).Str));
}, 1, "", true));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(DEF19_4188).S("<defs><linearGradient id=\"k64w\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#6a3e22\"/><stop offset=\"0.5\" stop-color=\"#4a2a18\"/><stop offset=\"1\" stop-color=\"#341c0e\"/></linearGradient>").S("<linearGradient id=\"k64g\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff0b0\"/><stop offset=\"0.35\" stop-color=\"#e2b456\"/><stop offset=\"0.7\" stop-color=\"#b38432\"/><stop offset=\"1\" stop-color=\"#f2d488\"/></linearGradient>").S("<linearGradient id=\"k64b\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0.4\"><stop offset=\"0\" stop-color=\"#a87a2a\"/><stop offset=\"0.4\" stop-color=\"#f6dc8a\"/><stop offset=\"0.7\" stop-color=\"#c99a3e\"/><stop offset=\"1\" stop-color=\"#8a6420\"/></linearGradient>").S("<linearGradient id=\"k64l\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffe6a8\" stop-opacity=\"0.65\"/><stop offset=\"0.55\" stop-color=\"#ffe0a0\" stop-opacity=\"0.18\"/><stop offset=\"1\" stop-color=\"#ffe0a0\" stop-opacity=\"0\"/></linearGradient>").S("<radialGradient id=\"k64v\" cx=\"50%\" cy=\"50%\" r=\"70%\"><stop offset=\"0.55\" stop-color=\"#8a5a2a\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#8a5a2a\" stop-opacity=\"0.45\"/></radialGradient>").S("<pattern id=\"k64h\" width=\"0.5\" height=\"0.5\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 0.5L0.5 0\" stroke=\"#5a4020\" stroke-width=\"0.06\" opacity=\"0.6\"/></pattern></defs>").End()))).Put("front", ((V)(s_6761.Str))).Put("bb", Invoke(C_6751, "bb", ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_6735;
return default;
}, 1, "", true));
Set(N_70, "smart27", Fn((V _arrowThis7000, int _argc6993, V S_6999, V _a6996, V _a6997, V _a6998, V[] _rest6994) => {
V D_7001 = default;
D_7001 = NewObj(5).Put("w", ((V)(122D))).Put("d", ((V)(14D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(40D))).Put("build", Fn((V _arrowThis7008, int _argc7002, V _a7004, V _a7005, V _a7006, V _a7007, V[] _rest7003) => {
return Arr();
}, 0, "build", true)).V;
Set(D_7001, "fx", Fn((V _arrowThis7016, int _argc7009, V ctx_7015, V _a7012, V _a7013, V _a7014, V[] _rest7010) => {
V C_7017 = default;
V k_7018 = default;
double PX_7019 = 0;
double PW_7020 = 0;
double PY0_7021 = 0;
double PH_7022 = 0;
V CH_7023 = default;
V s_7024 = default;
V RC_7025 = default;
V dish_7026 = default;
V KT_7027 = default;
JsStrBuf ui_7028 = null;
V orb_7029 = default;
V SP_7030 = default;
C_7017 = Call(camW_4181, V.Undef, ctx_7015);
k_7018 = Get(C_7017, "k");
PX_7019 = (-58D);
PW_7020 = 64D;
PY0_7021 = 12D;
PH_7022 = 42D;
CH_7023 = ((V)("#d8b878"));
Call(ext_4187, V.Undef, C_7017, Arr(Arr(((V)((-62D))), ((V)(((PY0_7021 + PH_7022) + 6D))), ((V)(0D))), Arr(((V)(60D)), ((V)(8D)), ((V)(0D))), Arr(((V)(60D)), ((V)(8D)), ((V)(12D)))));
s_7024 = Add(Call(WD_4186, V.Undef, C_7017, ((V)((PX_7019 - 5D))), ((V)(((PY0_7021 + PH_7022) + 5D))), ((V)(0.04)), ((V)(string.Concat("<rect width=\"", NumStr((PW_7020 + 10D)), "\" height=\"", NumStr((PH_7022 + 10D)), "\" rx=\"6\" fill=\"#ffcf7a\" opacity=\"0.2\" filter=\"url(#m11b8)\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.16;0.26;0.16")), ((V)(8D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "</rect>")))), Call(shW_6133, V.Undef, C_7017, ((V)(PX_7019)), ((V)((PY0_7021 + PH_7022))), ((V)(PW_7020)), ((V)(PH_7022)), ((V)(0.8)), ((V)(0.35))));
RC_7025 = Arr(NewObj(5).Put("t", ((V)("Saffron Risotto"))).Put("m", ((V)("4 servings \u00b7 35 min"))).Put("st", Arr(((V)("Toast the rice in butter")), ((V)("Ladle in warm stock")), ((V)("Fold in saffron + parmesan")))).Put("tm", ((V)("18:00"))).Put("ing", Arr(((V)("Arborio")), ((V)("Saffron")), ((V)("Parmesan")), ((V)("Shallot")))).V, NewObj(5).Put("t", ((V)("Lemon Meringue Tart"))).Put("m", ((V)("8 slices \u00b7 1 h 10"))).Put("st", Arr(((V)("Blind-bake the pastry")), ((V)("Whisk the lemon curd")), ((V)("Torch the meringue")))).Put("tm", ((V)("25:00"))).Put("ing", Arr(((V)("Lemons")), ((V)("Eggs")), ((V)("Butter")), ((V)("Sugar")))).V, NewObj(5).Put("t", ((V)("Coq au Vin"))).Put("m", ((V)("6 servings \u00b7 2 h"))).Put("st", Arr(((V)("Brown the chicken")), ((V)("Deglaze with Burgundy")), ((V)("Simmer with mushrooms")))).Put("tm", ((V)("90:00"))).Put("ing", Arr(((V)("Chicken")), ((V)("Burgundy")), ((V)("Mushrooms")), ((V)("Onions")))).V);
dish_7026 = Fn((V _arrowThis7038, int _argc7031, V i_7037, V _a7034, V _a7035, V _a7036, V[] _rest7032) => {
V Q_7039 = default;
V pt_7040 = default;
JsStrBuf o_7041 = null;
Q_7039 = Call(rng_13, V.Undef, ((V)(JsStrBuf.Begin().S("dish27").V(i_7037).End())));
pt_7040 = Fn((V _arrowThis7050, int _argc7042, V rx_7048, V ry_7049, V _a7046, V _a7047, V[] _rest7043) => {
double a_7051 = 0;
double d_7052 = 0;
a_7051 = ((ToNum(Call(Q_7039, V.Undef)) * 2D) * PI_11);
d_7052 = (System.Math.Sqrt(ToNum(Call(Q_7039, V.Undef))) * 0.88);
return Arr(((V)((13D + ((FdLibm.Cos(a_7051) * ToNum(rx_7048)) * d_7052)))), ((V)((22D + ((FdLibm.Sin(a_7051) * ToNum(ry_7049)) * d_7052)))));
return default;
}, 2, "", true);
o_7041 = new JsStrBuf(string.Concat("<circle cx=\"13.4\" cy=\"22.6\" r=\"8.2\" fill=\"#000000\" opacity=\"0.35\" filter=\"url(#m12b1)\"/><circle cx=\"13\" cy=\"22\" r=\"8\" fill=\"#efe4cc\"/><circle cx=\"13\" cy=\"22\" r=\"7.7\" fill=\"none\" stroke=\"", ToStr(CH_7023), "\" stroke-width=\"0.25\"/><circle cx=\"13\" cy=\"22\" r=\"5.6\" fill=\"#f8f0de\"/>"));
if (SEqN(i_7037, 0D)) {
o_7041.S("<ellipse cx=\"13\" cy=\"22.2\" rx=\"4.6\" ry=\"3.8\" fill=\"#e6b648\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(40D)), Fn((V _arrowThis7059, int _argc7053, V _a7055, V _a7056, V _a7057, V _a7058, V[] _rest7054) => {
V x_7060 = default;
V y_7061 = default;
{ V _t7062 = Call(pt_7040, V.Undef, ((V)(4.4)), ((V)(3.6)));
{ V _t7063 = ListOf(_t7062);
{ V _t7064 = GetIdx(_t7063, 0D);
x_7060 = _t7064; }
{ V _t7065 = GetIdx(_t7063, 1D);
y_7061 = _t7065; }
} }
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, x_7060)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, y_7061)), "\" rx=\"0.42\" ry=\"0.22\" fill=\"#f6dc8a\"/>")));
return default;
}, 0, "", true)), "join", ((V)("")))).V(Invoke(Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis7072, int _argc7066, V _a7068, V _a7069, V _a7070, V _a7071, V[] _rest7067) => {
V x_7073 = default;
V y_7074 = default;
{ V _t7075 = Call(pt_7040, V.Undef, ((V)(3.6)), ((V)(3D)));
{ V _t7076 = ListOf(_t7075);
{ V _t7077 = GetIdx(_t7076, 0D);
x_7073 = _t7077; }
{ V _t7078 = GetIdx(_t7076, 1D);
y_7074 = _t7078; }
} }
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, x_7073)), " ", ToStr(Call(f1_16, V.Undef, y_7074)), "l", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(Call(Q_7039, V.Undef)) - 0.5) * 1.4))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(Call(Q_7039, V.Undef)) - 0.5) * 1D))))), "\" stroke=\"#c83a1e\" stroke-width=\"0.18\"/>")));
return default;
}, 0, "", true)), "join", ((V)("")))).S("<path d=\"M11 20.6l1.6 -0.4l0.4 1.2l-1.4 0.3z M14.6 23l1.4 0.2l-0.2 1.1l-1.3 -0.3z\" fill=\"#fbf6ea\" opacity=\"0.9\"/><ellipse cx=\"14.4\" cy=\"20.6\" rx=\"0.9\" ry=\"0.45\" transform=\"rotate(-30 14.4 20.6)\" fill=\"#5a8a3a\"/><ellipse cx=\"15.2\" cy=\"21\" rx=\"0.8\" ry=\"0.4\" transform=\"rotate(20 15.2 21)\" fill=\"#6a9a4a\"/>");
} else {
if (SEqN(i_7037, 1D)) {
o_7041.S("<circle cx=\"13\" cy=\"22\" r=\"4.9\" fill=\"#cf9a58\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(22D)), Fn((V _arrowThis7086, int _argc7079, V j_7085, V _a7082, V _a7083, V _a7084, V[] _rest7080) => {
double a_7087 = 0;
a_7087 = (((ToNum(j_7085) / 22D) * 2D) * PI_11);
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((13D + (FdLibm.Cos(a_7087) * 4.9)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((22D + (FdLibm.Sin(a_7087) * 4.9)))))), "\" r=\"0.55\" fill=\"#b88040\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))).S("<circle cx=\"13\" cy=\"22\" r=\"4.1\" fill=\"#f0cc3a\"/>").V(Invoke(Invoke(Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(2D)), ((V)((-1.2)))), Arr(((V)((-2D))), ((V)((-1.2)))), Arr(((V)(2D)), ((V)(1.4))), Arr(((V)((-2D))), ((V)(1.4))), Arr(((V)(0D)), ((V)(2.6))), Arr(((V)(0D)), ((V)((-2.6))))), "map", Fn((V _arrowThis7099, int _argc7088, V _a7090, V _a7091, V _a7092, V _a7093, V[] _rest7089) => {
V dx_7096 = default;
V dy_7098 = default;
{ V _t7094 = ListOf(_a7090);
{ V _t7095 = GetIdx(_t7094, 0D);
dx_7096 = _t7095; }
{ V _t7097 = GetIdx(_t7094, 1D);
dy_7098 = _t7097; }
}
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, Add(((V)(13D)), dx_7096))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, Add(((V)(22D)), dy_7098))), "\" r=\"1\" fill=\"#fbf6ea\"/><circle cx=\"", ToStr(Call(f1_16, V.Undef, Add(((V)(12.7)), dx_7096))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, Add(((V)(21.6)), dy_7098))), "\" r=\"0.38\" fill=\"#d8a060\"/>")));
}, 1, "", true)), "join", ((V)(""))));
} else {
o_7041.S("<ellipse cx=\"13\" cy=\"22\" rx=\"4.8\" ry=\"4\" fill=\"#5e1a1e\"/><ellipse cx=\"11.8\" cy=\"20.6\" rx=\"2.2\" ry=\"0.9\" fill=\"#8a3036\" opacity=\"0.6\"/>").V(Invoke(Invoke(Arr(Arr(((V)(11.4)), ((V)(22.4)), ((V)(1.8)), ((V)(1.1))), Arr(((V)(14.6)), ((V)(21.2)), ((V)(1.6)), ((V)(1D))), Arr(((V)(13.6)), ((V)(24D)), ((V)(1.5)), ((V)(0.9)))), "map", Fn((V _arrowThis7115, int _argc7100, V _a7102, V _a7103, V _a7104, V _a7105, V[] _rest7101) => {
V x_7108 = default;
V y_7110 = default;
V a_7112 = default;
V b_7114 = default;
{ V _t7106 = ListOf(_a7102);
{ V _t7107 = GetIdx(_t7106, 0D);
x_7108 = _t7107; }
{ V _t7109 = GetIdx(_t7106, 1D);
y_7110 = _t7109; }
{ V _t7111 = GetIdx(_t7106, 2D);
a_7112 = _t7111; }
{ V _t7113 = GetIdx(_t7106, 3D);
b_7114 = _t7113; }
}
return ((V)(string.Concat("<ellipse cx=\"", ToStr(x_7108), "\" cy=\"", ToStr(y_7110), "\" rx=\"", ToStr(a_7112), "\" ry=\"", ToStr(b_7114), "\" fill=\"#b87448\"/><ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_7108) - 0.3))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(y_7110) - 0.3))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(a_7112) * 0.5))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(b_7114) * 0.4))))), "\" fill=\"#d89a6a\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M15.6 23.4a0.9 0.9 0 0 1 1.8 0z M10 20.4a0.8 0.8 0 0 1 1.6 0z\" fill=\"#e0d0b0\"/><circle cx=\"10.4\" cy=\"23.8\" r=\"0.5\" fill=\"#e07a30\"/><circle cx=\"16.4\" cy=\"21.4\" r=\"0.45\" fill=\"#e07a30\"/><circle cx=\"12.4\" cy=\"19.4\" r=\"0.55\" fill=\"#f2ead8\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(8D)), Fn((V _arrowThis7122, int _argc7116, V _a7118, V _a7119, V _a7120, V _a7121, V[] _rest7117) => {
V x_7123 = default;
V y_7124 = default;
{ V _t7125 = Call(pt_7040, V.Undef, ((V)(4.2)), ((V)(3.4)));
{ V _t7126 = ListOf(_t7125);
{ V _t7127 = GetIdx(_t7126, 0D);
x_7123 = _t7127; }
{ V _t7128 = GetIdx(_t7126, 1D);
y_7124 = _t7128; }
} }
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, x_7123)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, y_7124)), "\" r=\"0.2\" fill=\"#6a9a4a\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
}
}
return ((V)(o_7041.Str));
return default;
}, 1, "", true);
KT_7027 = Arr(Arr(((V)("1;1;0;0;1")), ((V)("0;0.31;0.333;0.977;1"))), Arr(((V)("0;0;1;1;0;0")), ((V)("0;0.333;0.356;0.643;0.666;1"))), Arr(((V)("0;0;1;1;0")), ((V)("0;0.666;0.689;0.977;1"))));
ui_7028 = new JsStrBuf(string.Concat(string.Concat("<rect width=\"", NumStr(PW_7020), "\" height=\"", NumStr(PH_7022), "\" fill=\"url(#k84g)\"/><text x=\"3\" y=\"4\" font-family=\"", ToStr(SANS_6132), "\" font-size=\"1.3\" fill=\"#c8a868\" letter-spacing=\"0.35\">CHEF'S TABLE</text><text x=\"61\" y=\"4\" text-anchor=\"end\" font-family=\"", ToStr(SANS_6132), "\" font-size=\"1.3\" fill=\"#c8a868\">18:42</text><path d=\"M3 5.6H61\" stroke=\"#5a4a32\" stroke-width=\"0.12\"/>"), string.Concat("<g>", ToStr(Call(at_47, V.Undef, ((V)("translate")), ((V)("0 0;0 0;0 4.4;0 4.4;0 8.8;0 8.8;0 0")), ((V)(10D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.3;0.34;0.63;0.67;0.97;1\"")))), "<rect x=\"24.2\" y=\"17.3\" width=\"25.4\" height=\"3.2\" rx=\"0.6\" fill=\"#f2c66a\" opacity=\"0.13\"/></g>"), string.Concat("<circle cx=\"55\" cy=\"22\" r=\"4.4\" fill=\"none\" stroke=\"#3a3024\" stroke-width=\"0.7\"/><circle cx=\"55\" cy=\"22\" r=\"4.4\" fill=\"none\" stroke=\"#f2c66a\" stroke-width=\"0.7\" stroke-linecap=\"round\" stroke-dasharray=\"27.65\" transform=\"rotate(-90 55 22)\">", ToStr(Call(an_14, V.Undef, ((V)("stroke-dashoffset")), ((V)("27.65;0")), ((V)(10D)), ((V)(0D)))), "</circle>"), string.Concat("<rect x=\"3\" y=\"33.4\" width=\"58\" height=\"0.5\" rx=\"0.25\" fill=\"#3a3024\"/><rect x=\"3\" y=\"33.4\" width=\"20\" height=\"0.5\" rx=\"0.25\" fill=\"#f2c66a\">", ToStr(Call(an_14, V.Undef, ((V)("width")), ((V)("0;58")), ((V)(10D)), ((V)(0D)))), "</rect>")));
Invoke(RC_7025, "forEach", Fn((V _arrowThis7137, int _argc7129, V r_7135, V i_7136, V _a7133, V _a7134, V[] _rest7130) => {
JsStrBuf g_7138 = null;
g_7138 = new JsStrBuf(JsStrBuf.Begin().V(Call(dish_7026, V.Undef, i_7136)).S(string.Concat("<text x=\"25\" y=\"11.6\" font-family=\"", ToStr(SERIF_6130), "\" font-style=\"italic\" font-size=\"3.2\" fill=\"#f6e2a8\">", ToStr(Call(xe_6129, V.Undef, Get(r_7135, "t"))), "</text><text x=\"25\" y=\"14.4\" font-family=\"", ToStr(SANS_6132), "\" font-size=\"1.3\" fill=\"#b89a60\" letter-spacing=\"0.1\">", ToStr(Call(xe_6129, V.Undef, Get(r_7135, "m"))), "</text>")).End());
Invoke(Get(r_7135, "st"), "forEach", Fn((V _arrowThis7147, int _argc7139, V t_7145, V j_7146, V _a7143, V _a7144, V[] _rest7140) => {
double y_7148 = 0;
y_7148 = (19.4 + (ToNum(j_7146) * 4.4));
g_7138.S(string.Concat("<circle cx=\"26\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((y_7148 - 0.5))))), "\" r=\"1.1\" fill=\"none\" stroke=\"", ToStr(CH_7023), "\" stroke-width=\"0.2\"/><text x=\"26\" y=\"", ToStr(Call(f1_16, V.Undef, ((V)(y_7148)))), "\" text-anchor=\"middle\" font-family=\"", ToStr(SANS_6132), "\" font-size=\"1.2\" fill=\"", ToStr(CH_7023), "\">", ToStr(Add(j_7146, ((V)(1D)))), "</text><text x=\"28\" y=\"", ToStr(Call(f1_16, V.Undef, ((V)(y_7148)))), "\" font-family=\"", ToStr(SANS_6132), "\" font-size=\"1.45\" fill=\"#ecd8a6\">", ToStr(Call(xe_6129, V.Undef, t_7145)), "</text>"));
return default;
}, 2, "", true));
g_7138.S(string.Concat("<text x=\"55\" y=\"22.6\" text-anchor=\"middle\" font-family=\"", ToStr(SANS_6132), "\" font-size=\"1.9\" fill=\"#f6e2a8\">", ToStr(Get(r_7135, "tm")), "</text><text x=\"55\" y=\"24.4\" text-anchor=\"middle\" font-family=\"", ToStr(SANS_6132), "\" font-size=\"0.8\" fill=\"#b89a60\" letter-spacing=\"0.2\">MIN</text>"));
Invoke(Get(r_7135, "ing"), "forEach", Fn((V _arrowThis7157, int _argc7149, V t_7155, V j_7156, V _a7153, V _a7154, V[] _rest7150) => {
double x_7158 = 0;
x_7158 = (3D + (ToNum(j_7156) * 14.6));
g_7138.S(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)(x_7158)))), "\" y=\"36.4\" width=\"13.4\" height=\"3\" rx=\"1.5\" fill=\"#241d16\" stroke=\"#6a5638\" stroke-width=\"0.18\"/><circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((x_7158 + 1.6))))), "\" cy=\"37.9\" r=\"0.62\" fill=\"", (LtN(j_7156, 2D) ? "#f2c66a" : "none"), "\" stroke=\"#f2c66a\" stroke-width=\"0.18\"/>", (LtN(j_7156, 2D) ? string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((x_7158 + 1.25))))), " 37.9l0.3 0.3l0.55 -0.6\" stroke=\"#1c1712\" stroke-width=\"0.2\" fill=\"none\"/>") : ""), "<text x=\"", ToStr(Call(f1_16, V.Undef, ((V)((x_7158 + 2.8))))), "\" y=\"38.4\" font-family=\"", ToStr(SANS_6132), "\" font-size=\"1.2\" fill=\"#d8c090\">", ToStr(Call(xe_6129, V.Undef, t_7155)), "</text>"));
return default;
}, 2, "", true));
ui_7028.S(string.Concat("<g opacity=\"", NumStr((Truthy(i_7136) ? 0D : 1D)), "\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), GetIdx(GetK(KT_7027, i_7136), 0D), ((V)(30D)), ((V)(0D)), ((V)(JsStrBuf.Begin().S(" keyTimes=\"").V(GetIdx(GetK(KT_7027, i_7136), 1D)).S("\"").End())))), g_7138.Str, "</g>"));
return default;
}, 2, "", true));
ui_7028.S(string.Concat("<path d=\"M12 0H20L6 ", NumStr(PH_7022), "H0Z\" fill=\"#ffffff\" opacity=\"0.04\"/><rect x=\"0.3\" y=\"0.3\" width=\"", NumStr((PW_7020 - 0.6)), "\" height=\"", NumStr((PH_7022 - 0.6)), "\" rx=\"0.6\" fill=\"none\" stroke=\"url(#k84b)\" stroke-width=\"0.6\"/>"));
s_7024 = Add(s_7024, Call(box3_4184, V.Undef, C_7017, NewObj(7).Put("c", Arr(((V)((PX_7019 + (PW_7020 / 2D)))), ((V)(PY0_7021)), ((V)(0.7)))).Put("w", ((V)(PW_7020))).Put("h", ((V)(PH_7022))).Put("d", ((V)(1.4))).Put("col", ((V)("#1c1712"))).Put("r", ((V)(0.3))).Put("dec", NewObj(1).Put("f", ((V)(ui_7028.Str))).V).V));
Invoke(Arr(Arr(((V)((PX_7019 + 2.4))), ((V)((PY0_7021 + 2.4)))), Arr(((V)(((PX_7019 + PW_7020) - 2.4))), ((V)((PY0_7021 + 2.4)))), Arr(((V)((PX_7019 + 2.4))), ((V)(((PY0_7021 + PH_7022) - 2.4)))), Arr(((V)(((PX_7019 + PW_7020) - 2.4))), ((V)(((PY0_7021 + PH_7022) - 2.4))))), "forEach", Fn((V _arrowThis7170, int _argc7159, V _a7161, V _a7162, V _a7163, V _a7164, V[] _rest7160) => {
V x_7167 = default;
V y_7169 = default;
{ V _t7165 = ListOf(_a7161);
{ V _t7166 = GetIdx(_t7165, 0D);
x_7167 = _t7166; }
{ V _t7168 = GetIdx(_t7165, 1D);
y_7169 = _t7168; }
}
return (s_7024 = Add(s_7024, Call(cyl3_4185, V.Undef, C_7017, Arr(x_7167, y_7169, ((V)(1.4))), Arr(x_7167, y_7169, ((V)(1.9))), ((V)(0.85)), CH_7023, NewObj(2).Put("n", ((V)(14D))).Put("mat", ((V)("gloss"))).V)));
}, 1, "", true));
orb_7029 = Fn((V _arrowThis7182, int _argc7171, V q_7177, V r_7178, V sp_7179, V ph_7180, V[] _rest7172) => {
V col_7183 = default;
V ty_7184 = default;
V c_7185 = default;
V cx_7186 = default;
V cy_7187 = default;
double Rr_7188 = 0;
V id_7189 = default;
V Q_7190 = default;
JsStrBuf fl_7191 = null;
V body_7192 = default;
V du_7181 = default;
du_7181 = (_argc7171 > 4 ? _rest7172[0] : V.Undef);
{ V _t7193 = sp_7179;
{ V _t7194 = ListOf(_t7193);
{ V _t7195 = GetIdx(_t7194, 0D);
col_7183 = _t7195; }
{ V _t7196 = GetIdx(_t7194, 1D);
ty_7184 = _t7196; }
} }
c_7185 = Invoke(C_7017, "P", q_7177);
cx_7186 = GetIdx(c_7185, 0D);
cy_7187 = GetIdx(c_7185, 1D);
Rr_7188 = (ToNum(r_7178) * ToNum(k_7018));
id_7189 = Invoke(C_7017, "u", ((V)("ob")));
Q_7190 = Call(rng_13, V.Undef, ((V)(JsStrBuf.Begin().S("orb").V(col_7183).End())));
fl_7191 = new JsStrBuf(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cx_7186) - Rr_7188))))), "\" y=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cy_7187) - (Rr_7188 * 0.08)))))), "\" width=\"", ToStr(Call(f1_16, V.Undef, ((V)((2D * Rr_7188))))), "\" height=\"", ToStr(Call(f1_16, V.Undef, ((V)((Rr_7188 * 1.1))))), "\" fill=\"", ToStr(col_7183), "\"/>"));
fl_7191.V(Invoke(Call(rep_18, V.Undef, ((V)((SEqS(ty_7184, "bd") ? 18D : 36D))), Fn((V _arrowThis7203, int _argc7197, V _a7199, V _a7200, V _a7201, V _a7202, V[] _rest7198) => {
V x_7204 = default;
V y_7205 = default;
V sc_7206 = default;
x_7204 = Add(cx_7186, ((V)((((ToNum(Call(Q_7190, V.Undef)) - 0.5) * 1.8) * Rr_7188))));
y_7205 = Add(cy_7187, ((V)(((ToNum(Call(Q_7190, V.Undef)) * Rr_7188) * 0.95))));
sc_7206 = Call(shade_10, V.Undef, col_7183, ((V)((0.75 + (ToNum(Call(Q_7190, V.Undef)) * 0.5)))));
if (SEqS(ty_7184, "th")) {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, x_7204)), " ", ToStr(Call(f1_16, V.Undef, y_7205)), "l", ToStr(Call(f1_16, V.Undef, ((V)((((ToNum(Call(Q_7190, V.Undef)) - 0.5) * 1.4) * ToNum(k_7018)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((((ToNum(Call(Q_7190, V.Undef)) - 0.5) * 0.9) * ToNum(k_7018)))))), "\" stroke=\"", (LtN(Call(Q_7190, V.Undef), 0.5) ? "#e85a2a" : "#8a1e10"), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.14 * ToNum(k_7018)))))), "\"/>")));
}
if (SEqS(ty_7184, "bd")) {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, x_7204)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, y_7205)), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.42 * ToNum(k_7018)))))), "\" fill=\"", ToStr(sc_7206), "\"/><circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_7204) - (0.12 * ToNum(k_7018))))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(y_7205) - (0.12 * ToNum(k_7018))))))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.12 * ToNum(k_7018)))))), "\" fill=\"#ffffff\" opacity=\"0.4\"/>")));
}
if (SEqS(ty_7184, "pd")) {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, x_7204)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, y_7205)), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.6 * ToNum(k_7018)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.32 * ToNum(k_7018)))))), "\" transform=\"rotate(", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(Q_7190, V.Undef)) * 180D))))), " ", ToStr(Call(f1_16, V.Undef, x_7204)), " ", ToStr(Call(f1_16, V.Undef, y_7205)), ")\" fill=\"", ToStr(sc_7206), "\"/>")));
}
if (SEqS(ty_7184, "cr")) {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, x_7204)), "\" y=\"", ToStr(Call(f1_16, V.Undef, y_7205)), "\" width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_7018)))))), "\" height=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_7018)))))), "\" transform=\"rotate(", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(Q_7190, V.Undef)) * 90D))))), " ", ToStr(Call(f1_16, V.Undef, x_7204)), " ", ToStr(Call(f1_16, V.Undef, y_7205)), ")\" fill=\"#ffffff\" stroke=\"#c8c4bc\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.04 * ToNum(k_7018)))))), "\"/>")));
}
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, x_7204)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, y_7205)), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.12 * ToNum(k_7018)))))), "\" fill=\"", ToStr(sc_7206), "\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
fl_7191.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, cx_7186)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cy_7187) - (Rr_7188 * 0.08)))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((Rr_7188 * 0.92))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((Rr_7188 * 0.2))))), "\" fill=\"", ToStr(Call(shade_10, V.Undef, col_7183, ((V)(1.18)))), "\"/>"));
body_7192 = ((V)(JsStrBuf.Begin().S(string.Concat("<defs><clipPath id=\"", ToStr(id_7189), "\"><circle cx=\"", ToStr(Call(f1_16, V.Undef, cx_7186)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, cy_7187)), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((Rr_7188 * 0.93))))), "\"/></clipPath></defs><circle cx=\"", ToStr(Call(f1_16, V.Undef, cx_7186)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, cy_7187)), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)(Rr_7188)))), "\" fill=\"#fff4dc\" opacity=\"0.12\"/>")).S(string.Concat("<g clip-path=\"url(#", ToStr(id_7189), ")\">", fl_7191.Str, "<rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cx_7186) - Rr_7188))))), "\" y=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cy_7187) - Rr_7188))))), "\" width=\"", ToStr(Call(f1_16, V.Undef, ((V)((2D * Rr_7188))))), "\" height=\"", ToStr(Call(f1_16, V.Undef, ((V)((2D * Rr_7188))))), "\" fill=\"url(#k84s)\"/></g>")).S(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, cx_7186)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, cy_7187)), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)(Rr_7188)))), "\" fill=\"none\" stroke=\"#f6ead0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.28 * ToNum(k_7018)))))), "\" opacity=\"0.75\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cx_7186) - (Rr_7188 * 0.72)))))), " ", ToStr(Call(f1_16, V.Undef, Add(cy_7187, ((V)((Rr_7188 * 0.6)))))), "Q", ToStr(Call(f1_16, V.Undef, cx_7186)), " ", ToStr(Call(f1_16, V.Undef, Add(cy_7187, ((V)((Rr_7188 * 1.06)))))), " ", ToStr(Call(f1_16, V.Undef, Add(cx_7186, ((V)((Rr_7188 * 0.72)))))), " ", ToStr(Call(f1_16, V.Undef, Add(cy_7187, ((V)((Rr_7188 * 0.6)))))), "\" stroke=\"#ffd890\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 * ToNum(k_7018)))))), "\" fill=\"none\" opacity=\"0.7\"/>")).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cx_7186) - (Rr_7188 * 0.38)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cy_7187) - (Rr_7188 * 0.44)))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((Rr_7188 * 0.3))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((Rr_7188 * 0.15))))), "\" transform=\"rotate(-38 ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cx_7186) - (Rr_7188 * 0.38)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cy_7187) - (Rr_7188 * 0.44)))))), ")\" fill=\"#ffffff\" opacity=\"0.7\"/><circle cx=\"", ToStr(Call(f1_16, V.Undef, Add(cx_7186, ((V)((Rr_7188 * 0.42)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cy_7187) - (Rr_7188 * 0.2)))))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)((Rr_7188 * 0.06))))), "\" fill=\"#ffffff\" opacity=\"0.8\"/>")).S(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cx_7186) - (Rr_7188 * 0.26)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(cy_7187) - (Rr_7188 * 0.9)))))), "h", ToStr(Call(f1_16, V.Undef, ((V)((Rr_7188 * 0.52))))), "v", ToStr(Call(f1_16, V.Undef, ((V)(((-Rr_7188) * 0.24))))), "q0 ", ToStr(Call(f1_16, V.Undef, ((V)(((-Rr_7188) * 0.12))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-Rr_7188) * 0.1))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-Rr_7188) * 0.12))))), "h", ToStr(Call(f1_16, V.Undef, ((V)(((-Rr_7188) * 0.32))))), "q", ToStr(Call(f1_16, V.Undef, ((V)(((-Rr_7188) * 0.1))))), " 0 ", ToStr(Call(f1_16, V.Undef, ((V)(((-Rr_7188) * 0.1))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((Rr_7188 * 0.12))))), "Z\" fill=\"url(#k84b)\"/>")).End()));
return ((V)(string.Concat("<g>", ToStr(Call(at_47, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;0 ").V(Call(f1_16, V.Undef, ((V)(((-1.5) * ToNum(k_7018)))))).S(";0 0").End())), du_7181, ((V)((-ToNum(ph_7180)))), Call(SPL_15, V.Undef, ((V)(2D))))), ToStr(body_7192), "</g>")));
return default;
}, 5, "", true);
SP_7030 = Arr(Arr(((V)("#c8401e")), ((V)("th"))), Arr(((V)("#b8321e")), ((V)("pw"))), Arr(((V)("#e0a020")), ((V)("pw"))), Arr(((V)("#d86a7a")), ((V)("bd"))), Arr(((V)("#8aa060")), ((V)("pd"))), Arr(((V)("#2e2826")), ((V)("bd"))), Arr(((V)("#f2efe8")), ((V)("cr"))), Arr(((V)("#7a2a30")), ((V)("pw"))));
Invoke(Arr(((V)(14D)), ((V)(34D))), "forEach", Fn((V _arrowThis7215, int _argc7207, V SY_7213, V row_7214, V _a7211, V _a7212, V[] _rest7208) => {
V XS_7216 = default;
V PH2_7217 = default;
JsStrBuf top_7218 = null;
XS_7216 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D))), "map", Fn((V _arrowThis7226, int _argc7219, V i_7225, V _a7222, V _a7223, V _a7224, V[] _rest7220) => {
return ((V)((17.5 + (ToNum(i_7225) * 11D))));
}, 1, "", true));
PH2_7217 = Invoke(XS_7216, "map", Fn((V _arrowThis7235, int _argc7227, V x_7233, V i_7234, V _a7231, V _a7232, V[] _rest7228) => {
return Arr(((V)((ToNum(Add(((V)((ToNum(row_7214) * 4D))), i_7234)) * 0.9))), ((V)((5.2 + ((ToNum(Add(((V)((ToNum(row_7214) * 4D))), i_7234)) % 3D) * 0.6)))));
}, 2, "", true));
top_7218 = new JsStrBuf(JsStrBuf.Begin().S("<rect width=\"44\" height=\"9\" fill=\"url(#k84w)\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(8D)), Fn((V _arrowThis7243, int _argc7236, V j_7242, V _a7239, V _a7240, V _a7241, V[] _rest7237) => {
return ((V)(string.Concat("<path d=\"M0 ", ToStr(Call(f1_16, V.Undef, ((V)((0.6 + (ToNum(j_7242) * 1.1)))))), "q14 0.3 22 -0.1t22 0.2\" stroke=\"#2a160c\" stroke-width=\"0.12\" fill=\"none\" opacity=\"0.5\"/>")));
}, 1, "", true)), "join", ((V)("")))).End());
Invoke(XS_7216, "forEach", Fn((V _arrowThis7252, int _argc7244, V x_7250, V i_7251, V _a7248, V _a7249, V[] _rest7245) => {
return ((V)(top_7218.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_7250) - 12D))))), "\" cy=\"4.5\" rx=\"3.2\" ry=\"2.4\" fill=\"url(#k84o)\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.95;0.55;0.95")), GetIdx(GetK(PH2_7217, i_7251), 1D), ((V)((-ToNum(GetIdx(GetK(PH2_7217, i_7251), 0D))))), Call(SPL_15, V.Undef, ((V)(2D))))), "</ellipse>")).Str));
}, 2, "", true));
s_7024 = Add(s_7024, Add(Call(shW_6133, V.Undef, C_7017, ((V)(12D)), Add(SY_7213, ((V)(1.8))), ((V)(44D)), ((V)(2.6)), ((V)(0.6)), ((V)(0.3))), Call(box3_4184, V.Undef, C_7017, NewObj(7).Put("c", Arr(((V)(34D)), SY_7213, ((V)(4.5)))).Put("w", ((V)(44D))).Put("h", ((V)(1.8))).Put("d", ((V)(9D))).Put("col", ((V)("#4a2c1a"))).Put("r", ((V)(0.3))).Put("dec", NewObj(2).Put("f", ((V)(string.Concat("<rect width=\"44\" height=\"1.8\" fill=\"url(#k84w)\"/><rect width=\"44\" height=\"0.4\" fill=\"", ToStr(CH_7023), "\"/><rect y=\"1.5\" width=\"44\" height=\"0.3\" fill=\"#2a160c\" opacity=\"0.6\"/>")))).Put("t", ((V)(top_7218.Str))).V).V)));
Invoke(XS_7216, "forEach", Fn((V _arrowThis7261, int _argc7253, V x_7259, V i_7260, V _a7257, V _a7258, V[] _rest7254) => {
return (s_7024 = Add(s_7024, Call(orb_7029, V.Undef, Arr(x_7259, Add(SY_7213, ((V)(7.9))), ((V)(4.5))), ((V)(3.6)), GetK(SP_7030, Add(((V)((ToNum(row_7214) * 4D))), i_7260)), GetIdx(GetK(PH2_7217, i_7260), 0D), GetIdx(GetK(PH2_7217, i_7260), 1D))));
}, 2, "", true));
return default;
}, 2, "", true));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(DEF19_4188).S(string.Concat("<defs><linearGradient id=\"k84g\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#2e251b\"/><stop offset=\"1\" stop-color=\"#120e0a\"/></linearGradient><linearGradient id=\"k84b\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff0c8\"/><stop offset=\"0.5\" stop-color=\"#d8b878\"/><stop offset=\"1\" stop-color=\"#9a7a40\"/></linearGradient><linearGradient id=\"k84w\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#5a3420\"/><stop offset=\"1\" stop-color=\"#3e2214\"/></linearGradient><radialGradient id=\"k84o\"><stop offset=\"0\" stop-color=\"#ffd88a\" stop-opacity=\"0.85\"/><stop offset=\"1\" stop-color=\"#ffd88a\" stop-opacity=\"0\"/></radialGradient><radialGradient id=\"k84s\" cx=\"40%\" cy=\"35%\" r=\"70%\"><stop offset=\"0.3\" stop-color=\"#000000\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#2a1a0a\" stop-opacity=\"0.5\"/></radialGradient></defs>", "")).End()))).Put("front", s_7024).Put("bb", Invoke(C_7017, "bb", ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_7001;
return default;
}, 1, "", true));
Set(N_70, "ksign27", Fn((V _arrowThis7269, int _argc7262, V S_7268, V _a7265, V _a7266, V _a7267, V[] _rest7263) => {
V t_7270 = default;
double W_7271 = 0;
double Hh_7272 = 0;
double Y0_7273 = 0;
double YT_7274 = 0;
double NY_7275 = 0;
double DP_7276 = 0;
double ex_7277 = 0;
V D_7278 = default;
t_7270 = Invoke(((Get(S_7268, "txt") is var _t7280 && Truthy(_t7280) ? _t7280 : (Get(S_7268, "row") is var _t7279 && !Truthy(_t7279) ? _t7279 : Get(Get(S_7268, "row"), "txt0"))) is var _t7281 && Truthy(_t7281) ? _t7281 : ((V)("Kitchen"))), "slice", ((V)(0D)), ((V)(26D)));
W_7271 = Max(54D, Min(150D, (30D + (ToNum(Get(t_7270, "length")) * 6.2))));
Hh_7272 = 18D;
Y0_7273 = 20D;
YT_7274 = (Y0_7273 + Hh_7272);
NY_7275 = (YT_7274 + 10D);
DP_7276 = 3D;
ex_7277 = ((W_7271 / 2D) - 7D);
D_7278 = NewObj(5).Put("w", ((V)((W_7271 + 10D)))).Put("d", ((V)(6D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(48D))).Put("build", Fn((V _arrowThis7288, int _argc7282, V _a7284, V _a7285, V _a7286, V _a7287, V[] _rest7283) => {
return Arr();
}, 0, "build", true)).V;
Set(D_7278, "fx", Fn((V _arrowThis7296, int _argc7289, V ctx_7295, V _a7292, V _a7293, V _a7294, V[] _rest7290) => {
V C_7297 = default;
V R_7298 = default;
V id_7299 = default;
V k_7300 = default;
JsStrBuf f_7301 = null;
V g_7302 = default;
V rb_7303 = default;
V s_7304 = default;
C_7297 = Call(camW_4181, V.Undef, ctx_7295);
R_7298 = Call(rng_13, V.Undef, ((V)(JsStrBuf.Begin().S("ks").V(t_7270).End())));
id_7299 = Invoke(C_7297, "u", ((V)("ks")));
k_7300 = Get(C_7297, "k");
Call(ext_4187, V.Undef, C_7297, Arr(Arr(((V)((((-W_7271) / 2D) - 2D))), ((V)((NY_7275 + 3D))), ((V)(0D))), Arr(((V)(((W_7271 / 2D) + 2D))), ((V)((Y0_7273 - 3D))), ((V)(0D))), Arr(((V)((W_7271 / 2D))), ((V)(Y0_7273)), ((V)(6D)))));
f_7301 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<rect width=\"", ToStr(Call(f1_16, V.Undef, ((V)(W_7271)))), "\" height=\"", NumStr(Hh_7272), "\" fill=\"url(#k101p)\"/>")).V(Invoke(Call(rep_18, V.Undef, ((V)(18D)), Fn((V _arrowThis7311, int _argc7305, V _a7307, V _a7308, V _a7309, V _a7310, V[] _rest7306) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_7298, V.Undef)) * (W_7271 - 16D)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.6 + (ToNum(Call(R_7298, V.Undef)) * (Hh_7272 - 1.2))))))), "h", ToStr(Call(f1_16, V.Undef, ((V)((4D + (ToNum(Call(R_7298, V.Undef)) * 12D)))))), "\" stroke=\"", (LtN(Call(R_7298, V.Undef), 0.5) ? "#ffffff" : "#d4c8aa"), "\" stroke-width=\"0.3\" opacity=\"0.35\"/>")));
}, 0, "", true)), "join", ((V)("")))).End());
f_7301.V(Invoke(Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis7318, int _argc7312, V _a7314, V _a7315, V _a7316, V _a7317, V[] _rest7313) => {
V e_7319 = default;
double x_7320 = 0;
double y_7321 = 0;
double rr_7322 = 0;
V P_7323 = default;
e_7319 = Call(R_7298, V.Undef);
x_7320 = (LtN(e_7319, 0.5) ? (1D + (ToNum(Call(R_7298, V.Undef)) * (W_7271 - 2D))) : (LtN(e_7319, 0.75) ? 0.8 : (W_7271 - 0.8)));
y_7321 = (LtN(e_7319, 0.25) ? 0.8 : (LtN(e_7319, 0.5) ? (Hh_7272 - 0.8) : (2D + (ToNum(Call(R_7298, V.Undef)) * (Hh_7272 - 4D)))));
rr_7322 = (0.6 + (ToNum(Call(R_7298, V.Undef)) * 1.1));
P_7323 = Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis7331, int _argc7324, V j_7330, V _a7327, V _a7328, V _a7329, V[] _rest7325) => {
double a_7332 = 0;
double q_7333 = 0;
a_7332 = (((ToNum(j_7330) / 6D) * 2D) * PI_11);
q_7333 = (rr_7322 * (0.6 + (ToNum(Call(R_7298, V.Undef)) * 0.6)));
return ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, ((V)((x_7320 + ((FdLibm.Cos(a_7332) * q_7333) * 1.4)))))).S(" ").V(Call(f1_16, V.Undef, ((V)((y_7321 + (FdLibm.Sin(a_7332) * q_7333)))))).End()));
return default;
}, 1, "", true));
return ((V)(string.Concat("<path d=\"M", ToStr(Invoke(P_7323, "join", ((V)("L")))), "Z\" fill=\"#c8965a\" stroke=\"#9a6a3a\" stroke-width=\"0.15\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
f_7301.S(string.Concat("<rect x=\"1.8\" y=\"1.8\" width=\"", ToStr(Call(f1_16, V.Undef, ((V)((W_7271 - 3.6))))), "\" height=\"", NumStr((Hh_7272 - 3.6)), "\" rx=\"1\" fill=\"none\" stroke=\"#8aa08a\" stroke-width=\"0.55\"/>"));
f_7301.S(string.Concat("<defs><mask id=\"", ToStr(id_7299), "m\"><rect width=\"", ToStr(Call(f1_16, V.Undef, ((V)(W_7271)))), "\" height=\"", NumStr(Hh_7272), "\" fill=\"#ffffff\"/>", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(70D)), Fn((V _arrowThis7340, int _argc7334, V _a7336, V _a7337, V _a7338, V _a7339, V[] _rest7335) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_7298, V.Undef)) * W_7271))))), "\" y=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_7298, V.Undef)) * Hh_7272))))), "\" width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.6 + (ToNum(Call(R_7298, V.Undef)) * 1.4)))))), "\" height=\"0.22\" fill=\"#000000\" opacity=\"0.8\"/>")));
}, 0, "", true)), "join", ((V)("")))), "</mask></defs>")).S(string.Concat("<g mask=\"url(#", ToStr(id_7299), "m)\"><text x=\"", ToStr(Call(f1_16, V.Undef, ((V)((W_7271 / 2D))))), "\" y=\"", ToStr(Call(f1_16, V.Undef, ((V)(((Hh_7272 / 2D) + 3.2))))), "\" text-anchor=\"middle\" font-family=\"", ToStr(SERIF_6130), "\" font-weight=\"700\" font-size=\"9\" letter-spacing=\"0.4\" textLength=\"", ToStr(Call(f1_16, V.Undef, ((V)((W_7271 - 26D))))), "\" lengthAdjust=\"spacingAndGlyphs\" fill=\"#9a3324\">", ToStr(Call(xe_6129, V.Undef, t_7270)), "</text></g>"));
f_7301.S(string.Concat("<g transform=\"translate(6.6 ", NumStr((Hh_7272 / 2D)), ")\" fill=\"#7a5a3a\"><g transform=\"rotate(30)\"><ellipse cy=\"-3.6\" rx=\"1.2\" ry=\"1.8\"/><rect x=\"-0.3\" y=\"-2\" width=\"0.6\" height=\"6\" rx=\"0.3\"/></g><g transform=\"rotate(-30)\"><path d=\"M-1.1 -5.4V-3.4Q-1.1 -2.4 -0.3 -2.2V3.8H0.3V-2.2Q1.1 -2.4 1.1 -3.4V-5.4H0.7V-3.6H0.2V-5.4H-0.2V-3.6H-0.7V-5.4Z\"/></g></g>")).S(string.Concat("<path d=\"M0 1C-1.6 -0.4 -1 -1.8 0 -1C1 -1.8 1.6 -0.4 0 1Z\" transform=\"translate(", ToStr(Call(f1_16, V.Undef, ((V)((W_7271 - 6.6))))), " ", NumStr((Hh_7272 / 2D)), ") scale(1.4)\" fill=\"#b84a3a\"/>"));
g_7302 = Call(shW_6133, V.Undef, C_7297, ((V)(((-W_7271) / 2D))), ((V)(YT_7274)), ((V)(W_7271)), ((V)(Hh_7272)), ((V)(2D)), ((V)(0.36)));
g_7302 = Add(g_7302, Call(box3_4184, V.Undef, C_7297, NewObj(7).Put("c", Arr(((V)(0D)), ((V)(Y0_7273)), ((V)((DP_7276 / 2D))))).Put("w", ((V)(W_7271))).Put("h", ((V)(Hh_7272))).Put("d", ((V)(DP_7276))).Put("col", ((V)("#efe5cc"))).Put("r", ((V)(1D))).Put("dec", NewObj(2).Put("f", ((V)(f_7301.Str))).Put("t", Invoke(Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis7347, int _argc7341, V _a7343, V _a7344, V _a7345, V _a7346, V[] _rest7342) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Call(R_7298, V.Undef)) * (W_7271 - 6D)))))), "\" y=\"0.4\" width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.5 + (ToNum(Call(R_7298, V.Undef)) * 4D)))))), "\" height=\"", ToStr(Call(f1_16, V.Undef, ((V)((DP_7276 - 0.8))))), "\" rx=\"0.4\" fill=\"#c8965a\"/>")));
}, 0, "", true)), "join", ((V)("")))).V).V));
Invoke(Arr(((V)((-ex_7277))), ((V)(ex_7277))), "forEach", Fn((V _arrowThis7355, int _argc7348, V x_7354, V _a7351, V _a7352, V _a7353, V[] _rest7349) => {
return (g_7302 = Add(g_7302, Call(WD_4186, V.Undef, C_7297, x_7354, ((V)((YT_7274 + 0.9))), ((V)(1.5)), ((V)("<circle r=\"0.7\" fill=\"none\" stroke=\"#c99a3e\" stroke-width=\"0.32\"/>")))));
}, 1, "", true));
rb_7303 = Arr(Arr(((V)((-ex_7277))), ((V)((YT_7274 + 0.9))), ((V)(2.2))), Arr(((V)(0D)), ((V)((NY_7275 - 0.6))), ((V)(2.2))), Arr(((V)(ex_7277)), ((V)((YT_7274 + 0.9))), ((V)(2.2))));
g_7302 = Add(g_7302, Add(Call(line3_4191, V.Undef, C_7297, rb_7303, ((V)(1.3)), ((V)("#c8302a"))), Call(line3_4191, V.Undef, C_7297, rb_7303, ((V)(0.55)), ((V)("#ffffff")), ((V)(string.Concat("stroke-dasharray=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.7 * ToNum(k_7300)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.7 * ToNum(k_7300)))))), "\" opacity=\"0.85\""))))));
g_7302 = Add(g_7302, Call(WD_4186, V.Undef, C_7297, ((V)(0D)), ((V)((NY_7275 + 0.6))), ((V)(2.6)), ((V)("<path d=\"M0 1.6C-3 -0.6 -4.4 2.4 -3.6 3.4C-2.6 4.4 -1 3 0 1.8ZM0 1.6C3 -0.6 4.4 2.4 3.6 3.4C2.6 4.4 1 3 0 1.8Z\" fill=\"#c8302a\" stroke=\"#8a1e1a\" stroke-width=\"0.15\"/><path d=\"M-2.4 1.6L-2 3.2M-1.2 1.2L-1 2.8M2.4 1.6L2 3.2M1.2 1.2L1 2.8\" stroke=\"#ffffff\" stroke-width=\"0.35\" opacity=\"0.8\"/><path d=\"M-0.4 2.2L-2.2 6.4L-1.2 6M0.4 2.2L1.8 6.6L2.6 5.8\" stroke=\"#c8302a\" stroke-width=\"1\" fill=\"none\" stroke-linejoin=\"round\"/><circle cy=\"1.8\" r=\"0.9\" fill=\"#a8241e\"/>"))));
s_7304 = Add(Add(Call(swayAt_4192, V.Undef, C_7297, Arr(((V)(0D)), ((V)(NY_7275)), ((V)(1.6))), ((V)(0.9)), ((V)(5.6)), ((V)(0D)), g_7302), Call(cyl3_4185, V.Undef, C_7297, Arr(((V)(0D)), ((V)(NY_7275)), ((V)(0D))), Arr(((V)(0D)), ((V)(NY_7275)), ((V)(3D))), ((V)(0.4)), ((V)("#7d838b")), NewObj(1).Put("n", ((V)(8D))).V)), Call(sp3_6128, V.Undef, C_7297, Arr(((V)(0D)), ((V)(NY_7275)), ((V)(3.1))), ((V)(0.9)), ((V)("#8a8f96"))));
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(DEF19_4188).S("<defs><linearGradient id=\"k101p\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#f8f0da\"/><stop offset=\"1\" stop-color=\"#e4d8ba\"/></linearGradient></defs>").End()))).Put("front", s_7304).Put("bb", Invoke(C_7297, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_7278;
return default;
}, 1, "", true));
}
}
Set(RD_8, "SET27", NewObj(36).Put("KIT-004", NewObj(3).Put("spec", ((V)("menus27"))).Put("live", ((V)("Fluttering coupon"))).Put("note", ((V)("Takeout menus tacked straight onto the wall with plastic push pins: Tony's Pizza (with a grease spot), the Golden Wok, a taped-up Taco Loco flyer whose half-torn coupon flutters, a Burger Barn coupon and a \"pizza Fri!\" sticky note. Below, a cheap white plastic paper-towel holder, one arm cracked and patched with duct tape; the hanging sheet sways."))).V).Put("KIT-024", NewObj(3).Put("spec", ((V)("knife27"))).Put("live", ((V)("Swaying board"))).Put("note", ((V)("A pine-framed chalkboard hung on jute twine from a nail, swaying a little: \"Today's Menu\" in chalk with pastel hearts, a cupcake and a steaming mug, old eraser smudges, chalk and a felt eraser on its ledge. Beside it an acacia magnetic strip holds a chef's knife, bread knife, santoku, a red paring knife, kitchen shears and a honing steel."))).V).Put("KIT-044", NewObj(3).Put("spec", ((V)("copper27"))).Put("live", ((V)("Swaying pans"))).Put("note", ((V)("A black wrought-iron rail on scrolled brackets with polished brass finials. Hammered French copper hangs from S-hooks on long iron handles: a wide skillet, three graded saucepans and a little butter warmer, plus a copper ladle and a brass whisk. Each piece sways gently, its hammered bottom catching the light."))).V).Put("KIT-064", NewObj(3).Put("spec", ((V)("winemap27"))).Put("live", ((V)("Picture lights"))).Put("note", ((V)("Two antique wine maps of Bordeaux and Burgundy on aged parchment, in walnut frames with a gilt fillet and linen mats, each lit by a polished brass picture light whose warm glow softly breathes. Below, a brass gallery rail holds olive-wood and brass utensils: ladle, skimmer, slotted spoon, whisk, fish slice, carving fork and pastry brush."))).V).Put("KIT-084", NewObj(3).Put("spec", ((V)("smart27"))).Put("live", ((V)("Floating orbs"))).Put("note", ((V)("A frameless smoked-glass recipe wall in a champagne-brass bezel, glowing warm. It pages through Saffron Risotto, Lemon Meringue Tart and Coq au Vin with the current step lit, a timer ring and the ingredients. Beside it, two floating walnut shelves of glass spice orbs (saffron, paprika, turmeric, pink pepper, cardamom, black pepper, fleur de sel, sumac) bob over soft pools of light."))).V).Put("KIT-101", NewObj(3).Put("spec", ((V)("ksign27"))).Put("live", ((V)("Swaying sign"))).Put("note", ((V)("A hand-painted pine board in soft cream, chipped to bare wood at the edges, with your word painted in barn red inside a sage border, a crossed spoon and fork and a little heart. It hangs on a red gingham ribbon tied in a bow on a nail and sways a little. Tap to change the writing."))).V).Put("KIT-001", NewObj(3).Put("s12", ((V)("k01dry"))).Put("live", ((V)("Dripping grease"))).Put("note", ((V)("Builder-beige drywall behind the stove: taped and mudded joints, screw pops, an unpainted spackle patch, a yellow haze from years of frying and amber grease splatter with runs (one drip slowly forms and falls), a scorch mark and a greasy outlet. The vinyl base is peeling."))).V).Put("KIT-021", NewObj(3).Put("s12", ((V)("k21vin"))).Put("live", ((V)("Peeling corner"))).Put("note", ((V)("Peel-and-stick vinyl \"subway tile\" sheets over mint paint. The grout lines are printed flat and every tile has the same printed shine. The sheet seams do not quite line up, there are air bubbles, a rough cut round the outlet and one corner peeling off its sticky back. Cherry-red vinyl base."))).V).Put("KIT-041", NewObj(3).Put("s12", ((V)("k41herr"))).Put("live", ((V)("Glinting glaze"))).Put("note", ((V)("Glossy white subway tile laid in a true 45 degree herringbone, every tile a slightly different white with a glazed bevel, under eggshell sage walls, finished with a bullnose cap. A soft glint slides over the glaze."))).V).Put("KIT-061", NewObj(2).Put("s12", ((V)("k61cop"))).Put("note", ((V)("Hand-hammered copper sheets with hundreds of little dents catching the light in rose, gold and brown, joined by standing seams with domed copper rivets and a polished half-round cap, under soft troweled Venetian lime plaster."))).V).Put("KIT-081", NewObj(3).Put("s12", ((V)("k81qtz"))).Put("live", ((V)("Recipe display"))).Put("note", ((V)("Floor-to-ceiling book-matched Patagonia quartzite lit from behind: milky quartz with clusters of black, smoky and caramel crystals, mirrored at a brass seam. A frameless smoked-glass display set into the stone pages through recipes with a timer ring. Bronze plinth with a champagne light line."))).V).Put("KIT-012", NewObj(3).Put("w19", ((V)("khop"))).Put("live", ((V)("Passing pigeon"))).Put("note", ((V)("A tiny hopper window high up in a deep concrete well, the steel frame chipped and rusting down the wall. The sash tilts in on two arms, the insect screen is rusty and torn at a corner, and through the grimy glass you see the grass at ground level: a dandelion clock sways, a pigeon struts past, a snail creeps along."))).V).Put("KIT-032", NewObj(3).Put("w19", ((V)("kging"))).Put("live", ((V)("Swaying curtains"))).Put("note", ((V)("A white double-hung window with red gingham cafe curtains on a brass tension rod and a gathered valance. Outside, laundry sways on the line and a little bird visits the swinging feeder. A geranium sits on the sill and a glass suncatcher throws rainbow spots."))).V).Put("KIT-052", NewObj(3).Put("w19", ((V)("kgreen"))).Put("live", ((V)("Swaying herbs"))).Put("note", ((V)("A glass greenhouse box pushed out past the wall, with a glass shelf and a zinc pebble tray full of terracotta pots: basil, rosemary, chives, thyme, mint and parsley all swaying in the sun. Sunbeams fall through the panes, a butterfly flits in the garden and a brass watering can waits on the stone sill."))).V).Put("KIT-072", NewObj(3).Put("w19", ((V)("kaccord"))).Put("live", ((V)("Folding panels"))).Put("note", ((V)("Six thin black-steel glass panels that fold open like an accordion and close again, turning the window into a pass-through bar. The walnut bar top runs out onto the patio ledge, with cocktail coupes and a brass bowl of lemons; outside, string lights twinkle over a golden-hour terrace."))).V).Put("KIT-092", NewObj(3).Put("w19", ((V)("khydro"))).Put("live", ((V)("Living farm"))).Put("note", ((V)("Frameless floor-to-ceiling glass on a golden-hour valley, lined with polished brass gutters on fine hangers: butterhead lettuce, basil, kale, herbs and strawberries that slowly ripen. Warm grow-light bars glow down, water trickles gutter to gutter, mist puffs now and then, over a bronze planter base with a champagne light line."))).V).Put("KIT-014", NewObj(3).Put("spec", ((V)("pine27"))).Put("live", ((V)("Swaying towel"))).Put("note", ((V)("A knotty pine plank on bent, rusty iron brackets that have left drip stains on the wall. On it: a mason jar of wooden spoons, a chipped \"#1 COOK\" mug, a dented can of beans, a blue salt tub, Grandma's recipe book and a pothos trailing down. A plaid tea towel sways on a cup hook and a tiny spider bobs on its thread."))).V).Put("KIT-034", NewObj(3).Put("spec", ((V)("lam27"))).Put("live", ((V)("Swaying mugs"))).Put("note", ((V)("Cheap white laminate wall cabinets with yellowed edge banding (one strip peeling), chrome bar pulls and a left door that sags a little. The right door is left ajar on cans, peanut butter and cereal. A dusty basket and cookie tin sit on top, a strip light flickers underneath and three mugs sway on hooks."))).V).Put("KIT-054", NewObj(3).Put("spec", ((V)("china27"))).Put("live", ((V)("Glowing cabinet"))).Put("note", ((V)("A creamy painted shaker hutch with brass knobs and cup pulls under a honed marble counter with a lemon cake on a stand. Above, two glass doors with mullions show a warm-lit interior: blue-and-white plates on a brass plate rail, teacups on saucers, bowl stacks, a tureen and a pitcher."))).V).Put("KIT-074", NewObj(3).Put("spec", ((V)("butler27"))).Put("live", ((V)("Turning carousels"))).Put("note", ((V)("A butler's pantry in deep green lacquer with brass bin pulls and little labelled spice drawers under a Calacatta marble counter. Open walnut shelves lit by warm strips hold glass canisters, copper pots and cookbooks, copper ladles hang from a brass rail, and two brass spice carousels slowly turn on the counter."))).V).Put("KIT-094", NewObj(4).Put("name", ((V)("Patisserie Pantry"))).Put("spec", ((V)("patis27"))).Put("live", ((V)("Turning cake stand"))).Put("note", ((V)("A cream lacquer and polished brass patisserie cabinet on a bronze plinth with a champagne light line, under a blush-and-cream scalloped awning. In the middle an arched glass vitrine glows pink, and a three-tier brass cake stand slowly turns: cupcakes, macaron towers and little cakes, with a strawberry cake on top. On each side a glass candy cabinet of apothecary jars (gumballs, lollipops, jelly beans, peppermints, cookies, marshmallows) twinkles over labelled drawers."))).V).Put("KIT-005", NewObj(2).Put("f27", ((V)("ylino"))).Put("note", ((V)("Old mustard-yellow vinyl squares with a marbled swirl, laid quarter-turned. Grime in the seams, cracked tiles, four corners curling up off the black glue, one tile missing (combed tar and stuck bits), grease spots in front of the stove and a scorched pot ring."))).V).Put("KIT-025", NewObj(2).Put("f27", ((V)("diner"))).Put("note", ((V)("Glossy black and white vinyl checkerboard like a 50s diner, each tile flecked with little chips, framed by a cherry-red border and a polished chrome strip. Waxed to a shine, with a few heel scuffs."))).V).Put("KIT-045", NewObj(2).Put("f27", ((V)("quarry"))).Put("note", ((V)("Hand-made terracotta quarry tiles in fired orange to brick-brown, with wavy edges, darker kiln flashing, pits and chalky bloom, set in warm sandy grout. A cat walked over three of them before they were fired."))).V).Put("KIT-065", NewObj(2).Put("f27", ((V)("oak"))).Put("note", ((V)("Wide smoky French oak planks of random lengths: wire-brushed grain, cracked knots, hand-scraped ripples, old dents and wormholes, square oak pegs at the board ends and dark open joints, finished with a low oiled sheen."))).V).Put("KIT-085", NewObj(3).Put("f27", ((V)("cush"))).Put("live", ((V)("Self-sweeping"))).Put("note", ((V)("Large book-matched cream Calacatta slabs with soft pillowed edges that spring back underfoot, their grey and gold veins flowing from slab to slab. Polished brass seams glow warm from the heating, brass keystones glint at the corners, and gold dust drifts into a bronze-and-brass vacuum plinth under a champagne light."))).V).Put("KIT-009", NewObj(3).Put("c27", ((V)("acou"))).Put("live", ((V)("Rattling fan"))).Put("note", ((V)("An old drop ceiling of fissured acoustic tiles in a yellowed metal grid. Brown leak rings, one soggy tile sagging out of the grid, one tile missing with a wire loop hanging out, and over the stove a grease-caked exhaust fan that spins, rattles and drips."))).V).Put("KIT-029", NewObj(3).Put("c27", ((V)("bead"))).Put("live", ((V)("Steam curls"))).Put("note", ((V)("A cosy painted beadboard ceiling in soft buttercream: tongue-and-groove boards with rounded beads, nail heads and brush marks, a bundle of drying herbs on a brass hook, and steam from the under-cabinet hood curling along the boards."))).V).Put("KIT-049", NewObj(2).Put("c27", ((V)("pots"))).Put("note", ((V)("A smooth matte white ceiling with eight recessed pot lights glowing warm in their grooved trims, a flush speaker grille, a slim slot vent by the stainless chimney hood and a crisp shadow-gap edge."))).V).Put("KIT-069", NewObj(3).Put("c27", ((V)("tray"))).Put("live", ((V)("Glowing cove"))).Put("note", ((V)("Hand-troweled Venetian lime plaster with soft burnished sweeps. Above the island a recessed tray lined with hand-laid gold leaf glows from a hidden warm cove, edged in polished brass, under a deep plaster crown that goes with the brass canopy hood."))).V).Put("KIT-017", NewObj(4).Put("spec", ((V)("fluor27"))).Put("s3", V.Null).Put("live", ((V)("Flickering tube"))).Put("note", ((V)("A bare fluorescent strip hung on two chains: a grubby enamel channel with two tubes, one burnt black at the end with a couple of dead bugs inside. The old tube stutters now and then and the pull-chain sways."))).V).Put("KIT-037", NewObj(4).Put("spec", ((V)("barn27"))).Put("s3", V.Null).Put("live", ((V)("Swaying shade"))).Put("note", ((V)("A farmhouse barn pendant in glossy green porcelain enamel with a wide rolled white rim, chipped to black steel in a few spots, on a braided cloth cord. It sways gently with the bulb peeking under the rim."))).V).Put("KIT-057", NewObj(4).Put("spec", ((V)("globe27"))).Put("s3", V.Null).Put("live", ((V)("Glowing filaments"))).Put("note", ((V)("Three ribbed clear glass globes on a slim brass canopy bar. Through the fine ribs you see an amber Edison bulb in each, its looped filament glowing, and every globe sways on its own cord."))).V).Put("KIT-077", NewObj(4).Put("spec", ((V)("alab27"))).Put("s3", V.Null).Put("live", ((V)("Glowing alabaster"))).Put("note", ((V)("A long hand-forged brass bar with scrolled ends, hammer marks catching the light, holding five veined alabaster drums in brass cups. Each stone glows warm from inside and a glint slides along the brass."))).V).Put("KIT-097", NewObj(4).Put("spec", ((V)("herb27"))).Put("s3", V.Null).Put("live", ((V)("Living herbs"))).Put("note", ((V)("A polished brass halo on four fine cables, planted all round with living basil, purple basil, rosemary and thyme. Trailing thyme hangs over the edge, a warm grow-light glows under the ring and dew twinkles on the leaves."))).V).Put("KIT-089", NewObj(3).Put("c27", ((V)("onyx"))).Put("live", ((V)("Whisper vortex"))).Put("note", ((V)("Book-matched slabs of honey onyx lit from behind so the whole ceiling glows warm, joined by polished brass seams. In the middle a brass-rimmed vortex slowly turns its brass vanes, drawing in drifting gold motes without a sound."))).V).V);
edit26_89 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis7363, int _argc7356, V rows_7362, V _a7359, V _a7360, V _a7361, V[] _rest7357) => {
return Invoke(Call(edit26_89, V.Undef, rows_7362), "map", Fn((V _arrowThis7371, int _argc7364, V r_7370, V _a7367, V _a7368, V _a7369, V[] _rest7365) => {
return (Truthy(GetK(Get(RD_8, "SET27"), Get(r_7370, "id"))) ? Object_assign(NewObj(0).V, r_7370, GetK(Get(RD_8, "SET27"), Get(r_7370, "id"))) : r_7370);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H27", NewObj(11).Put("FLOOR27", FLOOR27_85).Put("CEIL27", CEIL27_63).Put("rrW", rrW_34).Put("quadW", quadW_31).Put("dot", dot_32).Put("dotD", dotD_33).Put("walk", walk_36).Put("cE", cE_49).Put("cHi", cHi_50).Put("cDoc", cDoc_54).Put("cShade", cShade_53).V);
Set(RD_8, "PLUS27", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
