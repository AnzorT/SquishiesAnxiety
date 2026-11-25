// reno-plus4.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus4_js
    {

        public static void Run()
        {
Call(Named(boot_267 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V box_11 = default;
V cyl_12 = default;
V ball_13 = default;
V slab_14 = default;
V slabX_15 = default;
V arcW_16 = default;
V disc_17 = default;
V mix_18 = default;
V f1_19 = default;
V rep_20 = default;
V rng_21 = default;
V n4_22 = default;
V P2_23 = default;
V plane_24 = default;
V planeH_25 = default;
V an_26 = default;
V atS_27 = default;
V BLUR_28 = default;
V bbOf_29 = default;
V mt_30 = default;
V cer_31 = default;
V pt_32 = default;
V N_33 = default;
V em_34 = default;
V NE_35 = default;
double PI_36 = 0;
V CH_37 = default;
V WH_38 = default;
V SA_39 = default;
V MODES_40 = default;
V B_41 = default;
V anD_42 = default;
V anK_43 = default;
V nrm_44 = default;
V cyc_45 = default;
double UID_46 = 0;
V mball_47 = default;
V specks_48 = default;
V foilBall_49 = default;
V foilLight_50 = default;
V mirrorLight_51 = default;
V SURF4_52 = default;
V RGB_53 = default;
V fan_54 = default;
V jag_55 = default;
V bolt_56 = default;
V draw3_57 = default;
V edit3_58 = default;
if (_self1.IsNullish) _self1 = GlobalV;
mball_47 = Fn((V _self59, int _argc60, V cx_66, V cy_67, V R_68, V o_69, V[] _rest61) => {
V F_70 = default;
V cols_71 = default;
V rows_72 = default;
V dt_73 = default;
V e_74 = default;
double ce_75 = 0;
double se_76 = 0;
V env_77 = default;
V @base_78 = default;
V hi_79 = default;
V id_80 = default;
V pr_81 = default;
V sc_82 = default;
double gp_83 = 0;
double dph_84 = 0;
double dth_85 = 0;
JsStrBuf fr_86 = null;
V C_87 = default;
V s_88 = default;
if (_self59.IsNullish) _self59 = GlobalV;
o_69 = (o_69 is var _t89 && Truthy(_t89) ? _t89 : NewObj(0).V);
F_70 = (Get(o_69, "F") is var _t90 && Truthy(_t90) ? _t90 : ((V)(6D)));
cols_71 = (Get(o_69, "cols") is var _t91 && Truthy(_t91) ? _t91 : ((V)(18D)));
rows_72 = (Get(o_69, "rows") is var _t92 && Truthy(_t92) ? _t92 : ((V)(10D)));
dt_73 = (Get(o_69, "dt") is var _t93 && Truthy(_t93) ? _t93 : ((V)(0.09)));
e_74 = (Get(o_69, "e").IsNullish ? ((V)(0.38)) : Get(o_69, "e"));
ce_75 = FdLibm.Cos(ToNum(e_74));
se_76 = FdLibm.Sin(ToNum(e_74));
env_77 = (Get(o_69, "env") is var _t94 && Truthy(_t94) ? _t94 : Arr(NewObj(4).Put("d", Call(nrm_44, V.Undef, ((V)((-0.6))), ((V)(0.55)), ((V)(0.6)))).Put("c", ((V)("#ffffff"))).Put("p", ((V)(26D))).Put("s", ((V)(1.3))).V));
@base_78 = (Get(o_69, "base") is var _t95 && Truthy(_t95) ? _t95 : ((V)("#2e335c")));
hi_79 = (Get(o_69, "hi") is var _t96 && Truthy(_t96) ? _t96 : ((V)("#eef2ff")));
id_80 = ((V)(JsStrBuf.Begin().S("mb").N(++UID_46).End()));
pr_81 = Fn((V _arrowThis105, int _argc97, V ph_103, V th_104, V _a101, V _a102, V[] _rest98) => {
double x_106 = 0;
double y_107 = 0;
double z_108 = 0;
x_106 = (FdLibm.Cos(ToNum(ph_103)) * FdLibm.Sin(ToNum(th_104)));
y_107 = FdLibm.Sin(ToNum(ph_103));
z_108 = (FdLibm.Cos(ToNum(ph_103)) * FdLibm.Cos(ToNum(th_104)));
return Arr(((V)(x_106)), ((V)(((y_107 * ce_75) - (z_108 * se_76)))), ((V)(((y_107 * se_76) + (z_108 * ce_75)))));
return default;
}, 2, "", true);
sc_82 = Fn((V _arrowThis116, int _argc109, V v_115, V _a112, V _a113, V _a114, V[] _rest110) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_19, V.Undef, Add(cx_66, ((V)((ToNum(R_68) * ToNum(GetIdx(v_115, 0D)))))))).S(" ").V(Call(f1_19, V.Undef, ((V)((ToNum(cy_67) - (ToNum(R_68) * ToNum(GetIdx(v_115, 1D)))))))).End()));
}, 1, "", true);
gp_83 = 0.11;
dph_84 = (PI_36 / ToNum(rows_72));
dth_85 = ((2D * PI_36) / ToNum(cols_71));
fr_86 = new JsStrBuf("");
{
V f_117 = default;
f_117 = ((V)(0D));
while (true) {
V f_117_it = f_117;
if (!(Lt(f_117_it, F_70))) break;
JsStrBuf g_119 = null;
g_119 = new JsStrBuf("");
{
double i_120 = 0;
i_120 = 0D;
while (true) {
if (!(Lt(((V)(i_120)), rows_72))) break;
double p0_122 = 0;
double pa_123 = 0;
double pb_124 = 0;
double pc_125 = 0;
p0_122 = (((-PI_36) / 2D) + (i_120 * dph_84));
pa_123 = (p0_122 + (dph_84 * gp_83));
pb_124 = (p0_122 + (dph_84 * (1D - gp_83)));
pc_125 = (p0_122 + (dph_84 / 2D));
{
double j_126 = 0;
j_126 = 0D;
while (true) {
if (!(Lt(((V)(j_126)), cols_71))) break;
double t0_128 = 0;
double ta_129 = 0;
double tb_130 = 0;
V n_131 = default;
V r_132 = default;
V col_133 = default;
t0_128 = ((j_126 * dth_85) + ((ToNum(f_117_it) * dth_85) / ToNum(F_70)));
ta_129 = (t0_128 + (dth_85 * gp_83));
tb_130 = (t0_128 + (dth_85 * (1D - gp_83)));
n_131 = Call(pr_81, V.Undef, ((V)(pc_125)), ((V)((t0_128 + (dth_85 / 2D)))));
if (LtN(GetIdx(n_131, 2D), 0.05)) {
goto _cont127;
}
r_132 = Arr(((V)(((2D * ToNum(GetIdx(n_131, 2D))) * ToNum(GetIdx(n_131, 0D))))), ((V)(((2D * ToNum(GetIdx(n_131, 2D))) * ToNum(GetIdx(n_131, 1D))))), ((V)((((2D * ToNum(GetIdx(n_131, 2D))) * ToNum(GetIdx(n_131, 2D))) - 1D))));
col_133 = Call(mix_18, V.Undef, @base_78, hi_79, ((V)(Max(0D, Min(1D, ((0.14 + ((0.3 * ToNum(Add(GetIdx(n_131, 1D), ((V)(1D))))) / 2D)) + (0.14 * ToNum(GetIdx(n_131, 2D)))))))));
Invoke(env_77, "forEach", Fn((V _arrowThis141, int _argc134, V L_140, V _a137, V _a138, V _a139, V[] _rest135) => {
double v_142 = 0;
double s_143 = 0;
v_142 = Max(0D, (((ToNum(GetIdx(r_132, 0D)) * ToNum(GetIdx(Get(L_140, "d"), 0D))) + (ToNum(GetIdx(r_132, 1D)) * ToNum(GetIdx(Get(L_140, "d"), 1D)))) + (ToNum(GetIdx(r_132, 2D)) * ToNum(GetIdx(Get(L_140, "d"), 2D)))));
s_143 = Min(1D, (Pow(v_142, ToNum(Get(L_140, "p"))) * ToNum(Get(L_140, "s"))));
if ((s_143 > 0.02)) {
col_133 = Call(mix_18, V.Undef, col_133, Get(L_140, "c"), ((V)(s_143)));
}
return default;
}, 1, "", true));
g_119.S("<path d=\"M").V(Call(sc_82, V.Undef, Call(pr_81, V.Undef, ((V)(pa_123)), ((V)(ta_129))))).S("L").V(Call(sc_82, V.Undef, Call(pr_81, V.Undef, ((V)(pa_123)), ((V)(tb_130))))).S("L").V(Call(sc_82, V.Undef, Call(pr_81, V.Undef, ((V)(pb_124)), ((V)(tb_130))))).S("L").V(Call(sc_82, V.Undef, Call(pr_81, V.Undef, ((V)(pb_124)), ((V)(ta_129))))).S("Z\" fill=\"").V(col_133).S("\"/>");
_cont127: ;
j_126++;
}
}
i_120++;
}
}
fr_86.S("<g opacity=\"").N((Truthy(f_117_it) ? 0D : 1D)).S("\">").V((GtN(F_70, 1D) ? Call(anD_42, V.Undef, ((V)("opacity")), Invoke(Call(rep_20, V.Undef, F_70, Fn((V _arrowThis151, int _argc144, V m_150, V _a147, V _a148, V _a149, V[] _rest145) => {
return ((V)((SEq(m_150, f_117_it) ? 1D : 0D)));
}, 1, "", true)), "join", ((V)(";"))), Call(n4_22, V.Undef, ((V)((ToNum(F_70) * ToNum(dt_73)))))) : ((V)("")))).S(g_119.Str).S("</g>");
f_117 = f_117_it;
PostInc(ref f_117, 1D);
}
}
C_87 = ((V)(JsStrBuf.Begin().S(" cx=\"").V(Call(f1_19, V.Undef, cx_66)).S("\" cy=\"").V(Call(f1_19, V.Undef, cy_67)).S("\" r=\"").V(Call(f1_19, V.Undef, R_68)).S("\"").End()));
s_88 = ((V)(JsStrBuf.Begin().S("<defs><radialGradient id=\"").V(id_80).S("r\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0.6\" stop-color=\"#000\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#0a0c20\" stop-opacity=\"0.6\"/></radialGradient>").S("<radialGradient id=\"").V(id_80).S("h\" cx=\"32%\" cy=\"27%\" r=\"42%\"><stop offset=\"0\" stop-color=\"#fff\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#fff\" stop-opacity=\"0\"/></radialGradient><clipPath id=\"").V(id_80).S("c\"><circle").V(C_87).S("/></clipPath></defs>").S("<circle").V(C_87).S(" fill=\"#181b38\"/><g clip-path=\"url(#").V(id_80).S("c)\">").S(fr_86.Str).S("</g><circle").V(C_87).S(" fill=\"url(#").V(id_80).S("r)\"/><circle").V(C_87).S(" fill=\"url(#").V(id_80).S("h)\"/><circle").V(C_87).S(" fill=\"none\" stroke=\"#151830\" stroke-width=\"").V(Call(f1_19, V.Undef, ((V)((ToNum(R_68) * 0.035))))).S("\"/>").End()));
return NewObj(2).Put("s", s_88).Put("T", ((V)(((ToNum(cols_71) * ToNum(F_70)) * ToNum(dt_73))))).V;
return default;
}, 4, "mball", false);
foilBall_49 = Fn((V _self152, int _argc153, V cx_159, V cy_160, V R_161, V seed_162, V[] _rest154) => {
V Rn_163 = default;
double n_164 = 0;
V id_165 = default;
V pts_166 = default;
V outl_167 = default;
JsStrBuf s_168 = null;
JsStrBuf d_169 = null;
if (_self152.IsNullish) _self152 = GlobalV;
Rn_163 = Call(rng_21, V.Undef, seed_162);
n_164 = 15D;
id_165 = ((V)(JsStrBuf.Begin().S("fb").N(++UID_46).End()));
pts_166 = Call(rep_20, V.Undef, ((V)(n_164)), Fn((V _arrowThis177, int _argc170, V i_176, V _a173, V _a174, V _a175, V[] _rest171) => {
double a_178 = 0;
double r_179 = 0;
a_178 = (((ToNum(i_176) / n_164) * 2D) * PI_36);
r_179 = (ToNum(R_161) * (0.86 + (ToNum(Call(Rn_163, V.Undef)) * 0.22)));
return Arr(Add(cx_159, ((V)((FdLibm.Cos(a_178) * r_179)))), Add(cy_160, ((V)((FdLibm.Sin(a_178) * r_179)))));
return default;
}, 1, "", true));
outl_167 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_166, "map", P2_23), "join", ((V)("L")))).S("Z").End()));
s_168 = new JsStrBuf(JsStrBuf.Begin().S("<defs><radialGradient id=\"").V(id_165).S("g\" cx=\"34%\" cy=\"30%\" r=\"75%\"><stop offset=\"0\" stop-color=\"#fbfcfe\"/><stop offset=\"0.5\" stop-color=\"#c3c9d2\"/><stop offset=\"1\" stop-color=\"#737a86\"/></radialGradient><clipPath id=\"").V(id_165).S("c\"><path d=\"").V(outl_167).S("\"/></clipPath></defs>").End());
s_168.S("<path d=\"").V(outl_167).S("\" fill=\"url(#").V(id_165).S("g)\"/><g clip-path=\"url(#").V(id_165).S("c)\">");
Call(rep_20, V.Undef, ((V)(18D)), Fn((V _arrowThis187, int _argc180, V i_186, V _a183, V _a184, V _a185, V[] _rest181) => {
double a_188 = 0;
double rr_189 = 0;
V x_190 = default;
V y_191 = default;
double s2_192 = 0;
double b_193 = 0;
V lit_194 = default;
a_188 = ((ToNum(Call(Rn_163, V.Undef)) * 2D) * PI_36);
rr_189 = ((ToNum(Call(Rn_163, V.Undef)) * ToNum(R_161)) * 0.8);
x_190 = Add(cx_159, ((V)((FdLibm.Cos(a_188) * rr_189))));
y_191 = Add(cy_160, ((V)((FdLibm.Sin(a_188) * rr_189))));
s2_192 = (ToNum(R_161) * (0.18 + (ToNum(Call(Rn_163, V.Undef)) * 0.22)));
b_193 = (ToNum(Call(Rn_163, V.Undef)) * PI_36);
lit_194 = ((((ToNum(x_190) - ToNum(cx_159)) + (ToNum(y_191) - ToNum(cy_160))) < 0D) ? V.True : V.False);
s_168.S("<path d=\"M").V(Invoke(Invoke(Arr(((V)(0D)), ((V)(2.1)), ((V)(4.2))), "map", Fn((V _arrowThis202, int _argc195, V k2_201, V _a198, V _a199, V _a200, V[] _rest196) => {
return Call(P2_23, V.Undef, Arr(Add(x_190, ((V)((FdLibm.Cos(ToNum(Add(((V)(b_193)), k2_201))) * s2_192)))), Add(y_191, ((V)(((FdLibm.Sin(ToNum(Add(((V)(b_193)), k2_201))) * s2_192) * 0.8))))));
}, 1, "", true)), "join", ((V)("L")))).S("Z\" fill=\"").S((((ToNum(i_186) % 4D) == 0D) ? "#ffffff" : (Truthy(lit_194) ? "#e8ecf2" : "#858c97"))).S("\" opacity=\"").N((((ToNum(i_186) % 4D) == 0D) ? 0.85 : 0.5)).S("\"/>");
return default;
}, 1, "", true));
d_169 = new JsStrBuf("");
Call(rep_20, V.Undef, ((V)(11D)), Fn((V _arrowThis209, int _argc203, V _a205, V _a206, V _a207, V _a208, V[] _rest204) => {
V x_210 = default;
V y_211 = default;
x_210 = Add(cx_159, ((V)((((ToNum(Call(Rn_163, V.Undef)) - 0.5) * ToNum(R_161)) * 1.4))));
y_211 = Add(cy_160, ((V)((((ToNum(Call(Rn_163, V.Undef)) - 0.5) * ToNum(R_161)) * 1.4))));
d_169.S("M").V(Call(f1_19, V.Undef, x_210)).S(" ").V(Call(f1_19, V.Undef, y_211));
Call(rep_20, V.Undef, ((V)(3D)), Fn((V _arrowThis218, int _argc212, V _a214, V _a215, V _a216, V _a217, V[] _rest213) => {
x_210 = Add(x_210, ((V)((((ToNum(Call(Rn_163, V.Undef)) - 0.5) * ToNum(R_161)) * 0.55))));
y_211 = Add(y_211, ((V)((((ToNum(Call(Rn_163, V.Undef)) - 0.5) * ToNum(R_161)) * 0.55))));
d_169.S("L").V(Call(f1_19, V.Undef, x_210)).S(" ").V(Call(f1_19, V.Undef, y_211));
return default;
}, 0, "", true));
return default;
}, 0, "", true));
s_168.S("<path d=\"").S(d_169.Str).S("\" fill=\"none\" stroke=\"#565c66\" stroke-width=\"0.32\" opacity=\"0.6\"/><path d=\"").S(d_169.Str).S("\" transform=\"translate(0.3 0.3)\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.22\" opacity=\"0.5\"/></g>");
return NewObj(2).Put("s", ((V)(JsStrBuf.Begin().S(s_168.Str).S("<path d=\"").V(outl_167).S("\" fill=\"none\" stroke=\"#5f6670\" stroke-width=\"0.45\"/>").End()))).Put("clip", ((V)(JsStrBuf.Begin().V(id_165).S("c").End()))).V;
return default;
}, 4, "foilBall", false);
foilLight_50 = Fn((V _self219, int _argc220, V _a222, V _a223, V _a224, V _a225, V[] _rest221) => {
V BC_226 = default;
V fb_227 = default;
JsStrBuf s_228 = null;
if (_self219.IsNullish) _self219 = GlobalV;
BC_226 = ((V)("#5aa0ff"));
fb_227 = Call(foilBall_49, V.Undef, ((V)(9D)), ((V)(29D)), ((V)(7.4)), ((V)("foil6")));
s_228 = new JsStrBuf(JsStrBuf.Begin().S("<defs><radialGradient id=\"pbG\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"").V(BC_226).S("\" stop-opacity=\"0.75\"/><stop offset=\"0.35\" stop-color=\"").V(BC_226).S("\" stop-opacity=\"0.32\"/><stop offset=\"1\" stop-color=\"").V(BC_226).S("\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"pbC\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"").V(BC_226).S("\" stop-opacity=\"0.35\"/><stop offset=\"1\" stop-color=\"").V(BC_226).S("\" stop-opacity=\"0\"/></linearGradient>").S("<radialGradient id=\"pbB\" cx=\"45%\" cy=\"40%\" r=\"60%\"><stop offset=\"0\" stop-color=\"#eef6ff\"/><stop offset=\"0.45\" stop-color=\"#9cc8ff\"/><stop offset=\"1\" stop-color=\"").V(BC_226).S("\"/></radialGradient></defs>").End());
s_228.S("<g>").V(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.86;1;0.86")), ((V)(3.4)))).S("<path d=\"M-23.5 17L-36 60H-4L-16.5 17Z\" fill=\"url(#pbC)\"/><circle cx=\"-20\" cy=\"14\" r=\"24\" fill=\"url(#pbG)\"/></g>");
s_228.S("<rect x=\"-36\" y=\"-3.4\" width=\"34\" height=\"3.4\" rx=\"1.7\" fill=\"#a3a9b1\" stroke=\"#5f646c\" stroke-width=\"0.5\"/><path d=\"M-35 -2.6H-3\" stroke=\"#e4e8ee\" stroke-width=\"0.6\" opacity=\"0.8\"/>");
s_228.S("<path d=\"M-27 -5L-23.5 -3.6M-27 1.4L-23.5 0.2\" stroke=\"#2a2b30\" stroke-width=\"1.4\" stroke-linecap=\"round\"/><rect x=\"-23.5\" y=\"-4.6\" width=\"7\" height=\"1.8\" rx=\"0.6\" fill=\"#2a2b30\"/><rect x=\"-23.5\" y=\"-0.6\" width=\"7\" height=\"1.8\" rx=\"0.6\" fill=\"#2a2b30\"/><circle cx=\"-24.6\" cy=\"-1.7\" r=\"1.3\" fill=\"none\" stroke=\"#8a8f98\" stroke-width=\"0.6\"/>");
s_228.S("<rect x=\"-22.4\" y=\"1.2\" width=\"4.8\" height=\"6\" rx=\"1\" fill=\"#2a2b30\"/><rect x=\"-23\" y=\"6.6\" width=\"6\" height=\"1.7\" rx=\"0.5\" fill=\"#b8bcc4\"/>");
s_228.S("<path d=\"M-22.4 8.3C-25.6 10 -26.2 15.6 -20 19.6C-13.8 15.6 -14.4 10 -17.6 8.3Z\" fill=\"url(#pbB)\" stroke=\"#3f7fd8\" stroke-width=\"0.4\"/><ellipse cx=\"-21.6\" cy=\"12\" rx=\"1\" ry=\"2.2\" fill=\"#ffffff\" opacity=\"0.75\"/>");
s_228.S("<path d=\"M9 -4V22.4\" stroke=\"#d8d2c4\" stroke-width=\"0.5\"/><rect x=\"5.6\" y=\"-4\" width=\"6.8\" height=\"3\" rx=\"0.4\" fill=\"#efe3b8\" opacity=\"0.92\" transform=\"rotate(-6 9 -2.5)\"/>").V(Get(fb_227, "s"));
s_228.S("<g clip-path=\"url(#").V(Get(fb_227, "clip")).S(")\"><circle cx=\"2\" cy=\"27\" r=\"7.2\" fill=\"").V(BC_226).S("\" opacity=\"0.4\">").V(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.32;0.45;0.32")), ((V)(3.4)))).S("</circle><circle cx=\"4.6\" cy=\"26\" r=\"1.1\" fill=\"#dff0ff\"/></g>");
return NewObj(2).Put("vb", ((V)("-46 -4 92 64"))).Put("body", ((V)(s_228.Str))).V;
return default;
}, 0, "foilLight", false);
mirrorLight_51 = Fn((V _self229, int _argc230, V _a232, V _a233, V _a234, V _a235, V[] _rest231) => {
double cx_236 = 0;
double cy_237 = 0;
double R_238 = 0;
V ENV_239 = default;
V MB_240 = default;
V T_241 = default;
double Lr_242 = 0;
double sx_243 = 0;
double sy_244 = 0;
double a_245 = 0;
double ca_246 = 0;
double sa_247 = 0;
double lx_248 = 0;
double ly_249 = 0;
double px_250 = 0;
double py_251 = 0;
JsStrBuf s_252 = null;
if (_self229.IsNullish) _self229 = GlobalV;
cx_236 = 0D;
cy_237 = 34D;
R_238 = 19D;
ENV_239 = Arr(NewObj(4).Put("d", Call(nrm_44, V.Undef, ((V)((-0.62))), ((V)(0.5)), ((V)(0.6)))).Put("c", ((V)("#ffffff"))).Put("p", ((V)(22D))).Put("s", ((V)(1.5))).V, NewObj(4).Put("d", Call(nrm_44, V.Undef, ((V)(0.75)), ((V)(0.15)), ((V)(0.62)))).Put("c", ((V)("#9cc4ff"))).Put("p", ((V)(16D))).Put("s", ((V)(0.8))).V, NewObj(4).Put("d", Call(nrm_44, V.Undef, ((V)(0.15)), ((V)((-0.65))), ((V)(0.74)))).Put("c", ((V)("#ffe08a"))).Put("p", ((V)(16D))).Put("s", ((V)(0.6))).V);
MB_240 = Call(mball_47, V.Undef, ((V)(cx_236)), ((V)(cy_237)), ((V)(R_238)), NewObj(5).Put("env", ENV_239).Put("F", ((V)(6D))).Put("cols", ((V)(18D))).Put("rows", ((V)(10D))).Put("dt", ((V)(0.09))).V);
T_241 = Get(MB_240, "T");
Lr_242 = 50D;
sx_243 = (-46D);
sy_244 = 4D;
a_245 = FdLibm.Atan2((cy_237 - sy_244), (cx_236 - sx_243));
ca_246 = FdLibm.Cos(a_245);
sa_247 = FdLibm.Sin(a_245);
lx_248 = (sx_243 + (ca_246 * 6.5));
ly_249 = (sy_244 + (sa_247 * 6.5));
px_250 = (-sa_247);
py_251 = ca_246;
s_252 = new JsStrBuf(JsStrBuf.Begin().S("<defs><radialGradient id=\"mrH\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fffbe8\" stop-opacity=\"0.75\"/><stop offset=\"0.4\" stop-color=\"#fffbe8\" stop-opacity=\"0.28\"/><stop offset=\"1\" stop-color=\"#fffbe8\" stop-opacity=\"0\"/></radialGradient>").S("<radialGradient id=\"mrR\" gradientUnits=\"userSpaceOnUse\" cx=\"0\" cy=\"0\" r=\"").N(Lr_242).S("\"><stop offset=\"0.25\" stop-color=\"#ffffff\" stop-opacity=\"0.55\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"mrB\" gradientUnits=\"userSpaceOnUse\" x1=\"").V(Call(f1_19, V.Undef, ((V)(lx_248)))).S("\" y1=\"").V(Call(f1_19, V.Undef, ((V)(ly_249)))).S("\" x2=\"").V(Call(f1_19, V.Undef, ((V)(cx_236)))).S("\" y2=\"").V(Call(f1_19, V.Undef, ((V)(cy_237)))).S("\"><stop offset=\"0\" stop-color=\"#fffbe8\" stop-opacity=\"0.85\"/><stop offset=\"1\" stop-color=\"#fffbe8\" stop-opacity=\"0.3\"/></linearGradient>").V(Call(BLUR_28, V.Undef, ((V)("mrS")), ((V)(0.8)))).S("</defs>").End());
s_252.S("<circle cx=\"").N(cx_236).S("\" cy=\"").N(cy_237).S("\" r=\"46\" fill=\"url(#mrH)\">").V(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.8;1;0.8")), ((V)(1.6)))).S("</circle>");
s_252.S("<g transform=\"translate(").N(cx_236).S(" ").N(cy_237).S(")\"><g>").S("<animateTransform attributeName=\"transform\" type=\"rotate\" values=\"0;360\" dur=\"").V(Call(n4_22, V.Undef, ((V)((ToNum(T_241) * 1.5))))).S("s\" repeatCount=\"indefinite\"/>").V(Invoke(Call(rep_20, V.Undef, ((V)(12D)), Fn((V _arrowThis260, int _argc253, V i_259, V _a256, V _a257, V _a258, V[] _rest254) => {
double b_261 = 0;
double w_262 = 0;
b_261 = ((ToNum(i_259) * PI_36) / 6D);
w_262 = 0.09;
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 0L").V(Call(f1_19, V.Undef, ((V)((FdLibm.Cos((b_261 - w_262)) * Lr_242))))).S(" ").V(Call(f1_19, V.Undef, ((V)((FdLibm.Sin((b_261 - w_262)) * Lr_242))))).S("L").V(Call(f1_19, V.Undef, ((V)((FdLibm.Cos((b_261 + w_262)) * Lr_242))))).S(" ").V(Call(f1_19, V.Undef, ((V)((FdLibm.Sin((b_261 + w_262)) * Lr_242))))).S("Z\" fill=\"url(#mrR)\" opacity=\"").N((NumTruthy((ToNum(i_259) % 2D)) ? 0.55 : 0.9)).S("\">").V(Call(an_26, V.Undef, ((V)("opacity")), ((V)((NumTruthy((ToNum(i_259) % 2D)) ? "0.35;0.7;0.35" : "0.9;0.55;0.9"))), ((V)((1.3 + ((ToNum(i_259) % 3D) * 0.3)))))).S("</path>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g></g>");
s_252.S("<g filter=\"url(#mrS)\" opacity=\"0.6\">").V(Call(specks_48, V.Undef, ((V)(cx_236)), ((V)(cy_237)), ((V)(48D)), ((V)(25D)), ((V)(9D)), T_241, Arr(((V)("#ffffff")), ((V)("#cfe0ff"))), ((V)(2.2)))).S("</g>").V(Call(specks_48, V.Undef, ((V)(cx_236)), ((V)(cy_237)), ((V)(48D)), ((V)(25D)), ((V)(16D)), T_241, Arr(((V)("#ffffff")), ((V)("#dbe8ff")), ((V)("#fff4c8"))), ((V)(1.9))));
s_252.S("<path d=\"M").V(Call(f1_19, V.Undef, ((V)((lx_248 + (px_250 * 2.2)))))).S(" ").V(Call(f1_19, V.Undef, ((V)((ly_249 + (py_251 * 2.2)))))).S("L").V(Call(f1_19, V.Undef, ((V)((cx_236 + ((px_250 * R_238) * 0.8)))))).S(" ").V(Call(f1_19, V.Undef, ((V)((cy_237 + ((py_251 * R_238) * 0.8)))))).S("L").V(Call(f1_19, V.Undef, ((V)((cx_236 - ((px_250 * R_238) * 0.8)))))).S(" ").V(Call(f1_19, V.Undef, ((V)((cy_237 - ((py_251 * R_238) * 0.8)))))).S("L").V(Call(f1_19, V.Undef, ((V)((lx_248 - (px_250 * 2.2)))))).S(" ").V(Call(f1_19, V.Undef, ((V)((ly_249 - (py_251 * 2.2)))))).S("Z\" fill=\"url(#mrB)\">").V(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.9;1;0.9")), ((V)(1.6)))).S("</path>");
s_252.S("<path d=\"M0 -4V8\" stroke=\"#9aa0ae\" stroke-width=\"1.6\"/><rect x=\"-5.5\" y=\"6.5\" width=\"11\" height=\"7\" rx=\"2\" fill=\"#2c2e38\" stroke=\"#16171d\" stroke-width=\"0.5\"/><rect x=\"-4\" y=\"8\" width=\"8\" height=\"1.2\" rx=\"0.6\" fill=\"#4a4d5a\"/><path d=\"M0 13.5V15.6\" stroke=\"#c9cde8\" stroke-width=\"1.2\"/><circle cx=\"3\" cy=\"10.8\" r=\"0.8\" fill=\"#6fe39a\">").V(Call(an_26, V.Undef, ((V)("opacity")), ((V)("1;0.3;1")), ((V)(1D)))).S("</circle>");
s_252.V(Get(MB_240, "s"));
s_252.S("<path d=\"M").N(sx_243).S(" -4V").N((sy_244 - 3D)).S("\" stroke=\"#5f646c\" stroke-width=\"1.2\"/><path d=\"M").N((sx_243 - 4D)).S(" ").N((sy_244 - 3D)).S("H").N((sx_243 + 4D)).S("\" stroke=\"#5f646c\" stroke-width=\"1.2\" stroke-linecap=\"round\"/>");
s_252.S("<g transform=\"translate(").N(sx_243).S(" ").N(sy_244).S(") rotate(").V(Call(f1_19, V.Undef, ((V)(((a_245 * 180D) / PI_36))))).S(")\"><rect x=\"-6\" y=\"-3.6\" width=\"12\" height=\"7.2\" rx=\"1.6\" fill=\"#2a2b30\" stroke=\"#121317\" stroke-width=\"0.5\"/><rect x=\"-4\" y=\"-3.6\" width=\"1\" height=\"7.2\" fill=\"#3e4048\"/><rect x=\"5.4\" y=\"-3\" width=\"1.6\" height=\"6\" rx=\"0.5\" fill=\"#fffbe8\"/><circle cx=\"7\" cy=\"0\" r=\"2.4\" fill=\"#fffbe8\" opacity=\"0.6\"/></g>");
return NewObj(2).Put("vb", ((V)("-58 -4 116 84"))).Put("body", ((V)(s_252.Str))).V;
return default;
}, 0, "mirrorLight", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((RD_8 is var _t263 && !Truthy(_t263) ? _t263 : Get(RD_8, "PLUS3")) is var _t264 && !Truthy(_t264) ? _t264 : Get(RD_8, "H3")) is var _t265 && !Truthy(_t265) ? _t265 : X_9) is var _t266 && !Truthy(_t266) ? _t266 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_267.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS4"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t268 = K_10;
if (_t268.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t268));
{ V _t269 = Get(_t268, "box");
box_11 = _t269; }
{ V _t270 = Get(_t268, "cyl");
cyl_12 = _t270; }
{ V _t271 = Get(_t268, "ball");
ball_13 = _t271; }
{ V _t272 = Get(_t268, "slab");
slab_14 = _t272; }
{ V _t273 = Get(_t268, "slabX");
slabX_15 = _t273; }
{ V _t274 = Get(_t268, "arcW");
arcW_16 = _t274; }
{ V _t275 = Get(_t268, "disc");
disc_17 = _t275; }
{ V _t276 = Get(_t268, "mix");
mix_18 = _t276; }
{ V _t277 = Get(_t268, "f1");
f1_19 = _t277; } }
{ V _t278 = Get(RD_8, "H3");
if (_t278.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t278));
{ V _t279 = Get(_t278, "rep");
rep_20 = _t279; }
{ V _t280 = Get(_t278, "rng");
rng_21 = _t280; }
{ V _t281 = Get(_t278, "n4");
n4_22 = _t281; }
{ V _t282 = Get(_t278, "P2");
P2_23 = _t282; }
{ V _t283 = Get(_t278, "plane");
plane_24 = _t283; }
{ V _t284 = Get(_t278, "planeH");
planeH_25 = _t284; }
{ V _t285 = Get(_t278, "an");
an_26 = _t285; }
{ V _t286 = Get(_t278, "atS");
atS_27 = _t286; }
{ V _t287 = Get(_t278, "BLUR");
BLUR_28 = _t287; }
{ V _t288 = Get(_t278, "bbOf");
bbOf_29 = _t288; }
{ V _t289 = Get(_t278, "mt");
mt_30 = _t289; }
{ V _t290 = Get(_t278, "cer");
cer_31 = _t290; }
{ V _t291 = Get(_t278, "pt");
pt_32 = _t291; } }
N_33 = Get(RD_8, "N");
em_34 = Get(Get(RD_8, "H"), "em");
NE_35 = Get(K_10, "NEON");
PI_36 = System.Math.PI;
CH_37 = ((V)("#d5dde2"));
WH_38 = ((V)("#ffffff"));
SA_39 = Get(X_9, "SA");
MODES_40 = (Get(RD_8, "MODES") is var _t292 && Truthy(_t292) ? _t292 : Arr(((V)("Wave")), ((V)("Pulse")), ((V)("Rainbow")), ((V)("Chase"))));
B_41 = Fn((V _arrowThis300, int _argc293, V b_299, V _a296, V _a297, V _a298, V[] _rest294) => {
return ((V)((Truthy(b_299) ? JsStrBuf.Begin().S(" begin=\"").V(Call(n4_22, V.Undef, b_299)).S("s\"").End() : "")));
}, 1, "", true);
anD_42 = Fn((V _arrowThis311, int _argc301, V a_307, V v_308, V d_309, V b_310, V[] _rest302) => {
return ((V)(JsStrBuf.Begin().S("<animate attributeName=\"").V(a_307).S("\" values=\"").V(v_308).S("\" dur=\"").V(d_309).S("s\" calcMode=\"discrete\"").V(Call(B_41, V.Undef, b_310)).S(" repeatCount=\"indefinite\"/>").End()));
}, 4, "", true);
anK_43 = Fn((V _arrowThis323, int _argc312, V a_318, V v_319, V d_320, V kts_321, V[] _rest313) => {
V b_322 = default;
b_322 = (_argc312 > 4 ? _rest313[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<animate attributeName=\"").V(a_318).S("\" values=\"").V(v_319).S("\" keyTimes=\"").V(kts_321).S("\" dur=\"").V(d_320).S("s\"").V(Call(B_41, V.Undef, b_322)).S(" repeatCount=\"indefinite\"/>").End()));
}, 5, "", true);
nrm_44 = Fn((V _arrowThis333, int _argc324, V x_330, V y_331, V z_332, V _a329, V[] _rest325) => {
V l_334 = default;
l_334 = (((V)(Hypot(ToNum(x_330), ToNum(y_331), ToNum(z_332)))) is var _t335 && Truthy(_t335) ? _t335 : ((V)(1D)));
return Arr(((V)((ToNum(x_330) / ToNum(l_334)))), ((V)((ToNum(y_331) / ToNum(l_334)))), ((V)((ToNum(z_332) / ToNum(l_334)))));
return default;
}, 3, "", true);
cyc_45 = Fn((V _arrowThis344, int _argc336, V arr_342, V k_343, V _a340, V _a341, V[] _rest337) => {
k_343 = ((V)((ToNum(Add(((V)((ToNum(k_343) % ToNum(Get(arr_342, "length"))))), Get(arr_342, "length"))) % ToNum(Get(arr_342, "length")))));
return Invoke(Invoke(Invoke(arr_342, "slice", k_343), "concat", Invoke(arr_342, "slice", ((V)(0D)), k_343), Arr(GetK(arr_342, k_343))), "join", ((V)(";")));
return default;
}, 2, "", true);
UID_46 = 0D;
specks_48 = Fn((V _arrowThis359, int _argc345, V cx_351, V cy_352, V rx_353, V ry_354, V[] _rest346) => {
V path_360 = default;
V n_355 = default;
V T_356 = default;
V cols_357 = default;
V sz_358 = default;
n_355 = (_argc345 > 4 ? _rest346[0] : V.Undef);
T_356 = (_argc345 > 5 ? _rest346[1] : V.Undef);
cols_357 = (_argc345 > 6 ? _rest346[2] : V.Undef);
sz_358 = (_argc345 > 7 ? _rest346[3] : V.Undef);
path_360 = ((V)(JsStrBuf.Begin().S("M").V(Call(f1_19, V.Undef, ((V)((ToNum(cx_351) - ToNum(rx_353)))))).S(" ").V(Call(f1_19, V.Undef, cy_352)).S("A").V(Call(f1_19, V.Undef, rx_353)).S(" ").V(Call(f1_19, V.Undef, ry_354)).S(" 0 1 0 ").V(Call(f1_19, V.Undef, Add(cx_351, rx_353))).S(" ").V(Call(f1_19, V.Undef, cy_352)).S("A").V(Call(f1_19, V.Undef, rx_353)).S(" ").V(Call(f1_19, V.Undef, ry_354)).S(" 0 1 0 ").V(Call(f1_19, V.Undef, ((V)((ToNum(cx_351) - ToNum(rx_353)))))).S(" ").V(Call(f1_19, V.Undef, cy_352)).End()));
return Invoke(Call(rep_20, V.Undef, n_355, Fn((V _arrowThis368, int _argc361, V i_367, V _a364, V _a365, V _a366, V[] _rest362) => {
double b_369 = 0;
V c_370 = default;
double s_371 = 0;
double q_372 = 0;
b_369 = (-ToNum(Call(n4_22, V.Undef, ((V)(((ToNum(T_356) * ToNum(i_367)) / ToNum(n_355)))))));
c_370 = GetIdx(cols_357, (ToNum(i_367) % ToNum(Get(cols_357, "length"))));
s_371 = (ToNum(sz_358) * (0.7 + (((ToNum(i_367) * 37D) % 10D) / 18D)));
q_372 = (s_371 * 0.28);
return ((V)(JsStrBuf.Begin().S("<g>").S("<circle r=\"").V(Call(f1_19, V.Undef, ((V)((s_371 * 1.1))))).S("\" fill=\"").V(c_370).S("\" opacity=\"0.3\"/><path d=\"M0 ").V(Call(f1_19, V.Undef, ((V)((-s_371))))).S("L").V(Call(f1_19, V.Undef, ((V)(q_372)))).S(" ").V(Call(f1_19, V.Undef, ((V)((-q_372))))).S("L").V(Call(f1_19, V.Undef, ((V)(s_371)))).S(" 0L").V(Call(f1_19, V.Undef, ((V)(q_372)))).S(" ").V(Call(f1_19, V.Undef, ((V)(q_372)))).S("L0 ").V(Call(f1_19, V.Undef, ((V)(s_371)))).S("L").V(Call(f1_19, V.Undef, ((V)((-q_372))))).S(" ").V(Call(f1_19, V.Undef, ((V)(q_372)))).S("L").V(Call(f1_19, V.Undef, ((V)((-s_371))))).S(" 0L").V(Call(f1_19, V.Undef, ((V)((-q_372))))).S(" ").V(Call(f1_19, V.Undef, ((V)((-q_372))))).S("Z\" fill=\"").V(c_370).S("\"/>").S("<animateMotion dur=\"").V(Call(n4_22, V.Undef, T_356)).S("s\" begin=\"").N(b_369).S("s\" repeatCount=\"indefinite\" path=\"").V(path_360).S("\"/>").V(Call(anK_43, V.Undef, ((V)("opacity")), ((V)("1;1;0.12;0.12;1")), Call(n4_22, V.Undef, T_356), ((V)("0;0.44;0.54;0.94;1")), ((V)(b_369)))).S("</g>").End()));
return default;
}, 1, "", true)), "join", ((V)("")));
return default;
}, 8, "", true);
SURF4_52 = NewObj(2).Put("foil", foilLight_50).Put("mirror", mirrorLight_51).V;
RGB_53 = Arr(((V)("#ff3b3b")), ((V)("#3bff6a")), ((V)("#3b8bff")), ((V)("#ffe23b")), ((V)("#3bf0ff")), ((V)("#b04bff")));
fan_54 = Fn((V _arrowThis382, int _argc373, V o_379, V k_380, V F_381, V _a378, V[] _rest374) => {
V n_383 = default;
V cols_384 = default;
V vals_385 = default;
V ang_386 = default;
double L_387 = 0;
V E_388 = default;
V c0_389 = default;
V ph_390 = default;
JsStrBuf glow_391 = null;
JsStrBuf core_392 = null;
JsStrBuf dots_393 = null;
V sheet_394 = default;
V rot_395 = default;
n_383 = Get(F_381, "n");
cols_384 = (Get(F_381, "cols") is var _t396 && Truthy(_t396) ? _t396 : RGB_53);
vals_385 = Call(cyc_45, V.Undef, cols_384, (Get(F_381, "ci") is var _t397 && Truthy(_t397) ? _t397 : ((V)(0D))));
ang_386 = Call(rep_20, V.Undef, n_383, Fn((V _arrowThis405, int _argc398, V i_404, V _a401, V _a402, V _a403, V[] _rest399) => {
return ((V)(((ToNum(Add(Get(F_381, "c0"), ((V)((GtN(n_383, 1D) ? ((((ToNum(i_404) / (ToNum(n_383) - 1D)) - 0.5) * 2D) * ToNum(Get(F_381, "sp"))) : 0D))))) * PI_36) / 180D)));
}, 1, "", true));
L_387 = (ToNum(Get(F_381, "L")) * ToNum(k_380));
E_388 = Invoke(ang_386, "map", Fn((V _arrowThis413, int _argc406, V a_412, V _a409, V _a410, V _a411, V[] _rest407) => {
return Arr(Add(GetIdx(o_379, 0D), ((V)((FdLibm.Sin(ToNum(a_412)) * L_387)))), ((V)((ToNum(GetIdx(o_379, 1D)) - (FdLibm.Cos(ToNum(a_412)) * L_387)))));
}, 1, "", true));
c0_389 = GetIdx(cols_384, (ToNum((Get(F_381, "ci") is var _t414 && Truthy(_t414) ? _t414 : ((V)(0D)))) % ToNum(Get(cols_384, "length"))));
ph_390 = (Get(F_381, "ph") is var _t415 && Truthy(_t415) ? _t415 : ((V)(0D)));
glow_391 = new JsStrBuf("");
core_392 = new JsStrBuf("");
dots_393 = new JsStrBuf("");
Invoke(E_388, "forEach", Fn((V _arrowThis424, int _argc416, V e_422, V i_423, V _a420, V _a421, V[] _rest417) => {
V d_425 = default;
d_425 = ((V)(JsStrBuf.Begin().S("M").V(Call(P2_23, V.Undef, o_379)).S("L").V(Call(P2_23, V.Undef, e_422)).End()));
glow_391.S("<path d=\"").V(d_425).S("\"/>");
core_392.S("<path d=\"").V(d_425).S("\"/>");
dots_393.S("<circle cx=\"").V(Call(f1_19, V.Undef, GetIdx(e_422, 0D))).S("\" cy=\"").V(Call(f1_19, V.Undef, GetIdx(e_422, 1D))).S("\" r=\"").V(Call(f1_19, V.Undef, ((V)((1.5 * ToNum(k_380)))))).S("\" fill=\"").V(c0_389).S("\">").V(Call(an_26, V.Undef, ((V)("fill")), vals_385, (Get(F_381, "cd") is var _t426 && Truthy(_t426) ? _t426 : ((V)(4D))), ((V)((-ToNum(ph_390)))))).S("</circle>");
return default;
}, 2, "", true));
sheet_394 = ((V)((GtN(n_383, 1D) ? JsStrBuf.Begin().S("<path d=\"M").V(Call(P2_23, V.Undef, o_379)).S("L").V(Call(P2_23, V.Undef, GetIdx(E_388, 0D))).S("L").V(Call(P2_23, V.Undef, GetIdx(E_388, (ToNum(n_383) - 1D)))).S("Z\" fill=\"").V(c0_389).S("\" opacity=\"0.07\">").V(Call(an_26, V.Undef, ((V)("fill")), vals_385, (Get(F_381, "cd") is var _t427 && Truthy(_t427) ? _t427 : ((V)(4D))), ((V)((-ToNum(ph_390)))))).S("</path>").End() : "")));
rot_395 = (Truthy(Get(F_381, "sw")) ? Call(atS_27, V.Undef, ((V)("rotate")), Invoke(Invoke(Arr(((V)((-ToNum(Get(F_381, "sw"))))), Get(F_381, "sw"), ((V)((-ToNum(Get(F_381, "sw")))))), "map", Fn((V _arrowThis435, int _argc428, V v_434, V _a431, V _a432, V _a433, V[] _rest429) => {
return ((V)(JsStrBuf.Begin().V(v_434).S(" ").V(Call(P2_23, V.Undef, o_379)).End()));
}, 1, "", true)), "join", ((V)(";"))), (Get(F_381, "dur") is var _t436 && Truthy(_t436) ? _t436 : ((V)(3D))), ((V)((-ToNum(ph_390))))) : ((V)("")));
return ((V)(JsStrBuf.Begin().S("<g>").V((Truthy(Get(F_381, "blink")) ? Call(anD_42, V.Undef, ((V)("opacity")), Get(F_381, "blink"), (Get(F_381, "bd") is var _t437 && Truthy(_t437) ? _t437 : ((V)(2.4))), ((V)((-ToNum(ph_390))))) : ((V)("")))).S("<g>").V(rot_395).V(sheet_394).S("<g stroke=\"").V(c0_389).S("\" stroke-width=\"").V(Call(f1_19, V.Undef, ((V)((2.8 * ToNum(k_380)))))).S("\" opacity=\"0.4\" filter=\"url(#lzb)\" stroke-linecap=\"round\">").V(Call(an_26, V.Undef, ((V)("stroke")), vals_385, (Get(F_381, "cd") is var _t438 && Truthy(_t438) ? _t438 : ((V)(4D))), ((V)((-ToNum(ph_390)))))).S(glow_391.Str).S("</g>").S("<g stroke=\"").V(c0_389).S("\" stroke-width=\"").V(Call(f1_19, V.Undef, ((V)((0.75 * ToNum(k_380)))))).S("\" stroke-linecap=\"round\">").V(Call(an_26, V.Undef, ((V)("stroke")), vals_385, (Get(F_381, "cd") is var _t439 && Truthy(_t439) ? _t439 : ((V)(4D))), ((V)((-ToNum(ph_390)))))).S(core_392.Str).S("</g>").S("<g stroke=\"#ffffff\" stroke-width=\"").V(Call(f1_19, V.Undef, ((V)((0.22 * ToNum(k_380)))))).S("\" opacity=\"0.8\">").S(core_392.Str).S("</g>").S(dots_393.Str).S("</g></g>").End()));
return default;
}, 3, "", true);
Set(N_33, "laserSphere", Fn((V _arrowThis447, int _argc440, V S_446, V _a443, V _a444, V _a445, V[] _rest441) => {
V G_448 = default;
double SY_449 = 0;
double SR_450 = 0;
V D_451 = default;
G_448 = ((V)("#23252e"));
SY_449 = 152D;
SR_450 = 24D;
D_451 = NewObj(3).Put("w", ((V)(60D))).Put("d", ((V)(60D))).Put("round", ((V)(1D))).V;
Set(D_451, "build", Fn((V _arrowThis459, int _argc452, V P_458, V _a455, V _a456, V _a457, V[] _rest453) => {
return Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(4D)), ((V)("#16171c")), Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(15D)), ((V)(3D)), G_448, Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(arcW_16, V.Undef, ((V)(0D)), ((V)(7D)), ((V)(0D)), ((V)(15D)), ((V)(15D)), ((V)(0.9)), ((V)(0.7)), ((V)(0D)), ((V)((2D * PI_36))), ((V)("#6ac8ff")), Call(em_34, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(7D)), ((V)(0D)), ((V)(3.4)), ((V)(82D)), CH_37, Call(mt_30, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(0D)), ((V)(4.8)), ((V)(3D)), G_448, Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(box_11, V.Undef, ((V)(0D)), ((V)(89D)), ((V)(0D)), ((V)(32D)), ((V)(15D)), ((V)(22D)), ((V)("#454a58")), Call(mt_30, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_11, V.Undef, ((V)(0D)), ((V)(103.4)), ((V)(0D)), ((V)(33D)), ((V)(1.4)), ((V)(23D)), CH_37, Call(mt_30, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(slabX_15, V.Undef, ((V)(0D)), ((V)(92D)), ((V)(11.2)), ((V)(22D)), ((V)(0.8)), ((V)(0.4)), ((V)("#3a3d48")), NewObj(1).Put("noOut", ((V)(1D))).V), Call(slabX_15, V.Undef, ((V)(0D)), ((V)(100D)), ((V)(11.2)), ((V)(22D)), ((V)(0.8)), ((V)(0.4)), ((V)("#3a3d48")), NewObj(1).Put("noOut", ((V)(1D))).V), Call(disc_17, V.Undef, ((V)(0D)), ((V)(96.5)), ((V)(11D)), ((V)(5.2)), ((V)(1.2)), ((V)("#0b0c10")), Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(disc_17, V.Undef, ((V)(0D)), ((V)(96.5)), ((V)(12.2)), ((V)(3.2)), ((V)(0.5)), ((V)("#e8fdff")), Call(em_34, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(disc_17, V.Undef, ((V)((-11D))), ((V)(101D)), ((V)(11D)), ((V)(1.1)), ((V)(0.5)), ((V)("#3bff6a")), Call(em_34, V.Undef)), Call(disc_17, V.Undef, ((V)((-8D))), ((V)(101D)), ((V)(11D)), ((V)(1.1)), ((V)(0.5)), ((V)("#ff3b3b")), Call(em_34, V.Undef)), Call(disc_17, V.Undef, ((V)((-5D))), ((V)(101D)), ((V)(11D)), ((V)(1.1)), ((V)(0.5)), ((V)("#3b8bff")), Call(em_34, V.Undef)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(104D)), ((V)(0D)), ((V)(4.5)), ((V)(5D)), G_448, Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(109D)), ((V)(0D)), ((V)(1.3)), ((V)(20D)), CH_37, Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(126D)), ((V)(0D)), ((V)(3.2)), ((V)(3D)), G_448, Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)));
}, 1, "", true));
Set(D_451, "fx", Fn((V _arrowThis467, int _argc460, V c_466, V _a463, V _a464, V _a465, V[] _rest461) => {
V p_468 = default;
V k_469 = default;
V o_470 = default;
V sc_471 = default;
double R_472 = 0;
V MB_473 = default;
JsStrBuf f_474 = null;
V fl_475 = default;
V un_476 = default;
double L_477 = 0;
p_468 = Get(c_466, "p");
k_469 = Get(c_466, "k");
o_470 = Call(p_468, V.Undef, ((V)(0D)), ((V)(96.5)), ((V)(12.8)));
sc_471 = Call(p_468, V.Undef, ((V)(0D)), ((V)(SY_449)), ((V)(0D)));
R_472 = (SR_450 * ToNum(k_469));
MB_473 = Call(mball_47, V.Undef, GetIdx(sc_471, 0D), GetIdx(sc_471, 1D), ((V)(R_472)), NewObj(6).Put("F", ((V)(6D))).Put("cols", ((V)(20D))).Put("rows", ((V)(11D))).Put("dt", ((V)(0.08))).Put("base", ((V)("#262a4c"))).Put("env", Arr(NewObj(4).Put("d", Call(nrm_44, V.Undef, ((V)((-0.6))), ((V)(0.55)), ((V)(0.6)))).Put("c", ((V)("#ffffff"))).Put("p", ((V)(24D))).Put("s", ((V)(1.4))).V, NewObj(4).Put("d", Call(nrm_44, V.Undef, ((V)(0.7)), ((V)(0.2)), ((V)(0.68)))).Put("c", ((V)("#ff5a5a"))).Put("p", ((V)(14D))).Put("s", ((V)(0.9))).V, NewObj(4).Put("d", Call(nrm_44, V.Undef, ((V)(0.05)), ((V)((-0.7))), ((V)(0.72)))).Put("c", ((V)("#3bff6a"))).Put("p", ((V)(14D))).Put("s", ((V)(0.9))).V, NewObj(4).Put("d", Call(nrm_44, V.Undef, ((V)((-0.75))), ((V)((-0.25))), ((V)(0.6)))).Put("c", ((V)("#3b8bff"))).Put("p", ((V)(14D))).Put("s", ((V)(0.9))).V)).V);
f_474 = new JsStrBuf("");
f_474.V(Call(fan_54, V.Undef, o_470, k_469, NewObj(10).Put("n", ((V)(7D))).Put("c0", ((V)((-40D)))).Put("sp", ((V)(26D))).Put("L", ((V)(104D))).Put("sw", ((V)(22D))).Put("dur", ((V)(3.2))).Put("ci", ((V)(1D))).Put("ph", ((V)(0D))).Put("blink", ((V)("1;1;1;0.15;1;1;0.15;1"))).Put("bd", ((V)(3.2))).V));
f_474.V(Call(fan_54, V.Undef, o_470, k_469, NewObj(10).Put("n", ((V)(7D))).Put("c0", ((V)(40D))).Put("sp", ((V)(26D))).Put("L", ((V)(104D))).Put("sw", ((V)(22D))).Put("dur", ((V)(3.2))).Put("ci", ((V)(0D))).Put("ph", ((V)(1.6))).Put("blink", ((V)("1;0.15;1;1;1;0.15;1;1"))).Put("bd", ((V)(3.2))).V));
f_474.V(Call(fan_54, V.Undef, o_470, k_469, NewObj(10).Put("n", ((V)(4D))).Put("c0", ((V)((-96D)))).Put("sp", ((V)(12D))).Put("L", ((V)(78D))).Put("sw", ((V)(14D))).Put("dur", ((V)(2.2))).Put("ci", ((V)(4D))).Put("ph", ((V)(0.7))).Put("blink", ((V)("0;1;1;0;1;1"))).Put("bd", ((V)(2.4))).V));
f_474.V(Call(fan_54, V.Undef, o_470, k_469, NewObj(10).Put("n", ((V)(4D))).Put("c0", ((V)(96D))).Put("sp", ((V)(12D))).Put("L", ((V)(78D))).Put("sw", ((V)(14D))).Put("dur", ((V)(2.2))).Put("ci", ((V)(3D))).Put("ph", ((V)(1.9))).Put("blink", ((V)("1;0;1;1;0;1"))).Put("bd", ((V)(2.4))).V));
f_474.V(Call(fan_54, V.Undef, o_470, k_469, NewObj(6).Put("n", ((V)(2D))).Put("c0", ((V)(0D))).Put("sp", ((V)(9D))).Put("L", ((V)((((SY_449 - 96.5) - (SR_450 * 0.6)) * ToNum(Get(X_9, "CA")))))).Put("ci", ((V)(2D))).Put("ph", ((V)(0D))).V));
f_474.V(Add(Get(MB_473, "s"), Call(specks_48, V.Undef, GetIdx(sc_471, 0D), GetIdx(sc_471, 1D), ((V)((R_472 * 2.6))), ((V)((R_472 * 1.15))), ((V)(18D)), Get(MB_473, "T"), RGB_53, ((V)((1.7 * ToNum(k_469)))))));
fl_475 = Call(p_468, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(14D)));
un_476 = ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_19, V.Undef, GetIdx(fl_475, 0D))).S("\" cy=\"").V(Call(f1_19, V.Undef, GetIdx(fl_475, 1D))).S("\" rx=\"").V(Call(f1_19, V.Undef, ((V)((64D * ToNum(k_469)))))).S("\" ry=\"").V(Call(f1_19, V.Undef, ((V)((((64D * ToNum(k_469)) * ToNum(SA_39)) * 0.6))))).S("\" fill=\"").V(GetIdx(RGB_53, 1D)).S("\" opacity=\"0.18\">").V(Call(an_26, V.Undef, ((V)("fill")), Call(cyc_45, V.Undef, RGB_53, ((V)(0D))), ((V)(4D)))).S("</ellipse>").End()));
L_477 = (108D * ToNum(k_469));
return NewObj(4).Put("defs", Call(BLUR_28, V.Undef, ((V)("lzb")), ((V)(1.3)))).Put("under", un_476).Put("front", ((V)(f_474.Str))).Put("bb", Call(bbOf_29, V.Undef, Arr(Arr(((V)((ToNum(GetIdx(o_470, 0D)) - L_477))), ((V)((ToNum(GetIdx(o_470, 1D)) - L_477)))), Arr(Add(GetIdx(o_470, 0D), ((V)(L_477))), Add(GetIdx(o_470, 1D), ((V)((30D * ToNum(k_469)))))), Arr(((V)((ToNum(GetIdx(sc_471, 0D)) - (R_472 * 2.7)))), ((V)((ToNum(GetIdx(sc_471, 1D)) - (R_472 * 1.3))))), Arr(Add(GetIdx(sc_471, 0D), ((V)((R_472 * 2.7)))), Add(GetIdx(sc_471, 1D), ((V)((R_472 * 1.3)))))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_451;
return default;
}, 1, "", true));
jag_55 = Fn((V _arrowThis490, int _argc478, V a_484, V b_485, V bend_486, V R_487, V[] _rest479) => {
double dx_491 = 0;
double dy_492 = 0;
V L_493 = default;
double nx_494 = 0;
double ny_495 = 0;
double cx_496 = 0;
double cy_497 = 0;
JsStrBuf d_498 = null;
V n_488 = default;
V amp_489 = default;
n_488 = (_argc478 > 4 ? _rest479[0] : V.Undef);
amp_489 = (_argc478 > 5 ? _rest479[1] : V.Undef);
dx_491 = (ToNum(GetIdx(b_485, 0D)) - ToNum(GetIdx(a_484, 0D)));
dy_492 = (ToNum(GetIdx(b_485, 1D)) - ToNum(GetIdx(a_484, 1D)));
L_493 = (((V)(Hypot(dx_491, dy_492))) is var _t499 && Truthy(_t499) ? _t499 : ((V)(1D)));
nx_494 = ((-dy_492) / ToNum(L_493));
ny_495 = (dx_491 / ToNum(L_493));
cx_496 = ((ToNum(Add(GetIdx(a_484, 0D), GetIdx(b_485, 0D))) / 2D) + (nx_494 * ToNum(bend_486)));
cy_497 = ((ToNum(Add(GetIdx(a_484, 1D), GetIdx(b_485, 1D))) / 2D) + (ny_495 * ToNum(bend_486)));
d_498 = new JsStrBuf(JsStrBuf.Begin().S("M").V(Call(P2_23, V.Undef, a_484)).End());
{
double i_500 = 0;
i_500 = 1D;
while (true) {
if (!(Lt(((V)(i_500)), n_488))) break;
double t_502 = 0;
double x_503 = 0;
double y_504 = 0;
double j_505 = 0;
t_502 = (i_500 / ToNum(n_488));
x_503 = (((((1D - t_502) * (1D - t_502)) * ToNum(GetIdx(a_484, 0D))) + (((2D * (1D - t_502)) * t_502) * cx_496)) + ((t_502 * t_502) * ToNum(GetIdx(b_485, 0D))));
y_504 = (((((1D - t_502) * (1D - t_502)) * ToNum(GetIdx(a_484, 1D))) + (((2D * (1D - t_502)) * t_502) * cy_497)) + ((t_502 * t_502) * ToNum(GetIdx(b_485, 1D))));
j_505 = (((ToNum(Call(R_487, V.Undef)) - 0.5) * 2D) * ToNum(amp_489));
d_498.S("L").V(Call(f1_19, V.Undef, ((V)((x_503 + (nx_494 * j_505)))))).S(" ").V(Call(f1_19, V.Undef, ((V)((y_504 + (ny_495 * j_505))))));
i_500++;
}
}
return ((V)(JsStrBuf.Begin().S(d_498.Str).S("L").V(Call(P2_23, V.Undef, b_485)).End()));
return default;
}, 6, "", true);
bolt_56 = Fn((V _arrowThis518, int _argc506, V a_512, V b_513, V bend_514, V seed_515, V[] _rest507) => {
V R_519 = default;
V V_520 = default;
V vs_521 = default;
V dd_522 = default;
V k_516 = default;
V o_517 = default;
k_516 = (_argc506 > 4 ? _rest507[0] : V.Undef);
o_517 = (_argc506 > 5 ? _rest507[1] : V.Undef);
R_519 = Call(rng_21, V.Undef, seed_515);
V_520 = Call(rep_20, V.Undef, ((V)(4D)), Fn((V _arrowThis529, int _argc523, V _a525, V _a526, V _a527, V _a528, V[] _rest524) => {
return Call(jag_55, V.Undef, a_512, b_513, ((V)((ToNum(bend_514) * (0.75 + (ToNum(Call(R_519, V.Undef)) * 0.5))))), R_519, (Get(o_517, "n") is var _t530 && Truthy(_t530) ? _t530 : ((V)(9D))), ((V)((ToNum((Get(o_517, "amp") is var _t531 && Truthy(_t531) ? _t531 : ((V)(3.5)))) * ToNum(k_516)))));
}, 0, "", true));
vs_521 = Invoke(V_520, "join", ((V)(";")));
dd_522 = (Get(o_517, "dd") is var _t532 && Truthy(_t532) ? _t532 : ((V)(0.28)));
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(anD_42, V.Undef, ((V)("opacity")), (Get(o_517, "strike") is var _t533 && Truthy(_t533) ? _t533 : ((V)("1;0;1;1;0;1;0;0"))), (Get(o_517, "sd") is var _t534 && Truthy(_t534) ? _t534 : ((V)(1.3))), Get(o_517, "b"))).S("<path d=\"").V(GetIdx(V_520, 0D)).S("\" fill=\"none\" stroke=\"#b48cff\" stroke-width=\"").V(Call(f1_19, V.Undef, ((V)(((ToNum((Get(o_517, "w") is var _t535 && Truthy(_t535) ? _t535 : ((V)(1D)))) * 2.6) * ToNum(k_516)))))).S("\" opacity=\"0.6\" filter=\"url(#hdb)\">").V(Call(anD_42, V.Undef, ((V)("d")), vs_521, dd_522, Get(o_517, "b"))).S("</path>").S("<path d=\"").V(GetIdx(V_520, 0D)).S("\" fill=\"none\" stroke=\"#f6f0ff\" stroke-width=\"").V(Call(f1_19, V.Undef, ((V)(((ToNum((Get(o_517, "w") is var _t536 && Truthy(_t536) ? _t536 : ((V)(1D)))) * 0.6) * ToNum(k_516)))))).S("\" stroke-linejoin=\"round\">").V(Call(anD_42, V.Undef, ((V)("d")), vs_521, dd_522, Get(o_517, "b"))).S("</path></g>").End()));
return default;
}, 6, "", true);
Set(N_33, "holoDancer", Fn((V _arrowThis544, int _argc537, V S_543, V _a540, V _a541, V _a542, V[] _rest538) => {
V CY_545 = default;
V LT_546 = default;
double TX_547 = 0;
double TZ_548 = 0;
double TY_549 = 0;
V D_550 = default;
CY_545 = ((V)("#7ff0ff"));
LT_546 = ((V)("#e8fdff"));
TX_547 = 44D;
TZ_548 = (-4D);
TY_549 = 57.5;
D_550 = NewObj(2).Put("w", ((V)(120D))).Put("d", ((V)(50D))).V;
Set(D_550, "build", Fn((V _arrowThis558, int _argc551, V P_557, V _a554, V _a555, V _a556, V[] _rest552) => {
V o_559 = default;
o_559 = Arr(Call(cyl_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(26D)), ((V)(4D)), ((V)("#1c1d22")), Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(arcW_16, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(26D)), ((V)(26D)), ((V)(1.2)), ((V)(0.8)), ((V)(0D)), ((V)((2D * PI_36))), CY_545, Call(em_34, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(18D)), ((V)(4D)), ((V)("#2b2e36")), Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(22D))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D)), ((V)(12D)), ((V)(2D)), ((V)("#14151a")), Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(cyl_12, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(7D)), ((V)(1.6)), ((V)("#bfefff")), Call(cer_31, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("op", ((V)(0.7))).V)), Call(ball_13, V.Undef, ((V)(0D)), ((V)(11D)), ((V)(0D)), ((V)(3D)), CY_545, Call(em_34, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("sy", ((V)(0.5))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis567, int _argc560, V s_566, V _a563, V _a564, V _a565, V[] _rest561) => {
double x_568 = 0;
x_568 = (ToNum(s_566) * TX_547);
Invoke(o_559, "push", Call(box_11, V.Undef, ((V)(x_568)), ((V)(0D)), ((V)(TZ_548)), ((V)(16D)), ((V)(6D)), ((V)(16D)), ((V)("#2b2e36")), Call(mt_30, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(cyl_12, V.Undef, ((V)(x_568)), ((V)(6D)), ((V)(TZ_548)), ((V)(4.2)), ((V)(38D)), ((V)("#c87a46")), Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)));
Call(rep_20, V.Undef, ((V)(7D)), Fn((V _arrowThis576, int _argc569, V i_575, V _a572, V _a573, V _a574, V[] _rest570) => {
return Invoke(o_559, "push", Call(cyl_12, V.Undef, ((V)(x_568)), ((V)((9D + (ToNum(i_575) * 5D)))), ((V)(TZ_548)), ((V)(4.5)), ((V)(1D)), ((V)("#8a4f2c")), Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)));
}, 1, "", true));
Invoke(o_559, "push", Call(cyl_12, V.Undef, ((V)(x_568)), ((V)(44D)), ((V)(TZ_548)), ((V)(2D)), ((V)(3.4)), CH_37, Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(ball_13, V.Undef, ((V)(x_568)), ((V)(46.6)), ((V)(TZ_548)), ((V)(10D)), CH_37, Call(mt_30, V.Undef, NewObj(3).Put("sy", ((V)(0.36))).Put("n", ((V)(20D))).Put("shine", ((V)(1D))).V)), Call(cyl_12, V.Undef, ((V)(x_568)), ((V)(53D)), ((V)(TZ_548)), ((V)(0.7)), ((V)(3.4)), CH_37, Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(ball_13, V.Undef, ((V)(x_568)), ((V)(56D)), ((V)(TZ_548)), ((V)(1.5)), ((V)("#e9dcff")), Call(em_34, V.Undef, NewObj(1).Put("k", ((V)(4D))).V)));
return default;
}, 1, "", true));
return o_559;
return default;
}, 1, "", true));
Set(D_550, "fx", Fn((V _arrowThis584, int _argc577, V c_583, V _a580, V _a581, V _a582, V[] _rest578) => {
V p_585 = default;
V k_586 = default;
V ft_587 = default;
V ln_588 = default;
V top_589 = default;
V tL_590 = default;
V tR_591 = default;
V limb_592 = default;
V fig_593 = default;
JsStrBuf f_594 = null;
V brs_595 = default;
V un_596 = default;
V defs_597 = default;
p_585 = Get(c_583, "p");
k_586 = Get(c_583, "k");
ft_587 = Call(p_585, V.Undef, ((V)(0D)), ((V)(15D)), ((V)(0D)));
ln_588 = Call(p_585, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)));
top_589 = Call(p_585, V.Undef, ((V)(0D)), ((V)(84D)), ((V)(0D)));
tL_590 = Call(p_585, V.Undef, ((V)((-TX_547))), ((V)(TY_549)), ((V)(TZ_548)));
tR_591 = Call(p_585, V.Undef, ((V)(TX_547)), ((V)(TY_549)), ((V)(TZ_548)));
limb_592 = Fn((V _arrowThis607, int _argc598, V d_604, V pv_605, V vals_606, V _a603, V[] _rest599) => {
return ((V)(JsStrBuf.Begin().S("<g>").V(Call(atS_27, V.Undef, ((V)("rotate")), Invoke(Invoke(Invoke(vals_606, "split", ((V)(";"))), "map", Fn((V _arrowThis615, int _argc608, V v_614, V _a611, V _a612, V _a613, V[] _rest609) => {
return ((V)(JsStrBuf.Begin().V(v_614).S(" ").V(pv_605).End()));
}, 1, "", true)), "join", ((V)(";"))), ((V)(1.2)))).S("<path d=\"").V(d_604).S("\" fill=\"none\" stroke=\"").V(CY_545).S("\" stroke-width=\"3.2\" stroke-linecap=\"round\" stroke-linejoin=\"round\" opacity=\"0.75\"/><path d=\"").V(d_604).S("\" fill=\"none\" stroke=\"").V(LT_546).S("\" stroke-width=\"0.9\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/></g>").End()));
}, 3, "", true);
fig_593 = ((V)(JsStrBuf.Begin().S("<g id=\"hdF\">").V(Call(atS_27, V.Undef, ((V)("rotate")), ((V)("-5 0 0;5 0 0;-5 0 0")), ((V)(2.4)))).S("<g>").V(Call(atS_27, V.Undef, ((V)("translate")), ((V)("0 0;0 -2.6;0 0;0 -2.6;0 0")), ((V)(1.2)))).V(Call(limb_592, V.Undef, ((V)("M-2 -26L-5 -13L-6 0")), ((V)("-2 -26")), ((V)("0;-14;0;6;0")))).V(Call(limb_592, V.Undef, ((V)("M2 -26L5 -13L6 0")), ((V)("2 -26")), ((V)("0;-6;0;14;0")))).V(Call(limb_592, V.Undef, ((V)("M5 -40L10 -32L12 -24")), ((V)("5 -40")), ((V)("-20;-70;-25;-135;-20")))).S("<ellipse cx=\"0\" cy=\"-33\" rx=\"6.4\" ry=\"9\" fill=\"").V(CY_545).S("\" fill-opacity=\"0.42\" stroke=\"").V(LT_546).S("\" stroke-width=\"0.9\"/><ellipse cx=\"0\" cy=\"-33\" rx=\"6.4\" ry=\"9\" fill=\"url(#hdS)\"/>").V(Call(limb_592, V.Undef, ((V)("M-5 -40L-10 -32L-12 -24")), ((V)("-5 -40")), ((V)("20;110;160;110;20")))).S("<g>").V(Call(atS_27, V.Undef, ((V)("rotate")), ((V)("-9 0 -44;9 0 -44;-9 0 -44")), ((V)(1.2)))).S("<circle cx=\"-5.2\" cy=\"-56\" r=\"2.7\" fill=\"").V(CY_545).S("\" fill-opacity=\"0.5\" stroke=\"").V(LT_546).S("\" stroke-width=\"0.8\"/><circle cx=\"5.2\" cy=\"-56\" r=\"2.7\" fill=\"").V(CY_545).S("\" fill-opacity=\"0.5\" stroke=\"").V(LT_546).S("\" stroke-width=\"0.8\"/>").S("<circle cx=\"0\" cy=\"-50\" r=\"6.8\" fill=\"").V(CY_545).S("\" fill-opacity=\"0.45\" stroke=\"").V(LT_546).S("\" stroke-width=\"0.9\"/><circle cx=\"0\" cy=\"-50\" r=\"6.8\" fill=\"url(#hdS)\"/><path d=\"M-3.4 -50.6q1-1.2 2 0M1.4 -50.6q1-1.2 2 0M-1.6 -47.4q1.6 1.4 3.2 0\" fill=\"none\" stroke=\"").V(LT_546).S("\" stroke-width=\"0.8\" stroke-linecap=\"round\"/></g>").S("</g></g>").End()));
f_594 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"M").V(Call(f1_19, V.Undef, ((V)((ToNum(GetIdx(ln_588, 0D)) - (4D * ToNum(k_586))))))).S(" ").V(Call(f1_19, V.Undef, GetIdx(ln_588, 1D))).S("L").V(Call(f1_19, V.Undef, ((V)((ToNum(GetIdx(top_589, 0D)) - (26D * ToNum(k_586))))))).S(" ").V(Call(f1_19, V.Undef, GetIdx(top_589, 1D))).S("L").V(Call(f1_19, V.Undef, Add(GetIdx(top_589, 0D), ((V)((26D * ToNum(k_586))))))).S(" ").V(Call(f1_19, V.Undef, GetIdx(top_589, 1D))).S("L").V(Call(f1_19, V.Undef, Add(GetIdx(ln_588, 0D), ((V)((4D * ToNum(k_586))))))).S(" ").V(Call(f1_19, V.Undef, GetIdx(ln_588, 1D))).S("Z\" fill=\"url(#hdC)\">").V(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.7;1;0.75;0.95;0.7")), ((V)(2.2)))).S("</path>").End());
f_594.S("<g>").V(Call(anD_42, V.Undef, ((V)("opacity")), ((V)("0.95;0.95;0.95;0.45;0.95;0.95;0.95;0.95;0.2;0.9")), ((V)(3.1)))).S("<g>").S("<animateTransform attributeName=\"transform\" type=\"translate\" values=\"0 0;0 0;").V(Call(f1_19, V.Undef, ((V)((1.4 * ToNum(k_586)))))).S(" 0;0 0;0 0;").V(Call(f1_19, V.Undef, ((V)(((-1D) * ToNum(k_586)))))).S(" 0;0 0\" dur=\"2.7s\" calcMode=\"discrete\" repeatCount=\"indefinite\"/>").S("<g transform=\"translate(").V(Call(P2_23, V.Undef, ft_587)).S(") scale(").V(Call(n4_22, V.Undef, k_586)).S(")\"><use href=\"#hdF\" filter=\"url(#hdg)\" opacity=\"0.7\"/>").V(fig_593).S("</g></g></g>");
Call(rep_20, V.Undef, ((V)(8D)), Fn((V _arrowThis623, int _argc616, V i_622, V _a619, V _a620, V _a621, V[] _rest617) => {
double x_624 = 0;
V e0_625 = default;
V d_626 = default;
x_624 = (((ToNum(i_622) % 4D) - 1.5) * 10D);
e0_625 = Call(p_585, V.Undef, ((V)(x_624)), ((V)(14D)), ((V)((NumTruthy((ToNum(i_622) % 2D)) ? 5D : (-5D)))));
d_626 = Invoke(((V)((2.2 + ((ToNum(i_622) % 3D) * 0.5)))), "toFixed", ((V)(1D)));
f_594.S("<circle cx=\"").V(Call(f1_19, V.Undef, GetIdx(e0_625, 0D))).S("\" cy=\"").V(Call(f1_19, V.Undef, GetIdx(e0_625, 1D))).S("\" r=\"").V(Call(f1_19, V.Undef, ((V)((0.7 * ToNum(k_586)))))).S("\" fill=\"#e8fdff\">").V(Call(an_26, V.Undef, ((V)("cy")), ((V)(JsStrBuf.Begin().V(Call(f1_19, V.Undef, GetIdx(e0_625, 1D))).S(";").V(Call(f1_19, V.Undef, ((V)((ToNum(GetIdx(e0_625, 1D)) - (66D * ToNum(k_586))))))).End())), d_626, ((V)(((-ToNum(i_622)) * 0.41))))).V(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0;1;0")), d_626, ((V)(((-ToNum(i_622)) * 0.41))))).S("</circle>");
return default;
}, 1, "", true));
Invoke(Arr(tL_590, tR_591), "forEach", Fn((V _arrowThis635, int _argc627, V t_633, V i_634, V _a631, V _a632, V[] _rest628) => {
f_594.S("<circle cx=\"").V(Call(f1_19, V.Undef, GetIdx(t_633, 0D))).S("\" cy=\"").V(Call(f1_19, V.Undef, GetIdx(t_633, 1D))).S("\" r=\"").V(Call(f1_19, V.Undef, ((V)((6D * ToNum(k_586)))))).S("\" fill=\"#b48cff\" opacity=\"0.45\" filter=\"url(#hdb)\">").V(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.25;0.6;0.3;0.55;0.25")), ((V)(0.9)), ((V)(((-ToNum(i_634)) * 0.3))))).V(Call(an_26, V.Undef, ((V)("r")), ((V)(JsStrBuf.Begin().V(Call(f1_19, V.Undef, ((V)((5D * ToNum(k_586)))))).S(";").V(Call(f1_19, V.Undef, ((V)((8D * ToNum(k_586)))))).S(";").V(Call(f1_19, V.Undef, ((V)((5D * ToNum(k_586)))))).End())), ((V)(1.3)), ((V)(((-ToNum(i_634)) * 0.4))))).S("</circle>");
return default;
}, 2, "", true));
f_594.V(Call(bolt_56, V.Undef, tL_590, tR_591, ((V)(((-34D) * ToNum(k_586)))), ((V)("hdx")), k_586, NewObj(5).Put("n", ((V)(14D))).Put("amp", ((V)(4D))).Put("strike", ((V)("1;0;1;1;0;0;0;1;0;0"))).Put("sd", ((V)(1.6))).Put("w", ((V)(1.2))).V));
brs_595 = Arr(Arr(((V)((-1D))), ((V)((-26D))), ((V)((-14D)))), Arr(((V)((-1D))), ((V)((-14D))), ((V)((-26D)))), Arr(((V)((-1D))), ((V)((-30D))), ((V)(4D))), Arr(((V)(1D)), ((V)(26D)), ((V)((-14D)))), Arr(((V)(1D)), ((V)(14D)), ((V)((-26D)))), Arr(((V)(1D)), ((V)(30D)), ((V)(4D))));
Invoke(brs_595, "forEach", Fn((V _arrowThis650, int _argc636, V _a638, V i_642, V _a640, V _a641, V[] _rest637) => {
V t_651 = default;
V s_645 = default;
V dx_647 = default;
V dy_649 = default;
{ V _t643 = ListOf(_a638);
{ V _t644 = GetIdx(_t643, 0D);
s_645 = _t644; }
{ V _t646 = GetIdx(_t643, 1D);
dx_647 = _t646; }
{ V _t648 = GetIdx(_t643, 2D);
dy_649 = _t648; }
}
t_651 = (LtN(s_645, 0D) ? tL_590 : tR_591);
f_594.V(Call(bolt_56, V.Undef, t_651, Arr(Add(GetIdx(t_651, 0D), ((V)((ToNum(dx_647) * ToNum(k_586))))), Add(GetIdx(t_651, 1D), ((V)((ToNum(dy_649) * ToNum(k_586)))))), ((V)(((NumTruthy((ToNum(i_642) % 2D)) ? 5D : (-5D)) * ToNum(k_586)))), ((V)(JsStrBuf.Begin().S("hdb").V(i_642).End())), k_586, NewObj(6).Put("n", ((V)(6D))).Put("amp", ((V)(3D))).Put("strike", GetIdx(Arr(((V)("0;1;0;1;1;0;0")), ((V)("1;0;0;1;0;1;0")), ((V)("0;0;1;0;1;1;0"))), (ToNum(i_642) % 3D))).Put("sd", ((V)((1D + ((ToNum(i_642) % 3D) * 0.25))))).Put("b", ((V)(((-ToNum(i_642)) * 0.17)))).Put("w", ((V)(0.8))).V));
return default;
}, 2, "", true));
un_596 = ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(planeH_25, V.Undef, p_585, ((V)(4.4)))).S("\">").V(Invoke(Call(rep_20, V.Undef, ((V)(3D)), Fn((V _arrowThis659, int _argc652, V j_658, V _a655, V _a656, V _a657, V[] _rest653) => {
return ((V)(JsStrBuf.Begin().S("<ellipse rx=\"10\" ry=\"10\" fill=\"none\" stroke=\"#7ff0ff\" stroke-width=\"0.9\">").V(Call(an_26, V.Undef, ((V)("rx")), ((V)("10;34")), ((V)(2.4)), ((V)(((-ToNum(j_658)) * 0.8))))).V(Call(an_26, V.Undef, ((V)("ry")), ((V)("10;34")), ((V)(2.4)), ((V)(((-ToNum(j_658)) * 0.8))))).V(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.8;0")), ((V)(2.4)), ((V)(((-ToNum(j_658)) * 0.8))))).S("</ellipse>").End()));
}, 1, "", true)), "join", ((V)("")))).S("</g>").End()));
defs_597 = ((V)(JsStrBuf.Begin().V(Add(Call(BLUR_28, V.Undef, ((V)("hdb")), ((V)(1.3))), Call(BLUR_28, V.Undef, ((V)("hdg")), ((V)(2.2))))).S("<linearGradient id=\"hdC\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"#8fe8ff\" stop-opacity=\"0.45\"/><stop offset=\"1\" stop-color=\"#8fe8ff\" stop-opacity=\"0.02\"/></linearGradient>").S("<pattern id=\"hdS\" width=\"4\" height=\"2.4\" patternUnits=\"userSpaceOnUse\"><rect width=\"4\" height=\"0.7\" fill=\"#ffffff\" opacity=\"0.35\"/><animateTransform attributeName=\"patternTransform\" type=\"translate\" values=\"0 0;0 -2.4\" dur=\"0.6s\" repeatCount=\"indefinite\"/></pattern>").End()));
return NewObj(4).Put("defs", defs_597).Put("under", un_596).Put("front", ((V)(f_594.Str))).Put("bb", Call(bbOf_29, V.Undef, Arr(Arr(((V)((ToNum(GetIdx(tL_590, 0D)) - (34D * ToNum(k_586))))), ((V)((ToNum(GetIdx(tL_590, 1D)) - (30D * ToNum(k_586)))))), Arr(Add(GetIdx(tR_591, 0D), ((V)((34D * ToNum(k_586))))), ((V)((ToNum(GetIdx(tR_591, 1D)) - (30D * ToNum(k_586)))))), Arr(((V)((ToNum(Add(GetIdx(tL_590, 0D), GetIdx(tR_591, 0D))) / 2D))), ((V)((Min(ToNum(GetIdx(tL_590, 1D)), ToNum(GetIdx(tR_591, 1D))) - (40D * ToNum(k_586)))))), Arr(((V)((ToNum(GetIdx(top_589, 0D)) - (28D * ToNum(k_586))))), GetIdx(top_589, 1D)), Call(p_585, V.Undef, ((V)(0D)), ((V)(80D)), ((V)(0D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_550;
return default;
}, 1, "", true));
Set(N_33, "ledCove", Fn((V _arrowThis667, int _argc660, V S_666, V _a663, V _a664, V _a665, V[] _rest661) => {
V pal_668 = default;
V mode_669 = default;
V vals_670 = default;
double W_671 = 0;
double Y_672 = 0;
V off_673 = default;
V flick_674 = default;
pal_668 = (Get(S_666, "pal") is var _t675 && Truthy(_t675) ? _t675 : NE_35);
mode_669 = (Truthy(Invoke(MODES_40, "includes", Get(S_666, "st"))) ? Get(S_666, "st") : ((V)("Wave")));
vals_670 = Invoke(Invoke(pal_668, "concat", GetIdx(pal_668, 0D)), "join", ((V)(";")));
W_671 = 150D;
Y_672 = 58D;
off_673 = Fn((V _arrowThis683, int _argc676, V i_682, V _a679, V _a680, V _a681, V[] _rest677) => {
return ((V)((SEqS(mode_669, "Wave") ? ((-ToNum(i_682)) * 0.22) : (SEqS(mode_669, "Rainbow") ? (((-ToNum(i_682)) * 3D) / 12D) : (SEqS(mode_669, "Chase") ? ((-ToNum(i_682)) * 0.1) : 0D)))));
}, 1, "", true);
flick_674 = Fn((V _arrowThis691, int _argc684, V i_690, V _a687, V _a688, V _a689, V[] _rest685) => {
return (SEqS(mode_669, "Pulse") ? Call(an_26, V.Undef, ((V)("opacity")), ((V)("1;0.25;1")), ((V)(1.6))) : (SEqS(mode_669, "Chase") ? Call(an_26, V.Undef, ((V)("opacity")), ((V)("1;0.15;1")), ((V)(1.2)), Call(off_673, V.Undef, i_690)) : ((V)(""))));
}, 1, "", true);
return NewObj(5).Put("w", ((V)(176D))).Put("d", ((V)(14D))).Put("mount", ((V)("wall"))).Put("build", Fn((V _arrowThis699, int _argc692, V P_698, V _a695, V _a696, V _a697, V[] _rest693) => {
return Arr(Call(slabX_15, V.Undef, ((V)(0D)), ((V)(Y_672)), ((V)(1D)), ((V)(W_671)), ((V)(12D)), ((V)(2D)), ((V)("#e4ded2")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slabX_15, V.Undef, ((V)(0D)), ((V)(Y_672)), ((V)(5D)), ((V)(W_671)), ((V)(2D)), ((V)(8D)), ((V)("#f1ece2")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slabX_15, V.Undef, ((V)(0D)), ((V)((Y_672 + 2D))), ((V)(8.6)), ((V)(W_671)), ((V)(7D)), ((V)(1.6)), ((V)("#fbf8f2")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_11, V.Undef, ((V)((((-W_671) / 2D) - 1D))), ((V)(Y_672)), ((V)(4.6)), ((V)(2.4)), ((V)(9D)), ((V)(8D)), ((V)("#e4ded2")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_11, V.Undef, ((V)(((W_671 / 2D) + 1D))), ((V)(Y_672)), ((V)(4.6)), ((V)(2.4)), ((V)(9D)), ((V)(8D)), ((V)("#e4ded2")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_11, V.Undef, ((V)(((W_671 / 2D) + 11D))), ((V)((Y_672 - 2D))), ((V)(4D)), ((V)(13D)), ((V)(14D)), ((V)(7D)), ((V)("#2c2d31")), Call(mt_30, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(slabX_15, V.Undef, ((V)(((W_671 / 2D) + 4D))), ((V)((Y_672 + 4D))), ((V)(3D)), ((V)(6D)), ((V)(1D)), ((V)(1D)), ((V)("#2c2d31")), NewObj(1).Put("noOut", ((V)(1D))).V));
}, 1, "build", true)).Put("fx", Fn((V _arrowThis707, int _argc700, V c_706, V _a703, V _a704, V _a705, V[] _rest701) => {
V p_708 = default;
V k_709 = default;
double NS_710 = 0;
double sw_711 = 0;
V defs_712 = default;
JsStrBuf wash_713 = null;
JsStrBuf fr_714 = null;
V un_715 = default;
double n_716 = 0;
JsStrBuf gl_717 = null;
JsStrBuf dt_718 = null;
V a_719 = default;
V b_720 = default;
JsStrBuf wh_721 = null;
p_708 = Get(c_706, "p");
k_709 = Get(c_706, "k");
NS_710 = 12D;
sw_711 = (W_671 / NS_710);
defs_712 = Add(Call(BLUR_28, V.Undef, ((V)("lcb")), ((V)(3D))), Call(BLUR_28, V.Undef, ((V)("lcg")), ((V)(0.9))));
wash_713 = new JsStrBuf("");
fr_714 = new JsStrBuf("");
Call(rep_20, V.Undef, ((V)(NS_710)), Fn((V _arrowThis729, int _argc722, V i_728, V _a725, V _a726, V _a727, V[] _rest723) => {
V gid_730 = default;
V sc_731 = default;
gid_730 = ((V)(JsStrBuf.Begin().S("lcw").V(i_728).End()));
sc_731 = Call(an_26, V.Undef, ((V)("stop-color")), vals_670, ((V)(3D)), Call(off_673, V.Undef, i_728));
defs_712 = ((V)(JsStrBuf.Begin().V(defs_712).S("<linearGradient id=\"").V(gid_730).S("\" x1=\"0\" y1=\"1\" x2=\"0\" y2=\"0\"><stop offset=\"0\" stop-color=\"").V(GetIdx(pal_668, 0D)).S("\" stop-opacity=\"0.9\">").V(sc_731).S("</stop><stop offset=\"0.4\" stop-color=\"").V(GetIdx(pal_668, 0D)).S("\" stop-opacity=\"0.38\">").V(sc_731).S("</stop><stop offset=\"1\" stop-color=\"").V(GetIdx(pal_668, 0D)).S("\" stop-opacity=\"0\"/></linearGradient>").End()));
wash_713.S("<rect x=\"").V(Call(f1_19, V.Undef, ((V)(((((-W_671) / 2D) + (ToNum(i_728) * sw_711)) - 1.5))))).S("\" y=\"0\" width=\"").V(Call(f1_19, V.Undef, ((V)((sw_711 + 3D))))).S("\" height=\"52\" fill=\"url(#").V(gid_730).S(")\">").V(Call(flick_674, V.Undef, i_728)).S("</rect>");
return default;
}, 1, "", true));
defs_712 = ((V)(JsStrBuf.Begin().V(defs_712).S("<linearGradient id=\"lcd\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"").V(GetIdx(pal_668, 0D)).S("\" stop-opacity=\"0.55\">").V(Call(an_26, V.Undef, ((V)("stop-color")), vals_670, ((V)(3D)))).S("</stop><stop offset=\"1\" stop-color=\"").V(GetIdx(pal_668, 0D)).S("\" stop-opacity=\"0\"/></linearGradient>").End()));
un_715 = ((V)(JsStrBuf.Begin().S("<g transform=\"").V(Call(plane_24, V.Undef, p_708, ((V)((-0.3))), ((V)(((Y_672 + 12D) + 52D))))).S("\" filter=\"url(#lcb)\">").S(wash_713.Str).S("</g><g transform=\"").V(Call(plane_24, V.Undef, p_708, ((V)((-0.3))), ((V)(Y_672)))).S("\"><rect x=\"").V(Call(f1_19, V.Undef, ((V)(((-W_671) / 2D))))).S("\" y=\"0\" width=\"").N(W_671).S("\" height=\"12\" fill=\"url(#lcd)\" opacity=\"0.6\"/></g>").End()));
n_716 = 32D;
gl_717 = new JsStrBuf("");
dt_718 = new JsStrBuf("");
Call(rep_20, V.Undef, ((V)(n_716)), Fn((V _arrowThis739, int _argc732, V i_738, V _a735, V _a736, V _a737, V[] _rest733) => {
double x_740 = 0;
V q_741 = default;
double j_742 = 0;
V fa_743 = default;
x_740 = ((((-W_671) / 2D) + 2.5) + ((ToNum(i_738) * (W_671 - 5D)) / (n_716 - 1D)));
q_741 = Call(p_708, V.Undef, ((V)(x_740)), ((V)((Y_672 + 9.6))), ((V)(5.4)));
j_742 = ((ToNum(i_738) * NS_710) / n_716);
fa_743 = Add(Call(an_26, V.Undef, ((V)("fill")), vals_670, ((V)(3D)), Call(off_673, V.Undef, ((V)(j_742)))), Call(flick_674, V.Undef, ((V)(j_742))));
gl_717.S("<circle cx=\"").V(Call(f1_19, V.Undef, GetIdx(q_741, 0D))).S("\" cy=\"").V(Call(f1_19, V.Undef, GetIdx(q_741, 1D))).S("\" r=\"").V(Call(f1_19, V.Undef, ((V)((2.4 * ToNum(k_709)))))).S("\" fill=\"").V(GetIdx(pal_668, (ToNum(i_738) % ToNum(Get(pal_668, "length"))))).S("\">").V(fa_743).S("</circle>");
dt_718.S("<circle cx=\"").V(Call(f1_19, V.Undef, GetIdx(q_741, 0D))).S("\" cy=\"").V(Call(f1_19, V.Undef, GetIdx(q_741, 1D))).S("\" r=\"").V(Call(f1_19, V.Undef, ((V)((0.95 * ToNum(k_709)))))).S("\" fill=\"").V(GetIdx(pal_668, (ToNum(i_738) % ToNum(Get(pal_668, "length"))))).S("\">").V(fa_743).S("</circle><circle cx=\"").V(Call(f1_19, V.Undef, GetIdx(q_741, 0D))).S("\" cy=\"").V(Call(f1_19, V.Undef, GetIdx(q_741, 1D))).S("\" r=\"").V(Call(f1_19, V.Undef, ((V)((0.4 * ToNum(k_709)))))).S("\" fill=\"#ffffff\" opacity=\"0.85\"/>");
return default;
}, 1, "", true));
a_719 = Call(p_708, V.Undef, ((V)(((-W_671) / 2D))), ((V)((Y_672 + 9.1))), ((V)(9.5)));
b_720 = Call(p_708, V.Undef, ((V)((W_671 / 2D))), ((V)((Y_672 + 9.1))), ((V)(9.5)));
fr_714.S("<path d=\"M").V(Call(P2_23, V.Undef, a_719)).S("L").V(Call(P2_23, V.Undef, b_720)).S("\" stroke=\"").V(GetIdx(pal_668, 0D)).S("\" stroke-width=\"").V(Call(f1_19, V.Undef, ((V)((0.8 * ToNum(k_709)))))).S("\" opacity=\"0.75\">").V(Call(an_26, V.Undef, ((V)("stroke")), vals_670, ((V)(3D)))).S("</path><g filter=\"url(#lcg)\" opacity=\"0.7\">").S(gl_717.Str).S("</g>").S(dt_718.Str);
wh_721 = new JsStrBuf("");
Call(rep_20, V.Undef, ((V)(6D)), Fn((V _arrowThis751, int _argc744, V i_750, V _a747, V _a748, V _a749, V[] _rest745) => {
double a0_752 = 0;
double a1_753 = 0;
double r_754 = 0;
a0_752 = ((((ToNum(i_750) / 6D) * 2D) * PI_36) - (PI_36 / 2D));
a1_753 = ((((ToNum(Add(i_750, ((V)(1D)))) / 6D) * 2D) * PI_36) - (PI_36 / 2D));
r_754 = 3.6;
wh_721.S("<path d=\"M0 0L").V(Call(f1_19, V.Undef, ((V)((FdLibm.Cos(a0_752) * r_754))))).S(" ").V(Call(f1_19, V.Undef, ((V)((FdLibm.Sin(a0_752) * r_754))))).S("A").N(r_754).S(" ").N(r_754).S(" 0 0 1 ").V(Call(f1_19, V.Undef, ((V)((FdLibm.Cos(a1_753) * r_754))))).S(" ").V(Call(f1_19, V.Undef, ((V)((FdLibm.Sin(a1_753) * r_754))))).S("Z\" fill=\"").V(GetK(NE_35, i_750)).S("\"/>");
return default;
}, 1, "", true));
fr_714.S("<g transform=\"").V(Call(plane_24, V.Undef, p_708, ((V)(7.6)), ((V)((Y_672 + 10.5))), ((V)(((W_671 / 2D) + 11D))))).S("\"><g transform=\"translate(0 4.8)\">").S(wh_721.Str).S("<circle r=\"1.5\" fill=\"#ffffff\"/><circle r=\"4.4\" fill=\"none\" stroke=\"").V(GetIdx(pal_668, 0D)).S("\" stroke-width=\"0.7\">").V(Call(an_26, V.Undef, ((V)("stroke")), vals_670, ((V)(3D)))).S("</circle></g><rect x=\"-3.6\" y=\"10\" width=\"7.2\" height=\"1.4\" rx=\"0.7\" fill=\"#4a4d5a\"/></g>");
return NewObj(4).Put("defs", defs_712).Put("under", un_715).Put("front", ((V)(fr_714.Str))).Put("bb", Call(bbOf_29, V.Undef, Arr(Call(p_708, V.Undef, ((V)((((-W_671) / 2D) - 4D))), ((V)((Y_672 + 66D))), ((V)(0D))), Call(p_708, V.Undef, ((V)(((W_671 / 2D) + 18D))), ((V)((Y_672 + 66D))), ((V)(0D))), Call(p_708, V.Undef, ((V)((((-W_671) / 2D) - 4D))), ((V)((Y_672 - 6D))), ((V)(10D))), Call(p_708, V.Undef, ((V)(((W_671 / 2D) + 18D))), ((V)((Y_672 - 6D))), ((V)(10D)))), ((V)(2D)))).V;
return default;
}, 1, "fx", true)).V;
return default;
}, 1, "", true));
Set(N_33, "ledShow", Fn((V _arrowThis762, int _argc755, V S_761, V _a758, V _a759, V _a760, V[] _rest756) => {
V pal_763 = default;
V mode_764 = default;
V vals_765 = default;
double TX_766 = 0;
double TH_767 = 0;
V HX_768 = default;
double RC_769 = 0;
V RR_770 = default;
V D_771 = default;
pal_763 = (Get(S_761, "pal") is var _t772 && Truthy(_t772) ? _t772 : NE_35);
mode_764 = (Truthy(Invoke(MODES_40, "includes", Get(S_761, "st"))) ? Get(S_761, "st") : ((V)("Wave")));
vals_765 = Invoke(Invoke(pal_763, "concat", GetIdx(pal_763, 0D)), "join", ((V)(";")));
TX_766 = 84D;
TH_767 = 160D;
HX_768 = Arr(((V)((-54D))), ((V)((-18D))), ((V)(18D)), ((V)(54D)));
RC_769 = 84D;
RR_770 = Arr(((V)(54D)), ((V)(40D)), ((V)(26D)));
D_771 = NewObj(2).Put("w", ((V)(190D))).Put("d", ((V)(44D))).V;
Set(D_771, "build", Fn((V _arrowThis780, int _argc773, V P_779, V _a776, V _a777, V _a778, V[] _rest774) => {
V o_781 = default;
o_781 = Arr();
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis789, int _argc782, V s_788, V _a785, V _a786, V _a787, V[] _rest783) => {
double x_790 = 0;
x_790 = (ToNum(s_788) * TX_766);
Invoke(o_781, "push", Call(box_11, V.Undef, ((V)(x_790)), ((V)(0D)), ((V)(0D)), ((V)(18D)), ((V)(5D)), ((V)(24D)), ((V)("#2c2d31")), Call(mt_30, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Invoke(Arr(((V)((-5D))), ((V)(5D))), "forEach", Fn((V _arrowThis798, int _argc791, V dx_797, V _a794, V _a795, V _a796, V[] _rest792) => {
return Invoke(Arr(((V)((-5D))), ((V)(5D))), "forEach", Fn((V _arrowThis806, int _argc799, V dz_805, V _a802, V _a803, V _a804, V[] _rest800) => {
return Invoke(o_781, "push", Call(cyl_12, V.Undef, Add(((V)(x_790)), dx_797), ((V)(5D)), dz_805, ((V)(1.1)), ((V)((TH_767 - 5D))), CH_37, Call(mt_30, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
}, 1, "", true));
}, 1, "", true));
Call(rep_20, V.Undef, ((V)(8D)), Fn((V _arrowThis814, int _argc807, V i_813, V _a810, V _a811, V _a812, V[] _rest808) => {
return Invoke(o_781, "push", Call(box_11, V.Undef, ((V)(x_790)), ((V)((14D + (ToNum(i_813) * 19D)))), ((V)(0D)), ((V)(11D)), ((V)(1.2)), ((V)(11D)), CH_37, Call(mt_30, V.Undef, NewObj(1).Put("r", ((V)(0D))).V)));
}, 1, "", true));
return default;
}, 1, "", true));
Invoke(o_781, "push", Call(slabX_15, V.Undef, ((V)(0D)), ((V)(TH_767)), ((V)(0D)), ((V)(((2D * TX_766) + 14D))), ((V)(8D)), ((V)(11D)), ((V)("#3a3c48")), Call(mt_30, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slab_14, V.Undef, ((V)(0D)), ((V)(14D)), ((V)((-11D))), ((V)(150D)), ((V)(134D)), ((V)(3D)), ((V)("#0e0f14")), Call(mt_30, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)));
Invoke(HX_768, "forEach", Fn((V _arrowThis822, int _argc815, V x_821, V _a818, V _a819, V _a820, V[] _rest816) => {
return Invoke(o_781, "push", Call(box_11, V.Undef, x_821, ((V)((TH_767 - 7D))), ((V)(5D)), ((V)(9D)), ((V)(7D)), ((V)(9D)), ((V)("#1e2028")), Call(mt_30, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(disc_17, V.Undef, x_821, ((V)((TH_767 - 3.5))), ((V)(9.5)), ((V)(2.1)), ((V)(0.6)), ((V)("#e8fdff")), Call(em_34, V.Undef)));
}, 1, "", true));
return o_781;
return default;
}, 1, "", true));
Set(D_771, "fx", Fn((V _arrowThis830, int _argc823, V c_829, V _a826, V _a827, V _a828, V[] _rest824) => {
V p_831 = default;
V k_832 = default;
JsStrBuf un_833 = null;
V f_834 = default;
double nx_835 = 0;
double ny_836 = 0;
double cw_837 = 0;
double chh_838 = 0;
JsStrBuf g_839 = null;
V z0_840 = default;
V zr_841 = default;
JsStrBuf rg_842 = null;
JsStrBuf rgG_843 = null;
double cm_844 = 0;
V ends_845 = default;
JsStrBuf tz_846 = null;
V fl_847 = default;
p_831 = Get(c_829, "p");
k_832 = Get(c_829, "k");
un_833 = new JsStrBuf("");
f_834 = ((V)(""));
nx_835 = 15D;
ny_836 = 13D;
cw_837 = 9.6;
chh_838 = 9.8;
g_839 = new JsStrBuf("");
{
double j_848 = 0;
j_848 = 0D;
while (true) {
if (!((j_848 < ny_836))) break;
{
double i_850 = 0;
i_850 = 0D;
while (true) {
if (!((i_850 < nx_835))) break;
double dc_852 = 0;
double b_853 = 0;
dc_852 = Hypot((i_850 - ((nx_835 - 1D) / 2D)), ((j_848 - ((ny_836 - 1D) / 2D)) * 1.05));
b_853 = (SEqS(mode_764, "Wave") ? ((-dc_852) * 0.3) : (SEqS(mode_764, "Rainbow") ? ((-(i_850 + j_848)) * 0.14) : (SEqS(mode_764, "Chase") ? ((-i_850) * 0.12) : 0D)));
g_839.S("<rect x=\"").V(Call(f1_19, V.Undef, ((V)((((((-nx_835) * cw_837) / 2D) + (i_850 * cw_837)) + 0.8))))).S("\" y=\"").V(Call(f1_19, V.Undef, ((V)(((j_848 * chh_838) + 0.8))))).S("\" width=\"").V(Call(f1_19, V.Undef, ((V)((cw_837 - 1.6))))).S("\" height=\"").V(Call(f1_19, V.Undef, ((V)((chh_838 - 1.6))))).S("\" rx=\"1.4\" fill=\"").V(GetIdx(pal_763, ((i_850 + j_848) % ToNum(Get(pal_763, "length"))))).S("\">").V(Call(an_26, V.Undef, ((V)("fill")), vals_765, ((V)(3D)), ((V)(b_853)))).V((SEqS(mode_764, "Pulse") ? Call(an_26, V.Undef, ((V)("opacity")), ((V)("1;0.2;1")), ((V)(1.2)), ((V)(((-((i_850 + j_848) % 2D)) * 0.6)))) : (SEqS(mode_764, "Chase") ? Call(an_26, V.Undef, ((V)("opacity")), ((V)("1;0.15;0.15;1")), ((V)(1.5)), ((V)(b_853))) : Call(an_26, V.Undef, ((V)("opacity")), ((V)("1;0.55;1")), ((V)(2.2)), ((V)(b_853)))))).S("</rect>");
i_850++;
}
}
j_848++;
}
}
f_834 = ((V)(JsStrBuf.Begin().V(f_834).S("<g transform=\"").V(Call(plane_24, V.Undef, p_831, ((V)((-9.4))), ((V)(((14D + 134D) - 4D))))).S("\" opacity=\"0.88\"><g filter=\"url(#lsg)\" opacity=\"0.55\">").S(g_839.Str).S("</g>").S(g_839.Str).S("</g>").End()));
z0_840 = Call(p_831, V.Undef, ((V)(0D)), ((V)(TH_767)), ((V)(6D)));
zr_841 = Call(p_831, V.Undef, ((V)(0D)), Add(((V)(RC_769)), GetIdx(RR_770, 0D)), ((V)(6D)));
f_834 = ((V)(JsStrBuf.Begin().V(f_834).S("<path d=\"M").V(Call(P2_23, V.Undef, z0_840)).S("L").V(Call(P2_23, V.Undef, zr_841)).S("\" stroke=\"#9aa3a8\" stroke-width=\"").V(Call(f1_19, V.Undef, ((V)((0.5 * ToNum(k_832)))))).S("\"/>").End()));
rg_842 = new JsStrBuf("");
rgG_843 = new JsStrBuf("");
Invoke(RR_770, "forEach", Fn((V _arrowThis862, int _argc854, V r_860, V i_861, V _a858, V _a859, V[] _rest855) => {
double L_863 = 0;
V ca_864 = default;
V da_865 = default;
V dan_866 = default;
V op_867 = default;
L_863 = ((2D * PI_36) * ToNum(r_860));
ca_864 = Call(an_26, V.Undef, ((V)("stroke")), vals_765, ((V)(3D)), ((V)((SEqS(mode_764, "Rainbow") ? (-ToNum(i_861)) : ((-ToNum(i_861)) * 0.3)))));
da_865 = ((V)((SEqS(mode_764, "Chase") ? JsStrBuf.Begin().S(" stroke-dasharray=\"").V(Call(f1_19, V.Undef, ((V)(((L_863 / 12D) * 0.62))))).S(" ").V(Call(f1_19, V.Undef, ((V)(((L_863 / 12D) * 0.38))))).S("\"").End() : "")));
dan_866 = (SEqS(mode_764, "Chase") ? Call(an_26, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;").S((NumTruthy((ToNum(i_861) % 2D)) ? "" : "-")).V(Call(f1_19, V.Undef, ((V)((L_863 / 6D))))).End())), ((V)(1.6))) : ((V)("")));
op_867 = (SEqS(mode_764, "Pulse") ? Call(an_26, V.Undef, ((V)("opacity")), ((V)("1;0.2;1")), ((V)(1.2)), ((V)(((-ToNum(i_861)) * 0.25)))) : (SEqS(mode_764, "Wave") ? Call(an_26, V.Undef, ((V)("opacity")), ((V)("1;0.45;1")), ((V)(1.8)), ((V)(((-ToNum(i_861)) * 0.4)))) : ((V)(""))));
rgG_843.S("<circle r=\"").V(r_860).S("\" fill=\"none\" stroke=\"").V(GetIdx(pal_763, (ToNum(i_861) % ToNum(Get(pal_763, "length"))))).S("\" stroke-width=\"5\"").V(da_865).S(">").V(ca_864).V(dan_866).V(op_867).S("</circle>");
rg_842.S("<circle r=\"").V(r_860).S("\" fill=\"none\" stroke=\"").V(GetIdx(pal_763, (ToNum(i_861) % ToNum(Get(pal_763, "length"))))).S("\" stroke-width=\"2\"").V(da_865).S(">").V(ca_864).V(dan_866).V(op_867).S("</circle><circle r=\"").V(r_860).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.8\"").V(da_865).S(">").V(dan_866).V(op_867).S("</circle>");
return default;
}, 2, "", true));
cm_844 = ((2D * PI_36) * ToNum(GetIdx(RR_770, 0D)));
rg_842.S("<circle r=\"").V(GetIdx(RR_770, 0D)).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"2.6\" stroke-linecap=\"round\" stroke-dasharray=\"").V(Call(f1_19, V.Undef, ((V)((cm_844 * 0.07))))).S(" ").V(Call(f1_19, V.Undef, ((V)((cm_844 * 0.93))))).S("\">").V(Call(an_26, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;").V(Call(f1_19, V.Undef, ((V)((-cm_844))))).End())), ((V)(2.4)))).S("</circle>");
rg_842.S("<circle r=\"").V(GetIdx(RR_770, 2D)).S("\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"2\" stroke-linecap=\"round\" stroke-dasharray=\"").V(Call(f1_19, V.Undef, ((V)((((2D * PI_36) * ToNum(GetIdx(RR_770, 2D))) * 0.1))))).S(" ").V(Call(f1_19, V.Undef, ((V)((((2D * PI_36) * ToNum(GetIdx(RR_770, 2D))) * 0.9))))).S("\">").V(Call(an_26, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;").V(Call(f1_19, V.Undef, ((V)(((2D * PI_36) * ToNum(GetIdx(RR_770, 2D))))))).End())), ((V)(1.8)))).S("</circle>");
f_834 = ((V)(JsStrBuf.Begin().V(f_834).S("<g transform=\"").V(Call(plane_24, V.Undef, p_831, ((V)(6D)), ((V)(RC_769)))).S("\"><g filter=\"url(#lsg)\" opacity=\"0.6\">").S(rgG_843.Str).S("</g>").S(rg_842.Str).S("</g>").End()));
ends_845 = Arr();
Invoke(HX_768, "forEach", Fn((V _arrowThis876, int _argc868, V x_874, V i_875, V _a872, V _a873, V[] _rest869) => {
V o_877 = default;
V cols_878 = default;
o_877 = Call(p_831, V.Undef, x_874, ((V)((TH_767 - 3.5))), ((V)(10.2)));
cols_878 = Call(rep_20, V.Undef, Get(pal_763, "length"), Fn((V _arrowThis886, int _argc879, V m_885, V _a882, V _a883, V _a884, V[] _rest880) => {
return GetIdx(pal_763, (ToNum(Add(m_885, i_875)) % ToNum(Get(pal_763, "length"))));
}, 1, "", true));
f_834 = Add(f_834, Call(fan_54, V.Undef, o_877, k_832, NewObj(11).Put("n", ((V)(4D))).Put("c0", ((V)((180D + ((ToNum(i_875) - 1.5) * 14D))))).Put("sp", ((V)(20D))).Put("L", ((V)(116D))).Put("sw", ((V)(18D))).Put("dur", ((V)((2.4 + (ToNum(i_875) * 0.35))))).Put("ph", ((V)((ToNum(i_875) * 0.6)))).Put("cols", cols_878).Put("cd", ((V)(3D))).Put("blink", ((V)((NumTruthy((ToNum(i_875) % 2D)) ? "1;1;0;1;1;0" : "1;0;1;1;0;1")))).Put("bd", ((V)(2.6))).V));
Invoke(ends_845, "push", Arr(((V)((ToNum(GetIdx(o_877, 0D)) - (66D * ToNum(k_832))))), Add(GetIdx(o_877, 1D), ((V)((118D * ToNum(k_832)))))), Arr(Add(GetIdx(o_877, 0D), ((V)((66D * ToNum(k_832))))), Add(GetIdx(o_877, 1D), ((V)((118D * ToNum(k_832)))))));
return default;
}, 2, "", true));
tz_846 = new JsStrBuf("");
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis894, int _argc887, V s_893, V _a890, V _a891, V _a892, V[] _rest888) => {
JsStrBuf d_895 = null;
d_895 = new JsStrBuf("");
Call(rep_20, V.Undef, ((V)(16D)), Fn((V _arrowThis903, int _argc896, V i_902, V _a899, V _a900, V _a901, V[] _rest897) => {
V q_904 = default;
q_904 = Call(p_831, V.Undef, ((V)(((ToNum(s_893) * TX_766) + (NumTruthy((ToNum(i_902) % 2D)) ? 5D : (-5D))))), ((V)((6D + (ToNum(i_902) * 9.6)))), ((V)(5.3)));
d_895.S((Truthy(i_902) ? "L" : "M")).V(Call(P2_23, V.Undef, q_904));
return default;
}, 1, "", true));
tz_846.S("<path d=\"").S(d_895.Str).S("\" fill=\"none\" stroke=\"").V(CH_37).S("\" stroke-width=\"").V(Call(f1_19, V.Undef, ((V)((0.6 * ToNum(k_832)))))).S("\"/>");
return default;
}, 1, "", true));
{
JsStrBuf d_905 = null;
d_905 = new JsStrBuf("");
Call(rep_20, V.Undef, ((V)(36D)), Fn((V _arrowThis913, int _argc906, V i_912, V _a909, V _a910, V _a911, V[] _rest907) => {
V q_914 = default;
q_914 = Call(p_831, V.Undef, ((V)((((-TX_766) - 6D) + ((ToNum(i_912) * ((2D * TX_766) + 12D)) / 35D)))), ((V)((TH_767 + (NumTruthy((ToNum(i_912) % 2D)) ? 7D : 1D)))), ((V)(5.6)));
d_905.S((Truthy(i_912) ? "L" : "M")).V(Call(P2_23, V.Undef, q_914));
return default;
}, 1, "", true));
tz_846.S("<path d=\"").S(d_905.Str).S("\" fill=\"none\" stroke=\"#6a6f80\" stroke-width=\"").V(Call(f1_19, V.Undef, ((V)((0.5 * ToNum(k_832)))))).S("\"/>");
}
f_834 = ((V)(JsStrBuf.Begin().S(tz_846.Str).V(f_834).End()));
fl_847 = Call(p_831, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(22D)));
un_833.S("<ellipse cx=\"").V(Call(f1_19, V.Undef, GetIdx(fl_847, 0D))).S("\" cy=\"").V(Call(f1_19, V.Undef, GetIdx(fl_847, 1D))).S("\" rx=\"").V(Call(f1_19, V.Undef, ((V)((96D * ToNum(k_832)))))).S("\" ry=\"").V(Call(f1_19, V.Undef, ((V)((((96D * ToNum(k_832)) * ToNum(SA_39)) * 0.55))))).S("\" fill=\"").V(GetIdx(pal_763, 0D)).S("\" opacity=\"0.22\">").V(Call(an_26, V.Undef, ((V)("fill")), vals_765, ((V)(3D)))).S("</ellipse>");
return NewObj(4).Put("defs", Add(Call(BLUR_28, V.Undef, ((V)("lzb")), ((V)(1.2))), Call(BLUR_28, V.Undef, ((V)("lsg")), ((V)(2.2))))).Put("under", ((V)(un_833.Str))).Put("front", f_834).Put("bb", Call(bbOf_29, V.Undef, Invoke(ends_845, "concat", Arr(Call(p_831, V.Undef, ((V)(((-TX_766) - 10D))), ((V)((TH_767 + 10D))), ((V)(0D))), Call(p_831, V.Undef, ((V)((TX_766 + 10D))), ((V)((TH_767 + 10D))), ((V)(0D))))), ((V)(2D)))).V;
return default;
}, 1, "", true));
return D_771;
return default;
}, 1, "", true));
draw3_57 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis923, int _argc915, V r_921, V o_922, V _a919, V _a920, V[] _rest916) => {
V res_924 = default;
res_924 = Call(draw3_57, V.Undef, r_921, o_922);
if (Truthy(((!(Truthy(res_924)) ? V.True : V.False) is var _t925 && Truthy(_t925) ? _t925 : Get(res_924, "_p4")))) {
return res_924;
}
Set(res_924, "_p4", ((V)(1D)));
try {
V f_926 = default;
f_926 = (Get(r_921, "s4") is var _t927 && !Truthy(_t927) ? _t927 : GetK(SURF4_52, Get(r_921, "s4")));
if (Truthy((f_926 is var _t928 && !Truthy(_t928) ? _t928 : Get(res_924, "surf")))) {
V A_929 = default;
A_929 = Call(f_926, V.Undef);
Set(res_924, "vb", Get(A_929, "vb"));
Set(res_924, "svg", Invoke(RD_8, "svgDoc", Get(A_929, "vb"), Arr(), Get(A_929, "body")));
Set(res_924, "src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Get(res_924, "svg"))).End())));
}
} catch (System.Exception _ex930) {
V e_931 = default;
e_931 = Caught(_ex930);
Invoke(G("console"), "warn", ((V)("reno plus4")), Get(r_921, "id"), e_931);
}
return res_924;
return default;
}, 2, "", true));
Set(RD_8, "SET4", NewObj(6).Put("CLB-006", NewObj(3).Put("s4", ((V)("foil"))).Put("live", ((V)("Soft glow"))).Put("note", ((V)("A small crumpled tin-foil ball on a string, lit by one clip-on blue party bulb. It just glows."))).V).Put("CLB-026", NewObj(3).Put("s4", ((V)("mirror"))).Put("live", ((V)("Spinning ball"))).Put("note", ((V)("A bigger glass mirror ball that turns on its motor under a strong pinspot. Light rays and sparkles circle the room as it spins."))).V).Put("CLB-066", NewObj(3).Put("spec", ((V)("laserSphere"))).Put("live", ((V)("Laser show"))).Put("note", ((V)("An RGB laser projector fires sweeping beam fans in changing colours. The giant mirror sphere above it spins and throws coloured sparkles round the room."))).V).Put("CLB-086", NewObj(3).Put("spec", ((V)("holoDancer"))).Put("live", ((V)("Live hologram"))).Put("note", ((V)("A hologram dancer grooves on the emitter with a glitchy flicker, while two plasma coils throw lightning across the stage."))).V).Put("CLB-101", NewObj(2).Put("spec", ((V)("ledCove"))).Put("note", ((V)("An LED strip hidden in a wall cove washes the wall with colour. Pick a colour set and a pattern."))).V).Put("CLB-104", NewObj(2).Put("spec", ((V)("ledShow"))).Put("note", ((V)("A truss arch with a pixel wall, three halo rings and four sweeping laser heads, all in one colour set and pattern."))).V).V);
edit3_58 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis939, int _argc932, V rows_938, V _a935, V _a936, V _a937, V[] _rest933) => {
return Invoke(Call(edit3_58, V.Undef, rows_938), "map", Fn((V _arrowThis947, int _argc940, V r_946, V _a943, V _a944, V _a945, V[] _rest941) => {
return (Truthy(GetK(Get(RD_8, "SET4"), Get(r_946, "id"))) ? Object_assign(NewObj(0).V, r_946, GetK(Get(RD_8, "SET4"), Get(r_946, "id"))) : r_946);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "PLUS4", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
