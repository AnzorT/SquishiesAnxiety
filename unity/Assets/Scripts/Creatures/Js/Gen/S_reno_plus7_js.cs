// reno-plus7.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_reno_plus7_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("play", "");
        public static void Run()
        {
Call(Named(boot_370 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V K_10 = default;
V solid_11 = default;
V box_12 = default;
V cyl_13 = default;
V ball_14 = default;
V arcW_15 = default;
V prismZ_16 = default;
V f1_17 = default;
V rep_18 = default;
V rng_19 = default;
V n4_20 = default;
V P2_21 = default;
V mtx_22 = default;
V plane_23 = default;
V planeX_24 = default;
V planeH_25 = default;
V an_26 = default;
V BLUR_27 = default;
V bbOf_28 = default;
V mt_29 = default;
V wd_30 = default;
V cer_31 = default;
V pt_32 = default;
V N_33 = default;
double PI_34 = 0;
V GOLD_35 = default;
V CH_36 = default;
V MARB_37 = default;
V isPlay_38 = default;
V B_39 = default;
V kts_40 = default;
V anV_41 = default;
V atV_42 = default;
V once_43 = default;
V onceT_44 = default;
V st_45 = default;
V G_46 = default;
V L_47 = default;
V lerp_48 = default;
V shade7_49 = default;
V lerpA_50 = default;
V ellPts_51 = default;
V rrPts_52 = default;
V shPts_53 = default;
V lp_54 = default;
V sp_55 = default;
V quad_56 = default;
V planeT_57 = default;
V facing_58 = default;
V aboveFront_59 = default;
V tube_60 = default;
V curve_61 = default;
double UID_62 = 0;
V WP_63 = default;
V C1_64 = default;
V C2_65 = default;
V ripple_66 = default;
V STAR4_67 = default;
V water_68 = default;
V WDEF_69 = default;
V fall_70 = default;
V stream_71 = default;
V FDEF_72 = default;
V FLP_73 = default;
V tongue_74 = default;
V embers_75 = default;
V flames_76 = default;
V smoke_77 = default;
V glowE_78 = default;
V DUCK_79 = default;
V BBALL_80 = default;
V BBDEF_81 = default;
V edit6_82 = default;
if (_self1.IsNullish) _self1 = GlobalV;
water_68 = Fn((V _self83, int _argc84, V p_90, V o_91, V _a88, V _a89, V[] _rest85) => {
V id_92 = default;
V pts_93 = default;
V Lp_94 = default;
V C_95 = default;
V R_96 = default;
V cs_97 = default;
double x0_98 = 0;
double x1_99 = 0;
double z0_100 = 0;
double z1_101 = 0;
double cx_102 = 0;
double cz_103 = 0;
V rect_104 = default;
double t1_105 = 0;
double t2_106 = 0;
double sp1_107 = 0;
V defs_108 = default;
JsStrBuf s_109 = null;
V svg_110 = default;
if (_self83.IsNullish) _self83 = GlobalV;
id_92 = ((V)(JsStrBuf.Begin().S("w7").N(++UID_62).End()));
pts_93 = Call(shPts_53, V.Undef, Get(o_91, "sh"));
Lp_94 = Call(lp_54, V.Undef, pts_93);
C_95 = (Get(o_91, "pal") is var _t111 && Truthy(_t111) ? _t111 : Get(WP_63, "pool"));
R_96 = Call(rng_19, V.Undef, Add(id_92, (Get(o_91, "seed") is var _t112 && Truthy(_t112) ? _t112 : ((V)("")))));
cs_97 = (Get(o_91, "cs") is var _t113 && Truthy(_t113) ? _t113 : ((V)(1D)));
x0_98 = 1000000000D;
x1_99 = (-1000000000D);
z0_100 = 1000000000D;
z1_101 = (-1000000000D);
cx_102 = 0D;
cz_103 = 0D;
Invoke(pts_93, "forEach", Fn((V _arrowThis121, int _argc114, V q_120, V _a117, V _a118, V _a119, V[] _rest115) => {
x0_98 = Min(x0_98, ToNum(GetIdx(q_120, 0D)));
x1_99 = Max(x1_99, ToNum(GetIdx(q_120, 0D)));
z0_100 = Min(z0_100, ToNum(GetIdx(q_120, 1D)));
z1_101 = Max(z1_101, ToNum(GetIdx(q_120, 1D)));
cx_102 = (cx_102 + (ToNum(GetIdx(q_120, 0D)) / ToNum(Get(pts_93, "length"))));
cz_103 = (cz_103 + (ToNum(GetIdx(q_120, 1D)) / ToNum(Get(pts_93, "length"))));
return default;
}, 1, "", true));
rect_104 = Fn((V _arrowThis130, int _argc122, V fill_128, V op_129, V _a126, V _a127, V[] _rest123) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Call(f1_17, V.Undef, ((V)((x0_98 - 2D))))), "\" y=\"", ToStr(Call(f1_17, V.Undef, ((V)((z0_100 - 2D))))), "\" width=\"", ToStr(Call(f1_17, V.Undef, ((V)(((x1_99 - x0_98) + 4D))))), "\" height=\"", ToStr(Call(f1_17, V.Undef, ((V)(((z1_101 - z0_100) + 4D))))), "\" fill=\"", ToStr(fill_128), "\" opacity=\"", ToStr(op_129), "\"/>")));
}, 2, "", true);
t1_105 = (22D * ToNum(cs_97));
t2_106 = (31D * ToNum(cs_97));
sp1_107 = (Truthy(Get(o_91, "slow")) ? 2D : 1D);
defs_108 = ((V)(JsStrBuf.Begin().S(string.Concat("<clipPath id=\"", ToStr(id_92), "L\"><path d=\"", ToStr(Lp_94), "\"/></clipPath>")).S((Truthy(Get(o_91, "rim")) ? string.Concat("<clipPath id=\"", ToStr(id_92), "S\"><path d=\"", ToStr((Truthy(Get(Get(o_91, "rim"), "p3")) ? ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Get(Get(o_91, "rim"), "p3"), "map", Fn((V _arrowThis138, int _argc131, V q_137, V _a134, V _a135, V _a136, V[] _rest132) => {
return Call(P2_21, V.Undef, CallSpread(p_90, V.Undef, new ArrBuilder().Spread(q_137).V));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End())) : Call(sp_55, V.Undef, p_90, Call(shPts_53, V.Undef, (Get(Get(o_91, "rim"), "sh") is var _t139 && Truthy(_t139) ? _t139 : Get(o_91, "sh"))), Get(Get(o_91, "rim"), "y")))), "\"/></clipPath>") : "")).S(string.Concat("<linearGradient id=\"", ToStr(id_92), "g\" gradientUnits=\"userSpaceOnUse\" x1=\"", ToStr(Call(f1_17, V.Undef, ((V)((cx_102 - ((x1_99 - x0_98) * 0.12)))))), "\" y1=\"", ToStr(Call(f1_17, V.Undef, ((V)(z0_100)))), "\" x2=\"", ToStr(Call(f1_17, V.Undef, ((V)((cx_102 + ((x1_99 - x0_98) * 0.12)))))), "\" y2=\"", ToStr(Call(f1_17, V.Undef, ((V)(z1_101)))), "\">", ToStr(Call(st_45, V.Undef, Arr(Arr(((V)(0D)), GetIdx(C_95, 2D), Call(n4_20, V.Undef, ((V)((0.92 * ToNum((Get(o_91, "tint") is var _t140 && Truthy(_t140) ? _t140 : ((V)(1D))))))))), Arr(((V)(0.3)), GetIdx(C_95, 1D), Call(n4_20, V.Undef, ((V)((0.55 * ToNum((Get(o_91, "tint") is var _t141 && Truthy(_t141) ? _t141 : ((V)(1D))))))))), Arr(((V)(1D)), GetIdx(C_95, 0D), Call(n4_20, V.Undef, ((V)((0.4 * ToNum((Get(o_91, "tint") is var _t142 && Truthy(_t142) ? _t142 : ((V)(1D)))))))))))), "</linearGradient>")).S(string.Concat("<pattern id=\"", ToStr(id_92), "a\" width=\"", ToStr(Call(f1_17, V.Undef, ((V)(t1_105)))), "\" height=\"", ToStr(Call(f1_17, V.Undef, ((V)(t1_105)))), "\" patternUnits=\"userSpaceOnUse\"><path d=\"", ToStr(C1_64), "\" transform=\"scale(", ToStr(cs_97), ")\" fill=\"none\" stroke=\"", ToStr(GetIdx(C_95, 3D)), "\" stroke-width=\"0.85\" stroke-linecap=\"round\"/><animateTransform attributeName=\"patternTransform\" type=\"translate\" values=\"0 0;", ToStr(Call(f1_17, V.Undef, ((V)(t1_105)))), " ", ToStr(Call(f1_17, V.Undef, ((V)(t1_105)))), "\" dur=\"", ToStr(Call(n4_20, V.Undef, ((V)((9D * sp1_107))))), "s\" repeatCount=\"indefinite\"/></pattern>")).S(string.Concat("<pattern id=\"", ToStr(id_92), "b\" width=\"", ToStr(Call(f1_17, V.Undef, ((V)(t2_106)))), "\" height=\"", ToStr(Call(f1_17, V.Undef, ((V)(t2_106)))), "\" patternUnits=\"userSpaceOnUse\"><path d=\"", ToStr(C2_65), "\" transform=\"scale(", ToStr(cs_97), ")\" fill=\"none\" stroke=\"", ToStr(GetIdx(C_95, 3D)), "\" stroke-width=\"1.1\" stroke-linecap=\"round\"/><animateTransform attributeName=\"patternTransform\" type=\"translate\" values=\"", ToStr(Call(f1_17, V.Undef, ((V)(t2_106)))), " 0;0 ", ToStr(Call(f1_17, V.Undef, ((V)(t2_106)))), "\" dur=\"", ToStr(Call(n4_20, V.Undef, ((V)((13D * sp1_107))))), "s\" repeatCount=\"indefinite\"/></pattern>")).S(string.Concat("<pattern id=\"", ToStr(id_92), "w\" width=\"16\" height=\"9\" patternUnits=\"userSpaceOnUse\"><path d=\"M1.5 2.6q2.2-1.5 4.4 0M9.5 7q2.2-1.5 4.4 0\" stroke=\"#ffffff\" stroke-width=\"0.55\" stroke-linecap=\"round\" fill=\"none\"/><animateTransform attributeName=\"patternTransform\" type=\"translate\" values=\"0 0;", (Truthy(Get(o_91, "flow")) ? "32 0" : "16 9"), "\" dur=\"", NumStr((Truthy(Get(o_91, "flow")) ? 3D : (7D * sp1_107))), "s\" repeatCount=\"indefinite\"/></pattern>")).S(string.Concat("<pattern id=\"", ToStr(id_92), "v\" width=\"23\" height=\"13\" patternUnits=\"userSpaceOnUse\"><path d=\"M2 4q3-2 6 0M13 10q3-2 6 0\" stroke=\"#ffffff\" stroke-width=\"0.45\" stroke-linecap=\"round\" fill=\"none\"/><animateTransform attributeName=\"patternTransform\" type=\"translate\" values=\"0 0;", (Truthy(Get(o_91, "flow")) ? "46 0" : "-23 13"), "\" dur=\"", NumStr((Truthy(Get(o_91, "flow")) ? 4.2 : (10D * sp1_107))), "s\" repeatCount=\"indefinite\"/></pattern>")).V(Call(BLUR_27, V.Undef, ((V)(JsStrBuf.Begin().V(id_92).S("f").End())), ((V)(1.6)))).End()));
s_109 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<path d=\"", ToStr(Lp_94), "\" fill=\"", ToStr(GetIdx(C_95, 0D)), "\"/>")).V((Get(o_91, "floor") is var _t143 && Truthy(_t143) ? _t143 : ((V)("")))).End());
s_109.V(Add(Add(Call(rect_104, V.Undef, ((V)(string.Concat("url(#", ToStr(id_92), "a)"))), (Get(o_91, "caust").IsNullish ? ((V)(0.42)) : Get(o_91, "caust"))), Call(rect_104, V.Undef, ((V)(string.Concat("url(#", ToStr(id_92), "b)"))), ((V)((ToNum((Get(o_91, "caust").IsNullish ? ((V)(0.42)) : Get(o_91, "caust"))) * 0.7))))), (Get(o_91, "under") is var _t144 && Truthy(_t144) ? _t144 : ((V)("")))));
s_109.S(string.Concat("<path d=\"", ToStr(Lp_94), "\" fill=\"url(#", ToStr(id_92), "g)\"/><path d=\"", ToStr(Lp_94), "\" fill=\"none\" stroke=\"", ToStr(GetIdx(C_95, 2D)), "\" stroke-width=\"", ToStr((Get(o_91, "edge") is var _t145 && Truthy(_t145) ? _t145 : ((V)(5D)))), "\" opacity=\"0.5\" filter=\"url(#", ToStr(id_92), "f)\"/>"));
s_109.V(Add(Call(rect_104, V.Undef, ((V)(string.Concat("url(#", ToStr(id_92), "w)"))), (Get(o_91, "wave").IsNullish ? ((V)(0.5)) : Get(o_91, "wave"))), Call(rect_104, V.Undef, ((V)(string.Concat("url(#", ToStr(id_92), "v)"))), ((V)((ToNum((Get(o_91, "wave").IsNullish ? ((V)(0.5)) : Get(o_91, "wave"))) * 0.75))))));
Invoke((Get(o_91, "rip") is var _t154 && Truthy(_t154) ? _t154 : Arr()), "forEach", Fn((V _arrowThis153, int _argc146, V r_152, V _a149, V _a150, V _a151, V[] _rest147) => {
return ((V)(s_109.V(CallSpread(ripple_66, V.Undef, new ArrBuilder().Spread(r_152).V)).Str));
}, 1, "", true));
Call(rep_18, V.Undef, (Get(o_91, "gl").IsNullish ? ((V)(6D)) : Get(o_91, "gl")), Fn((V _arrowThis162, int _argc155, V i_161, V _a158, V _a159, V _a160, V[] _rest156) => {
V q_163 = default;
double f_164 = 0;
double d_165 = 0;
q_163 = GetIdx(pts_93, System.Math.Floor((ToNum(Call(R_96, V.Undef)) * ToNum(Get(pts_93, "length")))));
f_164 = (System.Math.Sqrt(ToNum(Call(R_96, V.Undef))) * 0.85);
d_165 = (2.2 + (ToNum(Call(R_96, V.Undef)) * 1.6));
s_109.S(string.Concat("<path d=\"", ToStr(STAR4_67), "\" fill=\"#ffffff\" opacity=\"0\" transform=\"translate(", ToStr(Call(f1_17, V.Undef, Call(lerp_48, V.Undef, ((V)(cx_102)), GetIdx(q_163, 0D), ((V)(f_164))))), " ", ToStr(Call(f1_17, V.Undef, Call(lerp_48, V.Undef, ((V)(cz_103)), GetIdx(q_163, 1D), ((V)(f_164))))), ") scale(", ToStr(Call(n4_20, V.Undef, ((V)((0.8 + (ToNum(Call(R_96, V.Undef)) * 0.7)))))), ")\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0;0;1;0")), Call(n4_20, V.Undef, ((V)(d_165))), Call(n4_20, V.Undef, ((V)(((-ToNum(Call(R_96, V.Undef))) * d_165)))))), "</path>"));
return default;
}, 1, "", true));
s_109.V((Get(o_91, "over") is var _t166 && Truthy(_t166) ? _t166 : ((V)("")))).S(string.Concat("<path d=\"", ToStr(Lp_94), "\" fill=\"none\" stroke=\"", ToStr(GetIdx(C_95, 3D)), "\" stroke-width=\"0.7\" opacity=\"0.75\"/>"));
svg_110 = ((V)(string.Concat("<g", (Truthy(Get(o_91, "rim")) ? string.Concat(" clip-path=\"url(#", ToStr(id_92), "S)\"") : ""), "><g transform=\"", ToStr(Call(planeH_25, V.Undef, p_90, Get(o_91, "y"))), "\"><g clip-path=\"url(#", ToStr(id_92), "L)\">", s_109.Str, "</g>", ToStr((Get(o_91, "top") is var _t167 && Truthy(_t167) ? _t167 : ((V)("")))), "</g></g>")));
return NewObj(2).Put("defs", defs_108).Put("svg", svg_110).V;
return default;
}, 2, "water", false);
fall_70 = Fn((V _self168, int _argc169, V p_175, V k_176, V A_177, V Cc_178, V[] _rest170) => {
V a_181 = default;
V c_182 = default;
V b_183 = default;
double n_184 = 0;
JsStrBuf s_185 = null;
V m_186 = default;
V Bt_179 = default;
V o_180 = default;
if (_self168.IsNullish) _self168 = GlobalV;
Bt_179 = (_argc169 > 4 ? _rest170[0] : V.Undef);
o_180 = (_argc169 > 5 ? _rest170[1] : V.Undef);
o_180 = (o_180 is var _t187 && Truthy(_t187) ? _t187 : NewObj(0).V);
a_181 = Invoke(A_177, "map", Fn((V _arrowThis195, int _argc188, V q_194, V _a191, V _a192, V _a193, V[] _rest189) => {
return CallSpread(p_175, V.Undef, new ArrBuilder().Spread(q_194).V);
}, 1, "", true));
c_182 = Invoke(Cc_178, "map", Fn((V _arrowThis203, int _argc196, V q_202, V _a199, V _a200, V _a201, V[] _rest197) => {
return CallSpread(p_175, V.Undef, new ArrBuilder().Spread(q_202).V);
}, 1, "", true));
b_183 = Invoke(Bt_179, "map", Fn((V _arrowThis211, int _argc204, V q_210, V _a207, V _a208, V _a209, V[] _rest205) => {
return CallSpread(p_175, V.Undef, new ArrBuilder().Spread(q_210).V);
}, 1, "", true));
n_184 = (ToNum(Get(a_181, "length")) - 1D);
s_185 = new JsStrBuf(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(a_181, "map", P2_21), "join", ((V)("L")))), "Q", ToStr(Call(P2_21, V.Undef, GetIdx(c_182, n_184))), " ", ToStr(Call(P2_21, V.Undef, GetIdx(b_183, n_184))), "L", ToStr(Invoke(Invoke(Invoke(Invoke(b_183, "slice"), "reverse"), "map", P2_21), "join", ((V)("L")))), "Q", ToStr(Call(P2_21, V.Undef, GetIdx(c_182, 0D))), " ", ToStr(Call(P2_21, V.Undef, GetIdx(a_181, 0D))), "Z\" fill=\"url(#w7fall)\" opacity=\"", ToStr((Get(o_180, "op") is var _t212 && Truthy(_t212) ? _t212 : ((V)(0.8)))), "\"/>"));
m_186 = (Get(o_180, "streaks") is var _t213 && Truthy(_t213) ? _t213 : ((V)(Max(4D, ((n_184 * 2D) + 2D)))));
Call(rep_18, V.Undef, m_186, Fn((V _arrowThis221, int _argc214, V i_220, V _a217, V _a218, V _a219, V[] _rest215) => {
double t_222 = 0;
V A1_223 = default;
V C2_224 = default;
V B1_225 = default;
double len_226 = 0;
t_222 = (ToNum(Add(i_220, ((V)(0.5)))) / ToNum(m_186));
A1_223 = Call(lerpA_50, V.Undef, a_181, ((V)(t_222)));
C2_224 = Call(lerpA_50, V.Undef, c_182, ((V)(t_222)));
B1_225 = Call(lerpA_50, V.Undef, b_183, ((V)(t_222)));
len_226 = (Hypot((ToNum(GetIdx(B1_225, 0D)) - ToNum(GetIdx(A1_223, 0D))), (ToNum(GetIdx(B1_225, 1D)) - ToNum(GetIdx(A1_223, 1D)))) + 1D);
s_185.S(string.Concat("<path d=\"M", ToStr(Call(P2_21, V.Undef, A1_223)), "Q", ToStr(Call(P2_21, V.Undef, C2_224)), " ", ToStr(Call(P2_21, V.Undef, B1_225)), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)(((0.45 + ((ToNum(i_220) % 3D) * 0.22)) * ToNum(k_176)))))), "\" stroke-linecap=\"round\" stroke-dasharray=\"", ToStr(Call(f1_17, V.Undef, ((V)((len_226 * 0.22))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((len_226 * 0.14))))), "\" opacity=\"", ToStr(Call(n4_20, V.Undef, ((V)((0.45 + ((ToNum(i_220) % 2D) * 0.35)))))), "\">", ToStr(Call(an_26, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;-").V(Call(f1_17, V.Undef, ((V)((len_226 * 0.72))))).End())), Call(n4_20, V.Undef, ((V)((0.55 + ((ToNum(i_220) % 4D) * 0.07))))), Call(n4_20, V.Undef, ((V)(((-ToNum(i_220)) * 0.13)))))), "</path>"));
return default;
}, 1, "", true));
if (!SEqN(Get(o_180, "foam"), 0D)) {
Call(rep_18, V.Undef, ((V)(Max(3D, (n_184 + 2D)))), Fn((V _arrowThis234, int _argc227, V i_233, V _a230, V _a231, V _a232, V[] _rest228) => {
V B1_235 = default;
double d_236 = 0;
B1_235 = Call(lerpA_50, V.Undef, b_183, ((V)((ToNum(i_233) / Max(1D, (n_184 + 1D))))));
d_236 = (0.8 + ((ToNum(i_233) % 3D) * 0.2));
s_185.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(B1_235, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(B1_235, 1D))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((2.6 * ToNum(k_176)))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((1.2 * ToNum(k_176)))))), "\" fill=\"#ffffff\" opacity=\"0.8\">", ToStr(Call(an_26, V.Undef, ((V)("rx")), ((V)(JsStrBuf.Begin().V(Call(f1_17, V.Undef, ((V)((1.6 * ToNum(k_176)))))).S(";").V(Call(f1_17, V.Undef, ((V)((3.2 * ToNum(k_176)))))).S(";").V(Call(f1_17, V.Undef, ((V)((1.6 * ToNum(k_176)))))).End())), ((V)(d_236)), ((V)(((-ToNum(i_233)) * 0.3))))), ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.9;0.5;0.9")), ((V)(d_236)), ((V)(((-ToNum(i_233)) * 0.3))))), "</ellipse>"));
return default;
}, 1, "", true));
}
if (!SEqN(Get(o_180, "mist"), 0D)) {
V M_237 = default;
M_237 = Call(lerpA_50, V.Undef, b_183, ((V)(0.5)));
s_185.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(M_237, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(GetIdx(M_237, 1D)) - (3D * ToNum(k_176))))))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum((Get(o_180, "mw") is var _t238 && Truthy(_t238) ? _t238 : ((V)(14D)))) * ToNum(k_176)))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((5D * ToNum(k_176)))))), "\" fill=\"#ffffff\" filter=\"url(#w7m)\" opacity=\"0.5\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.35;0.65;0.35")), ((V)(2.6)))), "</ellipse>"));
}
return ((V)(s_185.Str));
return default;
}, 6, "fall", false);
tongue_74 = Fn((V _self239, int _argc240, V R_246, V h_247, V w_248, V d_249, V[] _rest241) => {
V V_251 = default;
V Ly_252 = default;
V b_250 = default;
if (_self239.IsNullish) _self239 = GlobalV;
b_250 = (_argc240 > 4 ? _rest241[0] : V.Undef);
V_251 = Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis259, int _argc253, V _a255, V _a256, V _a257, V _a258, V[] _rest254) => {
return Arr(((V)((((ToNum(Call(R_246, V.Undef)) - 0.5) * ToNum(w_248)) * 2.4))), ((V)((ToNum(h_247) * (0.74 + (ToNum(Call(R_246, V.Undef)) * 0.38))))));
}, 0, "", true));
Invoke(V_251, "push", GetIdx(V_251, 0D));
Ly_252 = Fn((V _arrowThis269, int _argc260, V sc_266, V f_267, V dy_268, V _a265, V[] _rest261) => {
return ((V)(string.Concat("<path d=\"", ToStr(Call(FLP_73, V.Undef, ((V)((ToNum(GetIdx(GetIdx(V_251, 0D), 0D)) * ToNum(sc_266)))), ((V)((ToNum(GetIdx(GetIdx(V_251, 0D), 1D)) * ToNum(sc_266)))), ((V)((ToNum(w_248) * ToNum(sc_266)))))), "\" fill=\"", ToStr(f_267), "\"", (Truthy(dy_268) ? string.Concat(" transform=\"translate(0 ", ToStr(dy_268), ")\"") : ""), ">", ToStr(Call(anV_41, V.Undef, ((V)("d")), Invoke(V_251, "map", Fn((V _arrowThis277, int _argc270, V v_276, V _a273, V _a274, V _a275, V[] _rest271) => {
return Call(FLP_73, V.Undef, ((V)((ToNum(GetIdx(v_276, 0D)) * ToNum(sc_266)))), ((V)((ToNum(GetIdx(v_276, 1D)) * ToNum(sc_266)))), ((V)((ToNum(w_248) * ToNum(sc_266)))));
}, 1, "", true)), d_249, b_250)), "</path>")));
}, 3, "", true);
return Add(Add(Call(Ly_252, V.Undef, ((V)(1D)), ((V)("url(#f7o)"))), Call(Ly_252, V.Undef, ((V)(0.66)), ((V)("url(#f7m)")), Call(f1_17, V.Undef, ((V)((ToNum(w_248) * 0.1)))))), Call(Ly_252, V.Undef, ((V)(0.36)), ((V)("url(#f7c)")), Call(f1_17, V.Undef, ((V)((ToNum(w_248) * 0.2))))));
return default;
}, 5, "tongue", false);
flames_76 = Fn((V _self278, int _argc279, V q_285, V u_286, V o_287, V _a284, V[] _rest280) => {
V R_288 = default;
V n_289 = default;
V spr_290 = default;
V h_291 = default;
V w_292 = default;
JsStrBuf s_293 = null;
V T_294 = default;
if (_self278.IsNullish) _self278 = GlobalV;
o_287 = (o_287 is var _t295 && Truthy(_t295) ? _t295 : NewObj(0).V);
R_288 = Call(rng_19, V.Undef, (Get(o_287, "seed") is var _t296 && Truthy(_t296) ? _t296 : ((V)("f"))));
n_289 = (Get(o_287, "n") is var _t297 && Truthy(_t297) ? _t297 : ((V)(5D)));
spr_290 = (Get(o_287, "sp").IsNullish ? ((V)(9D)) : Get(o_287, "sp"));
h_291 = (Get(o_287, "h") is var _t298 && Truthy(_t298) ? _t298 : ((V)(16D)));
w_292 = (Get(o_287, "w") is var _t299 && Truthy(_t299) ? _t299 : ((V)(3.6)));
s_293 = new JsStrBuf("");
if (!(Truthy(Get(o_287, "noGlow")))) {
s_293.S(string.Concat("<ellipse cx=\"0\" cy=\"", ToStr(Call(f1_17, V.Undef, ((V)(((-ToNum(h_291)) * 0.35))))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)(((ToNum(spr_290) * 1.2) + 9D))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(h_291) * 0.85))))), "\" fill=\"url(#f7g)\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.7;1;0.78;0.95;0.7")), ((V)(1.3)))), "</ellipse>"));
}
T_294 = Invoke(Call(rep_18, V.Undef, n_289, Fn((V _arrowThis316, int _argc309, V i_315, V _a312, V _a313, V _a314, V[] _rest310) => {
double x_317 = 0;
double c_318 = 0;
x_317 = (SEqN(n_289, 1D) ? 0D : ((((ToNum(i_315) / (ToNum(n_289) - 1D)) - 0.5) * ToNum(spr_290)) * 2D));
c_318 = (1D - (System.Math.Abs(x_317) / ((ToNum(spr_290) * 1.5) + 0.000001)));
return NewObj(3).Put("x", ((V)((x_317 + ((ToNum(Call(R_288, V.Undef)) - 0.5) * 2D))))).Put("hh", ((V)(((ToNum(h_291) * (0.45 + (0.55 * c_318))) * (0.85 + (ToNum(Call(R_288, V.Undef)) * 0.3)))))).Put("ww", ((V)((ToNum(w_292) * (0.72 + (0.38 * c_318)))))).V;
return default;
}, 1, "", true)), "sort", Fn((V _arrowThis308, int _argc300, V a_306, V b_307, V _a304, V _a305, V[] _rest301) => {
return ((V)((ToNum(Get(a_306, "hh")) - ToNum(Get(b_307, "hh")))));
}, 2, "", true));
Invoke(T_294, "forEach", Fn((V _arrowThis326, int _argc319, V t_325, V _a322, V _a323, V _a324, V[] _rest320) => {
return ((V)(s_293.S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_17, V.Undef, Get(t_325, "x"))), " 0)\">", ToStr(Call(tongue_74, V.Undef, R_288, Get(t_325, "hh"), Get(t_325, "ww"), ((V)((0.5 + (ToNum(Call(R_288, V.Undef)) * 0.4)))), ((V)((-ToNum(Call(R_288, V.Undef))))))), "</g>")).Str));
}, 1, "", true));
if (!SEqN(Get(o_287, "emb"), 0D)) {
s_293.V(Call(embers_75, V.Undef, R_288, (Get(o_287, "emb") is var _t327 && Truthy(_t327) ? _t327 : ((V)(4D))), Add(spr_290, ((V)(4D))), h_291));
}
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(P2_21, V.Undef, q_285)), ") scale(", ToStr(Call(n4_20, V.Undef, u_286)), ")\">", s_293.Str, "</g>")));
return default;
}, 3, "flames", false);
smoke_77 = Fn((V _self328, int _argc329, V q_335, V u_336, V o_337, V _a334, V[] _rest330) => {
V R_338 = default;
V n_339 = default;
V H_340 = default;
V col_341 = default;
V op_342 = default;
V d_343 = default;
if (_self328.IsNullish) _self328 = GlobalV;
o_337 = (o_337 is var _t344 && Truthy(_t344) ? _t344 : NewObj(0).V);
R_338 = Call(rng_19, V.Undef, (Get(o_337, "seed") is var _t345 && Truthy(_t345) ? _t345 : ((V)("s"))));
n_339 = (Get(o_337, "n") is var _t346 && Truthy(_t346) ? _t346 : ((V)(5D)));
H_340 = (Get(o_337, "H") is var _t347 && Truthy(_t347) ? _t347 : ((V)(50D)));
col_341 = (Get(o_337, "col") is var _t348 && Truthy(_t348) ? _t348 : ((V)("#8a8784")));
op_342 = (Get(o_337, "op") is var _t349 && Truthy(_t349) ? _t349 : ((V)(0.35)));
d_343 = (Get(o_337, "d") is var _t350 && Truthy(_t350) ? _t350 : ((V)(4.5)));
return ((V)(JsStrBuf.Begin().S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_21, V.Undef, q_335)), ") scale(", ToStr(Call(n4_20, V.Undef, u_336)), ")\" filter=\"url(#f7s)\">")).V(Invoke(Call(rep_18, V.Undef, n_339, Fn((V _arrowThis358, int _argc351, V i_357, V _a354, V _a355, V _a356, V[] _rest352) => {
V b_359 = default;
double dx_360 = 0;
b_359 = Add(((V)((((-ToNum(i_357)) * ToNum(d_343)) / ToNum(n_339)))), (Get(o_337, "b") is var _t361 && Truthy(_t361) ? _t361 : ((V)(0D))));
dx_360 = ((ToNum(Call(R_338, V.Undef)) - 0.3) * ToNum((Get(o_337, "drift") is var _t362 && Truthy(_t362) ? _t362 : ((V)(14D)))));
return ((V)(string.Concat("<circle cx=\"0\" cy=\"0\" r=\"3\" fill=\"", ToStr(col_341), "\" opacity=\"0\"><animate attributeName=\"cx\" values=\"0;", ToStr(Call(f1_17, V.Undef, ((V)((dx_360 * 0.4))))), ";", ToStr(Call(f1_17, V.Undef, ((V)(dx_360)))), "\" dur=\"", ToStr(d_343), "s\"", ToStr(Call(B_39, V.Undef, b_359)), " repeatCount=\"indefinite\"/><animate attributeName=\"cy\" values=\"0;", ToStr(Call(f1_17, V.Undef, ((V)(((-ToNum(H_340)) * 0.5))))), ";", ToStr(Call(f1_17, V.Undef, ((V)((-ToNum(H_340)))))), "\" dur=\"", ToStr(d_343), "s\"", ToStr(Call(B_39, V.Undef, b_359)), " repeatCount=\"indefinite\"/><animate attributeName=\"r\" values=\"", ToStr(Call(f1_17, V.Undef, (Get(o_337, "r0") is var _t363 && Truthy(_t363) ? _t363 : ((V)(2.5))))), ";", ToStr(Call(f1_17, V.Undef, ((V)((ToNum((Get(o_337, "r1") is var _t364 && Truthy(_t364) ? _t364 : ((V)(9D)))) * 0.7))))), ";", ToStr(Call(f1_17, V.Undef, (Get(o_337, "r1") is var _t365 && Truthy(_t365) ? _t365 : ((V)(9D))))), "\" dur=\"", ToStr(d_343), "s\"", ToStr(Call(B_39, V.Undef, b_359)), " repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0;", ToStr(op_342), ";", ToStr(Call(n4_20, V.Undef, ((V)((ToNum(op_342) * 0.55))))), ";0\" dur=\"", ToStr(d_343), "s\"", ToStr(Call(B_39, V.Undef, b_359)), " repeatCount=\"indefinite\"/></circle>")));
return default;
}, 1, "", true)), "join", ((V)("")))).S("</g>").End()));
return default;
}, 3, "smoke", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
if (!(Truthy(((((RD_8 is var _t366 && !Truthy(_t366) ? _t366 : Get(RD_8, "PLUS6")) is var _t367 && !Truthy(_t367) ? _t367 : Get(RD_8, "H3")) is var _t368 && !Truthy(_t368) ? _t368 : X_9) is var _t369 && !Truthy(_t369) ? _t369 : Get(X_9, "K"))))) {
Call(G("setTimeout"), V.Undef, boot_370.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "PLUS7"))) {
return default;
}
K_10 = Get(X_9, "K");
{ V _t371 = K_10;
if (_t371.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t371));
{ V _t372 = Get(_t371, "solid");
solid_11 = _t372; }
{ V _t373 = Get(_t371, "box");
box_12 = _t373; }
{ V _t374 = Get(_t371, "cyl");
cyl_13 = _t374; }
{ V _t375 = Get(_t371, "ball");
ball_14 = _t375; }
{ V _t376 = Get(_t371, "arcW");
arcW_15 = _t376; }
{ V _t377 = Get(_t371, "prismZ");
prismZ_16 = _t377; }
{ V _t378 = Get(_t371, "f1");
f1_17 = _t378; } }
{ V _t379 = Get(RD_8, "H3");
if (_t379.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t379));
{ V _t380 = Get(_t379, "rep");
rep_18 = _t380; }
{ V _t381 = Get(_t379, "rng");
rng_19 = _t381; }
{ V _t382 = Get(_t379, "n4");
n4_20 = _t382; }
{ V _t383 = Get(_t379, "P2");
P2_21 = _t383; }
{ V _t384 = Get(_t379, "mtx");
mtx_22 = _t384; }
{ V _t385 = Get(_t379, "plane");
plane_23 = _t385; }
{ V _t386 = Get(_t379, "planeX");
planeX_24 = _t386; }
{ V _t387 = Get(_t379, "planeH");
planeH_25 = _t387; }
{ V _t388 = Get(_t379, "an");
an_26 = _t388; }
{ V _t389 = Get(_t379, "BLUR");
BLUR_27 = _t389; }
{ V _t390 = Get(_t379, "bbOf");
bbOf_28 = _t390; }
{ V _t391 = Get(_t379, "mt");
mt_29 = _t391; }
{ V _t392 = Get(_t379, "wd");
wd_30 = _t392; }
{ V _t393 = Get(_t379, "cer");
cer_31 = _t393; }
{ V _t394 = Get(_t379, "pt");
pt_32 = _t394; } }
N_33 = Get(RD_8, "N");
PI_34 = System.Math.PI;
GOLD_35 = ((V)("#e2b14a"));
CH_36 = ((V)("#d5dde2"));
MARB_37 = ((V)("#f3efe8"));
isPlay_38 = Fn((V _arrowThis402, int _argc395, V S_401, V _a398, V _a399, V _a400, V[] _rest396) => {
return Invoke(NewRegExp(RX0, "play", ""), "test", (Get(S_401, "st") is var _t403 && Truthy(_t403) ? _t403 : ((V)(""))));
}, 1, "", true);
B_39 = Fn((V _arrowThis411, int _argc404, V b_410, V _a407, V _a408, V _a409, V[] _rest405) => {
return ((V)((Truthy(b_410) ? JsStrBuf.Begin().S(" begin=\"").V(Call(n4_20, V.Undef, b_410)).S("s\"").End() : "")));
}, 1, "", true);
kts_40 = Fn((V _arrowThis419, int _argc412, V n_418, V _a415, V _a416, V _a417, V[] _rest413) => {
return Invoke(Call(rep_18, V.Undef, Add(n_418, ((V)(1D))), Fn((V _arrowThis427, int _argc420, V i_426, V _a423, V _a424, V _a425, V[] _rest421) => {
return Call(n4_20, V.Undef, ((V)((ToNum(i_426) / ToNum(n_418)))));
}, 1, "", true)), "join", ((V)(";")));
}, 1, "", true);
anV_41 = Fn((V _arrowThis438, int _argc428, V a_434, V vals_435, V d_436, V b_437, V[] _rest429) => {
return ((V)(string.Concat("<animate attributeName=\"", ToStr(a_434), "\" values=\"", ToStr(Invoke(vals_435, "join", ((V)(";")))), "\" dur=\"", ToStr(Call(n4_20, V.Undef, d_436)), "s\" calcMode=\"spline\" keyTimes=\"", ToStr(Call(kts_40, V.Undef, ((V)((ToNum(Get(vals_435, "length")) - 1D))))), "\" keySplines=\"", ToStr(Invoke(Call(rep_18, V.Undef, ((V)((ToNum(Get(vals_435, "length")) - 1D))), Fn((V _arrowThis445, int _argc439, V _a441, V _a442, V _a443, V _a444, V[] _rest440) => {
return ((V)("0.45 0 0.55 1"));
}, 0, "", true)), "join", ((V)(";")))), "\"", ToStr(Call(B_39, V.Undef, b_437)), " repeatCount=\"indefinite\"/>")));
}, 4, "", true);
atV_42 = Fn((V _arrowThis456, int _argc446, V type_452, V vals_453, V d_454, V b_455, V[] _rest447) => {
return ((V)(string.Concat("<animateTransform attributeName=\"transform\" type=\"", ToStr(type_452), "\" values=\"", ToStr(Invoke(vals_453, "join", ((V)(";")))), "\" dur=\"", ToStr(Call(n4_20, V.Undef, d_454)), "s\" calcMode=\"spline\" keyTimes=\"", ToStr(Call(kts_40, V.Undef, ((V)((ToNum(Get(vals_453, "length")) - 1D))))), "\" keySplines=\"", ToStr(Invoke(Call(rep_18, V.Undef, ((V)((ToNum(Get(vals_453, "length")) - 1D))), Fn((V _arrowThis463, int _argc457, V _a459, V _a460, V _a461, V _a462, V[] _rest458) => {
return ((V)("0.45 0 0.55 1"));
}, 0, "", true)), "join", ((V)(";")))), "\"", ToStr(Call(B_39, V.Undef, b_455)), " repeatCount=\"indefinite\"/>")));
}, 4, "", true);
once_43 = Fn((V _arrowThis475, int _argc464, V a_470, V vals_471, V kt_472, V d_473, V[] _rest465) => {
V b_474 = default;
b_474 = (_argc464 > 4 ? _rest465[0] : V.Undef);
return ((V)(string.Concat("<animate attributeName=\"", ToStr(a_470), "\" values=\"", ToStr(vals_471), "\" keyTimes=\"", ToStr(kt_472), "\" dur=\"", ToStr(d_473), "s\"", ToStr(Call(B_39, V.Undef, b_474)), " fill=\"freeze\"/>")));
}, 5, "", true);
onceT_44 = Fn((V _arrowThis487, int _argc476, V type_482, V vals_483, V kt_484, V d_485, V[] _rest477) => {
V b_486 = default;
b_486 = (_argc476 > 4 ? _rest477[0] : V.Undef);
return ((V)(string.Concat("<animateTransform attributeName=\"transform\" type=\"", ToStr(type_482), "\" values=\"", ToStr(vals_483), "\" keyTimes=\"", ToStr(kt_484), "\" dur=\"", ToStr(d_485), "s\"", ToStr(Call(B_39, V.Undef, b_486)), " fill=\"freeze\"/>")));
}, 5, "", true);
st_45 = Fn((V _arrowThis495, int _argc488, V s_494, V _a491, V _a492, V _a493, V[] _rest489) => {
return Invoke(Invoke(s_494, "map", Fn((V _arrowThis503, int _argc496, V q_502, V _a499, V _a500, V _a501, V[] _rest497) => {
return ((V)(string.Concat("<stop offset=\"", ToStr(GetIdx(q_502, 0D)), "\" stop-color=\"", ToStr(GetIdx(q_502, 1D)), "\"", (!GetIdx(q_502, 2D).IsNullish ? string.Concat(" stop-opacity=\"", ToStr(GetIdx(q_502, 2D)), "\"") : ""), "/>")));
}, 1, "", true)), "join", ((V)("")));
}, 1, "", true);
G_46 = Fn((V _arrowThis513, int _argc504, V id_510, V s_511, V a_512, V _a509, V[] _rest505) => {
return ((V)(string.Concat("<radialGradient id=\"", ToStr(id_510), "\" ", ToStr((a_512 is var _t514 && Truthy(_t514) ? _t514 : ((V)("cx=\"38%\" cy=\"34%\" r=\"70%\"")))), ">", ToStr(Call(st_45, V.Undef, s_511)), "</radialGradient>")));
}, 3, "", true);
L_47 = Fn((V _arrowThis524, int _argc515, V id_521, V s_522, V a_523, V _a520, V[] _rest516) => {
return ((V)(string.Concat("<linearGradient id=\"", ToStr(id_521), "\" ", ToStr((a_523 is var _t525 && Truthy(_t525) ? _t525 : ((V)("x1=\"0\" y1=\"0\" x2=\"0\" y2=\"1\"")))), ">", ToStr(Call(st_45, V.Undef, s_522)), "</linearGradient>")));
}, 3, "", true);
lerp_48 = Fn((V _arrowThis535, int _argc526, V a_532, V b_533, V t_534, V _a531, V[] _rest527) => {
return Add(a_532, ((V)(((ToNum(b_533) - ToNum(a_532)) * ToNum(t_534)))));
}, 3, "", true);
shade7_49 = Fn((V _arrowThis543, int _argc536, V c_542, V _a539, V _a540, V _a541, V[] _rest537) => {
return (Truthy(Get(K_10, "shade")) ? Invoke(K_10, "shade", c_542, ((V)(0.92))) : c_542);
}, 1, "", true);
lerpA_50 = Fn((V _arrowThis552, int _argc544, V arr_550, V t_551, V _a548, V _a549, V[] _rest545) => {
double f_553 = 0;
double i_554 = 0;
double u_555 = 0;
f_553 = (ToNum(t_551) * (ToNum(Get(arr_550, "length")) - 1D));
i_554 = Min((ToNum(Get(arr_550, "length")) - 2D), Max(0D, System.Math.Floor(f_553)));
u_555 = (f_553 - i_554);
return Invoke(GetIdx(arr_550, i_554), "map", Fn((V _arrowThis564, int _argc556, V v_562, V j_563, V _a560, V _a561, V[] _rest557) => {
return Add(v_562, ((V)(((ToNum(GetK(GetIdx(arr_550, (i_554 + 1D)), j_563)) - ToNum(v_562)) * u_555))));
}, 2, "", true));
return default;
}, 2, "", true);
ellPts_51 = Fn((V _arrowThis578, int _argc565, V cx_571, V cz_572, V rx_573, V rz_574, V[] _rest566) => {
V full_579 = default;
V n_575 = default;
V a0_576 = default;
V a1_577 = default;
n_575 = (_argc565 > 4 ? _rest566[0] : V.Undef);
a0_576 = (_argc565 > 5 ? _rest566[1] : V.Undef);
a1_577 = (_argc565 > 6 ? _rest566[2] : V.Undef);
full_579 = (a1_577.IsNullish ? V.True : V.False);
a0_576 = (a0_576 is var _t580 && Truthy(_t580) ? _t580 : ((V)(0D)));
if (Truthy(full_579)) {
a1_577 = Add(a0_576, ((V)((2D * PI_34))));
}
return Call(rep_18, V.Undef, (Truthy(full_579) ? n_575 : Add(n_575, ((V)(1D)))), Fn((V _arrowThis588, int _argc581, V i_587, V _a584, V _a585, V _a586, V[] _rest582) => {
V t_589 = default;
t_589 = Add(a0_576, ((V)((((ToNum(a1_577) - ToNum(a0_576)) * ToNum(i_587)) / ToNum(n_575)))));
return Arr(Add(cx_571, ((V)((ToNum(rx_573) * FdLibm.Cos(ToNum(t_589)))))), Add(cz_572, ((V)((ToNum(rz_574) * FdLibm.Sin(ToNum(t_589)))))));
return default;
}, 1, "", true));
return default;
}, 7, "", true);
rrPts_52 = Fn((V _arrowThis601, int _argc590, V cx_596, V cz_597, V hx_598, V hz_599, V[] _rest591) => {
V o_602 = default;
V r_600 = default;
r_600 = (_argc590 > 4 ? _rest591[0] : V.Undef);
r_600 = ((V)(Min(ToNum(r_600), ToNum(hx_598), ToNum(hz_599))));
o_602 = Arr();
Invoke(Arr(Arr(((V)(1D)), ((V)(1D)), ((V)(0D))), Arr(((V)((-1D))), ((V)(1D)), ((V)(0.5))), Arr(((V)((-1D))), ((V)((-1D))), ((V)(1D))), Arr(((V)(1D)), ((V)((-1D))), ((V)(1.5)))), "forEach", Fn((V _arrowThis616, int _argc603, V _a605, V _a606, V _a607, V _a608, V[] _rest604) => {
V sx_611 = default;
V sz_613 = default;
V a0_615 = default;
{ V _t609 = ListOf(_a605);
{ V _t610 = GetIdx(_t609, 0D);
sx_611 = _t610; }
{ V _t612 = GetIdx(_t609, 1D);
sz_613 = _t612; }
{ V _t614 = GetIdx(_t609, 2D);
a0_615 = _t614; }
}
{
double i_617 = 0;
i_617 = 0D;
while (true) {
if (!((i_617 <= 5D))) break;
double a_619 = 0;
a_619 = (ToNum(Add(a0_615, ((V)((i_617 / 10D))))) * PI_34);
Invoke(o_602, "push", Arr(Add(Add(cx_596, ((V)((ToNum(sx_611) * (ToNum(hx_598) - ToNum(r_600)))))), ((V)((ToNum(r_600) * FdLibm.Cos(a_619))))), Add(Add(cz_597, ((V)((ToNum(sz_613) * (ToNum(hz_599) - ToNum(r_600)))))), ((V)((ToNum(r_600) * FdLibm.Sin(a_619)))))));
i_617++;
}
}
return default;
}, 1, "", true));
return o_602;
return default;
}, 5, "", true);
shPts_53 = Fn((V _arrowThis627, int _argc620, V s_626, V _a623, V _a624, V _a625, V[] _rest621) => {
return (Get(s_626, "pts") is var _t632 && Truthy(_t632) ? _t632 : (Truthy(Get(s_626, "hx")) ? Call(rrPts_52, V.Undef, (Get(s_626, "cx") is var _t628 && Truthy(_t628) ? _t628 : ((V)(0D))), (Get(s_626, "cz") is var _t629 && Truthy(_t629) ? _t629 : ((V)(0D))), Get(s_626, "hx"), Get(s_626, "hz"), (Get(s_626, "r").IsNullish ? ((V)(3D)) : Get(s_626, "r"))) : Call(ellPts_51, V.Undef, (Get(s_626, "cx") is var _t630 && Truthy(_t630) ? _t630 : ((V)(0D))), (Get(s_626, "cz") is var _t631 && Truthy(_t631) ? _t631 : ((V)(0D))), Get(s_626, "rx"), (Get(s_626, "rz").IsNullish ? Get(s_626, "rx") : Get(s_626, "rz")), ((V)(60D)))));
}, 1, "", true);
lp_54 = Fn((V _arrowThis640, int _argc633, V pts_639, V _a636, V _a637, V _a638, V[] _rest634) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_639, "map", Fn((V _arrowThis648, int _argc641, V q_647, V _a644, V _a645, V _a646, V[] _rest642) => {
return ((V)(JsStrBuf.Begin().V(Call(f1_17, V.Undef, GetIdx(q_647, 0D))).S(" ").V(Call(f1_17, V.Undef, GetIdx(q_647, 1D))).End()));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
}, 1, "", true);
sp_55 = Fn((V _arrowThis658, int _argc649, V p_655, V pts_656, V y_657, V _a654, V[] _rest650) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_656, "map", Fn((V _arrowThis666, int _argc659, V q_665, V _a662, V _a663, V _a664, V[] _rest660) => {
return Call(P2_21, V.Undef, Call(p_655, V.Undef, GetIdx(q_665, 0D), y_657, GetIdx(q_665, 1D)));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
}, 3, "", true);
quad_56 = Fn((V _arrowThis678, int _argc667, V p_673, V a_674, V b_675, V c_676, V[] _rest668) => {
V d_677 = default;
d_677 = (_argc667 > 4 ? _rest668[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Arr(a_674, b_675, c_676, d_677), "map", Fn((V _arrowThis686, int _argc679, V q_685, V _a682, V _a683, V _a684, V[] _rest680) => {
return Call(P2_21, V.Undef, CallSpread(p_673, V.Undef, new ArrBuilder().Spread(q_685).V));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
}, 5, "", true);
planeT_57 = Fn((V _arrowThis699, int _argc687, V p_693, V cx_694, V cz_695, V R_696, V[] _rest688) => {
double s_700 = 0;
double c_701 = 0;
V o_702 = default;
V th_697 = default;
V y_698 = default;
th_697 = (_argc687 > 4 ? _rest688[0] : V.Undef);
y_698 = (_argc687 > 5 ? _rest688[1] : V.Undef);
s_700 = FdLibm.Sin(ToNum(th_697));
c_701 = FdLibm.Cos(ToNum(th_697));
o_702 = Arr(Add(cx_694, ((V)((ToNum(R_696) * s_700)))), y_698, Add(cz_695, ((V)((ToNum(R_696) * c_701)))));
return Call(mtx_22, V.Undef, CallSpread(p_693, V.Undef, new ArrBuilder().Spread(o_702).V), Call(p_693, V.Undef, Add(GetIdx(o_702, 0D), ((V)(c_701))), y_698, ((V)((ToNum(GetIdx(o_702, 2D)) - s_700)))), Call(p_693, V.Undef, GetIdx(o_702, 0D), ((V)((ToNum(y_698) - 1D))), GetIdx(o_702, 2D)));
return default;
}, 6, "", true);
facing_58 = Fn((V _arrowThis710, int _argc703, V th_709, V _a706, V _a707, V _a708, V[] _rest704) => {
return ((V)(FdLibm.Cos((ToNum(th_709) - (PI_34 / 6D)))));
}, 1, "", true);
aboveFront_59 = Fn((V _arrowThis722, int _argc711, V p_717, V r_718, V y_719, V cx_720, V[] _rest712) => {
V a_723 = default;
V cz_721 = default;
cz_721 = (_argc711 > 4 ? _rest712[0] : V.Undef);
a_723 = Invoke(Call(ellPts_51, V.Undef, (cx_720 is var _t732 && Truthy(_t732) ? _t732 : ((V)(0D))), (cz_721 is var _t733 && Truthy(_t733) ? _t733 : ((V)(0D))), r_718, r_718, ((V)(24D)), ((V)(((-PI_34) / 6D))), ((V)(((5D * PI_34) / 6D)))), "map", Fn((V _arrowThis731, int _argc724, V q_730, V _a727, V _a728, V _a729, V[] _rest725) => {
return Call(p_717, V.Undef, GetIdx(q_730, 0D), y_719, GetIdx(q_730, 1D));
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(a_723, "map", P2_21), "join", ((V)("L")))).S(string.Concat("L", ToStr(Call(f1_17, V.Undef, GetIdx(GetIdx(a_723, (ToNum(Get(a_723, "length")) - 1D)), 0D))), " -999L", ToStr(Call(f1_17, V.Undef, GetIdx(GetIdx(a_723, 0D), 0D))), " -999Z")).End()));
return default;
}, 5, "", true);
tube_60 = Fn((V _arrowThis746, int _argc734, V pts_740, V w_741, V k_742, V c_743, V[] _rest735) => {
V d_747 = default;
V hl_744 = default;
V ol_745 = default;
hl_744 = (_argc734 > 4 ? _rest735[0] : V.Undef);
ol_745 = (_argc734 > 5 ? _rest735[1] : V.Undef);
d_747 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_740, "map", P2_21), "join", ((V)("L")))).End()));
return ((V)(string.Concat("<path d=\"", ToStr(d_747), "\" fill=\"none\" stroke=\"", ToStr((ol_745 is var _t748 && Truthy(_t748) ? _t748 : ((V)("#141418")))), "\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(Add(w_741, ((V)(0.7)))) * ToNum(k_742)))))), "\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"", ToStr(d_747), "\" fill=\"none\" stroke=\"", ToStr(c_743), "\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(w_741) * ToNum(k_742)))))), "\" stroke-linecap=\"round\" stroke-linejoin=\"round\"/><path d=\"", ToStr(d_747), "\" fill=\"none\" stroke=\"", ToStr((hl_744 is var _t749 && Truthy(_t749) ? _t749 : ((V)("#ffffff")))), "\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)(((ToNum(w_741) * 0.3) * ToNum(k_742)))))), "\" stroke-linecap=\"round\" stroke-linejoin=\"round\" opacity=\"0.5\" transform=\"translate(", ToStr(Call(f1_17, V.Undef, ((V)((((-0.22) * ToNum(w_741)) * ToNum(k_742)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((((-0.22) * ToNum(w_741)) * ToNum(k_742)))))), ")\"/>")));
return default;
}, 6, "", true);
curve_61 = Fn((V _arrowThis760, int _argc750, V a_756, V b_757, V c_758, V n_759, V[] _rest751) => {
return Call(rep_18, V.Undef, Add(n_759, ((V)(1D))), Fn((V _arrowThis768, int _argc761, V i_767, V _a764, V _a765, V _a766, V[] _rest762) => {
double t_769 = 0;
double u_770 = 0;
t_769 = (ToNum(i_767) / ToNum(n_759));
u_770 = (1D - t_769);
return Invoke(a_756, "map", Fn((V _arrowThis779, int _argc771, V v_777, V j_778, V _a775, V _a776, V[] _rest772) => {
return ((V)(((((u_770 * u_770) * ToNum(v_777)) + (((2D * u_770) * t_769) * ToNum(GetK(b_757, j_778)))) + ((t_769 * t_769) * ToNum(GetK(c_758, j_778))))));
}, 2, "", true));
return default;
}, 1, "", true));
}, 4, "", true);
UID_62 = 0D;
WP_63 = NewObj(7).Put("pool", Arr(((V)("#147aa6")), ((V)("#2ab0d6")), ((V)("#93e6f6")), ((V)("#ffffff")))).Put("kid", Arr(((V)("#2a9ed8")), ((V)("#4cc6ee")), ((V)("#aeeefb")), ((V)("#ffffff")))).Put("cedar", Arr(((V)("#0e5a72")), ((V)("#1f8ea8")), ((V)("#80d4e4")), ((V)("#eafcff")))).Put("koi", Arr(((V)("#153b37")), ((V)("#2a6a5d")), ((V)("#6aae98")), ((V)("#e6fff4")))).Put("marble", Arr(((V)("#2a8fb4")), ((V)("#57bfdc")), ((V)("#b8eef8")), ((V)("#ffffff")))).Put("lagoon", Arr(((V)("#0a6886")), ((V)("#1db2cd")), ((V)("#8af0f5")), ((V)("#ffffff")))).Put("night", Arr(((V)("#05101a")), ((V)("#0f2536")), ((V)("#294b62")), ((V)("#ffc890")))).V;
C1_64 = ((V)("M0 5.5C3 3.2 6.5 8.4 11 5.2S18.5 2.8 22 5.5M0 16.5C4 13.6 7.4 19.8 12.2 16.8S19 14.4 22 16.5M5.5 0C3.4 3.6 8.2 6.8 5.4 11.4S3 18.6 5.5 22M16.5 0C14 4.4 19.6 7.2 16.8 12S14.6 19 16.5 22"));
C2_65 = ((V)("M0 9C6 5 11 14 17 9S26 6 31 9M0 24C5 20 12 28 18 23S27 21 31 24M9 0C5 6 14 11 9 17S6 26 9 31M24 0C20 5 28 12 23 18S21 27 24 31"));
ripple_66 = Fn((V _arrowThis793, int _argc780, V x_786, V z_787, V R1_788, V d_789, V[] _rest781) => {
V b_790 = default;
V col_791 = default;
V w_792 = default;
b_790 = (_argc780 > 4 ? _rest781[0] : V.Undef);
col_791 = (_argc780 > 5 ? _rest781[1] : V.Undef);
w_792 = (_argc780 > 6 ? _rest781[2] : V.Undef);
return Invoke(Call(rep_18, V.Undef, ((V)(2D)), Fn((V _arrowThis801, int _argc794, V j_800, V _a797, V _a798, V _a799, V[] _rest795) => {
double bb_802 = 0;
bb_802 = (ToNum(b_790) - ((ToNum(j_800) * ToNum(d_789)) / 2D));
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_17, V.Undef, x_786)), "\" cy=\"", ToStr(Call(f1_17, V.Undef, z_787)), "\" r=\"0.4\" fill=\"none\" stroke=\"", ToStr((col_791 is var _t803 && Truthy(_t803) ? _t803 : ((V)("#ffffff")))), "\" stroke-width=\"", ToStr((w_792 is var _t804 && Truthy(_t804) ? _t804 : ((V)(0.7)))), "\"><animate attributeName=\"r\" values=\"0.4;", ToStr(Call(f1_17, V.Undef, R1_788)), "\" dur=\"", ToStr(Call(n4_20, V.Undef, d_789)), "s\"", ToStr(Call(B_39, V.Undef, ((V)(bb_802)))), " repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0.85;0\" dur=\"", ToStr(Call(n4_20, V.Undef, d_789)), "s\"", ToStr(Call(B_39, V.Undef, ((V)(bb_802)))), " repeatCount=\"indefinite\"/></circle>")));
return default;
}, 1, "", true)), "join", ((V)("")));
}, 7, "", true);
STAR4_67 = ((V)("M0 -1.7L0.35 -0.35L1.7 0L0.35 0.35L0 1.7L-0.35 0.35L-1.7 0L-0.35 -0.35Z"));
WDEF_69 = Add(Call(L_47, V.Undef, ((V)("w7fall")), Arr(Arr(((V)(0D)), ((V)("#f2fdff")), ((V)(0.95))), Arr(((V)(0.5)), ((V)("#bdeef8")), ((V)(0.7))), Arr(((V)(1D)), ((V)("#8fd8ec")), ((V)(0.55))))), Call(BLUR_27, V.Undef, ((V)("w7m")), ((V)(2.4))));
stream_71 = Fn((V _arrowThis819, int _argc805, V p_811, V k_812, V a_813, V c_814, V[] _rest806) => {
V A_820 = default;
V Cc_821 = default;
V Bb_822 = default;
double len_823 = 0;
V dd_824 = default;
V b_815 = default;
V w_816 = default;
V d_817 = default;
V bg_818 = default;
b_815 = (_argc805 > 4 ? _rest806[0] : V.Undef);
w_816 = (_argc805 > 5 ? _rest806[1] : V.Undef);
d_817 = (_argc805 > 6 ? _rest806[2] : V.Undef);
bg_818 = (_argc805 > 7 ? _rest806[3] : V.Undef);
A_820 = CallSpread(p_811, V.Undef, new ArrBuilder().Spread(a_813).V);
Cc_821 = CallSpread(p_811, V.Undef, new ArrBuilder().Spread(c_814).V);
Bb_822 = CallSpread(p_811, V.Undef, new ArrBuilder().Spread(b_815).V);
len_823 = ((Hypot((ToNum(GetIdx(Bb_822, 0D)) - ToNum(GetIdx(A_820, 0D))), (ToNum(GetIdx(Bb_822, 1D)) - ToNum(GetIdx(A_820, 1D)))) + (Hypot((ToNum(GetIdx(Cc_821, 0D)) - ToNum(GetIdx(A_820, 0D))), (ToNum(GetIdx(Cc_821, 1D)) - ToNum(GetIdx(A_820, 1D)))) * 0.3)) + 1D);
dd_824 = ((V)(string.Concat("M", ToStr(Call(P2_21, V.Undef, A_820)), "Q", ToStr(Call(P2_21, V.Undef, Cc_821)), " ", ToStr(Call(P2_21, V.Undef, Bb_822)))));
return ((V)(string.Concat("<path d=\"", ToStr(dd_824), "\" fill=\"none\" stroke=\"#bfeefa\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(w_816) * ToNum(k_812)))))), "\" stroke-linecap=\"round\" opacity=\"0.6\"/><path d=\"", ToStr(dd_824), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)(((ToNum(w_816) * 0.55) * ToNum(k_812)))))), "\" stroke-linecap=\"round\" stroke-dasharray=\"", ToStr(Call(f1_17, V.Undef, ((V)((len_823 * 0.16))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((len_823 * 0.1))))), "\">", ToStr(Call(an_26, V.Undef, ((V)("stroke-dashoffset")), ((V)(JsStrBuf.Begin().S("0;-").V(Call(f1_17, V.Undef, ((V)((len_823 * 0.52))))).End())), Call(n4_20, V.Undef, (d_817 is var _t825 && Truthy(_t825) ? _t825 : ((V)(0.6)))), (bg_818 is var _t826 && Truthy(_t826) ? _t826 : ((V)(0D))))), "</path>")));
return default;
}, 8, "", true);
FDEF_72 = Add(Add(Add(Add(Add(Call(L_47, V.Undef, ((V)("f7o")), Arr(Arr(((V)(0D)), ((V)("#b8241a")), ((V)(0D))), Arr(((V)(0.2)), ((V)("#d8361a")), ((V)(0.9))), Arr(((V)(0.62)), ((V)("#ff6a1c"))), Arr(((V)(1D)), ((V)("#ffa22e"))))), Call(L_47, V.Undef, ((V)("f7m")), Arr(Arr(((V)(0D)), ((V)("#ff7a1c")), ((V)(0.15))), Arr(((V)(0.38)), ((V)("#ffa42a"))), Arr(((V)(1D)), ((V)("#ffe066")))))), Call(L_47, V.Undef, ((V)("f7c")), Arr(Arr(((V)(0D)), ((V)("#fff3b8")), ((V)(0.2))), Arr(((V)(0.5)), ((V)("#fff8d8"))), Arr(((V)(1D)), ((V)("#ffffff")))))), Call(G_46, V.Undef, ((V)("f7g")), Arr(Arr(((V)(0D)), ((V)("#ffb347")), ((V)(0.75))), Arr(((V)(0.5)), ((V)("#ff7a22")), ((V)(0.24))), Arr(((V)(1D)), ((V)("#ff5a1a")), ((V)(0D)))), ((V)("cx=\"50%\" cy=\"50%\" r=\"50%\"")))), Call(BLUR_27, V.Undef, ((V)("f7s")), ((V)(2.4)))), Call(BLUR_27, V.Undef, ((V)("f7b")), ((V)(1.2))));
FLP_73 = Fn((V _arrowThis836, int _argc827, V s_833, V h_834, V w_835, V _a832, V[] _rest828) => {
return ((V)(string.Concat("M", ToStr(Call(f1_17, V.Undef, ((V)((-ToNum(w_835)))))), " 0C", ToStr(Call(f1_17, V.Undef, ((V)(((-ToNum(w_835)) * 1.15))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((-ToNum(h_834)) * 0.32))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((((-ToNum(w_835)) * 0.2) + (ToNum(s_833) * 0.4)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((-ToNum(h_834)) * 0.58))))), " ", ToStr(Call(f1_17, V.Undef, s_833)), " ", ToStr(Call(f1_17, V.Undef, ((V)((-ToNum(h_834)))))), "C", ToStr(Call(f1_17, V.Undef, ((V)(((ToNum(w_835) * 0.3) + (ToNum(s_833) * 0.45)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((-ToNum(h_834)) * 0.6))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(w_835) * 1.15))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((-ToNum(h_834)) * 0.3))))), " ", ToStr(Call(f1_17, V.Undef, w_835)), " 0Q0 ", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(w_835) * 0.9))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((-ToNum(w_835)))))), " 0Z")));
}, 3, "", true);
embers_75 = Fn((V _arrowThis847, int _argc837, V R_843, V n_844, V sp_845, V h_846, V[] _rest838) => {
return Invoke(Call(rep_18, V.Undef, n_844, Fn((V _arrowThis854, int _argc848, V _a850, V _a851, V _a852, V _a853, V[] _rest849) => {
double x_855 = 0;
double d_856 = 0;
double b_857 = 0;
double dx_858 = 0;
x_855 = (((ToNum(Call(R_843, V.Undef)) - 0.5) * ToNum(sp_845)) * 1.6);
d_856 = (1.5 + (ToNum(Call(R_843, V.Undef)) * 1.5));
b_857 = ((-ToNum(Call(R_843, V.Undef))) * d_856);
dx_858 = ((ToNum(Call(R_843, V.Undef)) - 0.5) * 12D);
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.45 + (ToNum(Call(R_843, V.Undef)) * 0.45)))))), "\" fill=\"#ffd66b\"><animate attributeName=\"cx\" values=\"", ToStr(Call(f1_17, V.Undef, ((V)(x_855)))), ";", ToStr(Call(f1_17, V.Undef, ((V)((x_855 + (dx_858 * 0.5)))))), ";", ToStr(Call(f1_17, V.Undef, ((V)((x_855 + dx_858))))), "\" dur=\"", ToStr(Call(n4_20, V.Undef, ((V)(d_856)))), "s\"", ToStr(Call(B_39, V.Undef, ((V)(b_857)))), " repeatCount=\"indefinite\"/><animate attributeName=\"cy\" values=\"", ToStr(Call(f1_17, V.Undef, ((V)(((-ToNum(h_846)) * 0.5))))), ";", ToStr(Call(f1_17, V.Undef, ((V)(((-ToNum(h_846)) * 2.4))))), "\" dur=\"", ToStr(Call(n4_20, V.Undef, ((V)(d_856)))), "s\"", ToStr(Call(B_39, V.Undef, ((V)(b_857)))), " repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0;1;0.8;0\" dur=\"", ToStr(Call(n4_20, V.Undef, ((V)(d_856)))), "s\"", ToStr(Call(B_39, V.Undef, ((V)(b_857)))), " repeatCount=\"indefinite\"/></circle>")));
return default;
}, 0, "", true)), "join", ((V)("")));
}, 4, "", true);
glowE_78 = Fn((V _arrowThis874, int _argc859, V p_865, V x_866, V y_867, V z_868, V[] _rest860) => {
V q_875 = default;
V q2_876 = default;
V q3_877 = default;
V rx_869 = default;
V rz_870 = default;
V col_871 = default;
V op_872 = default;
V fl_873 = default;
rx_869 = (_argc859 > 4 ? _rest860[0] : V.Undef);
rz_870 = (_argc859 > 5 ? _rest860[1] : V.Undef);
col_871 = (_argc859 > 6 ? _rest860[2] : V.Undef);
op_872 = (_argc859 > 7 ? _rest860[3] : V.Undef);
fl_873 = (_argc859 > 8 ? _rest860[4] : V.Undef);
q_875 = Call(p_865, V.Undef, x_866, y_867, z_868);
q2_876 = Call(p_865, V.Undef, Add(x_866, rx_869), y_867, z_868);
q3_877 = Call(p_865, V.Undef, x_866, y_867, Add(z_868, rz_870));
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q_875, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q_875, 1D))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((Hypot((ToNum(GetIdx(q2_876, 0D)) - ToNum(GetIdx(q_875, 0D))), (ToNum(GetIdx(q2_876, 1D)) - ToNum(GetIdx(q_875, 1D)))) * 1.2))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)(((System.Math.Abs((ToNum(GetIdx(q3_877, 1D)) - ToNum(GetIdx(q_875, 1D)))) * 1.3) + 2D))))), "\" fill=\"", ToStr(col_871), "\" opacity=\"", ToStr(op_872), "\" filter=\"url(#f7s)\">", ToStr((Truthy(fl_873) ? Call(an_26, V.Undef, ((V)("opacity")), ((V)(string.Concat(ToStr(op_872), ";", ToStr(Call(n4_20, V.Undef, ((V)((ToNum(op_872) * 0.6))))), ";", ToStr(op_872), ";", ToStr(Call(n4_20, V.Undef, ((V)((ToNum(op_872) * 0.75))))), ";", ToStr(op_872)))), ((V)(1.6))) : ((V)("")))), "</ellipse>")));
return default;
}, 9, "", true);
DUCK_79 = ((V)(string.Concat("<ellipse cx=\"0\" cy=\"0.8\" rx=\"7\" ry=\"2.1\" fill=\"#ffffff\" opacity=\"0.35\"/><path d=\"M-5.6 -1.6Q-6.4 -4.6 -3.4 -4.4Q0 -3.6 3.6 -4.2Q6 -4.4 5.6 -1.4Q5 0.8 0 0.9Q-5 0.8 -5.6 -1.6Z\" fill=\"#ffd23a\" stroke=\"#c98a10\" stroke-width=\"0.3\"/><path d=\"M-4 -3.6Q-1 -1.8 3 -3\" stroke=\"#e8a81a\" stroke-width=\"0.5\" fill=\"none\"/>", "<path d=\"M-6 -2.6Q-7.8 -4.2 -7 -5.2Q-5.6 -4.4 -5 -3Z\" fill=\"#ffd23a\"/><circle cx=\"2.6\" cy=\"-6.8\" r=\"3\" fill=\"#ffd23a\" stroke=\"#c98a10\" stroke-width=\"0.3\"/><path d=\"M5.2 -7.3Q7.8 -7 7.5 -6Q6.8 -5.3 5.2 -5.8Z\" fill=\"#ff7a1a\"/><circle cx=\"3.5\" cy=\"-7.6\" r=\"0.55\" fill=\"#1d1e22\"/><ellipse cx=\"1.5\" cy=\"-8.2\" rx=\"1.1\" ry=\"0.7\" fill=\"#ffffff\" opacity=\"0.65\"/>")));
BBALL_80 = Fn((V _arrowThis885, int _argc878, V r_884, V _a881, V _a882, V _a883, V[] _rest879) => {
return ((V)(string.Concat("<ellipse cx=\"0\" cy=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(r_884) * 0.85))))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(r_884) * 1.15))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(r_884) * 0.3))))), "\" fill=\"#ffffff\" opacity=\"0.3\"/><circle r=\"", ToStr(r_884), "\" fill=\"#fbfbf6\"/><g clip-path=\"url(#k7bb)\">", ToStr(Invoke(Invoke(Arr(Arr(((V)("#e8343c")), ((V)(0D))), Arr(((V)("#2a86e6")), ((V)(60D))), Arr(((V)("#ffd23a")), ((V)(120D)))), "map", Fn((V _arrowThis897, int _argc886, V _a888, V _a889, V _a890, V _a891, V[] _rest887) => {
V c_894 = default;
V a_896 = default;
{ V _t892 = ListOf(_a888);
{ V _t893 = GetIdx(_t892, 0D);
c_894 = _t893; }
{ V _t895 = GetIdx(_t892, 1D);
a_896 = _t895; }
}
return ((V)(string.Concat("<ellipse rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(r_884) * 0.36))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(r_884) * 1.1))))), "\" fill=\"", ToStr(c_894), "\" transform=\"rotate(", ToStr(a_896), ")\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g><circle r=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(r_884) * 0.22))))), "\" fill=\"#fbfbf6\"/><circle r=\"", ToStr(r_884), "\" fill=\"url(#k7bs)\"/><ellipse cx=\"", ToStr(Call(f1_17, V.Undef, ((V)(((-ToNum(r_884)) * 0.35))))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, ((V)(((-ToNum(r_884)) * 0.4))))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(r_884) * 0.3))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(r_884) * 0.18))))), "\" fill=\"#ffffff\" opacity=\"0.8\"/>")));
}, 1, "", true);
BBDEF_81 = Fn((V _arrowThis905, int _argc898, V r_904, V _a901, V _a902, V _a903, V[] _rest899) => {
return ((V)(JsStrBuf.Begin().S(string.Concat("<clipPath id=\"k7bb\"><circle r=\"", ToStr(r_904), "\"/></clipPath>")).V(Call(G_46, V.Undef, ((V)("k7bs")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(0.6)), ((V)("#000000")), ((V)(0D))), Arr(((V)(1D)), ((V)("#000000")), ((V)(0.3)))), ((V)("cx=\"40%\" cy=\"38%\" r=\"65%\"")))).End()));
}, 1, "", true);
Set(N_33, "kiddie", Fn((V _arrowThis913, int _argc906, V S_912, V _a909, V _a910, V _a911, V[] _rest907) => {
double R0_914 = 0;
double RI_915 = 0;
double TY_916 = 0;
double WY_917 = 0;
V BL_918 = default;
V WT_919 = default;
V D_920 = default;
V prof_921 = default;
R0_914 = 52D;
RI_915 = 40D;
TY_916 = 30D;
WY_917 = 21D;
BL_918 = ((V)("#2a86e6"));
WT_919 = ((V)("#f6f9fc"));
D_920 = NewObj(4).Put("w", ((V)(112D))).Put("d", ((V)(112D))).Put("round", ((V)(1D))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-16D)))).Put("z", ((V)(6D))).Put("h", ((V)(WY_917))).V, NewObj(3).Put("x", ((V)(16D))).Put("z", ((V)((-6D)))).Put("h", ((V)(WY_917))).V)).V;
prof_921 = Fn((V _arrowThis929, int _argc922, V top_928, V _a925, V _a926, V _a927, V[] _rest923) => {
return (Truthy(top_928) ? Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.955))), Arr(((V)(2.5)), ((V)(0D)), ((V)(0.99))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))), Arr(((V)(7.4)), ((V)(0D)), ((V)(0.985))), Arr(((V)(9D)), ((V)(0D)), ((V)(0.95))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.9)))) : Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.955))), Arr(((V)(2.5)), ((V)(0D)), ((V)(0.99))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))), Arr(((V)(7.5)), ((V)(0D)), ((V)(0.99))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.955)))));
}, 1, "", true);
Set(D_920, "build", Fn((V _arrowThis937, int _argc930, V P_936, V _a933, V _a934, V _a935, V[] _rest931) => {
return Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis945, int _argc938, V i_944, V _a941, V _a942, V _a943, V[] _rest939) => {
return Call(cyl_13, V.Undef, ((V)(0D)), ((V)((ToNum(i_944) * 10D))), ((V)(0D)), ((V)(R0_914)), ((V)(10D)), (SEqN(i_944, 1D) ? WT_919 : BL_918), NewObj(3).Put("n", ((V)(48D))).Put("rg", Call(prof_921, V.Undef, (SEqN(i_944, 2D) ? V.True : V.False))).Put("shine", ((V)(1D))).V);
}, 1, "", true));
}, 1, "", true));
Set(D_920, "fx", Fn((V _arrowThis953, int _argc946, V c_952, V _a949, V _a950, V _a951, V[] _rest947) => {
V p_954 = default;
V k_955 = default;
JsStrBuf f_956 = null;
V defs_957 = default;
V FISH_958 = default;
V STAR_959 = default;
V cr_960 = default;
V fl_961 = default;
V W_962 = default;
p_954 = Get(c_952, "p");
k_955 = Get(c_952, "k");
f_956 = new JsStrBuf("");
defs_957 = Add(WDEF_69, Call(BBDEF_81, V.Undef, ((V)(5.2))));
FISH_958 = ((V)("<path d=\"M-4.2 0Q-1 -3 3 0Q-1 3 -4.2 0Z\" fill=\"#ff8a3a\"/><path d=\"M2.6 0L5.6 -2.2V2.2Z\" fill=\"#ff8a3a\"/><circle cx=\"-2.2\" cy=\"-0.5\" r=\"0.45\" fill=\"#1d2a3a\"/><circle cx=\"-6\" cy=\"-2.4\" r=\"0.8\" fill=\"none\" stroke=\"#5ab4f0\" stroke-width=\"0.35\"/><circle cx=\"-7.4\" cy=\"-4\" r=\"0.5\" fill=\"none\" stroke=\"#5ab4f0\" stroke-width=\"0.3\"/>"));
STAR_959 = ((V)("<path d=\"M0 -3.6L1 -1.2L3.5 -1.1L1.5 0.6L2.2 3.1L0 1.7L-2.2 3.1L-1.5 0.6L-3.5 -1.1L-1 -1.2Z\" fill=\"#ffd23a\" stroke=\"#e8a81a\" stroke-width=\"0.3\"/>"));
Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis970, int _argc963, V i_969, V _a966, V _a967, V _a968, V[] _rest964) => {
double th_971 = 0;
th_971 = ((-1.25) + (ToNum(i_969) * 0.42));
if (LtN(Call(facing_58, V.Undef, ((V)(th_971))), 0.18)) {
return default;
}
f_956.S(string.Concat("<g transform=\"", ToStr(Call(planeT_57, V.Undef, p_954, ((V)(0D)), ((V)(0D)), ((V)((R0_914 + 0.15))), ((V)(th_971)), ((V)(15D)))), "\">", ToStr((NumTruthy((ToNum(i_969) % 2D)) ? STAR_959 : FISH_958)), "</g>"));
return default;
}, 1, "", true));
cr_960 = ((V)(string.Concat("<radialGradient id=\"k7cr\" gradientUnits=\"userSpaceOnUse\" cx=\"0\" cy=\"0\" r=\"47\">", ToStr(Call(st_45, V.Undef, Arr(Arr(((V)(0D)), ((V)("#1a5fb0"))), Arr(((V)(0.851)), ((V)("#1a5fb0"))), Arr(((V)(0.9)), ((V)("#9ad6ff"))), Arr(((V)(0.955)), ((V)("#3f9af0"))), Arr(((V)(1D)), BL_918)))), "</radialGradient>")));
defs_957 = Add(defs_957, Add(cr_960, Call(L_47, V.Undef, ((V)("k7in")), Arr(Arr(((V)(0D)), ((V)("#1b5fae"))), Arr(((V)(1D)), ((V)("#4aa2f2")))))));
f_956.S(string.Concat("<g transform=\"", ToStr(Call(planeH_25, V.Undef, p_954, ((V)(TY_916)))), "\"><path d=\"", ToStr(Call(lp_54, V.Undef, Call(ellPts_51, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(46.9)), ((V)(46.9)), ((V)(60D))))), ToStr(Call(lp_54, V.Undef, Call(ellPts_51, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(RI_915)), ((V)(RI_915)), ((V)(60D))))), "\" fill=\"url(#k7cr)\" fill-rule=\"evenodd\"/><ellipse cx=\"", ToStr(Call(f1_17, V.Undef, ((V)((46D * FdLibm.Cos((-0.5))))))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, ((V)(((46D * FdLibm.Sin((-0.5))) + 0D))))), "\" rx=\"1.6\" ry=\"1.6\" fill=\"#f6f9fc\" stroke=\"#9aa1ad\" stroke-width=\"0.3\"/></g>"));
f_956.S(string.Concat("<path d=\"", ToStr(Call(sp_55, V.Undef, p_954, Call(ellPts_51, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(RI_915)), ((V)(RI_915)), ((V)(60D))), ((V)(TY_916)))), "\" fill=\"url(#k7in)\"/>"));
fl_961 = ((V)(JsStrBuf.Begin().S(string.Concat("<circle r=\"", NumStr(RI_915), "\" fill=\"#8fdcf6\" opacity=\"0.55\"/>")).V(Invoke(Invoke(Arr(Arr(((V)((-14D))), ((V)((-10D))), ((V)(1D))), Arr(((V)(12D)), ((V)(12D)), ((V)(0D))), Arr(((V)((-6D))), ((V)(18D)), ((V)(1D))), Arr(((V)(18D)), ((V)((-14D))), ((V)(0D))), Arr(((V)(0D)), ((V)(0D)), ((V)(1D)))), "map", Fn((V _arrowThis986, int _argc972, V _a974, V i_978, V _a976, V _a977, V[] _rest973) => {
V x_981 = default;
V z_983 = default;
V t_985 = default;
{ V _t979 = ListOf(_a974);
{ V _t980 = GetIdx(_t979, 0D);
x_981 = _t980; }
{ V _t982 = GetIdx(_t979, 1D);
z_983 = _t982; }
{ V _t984 = GetIdx(_t979, 2D);
t_985 = _t984; }
}
return ((V)(string.Concat("<g transform=\"translate(", ToStr(x_981), " ", ToStr(z_983), ") rotate(", NumStr((ToNum(i_978) * 47D)), ") scale(1.3)\" opacity=\"0.5\">", (Truthy(t_985) ? "<path d=\"M0 -3.6L1 -1.2L3.5 -1.1L1.5 0.6L2.2 3.1L0 1.7L-2.2 3.1L-1.5 0.6L-3.5 -1.1L-1 -1.2Z\" fill=\"#ffd23a\"/>" : "<path d=\"M-4.2 0Q-1 -3 3 0Q-1 3 -4.2 0Z\" fill=\"#ff8a3a\"/><path d=\"M2.6 0L5.6 -2.2V2.2Z\" fill=\"#ff8a3a\"/>"), "</g>")));
}, 2, "", true)), "join", ((V)("")))).End()));
W_962 = Call(water_68, V.Undef, p_954, NewObj(8).Put("sh", NewObj(1).Put("rx", ((V)((RI_915 + 0.5)))).V).Put("y", ((V)(WY_917))).Put("rim", NewObj(2).Put("y", ((V)(TY_916))).Put("sh", NewObj(1).Put("rx", ((V)(RI_915))).V).V).Put("pal", Get(WP_63, "kid")).Put("cs", ((V)(0.8))).Put("floor", fl_961).Put("rip", Arr(Arr(((V)((-14D))), ((V)(8D)), ((V)(9D)), ((V)(2.6)), ((V)(0D))), Arr(((V)(10D)), ((V)((-10D))), ((V)(8D)), ((V)(3.1)), ((V)((-1.2)))), Arr(((V)(4D)), ((V)(14D)), ((V)(7D)), ((V)(2.2)), ((V)((-0.6)))))).Put("gl", ((V)(7D))).V);
defs_957 = Add(defs_957, Get(W_962, "defs"));
f_956.V(Get(W_962, "svg"));
{
V path_987 = default;
V bq_988 = default;
path_987 = ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(Call(ellPts_51, V.Undef, ((V)(4D)), ((V)((-4D))), ((V)(17D)), ((V)(12D)), ((V)(24D))), "map", Fn((V _arrowThis996, int _argc989, V q_995, V _a992, V _a993, V _a994, V[] _rest990) => {
return Call(P2_21, V.Undef, Call(p_954, V.Undef, GetIdx(q_995, 0D), ((V)(WY_917)), GetIdx(q_995, 1D)));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
f_956.S(string.Concat("<g><animateMotion dur=\"18s\" repeatCount=\"indefinite\" path=\"", ToStr(path_987), "\"/><g transform=\"scale(", ToStr(Call(n4_20, V.Undef, ((V)((ToNum(k_955) * 0.95))))), ")\"><g>", ToStr(Call(atV_42, V.Undef, ((V)("translate")), Arr(((V)("0 0")), ((V)("0 -0.8")), ((V)("0 0"))), ((V)(1.6)))), "<g>", ToStr(Call(atV_42, V.Undef, ((V)("rotate")), Arr(((V)("-5")), ((V)("5")), ((V)("-5"))), ((V)(2.2)))), ToStr(DUCK_79), "</g></g></g></g>"));
bq_988 = Call(p_954, V.Undef, ((V)((-20D))), ((V)(WY_917)), ((V)(12D)));
f_956.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_21, V.Undef, bq_988)), ") scale(", ToStr(Call(n4_20, V.Undef, k_955)), ")\"><g>", ToStr(Call(atV_42, V.Undef, ((V)("translate")), Arr(((V)("0 -5")), ((V)("0 -5.9")), ((V)("0 -5"))), ((V)(1.9)), ((V)((-0.7))))), "<g>", ToStr(Call(atV_42, V.Undef, ((V)("rotate")), Arr(((V)("-14")), ((V)("14")), ((V)("-14"))), ((V)(5D)))), ToStr(Call(BBALL_80, V.Undef, ((V)(5.2)))), "</g></g></g>"));
}
return NewObj(3).Put("defs", defs_957).Put("front", ((V)(f_956.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_954, V.Undef, ((V)((-R0_914))), ((V)(0D)), ((V)((-R0_914)))), Call(p_954, V.Undef, ((V)(R0_914)), ((V)(0D)), ((V)(R0_914))), Call(p_954, V.Undef, ((V)((-R0_914))), ((V)(34D)), ((V)(R0_914))), Call(p_954, V.Undef, ((V)(R0_914)), ((V)(34D)), ((V)((-R0_914)))), Call(p_954, V.Undef, ((V)(R0_914)), ((V)(0D)), ((V)((-R0_914)))), Call(p_954, V.Undef, ((V)((-R0_914))), ((V)(0D)), ((V)(R0_914)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_920;
return default;
}, 1, "", true));
Set(N_33, "plunge", Fn((V _arrowThis1004, int _argc997, V S_1003, V _a1000, V _a1001, V _a1002, V[] _rest998) => {
double RO_1005 = 0;
double RI_1006 = 0;
double H_1007 = 0;
double CAP_1008 = 0;
double WY_1009 = 0;
double TH_1010 = 0;
double sT_1011 = 0;
double cT_1012 = 0;
V CED_1013 = default;
V CED2_1014 = default;
V D_1015 = default;
V at_1016 = default;
RO_1005 = 58D;
RI_1006 = 51D;
H_1007 = 40D;
CAP_1008 = 43D;
WY_1009 = 35D;
TH_1010 = ((72D * PI_34) / 180D);
sT_1011 = FdLibm.Sin(TH_1010);
cT_1012 = FdLibm.Cos(TH_1010);
CED_1013 = ((V)("#b9733e"));
CED2_1014 = ((V)("#cf8f55"));
D_1015 = NewObj(4).Put("w", ((V)(150D))).Put("d", ((V)(150D))).Put("round", ((V)(1D))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-18D)))).Put("z", ((V)(4D))).Put("h", ((V)(WY_1009))).V, NewObj(3).Put("x", ((V)(14D))).Put("z", ((V)((-10D)))).Put("h", ((V)(WY_1009))).V, NewObj(3).Put("x", ((V)(2D))).Put("z", ((V)(16D))).Put("h", ((V)(WY_1009))).V)).V;
Set(D_1015, "build", Fn((V _arrowThis1024, int _argc1017, V P_1023, V _a1020, V _a1021, V _a1022, V[] _rest1018) => {
V o_1025 = default;
o_1025 = Arr(Call(arcW_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(RO_1005)), ((V)(RO_1005)), ((V)((RO_1005 - RI_1006))), ((V)(H_1007)), ((V)(4.4)), ((V)((4.4 + (2D * PI_34)))), CED_1013, Call(wd_30, V.Undef, NewObj(1).Put("n", ((V)(56D))).V)), Call(arcW_15, V.Undef, ((V)(0D)), ((V)(H_1007)), ((V)(0D)), ((V)((RO_1005 + 1.6))), ((V)((RO_1005 + 1.6))), ((V)(((RO_1005 - RI_1006) + 3.2))), ((V)(3D)), ((V)(4.4)), ((V)((4.4 + (2D * PI_34)))), CED2_1014, Call(wd_30, V.Undef, NewObj(1).Put("n", ((V)(56D))).V)));
Invoke(Arr(((V)(6D)), ((V)(30D))), "forEach", Fn((V _arrowThis1033, int _argc1026, V y_1032, V _a1029, V _a1030, V _a1031, V[] _rest1027) => {
return Invoke(o_1025, "push", Call(arcW_15, V.Undef, ((V)(0D)), y_1032, ((V)(0D)), ((V)((RO_1005 + 0.9))), ((V)((RO_1005 + 0.9))), ((V)(1.3)), ((V)(2.6)), ((V)(4.4)), ((V)((4.4 + (2D * PI_34)))), ((V)("#2a2c31")), Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(56D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
return o_1025;
return default;
}, 1, "", true));
at_1016 = Fn((V _arrowThis1043, int _argc1034, V r_1040, V t_1041, V y_1042, V _a1039, V[] _rest1035) => {
return Arr(((V)(((sT_1011 * ToNum(r_1040)) + (cT_1012 * ToNum(t_1041))))), y_1042, ((V)(((cT_1012 * ToNum(r_1040)) - (sT_1011 * ToNum(t_1041))))));
}, 3, "", true);
Set(D_1015, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1051, int _argc1044, V P_1050, V _a1047, V _a1048, V _a1049, V[] _rest1045) => {
return Arr(Call(box_12, V.Undef, ((V)((sT_1011 * 76D))), ((V)(0D)), ((V)((cT_1012 * 76D))), ((V)(34D)), ((V)(14D)), ((V)(11D)), CED2_1014, Call(wd_30, V.Undef, NewObj(2).Put("r", ((V)(1.2))).Put("yaw", ((V)((-TH_1010)))).V)), Call(box_12, V.Undef, ((V)((sT_1011 * 66D))), ((V)(0D)), ((V)((cT_1012 * 66D))), ((V)(34D)), ((V)(28D)), ((V)(10D)), CED_1013, Call(wd_30, V.Undef, NewObj(2).Put("r", ((V)(1.2))).Put("yaw", ((V)((-TH_1010)))).V)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1060, int _argc1052, V p_1058, V s_1059, V _a1056, V _a1057, V[] _rest1053) => {
JsStrBuf ln_1061 = null;
ln_1061 = new JsStrBuf("");
Call(rep_18, V.Undef, ((V)(64D)), Fn((V _arrowThis1069, int _argc1062, V i_1068, V _a1065, V _a1066, V _a1067, V[] _rest1063) => {
double th_1070 = 0;
V a_1071 = default;
V b_1072 = default;
th_1070 = (((ToNum(i_1068) / 64D) * 2D) * PI_34);
if (LtN(Call(facing_58, V.Undef, ((V)(th_1070))), 0.04)) {
return default;
}
a_1071 = Call(p_1058, V.Undef, ((V)((RO_1005 * FdLibm.Sin(th_1070)))), ((V)(0.6)), ((V)((RO_1005 * FdLibm.Cos(th_1070)))));
b_1072 = Call(p_1058, V.Undef, ((V)((RO_1005 * FdLibm.Sin(th_1070)))), ((V)((H_1007 - 0.4))), ((V)((RO_1005 * FdLibm.Cos(th_1070)))));
ln_1061.S(string.Concat("<path d=\"M", ToStr(Call(P2_21, V.Undef, a_1071)), "L", ToStr(Call(P2_21, V.Undef, b_1072)), "\" stroke=\"#6e3f1e\" stroke-width=\"0.55\" opacity=\"", ToStr(Call(n4_20, V.Undef, ((V)((0.35 + (0.4 * ToNum(Call(facing_58, V.Undef, ((V)(th_1070)))))))))), "\"/>"));
return default;
}, 1, "", true));
return ((V)(JsStrBuf.Begin().S(ln_1061.Str).V(s_1059).End()));
return default;
}, 2, "wrap", true)).V));
Set(D_1015, "fx", Fn((V _arrowThis1080, int _argc1073, V c_1079, V _a1076, V _a1077, V _a1078, V[] _rest1074) => {
V p_1081 = default;
V k_1082 = default;
JsStrBuf f_1083 = null;
V defs_1084 = default;
JsStrBuf inn_1085 = null;
V fl_1086 = default;
V leaf_1087 = default;
V W_1088 = default;
p_1081 = Get(c_1079, "p");
k_1082 = Get(c_1079, "k");
f_1083 = new JsStrBuf("");
defs_1084 = WDEF_69;
inn_1085 = new JsStrBuf("");
Call(rep_18, V.Undef, ((V)(56D)), Fn((V _arrowThis1096, int _argc1089, V i_1095, V _a1092, V _a1093, V _a1094, V[] _rest1090) => {
double th_1097 = 0;
th_1097 = (((ToNum(i_1095) / 56D) * 2D) * PI_34);
if (GtN(Call(facing_58, V.Undef, ((V)(th_1097))), (-0.05))) {
return default;
}
inn_1085.S(string.Concat("<path d=\"M", ToStr(Call(P2_21, V.Undef, Call(p_1081, V.Undef, ((V)((RI_1006 * FdLibm.Sin(th_1097)))), ((V)(CAP_1008)), ((V)((RI_1006 * FdLibm.Cos(th_1097))))))), "L", ToStr(Call(P2_21, V.Undef, Call(p_1081, V.Undef, ((V)((RI_1006 * FdLibm.Sin(th_1097)))), ((V)(WY_1009)), ((V)((RI_1006 * FdLibm.Cos(th_1097))))))), "\" stroke=\"#7a4522\" stroke-width=\"0.5\" opacity=\"0.6\"/>"));
return default;
}, 1, "", true));
f_1083.S(string.Concat("<g clip-path=\"url(#p7rim)\">", inn_1085.Str, "</g>"));
defs_1084 = ((V)(JsStrBuf.Begin().V(defs_1084).S(string.Concat("<clipPath id=\"p7rim\"><path d=\"", ToStr(Call(sp_55, V.Undef, p_1081, Call(ellPts_51, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(RI_1006)), ((V)(RI_1006)), ((V)(60D))), ((V)(CAP_1008)))), "\"/></clipPath>")).End()));
fl_1086 = ((V)(JsStrBuf.Begin().S(string.Concat("<circle r=\"", NumStr(RI_1006), "\" fill=\"#5a8a7a\" opacity=\"0.35\"/>")).V(Invoke(Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis1105, int _argc1098, V i_1104, V _a1101, V _a1102, V _a1103, V[] _rest1099) => {
return ((V)(string.Concat("<path d=\"M", NumStr((-RI_1006)), " ", NumStr((((-RI_1006) + 6D) + (ToNum(i_1104) * 11D))), "H", NumStr(RI_1006), "\" stroke=\"#3b5f55\" stroke-width=\"0.8\" opacity=\"0.35\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
leaf_1087 = ((V)("<path d=\"M0 0Q2.6 -2.6 6 0Q2.6 2.6 0 0Z\" fill=\"#d9a03a\"/><path d=\"M0 0H6\" stroke=\"#9a6a1e\" stroke-width=\"0.3\"/>"));
W_1088 = Call(water_68, V.Undef, p_1081, NewObj(9).Put("sh", NewObj(1).Put("rx", ((V)(RI_1006))).V).Put("y", ((V)(WY_1009))).Put("rim", NewObj(2).Put("y", ((V)(CAP_1008))).Put("sh", NewObj(1).Put("rx", ((V)(RI_1006))).V).V).Put("pal", Get(WP_63, "cedar")).Put("cs", ((V)(1.1))).Put("floor", fl_1086).Put("rip", Arr(Arr(((V)((-10D))), ((V)(6D)), ((V)(10D)), ((V)(3D)), ((V)(0D))), Arr(((V)(16D)), ((V)((-8D))), ((V)(9D)), ((V)(3.6)), ((V)((-1.5)))))).Put("gl", ((V)(6D))).Put("over", ((V)(string.Concat("<g transform=\"translate(-22 -18)\">", ToStr(Call(atV_42, V.Undef, ((V)("rotate")), Arr(((V)("-20")), ((V)("25")), ((V)("-20"))), ((V)(14D)))), ToStr(leaf_1087), "</g><g transform=\"translate(24 10) rotate(140)\">", ToStr(leaf_1087), "</g>")))).V);
defs_1084 = Add(defs_1084, Get(W_1088, "defs"));
f_1083.V(Get(W_1088, "svg"));
{
V q_1106 = default;
q_1106 = Call(p_1081, V.Undef, ((V)(10D)), ((V)(WY_1009)), ((V)(4D)));
f_1083.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_21, V.Undef, q_1106)), ") scale(", ToStr(Call(n4_20, V.Undef, k_1082)), ")\"><g>", ToStr(Call(atV_42, V.Undef, ((V)("translate")), Arr(((V)("0 0")), ((V)("2 -0.6")), ((V)("0 0"))), ((V)(4.4)))), "<ellipse cx=\"0\" cy=\"0.6\" rx=\"5\" ry=\"1.4\" fill=\"#ffffff\" opacity=\"0.35\"/><rect x=\"-1.4\" y=\"-7.6\" width=\"2.8\" height=\"8\" rx=\"1.4\" fill=\"#c98c56\" stroke=\"#6e3f1e\" stroke-width=\"0.3\"/><rect x=\"-0.4\" y=\"-6.4\" width=\"0.8\" height=\"5\" rx=\"0.4\" fill=\"#ffffff\"/><rect x=\"-0.4\" y=\"-3.8\" width=\"0.8\" height=\"2.4\" fill=\"#e8343c\"/><circle cx=\"0\" cy=\"-8.4\" r=\"1\" fill=\"#6e3f1e\"/></g></g>"));
}
Invoke(Arr(((V)((-9D))), ((V)(9D))), "forEach", Fn((V _arrowThis1114, int _argc1107, V t_1113, V _a1110, V _a1111, V _a1112, V[] _rest1108) => {
V pts_1115 = default;
pts_1115 = Invoke(Invoke(Call(curve_61, V.Undef, Call(at_1016, V.Undef, ((V)(70D)), t_1113, ((V)(28D))), Call(at_1016, V.Undef, ((V)(68D)), t_1113, ((V)(62D))), Call(at_1016, V.Undef, ((V)(54D)), t_1113, ((V)(50D))), ((V)(10D))), "concat", Invoke(Call(curve_61, V.Undef, Call(at_1016, V.Undef, ((V)(54D)), t_1113, ((V)(50D))), Call(at_1016, V.Undef, ((V)(48D)), t_1113, ((V)(44D))), Call(at_1016, V.Undef, ((V)(47D)), t_1113, ((V)(26D))), ((V)(6D))), "slice", ((V)(1D)))), "map", Fn((V _arrowThis1123, int _argc1116, V q_1122, V _a1119, V _a1120, V _a1121, V[] _rest1117) => {
return CallSpread(p_1081, V.Undef, new ArrBuilder().Spread(q_1122).V);
}, 1, "", true));
f_1083.V(Call(tube_60, V.Undef, pts_1115, ((V)(1.5)), k_1082, ((V)("#c9d0d6"))));
return default;
}, 1, "", true));
return NewObj(3).Put("defs", defs_1084).Put("front", ((V)(f_1083.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1081, V.Undef, ((V)(((-RO_1005) - 2D))), ((V)(0D)), ((V)(((-RO_1005) - 2D)))), Call(p_1081, V.Undef, ((V)((RO_1005 + 2D))), ((V)(0D)), ((V)((RO_1005 + 2D)))), Call(p_1081, V.Undef, ((V)(((-RO_1005) - 2D))), ((V)(CAP_1008)), ((V)((RO_1005 + 2D)))), Call(p_1081, V.Undef, ((V)((RO_1005 + 2D))), ((V)(CAP_1008)), ((V)(((-RO_1005) - 2D)))), CallSpread(p_1081, V.Undef, new ArrBuilder().Spread(Call(at_1016, V.Undef, ((V)(82D)), ((V)(0D)), ((V)(0D)))).V), CallSpread(p_1081, V.Undef, new ArrBuilder().Spread(Call(at_1016, V.Undef, ((V)(70D)), ((V)(0D)), ((V)(62D)))).V)), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1015;
return default;
}, 1, "", true));
Set(N_33, "koiPond", Fn((V _arrowThis1131, int _argc1124, V S_1130, V _a1127, V _a1128, V _a1129, V[] _rest1125) => {
double RX_1132 = 0;
double RZ_1133 = 0;
double WY_1134 = 0;
V R_1135 = default;
V ST_1136 = default;
V MOSS_1137 = default;
V D_1138 = default;
V rocks_1139 = default;
V KOI_1140 = default;
V fish_1141 = default;
V loop_1142 = default;
V PAD_1143 = default;
V WAT_1144 = default;
V mkWater_1145 = default;
RX_1132 = 56D;
RZ_1133 = 42D;
WY_1134 = 5.5;
R_1135 = Call(rng_19, V.Undef, ((V)("koiP")));
ST_1136 = Arr(((V)("#8f8a7e")), ((V)("#a39d90")), ((V)("#7d786d")), ((V)("#b3ab9c")), ((V)("#948c7c")));
MOSS_1137 = ((V)("#6f9a4a"));
D_1138 = NewObj(2).Put("w", ((V)(140D))).Put("d", ((V)(112D))).V;
Set(D_1138, "build", Fn((V _arrowThis1153, int _argc1146, V P_1152, V _a1149, V _a1150, V _a1151, V[] _rest1147) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((RX_1132 + 5D))), ((V)(4.6)), ((V)("#4f4436")), Call(pt_32, V.Undef, NewObj(2).Put("rz", ((V)((RZ_1133 + 5D)))).Put("n", ((V)(44D))).V)));
}, 1, "", true));
rocks_1139 = Fn((V _arrowThis1160, int _argc1154, V _a1156, V _a1157, V _a1158, V _a1159, V[] _rest1155) => {
V o_1161 = default;
V RR_1162 = default;
o_1161 = Arr();
RR_1162 = Call(rng_19, V.Undef, ((V)("koiR")));
Call(rep_18, V.Undef, ((V)(26D)), Fn((V _arrowThis1170, int _argc1163, V i_1169, V _a1166, V _a1167, V _a1168, V[] _rest1164) => {
double t_1171 = 0;
double r_1172 = 0;
double x_1173 = 0;
double z_1174 = 0;
t_1171 = ((((ToNum(i_1169) / 26D) * 2D) * PI_34) + 0.08);
if ((FdLibm.Sin(t_1171) < (-0.82))) {
return default;
}
r_1172 = (6D + (ToNum(Call(RR_1162, V.Undef)) * 4D));
x_1173 = ((RX_1132 + 1.5) * FdLibm.Cos(t_1171));
z_1174 = ((RZ_1133 + 1.5) * FdLibm.Sin(t_1171));
Invoke(o_1161, "push", Call(ball_14, V.Undef, ((V)(x_1173)), ((V)((-0.5))), ((V)(z_1174)), ((V)(r_1172)), GetIdx(ST_1136, (ToNum(i_1169) % 5D)), Call(pt_32, V.Undef, NewObj(6).Put("sx", ((V)((1.15 + (ToNum(Call(RR_1162, V.Undef)) * 0.3))))).Put("sy", ((V)((0.6 + (ToNum(Call(RR_1162, V.Undef)) * 0.25))))).Put("sz", ((V)(0.95))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).Put("yaw", ((V)((ToNum(Call(RR_1162, V.Undef)) * 3D)))).V)));
if (((ToNum(i_1169) % 3D) == 0D)) {
Invoke(o_1161, "push", Call(ball_14, V.Undef, ((V)((x_1173 - 0.6))), ((V)((r_1172 * 0.62))), ((V)(z_1174)), ((V)((r_1172 * 0.6))), MOSS_1137, Call(pt_32, V.Undef, NewObj(5).Put("sx", ((V)(1.3))).Put("sy", ((V)(0.28))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).Put("soft", ((V)(1D))).V)));
}
return default;
}, 1, "", true));
Invoke(o_1161, "push", Call(ball_14, V.Undef, ((V)((-17D))), ((V)((-1D))), ((V)((-42D))), ((V)(13D)), GetIdx(ST_1136, 2D), Call(pt_32, V.Undef, NewObj(5).Put("sx", ((V)(1.1))).Put("sy", ((V)(1.15))).Put("k", ((V)(5D))).Put("n", ((V)(12D))).Put("yaw", ((V)(0.6))).V)), Call(ball_14, V.Undef, ((V)((-15D))), ((V)(17D)), ((V)((-46D))), ((V)(10D)), GetIdx(ST_1136, 0D), Call(pt_32, V.Undef, NewObj(4).Put("sx", ((V)(1.15))).Put("sy", ((V)(0.9))).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V)), Call(ball_14, V.Undef, ((V)(17D)), ((V)((-1D))), ((V)((-43D))), ((V)(12D)), GetIdx(ST_1136, 4D), Call(pt_32, V.Undef, NewObj(5).Put("sx", ((V)(1.1))).Put("sy", ((V)(1.2))).Put("k", ((V)(5D))).Put("n", ((V)(12D))).Put("yaw", ((V)(1.4))).V)), Call(ball_14, V.Undef, ((V)(16D)), ((V)(16D)), ((V)((-47D))), ((V)(10D)), GetIdx(ST_1136, 1D), Call(pt_32, V.Undef, NewObj(4).Put("sx", ((V)(1.2))).Put("sy", ((V)(0.95))).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)(6D)), ((V)((-54D))), ((V)(15D)), GetIdx(ST_1136, 2D), Call(pt_32, V.Undef, NewObj(4).Put("sx", ((V)(1.5))).Put("sy", ((V)(1.5))).Put("k", ((V)(5D))).Put("n", ((V)(12D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(28D)), ((V)((-40D))), ((V)(22D)), ((V)(3D)), ((V)(14D)), ((V)("#7b766a")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(ball_14, V.Undef, ((V)((-8D))), ((V)(30D)), ((V)((-50D))), ((V)(7D)), GetIdx(ST_1136, 3D), Call(pt_32, V.Undef, NewObj(4).Put("sx", ((V)(1.3))).Put("sy", ((V)(0.7))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)), Call(ball_14, V.Undef, ((V)(10D)), ((V)(30D)), ((V)((-52D))), ((V)(6D)), GetIdx(ST_1136, 0D), Call(pt_32, V.Undef, NewObj(4).Put("sx", ((V)(1.2))).Put("sy", ((V)(0.8))).Put("k", ((V)(4D))).Put("n", ((V)(10D))).V)), Call(ball_14, V.Undef, ((V)((-17D))), ((V)(26D)), ((V)((-46D))), ((V)(6D)), MOSS_1137, Call(pt_32, V.Undef, NewObj(5).Put("sx", ((V)(1.3))).Put("sy", ((V)(0.3))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).Put("soft", ((V)(1D))).V)), Call(ball_14, V.Undef, ((V)(16D)), ((V)(25D)), ((V)((-47D))), ((V)(6D)), MOSS_1137, Call(pt_32, V.Undef, NewObj(5).Put("sx", ((V)(1.2))).Put("sy", ((V)(0.3))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).Put("soft", ((V)(1D))).V)));
return o_1161;
return default;
}, 0, "", true);
KOI_1140 = Arr(Arr(((V)("#f7f2ea")), ((V)("#e8452c")), ((V)(1D))), Arr(((V)("#ff8a2a")), ((V)("#ffb347")), ((V)(0D))), Arr(((V)("#1d1d22")), ((V)("#e8452c")), ((V)(2D))), Arr(((V)("#f2c14a")), ((V)("#fff1a8")), ((V)(0D))), Arr(((V)("#f7f2ea")), ((V)("#ff7a2a")), ((V)(1D))));
fish_1141 = Fn((V _arrowThis1184, int _argc1175, V c0_1181, V c1_1182, V kind_1183, V _a1180, V[] _rest1176) => {
return ((V)(string.Concat(string.Concat("<path d=\"M-6.5 0Q-3.8 -2.3 0 -2.7Q4.6 -2.4 6.6 0Q4.6 2.4 0 2.7Q-3.8 2.3 -6.5 0Z\" fill=\"", ToStr(c0_1181), "\"/>"), (SEqN(kind_1183, 1D) ? string.Concat("<path d=\"M-2 -2.2Q1 -3 3.4 -1.6Q1.8 0.4 -1.6 0.8Z\" fill=\"", ToStr(c1_1182), "\"/><path d=\"M3.6 -1.4Q5.6 -1 5.8 0.4Q4.4 1.4 3 0.6Z\" fill=\"", ToStr(c1_1182), "\"/>") : (SEqN(kind_1183, 2D) ? string.Concat("<path d=\"M-3.4 -1.6Q0 -2.8 3 -1Q1 1.8 -2.4 1.2Z\" fill=\"", ToStr(c1_1182), "\"/><path d=\"M2.4 1Q4.6 1.6 5.4 0.2\" stroke=\"#f7f2ea\" stroke-width=\"1.1\" fill=\"none\"/>") : string.Concat("<path d=\"M-3 -0.9Q1 -2 4.6 -0.4\" stroke=\"", ToStr(c1_1182), "\" stroke-width=\"0.9\" fill=\"none\" opacity=\"0.8\"/>"))), string.Concat("<g>", ToStr(Call(atV_42, V.Undef, ((V)("rotate")), Arr(((V)("-22")), ((V)("22")), ((V)("-22"))), ((V)(0.55)))), "<path d=\"M-6.2 0Q-8.8 -3.6 -11.2 -3.4Q-9.6 0 -11.2 3.4Q-8.8 3.6 -6.2 0Z\" fill=\"", ToStr(c0_1181), "\" opacity=\"0.88\"/></g>"), string.Concat("<path d=\"M1.2 -2.3Q-0.6 -5.2 -2.6 -4.8Q-1.2 -3 -0.6 -2.4Z\" fill=\"", ToStr(c0_1181), "\" opacity=\"0.8\"/><path d=\"M1.2 2.3Q-0.6 5.2 -2.6 4.8Q-1.2 3 -0.6 2.4Z\" fill=\"", ToStr(c0_1181), "\" opacity=\"0.8\"/><circle cx=\"4.6\" cy=\"-1\" r=\"0.4\" fill=\"#1d1e22\"/><circle cx=\"4.6\" cy=\"1\" r=\"0.4\" fill=\"#1d1e22\"/>"))));
}, 3, "", true);
loop_1142 = Fn((V _arrowThis1196, int _argc1185, V cx_1191, V cz_1192, V rx_1193, V rz_1194, V[] _rest1186) => {
V rev_1195 = default;
rev_1195 = (_argc1185 > 4 ? _rest1186[0] : V.Undef);
return ((V)(string.Concat("M", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(cx_1191) - ToNum(rx_1193)))))), " ", ToStr(cz_1192), "A", ToStr(rx_1193), " ", ToStr(rz_1194), " 0 1 ", NumStr((Truthy(rev_1195) ? 0D : 1D)), " ", ToStr(Call(f1_17, V.Undef, Add(cx_1191, rx_1193))), " ", ToStr(cz_1192), "A", ToStr(rx_1193), " ", ToStr(rz_1194), " 0 1 ", NumStr((Truthy(rev_1195) ? 0D : 1D)), " ", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(cx_1191) - ToNum(rx_1193)))))), " ", ToStr(cz_1192), "Z")));
}, 5, "", true);
PAD_1143 = Fn((V _arrowThis1205, int _argc1197, V r_1203, V a_1204, V _a1201, V _a1202, V[] _rest1198) => {
return ((V)(string.Concat("<g transform=\"rotate(", ToStr(a_1204), ")\"><path d=\"M0 0L", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(r_1203) * FdLibm.Cos(0.22)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(r_1203) * FdLibm.Sin(0.22)))))), "A", ToStr(r_1203), " ", ToStr(r_1203), " 0 1 1 ", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(r_1203) * FdLibm.Cos((-0.22))))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(r_1203) * FdLibm.Sin((-0.22))))))), "Z\" fill=\"url(#k7pad)\" stroke=\"#2f6a26\" stroke-width=\"0.35\"/>", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis1213, int _argc1206, V i_1212, V _a1209, V _a1210, V _a1211, V[] _rest1207) => {
double t_1214 = 0;
t_1214 = (0.5 + (ToNum(i_1212) * 0.8));
return ((V)(string.Concat("<path d=\"M0 0L", ToStr(Call(f1_17, V.Undef, ((V)(((ToNum(r_1203) * 0.85) * FdLibm.Cos(t_1214)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((ToNum(r_1203) * 0.85) * FdLibm.Sin(t_1214)))))), "\" stroke=\"#9ad06a\" stroke-width=\"0.25\" opacity=\"0.7\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))), "</g>")));
}, 2, "", true);
WAT_1144 = V.Null;
mkWater_1145 = Fn((V _arrowThis1222, int _argc1215, V p_1221, V _a1218, V _a1219, V _a1220, V[] _rest1216) => {
V RR_1223 = default;
V under_1224 = default;
V floor_1225 = default;
V over_1226 = default;
if (Truthy(WAT_1144)) {
return WAT_1144;
}
RR_1223 = Call(rng_19, V.Undef, ((V)("koiW")));
under_1224 = Invoke(Invoke(KOI_1140, "map", Fn((V _arrowThis1235, int _argc1227, V c_1233, V i_1234, V _a1231, V _a1232, V[] _rest1228) => {
V pth_1236 = default;
double d_1237 = 0;
double b_1238 = 0;
pth_1236 = Call(loop_1142, V.Undef, GetK(Arr(((V)((-14D))), ((V)(10D)), ((V)((-6D))), ((V)(16D)), ((V)(4D))), i_1234), GetK(Arr(((V)(4D)), ((V)((-6D))), ((V)(10D)), ((V)(4D)), ((V)((-2D)))), i_1234), GetK(Arr(((V)(26D)), ((V)(22D)), ((V)(30D)), ((V)(18D)), ((V)(34D))), i_1234), GetK(Arr(((V)(16D)), ((V)(14D)), ((V)(18D)), ((V)(12D)), ((V)(20D))), i_1234), ((V)((ToNum(i_1234) % 2D))));
d_1237 = (16D + (ToNum(i_1234) * 4D));
b_1238 = ((-ToNum(Call(RR_1223, V.Undef))) * d_1237);
return ((V)(string.Concat("<g opacity=\"0.3\" filter=\"url(#w7m)\"><animateMotion dur=\"", NumStr(d_1237), "s\"", ToStr(Call(B_39, V.Undef, ((V)(b_1238)))), " repeatCount=\"indefinite\" rotate=\"auto\" path=\"", ToStr(pth_1236), "\"/><g transform=\"translate(2.4 3.4) scale(1.45)\"><ellipse rx=\"7\" ry=\"2.6\" fill=\"#0a1a18\"/></g></g><g><animateMotion dur=\"", NumStr(d_1237), "s\"", ToStr(Call(B_39, V.Undef, ((V)(b_1238)))), " repeatCount=\"indefinite\" rotate=\"auto\" path=\"", ToStr(pth_1236), "\"/><g transform=\"scale(1.45)\">", ToStr(CallSpread(fish_1141, V.Undef, new ArrBuilder().Spread(c_1233).V)), "</g></g>")));
return default;
}, 2, "", true)), "join", ((V)("")));
floor_1225 = ((V)(JsStrBuf.Begin().V(Invoke(Call(rep_18, V.Undef, ((V)(30D)), Fn((V _arrowThis1246, int _argc1239, V i_1245, V _a1242, V _a1243, V _a1244, V[] _rest1240) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_17, V.Undef, ((V)((((ToNum(Call(RR_1223, V.Undef)) - 0.5) * RX_1132) * 1.7))))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, ((V)((((ToNum(Call(RR_1223, V.Undef)) - 0.5) * RZ_1133) * 1.7))))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((1.4 + (ToNum(Call(RR_1223, V.Undef)) * 2.2)))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((1D + (ToNum(Call(RR_1223, V.Undef)) * 1.6)))))), "\" fill=\"", ToStr(GetIdx(Arr(((V)("#6b6a5a")), ((V)("#8a8470")), ((V)("#4f5a48"))), (ToNum(i_1245) % 3D))), "\" opacity=\"0.5\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<ellipse rx=\"", NumStr((RX_1132 * 0.6)), "\" ry=\"", NumStr((RZ_1133 * 0.6)), "\" fill=\"#0c2622\" opacity=\"0.45\" filter=\"url(#w7m)\"/>")).End()));
over_1226 = Invoke(Invoke(Arr(Arr(((V)(22D)), ((V)(10D)), ((V)(6.5)), ((V)(30D))), Arr(((V)(30D)), ((V)((-6D))), ((V)(5D)), ((V)(160D))), Arr(((V)((-30D))), ((V)(14D)), ((V)(6D)), ((V)(250D))), Arr(((V)((-24D))), ((V)(24D)), ((V)(4.4)), ((V)(80D))), Arr(((V)(8D)), ((V)(26D)), ((V)(5.4)), ((V)(300D))), Arr(((V)((-36D))), ((V)((-6D))), ((V)(4.6)), ((V)(200D)))), "map", Fn((V _arrowThis1263, int _argc1247, V _a1249, V i_1253, V _a1251, V _a1252, V[] _rest1248) => {
V x_1256 = default;
V z_1258 = default;
V r_1260 = default;
V a_1262 = default;
{ V _t1254 = ListOf(_a1249);
{ V _t1255 = GetIdx(_t1254, 0D);
x_1256 = _t1255; }
{ V _t1257 = GetIdx(_t1254, 1D);
z_1258 = _t1257; }
{ V _t1259 = GetIdx(_t1254, 2D);
r_1260 = _t1259; }
{ V _t1261 = GetIdx(_t1254, 3D);
a_1262 = _t1261; }
}
return ((V)(string.Concat("<g transform=\"translate(", ToStr(x_1256), " ", ToStr(z_1258), ")\"><g>", ToStr(Call(atV_42, V.Undef, ((V)("rotate")), Arr(((V)("-6")), ((V)("6")), ((V)("-6"))), ((V)((9D + (ToNum(i_1253) * 1.7)))), ((V)((-ToNum(i_1253)))))), "<ellipse cx=\"0.8\" cy=\"1\" rx=\"", ToStr(Call(f1_17, V.Undef, r_1260)), "\" ry=\"", ToStr(Call(f1_17, V.Undef, r_1260)), "\" fill=\"#0c2622\" opacity=\"0.3\"/>", ToStr(Call(PAD_1143, V.Undef, r_1260, a_1262)), "</g></g>")));
}, 2, "", true)), "join", ((V)("")));
WAT_1144 = Call(water_68, V.Undef, p_1221, NewObj(12).Put("sh", NewObj(2).Put("rx", ((V)(RX_1132))).Put("rz", ((V)(RZ_1133))).V).Put("y", ((V)(WY_1134))).Put("pal", Get(WP_63, "koi")).Put("cs", ((V)(1.25))).Put("caust", ((V)(0.3))).Put("tint", ((V)(0.45))).Put("floor", floor_1225).Put("under", under_1224).Put("over", over_1226).Put("slow", ((V)(1D))).Put("rip", Arr(Arr(((V)(0D)), ((V)((-26D))), ((V)(12D)), ((V)(1.6)), ((V)(0D))), Arr(((V)((-4D))), ((V)((-24D))), ((V)(9D)), ((V)(1.9)), ((V)((-0.7)))), Arr(((V)(5D)), ((V)((-25D))), ((V)(8D)), ((V)(1.4)), ((V)((-0.3)))), Arr(((V)((-20D))), ((V)(6D)), ((V)(7D)), ((V)(3.2)), ((V)((-1D)))), Arr(((V)(14D)), ((V)(2D)), ((V)(6D)), ((V)(3.8)), ((V)((-2D)))))).Put("gl", ((V)(5D))).V);
return WAT_1144;
return default;
}, 1, "", true);
Set(D_1138, "layers", Arr(NewObj(2).Put("build", rocks_1139).Put("wrap", Fn((V _arrowThis1272, int _argc1264, V p_1270, V s_1271, V _a1268, V _a1269, V[] _rest1265) => {
return Add(Get(Call(mkWater_1145, V.Undef, p_1270), "svg"), s_1271);
}, 2, "wrap", true)).V));
Set(D_1138, "fx", Fn((V _arrowThis1280, int _argc1273, V c_1279, V _a1276, V _a1277, V _a1278, V[] _rest1274) => {
V p_1281 = default;
V k_1282 = default;
V W_1283 = default;
JsStrBuf f_1284 = null;
V defs_1285 = default;
V xs_1286 = default;
V lotus_1287 = default;
V RR_1288 = default;
p_1281 = Get(c_1279, "p");
k_1282 = Get(c_1279, "k");
W_1283 = Call(mkWater_1145, V.Undef, p_1281);
f_1284 = new JsStrBuf("");
defs_1285 = Add(Add(WDEF_69, Get(W_1283, "defs")), Call(L_47, V.Undef, ((V)("k7pad")), Arr(Arr(((V)(0D)), ((V)("#6fb04a"))), Arr(((V)(1D)), ((V)("#3f7f2c")))), ((V)("x1=\"0\" y1=\"0\" x2=\"1\" y2=\"1\""))));
xs_1286 = Arr(((V)((-8D))), ((V)((-4D))), ((V)(0D)), ((V)(4D)), ((V)(8D)));
f_1284.V(Call(fall_70, V.Undef, p_1281, k_1282, Invoke(xs_1286, "map", Fn((V _arrowThis1296, int _argc1289, V x_1295, V _a1292, V _a1293, V _a1294, V[] _rest1290) => {
return Arr(x_1295, ((V)(31D)), ((V)((-33D))));
}, 1, "", true)), Invoke(xs_1286, "map", Fn((V _arrowThis1304, int _argc1297, V x_1303, V _a1300, V _a1301, V _a1302, V[] _rest1298) => {
return Arr(((V)((ToNum(x_1303) * 1.05))), ((V)(26D)), ((V)((-29D))));
}, 1, "", true)), Invoke(xs_1286, "map", Fn((V _arrowThis1312, int _argc1305, V x_1311, V _a1308, V _a1309, V _a1310, V[] _rest1306) => {
return Arr(((V)((ToNum(x_1311) * 1.15))), ((V)((WY_1134 + 0.4))), ((V)((-26D))));
}, 1, "", true)), NewObj(1).Put("mw", ((V)(16D))).V));
f_1284.V(Call(fall_70, V.Undef, p_1281, k_1282, Arr(Arr(((V)((-19D))), ((V)(22D)), ((V)((-38D)))), Arr(((V)((-15D))), ((V)(22D)), ((V)((-37D))))), Arr(Arr(((V)((-20D))), ((V)(15D)), ((V)((-34D)))), Arr(((V)((-15D))), ((V)(15D)), ((V)((-33D))))), Arr(Arr(((V)((-21D))), ((V)((WY_1134 + 0.4))), ((V)((-31D)))), Arr(((V)((-15D))), ((V)((WY_1134 + 0.4))), ((V)((-31D))))), NewObj(3).Put("streaks", ((V)(3D))).Put("mist", ((V)(0D))).Put("op", ((V)(0.7))).V));
lotus_1287 = Fn((V _arrowThis1322, int _argc1313, V x_1319, V z_1320, V s_1321, V _a1318, V[] _rest1314) => {
V q_1323 = default;
JsStrBuf l_1324 = null;
q_1323 = Call(p_1281, V.Undef, x_1319, ((V)((WY_1134 + 0.6))), z_1320);
l_1324 = new JsStrBuf("");
Invoke(Arr(Arr(((V)((-50D))), ((V)("#f7b7cf"))), Arr(((V)(50D)), ((V)("#f7b7cf"))), Arr(((V)((-28D))), ((V)("#f49ac0"))), Arr(((V)(28D)), ((V)("#f49ac0"))), Arr(((V)((-8D))), ((V)("#fcd4e2"))), Arr(((V)(8D)), ((V)("#fcd4e2"))), Arr(((V)(0D)), ((V)("#ffe6ee")))), "forEach", Fn((V _arrowThis1336, int _argc1325, V _a1327, V _a1328, V _a1329, V _a1330, V[] _rest1326) => {
V a_1333 = default;
V col_1335 = default;
{ V _t1331 = ListOf(_a1327);
{ V _t1332 = GetIdx(_t1331, 0D);
a_1333 = _t1332; }
{ V _t1334 = GetIdx(_t1331, 1D);
col_1335 = _t1334; }
}
return ((V)(l_1324.S(string.Concat("<path d=\"M0 0Q-2.4 -3.4 0 -7.6Q2.4 -3.4 0 0Z\" fill=\"", ToStr(col_1335), "\" stroke=\"#d26a94\" stroke-width=\"0.25\" transform=\"rotate(", ToStr(a_1333), ")\"/>")).Str));
}, 1, "", true));
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(P2_21, V.Undef, q_1323)), ") scale(", ToStr(Call(n4_20, V.Undef, ((V)((ToNum(k_1282) * ToNum(s_1321)))))), ")\"><g>", ToStr(Call(atV_42, V.Undef, ((V)("rotate")), Arr(((V)("-3")), ((V)("3")), ((V)("-3"))), ((V)(9D)))), l_1324.Str, "<circle cy=\"-1.4\" r=\"1.3\" fill=\"#ffd23a\"/></g></g>")));
return default;
}, 3, "", true);
f_1284.V(Add(Call(lotus_1287, V.Undef, ((V)(22D)), ((V)(10D)), ((V)(1D))), Call(lotus_1287, V.Undef, ((V)((-30D))), ((V)(14D)), ((V)(0.85)))));
Invoke(Arr(Arr(((V)((-50D))), ((V)((-18D)))), Arr(((V)((-46D))), ((V)((-24D)))), Arr(((V)((-53D))), ((V)((-12D)))), Arr(((V)(44D)), ((V)((-26D))))), "forEach", Fn((V _arrowThis1349, int _argc1337, V _a1339, V i_1343, V _a1341, V _a1342, V[] _rest1338) => {
V b0_1350 = default;
double h_1351 = 0;
V x_1346 = default;
V z_1348 = default;
{ V _t1344 = ListOf(_a1339);
{ V _t1345 = GetIdx(_t1344, 0D);
x_1346 = _t1345; }
{ V _t1347 = GetIdx(_t1344, 1D);
z_1348 = _t1347; }
}
b0_1350 = Call(p_1281, V.Undef, x_1346, ((V)(4D)), z_1348);
h_1351 = ((30D + (ToNum(i_1343) * 4D)) * ToNum(k_1282));
f_1284.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_21, V.Undef, b0_1350)), ")\"><g>", ToStr(Call(atV_42, V.Undef, ((V)("rotate")), Arr(((V)("-3")), ((V)("4")), ((V)("-3"))), ((V)((3.6 + (ToNum(i_1343) * 0.4)))), ((V)((-ToNum(i_1343)))))), "<path d=\"M0 0Q", ToStr(Call(f1_17, V.Undef, ((V)((2D * ToNum(k_1282)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((-h_1351) * 0.5))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((1D * ToNum(k_1282)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((-h_1351))))), "\" stroke=\"#5a8a3a\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.8 * ToNum(k_1282)))))), "\" fill=\"none\"/><rect x=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.2 * ToNum(k_1282)))))), "\" y=\"", ToStr(Call(f1_17, V.Undef, ((V)(((-h_1351) * 0.92))))), "\" width=\"", ToStr(Call(f1_17, V.Undef, ((V)((1.8 * ToNum(k_1282)))))), "\" height=\"", ToStr(Call(f1_17, V.Undef, ((V)((7D * ToNum(k_1282)))))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.9 * ToNum(k_1282)))))), "\" fill=\"#7a4a26\"/><path d=\"M0 0Q", ToStr(Call(f1_17, V.Undef, ((V)(((-4D) * ToNum(k_1282)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((-h_1351) * 0.4))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((-6D) * ToNum(k_1282)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((-h_1351) * 0.6))))), "\" stroke=\"#6fa84a\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.9 * ToNum(k_1282)))))), "\" fill=\"none\"/></g></g>"));
return default;
}, 2, "", true));
RR_1288 = Call(rng_19, V.Undef, ((V)("tuft")));
Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis1359, int _argc1352, V i_1358, V _a1355, V _a1356, V _a1357, V[] _rest1353) => {
double t_1360 = 0;
V b0_1361 = default;
t_1360 = ((((ToNum(i_1358) / 9D) * 2D) * PI_34) + 0.4);
if ((FdLibm.Sin(t_1360) < (-0.8))) {
return default;
}
b0_1361 = Call(p_1281, V.Undef, ((V)(((RX_1132 + 4D) * FdLibm.Cos(t_1360)))), ((V)(6D)), ((V)(((RZ_1133 + 4D) * FdLibm.Sin(t_1360)))));
f_1284.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_21, V.Undef, b0_1361)), ") scale(", ToStr(Call(n4_20, V.Undef, k_1282)), ")\">", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis1369, int _argc1362, V j_1368, V _a1365, V _a1366, V _a1367, V[] _rest1363) => {
return ((V)(string.Concat("<path d=\"M0 0Q", ToStr(Call(f1_17, V.Undef, ((V)(((ToNum(j_1368) - 2D) * 1.2))))), " -3 ", ToStr(Call(f1_17, V.Undef, ((V)(((ToNum(j_1368) - 2D) * 2.2))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((-5D) - (ToNum(Call(RR_1288, V.Undef)) * 3D)))))), "\" stroke=\"", (NumTruthy((ToNum(j_1368) % 2D)) ? "#5f9a3e" : "#7ab854"), "\" stroke-width=\"0.7\" fill=\"none\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g>"));
return default;
}, 1, "", true));
return NewObj(3).Put("defs", defs_1285).Put("front", ((V)(f_1284.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1281, V.Undef, ((V)(((-RX_1132) - 8D))), ((V)(0D)), ((V)(((-RZ_1133) - 8D)))), Call(p_1281, V.Undef, ((V)((RX_1132 + 8D))), ((V)(0D)), ((V)((RZ_1133 + 8D)))), Call(p_1281, V.Undef, ((V)(((-RX_1132) - 8D))), ((V)(0D)), ((V)((RZ_1133 + 8D)))), Call(p_1281, V.Undef, ((V)((RX_1132 + 8D))), ((V)(0D)), ((V)(((-RZ_1133) - 8D)))), Call(p_1281, V.Undef, ((V)(0D)), ((V)(52D)), ((V)((-54D)))), Call(p_1281, V.Undef, ((V)((-52D))), ((V)(42D)), ((V)((-18D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1138;
return default;
}, 1, "", true));
Set(N_33, "lapPool", Fn((V _arrowThis1377, int _argc1370, V S_1376, V _a1373, V _a1374, V _a1375, V[] _rest1371) => {
double HX_1378 = 0;
double HZ_1379 = 0;
double IX_1380 = 0;
double IZ_1381 = 0;
double BH_1382 = 0;
double CY_1383 = 0;
double WY_1384 = 0;
V TRV_1385 = default;
V D_1386 = default;
V WAT_1387 = default;
V mkW_1388 = default;
HX_1378 = 90D;
HZ_1379 = 34D;
IX_1380 = 82D;
IZ_1381 = 26D;
BH_1382 = 16D;
CY_1383 = 19D;
WY_1384 = 15D;
TRV_1385 = ((V)("#e9dfc9"));
D_1386 = NewObj(3).Put("w", ((V)(190D))).Put("d", ((V)(80D))).Put("seats", Arr(NewObj(3).Put("x", ((V)((-52D)))).Put("z", ((V)((-6D)))).Put("h", ((V)(WY_1384))).V, NewObj(3).Put("x", ((V)((-14D)))).Put("z", ((V)(7D))).Put("h", ((V)(WY_1384))).V, NewObj(3).Put("x", ((V)(22D))).Put("z", ((V)((-6D)))).Put("h", ((V)(WY_1384))).V, NewObj(3).Put("x", ((V)(66D))).Put("z", ((V)(4D))).Put("h", ((V)(17.5))).V)).V;
Set(D_1386, "build", Fn((V _arrowThis1396, int _argc1389, V P_1395, V _a1392, V _a1393, V _a1394, V[] _rest1390) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((2D * HX_1378))), ((V)(BH_1382)), ((V)((2D * HZ_1379))), ((V)("#d4c7ac")), Call(cer_31, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(BH_1382)), ((V)(((IZ_1381 + HZ_1379) / 2D))), ((V)(((2D * HX_1378) + 1D))), ((V)(3D)), ((V)(((HZ_1379 - IZ_1381) + 1D))), TRV_1385, Call(cer_31, V.Undef, NewObj(1).Put("r", ((V)(1.4))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(BH_1382)), ((V)(((-(IZ_1381 + HZ_1379)) / 2D))), ((V)(((2D * HX_1378) + 1D))), ((V)(3D)), ((V)(((HZ_1379 - IZ_1381) + 1D))), TRV_1385, Call(cer_31, V.Undef, NewObj(1).Put("r", ((V)(1.4))).V)), Call(box_12, V.Undef, ((V)(((-(IX_1380 + HX_1378)) / 2D))), ((V)(BH_1382)), ((V)(0D)), ((V)(((HX_1378 - IX_1380) + 1D))), ((V)(3D)), ((V)((2D * IZ_1381))), TRV_1385, Call(cer_31, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(((IX_1380 + HX_1378) / 2D))), ((V)(BH_1382)), ((V)(0D)), ((V)(((HX_1378 - IX_1380) + 1D))), ((V)(3D)), ((V)((2D * IZ_1381))), TRV_1385, Call(cer_31, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
WAT_1387 = V.Null;
mkW_1388 = Fn((V _arrowThis1404, int _argc1397, V p_1403, V _a1400, V _a1401, V _a1402, V[] _rest1398) => {
V lanes_1405 = default;
V shelf_1406 = default;
V tiles_1407 = default;
V rope_1408 = default;
if (Truthy(WAT_1387)) {
return WAT_1387;
}
lanes_1405 = Invoke(Invoke(Arr(((V)((-13D))), ((V)(13D))), "map", Fn((V _arrowThis1416, int _argc1409, V z_1415, V _a1412, V _a1413, V _a1414, V[] _rest1410) => {
return ((V)(string.Concat("<rect x=\"", NumStr(((-IX_1380) + 8D)), "\" y=\"", NumStr((ToNum(z_1415) - 1.2)), "\" width=\"", NumStr(((2D * IX_1380) - 48D)), "\" height=\"2.4\" fill=\"#16467e\" opacity=\"0.6\"/><rect x=\"", NumStr(((-IX_1380) + 6D)), "\" y=\"", NumStr((ToNum(z_1415) - 4D)), "\" width=\"1.6\" height=\"8\" fill=\"#16467e\" opacity=\"0.6\"/><rect x=\"", NumStr((IX_1380 - 42D)), "\" y=\"", NumStr((ToNum(z_1415) - 4D)), "\" width=\"1.6\" height=\"8\" fill=\"#16467e\" opacity=\"0.6\"/>")));
}, 1, "", true)), "join", ((V)("")));
shelf_1406 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"46\" y=\"", NumStr((-IZ_1381)), "\" width=\"", NumStr((IX_1380 - 46D)), "\" height=\"", NumStr((2D * IZ_1381)), "\" fill=\"#c9f2fa\" opacity=\"0.55\"/><path d=\"M46 ", NumStr((-IZ_1381)), "V", NumStr(IZ_1381), "\" stroke=\"#ffffff\" stroke-width=\"1.2\" opacity=\"0.7\"/>")).V(Invoke(Invoke(Arr(((V)((-12D))), ((V)(12D))), "map", Fn((V _arrowThis1424, int _argc1417, V x_1423, V _a1420, V _a1421, V _a1422, V[] _rest1418) => {
return ((V)(string.Concat("<ellipse cx=\"", NumStr(((ToNum(x_1423) * 4D) - 20D)), "\" cy=\"", NumStr(((-IZ_1381) + 2D)), "\" rx=\"5\" ry=\"2.2\" fill=\"#fff8d0\" opacity=\"0.7\" filter=\"url(#w7m)\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
tiles_1407 = ((V)(string.Concat("<rect x=\"", NumStr((-IX_1380)), "\" y=\"", NumStr((-IZ_1381)), "\" width=\"", NumStr((2D * IX_1380)), "\" height=\"", NumStr((2D * IZ_1381)), "\" fill=\"url(#k7tile)\" opacity=\"0.35\"/>")));
rope_1408 = Invoke(Call(rep_18, V.Undef, ((V)(34D)), Fn((V _arrowThis1432, int _argc1425, V i_1431, V _a1428, V _a1429, V _a1430, V[] _rest1426) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_17, V.Undef, ((V)((((-IX_1380) + 4D) + (ToNum(i_1431) * 3.5)))))), "\" cy=\"0\" r=\"1.25\" fill=\"", ToStr(GetIdx(Arr(((V)("#e8343c")), ((V)("#ffffff")), ((V)("#1f5fb8"))), (System.Math.Floor((ToNum(i_1431) / 3D)) % 3D))), "\" stroke=\"#0a2a4a\" stroke-width=\"0.2\"/>")));
}, 1, "", true)), "join", ((V)("")));
WAT_1387 = Call(water_68, V.Undef, p_1403, NewObj(9).Put("sh", NewObj(3).Put("hx", ((V)(IX_1380))).Put("hz", ((V)(IZ_1381))).Put("r", ((V)(1.5))).V).Put("y", ((V)(WY_1384))).Put("rim", NewObj(2).Put("y", ((V)(CY_1383))).Put("sh", NewObj(3).Put("hx", ((V)(IX_1380))).Put("hz", ((V)(IZ_1381))).Put("r", ((V)(1.5))).V).V).Put("pal", Get(WP_63, "pool")).Put("cs", ((V)(1D))).Put("floor", Add(Add(tiles_1407, lanes_1405), shelf_1406)).Put("over", ((V)(string.Concat("<g>", ToStr(Call(atV_42, V.Undef, ((V)("translate")), Arr(((V)("0 0")), ((V)("0 0.6")), ((V)("0 0"))), ((V)(3.4)))), ToStr(rope_1408), "</g>")))).Put("rip", Arr(Arr(((V)((-40D))), ((V)((-10D))), ((V)(9D)), ((V)(3.2)), ((V)(0D))), Arr(((V)(12D)), ((V)(12D)), ((V)(8D)), ((V)(3.6)), ((V)((-1.6)))), Arr(((V)(64D)), ((V)((-4D))), ((V)(7D)), ((V)(2.8)), ((V)((-0.8)))))).Put("gl", ((V)(9D))).V);
return WAT_1387;
return default;
}, 1, "", true);
Set(D_1386, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1440, int _argc1433, V P_1439, V _a1436, V _a1437, V _a1438, V[] _rest1434) => {
V AL_1441 = default;
V o_1442 = default;
AL_1441 = ((V)("#f4f4f0"));
o_1442 = Arr();
Invoke(Arr(Arr(((V)(56D)), ((V)((-5.6)))), Arr(((V)(56D)), ((V)(5.6))), Arr(((V)(75D)), ((V)((-5.6)))), Arr(((V)(75D)), ((V)(5.6)))), "forEach", Fn((V _arrowThis1454, int _argc1443, V _a1445, V _a1446, V _a1447, V _a1448, V[] _rest1444) => {
V x_1451 = default;
V z_1453 = default;
{ V _t1449 = ListOf(_a1445);
{ V _t1450 = GetIdx(_t1449, 0D);
x_1451 = _t1450; }
{ V _t1452 = GetIdx(_t1449, 1D);
z_1453 = _t1452; }
}
return Invoke(o_1442, "push", Call(box_12, V.Undef, x_1451, ((V)((WY_1384 - 0.4))), z_1453, ((V)(1.4)), ((V)(2.2)), ((V)(1.4)), AL_1441, Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true));
Invoke(o_1442, "push", Call(prismZ_16, V.Undef, ((V)((-7D))), ((V)(7D)), Arr(Arr(((V)(53D)), ((V)(16.4))), Arr(((V)(77D)), ((V)(16.4))), Arr(((V)(77D)), ((V)(17.6))), Arr(((V)(62D)), ((V)(17.6))), Arr(((V)(56.6)), ((V)(25.6))), Arr(((V)(54.8)), ((V)(25D)))), AL_1441, Call(mt_29, V.Undef, NewObj(1).Put("shine", ((V)(1D))).V)), Call(prismZ_16, V.Undef, ((V)((-6.3))), ((V)(6.3)), Arr(Arr(((V)(61.8)), ((V)(17.4))), Arr(((V)(76.4)), ((V)(17.4))), Arr(((V)(76.4)), ((V)(19.8))), Arr(((V)(62.8)), ((V)(19.8))), Arr(((V)(57.8)), ((V)(26.8))), Arr(((V)(56.2)), ((V)(25.8)))), ((V)("#f0e9da")), NewObj(2).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).V), Call(ball_14, V.Undef, ((V)(58.8)), ((V)(26.2)), ((V)(0D)), ((V)(3.4)), ((V)("#2f86c8")), NewObj(7).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).Put("sx", ((V)(0.7))).Put("sy", ((V)(0.75))).Put("sz", ((V)(1.7))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V));
Invoke(o_1442, "push", Call(cyl_13, V.Undef, ((V)(79D)), ((V)((WY_1384 - 0.4))), ((V)((-19D))), ((V)(0.8)), ((V)(38D)), AL_1441, Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(cyl_13, V.Undef, ((V)(79D)), ((V)((WY_1384 + 34D))), ((V)((-19D))), ((V)(17D)), ((V)(5D)), ((V)("#f2ece0")), NewObj(4).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).Put("n", ((V)(16D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(1.2)), ((V)(0D)), ((V)(0.96))), Arr(((V)(5D)), ((V)(0D)), ((V)(0.06))))).V), Call(cyl_13, V.Undef, ((V)(79D)), ((V)((WY_1384 + 38.6))), ((V)((-19D))), ((V)(1.2)), ((V)(1.6)), AL_1441, Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(cyl_13, V.Undef, ((V)(68D)), ((V)((WY_1384 - 0.4))), ((V)((-14D))), ((V)(3.6)), ((V)(1.2)), ((V)("#f2ece0")), Call(cer_31, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(cyl_13, V.Undef, ((V)(68D)), ((V)((WY_1384 + 0.8))), ((V)((-14D))), ((V)(0.6)), ((V)(5D)), AL_1441, Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)), Call(cyl_13, V.Undef, ((V)(68D)), ((V)((WY_1384 + 5.8))), ((V)((-14D))), ((V)(4D)), ((V)(0.8)), AL_1441, Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)));
return o_1442;
return default;
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1463, int _argc1455, V p_1461, V s_1462, V _a1459, V _a1460, V[] _rest1456) => {
V W_1464 = default;
double k_1465 = 0;
V back_1466 = default;
W_1464 = Call(mkW_1388, V.Undef, p_1461);
k_1465 = ((ToNum(GetIdx(Call(p_1461, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D))), 1D)) - ToNum(GetIdx(Call(p_1461, V.Undef, ((V)(0D)), ((V)(1D)), ((V)(0D))), 1D))) / ToNum(Get(X_9, "CA")));
back_1466 = ((V)(string.Concat(string.Concat("<path d=\"", ToStr(Call(quad_56, V.Undef, p_1461, Arr(((V)((-IX_1380))), ((V)(CY_1383)), ((V)((-IZ_1381)))), Arr(((V)(IX_1380)), ((V)(CY_1383)), ((V)((-IZ_1381)))), Arr(((V)(IX_1380)), ((V)((WY_1384 - 0.5))), ((V)((-IZ_1381)))), Arr(((V)((-IX_1380))), ((V)((WY_1384 - 0.5))), ((V)((-IZ_1381)))))), "\" fill=\"#d9eef2\"/><g transform=\"", ToStr(Call(plane_23, V.Undef, p_1461, ((V)(((-IZ_1381) + 0.05))), ((V)((CY_1383 - 0.6))), ((V)((-IX_1380))))), "\"><rect x=\"0\" y=\"0\" width=\"", NumStr((2D * IX_1380)), "\" height=\"2.6\" fill=\"url(#k7mos)\"/></g>"), string.Concat("<path d=\"", ToStr(Call(quad_56, V.Undef, p_1461, Arr(((V)((-IX_1380))), ((V)(CY_1383)), ((V)((-IZ_1381)))), Arr(((V)((-IX_1380))), ((V)(CY_1383)), ((V)(IZ_1381))), Arr(((V)((-IX_1380))), ((V)((WY_1384 - 0.5))), ((V)(IZ_1381))), Arr(((V)((-IX_1380))), ((V)((WY_1384 - 0.5))), ((V)((-IZ_1381)))))), "\" fill=\"#c3dfe6\"/><g transform=\"", ToStr(Call(planeX_24, V.Undef, p_1461, ((V)(((-IX_1380) + 0.05))), ((V)((CY_1383 - 0.6))), ((V)((-IZ_1381))))), "\"><rect x=\"0\" y=\"0\" width=\"", NumStr((2D * IZ_1381)), "\" height=\"2.6\" fill=\"url(#k7mos)\"/></g>"))));
return ((V)(JsStrBuf.Begin().S(string.Concat("<g clip-path=\"url(#k7rim)\">", ToStr(back_1466), "</g>")).V(Get(W_1464, "svg")).V(s_1462).V(Invoke(Call(rep_18, V.Undef, ((V)(8D)), Fn((V _arrowThis1474, int _argc1467, V i_1473, V _a1470, V _a1471, V _a1472, V[] _rest1468) => {
double a0_1475 = 0;
double a1_1476 = 0;
V A_1477 = default;
V Bq_1478 = default;
V T_1479 = default;
if (NumTruthy((ToNum(i_1473) % 2D))) {
return ((V)(""));
}
a0_1475 = (((ToNum(i_1473) / 8D) * 2D) * PI_34);
a1_1476 = (a0_1475 + (PI_34 / 4D));
A_1477 = Call(p_1461, V.Undef, ((V)((79D + (16.6 * FdLibm.Cos(a0_1475))))), ((V)((WY_1384 + 34.2))), ((V)(((-19D) + (16.6 * FdLibm.Sin(a0_1475))))));
Bq_1478 = Call(p_1461, V.Undef, ((V)((79D + (16.6 * FdLibm.Cos(a1_1476))))), ((V)((WY_1384 + 34.2))), ((V)(((-19D) + (16.6 * FdLibm.Sin(a1_1476))))));
T_1479 = Call(p_1461, V.Undef, ((V)(79D)), ((V)((WY_1384 + 39D))), ((V)((-19D))));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(P2_21, V.Undef, T_1479)), "L", ToStr(Call(P2_21, V.Undef, A_1477)), "L", ToStr(Call(P2_21, V.Undef, Bq_1478)), "Z\" fill=\"#2f86c8\" opacity=\"0.85\"/>")));
return default;
}, 1, "", true)), "join", ((V)("")))).V(Call(Fn((V _arrowThis1486, int _argc1480, V _a1482, V _a1483, V _a1484, V _a1485, V[] _rest1481) => {
V q_1487 = default;
q_1487 = Call(p_1461, V.Undef, ((V)(68D)), ((V)((WY_1384 + 6.6))), ((V)((-14D))));
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(P2_21, V.Undef, q_1487)), ") scale(", ToStr(Call(n4_20, V.Undef, ((V)(k_1465)))), ")\"><path d=\"M-1.6 -5H1.6L1.1 0H-1.1Z\" fill=\"#8fe0f0\" opacity=\"0.8\"/><path d=\"M-1.4 -3.4H1.4L1.1 0H-1.1Z\" fill=\"#ff9a3a\"/><circle cx=\"1.4\" cy=\"-5\" r=\"0.9\" fill=\"#ffd23a\"/></g>")));
return default;
}, 0, "", true), V.Undef)).End()));
return default;
}, 2, "wrap", true)).V));
Set(D_1386, "fx", Fn((V _arrowThis1495, int _argc1488, V c_1494, V _a1491, V _a1492, V _a1493, V[] _rest1489) => {
V p_1496 = default;
V k_1497 = default;
V W_1498 = default;
JsStrBuf f_1499 = null;
V defs_1500 = default;
p_1496 = Get(c_1494, "p");
k_1497 = Get(c_1494, "k");
W_1498 = Call(mkW_1388, V.Undef, p_1496);
f_1499 = new JsStrBuf("");
defs_1500 = ((V)(JsStrBuf.Begin().V(Add(Add(WDEF_69, FDEF_72), Get(W_1498, "defs"))).S(string.Concat("<clipPath id=\"k7rim\"><path d=\"", ToStr(Call(sp_55, V.Undef, p_1496, Call(rrPts_52, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(IX_1380)), ((V)(IZ_1381)), ((V)(1.5))), ((V)(CY_1383)))), "\"/></clipPath>")).S(string.Concat("<pattern id=\"k7mos\" width=\"2.6\" height=\"2.6\" patternUnits=\"userSpaceOnUse\"><rect width=\"2.6\" height=\"2.6\" fill=\"#1f6fb0\"/><rect x=\"0.15\" y=\"0.15\" width=\"1.1\" height=\"1.1\" fill=\"#2f8fd0\"/><rect x=\"1.35\" y=\"1.35\" width=\"1.1\" height=\"1.1\" fill=\"#4fb0e8\"/><rect x=\"1.35\" y=\"0.15\" width=\"1.1\" height=\"1.1\" fill=\"#1a5f9a\"/></pattern>", "")).S(string.Concat("<pattern id=\"k7tile\" width=\"6\" height=\"6\" patternUnits=\"userSpaceOnUse\"><path d=\"M0 0H6M0 0V6\" stroke=\"#ffffff\" stroke-width=\"0.4\"/></pattern>", "")).End()));
Invoke(Arr(Arr(((V)((-60D))), ((V)((-8D)))), Arr(((V)((-20D))), ((V)(10D))), Arr(((V)(20D)), ((V)((-14D)))), Arr(((V)(52D)), ((V)(6D))), Arr(((V)((-40D))), ((V)(14D)))), "forEach", Fn((V _arrowThis1513, int _argc1501, V _a1503, V i_1507, V _a1505, V _a1506, V[] _rest1502) => {
V x_1510 = default;
V z_1512 = default;
{ V _t1508 = ListOf(_a1503);
{ V _t1509 = GetIdx(_t1508, 0D);
x_1510 = _t1509; }
{ V _t1511 = GetIdx(_t1508, 1D);
z_1512 = _t1511; }
}
return ((V)(f_1499.V(Call(smoke_77, V.Undef, Call(p_1496, V.Undef, x_1510, ((V)(WY_1384)), z_1512), k_1497, NewObj(10).Put("seed", ((V)(JsStrBuf.Begin().S("st").V(i_1507).End()))).Put("n", ((V)(3D))).Put("H", ((V)(26D))).Put("col", ((V)("#ffffff"))).Put("op", ((V)(0.32))).Put("d", ((V)((5D + (ToNum(i_1507) * 0.6))))).Put("r0", ((V)(2D))).Put("r1", ((V)(8D))).Put("drift", ((V)(10D))).Put("b", ((V)((-ToNum(i_1507))))).V)).Str));
}, 2, "", true));
Invoke(Arr(((V)((-72D))), ((V)((-62D)))), "forEach", Fn((V _arrowThis1521, int _argc1514, V x_1520, V _a1517, V _a1518, V _a1519, V[] _rest1515) => {
return ((V)(f_1499.V(Call(tube_60, V.Undef, Invoke(Invoke(Call(curve_61, V.Undef, Arr(x_1520, ((V)((CY_1383 + 0.5))), ((V)((IZ_1381 + 6D)))), Arr(x_1520, ((V)((CY_1383 + 14D))), ((V)((IZ_1381 + 6D)))), Arr(x_1520, ((V)((CY_1383 + 10D))), ((V)((IZ_1381 - 1D)))), ((V)(8D))), "concat", Invoke(Call(curve_61, V.Undef, Arr(x_1520, ((V)((CY_1383 + 10D))), ((V)((IZ_1381 - 1D)))), Arr(x_1520, ((V)((CY_1383 + 6D))), ((V)((IZ_1381 - 4D)))), Arr(x_1520, ((V)(4D)), ((V)((IZ_1381 - 4D)))), ((V)(5D))), "slice", ((V)(1D)))), "map", Fn((V _arrowThis1529, int _argc1522, V q_1528, V _a1525, V _a1526, V _a1527, V[] _rest1523) => {
return CallSpread(p_1496, V.Undef, new ArrBuilder().Spread(q_1528).V);
}, 1, "", true)), ((V)(1.5)), k_1497, ((V)("#cfd6dc")))).Str));
}, 1, "", true));
return NewObj(3).Put("defs", defs_1500).Put("front", ((V)(f_1499.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1496, V.Undef, ((V)((-HX_1378))), ((V)(0D)), ((V)((-HZ_1379)))), Call(p_1496, V.Undef, ((V)(HX_1378)), ((V)(0D)), ((V)(HZ_1379))), Call(p_1496, V.Undef, ((V)((-HX_1378))), ((V)(CY_1383)), ((V)(HZ_1379))), Call(p_1496, V.Undef, ((V)(HX_1378)), ((V)(CY_1383)), ((V)((-HZ_1379)))), Call(p_1496, V.Undef, ((V)((-HX_1378))), ((V)(50D)), ((V)((-HZ_1379)))), Call(p_1496, V.Undef, ((V)(HX_1378)), ((V)(46D)), ((V)((-HZ_1379)))), Call(p_1496, V.Undef, ((V)((-72D))), ((V)((CY_1383 + 15D))), ((V)((IZ_1381 + 6D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1386;
return default;
}, 1, "", true));
Set(N_33, "lagoon", Fn((V _arrowThis1537, int _argc1530, V S_1536, V _a1533, V _a1534, V _a1535, V[] _rest1531) => {
double IX_1538 = 0;
double IZ0_1539 = 0;
double IZ1_1540 = 0;
double H_1541 = 0;
double WY_1542 = 0;
V ST_1543 = default;
V ST2_1544 = default;
V ROCK_1545 = default;
V TEAK_1546 = default;
V LIME_1547 = default;
V D_1548 = default;
V WAT_1549 = default;
V SH_1550 = default;
V mkW_1551 = default;
IX_1538 = 90D;
IZ0_1539 = (-52D);
IZ1_1540 = 55D;
H_1541 = 30D;
WY_1542 = 29.3;
ST_1543 = ((V)("#3d434a"));
ST2_1544 = ((V)("#4a5058"));
ROCK_1545 = Arr(((V)("#5f5a52")), ((V)("#6e685e")), ((V)("#585248")), ((V)("#7a7266")));
TEAK_1546 = ((V)("#8a5a34"));
LIME_1547 = ((V)("#e9e1d0"));
D_1548 = NewObj(3).Put("w", ((V)(214D))).Put("d", ((V)(124D))).Put("seats", Arr(NewObj(3).Put("x", ((V)(34D))).Put("z", ((V)((-26D)))).Put("h", ((V)((WY_1542 + 1.4)))).V, NewObj(3).Put("x", ((V)(50D))).Put("z", ((V)((-26D)))).Put("h", ((V)((WY_1542 + 1.4)))).V, NewObj(3).Put("x", ((V)(66D))).Put("z", ((V)((-26D)))).Put("h", ((V)((WY_1542 + 1.4)))).V, NewObj(3).Put("x", ((V)((-10D)))).Put("z", ((V)(20D))).Put("h", ((V)(WY_1542))).V, NewObj(3).Put("x", ((V)(20D))).Put("z", ((V)(30D))).Put("h", ((V)(WY_1542))).V)).V;
Set(D_1548, "build", Fn((V _arrowThis1559, int _argc1552, V P_1558, V _a1555, V _a1556, V _a1557, V[] _rest1553) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(((2D * IX_1538) + 12D))), ((V)(2D)), ((V)(((IZ1_1540 - IZ0_1539) + 6D))), ((V)("#24303a")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((IZ0_1539 - 3D))), ((V)(((2D * IX_1538) + 12D))), ((V)(H_1541)), ((V)(6D)), ST_1543, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)), Call(box_12, V.Undef, ((V)(((-IX_1538) - 3D))), ((V)(0D)), ((V)(1.5)), ((V)(6D)), ((V)(H_1541)), ((V)(((IZ1_1540 - IZ0_1539) + 3D))), ST_1543, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)), Call(box_12, V.Undef, ((V)((IX_1538 + 3D))), ((V)(0D)), ((V)(1.5)), ((V)(6D)), ((V)((H_1541 - 0.9))), ((V)(((IZ1_1540 - IZ0_1539) + 3D))), ((V)("#2c3238")), Call(cer_31, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_12, V.Undef, ((V)((IX_1538 + 12D))), ((V)(0D)), ((V)(1.5)), ((V)(12D)), ((V)(9D)), ((V)(((IZ1_1540 - IZ0_1539) + 9D))), ST2_1544, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((IZ1_1540 + 1.5))), ((V)(((2D * IX_1538) + 12D))), ((V)(1.8)), ((V)(3D)), ((V)("#1c2026")), Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_12, V.Undef, ((V)(((-IX_1538) - 3D))), ((V)(H_1541)), ((V)(1.5)), ((V)(7D)), ((V)(1.4)), ((V)(((IZ1_1540 - IZ0_1539) + 4D))), ((V)("#5a6068")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(H_1541)), ((V)((IZ0_1539 - 3D))), ((V)(((2D * IX_1538) + 12D))), ((V)(1.4)), ((V)(7D)), ((V)("#5a6068")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
}, 1, "", true));
WAT_1549 = V.Null;
SH_1550 = NewObj(1).Put("pts", Arr(Arr(((V)((-IX_1538))), ((V)(IZ0_1539))), Arr(((V)((IX_1538 + 6D))), ((V)(IZ0_1539))), Arr(((V)((IX_1538 + 6D))), ((V)(IZ1_1540))), Arr(((V)((-IX_1538))), ((V)(IZ1_1540))))).V;
mkW_1551 = Fn((V _arrowThis1567, int _argc1560, V p_1566, V _a1563, V _a1564, V _a1565, V[] _rest1561) => {
V floor_1568 = default;
if (Truthy(WAT_1549)) {
return WAT_1549;
}
floor_1568 = ((V)(JsStrBuf.Begin().S(string.Concat("<rect x=\"", NumStr((-IX_1538)), "\" y=\"", NumStr(IZ0_1539), "\" width=\"", NumStr(((2D * IX_1538) + 6D)), "\" height=\"", NumStr((IZ1_1540 - IZ0_1539)), "\" fill=\"url(#k7lg)\" opacity=\"0.4\"/><rect x=\"18\" y=\"", NumStr(IZ0_1539), "\" width=\"64\" height=\"16\" fill=\"#1a4a5a\" opacity=\"0.5\"/>", ToStr(Invoke(Invoke(Arr(((V)(34D)), ((V)(50D)), ((V)(66D))), "map", Fn((V _arrowThis1576, int _argc1569, V x_1575, V _a1572, V _a1573, V _a1574, V[] _rest1570) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Add(x_1575, ((V)(1D)))), "\" cy=\"-24\" rx=\"4.6\" ry=\"4.6\" fill=\"#0a3a4a\" opacity=\"0.55\"/>")));
}, 1, "", true)), "join", ((V)("")))))).V(Invoke(Invoke(Arr(((V)((-40D))), ((V)(0D)), ((V)(40D))), "map", Fn((V _arrowThis1584, int _argc1577, V x_1583, V _a1580, V _a1581, V _a1582, V[] _rest1578) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(x_1583), "\" cy=\"", NumStr((IZ0_1539 + 3D)), "\" rx=\"7\" ry=\"2.4\" fill=\"#d8fbff\" opacity=\"0.6\" filter=\"url(#w7m)\"/>")));
}, 1, "", true)), "join", ((V)("")))).End()));
WAT_1549 = Call(water_68, V.Undef, p_1566, NewObj(9).Put("sh", SH_1550).Put("y", ((V)(WY_1542))).Put("rim", NewObj(1).Put("p3", Arr(Arr(((V)((-IX_1538))), ((V)((H_1541 + 1.4))), ((V)(IZ0_1539))), Arr(((V)((IX_1538 + 6D))), ((V)((H_1541 + 1.4))), ((V)(IZ0_1539))), Arr(((V)((IX_1538 + 6D))), ((V)(WY_1542)), ((V)(IZ0_1539))), Arr(((V)((IX_1538 + 6D))), ((V)(WY_1542)), ((V)(IZ1_1540))), Arr(((V)((-IX_1538))), ((V)((WY_1542 + 0.5))), ((V)(IZ1_1540))), Arr(((V)((-IX_1538))), ((V)((H_1541 + 1.4))), ((V)((IZ1_1540 - 1D)))))).V).Put("pal", Get(WP_63, "lagoon")).Put("cs", ((V)(1.2))).Put("floor", floor_1568).Put("flow", ((V)(1D))).Put("rip", Arr(Arr(((V)((-64D))), ((V)((-30D))), ((V)(12D)), ((V)(1.5)), ((V)(0D))), Arr(((V)((-58D))), ((V)((-28D))), ((V)(10D)), ((V)(1.8)), ((V)((-0.6)))), Arr(((V)((-70D))), ((V)((-26D))), ((V)(8D)), ((V)(1.3)), ((V)((-0.3)))), Arr(((V)(34D)), ((V)((-26D))), ((V)(9D)), ((V)(3D)), ((V)((-0.4)))), Arr(((V)(50D)), ((V)((-26D))), ((V)(9D)), ((V)(3.2)), ((V)((-1.4)))), Arr(((V)(66D)), ((V)((-26D))), ((V)(9D)), ((V)(2.8)), ((V)((-2.2)))), Arr(((V)(42D)), ((V)((-22D))), ((V)(6D)), ((V)(3D)), ((V)((-1D)))), Arr(((V)((-6D))), ((V)(18D)), ((V)(9D)), ((V)(3.4)), ((V)((-2D)))))).Put("gl", ((V)(10D))).V);
return WAT_1549;
return default;
}, 1, "", true);
Set(D_1548, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1592, int _argc1585, V P_1591, V _a1588, V _a1589, V _a1590, V[] _rest1586) => {
V o_1593 = default;
V RR_1594 = default;
o_1593 = Arr();
RR_1594 = Call(rng_19, V.Undef, ((V)("grot")));
Invoke(Arr(Arr(((V)((-72D))), ((V)(0D)), ((V)((-40D))), ((V)(22D)), ((V)(1.3)), GetIdx(ROCK_1545, 0D)), Arr(((V)((-52D))), ((V)(6D)), ((V)((-46D))), ((V)(17D)), ((V)(1.2)), GetIdx(ROCK_1545, 1D)), Arr(((V)((-84D))), ((V)(0D)), ((V)((-22D))), ((V)(13D)), ((V)(1.1)), GetIdx(ROCK_1545, 2D)), Arr(((V)((-64D))), ((V)(28D)), ((V)((-44D))), ((V)(14D)), ((V)(0.95)), GetIdx(ROCK_1545, 3D)), Arr(((V)((-80D))), ((V)(22D)), ((V)((-34D))), ((V)(10D)), ((V)(1D)), GetIdx(ROCK_1545, 1D)), Arr(((V)((-44D))), ((V)(22D)), ((V)((-48D))), ((V)(9D)), ((V)(1D)), GetIdx(ROCK_1545, 2D)), Arr(((V)((-60D))), ((V)(44D)), ((V)((-46D))), ((V)(9D)), ((V)(0.8)), GetIdx(ROCK_1545, 0D))), "forEach", Fn((V _arrowThis1614, int _argc1595, V _a1597, V _a1598, V _a1599, V _a1600, V[] _rest1596) => {
V x_1603 = default;
V y_1605 = default;
V z_1607 = default;
V r_1609 = default;
V sy_1611 = default;
V c2_1613 = default;
{ V _t1601 = ListOf(_a1597);
{ V _t1602 = GetIdx(_t1601, 0D);
x_1603 = _t1602; }
{ V _t1604 = GetIdx(_t1601, 1D);
y_1605 = _t1604; }
{ V _t1606 = GetIdx(_t1601, 2D);
z_1607 = _t1606; }
{ V _t1608 = GetIdx(_t1601, 3D);
r_1609 = _t1608; }
{ V _t1610 = GetIdx(_t1601, 4D);
sy_1611 = _t1610; }
{ V _t1612 = GetIdx(_t1601, 5D);
c2_1613 = _t1612; }
}
return Invoke(o_1593, "push", Call(ball_14, V.Undef, x_1603, ((V)(Max(ToNum(y_1605), (WY_1542 - ((ToNum(r_1609) * ToNum(sy_1611)) * 0.4))))), z_1607, r_1609, c2_1613, Call(pt_32, V.Undef, NewObj(5).Put("sx", ((V)(1.15))).Put("sy", sy_1611).Put("k", ((V)(5D))).Put("n", ((V)(12D))).Put("yaw", ((V)((ToNum(Call(RR_1594, V.Undef)) * 3D)))).V)));
}, 1, "", true));
Invoke(Arr(Arr(((V)((-66D))), ((V)(50D)), ((V)((-46D))), ((V)(9D))), Arr(((V)((-84D))), ((V)(31D)), ((V)((-30D))), ((V)(6D))), Arr(((V)((-46D))), ((V)(31D)), ((V)((-46D))), ((V)(6D)))), "forEach", Fn((V _arrowThis1630, int _argc1615, V _a1617, V _a1618, V _a1619, V _a1620, V[] _rest1616) => {
V x_1623 = default;
V y_1625 = default;
V z_1627 = default;
V r_1629 = default;
{ V _t1621 = ListOf(_a1617);
{ V _t1622 = GetIdx(_t1621, 0D);
x_1623 = _t1622; }
{ V _t1624 = GetIdx(_t1621, 1D);
y_1625 = _t1624; }
{ V _t1626 = GetIdx(_t1621, 2D);
z_1627 = _t1626; }
{ V _t1628 = GetIdx(_t1621, 3D);
r_1629 = _t1628; }
}
return Invoke(o_1593, "push", Call(ball_14, V.Undef, x_1623, y_1625, z_1627, r_1629, ((V)("#4f8a3a")), Call(pt_32, V.Undef, NewObj(5).Put("sx", ((V)(1.3))).Put("sy", ((V)(0.32))).Put("k", ((V)(3D))).Put("n", ((V)(10D))).Put("soft", ((V)(1D))).V)));
}, 1, "", true));
Invoke(o_1593, "push", Call(box_12, V.Undef, ((V)(50D)), ((V)((WY_1542 - 0.5))), ((V)((-42D))), ((V)(64D)), ((V)(11D)), ((V)(12D)), LIME_1547, Call(cer_31, V.Undef, NewObj(1).Put("r", ((V)(1.5))).V)), Call(box_12, V.Undef, ((V)(50D)), ((V)((WY_1542 + 10.5))), ((V)((-41D))), ((V)(70D)), ((V)(2.4)), ((V)(16D)), TEAK_1546, Call(wd_30, V.Undef, NewObj(1).Put("r", ((V)(1.2))).V)));
Invoke(Arr(((V)(34D)), ((V)(50D)), ((V)(66D))), "forEach", Fn((V _arrowThis1638, int _argc1631, V x_1637, V _a1634, V _a1635, V _a1636, V[] _rest1632) => {
return Invoke(o_1593, "push", Call(cyl_13, V.Undef, x_1637, ((V)((WY_1542 - 0.6))), ((V)((-26D))), ((V)(4.8)), ((V)(2.4)), ((V)("#2fa8b8")), Call(cer_31, V.Undef, NewObj(3).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(1.6)), ((V)(0D)), ((V)(1D))), Arr(((V)(2.4)), ((V)(0D)), ((V)(0.84))))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, x_1637, ((V)((WY_1542 + 1.7))), ((V)((-26D))), ((V)(3.9)), ((V)(1D)), ((V)("#f4efe6")), NewObj(4).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(0.6)), ((V)(0D)), ((V)(1D))), Arr(((V)(1D)), ((V)(0D)), ((V)(0.8))))).V));
}, 1, "", true));
return o_1593;
return default;
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1647, int _argc1639, V p_1645, V s_1646, V _a1643, V _a1644, V[] _rest1640) => {
return Add(Get(Call(mkW_1551, V.Undef, p_1645), "svg"), s_1646);
}, 2, "wrap", true)).V));
Set(D_1548, "fx", Fn((V _arrowThis1655, int _argc1648, V c_1654, V _a1651, V _a1652, V _a1653, V[] _rest1649) => {
V p_1656 = default;
V k_1657 = default;
V W_1658 = default;
JsStrBuf f_1659 = null;
V un_1660 = default;
JsStrBuf defs_1661 = null;
V drink_1662 = default;
p_1656 = Get(c_1654, "p");
k_1657 = Get(c_1654, "k");
W_1658 = Call(mkW_1551, V.Undef, p_1656);
f_1659 = new JsStrBuf("");
un_1660 = ((V)(""));
defs_1661 = new JsStrBuf(JsStrBuf.Begin().V(Add(Add(Add(Add(WDEF_69, Get(W_1658, "defs")), Call(L_47, V.Undef, ((V)("k7lg")), Arr(Arr(((V)(0D)), ((V)("#0a4a62"))), Arr(((V)(1D)), ((V)("#2ad0e8")))))), Call(L_47, V.Undef, ((V)("k7gw")), Arr(Arr(((V)(0D)), ((V)("#5fe0f0")), ((V)(0.5))), Arr(((V)(0.25)), ((V)("#2ab4d0")), ((V)(0.62))), Arr(((V)(1D)), ((V)("#06506a")), ((V)(0.88)))))), Call(L_47, V.Undef, ((V)("k7gl")), Arr(Arr(((V)(0D)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(0.48)), ((V)("#ffffff")), ((V)(0D))), Arr(((V)(0.5)), ((V)("#ffffff")), ((V)(0.5))), Arr(((V)(0.56)), ((V)("#ffffff")), ((V)(0.06))), Arr(((V)(0.62)), ((V)("#ffffff")), ((V)(0.25))), Arr(((V)(0.66)), ((V)("#ffffff")), ((V)(0D)))), ((V)("x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0.6\""))))).S(string.Concat("<pattern id=\"k7ray\" width=\"18\" height=\"", ToStr(Call(f1_17, V.Undef, ((V)(WY_1542)))), "\" patternUnits=\"userSpaceOnUse\"><path d=\"M3 0Q6 ", ToStr(Call(f1_17, V.Undef, ((V)((WY_1542 * 0.5))))), " 2 ", ToStr(Call(f1_17, V.Undef, ((V)(WY_1542)))), "M11 0Q8 ", ToStr(Call(f1_17, V.Undef, ((V)((WY_1542 * 0.4))))), " 13 ", ToStr(Call(f1_17, V.Undef, ((V)(WY_1542)))), "\" stroke=\"#d8fbff\" stroke-width=\"1.6\" fill=\"none\" opacity=\"0.45\"/><animateTransform attributeName=\"patternTransform\" type=\"translate\" values=\"0 0;18 0\" dur=\"5s\" repeatCount=\"indefinite\"/></pattern>")).End());
{
JsStrBuf g_1663 = null;
V RR_1664 = default;
g_1663 = new JsStrBuf(string.Concat(string.Concat("<rect x=\"0\" y=\"0\" width=\"", NumStr(((2D * IX_1538) + 6D)), "\" height=\"", ToStr(Call(f1_17, V.Undef, ((V)(WY_1542)))), "\" fill=\"url(#k7gw)\"/><rect x=\"0\" y=\"0\" width=\"", NumStr(((2D * IX_1538) + 6D)), "\" height=\"", ToStr(Call(f1_17, V.Undef, ((V)(WY_1542)))), "\" fill=\"url(#k7ray)\"/>"), string.Concat("<path d=\"M0 0.4Q20 -0.6 40 0.4T80 0.4T120 0.4T160 0.4T200 0.4\" stroke=\"#ffffff\" stroke-width=\"0.8\" fill=\"none\" opacity=\"0.8\">", ToStr(Call(atV_42, V.Undef, ((V)("translate")), Arr(((V)("0 0")), ((V)("-20 0")), ((V)("0 0"))), ((V)(4D)))), "</path>")));
RR_1664 = Call(rng_19, V.Undef, ((V)("bub")));
Call(rep_18, V.Undef, ((V)(14D)), Fn((V _arrowThis1672, int _argc1665, V i_1671, V _a1668, V _a1669, V _a1670, V[] _rest1666) => {
double x_1673 = 0;
double d_1674 = 0;
double b_1675 = 0;
x_1673 = (8D + (ToNum(Call(RR_1664, V.Undef)) * ((2D * IX_1538) - 10D)));
d_1674 = (3D + (ToNum(Call(RR_1664, V.Undef)) * 3D));
b_1675 = ((-ToNum(Call(RR_1664, V.Undef))) * d_1674);
g_1663.S(string.Concat("<circle cx=\"", ToStr(Call(f1_17, V.Undef, ((V)(x_1673)))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, ((V)(WY_1542)))), "\" r=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.5 + (ToNum(Call(RR_1664, V.Undef)) * 0.8)))))), "\" fill=\"none\" stroke=\"#e8fdff\" stroke-width=\"0.3\"><animate attributeName=\"cy\" values=\"", ToStr(Call(f1_17, V.Undef, ((V)((WY_1542 - 1D))))), ";1\" dur=\"", ToStr(Call(n4_20, V.Undef, ((V)(d_1674)))), "s\"", ToStr(Call(B_39, V.Undef, ((V)(b_1675)))), " repeatCount=\"indefinite\"/><animate attributeName=\"cx\" values=\"", ToStr(Call(f1_17, V.Undef, ((V)(x_1673)))), ";", ToStr(Call(f1_17, V.Undef, ((V)((x_1673 + 2D))))), ";", ToStr(Call(f1_17, V.Undef, ((V)((x_1673 - 1D))))), "\" dur=\"", ToStr(Call(n4_20, V.Undef, ((V)(d_1674)))), "s\"", ToStr(Call(B_39, V.Undef, ((V)(b_1675)))), " repeatCount=\"indefinite\"/></circle>"));
return default;
}, 1, "", true));
g_1663.S(string.Concat("<rect x=\"0\" y=\"", ToStr(Call(f1_17, V.Undef, ((V)((WY_1542 - 1.6))))), "\" width=\"", NumStr(((2D * IX_1538) + 6D)), "\" height=\"1.2\" fill=\"#8af6ff\" opacity=\"0.9\"/><rect x=\"0\" y=\"0\" width=\"", NumStr(((2D * IX_1538) + 6D)), "\" height=\"", ToStr(Call(f1_17, V.Undef, ((V)(WY_1542)))), "\" fill=\"url(#k7gl)\"/><rect x=\"0\" y=\"0\" width=\"", NumStr(((2D * IX_1538) + 6D)), "\" height=\"", ToStr(Call(f1_17, V.Undef, ((V)(WY_1542)))), "\" fill=\"none\" stroke=\"#e8fbff\" stroke-width=\"0.5\" opacity=\"0.6\"/>"));
f_1659.S(string.Concat("<g transform=\"", ToStr(Call(plane_23, V.Undef, p_1656, ((V)((IZ1_1540 + 0.2))), ((V)(WY_1542)), ((V)((-IX_1538))))), "\">", g_1663.Str, "</g>")).S(string.Concat("<path d=\"", ToStr(Call(quad_56, V.Undef, p_1656, Arr(((V)(((-IX_1538) - 6D))), ((V)((WY_1542 + 0.5))), ((V)((IZ1_1540 + 0.3)))), Arr(((V)((IX_1538 + 6D))), ((V)((WY_1542 + 0.5))), ((V)((IZ1_1540 + 0.3)))), Arr(((V)((IX_1538 + 6D))), ((V)((WY_1542 - 0.6))), ((V)((IZ1_1540 + 0.3)))), Arr(((V)(((-IX_1538) - 6D))), ((V)((WY_1542 - 0.6))), ((V)((IZ1_1540 + 0.3)))))), "\" fill=\"#cfd6dc\"/>"));
}
{
V zs_1676 = default;
V T_1677 = default;
zs_1676 = Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis1685, int _argc1678, V i_1684, V _a1681, V _a1682, V _a1683, V[] _rest1679) => {
return ((V)(((IZ0_1539 + 2D) + ((ToNum(i_1684) * ((IZ1_1540 - IZ0_1539) - 4D)) / 8D))));
}, 1, "", true));
f_1659.V(Call(fall_70, V.Undef, p_1656, k_1657, Invoke(zs_1676, "map", Fn((V _arrowThis1693, int _argc1686, V z_1692, V _a1689, V _a1690, V _a1691, V[] _rest1687) => {
return Arr(((V)((IX_1538 + 6D))), ((V)(WY_1542)), z_1692);
}, 1, "", true)), Invoke(zs_1676, "map", Fn((V _arrowThis1701, int _argc1694, V z_1700, V _a1697, V _a1698, V _a1699, V[] _rest1695) => {
return Arr(((V)((IX_1538 + 6.6))), ((V)(20D)), z_1700);
}, 1, "", true)), Invoke(zs_1676, "map", Fn((V _arrowThis1709, int _argc1702, V z_1708, V _a1705, V _a1706, V _a1707, V[] _rest1703) => {
return Arr(((V)((IX_1538 + 8D))), ((V)(9D)), z_1708);
}, 1, "", true)), NewObj(3).Put("streaks", ((V)(22D))).Put("mist", ((V)(0D))).Put("op", ((V)(0.65))).V));
T_1677 = Call(water_68, V.Undef, p_1656, NewObj(6).Put("sh", NewObj(1).Put("pts", Arr(Arr(((V)((IX_1538 + 7D))), ((V)((IZ0_1539 - 2D)))), Arr(((V)((IX_1538 + 17D))), ((V)((IZ0_1539 - 2D)))), Arr(((V)((IX_1538 + 17D))), ((V)((IZ1_1540 + 4D)))), Arr(((V)((IX_1538 + 7D))), ((V)((IZ1_1540 + 4D)))))).V).Put("y", ((V)(8.6))).Put("pal", Get(WP_63, "lagoon")).Put("flow", ((V)(1D))).Put("gl", ((V)(3D))).Put("wave", ((V)(0.7))).V);
defs_1661.V(Get(T_1677, "defs"));
f_1659.V(Get(T_1677, "svg"));
}
{
V cq_1710 = default;
V xs_1711 = default;
cq_1710 = Call(p_1656, V.Undef, ((V)((-62D))), ((V)(36D)), ((V)((-27D))));
f_1659.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(cq_1710, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(cq_1710, 1D))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((11D * ToNum(k_1657)))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((8D * ToNum(k_1657)))))), "\" fill=\"#1a1612\" opacity=\"0.92\"/><ellipse cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(cq_1710, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, Add(GetIdx(cq_1710, 1D), ((V)((3D * ToNum(k_1657))))))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((8D * ToNum(k_1657)))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((4D * ToNum(k_1657)))))), "\" fill=\"#2a8aa0\" opacity=\"0.5\"/>"));
xs_1711 = Arr(((V)((-74D))), ((V)((-68D))), ((V)((-62D))), ((V)((-56D))), ((V)((-50D))));
f_1659.V(Call(fall_70, V.Undef, p_1656, k_1657, Invoke(xs_1711, "map", Fn((V _arrowThis1719, int _argc1712, V x_1718, V _a1715, V _a1716, V _a1717, V[] _rest1713) => {
return Arr(x_1718, ((V)(50D)), ((V)((-32D))));
}, 1, "", true)), Invoke(xs_1711, "map", Fn((V _arrowThis1727, int _argc1720, V x_1726, V _a1723, V _a1724, V _a1725, V[] _rest1721) => {
return Arr(x_1726, ((V)(44D)), ((V)((-24D))));
}, 1, "", true)), Invoke(xs_1711, "map", Fn((V _arrowThis1735, int _argc1728, V x_1734, V _a1731, V _a1732, V _a1733, V[] _rest1729) => {
return Arr(x_1734, ((V)((WY_1542 + 0.4))), ((V)((-20D))));
}, 1, "", true)), NewObj(2).Put("mw", ((V)(22D))).Put("op", ((V)(0.7))).V));
}
Invoke(Arr(Arr(((V)((-66D))), ((V)(54D)), ((V)((-46D))), ((V)(0D))), Arr(((V)((-86D))), ((V)(34D)), ((V)((-30D))), ((V)(1D))), Arr(((V)((-46D))), ((V)(34D)), ((V)((-48D))), ((V)(2D)))), "forEach", Fn((V _arrowThis1751, int _argc1736, V _a1738, V _a1739, V _a1740, V _a1741, V[] _rest1737) => {
V q_1752 = default;
V x_1744 = default;
V y_1746 = default;
V z_1748 = default;
V i_1750 = default;
{ V _t1742 = ListOf(_a1738);
{ V _t1743 = GetIdx(_t1742, 0D);
x_1744 = _t1743; }
{ V _t1745 = GetIdx(_t1742, 1D);
y_1746 = _t1745; }
{ V _t1747 = GetIdx(_t1742, 2D);
z_1748 = _t1747; }
{ V _t1749 = GetIdx(_t1742, 3D);
i_1750 = _t1749; }
}
q_1752 = Call(p_1656, V.Undef, x_1744, y_1746, z_1748);
f_1659.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_21, V.Undef, q_1752)), ") scale(", ToStr(Call(n4_20, V.Undef, k_1657)), ")\"><g>", ToStr(Call(atV_42, V.Undef, ((V)("rotate")), Arr(((V)("-4")), ((V)("4")), ((V)("-4"))), Add(((V)(4D)), i_1750), ((V)((-ToNum(i_1750)))))), ToStr(Invoke(Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis1760, int _argc1753, V j_1759, V _a1756, V _a1757, V _a1758, V[] _rest1754) => {
return ((V)(string.Concat("<path d=\"M0 0Q", ToStr(Call(f1_17, V.Undef, ((V)((FdLibm.Cos(((-PI_34) * (0.1 + (ToNum(j_1759) * 0.16)))) * 8D))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((FdLibm.Sin(((-PI_34) * (0.1 + (ToNum(j_1759) * 0.16)))) * 10D) - 2D))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((FdLibm.Cos(((-PI_34) * (0.1 + (ToNum(j_1759) * 0.16)))) * 16D))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((FdLibm.Sin(((-PI_34) * (0.1 + (ToNum(j_1759) * 0.16)))) * 12D) + 4D))))), "\" stroke=\"", (NumTruthy((ToNum(j_1759) % 2D)) ? "#3f8a34" : "#5aaa44"), "\" stroke-width=\"2.2\" stroke-linecap=\"round\" fill=\"none\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g></g>"));
return default;
}, 1, "", true));
drink_1662 = Fn((V _arrowThis1770, int _argc1761, V x_1767, V z_1768, V kind_1769, V _a1766, V[] _rest1762) => {
V q_1771 = default;
q_1771 = Call(p_1656, V.Undef, x_1767, ((V)((WY_1542 + 12.9))), z_1768);
return ((V)(string.Concat(string.Concat("<g transform=\"translate(", ToStr(Call(P2_21, V.Undef, q_1771)), ") scale(", ToStr(Call(n4_20, V.Undef, k_1657)), ")\">"), (Truthy(kind_1769) ? "<ellipse cx=\"0\" cy=\"-2.6\" rx=\"2.8\" ry=\"2.8\" fill=\"#7a4a26\"/><ellipse cx=\"-0.8\" cy=\"-3.4\" rx=\"1\" ry=\"0.7\" fill=\"#b07a4a\"/><path d=\"M0.6 -5L2.4 -9\" stroke=\"#ff4fb8\" stroke-width=\"0.4\"/>" : "<path d=\"M-2 -7.6H2L1 -2.4H-1Z\" fill=\"#ff9a3a\" opacity=\"0.9\"/><path d=\"M-2 -7.6H2L1 -2.4H-1Z\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.3\" opacity=\"0.8\"/><path d=\"M0 -2.4V0M-1.4 0H1.4\" stroke=\"#ffffff\" stroke-width=\"0.35\"/><path d=\"M0.5 -7.6L2.6 -11\" stroke=\"#7a4a26\" stroke-width=\"0.25\"/><path d=\"M0.4 -11.6Q2.6 -13.2 4.8 -11.6Z\" fill=\"#ffd23a\"/><circle cx=\"-1.2\" cy=\"-7.8\" r=\"0.8\" fill=\"#ff5a3a\"/>"), "</g>")));
return default;
}, 3, "", true);
f_1659.V(Add(Add(Add(Call(drink_1662, V.Undef, ((V)(36D)), ((V)((-42D))), ((V)(0D))), Call(drink_1662, V.Undef, ((V)(48D)), ((V)((-40D))), ((V)(1D)))), Call(drink_1662, V.Undef, ((V)(60D)), ((V)((-42D))), ((V)(0D)))), Call(drink_1662, V.Undef, ((V)(70D)), ((V)((-40D))), ((V)(1D)))));
return NewObj(3).Put("defs", ((V)(defs_1661.Str))).Put("front", ((V)(f_1659.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1656, V.Undef, ((V)(((-IX_1538) - 7D))), ((V)(0D)), ((V)((IZ0_1539 - 6D)))), Call(p_1656, V.Undef, ((V)((IX_1538 + 18D))), ((V)(0D)), ((V)((IZ1_1540 + 6D)))), Call(p_1656, V.Undef, ((V)(((-IX_1538) - 7D))), ((V)(0D)), ((V)((IZ1_1540 + 6D)))), Call(p_1656, V.Undef, ((V)((IX_1538 + 18D))), ((V)(0D)), ((V)((IZ0_1539 - 6D)))), Call(p_1656, V.Undef, ((V)((-62D))), ((V)(70D)), ((V)((-46D)))), Call(p_1656, V.Undef, ((V)((-90D))), ((V)(50D)), ((V)((-30D)))), Call(p_1656, V.Undef, ((V)((IX_1538 + 18D))), ((V)(H_1541)), ((V)((IZ0_1539 - 6D))))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1548;
return default;
}, 1, "", true));
Set(N_33, "marbleFount", Fn((V _arrowThis1779, int _argc1772, V S_1778, V _a1775, V _a1776, V _a1777, V[] _rest1773) => {
double BR_1780 = 0;
double BI_1781 = 0;
double BY_1782 = 0;
double BH_1783 = 0;
double BW_1784 = 0;
double MY_1785 = 0;
double MR_1786 = 0;
double TY_1787 = 0;
double TR_1788 = 0;
V D_1789 = default;
V balu_1790 = default;
V swan_1791 = default;
V SW_1792 = default;
V WB_1793 = default;
V WM_1794 = default;
V WT_1795 = default;
V mk_1796 = default;
BR_1780 = 58D;
BI_1781 = 50D;
BY_1782 = 2.5;
BH_1783 = 16D;
BW_1784 = 15.5;
MY_1785 = 47.4;
MR_1786 = 26D;
TY_1787 = 70D;
TR_1788 = 13.6;
D_1789 = NewObj(3).Put("w", ((V)(128D))).Put("d", ((V)(128D))).Put("round", ((V)(1D))).V;
balu_1790 = Fn((V _arrowThis1806, int _argc1797, V y_1803, V r_1804, V h_1805, V _a1802, V[] _rest1798) => {
return Call(cyl_13, V.Undef, ((V)(0D)), y_1803, ((V)(0D)), r_1804, h_1805, MARB_37, Call(cer_31, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.25))), Arr(((V)((ToNum(h_1805) * 0.12))), ((V)(0D)), ((V)(0.9))), Arr(((V)((ToNum(h_1805) * 0.45))), ((V)(0D)), ((V)(0.72))), Arr(((V)((ToNum(h_1805) * 0.75))), ((V)(0D)), ((V)(0.82))), Arr(((V)((ToNum(h_1805) * 0.9))), ((V)(0D)), ((V)(1.05))), Arr(h_1805, ((V)(0D)), ((V)(1.2))))).V));
}, 3, "", true);
Set(D_1789, "build", Fn((V _arrowThis1814, int _argc1807, V P_1813, V _a1810, V _a1811, V _a1812, V[] _rest1808) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((BR_1780 + 5D))), ((V)(BY_1782)), ((V)("#e2ddd3")), Call(cer_31, V.Undef, NewObj(1).Put("n", ((V)(48D))).V)), Call(arcW_15, V.Undef, ((V)(0D)), ((V)(BY_1782)), ((V)(0D)), ((V)(BR_1780)), ((V)(BR_1780)), ((V)((BR_1780 - BI_1781))), ((V)(BH_1783)), ((V)(4.4)), ((V)((4.4 + (2D * PI_34)))), MARB_37, Call(cer_31, V.Undef, NewObj(1).Put("n", ((V)(52D))).V)), Call(arcW_15, V.Undef, ((V)(0D)), ((V)((BY_1782 + BH_1783))), ((V)(0D)), ((V)((BR_1780 + 1D))), ((V)((BR_1780 + 1D))), ((V)(((BR_1780 - BI_1781) + 1.6))), ((V)(1.6)), ((V)(4.4)), ((V)((4.4 + (2D * PI_34)))), GOLD_35, Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(52D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
swan_1791 = Fn((V _arrowThis1825, int _argc1815, V o_1821, V x_1822, V z_1823, V d_1824, V[] _rest1816) => {
double by_1826 = 0;
by_1826 = (BW_1784 - 0.6);
Invoke(o_1821, "push", Call(ball_14, V.Undef, x_1822, ((V)(by_1826)), z_1823, ((V)(7D)), GOLD_35, Call(mt_29, V.Undef, NewObj(5).Put("sx", ((V)(1.45))).Put("sy", ((V)(0.55))).Put("k", ((V)(5D))).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).V)), Call(ball_14, V.Undef, Add(x_1822, ((V)((ToNum(d_1824) * 1.5)))), ((V)((by_1826 + 2.6))), ((V)((ToNum(z_1823) - 2.6))), ((V)(4.4)), GOLD_35, Call(mt_29, V.Undef, NewObj(4).Put("sx", ((V)(1.5))).Put("sy", ((V)(0.5))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V)), Call(ball_14, V.Undef, Add(x_1822, ((V)((ToNum(d_1824) * 1.5)))), ((V)((by_1826 + 2.6))), Add(z_1823, ((V)(2.6))), ((V)(4.4)), GOLD_35, Call(mt_29, V.Undef, NewObj(4).Put("sx", ((V)(1.5))).Put("sy", ((V)(0.5))).Put("k", ((V)(4D))).Put("n", ((V)(12D))).V)), Call(ball_14, V.Undef, Add(x_1822, ((V)((ToNum(d_1824) * 8.6)))), ((V)((by_1826 + 4.6))), z_1823, ((V)(2.2)), GOLD_35, Call(mt_29, V.Undef, NewObj(4).Put("sx", ((V)(1.2))).Put("sy", ((V)(1.3))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
Invoke(Arr(Arr(((V)((-5.6))), ((V)(4.4)), ((V)(2.3))), Arr(((V)((-7D))), ((V)(8D)), ((V)(2D))), Arr(((V)((-6.4))), ((V)(11.6)), ((V)(1.8))), Arr(((V)((-4.8))), ((V)(14.6)), ((V)(1.7)))), "forEach", Fn((V _arrowThis1840, int _argc1827, V _a1829, V _a1830, V _a1831, V _a1832, V[] _rest1828) => {
V dx_1835 = default;
V dy_1837 = default;
V r_1839 = default;
{ V _t1833 = ListOf(_a1829);
{ V _t1834 = GetIdx(_t1833, 0D);
dx_1835 = _t1834; }
{ V _t1836 = GetIdx(_t1833, 1D);
dy_1837 = _t1836; }
{ V _t1838 = GetIdx(_t1833, 2D);
r_1839 = _t1838; }
}
return Invoke(o_1821, "push", Call(ball_14, V.Undef, Add(x_1822, ((V)((ToNum(d_1824) * ToNum(dx_1835))))), Add(((V)(by_1826)), dy_1837), z_1823, r_1839, GOLD_35, Call(mt_29, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("n", ((V)(8D))).V)));
}, 1, "", true));
Invoke(o_1821, "push", Call(ball_14, V.Undef, ((V)((ToNum(x_1822) - (ToNum(d_1824) * 3.6)))), ((V)((by_1826 + 16.6))), z_1823, ((V)(2.3)), GOLD_35, Call(mt_29, V.Undef, NewObj(4).Put("sx", ((V)(1.25))).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("shine", ((V)(1D))).V)), Call(ball_14, V.Undef, ((V)((ToNum(x_1822) - (ToNum(d_1824) * 5.8)))), ((V)((by_1826 + 16.2))), z_1823, ((V)(1D)), ((V)("#b9862a")), Call(mt_29, V.Undef, NewObj(3).Put("sx", ((V)(1.6))).Put("k", ((V)(3D))).Put("n", ((V)(6D))).V)));
return default;
}, 4, "", true);
SW_1792 = Arr(Arr(((V)((-38D))), ((V)(14D)), ((V)((-1D)))), Arr(((V)(38D)), ((V)((-12D))), ((V)(1D))), Arr(((V)(30D)), ((V)(26D)), ((V)(1D))), Arr(((V)((-30D))), ((V)((-24D))), ((V)((-1D)))));
WB_1793 = V.Null;
WM_1794 = V.Null;
WT_1795 = V.Null;
mk_1796 = Fn((V _arrowThis1848, int _argc1841, V p_1847, V _a1844, V _a1845, V _a1846, V[] _rest1842) => {
if (Truthy(WB_1793)) {
return default;
}
WB_1793 = Call(water_68, V.Undef, p_1847, NewObj(7).Put("sh", NewObj(1).Put("rx", ((V)((BI_1781 + 0.5)))).V).Put("y", ((V)(BW_1784))).Put("rim", NewObj(2).Put("y", ((V)(((BY_1782 + BH_1783) + 1.6)))).Put("sh", NewObj(1).Put("rx", ((V)(BI_1781))).V).V).Put("pal", Get(WP_63, "marble")).Put("cs", ((V)(1D))).Put("rip", Invoke(Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis1871, int _argc1864, V i_1870, V _a1867, V _a1868, V _a1869, V[] _rest1865) => {
double t_1872 = 0;
t_1872 = ((-0.4) + (ToNum(i_1870) * 0.24));
return Arr(((V)((32D * FdLibm.Cos((t_1872 + 0.5))))), ((V)((32D * FdLibm.Sin((t_1872 + 0.5))))), ((V)(7D)), ((V)((1.6 + ((ToNum(i_1870) % 3D) * 0.3)))), ((V)(((-ToNum(i_1870)) * 0.3))));
return default;
}, 1, "", true)), "concat", Invoke(SW_1792, "map", Fn((V _arrowThis1863, int _argc1849, V _a1851, V i_1855, V _a1853, V _a1854, V[] _rest1850) => {
V x_1858 = default;
V z_1860 = default;
V d_1862 = default;
{ V _t1856 = ListOf(_a1851);
{ V _t1857 = GetIdx(_t1856, 0D);
x_1858 = _t1857; }
{ V _t1859 = GetIdx(_t1856, 1D);
z_1860 = _t1859; }
{ V _t1861 = GetIdx(_t1856, 2D);
d_1862 = _t1861; }
}
return Arr(((V)((ToNum(x_1858) - (ToNum(d_1862) * 17D)))), z_1860, ((V)(5D)), ((V)(1.4)), ((V)(((-ToNum(i_1855)) * 0.4))));
}, 2, "", true)))).Put("gl", ((V)(8D))).V);
WM_1794 = Call(water_68, V.Undef, p_1847, NewObj(7).Put("sh", NewObj(1).Put("rx", ((V)(MR_1786))).V).Put("y", ((V)((MY_1785 - 1.6)))).Put("rim", NewObj(2).Put("y", ((V)(MY_1785))).Put("sh", NewObj(1).Put("rx", ((V)(MR_1786))).V).V).Put("pal", Get(WP_63, "marble")).Put("cs", ((V)(0.7))).Put("rip", Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis1880, int _argc1873, V i_1879, V _a1876, V _a1877, V _a1878, V[] _rest1874) => {
return Arr(((V)((16D * FdLibm.Cos((ToNum(i_1879) * 1.25))))), ((V)((16D * FdLibm.Sin((ToNum(i_1879) * 1.25))))), ((V)(5D)), ((V)(1.4)), ((V)(((-ToNum(i_1879)) * 0.3))));
}, 1, "", true))).Put("gl", ((V)(4D))).V);
WT_1795 = Call(water_68, V.Undef, p_1847, NewObj(8).Put("sh", NewObj(1).Put("rx", ((V)(TR_1788))).V).Put("y", ((V)((TY_1787 - 1.2)))).Put("rim", NewObj(2).Put("y", ((V)(TY_1787))).Put("sh", NewObj(1).Put("rx", ((V)(TR_1788))).V).V).Put("pal", Get(WP_63, "marble")).Put("cs", ((V)(0.5))).Put("rip", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(7D)), ((V)(1.2)), ((V)(0D))), Arr(((V)(4D)), ((V)(3D)), ((V)(4D)), ((V)(1D)), ((V)((-0.5)))))).Put("gl", ((V)(2D))).Put("edge", ((V)(3D))).V);
return default;
}, 1, "", true);
Set(D_1789, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis1888, int _argc1881, V P_1887, V _a1884, V _a1885, V _a1886, V[] _rest1882) => {
V o_1889 = default;
o_1889 = Arr(Call(balu_1790, V.Undef, ((V)(BW_1784)), ((V)(9D)), ((V)(((MY_1785 - 8D) - BW_1784)))), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((MY_1785 - 8D))), ((V)(0D)), ((V)((MR_1786 + 1.6))), ((V)(8D)), MARB_37, Call(cer_31, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.3))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.66))), Arr(((V)(6D)), ((V)(0D)), ((V)(0.94))), Arr(((V)(8D)), ((V)(0D)), ((V)(1D))))).V)), Call(arcW_15, V.Undef, ((V)(0D)), ((V)((MY_1785 - 1D))), ((V)(0D)), ((V)((MR_1786 + 2.2))), ((V)((MR_1786 + 2.2))), ((V)(2.6)), ((V)(1.6)), ((V)(4.4)), ((V)((4.4 + (2D * PI_34)))), GOLD_35, Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(30D))).Put("shine", ((V)(1D))).V)));
Invoke(SW_1792, "forEach", Fn((V _arrowThis1897, int _argc1890, V s_1896, V _a1893, V _a1894, V _a1895, V[] _rest1891) => {
return CallSpread(swan_1791, V.Undef, new ArrBuilder().Add(o_1889).Spread(s_1896).V);
}, 1, "", true));
return o_1889;
return default;
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1906, int _argc1898, V p_1904, V s_1905, V _a1902, V _a1903, V[] _rest1899) => {
Call(mk_1796, V.Undef, p_1904);
return Add(Get(WB_1793, "svg"), s_1905);
return default;
}, 2, "wrap", true)).V, NewObj(2).Put("build", Fn((V _arrowThis1914, int _argc1907, V P_1913, V _a1910, V _a1911, V _a1912, V[] _rest1908) => {
return Arr(Call(balu_1790, V.Undef, ((V)((MY_1785 - 1.6))), ((V)(4.8)), ((V)((((TY_1787 - 5D) - MY_1785) + 1.6)))), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((TY_1787 - 5D))), ((V)(0D)), ((V)((TR_1788 + 1.6))), ((V)(5D)), MARB_37, Call(cer_31, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.36))), Arr(((V)(3D)), ((V)(0D)), ((V)(0.84))), Arr(((V)(5D)), ((V)(0D)), ((V)(1D))))).V)), Call(arcW_15, V.Undef, ((V)(0D)), ((V)((TY_1787 - 0.6))), ((V)(0D)), ((V)((TR_1788 + 2D))), ((V)((TR_1788 + 2D))), ((V)(2D)), ((V)(1D)), ((V)(4.4)), ((V)((4.4 + (2D * PI_34)))), GOLD_35, Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("shine", ((V)(1D))).V)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1923, int _argc1915, V p_1921, V s_1922, V _a1919, V _a1920, V[] _rest1916) => {
Call(mk_1796, V.Undef, p_1921);
return Add(Get(WM_1794, "svg"), s_1922);
return default;
}, 2, "wrap", true)).V, NewObj(2).Put("build", Fn((V _arrowThis1931, int _argc1924, V P_1930, V _a1927, V _a1928, V _a1929, V[] _rest1925) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)((TY_1787 - 1.2))), ((V)(0D)), ((V)(2.6)), ((V)(4D)), GOLD_35, Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)((TY_1787 + 4.4))), ((V)(0D)), ((V)(3.6)), GOLD_35, Call(mt_29, V.Undef, NewObj(3).Put("sy", ((V)(1.5))).Put("k", ((V)(5D))).Put("shine", ((V)(1D))).V)), Call(ball_14, V.Undef, ((V)(0D)), ((V)((TY_1787 + 14D))), ((V)(0D)), ((V)(1.4)), GOLD_35, Call(mt_29, V.Undef, NewObj(1).Put("k", ((V)(3D))).V)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis1940, int _argc1932, V p_1938, V s_1939, V _a1936, V _a1937, V[] _rest1933) => {
Call(mk_1796, V.Undef, p_1938);
return Add(Get(WT_1795, "svg"), s_1939);
return default;
}, 2, "wrap", true)).V));
Set(D_1789, "fx", Fn((V _arrowThis1948, int _argc1941, V c_1947, V _a1944, V _a1945, V _a1946, V[] _rest1942) => {
V p_1949 = default;
V k_1950 = default;
JsStrBuf f_1951 = null;
V defs_1952 = default;
V curt_1953 = default;
p_1949 = Get(c_1947, "p");
k_1950 = Get(c_1947, "k");
Call(mk_1796, V.Undef, p_1949);
f_1951 = new JsStrBuf("");
defs_1952 = Add(Add(Add(WDEF_69, Get(WB_1793, "defs")), Get(WM_1794, "defs")), Get(WT_1795, "defs"));
Call(rep_18, V.Undef, ((V)(8D)), Fn((V _arrowThis1961, int _argc1954, V i_1960, V _a1957, V _a1958, V _a1959, V[] _rest1955) => {
double t_1962 = 0;
t_1962 = (((ToNum(i_1960) / 8D) * 2D) * PI_34);
f_1951.V(Call(stream_71, V.Undef, p_1949, k_1950, Arr(((V)(0D)), ((V)((TY_1787 + 15D))), ((V)(0D))), Arr(((V)((FdLibm.Cos(t_1962) * 6D))), ((V)((TY_1787 + 30D))), ((V)((FdLibm.Sin(t_1962) * 6D)))), Arr(((V)((FdLibm.Cos(t_1962) * 10D))), ((V)((TY_1787 - 1D))), ((V)((FdLibm.Sin(t_1962) * 10D)))), ((V)(0.9)), ((V)(0.7)), ((V)(((-ToNum(i_1960)) * 0.09)))));
return default;
}, 1, "", true));
f_1951.V(Call(stream_71, V.Undef, p_1949, k_1950, Arr(((V)(0D)), ((V)((TY_1787 + 15D))), ((V)(0D))), Arr(((V)(0D)), ((V)((TY_1787 + 28D))), ((V)(0D))), Arr(((V)(0D)), ((V)((TY_1787 + 21D))), ((V)(0D))), ((V)(1.6)), ((V)(0.5))));
curt_1953 = Fn((V _arrowThis1975, int _argc1963, V r0_1969, V y0_1970, V r1_1971, V y1_1972, V[] _rest1964) => {
JsStrBuf s_1976 = null;
V n_1973 = default;
V w_1974 = default;
n_1973 = (_argc1963 > 4 ? _rest1964[0] : V.Undef);
w_1974 = (_argc1963 > 5 ? _rest1964[1] : V.Undef);
s_1976 = new JsStrBuf("");
Call(rep_18, V.Undef, n_1973, Fn((V _arrowThis1984, int _argc1977, V i_1983, V _a1980, V _a1981, V _a1982, V[] _rest1978) => {
double t_1985 = 0;
double cs_1986 = 0;
double sn_1987 = 0;
t_1985 = ((((-PI_34) / 6D) + ((ToNum(Add(i_1983, ((V)(0.5)))) / ToNum(n_1973)) * PI_34)) + ((PI_34 / 3D) * 0D));
cs_1986 = FdLibm.Cos((((t_1985 + (PI_34 / 3D)) - (PI_34 / 2D)) + (PI_34 / 6D)));
sn_1987 = FdLibm.Sin((((t_1985 + (PI_34 / 3D)) - (PI_34 / 2D)) + (PI_34 / 6D)));
s_1976.V(Call(stream_71, V.Undef, p_1949, k_1950, Arr(((V)((cs_1986 * ToNum(r0_1969)))), y0_1970, ((V)((sn_1987 * ToNum(r0_1969))))), Arr(((V)((cs_1986 * ToNum(Add(r0_1969, ((V)(4D))))))), ((V)((ToNum(y0_1970) - ((ToNum(y0_1970) - ToNum(y1_1972)) * 0.25)))), ((V)((sn_1987 * ToNum(Add(r0_1969, ((V)(4D)))))))), Arr(((V)((cs_1986 * ToNum(r1_1971)))), y1_1972, ((V)((sn_1987 * ToNum(r1_1971))))), w_1974, ((V)((0.55 + ((ToNum(i_1983) % 3D) * 0.06)))), ((V)(((-ToNum(i_1983)) * 0.11)))));
return default;
}, 1, "", true));
return ((V)(s_1976.Str));
return default;
}, 6, "", true);
f_1951.V(Add(Call(curt_1953, V.Undef, ((V)((TR_1788 + 2D))), ((V)((TY_1787 - 0.2))), ((V)((TR_1788 + 6D))), ((V)((MY_1785 - 1.4))), ((V)(10D)), ((V)(1D))), Call(curt_1953, V.Undef, ((V)((MR_1786 + 2.2))), ((V)((MY_1785 + 0.4))), ((V)(33D)), ((V)((BW_1784 + 0.2))), ((V)(16D)), ((V)(1.1)))));
Invoke(SW_1792, "forEach", Fn((V _arrowThis2002, int _argc1988, V _a1990, V i_1994, V _a1992, V _a1993, V[] _rest1989) => {
V x_1997 = default;
V z_1999 = default;
V d_2001 = default;
{ V _t1995 = ListOf(_a1990);
{ V _t1996 = GetIdx(_t1995, 0D);
x_1997 = _t1996; }
{ V _t1998 = GetIdx(_t1995, 1D);
z_1999 = _t1998; }
{ V _t2000 = GetIdx(_t1995, 2D);
d_2001 = _t2000; }
}
f_1951.V(Call(stream_71, V.Undef, p_1949, k_1950, Arr(((V)((ToNum(x_1997) - (ToNum(d_2001) * 6.4)))), ((V)((BW_1784 + 15.8))), z_1999), Arr(((V)((ToNum(x_1997) - (ToNum(d_2001) * 12D)))), ((V)((BW_1784 + 19D))), z_1999), Arr(((V)((ToNum(x_1997) - (ToNum(d_2001) * 17D)))), ((V)(BW_1784)), z_1999), ((V)(0.7)), ((V)(0.6)), ((V)(((-ToNum(i_1994)) * 0.2)))));
return default;
}, 2, "", true));
f_1951.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(Call(p_1949, V.Undef, ((V)(0D)), ((V)(BW_1784)), ((V)(0D))), 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(Call(p_1949, V.Undef, ((V)(0D)), ((V)((BW_1784 + 2D))), ((V)(0D))), 1D))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((38D * ToNum(k_1950)))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((10D * ToNum(k_1950)))))), "\" fill=\"#ffffff\" filter=\"url(#w7m)\" opacity=\"0.18\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.12;0.26;0.12")), ((V)(3D)))), "</ellipse>"));
return NewObj(3).Put("defs", defs_1952).Put("front", ((V)(f_1951.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_1949, V.Undef, ((V)(((-BR_1780) - 5D))), ((V)(0D)), ((V)(((-BR_1780) - 5D)))), Call(p_1949, V.Undef, ((V)((BR_1780 + 5D))), ((V)(0D)), ((V)((BR_1780 + 5D)))), Call(p_1949, V.Undef, ((V)(((-BR_1780) - 5D))), ((V)(0D)), ((V)((BR_1780 + 5D)))), Call(p_1949, V.Undef, ((V)((BR_1780 + 5D))), ((V)(0D)), ((V)(((-BR_1780) - 5D)))), Call(p_1949, V.Undef, ((V)(0D)), ((V)((TY_1787 + 34D))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_1789;
return default;
}, 1, "", true));
Set(N_33, "obelisk", Fn((V _arrowThis2010, int _argc2003, V S_2009, V _a2006, V _a2007, V _a2008, V[] _rest2004) => {
double RB_2011 = 0;
double RI_2012 = 0;
double WY_2013 = 0;
double TOP_2014 = 0;
V OB_2015 = default;
double YW_2016 = 0;
double A0_2017 = 0;
double Y0_2018 = 0;
double Y1_2019 = 0;
double Y2_2020 = 0;
double Y3_2021 = 0;
V D_2022 = default;
V FL_2023 = default;
V WAT_2024 = default;
V mkW_2025 = default;
V corner_2026 = default;
RB_2011 = 47D;
RI_2012 = 43D;
WY_2013 = 10D;
TOP_2014 = 11D;
OB_2015 = ((V)("#0f0c16"));
YW_2016 = 0.32;
A0_2017 = 8.4;
Y0_2018 = 36D;
Y1_2019 = 45D;
Y2_2020 = 116D;
Y3_2021 = 130D;
D_2022 = NewObj(4).Put("w", ((V)(104D))).Put("d", ((V)(104D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis2033, int _argc2027, V _a2029, V _a2030, V _a2031, V _a2032, V[] _rest2028) => {
return NewObj(2).Put("y", ((V)(20D))).Put("r", ((V)(70D))).V;
}, 0, "glow", true)).V;
Set(D_2022, "build", Fn((V _arrowThis2041, int _argc2034, V P_2040, V _a2037, V _a2038, V _a2039, V[] _rest2035) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((RB_2011 + 4D))), ((V)(3D)), ((V)("#1b1a20")), Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(44D))).Put("shine", ((V)(1D))).V)), Call(arcW_15, V.Undef, ((V)(0D)), ((V)(3D)), ((V)(0D)), ((V)(RB_2011)), ((V)(RB_2011)), ((V)((RB_2011 - RI_2012))), ((V)(8D)), ((V)(4.4)), ((V)((4.4 + (2D * PI_34)))), ((V)("#121016")), NewObj(3).Put("mat", ((V)("gloss"))).Put("n", ((V)(48D))).Put("shine", ((V)(1D))).V));
}, 1, "", true));
FL_2023 = Invoke(Call(rep_18, V.Undef, ((V)(8D)), Fn((V _arrowThis2049, int _argc2042, V i_2048, V _a2045, V _a2046, V _a2047, V[] _rest2043) => {
double t_2050 = 0;
double r_2051 = 0;
t_2050 = ((((ToNum(i_2048) / 8D) * 2D) * PI_34) + 0.2);
r_2051 = (NumTruthy((ToNum(i_2048) % 2D)) ? 24D : 18D);
return Arr(((V)((r_2051 * FdLibm.Cos(t_2050)))), ((V)((r_2051 * FdLibm.Sin(t_2050)))), i_2048);
return default;
}, 1, "", true)), "concat", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(8D))), Arr(((V)(6D)), ((V)((-4D))), ((V)(9D))), Arr(((V)((-5D))), ((V)(5D)), ((V)(10D)))));
WAT_2024 = V.Null;
mkW_2025 = Fn((V _arrowThis2059, int _argc2052, V p_2058, V _a2055, V _a2056, V _a2057, V[] _rest2053) => {
return (WAT_2024 is var _t2086 && Truthy(_t2086) ? _t2086 : (WAT_2024 = Call(water_68, V.Undef, p_2058, NewObj(10).Put("sh", NewObj(1).Put("rx", ((V)(RI_2012))).V).Put("y", ((V)(WY_2013))).Put("rim", NewObj(2).Put("y", ((V)(TOP_2014))).Put("sh", NewObj(1).Put("rx", ((V)((RI_2012 - 0.5)))).V).V).Put("pal", Get(WP_63, "night")).Put("cs", ((V)(0.9))).Put("caust", ((V)(0.28))).Put("floor", ((V)(string.Concat("<circle r=\"", NumStr(RI_2012), "\" fill=\"url(#o7led)\" opacity=\"0.6\"/>")))).Put("under", Invoke(Invoke(FL_2023, "map", Fn((V _arrowThis2071, int _argc2060, V _a2062, V _a2063, V _a2064, V _a2065, V[] _rest2061) => {
V x_2068 = default;
V z_2070 = default;
{ V _t2066 = ListOf(_a2062);
{ V _t2067 = GetIdx(_t2066, 0D);
x_2068 = _t2067; }
{ V _t2069 = GetIdx(_t2066, 1D);
z_2070 = _t2069; }
}
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_17, V.Undef, x_2068)), "\" cy=\"", ToStr(Call(f1_17, V.Undef, z_2070)), "\" rx=\"7\" ry=\"7\" fill=\"#ff7a22\" opacity=\"0.4\" filter=\"url(#w7m)\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.25;0.5;0.3;0.45;0.25")), ((V)(1.2)))), "</ellipse>")));
}, 1, "", true)), "join", ((V)("")))).Put("rip", Invoke(Invoke(Invoke(FL_2023, "slice", ((V)(0D)), ((V)(8D))), "map", Fn((V _arrowThis2085, int _argc2072, V _a2074, V _a2075, V _a2076, V _a2077, V[] _rest2073) => {
V x_2080 = default;
V z_2082 = default;
V i_2084 = default;
{ V _t2078 = ListOf(_a2074);
{ V _t2079 = GetIdx(_t2078, 0D);
x_2080 = _t2079; }
{ V _t2081 = GetIdx(_t2078, 1D);
z_2082 = _t2081; }
{ V _t2083 = GetIdx(_t2078, 2D);
i_2084 = _t2083; }
}
return Arr(x_2080, z_2082, ((V)(8D)), ((V)((1.4 + ((ToNum(i_2084) % 3D) * 0.25)))), ((V)(((-ToNum(i_2084)) * 0.21))), ((V)("#ffb070")), ((V)(0.6)));
}, 1, "", true)), "concat", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(14D)), ((V)(2.4)), ((V)(0D)), ((V)("#ffd0a0")), ((V)(0.5)))))).Put("gl", ((V)(6D))).V)));
}, 1, "", true);
corner_2026 = Fn((V _arrowThis2096, int _argc2087, V j_2093, V y_2094, V sc_2095, V _a2092, V[] _rest2088) => {
double u_2097 = 0;
double v_2098 = 0;
double cy_2099 = 0;
double sy_2100 = 0;
u_2097 = (((SEqN(j_2093, 0D) || SEqN(j_2093, 3D)) ? A0_2017 : (-A0_2017)) * ToNum(sc_2095));
v_2098 = ((LtN(j_2093, 2D) ? A0_2017 : (-A0_2017)) * ToNum(sc_2095));
cy_2099 = FdLibm.Cos(YW_2016);
sy_2100 = FdLibm.Sin(YW_2016);
return Arr(((V)(((u_2097 * cy_2099) - (v_2098 * sy_2100)))), y_2094, ((V)(((u_2097 * sy_2100) + (v_2098 * cy_2099)))));
return default;
}, 3, "", true);
Set(D_2022, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis2108, int _argc2101, V P_2107, V _a2104, V _a2105, V _a2106, V[] _rest2102) => {
return Arr(Call(solid_11, V.Undef, NewObj(11).Put("ax", ((V)("y"))).Put("sh", ((V)("rr"))).Put("c", Arr(((V)(0D)), ((V)(0D)))).Put("a", ((V)(A0_2017))).Put("b", ((V)(A0_2017))).Put("r", ((V)(0.3))).Put("yaw", ((V)(YW_2016))).Put("rings", Arr(Arr(((V)(Y0_2018)), ((V)(0D)), ((V)(0.05))), Arr(((V)(Y1_2019)), ((V)(0D)), ((V)(1D))), Arr(((V)(Y2_2020)), ((V)(0D)), ((V)(0.6))), Arr(((V)(Y3_2021)), ((V)(0D)), ((V)(0.04))))).Put("col", OB_2015).Put("mat", ((V)("gloss"))).Put("shine", ((V)(1D))).V));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis2117, int _argc2109, V p_2115, V s_2116, V _a2113, V _a2114, V[] _rest2110) => {
V W_2118 = default;
double k_2119 = 0;
JsStrBuf back_2120 = null;
JsStrBuf front_2121 = null;
JsStrBuf ed_2122 = null;
V q0_2123 = default;
W_2118 = Call(mkW_2025, V.Undef, p_2115);
k_2119 = ((ToNum(GetIdx(Call(p_2115, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D))), 1D)) - ToNum(GetIdx(Call(p_2115, V.Undef, ((V)(0D)), ((V)(1D)), ((V)(0D))), 1D))) / ToNum(Get(X_9, "CA")));
back_2120 = new JsStrBuf("");
front_2121 = new JsStrBuf("");
ed_2122 = new JsStrBuf("");
Invoke(FL_2023, "forEach", Fn((V _arrowThis2137, int _argc2124, V _a2126, V _a2127, V _a2128, V _a2129, V[] _rest2125) => {
V fl_2138 = default;
V x_2132 = default;
V z_2134 = default;
V i_2136 = default;
{ V _t2130 = ListOf(_a2126);
{ V _t2131 = GetIdx(_t2130, 0D);
x_2132 = _t2131; }
{ V _t2133 = GetIdx(_t2130, 1D);
z_2134 = _t2133; }
{ V _t2135 = GetIdx(_t2130, 2D);
i_2136 = _t2135; }
}
fl_2138 = Call(flames_76, V.Undef, Call(p_2115, V.Undef, x_2132, ((V)(WY_2013)), z_2134), ((V)((k_2119 * (GeN(i_2136, 8D) ? 0.9 : 0.8)))), NewObj(7).Put("seed", ((V)(JsStrBuf.Begin().S("ob").V(i_2136).End()))).Put("n", ((V)(3D))).Put("sp", ((V)(4D))).Put("h", ((V)((GeN(i_2136, 8D) ? 24D : 19D)))).Put("w", ((V)(3.2))).Put("emb", ((V)(2D))).Put("noGlow", ((V)((ToNum(i_2136) % 2D)))).V);
if ((((0.5 * ToNum(x_2132)) + (0.866 * ToNum(z_2134))) < 2D)) {
back_2120.V(fl_2138);
} else {
front_2121.V(fl_2138);
}
return default;
}, 1, "", true));
Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis2146, int _argc2139, V j_2145, V _a2142, V _a2143, V _a2144, V[] _rest2140) => {
V nx_2147 = default;
double dot_2148 = 0;
V pts_2149 = default;
nx_2147 = Call(corner_2026, V.Undef, j_2145, ((V)(0D)), ((V)(1D)));
dot_2148 = ((((0.5 * ToNum(GetIdx(nx_2147, 0D))) + (0.866 * ToNum(GetIdx(nx_2147, 2D)))) / A0_2017) / 1.414);
if ((dot_2148 < (-0.35))) {
return default;
}
pts_2149 = Invoke(Arr(Call(corner_2026, V.Undef, j_2145, ((V)(Y0_2018)), ((V)(0.05))), Call(corner_2026, V.Undef, j_2145, ((V)(Y1_2019)), ((V)(1D))), Call(corner_2026, V.Undef, j_2145, ((V)(Y2_2020)), ((V)(0.6))), Call(corner_2026, V.Undef, j_2145, ((V)(Y3_2021)), ((V)(0.04)))), "map", Fn((V _arrowThis2157, int _argc2150, V q_2156, V _a2153, V _a2154, V _a2155, V[] _rest2151) => {
return CallSpread(p_2115, V.Undef, new ArrBuilder().Spread(q_2156).V);
}, 1, "", true));
ed_2122.S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(pts_2149, "map", P2_21), "join", ((V)("L")))), "\" fill=\"none\" stroke=\"", ((dot_2148 > 0.6) ? "#f2e8ff" : "#9a88c8"), "\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((((dot_2148 > 0.6) ? 0.5 : 0.35) * k_2119))))), "\" opacity=\"", ToStr(Call(n4_20, V.Undef, ((V)((0.45 + (dot_2148 * 0.5)))))), "\"/>"));
return default;
}, 1, "", true));
Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis2165, int _argc2158, V j_2164, V _a2161, V _a2162, V _a2163, V[] _rest2159) => {
V a_2166 = default;
V b_2167 = default;
double nx_2168 = 0;
double nz_2169 = 0;
a_2166 = Call(corner_2026, V.Undef, j_2164, ((V)(0D)), ((V)(1D)));
b_2167 = Call(corner_2026, V.Undef, ((V)((ToNum(Add(j_2164, ((V)(1D)))) % 4D))), ((V)(0D)), ((V)(1D)));
nx_2168 = (ToNum(Add(GetIdx(a_2166, 0D), GetIdx(b_2167, 0D))) / 2D);
nz_2169 = (ToNum(Add(GetIdx(a_2166, 2D), GetIdx(b_2167, 2D))) / 2D);
if ((((0.5 * nx_2168) + (0.866 * nz_2169)) < 0D)) {
return default;
}
ed_2122.S(string.Concat("<path d=\"", ToStr(Call(quad_56, V.Undef, p_2115, Call(corner_2026, V.Undef, j_2164, ((V)(Y1_2019)), ((V)(1D))), Call(corner_2026, V.Undef, ((V)((ToNum(Add(j_2164, ((V)(1D)))) % 4D))), ((V)(Y1_2019)), ((V)(1D))), Call(corner_2026, V.Undef, ((V)((ToNum(Add(j_2164, ((V)(1D)))) % 4D))), ((V)((Y1_2019 + 34D))), ((V)(0.86))), Call(corner_2026, V.Undef, j_2164, ((V)((Y1_2019 + 34D))), ((V)(0.86))))), "\" fill=\"url(#o7fl)\" opacity=\"0.75\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.55;0.85;0.6;0.8;0.55")), ((V)(1.4)))), "</path><path d=\"", ToStr(Call(quad_56, V.Undef, p_2115, Call(corner_2026, V.Undef, j_2164, ((V)(Y0_2018)), ((V)(0.05))), Call(corner_2026, V.Undef, ((V)((ToNum(Add(j_2164, ((V)(1D)))) % 4D))), ((V)(Y0_2018)), ((V)(0.05))), Call(corner_2026, V.Undef, ((V)((ToNum(Add(j_2164, ((V)(1D)))) % 4D))), ((V)(Y1_2019)), ((V)(1D))), Call(corner_2026, V.Undef, j_2164, ((V)(Y1_2019)), ((V)(1D))))), "\" fill=\"#ff8a3a\" opacity=\"0.45\"/>"));
return default;
}, 1, "", true));
q0_2123 = Call(p_2115, V.Undef, ((V)(0D)), ((V)(Y3_2021)), ((V)(0D)));
ed_2122.S(string.Concat("<circle cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q0_2123, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q0_2123, 1D))), "\" r=\"", ToStr(Call(f1_17, V.Undef, ((V)((1.6 * k_2119))))), "\" fill=\"#ffe0c0\" filter=\"url(#f7b)\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.4;1;0.4")), ((V)(2.4)))), "</circle>"));
return ((V)(JsStrBuf.Begin().V(Get(W_2118, "svg")).S(back_2120.Str).S(string.Concat("<g>", ToStr(Call(atV_42, V.Undef, ((V)("translate")), Arr(((V)("0 0")), ((V)(string.Concat("0 ", ToStr(Call(f1_17, V.Undef, ((V)(((-4D) * k_2119)))))))), ((V)("0 0"))), ((V)(4.4)))), ToStr(s_2116), ed_2122.Str, "</g>")).S(front_2121.Str).End()));
return default;
}, 2, "wrap", true)).V));
Set(D_2022, "fx", Fn((V _arrowThis2177, int _argc2170, V c_2176, V _a2173, V _a2174, V _a2175, V[] _rest2171) => {
V p_2178 = default;
V k_2179 = default;
V W_2180 = default;
JsStrBuf f_2181 = null;
JsStrBuf un_2182 = null;
V defs_2183 = default;
p_2178 = Get(c_2176, "p");
k_2179 = Get(c_2176, "k");
W_2180 = Call(mkW_2025, V.Undef, p_2178);
f_2181 = new JsStrBuf("");
un_2182 = new JsStrBuf("");
defs_2183 = Add(Add(Add(Add(WDEF_69, FDEF_72), Get(W_2180, "defs")), Call(G_46, V.Undef, ((V)("o7led")), Arr(Arr(((V)(0D)), ((V)("#ff7a22")), ((V)(0D))), Arr(((V)(0.82)), ((V)("#ff7a22")), ((V)(0D))), Arr(((V)(0.95)), ((V)("#ff9a4a")), ((V)(0.7))), Arr(((V)(1D)), ((V)("#ff7a22")), ((V)(0D)))), ((V)("cx=\"50%\" cy=\"50%\" r=\"50%\"")))), Call(L_47, V.Undef, ((V)("o7fl")), Arr(Arr(((V)(0D)), ((V)("#ff9a4a")), ((V)(0D))), Arr(((V)(1D)), ((V)("#ff7a22")), ((V)(0.7))))));
f_2181.S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(Call(ellPts_51, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((RB_2011 - 0.6))), ((V)((RB_2011 - 0.6))), ((V)(20D)), ((V)(((-PI_34) / 6D))), ((V)(((5D * PI_34) / 6D)))), "map", Fn((V _arrowThis2191, int _argc2184, V q_2190, V _a2187, V _a2188, V _a2189, V[] _rest2185) => {
return Call(P2_21, V.Undef, Call(p_2178, V.Undef, GetIdx(q_2190, 0D), ((V)(TOP_2014)), GetIdx(q_2190, 1D)));
}, 1, "", true)), "join", ((V)("L")))), "\" fill=\"none\" stroke=\"#c8b8ff\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.45 * ToNum(k_2179)))))), "\" opacity=\"0.55\"/>"));
f_2181.V(Call(smoke_77, V.Undef, Call(p_2178, V.Undef, ((V)(0D)), ((V)((WY_2013 + 30D))), ((V)(0D))), k_2179, NewObj(7).Put("seed", ((V)("obs"))).Put("n", ((V)(4D))).Put("H", ((V)(60D))).Put("col", ((V)("#ffffff"))).Put("op", ((V)(0.12))).Put("d", ((V)(6D))).Put("r1", ((V)(14D))).V));
un_2182.V(Call(glowE_78, V.Undef, p_2178, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(60D)), ((V)(60D)), ((V)("#ff8a3a")), ((V)(0.35)), ((V)(1D))));
return NewObj(4).Put("defs", defs_2183).Put("under", ((V)(un_2182.Str))).Put("front", ((V)(f_2181.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2178, V.Undef, ((V)(((-RB_2011) - 6D))), ((V)(0D)), ((V)(((-RB_2011) - 6D)))), Call(p_2178, V.Undef, ((V)((RB_2011 + 6D))), ((V)(0D)), ((V)((RB_2011 + 6D)))), Call(p_2178, V.Undef, ((V)(((-RB_2011) - 6D))), ((V)(0D)), ((V)((RB_2011 + 6D)))), Call(p_2178, V.Undef, ((V)((RB_2011 + 6D))), ((V)(0D)), ((V)(((-RB_2011) - 6D)))), Call(p_2178, V.Undef, ((V)(0D)), ((V)((Y3_2021 + 12D))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2022;
return default;
}, 1, "", true));
Set(N_33, "chiminea", Fn((V _arrowThis2199, int _argc2192, V S_2198, V _a2195, V _a2196, V _a2197, V[] _rest2193) => {
double BY_2200 = 0;
double R0_2201 = 0;
V TC_2202 = default;
double TM_2203 = 0;
V RG_2204 = default;
V Rb_2205 = default;
V D_2206 = default;
BY_2200 = 12D;
R0_2201 = 30D;
TC_2202 = ((V)("#c4683a"));
TM_2203 = (PI_34 / 6D);
RG_2204 = Arr(Arr(((V)(0D)), ((V)(0.5))), Arr(((V)(3D)), ((V)(0.74))), Arr(((V)(9D)), ((V)(0.93))), Arr(((V)(17D)), ((V)(1D))), Arr(((V)(26D)), ((V)(0.95))), Arr(((V)(33D)), ((V)(0.78))), Arr(((V)(38D)), ((V)(0.56))), Arr(((V)(42D)), ((V)(0.4))), Arr(((V)(46D)), ((V)(0.3))), Arr(((V)(86D)), ((V)(0.27))), Arr(((V)(89D)), ((V)(0.31))), Arr(((V)(92D)), ((V)(0.3))));
Rb_2205 = Fn((V _arrowThis2214, int _argc2207, V y_2213, V _a2210, V _a2211, V _a2212, V[] _rest2208) => {
{
double i_2215 = 0;
i_2215 = 0D;
while (true) {
if (!((i_2215 < (ToNum(Get(RG_2204, "length")) - 1D)))) break;
if (Le(y_2213, GetIdx(GetIdx(RG_2204, (i_2215 + 1D)), 0D))) {
return ((V)((R0_2201 * ToNum(Call(lerp_48, V.Undef, GetIdx(GetIdx(RG_2204, i_2215), 1D), GetIdx(GetIdx(RG_2204, (i_2215 + 1D)), 1D), ((V)(((ToNum(y_2213) - ToNum(GetIdx(GetIdx(RG_2204, i_2215), 0D))) / (ToNum(GetIdx(GetIdx(RG_2204, (i_2215 + 1D)), 0D)) - ToNum(GetIdx(GetIdx(RG_2204, i_2215), 0D)))))))))));
}
i_2215++;
}
}
return ((V)((R0_2201 * ToNum(GetIdx(GetIdx(RG_2204, (ToNum(Get(RG_2204, "length")) - 1D)), 1D)))));
return default;
}, 1, "", true);
D_2206 = NewObj(4).Put("w", ((V)(70D))).Put("d", ((V)(70D))).Put("round", ((V)(1D))).Put("glow", Fn((V _arrowThis2223, int _argc2217, V _a2219, V _a2220, V _a2221, V _a2222, V[] _rest2218) => {
return NewObj(2).Put("y", ((V)(30D))).Put("r", ((V)(60D))).V;
}, 0, "glow", true)).V;
Set(D_2206, "build", Fn((V _arrowThis2231, int _argc2224, V P_2230, V _a2227, V _a2228, V _a2229, V[] _rest2225) => {
return Arr(Call(arcW_15, V.Undef, ((V)(0D)), ((V)((BY_2200 - 2D))), ((V)(0D)), ((V)(21D)), ((V)(21D)), ((V)(2.2)), ((V)(2D)), ((V)(4.4)), ((V)((4.4 + (2D * PI_34)))), ((V)("#1c1c1f")), Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(30D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(BY_2200)), ((V)(0D)), ((V)(R0_2201)), ((V)(46D)), TC_2202, Call(pt_32, V.Undef, NewObj(2).Put("n", ((V)(40D))).Put("rg", Invoke(Invoke(RG_2204, "slice", ((V)(0D)), ((V)(9D))), "map", Fn((V _arrowThis2239, int _argc2232, V r_2238, V _a2235, V _a2236, V _a2237, V[] _rest2233) => {
return Arr(GetIdx(r_2238, 0D), ((V)(0D)), GetIdx(r_2238, 1D));
}, 1, "", true))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((BY_2200 + 45D))), ((V)(0D)), ((V)((R0_2201 * 0.3))), ((V)(41D)), TC_2202, Call(pt_32, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(41D)), ((V)(0D)), ((V)(0.9))))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((BY_2200 + 86D))), ((V)(0D)), ((V)((R0_2201 * 0.31))), ((V)(6D)), Call(shade7_49, V.Undef, TC_2202), Call(pt_32, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(3D)), ((V)(0D)), ((V)(1.03))), Arr(((V)(6D)), ((V)(0D)), ((V)(1D))))).V)));
}, 1, "", true));
Set(D_2206, "fx", Fn((V _arrowThis2247, int _argc2240, V c_2246, V _a2243, V _a2244, V _a2245, V[] _rest2241) => {
V p_2248 = default;
V k_2249 = default;
JsStrBuf f_2250 = null;
JsStrBuf bk_2251 = null;
JsStrBuf un_2252 = null;
V defs_2253 = default;
V S3_2254 = default;
V outer_2255 = default;
V pth_2256 = default;
V OUT_2257 = default;
V INN_2258 = default;
V visClip_2259 = default;
JsStrBuf ins_2260 = null;
V L0_2261 = default;
V L1_2262 = default;
V L2_2263 = default;
V L3_2264 = default;
V ct_2265 = default;
double cr_2266 = 0;
p_2248 = Get(c_2246, "p");
k_2249 = Get(c_2246, "k");
f_2250 = new JsStrBuf("");
bk_2251 = new JsStrBuf("");
un_2252 = new JsStrBuf("");
defs_2253 = Add(Add(FDEF_72, Call(G_46, V.Undef, ((V)("c7in")), Arr(Arr(((V)(0D)), ((V)("#8a3414"))), Arr(((V)(0.55)), ((V)("#3a160c"))), Arr(((V)(1D)), ((V)("#120806")))), ((V)("cx=\"50%\" cy=\"80%\" r=\"75%\"")))), Call(L_47, V.Undef, ((V)("c7lip")), Arr(Arr(((V)(0D)), ((V)("#7a3a20"))), Arr(((V)(1D)), ((V)("#e0864a"))))));
Invoke(Arr(((V)((TM_2203 + 0.2))), ((V)((TM_2203 + 2.3))), ((V)((TM_2203 + 4.4)))), "forEach", Fn((V _arrowThis2274, int _argc2267, V t_2273, V _a2270, V _a2271, V _a2272, V[] _rest2268) => {
V a_2275 = default;
V m_2276 = default;
V b_2277 = default;
V s_2278 = default;
a_2275 = Call(p_2248, V.Undef, ((V)((20D * FdLibm.Sin(ToNum(t_2273))))), ((V)((BY_2200 - 1D))), ((V)((20D * FdLibm.Cos(ToNum(t_2273))))));
m_2276 = Call(p_2248, V.Undef, ((V)((23D * FdLibm.Sin(ToNum(t_2273))))), ((V)(5D)), ((V)((23D * FdLibm.Cos(ToNum(t_2273))))));
b_2277 = Call(p_2248, V.Undef, ((V)((26D * FdLibm.Sin(ToNum(t_2273))))), ((V)(0.8)), ((V)((26D * FdLibm.Cos(ToNum(t_2273))))));
s_2278 = ((V)(JsStrBuf.Begin().V(Call(tube_60, V.Undef, Arr(a_2275, m_2276, b_2277), ((V)(1.6)), k_2249, ((V)("#26262a")), ((V)("#7a7a80")))).S(string.Concat("<path d=\"M", ToStr(Call(P2_21, V.Undef, b_2277)), "c", ToStr(Call(f1_17, V.Undef, ((V)((2D * ToNum(k_2249)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((0.4 * ToNum(k_2249)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((3D * ToNum(k_2249)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((-2D) * ToNum(k_2249)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((1.2 * ToNum(k_2249)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(((-2.6) * ToNum(k_2249)))))), "\" fill=\"none\" stroke=\"#26262a\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((1.4 * ToNum(k_2249)))))), "\" stroke-linecap=\"round\"/>")).End()));
if (GtN(Call(facing_58, V.Undef, t_2273), (-0.1))) {
f_2250.V(s_2278);
} else {
bk_2251.V(s_2278);
}
return default;
}, 1, "", true));
S3_2254 = Fn((V _arrowThis2288, int _argc2279, V u_2285, V yr_2286, V d_2287, V _a2284, V[] _rest2280) => {
double R_2289 = 0;
double th_2290 = 0;
R_2289 = (ToNum(Call(Rb_2205, V.Undef, yr_2286)) - ToNum((d_2287 is var _t2291 && Truthy(_t2291) ? _t2291 : ((V)(0D)))));
th_2290 = (TM_2203 + (ToNum(u_2285) / Max(4D, ToNum(Call(Rb_2205, V.Undef, yr_2286)))));
return Call(p_2248, V.Undef, ((V)((R_2289 * FdLibm.Sin(th_2290)))), Add(((V)(BY_2200)), yr_2286), ((V)((R_2289 * FdLibm.Cos(th_2290)))));
return default;
}, 3, "", true);
outer_2255 = Call(Fn((V _arrowThis2298, int _argc2292, V _a2294, V _a2295, V _a2296, V _a2297, V[] _rest2293) => {
V o_2299 = default;
o_2299 = Arr();
Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis2307, int _argc2300, V i_2306, V _a2303, V _a2304, V _a2305, V[] _rest2301) => {
return Invoke(o_2299, "push", Arr(((V)((-14D))), ((V)((5D + ((12D * ToNum(i_2306)) / 8D))))));
}, 1, "", true));
Call(rep_18, V.Undef, ((V)(17D)), Fn((V _arrowThis2315, int _argc2308, V i_2314, V _a2311, V _a2312, V _a2313, V[] _rest2309) => {
double a_2316 = 0;
a_2316 = (PI_34 + ((ToNum(i_2314) / 16D) * PI_34));
Invoke(o_2299, "push", Arr(((V)((14D * FdLibm.Cos(a_2316)))), ((V)((17D - (9D * FdLibm.Sin(a_2316)))))));
return default;
}, 1, "", true));
Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis2324, int _argc2317, V i_2323, V _a2320, V _a2321, V _a2322, V[] _rest2318) => {
return Invoke(o_2299, "push", Arr(((V)(14D)), ((V)((17D - ((12D * ToNum(i_2323)) / 8D))))));
}, 1, "", true));
return o_2299;
return default;
}, 0, "", true), V.Undef);
pth_2256 = Fn((V _arrowThis2333, int _argc2325, V pts_2331, V d_2332, V _a2329, V _a2330, V[] _rest2326) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_2331, "map", Fn((V _arrowThis2345, int _argc2334, V _a2336, V _a2337, V _a2338, V _a2339, V[] _rest2335) => {
V u_2342 = default;
V y_2344 = default;
{ V _t2340 = ListOf(_a2336);
{ V _t2341 = GetIdx(_t2340, 0D);
u_2342 = _t2341; }
{ V _t2343 = GetIdx(_t2340, 1D);
y_2344 = _t2343; }
}
return Call(P2_21, V.Undef, Call(S3_2254, V.Undef, u_2342, y_2344, d_2332));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
}, 2, "", true);
OUT_2257 = Call(pth_2256, V.Undef, outer_2255, ((V)((-0.2))));
INN_2258 = Call(pth_2256, V.Undef, Invoke(outer_2255, "map", Fn((V _arrowThis2357, int _argc2346, V _a2348, V _a2349, V _a2350, V _a2351, V[] _rest2347) => {
V u_2354 = default;
V y_2356 = default;
{ V _t2352 = ListOf(_a2348);
{ V _t2353 = GetIdx(_t2352, 0D);
u_2354 = _t2353; }
{ V _t2355 = GetIdx(_t2352, 1D);
y_2356 = _t2355; }
}
return Arr(((V)((ToNum(u_2354) * 0.84))), ((V)((6D + ((ToNum(y_2356) - 5D) * 0.86)))));
}, 1, "", true)), ((V)(3.4)));
{
JsStrBuf bnd_2358 = null;
V vis_2359 = default;
V line_2360 = default;
bnd_2358 = new JsStrBuf("");
vis_2359 = Fn((V _arrowThis2368, int _argc2361, V yr_2367, V _a2364, V _a2365, V _a2366, V[] _rest2362) => {
return Call(rep_18, V.Undef, ((V)(37D)), Fn((V _arrowThis2376, int _argc2369, V i_2375, V _a2372, V _a2373, V _a2374, V[] _rest2370) => {
return ((V)((((-1.5) + (ToNum(i_2375) / 12D)) * ToNum(Call(Rb_2205, V.Undef, yr_2367)))));
}, 1, "", true));
}, 1, "", true);
line_2360 = Fn((V _arrowThis2386, int _argc2377, V yr_2383, V col_2384, V w_2385, V _a2382, V[] _rest2378) => {
return ((V)(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(Call(vis_2359, V.Undef, yr_2383), "map", Fn((V _arrowThis2394, int _argc2387, V u_2393, V _a2390, V _a2391, V _a2392, V[] _rest2388) => {
return Call(P2_21, V.Undef, Call(S3_2254, V.Undef, u_2393, yr_2383, ((V)((-0.1)))));
}, 1, "", true)), "join", ((V)("L")))), "\" fill=\"none\" stroke=\"", ToStr(col_2384), "\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(w_2385) * ToNum(k_2249)))))), "\" stroke-linecap=\"round\"/>")));
}, 3, "", true);
bnd_2358.V(Add(Call(line_2360, V.Undef, ((V)(29.6)), ((V)("#2a5aa8")), ((V)(0.9))), Call(line_2360, V.Undef, ((V)(36D)), ((V)("#2a5aa8")), ((V)(0.9))))).S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(Call(vis_2359, V.Undef, ((V)(32.8))), "map", Fn((V _arrowThis2403, int _argc2395, V u_2401, V i_2402, V _a2399, V _a2400, V[] _rest2396) => {
return Call(P2_21, V.Undef, Call(S3_2254, V.Undef, u_2401, ((V)((NumTruthy((ToNum(i_2402) % 2D)) ? 31.2 : 34.4))), ((V)((-0.1)))));
}, 2, "", true)), "join", ((V)("L")))), "\" fill=\"none\" stroke=\"#f6efe0\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.7 * ToNum(k_2249)))))), "\" stroke-linejoin=\"round\"/>"));
Invoke(Call(vis_2359, V.Undef, ((V)(32.8))), "forEach", Fn((V _arrowThis2412, int _argc2404, V u_2410, V i_2411, V _a2408, V _a2409, V[] _rest2405) => {
V q_2413 = default;
if (NumTruthy((ToNum(i_2411) % 2D))) {
return default;
}
q_2413 = Call(S3_2254, V.Undef, u_2410, ((V)(32.8)), ((V)((-0.1))));
bnd_2358.S(string.Concat("<circle cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q_2413, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q_2413, 1D))), "\" r=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.55 * ToNum(k_2249)))))), "\" fill=\"", (NumTruthy((ToNum(i_2411) % 4D)) ? "#f2c14a" : "#2fa89a"), "\"/>"));
return default;
}, 2, "", true));
f_2250.S(bnd_2358.Str);
}
visClip_2259 = ((V)(""));
f_2250.S(string.Concat("<path d=\"", ToStr(OUT_2257), "\" fill=\"url(#c7lip)\"/><path d=\"", ToStr(INN_2258), "\" fill=\"url(#c7in)\"/>"));
ins_2260 = new JsStrBuf("");
L0_2261 = Call(S3_2254, V.Undef, ((V)((-8D))), ((V)(7.4)), ((V)(9D)));
L1_2262 = Call(S3_2254, V.Undef, ((V)(8D)), ((V)(8.2)), ((V)(8D)));
L2_2263 = Call(S3_2254, V.Undef, ((V)((-7D))), ((V)(8.4)), ((V)(6D)));
L3_2264 = Call(S3_2254, V.Undef, ((V)(7D)), ((V)(7.2)), ((V)(11D)));
ins_2260.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(Add(GetIdx(L0_2261, 0D), GetIdx(L1_2262, 0D))) / 2D))))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, ((V)(((ToNum(Add(GetIdx(L0_2261, 1D), GetIdx(L1_2262, 1D))) / 2D) + (1.4 * ToNum(k_2249))))))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((11D * ToNum(k_2249)))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((2.6 * ToNum(k_2249)))))), "\" fill=\"#ff6a1a\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.6;1;0.7;0.9;0.6")), ((V)(1.1)))), "</ellipse>"));
Invoke(Arr(Arr(L0_2261, L1_2262), Arr(L2_2263, L3_2264)), "forEach", Fn((V _arrowThis2425, int _argc2414, V _a2416, V _a2417, V _a2418, V _a2419, V[] _rest2415) => {
V a_2422 = default;
V b_2424 = default;
{ V _t2420 = ListOf(_a2416);
{ V _t2421 = GetIdx(_t2420, 0D);
a_2422 = _t2421; }
{ V _t2423 = GetIdx(_t2420, 1D);
b_2424 = _t2423; }
}
return ((V)(ins_2260.S(string.Concat("<path d=\"M", ToStr(Call(P2_21, V.Undef, a_2422)), "L", ToStr(Call(P2_21, V.Undef, b_2424)), "\" stroke=\"#2a1608\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((3.6 * ToNum(k_2249)))))), "\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Call(P2_21, V.Undef, a_2422)), "L", ToStr(Call(P2_21, V.Undef, b_2424)), "\" stroke=\"#5a3418\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((2.6 * ToNum(k_2249)))))), "\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Call(P2_21, V.Undef, a_2422)), "L", ToStr(Call(P2_21, V.Undef, b_2424)), "\" stroke=\"#ff7a2a\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.5 * ToNum(k_2249)))))), "\" stroke-dasharray=\"", ToStr(Call(f1_17, V.Undef, ((V)((1.4 * ToNum(k_2249)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((2D * ToNum(k_2249)))))), "\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.4;1;0.5")), ((V)(0.9)))), "</path><circle cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(b_2424, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(b_2424, 1D))), "\" r=\"", ToStr(Call(f1_17, V.Undef, ((V)((1.3 * ToNum(k_2249)))))), "\" fill=\"#ff9a3a\"/>")).Str));
}, 1, "", true));
ins_2260.V(Call(flames_76, V.Undef, Call(S3_2254, V.Undef, ((V)(0D)), ((V)(8.6)), ((V)(7D))), ((V)((ToNum(k_2249) * 0.95))), NewObj(6).Put("seed", ((V)("chim"))).Put("n", ((V)(6D))).Put("sp", ((V)(8D))).Put("h", ((V)(20D))).Put("w", ((V)(3.6))).Put("emb", ((V)(3D))).V));
f_2250.S(string.Concat("<g clip-path=\"url(#c7m)\">", ins_2260.Str, "</g>")).S(string.Concat("<path d=\"", ToStr(INN_2258), "\" fill=\"none\" stroke=\"#2a120a\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.6 * ToNum(k_2249)))))), "\" opacity=\"0.7\"/>"));
ct_2265 = Call(p_2248, V.Undef, ((V)(0D)), ((V)((BY_2200 + 92D))), ((V)(0D)));
cr_2266 = (ToNum(Call(Rb_2205, V.Undef, ((V)(92D)))) - 2D);
f_2250.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(ct_2265, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(ct_2265, 1D))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)(((cr_2266 * ToNum(k_2249)) * 1.02))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((((cr_2266 * ToNum(k_2249)) * ToNum(Get(X_9, "SA"))) * 1.02))))), "\" fill=\"#2a120a\"/><ellipse cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(ct_2265, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(ct_2265, 1D))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)(((cr_2266 * ToNum(k_2249)) * 0.6))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((((cr_2266 * ToNum(k_2249)) * ToNum(Get(X_9, "SA"))) * 0.6))))), "\" fill=\"#ff7a2a\" opacity=\"0.7\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.4;0.85;0.5")), ((V)(1.4)))), "</ellipse>"));
f_2250.V(Call(smoke_77, V.Undef, ct_2265, k_2249, NewObj(8).Put("seed", ((V)("chs"))).Put("n", ((V)(5D))).Put("H", ((V)(50D))).Put("col", ((V)("#9a948e"))).Put("op", ((V)(0.38))).Put("d", ((V)(4.6))).Put("r1", ((V)(11D))).Put("drift", ((V)(18D))).V)).S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_21, V.Undef, ct_2265)), ") scale(", ToStr(Call(n4_20, V.Undef, k_2249)), ")\">", ToStr(Call(embers_75, V.Undef, Call(rng_19, V.Undef, ((V)("che"))), ((V)(4D)), ((V)(6D)), ((V)(8D)))), "</g>"));
un_2252.V(Call(glowE_78, V.Undef, p_2248, ((V)((34D * FdLibm.Sin(TM_2203)))), ((V)(0D)), ((V)((34D * FdLibm.Cos(TM_2203)))), ((V)(26D)), ((V)(18D)), ((V)("#ff8a3a")), ((V)(0.45)), ((V)(1D))));
return NewObj(5).Put("defs", ((V)(JsStrBuf.Begin().V(defs_2253).S(string.Concat("<clipPath id=\"c7m\"><path d=\"", ToStr(INN_2258), "\"/></clipPath>")).V(visClip_2259).End()))).Put("back", ((V)(bk_2251.Str))).Put("under", ((V)(un_2252.Str))).Put("front", ((V)(f_2250.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2248, V.Undef, ((V)((-34D))), ((V)(0D)), ((V)((-34D)))), Call(p_2248, V.Undef, ((V)(34D)), ((V)(0D)), ((V)(34D))), Call(p_2248, V.Undef, ((V)((-34D))), ((V)(0D)), ((V)(34D))), Call(p_2248, V.Undef, ((V)(34D)), ((V)(0D)), ((V)((-34D)))), Call(p_2248, V.Undef, ((V)(0D)), ((V)(((BY_2200 + 92D) + 50D))), ((V)(0D))), Call(p_2248, V.Undef, ((V)(18D)), ((V)(((BY_2200 + 92D) + 50D))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2206;
return default;
}, 1, "", true));
Set(N_33, "bowlPit", Fn((V _arrowThis2433, int _argc2426, V S_2432, V _a2429, V _a2430, V _a2431, V[] _rest2427) => {
V lit_2434 = default;
double BY_2435 = 0;
double RT_2436 = 0;
double LY_2437 = 0;
double LR_2438 = 0;
double LI_2439 = 0;
double AY_2440 = 0;
V STL_2441 = default;
V D_2442 = default;
lit_2434 = Call(isPlay_38, V.Undef, S_2432);
BY_2435 = 13D;
RT_2436 = 33D;
LY_2437 = 31.2;
LR_2438 = 37.5;
LI_2439 = 32D;
AY_2440 = 21D;
STL_2441 = ((V)("#34363b"));
D_2442 = NewObj(4).Put("w", ((V)(84D))).Put("d", ((V)(84D))).Put("round", ((V)(1D))).Put("glow", (Truthy(lit_2434) ? Fn((V _arrowThis2449, int _argc2443, V _a2445, V _a2446, V _a2447, V _a2448, V[] _rest2444) => {
return NewObj(2).Put("y", ((V)(30D))).Put("r", ((V)(70D))).V;
}, 0, "", true) : V.Undef)).V;
Set(D_2442, "build", Fn((V _arrowThis2457, int _argc2450, V P_2456, V _a2453, V _a2454, V _a2455, V[] _rest2451) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(10.5)), ((V)(0D)), ((V)(9D)), ((V)(2.6)), ((V)("#222428")), Call(mt_29, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(BY_2435)), ((V)(0D)), ((V)(RT_2436)), ((V)(17D)), STL_2441, Call(mt_29, V.Undef, NewObj(3).Put("n", ((V)(44D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.42))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.7))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(17D)), ((V)(0D)), ((V)(1D))))).Put("shine", ((V)(1D))).V)), Call(arcW_15, V.Undef, ((V)(0D)), ((V)((LY_2437 - 1.6))), ((V)(0D)), ((V)(LR_2438)), ((V)(LR_2438)), ((V)((LR_2438 - LI_2439))), ((V)(1.6)), ((V)(4.4)), ((V)((4.4 + (2D * PI_34)))), ((V)("#2a2c30")), Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(52D))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
Set(D_2442, "fx", Fn((V _arrowThis2465, int _argc2458, V c_2464, V _a2461, V _a2462, V _a2463, V[] _rest2459) => {
V p_2466 = default;
V k_2467 = default;
JsStrBuf f_2468 = null;
JsStrBuf bk_2469 = null;
JsStrBuf un_2470 = null;
V defs_2471 = default;
JsStrBuf ins_2472 = null;
V RR_2473 = default;
V log_2474 = default;
p_2466 = Get(c_2464, "p");
k_2467 = Get(c_2464, "k");
f_2468 = new JsStrBuf("");
bk_2469 = new JsStrBuf("");
un_2470 = new JsStrBuf("");
defs_2471 = ((V)(JsStrBuf.Begin().V(Add(Add(FDEF_72, Call(G_46, V.Undef, ((V)("b7in")), Arr(Arr(((V)(0D)), ((V)("#151517"))), Arr(((V)(0.6)), ((V)("#1e1f22"))), Arr(((V)(0.85)), ((V)("#3a3c41"))), Arr(((V)(1D)), ((V)("#55585e")))), ((V)("cx=\"50%\" cy=\"58%\" r=\"55%\"")))), Call(G_46, V.Undef, ((V)("b7ash")), Arr(Arr(((V)(0D)), ((V)((Truthy(lit_2434) ? "#ff7a2a" : "#45413d")))), Arr(((V)(0.5)), ((V)((Truthy(lit_2434) ? "#a8422a" : "#5e5953")))), Arr(((V)(1D)), ((V)((Truthy(lit_2434) ? "#b8b2aa" : "#857f77"))))), ((V)("cx=\"50%\" cy=\"50%\" r=\"50%\""))))).S(string.Concat("<clipPath id=\"b7rim\"><path d=\"", ToStr(Call(sp_55, V.Undef, p_2466, Call(ellPts_51, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(LI_2439)), ((V)(LI_2439)), ((V)(60D))), ((V)(LY_2437)))), "\"/></clipPath><clipPath id=\"b7up\"><path d=\"", ToStr(Call(aboveFront_59, V.Undef, p_2466, ((V)(LR_2438)), ((V)(LY_2437)))), "\"/></clipPath>")).End()));
Invoke(Arr(((V)((PI_34 / 12D))), ((V)(((PI_34 / 12D) + (PI_34 / 2D)))), ((V)(((PI_34 / 12D) + PI_34))), ((V)(((PI_34 / 12D) + (1.5 * PI_34))))), "forEach", Fn((V _arrowThis2482, int _argc2475, V t_2481, V _a2478, V _a2479, V _a2480, V[] _rest2476) => {
V pts_2483 = default;
V s_2484 = default;
pts_2483 = Arr(Call(p_2466, V.Undef, ((V)((10D * FdLibm.Sin(ToNum(t_2481))))), ((V)(11D)), ((V)((10D * FdLibm.Cos(ToNum(t_2481)))))), Call(p_2466, V.Undef, ((V)((24D * FdLibm.Sin(ToNum(t_2481))))), ((V)(9.5)), ((V)((24D * FdLibm.Cos(ToNum(t_2481)))))), Call(p_2466, V.Undef, ((V)((33D * FdLibm.Sin(ToNum(t_2481))))), ((V)(0.8)), ((V)((33D * FdLibm.Cos(ToNum(t_2481)))))));
s_2484 = ((V)(JsStrBuf.Begin().V(Call(tube_60, V.Undef, pts_2483, ((V)(1.9)), k_2467, ((V)("#2c2e33")), ((V)("#8a8f98")))).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(GetIdx(pts_2483, 2D), 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, Add(GetIdx(GetIdx(pts_2483, 2D), 1D), ((V)((0.4 * ToNum(k_2467))))))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((2.6 * ToNum(k_2467)))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((1.1 * ToNum(k_2467)))))), "\" fill=\"#141416\"/>")).End()));
if (GtN(Call(facing_58, V.Undef, t_2481), 0D)) {
f_2468.V(s_2484);
} else {
bk_2469.V(s_2484);
}
return default;
}, 1, "", true));
Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis2492, int _argc2485, V i_2491, V _a2488, V _a2489, V _a2490, V[] _rest2486) => {
double th_2493 = 0;
V q_2494 = default;
th_2493 = ((-0.9) + (ToNum(i_2491) * 0.4));
if (LtN(Call(facing_58, V.Undef, ((V)(th_2493))), 0.1)) {
return default;
}
q_2494 = Call(p_2466, V.Undef, ((V)(((RT_2436 - 0.5) * FdLibm.Sin(th_2493)))), ((V)((LY_2437 - 4.5))), ((V)(((RT_2436 - 0.5) * FdLibm.Cos(th_2493)))));
f_2468.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q_2494, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q_2494, 1D))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((5D * ToNum(k_2467)))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((2.2 * ToNum(k_2467)))))), "\" fill=\"#0c0c0e\" opacity=\"0.4\" filter=\"url(#f7b)\"/>"));
return default;
}, 1, "", true));
ins_2472 = new JsStrBuf(string.Concat("<path d=\"", ToStr(Call(sp_55, V.Undef, p_2466, Call(ellPts_51, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(LI_2439)), ((V)(LI_2439)), ((V)(60D))), ((V)(LY_2437)))), "\" fill=\"url(#b7in)\"/><g transform=\"", ToStr(Call(planeH_25, V.Undef, p_2466, ((V)(AY_2440)))), "\"><ellipse rx=\"24\" ry=\"24\" fill=\"url(#b7ash)\"/>"));
RR_2473 = Call(rng_19, V.Undef, ((V)("pitc")));
Call(rep_18, V.Undef, ((V)(26D)), Fn((V _arrowThis2502, int _argc2495, V i_2501, V _a2498, V _a2499, V _a2500, V[] _rest2496) => {
double a_2503 = 0;
double r_2504 = 0;
double x_2505 = 0;
double z_2506 = 0;
a_2503 = ((ToNum(Call(RR_2473, V.Undef)) * 2D) * PI_34);
r_2504 = (System.Math.Sqrt(ToNum(Call(RR_2473, V.Undef))) * 20D);
x_2505 = (r_2504 * FdLibm.Cos(a_2503));
z_2506 = (r_2504 * FdLibm.Sin(a_2503));
ins_2472.S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_17, V.Undef, ((V)(x_2505)))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, ((V)(z_2506)))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, Add(((V)(1.4)), Call(RR_2473, V.Undef)))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((1.1 + (ToNum(Call(RR_2473, V.Undef)) * 0.8)))))), "\" fill=\"", (Truthy(lit_2434) ? (NumTruthy((ToNum(i_2501) % 3D)) ? "#ff5a1a" : "#ffb347") : (NumTruthy((ToNum(i_2501) % 3D)) ? "#1d1c1b" : "#3a3836")), "\">", ToStr((Truthy(lit_2434) ? Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.55;1;0.6")), Call(n4_20, V.Undef, Add(((V)(0.8)), Call(RR_2473, V.Undef))), Call(n4_20, V.Undef, ((V)((-ToNum(Call(RR_2473, V.Undef))))))) : ((V)("")))), "</ellipse>"));
return default;
}, 1, "", true));
ins_2472.S("</g>");
log_2474 = Fn((V _arrowThis2515, int _argc2507, V a_2513, V b_2514, V _a2511, V _a2512, V[] _rest2508) => {
V A_2516 = default;
V Bq_2517 = default;
A_2516 = CallSpread(p_2466, V.Undef, new ArrBuilder().Spread(a_2513).V);
Bq_2517 = CallSpread(p_2466, V.Undef, new ArrBuilder().Spread(b_2514).V);
return ((V)(string.Concat("<path d=\"M", ToStr(Call(P2_21, V.Undef, A_2516)), "L", ToStr(Call(P2_21, V.Undef, Bq_2517)), "\" stroke=\"#1a120c\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((4.8 * ToNum(k_2467)))))), "\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Call(P2_21, V.Undef, A_2516)), "L", ToStr(Call(P2_21, V.Undef, Bq_2517)), "\" stroke=\"", (Truthy(lit_2434) ? "#3a2416" : "#6e4a2c"), "\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((3.8 * ToNum(k_2467)))))), "\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Call(P2_21, V.Undef, A_2516)), "L", ToStr(Call(P2_21, V.Undef, Bq_2517)), "\" stroke=\"", (Truthy(lit_2434) ? "#ff6a1a" : "#9a7048"), "\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.6 * ToNum(k_2467)))))), "\" stroke-dasharray=\"", ToStr(Call(f1_17, V.Undef, ((V)((2D * ToNum(k_2467)))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((1.6 * ToNum(k_2467)))))), "\" transform=\"translate(0 ", ToStr(Call(f1_17, V.Undef, ((V)(((-0.9) * ToNum(k_2467)))))), ")\">", ToStr((Truthy(lit_2434) ? Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.4;1;0.5")), ((V)(1D))) : ((V)("")))), "</path><circle cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(Bq_2517, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(Bq_2517, 1D))), "\" r=\"", ToStr(Call(f1_17, V.Undef, ((V)((1.9 * ToNum(k_2467)))))), "\" fill=\"", (Truthy(lit_2434) ? "#ff8a3a" : "#d1aa78"), "\" stroke=\"#5a3a20\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.3 * ToNum(k_2467)))))), "\"/><circle cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(Bq_2517, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(Bq_2517, 1D))), "\" r=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.9 * ToNum(k_2467)))))), "\" fill=\"none\" stroke=\"#8a5a34\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.2 * ToNum(k_2467)))))), "\"/>")));
return default;
}, 2, "", true);
ins_2472.V(Add(Add(Call(log_2474, V.Undef, Arr(((V)((-15D))), ((V)(22.5)), ((V)((-4D)))), Arr(((V)(14D)), ((V)(25.5)), ((V)(5D)))), Call(log_2474, V.Undef, Arr(((V)((-9D))), ((V)(23.5)), ((V)(12D))), Arr(((V)(12D)), ((V)(26D)), ((V)((-9D)))))), Call(log_2474, V.Undef, Arr(((V)(2D)), ((V)(22.5)), ((V)((-15D)))), Arr(((V)((-1D))), ((V)(27.5)), ((V)(12D))))));
f_2468.S(string.Concat("<g clip-path=\"url(#b7rim)\">", ins_2472.Str, "</g>"));
if (Truthy(lit_2434)) {
f_2468.S(string.Concat("<g clip-path=\"url(#b7up)\">", ToStr(Add(Add(Call(flames_76, V.Undef, Call(p_2466, V.Undef, ((V)(0D)), ((V)(25D)), ((V)(0D))), k_2467, NewObj(6).Put("seed", ((V)("pit"))).Put("n", ((V)(7D))).Put("sp", ((V)(11D))).Put("h", ((V)(28D))).Put("w", ((V)(3.8))).Put("emb", ((V)(6D))).V), Call(flames_76, V.Undef, Call(p_2466, V.Undef, ((V)((-10D))), ((V)(23D)), ((V)(6D))), ((V)((ToNum(k_2467) * 0.7))), NewObj(6).Put("seed", ((V)("pit2"))).Put("n", ((V)(3D))).Put("sp", ((V)(4D))).Put("h", ((V)(16D))).Put("noGlow", ((V)(1D))).Put("emb", ((V)(0D))).V)), Call(flames_76, V.Undef, Call(p_2466, V.Undef, ((V)(10D)), ((V)(23D)), ((V)((-4D)))), ((V)((ToNum(k_2467) * 0.7))), NewObj(6).Put("seed", ((V)("pit3"))).Put("n", ((V)(3D))).Put("sp", ((V)(4D))).Put("h", ((V)(15D))).Put("noGlow", ((V)(1D))).Put("emb", ((V)(0D))).V))), "</g>"));
f_2468.S(string.Concat("<path d=\"M", ToStr(Invoke(Invoke(Call(ellPts_51, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((LI_2439 + 0.5))), ((V)((LI_2439 + 0.5))), ((V)(20D)), ((V)(((5D * PI_34) / 6D))), ((V)(((11D * PI_34) / 6D)))), "map", Fn((V _arrowThis2525, int _argc2518, V q_2524, V _a2521, V _a2522, V _a2523, V[] _rest2519) => {
return Call(P2_21, V.Undef, Call(p_2466, V.Undef, GetIdx(q_2524, 0D), ((V)(LY_2437)), GetIdx(q_2524, 1D)));
}, 1, "", true)), "join", ((V)("L")))), "\" fill=\"none\" stroke=\"#ff9a4a\" stroke-width=\"", ToStr(Call(f1_17, V.Undef, ((V)((1.4 * ToNum(k_2467)))))), "\" opacity=\"0.55\" filter=\"url(#f7b)\"/>"));
f_2468.V(Call(smoke_77, V.Undef, Call(p_2466, V.Undef, ((V)(0D)), ((V)(52D)), ((V)(0D))), k_2467, NewObj(7).Put("seed", ((V)("pits"))).Put("n", ((V)(6D))).Put("H", ((V)(60D))).Put("op", ((V)(0.3))).Put("d", ((V)(5D))).Put("r1", ((V)(14D))).Put("drift", ((V)(16D))).V));
un_2470.V(Call(glowE_78, V.Undef, p_2466, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(52D)), ((V)(52D)), ((V)("#ff8a3a")), ((V)(0.5)), ((V)(1D))));
}
f_2468.V(Add(Add(Call(tube_60, V.Undef, Arr(Call(p_2466, V.Undef, ((V)((-30D))), ((V)(0.6)), ((V)(28D))), Call(p_2466, V.Undef, ((V)((-27D))), ((V)(31.4)), ((V)(17D)))), ((V)(0.8)), k_2467, ((V)("#3a3c42")), ((V)("#a0a6b0"))), Call(tube_60, V.Undef, Arr(Call(p_2466, V.Undef, ((V)((-27D))), ((V)(31.4)), ((V)(17D))), Call(p_2466, V.Undef, ((V)((-26.2))), ((V)(34D)), ((V)(15.4)))), ((V)(1.3)), k_2467, ((V)("#6e4a2c")), ((V)("#c09060")))), Call(tube_60, V.Undef, Arr(Call(p_2466, V.Undef, ((V)((-30D))), ((V)(0.6)), ((V)(28D))), Call(p_2466, V.Undef, ((V)((-32.4))), ((V)(2.6)), ((V)(29.4)))), ((V)(0.8)), k_2467, ((V)("#3a3c42")), ((V)("#a0a6b0")))));
return NewObj(5).Put("defs", defs_2471).Put("back", ((V)(bk_2469.Str))).Put("under", ((V)(un_2470.Str))).Put("front", ((V)(f_2468.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2466, V.Undef, ((V)((-40D))), ((V)(0D)), ((V)((-40D)))), Call(p_2466, V.Undef, ((V)(40D)), ((V)(0D)), ((V)(40D))), Call(p_2466, V.Undef, ((V)((-40D))), ((V)(0D)), ((V)(40D))), Call(p_2466, V.Undef, ((V)(40D)), ((V)(0D)), ((V)((-40D)))), Call(p_2466, V.Undef, ((V)(0D)), ((V)((Truthy(lit_2434) ? 112D : 34D))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2442;
return default;
}, 1, "", true));
Set(N_33, "kettle", Fn((V _arrowThis2533, int _argc2526, V S_2532, V _a2529, V _a2530, V _a2531, V[] _rest2527) => {
double TM0_2534 = 0;
V lit_2535 = default;
V RED_2536 = default;
double BY_2537 = 0;
double BR_2538 = 0;
double RY_2539 = 0;
V LID_2540 = default;
V D_2541 = default;
V LEG_2542 = default;
V closedLid_2543 = default;
V hungLid_2544 = default;
TM0_2534 = (PI_34 / 6D);
lit_2535 = Call(isPlay_38, V.Undef, S_2532);
RED_2536 = ((V)("#c41e26"));
BY_2537 = 40D;
BR_2538 = 27D;
RY_2539 = 58.8;
LID_2540 = Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(5D)), ((V)(0D)), ((V)(0.96))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.84))), Arr(((V)(15D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(18D)), ((V)(0D)), ((V)(0.3))), Arr(((V)(19D)), ((V)(0D)), ((V)(0.1))));
D_2541 = NewObj(3).Put("w", ((V)(80D))).Put("d", ((V)(80D))).Put("round", ((V)(1D))).V;
LEG_2542 = Arr(((V)((PI_34 / 6D))), ((V)(((PI_34 / 6D) + 2.1))), ((V)(((PI_34 / 6D) + 4.2))));
Set(D_2541, "build", Fn((V _arrowThis2552, int _argc2545, V P_2551, V _a2548, V _a2549, V _a2550, V[] _rest2546) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(BY_2537)), ((V)(0D)), ((V)(BR_2538)), ((V)(18D)), RED_2536, Call(cer_31, V.Undef, NewObj(3).Put("n", ((V)(44D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.32))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.66))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(18D)), ((V)(0D)), ((V)(1D))))).Put("shine", ((V)(1D))).V)), Call(arcW_15, V.Undef, ((V)(0D)), ((V)((RY_2539 - 1.4))), ((V)(0D)), ((V)((BR_2538 + 0.6))), ((V)((BR_2538 + 0.6))), ((V)(1.4)), ((V)(1.4)), ((V)(4.4)), ((V)((4.4 + (2D * PI_34)))), CH_36, Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(44D))).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)(31D)), ((V)(0D)), ((V)(10D)), ((V)(4D)), CH_36, Call(mt_29, V.Undef, NewObj(3).Put("n", ((V)(24D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.72))), Arr(((V)(4D)), ((V)(0D)), ((V)(1D))))).Put("shine", ((V)(1D))).V)));
}, 1, "", true));
closedLid_2543 = Fn((V _arrowThis2560, int _argc2553, V P_2559, V _a2556, V _a2557, V _a2558, V[] _rest2554) => {
return Arr(Call(cyl_13, V.Undef, ((V)(0D)), ((V)(RY_2539)), ((V)(0D)), ((V)((BR_2538 + 0.6))), ((V)(19D)), RED_2536, Call(cer_31, V.Undef, NewObj(3).Put("n", ((V)(44D))).Put("rg", LID_2540).Put("shine", ((V)(1D))).V)), Call(cyl_13, V.Undef, ((V)(0D)), ((V)((RY_2539 + 17.6))), ((V)(0D)), ((V)(6D)), ((V)(1.4)), CH_36, Call(mt_29, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)((RY_2539 + 20.6))), ((V)(9D)), ((V)(18D)), ((V)(2.6)), ((V)(3.2)), ((V)("#1a1a1d")), Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1.3))).V)), Call(box_12, V.Undef, ((V)((-7D))), ((V)((RY_2539 + 16.6))), ((V)(9D)), ((V)(1.4)), ((V)(4.2)), ((V)(1.4)), CH_36, Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(box_12, V.Undef, ((V)(7D)), ((V)((RY_2539 + 16.6))), ((V)(9D)), ((V)(1.4)), ((V)(4.2)), ((V)(1.4)), CH_36, Call(mt_29, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)));
}, 1, "", true);
hungLid_2544 = Fn((V _arrowThis2568, int _argc2561, V P_2567, V _a2564, V _a2565, V _a2566, V[] _rest2562) => {
return Arr(Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(48D)))).Put("a", ((V)((BR_2538 + 0.6)))).Put("b", ((V)((BR_2538 + 0.6)))).Put("n", ((V)(44D))).Put("rings", Invoke(LID_2540, "map", Fn((V _arrowThis2576, int _argc2569, V r_2575, V _a2572, V _a2573, V _a2574, V[] _rest2570) => {
return Arr(Add(((V)((BR_2538 + 2D))), GetIdx(r_2575, 0D)), ((V)(0D)), GetIdx(r_2575, 2D));
}, 1, "", true))).Put("col", RED_2536).Put("mat", ((V)("cer"))).Put("shine", ((V)(1D))).V), Call(solid_11, V.Undef, NewObj(10).Put("ax", ((V)("x"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)(0D)), ((V)(48D)))).Put("a", ((V)(6D))).Put("b", ((V)(6D))).Put("n", ((V)(18D))).Put("rings", Arr(Arr(((V)((BR_2538 + 19.6))), ((V)(0D))), Arr(((V)((BR_2538 + 21D))), ((V)(0D))))).Put("col", CH_36).Put("mat", ((V)("metal"))).Put("shine", ((V)(1D))).V));
}, 1, "", true);
Set(D_2541, "layers", (Truthy((lit_2535 is var _t2595 && !Truthy(_t2595) ? _t2595 : Get(G("window"), "R7END"))) ? Arr(NewObj(1).Put("build", hungLid_2544).V) : (Truthy(lit_2535) ? Arr(NewObj(2).Put("build", closedLid_2543).Put("wrap", Fn((V _arrowThis2585, int _argc2577, V p_2583, V s_2584, V _a2581, V _a2582, V[] _rest2578) => {
return ((V)(string.Concat("<g>", ToStr(Call(once_43, V.Undef, ((V)("opacity")), ((V)("1;1;0")), ((V)("0;0.4;1")), ((V)(0.7)))), "<g>", ToStr(Call(onceT_44, V.Undef, ((V)("translate")), ((V)("0 0;0 -14;12 -20")), ((V)("0;0.6;1")), ((V)(0.7)))), ToStr(s_2584), "</g></g>")));
}, 2, "wrap", true)).V, NewObj(2).Put("build", hungLid_2544).Put("wrap", Fn((V _arrowThis2594, int _argc2586, V p_2592, V s_2593, V _a2590, V _a2591, V[] _rest2587) => {
return ((V)(string.Concat("<g opacity=\"0\">", ToStr(Call(once_43, V.Undef, ((V)("opacity")), ((V)("0;0;1")), ((V)("0;0.5;1")), ((V)(0.9)))), ToStr(s_2593), "</g>")));
}, 2, "wrap", true)).V) : Arr(NewObj(1).Put("build", closedLid_2543).V))));
Set(D_2541, "fx", Fn((V _arrowThis2603, int _argc2596, V c_2602, V _a2599, V _a2600, V _a2601, V[] _rest2597) => {
V p_2604 = default;
V k_2605 = default;
JsStrBuf f_2606 = null;
JsStrBuf bk_2607 = null;
JsStrBuf un_2608 = null;
JsStrBuf defs_2609 = null;
p_2604 = Get(c_2602, "p");
k_2605 = Get(c_2602, "k");
f_2606 = new JsStrBuf("");
bk_2607 = new JsStrBuf("");
un_2608 = new JsStrBuf("");
defs_2609 = new JsStrBuf(JsStrBuf.Begin().V(Add(FDEF_72, Call(G_46, V.Undef, ((V)("k7bowl")), Arr(Arr(((V)(0D)), ((V)("#0e0e10"))), Arr(((V)(0.7)), ((V)("#1c1c1f"))), Arr(((V)(1D)), ((V)("#3a3a40")))), ((V)("cx=\"50%\" cy=\"60%\" r=\"55%\""))))).S(string.Concat("<clipPath id=\"k7rimK\"><path d=\"", ToStr(Call(sp_55, V.Undef, p_2604, Call(ellPts_51, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((BR_2538 - 0.4))), ((V)((BR_2538 - 0.4))), ((V)(60D))), ((V)(RY_2539)))), "\"/></clipPath>")).End());
Invoke(LEG_2542, "forEach", Fn((V _arrowThis2618, int _argc2610, V t_2616, V i_2617, V _a2614, V _a2615, V[] _rest2611) => {
V a_2619 = default;
V b_2620 = default;
V s_2621 = default;
a_2619 = Call(p_2604, V.Undef, ((V)((21D * FdLibm.Sin(ToNum(t_2616))))), ((V)((BY_2537 + 4D))), ((V)((21D * FdLibm.Cos(ToNum(t_2616))))));
b_2620 = Call(p_2604, V.Undef, ((V)((30D * FdLibm.Sin(ToNum(t_2616))))), ((V)(2.4)), ((V)((30D * FdLibm.Cos(ToNum(t_2616))))));
s_2621 = Call(tube_60, V.Undef, Arr(a_2619, b_2620), ((V)(2.4)), k_2605, ((V)("#1d1e22")), ((V)("#6a6e78")));
if (Truthy(i_2617)) {
s_2621 = ((V)(JsStrBuf.Begin().V(s_2621).S(string.Concat("<g transform=\"", ToStr(Call(planeT_57, V.Undef, p_2604, ((V)(0D)), ((V)(0D)), ((V)(31.5)), t_2616, ((V)(2.6)))), "\"><circle r=\"4.4\" fill=\"#141416\"/><circle r=\"2.4\" fill=\"#5a5e66\"/><circle r=\"0.9\" fill=\"", ToStr(CH_36), "\"/></g>")).End()));
} else {
s_2621 = ((V)(JsStrBuf.Begin().V(s_2621).S(string.Concat("<ellipse cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(b_2620, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, Add(GetIdx(b_2620, 1D), ((V)((1.4 * ToNum(k_2605))))))), "\" rx=\"", ToStr(Call(f1_17, V.Undef, ((V)((2D * ToNum(k_2605)))))), "\" ry=\"", ToStr(Call(f1_17, V.Undef, ((V)((1D * ToNum(k_2605)))))), "\" fill=\"#141416\"/>")).End()));
}
if (GtN(Call(facing_58, V.Undef, t_2616), (-0.2))) {
f_2606.V(s_2621);
} else {
bk_2607.V(s_2621);
}
return default;
}, 2, "", true));
{
V tri_2622 = default;
tri_2622 = Invoke(LEG_2542, "map", Fn((V _arrowThis2630, int _argc2623, V t_2629, V _a2626, V _a2627, V _a2628, V[] _rest2624) => {
return Call(p_2604, V.Undef, ((V)((26.4 * FdLibm.Sin(ToNum(t_2629))))), ((V)(16D)), ((V)((26.4 * FdLibm.Cos(ToNum(t_2629))))));
}, 1, "", true));
bk_2607.V(Call(tube_60, V.Undef, Arr(GetIdx(tri_2622, 1D), GetIdx(tri_2622, 2D)), ((V)(1D)), k_2605, ((V)("#3a3b40")), ((V)("#8a8f98"))));
f_2606.V(Call(tube_60, V.Undef, Arr(GetIdx(tri_2622, 2D), GetIdx(tri_2622, 0D), GetIdx(tri_2622, 1D)), ((V)(1D)), k_2605, ((V)("#3a3b40")), ((V)("#8a8f98"))));
}
{
V th_2631 = default;
th_2631 = Fn((V _arrowThis2639, int _argc2632, V TH_2638, V _a2635, V _a2636, V _a2637, V[] _rest2633) => {
return Call(p_2604, V.Undef, ((V)(((BR_2538 + 1D) * FdLibm.Sin(ToNum(TH_2638))))), ((V)((RY_2539 - 4D))), ((V)(((BR_2538 + 1D) * FdLibm.Cos(ToNum(TH_2638))))));
}, 1, "", true);
f_2606.V(Call(tube_60, V.Undef, Arr(Call(th_2631, V.Undef, ((V)(1.2))), Call(p_2604, V.Undef, ((V)(((BR_2538 + 5D) * FdLibm.Sin(1.35)))), ((V)((RY_2539 - 3.4))), ((V)(((BR_2538 + 5D) * FdLibm.Cos(1.35))))), Call(p_2604, V.Undef, ((V)(((BR_2538 + 5D) * FdLibm.Sin(1.75)))), ((V)((RY_2539 - 3.4))), ((V)(((BR_2538 + 5D) * FdLibm.Cos(1.75))))), Call(th_2631, V.Undef, ((V)(1.9)))), ((V)(1.4)), k_2605, ((V)("#1a1a1d")), ((V)("#5a5e66"))));
}
if (!(Truthy(lit_2535))) {
V vq_2640 = default;
f_2606.S(string.Concat("<g transform=\"", ToStr(Call(planeT_57, V.Undef, p_2604, ((V)(0D)), ((V)(0D)), ((V)((BR_2538 * 0.97))), ((V)(TM0_2534)), ((V)((RY_2539 + 6D))))), "\"><circle r=\"3.4\" fill=\"", ToStr(CH_36), "\" stroke=\"#7a8088\" stroke-width=\"0.4\"/><circle r=\"2.7\" fill=\"#fbfaf4\"/>", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(9D)), Fn((V _arrowThis2648, int _argc2641, V i_2647, V _a2644, V _a2645, V _a2646, V[] _rest2642) => {
return ((V)(string.Concat("<path d=\"M0 -2.4V-1.9\" stroke=\"#3a3a40\" stroke-width=\"0.25\" transform=\"rotate(", NumStr(((-120D) + (ToNum(i_2647) * 30D))), ")\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<path d=\"M0 0L1.6 -1.2\" stroke=\"#e8343c\" stroke-width=\"0.4\" stroke-linecap=\"round\"/><circle r=\"0.4\" fill=\"#3a3a40\"/></g>"));
vq_2640 = Call(p_2604, V.Undef, ((V)(0D)), ((V)((RY_2539 + 19D))), ((V)(0D)));
f_2606.S(string.Concat("<g transform=\"", ToStr(Call(planeH_25, V.Undef, p_2604, ((V)((RY_2539 + 19.05))))), "\">", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(3D)), Fn((V _arrowThis2656, int _argc2649, V i_2655, V _a2652, V _a2653, V _a2654, V[] _rest2650) => {
return ((V)(string.Concat("<path d=\"M0 0L", ToStr(Call(f1_17, V.Undef, ((V)((4D * FdLibm.Cos((ToNum(i_2655) * 2.1))))))), " ", ToStr(Call(f1_17, V.Undef, ((V)((4D * FdLibm.Sin((ToNum(i_2655) * 2.1))))))), "\" stroke=\"#7a8088\" stroke-width=\"1.1\" stroke-linecap=\"round\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<circle r=\"1.1\" fill=\"#9aa1ad\"/></g>"));
_ = vq_2640;
}
if (Truthy(lit_2535)) {
JsStrBuf ins_2657 = null;
V RR_2658 = default;
V patty_2659 = default;
V saus_2660 = default;
V RS_2661 = default;
ins_2657 = new JsStrBuf(string.Concat("<path d=\"", ToStr(Call(sp_55, V.Undef, p_2604, Call(ellPts_51, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(BR_2538)), ((V)(BR_2538)), ((V)(60D))), ((V)(RY_2539)))), "\" fill=\"url(#k7bowl)\"/><g transform=\"", ToStr(Call(planeH_25, V.Undef, p_2604, ((V)(49D)))), "\">"));
RR_2658 = Call(rng_19, V.Undef, ((V)("kco")));
Call(rep_18, V.Undef, ((V)(34D)), Fn((V _arrowThis2669, int _argc2662, V i_2668, V _a2665, V _a2666, V _a2667, V[] _rest2663) => {
double a_2670 = 0;
double r_2671 = 0;
double x_2672 = 0;
double z_2673 = 0;
a_2670 = ((ToNum(Call(RR_2658, V.Undef)) * 2D) * PI_34);
r_2671 = (System.Math.Sqrt(ToNum(Call(RR_2658, V.Undef))) * 17D);
x_2672 = (r_2671 * FdLibm.Cos(a_2670));
z_2673 = (r_2671 * FdLibm.Sin(a_2670));
ins_2657.S(string.Concat("<rect x=\"", ToStr(Call(f1_17, V.Undef, ((V)((x_2672 - 1.8))))), "\" y=\"", ToStr(Call(f1_17, V.Undef, ((V)((z_2673 - 1.6))))), "\" width=\"3.6\" height=\"3.2\" rx=\"1.3\" fill=\"#d8d2c8\" transform=\"rotate(", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(Call(RR_2658, V.Undef)) * 90D))))), " ", ToStr(Call(f1_17, V.Undef, ((V)(x_2672)))), " ", ToStr(Call(f1_17, V.Undef, ((V)(z_2673)))), ")\"/><rect x=\"", ToStr(Call(f1_17, V.Undef, ((V)((x_2672 - 1.2))))), "\" y=\"", ToStr(Call(f1_17, V.Undef, ((V)((z_2673 - 1D))))), "\" width=\"2.4\" height=\"2\" rx=\"0.9\" fill=\"#ff5a1a\">", ToStr(Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.5;1;0.6")), Call(n4_20, V.Undef, Add(((V)(0.8)), Call(RR_2658, V.Undef))), Call(n4_20, V.Undef, ((V)((-ToNum(Call(RR_2658, V.Undef)))))))), "</rect>"));
return default;
}, 1, "", true));
ins_2657.S("</g>");
ins_2657.S(string.Concat("<g transform=\"", ToStr(Call(planeH_25, V.Undef, p_2604, ((V)(55D)))), "\">")).V(Invoke(Call(rep_18, V.Undef, ((V)(15D)), Fn((V _arrowThis2681, int _argc2674, V i_2680, V _a2677, V _a2678, V _a2679, V[] _rest2675) => {
return ((V)(string.Concat("<path d=\"M", NumStr((-26D)), " ", ToStr(Call(f1_17, V.Undef, ((V)(((-24D) + (ToNum(i_2680) * 3.4)))))), "H26\" stroke=\"#2a2b30\" stroke-width=\"0.9\"/><path d=\"M", NumStr((-26D)), " ", ToStr(Call(f1_17, V.Undef, ((V)(((-24.4) + (ToNum(i_2680) * 3.4)))))), "H26\" stroke=\"#c9d0d6\" stroke-width=\"0.45\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<circle r=\"25.6\" fill=\"none\" stroke=\"#c9d0d6\" stroke-width=\"0.9\"/>", ""));
patty_2659 = Fn((V _arrowThis2690, int _argc2682, V x_2688, V z_2689, V _a2686, V _a2687, V[] _rest2683) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(x_2688), " ", ToStr(z_2689), ")\"><ellipse rx=\"6.2\" ry=\"6.2\" fill=\"#4a2a18\"/><ellipse rx=\"5.6\" ry=\"5.6\" fill=\"#7a4a2a\"/>", ToStr(Invoke(Invoke(Arr(((V)((-2.6))), ((V)(0D)), ((V)(2.6))), "map", Fn((V _arrowThis2698, int _argc2691, V d_2697, V _a2694, V _a2695, V _a2696, V[] _rest2692) => {
return ((V)(string.Concat("<path d=\"M-4.6 ", NumStr((ToNum(d_2697) - 1.4)), "L4.6 ", ToStr(Add(d_2697, ((V)(1.4)))), "\" stroke=\"#2a1608\" stroke-width=\"0.9\" stroke-linecap=\"round\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<path d=\"M-4.4 -4.4H4.4V3.6L2 6L1 3.6L-1 5.4L-4.4 3.2Z\" fill=\"#ffc02e\" opacity=\"0.92\"/></g>")));
}, 2, "", true);
saus_2660 = Fn((V _arrowThis2708, int _argc2699, V x_2705, V z_2706, V a_2707, V _a2704, V[] _rest2700) => {
return ((V)(string.Concat("<g transform=\"translate(", ToStr(x_2705), " ", ToStr(z_2706), ") rotate(", ToStr(a_2707), ")\"><rect x=\"-8\" y=\"-2\" width=\"16\" height=\"4\" rx=\"2\" fill=\"#7a2a1a\"/><rect x=\"-7.6\" y=\"-1.6\" width=\"15.2\" height=\"1.6\" rx=\"0.8\" fill=\"#b4542e\"/>", ToStr(Invoke(Invoke(Arr(((V)((-4D))), ((V)(0D)), ((V)(4D))), "map", Fn((V _arrowThis2716, int _argc2709, V d_2715, V _a2712, V _a2713, V _a2714, V[] _rest2710) => {
return ((V)(string.Concat("<path d=\"M", NumStr((ToNum(d_2715) - 1D)), " -1.8L", ToStr(Add(d_2715, ((V)(1D)))), " 1.8\" stroke=\"#2a1008\" stroke-width=\"0.7\"/>")));
}, 1, "", true)), "join", ((V)("")))), "</g>")));
}, 3, "", true);
ins_2657.V(Add(Add(Add(Call(patty_2659, V.Undef, ((V)((-9D))), ((V)((-6D)))), Call(patty_2659, V.Undef, ((V)(9D)), ((V)(4D)))), Call(saus_2660, V.Undef, ((V)((-6D))), ((V)(12D)), ((V)(10D)))), Call(saus_2660, V.Undef, ((V)(10D)), ((V)((-12D))), ((V)((-14D)))))).S(string.Concat("<g transform=\"translate(-14 8) rotate(-60)\"><rect x=\"-6\" y=\"-2.2\" width=\"12\" height=\"4.4\" rx=\"2.2\" fill=\"#f2c14a\"/>", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(10D)), Fn((V _arrowThis2724, int _argc2717, V i_2723, V _a2720, V _a2721, V _a2722, V[] _rest2718) => {
return ((V)(string.Concat("<circle cx=\"", NumStr(((-5D) + (ToNum(i_2723) * 1.1))), "\" cy=\"", NumStr((NumTruthy((ToNum(i_2723) % 2D)) ? (-1D) : 1D)), "\" r=\"0.5\" fill=\"#d89a1a\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<path d=\"M6 0L9 -2.4L8.4 1.6Z\" fill=\"#8aa84a\"/></g></g>"));
f_2606.S((Truthy(Get(G("window"), "R7END")) ? string.Concat("<g clip-path=\"url(#k7rimK)\">", ins_2657.Str, "</g>") : string.Concat("<g clip-path=\"url(#k7rimK)\" opacity=\"0\">", ToStr(Call(once_43, V.Undef, ((V)("opacity")), ((V)("0;0;1")), ((V)("0;0.45;1")), ((V)(0.8)))), ins_2657.Str, "</g>")));
RS_2661 = Call(rng_19, V.Undef, ((V)("siz")));
Call(rep_18, V.Undef, ((V)(8D)), Fn((V _arrowThis2732, int _argc2725, V i_2731, V _a2728, V _a2729, V _a2730, V[] _rest2726) => {
V q_2733 = default;
double d_2734 = 0;
q_2733 = Call(p_2604, V.Undef, ((V)(((ToNum(Call(RS_2661, V.Undef)) - 0.5) * 30D))), ((V)(56D)), ((V)(((ToNum(Call(RS_2661, V.Undef)) - 0.5) * 30D))));
d_2734 = (0.6 + (ToNum(Call(RS_2661, V.Undef)) * 0.5));
f_2606.S(string.Concat("<circle cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q_2733, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q_2733, 1D))), "\" r=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.5 * ToNum(k_2605)))))), "\" fill=\"#fff6c8\" opacity=\"0\"><animate attributeName=\"cy\" values=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q_2733, 1D))), ";", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(GetIdx(q_2733, 1D)) - (6D * ToNum(k_2605))))))), "\" dur=\"", ToStr(Call(n4_20, V.Undef, ((V)(d_2734)))), "s\" begin=\"", ToStr(Call(n4_20, V.Undef, Add(((V)(0.8)), Call(RS_2661, V.Undef)))), "s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0;1;0\" dur=\"", ToStr(Call(n4_20, V.Undef, ((V)(d_2734)))), "s\" begin=\"", ToStr(Call(n4_20, V.Undef, Add(((V)(0.8)), Call(RS_2661, V.Undef)))), "s\" repeatCount=\"indefinite\"/></circle>"));
return default;
}, 1, "", true));
f_2606.V(Call(smoke_77, V.Undef, Call(p_2604, V.Undef, ((V)(0D)), ((V)(60D)), ((V)(0D))), k_2605, NewObj(8).Put("seed", ((V)("kts"))).Put("n", ((V)(7D))).Put("H", ((V)(72D))).Put("col", ((V)("#d4cfc8"))).Put("op", ((V)(0.42))).Put("d", ((V)(5D))).Put("r1", ((V)(16D))).Put("drift", ((V)(20D))).V)).S(string.Concat("<g clip-path=\"url(#k7up)\">", ToStr(Call(flames_76, V.Undef, Call(p_2604, V.Undef, ((V)((-12D))), ((V)(52D)), ((V)(4D))), ((V)((ToNum(k_2605) * 0.5))), NewObj(5).Put("seed", ((V)("kf1"))).Put("n", ((V)(3D))).Put("sp", ((V)(3D))).Put("h", ((V)(9D))).Put("emb", ((V)(2D))).V)), ToStr(Call(flames_76, V.Undef, Call(p_2604, V.Undef, ((V)(12D)), ((V)(52D)), ((V)((-6D)))), ((V)((ToNum(k_2605) * 0.5))), NewObj(5).Put("seed", ((V)("kf2"))).Put("n", ((V)(3D))).Put("sp", ((V)(3D))).Put("h", ((V)(9D))).Put("emb", ((V)(2D))).V)), "</g>"));
defs_2609.S(string.Concat("<clipPath id=\"k7up\"><path d=\"", ToStr(Call(aboveFront_59, V.Undef, p_2604, ((V)(BR_2538)), ((V)(RY_2539)))), "\"/></clipPath>"));
un_2608.V(Call(glowE_78, V.Undef, p_2604, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(36D)), ((V)(36D)), ((V)("#ff8a3a")), ((V)(0.2)), ((V)(1D))));
}
return NewObj(5).Put("defs", ((V)(defs_2609.Str))).Put("back", ((V)(bk_2607.Str))).Put("under", ((V)(un_2608.Str))).Put("front", ((V)(f_2606.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2604, V.Undef, ((V)((-34D))), ((V)(0D)), ((V)((-34D)))), Call(p_2604, V.Undef, ((V)(34D)), ((V)(0D)), ((V)(34D))), Call(p_2604, V.Undef, ((V)((-34D))), ((V)(0D)), ((V)(34D))), Call(p_2604, V.Undef, ((V)(34D)), ((V)(0D)), ((V)((-34D)))), Call(p_2604, V.Undef, ((V)(0D)), ((V)((Truthy(lit_2535) ? 136D : 82D))), ((V)(0D))), Call(p_2604, V.Undef, ((V)((BR_2538 + 24D))), ((V)(76D)), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2541;
return default;
}, 1, "", true));
Set(N_33, "hibachi", Fn((V _arrowThis2742, int _argc2735, V S_2741, V _a2738, V _a2739, V _a2740, V[] _rest2736) => {
V lit_2743 = default;
V CI_2744 = default;
V CI2_2745 = default;
double W_2746 = 0;
double DZ_2747 = 0;
double Y0_2748 = 0;
double H_2749 = 0;
double TOP_2750 = 0;
double GY_2751 = 0;
V D_2752 = default;
lit_2743 = Call(isPlay_38, V.Undef, S_2741);
CI_2744 = ((V)("#34302c"));
CI2_2745 = ((V)("#2a2724"));
W_2746 = 66D;
DZ_2747 = 34D;
Y0_2748 = 4D;
H_2749 = 13D;
TOP_2750 = (Y0_2748 + H_2749);
GY_2751 = 21D;
D_2752 = NewObj(3).Put("w", ((V)(96D))).Put("d", ((V)(50D))).Put("glow", (Truthy(lit_2743) ? Fn((V _arrowThis2759, int _argc2753, V _a2755, V _a2756, V _a2757, V _a2758, V[] _rest2754) => {
return NewObj(2).Put("y", ((V)(20D))).Put("r", ((V)(50D))).V;
}, 0, "", true) : V.Undef)).V;
Set(D_2752, "build", Fn((V _arrowThis2767, int _argc2760, V P_2766, V _a2763, V _a2764, V _a2765, V[] _rest2761) => {
V o_2768 = default;
o_2768 = Arr();
Invoke(Arr(Arr(((V)((-27D))), ((V)((-12D)))), Arr(((V)(27D)), ((V)((-12D)))), Arr(((V)((-27D))), ((V)(12D))), Arr(((V)(27D)), ((V)(12D)))), "forEach", Fn((V _arrowThis2780, int _argc2769, V _a2771, V _a2772, V _a2773, V _a2774, V[] _rest2770) => {
V x_2777 = default;
V z_2779 = default;
{ V _t2775 = ListOf(_a2771);
{ V _t2776 = GetIdx(_t2775, 0D);
x_2777 = _t2776; }
{ V _t2778 = GetIdx(_t2775, 1D);
z_2779 = _t2778; }
}
return Invoke(o_2768, "push", Call(box_12, V.Undef, x_2777, ((V)(0D)), z_2779, ((V)(6D)), ((V)((Y0_2748 + 0.2))), ((V)(6D)), CI2_2745, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
Invoke(o_2768, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(Y0_2748)), ((V)(0D)), ((V)((W_2746 - 6D))), ((V)(2D)), ((V)((DZ_2747 - 6D))), CI_2744, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(Y0_2748)), ((V)(((DZ_2747 / 2D) - 1.5))), ((V)(W_2746)), ((V)(H_2749)), ((V)(3D)), CI_2744, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(Y0_2748)), ((V)((((-DZ_2747) / 2D) + 1.5))), ((V)(W_2746)), ((V)(H_2749)), ((V)(3D)), CI_2744, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)((((-W_2746) / 2D) + 1.5))), ((V)(Y0_2748)), ((V)(0D)), ((V)(3D)), ((V)(H_2749)), ((V)((DZ_2747 - 6D))), CI_2744, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)(((W_2746 / 2D) - 1.5))), ((V)(Y0_2748)), ((V)(0D)), ((V)(3D)), ((V)(H_2749)), ((V)((DZ_2747 - 6D))), CI_2744, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2788, int _argc2781, V s_2787, V _a2784, V _a2785, V _a2786, V[] _rest2782) => {
Invoke(o_2768, "push", Call(box_12, V.Undef, ((V)((ToNum(s_2787) * ((W_2746 / 2D) + 2.6)))), ((V)(10.6)), ((V)((-6D))), ((V)(5.4)), ((V)(1.8)), ((V)(1.6)), CI2_2745, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(box_12, V.Undef, ((V)((ToNum(s_2787) * ((W_2746 / 2D) + 2.6)))), ((V)(10.6)), ((V)(6D)), ((V)(5.4)), ((V)(1.8)), ((V)(1.6)), CI2_2745, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.4))).V)), Call(solid_11, V.Undef, NewObj(9).Put("ax", ((V)("z"))).Put("sh", ((V)("el"))).Put("c", Arr(((V)((ToNum(s_2787) * ((W_2746 / 2D) + 5.4)))), ((V)(11.5)))).Put("a", ((V)(2.2))).Put("b", ((V)(2.2))).Put("n", ((V)(14D))).Put("rings", Arr(Arr(((V)((-8.5))), ((V)(0D))), Arr(((V)(8.5)), ((V)(0D))))).Put("col", ((V)("#8a5a34"))).Put("mat", ((V)("wood"))).V));
Invoke(Arr(((V)((-11D))), ((V)(11D))), "forEach", Fn((V _arrowThis2796, int _argc2789, V z_2795, V _a2792, V _a2793, V _a2794, V[] _rest2790) => {
return Invoke(o_2768, "push", Call(box_12, V.Undef, ((V)((ToNum(s_2787) * ((W_2746 / 2D) - 1.6)))), ((V)(TOP_2750)), z_2795, ((V)(2.6)), ((V)(5.4)), ((V)(2.6)), CI2_2745, Call(pt_32, V.Undef, NewObj(1).Put("r", ((V)(0.5))).V)));
}, 1, "", true));
return default;
}, 1, "", true));
return o_2768;
return default;
}, 1, "", true));
Set(D_2752, "fx", Fn((V _arrowThis2804, int _argc2797, V c_2803, V _a2800, V _a2801, V _a2802, V[] _rest2798) => {
V p_2805 = default;
V k_2806 = default;
JsStrBuf f_2807 = null;
JsStrBuf un_2808 = null;
JsStrBuf defs_2809 = null;
JsStrBuf fr_2810 = null;
JsStrBuf cb_2811 = null;
V RR_2812 = default;
p_2805 = Get(c_2803, "p");
k_2806 = Get(c_2803, "k");
f_2807 = new JsStrBuf("");
un_2808 = new JsStrBuf("");
defs_2809 = new JsStrBuf(JsStrBuf.Begin().V(FDEF_72).S(string.Concat("<clipPath id=\"h7rim\"><path d=\"", ToStr(Call(sp_55, V.Undef, p_2805, Call(rrPts_52, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(((W_2746 / 2D) - 3D))), ((V)(((DZ_2747 / 2D) - 3D))), ((V)(0.6))), ((V)(TOP_2750)))), "\"/></clipPath>")).V(Call(G_46, V.Undef, ((V)("h7rust")), Arr(Arr(((V)(0D)), ((V)("#a8562a")), ((V)(0.55))), Arr(((V)(1D)), ((V)("#a8562a")), ((V)(0D)))), ((V)("cx=\"50%\" cy=\"50%\" r=\"50%\"")))).End());
fr_2810 = new JsStrBuf(JsStrBuf.Begin().S(string.Concat("<rect x=\"0\" y=\"0\" width=\"", NumStr(W_2746), "\" height=\"", NumStr(H_2749), "\" fill=\"none\"/>")).V(Invoke(Invoke(Arr(((V)(3.2)), ((V)(9.8))), "map", Fn((V _arrowThis2820, int _argc2813, V y_2819, V _a2816, V _a2817, V _a2818, V[] _rest2814) => {
return ((V)(string.Concat("<rect x=\"1\" y=\"", ToStr(y_2819), "\" width=\"", NumStr((W_2746 - 2D)), "\" height=\"0.8\" fill=\"#4a4540\"/><rect x=\"1\" y=\"", ToStr(Add(y_2819, ((V)(0.8)))), "\" width=\"", NumStr((W_2746 - 2D)), "\" height=\"0.4\" fill=\"#1a1816\"/>")));
}, 1, "", true)), "join", ((V)("")))).End());
Invoke(Arr(((V)(14D)), ((V)(40D))), "forEach", Fn((V _arrowThis2828, int _argc2821, V x_2827, V _a2824, V _a2825, V _a2826, V[] _rest2822) => {
fr_2810.S(string.Concat("<rect x=\"", ToStr(x_2827), "\" y=\"4.4\" width=\"12\" height=\"5\" rx=\"0.6\" fill=\"#1a1816\"/>", ToStr(Invoke(Call(rep_18, V.Undef, ((V)(4D)), Fn((V _arrowThis2836, int _argc2829, V i_2835, V _a2832, V _a2833, V _a2834, V[] _rest2830) => {
return ((V)(string.Concat("<rect x=\"", ToStr(Add(Add(x_2827, ((V)(1.2))), ((V)((ToNum(i_2835) * 2.7))))), "\" y=\"5.2\" width=\"1.6\" height=\"3.4\" rx=\"0.3\" fill=\"", (Truthy(lit_2743) ? "#ff6a1a" : "#0a0908"), "\">", ToStr((Truthy(lit_2743) ? Call(an_26, V.Undef, ((V)("opacity")), ((V)("0.5;1;0.6")), ((V)(1.2)), ((V)(((-ToNum(i_2835)) * 0.2)))) : ((V)("")))), "</rect>")));
}, 1, "", true)), "join", ((V)("")))), "<rect x=\"", NumStr(((ToNum(x_2827) - 0.6) + (Truthy(lit_2743) ? 5D : 0D))), "\" y=\"3.8\" width=\"7.4\" height=\"6.2\" rx=\"0.6\" fill=\"#3a3632\" stroke=\"#55504a\" stroke-width=\"0.3\">", (Truthy(lit_2743) ? string.Concat("<animate attributeName=\"x\" values=\"", NumStr((ToNum(x_2827) - 0.6)), ";", ToStr(Add(x_2827, ((V)(4.4)))), "\" dur=\"0.5s\" fill=\"freeze\"/>") : ""), "</rect><circle cx=\"", ToStr(Add(Add(x_2827, ((V)(3.1))), ((V)((Truthy(lit_2743) ? 5D : 0D))))), "\" cy=\"7\" r=\"0.7\" fill=\"#6a645c\"/>"));
return default;
}, 1, "", true));
fr_2810.V(Invoke(Invoke(Arr(Arr(((V)(8D)), ((V)(6D)), ((V)(7D))), Arr(((V)(32D)), ((V)(9D)), ((V)(5D))), Arr(((V)(55D)), ((V)(4D)), ((V)(6D)))), "map", Fn((V _arrowThis2850, int _argc2837, V _a2839, V _a2840, V _a2841, V _a2842, V[] _rest2838) => {
V x_2845 = default;
V y_2847 = default;
V r_2849 = default;
{ V _t2843 = ListOf(_a2839);
{ V _t2844 = GetIdx(_t2843, 0D);
x_2845 = _t2844; }
{ V _t2846 = GetIdx(_t2843, 1D);
y_2847 = _t2846; }
{ V _t2848 = GetIdx(_t2843, 2D);
r_2849 = _t2848; }
}
return ((V)(string.Concat("<ellipse cx=\"", ToStr(x_2845), "\" cy=\"", ToStr(y_2847), "\" rx=\"", ToStr(r_2849), "\" ry=\"", NumStr((ToNum(r_2849) * 0.6)), "\" fill=\"url(#h7rust)\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<text x=\"", NumStr((W_2746 / 2D)), "\" y=\"11.6\" text-anchor=\"middle\" font-family=\"Georgia, serif\" font-weight=\"700\" font-size=\"1.7\" fill=\"#5a544c\" letter-spacing=\"0.4\">SQUISH IRONWORKS</text>"));
f_2807.S(string.Concat("<g transform=\"", ToStr(Call(plane_23, V.Undef, p_2805, ((V)(((DZ_2747 / 2D) + 0.05))), ((V)(TOP_2750)), ((V)(((-W_2746) / 2D))))), "\">", fr_2810.Str, "</g><g transform=\"", ToStr(Call(planeX_24, V.Undef, p_2805, ((V)(((W_2746 / 2D) + 0.05))), ((V)(TOP_2750)), ((V)((DZ_2747 / 2D))))), "\"><g transform=\"scale(-1 1)\">", ToStr(Invoke(Invoke(Arr(((V)(3.2)), ((V)(9.8))), "map", Fn((V _arrowThis2858, int _argc2851, V y_2857, V _a2854, V _a2855, V _a2856, V[] _rest2852) => {
return ((V)(string.Concat("<rect x=\"1\" y=\"", ToStr(y_2857), "\" width=\"", NumStr((DZ_2747 - 2D)), "\" height=\"0.8\" fill=\"#4a4540\"/>")));
}, 1, "", true)), "join", ((V)("")))), "<ellipse cx=\"12\" cy=\"7\" rx=\"6\" ry=\"3.4\" fill=\"url(#h7rust)\"/></g></g>"));
cb_2811 = new JsStrBuf(string.Concat("<rect x=\"", NumStr((((-W_2746) / 2D) + 3D)), "\" y=\"", NumStr((((-DZ_2747) / 2D) + 3D)), "\" width=\"", NumStr((W_2746 - 6D)), "\" height=\"", NumStr((DZ_2747 - 6D)), "\" fill=\"#151312\"/>"));
RR_2812 = Call(rng_19, V.Undef, ((V)("hib")));
Call(rep_18, V.Undef, ((V)(5D)), Fn((V _arrowThis2866, int _argc2859, V j_2865, V _a2862, V _a2863, V _a2864, V[] _rest2860) => {
return Call(rep_18, V.Undef, ((V)(11D)), Fn((V _arrowThis2874, int _argc2867, V i_2873, V _a2870, V _a2871, V _a2872, V[] _rest2868) => {
double x_2875 = 0;
double z_2876 = 0;
V a_2877 = default;
double tI_2878 = 0;
x_2875 = ((((-27D) + (ToNum(i_2873) * 5.4)) + ((ToNum(j_2865) % 2D) * 2.4)) + (ToNum(Call(RR_2812, V.Undef)) - 0.5));
z_2876 = (((-11D) + (ToNum(j_2865) * 5.4)) + (ToNum(Call(RR_2812, V.Undef)) - 0.5));
a_2877 = Call(f1_17, V.Undef, ((V)(((ToNum(Call(RR_2812, V.Undef)) * 40D) - 20D))));
tI_2878 = (0.3 + ((Hypot((x_2875 + 28D), (z_2876 - 12D)) / 64D) * 3.2));
cb_2811.S(string.Concat("<g transform=\"translate(", ToStr(Call(f1_17, V.Undef, ((V)(x_2875)))), " ", ToStr(Call(f1_17, V.Undef, ((V)(z_2876)))), ") rotate(", ToStr(a_2877), ")\"><rect x=\"-2.4\" y=\"-2.2\" width=\"4.8\" height=\"4.4\" rx=\"1.8\" fill=\"#262422\"/><rect x=\"-1.8\" y=\"-1.9\" width=\"2.6\" height=\"1.4\" rx=\"0.7\" fill=\"#4a4744\"/>")).S((Truthy(lit_2743) ? string.Concat("<rect x=\"-2.4\" y=\"-2.2\" width=\"4.8\" height=\"4.4\" rx=\"1.8\" fill=\"#d6d0c6\" opacity=\"0\">", ToStr(Call(once_43, V.Undef, ((V)("opacity")), ((V)("0;0.85")), ((V)("0;1")), ((V)(1.6)), ((V)((tI_2878 + 0.6))))), "</rect><rect x=\"-1.6\" y=\"-1.4\" width=\"3.2\" height=\"2.8\" rx=\"1.2\" fill=\"#ff5a1a\" opacity=\"0\">", ToStr(Call(once_43, V.Undef, ((V)("opacity")), ((V)("0;1")), ((V)("0;1")), ((V)(0.6)), ((V)(tI_2878)))), "<animate attributeName=\"opacity\" values=\"1;0.55;1\" dur=\"", ToStr(Call(n4_20, V.Undef, ((V)((0.9 + (ToNum(Call(RR_2812, V.Undef)) * 0.8)))))), "s\" begin=\"", ToStr(Call(n4_20, V.Undef, ((V)((tI_2878 + 0.6))))), "s\" repeatCount=\"indefinite\"/></rect>") : "")).S("</g>");
return default;
}, 1, "", true));
}, 1, "", true));
f_2807.S(string.Concat("<g clip-path=\"url(#h7rim)\"><g transform=\"", ToStr(Call(planeH_25, V.Undef, p_2805, ((V)((Y0_2748 + 3.4))))), "\">", cb_2811.Str, "</g></g>"));
if (Truthy(lit_2743)) {
f_2807.S(string.Concat("<g clip-path=\"url(#h7up)\">", "")).V(Invoke(Invoke(Arr(Arr(((V)((-20D))), ((V)((-4D))), ((V)(0.4))), Arr(((V)((-6D))), ((V)(6D)), ((V)(1.4))), Arr(((V)(10D)), ((V)((-6D))), ((V)(2.4))), Arr(((V)(22D)), ((V)(4D)), ((V)(3D)))), "map", Fn((V _arrowThis2893, int _argc2879, V _a2881, V i_2885, V _a2883, V _a2884, V[] _rest2880) => {
V x_2888 = default;
V z_2890 = default;
V b_2892 = default;
{ V _t2886 = ListOf(_a2881);
{ V _t2887 = GetIdx(_t2886, 0D);
x_2888 = _t2887; }
{ V _t2889 = GetIdx(_t2886, 1D);
z_2890 = _t2889; }
{ V _t2891 = GetIdx(_t2886, 2D);
b_2892 = _t2891; }
}
return ((V)(string.Concat("<g opacity=\"0\">", ToStr(Call(once_43, V.Undef, ((V)("opacity")), ((V)("0;1")), ((V)("0;1")), ((V)(0.5)), b_2892)), ToStr(Call(flames_76, V.Undef, Call(p_2805, V.Undef, x_2888, ((V)((Y0_2748 + 4D))), z_2890), ((V)((ToNum(k_2806) * 0.45))), NewObj(6).Put("seed", ((V)(JsStrBuf.Begin().S("hf").V(i_2885).End()))).Put("n", ((V)(3D))).Put("sp", ((V)(4D))).Put("h", ((V)(10D))).Put("w", ((V)(3D))).Put("emb", ((V)(2D))).V)), "</g>")));
}, 2, "", true)), "join", ((V)("")))).S("</g>");
defs_2809.S(string.Concat("<clipPath id=\"h7up\"><path d=\"M", ToStr(Call(P2_21, V.Undef, Call(p_2805, V.Undef, ((V)(((-W_2746) / 2D))), ((V)(TOP_2750)), ((V)((DZ_2747 / 2D)))))), "L", ToStr(Call(P2_21, V.Undef, Call(p_2805, V.Undef, ((V)((W_2746 / 2D))), ((V)(TOP_2750)), ((V)((DZ_2747 / 2D)))))), "L", ToStr(Call(P2_21, V.Undef, Call(p_2805, V.Undef, ((V)((W_2746 / 2D))), ((V)(TOP_2750)), ((V)(((-DZ_2747) / 2D)))))), "L", ToStr(Call(f1_17, V.Undef, GetIdx(Call(p_2805, V.Undef, ((V)((W_2746 / 2D))), ((V)(TOP_2750)), ((V)(((-DZ_2747) / 2D)))), 0D))), " -999L", ToStr(Call(f1_17, V.Undef, GetIdx(Call(p_2805, V.Undef, ((V)(((-W_2746) / 2D))), ((V)(TOP_2750)), ((V)((DZ_2747 / 2D)))), 0D))), " -999Z\"/></clipPath>"));
}
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis2901, int _argc2894, V s_2900, V _a2897, V _a2898, V _a2899, V[] _rest2895) => {
JsStrBuf g_2902 = null;
g_2902 = new JsStrBuf(string.Concat("<rect x=\"-14.5\" y=\"-12.5\" width=\"29\" height=\"25\" rx=\"1\" fill=\"none\" stroke=\"#1a1816\" stroke-width=\"2\"/><rect x=\"-14.5\" y=\"-12.5\" width=\"29\" height=\"25\" rx=\"1\" fill=\"none\" stroke=\"#4a4540\" stroke-width=\"0.8\"/>", ""));
Call(rep_18, V.Undef, ((V)(7D)), Fn((V _arrowThis2910, int _argc2903, V i_2909, V _a2906, V _a2907, V _a2908, V[] _rest2904) => {
return ((V)(g_2902.S(string.Concat("<path d=\"M", NumStr(((-11D) + (ToNum(i_2909) * 3.7))), " -12V12\" stroke=\"#1a1816\" stroke-width=\"1.5\"/><path d=\"M", NumStr(((-11.3) + (ToNum(i_2909) * 3.7))), " -12V12\" stroke=\"#55504a\" stroke-width=\"0.5\"/>")).Str));
}, 1, "", true));
f_2807.S(string.Concat("<g transform=\"", ToStr(Call(planeH_25, V.Undef, p_2805, ((V)(GY_2751)), ((V)((ToNum(s_2900) * 15D))), ((V)(0D)))), "\">", g_2902.Str, "</g>"));
return default;
}, 1, "", true));
if (Truthy(lit_2743)) {
V sk_2911 = default;
V RS_2912 = default;
sk_2911 = Fn((V _arrowThis2921, int _argc2913, V x_2919, V z_2920, V _a2917, V _a2918, V[] _rest2914) => {
return ((V)(string.Concat("<g transform=\"", ToStr(Call(planeH_25, V.Undef, p_2805, ((V)((GY_2751 + 1.2))), x_2919, z_2920)), "\"><path d=\"M-17 0H17\" stroke=\"#d8c08a\" stroke-width=\"0.9\" stroke-linecap=\"round\"/>", ToStr(Invoke(Invoke(Arr(((V)((-10D))), ((V)((-4D))), ((V)(2D)), ((V)(8D))), "map", Fn((V _arrowThis2930, int _argc2922, V d_2928, V i_2929, V _a2926, V _a2927, V[] _rest2923) => {
return ((V)(string.Concat(string.Concat("<rect x=\"", NumStr((ToNum(d_2928) - 2.2)), "\" y=\"-2.4\" width=\"4.4\" height=\"4.8\" rx=\"1.6\" fill=\"", (NumTruthy((ToNum(i_2929) % 2D)) ? "#c9d88a" : "#b7743a"), "\"/>"), (NumTruthy((ToNum(i_2929) % 2D)) ? "" : string.Concat("<path d=\"M", NumStr((ToNum(d_2928) - 1.6)), " -1.2H", ToStr(Add(d_2928, ((V)(1.6)))), "M", NumStr((ToNum(d_2928) - 1.6)), " 1H", ToStr(Add(d_2928, ((V)(1.6)))), "\" stroke=\"#4a2410\" stroke-width=\"0.6\"/>")))));
}, 2, "", true)), "join", ((V)("")))), "</g>")));
}, 2, "", true);
f_2807.S(string.Concat("<g opacity=\"0\">", ToStr(Call(once_43, V.Undef, ((V)("opacity")), ((V)("0;1")), ((V)("0;1")), ((V)(0.5)), ((V)(1.6)))), ToStr(Add(Call(sk_2911, V.Undef, ((V)((-14D))), ((V)((-2D)))), Call(sk_2911, V.Undef, ((V)(14D)), ((V)(4D))))), "</g>")).V(Call(smoke_77, V.Undef, Call(p_2805, V.Undef, ((V)(0D)), ((V)((GY_2751 + 2D))), ((V)(0D))), k_2806, NewObj(9).Put("seed", ((V)("hbs"))).Put("n", ((V)(5D))).Put("H", ((V)(50D))).Put("col", ((V)("#c8c2ba"))).Put("op", ((V)(0.32))).Put("d", ((V)(4.4))).Put("r1", ((V)(10D))).Put("drift", ((V)(14D))).Put("b", ((V)(0D))).V));
RS_2912 = Call(rng_19, V.Undef, ((V)("hsp")));
Call(rep_18, V.Undef, ((V)(6D)), Fn((V _arrowThis2938, int _argc2931, V i_2937, V _a2934, V _a2935, V _a2936, V[] _rest2932) => {
V q_2939 = default;
double d_2940 = 0;
V b_2941 = default;
q_2939 = Call(p_2805, V.Undef, ((V)(((ToNum(Call(RS_2912, V.Undef)) - 0.5) * 50D))), ((V)(GY_2751)), ((V)(((ToNum(Call(RS_2912, V.Undef)) - 0.5) * 20D))));
d_2940 = (0.7 + (ToNum(Call(RS_2912, V.Undef)) * 0.6));
b_2941 = Call(n4_20, V.Undef, ((V)((1D + (ToNum(Call(RS_2912, V.Undef)) * 3D)))));
f_2807.S(string.Concat("<circle cx=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q_2939, 0D))), "\" cy=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q_2939, 1D))), "\" r=\"", ToStr(Call(f1_17, V.Undef, ((V)((0.4 * ToNum(k_2806)))))), "\" fill=\"#ffd66b\" opacity=\"0\"><animate attributeName=\"cy\" values=\"", ToStr(Call(f1_17, V.Undef, GetIdx(q_2939, 1D))), ";", ToStr(Call(f1_17, V.Undef, ((V)((ToNum(GetIdx(q_2939, 1D)) - (10D * ToNum(k_2806))))))), "\" dur=\"", ToStr(Call(n4_20, V.Undef, ((V)(d_2940)))), "s\" begin=\"", ToStr(b_2941), "s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0;1;0\" dur=\"", ToStr(Call(n4_20, V.Undef, ((V)(d_2940)))), "s\" begin=\"", ToStr(b_2941), "s\" repeatCount=\"indefinite\"/></circle>"));
return default;
}, 1, "", true));
un_2808.V(Call(glowE_78, V.Undef, p_2805, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(44D)), ((V)(26D)), ((V)("#ff8a3a")), ((V)(0.35)), ((V)(1D))));
}
return NewObj(4).Put("defs", ((V)(defs_2809.Str))).Put("under", ((V)(un_2808.Str))).Put("front", ((V)(f_2807.Str))).Put("bb", Call(bbOf_28, V.Undef, Arr(Call(p_2805, V.Undef, ((V)((((-W_2746) / 2D) - 9D))), ((V)(0D)), ((V)(((-DZ_2747) / 2D)))), Call(p_2805, V.Undef, ((V)(((W_2746 / 2D) + 9D))), ((V)(0D)), ((V)((DZ_2747 / 2D)))), Call(p_2805, V.Undef, ((V)((((-W_2746) / 2D) - 9D))), ((V)(0D)), ((V)((DZ_2747 / 2D)))), Call(p_2805, V.Undef, ((V)(((W_2746 / 2D) + 9D))), ((V)(0D)), ((V)(((-DZ_2747) / 2D)))), Call(p_2805, V.Undef, ((V)(0D)), ((V)((Truthy(lit_2743) ? 76D : (GY_2751 + 4D)))), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_2752;
return default;
}, 1, "", true));
Set(RD_8, "SET7", NewObj(11).Put("YRD-015", NewObj(3).Put("spec", ((V)("kiddie"))).Put("live", ((V)("Rippling water"))).Put("note", ((V)("A clean three-ring inflatable kiddie pool: fat glossy blue and white tubes printed with little fish and starfish. The water is alive with moving sunlight caustics, ripples and sparkles, a rubber duck drifts round and a beach ball bobs. Seats 2 splashing creatures."))).V).Put("YRD-035", NewObj(3).Put("spec", ((V)("plunge"))).Put("live", ((V)("Rippling water"))).Put("note", ((V)("A round above-ground plunge pool built from vertical cedar staves held by two steel hoops, with a wide cedar cap, cedar steps and stainless handrails. Deep teal water with drifting caustics, ripples, a floating thermometer and a couple of leaves. Seats 3."))).V).Put("YRD-055", NewObj(3).Put("spec", ((V)("koiPond"))).Put("live", ((V)("Koi swimming"))).Put("note", ((V)("A natural pond ringed with mossy boulders. Water spills off a stone ledge in a flowing waterfall with foam and mist, five koi (kohaku, showa, ogon, yamabuki) swim lazy loops under the surface, lily pads sway, two pink lotus flowers bloom and cattails nod."))).V).Put("YRD-075", NewObj(3).Put("spec", ((V)("lapPool"))).Put("live", ((V)("Heated \u00b7 steaming"))).Put("note", ((V)("A long travertine-edged lap pool with a blue mosaic waterline, lane stripes on the floor and a red-white-blue lane rope that bobs on the surface. The sunken sun shelf at the end holds an in-water chaise. Warm water steams gently. Seats 4."))).V).Put("YRD-095", NewObj(3).Put("spec", ((V)("lagoon"))).Put("live", ((V)("Waterfalls + infinity edge"))).Put("note", ((V)("A dark-stone lagoon with a glass front wall, so you see the water in cross-section with light rays and rising bubbles. A grotto waterfall pours over a hidden cave, the right side spills over an infinity edge into a catch trough, and the swim-up bar has stools in the water and tropical drinks. Seats 5."))).V).Put("YRD-106", NewObj(3).Put("spec", ((V)("marbleFount"))).Put("live", ((V)("Flowing fountain"))).Put("note", ((V)("Three Carrara marble tiers with gold rims. A crown jet sprays from the gold finial, water spills over every bowl rim in shining curtains, four gold swans spout into the basin, and each pool ripples with sunlight caustics."))).V).Put("YRD-098", NewObj(3).Put("spec", ((V)("obelisk"))).Put("live", ((V)("Fire on water"))).Put("note", ((V)("A razor-sharp obsidian obelisk that hovers above a black reflecting basin. Living fire tongues rise straight out of the rippling water around its base, the polished faces glow with firelight and the water mirrors the flames."))).V).Put("YRD-058", NewObj(3).Put("spec", ((V)("chiminea"))).Put("live", ((V)("Live fire"))).Put("note", ((V)("A pot-bellied terracotta chiminea with a hand-painted Talavera band on a wrought-iron stand. The logs and flames burn inside the clay chamber behind the arched mouth (you can see the wall thickness at the lip), smoke and sparks rise from the chimney and the mouth throws a warm glow on the ground."))).V).Put("YRD-038", NewObj(4).Put("spec", ((V)("bowlPit"))).Put("play", ((V)("fire"))).Put("live", ((V)("Tap to light"))).Put("note", ((V)("A deep steel bowl fire pit with a wide lip, four bent tube legs and a poker. The bowl is soot-darkened inside with a bed of ash and three split logs. Tap to light it: flames roar up out of the logs, coals and log cracks glow, embers drift up and smoke rises."))).V).Put("YRD-022", NewObj(4).Put("spec", ((V)("kettle"))).Put("play", ((V)("grill"))).Put("live", ((V)("Tap to grill"))).Put("note", ((V)("The classic red enamel kettle grill: glossy dome lid with a chrome vent and thermometer, black handle, ash catcher, triangle rack and two wheels. Tap to grill: the lid comes off and hangs on the side, the charcoal glows, burgers with melting cheese, sausages and corn sizzle and smoke billows up."))).V).Put("YRD-002", NewObj(4).Put("spec", ((V)("hibachi"))).Put("play", ((V)("coals"))).Put("live", ((V)("Tap to light"))).Put("note", ((V)("A heavy cast-iron hibachi with casting ribs, rust patina, sliding draft doors, wooden end handles and twin grates on notched posts. Tap to light: the draft doors slide open, the briquettes catch one by one (orange cores, grey ash coat), small flames lick up and two yakitori skewers start to sizzle."))).V).V);
edit6_82 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis2949, int _argc2942, V rows_2948, V _a2945, V _a2946, V _a2947, V[] _rest2943) => {
return Invoke(Call(edit6_82, V.Undef, rows_2948), "map", Fn((V _arrowThis2957, int _argc2950, V r_2956, V _a2953, V _a2954, V _a2955, V[] _rest2951) => {
return (Truthy(GetK(Get(RD_8, "SET7"), Get(r_2956, "id"))) ? Object_assign(NewObj(0).V, r_2956, GetK(Get(RD_8, "SET7"), Get(r_2956, "id"))) : r_2956);
}, 1, "", true));
}, 1, "", true));
Set(RD_8, "H7", NewObj(37).Put("isPlay", isPlay_38).Put("B", B_39).Put("anV", anV_41).Put("atV", atV_42).Put("once", once_43).Put("onceT", onceT_44).Put("st", st_45).Put("G", G_46).Put("L", L_47).Put("lerp", lerp_48).Put("lerpA", lerpA_50).Put("ellPts", ellPts_51).Put("rrPts", rrPts_52).Put("shPts", shPts_53).Put("lp", lp_54).Put("sp", sp_55).Put("quad", quad_56).Put("planeT", planeT_57).Put("facing", facing_58).Put("aboveFront", aboveFront_59).Put("tube", tube_60).Put("curve", curve_61).Put("water", water_68).Put("WP", WP_63).Put("WDEF", WDEF_69).Put("fall", fall_70).Put("stream", stream_71).Put("FDEF", FDEF_72).Put("flames", flames_76).Put("tongue", tongue_74).Put("embers", embers_75).Put("smoke", smoke_77).Put("glowE", glowE_78).Put("DUCK", DUCK_79).Put("BBALL", BBALL_80).Put("BBDEF", BBDEF_81).Put("ripple", ripple_66).V);
Set(RD_8, "PLUS7", ((V)(1D)));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
