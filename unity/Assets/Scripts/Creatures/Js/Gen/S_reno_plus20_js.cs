// reno-plus20.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus20_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("GOLDX", "g");
        public static void Run()
        {
Call(Named(boot_517 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
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
V px_19 = default;
V crv_20 = default;
V fblot_21 = default;
V FL_22 = default;
V TR_23 = default;
V wk_24 = default;
V gv_25 = default;
V W_26 = default;
V WP_27 = default;
V polyW_28 = default;
V lineW_29 = default;
V crvW_30 = default;
V chip_31 = default;
V ell_32 = default;
V refl_33 = default;
V fLino_34 = default;
V fLam_35 = default;
V fChev_36 = default;
V fTerr_37 = default;
V fOnyx_38 = default;
V FLOOR20_39 = default;
V MEMO_40 = default;
V draw19_41 = default;
V N_42 = default;
V cam_43 = default;
V slab_44 = default;
V top_45 = default;
V face_46 = default;
V rrP_47 = default;
V dP_48 = default;
V ellP_49 = default;
V DEF20_50 = default;
V RUG_51 = default;
V smooth_52 = default;
V blob_53 = default;
V fringe_54 = default;
V edit19_55 = default;
if (_self1.IsNullish) _self1 = GlobalV;
fLino_34 = Fn((V _self56, int _argc57, V _a59, V _a60, V _a61, V _a62, V[] _rest58) => {
V R_63 = default;
double NU_64 = 0;
double NV_65 = 0;
V T_66 = default;
JsStrBuf s_67 = null;
JsStrBuf hi_68 = null;
JsStrBuf lo_69 = null;
JsStrBuf dia_70 = null;
V path_71 = default;
if (_self56.IsNullish) _self56 = GlobalV;
R_63 = Call(rng_13, V.Undef, ((V)("lino20")));
NU_64 = 14D;
NV_65 = 9D;
T_66 = Arr(((V)("#dacfae")), ((V)("#d2c5a1")), ((V)("#ded4b6")), ((V)("#cdbf99")));
s_67 = new JsStrBuf("<rect width=\"80\" height=\"56\" fill=\"#b6a77f\"/>");
hi_68 = new JsStrBuf("");
lo_69 = new JsStrBuf("");
dia_70 = new JsStrBuf("");
{
double j_72 = 0;
j_72 = 0D;
while (true) {
if (!((j_72 < NV_65))) break;
{
double i_74 = 0;
i_74 = 0D;
while (true) {
if (!((i_74 < NU_64))) break;
double u0_76 = 0;
double u1_77 = 0;
double y0_78 = 0;
double y1_79 = 0;
u0_76 = ((i_74 / NU_64) + 0.005);
u1_77 = (((i_74 + 1D) / NU_64) - 0.005);
y0_78 = ((j_72 / NV_65) + 0.008);
y1_79 = (((j_72 + 1D) / NV_65) - 0.008);
s_67.S(string.Concat("<path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(((V)(u0_76)), ((V)(y0_78))), Arr(((V)(u1_77)), ((V)(y0_78))), Arr(((V)(u1_77)), ((V)(y1_79))), Arr(((V)(u0_76)), ((V)(y1_79)))))), "\" fill=\"", ToStr(GetIdx(T_66, ((((i_74 * 7D) + (j_72 * 3D)) + ((double)(ToInt32((ToNum(Call(R_63, V.Undef)) * 3D)) | ToInt32(0D)))) % 4D))), "\"/>"));
hi_68.V(Call(lineW_29, V.Undef, Arr(Arr(((V)(u0_76)), ((V)(y1_79))), Arr(((V)(u0_76)), ((V)(y0_78))), Arr(((V)(u1_77)), ((V)(y0_78))))));
lo_69.V(Call(lineW_29, V.Undef, Arr(Arr(((V)(u1_77)), ((V)(y0_78))), Arr(((V)(u1_77)), ((V)(y1_79))), Arr(((V)(u0_76)), ((V)(y1_79))))));
i_74++;
}
}
j_72++;
}
}
s_67.V(Call(fblot_21, V.Undef, ((V)("lino")), ((V)(30D)), Arr(((V)("#e6dcc0")), ((V)("#bfb08a")), ((V)("#d8cba6"))), ((V)(0.42)), ((V)(6D))));
s_67.S(string.Concat("<path d=\"", hi_68.Str, "\" stroke=\"#f4ecd6\" stroke-width=\"0.28\" fill=\"none\" opacity=\"0.8\"/><path d=\"", lo_69.Str, "\" stroke=\"#a6976f\" stroke-width=\"0.28\" fill=\"none\" opacity=\"0.7\"/>"));
{
double j_80 = 0;
j_80 = 1D;
while (true) {
if (!((j_80 < NV_65))) break;
{
double i_82 = 0;
i_82 = 1D;
while (true) {
if (!((i_82 < NU_64))) break;
double u_84 = 0;
double y_85 = 0;
double a_86 = 0;
double b_87 = 0;
u_84 = (i_82 / NU_64);
y_85 = (j_80 / NV_65);
a_86 = 0.011;
b_87 = 0.017;
dia_70.V(Call(polyW_28, V.Undef, Arr(Arr(((V)(u_84)), ((V)((y_85 - b_87)))), Arr(((V)((u_84 + a_86))), ((V)(y_85))), Arr(((V)(u_84)), ((V)((y_85 + b_87)))), Arr(((V)((u_84 - a_86))), ((V)(y_85))))));
i_82++;
}
}
j_80++;
}
}
s_67.S(string.Concat("<path d=\"", dia_70.Str, "\" fill=\"#8c7a54\"/><path d=\"", dia_70.Str, "\" fill=\"none\" stroke=\"#c9b88e\" stroke-width=\"0.12\"/>"));
s_67.V(Invoke(Call(rep_18, V.Undef, ((V)(320D)), Fn((V _arrowThis94, int _argc88, V _a90, V _a91, V _a92, V _a93, V[] _rest89) => {
V u_95 = default;
V y_96 = default;
V p_97 = default;
u_95 = Call(R_63, V.Undef);
y_96 = Call(R_63, V.Undef);
p_97 = Call(W_26, V.Undef, u_95, y_96);
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_97, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_97, 1D))), "\" r=\"", ToStr(Call(f1_16, V.Undef, ((V)(((0.1 + (ToNum(Call(R_63, V.Undef)) * 0.16)) * ToNum(Call(wk_24, V.Undef, Call(gv_25, V.Undef, y_96)))))))), "\" fill=\"", (LtN(Call(R_63, V.Undef), 0.55) ? "#9a8b66" : "#efe7cf"), "\" opacity=\"0.7\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
s_67.S(string.Concat("<path d=\"", ToStr(TR_23), "\" fill=\"none\" stroke=\"#b8974e\" stroke-width=\"7\" opacity=\"0.22\" filter=\"url(#fb3)\"/>")).S("<g filter=\"url(#fb3)\">").V(Call(ell_32, V.Undef, ((V)(0.02)), ((V)(0.05)), ((V)(6D)), ((V)(3D)), ((V)("fill=\"#6e5c3a\" opacity=\"0.3\"")))).V(Call(ell_32, V.Undef, ((V)(0.98)), ((V)(0.05)), ((V)(6D)), ((V)(3D)), ((V)("fill=\"#6e5c3a\" opacity=\"0.3\"")))).S("</g>");
path_71 = Call(crvW_30, V.Undef, Arr(Arr(((V)(0.4)), ((V)(1.08))), Arr(((V)(0.44)), ((V)(0.78))), Arr(((V)(0.54)), ((V)(0.48))), Arr(((V)(0.62)), ((V)(0.18))), Arr(((V)(0.64)), ((V)((-0.05))))));
s_67.S(string.Concat("<g filter=\"url(#fb3)\"><path d=\"", ToStr(path_71), "\" stroke=\"#8f805e\" stroke-width=\"15\" fill=\"none\" opacity=\"0.13\"/><path d=\"", ToStr(path_71), "\" stroke=\"#f4eed9\" stroke-width=\"9\" fill=\"none\" opacity=\"0.45\"/></g>"));
s_67.V(Invoke(Call(rep_18, V.Undef, ((V)(20D)), Fn((V _arrowThis104, int _argc98, V _a100, V _a101, V _a102, V _a103, V[] _rest99) => {
V y_105 = default;
double u_106 = 0;
V p_107 = default;
V k_108 = default;
double l_109 = 0;
double a_110 = 0;
y_105 = Call(R_63, V.Undef);
u_106 = ((0.36 + (0.26 * (1D - ToNum(y_105)))) + ((ToNum(Call(R_63, V.Undef)) - 0.5) * 0.2));
p_107 = Call(W_26, V.Undef, ((V)(u_106)), y_105);
k_108 = Call(wk_24, V.Undef, Call(gv_25, V.Undef, y_105));
l_109 = ((1D + (ToNum(Call(R_63, V.Undef)) * 2.4)) * ToNum(k_108));
a_110 = ((ToNum(Call(R_63, V.Undef)) - 0.5) * 1.4);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, GetIdx(p_107, 0D))), " ", ToStr(Call(f1_16, V.Undef, GetIdx(p_107, 1D))), "q", ToStr(Call(f1_16, V.Undef, ((V)(((l_109 * 0.5) * FdLibm.Cos(a_110)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.4) * ToNum(k_108)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((l_109 * FdLibm.Cos(a_110)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((l_109 * FdLibm.Sin(a_110)) * 0.5))))), "\" stroke=\"#36302a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)(((0.16 + (ToNum(Call(R_63, V.Undef)) * 0.26)) * ToNum(k_108)))))), "\" stroke-linecap=\"round\" fill=\"none\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.35 + (ToNum(Call(R_63, V.Undef)) * 0.35)))))), "\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
s_67.S(string.Concat("<path d=\"", ToStr(Call(lineW_29, V.Undef, Arr(Arr(((V)(0.71)), ((V)(0D))), Arr(((V)(0.71)), ((V)(1D)))))), "\" stroke=\"#f2ead2\" stroke-width=\"0.2\" opacity=\"0.8\" transform=\"translate(0.18 0)\"/><path d=\"", ToStr(Call(lineW_29, V.Undef, Arr(Arr(((V)(0.71)), ((V)(0D))), Arr(((V)(0.71)), ((V)(1D)))))), "\" stroke=\"#8a7b58\" stroke-width=\"0.18\" opacity=\"0.8\"/>"));
s_67.S(string.Concat("<path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(((V)(0.703)), ((V)(0.9))), Arr(((V)(0.71)), ((V)(0.9))), Arr(((V)(0.71)), ((V)(1.02))), Arr(((V)(0.698)), ((V)(1.02)))))), "\" fill=\"#000000\" opacity=\"0.2\" filter=\"url(#fb1)\"/><path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(((V)(0.71)), ((V)(0.88))), Arr(((V)(0.713)), ((V)(0.92))), Arr(((V)(0.716)), ((V)(1.02))), Arr(((V)(0.71)), ((V)(1.02)))))), "\" fill=\"#3e3326\"/>"));
s_67.S(string.Concat("<path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(((V)(0.711)), ((V)(0.88))), Arr(((V)(0.715)), ((V)(0.92))), Arr(((V)(0.719)), ((V)(1.02))), Arr(((V)(0.714)), ((V)(1.02))), Arr(((V)(0.711)), ((V)(0.92)))))), "\" fill=\"#e4d9bb\" transform=\"translate(0 -0.45)\"/><path d=\"", ToStr(Call(lineW_29, V.Undef, Arr(Arr(((V)(0.711)), ((V)(0.88))), Arr(((V)(0.715)), ((V)(0.93))), Arr(((V)(0.718)), ((V)(1.02)))))), "\" stroke=\"#fbf6e8\" stroke-width=\"0.28\" fill=\"none\" transform=\"translate(0 -0.5)\"/>"));
s_67.V(Add(Add(Call(ell_32, V.Undef, ((V)(0.27)), ((V)(0.42)), ((V)(1.9)), ((V)(0.85)), ((V)("fill=\"#8a5a32\" opacity=\"0.4\" filter=\"url(#fb1)\""))), Call(ell_32, V.Undef, ((V)(0.27)), ((V)(0.42)), ((V)(0.9)), ((V)(0.42)), ((V)("fill=\"#3a2416\" opacity=\"0.7\"")))), Call(ell_32, V.Undef, ((V)(0.27)), ((V)(0.42)), ((V)(1.25)), ((V)(0.58)), ((V)("fill=\"none\" stroke=\"#5a3a20\" stroke-width=\"0.2\" opacity=\"0.6\"")))));
{
V p_111 = default;
V k_112 = default;
V Q_113 = default;
V pts_114 = default;
V d_115 = default;
p_111 = Call(W_26, V.Undef, ((V)(0.17)), ((V)(0.87)));
k_112 = Call(wk_24, V.Undef, Call(gv_25, V.Undef, ((V)(0.87))));
Q_113 = Call(rng_13, V.Undef, ((V)("tear20")));
pts_114 = Call(rep_18, V.Undef, ((V)(11D)), Fn((V _arrowThis123, int _argc116, V i_122, V _a119, V _a120, V _a121, V[] _rest117) => {
double a_124 = 0;
double r_125 = 0;
a_124 = (((ToNum(i_122) / 11D) * 2D) * PI_11);
r_125 = (0.75 + (ToNum(Call(Q_113, V.Undef)) * 0.45));
return Arr(Add(GetIdx(p_111, 0D), ((V)((((2.6 * ToNum(k_112)) * r_125) * FdLibm.Cos(a_124))))), Add(GetIdx(p_111, 1D), ((V)((((1.25 * ToNum(k_112)) * r_125) * FdLibm.Sin(a_124))))));
return default;
}, 1, "", true));
d_115 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_114, "map", Fn((V _arrowThis133, int _argc126, V q_132, V _a129, V _a130, V _a131, V[] _rest127) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, GetIdx(q_132, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(q_132, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
s_67.S(string.Concat("<path d=\"", ToStr(d_115), "\" fill=\"#b08a58\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(p_111, 0D)) - (2D * ToNum(k_112))))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(p_111, 1D)) - (0.3 * ToNum(k_112))))))), "q", ToStr(Call(f1_16, V.Undef, ((V)((2D * ToNum(k_112)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((0.3 * ToNum(k_112)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((4D * ToNum(k_112)))))), " 0M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(p_111, 0D)) - (1.6 * ToNum(k_112))))))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(p_111, 1D), ((V)((0.5 * ToNum(k_112))))))), "q", ToStr(Call(f1_16, V.Undef, ((V)((1.6 * ToNum(k_112)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((-0.3) * ToNum(k_112)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((3.4 * ToNum(k_112)))))), " 0\" stroke=\"#7d5c38\" stroke-width=\"0.18\" fill=\"none\"/>")).S(string.Concat("<path d=\"", ToStr(d_115), "\" fill=\"none\" stroke=\"#f1ead4\" stroke-width=\"0.35\"/><path d=\"M", ToStr(Call(f1_16, V.Undef, GetIdx(GetIdx(pts_114, 2D), 0D))), " ", ToStr(Call(f1_16, V.Undef, GetIdx(GetIdx(pts_114, 2D), 1D))), "L", ToStr(Call(f1_16, V.Undef, Add(GetIdx(p_111, 0D), ((V)((3.6 * ToNum(k_112))))))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(p_111, 1D), ((V)((2.2 * ToNum(k_112))))))), "L", ToStr(Call(f1_16, V.Undef, GetIdx(GetIdx(pts_114, 0D), 0D))), " ", ToStr(Call(f1_16, V.Undef, GetIdx(GetIdx(pts_114, 0D), 1D))), "Z\" fill=\"#000000\" opacity=\"0.25\" filter=\"url(#fb1)\"/>")).S(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, GetIdx(GetIdx(pts_114, 2D), 0D))), " ", ToStr(Call(f1_16, V.Undef, GetIdx(GetIdx(pts_114, 2D), 1D))), "Q", ToStr(Call(f1_16, V.Undef, Add(GetIdx(p_111, 0D), ((V)((3.4 * ToNum(k_112))))))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(p_111, 1D), ((V)((0.4 * ToNum(k_112))))))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(p_111, 0D), ((V)((3.2 * ToNum(k_112))))))), " ", ToStr(Call(f1_16, V.Undef, Add(GetIdx(p_111, 1D), ((V)((1.8 * ToNum(k_112))))))), "L", ToStr(Call(f1_16, V.Undef, GetIdx(GetIdx(pts_114, 0D), 0D))), " ", ToStr(Call(f1_16, V.Undef, GetIdx(GetIdx(pts_114, 0D), 1D))), "Z\" fill=\"#8f897d\" stroke=\"#efe6cc\" stroke-width=\"0.2\"/>"));
}
return Call(FL_22, V.Undef, ((V)(s_67.Str)));
return default;
}, 0, "fLino", false);
fLam_35 = Fn((V _self134, int _argc135, V _a137, V _a138, V _a139, V _a140, V[] _rest136) => {
double NP_141 = 0;
V R_142 = default;
V PC_143 = default;
double L_144 = 0;
JsStrBuf s_145 = null;
JsStrBuf gr_146 = null;
JsStrBuf cat_147 = null;
JsStrBuf ends_148 = null;
JsStrBuf kn_149 = null;
JsStrBuf jn_150 = null;
V PR_151 = default;
double pi_152 = 0;
if (_self134.IsNullish) _self134 = GlobalV;
NP_141 = 22D;
R_142 = Call(rng_13, V.Undef, ((V)("lam20")));
PC_143 = Arr(((V)("#c99560")), ((V)("#d4a36c")), ((V)("#bf8b56")), ((V)("#dbad78")), ((V)("#c6915b")), ((V)("#cf9c64")));
L_144 = 0.46;
s_145 = new JsStrBuf("<rect width=\"80\" height=\"56\" fill=\"#5a3a1e\"/>");
gr_146 = new JsStrBuf("");
cat_147 = new JsStrBuf("");
ends_148 = new JsStrBuf("");
kn_149 = new JsStrBuf("");
jn_150 = new JsStrBuf("");
PR_151 = Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis160, int _argc153, V k_159, V _a156, V _a157, V _a158, V[] _rest154) => {
V Q_161 = default;
Q_161 = Call(rng_13, V.Undef, ((V)(JsStrBuf.Begin().S("lp20").V(k_159).End())));
return NewObj(4).Put("tone", k_159).Put("lines", Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis168, int _argc162, V _a164, V _a165, V _a166, V _a167, V[] _rest163) => {
return NewObj(4).Put("f", ((V)((0.1 + (ToNum(Call(Q_161, V.Undef)) * 0.8))))).Put("a", ((V)((0.05 + (ToNum(Call(Q_161, V.Undef)) * 0.1))))).Put("ph", ((V)((ToNum(Call(Q_161, V.Undef)) * 6D)))).Put("w", ((V)((1D + (ToNum(Call(Q_161, V.Undef)) * 2D))))).V;
}, 0, "", true))).Put("cat", (NumTruthy((ToNum(k_159) % 2D)) ? V.Null : NewObj(2).Put("f", ((V)((0.35 + (ToNum(Call(Q_161, V.Undef)) * 0.3))))).Put("y", ((V)((0.2 + (ToNum(Call(Q_161, V.Undef)) * 0.4))))).V)).Put("knot", (SEqN(k_159, 3D) ? NewObj(2).Put("f", ((V)((0.3 + (ToNum(Call(Q_161, V.Undef)) * 0.4))))).Put("y", ((V)((0.3 + (ToNum(Call(Q_161, V.Undef)) * 0.4))))).V : V.Null)).V;
return default;
}, 1, "", true));
pi_152 = 0D;
{
double i_169 = 0;
i_169 = 0D;
while (true) {
if (!((i_169 < NP_141))) break;
double u0_171 = 0;
double u1_172 = 0;
double cw_173 = 0;
double y_174 = 0;
u0_171 = (i_169 / NP_141);
u1_172 = ((i_169 + 1D) / NP_141);
cw_173 = (u1_172 - u0_171);
y_174 = (-(((i_169 * 0.37) + (ToNum(Call(R_142, V.Undef)) * 0.08)) % L_144));
jn_150.V(Call(lineW_29, V.Undef, Arr(Arr(((V)(u0_171)), ((V)(0D))), Arr(((V)(u0_171)), ((V)(1D))))));
while ((y_174 < 1D)) {
V P_175 = default;
double ya_176 = 0;
double yb_177 = 0;
P_175 = GetIdx(PR_151, (pi_152 % 4D));
ya_176 = Max(y_174, (-0.02));
yb_177 = Min((y_174 + L_144), 1.02);
pi_152++;
s_145.S(string.Concat("<path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(((V)(u0_171)), ((V)(ya_176))), Arr(((V)(u1_172)), ((V)(ya_176))), Arr(((V)(u1_172)), ((V)(yb_177))), Arr(((V)(u0_171)), ((V)(yb_177)))))), "\" fill=\"", ToStr(Call(shade_10, V.Undef, GetIdx(PC_143, (((ToNum(Get(P_175, "tone")) * 2D) + i_169) % 6D)), ((V)((0.96 + (ToNum(Call(R_142, V.Undef)) * 0.08)))))), "\"/>"));
Invoke(Get(P_175, "lines"), "forEach", Fn((V _arrowThis185, int _argc178, V g_184, V _a181, V _a182, V _a183, V[] _rest179) => {
gr_146.V(Call(crvW_30, V.Undef, Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis193, int _argc186, V j_192, V _a189, V _a190, V _a191, V[] _rest187) => {
double t_194 = 0;
t_194 = (ToNum(j_192) / 6D);
return Arr(((V)((u0_171 + (cw_173 * Min(0.95, Max(0.05, ToNum(Add(Get(g_184, "f"), ((V)((ToNum(Get(g_184, "a")) * FdLibm.Sin(ToNum(Add(((V)(((t_194 * ToNum(Get(g_184, "w"))) * 3D))), Get(g_184, "ph"))))))))))))))), ((V)((y_174 + (t_194 * L_144)))));
return default;
}, 1, "", true))));
return default;
}, 1, "", true));
if (Truthy(Get(P_175, "cat"))) {
double uc_195 = 0;
double yc_196 = 0;
uc_195 = (u0_171 + (cw_173 * ToNum(Get(Get(P_175, "cat"), "f"))));
yc_196 = (y_174 + (L_144 * ToNum(Get(Get(P_175, "cat"), "y"))));
{
double n_197 = 0;
n_197 = 1D;
while (true) {
if (!((n_197 <= 3D))) break;
double w_199 = 0;
double h_200 = 0;
w_199 = ((cw_173 * 0.1) * n_197);
h_200 = ((L_144 * 0.13) * n_197);
cat_147.V(Call(crvW_30, V.Undef, Arr(Arr(((V)((uc_195 - w_199))), ((V)((yc_196 + h_200)))), Arr(((V)((uc_195 - (w_199 * 0.6)))), ((V)((yc_196 + (h_200 * 0.35))))), Arr(((V)(uc_195)), ((V)(yc_196))), Arr(((V)((uc_195 + (w_199 * 0.6)))), ((V)((yc_196 + (h_200 * 0.35))))), Arr(((V)((uc_195 + w_199))), ((V)((yc_196 + h_200)))))));
n_197++;
}
}
}
if (Truthy(Get(P_175, "knot"))) {
kn_149.V(Call(ell_32, V.Undef, ((V)((u0_171 + (cw_173 * ToNum(Get(Get(P_175, "knot"), "f")))))), ((V)((y_174 + (L_144 * ToNum(Get(Get(P_175, "knot"), "y")))))), ((V)(0.42)), ((V)(0.2)), ((V)("fill=\"#6a4222\" opacity=\"0.7\""))));
}
if ((y_174 > 0D)) {
ends_148.V(Call(lineW_29, V.Undef, Arr(Arr(((V)(u0_171)), ((V)(y_174))), Arr(((V)(u1_172)), ((V)(y_174))))));
}
y_174 = (y_174 + L_144);
}
i_169++;
}
}
s_145.S(string.Concat("<path d=\"", gr_146.Str, "\" stroke=\"#7a4c26\" stroke-width=\"0.17\" fill=\"none\" opacity=\"0.22\"/><path d=\"", cat_147.Str, "\" stroke=\"#7a4c26\" stroke-width=\"0.2\" fill=\"none\" opacity=\"0.32\"/>", kn_149.Str));
s_145.V(Call(fblot_21, V.Undef, ((V)("lam")), ((V)(16D)), Arr(((V)("#e6b884")), ((V)("#9c6a3a"))), ((V)(0.22)), ((V)(8D))));
s_145.S(string.Concat("<path d=\"", jn_150.Str, "\" stroke=\"#f3cf98\" stroke-width=\"0.14\" opacity=\"0.4\" transform=\"translate(0.24 0)\"/><path d=\"", jn_150.Str, "\" stroke=\"#5e3a1c\" stroke-width=\"0.2\" opacity=\"0.85\"/><path d=\"", ends_148.Str, "\" stroke=\"#f3cf98\" stroke-width=\"0.12\" opacity=\"0.35\" transform=\"translate(0 0.18)\"/><path d=\"", ends_148.Str, "\" stroke=\"#5e3a1c\" stroke-width=\"0.2\" opacity=\"0.85\"/>"));
s_145.V(Invoke(Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis207, int _argc201, V _a203, V _a204, V _a205, V _a206, V[] _rest202) => {
V u_208 = default;
double y_209 = 0;
V p_210 = default;
V k_211 = default;
double l_212 = 0;
double a_213 = 0;
u_208 = Call(R_142, V.Undef);
y_209 = (0.2 + (ToNum(Call(R_142, V.Undef)) * 0.8));
p_210 = Call(W_26, V.Undef, u_208, ((V)(y_209)));
k_211 = Call(wk_24, V.Undef, Call(gv_25, V.Undef, ((V)(y_209))));
l_212 = ((1.5 + (ToNum(Call(R_142, V.Undef)) * 3D)) * ToNum(k_211));
a_213 = ((ToNum(Call(R_142, V.Undef)) - 0.5) * 2.4);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, GetIdx(p_210, 0D))), " ", ToStr(Call(f1_16, V.Undef, GetIdx(p_210, 1D))), "l", ToStr(Call(f1_16, V.Undef, ((V)((l_212 * FdLibm.Cos(a_213)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((l_212 * FdLibm.Sin(a_213)) * 0.5))))), "\" stroke=\"#f7e2c0\" stroke-width=\"0.1\" opacity=\"0.45\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
s_145.V(Call(refl_33, V.Undef, ((V)(0.16)), ((V)("#fff3dc"))));
return Call(FL_22, V.Undef, ((V)(s_145.Str)));
return default;
}, 0, "fLam", false);
fChev_36 = Fn((V _self214, int _argc215, V _a217, V _a218, V _a219, V _a220, V[] _rest216) => {
V R_221 = default;
V PC_222 = default;
double bu_223 = 0;
double by_224 = 0;
double ua_225 = 0;
double ub_226 = 0;
double ya_227 = 0;
double NC_228 = 0;
double cw_229 = 0;
double d_230 = 0;
double p_231 = 0;
V tone_232 = default;
JsStrBuf grain_233 = null;
JsStrBuf fleck_234 = null;
JsStrBuf joints_235 = null;
JsStrBuf s_236 = null;
JsStrBuf bb_237 = null;
JsStrBuf bj_238 = null;
JsStrBuf bg_239 = null;
JsStrBuf sb_240 = null;
JsStrBuf sj_241 = null;
JsStrBuf sg_242 = null;
if (_self214.IsNullish) _self214 = GlobalV;
R_221 = Call(rng_13, V.Undef, ((V)("chev20")));
PC_222 = Arr(((V)("#dcc6a2")), ((V)("#d0b58d")), ((V)("#e4d1b0")), ((V)("#c9ad84")), ((V)("#d7be97")), ((V)("#c2a47b")));
bu_223 = 0.024;
by_224 = 0.04;
ua_225 = (bu_223 + 0.006);
ub_226 = ((1D - bu_223) - 0.006);
ya_227 = (by_224 + 0.009);
NC_228 = 12D;
cw_229 = ((ub_226 - ua_225) / NC_228);
d_230 = (cw_229 * 1.7);
p_231 = 0.044;
tone_232 = Invoke(PC_222, "map", Fn((V _arrowThis249, int _argc243, V _a245, V _a246, V _a247, V _a248, V[] _rest244) => {
return ((V)(""));
}, 0, "", true));
grain_233 = new JsStrBuf("");
fleck_234 = new JsStrBuf("");
joints_235 = new JsStrBuf("");
{
double c_250 = 0;
c_250 = 0D;
while (true) {
if (!((c_250 < NC_228))) break;
double u0_252 = 0;
double u1_253 = 0;
double dl_254 = 0;
double dr_255 = 0;
u0_252 = (ua_225 + (c_250 * cw_229));
u1_253 = (u0_252 + cw_229);
dl_254 = (NumTruthy((c_250 % 2D)) ? 0D : d_230);
dr_255 = (NumTruthy((c_250 % 2D)) ? d_230 : 0D);
{
double k_256 = 0;
k_256 = ((-System.Math.Ceiling((d_230 / p_231))) - 1D);
while (true) {
if (!(((ya_227 + (k_256 * p_231)) < 1.05))) break;
double y_258 = 0;
V P_259 = default;
V d0_260 = default;
y_258 = (ya_227 + (k_256 * p_231));
if ((((y_258 + d_230) + p_231) < (ya_227 - 0.01))) {
goto _cont257;
}
P_259 = Arr(Arr(((V)(u0_252)), ((V)((y_258 + dl_254)))), Arr(((V)(u1_253)), ((V)((y_258 + dr_255)))), Arr(((V)(u1_253)), ((V)(((y_258 + dr_255) + p_231)))), Arr(((V)(u0_252)), ((V)(((y_258 + dl_254) + p_231)))));
d0_260 = Call(polyW_28, V.Undef, P_259);
OpSetK(tone_232, ((V)(((double)(ToInt32((ToNum(Call(R_221, V.Undef)) * 6D)) | ToInt32(0D))))), 0, d0_260);
joints_235.V(d0_260);
Invoke(Arr(((V)((0.28 + (ToNum(Call(R_221, V.Undef)) * 0.14)))), ((V)((0.62 + (ToNum(Call(R_221, V.Undef)) * 0.16))))), "forEach", Fn((V _arrowThis268, int _argc261, V f_267, V _a264, V _a265, V _a266, V[] _rest262) => {
double m_269 = 0;
m_269 = (((ToNum(Call(R_221, V.Undef)) - 0.5) * p_231) * 0.18);
grain_233.V(Call(lineW_29, V.Undef, Arr(Arr(((V)(u0_252)), ((V)(((y_258 + dl_254) + (p_231 * ToNum(f_267)))))), Arr(((V)((u0_252 + (cw_229 / 2D)))), ((V)((((y_258 + ((dl_254 + dr_255) / 2D)) + (p_231 * ToNum(f_267))) + m_269)))), Arr(((V)(u1_253)), ((V)(((y_258 + dr_255) + (p_231 * ToNum(f_267)))))))));
return default;
}, 1, "", true));
if (LtN(Call(R_221, V.Undef), 0.3)) {
double t0_270 = 0;
double f_271 = 0;
V at_272 = default;
t0_270 = (ToNum(Call(R_221, V.Undef)) * 0.7);
f_271 = (0.35 + (ToNum(Call(R_221, V.Undef)) * 0.3));
at_272 = Fn((V _arrowThis280, int _argc273, V t_279, V _a276, V _a277, V _a278, V[] _rest274) => {
return Arr(((V)((u0_252 + (cw_229 * ToNum(t_279))))), ((V)((((y_258 + dl_254) + ((dr_255 - dl_254) * ToNum(t_279))) + (p_231 * f_271)))));
}, 1, "", true);
fleck_234.V(Call(lineW_29, V.Undef, Arr(Call(at_272, V.Undef, ((V)(t0_270))), Call(at_272, V.Undef, ((V)(((t0_270 + 0.12) + (ToNum(Call(R_221, V.Undef)) * 0.1))))))));
}
_cont257: ;
k_256++;
}
}
c_250++;
}
}
s_236 = new JsStrBuf(string.Concat(string.Concat("<defs><clipPath id=\"cvf\"><path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(((V)(ua_225)), ((V)(ya_227))), Arr(((V)(ub_226)), ((V)(ya_227))), Arr(((V)(ub_226)), ((V)(1.05))), Arr(((V)(ua_225)), ((V)(1.05)))))), "\"/></clipPath><clipPath id=\"cvb\"><path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(((V)(0D)), ((V)((-0.02)))), Arr(((V)(1D)), ((V)((-0.02)))), Arr(((V)((1D - bu_223))), ((V)(by_224))), Arr(((V)(bu_223)), ((V)(by_224)))))), "\"/></clipPath>"), string.Concat("<clipPath id=\"cvl\"><path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(((V)(0D)), ((V)((-0.02)))), Arr(((V)(bu_223)), ((V)(by_224))), Arr(((V)(bu_223)), ((V)(1.05))), Arr(((V)(0D)), ((V)(1.05)))))), "\"/></clipPath><clipPath id=\"cvr\"><path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(((V)(1D)), ((V)((-0.02)))), Arr(((V)(1D)), ((V)(1.05))), Arr(((V)((1D - bu_223))), ((V)(1.05))), Arr(((V)((1D - bu_223))), ((V)(by_224)))))), "\"/></clipPath></defs><rect width=\"80\" height=\"56\" fill=\"#5e3f24\"/>")));
s_236.S(string.Concat("<g clip-path=\"url(#cvf)\">", ToStr(Invoke(Invoke(tone_232, "map", Fn((V _arrowThis289, int _argc281, V t_287, V i_288, V _a285, V _a286, V[] _rest282) => {
return ((V)(string.Concat("<path d=\"", ToStr(t_287), "\" fill=\"", ToStr(GetK(PC_222, i_288)), "\"/>")));
}, 2, "", true)), "join", ((V)("")))), "<path d=\"", grain_233.Str, "\" stroke=\"#9a7a52\" stroke-width=\"0.14\" fill=\"none\" opacity=\"0.4\"/><path d=\"", fleck_234.Str, "\" stroke=\"#8a6a44\" stroke-width=\"0.22\" fill=\"none\" opacity=\"0.45\"/>")).S(string.Concat("<path d=\"", joints_235.Str, "\" fill=\"none\" stroke=\"#8c6c48\" stroke-width=\"0.18\" opacity=\"0.85\"/></g>"));
bb_237 = new JsStrBuf("");
bj_238 = new JsStrBuf("");
bg_239 = new JsStrBuf("");
{
double u_290 = 0;
double n_291 = 0;
u_290 = (-0.05);
n_291 = 0D;
while (true) {
if (!((u_290 < 1D))) break;
bb_237.S(string.Concat("<path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(((V)(u_290)), ((V)((-0.02)))), Arr(((V)((u_290 + 0.11))), ((V)((-0.02)))), Arr(((V)((u_290 + 0.11))), ((V)(by_224))), Arr(((V)(u_290)), ((V)(by_224)))))), "\" fill=\"", ToStr(GetIdx(PC_222, (((n_291 * 2D) + 1D) % 6D))), "\"/>"));
bj_238.V(Call(lineW_29, V.Undef, Arr(Arr(((V)(u_290)), ((V)((-0.02)))), Arr(((V)(u_290)), ((V)(by_224))))));
u_290 = (u_290 + 0.11);
n_291++;
}
}
bg_239.V(Add(Call(lineW_29, V.Undef, Arr(Arr(((V)(0D)), ((V)((by_224 * 0.35)))), Arr(((V)(1D)), ((V)((by_224 * 0.35)))))), Call(lineW_29, V.Undef, Arr(Arr(((V)(0D)), ((V)((by_224 * 0.7)))), Arr(((V)(1D)), ((V)((by_224 * 0.7))))))));
sb_240 = new JsStrBuf("");
sj_241 = new JsStrBuf("");
sg_242 = new JsStrBuf("");
Invoke(Arr(Arr(((V)(0D)), ((V)(bu_223))), Arr(((V)((1D - bu_223))), ((V)(1D)))), "forEach", Fn((V _arrowThis305, int _argc293, V _a295, V side_299, V _a297, V _a298, V[] _rest294) => {
V a_302 = default;
V b_304 = default;
{ V _t300 = ListOf(_a295);
{ V _t301 = GetIdx(_t300, 0D);
a_302 = _t301; }
{ V _t303 = GetIdx(_t300, 1D);
b_304 = _t303; }
}
{
double y_306 = 0;
double n_307 = 0;
y_306 = ((-0.1) + (ToNum(side_299) * 0.07));
n_307 = 0D;
while (true) {
if (!((y_306 < 1.05))) break;
sb_240.S(string.Concat("<path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(a_302, ((V)(y_306))), Arr(b_304, ((V)(y_306))), Arr(b_304, ((V)((y_306 + 0.2)))), Arr(a_302, ((V)((y_306 + 0.2))))))), "\" fill=\"", ToStr(GetIdx(PC_222, (ToNum(Add(((V)((n_307 * 3D))), side_299)) % 6D))), "\"/>"));
sj_241.V(Call(lineW_29, V.Undef, Arr(Arr(a_302, ((V)(y_306))), Arr(b_304, ((V)(y_306))))));
y_306 = (y_306 + 0.2);
n_307++;
}
}
sg_242.V(Call(lineW_29, V.Undef, Arr(Arr(Add(a_302, ((V)(((ToNum(b_304) - ToNum(a_302)) * 0.4)))), ((V)(0D))), Arr(Add(a_302, ((V)(((ToNum(b_304) - ToNum(a_302)) * 0.4)))), ((V)(1.05))))));
return default;
}, 2, "", true));
s_236.S(string.Concat("<g clip-path=\"url(#cvb)\">", bb_237.Str, "<path d=\"", bg_239.Str, "\" stroke=\"#9a7a52\" stroke-width=\"0.14\" opacity=\"0.4\" fill=\"none\"/><path d=\"", bj_238.Str, "\" stroke=\"#8c6c48\" stroke-width=\"0.18\"/></g>"));
Invoke(Arr(((V)("cvl")), ((V)("cvr"))), "forEach", Fn((V _arrowThis316, int _argc309, V c_315, V _a312, V _a313, V _a314, V[] _rest310) => {
return ((V)(s_236.S(string.Concat("<g clip-path=\"url(#", ToStr(c_315), ")\">", sb_240.Str, "<path d=\"", sg_242.Str, "\" stroke=\"#9a7a52\" stroke-width=\"0.14\" opacity=\"0.4\" fill=\"none\"/><path d=\"", sj_241.Str, "\" stroke=\"#8c6c48\" stroke-width=\"0.18\"/></g>")).Str));
}, 1, "", true));
s_236.S(string.Concat("<path d=\"", ToStr(Call(lineW_29, V.Undef, Arr(Arr(((V)(0D)), ((V)((-0.02)))), Arr(((V)(bu_223)), ((V)(by_224))), Arr(((V)(bu_223)), ((V)(1.05)))))), "M", ToStr(Call(WP_27, V.Undef, ((V)(1D)), ((V)((-0.02))))), "L", ToStr(Call(WP_27, V.Undef, ((V)((1D - bu_223))), ((V)(by_224)))), "L", ToStr(Call(WP_27, V.Undef, ((V)((1D - bu_223))), ((V)(1.05)))), "\" stroke=\"#8c6c48\" stroke-width=\"0.18\" fill=\"none\"/>"));
s_236.V(Add(Call(fblot_21, V.Undef, ((V)("chev")), ((V)(18D)), Arr(((V)("#f2e4c8")), ((V)("#b8986c"))), ((V)(0.2)), ((V)(8D))), Call(refl_33, V.Undef, ((V)(0.12)), ((V)("#fff8e8")))));
return Call(FL_22, V.Undef, ((V)(s_236.Str)));
return default;
}, 0, "fChev", false);
fTerr_37 = Fn((V _self317, int _argc318, V _a320, V _a321, V _a322, V _a323, V[] _rest319) => {
V R_324 = default;
V CH_325 = default;
V tot_326 = default;
V dd_327 = default;
JsStrBuf s_328 = null;
double TW_329 = 0;
double TH_330 = 0;
V fine_331 = default;
JsStrBuf pat_332 = null;
JsStrBuf bandS_333 = null;
V loop_334 = default;
JsStrBuf br_335 = null;
if (_self317.IsNullish) _self317 = GlobalV;
R_324 = Call(rng_13, V.Undef, ((V)("terr20")));
CH_325 = Arr(Arr(((V)("#9b9a95")), ((V)(25D))), Arr(((V)("#fbf8f2")), ((V)(18D))), Arr(((V)("#c76f4c")), ((V)(14D))), Arr(((V)("#93a88c")), ((V)(12D))), Arr(((V)("#e2b39f")), ((V)(12D))), Arr(((V)("#3f3e42")), ((V)(10D))), Arr(((V)("#d6a647")), ((V)(3D))), Arr(((V)("#b9c3c9")), ((V)(6D))));
tot_326 = Invoke(CH_325, "reduce", Fn((V _arrowThis344, int _argc336, V a_342, V c_343, V _a340, V _a341, V[] _rest337) => {
return Add(a_342, GetIdx(c_343, 1D));
}, 2, "", true), ((V)(0D)));
dd_327 = Invoke(CH_325, "map", Fn((V _arrowThis351, int _argc345, V _a347, V _a348, V _a349, V _a350, V[] _rest346) => {
return ((V)(""));
}, 0, "", true));
s_328 = new JsStrBuf(JsStrBuf.Begin().S("<defs><radialGradient id=\"t20h\" cx=\"50%\" cy=\"62%\" r=\"65%\"><stop offset=\"0\" stop-color=\"#ff9a4a\" stop-opacity=\"0.2\"/><stop offset=\"1\" stop-color=\"#ff9a4a\" stop-opacity=\"0\"/></radialGradient></defs><rect width=\"80\" height=\"56\" fill=\"#ece6da\"/>").V(Call(fblot_21, V.Undef, ((V)("terr")), ((V)(26D)), Arr(((V)("#f4efe5")), ((V)("#ddd4c4")), ((V)("#ebe3d2"))), ((V)(0.5)), ((V)(8D)))).End());
TW_329 = 20D;
TH_330 = 14D;
fine_331 = Arr(((V)("")), ((V)("")));
{
double i_352 = 0;
i_352 = 0D;
while (true) {
if (!((i_352 < 520D))) break;
double x_354 = 0;
double y_355 = 0;
double z_356 = 0;
x_354 = (ToNum(Call(R_324, V.Undef)) * TW_329);
y_355 = (ToNum(Call(R_324, V.Undef)) * TH_330);
z_356 = (0.12 + (ToNum(Call(R_324, V.Undef)) * 0.1));
OpSetK(fine_331, ((V)((i_352 % 2D))), 0, ((V)(string.Concat("M", ToStr(Call(f1_16, V.Undef, ((V)(x_354)))), " ", ToStr(Call(f1_16, V.Undef, ((V)(y_355)))), "h", ToStr(Call(f1_16, V.Undef, ((V)(z_356)))), "v", ToStr(Call(f1_16, V.Undef, ((V)((z_356 * 0.8))))), "h", ToStr(Call(f1_16, V.Undef, ((V)((-z_356))))), "Z"))));
i_352++;
}
}
{
double i_357 = 0;
i_357 = 0D;
while (true) {
if (!((i_357 < 300D))) break;
double q_359 = 0;
double c_360 = 0;
V z_361 = default;
double r_362 = 0;
double x_363 = 0;
double y_364 = 0;
double n_365 = 0;
double a0_366 = 0;
q_359 = (ToNum(Call(R_324, V.Undef)) * ToNum(tot_326));
c_360 = 0D;
while (Gt(((V)(q_359)), GetIdx(GetIdx(CH_325, c_360), 1D))) {
q_359 = (q_359 - ToNum(GetIdx(GetIdx(CH_325, c_360), 1D)));
c_360++;
}
z_361 = Call(R_324, V.Undef);
r_362 = (LtN(z_361, 0.14) ? (0.5 + (ToNum(Call(R_324, V.Undef)) * 0.3)) : (LtN(z_361, 0.5) ? (0.3 + (ToNum(Call(R_324, V.Undef)) * 0.2)) : (0.15 + (ToNum(Call(R_324, V.Undef)) * 0.15))));
x_363 = (r_362 + (ToNum(Call(R_324, V.Undef)) * (TW_329 - (2D * r_362))));
y_364 = (r_362 + (ToNum(Call(R_324, V.Undef)) * (TH_330 - (2D * r_362))));
n_365 = (5D + ((double)(ToInt32((ToNum(Call(R_324, V.Undef)) * 2D)) | ToInt32(0D))));
a0_366 = (ToNum(Call(R_324, V.Undef)) * 6.3);
OpSetK(dd_327, ((V)(c_360)), 0, ((V)(JsStrBuf.Begin().V(Invoke(Call(rep_18, V.Undef, ((V)(n_365)), Fn((V _arrowThis374, int _argc367, V j_373, V _a370, V _a371, V _a372, V[] _rest368) => {
double a_375 = 0;
double rr_376 = 0;
a_375 = ((a0_366 + (((ToNum(j_373) * 2D) * PI_11) / n_365)) + ((ToNum(Call(R_324, V.Undef)) - 0.5) * 0.8));
rr_376 = (r_362 * (0.6 + (ToNum(Call(R_324, V.Undef)) * 0.5)));
return ((V)(JsStrBuf.Begin().S((Truthy(j_373) ? "L" : "M")).V(Call(f1_16, V.Undef, ((V)((x_363 + (rr_376 * FdLibm.Cos(a_375))))))).S(" ").V(Call(f1_16, V.Undef, ((V)((y_364 + (rr_376 * FdLibm.Sin(a_375))))))).End()));
return default;
}, 1, "", true)), "join", ((V)("")))).S("Z").End())));
i_357++;
}
}
pat_332 = new JsStrBuf(string.Concat("<g id=\"tzc\"><path d=\"", ToStr(GetIdx(fine_331, 0D)), "\" fill=\"#a9a59c\" opacity=\"0.6\"/><path d=\"", ToStr(GetIdx(fine_331, 1D)), "\" fill=\"#d9a88e\" opacity=\"0.5\"/>", ToStr(Invoke(Invoke(dd_327, "map", Fn((V _arrowThis385, int _argc377, V d_383, V i_384, V _a381, V _a382, V[] _rest378) => {
return ((V)(string.Concat("<path d=\"", ToStr(d_383), "\" fill=\"", ToStr(GetIdx(GetK(CH_325, i_384), 0D)), "\"/>")));
}, 2, "", true)), "join", ((V)("")))), "</g>"));
bandS_333 = new JsStrBuf("");
{
double b_386 = 0;
b_386 = 0D;
while (true) {
if (!((b_386 < 10D))) break;
double y0_388 = 0;
double y1_389 = 0;
V vm_390 = default;
double k_391 = 0;
double sq_392 = 0;
y0_388 = (b_386 / 10D);
y1_389 = ((b_386 + 1D) / 10D);
vm_390 = Call(gv_25, V.Undef, ((V)(((y0_388 + y1_389) / 2D))));
k_391 = (ToNum(Call(wk_24, V.Undef, vm_390)) * 0.95);
sq_392 = (0.55 + (0.2 * ToNum(vm_390)));
pat_332.S(string.Concat("<pattern id=\"tz", NumStr(b_386), "\" width=\"", NumStr(TW_329), "\" height=\"", NumStr(TH_330), "\" patternUnits=\"userSpaceOnUse\" patternTransform=\"translate(", ToStr(Call(f1_16, V.Undef, ((V)((b_386 * 7.3))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((b_386 * 3.1))))), ") scale(", ToStr(Call(n4_17, V.Undef, ((V)(k_391)))), " ", ToStr(Call(n4_17, V.Undef, ((V)((k_391 * sq_392))))), ")\"><use href=\"#tzc\"/></pattern>"));
bandS_333.S(string.Concat("<path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(((V)((-0.03))), ((V)((y0_388 - 0.002)))), Arr(((V)(1.03)), ((V)((y0_388 - 0.002)))), Arr(((V)(1.03)), ((V)(((b_386 == 9D) ? 1.05 : y1_389)))), Arr(((V)((-0.03))), ((V)(((b_386 == 9D) ? 1.05 : y1_389))))))), "\" fill=\"url(#tz", NumStr(b_386), ")\"/>"));
b_386++;
}
}
s_328.S(string.Concat("<defs>", pat_332.Str, "</defs>", bandS_333.Str));
loop_334 = Arr();
{
double j_393 = 0;
double y_394 = 0;
j_393 = 0D;
y_394 = 0.08;
while (true) {
if (!((y_394 < 1.02))) break;
double a_396 = 0;
double b_397 = 0;
a_396 = (NumTruthy((j_393 % 2D)) ? 0.94 : 0.06);
b_397 = (NumTruthy((j_393 % 2D)) ? 0.06 : 0.94);
Invoke(loop_334, "push", Arr(((V)(a_396)), ((V)(y_394))), Arr(((V)(b_397)), ((V)(y_394))), Arr(((V)(b_397)), ((V)((y_394 + 0.065)))));
j_393++;
y_394 = (y_394 + 0.13);
}
}
s_328.S(string.Concat("<path d=\"", ToStr(TR_23), "\" fill=\"url(#t20h)\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.35;1;0.35")), ((V)(8D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "</path><path d=\"", ToStr(Call(crvW_30, V.Undef, loop_334)), "\" stroke=\"#ff8a3a\" stroke-width=\"2.6\" fill=\"none\" opacity=\"0.04\" filter=\"url(#fb3)\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.03;0.13;0.03")), ((V)(8D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "</path>"));
br_335 = new JsStrBuf("");
Invoke(Arr(((V)(0.25)), ((V)(0.5)), ((V)(0.75))), "forEach", Fn((V _arrowThis405, int _argc398, V u_404, V _a401, V _a402, V _a403, V[] _rest399) => {
return ((V)(br_335.V(Call(lineW_29, V.Undef, Arr(Arr(u_404, ((V)(0D))), Arr(u_404, ((V)(1.02)))))).Str));
}, 1, "", true));
Invoke(Arr(((V)((1D / 3D))), ((V)((2D / 3D)))), "forEach", Fn((V _arrowThis413, int _argc406, V y_412, V _a409, V _a410, V _a411, V[] _rest407) => {
return ((V)(br_335.V(Call(lineW_29, V.Undef, Arr(Arr(((V)(0D)), y_412), Arr(((V)(1D)), y_412)))).Str));
}, 1, "", true));
s_328.S(string.Concat("<path d=\"", br_335.Str, "\" stroke=\"#9a7024\" stroke-width=\"0.48\" fill=\"none\"/><path d=\"", br_335.Str, "\" stroke=\"#e8c472\" stroke-width=\"0.22\" fill=\"none\"/><path d=\"", br_335.Str, "\" stroke=\"#fff0b8\" stroke-width=\"0.1\" fill=\"none\" transform=\"translate(-0.08 -0.1)\"/>"));
s_328.V(Call(refl_33, V.Undef, ((V)(0.3))));
return Call(FL_22, V.Undef, ((V)(s_328.Str)));
return default;
}, 0, "fTerr", false);
fOnyx_38 = Fn((V _self414, int _argc415, V _a417, V _a418, V _a419, V _a420, V[] _rest416) => {
V R_421 = default;
V BC_422 = default;
JsStrBuf s_423 = null;
JsStrBuf bands_424 = null;
JsStrBuf lines_425 = null;
V band_426 = default;
V vein_427 = default;
V walk_428 = default;
if (_self414.IsNullish) _self414 = GlobalV;
R_421 = Call(rng_13, V.Undef, ((V)("onyx20")));
BC_422 = Arr(((V)("#f6e2b4")), ((V)("#d9a85e")), ((V)("#f2d49a")), ((V)("#c98f48")), ((V)("#fbefd2")), ((V)("#e3b56c")), ((V)("#b8783a")));
s_423 = new JsStrBuf("<defs><radialGradient id=\"ox20\" cx=\"50%\" cy=\"62%\" r=\"62%\"><stop offset=\"0\" stop-color=\"#ffe0a0\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#ffe0a0\" stop-opacity=\"0\"/></radialGradient></defs><rect width=\"80\" height=\"56\" fill=\"#e3bb78\"/>");
bands_424 = new JsStrBuf("<g filter=\"url(#fb2)\">");
lines_425 = new JsStrBuf("");
band_426 = Fn((V _arrowThis439, int _argc429, V c_435, V ph_436, V ph2_437, V o_438, V[] _rest430) => {
return Call(rep_18, V.Undef, ((V)(13D)), Fn((V _arrowThis447, int _argc440, V j_446, V _a443, V _a444, V _a445, V[] _rest441) => {
double x_448 = 0;
x_448 = ((-0.05) + (ToNum(j_446) * 0.1));
return Arr(((V)(x_448)), Add(((V)((((ToNum(Add(c_435, ((V)((0.42 * x_448))))) - ((0.18 * x_448) * x_448)) + (0.035 * FdLibm.Sin(ToNum(Add(((V)((((2D * PI_11) * 1.2) * x_448))), ph_436))))) + (0.015 * FdLibm.Sin(ToNum(Add(((V)((((2D * PI_11) * 3.3) * x_448))), ph2_437))))))), (o_438 is var _t449 && Truthy(_t449) ? _t449 : ((V)(0D)))));
return default;
}, 1, "", true));
}, 4, "", true);
{
double c_450 = 0;
c_450 = (-0.6);
while (true) {
if (!((c_450 < 1.25))) break;
double ph_452 = 0;
double ph2_453 = 0;
V d_454 = default;
ph_452 = (ToNum(Call(R_421, V.Undef)) * 6D);
ph2_453 = (ToNum(Call(R_421, V.Undef)) * 6D);
d_454 = Call(crvW_30, V.Undef, Call(band_426, V.Undef, ((V)(c_450)), ((V)(ph_452)), ((V)(ph2_453))));
bands_424.S(string.Concat("<path d=\"", ToStr(d_454), "\" stroke=\"", ToStr(GetIdx(BC_422, ((double)(ToInt32((ToNum(Call(R_421, V.Undef)) * ToNum(Get(BC_422, "length")))) | ToInt32(0D))))), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1D + (ToNum(Call(R_421, V.Undef)) * 3.4)))))), "\" fill=\"none\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.5 + (ToNum(Call(R_421, V.Undef)) * 0.4)))))), "\"/>"));
if (LtN(Call(R_421, V.Undef), 0.6)) {
V o_455 = default;
V w_456 = default;
o_455 = (LtN(Call(R_421, V.Undef), 0.5) ? V.True : V.False);
w_456 = Call(f1_16, V.Undef, ((V)((0.08 + (ToNum(Call(R_421, V.Undef)) * 0.12)))));
lines_425.S(string.Concat("<path d=\"", ToStr(d_454), "\" stroke=\"", (Truthy(o_455) ? "#9a5e26" : "#fff6e2"), "\" stroke-width=\"", ToStr(w_456), "\" fill=\"none\" opacity=\"0.5\"/>"));
if (LtN(Call(R_421, V.Undef), 0.5)) {
lines_425.S(string.Concat("<path d=\"", ToStr(Call(crvW_30, V.Undef, Call(band_426, V.Undef, ((V)(c_450)), ((V)(ph_452)), ((V)(ph2_453)), ((V)(0.006))))), "\" stroke=\"", (Truthy(o_455) ? "#9a5e26" : "#fff6e2"), "\" stroke-width=\"", ToStr(w_456), "\" fill=\"none\" opacity=\"0.35\"/>"));
}
}
c_450 = (c_450 + (0.04 + (ToNum(Call(R_421, V.Undef)) * 0.05)));
}
}
s_423.S(bands_424.Str).S("</g>").S(string.Concat("<g filter=\"url(#fb3)\">", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis463, int _argc457, V _a459, V _a460, V _a461, V _a462, V[] _rest458) => {
return ((V)(string.Concat("<path d=\"", ToStr(Call(crvW_30, V.Undef, Call(band_426, V.Undef, ((V)(((ToNum(Call(R_421, V.Undef)) * 1.1) - 0.2))), ((V)((ToNum(Call(R_421, V.Undef)) * 6D))), ((V)((ToNum(Call(R_421, V.Undef)) * 6D)))))), "\" stroke=\"#a4602a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((4D + (ToNum(Call(R_421, V.Undef)) * 4D)))))), "\" fill=\"none\" opacity=\"0.28\"/>")));
}, 0, "", true)), "join", ((V)("")))), "</g>")).S(lines_425.Str).V(Call(fblot_21, V.Undef, ((V)("onyx")), ((V)(20D)), Arr(((V)("#fff6e2")), ((V)("#f9e0a8")), ((V)("#c98a44"))), ((V)(0.36)), ((V)(7D))));
s_423.S(string.Concat("<path d=\"", ToStr(TR_23), "\" fill=\"url(#ox20)\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.45;1;0.45")), ((V)(7D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "</path>"));
vein_427 = Fn((V _arrowThis473, int _argc464, V pts_470, V i_471, V w_472, V _a469, V[] _rest465) => {
V d_474 = default;
d_474 = Call(lineW_29, V.Undef, pts_470);
return ((V)(string.Concat(string.Concat("<path d=\"", ToStr(d_474), "\" stroke=\"#ffc94a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.3 * ToNum(w_472)))))), "\" fill=\"none\" opacity=\"0.3\" stroke-linejoin=\"round\" filter=\"url(#fb2)\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.15;0.55;0.15")), ((V)(4D)), ((V)(((-ToNum(i_471)) * 0.9))), Call(SPL_15, V.Undef, ((V)(2D))))), "</path><path d=\"", ToStr(d_474), "\" stroke=\"#a8761f\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.32 * ToNum(w_472)))))), "\" fill=\"none\" stroke-linejoin=\"round\"/><path d=\"", ToStr(d_474), "\" stroke=\"#ffe08a\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((0.15 * ToNum(w_472)))))), "\" fill=\"none\" stroke-linejoin=\"round\"/>"), string.Concat("<path d=\"", ToStr(d_474), "\" pathLength=\"100\" stroke=\"#fff3c0\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((1.1 * ToNum(w_472)))))), "\" stroke-linecap=\"round\" stroke-dasharray=\"2.5 97.5\" fill=\"none\" filter=\"url(#fb1)\"><animate attributeName=\"stroke-dashoffset\" values=\"0;-100\" dur=\"", ToStr(Call(n4_17, V.Undef, ((V)((6D + (ToNum(i_471) * 0.8)))))), "s\" begin=\"", ToStr(Call(n4_17, V.Undef, ((V)(((-ToNum(i_471)) * 1.7))))), "s\" repeatCount=\"indefinite\"/></path>"))));
return default;
}, 3, "", true);
walk_428 = Fn((V _arrowThis487, int _argc475, V u_481, V y_482, V y1_483, V du_484, V[] _rest476) => {
V pts_488 = default;
V jit_485 = default;
V st_486 = default;
jit_485 = (_argc475 > 4 ? _rest476[0] : V.Undef);
st_486 = (_argc475 > 5 ? _rest476[1] : V.Undef);
pts_488 = Arr(Arr(u_481, y_482));
while (Lt(y_482, y1_483)) {
y_482 = Add(y_482, ((V)((ToNum(st_486) * ToNum(Add(((V)(0.5)), Call(R_421, V.Undef)))))));
u_481 = Add(u_481, Add(((V)(((ToNum(Call(R_421, V.Undef)) - 0.5) * ToNum(jit_485)))), du_484));
Invoke(pts_488, "push", Arr(u_481, y_482));
}
return pts_488;
return default;
}, 6, "", true);
Invoke(Arr(Arr(((V)(0.16)), ((V)(0.02))), Arr(((V)(0.52)), ((V)((-0.03)))), Arr(((V)(0.83)), ((V)(0.01)))), "forEach", Fn((V _arrowThis501, int _argc489, V _a491, V k_495, V _a493, V _a494, V[] _rest490) => {
V pts_502 = default;
V u0_498 = default;
V du_500 = default;
{ V _t496 = ListOf(_a491);
{ V _t497 = GetIdx(_t496, 0D);
u0_498 = _t497; }
{ V _t499 = GetIdx(_t496, 1D);
du_500 = _t499; }
}
pts_502 = Call(walk_428, V.Undef, u0_498, ((V)((-0.06))), ((V)(1.05)), ((V)((ToNum(du_500) * 0.3))), ((V)(0.035)), ((V)(0.035)));
s_423.V(Call(vein_427, V.Undef, pts_502, k_495, ((V)(1D))));
Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis510, int _argc503, V j_509, V _a506, V _a507, V _a508, V[] _rest504) => {
V q_511 = default;
q_511 = GetIdx(pts_502, (3D + ((double)(ToInt32((ToNum(Call(R_421, V.Undef)) * (ToNum(Get(pts_502, "length")) - 6D))) | ToInt32(0D)))));
s_423.V(Call(vein_427, V.Undef, Call(walk_428, V.Undef, GetIdx(q_511, 0D), GetIdx(q_511, 1D), Add(Add(GetIdx(q_511, 1D), ((V)(0.1))), ((V)((ToNum(Call(R_421, V.Undef)) * 0.12)))), ((V)(((LtN(Call(R_421, V.Undef), 0.5) ? (-1D) : 1D) * 0.012))), ((V)(0.025)), ((V)(0.025))), Add(Add(((V)((ToNum(k_495) * 3D))), j_509), ((V)(3D))), ((V)(0.6))));
return default;
}, 1, "", true));
return default;
}, 2, "", true));
s_423.V(Call(refl_33, V.Undef, ((V)(0.24)), ((V)("#fff8e4"))));
return Call(FL_22, V.Undef, ((V)(s_423.Str)));
return default;
}, 0, "fOnyx", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy((((((RD_8 is var _t512 && !Truthy(_t512) ? _t512 : Get(RD_8, "PLUS19")) is var _t513 && !Truthy(_t513) ? _t513 : Get(RD_8, "H13")) is var _t514 && !Truthy(_t514) ? _t514 : Get(RD_8, "H10")) is var _t515 && !Truthy(_t515) ? _t515 : X_9) is var _t516 && !Truthy(_t516) ? _t516 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_517.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS20"))) {
return default;
}
shade_10 = Get(Get(X_9, "K"), "shade");
PI_11 = System.Math.PI;
H_12 = Get(RD_8, "H10");
{ V _t518 = H_12;
if (_t518.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t518));
{ V _t519 = Get(_t518, "rng");
rng_13 = _t519; }
{ V _t520 = Get(_t518, "an");
an_14 = _t520; }
{ V _t521 = Get(_t518, "SPL");
SPL_15 = _t521; }
{ V _t522 = Get(_t518, "f1");
f1_16 = _t522; }
{ V _t523 = Get(_t518, "n4");
n4_17 = _t523; }
{ V _t524 = Get(_t518, "rep");
rep_18 = _t524; } }
{ V _t525 = Get(RD_8, "H13");
if (_t525.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t525));
{ V _t526 = Get(_t525, "px");
px_19 = _t526; }
{ V _t527 = Get(_t525, "crv");
crv_20 = _t527; }
{ V _t528 = Get(_t525, "fblot");
fblot_21 = _t528; }
{ V _t529 = Get(_t525, "FL");
FL_22 = _t529; } }
TR_23 = ((V)("M14 0H66L80 56H0Z"));
wk_24 = Fn((V _arrowThis537, int _argc530, V v_536, V _a533, V _a534, V _a535, V[] _rest531) => {
return ((V)(((52D + (28D * ToNum(v_536))) / 80D)));
}, 1, "", true);
gv_25 = Fn((V _arrowThis545, int _argc538, V t_544, V _a541, V _a542, V _a543, V[] _rest539) => {
return ((V)((ToNum(t_544) * (0.7 + (0.3 * ToNum(t_544))))));
}, 1, "", true);
W_26 = Fn((V _arrowThis554, int _argc546, V u_552, V y_553, V _a550, V _a551, V[] _rest547) => {
return Call(px_19, V.Undef, u_552, Call(gv_25, V.Undef, y_553));
}, 2, "", true);
WP_27 = Fn((V _arrowThis563, int _argc555, V u_561, V y_562, V _a559, V _a560, V[] _rest556) => {
V p_564 = default;
p_564 = Call(W_26, V.Undef, u_561, y_562);
return ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, GetIdx(p_564, 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(p_564, 1D))).End()));
return default;
}, 2, "", true);
polyW_28 = Fn((V _arrowThis572, int _argc565, V pts_571, V _a568, V _a569, V _a570, V[] _rest566) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_571, "map", Fn((V _arrowThis584, int _argc573, V _a575, V _a576, V _a577, V _a578, V[] _rest574) => {
V u_581 = default;
V y_583 = default;
{ V _t579 = ListOf(_a575);
{ V _t580 = GetIdx(_t579, 0D);
u_581 = _t580; }
{ V _t582 = GetIdx(_t579, 1D);
y_583 = _t582; }
}
return Call(WP_27, V.Undef, u_581, y_583);
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
}, 1, "", true);
lineW_29 = Fn((V _arrowThis592, int _argc585, V pts_591, V _a588, V _a589, V _a590, V[] _rest586) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_591, "map", Fn((V _arrowThis604, int _argc593, V _a595, V _a596, V _a597, V _a598, V[] _rest594) => {
V u_601 = default;
V y_603 = default;
{ V _t599 = ListOf(_a595);
{ V _t600 = GetIdx(_t599, 0D);
u_601 = _t600; }
{ V _t602 = GetIdx(_t599, 1D);
y_603 = _t602; }
}
return Call(WP_27, V.Undef, u_601, y_603);
}, 1, "", true)), "join", ((V)("L")))).End()));
}, 1, "", true);
crvW_30 = Fn((V _arrowThis612, int _argc605, V pts_611, V _a608, V _a609, V _a610, V[] _rest606) => {
return Call(crv_20, V.Undef, Invoke(pts_611, "map", Fn((V _arrowThis624, int _argc613, V _a615, V _a616, V _a617, V _a618, V[] _rest614) => {
V u_621 = default;
V y_623 = default;
{ V _t619 = ListOf(_a615);
{ V _t620 = GetIdx(_t619, 0D);
u_621 = _t620; }
{ V _t622 = GetIdx(_t619, 1D);
y_623 = _t622; }
}
return Arr(u_621, Call(gv_25, V.Undef, y_623));
}, 1, "", true)));
}, 1, "", true);
chip_31 = Fn((V _arrowThis636, int _argc625, V R_631, V u_632, V y_633, V r_634, V[] _rest626) => {
V p_637 = default;
V v_638 = default;
double k_639 = 0;
double sq_640 = 0;
double a0_641 = 0;
JsStrBuf d_642 = null;
V n_635 = default;
n_635 = (_argc625 > 4 ? _rest626[0] : V.Undef);
p_637 = Call(W_26, V.Undef, u_632, y_633);
v_638 = Call(gv_25, V.Undef, y_633);
k_639 = (ToNum(r_634) * ToNum(Call(wk_24, V.Undef, v_638)));
sq_640 = (0.5 + (0.2 * ToNum(v_638)));
a0_641 = (ToNum(Call(R_631, V.Undef)) * 6.3);
d_642 = new JsStrBuf("");
{
double i_643 = 0;
i_643 = 0D;
while (true) {
if (!(Lt(((V)(i_643)), n_635))) break;
double a_645 = 0;
double rr_646 = 0;
a_645 = ((a0_641 + (((i_643 * 2D) * PI_11) / ToNum(n_635))) + ((ToNum(Call(R_631, V.Undef)) - 0.5) * 0.8));
rr_646 = (k_639 * (0.6 + (ToNum(Call(R_631, V.Undef)) * 0.55)));
d_642.S((NumTruthy(i_643) ? "L" : "M")).V(Call(f1_16, V.Undef, Add(GetIdx(p_637, 0D), ((V)((rr_646 * FdLibm.Cos(a_645))))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(p_637, 1D), ((V)(((rr_646 * FdLibm.Sin(a_645)) * sq_640))))));
i_643++;
}
}
return ((V)(string.Concat(d_642.Str, "Z")));
return default;
}, 5, "", true);
ell_32 = Fn((V _arrowThis658, int _argc647, V u_653, V y_654, V rx_655, V ry_656, V[] _rest648) => {
V p_659 = default;
V k_660 = default;
V ex_657 = default;
ex_657 = (_argc647 > 4 ? _rest648[0] : V.Undef);
p_659 = Call(W_26, V.Undef, u_653, y_654);
k_660 = Call(wk_24, V.Undef, Call(gv_25, V.Undef, y_654));
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_659, 0D))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, GetIdx(p_659, 1D))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(rx_655) * ToNum(k_660)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(ry_656) * ToNum(k_660)))))), "\" ", ToStr(ex_657), "/>")));
return default;
}, 5, "", true);
refl_33 = Fn((V _arrowThis669, int _argc661, V op_667, V col_668, V _a665, V _a666, V[] _rest662) => {
return ((V)(string.Concat("<g filter=\"url(#fb3)\"><path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(((V)(0.17)), ((V)(0D))), Arr(((V)(0.33)), ((V)(0D))), Arr(((V)(0.37)), ((V)(0.5))), Arr(((V)(0.14)), ((V)(0.5)))))), "\" fill=\"", ToStr((col_668 is var _t670 && Truthy(_t670) ? _t670 : ((V)("#ffffff")))), "\" opacity=\"", ToStr(op_667), "\"/><path d=\"", ToStr(Call(polyW_28, V.Undef, Arr(Arr(((V)(0.2)), ((V)(0D))), Arr(((V)(0.3)), ((V)(0D))), Arr(((V)(0.32)), ((V)(0.3))), Arr(((V)(0.18)), ((V)(0.3)))))), "\" fill=\"", ToStr((col_668 is var _t671 && Truthy(_t671) ? _t671 : ((V)("#ffffff")))), "\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(op_667) * 0.8))))), "\"/>", ToStr(Call(ell_32, V.Undef, ((V)(0.55)), ((V)(0.22)), ((V)(7D)), ((V)(2D)), ((V)(string.Concat("fill=\"", ToStr((col_668 is var _t672 && Truthy(_t672) ? _t672 : ((V)("#ffffff")))), "\" opacity=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(op_667) * 0.7))))), "\""))))), "</g>")));
}, 2, "", true);
FLOOR20_39 = NewObj(5).Put("lino", fLino_34).Put("lam", fLam_35).Put("chev", fChev_36).Put("terr", fTerr_37).Put("onyx", fOnyx_38).V;
MEMO_40 = NewObj(0).V;
draw19_41 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis681, int _argc673, V r_679, V o_680, V _a677, V _a678, V[] _rest674) => {
V res_682 = default;
res_682 = Call(draw19_41, V.Undef, r_679, o_680);
if (Truthy(((!(Truthy(res_682)) ? V.True : V.False) is var _t683 && Truthy(_t683) ? _t683 : Get(res_682, "_p20")))) {
return res_682;
}
try {
V f_684 = default;
f_684 = (Get(r_679, "f20") is var _t685 && !Truthy(_t685) ? _t685 : GetK(FLOOR20_39, Get(r_679, "f20")));
if (Truthy((f_684 is var _t686 && !Truthy(_t686) ? _t686 : Get(res_682, "surf")))) {
Set(res_682, "_p20", ((V)(1D)));
Set(res_682, "vb", ((V)("0 0 80 56")));
Set(res_682, "svg", (GetK(MEMO_40, Get(r_679, "f20")) is var _t687 && Truthy(_t687) ? _t687 : SetK(MEMO_40, Get(r_679, "f20"), Invoke(RD_8, "svgDoc", ((V)("0 0 80 56")), Arr(), Call(f_684, V.Undef)))));
Set(res_682, "src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Get(res_682, "svg"))).End())));
}
} catch (System.Exception _ex688) {
V e_689 = default;
e_689 = Caught(_ex688);
Invoke(G("console"), "warn", ((V)("reno plus20")), Get(r_679, "id"), e_689);
}
return res_682;
return default;
}, 2, "", true));
N_42 = Get(RD_8, "N");
{ V _t690 = H_12;
if (_t690.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t690));
{ V _t691 = Get(_t690, "cam");
cam_43 = _t691; } }
{ V _t692 = Get(RD_8, "H13");
if (_t692.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t692));
{ V _t693 = Get(_t692, "slab");
slab_44 = _t693; }
{ V _t694 = Get(_t692, "top");
top_45 = _t694; }
{ V _t695 = Get(_t692, "face");
face_46 = _t695; }
{ V _t696 = Get(_t692, "rrP");
rrP_47 = _t696; }
{ V _t697 = Get(_t692, "dP");
dP_48 = _t697; }
{ V _t698 = Get(_t692, "ellP");
ellP_49 = _t698; } }
DEF20_50 = ((V)("<filter id=\"r13b\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"1.6\"/></filter><filter id=\"r13s\" x=\"-30%\" y=\"-30%\" width=\"160%\" height=\"160%\"><feGaussianBlur stdDeviation=\"0.5\"/></filter><filter id=\"r20g\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"1.1\"/></filter>"));
RUG_51 = Fn((V _arrowThis708, int _argc699, V w_705, V d_706, V o_707, V _a704, V[] _rest700) => {
return Object_assign(NewObj(5).Put("w", w_705).Put("d", d_706).Put("flat", ((V)(1D))).Put("noBlock", ((V)(1D))).Put("build", Fn((V _arrowThis715, int _argc709, V _a711, V _a712, V _a713, V _a714, V[] _rest710) => {
return Arr();
}, 0, "build", true)).V, (o_707 is var _t716 && Truthy(_t716) ? _t716 : NewObj(0).V));
}, 3, "", true);
smooth_52 = Fn((V _arrowThis724, int _argc717, V P_723, V _a720, V _a721, V _a722, V[] _rest718) => {
V m_725 = default;
V n_726 = default;
JsStrBuf d_727 = null;
m_725 = Fn((V _arrowThis736, int _argc728, V a_734, V b_735, V _a732, V _a733, V[] _rest729) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, ((V)((ToNum(Add(GetIdx(a_734, 0D), GetIdx(b_735, 0D))) / 2D))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(Add(GetIdx(a_734, 1D), GetIdx(b_735, 1D))) / 2D))))).End()));
}, 2, "", true);
n_726 = Get(P_723, "length");
d_727 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(m_725, V.Undef, GetIdx(P_723, (ToNum(n_726) - 1D)), GetIdx(P_723, 0D))).End());
{
double i_737 = 0;
i_737 = 0D;
while (true) {
if (!(Lt(((V)(i_737)), n_726))) break;
d_727.S("Q").V(Call(f1_16, V.Undef, GetIdx(GetIdx(P_723, i_737), 0D))).S(" ").V(Call(f1_16, V.Undef, GetIdx(GetIdx(P_723, i_737), 1D))).S(" ").V(Call(m_725, V.Undef, GetIdx(P_723, i_737), GetIdx(P_723, ((i_737 + 1D) % ToNum(n_726)))));
i_737++;
}
}
return ((V)(string.Concat(d_727.Str, "Z")));
return default;
}, 1, "", true);
blob_53 = Fn((V _arrowThis751, int _argc739, V R_745, V cx_746, V cz_747, V rx_748, V[] _rest740) => {
double p1_752 = 0;
double p2_753 = 0;
V a_754 = default;
V rz_749 = default;
V k_750 = default;
rz_749 = (_argc739 > 4 ? _rest740[0] : V.Undef);
k_750 = (_argc739 > 5 ? _rest740[1] : V.Undef);
p1_752 = (ToNum(Call(R_745, V.Undef)) * 6D);
p2_753 = (ToNum(Call(R_745, V.Undef)) * 6D);
a_754 = (k_750 is var _t755 && Truthy(_t755) ? _t755 : ((V)(0.2)));
return Call(smooth_52, V.Undef, Call(rep_18, V.Undef, ((V)(22D)), Fn((V _arrowThis763, int _argc756, V i_762, V _a759, V _a760, V _a761, V[] _rest757) => {
double t_764 = 0;
double r_765 = 0;
t_764 = (((ToNum(i_762) / 22D) * 2D) * PI_11);
r_765 = ((1D + (ToNum(a_754) * FdLibm.Sin(((2D * t_764) + p1_752)))) + ((ToNum(a_754) * 0.5) * FdLibm.Sin(((3D * t_764) + p2_753))));
return Arr(Add(cx_746, ((V)(((ToNum(rx_748) * r_765) * FdLibm.Cos(t_764))))), Add(cz_747, ((V)(((ToNum(rz_749) * r_765) * FdLibm.Sin(t_764))))));
return default;
}, 1, "", true)));
return default;
}, 6, "", true);
fringe_54 = Fn((V _arrowThis778, int _argc766, V R_772, V W_773, V Dd_774, V col_775, V[] _rest767) => {
JsStrBuf s_779 = null;
V n_776 = default;
V L_777 = default;
n_776 = (_argc766 > 4 ? _rest767[0] : V.Undef);
L_777 = (_argc766 > 5 ? _rest767[1] : V.Undef);
s_779 = new JsStrBuf("");
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis787, int _argc780, V sx_786, V _a783, V _a784, V _a785, V[] _rest781) => {
{
V z_788 = default;
z_788 = ((V)((((-ToNum(Dd_774)) / 2D) + 2D)));
while (true) {
if (!(LeN(z_788, ((ToNum(Dd_774) / 2D) - 2D)))) break;
double l_790 = 0;
double x0_791 = 0;
double w_792 = 0;
l_790 = (ToNum(L_777) * (0.8 + (ToNum(Call(R_772, V.Undef)) * 0.4)));
x0_791 = ((ToNum(sx_786) * ToNum(W_773)) / 2D);
w_792 = ((ToNum(Call(R_772, V.Undef)) - 0.5) * 1.6);
s_779.S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)(x0_791)))).S(" ").V(Call(f1_16, V.Undef, z_788)).S("q").V(Call(f1_16, V.Undef, ((V)(((ToNum(sx_786) * l_790) * 0.5))))).S(" ").V(Call(f1_16, V.Undef, ((V)(w_792)))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(sx_786) * l_790))))).S(" ").V(Call(f1_16, V.Undef, ((V)((w_792 * 0.4))))).S("\" stroke=\"").V(Call(shade_10, V.Undef, col_775, ((V)(0.72)))).S("\" stroke-width=\"0.75\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M").V(Call(f1_16, V.Undef, ((V)(x0_791)))).S(" ").V(Call(f1_16, V.Undef, z_788)).S("q").V(Call(f1_16, V.Undef, ((V)(((ToNum(sx_786) * l_790) * 0.5))))).S(" ").V(Call(f1_16, V.Undef, ((V)(w_792)))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(sx_786) * l_790))))).S(" ").V(Call(f1_16, V.Undef, ((V)((w_792 * 0.4))))).S("\" stroke=\"").V(col_775).S("\" stroke-width=\"0.45\" fill=\"none\" stroke-linecap=\"round\"/>");
z_788 = Add(z_788, n_776);
}
}
return default;
}, 1, "", true));
return ((V)(s_779.Str));
return default;
}, 6, "", true);
Set(N_42, "mat20", Fn((V _arrowThis800, int _argc793, V S_799, V _a796, V _a797, V _a798, V[] _rest794) => {
double W_801 = 0;
double Dd_802 = 0;
double T_803 = 0;
double c_804 = 0;
V P_805 = default;
V D_806 = default;
W_801 = 118D;
Dd_802 = 70D;
T_803 = 0.8;
c_804 = 13D;
P_805 = Arr(Arr(((V)(((-W_801) / 2D))), ((V)(((-Dd_802) / 2D)))), Arr(((V)((W_801 / 2D))), ((V)(((-Dd_802) / 2D)))), Arr(((V)((W_801 / 2D))), ((V)(((Dd_802 / 2D) - c_804)))), Arr(((V)(((W_801 / 2D) - c_804))), ((V)((Dd_802 / 2D)))), Arr(((V)(((-W_801) / 2D))), ((V)((Dd_802 / 2D)))));
D_806 = Call(RUG_51, V.Undef, ((V)(124D)), ((V)(76D)));
Set(D_806, "fx", Fn((V _arrowThis814, int _argc807, V ctx_813, V _a810, V _a811, V _a812, V[] _rest808) => {
V C_815 = default;
V R_816 = default;
V id_817 = default;
JsStrBuf art_818 = null;
JsStrBuf rb_819 = null;
JsStrBuf rd_820 = null;
V tx_821 = default;
V a_822 = default;
V b_823 = default;
V f_824 = default;
V fl_825 = default;
JsStrBuf flap_826 = null;
V s_827 = default;
C_815 = Call(cam_43, V.Undef, ctx_813);
R_816 = Call(rng_13, V.Undef, ((V)("mat20")));
id_817 = Invoke(C_815, "u", ((V)("wm")));
art_818 = new JsStrBuf(JsStrBuf.Begin().S("<rect x=\"").N(((-W_801) / 2D)).S("\" y=\"").N(((-Dd_802) / 2D)).S("\" width=\"").N(W_801).S("\" height=\"").N(Dd_802).S("\" fill=\"#2d2b29\"/><rect x=\"").N((((-W_801) / 2D) + 3.4)).S("\" y=\"").N((((-Dd_802) / 2D) + 3.4)).S("\" width=\"").N((W_801 - 6.8)).S("\" height=\"").N((Dd_802 - 6.8)).S("\" rx=\"1.4\" fill=\"#b98b55\"/>").End());
rb_819 = new JsStrBuf("");
rd_820 = new JsStrBuf("");
{
double z_828 = 0;
z_828 = (((-Dd_802) / 2D) + 4D);
while (true) {
if (!((z_828 < ((Dd_802 / 2D) - 3.4)))) break;
rb_819.S("M").N((((-W_801) / 2D) + 3.4)).S(" ").V(Call(f1_16, V.Undef, ((V)(z_828)))).S("H").N(((W_801 / 2D) - 3.4));
rd_820.S("M").N((((-W_801) / 2D) + 3.4)).S(" ").V(Call(f1_16, V.Undef, ((V)((z_828 + 0.55))))).S("H").N(((W_801 / 2D) - 3.4));
z_828 = (z_828 + 1.25);
}
}
art_818.S("<path d=\"").S(rb_819.Str).S("\" stroke=\"#8e6538\" stroke-width=\"0.42\"/><path d=\"").S(rd_820.Str).S("\" stroke=\"#d8ad74\" stroke-width=\"0.28\" opacity=\"0.7\"/>");
art_818.S("<g filter=\"url(#r13b)\">").V(Invoke(Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis837, int _argc830, V i_836, V _a833, V _a834, V _a835, V[] _rest831) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_16, V.Undef, ((V)((((ToNum(Call(R_816, V.Undef)) - 0.5) * W_801) * 0.8))))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)((((ToNum(Call(R_816, V.Undef)) - 0.5) * Dd_802) * 0.7))))).S("\" rx=\"").V(Call(f1_16, V.Undef, ((V)((6D + (ToNum(Call(R_816, V.Undef)) * 8D)))))).S("\" ry=\"").V(Call(f1_16, V.Undef, ((V)((3D + (ToNum(Call(R_816, V.Undef)) * 5D)))))).S("\" fill=\"").S((NumTruthy((ToNum(i_836) % 2D)) ? "#d2a46a" : "#8a5f34")).S("\" opacity=\"0.35\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
tx_821 = Fn((V _arrowThis845, int _argc838, V st_844, V _a841, V _a842, V _a843, V[] _rest839) => {
return ((V)(JsStrBuf.Begin().S("<text x=\"0\" y=\"6\" text-anchor=\"middle\" font-family=\"'Arial Black',Arial,sans-serif\" font-weight=\"900\" font-size=\"15\" letter-spacing=\"1.2\" textLength=\"84\" lengthAdjust=\"spacingAndGlyphs\" ").V(st_844).S(">WELCOME</text>").End()));
}, 1, "", true);
art_818.S("<defs><mask id=\"").V(id_817).S("m\"><rect x=\"-60\" y=\"-40\" width=\"120\" height=\"80\" fill=\"#ffffff\"/>").V(Invoke(Call(rep_18, V.Undef, ((V)(140D)), Fn((V _arrowThis852, int _argc846, V _a848, V _a849, V _a850, V _a851, V[] _rest847) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_16, V.Undef, ((V)(((ToNum(Call(R_816, V.Undef)) - 0.5) * 90D))))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)(((ToNum(Call(R_816, V.Undef)) - 0.5) * 22D))))).S("\" r=\"").V(Call(f1_16, V.Undef, ((V)((0.25 + (ToNum(Call(R_816, V.Undef)) * 0.7)))))).S("\" fill=\"#000000\"/>").End()));
}, 0, "", true)), "join", ((V)("")))).S("<ellipse cx=\"-12\" cy=\"2\" rx=\"13\" ry=\"7\" fill=\"#000000\" opacity=\"0.7\" filter=\"url(#r13b)\"/></mask></defs>");
art_818.S("<g mask=\"url(#").V(id_817).S("m)\">").V(Call(tx_821, V.Undef, ((V)("fill=\"#3d2410\" opacity=\"0.88\"")))).S("</g>");
Invoke(Arr(Arr(((V)((-46D))), ((V)((-20D)))), Arr(((V)(46D)), ((V)(20D)))), "forEach", Fn((V _arrowThis865, int _argc853, V _a855, V i_859, V _a857, V _a858, V[] _rest854) => {
V x_862 = default;
V z_864 = default;
{ V _t860 = ListOf(_a855);
{ V _t861 = GetIdx(_t860, 0D);
x_862 = _t861; }
{ V _t863 = GetIdx(_t860, 1D);
z_864 = _t863; }
}
return ((V)(art_818.S("<g transform=\"translate(").V(x_862).S(" ").V(z_864).S(") rotate(").N((Truthy(i_859) ? 160D : (-20D))).S(")\" fill=\"#3d2410\" opacity=\"0.55\"><ellipse cx=\"0\" cy=\"2\" rx=\"3\" ry=\"2.4\"/><circle cx=\"-3\" cy=\"-1.6\" r=\"1\"/><circle cx=\"-1\" cy=\"-3\" r=\"1\"/><circle cx=\"1.4\" cy=\"-3\" r=\"1\"/><circle cx=\"3.2\" cy=\"-1.4\" r=\"1\"/></g>").Str));
}, 2, "", true));
art_818.S("<ellipse cx=\"-14\" cy=\"3\" rx=\"15\" ry=\"9\" fill=\"#d8b27e\" opacity=\"0.5\" filter=\"url(#r13b)\"/>");
art_818.V(Invoke(Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis872, int _argc866, V _a868, V _a869, V _a870, V _a871, V[] _rest867) => {
double x_873 = 0;
double z_874 = 0;
x_873 = ((ToNum(Call(R_816, V.Undef)) - 0.5) * (W_801 - 12D));
z_874 = ((ToNum(Call(R_816, V.Undef)) - 0.5) * (Dd_802 - 12D));
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_16, V.Undef, ((V)(x_873)))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)(z_874)))).S("\" r=\"").V(Call(f1_16, V.Undef, ((V)((0.3 + (ToNum(Call(R_816, V.Undef)) * 0.45)))))).S("\" fill=\"").S((LtN(Call(R_816, V.Undef), 0.5) ? "#e8c890" : "#5a3a1e")).S("\"/>").End()));
return default;
}, 0, "", true)), "join", ((V)(""))));
art_818.V(Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis881, int _argc875, V _a877, V _a878, V _a879, V _a880, V[] _rest876) => {
double x_882 = 0;
double z_883 = 0;
x_882 = ((ToNum(Call(R_816, V.Undef)) - 0.5) * (W_801 - 16D));
z_883 = ((ToNum(Call(R_816, V.Undef)) - 0.5) * (Dd_802 - 16D));
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_16, V.Undef, ((V)(x_882)))).S(" ").V(Call(f1_16, V.Undef, ((V)(z_883)))).S("q3 -2 6 0.4\" stroke=\"#f4efe6\" stroke-width=\"0.3\" fill=\"none\" opacity=\"0.8\"/>").End()));
return default;
}, 0, "", true)), "join", ((V)(""))));
a_822 = Arr(((V)((W_801 / 2D))), ((V)(((Dd_802 / 2D) - c_804))));
b_823 = Arr(((V)(((W_801 / 2D) - c_804))), ((V)((Dd_802 / 2D))));
f_824 = Arr(((V)(((W_801 / 2D) - c_804))), ((V)(((Dd_802 / 2D) - c_804))));
fl_825 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(a_822, "join", ((V)(" ")))).S("L").V(Invoke(f_824, "join", ((V)(" ")))).S("L").V(Invoke(b_823, "join", ((V)(" ")))).S("Z").End()));
flap_826 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(fl_825).S("\" fill=\"#000000\" opacity=\"0.35\" transform=\"translate(-1.2 -0.6)\" filter=\"url(#r13s)\"/><path d=\"").V(fl_825).S("\" fill=\"#2a2827\"/>").End());
{
double i_884 = 0;
i_884 = 1D;
while (true) {
if (!((i_884 < 6D))) break;
{
double k_886 = 0;
k_886 = 1D;
while (true) {
if (!((k_886 < (6D - i_884)))) break;
flap_826.S("<circle cx=\"").V(Call(f1_16, V.Undef, ((V)((((W_801 / 2D) - c_804) + ((k_886 * c_804) / 6D)))))).S("\" cy=\"").V(Call(f1_16, V.Undef, ((V)((((Dd_802 / 2D) - c_804) + ((i_884 * c_804) / 6D)))))).S("\" r=\"0.45\" fill=\"#474442\"/>");
k_886++;
}
}
i_884++;
}
}
flap_826.S("<path d=\"M").V(Invoke(a_822, "join", ((V)(" ")))).S("L").V(Invoke(b_823, "join", ((V)(" ")))).S("\" stroke=\"#5a5552\" stroke-width=\"0.7\"/><path d=\"M").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(a_822, 0D)) - 1.2))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(a_822, 1D)) - 0.4))))).S("L").V(Call(f1_16, V.Undef, Add(GetIdx(f_824, 0D), ((V)(0.6))))).S(" ").V(Call(f1_16, V.Undef, Add(GetIdx(f_824, 1D), ((V)(0.6))))).S("\" stroke=\"#5a5552\" stroke-width=\"0.4\"/>");
s_827 = Add(Call(slab_44, V.Undef, C_815, P_805, ((V)(T_803)), ((V)("#2a2827"))), Call(top_45, V.Undef, C_815, ((V)(T_803)), ((V)(JsStrBuf.Begin().V(Call(face_46, V.Undef, id_817, P_805, ((V)(art_818.Str)), ((V)(0.25)))).S(flap_826.Str).End()))));
return NewObj(3).Put("defs", DEF20_50).Put("front", s_827).Put("bb", Invoke(C_815, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_806;
return default;
}, 1, "", true));
Set(N_42, "jute20", Fn((V _arrowThis895, int _argc888, V S_894, V _a891, V _a892, V _a893, V[] _rest889) => {
double A_896 = 0;
double B_897 = 0;
double T_898 = 0;
V P_899 = default;
V D_900 = default;
A_896 = 94D;
B_897 = 64D;
T_898 = 2.4;
P_899 = Call(ellP_49, V.Undef, ((V)(A_896)), ((V)(B_897)), ((V)(72D)));
D_900 = Call(RUG_51, V.Undef, ((V)(204D)), ((V)(140D)), NewObj(1).Put("round", ((V)(1D))).V);
Set(D_900, "fx", Fn((V _arrowThis908, int _argc901, V ctx_907, V _a904, V _a905, V _a906, V[] _rest902) => {
V C_909 = default;
V id_910 = default;
V JT_911 = default;
V BK_912 = default;
V CR_913 = default;
double RW_914 = 0;
V PAT_915 = default;
V rr_916 = default;
JsStrBuf art_917 = null;
double k_918 = 0;
V star_919 = default;
V pom_920 = default;
V c0_921 = default;
V pm_922 = default;
V s_923 = default;
C_909 = Call(cam_43, V.Undef, ctx_907);
id_910 = Invoke(C_909, "u", ((V)("jt")));
JT_911 = ((V)("#c9a46a"));
BK_912 = ((V)("#2f2720"));
CR_913 = ((V)("#f1e6cc"));
RW_914 = 4.2;
PAT_915 = Arr(JT_911, JT_911, BK_912, BK_912, BK_912, JT_911, CR_913, JT_911, JT_911, BK_912, JT_911, JT_911, CR_913, CR_913, JT_911, BK_912, JT_911, JT_911, CR_913, JT_911);
rr_916 = Fn((V _arrowThis931, int _argc924, V k_930, V _a927, V _a928, V _a929, V[] _rest925) => {
return Arr(((V)((((A_896 - (RW_914 / 2D)) - 0.4) - (ToNum(k_930) * RW_914)))), ((V)((((B_897 - (RW_914 / 2D)) - 0.4) - (ToNum(k_930) * RW_914)))));
}, 1, "", true);
art_917 = new JsStrBuf(string.Concat("<ellipse rx=\"", NumStr(A_896), "\" ry=\"", NumStr(B_897), "\" fill=\"#5a4428\"/>"));
k_918 = 0D;
{
while (true) {
V rx_933 = default;
V ry_934 = default;
V c_935 = default;
V E_936 = default;
{ V _t937 = Call(rr_916, V.Undef, ((V)(k_918)));
{ V _t938 = ListOf(_t937);
{ V _t939 = GetIdx(_t938, 0D);
rx_933 = _t939; }
{ V _t940 = GetIdx(_t938, 1D);
ry_934 = _t940; }
} }
if (LtN(ry_934, 12D)) {
break;
}
c_935 = GetIdx(PAT_915, (k_918 % ToNum(Get(PAT_915, "length"))));
E_936 = Fn((V _arrowThis950, int _argc941, V dx_947, V w_948, V ex_949, V _a946, V[] _rest942) => {
return ((V)(string.Concat("<ellipse rx=\"", ToStr(Call(f1_16, V.Undef, Add(rx_933, dx_947))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, Add(ry_934, dx_947))), "\" fill=\"none\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, w_948)), "\" ", ToStr(ex_949), "/>")));
}, 3, "", true);
art_917.V(Add(Add(Add(Add(Call(E_936, V.Undef, ((V)(0.5)), ((V)(RW_914)), ((V)("stroke=\"#000000\" stroke-opacity=\"0.35\""))), Call(E_936, V.Undef, ((V)(0D)), ((V)((RW_914 - 0.5))), ((V)(string.Concat("stroke=\"", ToStr(c_935), "\""))))), Call(E_936, V.Undef, ((V)((RW_914 * 0.22))), ((V)((RW_914 * 0.42))), ((V)(string.Concat("stroke=\"", ToStr(Call(shade_10, V.Undef, c_935, ((V)(0.66)))), "\" stroke-dasharray=\"1.1 1.3\" stroke-dashoffset=\"", ToStr(Call(f1_16, V.Undef, ((V)((k_918 * 0.7))))), "\" opacity=\"0.75\""))))), Call(E_936, V.Undef, ((V)(((-RW_914) * 0.22))), ((V)((RW_914 * 0.42))), ((V)(string.Concat("stroke=\"", ToStr(Call(shade_10, V.Undef, c_935, ((V)(0.66)))), "\" stroke-dasharray=\"1.1 1.3\" stroke-dashoffset=\"", ToStr(Call(f1_16, V.Undef, ((V)(((k_918 * 0.7) + 1.2))))), "\" opacity=\"0.75\""))))), Call(E_936, V.Undef, ((V)(((-RW_914) * 0.3))), ((V)(0.5)), ((V)(string.Concat("stroke=\"", ToStr((SEq(c_935, BK_912) ? ((V)("#6a5a4a")) : Call(shade_10, V.Undef, c_935, ((V)(1.3))))), "\" stroke-dasharray=\"1.4 1\" opacity=\"0.85\""))))));
k_918++;
}
}
{
V rx_951 = default;
V ry_952 = default;
{ V _t953 = Call(rr_916, V.Undef, ((V)(k_918)));
{ V _t954 = ListOf(_t953);
{ V _t955 = GetIdx(_t954, 0D);
rx_951 = _t955; }
{ V _t956 = GetIdx(_t954, 1D);
ry_952 = _t956; }
} }
art_917.S(string.Concat("<ellipse rx=\"", ToStr(Call(f1_16, V.Undef, Add(rx_951, ((V)((RW_914 / 2D)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, Add(ry_952, ((V)((RW_914 / 2D)))))), "\" fill=\"", ToStr(JT_911), "\"/><ellipse rx=\"", ToStr(Call(f1_16, V.Undef, Add(rx_951, ((V)((RW_914 / 2D)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, Add(ry_952, ((V)((RW_914 / 2D)))))), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_10, V.Undef, JT_911, ((V)(0.66)))), "\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(ry_952) * 2D))))), "\" stroke-dasharray=\"1.1 1.3\" opacity=\"0.35\"/>"));
}
star_919 = Fn((V _arrowThis965, int _argc957, V r_963, V col_964, V _a961, V _a962, V[] _rest958) => {
return ((V)(string.Concat("<path d=\"", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis973, int _argc966, V i_972, V _a969, V _a970, V _a971, V[] _rest967) => {
double a_974 = 0;
V q_975 = default;
a_974 = ((ToNum(i_972) * PI_11) / 8D);
q_975 = (NumTruthy((ToNum(i_972) % 2D)) ? ((V)((ToNum(r_963) * 0.45))) : r_963);
return ((V)(JsStrBuf.Begin().S((Truthy(i_972) ? "L" : "M")).V(Call(f1_16, V.Undef, ((V)((ToNum(q_975) * FdLibm.Cos(a_974)))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((ToNum(q_975) * FdLibm.Sin(a_974)) * 0.72))))).End()));
return default;
}, 1, "", true)), "join", ((V)("")))), "Z\" fill=\"", ToStr(col_964), "\"/>")));
}, 2, "", true);
art_917.V(Add(Add(Call(star_919, V.Undef, ((V)(15D)), BK_912), Call(star_919, V.Undef, ((V)(10.5)), CR_913)), Call(star_919, V.Undef, ((V)(5D)), ((V)("#b5482f"))))).S(string.Concat("<circle r=\"1.4\" fill=\"", ToStr(BK_912), "\"/>"));
{
V o_976 = default;
V i_977 = default;
V ro_978 = default;
V ri_979 = default;
double n_980 = 0;
V d_981 = default;
o_976 = Call(rr_916, V.Undef, ((V)(2D)));
i_977 = Call(rr_916, V.Undef, ((V)(4D)));
ro_978 = Arr(((V)((ToNum(Add(GetIdx(o_976, 0D), ((V)((RW_914 / 2D))))) - 0.8))), ((V)((ToNum(Add(GetIdx(o_976, 1D), ((V)((RW_914 / 2D))))) - 0.8))));
ri_979 = Arr(((V)(((ToNum(GetIdx(i_977, 0D)) - (RW_914 / 2D)) + 0.8))), ((V)(((ToNum(GetIdx(i_977, 1D)) - (RW_914 / 2D)) + 0.8))));
n_980 = 64D;
d_981 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Call(rep_18, V.Undef, ((V)((n_980 + 1D))), Fn((V _arrowThis989, int _argc982, V q_988, V _a985, V _a986, V _a987, V[] _rest983) => {
double t_990 = 0;
V z_991 = default;
t_990 = (((ToNum(q_988) / n_980) * 2D) * PI_11);
z_991 = (NumTruthy((ToNum(q_988) % 2D)) ? ri_979 : ro_978);
return ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(z_991, 0D)) * FdLibm.Cos(t_990)))))).S(" ").V(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(z_991, 1D)) * FdLibm.Sin(t_990)))))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).End()));
art_917.S(string.Concat("<path d=\"", ToStr(d_981), "\" fill=\"none\" stroke=\"", ToStr(CR_913), "\" stroke-width=\"1.5\"/><path d=\"", ToStr(d_981), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.4\" opacity=\"0.5\" transform=\"translate(-0.2 -0.3)\"/>"));
}
{
V q_992 = default;
q_992 = Call(rr_916, V.Undef, ((V)(12.5)));
art_917.V(Invoke(Call(rep_18, V.Undef, ((V)(52D)), Fn((V _arrowThis1000, int _argc993, V i_999, V _a996, V _a997, V _a998, V[] _rest994) => {
double t_1001 = 0;
t_1001 = (((ToNum(i_999) / 52D) * 2D) * PI_11);
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(q_992, 0D)) * FdLibm.Cos(t_1001)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(GetIdx(q_992, 1D)) * FdLibm.Sin(t_1001)))))), "\" r=\"0.75\" fill=\"", ToStr(BK_912), "\"/>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
}
pom_920 = Arr();
{
double i_1002 = 0;
i_1002 = 0D;
while (true) {
if (!((i_1002 < 28D))) break;
double t_1004 = 0;
V q_1005 = default;
t_1004 = (((i_1002 / 28D) * 2D) * PI_11);
q_1005 = Arr(((V)(((A_896 * 1.035) * FdLibm.Cos(t_1004)))), ((V)(2.2)), ((V)(((B_897 * 1.05) * FdLibm.Sin(t_1004)))));
Invoke(pom_920, "push", Arr(GetIdx(Invoke(C_909, "P", q_1005), 1D), (NumTruthy((i_1002 % 2D)) ? CR_913 : BK_912), q_1005, ((V)(i_1002))));
i_1002++;
}
}
Invoke(pom_920, "sort", Fn((V _arrowThis1014, int _argc1006, V p_1012, V q_1013, V _a1010, V _a1011, V[] _rest1007) => {
return ((V)((ToNum(GetIdx(p_1012, 0D)) - ToNum(GetIdx(q_1013, 0D)))));
}, 2, "", true));
c0_921 = GetIdx(Invoke(C_909, "P", Arr(((V)(0D)), ((V)(0D)), ((V)(0D)))), 1D);
pm_922 = Fn((V _arrowThis1028, int _argc1015, V _a1017, V _a1018, V _a1019, V _a1020, V[] _rest1016) => {
V col_1023 = default;
V q_1025 = default;
V i_1027 = default;
{ V _t1021 = ListOf(_a1017);
{ V _t1022 = GetIdx(_t1021, 1D);
col_1023 = _t1022; }
{ V _t1024 = GetIdx(_t1021, 2D);
q_1025 = _t1024; }
{ V _t1026 = GetIdx(_t1021, 3D);
i_1027 = _t1026; }
}
return ((V)(string.Concat("<g>", ToStr(Invoke(H_12, "at", ((V)("translate")), ((V)("0 0;0 -0.7;0 0")), ((V)((1.5 + ((ToNum(i_1027) % 3D) * 0.3)))), ((V)(((-ToNum(i_1027)) * 0.23))), Call(SPL_15, V.Undef, ((V)(2D))))), ToStr(Invoke(H_12, "sph", C_909, q_1025, ((V)(2.5)), col_1023)), "</g>")));
}, 1, "", true);
s_923 = Add(Add(Add(Invoke(Invoke(Invoke(pom_920, "filter", Fn((V _arrowThis1036, int _argc1029, V p_1035, V _a1032, V _a1033, V _a1034, V[] _rest1030) => {
return (Lt(GetIdx(p_1035, 0D), c0_921) ? V.True : V.False);
}, 1, "", true)), "map", pm_922), "join", ((V)(""))), Call(slab_44, V.Undef, C_909, P_899, ((V)(T_898)), ((V)("#6e5432")))), Call(top_45, V.Undef, C_909, ((V)(T_898)), Call(face_46, V.Undef, id_910, P_899, ((V)(art_917.Str)), ((V)(0.2))))), Invoke(Invoke(Invoke(pom_920, "filter", Fn((V _arrowThis1044, int _argc1037, V p_1043, V _a1040, V _a1041, V _a1042, V[] _rest1038) => {
return (Ge(GetIdx(p_1043, 0D), c0_921) ? V.True : V.False);
}, 1, "", true)), "map", pm_922), "join", ((V)(""))));
return NewObj(3).Put("defs", DEF20_50).Put("front", s_923).Put("bb", Invoke(C_909, "bb", ((V)(6D)))).V;
return default;
}, 1, "", true));
return D_900;
return default;
}, 1, "", true));
Set(N_42, "pers20", Fn((V _arrowThis1052, int _argc1045, V S_1051, V _a1048, V _a1049, V _a1050, V[] _rest1046) => {
double W_1053 = 0;
double Dd_1054 = 0;
double T_1055 = 0;
V P_1056 = default;
V D_1057 = default;
W_1053 = 196D;
Dd_1054 = 128D;
T_1055 = 1.4;
P_1056 = Call(rrP_47, V.Undef, ((V)(W_1053)), ((V)(Dd_1054)), ((V)(1D)));
D_1057 = Call(RUG_51, V.Undef, ((V)(212D)), ((V)(132D)));
Set(D_1057, "fx", Fn((V _arrowThis1065, int _argc1058, V ctx_1064, V _a1061, V _a1062, V _a1063, V[] _rest1059) => {
V C_1066 = default;
V R_1067 = default;
V id_1068 = default;
V FLD_1069 = default;
V NV_1070 = default;
V IV_1071 = default;
V GD_1072 = default;
V TL_1073 = default;
V RS_1074 = default;
double FI_1075 = 0;
V rect_1076 = default;
V along_1077 = default;
V defs_1078 = default;
V art_1079 = default;
JsStrBuf gold_1080 = null;
JsStrBuf lat_1081 = null;
JsStrBuf fl_1082 = null;
V lobe_1083 = default;
V med_1084 = default;
V shine_1085 = default;
JsStrBuf tas_1086 = null;
V s_1087 = default;
C_1066 = Call(cam_43, V.Undef, ctx_1064);
R_1067 = Call(rng_13, V.Undef, ((V)("pers20")));
id_1068 = Invoke(C_1066, "u", ((V)("ps")));
FLD_1069 = ((V)("#a01f36"));
NV_1070 = ((V)("#1d2848"));
IV_1071 = ((V)("#f1e0bd"));
GD_1072 = ((V)("GOLDX"));
TL_1073 = ((V)("#2d7a76"));
RS_1074 = ((V)("#e47b8f"));
FI_1075 = 18.4;
rect_1076 = Fn((V _arrowThis1096, int _argc1088, V i_1094, V col_1095, V _a1092, V _a1093, V[] _rest1089) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, Add(((V)(((-W_1053) / 2D))), i_1094))), "\" y=\"", ToStr(Call(f1_16, V.Undef, Add(((V)(((-Dd_1054) / 2D))), i_1094))), "\" width=\"", ToStr(Call(f1_16, V.Undef, ((V)((W_1053 - (2D * ToNum(i_1094))))))), "\" height=\"", ToStr(Call(f1_16, V.Undef, ((V)((Dd_1054 - (2D * ToNum(i_1094))))))), "\" fill=\"", ToStr(col_1095), "\"/>")));
}, 2, "", true);
along_1077 = Fn((V _arrowThis1106, int _argc1097, V inset_1103, V step_1104, V fn_1105, V _a1102, V[] _rest1098) => {
V L_1107 = default;
JsStrBuf o_1108 = null;
L_1107 = Arr(Arr(Add(((V)(((-W_1053) / 2D))), inset_1103), Add(((V)(((-Dd_1054) / 2D))), inset_1103)), Arr(((V)(((W_1053 / 2D) - ToNum(inset_1103)))), Add(((V)(((-Dd_1054) / 2D))), inset_1103)), Arr(((V)(((W_1053 / 2D) - ToNum(inset_1103)))), ((V)(((Dd_1054 / 2D) - ToNum(inset_1103))))), Arr(Add(((V)(((-W_1053) / 2D))), inset_1103), ((V)(((Dd_1054 / 2D) - ToNum(inset_1103))))));
o_1108 = new JsStrBuf("");
Invoke(L_1107, "forEach", Fn((V _arrowThis1117, int _argc1109, V a_1115, V i_1116, V _a1113, V _a1114, V[] _rest1110) => {
V b_1118 = default;
double len_1119 = 0;
double n_1120 = 0;
double ux_1121 = 0;
double uz_1122 = 0;
double sl_1123 = 0;
b_1118 = GetIdx(L_1107, (ToNum(Add(i_1116, ((V)(1D)))) % 4D));
len_1119 = Hypot((ToNum(GetIdx(b_1118, 0D)) - ToNum(GetIdx(a_1115, 0D))), (ToNum(GetIdx(b_1118, 1D)) - ToNum(GetIdx(a_1115, 1D))));
n_1120 = Round((len_1119 / ToNum(step_1104)));
ux_1121 = ((ToNum(GetIdx(b_1118, 0D)) - ToNum(GetIdx(a_1115, 0D))) / len_1119);
uz_1122 = ((ToNum(GetIdx(b_1118, 1D)) - ToNum(GetIdx(a_1115, 1D))) / len_1119);
sl_1123 = (len_1119 / n_1120);
{
double k_1124 = 0;
k_1124 = 0D;
while (true) {
if (!((k_1124 < n_1120))) break;
o_1108.V(Call(fn_1105, V.Undef, Add(GetIdx(a_1115, 0D), ((V)(((ux_1121 * (k_1124 + 0.5)) * sl_1123)))), Add(GetIdx(a_1115, 1D), ((V)(((uz_1122 * (k_1124 + 0.5)) * sl_1123)))), ((V)(ux_1121)), ((V)(uz_1122)), ((V)(k_1124)), ((V)(sl_1123))));
k_1124++;
}
}
return default;
}, 2, "", true));
return ((V)(o_1108.Str));
return default;
}, 3, "", true);
defs_1078 = ((V)(string.Concat(string.Concat("<defs><linearGradient id=\"", ToStr(id_1068), "s\" gradientUnits=\"userSpaceOnUse\" x1=\"-50\" y1=\"-40\" x2=\"-10\" y2=\"40\"><stop offset=\"0\" stop-color=\"#fff4c8\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#fff4c8\" stop-opacity=\"1\"/><stop offset=\"1\" stop-color=\"#fff4c8\" stop-opacity=\"0\"/><animateTransform attributeName=\"gradientTransform\" type=\"translate\" values=\"-140 0;-140 0;260 0\" keyTimes=\"0;0.3;1\" dur=\"6s\" repeatCount=\"indefinite\"/></linearGradient>"), string.Concat("<linearGradient id=\"", ToStr(id_1068), "v\" gradientUnits=\"userSpaceOnUse\" x1=\"-100\" y1=\"0\" x2=\"100\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffd8e0\" stop-opacity=\"0.2\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><animateTransform attributeName=\"gradientTransform\" type=\"translate\" values=\"-160 0;160 0;-160 0\" dur=\"14s\" repeatCount=\"indefinite\"/></linearGradient>"), string.Concat("<clipPath id=\"", ToStr(id_1068), "f\"><rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)((((-W_1053) / 2D) + FI_1075))))), "\" y=\"", ToStr(Call(f1_16, V.Undef, ((V)((((-Dd_1054) / 2D) + FI_1075))))), "\" width=\"", ToStr(Call(f1_16, V.Undef, ((V)((W_1053 - (2D * FI_1075)))))), "\" height=\"", ToStr(Call(f1_16, V.Undef, ((V)((Dd_1054 - (2D * FI_1075)))))), "\"/></clipPath><pattern id=\"", ToStr(id_1068), "k\" width=\"1.2\" height=\"1.2\" patternUnits=\"userSpaceOnUse\"><rect width=\"0.6\" height=\"1\" fill=\"#000000\" opacity=\"0.07\"/></pattern></defs>"))));
art_1079 = Add(Add(Add(Add(Add(Call(rect_1076, V.Undef, ((V)(0D)), NV_1070), Call(rect_1076, V.Undef, ((V)(2D)), IV_1071)), Call(rect_1076, V.Undef, ((V)(5.2)), NV_1070)), Call(rect_1076, V.Undef, ((V)(15.6)), IV_1071)), Call(rect_1076, V.Undef, ((V)(17.4)), NV_1070)), Call(rect_1076, V.Undef, ((V)(FI_1075)), FLD_1069));
gold_1080 = new JsStrBuf("");
art_1079 = ((V)(JsStrBuf.Begin().V(art_1079).S(string.Concat("<path d=\"", ToStr(Call(along_1077, V.Undef, ((V)(2D)), ((V)(4D)), Fn((V _arrowThis1138, int _argc1126, V x_1132, V z_1133, V ux_1134, V uz_1135, V[] _rest1127) => {
V k_1136 = default;
V s_1137 = default;
k_1136 = (_argc1126 > 4 ? _rest1127[0] : V.Undef);
s_1137 = (_argc1126 > 5 ? _rest1127[1] : V.Undef);
return ((V)(string.Concat("M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_1132) - ((ToNum(ux_1134) * ToNum(s_1137)) / 2D)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(z_1133) - ((ToNum(uz_1135) * ToNum(s_1137)) / 2D)))))), "L", ToStr(Call(f1_16, V.Undef, Add(x_1132, ((V)(((ToNum(ux_1134) * ToNum(s_1137)) / 2D)))))), " ", ToStr(Call(f1_16, V.Undef, Add(z_1133, ((V)(((ToNum(uz_1135) * ToNum(s_1137)) / 2D)))))), "L", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_1132) - (ToNum(uz_1135) * 3.2)))))), " ", ToStr(Call(f1_16, V.Undef, Add(z_1133, ((V)((ToNum(ux_1134) * 3.2)))))), "Z")));
}, 6, "", true))), "\" fill=\"", ToStr(FLD_1069), "\"/>")).End()));
art_1079 = ((V)(JsStrBuf.Begin().V(art_1079).S(string.Concat("<path d=\"", ToStr(Call(along_1077, V.Undef, ((V)(10.4)), ((V)(5.5)), Fn((V _arrowThis1151, int _argc1139, V x_1145, V z_1146, V ux_1147, V uz_1148, V[] _rest1140) => {
double sg_1152 = 0;
V k_1149 = default;
V s_1150 = default;
k_1149 = (_argc1139 > 4 ? _rest1140[0] : V.Undef);
s_1150 = (_argc1139 > 5 ? _rest1140[1] : V.Undef);
sg_1152 = (NumTruthy((ToNum(k_1149) % 2D)) ? 1D : (-1D));
return ((V)(string.Concat("M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_1145) - ((ToNum(ux_1147) * ToNum(s_1150)) / 2D)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(z_1146) - ((ToNum(uz_1148) * ToNum(s_1150)) / 2D)))))), "Q", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_1145) - ((ToNum(uz_1148) * 3D) * sg_1152)))))), " ", ToStr(Call(f1_16, V.Undef, Add(z_1146, ((V)(((ToNum(ux_1147) * 3D) * sg_1152)))))), " ", ToStr(Call(f1_16, V.Undef, Add(x_1145, ((V)(((ToNum(ux_1147) * ToNum(s_1150)) / 2D)))))), " ", ToStr(Call(f1_16, V.Undef, Add(z_1146, ((V)(((ToNum(uz_1148) * ToNum(s_1150)) / 2D)))))))));
return default;
}, 6, "", true))), "\" stroke=\"", ToStr(TL_1073), "\" stroke-width=\"0.9\" fill=\"none\"/>")).End()));
art_1079 = Add(art_1079, Call(along_1077, V.Undef, ((V)(10.4)), ((V)(11D)), Fn((V _arrowThis1161, int _argc1153, V x_1159, V z_1160, V _a1157, V _a1158, V[] _rest1154) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(f1_16, V.Undef, x_1159)), " ", ToStr(Call(f1_16, V.Undef, z_1160)), ")\">", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(8D)), Fn((V _arrowThis1169, int _argc1162, V q_1168, V _a1165, V _a1166, V _a1167, V[] _rest1163) => {
return ((V)(string.Concat("<ellipse cy=\"-2.2\" rx=\"1.1\" ry=\"2.2\" fill=\"", ToStr((NumTruthy((ToNum(q_1168) % 2D)) ? RS_1074 : ((V)("#c9465e")))), "\" transform=\"rotate(", NumStr((ToNum(q_1168) * 45D)), ")\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<circle r=\"1.4\" fill=\"", ToStr(IV_1071), "\"/></g>")));
}, 2, "", true)));
gold_1080.V(Add(Call(along_1077, V.Undef, ((V)(10.4)), ((V)(11D)), Fn((V _arrowThis1178, int _argc1170, V x_1176, V z_1177, V _a1174, V _a1175, V[] _rest1171) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_16, V.Undef, x_1176)), "\" cy=\"", ToStr(Call(f1_16, V.Undef, z_1177)), "\" r=\"0.8\" fill=\"", ToStr(GD_1072), "\"/>")));
}, 2, "", true)), Call(along_1077, V.Undef, ((V)(10.4)), ((V)(11D)), Fn((V _arrowThis1191, int _argc1179, V x_1185, V z_1186, V ux_1187, V uz_1188, V[] _rest1180) => {
V k_1189 = default;
V s_1190 = default;
k_1189 = (_argc1179 > 4 ? _rest1180[0] : V.Undef);
s_1190 = (_argc1179 > 5 ? _rest1180[1] : V.Undef);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, Add(x_1185, ((V)(((ToNum(ux_1187) * ToNum(s_1190)) / 2D)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(Add(z_1186, ((V)(((ToNum(uz_1188) * ToNum(s_1190)) / 2D))))) - 1.6))))), "l1.3 1.6l-1.3 1.6l-1.3 -1.6Z\" fill=\"", ToStr(GD_1072), "\"/>")));
}, 6, "", true))));
art_1079 = ((V)(JsStrBuf.Begin().V(art_1079).S(string.Concat("<path d=\"", ToStr(Call(along_1077, V.Undef, ((V)(16.5)), ((V)(2.6)), Fn((V _arrowThis1200, int _argc1192, V x_1198, V z_1199, V _a1196, V _a1197, V[] _rest1193) => {
return ((V)(string.Concat("M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_1198) - 0.5))))), " ", ToStr(Call(f1_16, V.Undef, z_1199)), "a0.5 0.5 0 1 0 1 0a0.5 0.5 0 1 0 -1 0Z")));
}, 2, "", true))), "\" fill=\"", ToStr(NV_1070), "\"/>")).End()));
lat_1081 = new JsStrBuf("");
fl_1082 = new JsStrBuf("");
{
double c_1201 = 0;
c_1201 = (-18D);
while (true) {
if (!((c_1201 <= 18D))) break;
lat_1081.S(string.Concat("M", NumStr((c_1201 * 12D)), " ", NumStr(((-Dd_1054) / 2D)), "l", ToStr(Call(f1_16, V.Undef, ((V)((Dd_1054 * 1.2))))), " ", NumStr(Dd_1054), "M", NumStr((c_1201 * 12D)), " ", NumStr(((-Dd_1054) / 2D)), "l", ToStr(Call(f1_16, V.Undef, ((V)(((-Dd_1054) * 1.2))))), " ", NumStr(Dd_1054)));
c_1201++;
}
}
{
double i_1203 = 0;
i_1203 = (-16D);
while (true) {
if (!((i_1203 <= 16D))) break;
{
double j_1205 = 0;
j_1205 = (-7D);
while (true) {
if (!((j_1205 <= 7D))) break;
double x_1207 = 0;
double z_1208 = 0;
if (NumTruthy(((i_1203 + j_1205) % 2D))) {
goto _cont1206;
}
x_1207 = (6D * i_1203);
z_1208 = (((5D * j_1205) + (Dd_1054 / 2D)) - (System.Math.Floor((Dd_1054 / 10D)) * 5D));
if ((((System.Math.Abs(x_1207) > ((W_1053 / 2D) - FI_1075)) || (System.Math.Abs(z_1208) > ((Dd_1054 / 2D) - FI_1075))) || ((Pow((x_1207 / 70D), 2D) + Pow((z_1208 / 40D), 2D)) < 1D))) {
goto _cont1206;
}
fl_1082.S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_16, V.Undef, ((V)(x_1207)))), " ", ToStr(Call(f1_16, V.Undef, ((V)(z_1208)))), ")\">", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis1216, int _argc1209, V q_1215, V _a1212, V _a1213, V _a1214, V[] _rest1210) => {
return ((V)(string.Concat("<ellipse cy=\"-1.3\" rx=\"0.7\" ry=\"1.3\" fill=\"", ToStr(IV_1071), "\" transform=\"rotate(", NumStr(((ToNum(q_1215) * 90D) + 45D)), ")\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<circle r=\"0.6\" fill=\"", ToStr(TL_1073), "\"/></g>"));
_cont1206: ;
j_1205++;
}
}
i_1203++;
}
}
gold_1080.S(string.Concat("<g clip-path=\"url(#", ToStr(id_1068), "f)\"><path d=\"", lat_1081.Str, "\" stroke=\"", ToStr(GD_1072), "\" stroke-width=\"0.45\" fill=\"none\" opacity=\"0.8\"/></g>"));
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis1228, int _argc1217, V _a1219, V _a1220, V _a1221, V _a1222, V[] _rest1218) => {
double cx_1229 = 0;
double cz_1230 = 0;
V lob_1231 = default;
V sx_1225 = default;
V sz_1227 = default;
{ V _t1223 = ListOf(_a1219);
{ V _t1224 = GetIdx(_t1223, 0D);
sx_1225 = _t1224; }
{ V _t1226 = GetIdx(_t1223, 1D);
sz_1227 = _t1226; }
}
cx_1229 = (ToNum(sx_1225) * ((W_1053 / 2D) - FI_1075));
cz_1230 = (ToNum(sz_1227) * ((Dd_1054 / 2D) - FI_1075));
lob_1231 = Fn((V _arrowThis1239, int _argc1232, V k_1238, V _a1235, V _a1236, V _a1237, V[] _rest1233) => {
return Call(smooth_52, V.Undef, Invoke(Call(rep_18, V.Undef, ((V)(11D)), Fn((V _arrowThis1247, int _argc1240, V i_1246, V _a1243, V _a1244, V _a1245, V[] _rest1241) => {
double t_1248 = 0;
double r_1249 = 0;
t_1248 = (((ToNum(i_1246) / 10D) * PI_11) / 2D);
r_1249 = (ToNum(k_1238) * (1D + (0.1 * FdLibm.Cos((8D * t_1248)))));
return Arr(((V)((cx_1229 - (((ToNum(sx_1225) * r_1249) * 32D) * FdLibm.Cos(t_1248))))), ((V)((cz_1230 - (((ToNum(sz_1227) * r_1249) * 22D) * FdLibm.Sin(t_1248))))));
return default;
}, 1, "", true)), "concat", Arr(Arr(((V)(cx_1229)), ((V)(cz_1230))))));
}, 1, "", true);
art_1079 = ((V)(JsStrBuf.Begin().V(art_1079).S(string.Concat("<path d=\"", ToStr(Call(lob_1231, V.Undef, ((V)(1D)))), "\" fill=\"", ToStr(NV_1070), "\"/><path d=\"", ToStr(Call(lob_1231, V.Undef, ((V)(0.78)))), "\" fill=\"", ToStr(IV_1071), "\"/><path d=\"", ToStr(Call(lob_1231, V.Undef, ((V)(0.62)))), "\" fill=\"", ToStr(TL_1073), "\"/>")).End()));
gold_1080.S(string.Concat("<path d=\"", ToStr(Call(lob_1231, V.Undef, ((V)(0.4)))), "\" fill=\"", ToStr(GD_1072), "\"/>"));
return default;
}, 1, "", true));
art_1079 = ((V)(JsStrBuf.Begin().V(art_1079).V(Invoke(((V)(gold_1080.Str)), "replace", NewRegExp(RX0, "GOLDX", "g"), ((V)("#e3b24c")))).S(fl_1082.Str).End()));
gold_1080.Set("");
lobe_1083 = Fn((V _arrowThis1260, int _argc1250, V k_1256, V n_1257, V a_1258, V col_1259, V[] _rest1251) => {
return ((V)(string.Concat("<path d=\"", ToStr(Call(smooth_52, V.Undef, Call(rep_18, V.Undef, ((V)((ToNum(n_1257) * 4D))), Fn((V _arrowThis1268, int _argc1261, V i_1267, V _a1264, V _a1265, V _a1266, V[] _rest1262) => {
double t_1269 = 0;
double r_1270 = 0;
t_1269 = (((ToNum(i_1267) / (ToNum(n_1257) * 4D)) * 2D) * PI_11);
r_1270 = (ToNum(k_1256) * ((1D - ToNum(a_1258)) + (ToNum(a_1258) * System.Math.Abs(FdLibm.Cos(((ToNum(n_1257) * t_1269) / 2D))))));
return Arr(((V)(((54D * r_1270) * FdLibm.Cos(t_1269)))), ((V)(((35D * r_1270) * FdLibm.Sin(t_1269)))));
return default;
}, 1, "", true)))), "\" fill=\"", ToStr(col_1259), "\"/>")));
}, 4, "", true);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1278, int _argc1271, V sx_1277, V _a1274, V _a1275, V _a1276, V[] _rest1272) => {
art_1079 = ((V)(JsStrBuf.Begin().V(art_1079).S(string.Concat("<path d=\"M", NumStr((ToNum(sx_1277) * 46D)), " -8L", NumStr((ToNum(sx_1277) * 60D)), " -4.5L", NumStr((ToNum(sx_1277) * 67D)), " 0L", NumStr((ToNum(sx_1277) * 60D)), " 4.5L", NumStr((ToNum(sx_1277) * 46D)), " 8Z\" fill=\"", ToStr(NV_1070), "\"/><path d=\"M", NumStr((ToNum(sx_1277) * 50D)), " -4L", NumStr((ToNum(sx_1277) * 59D)), " -2.2L", NumStr((ToNum(sx_1277) * 63D)), " 0L", NumStr((ToNum(sx_1277) * 59D)), " 2.2L", NumStr((ToNum(sx_1277) * 50D)), " 4Z\" fill=\"", ToStr(IV_1071), "\"/>")).End()));
gold_1080.S(string.Concat("<circle cx=\"", NumStr((ToNum(sx_1277) * 70D)), "\" cy=\"0\" r=\"2.2\" fill=\"", ToStr(GD_1072), "\"/><path d=\"M", NumStr((ToNum(sx_1277) * 52D)), " 0H", NumStr((ToNum(sx_1277) * 61D)), "\" stroke=\"", ToStr(GD_1072), "\" stroke-width=\"0.9\"/>"));
return default;
}, 1, "", true));
art_1079 = Add(art_1079, Add(Add(Call(lobe_1083, V.Undef, ((V)(1D)), ((V)(16D)), ((V)(0.12)), NV_1070), Call(lobe_1083, V.Undef, ((V)(0.9)), ((V)(16D)), ((V)(0.12)), IV_1071)), Call(lobe_1083, V.Undef, ((V)(0.8)), ((V)(16D)), ((V)(0.1)), FLD_1069)));
art_1079 = Add(art_1079, Invoke(Call(rep_18, V.Undef, ((V)(12D)), Fn((V _arrowThis1286, int _argc1279, V i_1285, V _a1282, V _a1283, V _a1284, V[] _rest1280) => {
double a_1287 = 0;
double x_1288 = 0;
double z_1289 = 0;
a_1287 = ((ToNum(i_1285) * PI_11) / 6D);
x_1288 = ((54D * 0.68) * FdLibm.Cos(a_1287));
z_1289 = ((35D * 0.68) * FdLibm.Sin(a_1287));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_16, V.Undef, ((V)(x_1288)))), " ", ToStr(Call(f1_16, V.Undef, ((V)(z_1289)))), "q1.6 -2.2 3.2 -0.4q0.8 1.4 -0.6 1.8\" stroke=\"", ToStr(IV_1071), "\" stroke-width=\"0.6\" fill=\"none\" transform=\"rotate(", ToStr(Call(f1_16, V.Undef, ((V)(((a_1287 * 180D) / PI_11))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(x_1288)))), " ", ToStr(Call(f1_16, V.Undef, ((V)(z_1289)))), ")\"/>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
gold_1080.S(string.Concat("<path d=\"", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(16D)), Fn((V _arrowThis1297, int _argc1290, V i_1296, V _a1293, V _a1294, V _a1295, V[] _rest1291) => {
double a_1298 = 0;
double q_1299 = 0;
a_1298 = ((ToNum(i_1296) * PI_11) / 8D);
q_1299 = (NumTruthy((ToNum(i_1296) % 2D)) ? 0.34 : 0.58);
return ((V)(JsStrBuf.Begin().S((Truthy(i_1296) ? "L" : "M")).V(Call(f1_16, V.Undef, ((V)(((54D * q_1299) * FdLibm.Cos(a_1298)))))).S(" ").V(Call(f1_16, V.Undef, ((V)(((35D * q_1299) * FdLibm.Sin(a_1298)))))).End()));
return default;
}, 1, "", true)), "join", ((V)("")))), "Z\" fill=\"", ToStr(GD_1072), "\"/>"));
med_1084 = Add(Add(Call(lobe_1083, V.Undef, ((V)(0.36)), ((V)(8D)), ((V)(0.2)), NV_1070), Call(lobe_1083, V.Undef, ((V)(0.24)), ((V)(8D)), ((V)(0.2)), TL_1073)), Call(lobe_1083, V.Undef, ((V)(0.12)), ((V)(8D)), ((V)(0.2)), RS_1074));
art_1079 = Add(art_1079, Add(Invoke(((V)(gold_1080.Str)), "replace", NewRegExp(RX0, "GOLDX", "g"), ((V)("#e3b24c"))), med_1084));
shine_1085 = Invoke(((V)(gold_1080.Str)), "replace", NewRegExp(RX0, "GOLDX", "g"), ((V)(string.Concat("url(#", ToStr(id_1068), "s)"))));
art_1079 = ((V)(JsStrBuf.Begin().V(art_1079).V(shine_1085).S(string.Concat("<circle r=\"1.6\" fill=\"#e3b24c\"/>", "")).End()));
art_1079 = ((V)(JsStrBuf.Begin().V(art_1079).S(string.Concat("<rect x=\"", NumStr(((-W_1053) / 2D)), "\" y=\"", NumStr(((-Dd_1054) / 2D)), "\" width=\"", NumStr(W_1053), "\" height=\"", NumStr(Dd_1054), "\" fill=\"url(#", ToStr(id_1068), "k)\"/><rect x=\"", NumStr(((-W_1053) / 2D)), "\" y=\"", NumStr(((-Dd_1054) / 2D)), "\" width=\"", NumStr(W_1053), "\" height=\"", NumStr(Dd_1054), "\" fill=\"url(#", ToStr(id_1068), "v)\"/>")).End()));
art_1079 = Add(art_1079, Invoke(Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis1306, int _argc1300, V _a1302, V _a1303, V _a1304, V _a1305, V[] _rest1301) => {
double x_1307 = 0;
double w_1308 = 0;
x_1307 = ((ToNum(Call(R_1067, V.Undef)) - 0.5) * W_1053);
w_1308 = (4D + (ToNum(Call(R_1067, V.Undef)) * 10D));
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_16, V.Undef, ((V)(x_1307)))), "\" y=\"", NumStr(((-Dd_1054) / 2D)), "\" width=\"", ToStr(Call(f1_16, V.Undef, ((V)(w_1308)))), "\" height=\"", NumStr(Dd_1054), "\" fill=\"", (LtN(Call(R_1067, V.Undef), 0.5) ? "#ffffff" : "#3a0a1c"), "\" opacity=\"0.05\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
tas_1086 = new JsStrBuf("");
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1316, int _argc1309, V sx_1315, V _a1312, V _a1313, V _a1314, V[] _rest1310) => {
{
V z_1317 = default;
z_1317 = ((V)((((-Dd_1054) / 2D) + 2.6)));
while (true) {
V z_1317_it = z_1317;
if (!(LeN(z_1317_it, ((Dd_1054 / 2D) - 2.6)))) break;
double x0_1319 = 0;
double L_1320 = 0;
double w_1321 = 0;
x0_1319 = ((ToNum(sx_1315) * W_1053) / 2D);
L_1320 = (5.4 + (ToNum(Call(R_1067, V.Undef)) * 1.8));
w_1321 = ((ToNum(Call(R_1067, V.Undef)) - 0.5) * 1.2);
Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis1329, int _argc1322, V q_1328, V _a1325, V _a1326, V _a1327, V[] _rest1323) => {
double dz_1330 = 0;
V d_1331 = default;
dz_1330 = ((ToNum(q_1328) - 1D) * 0.55);
d_1331 = ((V)(string.Concat("M", ToStr(Call(f1_16, V.Undef, ((V)((x0_1319 + (ToNum(sx_1315) * 1.4)))))), " ", ToStr(Call(f1_16, V.Undef, z_1317_it)), "q", ToStr(Call(f1_16, V.Undef, ((V)(((ToNum(sx_1315) * L_1320) * 0.5))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((dz_1330 + w_1321))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(sx_1315) * L_1320))))), " ", ToStr(Call(f1_16, V.Undef, ((V)(((dz_1330 * 1.8) + (w_1321 * 0.5)))))))));
tas_1086.S(string.Concat("<path d=\"", ToStr(d_1331), "\" stroke=\"#c9b48e\" stroke-width=\"0.7\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"", ToStr(d_1331), "\" stroke=\"", ToStr(IV_1071), "\" stroke-width=\"0.38\" fill=\"none\" stroke-linecap=\"round\"/>"));
return default;
}, 1, "", true));
tas_1086.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((x0_1319 + (ToNum(sx_1315) * 1.3)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, z_1317_it)), "\" rx=\"1.1\" ry=\"0.95\" fill=\"#e6d3ab\" stroke=\"#b39d74\" stroke-width=\"0.2\"/>"));
z_1317 = z_1317_it;
z_1317 = Add(z_1317, ((V)(3.6)));
}
}
return default;
}, 1, "", true));
s_1087 = Add(Add(Call(slab_44, V.Undef, C_1066, P_1056, ((V)(T_1055)), ((V)("#1a2140"))), Call(top_45, V.Undef, C_1066, ((V)((T_1055 * 0.5))), ((V)(tas_1086.Str)))), Call(top_45, V.Undef, C_1066, ((V)(T_1055)), Add(defs_1078, Call(face_46, V.Undef, id_1068, P_1056, art_1079, ((V)(0.24))))));
return NewObj(3).Put("defs", DEF20_50).Put("front", s_1087).Put("bb", Invoke(C_1066, "bb", ((V)(6D)))).V;
return default;
}, 1, "", true));
return D_1057;
return default;
}, 1, "", true));
Set(N_42, "silk20", Fn((V _arrowThis1339, int _argc1332, V S_1338, V _a1335, V _a1336, V _a1337, V[] _rest1333) => {
double A_1340 = 0;
double B_1341 = 0;
double T_1342 = 0;
V rO_1343 = default;
V P_1344 = default;
V D_1345 = default;
A_1340 = 104D;
B_1341 = 68D;
T_1342 = 2.6;
rO_1343 = Fn((V _arrowThis1353, int _argc1346, V t_1352, V _a1349, V _a1350, V _a1351, V[] _rest1347) => {
return ((V)((((1D + (0.05 * FdLibm.Sin(((2D * ToNum(t_1352)) + 0.7)))) + (0.035 * FdLibm.Sin(((3D * ToNum(t_1352)) + 2.1)))) + (0.02 * FdLibm.Sin(((5D * ToNum(t_1352)) + 4.4))))));
}, 1, "", true);
P_1344 = Call(rep_18, V.Undef, ((V)(72D)), Fn((V _arrowThis1361, int _argc1354, V i_1360, V _a1357, V _a1358, V _a1359, V[] _rest1355) => {
double t_1362 = 0;
V r_1363 = default;
t_1362 = (((ToNum(i_1360) / 72D) * 2D) * PI_11);
r_1363 = Call(rO_1343, V.Undef, ((V)(t_1362)));
return Arr(((V)(((A_1340 * ToNum(r_1363)) * FdLibm.Cos(t_1362)))), ((V)(((B_1341 * ToNum(r_1363)) * FdLibm.Sin(t_1362)))));
return default;
}, 1, "", true));
D_1345 = Call(RUG_51, V.Undef, ((V)(226D)), ((V)(152D)), NewObj(1).Put("round", ((V)(1D))).V);
Set(D_1345, "fx", Fn((V _arrowThis1371, int _argc1364, V ctx_1370, V _a1367, V _a1368, V _a1369, V[] _rest1365) => {
V C_1372 = default;
V R_1373 = default;
V id_1374 = default;
JsStrBuf art_1375 = null;
V isl_1376 = default;
V s_1377 = default;
C_1372 = Call(cam_43, V.Undef, ctx_1370);
R_1373 = Call(rng_13, V.Undef, ((V)("silk20")));
id_1374 = Invoke(C_1372, "u", ((V)("sk")));
art_1375 = new JsStrBuf(string.Concat(string.Concat("<defs><linearGradient id=\"", ToStr(id_1374), "i\" gradientUnits=\"userSpaceOnUse\" x1=\"-100\" y1=\"0\" x2=\"100\" y2=\"0\" spreadMethod=\"repeat\"><stop offset=\"0\" stop-color=\"#ffd27a\"/><stop offset=\"0.33\" stop-color=\"#ff9ec4\"/><stop offset=\"0.66\" stop-color=\"#8fe4ff\"/><stop offset=\"1\" stop-color=\"#ffd27a\"/><animateTransform attributeName=\"gradientTransform\" type=\"translate\" values=\"0 0;200 0\" dur=\"7s\" repeatCount=\"indefinite\"/></linearGradient>"), string.Concat("<pattern id=\"", ToStr(id_1374), "p\" width=\"1.3\" height=\"1.3\" patternUnits=\"userSpaceOnUse\"><circle cx=\"0.4\" cy=\"0.4\" r=\"0.32\" fill=\"#000000\" opacity=\"0.07\"/><circle cx=\"1\" cy=\"1\" r=\"0.28\" fill=\"#ffffff\" opacity=\"0.1\"/></pattern></defs>")));
art_1375.S(string.Concat("<path d=\"", ToStr(Call(dP_48, V.Undef, P_1344)), "\" fill=\"#efe7d8\"/>")).S("<g filter=\"url(#r13b)\">").V(Invoke(Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis1385, int _argc1378, V i_1384, V _a1381, V _a1382, V _a1383, V[] _rest1379) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((((ToNum(Call(R_1373, V.Undef)) - 0.5) * A_1340) * 1.6))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((((ToNum(Call(R_1373, V.Undef)) - 0.5) * B_1341) * 1.6))))), "\" rx=\"", ToStr(Call(f1_16, V.Undef, ((V)((12D + (ToNum(Call(R_1373, V.Undef)) * 14D)))))), "\" ry=\"", ToStr(Call(f1_16, V.Undef, ((V)((8D + (ToNum(Call(R_1373, V.Undef)) * 9D)))))), "\" fill=\"", (NumTruthy((ToNum(i_1384) % 2D)) ? "#f6f0e4" : "#ddd2bf"), "\" opacity=\"0.5\"/>")));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
isl_1376 = Fn((V _arrowThis1397, int _argc1386, V cx_1392, V cz_1393, V rx_1394, V rz_1395, V[] _rest1387) => {
V Q_1398 = default;
double p1_1399 = 0;
double p2_1400 = 0;
V sd_1396 = default;
sd_1396 = (_argc1386 > 4 ? _rest1387[0] : V.Undef);
Q_1398 = Call(rng_13, V.Undef, sd_1396);
p1_1399 = (ToNum(Call(Q_1398, V.Undef)) * 6D);
p2_1400 = (ToNum(Call(Q_1398, V.Undef)) * 6D);
return Fn((V _arrowThis1408, int _argc1401, V k_1407, V _a1404, V _a1405, V _a1406, V[] _rest1402) => {
return Call(smooth_52, V.Undef, Call(rep_18, V.Undef, ((V)(24D)), Fn((V _arrowThis1416, int _argc1409, V i_1415, V _a1412, V _a1413, V _a1414, V[] _rest1410) => {
double t_1417 = 0;
double r_1418 = 0;
t_1417 = (((ToNum(i_1415) / 24D) * 2D) * PI_11);
r_1418 = (ToNum(k_1407) * ((1D + (0.18 * FdLibm.Sin(((2D * t_1417) + p1_1399)))) + (0.09 * FdLibm.Sin(((3D * t_1417) + p2_1400)))));
return Arr(Add(cx_1392, ((V)(((ToNum(rx_1394) * r_1418) * FdLibm.Cos(t_1417))))), Add(cz_1393, ((V)(((ToNum(rz_1395) * r_1418) * FdLibm.Sin(t_1417))))));
return default;
}, 1, "", true)));
}, 1, "", true);
return default;
}, 5, "", true);
Invoke(Arr(Arr(((V)((-50D))), ((V)((-6D))), ((V)(40D)), ((V)(30D)), ((V)("#1f6066"))), Arr(((V)(42D)), ((V)(18D)), ((V)(42D)), ((V)(26D)), ((V)("#c3592f"))), Arr(((V)(64D)), ((V)((-32D))), ((V)(22D)), ((V)(15D)), ((V)("#e3a83a"))), Arr(((V)((-58D))), ((V)(40D)), ((V)(22D)), ((V)(12D)), ((V)("#e8b4a4"))), Arr(((V)((-4D))), ((V)((-36D))), ((V)(18D)), ((V)(11D)), ((V)("#3b3a3c"))), Arr(((V)(4D)), ((V)(34D)), ((V)(12D)), ((V)(8D)), ((V)("#e3a83a")))), "forEach", Fn((V _arrowThis1437, int _argc1419, V _a1421, V i_1425, V _a1423, V _a1424, V[] _rest1420) => {
V f_1438 = default;
V d_1439 = default;
V x_1428 = default;
V z_1430 = default;
V rx_1432 = default;
V rz_1434 = default;
V col_1436 = default;
{ V _t1426 = ListOf(_a1421);
{ V _t1427 = GetIdx(_t1426, 0D);
x_1428 = _t1427; }
{ V _t1429 = GetIdx(_t1426, 1D);
z_1430 = _t1429; }
{ V _t1431 = GetIdx(_t1426, 2D);
rx_1432 = _t1431; }
{ V _t1433 = GetIdx(_t1426, 3D);
rz_1434 = _t1433; }
{ V _t1435 = GetIdx(_t1426, 4D);
col_1436 = _t1435; }
}
f_1438 = Call(isl_1376, V.Undef, x_1428, z_1430, rx_1432, rz_1434, ((V)(JsStrBuf.Begin().S("sk").V(i_1425).End())));
d_1439 = Call(f_1438, V.Undef, ((V)(1D)));
art_1375.S(string.Concat("<path d=\"", ToStr(d_1439), "\" fill=\"#000000\" opacity=\"0.34\" transform=\"translate(0.7 1.1)\" filter=\"url(#r13s)\"/><path d=\"", ToStr(d_1439), "\" fill=\"", ToStr(Call(shade_10, V.Undef, col_1436, ((V)(0.78)))), "\"/><path d=\"", ToStr(Call(f_1438, V.Undef, ((V)(0.97)))), "\" fill=\"", ToStr(col_1436), "\" transform=\"translate(-0.2 -0.3)\"/>")).V(Invoke(Invoke(Arr(((V)(0.74)), ((V)(0.5)), ((V)(0.27))), "map", Fn((V _arrowThis1447, int _argc1440, V k_1446, V _a1443, V _a1444, V _a1445, V[] _rest1441) => {
return ((V)(string.Concat("<path d=\"", ToStr(Call(f_1438, V.Undef, k_1446)), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_10, V.Undef, col_1436, ((V)(0.7)))), "\" stroke-width=\"0.6\"/><path d=\"", ToStr(Call(f_1438, V.Undef, k_1446)), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_10, V.Undef, col_1436, ((V)(1.3)))), "\" stroke-width=\"0.35\" transform=\"translate(-0.3 -0.4)\" opacity=\"0.8\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<path d=\"", ToStr(Call(f_1438, V.Undef, ((V)(0.97)))), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.55\" opacity=\"0.4\" transform=\"translate(-0.5 -0.6)\"/>"));
return default;
}, 2, "", true));
art_1375.S(string.Concat("<path d=\"", ToStr(Call(dP_48, V.Undef, P_1344)), "\" fill=\"url(#", ToStr(id_1374), "p)\"/>"));
Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis1455, int _argc1448, V k_1454, V _a1451, V _a1452, V _a1453, V[] _rest1449) => {
double z0_1456 = 0;
double a_1457 = 0;
double ph_1458 = 0;
double fq_1459 = 0;
V d_1460 = default;
double w_1461 = 0;
z0_1456 = ((((-B_1341) * 0.7) + ((ToNum(k_1454) * B_1341) * 0.46)) + ((ToNum(Call(R_1373, V.Undef)) - 0.5) * 6D));
a_1457 = (5D + (ToNum(Call(R_1373, V.Undef)) * 6D));
ph_1458 = (ToNum(Call(R_1373, V.Undef)) * 6D);
fq_1459 = (1.2 + (ToNum(Call(R_1373, V.Undef)) * 0.8));
d_1460 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Call(rep_18, V.Undef, ((V)(23D)), Fn((V _arrowThis1469, int _argc1462, V i_1468, V _a1465, V _a1466, V _a1467, V[] _rest1463) => {
double x_1470 = 0;
x_1470 = (((-A_1340) * 1.1) + (((ToNum(i_1468) * A_1340) * 2.2) / 22D));
return ((V)(JsStrBuf.Begin().V(Call(f1_16, V.Undef, ((V)(x_1470)))).S(" ").V(Call(f1_16, V.Undef, ((V)((z0_1456 + (a_1457 * FdLibm.Sin(((((x_1470 / A_1340) * PI_11) * fq_1459) + ph_1458)))))))).End()));
return default;
}, 1, "", true)), "join", ((V)("L")))).End()));
w_1461 = (NumTruthy((ToNum(k_1454) % 2D)) ? 1.3 : 2D);
art_1375.S(string.Concat("<path d=\"", ToStr(d_1460), "\" stroke=\"#000000\" stroke-width=\"", NumStr((w_1461 + 0.6)), "\" fill=\"none\" opacity=\"0.2\" stroke-linejoin=\"round\" transform=\"translate(0.4 0.6)\"/><path d=\"", ToStr(d_1460), "\" stroke=\"#fbf6ec\" stroke-width=\"", NumStr(w_1461), "\" fill=\"none\" stroke-linejoin=\"round\"/><path d=\"", ToStr(d_1460), "\" stroke=\"url(#", ToStr(id_1374), "i)\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((w_1461 * 0.75))))), "\" fill=\"none\" stroke-linejoin=\"round\" opacity=\"0.85\"/>")).S(string.Concat("<path d=\"", ToStr(d_1460), "\" pathLength=\"100\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_16, V.Undef, ((V)((w_1461 * 1.1))))), "\" stroke-linecap=\"round\" stroke-dasharray=\"3 97\" fill=\"none\" filter=\"url(#r13s)\"><animate attributeName=\"stroke-dashoffset\" values=\"0;-100\" dur=\"", ToStr(Call(n4_17, V.Undef, ((V)((5D + (ToNum(k_1454) * 1.3)))))), "s\" begin=\"", ToStr(Call(n4_17, V.Undef, ((V)(((-ToNum(k_1454)) * 1.9))))), "s\" repeatCount=\"indefinite\"/></path>"));
return default;
}, 1, "", true));
art_1375.S(string.Concat("<path d=\"", ToStr(Call(dP_48, V.Undef, Invoke(P_1344, "map", Fn((V _arrowThis1478, int _argc1471, V q_1477, V _a1474, V _a1475, V _a1476, V[] _rest1472) => {
return Arr(((V)((ToNum(GetIdx(q_1477, 0D)) * 0.965))), ((V)((ToNum(GetIdx(q_1477, 1D)) * 0.95))));
}, 1, "", true)))), "\" fill=\"none\" stroke=\"#a89a84\" stroke-width=\"0.6\" opacity=\"0.8\"/><path d=\"", ToStr(Call(dP_48, V.Undef, P_1344)), "\" fill=\"none\" stroke=\"#b9ad9b\" stroke-width=\"2.2\"/>"));
s_1377 = Add(Call(slab_44, V.Undef, C_1372, P_1344, ((V)(T_1342)), ((V)("#cbbfad"))), Call(top_45, V.Undef, C_1372, ((V)(T_1342)), Call(face_46, V.Undef, id_1374, P_1344, ((V)(art_1375.Str)), ((V)(0.2)))));
return NewObj(3).Put("defs", DEF20_50).Put("front", s_1377).Put("bb", Invoke(C_1372, "bb", ((V)(5D)))).V;
return default;
}, 1, "", true));
return D_1345;
return default;
}, 1, "", true));
Set(N_42, "fiber20", Fn((V _arrowThis1486, int _argc1479, V S_1485, V _a1482, V _a1483, V _a1484, V[] _rest1480) => {
double A_1487 = 0;
double B_1488 = 0;
double T_1489 = 0;
V P_1490 = default;
V D_1491 = default;
A_1487 = 100D;
B_1488 = 68D;
T_1489 = 2.2;
P_1490 = Call(ellP_49, V.Undef, ((V)(A_1487)), ((V)(B_1488)), ((V)(80D)));
D_1491 = Call(RUG_51, V.Undef, ((V)(214D)), ((V)(146D)), NewObj(1).Put("round", ((V)(1D))).V);
Set(D_1491, "fx", Fn((V _arrowThis1499, int _argc1492, V ctx_1498, V _a1495, V _a1496, V _a1497, V[] _rest1493) => {
V C_1500 = default;
V R_1501 = default;
V id_1502 = default;
V MOOD_1503 = default;
double NG_1504 = 0;
V gp_1505 = default;
V wt_1506 = default;
V dot_1507 = default;
V fa_1508 = default;
JsStrBuf art_1509 = null;
JsStrBuf gal_1510 = null;
V rip_1511 = default;
V glow_1512 = default;
V s_1513 = default;
C_1500 = Call(cam_43, V.Undef, ctx_1498);
R_1501 = Call(rng_13, V.Undef, ((V)("fib20")));
id_1502 = Invoke(C_1500, "u", ((V)("fo")));
MOOD_1503 = ((V)("#ff4fa0;#a66bff;#4fd8ff;#5affb0;#ffd36a;#ff7a4f;#ff4fa0"));
NG_1504 = 8D;
gp_1505 = Call(rep_18, V.Undef, ((V)(NG_1504)), Fn((V _arrowThis1520, int _argc1514, V _a1516, V _a1517, V _a1518, V _a1519, V[] _rest1515) => {
return ((V)(""));
}, 0, "", true));
wt_1506 = Arr(((V)("")), ((V)("")));
dot_1507 = Fn((V _arrowThis1530, int _argc1521, V x_1527, V z_1528, V r_1529, V _a1526, V[] _rest1522) => {
return ((V)(string.Concat("M", ToStr(Call(f1_16, V.Undef, ((V)((ToNum(x_1527) - ToNum(r_1529)))))), " ", ToStr(Call(f1_16, V.Undef, z_1528)), "a", ToStr(Call(f1_16, V.Undef, r_1529)), " ", ToStr(Call(f1_16, V.Undef, r_1529)), " 0 1 0 ", ToStr(Call(f1_16, V.Undef, ((V)((2D * ToNum(r_1529)))))), " 0a", ToStr(Call(f1_16, V.Undef, r_1529)), " ", ToStr(Call(f1_16, V.Undef, r_1529)), " 0 1 0 ", ToStr(Call(f1_16, V.Undef, ((V)(((-2D) * ToNum(r_1529)))))), " 0Z")));
}, 3, "", true);
fa_1508 = Fn((V _arrowThis1539, int _argc1531, V g_1537, V d_1538, V _a1535, V _a1536, V[] _rest1532) => {
return ((V)(string.Concat("<animate attributeName=\"", ToStr((d_1538 is var _t1540 && Truthy(_t1540) ? _t1540 : ((V)("fill")))), "\" values=\"", ToStr(MOOD_1503), "\" dur=\"12s\" begin=\"", ToStr(Call(n4_17, V.Undef, ((V)(((-ToNum(g_1537)) * 1.5))))), "s\" repeatCount=\"indefinite\"/>")));
}, 2, "", true);
{
double arm_1541 = 0;
arm_1541 = 0D;
while (true) {
if (!((arm_1541 < 3D))) break;
{
double i_1543 = 0;
i_1543 = 0D;
while (true) {
if (!((i_1543 < 300D))) break;
double t_1545 = 0;
double th_1546 = 0;
double r_1547 = 0;
t_1545 = (i_1543 / 300D);
th_1546 = (((((arm_1541 * 2D) * PI_11) / 3D) + ((t_1545 * 2.6) * PI_11)) + ((ToNum(Call(R_1501, V.Undef)) - 0.5) * (0.5 + (t_1545 * 0.4))));
r_1547 = ((5D + (Pow(t_1545, 0.8) * 92D)) + (((ToNum(Call(R_1501, V.Undef)) - 0.5) * 7D) * (0.4 + t_1545)));
OpSetK(gp_1505, ((V)((((arm_1541 * 3D) + ((double)(ToInt32((t_1545 * 4D)) | ToInt32(0D)))) % NG_1504))), 0, Call(dot_1507, V.Undef, ((V)((r_1547 * FdLibm.Cos(th_1546)))), ((V)((r_1547 * FdLibm.Sin(th_1546)))), ((V)(((0.55 + ((1D - t_1545) * 0.6)) + (ToNum(Call(R_1501, V.Undef)) * 0.3))))));
if (LtN(Call(R_1501, V.Undef), 0.08)) {
OpSetK(wt_1506, ((V)((i_1543 % 2D))), 0, Call(dot_1507, V.Undef, ((V)((r_1547 * FdLibm.Cos(th_1546)))), ((V)((r_1547 * FdLibm.Sin(th_1546)))), ((V)(0.4))));
}
i_1543++;
}
}
arm_1541++;
}
}
{
double i_1548 = 0;
i_1548 = 0D;
while (true) {
if (!((i_1548 < 240D))) break;
double r_1550 = 0;
double th_1551 = 0;
r_1550 = (8D + (System.Math.Sqrt(ToNum(Call(R_1501, V.Undef))) * 92D));
th_1551 = ((ToNum(Call(R_1501, V.Undef)) * 2D) * PI_11);
OpSetK(gp_1505, ((V)((i_1548 % NG_1504))), 0, Call(dot_1507, V.Undef, ((V)((r_1550 * FdLibm.Cos(th_1551)))), ((V)((r_1550 * FdLibm.Sin(th_1551)))), ((V)((0.28 + (ToNum(Call(R_1501, V.Undef)) * 0.22))))));
i_1548++;
}
}
art_1509 = new JsStrBuf(string.Concat("<defs><pattern id=\"", ToStr(id_1502), "w\" width=\"2\" height=\"1.6\" patternUnits=\"userSpaceOnUse\"><rect width=\"2\" height=\"1.6\" fill=\"#141224\"/><rect width=\"0.9\" height=\"0.7\" fill=\"#1d1a30\"/><rect x=\"1\" y=\"0.8\" width=\"0.9\" height=\"0.7\" fill=\"#1d1a30\"/></pattern><radialGradient id=\"", ToStr(id_1502), "c\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"1\"/><stop offset=\"0.25\" stop-color=\"#ffd6f2\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#a66bff\" stop-opacity=\"0\"/></radialGradient></defs>"));
art_1509.S(string.Concat("<ellipse rx=\"", NumStr(A_1487), "\" ry=\"", NumStr(B_1488), "\" fill=\"url(#", ToStr(id_1502), "w)\"/>"));
gal_1510 = new JsStrBuf(JsStrBuf.Begin().S("<g filter=\"url(#r13b)\" opacity=\"0.28\">").V(Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis1559, int _argc1552, V a_1558, V _a1555, V _a1556, V _a1557, V[] _rest1553) => {
double th_1560 = 0;
th_1560 = ((((ToNum(a_1558) * 2D) * PI_11) / 3D) + 2.2);
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_16, V.Undef, ((V)((40D * FdLibm.Cos(th_1560)))))), "\" cy=\"", ToStr(Call(f1_16, V.Undef, ((V)((40D * FdLibm.Sin(th_1560)))))), "\" rx=\"38\" ry=\"10\" transform=\"rotate(", ToStr(Call(f1_16, V.Undef, ((V)((((th_1560 * 180D) / PI_11) + 70D))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((40D * FdLibm.Cos(th_1560)))))), " ", ToStr(Call(f1_16, V.Undef, ((V)((40D * FdLibm.Sin(th_1560)))))), ")\" fill=\"#a66bff\">", ToStr(Call(fa_1508, V.Undef, ((V)((ToNum(a_1558) * 2D))))), "</ellipse>")));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g>").End());
gal_1510.S(string.Concat("<g filter=\"url(#r20g)\" opacity=\"0.8\">", ToStr(Invoke(Invoke(gp_1505, "map", Fn((V _arrowThis1569, int _argc1561, V d_1567, V g_1568, V _a1565, V _a1566, V[] _rest1562) => {
return ((V)(string.Concat("<path d=\"", ToStr(d_1567), "\" fill=\"#ff4fa0\">", ToStr(Call(fa_1508, V.Undef, g_1568)), "</path>")));
}, 2, "", true)), "join", ((V)("")))), "</g>")).V(Invoke(Invoke(gp_1505, "map", Fn((V _arrowThis1578, int _argc1570, V d_1576, V g_1577, V _a1574, V _a1575, V[] _rest1571) => {
return ((V)(string.Concat("<path d=\"", ToStr(d_1576), "\" fill=\"#ff4fa0\">", ToStr(Call(fa_1508, V.Undef, g_1577)), ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.7;1;0.7")), ((V)(2.4)), ((V)(((-ToNum(g_1577)) * 0.3))))), "</path>")));
}, 2, "", true)), "join", ((V)(""))));
gal_1510.V(Invoke(Invoke(wt_1506, "map", Fn((V _arrowThis1587, int _argc1579, V d_1585, V i_1586, V _a1583, V _a1584, V[] _rest1580) => {
return ((V)(string.Concat("<path d=\"", ToStr(d_1585), "\" fill=\"#ffffff\">", ToStr(Call(an_14, V.Undef, ((V)("opacity")), ((V)("0.2;1;0.2")), ((V)((1.6 + (ToNum(i_1586) * 0.7)))), ((V)(((-ToNum(i_1586)) * 0.5))))), "</path>")));
}, 2, "", true)), "join", ((V)(""))));
rip_1511 = Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis1595, int _argc1588, V i_1594, V _a1591, V _a1592, V _a1593, V[] _rest1589) => {
return ((V)(string.Concat("<circle r=\"4\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1\" opacity=\"0\"><animate attributeName=\"r\" values=\"4;98\" dur=\"4.5s\" begin=\"", ToStr(Call(n4_17, V.Undef, ((V)(((-ToNum(i_1594)) * 1.5))))), "s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0.8;0\" dur=\"4.5s\" begin=\"", ToStr(Call(n4_17, V.Undef, ((V)(((-ToNum(i_1594)) * 1.5))))), "s\" repeatCount=\"indefinite\"/>", ToStr(Call(fa_1508, V.Undef, ((V)((ToNum(i_1594) * 2D))), ((V)("stroke")))), "</circle>")));
}, 1, "", true)), "join", ((V)("")));
art_1509.S(string.Concat("<g transform=\"scale(1 ", ToStr(Call(n4_17, V.Undef, ((V)((B_1488 / A_1487))))), ")\"><g>", ToStr(Invoke(H_12, "at", ((V)("rotate")), ((V)("0;360")), ((V)(60D)))), gal_1510.Str, "</g>", ToStr(rip_1511), "<circle r=\"16\" fill=\"url(#", ToStr(id_1502), "c)\">", ToStr(Call(an_14, V.Undef, ((V)("r")), ((V)("12;18;12")), ((V)(3D)), ((V)(0D)), Call(SPL_15, V.Undef, ((V)(2D))))), "</circle></g>"));
art_1509.S(string.Concat("<ellipse rx=\"", NumStr((A_1487 - 2.4)), "\" ry=\"", NumStr((B_1488 - 2.4)), "\" fill=\"none\" stroke=\"#ff4fa0\" stroke-width=\"1.6\">", ToStr(Call(fa_1508, V.Undef, ((V)(0D)), ((V)("stroke")))), "</ellipse><ellipse rx=\"", NumStr((A_1487 - 2.4)), "\" ry=\"", NumStr((B_1488 - 2.4)), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1.1\" stroke-dasharray=\"2.5 9.5\" stroke-linecap=\"round\"><animate attributeName=\"stroke-dashoffset\" values=\"0;-48\" dur=\"1.4s\" repeatCount=\"indefinite\"/></ellipse>"));
glow_1512 = ((V)(string.Concat("<g transform=\"", ToStr(Invoke(H_12, "FR", C_1500, Arr(((V)(0D)), ((V)(0.05)), ((V)(0D))), Arr(((V)(1D)), ((V)(0D)), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D))))), "\"><ellipse rx=\"", NumStr((A_1487 * 1.05)), "\" ry=\"", NumStr((B_1488 * 1.07)), "\" fill=\"none\" stroke=\"#ff4fa0\" stroke-width=\"8\" opacity=\"0.35\" filter=\"url(#r13b)\">", ToStr(Call(fa_1508, V.Undef, ((V)(0D)), ((V)("stroke")))), "</ellipse></g>")));
s_1513 = Add(Add(glow_1512, Call(slab_44, V.Undef, C_1500, P_1490, ((V)(T_1489)), ((V)("#141220")))), Call(top_45, V.Undef, C_1500, ((V)(T_1489)), Call(face_46, V.Undef, id_1502, P_1490, ((V)(art_1509.Str)), ((V)(0.3)))));
return NewObj(3).Put("defs", DEF20_50).Put("front", s_1513).Put("bb", Invoke(C_1500, "bb", ((V)(8D)))).V;
return default;
}, 1, "", true));
return D_1491;
return default;
}, 1, "", true));
Set(RD_8, "SET20", NewObj(9).Put("LIV-005", NewObj(2).Put("f20", ((V)("lino"))).Put("note", ((V)("Old beige sheet linoleum printed to look like stone squares with little brown diamonds. A worn path runs across it, with black heel scuffs, a seam that curls up at the edge, an iron burn and a torn spot showing the plywood underneath."))).V).Put("LIV-025", NewObj(2).Put("f20", ((V)("lam"))).Put("note", ((V)("Honey oak laminate planks with bevelled edges and staggered joints. The wood print repeats every few planks like real laminate, with a soft satin sheen and a few light scratches."))).V).Put("LIV-045", NewObj(2).Put("f20", ((V)("chev"))).Put("note", ((V)("Pale white oak boards laid in a chevron zigzag, with straight oak border boards and a thin walnut inlay line round the edge. Oiled to a soft matte sheen."))).V).Put("LIV-065", NewObj(3).Put("f20", ((V)("terr"))).Put("live", ((V)("Warm glow"))).Put("note", ((V)("Polished cream terrazzo full of marble chips in grey, terracotta, sage, blush and black, split into big panels by brass strips. Heating pipes under the floor make it glow softly warm."))).V).Put("LIV-037", NewObj(3).Put("spec", ((V)("jute20"))).Put("live", ((V)("Bobbing pompoms"))).Put("note", ((V)("An oval rug braided from chunky jute rope, with a wide black band and a cream zigzag, cream and black rings, a woven star in the middle and a trim of cream and black pompoms that bob."))).V).Put("LIV-057", NewObj(3).Put("spec", ((V)("pers20"))).Put("live", ((V)("Gold threads shimmer"))).Put("note", ((V)("A vintage Persian wool carpet overdyed deep crimson: a big lobed navy and ivory medallion with a gold star, a gold-thread lattice full of little flowers, teal corner pieces and a rosette border. The gold threads shimmer and the velvet pile catches the light."))).V).Put("LIV-077", NewObj(3).Put("spec", ((V)("silk20"))).Put("live", ((V)("Flowing silk"))).Put("note", ((V)("A free-form pebble-shaped designer rug: deep teal, rust, mustard, blush and charcoal islands in raised wool with carved grooves and contour lines, crossed by iridescent silk rivers whose colours flow and glint."))).V).Put("LIV-097", NewObj(3).Put("spec", ((V)("fiber20"))).Put("live", ((V)("Turning galaxy"))).Put("note", ((V)("An oval fibre-optic rug with a spiral galaxy of light points that slowly turns. Its colours drift through moods, rings of colour pulse out from the glowing core and a chasing light runs round the rim."))).V).Put("LIV-085", NewObj(3).Put("f20", ((V)("onyx"))).Put("live", ((V)("Glowing gold veins"))).Put("note", ((V)("One seamless slab of honey onyx with soft cloudy bands, lit from below. Thin gold veins glow and little pulses of light run along them."))).V).V);
edit19_55 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis1603, int _argc1596, V rows_1602, V _a1599, V _a1600, V _a1601, V[] _rest1597) => {
return Invoke(Call(edit19_55, V.Undef, rows_1602), "map", Fn((V _arrowThis1611, int _argc1604, V r_1610, V _a1607, V _a1608, V _a1609, V[] _rest1605) => {
return (Truthy(GetK(Get(RD_8, "SET20"), Get(r_1610, "id"))) ? Object_assign(NewObj(0).V, r_1610, GetK(Get(RD_8, "SET20"), Get(r_1610, "id"))) : r_1610);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H20", NewObj(6).Put("FLOOR20", FLOOR20_39).Put("W", W_26).Put("polyW", polyW_28).Put("lineW", lineW_29).Put("crvW", crvW_30).Put("chip", chip_31).V);
Set(RD_8, "PLUS20", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
