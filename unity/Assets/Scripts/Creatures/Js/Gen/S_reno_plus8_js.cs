// reno-plus8.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus8_js
    {

        public static void Run()
        {
Call(Named(boot_78 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V solid_11 = default;
V box_12 = default;
V cyl_13 = default;
V ball_14 = default;
V arcW_15 = default;
V prism_16 = default;
V prismZ_17 = default;
V f1_18 = default;
V rep_19 = default;
V rng_20 = default;
V n4_21 = default;
V P2_22 = default;
V planeH_23 = default;
V plane_24 = default;
V planeX_25 = default;
V an_26 = default;
V BLUR_27 = default;
V bbOf_28 = default;
V mt_29 = default;
V wd_30 = default;
V cer_31 = default;
V pt_32 = default;
V tex_33 = default;
V atV_34 = default;
V once_35 = default;
V onceT_36 = default;
V G_37 = default;
V L_38 = default;
V ellPts_39 = default;
V lp_40 = default;
V sp_41 = default;
V quad_42 = default;
V planeT_43 = default;
V facing_44 = default;
V tube_45 = default;
V curve_46 = default;
V water_47 = default;
V WP_48 = default;
V WDEF_49 = default;
V FDEF_50 = default;
V smoke_51 = default;
V glowE_52 = default;
V isPlay_53 = default;
V N_54 = default;
double PI_55 = 0;
V GOLD_56 = default;
V CH_57 = default;
V B_58 = default;
V fb_59 = default;
V kOf_60 = default;
V V3_61 = default;
V LT_62 = default;
V dot_63 = default;
V LEAF_64 = default;
V LEAFT_65 = default;
V sprinkle_66 = default;
V fruitOn_67 = default;
V sway_68 = default;
V flower5_69 = default;
V stageOf_70 = default;
V GROW_71 = default;
V GROWT_72 = default;
V edit7_73 = default;
if (_self1.IsNullish) _self1 = GlobalV;
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((RD_8 is var _t74 && !Truthy(_t74) ? _t74 : Get(RD_8, "PLUS7")) is var _t75 && !Truthy(_t75) ? _t75 : Get(RD_8, "H7")) is var _t76 && !Truthy(_t76) ? _t76 : X_9) is var _t77 && !Truthy(_t77) ? _t77 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_78.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS8"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t79 = K_10;
if (_t79.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t79));
{ V _t80 = Get(_t79, "solid");
solid_11 = _t80; }
{ V _t81 = Get(_t79, "box");
box_12 = _t81; }
{ V _t82 = Get(_t79, "cyl");
cyl_13 = _t82; }
{ V _t83 = Get(_t79, "ball");
ball_14 = _t83; }
{ V _t84 = Get(_t79, "arcW");
arcW_15 = _t84; }
{ V _t85 = Get(_t79, "prism");
prism_16 = _t85; }
{ V _t86 = Get(_t79, "prismZ");
prismZ_17 = _t86; }
{ V _t87 = Get(_t79, "f1");
f1_18 = _t87; } }
{ V _t88 = Get(RD_8, "H3");
if (_t88.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t88));
{ V _t89 = Get(_t88, "rep");
rep_19 = _t89; }
{ V _t90 = Get(_t88, "rng");
rng_20 = _t90; }
{ V _t91 = Get(_t88, "n4");
n4_21 = _t91; }
{ V _t92 = Get(_t88, "P2");
P2_22 = _t92; }
{ V _t93 = Get(_t88, "planeH");
planeH_23 = _t93; }
{ V _t94 = Get(_t88, "plane");
plane_24 = _t94; }
{ V _t95 = Get(_t88, "planeX");
planeX_25 = _t95; }
{ V _t96 = Get(_t88, "an");
an_26 = _t96; }
{ V _t97 = Get(_t88, "BLUR");
BLUR_27 = _t97; }
{ V _t98 = Get(_t88, "bbOf");
bbOf_28 = _t98; }
{ V _t99 = Get(_t88, "mt");
mt_29 = _t99; }
{ V _t100 = Get(_t88, "wd");
wd_30 = _t100; }
{ V _t101 = Get(_t88, "cer");
cer_31 = _t101; }
{ V _t102 = Get(_t88, "pt");
pt_32 = _t102; }
{ V _t103 = Get(_t88, "tex");
tex_33 = _t103; } }
{ V _t104 = Get(RD_8, "H7");
if (_t104.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t104));
{ V _t105 = Get(_t104, "atV");
atV_34 = _t105; }
{ V _t106 = Get(_t104, "once");
once_35 = _t106; }
{ V _t107 = Get(_t104, "onceT");
onceT_36 = _t107; }
{ V _t108 = Get(_t104, "G");
G_37 = _t108; }
{ V _t109 = Get(_t104, "L");
L_38 = _t109; }
{ V _t110 = Get(_t104, "ellPts");
ellPts_39 = _t110; }
{ V _t111 = Get(_t104, "lp");
lp_40 = _t111; }
{ V _t112 = Get(_t104, "sp");
sp_41 = _t112; }
{ V _t113 = Get(_t104, "quad");
quad_42 = _t113; }
{ V _t114 = Get(_t104, "planeT");
planeT_43 = _t114; }
{ V _t115 = Get(_t104, "facing");
facing_44 = _t115; }
{ V _t116 = Get(_t104, "tube");
tube_45 = _t116; }
{ V _t117 = Get(_t104, "curve");
curve_46 = _t117; }
{ V _t118 = Get(_t104, "water");
water_47 = _t118; }
{ V _t119 = Get(_t104, "WP");
WP_48 = _t119; }
{ V _t120 = Get(_t104, "WDEF");
WDEF_49 = _t120; }
{ V _t121 = Get(_t104, "FDEF");
FDEF_50 = _t121; }
{ V _t122 = Get(_t104, "smoke");
smoke_51 = _t122; }
{ V _t123 = Get(_t104, "glowE");
glowE_52 = _t123; }
{ V _t124 = Get(_t104, "isPlay");
isPlay_53 = _t124; } }
N_54 = Get(RD_8, "N");
PI_55 = System.Math.PI;
GOLD_56 = ((V)("#e2b14a"));
CH_57 = ((V)("#d5dde2"));
B_58 = Fn((V _arrowThis132, int _argc125, V b_131, V _a128, V _a129, V _a130, V[] _rest126) => {
return ((V)((Truthy(b_131) ? string.Concat(" begin=\"", ToStr(Call(n4_21, V.Undef, b_131)), "s\"") : "")));
}, 1, "", true);
fb_59 = Fn((V _arrowThis140, int _argc133, V o_139, V _a136, V _a137, V _a138, V[] _rest134) => {
return Object_assign(NewObj(2).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).V, (o_139 is var _t141 && Truthy(_t141) ? _t141 : NewObj(0).V));
}, 1, "", true);
kOf_60 = Fn((V _arrowThis149, int _argc142, V p_148, V _a145, V _a146, V _a147, V[] _rest143) => {
return ((V)(((ToNum(GetIdx(Call(p_148, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D))), 1D)) - ToNum(GetIdx(Call(p_148, V.Undef, ((V)(0D)), ((V)(1D)), ((V)(0D))), 1D))) / ToNum(Get(X_9, "CA")))));
}, 1, "", true);
V3_61 = Arr(((V)(0.394)), ((V)(0.616)), ((V)(0.682)));
LT_62 = Arr(((V)((-0.42))), ((V)(0.8)), ((V)(0.43)));
dot_63 = Fn((V _arrowThis158, int _argc150, V a_156, V b_157, V _a154, V _a155, V[] _rest151) => {
return ((V)((((ToNum(GetIdx(a_156, 0D)) * ToNum(GetIdx(b_157, 0D))) + (ToNum(GetIdx(a_156, 1D)) * ToNum(GetIdx(b_157, 1D)))) + (ToNum(GetIdx(a_156, 2D)) * ToNum(GetIdx(b_157, 2D))))));
}, 2, "", true);
LEAF_64 = ((V)(string.Concat("<pattern id=\"q8lf\" width=\"7\" height=\"6\" patternUnits=\"userSpaceOnUse\"><path d=\"M1 2.4q1.4-1.6 3 0q-1.6 1.2-3 0Z\" fill=\"#ffffff\" fill-opacity=\"0.3\"/><path d=\"M4 5q1.3-1.4 2.8 0q-1.4 1.1-2.8 0Z\" fill=\"#000000\" fill-opacity=\"0.22\"/><path d=\"M0.4 5.2q1-1 2 0M5 1.2q0.8-0.8 1.6 0\" stroke=\"#000000\" stroke-opacity=\"0.2\" stroke-width=\"0.3\" fill=\"none\"/></pattern>", "<pattern id=\"q8lf2\" width=\"11\" height=\"9\" patternUnits=\"userSpaceOnUse\"><path d=\"M1 3q2.2-2.4 4.6 0q-2.4 1.8-4.6 0Z\" fill=\"#000000\" fill-opacity=\"0.16\"/><path d=\"M6 7.4q2-2 4.2 0q-2.2 1.6-4.2 0Z\" fill=\"#ffffff\" fill-opacity=\"0.2\"/></pattern>", "<pattern id=\"q8wv\" width=\"3\" height=\"3\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 0.75H3M0 2.25H3\" stroke=\"#5a3a1a\" stroke-opacity=\"0.35\" stroke-width=\"0.5\"/><path d=\"M0.75 0V0.75M2.25 0.75V2.25M0.75 2.25V3\" stroke=\"#ffffff\" stroke-opacity=\"0.22\" stroke-width=\"0.45\"/></pattern>")));
LEAFT_65 = Fn((V _arrowThis166, int _argc159, V s_165, V _a162, V _a163, V _a164, V[] _rest160) => {
return Call(tex_33, V.Undef, s_165, Arr(Arr(((V)("q8lf")), ((V)(0.9))), Arr(((V)("q8lf2")), ((V)(0.6)))));
}, 1, "", true);
sprinkle_66 = Fn((V _arrowThis180, int _argc167, V p_173, V k_174, V cl_175, V cols_176, V[] _rest168) => {
V R_181 = default;
JsStrBuf s_182 = null;
V seed_177 = default;
V per_178 = default;
V sz_179 = default;
seed_177 = (_argc167 > 4 ? _rest168[0] : V.Undef);
per_178 = (_argc167 > 5 ? _rest168[1] : V.Undef);
sz_179 = (_argc167 > 6 ? _rest168[2] : V.Undef);
R_181 = Call(rng_20, V.Undef, seed_177);
s_182 = new JsStrBuf("");
sz_179 = (sz_179 is var _t183 && Truthy(_t183) ? _t183 : ((V)(1D)));
Invoke(cl_175, "forEach", Fn((V _arrowThis199, int _argc184, V _a186, V _a187, V _a188, V _a189, V[] _rest185) => {
V x_192 = default;
V y_194 = default;
V z_196 = default;
V r_198 = default;
{ V _t190 = ListOf(_a186);
{ V _t191 = GetIdx(_t190, 0D);
x_192 = _t191; }
{ V _t193 = GetIdx(_t190, 1D);
y_194 = _t193; }
{ V _t195 = GetIdx(_t190, 2D);
z_196 = _t195; }
{ V _t197 = GetIdx(_t190, 3D);
r_198 = _t197; }
}
return Call(rep_19, V.Undef, (per_178 is var _t200 && Truthy(_t200) ? _t200 : ((V)(10D))), Fn((V _arrowThis207, int _argc201, V _a203, V _a204, V _a205, V _a206, V[] _rest202) => {
V d_208 = default;
V q_209 = default;
V li_210 = default;
V c_211 = default;
d_208 = Arr(((V)(0D)), ((V)(1D)), ((V)(0D)));
{
double t_212 = 0;
t_212 = 0D;
while (true) {
if (!((t_212 < 8D))) break;
V c_214 = default;
V l_215 = default;
c_214 = Arr(((V)(((ToNum(Call(R_181, V.Undef)) * 2D) - 1D))), ((V)(((ToNum(Call(R_181, V.Undef)) * 2D) - 1D))), ((V)(((ToNum(Call(R_181, V.Undef)) * 2D) - 1D))));
l_215 = InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(c_214).V);
if ((GtN(l_215, 0.3) && LtN(l_215, 1D))) {
d_208 = Invoke(c_214, "map", Fn((V _arrowThis223, int _argc216, V v_222, V _a219, V _a220, V _a221, V[] _rest217) => {
return ((V)((ToNum(v_222) / ToNum(l_215))));
}, 1, "", true));
break;
}
t_212++;
}
}
if (LtN(Call(dot_63, V.Undef, d_208, V3_61), 0.2)) {
return default;
}
q_209 = Call(p_173, V.Undef, Add(x_192, ((V)((ToNum(GetIdx(d_208, 0D)) * ToNum(r_198))))), Add(y_194, ((V)(((ToNum(GetIdx(d_208, 1D)) * ToNum(r_198)) * 0.94)))), Add(z_196, ((V)((ToNum(GetIdx(d_208, 2D)) * ToNum(r_198))))));
li_210 = Call(dot_63, V.Undef, d_208, LT_62);
c_211 = (GtN(li_210, 0.45) ? GetIdx(cols_176, 2D) : (GtN(li_210, 0D) ? GetIdx(cols_176, 1D) : GetIdx(cols_176, 0D)));
s_182.S(string.Concat("<path d=\"M0 0q", ToStr(Call(f1_18, V.Undef, ((V)((1.3 * ToNum(sz_179)))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-1.1) * ToNum(sz_179)))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((2.8 * ToNum(sz_179)))))), " 0q", ToStr(Call(f1_18, V.Undef, ((V)(((-1.4) * ToNum(sz_179)))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((1.1 * ToNum(sz_179)))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-2.8) * ToNum(sz_179)))))), " 0Z\" fill=\"", ToStr(c_211), "\" transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_209)), ") rotate(", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(Call(R_181, V.Undef)) * 360D))))), ") scale(", ToStr(Call(n4_21, V.Undef, k_174)), ")\"/>"));
return default;
}, 0, "", true));
}, 1, "", true));
return ((V)(s_182.Str));
return default;
}, 7, "", true);
fruitOn_67 = Fn((V _arrowThis237, int _argc224, V o_230, V cl_231, V n_232, V col_233, V[] _rest225) => {
V R_238 = default;
V r_234 = default;
V seed_235 = default;
V o2_236 = default;
r_234 = (_argc224 > 4 ? _rest225[0] : V.Undef);
seed_235 = (_argc224 > 5 ? _rest225[1] : V.Undef);
o2_236 = (_argc224 > 6 ? _rest225[2] : V.Undef);
R_238 = Call(rng_20, V.Undef, seed_235);
Call(rep_19, V.Undef, n_232, Fn((V _arrowThis246, int _argc239, V i_245, V _a242, V _a243, V _a244, V[] _rest240) => {
V x_247 = default;
V y_248 = default;
V z_249 = default;
V rr_250 = default;
V d_251 = default;
{ V _t252 = GetIdx(cl_231, (ToNum(i_245) % ToNum(Get(cl_231, "length"))));
{ V _t253 = ListOf(_t252);
{ V _t254 = GetIdx(_t253, 0D);
x_247 = _t254; }
{ V _t255 = GetIdx(_t253, 1D);
y_248 = _t255; }
{ V _t256 = GetIdx(_t253, 2D);
z_249 = _t256; }
{ V _t257 = GetIdx(_t253, 3D);
rr_250 = _t257; }
} }
d_251 = V.Undef;
{
double t_258 = 0;
t_258 = 0D;
while (true) {
if (!((t_258 < 10D))) break;
V l_260 = default;
d_251 = Arr(((V)(((ToNum(Call(R_238, V.Undef)) * 2D) - 1D))), ((V)(((ToNum(Call(R_238, V.Undef)) * 0.8) - 0.5))), ((V)(((ToNum(Call(R_238, V.Undef)) * 2D) - 1D))));
l_260 = InvokeSpread(G("Math"), "hypot", new ArrBuilder().Spread(d_251).V);
d_251 = Invoke(d_251, "map", Fn((V _arrowThis268, int _argc261, V v_267, V _a264, V _a265, V _a266, V[] _rest262) => {
return ((V)((ToNum(v_267) / ToNum(l_260))));
}, 1, "", true));
if (GtN(Call(dot_63, V.Undef, d_251, V3_61), 0.1)) {
break;
}
t_258++;
}
}
Invoke(o_230, "push", Call(ball_14, V.Undef, Add(x_247, ((V)(((ToNum(GetIdx(d_251, 0D)) * ToNum(rr_250)) * 0.96)))), Add(y_248, ((V)(((ToNum(GetIdx(d_251, 1D)) * ToNum(rr_250)) * 0.9)))), Add(z_249, ((V)(((ToNum(GetIdx(d_251, 2D)) * ToNum(rr_250)) * 0.96)))), r_234, col_233, Object_assign(NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V, (o2_236 is var _t269 && Truthy(_t269) ? _t269 : NewObj(0).V))));
return default;
}, 1, "", true));
return default;
}, 7, "", true);
sway_68 = Fn((V _arrowThis283, int _argc270, V p_276, V x_277, V y_278, V z_279, V[] _rest271) => {
V q_284 = default;
V a_280 = default;
V d_281 = default;
V b_282 = default;
a_280 = (_argc270 > 4 ? _rest271[0] : V.Undef);
d_281 = (_argc270 > 5 ? _rest271[1] : V.Undef);
b_282 = (_argc270 > 6 ? _rest271[2] : V.Undef);
q_284 = Call(p_276, V.Undef, x_277, y_278, z_279);
return Call(atV_34, V.Undef, ((V)("rotate")), Arr(((V)(string.Concat(NumStr((-ToNum(a_280))), " ", ToStr(Call(P2_22, V.Undef, q_284))))), ((V)(string.Concat(ToStr(a_280), " ", ToStr(Call(P2_22, V.Undef, q_284))))), ((V)(string.Concat(NumStr((-ToNum(a_280))), " ", ToStr(Call(P2_22, V.Undef, q_284)))))), d_281, b_282);
return default;
}, 7, "", true);
flower5_69 = Fn((V _arrowThis296, int _argc285, V q_291, V k_292, V s_293, V col_294, V[] _rest286) => {
V mid_295 = default;
mid_295 = (_argc285 > 4 ? _rest286[0] : V.Undef);
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_291)), ") scale(", ToStr(Call(n4_21, V.Undef, ((V)((ToNum(k_292) * ToNum(s_293)))))), ")\">", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(5D)), Fn((V _arrowThis304, int _argc297, V i_303, V _a300, V _a301, V _a302, V[] _rest298) => {
return ((V)(string.Concat("<ellipse cx=\"0\" cy=\"-1.1\" rx=\"0.75\" ry=\"1.1\" fill=\"", ToStr(col_294), "\" transform=\"rotate(", NumStr((ToNum(i_303) * 72D)), ")\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<circle r=\"0.55\" fill=\"", ToStr((mid_295 is var _t305 && Truthy(_t305) ? _t305 : ((V)("#ffd23a")))), "\"/></g>")));
}, 5, "", true);
stageOf_70 = Fn((V _arrowThis313, int _argc306, V S_312, V _a309, V _a310, V _a311, V[] _rest307) => {
V M_314 = default;
M_314 = ((Get(S_312, "row") is var _t315 && !Truthy(_t315) ? _t315 : Get(Get(S_312, "row"), "modes")) is var _t316 && Truthy(_t316) ? _t316 : Arr());
return ((V)(Max(0D, ToNum(Invoke(M_314, "indexOf", Get(S_312, "st"))))));
return default;
}, 1, "", true);
Set(N_54, "lemon8", Fn((V _arrowThis324, int _argc317, V S_323, V _a320, V _a321, V _a322, V[] _rest318) => {
V CL_325 = default;
V GR_326 = default;
V D_327 = default;
CL_325 = Arr(Arr(((V)(0D)), ((V)(66D)), ((V)(0D)), ((V)(16D))), Arr(((V)((-15D))), ((V)(58D)), ((V)(4D)), ((V)(12.5))), Arr(((V)(15D)), ((V)(60D)), ((V)((-2D))), ((V)(13D))), Arr(((V)((-7D))), ((V)(79D)), ((V)((-6D))), ((V)(12.5))), Arr(((V)(9D)), ((V)(77D)), ((V)(7D)), ((V)(12D))), Arr(((V)((-18D))), ((V)(71D)), ((V)((-5D))), ((V)(10D))), Arr(((V)(18D)), ((V)(72D)), ((V)(8D)), ((V)(10D))), Arr(((V)(2D)), ((V)(54D)), ((V)(12D)), ((V)(11D))), Arr(((V)(0D)), ((V)(88D)), ((V)(2D)), ((V)(9.5))), Arr(((V)((-4D))), ((V)(62D)), ((V)(14D)), ((V)(9D))));
GR_326 = Arr(((V)("#2f6a2a")), ((V)("#3f8a34")), ((V)("#5aa844")));
D_327 = NewObj(3).Put("w", ((V)(60D))).Put("d", ((V)(60D))).Put("round", ((V)(1D))).V;
Set(D_327, "build", Fn((V _arrowThis335, int _argc328, V P_334, V _a331, V _a332, V _a333, V[] _rest329) => {
return new ArrBuilder().Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(24D)), ((V)("#9a6a3c")), Call(wd_30, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.88))), Arr(((V)(12D)), ((V)(0D)), ((V)(1D))), Arr(((V)(24D)), ((V)(0D)), ((V)(0.96))))).V))).Spread(Invoke(Arr(((V)(4D)), ((V)(19D))), "map", Fn((V _arrowThis343, int _argc336, V y_342, V _a339, V _a340, V _a341, V[] _rest337) => {
return Call(arcW_15, V.Undef, ((V)(0D)), y_342, ((V)(0D)), ((V)(20.6)), ((V)(20.6)), ((V)(1.2)), ((V)(2.2)), ((V)(4.4)), ((V)((4.4 + (2D * PI_55)))), ((V)("#3a3c42")), Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(30D))).Put("shine", ((V)(1D))).V));
}, 1, "", true))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(23D)), ((V)(0D)), ((V)(18.6)), ((V)(1.2)), ((V)("#4a3424")), Call(pt_32, V.Undef, NewObj(1).Put("n", ((V)(26D))).V))).Add(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(23D)), ((V)(0D)), ((V)(2.6)), ((V)(26D)), ((V)("#7a5a3e")), Call(wd_30, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.25))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))), Arr(((V)(26D)), ((V)(0D)), ((V)(0.75))))).V))).V;
}, 1, "", true));
Set(D_327, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis351, int _argc344, V P_350, V _a347, V _a348, V _a349, V[] _rest345) => {
V o_352 = default;
o_352 = Invoke(CL_325, "map", Fn((V _arrowThis369, int _argc353, V _a355, V i_359, V _a357, V _a358, V[] _rest354) => {
V x_362 = default;
V y_364 = default;
V z_366 = default;
V r_368 = default;
{ V _t360 = ListOf(_a355);
{ V _t361 = GetIdx(_t360, 0D);
x_362 = _t361; }
{ V _t363 = GetIdx(_t360, 1D);
y_364 = _t363; }
{ V _t365 = GetIdx(_t360, 2D);
z_366 = _t365; }
{ V _t367 = GetIdx(_t360, 3D);
r_368 = _t367; }
}
return Call(ball_14, V.Undef, x_362, y_364, z_366, r_368, GetIdx(GR_326, (ToNum(i_359) % 3D)), Call(pt_32, V.Undef, NewObj(4).Put("k", ((V)(5D))).Put("n", ((V)(14D))).Put("soft", ((V)(1D))).Put("sy", ((V)(0.9))).V));
}, 2, "", true));
Call(fruitOn_67, V.Undef, o_352, CL_325, ((V)(11D)), ((V)("#f6d23a")), ((V)(2.5)), ((V)("lem")), NewObj(1).Put("sx", ((V)(1.15))).V);
return o_352;
return default;
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis378, int _argc370, V p_376, V s_377, V _a374, V _a375, V[] _rest371) => {
V k_379 = default;
JsStrBuf br_380 = null;
JsStrBuf bl_381 = null;
V R_382 = default;
k_379 = Call(kOf_60, V.Undef, p_376);
br_380 = new JsStrBuf("");
Invoke(Arr(Arr(((V)((-12D))), ((V)(58D)), ((V)(4D))), Arr(((V)(12D)), ((V)(60D)), ((V)((-2D)))), Arr(((V)(0D)), ((V)(70D)), ((V)(0D))), Arr(((V)(8D)), ((V)(74D)), ((V)(6D))), Arr(((V)((-6D))), ((V)(76D)), ((V)((-6D))))), "forEach", Fn((V _arrowThis390, int _argc383, V c_389, V _a386, V _a387, V _a388, V[] _rest384) => {
return ((V)(br_380.V(Call(tube_45, V.Undef, Invoke(Call(curve_46, V.Undef, Arr(((V)(0D)), ((V)(48D)), ((V)(0D))), Arr(((V)((ToNum(GetIdx(c_389, 0D)) * 0.3))), ((V)(54D)), ((V)((ToNum(GetIdx(c_389, 2D)) * 0.3)))), c_389, ((V)(5D))), "map", Fn((V _arrowThis398, int _argc391, V q_397, V _a394, V _a395, V _a396, V[] _rest392) => {
return CallSpread(p_376, V.Undef, new ArrBuilder().Spread(q_397).V);
}, 1, "", true)), ((V)(1.6)), k_379, ((V)("#7a5a3e")), ((V)("#b08a64")), ((V)("#3a2a1a")))).Str));
}, 1, "", true));
bl_381 = new JsStrBuf("");
R_382 = Call(rng_20, V.Undef, ((V)("lbl")));
Call(rep_19, V.Undef, ((V)(7D)), Fn((V _arrowThis406, int _argc399, V i_405, V _a402, V _a403, V _a404, V[] _rest400) => {
V c_407 = default;
c_407 = GetK(CL_325, i_405);
bl_381.V(Call(flower5_69, V.Undef, Call(p_376, V.Undef, Add(GetIdx(c_407, 0D), ((V)(((ToNum(Call(R_382, V.Undef)) - 0.5) * 8D)))), Add(GetIdx(c_407, 1D), ((V)((ToNum(GetIdx(c_407, 3D)) * 0.6)))), Add(GetIdx(c_407, 2D), ((V)((ToNum(GetIdx(c_407, 3D)) * 0.7))))), k_379, ((V)(0.9)), ((V)("#fffaf0")), ((V)("#f2c14a"))));
return default;
}, 1, "", true));
return ((V)(string.Concat("<g>", ToStr(Call(sway_68, V.Undef, p_376, ((V)(0D)), ((V)(48D)), ((V)(0D)), ((V)(1.1)), ((V)(5.2)))), br_380.Str, ToStr(Call(LEAFT_65, V.Undef, s_377)), ToStr(Call(sprinkle_66, V.Undef, p_376, k_379, CL_325, Invoke(GR_326, "map", Fn((V _arrowThis415, int _argc408, V c_414, V _a411, V _a412, V _a413, V[] _rest409) => {
return (Truthy(Get(K_10, "shade")) ? Invoke(K_10, "shade", c_414, ((V)(1.15))) : c_414);
}, 1, "", true)), ((V)("lml")), ((V)(14D)), ((V)(1.15)))), bl_381.Str, "</g>")));
return default;
}, 2, "wrap", true)).V));
Set(D_327, "fx", Fn((V _arrowThis423, int _argc416, V c_422, V _a419, V _a420, V _a421, V[] _rest417) => {
V p_424 = default;
V k_425 = default;
JsStrBuf f_426 = null;
p_424 = Get(c_422, "p");
k_425 = Get(c_422, "k");
f_426 = new JsStrBuf("");
Call(rep_19, V.Undef, ((V)(16D)), Fn((V _arrowThis434, int _argc427, V i_433, V _a430, V _a431, V _a432, V[] _rest428) => {
double th_435 = 0;
th_435 = (((ToNum(i_433) / 16D) * 2D) * PI_55);
if (LtN(Call(facing_44, V.Undef, ((V)(th_435))), 0.05)) {
return default;
}
f_426.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, Call(p_424, V.Undef, ((V)((20.4 * FdLibm.Sin(th_435)))), ((V)(0.6)), ((V)((20.4 * FdLibm.Cos(th_435))))))), "L", ToStr(Call(P2_22, V.Undef, Call(p_424, V.Undef, ((V)((20.4 * FdLibm.Sin(th_435)))), ((V)(23.4)), ((V)((20.4 * FdLibm.Cos(th_435))))))), "\" stroke=\"#5a3a1e\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.5 * ToNum(k_425)))))), "\" opacity=\"0.55\"/>"));
return default;
}, 1, "", true));
f_426.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_424, ((V)(24.3)))), "\">", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(18D)), Fn((V _arrowThis443, int _argc436, V i_442, V _a439, V _a440, V _a441, V[] _rest437) => {
double a_444 = 0;
double r_445 = 0;
a_444 = (ToNum(i_442) * 2.4);
r_445 = (4D + ((ToNum(i_442) % 6D) * 2.3));
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_18, V.Undef, ((V)((r_445 * FdLibm.Cos(a_444)))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)((r_445 * FdLibm.Sin(a_444)))))), "\" rx=\"1.6\" ry=\"0.9\" fill=\"", (NumTruthy((ToNum(i_442) % 2D)) ? "#7a5434" : "#5e4028"), "\" transform=\"rotate(", NumStr((ToNum(i_442) * 37D)), " ", ToStr(Call(f1_18, V.Undef, ((V)((r_445 * FdLibm.Cos(a_444)))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((r_445 * FdLibm.Sin(a_444)))))), ")\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))), "</g>"));
return NewObj(3).Put("defs", LEAF_64).Put("front", ((V)(f_426.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_424, V.Undef, ((V)((-28D))), ((V)(0D)), ((V)((-28D)))), Call(p_424, V.Undef, ((V)(28D)), ((V)(0D)), ((V)(28D))), Call(p_424, V.Undef, ((V)((-28D))), ((V)(0D)), ((V)(28D))), Call(p_424, V.Undef, ((V)(28D)), ((V)(0D)), ((V)((-28D)))), Call(p_424, V.Undef, ((V)(0D)), ((V)(102D)), ((V)(0D))), Call(p_424, V.Undef, ((V)((-36D))), ((V)(72D)), ((V)(0D))), Call(p_424, V.Undef, ((V)(36D)), ((V)(72D)), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_327;
return default;
}, 1, "", true));
Set(N_54, "parterre8", Fn((V _arrowThis453, int _argc446, V S_452, V _a449, V _a450, V _a451, V[] _rest447) => {
double W_454 = 0;
double DZ_455 = 0;
V HG_456 = default;
V HG2_457 = default;
V D_458 = default;
W_454 = 74D;
DZ_455 = 50D;
HG_456 = ((V)("#3f7a34"));
HG2_457 = ((V)("#4f8f3e"));
D_458 = NewObj(2).Put("w", ((V)(160D))).Put("d", ((V)(110D))).V;
Set(D_458, "build", Fn((V _arrowThis466, int _argc459, V P_465, V _a462, V _a463, V _a464, V[] _rest460) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(((2D * W_454) + 4D))), ((V)(1.4)), ((V)(((2D * DZ_455) + 4D))), ((V)("#d9cdb2")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(7D)), ((V)(9D)), ((V)("#c4683a")), Call(pt_32, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(2D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(7D)), ((V)(0D)), ((V)(1D))), Arr(((V)(9D)), ((V)(0D)), ((V)(1.08))))).V)));
}, 1, "", true));
Set(D_458, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis474, int _argc467, V P_473, V _a470, V _a471, V _a472, V[] _rest468) => {
V o_475 = default;
V H2_476 = default;
o_475 = Arr();
H2_476 = Fn((V _arrowThis487, int _argc477, V x_483, V z_484, V w_485, V d_486, V[] _rest478) => {
return Invoke(o_475, "push", Call(box_12, V.Undef, x_483, ((V)(1.4)), z_484, w_485, ((V)(7D)), d_486, HG_456, Call(fb_59, V.Undef, NewObj(2).Put("r", ((V)(3.2))).Put("bev", ((V)(2.4))).V)));
}, 4, "", true);
Call(H2_476, V.Undef, ((V)(0D)), ((V)((DZ_455 - 2D))), ((V)((2D * W_454))), ((V)(4.4)));
Call(H2_476, V.Undef, ((V)(0D)), ((V)(((-DZ_455) + 2D))), ((V)((2D * W_454))), ((V)(4.4)));
Call(H2_476, V.Undef, ((V)(((-W_454) + 2D))), ((V)(0D)), ((V)(4.4)), ((V)(((2D * DZ_455) - 8D))));
Call(H2_476, V.Undef, ((V)((W_454 - 2D))), ((V)(0D)), ((V)(4.4)), ((V)(((2D * DZ_455) - 8D))));
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis499, int _argc488, V _a490, V _a491, V _a492, V _a493, V[] _rest489) => {
V sx_496 = default;
V sz_498 = default;
{ V _t494 = ListOf(_a490);
{ V _t495 = GetIdx(_t494, 0D);
sx_496 = _t495; }
{ V _t497 = GetIdx(_t494, 1D);
sz_498 = _t497; }
}
Call(H2_476, V.Undef, ((V)(((ToNum(sx_496) * W_454) / 2D))), ((V)(((ToNum(sz_498) * DZ_455) / 2D))), ((V)(4D)), ((V)((DZ_455 - 14D))));
Call(H2_476, V.Undef, ((V)((ToNum(sx_496) * (W_454 / 2D)))), ((V)((ToNum(sz_498) * (DZ_455 / 2D)))), ((V)((W_454 - 22D))), ((V)(4D)));
Invoke(o_475, "push", Call(ball_14, V.Undef, ((V)((ToNum(sx_496) * (W_454 - 10D)))), ((V)(12D)), ((V)((ToNum(sz_498) * (DZ_455 - 10D)))), ((V)(5.6)), HG2_457, Call(fb_59, V.Undef, NewObj(2).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V)), Call(cyl_13, V.Undef, ((V)((ToNum(sx_496) * (W_454 - 10D)))), ((V)(1.4)), ((V)((ToNum(sz_498) * (DZ_455 - 10D)))), ((V)(1.2)), ((V)(6D)), ((V)("#6a4a2a")), Call(wd_30, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
return default;
}, 1, "", true));
Invoke(o_475, "push", Call(ball_14, V.Undef, ((V)(0D)), ((V)(18.6)), ((V)(0D)), ((V)(8.4)), HG2_457, Call(fb_59, V.Undef, NewObj(2).Put("k", ((V)(5D))).Put("n", ((V)(14D))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(0D)), ((V)(5.4)), HG2_457, Call(fb_59, V.Undef, NewObj(2).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V)));
Call(rep_19, V.Undef, ((V)(20D)), Fn((V _arrowThis507, int _argc500, V i_506, V _a503, V _a504, V _a505, V[] _rest501) => {
double t_508 = 0;
t_508 = (((ToNum(i_506) / 20D) * 2D) * PI_55);
Invoke(o_475, "push", Call(ball_14, V.Undef, ((V)((20D * FdLibm.Cos(t_508)))), ((V)(4.4)), ((V)((14D * FdLibm.Sin(t_508)))), ((V)(3.2)), HG2_457, Call(fb_59, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
return default;
}, 1, "", true));
return o_475;
return default;
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis517, int _argc509, V p_515, V s_516, V _a513, V _a514, V[] _rest510) => {
return Call(LEAFT_65, V.Undef, s_516);
}, 2, "wrap", true)).V));
Set(D_458, "fx", Fn((V _arrowThis525, int _argc518, V c_524, V _a521, V _a522, V _a523, V[] _rest519) => {
V p_526 = default;
V k_527 = default;
JsStrBuf f_528 = null;
JsStrBuf bk_529 = null;
V arch_530 = default;
V R_531 = default;
p_526 = Get(c_524, "p");
k_527 = Get(c_524, "k");
f_528 = new JsStrBuf("");
bk_529 = new JsStrBuf("");
f_528.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_526, ((V)(1.5)))), "\" opacity=\"0.6\">", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(60D)), Fn((V _arrowThis539, int _argc532, V i_538, V _a535, V _a536, V _a537, V[] _rest533) => {
V R_540 = default;
R_540 = Call(Call(rng_20, V.Undef, ((V)(JsStrBuf.Begin().S("grv").V(i_538).End()))), V.Undef);
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, ((V)(((-W_454) + ((ToNum(i_538) * 37D) % 148D)))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)(((-DZ_455) + ((ToNum(i_538) * 53D) % 100D)))))), "\" r=\"", ToStr(Call(f1_18, V.Undef, Add(((V)(0.5)), R_540))), "\" fill=\"#b8ab8e\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))), "</g>"));
Invoke(Arr(Arr(((V)((-1D))), ((V)((-1D)))), Arr(((V)(1D)), ((V)((-1D)))), Arr(((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)(1D)))), "forEach", Fn((V _arrowThis553, int _argc541, V _a543, V j_547, V _a545, V _a546, V[] _rest542) => {
V R_554 = default;
V sx_550 = default;
V sz_552 = default;
{ V _t548 = ListOf(_a543);
{ V _t549 = GetIdx(_t548, 0D);
sx_550 = _t549; }
{ V _t551 = GetIdx(_t548, 1D);
sz_552 = _t551; }
}
R_554 = Call(rng_20, V.Undef, ((V)(JsStrBuf.Begin().S("rose").V(j_547).End())));
Call(rep_19, V.Undef, ((V)(9D)), Fn((V _arrowThis562, int _argc555, V i_561, V _a558, V _a559, V _a560, V[] _rest556) => {
double x_563 = 0;
double z_564 = 0;
V q_565 = default;
x_563 = (ToNum(sx_550) * ((W_454 / 2D) + ((ToNum(Call(R_554, V.Undef)) - 0.5) * 30D)));
z_564 = (ToNum(sz_552) * ((DZ_455 / 2D) + ((ToNum(Call(R_554, V.Undef)) - 0.5) * 22D)));
q_565 = Call(p_526, V.Undef, ((V)(x_563)), ((V)(4D)), ((V)(z_564)));
f_528.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_565)), ") scale(", ToStr(Call(n4_21, V.Undef, k_527)), ")\"><ellipse cx=\"0\" cy=\"0.6\" rx=\"3.4\" ry=\"1.6\" fill=\"#2f5a26\"/><path d=\"M-2.4 0q1-2.6 2.4-1.2q1.4-1.4 2.4 1.2\" fill=\"#3f7a34\"/>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(3D)), Fn((V _arrowThis573, int _argc566, V m_572, V _a569, V _a570, V _a571, V[] _rest567) => {
return ((V)(string.Concat("<circle cx=\"", NumStr(((ToNum(m_572) - 1D) * 1.6)), "\" cy=\"", NumStr(((-1.6) - (ToNum(m_572) % 2D))), "\" r=\"1.2\" fill=\"", ToStr(GetIdx(Arr(((V)("#e8345a")), ((V)("#f27aa0")), ((V)("#c81e44"))), (ToNum(Add(i_561, m_572)) % 3D))), "\"/><circle cx=\"", NumStr((((ToNum(m_572) - 1D) * 1.6) - 0.3)), "\" cy=\"", NumStr(((-1.9) - (ToNum(m_572) % 2D))), "\" r=\"0.4\" fill=\"#ffd0dc\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g>"));
return default;
}, 1, "", true));
return default;
}, 2, "", true));
arch_530 = Fn((V _arrowThis581, int _argc574, V side_580, V _a577, V _a578, V _a579, V[] _rest575) => {
return Call(rep_19, V.Undef, ((V)(13D)), Fn((V _arrowThis589, int _argc582, V i_588, V _a585, V _a586, V _a587, V[] _rest583) => {
double a_590 = 0;
a_590 = (PI_55 - ((ToNum(i_588) / 12D) * PI_55));
return Arr(((V)(((ToNum(side_580) * 3D) + (22D * FdLibm.Cos(a_590))))), ((V)((30D + (22D * FdLibm.Sin(a_590))))), ((V)(((-DZ_455) - 2D))));
return default;
}, 1, "", true));
}, 1, "", true);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis598, int _argc591, V s_597, V _a594, V _a595, V _a596, V[] _rest592) => {
V pts_599 = default;
V t_600 = default;
pts_599 = Invoke(Invoke(Arr(Arr(((V)((-22D))), ((V)(0D)), ((V)((((-DZ_455) - 2D) + (ToNum(s_597) * 3D))))), Arr(((V)((-22D))), ((V)(30D)), ((V)((((-DZ_455) - 2D) + (ToNum(s_597) * 3D)))))), "concat", Call(rep_19, V.Undef, ((V)(13D)), Fn((V _arrowThis608, int _argc601, V i_607, V _a604, V _a605, V _a606, V[] _rest602) => {
double a_609 = 0;
a_609 = (PI_55 - ((ToNum(i_607) / 12D) * PI_55));
return Arr(((V)((22D * FdLibm.Cos(a_609)))), ((V)((30D + (22D * FdLibm.Sin(a_609))))), ((V)((((-DZ_455) - 2D) + (ToNum(s_597) * 3D)))));
return default;
}, 1, "", true))), "concat", Arr(Arr(((V)(22D)), ((V)(0D)), ((V)((((-DZ_455) - 2D) + (ToNum(s_597) * 3D)))))));
t_600 = Call(tube_45, V.Undef, Invoke(pts_599, "map", Fn((V _arrowThis617, int _argc610, V q_616, V _a613, V _a614, V _a615, V[] _rest611) => {
return CallSpread(p_526, V.Undef, new ArrBuilder().Spread(q_616).V);
}, 1, "", true)), ((V)(1D)), k_527, ((V)("#f4f2ea")), ((V)("#ffffff")), ((V)("#6a6a60")));
if (LtN(s_597, 0D)) {
bk_529.V(t_600);
} else {
f_528.V(t_600);
}
return default;
}, 1, "", true));
_ = arch_530;
R_531 = Call(rng_20, V.Undef, ((V)("arch")));
Call(rep_19, V.Undef, ((V)(34D)), Fn((V _arrowThis625, int _argc618, V i_624, V _a621, V _a622, V _a623, V[] _rest619) => {
double u_626 = 0;
V a_627 = default;
V q_628 = default;
u_626 = (ToNum(i_624) / 33D);
a_627 = ((u_626 < 0.22) ? V.Null : ((V)((PI_55 - (((u_626 - 0.22) / 0.56) * PI_55)))));
q_628 = ((u_626 < 0.22) ? Call(p_526, V.Undef, ((V)((-22D))), ((V)(((u_626 / 0.22) * 30D))), ((V)(((-DZ_455) - 0.5)))) : ((u_626 > 0.78) ? Call(p_526, V.Undef, ((V)(22D)), ((V)((((1D - u_626) / 0.22) * 30D))), ((V)(((-DZ_455) - 0.5)))) : Call(p_526, V.Undef, ((V)((22D * FdLibm.Cos(ToNum(a_627))))), ((V)((30D + (22D * FdLibm.Sin(ToNum(a_627)))))), ((V)(((-DZ_455) - 0.5))))));
f_528.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_628)), ") scale(", ToStr(Call(n4_21, V.Undef, k_527)), ")\"><g>", ToStr(Call(atV_34, V.Undef, ((V)("rotate")), Arr(((V)("-6")), ((V)("6")), ((V)("-6"))), ((V)((4D + (ToNum(Call(R_531, V.Undef)) * 2D)))), ((V)(((-ToNum(Call(R_531, V.Undef))) * 3D))))), "<path d=\"M0 0q1.6-2.2 3.4-0.4q-1.6 1.6-3.4 0.4Z\" fill=\"", (GtN(Call(R_531, V.Undef), 0.5) ? "#3f7a34" : "#5a9a44"), "\" transform=\"rotate(", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(Call(R_531, V.Undef)) * 360D))))), ")\"/>", (((ToNum(i_624) % 3D) == 0D) ? string.Concat("<circle cx=\"1\" cy=\"-1\" r=\"1.5\" fill=\"", (GtN(Call(R_531, V.Undef), 0.5) ? "#f27aa0" : "#e8345a"), "\"/><circle cx=\"0.7\" cy=\"-1.3\" r=\"0.5\" fill=\"#ffd0dc\"/>") : ""), "</g></g>"));
return default;
}, 1, "", true));
return NewObj(4).Put("defs", LEAF_64).Put("back", ((V)(bk_529.Str))).Put("front", ((V)(f_528.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_526, V.Undef, ((V)(((-W_454) - 4D))), ((V)(0D)), ((V)(((-DZ_455) - 4D)))), Call(p_526, V.Undef, ((V)((W_454 + 4D))), ((V)(0D)), ((V)((DZ_455 + 4D)))), Call(p_526, V.Undef, ((V)(((-W_454) - 4D))), ((V)(0D)), ((V)((DZ_455 + 4D)))), Call(p_526, V.Undef, ((V)((W_454 + 4D))), ((V)(0D)), ((V)(((-DZ_455) - 4D)))), Call(p_526, V.Undef, ((V)(0D)), ((V)(56D)), ((V)((-DZ_455)))), Call(p_526, V.Undef, ((V)((-26D))), ((V)(40D)), ((V)((-DZ_455)))), Call(p_526, V.Undef, ((V)(26D)), ((V)(40D)), ((V)((-DZ_455))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_458;
return default;
}, 1, "", true));
Set(N_54, "grove8", Fn((V _arrowThis636, int _argc629, V S_635, V _a632, V _a633, V _a634, V[] _rest630) => {
V OL_637 = default;
V OG_638 = default;
V D_639 = default;
V CY_640 = default;
V CYG_641 = default;
OL_637 = Arr(Arr(((V)((-6D))), ((V)(72D)), ((V)(0D)), ((V)(15D))), Arr(((V)(10D)), ((V)(66D)), ((V)(6D)), ((V)(13D))), Arr(((V)((-20D))), ((V)(62D)), ((V)(6D)), ((V)(11D))), Arr(((V)(4D)), ((V)(84D)), ((V)((-6D))), ((V)(12D))), Arr(((V)(20D)), ((V)(76D)), ((V)((-4D))), ((V)(10.5))), Arr(((V)((-16D))), ((V)(82D)), ((V)((-8D))), ((V)(10.5))), Arr(((V)((-2D))), ((V)(60D)), ((V)(14D)), ((V)(10D))), Arr(((V)((-26D))), ((V)(72D)), ((V)((-2D))), ((V)(9D))), Arr(((V)(14D)), ((V)(86D)), ((V)(4D)), ((V)(9D))), Arr(((V)(26D)), ((V)(66D)), ((V)(6D)), ((V)(8.5))), Arr(((V)((-10D))), ((V)(92D)), ((V)(0D)), ((V)(8D))));
OG_638 = Arr(((V)("#6f8a5a")), ((V)("#8fa878")), ((V)("#b4c8a0")));
D_639 = NewObj(2).Put("w", ((V)(140D))).Put("d", ((V)(90D))).V;
CY_640 = Arr(Arr(((V)(46D)), ((V)((-18D))), ((V)(84D)), ((V)(9D))), Arr(((V)(54D)), ((V)(22D)), ((V)(70D)), ((V)(8D))));
CYG_641 = Arr(((V)("#1f3a22")), ((V)("#2f5232")), ((V)("#46704a")));
Set(D_639, "build", Fn((V _arrowThis649, int _argc642, V P_648, V _a645, V _a646, V _a647, V[] _rest643) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(62D)), ((V)(1.6)), ((V)("#d8ccb0")), Call(pt_32, V.Undef, NewObj(2).Put("n", ((V)(36D))).Put("rz", ((V)(38D))).V)), Call(ball_14, V.Undef, ((V)((-2D))), ((V)(1D)), ((V)(2D)), ((V)(9D)), ((V)("#6a5a48")), Call(wd_30, V.Undef, NewObj(4).Put("sx", ((V)(1.5))).Put("sy", ((V)(0.6))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V)));
}, 1, "", true));
Set(D_639, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis657, int _argc650, V P_656, V _a653, V _a654, V _a655, V[] _rest651) => {
V o_658 = default;
o_658 = Arr();
Invoke(CY_640, "forEach", Fn((V _arrowThis674, int _argc659, V _a661, V _a662, V _a663, V _a664, V[] _rest660) => {
V x_667 = default;
V z_669 = default;
V h_671 = default;
V r_673 = default;
{ V _t665 = ListOf(_a661);
{ V _t666 = GetIdx(_t665, 0D);
x_667 = _t666; }
{ V _t668 = GetIdx(_t665, 1D);
z_669 = _t668; }
{ V _t670 = GetIdx(_t665, 2D);
h_671 = _t670; }
{ V _t672 = GetIdx(_t665, 3D);
r_673 = _t672; }
}
return Invoke(o_658, "push", Call(cyl_13, V.Undef, x_667, ((V)(1D)), z_669, ((V)(1.8)), ((V)(6D)), ((V)("#5a4632")), Call(wd_30, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(cyl_13, V.Undef, x_667, ((V)(5D)), z_669, r_673, h_671, GetIdx(CYG_641, 1D), Call(fb_59, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.55))), Arr(((V)((ToNum(h_671) * 0.12))), ((V)(0D)), ((V)(0.92))), Arr(((V)((ToNum(h_671) * 0.35))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(h_671) * 0.65))), ((V)(0D)), ((V)(0.78))), Arr(((V)((ToNum(h_671) * 0.88))), ((V)(0D)), ((V)(0.36))), Arr(h_671, ((V)(0D)), ((V)(0.05))))).V)));
}, 1, "", true));
Invoke(OL_637, "forEach", Fn((V _arrowThis691, int _argc675, V _a677, V i_681, V _a679, V _a680, V[] _rest676) => {
V x_684 = default;
V y_686 = default;
V z_688 = default;
V r_690 = default;
{ V _t682 = ListOf(_a677);
{ V _t683 = GetIdx(_t682, 0D);
x_684 = _t683; }
{ V _t685 = GetIdx(_t682, 1D);
y_686 = _t685; }
{ V _t687 = GetIdx(_t682, 2D);
z_688 = _t687; }
{ V _t689 = GetIdx(_t682, 3D);
r_690 = _t689; }
}
return Invoke(o_658, "push", Call(ball_14, V.Undef, x_684, y_686, z_688, r_690, GetIdx(OG_638, (ToNum(i_681) % 2D)), Call(fb_59, V.Undef, NewObj(3).Put("k", ((V)(5D))).Put("n", ((V)(14D))).Put("sy", ((V)(0.72))).V)));
}, 2, "", true));
Call(fruitOn_67, V.Undef, o_658, OL_637, ((V)(14D)), ((V)("#2a2430")), ((V)(1.1)), ((V)("olv")), NewObj(2).Put("k", ((V)(2D))).Put("n", ((V)(6D))).V);
return o_658;
return default;
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis700, int _argc692, V p_698, V s_699, V _a696, V _a697, V[] _rest693) => {
V k_701 = default;
JsStrBuf tr_702 = null;
k_701 = Call(kOf_60, V.Undef, p_698);
tr_702 = new JsStrBuf("");
Invoke(Arr(Arr(((V)((-4D))), ((V)(0D))), Arr(((V)(3D)), ((V)(2D))), Arr(((V)(0D)), ((V)((-3D))))), "forEach", Fn((V _arrowThis715, int _argc703, V _a705, V j_709, V _a707, V _a708, V[] _rest704) => {
V pts_716 = default;
V dx_712 = default;
V dz_714 = default;
{ V _t710 = ListOf(_a705);
{ V _t711 = GetIdx(_t710, 0D);
dx_712 = _t711; }
{ V _t713 = GetIdx(_t710, 1D);
dz_714 = _t713; }
}
pts_716 = Call(rep_19, V.Undef, ((V)(9D)), Fn((V _arrowThis724, int _argc717, V i_723, V _a720, V _a721, V _a722, V[] _rest718) => {
double t_725 = 0;
double a_726 = 0;
t_725 = (ToNum(i_723) / 8D);
a_726 = ((t_725 * 3.6) + (ToNum(j_709) * 2.1));
return Arr(((V)((((ToNum(dx_712) * (1D - t_725)) + ((FdLibm.Cos(a_726) * 3.4) * (1D - (t_725 * 0.4)))) + ((ToNum(GetK(Arr(((V)((-8D))), ((V)(8D)), ((V)(2D))), j_709)) * t_725) * t_725)))), ((V)((2D + (t_725 * 58D)))), ((V)((((ToNum(dz_714) * (1D - t_725)) + ((FdLibm.Sin(a_726) * 3.4) * (1D - (t_725 * 0.4)))) + ((ToNum(GetK(Arr(((V)(2D)), ((V)(4D)), ((V)((-6D)))), j_709)) * t_725) * t_725)))));
return default;
}, 1, "", true));
tr_702.V(Call(tube_45, V.Undef, Invoke(pts_716, "map", Fn((V _arrowThis734, int _argc727, V q_733, V _a730, V _a731, V _a732, V[] _rest728) => {
return CallSpread(p_698, V.Undef, new ArrBuilder().Spread(q_733).V);
}, 1, "", true)), ((V)((4.6 - (ToNum(j_709) * 0.8)))), k_701, GetK(Arr(((V)("#7a6a58")), ((V)("#8a7a66")), ((V)("#6a5a4a"))), j_709), ((V)("#c8b8a0")), ((V)("#2e261e"))));
return default;
}, 2, "", true));
Invoke(Arr(Arr(((V)((-20D))), ((V)(62D)), ((V)(6D))), Arr(((V)(18D)), ((V)(76D)), ((V)((-4D)))), Arr(((V)(4D)), ((V)(82D)), ((V)((-6D))))), "forEach", Fn((V _arrowThis742, int _argc735, V c_741, V _a738, V _a739, V _a740, V[] _rest736) => {
return ((V)(tr_702.V(Call(tube_45, V.Undef, Invoke(Call(curve_46, V.Undef, Arr(((V)(0D)), ((V)(56D)), ((V)(0D))), Arr(((V)((ToNum(GetIdx(c_741, 0D)) * 0.4))), ((V)(62D)), ((V)((ToNum(GetIdx(c_741, 2D)) * 0.4)))), c_741, ((V)(5D))), "map", Fn((V _arrowThis750, int _argc743, V q_749, V _a746, V _a747, V _a748, V[] _rest744) => {
return CallSpread(p_698, V.Undef, new ArrBuilder().Spread(q_749).V);
}, 1, "", true)), ((V)(1.8)), k_701, ((V)("#7a6a58")), ((V)("#b8a890")), ((V)("#2e261e")))).Str));
}, 1, "", true));
return ((V)(string.Concat("<g>", ToStr(Call(sway_68, V.Undef, p_698, ((V)(50D)), ((V)(6D)), ((V)((-4D))), ((V)(0.7)), ((V)(6.4)))), tr_702.Str, ToStr(Call(LEAFT_65, V.Undef, s_699)), ToStr(Call(sprinkle_66, V.Undef, p_698, k_701, OL_637, Arr(((V)("#6a8456")), ((V)("#9ab286")), ((V)("#c8d8b4"))), ((V)("ols")), ((V)(16D)), ((V)(1.05)))), ToStr(Call(sprinkle_66, V.Undef, p_698, k_701, Invoke(CY_640, "map", Fn((V _arrowThis766, int _argc751, V _a753, V _a754, V _a755, V _a756, V[] _rest752) => {
V x_759 = default;
V z_761 = default;
V h_763 = default;
V r_765 = default;
{ V _t757 = ListOf(_a753);
{ V _t758 = GetIdx(_t757, 0D);
x_759 = _t758; }
{ V _t760 = GetIdx(_t757, 1D);
z_761 = _t760; }
{ V _t762 = GetIdx(_t757, 2D);
h_763 = _t762; }
{ V _t764 = GetIdx(_t757, 3D);
r_765 = _t764; }
}
return Arr(x_759, ((V)((5D + (ToNum(h_763) * 0.4)))), z_761, ((V)((ToNum(r_765) * 0.9))));
}, 1, "", true)), CYG_641, ((V)("cys")), ((V)(26D)), ((V)(0.8)))), "</g>")));
return default;
}, 2, "wrap", true)).V));
Set(D_639, "fx", Fn((V _arrowThis774, int _argc767, V c_773, V _a770, V _a771, V _a772, V[] _rest768) => {
V p_775 = default;
V k_776 = default;
JsStrBuf f_777 = null;
p_775 = Get(c_773, "p");
k_776 = Get(c_773, "k");
f_777 = new JsStrBuf("");
Invoke(Arr(Arr(((V)((-40D))), ((V)(20D))), Arr(((V)((-30D))), ((V)(28D))), Arr(((V)(24D)), ((V)(26D))), Arr(((V)((-48D))), ((V)(6D))), Arr(((V)(36D)), ((V)(24D)))), "forEach", Fn((V _arrowThis790, int _argc778, V _a780, V i_784, V _a782, V _a783, V[] _rest779) => {
V q_791 = default;
V x_787 = default;
V z_789 = default;
{ V _t785 = ListOf(_a780);
{ V _t786 = GetIdx(_t785, 0D);
x_787 = _t786; }
{ V _t788 = GetIdx(_t785, 1D);
z_789 = _t788; }
}
q_791 = Call(p_775, V.Undef, x_787, ((V)(1.6)), z_789);
f_777.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_791)), ") scale(", ToStr(Call(n4_21, V.Undef, k_776)), ")\"><g>", ToStr(Call(atV_34, V.Undef, ((V)("rotate")), Arr(((V)("-4")), ((V)("4")), ((V)("-4"))), ((V)((3D + (ToNum(i_784) * 0.4)))), ((V)((-ToNum(i_784)))))), ToStr(Invoke(Call(rep_19, V.Undef, ((V)(7D)), Fn((V _arrowThis799, int _argc792, V j_798, V _a795, V _a796, V _a797, V[] _rest793) => {
return ((V)(string.Concat("<path d=\"M0 0Q", ToStr(Call(f1_18, V.Undef, ((V)(((ToNum(j_798) - 3D) * 1.4))))), " -5 ", ToStr(Call(f1_18, V.Undef, ((V)(((ToNum(j_798) - 3D) * 2.2))))), " -9\" stroke=\"#7a9a5a\" stroke-width=\"0.6\" fill=\"none\"/><ellipse cx=\"", ToStr(Call(f1_18, V.Undef, ((V)(((ToNum(j_798) - 3D) * 2.2))))), "\" cy=\"-10.6\" rx=\"0.8\" ry=\"2\" fill=\"", (NumTruthy((ToNum(j_798) % 2D)) ? "#9a7ad8" : "#b49af0"), "\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g></g>"));
return default;
}, 2, "", true));
return NewObj(3).Put("defs", LEAF_64).Put("front", ((V)(f_777.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_775, V.Undef, ((V)((-64D))), ((V)(0D)), ((V)((-40D)))), Call(p_775, V.Undef, ((V)(64D)), ((V)(0D)), ((V)(40D))), Call(p_775, V.Undef, ((V)((-64D))), ((V)(0D)), ((V)(40D))), Call(p_775, V.Undef, ((V)(64D)), ((V)(0D)), ((V)((-40D)))), Call(p_775, V.Undef, ((V)(0D)), ((V)(98D)), ((V)(0D))), Call(p_775, V.Undef, ((V)(44D)), ((V)(92D)), ((V)((-16D)))), Call(p_775, V.Undef, ((V)((-36D))), ((V)(76D)), ((V)(6D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_639;
return default;
}, 1, "", true));
Set(N_54, "zen8", Fn((V _arrowThis807, int _argc800, V S_806, V _a803, V _a804, V _a805, V[] _rest801) => {
V LS_808 = default;
V LS2_809 = default;
V D_810 = default;
V lantern_811 = default;
LS_808 = ((V)("#d8cfbc"));
LS2_809 = ((V)("#c8bea8"));
D_810 = NewObj(3).Put("w", ((V)(150D))).Put("d", ((V)(100D))).Put("glow", Fn((V _arrowThis818, int _argc812, V _a814, V _a815, V _a816, V _a817, V[] _rest813) => {
return NewObj(2).Put("y", ((V)(26D))).Put("r", ((V)(40D))).V;
}, 0, "glow", true)).V;
lantern_811 = Fn((V _arrowThis828, int _argc819, V o_825, V x_826, V z_827, V _a824, V[] _rest820) => {
Invoke(o_825, "push", Call(cyl_13, V.Undef, x_826, ((V)(0D)), z_827, ((V)(7D)), ((V)(3D)), LS2_809, Call(pt_32, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(cyl_13, V.Undef, x_826, ((V)(3D)), z_827, ((V)(3D)), ((V)(14D)), LS_808, Call(pt_32, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(cyl_13, V.Undef, x_826, ((V)(17D)), z_827, ((V)(6D)), ((V)(2D)), LS2_809, Call(pt_32, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(box_12, V.Undef, x_826, ((V)(19D)), z_827, ((V)(9D)), ((V)(8D)), ((V)(9D)), LS_808, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(cyl_13, V.Undef, x_826, ((V)(27D)), z_827, ((V)(10D)), ((V)(4D)), LS2_809, Call(pt_32, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(1D)), ((V)(0D)), ((V)(1D))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.34))))).V)), Call(cyl_13, V.Undef, x_826, ((V)(31D)), z_827, ((V)(2.4)), ((V)(2D)), LS_808, Call(pt_32, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(ball_14, V.Undef, x_826, ((V)(34D)), z_827, ((V)(2.4)), LS2_809, Call(pt_32, V.Undef, NewObj(3).Put("sy", ((V)(1.4))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
return default;
}, 3, "", true);
Set(D_810, "build", Fn((V _arrowThis836, int _argc829, V P_835, V _a832, V _a833, V _a834, V[] _rest830) => {
V o_837 = default;
o_837 = Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(148D)), ((V)(1.2)), ((V)(98D)), ((V)("#e8e2d4")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Invoke(o_837, "push", Call(cyl_13, V.Undef, ((V)(0D)), ((V)(1.2)), ((V)((-18D))), ((V)(18D)), ((V)(5D)), LS2_809, Call(pt_32, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(3D)), ((V)(0D)), ((V)(1D))), Arr(((V)(5D)), ((V)(0D)), ((V)(0.92))))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(9D)), ((V)((-18D))), ((V)(15D)), LS_808, Call(pt_32, V.Undef, NewObj(5).Put("sx", ((V)(1.05))).Put("sy", ((V)(0.42))).Put("sz", ((V)(0.8))).Put("k", ((V)(4D))).Put("n", ((V)(16D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(10D)), ((V)((-21D))), ((V)(9.5)), ((V)(18D)), LS_808, Call(pt_32, V.Undef, NewObj(3).Put("n", ((V)(18D))).Put("rz", ((V)(7.5))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.08))), Arr(((V)(9D)), ((V)(0D)), ((V)(1D))), Arr(((V)(14D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(18D)), ((V)(0D)), ((V)(0.72))))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(31.6)), ((V)((-21D))), ((V)(6.2)), LS_808, Call(pt_32, V.Undef, NewObj(3).Put("k", ((V)(5D))).Put("n", ((V)(14D))).Put("sy", ((V)(1.08))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(38.6)), ((V)((-21D))), ((V)(2.6)), LS2_809, Call(pt_32, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(13.6)), ((V)((-13.6))), ((V)(4.6)), LS_808, Call(pt_32, V.Undef, NewObj(4).Put("sx", ((V)(1.4))).Put("sy", ((V)(0.5))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).V)), Call(ball_14, V.Undef, ((V)((-9.6))), ((V)(22D)), ((V)((-20.6))), ((V)(3.2)), LS_808, Call(pt_32, V.Undef, NewObj(3).Put("sy", ((V)(1.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)), Call(ball_14, V.Undef, ((V)(9.6)), ((V)(22D)), ((V)((-20.6))), ((V)(3.2)), LS_808, Call(pt_32, V.Undef, NewObj(3).Put("sy", ((V)(1.6))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
Call(lantern_811, V.Undef, o_837, ((V)((-48D))), ((V)((-26D))));
Call(lantern_811, V.Undef, o_837, ((V)(50D)), ((V)((-22D))));
Invoke(Arr(Arr(((V)((-30D))), ((V)(22D)), ((V)(9D))), Arr(((V)((-6D))), ((V)(30D)), ((V)(8D))), Arr(((V)(20D)), ((V)(26D)), ((V)(9D)))), "forEach", Fn((V _arrowThis851, int _argc838, V _a840, V _a841, V _a842, V _a843, V[] _rest839) => {
V x_846 = default;
V z_848 = default;
V r_850 = default;
{ V _t844 = ListOf(_a840);
{ V _t845 = GetIdx(_t844, 0D);
x_846 = _t845; }
{ V _t847 = GetIdx(_t844, 1D);
z_848 = _t847; }
{ V _t849 = GetIdx(_t844, 2D);
r_850 = _t849; }
}
return Invoke(o_837, "push", Call(cyl_13, V.Undef, x_846, ((V)(1.2)), z_848, r_850, ((V)(1.4)), ((V)("#9a9488")), Call(pt_32, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rz", ((V)((ToNum(r_850) * 0.7)))).V)));
}, 1, "", true));
Invoke(Arr(Arr(((V)((-60D))), ((V)(20D)), ((V)(9D))), Arr(((V)(58D)), ((V)(30D)), ((V)(7D))), Arr(((V)((-52D))), ((V)((-40D))), ((V)(7D))), Arr(((V)(40D)), ((V)(2D)), ((V)(5D)))), "forEach", Fn((V _arrowThis865, int _argc852, V _a854, V _a855, V _a856, V _a857, V[] _rest853) => {
V x_860 = default;
V z_862 = default;
V r_864 = default;
{ V _t858 = ListOf(_a854);
{ V _t859 = GetIdx(_t858, 0D);
x_860 = _t859; }
{ V _t861 = GetIdx(_t858, 1D);
z_862 = _t861; }
{ V _t863 = GetIdx(_t858, 2D);
r_864 = _t863; }
}
return Invoke(o_837, "push", Call(ball_14, V.Undef, x_860, ((V)(0.8)), z_862, r_864, ((V)("#5f8a3e")), Call(fb_59, V.Undef, NewObj(3).Put("sy", ((V)(0.5))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V)));
}, 1, "", true));
Invoke(o_837, "push", Call(ball_14, V.Undef, ((V)(40D)), ((V)(1D)), ((V)((-40D))), ((V)(9D)), ((V)("#8a8478")), Call(pt_32, V.Undef, NewObj(4).Put("sx", ((V)(1.4))).Put("sy", ((V)(0.8))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V)), Call(ball_14, V.Undef, ((V)((-24D))), ((V)(1D)), ((V)((-40D))), ((V)(6D)), ((V)("#7a756a")), Call(pt_32, V.Undef, NewObj(4).Put("sx", ((V)(1.2))).Put("sy", ((V)(0.9))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)));
return o_837;
return default;
}, 1, "", true));
Set(D_810, "fx", Fn((V _arrowThis873, int _argc866, V c_872, V _a869, V _a870, V _a871, V[] _rest867) => {
V p_874 = default;
V k_875 = default;
JsStrBuf f_876 = null;
JsStrBuf un_877 = null;
JsStrBuf rk_878 = null;
V q_879 = default;
p_874 = Get(c_872, "p");
k_875 = Get(c_872, "k");
f_876 = new JsStrBuf("");
un_877 = new JsStrBuf("");
rk_878 = new JsStrBuf("");
Call(rep_19, V.Undef, ((V)(15D)), Fn((V _arrowThis887, int _argc880, V i_886, V _a883, V _a884, V _a885, V[] _rest881) => {
double z_888 = 0;
z_888 = ((-46D) + (ToNum(i_886) * 6.4));
rk_878.S(string.Concat("<path d=\"M-72 ", ToStr(Call(f1_18, V.Undef, ((V)(z_888)))), "Q-36 ", ToStr(Call(f1_18, V.Undef, ((V)((z_888 + 1.2))))), " 0 ", ToStr(Call(f1_18, V.Undef, ((V)(z_888)))), "T72 ", ToStr(Call(f1_18, V.Undef, ((V)(z_888)))), "\" stroke=\"#c8bfae\" stroke-width=\"0.9\" fill=\"none\"/><path d=\"M-72 ", ToStr(Call(f1_18, V.Undef, ((V)((z_888 + 0.9))))), "Q-36 ", ToStr(Call(f1_18, V.Undef, ((V)((z_888 + 2.1))))), " 0 ", ToStr(Call(f1_18, V.Undef, ((V)((z_888 + 0.9))))), "T72 ", ToStr(Call(f1_18, V.Undef, ((V)((z_888 + 0.9))))), "\" stroke=\"#ffffff\" stroke-width=\"0.5\" fill=\"none\" opacity=\"0.7\"/>"));
return default;
}, 1, "", true));
f_876.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_874, ((V)(1.25)))), "\"><g clip-path=\"url(#z8c)\">", rk_878.Str, "</g>", ToStr(Invoke(Invoke(Arr(Arr(((V)(40D)), ((V)((-40D))), ((V)(13D))), Arr(((V)((-24D))), ((V)((-40D))), ((V)(9D)))), "map", Fn((V _arrowThis902, int _argc889, V _a891, V _a892, V _a893, V _a894, V[] _rest890) => {
V x_897 = default;
V z_899 = default;
V r_901 = default;
{ V _t895 = ListOf(_a891);
{ V _t896 = GetIdx(_t895, 0D);
x_897 = _t896; }
{ V _t898 = GetIdx(_t895, 1D);
z_899 = _t898; }
{ V _t900 = GetIdx(_t895, 2D);
r_901 = _t900; }
}
return Invoke(Call(rep_19, V.Undef, ((V)(3D)), Fn((V _arrowThis910, int _argc903, V j_909, V _a906, V _a907, V _a908, V[] _rest904) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(x_897), "\" cy=\"", ToStr(z_899), "\" rx=\"", ToStr(Add(r_901, ((V)((ToNum(j_909) * 3.4))))), "\" ry=\"", NumStr((ToNum(Add(r_901, ((V)((ToNum(j_909) * 3.4))))) * 0.8)), "\" fill=\"none\" stroke=\"#c8bfae\" stroke-width=\"0.9\"/>")));
}, 1, "", true)), "join", ((V)("")));
}, 1, "", true)), "join", ((V)("")))), "</g>"));
Invoke(Arr(Arr(((V)((-48D))), ((V)((-26D)))), Arr(((V)(50D)), ((V)((-22D))))), "forEach", Fn((V _arrowThis923, int _argc911, V _a913, V i_917, V _a915, V _a916, V[] _rest912) => {
V q_924 = default;
V u_925 = default;
V g_926 = default;
V x_920 = default;
V z_922 = default;
{ V _t918 = ListOf(_a913);
{ V _t919 = GetIdx(_t918, 0D);
x_920 = _t919; }
{ V _t921 = GetIdx(_t918, 1D);
z_922 = _t921; }
}
q_924 = Call(p_874, V.Undef, x_920, ((V)(23D)), Add(z_922, ((V)(4.6))));
u_925 = k_875;
f_876.S(string.Concat("<rect x=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(q_924, 0D)) - (2.4 * ToNum(u_925))))))), "\" y=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(q_924, 1D)) - (2.6 * ToNum(u_925))))))), "\" width=\"", ToStr(Call(f1_18, V.Undef, ((V)((4.8 * ToNum(u_925)))))), "\" height=\"", ToStr(Call(f1_18, V.Undef, ((V)((5D * ToNum(u_925)))))), "\" rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.6 * ToNum(u_925)))))), "\" fill=\"#ffd27a\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.75;1;0.82;0.95;0.75")), ((V)(2.2)), ((V)((-ToNum(i_917)))))), "</rect>"));
g_926 = Call(p_874, V.Undef, x_920, ((V)(23D)), z_922);
f_876.S(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(g_926, 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(g_926, 1D))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((14D * ToNum(u_925)))))), "\" fill=\"url(#f7g)\" opacity=\"0.65\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.5;0.75;0.55")), ((V)(2.4)), ((V)((-ToNum(i_917)))))), "</circle>"));
return default;
}, 2, "", true));
q_879 = Call(p_874, V.Undef, ((V)(0D)), ((V)(33D)), ((V)((-15.2))));
f_876.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_879)), ") scale(", ToStr(Call(n4_21, V.Undef, k_875)), ")\"><path d=\"M-2.4 -1.2q1 -0.7 1.8 0M0.6 -1.2q1 -0.7 1.8 0\" stroke=\"#8a8270\" stroke-width=\"0.5\" fill=\"none\"/><path d=\"M-1 2.4q1 0.6 2 0\" stroke=\"#8a8270\" stroke-width=\"0.45\" fill=\"none\"/></g>"));
un_877.V(Call(glowE_52, V.Undef, p_874, ((V)(0D)), ((V)(0D)), ((V)((-18D))), ((V)(30D)), ((V)(20D)), ((V)("#ffe6a8")), ((V)(0.2))));
return NewObj(4).Put("defs", ((V)(JsStrBuf.Begin().V(FDEF_50).S(string.Concat("<clipPath id=\"z8c\"><path d=\"M-72 -48H72V48H-72Z M20 -40a20 16 0 1 0 40 0a20 16 0 1 0 -40 0Z M-38 -40a14 11 0 1 0 28 0a14 11 0 1 0 -28 0Z\" clip-rule=\"evenodd\"/></clipPath>", "")).End()))).Put("under", ((V)(un_877.Str))).Put("front", ((V)(f_876.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_874, V.Undef, ((V)((-76D))), ((V)(0D)), ((V)((-50D)))), Call(p_874, V.Undef, ((V)(76D)), ((V)(0D)), ((V)(50D))), Call(p_874, V.Undef, ((V)((-76D))), ((V)(0D)), ((V)(50D))), Call(p_874, V.Undef, ((V)(76D)), ((V)(0D)), ((V)((-50D)))), Call(p_874, V.Undef, ((V)(0D)), ((V)(46D)), ((V)((-21D)))), Call(p_874, V.Undef, ((V)((-48D))), ((V)(40D)), ((V)((-26D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_810;
return default;
}, 1, "", true));
Set(N_54, "cedarBed8", Fn((V _arrowThis934, int _argc927, V S_933, V _a930, V _a931, V _a932, V[] _rest928) => {
V si_935 = default;
V CED_936 = default;
V CED2_937 = default;
double W_938 = 0;
double DZ_939 = 0;
double H_940 = 0;
V D_941 = default;
si_935 = Call(stageOf_70, V.Undef, S_933);
CED_936 = ((V)("#b9733e"));
CED2_937 = ((V)("#cf8f55"));
W_938 = 50D;
DZ_939 = 24D;
H_940 = 16D;
D_941 = NewObj(2).Put("w", ((V)(120D))).Put("d", ((V)(70D))).V;
Set(D_941, "build", Fn((V _arrowThis949, int _argc942, V P_948, V _a945, V _a946, V _a947, V[] _rest943) => {
V o_950 = default;
o_950 = Arr();
Invoke(Arr(Arr(((V)(0D)), ((V)(DZ_939))), Arr(((V)(0D)), ((V)((-DZ_939))))), "forEach", Fn((V _arrowThis962, int _argc951, V _a953, V _a954, V _a955, V _a956, V[] _rest952) => {
V x_959 = default;
V z_961 = default;
{ V _t957 = ListOf(_a953);
{ V _t958 = GetIdx(_t957, 0D);
x_959 = _t958; }
{ V _t960 = GetIdx(_t957, 1D);
z_961 = _t960; }
}
return Invoke(Arr(((V)(0D)), ((V)(8D))), "forEach", Fn((V _arrowThis970, int _argc963, V y_969, V _a966, V _a967, V _a968, V[] _rest964) => {
return Invoke(o_950, "push", Call(box_12, V.Undef, x_959, y_969, z_961, ((V)((2D * W_938))), ((V)(7.6)), ((V)(3D)), (Truthy(y_969) ? CED2_937 : CED_936), Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(Arr(((V)((-W_938))), ((V)(W_938))), "forEach", Fn((V _arrowThis978, int _argc971, V x_977, V _a974, V _a975, V _a976, V[] _rest972) => {
return Invoke(Arr(((V)(0D)), ((V)(8D))), "forEach", Fn((V _arrowThis986, int _argc979, V y_985, V _a982, V _a983, V _a984, V[] _rest980) => {
return Invoke(o_950, "push", Call(box_12, V.Undef, x_977, y_985, ((V)(0D)), ((V)(3D)), ((V)(7.6)), ((V)(((2D * DZ_939) - 3D))), (Truthy(y_985) ? CED2_937 : CED_936), Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
}, 1, "", true));
}, 1, "", true));
Invoke(Arr(Arr(((V)((-W_938))), ((V)((-DZ_939)))), Arr(((V)(W_938)), ((V)((-DZ_939)))), Arr(((V)((-W_938))), ((V)(DZ_939))), Arr(((V)(W_938)), ((V)(DZ_939)))), "forEach", Fn((V _arrowThis998, int _argc987, V _a989, V _a990, V _a991, V _a992, V[] _rest988) => {
V x_995 = default;
V z_997 = default;
{ V _t993 = ListOf(_a989);
{ V _t994 = GetIdx(_t993, 0D);
x_995 = _t994; }
{ V _t996 = GetIdx(_t993, 1D);
z_997 = _t996; }
}
return Invoke(o_950, "push", Call(box_12, V.Undef, x_995, ((V)(0D)), z_997, ((V)(4.4)), ((V)((H_940 + 2D))), ((V)(4.4)), ((V)("#a8683a")), Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_12, V.Undef, x_995, ((V)((H_940 + 2D))), z_997, ((V)(5.4)), ((V)(1.2)), ((V)(5.4)), CED2_937, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
Invoke(o_950, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(((2D * W_938) - 3D))), ((V)((H_940 - 2.4))), ((V)(((2D * DZ_939) - 3D))), ((V)("#3a2a1e")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
return o_950;
return default;
}, 1, "", true));
Set(D_941, "fx", Fn((V _arrowThis1006, int _argc999, V c_1005, V _a1002, V _a1003, V _a1004, V[] _rest1000) => {
V p_1007 = default;
V k_1008 = default;
JsStrBuf f_1009 = null;
V rows_1010 = default;
V cols_1011 = default;
V grow_1012 = default;
V plant_1013 = default;
p_1007 = Get(c_1005, "p");
k_1008 = Get(c_1005, "k");
f_1009 = new JsStrBuf("");
f_1009.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_1007, ((V)((H_940 - 2.3))))), "\">", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(3D)), Fn((V _arrowThis1021, int _argc1014, V i_1020, V _a1017, V _a1018, V _a1019, V[] _rest1015) => {
return ((V)(string.Concat("<path d=\"M", NumStr(((-W_938) + 4D)), " ", NumStr(((-14D) + (ToNum(i_1020) * 14D))), "H", NumStr((W_938 - 4D)), "\" stroke=\"#2a1c12\" stroke-width=\"2.4\" opacity=\"0.6\"/><path d=\"M", NumStr(((-W_938) + 4D)), " ", NumStr(((-15D) + (ToNum(i_1020) * 14D))), "H", NumStr((W_938 - 4D)), "\" stroke=\"#5a4230\" stroke-width=\"0.8\" opacity=\"0.7\"/>")));
}, 1, "", true)), "join", ((V)("")))), ToStr(Invoke(Call(rep_19, V.Undef, ((V)(40D)), Fn((V _arrowThis1029, int _argc1022, V i_1028, V _a1025, V _a1026, V _a1027, V[] _rest1023) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, ((V)((((-W_938) + 4D) + ((ToNum(i_1028) * 23D) % ((2D * W_938) - 8D))))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)((((-DZ_939) + 4D) + ((ToNum(i_1028) * 17D) % ((2D * DZ_939) - 8D))))))), "\" r=\"0.6\" fill=\"#6a5240\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g>"));
Invoke(Arr(Arr(((V)((DZ_939 + 1.55))), ((V)(1D)))), "forEach", Fn((V _arrowThis1036, int _argc1030, V _a1032, V _a1033, V _a1034, V _a1035, V[] _rest1031) => {
return Invoke(Arr(((V)(3.8)), ((V)(11.8))), "forEach", Fn((V _arrowThis1044, int _argc1037, V y_1043, V _a1040, V _a1041, V _a1042, V[] _rest1038) => {
return ((V)(f_1009.S(string.Concat("<g transform=\"", ToStr(Call(plane_24, V.Undef, p_1007, ((V)((DZ_939 + 1.55))), y_1043, ((V)((-W_938))))), "\"><path d=\"M2 0H", NumStr(((2D * W_938) - 2D)), "M8 1.6H", NumStr(((2D * W_938) - 12D)), "\" stroke=\"#7a4522\" stroke-width=\"0.3\" opacity=\"0.6\"/></g>")).Str));
}, 1, "", true));
}, 0, "", true));
rows_1010 = Arr(((V)((-14D))), ((V)(0D)), ((V)(14D)));
cols_1011 = Call(rep_19, V.Undef, ((V)(6D)), Fn((V _arrowThis1052, int _argc1045, V i_1051, V _a1048, V _a1049, V _a1050, V[] _rest1046) => {
return ((V)(((-40D) + (ToNum(i_1051) * 16D))));
}, 1, "", true));
grow_1012 = Fn((V _arrowThis1060, int _argc1053, V d_1059, V _a1056, V _a1057, V _a1058, V[] _rest1054) => {
return ((V)((SEqN(si_935, 4D) ? "" : string.Concat("<animateTransform attributeName=\"transform\" type=\"scale\" values=\"0.6;1.08;1\" keyTimes=\"0;0.6;1\" dur=\"0.7s\"", ToStr(Call(B_58, V.Undef, d_1059)), " fill=\"freeze\" additive=\"sum\"/>"))));
}, 1, "", true);
plant_1013 = Fn((V _arrowThis1071, int _argc1061, V x_1067, V z_1068, V row_1069, V i_1070, V[] _rest1062) => {
V q_1072 = default;
double d_1073 = 0;
JsStrBuf g_1074 = null;
if (SEqN(si_935, 4D)) {
return ((V)(""));
}
q_1072 = Call(p_1007, V.Undef, x_1067, ((V)((H_940 - 2.3))), z_1068);
d_1073 = ((ToNum(i_1070) % 6D) * 0.06);
g_1074 = new JsStrBuf("");
if (SEqN(si_935, 0D)) {
g_1074.Set((((ToNum(i_1070) % 6D) == 0D) ? string.Concat("<path d=\"M0 0V-6\" stroke=\"#c9a070\" stroke-width=\"0.5\"/><rect x=\"-2.4\" y=\"-9.6\" width=\"4.8\" height=\"3.6\" rx=\"0.4\" fill=\"#fffaf0\" stroke=\"#9a8a6a\" stroke-width=\"0.2\"/><circle cy=\"-7.8\" r=\"1\" fill=\"", ToStr(GetK(Arr(((V)("#e8343c")), ((V)("#7ab854")), ((V)("#ff8a2a"))), row_1069)), "\"/>") : string.Concat("<ellipse rx=\"1.4\" ry=\"0.6\" fill=\"#2a1c12\"/><circle cx=\"-0.5\" cy=\"-0.3\" r=\"0.35\" fill=\"#d8c08a\"/><circle cx=\"0.6\" cy=\"-0.1\" r=\"0.35\" fill=\"#d8c08a\"/>", "")));
} else {
if (SEqN(si_935, 1D)) {
g_1074.Set(string.Concat("<path d=\"M0 0V-3.2\" stroke=\"#6fae44\" stroke-width=\"0.5\"/><path d=\"M0 -3Q-2.6 -4.8 -3 -2.6Q-1.4 -2 0 -3ZM0 -3Q2.6 -4.8 3 -2.6Q1.4 -2 0 -3Z\" fill=\"#8fd060\"/>", ""));
} else {
if (SEqN(row_1069, 0D)) {
V t_1075 = default;
t_1075 = (GeN(si_935, 3D) ? V.True : V.False);
g_1074.Set(string.Concat("<path d=\"M0 0V-24\" stroke=\"#c9a070\" stroke-width=\"0.7\"/>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)((SEqN(si_935, 2D) ? 4D : 6D))), Fn((V _arrowThis1083, int _argc1076, V j_1082, V _a1079, V _a1080, V _a1081, V[] _rest1077) => {
return ((V)(string.Concat("<path d=\"M0 ", NumStr(((-4D) - (ToNum(j_1082) * 3.4))), "q", NumStr((NumTruthy((ToNum(j_1082) % 2D)) ? 4D : (-4D))), " -2 ", NumStr((NumTruthy((ToNum(j_1082) % 2D)) ? 6D : (-6D))), " 0q", NumStr((NumTruthy((ToNum(j_1082) % 2D)) ? (-3D) : 3D)), " 1.6 ", NumStr((NumTruthy((ToNum(j_1082) % 2D)) ? (-6D) : 6D)), " 0Z\" fill=\"", (NumTruthy((ToNum(j_1082) % 2D)) ? "#3f8a34" : "#5aa844"), "\"/>")));
}, 1, "", true)), "join", ((V)("")))), ToStr((Truthy(t_1075) ? Invoke(Invoke(Arr(Arr(((V)((-3D))), ((V)((-10D)))), Arr(((V)(3D)), ((V)((-14D)))), Arr(((V)((-2.6))), ((V)((-18D)))), Arr(((V)(2.4)), ((V)((-7D))))), "map", Fn((V _arrowThis1095, int _argc1084, V _a1086, V _a1087, V _a1088, V _a1089, V[] _rest1085) => {
V u_1092 = default;
V v_1094 = default;
{ V _t1090 = ListOf(_a1086);
{ V _t1091 = GetIdx(_t1090, 0D);
u_1092 = _t1091; }
{ V _t1093 = GetIdx(_t1090, 1D);
v_1094 = _t1093; }
}
return ((V)(string.Concat("<circle cx=\"", ToStr(u_1092), "\" cy=\"", ToStr(v_1094), "\" r=\"2.1\" fill=\"#e8343c\"/><ellipse cx=\"", NumStr((ToNum(u_1092) - 0.6)), "\" cy=\"", NumStr((ToNum(v_1094) - 0.7)), "\" rx=\"0.7\" ry=\"0.45\" fill=\"#ffffff\" opacity=\"0.6\"/><path d=\"M", NumStr((ToNum(u_1092) - 0.8)), " ", NumStr((ToNum(v_1094) - 2D)), "l0.8 0.6l0.8 -0.6\" stroke=\"#3f8a34\" stroke-width=\"0.4\" fill=\"none\"/>")));
}, 1, "", true)), "join", ((V)(""))) : ((V)(""))))));
} else {
if (SEqN(row_1069, 1D)) {
double r_1096 = 0;
r_1096 = (SEqN(si_935, 2D) ? 3.4 : 4.6);
g_1074.Set(JsStrBuf.Begin().V(Invoke(Call(rep_19, V.Undef, ((V)(7D)), Fn((V _arrowThis1104, int _argc1097, V j_1103, V _a1100, V _a1101, V _a1102, V[] _rest1098) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_18, V.Undef, ((V)(((FdLibm.Cos((ToNum(j_1103) * 0.9)) * r_1096) * 0.5))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)((((-r_1096) * 0.6) + ((FdLibm.Sin((ToNum(j_1103) * 0.9)) * r_1096) * 0.25)))))), "\" rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((r_1096 * 0.62))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((r_1096 * 0.42))))), "\" fill=\"", ToStr(GetIdx(Arr(((V)("#9ad86a")), ((V)("#7ac050")), ((V)("#b4e88a"))), (ToNum(j_1103) % 3D))), "\" stroke=\"#5a9a3a\" stroke-width=\"0.2\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<ellipse cy=\"", ToStr(Call(f1_18, V.Undef, ((V)(((-r_1096) * 0.7))))), "\" rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((r_1096 * 0.35))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((r_1096 * 0.3))))), "\" fill=\"#d8f2b0\"/>")).End());
} else {
g_1074.Set(string.Concat((GeN(si_935, 3D) ? "<path d=\"M-1.4 0L0 4L1.4 0Z\" fill=\"#ff8a2a\" transform=\"translate(0 -1)\"/>" : ""), ToStr(Invoke(Call(rep_19, V.Undef, ((V)(5D)), Fn((V _arrowThis1112, int _argc1105, V j_1111, V _a1108, V _a1109, V _a1110, V[] _rest1106) => {
return ((V)(string.Concat("<path d=\"M0 0Q", NumStr(((ToNum(j_1111) - 2D) * 1.6)), " -4 ", NumStr(((ToNum(j_1111) - 2D) * 2.4)), " ", NumStr((-(SEqN(si_935, 2D) ? 6D : 9D))), "\" stroke=\"#5aa844\" stroke-width=\"0.8\" fill=\"none\"/>")));
}, 1, "", true)), "join", ((V)(""))))));
}
}
}
}
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_1072)), ") scale(", ToStr(Call(n4_21, V.Undef, k_1008)), ")\"><g>", ToStr(Call(grow_1012, V.Undef, ((V)(d_1073)))), g_1074.Str, "</g></g>")));
return default;
}, 4, "", true);
Invoke(rows_1010, "forEach", Fn((V _arrowThis1121, int _argc1113, V z_1119, V row_1120, V _a1117, V _a1118, V[] _rest1114) => {
return Invoke(cols_1011, "forEach", Fn((V _arrowThis1130, int _argc1122, V x_1128, V i_1129, V _a1126, V _a1127, V[] _rest1123) => {
if (Truthy(((SEqN(row_1120, 0D) ? V.True : V.False) is var _t1131 && !Truthy(_t1131) ? _t1131 : ((V)((ToNum(i_1129) % 2D)))))) {
return default;
}
f_1009.V(Call(plant_1013, V.Undef, Add(x_1128, ((V)((SEqN(row_1120, 1D) ? 6D : 0D)))), z_1119, row_1120, i_1129));
return default;
}, 2, "", true));
}, 2, "", true));
if (SEqN(si_935, 4D)) {
V q_1132 = default;
q_1132 = Call(p_1007, V.Undef, ((V)((W_938 + 18D))), ((V)(0D)), ((V)(10D)));
f_1009.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_1132)), ") scale(", ToStr(Call(n4_21, V.Undef, k_1008)), ")\"><ellipse cy=\"0.6\" rx=\"11\" ry=\"3\" fill=\"#000000\" opacity=\"0.15\"/><path d=\"M-9 -8H9L7 0H-7Z\" fill=\"#c9965a\" stroke=\"#7a5430\" stroke-width=\"0.4\"/>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(4D)), Fn((V _arrowThis1140, int _argc1133, V j_1139, V _a1136, V _a1137, V _a1138, V[] _rest1134) => {
return ((V)(string.Concat("<path d=\"M-8.4 ", NumStr(((-6.4) + (ToNum(j_1139) * 1.8))), "H8.4\" stroke=\"#9a6a3a\" stroke-width=\"0.4\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<path d=\"M-8 -8Q0 -22 8 -8\" stroke=\"#9a6a3a\" stroke-width=\"1.2\" fill=\"none\"/>")).V(Invoke(Invoke(Arr(Arr(((V)((-5D))), ((V)((-10D))), ((V)("#e8343c")), ((V)(2.4))), Arr(((V)((-1D))), ((V)((-11D))), ((V)("#e8343c")), ((V)(2.4))), Arr(((V)(3D)), ((V)((-10D))), ((V)("#9ad86a")), ((V)(3.2))), Arr(((V)(6.4)), ((V)((-9.4))), ((V)("#ff8a2a")), ((V)(1.8))), Arr(((V)((-6.6))), ((V)((-9D))), ((V)("#ff8a2a")), ((V)(1.8)))), "map", Fn((V _arrowThis1157, int _argc1141, V _a1143, V j_1147, V _a1145, V _a1146, V[] _rest1142) => {
V u_1150 = default;
V v_1152 = default;
V col_1154 = default;
V r_1156 = default;
{ V _t1148 = ListOf(_a1143);
{ V _t1149 = GetIdx(_t1148, 0D);
u_1150 = _t1149; }
{ V _t1151 = GetIdx(_t1148, 1D);
v_1152 = _t1151; }
{ V _t1153 = GetIdx(_t1148, 2D);
col_1154 = _t1153; }
{ V _t1155 = GetIdx(_t1148, 3D);
r_1156 = _t1155; }
}
return ((V)(string.Concat("<g opacity=\"0\">", ToStr(Call(once_35, V.Undef, ((V)("opacity")), ((V)("0;1")), ((V)("0;1")), ((V)(0.2)), ((V)((0.2 + (ToNum(j_1147) * 0.18)))))), "<circle cx=\"", ToStr(u_1150), "\" cy=\"", ToStr(v_1152), "\" r=\"", ToStr(r_1156), "\" fill=\"", ToStr(col_1154), "\">", ToStr(Call(once_35, V.Undef, ((V)("cy")), ((V)(string.Concat(NumStr((ToNum(v_1152) - 30D)), ";", NumStr((ToNum(v_1152) - 6D)), ";", ToStr(v_1152)))), ((V)("0;0.7;1")), ((V)(0.5)), ((V)((0.2 + (ToNum(j_1147) * 0.18)))))), "</circle></g>")));
}, 2, "", true)), "join", ((V)("")))).S("</g>");
}
return NewObj(3).Put("defs", ((V)(""))).Put("front", ((V)(f_1009.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1007, V.Undef, ((V)(((-W_938) - 4D))), ((V)(0D)), ((V)(((-DZ_939) - 4D)))), Call(p_1007, V.Undef, ((V)((W_938 + 4D))), ((V)(0D)), ((V)((DZ_939 + 4D)))), Call(p_1007, V.Undef, ((V)(((-W_938) - 4D))), ((V)(0D)), ((V)((DZ_939 + 4D)))), Call(p_1007, V.Undef, ((V)((W_938 + 4D))), ((V)(0D)), ((V)(((-DZ_939) - 4D)))), Call(p_1007, V.Undef, ((V)((-40D))), ((V)((H_940 + 30D))), ((V)((-14D)))), Call(p_1007, V.Undef, ((V)((W_938 + 32D))), ((V)(0D)), ((V)(10D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_941;
return default;
}, 1, "", true));
Set(N_54, "tower8", Fn((V _arrowThis1165, int _argc1158, V S_1164, V _a1161, V _a1162, V _a1163, V[] _rest1159) => {
V si_1166 = default;
V TC_1167 = default;
V TC2_1168 = default;
V T_1169 = default;
V POCK_1170 = default;
V D_1171 = default;
V tier_1172 = default;
V soil_1173 = default;
si_1166 = Call(stageOf_70, V.Undef, S_1164);
TC_1167 = ((V)("#c4683a"));
TC2_1168 = ((V)("#b05a30"));
T_1169 = Arr(Arr(((V)(0D)), ((V)(26D)), ((V)(22D))), Arr(((V)(22D)), ((V)(19D)), ((V)(18D))), Arr(((V)(40D)), ((V)(13D)), ((V)(15D))));
POCK_1170 = Arr();
Invoke(T_1169, "forEach", Fn((V _arrowThis1188, int _argc1174, V _a1176, V ti_1180, V _a1178, V _a1179, V[] _rest1175) => {
double n_1189 = 0;
V y_1183 = default;
V r_1185 = default;
V h_1187 = default;
{ V _t1181 = ListOf(_a1176);
{ V _t1182 = GetIdx(_t1181, 0D);
y_1183 = _t1182; }
{ V _t1184 = GetIdx(_t1181, 1D);
r_1185 = _t1184; }
{ V _t1186 = GetIdx(_t1181, 2D);
h_1187 = _t1186; }
}
n_1189 = (SEqN(ti_1180, 2D) ? 0D : 6D);
Call(rep_19, V.Undef, ((V)(n_1189)), Fn((V _arrowThis1197, int _argc1190, V i_1196, V _a1193, V _a1194, V _a1195, V[] _rest1191) => {
double th_1198 = 0;
th_1198 = ((((ToNum(i_1196) / n_1189) * 2D) * PI_55) + (ToNum(ti_1180) * 0.5));
Invoke(POCK_1170, "push", Arr(((V)(th_1198)), Add(r_1185, ((V)(1.6))), Add(y_1183, ((V)((ToNum(h_1187) * 0.6)))), ti_1180));
return default;
}, 1, "", true));
return default;
}, 2, "", true));
D_1171 = NewObj(3).Put("w", ((V)(64D))).Put("d", ((V)(64D))).Put("round", ((V)(1D))).V;
tier_1172 = Fn((V _arrowThis1206, int _argc1199, V ti_1205, V _a1202, V _a1203, V _a1204, V[] _rest1200) => {
V o_1207 = default;
V y_1208 = default;
V r_1209 = default;
V h_1210 = default;
o_1207 = Arr();
{ V _t1211 = GetK(T_1169, ti_1205);
{ V _t1212 = ListOf(_t1211);
{ V _t1213 = GetIdx(_t1212, 0D);
y_1208 = _t1213; }
{ V _t1214 = GetIdx(_t1212, 1D);
r_1209 = _t1214; }
{ V _t1215 = GetIdx(_t1212, 2D);
h_1210 = _t1215; }
} }
Invoke(o_1207, "push", Call(cyl_13, V.Undef, ((V)(0D)), y_1208, ((V)(0D)), r_1209, h_1210, TC_1167, Call(pt_32, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.86))), Arr(((V)((ToNum(h_1210) - 3D))), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(h_1210) - 2.6))), ((V)(0D)), ((V)(1.08))), Arr(h_1210, ((V)(0D)), ((V)(1.08))))).V)));
Invoke(Invoke(POCK_1170, "filter", Fn((V _arrowThis1237, int _argc1230, V q_1236, V _a1233, V _a1234, V _a1235, V[] _rest1231) => {
return (SEq(GetIdx(q_1236, 3D), ti_1205) ? V.True : V.False);
}, 1, "", true)), "forEach", Fn((V _arrowThis1229, int _argc1216, V _a1218, V _a1219, V _a1220, V _a1221, V[] _rest1217) => {
V th_1224 = default;
V r_1226 = default;
V y_1228 = default;
{ V _t1222 = ListOf(_a1218);
{ V _t1223 = GetIdx(_t1222, 0D);
th_1224 = _t1223; }
{ V _t1225 = GetIdx(_t1222, 1D);
r_1226 = _t1225; }
{ V _t1227 = GetIdx(_t1222, 2D);
y_1228 = _t1227; }
}
return Invoke(o_1207, "push", Call(ball_14, V.Undef, ((V)((ToNum(r_1226) * FdLibm.Sin(ToNum(th_1224))))), ((V)((ToNum(y_1228) - 2D))), ((V)((ToNum(r_1226) * FdLibm.Cos(ToNum(th_1224))))), ((V)(4.2)), TC2_1168, Call(pt_32, V.Undef, NewObj(3).Put("sy", ((V)(0.8))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V)), Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("y"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((ToNum(Add(r_1226, ((V)(1D)))) * FdLibm.Sin(ToNum(th_1224))))), ((V)((ToNum(Add(r_1226, ((V)(1D)))) * FdLibm.Cos(ToNum(th_1224))))))).Put("a", ((V)(3.6))).Put("b", ((V)(2.6))).Put("yaw", ((V)((-ToNum(th_1224))))).Put("n", ((V)(12D))).Put("rings", Arr(Arr(Add(y_1228, ((V)(1.2))), ((V)(0D))), Arr(Add(y_1228, ((V)(2D))), ((V)(0D))))).Put("col", TC_1167).Put("mat", ((V)("paint"))).V));
}, 1, "", true));
return o_1207;
return default;
}, 1, "", true);
soil_1173 = Fn((V _arrowThis1246, int _argc1238, V p_1244, V ti_1245, V _a1242, V _a1243, V[] _rest1239) => {
V y_1247 = default;
V r_1248 = default;
V h_1249 = default;
{ V _t1250 = GetK(T_1169, ti_1245);
{ V _t1251 = ListOf(_t1250);
{ V _t1252 = GetIdx(_t1251, 0D);
y_1247 = _t1252; }
{ V _t1253 = GetIdx(_t1251, 1D);
r_1248 = _t1253; }
{ V _t1254 = GetIdx(_t1251, 2D);
h_1249 = _t1254; }
} }
return ((V)(string.Concat("<path d=\"", ToStr(Call(sp_41, V.Undef, p_1244, Call(ellPts_39, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((ToNum(r_1248) * 1.02))), ((V)((ToNum(r_1248) * 1.02))), ((V)(40D))), Add(y_1247, h_1249))), "\" fill=\"#3a2a1e\"/><path d=\"", ToStr(Call(sp_41, V.Undef, p_1244, Call(ellPts_39, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((ToNum(r_1248) * 0.7))), ((V)((ToNum(r_1248) * 0.7))), ((V)(30D))), Add(y_1247, h_1249))), "\" fill=\"#2a1c12\" opacity=\"0.5\"/>")));
return default;
}, 2, "", true);
Set(D_1171, "build", Fn((V _arrowThis1262, int _argc1255, V P_1261, V _a1258, V _a1259, V _a1260, V[] _rest1256) => {
return Call(tier_1172, V.Undef, ((V)(0D)));
}, 1, "", true));
Set(D_1171, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1270, int _argc1263, V P_1269, V _a1266, V _a1267, V _a1268, V[] _rest1264) => {
return Call(tier_1172, V.Undef, ((V)(1D)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1279, int _argc1271, V p_1277, V s_1278, V _a1275, V _a1276, V[] _rest1272) => {
return Add(Call(soil_1173, V.Undef, p_1277, ((V)(0D))), s_1278);
}, 2, "wrap", true)).V, NewObj(2).Put("build", Fn((V _arrowThis1287, int _argc1280, V P_1286, V _a1283, V _a1284, V _a1285, V[] _rest1281) => {
return Call(tier_1172, V.Undef, ((V)(2D)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1296, int _argc1288, V p_1294, V s_1295, V _a1292, V _a1293, V[] _rest1289) => {
return Add(Call(soil_1173, V.Undef, p_1294, ((V)(1D))), s_1295);
}, 2, "wrap", true)).V));
Set(D_1171, "fx", Fn((V _arrowThis1304, int _argc1297, V c_1303, V _a1300, V _a1301, V _a1302, V[] _rest1298) => {
V p_1305 = default;
V k_1306 = default;
V f_1307 = default;
V berry_1308 = default;
V tq_1309 = default;
p_1305 = Get(c_1303, "p");
k_1306 = Get(c_1303, "k");
f_1307 = Call(soil_1173, V.Undef, p_1305, ((V)(2D)));
berry_1308 = Fn((V _arrowThis1319, int _argc1310, V q_1316, V ripe_1317, V s_1318, V _a1315, V[] _rest1311) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_1316)), ") scale(", ToStr(Call(n4_21, V.Undef, ((V)((ToNum(k_1306) * ToNum(s_1318)))))), ")\"><path d=\"M0 0Q-2.4 -0.2 -2 2.4Q-1 4.8 0 5.2Q1 4.8 2 2.4Q2.4 -0.2 0 0Z\" fill=\"", (Truthy(ripe_1317) ? "#e8243c" : (SEqN(si_1166, 2D) ? "#c8e08a" : "#f0f0d0")), "\"/>", ToStr((Truthy(ripe_1317) ? Invoke(Call(rep_19, V.Undef, ((V)(6D)), Fn((V _arrowThis1327, int _argc1320, V j_1326, V _a1323, V _a1324, V _a1325, V[] _rest1321) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, ((V)((((ToNum(j_1326) % 3D) - 1D) * 1D))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.6 + (System.Math.Floor((ToNum(j_1326) / 3D)) * 1.6)))))), "\" r=\"0.22\" fill=\"#ffe06a\"/>")));
}, 1, "", true)), "join", ((V)(""))) : ((V)("")))), "<path d=\"M-1.4 0L0 -1L1.4 0L0 0.6Z\" fill=\"#3f8a34\"/></g>")));
}, 3, "", true);
Invoke(Invoke(Invoke(POCK_1170, "slice"), "sort", Fn((V _arrowThis1384, int _argc1376, V a_1382, V b_1383, V _a1380, V _a1381, V[] _rest1377) => {
return ((V)((ToNum(Call(facing_44, V.Undef, GetIdx(a_1382, 0D))) - ToNum(Call(facing_44, V.Undef, GetIdx(b_1383, 0D))))));
}, 2, "", true)), "forEach", Fn((V _arrowThis1344, int _argc1328, V _a1330, V i_1334, V _a1332, V _a1333, V[] _rest1329) => {
V fc_1345 = default;
V q_1346 = default;
V th_1337 = default;
V r_1339 = default;
V y_1341 = default;
V ti_1343 = default;
{ V _t1335 = ListOf(_a1330);
{ V _t1336 = GetIdx(_t1335, 0D);
th_1337 = _t1336; }
{ V _t1338 = GetIdx(_t1335, 1D);
r_1339 = _t1338; }
{ V _t1340 = GetIdx(_t1335, 2D);
y_1341 = _t1340; }
{ V _t1342 = GetIdx(_t1335, 3D);
ti_1343 = _t1342; }
}
fc_1345 = Call(facing_44, V.Undef, th_1337);
if (LtN(fc_1345, (-0.25))) {
return default;
}
q_1346 = Call(p_1305, V.Undef, ((V)((ToNum(Add(r_1339, ((V)(1D)))) * FdLibm.Sin(ToNum(th_1337))))), Add(y_1341, ((V)(1.8))), ((V)((ToNum(Add(r_1339, ((V)(1D)))) * FdLibm.Cos(ToNum(th_1337))))));
f_1307 = ((V)(JsStrBuf.Begin().V(f_1307).S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_1346)), ") scale(", ToStr(Call(n4_21, V.Undef, k_1306)), ")\"><ellipse rx=\"3.2\" ry=\"1.3\" fill=\"#2a1c12\"/>", (SEqN(si_1166, 0D) ? "<path d=\"M0 0V-2.4\" stroke=\"#6fae44\" stroke-width=\"0.5\"/><path d=\"M0 -2.2q-1.6-1.4-2.2 0q1 0.6 2.2 0ZM0 -2.2q1.6-1.4 2.2 0q-1 0.6-2.2 0Z\" fill=\"#8fd060\"/>" : string.Concat("<g>", ToStr(Call(atV_34, V.Undef, ((V)("rotate")), Arr(((V)("-4")), ((V)("4")), ((V)("-4"))), ((V)(3.6)), ((V)(((-ToNum(i_1334)) * 0.3))))), ToStr(Invoke(Call(rep_19, V.Undef, ((V)(3D)), Fn((V _arrowThis1354, int _argc1347, V j_1353, V _a1350, V _a1351, V _a1352, V[] _rest1348) => {
return ((V)(string.Concat("<g transform=\"rotate(", NumStr(((-40D) + (ToNum(j_1353) * 40D))), ")\"><path d=\"M0 0V-4\" stroke=\"#4f8a34\" stroke-width=\"0.4\"/>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(3D)), Fn((V _arrowThis1362, int _argc1355, V m_1361, V _a1358, V _a1359, V _a1360, V[] _rest1356) => {
return ((V)(string.Concat("<path d=\"M0 -4Q", NumStr(((-2.2) + (ToNum(m_1361) * 2.2))), " -7.4 ", NumStr(((-1.4) + (ToNum(m_1361) * 1.4))), " -4.2Z\" fill=\"", (SEqN(m_1361, 1D) ? "#3f8a34" : "#5aa844"), "\" stroke=\"#2f6a26\" stroke-width=\"0.15\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g>")));
}, 1, "", true)), "join", ((V)("")))), "</g>", ToStr((SEqN(si_1166, 1D) ? Call(flower5_69, V.Undef, Arr(((V)(1.4)), ((V)((-2.2)))), ((V)(1D)), ((V)(0.9)), ((V)("#ffffff"))) : ((V)("")))))), "</g>")).End()));
if ((GeN(si_1166, 2D) && LtN(si_1166, 4D))) {
Invoke(Arr(Arr(((V)((-1.6))), ((V)(0.2))), Arr(((V)(1.5)), ((V)(0.6)))), "forEach", Fn((V _arrowThis1374, int _argc1363, V _a1365, V _a1366, V _a1367, V _a1368, V[] _rest1364) => {
V b0_1375 = default;
V du_1371 = default;
V dy_1373 = default;
{ V _t1369 = ListOf(_a1365);
{ V _t1370 = GetIdx(_t1369, 0D);
du_1371 = _t1370; }
{ V _t1372 = GetIdx(_t1369, 1D);
dy_1373 = _t1372; }
}
b0_1375 = Call(p_1305, V.Undef, ((V)(((ToNum(Add(r_1339, ((V)(1.8)))) * FdLibm.Sin(ToNum(th_1337))) + (ToNum(du_1371) * FdLibm.Cos(ToNum(th_1337)))))), ((V)((ToNum(Add(y_1341, ((V)(2D)))) - ToNum(dy_1373)))), ((V)(((ToNum(Add(r_1339, ((V)(1.8)))) * FdLibm.Cos(ToNum(th_1337))) - (ToNum(du_1371) * FdLibm.Sin(ToNum(th_1337)))))));
f_1307 = Add(f_1307, Call(berry_1308, V.Undef, b0_1375, (SEqN(si_1166, 3D) ? V.True : V.False), ((V)(0.75))));
return default;
}, 1, "", true));
}
return default;
}, 2, "", true));
tq_1309 = Call(p_1305, V.Undef, ((V)(0D)), Add(GetIdx(GetIdx(T_1169, 2D), 0D), GetIdx(GetIdx(T_1169, 2D), 2D)), ((V)(0D)));
f_1307 = ((V)(JsStrBuf.Begin().V(f_1307).S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, tq_1309)), ") scale(", ToStr(Call(n4_21, V.Undef, k_1306)), ")\"><g>", ToStr(Call(atV_34, V.Undef, ((V)("rotate")), Arr(((V)("-3")), ((V)("3")), ((V)("-3"))), ((V)(4D)))), ToStr(Invoke(Call(rep_19, V.Undef, ((V)((SEqN(si_1166, 0D) ? 3D : 9D))), Fn((V _arrowThis1392, int _argc1385, V j_1391, V _a1388, V _a1389, V _a1390, V[] _rest1386) => {
double a_1393 = 0;
double l_1394 = 0;
a_1393 = ((ToNum(j_1391) * 0.7) - 2.8);
l_1394 = (SEqN(si_1166, 0D) ? 3D : (LtN(si_1166, 3D) ? 8D : 11D));
return ((V)(string.Concat("<path d=\"M0 0Q", ToStr(Call(f1_18, V.Undef, ((V)((a_1393 * 2D))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((-l_1394) * 0.5))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((a_1393 * 3D))))), " ", NumStr((-l_1394)), "\" stroke=\"", (NumTruthy((ToNum(j_1391) % 3D)) ? "#4f7a3a" : "#5a8a6a"), "\" stroke-width=\"0.6\" fill=\"none\"/>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(3D)), Fn((V _arrowThis1402, int _argc1395, V m_1401, V _a1398, V _a1399, V _a1400, V[] _rest1396) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_18, V.Undef, ((V)(((a_1393 * 3D) * (0.4 + (ToNum(m_1401) * 0.3))))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)(((-l_1394) * (0.4 + (ToNum(m_1401) * 0.3))))))), "\" rx=\"", NumStr((NumTruthy((ToNum(j_1391) % 3D)) ? 1.4 : 0.5)), "\" ry=\"", NumStr((NumTruthy((ToNum(j_1391) % 3D)) ? 0.8 : 1.6)), "\" fill=\"", (NumTruthy((ToNum(j_1391) % 3D)) ? "#5aa844" : "#6a8a6a"), "\"/>")));
}, 1, "", true)), "join", ((V)("")))))));
return default;
}, 1, "", true)), "join", ((V)("")))), "</g></g>")).End()));
if (SEqN(si_1166, 4D)) {
V q_1403 = default;
q_1403 = Call(p_1305, V.Undef, ((V)(30D)), ((V)(0D)), ((V)(14D)));
f_1307 = ((V)(JsStrBuf.Begin().V(f_1307).S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_1403)), ") scale(", ToStr(Call(n4_21, V.Undef, k_1306)), ")\"><ellipse cy=\"0.4\" rx=\"8\" ry=\"2\" fill=\"#000000\" opacity=\"0.15\"/><path d=\"M-7 -4.6H7Q6.4 0 0 0.4Q-6.4 0 -7 -4.6Z\" fill=\"#2f6fb0\" stroke=\"#1a3f6a\" stroke-width=\"0.3\"/><ellipse cy=\"-4.6\" rx=\"7\" ry=\"1.6\" fill=\"#f4efe6\"/>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(7D)), Fn((V _arrowThis1411, int _argc1404, V j_1410, V _a1407, V _a1408, V _a1409, V[] _rest1405) => {
return ((V)(string.Concat("<g opacity=\"0\">", ToStr(Call(once_35, V.Undef, ((V)("opacity")), ((V)("0;1")), ((V)("0;1")), ((V)(0.2)), ((V)((0.2 + (ToNum(j_1410) * 0.15)))))), "<g transform=\"translate(", NumStr(((-4.4) + ((ToNum(j_1410) % 4D) * 2.8))), " ", NumStr(((-5D) - (System.Math.Floor((ToNum(j_1410) / 4D)) * 2D))), ")\"><path d=\"M0 0Q-1.6 0 -1.4 1.8Q-0.6 3.4 0 3.6Q0.6 3.4 1.4 1.8Q1.6 0 0 0Z\" fill=\"#e8243c\"/><path d=\"M-1 0L0 -0.8L1 0Z\" fill=\"#3f8a34\"/></g></g>")));
}, 1, "", true)), "join", ((V)("")))), "</g>")).End()));
}
return NewObj(3).Put("defs", ((V)(""))).Put("front", f_1307).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1305, V.Undef, ((V)((-32D))), ((V)(0D)), ((V)((-32D)))), Call(p_1305, V.Undef, ((V)(32D)), ((V)(0D)), ((V)(32D))), Call(p_1305, V.Undef, ((V)((-32D))), ((V)(0D)), ((V)(32D))), Call(p_1305, V.Undef, ((V)(32D)), ((V)(0D)), ((V)((-32D)))), Call(p_1305, V.Undef, ((V)(0D)), ((V)(66D)), ((V)(0D))), Call(p_1305, V.Undef, ((V)(40D)), ((V)(0D)), ((V)(14D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1171;
return default;
}, 1, "", true));
Set(N_54, "eggSwing", Fn((V _arrowThis1419, int _argc1412, V S_1418, V _a1415, V _a1416, V _a1417, V[] _rest1413) => {
V HK_1420 = default;
double TOPY_1421 = 0;
V RAT_1422 = default;
V D_1423 = default;
HK_1420 = Arr(((V)(0D)), ((V)(104D)), ((V)((-6D))));
TOPY_1421 = 78D;
RAT_1422 = ((V)("#b8864e"));
D_1423 = NewObj(3).Put("w", ((V)(80D))).Put("d", ((V)(70D))).Put("seats", Arr(NewObj(3).Put("x", ((V)(0D))).Put("z", ((V)(6D))).Put("h", ((V)(32D))).V)).V;
Set(D_1423, "build", Fn((V _arrowThis1431, int _argc1424, V P_1430, V _a1427, V _a1428, V _a1429, V[] _rest1425) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-6D))), ((V)(19D)), ((V)(2D)), ((V)("#2a2b30")), Call(mt_29, V.Undef, NewObj(3).Put("n", ((V)(28D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(1.4)), ((V)(0D)), ((V)(0.97))), Arr(((V)(2D)), ((V)(0D)), ((V)(0.88))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(2D)), ((V)((-6D))), ((V)(3.4)), ((V)(1.6)), ((V)("#2a2b30")), Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
}, 1, "", true));
Set(D_1423, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1439, int _argc1432, V P_1438, V _a1435, V _a1436, V _a1437, V[] _rest1433) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(23D)), ((V)(56D)), RAT_1422, Call(fb_59, V.Undef, NewObj(2).Put("n", ((V)(30D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.32))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(14D)), ((V)(0D)), ((V)(0.96))), Arr(((V)(26D)), ((V)(0D)), ((V)(1D))), Arr(((V)(40D)), ((V)(0D)), ((V)(0.92))), Arr(((V)(50D)), ((V)(0D)), ((V)(0.66))), Arr(((V)(56D)), ((V)(0D)), ((V)(0.22))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(TOPY_1421)), ((V)(0D)), ((V)(2.6)), ((V)(2D)), ((V)("#2a2b30")), Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1448, int _argc1440, V p_1446, V s_1447, V _a1444, V _a1445, V[] _rest1441) => {
V k_1449 = default;
V hk_1450 = default;
double TM_1451 = 0;
V mouth_1452 = default;
V inner_1453 = default;
V cush_1454 = default;
V chain_1455 = default;
k_1449 = Call(kOf_60, V.Undef, p_1446);
hk_1450 = CallSpread(p_1446, V.Undef, new ArrBuilder().Spread(HK_1420).V);
TM_1451 = (PI_55 / 6D);
mouth_1452 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Call(rep_19, V.Undef, ((V)(33D)), Fn((V _arrowThis1463, int _argc1456, V i_1462, V _a1459, V _a1460, V _a1461, V[] _rest1457) => {
double a_1464 = 0;
double u_1465 = 0;
double y_1466 = 0;
double R_1467 = 0;
a_1464 = (((ToNum(i_1462) / 32D) * 2D) * PI_55);
u_1465 = (13D * FdLibm.Sin(a_1464));
y_1466 = (48D + (17D * FdLibm.Cos(a_1464)));
R_1467 = 21.4;
return Call(P2_22, V.Undef, Call(p_1446, V.Undef, ((V)((R_1467 * FdLibm.Sin((TM_1451 + (u_1465 / R_1467)))))), ((V)(y_1466)), ((V)((R_1467 * FdLibm.Cos((TM_1451 + (u_1465 / R_1467))))))));
return default;
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
inner_1453 = ((V)(string.Concat("<path d=\"", ToStr(mouth_1452), "\" fill=\"#5a3a1e\"/><path d=\"", ToStr(mouth_1452), "\" fill=\"url(#e8in)\"/>")));
cush_1454 = Call(Fn((V _arrowThis1474, int _argc1468, V _a1470, V _a1471, V _a1472, V _a1473, V[] _rest1469) => {
V q_1475 = default;
V q2_1476 = default;
q_1475 = Call(p_1446, V.Undef, ((V)(9D)), ((V)(34D)), ((V)(15.6)));
q2_1476 = Call(p_1446, V.Undef, ((V)(4D)), ((V)(48D)), ((V)(4D)));
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(q2_1476, 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(q2_1476, 1D))), "\" rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((10D * ToNum(k_1449)))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((12D * ToNum(k_1449)))))), "\" fill=\"#f2ece0\" stroke=\"#c8bca4\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_1449)))))), "\"/><ellipse cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(q_1475, 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(q_1475, 1D))), "\" rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((13D * ToNum(k_1449)))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((5D * ToNum(k_1449)))))), "\" fill=\"#f6f1e6\" stroke=\"#c8bca4\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_1449)))))), "\"/><ellipse cx=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(q_1475, 0D)) - (3D * ToNum(k_1449))))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(q_1475, 1D)) - (1.4 * ToNum(k_1449))))))), "\" rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((5D * ToNum(k_1449)))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.4 * ToNum(k_1449)))))), "\" fill=\"#ffffff\" opacity=\"0.6\"/>")));
return default;
}, 0, "", true), V.Undef);
chain_1455 = Invoke(Call(rep_19, V.Undef, ((V)(9D)), Fn((V _arrowThis1484, int _argc1477, V i_1483, V _a1480, V _a1481, V _a1482, V[] _rest1478) => {
V a_1485 = default;
V q_1486 = default;
a_1485 = Arr(GetIdx(HK_1420, 0D), ((V)((ToNum(GetIdx(HK_1420, 1D)) - ((ToNum(i_1483) * ((ToNum(GetIdx(HK_1420, 1D)) - TOPY_1421) - 2D)) / 8D)))), Add(GetIdx(HK_1420, 2D), ((V)(((ToNum(i_1483) / 8D) * 6D)))));
q_1486 = CallSpread(p_1446, V.Undef, new ArrBuilder().Spread(a_1485).V);
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(q_1486, 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(q_1486, 1D))), "\" rx=\"", ToStr(Call(f1_18, V.Undef, ((V)(((NumTruthy((ToNum(i_1483) % 2D)) ? 0.6 : 1.1) * ToNum(k_1449)))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.5 * ToNum(k_1449)))))), "\" fill=\"none\" stroke=\"#c9d0d6\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.6 * ToNum(k_1449)))))), "\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")));
return ((V)(string.Concat("<g>", ToStr(Call(atV_34, V.Undef, ((V)("rotate")), Arr(((V)(string.Concat("-2.6 ", ToStr(Call(P2_22, V.Undef, hk_1450))))), ((V)(string.Concat("2.6 ", ToStr(Call(P2_22, V.Undef, hk_1450))))), ((V)(string.Concat("-2.6 ", ToStr(Call(P2_22, V.Undef, hk_1450)))))), ((V)(4.6)))), ToStr(chain_1455), "<g>", ToStr(Call(tex_33, V.Undef, s_1447, Arr(Arr(((V)("q8wv")), ((V)(0.95)))))), "</g>", ToStr(inner_1453), "<clipPath id=\"e8m\"><path d=\"", ToStr(mouth_1452), "\"/></clipPath><g clip-path=\"url(#e8m)\">", ToStr(cush_1454), "</g><path d=\"", ToStr(mouth_1452), "\" fill=\"none\" stroke=\"#8a5a2a\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.4 * ToNum(k_1449)))))), "\"/></g>")));
return default;
}, 2, "wrap", true)).V));
Set(D_1423, "fx", Fn((V _arrowThis1494, int _argc1487, V c_1493, V _a1490, V _a1491, V _a1492, V[] _rest1488) => {
V p_1495 = default;
V k_1496 = default;
V st0_1497 = default;
V stand_1498 = default;
p_1495 = Get(c_1493, "p");
k_1496 = Get(c_1493, "k");
st0_1497 = Arr(Call(p_1495, V.Undef, ((V)(0D)), ((V)(4D)), ((V)((-26D)))), Call(p_1495, V.Undef, ((V)(0D)), ((V)(60D)), ((V)((-34D)))), Call(p_1495, V.Undef, ((V)(0D)), ((V)(100D)), ((V)((-26D)))), CallSpread(p_1495, V.Undef, new ArrBuilder().Spread(HK_1420).V));
stand_1498 = Call(tube_45, V.Undef, Invoke(Invoke(Arr(Call(p_1495, V.Undef, ((V)(0D)), ((V)(3D)), ((V)((-6D)))), Call(p_1495, V.Undef, ((V)(0D)), ((V)(2.6)), ((V)((-28D))))), "concat", Invoke(Call(curve_46, V.Undef, Arr(((V)(0D)), ((V)(2.6)), ((V)((-28D)))), Arr(((V)(0D)), ((V)(70D)), ((V)((-40D)))), Arr(((V)(0D)), ((V)(104D)), ((V)((-22D)))), ((V)(10D))), "map", Fn((V _arrowThis1506, int _argc1499, V q_1505, V _a1502, V _a1503, V _a1504, V[] _rest1500) => {
return CallSpread(p_1495, V.Undef, new ArrBuilder().Spread(q_1505).V);
}, 1, "", true))), "concat", Arr(Call(p_1495, V.Undef, ((V)(0D)), ((V)(106D)), ((V)((-12D)))), CallSpread(p_1495, V.Undef, new ArrBuilder().Spread(HK_1420).V))), ((V)(2.4)), k_1496, ((V)("#2a2b30")), ((V)("#8a8f98")));
_ = st0_1497;
return NewObj(4).Put("defs", Add(LEAF_64, Call(L_38, V.Undef, ((V)("e8in")), Arr(Arr(((V)(0D)), ((V)("#2a1a0c")), ((V)(0.85))), Arr(((V)(1D)), ((V)("#7a5430")), ((V)(0.3))))))).Put("back", stand_1498).Put("front", ((V)(""))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1495, V.Undef, ((V)((-28D))), ((V)(0D)), ((V)((-40D)))), Call(p_1495, V.Undef, ((V)(28D)), ((V)(0D)), ((V)(22D))), Call(p_1495, V.Undef, ((V)(0D)), ((V)(112D)), ((V)((-24D)))), Call(p_1495, V.Undef, ((V)((-28D))), ((V)(0D)), ((V)(22D))), Call(p_1495, V.Undef, ((V)(28D)), ((V)(0D)), ((V)((-40D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1423;
return default;
}, 1, "", true));
Set(N_54, "porchSwing", Fn((V _arrowThis1514, int _argc1507, V S_1513, V _a1510, V _a1511, V _a1512, V[] _rest1508) => {
V CED_1515 = default;
V CED2_1516 = default;
double BX_1517 = 0;
double BZ_1518 = 0;
double BY_1519 = 0;
double BEAM_1520 = 0;
V D_1521 = default;
V corners_1522 = default;
V cush_1523 = default;
CED_1515 = ((V)("#b9733e"));
CED2_1516 = ((V)("#cf8f55"));
BX_1517 = 40D;
BZ_1518 = 18D;
BY_1519 = 22D;
BEAM_1520 = 92D;
D_1521 = NewObj(3).Put("w", ((V)(130D))).Put("d", ((V)(70D))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-14D)))).Put("z", ((V)(2D))).Put("h", ((V)((BY_1519 + 9D)))).V, NewObj(3).Put("x", ((V)(14D))).Put("z", ((V)(2D))).Put("h", ((V)((BY_1519 + 9D)))).V)).V;
Set(D_1521, "build", Fn((V _arrowThis1531, int _argc1524, V P_1530, V _a1527, V _a1528, V _a1529, V[] _rest1525) => {
V o_1532 = default;
o_1532 = Arr();
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis1540, int _argc1533, V s_1539, V _a1536, V _a1537, V _a1538, V[] _rest1534) => {
Invoke(o_1532, "push", Call(box_12, V.Undef, ((V)((ToNum(s_1539) * 54D))), ((V)(0D)), ((V)((-24D))), ((V)(5D)), ((V)(BEAM_1520)), ((V)(5D)), CED_1515, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)((ToNum(s_1539) * 54D))), ((V)(0D)), ((V)(24D)), ((V)(5D)), ((V)(BEAM_1520)), ((V)(5D)), CED_1515, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)((ToNum(s_1539) * 54D))), ((V)(0D)), ((V)(0D)), ((V)(5D)), ((V)(6D)), ((V)(58D)), CED2_1516, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)((ToNum(s_1539) * 54D))), ((V)((BEAM_1520 - 8D))), ((V)(0D)), ((V)(5D)), ((V)(6D)), ((V)(54D)), CED2_1516, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
return default;
}, 1, "", true));
Invoke(o_1532, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(BEAM_1520)), ((V)(0D)), ((V)(118D)), ((V)(6D)), ((V)(7D)), CED2_1516, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
return o_1532;
return default;
}, 1, "", true));
corners_1522 = Arr(Arr(((V)(((-BX_1517) + 2D))), ((V)(((-BZ_1518) + 2D)))), Arr(((V)((BX_1517 - 2D))), ((V)(((-BZ_1518) + 2D)))), Arr(((V)(((-BX_1517) + 2D))), ((V)((BZ_1518 - 2D)))), Arr(((V)((BX_1517 - 2D))), ((V)((BZ_1518 - 2D)))));
Set(D_1521, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1548, int _argc1541, V P_1547, V _a1544, V _a1545, V _a1546, V[] _rest1542) => {
V o_1549 = default;
o_1549 = Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(BY_1519)), ((V)(0D)), ((V)((2D * BX_1517))), ((V)(4D)), ((V)((2D * BZ_1518))), CED_1515, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(cush_1523, V.Undef, ((V)(0D)), ((V)((BY_1519 + 4D))), ((V)(1.5)), ((V)(((2D * BX_1517) - 6D))), ((V)(6D)), ((V)(((2D * BZ_1518) - 7D))), ((V)("#f2ece0"))), Call(box_12, V.Undef, ((V)(0D)), ((V)((BY_1519 + 4D))), ((V)(((-BZ_1518) + 1.6))), ((V)(((2D * BX_1517) - 6.2))), ((V)(18D)), ((V)(3D)), CED2_1516, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)(((-BX_1517) + 1.6))), ((V)((BY_1519 + 4D))), ((V)(1.5)), ((V)(3D)), ((V)(10D)), ((V)(((2D * BZ_1518) - 3D))), CED2_1516, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)((BX_1517 - 1.6))), ((V)((BY_1519 + 4D))), ((V)(1.5)), ((V)(3D)), ((V)(10D)), ((V)(((2D * BZ_1518) - 3D))), CED2_1516, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
Invoke(o_1549, "push", Call(ball_14, V.Undef, ((V)((-26D))), ((V)((BY_1519 + 10D))), ((V)(((-BZ_1518) + 6D))), ((V)(6D)), ((V)("#7aa8c8")), Call(fb_59, V.Undef, NewObj(5).Put("sx", ((V)(1.2))).Put("sy", ((V)(1D))).Put("sz", ((V)(0.5))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V)), Call(ball_14, V.Undef, ((V)(24D)), ((V)((BY_1519 + 10D))), ((V)(((-BZ_1518) + 6D))), ((V)(6D)), ((V)("#e8b45a")), Call(fb_59, V.Undef, NewObj(5).Put("sx", ((V)(1.2))).Put("sy", ((V)(1D))).Put("sz", ((V)(0.5))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V)), Call(ball_14, V.Undef, ((V)((-2D))), ((V)((BY_1519 + 10D))), ((V)(((-BZ_1518) + 7D))), ((V)(5D)), ((V)("#f4efe6")), Call(fb_59, V.Undef, NewObj(5).Put("sx", ((V)(1.3))).Put("sy", ((V)(0.9))).Put("sz", ((V)(0.5))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V)));
return o_1549;
return default;
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1558, int _argc1550, V p_1556, V s_1557, V _a1554, V _a1555, V[] _rest1551) => {
V k_1559 = default;
JsStrBuf rb_1560 = null;
JsStrBuf rf_1561 = null;
V pv_1562 = default;
k_1559 = Call(kOf_60, V.Undef, p_1556);
rb_1560 = new JsStrBuf("");
rf_1561 = new JsStrBuf("");
Invoke(corners_1522, "forEach", Fn((V _arrowThis1574, int _argc1563, V _a1565, V _a1566, V _a1567, V _a1568, V[] _rest1564) => {
V top_1575 = default;
V bot_1576 = default;
V t_1577 = default;
V x_1571 = default;
V z_1573 = default;
{ V _t1569 = ListOf(_a1565);
{ V _t1570 = GetIdx(_t1569, 0D);
x_1571 = _t1570; }
{ V _t1572 = GetIdx(_t1569, 1D);
z_1573 = _t1572; }
}
top_1575 = Arr(((V)((ToNum(x_1571) * 1.05))), ((V)(BEAM_1520)), ((V)(0D)));
bot_1576 = Arr(x_1571, ((V)((BY_1519 + 2D))), z_1573);
t_1577 = ((V)(JsStrBuf.Begin().V(Call(tube_45, V.Undef, Arr(CallSpread(p_1556, V.Undef, new ArrBuilder().Spread(top_1575).V), CallSpread(p_1556, V.Undef, new ArrBuilder().Spread(bot_1576).V)), ((V)(0.9)), k_1559, ((V)("#e8dcc0")), ((V)("#ffffff")), ((V)("#8a7a5a")))).S(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(CallSpread(p_1556, V.Undef, new ArrBuilder().Spread(bot_1576).V), 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(CallSpread(p_1556, V.Undef, new ArrBuilder().Spread(bot_1576).V), 1D))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.3 * ToNum(k_1559)))))), "\" fill=\"none\" stroke=\"#c9d0d6\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.6 * ToNum(k_1559)))))), "\"/>")).End()));
if (LtN(z_1573, 0D)) {
rb_1560.V(t_1577);
} else {
rf_1561.V(t_1577);
}
return default;
}, 1, "", true));
pv_1562 = Call(p_1556, V.Undef, ((V)(0D)), ((V)(BEAM_1520)), ((V)(0D)));
return ((V)(string.Concat("<g>", ToStr(Call(atV_34, V.Undef, ((V)("rotate")), Arr(((V)(string.Concat("-1.6 ", ToStr(Call(P2_22, V.Undef, pv_1562))))), ((V)(string.Concat("1.6 ", ToStr(Call(P2_22, V.Undef, pv_1562))))), ((V)(string.Concat("-1.6 ", ToStr(Call(P2_22, V.Undef, pv_1562)))))), ((V)(3.8)))), rb_1560.Str, ToStr(s_1557), rf_1561.Str, "</g>")));
return default;
}, 2, "wrap", true)).V));
cush_1523 = Fn((V _arrowThis1591, int _argc1578, V x_1584, V y_1585, V z_1586, V w_1587, V[] _rest1579) => {
V h_1588 = default;
V d_1589 = default;
V c_1590 = default;
h_1588 = (_argc1578 > 4 ? _rest1579[0] : V.Undef);
d_1589 = (_argc1578 > 5 ? _rest1579[1] : V.Undef);
c_1590 = (_argc1578 > 6 ? _rest1579[2] : V.Undef);
return Invoke(K_10, "cush", x_1584, y_1585, z_1586, w_1587, h_1588, d_1589, c_1590, Call(fb_59, V.Undef, NewObj(0).V));
}, 7, "", true);
Set(D_1521, "fx", Fn((V _arrowThis1599, int _argc1592, V c_1598, V _a1595, V _a1596, V _a1597, V[] _rest1593) => {
return NewObj(3).Put("defs", ((V)(""))).Put("front", ((V)(""))).Put("bb", Call(bbOf_28, V.Undef, Arr(Invoke(c_1598, "p", ((V)((-60D))), ((V)(0D)), ((V)((-30D)))), Invoke(c_1598, "p", ((V)(60D)), ((V)(0D)), ((V)(30D))), Invoke(c_1598, "p", ((V)((-60D))), ((V)((BEAM_1520 + 8D))), ((V)((-30D)))), Invoke(c_1598, "p", ((V)(60D)), ((V)((BEAM_1520 + 8D))), ((V)(30D))), Invoke(c_1598, "p", ((V)((-60D))), ((V)(0D)), ((V)(30D))), Invoke(c_1598, "p", ((V)(60D)), ((V)(0D)), ((V)((-30D))))), ((V)(3D)))).V;
}, 1, "", true));
return D_1521;
return default;
}, 1, "", true));
Set(N_54, "blockBench", Fn((V _arrowThis1607, int _argc1600, V S_1606, V _a1603, V _a1604, V _a1605, V[] _rest1601) => {
V CB_1608 = default;
V PL_1609 = default;
V D_1610 = default;
CB_1608 = ((V)("#a9a8a2"));
PL_1609 = ((V)("#d8b98a"));
D_1610 = NewObj(3).Put("w", ((V)(110D))).Put("d", ((V)(40D))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-16D)))).Put("z", ((V)(2D))).Put("h", ((V)(17D))).V, NewObj(3).Put("x", ((V)(16D))).Put("z", ((V)(2D))).Put("h", ((V)(17D))).V)).V;
Set(D_1610, "build", Fn((V _arrowThis1618, int _argc1611, V P_1617, V _a1614, V _a1615, V _a1616, V[] _rest1612) => {
V o_1619 = default;
o_1619 = Arr();
Invoke(Arr(((V)((-34D))), ((V)(34D))), "forEach", Fn((V _arrowThis1627, int _argc1620, V x_1626, V _a1623, V _a1624, V _a1625, V[] _rest1621) => {
return Invoke(o_1619, "push", Call(box_12, V.Undef, x_1626, ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(7.6)), ((V)(15D)), CB_1608, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)), Call(box_12, V.Undef, x_1626, ((V)(7.6)), ((V)(0D)), ((V)(16D)), ((V)(7.6)), ((V)(15D)), CB_1608, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
}, 1, "", true));
Invoke(Arr(((V)((-5D))), ((V)(0.2)), ((V)(5.4))), "forEach", Fn((V _arrowThis1635, int _argc1628, V z_1634, V _a1631, V _a1632, V _a1633, V[] _rest1629) => {
return Invoke(o_1619, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(15.2)), z_1634, ((V)(96D)), ((V)(1.8)), ((V)(4.8)), PL_1609, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
Invoke(Arr(((V)((-34D))), ((V)(34D))), "forEach", Fn((V _arrowThis1643, int _argc1636, V x_1642, V _a1639, V _a1640, V _a1641, V[] _rest1637) => {
return Invoke(o_1619, "push", Call(box_12, V.Undef, ((V)((ToNum(x_1642) - 4D))), ((V)(17D)), ((V)((-5.4))), ((V)(3.6)), ((V)(24.2)), ((V)(1.8)), PL_1609, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)), Call(box_12, V.Undef, Add(x_1642, ((V)(4D))), ((V)(17D)), ((V)((-5.4))), ((V)(3.6)), ((V)(24.2)), ((V)(1.8)), PL_1609, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V)));
}, 1, "", true));
Invoke(Arr(((V)(28D)), ((V)(36D))), "forEach", Fn((V _arrowThis1651, int _argc1644, V y_1650, V _a1647, V _a1648, V _a1649, V[] _rest1645) => {
return Invoke(o_1619, "push", Call(box_12, V.Undef, ((V)(0D)), y_1650, ((V)((-3.6))), ((V)(96D)), ((V)(4.8)), ((V)(1.8)), PL_1609, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
return o_1619;
return default;
}, 1, "", true));
Set(D_1610, "fx", Fn((V _arrowThis1659, int _argc1652, V c_1658, V _a1655, V _a1656, V _a1657, V[] _rest1653) => {
V p_1660 = default;
JsStrBuf f_1661 = null;
p_1660 = Get(c_1658, "p");
f_1661 = new JsStrBuf("");
Invoke(Arr(((V)((-34D))), ((V)(34D))), "forEach", Fn((V _arrowThis1669, int _argc1662, V x_1668, V _a1665, V _a1666, V _a1667, V[] _rest1663) => {
return Invoke(Arr(((V)(0D)), ((V)(7.6))), "forEach", Fn((V _arrowThis1677, int _argc1670, V y_1676, V _a1673, V _a1674, V _a1675, V[] _rest1671) => {
return ((V)(f_1661.S(string.Concat("<g transform=\"", ToStr(Call(plane_24, V.Undef, p_1660, ((V)(7.55)), Add(y_1676, ((V)(7.6))), ((V)((ToNum(x_1668) - 8D))))), "\"><rect x=\"2\" y=\"1.4\" width=\"5\" height=\"4.8\" rx=\"0.6\" fill=\"#6a6964\"/><rect x=\"9\" y=\"1.4\" width=\"5\" height=\"4.8\" rx=\"0.6\" fill=\"#6a6964\"/><rect x=\"2\" y=\"1.4\" width=\"5\" height=\"1\" fill=\"#4a4946\"/><rect x=\"9\" y=\"1.4\" width=\"5\" height=\"1\" fill=\"#4a4946\"/></g>")).Str));
}, 1, "", true));
}, 1, "", true));
f_1661.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_1660, ((V)(17.05)))), "\">", ToStr(Invoke(Invoke(Arr(((V)((-5D))), ((V)(0.2)), ((V)(5.4))), "map", Fn((V _arrowThis1685, int _argc1678, V z_1684, V _a1681, V _a1682, V _a1683, V[] _rest1679) => {
return ((V)(string.Concat("<path d=\"M-46 ", ToStr(z_1684), "H46\" stroke=\"#a8875a\" stroke-width=\"0.3\"/><circle cx=\"-44\" cy=\"", ToStr(z_1684), "\" r=\"0.5\" fill=\"#6a6a6a\"/><circle cx=\"44\" cy=\"", ToStr(z_1684), "\" r=\"0.5\" fill=\"#6a6a6a\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g>"));
return NewObj(3).Put("defs", ((V)(""))).Put("front", ((V)(f_1661.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1660, V.Undef, ((V)((-50D))), ((V)(0D)), ((V)((-10D)))), Call(p_1660, V.Undef, ((V)(50D)), ((V)(0D)), ((V)(10D))), Call(p_1660, V.Undef, ((V)((-50D))), ((V)(42D)), ((V)((-6D)))), Call(p_1660, V.Undef, ((V)(50D)), ((V)(42D)), ((V)((-6D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1610;
return default;
}, 1, "", true));
Set(N_54, "parkBench", Fn((V _arrowThis1693, int _argc1686, V S_1692, V _a1689, V _a1690, V _a1691, V[] _rest1687) => {
V IR_1694 = default;
V OAK_1695 = default;
V D_1696 = default;
IR_1694 = ((V)("#1f2124"));
OAK_1695 = ((V)("#c08a52"));
D_1696 = NewObj(3).Put("w", ((V)(110D))).Put("d", ((V)(44D))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-18D)))).Put("z", ((V)(2D))).Put("h", ((V)(17D))).V, NewObj(3).Put("x", ((V)(18D))).Put("z", ((V)(2D))).Put("h", ((V)(17D))).V)).V;
Set(D_1696, "build", Fn((V _arrowThis1704, int _argc1697, V P_1703, V _a1700, V _a1701, V _a1702, V[] _rest1698) => {
V o_1705 = default;
o_1705 = Arr();
Call(rep_19, V.Undef, ((V)(5D)), Fn((V _arrowThis1713, int _argc1706, V i_1712, V _a1709, V _a1710, V _a1711, V[] _rest1707) => {
return Invoke(o_1705, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(15.4)), ((V)(((-7D) + (ToNum(i_1712) * 4.2)))), ((V)(88D)), ((V)(1.8)), ((V)(3.4)), OAK_1695, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
}, 1, "", true));
Call(rep_19, V.Undef, ((V)(4D)), Fn((V _arrowThis1721, int _argc1714, V i_1720, V _a1717, V _a1718, V _a1719, V[] _rest1715) => {
double y_1722 = 0;
double z_1723 = 0;
y_1722 = (21D + (ToNum(i_1720) * 5.6));
z_1723 = ((-9.8) - (ToNum(i_1720) * 0.8));
Invoke(o_1705, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(y_1722)), ((V)(z_1723)), ((V)(88D)), ((V)(4.2)), ((V)(1.6)), OAK_1695, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
return default;
}, 1, "", true));
return o_1705;
return default;
}, 1, "", true));
Set(D_1696, "fx", Fn((V _arrowThis1731, int _argc1724, V c_1730, V _a1727, V _a1728, V _a1729, V[] _rest1725) => {
V p_1732 = default;
V k_1733 = default;
JsStrBuf f_1734 = null;
JsStrBuf bk_1735 = null;
p_1732 = Get(c_1730, "p");
k_1733 = Get(c_1730, "k");
f_1734 = new JsStrBuf("");
bk_1735 = new JsStrBuf("");
Invoke(Arr(((V)((-43D))), ((V)(43D))), "forEach", Fn((V _arrowThis1743, int _argc1736, V x_1742, V _a1739, V _a1740, V _a1741, V[] _rest1737) => {
V P3_1744 = default;
V s2_1745 = default;
P3_1744 = Fn((V _arrowThis1753, int _argc1746, V a_1752, V _a1749, V _a1750, V _a1751, V[] _rest1747) => {
return Invoke(a_1752, "map", Fn((V _arrowThis1765, int _argc1754, V _a1756, V _a1757, V _a1758, V _a1759, V[] _rest1755) => {
V z_1762 = default;
V y_1764 = default;
{ V _t1760 = ListOf(_a1756);
{ V _t1761 = GetIdx(_t1760, 0D);
z_1762 = _t1761; }
{ V _t1763 = GetIdx(_t1760, 1D);
y_1764 = _t1763; }
}
return Call(p_1732, V.Undef, x_1742, y_1764, z_1762);
}, 1, "", true));
}, 1, "", true);
s2_1745 = Add(Add(Add(Call(tube_45, V.Undef, Call(P3_1744, V.Undef, Arr(Arr(((V)(11D)), ((V)(0D))), Arr(((V)(9D)), ((V)(15D))), Arr(((V)(10.6)), ((V)(23.6))))), ((V)(1.8)), k_1733, IR_1694, ((V)("#6a6e76"))), Call(tube_45, V.Undef, Call(P3_1744, V.Undef, Arr(Arr(((V)((-12D))), ((V)(0D))), Invoke(Arr(((V)((-9D))), ((V)(15D))), "concat"), Arr(((V)((-10.4))), ((V)(22D))), Arr(((V)((-12.6))), ((V)(33D))), Arr(((V)((-14.6))), ((V)(44D))))), ((V)(1.8)), k_1733, IR_1694, ((V)("#6a6e76")))), Call(tube_45, V.Undef, Call(P3_1744, V.Undef, Arr(Arr(((V)((-10D))), ((V)(15D))), Arr(((V)(9.4)), ((V)(15D))))), ((V)(1.5)), k_1733, IR_1694, ((V)("#6a6e76")))), Call(tube_45, V.Undef, Call(P3_1744, V.Undef, Arr(Arr(((V)((-10.6))), ((V)(24D))), Arr(((V)(12D)), ((V)(24D))), Arr(((V)(13.4)), ((V)(22.4))))), ((V)(1.7)), k_1733, IR_1694, ((V)("#6a6e76"))));
s2_1745 = ((V)(JsStrBuf.Begin().V(s2_1745).V(Add(Call(tube_45, V.Undef, Call(P3_1744, V.Undef, Call(rep_19, V.Undef, ((V)(9D)), Fn((V _arrowThis1773, int _argc1766, V i_1772, V _a1769, V _a1770, V _a1771, V[] _rest1767) => {
double a_1774 = 0;
a_1774 = (((ToNum(i_1772) / 8D) * 2D) * PI_55);
return Arr(((V)(((-1D) + (FdLibm.Cos(a_1774) * 3.2)))), ((V)((7.4 + (FdLibm.Sin(a_1774) * 3.2)))));
return default;
}, 1, "", true))), ((V)(0.6)), k_1733, IR_1694, ((V)("#6a6e76"))), Call(tube_45, V.Undef, Call(P3_1744, V.Undef, Call(rep_19, V.Undef, ((V)(7D)), Fn((V _arrowThis1782, int _argc1775, V i_1781, V _a1778, V _a1779, V _a1780, V[] _rest1776) => {
double a_1783 = 0;
a_1783 = (PI_55 + (((ToNum(i_1781) / 6D) * PI_55) * 1.4));
return Arr(((V)(((-11.6) + (FdLibm.Cos(a_1783) * 1.6)))), ((V)((36D + (FdLibm.Sin(a_1783) * 1.6)))));
return default;
}, 1, "", true))), ((V)(0.5)), k_1733, IR_1694, ((V)("#6a6e76"))))).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(Call(p_1732, V.Undef, x_1742, ((V)(0D)), ((V)(11D))), 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(Call(p_1732, V.Undef, x_1742, ((V)(0D)), ((V)(11D))), 1D))), "\" rx=\"", ToStr(Call(f1_18, V.Undef, ((V)((2D * ToNum(k_1733)))))), "\" ry=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.9 * ToNum(k_1733)))))), "\" fill=\"#141416\"/>")).End()));
if (LtN(x_1742, 0D)) {
bk_1735.V(s2_1745);
} else {
f_1734.V(s2_1745);
}
return default;
}, 1, "", true));
return NewObj(4).Put("defs", ((V)(""))).Put("back", ((V)(bk_1735.Str))).Put("front", ((V)(f_1734.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1732, V.Undef, ((V)((-48D))), ((V)(0D)), ((V)((-16D)))), Call(p_1732, V.Undef, ((V)(48D)), ((V)(0D)), ((V)(16D))), Call(p_1732, V.Undef, ((V)((-48D))), ((V)(46D)), ((V)((-16D)))), Call(p_1732, V.Undef, ((V)(48D)), ((V)(46D)), ((V)((-16D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1696;
return default;
}, 1, "", true));
Set(N_54, "lawnChairs", Fn((V _arrowThis1791, int _argc1784, V S_1790, V _a1787, V _a1788, V _a1789, V[] _rest1785) => {
V RS_1792 = default;
V D_1793 = default;
V chair_1794 = default;
RS_1792 = ((V)("#f2efe8"));
D_1793 = NewObj(3).Put("w", ((V)(110D))).Put("d", ((V)(50D))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-24D)))).Put("z", ((V)(2D))).Put("h", ((V)(15D))).V, NewObj(3).Put("x", ((V)(24D))).Put("z", ((V)(2D))).Put("h", ((V)(15D))).V)).V;
chair_1794 = Fn((V _arrowThis1803, int _argc1795, V o_1801, V cx_1802, V _a1799, V _a1800, V[] _rest1796) => {
Invoke(Arr(Arr(((V)((-9D))), ((V)(8D))), Arr(((V)(9D)), ((V)(8D)))), "forEach", Fn((V _arrowThis1815, int _argc1804, V _a1806, V _a1807, V _a1808, V _a1809, V[] _rest1805) => {
V x_1812 = default;
V z_1814 = default;
{ V _t1810 = ListOf(_a1806);
{ V _t1811 = GetIdx(_t1810, 0D);
x_1812 = _t1811; }
{ V _t1813 = GetIdx(_t1810, 1D);
z_1814 = _t1813; }
}
return Invoke(o_1801, "push", Call(box_12, V.Undef, Add(cx_1802, x_1812), ((V)(0D)), z_1814, ((V)(2.6)), ((V)(14D)), ((V)(2.6)), RS_1792, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
Invoke(Arr(Arr(((V)((-9D))), ((V)((-8D)))), Arr(((V)(9D)), ((V)((-8D))))), "forEach", Fn((V _arrowThis1827, int _argc1816, V _a1818, V _a1819, V _a1820, V _a1821, V[] _rest1817) => {
V x_1824 = default;
V z_1826 = default;
{ V _t1822 = ListOf(_a1818);
{ V _t1823 = GetIdx(_t1822, 0D);
x_1824 = _t1823; }
{ V _t1825 = GetIdx(_t1822, 1D);
z_1826 = _t1825; }
}
return Invoke(o_1801, "push", Call(box_12, V.Undef, Add(cx_1802, x_1824), ((V)(0D)), z_1826, ((V)(2.6)), ((V)(14D)), ((V)(2.6)), RS_1792, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
Invoke(o_1801, "push", Invoke(K_10, "cush", cx_1802, ((V)(13D)), ((V)(0.6)), ((V)(22D)), ((V)(2.6)), ((V)(19D)), RS_1792, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(prism_16, V.Undef, ((V)((ToNum(cx_1802) - 10.6))), Add(cx_1802, ((V)(10.6))), Arr(Arr(((V)((-9.6))), ((V)(15D))), Arr(((V)((-7.4))), ((V)(15D))), Arr(((V)((-10.4))), ((V)(38D))), Arr(((V)((-12.8))), ((V)(38D)))), RS_1792, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)((ToNum(cx_1802) - 11D))), ((V)(21D)), ((V)(0D)), ((V)(2.2)), ((V)(1.6)), ((V)(18D)), RS_1792, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, Add(cx_1802, ((V)(11D))), ((V)(21D)), ((V)(0D)), ((V)(2.2)), ((V)(1.6)), ((V)(18D)), RS_1792, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)((ToNum(cx_1802) - 11D))), ((V)(14D)), ((V)(8.4)), ((V)(2D)), ((V)(7D)), ((V)(2D)), RS_1792, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, Add(cx_1802, ((V)(11D))), ((V)(14D)), ((V)(8.4)), ((V)(2D)), ((V)(7D)), ((V)(2D)), RS_1792, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
return default;
}, 2, "", true);
Set(D_1793, "build", Fn((V _arrowThis1835, int _argc1828, V P_1834, V _a1831, V _a1832, V _a1833, V[] _rest1829) => {
V o_1836 = default;
o_1836 = Arr();
Call(chair_1794, V.Undef, o_1836, ((V)((-24D))));
Call(chair_1794, V.Undef, o_1836, ((V)(24D)));
return o_1836;
return default;
}, 1, "", true));
Set(D_1793, "fx", Fn((V _arrowThis1844, int _argc1837, V c_1843, V _a1840, V _a1841, V _a1842, V[] _rest1838) => {
V p_1845 = default;
V k_1846 = default;
JsStrBuf f_1847 = null;
p_1845 = Get(c_1843, "p");
k_1846 = Get(c_1843, "k");
f_1847 = new JsStrBuf("");
Invoke(Arr(((V)((-24D))), ((V)(24D))), "forEach", Fn((V _arrowThis1855, int _argc1848, V cx_1854, V _a1851, V _a1852, V _a1853, V[] _rest1849) => {
Call(rep_19, V.Undef, ((V)(4D)), Fn((V _arrowThis1863, int _argc1856, V i_1862, V _a1859, V _a1860, V _a1861, V[] _rest1857) => {
double y_1864 = 0;
double z_1865 = 0;
V a_1866 = default;
V b_1867 = default;
y_1864 = (22D + (ToNum(i_1862) * 3.6));
z_1865 = (((-9D) - ((y_1864 - 15D) * (2.6 / 23D))) - 0.4);
a_1866 = Call(p_1845, V.Undef, ((V)((ToNum(cx_1854) - 7D))), ((V)(y_1864)), ((V)((z_1865 + 0.1))));
b_1867 = Call(p_1845, V.Undef, Add(cx_1854, ((V)(7D))), ((V)(y_1864)), ((V)((z_1865 + 0.1))));
f_1847.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, a_1866)), "L", ToStr(Call(P2_22, V.Undef, b_1867)), "\" stroke=\"#b9b4aa\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.1 * ToNum(k_1846)))))), "\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Call(P2_22, V.Undef, a_1866)), "L", ToStr(Call(P2_22, V.Undef, b_1867)), "\" stroke=\"#d6d1c6\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.5 * ToNum(k_1846)))))), "\" stroke-linecap=\"round\" transform=\"translate(0 ", ToStr(Call(f1_18, V.Undef, ((V)((0.5 * ToNum(k_1846)))))), ")\"/>"));
return default;
}, 1, "", true));
f_1847.S(string.Concat("<g transform=\"", ToStr(Call(planeH_23, V.Undef, p_1845, ((V)(15.7)), cx_1854, ((V)(0.6)))), "\"><path d=\"M-6 -4L-3 1L-5 5\" stroke=\"#c9c3b6\" stroke-width=\"0.3\" fill=\"none\"/></g>"));
return default;
}, 1, "", true));
return NewObj(3).Put("defs", ((V)(""))).Put("front", ((V)(f_1847.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1845, V.Undef, ((V)((-40D))), ((V)(0D)), ((V)((-14D)))), Call(p_1845, V.Undef, ((V)(40D)), ((V)(0D)), ((V)(14D))), Call(p_1845, V.Undef, ((V)((-40D))), ((V)(40D)), ((V)((-14D)))), Call(p_1845, V.Undef, ((V)(40D)), ((V)(40D)), ((V)((-14D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1793;
return default;
}, 1, "", true));
Set(N_54, "umbrella8", Fn((V _arrowThis1875, int _argc1868, V S_1874, V _a1871, V _a1872, V _a1873, V[] _rest1869) => {
double R_1876 = 0;
double TOP_1877 = 0;
double RIM_1878 = 0;
V C1_1879 = default;
V C2_1880 = default;
V D_1881 = default;
R_1876 = 46D;
TOP_1877 = 84D;
RIM_1878 = 72D;
C1_1879 = ((V)("#2f86c8"));
C2_1880 = ((V)("#fbf7ee"));
D_1881 = NewObj(3).Put("w", ((V)(100D))).Put("d", ((V)(100D))).Put("round", ((V)(1D))).V;
Set(D_1881, "build", Fn((V _arrowThis1889, int _argc1882, V P_1888, V _a1885, V _a1886, V _a1887, V[] _rest1883) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(13D)), ((V)(3.6)), ((V)("#2c2e33")), Call(mt_29, V.Undef, NewObj(3).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.95))), Arr(((V)(3.6)), ((V)(0D)), ((V)(0.6))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(3.6)), ((V)(0D)), ((V)(1.6)), ((V)((TOP_1877 - 3.6))), ((V)("#e8e4dc")), Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(2.6)), ((V)(6D)), ((V)("#c9d0d6")), Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
Set(D_1881, "fx", Fn((V _arrowThis1897, int _argc1890, V c_1896, V _a1893, V _a1894, V _a1895, V[] _rest1891) => {
V p_1898 = default;
V k_1899 = default;
JsStrBuf f_1900 = null;
JsStrBuf bk_1901 = null;
V rimP_1902 = default;
V panels_1903 = default;
V T0_1904 = default;
V cq_1905 = default;
p_1898 = Get(c_1896, "p");
k_1899 = Get(c_1896, "k");
f_1900 = new JsStrBuf("");
bk_1901 = new JsStrBuf("");
rimP_1902 = Fn((V _arrowThis1913, int _argc1906, V i_1912, V _a1909, V _a1910, V _a1911, V[] _rest1907) => {
double a_1914 = 0;
a_1914 = ((((ToNum(i_1912) / 8D) * 2D) * PI_55) + (PI_55 / 8D));
return Arr(((V)((R_1876 * FdLibm.Cos(a_1914)))), ((V)(RIM_1878)), ((V)((R_1876 * FdLibm.Sin(a_1914)))));
return default;
}, 1, "", true);
panels_1903 = Invoke(Call(rep_19, V.Undef, ((V)(8D)), Fn((V _arrowThis1931, int _argc1924, V i_1930, V _a1927, V _a1928, V _a1929, V[] _rest1925) => {
V a_1932 = default;
V b_1933 = default;
V m_1934 = default;
double dep_1935 = 0;
a_1932 = Call(rimP_1902, V.Undef, i_1930);
b_1933 = Call(rimP_1902, V.Undef, Add(i_1930, ((V)(1D))));
m_1934 = Arr(((V)(((ToNum(Add(GetIdx(a_1932, 0D), GetIdx(b_1933, 0D))) / 2D) * 0.98))), ((V)((RIM_1878 + 1.6))), ((V)(((ToNum(Add(GetIdx(a_1932, 2D), GetIdx(b_1933, 2D))) / 2D) * 0.98))));
dep_1935 = ((ToNum(GetIdx(m_1934, 0D)) * 0.5) + (ToNum(GetIdx(m_1934, 2D)) * 0.866));
return NewObj(5).Put("i", i_1930).Put("a", a_1932).Put("b", b_1933).Put("m", m_1934).Put("dep", ((V)(dep_1935))).V;
return default;
}, 1, "", true)), "sort", Fn((V _arrowThis1923, int _argc1915, V u_1921, V v_1922, V _a1919, V _a1920, V[] _rest1916) => {
return ((V)((ToNum(Get(u_1921, "dep")) - ToNum(Get(v_1922, "dep")))));
}, 2, "", true));
Call(rep_19, V.Undef, ((V)(8D)), Fn((V _arrowThis1943, int _argc1936, V i_1942, V _a1939, V _a1940, V _a1941, V[] _rest1937) => {
V a_1944 = default;
a_1944 = Call(rimP_1902, V.Undef, i_1942);
bk_1901.V(Add(Call(tube_45, V.Undef, Arr(Call(p_1898, V.Undef, ((V)(0D)), ((V)((TOP_1877 - 1D))), ((V)(0D))), Call(p_1898, V.Undef, ((V)((ToNum(GetIdx(a_1944, 0D)) * 0.98))), ((V)((RIM_1878 - 0.4))), ((V)((ToNum(GetIdx(a_1944, 2D)) * 0.98))))), ((V)(0.6)), k_1899, ((V)("#d8d2c4")), ((V)("#ffffff")), ((V)("#6a6a60"))), Call(tube_45, V.Undef, Arr(Call(p_1898, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(0D))), Call(p_1898, V.Undef, ((V)((ToNum(GetIdx(a_1944, 0D)) * 0.45))), ((V)((RIM_1878 - 4D))), ((V)((ToNum(GetIdx(a_1944, 2D)) * 0.45))))), ((V)(0.45)), k_1899, ((V)("#d8d2c4")), ((V)("#ffffff")), ((V)("#6a6a60")))));
return default;
}, 1, "", true));
Invoke(panels_1903, "forEach", Fn((V _arrowThis1959, int _argc1945, V _a1947, V _a1948, V _a1949, V _a1950, V[] _rest1946) => {
V col_1960 = default;
double lit_1961 = 0;
V A_1962 = default;
V Bq_1963 = default;
V M_1964 = default;
V T0_1965 = default;
V fr_1966 = default;
V i_1952 = default;
V a_1954 = default;
V b_1956 = default;
V m_1958 = default;
if (_a1947.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a1947));
{ V _t1951 = Get(_a1947, "i");
i_1952 = _t1951; }
{ V _t1953 = Get(_a1947, "a");
a_1954 = _t1953; }
{ V _t1955 = Get(_a1947, "b");
b_1956 = _t1955; }
{ V _t1957 = Get(_a1947, "m");
m_1958 = _t1957; }
col_1960 = (NumTruthy((ToNum(i_1952) % 2D)) ? C1_1879 : C2_1880);
lit_1961 = (0.5 + (0.5 * Max((-1D), Min(1D, ((-(((ToNum(Add(GetIdx(a_1954, 0D), GetIdx(b_1956, 0D))) * 0.5) * 0.4) - ((ToNum(Add(GetIdx(a_1954, 2D), GetIdx(b_1956, 2D))) * 0.5) * 0.2))) / R_1876)))));
A_1962 = CallSpread(p_1898, V.Undef, new ArrBuilder().Spread(a_1954).V);
Bq_1963 = CallSpread(p_1898, V.Undef, new ArrBuilder().Spread(b_1956).V);
M_1964 = CallSpread(p_1898, V.Undef, new ArrBuilder().Spread(m_1958).V);
T0_1965 = Call(p_1898, V.Undef, ((V)(0D)), ((V)(TOP_1877)), ((V)(0D)));
f_1900.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, T0_1965)), "L", ToStr(Call(P2_22, V.Undef, A_1962)), "Q", ToStr(Call(P2_22, V.Undef, M_1964)), " ", ToStr(Call(P2_22, V.Undef, Bq_1963)), "Z\" fill=\"", ToStr(col_1960), "\" stroke=\"#8a8478\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_1899)))))), "\"/><path d=\"M", ToStr(Call(P2_22, V.Undef, T0_1965)), "L", ToStr(Call(P2_22, V.Undef, A_1962)), "Q", ToStr(Call(P2_22, V.Undef, M_1964)), " ", ToStr(Call(P2_22, V.Undef, Bq_1963)), "Z\" fill=\"", ((lit_1961 > 0.55) ? "#ffffff" : "#000000"), "\" opacity=\"", ToStr(Call(n4_21, V.Undef, ((V)((System.Math.Abs((lit_1961 - 0.55)) * 0.35))))), "\"/>"));
fr_1966 = Call(facing_44, V.Undef, ((V)(FdLibm.Atan2(ToNum(GetIdx(m_1958, 0D)), ToNum(GetIdx(m_1958, 2D))))));
if (GtN(fr_1966, (-0.1))) {
JsStrBuf v_1967 = null;
v_1967 = new JsStrBuf("");
Call(rep_19, V.Undef, ((V)(5D)), Fn((V _arrowThis1975, int _argc1968, V j_1974, V _a1971, V _a1972, V _a1973, V[] _rest1969) => {
double t0_1976 = 0;
double t1_1977 = 0;
V q0_1978 = default;
V q1_1979 = default;
t0_1976 = (ToNum(j_1974) / 5D);
t1_1977 = (ToNum(Add(j_1974, ((V)(1D)))) / 5D);
q0_1978 = Call(p_1898, V.Undef, Add(GetIdx(a_1954, 0D), ((V)(((ToNum(GetIdx(b_1956, 0D)) - ToNum(GetIdx(a_1954, 0D))) * t0_1976)))), ((V)(RIM_1878)), Add(GetIdx(a_1954, 2D), ((V)(((ToNum(GetIdx(b_1956, 2D)) - ToNum(GetIdx(a_1954, 2D))) * t0_1976)))));
q1_1979 = Call(p_1898, V.Undef, Add(GetIdx(a_1954, 0D), ((V)(((ToNum(GetIdx(b_1956, 0D)) - ToNum(GetIdx(a_1954, 0D))) * t1_1977)))), ((V)(RIM_1878)), Add(GetIdx(a_1954, 2D), ((V)(((ToNum(GetIdx(b_1956, 2D)) - ToNum(GetIdx(a_1954, 2D))) * t1_1977)))));
v_1967.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, q0_1978)), "L", ToStr(Call(P2_22, V.Undef, q1_1979)), "Q", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(Add(GetIdx(q0_1978, 0D), GetIdx(q1_1979, 0D))) / 2D))))), " ", ToStr(Call(f1_18, V.Undef, ((V)(((ToNum(Add(GetIdx(q0_1978, 1D), GetIdx(q1_1979, 1D))) / 2D) + (4D * ToNum(k_1899))))))), " ", ToStr(Call(P2_22, V.Undef, q0_1978)), "Z\" fill=\"", ToStr((SEq(col_1960, C1_1879) ? C2_1880 : C1_1879)), "\" stroke=\"#8a8478\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.2 * ToNum(k_1899)))))), "\"/>"));
return default;
}, 1, "", true));
f_1900.S(v_1967.Str);
}
return default;
}, 1, "", true));
T0_1904 = Call(p_1898, V.Undef, ((V)(0D)), ((V)(TOP_1877)), ((V)(0D)));
f_1900.S(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(T0_1904, 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(GetIdx(T0_1904, 1D)) - (2D * ToNum(k_1899))))))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((2.4 * ToNum(k_1899)))))), "\" fill=\"#e8e4dc\" stroke=\"#8a8478\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_1899)))))), "\"/>"));
cq_1905 = Call(p_1898, V.Undef, ((V)(2.6)), ((V)(33D)), ((V)(0D)));
bk_1901.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, cq_1905)), "l", ToStr(Call(f1_18, V.Undef, ((V)((4D * ToNum(k_1899)))))), " ", ToStr(Call(f1_18, V.Undef, ((V)((1D * ToNum(k_1899)))))), "l0 ", ToStr(Call(f1_18, V.Undef, ((V)((3D * ToNum(k_1899)))))), "\" stroke=\"#c9d0d6\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.7 * ToNum(k_1899)))))), "\" fill=\"none\"/><circle cx=\"", ToStr(Call(f1_18, V.Undef, Add(GetIdx(cq_1905, 0D), ((V)((4D * ToNum(k_1899))))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, Add(GetIdx(cq_1905, 1D), ((V)((4D * ToNum(k_1899))))))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((1D * ToNum(k_1899)))))), "\" fill=\"#2c2e33\"/>"));
return NewObj(4).Put("defs", ((V)(""))).Put("back", ((V)(""))).Put("front", ((V)(string.Concat(bk_1901.Str, string.Concat("<g>", ToStr(Call(atV_34, V.Undef, ((V)("translate")), Arr(((V)("0 0")), ((V)(string.Concat("0 ", ToStr(Call(f1_18, V.Undef, ((V)(((-0.6) * ToNum(k_1899))))))))), ((V)("0 0"))), ((V)(3.4)))), f_1900.Str, "</g>"))))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1898, V.Undef, ((V)(((-R_1876) - 2D))), ((V)((RIM_1878 - 4D))), ((V)(((-R_1876) - 2D)))), Call(p_1898, V.Undef, ((V)((R_1876 + 2D))), ((V)((RIM_1878 - 4D))), ((V)((R_1876 + 2D)))), Call(p_1898, V.Undef, ((V)(((-R_1876) - 2D))), ((V)((RIM_1878 - 4D))), ((V)((R_1876 + 2D)))), Call(p_1898, V.Undef, ((V)((R_1876 + 2D))), ((V)((RIM_1878 - 4D))), ((V)(((-R_1876) - 2D)))), Call(p_1898, V.Undef, ((V)(0D)), ((V)((TOP_1877 + 4D))), ((V)(0D))), Call(p_1898, V.Undef, ((V)((-14D))), ((V)(0D)), ((V)(14D))), Call(p_1898, V.Undef, ((V)(14D)), ((V)(0D)), ((V)((-14D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1881;
return default;
}, 1, "", true));
Set(N_54, "cabana8", Fn((V _arrowThis1987, int _argc1980, V S_1986, V _a1983, V _a1984, V _a1985, V[] _rest1981) => {
double W_1988 = 0;
double DZ_1989 = 0;
double H_1990 = 0;
V AL_1991 = default;
V D_1992 = default;
W_1988 = 60D;
DZ_1989 = 40D;
H_1990 = 66D;
AL_1991 = ((V)("#3a3d42"));
D_1992 = NewObj(3).Put("w", ((V)(130D))).Put("d", ((V)(90D))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-16D)))).Put("z", ((V)(4D))).Put("h", ((V)(14D))).V, NewObj(3).Put("x", ((V)(14D))).Put("z", ((V)(4D))).Put("h", ((V)(14D))).V)).V;
Set(D_1992, "build", Fn((V _arrowThis2000, int _argc1993, V P_1999, V _a1996, V _a1997, V _a1998, V[] _rest1994) => {
V o_2001 = default;
o_2001 = Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(((2D * W_1988) + 8D))), ((V)(1.4)), ((V)(((2D * DZ_1989) + 8D))), ((V)("#cfc7b6")), Call(cer_31, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Invoke(Arr(Arr(((V)((-W_1988))), ((V)((-DZ_1989)))), Arr(((V)(W_1988)), ((V)((-DZ_1989)))), Arr(((V)((-W_1988))), ((V)(DZ_1989))), Arr(((V)(W_1988)), ((V)(DZ_1989)))), "forEach", Fn((V _arrowThis2013, int _argc2002, V _a2004, V _a2005, V _a2006, V _a2007, V[] _rest2003) => {
V x_2010 = default;
V z_2012 = default;
{ V _t2008 = ListOf(_a2004);
{ V _t2009 = GetIdx(_t2008, 0D);
x_2010 = _t2009; }
{ V _t2011 = GetIdx(_t2008, 1D);
z_2012 = _t2011; }
}
return Invoke(o_2001, "push", Call(box_12, V.Undef, x_2010, ((V)(1.4)), z_2012, ((V)(5D)), ((V)(H_1990)), ((V)(5D)), AL_1991, Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
}, 1, "", true));
Invoke(o_2001, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(H_1990)), ((V)(DZ_1989)), ((V)(((2D * W_1988) + 5D))), ((V)(7D)), ((V)(5D)), AL_1991, Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(H_1990)), ((V)((-DZ_1989))), ((V)(((2D * W_1988) + 5D))), ((V)(7D)), ((V)(5D)), AL_1991, Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)((-W_1988))), ((V)(H_1990)), ((V)(0D)), ((V)(5D)), ((V)(7D)), ((V)((2D * DZ_1989))), AL_1991, Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)(W_1988)), ((V)(H_1990)), ((V)(0D)), ((V)(5D)), ((V)(7D)), ((V)((2D * DZ_1989))), AL_1991, Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
Invoke(o_2001, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(1.4)), ((V)((-14D))), ((V)(82D)), ((V)(7D)), ((V)(28D)), ((V)("#3a3d42")), Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((-42D))), ((V)(1.4)), ((V)((-14D))), ((V)(6D)), ((V)(17D)), ((V)(28D)), ((V)("#3a3d42")), Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(42D)), ((V)(1.4)), ((V)((-14D))), ((V)(6D)), ((V)(17D)), ((V)(28D)), ((V)("#3a3d42")), Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(1.4)), ((V)((-27D))), ((V)(90D)), ((V)(22D)), ((V)(4D)), ((V)("#3a3d42")), Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Invoke(K_10, "cush", ((V)((-19.6))), ((V)(8.4)), ((V)((-12D))), ((V)(38D)), ((V)(6D)), ((V)(24D)), ((V)("#ece6d8")), Call(fb_59, V.Undef, NewObj(0).V)), Invoke(K_10, "cush", ((V)(19.6)), ((V)(8.4)), ((V)((-12D))), ((V)(38D)), ((V)(6D)), ((V)(24D)), ((V)("#ece6d8")), Call(fb_59, V.Undef, NewObj(0).V)), Invoke(K_10, "cush", ((V)((-19.6))), ((V)(14D)), ((V)((-23D))), ((V)(38D)), ((V)(14D)), ((V)(6D)), ((V)("#ece6d8")), Call(fb_59, V.Undef, NewObj(0).V)), Invoke(K_10, "cush", ((V)(19.6)), ((V)(14D)), ((V)((-23D))), ((V)(38D)), ((V)(14D)), ((V)(6D)), ((V)("#ece6d8")), Call(fb_59, V.Undef, NewObj(0).V)), Invoke(K_10, "cush", ((V)((-26D))), ((V)(14D)), ((V)((-18D))), ((V)(12D)), ((V)(10D)), ((V)(5D)), ((V)("#3f6a8a")), Call(fb_59, V.Undef, NewObj(0).V)), Invoke(K_10, "cush", ((V)(26D)), ((V)(14D)), ((V)((-18D))), ((V)(12D)), ((V)(10D)), ((V)(5D)), ((V)("#c8a45a")), Call(fb_59, V.Undef, NewObj(0).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(1.4)), ((V)(18D)), ((V)(34D)), ((V)(11D)), ((V)(18D)), ((V)("#8a5a34")), Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
return o_2001;
return default;
}, 1, "", true));
Set(D_1992, "fx", Fn((V _arrowThis2021, int _argc2014, V c_2020, V _a2017, V _a2018, V _a2019, V[] _rest2015) => {
V p_2022 = default;
V k_2023 = default;
JsStrBuf f_2024 = null;
JsStrBuf un_2025 = null;
double n_2026 = 0;
p_2022 = Get(c_2020, "p");
k_2023 = Get(c_2020, "k");
f_2024 = new JsStrBuf("");
un_2025 = new JsStrBuf("");
f_2024.S(string.Concat("<clipPath id=\"cb8\"><path d=\"", ToStr(Call(quad_42, V.Undef, p_2022, Arr(((V)(((-W_1988) + 2.5))), ((V)((H_1990 + 7D))), ((V)(((-DZ_1989) + 2.5)))), Arr(((V)((W_1988 - 2.5))), ((V)((H_1990 + 7D))), ((V)(((-DZ_1989) + 2.5)))), Arr(((V)((W_1988 - 2.5))), ((V)((H_1990 + 7D))), ((V)((DZ_1989 - 2.5)))), Arr(((V)(((-W_1988) + 2.5))), ((V)((H_1990 + 7D))), ((V)((DZ_1989 - 2.5)))))), "\"/></clipPath><g clip-path=\"url(#cb8)\">"));
n_2026 = 16D;
Call(rep_19, V.Undef, ((V)(n_2026)), Fn((V _arrowThis2034, int _argc2027, V i_2033, V _a2030, V _a2031, V _a2032, V[] _rest2028) => {
double x_2035 = 0;
V A_2036 = default;
V Bv_2037 = default;
V q_2038 = default;
V r_2039 = default;
V sh_2040 = default;
x_2035 = (((-W_1988) + 4D) + ((ToNum(i_2033) * ((2D * W_1988) - 8D)) / (n_2026 - 1D)));
A_2036 = Arr(((V)((x_2035 - 2.6))), ((V)((H_1990 + 5.4))));
Bv_2037 = Arr(((V)((x_2035 + 2.6))), ((V)((H_1990 + 5.4))));
q_2038 = Fn((V _arrowThis2049, int _argc2041, V dx_2047, V dy_2048, V _a2045, V _a2046, V[] _rest2042) => {
return Call(P2_22, V.Undef, Call(p_2022, V.Undef, Add(((V)(x_2035)), dx_2047), Add(((V)((H_1990 + 5.4))), dy_2048), ((V)(((-DZ_1989) + 2D)))));
}, 2, "", true);
r_2039 = Fn((V _arrowThis2058, int _argc2050, V dx_2056, V dy_2057, V _a2054, V _a2055, V[] _rest2051) => {
return Call(P2_22, V.Undef, Call(p_2022, V.Undef, Add(((V)(x_2035)), dx_2056), Add(((V)((H_1990 + 5.4))), dy_2057), ((V)((DZ_1989 - 2D)))));
}, 2, "", true);
sh_2040 = Fn((V _arrowThis2066, int _argc2059, V t_2065, V _a2062, V _a2063, V _a2064, V[] _rest2060) => {
return ((V)(string.Concat("M", ToStr(Call(q_2038, V.Undef, ((V)(((-3.2) * ToNum(t_2065)))), ((V)((1.6 * (1D - ToNum(t_2065))))))), "L", ToStr(Call(r_2039, V.Undef, ((V)(((-3.2) * ToNum(t_2065)))), ((V)((1.6 * (1D - ToNum(t_2065))))))), "L", ToStr(Call(r_2039, V.Undef, ((V)((3.2 * ToNum(t_2065)))), ((V)(((-1.6) * (1D - ToNum(t_2065))))))), "L", ToStr(Call(q_2038, V.Undef, ((V)((3.2 * ToNum(t_2065)))), ((V)(((-1.6) * (1D - ToNum(t_2065))))))), "Z")));
}, 1, "", true);
_ = A_2036;
_ = Bv_2037;
f_2024.S(string.Concat("<path d=\"", ToStr(Call(sh_2040, V.Undef, ((V)(1D)))), "\" fill=\"#e2e4e8\" stroke=\"#6a6e76\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.3 * ToNum(k_2023)))))), "\"><animate attributeName=\"d\" values=\"", ToStr(Call(sh_2040, V.Undef, ((V)(1D)))), ";", ToStr(Call(sh_2040, V.Undef, ((V)(1D)))), ";", ToStr(Call(sh_2040, V.Undef, ((V)(0.18)))), ";", ToStr(Call(sh_2040, V.Undef, ((V)(0.18)))), ";", ToStr(Call(sh_2040, V.Undef, ((V)(1D)))), "\" keyTimes=\"0;0.35;0.5;0.85;1\" dur=\"14s\" repeatCount=\"indefinite\"/></path>"));
return default;
}, 1, "", true));
f_2024.S("</g>");
f_2024.S(string.Concat("<path d=\"M", ToStr(Call(P2_22, V.Undef, Call(p_2022, V.Undef, ((V)(((-W_1988) + 3D))), ((V)((H_1990 + 0.4))), ((V)((DZ_1989 - 2.4)))))), "L", ToStr(Call(P2_22, V.Undef, Call(p_2022, V.Undef, ((V)((W_1988 - 3D))), ((V)((H_1990 + 0.4))), ((V)((DZ_1989 - 2.4)))))), "\" stroke=\"#fff2c8\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.9 * ToNum(k_2023)))))), "\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.7;1;0.7")), ((V)(3D)))), "</path>"));
un_2025.V(Call(glowE_52, V.Undef, p_2022, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(50D)), ((V)(34D)), ((V)("#fff2c8")), ((V)(0.18))));
return NewObj(4).Put("defs", FDEF_50).Put("under", ((V)(un_2025.Str))).Put("front", ((V)(f_2024.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2022, V.Undef, ((V)(((-W_1988) - 6D))), ((V)(0D)), ((V)(((-DZ_1989) - 6D)))), Call(p_2022, V.Undef, ((V)((W_1988 + 6D))), ((V)(0D)), ((V)((DZ_1989 + 6D)))), Call(p_2022, V.Undef, ((V)(((-W_1988) - 6D))), ((V)(0D)), ((V)((DZ_1989 + 6D)))), Call(p_2022, V.Undef, ((V)((W_1988 + 6D))), ((V)(0D)), ((V)(((-DZ_1989) - 6D)))), Call(p_2022, V.Undef, ((V)(0D)), ((V)((H_1990 + 10D))), ((V)((-DZ_1989)))), Call(p_2022, V.Undef, ((V)(0D)), ((V)((H_1990 + 10D))), ((V)(DZ_1989)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1992;
return default;
}, 1, "", true));
Set(N_54, "sail8", Fn((V _arrowThis2074, int _argc2067, V S_2073, V _a2070, V _a2071, V _a2072, V[] _rest2068) => {
V PO_2075 = default;
V WD_2076 = default;
V D_2077 = default;
PO_2075 = Arr(Arr(((V)((-52D))), ((V)((-28D))), ((V)(74D))), Arr(((V)(50D)), ((V)((-34D))), ((V)(66D))), Arr(((V)(10D)), ((V)(36D)), ((V)(56D))));
WD_2076 = ((V)("#9a6a3c"));
D_2077 = NewObj(3).Put("w", ((V)(120D))).Put("d", ((V)(90D))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-6D)))).Put("z", ((V)(0D))).Put("h", ((V)(0D))).V)).V;
Set(D_2077, "build", Fn((V _arrowThis2085, int _argc2078, V P_2084, V _a2081, V _a2082, V _a2083, V[] _rest2079) => {
return Invoke(Invoke(PO_2075, "map", Fn((V _arrowThis2111, int _argc2098, V _a2100, V _a2101, V _a2102, V _a2103, V[] _rest2099) => {
V x_2106 = default;
V z_2108 = default;
V h_2110 = default;
{ V _t2104 = ListOf(_a2100);
{ V _t2105 = GetIdx(_t2104, 0D);
x_2106 = _t2105; }
{ V _t2107 = GetIdx(_t2104, 1D);
z_2108 = _t2107; }
{ V _t2109 = GetIdx(_t2104, 2D);
h_2110 = _t2109; }
}
return Call(box_12, V.Undef, x_2106, ((V)(0D)), z_2108, ((V)(5D)), h_2110, ((V)(5D)), WD_2076, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V));
}, 1, "", true)), "concat", Invoke(PO_2075, "map", Fn((V _arrowThis2097, int _argc2086, V _a2088, V _a2089, V _a2090, V _a2091, V[] _rest2087) => {
V x_2094 = default;
V z_2096 = default;
{ V _t2092 = ListOf(_a2088);
{ V _t2093 = GetIdx(_t2092, 0D);
x_2094 = _t2093; }
{ V _t2095 = GetIdx(_t2092, 1D);
z_2096 = _t2095; }
}
return Call(cyl_13, V.Undef, x_2094, ((V)(0D)), z_2096, ((V)(5.6)), ((V)(2D)), ((V)("#7a7468")), Call(pt_32, V.Undef, NewObj(1).Put("n", ((V)(10D))).V));
}, 1, "", true)));
}, 1, "", true));
Set(D_2077, "fx", Fn((V _arrowThis2119, int _argc2112, V c_2118, V _a2115, V _a2116, V _a2117, V[] _rest2113) => {
V p_2120 = default;
V k_2121 = default;
JsStrBuf f_2122 = null;
V C_2123 = default;
V mid_2124 = default;
V cen_2125 = default;
V sh_2126 = default;
V s0_2127 = default;
V cc_2128 = default;
p_2120 = Get(c_2118, "p");
k_2121 = Get(c_2118, "k");
f_2122 = new JsStrBuf("");
C_2123 = Invoke(PO_2075, "map", Fn((V _arrowThis2142, int _argc2129, V _a2131, V _a2132, V _a2133, V _a2134, V[] _rest2130) => {
V x_2137 = default;
V z_2139 = default;
V h_2141 = default;
{ V _t2135 = ListOf(_a2131);
{ V _t2136 = GetIdx(_t2135, 0D);
x_2137 = _t2136; }
{ V _t2138 = GetIdx(_t2135, 1D);
z_2139 = _t2138; }
{ V _t2140 = GetIdx(_t2135, 2D);
h_2141 = _t2140; }
}
return Arr(((V)((ToNum(x_2137) * 0.9))), ((V)((ToNum(h_2141) - 3D))), ((V)((ToNum(z_2139) * 0.9))));
}, 1, "", true));
mid_2124 = Fn((V _arrowThis2152, int _argc2143, V a_2149, V b_2150, V s_2151, V _a2148, V[] _rest2144) => {
return Arr(((V)(((ToNum(Add(GetIdx(a_2149, 0D), GetIdx(b_2150, 0D))) / 2D) * ToNum(s_2151)))), ((V)(((ToNum(Add(GetIdx(a_2149, 1D), GetIdx(b_2150, 1D))) / 2D) + 2D))), ((V)(((ToNum(Add(GetIdx(a_2149, 2D), GetIdx(b_2150, 2D))) / 2D) * ToNum(s_2151)))));
}, 3, "", true);
cen_2125 = Arr(((V)(0D)), ((V)(58D)), ((V)((-6D))));
sh_2126 = Fn((V _arrowThis2160, int _argc2153, V bl_2159, V _a2156, V _a2157, V _a2158, V[] _rest2154) => {
V d_2161 = default;
d_2161 = Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis2169, int _argc2162, V i_2168, V _a2165, V _a2166, V _a2167, V[] _rest2163) => {
V a_2170 = default;
V b_2171 = default;
V m_2172 = default;
a_2170 = GetK(C_2123, i_2168);
b_2171 = GetIdx(C_2123, (ToNum(Add(i_2168, ((V)(1D)))) % 3D));
m_2172 = Call(mid_2124, V.Undef, a_2170, b_2171, ((V)(0.8)));
return ((V)(string.Concat(ToStr(Call(P2_22, V.Undef, CallSpread(p_2120, V.Undef, new ArrBuilder().Spread(a_2170).V))), "Q", ToStr(Call(P2_22, V.Undef, Call(p_2120, V.Undef, GetIdx(m_2172, 0D), GetIdx(m_2172, 1D), GetIdx(m_2172, 2D)))), " ")));
return default;
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S("M").V(GetIdx(d_2161, 0D)).V(Call(P2_22, V.Undef, CallSpread(p_2120, V.Undef, new ArrBuilder().Spread(GetIdx(C_2123, 1D)).V))).S("Q").V(Call(P2_22, V.Undef, CallSpread(p_2120, V.Undef, new ArrBuilder().Spread(Call(mid_2124, V.Undef, GetIdx(C_2123, 1D), GetIdx(C_2123, 2D), ((V)(0.8)))).V))).S(" ").V(Call(P2_22, V.Undef, CallSpread(p_2120, V.Undef, new ArrBuilder().Spread(GetIdx(C_2123, 2D)).V))).S("Q").V(Call(P2_22, V.Undef, CallSpread(p_2120, V.Undef, new ArrBuilder().Spread(Call(mid_2124, V.Undef, GetIdx(C_2123, 2D), GetIdx(C_2123, 0D), ((V)(0.8)))).V))).S(" ").V(Call(P2_22, V.Undef, CallSpread(p_2120, V.Undef, new ArrBuilder().Spread(GetIdx(C_2123, 0D)).V))).S("Z").End()));
_ = bl_2159;
return default;
}, 1, "", true);
s0_2127 = Call(sh_2126, V.Undef);
cc_2128 = CallSpread(p_2120, V.Undef, new ArrBuilder().Spread(cen_2125).V);
f_2122.S(string.Concat("<g>", ToStr(Call(atV_34, V.Undef, ((V)("translate")), Arr(((V)("0 0")), ((V)(string.Concat("0 ", ToStr(Call(f1_18, V.Undef, ((V)(((-1.4) * ToNum(k_2121))))))))), ((V)("0 0"))), ((V)(3.6)))), "<path d=\"", ToStr(s0_2127), "\" fill=\"#f6f0e2\" stroke=\"#b8ad96\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.5 * ToNum(k_2121)))))), "\"/><path d=\"", ToStr(s0_2127), "\" fill=\"url(#sl8)\"/><circle cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(cc_2128, 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(cc_2128, 1D))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((30D * ToNum(k_2121)))))), "\" fill=\"#ffffff\" opacity=\"0.18\"/></g>"));
Invoke(PO_2075, "forEach", Fn((V _arrowThis2187, int _argc2173, V _a2175, V i_2179, V _a2177, V _a2178, V[] _rest2174) => {
V a_2188 = default;
V b_2189 = default;
V x_2182 = default;
V z_2184 = default;
V h_2186 = default;
{ V _t2180 = ListOf(_a2175);
{ V _t2181 = GetIdx(_t2180, 0D);
x_2182 = _t2181; }
{ V _t2183 = GetIdx(_t2180, 1D);
z_2184 = _t2183; }
{ V _t2185 = GetIdx(_t2180, 2D);
h_2186 = _t2185; }
}
a_2188 = GetK(C_2123, i_2179);
b_2189 = Arr(x_2182, ((V)((ToNum(h_2186) - 1D))), z_2184);
f_2122.V(Call(tube_45, V.Undef, Arr(CallSpread(p_2120, V.Undef, new ArrBuilder().Spread(a_2188).V), CallSpread(p_2120, V.Undef, new ArrBuilder().Spread(b_2189).V)), ((V)(0.7)), k_2121, ((V)("#d5dde2")), ((V)("#ffffff")), ((V)("#5a5e66")))).S(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, GetIdx(CallSpread(p_2120, V.Undef, new ArrBuilder().Spread(a_2188).V), 0D))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, GetIdx(CallSpread(p_2120, V.Undef, new ArrBuilder().Spread(a_2188).V), 1D))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)((1.4 * ToNum(k_2121)))))), "\" fill=\"none\" stroke=\"#9aa1ad\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((0.6 * ToNum(k_2121)))))), "\"/>"));
return default;
}, 2, "", true));
return NewObj(3).Put("defs", Call(L_38, V.Undef, ((V)("sl8")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0.25))), Arr(((V)(0.6)), ((V)("#000000")), ((V)(0D))), Arr(((V)(1D)), ((V)("#000000")), ((V)(0.18)))), ((V)("x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"")))).Put("front", ((V)(f_2122.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2120, V.Undef, ((V)((-58D))), ((V)(0D)), ((V)((-34D)))), Call(p_2120, V.Undef, ((V)(58D)), ((V)(0D)), ((V)(40D))), Call(p_2120, V.Undef, ((V)((-58D))), ((V)(80D)), ((V)((-34D)))), Call(p_2120, V.Undef, ((V)(56D)), ((V)(72D)), ((V)((-40D)))), Call(p_2120, V.Undef, ((V)(12D)), ((V)(0D)), ((V)(42D))), Call(p_2120, V.Undef, ((V)(12D)), ((V)(60D)), ((V)(42D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2077;
return default;
}, 1, "", true));
Set(N_54, "wisteria8", Fn((V _arrowThis2197, int _argc2190, V S_2196, V _a2193, V _a2194, V _a2195, V[] _rest2191) => {
double W_2198 = 0;
double DZ_2199 = 0;
double H_2200 = 0;
V CED_2201 = default;
V CED2_2202 = default;
V D_2203 = default;
W_2198 = 54D;
DZ_2199 = 34D;
H_2200 = 70D;
CED_2201 = ((V)("#a8683a"));
CED2_2202 = ((V)("#c08050"));
D_2203 = NewObj(3).Put("w", ((V)(130D))).Put("d", ((V)(90D))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-12D)))).Put("z", ((V)(0D))).Put("h", ((V)(14D))).V, NewObj(3).Put("x", ((V)(12D))).Put("z", ((V)(0D))).Put("h", ((V)(14D))).V)).V;
Set(D_2203, "build", Fn((V _arrowThis2211, int _argc2204, V P_2210, V _a2207, V _a2208, V _a2209, V[] _rest2205) => {
V o_2212 = default;
o_2212 = Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(((2D * W_2198) + 10D))), ((V)(1.2)), ((V)(((2D * DZ_2199) + 10D))), ((V)("#d8ccb0")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Invoke(Arr(Arr(((V)((-W_2198))), ((V)((-DZ_2199)))), Arr(((V)(W_2198)), ((V)((-DZ_2199)))), Arr(((V)((-W_2198))), ((V)(DZ_2199))), Arr(((V)(W_2198)), ((V)(DZ_2199)))), "forEach", Fn((V _arrowThis2224, int _argc2213, V _a2215, V _a2216, V _a2217, V _a2218, V[] _rest2214) => {
V x_2221 = default;
V z_2223 = default;
{ V _t2219 = ListOf(_a2215);
{ V _t2220 = GetIdx(_t2219, 0D);
x_2221 = _t2220; }
{ V _t2222 = GetIdx(_t2219, 1D);
z_2223 = _t2222; }
}
return Invoke(o_2212, "push", Call(box_12, V.Undef, x_2221, ((V)(1.2)), z_2223, ((V)(6D)), ((V)(H_2200)), ((V)(6D)), CED_2201, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, x_2221, ((V)(1.2)), z_2223, ((V)(8D)), ((V)(6D)), ((V)(8D)), CED2_2202, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
}, 1, "", true));
Invoke(o_2212, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(H_2200)), ((V)((-DZ_2199))), ((V)(((2D * W_2198) + 20D))), ((V)(7D)), ((V)(4D)), CED2_2202, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(H_2200)), ((V)(DZ_2199)), ((V)(((2D * W_2198) + 20D))), ((V)(7D)), ((V)(4D)), CED2_2202, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
Call(rep_19, V.Undef, ((V)(7D)), Fn((V _arrowThis2232, int _argc2225, V i_2231, V _a2228, V _a2229, V _a2230, V[] _rest2226) => {
return Invoke(o_2212, "push", Call(box_12, V.Undef, ((V)(((-W_2198) + (ToNum(i_2231) * ((2D * W_2198) / 6D))))), ((V)((H_2200 + 7D))), ((V)(0D)), ((V)(3D)), ((V)(5D)), ((V)(((2D * DZ_2199) + 18D))), CED_2201, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
}, 1, "", true));
Invoke(o_2212, "push", Invoke(K_10, "cush", ((V)(0D)), ((V)(1.2)), ((V)((-6D))), ((V)(54D)), ((V)(12D)), ((V)(20D)), ((V)("#e8e2d4")), Call(fb_59, V.Undef, NewObj(0).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(1.2)), ((V)(16D)), ((V)(26D)), ((V)(10D)), ((V)(14D)), ((V)("#8a8478")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
return o_2212;
return default;
}, 1, "", true));
Set(D_2203, "fx", Fn((V _arrowThis2240, int _argc2233, V c_2239, V _a2236, V _a2237, V _a2238, V[] _rest2234) => {
V p_2241 = default;
V k_2242 = default;
JsStrBuf f_2243 = null;
V bk_2244 = default;
V R_2245 = default;
JsStrBuf lv_2246 = null;
JsStrBuf rc_2247 = null;
p_2241 = Get(c_2239, "p");
k_2242 = Get(c_2239, "k");
f_2243 = new JsStrBuf("");
bk_2244 = ((V)(""));
R_2245 = Call(rng_20, V.Undef, ((V)("wis")));
lv_2246 = new JsStrBuf("");
Call(rep_19, V.Undef, ((V)(70D)), Fn((V _arrowThis2255, int _argc2248, V i_2254, V _a2251, V _a2252, V _a2253, V[] _rest2249) => {
double x_2256 = 0;
double z_2257 = 0;
V q_2258 = default;
x_2256 = ((ToNum(Call(R_2245, V.Undef)) - 0.5) * ((2D * W_2198) + 12D));
z_2257 = ((ToNum(Call(R_2245, V.Undef)) - 0.5) * ((2D * DZ_2199) + 14D));
q_2258 = Call(p_2241, V.Undef, ((V)(x_2256)), ((V)(((H_2200 + 12D) + (ToNum(Call(R_2245, V.Undef)) * 2D)))), ((V)(z_2257)));
lv_2246.S(string.Concat("<path d=\"M0 0q2-2.2 4.4-0.4q-2.2 1.8-4.4 0.4Z\" fill=\"", ToStr(GetIdx(Arr(((V)("#4f8a3a")), ((V)("#6aa84a")), ((V)("#3f7a2e"))), (ToNum(i_2254) % 3D))), "\" transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_2258)), ") rotate(", ToStr(Call(f1_18, V.Undef, ((V)((ToNum(Call(R_2245, V.Undef)) * 360D))))), ") scale(", ToStr(Call(n4_21, V.Undef, ((V)((ToNum(k_2242) * 1.2))))), ")\"/>"));
return default;
}, 1, "", true));
rc_2247 = new JsStrBuf("");
Call(rep_19, V.Undef, ((V)(26D)), Fn((V _arrowThis2266, int _argc2259, V i_2265, V _a2262, V _a2263, V _a2264, V[] _rest2260) => {
double x_2267 = 0;
double z_2268 = 0;
V q_2269 = default;
double L0_2270 = 0;
JsStrBuf g_2271 = null;
x_2267 = ((ToNum(Call(R_2245, V.Undef)) - 0.5) * ((2D * W_2198) + 8D));
z_2268 = ((ToNum(Call(R_2245, V.Undef)) - 0.5) * ((2D * DZ_2199) + 8D));
q_2269 = Call(p_2241, V.Undef, ((V)(x_2267)), ((V)((H_2200 + 6D))), ((V)(z_2268)));
L0_2270 = (10D + (ToNum(Call(R_2245, V.Undef)) * 9D));
g_2271 = new JsStrBuf("");
Call(rep_19, V.Undef, ((V)(12D)), Fn((V _arrowThis2279, int _argc2272, V j_2278, V _a2275, V _a2276, V _a2277, V[] _rest2273) => {
double t_2280 = 0;
t_2280 = (ToNum(j_2278) / 11D);
g_2271.S(string.Concat("<circle cx=\"", ToStr(Call(f1_18, V.Undef, ((V)((((ToNum(Call(R_2245, V.Undef)) - 0.5) * 2D) * (1D - t_2280)))))), "\" cy=\"", ToStr(Call(f1_18, V.Undef, ((V)((t_2280 * L0_2270))))), "\" r=\"", ToStr(Call(f1_18, V.Undef, ((V)(((1.5 - t_2280) * 1.3))))), "\" fill=\"", ToStr(GetIdx(Arr(((V)("#b49af0")), ((V)("#9a7ad8")), ((V)("#c8b4f8")), ((V)("#8a6ac8"))), (ToNum(j_2278) % 4D))), "\"/>"));
return default;
}, 1, "", true));
rc_2247.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_2269)), ") scale(", ToStr(Call(n4_21, V.Undef, k_2242)), ")\"><g>", ToStr(Call(atV_34, V.Undef, ((V)("rotate")), Arr(((V)("-5")), ((V)("5")), ((V)("-5"))), ((V)((3D + (ToNum(Call(R_2245, V.Undef)) * 2D)))), ((V)(((-ToNum(Call(R_2245, V.Undef))) * 3D))))), "<path d=\"M0 0V3\" stroke=\"#5a8a3a\" stroke-width=\"0.4\"/>", g_2271.Str, "</g></g>"));
return default;
}, 1, "", true));
Invoke(Arr(Arr(((V)((-W_2198))), ((V)(DZ_2199))), Arr(((V)(W_2198)), ((V)(DZ_2199)))), "forEach", Fn((V _arrowThis2292, int _argc2281, V _a2283, V _a2284, V _a2285, V _a2286, V[] _rest2282) => {
V pts_2293 = default;
V x_2289 = default;
V z_2291 = default;
{ V _t2287 = ListOf(_a2283);
{ V _t2288 = GetIdx(_t2287, 0D);
x_2289 = _t2288; }
{ V _t2290 = GetIdx(_t2287, 1D);
z_2291 = _t2290; }
}
pts_2293 = Call(rep_19, V.Undef, ((V)(16D)), Fn((V _arrowThis2301, int _argc2294, V i_2300, V _a2297, V _a2298, V _a2299, V[] _rest2295) => {
double t_2302 = 0;
double a_2303 = 0;
t_2302 = (ToNum(i_2300) / 15D);
a_2303 = (t_2302 * 8D);
return Call(p_2241, V.Undef, Add(x_2289, ((V)((FdLibm.Cos(a_2303) * 3.6)))), ((V)((2D + (t_2302 * (H_2200 - 2D))))), Add(z_2291, ((V)((FdLibm.Sin(a_2303) * 3.6)))));
return default;
}, 1, "", true));
f_2243.S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(pts_2293, "map", P2_22), "join", ((V)("L")))), "\" fill=\"none\" stroke=\"#6a4a2a\" stroke-width=\"", ToStr(Call(f1_18, V.Undef, ((V)((1D * ToNum(k_2242)))))), "\"/>")).V(Invoke(Invoke(Invoke(pts_2293, "filter", Fn((V _arrowThis2320, int _argc2312, V q_2318, V i_2319, V _a2316, V _a2317, V[] _rest2313) => {
return (((ToNum(i_2319) % 3D) == 1D) ? V.True : V.False);
}, 2, "", true)), "map", Fn((V _arrowThis2311, int _argc2304, V q_2310, V _a2307, V _a2308, V _a2309, V[] _rest2305) => {
return ((V)(string.Concat("<path d=\"M0 0q2-2 4 0q-2 1.6-4 0Z\" fill=\"#5a9a44\" transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_2310)), ") scale(", ToStr(Call(n4_21, V.Undef, k_2242)), ")\"/>")));
}, 1, "", true)), "join", ((V)(""))));
return default;
}, 1, "", true));
f_2243.S(lv_2246.Str).S(rc_2247.Str);
return NewObj(4).Put("defs", ((V)(""))).Put("back", bk_2244).Put("front", ((V)(f_2243.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2241, V.Undef, ((V)(((-W_2198) - 12D))), ((V)(0D)), ((V)(((-DZ_2199) - 12D)))), Call(p_2241, V.Undef, ((V)((W_2198 + 12D))), ((V)(0D)), ((V)((DZ_2199 + 12D)))), Call(p_2241, V.Undef, ((V)(((-W_2198) - 12D))), ((V)((H_2200 + 16D))), ((V)((DZ_2199 + 12D)))), Call(p_2241, V.Undef, ((V)((W_2198 + 12D))), ((V)((H_2200 + 16D))), ((V)(((-DZ_2199) - 12D)))), Call(p_2241, V.Undef, ((V)(((-W_2198) - 12D))), ((V)(0D)), ((V)((DZ_2199 + 12D)))), Call(p_2241, V.Undef, ((V)((W_2198 + 12D))), ((V)(0D)), ((V)(((-DZ_2199) - 12D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2203;
return default;
}, 1, "", true));
Set(N_54, "shed8", Fn((V _arrowThis2328, int _argc2321, V S_2327, V _a2324, V _a2325, V _a2326, V[] _rest2322) => {
double W_2329 = 0;
double DZ_2330 = 0;
double HF_2331 = 0;
double HB_2332 = 0;
V CED_2333 = default;
V BK_2334 = default;
V D_2335 = default;
W_2329 = 44D;
DZ_2330 = 30D;
HF_2331 = 70D;
HB_2332 = 58D;
CED_2333 = ((V)("#c08a56"));
BK_2334 = ((V)("#26272b"));
D_2335 = NewObj(2).Put("w", ((V)(110D))).Put("d", ((V)(80D))).V;
Set(D_2335, "build", Fn((V _arrowThis2343, int _argc2336, V P_2342, V _a2339, V _a2340, V _a2341, V[] _rest2337) => {
return new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(((2D * W_2329) + 16D))), ((V)(1.2)), ((V)(((2D * DZ_2330) + 20D))), ((V)("#b9b2a4")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(1.2)), ((V)(0D)), ((V)((2D * W_2329))), ((V)(HB_2332)), ((V)((2D * DZ_2330))), CED_2333, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V))).Add(Call(prism_16, V.Undef, ((V)((-W_2329))), ((V)(W_2329)), Arr(Arr(((V)((-DZ_2330))), ((V)((HB_2332 + 1.2)))), Arr(((V)(DZ_2330)), ((V)((HB_2332 + 1.2)))), Arr(((V)(DZ_2330)), ((V)((HF_2331 + 1.2)))), Arr(((V)((-DZ_2330))), ((V)((HB_2332 + 1.2))))), CED_2333, Call(wd_30, V.Undef, NewObj(0).V))).Add(Call(prism_16, V.Undef, ((V)(((-W_2329) - 3D))), ((V)((W_2329 + 3D))), Arr(Arr(((V)(((-DZ_2330) - 4D))), ((V)((HB_2332 + 1D)))), Arr(((V)((DZ_2330 + 5D))), ((V)((HF_2331 + 1D)))), Arr(((V)((DZ_2330 + 5D))), ((V)((HF_2331 + 3.4)))), Arr(((V)(((-DZ_2330) - 4D))), ((V)((HB_2332 + 3.4))))), BK_2334, Call(mt_29, V.Undef, NewObj(1).Put("shine", ((V)(1D))).V))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(1.2)), ((V)((DZ_2330 + 0.6))), ((V)(((2D * W_2329) + 1D))), ((V)(2.4)), ((V)(1.2)), BK_2334, Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V))).Spread(Invoke(Arr(Arr(((V)((-W_2329))), ((V)((-DZ_2330)))), Arr(((V)(W_2329)), ((V)((-DZ_2330)))), Arr(((V)((-W_2329))), ((V)(DZ_2330))), Arr(((V)(W_2329)), ((V)(DZ_2330)))), "map", Fn((V _arrowThis2355, int _argc2344, V _a2346, V _a2347, V _a2348, V _a2349, V[] _rest2345) => {
V x_2352 = default;
V z_2354 = default;
{ V _t2350 = ListOf(_a2346);
{ V _t2351 = GetIdx(_t2350, 0D);
x_2352 = _t2351; }
{ V _t2353 = GetIdx(_t2350, 1D);
z_2354 = _t2353; }
}
return Call(box_12, V.Undef, x_2352, ((V)(1.2)), z_2354, ((V)(2.4)), ((V)((HB_2332 + (GtN(z_2354, 0D) ? 12D : 0D)))), ((V)(2.4)), BK_2334, Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.3))).V));
}, 1, "", true))).V;
}, 1, "", true));
Set(D_2335, "fx", Fn((V _arrowThis2363, int _argc2356, V c_2362, V _a2359, V _a2360, V _a2361, V[] _rest2357) => {
V p_2364 = default;
V k_2365 = default;
JsStrBuf f_2366 = null;
JsStrBuf fr_2367 = null;
JsStrBuf sd_2368 = null;
p_2364 = Get(c_2362, "p");
k_2365 = Get(c_2362, "k");
f_2366 = new JsStrBuf("");
fr_2367 = new JsStrBuf("");
Call(rep_19, V.Undef, ((V)(22D)), Fn((V _arrowThis2376, int _argc2369, V i_2375, V _a2372, V _a2373, V _a2374, V[] _rest2370) => {
return ((V)(fr_2367.S(string.Concat("<path d=\"M", ToStr(Call(f1_18, V.Undef, ((V)((2D + (ToNum(i_2375) * 4D)))))), " 0V", NumStr((HB_2332 - 1D)), "\" stroke=\"#8a5a30\" stroke-width=\"0.35\" opacity=\"0.7\"/>")).Str));
}, 1, "", true));
fr_2367.S(string.Concat("<rect x=\"", NumStr((W_2329 - 13D)), "\" y=\"", NumStr((HB_2332 - 52D)), "\" width=\"26\" height=\"50\" fill=\"", ToStr(BK_2334), "\"/><rect x=\"", NumStr((W_2329 - 11D)), "\" y=\"", NumStr((HB_2332 - 50D)), "\" width=\"22\" height=\"47\" fill=\"#3a2a1e\"/>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(8D)), Fn((V _arrowThis2384, int _argc2377, V i_2383, V _a2380, V _a2381, V _a2382, V[] _rest2378) => {
return ((V)(string.Concat("<path d=\"M", NumStr((W_2329 - 11D)), " ", NumStr(((HB_2332 - 47D) + (ToNum(i_2383) * 5.6))), "H", NumStr((W_2329 + 11D)), "\" stroke=\"#2a1c12\" stroke-width=\"0.5\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<rect x=\"", NumStr((W_2329 + 6D)), "\" y=\"", NumStr((HB_2332 - 28D)), "\" width=\"1.4\" height=\"9\" rx=\"0.7\" fill=\"#c9d0d6\"/>"));
fr_2367.S(string.Concat("<rect x=\"6\" y=\"", NumStr((HB_2332 - 50D)), "\" width=\"22\" height=\"16\" fill=\"", ToStr(BK_2334), "\"/><rect x=\"7.2\" y=\"", NumStr((HB_2332 - 48.8)), "\" width=\"19.6\" height=\"13.6\" fill=\"url(#sh8g)\"/><path d=\"M17 ", NumStr((HB_2332 - 48.8)), "V", NumStr((HB_2332 - 35.2)), "\" stroke=\"", ToStr(BK_2334), "\" stroke-width=\"1\"/>"));
f_2366.S(string.Concat("<g transform=\"", ToStr(Call(plane_24, V.Undef, p_2364, ((V)((DZ_2330 + 0.05))), ((V)((HB_2332 + 1.2))), ((V)((-W_2329))))), "\">", fr_2367.Str, "</g>"));
sd_2368 = new JsStrBuf("");
Call(rep_19, V.Undef, ((V)(15D)), Fn((V _arrowThis2392, int _argc2385, V i_2391, V _a2388, V _a2389, V _a2390, V[] _rest2386) => {
return ((V)(sd_2368.S(string.Concat("<path d=\"M", ToStr(Call(f1_18, V.Undef, ((V)((2D + (ToNum(i_2391) * 4D)))))), " 0V", NumStr((HB_2332 - 1D)), "\" stroke=\"#8a5a30\" stroke-width=\"0.35\" opacity=\"0.6\"/>")).Str));
}, 1, "", true));
sd_2368.S(string.Concat("<rect x=\"16\" y=\"", NumStr((HB_2332 - 54D)), "\" width=\"30\" height=\"7\" fill=\"", ToStr(BK_2334), "\"/><rect x=\"17\" y=\"", NumStr((HB_2332 - 53D)), "\" width=\"28\" height=\"5\" fill=\"url(#sh8g)\"/>"));
f_2366.S(string.Concat("<g transform=\"", ToStr(Call(planeX_25, V.Undef, p_2364, ((V)((W_2329 + 0.05))), ((V)((HB_2332 + 1.2))), ((V)(DZ_2330)))), "\"><g transform=\"scale(-1 1)\">", sd_2368.Str, "</g></g>"));
{
V q_2393 = default;
q_2393 = Call(p_2364, V.Undef, ((V)((W_2329 - 22D))), ((V)(0D)), ((V)((DZ_2330 + 10D))));
f_2366.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_22, V.Undef, q_2393)), ") scale(", ToStr(Call(n4_21, V.Undef, k_2365)), ")\"><path d=\"M-5 -10H5L4 0H-4Z\" fill=\"#2a2b30\"/><path d=\"M-5 -10H5\" stroke=\"#55575e\" stroke-width=\"0.6\"/>", ToStr(Invoke(Call(rep_19, V.Undef, ((V)(9D)), Fn((V _arrowThis2401, int _argc2394, V j_2400, V _a2397, V _a2398, V _a2399, V[] _rest2395) => {
return ((V)(string.Concat("<path d=\"M0 -10Q", NumStr(((ToNum(j_2400) - 4D) * 1.6)), " -18 ", NumStr(((ToNum(j_2400) - 4D) * 2.6)), " -24\" stroke=\"", (NumTruthy((ToNum(j_2400) % 2D)) ? "#4f8a3a" : "#6aa84a"), "\" stroke-width=\"1.2\" fill=\"none\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g>"));
}
return NewObj(3).Put("defs", Call(L_38, V.Undef, ((V)("sh8g")), Arr(Arr(((V)(0D)), ((V)("#cfe8f2"))), Arr(((V)(0.5)), ((V)("#8fb8cc"))), Arr(((V)(1D)), ((V)("#e8f6fb")))), ((V)("x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\"")))).Put("front", ((V)(f_2366.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2364, V.Undef, ((V)(((-W_2329) - 8D))), ((V)(0D)), ((V)(((-DZ_2330) - 10D)))), Call(p_2364, V.Undef, ((V)((W_2329 + 8D))), ((V)(0D)), ((V)((DZ_2330 + 12D)))), Call(p_2364, V.Undef, ((V)(((-W_2329) - 4D))), ((V)((HB_2332 + 4D))), ((V)(((-DZ_2330) - 4D)))), Call(p_2364, V.Undef, ((V)((W_2329 + 4D))), ((V)((HF_2331 + 4D))), ((V)((DZ_2330 + 6D)))), Call(p_2364, V.Undef, ((V)(((-W_2329) - 8D))), ((V)(0D)), ((V)((DZ_2330 + 12D)))), Call(p_2364, V.Undef, ((V)((W_2329 + 8D))), ((V)(0D)), ((V)(((-DZ_2330) - 10D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2335;
return default;
}, 1, "", true));
GROW_71 = Arr(((V)("Seeds")), ((V)("Sprouts")), ((V)("Leafy")), ((V)("Ripe")), ((V)("Harvest")));
GROWT_72 = Arr(((V)("Planted")), ((V)("Flowering")), ((V)("Green berries")), ((V)("Ripe")), ((V)("Harvest")));
Set(RD_8, "SET8", NewObj(16).Put("YRD-031", NewObj(3).Put("spec", ((V)("lemon8"))).Put("live", ((V)("Swaying"))).Put("note", ((V)("A dwarf Meyer lemon in an oak half-barrel with steel hoops and bark mulch. A lush, rounded canopy of glossy dark leaves (lit from the top, darker underneath) on three branching limbs, hung with bright lemons and white blossoms. It sways gently in the breeze."))).V).Put("YRD-067", NewObj(3).Put("spec", ((V)("parterre8"))).Put("live", ((V)("Roses swaying"))).Put("note", ((V)("A formal French parterre: clipped boxwood borders and knot hedges, cone topiaries, a ring of boxwood balls round a terracotta-potted topiary, four beds of red and pink roses on pale gravel, and a white iron arch at the back covered in climbing roses."))).V).Put("YRD-071", NewObj(3).Put("spec", ((V)("grove8"))).Put("live", ((V)("Swaying"))).Put("note", ((V)("An ancient olive with a gnarled trunk of three braided limbs and an airy silver-green crown dotted with black olives, beside two tall Italian cypresses, with lavender tufts on pale gravel."))).V).Put("YRD-064", NewObj(3).Put("spec", ((V)("zen8"))).Put("live", ((V)("Lanterns glowing"))).Put("note", ((V)("A raked-gravel zen garden: a seated limestone Buddha on a lotus base, two stone pagoda lanterns with warm flickering windows, stepping stones, moss mounds and rocks ringed by raked circles."))).V).Put("YRD-027", NewObj(6).Put("spec", ((V)("cedarBed8"))).Put("kind", ((V)("grow"))).Put("modes", GROW_71).Put("modeLbl", ((V)("STAGE"))).Put("live", ((V)("Tap to grow"))).Put("note", ((V)("A clean cedar raised bed with corner posts and dark soil furrows. Tap to grow: seeds with plant tags, sprouts, leafy plants, then ripe tomatoes on stakes, lettuce heads and carrots. The last tap harvests everything into a basket and the bed starts again."))).V).Put("YRD-047", NewObj(6).Put("spec", ((V)("tower8"))).Put("kind", ((V)("grow"))).Put("modes", GROWT_72).Put("modeLbl", ((V)("STAGE"))).Put("live", ((V)("Tap to grow"))).Put("note", ((V)("Three stacked terracotta pots with planting pockets all round. The strawberry plants grow inside each pocket and their berries hang over the lip; herbs fill the top. Tap to grow: planted, flowering, green berries, ripe red berries, then harvest into a bowl and replant."))).V).Put("YRD-050", NewObj(3).Put("spec", ((V)("eggSwing"))).Put("live", ((V)("Gently swinging"))).Put("note", ((V)("A woven rattan egg chair with a cream seat cushion and back pillow. It hangs from a curved black steel stand by a chain that is fixed to the top of the egg, and swings gently."))).V).Put("YRD-070", NewObj(3).Put("spec", ((V)("porchSwing"))).Put("live", ((V)("Gently swinging"))).Put("note", ((V)("A cedar daybed swing on its own timber frame. Four ropes run from the top beam down to the corners of the bed frame, so the bed hangs from them properly. Soft mattress and throw pillows; it sways slowly. Seats 2."))).V).Put("YRD-013", NewObj(2).Put("spec", ((V)("blockBench"))).Put("note", ((V)("Two stacks of cinderblocks with 2x4 planks laid across for the seat and a two-board backrest screwed to posts that drop into the block holes (the backrest sits in front of its posts). Seats 2."))).V).Put("YRD-033", NewObj(2).Put("spec", ((V)("parkBench"))).Put("note", ((V)("A classic park bench: black cast-iron side frames with scroll detail and warm oak slats for the seat and the curved back (the back slats sit in front of the iron posts). Seats 2."))).V).Put("YRD-006", NewObj(2).Put("spec", ((V)("lawnChairs"))).Put("note", ((V)("A pair of white resin lawn chairs with slatted backs, arms and four legs each. The backrests sit in front of their back legs. Seats 2."))).V).Put("YRD-029", NewObj(3).Put("spec", ((V)("umbrella8"))).Put("live", ((V)("Canopy breathing"))).Put("note", ((V)("A crank-open patio umbrella with a weighted base, a crank handle on the pole, eight ribs and a blue-and-white striped canopy with a scalloped valance."))).V).Put("YRD-069", NewObj(3).Put("spec", ((V)("cabana8"))).Put("live", ((V)("Louvers moving"))).Put("note", ((V)("A charcoal aluminium bioclimatic pergola: the roof louvers tilt open and shut on their motor, a warm LED strip runs round the frame, and inside there is a deep lounge sofa with cushions and a teak coffee table. Seats 2."))).V).Put("YRD-009", NewObj(4).Put("name", ((V)("Tensioned Canvas Shade Sail on Timber Posts"))).Put("spec", ((V)("sail8"))).Put("live", ((V)("Sail breathing"))).Put("note", ((V)("A clean triangular canvas shade sail with curved edges, tensioned from three timber posts by stainless turnbuckles. The sail breathes gently in the breeze."))).V).Put("YRD-049", NewObj(3).Put("spec", ((V)("wisteria8"))).Put("live", ((V)("Wisteria swaying"))).Put("note", ((V)("A cedar pergola with notched rafters, a leafy vine canopy on top and long lilac wisteria racemes hanging down that sway in the breeze. Vines spiral up the front posts. A cushioned bench and stone table sit underneath. Seats 2."))).V).Put("YRD-012", NewObj(3).Put("name", ((V)("Modern Cedar & Black Steel Garden Shed"))).Put("spec", ((V)("shed8"))).Put("note", ((V)("A modern garden shed: vertical cedar cladding, a black steel mono-pitch roof and trim, a black-framed door, glass clerestory windows and a tall planter by the door, on a gravel apron."))).V).V);
edit7_73 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis2409, int _argc2402, V rows_2408, V _a2405, V _a2406, V _a2407, V[] _rest2403) => {
return Invoke(Call(edit7_73, V.Undef, rows_2408), "map", Fn((V _arrowThis2417, int _argc2410, V r_2416, V _a2413, V _a2414, V _a2415, V[] _rest2411) => {
return (Truthy(GetK(Get(RD_8, "SET8"), Get(r_2416, "id"))) ? Object_assign(NewObj(0).V, r_2416, GetK(Get(RD_8, "SET8"), Get(r_2416, "id"))) : r_2416);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H8", NewObj(12).Put("fb", fb_59).Put("kOf", kOf_60).Put("LEAF", LEAF_64).Put("LEAFT", LEAFT_65).Put("sprinkle", sprinkle_66).Put("fruitOn", fruitOn_67).Put("sway", sway_68).Put("flower5", flower5_69).Put("stageOf", stageOf_70).Put("V3", V3_61).Put("LT", LT_62).Put("dot", dot_63).V);
Set(RD_8, "PLUS8", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
