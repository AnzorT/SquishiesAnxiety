// reno-plus21.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus21_js
    {

        public static void Run()
        {
Call(Named(boot_645 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
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
V P2_23 = default;
V DEF11_24 = default;
V zsort_25 = default;
V box3_26 = default;
V cyl3_27 = default;
V sph_28 = default;
V mkV_29 = default;
V FRM_30 = default;
V E_31 = default;
V lo_32 = default;
V dot_33 = default;
V band_34 = default;
V mould_35 = default;
V trim_36 = default;
V light_37 = default;
V doc_38 = default;
V blots_39 = default;
V web_40 = default;
V cPop_41 = default;
V cCove_42 = default;
V cBeam_43 = default;
V cMed_44 = default;
V cVault_45 = default;
V WALLC_46 = default;
V CBASE_47 = default;
V CEIL21_48 = default;
V cardOf_49 = default;
V DEF21_50 = default;
V glow_51 = default;
V ring_52 = default;
V swing_53 = default;
V FLK_54 = default;
V ellOf_55 = default;
V draw20_56 = default;
V MEMO_57 = default;
V edit20_58 = default;
if (_self1.IsNullish) _self1 = GlobalV;
cPop_41 = Fn((V _self59, int _argc60, V G_66, V _a63, V _a64, V _a65, V[] _rest61) => {
V R_67 = default;
JsStrBuf s_68 = null;
V T0_69 = default;
JsStrBuf a_70 = null;
JsStrBuf b_71 = null;
V tile_72 = default;
double NB_73 = 0;
JsStrBuf pd_74 = null;
V stain_75 = default;
if (_self59.IsNullish) _self59 = GlobalV;
R_67 = Call(rng_16, V.Undef, ((V)("pop21")));
s_68 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<path d=\"", ToStr(Get(G_66, "tr")), "\" fill=\"#e6dbbd\"/>")).V(Call(blots_39, V.Undef, G_66, ((V)("pop21b")), ((V)(10D)), Arr(((V)("#d6c493")), ((V)("#f3ebd5")), ((V)("#dccb9f"))), ((V)(0.55)), ((V)(40D)))).End());
T0_69 = Call(rng_16, V.Undef, ((V)("popT")));
a_70 = new JsStrBuf("");
b_71 = new JsStrBuf("");
{
double i_76 = 0;
i_76 = 0D;
while (true) {
if (!((i_76 < 46D))) break;
double x_78 = 0;
double y_79 = 0;
double r_80 = 0;
x_78 = (ToNum(Call(T0_69, V.Undef)) * 20D);
y_79 = (ToNum(Call(T0_69, V.Undef)) * 20D);
r_80 = (0.7 + (ToNum(Call(T0_69, V.Undef)) * 0.8));
Invoke(Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(20D)), ((V)(0D))), Arr(((V)((-20D))), ((V)(0D))), Arr(((V)(0D)), ((V)(20D))), Arr(((V)(0D)), ((V)((-20D))))), "forEach", Fn((V _arrowThis92, int _argc81, V _a83, V _a84, V _a85, V _a86, V[] _rest82) => {
V X2_93 = default;
V Y2_94 = default;
V dx_89 = default;
V dy_91 = default;
{ V _t87 = ListOf(_a83);
{ V _t88 = GetIdx(_t87, 0D);
dx_89 = _t88; }
{ V _t90 = GetIdx(_t87, 1D);
dy_91 = _t90; }
}
X2_93 = Add(((V)(x_78)), dx_89);
Y2_94 = Add(((V)(y_79)), dy_91);
if ((((LtN(X2_93, ((-2D) * r_80)) || GtN(X2_93, (20D + (2D * r_80)))) || LtN(Y2_94, ((-2D) * r_80))) || GtN(Y2_94, (20D + (2D * r_80))))) {
return default;
}
a_70.V(Call(dot_33, V.Undef, Add(X2_93, ((V)((0.32 * r_80)))), Add(Y2_94, ((V)((0.28 * r_80)))), ((V)(r_80)), ((V)(r_80))));
b_71.V(Call(dot_33, V.Undef, ((V)((ToNum(X2_93) - (0.2 * r_80)))), ((V)((ToNum(Y2_94) - (0.2 * r_80)))), ((V)((r_80 * 0.66))), ((V)((r_80 * 0.66)))));
return default;
}, 1, "", true));
i_76++;
}
}
tile_72 = ((V)(string.Concat("<path d=\"", a_70.Str, "\" fill=\"#c2af82\" opacity=\"0.62\"/><path d=\"", b_71.Str, "\" fill=\"#faf5e6\" opacity=\"0.92\"/>")));
NB_73 = 9D;
pd_74 = new JsStrBuf("");
{
double j_95 = 0;
j_95 = 0D;
while (true) {
if (!((j_95 < NB_73))) break;
double t0_97 = 0;
double t1_98 = 0;
double z_99 = 0;
t0_97 = (j_95 / NB_73);
t1_98 = ((j_95 + 1D) / NB_73);
z_99 = (ToNum(Invoke(G_66, "z", Invoke(G_66, "y", ((V)(((t0_97 + t1_98) / 2D)))))) * 0.55);
pd_74.S(string.Concat("<pattern id=\"pp", NumStr(j_95), "\" patternUnits=\"userSpaceOnUse\" width=\"20\" height=\"20\" patternTransform=\"translate(", NumStr((j_95 * 7D)), " 0) scale(", ToStr(Call(n4_21, V.Undef, ((V)(z_99)))), " ", ToStr(Call(n4_21, V.Undef, ((V)((z_99 * 0.6))))), ")\">", ToStr(tile_72), "</pattern>"));
s_68.S(string.Concat("<path d=\"", ToStr(Invoke(G_66, "quad", ((V)((-0.05))), ((V)(t0_97)), ((V)(1.05)), ((V)(t1_98)))), "\" fill=\"url(#pp", NumStr(j_95), ")\"/>"));
j_95++;
}
}
s_68.Set(string.Concat(string.Concat("<defs>", pd_74.Str, "</defs>"), s_68.Str));
stain_75 = Fn((V _arrowThis110, int _argc100, V u_106, V t_107, V rw_108, V sd_109, V[] _rest101) => {
V P_111 = default;
V Rr_112 = default;
double n_113 = 0;
V pts_114 = default;
V d_115 = default;
V d2_116 = default;
P_111 = Call(E_31, V.Undef, G_66, u_106, t_107);
Rr_112 = Call(rng_16, V.Undef, sd_109);
n_113 = 22D;
pts_114 = Call(rep_22, V.Undef, ((V)(n_113)), Fn((V _arrowThis124, int _argc117, V i_123, V _a120, V _a121, V _a122, V[] _rest118) => {
double an__125 = 0;
double k_126 = 0;
an__125 = (((ToNum(i_123) / n_113) * 2D) * PI_13);
k_126 = ((ToNum(rw_108) * ToNum(Get(P_111, "z"))) * (0.78 + (ToNum(Call(Rr_112, V.Undef)) * 0.4)));
return Arr(Add(Get(P_111, "x"), ((V)((FdLibm.Cos(an__125) * k_126)))), Add(Get(P_111, "y"), ((V)(((FdLibm.Sin(an__125) * k_126) * ToNum(Get(P_111, "q")))))));
return default;
}, 1, "", true));
d_115 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_114, "map", P2_23), "join", ((V)("L")))).S("Z").End()));
d2_116 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Invoke(pts_114, "map", Fn((V _arrowThis138, int _argc127, V _a129, V _a130, V _a131, V _a132, V[] _rest128) => {
V x_135 = default;
V y_137 = default;
{ V _t133 = ListOf(_a129);
{ V _t134 = GetIdx(_t133, 0D);
x_135 = _t134; }
{ V _t136 = GetIdx(_t133, 1D);
y_137 = _t136; }
}
return Arr(Add(Get(P_111, "x"), ((V)(((ToNum(x_135) - ToNum(Get(P_111, "x"))) * 0.6)))), Add(Get(P_111, "y"), ((V)(((ToNum(y_137) - ToNum(Get(P_111, "y"))) * 0.6)))));
}, 1, "", true)), "map", P2_23), "join", ((V)("L")))).S("Z").End()));
return ((V)(string.Concat("<path d=\"", ToStr(d_115), "\" fill=\"#d0b479\" opacity=\"0.4\"/><path d=\"", ToStr(d_115), "\" fill=\"none\" stroke=\"#a37e48\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((1.1 * ToNum(Get(P_111, "z"))))))), "\" opacity=\"0.55\"/><path d=\"", ToStr(d2_116), "\" fill=\"#c9a96a\" opacity=\"0.18\"/><path d=\"", ToStr(d2_116), "\" fill=\"none\" stroke=\"#b18c55\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.7 * ToNum(Get(P_111, "z"))))))), "\" opacity=\"0.42\"/>")));
return default;
}, 4, "", true);
s_68.V(Add(Add(Call(stain_75, V.Undef, ((V)(0.27)), ((V)(0.55)), ((V)(26D)), ((V)("st1"))), Call(stain_75, V.Undef, ((V)(0.72)), ((V)(0.32)), ((V)(17D)), ((V)("st2")))), Call(stain_75, V.Undef, ((V)(0.6)), ((V)(0.84)), ((V)(11D)), ((V)("st3")))));
{
V P_139 = default;
V z_140 = default;
V Rr_141 = default;
V pts_142 = default;
V d_143 = default;
V ax_144 = default;
V ay_145 = default;
V fl_146 = default;
P_139 = Call(E_31, V.Undef, G_66, ((V)(0.33)), ((V)(0.62)));
z_140 = Get(P_139, "z");
Rr_141 = Call(rng_16, V.Undef, ((V)("peel")));
pts_142 = Call(rep_22, V.Undef, ((V)(14D)), Fn((V _arrowThis154, int _argc147, V i_153, V _a150, V _a151, V _a152, V[] _rest148) => {
double a2_155 = 0;
double k_156 = 0;
a2_155 = (((ToNum(i_153) / 14D) * 2D) * PI_13);
k_156 = ((7D + (ToNum(Call(Rr_141, V.Undef)) * 5D)) * ToNum(z_140));
return Arr(Add(Get(P_139, "x"), ((V)(((FdLibm.Cos(a2_155) * k_156) * 1.4)))), Add(Get(P_139, "y"), ((V)((((FdLibm.Sin(a2_155) * k_156) * ToNum(Get(P_139, "q"))) * 1.3)))));
return default;
}, 1, "", true));
d_143 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_142, "map", P2_23), "join", ((V)("L")))).S("Z").End()));
s_68.S(string.Concat("<path d=\"", ToStr(d_143), "\" fill=\"#cbc4b2\"/><path d=\"", ToStr(d_143), "\" fill=\"none\" stroke=\"#a89f88\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(z_140)))))), "\"/><path d=\"", ToStr(d_143), "\" fill=\"none\" stroke=\"#fbf6e6\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(z_140)))))), "\" transform=\"translate(", ToStr(Call(f1_20, V.Undef, ((V)(((-0.6) * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)(((-0.5) * ToNum(z_140)))))), ")\"/>"));
ax_144 = GetIdx(GetIdx(pts_142, 3D), 0D);
ay_145 = GetIdx(GetIdx(pts_142, 3D), 1D);
fl_146 = ((V)(string.Concat("M", ToStr(Call(f1_20, V.Undef, ax_144)), " ", ToStr(Call(f1_20, V.Undef, ay_145)), "q", ToStr(Call(f1_20, V.Undef, ((V)((4D * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)(((-1D) * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((7D * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((1.2 * ToNum(z_140)))))), "q", ToStr(Call(f1_20, V.Undef, ((V)(((-0.6) * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((3.6 * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)(((-4.2) * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((5.4 * ToNum(z_140)))))), "q", ToStr(Call(f1_20, V.Undef, ((V)(((-2.8) * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)(((-1.6) * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)(((-2.8) * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)(((-6.6) * ToNum(z_140)))))), "Z")));
s_68.S(string.Concat("<g>", ToStr(Call(at_18, V.Undef, ((V)("rotate")), ((V)(string.Concat("-9 ", ToStr(Call(f1_20, V.Undef, ax_144)), " ", ToStr(Call(f1_20, V.Undef, ay_145)), ";7 ", ToStr(Call(f1_20, V.Undef, ax_144)), " ", ToStr(Call(f1_20, V.Undef, ay_145)), ";-4 ", ToStr(Call(f1_20, V.Undef, ax_144)), " ", ToStr(Call(f1_20, V.Undef, ay_145)), ";-9 ", ToStr(Call(f1_20, V.Undef, ax_144)), " ", ToStr(Call(f1_20, V.Undef, ay_145))))), ((V)(3.8)), ((V)(0D)), Call(SPL_19, V.Undef, ((V)(3D))))), "<path d=\"", ToStr(fl_146), "\" fill=\"#000000\" opacity=\"0.18\" transform=\"translate(", ToStr(Call(f1_20, V.Undef, ((V)((0.8 * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((1D * ToNum(z_140)))))), ")\"/><path d=\"", ToStr(fl_146), "\" fill=\"#efe5c8\" stroke=\"#b6a67c\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.35 * ToNum(z_140)))))), "\"/><path d=\"M", ToStr(Call(f1_20, V.Undef, Add(ax_144, ((V)((1D * ToNum(z_140))))))), " ", ToStr(Call(f1_20, V.Undef, Add(ay_145, ((V)((0.6 * ToNum(z_140))))))), "q", ToStr(Call(f1_20, V.Undef, ((V)((2.4 * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((0.2 * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((4.6 * ToNum(z_140)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((1.4 * ToNum(z_140)))))), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.4 * ToNum(z_140)))))), "\" fill=\"none\" opacity=\"0.8\"/></g>"));
}
{
V pts_157 = default;
V br_158 = default;
pts_157 = Invoke(Arr(Arr(((V)(0.04)), ((V)(0.97))), Arr(((V)(0.07)), ((V)(0.9))), Arr(((V)(0.065)), ((V)(0.84))), Arr(((V)(0.1)), ((V)(0.78))), Arr(((V)(0.12)), ((V)(0.7))), Arr(((V)(0.16)), ((V)(0.66)))), "map", Fn((V _arrowThis170, int _argc159, V _a161, V _a162, V _a163, V _a164, V[] _rest160) => {
V y_171 = default;
V u_167 = default;
V t_169 = default;
{ V _t165 = ListOf(_a161);
{ V _t166 = GetIdx(_t165, 0D);
u_167 = _t166; }
{ V _t168 = GetIdx(_t165, 1D);
t_169 = _t168; }
}
y_171 = Invoke(G_66, "y", t_169);
return Arr(Invoke(G_66, "x", u_167, y_171), y_171);
return default;
}, 1, "", true));
br_158 = Invoke(Arr(Arr(((V)(0.1)), ((V)(0.78))), Arr(((V)(0.135)), ((V)(0.8))), Arr(((V)(0.15)), ((V)(0.86)))), "map", Fn((V _arrowThis183, int _argc172, V _a174, V _a175, V _a176, V _a177, V[] _rest173) => {
V y_184 = default;
V u_180 = default;
V t_182 = default;
{ V _t178 = ListOf(_a174);
{ V _t179 = GetIdx(_t178, 0D);
u_180 = _t179; }
{ V _t181 = GetIdx(_t178, 1D);
t_182 = _t181; }
}
y_184 = Invoke(G_66, "y", t_182);
return Arr(Invoke(G_66, "x", u_180, y_184), y_184);
return default;
}, 1, "", true));
s_68.S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(pts_157, "map", P2_23), "join", ((V)("L")))), "M", ToStr(Invoke(Invoke(br_158, "map", P2_23), "join", ((V)("L")))), "\" stroke=\"#9a8a68\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(Get(G_66, "s"))))))), "\" fill=\"none\" stroke-linejoin=\"round\"/>"));
}
s_68.V(Add(Call(web_40, V.Undef, G_66, ((V)(0.995)), ((V)(1D)), ((V)(1.1)), ((V)(1D))), Call(web_40, V.Undef, G_66, ((V)(0.006)), ((V)(0.99)), ((V)(0.8)))));
return ((V)(JsStrBuf.Begin().S(s_68.Str).V(Call(light_37, V.Undef, G_66, ((V)(0.3)), ((V)(0.05)))).V(Call(trim_36, V.Undef, G_66, ((V)(2.6)), ((V)("#e2d5b2")))).End()));
return default;
}, 1, "cPop", false);
cCove_42 = Fn((V _self185, int _argc186, V G_192, V _a189, V _a190, V _a191, V[] _rest187) => {
JsStrBuf s_193 = null;
if (_self185.IsNullish) _self185 = GlobalV;
s_193 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<path d=\"", ToStr(Get(G_192, "tr")), "\" fill=\"#f2eee5\"/>")).V(Call(blots_39, V.Undef, G_192, ((V)("cov21")), ((V)(8D)), Arr(((V)("#ffffff")), ((V)("#e6dfcf"))), ((V)(0.5)), ((V)(90D)))).End());
s_193.S(string.Concat("<defs><linearGradient id=\"sgb\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0.5\" stop-color=\"#9caf8b\" stop-opacity=\"0\"/><stop offset=\"1\" stop-color=\"#9caf8b\" stop-opacity=\"0.24\"/></linearGradient></defs><path d=\"", ToStr(Get(G_192, "tr")), "\" fill=\"url(#sgb)\"/>"));
{
V P_194 = default;
V z_195 = default;
V x_196 = default;
V y_197 = default;
V yb_198 = default;
double r_199 = 0;
double ry_200 = 0;
P_194 = Call(E_31, V.Undef, G_192, ((V)(0.31)), ((V)(0.5)));
z_195 = Get(P_194, "z");
x_196 = Get(P_194, "x");
y_197 = Get(P_194, "y");
yb_198 = Call(lo_32, V.Undef, G_192, y_197, ((V)(0.025)));
r_199 = (6D * ToNum(z_195));
ry_200 = (r_199 * ToNum(Get(P_194, "q")));
s_193.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Add(x_196, ((V)((1D * ToNum(z_195))))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, Add(yb_198, ((V)((1.2 * ToNum(z_195))))))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((r_199 * 1.05))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((ry_200 * 1.05))))), "\" fill=\"#000000\" opacity=\"0.16\" filter=\"url(#cb1)\"/>")).S(string.Concat("<path d=\"M", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(x_196) - r_199))))), " ", ToStr(Call(f1_20, V.Undef, y_197)), "V", ToStr(Call(f1_20, V.Undef, yb_198)), "H", ToStr(Call(f1_20, V.Undef, Add(x_196, ((V)(r_199))))), "V", ToStr(Call(f1_20, V.Undef, y_197)), "Z\" fill=\"#dcd8cf\"/><ellipse cx=\"", ToStr(Call(f1_20, V.Undef, x_196)), "\" cy=\"", ToStr(Call(f1_20, V.Undef, y_197)), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)(r_199)))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)(ry_200)))), "\" fill=\"#dcd8cf\"/>")).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, x_196)), "\" cy=\"", ToStr(Call(f1_20, V.Undef, yb_198)), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)(r_199)))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)(ry_200)))), "\" fill=\"#fbfaf6\" stroke=\"#c9c3b6\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.4 * ToNum(Get(G_192, "s"))))))), "\"/><ellipse cx=\"", ToStr(Call(f1_20, V.Undef, x_196)), "\" cy=\"", ToStr(Call(f1_20, V.Undef, yb_198)), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((r_199 * 0.62))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((ry_200 * 0.62))))), "\" fill=\"#f1eee6\" stroke=\"#d6d0c3\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.35 * ToNum(Get(G_192, "s"))))))), "\"/>")).V(Invoke(Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis208, int _argc201, V i_207, V _a204, V _a205, V _a206, V[] _rest202) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(x_196) - (r_199 * 0.42)))))), " ", ToStr(Call(f1_20, V.Undef, Add(yb_198, ((V)((((ToNum(i_207) - 1.5) * ry_200) * 0.22)))))), "H", ToStr(Call(f1_20, V.Undef, Add(x_196, ((V)((r_199 * 0.42)))))), "\" stroke=\"#c4bdae\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.35 * ToNum(z_195)))))), "\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Add(x_196, ((V)((r_199 * 0.78)))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, yb_198)), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.6 * ToNum(z_195)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.42 * ToNum(z_195)))))), "\" fill=\"#7a1a14\"/><ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Add(x_196, ((V)((r_199 * 0.78)))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, yb_198)), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.6 * ToNum(z_195)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.42 * ToNum(z_195)))))), "\" fill=\"#ff3b30\" opacity=\"0.15\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.15;0.15;1;0.15")), ((V)(4D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.86;0.9;1\"")))), "</ellipse>")).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Add(x_196, ((V)((r_199 * 0.78)))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, yb_198)), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((2.4 * ToNum(z_195)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((1.4 * ToNum(z_195)))))), "\" fill=\"#ff5a4a\" opacity=\"0\" filter=\"url(#cb1)\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0;0;0.6;0")), ((V)(4D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.86;0.9;1\"")))), "</ellipse>"));
}
{
double u0_209 = 0;
double u1_210 = 0;
double t0_211 = 0;
double t1_212 = 0;
JsStrBuf l_213 = null;
u0_209 = 0.75;
u1_210 = 0.81;
t0_211 = 0.27;
t1_212 = 0.34;
l_213 = new JsStrBuf("");
{
double i_214 = 0;
i_214 = 1D;
while (true) {
if (!((i_214 < 6D))) break;
double t_216 = 0;
t_216 = (t0_211 + (((t1_212 - t0_211) * i_214) / 6D));
l_213.S("M").V(Invoke(G_192, "P", ((V)((u0_209 + 0.004))), ((V)(t_216)))).S("L").V(Invoke(G_192, "P", ((V)((u1_210 - 0.004))), ((V)(t_216))));
i_214++;
}
}
s_193.S(string.Concat("<path d=\"", ToStr(Invoke(G_192, "quad", ((V)(u0_209)), ((V)(t0_211)), ((V)(u1_210)), ((V)(t1_212)))), "\" fill=\"#000000\" opacity=\"0.12\" filter=\"url(#cb1)\" transform=\"translate(", ToStr(Call(f1_20, V.Undef, ((V)((0.8 * ToNum(Get(G_192, "s"))))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((1D * ToNum(Get(G_192, "s"))))))), ")\"/><path d=\"", ToStr(Invoke(G_192, "quad", ((V)(u0_209)), ((V)(t0_211)), ((V)(u1_210)), ((V)(t1_212)))), "\" fill=\"#f8f6f0\" stroke=\"#cbc4b5\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(Get(G_192, "s"))))))), "\"/><path d=\"", ToStr(Invoke(G_192, "quad", ((V)((u0_209 + 0.004))), ((V)((t0_211 + 0.012))), ((V)((u1_210 - 0.004))), ((V)((t1_212 - 0.012))))), "\" fill=\"#8c877c\"/><path d=\"", l_213.Str, "\" stroke=\"#f3f0e8\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((1.3 * ToNum(Get(G_192, "s"))))))), "\"/>"));
}
return ((V)(JsStrBuf.Begin().S(s_193.Str).V(Call(light_37, V.Undef, G_192, ((V)(0.24)), ((V)(0.05)))).V(Call(mould_35, V.Undef, G_192, ((V)(7D)), Arr(((V)("#dbd3c2")), ((V)("#b9ae97")), ((V)("#cfc6b3")), ((V)("#e9e3d6")), ((V)("#fbf9f3"))), ((V)("#ffffff")))).End()));
return default;
}, 1, "cCove", false);
cBeam_43 = Fn((V _self217, int _argc218, V G_224, V _a221, V _a222, V _a223, V[] _rest219) => {
V R_225 = default;
double NU_226 = 0;
V BC_227 = default;
JsStrBuf s_228 = null;
JsStrBuf gr_229 = null;
V beam_230 = default;
if (_self217.IsNullish) _self217 = GlobalV;
R_225 = Call(rng_16, V.Undef, ((V)("bm21")));
NU_226 = 40D;
BC_227 = Arr(((V)("#efe6d5")), ((V)("#e6dcca")), ((V)("#f3ecde")), ((V)("#e0d5c0")));
s_228 = new JsStrBuf(string.Concat("<path d=\"", ToStr(Get(G_224, "tr")), "\" fill=\"#e9e0cf\"/>"));
gr_229 = new JsStrBuf("");
{
double i_231 = 0;
i_231 = 0D;
while (true) {
if (!((i_231 < NU_226))) break;
double u0_233 = 0;
double u1_234 = 0;
u0_233 = (((i_231 / NU_226) * 1.1) - 0.05);
u1_234 = ((((i_231 + 1D) / NU_226) * 1.1) - 0.05);
s_228.S(string.Concat("<path d=\"", ToStr(Invoke(G_224, "quad", ((V)(u0_233)), ((V)(0D)), ((V)(u1_234)), ((V)(1D)))), "\" fill=\"", ToStr(GetIdx(BC_227, (((i_231 * 5D) + ((double)(ToInt32((ToNum(Call(R_225, V.Undef)) * 2D)) | ToInt32(0D)))) % 4D))), "\"/>"));
gr_229.S("M").V(Invoke(G_224, "P", ((V)(u0_233)), ((V)(0D)))).S("L").V(Invoke(G_224, "P", ((V)(u0_233)), ((V)(1D))));
i_231++;
}
}
s_228.S(string.Concat("<path d=\"", gr_229.Str, "\" stroke=\"#c4b596\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.7 * ToNum(Get(G_224, "s"))))))), "\" fill=\"none\"/>")).V(Invoke(Call(rep_22, V.Undef, ((V)(30D)), Fn((V _arrowThis241, int _argc235, V _a237, V _a238, V _a239, V _a240, V[] _rest236) => {
V P_242 = default;
P_242 = Call(E_31, V.Undef, G_224, Call(R_225, V.Undef), Call(R_225, V.Undef));
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Get(P_242, "x"))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, Get(P_242, "y"))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((1.1 * ToNum(Get(P_242, "z"))))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(Get(P_242, "z"))))))), "\" fill=\"#c9b691\" opacity=\"0.6\"/>")));
return default;
}, 0, "", true)), "join", ((V)(""))));
beam_230 = Fn((V _arrowThis250, int _argc243, V t_249, V _a246, V _a247, V _a248, V[] _rest244) => {
double bt_251 = 0;
double dd_252 = 0;
V y0_253 = default;
V y1_254 = default;
V ya_255 = default;
V yb_256 = default;
V z0_257 = default;
V z1_258 = default;
double XL_259 = 0;
V XW_260 = default;
V Rb_261 = default;
JsStrBuf b_262 = null;
V wav_263 = default;
bt_251 = 0.052;
dd_252 = 0.068;
y0_253 = Invoke(G_224, "y", t_249);
y1_254 = Invoke(G_224, "y", Add(t_249, ((V)(bt_251))));
ya_255 = Call(lo_32, V.Undef, G_224, y0_253, ((V)(dd_252)));
yb_256 = Call(lo_32, V.Undef, G_224, y1_254, ((V)(dd_252)));
z0_257 = Invoke(G_224, "z", y0_253);
z1_258 = Invoke(G_224, "z", y1_254);
XL_259 = (-12D);
XW_260 = Add(Get(G_224, "W"), ((V)(24D)));
Rb_261 = Call(rng_16, V.Undef, ((V)(JsStrBuf.Begin().S("bm").V(t_249).End())));
b_262 = new JsStrBuf(string.Concat(string.Concat("<rect x=\"", NumStr(XL_259), "\" y=\"", ToStr(Call(f1_20, V.Undef, y1_254)), "\" width=\"", ToStr(XW_260), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)(((ToNum(yb_256) - ToNum(y1_254)) + (4D * ToNum(z1_258))))))), "\" fill=\"#000000\" opacity=\"0.2\" filter=\"url(#cb1)\"/>"), string.Concat("<rect x=\"", NumStr(XL_259), "\" y=\"", ToStr(Call(f1_20, V.Undef, y0_253)), "\" width=\"", ToStr(XW_260), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(ya_255) - ToNum(y0_253)))))), "\" fill=\"#95522e\"/><rect x=\"", NumStr(XL_259), "\" y=\"", ToStr(Call(f1_20, V.Undef, ya_255)), "\" width=\"", ToStr(XW_260), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(yb_256) - ToNum(ya_255)))))), "\" fill=\"#bb6d40\"/>")));
wav_263 = Fn((V _arrowThis273, int _argc264, V yy_270, V amp_271, V ph_272, V _a269, V[] _rest265) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Call(rep_22, V.Undef, ((V)(26D)), Fn((V _arrowThis281, int _argc274, V i_280, V _a277, V _a278, V _a279, V[] _rest275) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, ((V)((XL_259 + ((ToNum(XW_260) * ToNum(i_280)) / 25D)))))).S(" ").V(Call(f1_20, V.Undef, Add(Add(yy_270, ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(i_280) * 1.3))), ph_272))) * ToNum(amp_271))))), ((V)(((FdLibm.Sin(((ToNum(i_280) * 0.37) + (ToNum(ph_272) * 2D))) * ToNum(amp_271)) * 0.6)))))).End()));
}, 1, "", true)), "join", ((V)("L")))).End()));
}, 3, "", true);
b_262.S(string.Concat("<path d=\"", ToStr(Invoke(Invoke(Arr(((V)(0.25)), ((V)(0.5)), ((V)(0.75))), "map", Fn((V _arrowThis290, int _argc282, V k_288, V i_289, V _a286, V _a287, V[] _rest283) => {
return Call(wav_263, V.Undef, Add(ya_255, ((V)(((ToNum(yb_256) - ToNum(ya_255)) * ToNum(k_288))))), ((V)((0.25 * ToNum(z1_258)))), Add(((V)((ToNum(t_249) * 9D))), i_289));
}, 2, "", true)), "join", ((V)("")))), "\" stroke=\"#97502b\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.4 * ToNum(z1_258)))))), "\" fill=\"none\" opacity=\"0.55\"/>")).S(string.Concat("<path d=\"", ToStr(Invoke(Invoke(Arr(((V)(0.35)), ((V)(0.7))), "map", Fn((V _arrowThis299, int _argc291, V k_297, V i_298, V _a295, V _a296, V[] _rest292) => {
return Call(wav_263, V.Undef, Add(y0_253, ((V)(((ToNum(ya_255) - ToNum(y0_253)) * ToNum(k_297))))), ((V)((0.3 * ToNum(z0_257)))), ((V)(((ToNum(t_249) * 5D) + (ToNum(i_298) * 2D)))));
}, 2, "", true)), "join", ((V)("")))), "\" stroke=\"#74391b\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.45 * ToNum(z0_257)))))), "\" fill=\"none\" opacity=\"0.5\"/>"));
Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis306, int _argc300, V _a302, V _a303, V _a304, V _a305, V[] _rest301) => {
double x_307 = 0;
V yk_308 = default;
x_307 = (ToNum(Get(G_224, "W")) * (0.05 + (ToNum(Call(Rb_261, V.Undef)) * 0.9)));
yk_308 = Add(ya_255, ((V)(((ToNum(yb_256) - ToNum(ya_255)) * (0.3 + (ToNum(Call(Rb_261, V.Undef)) * 0.4))))));
b_262.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, ((V)(x_307)))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, yk_308)), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((2.2 * ToNum(z1_258)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)(((ToNum(yb_256) - ToNum(ya_255)) * 0.2))))), "\" fill=\"#7a3d1e\" opacity=\"0.65\"/><ellipse cx=\"", ToStr(Call(f1_20, V.Undef, ((V)(x_307)))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, yk_308)), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((3.4 * ToNum(z1_258)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)(((ToNum(yb_256) - ToNum(ya_255)) * 0.3))))), "\" fill=\"none\" stroke=\"#8a4524\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.3 * ToNum(z1_258)))))), "\" opacity=\"0.5\"/>"));
return default;
}, 0, "", true));
Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis315, int _argc309, V _a311, V _a312, V _a313, V _a314, V[] _rest310) => {
double x_316 = 0;
V yk_317 = default;
x_316 = (ToNum(Get(G_224, "W")) * (0.05 + (ToNum(Call(Rb_261, V.Undef)) * 0.9)));
yk_317 = Add(y0_253, ((V)(((ToNum(ya_255) - ToNum(y0_253)) * (0.35 + (ToNum(Call(Rb_261, V.Undef)) * 0.3))))));
b_262.S(string.Concat("<path d=\"M", ToStr(Call(f1_20, V.Undef, ((V)(x_316)))), " ", ToStr(Call(f1_20, V.Undef, yk_317)), "l", ToStr(Call(f1_20, V.Undef, ((V)(((10D + (ToNum(Call(Rb_261, V.Undef)) * 14D)) * ToNum(z0_257)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((0.4 * ToNum(z0_257)))))), "\" stroke=\"#4e2410\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.45 * ToNum(z0_257)))))), "\" opacity=\"0.7\"/>"));
return default;
}, 0, "", true));
b_262.S(string.Concat("<path d=\"M", NumStr(XL_259), " ", ToStr(Call(f1_20, V.Undef, ya_255)), "H", ToStr(Add(((V)(XL_259)), XW_260)), "\" stroke=\"#da8f5e\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.6 * ToNum(z0_257)))))), "\"/>"));
Invoke(Arr(((V)(0.2)), ((V)(0.8))), "forEach", Fn((V _arrowThis325, int _argc318, V u_324, V _a321, V _a322, V _a323, V[] _rest319) => {
V x_326 = default;
x_326 = Invoke(G_224, "x", u_324, y0_253);
b_262.S(string.Concat("<rect x=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(x_326) - (2.4 * ToNum(z0_257))))))), "\" y=\"", ToStr(Call(f1_20, V.Undef, y0_253)), "\" width=\"", ToStr(Call(f1_20, V.Undef, ((V)((4.8 * ToNum(z0_257)))))), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(yb_256) - ToNum(y0_253)))))), "\" fill=\"#2c2724\"/><rect x=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(x_326) - (2.4 * ToNum(z0_257))))))), "\" y=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(ya_255) - (0.3 * ToNum(z0_257))))))), "\" width=\"", ToStr(Call(f1_20, V.Undef, ((V)((4.8 * ToNum(z0_257)))))), "\" height=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.6 * ToNum(z0_257)))))), "\" fill=\"#5a524b\"/>")).V(Invoke(Invoke(Arr(Arr(Add(y0_253, ((V)(((ToNum(ya_255) - ToNum(y0_253)) * 0.5))))), Arr(Add(ya_255, ((V)(((ToNum(yb_256) - ToNum(ya_255)) * 0.5)))))), "map", Fn((V _arrowThis336, int _argc327, V _a329, V _a330, V _a331, V _a332, V[] _rest328) => {
V yy_335 = default;
{ V _t333 = ListOf(_a329);
{ V _t334 = GetIdx(_t333, 0D);
yy_335 = _t334; }
}
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_20, V.Undef, x_326)), "\" cy=\"", ToStr(Call(f1_20, V.Undef, yy_335)), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.75 * ToNum(z0_257)))))), "\" fill=\"#6f665d\" stroke=\"#191614\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.2 * ToNum(z0_257)))))), "\"/>")));
}, 1, "", true)), "join", ((V)(""))));
return default;
}, 1, "", true));
return ((V)(b_262.Str));
return default;
}, 1, "", true);
Invoke(Arr(((V)(0.86)), ((V)(0.6)), ((V)(0.35)), ((V)(0.1))), "forEach", Fn((V _arrowThis344, int _argc337, V t_343, V _a340, V _a341, V _a342, V[] _rest338) => {
return ((V)(s_228.V(Call(beam_230, V.Undef, t_343)).Str));
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S(s_228.Str).V(Call(light_37, V.Undef, G_224, ((V)(0.26)), ((V)(0.05)))).V(Call(mould_35, V.Undef, G_224, ((V)(5.4)), Arr(((V)("#7f4524")), ((V)("#9c5a33")), ((V)("#b0683c"))), ((V)("#d18a5a")))).End()));
return default;
}, 1, "cBeam", false);
cMed_44 = Fn((V _self345, int _argc346, V G_352, V _a349, V _a350, V _a351, V[] _rest347) => {
JsStrBuf s_353 = null;
V frame_354 = default;
V crown_355 = default;
V B_356 = default;
double y0_357 = 0;
double y1_358 = 0;
double st_359 = 0;
JsStrBuf dn_360 = null;
if (_self345.IsNullish) _self345 = GlobalV;
s_353 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<path d=\"", ToStr(Get(G_352, "tr")), "\" fill=\"#f4eee1\"/>")).V(Call(blots_39, V.Undef, G_352, ((V)("md21")), ((V)(8D)), Arr(((V)("#fffcf4")), ((V)("#e9e0cc"))), ((V)(0.45)), ((V)(80D)))).End());
frame_354 = Fn((V _arrowThis373, int _argc361, V u0_367, V t0_368, V u1_369, V t1_370, V[] _rest362) => {
V d_374 = default;
V w_371 = default;
V gold_372 = default;
w_371 = (_argc361 > 4 ? _rest362[0] : V.Undef);
gold_372 = (_argc361 > 5 ? _rest362[1] : V.Undef);
d_374 = Invoke(G_352, "quad", u0_367, t0_368, u1_369, t1_370);
return ((V)(string.Concat(string.Concat("<path d=\"", ToStr(d_374), "\" fill=\"none\" stroke=\"#d2c6ab\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)(((ToNum(w_371) * 1.7) * ToNum(Get(G_352, "s"))))))), "\" transform=\"translate(", ToStr(Call(f1_20, V.Undef, ((V)((0.4 * ToNum(Get(G_352, "s"))))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((0.8 * ToNum(Get(G_352, "s"))))))), ")\"/><path d=\"", ToStr(d_374), "\" fill=\"none\" stroke=\"#fffdf8\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(w_371) * ToNum(Get(G_352, "s"))))))), "\"/>"), (Truthy(gold_372) ? string.Concat("<path d=\"", ToStr(d_374), "\" fill=\"none\" stroke=\"#c9a35a\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.4 * ToNum(Get(G_352, "s"))))))), "\"/>") : ""))));
return default;
}, 6, "", true);
s_353.V(Add(Call(frame_354, V.Undef, ((V)(0.045)), ((V)(0.06)), ((V)(0.955)), ((V)(0.965)), ((V)(1.8))), Call(frame_354, V.Undef, ((V)(0.085)), ((V)(0.14)), ((V)(0.915)), ((V)(0.925)), ((V)(1.2)), ((V)(1D)))));
Invoke(Arr(Arr(((V)(0.085)), ((V)(0.14))), Arr(((V)(0.915)), ((V)(0.14))), Arr(((V)(0.085)), ((V)(0.925))), Arr(((V)(0.915)), ((V)(0.925)))), "forEach", Fn((V _arrowThis386, int _argc375, V _a377, V _a378, V _a379, V _a380, V[] _rest376) => {
V P_387 = default;
V u_383 = default;
V t_385 = default;
{ V _t381 = ListOf(_a377);
{ V _t382 = GetIdx(_t381, 0D);
u_383 = _t382; }
{ V _t384 = GetIdx(_t381, 1D);
t_385 = _t384; }
}
P_387 = Call(E_31, V.Undef, G_352, u_383, t_385);
s_353.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Add(Get(P_387, "x"), ((V)((0.5 * ToNum(Get(P_387, "z")))))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, Add(Get(P_387, "y"), ((V)((0.6 * ToNum(Get(P_387, "z")))))))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((3.4 * ToNum(Get(P_387, "z"))))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)(((3.4 * ToNum(Get(P_387, "z"))) * ToNum(Get(P_387, "q"))))))), "\" fill=\"#cfc2a6\"/><ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Get(P_387, "x"))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, Get(P_387, "y"))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((3.4 * ToNum(Get(P_387, "z"))))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)(((3.4 * ToNum(Get(P_387, "z"))) * ToNum(Get(P_387, "q"))))))), "\" fill=\"#fffaf0\" stroke=\"#d8cdb4\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.35 * ToNum(Get(G_352, "s"))))))), "\"/><ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Get(P_387, "x"))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, Get(P_387, "y"))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((1.3 * ToNum(Get(P_387, "z"))))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)(((1.3 * ToNum(Get(P_387, "z"))) * ToNum(Get(P_387, "q"))))))), "\" fill=\"#c9a35a\"/>"));
return default;
}, 1, "", true));
{
V P_388 = default;
V z_389 = default;
V sq_390 = default;
double R0_391 = 0;
V pt_392 = default;
V PP_393 = default;
JsStrBuf m_394 = null;
double NL_395 = 0;
double hw_396 = 0;
JsStrBuf lv_397 = null;
JsStrBuf ls_398 = null;
JsStrBuf vn_399 = null;
JsStrBuf bd_400 = null;
JsStrBuf bs_401 = null;
JsStrBuf pe_402 = null;
P_388 = Call(E_31, V.Undef, G_352, ((V)(0.5)), ((V)(0.74)));
z_389 = Get(P_388, "z");
sq_390 = Get(P_388, "q");
R0_391 = 46D;
pt_392 = Fn((V _arrowThis411, int _argc403, V r_409, V a_410, V _a407, V _a408, V[] _rest404) => {
return Arr(Add(Get(P_388, "x"), ((V)((((FdLibm.Cos(ToNum(a_410)) * ToNum(r_409)) * R0_391) * ToNum(z_389))))), Add(Get(P_388, "y"), ((V)(((((FdLibm.Sin(ToNum(a_410)) * ToNum(r_409)) * R0_391) * ToNum(z_389)) * ToNum(sq_390))))));
}, 2, "", true);
PP_393 = Fn((V _arrowThis420, int _argc412, V r_418, V a_419, V _a416, V _a417, V[] _rest413) => {
return Call(P2_23, V.Undef, Call(pt_392, V.Undef, r_418, a_419));
}, 2, "", true);
m_394 = new JsStrBuf(string.Concat("<defs><radialGradient id=\"mdg\" cx=\"0.38\" cy=\"0.3\" r=\"0.75\"><stop offset=\"0\" stop-color=\"#ffffff\"/><stop offset=\"0.55\" stop-color=\"#f1e9d8\"/><stop offset=\"1\" stop-color=\"#d2c5a8\"/></radialGradient></defs>", ""));
m_394.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Add(Get(P_388, "x"), ((V)((1.2 * ToNum(z_389))))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, Add(Get(P_388, "y"), ((V)((1.6 * ToNum(z_389))))))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)(((R0_391 * 1.04) * ToNum(z_389)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((((R0_391 * 1.04) * ToNum(z_389)) * ToNum(sq_390)))))), "\" fill=\"#000000\" opacity=\"0.16\" filter=\"url(#cb3)\"/>"));
NL_395 = 26D;
hw_396 = ((PI_13 / NL_395) * 0.92);
lv_397 = new JsStrBuf("");
ls_398 = new JsStrBuf("");
vn_399 = new JsStrBuf("");
{
double i_421 = 0;
i_421 = 0D;
while (true) {
if (!((i_421 < NL_395))) break;
double a_423 = 0;
V d_424 = default;
double br_425 = 0;
a_423 = (((i_421 / NL_395) * 2D) * PI_13);
d_424 = ((V)(string.Concat("M", ToStr(Call(PP_393, V.Undef, ((V)(0.56)), ((V)((a_423 - hw_396))))), "Q", ToStr(Call(PP_393, V.Undef, ((V)(0.86)), ((V)((a_423 - (hw_396 * 1.15)))))), " ", ToStr(Call(PP_393, V.Undef, ((V)(1D)), ((V)(a_423)))), "Q", ToStr(Call(PP_393, V.Undef, ((V)(0.86)), ((V)((a_423 + (hw_396 * 1.15)))))), " ", ToStr(Call(PP_393, V.Undef, ((V)(0.56)), ((V)((a_423 + hw_396))))), "Z")));
br_425 = (1D - (0.07 * ((FdLibm.Cos(a_423) * 0.5) + (FdLibm.Sin(a_423) * 0.85))));
ls_398.V(d_424);
lv_397.S(string.Concat("<path d=\"", ToStr(d_424), "\" fill=\"", ToStr(Call(shade_11, V.Undef, ((V)("#fbf6ea")), ((V)(br_425)))), "\"/>"));
vn_399.S(string.Concat("M", ToStr(Call(PP_393, V.Undef, ((V)(0.6)), ((V)(a_423)))), "L", ToStr(Call(PP_393, V.Undef, ((V)(0.93)), ((V)(a_423))))));
i_421++;
}
}
m_394.S(string.Concat("<path d=\"", ls_398.Str, "\" fill=\"#cbbd9f\" transform=\"translate(", ToStr(Call(f1_20, V.Undef, ((V)((0.7 * ToNum(z_389)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((0.7 * ToNum(z_389)))))), ")\"/>")).S(lv_397.Str).S(string.Concat("<path d=\"", vn_399.Str, "\" stroke=\"#d5c8ac\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.35 * ToNum(z_389)))))), "\" fill=\"none\"/>"));
bd_400 = new JsStrBuf("");
bs_401 = new JsStrBuf("");
{
double i_426 = 0;
i_426 = 0D;
while (true) {
if (!((i_426 < 34D))) break;
V q_428 = default;
q_428 = Call(pt_392, V.Undef, ((V)(0.53)), ((V)((((i_426 / 34D) * 2D) * PI_13))));
bs_401.V(Call(dot_33, V.Undef, Add(GetIdx(q_428, 0D), ((V)((0.3 * ToNum(z_389))))), Add(GetIdx(q_428, 1D), ((V)((0.3 * ToNum(z_389))))), ((V)((0.9 * ToNum(z_389)))), ((V)(((0.9 * ToNum(z_389)) * 0.75)))));
bd_400.V(Call(dot_33, V.Undef, GetIdx(q_428, 0D), GetIdx(q_428, 1D), ((V)((0.9 * ToNum(z_389)))), ((V)(((0.9 * ToNum(z_389)) * 0.75)))));
i_426++;
}
}
m_394.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Get(P_388, "x"))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, Get(P_388, "y"))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)(((R0_391 * 0.5) * ToNum(z_389)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((((R0_391 * 0.5) * ToNum(z_389)) * ToNum(sq_390)))))), "\" fill=\"#e4d9c2\"/><path d=\"", bs_401.Str, "\" fill=\"#c7b999\"/><path d=\"", bd_400.Str, "\" fill=\"#fffaf0\"/>")).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Get(P_388, "x"))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(P_388, "y")) - (0.5 * ToNum(z_389))))))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)(((R0_391 * 0.42) * ToNum(z_389)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((((R0_391 * 0.42) * ToNum(z_389)) * ToNum(sq_390)))))), "\" fill=\"url(#mdg)\" stroke=\"#d6cab0\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.4 * ToNum(Get(G_352, "s"))))))), "\"/>"));
pe_402 = new JsStrBuf("");
{
double i_429 = 0;
i_429 = 0D;
while (true) {
if (!((i_429 < 8D))) break;
double a_431 = 0;
double h2_432 = 0;
a_431 = ((((i_429 / 8D) * 2D) * PI_13) + 0.2);
h2_432 = ((PI_13 / 8D) * 0.8);
pe_402.S(string.Concat("M", ToStr(Call(PP_393, V.Undef, ((V)(0.08)), ((V)(a_431)))), "Q", ToStr(Call(PP_393, V.Undef, ((V)(0.24)), ((V)((a_431 - h2_432))))), " ", ToStr(Call(PP_393, V.Undef, ((V)(0.31)), ((V)(a_431)))), "Q", ToStr(Call(PP_393, V.Undef, ((V)(0.24)), ((V)((a_431 + h2_432))))), " ", ToStr(Call(PP_393, V.Undef, ((V)(0.08)), ((V)(a_431)))), "Z"));
i_429++;
}
}
m_394.S(string.Concat("<g transform=\"translate(0 ", ToStr(Call(f1_20, V.Undef, ((V)(((-0.5) * ToNum(z_389)))))), ")\"><path d=\"", pe_402.Str, "\" fill=\"#efe6d3\" stroke=\"#d0c3a6\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.3 * ToNum(z_389)))))), "\"/><ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Get(P_388, "x"))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, Get(P_388, "y"))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)(((R0_391 * 0.075) * ToNum(z_389)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((((R0_391 * 0.075) * ToNum(z_389)) * ToNum(sq_390)))))), "\" fill=\"#fffdf8\" stroke=\"#c9a35a\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.4 * ToNum(z_389)))))), "\"/></g>"));
s_353.S(m_394.Str);
}
crown_355 = Call(mould_35, V.Undef, G_352, ((V)(7.5)), Arr(((V)("#e6ddca")), ((V)("#fbf8f1")), ((V)("#d4c9b1")), ((V)("#f6f0e4")), ((V)("#e1d6bf")), ((V)("#fffdf8"))), ((V)("#ffffff")));
B_356 = Call(band_34, V.Undef, G_352, ((V)(7.5)), ((V)(0.33)), ((V)(0.5)));
y0_357 = (ToNum(Get(G_352, "H")) - (ToNum(Get(B_356, "wb")) * 0.5));
y1_358 = (ToNum(Get(G_352, "H")) - (ToNum(Get(B_356, "wb")) * 0.33));
st_359 = (4.4 * ToNum(Invoke(G_352, "z", Get(G_352, "H"))));
dn_360 = new JsStrBuf("");
{
V x_433 = default;
x_433 = Add(Get(G_352, "ins"), ((V)((ToNum(Get(B_356, "wb")) * 0.8))));
while (true) {
if (!(LtN(x_433, (((ToNum(Get(G_352, "W")) - ToNum(Get(G_352, "ins"))) - (ToNum(Get(B_356, "wb")) * 0.8)) - (st_359 * 0.6))))) break;
dn_360.S(string.Concat("M", ToStr(Call(f1_20, V.Undef, x_433)), " ", ToStr(Call(f1_20, V.Undef, ((V)(y0_357)))), "h", ToStr(Call(f1_20, V.Undef, ((V)((st_359 * 0.62))))), "V", ToStr(Call(f1_20, V.Undef, ((V)(y1_358)))), "h", ToStr(Call(f1_20, V.Undef, ((V)(((-st_359) * 0.62))))), "Z"));
x_433 = Add(x_433, ((V)(st_359)));
}
}
return ((V)(JsStrBuf.Begin().S(s_353.Str).V(Call(light_37, V.Undef, G_352, ((V)(0.24)), ((V)(0.05)))).V(crown_355).S(string.Concat("<path d=\"", ToStr(Get(B_356, "back")), "\" fill=\"#bfb194\"/><path d=\"", dn_360.Str, "\" fill=\"#fffaf0\"/><path d=\"M", ToStr(Call(f1_20, V.Undef, Add(Get(G_352, "ins"), Get(B_356, "wb")))), " ", ToStr(Call(f1_20, V.Undef, ((V)((y1_358 + (0.3 * ToNum(Get(G_352, "s")))))))), "H", ToStr(Call(f1_20, V.Undef, ((V)(((ToNum(Get(G_352, "W")) - ToNum(Get(G_352, "ins"))) - ToNum(Get(B_356, "wb"))))))), "\" stroke=\"#c9a35a\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.4 * ToNum(Get(G_352, "s"))))))), "\"/>")).End()));
return default;
}, 1, "cMed", false);
cVault_45 = Fn((V _self435, int _argc436, V G_442, V _a439, V _a440, V _a441, V[] _rest437) => {
V VY_443 = default;
double u0_444 = 0;
double u1_445 = 0;
double t0_446 = 0;
double t1_447 = 0;
double m0_448 = 0;
double bmp_449 = 0;
V hi_450 = default;
V mu_451 = default;
V O_452 = default;
V TS_453 = default;
V US_454 = default;
JsStrBuf s_455 = null;
JsStrBuf v_456 = null;
V side_457 = default;
JsStrBuf rib_458 = null;
JsStrBuf ribH_459 = null;
V @base_460 = default;
V sw_461 = default;
if (_self435.IsNullish) _self435 = GlobalV;
VY_443 = Get(G_442, "VY");
u0_444 = 0.16;
u1_445 = 0.84;
t0_446 = 0.1;
t1_447 = 0.8;
m0_448 = 1.2;
bmp_449 = 0.28;
hi_450 = Fn((V _arrowThis471, int _argc462, V u_468, V t_469, V m_470, V _a467, V[] _rest463) => {
V y_472 = default;
y_472 = Invoke(G_442, "y", t_469);
return Arr(Invoke(G_442, "x", u_468, y_472), ((V)((ToNum(VY_443) - ((ToNum(VY_443) - ToNum(y_472)) * ToNum(m_470))))));
return default;
}, 3, "", true);
mu_451 = Fn((V _arrowThis480, int _argc473, V u_479, V _a476, V _a477, V _a478, V[] _rest474) => {
return ((V)((m0_448 + (bmp_449 * FdLibm.Sin((PI_13 * Min(1D, Max(0D, ((ToNum(u_479) - u0_444) / (u1_445 - u0_444))))))))));
}, 1, "", true);
O_452 = Invoke(G_442, "quad", ((V)(u0_444)), ((V)(t0_446)), ((V)(u1_445)), ((V)(t1_447)));
TS_453 = Call(rep_22, V.Undef, ((V)(13D)), Fn((V _arrowThis488, int _argc481, V i_487, V _a484, V _a485, V _a486, V[] _rest482) => {
return ((V)((t0_446 + (((t1_447 - t0_446) * ToNum(i_487)) / 12D))));
}, 1, "", true));
US_454 = Call(rep_22, V.Undef, ((V)(25D)), Fn((V _arrowThis496, int _argc489, V i_495, V _a492, V _a493, V _a494, V[] _rest490) => {
return ((V)((u0_444 + (((u1_445 - u0_444) * ToNum(i_495)) / 24D))));
}, 1, "", true));
s_455 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<path d=\"", ToStr(Get(G_442, "tr")), "\" fill=\"#f3f0ea\"/>")).V(Call(blots_39, V.Undef, G_442, ((V)("vt21")), ((V)(6D)), Arr(((V)("#ffffff")), ((V)("#e6e1d8"))), ((V)(0.45)), ((V)(80D)))).S(string.Concat("<path d=\"", ToStr(O_452), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((30D * ToNum(Get(G_442, "s"))))))), "\" opacity=\"0.6\" filter=\"url(#cb6)\"/>")).End());
v_456 = new JsStrBuf(string.Concat(string.Concat("<defs><linearGradient id=\"vsk\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#4a8fd9\"/><stop offset=\"0.65\" stop-color=\"#93c3ee\"/><stop offset=\"1\" stop-color=\"#d9edfb\"/></linearGradient><clipPath id=\"vop\"><path d=\"", ToStr(O_452), "\"/></clipPath>"), string.Concat("<linearGradient id=\"vfw\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#f7f4ee\"/><stop offset=\"1\" stop-color=\"#d9d3c8\"/></linearGradient></defs><rect x=\"0\" y=\"0\" width=\"", ToStr(Get(G_442, "W")), "\" height=\"", ToStr(Get(G_442, "H")), "\" fill=\"url(#vsk)\"/>")));
v_456.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_442, "W")) * 0.66))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_442, "H")) * 0.22))))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_442, "W")) * 0.08))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_442, "H")) * 0.2))))), "\" fill=\"#fffbe6\" opacity=\"0.75\" filter=\"url(#cb6)\"/>"));
v_456.S("<g filter=\"url(#cb3)\">").V(Invoke(Invoke(Arr(Arr(((V)(0.3)), ((V)(0.35)), ((V)(1D))), Arr(((V)(0.55)), ((V)(0.5)), ((V)(0.8))), Arr(((V)(0.75)), ((V)(0.3)), ((V)(0.9))), Arr(((V)(0.42)), ((V)(0.62)), ((V)(0.6))), Arr(((V)(0.2)), ((V)(0.55)), ((V)(0.7))), Arr(((V)(0.66)), ((V)(0.66)), ((V)(0.55)))), "map", Fn((V _arrowThis511, int _argc497, V _a499, V i_503, V _a501, V _a502, V[] _rest498) => {
double x_512 = 0;
double y_513 = 0;
double w_514 = 0;
V dx_515 = default;
V u_506 = default;
V h_508 = default;
V sz_510 = default;
{ V _t504 = ListOf(_a499);
{ V _t505 = GetIdx(_t504, 0D);
u_506 = _t505; }
{ V _t507 = GetIdx(_t504, 1D);
h_508 = _t507; }
{ V _t509 = GetIdx(_t504, 2D);
sz_510 = _t509; }
}
x_512 = (ToNum(Get(G_442, "W")) * ToNum(u_506));
y_513 = (ToNum(Get(G_442, "H")) * ToNum(h_508));
w_514 = ((ToNum(Get(G_442, "W")) * 0.05) * ToNum(sz_510));
dx_515 = Call(f1_20, V.Undef, ((V)(((ToNum(Get(G_442, "W")) * 0.05) * (NumTruthy((ToNum(i_503) % 2D)) ? (-1D) : 1D)))));
return ((V)(string.Concat("<g opacity=\"0.92\">", ToStr(Call(at_18, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;", ToStr(dx_515), " 0;0 0"))), ((V)((40D + (ToNum(i_503) * 7D)))), ((V)(((-ToNum(i_503)) * 6D))), Call(SPL_19, V.Undef, ((V)(2D))))), "<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, ((V)(x_512)))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, ((V)(y_513)))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)(w_514)))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((w_514 * 0.28))))), "\" fill=\"#ffffff\"/><ellipse cx=\"", ToStr(Call(f1_20, V.Undef, ((V)((x_512 - (w_514 * 0.5)))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, ((V)((y_513 + (w_514 * 0.05)))))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((w_514 * 0.6))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((w_514 * 0.2))))), "\" fill=\"#ffffff\"/><ellipse cx=\"", ToStr(Call(f1_20, V.Undef, ((V)((x_512 + (w_514 * 0.4)))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, ((V)((y_513 - (w_514 * 0.08)))))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((w_514 * 0.55))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((w_514 * 0.24))))), "\" fill=\"#f4f8fc\"/></g>")));
return default;
}, 2, "", true)), "join", ((V)("")))).S("</g>");
{
V z_516 = default;
double y_517 = 0;
double x0_518 = 0;
double x1_519 = 0;
V KT_520 = default;
z_516 = Invoke(G_442, "z", Invoke(G_442, "y", ((V)(0.5))));
y_517 = (ToNum(Get(G_442, "H")) * 0.42);
x0_518 = (ToNum(Get(G_442, "W")) * 0.12);
x1_519 = (ToNum(Get(G_442, "W")) * 0.9);
KT_520 = ((V)(" keyTimes=\"0;0.5;0.55;0.84;0.88;1\""));
v_456.S(string.Concat("<g opacity=\"0\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0;0;1;1;0;0")), ((V)(19D)), ((V)((-3D))), KT_520)), ToStr(Call(at_18, V.Undef, ((V)("translate")), ((V)(string.Concat(ToStr(Call(f1_20, V.Undef, ((V)(x0_518)))), " ", ToStr(Call(f1_20, V.Undef, ((V)(y_517)))), ";", ToStr(Call(f1_20, V.Undef, ((V)(x0_518)))), " ", ToStr(Call(f1_20, V.Undef, ((V)(y_517)))), ";", ToStr(Call(f1_20, V.Undef, ((V)((x0_518 + ((x1_519 - x0_518) * 0.1)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((y_517 - (2D * ToNum(z_516))))))), ";", ToStr(Call(f1_20, V.Undef, ((V)(x1_519)))), " ", ToStr(Call(f1_20, V.Undef, ((V)((y_517 - (9D * ToNum(z_516))))))), ";", ToStr(Call(f1_20, V.Undef, ((V)(x1_519)))), " ", ToStr(Call(f1_20, V.Undef, ((V)((y_517 - (9D * ToNum(z_516))))))), ";", ToStr(Call(f1_20, V.Undef, ((V)(x1_519)))), " ", ToStr(Call(f1_20, V.Undef, ((V)((y_517 - (9D * ToNum(z_516)))))))))), ((V)(19D)), ((V)((-3D))), KT_520)), "<g transform=\"scale(", ToStr(Call(n4_21, V.Undef, z_516)), ")\"><path d=\"M-3 0Q-1.5 -1.8 0 0Q1.5 -1.8 3 0\" stroke=\"#2c3a4a\" stroke-width=\"0.6\" fill=\"none\">", ToStr(Call(an_17, V.Undef, ((V)("d")), ((V)("M-3 0Q-1.5 -1.8 0 0Q1.5 -1.8 3 0;M-3 -1.2Q-1.5 0.6 0 0Q1.5 0.6 3 -1.2;M-3 0Q-1.5 -1.8 0 0Q1.5 -1.8 3 0")), ((V)(0.5)))), "</path></g></g>"));
}
side_457 = Fn((V _arrowThis529, int _argc521, V u_527, V col_528, V _a525, V _a526, V[] _rest522) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(TS_453, "map", Fn((V _arrowThis537, int _argc530, V t_536, V _a533, V _a534, V _a535, V[] _rest531) => {
return Call(P2_23, V.Undef, Call(hi_450, V.Undef, u_527, t_536, ((V)(1D))));
}, 1, "", true)), "join", ((V)("L")))), "L", ToStr(Invoke(Invoke(Invoke(Invoke(TS_453, "slice"), "reverse"), "map", Fn((V _arrowThis545, int _argc538, V t_544, V _a541, V _a542, V _a543, V[] _rest539) => {
return Call(P2_23, V.Undef, Call(hi_450, V.Undef, u_527, t_544, ((V)(m0_448))));
}, 1, "", true)), "join", ((V)("L")))), "Z\" fill=\"", ToStr(col_528), "\"/>")));
}, 2, "", true);
v_456.V(Add(Call(side_457, V.Undef, ((V)(u0_444)), ((V)("#ece8e0"))), Call(side_457, V.Undef, ((V)(u1_445)), ((V)("#d6d0c4"))))).S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(US_454, "map", Fn((V _arrowThis553, int _argc546, V u_552, V _a549, V _a550, V _a551, V[] _rest547) => {
return Call(P2_23, V.Undef, Call(hi_450, V.Undef, u_552, ((V)(t1_447)), ((V)(1D))));
}, 1, "", true)), "join", ((V)("L")))), "L", ToStr(Invoke(Invoke(Invoke(Invoke(US_454, "slice"), "reverse"), "map", Fn((V _arrowThis561, int _argc554, V u_560, V _a557, V _a558, V _a559, V[] _rest555) => {
return Call(P2_23, V.Undef, Call(hi_450, V.Undef, u_560, ((V)(t1_447)), ((V)(m0_448))));
}, 1, "", true)), "join", ((V)("L")))), "Z\" fill=\"url(#vfw)\"/>"));
v_456.S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(US_454, "map", Fn((V _arrowThis569, int _argc562, V u_568, V _a565, V _a566, V _a567, V[] _rest563) => {
return Call(P2_23, V.Undef, Call(hi_450, V.Undef, u_568, ((V)(t1_447)), ((V)(m0_448))));
}, 1, "", true)), "join", ((V)("L")))), "\" stroke=\"#c9a04a\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((1D * ToNum(Invoke(G_442, "z", Get(G_442, "H")))))))), "\" fill=\"none\"/>"));
v_456.S(string.Concat("<path d=\"M", ToStr(Invoke(G_442, "P", ((V)(u0_444)), ((V)(t0_446)))), "L", ToStr(Invoke(G_442, "P", ((V)(u0_444)), ((V)(t1_447)))), "L", ToStr(Invoke(G_442, "P", ((V)(u1_445)), ((V)(t1_447)))), "L", ToStr(Invoke(G_442, "P", ((V)(u1_445)), ((V)(t0_446)))), "\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.12\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((2D * ToNum(Get(G_442, "s"))))))), "\"/>"));
v_456.S(string.Concat("<rect x=\"", ToStr(Call(f1_20, V.Undef, ((V)(((-ToNum(Get(G_442, "W"))) * 0.4))))), "\" y=\"0\" width=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_442, "W")) * 0.12))))), "\" height=\"", ToStr(Get(G_442, "H")), "\" fill=\"#ffffff\" opacity=\"0.16\" transform=\"skewX(-25)\">", ToStr(Call(at_18, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;0 0;", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_442, "W")) * 1.7))))), " 0"))), ((V)(12D)), ((V)(0D)), ((V)(" keyTimes=\"0;0.55;1\"")))), "</rect>"));
rib_458 = new JsStrBuf("");
ribH_459 = new JsStrBuf("");
Invoke(Invoke(TS_453, "filter", Fn((V _arrowThis595, int _argc587, V __593, V i_594, V _a591, V _a592, V[] _rest588) => {
return (((ToNum(i_594) % 2D) == 0D) ? V.True : V.False);
}, 2, "", true)), "forEach", Fn((V _arrowThis577, int _argc570, V t_576, V _a573, V _a574, V _a575, V[] _rest571) => {
V d_578 = default;
d_578 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(US_454, "map", Fn((V _arrowThis586, int _argc579, V u_585, V _a582, V _a583, V _a584, V[] _rest580) => {
return Call(P2_23, V.Undef, Call(hi_450, V.Undef, u_585, t_576, Call(mu_451, V.Undef, u_585)));
}, 1, "", true)), "join", ((V)("L")))).End()));
rib_458.V(d_578);
return default;
}, 1, "", true));
Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis603, int _argc596, V j_602, V _a599, V _a600, V _a601, V[] _rest597) => {
double u_604 = 0;
V d_605 = default;
V g_606 = default;
u_604 = (u0_444 + (((u1_445 - u0_444) * ToNum(Add(j_602, ((V)(1D))))) / 6D));
d_605 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(TS_453, "map", Fn((V _arrowThis614, int _argc607, V t_613, V _a610, V _a611, V _a612, V[] _rest608) => {
return Call(P2_23, V.Undef, Call(hi_450, V.Undef, ((V)(u_604)), t_613, Call(mu_451, V.Undef, ((V)(u_604)))));
}, 1, "", true)), "join", ((V)("L")))).End()));
g_606 = ((V)(string.Concat("M", ToStr(Call(P2_23, V.Undef, Call(hi_450, V.Undef, ((V)(u_604)), ((V)(t1_447)), ((V)(m0_448))))), "L", ToStr(Call(P2_23, V.Undef, Call(hi_450, V.Undef, ((V)(u_604)), ((V)(t1_447)), Call(mu_451, V.Undef, ((V)(u_604)))))))));
rib_458.V(Add(d_605, g_606));
ribH_459.V(d_605);
return default;
}, 1, "", true));
@base_460 = ((V)(string.Concat("M", ToStr(Invoke(Invoke(TS_453, "map", Fn((V _arrowThis622, int _argc615, V t_621, V _a618, V _a619, V _a620, V[] _rest616) => {
return Call(P2_23, V.Undef, Call(hi_450, V.Undef, ((V)(u0_444)), t_621, ((V)(m0_448))));
}, 1, "", true)), "join", ((V)("L")))), "L", ToStr(Invoke(Invoke(US_454, "map", Fn((V _arrowThis630, int _argc623, V u_629, V _a626, V _a627, V _a628, V[] _rest624) => {
return Call(P2_23, V.Undef, Call(hi_450, V.Undef, u_629, ((V)(t1_447)), ((V)(m0_448))));
}, 1, "", true)), "join", ((V)("L")))), "L", ToStr(Invoke(Invoke(Invoke(Invoke(TS_453, "slice"), "reverse"), "map", Fn((V _arrowThis638, int _argc631, V t_637, V _a634, V _a635, V _a636, V[] _rest632) => {
return Call(P2_23, V.Undef, Call(hi_450, V.Undef, ((V)(u1_445)), t_637, ((V)(m0_448))));
}, 1, "", true)), "join", ((V)("L")))))));
sw_461 = Invoke(G_442, "z", Invoke(G_442, "y", ((V)(0.6))));
v_456.S(string.Concat("<path d=\"", rib_458.Str, "\" stroke=\"#7d8996\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((1.7 * ToNum(sw_461)))))), "\" fill=\"none\" stroke-linejoin=\"round\"/><path d=\"", rib_458.Str, "\" stroke=\"#f4f6f8\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.9 * ToNum(sw_461)))))), "\" fill=\"none\" stroke-linejoin=\"round\"/><path d=\"", ribH_459.Str, "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.3 * ToNum(sw_461)))))), "\" fill=\"none\" transform=\"translate(", ToStr(Call(f1_20, V.Undef, ((V)(((-0.3) * ToNum(sw_461)))))), " 0)\"/>")).S(string.Concat("<path d=\"", ToStr(@base_460), "\" stroke=\"#8c96a0\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((2.6 * ToNum(sw_461)))))), "\" fill=\"none\"/><path d=\"", ToStr(@base_460), "\" stroke=\"#fbfbfa\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((1.6 * ToNum(sw_461)))))), "\" fill=\"none\"/>"));
s_455.S(string.Concat("<g clip-path=\"url(#vop)\">", v_456.Str, "</g>"));
s_455.S(string.Concat("<path d=\"", ToStr(O_452), "\" fill=\"none\" stroke=\"#9e7424\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((3.4 * ToNum(Get(G_442, "s"))))))), "\"/><path d=\"", ToStr(O_452), "\" fill=\"none\" stroke=\"#e2b552\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((2D * ToNum(Get(G_442, "s"))))))), "\"/><path d=\"", ToStr(O_452), "\" fill=\"none\" stroke=\"#fff0b8\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(Get(G_442, "s"))))))), "\" transform=\"translate(0 ", ToStr(Call(f1_20, V.Undef, ((V)(((-0.5) * ToNum(Get(G_442, "s"))))))), ")\"/>"));
return ((V)(JsStrBuf.Begin().S(s_455.Str).V(Call(light_37, V.Undef, G_442, ((V)(0.16)), ((V)(0.04)))).V(Call(mould_35, V.Undef, G_442, ((V)(4.4)), Arr(((V)("#ddd8cf")), ((V)("#f6f3ee")), ((V)("#ebe7e0"))), ((V)("#ffffff")), ((V)(string.Concat("<path d=\"", ToStr(Get(Call(band_34, V.Undef, G_442, ((V)(4.4)), ((V)(0D)), ((V)(1D))), "lip")), "\" stroke=\"#d4a548\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(Get(G_442, "s"))))))), "\" fill=\"none\" transform=\"translate(0 ", ToStr(Call(f1_20, V.Undef, ((V)((0.6 * ToNum(Get(G_442, "s"))))))), ")\"/>"))))).End()));
return default;
}, 1, "cVault", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((((RD_8 is var _t639 && !Truthy(_t639) ? _t639 : Get(RD_8, "PLUS20")) is var _t640 && !Truthy(_t640) ? _t640 : Get(RD_8, "H14")) is var _t641 && !Truthy(_t641) ? _t641 : Get(RD_8, "H11")) is var _t642 && !Truthy(_t642) ? _t642 : Get(RD_8, "H10")) is var _t643 && !Truthy(_t643) ? _t643 : X_9) is var _t644 && !Truthy(_t644) ? _t644 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_645.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS21"))) {
return default;
}
K_10 = Get(X_9, "K");
shade_11 = Get(K_10, "shade");
N_12 = Get(RD_8, "N");
PI_13 = System.Math.PI;
H_14 = Get(RD_8, "H10");
{ V _t646 = H_14;
if (_t646.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t646));
{ V _t647 = Get(_t646, "cam");
cam_15 = _t647; }
{ V _t648 = Get(_t646, "rng");
rng_16 = _t648; }
{ V _t649 = Get(_t646, "an");
an_17 = _t649; }
{ V _t650 = Get(_t646, "at");
at_18 = _t650; }
{ V _t651 = Get(_t646, "SPL");
SPL_19 = _t651; }
{ V _t652 = Get(_t646, "f1");
f1_20 = _t652; }
{ V _t653 = Get(_t646, "n4");
n4_21 = _t653; }
{ V _t654 = Get(_t646, "rep");
rep_22 = _t654; }
{ V _t655 = Get(_t646, "P2");
P2_23 = _t655; } }
{ V _t656 = Get(RD_8, "H11");
if (_t656.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t656));
{ V _t657 = Get(_t656, "DEF11");
DEF11_24 = _t657; }
{ V _t658 = Get(_t656, "zsort");
zsort_25 = _t658; } }
box3_26 = Fn((V _arrowThis667, int _argc659, V C_665, V o_666, V _a663, V _a664, V[] _rest660) => {
return Invoke(H_14, "box3", C_665, Object_assign(NewObj(0).V, o_666, NewObj(7).Put("mat", V.Null).Put("tpat", V.Null).Put("gl", ((V)((Truthy(Get(o_666, "gl")) ? Min(ToNum(Get(o_666, "gl")), 0.2) : 0D)))).Put("olw", ((V)(1D))).Put("olo", ((V)(0.95))).Put("olc", Call(shade_11, V.Undef, Get(o_666, "col"), ((V)(0.32)))).Put("edge", ((V)(0.5))).V));
}, 2, "", true);
cyl3_27 = Fn((V _arrowThis680, int _argc668, V C_674, V a_675, V b_676, V r_677, V[] _rest669) => {
V col_678 = default;
V o_679 = default;
col_678 = (_argc668 > 4 ? _rest669[0] : V.Undef);
o_679 = (_argc668 > 5 ? _rest669[1] : V.Undef);
return Invoke(H_14, "cyl3", C_674, a_675, b_676, r_677, col_678, Object_assign(NewObj(0).V, (o_679 is var _t681 && Truthy(_t681) ? _t681 : NewObj(0).V), NewObj(4).Put("mat", ((V)((Truthy((o_679 is var _t682 && !Truthy(_t682) ? _t682 : (SEqS(Get(o_679, "mat"), "gloss") ? V.True : V.False))) ? "gloss" : "plastic")))).Put("pat", V.Null).Put("olw", (Truthy((o_679 is var _t683 && !Truthy(_t683) ? _t683 : (!Get(o_679, "olw").IsNullish ? V.True : V.False))) ? Get(o_679, "olw") : ((V)(0.8)))).Put("olo", ((V)(0.95))).V));
}, 6, "", true);
sph_28 = Fn((V _arrowThis695, int _argc684, V C_690, V q_691, V r_692, V col_693, V[] _rest685) => {
V c_696 = default;
V o_694 = default;
o_694 = (_argc684 > 4 ? _rest685[0] : V.Undef);
c_696 = Invoke(C_690, "P", q_691);
return ((V)(JsStrBuf.Begin().V(Invoke(H_14, "sph", C_690, q_691, r_692, col_693, o_694)).S(string.Concat("<circle cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(c_696, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(c_696, 1D))), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(r_692) * ToNum(Get(C_690, "k"))))))), "\" fill=\"none\" stroke=\"", ToStr(Call(shade_11, V.Undef, col_693, ((V)(0.35)))), "\" stroke-width=\"0.5\"/>")).End()));
return default;
}, 5, "", true);
mkV_29 = Fn((V _arrowThis704, int _argc697, V F_703, V _a700, V _a701, V _a702, V[] _rest698) => {
V G_705 = default;
G_705 = Invoke(Get(RD_8, "H14"), "mk", F_703);
Set(G_705, "VY", ((V)(((ToNum(Get(G_705, "H")) * ToNum(Get(G_705, "W"))) / (2D * ToNum(Get(G_705, "ins")))))));
return G_705;
return default;
}, 1, "", true);
FRM_30 = Get(Get(RD_8, "H14"), "FRM");
E_31 = Fn((V _arrowThis715, int _argc706, V G_712, V u_713, V t_714, V _a711, V[] _rest707) => {
V y_716 = default;
y_716 = Invoke(G_712, "y", t_714);
return NewObj(4).Put("x", Invoke(G_712, "x", u_713, y_716)).Put("y", y_716).Put("z", Invoke(G_712, "z", y_716)).Put("q", ((V)((0.28 + (0.22 * (1D - (ToNum(y_716) / ToNum(Get(G_712, "H"))))))))).V;
return default;
}, 3, "", true);
lo_32 = Fn((V _arrowThis726, int _argc717, V G_723, V y_724, V dd_725, V _a722, V[] _rest718) => {
return Add(y_724, ((V)(((ToNum(Get(G_723, "VY")) - ToNum(y_724)) * ToNum(dd_725)))));
}, 3, "", true);
dot_33 = Fn((V _arrowThis737, int _argc727, V x_733, V y_734, V rx_735, V ry_736, V[] _rest728) => {
return ((V)(string.Concat("M", ToStr(Call(n4_21, V.Undef, ((V)((ToNum(x_733) - ToNum(rx_735)))))), " ", ToStr(Call(n4_21, V.Undef, y_734)), "a", ToStr(Call(n4_21, V.Undef, rx_735)), " ", ToStr(Call(n4_21, V.Undef, ry_736)), " 0 1 0 ", ToStr(Call(n4_21, V.Undef, ((V)((2D * ToNum(rx_735)))))), " 0a", ToStr(Call(n4_21, V.Undef, rx_735)), " ", ToStr(Call(n4_21, V.Undef, ry_736)), " 0 1 0 ", ToStr(Call(n4_21, V.Undef, ((V)(((-2D) * ToNum(rx_735)))))), " 0")));
}, 4, "", true);
band_34 = Fn((V _arrowThis748, int _argc738, V G_744, V bw_745, V a_746, V b_747, V[] _rest739) => {
double n_749 = 0;
V w_750 = default;
V L_751 = default;
V R_752 = default;
V sh_753 = default;
V wb_754 = default;
n_749 = 12D;
w_750 = Fn((V _arrowThis762, int _argc755, V y_761, V _a758, V _a759, V _a760, V[] _rest756) => {
return ((V)((ToNum(bw_745) * ToNum(Invoke(G_744, "z", y_761)))));
}, 1, "", true);
L_751 = Arr();
R_752 = Arr();
{
double i_763 = 0;
i_763 = 0D;
while (true) {
if (!((i_763 <= n_749))) break;
double y_765 = 0;
y_765 = ((ToNum(Get(G_744, "H")) * i_763) / n_749);
Invoke(L_751, "push", Arr(Invoke(G_744, "x", ((V)(0D)), ((V)(y_765))), ((V)(y_765))));
Invoke(R_752, "push", Arr(Invoke(G_744, "x", ((V)(1D)), ((V)(y_765))), ((V)(y_765))));
i_763++;
}
}
sh_753 = Fn((V _arrowThis775, int _argc766, V P_772, V sg_773, V f_774, V _a771, V[] _rest767) => {
return Invoke(P_772, "map", Fn((V _arrowThis787, int _argc776, V _a778, V _a779, V _a780, V _a781, V[] _rest777) => {
V x_784 = default;
V y_786 = default;
{ V _t782 = ListOf(_a778);
{ V _t783 = GetIdx(_t782, 0D);
x_784 = _t783; }
{ V _t785 = GetIdx(_t782, 1D);
y_786 = _t785; }
}
return Arr(Add(x_784, ((V)((((ToNum(sg_773) * ToNum(Call(w_750, V.Undef, y_786))) * 1.6) * ToNum(f_774))))), y_786);
}, 1, "", true));
}, 3, "", true);
wb_754 = Call(w_750, V.Undef, Get(G_744, "H"));
return NewObj(5).Put("back", ((V)(string.Concat("M", ToStr(Call(f1_20, V.Undef, Add(Get(G_744, "ins"), ((V)(((ToNum(wb_754) * 1.6) * ToNum(a_746))))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_744, "H")) - (ToNum(wb_754) * ToNum(b_747))))))), "H", ToStr(Call(f1_20, V.Undef, ((V)(((ToNum(Get(G_744, "W")) - ToNum(Get(G_744, "ins"))) - ((ToNum(wb_754) * 1.6) * ToNum(a_746))))))), "V", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_744, "H")) - (ToNum(wb_754) * ToNum(a_746))))))), "H", ToStr(Call(f1_20, V.Undef, Add(Get(G_744, "ins"), ((V)(((ToNum(wb_754) * 1.6) * ToNum(a_746))))))), "Z")))).Put("l", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Call(sh_753, V.Undef, L_751, ((V)(1D)), a_746), "map", P2_23), "join", ((V)("L")))).S("L").V(Invoke(Invoke(Invoke(Call(sh_753, V.Undef, L_751, ((V)(1D)), b_747), "reverse"), "map", P2_23), "join", ((V)("L")))).S("Z").End()))).Put("r", ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Call(sh_753, V.Undef, R_752, ((V)((-1D))), a_746), "map", P2_23), "join", ((V)("L")))).S("L").V(Invoke(Invoke(Invoke(Call(sh_753, V.Undef, R_752, ((V)((-1D))), b_747), "reverse"), "map", P2_23), "join", ((V)("L")))).S("Z").End()))).Put("lip", ((V)(JsStrBuf.Begin().S(string.Concat("M", ToStr(Call(f1_20, V.Undef, Add(Get(G_744, "ins"), ((V)(((ToNum(wb_754) * 1.6) * ToNum(b_747))))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(G_744, "H")) - (ToNum(wb_754) * ToNum(b_747))))))), "H", ToStr(Call(f1_20, V.Undef, ((V)(((ToNum(Get(G_744, "W")) - ToNum(Get(G_744, "ins"))) - ((ToNum(wb_754) * 1.6) * ToNum(b_747))))))), "M")).V(Invoke(Invoke(Call(sh_753, V.Undef, L_751, ((V)(1D)), b_747), "map", P2_23), "join", ((V)("L")))).S("M").V(Invoke(Invoke(Call(sh_753, V.Undef, R_752, ((V)((-1D))), b_747), "map", P2_23), "join", ((V)("L")))).End()))).Put("wb", wb_754).V;
return default;
}, 4, "", true);
mould_35 = Fn((V _arrowThis799, int _argc788, V G_794, V bw_795, V cols_796, V lip_797, V[] _rest789) => {
JsStrBuf s_800 = null;
V B_801 = default;
V ex_798 = default;
ex_798 = (_argc788 > 4 ? _rest789[0] : V.Undef);
s_800 = new JsStrBuf("");
Invoke(cols_796, "forEach", Fn((V _arrowThis810, int _argc802, V c_808, V i_809, V _a806, V _a807, V[] _rest803) => {
V B_811 = default;
B_811 = Call(band_34, V.Undef, G_794, bw_795, ((V)((ToNum(i_809) / ToNum(Get(cols_796, "length"))))), ((V)((ToNum(Add(i_809, ((V)(1D)))) / ToNum(Get(cols_796, "length"))))));
s_800.S(string.Concat("<path d=\"", ToStr(Get(B_811, "back")), "\" fill=\"", ToStr(c_808), "\"/><path d=\"", ToStr(Get(B_811, "l")), "\" fill=\"", ToStr(Call(shade_11, V.Undef, c_808, ((V)(0.94)))), "\"/><path d=\"", ToStr(Get(B_811, "r")), "\" fill=\"", ToStr(Call(shade_11, V.Undef, c_808, ((V)(0.87)))), "\"/>"));
return default;
}, 2, "", true));
B_801 = Call(band_34, V.Undef, G_794, bw_795, ((V)(0D)), ((V)(1D)));
return ((V)(JsStrBuf.Begin().S(string.Concat("<path d=\"", ToStr(Get(B_801, "lip")), "\" stroke=\"#000000\" stroke-opacity=\"0.12\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((1.6 * ToNum(Get(G_794, "s"))))))), "\" fill=\"none\" transform=\"translate(0 ", ToStr(Call(f1_20, V.Undef, ((V)((0.8 * ToNum(Get(G_794, "s"))))))), ")\"/>")).S(s_800.Str).S(string.Concat("<path d=\"", ToStr(Get(B_801, "lip")), "\" stroke=\"", ToStr(lip_797), "\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.8 * ToNum(Get(G_794, "s"))))))), "\" fill=\"none\"/>")).V((ex_798 is var _t812 && Truthy(_t812) ? _t812 : ((V)("")))).End()));
return default;
}, 5, "", true);
trim_36 = Fn((V _arrowThis823, int _argc813, V G_819, V bw_820, V col_821, V ex_822, V[] _rest814) => {
return Call(mould_35, V.Undef, G_819, bw_820, Arr(col_821), Call(shade_11, V.Undef, col_821, ((V)(1.4))), ex_822);
}, 4, "", true);
light_37 = Fn((V _arrowThis833, int _argc824, V G_830, V a_831, V b_832, V _a829, V[] _rest825) => {
return ((V)(JsStrBuf.Begin().S("<defs><linearGradient id=\"csh\" x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"><stop offset=\"0\" stop-color=\"#000000\" stop-opacity=\"").V(a_831).S("\"/><stop offset=\"0.7\" stop-color=\"#000000\" stop-opacity=\"0\"/><stop offset=\"0.92\" stop-color=\"#ffffff\" stop-opacity=\"").V((b_832 is var _t834 && Truthy(_t834) ? _t834 : ((V)(0.05)))).S("\"/><stop offset=\"1\" stop-color=\"#ffffff\" stop-opacity=\"0\"/></linearGradient></defs><path d=\"").V(Get(G_830, "tr")).S("\" fill=\"url(#csh)\"/>").End()));
}, 3, "", true);
doc_38 = Fn((V _arrowThis843, int _argc835, V G_841, V body_842, V _a839, V _a840, V[] _rest836) => {
return ((V)(JsStrBuf.Begin().S("<defs><clipPath id=\"ctc\"><path d=\"").V(Get(G_841, "tr")).S("\"/></clipPath>").V(Invoke(G_841, "b", ((V)(1D)))).V(Invoke(G_841, "b", ((V)(3D)))).V(Invoke(G_841, "b", ((V)(6D)))).S("</defs><g clip-path=\"url(#ctc)\">").V(body_842).S("</g>").End()));
}, 2, "", true);
blots_39 = Fn((V _arrowThis856, int _argc844, V G_850, V sd_851, V n_852, V cols_853, V[] _rest845) => {
V R_857 = default;
V op_854 = default;
V w_855 = default;
op_854 = (_argc844 > 4 ? _rest845[0] : V.Undef);
w_855 = (_argc844 > 5 ? _rest845[1] : V.Undef);
R_857 = Call(rng_16, V.Undef, sd_851);
return ((V)(JsStrBuf.Begin().S(string.Concat("<g filter=\"url(#cb6)\" opacity=\"", ToStr(op_854), "\">")).V(Invoke(Call(rep_22, V.Undef, n_852, Fn((V _arrowThis865, int _argc858, V i_864, V _a861, V _a862, V _a863, V[] _rest859) => {
double t_866 = 0;
V y_867 = default;
V z_868 = default;
t_866 = (0.05 + (ToNum(Call(R_857, V.Undef)) * 0.92));
y_867 = Invoke(G_850, "y", ((V)(t_866)));
z_868 = Invoke(G_850, "z", y_867);
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Invoke(G_850, "x", ((V)(((ToNum(Call(R_857, V.Undef)) * 1.1) - 0.05))), y_867))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, y_867)), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Add(w_855, ((V)((ToNum(Call(R_857, V.Undef)) * ToNum(w_855)))))) * ToNum(z_868)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)(((4D + (ToNum(Call(R_857, V.Undef)) * 5D)) * ToNum(z_868)))))), "\" fill=\"", ToStr(GetIdx(cols_853, (ToNum(i_864) % ToNum(Get(cols_853, "length"))))), "\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g>").End()));
return default;
}, 6, "", true);
web_40 = Fn((V _arrowThis880, int _argc869, V G_875, V u_876, V t_877, V r_878, V[] _rest870) => {
V y_881 = default;
V x_882 = default;
double z_883 = 0;
V A_884 = default;
double sx_885 = 0;
V d_886 = default;
V fl_879 = default;
fl_879 = (_argc869 > 4 ? _rest870[0] : V.Undef);
y_881 = Invoke(G_875, "y", t_877);
x_882 = Invoke(G_875, "x", u_876, y_881);
z_883 = (ToNum(Invoke(G_875, "z", y_881)) * ToNum(r_878));
A_884 = Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis894, int _argc887, V k_893, V _a890, V _a891, V _a892, V[] _rest888) => {
return ((V)((((ToNum(k_893) / 5D) * PI_13) / 2D)));
}, 1, "", true));
sx_885 = (Truthy(fl_879) ? (-1D) : 1D);
d_886 = Invoke(Invoke(A_884, "map", Fn((V _arrowThis902, int _argc895, V a_901, V _a898, V _a899, V _a900, V[] _rest896) => {
return ((V)(JsStrBuf.Begin().S("M").V(Call(f1_20, V.Undef, x_882)).S(" ").V(Call(f1_20, V.Undef, y_881)).S("l").V(Call(f1_20, V.Undef, ((V)((((sx_885 * FdLibm.Cos(ToNum(a_901))) * 9D) * z_883))))).S(" ").V(Call(f1_20, V.Undef, ((V)((((-FdLibm.Sin(ToNum(a_901))) * 5D) * z_883))))).End()));
}, 1, "", true)), "join", ((V)("")));
Invoke(Arr(((V)(0.35)), ((V)(0.65)), ((V)(0.95))), "forEach", Fn((V _arrowThis910, int _argc903, V k_909, V _a906, V _a907, V _a908, V[] _rest904) => {
d_886 = ((V)(JsStrBuf.Begin().V(d_886).S("M").V(Invoke(Invoke(A_884, "map", Fn((V _arrowThis918, int _argc911, V a_917, V _a914, V _a915, V _a916, V[] _rest912) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_20, V.Undef, Add(x_882, ((V)(((((sx_885 * FdLibm.Cos(ToNum(a_917))) * 9D) * z_883) * ToNum(k_909))))))).S(" ").V(Call(f1_20, V.Undef, ((V)((ToNum(y_881) - (((FdLibm.Sin(ToNum(a_917)) * 5D) * z_883) * ToNum(k_909))))))).End()));
}, 1, "", true)), "join", ((V)("L")))).End()));
return default;
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(d_886).S("\" stroke=\"#fbf8f0\" stroke-opacity=\"0.7\" stroke-width=\"").V(Call(f1_20, V.Undef, ((V)((0.35 * ToNum(Get(G_875, "s"))))))).S("\" fill=\"none\"/>").End()));
return default;
}, 5, "", true);
WALLC_46 = NewObj(5).Put("pop", ((V)("#ebe2ca"))).Put("cove", ((V)("#9caf8b"))).Put("beam", ((V)("#eee2c6"))).Put("med", ((V)("#b98a58"))).Put("vault", ((V)("#f2efea"))).V;
CBASE_47 = NewObj(5).Put("pop", Arr(((V)("#e6dbbd")), ((V)("#e2d5b2")))).Put("cove", Arr(((V)("#f2eee5")), ((V)("#efeae0")))).Put("beam", Arr(((V)("#e9e0cf")), ((V)("#9c5a33")))).Put("med", Arr(((V)("#f4eee1")), ((V)("#f6f0e4")))).Put("vault", Arr(((V)("#f3f0ea")), ((V)("#ebe7e0")))).V;
CEIL21_48 = NewObj(5).Put("pop", cPop_41).Put("cove", cCove_42).Put("beam", cBeam_43).Put("med", cMed_44).Put("vault", cVault_45).V;
cardOf_49 = Fn((V _arrowThis926, int _argc919, V k_925, V _a922, V _a923, V _a924, V[] _rest920) => {
V G_927 = default;
V w_928 = default;
G_927 = Call(mkV_29, V.Undef, Get(FRM_30, "card"));
w_928 = GetK(WALLC_46, k_925);
return ((V)(JsStrBuf.Begin().S("<path d=\"M16 26H64V56H16Z\" fill=\"").V(w_928).S("\"/><path d=\"M0 0L16 26V56H0Z\" fill=\"").V(Call(shade_11, V.Undef, w_928, ((V)(0.88)))).S("\"/><path d=\"M80 0L64 26V56H80Z\" fill=\"").V(Call(shade_11, V.Undef, w_928, ((V)(0.8)))).S("\"/><path d=\"M16 26V56M64 26V56\" stroke=\"#000000\" stroke-opacity=\"0.2\" stroke-width=\"0.6\"/>").V(Call(doc_38, V.Undef, G_927, InvokeK(CEIL21_48, k_925, G_927))).S("<path d=\"").V(Get(G_927, "tr")).S("\" fill=\"none\" stroke=\"#000000\" stroke-opacity=\"0.25\" stroke-width=\"0.5\"/>").End()));
return default;
}, 1, "", true);
DEF21_50 = ((V)(JsStrBuf.Begin().V(DEF11_24).S("<filter id=\"l21b1\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"0.8\"/></filter><filter id=\"l21b3\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feGaussianBlur stdDeviation=\"3\"/></filter>").S("<radialGradient id=\"l21w\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff0c0\" stop-opacity=\"0.85\"/><stop offset=\"0.35\" stop-color=\"#ffd27a\" stop-opacity=\"0.35\"/><stop offset=\"1\" stop-color=\"#ffc060\" stop-opacity=\"0\"/></radialGradient>").S("<radialGradient id=\"l21c\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#eef8ff\" stop-opacity=\"0.85\"/><stop offset=\"0.35\" stop-color=\"#9fd6ff\" stop-opacity=\"0.3\"/><stop offset=\"1\" stop-color=\"#7ab8ff\" stop-opacity=\"0\"/></radialGradient>").S("<linearGradient id=\"l21m\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0.3\"><stop offset=\"0\" stop-color=\"#f3dcb8\" stop-opacity=\"0.85\"/><stop offset=\"0.45\" stop-color=\"#c49a6e\" stop-opacity=\"0.62\"/><stop offset=\"1\" stop-color=\"#6a4c36\" stop-opacity=\"0.8\"/></linearGradient>").End()));
glow_51 = Fn((V _arrowThis941, int _argc929, V C_935, V q_936, V r_937, V op_938, V[] _rest930) => {
V c_942 = default;
V A_939 = default;
V g_940 = default;
A_939 = (_argc929 > 4 ? _rest930[0] : V.Undef);
g_940 = (_argc929 > 5 ? _rest930[1] : V.Undef);
c_942 = Invoke(C_935, "P", q_936);
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(c_942, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(c_942, 1D))), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(r_937) * ToNum(Get(C_935, "k"))))))), "\" fill=\"url(#", ToStr((g_940 is var _t943 && Truthy(_t943) ? _t943 : ((V)("l21w")))), ")\" opacity=\"", ToStr(op_938), "\">", ToStr((A_939 is var _t944 && Truthy(_t944) ? _t944 : ((V)("")))), "</circle>")));
return default;
}, 6, "", true);
ring_52 = Fn((V _arrowThis957, int _argc945, V C_951, V y_952, V r_953, V a0_954, V[] _rest946) => {
V a1_955 = default;
V n_956 = default;
a1_955 = (_argc945 > 4 ? _rest946[0] : V.Undef);
n_956 = (_argc945 > 5 ? _rest946[1] : V.Undef);
return Call(rep_22, V.Undef, Add(n_956, ((V)(1D))), Fn((V _arrowThis965, int _argc958, V i_964, V _a961, V _a962, V _a963, V[] _rest959) => {
V a_966 = default;
a_966 = Add(a0_954, ((V)((((ToNum(a1_955) - ToNum(a0_954)) * ToNum(i_964)) / ToNum(n_956)))));
return Invoke(C_951, "p", ((V)((ToNum(r_953) * FdLibm.Sin(ToNum(a_966))))), y_952, ((V)((ToNum(r_953) * FdLibm.Cos(ToNum(a_966))))));
return default;
}, 1, "", true));
}, 6, "", true);
swing_53 = Fn((V _arrowThis978, int _argc967, V C_973, V q_974, V deg_975, V T_976, V[] _rest968) => {
V c_979 = default;
V b_977 = default;
b_977 = (_argc967 > 4 ? _rest968[0] : V.Undef);
c_979 = Invoke(C_973, "P", q_974);
return ((V)(string.Concat("<animateTransform attributeName=\"transform\" type=\"rotate\" values=\"", NumStr((-ToNum(deg_975))), " ", ToStr(Call(P2_23, V.Undef, c_979)), ";", ToStr(deg_975), " ", ToStr(Call(P2_23, V.Undef, c_979)), ";", NumStr((-ToNum(deg_975))), " ", ToStr(Call(P2_23, V.Undef, c_979)), "\" dur=\"", ToStr(Call(n4_21, V.Undef, T_976)), "s\" begin=\"", ToStr(Call(n4_21, V.Undef, (b_977 is var _t980 && Truthy(_t980) ? _t980 : ((V)(0D))))), "s\" repeatCount=\"indefinite\"", ToStr(Call(SPL_19, V.Undef, ((V)(2D)))), "/>")));
return default;
}, 5, "", true);
FLK_54 = Fn((V _arrowThis989, int _argc981, V T_987, V b_988, V _a985, V _a986, V[] _rest982) => {
return Call(an_17, V.Undef, ((V)("opacity")), ((V)("1;0.88;1;0.66;1;1")), T_987, b_988, ((V)(" keyTimes=\"0;0.3;0.45;0.5;0.56;1\"")));
}, 2, "", true);
ellOf_55 = Fn((V _arrowThis999, int _argc990, V C_996, V y_997, V r_998, V _a995, V[] _rest991) => {
V c_1000 = default;
V f_1001 = default;
c_1000 = Invoke(C_996, "P", Arr(((V)(0D)), y_997, ((V)(0D))));
f_1001 = Invoke(C_996, "P", Arr(((V)((ToNum(r_998) * FdLibm.Sin(ToNum(Get(C_996, "thV")))))), y_997, ((V)((ToNum(r_998) * FdLibm.Cos(ToNum(Get(C_996, "thV"))))))));
Invoke(C_996, "P", Arr(r_998, y_997, ((V)(0D))));
Invoke(C_996, "P", Arr(((V)((-ToNum(r_998)))), y_997, ((V)(0D))));
Invoke(C_996, "P", Arr(((V)(0D)), y_997, r_998));
Invoke(C_996, "P", Arr(((V)(0D)), y_997, ((V)((-ToNum(r_998))))));
return NewObj(4).Put("x", GetIdx(c_1000, 0D)).Put("y", GetIdx(c_1000, 1D)).Put("rx", ((V)((ToNum(r_998) * ToNum(Get(C_996, "k")))))).Put("ry", ((V)(Max(0.3, System.Math.Abs((ToNum(GetIdx(f_1001, 1D)) - ToNum(GetIdx(c_1000, 1D)))))))).V;
return default;
}, 3, "", true);
Set(N_12, "dome21", Fn((V _arrowThis1009, int _argc1002, V S_1008, V _a1005, V _a1006, V _a1007, V[] _rest1003) => {
double T_1010 = 0;
V D_1011 = default;
T_1010 = 12D;
D_1011 = NewObj(5).Put("w", ((V)(30D))).Put("d", ((V)(30D))).Put("zs", ((V)(1.6))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis1018, int _argc1012, V _a1014, V _a1015, V _a1016, V _a1017, V[] _rest1013) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1011, "fx", Fn((V _arrowThis1026, int _argc1019, V ctx_1025, V _a1022, V _a1023, V _a1024, V[] _rest1020) => {
V C_1027 = default;
V k_1028 = default;
double R0_1029 = 0;
double yR_1030 = 0;
V e_1031 = default;
V bot_1032 = default;
double rd_1033 = 0;
V g_1034 = default;
V d_1035 = default;
JsStrBuf s_1036 = null;
C_1027 = Call(cam_15, V.Undef, ctx_1025);
k_1028 = Get(C_1027, "k");
R0_1029 = 12.5;
yR_1030 = (T_1010 - 2.2);
e_1031 = Call(ellOf_55, V.Undef, C_1027, ((V)(yR_1030)), ((V)(R0_1029)));
bot_1032 = Invoke(C_1027, "P", Arr(((V)(0D)), ((V)((yR_1030 - 7.5))), ((V)(0D))));
rd_1033 = Max(ToNum(Add(Get(e_1031, "ry"), ((V)(1D)))), (ToNum(GetIdx(bot_1032, 1D)) - ToNum(Get(e_1031, "y"))));
g_1034 = Invoke(C_1027, "u", ((V)("dg")));
d_1035 = ((V)(string.Concat("M", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(e_1031, "x")) - ToNum(Get(e_1031, "rx"))))))), " ", ToStr(Call(f1_20, V.Undef, Get(e_1031, "y"))), "A", ToStr(Call(f1_20, V.Undef, Get(e_1031, "rx"))), " ", ToStr(Call(f1_20, V.Undef, ((V)(rd_1033)))), " 0 0 0 ", ToStr(Call(f1_20, V.Undef, Add(Get(e_1031, "x"), Get(e_1031, "rx")))), " ", ToStr(Call(f1_20, V.Undef, Get(e_1031, "y"))), "A", ToStr(Call(f1_20, V.Undef, Get(e_1031, "rx"))), " ", ToStr(Call(f1_20, V.Undef, Get(e_1031, "ry"))), " 0 0 0 ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(e_1031, "x")) - ToNum(Get(e_1031, "rx"))))))), " ", ToStr(Call(f1_20, V.Undef, Get(e_1031, "y"))), "Z")));
s_1036 = new JsStrBuf(string.Concat("<defs><radialGradient id=\"", ToStr(g_1034), "\" gradientUnits=\"userSpaceOnUse\" cx=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(e_1031, "x")) - (ToNum(Get(e_1031, "rx")) * 0.3)))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, Add(Get(e_1031, "y"), ((V)((rd_1033 * 0.2)))))), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(e_1031, "rx")) * 1.3))))), "\"><stop offset=\"0\" stop-color=\"#fff7d2\"/><stop offset=\"0.45\" stop-color=\"#f1d98e\"/><stop offset=\"0.85\" stop-color=\"#d6ad56\"/><stop offset=\"1\" stop-color=\"#b08436\"/></radialGradient></defs>"));
s_1036.V(Add(Call(glow_51, V.Undef, C_1027, Arr(((V)(0D)), ((V)(T_1010)), ((V)(0D))), ((V)(30D)), ((V)(0.6)), Call(FLK_54, V.Undef, ((V)(6.1)))), Call(cyl3_27, V.Undef, C_1027, Arr(((V)(0D)), ((V)(yR_1030)), ((V)(0D))), Arr(((V)(0D)), ((V)(T_1010)), ((V)(0D))), ((V)((R0_1029 + 0.7))), ((V)("#dcd6c8")))));
s_1036.S(string.Concat("<path d=\"", ToStr(d_1035), "\" fill=\"url(#", ToStr(g_1034), ")\" stroke=\"#a37a34\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.3 * ToNum(k_1028)))))), "\"/>"));
s_1036.S(string.Concat("<g opacity=\"0.55\">", ToStr(Invoke(Invoke(Arr(Arr(((V)((-3.2))), ((V)(0.62)), ((V)(0.3))), Arr(((V)(1.8)), ((V)(0.7)), ((V)((-0.5)))), Arr(((V)(4.6)), ((V)(0.5)), ((V)(1D)))), "map", Fn((V _arrowThis1050, int _argc1037, V _a1039, V _a1040, V _a1041, V _a1042, V[] _rest1038) => {
V x_1051 = default;
V y_1052 = default;
V dx_1045 = default;
V f_1047 = default;
V r_1049 = default;
{ V _t1043 = ListOf(_a1039);
{ V _t1044 = GetIdx(_t1043, 0D);
dx_1045 = _t1044; }
{ V _t1046 = GetIdx(_t1043, 1D);
f_1047 = _t1046; }
{ V _t1048 = GetIdx(_t1043, 2D);
r_1049 = _t1048; }
}
x_1051 = Add(Get(e_1031, "x"), ((V)((ToNum(dx_1045) * ToNum(k_1028)))));
y_1052 = Add(Get(e_1031, "y"), ((V)((rd_1033 * ToNum(f_1047)))));
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, x_1051)), "\" cy=\"", ToStr(Call(f1_20, V.Undef, y_1052)), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.7 * ToNum(k_1028)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.38 * ToNum(k_1028)))))), "\" fill=\"#4e3a1a\" transform=\"rotate(", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(r_1049) * 40D))))), " ", ToStr(Call(f1_20, V.Undef, x_1051)), " ", ToStr(Call(f1_20, V.Undef, y_1052)), ")\"/><path d=\"M", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(x_1051) - (0.9 * ToNum(k_1028))))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(y_1052) - (0.4 * ToNum(k_1028))))))), "l", ToStr(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(k_1028)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((0.3 * ToNum(k_1028)))))), "M", ToStr(Call(f1_20, V.Undef, Add(x_1051, ((V)((0.9 * ToNum(k_1028))))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(y_1052) - (0.3 * ToNum(k_1028))))))), "l", ToStr(Call(f1_20, V.Undef, ((V)(((-0.5) * ToNum(k_1028)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((0.3 * ToNum(k_1028)))))), "M", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(x_1051) - (0.8 * ToNum(k_1028))))))), " ", ToStr(Call(f1_20, V.Undef, Add(y_1052, ((V)((0.5 * ToNum(k_1028))))))), "l", ToStr(Call(f1_20, V.Undef, ((V)((0.4 * ToNum(k_1028)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)(((-0.3) * ToNum(k_1028)))))), "\" stroke=\"#4e3a1a\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.15 * ToNum(k_1028)))))), "\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))), "</g>"));
s_1036.S(string.Concat("<g>", ToStr(Call(FLK_54, V.Undef, ((V)(6.1)))), "<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Get(e_1031, "x"))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, Add(Get(e_1031, "y"), ((V)((rd_1033 * 0.42)))))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(e_1031, "rx")) * 0.5))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((rd_1033 * 0.32))))), "\" fill=\"#fffbe6\" opacity=\"0.75\" filter=\"url(#l21b1)\"/></g>"));
s_1036.S(string.Concat("<path d=\"M", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(e_1031, "x")) - (ToNum(Get(e_1031, "rx")) * 0.7)))))), " ", ToStr(Call(f1_20, V.Undef, Add(Get(e_1031, "y"), ((V)((rd_1033 * 0.25)))))), "Q", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(e_1031, "x")) - (ToNum(Get(e_1031, "rx")) * 0.55)))))), " ", ToStr(Call(f1_20, V.Undef, Add(Get(e_1031, "y"), ((V)((rd_1033 * 0.7)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Get(e_1031, "x")) - (ToNum(Get(e_1031, "rx")) * 0.15)))))), " ", ToStr(Call(f1_20, V.Undef, Add(Get(e_1031, "y"), ((V)((rd_1033 * 0.86)))))), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.7 * ToNum(k_1028)))))), "\" fill=\"none\" opacity=\"0.6\" stroke-linecap=\"round\"/>"));
s_1036.V(Add(Call(cyl3_27, V.Undef, C_1027, Arr(((V)(0D)), ((V)((yR_1030 - 7.1))), ((V)(0D))), Arr(((V)(0D)), ((V)((yR_1030 - 7.9))), ((V)(0D))), ((V)(1.6)), ((V)("#c9ced2")), NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.4))).V), Call(sph_28, V.Undef, C_1027, Arr(((V)(0D)), ((V)((yR_1030 - 8.4))), ((V)(0D))), ((V)(0.9)), ((V)("#dfe3e6")))));
return NewObj(3).Put("defs", DEF21_50).Put("front", ((V)(s_1036.Str))).Put("bb", Invoke(C_1027, "bb", ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1011;
return default;
}, 1, "", true));
Set(N_12, "rattan21", Fn((V _arrowThis1060, int _argc1053, V S_1059, V _a1056, V _a1057, V _a1058, V[] _rest1054) => {
double T_1061 = 0;
V D_1062 = default;
V prof_1063 = default;
V rr_1064 = default;
T_1061 = 48D;
D_1062 = NewObj(5).Put("w", ((V)(40D))).Put("d", ((V)(40D))).Put("zs", ((V)(1.6))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis1071, int _argc1065, V _a1067, V _a1068, V _a1069, V _a1070, V[] _rest1066) => {
return Arr();
}, 0, "build", true)).V;
prof_1063 = Arr(Arr(((V)((T_1061 - 15D))), ((V)(4D))), Arr(((V)((T_1061 - 18D))), ((V)(9.5))), Arr(((V)((T_1061 - 22D))), ((V)(13.5))), Arr(((V)((T_1061 - 30D))), ((V)(16.6))), Arr(((V)((T_1061 - 38D))), ((V)(17.8))), Arr(((V)(6D)), ((V)(18.2))));
rr_1064 = Fn((V _arrowThis1079, int _argc1072, V y_1078, V _a1075, V _a1076, V _a1077, V[] _rest1073) => {
{
double i_1080 = 0;
i_1080 = 1D;
while (true) {
if (!(Lt(((V)(i_1080)), Get(prof_1063, "length")))) break;
V ya_1082 = default;
V ra_1083 = default;
V yb_1084 = default;
V rb_1085 = default;
{ V _t1086 = GetIdx(prof_1063, (i_1080 - 1D));
{ V _t1087 = ListOf(_t1086);
{ V _t1088 = GetIdx(_t1087, 0D);
ya_1082 = _t1088; }
{ V _t1089 = GetIdx(_t1087, 1D);
ra_1083 = _t1089; }
} }
{ V _t1090 = GetIdx(prof_1063, i_1080);
{ V _t1091 = ListOf(_t1090);
{ V _t1092 = GetIdx(_t1091, 0D);
yb_1084 = _t1092; }
{ V _t1093 = GetIdx(_t1091, 1D);
rb_1085 = _t1093; }
} }
if (Ge(y_1078, yb_1084)) {
return Add(ra_1083, ((V)((((ToNum(rb_1085) - ToNum(ra_1083)) * (ToNum(ya_1082) - ToNum(y_1078))) / (ToNum(ya_1082) - ToNum(yb_1084))))));
}
i_1080++;
}
}
return ((V)(18.2));
return default;
}, 1, "", true);
Set(D_1062, "fx", Fn((V _arrowThis1101, int _argc1094, V ctx_1100, V _a1097, V _a1098, V _a1099, V[] _rest1095) => {
V C_1102 = default;
V k_1103 = default;
V R_1104 = default;
JsStrBuf sp_1105 = null;
JsStrBuf sh_1106 = null;
double NS_1107 = 0;
double NY_1108 = 0;
V ys_1109 = default;
JsStrBuf st_1110 = null;
V arc_1111 = default;
V top_1112 = default;
C_1102 = Call(cam_15, V.Undef, ctx_1100);
k_1103 = Get(C_1102, "k");
R_1104 = Call(rng_16, V.Undef, ((V)("rat21")));
sp_1105 = new JsStrBuf("");
sh_1106 = new JsStrBuf("");
Call(rep_22, V.Undef, ((V)(16D)), Fn((V _arrowThis1120, int _argc1113, V i_1119, V _a1116, V _a1117, V _a1118, V[] _rest1114) => {
double a_1121 = 0;
double r_1122 = 0;
V q_1123 = default;
a_1121 = ((((ToNum(i_1119) / 16D) * 2D) * PI_13) + (ToNum(Call(R_1104, V.Undef)) * 0.3));
r_1122 = (12D + (ToNum(Call(R_1104, V.Undef)) * 18D));
q_1123 = Invoke(C_1102, "p", ((V)((r_1122 * FdLibm.Sin(a_1121)))), ((V)(T_1061)), ((V)((r_1122 * FdLibm.Cos(a_1121)))));
sp_1105.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(q_1123, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(q_1123, 1D))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(Add(((V)(1.2)), Call(R_1104, V.Undef))) * ToNum(k_1103)))))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.55 * ToNum(k_1103)))))), "\" fill=\"#ffe2a6\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.2;0.75;0.2")), Call(n4_21, V.Undef, ((V)((2.6 + (ToNum(Call(R_1104, V.Undef)) * 2.4))))), Call(n4_21, V.Undef, ((V)(((-ToNum(Call(R_1104, V.Undef))) * 3D)))), Call(SPL_19, V.Undef, ((V)(2D))))), "</ellipse>"));
return default;
}, 1, "", true));
sh_1106.V(Add(Call(glow_51, V.Undef, C_1102, Arr(((V)(0D)), ((V)(2D)), ((V)(0D))), ((V)(24D)), ((V)(0.55))), Call(cyl3_27, V.Undef, C_1102, Arr(((V)(0D)), ((V)((T_1061 - 1.6))), ((V)(0D))), Arr(((V)(0D)), ((V)((T_1061 - 15D))), ((V)(0D))), ((V)(0.35)), ((V)("#2a2420")), NewObj(1).Put("olw", ((V)(0.3))).V)));
{
double i_1124 = 0;
i_1124 = 1D;
while (true) {
if (!(Lt(((V)(i_1124)), Get(prof_1063, "length")))) break;
sh_1106.V(Call(cyl3_27, V.Undef, C_1102, Arr(((V)(0D)), GetIdx(GetIdx(prof_1063, (i_1124 - 1D)), 0D), ((V)(0D))), Arr(((V)(0D)), GetIdx(GetIdx(prof_1063, i_1124), 0D), ((V)(0D))), GetIdx(GetIdx(prof_1063, (i_1124 - 1D)), 1D), ((V)("#f7cf84")), NewObj(2).Put("r2", GetIdx(GetIdx(prof_1063, i_1124), 1D)).Put("olw", ((V)(0D))).V));
i_1124++;
}
}
NS_1107 = 22D;
NY_1108 = 16D;
ys_1109 = Call(rep_22, V.Undef, ((V)(NY_1108)), Fn((V _arrowThis1133, int _argc1126, V i_1132, V _a1129, V _a1130, V _a1131, V[] _rest1127) => {
return ((V)(((T_1061 - 15D) + (((6D - (T_1061 - 15D)) * ToNum(i_1132)) / (NY_1108 - 1D)))));
}, 1, "", true));
st_1110 = new JsStrBuf("");
Invoke(Arr(((V)(1D)), ((V)((-1D)))), "forEach", Fn((V _arrowThis1141, int _argc1134, V sg_1140, V _a1137, V _a1138, V _a1139, V[] _rest1135) => {
return Call(rep_22, V.Undef, ((V)(NS_1107)), Fn((V _arrowThis1149, int _argc1142, V j_1148, V _a1145, V _a1146, V _a1147, V[] _rest1143) => {
JsStrBuf d_1150 = null;
V on_1151 = default;
d_1150 = new JsStrBuf("");
on_1151 = (false ? V.True : V.False);
Invoke(ys_1109, "forEach", Fn((V _arrowThis1160, int _argc1152, V y_1158, V i_1159, V _a1156, V _a1157, V[] _rest1153) => {
double f_1161 = 0;
double a_1162 = 0;
V vis_1163 = default;
V q_1164 = default;
f_1161 = (ToNum(i_1159) / (NY_1108 - 1D));
a_1162 = ((((2D * PI_13) * ToNum(j_1148)) / NS_1107) + ((ToNum(sg_1140) * 1.25) * f_1161));
vis_1163 = ((FdLibm.Cos((a_1162 - ToNum(Get(C_1102, "thV")))) > 0.02) ? V.True : V.False);
q_1164 = Invoke(C_1102, "p", ((V)((ToNum(Call(rr_1064, V.Undef, y_1158)) * FdLibm.Sin(a_1162)))), y_1158, ((V)((ToNum(Call(rr_1064, V.Undef, y_1158)) * FdLibm.Cos(a_1162)))));
if (Truthy(vis_1163)) {
d_1150.S((Truthy(on_1151) ? "L" : "M")).V(Call(P2_23, V.Undef, q_1164));
on_1151 = (true ? V.True : V.False);
} else {
on_1151 = (false ? V.True : V.False);
}
return default;
}, 2, "", true));
st_1110.S(d_1150.Str);
return default;
}, 1, "", true));
}, 1, "", true));
sh_1106.S(string.Concat("<path d=\"", st_1110.Str, "\" stroke=\"#7e4f22\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((1.25 * ToNum(k_1103)))))), "\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"", st_1110.Str, "\" stroke=\"#c48a4c\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.8 * ToNum(k_1103)))))), "\" fill=\"none\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"", st_1110.Str, "\" stroke=\"#ebc08a\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.25 * ToNum(k_1103)))))), "\" fill=\"none\" transform=\"translate(", ToStr(Call(f1_20, V.Undef, ((V)(((-0.2) * ToNum(k_1103)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)(((-0.2) * ToNum(k_1103)))))), ")\"/>"));
arc_1111 = Fn((V _arrowThis1173, int _argc1165, V y_1171, V w_1172, V _a1169, V _a1170, V[] _rest1166) => {
V P_1174 = default;
P_1174 = Call(ring_52, V.Undef, C_1102, y_1171, Add(Call(rr_1064, V.Undef, y_1171), ((V)(0.15))), ((V)((ToNum(Get(C_1102, "thV")) - (PI_13 / 2D)))), Add(Get(C_1102, "thV"), ((V)((PI_13 / 2D)))), ((V)(22D)));
return ((V)(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(P_1174, "map", P2_23), "join", ((V)("L")))), "\" stroke=\"#6e431c\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(w_1172) * ToNum(k_1103)))))), "\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Invoke(Invoke(P_1174, "map", P2_23), "join", ((V)("L")))), "\" stroke=\"#d29a5a\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)(((ToNum(w_1172) * 0.45) * ToNum(k_1103)))))), "\" fill=\"none\" transform=\"translate(0 ", ToStr(Call(f1_20, V.Undef, ((V)((((-ToNum(w_1172)) * 0.2) * ToNum(k_1103)))))), ")\" stroke-linecap=\"round\"/>")));
return default;
}, 2, "", true);
sh_1106.V(Add(Add(Add(Call(arc_1111, V.Undef, ((V)((T_1061 - 15.4))), ((V)(1.4))), Call(arc_1111, V.Undef, ((V)((T_1061 - 22D))), ((V)(0.9)))), Call(arc_1111, V.Undef, ((V)((T_1061 - 38D))), ((V)(0.9)))), Call(arc_1111, V.Undef, ((V)(6.4)), ((V)(1.9)))));
top_1112 = Call(cyl3_27, V.Undef, C_1102, Arr(((V)(0D)), ((V)((T_1061 - 1.6))), ((V)(0D))), Arr(((V)(0D)), ((V)(T_1061)), ((V)(0D))), ((V)(3.4)), ((V)("#c99a5a")), NewObj(1).Put("olw", ((V)(0.5))).V);
return NewObj(3).Put("defs", DEF21_50).Put("front", ((V)(JsStrBuf.Begin().S(sp_1105.Str).V(top_1112).S(string.Concat("<g>", ToStr(Call(swing_53, V.Undef, C_1102, Arr(((V)(0D)), ((V)((T_1061 - 1.6))), ((V)(0D))), ((V)(2.2)), ((V)(5.6)))), sh_1106.Str, "</g>")).End()))).Put("bb", Invoke(C_1102, "bb", ((V)(5D)))).V;
return default;
}, 1, "", true));
return D_1062;
return default;
}, 1, "", true));
Set(N_12, "sput21", Fn((V _arrowThis1182, int _argc1175, V S_1181, V _a1178, V _a1179, V _a1180, V[] _rest1176) => {
double T_1183 = 0;
double HY_1184 = 0;
double L_1185 = 0;
V GD_1186 = default;
V D_1187 = default;
double ph_1188 = 0;
V V_1189 = default;
T_1183 = 40D;
HY_1184 = 19D;
L_1185 = 17D;
GD_1186 = ((V)("#c9a04a"));
D_1187 = NewObj(5).Put("w", ((V)(66D))).Put("d", ((V)(66D))).Put("zs", ((V)(1.5))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis1196, int _argc1190, V _a1192, V _a1193, V _a1194, V _a1195, V[] _rest1191) => {
return Arr();
}, 0, "build", true)).V;
ph_1188 = ((1D + System.Math.Sqrt(5D)) / 2D);
V_1189 = Invoke(Arr(Arr(((V)(0D)), ((V)(1D)), ((V)(ph_1188))), Arr(((V)(0D)), ((V)(1D)), ((V)((-ph_1188)))), Arr(((V)(0D)), ((V)((-1D))), ((V)(ph_1188))), Arr(((V)(0D)), ((V)((-1D))), ((V)((-ph_1188)))), Arr(((V)(1D)), ((V)(ph_1188)), ((V)(0D))), Arr(((V)(1D)), ((V)((-ph_1188))), ((V)(0D))), Arr(((V)((-1D))), ((V)(ph_1188)), ((V)(0D))), Arr(((V)((-1D))), ((V)((-ph_1188))), ((V)(0D))), Arr(((V)(ph_1188)), ((V)(0D)), ((V)(1D))), Arr(((V)(ph_1188)), ((V)(0D)), ((V)((-1D)))), Arr(((V)((-ph_1188))), ((V)(0D)), ((V)(1D))), Arr(((V)((-ph_1188))), ((V)(0D)), ((V)((-1D))))), "map", Fn((V _arrowThis1204, int _argc1197, V v_1203, V _a1200, V _a1201, V _a1202, V[] _rest1198) => {
V n_1205 = default;
double c_1206 = 0;
double s2_1207 = 0;
double x_1208 = 0;
double y_1209 = 0;
double z_1210 = 0;
double x2_1211 = 0;
double y2_1212 = 0;
n_1205 = InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(v_1203).V);
c_1206 = FdLibm.Cos(0.35);
s2_1207 = FdLibm.Sin(0.35);
x_1208 = (ToNum(GetIdx(v_1203, 0D)) / ToNum(n_1205));
y_1209 = (ToNum(GetIdx(v_1203, 1D)) / ToNum(n_1205));
z_1210 = (ToNum(GetIdx(v_1203, 2D)) / ToNum(n_1205));
x2_1211 = ((x_1208 * c_1206) - (y_1209 * s2_1207));
y2_1212 = ((x_1208 * s2_1207) + (y_1209 * c_1206));
return Arr(((V)(x2_1211)), ((V)(y2_1212)), ((V)(z_1210)));
return default;
}, 1, "", true));
Set(D_1187, "fx", Fn((V _arrowThis1220, int _argc1213, V ctx_1219, V _a1216, V _a1217, V _a1218, V[] _rest1214) => {
V C_1221 = default;
V v_1222 = default;
V A_1223 = default;
V isF_1224 = default;
V Ab_1225 = default;
V Af_1226 = default;
V s_1227 = default;
C_1221 = Call(cam_15, V.Undef, ctx_1219);
v_1222 = Get(C_1221, "v");
A_1223 = Arr();
Invoke(V_1189, "forEach", Fn((V _arrowThis1236, int _argc1228, V d_1234, V i_1235, V _a1232, V _a1233, V[] _rest1229) => {
V p_1237 = default;
V e_1238 = default;
V b_1239 = default;
p_1237 = Fn((V _arrowThis1248, int _argc1240, V r_1246, V o_1247, V _a1244, V _a1245, V[] _rest1241) => {
return Arr(((V)((ToNum(GetIdx(d_1234, 0D)) * ToNum(r_1246)))), Add(((V)((HY_1184 + (ToNum(GetIdx(d_1234, 1D)) * ToNum(r_1246))))), (o_1247 is var _t1249 && Truthy(_t1249) ? _t1249 : ((V)(0D)))), ((V)((ToNum(GetIdx(d_1234, 2D)) * ToNum(r_1246)))));
}, 2, "", true);
e_1238 = Call(p_1237, V.Undef, ((V)(L_1185)));
b_1239 = Call(p_1237, V.Undef, ((V)((L_1185 + 3.4))));
Invoke(A_1223, "push", NewObj(2).Put("q", e_1238).Put("s", Add(Add(Add(Call(cyl3_27, V.Undef, C_1221, Call(p_1237, V.Undef, ((V)(3D))), e_1238, ((V)(0.42)), GD_1186, NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.35))).V), Call(cyl3_27, V.Undef, C_1221, e_1238, Call(p_1237, V.Undef, ((V)((L_1185 + 1.5)))), ((V)(0.95)), ((V)("#a7802f")), NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.35))).V)), Call(glow_51, V.Undef, C_1221, b_1239, ((V)(7D)), ((V)(0.75)), Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.5;0.95;0.5")), ((V)((2.2 + ((ToNum(i_1235) % 4D) * 0.55)))), ((V)(((-ToNum(i_1235)) * 0.37))), Call(SPL_19, V.Undef, ((V)(2D)))))), Call(sph_28, V.Undef, C_1221, b_1239, ((V)(1.9)), ((V)("#fff5d8")), NewObj(1).Put("op", ((V)(0.96))).V))).V);
return default;
}, 2, "", true));
isF_1224 = Fn((V _arrowThis1257, int _argc1250, V o_1256, V _a1253, V _a1254, V _a1255, V[] _rest1251) => {
return ((((ToNum(GetIdx(Get(o_1256, "q"), 0D)) * ToNum(GetIdx(v_1222, 0D))) + (ToNum(GetIdx(Get(o_1256, "q"), 2D)) * ToNum(GetIdx(v_1222, 2D)))) > 0D) ? V.True : V.False);
}, 1, "", true);
Ab_1225 = Invoke(A_1223, "filter", Fn((V _arrowThis1265, int _argc1258, V o_1264, V _a1261, V _a1262, V _a1263, V[] _rest1259) => {
return (!(Truthy(Call(isF_1224, V.Undef, o_1264))) ? V.True : V.False);
}, 1, "", true));
Af_1226 = Invoke(A_1223, "filter", isF_1224);
s_1227 = Add(Add(Add(Add(Call(glow_51, V.Undef, C_1221, Arr(((V)(0D)), ((V)(HY_1184)), ((V)(0D))), ((V)(46D)), ((V)(0.5)), Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.4;0.6;0.4")), ((V)(5D)), ((V)(0D)), Call(SPL_19, V.Undef, ((V)(2D))))), Call(zsort_25, V.Undef, C_1221, Ab_1225)), Call(cyl3_27, V.Undef, C_1221, Arr(((V)(0D)), ((V)((HY_1184 + 3D))), ((V)(0D))), Arr(((V)(0D)), ((V)(T_1183)), ((V)(0D))), ((V)(0.6)), GD_1186, NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.35))).V)), Call(sph_28, V.Undef, C_1221, Arr(((V)(0D)), ((V)(HY_1184)), ((V)(0D))), ((V)(3.8)), GD_1186)), Call(zsort_25, V.Undef, C_1221, Af_1226));
return NewObj(3).Put("defs", DEF21_50).Put("front", ((V)(JsStrBuf.Begin().V(Call(cyl3_27, V.Undef, C_1221, Arr(((V)(0D)), ((V)((T_1183 - 1.2))), ((V)(0D))), Arr(((V)(0D)), ((V)(T_1183)), ((V)(0D))), ((V)(4.4)), GD_1186, NewObj(1).Put("mat", ((V)("gloss"))).V)).S(string.Concat("<g>", ToStr(Call(swing_53, V.Undef, C_1221, Arr(((V)(0D)), ((V)(T_1183)), ((V)(0D))), ((V)(1.2)), ((V)(7D)))), ToStr(s_1227), "</g>")).End()))).Put("bb", Invoke(C_1221, "bb", ((V)(5D)))).V;
return default;
}, 1, "", true));
return D_1187;
return default;
}, 1, "", true));
Set(N_12, "mura21", Fn((V _arrowThis1273, int _argc1266, V S_1272, V _a1269, V _a1270, V _a1271, V[] _rest1267) => {
double T_1274 = 0;
V GD_1275 = default;
V TI_1276 = default;
V D_1277 = default;
T_1274 = 60D;
GD_1275 = ((V)("#c9a04a"));
TI_1276 = Arr(NewObj(4).Put("y", ((V)(45D))).Put("r", ((V)(8D))).Put("n", ((V)(8D))).Put("h", ((V)(8D))).V, NewObj(4).Put("y", ((V)(33D))).Put("r", ((V)(13D))).Put("n", ((V)(11D))).Put("h", ((V)(10D))).V, NewObj(4).Put("y", ((V)(20D))).Put("r", ((V)(18.5))).Put("n", ((V)(14D))).Put("h", ((V)(12D))).V);
D_1277 = NewObj(5).Put("w", ((V)(46D))).Put("d", ((V)(46D))).Put("zs", ((V)(1.6))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis1284, int _argc1278, V _a1280, V _a1281, V _a1282, V _a1283, V[] _rest1279) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1277, "fx", Fn((V _arrowThis1292, int _argc1285, V ctx_1291, V _a1288, V _a1289, V _a1290, V[] _rest1286) => {
V C_1293 = default;
V k_1294 = default;
V v_1295 = default;
V L_1296 = default;
JsStrBuf gl_1297 = null;
V rp_1298 = default;
double n_1299 = 0;
V isF_1300 = default;
V Lb_1301 = default;
V Lf_1302 = default;
V bk_1303 = default;
V rings_1304 = default;
V arms_1305 = default;
V body_1306 = default;
C_1293 = Call(cam_15, V.Undef, ctx_1291);
k_1294 = Get(C_1293, "k");
v_1295 = Get(C_1293, "v");
L_1296 = Arr();
gl_1297 = new JsStrBuf("");
rp_1298 = Fn((V _arrowThis1315, int _argc1307, V P_1313, V w_1314, V _a1311, V _a1312, V[] _rest1308) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(P_1313, "map", P2_23), "join", ((V)("L")))), "\" stroke=\"", ToStr(GD_1275), "\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(w_1314) * ToNum(k_1294)))))), "\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Invoke(Invoke(P_1313, "map", P2_23), "join", ((V)("L")))), "\" stroke=\"#fff0b8\" stroke-opacity=\"0.5\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)(((ToNum(w_1314) * 0.3) * ToNum(k_1294)))))), "\" fill=\"none\" transform=\"translate(0 ", ToStr(Call(f1_20, V.Undef, ((V)((((-ToNum(w_1314)) * 0.25) * ToNum(k_1294)))))), ")\"/>")));
}, 2, "", true);
n_1299 = 0D;
Invoke(TI_1276, "forEach", Fn((V _arrowThis1324, int _argc1316, V t_1322, V ti_1323, V _a1320, V _a1321, V[] _rest1317) => {
gl_1297.V(Call(glow_51, V.Undef, C_1293, Arr(((V)(0D)), ((V)((ToNum(Get(t_1322, "y")) - (ToNum(Get(t_1322, "h")) * 0.4)))), ((V)(0D))), ((V)((ToNum(Get(t_1322, "r")) * 1.5))), ((V)(0.6)), Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.45;0.7;0.45")), Add(((V)(4D)), ti_1323), ((V)((-ToNum(ti_1323)))), Call(SPL_19, V.Undef, ((V)(2D))))));
Call(rep_22, V.Undef, Get(t_1322, "n"), Fn((V _arrowThis1332, int _argc1325, V i_1331, V _a1328, V _a1329, V _a1330, V[] _rest1326) => {
double a_1333 = 0;
double x_1334 = 0;
double z_1335 = 0;
V p_1336 = default;
double w_1337 = 0;
double h_1338 = 0;
double id_1339 = 0;
V d_1340 = default;
V sw_1341 = default;
V s_1342 = default;
a_1333 = ((((ToNum(i_1331) / ToNum(Get(t_1322, "n"))) * 2D) * PI_13) + (ToNum(ti_1323) * 0.4));
x_1334 = (ToNum(Get(t_1322, "r")) * FdLibm.Sin(a_1333));
z_1335 = (ToNum(Get(t_1322, "r")) * FdLibm.Cos(a_1333));
p_1336 = Invoke(C_1293, "P", Arr(((V)(x_1334)), Get(t_1322, "y"), ((V)(z_1335))));
w_1337 = ((ToNum(Get(t_1322, "h")) * 0.44) * ToNum(k_1294));
h_1338 = (ToNum(Get(t_1322, "h")) * ToNum(k_1294));
id_1339 = n_1299++;
d_1340 = ((V)(string.Concat("M", ToStr(Call(f1_20, V.Undef, GetIdx(p_1336, 0D))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(p_1336, 1D))), "C", ToStr(Call(f1_20, V.Undef, Add(GetIdx(p_1336, 0D), ((V)(w_1337))))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(p_1336, 1D), ((V)((h_1338 * 0.22)))))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(p_1336, 0D), ((V)((w_1337 * 0.75)))))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(p_1336, 1D), ((V)((h_1338 * 0.86)))))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(p_1336, 0D))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(p_1336, 1D), ((V)(h_1338))))), "C", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(p_1336, 0D)) - (w_1337 * 0.75)))))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(p_1336, 1D), ((V)((h_1338 * 0.86)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(p_1336, 0D)) - w_1337))))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(p_1336, 1D), ((V)((h_1338 * 0.22)))))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(p_1336, 0D))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(p_1336, 1D))), "Z")));
sw_1341 = ((V)(string.Concat(ToStr(Call(f1_20, V.Undef, GetIdx(p_1336, 0D))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(p_1336, 1D))))));
s_1342 = ((V)(string.Concat(string.Concat("<g>", ToStr(Call(at_18, V.Undef, ((V)("rotate")), ((V)(string.Concat("-4 ", ToStr(sw_1341), ";4 ", ToStr(sw_1341), ";-4 ", ToStr(sw_1341)))), ((V)((2.8 + ((id_1339 % 5D) * 0.45)))), ((V)(((-id_1339) * 0.31))), Call(SPL_19, V.Undef, ((V)(2D))))), "<path d=\"", ToStr(d_1340), "\" fill=\"url(#l21m)\" stroke=\"#2e2119\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.22 * ToNum(k_1294)))))), "\"/>"), string.Concat("<path d=\"M", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(p_1336, 0D)) - (w_1337 * 0.45)))))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(p_1336, 1D), ((V)((h_1338 * 0.25)))))), "Q", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(p_1336, 0D)) - (w_1337 * 0.55)))))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(p_1336, 1D), ((V)((h_1338 * 0.6)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(p_1336, 0D)) - (w_1337 * 0.15)))))), " ", ToStr(Call(f1_20, V.Undef, Add(GetIdx(p_1336, 1D), ((V)((h_1338 * 0.85)))))), "\" stroke=\"#fff4dc\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.35 * ToNum(k_1294)))))), "\" fill=\"none\" opacity=\"0.55\" stroke-linecap=\"round\"/>"), string.Concat("<circle cx=\"", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(GetIdx(p_1336, 0D)) - (w_1337 * 0.3)))))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, Add(GetIdx(p_1336, 1D), ((V)((h_1338 * 0.35)))))), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.6 * ToNum(k_1294)))))), "\" fill=\"#ffffff\" opacity=\"0\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0;0;1;0;0")), ((V)((3D + ((id_1339 % 6D) * 0.5)))), ((V)(((-id_1339) * 0.41))), ((V)(" keyTimes=\"0;0.6;0.68;0.78;1\"")))), "</circle>"), string.Concat("<circle cx=\"", ToStr(Call(f1_20, V.Undef, GetIdx(p_1336, 0D))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, GetIdx(p_1336, 1D))), "\" r=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.45 * ToNum(k_1294)))))), "\" fill=\"", ToStr(GD_1275), "\"/></g>"))));
Invoke(L_1296, "push", NewObj(2).Put("q", Arr(((V)(x_1334)), ((V)((ToNum(Get(t_1322, "y")) - (ToNum(Get(t_1322, "h")) * 0.5)))), ((V)(z_1335)))).Put("s", s_1342).V);
return default;
}, 1, "", true));
return default;
}, 2, "", true));
isF_1300 = Fn((V _arrowThis1350, int _argc1343, V o_1349, V _a1346, V _a1347, V _a1348, V[] _rest1344) => {
return ((((ToNum(GetIdx(Get(o_1349, "q"), 0D)) * ToNum(GetIdx(v_1295, 0D))) + (ToNum(GetIdx(Get(o_1349, "q"), 2D)) * ToNum(GetIdx(v_1295, 2D)))) > 0D) ? V.True : V.False);
}, 1, "", true);
Lb_1301 = Invoke(L_1296, "filter", Fn((V _arrowThis1358, int _argc1351, V o_1357, V _a1354, V _a1355, V _a1356, V[] _rest1352) => {
return (!(Truthy(Call(isF_1300, V.Undef, o_1357))) ? V.True : V.False);
}, 1, "", true));
Lf_1302 = Invoke(L_1296, "filter", isF_1300);
bk_1303 = Add(Get(C_1293, "thV"), ((V)(PI_13)));
rings_1304 = Fn((V _arrowThis1367, int _argc1359, V a0_1365, V a1_1366, V _a1363, V _a1364, V[] _rest1360) => {
return Invoke(Invoke(TI_1276, "map", Fn((V _arrowThis1375, int _argc1368, V t_1374, V _a1371, V _a1372, V _a1373, V[] _rest1369) => {
return Call(rp_1298, V.Undef, Call(ring_52, V.Undef, C_1293, Get(t_1374, "y"), Get(t_1374, "r"), a0_1365, a1_1366, ((V)(24D))), ((V)(0.9)));
}, 1, "", true)), "join", ((V)("")));
}, 2, "", true);
arms_1305 = Invoke(Invoke(TI_1276, "map", Fn((V _arrowThis1383, int _argc1376, V t_1382, V _a1379, V _a1380, V _a1381, V[] _rest1377) => {
return Invoke(Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis1391, int _argc1384, V i_1390, V _a1387, V _a1388, V _a1389, V[] _rest1385) => {
double a_1392 = 0;
a_1392 = (((ToNum(i_1390) * PI_13) / 2D) + 0.4);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(P2_23, V.Undef, Invoke(C_1293, "p", ((V)(0D)), Add(Get(t_1382, "y"), ((V)(3D))), ((V)(0D))))), "L", ToStr(Call(P2_23, V.Undef, Invoke(C_1293, "p", ((V)((ToNum(Get(t_1382, "r")) * FdLibm.Sin(a_1392)))), Get(t_1382, "y"), ((V)((ToNum(Get(t_1382, "r")) * FdLibm.Cos(a_1392))))))), "\" stroke=\"", ToStr(GD_1275), "\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(k_1294)))))), "\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")));
}, 1, "", true)), "join", ((V)("")));
body_1306 = ((V)(JsStrBuf.Begin().S(gl_1297.Str).V(Call(zsort_25, V.Undef, C_1293, Lb_1301)).V(Call(rings_1304, V.Undef, ((V)((ToNum(bk_1303) - (PI_13 / 2D)))), Add(bk_1303, ((V)((PI_13 / 2D)))))).V(arms_1305).V(Call(cyl3_27, V.Undef, C_1293, Arr(((V)(0D)), ((V)(9D)), ((V)(0D))), Arr(((V)(0D)), ((V)((T_1274 - 1.4))), ((V)(0D))), ((V)(0.8)), GD_1275, NewObj(2).Put("mat", ((V)("gloss"))).Put("olw", ((V)(0.35))).V)).V(Call(sph_28, V.Undef, C_1293, Arr(((V)(0D)), ((V)(8.6)), ((V)(0D))), ((V)(1.6)), GD_1275)).V(Invoke(Invoke(TI_1276, "map", Fn((V _arrowThis1400, int _argc1393, V t_1399, V _a1396, V _a1397, V _a1398, V[] _rest1394) => {
return Call(sph_28, V.Undef, C_1293, Arr(((V)(0D)), Add(Get(t_1399, "y"), ((V)(2.6))), ((V)(0D))), ((V)(1.3)), GD_1275);
}, 1, "", true)), "join", ((V)("")))).V(Call(rings_1304, V.Undef, ((V)((ToNum(Get(C_1293, "thV")) - (PI_13 / 2D)))), Add(Get(C_1293, "thV"), ((V)((PI_13 / 2D)))))).V(Call(zsort_25, V.Undef, C_1293, Lf_1302)).End()));
return NewObj(3).Put("defs", DEF21_50).Put("front", ((V)(JsStrBuf.Begin().V(Call(cyl3_27, V.Undef, C_1293, Arr(((V)(0D)), ((V)((T_1274 - 1.4))), ((V)(0D))), Arr(((V)(0D)), ((V)(T_1274)), ((V)(0D))), ((V)(5D)), GD_1275, NewObj(1).Put("mat", ((V)("gloss"))).V)).S(string.Concat("<g>", ToStr(Call(swing_53, V.Undef, C_1293, Arr(((V)(0D)), ((V)(T_1274)), ((V)(0D))), ((V)(1D)), ((V)(8D)))), ToStr(body_1306), "</g>")).End()))).Put("bb", Invoke(C_1293, "bb", ((V)(5D)))).V;
return default;
}, 1, "", true));
return D_1277;
return default;
}, 1, "", true));
Set(N_12, "const21", Fn((V _arrowThis1408, int _argc1401, V S_1407, V _a1404, V _a1405, V _a1406, V[] _rest1402) => {
double T_1409 = 0;
V D_1410 = default;
T_1409 = 52D;
D_1410 = NewObj(5).Put("w", ((V)(90D))).Put("d", ((V)(90D))).Put("zs", ((V)(1.4))).Put("mount", ((V)("ceil"))).Put("build", Fn((V _arrowThis1417, int _argc1411, V _a1413, V _a1414, V _a1415, V _a1416, V[] _rest1412) => {
return Arr();
}, 0, "build", true)).V;
Set(D_1410, "fx", Fn((V _arrowThis1425, int _argc1418, V ctx_1424, V _a1421, V _a1422, V _a1423, V[] _rest1419) => {
V C_1426 = default;
V k_1427 = default;
V R_1428 = default;
V P_1429 = default;
V bob_1430 = default;
V seen_1431 = default;
JsStrBuf ln_1432 = null;
V CR_1433 = default;
V L_1434 = default;
V s_1435 = default;
C_1426 = Call(cam_15, V.Undef, ctx_1424);
k_1427 = Get(C_1426, "k");
R_1428 = Call(rng_16, V.Undef, ((V)("cst21")));
P_1429 = Arr();
Call(rep_22, V.Undef, ((V)(26D)), Fn((V _arrowThis1443, int _argc1436, V i_1442, V _a1439, V _a1440, V _a1441, V[] _rest1437) => {
double f_1444 = 0;
double a_1445 = 0;
double rd_1446 = 0;
double y_1447 = 0;
f_1444 = (ToNum(i_1442) / 25D);
a_1445 = (((f_1444 * 4.4) * PI_13) + (ToNum(Call(R_1428, V.Undef)) * 0.3));
rd_1446 = ((4D + (32D * (1D - f_1444))) + (ToNum(Call(R_1428, V.Undef)) * 3D));
y_1447 = (((T_1409 - 9D) - (f_1444 * 34D)) + (ToNum(Call(R_1428, V.Undef)) * 2D));
Invoke(P_1429, "push", NewObj(5).Put("q", Arr(((V)((rd_1446 * FdLibm.Sin(a_1445)))), ((V)(Max(6D, y_1447))), ((V)((rd_1446 * FdLibm.Cos(a_1445)))))).Put("s", ((V)((1.4 + (ToNum(Call(R_1428, V.Undef)) * 1.7))))).Put("A", ((V)(((0.9 + (ToNum(Call(R_1428, V.Undef)) * 1.3)) * ToNum(k_1427))))).Put("T", ((V)((3D + (ToNum(Call(R_1428, V.Undef)) * 3.4))))).Put("b", ((V)(((-ToNum(Call(R_1428, V.Undef))) * 4D)))).V);
return default;
}, 1, "", true));
Invoke(P_1429, "forEach", Fn((V _arrowThis1455, int _argc1448, V o_1454, V _a1451, V _a1452, V _a1453, V[] _rest1449) => {
Set(o_1454, "p", Invoke(C_1426, "P", Get(o_1454, "q")));
return default;
}, 1, "", true));
bob_1430 = Fn((V _arrowThis1465, int _argc1456, V o_1462, V at2_1463, V v0_1464, V _a1461, V[] _rest1457) => {
return ((V)(string.Concat("<animate attributeName=\"", ToStr(at2_1463), "\" values=\"", ToStr(Call(f1_20, V.Undef, v0_1464)), ";", ToStr(Call(f1_20, V.Undef, ((V)((ToNum(v0_1464) - ToNum(Get(o_1462, "A"))))))), ";", ToStr(Call(f1_20, V.Undef, v0_1464)), "\" dur=\"", ToStr(Call(n4_21, V.Undef, Get(o_1462, "T"))), "s\" begin=\"", ToStr(Call(n4_21, V.Undef, Get(o_1462, "b"))), "s\" repeatCount=\"indefinite\"", ToStr(Call(SPL_19, V.Undef, ((V)(2D)))), "/>")));
}, 3, "", true);
seen_1431 = NewObj(0).V;
ln_1432 = new JsStrBuf("");
Invoke(P_1429, "forEach", Fn((V _arrowThis1474, int _argc1466, V o_1472, V i_1473, V _a1470, V _a1471, V[] _rest1467) => {
Invoke(Invoke(Invoke(Invoke(Invoke(P_1429, "map", Fn((V _arrowThis1516, int _argc1508, V q_1514, V j_1515, V _a1512, V _a1513, V[] _rest1509) => {
return Arr(j_1515, ((V)(Hypot((ToNum(GetIdx(Get(q_1514, "q"), 0D)) - ToNum(GetIdx(Get(o_1472, "q"), 0D))), (ToNum(GetIdx(Get(q_1514, "q"), 1D)) - ToNum(GetIdx(Get(o_1472, "q"), 1D))), (ToNum(GetIdx(Get(q_1514, "q"), 2D)) - ToNum(GetIdx(Get(o_1472, "q"), 2D)))))));
}, 2, "", true)), "filter", Fn((V _arrowThis1507, int _argc1498, V _a1500, V _a1501, V _a1502, V _a1503, V[] _rest1499) => {
V j_1506 = default;
{ V _t1504 = ListOf(_a1500);
{ V _t1505 = GetIdx(_t1504, 0D);
j_1506 = _t1505; }
}
return (!SEq(j_1506, i_1473) ? V.True : V.False);
}, 1, "", true)), "sort", Fn((V _arrowThis1497, int _argc1489, V a_1495, V b_1496, V _a1493, V _a1494, V[] _rest1490) => {
return ((V)((ToNum(GetIdx(a_1495, 1D)) - ToNum(GetIdx(b_1496, 1D)))));
}, 2, "", true)), "slice", ((V)(0D)), ((V)(2D))), "forEach", Fn((V _arrowThis1484, int _argc1475, V _a1477, V _a1478, V _a1479, V _a1480, V[] _rest1476) => {
V key_1485 = default;
V q_1486 = default;
double len_1487 = 0;
V A1_1488 = default;
V j_1483 = default;
{ V _t1481 = ListOf(_a1477);
{ V _t1482 = GetIdx(_t1481, 0D);
j_1483 = _t1482; }
}
key_1485 = ((V)(JsStrBuf.Begin().N(Min(ToNum(i_1473), ToNum(j_1483))).S("_").N(Max(ToNum(i_1473), ToNum(j_1483))).End()));
if (Truthy(GetK(seen_1431, key_1485))) {
return default;
}
SetK(seen_1431, key_1485, ((V)(1D)));
q_1486 = GetK(P_1429, j_1483);
len_1487 = (Hypot((ToNum(GetIdx(Get(q_1486, "p"), 0D)) - ToNum(GetIdx(Get(o_1472, "p"), 0D))), (ToNum(GetIdx(Get(q_1486, "p"), 1D)) - ToNum(GetIdx(Get(o_1472, "p"), 1D)))) + 1D);
A1_1488 = Add(Call(bob_1430, V.Undef, o_1472, ((V)("y1")), GetIdx(Get(o_1472, "p"), 1D)), Call(bob_1430, V.Undef, q_1486, ((V)("y2")), GetIdx(Get(q_1486, "p"), 1D)));
ln_1432.S(string.Concat("<line x1=\"", ToStr(Call(f1_20, V.Undef, GetIdx(Get(o_1472, "p"), 0D))), "\" y1=\"", ToStr(Call(f1_20, V.Undef, GetIdx(Get(o_1472, "p"), 1D))), "\" x2=\"", ToStr(Call(f1_20, V.Undef, GetIdx(Get(q_1486, "p"), 0D))), "\" y2=\"", ToStr(Call(f1_20, V.Undef, GetIdx(Get(q_1486, "p"), 1D))), "\" stroke=\"#bfe8ff\" stroke-opacity=\"0.8\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.3 * ToNum(k_1427)))))), "\">", ToStr(A1_1488), "</line>"));
if (((ToNum(Add(i_1473, j_1483)) % 3D) == 0D)) {
ln_1432.S(string.Concat("<line x1=\"", ToStr(Call(f1_20, V.Undef, GetIdx(Get(o_1472, "p"), 0D))), "\" y1=\"", ToStr(Call(f1_20, V.Undef, GetIdx(Get(o_1472, "p"), 1D))), "\" x2=\"", ToStr(Call(f1_20, V.Undef, GetIdx(Get(q_1486, "p"), 0D))), "\" y2=\"", ToStr(Call(f1_20, V.Undef, GetIdx(Get(q_1486, "p"), 1D))), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.5 * ToNum(k_1427)))))), "\" stroke-linecap=\"round\" stroke-dasharray=\"", ToStr(Call(f1_20, V.Undef, ((V)((2D * ToNum(k_1427)))))), " ", ToStr(Call(f1_20, V.Undef, ((V)((len_1487 * 2D))))), "\">", ToStr(A1_1488), "<animate attributeName=\"stroke-dashoffset\" values=\"", ToStr(Call(f1_20, V.Undef, ((V)(len_1487)))), ";", ToStr(Call(f1_20, V.Undef, ((V)((-len_1487))))), "\" dur=\"", ToStr(Call(n4_21, V.Undef, ((V)((1.8 + ((ToNum(i_1473) % 4D) * 0.4)))))), "s\" begin=\"", ToStr(Call(n4_21, V.Undef, ((V)(((-ToNum(i_1473)) * 0.3))))), "s\" repeatCount=\"indefinite\"/></line>"));
}
return default;
}, 1, "", true));
return default;
}, 2, "", true));
CR_1433 = Arr(((V)("#e8f6ff")), ((V)("#f1e6ff")), ((V)("#e4fff4")), ((V)("#fff4e0")));
L_1434 = Invoke(P_1429, "map", Fn((V _arrowThis1525, int _argc1517, V o_1523, V i_1524, V _a1521, V _a1522, V[] _rest1518) => {
double s_1526 = 0;
V c_1527 = default;
V tp_1528 = default;
V rt_1529 = default;
V bt_1530 = default;
V lf_1531 = default;
V tri_1532 = default;
V g_1533 = default;
s_1526 = (ToNum(Get(o_1523, "s")) * ToNum(k_1427));
c_1527 = Arr(((V)(((-0.2) * s_1526))), ((V)(((-0.25) * s_1526))));
tp_1528 = Arr(((V)(0D)), ((V)(((-1.7) * s_1526))));
rt_1529 = Arr(((V)(s_1526)), ((V)(0D)));
bt_1530 = Arr(((V)(0D)), ((V)((1.7 * s_1526))));
lf_1531 = Arr(((V)((-s_1526))), ((V)(0D)));
tri_1532 = Fn((V _arrowThis1543, int _argc1534, V a_1540, V b_1541, V f_1542, V _a1539, V[] _rest1535) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Call(P2_23, V.Undef, a_1540)), "L", ToStr(Call(P2_23, V.Undef, b_1541)), "L", ToStr(Call(P2_23, V.Undef, c_1527)), "Z\" fill=\"", ToStr(f_1542), "\"/>")));
}, 3, "", true);
g_1533 = ((V)(JsStrBuf.Begin().V(Add(Add(Add(Call(tri_1532, V.Undef, lf_1531, tp_1528, ((V)("#ffffff"))), Call(tri_1532, V.Undef, tp_1528, rt_1529, ((V)("#cfe6ff")))), Call(tri_1532, V.Undef, rt_1529, bt_1530, ((V)("#86aad0")))), Call(tri_1532, V.Undef, bt_1530, lf_1531, ((V)("#b4d0ee"))))).S(string.Concat("<path d=\"M", ToStr(Call(P2_23, V.Undef, tp_1528)), "L", ToStr(Call(P2_23, V.Undef, rt_1529)), "L", ToStr(Call(P2_23, V.Undef, bt_1530)), "L", ToStr(Call(P2_23, V.Undef, lf_1531)), "Z\" fill=\"", ToStr(GetIdx(CR_1433, (ToNum(i_1524) % 4D))), "\" opacity=\"0.35\">", ToStr(Call(an_17, V.Undef, ((V)("fill")), Invoke(Call(Fn((V _arrowThis1551, int _argc1544, V m_1550, V _a1547, V _a1548, V _a1549, V[] _rest1545) => {
return Invoke(m_1550, "concat", GetIdx(m_1550, 0D));
}, 1, "", true), V.Undef, Invoke(Invoke(CR_1433, "slice", ((V)((ToNum(i_1524) % 4D)))), "concat", Invoke(CR_1433, "slice", ((V)(0D)), ((V)((ToNum(i_1524) % 4D)))))), "join", ((V)(";"))), ((V)((9D + ((ToNum(i_1524) % 3D) * 2D)))), ((V)(((-ToNum(i_1524)) * 0.7))))), "</path><path d=\"M", ToStr(Call(P2_23, V.Undef, tp_1528)), "L", ToStr(Call(P2_23, V.Undef, rt_1529)), "L", ToStr(Call(P2_23, V.Undef, bt_1530)), "L", ToStr(Call(P2_23, V.Undef, lf_1531)), "Z\" fill=\"none\" stroke=\"#6f93b8\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.18 * ToNum(k_1427)))))), "\"/>")).S(string.Concat("<path d=\"M0 ", ToStr(Call(f1_20, V.Undef, ((V)(((-2.4) * s_1526))))), "V", ToStr(Call(f1_20, V.Undef, ((V)((2.4 * s_1526))))), "M", ToStr(Call(f1_20, V.Undef, ((V)(((-2.4) * s_1526))))), " 0H", ToStr(Call(f1_20, V.Undef, ((V)((2.4 * s_1526))))), "\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.25 * ToNum(k_1427)))))), "\" opacity=\"0\" stroke-linecap=\"round\">", ToStr(Call(an_17, V.Undef, ((V)("opacity")), ((V)("0;0;1;0;0")), ((V)((3.4 + ((ToNum(i_1524) % 5D) * 0.7)))), ((V)(((-ToNum(i_1524)) * 0.53))), ((V)(" keyTimes=\"0;0.7;0.76;0.84;1\"")))), "</path>")).End()));
return NewObj(2).Put("q", Get(o_1523, "q")).Put("s", ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(f1_20, V.Undef, GetIdx(Get(o_1523, "p"), 0D))), " ", ToStr(Call(f1_20, V.Undef, GetIdx(Get(o_1523, "p"), 1D))), ")\"><g>", ToStr(Call(at_18, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;0 ", ToStr(Call(f1_20, V.Undef, ((V)((-ToNum(Get(o_1523, "A"))))))), ";0 0"))), Get(o_1523, "T"), Get(o_1523, "b"), Call(SPL_19, V.Undef, ((V)(2D))))), ToStr(g_1533), "</g></g>")))).V;
return default;
}, 2, "", true));
s_1435 = Add(Add(Call(glow_51, V.Undef, C_1426, Arr(((V)(0D)), ((V)((T_1409 - 2D))), ((V)(0D))), ((V)(40D)), ((V)(0.5)), ((V)("")), ((V)("l21c"))), Call(glow_51, V.Undef, C_1426, Arr(((V)(0D)), ((V)(30D)), ((V)(0D))), ((V)(52D)), ((V)(0.45)), Call(an_17, V.Undef, ((V)("opacity")), ((V)("0.3;0.55;0.3")), ((V)(6D)), ((V)(0D)), Call(SPL_19, V.Undef, ((V)(2D)))), ((V)("l21c")))), Call(cyl3_27, V.Undef, C_1426, Arr(((V)(0D)), ((V)((T_1409 - 1.4))), ((V)(0D))), Arr(((V)(0D)), ((V)(T_1409)), ((V)(0D))), ((V)(10D)), ((V)("#eef2f6")), NewObj(1).Put("mat", ((V)("gloss"))).V));
{
V e_1552 = default;
e_1552 = Call(ellOf_55, V.Undef, C_1426, ((V)((T_1409 - 1.5))), ((V)(9.2)));
s_1435 = ((V)(JsStrBuf.Begin().V(s_1435).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_20, V.Undef, Get(e_1552, "x"))), "\" cy=\"", ToStr(Call(f1_20, V.Undef, Get(e_1552, "y"))), "\" rx=\"", ToStr(Call(f1_20, V.Undef, Get(e_1552, "rx"))), "\" ry=\"", ToStr(Call(f1_20, V.Undef, Get(e_1552, "ry"))), "\" fill=\"none\" stroke=\"#9fe2ff\" stroke-width=\"", ToStr(Call(f1_20, V.Undef, ((V)((0.6 * ToNum(k_1427)))))), "\">", ToStr(Call(an_17, V.Undef, ((V)("stroke-opacity")), ((V)("0.4;1;0.4")), ((V)(3D)), ((V)(0D)), Call(SPL_19, V.Undef, ((V)(2D))))), "</ellipse>")).End()));
}
s_1435 = ((V)(JsStrBuf.Begin().V(s_1435).S(ln_1432.Str).V(Call(zsort_25, V.Undef, C_1426, L_1434)).End()));
return NewObj(3).Put("defs", DEF21_50).Put("front", s_1435).Put("bb", Invoke(C_1426, "bb", ((V)(8D)))).V;
return default;
}, 1, "", true));
return D_1410;
return default;
}, 1, "", true));
draw20_56 = Get(RD_8, "draw");
MEMO_57 = NewObj(0).V;
Set(RD_8, "draw", Fn((V _arrowThis1561, int _argc1553, V r_1559, V o_1560, V _a1557, V _a1558, V[] _rest1554) => {
V res_1562 = default;
res_1562 = Call(draw20_56, V.Undef, r_1559, o_1560);
if (Truthy(((!(Truthy(res_1562)) ? V.True : V.False) is var _t1563 && Truthy(_t1563) ? _t1563 : Get(res_1562, "_p21")))) {
return res_1562;
}
try {
V k_1564 = default;
k_1564 = (Get(r_1559, "c21") is var _t1565 && !Truthy(_t1565) ? _t1565 : GetK(CEIL21_48, Get(r_1559, "c21")));
if (Truthy((k_1564 is var _t1566 && !Truthy(_t1566) ? _t1566 : Get(res_1562, "surf")))) {
V M_1567 = default;
Set(res_1562, "_p21", ((V)(1D)));
Set(res_1562, "vb", ((V)("0 0 80 56")));
M_1567 = (GetK(MEMO_57, Get(r_1559, "c21")) is var _t1576 && Truthy(_t1576) ? _t1576 : SetK(MEMO_57, Get(r_1559, "c21"), Call(Fn((V _arrowThis1574, int _argc1568, V _a1570, V _a1571, V _a1572, V _a1573, V[] _rest1569) => {
V G_1575 = default;
G_1575 = Call(mkV_29, V.Undef, Get(FRM_30, "room"));
return NewObj(2).Put("svg", Invoke(RD_8, "svgDoc", ((V)("0 0 80 56")), Arr(), Call(cardOf_49, V.Undef, Get(r_1559, "c21")))).Put("room", Invoke(RD_8, "svgDoc", ((V)(JsStrBuf.Begin().S("0 0 ").V(Get(G_1575, "W")).S(" ").V(Get(G_1575, "H")).End())), Arr(), Call(doc_38, V.Undef, G_1575, Call(k_1564, V.Undef, G_1575)))).V;
return default;
}, 0, "", true), V.Undef)));
Set(res_1562, "svg", Get(M_1567, "svg"));
Set(res_1562, "src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, Get(M_1567, "svg"))).End())));
Set(res_1562, "ceilRoom", Get(M_1567, "room"));
Set(res_1562, "ceilBase", GetIdx(GetK(CBASE_47, Get(r_1559, "c21")), 0D));
Set(res_1562, "ceilTrim", GetIdx(GetK(CBASE_47, Get(r_1559, "c21")), 1D));
}
} catch (System.Exception _ex1577) {
V e_1578 = default;
e_1578 = Caught(_ex1577);
Invoke(G("console"), "warn", ((V)("reno plus21")), Get(r_1559, "id"), e_1578);
}
return res_1562;
return default;
}, 2, "", true));
Set(RD_8, "SET21", NewObj(10).Put("LIV-009", NewObj(3).Put("c21", ((V)("pop"))).Put("live", ((V)("Fluttering paint flake"))).Put("note", ((V)("An old popcorn stucco ceiling gone yellow, with brown rings where the roof once leaked, a hairline crack, a cobweb in the corner and a peeled patch where a curl of paint hangs and flutters in the draft."))).V).Put("LIV-029", NewObj(3).Put("c21", ((V)("cove"))).Put("live", ((V)("Blinking smoke alarm"))).Put("note", ((V)("A smooth, freshly skimmed warm-white ceiling with a deep curved cove moulding all round, a soft sage glow from the walls, a white air vent and a smoke alarm whose little red light blinks."))).V).Put("LIV-049", NewObj(2).Put("c21", ((V)("beam"))).Put("note", ((V)("Four heavy cedar beams across the room with real grain, knots and checks, held by black iron straps, over whitewashed pine boards and a cedar wall plate."))).V).Put("LIV-069", NewObj(2).Put("c21", ((V)("med"))).Put("note", ((V)("A cream plaster ceiling with two panel mouldings (the inner one with a thin gilded line), corner rosettes, a carved acanthus medallion right above the light and a deep crown moulding with a dentil row."))).V).Put("LIV-089", NewObj(3).Put("c21", ((V)("vault"))).Put("live", ((V)("Drifting clouds"))).Put("note", ((V)("A brass-rimmed opening in the polished white ceiling rises to a glass barrel vault: steel ribs, blue sky, slow drifting clouds, a sun glint gliding over the glass and now and then a bird flying over."))).V).Put("LIV-018", NewObj(4).Put("spec", ((V)("dome21"))).Put("s3", V.Null).Put("live", ((V)("Flickering"))).Put("note", ((V)("A cheap frosted plastic dome light that has gone yellow, on a metal ring with a chrome nut at the bottom. A few dead bugs sit inside and it flickers now and then."))).V).Put("LIV-038", NewObj(4).Put("spec", ((V)("rattan21"))).Put("s3", V.Null).Put("live", ((V)("Swaying shade"))).Put("note", ((V)("A bell-shaped pendant of criss-cross woven rattan on a black cord. Warm light glows through the gaps and throws dappled spots on the ceiling while it sways gently."))).V).Put("LIV-058", NewObj(4).Put("spec", ((V)("sput21"))).Put("s3", V.Null).Put("live", ((V)("Twinkling bulbs"))).Put("note", ((V)("A brushed-brass Sputnik chandelier: a brass ball on a rod with 12 arms reaching out in every direction, each ending in a round glowing bulb that twinkles softly."))).V).Put("LIV-078", NewObj(4).Put("spec", ((V)("mura21"))).Put("s3", V.Null).Put("live", ((V)("Swinging glass"))).Put("note", ((V)("Three brass rings in tiers hung with hand-blown smoked-amber Murano glass drops. Warm light glows inside, each drop swings on its hook and catches a glint."))).V).Put("LIV-098", NewObj(4).Put("spec", ((V)("const21"))).Put("s3", V.Null).Put("live", ((V)("Floating crystals"))).Put("note", ((V)("A slim glowing disc on the ceiling with 26 cut crystals floating below it on no wires, each bobbing on its own, joined by fine light lines with pulses running along them while the crystals shift colour and sparkle."))).V).V);
edit20_58 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis1586, int _argc1579, V rows_1585, V _a1582, V _a1583, V _a1584, V[] _rest1580) => {
return Invoke(Call(edit20_58, V.Undef, rows_1585), "map", Fn((V _arrowThis1594, int _argc1587, V r_1593, V _a1590, V _a1591, V _a1592, V[] _rest1588) => {
return (Truthy(GetK(Get(RD_8, "SET21"), Get(r_1593, "id"))) ? Object_assign(NewObj(0).V, r_1593, GetK(Get(RD_8, "SET21"), Get(r_1593, "id"))) : r_1593);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H21", NewObj(4).Put("CEIL21", CEIL21_48).Put("band", band_34).Put("mould", mould_35).Put("mkV", mkV_29).V);
Set(RD_8, "PLUS21", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
