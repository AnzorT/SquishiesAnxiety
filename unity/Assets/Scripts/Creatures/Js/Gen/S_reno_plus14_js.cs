// reno-plus14.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus14_js
    {

        public static void Run()
        {
Call(Named(boot_320 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V shade_11 = default;
V N_12 = default;
double PI_13 = 0;
V H_14 = default;
V cam_15 = default;
V rng_16 = default;
V an_17 = default;
V at_18 = default;
V SPL_19 = default;
V f1_20 = default;
V n4_21 = default;
V rep_22 = default;
V pth_23 = default;
V P2_24 = default;
V DEF11_25 = default;
V zsort_26 = default;
V box3_27 = default;
V cyl3_28 = default;
V sph_29 = default;
V FRM_30 = default;
V mk_31 = default;
V trim_32 = default;
V light_33 = default;
V doc_34 = default;
V cPipes_35 = default;
V cTile_36 = default;
V cCoffer_37 = default;
V cSky_38 = default;
V cNeb_39 = default;
V WALLC_40 = default;
V CBASE_41 = default;
V CEIL14_42 = default;
V cardOf_43 = default;
V DEF14_44 = default;
V glow_45 = default;
V ring_46 = default;
V swing_47 = default;
V FLK_48 = default;
V draw13_49 = default;
V edit13_50 = default;
if (_self1.IsNullish) _self1 = GlobalV;
cPipes_35 = Fn((V _self51, int _argc52, V G_58, V _a55, V _a56, V _a57, V[] _rest53) => {
V R_59 = default;
double NJ_60 = 0;
double hw_61 = 0;
V y0_62 = default;
JsStrBuf s_63 = null;
V pipe_64 = default;
V web_65 = default;
if (_self51.IsNullish) _self51 = GlobalV;
R_59 = Call(rng_16, V.Undef, ((V)("pipe14")));
NJ_60 = 17D;
hw_61 = 0.0062;
y0_62 = Invoke(G_58, "y", ((V)(0D)));
s_63 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Get(G_58, "tr")).S("\" fill=\"#7c6852\"/>").End());
{
double i_66 = 0;
i_66 = 0D;
while (true) {
if (!((i_66 < 22D))) break;
double t0_68 = 0;
double t1_69 = 0;
t0_68 = (i_66 / 22D);
t1_69 = ((i_66 + 1D) / 22D);
s_63.S("<path d=\"").V(Invoke(G_58, "quad", ((V)((-0.05))), ((V)(t0_68)), ((V)(1.05)), ((V)(t1_69)))).S("\" fill=\"").V(Call(shade_11, V.Undef, ((V)("#7c6852")), ((V)((0.9 + (ToNum(Call(R_59, V.Undef)) * 0.2)))))).S("\"/><path d=\"").V(Invoke(G_58, "hl", Invoke(G_58, "y", ((V)(t1_69))))).S("\" stroke=\"#5c4a37\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(Invoke(G_58, "z", Invoke(G_58, "y", ((V)(t1_69)))))))))).S("\"/>");
i_66++;
}
}
{
double i_70 = 0;
i_70 = 0D;
while (true) {
if (!((i_70 < NJ_60))) break;
double u_72 = 0;
double sd_73 = 0;
double dp_74 = 0;
u_72 = ((i_70 + 0.5) / NJ_60);
sd_73 = ((u_72 < 0.5) ? 1D : (-1D));
dp_74 = (0.011 * (System.Math.Abs((u_72 - 0.5)) * 2D));
s_63.S("<path d=\"").V(Invoke(G_58, "quad", ((V)((u_72 + (sd_73 * hw_61)))), ((V)(0D)), ((V)((u_72 + (sd_73 * (hw_61 + dp_74))))), ((V)(1D)))).S("\" fill=\"#8a6a44\"/><path d=\"").V(Invoke(G_58, "quad", ((V)((u_72 - hw_61))), ((V)(0D)), ((V)((u_72 + hw_61))), ((V)(1D)))).S("\" fill=\"#b28a5a\"/><path d=\"M").V(Invoke(G_58, "P", ((V)((u_72 - (hw_61 * 0.4)))), ((V)(0D)))).S("L").V(Invoke(G_58, "P", ((V)((u_72 - (hw_61 * 0.4)))), ((V)(1D)))).S("\" stroke=\"#d2a874\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(Get(G_58, "s"))))))).S("\"/>");
i_70++;
}
}
pipe_64 = Fn((V _arrowThis86, int _argc75, V t_81, V th_82, V c0_83, V c1_84, V[] _rest76) => {
V y_87 = default;
V z_88 = default;
double h_89 = 0;
V id_90 = default;
V c2_85 = default;
c2_85 = (_argc75 > 4 ? _rest76[0] : V.Undef);
y_87 = Invoke(G_58, "y", t_81);
z_88 = Invoke(G_58, "z", y_87);
h_89 = (ToNum(th_82) * ToNum(z_88));
id_90 = ((V)(JsStrBuf.Begin().S("pp").V(Invoke(c0_83, "slice", ((V)(1D)))).End()));
return ((V)(JsStrBuf.Begin().S("<defs><linearGradient id=\"").V(id_90).S("\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"").V(c2_85).S("\"/><stop offset=\"0.35\" stop-color=\"").V(c0_83).S("\"/><stop offset=\"1\" stop-color=\"").V(c1_84).S("\"/></linearGradient></defs><rect x=\"").V(Call(f1_20, V.Undef, Invoke(G_58, "x", ((V)((-0.05))), y_87))).S("\" y=\"").V(Call(f1_20, V.Undef, Add(y_87, ((V)((1.6 * ToNum(z_88))))))).S("\" width=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_58, "W")) * 1.1))))).S("\" height=\"").V(Call(f1_20, V.Undef, ((V)(h_89)))).S("\" fill=\"#000000\" opacity=\"0.25\" filter=\"url(#cb1)\"/><rect x=\"").V(Call(f1_20, V.Undef, Invoke(G_58, "x", ((V)((-0.05))), y_87))).S("\" y=\"").V(Call(f1_20, V.Undef, y_87)).S("\" width=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_58, "W")) * 1.1))))).S("\" height=\"").V(Call(f1_20, V.Undef, ((V)(h_89)))).S("\" fill=\"url(#").V(id_90).S(")\"/>").V(Invoke(Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis98, int _argc91, V k_97, V _a94, V _a95, V _a96, V[] _rest92) => {
double u_99 = 0;
u_99 = (((ToNum(k_97) * 3D) + 1.5) / NJ_60);
return ((V)(JsStrBuf.Begin().S("<rect x=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Invoke(G_58, "x", ((V)(u_99)), y_87)) - (0.8 * ToNum(z_88))))))).S("\" y=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(y_87) - (1.2 * ToNum(z_88))))))).S("\" width=\"").V(Call(f1_20, V.Undef, ((V)((1.6 * ToNum(z_88)))))).S("\" height=\"").V(Call(f1_20, V.Undef, ((V)((h_89 + (1.6 * ToNum(z_88))))))).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((0.4 * ToNum(z_88)))))).S("\" fill=\"#8e9398\"/>").End()));
return default;
}, 1, "", true)), "join", ((V)("")))).End()));
return default;
}, 5, "", true);
s_63.V(Add(Call(pipe_64, V.Undef, ((V)(0.5)), ((V)(6.4)), ((V)("#d9dde0")), ((V)("#8f969c")), ((V)("#f6f8f9"))), Call(pipe_64, V.Undef, ((V)(0.74)), ((V)(3.2)), ((V)("#d98a4e")), ((V)("#8a4a24")), ((V)("#f2c08c")))));
{
V y_100 = default;
V z_101 = default;
V x_102 = default;
y_100 = Invoke(G_58, "y", ((V)(0.5)));
z_101 = Invoke(G_58, "z", y_100);
x_102 = Invoke(G_58, "x", ((V)(0.71)), y_100);
s_63.S("<rect x=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(x_102) - (3.2 * ToNum(z_101))))))).S("\" y=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(y_100) - (6D * ToNum(z_101))))))).S("\" width=\"").V(Call(f1_20, V.Undef, ((V)((6.4 * ToNum(z_101)))))).S("\" height=\"").V(Call(f1_20, V.Undef, ((V)((6.4 * ToNum(z_101)))))).S("\" fill=\"#c3c8cc\"/><rect x=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(x_102) - (3.8 * ToNum(z_101))))))).S("\" y=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(y_100) - (1.4 * ToNum(z_101))))))).S("\" width=\"").V(Call(f1_20, V.Undef, ((V)((7.6 * ToNum(z_101)))))).S("\" height=\"").V(Call(f1_20, V.Undef, ((V)((2D * ToNum(z_101)))))).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((0.6 * ToNum(z_101)))))).S("\" fill=\"#e6e9eb\" stroke=\"#8f969c\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.3 * ToNum(Get(G_58, "s"))))))).S("\"/>");
}
{
V ty_103 = default;
V z_104 = default;
JsStrBuf d_105 = null;
ty_103 = Invoke(G_58, "y", ((V)(0.8)));
z_104 = Invoke(G_58, "z", ty_103);
d_105 = new JsStrBuf("");
{
double i_106 = 0;
i_106 = 3D;
while (true) {
if (!((i_106 < 9D))) break;
V xa_108 = default;
V xb_109 = default;
xa_108 = Invoke(G_58, "x", ((V)(((i_106 + 0.5) / NJ_60))), ty_103);
xb_109 = Invoke(G_58, "x", ((V)(((i_106 + 1.5) / NJ_60))), ty_103);
d_105.S(((i_106 == 3D) ? "M" : "L")).V(Call(f1_20, V.Undef, xa_108)).S(" ").V(Call(f1_20, V.Undef, ty_103)).S("Q").V(Call(f1_20, V.Undef, ((V)((ToNum(Add(xa_108, xb_109)) / 2D))))).S(" ").V(Call(f1_20, V.Undef, Add(ty_103, ((V)((3.2 * ToNum(z_104))))))).S(" ").V(Call(f1_20, V.Undef, xb_109)).S(" ").V(Call(f1_20, V.Undef, ty_103));
i_106++;
}
}
s_63.S("<path d=\"").S(d_105.Str).S("\" stroke=\"#1d1a18\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.9 * ToNum(z_104)))))).S("\" fill=\"none\"/>");
}
web_65 = Fn((V _arrowThis120, int _argc110, V u_116, V t_117, V r_118, V fl_119, V[] _rest111) => {
V y_121 = default;
V x_122 = default;
double z_123 = 0;
V A_124 = default;
double sx_125 = 0;
V d_126 = default;
y_121 = Invoke(G_58, "y", t_117);
x_122 = Invoke(G_58, "x", u_116, y_121);
z_123 = (ToNum(Invoke(G_58, "z", y_121)) * ToNum(r_118));
A_124 = Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis134, int _argc127, V k_133, V _a130, V _a131, V _a132, V[] _rest128) => {
return ((V)((((ToNum(k_133) / 5D) * PI_13) / 2D)));
}, 1, "", true));
sx_125 = (Truthy(fl_119) ? (-1D) : 1D);
d_126 = Invoke(Invoke(A_124, "map", Fn((V _arrowThis142, int _argc135, V a_141, V _a138, V _a139, V _a140, V[] _rest136) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_20, V.Undef, x_122)).S(" ").V(Call(f1_20, V.Undef, y_121)).S("l").V(Call(f1_20, V.Undef, ((V)((((sx_125 * FdLibm.Cos(ToNum(a_141))) * 9D) * z_123))))).S(" ").V(Call(f1_20, V.Undef, ((V)((((-FdLibm.Sin(ToNum(a_141))) * 5D) * z_123))))).End()));
}, 1, "", true)), "join", ((V)("")));
Invoke(Arr(((V)(0.35)), ((V)(0.65)), ((V)(0.95))), "forEach", Fn((V _arrowThis150, int _argc143, V k_149, V _a146, V _a147, V _a148, V[] _rest144) => {
d_126 = ((V)(JsStrBuf.Begin().V(d_126).S("M").V(Invoke(Invoke(A_124, "map", Fn((V _arrowThis158, int _argc151, V a_157, V _a154, V _a155, V _a156, V[] _rest152) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, Add(x_122, ((V)(((((sx_125 * FdLibm.Cos(ToNum(a_157))) * 9D) * z_123) * ToNum(k_149))))))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(y_121) - (((FdLibm.Sin(ToNum(a_157)) * 5D) * z_123) * ToNum(k_149))))))).End()));
}, 1, "", true)), "join", ((V)("L")))).End()));
return default;
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(d_126).S("\" stroke=\"#f4f1ea\" stroke-opacity=\"0.55\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.35 * ToNum(Get(G_58, "s"))))))).S("\" fill=\"none\"/>").End()));
return default;
}, 4, "", true);
s_63.V(Add(Add(Call(web_65, V.Undef, ((V)(((4D / NJ_60) + hw_61))), ((V)(1D)), ((V)(1D))), Call(web_65, V.Undef, ((V)(((13D / NJ_60) - hw_61))), ((V)(1D)), ((V)(0.8)), ((V)(1D)))), Call(web_65, V.Undef, ((V)(0.004)), ((V)(0.94)), ((V)(1.1)))));
{
V y_159 = default;
V z_160 = default;
V x_161 = default;
y_159 = Invoke(G_58, "y", ((V)(1D)));
z_160 = Invoke(G_58, "z", y_159);
x_161 = Invoke(G_58, "x", ((V)((4.6 / NJ_60))), y_159);
s_63.S("<g><path d=\"M").V(Call(f1_20, V.Undef, x_161)).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(y_159) - (4D * ToNum(z_160))))))).S("v").V(Call(f1_20, V.Undef, ((V)((3D * ToNum(z_160)))))).S("\" stroke=\"#f4f1ea\" stroke-opacity=\"0.6\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.25 * ToNum(Get(G_58, "s"))))))).S("\"/><g>").V(Call(at_18, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;0 ").V(Call(f1_20, V.Undef, ((V)(((-2.2) * ToNum(z_160)))))).S(";0 0").End())), ((V)(7D)), ((V)(0D)), Call(SPL_19, V.Undef, ((V)(2D))))).S("<circle cx=\"").V(Call(f1_20, V.Undef, x_161)).S("\" cy=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(y_159) - (0.6 * ToNum(z_160))))))).S("\" r=\"").V(Call(f1_20, V.Undef, ((V)((0.8 * ToNum(z_160)))))).S("\" fill=\"#2a221c\"/><path d=\"M").V(Call(f1_20, V.Undef, ((V)((ToNum(x_161) - (1.6 * ToNum(z_160))))))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(y_159) - (1.2 * ToNum(z_160))))))).S("L").V(Call(f1_20, V.Undef, Add(x_161, ((V)((1.6 * ToNum(z_160))))))).S(" ").V(Call(f1_20, V.Undef, y_159)).S("M").V(Call(f1_20, V.Undef, Add(x_161, ((V)((1.6 * ToNum(z_160))))))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(y_159) - (1.2 * ToNum(z_160))))))).S("L").V(Call(f1_20, V.Undef, ((V)((ToNum(x_161) - (1.6 * ToNum(z_160))))))).S(" ").V(Call(f1_20, V.Undef, y_159)).S("\" stroke=\"#2a221c\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.3 * ToNum(z_160)))))).S("\"/></g></g>");
}
return ((V)(JsStrBuf.Begin().S(s_63.Str).V(Call(light_33, V.Undef, G_58, ((V)(0.32)), ((V)(0.06)))).V(Call(trim_32, V.Undef, G_58, ((V)(4.2)), ((V)("#a07c52")))).End()));
return default;
}, 1, "cPipes", false);
cTile_36 = Fn((V _self162, int _argc163, V G_169, V _a166, V _a167, V _a168, V[] _rest164) => {
V R_170 = default;
double NU_171 = 0;
double NV_172 = 0;
JsStrBuf s_173 = null;
JsStrBuf grid_174 = null;
if (_self162.IsNullish) _self162 = GlobalV;
R_170 = Call(rng_16, V.Undef, ((V)("tile14")));
NU_171 = 18D;
NV_172 = 6D;
s_173 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Get(G_169, "tr")).S("\" fill=\"#26282d\"/>").End());
grid_174 = new JsStrBuf("");
{
double v_175 = 0;
v_175 = 0D;
while (true) {
if (!((v_175 < NV_172))) break;
{
double u_177 = 0;
u_177 = 0D;
while (true) {
if (!((u_177 < NU_171))) break;
double t0_179 = 0;
double t1_180 = 0;
double u0_181 = 0;
double u1_182 = 0;
V y1_183 = default;
V z_184 = default;
V odd_185 = default;
V gr_186 = default;
t0_179 = (v_175 / NV_172);
t1_180 = ((v_175 + 1D) / NV_172);
u0_181 = (u_177 / NU_171);
u1_182 = ((u_177 + 1D) / NU_171);
y1_183 = Invoke(G_169, "y", ((V)(t1_180)));
z_184 = Invoke(G_169, "z", y1_183);
odd_185 = (((u_177 == 11D) && (v_175 == 4D)) ? V.True : V.False);
gr_186 = (((u_177 == 5D) && (v_175 == 5D)) ? V.True : V.False);
if (Truthy(odd_185)) {
s_173.S("<path d=\"").V(Invoke(G_169, "quad", ((V)((u0_181 + 0.004))), ((V)((t0_179 + 0.05))), ((V)((u1_182 - 0.01))), ((V)((t1_180 - 0.02))))).S("\" fill=\"#45484f\" transform=\"translate(").V(Call(f1_20, V.Undef, ((V)((1.4 * ToNum(z_184)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((1.2 * ToNum(z_184)))))).S(")\"/>");
goto _cont178;
}
s_173.S("<path d=\"").V(Invoke(G_169, "quad", ((V)(u0_181)), ((V)(t0_179)), ((V)(u1_182)), ((V)(t1_180)))).S("\" fill=\"").V((Truthy(gr_186) ? ((V)("#5d6168")) : Call(shade_11, V.Undef, ((V)("#3c3f46")), ((V)((0.94 + (ToNum(Call(R_170, V.Undef)) * 0.12))))))).S("\"/>");
if (Truthy(gr_186)) {
Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis194, int _argc187, V k_193, V _a190, V _a191, V _a192, V[] _rest188) => {
return ((V)(s_173.S("<path d=\"M").V(Invoke(G_169, "P", ((V)((u0_181 + 0.004))), ((V)((t0_179 + ((ToNum(Add(k_193, ((V)(1D)))) * (t1_180 - t0_179)) / 5D)))))).S("L").V(Invoke(G_169, "P", ((V)((u1_182 - 0.004))), ((V)((t0_179 + ((ToNum(Add(k_193, ((V)(1D)))) * (t1_180 - t0_179)) / 5D)))))).S("\" stroke=\"#2e3035\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.7 * ToNum(z_184)))))).S("\"/>").Str));
}, 1, "", true));
} else {
s_173.S("<path d=\"M").V(Invoke(G_169, "P", ((V)((u0_181 + 0.006))), ((V)((t0_179 + 0.02))))).S("L").V(Invoke(G_169, "P", ((V)((u1_182 - 0.006))), ((V)((t0_179 + 0.02))))).S("\" stroke=\"#555962\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(z_184)))))).S("\"/>").V(Invoke(Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis202, int _argc195, V k_201, V _a198, V _a199, V _a200, V[] _rest196) => {
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(Call(f1_20, V.Undef, Invoke(G_169, "x", ((V)((u0_181 + ((ToNum(Add(k_201, ((V)(0.6)))) * (u1_182 - u0_181)) / 3.2)))), ((V)((ToNum(Add(Invoke(G_169, "y", ((V)(t0_179))), y1_183)) / 2D)))))).S("\" cy=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Add(Invoke(G_169, "y", ((V)(t0_179))), y1_183)) / 2D))))).S("\" r=\"").V(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(z_184)))))).S("\" fill=\"#2a2c31\" opacity=\"0.6\"/>").End()));
}, 1, "", true)), "join", ((V)(""))));
}
_cont178: ;
u_177++;
}
}
v_175++;
}
}
{
double u_203 = 0;
u_203 = 0D;
while (true) {
if (!((u_203 <= NU_171))) break;
grid_174.S("M").V(Invoke(G_169, "P", ((V)((u_203 / NU_171))), ((V)(0D)))).S("L").V(Invoke(G_169, "P", ((V)((u_203 / NU_171))), ((V)(1D))));
u_203++;
}
}
{
double v_205 = 0;
v_205 = 1D;
while (true) {
if (!((v_205 <= NV_172))) break;
grid_174.V(Invoke(G_169, "hl", Invoke(G_169, "y", ((V)((v_205 / NV_172))))));
v_205++;
}
}
s_173.S("<path d=\"").S(grid_174.Str).S("\" stroke=\"#55595f\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((1.5 * ToNum(Get(G_169, "s"))))))).S("\" fill=\"none\"/><path d=\"").S(grid_174.Str).S("\" stroke=\"#9aa0a6\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.7 * ToNum(Get(G_169, "s"))))))).S("\" fill=\"none\"/>");
return ((V)(JsStrBuf.Begin().S(s_173.Str).V(Call(light_33, V.Undef, G_169, ((V)(0.3)), ((V)(0.05)))).V(Call(trim_32, V.Undef, G_169, ((V)(2.6)), ((V)("#9aa0a6")))).End()));
return default;
}, 1, "cTile", false);
cCoffer_37 = Fn((V _self207, int _argc208, V G_214, V _a211, V _a212, V _a213, V[] _rest209) => {
double NU_215 = 0;
double NV_216 = 0;
double bw_217 = 0;
JsStrBuf s_218 = null;
JsStrBuf ros_219 = null;
JsStrBuf bl_220 = null;
if (_self207.IsNullish) _self207 = GlobalV;
NU_215 = 12D;
NV_216 = 5D;
bw_217 = 0.012;
s_218 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Get(G_214, "tr")).S("\" fill=\"#3e2416\"/>").End());
ros_219 = new JsStrBuf("");
{
double v_221 = 0;
v_221 = 0D;
while (true) {
if (!((v_221 < NV_216))) break;
{
double u_223 = 0;
u_223 = 0D;
while (true) {
if (!((u_223 < NU_215))) break;
double t0_225 = 0;
double t1_226 = 0;
double u0_227 = 0;
double u1_228 = 0;
V ym_229 = default;
V z_230 = default;
V xm_231 = default;
t0_225 = ((v_221 / NV_216) + 0.03);
t1_226 = (((v_221 + 1D) / NV_216) - 0.03);
u0_227 = ((u_223 / NU_215) + bw_217);
u1_228 = (((u_223 + 1D) / NU_215) - bw_217);
ym_229 = Invoke(G_214, "y", ((V)(((t0_225 + t1_226) / 2D))));
z_230 = Invoke(G_214, "z", ym_229);
xm_231 = Invoke(G_214, "x", ((V)(((u0_227 + u1_228) / 2D))), ym_229);
s_218.S("<path d=\"").V(Invoke(G_214, "quad", ((V)(u0_227)), ((V)(t0_225)), ((V)(u1_228)), ((V)(t1_226)))).S("\" fill=\"#6e4329\"/><path d=\"").V(Invoke(G_214, "quad", ((V)((u0_227 + 0.006))), ((V)((t0_225 + 0.04))), ((V)((u1_228 - 0.006))), ((V)((t1_226 - 0.012))))).S("\" fill=\"#5a1a26\"/><path d=\"").V(Invoke(G_214, "quad", ((V)((u0_227 + 0.006))), ((V)((t0_225 + 0.04))), ((V)((u1_228 - 0.006))), ((V)((t0_225 + 0.07))))).S("\" fill=\"#000000\" opacity=\"0.3\"/>").S("<ellipse cx=\"").V(Call(f1_20, V.Undef, xm_231)).S("\" cy=\"").V(Call(f1_20, V.Undef, ym_229)).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((6D * ToNum(z_230)))))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)((2.4 * ToNum(z_230)))))).S("\" fill=\"#ffc27a\" opacity=\"0.35\" filter=\"url(#cb3)\"/><ellipse cx=\"").V(Call(f1_20, V.Undef, xm_231)).S("\" cy=\"").V(Call(f1_20, V.Undef, ym_229)).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((1.6 * ToNum(z_230)))))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)((0.7 * ToNum(z_230)))))).S("\" fill=\"#fff0c8\"/>");
u_223++;
}
}
v_221++;
}
}
{
double v_232 = 0;
v_232 = 0D;
while (true) {
if (!((v_232 <= NV_216))) break;
{
double u_234 = 0;
u_234 = 0D;
while (true) {
if (!((u_234 <= NU_215))) break;
V y_236 = default;
V z_237 = default;
y_236 = Invoke(G_214, "y", ((V)((v_232 / NV_216))));
z_237 = Invoke(G_214, "z", y_236);
ros_219.S("<circle cx=\"").V(Call(f1_20, V.Undef, Invoke(G_214, "x", ((V)((u_234 / NU_215))), y_236))).S("\" cy=\"").V(Call(f1_20, V.Undef, y_236)).S("\" r=\"").V(Call(f1_20, V.Undef, ((V)((0.95 * ToNum(z_237)))))).S("\" fill=\"#d9ac4a\"/>");
u_234++;
}
}
v_232++;
}
}
bl_220 = new JsStrBuf("");
{
double u_238 = 0;
u_238 = 0D;
while (true) {
if (!((u_238 <= NU_215))) break;
bl_220.S("M").V(Invoke(G_214, "P", ((V)(((u_238 / NU_215) - (bw_217 * 0.6)))), ((V)(0D)))).S("L").V(Invoke(G_214, "P", ((V)(((u_238 / NU_215) - (bw_217 * 0.6)))), ((V)(1D))));
u_238++;
}
}
{
double v_240 = 0;
v_240 = 1D;
while (true) {
if (!((v_240 <= NV_216))) break;
bl_220.V(Invoke(G_214, "hl", ((V)((ToNum(Invoke(G_214, "y", ((V)((v_240 / NV_216))))) - (0.6 * ToNum(Invoke(G_214, "z", Invoke(G_214, "y", ((V)((v_240 / NV_216))))))))))));
v_240++;
}
}
s_218.S("<path d=\"").S(bl_220.Str).S("\" stroke=\"#8a5a36\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.6 * ToNum(Get(G_214, "s"))))))).S("\" fill=\"none\" opacity=\"0.8\"/>").S(ros_219.Str);
return ((V)(JsStrBuf.Begin().S(s_218.Str).V(Call(light_33, V.Undef, G_214, ((V)(0.3)), ((V)(0.06)))).V(Call(trim_32, V.Undef, G_214, ((V)(4.6)), ((V)("#4a2b1a")), ((V)(JsStrBuf.Begin().S("<path d=\"").V(Invoke(G_214, "hl", ((V)(((ToNum(Get(G_214, "H")) - (4.6 * ToNum(Invoke(G_214, "z", Get(G_214, "H"))))) + (0.9 * ToNum(Get(G_214, "s")))))))).S("\" stroke=\"#d9ac4a\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.7 * ToNum(Get(G_214, "s"))))))).S("\"/>").End())))).End()));
return default;
}, 1, "cCoffer", false);
cSky_38 = Fn((V _self242, int _argc243, V G_249, V _a246, V _a247, V _a248, V[] _rest244) => {
V R_250 = default;
JsStrBuf s_251 = null;
V COL_252 = default;
double yb_253 = 0;
if (_self242.IsNullish) _self242 = GlobalV;
R_250 = Call(rng_16, V.Undef, ((V)("sky14")));
s_251 = new JsStrBuf(JsStrBuf.Begin().S("<defs><linearGradient id=\"skg\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#0b0e26\"/><stop offset=\"1\" stop-color=\"#1c2252\"/></linearGradient></defs><path d=\"").V(Get(G_249, "tr")).S("\" fill=\"url(#skg)\"/>").End());
s_251.S("<g filter=\"url(#cb6)\" opacity=\"0.5\"><ellipse cx=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_249, "W")) * 0.42))))).S("\" cy=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_249, "H")) * 0.62))))).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_249, "W")) * 0.38))))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_249, "H")) * 0.14))))).S("\" fill=\"#7a76c8\" transform=\"rotate(-2 ").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_249, "W")) * 0.42))))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_249, "H")) * 0.62))))).S(")\"/><ellipse cx=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_249, "W")) * 0.6))))).S("\" cy=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_249, "H")) * 0.7))))).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_249, "W")) * 0.16))))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_249, "H")) * 0.08))))).S("\" fill=\"#b49ad8\"/></g>");
COL_252 = Arr(((V)("#ffffff")), ((V)("#fff2cc")), ((V)("#cfe4ff")), ((V)("#ffffff")), ((V)("#ffd6ef")), ((V)("#bff6ee")));
Call(rep_22, V.Undef, ((V)(170D)), Fn((V _arrowThis261, int _argc254, V i_260, V _a257, V _a258, V _a259, V[] _rest255) => {
V u_262 = default;
double t_263 = 0;
V y_264 = default;
V z_265 = default;
V x_266 = default;
double r_267 = 0;
u_262 = Call(R_250, V.Undef);
t_263 = (0.25 + (ToNum(Call(R_250, V.Undef)) * 0.75));
y_264 = Invoke(G_249, "y", ((V)(t_263)));
z_265 = Invoke(G_249, "z", y_264);
x_266 = Invoke(G_249, "x", u_262, y_264);
r_267 = ((0.45 + (ToNum(Call(R_250, V.Undef)) * 0.7)) * ToNum(z_265));
s_251.S("<circle cx=\"").V(Call(f1_20, V.Undef, x_266)).S("\" cy=\"").V(Call(f1_20, V.Undef, y_264)).S("\" r=\"").V(Call(f1_20, V.Undef, ((V)(r_267)))).S("\" fill=\"").V(GetIdx(COL_252, (ToNum(i_260) % 6D))).S("\">").V(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.25;1;0.25")), Call(n4_21, V.Undef, ((V)((1.6 + (ToNum(Call(R_250, V.Undef)) * 3.2))))), Call(n4_21, V.Undef, ((V)(((-ToNum(Call(R_250, V.Undef))) * 4D)))))).S("</circle>");
return default;
}, 1, "", true));
{
V y_268 = default;
V z_269 = default;
V x_270 = default;
y_268 = Invoke(G_249, "y", ((V)(0.8)));
z_269 = Invoke(G_249, "z", y_268);
x_270 = Invoke(G_249, "x", ((V)(0.3)), y_268);
s_251.S("<g opacity=\"0\"><path d=\"M0 0L").V(Call(f1_20, V.Undef, ((V)(((-26D) * ToNum(z_269)))))).S(" ").V(Call(f1_20, V.Undef, ((V)(((-1D) * ToNum(z_269)))))).S("L").V(Call(f1_20, V.Undef, ((V)(((-26D) * ToNum(z_269)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((0.6 * ToNum(z_269)))))).S("Z\" fill=\"#ffffff\" transform=\"translate(").V(Call(f1_20, V.Undef, x_270)).S(" ").V(Call(f1_20, V.Undef, y_268)).S(")\"/>").V(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0;0;1;0;0")), ((V)(11D)), ((V)((-3D))), ((V)(" keyTimes=\"0;0.86;0.89;0.94;1\"")))).V(Call(at_18, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;0 0;").V(Call(f1_20, V.Undef, ((V)((60D * ToNum(z_269)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((3D * ToNum(z_269)))))).S(";").V(Call(f1_20, V.Undef, ((V)((110D * ToNum(z_269)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((6D * ToNum(z_269)))))).S(";").V(Call(f1_20, V.Undef, ((V)((110D * ToNum(z_269)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((6D * ToNum(z_269)))))).End())), ((V)(11D)), ((V)((-3D))), ((V)(" keyTimes=\"0;0.86;0.89;0.94;1\"")))).S("</g>");
}
yb_253 = (ToNum(Get(G_249, "H")) - (4.4 * ToNum(Invoke(G_249, "z", Get(G_249, "H")))));
return ((V)(JsStrBuf.Begin().S(s_251.Str).V(Call(light_33, V.Undef, G_249, ((V)(0.25)), ((V)(0.04)))).V(Call(trim_32, V.Undef, G_249, ((V)(4.4)), ((V)("#5e3722")), ((V)(JsStrBuf.Begin().S("<path d=\"").V(Invoke(G_249, "hl", ((V)((yb_253 - (0.6 * ToNum(Get(G_249, "s")))))))).S("\" stroke=\"#ffcf7a\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((4D * ToNum(Get(G_249, "s"))))))).S("\" opacity=\"0.4\" filter=\"url(#cb3)\">").V(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.3;0.55;0.3")), ((V)(4D)), ((V)(0D)), Call(SPL_19, V.Undef, ((V)(2D))))).S("</path><path d=\"").V(Invoke(G_249, "hl", ((V)((yb_253 - (0.3 * ToNum(Get(G_249, "s")))))))).S("\" stroke=\"#ffe7b8\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.7 * ToNum(Get(G_249, "s"))))))).S("\"/>").End())))).End()));
return default;
}, 1, "cSky", false);
cNeb_39 = Fn((V _self271, int _argc272, V G_278, V _a275, V _a276, V _a277, V[] _rest273) => {
V R_279 = default;
JsStrBuf s_280 = null;
V CL_281 = default;
double yb_282 = 0;
if (_self271.IsNullish) _self271 = GlobalV;
R_279 = Call(rng_16, V.Undef, ((V)("neb14")));
s_280 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"").V(Get(G_278, "tr")).S("\" fill=\"#0a0818\"/>").End());
CL_281 = Arr(Arr(((V)("#7a3cff")), ((V)(0.2)), ((V)(0.55)), ((V)(0.22))), Arr(((V)("#3fd0ff")), ((V)(0.55)), ((V)(0.7)), ((V)(0.18))), Arr(((V)("#ff5fb4")), ((V)(0.82)), ((V)(0.5)), ((V)(0.16))), Arr(((V)("#a66bff")), ((V)(0.4)), ((V)(0.9)), ((V)(0.2))), Arr(((V)("#3fd0ff")), ((V)(0.05)), ((V)(0.85)), ((V)(0.14))), Arr(((V)("#ff5fb4")), ((V)(0.65)), ((V)(0.95)), ((V)(0.12))), Arr(((V)("#7a3cff")), ((V)(0.95)), ((V)(0.8)), ((V)(0.18))));
s_280.S("<g filter=\"url(#cb6)\">").V(Invoke(Invoke(CL_281, "map", Fn((V _arrowThis299, int _argc283, V _a285, V i_289, V _a287, V _a288, V[] _rest284) => {
V y_300 = default;
V x_301 = default;
V dx_302 = default;
V c_292 = default;
V u_294 = default;
V t_296 = default;
V w_298 = default;
{ V _t290 = ListOf(_a285);
{ V _t291 = GetIdx(_t290, 0D);
c_292 = _t291; }
{ V _t293 = GetIdx(_t290, 1D);
u_294 = _t293; }
{ V _t295 = GetIdx(_t290, 2D);
t_296 = _t295; }
{ V _t297 = GetIdx(_t290, 3D);
w_298 = _t297; }
}
y_300 = Invoke(G_278, "y", t_296);
x_301 = Invoke(G_278, "x", u_294, y_300);
dx_302 = Call(f1_20, V.Undef, ((V)((((NumTruthy((ToNum(i_289) % 2D)) ? (-1D) : 1D) * ToNum(Get(G_278, "W"))) * 0.05))));
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(Call(f1_20, V.Undef, x_301)).S("\" cy=\"").V(Call(f1_20, V.Undef, y_300)).S("\" rx=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_278, "W")) * ToNum(w_298)))))).S("\" ry=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_278, "H")) * 0.16))))).S("\" fill=\"").V(c_292).S("\" opacity=\"0.55\">").V(Call(at_18, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;").V(dx_302).S(" 0;0 0").End())), ((V)((14D + (ToNum(i_289) * 3D)))), ((V)(((-ToNum(i_289)) * 2D))), Call(SPL_19, V.Undef, ((V)(2D))))).V(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.4;0.7;0.4")), Add(((V)(6D)), i_289), ((V)((-ToNum(i_289)))), Call(SPL_19, V.Undef, ((V)(2D))))).S("</ellipse>").End()));
return default;
}, 2, "", true)), "join", ((V)("")))).S("</g>");
Call(rep_22, V.Undef, ((V)(120D)), Fn((V _arrowThis310, int _argc303, V i_309, V _a306, V _a307, V _a308, V[] _rest304) => {
double t_311 = 0;
V y_312 = default;
V z_313 = default;
t_311 = (0.2 + (ToNum(Call(R_279, V.Undef)) * 0.8));
y_312 = Invoke(G_278, "y", ((V)(t_311)));
z_313 = Invoke(G_278, "z", y_312);
s_280.S("<circle cx=\"").V(Call(f1_20, V.Undef, Invoke(G_278, "x", Call(R_279, V.Undef), y_312))).S("\" cy=\"").V(Call(f1_20, V.Undef, y_312)).S("\" r=\"").V(Call(f1_20, V.Undef, ((V)(((0.4 + (ToNum(Call(R_279, V.Undef)) * 0.6)) * ToNum(z_313)))))).S("\" fill=\"").S((NumTruthy((ToNum(i_309) % 4D)) ? "#ffffff" : "#cfe6ff")).S("\">").V(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.2;1;0.2")), Call(n4_21, V.Undef, ((V)((1.6 + (ToNum(Call(R_279, V.Undef)) * 3D))))), Call(n4_21, V.Undef, ((V)(((-ToNum(Call(R_279, V.Undef))) * 4D)))))).S("</circle>");
return default;
}, 1, "", true));
s_280.S("<defs><linearGradient id=\"nsw\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0\"><stop offset=\"0\" stop-color=\"#ffffff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#e6dcff\" stop-opacity=\"0.14\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient></defs><rect x=\"").V(Call(f1_20, V.Undef, ((V)(((-ToNum(Get(G_278, "W"))) * 0.3))))).S("\" width=\"").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_278, "W")) * 0.2))))).S("\" height=\"").V(Get(G_278, "H")).S("\" fill=\"url(#nsw)\">").V(Call(at_18, V.Undef, ((V)("translate")), ((V)(JsStrBuf.Begin().S("0 0;0 0;").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_278, "W")) * 1.5))))).S(" 0").End())), ((V)(9D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.5;1\"")))).S("</rect>");
yb_282 = (ToNum(Get(G_278, "H")) - (3.6 * ToNum(Invoke(G_278, "z", Get(G_278, "H")))));
return ((V)(JsStrBuf.Begin().S(s_280.Str).V(Call(light_33, V.Undef, G_278, ((V)(0.2)), ((V)(0.03)))).V(Call(trim_32, V.Undef, G_278, ((V)(3.6)), ((V)("#0e0b1e")), ((V)(JsStrBuf.Begin().S("<path d=\"").V(Invoke(G_278, "hl", ((V)((yb_282 - (0.8 * ToNum(Get(G_278, "s")))))))).S("\" stroke=\"#7a6cff\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((4D * ToNum(Get(G_278, "s"))))))).S("\" opacity=\"0.4\" filter=\"url(#cb3)\">").V(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.2;0.5;0.2")), ((V)(4D)), ((V)(0D)), Call(SPL_19, V.Undef, ((V)(2D))))).S("</path><path d=\"").V(Invoke(G_278, "hl", ((V)((yb_282 + (0.6 * ToNum(Get(G_278, "s")))))))).S("\" stroke=\"#a49bff\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.6 * ToNum(Get(G_278, "s"))))))).S("\"/>").End())))).End()));
return default;
}, 1, "cNeb", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((((RD_8 is var _t314 && !Truthy(_t314) ? _t314 : Get(RD_8, "PLUS13")) is var _t315 && !Truthy(_t315) ? _t315 : Get(RD_8, "H12")) is var _t316 && !Truthy(_t316) ? _t316 : Get(RD_8, "H11")) is var _t317 && !Truthy(_t317) ? _t317 : Get(RD_8, "H10")) is var _t318 && !Truthy(_t318) ? _t318 : X_9) is var _t319 && !Truthy(_t319) ? _t319 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_320.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS14"))) {
return default;
}
K_10 = Get(X_9, "K");
shade_11 = Get(K_10, "shade");
N_12 = Get(RD_8, "N");
PI_13 = System.Math.PI;
H_14 = Get(RD_8, "H10");
{ V _t321 = H_14;
if (_t321.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t321));
{ V _t322 = Get(_t321, "cam");
cam_15 = _t322; }
{ V _t323 = Get(_t321, "rng");
rng_16 = _t323; }
{ V _t324 = Get(_t321, "an");
an_17 = _t324; }
{ V _t325 = Get(_t321, "at");
at_18 = _t325; }
{ V _t326 = Get(_t321, "SPL");
SPL_19 = _t326; }
{ V _t327 = Get(_t321, "f1");
f1_20 = _t327; }
{ V _t328 = Get(_t321, "n4");
n4_21 = _t328; }
{ V _t329 = Get(_t321, "rep");
rep_22 = _t329; }
{ V _t330 = Get(_t321, "pth");
pth_23 = _t330; }
{ V _t331 = Get(_t321, "P2");
P2_24 = _t331; } }
{ V _t332 = Get(RD_8, "H11");
if (_t332.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t332));
{ V _t333 = Get(_t332, "DEF11");
DEF11_25 = _t333; }
{ V _t334 = Get(_t332, "zsort");
zsort_26 = _t334; } }
box3_27 = Fn((V _arrowThis343, int _argc335, V C_341, V o_342, V _a339, V _a340, V[] _rest336) => {
return Invoke(H_14, "box3", C_341, Object_assign(NewObj(0).V, o_342, NewObj(7).Put("mat", V.Null).Put("tpat", V.Null).Put("gl", ((V)((Truthy(Get(o_342, "gl")) ? Min(ToNum(Get(o_342, "gl")), 0.2) : 0D)))).Put("olw", ((V)(1D))).Put("olo", ((V)(0.95))).Put("olc", Call(shade_11, V.Undef, Get(o_342, "col"), ((V)(0.32)))).Put("edge", ((V)(0.5))).V));
}, 2, "", true);
cyl3_28 = Fn((V _arrowThis356, int _argc344, V C_350, V a_351, V b_352, V r_353, V[] _rest345) => {
V col_354 = default;
V o_355 = default;
col_354 = (_argc344 > 4 ? _rest345[0] : V.Undef);
o_355 = (_argc344 > 5 ? _rest345[1] : V.Undef);
return Invoke(H_14, "cyl3", C_350, a_351, b_352, r_353, col_354, Object_assign(NewObj(0).V, (o_355 is var _t357 && Truthy(_t357) ? _t357 : NewObj(0).V), NewObj(4).Put("mat", ((V)((Truthy((o_355 is var _t358 && !Truthy(_t358) ? _t358 : (SEqS(Get(o_355, "mat"), "gloss") ? V.True : V.False))) ? "gloss" : "plastic")))).Put("pat", V.Null).Put("olw", ((V)(0.8))).Put("olo", ((V)(0.95))).V));
}, 6, "", true);
sph_29 = Fn((V _arrowThis370, int _argc359, V C_365, V q_366, V r_367, V col_368, V[] _rest360) => {
V c_371 = default;
V o_369 = default;
o_369 = (_argc359 > 4 ? _rest360[0] : V.Undef);
c_371 = Invoke(C_365, "P", q_366);
return ((V)(JsStrBuf.Begin().V(Invoke(H_14, "sph", C_365, q_366, r_367, col_368, o_369)).S(string.Concat("<circle cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(c_371, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(c_371, 1D))), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(r_367) * ToNum(Get(C_365, "k"))))))), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_11, V.Undef, col_368, ((V)(0.35)))), "\" stroke-width=\"0.5\"/>")).End()));
return default;
}, 5, "", true);
FRM_30 = NewObj(2).Put("room", NewObj(4).Put("W", ((V)(1259.6))).Put("H", ((V)(70D))).Put("ins", ((V)(303.8))).Put("s", ((V)(1D))).V).Put("card", NewObj(4).Put("W", ((V)(80D))).Put("H", ((V)(26D))).Put("ins", ((V)(16D))).Put("s", ((V)(0.16))).V).V;
mk_31 = Fn((V _arrowThis379, int _argc372, V F_378, V _a375, V _a376, V _a377, V[] _rest373) => {
V G_380 = default;
V wk_381 = default;
G_380 = Object_assign(NewObj(0).V, F_378);
wk_381 = Fn((V _arrowThis389, int _argc382, V y_388, V _a385, V _a386, V _a387, V[] _rest383) => {
return ((V)((1D - (((2D * ToNum(Get(G_380, "ins"))) * ToNum(y_388)) / (ToNum(Get(G_380, "H")) * ToNum(Get(G_380, "W")))))));
}, 1, "", true);
Set(G_380, "x", Fn((V _arrowThis398, int _argc390, V u_396, V y_397, V _a394, V _a395, V[] _rest391) => {
return ((V)((((ToNum(Get(G_380, "ins")) * ToNum(y_397)) / ToNum(Get(G_380, "H"))) + ((ToNum(u_396) * ToNum(Get(G_380, "W"))) * ToNum(Call(wk_381, V.Undef, y_397))))));
}, 2, "", true));
Set(G_380, "y", Fn((V _arrowThis406, int _argc399, V t_405, V _a402, V _a403, V _a404, V[] _rest400) => {
return ((V)(((ToNum(Get(G_380, "H")) * (1D - (1D / (1D + ((2D * ToNum(t_405)) / 3D))))) / 0.4)));
}, 1, "", true));
Set(G_380, "z", Fn((V _arrowThis414, int _argc407, V y_413, V _a410, V _a411, V _a412, V[] _rest408) => {
return ((V)(((ToNum(Get(G_380, "s")) * ToNum(Call(wk_381, V.Undef, y_413))) / 0.6)));
}, 1, "", true));
Set(G_380, "P", Fn((V _arrowThis423, int _argc415, V u_421, V t_422, V _a419, V _a420, V[] _rest416) => {
V y_424 = default;
y_424 = Invoke(G_380, "y", t_422);
return ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, Invoke(G_380, "x", u_421, y_424))).S(" ").V(Call(f1_20, V.Undef, y_424)).End()));
return default;
}, 2, "", true));
Set(G_380, "quad", Fn((V _arrowThis435, int _argc425, V u0_431, V t0_432, V u1_433, V t1_434, V[] _rest426) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(G_380, "P", u0_431, t0_432)).S("L").V(Invoke(G_380, "P", u1_433, t0_432)).S("L").V(Invoke(G_380, "P", u1_433, t1_434)).S("L").V(Invoke(G_380, "P", u0_431, t1_434)).S("Z").End()));
}, 4, "", true));
Set(G_380, "tr", ((V)(JsStrBuf.Begin().S("M0 0H").V(Get(G_380, "W")).S("L").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_380, "W")) - ToNum(Get(G_380, "ins"))))))).S(" ").V(Get(G_380, "H")).S("H").V(Call(f1_20, V.Undef, Get(G_380, "ins"))).S("Z").End())));
Set(G_380, "hl", Fn((V _arrowThis444, int _argc436, V y_442, V o_443, V _a440, V _a441, V[] _rest437) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_20, V.Undef, Invoke(G_380, "x", ((V)((-0.02))), y_442))).S(" ").V(Call(f1_20, V.Undef, y_442)).S("H").V(Call(f1_20, V.Undef, Invoke(G_380, "x", ((V)(1.02)), y_442))).End()));
}, 2, "", true));
Set(G_380, "b", Fn((V _arrowThis452, int _argc445, V sd_451, V _a448, V _a449, V _a450, V[] _rest446) => {
return ((V)(JsStrBuf.Begin().S("<filter id=\"cb").V(sd_451).S("\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"").V(Call(n4_21, V.Undef, ((V)((ToNum(sd_451) * (LtN(Get(G_380, "s"), 1D) ? 0.35 : 1D)))))).S("\"/></filter>").End()));
}, 1, "", true));
return G_380;
return default;
}, 1, "", true);
trim_32 = Fn((V _arrowThis463, int _argc453, V G_459, V bw_460, V col_461, V ex_462, V[] _rest454) => {
double n_464 = 0;
V w_465 = default;
V L_466 = default;
V R_467 = default;
V sideIn_468 = default;
V back_469 = default;
V sl_470 = default;
V sr_471 = default;
V lipB_472 = default;
V lipL_473 = default;
V lipR_474 = default;
n_464 = 12D;
w_465 = Fn((V _arrowThis482, int _argc475, V y_481, V _a478, V _a479, V _a480, V[] _rest476) => {
return ((V)((ToNum(bw_460) * ToNum(Invoke(G_459, "z", y_481)))));
}, 1, "", true);
L_466 = Arr();
R_467 = Arr();
{
double i_483 = 0;
i_483 = 0D;
while (true) {
if (!((i_483 <= n_464))) break;
double y_485 = 0;
y_485 = ((ToNum(Get(G_459, "H")) * i_483) / n_464);
Invoke(L_466, "push", Arr(Invoke(G_459, "x", ((V)(0D)), ((V)(y_485))), ((V)(y_485))));
Invoke(R_467, "push", Arr(Invoke(G_459, "x", ((V)(1D)), ((V)(y_485))), ((V)(y_485))));
i_483++;
}
}
sideIn_468 = Fn((V _arrowThis494, int _argc486, V P_492, V sg_493, V _a490, V _a491, V[] _rest487) => {
return Invoke(P_492, "map", Fn((V _arrowThis506, int _argc495, V _a497, V _a498, V _a499, V _a500, V[] _rest496) => {
V x_503 = default;
V y_505 = default;
{ V _t501 = ListOf(_a497);
{ V _t502 = GetIdx(_t501, 0D);
x_503 = _t502; }
{ V _t504 = GetIdx(_t501, 1D);
y_505 = _t504; }
}
return Arr(Add(x_503, ((V)(((ToNum(sg_493) * ToNum(Call(w_465, V.Undef, y_505))) * 1.6)))), y_505);
}, 1, "", true));
}, 2, "", true);
back_469 = ((V)(JsStrBuf.Begin().S("M").V(Call(f1_20, V.Undef, Get(G_459, "ins"))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_459, "H")) - ToNum(Call(w_465, V.Undef, Get(G_459, "H")))))))).S("H").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_459, "W")) - ToNum(Get(G_459, "ins"))))))).S("V").V(Get(G_459, "H")).S("H").V(Call(f1_20, V.Undef, Get(G_459, "ins"))).S("Z").End()));
sl_470 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(L_466, "map", P2_24), "join", ((V)("L")))).S("L").V(Invoke(Invoke(Invoke(Call(sideIn_468, V.Undef, L_466, ((V)(1D))), "reverse"), "map", P2_24), "join", ((V)("L")))).S("Z").End()));
sr_471 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(R_467, "map", P2_24), "join", ((V)("L")))).S("L").V(Invoke(Invoke(Invoke(Call(sideIn_468, V.Undef, R_467, ((V)((-1D)))), "reverse"), "map", P2_24), "join", ((V)("L")))).S("Z").End()));
lipB_472 = ((V)(JsStrBuf.Begin().S("M").V(Call(f1_20, V.Undef, Add(Get(G_459, "ins"), ((V)((ToNum(Call(w_465, V.Undef, Get(G_459, "H"))) * 1.6)))))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_459, "H")) - ToNum(Call(w_465, V.Undef, Get(G_459, "H")))))))).S("H").V(Call(f1_20, V.Undef, ((V)(((ToNum(Get(G_459, "W")) - ToNum(Get(G_459, "ins"))) - (ToNum(Call(w_465, V.Undef, Get(G_459, "H"))) * 1.6)))))).End()));
lipL_473 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Call(sideIn_468, V.Undef, L_466, ((V)(1D))), "map", P2_24), "join", ((V)("L")))).End()));
lipR_474 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Call(sideIn_468, V.Undef, R_467, ((V)((-1D)))), "map", P2_24), "join", ((V)("L")))).End()));
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(back_469).S("\" fill=\"").V(col_461).S("\"/><path d=\"").V(sl_470).S("\" fill=\"").V(Call(shade_11, V.Undef, col_461, ((V)(0.88)))).S("\"/><path d=\"").V(sr_471).S("\" fill=\"").V(Call(shade_11, V.Undef, col_461, ((V)(0.8)))).S("\"/>").S("<path d=\"").V(lipB_472).V(lipL_473).V(lipR_474).S("\" stroke=\"").V(Call(shade_11, V.Undef, col_461, ((V)(1.4)))).S("\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.8 * ToNum(Get(G_459, "s"))))))).S("\" fill=\"none\"/>").V((ex_462 is var _t507 && Truthy(_t507) ? _t507 : ((V)("")))).End()));
return default;
}, 4, "", true);
light_33 = Fn((V _arrowThis517, int _argc508, V G_514, V a_515, V b_516, V _a513, V[] _rest509) => {
return ((V)(JsStrBuf.Begin().S("<defs><linearGradient id=\"csh\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#000000\" stop-opacity=\"").V(a_515).S("\"/><stop offset=\"0.7\" stop-color=\"#000000\" stop-opacity=\"0\"/><stop offset=\"0.92\" stop-color=\"#ffffff\" stop-opacity=\"").V((b_516 is var _t518 && Truthy(_t518) ? _t518 : ((V)(0.05)))).S("\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient></defs><path d=\"").V(Get(G_514, "tr")).S("\" fill=\"url(#csh)\"/>").End()));
}, 3, "", true);
doc_34 = Fn((V _arrowThis527, int _argc519, V G_525, V body_526, V _a523, V _a524, V[] _rest520) => {
return ((V)(JsStrBuf.Begin().S("<defs><clipPath id=\"ctc\"><path d=\"").V(Get(G_525, "tr")).S("\"/></clipPath>").V(Invoke(G_525, "b", ((V)(1D)))).V(Invoke(G_525, "b", ((V)(3D)))).V(Invoke(G_525, "b", ((V)(6D)))).S("</defs><g clip-path=\"url(#ctc)\">").V(body_526).S("</g>").End()));
}, 2, "", true);
WALLC_40 = NewObj(5).Put("pipes", ((V)("#c5c3bc"))).Put("tile", ((V)("#4a4e57"))).Put("coffer", ((V)("#951e33"))).Put("sky", ((V)("#704329"))).Put("neb", ((V)("#27223a"))).V;
CBASE_41 = NewObj(5).Put("pipes", Arr(((V)("#7c6852")), ((V)("#a07c52")))).Put("tile", Arr(((V)("#26282d")), ((V)("#9aa0a6")))).Put("coffer", Arr(((V)("#3e2416")), ((V)("#4a2b1a")))).Put("sky", Arr(((V)("#0b0e26")), ((V)("#5e3722")))).Put("neb", Arr(((V)("#0a0818")), ((V)("#0e0b1e")))).V;
CEIL14_42 = NewObj(5).Put("pipes", cPipes_35).Put("tile", cTile_36).Put("coffer", cCoffer_37).Put("sky", cSky_38).Put("neb", cNeb_39).V;
cardOf_43 = Fn((V _arrowThis535, int _argc528, V k_534, V _a531, V _a532, V _a533, V[] _rest529) => {
V G_536 = default;
V w_537 = default;
G_536 = Call(mk_31, V.Undef, Get(FRM_30, "card"));
w_537 = GetK(WALLC_40, k_534);
return ((V)(JsStrBuf.Begin().S("<path d=\"M16 26H64V56H16Z\" fill=\"").V(w_537).S("\"/><path d=\"M0 0L16 26V56H0Z\" fill=\"").V(Call(shade_11, V.Undef, w_537, ((V)(0.88)))).S("\"/><path d=\"M80 0L64 26V56H80Z\" fill=\"").V(Call(shade_11, V.Undef, w_537, ((V)(0.8)))).S("\"/><path d=\"M16 26V56M64 26V56\" stroke=\"#000000\" stroke-opacity=\"0.2\" stroke-width=\"0.6\"/>").V(Call(doc_34, V.Undef, G_536, InvokeK(CEIL14_42, k_534, G_536))).S("<path d=\"").V(Get(G_536, "tr")).S("\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.25\" stroke-width=\"0.5\"/>").End()));
return default;
}, 1, "", true);
DEF14_44 = ((V)(JsStrBuf.Begin().V(DEF11_25).S("<filter id=\"l14b1\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"0.8\"/></filter><filter id=\"l14b3\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"3\"/></filter>").S("<radialGradient id=\"l14w\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff0c0\" stop-opacity=\"0.85\"/><stop offset=\"0.35\" stop-color=\"#ffd27a\" stop-opacity=\"0.35\"/><stop offset=\"1\" stop-color=\"#ffc060\" stop-opacity=\"0\"/></radialGradient>").End()));
glow_45 = Fn((V _arrowThis549, int _argc538, V C_544, V q_545, V r_546, V op_547, V[] _rest539) => {
V c_550 = default;
V A_548 = default;
A_548 = (_argc538 > 4 ? _rest539[0] : V.Undef);
c_550 = Invoke(C_544, "P", q_545);
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(c_550, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(c_550, 1D))), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(r_546) * ToNum(Get(C_544, "k"))))))), "\" fill=\"url(#l14w)\" opacity=\"", ToStr(op_547), "\">", ToStr((A_548 is var _t551 && Truthy(_t551) ? _t551 : ((V)("")))), "</circle>")));
return default;
}, 5, "", true);
ring_46 = Fn((V _arrowThis564, int _argc552, V C_558, V y_559, V r_560, V a0_561, V[] _rest553) => {
V a1_562 = default;
V n_563 = default;
a1_562 = (_argc552 > 4 ? _rest553[0] : V.Undef);
n_563 = (_argc552 > 5 ? _rest553[1] : V.Undef);
return Call(rep_22, V.Undef, Add(n_563, ((V)(1D))), Fn((V _arrowThis572, int _argc565, V i_571, V _a568, V _a569, V _a570, V[] _rest566) => {
V a_573 = default;
a_573 = Add(a0_561, ((V)((((ToNum(a1_562) - ToNum(a0_561)) * ToNum(i_571)) / ToNum(n_563)))));
return Invoke(C_558, "p", ((V)((ToNum(r_560) * FdLibm.Sin(ToNum(a_573))))), y_559, ((V)((ToNum(r_560) * FdLibm.Cos(ToNum(a_573))))));
return default;
}, 1, "", true));
}, 6, "", true);
swing_47 = Fn((V _arrowThis585, int _argc574, V C_580, V q_581, V deg_582, V T_583, V[] _rest575) => {
V c_586 = default;
V b_584 = default;
b_584 = (_argc574 > 4 ? _rest575[0] : V.Undef);
c_586 = Invoke(C_580, "P", q_581);
return ((V)(string.Concat("<animateTransform attributeName=\"transform\" type=\"rotate\" values=\"", NumStr((-ToNum(deg_582))), " ", ToStr(Call(P2_24, V.Undef, c_586)), ";", ToStr(deg_582), " ", ToStr(Call(P2_24, V.Undef, c_586)), ";", NumStr((-ToNum(deg_582))), " ", ToStr(Call(P2_24, V.Undef, c_586)), "\" dur=\"", ToStr(Call(n4_21, V.Undef, T_583)), "s\" begin=\"", ToStr(Call(n4_21, V.Undef, (b_584 is var _t587 && Truthy(_t587) ? _t587 : ((V)(0D))))), "s\" repeatCount=\"indefinite\"", ToStr(Call(SPL_19, V.Undef, ((V)(2D)))), "/>")));
return default;
}, 5, "", true);
FLK_48 = Fn((V _arrowThis596, int _argc588, V T_594, V b_595, V _a592, V _a593, V[] _rest589) => {
return Call(an_17, V.Undef, ((V)("opacity")), ((V)("1;0.9;1;0.72;1;1")), T_594, b_595, ((V)(" keyTimes=\"0;0.3;0.45;0.5;0.56;1\"")));
}, 2, "", true);
Set(N_12, "bulb14", Fn((V _arrowThis604, int _argc597, V S_603, V _a600, V _a601, V _a602, V[] _rest598) => {
double T_605 = 0;
V D_606 = default;
T_605 = 46D;
D_606 = NewObj(4).Put("w", ((V)(16D))).Put("d", ((V)(16D))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis613, int _argc607, V _a609, V _a610, V _a611, V _a612, V[] _rest608) => {
return Arr();
}, 0, "build", true)).V;
Set(D_606, "fx", Fn((V _arrowThis621, int _argc614, V ctx_620, V _a617, V _a618, V _a619, V[] _rest615) => {
V C_622 = default;
V b_623 = default;
V k_624 = default;
V chain_625 = default;
V fil_626 = default;
V s_627 = default;
C_622 = Call(cam_15, V.Undef, ctx_620);
b_623 = Invoke(C_622, "P", Arr(((V)(0D)), ((V)(9.5)), ((V)(0D))));
k_624 = Get(C_622, "k");
chain_625 = Add(Invoke(Call(rep_22, V.Undef, ((V)(9D)), Fn((V _arrowThis635, int _argc628, V i_634, V _a631, V _a632, V _a633, V[] _rest629) => {
V q_636 = default;
q_636 = Invoke(C_622, "p", ((V)((1.3 + (ToNum(i_634) * 0.05)))), ((V)((16D - (ToNum(i_634) * 1.15)))), ((V)(0.6)));
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(q_636, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(q_636, 1D))), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.36 * ToNum(k_624)))))), "\" fill=\"#b9b2a2\" stroke=\"#6e685c\" stroke-width=\"0.2\"/>")));
return default;
}, 1, "", true)), "join", ((V)(""))), Call(Fn((V _arrowThis644, int _argc637, V q_643, V _a640, V _a641, V _a642, V[] _rest638) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(q_643, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(q_643, 1D))), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.8 * ToNum(k_624)))))), "\" fill=\"#d8cfbc\" stroke=\"#6e685c\" stroke-width=\"0.25\"/>")));
}, 1, "", true), V.Undef, Invoke(C_622, "p", ((V)(1.75)), ((V)(5.2)), ((V)(0.6)))));
fil_626 = ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_623, 0D)) - (1.2 * ToNum(k_624))))))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(b_623, 1D), ((V)((1.8 * ToNum(k_624))))))), "L", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_623, 0D)) - (0.8 * ToNum(k_624))))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_623, 1D)) - (0.6 * ToNum(k_624))))))), "Q", ToStr(Call(f1_20, V.Undef, GetIdx(b_623, 0D))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_623, 1D)) - (1.6 * ToNum(k_624))))))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(b_623, 0D), ((V)((0.8 * ToNum(k_624))))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_623, 1D)) - (0.6 * ToNum(k_624))))))), "L", ToStr(Call(f1_20, V.Undef, Add(GetIdx(b_623, 0D), ((V)((1.2 * ToNum(k_624))))))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(b_623, 1D), ((V)((1.8 * ToNum(k_624))))))), "\" stroke=\"#ff9a2a\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.35 * ToNum(k_624)))))), "\" fill=\"none\"/><path d=\"M", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_623, 0D)) - (0.8 * ToNum(k_624))))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_623, 1D)) - (0.6 * ToNum(k_624))))))), "Q", ToStr(Call(f1_20, V.Undef, GetIdx(b_623, 0D))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_623, 1D)) - (1.6 * ToNum(k_624))))))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(b_623, 0D), ((V)((0.8 * ToNum(k_624))))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_623, 1D)) - (0.6 * ToNum(k_624))))))), "\" stroke=\"#fff6d0\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.18 * ToNum(k_624)))))), "\" fill=\"none\"/>")));
s_627 = Call(cyl3_28, V.Undef, C_622, Arr(((V)(0D)), ((V)((T_605 - 2D))), ((V)(0D))), Arr(((V)(0D)), ((V)(T_605)), ((V)(0D))), ((V)(3.2)), ((V)("#efe8d8")));
s_627 = ((V)(JsStrBuf.Begin().V(s_627).S(string.Concat("<g>", ToStr(Call(swing_47, V.Undef, C_622, Arr(((V)(0D)), ((V)((T_605 - 2D))), ((V)(0D))), ((V)(2.6)), ((V)(4.6)))), ToStr(Call(glow_45, V.Undef, C_622, Arr(((V)(0D)), ((V)(9.5)), ((V)(0D))), ((V)(17D)), ((V)(0.9)), Call(FLK_48, V.Undef, ((V)(5.2))))))).V(Call(cyl3_28, V.Undef, C_622, Arr(((V)(0D)), ((V)((T_605 - 2D))), ((V)(0D))), Arr(((V)(0D)), ((V)(20D)), ((V)(0D))), ((V)(0.4)), ((V)("#2c2622")))).V(Call(cyl3_28, V.Undef, C_622, Arr(((V)(0D)), ((V)(20D)), ((V)(0D))), Arr(((V)(0D)), ((V)(15D)), ((V)(0D))), ((V)(1.8)), ((V)("#ddd5c4")))).V(Call(cyl3_28, V.Undef, C_622, Arr(((V)(0D)), ((V)(15D)), ((V)(0D))), Arr(((V)(0D)), ((V)(12.6)), ((V)(0D))), ((V)(1.15)), ((V)("#c9a85a")))).S(string.Concat("<g>", ToStr(Call(swing_47, V.Undef, C_622, Arr(((V)(1.3)), ((V)(16D)), ((V)(0.6))), ((V)(6D)), ((V)(2.3)), ((V)((-0.6))))), ToStr(chain_625), "</g>")).V(Call(sph_29, V.Undef, C_622, Arr(((V)(0D)), ((V)(9.5)), ((V)(0D))), ((V)(3.6)), ((V)("#fff1b8")), NewObj(1).Put("op", ((V)(0.92))).V)).S(string.Concat("<g>", ToStr(Call(FLK_48, V.Undef, ((V)(5.2)))), ToStr(fil_626), "</g>")).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_623, 0D)) - (1.3 * ToNum(k_624))))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(b_623, 1D)) - (1.4 * ToNum(k_624))))))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.9 * ToNum(k_624)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.6 * ToNum(k_624)))))), "\" fill=\"#ffffff\" opacity=\"0.8\"/></g>")).End()));
return NewObj(3).Put("defs", DEF14_44).Put("front", s_627).Put("bb", Invoke(C_622, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_606;
return default;
}, 1, "", true));
Set(N_12, "track14", Fn((V _arrowThis652, int _argc645, V S_651, V _a648, V _a649, V _a650, V[] _rest646) => {
double T_653 = 0;
V HX_654 = default;
V D_655 = default;
T_653 = 34D;
HX_654 = Arr(((V)((-27D))), ((V)((-9D))), ((V)(9D)), ((V)(27D)));
D_655 = NewObj(4).Put("w", ((V)(84D))).Put("d", ((V)(14D))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis662, int _argc656, V _a658, V _a659, V _a660, V _a661, V[] _rest657) => {
return Arr();
}, 0, "build", true)).V;
Set(D_655, "fx", Fn((V _arrowThis670, int _argc663, V ctx_669, V _a666, V _a667, V _a668, V[] _rest664) => {
V C_671 = default;
V k_672 = default;
JsStrBuf s_673 = null;
JsStrBuf beams_674 = null;
C_671 = Call(cam_15, V.Undef, ctx_669);
k_672 = Get(C_671, "k");
s_673 = new JsStrBuf("");
beams_674 = new JsStrBuf("");
Invoke(Arr(((V)((-30D))), ((V)(30D))), "forEach", Fn((V _arrowThis682, int _argc675, V x_681, V _a678, V _a679, V _a680, V[] _rest676) => {
return ((V)(s_673.V(Add(Call(cyl3_28, V.Undef, C_671, Arr(x_681, ((V)((T_653 - 0.6))), ((V)(0D))), Arr(x_681, ((V)(T_653)), ((V)(0D))), ((V)(2.2)), ((V)("#2a2b30"))), Call(cyl3_28, V.Undef, C_671, Arr(x_681, ((V)((T_653 - 5D))), ((V)(0D))), Arr(x_681, ((V)((T_653 - 0.6))), ((V)(0D))), ((V)(0.55)), ((V)("#3a3c42"))))).Str));
}, 1, "", true));
s_673.V(Call(box3_27, V.Undef, C_671, NewObj(6).Put("c", Arr(((V)(0D)), ((V)((T_653 - 7.6))), ((V)(0D)))).Put("w", ((V)(82D))).Put("h", ((V)(2.6))).Put("d", ((V)(3.2))).Put("r", ((V)(0.6))).Put("col", ((V)("#1d1e22"))).V)).S(string.Concat("<path d=\"M", ToStr(Call(P2_24, V.Undef, Invoke(C_671, "p", ((V)((-40D))), ((V)((T_653 - 6.2))), ((V)(1.62))))), "L", ToStr(Call(P2_24, V.Undef, Invoke(C_671, "p", ((V)(40D)), ((V)((T_653 - 6.2))), ((V)(1.62))))), "\" stroke=\"#ffffff\" stroke-opacity=\"0.22\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.4 * ToNum(k_672)))))), "\"/>"));
Invoke(HX_654, "forEach", Fn((V _arrowThis691, int _argc683, V x_689, V i_690, V _a687, V _a688, V[] _rest684) => {
double dx_692 = 0;
V L_693 = default;
V id_694 = default;
V F_695 = default;
V dim_696 = default;
dx_692 = (ToNum(x_689) * 0.12);
L_693 = Invoke(C_671, "P", Arr(Add(x_689, ((V)(dx_692))), ((V)((T_653 - 14.4))), ((V)(4.2))));
id_694 = Invoke(C_671, "u", ((V)("tb")));
F_695 = Arr(Invoke(C_671, "p", ((V)((ToNum(Add(x_689, ((V)((dx_692 * 4D))))) - 12D))), ((V)((-30D))), ((V)(34D))), Invoke(C_671, "p", Add(Add(x_689, ((V)((dx_692 * 4D)))), ((V)(12D))), ((V)((-30D))), ((V)(34D))));
dim_696 = Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.55;1;0.55")), ((V)(6D)), ((V)(((-ToNum(i_690)) * 1.5))), Call(SPL_19, V.Undef, ((V)(2D))));
beams_674.S(string.Concat("<defs><linearGradient id=\"", ToStr(id_694), "\" gradientUnits=\"userSpaceOnUse\" x1=\"", ToStr(Call(f1_20, V.Undef, GetIdx(L_693, 0D))), "\" y1=\"", ToStr(Call(f1_20, V.Undef, GetIdx(L_693, 1D))), "\" x2=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Add(GetIdx(GetIdx(F_695, 0D), 0D), GetIdx(GetIdx(F_695, 1D), 0D))) / 2D))))), "\" y2=\"", ToStr(Call(f1_20, V.Undef, GetIdx(GetIdx(F_695, 0D), 1D))), "\"><stop offset=\"0\" stop-color=\"#ffe2a8\" stop-opacity=\"0.5\"/><stop offset=\"1\" stop-color=\"#ffd690\" stop-opacity=\"0\"/></linearGradient></defs><g>", ToStr(Call(swing_47, V.Undef, C_671, Arr(x_689, ((V)((T_653 - 9D))), ((V)(0D))), ((V)(5D)), Add(((V)(9D)), i_690), ((V)(((-ToNum(i_690)) * 2D))))), "<g>", ToStr(dim_696), "<path d=\"M", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(L_693, 0D)) - (1.6 * ToNum(k_672))))))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(L_693, 1D))), "L", ToStr(Call(P2_24, V.Undef, GetIdx(F_695, 0D))), "L", ToStr(Call(P2_24, V.Undef, GetIdx(F_695, 1D))), "L", ToStr(Call(f1_20, V.Undef, Add(GetIdx(L_693, 0D), ((V)((1.6 * ToNum(k_672))))))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(L_693, 1D))), "Z\" fill=\"url(#", ToStr(id_694), ")\"/></g></g>"));
s_673.S(string.Concat("<g>", ToStr(Call(swing_47, V.Undef, C_671, Arr(x_689, ((V)((T_653 - 9D))), ((V)(0D))), ((V)(5D)), Add(((V)(9D)), i_690), ((V)(((-ToNum(i_690)) * 2D))))))).V(Call(cyl3_28, V.Undef, C_671, Arr(x_689, ((V)((T_653 - 7.6))), ((V)(0D))), Arr(x_689, ((V)((T_653 - 10D))), ((V)(0D))), ((V)(0.6)), ((V)("#2a2b30")))).V(Call(cyl3_28, V.Undef, C_671, Arr(((V)((ToNum(x_689) - (dx_692 * 0.2)))), ((V)((T_653 - 10.4))), ((V)((-2.2)))), Arr(Add(x_689, ((V)(dx_692))), ((V)((T_653 - 14.4))), ((V)(4.2))), ((V)(2.3)), ((V)("#1b1c20")), NewObj(2).Put("mat", ((V)("gloss"))).Put("cap", Fn((V _arrowThis704, int _argc697, V cr_703, V _a700, V _a701, V _a702, V[] _rest698) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(cr_703) * 0.8))))), "\" fill=\"#fff2cc\"/><circle r=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(cr_703) * 0.45))))), "\" fill=\"#ffffff\"/>")));
}, 1, "cap", true)).V)).S(string.Concat("<g>", ToStr(dim_696), ToStr(Call(glow_45, V.Undef, C_671, Arr(Add(x_689, ((V)(dx_692))), ((V)((T_653 - 14.6))), ((V)(4.6))), ((V)(5D)), ((V)(0.8)))), "</g></g>"));
return default;
}, 2, "", true));
return NewObj(3).Put("defs", DEF14_44).Put("front", ((V)(string.Concat(beams_674.Str, s_673.Str)))).Put("bb", Invoke(C_671, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_655;
return default;
}, 1, "", true));
Set(N_12, "flush14", Fn((V _arrowThis712, int _argc705, V S_711, V _a708, V _a709, V _a710, V[] _rest706) => {
double T_713 = 0;
V GD_714 = default;
V D_715 = default;
T_713 = 14D;
GD_714 = ((V)("#c9a04a"));
D_715 = NewObj(4).Put("w", ((V)(34D))).Put("d", ((V)(34D))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis722, int _argc716, V _a718, V _a719, V _a720, V _a721, V[] _rest717) => {
return Arr();
}, 0, "build", true)).V;
Set(D_715, "fx", Fn((V _arrowThis730, int _argc723, V ctx_729, V _a726, V _a727, V _a728, V[] _rest724) => {
V C_731 = default;
JsStrBuf s_732 = null;
V TI_733 = default;
V m_734 = default;
C_731 = Call(cam_15, V.Undef, ctx_729);
s_732 = new JsStrBuf("");
TI_733 = Arr(Arr(((V)((T_713 - 1.2))), ((V)((T_713 - 4.4))), ((V)(13.6)), ((V)(12.4))), Arr(((V)((T_713 - 5.2))), ((V)((T_713 - 8D))), ((V)(11D)), ((V)(8.6))), Arr(((V)((T_713 - 8.8))), ((V)((T_713 - 10.8))), ((V)(7.4)), ((V)(4.2))));
s_732.V(Add(Call(glow_45, V.Undef, C_731, Arr(((V)(0D)), ((V)(T_713)), ((V)(0D))), ((V)(34D)), ((V)(0.6)), Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.45;0.75;0.45")), ((V)(5D)), ((V)(0D)), Call(SPL_19, V.Undef, ((V)(2D))))), Call(cyl3_28, V.Undef, C_731, Arr(((V)(0D)), ((V)((T_713 - 1.2))), ((V)(0D))), Arr(((V)(0D)), ((V)(T_713)), ((V)(0D))), ((V)(15D)), GD_714, NewObj(1).Put("mat", ((V)("gloss"))).V)));
Invoke(TI_733, "forEach", Fn((V _arrowThis751, int _argc735, V _a737, V i_741, V _a739, V _a740, V[] _rest736) => {
V y0_744 = default;
V y1_746 = default;
V r0_748 = default;
V r1_750 = default;
{ V _t742 = ListOf(_a737);
{ V _t743 = GetIdx(_t742, 0D);
y0_744 = _t743; }
{ V _t745 = GetIdx(_t742, 1D);
y1_746 = _t745; }
{ V _t747 = GetIdx(_t742, 2D);
r0_748 = _t747; }
{ V _t749 = GetIdx(_t742, 3D);
r1_750 = _t749; }
}
s_732.V(Call(cyl3_28, V.Undef, C_731, Arr(((V)(0D)), y0_744, ((V)(0D))), Arr(((V)(0D)), y1_746, ((V)(0D))), r0_748, ((V)("#f6f0e2")), NewObj(2).Put("r2", r1_750).Put("op", ((V)(0.96))).V));
s_732.V(Invoke(Call(rep_22, V.Undef, ((V)(9D)), Fn((V _arrowThis759, int _argc752, V j_758, V _a755, V _a756, V _a757, V[] _rest753) => {
V a_760 = default;
V p_761 = default;
V q_762 = default;
a_760 = Add(Get(C_731, "thV"), ((V)(((ToNum(j_758) - 4D) * 0.3))));
p_761 = Invoke(C_731, "p", ((V)((ToNum(r0_748) * FdLibm.Sin(ToNum(a_760))))), y0_744, ((V)((ToNum(r0_748) * FdLibm.Cos(ToNum(a_760))))));
q_762 = Invoke(C_731, "p", ((V)((ToNum(r1_750) * FdLibm.Sin(ToNum(a_760))))), y1_746, ((V)((ToNum(r1_750) * FdLibm.Cos(ToNum(a_760))))));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(P2_24, V.Undef, p_761)), "L", ToStr(Call(P2_24, V.Undef, q_762)), "\" stroke=\"#d6c7a6\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.22 * ToNum(Get(C_731, "k"))))))), "\"/>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
if (LtN(i_741, 2D)) {
s_732.V(Call(cyl3_28, V.Undef, C_731, Arr(((V)(0D)), y1_746, ((V)(0D))), Arr(((V)(0D)), ((V)((ToNum(y1_746) - 0.8))), ((V)(0D))), r1_750, GD_714, NewObj(1).Put("mat", ((V)("gloss"))).V));
}
return default;
}, 2, "", true));
m_734 = Invoke(C_731, "P", Arr(((V)(0D)), ((V)((T_713 - 6D))), ((V)(0D))));
s_732.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(m_734, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(m_734, 1D))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((9D * ToNum(Get(C_731, "k"))))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((3.4 * ToNum(Get(C_731, "k"))))))), "\" fill=\"#fff6d8\" opacity=\"0.5\" filter=\"url(#l14b1)\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.35;0.6;0.35")), ((V)(5D)), ((V)(0D)), Call(SPL_19, V.Undef, ((V)(2D))))), "</ellipse>")).V(Call(sph_29, V.Undef, C_731, Arr(((V)(0D)), ((V)((T_713 - 12D))), ((V)(0D))), ((V)(1.4)), GD_714));
return NewObj(3).Put("defs", DEF14_44).Put("front", ((V)(s_732.Str))).Put("bb", Invoke(C_731, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_715;
return default;
}, 1, "", true));
Set(N_12, "chand14", Fn((V _arrowThis770, int _argc763, V S_769, V _a766, V _a767, V _a768, V[] _rest764) => {
double T_771 = 0;
V GD_772 = default;
V D_773 = default;
T_771 = 60D;
GD_772 = ((V)("#c9a04a"));
D_773 = NewObj(4).Put("w", ((V)(50D))).Put("d", ((V)(50D))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis780, int _argc774, V _a776, V _a777, V _a778, V _a779, V[] _rest775) => {
return Arr();
}, 0, "build", true)).V;
Set(D_773, "fx", Fn((V _arrowThis788, int _argc781, V ctx_787, V _a784, V _a785, V _a786, V[] _rest782) => {
V C_789 = default;
V k_790 = default;
V v_791 = default;
JsStrBuf top_792 = null;
V L_793 = default;
V ch_794 = default;
double R1_795 = 0;
double Y1_796 = 0;
double R2_797 = 0;
double Y2_798 = 0;
V fr_799 = default;
V rp_800 = default;
V back_801 = default;
V ringB_802 = default;
V ringF_803 = default;
V cand_804 = default;
V drop_805 = default;
V isF_806 = default;
V Lb_807 = default;
V Lf_808 = default;
V arms_809 = default;
V body_810 = default;
C_789 = Call(cam_15, V.Undef, ctx_787);
k_790 = Get(C_789, "k");
v_791 = Get(C_789, "v");
top_792 = new JsStrBuf("");
L_793 = Arr();
top_792.V(Add(Call(cyl3_28, V.Undef, C_789, Arr(((V)(0D)), ((V)((T_771 - 1.6))), ((V)(0D))), Arr(((V)(0D)), ((V)(T_771)), ((V)(0D))), ((V)(4.4)), GD_772, NewObj(1).Put("mat", ((V)("gloss"))).V), Call(box3_27, V.Undef, C_789, NewObj(6).Put("c", Arr(((V)(0D)), ((V)((T_771 - 6D))), ((V)(0D)))).Put("w", ((V)(5D))).Put("h", ((V)(4.4))).Put("d", ((V)(5D))).Put("r", ((V)(0.8))).Put("col", ((V)("#7a5a24"))).V)));
{
V q_811 = default;
q_811 = Invoke(C_789, "p", ((V)(0D)), ((V)((T_771 - 4D))), ((V)(2.55)));
top_792.S(string.Concat("<circle cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(q_811, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(q_811, 1D))), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.45 * ToNum(k_790)))))), "\" fill=\"#6fe39a\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("1;0.2;1")), ((V)(1.6)))), "</circle>"));
}
ch_794 = Invoke(Call(rep_22, V.Undef, ((V)(10D)), Fn((V _arrowThis819, int _argc812, V i_818, V _a815, V _a816, V _a817, V[] _rest813) => {
V q_820 = default;
q_820 = Invoke(C_789, "p", ((V)(0D)), ((V)(((T_771 - 6.6) - (ToNum(i_818) * 1.9)))), ((V)(0D)));
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(q_820, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(q_820, 1D))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)(((NumTruthy((ToNum(i_818) % 2D)) ? 0.35 : 0.7) * ToNum(k_790)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((1.05 * ToNum(k_790)))))), "\" fill=\"none\" stroke=\"", ToStr(GD_772), "\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.35 * ToNum(k_790)))))), "\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")));
R1_795 = 20D;
Y1_796 = 22D;
R2_797 = 11D;
Y2_798 = 30D;
fr_799 = Fn((V _arrowThis828, int _argc821, V a_827, V _a824, V _a825, V _a826, V[] _rest822) => {
return ((((FdLibm.Sin(ToNum(a_827)) * ToNum(GetIdx(v_791, 0D))) + (FdLibm.Cos(ToNum(a_827)) * ToNum(GetIdx(v_791, 2D)))) > 0D) ? V.True : V.False);
}, 1, "", true);
rp_800 = Fn((V _arrowThis837, int _argc829, V P_835, V w_836, V _a833, V _a834, V[] _rest830) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(P_835, "map", P2_24), "join", ((V)("L")))), "\" stroke=\"", ToStr(GD_772), "\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(w_836) * ToNum(k_790)))))), "\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Invoke(Invoke(P_835, "map", P2_24), "join", ((V)("L")))), "\" stroke=\"#fff0b8\" stroke-opacity=\"0.5\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)(((ToNum(w_836) * 0.3) * ToNum(k_790)))))), "\" fill=\"none\" transform=\"translate(0 ", ToStr(Call(f1_20, V.Undef, ((V)((((-ToNum(w_836)) * 0.25) * ToNum(k_790)))))), ")\"/>")));
}, 2, "", true);
back_801 = Add(Get(C_789, "thV"), ((V)(PI_13)));
ringB_802 = Fn((V _arrowThis847, int _argc838, V r_844, V y_845, V w_846, V _a843, V[] _rest839) => {
return Call(rp_800, V.Undef, Call(ring_46, V.Undef, C_789, y_845, r_844, ((V)((ToNum(back_801) - (PI_13 / 2D)))), Add(back_801, ((V)((PI_13 / 2D)))), ((V)(24D))), w_846);
}, 3, "", true);
ringF_803 = Fn((V _arrowThis857, int _argc848, V r_854, V y_855, V w_856, V _a853, V[] _rest849) => {
return Call(rp_800, V.Undef, Call(ring_46, V.Undef, C_789, y_855, r_854, ((V)((ToNum(Get(C_789, "thV")) - (PI_13 / 2D)))), Add(Get(C_789, "thV"), ((V)((PI_13 / 2D)))), ((V)(24D))), w_856);
}, 3, "", true);
cand_804 = Fn((V _arrowThis868, int _argc858, V r_864, V y_865, V a_866, V i_867, V[] _rest859) => {
double x_869 = 0;
double z_870 = 0;
V f_871 = default;
x_869 = (ToNum(r_864) * FdLibm.Sin(ToNum(a_866)));
z_870 = (ToNum(r_864) * FdLibm.Cos(ToNum(a_866)));
f_871 = Invoke(C_789, "P", Arr(((V)(x_869)), Add(y_865, ((V)(5.4))), ((V)(z_870))));
return ((V)(JsStrBuf.Begin().V(Add(Add(Call(cyl3_28, V.Undef, C_789, Arr(((V)(x_869)), y_865, ((V)(z_870))), Arr(((V)(x_869)), Add(y_865, ((V)(0.6))), ((V)(z_870))), ((V)(1.5)), GD_772, NewObj(1).Put("mat", ((V)("gloss"))).V), Call(cyl3_28, V.Undef, C_789, Arr(((V)(x_869)), Add(y_865, ((V)(0.6))), ((V)(z_870))), Arr(((V)(x_869)), Add(y_865, ((V)(4.4))), ((V)(z_870))), ((V)(0.85)), ((V)("#f6efe0")))), Call(glow_45, V.Undef, C_789, Arr(((V)(x_869)), Add(y_865, ((V)(5.4))), ((V)(z_870))), ((V)(5D)), ((V)(0.8)), Call(FLK_48, V.Undef, ((V)((3D + ((ToNum(i_867) % 3D) * 0.7)))), ((V)(((-ToNum(i_867)) * 0.4))))))).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(f_871, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(f_871, 1D))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.75 * ToNum(k_790)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((1.25 * ToNum(k_790)))))), "\" fill=\"#fff0c0\"/>")).End()));
return default;
}, 4, "", true);
drop_805 = Fn((V _arrowThis882, int _argc872, V r_878, V y_879, V a_880, V i_881, V[] _rest873) => {
double x_883 = 0;
double z_884 = 0;
V q_885 = default;
V h_886 = default;
double w_887 = 0;
double hh_888 = 0;
x_883 = (ToNum(r_878) * FdLibm.Sin(ToNum(a_880)));
z_884 = (ToNum(r_878) * FdLibm.Cos(ToNum(a_880)));
q_885 = Invoke(C_789, "P", Arr(((V)(x_883)), ((V)((ToNum(y_879) - 3.4))), ((V)(z_884))));
h_886 = Invoke(C_789, "P", Arr(((V)(x_883)), y_879, ((V)(z_884))));
w_887 = (1D * ToNum(k_790));
hh_888 = (1.8 * ToNum(k_790));
return ((V)(string.Concat(string.Concat("<path d=\"M", ToStr(Call(P2_24, V.Undef, h_886)), "L", ToStr(Call(f1_20, V.Undef, GetIdx(q_885, 0D))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q_885, 1D)) - hh_888))))), "\" stroke=\"#d9e8ee\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.15 * ToNum(k_790)))))), "\"/><path d=\"M", ToStr(Call(f1_20, V.Undef, GetIdx(q_885, 0D))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q_885, 1D)) - hh_888))))), "L", ToStr(Call(f1_20, V.Undef, Add(GetIdx(q_885, 0D), ((V)(w_887))))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(q_885, 1D))), "L", ToStr(Call(f1_20, V.Undef, GetIdx(q_885, 0D))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(q_885, 1D), ((V)((hh_888 * 1.4)))))), "L", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q_885, 0D)) - w_887))))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(q_885, 1D))), "Z\" fill=\"#dff3ff\" stroke=\"#9cc6d8\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.15 * ToNum(k_790)))))), "\" opacity=\"0.9\"/>"), string.Concat("<circle cx=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q_885, 0D)) - (w_887 * 0.3)))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q_885, 1D)) - (hh_888 * 0.3)))))), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.55 * ToNum(k_790)))))), "\" fill=\"#ffffff\" opacity=\"0\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0;0;1;0;0")), ((V)((2.6 + ((ToNum(i_881) % 5D) * 0.5)))), ((V)(((-ToNum(i_881)) * 0.37))), ((V)(" keyTimes=\"0;0.6;0.7;0.8;1\"")))), "</circle>"))));
return default;
}, 4, "", true);
Call(rep_22, V.Undef, ((V)(8D)), Fn((V _arrowThis896, int _argc889, V i_895, V _a892, V _a893, V _a894, V[] _rest890) => {
double a_897 = 0;
a_897 = (((ToNum(i_895) * PI_13) / 4D) + (PI_13 / 8D));
Invoke(L_793, "push", NewObj(2).Put("q", Arr(((V)((R1_795 * FdLibm.Sin(a_897)))), ((V)(Y1_796)), ((V)((R1_795 * FdLibm.Cos(a_897)))))).Put("s", Call(cand_804, V.Undef, ((V)(R1_795)), ((V)(Y1_796)), ((V)(a_897)), i_895)).V);
return default;
}, 1, "", true));
Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis905, int _argc898, V i_904, V _a901, V _a902, V _a903, V[] _rest899) => {
double a_906 = 0;
a_906 = (((ToNum(i_904) * 2D) * PI_13) / 5D);
Invoke(L_793, "push", NewObj(2).Put("q", Arr(((V)((R2_797 * FdLibm.Sin(a_906)))), ((V)(Y2_798)), ((V)((R2_797 * FdLibm.Cos(a_906)))))).Put("s", Call(cand_804, V.Undef, ((V)(R2_797)), ((V)(Y2_798)), ((V)(a_906)), Add(i_904, ((V)(8D))))).V);
return default;
}, 1, "", true));
Call(rep_22, V.Undef, ((V)(16D)), Fn((V _arrowThis914, int _argc907, V i_913, V _a910, V _a911, V _a912, V[] _rest908) => {
double a_915 = 0;
a_915 = ((ToNum(i_913) * PI_13) / 8D);
Invoke(L_793, "push", NewObj(2).Put("q", Arr(((V)((R1_795 * FdLibm.Sin(a_915)))), ((V)((Y1_796 - 2D))), ((V)((R1_795 * FdLibm.Cos(a_915)))))).Put("s", Call(drop_805, V.Undef, ((V)(R1_795)), ((V)(Y1_796)), ((V)(a_915)), i_913)).V);
return default;
}, 1, "", true));
Call(rep_22, V.Undef, ((V)(10D)), Fn((V _arrowThis923, int _argc916, V i_922, V _a919, V _a920, V _a921, V[] _rest917) => {
double a_924 = 0;
a_924 = (((ToNum(i_922) * PI_13) / 5D) + 0.3);
Invoke(L_793, "push", NewObj(2).Put("q", Arr(((V)(((R2_797 * 0.9) * FdLibm.Sin(a_924)))), ((V)((Y2_798 - 2D))), ((V)(((R2_797 * 0.9) * FdLibm.Cos(a_924)))))).Put("s", Call(drop_805, V.Undef, ((V)((R2_797 * 0.9))), ((V)((Y2_798 - 0.4))), ((V)(a_924)), Add(i_922, ((V)(16D))))).V);
return default;
}, 1, "", true));
isF_806 = Fn((V _arrowThis932, int _argc925, V o_931, V _a928, V _a929, V _a930, V[] _rest926) => {
return ((((ToNum(GetIdx(Get(o_931, "q"), 0D)) * ToNum(GetIdx(v_791, 0D))) + (ToNum(GetIdx(Get(o_931, "q"), 2D)) * ToNum(GetIdx(v_791, 2D)))) > 0D) ? V.True : V.False);
}, 1, "", true);
Lb_807 = Invoke(L_793, "filter", Fn((V _arrowThis940, int _argc933, V o_939, V _a936, V _a937, V _a938, V[] _rest934) => {
return (!(Truthy(Call(isF_806, V.Undef, o_939))) ? V.True : V.False);
}, 1, "", true));
Lf_808 = Invoke(L_793, "filter", isF_806);
arms_809 = Invoke(Call(rep_22, V.Undef, ((V)(8D)), Fn((V _arrowThis948, int _argc941, V i_947, V _a944, V _a945, V _a946, V[] _rest942) => {
double a_949 = 0;
a_949 = (((ToNum(i_947) * PI_13) / 4D) + (PI_13 / 8D));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(P2_24, V.Undef, Invoke(C_789, "p", ((V)(0D)), ((V)(28D)), ((V)(0D))))), "Q", ToStr(Call(P2_24, V.Undef, Invoke(C_789, "p", ((V)(((R1_795 * 0.5) * FdLibm.Sin(a_949)))), ((V)(18D)), ((V)(((R1_795 * 0.5) * FdLibm.Cos(a_949))))))), " ", ToStr(Call(P2_24, V.Undef, Invoke(C_789, "p", ((V)((R1_795 * FdLibm.Sin(a_949)))), ((V)(Y1_796)), ((V)((R1_795 * FdLibm.Cos(a_949))))))), "\" stroke=\"", ToStr(GD_772), "\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.7 * ToNum(k_790)))))), "\" fill=\"none\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")));
body_810 = Add(Add(Add(Add(Add(Add(Add(Add(Add(Add(Add(Call(glow_45, V.Undef, C_789, Arr(((V)(0D)), ((V)(26D)), ((V)(0D))), ((V)(38D)), ((V)(0.55)), Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.45;0.65;0.45")), ((V)(4D)), ((V)(0D)), Call(SPL_19, V.Undef, ((V)(2D))))), ch_794), Call(ringB_802, V.Undef, ((V)(R1_795)), ((V)(Y1_796)), ((V)(1.3)))), Call(ringB_802, V.Undef, ((V)(R2_797)), ((V)(Y2_798)), ((V)(1D)))), Call(zsort_26, V.Undef, C_789, Lb_807)), arms_809), Call(cyl3_28, V.Undef, C_789, Arr(((V)(0D)), ((V)((T_771 - 25D))), ((V)(0D))), Arr(((V)(0D)), ((V)(13D)), ((V)(0D))), ((V)(1.2)), GD_772, NewObj(1).Put("mat", ((V)("gloss"))).V)), Call(sph_29, V.Undef, C_789, Arr(((V)(0D)), ((V)(26D)), ((V)(0D))), ((V)(2.6)), GD_772)), Call(sph_29, V.Undef, C_789, Arr(((V)(0D)), ((V)(12D)), ((V)(0D))), ((V)(1.7)), GD_772)), Call(ringF_803, V.Undef, ((V)(R1_795)), ((V)(Y1_796)), ((V)(1.3)))), Call(ringF_803, V.Undef, ((V)(R2_797)), ((V)(Y2_798)), ((V)(1D)))), Call(zsort_26, V.Undef, C_789, Lf_808));
body_810 = ((V)(string.Concat("<g>", ToStr(Call(swing_47, V.Undef, C_789, Arr(((V)(0D)), ((V)((T_771 - 6D))), ((V)(0D))), ((V)(1.4)), ((V)(7D)))), "<g>", ToStr(Call(at_18, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;0 ", ToStr(Call(f1_20, V.Undef, ((V)((2.4 * ToNum(k_790)))))), ";0 0"))), ((V)(12D)), ((V)(0D)), Call(SPL_19, V.Undef, ((V)(2D))))), ToStr(body_810), "</g></g>")));
return NewObj(3).Put("defs", DEF14_44).Put("front", ((V)(JsStrBuf.Begin().V(body_810).S(top_792.Str).End()))).Put("bb", Invoke(C_789, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_773;
return default;
}, 1, "", true));
Set(N_12, "halo14", Fn((V _arrowThis957, int _argc950, V S_956, V _a953, V _a954, V _a955, V[] _rest951) => {
double T_958 = 0;
double R1_959 = 0;
double Y1_960 = 0;
double R2_961 = 0;
double Y2_962 = 0;
V D_963 = default;
T_958 = 40D;
R1_959 = 42D;
Y1_960 = 18D;
R2_961 = 29D;
Y2_962 = 22D;
D_963 = NewObj(4).Put("w", ((V)(96D))).Put("d", ((V)(96D))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis970, int _argc964, V _a966, V _a967, V _a968, V _a969, V[] _rest965) => {
return Arr();
}, 0, "build", true)).V;
Set(D_963, "fx", Fn((V _arrowThis978, int _argc971, V ctx_977, V _a974, V _a975, V _a976, V[] _rest972) => {
V C_979 = default;
V k_980 = default;
V A_981 = default;
V B_982 = default;
V g_983 = default;
V STO_984 = default;
double Lg_985 = 0;
JsStrBuf s_986 = null;
V path_987 = default;
V bk_988 = default;
V rings_989 = default;
V c_990 = default;
double rx_991 = 0;
double ry_992 = 0;
C_979 = Call(cam_15, V.Undef, ctx_977);
k_980 = Get(C_979, "k");
A_981 = Invoke(C_979, "P", Arr(((V)((-R1_959))), ((V)(Y1_960)), ((V)(0D))));
B_982 = Invoke(C_979, "P", Arr(((V)(R1_959)), ((V)(Y1_960)), ((V)(0D))));
g_983 = Invoke(C_979, "u", ((V)("ag")));
STO_984 = ((V)("<stop offset=\"0\" stop-color=\"#4fe0b0\"/><stop offset=\"0.25\" stop-color=\"#3fb8ff\"/><stop offset=\"0.5\" stop-color=\"#a66bff\"/><stop offset=\"0.75\" stop-color=\"#ff6ad5\"/><stop offset=\"1\" stop-color=\"#4fe0b0\"/>"));
Lg_985 = (ToNum(GetIdx(B_982, 0D)) - ToNum(GetIdx(A_981, 0D)));
s_986 = new JsStrBuf(string.Concat("<defs><linearGradient id=\"", ToStr(g_983), "\" gradientUnits=\"userSpaceOnUse\" x1=\"", ToStr(Call(f1_20, V.Undef, GetIdx(A_981, 0D))), "\" y1=\"0\" x2=\"", ToStr(Call(f1_20, V.Undef, GetIdx(B_982, 0D))), "\" y2=\"0\" spreadMethod=\"repeat\">", ToStr(STO_984), "<animateTransform attributeName=\"gradientTransform\" type=\"translate\" values=\"0 0;", ToStr(Call(f1_20, V.Undef, ((V)(Lg_985)))), " 0\" dur=\"7s\" repeatCount=\"indefinite\"/></linearGradient></defs>"));
path_987 = Fn((V _arrowThis1003, int _argc993, V r_999, V y_1000, V a0_1001, V a1_1002, V[] _rest994) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Call(ring_46, V.Undef, C_979, y_1000, r_999, a0_1001, a1_1002, ((V)(40D))), "map", P2_24), "join", ((V)("L")))).End()));
}, 4, "", true);
bk_988 = Add(Get(C_979, "thV"), ((V)(PI_13)));
Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis1011, int _argc1004, V i_1010, V _a1007, V _a1008, V _a1009, V[] _rest1005) => {
double a_1012 = 0;
V top_1013 = default;
V bot_1014 = default;
a_1012 = ((((ToNum(i_1010) * 2D) * PI_13) / 3D) + 0.4);
top_1013 = Invoke(C_979, "p", ((V)(((R1_959 * 0.6) * FdLibm.Sin(a_1012)))), ((V)(T_958)), ((V)(((R1_959 * 0.6) * FdLibm.Cos(a_1012)))));
bot_1014 = Invoke(C_979, "p", ((V)((R1_959 * FdLibm.Sin(a_1012)))), ((V)(Y1_960)), ((V)((R1_959 * FdLibm.Cos(a_1012)))));
s_986.S(string.Concat("<path d=\"M", ToStr(Call(P2_24, V.Undef, top_1013)), "L", ToStr(Call(P2_24, V.Undef, bot_1014)), "\" stroke=\"#c9cfd8\" stroke-opacity=\"0.7\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.18 * ToNum(k_980)))))), "\"/>")).S(string.Concat("<circle cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(top_1013, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(top_1013, 1D))), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.9 * ToNum(k_980)))))), "\" fill=\"#c9cfd8\"/>"));
return default;
}, 1, "", true));
s_986.S(string.Concat("<g filter=\"url(#l14b3)\" opacity=\"0.5\">", ToStr(Invoke(Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis1022, int _argc1015, V i_1021, V _a1018, V _a1019, V _a1020, V[] _rest1016) => {
double a_1023 = 0;
V p_1024 = default;
V q_1025 = default;
a_1023 = ((ToNum(bk_988) - (PI_13 / 2D)) + ((ToNum(i_1021) * PI_13) / 4D));
p_1024 = Invoke(C_979, "p", ((V)((R1_959 * FdLibm.Sin(a_1023)))), ((V)(Y1_960)), ((V)((R1_959 * FdLibm.Cos(a_1023)))));
q_1025 = Invoke(C_979, "p", ((V)(((R1_959 * 0.8) * FdLibm.Sin(a_1023)))), ((V)((T_958 - 4D))), ((V)(((R1_959 * 0.8) * FdLibm.Cos(a_1023)))));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(p_1024, 0D)) - (4D * ToNum(k_980))))))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(p_1024, 1D))), "L", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(q_1025, 0D)) - (3D * ToNum(k_980))))))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(q_1025, 1D))), "L", ToStr(Call(f1_20, V.Undef, Add(GetIdx(q_1025, 0D), ((V)((3D * ToNum(k_980))))))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(q_1025, 1D))), "L", ToStr(Call(f1_20, V.Undef, Add(GetIdx(p_1024, 0D), ((V)((4D * ToNum(k_980))))))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(p_1024, 1D))), "Z\" fill=\"url(#", ToStr(g_983), ")\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.2;0.7;0.2")), ((V)((4D + (ToNum(i_1021) * 0.9)))), ((V)((-ToNum(i_1021)))))), "</path>")));
return default;
}, 1, "", true)), "join", ((V)("")))), "</g>"));
rings_989 = Fn((V _arrowThis1035, int _argc1026, V a0_1032, V a1_1033, V op_1034, V _a1031, V[] _rest1027) => {
return Invoke(Invoke(Arr(Arr(((V)(R1_959)), ((V)(Y1_960)), ((V)(2.4))), Arr(((V)(R2_961)), ((V)(Y2_962)), ((V)(1.5)))), "map", Fn((V _arrowThis1049, int _argc1036, V _a1038, V _a1039, V _a1040, V _a1041, V[] _rest1037) => {
V r_1044 = default;
V y_1046 = default;
V w_1048 = default;
{ V _t1042 = ListOf(_a1038);
{ V _t1043 = GetIdx(_t1042, 0D);
r_1044 = _t1043; }
{ V _t1045 = GetIdx(_t1042, 1D);
y_1046 = _t1045; }
{ V _t1047 = GetIdx(_t1042, 2D);
w_1048 = _t1047; }
}
return ((V)(string.Concat("<path d=\"", ToStr(Call(path_987, V.Undef, r_1044, y_1046, a0_1032, a1_1033)), "\" stroke=\"url(#", ToStr(g_983), ")\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)(((ToNum(w_1048) * 2.6) * ToNum(k_980)))))), "\" fill=\"none\" opacity=\"", NumStr((ToNum(op_1034) * 0.45)), "\" filter=\"url(#l14b1)\"/><path d=\"", ToStr(Call(path_987, V.Undef, r_1044, y_1046, a0_1032, a1_1033)), "\" stroke=\"#e8ecf2\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(w_1048) * ToNum(k_980)))))), "\" fill=\"none\" stroke-linecap=\"round\" opacity=\"", ToStr(op_1034), "\"/><path d=\"", ToStr(Call(path_987, V.Undef, r_1044, y_1046, a0_1032, a1_1033)), "\" stroke=\"url(#", ToStr(g_983), ")\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)(((ToNum(w_1048) * 0.62) * ToNum(k_980)))))), "\" fill=\"none\" stroke-linecap=\"round\" opacity=\"", ToStr(op_1034), "\"/>")));
}, 1, "", true)), "join", ((V)("")));
}, 3, "", true);
s_986.V(Call(rings_989, V.Undef, ((V)((ToNum(bk_988) - (PI_13 / 2D)))), Add(bk_988, ((V)((PI_13 / 2D)))), ((V)(0.75))));
c_990 = Invoke(C_979, "P", Arr(((V)(0D)), ((V)(Y1_960)), ((V)(0D))));
rx_991 = (System.Math.Abs((ToNum(GetIdx(B_982, 0D)) - ToNum(GetIdx(A_981, 0D)))) / 2D);
ry_992 = System.Math.Abs((ToNum(GetIdx(Invoke(C_979, "P", Arr(((V)(0D)), ((V)(Y1_960)), ((V)(R1_959)))), 1D)) - ToNum(GetIdx(c_990, 1D))));
s_986.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(c_990, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(c_990, 1D))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)(rx_991)))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)(ry_992)))), "\" fill=\"none\" stroke=\"#bff6ee\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.6 * ToNum(k_980)))))), "\" opacity=\"0\"><animate attributeName=\"rx\" values=\"", ToStr(Call(f1_20, V.Undef, ((V)(rx_991)))), ";", ToStr(Call(f1_20, V.Undef, ((V)((rx_991 * 1.3))))), "\" dur=\"3.2s\" repeatCount=\"indefinite\"/><animate attributeName=\"ry\" values=\"", ToStr(Call(f1_20, V.Undef, ((V)(ry_992)))), ";", ToStr(Call(f1_20, V.Undef, ((V)((ry_992 * 1.3))))), "\" dur=\"3.2s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0.8;0\" dur=\"3.2s\" repeatCount=\"indefinite\"/></ellipse>"));
s_986.V(Call(rings_989, V.Undef, ((V)((ToNum(Get(C_979, "thV")) - (PI_13 / 2D)))), Add(Get(C_979, "thV"), ((V)((PI_13 / 2D)))), ((V)(1D))));
return NewObj(3).Put("defs", DEF14_44).Put("front", ((V)(s_986.Str))).Put("bb", Invoke(C_979, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_963;
return default;
}, 1, "", true));
draw13_49 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis1058, int _argc1050, V r_1056, V o_1057, V _a1054, V _a1055, V[] _rest1051) => {
V res_1059 = default;
res_1059 = Call(draw13_49, V.Undef, r_1056, o_1057);
if (Truthy(((!(Truthy(res_1059)) ? V.True : V.False) is var _t1060 && Truthy(_t1060) ? _t1060 : Get(res_1059, "_p14")))) {
return res_1059;
}
try {
V k_1061 = default;
k_1061 = (Get(r_1056, "c14") is var _t1062 && !Truthy(_t1062) ? _t1062 : GetK(CEIL14_42, Get(r_1056, "c14")));
if (Truthy((k_1061 is var _t1063 && !Truthy(_t1063) ? _t1063 : Get(res_1059, "surf")))) {
V G_1064 = default;
Set(res_1059, "_p14", ((V)(1D)));
Set(res_1059, "vb", ((V)("0 0 80 56")));
Set(res_1059, "svg", Invoke(RD_8, "svgDoc", ((V)("0 0 80 56")), Arr(), Call(cardOf_43, V.Undef, Get(r_1056, "c14"))));
Set(res_1059, "src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Get(res_1059, "svg"))).End())));
G_1064 = Call(mk_31, V.Undef, Get(FRM_30, "room"));
Set(res_1059, "ceilRoom", Invoke(RD_8, "svgDoc", ((V)(JsStrBuf.Begin().S("0 0 ").V(Get(G_1064, "W")).S(" ").V(Get(G_1064, "H")).End())), Arr(), Call(doc_34, V.Undef, G_1064, Call(k_1061, V.Undef, G_1064))));
Set(res_1059, "ceilBase", GetIdx(GetK(CBASE_41, Get(r_1056, "c14")), 0D));
Set(res_1059, "ceilTrim", GetIdx(GetK(CBASE_41, Get(r_1056, "c14")), 1D));
}
} catch (System.Exception _ex1065) {
V e_1066 = default;
e_1066 = Caught(_ex1065);
Invoke(G("console"), "warn", ((V)("reno plus14")), Get(r_1056, "id"), e_1066);
}
return res_1059;
return default;
}, 2, "", true));
Set(RD_8, "SET14", NewObj(10).Put("MOV-009", NewObj(3).Put("c14", ((V)("pipes"))).Put("live", ((V)("Spider on a thread"))).Put("note", ((V)("Bare wooden joists under rough subfloor boards, a grey drain pipe and a copper water line on metal straps, a stapled wire sagging between the joists, and dusty cobwebs in the corners. A tiny spider bobs on its thread."))).V).Put("MOV-029", NewObj(2).Put("c14", ((V)("tile"))).Put("note", ((V)("A light grey T-bar grid holding charcoal acoustic foam tiles that soak up sound. One tile has been knocked a little askew and there is a return-air grille in the back row."))).V).Put("MOV-049", NewObj(2).Put("c14", ((V)("coffer"))).Put("note", ((V)("Deep coffers framed by dark walnut beams, each lined in burgundy to match the velvet walls, with a gold rosette at every crossing and a warm pin light glowing in each coffer."))).V).Put("MOV-069", NewObj(3).Put("c14", ((V)("sky"))).Put("live", ((V)("Twinkling stars"))).Put("note", ((V)("A navy night-sky dome full of fibre-optic stars in warm and cool white that twinkle at their own pace, a faint Milky Way, now and then a shooting star, and a walnut crown with an amber LED cove."))).V).Put("MOV-089", NewObj(3).Put("c14", ((V)("neb"))).Put("live", ((V)("Drifting nebula"))).Put("note", ((V)("A 360-degree projection vault: violet, cyan and pink nebula clouds drift slowly over a field of twinkling stars while a soft projector sweep passes over, edged in obsidian with a violet light line."))).V).Put("MOV-015", NewObj(4).Put("spec", ((V)("bulb14"))).Put("s3", V.Null).Put("live", ((V)("Swaying bulb"))).Put("note", ((V)("A clear utility bulb in a porcelain socket on a short cloth cord, with a glowing filament and a little pull chain. It sways gently, the chain swings and the light flickers now and then."))).V).Put("MOV-035", NewObj(4).Put("spec", ((V)("track14"))).Put("s3", V.Null).Put("live", ((V)("Dimming spots"))).Put("note", ((V)("A black ceiling track on two rods with four spot cans. The cans pan slowly and their warm beams dim up and down like someone is playing with the dimmer."))).V).Put("MOV-055", NewObj(4).Put("spec", ((V)("flush14"))).Put("s3", V.Null).Put("live", ((V)("Soft glow"))).Put("note", ((V)("An Art Deco flush-mount: a brass canopy with three stepped frosted-glass tiers, fluted lines and brass bands, glowing softly and lighting the ceiling around it."))).V).Put("MOV-075", NewObj(4).Put("spec", ((V)("chand14"))).Put("s3", V.Null).Put("live", ((V)("Sparkling crystals"))).Put("note", ((V)("A brass chandelier on a motorized winch: a chain, two rings of candle bulbs and rows of crystal drops that sparkle. The motor slowly lowers and raises it and it sways a little."))).V).Put("MOV-095", NewObj(4).Put("spec", ((V)("halo14"))).Put("s3", V.Null).Put("live", ((V)("Aurora colours"))).Put("note", ((V)("Two floating rings on fine wires with aurora colours flowing round them, soft aurora curtains rising to the ceiling and a pulse ring that ripples out when it hears voices."))).V).V);
edit13_50 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis1074, int _argc1067, V rows_1073, V _a1070, V _a1071, V _a1072, V[] _rest1068) => {
return Invoke(Call(edit13_50, V.Undef, rows_1073), "map", Fn((V _arrowThis1082, int _argc1075, V r_1081, V _a1078, V _a1079, V _a1080, V[] _rest1076) => {
return (Truthy(GetK(Get(RD_8, "SET14"), Get(r_1081, "id"))) ? Object_assign(NewObj(0).V, r_1081, GetK(Get(RD_8, "SET14"), Get(r_1081, "id"))) : r_1081);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H14", NewObj(3).Put("mk", mk_31).Put("FRM", FRM_30).Put("CEIL14", CEIL14_42).V);
Set(RD_8, "PLUS14", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
