// reno-plus3.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus3_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("<path d=\"([^\"]+)\" fill=\"url\\(#h[SR][^\"]*\\)\"[^>]*\\/>", "g");
        public static void Run()
        {
Call(Named(boot_518 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
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
V N_24 = default;
V em_25 = default;
V GOLD_26 = default;
V CH_27 = default;
V WH_28 = default;
V GL_29 = default;
double PI_30 = 0;
V SA_31 = default;
V CA_32 = default;
V mt_33 = default;
V wd_34 = default;
V cer_35 = default;
V fb_36 = default;
V pt_37 = default;
V rep_38 = default;
V hash_39 = default;
V rng_40 = default;
V n4_41 = default;
V P2_42 = default;
V mtx_43 = default;
V plane_44 = default;
V planeX_45 = default;
V planeH_46 = default;
V kOf_47 = default;
V kt_48 = default;
V SPL_49 = default;
V B_50 = default;
V an_51 = default;
V anS_52 = default;
V anD_53 = default;
V at_54 = default;
V atS_55 = default;
V BLUR_56 = default;
V bbOf_57 = default;
V HULL_58 = default;
V tex_59 = default;
V PATS_60 = default;
double CID_61 = 0;
V clipR_62 = default;
V tuft_63 = default;
V chan_64 = default;
V pleats_65 = default;
V nailRow_66 = default;
V seatC_67 = default;
V throwP_68 = default;
V veinsSVG_69 = default;
V NF_70 = default;
V word_71 = default;
V tube_72 = default;
V BOOKC_73 = default;
V shelfBooks_74 = default;
V apple_75 = default;
V orange_76 = default;
V straw_77 = default;
V grapes_78 = default;
V kiwi_79 = default;
V can_80 = default;
V cakeSlice_81 = default;
V px_82 = default;
V PU_83 = default;
V concreteFloor_84 = default;
V obsidianWall_85 = default;
V trackLight_86 = default;
V auroraHalo_87 = default;
V NEO_88 = default;
V blackWall_89 = default;
V blackLedFloor_90 = default;
V SURF3_91 = default;
V draw2_92 = default;
V LEATHER_93 = default;
V BOUC_94 = default;
V edit2_95 = default;
V ADD3_96 = default;
if (_self1.IsNullish) _self1 = GlobalV;
tuft_63 = Fn((V _self97, int _argc98, V w_104, V h_105, V col_106, V btn_107, V[] _rest99) => {
V cell_109 = default;
double C_110 = 0;
double R_111 = 0;
double du_112 = 0;
double dv_113 = 0;
double v0_114 = 0;
V cl_115 = default;
V cr_116 = default;
JsStrBuf puff_117 = null;
JsStrBuf crs_118 = null;
JsStrBuf bt_119 = null;
JsStrBuf pl_120 = null;
V odd_121 = default;
V o_108 = default;
if (_self97.IsNullish) _self97 = GlobalV;
o_108 = (_argc98 > 4 ? _rest99[0] : V.Undef);
o_108 = (o_108 is var _t122 && Truthy(_t122) ? _t122 : NewObj(0).V);
cell_109 = (Get(o_108, "cell") is var _t123 && Truthy(_t123) ? _t123 : ((V)(15D)));
C_110 = Max(2D, Round((ToNum(w_104) / ToNum(cell_109))));
R_111 = Max(1D, Round((ToNum(h_105) / (ToNum(cell_109) * 0.8))));
du_112 = (ToNum(w_104) / (2D * C_110));
dv_113 = (ToNum(h_105) / ((2D * R_111) + 1D));
v0_114 = (dv_113 * 0.95);
cl_115 = Call(clipR_62, V.Undef, w_104, h_105);
cr_116 = Call(shade_21, V.Undef, col_106, ((V)(0.45)));
puff_117 = new JsStrBuf("");
crs_118 = new JsStrBuf("");
bt_119 = new JsStrBuf("");
pl_120 = new JsStrBuf("");
odd_121 = Fn((V _arrowThis132, int _argc124, V i_130, V j_131, V _a128, V _a129, V[] _rest125) => {
return (((((ToNum(Add(i_130, j_131)) % 2D) + 2D) % 2D) == 1D) ? V.True : V.False);
}, 2, "", true);
{
double j_133 = 0;
j_133 = (-1D);
while (true) {
if (!((j_133 <= ((2D * R_111) + 1D)))) break;
{
double i_135 = 0;
i_135 = (-1D);
while (true) {
if (!((i_135 <= ((2D * C_110) + 1D)))) break;
double x_137 = 0;
double y_138 = 0;
x_137 = (i_135 * du_112);
y_138 = (v0_114 + (j_133 * dv_113));
if (Truthy(Call(odd_121, V.Undef, ((V)(i_135)), ((V)(j_133))))) {
puff_117.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((x_137 - du_112))))).S(" ").V(Call(f1_23, V.Undef, ((V)(y_138)))).S("L").V(Call(f1_23, V.Undef, ((V)(x_137)))).S(" ").V(Call(f1_23, V.Undef, ((V)((y_138 - dv_113))))).S("L").V(Call(f1_23, V.Undef, ((V)((x_137 + du_112))))).S(" ").V(Call(f1_23, V.Undef, ((V)(y_138)))).S("L").V(Call(f1_23, V.Undef, ((V)(x_137)))).S(" ").V(Call(f1_23, V.Undef, ((V)((y_138 + dv_113))))).S("Z\" fill=\"url(#p3puff)\"/>");
} else {
crs_118.S("M").V(Call(f1_23, V.Undef, ((V)(x_137)))).S(" ").V(Call(f1_23, V.Undef, ((V)(y_138)))).S("L").V(Call(f1_23, V.Undef, ((V)((x_137 + du_112))))).S(" ").V(Call(f1_23, V.Undef, ((V)((y_138 + dv_113))))).S("M").V(Call(f1_23, V.Undef, ((V)(x_137)))).S(" ").V(Call(f1_23, V.Undef, ((V)(y_138)))).S("L").V(Call(f1_23, V.Undef, ((V)((x_137 + du_112))))).S(" ").V(Call(f1_23, V.Undef, ((V)((y_138 - dv_113)))));
if (((((x_137 > 0.5) && (x_137 < (ToNum(w_104) - 0.5))) && (y_138 > 0.5)) && (y_138 < (ToNum(h_105) - 0.5)))) {
bt_119.S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)(x_137)))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((y_138 + 0.25))))).S("\" r=\"2.2\" fill=\"#000000\" opacity=\"0.32\"/><circle cx=\"").V(Call(f1_23, V.Undef, ((V)(x_137)))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(y_138)))).S("\" r=\"1.35\" fill=\"").V(btn_107).S("\" stroke=\"").V(Call(shade_21, V.Undef, btn_107, ((V)(0.55)))).S("\" stroke-width=\"0.3\"/><circle cx=\"").V(Call(f1_23, V.Undef, ((V)((x_137 - 0.4))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((y_138 - 0.45))))).S("\" r=\"0.45\" fill=\"#ffffff\" opacity=\"0.7\"/>");
if (Truthy((Get(o_108, "pleat") is var _t139 && !Truthy(_t139) ? _t139 : (((y_138 + dv_113) > (ToNum(h_105) - 0.5)) ? V.True : V.False)))) {
pl_120.S("M").V(Call(f1_23, V.Undef, ((V)(x_137)))).S(" ").V(Call(f1_23, V.Undef, ((V)(y_138)))).S("L").V(Call(f1_23, V.Undef, ((V)((x_137 - (du_112 * 0.35)))))).S(" ").V(Call(f1_23, V.Undef, h_105)).S("M").V(Call(f1_23, V.Undef, ((V)(x_137)))).S(" ").V(Call(f1_23, V.Undef, ((V)(y_138)))).S("L").V(Call(f1_23, V.Undef, ((V)((x_137 + (du_112 * 0.35)))))).S(" ").V(Call(f1_23, V.Undef, h_105));
}
}
}
i_135++;
}
}
j_133++;
}
}
return ((V)(JsStrBuf.Begin().S("<defs>").V(Get(cl_115, "d")).S("</defs><g clip-path=\"url(#").V(Get(cl_115, "id")).S(")\">").S(puff_117.Str).S("<path d=\"").S(crs_118.Str).S("\" transform=\"translate(0 0.6)\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.14\" stroke-width=\"0.5\"/><path d=\"").S(crs_118.Str).S(pl_120.Str).S("\" fill=\"none\" stroke=\"").V(cr_116).S("\" stroke-opacity=\"0.9\" stroke-width=\"0.65\" stroke-linecap=\"round\"/>").S(bt_119.Str).S("</g>").End()));
return default;
}, 5, "tuft", false);
chan_64 = Fn((V _self140, int _argc141, V w_147, V h_148, V col_149, V cw_150, V[] _rest142) => {
double n_151 = 0;
double c_152 = 0;
V cl_153 = default;
JsStrBuf s_154 = null;
JsStrBuf sm_155 = null;
if (_self140.IsNullish) _self140 = GlobalV;
n_151 = Max(3D, Round((ToNum(w_147) / ToNum((cw_150 is var _t156 && Truthy(_t156) ? _t156 : ((V)(9D)))))));
c_152 = (ToNum(w_147) / n_151);
cl_153 = Call(clipR_62, V.Undef, w_147, h_148);
s_154 = new JsStrBuf("");
sm_155 = new JsStrBuf("");
Call(rep_38, V.Undef, ((V)(n_151)), Fn((V _arrowThis164, int _argc157, V i_163, V _a160, V _a161, V _a162, V[] _rest158) => {
s_154.S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(i_163) * c_152))))).S("\" y=\"0\" width=\"").V(Call(f1_23, V.Undef, ((V)(c_152)))).S("\" height=\"").V(Call(f1_23, V.Undef, h_148)).S("\" fill=\"url(#p3chan)\"/><ellipse cx=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(Add(i_163, ((V)(0.5)))) * c_152))))).S("\" cy=\"2.6\" rx=\"").V(Call(f1_23, V.Undef, ((V)((c_152 * 0.36))))).S("\" ry=\"1.6\" fill=\"#ffffff\" opacity=\"0.2\"/>");
if (Truthy(i_163)) {
sm_155.S("M").V(Call(f1_23, V.Undef, ((V)((ToNum(i_163) * c_152))))).S(" 0V").V(Call(f1_23, V.Undef, h_148));
}
return default;
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S("<defs>").V(Get(cl_153, "d")).S("</defs><g clip-path=\"url(#").V(Get(cl_153, "id")).S(")\">").S(s_154.Str).S("<path d=\"").S(sm_155.Str).S("\" fill=\"none\" stroke=\"").V(Call(shade_21, V.Undef, col_149, ((V)(0.5)))).S("\" stroke-width=\"0.75\"/><path d=\"").S(sm_155.Str).S("\" transform=\"translate(0.7 0)\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.16\" stroke-width=\"0.4\"/></g>").End()));
return default;
}, 4, "chan", false);
concreteFloor_84 = Fn((V _self165, int _argc166, V _a168, V _a169, V _a170, V _a171, V[] _rest167) => {
V R_172 = default;
V T_173 = default;
JsStrBuf s_174 = null;
V J_175 = default;
JsStrBuf cr_176 = null;
double u_177 = 0;
double v_178 = 0;
V cable_179 = default;
V tape_180 = default;
V c1_181 = default;
V c2_182 = default;
if (_self165.IsNullish) _self165 = GlobalV;
R_172 = Call(rng_40, V.Undef, ((V)("concrete5")));
T_173 = ((V)("M14 0H66L80 56H0Z"));
s_174 = new JsStrBuf(JsStrBuf.Begin().S("<defs><linearGradient id=\"cf0\" x1=\"0\" y1=\"0\" x2=\"0.3\" y2=\"1\"><stop offset=\"0\" stop-color=\"#aba79f\"/><stop offset=\"1\" stop-color=\"#8f8b84\"/></linearGradient><clipPath id=\"cfc\"><path d=\"").V(T_173).S("\"/></clipPath>").V(Call(BLUR_56, V.Undef, ((V)("cfb")), ((V)(2D)))).S("</defs><g clip-path=\"url(#cfc)\"><path d=\"").V(T_173).S("\" fill=\"url(#cf0)\"/>").End());
s_174.S("<g filter=\"url(#cfb)\">");
Call(rep_38, V.Undef, ((V)(18D)), Fn((V _arrowThis190, int _argc183, V i_189, V _a186, V _a187, V _a188, V[] _rest184) => {
V q_191 = default;
q_191 = Call(px_82, V.Undef, Call(R_172, V.Undef), Call(R_172, V.Undef));
s_174.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_191, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_191, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((4D + (ToNum(Call(R_172, V.Undef)) * 9D)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((2D + (ToNum(Call(R_172, V.Undef)) * 4D)))))).S("\" fill=\"").S((NumTruthy((ToNum(i_189) % 2D)) ? "#bdb9b0" : "#7f7b74")).S("\" opacity=\"0.35\"/>");
return default;
}, 1, "", true));
s_174.S("</g>");
Call(rep_38, V.Undef, ((V)(90D)), Fn((V _arrowThis199, int _argc192, V i_198, V _a195, V _a196, V _a197, V[] _rest193) => {
V q_200 = default;
q_200 = Call(px_82, V.Undef, Call(R_172, V.Undef), Call(R_172, V.Undef));
s_174.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_200, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_200, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.12 + (ToNum(Call(R_172, V.Undef)) * 0.25)))))).S("\" fill=\"").S((NumTruthy((ToNum(i_198) % 3D)) ? "#6f6b65" : "#d4d0c8")).S("\" opacity=\"0.5\"/>");
return default;
}, 1, "", true));
J_175 = Fn((V _arrowThis209, int _argc201, V a_207, V b_208, V _a205, V _a206, V[] _rest202) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(a_207).S("L").V(b_208).S("\" stroke=\"#6b675f\" stroke-width=\"0.5\"/><path d=\"M").V(a_207).S("L").V(b_208).S("\" stroke=\"#cfcbc2\" stroke-width=\"0.3\" transform=\"translate(0.45 0.35)\"/>").End()));
}, 2, "", true);
s_174.V(Add(Add(Call(J_175, V.Undef, Call(PU_83, V.Undef, ((V)((1D / 3D))), ((V)(0D))), Call(PU_83, V.Undef, ((V)((1D / 3D))), ((V)(1D)))), Call(J_175, V.Undef, Call(PU_83, V.Undef, ((V)((2D / 3D))), ((V)(0D))), Call(PU_83, V.Undef, ((V)((2D / 3D))), ((V)(1D))))), Call(J_175, V.Undef, Call(PU_83, V.Undef, ((V)(0D)), ((V)(0.45))), Call(PU_83, V.Undef, ((V)(1D)), ((V)(0.45))))));
cr_176 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(PU_83, V.Undef, ((V)(0.55)), ((V)(0.12)))).End());
u_177 = 0.55;
v_178 = 0.12;
Call(rep_38, V.Undef, ((V)(6D)), Fn((V _arrowThis216, int _argc210, V _a212, V _a213, V _a214, V _a215, V[] _rest211) => {
u_177 = (u_177 + ((ToNum(Call(R_172, V.Undef)) - 0.45) * 0.05));
v_178 = (v_178 + (0.035 + (ToNum(Call(R_172, V.Undef)) * 0.02)));
cr_176.S("L").V(Call(PU_83, V.Undef, ((V)(u_177)), ((V)(v_178))));
return default;
}, 0, "", true));
s_174.S("<path d=\"").S(cr_176.Str).S("\" fill=\"none\" stroke=\"#5f5b55\" stroke-width=\"0.32\" opacity=\"0.8\"/><path d=\"").S(cr_176.Str).S("\" fill=\"none\" stroke=\"#d8d4cc\" stroke-width=\"0.2\" transform=\"translate(0.3 0.25)\" opacity=\"0.6\"/>");
cable_179 = Fn((V _arrowThis226, int _argc217, V pts_223, V col_224, V w_225, V _a222, V[] _rest218) => {
JsStrBuf d_227 = null;
d_227 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(PU_83, V.Undef, GetIdx(GetIdx(pts_223, 0D), 0D), GetIdx(GetIdx(pts_223, 0D), 1D))).End());
{
double i_228 = 0;
i_228 = 1D;
while (true) {
if (!((i_228 < (ToNum(Get(pts_223, "length")) - 1D)))) break;
V m_230 = default;
m_230 = Arr(((V)((ToNum(Add(GetIdx(GetIdx(pts_223, i_228), 0D), GetIdx(GetIdx(pts_223, (i_228 + 1D)), 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(GetIdx(pts_223, i_228), 1D), GetIdx(GetIdx(pts_223, (i_228 + 1D)), 1D))) / 2D))));
d_227.S("Q").V(Call(PU_83, V.Undef, GetIdx(GetIdx(pts_223, i_228), 0D), GetIdx(GetIdx(pts_223, i_228), 1D))).S(" ").V(Call(PU_83, V.Undef, GetIdx(m_230, 0D), GetIdx(m_230, 1D)));
i_228++;
}
}
d_227.S("L").V(Call(PU_83, V.Undef, GetIdx(GetIdx(pts_223, (ToNum(Get(pts_223, "length")) - 1D)), 0D), GetIdx(GetIdx(pts_223, (ToNum(Get(pts_223, "length")) - 1D)), 1D)));
return ((V)(JsStrBuf.Begin().S("<path d=\"").S(d_227.Str).S("\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.28\" stroke-width=\"").V(Add(w_225, ((V)(0.6)))).S("\" transform=\"translate(0.4 0.5)\" stroke-linecap=\"round\"/><path d=\"").S(d_227.Str).S("\" fill=\"none\" stroke=\"").V(col_224).S("\" stroke-width=\"").V(w_225).S("\" stroke-linecap=\"round\"/><path d=\"").S(d_227.Str).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.3\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(w_225) * 0.3))))).S("\" transform=\"translate(-0.2 -0.25)\" stroke-linecap=\"round\"/>").End()));
return default;
}, 3, "", true);
tape_180 = Fn((V _arrowThis241, int _argc231, V u_237, V v_238, V du_239, V dv_240, V[] _rest232) => {
V L_242 = default;
double tu_243 = 0;
double tv_244 = 0;
double nu_245 = 0;
double nv_246 = 0;
double a_247 = 0;
double b_248 = 0;
V C_249 = default;
L_242 = (((V)(Hypot(ToNum(du_239), ToNum(dv_240)))) is var _t250 && Truthy(_t250) ? _t250 : ((V)(1D)));
tu_243 = (ToNum(du_239) / ToNum(L_242));
tv_244 = (ToNum(dv_240) / ToNum(L_242));
nu_245 = (-tv_244);
nv_246 = tu_243;
a_247 = 0.05;
b_248 = 0.022;
C_249 = Arr(Arr(((V)((ToNum(Add(u_237, ((V)((nu_245 * a_247))))) - (tu_243 * b_248)))), ((V)((ToNum(Add(v_238, ((V)(((nv_246 * a_247) * 1.4))))) - (tv_244 * b_248))))), Arr(Add(Add(u_237, ((V)((nu_245 * a_247)))), ((V)((tu_243 * b_248)))), Add(Add(v_238, ((V)(((nv_246 * a_247) * 1.4)))), ((V)((tv_244 * b_248))))), Arr(((V)(((ToNum(u_237) - (nu_245 * a_247)) + (tu_243 * b_248)))), ((V)(((ToNum(v_238) - ((nv_246 * a_247) * 1.4)) + (tv_244 * b_248))))), Arr(((V)(((ToNum(u_237) - (nu_245 * a_247)) - (tu_243 * b_248)))), ((V)(((ToNum(v_238) - ((nv_246 * a_247) * 1.4)) - (tv_244 * b_248))))));
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Invoke(Invoke(C_249, "map", Fn((V _arrowThis258, int _argc251, V q_257, V _a254, V _a255, V _a256, V[] _rest252) => {
return Call(PU_83, V.Undef, GetIdx(q_257, 0D), GetIdx(q_257, 1D));
}, 1, "", true)), "join", ((V)("L")))).S("Z\" fill=\"#c3c6c9\" stroke=\"#8f9297\" stroke-width=\"0.25\" opacity=\"0.95\"/><path d=\"M").V(Call(PU_83, V.Undef, ((V)((ToNum(Add(GetIdx(GetIdx(C_249, 0D), 0D), GetIdx(GetIdx(C_249, 1D), 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(GetIdx(C_249, 0D), 1D), GetIdx(GetIdx(C_249, 1D), 1D))) / 2D))))).S("L").V(Call(PU_83, V.Undef, ((V)((ToNum(Add(GetIdx(GetIdx(C_249, 2D), 0D), GetIdx(GetIdx(C_249, 3D), 0D))) / 2D))), ((V)((ToNum(Add(GetIdx(GetIdx(C_249, 2D), 1D), GetIdx(GetIdx(C_249, 3D), 1D))) / 2D))))).S("\" stroke=\"#e4e6e8\" stroke-width=\"0.3\" opacity=\"0.8\"/>").End()));
return default;
}, 4, "", true);
c1_181 = Arr(Arr(((V)(0.08)), ((V)((-0.05)))), Arr(((V)(0.1)), ((V)(0.35))), Arr(((V)(0.12)), ((V)(0.62))), Arr(((V)(0.22)), ((V)(0.78))), Arr(((V)(0.5)), ((V)(0.82))), Arr(((V)(1.05)), ((V)(0.84))));
c2_182 = Arr(Arr(((V)(0.7)), ((V)((-0.05)))), Arr(((V)(0.74)), ((V)(0.3))), Arr(((V)(0.78)), ((V)(0.55))), Arr(((V)(0.9)), ((V)(0.62))), Arr(((V)(1.05)), ((V)(0.64))));
s_174.V(Add(Call(cable_179, V.Undef, c1_181, ((V)("#1e1f22")), ((V)(1.15))), Call(cable_179, V.Undef, c2_182, ((V)("#e8742a")), ((V)(0.95)))));
Invoke(Arr(Arr(((V)(0.1)), ((V)(0.18)), ((V)(0.02)), ((V)(1D))), Arr(((V)(0.12)), ((V)(0.52)), ((V)(0.02)), ((V)(1D))), Arr(((V)(0.36)), ((V)(0.81)), ((V)(1D)), ((V)(0.05))), Arr(((V)(0.74)), ((V)(0.83)), ((V)(1D)), ((V)(0.02))), Arr(((V)(0.745)), ((V)(0.15)), ((V)(0.04)), ((V)(1D))), Arr(((V)(0.86)), ((V)(0.61)), ((V)(1D)), ((V)(0.2)))), "forEach", Fn((V _arrowThis274, int _argc259, V _a261, V _a262, V _a263, V _a264, V[] _rest260) => {
V u_267 = default;
V v_269 = default;
V du_271 = default;
V dv_273 = default;
{ V _t265 = ListOf(_a261);
{ V _t266 = GetIdx(_t265, 0D);
u_267 = _t266; }
{ V _t268 = GetIdx(_t265, 1D);
v_269 = _t268; }
{ V _t270 = GetIdx(_t265, 2D);
du_271 = _t270; }
{ V _t272 = GetIdx(_t265, 3D);
dv_273 = _t272; }
}
return ((V)(s_174.V(Call(tape_180, V.Undef, u_267, v_269, du_271, dv_273)).Str));
}, 1, "", true));
return ((V)(string.Concat(s_174.Str, "</g>")));
return default;
}, 0, "concreteFloor", false);
obsidianWall_85 = Fn((V _self275, int _argc276, V _a278, V _a279, V _a280, V _a281, V[] _rest277) => {
V R_282 = default;
JsStrBuf s_283 = null;
if (_self275.IsNullish) _self275 = GlobalV;
R_282 = Call(rng_40, V.Undef, ((V)("obsidian")));
s_283 = new JsStrBuf("<defs><linearGradient id=\"og0\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#1d1b24\"/><stop offset=\"1\" stop-color=\"#0c0b10\"/></linearGradient><pattern id=\"ofab\" width=\"1.6\" height=\"1.6\" patternUnits=\"userSpaceOnUse\"><circle cx=\"0.4\" cy=\"0.4\" r=\"0.22\" fill=\"#ffffff\" fill-opacity=\"0.035\"/><circle cx=\"1.2\" cy=\"1.2\" r=\"0.22\" fill=\"#000000\" fill-opacity=\"0.3\"/></pattern><linearGradient id=\"osh\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"1\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient></defs>");
s_283.S("<rect width=\"80\" height=\"56\" fill=\"#08070b\"/>");
{
double j_284 = 0;
j_284 = 0D;
while (true) {
if (!((j_284 < 4D))) break;
{
double i_286 = 0;
i_286 = 0D;
while (true) {
if (!((i_286 < 5D))) break;
double x_288 = 0;
double y_289 = 0;
double w_290 = 0;
double h_291 = 0;
double a_292 = 0;
double gx_293 = 0;
x_288 = ((i_286 * 16D) + 0.5);
y_289 = ((j_284 * 14D) + 0.5);
w_290 = 15D;
h_291 = 13D;
s_283.S("<rect x=\"").N(x_288).S("\" y=\"").N(y_289).S("\" width=\"").N(w_290).S("\" height=\"").N(h_291).S("\" rx=\"0.9\" fill=\"url(#og0)\"/><path d=\"M").N((x_288 + 0.5)).S(" ").N(((y_289 + h_291) - 0.6)).S("V").N((y_289 + 0.5)).S("H").N(((x_288 + w_290) - 0.6)).S("\" fill=\"none\" stroke=\"#3a3842\" stroke-width=\"0.45\"/><path d=\"M").N((x_288 + 0.6)).S(" ").N(((y_289 + h_291) - 0.4)).S("H").N(((x_288 + w_290) - 0.4)).S("V").N((y_289 + 0.6)).S("\" fill=\"none\" stroke=\"#020203\" stroke-width=\"0.55\"/>");
a_292 = ((ToNum(Call(R_282, V.Undef)) * 0.8) - 0.4);
gx_293 = ((x_288 + 2D) + (ToNum(Call(R_282, V.Undef)) * 9D));
s_283.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)(gx_293)))).S(" ").N((y_289 + 1D)).S("L").V(Call(f1_23, V.Undef, ((V)((gx_293 + 3D))))).S(" ").N((y_289 + 1D)).S("L").V(Call(f1_23, V.Undef, ((V)(((gx_293 + 3D) + (h_291 * a_292)))))).S(" ").N(((y_289 + h_291) - 1D)).S("L").V(Call(f1_23, V.Undef, ((V)((gx_293 + (h_291 * a_292)))))).S(" ").N(((y_289 + h_291) - 1D)).S("Z\" fill=\"#ffffff\" opacity=\"").V(Call(f1_23, V.Undef, ((V)((0.012 + (ToNum(Call(R_282, V.Undef)) * 0.022)))))).S("\"/>");
i_286++;
}
}
j_284++;
}
}
s_283.S("<rect width=\"80\" height=\"56\" fill=\"url(#ofab)\"/>");
Call(rep_38, V.Undef, ((V)(78D)), Fn((V _arrowThis301, int _argc294, V i_300, V _a297, V _a298, V _a299, V[] _rest295) => {
double x_302 = 0;
double y_303 = 0;
double r_304 = 0;
V col_305 = default;
V d_306 = default;
double b_307 = 0;
x_302 = (ToNum(Call(R_282, V.Undef)) * 80D);
y_303 = (ToNum(Call(R_282, V.Undef)) * 56D);
r_304 = (0.16 + (ToNum(Call(R_282, V.Undef)) * 0.3));
col_305 = GetIdx(Arr(((V)("#ffffff")), ((V)("#d6e8ff")), ((V)("#fff2d6")), ((V)("#cfe0ff"))), (ToNum(i_300) % 4D));
d_306 = Invoke(((V)((1.6 + (ToNum(Call(R_282, V.Undef)) * 2.8)))), "toFixed", ((V)(2D)));
b_307 = (-(ToNum(Call(R_282, V.Undef)) * 4D));
if ((r_304 > 0.38)) {
s_283.S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)(x_302)))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(y_303)))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((r_304 * 3D))))).S("\" fill=\"").V(col_305).S("\" opacity=\"0.15\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.04;0.22;0.04")), d_306, ((V)(b_307)))).S("</circle>");
}
s_283.S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)(x_302)))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(y_303)))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)(r_304)))).S("\" fill=\"").V(col_305).S("\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.25;1;0.25")), d_306, ((V)(b_307)))).S("</circle>");
return default;
}, 1, "", true));
s_283.S("<g opacity=\"0\"><rect x=\"-6\" y=\"-0.3\" width=\"12\" height=\"0.6\" rx=\"0.3\" fill=\"url(#osh)\" transform=\"translate(14 8) rotate(24)\"/>").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0;0;1;0;0")), ((V)(9D)), ((V)(0D)), ((V)("0;0.78;0.82;0.88;1")))).V(Call(at_54, V.Undef, ((V)("translate")), ((V)("0 0;0 0;14 7;24 12;24 12")), ((V)(9D)))).S("</g>");
return ((V)(s_283.Str));
return default;
}, 0, "obsidianWall", false);
trackLight_86 = Fn((V _self308, int _argc309, V _a311, V _a312, V _a313, V _a314, V[] _rest310) => {
JsStrBuf s_315 = null;
if (_self308.IsNullish) _self308 = GlobalV;
s_315 = new JsStrBuf("<defs><linearGradient id=\"tcone\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#fff3cf\" stop-opacity=\"0.75\"/><stop offset=\"1\" stop-color=\"#fff3cf\" stop-opacity=\"0\"/></linearGradient><linearGradient id=\"tcan\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#4a4d55\"/><stop offset=\"0.35\" stop-color=\"#2a2c32\"/><stop offset=\"1\" stop-color=\"#121316\"/></linearGradient><radialGradient id=\"tlens\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"1\" stop-color=\"#ffd98a\"/></radialGradient></defs>");
Invoke(Arr(((V)(14D)), ((V)(66D))), "forEach", Fn((V _arrowThis323, int _argc316, V x_322, V _a319, V _a320, V _a321, V[] _rest317) => {
return ((V)(s_315.S("<path d=\"M").V(x_322).S(" 0V8\" stroke=\"#6a6d75\" stroke-width=\"0.6\"/><rect x=\"").N((ToNum(x_322) - 2D)).S("\" y=\"-0.2\" width=\"4\" height=\"1.4\" rx=\"0.4\" fill=\"#2a2c32\"/>").Str));
}, 1, "", true));
s_315.S("<path d=\"M8 9L11 7.3H75L72 9Z\" fill=\"#3a3c42\" stroke=\"#121316\" stroke-width=\"0.3\"/><rect x=\"8\" y=\"9\" width=\"64\" height=\"3.6\" fill=\"#1d1e22\" stroke=\"#0a0a0c\" stroke-width=\"0.3\"/><path d=\"M8.4 9.3H71.6\" stroke=\"#6a6d75\" stroke-width=\"0.35\"/><path d=\"M72 9L75 7.3V10.9L72 12.6Z\" fill=\"#141518\"/>");
Invoke(Arr(Arr(((V)(18D)), ((V)((-16D)))), Arr(((V)(33D)), ((V)(8D))), Arr(((V)(48D)), ((V)((-8D)))), Arr(((V)(63D)), ((V)(15D)))), "forEach", Fn((V _arrowThis336, int _argc324, V _a326, V i_330, V _a328, V _a329, V[] _rest325) => {
double b_337 = 0;
V x_333 = default;
V a_335 = default;
{ V _t331 = ListOf(_a326);
{ V _t332 = GetIdx(_t331, 0D);
x_333 = _t332; }
{ V _t334 = GetIdx(_t331, 1D);
a_335 = _t334; }
}
b_337 = (-(ToNum(i_330) * 1.4));
s_315.S("<rect x=\"").N((ToNum(x_333) - 1.6)).S("\" y=\"12.6\" width=\"3.2\" height=\"2\" fill=\"#2a2b30\"/><g transform=\"rotate(").V(a_335).S(" ").V(x_333).S(" 19)\"><path d=\"M").N((ToNum(x_333) - 2.4)).S(" 26.4L").N((ToNum(x_333) - 12D)).S(" 60H").V(Add(x_333, ((V)(12D)))).S("L").V(Add(x_333, ((V)(2.4)))).S(" 26.4Z\" fill=\"url(#tcone)\">").V(Call(anS_52, V.Undef, ((V)("opacity")), ((V)("0.15;0.7;0.15")), ((V)(6.4)), ((V)(b_337)))).S("</path>").S("<path d=\"M").N((ToNum(x_333) - 4.4)).S(" 14.6V20M").V(Add(x_333, ((V)(4.4)))).S(" 14.6V20M").N((ToNum(x_333) - 4.4)).S(" 14.6H").V(Add(x_333, ((V)(4.4)))).S("\" fill=\"none\" stroke=\"#2a2b30\" stroke-width=\"1.1\" stroke-linecap=\"round\"/><rect x=\"").N((ToNum(x_333) - 3.6)).S("\" y=\"15.6\" width=\"7.2\" height=\"10.5\" rx=\"1.6\" fill=\"url(#tcan)\" stroke=\"#0a0a0c\" stroke-width=\"0.3\"/>").V(Invoke(Invoke(Arr(((V)(16.8)), ((V)(17.9)), ((V)(19D)), ((V)(20.1))), "map", Fn((V _arrowThis345, int _argc338, V y_344, V _a341, V _a342, V _a343, V[] _rest339) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"M").N((ToNum(x_333) - 3.2)).S(" ").V(y_344).S("H").V(Add(x_333, ((V)(3.2)))).S("\" stroke=\"#5a5d64\" stroke-width=\"0.35\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<circle cx=\"").N((ToNum(x_333) - 4.4)).S("\" cy=\"19.6\" r=\"0.7\" fill=\"#6a6d75\"/><circle cx=\"").V(Add(x_333, ((V)(4.4)))).S("\" cy=\"19.6\" r=\"0.7\" fill=\"#6a6d75\"/>").S("<ellipse cx=\"").V(x_333).S("\" cy=\"26.1\" rx=\"3.7\" ry=\"1.25\" fill=\"#0e0f12\" stroke=\"#6a6d75\" stroke-width=\"0.35\"/><ellipse cx=\"").V(x_333).S("\" cy=\"26.1\" rx=\"2.7\" ry=\"0.9\" fill=\"url(#tlens)\">").V(Call(anS_52, V.Undef, ((V)("opacity")), ((V)("0.35;1;0.35")), ((V)(6.4)), ((V)(b_337)))).S("</ellipse></g>");
return default;
}, 2, "", true));
s_315.S("<circle cx=\"74\" cy=\"10.8\" r=\"0.5\" fill=\"#ffd66b\">").V(Call(anS_52, V.Undef, ((V)("opacity")), ((V)("0.3;1;0.3")), ((V)(6.4)))).S("</circle>");
return ((V)(s_315.Str));
return default;
}, 0, "trackLight", false);
auroraHalo_87 = Fn((V _self346, int _argc347, V _a349, V _a350, V _a351, V _a352, V[] _rest348) => {
double cx_353 = 0;
double cy_354 = 0;
double rx_355 = 0;
double ry_356 = 0;
V CS_357 = default;
V pt2_358 = default;
JsStrBuf s_359 = null;
V rib_360 = default;
if (_self346.IsNullish) _self346 = GlobalV;
cx_353 = 40D;
cy_354 = 17D;
rx_355 = 27D;
ry_356 = 7D;
CS_357 = Arr(((V)("#5effb0")), ((V)("#4fe0d0")), ((V)("#8f7bff")), ((V)("#ff6ad5")), ((V)("#6ac8ff")), ((V)("#5effb0")));
pt2_358 = Fn((V _arrowThis368, int _argc361, V a_367, V _a364, V _a365, V _a366, V[] _rest362) => {
return Arr(((V)((cx_353 + (rx_355 * FdLibm.Cos(ToNum(a_367)))))), ((V)((cy_354 + (ry_356 * FdLibm.Sin(ToNum(a_367)))))));
}, 1, "", true);
s_359 = new JsStrBuf(JsStrBuf.Begin().S("<defs>").V(Call(BLUR_56, V.Undef, ((V)("ab")), ((V)(1.2)))).V(Invoke(Call(rep_38, V.Undef, ((V)(5D)), Fn((V _arrowThis376, int _argc369, V i_375, V _a372, V _a373, V _a374, V[] _rest370) => {
return ((V)(JsStrBuf.Begin().S("<linearGradient id=\"au").V(i_375).S("\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"").V(GetK(CS_357, i_375)).S("\" stop-opacity=\"0.85\">").V(Call(an_51, V.Undef, ((V)("stop-color")), Invoke(Invoke(Invoke(CS_357, "slice", i_375), "concat", Invoke(CS_357, "slice", ((V)(0D)), Add(i_375, ((V)(1D))))), "join", ((V)(";"))), ((V)(9D)), ((V)((-ToNum(i_375)))))).S("</stop><stop offset=\"0.55\" stop-color=\"").V(GetK(CS_357, Add(i_375, ((V)(1D))))).S("\" stop-opacity=\"0.35\">").V(Call(an_51, V.Undef, ((V)("stop-color")), Invoke(Invoke(Invoke(CS_357, "slice", Add(i_375, ((V)(1D)))), "concat", Invoke(CS_357, "slice", ((V)(0D)), Add(i_375, ((V)(2D))))), "join", ((V)(";"))), ((V)(9D)), ((V)((-ToNum(i_375)))))).S("</stop><stop offset=\"1\" stop-color=\"").V(GetK(CS_357, Add(i_375, ((V)(1D))))).S("\" stop-opacity=\"0\"/></linearGradient>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<pattern id=\"aur\" width=\"1.6\" height=\"30\" patternUnits=\"userSpaceOnUse\"><rect width=\"0.5\" height=\"30\" fill=\"#ffffff\" opacity=\"0.22\"/></pattern></defs>").End());
Invoke(Arr(Arr(((V)(22D)), ((V)(0D)), ((V)(17D)), ((V)(15D))), Arr(((V)(58D)), ((V)(0D)), ((V)(63D)), ((V)(15D))), Arr(((V)(40D)), ((V)(0D)), ((V)(40D)), ((V)(10D)))), "forEach", Fn((V _arrowThis392, int _argc377, V _a379, V _a380, V _a381, V _a382, V[] _rest378) => {
V a_385 = default;
V b_387 = default;
V c_389 = default;
V d_391 = default;
{ V _t383 = ListOf(_a379);
{ V _t384 = GetIdx(_t383, 0D);
a_385 = _t384; }
{ V _t386 = GetIdx(_t383, 1D);
b_387 = _t386; }
{ V _t388 = GetIdx(_t383, 2D);
c_389 = _t388; }
{ V _t390 = GetIdx(_t383, 3D);
d_391 = _t390; }
}
return ((V)(s_359.S("<path d=\"M").V(a_385).S(" ").V(b_387).S("L").V(c_389).S(" ").V(d_391).S("\" stroke=\"#9aa3a8\" stroke-width=\"0.35\"/>").Str));
}, 1, "", true));
rib_360 = Fn((V _arrowThis404, int _argc393, V a0_399, V a1_400, V h_401, V i_402, V[] _rest394) => {
V fr_405 = default;
V v_406 = default;
V front_403 = default;
front_403 = (_argc393 > 4 ? _rest394[0] : V.Undef);
fr_405 = Fn((V _arrowThis414, int _argc407, V ph_413, V _a410, V _a411, V _a412, V[] _rest408) => {
V top_415 = default;
V bot_416 = default;
top_415 = Call(rep_38, V.Undef, ((V)(9D)), Fn((V _arrowThis424, int _argc417, V k_423, V _a420, V _a421, V _a422, V[] _rest418) => {
return Call(pt2_358, V.Undef, Add(a0_399, ((V)((((ToNum(a1_400) - ToNum(a0_399)) * ToNum(k_423)) / 8D)))));
}, 1, "", true));
bot_416 = Invoke(top_415, "map", Fn((V _arrowThis437, int _argc425, V _a427, V k_431, V _a429, V _a430, V[] _rest426) => {
V x_434 = default;
V y_436 = default;
{ V _t432 = ListOf(_a427);
{ V _t433 = GetIdx(_t432, 0D);
x_434 = _t433; }
{ V _t435 = GetIdx(_t432, 1D);
y_436 = _t435; }
}
return Arr(Add(x_434, ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(k_431) * 0.8))), ph_413))) * 2.4)))), Add(y_436, ((V)((ToNum(h_401) * (0.75 + (0.25 * FdLibm.Sin(((ToNum(k_431) * 1.1) + (ToNum(ph_413) * 1.3))))))))));
}, 2, "", true));
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(top_415, "map", P2_42), "join", ((V)("L")))).S("L").V(Invoke(Invoke(Invoke(bot_416, "reverse"), "map", P2_42), "join", ((V)("L")))).S("Z").End()));
return default;
}, 1, "", true);
v_406 = Invoke(Invoke(Arr(((V)(0D)), ((V)(1.6)), ((V)(3.2)), ((V)(0D))), "map", fr_405), "join", ((V)(";")));
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(Call(fr_405, V.Undef, ((V)(0D)))).S("\" fill=\"url(#au").V(i_402).S(")\" opacity=\"").N((Truthy(front_403) ? 0.75 : 0.55)).S("\">").V(Call(anS_52, V.Undef, ((V)("d")), v_406, ((V)((6D + (ToNum(i_402) * 0.7)))), ((V)((-ToNum(i_402)))))).S("</path><path d=\"").V(Call(fr_405, V.Undef, ((V)(0D)))).S("\" fill=\"url(#aur)\" opacity=\"0.35\">").V(Call(anS_52, V.Undef, ((V)("d")), v_406, ((V)((6D + (ToNum(i_402) * 0.7)))), ((V)((-ToNum(i_402)))))).S("</path>").End()));
return default;
}, 5, "", true);
s_359.V(Add(Call(rib_360, V.Undef, ((V)((PI_30 * 1.05))), ((V)((PI_30 * 1.6))), ((V)(20D)), ((V)(0D))), Call(rib_360, V.Undef, ((V)((PI_30 * 1.45))), ((V)((PI_30 * 1.95))), ((V)(24D)), ((V)(1D)))));
s_359.S("<path d=\"M").V(Call(P2_42, V.Undef, Call(pt2_358, V.Undef, ((V)(PI_30))))).S("A").N(rx_355).S(" ").N(ry_356).S(" 0 0 1 ").V(Call(P2_42, V.Undef, Call(pt2_358, V.Undef, ((V)(0D))))).S("\" fill=\"none\" stroke=\"#7d858e\" stroke-width=\"2\"/><path d=\"M").V(Call(P2_42, V.Undef, Call(pt2_358, V.Undef, ((V)(PI_30))))).S("A").N(rx_355).S(" ").N(ry_356).S(" 0 0 1 ").V(Call(P2_42, V.Undef, Call(pt2_358, V.Undef, ((V)(0D))))).S("\" fill=\"none\" stroke=\"#e8fdff\" stroke-width=\"0.7\" stroke-dasharray=\"3 2\" filter=\"url(#ab)\">").V(Call(an_51, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-30")), ((V)(2.4)))).V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.5;1;0.6;0.95;0.45;1;0.5")), ((V)(1.4)))).S("</path>");
s_359.V(Add(Add(Call(rib_360, V.Undef, ((V)((PI_30 * 0.02))), ((V)((PI_30 * 0.5))), ((V)(26D)), ((V)(2D)), ((V)(1D))), Call(rib_360, V.Undef, ((V)((PI_30 * 0.45))), ((V)((PI_30 * 0.98))), ((V)(23D)), ((V)(3D)), ((V)(1D)))), Call(rib_360, V.Undef, ((V)((PI_30 * 0.25))), ((V)((PI_30 * 0.75))), ((V)(30D)), ((V)(4D)), ((V)(1D)))));
s_359.S("<path d=\"M").V(Call(P2_42, V.Undef, Call(pt2_358, V.Undef, ((V)(0D))))).S("A").N(rx_355).S(" ").N(ry_356).S(" 0 0 1 ").V(Call(P2_42, V.Undef, Call(pt2_358, V.Undef, ((V)(PI_30))))).S("\" fill=\"none\" stroke=\"#c9d0d6\" stroke-width=\"2.2\"/><path d=\"M").V(Call(P2_42, V.Undef, Call(pt2_358, V.Undef, ((V)(0D))))).S("A").N(rx_355).S(" ").N(ry_356).S(" 0 0 1 ").V(Call(P2_42, V.Undef, Call(pt2_358, V.Undef, ((V)(PI_30))))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.5\" transform=\"translate(0 -0.7)\" opacity=\"0.8\"/><path d=\"M").V(Call(P2_42, V.Undef, Call(pt2_358, V.Undef, ((V)(0D))))).S("A").N(rx_355).S(" ").N(ry_356).S(" 0 0 1 ").V(Call(P2_42, V.Undef, Call(pt2_358, V.Undef, ((V)(PI_30))))).S("\" fill=\"none\" stroke=\"#5effb0\" stroke-width=\"0.8\" stroke-dasharray=\"2 1.6\" transform=\"translate(0 0.9)\" filter=\"url(#ab)\">").V(Call(an_51, V.Undef, ((V)("stroke")), Invoke(CS_357, "join", ((V)(";"))), ((V)(8D)))).V(Call(an_51, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;30")), ((V)(2D)))).V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.6;1;0.5;1;0.7;0.6")), ((V)(1.1)))).S("</path>");
Call(rep_38, V.Undef, ((V)(8D)), Fn((V _arrowThis445, int _argc438, V i_444, V _a441, V _a442, V _a443, V[] _rest439) => {
return ((V)(s_359.S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)((16D + (ToNum(i_444) * 6.6)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((28D + ((ToNum(i_444) % 3D) * 6D)))))).S("\" r=\"0.45\" fill=\"#ffffff\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0;1;0")), ((V)((2D + ((ToNum(i_444) % 3D) * 0.5)))), ((V)(((-ToNum(i_444)) * 0.4))))).S("</circle>").Str));
}, 1, "", true));
return ((V)(s_359.Str));
return default;
}, 0, "auroraHalo", false);
blackWall_89 = Fn((V _self446, int _argc447, V _a449, V _a450, V _a451, V _a452, V[] _rest448) => {
JsStrBuf s_453 = null;
if (_self446.IsNullish) _self446 = GlobalV;
s_453 = new JsStrBuf("<defs><linearGradient id=\"bw0\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#1c1c21\"/><stop offset=\"1\" stop-color=\"#0b0b0d\"/></linearGradient><pattern id=\"bwt\" width=\"1.4\" height=\"1.4\" patternUnits=\"userSpaceOnUse\"><circle cx=\"0.35\" cy=\"0.35\" r=\"0.2\" fill=\"#ffffff\" fill-opacity=\"0.03\"/><circle cx=\"1.05\" cy=\"1.05\" r=\"0.2\" fill=\"#000000\" fill-opacity=\"0.35\"/></pattern><linearGradient id=\"bwsh\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.05\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient><clipPath id=\"bwc\"><rect width=\"80\" height=\"56\" rx=\"4\"/></clipPath></defs><g clip-path=\"url(#bwc)\"><rect width=\"80\" height=\"56\" fill=\"url(#bw0)\"/>");
{
double i_454 = 0;
i_454 = 0D;
while (true) {
if (!((i_454 < 6D))) break;
double x_456 = 0;
x_456 = ((i_454 * 80D) / 6D);
s_453.S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)((x_456 + 0.4))))).S("\" y=\"0.4\" width=\"").V(Call(f1_23, V.Undef, ((V)(((80D / 6D) - 0.8))))).S("\" height=\"51\" rx=\"0.5\" fill=\"url(#bwsh)\"/><path d=\"M").V(Call(f1_23, V.Undef, ((V)(x_456)))).S(" 0V52\" stroke=\"#000000\" stroke-width=\"0.7\"/><path d=\"M").V(Call(f1_23, V.Undef, ((V)((x_456 + 0.5))))).S(" 0V52\" stroke=\"#2c2c33\" stroke-width=\"0.25\"/>");
i_454++;
}
}
return ((V)(string.Concat(s_453.Str, "<rect width=\"80\" height=\"56\" fill=\"url(#bwt)\"/><rect y=\"52\" width=\"80\" height=\"4\" fill=\"#050506\"/><path d=\"M0 52H80\" stroke=\"#30303a\" stroke-width=\"0.4\"/></g>")));
return default;
}, 0, "blackWall", false);
blackLedFloor_90 = Fn((V _self457, int _argc458, V _a460, V _a461, V _a462, V _a463, V[] _rest459) => {
V T_464 = default;
double C_465 = 0;
double R_466 = 0;
double Y0_467 = 0;
double Y1_468 = 0;
double XB_469 = 0;
double SL_470 = 0;
V q_471 = default;
V quad_472 = default;
JsStrBuf s_473 = null;
JsStrBuf t_474 = null;
if (_self457.IsNullish) _self457 = GlobalV;
T_464 = ((V)("M14 0H66L80 56H0Z"));
C_465 = 12D;
R_466 = 6D;
Y0_467 = 5.4;
Y1_468 = 53.8;
XB_469 = 15.6;
SL_470 = 0.25;
q_471 = Fn((V _arrowThis483, int _argc475, V u_481, V v_482, V _a479, V _a480, V[] _rest476) => {
double y_484 = 0;
double L_485 = 0;
double Rr_486 = 0;
y_484 = (Y0_467 + ((Y1_468 - Y0_467) * ToNum(v_482)));
L_485 = (XB_469 + ((Y1_468 - y_484) * SL_470));
Rr_486 = (80D - L_485);
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((L_485 + ((Rr_486 - L_485) * ToNum(u_481))))))).S(" ").V(Call(f1_23, V.Undef, ((V)(y_484)))).End()));
return default;
}, 2, "", true);
quad_472 = Fn((V _arrowThis497, int _argc487, V a_493, V b_494, V c_495, V d_496, V[] _rest488) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(q_471, V.Undef, a_493, b_494)).S("L").V(Call(q_471, V.Undef, c_495, b_494)).S("L").V(Call(q_471, V.Undef, c_495, d_496)).S("L").V(Call(q_471, V.Undef, a_493, d_496)).S("Z").End()));
}, 4, "", true);
s_473 = new JsStrBuf(JsStrBuf.Begin().S("<defs>").V(Call(BLUR_56, V.Undef, ((V)("blf")), ((V)(1.2)))).S("<clipPath id=\"blc\"><path d=\"").V(T_464).S("\"/></clipPath><linearGradient id=\"bl0\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#0d0d10\"/><stop offset=\"1\" stop-color=\"#050506\"/></linearGradient><linearGradient id=\"blsh\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.2\"/><stop offset=\"0.55\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient></defs><g clip-path=\"url(#blc)\"><path d=\"").V(T_464).S("\" fill=\"url(#bl0)\"/>").End());
t_474 = new JsStrBuf("");
{
double j_498 = 0;
j_498 = 0D;
while (true) {
if (!((j_498 < R_466))) break;
{
double i_500 = 0;
i_500 = 0D;
while (true) {
if (!((i_500 < C_465))) break;
double k_502 = 0;
V seq_503 = default;
double b_504 = 0;
double gu_505 = 0;
double gv_506 = 0;
k_502 = ((i_500 + (j_498 * 2D)) % ToNum(Get(NEO_88, "length")));
seq_503 = Invoke(Invoke(Call(rep_38, V.Undef, Get(NEO_88, "length"), Fn((V _arrowThis514, int _argc507, V m_513, V _a510, V _a511, V _a512, V[] _rest508) => {
return GetIdx(NEO_88, (ToNum(Add(((V)(k_502)), m_513)) % ToNum(Get(NEO_88, "length"))));
}, 1, "", true)), "concat", GetIdx(NEO_88, k_502)), "join", ((V)(";")));
b_504 = (-ToNum(Invoke(((V)(((i_500 + j_498) * 0.18))), "toFixed", ((V)(2D)))));
gu_505 = (0.09 / C_465);
gv_506 = (0.1 / R_466);
t_474.S("<path d=\"").V(Call(quad_472, V.Undef, ((V)(((i_500 / C_465) + gu_505))), ((V)(((j_498 / R_466) + gv_506))), ((V)((((i_500 + 1D) / C_465) - gu_505))), ((V)((((j_498 + 1D) / R_466) - gv_506))))).S("\" fill=\"").V(GetIdx(NEO_88, k_502)).S("\">").V(Call(an_51, V.Undef, ((V)("fill")), seq_503, ((V)(5.6)), ((V)(b_504)))).V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("1;0.3;1")), ((V)(1.4)), Invoke(((V)((b_504 * 0.5))), "toFixed", ((V)(2D))))).S("</path>");
i_500++;
}
}
j_498++;
}
}
s_473.S("<path d=\"").V(Call(quad_472, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(1D)), ((V)(1D)))).S("\" fill=\"#000000\"/><g filter=\"url(#blf)\" opacity=\"0.5\">").S(t_474.Str).S("</g>").S(t_474.Str).S("<path d=\"").V(Call(quad_472, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(1D)), ((V)(1D)))).S("\" fill=\"url(#blsh)\"/><path d=\"").V(Call(quad_472, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(1D)), ((V)(1D)))).S("\" fill=\"none\" stroke=\"#000000\" stroke-width=\"0.35\"/>");
return ((V)(string.Concat(s_473.Str, "</g>")));
return default;
}, 0, "blackLedFloor", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy((((RD_8 is var _t515 && !Truthy(_t515) ? _t515 : Get(RD_8, "PLUS2")) is var _t516 && !Truthy(_t516) ? _t516 : X_9) is var _t517 && !Truthy(_t517) ? _t517 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_518.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS3"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t519 = K_10;
if (_t519.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t519));
{ V _t520 = Get(_t519, "solid");
solid_11 = _t520; }
{ V _t521 = Get(_t519, "box");
box_12 = _t521; }
{ V _t522 = Get(_t519, "cyl");
cyl_13 = _t522; }
{ V _t523 = Get(_t519, "ball");
ball_14 = _t523; }
{ V _t524 = Get(_t519, "slab");
slab_15 = _t524; }
{ V _t525 = Get(_t519, "slabX");
slabX_16 = _t525; }
{ V _t526 = Get(_t519, "arcW");
arcW_17 = _t526; }
{ V _t527 = Get(_t519, "disc");
disc_18 = _t527; }
{ V _t528 = Get(_t519, "prism");
prism_19 = _t528; }
{ V _t529 = Get(_t519, "prismZ");
prismZ_20 = _t529; }
{ V _t530 = Get(_t519, "shade");
shade_21 = _t530; }
{ V _t531 = Get(_t519, "mix");
mix_22 = _t531; }
{ V _t532 = Get(_t519, "f1");
f1_23 = _t532; } }
N_24 = Get(RD_8, "N");
em_25 = Get(Get(RD_8, "H"), "em");
GOLD_26 = ((V)("#e2b14a"));
CH_27 = ((V)("#d5dde2"));
WH_28 = ((V)("#ffffff"));
GL_29 = ((V)("#cfe8f2"));
PI_30 = System.Math.PI;
SA_31 = Get(X_9, "SA");
CA_32 = Get(X_9, "CA");
mt_33 = Fn((V _arrowThis540, int _argc533, V o_539, V _a536, V _a537, V _a538, V[] _rest534) => {
return Object_assign(NewObj(1).Put("mat", ((V)("metal"))).V, (o_539 is var _t541 && Truthy(_t541) ? _t541 : NewObj(0).V));
}, 1, "", true);
wd_34 = Fn((V _arrowThis549, int _argc542, V o_548, V _a545, V _a546, V _a547, V[] _rest543) => {
return Object_assign(NewObj(1).Put("mat", ((V)("wood"))).V, (o_548 is var _t550 && Truthy(_t550) ? _t550 : NewObj(0).V));
}, 1, "", true);
cer_35 = Fn((V _arrowThis558, int _argc551, V o_557, V _a554, V _a555, V _a556, V[] _rest552) => {
return Object_assign(NewObj(1).Put("mat", ((V)("cer"))).V, (o_557 is var _t559 && Truthy(_t559) ? _t559 : NewObj(0).V));
}, 1, "", true);
fb_36 = Fn((V _arrowThis567, int _argc560, V o_566, V _a563, V _a564, V _a565, V[] _rest561) => {
return Object_assign(NewObj(2).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).V, (o_566 is var _t568 && Truthy(_t568) ? _t568 : NewObj(0).V));
}, 1, "", true);
pt_37 = Fn((V _arrowThis576, int _argc569, V o_575, V _a572, V _a573, V _a574, V[] _rest570) => {
return Object_assign(NewObj(1).Put("mat", ((V)("paint"))).V, (o_575 is var _t577 && Truthy(_t577) ? _t577 : NewObj(0).V));
}, 1, "", true);
rep_38 = Fn((V _arrowThis586, int _argc578, V n_584, V f_585, V _a582, V _a583, V[] _rest579) => {
return Array_from(NewObj(1).Put("length", n_584).V, Fn((V _arrowThis595, int _argc587, V __593, V i_594, V _a591, V _a592, V[] _rest588) => {
return Call(f_585, V.Undef, i_594);
}, 2, "", true));
}, 2, "", true);
hash_39 = Fn((V _arrowThis603, int _argc596, V s_602, V _a599, V _a600, V _a601, V[] _rest597) => {
double h_604 = 0;
h_604 = 7D;
{
foreach (V _k605 in new JsIter(((V)(ToStrS(s_602))))) {
V ch_606 = default;
ch_606 = _k605;
h_604 = ((double)(ToInt32(ToNum(Add(((V)((h_604 * 31D))), Invoke(ch_606, "charCodeAt", ((V)(0D)))))) | ToInt32(0D)));
}
}
return ((V)(System.Math.Abs(h_604)));
return default;
}, 1, "", true);
rng_40 = Fn((V _arrowThis614, int _argc607, V s_613, V _a610, V _a611, V _a612, V[] _rest608) => {
V h_615 = default;
h_615 = (Call(hash_39, V.Undef, s_613) is var _t616 && Truthy(_t616) ? _t616 : ((V)(1D)));
return Fn((V _arrowThis623, int _argc617, V _a619, V _a620, V _a621, V _a622, V[] _rest618) => {
h_615 = ((V)(((double)(ToInt32(((ToNum(h_615) * 1103515245D) + 12345D)) | ToInt32(0D)))));
return ((V)((((double)(ToInt32(((double)(ToUint32(ToNum(h_615)) >> (int)(ToUint32(8D) & 31)))) & ToInt32(65535D))) / 65536D)));
return default;
}, 0, "", true);
return default;
}, 1, "", true);
n4_41 = Fn((V _arrowThis631, int _argc624, V v_630, V _a627, V _a628, V _a629, V[] _rest625) => {
return ((V)((Round((ToNum(v_630) * 10000D)) / 10000D)));
}, 1, "", true);
P2_42 = Fn((V _arrowThis639, int _argc632, V q_638, V _a635, V _a636, V _a637, V[] _rest633) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(q_638, 0D))).S(" ").V(Call(f1_23, V.Undef, GetIdx(q_638, 1D))).End()));
}, 1, "", true);
mtx_43 = Fn((V _arrowThis649, int _argc640, V o_646, V a_647, V b_648, V _a645, V[] _rest641) => {
return ((V)(JsStrBuf.Begin().S("matrix(").V(Invoke(Invoke(Arr(((V)((ToNum(GetIdx(a_647, 0D)) - ToNum(GetIdx(o_646, 0D))))), ((V)((ToNum(GetIdx(a_647, 1D)) - ToNum(GetIdx(o_646, 1D))))), ((V)((ToNum(GetIdx(b_648, 0D)) - ToNum(GetIdx(o_646, 0D))))), ((V)((ToNum(GetIdx(b_648, 1D)) - ToNum(GetIdx(o_646, 1D))))), GetIdx(o_646, 0D), GetIdx(o_646, 1D)), "map", n4_41), "join", ((V)(" ")))).S(")").End()));
}, 3, "", true);
plane_44 = Fn((V _arrowThis660, int _argc650, V p_656, V z_657, V y_658, V x0_659, V[] _rest651) => {
x0_659 = (x0_659 is var _t661 && Truthy(_t661) ? _t661 : ((V)(0D)));
if (((ToNum(GetIdx(Call(p_656, V.Undef, x0_659, y_658, Add(z_657, ((V)(1D)))), 1D)) - ToNum(GetIdx(Call(p_656, V.Undef, x0_659, y_658, z_657), 1D))) <= 0.002)) {
return ((V)("scale(0)"));
}
return Call(mtx_43, V.Undef, Call(p_656, V.Undef, x0_659, y_658, z_657), Call(p_656, V.Undef, Add(x0_659, ((V)(1D))), y_658, z_657), Call(p_656, V.Undef, x0_659, ((V)((ToNum(y_658) - 1D))), z_657));
return default;
}, 4, "", true);
planeX_45 = Fn((V _arrowThis672, int _argc662, V p_668, V x_669, V y_670, V z0_671, V[] _rest663) => {
return (((ToNum(GetIdx(Call(p_668, V.Undef, Add(x_669, ((V)(1D))), y_670, z0_671), 1D)) - ToNum(GetIdx(Call(p_668, V.Undef, x_669, y_670, z0_671), 1D))) <= 0.002) ? ((V)("scale(0)")) : Call(mtx_43, V.Undef, Call(p_668, V.Undef, x_669, y_670, z0_671), Call(p_668, V.Undef, x_669, y_670, Add(z0_671, ((V)(1D)))), Call(p_668, V.Undef, x_669, ((V)((ToNum(y_670) - 1D))), z0_671)));
}, 4, "", true);
planeH_46 = Fn((V _arrowThis683, int _argc673, V p_679, V y_680, V x0_681, V z0_682, V[] _rest674) => {
x0_681 = (x0_681 is var _t684 && Truthy(_t684) ? _t684 : ((V)(0D)));
z0_682 = (z0_682 is var _t685 && Truthy(_t685) ? _t685 : ((V)(0D)));
return Call(mtx_43, V.Undef, Call(p_679, V.Undef, x0_681, y_680, z0_682), Call(p_679, V.Undef, Add(x0_681, ((V)(1D))), y_680, z0_682), Call(p_679, V.Undef, x0_681, y_680, Add(z0_682, ((V)(1D)))));
return default;
}, 4, "", true);
kOf_47 = Fn((V _arrowThis693, int _argc686, V p_692, V _a689, V _a690, V _a691, V[] _rest687) => {
return ((V)(((ToNum(GetIdx(Call(p_692, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D))), 1D)) - ToNum(GetIdx(Call(p_692, V.Undef, ((V)(0D)), ((V)(1D)), ((V)(0D))), 1D))) / ToNum(CA_32))));
}, 1, "", true);
kt_48 = Fn((V _arrowThis701, int _argc694, V n_700, V _a697, V _a698, V _a699, V[] _rest695) => {
return Invoke(Call(rep_38, V.Undef, Add(n_700, ((V)(1D))), Fn((V _arrowThis709, int _argc702, V i_708, V _a705, V _a706, V _a707, V[] _rest703) => {
return Call(n4_41, V.Undef, ((V)((ToNum(i_708) / ToNum(n_700)))));
}, 1, "", true)), "join", ((V)(";")));
}, 1, "", true);
SPL_49 = Fn((V _arrowThis717, int _argc710, V n_716, V _a713, V _a714, V _a715, V[] _rest711) => {
return ((V)(JsStrBuf.Begin().S(" calcMode=\"spline\" keyTimes=\"").V(Call(kt_48, V.Undef, n_716)).S("\" keySplines=\"").V(Invoke(Call(rep_38, V.Undef, n_716, Fn((V _arrowThis724, int _argc718, V _a720, V _a721, V _a722, V _a723, V[] _rest719) => {
return ((V)("0.42 0 0.58 1"));
}, 0, "", true)), "join", ((V)(";")))).S("\"").End()));
}, 1, "", true);
B_50 = Fn((V _arrowThis732, int _argc725, V b_731, V _a728, V _a729, V _a730, V[] _rest726) => {
return ((V)((Truthy(b_731) ? JsStrBuf.Begin().S(" begin=\"").V(Call(n4_41, V.Undef, b_731)).S("s\"").End() : "")));
}, 1, "", true);
an_51 = Fn((V _arrowThis744, int _argc733, V a_739, V v_740, V d_741, V b_742, V[] _rest734) => {
V kts_743 = default;
kts_743 = (_argc733 > 4 ? _rest734[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<animate attributeName=\"").V(a_739).S("\" values=\"").V(v_740).S("\" dur=\"").V(d_741).S("s\"").S((Truthy(kts_743) ? JsStrBuf.Begin().S(" keyTimes=\"").V(kts_743).S("\"").End() : "")).V(Call(B_50, V.Undef, b_742)).S(" repeatCount=\"indefinite\"/>").End()));
}, 5, "", true);
anS_52 = Fn((V _arrowThis755, int _argc745, V a_751, V v_752, V d_753, V b_754, V[] _rest746) => {
return ((V)(JsStrBuf.Begin().S("<animate attributeName=\"").V(a_751).S("\" values=\"").V(v_752).S("\" dur=\"").V(d_753).S("s\"").V(Call(SPL_49, V.Undef, ((V)((ToNum(Get(Invoke(v_752, "split", ((V)(";"))), "length")) - 1D))))).V(Call(B_50, V.Undef, b_754)).S(" repeatCount=\"indefinite\"/>").End()));
}, 4, "", true);
anD_53 = Fn((V _arrowThis766, int _argc756, V a_762, V v_763, V d_764, V b_765, V[] _rest757) => {
return ((V)(JsStrBuf.Begin().S("<animate attributeName=\"").V(a_762).S("\" values=\"").V(v_763).S("\" dur=\"").V(d_764).S("s\" calcMode=\"discrete\"").V(Call(B_50, V.Undef, b_765)).S(" repeatCount=\"indefinite\"/>").End()));
}, 4, "", true);
at_54 = Fn((V _arrowThis777, int _argc767, V t_773, V v_774, V d_775, V b_776, V[] _rest768) => {
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"").V(t_773).S("\" values=\"").V(v_774).S("\" dur=\"").V(d_775).S("s\"").V(Call(B_50, V.Undef, b_776)).S(" repeatCount=\"indefinite\"/>").End()));
}, 4, "", true);
atS_55 = Fn((V _arrowThis788, int _argc778, V t_784, V v_785, V d_786, V b_787, V[] _rest779) => {
return ((V)(JsStrBuf.Begin().S("<animateTransform attributeName=\"transform\" type=\"").V(t_784).S("\" values=\"").V(v_785).S("\" dur=\"").V(d_786).S("s\"").V(Call(SPL_49, V.Undef, ((V)((ToNum(Get(Invoke(v_785, "split", ((V)(";"))), "length")) - 1D))))).V(Call(B_50, V.Undef, b_787)).S(" repeatCount=\"indefinite\"/>").End()));
}, 4, "", true);
BLUR_56 = Fn((V _arrowThis797, int _argc789, V id_795, V s_796, V _a793, V _a794, V[] _rest790) => {
return ((V)(JsStrBuf.Begin().S("<filter id=\"").V(id_795).S("\" x=\"-60%\" y=\"-60%\" width=\"220%\" height=\"220%\"><feGaussianBlur stdDeviation=\"").V(s_796).S("\"/></filter>").End()));
}, 2, "", true);
bbOf_57 = Fn((V _arrowThis806, int _argc798, V pts_804, V m_805, V _a802, V _a803, V[] _rest799) => {
double a_807 = 0;
double b_808 = 0;
double c_809 = 0;
double d_810 = 0;
m_805 = (m_805 is var _t811 && Truthy(_t811) ? _t811 : ((V)(4D)));
a_807 = 1000000000D;
b_808 = 1000000000D;
c_809 = (-1000000000D);
d_810 = (-1000000000D);
Invoke(pts_804, "forEach", Fn((V _arrowThis819, int _argc812, V q_818, V _a815, V _a816, V _a817, V[] _rest813) => {
a_807 = Min(a_807, ToNum(GetIdx(q_818, 0D)));
b_808 = Min(b_808, ToNum(GetIdx(q_818, 1D)));
c_809 = Max(c_809, ToNum(GetIdx(q_818, 0D)));
d_810 = Max(d_810, ToNum(GetIdx(q_818, 1D)));
return default;
}, 1, "", true));
return Arr(((V)((a_807 - ToNum(m_805)))), ((V)((b_808 - ToNum(m_805)))), Add(((V)(c_809)), m_805), Add(((V)(d_810)), m_805));
return default;
}, 2, "", true);
HULL_58 = NewRegExp(RX0, "<path d=\"([^\"]+)\" fill=\"url\\(#h[SR][^\"]*\\)\"[^>]*\\/>", "g");
tex_59 = Fn((V _arrowThis828, int _argc820, V s_826, V pats_827, V _a824, V _a825, V[] _rest821) => {
V hs_829 = default;
V o_830 = default;
hs_829 = Arr();
Invoke(s_826, "replace", HULL_58, Fn((V _arrowThis839, int _argc831, V m_837, V d_838, V _a835, V _a836, V[] _rest832) => {
Invoke(hs_829, "push", d_838);
return m_837;
return default;
}, 2, "", true));
if (!(Truthy(Get(hs_829, "length")))) {
return s_826;
}
o_830 = s_826;
Invoke(pats_827, "forEach", Fn((V _arrowThis851, int _argc840, V _a842, V _a843, V _a844, V _a845, V[] _rest841) => {
V id_848 = default;
V op_850 = default;
{ V _t846 = ListOf(_a842);
{ V _t847 = GetIdx(_t846, 0D);
id_848 = _t847; }
{ V _t849 = GetIdx(_t846, 1D);
op_850 = _t849; }
}
o_830 = ((V)(JsStrBuf.Begin().V(o_830).S("<g opacity=\"").V(op_850).S("\">").V(Invoke(Invoke(hs_829, "map", Fn((V _arrowThis859, int _argc852, V d_858, V _a855, V _a856, V _a857, V[] _rest853) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(d_858).S("\" fill=\"url(#").V(id_848).S(")\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>").End()));
return default;
}, 1, "", true));
return o_830;
return default;
}, 2, "", true);
PATS_60 = ((V)(JsStrBuf.Begin().S("<pattern id=\"p3bou\" width=\"3.4\" height=\"3.4\" patternUnits=\"userSpaceOnUse\"><circle cx=\"0.9\" cy=\"0.9\" r=\"0.62\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.55\" stroke-width=\"0.36\"/><circle cx=\"2.5\" cy=\"2.4\" r=\"0.7\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.16\" stroke-width=\"0.36\"/><circle cx=\"2.6\" cy=\"0.8\" r=\"0.42\" fill=\"#ffffff\" fill-opacity=\"0.3\"/><circle cx=\"0.9\" cy=\"2.6\" r=\"0.46\" fill=\"#000000\" fill-opacity=\"0.09\"/></pattern>").S("<pattern id=\"p3she\" width=\"4.2\" height=\"3.6\" patternUnits=\"userSpaceOnUse\"><path d=\"M0.3 1.7q0.7-1.3 1.4 0t1.4 0\" fill=\"none\" stroke=\"#ffffff\" stroke-opacity=\"0.65\" stroke-width=\"0.5\" stroke-linecap=\"round\"/><path d=\"M1.6 3.3q0.7-1.2 1.4 0t1.4 0\" fill=\"none\" stroke=\"#6a5a40\" stroke-opacity=\"0.25\" stroke-width=\"0.5\" stroke-linecap=\"round\"/></pattern>").S("<pattern id=\"p3lea\" width=\"10\" height=\"8\" patternUnits=\"userSpaceOnUse\"><path d=\"M0.6 2.4q2-0.7 3.8 0.3M5.2 5.8q1.9 0.5 3.6-0.4M2 6.6q0.8-0.4 1.6 0\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.16\" stroke-width=\"0.32\"/><circle cx=\"7.6\" cy=\"1.6\" r=\"0.3\" fill=\"#000000\" fill-opacity=\"0.12\"/><circle cx=\"3.2\" cy=\"4.4\" r=\"0.25\" fill=\"#ffffff\" fill-opacity=\"0.14\"/></pattern>").S("<linearGradient id=\"p3vel\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.3\"/><stop offset=\"0.32\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.72\" stop-color=\"#000000\" stop-opacity=\"0.16\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0.12\"/></linearGradient>").S("<radialGradient id=\"p3puff\" cx=\"45%\" cy=\"40%\" r=\"62%\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.26\"/><stop offset=\"0.55\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.3\"/></radialGradient>").S("<linearGradient id=\"p3chan\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#000000\" stop-opacity=\"0.24\"/><stop offset=\"0.42\" stop-color=\"#ffffff\" stop-opacity=\"0.22\"/><stop offset=\"1\" stop-color=\"#000000\" stop-opacity=\"0.24\"/></linearGradient>").S("<radialGradient id=\"p3nail\" cx=\"35%\" cy=\"30%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#fff4c8\"/><stop offset=\"0.5\" stop-color=\"#d4a548\"/><stop offset=\"1\" stop-color=\"#7a5a1e\"/></radialGradient>").S("<linearGradient id=\"p3glass\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.45\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#ffffff\" stop-opacity=\"0.55\"/><stop offset=\"0.58\" stop-color=\"#ffffff\" stop-opacity=\"0.08\"/><stop offset=\"0.66\" stop-color=\"#ffffff\" stop-opacity=\"0.3\"/><stop offset=\"0.7\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient>").S("<radialGradient id=\"p3gold\" cx=\"35%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#fff6c8\"/><stop offset=\"0.45\" stop-color=\"#f0c24a\"/><stop offset=\"1\" stop-color=\"#9a6a14\"/></radialGradient>").End()));
CID_61 = 0D;
clipR_62 = Fn((V _arrowThis869, int _argc860, V w_866, V h_867, V r_868, V _a865, V[] _rest861) => {
V id_870 = default;
id_870 = ((V)(JsStrBuf.Begin().S("p3c").N(++CID_61).End()));
return NewObj(2).Put("id", id_870).Put("d", ((V)(JsStrBuf.Begin().S("<clipPath id=\"").V(id_870).S("\"><rect x=\"0\" y=\"0\" width=\"").V(Call(f1_23, V.Undef, w_866)).S("\" height=\"").V(Call(f1_23, V.Undef, h_867)).S("\" rx=\"").V((r_868 is var _t871 && Truthy(_t871) ? _t871 : ((V)(1.5)))).S("\"/></clipPath>").End()))).V;
return default;
}, 3, "", true);
pleats_65 = Fn((V _arrowThis882, int _argc872, V rx_878, V ry_879, V col_880, V btn_881, V[] _rest873) => {
JsStrBuf d_883 = null;
d_883 = new JsStrBuf("");
Call(rep_38, V.Undef, ((V)(11D)), Fn((V _arrowThis891, int _argc884, V i_890, V _a887, V _a888, V _a889, V[] _rest885) => {
double a_892 = 0;
a_892 = (PI_30 * (0.92 + (ToNum(i_890) * 0.116)));
d_883.S("M0 ").V(Call(f1_23, V.Undef, ((V)((ToNum(ry_879) * 0.3))))).S("L").V(Call(f1_23, V.Undef, ((V)(((FdLibm.Cos(a_892) * ToNum(rx_878)) * 0.94))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((FdLibm.Sin(a_892) * ToNum(ry_879)) * 0.94)))));
return default;
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"0\" cy=\"0\" rx=\"").V(Call(f1_23, V.Undef, rx_878)).S("\" ry=\"").V(Call(f1_23, V.Undef, ry_879)).S("\" fill=\"url(#p3puff)\" opacity=\"0.8\"/><path d=\"").S(d_883.Str).S("\" fill=\"none\" stroke=\"").V(Call(shade_21, V.Undef, col_880, ((V)(0.48)))).S("\" stroke-width=\"0.55\" stroke-linecap=\"round\"/><circle cx=\"0\" cy=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(ry_879) * 0.3))))).S("\" r=\"1.5\" fill=\"").V(btn_881).S("\" stroke=\"").V(Call(shade_21, V.Undef, btn_881, ((V)(0.55)))).S("\" stroke-width=\"0.3\"/>").End()));
return default;
}, 4, "", true);
nailRow_66 = Fn((V _arrowThis901, int _argc893, V pts_899, V sp_900, V _a897, V _a898, V[] _rest894) => {
JsStrBuf s_902 = null;
s_902 = new JsStrBuf("");
{
double i_903 = 0;
i_903 = 0D;
while (true) {
if (!((i_903 < (ToNum(Get(pts_899, "length")) - 1D)))) break;
V a_905 = default;
V b_906 = default;
double L_907 = 0;
double m_908 = 0;
a_905 = GetIdx(pts_899, i_903);
b_906 = GetIdx(pts_899, (i_903 + 1D));
L_907 = Hypot((ToNum(GetIdx(b_906, 0D)) - ToNum(GetIdx(a_905, 0D))), (ToNum(GetIdx(b_906, 1D)) - ToNum(GetIdx(a_905, 1D))));
m_908 = Max(1D, Round((L_907 / ToNum(sp_900))));
{
double k_909 = 0;
k_909 = 0D;
while (true) {
if (!((k_909 < m_908))) break;
double t_911 = 0;
t_911 = (k_909 / m_908);
s_902.S("<circle cx=\"").V(Call(f1_23, V.Undef, Add(GetIdx(a_905, 0D), ((V)(((ToNum(GetIdx(b_906, 0D)) - ToNum(GetIdx(a_905, 0D))) * t_911)))))).S("\" cy=\"").V(Call(f1_23, V.Undef, Add(GetIdx(a_905, 1D), ((V)(((ToNum(GetIdx(b_906, 1D)) - ToNum(GetIdx(a_905, 1D))) * t_911)))))).S("\" r=\"0.78\" fill=\"url(#p3nail)\" stroke=\"#5a3e12\" stroke-width=\"0.2\"/>");
k_909++;
}
}
i_903++;
}
}
return ((V)(s_902.Str));
return default;
}, 2, "", true);
seatC_67 = Fn((V _arrowThis926, int _argc912, V x_918, V y_919, V z_920, V w_921, V[] _rest913) => {
V h_922 = default;
V d_923 = default;
V col_924 = default;
V o_925 = default;
h_922 = (_argc912 > 4 ? _rest913[0] : V.Undef);
d_923 = (_argc912 > 5 ? _rest913[1] : V.Undef);
col_924 = (_argc912 > 6 ? _rest913[2] : V.Undef);
o_925 = (_argc912 > 7 ? _rest913[3] : V.Undef);
return Call(solid_11, V.Undef, Object_assign(NewObj(10).Put("ax", ((V)("y"))).Put("sh", ((V)("rr"))).Put("c", Arr(x_918, z_920)).Put("a", ((V)((ToNum(w_921) / 2D)))).Put("b", ((V)((ToNum(d_923) / 2D)))).Put("r", ((V)((Min(ToNum(w_921), ToNum(d_923)) * 0.15)))).Put("rings", Arr(Arr(y_919, ((V)(1.4)), ((V)(0.97))), Arr(Add(y_919, ((V)(1.4))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(Add(y_919, h_922)) - 3D))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(Add(y_919, h_922)) - 1D))), ((V)(1.4)), ((V)(0.99))), Arr(Add(y_919, h_922), ((V)(4.2)), ((V)(0.95))), Arr(Add(Add(y_919, h_922), ((V)(1.6))), ((V)(10D)), ((V)(0.85))))).Put("col", col_924).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V, (o_925 is var _t927 && Truthy(_t927) ? _t927 : NewObj(0).V)));
}, 8, "", true);
throwP_68 = Fn((V _arrowThis940, int _argc928, V x_934, V y_935, V z_936, V s_937, V[] _rest929) => {
V col_938 = default;
V o_939 = default;
col_938 = (_argc928 > 4 ? _rest929[0] : V.Undef);
o_939 = (_argc928 > 5 ? _rest929[1] : V.Undef);
return Call(solid_11, V.Undef, Object_assign(NewObj(10).Put("ax", ((V)("z"))).Put("sh", ((V)("rr"))).Put("c", Arr(x_934, Add(y_935, ((V)((ToNum(s_937) / 2D)))))).Put("a", ((V)((ToNum(s_937) / 2D)))).Put("b", ((V)((ToNum(s_937) / 2D)))).Put("r", ((V)((ToNum(s_937) * 0.3)))).Put("rings", Arr(Arr(((V)((ToNum(z_936) - 4.5))), ((V)(4D)), ((V)(0.82))), Arr(((V)((ToNum(z_936) - 2.6))), ((V)(1D)), ((V)(0.97))), Arr(z_936, ((V)(0D)), ((V)(1D))), Arr(Add(z_936, ((V)(2.6))), ((V)(1D)), ((V)(0.97))), Arr(Add(z_936, ((V)(4.5))), ((V)(4D)), ((V)(0.82))))).Put("col", col_938).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V, (o_939 is var _t941 && Truthy(_t941) ? _t941 : NewObj(0).V)));
}, 6, "", true);
veinsSVG_69 = Fn((V _arrowThis953, int _argc942, V R_948, V w_949, V h_950, V n_951, V[] _rest943) => {
JsStrBuf s_954 = null;
V col_952 = default;
col_952 = (_argc942 > 4 ? _rest943[0] : V.Undef);
s_954 = new JsStrBuf("");
Call(rep_38, V.Undef, n_951, Fn((V _arrowThis961, int _argc955, V _a957, V _a958, V _a959, V _a960, V[] _rest956) => {
double x_962 = 0;
double y_963 = 0;
JsStrBuf d_964 = null;
x_962 = (ToNum(Call(R_948, V.Undef)) * ToNum(w_949));
y_963 = (ToNum(Call(R_948, V.Undef)) * ToNum(h_950));
d_964 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(f1_23, V.Undef, ((V)(x_962)))).S(" ").V(Call(f1_23, V.Undef, ((V)(y_963)))).End());
Call(rep_38, V.Undef, ((V)(4D)), Fn((V _arrowThis971, int _argc965, V _a967, V _a968, V _a969, V _a970, V[] _rest966) => {
double nx_972 = 0;
double ny_973 = 0;
nx_972 = ((x_962 + 6D) + (ToNum(Call(R_948, V.Undef)) * 14D));
ny_973 = (y_963 + ((ToNum(Call(R_948, V.Undef)) - 0.4) * 6D));
d_964.S("Q").V(Call(f1_23, V.Undef, ((V)((((x_962 + nx_972) / 2D) + ((ToNum(Call(R_948, V.Undef)) - 0.5) * 4D)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((((y_963 + ny_973) / 2D) + ((ToNum(Call(R_948, V.Undef)) - 0.5) * 4D)))))).S(" ").V(Call(f1_23, V.Undef, ((V)(nx_972)))).S(" ").V(Call(f1_23, V.Undef, ((V)(ny_973))));
x_962 = nx_972;
y_963 = ny_973;
return default;
}, 0, "", true));
s_954.S("<path d=\"").S(d_964.Str).S("\" fill=\"none\" stroke=\"").V((col_952 is var _t974 && Truthy(_t974) ? _t974 : ((V)("#b9ae98")))).S("\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.25 + (ToNum(Call(R_948, V.Undef)) * 0.35)))))).S("\" opacity=\"0.6\"/>");
return default;
}, 0, "", true));
return ((V)(s_954.Str));
return default;
}, 5, "", true);
Set(N_24, "chester", Fn((V _arrowThis982, int _argc975, V S_981, V _a978, V _a979, V _a980, V[] _rest976) => {
V n_983 = default;
V ch_984 = default;
V gold_985 = default;
V lea_986 = default;
V bou_987 = default;
V mar_988 = default;
double SW_989 = 0;
double AW_990 = 0;
double Wd_991 = 0;
double Dp_992 = 0;
double B0_993 = 0;
double RT_994 = 0;
double ST_995 = 0;
double CT_996 = 0;
double TOP_997 = 0;
double BZ0_998 = 0;
double BZ1_999 = 0;
double ZF_1000 = 0;
V xs_1001 = default;
double xl_1002 = 0;
double xr_1003 = 0;
V legc_1004 = default;
V F_1005 = default;
V BT_1006 = default;
V pats_1007 = default;
double rollY_1008 = 0;
double rA_1009 = 0;
double rB_1010 = 0;
V rX_1011 = default;
double z0_1012 = 0;
V arm_1013 = default;
V D_1014 = default;
V pal_1015 = default;
n_983 = (Get(S_981, "n") is var _t1016 && Truthy(_t1016) ? _t1016 : ((V)(3D)));
ch_984 = (SEqS(Get(S_981, "st"), "channel") ? V.True : V.False);
gold_985 = (!(!(Truthy(Get(S_981, "gold")))) ? V.True : V.False);
lea_986 = (!(!(Truthy(Get(S_981, "leather")))) ? V.True : V.False);
bou_987 = (!(!(Truthy(Get(S_981, "boucle")))) ? V.True : V.False);
mar_988 = Get(S_981, "plinth");
SW_989 = 58D;
AW_990 = (Truthy(ch_984) ? 21D : 24D);
Wd_991 = ((ToNum(n_983) * SW_989) + (AW_990 * 2D));
Dp_992 = 94D;
B0_993 = (Truthy(mar_988) ? 13D : 9D);
RT_994 = (B0_993 + 13D);
ST_995 = (RT_994 + 9D);
CT_996 = (ST_995 + 13D);
TOP_997 = (RT_994 + (Truthy(ch_984) ? 50D : 46D));
BZ0_998 = ((-Dp_992) / 2D);
BZ1_999 = (BZ0_998 + 18D);
ZF_1000 = (Dp_992 / 2D);
xs_1001 = Call(rep_38, V.Undef, n_983, Fn((V _arrowThis1024, int _argc1017, V i_1023, V _a1020, V _a1021, V _a1022, V[] _rest1018) => {
return ((V)(((((-Wd_991) / 2D) + AW_990) + (SW_989 * ToNum(Add(i_1023, ((V)(0.5))))))));
}, 1, "", true));
xl_1002 = (((-Wd_991) / 2D) + AW_990);
xr_1003 = ((Wd_991 / 2D) - AW_990);
legc_1004 = (Truthy(gold_985) ? GOLD_26 : (Get(S_981, "wood") is var _t1025 && Truthy(_t1025) ? _t1025 : ((V)("#4a2c1a"))));
F_1005 = Fn((V _arrowThis1033, int _argc1026, V P_1032, V _a1029, V _a1030, V _a1031, V[] _rest1027) => {
return ((Get(P_1032, "c") is var _t1034 && !Truthy(_t1034) ? _t1034 : Get(Get(P_1032, "c"), "a")) is var _t1035 && Truthy(_t1035) ? _t1035 : Get(P_1032, "a"));
}, 1, "", true);
BT_1006 = Fn((V _arrowThis1043, int _argc1036, V P_1042, V _a1039, V _a1040, V _a1041, V[] _rest1037) => {
return (Truthy(gold_985) ? ((V)("#f0c24a")) : Call(shade_21, V.Undef, Call(F_1005, V.Undef, P_1042), ((V)((Truthy(lea_986) ? 0.62 : 0.72)))));
}, 1, "", true);
pats_1007 = (Truthy(lea_986) ? Arr(Arr(((V)("p3lea")), ((V)(0.8))), Arr(((V)("p3vel")), ((V)(0.6)))) : (Truthy(bou_987) ? Arr(Arr(((V)("p3bou")), ((V)(0.55))), Arr(((V)("p3vel")), ((V)(0.3)))) : Arr(Arr(((V)("p3vel")), ((V)(0.55))))));
rollY_1008 = (TOP_997 - (Truthy(ch_984) ? 5D : 6D));
rA_1009 = (Truthy(ch_984) ? (AW_990 / 2D) : ((AW_990 / 2D) + 3.2));
rB_1010 = (Truthy(ch_984) ? 6D : 7.6);
rX_1011 = Fn((V _arrowThis1051, int _argc1044, V sg_1050, V _a1047, V _a1048, V _a1049, V[] _rest1045) => {
return ((V)((ToNum(sg_1050) * (((Wd_991 / 2D) - (AW_990 / 2D)) + (Truthy(ch_984) ? 0D : 3D)))));
}, 1, "", true);
z0_1012 = (BZ0_998 + 3D);
arm_1013 = Fn((V _arrowThis1060, int _argc1052, V P_1058, V sg_1059, V _a1056, V _a1057, V[] _rest1053) => {
V f_1061 = default;
double x_1062 = 0;
f_1061 = Call(F_1005, V.Undef, P_1058);
x_1062 = (ToNum(sg_1059) * ((Wd_991 / 2D) - (AW_990 / 2D)));
return Arr(Call(box_12, V.Undef, ((V)(x_1062)), ((V)(RT_994)), ((V)(((z0_1012 + ZF_1000) / 2D))), ((V)(AW_990)), ((V)((rollY_1008 - RT_994))), ((V)((ZF_1000 - z0_1012))), f_1061, Call(fb_36, V.Undef, NewObj(1).Put("r", ((V)(5D))).V)), Call(solid_11, V.Undef, Call(fb_36, V.Undef, NewObj(8).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(Call(rX_1011, V.Undef, sg_1059), ((V)(rollY_1008)))).Put("a", ((V)(rA_1009))).Put("b", ((V)(rB_1010))).Put("n", ((V)(18D))).Put("rings", Arr(Arr(((V)(z0_1012)), ((V)(0D)), ((V)(0.9))), Arr(((V)((z0_1012 + 2.5))), ((V)(0D)), ((V)(1D))), Arr(((V)((ZF_1000 - 0.5))), ((V)(0D)), ((V)(1D))), Arr(((V)((ZF_1000 + 2D))), ((V)(0D)), ((V)(0.9))))).Put("col", f_1061).V)));
return default;
}, 2, "", true);
D_1014 = NewObj(4).Put("w", ((V)((Wd_991 + (Truthy(ch_984) ? 4D : 10D))))).Put("d", ((V)((Dp_992 + 6D)))).Put("act", ((V)("sit"))).Put("seats", Invoke(xs_1001, "map", Fn((V _arrowThis1070, int _argc1063, V x_1069, V _a1066, V _a1067, V _a1068, V[] _rest1064) => {
return NewObj(3).Put("x", x_1069).Put("z", ((V)(((BZ1_999 + ZF_1000) / 2D)))).Put("h", ((V)((CT_996 + 1D)))).V;
}, 1, "", true))).V;
pal_1015 = Fn((V _arrowThis1077, int _argc1071, V _a1073, V _a1074, V _a1075, V _a1076, V[] _rest1072) => {
return Invoke(X_9, "pal", D_1014, ((V)(0D)));
}, 0, "", true);
Set(D_1014, "layers", Arr(NewObj(3).Put("back", ((V)(1D))).Put("build", Fn((V _arrowThis1085, int _argc1078, V P_1084, V _a1081, V _a1082, V _a1083, V[] _rest1079) => {
V f_1086 = default;
f_1086 = Call(F_1005, V.Undef, P_1084);
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(RT_994)), ((V)(((BZ0_998 + BZ1_999) / 2D))), ((V)((Wd_991 - 2D))), ((V)(((TOP_997 - RT_994) - 4D))), ((V)((BZ1_999 - BZ0_998))), f_1086, Call(fb_36, V.Undef, NewObj(1).Put("r", ((V)(4D))).V)), Call(solid_11, V.Undef, Call(fb_36, V.Undef, NewObj(8).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(((BZ0_998 + BZ1_999) / 2D))), ((V)((TOP_997 - 4D))))).Put("a", ((V)((((BZ1_999 - BZ0_998) / 2D) + 0.6)))).Put("b", ((V)(5D))).Put("n", ((V)(16D))).Put("rings", Arr(Arr(((V)((((-Wd_991) / 2D) + 1D))), ((V)(0D)), ((V)(0.82))), Arr(((V)((((-Wd_991) / 2D) + 3D))), ((V)(0D)), ((V)(1D))), Arr(((V)(((Wd_991 / 2D) - 3D))), ((V)(0D)), ((V)(1D))), Arr(((V)(((Wd_991 / 2D) - 1D))), ((V)(0D)), ((V)(0.82))))).Put("col", f_1086).V)));
return default;
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1095, int _argc1087, V p_1093, V s_1094, V _a1091, V _a1092, V[] _rest1088) => {
V P_1096 = default;
V f_1097 = default;
double w_1098 = 0;
double h_1099 = 0;
P_1096 = Call(pal_1015, V.Undef);
f_1097 = Call(F_1005, V.Undef, P_1096);
w_1098 = (xr_1003 - xl_1002);
h_1099 = ((TOP_997 - 9.5) - (ST_995 + 1D));
return ((V)(JsStrBuf.Begin().V(Call(tex_59, V.Undef, s_1094, pats_1007)).S("<g transform=\"").V(Call(plane_44, V.Undef, p_1093, ((V)((BZ1_999 + 0.1))), ((V)((TOP_997 - 9.5))), ((V)(xl_1002)))).S("\">").V((Truthy(ch_984) ? Call(chan_64, V.Undef, ((V)(w_1098)), ((V)(h_1099)), f_1097) : Call(tuft_63, V.Undef, ((V)(w_1098)), ((V)(h_1099)), f_1097, Call(BT_1006, V.Undef, P_1096), NewObj(1).Put("pleat", ((V)(1D))).V))).S("</g>").End()));
return default;
}, 2, "wrap", true)).V, NewObj(3).Put("back", ((V)(1D))).Put("build", Fn((V _arrowThis1107, int _argc1100, V P_1106, V _a1103, V _a1104, V _a1105, V[] _rest1101) => {
return Call(arm_1013, V.Undef, P_1106, ((V)((-1D))));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1116, int _argc1108, V p_1114, V s_1115, V _a1112, V _a1113, V[] _rest1109) => {
V P_1117 = default;
V f_1118 = default;
V o_1119 = default;
P_1117 = Call(pal_1015, V.Undef);
f_1118 = Call(F_1005, V.Undef, P_1117);
o_1119 = Call(tex_59, V.Undef, s_1115, pats_1007);
if (!(Truthy(ch_984))) {
double h_1120 = 0;
h_1120 = (((rollY_1008 - rB_1010) - 0.6) - (ST_995 + 1D));
o_1119 = ((V)(JsStrBuf.Begin().V(o_1119).S("<g transform=\"").V(Call(planeX_45, V.Undef, p_1114, ((V)((xl_1002 + 0.1))), ((V)(((rollY_1008 - rB_1010) - 0.6))), ((V)((BZ1_999 + 1D))))).S("\">").V(Call(tuft_63, V.Undef, ((V)(((ZF_1000 - BZ1_999) - 3D))), ((V)(h_1120)), f_1118, Call(BT_1006, V.Undef, P_1117), NewObj(1).Put("cell", ((V)(13D))).V)).S("</g><g transform=\"").V(Call(plane_44, V.Undef, p_1114, ((V)((ZF_1000 + 2.1))), ((V)(rollY_1008)), Call(rX_1011, V.Undef, ((V)((-1D)))))).S("\">").V(Call(pleats_65, V.Undef, ((V)((rA_1009 * 0.88))), ((V)((rB_1010 * 0.88))), f_1118, Call(BT_1006, V.Undef, P_1117))).S("</g>").End()));
}
if (Truthy(lea_986)) {
o_1119 = ((V)(JsStrBuf.Begin().V(o_1119).S("<g transform=\"").V(Call(plane_44, V.Undef, p_1114, ((V)((ZF_1000 + 0.25))), ((V)(0D)), ((V)((((-Wd_991) / 2D) + (AW_990 / 2D)))))).S("\">").V(Call(nailRow_66, V.Undef, Arr(Arr(((V)((((-AW_990) / 2D) + 1.6))), ((V)((-(RT_994 + 1.5))))), Arr(((V)((((-AW_990) / 2D) + 1.6))), ((V)((-(rollY_1008 - rB_1010))))), Arr(((V)(((AW_990 / 2D) - 1.6))), ((V)((-(rollY_1008 - rB_1010))))), Arr(((V)(((AW_990 / 2D) - 1.6))), ((V)((-(RT_994 + 1.5)))))), ((V)(2.3)))).S("</g>").End()));
}
return o_1119;
return default;
}, 2, "wrap", true)).V, NewObj(2).Put("build", Fn((V _arrowThis1128, int _argc1121, V P_1127, V _a1124, V _a1125, V _a1126, V[] _rest1122) => {
V f_1129 = default;
V fl_1130 = default;
V o_1131 = default;
V pc_1132 = default;
f_1129 = Call(F_1005, V.Undef, P_1127);
fl_1130 = Call(mix_22, V.Undef, f_1129, ((V)("#ffffff")), ((V)((Truthy(lea_986) ? 0.05 : 0.09))));
o_1131 = Arr();
Invoke(xs_1001, "forEach", Fn((V _arrowThis1140, int _argc1133, V x_1139, V _a1136, V _a1137, V _a1138, V[] _rest1134) => {
return Invoke(o_1131, "push", Call(seatC_67, V.Undef, x_1139, ((V)(ST_995)), ((V)((((BZ1_999 + ZF_1000) / 2D) + 1D))), ((V)((SW_989 - 2D))), ((V)((CT_996 - ST_995))), ((V)(((ZF_1000 - BZ1_999) - 1D))), fl_1130));
}, 1, "", true));
pc_1132 = (Get(S_981, "pil") is var _t1141 && Truthy(_t1141) ? _t1141 : ((V)((Truthy(lea_986) ? "#e9dcc0" : (Truthy(gold_985) ? "#e9c66a" : (Truthy(bou_987) ? "#c9a35a" : "#d8b25a"))))));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1149, int _argc1142, V sg_1148, V _a1145, V _a1146, V _a1147, V[] _rest1143) => {
return Invoke(o_1131, "push", Call(throwP_68, V.Undef, ((V)((ToNum(sg_1148) * (((Wd_991 / 2D) - AW_990) - 16D)))), ((V)((CT_996 - 1.5))), ((V)((BZ1_999 + 5.2))), ((V)(24D)), (LtN(sg_1148, 0D) ? pc_1132 : Call(shade_21, V.Undef, pc_1132, ((V)(0.9))))));
}, 1, "", true));
if (GeN(n_983, 4D)) {
Invoke(o_1131, "push", Call(solid_11, V.Undef, Call(fb_36, V.Undef, NewObj(8).Put("ax", ((V)("z"))).Put("sh", ((V)("rr"))).Put("c", Arr(((V)(0D)), ((V)((CT_996 + 7D))))).Put("a", ((V)(17D))).Put("b", ((V)(7.5))).Put("r", ((V)(6D))).Put("rings", Arr(Arr(((V)((BZ1_999 + 0.6))), ((V)(3D)), ((V)(0.82))), Arr(((V)((BZ1_999 + 2.6))), ((V)(0.6)), ((V)(0.97))), Arr(((V)((BZ1_999 + 5D))), ((V)(0D)), ((V)(1D))), Arr(((V)((BZ1_999 + 7.4))), ((V)(0.6)), ((V)(0.97))), Arr(((V)((BZ1_999 + 9.4))), ((V)(3D)), ((V)(0.82))))).Put("col", (Truthy(gold_985) ? ((V)("#1f4f3e")) : Call(shade_21, V.Undef, pc_1132, ((V)(1.08))))).V)));
}
return o_1131;
return default;
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1158, int _argc1150, V p_1156, V s_1157, V _a1154, V _a1155, V[] _rest1151) => {
return Call(tex_59, V.Undef, s_1157, pats_1007);
}, 2, "wrap", true)).V, NewObj(2).Put("build", Fn((V _arrowThis1166, int _argc1159, V P_1165, V _a1162, V _a1163, V _a1164, V[] _rest1160) => {
return Call(arm_1013, V.Undef, P_1165, ((V)(1D)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1175, int _argc1167, V p_1173, V s_1174, V _a1171, V _a1172, V[] _rest1168) => {
V P_1176 = default;
V f_1177 = default;
V o_1178 = default;
P_1176 = Call(pal_1015, V.Undef);
f_1177 = Call(F_1005, V.Undef, P_1176);
o_1178 = Call(tex_59, V.Undef, s_1174, pats_1007);
if (!(Truthy(ch_984))) {
double h_1179 = 0;
h_1179 = (((rollY_1008 - rB_1010) - 0.6) - (RT_994 + 1.5));
o_1178 = ((V)(JsStrBuf.Begin().V(o_1178).S("<g transform=\"").V(Call(planeX_45, V.Undef, p_1173, ((V)(((Wd_991 / 2D) + 0.1))), ((V)(((rollY_1008 - rB_1010) - 0.6))), ((V)((z0_1012 + 1.5))))).S("\">").V(Call(tuft_63, V.Undef, ((V)(((ZF_1000 - z0_1012) - 3D))), ((V)(h_1179)), f_1177, Call(BT_1006, V.Undef, P_1176), NewObj(1).Put("cell", ((V)(13D))).V)).S("</g><g transform=\"").V(Call(plane_44, V.Undef, p_1173, ((V)((ZF_1000 + 2.1))), ((V)(rollY_1008)), Call(rX_1011, V.Undef, ((V)(1D))))).S("\">").V(Call(pleats_65, V.Undef, ((V)((rA_1009 * 0.88))), ((V)((rB_1010 * 0.88))), f_1177, Call(BT_1006, V.Undef, P_1176))).S("</g>").End()));
}
if (Truthy(lea_986)) {
o_1178 = ((V)(JsStrBuf.Begin().V(o_1178).S("<g transform=\"").V(Call(plane_44, V.Undef, p_1173, ((V)((ZF_1000 + 0.25))), ((V)(0D)), ((V)(((Wd_991 / 2D) - (AW_990 / 2D)))))).S("\">").V(Call(nailRow_66, V.Undef, Arr(Arr(((V)((((-AW_990) / 2D) + 1.6))), ((V)((-(RT_994 + 1.5))))), Arr(((V)((((-AW_990) / 2D) + 1.6))), ((V)((-(rollY_1008 - rB_1010))))), Arr(((V)(((AW_990 / 2D) - 1.6))), ((V)((-(rollY_1008 - rB_1010))))), Arr(((V)(((AW_990 / 2D) - 1.6))), ((V)((-(RT_994 + 1.5)))))), ((V)(2.3)))).S("</g>").End()));
}
return o_1178;
return default;
}, 2, "wrap", true)).V));
Set(D_1014, "build", Fn((V _arrowThis1187, int _argc1180, V P_1186, V _a1183, V _a1184, V _a1185, V[] _rest1181) => {
V f_1188 = default;
V o_1189 = default;
f_1188 = Call(F_1005, V.Undef, P_1186);
o_1189 = Arr();
if (Truthy(mar_988)) {
Invoke(o_1189, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((Wd_991 + 8D))), ((V)((B0_993 - 3.2))), ((V)((Dp_992 + 6D))), mar_988, Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((B0_993 - 3.2))), ((V)(0D)), ((V)((Wd_991 + 1D))), ((V)(3D)), ((V)((Dp_992 - 1D))), GOLD_26, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)));
} else {
double lx_1190 = 0;
double lz_1191 = 0;
V L_1192 = default;
lx_1190 = ((Wd_991 / 2D) - 8D);
lz_1191 = ((Dp_992 / 2D) - 9D);
L_1192 = Arr(Arr(((V)((-lx_1190))), ((V)((-lz_1191)))), Arr(((V)(lx_1190)), ((V)((-lz_1191)))), Arr(((V)((-lx_1190))), ((V)(lz_1191))), Arr(((V)(lx_1190)), ((V)(lz_1191))));
if (GeN(n_983, 4D)) {
Invoke(L_1192, "push", Arr(((V)(0D)), ((V)(lz_1191))), Arr(((V)(0D)), ((V)((-lz_1191)))));
}
Invoke(L_1192, "forEach", Fn((V _arrowThis1204, int _argc1193, V _a1195, V _a1196, V _a1197, V _a1198, V[] _rest1194) => {
V x_1201 = default;
V z_1203 = default;
{ V _t1199 = ListOf(_a1195);
{ V _t1200 = GetIdx(_t1199, 0D);
x_1201 = _t1200; }
{ V _t1202 = GetIdx(_t1199, 1D);
z_1203 = _t1202; }
}
return Invoke(o_1189, "push", Call(ball_14, V.Undef, x_1201, ((V)(0.6)), z_1203, ((V)(4.2)), legc_1004, Object_assign(NewObj(3).Put("sy", ((V)(0.92))).Put("k", ((V)(6D))).Put("n", ((V)(14D))).V, (Truthy(gold_985) ? Call(mt_33, V.Undef, NewObj(1).Put("shine", ((V)(1D))).V) : Call(wd_34, V.Undef)))), Call(cyl_13, V.Undef, x_1201, ((V)(0D)), z_1203, ((V)(2.2)), ((V)(0.8)), ((V)("#1d140c")), NewObj(1).Put("n", ((V)(10D))).V), Call(cyl_13, V.Undef, x_1201, ((V)(7.8)), z_1203, ((V)(3.4)), ((V)((B0_993 - 7.8))), legc_1004, (Truthy(gold_985) ? Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(12D))).V) : Call(wd_34, V.Undef, NewObj(1).Put("n", ((V)(12D))).V))));
}, 1, "", true));
}
Invoke(o_1189, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(B0_993)), ((V)(0D)), ((V)(Wd_991)), ((V)((RT_994 - B0_993))), ((V)(Dp_992)), (Truthy(gold_985) ? GOLD_26 : f_1188), (Truthy(gold_985) ? Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(3D))).V) : Call(fb_36, V.Undef, NewObj(1).Put("r", ((V)(4D))).V))), Call(slabX_16, V.Undef, ((V)(0D)), ((V)((RT_994 - 1.6))), ((V)((ZF_1000 + 0.35))), ((V)((Wd_991 - 4D))), ((V)(1.6)), ((V)(1.4)), Call(shade_21, V.Undef, f_1188, ((V)(0.78))), Call(fb_36, V.Undef, NewObj(1).Put("r", ((V)(0.7))).V)));
Invoke(o_1189, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(RT_994)), ((V)(((BZ1_999 + ZF_1000) / 2D))), ((V)((xr_1003 - xl_1002))), ((V)((ST_995 - RT_994))), ((V)((ZF_1000 - BZ1_999))), Call(shade_21, V.Undef, f_1188, ((V)(0.86))), Call(fb_36, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(slabX_16, V.Undef, ((V)(0D)), ((V)((ST_995 - 1.2))), ((V)((ZF_1000 + 0.3))), ((V)(((xr_1003 - xl_1002) - 2D))), ((V)(1.2)), ((V)(1.2)), Call(shade_21, V.Undef, f_1188, ((V)(0.74))), Call(fb_36, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
return o_1189;
return default;
}, 1, "", true));
Set(D_1014, "fx", Fn((V _arrowThis1212, int _argc1205, V c_1211, V _a1208, V _a1209, V _a1210, V[] _rest1206) => {
V p_1213 = default;
V R_1214 = default;
JsStrBuf fr_1215 = null;
p_1213 = Get(c_1211, "p");
R_1214 = Call(rng_40, V.Undef, (Get(S_981, "nm") is var _t1216 && Truthy(_t1216) ? _t1216 : ((V)("ch"))));
fr_1215 = new JsStrBuf("");
if (Truthy(gold_985)) {
double h_1217 = 0;
double w_1218 = 0;
JsStrBuf s_1219 = null;
h_1217 = ((RT_994 - B0_993) - 2.4);
w_1218 = Wd_991;
s_1219 = new JsStrBuf("");
{
double u_1220 = 0;
u_1220 = 2D;
while (true) {
if (!((u_1220 < (w_1218 - 1D)))) break;
s_1219.S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)(u_1220)))).S("\" cy=\"1.1\" r=\"0.55\" fill=\"#fff1b0\"/><circle cx=\"").V(Call(f1_23, V.Undef, ((V)(u_1220)))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((h_1217 - 0.8))))).S("\" r=\"0.55\" fill=\"#fff1b0\"/>");
u_1220 = (u_1220 + 2.3);
}
}
{
double u_1222 = 0;
u_1222 = 6D;
while (true) {
if (!((u_1222 < (w_1218 - 6D)))) break;
if ((System.Math.Abs((u_1222 - (w_1218 / 2D))) < 14D)) {
goto _cont1223;
}
s_1219.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)(u_1222)))).S(" ").V(Call(f1_23, V.Undef, ((V)((h_1217 * 0.55))))).S("c2 -3.2 5 -3.2 6 0s-2 3 -3 1.2\" fill=\"none\" stroke=\"#9a6a14\" stroke-width=\"0.55\"/>");
_cont1223: ;
u_1222 = (u_1222 + 12D);
}
}
s_1219.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)(((w_1218 / 2D) - 11D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((h_1217 / 2D))))).S("C").V(Call(f1_23, V.Undef, ((V)(((w_1218 / 2D) - 6D))))).S(" -0.5 ").V(Call(f1_23, V.Undef, ((V)(((w_1218 / 2D) - 2D))))).S(" -0.5 ").V(Call(f1_23, V.Undef, ((V)((w_1218 / 2D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((h_1217 / 2D))))).S("C").V(Call(f1_23, V.Undef, ((V)(((w_1218 / 2D) + 2D))))).S(" -0.5 ").V(Call(f1_23, V.Undef, ((V)(((w_1218 / 2D) + 6D))))).S(" -0.5 ").V(Call(f1_23, V.Undef, ((V)(((w_1218 / 2D) + 11D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((h_1217 / 2D))))).S("C").V(Call(f1_23, V.Undef, ((V)(((w_1218 / 2D) + 6D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((h_1217 + 0.5))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((w_1218 / 2D) + 2D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((h_1217 + 0.5))))).S(" ").V(Call(f1_23, V.Undef, ((V)((w_1218 / 2D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((h_1217 / 2D))))).S("C").V(Call(f1_23, V.Undef, ((V)(((w_1218 / 2D) - 2D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((h_1217 + 0.5))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((w_1218 / 2D) - 6D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((h_1217 + 0.5))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((w_1218 / 2D) - 11D))))).S(" ").V(Call(f1_23, V.Undef, ((V)((h_1217 / 2D))))).S("Z\" fill=\"url(#p3gold)\" stroke=\"#9a6a14\" stroke-width=\"0.5\"/>");
fr_1215.S("<g transform=\"").V(Call(plane_44, V.Undef, p_1213, ((V)((ZF_1000 + 0.12))), ((V)((RT_994 - 1.8))), ((V)(((-Wd_991) / 2D))))).S("\">").S(s_1219.Str).S("</g>");
}
if (Truthy(lea_986)) {
fr_1215.S("<g transform=\"").V(Call(plane_44, V.Undef, p_1213, ((V)((ZF_1000 + 1.2))), ((V)(0D)), ((V)(0D)))).S("\">").V(Call(nailRow_66, V.Undef, Arr(Arr(((V)((((-Wd_991) / 2D) + 2D))), ((V)((-(RT_994 - 3.4))))), Arr(((V)(((Wd_991 / 2D) - 2D))), ((V)((-(RT_994 - 3.4)))))), ((V)(2.4)))).S("</g>");
}
if (Truthy(mar_988)) {
fr_1215.S("<g transform=\"").V(Call(plane_44, V.Undef, p_1213, ((V)(((Dp_992 / 2D) + 3.06))), ((V)((B0_993 - 3.4))), ((V)((((-Wd_991) / 2D) - 4D))))).S("\">").V(Call(veinsSVG_69, V.Undef, R_1214, ((V)((Wd_991 + 8D))), ((V)((B0_993 - 3.4))), ((V)(9D)))).S("<rect x=\"0\" y=\"0\" width=\"").V(Call(f1_23, V.Undef, ((V)((Wd_991 + 8D))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((B0_993 - 3.4))))).S("\" fill=\"url(#p3glass)\" opacity=\"0.5\"/></g>");
}
return NewObj(2).Put("defs", PATS_60).Put("front", ((V)(fr_1215.Str))).V;
return default;
}, 1, "", true));
return D_1014;
return default;
}, 1, "", true));
Set(N_24, "cloudPit", Fn((V _arrowThis1231, int _argc1224, V S_1230, V _a1227, V _a1228, V _a1229, V[] _rest1225) => {
V n_1232 = default;
double a0_1233 = 0;
double a1_1234 = 0;
double da_1235 = 0;
double RF_1236 = 0;
double RO_1237 = 0;
double RB_1238 = 0;
double zc_1239 = 0;
V F_1240 = default;
V Pp_1241 = default;
V wedge_1242 = default;
V wsol_1243 = default;
V puffR_1244 = default;
V mods_1245 = default;
V D_1246 = default;
n_1232 = (Get(S_1230, "n") is var _t1247 && Truthy(_t1247) ? _t1247 : ((V)(5D)));
a0_1233 = (PI_30 * 0.95);
a1_1234 = (PI_30 * 2.05);
da_1235 = ((a1_1234 - a0_1233) / ToNum(n_1232));
RF_1236 = 54D;
RO_1237 = 126D;
RB_1238 = 104D;
zc_1239 = ((RO_1237 - (FdLibm.Sin((PI_30 - a0_1233)) * RO_1237)) / 2D);
F_1240 = Fn((V _arrowThis1255, int _argc1248, V P_1254, V _a1251, V _a1252, V _a1253, V[] _rest1249) => {
return ((Get(P_1254, "c") is var _t1256 && !Truthy(_t1256) ? _t1256 : Get(Get(P_1254, "c"), "a")) is var _t1257 && Truthy(_t1257) ? _t1257 : Get(P_1254, "a"));
}, 1, "", true);
Pp_1241 = Fn((V _arrowThis1266, int _argc1258, V r_1264, V t_1265, V _a1262, V _a1263, V[] _rest1259) => {
return Arr(((V)((FdLibm.Cos(ToNum(t_1265)) * ToNum(r_1264)))), ((V)((zc_1239 + (FdLibm.Sin(ToNum(t_1265)) * ToNum(r_1264))))));
}, 2, "", true);
wedge_1242 = Fn((V _arrowThis1279, int _argc1267, V r0_1273, V r1_1274, V t0_1275, V t1_1276, V[] _rest1268) => {
double tm_1280 = 0;
V C_1281 = default;
V o_1282 = default;
double d1_1283 = 0;
double d0_1284 = 0;
V bz_1285 = default;
V arc_1286 = default;
V rc_1277 = default;
V m_1278 = default;
rc_1277 = (_argc1267 > 4 ? _rest1268[0] : V.Undef);
m_1278 = (_argc1267 > 5 ? _rest1268[1] : V.Undef);
tm_1280 = (ToNum(Add(t0_1275, t1_1276)) / 2D);
C_1281 = Call(Pp_1241, V.Undef, ((V)((ToNum(Add(r0_1273, r1_1274)) / 2D))), ((V)(tm_1280)));
o_1282 = Arr();
d1_1283 = (ToNum(rc_1277) / ToNum(r1_1274));
d0_1284 = (ToNum(rc_1277) / ToNum(r0_1273));
bz_1285 = Fn((V _arrowThis1296, int _argc1287, V a_1293, V k_1294, V b_1295, V _a1292, V[] _rest1288) => {
return Invoke(Arr(((V)(0.25)), ((V)(0.5)), ((V)(0.75))), "forEach", Fn((V _arrowThis1304, int _argc1297, V s_1303, V _a1300, V _a1301, V _a1302, V[] _rest1298) => {
return Invoke(o_1282, "push", Arr(((V)((((((1D - ToNum(s_1303)) * (1D - ToNum(s_1303))) * ToNum(GetIdx(a_1293, 0D))) + (((2D * (1D - ToNum(s_1303))) * ToNum(s_1303)) * ToNum(GetIdx(k_1294, 0D)))) + ((ToNum(s_1303) * ToNum(s_1303)) * ToNum(GetIdx(b_1295, 0D)))))), ((V)((((((1D - ToNum(s_1303)) * (1D - ToNum(s_1303))) * ToNum(GetIdx(a_1293, 1D))) + (((2D * (1D - ToNum(s_1303))) * ToNum(s_1303)) * ToNum(GetIdx(k_1294, 1D)))) + ((ToNum(s_1303) * ToNum(s_1303)) * ToNum(GetIdx(b_1295, 1D))))))));
}, 1, "", true));
}, 3, "", true);
arc_1286 = Fn((V _arrowThis1314, int _argc1305, V r_1311, V ta_1312, V tb_1313, V _a1310, V[] _rest1306) => {
{
double i_1315 = 0;
i_1315 = 0D;
while (true) {
if (!(Le(((V)(i_1315)), m_1278))) break;
Invoke(o_1282, "push", Call(Pp_1241, V.Undef, r_1311, Add(ta_1312, ((V)((((ToNum(tb_1313) - ToNum(ta_1312)) * i_1315) / ToNum(m_1278)))))));
i_1315++;
}
}
return default;
}, 3, "", true);
Invoke(o_1282, "push", Call(Pp_1241, V.Undef, ((V)((ToNum(r1_1274) - ToNum(rc_1277)))), t0_1275));
Call(bz_1285, V.Undef, Call(Pp_1241, V.Undef, ((V)((ToNum(r1_1274) - ToNum(rc_1277)))), t0_1275), Call(Pp_1241, V.Undef, r1_1274, t0_1275), Call(Pp_1241, V.Undef, r1_1274, Add(t0_1275, ((V)(d1_1283)))));
Call(arc_1286, V.Undef, r1_1274, Add(t0_1275, ((V)(d1_1283))), ((V)((ToNum(t1_1276) - d1_1283))));
Call(bz_1285, V.Undef, Call(Pp_1241, V.Undef, r1_1274, ((V)((ToNum(t1_1276) - d1_1283)))), Call(Pp_1241, V.Undef, r1_1274, t1_1276), Call(Pp_1241, V.Undef, ((V)((ToNum(r1_1274) - ToNum(rc_1277)))), t1_1276));
Invoke(o_1282, "push", Call(Pp_1241, V.Undef, Add(r0_1273, rc_1277), t1_1276));
Call(bz_1285, V.Undef, Call(Pp_1241, V.Undef, Add(r0_1273, rc_1277), t1_1276), Call(Pp_1241, V.Undef, r0_1273, t1_1276), Call(Pp_1241, V.Undef, r0_1273, ((V)((ToNum(t1_1276) - d0_1284)))));
Call(arc_1286, V.Undef, r0_1273, ((V)((ToNum(t1_1276) - d0_1284))), Add(t0_1275, ((V)(d0_1284))));
Call(bz_1285, V.Undef, Call(Pp_1241, V.Undef, r0_1273, Add(t0_1275, ((V)(d0_1284)))), Call(Pp_1241, V.Undef, r0_1273, t0_1275), Call(Pp_1241, V.Undef, Add(r0_1273, rc_1277), t0_1275));
return NewObj(2).Put("c", C_1281).Put("pts", Invoke(o_1282, "map", Fn((V _arrowThis1324, int _argc1317, V p_1323, V _a1320, V _a1321, V _a1322, V[] _rest1318) => {
return Arr(((V)((ToNum(GetIdx(p_1323, 0D)) - ToNum(GetIdx(C_1281, 0D))))), ((V)((ToNum(GetIdx(p_1323, 1D)) - ToNum(GetIdx(C_1281, 1D))))));
}, 1, "", true))).V;
return default;
}, 6, "", true);
wsol_1243 = Fn((V _arrowThis1335, int _argc1325, V W_1331, V rings_1332, V col_1333, V o_1334, V[] _rest1326) => {
return Call(solid_11, V.Undef, Object_assign(NewObj(6).Put("ax", ((V)("y"))).Put("sh", ((V)("poly"))).Put("c", Get(W_1331, "c")).Put("pts", Get(W_1331, "pts")).Put("rings", rings_1332).Put("col", col_1333).V, o_1334));
}, 4, "", true);
puffR_1244 = Fn((V _arrowThis1345, int _argc1336, V y0_1342, V y1_1343, V top_1344, V _a1341, V[] _rest1337) => {
return Arr(Arr(y0_1342, ((V)(0D)), ((V)(0.95))), Arr(Add(y0_1342, ((V)(3D))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(y1_1343) - (Truthy(top_1344) ? 7D : 5D)))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(y1_1343) - (Truthy(top_1344) ? 3D : 2D)))), ((V)(0D)), ((V)((Truthy(top_1344) ? 0.94 : 0.97)))), Arr(y1_1343, ((V)(0D)), ((V)((Truthy(top_1344) ? 0.8 : 0.88)))));
}, 3, "", true);
mods_1245 = Call(rep_38, V.Undef, n_1232, Fn((V _arrowThis1353, int _argc1346, V i_1352, V _a1349, V _a1350, V _a1351, V[] _rest1347) => {
return NewObj(3).Put("t0", ((V)((a0_1233 + (da_1235 * ToNum(i_1352)))))).Put("t1", ((V)((a0_1233 + (da_1235 * ToNum(Add(i_1352, ((V)(1D))))))))).Put("t", ((V)((a0_1233 + (da_1235 * ToNum(Add(i_1352, ((V)(0.5))))))))).V;
}, 1, "", true));
D_1246 = NewObj(4).Put("w", ((V)(((RO_1237 * 2D) + 4D)))).Put("d", ((V)(((RO_1237 + (FdLibm.Sin((PI_30 - a0_1233)) * RO_1237)) + 4D)))).Put("act", ((V)("sit"))).Put("seats", Invoke(mods_1245, "map", Fn((V _arrowThis1361, int _argc1354, V m_1360, V _a1357, V _a1358, V _a1359, V[] _rest1355) => {
V q_1362 = default;
q_1362 = Call(Pp_1241, V.Undef, ((V)(80D)), Get(m_1360, "t"));
return NewObj(4).Put("x", GetIdx(q_1362, 0D)).Put("z", GetIdx(q_1362, 1D)).Put("h", ((V)(26D))).Put("f", ((V)(((FdLibm.Atan2((-FdLibm.Cos(ToNum(Get(m_1360, "t")))), (-FdLibm.Sin(ToNum(Get(m_1360, "t"))))) * 180D) / PI_30)))).V;
return default;
}, 1, "", true))).V;
Set(D_1246, "build", Fn((V _arrowThis1370, int _argc1363, V P_1369, V _a1366, V _a1367, V _a1368, V[] _rest1364) => {
V f_1371 = default;
V sc_1372 = default;
V bc_1373 = default;
V o_1374 = default;
V backs_1375 = default;
f_1371 = Call(F_1240, V.Undef, P_1369);
sc_1372 = Call(mix_22, V.Undef, f_1371, ((V)("#ffffff")), ((V)(0.06)));
bc_1373 = Call(shade_21, V.Undef, f_1371, ((V)(0.97)));
o_1374 = Arr();
backs_1375 = Arr();
Invoke(mods_1245, "forEach", Fn((V _arrowThis1383, int _argc1376, V m_1382, V _a1379, V _a1380, V _a1381, V[] _rest1377) => {
Invoke(o_1374, "push", Call(wsol_1243, V.Undef, Call(wedge_1242, V.Undef, ((V)(60D)), ((V)(120D)), Add(Get(m_1382, "t0"), ((V)(0.012))), ((V)((ToNum(Get(m_1382, "t1")) - 0.012))), ((V)(4D)), ((V)(5D))), Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.97))), Arr(((V)(4.2)), ((V)(0D)), ((V)(1D))), Arr(((V)(5D)), ((V)(0D)), ((V)(0.98)))), ((V)("#3a332c")), Call(wd_34, V.Undef)));
Invoke(o_1374, "push", Call(wsol_1243, V.Undef, Call(wedge_1242, V.Undef, ((V)(RF_1236)), ((V)(RO_1237)), Get(m_1382, "t0"), Get(m_1382, "t1"), ((V)(9D)), ((V)(6D))), Call(puffR_1244, V.Undef, ((V)(5D)), ((V)(26D))), sc_1372, Call(fb_36, V.Undef)));
Invoke(Arr(((V)(0D)), ((V)(1D))), "forEach", Fn((V _arrowThis1391, int _argc1384, V h_1390, V _a1387, V _a1388, V _a1389, V[] _rest1385) => {
V b_1392 = default;
b_1392 = Call(wsol_1243, V.Undef, Call(wedge_1242, V.Undef, ((V)(RB_1238)), ((V)(RO_1237)), Add(Get(m_1382, "t0"), ((V)(((da_1235 * ToNum(h_1390)) / 2D)))), Add(Get(m_1382, "t0"), ((V)(((da_1235 * ToNum(Add(h_1390, ((V)(1D))))) / 2D)))), ((V)(6D)), ((V)(4D))), Call(puffR_1244, V.Undef, ((V)(26.1)), ((V)(55D)), ((V)(1D))), bc_1373, Call(fb_36, V.Undef));
Invoke(backs_1375, "push", b_1392);
Invoke(o_1374, "push", b_1392);
return default;
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((a0_1233 + (da_1235 * 0.28)))), GetIdx(backs_1375, 0D), ((V)("#b9a48a"))), Arr(((V)((a1_1234 - (da_1235 * 0.28)))), GetIdx(backs_1375, (ToNum(Get(backs_1375, "length")) - 1D)), ((V)("#c9a35a")))), "forEach", Fn((V _arrowThis1406, int _argc1393, V _a1395, V _a1396, V _a1397, V _a1398, V[] _rest1394) => {
V q_1407 = default;
V b_1408 = default;
V t_1401 = default;
V par_1403 = default;
V col_1405 = default;
{ V _t1399 = ListOf(_a1395);
{ V _t1400 = GetIdx(_t1399, 0D);
t_1401 = _t1400; }
{ V _t1402 = GetIdx(_t1399, 1D);
par_1403 = _t1402; }
{ V _t1404 = GetIdx(_t1399, 2D);
col_1405 = _t1404; }
}
q_1407 = Call(Pp_1241, V.Undef, ((V)(97D)), t_1401);
b_1408 = Call(ball_14, V.Undef, GetIdx(q_1407, 0D), ((V)(26.2)), GetIdx(q_1407, 1D), ((V)(10D)), col_1405, NewObj(6).Put("sx", ((V)(1.1))).Put("sy", ((V)(0.92))).Put("sz", ((V)(0.62))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).Put("yaw", Add(t_1401, ((V)((PI_30 / 2D))))).V);
Set(b_1408, "par", par_1403);
Set(b_1408, "fn", Arr(((V)((-FdLibm.Cos(ToNum(t_1401))))), ((V)(0D)), ((V)((-FdLibm.Sin(ToNum(t_1401)))))));
Invoke(o_1374, "push", b_1408);
return default;
}, 1, "", true));
return o_1374;
return default;
}, 1, "", true));
Set(D_1246, "fx", Fn((V _arrowThis1415, int _argc1409, V _a1411, V _a1412, V _a1413, V _a1414, V[] _rest1410) => {
return NewObj(1).Put("defs", PATS_60).V;
}, 0, "", true));
return D_1246;
return default;
}, 1, "", true));
Set(N_24, "vipPods", Fn((V _arrowThis1423, int _argc1416, V S_1422, V _a1419, V _a1420, V _a1421, V[] _rest1417) => {
V n_1424 = default;
double PW_1425 = 0;
double CW_1426 = 0;
double Wd_1427 = 0;
V xs_1428 = default;
V cxs_1429 = default;
V SHL_1430 = default;
V GUN_1431 = default;
V CY_1432 = default;
V F_1433 = default;
V u_1434 = default;
V nv_1435 = default;
V S0_1436 = default;
V S1_1437 = default;
V add_1438 = default;
V D_1439 = default;
V pod_1440 = default;
V con_1441 = default;
n_1424 = (Get(S_1422, "n") is var _t1442 && Truthy(_t1442) ? _t1442 : ((V)(3D)));
PW_1425 = 62D;
CW_1426 = 13D;
Wd_1427 = ((ToNum(n_1424) * PW_1425) + (ToNum(Add(n_1424, ((V)(1D)))) * CW_1426));
xs_1428 = Call(rep_38, V.Undef, n_1424, Fn((V _arrowThis1450, int _argc1443, V i_1449, V _a1446, V _a1447, V _a1448, V[] _rest1444) => {
return ((V)((((((-Wd_1427) / 2D) + CW_1426) + (PW_1425 / 2D)) + (ToNum(i_1449) * (PW_1425 + CW_1426)))));
}, 1, "", true));
cxs_1429 = Call(rep_38, V.Undef, Add(n_1424, ((V)(1D))), Fn((V _arrowThis1458, int _argc1451, V i_1457, V _a1454, V _a1455, V _a1456, V[] _rest1452) => {
return ((V)(((((-Wd_1427) / 2D) + (CW_1426 / 2D)) + (ToNum(i_1457) * (PW_1425 + CW_1426)))));
}, 1, "", true));
SHL_1430 = ((V)("#e9ebee"));
GUN_1431 = ((V)("#2a2d34"));
CY_1432 = ((V)("#4fe0ff"));
F_1433 = Fn((V _arrowThis1466, int _argc1459, V P_1465, V _a1462, V _a1463, V _a1464, V[] _rest1460) => {
return ((Get(P_1465, "c") is var _t1467 && !Truthy(_t1467) ? _t1467 : Get(Get(P_1465, "c"), "a")) is var _t1468 && Truthy(_t1468) ? _t1468 : ((V)("#2a2a30")));
}, 1, "", true);
u_1434 = Arr(((V)((-0.433))), ((V)(0.9)));
nv_1435 = Arr(((V)(0.9)), ((V)(0.433)));
S0_1436 = Arr(((V)((-26D))), ((V)(34D)));
S1_1437 = Arr(((V)((-52D))), ((V)(88D)));
add_1438 = Fn((V _arrowThis1478, int _argc1469, V a_1475, V b_1476, V k_1477, V _a1474, V[] _rest1470) => {
return Arr(Add(GetIdx(a_1475, 0D), ((V)((ToNum(GetIdx(b_1476, 0D)) * ToNum(k_1477))))), Add(GetIdx(a_1475, 1D), ((V)((ToNum(GetIdx(b_1476, 1D)) * ToNum(k_1477))))));
}, 3, "", true);
D_1439 = NewObj(4).Put("w", ((V)((Wd_1427 + 8D)))).Put("d", ((V)(132D))).Put("act", ((V)("sit"))).Put("seats", Invoke(xs_1428, "map", Fn((V _arrowThis1486, int _argc1479, V x_1485, V _a1482, V _a1483, V _a1484, V[] _rest1480) => {
return NewObj(3).Put("x", x_1485).Put("z", ((V)(2D))).Put("h", ((V)(44D))).V;
}, 1, "", true))).V;
Set(D_1439, "build", Fn((V _arrowThis1494, int _argc1487, V P_1493, V _a1490, V _a1491, V _a1492, V[] _rest1488) => {
V o_1495 = default;
o_1495 = Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)((Wd_1427 + 6D))), ((V)(4D)), ((V)(122D)), ((V)("#1c1d22")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(1.4)), ((V)(65.2)), ((V)((Wd_1427 + 2D))), ((V)(1.2)), ((V)(0.8)), CY_1432, Call(em_25, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
Invoke(xs_1428, "forEach", Fn((V _arrowThis1503, int _argc1496, V x_1502, V _a1499, V _a1500, V _a1501, V[] _rest1497) => {
Invoke(o_1495, "push", Call(cyl_13, V.Undef, x_1502, ((V)(4D)), ((V)((-4D))), ((V)(22D)), ((V)(5D)), GUN_1431, Call(mt_33, V.Undef, NewObj(2).Put("rz", ((V)(17D))).Put("n", ((V)(24D))).V)), Call(cyl_13, V.Undef, x_1502, ((V)(9D)), ((V)((-4D))), ((V)(19D)), ((V)(0.8)), CY_1432, Call(em_25, V.Undef, NewObj(2).Put("rz", ((V)(14.6))).Put("n", ((V)(24D))).V)));
Invoke(Arr(Arr(((V)((-12D))), ((V)((-14D)))), Arr(((V)(12D)), ((V)((-14D)))), Arr(((V)(0D)), ((V)(8D)))), "forEach", Fn((V _arrowThis1515, int _argc1504, V _a1506, V _a1507, V _a1508, V _a1509, V[] _rest1505) => {
V dx_1512 = default;
V dz_1514 = default;
{ V _t1510 = ListOf(_a1506);
{ V _t1511 = GetIdx(_t1510, 0D);
dx_1512 = _t1511; }
{ V _t1513 = GetIdx(_t1510, 1D);
dz_1514 = _t1513; }
}
return Invoke(o_1495, "push", Call(cyl_13, V.Undef, Add(x_1502, dx_1512), ((V)(9.8)), Add(((V)((-4D))), dz_1514), ((V)(2.5)), ((V)(11D)), CH_27, Call(mt_33, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, Add(x_1502, dx_1512), ((V)(12.6)), Add(((V)((-4D))), dz_1514), ((V)(3.3)), ((V)(2.4)), ((V)("#16171b")), NewObj(1).Put("n", ((V)(10D))).V));
}, 1, "", true));
return default;
}, 1, "", true));
return o_1495;
return default;
}, 1, "", true));
pod_1440 = Fn((V _arrowThis1524, int _argc1516, V x_1522, V i_1523, V _a1520, V _a1521, V[] _rest1517) => {
return NewObj(2).Put("build", Fn((V _arrowThis1532, int _argc1525, V P_1531, V _a1528, V _a1529, V _a1530, V[] _rest1526) => {
V L_1533 = default;
V LL_1534 = default;
V o_1535 = default;
double hw_1536 = 0;
V H_1537 = default;
L_1533 = Call(F_1433, V.Undef, P_1531);
LL_1534 = Call(mix_22, V.Undef, L_1533, ((V)("#ffffff")), ((V)(0.08)));
o_1535 = Arr();
hw_1536 = (PW_1425 / 2D);
Invoke(o_1535, "push", Call(box_12, V.Undef, x_1522, ((V)(20D)), ((V)((-2D))), ((V)((PW_1425 - 8D))), ((V)(13D)), ((V)(54D)), SHL_1430, Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(9D))).V)), Call(box_12, V.Undef, x_1522, ((V)(21D)), ((V)(25D)), ((V)((PW_1425 - 12D))), ((V)(1D)), ((V)(1D)), CY_1432, Call(em_25, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
Invoke(o_1535, "push", Call(prism_19, V.Undef, ((V)(((ToNum(x_1522) - hw_1536) + 7D))), ((V)((ToNum(Add(x_1522, ((V)(hw_1536)))) - 7D))), Arr(Arr(((V)((-25D))), ((V)(33D))), Arr(((V)(25D)), ((V)(36D))), Arr(((V)(25D)), ((V)(44.5))), Arr(((V)((-25D))), ((V)(41.5)))), LL_1534, NewObj(2).Put("soft", ((V)(1D))).Put("mat", ((V)("paint"))).V));
Invoke(o_1535, "push", Call(prism_19, V.Undef, ((V)(((ToNum(x_1522) - hw_1536) + 3D))), ((V)((ToNum(Add(x_1522, ((V)(hw_1536)))) - 3D))), Arr(Call(add_1438, V.Undef, S0_1436, nv_1435, ((V)((-5D)))), Call(add_1438, V.Undef, S1_1437, nv_1435, ((V)((-5D)))), S1_1437, S0_1436), SHL_1430, Call(cer_35, V.Undef)), Call(prism_19, V.Undef, ((V)(((ToNum(x_1522) - hw_1536) + 8D))), ((V)((ToNum(Add(x_1522, ((V)(hw_1536)))) - 8D))), Arr(S0_1436, S1_1437, Call(add_1438, V.Undef, S1_1437, nv_1435, ((V)(8D))), Call(add_1438, V.Undef, S0_1436, nv_1435, ((V)(8D)))), L_1533, NewObj(2).Put("soft", ((V)(1D))).Put("mat", ((V)("paint"))).V));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1545, int _argc1538, V sg_1544, V _a1541, V _a1542, V _a1543, V[] _rest1539) => {
return Invoke(o_1535, "push", Call(prism_19, V.Undef, ((V)((ToNum(Add(x_1522, ((V)((ToNum(sg_1544) * (hw_1536 - 8D)))))) - (GtN(sg_1544, 0D) ? 0D : 3.4)))), Add(Add(x_1522, ((V)((ToNum(sg_1544) * (hw_1536 - 8D))))), ((V)((GtN(sg_1544, 0D) ? 3.4 : 0D)))), Arr(Call(add_1438, V.Undef, S0_1436, nv_1435, ((V)(0.4))), Call(add_1438, V.Undef, S1_1437, nv_1435, ((V)(0.4))), Call(add_1438, V.Undef, S1_1437, nv_1435, ((V)(11D))), Call(add_1438, V.Undef, S0_1436, nv_1435, ((V)(11D)))), Call(shade_21, V.Undef, L_1533, ((V)(0.9))), NewObj(2).Put("soft", ((V)(1D))).Put("mat", ((V)("paint"))).V));
}, 1, "", true));
H_1537 = Call(add_1438, V.Undef, Call(add_1438, V.Undef, S1_1437, nv_1435, ((V)(11D))), u_1434, ((V)((-9D))));
Invoke(o_1535, "push", Call(ball_14, V.Undef, x_1522, ((V)((ToNum(GetIdx(H_1537, 1D)) - 5.5))), GetIdx(H_1537, 0D), ((V)(13D)), LL_1534, NewObj(7).Put("sx", ((V)(1.25))).Put("sy", ((V)(0.5))).Put("sz", ((V)(0.55))).Put("soft", ((V)(1D))).Put("mat", ((V)("paint"))).Put("k", ((V)(6D))).Put("n", ((V)(16D))).V));
Invoke(o_1535, "push", Call(prism_19, V.Undef, ((V)(((ToNum(x_1522) - hw_1536) + 7D))), ((V)((ToNum(Add(x_1522, ((V)(hw_1536)))) - 7D))), Arr(Arr(((V)(22D)), ((V)(30D))), Arr(((V)(60D)), ((V)(37D))), Arr(((V)(61D)), ((V)(40D))), Arr(((V)(22D)), ((V)(34D)))), SHL_1430, Call(cer_35, V.Undef)), Call(prism_19, V.Undef, ((V)(((ToNum(x_1522) - hw_1536) + 8D))), ((V)((ToNum(Add(x_1522, ((V)(hw_1536)))) - 8D))), Arr(Arr(((V)(24D)), ((V)(34.5))), Arr(((V)(61D)), ((V)(40.5))), Arr(((V)(61D)), ((V)(48D))), Arr(((V)(24D)), ((V)(43.5)))), LL_1534, NewObj(2).Put("soft", ((V)(1D))).Put("mat", ((V)("paint"))).V), Call(box_12, V.Undef, x_1522, ((V)(38D)), ((V)(63.4)), ((V)((PW_1425 - 18D))), ((V)(2.4)), ((V)(2.4)), CH_27, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1553, int _argc1546, V sg_1552, V _a1549, V _a1550, V _a1551, V[] _rest1547) => {
V ax_1554 = default;
ax_1554 = Add(x_1522, ((V)((ToNum(sg_1552) * (hw_1536 - 3.5)))));
Invoke(o_1535, "push", Call(box_12, V.Undef, ax_1554, ((V)(30D)), ((V)((-6D))), ((V)(7D)), ((V)(19D)), ((V)(54D)), SHL_1430, Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ax_1554, ((V)(49D)), ((V)((-6D))), ((V)(8D)), ((V)(3D)), ((V)(52D)), L_1533, NewObj(3).Put("r", ((V)(1.5))).Put("soft", ((V)(1D))).Put("mat", ((V)("paint"))).V), Call(slab_15, V.Undef, ax_1554, ((V)(38D)), ((V)(21.4)), ((V)(5D)), ((V)(6D)), ((V)(0.6)), ((V)("#0e1a24")), NewObj(1).Put("r", ((V)(1D))).V), Call(slab_15, V.Undef, ax_1554, ((V)(39D)), ((V)(21.9)), ((V)(3.6)), ((V)(4D)), ((V)(0.3)), CY_1432, Call(em_25, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
return default;
}, 1, "", true));
return o_1535;
return default;
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1563, int _argc1555, V p_1561, V s_1562, V _a1559, V _a1560, V[] _rest1556) => {
V L_1564 = default;
V q_1565 = default;
double w_1566 = 0;
V O_1567 = default;
V cl_1568 = default;
JsStrBuf ch_1569 = null;
V pm_1570 = default;
L_1564 = Call(F_1433, V.Undef, Invoke(X_9, "pal", D_1439, ((V)(0D))));
q_1565 = Call(p_1561, V.Undef, x_1522, ((V)(20D)), ((V)((-2D))));
w_1566 = (PW_1425 - 16D);
O_1567 = Call(add_1438, V.Undef, Call(add_1438, V.Undef, S1_1437, nv_1435, ((V)(8.1))), u_1434, ((V)((-0.5))));
cl_1568 = Call(clipR_62, V.Undef, ((V)(w_1566)), ((V)(46D)), ((V)(3D)));
ch_1569 = new JsStrBuf("");
Call(rep_38, V.Undef, ((V)(7D)), Fn((V _arrowThis1578, int _argc1571, V j_1577, V _a1574, V _a1575, V _a1576, V[] _rest1572) => {
double v_1579 = 0;
v_1579 = (5D + (ToNum(j_1577) * 6D));
ch_1569.S("<path d=\"M0 ").N(v_1579).S("H").N(w_1566).S("\" stroke=\"").V(Call(shade_21, V.Undef, L_1564, ((V)(0.5)))).S("\" stroke-width=\"0.7\"/><path d=\"M0 ").N((v_1579 + 0.7)).S("H").N(w_1566).S("\" stroke=\"#ffffff\" stroke-opacity=\"0.16\" stroke-width=\"0.45\"/><path d=\"M1 ").N((v_1579 - 1.6)).S("H").N((w_1566 - 1D)).S("\" stroke=\"").V(Call(shade_21, V.Undef, L_1564, ((V)(1.6)))).S("\" stroke-opacity=\"0.35\" stroke-width=\"0.25\" stroke-dasharray=\"1 0.8\"/>");
return default;
}, 1, "", true));
pm_1570 = Call(mtx_43, V.Undef, Call(p_1561, V.Undef, ((V)((ToNum(x_1522) - (w_1566 / 2D)))), GetIdx(O_1567, 1D), GetIdx(O_1567, 0D)), Call(p_1561, V.Undef, ((V)(((ToNum(x_1522) - (w_1566 / 2D)) + 1D))), GetIdx(O_1567, 1D), GetIdx(O_1567, 0D)), Call(p_1561, V.Undef, ((V)((ToNum(x_1522) - (w_1566 / 2D)))), ((V)((ToNum(GetIdx(O_1567, 1D)) - ToNum(GetIdx(u_1434, 1D))))), ((V)((ToNum(GetIdx(O_1567, 0D)) - ToNum(GetIdx(u_1434, 0D)))))));
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(atS_55, V.Undef, ((V)("rotate")), ((V)(JsStrBuf.Begin().S("0 ").V(Call(P2_42, V.Undef, q_1565)).S(";-1.3 ").V(Call(P2_42, V.Undef, q_1565)).S(";0.9 ").V(Call(P2_42, V.Undef, q_1565)).S(";-0.5 ").V(Call(P2_42, V.Undef, q_1565)).S(";0 ").V(Call(P2_42, V.Undef, q_1565)).End())), ((V)(4.6)), ((V)(((-ToNum(i_1523)) * 1.3))))).V(Call(tex_59, V.Undef, s_1562, Arr(Arr(((V)("p3lea")), ((V)(0.85))), Arr(((V)("p3vel")), ((V)(0.8)))))).S("<g transform=\"").V(pm_1570).S("\"><defs>").V(Get(cl_1568, "d")).S("</defs><g clip-path=\"url(#").V(Get(cl_1568, "id")).S(")\">").S(ch_1569.Str).S("</g></g></g>").End()));
return default;
}, 2, "wrap", true)).V;
}, 2, "", true);
con_1441 = Fn((V _arrowThis1587, int _argc1580, V cx_1586, V _a1583, V _a1584, V _a1585, V[] _rest1581) => {
return NewObj(1).Put("build", Fn((V _arrowThis1595, int _argc1588, V P_1594, V _a1591, V _a1592, V _a1593, V[] _rest1589) => {
V L_1596 = default;
L_1596 = Call(F_1433, V.Undef, P_1594);
return Arr(Call(box_12, V.Undef, cx_1586, ((V)(4D)), ((V)((-6D))), ((V)((CW_1426 - 1.5))), ((V)(46D)), ((V)(70D)), GUN_1431, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, cx_1586, ((V)(50D)), ((V)((-6D))), ((V)(CW_1426)), ((V)(3D)), ((V)(72D)), L_1596, NewObj(3).Put("r", ((V)(2D))).Put("soft", ((V)(1D))).Put("mat", ((V)("paint"))).V), Call(arcW_17, V.Undef, cx_1586, ((V)(53D)), ((V)(16D)), ((V)(4.2)), ((V)(4.2)), ((V)(1D)), ((V)(0.8)), ((V)(0D)), ((V)((2D * PI_30))), CH_27, Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(cyl_13, V.Undef, cx_1586, ((V)(53D)), ((V)(16D)), ((V)(3.3)), ((V)(11D)), ((V)("#d9363b")), Call(pt_37, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(11D)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_13, V.Undef, cx_1586, ((V)(64D)), ((V)(16D)), ((V)(3.5)), ((V)(1D)), ((V)("#ffffff")), NewObj(1).Put("n", ((V)(14D))).V), Call(cyl_13, V.Undef, Add(cx_1586, ((V)(1D))), ((V)(65D)), ((V)(16D)), ((V)(0.45)), ((V)(6D)), ((V)("#ffffff")), NewObj(1).Put("n", ((V)(4D))).V), Call(slab_15, V.Undef, cx_1586, ((V)(38D)), ((V)(29.4)), ((V)((CW_1426 - 4D))), ((V)(8D)), ((V)(0.6)), ((V)("#0e1a24")), NewObj(1).Put("r", ((V)(1D))).V), Call(slab_15, V.Undef, cx_1586, ((V)(39.2)), ((V)(29.9)), ((V)((CW_1426 - 6D))), ((V)(5.6)), ((V)(0.3)), CY_1432, Call(em_25, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, cx_1586, ((V)(5D)), ((V)(29.2)), ((V)((CW_1426 - 3D))), ((V)(1D)), ((V)(0.6)), CY_1432, Call(em_25, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
return default;
}, 1, "build", true)).V;
}, 1, "", true);
Set(D_1439, "layers", Arr());
Invoke(cxs_1429, "forEach", Fn((V _arrowThis1605, int _argc1597, V cx_1603, V i_1604, V _a1601, V _a1602, V[] _rest1598) => {
Invoke(Get(D_1439, "layers"), "push", Call(con_1441, V.Undef, cx_1603));
if (Lt(i_1604, n_1424)) {
Invoke(Get(D_1439, "layers"), "push", Call(pod_1440, V.Undef, GetK(xs_1428, i_1604), i_1604));
}
return default;
}, 2, "", true));
Set(D_1439, "fx", Fn((V _arrowThis1613, int _argc1606, V c_1612, V _a1609, V _a1610, V _a1611, V[] _rest1607) => {
V p_1614 = default;
JsStrBuf un_1615 = null;
V tick_1616 = default;
p_1614 = Get(c_1612, "p");
un_1615 = new JsStrBuf("");
Invoke(xs_1428, "forEach", Fn((V _arrowThis1625, int _argc1617, V x_1623, V i_1624, V _a1621, V _a1622, V[] _rest1618) => {
return ((V)(un_1615.S("<g transform=\"").V(Call(planeH_46, V.Undef, p_1614, ((V)(4.2)), x_1623, ((V)((-4D))))).S("\"><ellipse rx=\"34\" ry=\"30\" fill=\"#4fe0ff\" opacity=\"0.12\">").V(Call(anS_52, V.Undef, ((V)("opacity")), ((V)("0.06;0.22;0.06")), ((V)(2.3)), ((V)(((-ToNum(i_1624)) * 0.7))))).S("</ellipse></g>").Str));
}, 2, "", true));
tick_1616 = Invoke(Invoke(xs_1428, "map", Fn((V _arrowThis1634, int _argc1626, V x_1632, V i_1633, V _a1630, V _a1631, V[] _rest1627) => {
V q_1635 = default;
q_1635 = Call(p_1614, V.Undef, ((V)((ToNum(x_1632) - 9D))), ((V)(40.2)), ((V)(22D)));
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_1635, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(q_1635, 1D))).S("\" r=\"0.6\" fill=\"#ffffff\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("1;0.2;1")), ((V)(1.2)), ((V)(((-ToNum(i_1633)) * 0.4))))).S("</circle>").End()));
return default;
}, 2, "", true)), "join", ((V)("")));
return NewObj(3).Put("defs", PATS_60).Put("under", ((V)(un_1615.Str))).Put("front", tick_1616).V;
return default;
}, 1, "", true));
return D_1439;
return default;
}, 1, "", true));
Set(N_24, "qHolo", Fn((V _arrowThis1643, int _argc1636, V S_1642, V _a1639, V _a1640, V _a1641, V[] _rest1637) => {
V G_1644 = default;
V CY_1645 = default;
V NODES_1646 = default;
V SAT_1647 = default;
V D_1648 = default;
G_1644 = ((V)("#2b2e36"));
CY_1645 = ((V)("#7ff0ff"));
NODES_1646 = Arr(Arr(((V)((-22D))), ((V)((-16D)))), Arr(((V)(22D)), ((V)((-16D)))), Arr(((V)((-22D))), ((V)(16D))), Arr(((V)(22D)), ((V)(16D))));
SAT_1647 = Call(rep_38, V.Undef, ((V)(3D)), Fn((V _arrowThis1656, int _argc1649, V i_1655, V _a1652, V _a1653, V _a1654, V[] _rest1650) => {
double a_1657 = 0;
a_1657 = ((PI_30 / 2D) + (((ToNum(i_1655) * 2D) * PI_30) / 3D));
return Arr(((V)((FdLibm.Cos(a_1657) * 19D))), ((V)((FdLibm.Sin(a_1657) * 19D))));
return default;
}, 1, "", true));
D_1648 = NewObj(3).Put("w", ((V)(86D))).Put("d", ((V)(80D))).Put("glow", Fn((V _arrowThis1664, int _argc1658, V _a1660, V _a1661, V _a1662, V _a1663, V[] _rest1659) => {
return NewObj(3).Put("y", ((V)(80D))).Put("r", ((V)(62D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).V;
Set(D_1648, "build", Fn((V _arrowThis1672, int _argc1665, V P_1671, V _a1668, V _a1669, V _a1670, V[] _rest1666) => {
V o_1673 = default;
o_1673 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(37D)), ((V)(3D)), ((V)("#1c1d22")), Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(37D)), ((V)(37D)), ((V)(1.4)), ((V)(0.8)), ((V)(0D)), ((V)((2D * PI_30))), CY_1645, Call(em_25, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
Invoke(NODES_1646, "forEach", Fn((V _arrowThis1685, int _argc1674, V _a1676, V _a1677, V _a1678, V _a1679, V[] _rest1675) => {
V x_1682 = default;
V z_1684 = default;
{ V _t1680 = ListOf(_a1676);
{ V _t1681 = GetIdx(_t1680, 0D);
x_1682 = _t1681; }
{ V _t1683 = GetIdx(_t1680, 1D);
z_1684 = _t1683; }
}
return Invoke(o_1673, "push", Call(cyl_13, V.Undef, x_1682, ((V)(3D)), z_1684, ((V)(6D)), ((V)(7D)), G_1644, Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(cyl_13, V.Undef, x_1682, ((V)(10D)), z_1684, ((V)(6.3)), ((V)(0.9)), CY_1645, Call(em_25, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(cyl_13, V.Undef, x_1682, ((V)(10.9)), z_1684, ((V)(2.6)), ((V)(6D)), CH_27, Call(mt_33, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
return o_1673;
return default;
}, 1, "", true));
Set(D_1648, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1693, int _argc1686, V P_1692, V _a1689, V _a1690, V _a1691, V[] _rest1687) => {
V o_1694 = default;
o_1694 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(0D)), ((V)(32D)), ((V)(5.6)), G_1644, Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(21.6)), ((V)(0D)), ((V)(32.8)), ((V)(1D)), CH_27, Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(22.6)), ((V)(0D)), ((V)(24D)), ((V)(2.4)), ((V)("#1a1c22")), Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(25D)), ((V)(0D)), ((V)(24D)), ((V)(24D)), ((V)(1.2)), ((V)(0.8)), ((V)(0D)), ((V)((2D * PI_30))), CY_1645, Call(em_25, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(25D)), ((V)(0D)), ((V)(10D)), ((V)(9D)), ((V)("#23252c")), Call(mt_33, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.1))), Arr(((V)(9D)), ((V)(0D)), ((V)(0.9))))).V)));
Invoke(Arr(((V)(34D)), ((V)(37D)), ((V)(40D))), "forEach", Fn((V _arrowThis1703, int _argc1695, V y_1701, V i_1702, V _a1699, V _a1700, V[] _rest1696) => {
return Invoke(o_1694, "push", Call(cyl_13, V.Undef, ((V)(0D)), y_1701, ((V)(0D)), ((V)((8.6 - (ToNum(i_1702) * 1.2)))), ((V)(2D)), ((V)("#bfefff")), Call(cer_35, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("op", ((V)(0.55))).V)), Call(cyl_13, V.Undef, ((V)(0D)), Add(y_1701, ((V)(2D))), ((V)(0D)), ((V)((6.4 - ToNum(i_1702)))), ((V)(1D)), CH_27, Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)));
}, 2, "", true));
Invoke(o_1694, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(43D)), ((V)(0D)), ((V)(5.4)), ((V)("#dffaff")), Call(cer_35, V.Undef, NewObj(3).Put("sy", ((V)(0.6))).Put("op", ((V)(0.7))).Put("n", ((V)(16D))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(43.8)), ((V)(0D)), ((V)(2.6)), CY_1645, Call(em_25, V.Undef, NewObj(1).Put("k", ((V)(4D))).V)));
Invoke(SAT_1647, "forEach", Fn((V _arrowThis1715, int _argc1704, V _a1706, V _a1707, V _a1708, V _a1709, V[] _rest1705) => {
V x_1712 = default;
V z_1714 = default;
{ V _t1710 = ListOf(_a1706);
{ V _t1711 = GetIdx(_t1710, 0D);
x_1712 = _t1711; }
{ V _t1713 = GetIdx(_t1710, 1D);
z_1714 = _t1713; }
}
return Invoke(o_1694, "push", Call(cyl_13, V.Undef, x_1712, ((V)(25D)), z_1714, ((V)(3.6)), ((V)(8D)), G_1644, Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_13, V.Undef, x_1712, ((V)(33D)), z_1714, ((V)(3.9)), ((V)(1.2)), CH_27, Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(ball_14, V.Undef, x_1712, ((V)(34.2)), z_1714, ((V)(2.3)), CY_1645, Call(em_25, V.Undef, NewObj(1).Put("k", ((V)(3D))).V)));
}, 1, "", true));
return o_1694;
return default;
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1724, int _argc1716, V p_1722, V s_1723, V _a1720, V _a1721, V[] _rest1717) => {
V k_1725 = default;
V q_1726 = default;
V a_1727 = default;
V b_1728 = default;
V pl_1729 = default;
double w0_1730 = 0;
double w1_1731 = 0;
double R_1732 = 0;
JsStrBuf h_1733 = null;
k_1725 = Call(kOf_47, V.Undef, p_1722);
q_1726 = Call(p_1722, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(0D)));
a_1727 = Call(p_1722, V.Undef, ((V)(0D)), ((V)(47D)), ((V)(0D)));
b_1728 = Call(p_1722, V.Undef, ((V)(0D)), ((V)(112D)), ((V)(0D)));
pl_1729 = Call(p_1722, V.Undef, ((V)(0D)), ((V)(82D)), ((V)(0D)));
w0_1730 = (5D * ToNum(k_1725));
w1_1731 = (34D * ToNum(k_1725));
R_1732 = (14D * ToNum(k_1725));
h_1733 = new JsStrBuf("");
h_1733.S("<path d=\"M").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(a_1727, 0D)) - w0_1730))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(a_1727, 1D))).S("L").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(b_1728, 0D)) - w1_1731))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(b_1728, 1D))).S("L").V(Call(f1_23, V.Undef, Add(GetIdx(b_1728, 0D), ((V)(w1_1731))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(b_1728, 1D))).S("L").V(Call(f1_23, V.Undef, Add(GetIdx(a_1727, 0D), ((V)(w0_1730))))).S(" ").V(Call(f1_23, V.Undef, GetIdx(a_1727, 1D))).S("Z\" fill=\"url(#qcone)\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.75;1;0.8;0.95;0.75")), ((V)(2.2)))).S("</path>");
Invoke(SAT_1647, "forEach", Fn((V _arrowThis1746, int _argc1734, V _a1736, V i_1740, V _a1738, V _a1739, V[] _rest1735) => {
V e_1747 = default;
V x_1743 = default;
V z_1745 = default;
{ V _t1741 = ListOf(_a1736);
{ V _t1742 = GetIdx(_t1741, 0D);
x_1743 = _t1742; }
{ V _t1744 = GetIdx(_t1741, 1D);
z_1745 = _t1744; }
}
e_1747 = Call(p_1722, V.Undef, x_1743, ((V)(36.5)), z_1745);
h_1733.S("<path d=\"M").V(Call(P2_42, V.Undef, e_1747)).S("L").V(Call(P2_42, V.Undef, pl_1729)).S("\" stroke=\"#bff8ff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.9 * ToNum(k_1725)))))).S("\" stroke-dasharray=\"").V(Call(f1_23, V.Undef, ((V)((3D * ToNum(k_1725)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(k_1725)))))).S("\" opacity=\"0.7\">").V(Call(an_51, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;-").V(Call(f1_23, V.Undef, ((V)((10D * ToNum(k_1725)))))).End())), ((V)(0.6)), ((V)(((-ToNum(i_1740)) * 0.2))))).S("</path>");
return default;
}, 2, "", true));
h_1733.S("<g transform=\"").V(Call(planeH_46, V.Undef, p_1722, ((V)(64D)))).S("\"><ellipse rx=\"27\" ry=\"27\" fill=\"none\" stroke=\"#8fe8ff\" stroke-width=\"4.4\" stroke-dasharray=\"5 1.4\" opacity=\"0.32\">").V(Call(an_51, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-64")), ((V)(5D)))).S("</ellipse><ellipse rx=\"27\" ry=\"27\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.7\" stroke-dasharray=\"1 1.6\" opacity=\"0.6\" transform=\"scale(1.07)\">").V(Call(an_51, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-52")), ((V)(5D)))).S("</ellipse><ellipse rx=\"27\" ry=\"27\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.7\" stroke-dasharray=\"1 1.6\" opacity=\"0.6\" transform=\"scale(0.93)\">").V(Call(an_51, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-52")), ((V)(5D)))).S("</ellipse></g>");
h_1733.S("<g transform=\"translate(").V(Call(P2_42, V.Undef, pl_1729)).S(")\"><g>").V(Call(atS_55, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;0 ").V(Call(f1_23, V.Undef, ((V)(((-3D) * ToNum(k_1725)))))).S(";0 0").End())), ((V)(3D)))).S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)(R_1732)))).S("\" fill=\"url(#qpl)\" stroke=\"#d8fbff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.5 * ToNum(k_1725)))))).S("\"/>");
Call(rep_38, V.Undef, ((V)(3D)), Fn((V _arrowThis1755, int _argc1748, V i_1754, V _a1751, V _a1752, V _a1753, V[] _rest1749) => {
return ((V)(h_1733.S("<ellipse rx=\"").V(Call(f1_23, V.Undef, ((V)(R_1732)))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(R_1732)))).S("\" fill=\"none\" stroke=\"#d8fbff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.35 * ToNum(k_1725)))))).S("\" opacity=\"0.7\">").V(Call(an_51, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)(R_1732)))).S(";").V(Call(f1_23, V.Undef, ((V)((R_1732 * 0.05))))).S(";").V(Call(f1_23, V.Undef, ((V)(R_1732)))).End())), ((V)(4.2)), ((V)(((-ToNum(i_1754)) * 1.4))))).S("</ellipse>").Str));
}, 1, "", true));
Invoke(Arr(((V)((-0.5))), ((V)(0D)), ((V)(0.5))), "forEach", Fn((V _arrowThis1763, int _argc1756, V t_1762, V _a1759, V _a1760, V _a1761, V[] _rest1757) => {
return ((V)(h_1733.S("<ellipse cy=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(t_1762) * R_1732))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((R_1732 * System.Math.Sqrt((1D - (ToNum(t_1762) * ToNum(t_1762))))))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)(((R_1732 * 0.22) * System.Math.Sqrt((1D - (ToNum(t_1762) * ToNum(t_1762))))))))).S("\" fill=\"none\" stroke=\"#d8fbff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.3 * ToNum(k_1725)))))).S("\" opacity=\"0.6\"/>").Str));
}, 1, "", true));
h_1733.S("<g transform=\"rotate(-14)\"><ellipse rx=\"").V(Call(f1_23, V.Undef, ((V)((R_1732 * 1.75))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((R_1732 * 0.42))))).S("\" fill=\"none\" stroke=\"#e8fdff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((1.2 * ToNum(k_1725)))))).S("\" stroke-dasharray=\"").V(Call(f1_23, V.Undef, ((V)((4D * ToNum(k_1725)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((1.5 * ToNum(k_1725)))))).S("\" opacity=\"0.8\">").V(Call(an_51, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;-").V(Call(f1_23, V.Undef, ((V)((40D * ToNum(k_1725)))))).End())), ((V)(3D)))).S("</ellipse><circle r=\"").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(k_1725)))))).S("\" fill=\"#ffffff\"><animateMotion dur=\"4s\" repeatCount=\"indefinite\" path=\"M").V(Call(f1_23, V.Undef, ((V)((R_1732 * 1.75))))).S(" 0A").V(Call(f1_23, V.Undef, ((V)((R_1732 * 1.75))))).S(" ").V(Call(f1_23, V.Undef, ((V)((R_1732 * 0.42))))).S(" 0 1 1 ").V(Call(f1_23, V.Undef, ((V)(((-R_1732) * 1.75))))).S(" 0A").V(Call(f1_23, V.Undef, ((V)((R_1732 * 1.75))))).S(" ").V(Call(f1_23, V.Undef, ((V)((R_1732 * 0.42))))).S(" 0 1 1 ").V(Call(f1_23, V.Undef, ((V)((R_1732 * 1.75))))).S(" 0\"/></circle></g>");
Call(rep_38, V.Undef, ((V)(6D)), Fn((V _arrowThis1771, int _argc1764, V i_1770, V _a1767, V _a1768, V _a1769, V[] _rest1765) => {
return ((V)(h_1733.S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)((-R_1732))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)(((-R_1732) + ((ToNum(i_1770) * R_1732) / 3D)))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((2D * R_1732))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((0.4 * ToNum(k_1725)))))).S("\" fill=\"#ffffff\" opacity=\"0.25\">").V(Call(an_51, V.Undef, ((V)("y")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((-R_1732))))).S(";").V(Call(f1_23, V.Undef, ((V)(R_1732)))).End())), ((V)(2.4)), ((V)(((-ToNum(i_1770)) * 0.4))))).S("</rect>").Str));
}, 1, "", true));
h_1733.S("</g></g>");
Call(rep_38, V.Undef, ((V)(10D)), Fn((V _arrowThis1779, int _argc1772, V i_1778, V _a1775, V _a1776, V _a1777, V[] _rest1773) => {
double x_1780 = 0;
double z_1781 = 0;
V e0_1782 = default;
V e1_1783 = default;
V d_1784 = default;
x_1780 = (((ToNum(i_1778) % 5D) - 2D) * 9D);
z_1781 = (NumTruthy((ToNum(i_1778) % 2D)) ? 6D : (-6D));
e0_1782 = Call(p_1722, V.Undef, ((V)(x_1780)), ((V)(48D)), ((V)(z_1781)));
e1_1783 = Call(p_1722, V.Undef, ((V)((x_1780 * 1.6))), ((V)(110D)), ((V)(z_1781)));
d_1784 = Invoke(((V)((2.4 + ((ToNum(i_1778) % 3D) * 0.5)))), "toFixed", ((V)(1D)));
h_1733.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(e0_1782, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(e0_1782, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.7 * ToNum(k_1725)))))).S("\" fill=\"#e8fdff\">").V(Call(an_51, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(e0_1782, 1D))).S(";").V(Call(f1_23, V.Undef, GetIdx(e1_1783, 1D))).End())), d_1784, ((V)(((-ToNum(i_1778)) * 0.37))))).V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0;1;0")), d_1784, ((V)(((-ToNum(i_1778)) * 0.37))))).S("</circle>");
return default;
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(atS_55, V.Undef, ((V)("rotate")), ((V)(JsStrBuf.Begin().S("0 ").V(Call(P2_42, V.Undef, q_1726)).S(";-1.6 ").V(Call(P2_42, V.Undef, q_1726)).S(";1.2 ").V(Call(P2_42, V.Undef, q_1726)).S(";-0.8 ").V(Call(P2_42, V.Undef, q_1726)).S(";0 ").V(Call(P2_42, V.Undef, q_1726)).End())), ((V)(3.6)))).V(Call(atS_55, V.Undef, ((V)("translate")), ((V)("0 0;0 -1.2;0 0.4;0 -0.8;0 0")), ((V)(3.6)))).V(s_1723).S(h_1733.Str).S("</g>").End()));
return default;
}, 2, "wrap", true)).V));
Set(D_1648, "fx", Fn((V _arrowThis1792, int _argc1785, V c_1791, V _a1788, V _a1789, V _a1790, V[] _rest1786) => {
V p_1793 = default;
V k_1794 = default;
JsStrBuf un_1795 = null;
JsStrBuf f_1796 = null;
V top_1797 = default;
V l_1798 = default;
V r_1799 = default;
p_1793 = Get(c_1791, "p");
k_1794 = Get(c_1791, "k");
un_1795 = new JsStrBuf("");
f_1796 = new JsStrBuf("");
Invoke(NODES_1646, "forEach", Fn((V _arrowThis1812, int _argc1800, V _a1802, V i_1806, V _a1804, V _a1805, V[] _rest1801) => {
V x_1809 = default;
V z_1811 = default;
{ V _t1807 = ListOf(_a1802);
{ V _t1808 = GetIdx(_t1807, 0D);
x_1809 = _t1808; }
{ V _t1810 = GetIdx(_t1807, 1D);
z_1811 = _t1810; }
}
un_1795.S("<g transform=\"").V(Call(planeH_46, V.Undef, p_1793, ((V)(3.2)), x_1809, z_1811)).S("\">").V(Invoke(Call(rep_38, V.Undef, ((V)(2D)), Fn((V _arrowThis1820, int _argc1813, V j_1819, V _a1816, V _a1817, V _a1818, V[] _rest1814) => {
return ((V)(JsStrBuf.Begin().S("<ellipse rx=\"6\" ry=\"6\" fill=\"none\" stroke=\"#7ff0ff\" stroke-width=\"0.8\">").V(Call(an_51, V.Undef, ((V)("rx")), ((V)("6;18")), ((V)(2D)), ((V)((((-ToNum(i_1806)) * 0.5) - ToNum(j_1819)))))).V(Call(an_51, V.Undef, ((V)("ry")), ((V)("6;18")), ((V)(2D)), ((V)((((-ToNum(i_1806)) * 0.5) - ToNum(j_1819)))))).V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.8;0")), ((V)(2D)), ((V)((((-ToNum(i_1806)) * 0.5) - ToNum(j_1819)))))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
Call(rep_38, V.Undef, ((V)(2D)), Fn((V _arrowThis1828, int _argc1821, V j_1827, V _a1824, V _a1825, V _a1826, V[] _rest1822) => {
V e_1829 = default;
e_1829 = Call(p_1793, V.Undef, x_1809, ((V)(10D)), z_1811);
f_1796.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(e_1829, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(e_1829, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((2.2 * ToNum(k_1794)))))).S("\" fill=\"#ffffff\" opacity=\"0\">").V(Call(an_51, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(e_1829, 1D))).S(";").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(e_1829, 1D)) - (22D * ToNum(k_1794))))))).End())), ((V)(3D)), ((V)((((-ToNum(i_1806)) * 0.8) - (ToNum(j_1827) * 1.5)))))).V(Call(an_51, V.Undef, ((V)("r")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(k_1794)))))).S(";").V(Call(f1_23, V.Undef, ((V)((5D * ToNum(k_1794)))))).End())), ((V)(3D)), ((V)((((-ToNum(i_1806)) * 0.8) - (ToNum(j_1827) * 1.5)))))).V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0;0.35;0")), ((V)(3D)), ((V)((((-ToNum(i_1806)) * 0.8) - (ToNum(j_1827) * 1.5)))))).S("</circle>");
return default;
}, 1, "", true));
return default;
}, 2, "", true));
top_1797 = Call(p_1793, V.Undef, ((V)(0D)), ((V)(116D)), ((V)(0D)));
l_1798 = Call(p_1793, V.Undef, ((V)((-40D))), ((V)(60D)), ((V)(0D)));
r_1799 = Call(p_1793, V.Undef, ((V)(40D)), ((V)(60D)), ((V)(0D)));
return NewObj(4).Put("defs", ((V)("<linearGradient id=\"qcone\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8fe8ff\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#8fe8ff\" stop-opacity=\"0.02\"/></linearGradient><radialGradient id=\"qpl\" cx=\"38%\" cy=\"32%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#e8fdff\" stop-opacity=\"0.85\"/><stop offset=\"0.6\" stop-color=\"#6fd8ff\" stop-opacity=\"0.45\"/><stop offset=\"1\" stop-color=\"#3a8fd8\" stop-opacity=\"0.25\"/></radialGradient>"))).Put("under", ((V)(un_1795.Str))).Put("front", ((V)(f_1796.Str))).Put("bb", Call(bbOf_57, V.Undef, Arr(top_1797, l_1798, r_1799), ((V)(6D)))).V;
return default;
}, 1, "", true));
return D_1648;
return default;
}, 1, "", true));
Set(N_24, "reelSculpt", Fn((V _arrowThis1837, int _argc1830, V S_1836, V _a1833, V _a1834, V _a1835, V[] _rest1831) => {
V RL_1838 = default;
V D_1839 = default;
RL_1838 = Arr(Arr(((V)((-30D))), ((V)(46D)), ((V)(21D)), ((V)(7D))), Arr(((V)(30D)), ((V)(58D)), ((V)(16D)), ((V)((-5.5)))));
D_1839 = NewObj(5).Put("w", ((V)(124D))).Put("d", ((V)(14D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(46D))).Put("glow", Fn((V _arrowThis1846, int _argc1840, V _a1842, V _a1843, V _a1844, V _a1845, V[] _rest1841) => {
return NewObj(3).Put("y", ((V)(52D))).Put("r", ((V)(70D))).Put("c", ((V)("url(#gNeon)"))).V;
}, 0, "glow", true)).V;
Set(D_1839, "build", Fn((V _arrowThis1854, int _argc1847, V P_1853, V _a1850, V _a1851, V _a1852, V[] _rest1848) => {
return new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-4D))), ((V)(116D)), ((V)(5D)), ((V)(6D)), ((V)("#23252e")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(2D))).V))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(1.4)), ((V)((-0.7))), ((V)(108D)), ((V)(1.4)), ((V)(0.6)), ((V)("#8fe8ff")), Call(em_25, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V))).Spread(Invoke(Arr(((V)((-44D))), ((V)(44D))), "map", Fn((V _arrowThis1862, int _argc1855, V x_1861, V _a1858, V _a1859, V _a1860, V[] _rest1856) => {
return Call(cyl_13, V.Undef, x_1861, ((V)(5D)), ((V)((-4D))), ((V)(2D)), ((V)(1.2)), CH_27, Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(10D))).V));
}, 1, "", true))).V;
}, 1, "", true));
Set(D_1839, "fx", Fn((V _arrowThis1870, int _argc1863, V c_1869, V _a1866, V _a1867, V _a1868, V[] _rest1864) => {
V p_1871 = default;
JsStrBuf f_1872 = null;
V fs_1873 = default;
p_1871 = Get(c_1869, "p");
f_1872 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_44, V.Undef, p_1871, ((V)(2D)), ((V)(0D)))).S("\">").End());
f_1872.S("<path d=\"M-56 -5L-70 -96H70L56 -5Z\" fill=\"url(#rbeam)\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.5;0.9;0.5")), ((V)(3D)))).S("</path>");
Invoke(RL_1838, "forEach", Fn((V _arrowThis1890, int _argc1874, V _a1876, V i_1880, V _a1878, V _a1879, V[] _rest1875) => {
V cx_1891 = default;
double cy_1892 = 0;
V ho_1893 = default;
V x_1883 = default;
V y_1885 = default;
V r_1887 = default;
V d_1889 = default;
{ V _t1881 = ListOf(_a1876);
{ V _t1882 = GetIdx(_t1881, 0D);
x_1883 = _t1882; }
{ V _t1884 = GetIdx(_t1881, 1D);
y_1885 = _t1884; }
{ V _t1886 = GetIdx(_t1881, 2D);
r_1887 = _t1886; }
{ V _t1888 = GetIdx(_t1881, 3D);
d_1889 = _t1888; }
}
cx_1891 = x_1883;
cy_1892 = (-ToNum(y_1885));
ho_1893 = Invoke(Call(rep_38, V.Undef, ((V)(5D)), Fn((V _arrowThis1901, int _argc1894, V j_1900, V _a1897, V _a1898, V _a1899, V[] _rest1895) => {
double a_1902 = 0;
a_1902 = (((ToNum(j_1900) * 2D) * PI_30) / 5D);
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_23, V.Undef, ((V)(((FdLibm.Cos(a_1902) * ToNum(r_1887)) * 0.55))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((FdLibm.Sin(a_1902) * ToNum(r_1887)) * 0.55))))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(r_1887) * 0.22))))).S("\" fill=\"#06222e\" fill-opacity=\"0.55\" stroke=\"#e8fdff\" stroke-width=\"0.6\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
f_1872.S("<g transform=\"translate(").V(cx_1891).S(" ").N(cy_1892).S(")\"><g>").V(Call(atS_55, V.Undef, ((V)("translate")), ((V)("0 0;0 -3;0 0")), ((V)(3.4)), ((V)(((-ToNum(i_1880)) * 1.2))))).S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(r_1887) * 1.25))))).S("\" fill=\"#8fe8ff\" opacity=\"0.25\" filter=\"url(#rbl)\">").V(Call(anS_52, V.Undef, ((V)("opacity")), ((V)("0.15;0.45;0.15")), ((V)(2.4)), ((V)((-ToNum(i_1880)))))).S("</circle><g>").V(Call(at_54, V.Undef, ((V)("rotate")), ((V)((GtN(d_1889, 0D) ? "0;360" : "360;0"))), ((V)(System.Math.Abs(ToNum(d_1889)))))).S("<circle r=\"").V(r_1887).S("\" fill=\"url(#rdisc)\" stroke=\"#e8fdff\" stroke-width=\"1.4\"/><circle r=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(r_1887) - 2.4))))).S("\" fill=\"none\" stroke=\"#8fe8ff\" stroke-width=\"0.6\" stroke-dasharray=\"1.6 1.2\"/>").V(ho_1893).S("<circle r=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(r_1887) * 0.16))))).S("\" fill=\"#e8fdff\"/><circle r=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(r_1887) * 0.07))))).S("\" fill=\"#06222e\"/></g>").S("<ellipse cx=\"").V(Call(f1_23, V.Undef, ((V)(((-ToNum(r_1887)) * 0.35))))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)(((-ToNum(r_1887)) * 0.4))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(r_1887) * 0.35))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(r_1887) * 0.18))))).S("\" fill=\"#ffffff\" opacity=\"0.35\" transform=\"rotate(-30)\"/></g></g>");
return default;
}, 2, "", true));
fs_1873 = ((V)("M-30 -25C-6 -16 4 -84 30 -74C48 -66 52 -38 30 -42"));
f_1872.S("<path d=\"").V(fs_1873).S("\" fill=\"none\" stroke=\"#8fe8ff\" stroke-width=\"5.2\" opacity=\"0.35\"/><path d=\"").V(fs_1873).S("\" fill=\"none\" stroke=\"#e8fdff\" stroke-width=\"5.2\" stroke-dasharray=\"4.4 1\" opacity=\"0.28\">").V(Call(an_51, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-21")), ((V)(1.4)))).S("</path><path d=\"").V(fs_1873).S("\" fill=\"none\" stroke=\"#06222e\" stroke-width=\"0.9\" stroke-dasharray=\"0.9 1.3\" transform=\"translate(0 1.8)\" opacity=\"0.7\">").V(Call(an_51, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-22")), ((V)(1.4)))).S("</path><path d=\"").V(fs_1873).S("\" fill=\"none\" stroke=\"#06222e\" stroke-width=\"0.9\" stroke-dasharray=\"0.9 1.3\" transform=\"translate(0 -1.8)\" opacity=\"0.7\">").V(Call(an_51, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-22")), ((V)(1.4)))).S("</path>");
Call(rep_38, V.Undef, ((V)(8D)), Fn((V _arrowThis1910, int _argc1903, V i_1909, V _a1906, V _a1907, V _a1908, V[] _rest1904) => {
return ((V)(f_1872.S("<circle cx=\"").N(((-50D) + (ToNum(i_1909) * 14D))).S("\" cy=\"-8\" r=\"0.8\" fill=\"#e8fdff\">").V(Call(an_51, V.Undef, ((V)("cy")), ((V)("-8;-90")), ((V)((3D + ((ToNum(i_1909) % 3D) * 0.6)))), ((V)(((-ToNum(i_1909)) * 0.5))))).V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0;1;0")), ((V)((3D + ((ToNum(i_1909) % 3D) * 0.6)))), ((V)(((-ToNum(i_1909)) * 0.5))))).S("</circle>").Str));
}, 1, "", true));
f_1872.S("</g>");
return NewObj(3).Put("defs", ((V)(JsStrBuf.Begin().V(Call(BLUR_56, V.Undef, ((V)("rbl")), ((V)(3D)))).S("<linearGradient id=\"rbeam\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8fe8ff\" stop-opacity=\"0.3\"/><stop offset=\"1\" stop-color=\"#8fe8ff\" stop-opacity=\"0\"/></linearGradient><radialGradient id=\"rdisc\" cx=\"40%\" cy=\"35%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#e8fdff\" stop-opacity=\"0.75\"/><stop offset=\"1\" stop-color=\"#3ab8e8\" stop-opacity=\"0.35\"/></radialGradient>").End()))).Put("front", ((V)(f_1872.Str))).Put("bb", Call(bbOf_57, V.Undef, Arr(Call(p_1871, V.Undef, ((V)((-72D))), ((V)(100D)), ((V)(2D))), Call(p_1871, V.Undef, ((V)(72D)), ((V)(100D)), ((V)(2D))), Call(p_1871, V.Undef, ((V)((-72D))), ((V)(0D)), ((V)(2D))), Call(p_1871, V.Undef, ((V)(72D)), ((V)(0D)), ((V)(2D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1839;
return default;
}, 1, "", true));
NF_70 = NewObj(7).Put("N", ((V)("M0 10V0L6 10V0"))).Put("O", ((V)("M3 0C6.8 0 6.8 10 3 10C-0.8 10 -0.8 0 3 0Z"))).Put("W", ((V)("M0 0L1.6 10L3 3.6L4.4 10L6 0"))).Put("S", ((V)("M5.8 1.7C5 0.4 4 0 3 0C1.1 0 0.1 1.1 0.1 2.6C0.1 5.2 6 4.6 6 7.5C6 9 4.8 10 3 10C1.8 10 0.6 9.4 0 8.2"))).Put("H", ((V)("M0 0V10M6 0V10M0 5H6"))).Put("I", ((V)("M1 0V10"))).Put("G", ((V)("M5.8 1.9C5.1 0.6 4.1 0 3 0C0.8 0 0 2.4 0 5C0 7.6 0.8 10 3 10C5 10 6 8.6 6 6.6V5.8H3.4"))).V;
word_71 = Fn((V _arrowThis1922, int _argc1911, V str_1917, V x_1918, V y_1919, V s_1920, V[] _rest1912) => {
JsStrBuf o_1923 = null;
V cx_1924 = default;
V W_1925 = default;
V tot_1926 = default;
V gap_1921 = default;
gap_1921 = (_argc1911 > 4 ? _rest1912[0] : V.Undef);
o_1923 = new JsStrBuf("");
cx_1924 = ((V)(0D));
W_1925 = Fn((V _arrowThis1934, int _argc1927, V ch_1933, V _a1930, V _a1931, V _a1932, V[] _rest1928) => {
return ((V)((SEqS(ch_1933, "I") ? 2D : 6D)));
}, 1, "", true);
tot_1926 = Invoke(Invoke(str_1917, "split", ((V)(""))), "reduce", Fn((V _arrowThis1943, int _argc1935, V a_1941, V ch_1942, V _a1939, V _a1940, V[] _rest1936) => {
return Add(Add(a_1941, Call(W_1925, V.Undef, ch_1942)), gap_1921);
}, 2, "", true), ((V)((-ToNum(gap_1921)))));
cx_1924 = ((V)(((-ToNum(tot_1926)) / 2D)));
Invoke(Invoke(str_1917, "split", ((V)(""))), "forEach", Fn((V _arrowThis1951, int _argc1944, V ch_1950, V _a1947, V _a1948, V _a1949, V[] _rest1945) => {
o_1923.S("<path d=\"").V(GetK(NF_70, ch_1950)).S("\" transform=\"translate(").V(Call(f1_23, V.Undef, cx_1924)).S(" 0)\"/>");
cx_1924 = Add(cx_1924, Add(Call(W_1925, V.Undef, ch_1950), gap_1921));
return default;
}, 1, "", true));
return NewObj(2).Put("g", ((V)(o_1923.Str))).Put("t", ((V)(JsStrBuf.Begin().S("translate(").V(x_1918).S(" ").V(y_1919).S(") scale(").V(s_1920).S(")").End()))).V;
return default;
}, 5, "", true);
tube_72 = Fn((V _arrowThis1963, int _argc1952, V g_1958, V t_1959, V col_1960, V s_1961, V[] _rest1953) => {
V extra_1962 = default;
extra_1962 = (_argc1952 > 4 ? _rest1953[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<g transform=\"").V(t_1959).S("\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\">").V((extra_1962 is var _t1964 && Truthy(_t1964) ? _t1964 : ((V)("")))).S("<g stroke=\"").V(col_1960).S("\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((3.6 / ToNum(s_1961)))))).S("\" opacity=\"0.55\" filter=\"url(#nbl)\">").V(g_1958).S("</g><g stroke=\"").V(col_1960).S("\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((1.7 / ToNum(s_1961)))))).S("\">").V(g_1958).S("</g><g stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.6 / ToNum(s_1961)))))).S("\" opacity=\"0.85\">").V(g_1958).S("</g></g>").End()));
}, 5, "", true);
Set(N_24, "neonShow", Fn((V _arrowThis1972, int _argc1965, V S_1971, V _a1968, V _a1969, V _a1970, V[] _rest1966) => {
return NewObj(7).Put("w", ((V)(124D))).Put("d", ((V)(10D))).Put("mount", ((V)("wall"))).Put("elev", ((V)(50D))).Put("glow", Fn((V _arrowThis1979, int _argc1973, V _a1975, V _a1976, V _a1977, V _a1978, V[] _rest1974) => {
return NewObj(3).Put("y", ((V)(32D))).Put("r", ((V)(76D))).Put("c", ((V)("url(#npink)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis1987, int _argc1980, V P_1986, V _a1983, V _a1984, V _a1985, V[] _rest1981) => {
return new ArrBuilder().Add(Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-1.5))), ((V)(116D)), ((V)(64D)), ((V)(3D)), ((V)("#1c1a2a")), Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(6D))).V))).Add(Call(slab_15, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0.3)), ((V)(110D)), ((V)(60D)), ((V)(0.6)), ((V)("#14121e")), Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(5D))).V))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)((-6D))), ((V)((-2D))), ((V)(22D)), ((V)(6D)), ((V)(4D)), ((V)("#4a4c52")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).Spread(Invoke(Arr(Arr(((V)((-50D))), ((V)(6D))), Arr(((V)(50D)), ((V)(6D))), Arr(((V)((-50D))), ((V)(58D))), Arr(((V)(50D)), ((V)(58D)))), "map", Fn((V _arrowThis1999, int _argc1988, V _a1990, V _a1991, V _a1992, V _a1993, V[] _rest1989) => {
V x_1996 = default;
V y_1998 = default;
{ V _t1994 = ListOf(_a1990);
{ V _t1995 = GetIdx(_t1994, 0D);
x_1996 = _t1995; }
{ V _t1997 = GetIdx(_t1994, 1D);
y_1998 = _t1997; }
}
return Call(disc_18, V.Undef, x_1996, y_1998, ((V)(0.6)), ((V)(1.4)), ((V)(1.6)), CH_27, Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(10D))).V));
}, 1, "", true))).V;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2007, int _argc2000, V c_2006, V _a2003, V _a2004, V _a2005, V[] _rest2001) => {
V p_2008 = default;
JsStrBuf f_2009 = null;
V A_2010 = default;
V Bw_2011 = default;
p_2008 = Get(c_2006, "p");
f_2009 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_44, V.Undef, p_2008, ((V)(1.2)), ((V)(64D)))).S("\">").End());
f_2009.V(Call(tube_72, V.Undef, ((V)("<rect x=\"-52\" y=\"5\" width=\"104\" height=\"54\" rx=\"7\" stroke-dasharray=\"40 1.4 30 1.4 70 1.4 50 1.4\"/>")), ((V)("")), ((V)("#ffb347")), ((V)(1D)), ((V)(""))));
A_2010 = Call(word_71, V.Undef, ((V)("NOW")), ((V)(0D)), ((V)(13D)), ((V)(1.6)), ((V)(2.4)));
Bw_2011 = Call(word_71, V.Undef, ((V)("SHOWING")), ((V)(0D)), ((V)(37D)), ((V)(1.2)), ((V)(1.8)));
f_2009.S("<g>").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("1;1;0.25;1;0.5;1;1")), ((V)(4.6)), ((V)(0D)), ((V)("0;0.62;0.64;0.66;0.69;0.72;1")))).V(Call(tube_72, V.Undef, Get(A_2010, "g"), Get(A_2010, "t"), ((V)("#ff4fa3")), ((V)(1.6)))).S("</g>");
f_2009.S("<g>").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.92;1;0.95;1;0.92")), ((V)(0.18)))).V(Call(tube_72, V.Undef, Get(Bw_2011, "g"), Get(Bw_2011, "t"), ((V)("#4fe8ff")), ((V)(1.2)))).S("</g>");
f_2009.V(Call(tube_72, V.Undef, ((V)("<path d=\"M-40 31H-24M24 31H40M-36 28L-40 31L-36 34M36 28L40 31L36 34\"/>")), ((V)("")), ((V)("#ffd66b")), ((V)(1D))));
Invoke(Arr(Arr(((V)((-30D))), ((V)(22D))), Arr(((V)(30D)), ((V)(22D))), Arr(((V)((-44D))), ((V)(47D))), Arr(((V)(44D)), ((V)(47D))), Arr(((V)((-10D))), ((V)(52D))), Arr(((V)(10D)), ((V)(52D)))), "forEach", Fn((V _arrowThis2023, int _argc2012, V _a2014, V _a2015, V _a2016, V _a2017, V[] _rest2013) => {
V x_2020 = default;
V y_2022 = default;
{ V _t2018 = ListOf(_a2014);
{ V _t2019 = GetIdx(_t2018, 0D);
x_2020 = _t2019; }
{ V _t2021 = GetIdx(_t2018, 1D);
y_2022 = _t2021; }
}
return ((V)(f_2009.S("<rect x=\"").N((ToNum(x_2020) - 1.2)).S("\" y=\"").N((ToNum(y_2022) - 0.6)).S("\" width=\"2.4\" height=\"1.2\" rx=\"0.3\" fill=\"#8a8d94\"/>").Str));
}, 1, "", true));
f_2009.S("</g>");
return NewObj(2).Put("defs", ((V)(JsStrBuf.Begin().V(Call(BLUR_56, V.Undef, ((V)("nbl")), ((V)(1.3)))).S("<radialGradient id=\"npink\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#ff6ab8\" stop-opacity=\"0.45\"/><stop offset=\"0.6\" stop-color=\"#4fe8ff\" stop-opacity=\"0.12\"/><stop offset=\"1\" stop-color=\"#4fe8ff\" stop-opacity=\"0\"/></radialGradient>").End()))).Put("front", ((V)(f_2009.Str))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "sphereAudio", Fn((V _arrowThis2031, int _argc2024, V S_2030, V _a2027, V _a2028, V _a2029, V[] _rest2025) => {
V SP_2032 = default;
V D_2033 = default;
V yb_2034 = default;
SP_2032 = Arr(Arr(((V)((-46D))), ((V)(12D)), ((V)(13D)), ((V)(0.6))), Arr(((V)(0D)), ((V)((-4D))), ((V)(20D)), ((V)(0D))), Arr(((V)(46D)), ((V)(12D)), ((V)(13D)), ((V)(1.3))));
D_2033 = NewObj(2).Put("w", ((V)(140D))).Put("d", ((V)(70D))).V;
Set(D_2033, "build", Fn((V _arrowThis2042, int _argc2035, V P_2041, V _a2038, V _a2039, V _a2040, V[] _rest2036) => {
V o_2043 = default;
o_2043 = Arr();
Invoke(SP_2032, "forEach", Fn((V _arrowThis2057, int _argc2044, V _a2046, V _a2047, V _a2048, V _a2049, V[] _rest2045) => {
V x_2052 = default;
V z_2054 = default;
V r_2056 = default;
{ V _t2050 = ListOf(_a2046);
{ V _t2051 = GetIdx(_t2050, 0D);
x_2052 = _t2051; }
{ V _t2053 = GetIdx(_t2050, 1D);
z_2054 = _t2053; }
{ V _t2055 = GetIdx(_t2050, 2D);
r_2056 = _t2055; }
}
return Invoke(o_2043, "push", Call(cyl_13, V.Undef, x_2052, ((V)(0D)), z_2054, Add(r_2056, ((V)(4D))), ((V)(3D)), ((V)("#121318")), Call(cer_35, V.Undef, NewObj(1).Put("n", ((V)(22D))).V)), Call(cyl_13, V.Undef, x_2052, ((V)(3D)), z_2054, Add(r_2056, ((V)(1D))), ((V)(3.4)), ((V)("#1d1f26")), Call(mt_33, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(3.4)), ((V)(0D)), ((V)(0.82))))).V)), Call(arcW_17, V.Undef, x_2052, ((V)(6.4)), z_2054, ((V)((ToNum(r_2056) * 0.75))), ((V)((ToNum(r_2056) * 0.75))), ((V)(1.1)), ((V)(0.7)), ((V)(0D)), ((V)((2D * PI_30))), ((V)("#6ac8ff")), Call(em_25, V.Undef, NewObj(1).Put("n", ((V)(22D))).V)), Call(cyl_13, V.Undef, x_2052, ((V)(6.4)), z_2054, ((V)((ToNum(r_2056) * 0.4))), ((V)(0.6)), ((V)("#2c2f38")), Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)));
}, 1, "", true));
return o_2043;
return default;
}, 1, "", true));
yb_2034 = Fn((V _arrowThis2065, int _argc2058, V r_2064, V _a2061, V _a2062, V _a2063, V[] _rest2059) => {
return ((V)(((7D + 12D) + (GtN(r_2064, 15D) ? 3D : 0D))));
}, 1, "", true);
Set(D_2033, "layers", Invoke(SP_2032, "map", Fn((V _arrowThis2081, int _argc2066, V _a2068, V _a2069, V _a2070, V _a2071, V[] _rest2067) => {
V x_2074 = default;
V z_2076 = default;
V r_2078 = default;
V ph_2080 = default;
{ V _t2072 = ListOf(_a2068);
{ V _t2073 = GetIdx(_t2072, 0D);
x_2074 = _t2073; }
{ V _t2075 = GetIdx(_t2072, 1D);
z_2076 = _t2075; }
{ V _t2077 = GetIdx(_t2072, 2D);
r_2078 = _t2077; }
{ V _t2079 = GetIdx(_t2072, 3D);
ph_2080 = _t2079; }
}
return NewObj(2).Put("build", Fn((V _arrowThis2089, int _argc2082, V P_2088, V _a2085, V _a2086, V _a2087, V[] _rest2083) => {
V y_2090 = default;
y_2090 = Call(yb_2034, V.Undef, r_2078);
return Arr(Call(cyl_13, V.Undef, x_2074, ((V)((ToNum(y_2090) - 1.6))), z_2076, ((V)((ToNum(r_2078) * 0.2))), ((V)(2.2)), CH_27, Call(mt_33, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, x_2074, Add(y_2090, ((V)(0.4))), z_2076, ((V)(0.7)), ((V)((ToNum(r_2078) * 0.78))), CH_27, Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(ball_14, V.Undef, x_2074, Add(y_2090, ((V)((ToNum(r_2078) * 0.78)))), z_2076, ((V)((ToNum(r_2078) * 0.22))), ((V)("#c9a6ff")), Call(em_25, V.Undef, NewObj(1).Put("k", ((V)(5D))).V)), Call(ball_14, V.Undef, x_2074, y_2090, z_2076, r_2078, ((V)("#cfeaff")), Call(cer_35, V.Undef, NewObj(4).Put("op", ((V)(0.26))).Put("n", ((V)(22D))).Put("k", ((V)(9D))).Put("shine", ((V)(1D))).V)));
return default;
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis2099, int _argc2091, V p_2097, V s_2098, V _a2095, V _a2096, V[] _rest2092) => {
V k_2100 = default;
V y_2101 = default;
V c0_2102 = default;
double Rs_2103 = 0;
V R_2104 = default;
JsStrBuf a_2105 = null;
k_2100 = Call(kOf_47, V.Undef, p_2097);
y_2101 = Call(yb_2034, V.Undef, r_2078);
c0_2102 = Call(p_2097, V.Undef, x_2074, Add(y_2101, r_2078), z_2076);
Rs_2103 = ((ToNum(r_2078) * ToNum(k_2100)) * 0.93);
R_2104 = Call(rng_40, V.Undef, ((V)(JsStrBuf.Begin().S("arc").V(x_2074).End())));
a_2105 = new JsStrBuf("");
Call(rep_38, V.Undef, ((V)(5D)), Fn((V _arrowThis2113, int _argc2106, V j_2112, V _a2109, V _a2110, V _a2111, V[] _rest2107) => {
V vs_2114 = default;
vs_2114 = Call(rep_38, V.Undef, ((V)(3D)), Fn((V _arrowThis2121, int _argc2115, V _a2117, V _a2118, V _a2119, V _a2120, V[] _rest2116) => {
double ph2_2122 = 0;
V e_2123 = default;
JsStrBuf d_2124 = null;
ph2_2122 = ((ToNum(j_2112) * 1.26) + (ToNum(Call(R_2104, V.Undef)) * 0.5));
e_2123 = Arr(Add(GetIdx(c0_2102, 0D), ((V)((FdLibm.Cos(ph2_2122) * Rs_2103)))), Add(GetIdx(c0_2102, 1D), ((V)(((FdLibm.Sin(ph2_2122) * Rs_2103) * 0.98)))));
d_2124 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(P2_42, V.Undef, c0_2102)).End());
Call(rep_38, V.Undef, ((V)(4D)), Fn((V _arrowThis2132, int _argc2125, V m_2131, V _a2128, V _a2129, V _a2130, V[] _rest2126) => {
double t_2133 = 0;
double nx_2134 = 0;
double ny_2135 = 0;
V L_2136 = default;
double jj_2137 = 0;
t_2133 = (ToNum(Add(m_2131, ((V)(1D)))) / 5D);
nx_2134 = (-(ToNum(GetIdx(e_2123, 1D)) - ToNum(GetIdx(c0_2102, 1D))));
ny_2135 = (ToNum(GetIdx(e_2123, 0D)) - ToNum(GetIdx(c0_2102, 0D)));
L_2136 = (((V)(Hypot(nx_2134, ny_2135))) is var _t2138 && Truthy(_t2138) ? _t2138 : ((V)(1D)));
jj_2137 = (((ToNum(Call(R_2104, V.Undef)) - 0.5) * 0.35) * Rs_2103);
d_2124.S("L").V(Call(f1_23, V.Undef, Add(Add(GetIdx(c0_2102, 0D), ((V)(((ToNum(GetIdx(e_2123, 0D)) - ToNum(GetIdx(c0_2102, 0D))) * t_2133)))), ((V)(((nx_2134 / ToNum(L_2136)) * jj_2137)))))).S(" ").V(Call(f1_23, V.Undef, Add(Add(GetIdx(c0_2102, 1D), ((V)(((ToNum(GetIdx(e_2123, 1D)) - ToNum(GetIdx(c0_2102, 1D))) * t_2133)))), ((V)(((ny_2135 / ToNum(L_2136)) * jj_2137))))));
return default;
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S(d_2124.Str).S("L").V(Call(P2_42, V.Undef, e_2123)).End()));
return default;
}, 0, "", true));
a_2105.S("<path d=\"").V(GetIdx(vs_2114, 0D)).S("\" fill=\"none\" stroke=\"#b48cff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(k_2100)))))).S("\" stroke-linecap=\"round\" stroke-linejoin=\"round\" opacity=\"0.28\">").V(Call(anD_53, V.Undef, ((V)("d")), Invoke(vs_2114, "join", ((V)(";"))), ((V)(0.36)), ((V)(((-ToNum(j_2112)) * 0.07))))).S("</path><path d=\"").V(GetIdx(vs_2114, 0D)).S("\" fill=\"none\" stroke=\"#f4ecff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.45 * ToNum(k_2100)))))).S("\">").V(Call(anD_53, V.Undef, ((V)("d")), Invoke(vs_2114, "join", ((V)(";"))), ((V)(0.36)), ((V)(((-ToNum(j_2112)) * 0.07))))).V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("1;0.4;1;0.7;1")), ((V)(0.5)), ((V)(((-ToNum(j_2112)) * 0.1))))).S("</path>");
return default;
}, 1, "", true));
a_2105.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(c0_2102, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(c0_2102, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)(((ToNum(r_2078) * 0.75) * ToNum(k_2100)))))).S("\" fill=\"url(#sbg)\" opacity=\"0.6\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.2;0.45;0.25;0.4;0.2")), ((V)(0.9)))).S("</circle>");
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(atS_55, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;0 ").V(Call(f1_23, V.Undef, ((V)(((-3.4) * ToNum(k_2100)))))).S(";0 0").End())), ((V)(3.4)), ((V)((-ToNum(ph_2080)))))).V(s_2098).S(a_2105.Str).S("</g>").End()));
return default;
}, 2, "wrap", true)).V;
}, 1, "", true)));
Set(D_2033, "fx", Fn((V _arrowThis2146, int _argc2139, V c_2145, V _a2142, V _a2143, V _a2144, V[] _rest2140) => {
V p_2147 = default;
JsStrBuf f_2148 = null;
p_2147 = Get(c_2145, "p");
f_2148 = new JsStrBuf("");
Invoke(SP_2032, "forEach", Fn((V _arrowThis2163, int _argc2149, V _a2151, V i_2155, V _a2153, V _a2154, V[] _rest2150) => {
V x_2158 = default;
V z_2160 = default;
V r_2162 = default;
{ V _t2156 = ListOf(_a2151);
{ V _t2157 = GetIdx(_t2156, 0D);
x_2158 = _t2157; }
{ V _t2159 = GetIdx(_t2156, 1D);
z_2160 = _t2159; }
{ V _t2161 = GetIdx(_t2156, 2D);
r_2162 = _t2161; }
}
f_2148.S("<g transform=\"").V(Call(planeH_46, V.Undef, p_2147, ((V)(7.4)), x_2158, z_2160)).S("\">").V(Invoke(Call(rep_38, V.Undef, ((V)(2D)), Fn((V _arrowThis2171, int _argc2164, V j_2170, V _a2167, V _a2168, V _a2169, V[] _rest2165) => {
return ((V)(JsStrBuf.Begin().S("<ellipse rx=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(r_2162) * 0.6))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(r_2162) * 0.6))))).S("\" fill=\"none\" stroke=\"#6ac8ff\" stroke-width=\"0.7\">").V(Call(an_51, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((ToNum(r_2162) * 0.5))))).S(";").V(Call(f1_23, V.Undef, ((V)((ToNum(r_2162) * 1.3))))).End())), ((V)(1.8)), ((V)((((-ToNum(i_2155)) * 0.4) - (ToNum(j_2170) * 0.9)))))).V(Call(an_51, V.Undef, ((V)("ry")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((ToNum(r_2162) * 0.5))))).S(";").V(Call(f1_23, V.Undef, ((V)((ToNum(r_2162) * 1.3))))).End())), ((V)(1.8)), ((V)((((-ToNum(i_2155)) * 0.4) - (ToNum(j_2170) * 0.9)))))).V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.8;0")), ((V)(1.8)), ((V)((((-ToNum(i_2155)) * 0.4) - (ToNum(j_2170) * 0.9)))))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
return default;
}, 2, "", true));
return NewObj(2).Put("defs", ((V)("<radialGradient id=\"sbg\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#b48cff\" stop-opacity=\"0.9\"/><stop offset=\"0.45\" stop-color=\"#b48cff\" stop-opacity=\"0.4\"/><stop offset=\"1\" stop-color=\"#b48cff\" stop-opacity=\"0\"/></radialGradient>"))).Put("under", ((V)(f_2148.Str))).V;
return default;
}, 1, "", true));
return D_2033;
return default;
}, 1, "", true));
Set(N_24, "coneHearth", Fn((V _arrowThis2179, int _argc2172, V S_2178, V _a2175, V _a2176, V _a2177, V[] _rest2173) => {
V BK_2180 = default;
BK_2180 = ((V)("#2a2b2e"));
return NewObj(4).Put("w", ((V)(110D))).Put("d", ((V)(84D))).Put("build", Fn((V _arrowThis2188, int _argc2181, V P_2187, V _a2184, V _a2185, V _a2186, V[] _rest2182) => {
V o_2189 = default;
o_2189 = Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(36D)), ((V)(3D)), ((V)("#3a3c40")), Call(cer_35, V.Undef, NewObj(2).Put("rz", ((V)(31D))).Put("n", ((V)(28D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(33D)), ((V)(0.8)), ((V)("#55585e")), Call(cer_35, V.Undef, NewObj(2).Put("rz", ((V)(28D))).Put("n", ((V)(28D))).V)));
Invoke(o_2189, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(26D)), ((V)(30D)), BK_2180, Call(pt_37, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.32))), Arr(((V)(5D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(13D)), ((V)(0D)), ((V)(1D))), Arr(((V)(22D)), ((V)(0D)), ((V)(0.94))), Arr(((V)(30D)), ((V)(0D)), ((V)(0.6))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(60D)), ((V)(0D)), ((V)(15.8)), ((V)(30D)), BK_2180, Call(pt_37, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(30D)), ((V)(0D)), ((V)(0.32))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(89.6)), ((V)(0D)), ((V)(5.2)), ((V)(104D)), BK_2180, Call(pt_37, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(188D)), ((V)(0D)), ((V)(9D)), ((V)(3.4)), BK_2180, Call(pt_37, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(120D)), ((V)(0D)), ((V)(5.7)), ((V)(1.4)), ((V)("#3e4045")), Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)));
Invoke(Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(1D)), ((V)(0D))), Arr(((V)(2D)), ((V)(0D))), Arr(((V)(0.5)), ((V)(1D))), Arr(((V)(1.5)), ((V)(1D))), Arr(((V)(1D)), ((V)(2D)))), "forEach", Fn((V _arrowThis2201, int _argc2190, V _a2192, V _a2193, V _a2194, V _a2195, V[] _rest2191) => {
double x_2202 = 0;
double y_2203 = 0;
V i_2198 = default;
V j_2200 = default;
{ V _t2196 = ListOf(_a2192);
{ V _t2197 = GetIdx(_t2196, 0D);
i_2198 = _t2197; }
{ V _t2199 = GetIdx(_t2196, 1D);
j_2200 = _t2199; }
}
x_2202 = (46D + (ToNum(i_2198) * 7.6));
y_2203 = ((4D + 3.8) + (ToNum(j_2200) * 6.8));
Invoke(o_2189, "push", Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(x_2202)), ((V)(y_2203)))).Put("a", ((V)(3.8))).Put("b", ((V)(3.6))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)((-14D))), ((V)(0D))), Arr(((V)(12D)), ((V)(0D))))).Put("col", ((V)((SEqN(j_2200, 2D) ? "#7a5234" : "#8a5a34")))).Put("mat", ((V)("wood"))).V), Call(disc_18, V.Undef, ((V)(x_2202)), ((V)(y_2203)), ((V)(12D)), ((V)(3.2)), ((V)(0.4)), ((V)("#d9b48a")), Call(wd_34, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("noOut", ((V)(1D))).V)));
return default;
}, 1, "", true));
InvokeSpread(o_2189, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(53.6)), ((V)(0D)), ((V)((-15D))), ((V)(26D)), ((V)(1.2)), ((V)(1.4)), BK_2180, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V))).Add(Call(box_12, V.Undef, ((V)(53.6)), ((V)(0D)), ((V)(13D)), ((V)(26D)), ((V)(1.2)), ((V)(1.4)), BK_2180, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V))).Spread(Invoke(Arr(((V)(41.8)), ((V)(65.4))), "map", Fn((V _arrowThis2211, int _argc2204, V x_2210, V _a2207, V _a2208, V _a2209, V[] _rest2205) => {
return Call(box_12, V.Undef, x_2210, ((V)(0D)), ((V)((-1D))), ((V)(1.2)), ((V)(14D)), ((V)(28D)), BK_2180, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V));
}, 1, "", true))).V);
return o_2189;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2219, int _argc2212, V c_2218, V _a2215, V _a2216, V _a2217, V[] _rest2213) => {
V p_2220 = default;
V k_2221 = default;
V q_2222 = default;
JsStrBuf f_2223 = null;
V F_2224 = default;
V g_2225 = default;
p_2220 = Get(c_2218, "p");
k_2221 = Get(c_2218, "k");
q_2222 = Call(p_2220, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(22.6)));
f_2223 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_42, V.Undef, q_2222)).S(")\"><ellipse rx=\"").V(Call(f1_23, V.Undef, ((V)((15D * ToNum(k_2221)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((9.5 * ToNum(k_2221)))))).S("\" fill=\"#141210\" stroke=\"#4a4c52\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((1.1 * ToNum(k_2221)))))).S("\"/><ellipse cy=\"").V(Call(f1_23, V.Undef, ((V)((2D * ToNum(k_2221)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((12D * ToNum(k_2221)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((6.5 * ToNum(k_2221)))))).S("\" fill=\"url(#chot)\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.6;1;0.75;0.95;0.6")), ((V)(1.8)))).S("</ellipse>").S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)(((-9D) * ToNum(k_2221)))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((3D * ToNum(k_2221)))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((18D * ToNum(k_2221)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((2.6 * ToNum(k_2221)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((1.3 * ToNum(k_2221)))))).S("\" fill=\"#5a3418\" transform=\"rotate(-6)\"/><rect x=\"").V(Call(f1_23, V.Undef, ((V)(((-8D) * ToNum(k_2221)))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((4.4 * ToNum(k_2221)))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((16D * ToNum(k_2221)))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(k_2221)))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((1.2 * ToNum(k_2221)))))).S("\" fill=\"#6a3e1e\" transform=\"rotate(8)\"/></g>").End());
F_2224 = Invoke(Get(RD_8, "H"), "fire", c_2218, Arr(Arr(((V)((-3D))), ((V)(40D)), ((V)(21D)), ((V)(0.55))), Arr(((V)(3.5)), ((V)(40.5)), ((V)(21.5)), ((V)(0.48)))));
f_2223.S("<g clip-path=\"url(#cclip)\">").V(Get(F_2224, "over")).S("</g>");
g_2225 = Call(p_2220, V.Undef, ((V)(0D)), ((V)(3.4)), ((V)(0D)));
f_2223.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(g_2225, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(g_2225, 1D))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((30D * ToNum(k_2221)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((14D * ToNum(k_2221)))))).S("\" fill=\"#ff9a3a\" opacity=\"0.12\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.08;0.18;0.1")), ((V)(1.6)))).S("</ellipse>");
return NewObj(2).Put("defs", ((V)(JsStrBuf.Begin().S("<radialGradient id=\"chot\" cx=\"50%\" cy=\"70%\" r=\"60%\"><stop offset=\"0\" stop-color=\"#ffcf6a\"/><stop offset=\"0.5\" stop-color=\"#ff7a22\" stop-opacity=\"0.7\"/><stop offset=\"1\" stop-color=\"#3a1a0a\" stop-opacity=\"0\"/></radialGradient><clipPath id=\"cclip\"><ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(q_2222, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(q_2222, 1D)) - (5D * ToNum(k_2221))))))).S("\" rx=\"").V(Call(f1_23, V.Undef, ((V)((15D * ToNum(k_2221)))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((14.5 * ToNum(k_2221)))))).S("\"/></clipPath>").End()))).Put("front", ((V)(f_2223.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
BOOKC_73 = Arr(((V)("#7f2030")), ((V)("#1f4f3e")), ((V)("#2b3f7a")), ((V)("#c99a2e")), ((V)("#5a2a5e")), ((V)("#e9dfcc")), ((V)("#3a2a22")), ((V)("#a8592b")), ((V)("#2c2d31")), ((V)("#6b8fb8")), ((V)("#9fb58c")), ((V)("#d9483b")));
shelfBooks_74 = Fn((V _arrowThis2240, int _argc2226, V o_2232, V R_2233, V x0_2234, V x1_2235, V[] _rest2227) => {
V x_2241 = default;
V y_2236 = default;
V zb_2237 = default;
V dmax_2238 = default;
V hmax_2239 = default;
y_2236 = (_argc2226 > 4 ? _rest2227[0] : V.Undef);
zb_2237 = (_argc2226 > 5 ? _rest2227[1] : V.Undef);
dmax_2238 = (_argc2226 > 6 ? _rest2227[2] : V.Undef);
hmax_2239 = (_argc2226 > 7 ? _rest2227[3] : V.Undef);
x_2241 = Add(x0_2234, ((V)(0.6)));
while (LtN(x_2241, (ToNum(x1_2235) - 2D))) {
V k_2242 = default;
double w_2243 = 0;
double h_2244 = 0;
double d_2245 = 0;
V col_2246 = default;
V zf_2247 = default;
k_2242 = Call(R_2233, V.Undef);
if ((LtN(k_2242, 0.08) && ((ToNum(x1_2235) - ToNum(x_2241)) > 14D))) {
V t_2248 = default;
t_2248 = Call(R_2233, V.Undef);
if (LtN(t_2248, 0.5)) {
Invoke(o_2232, "push", Call(cyl_13, V.Undef, Add(x_2241, ((V)(4D))), y_2236, Add(zb_2237, ((V)((ToNum(dmax_2238) / 2D)))), ((V)(3.2)), ((V)((ToNum(hmax_2239) * 0.55))), GetIdx(Arr(((V)("#e9e4da")), ((V)("#3f6a8a")), ((V)("#c8693f"))), System.Math.Floor((ToNum(Call(R_2233, V.Undef)) * 3D))), Call(cer_35, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)((ToNum(hmax_2239) * 0.3))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(hmax_2239) * 0.55))), ((V)(0D)), ((V)(0.5))))).V)));
} else {
Invoke(o_2232, "push", Call(cyl_13, V.Undef, Add(x_2241, ((V)(4D))), y_2236, Add(zb_2237, ((V)((ToNum(dmax_2238) / 2D)))), ((V)(2.6)), ((V)(1.4)), ((V)("#3a2a22")), Call(wd_34, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(ball_14, V.Undef, Add(x_2241, ((V)(4D))), Add(y_2236, ((V)(1.4))), Add(zb_2237, ((V)((ToNum(dmax_2238) / 2D)))), ((V)(3.6)), ((V)("#6b8fb8")), NewObj(2).Put("k", ((V)(6D))).Put("n", ((V)(12D))).V));
}
x_2241 = Add(x_2241, ((V)(9D)));
continue;
}
if ((LtN(k_2242, 0.16) && ((ToNum(x1_2235) - ToNum(x_2241)) > 14D))) {
double w_2249 = 0;
w_2249 = (11D + (ToNum(Call(R_2233, V.Undef)) * 3D));
Call(rep_38, V.Undef, ((V)((3D + System.Math.Floor((ToNum(Call(R_2233, V.Undef)) * 3D))))), Fn((V _arrowThis2257, int _argc2250, V j_2256, V _a2253, V _a2254, V _a2255, V[] _rest2251) => {
return Invoke(o_2232, "push", Call(box_12, V.Undef, Add(x_2241, ((V)((w_2249 / 2D)))), Add(y_2236, ((V)((ToNum(j_2256) * 2.6)))), Add(zb_2237, ((V)((ToNum(dmax_2238) / 2D)))), ((V)((w_2249 - (ToNum(j_2256) * 0.6)))), ((V)(2.4)), ((V)(((ToNum(dmax_2238) - 2D) - (ToNum(j_2256) * 0.4)))), GetIdx(BOOKC_73, System.Math.Floor((ToNum(Call(R_2233, V.Undef)) * 12D))), Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
}, 1, "", true));
x_2241 = Add(x_2241, ((V)((w_2249 + 1D))));
continue;
}
w_2243 = (2.4 + (ToNum(Call(R_2233, V.Undef)) * 2.6));
h_2244 = (ToNum(hmax_2239) * (0.7 + (ToNum(Call(R_2233, V.Undef)) * 0.28)));
d_2245 = (ToNum(dmax_2238) - (ToNum(Call(R_2233, V.Undef)) * 3D));
col_2246 = GetIdx(BOOKC_73, System.Math.Floor((ToNum(Call(R_2233, V.Undef)) * 12D)));
zf_2247 = Add(zb_2237, ((V)(d_2245)));
Invoke(o_2232, "push", Call(box_12, V.Undef, Add(x_2241, ((V)((w_2243 / 2D)))), y_2236, Add(zb_2237, ((V)((d_2245 / 2D)))), ((V)(w_2243)), ((V)(h_2244)), ((V)(d_2245)), col_2246, Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
if (LtN(Call(R_2233, V.Undef), 0.7)) {
Invoke(Arr(((V)(0.78)), ((V)(0.18))), "forEach", Fn((V _arrowThis2265, int _argc2258, V t_2264, V _a2261, V _a2262, V _a2263, V[] _rest2259) => {
return Invoke(o_2232, "push", Call(box_12, V.Undef, Add(x_2241, ((V)((w_2243 / 2D)))), Add(y_2236, ((V)((h_2244 * ToNum(t_2264))))), Add(zf_2247, ((V)(0.15))), ((V)((w_2243 * 0.86))), ((V)(0.7)), ((V)(0.3)), GOLD_26, Call(mt_33, V.Undef, NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V)));
}, 1, "", true));
}
x_2241 = Add(x_2241, ((V)((w_2243 + 0.2))));
}
return default;
}, 8, "", true);
Set(N_24, "library", Fn((V _arrowThis2273, int _argc2266, V S_2272, V _a2269, V _a2270, V _a2271, V[] _rest2267) => {
double W_2274 = 0;
double H_2275 = 0;
double DD_2276 = 0;
V WAL_2277 = default;
V WD_2278 = default;
V ys_2279 = default;
V bays_2280 = default;
double zb_2281 = 0;
double LX_2282 = 0;
V lz_2283 = default;
V R_2284 = default;
V lev_2285 = default;
V L_2286 = default;
W_2274 = 170D;
H_2275 = 150D;
DD_2276 = 38D;
WAL_2277 = ((V)("#5b3820"));
WD_2278 = ((V)("#4a2c18"));
ys_2279 = Arr(((V)(10D)), ((V)(38D)), ((V)(66D)), ((V)(94D)), ((V)(122D)));
bays_2280 = Arr(Arr(((V)((((-W_2274) / 2D) + 6D))), ((V)((-27D)))), Arr(((V)((-24.5))), ((V)(24.5))), Arr(((V)(27D)), ((V)(((W_2274 / 2D) - 6D)))));
zb_2281 = (((-DD_2276) / 2D) + 3D);
LX_2282 = 32D;
lz_2283 = Fn((V _arrowThis2294, int _argc2287, V y_2293, V _a2290, V _a2291, V _a2292, V[] _rest2288) => {
return ((V)((50D - ((ToNum(y_2293) / 132D) * 28D))));
}, 1, "", true);
R_2284 = Call(rng_40, V.Undef, ((V)(JsStrBuf.Begin().S("lib").V((Get(S_2272, "nm") is var _t2295 && Truthy(_t2295) ? _t2295 : ((V)("")))).End())));
lev_2285 = Invoke(ys_2279, "map", Fn((V _arrowThis2304, int _argc2296, V y_2302, V j_2303, V _a2300, V _a2301, V[] _rest2297) => {
V o_2305 = default;
double top_2306 = 0;
o_2305 = Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)((ToNum(y_2302) - 2.4))), ((V)(0D)), ((V)((W_2274 - 10D))), ((V)(2.4)), ((V)((DD_2276 - 2D))), WAL_2277, Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((ToNum(y_2302) - 2.4))), ((V)(((DD_2276 / 2D) - 0.6))), ((V)((W_2274 - 10D))), ((V)(2.4)), ((V)(0.9)), Call(shade_21, V.Undef, WAL_2277, ((V)(1.15))), Call(wd_34, V.Undef, NewObj(2).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).V)));
top_2306 = (LtN(j_2303, 4D) ? (ToNum(GetK(ys_2279, Add(j_2303, ((V)(1D))))) - 2.4) : H_2275);
Invoke(Arr(((V)((-25.75))), ((V)(25.75))), "forEach", Fn((V _arrowThis2314, int _argc2307, V x_2313, V _a2310, V _a2311, V _a2312, V[] _rest2308) => {
return Invoke(o_2305, "push", Call(box_12, V.Undef, x_2313, y_2302, ((V)(0D)), ((V)(2.5)), ((V)((top_2306 - ToNum(y_2302)))), ((V)((DD_2276 - 2D))), WAL_2277, Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
Invoke(bays_2280, "forEach", Fn((V _arrowThis2326, int _argc2315, V _a2317, V _a2318, V _a2319, V _a2320, V[] _rest2316) => {
V a_2323 = default;
V b_2325 = default;
{ V _t2321 = ListOf(_a2317);
{ V _t2322 = GetIdx(_t2321, 0D);
a_2323 = _t2322; }
{ V _t2324 = GetIdx(_t2321, 1D);
b_2325 = _t2324; }
}
return Call(shelfBooks_74, V.Undef, o_2305, R_2284, a_2323, b_2325, y_2302, ((V)(zb_2281)), ((V)((DD_2276 - 9D))), ((V)(Min(24D, ((top_2306 - ToNum(y_2302)) - 3D)))));
}, 1, "", true));
return o_2305;
return default;
}, 2, "", true));
L_2286 = Arr(NewObj(2).Put("back", ((V)(1D))).Put("build", Fn((V _arrowThis2334, int _argc2327, V P_2333, V _a2330, V _a2331, V _a2332, V[] _rest2328) => {
return Arr(Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((((-DD_2276) / 2D) + 1D))), ((V)((W_2274 - 4D))), ((V)(H_2275)), ((V)(2D)), WD_2278, Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((-((W_2274 / 2D) - 3D)))), ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(H_2275)), ((V)(DD_2276)), WAL_2277, Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)));
}, 1, "build", true)).V);
Invoke(lev_2285, "forEach", Fn((V _arrowThis2342, int _argc2335, V o_2341, V _a2338, V _a2339, V _a2340, V[] _rest2336) => {
return Invoke(L_2286, "push", NewObj(1).Put("build", Fn((V _arrowThis2350, int _argc2343, V P_2349, V _a2346, V _a2347, V _a2348, V[] _rest2344) => {
return o_2341;
}, 1, "build", true)).V);
}, 1, "", true));
Invoke(L_2286, "push", NewObj(1).Put("build", Fn((V _arrowThis2358, int _argc2351, V P_2357, V _a2354, V _a2355, V _a2356, V[] _rest2352) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(H_2275)), ((V)(0D)), ((V)((W_2274 + 4D))), ((V)(4D)), ((V)((DD_2276 + 4D))), WAL_2277, Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((H_2275 + 4D))), ((V)((-1D))), ((V)((W_2274 + 8D))), ((V)(2.6)), ((V)((DD_2276 + 8D))), Call(shade_21, V.Undef, WAL_2277, ((V)(1.08))), Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((H_2275 - 1.2))), ((V)(((DD_2276 / 2D) - 1D))), ((V)((W_2274 - 10D))), ((V)(1D)), ((V)(0.6)), ((V)("#ffe9b0")), Call(em_25, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
}, 1, "build", true)).V, NewObj(1).Put("build", Fn((V _arrowThis2366, int _argc2359, V P_2365, V _a2362, V _a2363, V _a2364, V[] _rest2360) => {
return Arr(Call(box_12, V.Undef, ((V)(((W_2274 / 2D) - 3D))), ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(H_2275)), ((V)(DD_2276)), WAL_2277, Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)));
}, 1, "build", true)).V);
Invoke(L_2286, "push", NewObj(1).Put("build", Fn((V _arrowThis2374, int _argc2367, V P_2373, V _a2370, V _a2371, V _a2372, V[] _rest2368) => {
V o_2375 = default;
double ry_2376 = 0;
double rz_2377 = 0;
o_2375 = Arr();
ry_2376 = 134D;
rz_2377 = 22D;
InvokeSpread(o_2375, "push", new ArrBuilder().Add(Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(rz_2377)), ((V)(ry_2376)))).Put("a", ((V)(1.4))).Put("b", ((V)(1.4))).Put("n", ((V)(10D))).Put("rings", Arr(Arr(((V)((((-W_2274) / 2D) + 4D))), ((V)(0D))), Arr(((V)(((W_2274 / 2D) - 4D))), ((V)(0D))))).Put("col", ((V)("#d4a548"))).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V)).Spread(Invoke(Arr(((V)((((-W_2274) / 2D) + 8D))), ((V)(0D)), ((V)(((W_2274 / 2D) - 8D)))), "map", Fn((V _arrowThis2385, int _argc2378, V x_2384, V _a2381, V _a2382, V _a2383, V[] _rest2379) => {
return Call(box_12, V.Undef, x_2384, ((V)((ry_2376 - 1D))), ((V)((19.5 - 2D))), ((V)(2D)), ((V)(2.4)), ((V)(5D)), ((V)("#b8862e")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V));
}, 1, "", true))).V);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2393, int _argc2386, V sg_2392, V _a2389, V _a2390, V _a2391, V[] _rest2387) => {
double x_2394 = 0;
x_2394 = (LX_2282 + (ToNum(sg_2392) * 10D));
Invoke(o_2375, "push", Call(prism_19, V.Undef, ((V)((x_2394 - 1.3))), ((V)((x_2394 + 1.3))), Arr(Arr(Add(Call(lz_2283, V.Undef, ((V)(0D))), ((V)(1.6))), ((V)(0D))), Arr(Add(Call(lz_2283, V.Undef, ((V)(0D))), ((V)(4.2))), ((V)(0D))), Arr(Add(Call(lz_2283, V.Undef, ((V)(132D))), ((V)(2.6))), ((V)(132D))), Arr(Call(lz_2283, V.Undef, ((V)(132D))), ((V)(132D)))), ((V)("#7a4a2a")), Call(wd_34, V.Undef)), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(Add(Call(lz_2283, V.Undef, ((V)(0D))), ((V)(2.9))), ((V)(2.6)))).Put("a", ((V)(2.6))).Put("b", ((V)(2.6))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)((x_2394 - 1.6))), ((V)(0D))), Arr(((V)((x_2394 + 1.6))), ((V)(0D))))).Put("col", ((V)("#2c2d31"))).Put("mat", ((V)("metal"))).V), Call(box_12, V.Undef, ((V)(x_2394)), ((V)(131D)), ((V)((ToNum(Call(lz_2283, V.Undef, ((V)(132D)))) - 0.4))), ((V)(2D)), ((V)(4D)), ((V)(3D)), ((V)("#b8862e")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
return default;
}, 1, "", true));
Call(rep_38, V.Undef, ((V)(8D)), Fn((V _arrowThis2402, int _argc2395, V i_2401, V _a2398, V _a2399, V _a2400, V[] _rest2396) => {
double y_2403 = 0;
y_2403 = (14D + (ToNum(i_2401) * 15.5));
Invoke(o_2375, "push", Call(slabX_16, V.Undef, ((V)(LX_2282)), ((V)(y_2403)), Add(Call(lz_2283, V.Undef, ((V)(y_2403))), ((V)(1.6))), ((V)(18.4)), ((V)(1.6)), ((V)(2.6)), ((V)("#8a5a34")), Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
return default;
}, 1, "", true));
return o_2375;
return default;
}, 1, "build", true)).V);
return NewObj(5).Put("w", ((V)((W_2274 + 6D)))).Put("d", ((V)((DD_2276 + 30D)))).Put("layers", L_2286).Put("build", Fn((V _arrowThis2411, int _argc2404, V P_2410, V _a2407, V _a2408, V _a2409, V[] _rest2405) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((W_2274 - 6D))), ((V)(8D)), ((V)((DD_2276 - 4D))), Call(shade_21, V.Undef, WAL_2277, ((V)(0.85))), Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "build", true)).Put("glow", Fn((V _arrowThis2418, int _argc2412, V _a2414, V _a2415, V _a2416, V _a2417, V[] _rest2413) => {
return NewObj(3).Put("y", ((V)(120D))).Put("r", ((V)(70D))).Put("c", ((V)("url(#gWarm)"))).V;
}, 0, "glow", true)).V;
return default;
}, 1, "", true));
Set(N_24, "archBook", Fn((V _arrowThis2426, int _argc2419, V S_2425, V _a2422, V _a2423, V _a2424, V[] _rest2420) => {
double W_2427 = 0;
double H_2428 = 0;
double DD_2429 = 0;
V PNT_2430 = default;
V OAK_2431 = default;
V bays_2432 = default;
double ZF_2433 = 0;
double SPR_2434 = 0;
W_2427 = 176D;
H_2428 = 148D;
DD_2429 = 34D;
PNT_2430 = ((V)("#ece4d4"));
OAK_2431 = ((V)("#c8925a"));
bays_2432 = Arr(Arr(((V)((-58D))), ((V)(25D)), ((V)("b"))), Arr(((V)(0D)), ((V)(30D)), ((V)("n"))), Arr(((V)(58D)), ((V)(25D)), ((V)("b"))));
ZF_2433 = (DD_2429 / 2D);
SPR_2434 = 106D;
return NewObj(4).Put("w", ((V)((W_2427 + 6D)))).Put("d", ((V)((DD_2429 + 6D)))).Put("build", Fn((V _arrowThis2442, int _argc2435, V P_2441, V _a2438, V _a2439, V _a2440, V[] _rest2436) => {
V R_2443 = default;
V o_2444 = default;
double zb_2445 = 0;
R_2443 = Call(rng_40, V.Undef, ((V)(JsStrBuf.Begin().S("arch").V((Get(S_2425, "nm") is var _t2446 && Truthy(_t2446) ? _t2446 : ((V)("")))).End())));
o_2444 = Arr();
zb_2445 = (((-DD_2429) / 2D) + 2.5);
Invoke(o_2444, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((((-DD_2429) / 2D) + 1D))), ((V)((W_2427 - 4D))), ((V)(H_2428)), ((V)(2D)), ((V)("#d9cfbc")), Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(W_2427)), ((V)(9D)), ((V)(DD_2429)), PNT_2430, Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2454, int _argc2447, V sg_2453, V _a2450, V _a2451, V _a2452, V[] _rest2448) => {
return Invoke(o_2444, "push", Call(box_12, V.Undef, ((V)((ToNum(sg_2453) * ((W_2427 / 2D) - 3D)))), ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(H_2428)), ((V)(DD_2429)), PNT_2430, Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
Invoke(o_2444, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(H_2428)), ((V)(0D)), ((V)((W_2427 + 4D))), ((V)(4D)), ((V)((DD_2429 + 4D))), PNT_2430, Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((H_2428 + 4D))), ((V)((-1D))), ((V)((W_2427 + 8D))), ((V)(3D)), ((V)((DD_2429 + 8D))), Call(mix_22, V.Undef, PNT_2430, ((V)("#ffffff")), ((V)(0.3))), Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Invoke(bays_2432, "forEach", Fn((V _arrowThis2468, int _argc2455, V _a2457, V _a2458, V _a2459, V _a2460, V[] _rest2456) => {
V x_2463 = default;
V hw_2465 = default;
V t_2467 = default;
{ V _t2461 = ListOf(_a2457);
{ V _t2462 = GetIdx(_t2461, 0D);
x_2463 = _t2462; }
{ V _t2464 = GetIdx(_t2461, 1D);
hw_2465 = _t2464; }
{ V _t2466 = GetIdx(_t2461, 2D);
t_2467 = _t2466; }
}
if (SEqS(t_2467, "b")) {
Invoke(Arr(((V)(36D)), ((V)(64D)), ((V)(92D)), ((V)(118D))), "forEach", Fn((V _arrowThis2476, int _argc2469, V y_2475, V _a2472, V _a2473, V _a2474, V[] _rest2470) => {
return Invoke(o_2444, "push", Call(box_12, V.Undef, x_2463, ((V)((ToNum(y_2475) - 2.2))), ((V)((-1D))), ((V)((ToNum(hw_2465) * 2D))), ((V)(2.2)), ((V)((DD_2429 - 6D))), OAK_2431, Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
}, 1, "", true));
Invoke(Arr(((V)(9D)), ((V)(36D)), ((V)(64D)), ((V)(92D)), ((V)(118D))), "forEach", Fn((V _arrowThis2484, int _argc2477, V y_2483, V _a2480, V _a2481, V _a2482, V[] _rest2478) => {
return Call(shelfBooks_74, V.Undef, o_2444, R_2443, ((V)((ToNum(x_2463) - ToNum(hw_2465)))), Add(x_2463, hw_2465), y_2483, ((V)(zb_2445)), ((V)((DD_2429 - 10D))), ((V)(24D)));
}, 1, "", true));
} else {
Invoke(o_2444, "push", Call(box_12, V.Undef, x_2463, ((V)(9D)), ((V)(0D)), ((V)((ToNum(hw_2465) * 2D))), ((V)(22D)), ((V)((DD_2429 - 4D))), PNT_2430, Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("y"))).Put("sh", ((V)("rr"))).Put("c", Arr(x_2463, ((V)(1D)))).Put("a", ((V)((ToNum(hw_2465) - 1D)))).Put("b", ((V)(((DD_2429 / 2D) - 3D)))).Put("r", ((V)(6D))).Put("rings", Arr(Arr(((V)(31D)), ((V)(1.4)), ((V)(0.97))), Arr(((V)(32.4)), ((V)(0D)), ((V)(1D))), Arr(((V)(37D)), ((V)(0D)), ((V)(1D))), Arr(((V)(39D)), ((V)(3D)), ((V)(0.94))), Arr(((V)(40D)), ((V)(7D)), ((V)(0.84))))).Put("col", ((V)("#6b8fb8"))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((zb_2445 + 6D))), ((V)(46D)))).Put("a", ((V)(6D))).Put("b", ((V)(6D))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)(((ToNum(x_2463) - ToNum(hw_2465)) + 2D))), ((V)(0D)), ((V)(0.75))), Arr(((V)(((ToNum(x_2463) - ToNum(hw_2465)) + 4D))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(Add(x_2463, hw_2465)) - 4D))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(Add(x_2463, hw_2465)) - 2D))), ((V)(0D)), ((V)(0.75))))).Put("col", ((V)("#e9d9b0"))).Put("soft", ((V)(1D))).Put("mat", ((V)("fab"))).V), Call(throwP_68, V.Undef, ((V)((ToNum(x_2463) - 14D))), ((V)(39D)), ((V)((zb_2445 + 13D))), ((V)(18D)), ((V)("#c99a2e"))), Call(throwP_68, V.Undef, Add(x_2463, ((V)(15D))), ((V)(39D)), ((V)((zb_2445 + 13D))), ((V)(16D)), ((V)("#efe4cc"))), Call(box_12, V.Undef, x_2463, ((V)(98D)), ((V)((zb_2445 + 0.6))), ((V)(2.4)), ((V)(2.4)), ((V)(3D)), GOLD_26, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(cyl_13, V.Undef, x_2463, ((V)(92D)), ((V)((zb_2445 + 4D))), ((V)(4.2)), ((V)(6D)), ((V)("#fff2c8")), NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))))).V), Call(ball_14, V.Undef, x_2463, ((V)(93D)), ((V)((zb_2445 + 4D))), ((V)(1.6)), ((V)("#ffe9a0")), Call(em_25, V.Undef, NewObj(1).Put("k", ((V)(3D))).V)), Call(slab_15, V.Undef, x_2463, ((V)(56D)), ((V)((zb_2445 + 0.3))), ((V)(30D)), ((V)(24D)), ((V)(1D)), ((V)("#3a2a22")), Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(slab_15, V.Undef, x_2463, ((V)(58D)), ((V)((zb_2445 + 1D))), ((V)(26D)), ((V)(20D)), ((V)(0.4)), ((V)("#9fb58c")), Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}
return default;
}, 1, "", true));
return o_2444;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2492, int _argc2485, V c_2491, V _a2488, V _a2489, V _a2490, V[] _rest2486) => {
V p_2493 = default;
V open_2494 = default;
V frame_2495 = default;
V mold_2496 = default;
V key_2497 = default;
V f_2498 = default;
p_2493 = Get(c_2491, "p");
open_2494 = Invoke(Invoke(bays_2432, "map", Fn((V _arrowThis2512, int _argc2499, V _a2501, V _a2502, V _a2503, V _a2504, V[] _rest2500) => {
double bot_2513 = 0;
V x_2507 = default;
V hw_2509 = default;
V t_2511 = default;
{ V _t2505 = ListOf(_a2501);
{ V _t2506 = GetIdx(_t2505, 0D);
x_2507 = _t2506; }
{ V _t2508 = GetIdx(_t2505, 1D);
hw_2509 = _t2508; }
{ V _t2510 = GetIdx(_t2505, 2D);
t_2511 = _t2510; }
}
bot_2513 = (SEqS(t_2511, "n") ? 9D : 9D);
return ((V)(JsStrBuf.Begin().S("M").N((ToNum(x_2507) - ToNum(hw_2509))).S(" ").N((H_2428 - bot_2513)).S("V").N((H_2428 - SPR_2434)).S("A").V(hw_2509).S(" ").V(hw_2509).S(" 0 0 1 ").V(Add(x_2507, hw_2509)).S(" ").N((H_2428 - SPR_2434)).S("V").N((H_2428 - bot_2513)).S("Z").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
frame_2495 = ((V)(JsStrBuf.Begin().S("M").N(((-W_2427) / 2D)).S(" 0H").N((W_2427 / 2D)).S("V").N(H_2428).S("H").N(((-W_2427) / 2D)).S("Z").V(open_2494).End()));
mold_2496 = Invoke(Invoke(bays_2432, "map", Fn((V _arrowThis2525, int _argc2514, V _a2516, V _a2517, V _a2518, V _a2519, V[] _rest2515) => {
V x_2522 = default;
V hw_2524 = default;
{ V _t2520 = ListOf(_a2516);
{ V _t2521 = GetIdx(_t2520, 0D);
x_2522 = _t2521; }
{ V _t2523 = GetIdx(_t2520, 1D);
hw_2524 = _t2523; }
}
return ((V)(JsStrBuf.Begin().S("M").N(((ToNum(x_2522) - ToNum(hw_2524)) - 1.6)).S(" ").N((H_2428 - 9D)).S("V").N((H_2428 - SPR_2434)).S("A").V(Add(hw_2524, ((V)(1.6)))).S(" ").V(Add(hw_2524, ((V)(1.6)))).S(" 0 0 1 ").V(Add(Add(x_2522, hw_2524), ((V)(1.6)))).S(" ").N((H_2428 - SPR_2434)).S("V").N((H_2428 - 9D)).End()));
}, 1, "", true)), "join", ((V)("")));
key_2497 = Invoke(Invoke(bays_2432, "map", Fn((V _arrowThis2537, int _argc2526, V _a2528, V _a2529, V _a2530, V _a2531, V[] _rest2527) => {
V x_2534 = default;
V hw_2536 = default;
{ V _t2532 = ListOf(_a2528);
{ V _t2533 = GetIdx(_t2532, 0D);
x_2534 = _t2533; }
{ V _t2535 = GetIdx(_t2532, 1D);
hw_2536 = _t2535; }
}
return ((V)(JsStrBuf.Begin().S("<path d=\"M").N((ToNum(x_2534) - 3D)).S(" ").V(Call(f1_23, V.Undef, ((V)((((H_2428 - SPR_2434) - ToNum(hw_2536)) - 3.5))))).S("H").V(Add(x_2534, ((V)(3D)))).S("L").V(Add(x_2534, ((V)(2D)))).S(" ").V(Call(f1_23, V.Undef, ((V)((((H_2428 - SPR_2434) - ToNum(hw_2536)) + 3D))))).S("H").N((ToNum(x_2534) - 2D)).S("Z\" fill=\"#f6f0e4\" stroke=\"#c9bfae\" stroke-width=\"0.4\"/>").End()));
}, 1, "", true)), "join", ((V)("")));
f_2498 = ((V)(JsStrBuf.Begin().S("<defs><clipPath id=\"abcl\"><path transform=\"").V(Call(plane_44, V.Undef, p_2493, ((V)((ZF_2433 + 0.2))), ((V)(H_2428)), ((V)(0D)))).S("\" d=\"").V(open_2494).S("\"/></clipPath></defs><g clip-path=\"url(#abcl)\"><g transform=\"").V(Call(plane_44, V.Undef, p_2493, ((V)((ZF_2433 - 4D))), ((V)(H_2428)), ((V)(0D)))).S("\"><path d=\"").V(frame_2495).S("\" fill=\"#c9bfae\" fill-rule=\"evenodd\"/></g></g><g transform=\"").V(Call(plane_44, V.Undef, p_2493, ((V)((ZF_2433 + 0.2))), ((V)(H_2428)), ((V)(0D)))).S("\"><path d=\"").V(frame_2495).S("\" fill=\"").V(PNT_2430).S("\" fill-rule=\"evenodd\" stroke=\"#a89c88\" stroke-width=\"0.8\"/><path d=\"").V(frame_2495).S("\" fill=\"url(#p3glass)\" fill-rule=\"evenodd\" opacity=\"0.35\"/><path d=\"").V(mold_2496).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.9\" opacity=\"0.8\"/><path d=\"").V(mold_2496).S("\" fill=\"none\" stroke=\"#b9ad98\" stroke-width=\"0.4\" transform=\"translate(0.9 0.9)\"/>").V(key_2497).S("</g>").End()));
return NewObj(2).Put("defs", PATS_60).Put("front", f_2498).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "vault", Fn((V _arrowThis2545, int _argc2538, V S_2544, V _a2541, V _a2542, V _a2543, V[] _rest2539) => {
double W_2546 = 0;
double H_2547 = 0;
double DD_2548 = 0;
V FR_2549 = default;
V ys_2550 = default;
double ZF_2551 = 0;
V STEEL_2552 = default;
W_2546 = 112D;
H_2547 = 160D;
DD_2548 = 36D;
FR_2549 = ((V)("#2b2622"));
ys_2550 = Arr(((V)(10D)), ((V)(42D)), ((V)(74D)), ((V)(106D)), ((V)(138D)));
ZF_2551 = (DD_2548 / 2D);
STEEL_2552 = Arr(((V)("#aab3bb")), ((V)("#7d858e")), ((V)("#d4a548")), ((V)("#9a3a3a")), ((V)("#3f6aa8")), ((V)("#c9ced3")), ((V)("#5a5e66")), ((V)("#b07a2a")));
return NewObj(5).Put("w", ((V)((W_2546 + 6D)))).Put("d", ((V)((DD_2548 + 6D)))).Put("glow", Fn((V _arrowThis2559, int _argc2553, V _a2555, V _a2556, V _a2557, V _a2558, V[] _rest2554) => {
return NewObj(3).Put("y", ((V)(80D))).Put("r", ((V)(70D))).Put("c", ((V)("url(#gWarm)"))).V;
}, 0, "glow", true)).Put("build", Fn((V _arrowThis2567, int _argc2560, V P_2566, V _a2563, V _a2564, V _a2565, V[] _rest2561) => {
V R_2568 = default;
V o_2569 = default;
R_2568 = Call(rng_40, V.Undef, ((V)("vault")));
o_2569 = Arr();
Invoke(o_2569, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((((-DD_2548) / 2D) + 1D))), ((V)((W_2546 - 2D))), ((V)(H_2547)), ((V)(2D)), ((V)("#1a1820")), Call(fb_36, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(W_2546)), ((V)(6D)), ((V)(DD_2548)), FR_2549, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((H_2547 - 4D))), ((V)(0D)), ((V)(W_2546)), ((V)(6D)), ((V)(DD_2548)), FR_2549, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis2581, int _argc2570, V _a2572, V _a2573, V _a2574, V _a2575, V[] _rest2571) => {
V a_2578 = default;
V b_2580 = default;
{ V _t2576 = ListOf(_a2572);
{ V _t2577 = GetIdx(_t2576, 0D);
a_2578 = _t2577; }
{ V _t2579 = GetIdx(_t2576, 1D);
b_2580 = _t2579; }
}
return Invoke(o_2569, "push", Call(box_12, V.Undef, ((V)((ToNum(a_2578) * ((W_2546 / 2D) - 1.8)))), ((V)(6D)), ((V)((ToNum(b_2580) * ((DD_2548 / 2D) - 1.8)))), ((V)(3.6)), ((V)((H_2547 - 10D))), ((V)(3.6)), FR_2549, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
}, 1, "", true));
Invoke(Invoke(ys_2550, "slice", ((V)(1D))), "forEach", Fn((V _arrowThis2589, int _argc2582, V y_2588, V _a2585, V _a2586, V _a2587, V[] _rest2583) => {
return Invoke(o_2569, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((ToNum(y_2588) - 1.2))), ((V)((-1D))), ((V)((W_2546 - 6D))), ((V)(1.2)), ((V)((DD_2548 - 6D))), GL_29, Call(cer_35, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("op", ((V)(0.4))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((ToNum(y_2588) - 2.1))), ((V)((ZF_2551 - 5D))), ((V)((W_2546 - 8D))), ((V)(0.8)), ((V)(0.8)), ((V)("#fff1c8")), Call(em_25, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
}, 1, "", true));
Invoke(ys_2550, "forEach", Fn((V _arrowThis2598, int _argc2590, V y_2596, V j_2597, V _a2594, V _a2595, V[] _rest2591) => {
double x_2599 = 0;
double z_2600 = 0;
if (SEqN(j_2597, 4D)) {
return default;
}
x_2599 = (((-W_2546) / 2D) + 6D);
z_2600 = (-4D);
Invoke(o_2569, "push", Call(box_12, V.Undef, ((V)((((-W_2546) / 2D) + 26D))), y_2596, ((V)((z_2600 + 2D))), ((V)(12D)), ((V)(2D)), ((V)(6D)), ((V)("#2c2d31")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(slab_15, V.Undef, ((V)((((-W_2546) / 2D) + 26D))), Add(y_2596, ((V)(2D))), ((V)((z_2600 + 2D))), ((V)(15D)), ((V)(21D)), ((V)(1.6)), GetIdx(STEEL_2552, ((ToNum(j_2597) * 3D) % 8D)), Call(mt_33, V.Undef, NewObj(2).Put("r", ((V)(0.8))).Put("shine", ((V)(1D))).V)), Call(disc_18, V.Undef, ((V)(((((-W_2546) / 2D) + 26D) + (NumTruthy((ToNum(j_2597) % 2D)) ? 3D : (-3D))))), Add(y_2596, ((V)(14D))), ((V)((z_2600 + 2.9))), ((V)(3.6)), ((V)(0.3)), GetK(Arr(((V)("#ffd66b")), ((V)("#e8fdff")), ((V)("#ff9d4a")), ((V)("#a6f06a"))), j_2597), NewObj(2).Put("noOut", ((V)(1D))).Put("n", ((V)(14D))).V), Call(box_12, V.Undef, ((V)((((-W_2546) / 2D) + 26D))), Add(y_2596, ((V)(5D))), ((V)((z_2600 + 2.95))), ((V)(11D)), ((V)(1.6)), ((V)(0.3)), ((V)("#14151a")), NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V));
x_2599 = (((-W_2546) / 2D) + 36D);
while ((x_2599 < ((W_2546 / 2D) - 6D))) {
double w_2601 = 0;
V col_2602 = default;
w_2601 = (1.5 + (ToNum(Call(R_2568, V.Undef)) * 0.5));
col_2602 = GetIdx(STEEL_2552, System.Math.Floor((ToNum(Call(R_2568, V.Undef)) * 8D)));
Invoke(o_2569, "push", Call(box_12, V.Undef, ((V)((x_2599 + (w_2601 / 2D)))), y_2596, ((V)(z_2600)), ((V)(w_2601)), ((V)(19D)), ((V)(13.5)), col_2602, Call(mt_33, V.Undef, NewObj(2).Put("r", ((V)(0.3))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((x_2599 + (w_2601 / 2D)))), Add(y_2596, ((V)(14D))), ((V)((z_2600 + 6.9))), ((V)((w_2601 * 0.7))), ((V)(2.6)), ((V)(0.3)), ((V)((LtN(Call(R_2568, V.Undef), 0.5) ? "#ffffff" : "#14151a"))), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
x_2599 = (x_2599 + (w_2601 + 0.25));
}
return default;
}, 2, "", true));
Invoke(ys_2550, "forEach", Fn((V _arrowThis2610, int _argc2603, V y_2609, V _a2606, V _a2607, V _a2608, V[] _rest2604) => {
return Invoke(o_2569, "push", Call(cyl_13, V.Undef, ((V)((-20D))), Add(y_2609, ((V)(26.6))), ((V)((-6D))), ((V)(1.8)), ((V)(0.8)), ((V)("#fff6dc")), Call(em_25, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(cyl_13, V.Undef, ((V)(20D)), Add(y_2609, ((V)(26.6))), ((V)((-6D))), ((V)(1.8)), ((V)(0.8)), ((V)("#fff6dc")), Call(em_25, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)));
}, 1, "", true));
Invoke(o_2569, "push", Call(slab_15, V.Undef, ((V)(((-W_2546) / 4D))), ((V)(6D)), ((V)((ZF_2551 - 0.4))), ((V)(((W_2546 / 2D) - 2D))), ((V)((H_2547 - 10D))), ((V)(0.8)), GL_29, Call(cer_35, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("op", ((V)(0.14))).V)), Call(slab_15, V.Undef, ((V)((W_2546 / 4D))), ((V)(6D)), ((V)((ZF_2551 - 0.4))), ((V)(((W_2546 / 2D) - 2D))), ((V)((H_2547 - 10D))), ((V)(0.8)), GL_29, Call(cer_35, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("op", ((V)(0.14))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2618, int _argc2611, V sg_2617, V _a2614, V _a2615, V _a2616, V[] _rest2612) => {
return Invoke(o_2569, "push", Call(box_12, V.Undef, ((V)((ToNum(sg_2617) * 0.9))), ((V)(6D)), ((V)((ZF_2551 + 0.2))), ((V)(1.8)), ((V)((H_2547 - 10D))), ((V)(1.8)), FR_2549, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(cyl_13, V.Undef, ((V)((ToNum(sg_2617) * 4D))), ((V)(50D)), ((V)((ZF_2551 + 2.2))), ((V)(0.7)), ((V)(60D)), ((V)("#d4a548")), Call(mt_33, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((ToNum(sg_2617) * 4D))), ((V)(50D)), ((V)((ZF_2551 + 0.6))), ((V)(1.2)), ((V)(1.2)), ((V)(2.2)), ((V)("#d4a548")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_12, V.Undef, ((V)((ToNum(sg_2617) * 4D))), ((V)(109D)), ((V)((ZF_2551 + 0.6))), ((V)(1.2)), ((V)(1.2)), ((V)(2.2)), ((V)("#d4a548")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
}, 1, "", true));
return o_2569;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2626, int _argc2619, V c_2625, V _a2622, V _a2623, V _a2624, V[] _rest2620) => {
V p_2627 = default;
double w_2628 = 0;
double h_2629 = 0;
V cl_2630 = default;
JsStrBuf f_2631 = null;
p_2627 = Get(c_2625, "p");
w_2628 = ((W_2546 / 2D) - 2D);
h_2629 = (H_2547 - 10D);
cl_2630 = Call(clipR_62, V.Undef, ((V)(w_2628)), ((V)(h_2629)), ((V)(0.6)));
f_2631 = new JsStrBuf("");
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2640, int _argc2632, V sg_2638, V i_2639, V _a2636, V _a2637, V[] _rest2633) => {
V cl2_2641 = default;
cl2_2641 = Call(clipR_62, V.Undef, ((V)(w_2628)), ((V)(h_2629)), ((V)(0.6)));
f_2631.S("<g transform=\"").V(Call(plane_44, V.Undef, p_2627, ((V)((ZF_2551 + 0.1))), ((V)((H_2547 - 4D))), ((V)((LtN(sg_2638, 0D) ? (((-W_2546) / 2D) + 1D) : 1D))))).S("\"><defs>").V(Get(cl2_2641, "d")).S("</defs><g clip-path=\"url(#").V(Get(cl2_2641, "id")).S(")\"><rect x=\"-40\" y=\"0\" width=\"").N((w_2628 + 80D)).S("\" height=\"").N(h_2629).S("\" fill=\"url(#p3glass)\" opacity=\"0.8\">").V(Call(atS_55, V.Undef, ((V)("translate")), ((V)("-30 0;30 0;-30 0")), ((V)(9D)), ((V)(((-ToNum(i_2639)) * 3D))))).S("</rect><path d=\"M2 2V").N((h_2629 - 2D)).S("\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.45\"/></g></g>");
return default;
}, 2, "", true));
return NewObj(2).Put("defs", PATS_60).Put("front", ((V)(f_2631.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "awardSet", Fn((V _arrowThis2649, int _argc2642, V S_2648, V _a2645, V _a2646, V _a2647, V[] _rest2643) => {
V G_2650 = default;
V gm_2651 = default;
G_2650 = ((V)("#e8b830"));
gm_2651 = Fn((V _arrowThis2659, int _argc2652, V o_2658, V _a2655, V _a2656, V _a2657, V[] _rest2653) => {
return Call(mt_33, V.Undef, Object_assign(NewObj(1).Put("shine", ((V)(1D))).V, (o_2658 is var _t2660 && Truthy(_t2660) ? _t2660 : NewObj(0).V)));
}, 1, "", true);
return NewObj(5).Put("w", ((V)(56D))).Put("d", ((V)(36D))).Put("small", ((V)(1D))).Put("build", Fn((V _arrowThis2668, int _argc2661, V P_2667, V _a2664, V _a2665, V _a2666, V[] _rest2662) => {
V o_2669 = default;
o_2669 = Arr();
Invoke(o_2669, "push", Call(cyl_13, V.Undef, ((V)(8D)), ((V)(0D)), ((V)(4D)), ((V)(15D)), ((V)(1.2)), ((V)("#c9ced3")), Call(mt_33, V.Undef, NewObj(3).Put("rz", ((V)(9D))).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).V)));
Invoke(o_2669, "push", Call(box_12, V.Undef, ((V)((-14D))), ((V)(0D)), ((V)((-2D))), ((V)(16D)), ((V)(6D)), ((V)(14D)), ((V)("#16161a")), Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((-14D))), ((V)(6D)), ((V)((-2D))), ((V)(12D)), ((V)(3D)), ((V)(10D)), ((V)("#22222a")), Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(slab_15, V.Undef, ((V)((-14D))), ((V)(1.4)), ((V)(5.3)), ((V)(9D)), ((V)(3.2)), ((V)(0.4)), G_2650, Call(gm_2651, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
Invoke(o_2669, "push", Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(9D)), ((V)((-2D))), ((V)(2.8)), ((V)(1.4)), G_2650, Call(gm_2651, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(10.4)), ((V)((-2D))), ((V)(2.4)), ((V)(14D)), G_2650, Call(gm_2651, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.15))), Arr(((V)(8D)), ((V)(0D)), ((V)(0.75))), Arr(((V)(14D)), ((V)(0D)), ((V)(0.85))))).V)), Call(cyl_13, V.Undef, ((V)((-14D))), ((V)(24.4)), ((V)((-2D))), ((V)(2.1)), ((V)(6D)), G_2650, Call(gm_2651, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(3D)), ((V)(0D)), ((V)(1.2))), Arr(((V)(6D)), ((V)(0D)), ((V)(0.9))))).V)), Call(ball_14, V.Undef, ((V)((-14D))), ((V)(30.2)), ((V)((-2D))), ((V)(2.1)), G_2650, Call(gm_2651, V.Undef, NewObj(2).Put("k", ((V)(6D))).Put("n", ((V)(12D))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2677, int _argc2670, V sg_2676, V _a2673, V _a2674, V _a2675, V[] _rest2671) => {
return Invoke(o_2669, "push", Call(cyl_13, V.Undef, ((V)(((-14D) + (ToNum(sg_2676) * 2.6)))), ((V)(27D)), ((V)((-2D))), ((V)(0.75)), ((V)(9D)), G_2650, Call(gm_2651, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(ball_14, V.Undef, ((V)(((-14D) + (ToNum(sg_2676) * 2.6)))), ((V)(35.6)), ((V)((-2D))), ((V)(0.9)), G_2650, Call(gm_2651, V.Undef, NewObj(1).Put("k", ((V)(3D))).V)));
}, 1, "", true));
InvokeSpread(o_2669, "push", new ArrBuilder().Add(Call(disc_18, V.Undef, ((V)((-14D))), ((V)(41D)), ((V)((-2.6))), ((V)(5.4)), ((V)(1.4)), G_2650, Call(gm_2651, V.Undef, NewObj(1).Put("n", ((V)(18D))).V))).Spread(Call(rep_38, V.Undef, ((V)(5D)), Fn((V _arrowThis2685, int _argc2678, V i_2684, V _a2681, V _a2682, V _a2683, V[] _rest2679) => {
double a_2686 = 0;
a_2686 = ((((ToNum(i_2684) * 2D) * PI_30) / 5D) - (PI_30 / 2D));
return Call(disc_18, V.Undef, ((V)(((-14D) + (FdLibm.Cos(a_2686) * 3D)))), ((V)((41D + (FdLibm.Sin(a_2686) * 3D)))), ((V)((-1.15))), ((V)(1.1)), ((V)(0.2)), ((V)("#7a5414")), NewObj(2).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V);
return default;
}, 1, "", true))).Add(Call(disc_18, V.Undef, ((V)((-14D))), ((V)(41D)), ((V)((-1.1))), ((V)(1D)), ((V)(0.3)), ((V)("#fff1b0")), NewObj(2).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).V)).V);
Invoke(o_2669, "push", Call(cyl_13, V.Undef, ((V)(10D)), ((V)(1.2)), ((V)(0D)), ((V)(6.2)), ((V)(15D)), GL_29, Call(cer_35, V.Undef, NewObj(3).Put("n", ((V)(8D))).Put("op", ((V)(0.34))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.86))), Arr(((V)(2D)), ((V)(0D)), ((V)(1D))), Arr(((V)(10D)), ((V)(0D)), ((V)(1D))), Arr(((V)(13D)), ((V)(0D)), ((V)(0.55))), Arr(((V)(15D)), ((V)(0D)), ((V)(0.32))))).V)), Call(cyl_13, V.Undef, ((V)(10D)), ((V)(1.6)), ((V)(0D)), ((V)(5.4)), ((V)(9.4)), ((V)("#c27a2a")), NewObj(2).Put("n", ((V)(8D))).Put("op", ((V)(0.75))).V), Call(cyl_13, V.Undef, ((V)(10D)), ((V)(16.2)), ((V)(0D)), ((V)(1.9)), ((V)(3.6)), GL_29, Call(cer_35, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("op", ((V)(0.45))).V)), Call(ball_14, V.Undef, ((V)(10D)), ((V)(19.6)), ((V)(0D)), ((V)(2.6)), ((V)("#e8f6ff")), Call(cer_35, V.Undef, NewObj(4).Put("n", ((V)(8D))).Put("k", ((V)(3D))).Put("sy", ((V)(1.25))).Put("op", ((V)(0.65))).V)));
Invoke(Arr(Arr(((V)(2D)), ((V)(9D))), Arr(((V)(18D)), ((V)(8D)))), "forEach", Fn((V _arrowThis2698, int _argc2687, V _a2689, V _a2690, V _a2691, V _a2692, V[] _rest2688) => {
V x_2695 = default;
V z_2697 = default;
{ V _t2693 = ListOf(_a2689);
{ V _t2694 = GetIdx(_t2693, 0D);
x_2695 = _t2694; }
{ V _t2696 = GetIdx(_t2693, 1D);
z_2697 = _t2696; }
}
return Invoke(o_2669, "push", Call(cyl_13, V.Undef, x_2695, ((V)(1.2)), z_2697, ((V)(3D)), ((V)(5.4)), GL_29, Call(cer_35, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("op", ((V)(0.35))).V)), Call(cyl_13, V.Undef, x_2695, ((V)(1.6)), z_2697, ((V)(2.6)), ((V)(1.8)), ((V)("#c27a2a")), NewObj(2).Put("n", ((V)(8D))).Put("op", ((V)(0.8))).V), Call(box_12, V.Undef, Add(x_2695, ((V)(0.6))), ((V)(3.4)), ((V)((ToNum(z_2697) - 0.4))), ((V)(1.6)), ((V)(1.4)), ((V)(1.6)), ((V)("#eaf6ff")), Call(cer_35, V.Undef, NewObj(2).Put("op", ((V)(0.6))).Put("r", ((V)(0.3))).V)));
}, 1, "", true));
return o_2669;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2706, int _argc2699, V c_2705, V _a2702, V _a2703, V _a2704, V[] _rest2700) => {
V p_2707 = default;
V k_2708 = default;
JsStrBuf f_2709 = null;
p_2707 = Get(c_2705, "p");
k_2708 = Get(c_2705, "k");
f_2709 = new JsStrBuf("");
Invoke(Arr(Arr(((V)(10D)), ((V)(6D)), ((V)(6.1))), Arr(((V)(10D)), ((V)(10D)), ((V)(6.1)))), "forEach", Fn((V _arrowThis2724, int _argc2710, V _a2712, V i_2716, V _a2714, V _a2715, V[] _rest2711) => {
V a_2725 = default;
V b_2726 = default;
V x_2719 = default;
V y_2721 = default;
V z_2723 = default;
{ V _t2717 = ListOf(_a2712);
{ V _t2718 = GetIdx(_t2717, 0D);
x_2719 = _t2718; }
{ V _t2720 = GetIdx(_t2717, 1D);
y_2721 = _t2720; }
{ V _t2722 = GetIdx(_t2717, 2D);
z_2723 = _t2722; }
}
a_2725 = Call(p_2707, V.Undef, ((V)((ToNum(x_2719) - 2D))), y_2721, z_2723);
b_2726 = Call(p_2707, V.Undef, ((V)((ToNum(x_2719) - 2D))), Add(y_2721, ((V)(7D))), z_2723);
f_2709.S("<path d=\"M").V(Call(P2_42, V.Undef, a_2725)).S("L").V(Call(P2_42, V.Undef, b_2726)).S("\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(k_2708)))))).S("\" opacity=\"0.7\"/>");
return default;
}, 2, "", true));
Invoke(Arr(Arr(((V)((-14D))), ((V)(44D)), ((V)(0D))), Arr(((V)((-16D))), ((V)(28D)), ((V)(1D))), Arr(((V)(10D)), ((V)(21D)), ((V)(2D)))), "forEach", Fn((V _arrowThis2739, int _argc2727, V _a2729, V i_2733, V _a2731, V _a2732, V[] _rest2728) => {
V q_2740 = default;
V x_2736 = default;
V y_2738 = default;
{ V _t2734 = ListOf(_a2729);
{ V _t2735 = GetIdx(_t2734, 0D);
x_2736 = _t2735; }
{ V _t2737 = GetIdx(_t2734, 1D);
y_2738 = _t2737; }
}
q_2740 = Call(p_2707, V.Undef, x_2736, y_2738, ((V)(2D)));
f_2709.S("<g transform=\"translate(").V(Call(P2_42, V.Undef, q_2740)).S(") scale(").V(Call(f1_23, V.Undef, ((V)((ToNum(k_2708) * 0.7))))).S(")\"><path d=\"M0 -4L1 -1L4 0L1 1L0 4L-1 1L-4 0L-1 -1Z\" fill=\"#ffffff\" opacity=\"0\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0;1;0;0")), ((V)(2.2)), ((V)(((-ToNum(i_2733)) * 0.7))))).S("</path></g>");
return default;
}, 2, "", true));
return NewObj(1).Put("front", ((V)(f_2709.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "shearChair", Fn((V _arrowThis2748, int _argc2741, V S_2747, V _a2744, V _a2745, V _a2746, V[] _rest2742) => {
V WAL_2749 = default;
V SHE_2750 = default;
V nv_2751 = default;
V F0_2752 = default;
V F1_2753 = default;
V add_2754 = default;
V B0_2755 = default;
V B1_2756 = default;
V side_2757 = default;
WAL_2749 = ((V)("#5b3820"));
SHE_2750 = ((V)("#efe6d6"));
nv_2751 = Arr(((V)(0.958)), ((V)(0.29)));
F0_2752 = Arr(((V)((-22D))), ((V)(30D)));
F1_2753 = Arr(((V)((-36D))), ((V)(76D)));
add_2754 = Fn((V _arrowThis2767, int _argc2758, V a_2764, V b_2765, V k_2766, V _a2763, V[] _rest2759) => {
return Arr(Add(GetIdx(a_2764, 0D), ((V)((ToNum(GetIdx(b_2765, 0D)) * ToNum(k_2766))))), Add(GetIdx(a_2764, 1D), ((V)((ToNum(GetIdx(b_2765, 1D)) * ToNum(k_2766))))));
}, 3, "", true);
B0_2755 = Call(add_2754, V.Undef, F0_2752, nv_2751, ((V)((-9D))));
B1_2756 = Call(add_2754, V.Undef, F1_2753, nv_2751, ((V)((-9D))));
side_2757 = Fn((V _arrowThis2775, int _argc2768, V sg_2774, V _a2771, V _a2772, V _a2773, V[] _rest2769) => {
double x0_2776 = 0;
double x1_2777 = 0;
double a_2778 = 0;
double b_2779 = 0;
x0_2776 = (ToNum(sg_2774) * 34D);
x1_2777 = (ToNum(sg_2774) * 39D);
a_2778 = Min(x0_2776, x1_2777);
b_2779 = Max(x0_2776, x1_2777);
return Arr(Call(prism_19, V.Undef, ((V)(a_2778)), ((V)(b_2779)), Arr(Arr(((V)((-34D))), ((V)(0D))), Arr(((V)(36D)), ((V)(0D))), Arr(((V)(38D)), ((V)(4D))), Arr(((V)((-36D))), ((V)(4D)))), WAL_2749, Call(wd_34, V.Undef)), Call(prism_19, V.Undef, ((V)(a_2778)), ((V)(b_2779)), Arr(Arr(((V)(22D)), ((V)(4D))), Arr(((V)(30D)), ((V)(4D))), Arr(((V)(27D)), ((V)(31D))), Arr(((V)(19D)), ((V)(31D)))), WAL_2749, Call(wd_34, V.Undef)), Call(prism_19, V.Undef, ((V)(a_2778)), ((V)(b_2779)), Arr(Arr(((V)((-31D))), ((V)(4D))), Arr(((V)((-23D))), ((V)(4D))), Arr(((V)((-19D))), ((V)(31D))), Arr(((V)((-27D))), ((V)(31D)))), WAL_2749, Call(wd_34, V.Undef)), Call(prism_19, V.Undef, ((V)((a_2778 - 0.5))), ((V)((b_2779 + 0.5))), Arr(Arr(((V)((-30D))), ((V)(31D))), Arr(((V)(34D)), ((V)(33D))), Arr(((V)(36D)), ((V)(37D))), Arr(((V)(34D)), ((V)(39D))), Arr(((V)((-31D))), ((V)(37D)))), Call(shade_21, V.Undef, WAL_2749, ((V)(1.08))), Call(wd_34, V.Undef)), Call(prism_19, V.Undef, ((V)(a_2778)), ((V)(b_2779)), Arr(Call(add_2754, V.Undef, B0_2755, nv_2751, ((V)((-3.4)))), Call(add_2754, V.Undef, B1_2756, nv_2751, ((V)((-3.4)))), Call(add_2754, V.Undef, B1_2756, nv_2751, ((V)(0.6))), Call(add_2754, V.Undef, B0_2755, nv_2751, ((V)(0.6)))), WAL_2749, Call(wd_34, V.Undef)));
return default;
}, 1, "", true);
return NewObj(7).Put("w", ((V)(84D))).Put("d", ((V)(92D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(4D))).Put("h", ((V)(34D))).V)).Put("build", Fn((V _arrowThis2787, int _argc2780, V P_2786, V _a2783, V _a2784, V _a2785, V[] _rest2781) => {
return Arr();
}, 1, "build", true)).Put("layers", Arr(NewObj(2).Put("back", ((V)(1D))).Put("build", Fn((V _arrowThis2795, int _argc2788, V P_2794, V _a2791, V _a2792, V _a2793, V[] _rest2789) => {
return Call(side_2757, V.Undef, ((V)((-1D))));
}, 1, "build", true)).V, NewObj(3).Put("back", ((V)(1D))).Put("build", Fn((V _arrowThis2803, int _argc2796, V P_2802, V _a2799, V _a2800, V _a2801, V[] _rest2797) => {
return Arr(Call(prism_19, V.Undef, ((V)((-34D))), ((V)(34D)), Arr(Arr(((V)((-28D))), ((V)(14D))), Arr(((V)(32D)), ((V)(18D))), Arr(((V)(32D)), ((V)(22D))), Arr(((V)((-28D))), ((V)(18D)))), WAL_2749, Call(wd_34, V.Undef)), Call(prism_19, V.Undef, ((V)((-35D))), ((V)(35D)), Arr(Call(add_2754, V.Undef, B0_2755, nv_2751, ((V)((-3D)))), Call(add_2754, V.Undef, B1_2756, nv_2751, ((V)((-3D)))), B1_2756, B0_2755), WAL_2749, Call(wd_34, V.Undef)), Call(prism_19, V.Undef, ((V)((-33D))), ((V)(33D)), Arr(Arr(((V)((-26D))), ((V)(18D))), Arr(((V)(31D)), ((V)(22D))), Arr(((V)(33D)), ((V)(30D))), Arr(((V)(30D)), ((V)(33.5))), Arr(((V)((-26D))), ((V)(30D)))), SHE_2750, Call(fb_36, V.Undef)), Call(solid_11, V.Undef, Call(fb_36, V.Undef, NewObj(8).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(30.5)), ((V)(28D)))).Put("a", ((V)(4.2))).Put("b", ((V)(4.8))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)((-33D))), ((V)(0D)), ((V)(0.8))), Arr(((V)((-31D))), ((V)(0D)), ((V)(1D))), Arr(((V)(31D)), ((V)(0D)), ((V)(1D))), Arr(((V)(33D)), ((V)(0D)), ((V)(0.8))))).Put("col", Call(mix_22, V.Undef, SHE_2750, ((V)("#ffffff")), ((V)(0.15)))).V)), Call(prism_19, V.Undef, ((V)((-32D))), ((V)(32D)), Arr(F0_2752, F1_2753, B1_2756, B0_2755), SHE_2750, Call(fb_36, V.Undef)), Call(solid_11, V.Undef, Call(fb_36, V.Undef, NewObj(8).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((ToNum(GetIdx(F1_2753, 0D)) - 3D))), ((V)((ToNum(GetIdx(F1_2753, 1D)) - 3D))))).Put("a", ((V)(6D))).Put("b", ((V)(5D))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)((-32D))), ((V)(0D)), ((V)(0.8))), Arr(((V)((-30D))), ((V)(0D)), ((V)(1D))), Arr(((V)(30D)), ((V)(0D)), ((V)(1D))), Arr(((V)(32D)), ((V)(0D)), ((V)(0.8))))).Put("col", Call(mix_22, V.Undef, SHE_2750, ((V)("#ffffff")), ((V)(0.12)))).V)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis2812, int _argc2804, V p_2810, V s_2811, V _a2808, V _a2809, V[] _rest2805) => {
return Call(tex_59, V.Undef, s_2811, Arr(Arr(((V)("p3she")), ((V)(1D))), Arr(((V)("p3vel")), ((V)(0.3)))));
}, 2, "wrap", true)).V, NewObj(1).Put("build", Fn((V _arrowThis2820, int _argc2813, V P_2819, V _a2816, V _a2817, V _a2818, V[] _rest2814) => {
return Call(side_2757, V.Undef, ((V)(1D)));
}, 1, "build", true)).V)).Put("fx", Fn((V _arrowThis2827, int _argc2821, V _a2823, V _a2824, V _a2825, V _a2826, V[] _rest2822) => {
return NewObj(1).Put("defs", PATS_60).V;
}, 0, "fx", true)).V;
return default;
}, 1, "", true));
apple_75 = Fn((V _arrowThis2839, int _argc2828, V x_2834, V y_2835, V z_2836, V col_2837, V[] _rest2829) => {
V s_2838 = default;
s_2838 = (_argc2828 > 4 ? _rest2829[0] : V.Undef);
s_2838 = (s_2838 is var _t2840 && Truthy(_t2840) ? _t2840 : ((V)(1D)));
return Arr(Call(ball_14, V.Undef, x_2834, y_2835, z_2836, ((V)((5.2 * ToNum(s_2838)))), col_2837, NewObj(3).Put("sy", ((V)(0.9))).Put("k", ((V)(6D))).Put("n", ((V)(14D))).V), Call(cyl_13, V.Undef, x_2834, Add(y_2835, ((V)((9D * ToNum(s_2838))))), z_2836, ((V)(0.5)), ((V)((2.6 * ToNum(s_2838)))), ((V)("#5a3a20")), NewObj(1).Put("n", ((V)(4D))).V), Call(ball_14, V.Undef, Add(x_2834, ((V)((1.8 * ToNum(s_2838))))), Add(y_2835, ((V)((10.4 * ToNum(s_2838))))), z_2836, ((V)((1.8 * ToNum(s_2838)))), ((V)("#5fa84a")), NewObj(4).Put("sx", ((V)(1.5))).Put("sy", ((V)(0.35))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V));
return default;
}, 5, "", true);
orange_76 = Fn((V _arrowThis2851, int _argc2841, V x_2847, V y_2848, V z_2849, V s_2850, V[] _rest2842) => {
s_2850 = (s_2850 is var _t2852 && Truthy(_t2852) ? _t2852 : ((V)(1D)));
return Arr(Call(ball_14, V.Undef, x_2847, y_2848, z_2849, ((V)((5.4 * ToNum(s_2850)))), ((V)("#f2932c")), NewObj(2).Put("k", ((V)(6D))).Put("n", ((V)(14D))).V), Call(ball_14, V.Undef, x_2847, Add(y_2848, ((V)((10.4 * ToNum(s_2850))))), z_2849, ((V)((0.9 * ToNum(s_2850)))), ((V)("#6a8a3a")), NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V));
return default;
}, 4, "", true);
straw_77 = Fn((V _arrowThis2863, int _argc2853, V x_2859, V y_2860, V z_2861, V s_2862, V[] _rest2854) => {
s_2862 = (s_2862 is var _t2864 && Truthy(_t2864) ? _t2864 : ((V)(1D)));
return Arr(Call(ball_14, V.Undef, x_2859, y_2860, z_2861, ((V)((2.4 * ToNum(s_2862)))), ((V)("#d9283b")), NewObj(3).Put("sy", ((V)(1.2))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V), Call(ball_14, V.Undef, x_2859, Add(y_2860, ((V)((5.2 * ToNum(s_2862))))), z_2861, ((V)((1.9 * ToNum(s_2862)))), ((V)("#4f9a3a")), NewObj(4).Put("sy", ((V)(0.35))).Put("k", ((V)(2D))).Put("n", ((V)(8D))).Put("shine", ((V)(0D))).V));
return default;
}, 4, "", true);
grapes_78 = Fn((V _arrowThis2875, int _argc2865, V x_2871, V y_2872, V z_2873, V col_2874, V[] _rest2866) => {
V o_2876 = default;
o_2876 = Arr();
Invoke(Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0D))), Arr(((V)(2.6)), ((V)(0D)), ((V)(1D))), Arr(((V)((-2.6))), ((V)(0D)), ((V)(1D))), Arr(((V)(1.3)), ((V)(2.3)), ((V)(0D))), Arr(((V)((-1.3))), ((V)(2.3)), ((V)(0D))), Arr(((V)(0D)), ((V)(4.4)), ((V)(1D))), Arr(((V)(1.4)), ((V)((-2.2))), ((V)(1D))), Arr(((V)((-1.4))), ((V)((-2.2))), ((V)(0D)))), "forEach", Fn((V _arrowThis2890, int _argc2877, V _a2879, V _a2880, V _a2881, V _a2882, V[] _rest2878) => {
V dx_2885 = default;
V dy_2887 = default;
V dz_2889 = default;
{ V _t2883 = ListOf(_a2879);
{ V _t2884 = GetIdx(_t2883, 0D);
dx_2885 = _t2884; }
{ V _t2886 = GetIdx(_t2883, 1D);
dy_2887 = _t2886; }
{ V _t2888 = GetIdx(_t2883, 2D);
dz_2889 = _t2888; }
}
return Invoke(o_2876, "push", Call(ball_14, V.Undef, Add(x_2871, dx_2885), ((V)((ToNum(Add(y_2872, ((V)(6D)))) - ToNum(dy_2887)))), Add(z_2873, ((V)((ToNum(dz_2889) * 1.8)))), ((V)(1.9)), col_2874, NewObj(2).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V));
}, 1, "", true));
Invoke(o_2876, "push", Call(cyl_13, V.Undef, x_2871, Add(y_2872, ((V)(12.4))), z_2873, ((V)(0.4)), ((V)(2.4)), ((V)("#6b4a20")), NewObj(1).Put("n", ((V)(4D))).V));
return o_2876;
return default;
}, 4, "", true);
kiwi_79 = Fn((V _arrowThis2900, int _argc2891, V x_2897, V y_2898, V z_2899, V _a2896, V[] _rest2892) => {
return Arr(Call(cyl_13, V.Undef, x_2897, y_2898, z_2899, ((V)(3.8)), ((V)(1.6)), ((V)("#8a6a3a")), NewObj(1).Put("n", ((V)(14D))).V), Call(cyl_13, V.Undef, x_2897, Add(y_2898, ((V)(1.6))), z_2899, ((V)(3.4)), ((V)(0.3)), ((V)("#8fc23a")), NewObj(1).Put("n", ((V)(14D))).V), Call(cyl_13, V.Undef, x_2897, Add(y_2898, ((V)(1.9))), z_2899, ((V)(1.2)), ((V)(0.2)), ((V)("#f4f2d6")), NewObj(2).Put("n", ((V)(10D))).Put("noOut", ((V)(1D))).V));
}, 3, "", true);
can_80 = Fn((V _arrowThis2911, int _argc2901, V x_2907, V y_2908, V z_2909, V col_2910, V[] _rest2902) => {
return Arr(Call(cyl_13, V.Undef, x_2907, y_2908, z_2909, ((V)(2.3)), ((V)(7.6)), col_2910, Call(mt_33, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, x_2907, Add(y_2908, ((V)(7.6))), z_2909, ((V)(2D)), ((V)(0.6)), ((V)("#d5dde2")), Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
}, 4, "", true);
cakeSlice_81 = Fn((V _arrowThis2923, int _argc2912, V x_2918, V y_2919, V z_2920, V c1_2921, V[] _rest2913) => {
V c2_2922 = default;
c2_2922 = (_argc2912 > 4 ? _rest2913[0] : V.Undef);
return new ArrBuilder().Add(Call(prism_19, V.Undef, ((V)((ToNum(x_2918) - 3D))), Add(x_2918, ((V)(3D))), Arr(Arr(((V)((ToNum(z_2920) - 4D))), y_2919), Arr(Add(z_2920, ((V)(4D))), y_2919), Arr(Add(z_2920, ((V)(4D))), Add(y_2919, ((V)(3.4)))), Arr(((V)((ToNum(z_2920) - 4D))), Add(y_2919, ((V)(3.4))))), c1_2921, Call(pt_37, V.Undef))).Add(Call(prism_19, V.Undef, ((V)((ToNum(x_2918) - 3D))), Add(x_2918, ((V)(3D))), Arr(Arr(((V)((ToNum(z_2920) - 4D))), Add(y_2919, ((V)(3.4)))), Arr(Add(z_2920, ((V)(4D))), Add(y_2919, ((V)(3.4)))), Arr(Add(z_2920, ((V)(4D))), Add(y_2919, ((V)(4.4)))), Arr(((V)((ToNum(z_2920) - 4D))), Add(y_2919, ((V)(4.4))))), ((V)("#fff6ea")), Call(pt_37, V.Undef))).Add(Call(prism_19, V.Undef, ((V)((ToNum(x_2918) - 3D))), Add(x_2918, ((V)(3D))), Arr(Arr(((V)((ToNum(z_2920) - 4D))), Add(y_2919, ((V)(4.4)))), Arr(Add(z_2920, ((V)(4D))), Add(y_2919, ((V)(4.4)))), Arr(Add(z_2920, ((V)(4D))), Add(y_2919, ((V)(7.4)))), Arr(((V)((ToNum(z_2920) - 4D))), Add(y_2919, ((V)(7.4))))), c1_2921, Call(pt_37, V.Undef))).Add(Call(prism_19, V.Undef, ((V)((ToNum(x_2918) - 3.2))), Add(x_2918, ((V)(3.2))), Arr(Arr(((V)((ToNum(z_2920) - 4.2))), Add(y_2919, ((V)(7.4)))), Arr(Add(z_2920, ((V)(4.2))), Add(y_2919, ((V)(7.4)))), Arr(Add(z_2920, ((V)(4D))), Add(y_2919, ((V)(8.6)))), Arr(((V)((ToNum(z_2920) - 4D))), Add(y_2919, ((V)(8.6))))), c2_2922, Call(pt_37, V.Undef))).Spread(Call(straw_77, V.Undef, x_2918, Add(y_2919, ((V)(8.6))), z_2920, ((V)(0.55)))).V;
}, 5, "", true);
Set(RD_8, "FOOD3", NewObj(7).Put("apple", apple_75).Put("orange", orange_76).Put("straw", straw_77).Put("grapes", grapes_78).Put("kiwi", kiwi_79).Put("can", can_80).Put("cakeSlice", cakeSlice_81).V);
Set(N_24, "smartConsole", Fn((V _arrowThis2931, int _argc2924, V S_2930, V _a2927, V _a2928, V _a2929, V[] _rest2925) => {
double W_2932 = 0;
double D2_2933 = 0;
double TH_2934 = 0;
V BODY_2935 = default;
V TOPC_2936 = default;
V FRZ_2937 = default;
W_2932 = 132D;
D2_2933 = 62D;
TH_2934 = 40D;
BODY_2935 = ((V)("#2b2d33"));
TOPC_2936 = ((V)("#1d2027"));
FRZ_2937 = ((V)("#e8f6ff"));
return NewObj(6).Put("w", ((V)((W_2932 + 6D)))).Put("d", ((V)((D2_2933 + 6D)))).Put("topH", ((V)((TH_2934 + 1D)))).Put("topW", ((V)(50D))).Put("build", Fn((V _arrowThis2945, int _argc2938, V P_2944, V _a2941, V _a2942, V _a2943, V[] _rest2939) => {
V o_2946 = default;
double z0_2947 = 0;
double z1_2948 = 0;
V cc_2949 = default;
o_2946 = Arr();
z0_2947 = ((-D2_2933) / 2D);
z1_2948 = (D2_2933 / 2D);
Invoke(o_2946, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((W_2932 - 10D))), ((V)(4D)), ((V)((D2_2933 - 8D))), ((V)("#141519")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)((((-D2_2933) / 2D) + 2D))), ((V)(W_2932)), ((V)(33D)), ((V)(4D)), BODY_2935, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2957, int _argc2950, V sg_2956, V _a2953, V _a2954, V _a2955, V[] _rest2951) => {
return Invoke(o_2946, "push", Call(box_12, V.Undef, ((V)((ToNum(sg_2956) * ((W_2932 / 2D) - 2D)))), ((V)(4D)), ((V)(0D)), ((V)(4D)), ((V)(33D)), ((V)(D2_2933)), BODY_2935, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)));
}, 1, "", true));
Invoke(o_2946, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)((W_2932 - 4D))), ((V)(2D)), ((V)((D2_2933 - 2D))), BODY_2935, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((-39D))), ((V)(20.6)), ((V)(0D)), ((V)(46D)), ((V)(1D)), ((V)((D2_2933 - 4D))), GL_29, Call(cer_35, V.Undef, NewObj(2).Put("op", ((V)(0.4))).Put("r", ((V)(0.4))).V)), Call(box_12, V.Undef, ((V)(39D)), ((V)(20.6)), ((V)(0D)), ((V)(46D)), ((V)(1D)), ((V)((D2_2933 - 4D))), GL_29, Call(cer_35, V.Undef, NewObj(2).Put("op", ((V)(0.4))).Put("r", ((V)(0.4))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)((((-D2_2933) / 2D) + 4.2))), ((V)((W_2932 - 8D))), ((V)(30D)), ((V)(0.4)), FRZ_2937, Call(em_25, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("op", ((V)(0.9))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(30D)), ((V)(21D)), ((V)((D2_2933 - 2D))), BODY_2935, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((-8.6))), ((V)(25D)), ((V)(0D)), ((V)(0.8)), ((V)(12D)), ((V)(38D)), FRZ_2937, Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_12, V.Undef, ((V)(8.6)), ((V)(25D)), ((V)(0D)), ((V)(0.8)), ((V)(12D)), ((V)(38D)), FRZ_2937, Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
cc_2949 = Arr(((V)("#d9363b")), ((V)("#3f7fc8")), ((V)("#4f9a4a")), ((V)("#f2c14a")), ((V)("#2c2d31")), ((V)("#ff9d4a")));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2966, int _argc2958, V sg_2964, V i_2965, V _a2962, V _a2963, V[] _rest2959) => {
double cx_2967 = 0;
cx_2967 = (ToNum(sg_2964) * 39D);
Call(rep_38, V.Undef, ((V)(4D)), Fn((V _arrowThis2975, int _argc2968, V j_2974, V _a2971, V _a2972, V _a2973, V[] _rest2969) => {
return InvokeSpread(o_2946, "push", new ArrBuilder().Spread(Call(can_80, V.Undef, ((V)(((cx_2967 - 16D) + (ToNum(j_2974) * 5.6)))), ((V)(6D)), ((V)(((-10D) + ((ToNum(j_2974) % 2D) * 4D)))), GetIdx(cc_2949, (ToNum(Add(j_2974, ((V)((ToNum(i_2965) * 2D))))) % 6D)))).V);
}, 1, "", true));
Invoke(o_2946, "push", Call(box_12, V.Undef, ((V)((cx_2967 + 13D))), ((V)(6D)), ((V)((-4D))), ((V)(10D)), ((V)(8D)), ((V)(6D)), ((V)((LtN(sg_2964, 0D) ? "#d9363b" : "#f2c94c"))), Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_12, V.Undef, ((V)((cx_2967 + 13D))), ((V)(14D)), ((V)((-4D))), ((V)(8D)), ((V)(4D)), ((V)(5D)), ((V)("#ffffff")), Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
if (Truthy(i_2965)) {
InvokeSpread(o_2946, "push", new ArrBuilder().Spread(Call(cakeSlice_81, V.Undef, ((V)((cx_2967 - 10D))), ((V)(21.6)), ((V)((-2D))), ((V)("#efc88a")), ((V)("#f6c6d2")))).Spread(Call(cakeSlice_81, V.Undef, ((V)((cx_2967 + 2D))), ((V)(21.6)), ((V)((-4D))), ((V)("#6b3a22")), ((V)("#3a2010")))).Spread(Call(grapes_78, V.Undef, ((V)((cx_2967 + 14D))), ((V)(21.6)), ((V)((-2D))), ((V)("#6b3a8a")))).V);
} else {
InvokeSpread(o_2946, "push", new ArrBuilder().Spread(Call(apple_75, V.Undef, ((V)((cx_2967 - 12D))), ((V)(21.6)), ((V)((-4D))), ((V)("#d9363b")), ((V)(0.9)))).Spread(Call(orange_76, V.Undef, ((V)((cx_2967 - 1D))), ((V)(21.6)), ((V)((-6D))), ((V)(0.9)))).Spread(Call(apple_75, V.Undef, ((V)((cx_2967 + 9D))), ((V)(21.6)), ((V)((-2D))), ((V)("#9fcf4a")), ((V)(0.85)))).Spread(Call(straw_77, V.Undef, ((V)((cx_2967 + 15D))), ((V)(21.6)), ((V)(2D)), ((V)(0.9)))).Spread(Call(straw_77, V.Undef, ((V)((cx_2967 + 3D))), ((V)(21.6)), ((V)(4D)), ((V)(0.8)))).V);
}
Invoke(o_2946, "push", Call(slab_15, V.Undef, ((V)(cx_2967)), ((V)(5D)), ((V)((z1_2948 - 0.6))), ((V)(46D)), ((V)(31D)), ((V)(1D)), GL_29, Call(cer_35, V.Undef, NewObj(2).Put("r", ((V)(1.2))).Put("op", ((V)(0.18))).V)), Call(box_12, V.Undef, ((V)(cx_2967)), ((V)(30D)), ((V)((z1_2948 + 0.3))), ((V)(30D)), ((V)(1.6)), ((V)(1.8)), CH_27, Call(mt_33, V.Undef, NewObj(2).Put("r", ((V)(0.8))).Put("shine", ((V)(1D))).V)));
return default;
}, 2, "", true));
Invoke(o_2946, "push", Call(slab_15, V.Undef, ((V)(0D)), ((V)(6D)), ((V)((z1_2948 - 0.6))), ((V)(26D)), ((V)(29D)), ((V)(1.2)), ((V)("#16181d")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slab_15, V.Undef, ((V)(0D)), ((V)(24D)), ((V)((z1_2948 + 0.2))), ((V)(16D)), ((V)(7D)), ((V)(0.4)), ((V)("#0e1a24")), NewObj(1).Put("r", ((V)(0.8))).V), Call(slab_15, V.Undef, ((V)(0D)), ((V)(25D)), ((V)((z1_2948 + 0.55))), ((V)(13D)), ((V)(5D)), ((V)(0.2)), ((V)("#6ac8ff")), Call(em_25, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("op", ((V)(0.85))).V)));
Invoke(o_2946, "push", Call(box_12, V.Undef, ((V)((-37D))), ((V)(37D)), ((V)(0D)), ((V)(58D)), ((V)(3D)), ((V)(D2_2933)), TOPC_2936, Call(cer_35, V.Undef, NewObj(2).Put("r", ((V)(1.5))).Put("op", ((V)(0.95))).V)), Call(box_12, V.Undef, ((V)(37D)), ((V)(37D)), ((V)(0D)), ((V)(58D)), ((V)(3D)), ((V)(D2_2933)), TOPC_2936, Call(cer_35, V.Undef, NewObj(2).Put("r", ((V)(1.5))).Put("op", ((V)(0.95))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(37D)), ((V)((((-D2_2933) / 2D) + 6D))), ((V)(16D)), ((V)(3D)), ((V)(12D)), TOPC_2936, Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(37D)), ((V)(((D2_2933 / 2D) - 6D))), ((V)(16D)), ((V)(3D)), ((V)(12D)), TOPC_2936, Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
InvokeSpread(o_2946, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(16D)), ((V)(1D)), ((V)(38D)), FRZ_2937, Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).Spread(Call(apple_75, V.Undef, ((V)((-4D))), ((V)(27D)), ((V)((-9D))), ((V)("#c42a30")), ((V)(0.7)))).Spread(Call(orange_76, V.Undef, ((V)(4D)), ((V)(27D)), ((V)((-8D))), ((V)(0.68)))).Spread(Call(grapes_78, V.Undef, ((V)((-3D))), ((V)(27D)), ((V)(4D)), ((V)("#7fb84a")))).Spread(Call(kiwi_79, V.Undef, ((V)(5D)), ((V)(27D)), ((V)(6D)))).Spread(Call(straw_77, V.Undef, ((V)((-5D))), ((V)(27D)), ((V)(12D)), ((V)(0.7)))).Spread(Call(straw_77, V.Undef, ((V)(4D)), ((V)(27D)), ((V)(13D)), ((V)(0.65)))).V);
Invoke(o_2946, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(39.6)), ((V)(0D)), ((V)(16.4)), ((V)(0.6)), ((V)(38.4)), GL_29, Call(cer_35, V.Undef, NewObj(2).Put("r", ((V)(0.4))).Put("op", ((V)(0.2))).V)));
Invoke(o_2946, "push", Call(box_12, V.Undef, ((V)((-46D))), ((V)(40D)), ((V)(4D)), ((V)(8D)), ((V)(0.6)), ((V)(15D)), ((V)("#14151a")), NewObj(1).Put("r", ((V)(1.2))).V), Call(slab_15, V.Undef, ((V)((-46D))), ((V)(40.1)), ((V)(4D)), ((V)(6.6)), ((V)(0.3)), ((V)(13D)), ((V)("#3a6ac8")), Call(em_25, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("op", ((V)(0.5))).V)));
return o_2946;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis2983, int _argc2976, V c_2982, V _a2979, V _a2980, V _a2981, V[] _rest2977) => {
V p_2984 = default;
JsStrBuf f_2985 = null;
V q_2986 = default;
p_2984 = Get(c_2982, "p");
f_2985 = new JsStrBuf("");
Invoke(Arr(Arr(((V)((-46D))), ((V)((-14D)))), Arr(((V)((-26D))), ((V)(8D))), Arr(((V)(26D)), ((V)(8D))), Arr(((V)(46D)), ((V)((-12D))))), "forEach", Fn((V _arrowThis2999, int _argc2987, V _a2989, V i_2993, V _a2991, V _a2992, V[] _rest2988) => {
V x_2996 = default;
V z_2998 = default;
{ V _t2994 = ListOf(_a2989);
{ V _t2995 = GetIdx(_t2994, 0D);
x_2996 = _t2995; }
{ V _t2997 = GetIdx(_t2994, 1D);
z_2998 = _t2997; }
}
return ((V)(f_2985.S("<g transform=\"").V(Call(planeH_46, V.Undef, p_2984, ((V)(40.2)), x_2996, z_2998)).S("\"><circle r=\"5.2\" fill=\"none\" stroke=\"#6ac8ff\" stroke-width=\"0.6\" opacity=\"0.8\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.3;1;0.3")), ((V)(2.4)), ((V)(((-ToNum(i_2993)) * 0.6))))).S("</circle><circle r=\"3\" fill=\"none\" stroke=\"#6ac8ff\" stroke-width=\"0.4\" opacity=\"0.6\"/></g>").Str));
}, 2, "", true));
f_2985.S("<g transform=\"").V(Call(planeH_46, V.Undef, p_2984, ((V)(40.2)), ((V)((-60D))), ((V)((-26D))))).S("\">").V(Invoke(Call(rep_38, V.Undef, ((V)(10D)), Fn((V _arrowThis3007, int _argc3000, V i_3006, V _a3003, V _a3004, V _a3005, V[] _rest3001) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"").N((ToNum(i_3006) * 4D)).S("\" y=\"0\" width=\"2.6\" height=\"1.2\" rx=\"0.6\" fill=\"#6ac8ff\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.25;1;0.25")), ((V)(1.6)), ((V)(((-ToNum(i_3006)) * 0.16))))).S("</rect>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>");
q_2986 = Call(p_2984, V.Undef, ((V)(0D)), ((V)(25.6)), ((V)(((D2_2933 / 2D) + 0.7))));
f_2985.S("<g transform=\"").V(Call(plane_44, V.Undef, p_2984, ((V)(((D2_2933 / 2D) + 0.7))), ((V)(30.6)), ((V)((-6.5))))).S("\"><text x=\"6.5\" y=\"3.6\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"700\" font-size=\"3\" fill=\"#e8fdff\">4\u00b0C</text></g>");
Invoke(Arr(((V)((-39D))), ((V)(39D))), "forEach", Fn((V _arrowThis3016, int _argc3008, V x_3014, V i_3015, V _a3012, V _a3013, V[] _rest3009) => {
return ((V)(f_2985.S("<g transform=\"").V(Call(plane_44, V.Undef, p_2984, ((V)(((D2_2933 / 2D) + 0.2))), ((V)(36D)), ((V)((ToNum(x_3014) - 23D))))).S("\"><rect width=\"46\" height=\"31\" rx=\"1.2\" fill=\"url(#p3glass)\" opacity=\"0.7\"/>").V(Invoke(Call(rep_38, V.Undef, ((V)(8D)), Fn((V _arrowThis3024, int _argc3017, V j_3023, V _a3020, V _a3021, V _a3022, V[] _rest3018) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").N((4D + ((ToNum(j_3023) * 13D) % 40D))).S("\" cy=\"").N((5D + ((ToNum(j_3023) * 7D) % 22D))).S("\" r=\"0.5\" fill=\"#ffffff\" opacity=\"0.6\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>").Str));
}, 2, "", true));
Call(rep_38, V.Undef, ((V)(4D)), Fn((V _arrowThis3032, int _argc3025, V i_3031, V _a3028, V _a3029, V _a3030, V[] _rest3026) => {
V a_3033 = default;
a_3033 = Call(p_2984, V.Undef, ((V)(((-6D) + (ToNum(i_3031) * 4D)))), ((V)(40D)), ((V)(((-10D) + ((ToNum(i_3031) % 2D) * 20D)))));
f_2985.S("<ellipse cx=\"").V(Call(f1_23, V.Undef, GetIdx(a_3033, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(a_3033, 1D))).S("\" rx=\"3\" ry=\"1.6\" fill=\"#ffffff\" opacity=\"0\">").V(Call(an_51, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, GetIdx(a_3033, 1D))).S(";").V(Call(f1_23, V.Undef, ((V)((ToNum(GetIdx(a_3033, 1D)) - 12D))))).End())), ((V)(3D)), ((V)(((-ToNum(i_3031)) * 0.8))))).V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0;0.4;0")), ((V)(3D)), ((V)(((-ToNum(i_3031)) * 0.8))))).V(Call(an_51, V.Undef, ((V)("rx")), ((V)("2;6")), ((V)(3D)), ((V)(((-ToNum(i_3031)) * 0.8))))).S("</ellipse>");
return default;
}, 1, "", true));
return NewObj(2).Put("defs", PATS_60).Put("front", ((V)(f_2985.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "robButler", Fn((V _arrowThis3041, int _argc3034, V S_3040, V _a3037, V _a3038, V _a3039, V[] _rest3035) => {
V WHT_3042 = default;
V CY_3043 = default;
V CHR_3044 = default;
WHT_3042 = ((V)("#eef0f3"));
CY_3043 = ((V)("#4fe0ff"));
CHR_3044 = ((V)("#cfd6dc"));
return NewObj(5).Put("w", ((V)(64D))).Put("d", ((V)(64D))).Put("roam", ((V)(1D))).Put("build", Fn((V _arrowThis3052, int _argc3045, V P_3051, V _a3048, V _a3049, V _a3050, V[] _rest3046) => {
V o_3053 = default;
o_3053 = Arr();
Call(rep_38, V.Undef, ((V)(3D)), Fn((V _arrowThis3061, int _argc3054, V i_3060, V _a3057, V _a3058, V _a3059, V[] _rest3055) => {
double a_3062 = 0;
double x_3063 = 0;
double z_3064 = 0;
a_3062 = ((((ToNum(i_3060) * 2D) * PI_30) / 3D) + (PI_30 / 2D));
x_3063 = (FdLibm.Cos(a_3062) * 14D);
z_3064 = (FdLibm.Sin(a_3062) * 14D);
Invoke(o_3053, "push", Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(z_3064)), ((V)(4D)))).Put("a", ((V)(4D))).Put("b", ((V)(4D))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)((x_3063 - 1.6))), ((V)(0D))), Arr(((V)((x_3063 + 1.6))), ((V)(0D))))).Put("col", ((V)("#2c2d31"))).Put("mat", ((V)("metal"))).V));
return default;
}, 1, "", true));
Invoke(o_3053, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(20.5)), ((V)(3D)), ((V)("#2c2d31")), Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(20D)), ((V)(8D)), WHT_3042, Call(cer_35, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(6D)), ((V)(0D)), ((V)(0.98))), Arr(((V)(8D)), ((V)(0D)), ((V)(0.9))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(18D)), ((V)(0.9)), CY_3043, Call(em_25, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(slab_15, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(19.4)), ((V)(12D)), ((V)(3D)), ((V)(0.6)), ((V)("#14151a")), NewObj(1).Put("r", ((V)(1.4))).V));
Invoke(o_3053, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(14.9)), ((V)(0D)), ((V)(7D)), ((V)(15D)), CHR_3044, Call(mt_33, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(29.9)), ((V)(0D)), ((V)(7.6)), ((V)(1.4)), ((V)("#2c2d31")), Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(31.3)), ((V)(0D)), ((V)(5.6)), ((V)(12D)), CHR_3044, Call(mt_33, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(43.3)), ((V)(0D)), ((V)(6.2)), ((V)(1.2)), ((V)("#2c2d31")), Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(44.5)), ((V)(0D)), ((V)(4.3)), ((V)(9D)), CHR_3044, Call(mt_33, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).V)));
InvokeSpread(o_3053, "push", new ArrBuilder().Add(Call(ball_14, V.Undef, ((V)(0D)), ((V)(52D)), ((V)(0D)), ((V)(13D)), WHT_3042, Call(cer_35, V.Undef, NewObj(4).Put("sy", ((V)(0.8))).Put("sz", ((V)(0.85))).Put("k", ((V)(7D))).Put("n", ((V)(18D))).V))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(72D)), ((V)(0D)), ((V)(3D)), ((V)(3D)), ((V)("#2c2d31")), Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(12D))).V))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(74.6)), ((V)(1D)), ((V)(20D)), ((V)(13D)), ((V)(10D)), ((V)("#1a1c22")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(4D))).V))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(74.2)), ((V)(1D)), ((V)(21D)), ((V)(1D)), ((V)(10.6)), WHT_3042, Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(4D))).V))).Spread(Invoke(Arr(((V)((-1D))), ((V)(1D))), "map", Fn((V _arrowThis3072, int _argc3065, V sg_3071, V _a3068, V _a3069, V _a3070, V[] _rest3066) => {
return Call(ball_14, V.Undef, ((V)((ToNum(sg_3071) * 10.8))), ((V)(78D)), ((V)(1D)), ((V)(2.4)), CHR_3044, Call(mt_33, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("shine", ((V)(1D))).V));
}, 1, "", true))).V);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis3080, int _argc3073, V sg_3079, V _a3076, V _a3077, V _a3078, V[] _rest3074) => {
double x_3081 = 0;
x_3081 = (ToNum(sg_3079) * 13.6);
Invoke(o_3053, "push", Call(ball_14, V.Undef, ((V)(x_3081)), ((V)(62D)), ((V)(0D)), ((V)(3.4)), CHR_3044, Call(mt_33, V.Undef, NewObj(2).Put("k", ((V)(5D))).Put("shine", ((V)(1D))).V)), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(x_3081)), ((V)(64.4)))).Put("a", ((V)(1.9))).Put("b", ((V)(1.9))).Put("n", ((V)(10D))).Put("rings", Arr(Arr(((V)(1D)), ((V)(0D))), Arr(((V)(12D)), ((V)(0D))))).Put("col", WHT_3042).Put("mat", ((V)("cer"))).V), Call(ball_14, V.Undef, ((V)(x_3081)), ((V)(62.2)), ((V)(12.6)), ((V)(2.4)), CHR_3044, Call(mt_33, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("shine", ((V)(1D))).V)), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(x_3081)), ((V)(64.6)))).Put("a", ((V)(1.6))).Put("b", ((V)(1.6))).Put("n", ((V)(10D))).Put("rings", Arr(Arr(((V)(14D)), ((V)(0D))), Arr(((V)(21D)), ((V)(0D))))).Put("col", ((V)("#2c2d31"))).Put("mat", ((V)("metal"))).V), Call(box_12, V.Undef, ((V)((x_3081 - (ToNum(sg_3079) * 1D)))), ((V)(63D)), ((V)(22.2)), ((V)(3D)), ((V)(2.6)), ((V)(3D)), CHR_3044, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
return default;
}, 1, "", true));
Invoke(o_3053, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(65.6)), ((V)(22D)), ((V)(15D)), ((V)(1.4)), CHR_3044, Call(mt_33, V.Undef, NewObj(3).Put("rz", ((V)(10D))).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).V)), Call(arcW_17, V.Undef, ((V)(0D)), ((V)(67D)), ((V)(22D)), ((V)(15D)), ((V)(10D)), ((V)(0.8)), ((V)(1.2)), ((V)(0D)), ((V)((2D * PI_30))), ((V)("#9aa3a8")), Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)));
InvokeSpread(o_3053, "push", new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)((-6D))), ((V)(67D)), ((V)(22D)), ((V)(3.6)), ((V)(9D)), ((V)("#ffffff")), Call(pt_37, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.78))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V))).Spread(Call(rep_38, V.Undef, ((V)(6D)), Fn((V _arrowThis3089, int _argc3082, V i_3088, V _a3085, V _a3086, V _a3087, V[] _rest3083) => {
return Call(ball_14, V.Undef, ((V)(((-6D) + (((ToNum(i_3088) % 3D) - 1D) * 2D)))), ((V)((75.6 + (GtN(i_3088, 2D) ? 1.4 : 0D)))), ((V)((22D + ((ToNum(i_3088) % 2D) * 1.6)))), ((V)(1.4)), ((V)("#fff6dc")), NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(7D))).Put("shine", ((V)(0D))).V);
}, 1, "", true))).Add(Call(cyl_13, V.Undef, ((V)(6D)), ((V)(67D)), ((V)(20D)), ((V)(2.6)), ((V)(9D)), ((V)("#d9363b")), Call(pt_37, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))))).V))).Add(Call(cyl_13, V.Undef, ((V)(6D)), ((V)(76D)), ((V)(20D)), ((V)(2.8)), ((V)(0.8)), ((V)("#ffffff")), NewObj(1).Put("n", ((V)(12D))).V)).Add(Call(cyl_13, V.Undef, ((V)(6.8)), ((V)(76.8)), ((V)(20D)), ((V)(0.4)), ((V)(5D)), ((V)("#ffffff")), NewObj(1).Put("n", ((V)(4D))).V)).Add(Call(box_12, V.Undef, ((V)(4D)), ((V)(67D)), ((V)(27D)), ((V)(8D)), ((V)(0.6)), ((V)(5D)), ((V)("#ffffff")), NewObj(1).Put("r", ((V)(0.5))).V)).V);
return o_3053;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis3097, int _argc3090, V c_3096, V _a3093, V _a3094, V _a3095, V[] _rest3091) => {
V p_3098 = default;
JsStrBuf f_3099 = null;
V q_3100 = default;
p_3098 = Get(c_3096, "p");
f_3099 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_44, V.Undef, p_3098, ((V)(6.15)), ((V)(85.8)), ((V)((-8D))))).S("\">").V(Invoke(Invoke(Arr(((V)(4.6)), ((V)(11.4))), "map", Fn((V _arrowThis3108, int _argc3101, V x_3107, V _a3104, V _a3105, V _a3106, V[] _rest3102) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(x_3107).S("\" cy=\"4.6\" rx=\"1.6\" ry=\"2\" fill=\"#4fe0ff\">").V(Call(an_51, V.Undef, ((V)("ry")), ((V)("2;2;0.2;2;2")), ((V)(4D)), ((V)(0D)), ((V)("0;0.9;0.93;0.96;1")))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M5.4 8.2Q8 9.8 10.6 8.2\" fill=\"none\" stroke=\"#4fe0ff\" stroke-width=\"0.6\" stroke-linecap=\"round\"/></g>").End());
q_3100 = Call(p_3098, V.Undef, ((V)(0D)), ((V)(14.4)), ((V)(0D)));
f_3099.S("<g transform=\"").V(Call(planeH_46, V.Undef, p_3098, ((V)(14.5)))).S("\"><ellipse rx=\"18\" ry=\"18\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1\" stroke-dasharray=\"6 50\" opacity=\"0.8\">").V(Call(an_51, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-113")), ((V)(2D)))).S("</ellipse></g>");
return NewObj(1).Put("front", ((V)(f_3099.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "archiveWall", Fn((V _arrowThis3116, int _argc3109, V S_3115, V _a3112, V _a3113, V _a3114, V[] _rest3110) => {
double W_3117 = 0;
double H_3118 = 0;
double DD_3119 = 0;
V FRM_3120 = default;
V EDG_3121 = default;
double COLS_3122 = 0;
double ROWS_3123 = 0;
double cw_3124 = 0;
double rh_3125 = 0;
double x0_3126 = 0;
double y0_3127 = 0;
V LED_3128 = default;
V cell_3129 = default;
V R_3130 = default;
double zb_3131 = 0;
V rows_3132 = default;
W_3117 = 172D;
H_3118 = 150D;
DD_3119 = 24D;
FRM_3120 = ((V)("#34363c"));
EDG_3121 = ((V)("#b9c0c8"));
COLS_3122 = 5D;
ROWS_3123 = 4D;
cw_3124 = ((W_3117 - 8D) / COLS_3122);
rh_3125 = ((H_3118 - 14D) / ROWS_3123);
x0_3126 = (((-W_3117) / 2D) + 4D);
y0_3127 = 10D;
LED_3128 = Arr(((V)("#6ac8ff")), ((V)("#ffd66b")), ((V)("#b48cff")), ((V)("#4fe0d0")), ((V)("#ff9d4a")));
cell_3129 = Fn((V _arrowThis3141, int _argc3133, V i_3139, V j_3140, V _a3137, V _a3138, V[] _rest3134) => {
return NewObj(2).Put("x", ((V)((x0_3126 + (cw_3124 * ToNum(Add(i_3139, ((V)(0.5))))))))).Put("y", ((V)((y0_3127 + (rh_3125 * ToNum(j_3140)))))).V;
}, 2, "", true);
R_3130 = Call(rng_40, V.Undef, ((V)("arch2")));
zb_3131 = (((-DD_3119) / 2D) + 3D);
rows_3132 = Call(rep_38, V.Undef, ((V)(ROWS_3123)), Fn((V _arrowThis3149, int _argc3142, V j_3148, V _a3145, V _a3146, V _a3147, V[] _rest3143) => {
V o_3150 = default;
V g_3151 = default;
o_3150 = Arr();
g_3151 = Arr();
if (Truthy(j_3148)) {
Invoke(g_3151, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(((y0_3127 + (rh_3125 * ToNum(j_3148))) - 1.2))), ((V)(0D)), ((V)((W_3117 - 6D))), ((V)(2.4)), ((V)((DD_3119 - 1D))), FRM_3120, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(((y0_3127 + (rh_3125 * ToNum(j_3148))) - 1.2))), ((V)(((DD_3119 / 2D) - 0.2))), ((V)((W_3117 - 6D))), ((V)(2.4)), ((V)(0.7)), EDG_3121, Call(mt_33, V.Undef, NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V)));
}
Call(rep_38, V.Undef, ((V)((COLS_3122 - 1D))), Fn((V _arrowThis3159, int _argc3152, V i_3158, V _a3155, V _a3156, V _a3157, V[] _rest3153) => {
double hh_3160 = 0;
double yy_3161 = 0;
hh_3160 = ((rh_3125 - (Truthy(j_3148) ? 1.2 : 0D)) - (LtN(j_3148, (ROWS_3123 - 1D)) ? 1.2 : 0D));
yy_3161 = ((y0_3127 + (rh_3125 * ToNum(j_3148))) + (Truthy(j_3148) ? 1.2 : 0D));
Invoke(o_3150, "push", Call(box_12, V.Undef, ((V)((x0_3126 + (cw_3124 * ToNum(Add(i_3158, ((V)(1D)))))))), ((V)(yy_3161)), ((V)(0D)), ((V)(2.4)), ((V)(hh_3160)), ((V)((DD_3119 - 1D))), FRM_3120, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_12, V.Undef, ((V)((x0_3126 + (cw_3124 * ToNum(Add(i_3158, ((V)(1D)))))))), ((V)(yy_3161)), ((V)(((DD_3119 / 2D) - 0.2))), ((V)(2.4)), ((V)(hh_3160)), ((V)(0.7)), EDG_3121, Call(mt_33, V.Undef, NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V)));
return default;
}, 1, "", true));
Call(rep_38, V.Undef, ((V)(COLS_3122)), Fn((V _arrowThis3169, int _argc3162, V i_3168, V _a3165, V _a3166, V _a3167, V[] _rest3163) => {
V x_3170 = default;
V y_3171 = default;
V b_3172 = default;
double t_3173 = 0;
double zc_3174 = 0;
{ V _t3175 = Call(cell_3129, V.Undef, i_3168, j_3148);
if (_t3175.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3175));
{ V _t3176 = Get(_t3175, "x");
x_3170 = _t3176; }
{ V _t3177 = Get(_t3175, "y");
y_3171 = _t3177; } }
b_3172 = Add(y_3171, ((V)(1.2)));
t_3173 = System.Math.Floor((ToNum(Call(R_3130, V.Undef)) * 5D));
zc_3174 = (zb_3131 + 7D);
Invoke(o_3150, "push", Call(box_12, V.Undef, x_3170, ((V)((ToNum(Add(b_3172, ((V)(rh_3125)))) - 3.4))), ((V)(((DD_3119 / 2D) - 3D))), ((V)((cw_3124 - 6D))), ((V)(0.7)), ((V)(0.8)), ((V)("#ffffff")), Call(em_25, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
if ((t_3173 == 0D)) {
Call(rep_38, V.Undef, ((V)(3D)), Fn((V _arrowThis3185, int _argc3178, V k_3184, V _a3181, V _a3182, V _a3183, V[] _rest3179) => {
return Invoke(o_3150, "push", Call(box_12, V.Undef, ((V)(((ToNum(x_3170) - 8D) + (ToNum(k_3184) * 8D)))), b_3172, ((V)(zc_3174)), ((V)(7D)), ((V)(9D)), ((V)(12D)), GetK(Arr(((V)("#d8cdb8")), ((V)("#c9bba0")), ((V)("#e2d6c0"))), k_3184), Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)), Call(slab_15, V.Undef, ((V)(((ToNum(x_3170) - 8D) + (ToNum(k_3184) * 8D)))), Add(b_3172, ((V)(5D))), ((V)((zc_3174 + 6.2))), ((V)(4D)), ((V)(2D)), ((V)(0.3)), ((V)("#ffffff")), NewObj(2).Put("r", ((V)(0.2))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
} else {
if ((t_3173 == 1D)) {
Call(shelfBooks_74, V.Undef, o_3150, R_3130, ((V)(((ToNum(x_3170) - (cw_3124 / 2D)) + 2D))), ((V)((ToNum(Add(x_3170, ((V)((cw_3124 / 2D))))) - 2D))), b_3172, ((V)((zb_3131 + 1D))), ((V)(14D)), ((V)((rh_3125 - 7D))));
} else {
if ((t_3173 == 2D)) {
Invoke(o_3150, "push", Call(cyl_13, V.Undef, ((V)((ToNum(x_3170) - 4D))), b_3172, ((V)(zc_3174)), ((V)(4.6)), ((V)(14D)), GetIdx(Arr(((V)("#2c2d31")), ((V)("#e9e4da")), ((V)("#3f6a8a"))), System.Math.Floor((ToNum(Call(R_3130, V.Undef)) * 3D))), Call(cer_35, V.Undef, NewObj(2).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))), Arr(((V)(11D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(14D)), ((V)(0D)), ((V)(0.75))))).V)), Call(cyl_13, V.Undef, Add(x_3170, ((V)(6D))), b_3172, ((V)((zc_3174 + 2D))), ((V)(3D)), ((V)(8D)), ((V)("#c8693f")), Call(cer_35, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(8D)), ((V)(0D)), ((V)(1D))))).V)));
} else {
if ((t_3173 == 3D)) {
Invoke(o_3150, "push", Call(box_12, V.Undef, x_3170, b_3172, ((V)(zc_3174)), ((V)(10D)), ((V)(4D)), ((V)(10D)), ((V)("#2c2d31")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(ball_14, V.Undef, x_3170, Add(b_3172, ((V)(4D))), ((V)(zc_3174)), ((V)(6D)), GetIdx(Arr(((V)("#d4a548")), ((V)("#d5dde2")), ((V)("#e9e4da"))), System.Math.Floor((ToNum(Call(R_3130, V.Undef)) * 3D))), Call(mt_33, V.Undef, NewObj(3).Put("k", ((V)(7D))).Put("n", ((V)(16D))).Put("shine", ((V)(1D))).V)));
} else {
Invoke(o_3150, "push", Call(box_12, V.Undef, x_3170, b_3172, ((V)(zc_3174)), ((V)(14D)), ((V)(2D)), ((V)(10D)), ((V)("#2c2d31")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)), Call(box_12, V.Undef, ((V)((ToNum(x_3170) - 2D))), Add(b_3172, ((V)(2D))), ((V)(zc_3174)), ((V)(6D)), ((V)(10D)), ((V)(6D)), ((V)("#e9e4da")), Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)), Call(box_12, V.Undef, Add(x_3170, ((V)(3D))), Add(b_3172, ((V)(2D))), ((V)((zc_3174 - 1D))), ((V)(4D)), ((V)(16D)), ((V)(4D)), ((V)("#9aa3a8")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
}
}
}
}
return default;
}, 1, "", true));
return NewObj(2).Put("g", g_3151).Put("o", o_3150).V;
return default;
}, 1, "", true));
return NewObj(5).Put("w", ((V)((W_3117 + 6D)))).Put("d", ((V)((DD_3119 + 20D)))).Put("build", Fn((V _arrowThis3193, int _argc3186, V P_3192, V _a3189, V _a3190, V _a3191, V[] _rest3187) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(W_3117)), ((V)(y0_3127)), ((V)(DD_3119)), ((V)("#2c2d31")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "build", true)).Put("layers", new ArrBuilder().Add(NewObj(3).Put("back", ((V)(1D))).Put("build", Fn((V _arrowThis3201, int _argc3194, V P_3200, V _a3197, V _a3198, V _a3199, V[] _rest3195) => {
return Arr(Call(slab_15, V.Undef, ((V)(0D)), ((V)(y0_3127)), ((V)((((-DD_3119) / 2D) + 1D))), ((V)((W_3117 - 4D))), ((V)(((H_3118 - 4D) - y0_3127))), ((V)(2D)), ((V)("#1c1e24")), Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis3210, int _argc3202, V p_3208, V s_3209, V _a3206, V _a3207, V[] _rest3203) => {
JsStrBuf g_3211 = null;
g_3211 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_44, V.Undef, p_3208, ((V)((((-DD_3119) / 2D) + 2.1))), ((V)(0D)), ((V)(0D)))).S("\">").End());
Call(rep_38, V.Undef, ((V)(ROWS_3123)), Fn((V _arrowThis3219, int _argc3212, V j_3218, V _a3215, V _a3216, V _a3217, V[] _rest3213) => {
return Call(rep_38, V.Undef, ((V)(COLS_3122)), Fn((V _arrowThis3227, int _argc3220, V i_3226, V _a3223, V _a3224, V _a3225, V[] _rest3221) => {
V x_3228 = default;
V y_3229 = default;
V c0_3230 = default;
V seq_3231 = default;
double b_3232 = 0;
{ V _t3233 = Call(cell_3129, V.Undef, i_3226, j_3218);
if (_t3233.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3233));
{ V _t3234 = Get(_t3233, "x");
x_3228 = _t3234; }
{ V _t3235 = Get(_t3233, "y");
y_3229 = _t3235; } }
c0_3230 = GetIdx(LED_3128, (ToNum(Add(i_3226, j_3218)) % 5D));
seq_3231 = ((V)(JsStrBuf.Begin().V(Invoke(Call(rep_38, V.Undef, ((V)(6D)), Fn((V _arrowThis3243, int _argc3236, V k_3242, V _a3239, V _a3240, V _a3241, V[] _rest3237) => {
return GetIdx(LED_3128, (ToNum(Add(Add(i_3226, j_3218), k_3242)) % 5D));
}, 1, "", true)), "join", ((V)(";")))).S(";").V(c0_3230).End()));
b_3232 = (-((ToNum(i_3226) * 0.45) + (ToNum(j_3218) * 0.3)));
g_3211.S("<rect x=\"").V(Call(f1_23, V.Undef, ((V)(((ToNum(x_3228) - (cw_3124 / 2D)) + 2D))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((-(ToNum(Add(y_3229, ((V)(rh_3125)))) - 1.6)))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((cw_3124 - 4D))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((rh_3125 - 3.2))))).S("\" rx=\"1\" fill=\"url(#awg").N((ToNum(Add(i_3226, j_3218)) % 5D)).S(")\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.55;1;0.55")), ((V)(3.2)), ((V)(b_3232)))).S("</rect>");
return default;
}, 1, "", true));
}, 1, "", true));
return ((V)(JsStrBuf.Begin().V(s_3209).S(g_3211.Str).S("</g>").End()));
return default;
}, 2, "wrap", true)).V).Add(NewObj(2).Put("back", ((V)(1D))).Put("build", Fn((V _arrowThis3251, int _argc3244, V P_3250, V _a3247, V _a3248, V _a3249, V[] _rest3245) => {
return Arr(Call(box_12, V.Undef, ((V)((-((W_3117 / 2D) - 2D)))), ((V)(y0_3127)), ((V)(0D)), ((V)(4D)), ((V)(((H_3118 - 4D) - y0_3127))), ((V)(DD_3119)), FRM_3120, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
}, 1, "build", true)).V).Spread(InvokeSpread(Arr(), "concat", new ArrBuilder().Spread(Invoke(rows_3132, "map", Fn((V _arrowThis3260, int _argc3252, V r_3258, V j_3259, V _a3256, V _a3257, V[] _rest3253) => {
return Arr(NewObj(2).Put("build", Fn((V _arrowThis3268, int _argc3261, V P_3267, V _a3264, V _a3265, V _a3266, V[] _rest3262) => {
return Get(r_3258, "g");
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis3277, int _argc3269, V p_3275, V s_3276, V _a3273, V _a3274, V[] _rest3270) => {
JsStrBuf gl_3278 = null;
gl_3278 = new JsStrBuf("");
Call(rep_38, V.Undef, ((V)(COLS_3122)), Fn((V _arrowThis3286, int _argc3279, V i_3285, V _a3282, V _a3283, V _a3284, V[] _rest3280) => {
V x_3287 = default;
V y_3288 = default;
{ V _t3289 = Call(cell_3129, V.Undef, i_3285, j_3259);
if (_t3289.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t3289));
{ V _t3290 = Get(_t3289, "x");
x_3287 = _t3290; }
{ V _t3291 = Get(_t3289, "y");
y_3288 = _t3291; } }
gl_3278.S("<g transform=\"").V(Call(planeH_46, V.Undef, p_3275, Add(y_3288, ((V)(1.25))), x_3287, ((V)(0D)))).S("\"><rect x=\"").V(Call(f1_23, V.Undef, ((V)((((-cw_3124) / 2D) + 1.4))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)((((-DD_3119) / 2D) + 1D))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((cw_3124 - 2.8))))).S("\" height=\"").V(Call(f1_23, V.Undef, ((V)((DD_3119 - 2D))))).S("\" fill=\"url(#awf").N((ToNum(Add(i_3285, j_3259)) % 5D)).S(")\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.45;0.95;0.45")), ((V)(3.2)), ((V)((-((ToNum(i_3285) * 0.45) + (ToNum(j_3259) * 0.3))))))).S("</rect></g>");
return default;
}, 1, "", true));
return ((V)(JsStrBuf.Begin().V(s_3276).S(gl_3278.Str).End()));
return default;
}, 2, "wrap", true)).V, NewObj(1).Put("build", Fn((V _arrowThis3299, int _argc3292, V P_3298, V _a3295, V _a3296, V _a3297, V[] _rest3293) => {
return Get(r_3258, "o");
}, 1, "build", true)).V);
}, 2, "", true))).V)).Add(NewObj(1).Put("build", Fn((V _arrowThis3307, int _argc3300, V P_3306, V _a3303, V _a3304, V _a3305, V[] _rest3301) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)((H_3118 - 4D))), ((V)(0D)), ((V)(W_3117)), ((V)(4D)), ((V)(DD_3119)), FRM_3120, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((H_3118 - 4D))), ((V)(((DD_3119 / 2D) - 0.1))), ((V)(W_3117)), ((V)(4D)), ((V)(0.7)), EDG_3121, Call(mt_33, V.Undef, NewObj(2).Put("r", ((V)(0.3))).Put("noOut", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(((W_3117 / 2D) - 2D))), ((V)(y0_3127)), ((V)(0D)), ((V)(4D)), ((V)(((H_3118 - 4D) - y0_3127))), ((V)(DD_3119)), FRM_3120, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((H_3118 - 8D))), ((V)(((DD_3119 / 2D) + 4D))), ((V)((W_3117 - 8D))), ((V)(3D)), ((V)(3D)), CH_27, Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
}, 1, "build", true)).V).Add(NewObj(2).Put("build", Fn((V _arrowThis3315, int _argc3308, V P_3314, V _a3311, V _a3312, V _a3313, V[] _rest3309) => {
return Arr(Call(box_12, V.Undef, ((V)((((-W_3117) / 2D) + 22D))), ((V)((H_3118 - 11D))), ((V)(((DD_3119 / 2D) + 4D))), ((V)(6D)), ((V)(6D)), ((V)(5D)), ((V)("#2c2d31")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((((-W_3117) / 2D) + 22D))), ((V)(12D)), ((V)(((DD_3119 / 2D) + 4D))), ((V)(2.4)), ((V)((H_3118 - 22D))), ((V)(2.4)), ((V)("#9aa3a8")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis3324, int _argc3316, V p_3322, V s_3323, V _a3320, V _a3321, V[] _rest3317) => {
V e_3325 = default;
V o0_3326 = default;
double dx_3327 = 0;
double dy_3328 = 0;
V T_3329 = default;
e_3325 = Call(p_3322, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D)));
o0_3326 = Call(p_3322, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
dx_3327 = (ToNum(GetIdx(e_3325, 0D)) - ToNum(GetIdx(o0_3326, 0D)));
dy_3328 = (ToNum(GetIdx(e_3325, 1D)) - ToNum(GetIdx(o0_3326, 1D)));
T_3329 = Fn((V _arrowThis3337, int _argc3330, V d_3336, V _a3333, V _a3334, V _a3335, V[] _rest3331) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((dx_3327 * ToNum(d_3336)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((dy_3328 * ToNum(d_3336)))))).End()));
}, 1, "", true);
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(atS_55, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;").V(Call(T_3329, V.Undef, ((V)(0D)))).S(";").V(Call(T_3329, V.Undef, ((V)(64D)))).S(";").V(Call(T_3329, V.Undef, ((V)(64D)))).S(";").V(Call(T_3329, V.Undef, ((V)(124D)))).S(";").V(Call(T_3329, V.Undef, ((V)(124D)))).S(";0 0").End())), ((V)(14D)))).V(s_3323).S("</g>").End()));
return default;
}, 2, "wrap", true)).V).Add(NewObj(2).Put("build", Fn((V _arrowThis3345, int _argc3338, V P_3344, V _a3341, V _a3342, V _a3343, V[] _rest3339) => {
return Arr(Call(box_12, V.Undef, ((V)((((-W_3117) / 2D) + 22D))), ((V)(70D)), ((V)(((DD_3119 / 2D) + 6D))), ((V)(9D)), ((V)(6D)), ((V)(8D)), ((V)("#2c2d31")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)), Call(box_12, V.Undef, ((V)((((-W_3117) / 2D) + 22D))), ((V)(64D)), ((V)(((DD_3119 / 2D) + 8D))), ((V)(7D)), ((V)(6D)), ((V)(7D)), ((V)("#d8cdb8")), Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)), Call(box_12, V.Undef, ((V)((((-W_3117) / 2D) + 22D))), ((V)(72.6)), ((V)(((DD_3119 / 2D) + 10.1))), ((V)(4D)), ((V)(1D)), ((V)(0.4)), ((V)("#4fe0ff")), Call(em_25, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis3354, int _argc3346, V p_3352, V s_3353, V _a3350, V _a3351, V[] _rest3347) => {
V e_3355 = default;
V o0_3356 = default;
double dx_3357 = 0;
double dy_3358 = 0;
V k_3359 = default;
V T_3360 = default;
V Y_3361 = default;
e_3355 = Call(p_3352, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D)));
o0_3356 = Call(p_3352, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)));
dx_3357 = (ToNum(GetIdx(e_3355, 0D)) - ToNum(GetIdx(o0_3356, 0D)));
dy_3358 = (ToNum(GetIdx(e_3355, 1D)) - ToNum(GetIdx(o0_3356, 1D)));
k_3359 = Call(kOf_47, V.Undef, p_3352);
T_3360 = Fn((V _arrowThis3369, int _argc3362, V d_3368, V _a3365, V _a3366, V _a3367, V[] _rest3363) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((dx_3357 * ToNum(d_3368)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((dy_3358 * ToNum(d_3368)))))).End()));
}, 1, "", true);
Y_3361 = Fn((V _arrowThis3377, int _argc3370, V d_3376, V _a3373, V _a3374, V _a3375, V[] _rest3371) => {
return ((V)(JsStrBuf.Begin().S("0 ").V(Call(f1_23, V.Undef, ((V)((((-ToNum(d_3376)) * ToNum(k_3359)) * ToNum(CA_32)))))).End()));
}, 1, "", true);
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(atS_55, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;").V(Call(T_3360, V.Undef, ((V)(0D)))).S(";").V(Call(T_3360, V.Undef, ((V)(64D)))).S(";").V(Call(T_3360, V.Undef, ((V)(64D)))).S(";").V(Call(T_3360, V.Undef, ((V)(124D)))).S(";").V(Call(T_3360, V.Undef, ((V)(124D)))).S(";0 0").End())), ((V)(14D)))).S("<g>").V(Call(atS_55, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().V(Call(Y_3361, V.Undef, ((V)((-40D))))).S(";").V(Call(Y_3361, V.Undef, ((V)(30D)))).S(";").V(Call(Y_3361, V.Undef, ((V)(30D)))).S(";").V(Call(Y_3361, V.Undef, ((V)((-20D))))).S(";").V(Call(Y_3361, V.Undef, ((V)((-20D))))).S(";").V(Call(Y_3361, V.Undef, ((V)(45D)))).S(";").V(Call(Y_3361, V.Undef, ((V)((-40D))))).End())), ((V)(14D)))).V(s_3353).S("</g></g>").End()));
return default;
}, 2, "wrap", true)).V).V).Put("fx", Fn((V _arrowThis3385, int _argc3378, V c_3384, V _a3381, V _a3382, V _a3383, V[] _rest3379) => {
return NewObj(1).Put("defs", Invoke(Invoke(LED_3128, "map", Fn((V _arrowThis3394, int _argc3386, V col_3392, V i_3393, V _a3390, V _a3391, V[] _rest3387) => {
return ((V)(JsStrBuf.Begin().S("<radialGradient id=\"awg").V(i_3393).S("\" cx=\"50%\" cy=\"20%\" r=\"85%\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0.9\"/><stop offset=\"0.35\" stop-color=\"").V(col_3392).S("\" stop-opacity=\"0.85\"/><stop offset=\"1\" stop-color=\"").V(col_3392).S("\" stop-opacity=\"0.15\"/></radialGradient><linearGradient id=\"awf").V(i_3393).S("\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"").V(col_3392).S("\" stop-opacity=\"0.85\"/><stop offset=\"1\" stop-color=\"").V(col_3392).S("\" stop-opacity=\"0.1\"/></linearGradient>").End()));
}, 2, "", true)), "join", ((V)("")))).V;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "chrono", Fn((V _arrowThis3402, int _argc3395, V S_3401, V _a3398, V _a3399, V _a3400, V[] _rest3396) => {
return NewObj(6).Put("w", ((V)(60D))).Put("d", ((V)(34D))).Put("small", ((V)(1D))).Put("build", Fn((V _arrowThis3410, int _argc3403, V P_3409, V _a3406, V _a3407, V _a3408, V[] _rest3404) => {
V o_3411 = default;
V R_3412 = default;
o_3411 = Arr();
R_3412 = Call(rng_40, V.Undef, ((V)("met")));
Invoke(o_3411, "push", Call(box_12, V.Undef, ((V)((-12D))), ((V)(0D)), ((V)(0D)), ((V)(26D)), ((V)(5D)), ((V)(20D)), ((V)("#16161a")), Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(arcW_17, V.Undef, ((V)((-12D))), ((V)(5D)), ((V)(0D)), ((V)(7D)), ((V)(7D)), ((V)(1.2)), ((V)(1.2)), ((V)(0D)), ((V)((2D * PI_30))), ((V)("#d4a548")), Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(cyl_13, V.Undef, ((V)((-12D))), ((V)(5D)), ((V)(0D)), ((V)(4.2)), ((V)(0.6)), ((V)("#6ac8ff")), Call(em_25, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)));
Invoke(o_3411, "push", Call(cyl_13, V.Undef, ((V)(15D)), ((V)(0D)), ((V)(0D)), ((V)(8D)), ((V)(3D)), ((V)("#3a2416")), Call(wd_34, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_13, V.Undef, ((V)(15D)), ((V)(3D)), ((V)(0D)), ((V)(1.4)), ((V)(4D)), ((V)("#9aa3a8")), Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
Invoke(Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(5.4))), Arr(((V)((-3D))), ((V)(1.6)), ((V)(2D)), ((V)(3.8))), Arr(((V)(3.4)), ((V)(2.4)), ((V)((-1.6))), ((V)(3.6))), Arr(((V)(1D)), ((V)(4.4)), ((V)(1.6)), ((V)(3.4))), Arr(((V)((-2D))), ((V)(3.8)), ((V)((-2.4))), ((V)(3D))), Arr(((V)(2.6)), ((V)(0.4)), ((V)(3D)), ((V)(2.8)))), "forEach", Fn((V _arrowThis3428, int _argc3413, V _a3415, V _a3416, V _a3417, V _a3418, V[] _rest3414) => {
V dx_3421 = default;
V dy_3423 = default;
V dz_3425 = default;
V r_3427 = default;
{ V _t3419 = ListOf(_a3415);
{ V _t3420 = GetIdx(_t3419, 0D);
dx_3421 = _t3420; }
{ V _t3422 = GetIdx(_t3419, 1D);
dy_3423 = _t3422; }
{ V _t3424 = GetIdx(_t3419, 2D);
dz_3425 = _t3424; }
{ V _t3426 = GetIdx(_t3419, 3D);
r_3427 = _t3426; }
}
return Invoke(o_3411, "push", Call(ball_14, V.Undef, Add(((V)(15D)), dx_3421), Add(((V)(6D)), dy_3423), dz_3425, r_3427, ((V)("#4b4a4c")), Call(mt_33, V.Undef, NewObj(3).Put("k", ((V)(4D))).Put("n", ((V)(9D))).Put("sy", ((V)(0.85))).V)));
}, 1, "", true));
Call(rep_38, V.Undef, ((V)(7D)), Fn((V _arrowThis3435, int _argc3429, V _a3431, V _a3432, V _a3433, V _a3434, V[] _rest3430) => {
return Invoke(o_3411, "push", Call(ball_14, V.Undef, ((V)((15D + ((ToNum(Call(R_3412, V.Undef)) - 0.5) * 9D)))), ((V)((8D + (ToNum(Call(R_3412, V.Undef)) * 6D)))), ((V)((3.4 + (ToNum(Call(R_3412, V.Undef)) * 1.6)))), ((V)((0.9 + (ToNum(Call(R_3412, V.Undef)) * 0.8)))), ((V)("#2e2d30")), NewObj(5).Put("sy", ((V)(0.4))).Put("k", ((V)(2D))).Put("n", ((V)(8D))).Put("noOut", ((V)(1D))).Put("shine", ((V)(0D))).V));
}, 0, "", true));
return o_3411;
return default;
}, 1, "build", true)).Put("layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis3443, int _argc3436, V P_3442, V _a3439, V _a3440, V _a3441, V[] _rest3437) => {
return Arr(Call(ball_14, V.Undef, ((V)((-12D))), ((V)(14D)), ((V)(0D)), ((V)(5.4)), ((V)("#d5dde2")), Call(mt_33, V.Undef, NewObj(3).Put("k", ((V)(8D))).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).V)), Call(disc_18, V.Undef, ((V)((-12D))), ((V)(19.4)), ((V)(5D)), ((V)(3.2)), ((V)(0.3)), ((V)("#fffaf1")), NewObj(2).Put("n", ((V)(18D))).Put("noOut", ((V)(1D))).V));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis3452, int _argc3444, V p_3450, V s_3451, V _a3448, V _a3449, V[] _rest3445) => {
V k_3453 = default;
V q_3454 = default;
double R_3455 = 0;
V ring_3456 = default;
V r2_3457 = default;
k_3453 = Call(kOf_47, V.Undef, p_3450);
q_3454 = Call(p_3450, V.Undef, ((V)((-12D))), ((V)(19.4)), ((V)(0D)));
R_3455 = (9D * ToNum(k_3453));
ring_3456 = Fn((V _arrowThis3470, int _argc3458, V rx_3464, V ry_3465, V rot_3466, V col_3467, V[] _rest3459) => {
V w_3468 = default;
V d_3469 = default;
w_3468 = (_argc3458 > 4 ? _rest3459[0] : V.Undef);
d_3469 = (_argc3458 > 5 ? _rest3459[1] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<g transform=\"rotate(").V(rot_3466).S(")\"><ellipse rx=\"").V(Call(f1_23, V.Undef, rx_3464)).S("\" ry=\"").V(Call(f1_23, V.Undef, ry_3465)).S("\" fill=\"none\" stroke=\"#6a4a12\" stroke-width=\"").V(Call(f1_23, V.Undef, Add(w_3468, ((V)(0.5))))).S("\"/><ellipse rx=\"").V(Call(f1_23, V.Undef, rx_3464)).S("\" ry=\"").V(Call(f1_23, V.Undef, ry_3465)).S("\" fill=\"none\" stroke=\"").V(col_3467).S("\" stroke-width=\"").V(Call(f1_23, V.Undef, w_3468)).S("\"/><ellipse rx=\"").V(Call(f1_23, V.Undef, rx_3464)).S("\" ry=\"").V(Call(f1_23, V.Undef, ry_3465)).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(w_3468) * 0.3))))).S("\" stroke-dasharray=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(rx_3464) * 0.8))))).S(" ").V(Call(f1_23, V.Undef, ((V)((ToNum(rx_3464) * 5D))))).S("\" opacity=\"0.8\">").V(Call(an_51, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;-").V(Call(f1_23, V.Undef, ((V)((ToNum(rx_3464) * 6.3))))).End())), d_3469)).S("</ellipse></g>").End()));
}, 6, "", true);
r2_3457 = ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_42, V.Undef, q_3454)).S(")\">").V(Call(ring_3456, V.Undef, ((V)(R_3455)), ((V)((R_3455 * 0.32))), ((V)((-18D))), ((V)("#e8c25a")), ((V)((0.9 * ToNum(k_3453)))), ((V)(3D)))).S("<g>").S("<ellipse rx=\"").V(Call(f1_23, V.Undef, ((V)((R_3455 * 0.86))))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((R_3455 * 0.86))))).S("\" fill=\"none\" stroke=\"#c9ced3\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.7 * ToNum(k_3453)))))).S("\">").V(Call(anS_52, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_23, V.Undef, ((V)((R_3455 * 0.86))))).S(";").V(Call(f1_23, V.Undef, ((V)((R_3455 * 0.08))))).S(";").V(Call(f1_23, V.Undef, ((V)((R_3455 * 0.86))))).End())), ((V)(5D)))).S("</ellipse></g>").V(Call(ring_3456, V.Undef, ((V)((R_3455 * 1.12))), ((V)((R_3455 * 0.42))), ((V)(24D)), ((V)("#d4a548")), ((V)((0.7 * ToNum(k_3453)))), ((V)(4.4)))).S("<g transform=\"rotate(-18)\"><ellipse rx=\"").V(Call(f1_23, V.Undef, ((V)(R_3455)))).S("\" ry=\"").V(Call(f1_23, V.Undef, ((V)((R_3455 * 0.32))))).S("\" fill=\"none\" stroke=\"#3a2a10\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.25 * ToNum(k_3453)))))).S("\" stroke-dasharray=\"").V(Call(f1_23, V.Undef, ((V)((0.25 * ToNum(k_3453)))))).S(" ").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(k_3453)))))).S("\"/></g>").S("<line x1=\"0\" y1=\"0\" x2=\"0\" y2=\"").V(Call(f1_23, V.Undef, ((V)(((-2.4) * ToNum(k_3453)))))).S("\" stroke=\"#2c2d31\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.35 * ToNum(k_3453)))))).S("\" transform=\"translate(").V(Call(f1_23, V.Undef, ((V)(0D)))).S(" ").V(Call(f1_23, V.Undef, ((V)(0D)))).S(")\">").V(Call(at_54, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(6D)))).S("</line><line x1=\"0\" y1=\"0\" x2=\"").V(Call(f1_23, V.Undef, ((V)((1.6 * ToNum(k_3453)))))).S("\" y2=\"0\" stroke=\"#2c2d31\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.45 * ToNum(k_3453)))))).S("\">").V(Call(at_54, V.Undef, ((V)("rotate")), ((V)("0;360")), ((V)(40D)))).S("</line></g>").End()));
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(atS_55, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;0 ").V(Call(f1_23, V.Undef, ((V)(((-2.6) * ToNum(k_3453)))))).S(";0 0").End())), ((V)(3.2)))).V(s_3451).V(r2_3457).S("</g>").End()));
return default;
}, 2, "wrap", true)).V)).Put("fx", Fn((V _arrowThis3478, int _argc3471, V c_3477, V _a3474, V _a3475, V _a3476, V[] _rest3472) => {
V p_3479 = default;
V q_3480 = default;
V k_3481 = default;
JsStrBuf f_3482 = null;
V g_3483 = default;
p_3479 = Get(c_3477, "p");
q_3480 = Call(p_3479, V.Undef, ((V)(15D)), ((V)(9D)), ((V)(5.4)));
k_3481 = Get(c_3477, "k");
f_3482 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(P2_42, V.Undef, q_3480)).S(") scale(").V(Call(f1_23, V.Undef, k_3481)).S(")\"><path d=\"M-2.6 -2.4L2.8 -3L3.2 2.2L-2.2 2.8Z\" fill=\"#c9ced3\" stroke=\"#6b6f7a\" stroke-width=\"0.3\"/><path d=\"M-2 -2L2.6 2M-1 -2.6L3 1M-2.4 0L0.6 2.6M-2.2 1.6L2.6 -2.2M-0.6 2.6L3 -0.6M-2.6 -1L0.6 -2.8\" stroke=\"#8a8f96\" stroke-width=\"0.22\"/></g>").End());
g_3483 = Call(p_3479, V.Undef, ((V)((-12D))), ((V)(5.6)), ((V)(0D)));
f_3482.S("<g transform=\"").V(Call(planeH_46, V.Undef, p_3479, ((V)(5.6)), ((V)((-12D))), ((V)(0D)))).S("\"><ellipse rx=\"5\" ry=\"5\" fill=\"none\" stroke=\"#6ac8ff\" stroke-width=\"0.5\">").V(Call(an_51, V.Undef, ((V)("rx")), ((V)("3;8")), ((V)(1.8)))).V(Call(an_51, V.Undef, ((V)("ry")), ((V)("3;8")), ((V)(1.8)))).V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0.8;0")), ((V)(1.8)))).S("</ellipse></g>");
Call(rep_38, V.Undef, ((V)(3D)), Fn((V _arrowThis3491, int _argc3484, V i_3490, V _a3487, V _a3488, V _a3489, V[] _rest3485) => {
V s_3492 = default;
s_3492 = Call(p_3479, V.Undef, ((V)((15D + ((ToNum(i_3490) - 1D) * 3D)))), ((V)((10D + (ToNum(i_3490) * 1.6)))), ((V)(4D)));
f_3482.S("<circle cx=\"").V(Call(f1_23, V.Undef, GetIdx(s_3492, 0D))).S("\" cy=\"").V(Call(f1_23, V.Undef, GetIdx(s_3492, 1D))).S("\" r=\"").V(Call(f1_23, V.Undef, ((V)((0.5 * ToNum(k_3481)))))).S("\" fill=\"#ffffff\" opacity=\"0\">").V(Call(an_51, V.Undef, ((V)("opacity")), ((V)("0;1;0;0")), ((V)(2.4)), ((V)(((-ToNum(i_3490)) * 0.8))))).S("</circle>");
return default;
}, 1, "", true));
return NewObj(1).Put("front", ((V)(f_3482.Str))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
Set(N_24, "artBooks", Fn((V _arrowThis3500, int _argc3493, V S_3499, V _a3496, V _a3497, V _a3498, V[] _rest3494) => {
V BKS_3501 = default;
BKS_3501 = Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(36D)), ((V)(5.2)), ((V)(30D)), ((V)("#2f4870")), ((V)("MODERN ART"))), Arr(((V)((-1.6))), ((V)(5.2)), ((V)(31D)), ((V)(4.6)), ((V)(26D)), ((V)("#7f2030")), ((V)("BAUHAUS"))), Arr(((V)(1.2)), ((V)(9.8)), ((V)(27D)), ((V)(4D)), ((V)(22D)), ((V)("#1f4f3e")), ((V)("MATISSE"))));
return NewObj(6).Put("w", ((V)(52D))).Put("d", ((V)(40D))).Put("small", ((V)(1D))).Put("topH", ((V)(14D))).Put("build", Fn((V _arrowThis3509, int _argc3502, V P_3508, V _a3505, V _a3506, V _a3507, V[] _rest3503) => {
V o_3510 = default;
double y_3511 = 0;
double mx_3512 = 0;
double mz_3513 = 0;
o_3510 = Arr();
Invoke(BKS_3501, "forEach", Fn((V _arrowThis3533, int _argc3514, V _a3516, V _a3517, V _a3518, V _a3519, V[] _rest3515) => {
V dx_3522 = default;
V y_3524 = default;
V w_3526 = default;
V t_3528 = default;
V d_3530 = default;
V col_3532 = default;
{ V _t3520 = ListOf(_a3516);
{ V _t3521 = GetIdx(_t3520, 0D);
dx_3522 = _t3521; }
{ V _t3523 = GetIdx(_t3520, 1D);
y_3524 = _t3523; }
{ V _t3525 = GetIdx(_t3520, 2D);
w_3526 = _t3525; }
{ V _t3527 = GetIdx(_t3520, 3D);
t_3528 = _t3527; }
{ V _t3529 = GetIdx(_t3520, 4D);
d_3530 = _t3529; }
{ V _t3531 = GetIdx(_t3520, 5D);
col_3532 = _t3531; }
}
Invoke(o_3510, "push", Call(box_12, V.Undef, dx_3522, y_3524, ((V)(0D)), w_3526, ((V)(0.9)), d_3530, col_3532, Call(fb_36, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("soft", ((V)(0D))).V)), Call(box_12, V.Undef, Add(dx_3522, ((V)(0.6))), Add(y_3524, ((V)(0.9))), ((V)((-0.4))), ((V)((ToNum(w_3526) - 2.4))), ((V)((ToNum(t_3528) - 1.8))), ((V)((ToNum(d_3530) - 2.4))), ((V)("#f6efe0")), Call(pt_37, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_12, V.Undef, dx_3522, ((V)((ToNum(Add(y_3524, t_3528)) - 0.9))), ((V)(0D)), w_3526, ((V)(0.9)), d_3530, col_3532, Call(fb_36, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("soft", ((V)(0D))).V)), Call(box_12, V.Undef, dx_3522, y_3524, ((V)(((ToNum(d_3530) / 2D) - 0.7))), w_3526, t_3528, ((V)(1.4)), Call(shade_21, V.Undef, col_3532, ((V)(0.92))), Call(fb_36, V.Undef, NewObj(2).Put("r", ((V)(0.7))).Put("soft", ((V)(0D))).V)));
return default;
}, 1, "", true));
y_3511 = 13.8;
mx_3512 = (-2D);
mz_3513 = (-3D);
Invoke(o_3510, "push", Call(arcW_17, V.Undef, ((V)(mx_3512)), ((V)(y_3511)), ((V)(mz_3513)), ((V)(6.4)), ((V)(6.4)), ((V)(1.3)), ((V)(1.4)), ((V)(0D)), ((V)((2D * PI_30))), ((V)("#d4a548")), Call(mt_33, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(mx_3512)), ((V)((y_3511 + 0.3))), ((V)(mz_3513)), ((V)(5.2)), ((V)(0.7)), ((V)("#dff2fb")), Call(cer_35, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("op", ((V)(0.4))).V)), Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((mz_3513 + 1.6))), ((V)((y_3511 + 0.9))))).Put("a", ((V)(1.1))).Put("b", ((V)(1.1))).Put("n", ((V)(10D))).Put("rings", Arr(Arr(((V)((mx_3512 + 6.2))), ((V)(0D)), ((V)(0.9))), Arr(((V)((mx_3512 + 9D))), ((V)(0D)), ((V)(1D))))).Put("col", ((V)("#d4a548"))).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V), Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((mz_3513 + 2.4))), ((V)((y_3511 + 1D))))).Put("a", ((V)(1.5))).Put("b", ((V)(1.5))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(((V)((mx_3512 + 9D))), ((V)(0D)), ((V)(1D))), Arr(((V)((mx_3512 + 19D))), ((V)(0D)), ((V)(1.1))), Arr(((V)((mx_3512 + 20D))), ((V)(0D)), ((V)(0.7))))).Put("col", ((V)("#3a2416"))).Put("mat", ((V)("wood"))).Put("shine", ((V)(1D))).V));
Invoke(o_3510, "push", Call(box_12, V.Undef, ((V)((-8D))), ((V)(9.6)), ((V)(12.9)), ((V)(1.6)), ((V)(0.3)), ((V)(4D)), ((V)("#c8303a")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V), Call(box_12, V.Undef, ((V)((-8D))), ((V)(5.2)), ((V)(14.6)), ((V)(1.6)), ((V)(4.6)), ((V)(0.3)), ((V)("#c8303a")), NewObj(2).Put("r", ((V)(0D))).Put("noOut", ((V)(1D))).V));
return o_3510;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis3541, int _argc3534, V c_3540, V _a3537, V _a3538, V _a3539, V[] _rest3535) => {
V p_3542 = default;
JsStrBuf f_3543 = null;
V q_3544 = default;
p_3542 = Get(c_3540, "p");
f_3543 = new JsStrBuf("");
Invoke(BKS_3501, "forEach", Fn((V _arrowThis3566, int _argc3545, V _a3547, V _a3548, V _a3549, V _a3550, V[] _rest3546) => {
JsStrBuf pl_3567 = null;
V dx_3553 = default;
V y_3555 = default;
V w_3557 = default;
V t_3559 = default;
V d_3561 = default;
V col_3563 = default;
V title_3565 = default;
{ V _t3551 = ListOf(_a3547);
{ V _t3552 = GetIdx(_t3551, 0D);
dx_3553 = _t3552; }
{ V _t3554 = GetIdx(_t3551, 1D);
y_3555 = _t3554; }
{ V _t3556 = GetIdx(_t3551, 2D);
w_3557 = _t3556; }
{ V _t3558 = GetIdx(_t3551, 3D);
t_3559 = _t3558; }
{ V _t3560 = GetIdx(_t3551, 4D);
d_3561 = _t3560; }
{ V _t3562 = GetIdx(_t3551, 5D);
col_3563 = _t3562; }
{ V _t3564 = GetIdx(_t3551, 6D);
title_3565 = _t3564; }
}
f_3543.S("<g transform=\"").V(Call(plane_44, V.Undef, p_3542, ((V)(((ToNum(d_3561) / 2D) + 0.75))), Add(y_3555, t_3559), ((V)((ToNum(dx_3553) - (ToNum(w_3557) / 2D)))))).S("\"><rect x=\"1\" y=\"0.5\" width=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(w_3557) - 2D))))).S("\" height=\"0.35\" fill=\"#e2b14a\"/><rect x=\"1\" y=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(t_3559) - 0.85))))).S("\" width=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(w_3557) - 2D))))).S("\" height=\"0.35\" fill=\"#e2b14a\"/><text x=\"").V(Call(f1_23, V.Undef, ((V)((ToNum(w_3557) / 2D))))).S("\" y=\"").V(Call(f1_23, V.Undef, ((V)(((ToNum(t_3559) / 2D) + 1.05))))).S("\" text-anchor=\"middle\" font-family=\"Georgia, 'Times New Roman', serif\" font-weight=\"700\" font-size=\"").V(Call(f1_23, V.Undef, ((V)(Min(2.8, (ToNum(t_3559) * 0.62)))))).S("\" letter-spacing=\"0.4\" fill=\"#f2d27a\">").V(title_3565).S("</text></g>");
pl_3567 = new JsStrBuf("");
Call(rep_38, V.Undef, ((V)(5D)), Fn((V _arrowThis3575, int _argc3568, V j_3574, V _a3571, V _a3572, V _a3573, V[] _rest3569) => {
return ((V)(pl_3567.S("<path d=\"M0 ").V(Call(f1_23, V.Undef, ((V)((1.1 + ((ToNum(j_3574) * (ToNum(t_3559) - 2.2)) / 4D)))))).S("H").V(Call(f1_23, V.Undef, ((V)((ToNum(d_3561) - 3D))))).S("\" stroke=\"#d8ccb2\" stroke-width=\"0.18\"/>").Str));
}, 1, "", true));
f_3543.S("<g transform=\"").V(Call(planeX_45, V.Undef, p_3542, ((V)((ToNum(Add(dx_3553, ((V)((ToNum(w_3557) / 2D))))) - 1.15))), ((V)((ToNum(Add(y_3555, t_3559)) - 0.9))), ((V)((((-ToNum(d_3561)) / 2D) + 1D))))).S("\">").S(pl_3567.Str).S("</g>");
return default;
}, 1, "", true));
q_3544 = Call(p_3542, V.Undef, ((V)((-3.5))), ((V)(14.6)), ((V)((-4D))));
f_3543.S("<g transform=\"translate(").V(Call(P2_42, V.Undef, q_3544)).S(")\"><path d=\"M").V(Call(f1_23, V.Undef, ((V)(((-3D) * ToNum(Get(c_3540, "k"))))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-0.6) * ToNum(Get(c_3540, "k"))))))).S("Q").V(Call(f1_23, V.Undef, ((V)(((-1D) * ToNum(Get(c_3540, "k"))))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-2.6) * ToNum(Get(c_3540, "k"))))))).S(" ").V(Call(f1_23, V.Undef, ((V)((2.4 * ToNum(Get(c_3540, "k"))))))).S(" ").V(Call(f1_23, V.Undef, ((V)(((-1.8) * ToNum(Get(c_3540, "k"))))))).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_23, V.Undef, ((V)((0.6 * ToNum(Get(c_3540, "k"))))))).S("\" opacity=\"0.8\"/></g>");
return NewObj(1).Put("front", ((V)(f_3543.Str))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_24, "microClean", Fn((V _arrowThis3583, int _argc3576, V S_3582, V _a3579, V _a3580, V _a3581, V[] _rest3577) => {
return NewObj(4).Put("w", ((V)(56D))).Put("d", ((V)(48D))).Put("build", Fn((V _arrowThis3591, int _argc3584, V P_3590, V _a3587, V _a3588, V _a3589, V[] _rest3585) => {
V o_3592 = default;
V BEE_3593 = default;
V SS_3594 = default;
o_3592 = Arr();
BEE_3593 = ((V)("#d6a46a"));
SS_3594 = ((V)("#c9cdd2"));
Invoke(Arr(Arr(((V)((-13D))), ((V)((-10D)))), Arr(((V)(13D)), ((V)((-10D)))), Arr(((V)((-13D))), ((V)(10D))), Arr(((V)(13D)), ((V)(10D)))), "forEach", Fn((V _arrowThis3606, int _argc3595, V _a3597, V _a3598, V _a3599, V _a3600, V[] _rest3596) => {
V x_3603 = default;
V z_3605 = default;
{ V _t3601 = ListOf(_a3597);
{ V _t3602 = GetIdx(_t3601, 0D);
x_3603 = _t3602; }
{ V _t3604 = GetIdx(_t3601, 1D);
z_3605 = _t3604; }
}
return Invoke(o_3592, "push", Call(cyl_13, V.Undef, x_3603, ((V)(0D)), z_3605, ((V)(1.9)), ((V)(38D)), BEE_3593, Call(wd_34, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(38D)), ((V)(0D)), ((V)(1.1))))).V)));
}, 1, "", true));
Invoke(o_3592, "push", Call(slabX_16, V.Undef, ((V)(0D)), ((V)(12D)), ((V)((-10D))), ((V)(26D)), ((V)(2.2)), ((V)(2.2)), BEE_3593, Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(slabX_16, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(10D)), ((V)(26D)), ((V)(2.2)), ((V)(2.2)), BEE_3593, Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)((-13D))), ((V)(16D)), ((V)(0D)), ((V)(2.2)), ((V)(2.2)), ((V)(20D)), BEE_3593, Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)(13D)), ((V)(16D)), ((V)(0D)), ((V)(2.2)), ((V)(2.2)), ((V)(20D)), BEE_3593, Call(wd_34, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
Invoke(o_3592, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(0D)), ((V)(20D)), ((V)(3.4)), BEE_3593, Call(wd_34, V.Undef, NewObj(3).Put("rz", ((V)(16D))).Put("n", ((V)(26D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.97))), Arr(((V)(2.4)), ((V)(0D)), ((V)(1D))), Arr(((V)(3.4)), ((V)(0D)), ((V)(0.96))))).V)));
Invoke(Arr(Arr(((V)((-17D))), ((V)((-11D)))), Arr(((V)(17D)), ((V)((-11D)))), Arr(((V)((-17D))), ((V)(11D))), Arr(((V)(17D)), ((V)(11D)))), "forEach", Fn((V _arrowThis3618, int _argc3607, V _a3609, V _a3610, V _a3611, V _a3612, V[] _rest3608) => {
V x_3615 = default;
V z_3617 = default;
{ V _t3613 = ListOf(_a3609);
{ V _t3614 = GetIdx(_t3613, 0D);
x_3615 = _t3614; }
{ V _t3616 = GetIdx(_t3613, 1D);
z_3617 = _t3616; }
}
return Invoke(o_3592, "push", Call(cyl_13, V.Undef, x_3615, ((V)(41.4)), z_3617, ((V)(1.4)), ((V)(1D)), ((V)("#1d1d20")), NewObj(1).Put("n", ((V)(8D))).V));
}, 1, "", true));
Invoke(o_3592, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(42.4)), ((V)(0D)), ((V)(44D)), ((V)(25D)), ((V)(30D)), SS_3594, Call(mt_33, V.Undef, NewObj(2).Put("r", ((V)(2.5))).Put("shine", ((V)(0D))).V)), Call(slab_15, V.Undef, ((V)((-6D))), ((V)(44.6)), ((V)(15.3)), ((V)(29D)), ((V)(20.6)), ((V)(0.6)), ((V)("#16181c")), Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(slab_15, V.Undef, ((V)((-7D))), ((V)(47D)), ((V)(15.75)), ((V)(22D)), ((V)(15D)), ((V)(0.3)), ((V)("#2a2010")), NewObj(2).Put("r", ((V)(1.4))).Put("noOut", ((V)(1D))).V), Call(slab_15, V.Undef, ((V)(14.6)), ((V)(44.6)), ((V)(15.3)), ((V)(10.4)), ((V)(20.6)), ((V)(0.6)), ((V)("#1d1f24")), Call(cer_35, V.Undef, NewObj(1).Put("r", ((V)(1.4))).V)), Call(box_12, V.Undef, ((V)(8D)), ((V)(46D)), ((V)(16.4)), ((V)(1.4)), ((V)(16D)), ((V)(1.4)), ((V)("#e3e7eb")), Call(mt_33, V.Undef, NewObj(2).Put("r", ((V)(0.6))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(8D)), ((V)(46D)), ((V)(15.6)), ((V)(1D)), ((V)(1D)), ((V)(1D)), ((V)("#9aa3a8")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V)), Call(box_12, V.Undef, ((V)(8D)), ((V)(61D)), ((V)(15.6)), ((V)(1D)), ((V)(1D)), ((V)(1D)), ((V)("#9aa3a8")), Call(mt_33, V.Undef, NewObj(1).Put("r", ((V)(0.2))).V)));
Invoke(o_3592, "push", Call(slab_15, V.Undef, ((V)(14.6)), ((V)(59D)), ((V)(15.7)), ((V)(8D)), ((V)(3.6)), ((V)(0.3)), ((V)("#0a1a14")), NewObj(2).Put("r", ((V)(0.6))).Put("noOut", ((V)(1D))).V));
Call(rep_38, V.Undef, ((V)(9D)), Fn((V _arrowThis3626, int _argc3619, V i_3625, V _a3622, V _a3623, V _a3624, V[] _rest3620) => {
return Invoke(o_3592, "push", Call(slab_15, V.Undef, ((V)((12D + ((ToNum(i_3625) % 3D) * 2.6)))), ((V)((47.6 + (System.Math.Floor((ToNum(i_3625) / 3D)) * 3D)))), ((V)(15.75)), ((V)(1.8)), ((V)(1.8)), ((V)(0.3)), ((V)((SEqN(i_3625, 8D) ? "#4fc86a" : "#3a3d44"))), NewObj(2).Put("r", ((V)(0.6))).Put("noOut", ((V)(1D))).V));
}, 1, "", true));
Invoke(o_3592, "push", Call(cyl_13, V.Undef, ((V)(14.6)), ((V)(56.6)), ((V)(15.6)), ((V)(1.6)), ((V)(0.4)), ((V)("#9aa3a8")), Call(mt_33, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
return o_3592;
return default;
}, 1, "build", true)).Put("fx", Fn((V _arrowThis3634, int _argc3627, V c_3633, V _a3630, V _a3631, V _a3632, V[] _rest3628) => {
V p_3635 = default;
JsStrBuf f_3636 = null;
JsStrBuf v_3637 = null;
p_3635 = Get(c_3633, "p");
f_3636 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_44, V.Undef, p_3635, ((V)(15.95)), ((V)(62D)), ((V)((-18D))))).S("\"><rect width=\"22\" height=\"15\" rx=\"1.4\" fill=\"url(#mwin)\">").V(Call(anS_52, V.Undef, ((V)("opacity")), ((V)("0.75;1;0.75")), ((V)(2D)))).S("</rect><g transform=\"translate(11 9.6)\"><ellipse rx=\"6.5\" ry=\"1.4\" fill=\"#ffffff\" opacity=\"0.35\"/><g>").V(Call(atS_55, V.Undef, ((V)("scale")), ((V)("1 1;0.55 1;1 1")), ((V)(2.6)))).S("<path d=\"M-3.2 0L-2.6 -5.2Q0 -6.4 2.6 -5.2L3.2 0Z\" fill=\"#f4ecd8\" stroke=\"#c8b48a\" stroke-width=\"0.3\"/><rect x=\"-2.4\" y=\"-3.6\" width=\"4.8\" height=\"1.4\" fill=\"#d9363b\"/></g></g><rect width=\"22\" height=\"15\" rx=\"1.4\" fill=\"url(#p3glass)\" opacity=\"0.6\"/></g>").End());
f_3636.S("<g transform=\"").V(Call(plane_44, V.Undef, p_3635, ((V)(15.9)), ((V)(62.6)), ((V)(10.6)))).S("\"><text x=\"4\" y=\"2.6\" text-anchor=\"middle\" font-family=\"Arial, sans-serif\" font-weight=\"700\" font-size=\"2.6\" fill=\"#7fe8a0\">1:30").V(Call(anD_53, V.Undef, ((V)("opacity")), ((V)("1;0.4")), ((V)(1D)))).S("</text></g>");
v_3637 = new JsStrBuf("");
Call(rep_38, V.Undef, ((V)(6D)), Fn((V _arrowThis3645, int _argc3638, V i_3644, V _a3641, V _a3642, V _a3643, V[] _rest3639) => {
return ((V)(v_3637.S("<path d=\"M").N((3D + (ToNum(i_3644) * 3.6))).S(" 3V14\" stroke=\"#8a9096\" stroke-width=\"0.7\"/>").Str));
}, 1, "", true));
f_3636.S("<g transform=\"").V(Call(planeX_45, V.Undef, p_3635, ((V)(22.1)), ((V)(64D)), ((V)((-10D))))).S("\">").S(v_3637.Str).S("</g>");
return NewObj(2).Put("defs", ((V)(JsStrBuf.Begin().V(PATS_60).S("<radialGradient id=\"mwin\" cx=\"50%\" cy=\"55%\" r=\"70%\"><stop offset=\"0\" stop-color=\"#ffe6a0\"/><stop offset=\"0.7\" stop-color=\"#e8a84a\"/><stop offset=\"1\" stop-color=\"#5a3a14\"/></radialGradient>").End()))).Put("front", ((V)(f_3636.Str))).V;
return default;
}, 1, "fx", true)).V;
}, 1, "", true));
px_82 = Fn((V _arrowThis3654, int _argc3646, V u_3652, V v_3653, V _a3650, V _a3651, V[] _rest3647) => {
return Arr(((V)(((14D - (14D * ToNum(v_3653))) + ((52D + (28D * ToNum(v_3653))) * ToNum(u_3652))))), ((V)((ToNum(v_3653) * 56D))));
}, 2, "", true);
PU_83 = Fn((V _arrowThis3663, int _argc3655, V u_3661, V v_3662, V _a3659, V _a3660, V[] _rest3656) => {
return Call(P2_42, V.Undef, Call(px_82, V.Undef, u_3661, v_3662));
}, 2, "", true);
NEO_88 = Arr(((V)("#ff3fb4")), ((V)("#a64dff")), ((V)("#3f8cff")), ((V)("#2fe0ff")), ((V)("#3fff9a")), ((V)("#ffe23f")), ((V)("#ff8a2f")));
SURF3_91 = NewObj(6).Put("concrete", concreteFloor_84).Put("obsidian", obsidianWall_85).Put("track", trackLight_86).Put("aurora", auroraHalo_87).Put("blackWall", blackWall_89).Put("blackLed", blackLedFloor_90).V;
draw2_92 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis3672, int _argc3664, V r_3670, V o_3671, V _a3668, V _a3669, V[] _rest3665) => {
V res_3673 = default;
res_3673 = Call(draw2_92, V.Undef, r_3670, o_3671);
if (Truthy(((!(Truthy(res_3673)) ? V.True : V.False) is var _t3674 && Truthy(_t3674) ? _t3674 : Get(res_3673, "_p3")))) {
return res_3673;
}
Set(res_3673, "_p3", ((V)(1D)));
try {
V f_3675 = default;
f_3675 = (Get(r_3670, "s3") is var _t3676 && !Truthy(_t3676) ? _t3676 : GetK(SURF3_91, Get(r_3670, "s3")));
if (Truthy(((f_3675 is var _t3677 && !Truthy(_t3677) ? _t3677 : Get(res_3673, "surf")) is var _t3678 && !Truthy(_t3678) ? _t3678 : Get(res_3673, "vb")))) {
V v_3679 = default;
double k_3680 = 0;
V tx_3681 = default;
V ty_3682 = default;
v_3679 = Invoke(Invoke(Get(res_3673, "vb"), "split", ((V)(" "))), "map", G("Number"));
k_3680 = Min((ToNum(GetIdx(v_3679, 2D)) / 80D), (ToNum(GetIdx(v_3679, 3D)) / 56D));
tx_3681 = Add(GetIdx(v_3679, 0D), ((V)(((ToNum(GetIdx(v_3679, 2D)) - (80D * k_3680)) / 2D))));
ty_3682 = Add(GetIdx(v_3679, 1D), ((V)(((ToNum(GetIdx(v_3679, 3D)) - (56D * k_3680)) / 2D))));
Set(res_3673, "svg", Invoke(RD_8, "svgDoc", Get(res_3673, "vb"), Arr(), ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(n4_41, V.Undef, tx_3681)).S(" ").V(Call(n4_41, V.Undef, ty_3682)).S(") scale(").V(Call(n4_41, V.Undef, ((V)(k_3680)))).S(")\">").V(Call(f_3675, V.Undef)).S("</g>").End()))));
Set(res_3673, "src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Get(res_3673, "svg"))).End())));
}
} catch (System.Exception _ex3683) {
V e_3684 = default;
e_3684 = Caught(_ex3683);
Invoke(G("console"), "warn", ((V)("reno plus3")), Get(r_3670, "id"), e_3684);
}
return res_3673;
return default;
}, 2, "", true));
LEATHER_93 = Arr(NewObj(2).Put("n", ((V)("Midnight Black"))).Put("c", ((V)("#2a2a30"))).V, NewObj(2).Put("n", ((V)("Cognac"))).Put("c", ((V)("#9a4f26"))).V, NewObj(2).Put("n", ((V)("Oxblood"))).Put("c", ((V)("#6e2a24"))).V, NewObj(2).Put("n", ((V)("Ivory"))).Put("c", ((V)("#e4dccb"))).V);
BOUC_94 = Arr(NewObj(2).Put("n", ((V)("Cream Boucl\u00e9"))).Put("c", ((V)("#ece5d6"))).V, NewObj(2).Put("n", ((V)("Oat Boucl\u00e9"))).Put("c", ((V)("#d9cbb0"))).V, NewObj(2).Put("n", ((V)("Sage Boucl\u00e9"))).Put("c", ((V)("#b8c4a8"))).V, NewObj(2).Put("n", ((V)("Taupe Boucl\u00e9"))).Put("c", ((V)("#c2b4a4"))).V);
Set(RD_8, "SET3", NewObj(26).Put("MOV-086", NewObj(3).Put("spec", ((V)("qHolo"))).Put("live", ((V)("Live hologram"))).Put("note", ((V)("A lens stack and three satellite emitters project a spinning planet and a film-strip ring. The platform rocks on four 4DX motion nodes."))).V).Put("MOV-098", NewObj(3).Put("spec", ((V)("reelSculpt"))).Put("live", ((V)("Spinning reels"))).Put("note", ((V)("Two holographic film reels float and spin above a wall emitter, with film running between them."))).V).Put("MOV-081", NewObj(2).Put("s3", ((V)("obsidian"))).Put("live", ((V)("Twinkling stars"))).V).Put("MOV-038", NewObj(2).Put("spec", ((V)("neonShow"))).Put("live", ((V)("Flickering neon"))).V).Put("MOV-095", NewObj(2).Put("s3", ((V)("aurora"))).Put("live", ((V)("Live aurora"))).V).Put("MOV-035", NewObj(2).Put("s3", ((V)("track"))).Put("live", ((V)("Dimming spots"))).V).Put("MOV-090", NewObj(3).Put("spec", ((V)("sphereAudio"))).Put("live", ((V)("Plasma arcs"))).Put("note", ((V)("Three glass spheres float over magnetic bases, with plasma arcs crackling inside."))).V).Put("MOV-093", NewObj(4).Put("spec", ((V)("vipPods"))).Put("colors", LEATHER_93).Put("live", ((V)("Motion sync"))).Put("note", ((V)("Three reclining leather pods on motion actuators, with lit consoles and cup holders between them."))).V).Put("MOV-077", NewObj(1).Put("spec", ((V)("vault"))).V).Put("MOV-068", NewObj(1).Put("spec", ((V)("awardSet"))).V).Put("MOV-063", NewObj(2).Put("spec", ((V)("smartConsole"))).Put("live", ((V)("Chilled"))).V).Put("MOV-087", NewObj(2).Put("spec", ((V)("robButler"))).Put("live", ((V)("Rolls around"))).V).Put("MOV-011", NewObj(1).Put("spec", ((V)("microClean"))).V).Put("MOV-005", NewObj(1).Put("s3", ((V)("concrete"))).V).Put("LIV-107", NewObj(2).Put("spec", ((V)("chester"))).Put("sx", NewObj(2).Put("n", ((V)(3D))).Put("wood", ((V)("#4a2c1a"))).V).V).Put("LIV-110", NewObj(2).Put("spec", ((V)("chester"))).Put("sx", NewObj(2).Put("n", ((V)(4D))).Put("gold", ((V)(1D))).V).V).Put("LIV-108", NewObj(2).Put("spec", ((V)("chester"))).Put("sx", NewObj(3).Put("n", ((V)(3D))).Put("leather", ((V)(1D))).Put("wood", ((V)("#3a2416"))).V).V).Put("LIV-109", NewObj(2).Put("spec", ((V)("chester"))).Put("sx", NewObj(5).Put("n", ((V)(3D))).Put("st", ((V)("channel"))).Put("boucle", ((V)(1D))).Put("plinth", ((V)("#f2efea"))).Put("pil", ((V)("#c9a35a"))).V).V).Put("LIV-066", NewObj(3).Put("spec", ((V)("cloudPit"))).Put("sx", NewObj(1).Put("n", ((V)(5D))).V).Put("colors", BOUC_94).V).Put("LIV-067", NewObj(1).Put("spec", ((V)("library"))).V).Put("LIV-047", NewObj(1).Put("spec", ((V)("archBook"))).V).Put("LIV-075", NewObj(1).Put("spec", ((V)("coneHearth"))).V).Put("LIV-070", NewObj(2).Put("spec", ((V)("shearChair"))).Put("sx", NewObj(0).V).V).Put("LIV-087", NewObj(2).Put("spec", ((V)("archiveWall"))).Put("live", ((V)("Robot arm"))).V).Put("LIV-088", NewObj(2).Put("spec", ((V)("chrono"))).Put("live", ((V)("Levitating"))).V).Put("LIV-048", NewObj(1).Put("spec", ((V)("artBooks"))).V).V);
edit2_95 = Get(RD_8, "edit");
ADD3_96 = Arr(Arr(((V)(113D)), ((V)(1D)), ((V)("Wall Surface")), ((V)("Matte Black Club Walls")), ((V)("blackWall")), ((V)("A deep matte black wall that makes every light in the room pop."))), Arr(((V)(114D)), ((V)(2D)), ((V)("Floor Surface")), ((V)("Black LED Light-Up Dance Floor")), ((V)("blackLed")), ((V)("A black floor with a light-up LED tile grid set 10 px in from every edge. The tiles cycle through neon colours in a wave."))));
Set(RD_8, "edit", Fn((V _arrowThis3692, int _argc3685, V rows_3691, V _a3688, V _a3689, V _a3690, V[] _rest3686) => {
V R_3693 = default;
R_3693 = Invoke(Call(edit2_95, V.Undef, rows_3691), "map", Fn((V _arrowThis3701, int _argc3694, V r_3700, V _a3697, V _a3698, V _a3699, V[] _rest3695) => {
return (Truthy(GetK(Get(RD_8, "SET3"), Get(r_3700, "id"))) ? Object_assign(NewObj(0).V, r_3700, GetK(Get(RD_8, "SET3"), Get(r_3700, "id"))) : r_3700);
}, 1, "", true));
Invoke(ADD3_96, "forEach", Fn((V _arrowThis3721, int _argc3702, V _a3704, V _a3705, V _a3706, V _a3707, V[] _rest3703) => {
V b_3722 = default;
V num_3710 = default;
V slot_3712 = default;
V slotName_3714 = default;
V name_3716 = default;
V s3_3718 = default;
V note_3720 = default;
{ V _t3708 = ListOf(_a3704);
{ V _t3709 = GetIdx(_t3708, 0D);
num_3710 = _t3709; }
{ V _t3711 = GetIdx(_t3708, 1D);
slot_3712 = _t3711; }
{ V _t3713 = GetIdx(_t3708, 2D);
slotName_3714 = _t3713; }
{ V _t3715 = GetIdx(_t3708, 3D);
name_3716 = _t3715; }
{ V _t3717 = GetIdx(_t3708, 4D);
s3_3718 = _t3717; }
{ V _t3719 = GetIdx(_t3708, 5D);
note_3720 = _t3719; }
}
b_3722 = Invoke(rows_3691, "find", Fn((V _arrowThis3730, int _argc3723, V r_3729, V _a3726, V _a3727, V _a3728, V[] _rest3724) => {
return (((SEqS(Get(r_3729, "room"), "CLB") && SEqN(Get(r_3729, "tier"), 3D)) && SEq(Get(r_3729, "slot"), slot_3712)) ? V.True : V.False);
}, 1, "", true));
if (Truthy(b_3722)) {
Invoke(R_3693, "push", Object_assign(NewObj(0).V, b_3722, NewObj(6).Put("id", ((V)(JsStrBuf.Begin().S("CLB-").V(num_3710).End()))).Put("slotName", slotName_3714).Put("name", name_3716).Put("s3", s3_3718).Put("note", note_3720).Put("add", ((V)(1D))).V, (SEqS(s3_3718, "blackLed") ? NewObj(1).Put("live", ((V)("Live LED"))).V : NewObj(0).V)));
}
return default;
}, 1, "", true));
return R_3693;
return default;
}, 1, "", true));
Object_assign(RD_8, NewObj(2).Put("PLUS3", ((V)(1D))).Put("H3", NewObj(24).Put("rep", rep_38).Put("rng", rng_40).Put("n4", n4_41).Put("P2", P2_42).Put("mtx", mtx_43).Put("plane", plane_44).Put("planeX", planeX_45).Put("planeH", planeH_46).Put("kOf", kOf_47).Put("an", an_51).Put("anS", anS_52).Put("at", at_54).Put("atS", atS_55).Put("BLUR", BLUR_56).Put("bbOf", bbOf_57).Put("tex", tex_59).Put("PATS", PATS_60).Put("mt", mt_33).Put("wd", wd_34).Put("cer", cer_35).Put("fb", fb_36).Put("pt", pt_37).Put("throwP", throwP_68).Put("seatC", seatC_67).V).V);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
