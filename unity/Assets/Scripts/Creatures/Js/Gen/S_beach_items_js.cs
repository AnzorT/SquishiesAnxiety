// beach-items.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_beach_items_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("viewBox=\"([^\"]+)\"", "");
        static readonly System.Text.RegularExpressions.Regex RX1 = JsRegExp.Compile("[.@*+]", "");
        public static void Run()
        {
Call(Named(boot_254 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V RD_8 = default;
V X_9 = default;
V BE_10 = default;
V K_11 = default;
V box_12 = default;
V cush_13 = default;
V cyl_14 = default;
V ball_15 = default;
V slab_16 = default;
V arcW_17 = default;
V prismZ_18 = default;
V shade_19 = default;
V mix_20 = default;
V f1_21 = default;
V rep_22 = default;
V rng_23 = default;
V n4_24 = default;
V P2_25 = default;
V planeH_26 = default;
V bbOf_27 = default;
V mt_28 = default;
V wd_29 = default;
V cer_30 = default;
V pt_31 = default;
V atV_32 = default;
V tube_33 = default;
V curve_34 = default;
V water_35 = default;
V WP_36 = default;
V flames_37 = default;
V FDEF_38 = default;
V glowE_39 = default;
V isPlay_40 = default;
V ellPts_41 = default;
V N_42 = default;
double PI_43 = 0;
V GOLD_44 = default;
V WH_45 = default;
V em_46 = default;
V fb_47 = default;
V T_48 = default;
V SAND_49 = default;
V SANDD_50 = default;
V PP_51 = default;
V PQ_52 = default;
V AT_53 = default;
V AN_54 = default;
V sway_55 = default;
V ink_56 = default;
V cone_57 = default;
V palm_58 = default;
V crab_59 = default;
V star5_60 = default;
V ripples_61 = default;
V HUE_62 = default;
V GLW_63 = default;
V glowAt_64 = default;
V UMB_65 = default;
V BOARD_66 = default;
V TN_67 = default;
V RAR_68 = default;
V BASE_69 = default;
V TAG_70 = default;
V SLOTS_71 = default;
V ROWS_72 = default;
V LVOF_73 = default;
V edit0_74 = default;
V BPL_75 = default;
V SM_76 = default;
V d0_77 = default;
if (_self1.IsNullish) _self1 = GlobalV;
cone_57 = Fn((V _self78, int _argc79, V p_85, V k_86, V o_87, V _a84, V[] _rest80) => {
V n_88 = default;
V cx_89 = default;
V cz_90 = default;
V A_91 = default;
V R_92 = default;
V dr_93 = default;
JsStrBuf s_94 = null;
JsStrBuf fr_95 = null;
V rim_96 = default;
V W_97 = default;
if (_self78.IsNullish) _self78 = GlobalV;
n_88 = (Get(o_87, "n") is var _t98 && Truthy(_t98) ? _t98 : ((V)(12D)));
cx_89 = (Get(o_87, "x") is var _t99 && Truthy(_t99) ? _t99 : ((V)(0D)));
cz_90 = (Get(o_87, "z") is var _t100 && Truthy(_t100) ? _t100 : ((V)(0D)));
A_91 = Arr(cx_89, Add(Get(o_87, "y"), Get(o_87, "h")), cz_90);
R_92 = Get(o_87, "R");
dr_93 = (Get(o_87, "droop").IsNullish ? ((V)(3D)) : Get(o_87, "droop"));
s_94 = new JsStrBuf("");
fr_95 = new JsStrBuf("");
rim_96 = Fn((V _arrowThis108, int _argc101, V i_107, V _a104, V _a105, V _a106, V[] _rest102) => {
V t_109 = default;
t_109 = Add(((V)((((ToNum(i_107) / ToNum(n_88)) * 2D) * PI_43))), (Get(o_87, "a0") is var _t110 && Truthy(_t110) ? _t110 : ((V)(0D))));
return Arr(Add(cx_89, ((V)((ToNum(R_92) * FdLibm.Cos(ToNum(t_109)))))), ((V)((ToNum(Get(o_87, "y")) - ToNum(dr_93)))), Add(cz_90, ((V)((ToNum(R_92) * FdLibm.Sin(ToNum(t_109)))))));
return default;
}, 1, "", true);
W_97 = Invoke(Call(rep_22, V.Undef, n_88, Fn((V _arrowThis127, int _argc120, V i_126, V _a123, V _a124, V _a125, V[] _rest121) => {
V a_128 = default;
V b_129 = default;
V m_130 = default;
a_128 = Call(rim_96, V.Undef, i_126);
b_129 = Call(rim_96, V.Undef, Add(i_126, ((V)(1D))));
m_130 = Arr(((V)((ToNum(Add(GetIdx(a_128, 0D), GetIdx(b_129, 0D))) / 2D))), GetIdx(a_128, 1D), ((V)((ToNum(Add(GetIdx(a_128, 2D), GetIdx(b_129, 2D))) / 2D))));
return NewObj(5).Put("i", i_126).Put("a", a_128).Put("b", b_129).Put("m", m_130).Put("dz", GetIdx(CallSpread(p_85, V.Undef, new ArrBuilder().Spread(m_130).V), 1D)).V;
return default;
}, 1, "", true)), "sort", Fn((V _arrowThis119, int _argc111, V u_117, V v_118, V _a115, V _a116, V[] _rest112) => {
return ((V)((ToNum(Get(u_117, "dz")) - ToNum(Get(v_118, "dz")))));
}, 2, "", true));
Invoke(W_97, "forEach", Fn((V _arrowThis138, int _argc131, V w_137, V _a134, V _a135, V _a136, V[] _rest132) => {
V c_139 = default;
V th_140 = default;
double li_141 = 0;
V col_142 = default;
V mid_143 = default;
c_139 = GetIdx(Get(o_87, "cols"), (ToNum(Get(w_137, "i")) % ToNum(Get(Get(o_87, "cols"), "length"))));
th_140 = Add(((V)((((ToNum(Add(Get(w_137, "i"), ((V)(0.5)))) / ToNum(n_88)) * 2D) * PI_43))), (Get(o_87, "a0") is var _t144 && Truthy(_t144) ? _t144 : ((V)(0D))));
li_141 = (0.5 + (0.5 * FdLibm.Cos((ToNum(th_140) - 2.4))));
col_142 = Call(mix_20, V.Undef, Call(shade_19, V.Undef, c_139, ((V)((0.8 + (li_141 * 0.32))))), ((V)("#ffffff")), ((V)((li_141 * 0.12))));
mid_143 = Arr(((V)(((ToNum(Add(GetIdx(Get(w_137, "a"), 0D), GetIdx(Get(w_137, "b"), 0D))) / 2D) + ((FdLibm.Cos(ToNum(th_140)) * ToNum(R_92)) * 0.08)))), ((V)((ToNum(GetIdx(Get(w_137, "a"), 1D)) - (Truthy(Get(o_87, "scallop")) ? 4D : 0D)))), ((V)(((ToNum(Add(GetIdx(Get(w_137, "a"), 2D), GetIdx(Get(w_137, "b"), 2D))) / 2D) + ((FdLibm.Sin(ToNum(th_140)) * ToNum(R_92)) * 0.08)))));
s_94.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, CallSpread(p_85, V.Undef, new ArrBuilder().Spread(A_91).V))), "L", ToStr(Call(P2_25, V.Undef, CallSpread(p_85, V.Undef, new ArrBuilder().Spread(Get(w_137, "a")).V))), (Truthy(Get(o_87, "scallop")) ? string.Concat("Q", ToStr(Call(P2_25, V.Undef, CallSpread(p_85, V.Undef, new ArrBuilder().Spread(mid_143).V))), " ", ToStr(Call(P2_25, V.Undef, CallSpread(p_85, V.Undef, new ArrBuilder().Spread(Get(w_137, "b")).V)))) : string.Concat("L", ToStr(Call(P2_25, V.Undef, CallSpread(p_85, V.Undef, new ArrBuilder().Spread(Get(w_137, "b")).V))))), "Z"))), col_142, Call(ink_56, V.Undef, c_139), ((V)(0.9))));
if (Truthy((Get(o_87, "fringe") is var _t145 && !Truthy(_t145) ? _t145 : (GtN(GetIdx(CallSpread(p_85, V.Undef, new ArrBuilder().Spread(Get(w_137, "m")).V), 1D), (ToNum(GetIdx(Call(p_85, V.Undef, cx_89, Get(o_87, "y"), cz_90), 1D)) - 2D)) ? V.True : V.False)))) {
Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis153, int _argc146, V j_152, V _a149, V _a150, V _a151, V[] _rest147) => {
double u_154 = 0;
V q_155 = default;
V q1_156 = default;
V q2_157 = default;
u_154 = (ToNum(Add(j_152, ((V)(0.5)))) / 3D);
q_155 = Arr(Add(GetIdx(Get(w_137, "a"), 0D), ((V)(((ToNum(GetIdx(Get(w_137, "b"), 0D)) - ToNum(GetIdx(Get(w_137, "a"), 0D))) * u_154)))), GetIdx(Get(w_137, "a"), 1D), Add(GetIdx(Get(w_137, "a"), 2D), ((V)(((ToNum(GetIdx(Get(w_137, "b"), 2D)) - ToNum(GetIdx(Get(w_137, "a"), 2D))) * u_154)))));
q1_156 = CallSpread(p_85, V.Undef, new ArrBuilder().Spread(q_155).V);
q2_157 = Call(p_85, V.Undef, GetIdx(q_155, 0D), ((V)((ToNum(GetIdx(q_155, 1D)) - ToNum((Get(o_87, "fl") is var _t158 && Truthy(_t158) ? _t158 : ((V)(7D))))))), GetIdx(q_155, 2D));
fr_95.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, q1_156)), "L", ToStr(Call(P2_25, V.Undef, q2_157))))), ((V)("none")), Get(o_87, "fringe"), ((V)(1.6))));
return default;
}, 1, "", true));
}
if (Truthy((Get(o_87, "tassel") is var _t159 && !Truthy(_t159) ? _t159 : (Gt(GetIdx(CallSpread(p_85, V.Undef, new ArrBuilder().Spread(Get(w_137, "m")).V), 1D), GetIdx(Call(p_85, V.Undef, cx_89, Get(o_87, "y"), cz_90), 1D)) ? V.True : V.False)))) {
V q_160 = default;
q_160 = CallSpread(p_85, V.Undef, new ArrBuilder().Spread(Get(w_137, "a")).V);
fr_95.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, q_160)), "l0 5"))), ((V)("none")), Get(o_87, "tassel"), ((V)(1D)))).S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_160, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, Add(GetIdx(q_160, 1D), ((V)(6D))))), "\" r=\"1.6\" fill=\"", ToStr(Get(o_87, "tassel")), "\"/>"));
}
return default;
}, 1, "", true));
return ((V)(string.Concat(s_94.Str, fr_95.Str)));
return default;
}, 3, "cone", false);
palm_58 = Fn((V _self161, int _argc162, V p_168, V k_169, V x_170, V z_171, V[] _rest163) => {
V R_176 = default;
V top_177 = default;
V @base_178 = default;
V mid_179 = default;
V pts_180 = default;
V sp_181 = default;
V tc_182 = default;
V s_183 = default;
V tq_184 = default;
JsStrBuf fr_185 = null;
V nf_186 = default;
V L0_187 = default;
JsStrBuf co_188 = null;
V H_172 = default;
V lean_173 = default;
V seed_174 = default;
V o_175 = default;
if (_self161.IsNullish) _self161 = GlobalV;
H_172 = (_argc162 > 4 ? _rest163[0] : V.Undef);
lean_173 = (_argc162 > 5 ? _rest163[1] : V.Undef);
seed_174 = (_argc162 > 6 ? _rest163[2] : V.Undef);
o_175 = (_argc162 > 7 ? _rest163[3] : V.Undef);
o_175 = (o_175 is var _t189 && Truthy(_t189) ? _t189 : NewObj(0).V);
R_176 = Call(rng_23, V.Undef, seed_174);
top_177 = Arr(Add(x_170, lean_173), H_172, Add(z_171, ((V)((ToNum(lean_173) * 0.3)))));
@base_178 = Arr(x_170, ((V)(0D)), z_171);
mid_179 = Arr(Add(x_170, ((V)((ToNum(lean_173) * 0.15)))), ((V)((ToNum(H_172) * 0.55))), z_171);
pts_180 = Call(curve_34, V.Undef, @base_178, mid_179, top_177, ((V)(8D)));
sp_181 = Invoke(pts_180, "map", Fn((V _arrowThis197, int _argc190, V q_196, V _a193, V _a194, V _a195, V[] _rest191) => {
return CallSpread(p_168, V.Undef, new ArrBuilder().Spread(q_196).V);
}, 1, "", true));
tc_182 = (Get(o_175, "trunk") is var _t198 && Truthy(_t198) ? _t198 : ((V)("#b07a44")));
s_183 = Call(tube_33, V.Undef, sp_181, (Get(o_175, "tw") is var _t199 && Truthy(_t199) ? _t199 : ((V)(4.2))), k_169, tc_182, Call(mix_20, V.Undef, tc_182, ((V)("#ffffff")), ((V)(0.35))), Call(ink_56, V.Undef, tc_182));
Invoke(Invoke(sp_181, "slice", ((V)(1D)), ((V)((-1D)))), "forEach", Fn((V _arrowThis208, int _argc200, V q_206, V i_207, V _a204, V _a205, V[] _rest201) => {
return (s_183 = Add(s_183, Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_206, 0D)) - (4D * ToNum(k_169))))))), " ", ToStr(Call(f1_21, V.Undef, GetIdx(q_206, 1D))), "h", ToStr(Call(f1_21, V.Undef, ((V)((8D * ToNum(k_169))))))))), ((V)("none")), Call(ink_56, V.Undef, tc_182), ((V)(0.8)), ((V)(" opacity=\"0.6\"")))));
}, 2, "", true));
tq_184 = CallSpread(p_168, V.Undef, new ArrBuilder().Spread(top_177).V);
fr_185 = new JsStrBuf("");
nf_186 = (Get(o_175, "nf") is var _t209 && Truthy(_t209) ? _t209 : ((V)(8D)));
L0_187 = (Get(o_175, "L") is var _t210 && Truthy(_t210) ? _t210 : ((V)(34D)));
Call(rep_22, V.Undef, nf_186, Fn((V _arrowThis218, int _argc211, V i_217, V _a214, V _a215, V _a216, V[] _rest212) => {
double a_219 = 0;
double L_220 = 0;
V ex_221 = default;
V ez_222 = default;
double ey_223 = 0;
V m1_224 = default;
V e2_225 = default;
V m2_226 = default;
V c_227 = default;
double w_228 = 0;
a_219 = ((((ToNum(i_217) / ToNum(nf_186)) * 2D) * PI_43) + (ToNum(Call(R_176, V.Undef)) * 0.3));
L_220 = (ToNum(L0_187) * (0.8 + (ToNum(Call(R_176, V.Undef)) * 0.35)));
ex_221 = Add(GetIdx(top_177, 0D), ((V)((FdLibm.Cos(a_219) * L_220))));
ez_222 = Add(GetIdx(top_177, 2D), ((V)(((FdLibm.Sin(a_219) * L_220) * 0.7))));
ey_223 = (ToNum(H_172) - (L_220 * 0.42));
m1_224 = Arr(Add(GetIdx(top_177, 0D), ((V)(((FdLibm.Cos(a_219) * L_220) * 0.5)))), Add(H_172, ((V)(6D))), Add(GetIdx(top_177, 2D), ((V)(((FdLibm.Sin(a_219) * L_220) * 0.35)))));
e2_225 = Call(p_168, V.Undef, ex_221, ((V)(ey_223)), ez_222);
m2_226 = CallSpread(p_168, V.Undef, new ArrBuilder().Spread(m1_224).V);
c_227 = (Truthy(Get(o_175, "leaf")) ? GetIdx(Get(o_175, "leaf"), (ToNum(i_217) % ToNum(Get(Get(o_175, "leaf"), "length")))) : ((V)((NumTruthy((ToNum(i_217) % 2D)) ? "#3f9a42" : "#52b04a"))));
w_228 = (6D * ToNum(k_169));
fr_185.V(Get(NewObj(2).Put("z", GetIdx(e2_225, 1D)).Put("s", Add(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, tq_184)), "Q", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(m2_226, 0D)) - (w_228 * FdLibm.Sin(a_219))))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(m2_226, 1D)) - w_228))))), " ", ToStr(Call(P2_25, V.Undef, e2_225)), "Q", ToStr(Call(f1_21, V.Undef, Add(GetIdx(m2_226, 0D), ((V)((w_228 * FdLibm.Sin(a_219))))))), " ", ToStr(Call(f1_21, V.Undef, Add(GetIdx(m2_226, 1D), ((V)((w_228 * 0.4)))))), " ", ToStr(Call(P2_25, V.Undef, tq_184)), "Z"))), c_227, Call(ink_56, V.Undef, c_227), ((V)(0.8))), Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, tq_184)), "Q", ToStr(Call(P2_25, V.Undef, m2_226)), " ", ToStr(Call(P2_25, V.Undef, e2_225))))), ((V)("none")), Call(mix_20, V.Undef, c_227, ((V)("#ffffff")), ((V)(0.3))), ((V)(0.6)), ((V)(" opacity=\"0.7\""))))).V, "s"));
return default;
}, 1, "", true));
co_188 = new JsStrBuf("");
if (!SEqN(Get(o_175, "nuts"), 0D)) {
Call(rep_22, V.Undef, (Get(o_175, "nuts") is var _t229 && Truthy(_t229) ? _t229 : ((V)(3D))), Fn((V _arrowThis237, int _argc230, V i_236, V _a233, V _a234, V _a235, V[] _rest231) => {
V q_238 = default;
q_238 = Call(p_168, V.Undef, Add(GetIdx(top_177, 0D), ((V)(((ToNum(i_236) - 1D) * 3D)))), ((V)((ToNum(H_172) - 4D))), Add(GetIdx(top_177, 2D), ((V)(3D))));
co_188.S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_238, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_238, 1D))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((3.2 * ToNum(k_169)))))), "\" fill=\"", ToStr((Get(o_175, "nutC") is var _t239 && Truthy(_t239) ? _t239 : ((V)("#7a4e24")))), "\" stroke=\"#3a2410\" stroke-width=\"0.6\"/>"));
return default;
}, 1, "", true));
}
s_183 = ((V)(JsStrBuf.Begin().V(s_183).S(string.Concat("<g>", ToStr(Call(sway_55, V.Undef, tq_184, (Get(o_175, "sw") is var _t240 && Truthy(_t240) ? _t240 : ((V)(2.4))), Add(((V)(4.6)), Call(R_176, V.Undef)), ((V)(((-ToNum(Call(R_176, V.Undef))) * 3D))))), fr_185.Str, co_188.Str, "</g>")).End()));
return NewObj(2).Put("s", s_183).Put("pts", Arr(CallSpread(p_168, V.Undef, new ArrBuilder().Spread(@base_178).V), tq_184, Call(p_168, V.Undef, ((V)((ToNum(GetIdx(top_177, 0D)) - ToNum(L0_187)))), H_172, GetIdx(top_177, 2D)), Call(p_168, V.Undef, Add(GetIdx(top_177, 0D), L0_187), H_172, GetIdx(top_177, 2D)), Call(p_168, V.Undef, GetIdx(top_177, 0D), Add(H_172, ((V)(10D))), GetIdx(top_177, 2D)), Call(p_168, V.Undef, GetIdx(top_177, 0D), ((V)((ToNum(H_172) - (ToNum(L0_187) * 0.5)))), Add(GetIdx(top_177, 2D), ((V)((ToNum(L0_187) * 0.7))))))).V;
return default;
}, 8, "palm", false);
LVOF_73 = Fn((V _self241, int _argc242, V _a244, V _a245, V _a246, V _a247, V[] _rest243) => {
if (_self241.IsNullish) _self241 = GlobalV;
return Get(BE_10, "LV");
return default;
}, 0, "LVOF", false);
RD_8 = Get(G("window"), "RenoDraw");
X_9 = Get(G("window"), "House3D");
BE_10 = Get(G("window"), "Beach");
if (!(Truthy(((((((RD_8 is var _t248 && !Truthy(_t248) ? _t248 : Get(RD_8, "PLUS9")) is var _t249 && !Truthy(_t249) ? _t249 : Get(RD_8, "H3")) is var _t250 && !Truthy(_t250) ? _t250 : Get(RD_8, "H7")) is var _t251 && !Truthy(_t251) ? _t251 : X_9) is var _t252 && !Truthy(_t252) ? _t252 : Get(X_9, "K")) is var _t253 && !Truthy(_t253) ? _t253 : BE_10)))) {
Call(G("setTimeout"), V.Undef, boot_254.v, ((V)(30D)));
return default;
}
if (Truthy(Get(RD_8, "BEACH"))) {
return default;
}
K_11 = Get(X_9, "K");
{ V _t255 = K_11;
if (_t255.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t255));
{ V _t256 = Get(_t255, "box");
box_12 = _t256; }
{ V _t257 = Get(_t255, "cush");
cush_13 = _t257; }
{ V _t258 = Get(_t255, "cyl");
cyl_14 = _t258; }
{ V _t259 = Get(_t255, "ball");
ball_15 = _t259; }
{ V _t260 = Get(_t255, "slab");
slab_16 = _t260; }
{ V _t261 = Get(_t255, "arcW");
arcW_17 = _t261; }
{ V _t262 = Get(_t255, "prismZ");
prismZ_18 = _t262; }
{ V _t263 = Get(_t255, "shade");
shade_19 = _t263; }
{ V _t264 = Get(_t255, "mix");
mix_20 = _t264; }
{ V _t265 = Get(_t255, "f1");
f1_21 = _t265; } }
{ V _t266 = Get(RD_8, "H3");
if (_t266.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t266));
{ V _t267 = Get(_t266, "rep");
rep_22 = _t267; }
{ V _t268 = Get(_t266, "rng");
rng_23 = _t268; }
{ V _t269 = Get(_t266, "n4");
n4_24 = _t269; }
{ V _t270 = Get(_t266, "P2");
P2_25 = _t270; }
{ V _t271 = Get(_t266, "planeH");
planeH_26 = _t271; }
{ V _t272 = Get(_t266, "bbOf");
bbOf_27 = _t272; }
{ V _t273 = Get(_t266, "mt");
mt_28 = _t273; }
{ V _t274 = Get(_t266, "wd");
wd_29 = _t274; }
{ V _t275 = Get(_t266, "cer");
cer_30 = _t275; }
{ V _t276 = Get(_t266, "pt");
pt_31 = _t276; } }
{ V _t277 = Get(RD_8, "H7");
if (_t277.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t277));
{ V _t278 = Get(_t277, "atV");
atV_32 = _t278; }
{ V _t279 = Get(_t277, "tube");
tube_33 = _t279; }
{ V _t280 = Get(_t277, "curve");
curve_34 = _t280; }
{ V _t281 = Get(_t277, "water");
water_35 = _t281; }
{ V _t282 = Get(_t277, "WP");
WP_36 = _t282; }
{ V _t283 = Get(_t277, "flames");
flames_37 = _t283; }
{ V _t284 = Get(_t277, "FDEF");
FDEF_38 = _t284; }
{ V _t285 = Get(_t277, "glowE");
glowE_39 = _t285; }
{ V _t286 = Get(_t277, "isPlay");
isPlay_40 = _t286; }
{ V _t287 = Get(_t277, "ellPts");
ellPts_41 = _t287; } }
N_42 = Get(RD_8, "N");
PI_43 = System.Math.PI;
GOLD_44 = ((V)("#e2b14a"));
WH_45 = ((V)("#ffffff"));
em_46 = Get(Get(RD_8, "H"), "em");
fb_47 = Fn((V _arrowThis295, int _argc288, V o_294, V _a291, V _a292, V _a293, V[] _rest289) => {
return Object_assign(NewObj(2).Put("mat", ((V)("fab"))).Put("soft", ((V)(1D))).V, (o_294 is var _t296 && Truthy(_t296) ? _t296 : NewObj(0).V));
}, 1, "", true);
T_48 = Fn((V _arrowThis304, int _argc297, V S_303, V _a300, V _a301, V _a302, V[] _rest298) => {
return ((Get(S_303, "row") is var _t305 && !Truthy(_t305) ? _t305 : Get(Get(S_303, "row"), "tier")) is var _t306 && Truthy(_t306) ? _t306 : ((V)(1D)));
}, 1, "", true);
SAND_49 = ((V)("#e6c68a"));
SANDD_50 = ((V)("#c9a466"));
PP_51 = Fn((V _arrowThis318, int _argc307, V d_313, V f_314, V s_315, V w_316, V[] _rest308) => {
V ex_317 = default;
ex_317 = (_argc307 > 4 ? _rest308[0] : V.Undef);
return ((V)(string.Concat("<path d=\"", ToStr(d_313), "\" fill=\"", ToStr((f_314 is var _t319 && Truthy(_t319) ? _t319 : ((V)("none")))), "\"", (Truthy(s_315) ? string.Concat(" stroke=\"", ToStr(s_315), "\" stroke-width=\"", ToStr((w_316 is var _t320 && Truthy(_t320) ? _t320 : ((V)(1D)))), "\" stroke-linejoin=\"round\" stroke-linecap=\"round\"") : ""), ToStr((ex_317 is var _t321 && Truthy(_t321) ? _t321 : ((V)("")))), "/>")));
}, 5, "", true);
PQ_52 = Fn((V _arrowThis330, int _argc322, V p_328, V pts_329, V _a326, V _a327, V[] _rest323) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(pts_329, "map", Fn((V _arrowThis338, int _argc331, V q_337, V _a334, V _a335, V _a336, V[] _rest332) => {
return Call(P2_25, V.Undef, CallSpread(p_328, V.Undef, new ArrBuilder().Spread(q_337).V));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
}, 2, "", true);
AT_53 = Fn((V _arrowThis349, int _argc339, V type_345, V vals_346, V d_347, V b_348, V[] _rest340) => {
return ((V)(string.Concat("<animateTransform attributeName=\"transform\" type=\"", ToStr(type_345), "\" values=\"", ToStr(vals_346), "\" dur=\"", ToStr(Call(n4_24, V.Undef, d_347)), "s\"", (Truthy(b_348) ? string.Concat(" begin=\"", ToStr(Call(n4_24, V.Undef, b_348)), "s\"") : ""), " repeatCount=\"indefinite\"/>")));
}, 4, "", true);
AN_54 = Fn((V _arrowThis360, int _argc350, V a_356, V vals_357, V d_358, V b_359, V[] _rest351) => {
return ((V)(string.Concat("<animate attributeName=\"", ToStr(a_356), "\" values=\"", ToStr(vals_357), "\" dur=\"", ToStr(Call(n4_24, V.Undef, d_358)), "s\"", (Truthy(b_359) ? string.Concat(" begin=\"", ToStr(Call(n4_24, V.Undef, b_359)), "s\"") : ""), " repeatCount=\"indefinite\"/>")));
}, 4, "", true);
sway_55 = Fn((V _arrowThis371, int _argc361, V q_367, V a_368, V d_369, V b_370, V[] _rest362) => {
return Call(atV_32, V.Undef, ((V)("rotate")), Arr(((V)(string.Concat(NumStr((-ToNum(a_368))), " ", ToStr(Call(P2_25, V.Undef, q_367))))), ((V)(string.Concat(ToStr(a_368), " ", ToStr(Call(P2_25, V.Undef, q_367))))), ((V)(string.Concat(NumStr((-ToNum(a_368))), " ", ToStr(Call(P2_25, V.Undef, q_367)))))), d_369, b_370);
}, 4, "", true);
ink_56 = Fn((V _arrowThis379, int _argc372, V c_378, V _a375, V _a376, V _a377, V[] _rest373) => {
return Call(shade_19, V.Undef, c_378, ((V)(0.55)));
}, 1, "", true);
crab_59 = Fn((V _arrowThis392, int _argc380, V q_386, V k_387, V col_388, V d_389, V[] _rest381) => {
V b_390 = default;
V dx_391 = default;
b_390 = (_argc380 > 4 ? _rest381[0] : V.Undef);
dx_391 = (_argc380 > 5 ? _rest381[1] : V.Undef);
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(P2_25, V.Undef, q_386)), ") scale(", ToStr(Call(n4_24, V.Undef, k_387)), ")\"><g>", ToStr(Call(AT_53, V.Undef, ((V)("translate")), ((V)(string.Concat("0 0;", ToStr(dx_391), " 0;0 0;", NumStr(((-ToNum(dx_391)) * 0.6)), " 0;0 0"))), d_389, b_390)), "<path d=\"M-5 0Q-5 -4 0 -4Q5 -4 5 0Q0 2 -5 0Z\" fill=\"", ToStr(col_388), "\" stroke=\"", ToStr(Call(ink_56, V.Undef, col_388)), "\" stroke-width=\"0.7\"/><path d=\"M-5 -1L-8 -4M5 -1L8 -4M-4 0L-7 2M4 0L7 2\" stroke=\"", ToStr(Call(ink_56, V.Undef, col_388)), "\" stroke-width=\"0.8\" stroke-linecap=\"round\"/><circle cx=\"-2\" cy=\"-5\" r=\"1\" fill=\"#2a1a10\"/><circle cx=\"2\" cy=\"-5\" r=\"1\" fill=\"#2a1a10\"/></g></g>")));
}, 6, "", true);
star5_60 = Fn((V _arrowThis403, int _argc393, V q_399, V k_400, V col_401, V rot_402, V[] _rest394) => {
return ((V)(string.Concat("<path transform=\"translate(", ToStr(Call(P2_25, V.Undef, q_399)), ") scale(", ToStr(Call(n4_24, V.Undef, k_400)), ") rotate(", ToStr((rot_402 is var _t404 && Truthy(_t404) ? _t404 : ((V)(0D)))), ")\" d=\"M0-5L1.4-1.6L5-1.6L2.2 0.6L3.2 4.4L0 2.2L-3.2 4.4L-2.2 0.6L-5-1.6L-1.4-1.6Z\" fill=\"", ToStr(col_401), "\" stroke=\"", ToStr(Call(ink_56, V.Undef, col_401)), "\" stroke-width=\"0.6\"/>")));
}, 4, "", true);
ripples_61 = Fn((V _arrowThis416, int _argc405, V p_411, V rx_412, V rz_413, V n_414, V[] _rest406) => {
V d_415 = default;
d_415 = (_argc405 > 4 ? _rest406[0] : V.Undef);
return ((V)(string.Concat("<g transform=\"", ToStr(Call(planeH_26, V.Undef, p_411, ((V)(0.4)))), "\">", ToStr(Invoke(Call(rep_22, V.Undef, (n_414 is var _t417 && Truthy(_t417) ? _t417 : ((V)(2D))), Fn((V _arrowThis425, int _argc418, V j_424, V _a421, V _a422, V _a423, V[] _rest419) => {
return ((V)(string.Concat("<ellipse cx=\"0\" cy=\"0\" rx=\"", ToStr(rx_412), "\" ry=\"", ToStr(rz_413), "\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"1.4\"><animate attributeName=\"rx\" values=\"", ToStr(rx_412), ";", NumStr((ToNum(rx_412) * 1.35)), "\" dur=\"", ToStr((d_415 is var _t426 && Truthy(_t426) ? _t426 : ((V)(2.6)))), "s\" begin=\"", NumStr((((-ToNum(j_424)) * ToNum((d_415 is var _t427 && Truthy(_t427) ? _t427 : ((V)(2.6))))) / 2D)), "s\" repeatCount=\"indefinite\"/><animate attributeName=\"ry\" values=\"", ToStr(rz_413), ";", NumStr((ToNum(rz_413) * 1.35)), "\" dur=\"", ToStr((d_415 is var _t428 && Truthy(_t428) ? _t428 : ((V)(2.6)))), "s\" begin=\"", NumStr((((-ToNum(j_424)) * ToNum((d_415 is var _t429 && Truthy(_t429) ? _t429 : ((V)(2.6))))) / 2D)), "s\" repeatCount=\"indefinite\"/><animate attributeName=\"opacity\" values=\"0.8;0\" dur=\"", ToStr((d_415 is var _t430 && Truthy(_t430) ? _t430 : ((V)(2.6)))), "s\" begin=\"", NumStr((((-ToNum(j_424)) * ToNum((d_415 is var _t431 && Truthy(_t431) ? _t431 : ((V)(2.6))))) / 2D)), "s\" repeatCount=\"indefinite\"/></ellipse>")));
}, 1, "", true)), "join", ((V)("")))), "</g>")));
}, 5, "", true);
HUE_62 = ((V)("<filter id=\"bhBlue\" x=\"-50%\" y=\"-50%\" width=\"200%\" height=\"200%\"><feColorMatrix type=\"hueRotate\" values=\"190\"/></filter>"));
GLW_63 = ((V)("<radialGradient id=\"bhG\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#fff2b0\" stop-opacity=\"0.8\"/><stop offset=\"1\" stop-color=\"#fff2b0\" stop-opacity=\"0\"/></radialGradient><radialGradient id=\"bhC\" cx=\"50%\" cy=\"50%\" r=\"50%\"><stop offset=\"0\" stop-color=\"#bffcff\" stop-opacity=\"0.85\"/><stop offset=\"1\" stop-color=\"#4fe0f0\" stop-opacity=\"0\"/></radialGradient>"));
glowAt_64 = Fn((V _arrowThis442, int _argc432, V q_438, V r_439, V id_440, V op_441, V[] _rest433) => {
return ((V)(string.Concat("<ellipse cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_438, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_438, 1D))), "\" rx=\"", ToStr(Call(f1_21, V.Undef, r_439)), "\" ry=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(r_439) * 0.8))))), "\" fill=\"url(#", ToStr((id_440 is var _t443 && Truthy(_t443) ? _t443 : ((V)("bhG")))), ")\" opacity=\"", ToStr((op_441 is var _t444 && Truthy(_t444) ? _t444 : ((V)(1D)))), "\">", ToStr(Call(AN_54, V.Undef, ((V)("opacity")), ((V)(string.Concat(ToStr((op_441 is var _t445 && Truthy(_t445) ? _t445 : ((V)(1D)))), ";", ToStr(Call(n4_24, V.Undef, ((V)((ToNum((op_441 is var _t446 && Truthy(_t446) ? _t446 : ((V)(1D)))) * 0.6))))), ";", ToStr((op_441 is var _t447 && Truthy(_t447) ? _t447 : ((V)(1D))))))), ((V)(2.2)))), "</ellipse>")));
}, 4, "", true);
Set(N_42, "bLounger", Fn((V _arrowThis455, int _argc448, V S_454, V _a451, V _a452, V _a453, V[] _rest449) => {
V t_456 = default;
V H_457 = default;
V D_458 = default;
V back_459 = default;
t_456 = Call(T_48, V.Undef, S_454);
H_457 = GetIdx(Arr(((V)(13D)), ((V)(18D)), ((V)(20D)), ((V)(22D)), ((V)(18D))), (ToNum(t_456) - 1D));
D_458 = NewObj(4).Put("w", ((V)((SEqN(t_456, 4D) ? 160D : 150D)))).Put("d", ((V)((SEqN(t_456, 4D) ? 104D : 62D)))).Put("act", ((V)("sun"))).Put("seats", (SEqN(t_456, 4D) ? Arr(NewObj(4).Put("x", ((V)((-18D)))).Put("z", ((V)(4D))).Put("h", Add(H_457, ((V)(8D)))).Put("k", ((V)("sun"))).V, NewObj(4).Put("x", ((V)(34D))).Put("z", ((V)(4D))).Put("h", Add(H_457, ((V)(8D)))).Put("k", ((V)("sun"))).V) : Arr(NewObj(4).Put("x", ((V)(14D))).Put("z", ((V)(2D))).Put("h", Add(H_457, ((V)(4D)))).Put("k", ((V)("sun"))).V))).V;
back_459 = Fn((V _arrowThis472, int _argc460, V z0_466, V z1_467, V c_468, V y0_469, V[] _rest461) => {
V th_470 = default;
V o2_471 = default;
th_470 = (_argc460 > 4 ? _rest461[0] : V.Undef);
o2_471 = (_argc460 > 5 ? _rest461[1] : V.Undef);
return Call(prismZ_18, V.Undef, z0_466, z1_467, Arr(Arr(((V)((-40D))), y0_469), Arr(((V)((-36D))), Add(y0_469, th_470)), Arr(((V)((-62D))), Add(Add(y0_469, ((V)(40D))), th_470)), Arr(((V)((-68D))), Add(y0_469, ((V)(40D))))), c_468, (o2_471 is var _t473 && Truthy(_t473) ? _t473 : NewObj(0).V));
}, 6, "", true);
Set(D_458, "build", Fn((V _arrowThis481, int _argc474, V P_480, V _a477, V _a478, V _a479, V[] _rest475) => {
V o_482 = default;
o_482 = Arr();
if (SEqN(t_456, 1D)) {
Invoke(Arr(Arr(((V)((-60D))), ((V)((-22D)))), Arr(((V)((-60D))), ((V)(22D))), Arr(((V)(58D)), ((V)((-22D)))), Arr(((V)(58D)), ((V)(22D)))), "forEach", Fn((V _arrowThis494, int _argc483, V _a485, V _a486, V _a487, V _a488, V[] _rest484) => {
V x_491 = default;
V z_493 = default;
{ V _t489 = ListOf(_a485);
{ V _t490 = GetIdx(_t489, 0D);
x_491 = _t490; }
{ V _t492 = GetIdx(_t489, 1D);
z_493 = _t492; }
}
return Invoke(o_482, "push", Call(cyl_14, V.Undef, x_491, ((V)(0D)), z_493, ((V)(1.6)), H_457, ((V)("#b8bec4")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
}, 1, "", true));
Invoke(Arr(((V)((-23D))), ((V)(23D))), "forEach", Fn((V _arrowThis502, int _argc495, V z_501, V _a498, V _a499, V _a500, V[] _rest496) => {
return Invoke(o_482, "push", Call(box_12, V.Undef, ((V)(0D)), H_457, z_501, ((V)(128D)), ((V)(2D)), ((V)(2.4)), ((V)("#c9cdd2")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
Call(rep_22, V.Undef, ((V)(8D)), Fn((V _arrowThis510, int _argc503, V i_509, V _a506, V _a507, V _a508, V[] _rest504) => {
if (SEqN(i_509, 3D)) {
return default;
}
Invoke(o_482, "push", Call(box_12, V.Undef, ((V)(((-38D) + (ToNum(i_509) * 14D)))), ((V)((ToNum(H_457) - 0.4))), ((V)(0D)), ((V)(9D)), ((V)(1.4)), ((V)(44D)), ((V)((NumTruthy((ToNum(i_509) % 2D)) ? "#f1f0e6" : "#7fbf7a"))), Call(fb_47, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
return default;
}, 1, "", true));
Invoke(o_482, "push", Call(back_459, V.Undef, ((V)((-22D))), ((V)(22D)), ((V)("#7fbf7a")), H_457, ((V)(2D)), Call(fb_47, V.Undef)), Call(box_12, V.Undef, ((V)((-12D))), ((V)((ToNum(H_457) - 3D))), ((V)(18D)), ((V)(8D)), ((V)(3D)), ((V)(6D)), ((V)("#7fbf7a")), Call(fb_47, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
} else {
if (SEqN(t_456, 2D)) {
Invoke(Arr(Arr(((V)((-58D))), ((V)((-24D)))), Arr(((V)((-58D))), ((V)(24D))), Arr(((V)(56D)), ((V)((-24D)))), Arr(((V)(56D)), ((V)(24D)))), "forEach", Fn((V _arrowThis522, int _argc511, V _a513, V _a514, V _a515, V _a516, V[] _rest512) => {
V x_519 = default;
V z_521 = default;
{ V _t517 = ListOf(_a513);
{ V _t518 = GetIdx(_t517, 0D);
x_519 = _t518; }
{ V _t520 = GetIdx(_t517, 1D);
z_521 = _t520; }
}
return Invoke(o_482, "push", Call(box_12, V.Undef, x_519, ((V)(0D)), z_521, ((V)(4D)), H_457, ((V)(4D)), ((V)("#b8804a")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
}, 1, "", true));
Invoke(Arr(((V)((-25D))), ((V)(25D))), "forEach", Fn((V _arrowThis530, int _argc523, V z_529, V _a526, V _a527, V _a528, V[] _rest524) => {
return Invoke(o_482, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)((ToNum(H_457) - 3D))), z_529, ((V)(124D)), ((V)(4D)), ((V)(3D)), ((V)("#c48a52")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
Invoke(Arr(Arr(((V)((-24D))), ((V)((-8D))), ((V)("#e2554a"))), Arr(((V)((-8D))), ((V)(8D)), ((V)("#fffaf1"))), Arr(((V)(8D)), ((V)(24D)), ((V)("#e2554a")))), "forEach", Fn((V _arrowThis544, int _argc531, V _a533, V _a534, V _a535, V _a536, V[] _rest532) => {
V a_539 = default;
V b_541 = default;
V c_543 = default;
{ V _t537 = ListOf(_a533);
{ V _t538 = GetIdx(_t537, 0D);
a_539 = _t538; }
{ V _t540 = GetIdx(_t537, 1D);
b_541 = _t540; }
{ V _t542 = GetIdx(_t537, 2D);
c_543 = _t542; }
}
Invoke(o_482, "push", Call(box_12, V.Undef, ((V)(10D)), ((V)((ToNum(H_457) - 1D))), ((V)((ToNum(Add(a_539, b_541)) / 2D))), ((V)(100D)), ((V)(2.6)), ((V)((ToNum(b_541) - ToNum(a_539)))), c_543, Call(fb_47, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)), Call(back_459, V.Undef, a_539, b_541, c_543, ((V)((ToNum(H_457) - 1D))), ((V)(2.6)), Call(fb_47, V.Undef)));
return default;
}, 1, "", true));
} else {
if (SEqN(t_456, 3D)) {
InvokeSpread(o_482, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(140D)), ((V)((ToNum(H_457) - 6D))), ((V)(56D)), ((V)("#a8683a")), Call(wd_29, V.Undef, NewObj(2).Put("r", ((V)(3D))).Put("bev", ((V)(1.4))).V))).Spread(Invoke(Arr(Arr(((V)((-64D))), ((V)((-24D)))), Arr(((V)((-64D))), ((V)(24D))), Arr(((V)(62D)), ((V)((-24D)))), Arr(((V)(62D)), ((V)(24D)))), "map", Fn((V _arrowThis556, int _argc545, V _a547, V _a548, V _a549, V _a550, V[] _rest546) => {
V x_553 = default;
V z_555 = default;
{ V _t551 = ListOf(_a547);
{ V _t552 = GetIdx(_t551, 0D);
x_553 = _t552; }
{ V _t554 = GetIdx(_t551, 1D);
z_555 = _t554; }
}
return Call(box_12, V.Undef, x_553, ((V)(0D)), z_555, ((V)(6D)), ((V)(5D)), ((V)(6D)), ((V)("#7a4a24")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V));
}, 1, "", true))).V);
Invoke(o_482, "push", Call(cush_13, V.Undef, ((V)(14D)), ((V)((ToNum(H_457) - 2D))), ((V)(0D)), ((V)(104D)), ((V)(8D)), ((V)(54D)), ((V)("#2f4f86")), Call(fb_47, V.Undef)), Call(back_459, V.Undef, ((V)((-26D))), ((V)(26D)), ((V)("#a8683a")), ((V)((ToNum(H_457) - 2D))), ((V)(3D)), Call(wd_29, V.Undef)), Call(back_459, V.Undef, ((V)((-25D))), ((V)(25D)), ((V)("#2f4f86")), Add(H_457, ((V)(1D))), ((V)(6D)), Call(fb_47, V.Undef)), Call(ball_15, V.Undef, ((V)((-44D))), Add(H_457, ((V)(18D))), ((V)(0D)), ((V)(8D)), ((V)("#fffaf1")), Call(fb_47, V.Undef, NewObj(3).Put("sx", ((V)(2.4))).Put("sy", ((V)(0.8))).Put("k", ((V)(4D))).V)));
} else {
if (SEqN(t_456, 4D)) {
InvokeSpread(o_482, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(150D)), ((V)(12D)), ((V)(100D)), ((V)("#f4f1ea")), Call(pt_31, V.Undef, NewObj(2).Put("r", ((V)(4D))).Put("bev", ((V)(2D))).V))).Add(Call(cush_13, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(142D)), ((V)(12D)), ((V)(92D)), ((V)("#ffffff")), Call(fb_47, V.Undef))).Spread(Invoke(Arr(Arr(((V)((-77.6))), ((V)((-46D)))), Arr(((V)((-77.6))), ((V)(46D))), Arr(((V)(77.6)), ((V)((-46D)))), Arr(((V)(77.6)), ((V)(46D)))), "map", Fn((V _arrowThis568, int _argc557, V _a559, V _a560, V _a561, V _a562, V[] _rest558) => {
V x_565 = default;
V z_567 = default;
{ V _t563 = ListOf(_a559);
{ V _t564 = GetIdx(_t563, 0D);
x_565 = _t564; }
{ V _t566 = GetIdx(_t563, 1D);
z_567 = _t566; }
}
return Call(cyl_14, V.Undef, x_565, ((V)(0D)), z_567, ((V)(2.6)), ((V)(94D)), ((V)("#e2b14a")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(8D))).V));
}, 1, "", true))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(94D)), ((V)(0D)), ((V)(160D)), ((V)(5D)), ((V)(104D)), ((V)("#f4f1ea")), Call(fb_47, V.Undef, NewObj(1).Put("r", ((V)(3D))).V))).Spread(Invoke(Arr(((V)((-40D))), ((V)(0D)), ((V)(40D))), "map", Fn((V _arrowThis577, int _argc569, V x_575, V i_576, V _a573, V _a574, V[] _rest570) => {
return Call(ball_15, V.Undef, x_575, ((V)(24D)), ((V)((-38D))), ((V)(9D)), GetK(Arr(((V)("#3fb0c8")), ((V)("#ffd66b")), ((V)("#3fb0c8"))), i_576), Call(fb_47, V.Undef, NewObj(4).Put("sx", ((V)(1.8))).Put("sy", ((V)(1.1))).Put("sz", ((V)(0.7))).Put("k", ((V)(4D))).V));
}, 2, "", true))).V);
} else {
Invoke(o_482, "push", Call(ball_15, V.Undef, ((V)(10D)), ((V)((ToNum(H_457) - 4D))), ((V)(0D)), ((V)(52D)), ((V)("#ffe6dc")), Call(cer_30, V.Undef, NewObj(6).Put("sx", ((V)(1.4))).Put("sy", ((V)(0.28))).Put("sz", ((V)(0.62))).Put("k", ((V)(4D))).Put("n", ((V)(20D))).Put("shine", ((V)(1D))).V)), Call(prismZ_18, V.Undef, ((V)((-26D))), ((V)(26D)), Arr(Arr(((V)((-44D))), ((V)((ToNum(H_457) - 8D)))), Arr(((V)((-30D))), H_457), Arr(((V)((-64D))), Add(H_457, ((V)(44D)))), Arr(((V)((-78D))), Add(H_457, ((V)(30D))))), ((V)("#ffd6c8")), Call(cer_30, V.Undef, NewObj(1).Put("shine", ((V)(1D))).V)), Call(ball_15, V.Undef, ((V)((-48D))), Add(H_457, ((V)(16D))), ((V)(0D)), ((V)(9D)), ((V)("#fffaf6")), Call(cer_30, V.Undef, NewObj(4).Put("sx", ((V)(2.2))).Put("sy", ((V)(0.9))).Put("k", ((V)(5D))).Put("shine", ((V)(1D))).V)), Call(cyl_14, V.Undef, ((V)(10D)), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(3D)), ((V)("#bfeffa")), Call(em_46, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)));
}
}
}
}
return o_482;
return default;
}, 1, "", true));
Set(D_458, "fx", Fn((V _arrowThis585, int _argc578, V c_584, V _a581, V _a582, V _a583, V[] _rest579) => {
V p_586 = default;
V k_587 = default;
V f_588 = default;
V defs_589 = default;
p_586 = Get(c_584, "p");
k_587 = Get(c_584, "k");
f_588 = ((V)(""));
defs_589 = ((V)(""));
if (SEqN(t_456, 4D)) {
Call(rep_22, V.Undef, ((V)(14D)), Fn((V _arrowThis597, int _argc590, V i_596, V _a593, V _a594, V _a595, V[] _rest591) => {
double x_598 = 0;
V q_599 = default;
x_598 = ((-78D) + (ToNum(i_596) * 12D));
q_599 = Call(p_586, V.Undef, ((V)(x_598)), ((V)(94D)), ((V)(52D)));
f_588 = Add(f_588, Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, q_599)), "l0 ", ToStr(Call(f1_21, V.Undef, ((V)((7D * ToNum(k_587))))))))), ((V)("none")), ((V)("#3fb0c8")), ((V)(1.4))));
return default;
}, 1, "", true));
}
if (SEqN(t_456, 5D)) {
defs_589 = GLW_63;
f_588 = Add(Invoke(Call(rep_22, V.Undef, ((V)(7D)), Fn((V _arrowThis607, int _argc600, V i_606, V _a603, V _a604, V _a605, V[] _rest601) => {
double a_608 = 0;
V q0_609 = default;
V q1_610 = default;
a_608 = ((-0.7) + (ToNum(i_606) * 0.23));
q0_609 = Call(p_586, V.Undef, ((V)(10D)), Add(H_457, ((V)(9D))), ((V)(0D)));
q1_610 = Call(p_586, V.Undef, ((V)((10D + (FdLibm.Cos(a_608) * 66D)))), Add(H_457, ((V)(6D))), ((V)((FdLibm.Sin(a_608) * 32D))));
return Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, q0_609)), "L", ToStr(Call(P2_25, V.Undef, q1_610))))), ((V)("none")), ((V)("#e8a898")), ((V)(1D)), ((V)(" opacity=\"0.7\"")));
return default;
}, 1, "", true)), "join", ((V)(""))), Call(glowAt_64, V.Undef, Call(p_586, V.Undef, ((V)(10D)), ((V)(0D)), ((V)(0D))), ((V)((40D * ToNum(k_587)))), ((V)("bhC")), ((V)(0.7))));
}
if (SEqN(t_456, 1D)) {
f_588 = Add(f_588, Call(PP_51, V.Undef, Call(PQ_52, V.Undef, p_586, Arr(Arr(((V)((-8D))), Add(H_457, ((V)(1.2))), ((V)((-10D)))), Arr(((V)(4D)), Add(H_457, ((V)(1.2))), ((V)((-6D)))), Arr(((V)((-2D))), Add(H_457, ((V)(1.2))), ((V)(4D))))), ((V)("#5a4a3a")), ((V)("")), ((V)(0D)), ((V)(" opacity=\"0.5\""))));
}
return NewObj(3).Put("defs", defs_589).Put("front", f_588).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_586, V.Undef, ((V)((-80D))), ((V)(0D)), ((V)((-50D)))), Call(p_586, V.Undef, ((V)(80D)), ((V)(0D)), ((V)(50D))), Call(p_586, V.Undef, ((V)((-80D))), ((V)(100D)), ((V)(0D))), Call(p_586, V.Undef, ((V)(80D)), ((V)(100D)), ((V)(0D))), Call(p_586, V.Undef, ((V)((-70D))), Add(H_457, ((V)(50D))), ((V)(0D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_458;
return default;
}, 1, "", true));
UMB_65 = Arr(NewObj(6).Put("cols", Arr(((V)("#c9b8a0")), ((V)("#b4c4bc")))).Put("R", ((V)(52D))).Put("h", ((V)(18D))).Put("y", ((V)(72D))).Put("pole", ((V)("#9aa1a6"))).Put("towel", Arr(((V)("#b8b0a0")))).V, NewObj(6).Put("cols", Arr(((V)("#ff6a5a")), ((V)("#ffb340")), ((V)("#ffe066")), ((V)("#6fd06a")), ((V)("#4fb0f0")), ((V)("#a07af0")))).Put("R", ((V)(58D))).Put("h", ((V)(20D))).Put("y", ((V)(80D))).Put("pole", ((V)("#ffffff"))).Put("towel", Arr(((V)("#4fb0f0")), ((V)("#ffffff")))).V, NewObj(8).Put("cols", Arr(((V)("#d8b46a")), ((V)("#c9a45a")))).Put("R", ((V)(56D))).Put("h", ((V)(24D))).Put("y", ((V)(78D))).Put("pole", ((V)("#8a5a2c"))).Put("towel", Arr(((V)("#e3946a")), ((V)("#fff1d8")))).Put("fringe", ((V)("#c49a50"))).Put("n", ((V)(16D))).V, NewObj(8).Put("cols", Arr(((V)("#ffffff")), ((V)("#2f9fb8")))).Put("R", ((V)(60D))).Put("h", ((V)(20D))).Put("y", ((V)(82D))).Put("pole", ((V)("#e2b14a"))).Put("towel", Arr(((V)("#2f9fb8")), ((V)("#ffffff")))).Put("scallop", ((V)(1D))).Put("tassel", ((V)("#e2b14a"))).V, NewObj(8).Put("cols", Arr(((V)("#ffe6dc")), ((V)("#ffd0c4")))).Put("R", ((V)(64D))).Put("h", ((V)(26D))).Put("y", ((V)(86D))).Put("pole", ((V)("#f4e6d8"))).Put("towel", Arr(((V)("#ffd6c8")), ((V)("#fffaf6")))).Put("scallop", ((V)(1D))).Put("n", ((V)(14D))).V);
Set(N_42, "bUmbrella", Fn((V _arrowThis618, int _argc611, V S_617, V _a614, V _a615, V _a616, V[] _rest612) => {
V t_619 = default;
V U_620 = default;
V D_621 = default;
t_619 = Call(T_48, V.Undef, S_617);
U_620 = GetIdx(UMB_65, (ToNum(t_619) - 1D));
D_621 = NewObj(4).Put("w", ((V)(130D))).Put("d", ((V)(110D))).Put("act", ((V)("nap"))).Put("seats", Arr(NewObj(4).Put("x", ((V)((-4D)))).Put("z", ((V)(20D))).Put("h", ((V)(3D))).Put("k", ((V)("nap"))).V)).V;
Set(D_621, "build", Fn((V _arrowThis629, int _argc622, V P_628, V _a625, V _a626, V _a627, V[] _rest623) => {
V o_630 = default;
o_630 = Arr(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-16D))), ((V)(2.2)), Add(Get(U_620, "y"), Get(U_620, "h")), Get(U_620, "pole"), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-16D))), ((V)(6D)), ((V)(2D)), SANDD_50, Call(pt_31, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
Invoke(Get(U_620, "towel"), "forEach", Fn((V _arrowThis639, int _argc631, V c_637, V i_638, V _a635, V _a636, V[] _rest632) => {
return Invoke(o_630, "push", Call(box_12, V.Undef, ((V)((-4D))), ((V)(0D)), ((V)((20D + ((ToNum(i_638) - ((ToNum(Get(Get(U_620, "towel"), "length")) - 1D) / 2D)) * 18D)))), ((V)(74D)), ((V)(1.4)), ((V)((GtN(Get(Get(U_620, "towel"), "length"), 1D) ? 18D : 40D))), c_637, Call(fb_47, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 2, "", true));
if (SEqN(t_619, 5D)) {
Invoke(o_630, "push", Call(ball_15, V.Undef, ((V)(0D)), Add(Add(Get(U_620, "y"), Get(U_620, "h")), ((V)(6D))), ((V)((-16D))), ((V)(6D)), ((V)("#fffaf6")), Call(cer_30, V.Undef, NewObj(2).Put("shine", ((V)(1D))).Put("k", ((V)(5D))).V)));
}
return o_630;
return default;
}, 1, "", true));
Set(D_621, "fx", Fn((V _arrowThis647, int _argc640, V c_646, V _a643, V _a644, V _a645, V[] _rest641) => {
V p_648 = default;
V k_649 = default;
V f_650 = default;
V defs_651 = default;
p_648 = Get(c_646, "p");
k_649 = Get(c_646, "k");
f_650 = Call(cone_57, V.Undef, p_648, k_649, NewObj(10).Put("y", Get(U_620, "y")).Put("h", Get(U_620, "h")).Put("R", Get(U_620, "R")).Put("n", (Get(U_620, "n") is var _t652 && Truthy(_t652) ? _t652 : ((V)(12D)))).Put("cols", Get(U_620, "cols")).Put("z", ((V)((-16D)))).Put("fringe", Get(U_620, "fringe")).Put("scallop", Get(U_620, "scallop")).Put("tassel", Get(U_620, "tassel")).Put("fl", ((V)(9D))).V);
defs_651 = GLW_63;
if (SEqN(t_619, 1D)) {
V q_653 = default;
q_653 = Call(p_648, V.Undef, ((V)(18D)), Add(Get(U_620, "y"), ((V)(6D))), ((V)(10D)));
f_650 = Add(f_650, Add(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_653, 0D)) - (7D * ToNum(k_649))))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_653, 1D)) - (4D * ToNum(k_649))))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((12D * ToNum(k_649)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)(((-2D) * ToNum(k_649)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((1D * ToNum(k_649)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((8D * ToNum(k_649)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)(((-12D) * ToNum(k_649)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((2D * ToNum(k_649)))))), "Z"))), ((V)("#9fa88a")), ((V)("#5e584e")), ((V)(0.8))), Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_653, 0D)) - (5D * ToNum(k_649))))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_653, 1D)) - (2D * ToNum(k_649))))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((8D * ToNum(k_649)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((3D * ToNum(k_649))))))))), ((V)("none")), ((V)("#5e584e")), ((V)(0.6)), ((V)(" stroke-dasharray=\"1.4 1.4\"")))));
}
if (SEqN(t_619, 2D)) {
V q_654 = default;
q_654 = Call(p_648, V.Undef, ((V)(30D)), ((V)(0.4)), ((V)(24D)));
f_650 = ((V)(JsStrBuf.Begin().V(f_650).S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_25, V.Undef, q_654)), ") scale(", ToStr(Call(n4_24, V.Undef, k_649)), ")\"><ellipse cx=\"0\" cy=\"0\" rx=\"4\" ry=\"2\" fill=\"#ff6a5a\" stroke=\"#8a2a20\" stroke-width=\"0.6\"/><ellipse cx=\"9\" cy=\"1\" rx=\"4\" ry=\"2\" fill=\"#ff6a5a\" stroke=\"#8a2a20\" stroke-width=\"0.6\"/></g>")).End()));
}
if (SEqN(t_619, 5D)) {
f_650 = Add(f_650, Call(glowAt_64, V.Undef, Call(p_648, V.Undef, ((V)(0D)), Add(Add(Get(U_620, "y"), Get(U_620, "h")), ((V)(6D))), ((V)((-16D)))), ((V)((22D * ToNum(k_649)))), ((V)("bhG")), ((V)(0.8))));
}
return NewObj(3).Put("defs", defs_651).Put("front", f_650).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_648, V.Undef, ((V)((-ToNum(Get(U_620, "R"))))), Get(U_620, "y"), ((V)(((-16D) - ToNum(Get(U_620, "R")))))), Call(p_648, V.Undef, Get(U_620, "R"), Get(U_620, "y"), Add(((V)((-16D))), Get(U_620, "R"))), Call(p_648, V.Undef, ((V)(0D)), Add(Add(Get(U_620, "y"), Get(U_620, "h")), ((V)(12D))), ((V)((-16D)))), Call(p_648, V.Undef, ((V)((-50D))), ((V)(0D)), ((V)(50D))), Call(p_648, V.Undef, ((V)(46D)), ((V)(0D)), ((V)(50D))), Call(p_648, V.Undef, ((V)((-ToNum(Get(U_620, "R"))))), ((V)((ToNum(Get(U_620, "y")) - 12D))), ((V)((-16D)))), Call(p_648, V.Undef, Get(U_620, "R"), ((V)((ToNum(Get(U_620, "y")) - 12D))), ((V)((-16D))))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_621;
return default;
}, 1, "", true));
Set(N_42, "bTowel", Fn((V _arrowThis662, int _argc655, V S_661, V _a658, V _a659, V _a660, V[] _rest656) => {
V t_663 = default;
V round_664 = default;
V D_665 = default;
t_663 = Call(T_48, V.Undef, S_661);
round_664 = (SEqN(t_663, 3D) ? V.True : V.False);
D_665 = NewObj(5).Put("w", ((V)((Truthy(round_664) ? 96D : 110D)))).Put("d", ((V)((Truthy(round_664) ? 96D : 60D)))).Put("flat", ((V)(1D))).Put("act", ((V)("sun"))).Put("seats", Arr(NewObj(4).Put("x", ((V)((Truthy(round_664) ? 0D : 6D)))).Put("z", ((V)(2D))).Put("h", ((V)((SEqN(t_663, 4D) ? 7D : 2D)))).Put("k", ((V)("sun"))).V)).V;
Set(D_665, "build", Fn((V _arrowThis673, int _argc666, V P_672, V _a669, V _a670, V _a671, V[] _rest667) => {
V o_674 = default;
o_674 = Arr();
if (SEqN(t_663, 1D)) {
Invoke(o_674, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(100D)), ((V)(1.2)), ((V)(54D)), ((V)("#c9c4b6")), Call(fb_47, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
} else {
if (SEqN(t_663, 2D)) {
Invoke(Arr(Arr(((V)("#3fb0c8")), ((V)((-18D)))), Arr(((V)("#ffffff")), ((V)((-6D)))), Arr(((V)("#ffd23f")), ((V)(6D))), Arr(((V)("#ffffff")), ((V)(18D)))), "forEach", Fn((V _arrowThis686, int _argc675, V _a677, V _a678, V _a679, V _a680, V[] _rest676) => {
V c_683 = default;
V z_685 = default;
{ V _t681 = ListOf(_a677);
{ V _t682 = GetIdx(_t681, 0D);
c_683 = _t682; }
{ V _t684 = GetIdx(_t681, 1D);
z_685 = _t684; }
}
return Invoke(o_674, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), z_685, ((V)(104D)), ((V)(1.4)), ((V)(12.2)), c_683, Call(fb_47, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
} else {
if (SEqN(t_663, 3D)) {
Invoke(o_674, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(46D)), ((V)(1.4)), ((V)("#e3946a")), Call(fb_47, V.Undef, NewObj(1).Put("n", ((V)(28D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(1.4)), ((V)(0D)), ((V)(34D)), ((V)(0.4)), ((V)("#ffd66b")), Call(fb_47, V.Undef, NewObj(1).Put("n", ((V)(28D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(1.8)), ((V)(0D)), ((V)(20D)), ((V)(0.4)), ((V)("#2f9fb8")), Call(fb_47, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(2.2)), ((V)(0D)), ((V)(8D)), ((V)(0.4)), ((V)("#fff1d8")), Call(fb_47, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)));
} else {
if (SEqN(t_663, 4D)) {
Invoke(o_674, "push", Call(cush_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(108D)), ((V)(6D)), ((V)(58D)), ((V)("#f4efe4")), Call(fb_47, V.Undef)), Call(ball_15, V.Undef, ((V)((-42D))), ((V)(9D)), ((V)((-6D))), ((V)(8D)), ((V)("#2f9fb8")), Call(fb_47, V.Undef, NewObj(4).Put("sx", ((V)(1.2))).Put("sy", ((V)(0.6))).Put("sz", ((V)(1.7))).Put("k", ((V)(4D))).V)), Call(ball_15, V.Undef, ((V)((-42D))), ((V)(9D)), ((V)(14D)), ((V)(7D)), ((V)("#ffd66b")), Call(fb_47, V.Undef, NewObj(4).Put("sx", ((V)(1.1))).Put("sy", ((V)(0.6))).Put("sz", ((V)(1.4))).Put("k", ((V)(4D))).V)));
} else {
Invoke(o_674, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(108D)), ((V)(1.8)), ((V)(60D)), ((V)("#e8b84a")), Call(fb_47, V.Undef, NewObj(2).Put("r", ((V)(2D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(1.8)), ((V)(0D)), ((V)(92D)), ((V)(0.4)), ((V)(44D)), ((V)("#f6d77a")), Call(fb_47, V.Undef, NewObj(2).Put("r", ((V)(2D))).Put("shine", ((V)(1D))).V)));
}
}
}
}
return o_674;
return default;
}, 1, "", true));
Set(D_665, "fx", Fn((V _arrowThis694, int _argc687, V c_693, V _a690, V _a691, V _a692, V[] _rest688) => {
V p_695 = default;
V k_696 = default;
JsStrBuf f_697 = null;
p_695 = Get(c_693, "p");
k_696 = Get(c_693, "k");
f_697 = new JsStrBuf("");
if (SEqN(t_663, 1D)) {
Invoke(Arr(Arr(((V)((-20D))), ((V)((-8D)))), Arr(((V)(24D)), ((V)(12D))), Arr(((V)(8D)), ((V)((-14D))))), "forEach", Fn((V _arrowThis709, int _argc698, V _a700, V _a701, V _a702, V _a703, V[] _rest699) => {
V x_706 = default;
V z_708 = default;
{ V _t704 = ListOf(_a700);
{ V _t705 = GetIdx(_t704, 0D);
x_706 = _t705; }
{ V _t707 = GetIdx(_t704, 1D);
z_708 = _t707; }
}
return ((V)(f_697.V(Call(PP_51, V.Undef, Call(PQ_52, V.Undef, p_695, Invoke(Call(ellPts_41, V.Undef, x_706, z_708, ((V)(4D)), ((V)(3D)), ((V)(8D))), "map", Fn((V _arrowThis717, int _argc710, V q_716, V _a713, V _a714, V _a715, V[] _rest711) => {
return Arr(GetIdx(q_716, 0D), ((V)(1.3)), GetIdx(q_716, 1D));
}, 1, "", true))), SANDD_50, ((V)("#8a7a5c")), ((V)(0.5)))).Str));
}, 1, "", true));
f_697.V(Call(PP_51, V.Undef, Call(PQ_52, V.Undef, p_695, Arr(Arr(((V)(50D)), ((V)(1.3)), ((V)((-27D)))), Arr(((V)(56D)), ((V)(1.3)), ((V)((-20D)))), Arr(((V)(50D)), ((V)(1.3)), ((V)((-14D)))))), ((V)("#a8a294")), ((V)("")), ((V)(0D))));
}
if (SEqN(t_663, 2D)) {
V q_718 = default;
q_718 = Call(p_695, V.Undef, ((V)(60D)), ((V)(0.5)), ((V)(30D)));
f_697.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_25, V.Undef, q_718)), ") scale(", ToStr(Call(n4_24, V.Undef, k_696)), ")\"><ellipse cx=\"0\" cy=\"0\" rx=\"3.4\" ry=\"7\" fill=\"#e2554a\" stroke=\"#7a2a20\" stroke-width=\"0.6\" transform=\"rotate(70)\"/><ellipse cx=\"6\" cy=\"4\" rx=\"3.4\" ry=\"7\" fill=\"#e2554a\" stroke=\"#7a2a20\" stroke-width=\"0.6\" transform=\"rotate(70 6 4)\"/></g>"));
}
if (SEqN(t_663, 3D)) {
Call(rep_22, V.Undef, ((V)(12D)), Fn((V _arrowThis726, int _argc719, V i_725, V _a722, V _a723, V _a724, V[] _rest720) => {
double a_727 = 0;
a_727 = (((ToNum(i_725) / 12D) * 2D) * PI_43);
f_697.V(Call(PP_51, V.Undef, Call(PQ_52, V.Undef, p_695, Arr(Arr(((V)((FdLibm.Cos(a_727) * 22D))), ((V)(2.4)), ((V)((FdLibm.Sin(a_727) * 22D)))), Arr(((V)((FdLibm.Cos((a_727 + 0.18)) * 32D))), ((V)(2.4)), ((V)((FdLibm.Sin((a_727 + 0.18)) * 32D)))), Arr(((V)((FdLibm.Cos((a_727 - 0.18)) * 32D))), ((V)(2.4)), ((V)((FdLibm.Sin((a_727 - 0.18)) * 32D)))))), ((V)((NumTruthy((ToNum(i_725) % 2D)) ? "#fff1d8" : "#ff9d6a"))), ((V)("")), ((V)(0D)), ((V)(" opacity=\"0.9\""))));
return default;
}, 1, "", true));
}
if (SEqN(t_663, 5D)) {
Invoke(Arr(Arr(((V)((-54D))), ((V)((-30D)))), Arr(((V)(54D)), ((V)((-30D)))), Arr(((V)((-54D))), ((V)(30D))), Arr(((V)(54D)), ((V)(30D)))), "forEach", Fn((V _arrowThis739, int _argc728, V _a730, V _a731, V _a732, V _a733, V[] _rest729) => {
V q_740 = default;
V x_736 = default;
V z_738 = default;
{ V _t734 = ListOf(_a730);
{ V _t735 = GetIdx(_t734, 0D);
x_736 = _t735; }
{ V _t737 = GetIdx(_t734, 1D);
z_738 = _t737; }
}
q_740 = Call(p_695, V.Undef, x_736, ((V)(1D)), z_738);
f_697.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, q_740)), "l", ToStr(Call(f1_21, V.Undef, ((V)((GtN(x_736, 0D) ? 4D : (-4D)))))), " 4"))), ((V)("none")), ((V)("#c9961f")), ((V)(2D)))).S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, Add(GetIdx(q_740, 0D), ((V)((GtN(x_736, 0D) ? 4D : (-4D))))))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, Add(GetIdx(q_740, 1D), ((V)(5D))))), "\" r=\"1.8\" fill=\"#e2b14a\"/>"));
return default;
}, 1, "", true));
f_697.S(string.Concat("<g transform=\"", ToStr(Call(planeH_26, V.Undef, p_695, ((V)(2.3)))), "\"><rect x=\"-46\" y=\"-22\" width=\"92\" height=\"44\" fill=\"url(#bhSh)\"/></g>"));
}
return NewObj(3).Put("defs", ((V)((SEqN(t_663, 5D) ? "<linearGradient id=\"bhSh\" x1=\"0\" y1=\"0\" x2=\"1\" y2=\"0.2\" gradientTransform=\"translate(-1 0)\"><stop offset=\"0.35\" stop-color=\"#fff\" stop-opacity=\"0\"/><stop offset=\"0.5\" stop-color=\"#fff\" stop-opacity=\"0.7\"/><stop offset=\"0.65\" stop-color=\"#fff\" stop-opacity=\"0\"/><animateTransform attributeName=\"gradientTransform\" type=\"translate\" values=\"-1 0;1 0;1 0\" dur=\"4s\" repeatCount=\"indefinite\"/></linearGradient>" : "")))).Put("front", ((V)(f_697.Str))).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_695, V.Undef, ((V)((-66D))), ((V)(0D)), ((V)((-40D)))), Call(p_695, V.Undef, ((V)(66D)), ((V)(0D)), ((V)(40D))), Call(p_695, V.Undef, ((V)((-66D))), ((V)(0D)), ((V)(40D))), Call(p_695, V.Undef, ((V)(66D)), ((V)(0D)), ((V)((-40D)))), Call(p_695, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)))), ((V)(3D)))).V;
return default;
}, 1, "", true));
return D_665;
return default;
}, 1, "", true));
Set(N_42, "bCastle", Fn((V _arrowThis748, int _argc741, V S_747, V _a744, V _a745, V _a746, V[] _rest742) => {
V t_749 = default;
V sc_750 = default;
V D_751 = default;
V tower_752 = default;
t_749 = Call(T_48, V.Undef, S_747);
sc_750 = (SEqN(t_749, 5D) ? ((V)("#cfeefa")) : SAND_49);
D_751 = NewObj(4).Put("w", GetIdx(Arr(((V)(70D)), ((V)(90D)), ((V)(120D)), ((V)(140D)), ((V)(130D))), (ToNum(t_749) - 1D))).Put("d", GetIdx(Arr(((V)(60D)), ((V)(70D)), ((V)(100D)), ((V)(110D)), ((V)(100D))), (ToNum(t_749) - 1D))).Put("act", ((V)("build"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", GetIdx(Arr(((V)(44D)), ((V)(50D)), ((V)(64D)), ((V)(70D)), ((V)(64D))), (ToNum(t_749) - 1D))).V).V;
tower_752 = Fn((V _arrowThis765, int _argc753, V o_759, V x_760, V z_761, V r_762, V[] _rest754) => {
V h_763 = default;
V cap_764 = default;
h_763 = (_argc753 > 4 ? _rest754[0] : V.Undef);
cap_764 = (_argc753 > 5 ? _rest754[1] : V.Undef);
Invoke(o_759, "push", Call(cyl_14, V.Undef, x_760, ((V)(0D)), z_761, r_762, h_763, sc_750, (SEqN(t_749, 5D) ? Call(em_46, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.08))), Arr(h_763, ((V)(0D)), ((V)(0.94))))).V) : Call(pt_31, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.1))), Arr(((V)((ToNum(h_763) * 0.6))), ((V)(0D)), ((V)(1D))), Arr(h_763, ((V)(0D)), ((V)(0.96))))).V))));
if (SEqS(cap_764, "dome")) {
Invoke(o_759, "push", Call(ball_15, V.Undef, x_760, h_763, z_761, ((V)((ToNum(r_762) * 0.95))), ((V)((SEqN(t_749, 4D) ? "#ffb3a0" : "#ffd6f0"))), Call(cer_30, V.Undef, NewObj(3).Put("sy", ((V)(1.1))).Put("k", ((V)(4D))).Put("shine", ((V)(1D))).V)));
} else {
if (SEqS(cap_764, "spire")) {
Invoke(o_759, "push", Call(cyl_14, V.Undef, x_760, h_763, z_761, ((V)((ToNum(r_762) * 0.9))), ((V)((ToNum(r_762) * 2.2))), ((V)("#bfeefa")), Call(em_46, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)((ToNum(r_762) * 2.2))), ((V)(0D)), ((V)(0.05))))).V)));
} else {
Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis773, int _argc766, V i_772, V _a769, V _a770, V _a771, V[] _rest767) => {
double a_774 = 0;
a_774 = (((ToNum(i_772) / 6D) * 2D) * PI_43);
Invoke(o_759, "push", Call(box_12, V.Undef, Add(x_760, ((V)(((FdLibm.Cos(a_774) * ToNum(r_762)) * 0.78)))), h_763, Add(z_761, ((V)(((FdLibm.Sin(a_774) * ToNum(r_762)) * 0.78)))), ((V)((ToNum(r_762) * 0.5))), ((V)(4D)), ((V)((ToNum(r_762) * 0.5))), sc_750, Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V)));
return default;
}, 1, "", true));
}
}
return default;
}, 6, "", true);
Set(D_751, "build", Fn((V _arrowThis782, int _argc775, V P_781, V _a778, V _a779, V _a780, V[] _rest776) => {
V o_783 = default;
o_783 = Arr();
if (SEqN(t_749, 1D)) {
Invoke(o_783, "push", Call(cyl_14, V.Undef, ((V)((-6D))), ((V)(0D)), ((V)(0D)), ((V)(20D)), ((V)(16D)), SAND_49, Call(pt_31, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.2))), Arr(((V)(10D)), ((V)(0D)), ((V)(0.92))), Arr(((V)(16D)), ((V)(0D)), ((V)(0.6))))).V)), Call(cyl_14, V.Undef, ((V)(18D)), ((V)(0D)), ((V)(10D)), ((V)(8D)), ((V)(12D)), SAND_49, Call(pt_31, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(12D)), ((V)(0D)), ((V)(0.8))))).V)), Call(cyl_14, V.Undef, ((V)((-26D))), ((V)(0D)), ((V)(18D)), ((V)(7D)), ((V)(12D)), ((V)("#e2554a")), Call(pt_31, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(12D)), ((V)(0D)), ((V)(1D))))).V)));
} else {
if (SEqN(t_749, 2D)) {
Invoke(o_783, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(52D)), ((V)(14D)), ((V)(34D)), SAND_49, Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Call(tower_752, V.Undef, o_783, ((V)((-24D))), ((V)(0D)), ((V)(9D)), ((V)(26D)));
Call(tower_752, V.Undef, o_783, ((V)(24D)), ((V)(0D)), ((V)(9D)), ((V)(26D)));
Call(tower_752, V.Undef, o_783, ((V)(0D)), ((V)((-6D))), ((V)(11D)), ((V)(34D)));
Invoke(o_783, "push", Call(cyl_14, V.Undef, ((V)(36D)), ((V)(0D)), ((V)(24D)), ((V)(7D)), ((V)(13D)), ((V)("#4fb0f0")), Call(pt_31, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(13D)), ((V)(0D)), ((V)(1D))))).V)));
} else {
if (SEqN(t_749, 3D)) {
Invoke(o_783, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-6D))), ((V)(64D)), ((V)(18D)), ((V)(44D)), SAND_49, Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Call(tower_752, V.Undef, o_783, ((V)((-32D))), ((V)((-6D))), ((V)(11D)), ((V)(30D)));
Call(tower_752, V.Undef, o_783, ((V)(32D)), ((V)((-6D))), ((V)(11D)), ((V)(30D)));
Call(tower_752, V.Undef, o_783, ((V)(0D)), ((V)((-14D))), ((V)(13D)), ((V)(44D)));
Call(tower_752, V.Undef, o_783, ((V)(0D)), ((V)(14D)), ((V)(8D)), ((V)(22D)));
} else {
if (SEqN(t_749, 4D)) {
Invoke(o_783, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-6D))), ((V)(86D)), ((V)(20D)), ((V)(54D)), SAND_49, Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(20D)), ((V)((-10D))), ((V)(50D)), ((V)(14D)), ((V)(30D)), SAND_49, Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
Call(tower_752, V.Undef, o_783, ((V)((-42D))), ((V)((-6D))), ((V)(12D)), ((V)(36D)), ((V)("dome")));
Call(tower_752, V.Undef, o_783, ((V)(42D)), ((V)((-6D))), ((V)(12D)), ((V)(36D)), ((V)("dome")));
Call(tower_752, V.Undef, o_783, ((V)(0D)), ((V)((-12D))), ((V)(15D)), ((V)(52D)), ((V)("dome")));
Call(tower_752, V.Undef, o_783, ((V)((-22D))), ((V)(18D)), ((V)(8D)), ((V)(26D)));
Call(tower_752, V.Undef, o_783, ((V)(22D)), ((V)(18D)), ((V)(8D)), ((V)(26D)));
} else {
Invoke(o_783, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-4D))), ((V)(70D)), ((V)(16D)), ((V)(46D)), ((V)("#e8f6fb")), Call(em_46, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)));
Call(tower_752, V.Undef, o_783, ((V)((-34D))), ((V)((-4D))), ((V)(10D)), ((V)(40D)), ((V)("spire")));
Call(tower_752, V.Undef, o_783, ((V)(34D)), ((V)((-4D))), ((V)(10D)), ((V)(40D)), ((V)("spire")));
Call(tower_752, V.Undef, o_783, ((V)(0D)), ((V)((-10D))), ((V)(13D)), ((V)(58D)), ((V)("spire")));
Call(tower_752, V.Undef, o_783, ((V)((-16D))), ((V)(16D)), ((V)(7D)), ((V)(26D)), ((V)("spire")));
Call(tower_752, V.Undef, o_783, ((V)(16D)), ((V)(16D)), ((V)(7D)), ((V)(26D)), ((V)("spire")));
}
}
}
}
return o_783;
return default;
}, 1, "", true));
Set(D_751, "fx", Fn((V _arrowThis791, int _argc784, V c_790, V _a787, V _a788, V _a789, V[] _rest785) => {
V p_792 = default;
V k_793 = default;
JsStrBuf f_794 = null;
JsStrBuf u_795 = null;
JsStrBuf defs_796 = null;
p_792 = Get(c_790, "p");
k_793 = Get(c_790, "k");
f_794 = new JsStrBuf("");
u_795 = new JsStrBuf("");
defs_796 = new JsStrBuf("");
if (GeN(t_749, 3D)) {
V W_797 = default;
V W2_798 = default;
W_797 = Call(water_35, V.Undef, p_792, NewObj(5).Put("sh", NewObj(2).Put("rx", ((V)((SEqN(t_749, 3D) ? 52D : 66D)))).Put("rz", ((V)((SEqN(t_749, 3D) ? 40D : 46D)))).V).Put("y", ((V)(0.3))).Put("pal", Get(WP_36, "kid")).Put("gl", ((V)(3D))).Put("wave", ((V)(0.3))).V);
defs_796.V(Get(W_797, "defs"));
u_795.V(Get(W_797, "svg"));
W2_798 = ((V)(string.Concat("<g transform=\"", ToStr(Call(planeH_26, V.Undef, p_792, ((V)(0.5)))), "\"><ellipse cx=\"0\" cy=\"-4\" rx=\"", NumStr((SEqN(t_749, 3D) ? 40D : 52D)), "\" ry=\"", NumStr((SEqN(t_749, 3D) ? 30D : 36D)), "\" fill=\"", ToStr(SAND_49), "\"/></g>")));
u_795.V(W2_798);
}
if ((GeN(t_749, 2D) && LeN(t_749, 4D))) {
V top_799 = default;
V q0_800 = default;
V q1_801 = default;
top_799 = (SEqN(t_749, 2D) ? Arr(((V)(0D)), ((V)((34D + 4D))), ((V)((-6D)))) : (SEqN(t_749, 3D) ? Arr(((V)(0D)), ((V)(48D)), ((V)((-14D)))) : Arr(((V)(0D)), ((V)(64D)), ((V)((-12D))))));
q0_800 = CallSpread(p_792, V.Undef, new ArrBuilder().Spread(top_799).V);
q1_801 = Call(p_792, V.Undef, GetIdx(top_799, 0D), Add(GetIdx(top_799, 1D), ((V)(16D))), GetIdx(top_799, 2D));
f_794.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, q0_800)), "L", ToStr(Call(P2_25, V.Undef, q1_801))))), ((V)("none")), ((V)("#8a6a48")), ((V)(1.2)))).S(string.Concat("<g>", ToStr(Call(AT_53, V.Undef, ((V)("skewY")), ((V)("-8;8;-8")), ((V)(1.6)))), "<path d=\"M", ToStr(Call(P2_25, V.Undef, q1_801)), "l", ToStr(Call(f1_21, V.Undef, ((V)((11D * ToNum(k_793)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((3D * ToNum(k_793)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)(((-11D) * ToNum(k_793)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((4D * ToNum(k_793)))))), "Z\" fill=\"", (SEqN(t_749, 4D) ? "#3f7fc8" : "#e2554a"), "\" stroke=\"#5a2a20\" stroke-width=\"0.6\"/></g>"));
}
if (SEqN(t_749, 4D)) {
Call(rep_22, V.Undef, ((V)(18D)), Fn((V _arrowThis809, int _argc802, V i_808, V _a805, V _a806, V _a807, V[] _rest803) => {
double a_810 = 0;
V q_811 = default;
a_810 = (((ToNum(i_808) / 18D) * 2D) * PI_43);
q_811 = Call(p_792, V.Undef, ((V)((FdLibm.Cos(a_810) * 40D))), ((V)(10D)), ((V)(((-6D) + (FdLibm.Sin(a_810) * 26D)))));
if ((FdLibm.Sin(a_810) < (-0.2))) {
return default;
}
f_794.S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_811, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_811, 1D))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((1.6 * ToNum(k_793)))))), "\" fill=\"", ToStr(GetIdx(Arr(((V)("#ffb3a0")), ((V)("#fff1d8")), ((V)("#9fe0e0"))), (ToNum(i_808) % 3D))), "\" stroke=\"#a8784a\" stroke-width=\"0.4\"/>"));
return default;
}, 1, "", true));
}
if (SEqN(t_749, 5D)) {
defs_796.V(GLW_63);
Invoke(Arr(Arr(((V)((-34D))), ((V)(22D)), ((V)(6D))), Arr(((V)(34D)), ((V)(22D)), ((V)(6D))), Arr(((V)(0D)), ((V)(30D)), ((V)((-2D)))), Arr(((V)(0D)), ((V)(44D)), ((V)(2D))), Arr(((V)((-16D))), ((V)(14D)), ((V)(23D))), Arr(((V)(16D)), ((V)(14D)), ((V)(23D)))), "forEach", Fn((V _arrowThis826, int _argc812, V _a814, V i_818, V _a816, V _a817, V[] _rest813) => {
V q_827 = default;
V x_821 = default;
V y_823 = default;
V z_825 = default;
{ V _t819 = ListOf(_a814);
{ V _t820 = GetIdx(_t819, 0D);
x_821 = _t820; }
{ V _t822 = GetIdx(_t819, 1D);
y_823 = _t822; }
{ V _t824 = GetIdx(_t819, 2D);
z_825 = _t824; }
}
q_827 = Call(p_792, V.Undef, x_821, y_823, z_825);
f_794.S(string.Concat("<rect x=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_827, 0D)) - (1.6 * ToNum(k_793))))))), "\" y=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_827, 1D)) - (3D * ToNum(k_793))))))), "\" width=\"", ToStr(Call(f1_21, V.Undef, ((V)((3.2 * ToNum(k_793)))))), "\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)((5D * ToNum(k_793)))))), "\" rx=\"", ToStr(Call(f1_21, V.Undef, ((V)((1.4 * ToNum(k_793)))))), "\" fill=\"#fff2a0\">", ToStr(Call(AN_54, V.Undef, ((V)("opacity")), ((V)("1;0.5;1")), ((V)((1.6 + (ToNum(i_818) * 0.3)))))), "</rect>"));
return default;
}, 2, "", true));
f_794.V(Call(glowAt_64, V.Undef, Call(p_792, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D))), ((V)((46D * ToNum(k_793)))), ((V)("bhC")), ((V)(0.5))));
}
if (SEqN(t_749, 2D)) {
f_794.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, Call(p_792, V.Undef, ((V)(30D)), ((V)(0.4)), ((V)(30D))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((9D * ToNum(k_793)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)(((-4D) * ToNum(k_793))))))))), ((V)("none")), ((V)("#c4651f")), ((V)(1.6))));
}
return NewObj(4).Put("defs", ((V)(defs_796.Str))).Put("under", ((V)(u_795.Str))).Put("front", ((V)(f_794.Str))).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_792, V.Undef, ((V)((-70D))), ((V)(0D)), ((V)((-50D)))), Call(p_792, V.Undef, ((V)(70D)), ((V)(0D)), ((V)(50D))), Call(p_792, V.Undef, ((V)((-70D))), ((V)(0D)), ((V)(50D))), Call(p_792, V.Undef, ((V)(70D)), ((V)(0D)), ((V)((-50D)))), Call(p_792, V.Undef, ((V)(0D)), ((V)((SEqN(t_749, 5D) ? 90D : 76D))), ((V)((-12D))))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_751;
return default;
}, 1, "", true));
BOARD_66 = Fn((V _arrowThis842, int _argc828, V o_834, V x_835, V z_836, V w_837, V[] _rest829) => {
V h_838 = default;
V c_839 = default;
V stripe_840 = default;
V yaw_841 = default;
h_838 = (_argc828 > 4 ? _rest829[0] : V.Undef);
c_839 = (_argc828 > 5 ? _rest829[1] : V.Undef);
stripe_840 = (_argc828 > 6 ? _rest829[2] : V.Undef);
yaw_841 = (_argc828 > 7 ? _rest829[3] : V.Undef);
Invoke(o_834, "push", Call(slab_16, V.Undef, x_835, ((V)(0D)), z_836, w_837, h_838, ((V)(3.6)), c_839, Call(cer_30, V.Undef, NewObj(3).Put("r", ((V)(((ToNum(w_837) / 2D) - 0.5)))).Put("shine", ((V)(1D))).Put("yaw", (yaw_841 is var _t843 && Truthy(_t843) ? _t843 : ((V)(0D)))).V)));
if (Truthy(stripe_840)) {
Invoke(o_834, "push", Call(slab_16, V.Undef, x_835, ((V)((ToNum(h_838) * 0.1))), Add(z_836, ((V)(1.9))), ((V)(2.6)), ((V)((ToNum(h_838) * 0.8))), ((V)(0.4)), stripe_840, Call(cer_30, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("yaw", (yaw_841 is var _t844 && Truthy(_t844) ? _t844 : ((V)(0D)))).V)));
}
return default;
}, 8, "", true);
Set(N_42, "bSurf", Fn((V _arrowThis852, int _argc845, V S_851, V _a848, V _a849, V _a850, V[] _rest846) => {
V t_853 = default;
V D_854 = default;
t_853 = Call(T_48, V.Undef, S_851);
D_854 = NewObj(4).Put("w", ((V)(110D))).Put("d", ((V)(60D))).Put("act", ((V)("surf"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(46D))).V).V;
Set(D_854, "build", Fn((V _arrowThis862, int _argc855, V P_861, V _a858, V _a859, V _a860, V[] _rest856) => {
V o_863 = default;
o_863 = Arr();
if (SEqN(t_853, 1D)) {
Invoke(o_863, "push", Call(cyl_14, V.Undef, ((V)((-14D))), ((V)(0D)), ((V)((-6D))), ((V)(4D)), ((V)(54D)), ((V)("#a8977c")), Call(wd_29, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(54D)), ((V)(0D)), ((V)(0.8))))).V)));
Call(BOARD_66, V.Undef, o_863, ((V)(6D)), ((V)((-2D))), ((V)(26D)), ((V)(44D)), ((V)("#5ab0e0")), ((V)("#ffffff")), ((V)(0.2)));
} else {
if (SEqN(t_853, 2D)) {
Invoke(Arr(((V)((-24D))), ((V)(24D))), "forEach", Fn((V _arrowThis871, int _argc864, V x_870, V _a867, V _a868, V _a869, V[] _rest865) => {
return Invoke(o_863, "push", Call(box_12, V.Undef, x_870, ((V)(0D)), ((V)((-10D))), ((V)(4D)), ((V)(70D)), ((V)(4D)), ((V)("#b8804a")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, x_870, ((V)(0D)), ((V)(6D)), ((V)(4D)), ((V)(18D)), ((V)(4D)), ((V)("#b8804a")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)));
}, 1, "", true));
Invoke(o_863, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(66D)), ((V)((-10D))), ((V)(58D)), ((V)(4D)), ((V)(5D)), ((V)("#c48a52")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Call(BOARD_66, V.Undef, o_863, ((V)(0D)), ((V)((-4D))), ((V)(24D)), ((V)(96D)), ((V)("#ffe066")), ((V)("#e2554a")));
} else {
if (SEqN(t_853, 3D)) {
Invoke(Arr(((V)((-46D))), ((V)(46D))), "forEach", Fn((V _arrowThis879, int _argc872, V x_878, V _a875, V _a876, V _a877, V[] _rest873) => {
return Invoke(o_863, "push", Call(box_12, V.Undef, x_878, ((V)(0D)), ((V)((-12D))), ((V)(5D)), ((V)(76D)), ((V)(5D)), ((V)("#3e4046")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
Invoke(o_863, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(72D)), ((V)((-12D))), ((V)(98D)), ((V)(5D)), ((V)(6D)), ((V)("#3e4046")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Call(BOARD_66, V.Undef, o_863, ((V)((-20D))), ((V)((-6D))), ((V)(22D)), ((V)(88D)), ((V)("#ffffff")), ((V)("#2f9fb8")));
Call(BOARD_66, V.Undef, o_863, ((V)(18D)), ((V)((-6D))), ((V)(22D)), ((V)(80D)), ((V)("#ff8a5a")), ((V)("#ffffff")));
Invoke(o_863, "push", Call(slab_16, V.Undef, ((V)(40D)), ((V)(34D)), ((V)((-8D))), ((V)(14D)), ((V)(34D)), ((V)(3D)), ((V)("#2c2d31")), Call(fb_47, V.Undef, NewObj(1).Put("r", ((V)(5D))).V)));
} else {
if (SEqN(t_853, 4D)) {
Invoke(Arr(((V)((-50D))), ((V)(50D))), "forEach", Fn((V _arrowThis887, int _argc880, V x_886, V _a883, V _a884, V _a885, V[] _rest881) => {
return Invoke(o_863, "push", Call(cyl_14, V.Undef, x_886, ((V)(0D)), ((V)((-14D))), ((V)(3.4)), ((V)(86D)), ((V)("#8a5a2c")), Call(wd_29, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
}, 1, "", true));
Invoke(o_863, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(82D)), ((V)((-14D))), ((V)(108D)), ((V)(4D)), ((V)(6D)), ((V)("#8a5a2c")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
Call(BOARD_66, V.Undef, o_863, ((V)((-28D))), ((V)((-8D))), ((V)(20D)), ((V)(84D)), ((V)("#ffd6c8")), ((V)("#e2554a")));
Call(BOARD_66, V.Undef, o_863, ((V)(0D)), ((V)((-8D))), ((V)(22D)), ((V)(92D)), ((V)("#9fe0e0")), ((V)("#ffffff")));
Call(BOARD_66, V.Undef, o_863, ((V)(28D)), ((V)((-8D))), ((V)(20D)), ((V)(80D)), ((V)("#ffe066")), ((V)("#3fa04a")));
} else {
Invoke(o_863, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(6D)), ((V)("#2a3a5a")), Call(mt_28, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(26D)), ((V)(1.4)), ((V)("#7af6ff")), Call(em_46, V.Undef, NewObj(1).Put("n", ((V)(24D))).V)));
}
}
}
}
return o_863;
return default;
}, 1, "", true));
if (SEqN(t_853, 5D)) {
Set(D_854, "layers", Arr(NewObj(2).Put("build", Fn((V _arrowThis895, int _argc888, V P_894, V _a891, V _a892, V _a893, V[] _rest889) => {
return Arr(Call(box_12, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(0D)), ((V)(96D)), ((V)(4D)), ((V)(26D)), ((V)("#ffffff")), Call(cer_30, V.Undef, NewObj(2).Put("r", ((V)(12D))).Put("shine", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(0D)), ((V)(70D)), ((V)(0.6)), ((V)(3D)), ((V)("#4fe0f0")), Call(em_46, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "build", true)).Put("wrap", Fn((V _arrowThis904, int _argc896, V p_902, V s_903, V _a900, V _a901, V[] _rest897) => {
return ((V)(string.Concat("<g>", ToStr(Call(AT_53, V.Undef, ((V)("translate")), ((V)("0 0;0 -4;0 0")), ((V)(2.4)))), ToStr(s_903), "</g>")));
}, 2, "wrap", true)).V));
}
Set(D_854, "fx", Fn((V _arrowThis912, int _argc905, V c_911, V _a908, V _a909, V _a910, V[] _rest906) => {
V p_913 = default;
V k_914 = default;
JsStrBuf f_915 = null;
V defs_916 = default;
p_913 = Get(c_911, "p");
k_914 = Get(c_911, "k");
f_915 = new JsStrBuf("");
defs_916 = ((V)(""));
if (SEqN(t_853, 4D)) {
f_915.V(Call(cone_57, V.Undef, p_913, k_914, NewObj(10).Put("y", ((V)(86D))).Put("h", ((V)(14D))).Put("R", ((V)(64D))).Put("n", ((V)(4D))).Put("a0", ((V)((PI_43 / 4D)))).Put("cols", Arr(((V)("#d8b46a")), ((V)("#c9a45a")))).Put("fringe", ((V)("#b8924a"))).Put("z", ((V)((-14D)))).Put("droop", ((V)(0D))).Put("fl", ((V)(8D))).V));
Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis924, int _argc917, V i_923, V _a920, V _a921, V _a922, V[] _rest918) => {
V q_925 = default;
q_925 = Call(p_913, V.Undef, ((V)(((-28D) + (ToNum(i_923) * 28D)))), ((V)(50D)), ((V)((-5D))));
f_915.V(Invoke(Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis933, int _argc926, V j_932, V _a929, V _a930, V _a931, V[] _rest927) => {
return ((V)(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, Add(GetIdx(q_925, 0D), ((V)(((FdLibm.Cos((ToNum(j_932) * 1.256)) * 3.2) * ToNum(k_914))))))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, Add(GetIdx(q_925, 1D), ((V)(((FdLibm.Sin((ToNum(j_932) * 1.256)) * 3.2) * ToNum(k_914))))))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((2.2 * ToNum(k_914)))))), "\" fill=\"#ff6a8a\"/>")));
}, 1, "", true)), "join", ((V)("")))).S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_925, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_925, 1D))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((1.4 * ToNum(k_914)))))), "\" fill=\"#ffe066\"/>"));
return default;
}, 1, "", true));
}
if (SEqN(t_853, 5D)) {
defs_916 = GLW_63;
f_915.V(Add(Call(glowAt_64, V.Undef, Call(p_913, V.Undef, ((V)(0D)), ((V)(8D)), ((V)(0D))), ((V)((44D * ToNum(k_914)))), ((V)("bhC")), ((V)(0.7))), Invoke(Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis941, int _argc934, V i_940, V _a937, V _a938, V _a939, V[] _rest935) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_21, V.Undef, ((V)((1.4 * ToNum(k_914)))))), "\" fill=\"#bffcff\"><animateMotion dur=\"", NumStr((2D + (ToNum(i_940) * 0.4))), "s\" begin=\"", NumStr(((-ToNum(i_940)) * 0.5)), "s\" repeatCount=\"indefinite\" path=\"M", ToStr(Call(P2_25, V.Undef, Call(p_913, V.Undef, ((V)(((-30D) + (ToNum(i_940) * 20D)))), ((V)(8D)), ((V)(0D))))), "L", ToStr(Call(P2_25, V.Undef, Call(p_913, V.Undef, ((V)(((-30D) + (ToNum(i_940) * 20D)))), ((V)(22D)), ((V)(0D))))), "\"/>", ToStr(Call(AN_54, V.Undef, ((V)("opacity")), ((V)("1;0")), ((V)((2D + (ToNum(i_940) * 0.4)))), ((V)(((-ToNum(i_940)) * 0.5))))), "</circle>")));
}, 1, "", true)), "join", ((V)("")))));
}
if (SEqN(t_853, 1D)) {
f_915.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, Call(p_913, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((5D * ToNum(k_914)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((6D * ToNum(k_914)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)(((-2D) * ToNum(k_914)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((5D * ToNum(k_914))))))))), ((V)("none")), ((V)("#2a5a7a")), ((V)(0.8))));
}
return NewObj(3).Put("defs", defs_916).Put("front", ((V)(f_915.Str))).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_913, V.Undef, ((V)((-66D))), ((V)(0D)), ((V)((-30D)))), Call(p_913, V.Undef, ((V)(66D)), ((V)(0D)), ((V)(30D))), Call(p_913, V.Undef, ((V)(0D)), ((V)(110D)), ((V)((-14D)))), Call(p_913, V.Undef, ((V)((-60D))), ((V)(90D)), ((V)((-14D)))), Call(p_913, V.Undef, ((V)(60D)), ((V)(90D)), ((V)((-14D))))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_854;
return default;
}, 1, "", true));
Set(N_42, "bVolley", Fn((V _arrowThis949, int _argc942, V S_948, V _a945, V _a946, V _a947, V[] _rest943) => {
V t_950 = default;
V pl_951 = default;
V D_952 = default;
t_950 = Call(T_48, V.Undef, S_948);
pl_951 = Call(isPlay_40, V.Undef, S_948);
D_952 = NewObj(2).Put("w", ((V)(170D))).Put("d", ((V)(100D))).V;
Set(D_952, "build", Fn((V _arrowThis960, int _argc953, V P_959, V _a956, V _a957, V _a958, V[] _rest954) => {
V o_961 = default;
V pc_962 = default;
double H_963 = 0;
o_961 = Arr();
pc_962 = GetIdx(Arr(((V)("#a8977c")), ((V)("#ffffff")), ((V)("#3f7fc8")), ((V)("#e2554a")), ((V)("#2a2a40"))), (ToNum(t_950) - 1D));
H_963 = (SEqN(t_950, 1D) ? 40D : 48D);
Invoke(Arr(((V)((-72D))), ((V)(72D))), "forEach", Fn((V _arrowThis972, int _argc964, V x_970, V i_971, V _a968, V _a969, V[] _rest965) => {
return Invoke(o_961, "push", Call(cyl_14, V.Undef, x_970, ((V)(0D)), ((V)(0D)), ((V)((SEqN(t_950, 1D) ? 2.4 : 3D))), ((V)((H_963 + (SEqN(t_950, 1D) ? (Truthy(i_971) ? (-4D) : 2D) : 4D)))), pc_962, (SEqN(t_950, 1D) ? Call(wd_29, V.Undef, NewObj(1).Put("n", ((V)(8D))).V) : Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(10D))).V))));
}, 2, "", true));
if (SEqN(t_950, 4D)) {
Invoke(o_961, "push", Call(box_12, V.Undef, ((V)((-90D))), ((V)(0D)), ((V)((-30D))), ((V)(6D)), ((V)(50D)), ((V)(6D)), ((V)("#3a3d44")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(slab_16, V.Undef, ((V)((-90D))), ((V)(50D)), ((V)((-30D))), ((V)(40D)), ((V)(20D)), ((V)(3D)), ((V)("#1c1f3a")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)));
}
if (!(Truthy(pl_951))) {
Invoke(o_961, "push", Call(ball_15, V.Undef, ((V)(30D)), ((V)(7D)), ((V)(26D)), ((V)(7D)), ((V)((SEqN(t_950, 5D) ? "#bffcff" : "#ffffff"))), (SEqN(t_950, 5D) ? Call(em_46, V.Undef, NewObj(1).Put("k", ((V)(5D))).V) : Call(cer_30, V.Undef, NewObj(2).Put("k", ((V)(5D))).Put("shine", ((V)(1D))).V))));
}
return o_961;
return default;
}, 1, "", true));
Set(D_952, "fx", Fn((V _arrowThis980, int _argc973, V c_979, V _a976, V _a977, V _a978, V[] _rest974) => {
V p_981 = default;
V k_982 = default;
double H_983 = 0;
double top_984 = 0;
JsStrBuf f_985 = null;
JsStrBuf u_986 = null;
V defs_987 = default;
V nT_988 = default;
V nB_989 = default;
V pth_990 = default;
JsStrBuf mesh_991 = null;
p_981 = Get(c_979, "p");
k_982 = Get(c_979, "k");
H_983 = (SEqN(t_950, 1D) ? 40D : 48D);
top_984 = (SEqN(t_950, 1D) ? 6D : 0D);
f_985 = new JsStrBuf("");
u_986 = new JsStrBuf("");
defs_987 = GLW_63;
if (GeN(t_950, 2D)) {
u_986.S(string.Concat("<g transform=\"", ToStr(Call(planeH_26, V.Undef, p_981, ((V)(0.4)))), "\"><rect x=\"-80\" y=\"-44\" width=\"160\" height=\"88\" fill=\"none\" stroke=\"", (SEqN(t_950, 5D) ? "#7af6ff" : "#ffffff"), "\" stroke-width=\"2.2\" opacity=\"0.85\"/><path d=\"M0 -44V44\" stroke=\"", (SEqN(t_950, 5D) ? "#7af6ff" : "#ffffff"), "\" stroke-width=\"1.6\" opacity=\"0.6\"/></g>"));
}
nT_988 = Arr(Arr(((V)((-70D))), ((V)((H_983 - 2D)))), Arr(((V)((-35D))), ((V)(((H_983 - 2D) - (top_984 * 0.7))))), Arr(((V)(0D)), ((V)(((H_983 - 2D) - top_984)))), Arr(((V)(35D)), ((V)(((H_983 - 2D) - (top_984 * 0.7))))), Arr(((V)(70D)), ((V)((H_983 - 2D)))));
nB_989 = Invoke(nT_988, "map", Fn((V _arrowThis1003, int _argc992, V _a994, V _a995, V _a996, V _a997, V[] _rest993) => {
V x_1000 = default;
V y_1002 = default;
{ V _t998 = ListOf(_a994);
{ V _t999 = GetIdx(_t998, 0D);
x_1000 = _t999; }
{ V _t1001 = GetIdx(_t998, 1D);
y_1002 = _t1001; }
}
return Arr(x_1000, ((V)((ToNum(y_1002) - 18D))));
}, 1, "", true));
pth_990 = Fn((V _arrowThis1012, int _argc1004, V A_1010, V B_1011, V _a1008, V _a1009, V[] _rest1005) => {
return ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(A_1010, "map", Fn((V _arrowThis1024, int _argc1013, V _a1015, V _a1016, V _a1017, V _a1018, V[] _rest1014) => {
V x_1021 = default;
V y_1023 = default;
{ V _t1019 = ListOf(_a1015);
{ V _t1020 = GetIdx(_t1019, 0D);
x_1021 = _t1020; }
{ V _t1022 = GetIdx(_t1019, 1D);
y_1023 = _t1022; }
}
return Call(P2_25, V.Undef, Call(p_981, V.Undef, x_1021, y_1023, ((V)(0D))));
}, 1, "", true)), "join", ((V)("L")))).S("L").V(Invoke(Invoke(Invoke(Invoke(B_1011, "slice"), "reverse"), "map", Fn((V _arrowThis1036, int _argc1025, V _a1027, V _a1028, V _a1029, V _a1030, V[] _rest1026) => {
V x_1033 = default;
V y_1035 = default;
{ V _t1031 = ListOf(_a1027);
{ V _t1032 = GetIdx(_t1031, 0D);
x_1033 = _t1032; }
{ V _t1034 = GetIdx(_t1031, 1D);
y_1035 = _t1034; }
}
return Call(P2_25, V.Undef, Call(p_981, V.Undef, x_1033, y_1035, ((V)(0D))));
}, 1, "", true)), "join", ((V)("L")))).S("Z").End()));
}, 2, "", true);
mesh_991 = new JsStrBuf("");
Call(rep_22, V.Undef, ((V)(15D)), Fn((V _arrowThis1044, int _argc1037, V i_1043, V _a1040, V _a1041, V _a1042, V[] _rest1038) => {
double x_1045 = 0;
double yt_1046 = 0;
x_1045 = ((-70D) + (ToNum(i_1043) * 10D));
yt_1046 = ((H_983 - 2D) - (top_984 * FdLibm.Sin((((x_1045 + 70D) / 140D) * PI_43))));
mesh_991.S(string.Concat("M", ToStr(Call(P2_25, V.Undef, Call(p_981, V.Undef, ((V)(x_1045)), ((V)(yt_1046)), ((V)(0D))))), "L", ToStr(Call(P2_25, V.Undef, Call(p_981, V.Undef, ((V)(x_1045)), ((V)((yt_1046 - 18D))), ((V)(0D)))))));
return default;
}, 1, "", true));
Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis1054, int _argc1047, V j_1053, V _a1050, V _a1051, V _a1052, V[] _rest1048) => {
mesh_991.S("M").V(Invoke(Call(rep_22, V.Undef, ((V)(15D)), Fn((V _arrowThis1062, int _argc1055, V i_1061, V _a1058, V _a1059, V _a1060, V[] _rest1056) => {
double x_1063 = 0;
double yt_1064 = 0;
x_1063 = ((-70D) + (ToNum(i_1061) * 10D));
yt_1064 = ((H_983 - 2D) - (top_984 * FdLibm.Sin((((x_1063 + 70D) / 140D) * PI_43))));
return Call(P2_25, V.Undef, Call(p_981, V.Undef, ((V)(x_1063)), ((V)((yt_1064 - (4.5 * ToNum(Add(j_1053, ((V)(0.5)))))))), ((V)(0D))));
return default;
}, 1, "", true)), "join", ((V)("L"))));
return default;
}, 1, "", true));
f_985.V(Add(Add(Add(Call(PP_51, V.Undef, Call(pth_990, V.Undef, nT_988, nB_989), ((V)((SEqN(t_950, 1D) ? "#c9b896" : "#ffffff"))), ((V)("")), ((V)(0D)), ((V)(" opacity=\"0.18\""))), Call(PP_51, V.Undef, ((V)(mesh_991.Str)), ((V)("none")), ((V)((SEqN(t_950, 1D) ? "#8a7a5c" : (SEqN(t_950, 5D) ? "#7af6ff" : "#2a2a30")))), ((V)(0.6)), ((V)(" opacity=\"0.7\"")))), Call(PP_51, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(nT_988, "map", Fn((V _arrowThis1076, int _argc1065, V _a1067, V _a1068, V _a1069, V _a1070, V[] _rest1066) => {
V x_1073 = default;
V y_1075 = default;
{ V _t1071 = ListOf(_a1067);
{ V _t1072 = GetIdx(_t1071, 0D);
x_1073 = _t1072; }
{ V _t1074 = GetIdx(_t1071, 1D);
y_1075 = _t1074; }
}
return Call(P2_25, V.Undef, Call(p_981, V.Undef, x_1073, y_1075, ((V)(0D))));
}, 1, "", true)), "join", ((V)("L")))).End())), ((V)("none")), ((V)((SEqN(t_950, 5D) ? "#bffcff" : "#ffffff"))), ((V)(2.4)))), Call(PP_51, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Invoke(Invoke(nT_988, "map", Fn((V _arrowThis1088, int _argc1077, V _a1079, V _a1080, V _a1081, V _a1082, V[] _rest1078) => {
V x_1085 = default;
V y_1087 = default;
{ V _t1083 = ListOf(_a1079);
{ V _t1084 = GetIdx(_t1083, 0D);
x_1085 = _t1084; }
{ V _t1086 = GetIdx(_t1083, 1D);
y_1087 = _t1086; }
}
return Call(P2_25, V.Undef, Call(p_981, V.Undef, x_1085, y_1087, ((V)(0D))));
}, 1, "", true)), "join", ((V)("L")))).End())), ((V)("none")), ((V)((SEqN(t_950, 5D) ? "#4fe0f0" : "#2a2a30"))), ((V)(0.8)))));
if (GeN(t_950, 3D)) {
Invoke(Arr(((V)((-72D))), ((V)(72D))), "forEach", Fn((V _arrowThis1097, int _argc1089, V x_1095, V i_1096, V _a1093, V _a1094, V[] _rest1090) => {
V q_1098 = default;
q_1098 = Call(p_981, V.Undef, x_1095, ((V)((H_983 + 4D))), ((V)(0D)));
f_985.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, q_1098)), "l0 ", ToStr(Call(f1_21, V.Undef, ((V)(((-14D) * ToNum(k_982))))))))), ((V)("none")), ((V)("#2a2a30")), ((V)(1D)))).S(string.Concat("<g>", ToStr(Call(AT_53, V.Undef, ((V)("skewY")), ((V)("-10;10;-10")), ((V)(1.4)), ((V)(((-ToNum(i_1096)) * 0.4))))), "<path d=\"M", ToStr(Call(f1_21, V.Undef, GetIdx(q_1098, 0D))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1098, 1D)) - (14D * ToNum(k_982))))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((12D * ToNum(k_982)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((3D * ToNum(k_982)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)(((-12D) * ToNum(k_982)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((4D * ToNum(k_982)))))), "Z\" fill=\"", (Truthy(i_1096) ? "#ffd23f" : "#e2554a"), "\"/></g>"));
return default;
}, 2, "", true));
}
if (SEqN(t_950, 4D)) {
V q_1099 = default;
q_1099 = Call(p_981, V.Undef, ((V)((-90D))), ((V)(60D)), ((V)((-28D))));
f_985.S(string.Concat("<text x=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_1099, 0D))), "\" y=\"", ToStr(Call(f1_21, V.Undef, Add(GetIdx(q_1099, 1D), ((V)(3D))))), "\" text-anchor=\"middle\" font-family=\"Fredoka, sans-serif\" font-weight=\"700\" font-size=\"", ToStr(Call(f1_21, V.Undef, ((V)((9D * ToNum(k_982)))))), "\" fill=\"#ffd23f\">", (Truthy(pl_951) ? "3-2" : "0-0"), "</text>"));
}
if (SEqN(t_950, 5D)) {
f_985.V(Call(glowAt_64, V.Undef, Call(p_981, V.Undef, ((V)(0D)), ((V)(H_983)), ((V)(0D))), ((V)((60D * ToNum(k_982)))), ((V)("bhC")), ((V)(0.35))));
}
if (Truthy(pl_951)) {
V a_1100 = default;
V b_1101 = default;
V cc_1102 = default;
a_1100 = Call(p_981, V.Undef, ((V)((-50D))), ((V)(20D)), ((V)(10D)));
b_1101 = Call(p_981, V.Undef, ((V)(0D)), ((V)((H_983 + 40D))), ((V)(0D)));
cc_1102 = Call(p_981, V.Undef, ((V)(50D)), ((V)(20D)), ((V)((-8D))));
f_985.S(string.Concat("<g><animateMotion dur=\"1.8s\" repeatCount=\"indefinite\" path=\"M", ToStr(Call(P2_25, V.Undef, a_1100)), "Q", ToStr(Call(P2_25, V.Undef, b_1101)), " ", ToStr(Call(P2_25, V.Undef, cc_1102)), "Q", ToStr(Call(P2_25, V.Undef, b_1101)), " ", ToStr(Call(P2_25, V.Undef, a_1100)), "\"/><circle r=\"", ToStr(Call(f1_21, V.Undef, ((V)((6D * ToNum(k_982)))))), "\" fill=\"", (SEqN(t_950, 5D) ? "#bffcff" : "#ffffff"), "\" stroke=\"#8a8a90\" stroke-width=\"0.8\"/><path d=\"M", ToStr(Call(f1_21, V.Undef, ((V)(((-6D) * ToNum(k_982)))))), " 0Q0 ", ToStr(Call(f1_21, V.Undef, ((V)(((-3D) * ToNum(k_982)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((6D * ToNum(k_982)))))), " 0\" stroke=\"#3fb0c8\" stroke-width=\"1.2\" fill=\"none\"/></g>"));
}
return NewObj(4).Put("defs", defs_987).Put("under", ((V)(u_986.Str))).Put("front", ((V)(f_985.Str))).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_981, V.Undef, ((V)((-96D))), ((V)(0D)), ((V)((-50D)))), Call(p_981, V.Undef, ((V)(96D)), ((V)(0D)), ((V)(50D))), Call(p_981, V.Undef, ((V)((-96D))), ((V)(0D)), ((V)(50D))), Call(p_981, V.Undef, ((V)(96D)), ((V)(0D)), ((V)((-50D)))), Call(p_981, V.Undef, ((V)(0D)), ((V)((H_983 + 50D))), ((V)(0D))), Call(p_981, V.Undef, ((V)((-90D))), ((V)(74D)), ((V)((-30D))))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_952;
return default;
}, 1, "", true));
Set(N_42, "bShack", Fn((V _arrowThis1110, int _argc1103, V S_1109, V _a1106, V _a1107, V _a1108, V[] _rest1104) => {
V t_1111 = default;
V D_1112 = default;
t_1111 = Call(T_48, V.Undef, S_1109);
D_1112 = NewObj(4).Put("w", ((V)(130D))).Put("d", ((V)(80D))).Put("act", ((V)("treat"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(56D))).V).V;
Set(D_1112, "build", Fn((V _arrowThis1120, int _argc1113, V P_1119, V _a1116, V _a1117, V _a1118, V[] _rest1114) => {
V o_1121 = default;
o_1121 = Arr();
if (SEqN(t_1111, 1D)) {
Invoke(o_1121, "push", Call(box_12, V.Undef, ((V)((-18D))), ((V)(0D)), ((V)(0D)), ((V)(40D)), ((V)(30D)), ((V)(34D)), ((V)("#c49a62")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(22D)), ((V)(0D)), ((V)(0D)), ((V)(36D)), ((V)(30D)), ((V)(34D)), ((V)("#b8894e")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(30D)), ((V)(0D)), ((V)(82D)), ((V)(3D)), ((V)(38D)), ((V)("#d8b07a")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(cyl_14, V.Undef, ((V)((-14D))), ((V)(33D)), ((V)(0D)), ((V)(7D)), ((V)(16D)), ((V)("#fff6a0")), Call(cer_30, V.Undef, NewObj(2).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).V)), Call(cyl_14, V.Undef, ((V)((-14D))), ((V)(49D)), ((V)(0D)), ((V)(7.4)), ((V)(2D)), ((V)("#f2c255")), Call(pt_31, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)), Call(slab_16, V.Undef, ((V)(18D)), ((V)(33D)), ((V)((-12D))), ((V)(34D)), ((V)(26D)), ((V)(2D)), ((V)("#fff8ea")), Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
} else {
if (SEqN(t_1111, 2D)) {
InvokeSpread(o_1121, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(92D)), ((V)(40D)), ((V)(46D)), ((V)("#fffaf1")), Call(pt_31, V.Undef, NewObj(2).Put("r", ((V)(6D))).Put("bev", ((V)(2D))).V))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(52D)), ((V)(0D)), ((V)(96D)), ((V)(4D)), ((V)(50D)), ((V)("#7fd0e0")), Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(4D))).V))).Spread(Invoke(Arr(Arr(((V)((-34D))), ((V)(24D))), Arr(((V)(34D)), ((V)(24D))), Arr(((V)((-34D))), ((V)((-24D)))), Arr(((V)(34D)), ((V)((-24D))))), "map", Fn((V _arrowThis1133, int _argc1122, V _a1124, V _a1125, V _a1126, V _a1127, V[] _rest1123) => {
V x_1130 = default;
V z_1132 = default;
{ V _t1128 = ListOf(_a1124);
{ V _t1129 = GetIdx(_t1128, 0D);
x_1130 = _t1129; }
{ V _t1131 = GetIdx(_t1128, 1D);
z_1132 = _t1131; }
}
return Call(cyl_14, V.Undef, x_1130, ((V)(0D)), z_1132, ((V)(6D)), ((V)(12D)), ((V)("#3a3d44")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(12D))).V));
}, 1, "", true))).Add(Call(cyl_14, V.Undef, ((V)(46D)), ((V)(12D)), ((V)(0D)), ((V)(1.6)), ((V)(74D)), ((V)("#9aa1a6")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(6D))).V))).V);
Invoke(Arr(Arr(((V)((-28D))), ((V)("#ffb3c8"))), Arr(((V)((-14D))), ((V)("#fff1b8"))), Arr(((V)(0D)), ((V)("#c9f0b0"))), Arr(((V)(14D)), ((V)("#cfe0ff")))), "forEach", Fn((V _arrowThis1145, int _argc1134, V _a1136, V _a1137, V _a1138, V _a1139, V[] _rest1135) => {
V x_1142 = default;
V c_1144 = default;
{ V _t1140 = ListOf(_a1136);
{ V _t1141 = GetIdx(_t1140, 0D);
x_1142 = _t1141; }
{ V _t1143 = GetIdx(_t1140, 1D);
c_1144 = _t1143; }
}
return Invoke(o_1121, "push", Call(cyl_14, V.Undef, x_1142, ((V)(56D)), ((V)(0D)), ((V)(5.4)), ((V)(6D)), c_1144, Call(fb_47, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
}, 1, "", true));
} else {
if (SEqN(t_1111, 3D)) {
InvokeSpread(o_1121, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(110D)), ((V)(34D)), ((V)(30D)), ((V)("#c48a52")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(2D))).V))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(12D)), ((V)(116D)), ((V)(4D)), ((V)(36D)), ((V)("#e8c88a")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).Spread(Invoke(Arr(Arr(((V)((-52D))), ((V)((-26D)))), Arr(((V)(52D)), ((V)((-26D)))), Arr(((V)((-52D))), ((V)(24D))), Arr(((V)(52D)), ((V)(24D)))), "map", Fn((V _arrowThis1157, int _argc1146, V _a1148, V _a1149, V _a1150, V _a1151, V[] _rest1147) => {
V x_1154 = default;
V z_1156 = default;
{ V _t1152 = ListOf(_a1148);
{ V _t1153 = GetIdx(_t1152, 0D);
x_1154 = _t1153; }
{ V _t1155 = GetIdx(_t1152, 1D);
z_1156 = _t1155; }
}
return Call(cyl_14, V.Undef, x_1154, ((V)(0D)), z_1156, ((V)(3D)), ((V)(74D)), ((V)("#8a5a2c")), Call(wd_29, V.Undef, NewObj(1).Put("n", ((V)(8D))).V));
}, 1, "", true))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-24D))), ((V)(104D)), ((V)(52D)), ((V)(6D)), ((V)("#b8804a")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).V);
Invoke(Arr(Arr(((V)((-30D))), ((V)("#ff8ab0"))), Arr(((V)((-12D))), ((V)("#ffd66b"))), Arr(((V)(8D)), ((V)("#a6e870")))), "forEach", Fn((V _arrowThis1169, int _argc1158, V _a1160, V _a1161, V _a1162, V _a1163, V[] _rest1159) => {
V x_1166 = default;
V c_1168 = default;
{ V _t1164 = ListOf(_a1160);
{ V _t1165 = GetIdx(_t1164, 0D);
x_1166 = _t1165; }
{ V _t1167 = GetIdx(_t1164, 1D);
c_1168 = _t1167; }
}
return Invoke(o_1121, "push", Call(cyl_14, V.Undef, x_1166, ((V)(38D)), ((V)(14D)), ((V)(5.4)), ((V)(14D)), c_1168, Call(cer_30, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("shine", ((V)(1D))).V)), Call(cyl_14, V.Undef, Add(x_1166, ((V)(2D))), ((V)(52D)), ((V)(14D)), ((V)(0.8)), ((V)(8D)), ((V)("#ffffff")), Call(pt_31, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
}, 1, "", true));
} else {
if (SEqN(t_1111, 4D)) {
InvokeSpread(o_1121, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(120D)), ((V)(46D)), ((V)(44D)), ((V)("#f4f1ea")), Call(pt_31, V.Undef, NewObj(2).Put("r", ((V)(3D))).Put("bev", ((V)(2D))).V))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(46D)), ((V)(6D)), ((V)(126D)), ((V)(4D)), ((V)(56D)), ((V)("#3fb0c8")), Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(2D))).V))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-26D))), ((V)(120D)), ((V)(76D)), ((V)(8D)), ((V)("#3fb0c8")), Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(2D))).V))).Spread(Invoke(Arr(((V)((-40D))), ((V)((-20D))), ((V)(0D)), ((V)(20D)), ((V)(40D))), "map", Fn((V _arrowThis1177, int _argc1170, V x_1176, V _a1173, V _a1174, V _a1175, V[] _rest1171) => {
return Call(cyl_14, V.Undef, x_1176, ((V)(0D)), ((V)(30D)), ((V)(5D)), ((V)(22D)), ((V)("#e2554a")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(12D))).V));
}, 1, "", true))).Spread(Invoke(Arr(((V)((-40D))), ((V)((-20D))), ((V)(0D)), ((V)(20D)), ((V)(40D))), "map", Fn((V _arrowThis1185, int _argc1178, V x_1184, V _a1181, V _a1182, V _a1183, V[] _rest1179) => {
return Call(cyl_14, V.Undef, x_1184, ((V)(22D)), ((V)(30D)), ((V)(7D)), ((V)(2.4)), ((V)("#2c2d31")), Call(fb_47, V.Undef, NewObj(1).Put("n", ((V)(12D))).V));
}, 1, "", true))).V);
} else {
Invoke(o_1121, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(46D)), ((V)(44D)), ((V)("#fff6e2")), Call(cer_30, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("shine", ((V)(1D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(44D)), ((V)(0D)), ((V)(50D)), ((V)(4D)), GOLD_44, Call(mt_28, V.Undef, NewObj(2).Put("n", ((V)(28D))).Put("shine", ((V)(1D))).V)), Call(ball_15, V.Undef, ((V)(0D)), ((V)(48D)), ((V)(0D)), ((V)(44D)), ((V)("#ffd6e8")), Call(cer_30, V.Undef, NewObj(4).Put("sy", ((V)(0.62))).Put("k", ((V)(6D))).Put("n", ((V)(28D))).Put("shine", ((V)(1D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(74D)), ((V)(0D)), ((V)(8D)), ((V)(24D)), ((V)("#e8b84a")), Call(pt_31, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.2))), Arr(((V)(24D)), ((V)(0D)), ((V)(1D))))).V)), Call(ball_15, V.Undef, ((V)(0D)), ((V)(102D)), ((V)(0D)), ((V)(11D)), ((V)("#ff9ac8")), Call(fb_47, V.Undef, NewObj(1).Put("k", ((V)(5D))).V)), Call(ball_15, V.Undef, ((V)(0D)), ((V)(112D)), ((V)(0D)), ((V)(4D)), ((V)("#e2554a")), Call(cer_30, V.Undef, NewObj(2).Put("k", ((V)(4D))).Put("shine", ((V)(1D))).V)));
}
}
}
}
return o_1121;
return default;
}, 1, "", true));
Set(D_1112, "fx", Fn((V _arrowThis1193, int _argc1186, V c_1192, V _a1189, V _a1190, V _a1191, V[] _rest1187) => {
V p_1194 = default;
V k_1195 = default;
JsStrBuf f_1196 = null;
V defs_1197 = default;
V sign_1198 = default;
p_1194 = Get(c_1192, "p");
k_1195 = Get(c_1192, "k");
f_1196 = new JsStrBuf("");
defs_1197 = GLW_63;
sign_1198 = Fn((V _arrowThis1210, int _argc1199, V q_1205, V txt_1206, V col_1207, V bg_1208, V[] _rest1200) => {
V sz_1209 = default;
sz_1209 = (_argc1199 > 4 ? _rest1200[0] : V.Undef);
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(P2_25, V.Undef, q_1205)), ")\"><text text-anchor=\"middle\" y=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(sz_1209) * 0.35))))), "\" font-family=\"Fredoka, sans-serif\" font-weight=\"700\" font-size=\"", ToStr(Call(f1_21, V.Undef, sz_1209)), "\" fill=\"", ToStr(col_1207), "\" stroke=\"", ToStr(bg_1208), "\" stroke-width=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(sz_1209) * 0.22))))), "\" paint-order=\"stroke\">", ToStr(txt_1206), "</text></g>")));
}, 5, "", true);
if (SEqN(t_1111, 1D)) {
f_1196.V(Call(sign_1198, V.Undef, Call(p_1194, V.Undef, ((V)(18D)), ((V)(48D)), ((V)((-10D)))), ((V)("LEMONADE")), ((V)("#e2554a")), ((V)("#fff8ea")), ((V)((4.6 * ToNum(k_1195))))));
}
if (SEqN(t_1111, 2D)) {
f_1196.V(Call(cone_57, V.Undef, p_1194, k_1195, NewObj(6).Put("y", ((V)(84D))).Put("h", ((V)(12D))).Put("R", ((V)(30D))).Put("n", ((V)(10D))).Put("x", ((V)(46D))).Put("cols", Arr(((V)("#ff6a8a")), ((V)("#ffffff")))).V));
f_1196.V(Call(sign_1198, V.Undef, Call(p_1194, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(24D))), ((V)("ICE CREAM")), ((V)("#2f9fb8")), ((V)("#fffaf1")), ((V)((6D * ToNum(k_1195))))));
}
if (SEqN(t_1111, 3D)) {
f_1196.V(Call(cone_57, V.Undef, p_1194, k_1195, NewObj(9).Put("y", ((V)(74D))).Put("h", ((V)(22D))).Put("R", ((V)(74D))).Put("n", ((V)(4D))).Put("a0", ((V)((PI_43 / 4D)))).Put("cols", Arr(((V)("#d8b46a")), ((V)("#c9a45a")))).Put("fringe", ((V)("#b8924a"))).Put("droop", ((V)(0D))).Put("fl", ((V)(10D))).V));
f_1196.V(Call(sign_1198, V.Undef, Call(p_1194, V.Undef, ((V)(0D)), ((V)(50D)), ((V)((-20D)))), ((V)("SMOOTHIES")), ((V)("#ffffff")), ((V)("#8a5a2c")), ((V)((6.4 * ToNum(k_1195))))));
}
if (SEqN(t_1111, 4D)) {
V sc_1211 = default;
V q_1212 = default;
sc_1211 = Invoke(Invoke(Call(rep_22, V.Undef, ((V)(7D)), Fn((V _arrowThis1230, int _argc1223, V i_1229, V _a1226, V _a1227, V _a1228, V[] _rest1224) => {
return NewObj(1).Put("i", i_1229).V;
}, 1, "", true)), "map", Fn((V _arrowThis1221, int _argc1213, V _a1215, V _a1216, V _a1217, V _a1218, V[] _rest1214) => {
double x_1222 = 0;
V i_1220 = default;
if (_a1215.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_a1215));
{ V _t1219 = Get(_a1215, "i");
i_1220 = _t1219; }
x_1222 = ((-63D) + (ToNum(i_1220) * 18D));
return Call(PP_51, V.Undef, Call(PQ_52, V.Undef, p_1194, Arr(Arr(((V)(x_1222)), ((V)(50D)), ((V)(34D))), Arr(((V)((x_1222 + 18D))), ((V)(50D)), ((V)(34D))), Arr(((V)((x_1222 + 18D))), ((V)(42D)), ((V)(40D))), Arr(((V)(x_1222)), ((V)(42D)), ((V)(40D))))), ((V)((NumTruthy((ToNum(i_1220) % 2D)) ? "#ffffff" : "#e2554a"))), Call(ink_56, V.Undef, ((V)("#e2554a"))), ((V)(0.6)));
return default;
}, 1, "", true)), "join", ((V)("")));
f_1196.V(sc_1211);
q_1212 = Call(p_1194, V.Undef, ((V)(30D)), ((V)(60D)), ((V)((-24D))));
f_1196.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_25, V.Undef, q_1212)), ") scale(", ToStr(Call(n4_24, V.Undef, k_1195)), ")\"><path d=\"M-5 0L0 14L5 0Z\" fill=\"#ffb340\" stroke=\"#ff7a22\" stroke-width=\"1.6\"><animate attributeName=\"stroke-opacity\" values=\"1;0.4;1\" dur=\"1.2s\" repeatCount=\"indefinite\"/></path><circle cx=\"0\" cy=\"-3\" r=\"6\" fill=\"#ff8ac8\" stroke=\"#ff4fd8\" stroke-width=\"1.6\"/></g>")).V(Call(glowAt_64, V.Undef, q_1212, ((V)((18D * ToNum(k_1195)))), ((V)("bhG")), ((V)(0.6)))).V(Call(sign_1198, V.Undef, Call(p_1194, V.Undef, ((V)((-20D))), ((V)(62D)), ((V)((-24D)))), ((V)("SNACKS")), ((V)("#ffffff")), ((V)("#2f7a8a")), ((V)((7D * ToNum(k_1195))))));
}
if (SEqN(t_1111, 5D)) {
f_1196.V(Add(Call(glowAt_64, V.Undef, Call(p_1194, V.Undef, ((V)(0D)), ((V)(60D)), ((V)(0D))), ((V)((60D * ToNum(k_1195)))), ((V)("bhG")), ((V)(0.5))), Invoke(Call(rep_22, V.Undef, ((V)(8D)), Fn((V _arrowThis1238, int _argc1231, V i_1237, V _a1234, V _a1235, V _a1236, V[] _rest1232) => {
double a_1239 = 0;
V q_1240 = default;
a_1239 = (((ToNum(i_1237) / 8D) * 2D) * PI_43);
q_1240 = Call(p_1194, V.Undef, ((V)((FdLibm.Cos(a_1239) * 48D))), ((V)(46D)), ((V)((FdLibm.Sin(a_1239) * 48D))));
return ((V)(((FdLibm.Sin(a_1239) > (-0.2)) ? string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_1240, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_1240, 1D))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((1.8 * ToNum(k_1195)))))), "\" fill=\"#fff6c8\">", ToStr(Call(AN_54, V.Undef, ((V)("opacity")), ((V)("1;0.3;1")), ((V)(1.2)), ((V)(((-ToNum(i_1237)) * 0.15))))), "</circle>") : "")));
return default;
}, 1, "", true)), "join", ((V)("")))));
}
return NewObj(3).Put("defs", defs_1197).Put("front", ((V)(f_1196.Str))).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_1194, V.Undef, ((V)((-76D))), ((V)(0D)), ((V)((-44D)))), Call(p_1194, V.Undef, ((V)(76D)), ((V)(0D)), ((V)(44D))), Call(p_1194, V.Undef, ((V)((-76D))), ((V)(0D)), ((V)(44D))), Call(p_1194, V.Undef, ((V)(76D)), ((V)(0D)), ((V)((-44D)))), Call(p_1194, V.Undef, ((V)(0D)), ((V)(120D)), ((V)(0D))), Call(p_1194, V.Undef, ((V)((-70D))), ((V)(96D)), ((V)((-20D)))), Call(p_1194, V.Undef, ((V)(70D)), ((V)(96D)), ((V)((-20D)))), Call(p_1194, V.Undef, ((V)(76D)), ((V)(90D)), ((V)(0D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1112;
return default;
}, 1, "", true));
Set(N_42, "bFire", Fn((V _arrowThis1248, int _argc1241, V S_1247, V _a1244, V _a1245, V _a1246, V[] _rest1242) => {
V t_1249 = default;
V D_1250 = default;
t_1249 = Call(T_48, V.Undef, S_1247);
D_1250 = NewObj(4).Put("w", ((V)(140D))).Put("d", ((V)(110D))).Put("act", ((V)("roast"))).Put("seats", Arr(NewObj(5).Put("x", ((V)((-54D)))).Put("z", ((V)(8D))).Put("h", ((V)(((SEqN(t_1249, 2D) || SEqN(t_1249, 4D)) ? 12D : 3D)))).Put("k", ((V)("roast"))).Put("f", ((V)(90D))).V, NewObj(5).Put("x", ((V)(54D))).Put("z", ((V)(8D))).Put("h", ((V)(((SEqN(t_1249, 2D) || SEqN(t_1249, 4D)) ? 12D : 3D)))).Put("k", ((V)("roast"))).Put("f", ((V)((-90D)))).V, NewObj(5).Put("x", ((V)(0D))).Put("z", ((V)((-46D)))).Put("h", ((V)((SEqN(t_1249, 4D) ? 12D : 3D)))).Put("k", ((V)("roast"))).Put("f", ((V)(0D))).V)).V;
Set(D_1250, "build", Fn((V _arrowThis1258, int _argc1251, V P_1257, V _a1254, V _a1255, V _a1256, V[] _rest1252) => {
V o_1259 = default;
o_1259 = Arr();
if (SEqN(t_1249, 1D)) {
Invoke(o_1259, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(2D)), SANDD_50, Call(pt_31, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.2))), Arr(((V)(2D)), ((V)(0D)), ((V)(1D))))).V)));
Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis1267, int _argc1260, V i_1266, V _a1263, V _a1264, V _a1265, V[] _rest1261) => {
double a_1268 = 0;
a_1268 = (((ToNum(i_1266) / 5D) * 2D) * PI_43);
Invoke(o_1259, "push", Call(box_12, V.Undef, ((V)((FdLibm.Cos(a_1268) * 6D))), ((V)(2D)), ((V)((FdLibm.Sin(a_1268) * 6D))), ((V)(18D)), ((V)(2.4)), ((V)(2.4)), ((V)("#8a6a48")), Call(wd_29, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("yaw", ((V)(a_1268))).V)));
return default;
}, 1, "", true));
} else {
if (SEqN(t_1249, 2D)) {
Call(rep_22, V.Undef, ((V)(12D)), Fn((V _arrowThis1276, int _argc1269, V i_1275, V _a1272, V _a1273, V _a1274, V[] _rest1270) => {
double a_1277 = 0;
a_1277 = (((ToNum(i_1275) / 12D) * 2D) * PI_43);
Invoke(o_1259, "push", Call(ball_15, V.Undef, ((V)((FdLibm.Cos(a_1277) * 20D))), ((V)(3D)), ((V)((FdLibm.Sin(a_1277) * 16D))), ((V)(5D)), ((V)((NumTruthy((ToNum(i_1275) % 2D)) ? "#9a948a" : "#b4ada0"))), Call(pt_31, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(8D))).Put("sy", ((V)(0.7))).V)));
return default;
}, 1, "", true));
Invoke(o_1259, "push", Call(box_12, V.Undef, ((V)((-54D))), ((V)(0D)), ((V)(8D)), ((V)(22D)), ((V)(10D)), ((V)(40D)), ((V)("#8a5a2c")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(5D))).V)), Call(box_12, V.Undef, ((V)(54D)), ((V)(0D)), ((V)(8D)), ((V)(22D)), ((V)(10D)), ((V)(40D)), ((V)("#8a5a2c")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(5D))).V)));
Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis1285, int _argc1278, V i_1284, V _a1281, V _a1282, V _a1283, V[] _rest1279) => {
return Invoke(o_1259, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0D)), ((V)(22D)), ((V)(3D)), ((V)(3D)), ((V)("#6a4a2a")), Call(wd_29, V.Undef, NewObj(2).Put("r", ((V)(1.2))).Put("yaw", ((V)((ToNum(i_1284) * 0.8)))).V)));
}, 1, "", true));
} else {
if (SEqN(t_1249, 3D)) {
InvokeSpread(o_1259, "push", new ArrBuilder().Spread(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D))), "map", Fn((V _arrowThis1293, int _argc1286, V i_1292, V _a1289, V _a1290, V _a1291, V[] _rest1287) => {
return Call(box_12, V.Undef, ((V)((FdLibm.Cos((ToNum(i_1292) * 2.09)) * 14D))), ((V)(0D)), ((V)((FdLibm.Sin((ToNum(i_1292) * 2.09)) * 14D))), ((V)(3D)), ((V)(12D)), ((V)(3D)), ((V)("#2c2d31")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V));
}, 1, "", true))).Add(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(10D)), ((V)(0D)), ((V)(24D)), ((V)(10D)), ((V)("#3a3d44")), Call(mt_28, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(10D)), ((V)(0D)), ((V)(1D))))).V))).Add(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(19.4)), ((V)(0D)), ((V)(24.6)), ((V)(1.2)), ((V)("#55585e")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(22D))).V))).V);
} else {
if (SEqN(t_1249, 4D)) {
Invoke(o_1259, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(24D)), ((V)(6D)), ((V)("#9a948a")), Call(pt_31, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(0D)), ((V)(18D)), ((V)(1D)), ((V)("#3a2a20")), Call(pt_31, V.Undef, NewObj(1).Put("n", ((V)(18D))).V)));
Call(rep_22, V.Undef, ((V)(7D)), Fn((V _arrowThis1301, int _argc1294, V i_1300, V _a1297, V _a1298, V _a1299, V[] _rest1295) => {
double a_1302 = 0;
a_1302 = ((PI_43 * 0.15) + (((ToNum(i_1300) / 7D) * 2D) * PI_43));
Invoke(o_1259, "push", Call(cush_13, V.Undef, ((V)((FdLibm.Cos(a_1302) * 52D))), ((V)(0D)), ((V)((FdLibm.Sin(a_1302) * 40D))), ((V)(22D)), ((V)(12D)), ((V)(22D)), ((V)((NumTruthy((ToNum(i_1300) % 2D)) ? "#e3946a" : "#2f9fb8"))), Call(fb_47, V.Undef, NewObj(1).Put("yaw", ((V)((-a_1302)))).V)));
return default;
}, 1, "", true));
} else {
Call(rep_22, V.Undef, ((V)(9D)), Fn((V _arrowThis1310, int _argc1303, V i_1309, V _a1306, V _a1307, V _a1308, V[] _rest1304) => {
double a_1311 = 0;
a_1311 = (((ToNum(i_1309) / 9D) * 2D) * PI_43);
Invoke(o_1259, "push", Call(cyl_14, V.Undef, ((V)((FdLibm.Cos(a_1311) * 22D))), ((V)(0D)), ((V)((FdLibm.Sin(a_1311) * 18D))), ((V)(4D)), ((V)((10D + ((ToNum(i_1309) % 3D) * 5D)))), ((V)("#bfeefa")), Call(em_46, V.Undef, NewObj(2).Put("n", ((V)(6D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)((10D + ((ToNum(i_1309) % 3D) * 5D)))), ((V)(0D)), ((V)(0.1))))).V)));
return default;
}, 1, "", true));
Invoke(o_1259, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(2D)), ((V)("#3a3a5a")), Call(pt_31, V.Undef, NewObj(1).Put("n", ((V)(16D))).V)));
}
}
}
}
return o_1259;
return default;
}, 1, "", true));
Set(D_1250, "fx", Fn((V _arrowThis1319, int _argc1312, V c_1318, V _a1315, V _a1316, V _a1317, V[] _rest1313) => {
V p_1320 = default;
V k_1321 = default;
double fy_1322 = 0;
JsStrBuf f_1323 = null;
V defs_1324 = default;
V fl_1325 = default;
p_1320 = Get(c_1318, "p");
k_1321 = Get(c_1318, "k");
fy_1322 = (SEqN(t_1249, 3D) ? 20D : (SEqN(t_1249, 4D) ? 6D : 3D));
f_1323 = new JsStrBuf("");
defs_1324 = Add(Add(FDEF_38, HUE_62), GLW_63);
fl_1325 = Call(flames_37, V.Undef, Call(p_1320, V.Undef, ((V)(0D)), ((V)(fy_1322)), ((V)(0D))), ((V)((ToNum(k_1321) * (SEqN(t_1249, 1D) ? 0.75 : 1D)))), NewObj(5).Put("n", ((V)((SEqN(t_1249, 1D) ? 3D : 5D)))).Put("sp", ((V)((SEqN(t_1249, 1D) ? 5D : 9D)))).Put("h", ((V)((SEqN(t_1249, 1D) ? 14D : 20D)))).Put("w", ((V)(3.8))).Put("seed", ((V)(JsStrBuf.Begin().S("bf").V(t_1249).End()))).V);
f_1323.V((SEqN(t_1249, 5D) ? ((V)(string.Concat("<g filter=\"url(#bhBlue)\">", ToStr(fl_1325), "</g>"))) : fl_1325));
if (SEqN(t_1249, 3D)) {
Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis1333, int _argc1326, V i_1332, V _a1329, V _a1330, V _a1331, V[] _rest1327) => {
double a_1334 = 0;
V q0_1335 = default;
V q1_1336 = default;
a_1334 = ((-0.6) + (ToNum(i_1332) * 0.6));
q0_1335 = Call(p_1320, V.Undef, ((V)((FdLibm.Cos(a_1334) * 46D))), ((V)(18D)), ((V)(((FdLibm.Sin(a_1334) * 30D) + 10D))));
q1_1336 = Call(p_1320, V.Undef, ((V)((FdLibm.Cos(a_1334) * 12D))), ((V)(26D)), ((V)((FdLibm.Sin(a_1334) * 8D))));
f_1323.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, q0_1335)), "L", ToStr(Call(P2_25, V.Undef, q1_1336))))), ((V)("none")), ((V)("#8a6a48")), ((V)(1.2)))).S(string.Concat("<rect x=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q1_1336, 0D)) - (2.4 * ToNum(k_1321))))))), "\" y=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q1_1336, 1D)) - (1.6 * ToNum(k_1321))))))), "\" width=\"", ToStr(Call(f1_21, V.Undef, ((V)((4.8 * ToNum(k_1321)))))), "\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)((3.6 * ToNum(k_1321)))))), "\" rx=\"", ToStr(Call(f1_21, V.Undef, ((V)((1.4 * ToNum(k_1321)))))), "\" fill=\"#fffaf1\" stroke=\"#d8c8b0\" stroke-width=\"0.5\"/>"));
return default;
}, 1, "", true));
}
f_1323.V(Call(glowAt_64, V.Undef, Call(p_1320, V.Undef, ((V)(0D)), ((V)(2D)), ((V)(0D))), ((V)((44D * ToNum(k_1321)))), ((V)((SEqN(t_1249, 5D) ? "bhC" : "bhG"))), ((V)(0.45))));
return NewObj(3).Put("defs", defs_1324).Put("front", ((V)(f_1323.Str))).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_1320, V.Undef, ((V)((-80D))), ((V)(0D)), ((V)((-56D)))), Call(p_1320, V.Undef, ((V)(80D)), ((V)(0D)), ((V)(56D))), Call(p_1320, V.Undef, ((V)((-80D))), ((V)(0D)), ((V)(56D))), Call(p_1320, V.Undef, ((V)(80D)), ((V)(0D)), ((V)((-56D)))), Call(p_1320, V.Undef, ((V)(0D)), ((V)(50D)), ((V)(0D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1250;
return default;
}, 1, "", true));
Set(N_42, "bTide", Fn((V _arrowThis1344, int _argc1337, V S_1343, V _a1340, V _a1341, V _a1342, V[] _rest1338) => {
V t_1345 = default;
double RX_1346 = 0;
double RZ_1347 = 0;
V rc_1348 = default;
V D_1349 = default;
t_1345 = Call(T_48, V.Undef, S_1343);
RX_1346 = 40D;
RZ_1347 = 28D;
rc_1348 = ((V)((SEqN(t_1345, 3D) ? "#7f8f78" : (SEqN(t_1345, 4D) ? "#e8907a" : (SEqN(t_1345, 5D) ? "#6a6f9a" : "#9a948a")))));
D_1349 = NewObj(4).Put("w", ((V)(120D))).Put("d", ((V)(90D))).Put("act", ((V)("splash"))).Put("seats", Arr(NewObj(4).Put("x", ((V)((-14D)))).Put("z", ((V)(0D))).Put("h", ((V)(2D))).Put("k", ((V)("splash"))).V, NewObj(4).Put("x", ((V)(16D))).Put("z", ((V)(4D))).Put("h", ((V)(2D))).Put("k", ((V)("splash"))).V)).V;
Set(D_1349, "build", Fn((V _arrowThis1357, int _argc1350, V P_1356, V _a1353, V _a1354, V _a1355, V[] _rest1351) => {
V o_1358 = default;
V R_1359 = default;
double n_1360 = 0;
o_1358 = Arr();
R_1359 = Call(rng_23, V.Undef, ((V)(JsStrBuf.Begin().S("tide").V(t_1345).End())));
n_1360 = (SEqN(t_1345, 1D) ? 0D : 13D);
if (SEqN(t_1345, 1D)) {
Invoke(o_1358, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((RX_1346 + 6D))), ((V)(1D)), ((V)("#8a7a5c")), Call(pt_31, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("rz", ((V)((RZ_1347 + 5D)))).V)));
}
Call(rep_22, V.Undef, ((V)(n_1360)), Fn((V _arrowThis1368, int _argc1361, V i_1367, V _a1364, V _a1365, V _a1366, V[] _rest1362) => {
double a_1369 = 0;
double r_1370 = 0;
a_1369 = (((ToNum(i_1367) / n_1360) * 2D) * PI_43);
r_1370 = (7D + (ToNum(Call(R_1359, V.Undef)) * 6D));
Invoke(o_1358, "push", Call(ball_15, V.Undef, ((V)((FdLibm.Cos(a_1369) * (RX_1346 + 4D)))), ((V)((r_1370 * 0.4))), ((V)((FdLibm.Sin(a_1369) * (RZ_1347 + 4D)))), ((V)(r_1370)), (((ToNum(i_1367) % 3D) == 0D) ? Call(shade_19, V.Undef, rc_1348, ((V)(1.1))) : rc_1348), Call(pt_31, V.Undef, NewObj(3).Put("k", ((V)(3D))).Put("n", ((V)(9D))).Put("sy", ((V)(0.75))).V)));
return default;
}, 1, "", true));
if (SEqN(t_1345, 3D)) {
Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis1378, int _argc1371, V i_1377, V _a1374, V _a1375, V _a1376, V[] _rest1372) => {
return Invoke(o_1358, "push", Call(ball_15, V.Undef, ((V)(((-24D) + (ToNum(i_1377) * 16D)))), ((V)(2D)), ((V)(((NumTruthy((ToNum(i_1377) % 2D)) ? 1D : (-1D)) * 10D))), ((V)(3.4)), GetK(Arr(((V)("#ff7aa0")), ((V)("#ffb3c8")), ((V)("#ff9a6a")), ((V)("#ff7aa0"))), i_1377), Call(fb_47, V.Undef, NewObj(2).Put("k", ((V)(3D))).Put("sy", ((V)(1.4))).V)));
}, 1, "", true));
}
return o_1358;
return default;
}, 1, "", true));
Set(D_1349, "fx", Fn((V _arrowThis1386, int _argc1379, V c_1385, V _a1382, V _a1383, V _a1384, V[] _rest1380) => {
V p_1387 = default;
V k_1388 = default;
V pal_1389 = default;
V W_1390 = default;
JsStrBuf f_1391 = null;
V defs_1392 = default;
double nc_1393 = 0;
p_1387 = Get(c_1385, "p");
k_1388 = Get(c_1385, "k");
pal_1389 = (SEqN(t_1345, 1D) ? Arr(((V)("#4a3a24")), ((V)("#6a5a3e")), ((V)("#a8987a")), ((V)("#e8dcc0"))) : (SEqN(t_1345, 5D) ? Arr(((V)("#0a1838")), ((V)("#183a6a")), ((V)("#4f7ab8")), ((V)("#bfe6ff"))) : (SEqN(t_1345, 4D) ? Get(WP_36, "lagoon") : Get(WP_36, "pool"))));
W_1390 = Call(water_35, V.Undef, p_1387, NewObj(6).Put("sh", NewObj(2).Put("rx", ((V)(RX_1346))).Put("rz", ((V)(RZ_1347))).V).Put("y", ((V)(1.2))).Put("pal", pal_1389).Put("gl", ((V)((SEqN(t_1345, 1D) ? 1D : 5D)))).Put("wave", ((V)(0.35))).Put("caust", ((V)((SEqN(t_1345, 1D) ? 0.1 : 0.4)))).V);
f_1391 = new JsStrBuf("");
defs_1392 = Add(Get(W_1390, "defs"), GLW_63);
if ((SEqN(t_1345, 2D) || SEqN(t_1345, 3D))) {
f_1391.V(Add(Call(star5_60, V.Undef, Call(p_1387, V.Undef, ((V)((-20D))), ((V)(1.6)), ((V)(10D))), ((V)((ToNum(k_1388) * 1.2))), ((V)("#ff8a4a")), ((V)(20D))), Call(star5_60, V.Undef, Call(p_1387, V.Undef, ((V)(22D)), ((V)(1.6)), ((V)((-8D)))), k_1388, ((V)("#ffb340")), ((V)((-10D))))));
}
if (SEqN(t_1345, 4D)) {
Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis1401, int _argc1394, V i_1400, V _a1397, V _a1398, V _a1399, V[] _rest1395) => {
V q_1402 = default;
q_1402 = Call(p_1387, V.Undef, ((V)(((-26D) + (ToNum(i_1400) * 24D)))), ((V)(1.4)), ((V)(((-12D) + ((ToNum(i_1400) % 2D) * 16D)))));
f_1391.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_25, V.Undef, q_1402)), ") scale(", ToStr(Call(n4_24, V.Undef, k_1388)), ")\"><path d=\"M0 0V-10M0 -6l-4 -4M0 -4l4 -5M0 -8l3 -3\" stroke=\"", ToStr(GetK(Arr(((V)("#ff7a5a")), ((V)("#ffb3c8")), ((V)("#ffd66b"))), i_1400)), "\" stroke-width=\"2\" stroke-linecap=\"round\" fill=\"none\"/></g>"));
return default;
}, 1, "", true));
Call(rep_22, V.Undef, ((V)(3D)), Fn((V _arrowThis1410, int _argc1403, V i_1409, V _a1406, V _a1407, V _a1408, V[] _rest1404) => {
return ((V)(f_1391.S(string.Concat("<g><animateMotion dur=\"", ToStr(Add(((V)(5D)), i_1409)), "s\" begin=\"", NumStr(((-ToNum(i_1409)) * 1.6)), "s\" repeatCount=\"indefinite\" path=\"M", ToStr(Call(P2_25, V.Undef, Call(p_1387, V.Undef, ((V)((-26D))), ((V)(1.4)), ((V)(((-8D) + (ToNum(i_1409) * 7D))))))), "Q", ToStr(Call(P2_25, V.Undef, Call(p_1387, V.Undef, ((V)(0D)), ((V)(1.4)), ((V)((16D - (ToNum(i_1409) * 8D))))))), " ", ToStr(Call(P2_25, V.Undef, Call(p_1387, V.Undef, ((V)(26D)), ((V)(1.4)), ((V)(((-6D) + (ToNum(i_1409) * 6D))))))), "Q", ToStr(Call(P2_25, V.Undef, Call(p_1387, V.Undef, ((V)(0D)), ((V)(1.4)), ((V)(((-18D) + (ToNum(i_1409) * 6D))))))), " ", ToStr(Call(P2_25, V.Undef, Call(p_1387, V.Undef, ((V)((-26D))), ((V)(1.4)), ((V)(((-8D) + (ToNum(i_1409) * 7D))))))), "\" rotate=\"auto\"/><path d=\"M-3 0Q0 -2 3 0Q0 2 -3 0ZM-3 0L-5.4 -1.6V1.6Z\" fill=\"", ToStr(GetK(Arr(((V)("#ffb340")), ((V)("#ff7a6a")), ((V)("#ffe066"))), i_1409)), "\" transform=\"scale(", ToStr(Call(n4_24, V.Undef, k_1388)), ")\"/></g>")).Str));
}, 1, "", true));
}
if (SEqN(t_1345, 5D)) {
f_1391.V(Call(glowAt_64, V.Undef, Call(p_1387, V.Undef, ((V)(0D)), ((V)(1.2)), ((V)(0D))), ((V)((40D * ToNum(k_1388)))), ((V)("bhC")), ((V)(0.6)))).S(string.Concat("<g transform=\"", ToStr(Call(planeH_26, V.Undef, p_1387, ((V)(1.3)))), "\"><circle cx=\"6\" cy=\"-4\" r=\"7\" fill=\"#fff8dc\" opacity=\"0.85\">", ToStr(Call(AN_54, V.Undef, ((V)("opacity")), ((V)("0.85;0.5;0.85")), ((V)(3D)))), "</circle></g>"));
}
nc_1393 = (SEqN(t_1345, 1D) ? 1D : (SEqN(t_1345, 2D) ? 2D : 3D));
Call(rep_22, V.Undef, ((V)(nc_1393)), Fn((V _arrowThis1418, int _argc1411, V i_1417, V _a1414, V _a1415, V _a1416, V[] _rest1412) => {
double a_1419 = 0;
V q_1420 = default;
a_1419 = (PI_43 * (0.25 + (ToNum(i_1417) * 0.5)));
q_1420 = Call(p_1387, V.Undef, ((V)((FdLibm.Cos(a_1419) * (RX_1346 + 2D)))), ((V)(7D)), ((V)((FdLibm.Sin(a_1419) * (RZ_1347 + 3D)))));
f_1391.V(Call(crab_59, V.Undef, q_1420, k_1388, ((V)((SEqN(t_1345, 5D) ? "#ff9ac8" : "#e2554a"))), Add(((V)(3D)), i_1417), ((V)(((-ToNum(i_1417)) * 1.3))), ((V)((5D * ToNum(k_1388))))));
return default;
}, 1, "", true));
return NewObj(4).Put("defs", defs_1392).Put("under", Get(W_1390, "svg")).Put("front", ((V)(f_1391.Str))).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_1387, V.Undef, ((V)(((-RX_1346) - 14D))), ((V)(0D)), ((V)(((-RZ_1347) - 14D)))), Call(p_1387, V.Undef, ((V)((RX_1346 + 14D))), ((V)(0D)), ((V)((RZ_1347 + 14D)))), Call(p_1387, V.Undef, ((V)(((-RX_1346) - 14D))), ((V)(0D)), ((V)((RZ_1347 + 14D)))), Call(p_1387, V.Undef, ((V)((RX_1346 + 14D))), ((V)(0D)), ((V)(((-RZ_1347) - 14D)))), Call(p_1387, V.Undef, ((V)(0D)), ((V)(18D)), ((V)(0D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1349;
return default;
}, 1, "", true));
Set(N_42, "bFloat", Fn((V _arrowThis1428, int _argc1421, V S_1427, V _a1424, V _a1425, V _a1426, V[] _rest1422) => {
V t_1429 = default;
V D_1430 = default;
t_1429 = Call(T_48, V.Undef, S_1427);
D_1430 = NewObj(5).Put("w", GetIdx(Arr(((V)(70D)), ((V)(80D)), ((V)(130D)), ((V)(120D)), ((V)(150D))), (ToNum(t_1429) - 1D))).Put("d", GetIdx(Arr(((V)(70D)), ((V)(74D)), ((V)(56D)), ((V)(64D)), ((V)(70D))), (ToNum(t_1429) - 1D))).Put("sea", ((V)(1D))).Put("act", ((V)("ride"))).Put("seats", Arr(NewObj(4).Put("x", ((V)((GeN(t_1429, 3D) ? 8D : 0D)))).Put("z", ((V)(0D))).Put("h", GetIdx(Arr(((V)(7D)), ((V)(8D)), ((V)(10D)), ((V)(12D)), ((V)(14D))), (ToNum(t_1429) - 1D))).Put("k", ((V)("ride"))).V)).V;
Set(D_1430, "build", Fn((V _arrowThis1438, int _argc1431, V P_1437, V _a1434, V _a1435, V _a1436, V[] _rest1432) => {
V o_1439 = default;
o_1439 = Arr();
if (SEqN(t_1429, 1D)) {
Invoke(o_1439, "push", Call(arcW_17, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(30D)), ((V)(30D)), ((V)(13D)), ((V)(9D)), ((V)(0D)), ((V)((2D * PI_43))), ((V)("#3a3d44")), Call(fb_47, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).V)));
} else {
if (SEqN(t_1429, 2D)) {
Invoke(o_1439, "push", Call(arcW_17, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(32D)), ((V)(30D)), ((V)(14D)), ((V)(10D)), ((V)(0D)), ((V)((2D * PI_43))), ((V)("#ffd23f")), Call(cer_30, V.Undef, NewObj(2).Put("n", ((V)(24D))).Put("shine", ((V)(1D))).V)), Call(ball_15, V.Undef, ((V)((-30D))), ((V)(22D)), ((V)(0D)), ((V)(10D)), ((V)("#ffd23f")), Call(cer_30, V.Undef, NewObj(2).Put("k", ((V)(5D))).Put("shine", ((V)(1D))).V)), Call(ball_15, V.Undef, ((V)((-40D))), ((V)(20D)), ((V)(0D)), ((V)(4D)), ((V)("#ff8a2a")), Call(cer_30, V.Undef, NewObj(3).Put("sx", ((V)(1.8))).Put("sy", ((V)(0.6))).Put("k", ((V)(3D))).V)));
} else {
if (SEqN(t_1429, 3D)) {
Invoke(o_1439, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)((-2D))), ((V)(0D)), ((V)(62D)), ((V)(14D)), ((V)("#b8804a")), Call(wd_29, V.Undef, NewObj(3).Put("rz", ((V)(24D))).Put("n", ((V)(26D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.78))), Arr(((V)(14D)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(56D)), ((V)(1D)), ((V)("#8a5a2c")), Call(wd_29, V.Undef, NewObj(2).Put("rz", ((V)(19D))).Put("n", ((V)(24D))).V)), Call(box_12, V.Undef, ((V)(8D)), ((V)(8D)), ((V)(0D)), ((V)(14D)), ((V)(2.4)), ((V)(38D)), ((V)("#c48a52")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(0.8))).V)), Call(box_12, V.Undef, ((V)((-6D))), ((V)(13D)), ((V)(26D)), ((V)(70D)), ((V)(2D)), ((V)(3D)), ((V)("#d8b07a")), Call(wd_29, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("yaw", ((V)(0.2))).V)), Call(box_12, V.Undef, ((V)((-6D))), ((V)(13D)), ((V)((-26D))), ((V)(70D)), ((V)(2D)), ((V)(3D)), ((V)("#d8b07a")), Call(wd_29, V.Undef, NewObj(2).Put("r", ((V)(1D))).Put("yaw", ((V)((-0.2)))).V)));
} else {
if (SEqN(t_1429, 4D)) {
Invoke(o_1439, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)((-2D))), ((V)(0D)), ((V)(56D)), ((V)(16D)), ((V)("#fffaf6")), Call(cer_30, V.Undef, NewObj(4).Put("rz", ((V)(30D))).Put("n", ((V)(26D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(16D)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(14D)), ((V)(0D)), ((V)(48D)), ((V)(1D)), ((V)("#3fb0c8")), Call(fb_47, V.Undef, NewObj(2).Put("rz", ((V)(24D))).Put("n", ((V)(24D))).V)), Call(slab_16, V.Undef, ((V)((-14D))), ((V)(12D)), ((V)((-24D))), ((V)(40D)), ((V)(18D)), ((V)(4D)), ((V)("#fffaf6")), Call(cer_30, V.Undef, NewObj(2).Put("r", ((V)(9D))).Put("shine", ((V)(1D))).V)), Call(slab_16, V.Undef, ((V)((-14D))), ((V)(12D)), ((V)(24D)), ((V)(40D)), ((V)(18D)), ((V)(4D)), ((V)("#fffaf6")), Call(cer_30, V.Undef, NewObj(2).Put("r", ((V)(9D))).Put("shine", ((V)(1D))).V)));
} else {
InvokeSpread(o_1439, "push", new ArrBuilder().Add(Call(cyl_14, V.Undef, ((V)(0D)), ((V)((-2D))), ((V)(0D)), ((V)(72D)), ((V)(18D)), ((V)("#e8b84a")), Call(mt_28, V.Undef, NewObj(4).Put("rz", ((V)(32D))).Put("n", ((V)(28D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.8))), Arr(((V)(18D)), ((V)(0D)), ((V)(1D))))).V))).Add(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(16D)), ((V)(0D)), ((V)(64D)), ((V)(1.4)), ((V)("#7a1e2c")), Call(fb_47, V.Undef, NewObj(2).Put("rz", ((V)(26D))).Put("n", ((V)(26D))).V))).Spread(Invoke(Arr(Arr(((V)((-40D))), ((V)((-18D)))), Arr(((V)((-40D))), ((V)(18D))), Arr(((V)(40D)), ((V)((-18D)))), Arr(((V)(40D)), ((V)(18D)))), "map", Fn((V _arrowThis1451, int _argc1440, V _a1442, V _a1443, V _a1444, V _a1445, V[] _rest1441) => {
V x_1448 = default;
V z_1450 = default;
{ V _t1446 = ListOf(_a1442);
{ V _t1447 = GetIdx(_t1446, 0D);
x_1448 = _t1447; }
{ V _t1449 = GetIdx(_t1446, 1D);
z_1450 = _t1449; }
}
return Call(cyl_14, V.Undef, x_1448, ((V)(16D)), z_1450, ((V)(1.8)), ((V)(50D)), GOLD_44, Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(8D))).V));
}, 1, "", true))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(66D)), ((V)(0D)), ((V)(88D)), ((V)(3D)), ((V)(42D)), ((V)("#7a1e2c")), Call(fb_47, V.Undef, NewObj(1).Put("r", ((V)(2D))).V))).V);
}
}
}
}
return o_1439;
return default;
}, 1, "", true));
Set(D_1430, "fx", Fn((V _arrowThis1459, int _argc1452, V c_1458, V _a1455, V _a1456, V _a1457, V[] _rest1453) => {
V p_1460 = default;
V k_1461 = default;
JsStrBuf f_1462 = null;
V u_1463 = default;
p_1460 = Get(c_1458, "p");
k_1461 = Get(c_1458, "k");
f_1462 = new JsStrBuf("");
u_1463 = Call(ripples_61, V.Undef, p_1460, ((V)((ToNum(Get(D_1430, "w")) * 0.55))), ((V)((ToNum(Get(D_1430, "d")) * 0.5))), ((V)(2D)), ((V)(2.8)));
if (SEqN(t_1429, 1D)) {
f_1462.V(Call(PP_51, V.Undef, Call(PQ_52, V.Undef, p_1460, Arr(Arr(((V)(16D)), ((V)(9.2)), ((V)(18D))), Arr(((V)(26D)), ((V)(9.2)), ((V)(10D))), Arr(((V)(22D)), ((V)(9.2)), ((V)(22D))))), ((V)("#e2554a")), ((V)("#7a2a20")), ((V)(0.6))));
}
if (SEqN(t_1429, 2D)) {
V q_1464 = default;
q_1464 = Call(p_1460, V.Undef, ((V)((-34D))), ((V)(26D)), ((V)(0D)));
f_1462.S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1464, 0D)) - (3D * ToNum(k_1461))))))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1464, 1D)) - (1D * ToNum(k_1461))))))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((1.4 * ToNum(k_1461)))))), "\" fill=\"#2a1a10\"/>"));
}
if (SEqN(t_1429, 4D)) {
V pts_1465 = default;
V hq_1466 = default;
pts_1465 = Invoke(Call(curve_34, V.Undef, Arr(((V)((-50D))), ((V)(10D)), ((V)(0D))), Arr(((V)((-66D))), ((V)(40D)), ((V)(0D))), Arr(((V)((-52D))), ((V)(62D)), ((V)(0D))), ((V)(8D))), "map", Fn((V _arrowThis1474, int _argc1467, V q_1473, V _a1470, V _a1471, V _a1472, V[] _rest1468) => {
return CallSpread(p_1460, V.Undef, new ArrBuilder().Spread(q_1473).V);
}, 1, "", true));
f_1462.V(Call(tube_33, V.Undef, pts_1465, ((V)(6D)), k_1461, ((V)("#fffaf6")), ((V)("#ffffff")), ((V)("#9aa4b0"))));
hq_1466 = Call(p_1460, V.Undef, ((V)((-52D))), ((V)(66D)), ((V)(0D)));
f_1462.S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(hq_1466, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(hq_1466, 1D))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((7D * ToNum(k_1461)))))), "\" fill=\"#fffaf6\" stroke=\"#9aa4b0\" stroke-width=\"0.8\"/><path d=\"M", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(hq_1466, 0D)) - (6D * ToNum(k_1461))))))), " ", ToStr(Call(f1_21, V.Undef, GetIdx(hq_1466, 1D))), "l", ToStr(Call(f1_21, V.Undef, ((V)(((-8D) * ToNum(k_1461)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((2D * ToNum(k_1461)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((8D * ToNum(k_1461)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((3D * ToNum(k_1461)))))), "Z\" fill=\"#ff8a2a\" stroke=\"#c4561c\" stroke-width=\"0.6\"/><circle cx=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(hq_1466, 0D)) - (2D * ToNum(k_1461))))))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(hq_1466, 1D)) - (2D * ToNum(k_1461))))))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((1.2 * ToNum(k_1461)))))), "\" fill=\"#2a1a10\"/>"));
}
if (SEqN(t_1429, 5D)) {
V q_1475 = default;
f_1462.V(Call(cone_57, V.Undef, p_1460, k_1461, NewObj(8).Put("y", ((V)(69D))).Put("h", ((V)(14D))).Put("R", ((V)(56D))).Put("n", ((V)(4D))).Put("a0", ((V)((PI_43 / 4D)))).Put("cols", Arr(((V)("#a8243a")), ((V)("#7a1e2c")))).Put("droop", ((V)(0D))).Put("tassel", GOLD_44).V));
q_1475 = Call(p_1460, V.Undef, ((V)(0D)), ((V)(84D)), ((V)(0D)));
f_1462.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, q_1475)), "l0 ", ToStr(Call(f1_21, V.Undef, ((V)(((-14D) * ToNum(k_1461))))))))), ((V)("none")), GOLD_44, ((V)(1.4)))).S(string.Concat("<g>", ToStr(Call(AT_53, V.Undef, ((V)("skewY")), ((V)("-8;8;-8")), ((V)(1.6)))), "<path d=\"M", ToStr(Call(f1_21, V.Undef, GetIdx(q_1475, 0D))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1475, 1D)) - (14D * ToNum(k_1461))))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((12D * ToNum(k_1461)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((3D * ToNum(k_1461)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)(((-12D) * ToNum(k_1461)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((4D * ToNum(k_1461)))))), "Z\" fill=\"#ffd23f\"/></g>"));
}
return NewObj(3).Put("under", u_1463).Put("front", ((V)(f_1462.Str))).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_1460, V.Undef, ((V)(((-ToNum(Get(D_1430, "w"))) * 0.7))), ((V)(0D)), ((V)(((-ToNum(Get(D_1430, "d"))) * 0.7)))), Call(p_1460, V.Undef, ((V)((ToNum(Get(D_1430, "w")) * 0.7))), ((V)(0D)), ((V)((ToNum(Get(D_1430, "d")) * 0.7)))), Call(p_1460, V.Undef, ((V)(((-ToNum(Get(D_1430, "w"))) * 0.7))), ((V)(0D)), ((V)((ToNum(Get(D_1430, "d")) * 0.7)))), Call(p_1460, V.Undef, ((V)((ToNum(Get(D_1430, "w")) * 0.7))), ((V)(0D)), ((V)(((-ToNum(Get(D_1430, "d"))) * 0.7)))), Call(p_1460, V.Undef, ((V)(0D)), ((V)((SEqN(t_1429, 5D) ? 100D : (SEqN(t_1429, 4D) ? 76D : 40D)))), ((V)(0D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1430;
return default;
}, 1, "", true));
Set(N_42, "bTower", Fn((V _arrowThis1483, int _argc1476, V S_1482, V _a1479, V _a1480, V _a1481, V[] _rest1477) => {
V t_1484 = default;
V H_1485 = default;
V D_1486 = default;
t_1484 = Call(T_48, V.Undef, S_1482);
H_1485 = GetIdx(Arr(((V)(24D)), ((V)(52D)), ((V)(60D)), ((V)(64D)), ((V)(70D))), (ToNum(t_1484) - 1D));
D_1486 = NewObj(4).Put("w", ((V)(100D))).Put("d", ((V)(90D))).Put("act", ((V)("sit"))).Put("seats", Arr(NewObj(4).Put("x", ((V)(0D))).Put("z", ((V)((SEqN(t_1484, 1D) ? 2D : 10D)))).Put("h", Add(H_1485, ((V)(4D)))).Put("k", ((V)("sit"))).V)).V;
Set(D_1486, "build", Fn((V _arrowThis1494, int _argc1487, V P_1493, V _a1490, V _a1491, V _a1492, V[] _rest1488) => {
V o_1495 = default;
o_1495 = Arr();
if (SEqN(t_1484, 1D)) {
Invoke(o_1495, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(38D)), H_1485, ((V)(34D)), ((V)("#c49a62")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(6D)), ((V)(17.4)), ((V)(34D)), ((V)(3D)), ((V)(0.6)), ((V)("#8a6a42")), Call(wd_29, V.Undef)), Call(box_12, V.Undef, ((V)(0D)), ((V)(15D)), ((V)(17.4)), ((V)(34D)), ((V)(3D)), ((V)(0.6)), ((V)("#8a6a42")), Call(wd_29, V.Undef)));
} else {
if (SEqN(t_1484, 2D)) {
Invoke(Arr(Arr(((V)((-18D))), ((V)((-14D)))), Arr(((V)(18D)), ((V)((-14D)))), Arr(((V)((-18D))), ((V)(18D))), Arr(((V)(18D)), ((V)(18D)))), "forEach", Fn((V _arrowThis1507, int _argc1496, V _a1498, V _a1499, V _a1500, V _a1501, V[] _rest1497) => {
V x_1504 = default;
V z_1506 = default;
{ V _t1502 = ListOf(_a1498);
{ V _t1503 = GetIdx(_t1502, 0D);
x_1504 = _t1503; }
{ V _t1505 = GetIdx(_t1502, 1D);
z_1506 = _t1505; }
}
return Invoke(o_1495, "push", Call(box_12, V.Undef, x_1504, ((V)(0D)), z_1506, ((V)(4D)), H_1485, ((V)(4D)), ((V)("#f4f1ea")), Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
InvokeSpread(o_1495, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), H_1485, ((V)(2D)), ((V)(44D)), ((V)(4D)), ((V)(40D)), ((V)("#f4f1ea")), Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).Add(Call(slab_16, V.Undef, ((V)(0D)), Add(H_1485, ((V)(4D))), ((V)((-16D))), ((V)(44D)), ((V)(26D)), ((V)(3D)), ((V)("#f4f1ea")), Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(2D))).V))).Spread(Invoke(Arr(((V)(12D)), ((V)(26D)), ((V)(40D))), "map", Fn((V _arrowThis1515, int _argc1508, V y_1514, V _a1511, V _a1512, V _a1513, V[] _rest1509) => {
return Call(box_12, V.Undef, ((V)(0D)), y_1514, ((V)(18D)), ((V)(36D)), ((V)(2D)), ((V)(2D)), ((V)("#e8e2d6")), Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(0.6))).V));
}, 1, "", true))).V);
} else {
V hc_1516 = default;
V st_1517 = default;
hc_1516 = ((V)((SEqN(t_1484, 3D) ? "#e2554a" : (SEqN(t_1484, 4D) ? "#f4f1ea" : "#ffffff"))));
st_1517 = ((V)((SEqN(t_1484, 5D) ? "#e2554a" : "#ffffff")));
if (SEqN(t_1484, 5D)) {
InvokeSpread(o_1495, "push", new ArrBuilder().Add(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)((-6D))), ((V)(26D)), H_1485, ((V)("#ffffff")), Call(pt_31, V.Undef, NewObj(2).Put("n", ((V)(22D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.1))), Arr(H_1485, ((V)(0D)), ((V)(0.86))))).V))).Spread(Invoke(Arr(((V)(0.2)), ((V)(0.5)), ((V)(0.8))), "map", Fn((V _arrowThis1525, int _argc1518, V u_1524, V _a1521, V _a1522, V _a1523, V[] _rest1519) => {
return Call(cyl_14, V.Undef, ((V)(0D)), ((V)((ToNum(H_1485) * ToNum(u_1524)))), ((V)((-6D))), ((V)(((26D * (1.1 - (0.24 * ToNum(u_1524)))) + 0.4))), ((V)((ToNum(H_1485) * 0.14))), ((V)("#e2554a")), Call(pt_31, V.Undef, NewObj(1).Put("n", ((V)(22D))).V));
}, 1, "", true))).Add(Call(cyl_14, V.Undef, ((V)(0D)), H_1485, ((V)((-6D))), ((V)(30D)), ((V)(4D)), ((V)("#2c2d31")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(22D))).V))).V);
} else {
Invoke(Arr(Arr(((V)((-26D))), ((V)((-22D)))), Arr(((V)(26D)), ((V)((-22D)))), Arr(((V)((-26D))), ((V)(18D))), Arr(((V)(26D)), ((V)(18D)))), "forEach", Fn((V _arrowThis1537, int _argc1526, V _a1528, V _a1529, V _a1530, V _a1531, V[] _rest1527) => {
V x_1534 = default;
V z_1536 = default;
{ V _t1532 = ListOf(_a1528);
{ V _t1533 = GetIdx(_t1532, 0D);
x_1534 = _t1533; }
{ V _t1535 = GetIdx(_t1532, 1D);
z_1536 = _t1535; }
}
return Invoke(o_1495, "push", Call(box_12, V.Undef, x_1534, ((V)(0D)), z_1536, ((V)(5D)), H_1485, ((V)(5D)), ((V)("#f4f1ea")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
Invoke(o_1495, "push", Call(box_12, V.Undef, ((V)(0D)), H_1485, ((V)((-2D))), ((V)(64D)), ((V)(4D)), ((V)(52D)), ((V)("#d8b07a")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)(0D)), Add(H_1485, ((V)(4D))), ((V)((-12D))), ((V)(50D)), ((V)(34D)), ((V)(30D)), hc_1516, Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)(0D)), Add(H_1485, ((V)(38D))), ((V)((-12D))), ((V)(58D)), ((V)(4D)), ((V)(38D)), st_1517, Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(prismZ_18, V.Undef, ((V)((-10D))), ((V)(10D)), Arr(Arr(((V)(20D)), ((V)(0D))), Arr(((V)(30D)), ((V)(0D))), Arr(((V)(26D)), ((V)(4D))), Arr(((V)(8D)), H_1485), Arr(((V)(2D)), H_1485)), ((V)("#d8b07a")), Call(wd_29, V.Undef)));
}
if (SEqN(t_1484, 4D)) {
Invoke(o_1495, "push", Call(cyl_14, V.Undef, ((V)(32D)), ((V)(0D)), ((V)((-30D))), ((V)(1.8)), Add(H_1485, ((V)(70D))), ((V)("#9aa1a6")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(6D))).V)));
}
}
}
return o_1495;
return default;
}, 1, "", true));
Set(D_1486, "fx", Fn((V _arrowThis1545, int _argc1538, V c_1544, V _a1541, V _a1542, V _a1543, V[] _rest1539) => {
V p_1546 = default;
V k_1547 = default;
JsStrBuf f_1548 = null;
V defs_1549 = default;
p_1546 = Get(c_1544, "p");
k_1547 = Get(c_1544, "k");
f_1548 = new JsStrBuf("");
defs_1549 = GLW_63;
if (SEqN(t_1484, 2D)) {
f_1548.V(Add(Call(cone_57, V.Undef, p_1546, k_1547, NewObj(6).Put("y", Add(H_1485, ((V)(52D)))).Put("h", ((V)(10D))).Put("R", ((V)(34D))).Put("n", ((V)(10D))).Put("z", ((V)((-10D)))).Put("cols", Arr(((V)("#e2554a")), ((V)("#ffffff")))).V), Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, Call(p_1546, V.Undef, ((V)(0D)), Add(H_1485, ((V)(30D))), ((V)((-16D)))))), "L", ToStr(Call(P2_25, V.Undef, Call(p_1546, V.Undef, ((V)(0D)), Add(H_1485, ((V)(52D))), ((V)((-10D))))))))), ((V)("none")), ((V)("#9aa1a6")), ((V)(1.4)))));
}
if ((SEqN(t_1484, 3D) || SEqN(t_1484, 4D))) {
V q_1550 = default;
q_1550 = Call(p_1546, V.Undef, ((V)(0D)), Add(H_1485, ((V)(22D))), ((V)(3.4)));
f_1548.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_25, V.Undef, q_1550)), ") scale(", ToStr(Call(n4_24, V.Undef, k_1547)), ")\"><circle r=\"7\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"3.4\"/><circle r=\"7\" fill=\"none\" stroke=\"#e2554a\" stroke-width=\"3.4\" stroke-dasharray=\"5.5 5.5\"/></g>"));
}
if (SEqN(t_1484, 4D)) {
V q_1551 = default;
q_1551 = Call(p_1546, V.Undef, ((V)(32D)), Add(H_1485, ((V)(70D))), ((V)((-30D))));
f_1548.S(string.Concat("<g>", ToStr(Call(AT_53, V.Undef, ((V)("skewY")), ((V)("-8;8;-8")), ((V)(1.5)))), "<path d=\"M", ToStr(Call(P2_25, V.Undef, q_1551)), "l", ToStr(Call(f1_21, V.Undef, ((V)((18D * ToNum(k_1547)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((4D * ToNum(k_1547)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)(((-18D) * ToNum(k_1547)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((6D * ToNum(k_1547)))))), "Z\" fill=\"#ffd23f\" stroke=\"#8a5d00\" stroke-width=\"0.6\"/><path d=\"M", ToStr(Call(f1_21, V.Undef, GetIdx(q_1551, 0D))), " ", ToStr(Call(f1_21, V.Undef, Add(GetIdx(q_1551, 1D), ((V)((3D * ToNum(k_1547))))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((18D * ToNum(k_1547)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((1D * ToNum(k_1547)))))), "\" stroke=\"#e2554a\" stroke-width=\"", ToStr(Call(f1_21, V.Undef, ((V)((2D * ToNum(k_1547)))))), "\"/></g>"));
}
if (SEqN(t_1484, 5D)) {
V q_1552 = default;
q_1552 = Call(p_1546, V.Undef, ((V)(0D)), Add(H_1485, ((V)(14D))), ((V)((-6D))));
f_1548.S(string.Concat("<rect x=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1552, 0D)) - (10D * ToNum(k_1547))))))), "\" y=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1552, 1D)) - (12D * ToNum(k_1547))))))), "\" width=\"", ToStr(Call(f1_21, V.Undef, ((V)((20D * ToNum(k_1547)))))), "\" height=\"", ToStr(Call(f1_21, V.Undef, ((V)((12D * ToNum(k_1547)))))), "\" rx=\"", ToStr(Call(f1_21, V.Undef, ((V)((2D * ToNum(k_1547)))))), "\" fill=\"#fff6c8\" stroke=\"#2c2d31\" stroke-width=\"1\"/>")).V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1552, 0D)) - (12D * ToNum(k_1547))))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1552, 1D)) - (12D * ToNum(k_1547))))))), "L", ToStr(Call(f1_21, V.Undef, GetIdx(q_1552, 0D))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1552, 1D)) - (22D * ToNum(k_1547))))))), "L", ToStr(Call(f1_21, V.Undef, Add(GetIdx(q_1552, 0D), ((V)((12D * ToNum(k_1547))))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1552, 1D)) - (12D * ToNum(k_1547))))))), "Z"))), ((V)("#e2554a")), ((V)("#7a2a20")), ((V)(1D)))).V(Call(glowAt_64, V.Undef, Arr(GetIdx(q_1552, 0D), ((V)((ToNum(GetIdx(q_1552, 1D)) - (6D * ToNum(k_1547)))))), ((V)((26D * ToNum(k_1547)))), ((V)("bhG")), ((V)(0.8))));
}
return NewObj(3).Put("defs", defs_1549).Put("front", ((V)(f_1548.Str))).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_1546, V.Undef, ((V)((-56D))), ((V)(0D)), ((V)((-46D)))), Call(p_1546, V.Undef, ((V)(56D)), ((V)(0D)), ((V)(46D))), Call(p_1546, V.Undef, ((V)((-56D))), ((V)(0D)), ((V)(46D))), Call(p_1546, V.Undef, ((V)(56D)), ((V)(0D)), ((V)((-46D)))), Call(p_1546, V.Undef, ((V)(0D)), Add(H_1485, ((V)((SEqN(t_1484, 4D) ? 80D : 70D)))), ((V)((-10D))))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1486;
return default;
}, 1, "", true));
Set(N_42, "bCooler", Fn((V _arrowThis1560, int _argc1553, V S_1559, V _a1556, V _a1557, V _a1558, V[] _rest1554) => {
V t_1561 = default;
V D_1562 = default;
t_1561 = Call(T_48, V.Undef, S_1559);
D_1562 = NewObj(4).Put("w", ((V)(70D))).Put("d", ((V)(50D))).Put("act", ((V)("treat"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(40D))).V).V;
Set(D_1562, "build", Fn((V _arrowThis1570, int _argc1563, V P_1569, V _a1566, V _a1567, V _a1568, V[] _rest1564) => {
V o_1571 = default;
o_1571 = Arr();
if (SEqN(t_1561, 1D)) {
Invoke(o_1571, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(44D)), ((V)(24D)), ((V)(30D)), ((V)("#f4f1ea")), Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(24D)), ((V)(0D)), ((V)(46D)), ((V)(5D)), ((V)(32D)), ((V)("#e8e4dc")), Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)));
} else {
if (SEqN(t_1561, 2D)) {
Invoke(o_1571, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(48D)), ((V)(26D)), ((V)(32D)), ((V)("#e2554a")), Call(pt_31, V.Undef, NewObj(2).Put("r", ((V)(4D))).Put("bev", ((V)(1.6))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(26D)), ((V)(0D)), ((V)(50D)), ((V)(6D)), ((V)(34D)), ((V)("#ffffff")), Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(4D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(0D)), ((V)(30D)), ((V)(2D)), ((V)(4D)), ((V)("#9aa1a6")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
} else {
if (SEqN(t_1561, 3D)) {
InvokeSpread(o_1571, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(60D)), ((V)(26D)), ((V)(36D)), ((V)("#3fb0c8")), Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(3D))).V))).Spread(Invoke(Arr(Arr(((V)((-24D))), ((V)(16D))), Arr(((V)(24D)), ((V)(16D))), Arr(((V)((-24D))), ((V)((-16D)))), Arr(((V)(24D)), ((V)((-16D))))), "map", Fn((V _arrowThis1583, int _argc1572, V _a1574, V _a1575, V _a1576, V _a1577, V[] _rest1573) => {
V x_1580 = default;
V z_1582 = default;
{ V _t1578 = ListOf(_a1574);
{ V _t1579 = GetIdx(_t1578, 0D);
x_1580 = _t1579; }
{ V _t1581 = GetIdx(_t1578, 1D);
z_1582 = _t1581; }
}
return Call(cyl_14, V.Undef, x_1580, ((V)(0D)), z_1582, ((V)(5D)), ((V)(12D)), ((V)("#3a3d44")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(10D))).V));
}, 1, "", true))).Spread(Invoke(Arr(((V)((-18D))), ((V)(0D)), ((V)(18D))), "map", Fn((V _arrowThis1591, int _argc1584, V x_1590, V _a1587, V _a1588, V _a1589, V[] _rest1585) => {
return Call(ball_15, V.Undef, x_1590, ((V)(44D)), ((V)(0D)), ((V)(7.4)), ((V)("#8a5a2c")), Call(wd_29, V.Undef, NewObj(1).Put("k", ((V)(5D))).V));
}, 1, "", true))).V);
} else {
if (SEqN(t_1561, 4D)) {
InvokeSpread(o_1571, "push", new ArrBuilder().Add(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(40D)), ((V)("#a8683a")), Call(wd_29, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.9))), Arr(((V)(20D)), ((V)(0D)), ((V)(1D))), Arr(((V)(40D)), ((V)(0D)), ((V)(0.9))))).V))).Spread(Invoke(Arr(((V)(8D)), ((V)(32D))), "map", Fn((V _arrowThis1599, int _argc1592, V y_1598, V _a1595, V _a1596, V _a1597, V[] _rest1593) => {
return Call(cyl_14, V.Undef, ((V)(0D)), y_1598, ((V)(0D)), ((V)((22D * 0.98))), ((V)(2D)), ((V)("#3a3d44")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(20D))).V));
}, 1, "", true))).Spread(Invoke(Arr(((V)((-12D))), ((V)(12D))), "map", Fn((V _arrowThis1607, int _argc1600, V x_1606, V _a1603, V _a1604, V _a1605, V[] _rest1601) => {
return Call(cyl_14, V.Undef, x_1606, ((V)(40D)), ((V)(0D)), ((V)(6D)), ((V)(10D)), ((V)("#ffd23f")), Call(pt_31, V.Undef, NewObj(1).Put("n", ((V)(12D))).V));
}, 1, "", true))).V);
} else {
Invoke(o_1571, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(16D)), ((V)(12D)), GOLD_44, Call(mt_28, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(12D)), ((V)(0D)), ((V)(6D)), ((V)(20D)), GOLD_44, Call(mt_28, V.Undef, NewObj(2).Put("n", ((V)(12D))).Put("shine", ((V)(1D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(32D)), ((V)(0D)), ((V)(22D)), ((V)(8D)), GOLD_44, Call(mt_28, V.Undef, NewObj(3).Put("n", ((V)(20D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.6))), Arr(((V)(8D)), ((V)(0D)), ((V)(1D))))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(39D)), ((V)(0D)), ((V)(20D)), ((V)(1D)), ((V)("#9fe8f6")), Call(em_46, V.Undef, NewObj(1).Put("n", ((V)(20D))).V)));
}
}
}
}
return o_1571;
return default;
}, 1, "", true));
Set(D_1562, "fx", Fn((V _arrowThis1615, int _argc1608, V c_1614, V _a1611, V _a1612, V _a1613, V[] _rest1609) => {
V p_1616 = default;
V k_1617 = default;
JsStrBuf f_1618 = null;
p_1616 = Get(c_1614, "p");
k_1617 = Get(c_1614, "k");
f_1618 = new JsStrBuf("");
if (SEqN(t_1561, 1D)) {
f_1618.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, Call(p_1616, V.Undef, ((V)((-16D))), ((V)(18D)), ((V)(15.2))))), "q", ToStr(Call(f1_21, V.Undef, ((V)((4D * ToNum(k_1617)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((3D * ToNum(k_1617)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((8D * ToNum(k_1617)))))), " 0"))), ((V)("none")), ((V)("#b8b0a0")), ((V)(1D))));
}
if (SEqN(t_1561, 3D)) {
Invoke(Arr(((V)((-18D))), ((V)(0D)), ((V)(18D))), "forEach", Fn((V _arrowThis1627, int _argc1619, V x_1625, V i_1626, V _a1623, V _a1624, V[] _rest1620) => {
V q_1628 = default;
q_1628 = Call(p_1616, V.Undef, x_1625, ((V)(50D)), ((V)(0D)));
f_1618.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, q_1628)), "l", ToStr(Call(f1_21, V.Undef, ((V)((((ToNum(i_1626) - 1D) * 3D) * ToNum(k_1617)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)(((-12D) * ToNum(k_1617))))))))), ((V)("none")), GetK(Arr(((V)("#ff6a8a")), ((V)("#ffd23f")), ((V)("#6fd06a"))), i_1626), ((V)(1.6))));
return default;
}, 2, "", true));
}
if (SEqN(t_1561, 4D)) {
Invoke(Arr(((V)((-12D))), ((V)(12D))), "forEach", Fn((V _arrowThis1636, int _argc1629, V x_1635, V _a1632, V _a1633, V _a1634, V[] _rest1630) => {
V q_1637 = default;
q_1637 = Call(p_1616, V.Undef, x_1635, ((V)(50D)), ((V)(0D)));
f_1618.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1637, 0D)) - (4D * ToNum(k_1617))))))), " ", ToStr(Call(f1_21, V.Undef, GetIdx(q_1637, 1D))), "l", ToStr(Call(f1_21, V.Undef, ((V)((2D * ToNum(k_1617)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)(((-7D) * ToNum(k_1617)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((2D * ToNum(k_1617)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((5D * ToNum(k_1617)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((2D * ToNum(k_1617)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)(((-6D) * ToNum(k_1617)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((2D * ToNum(k_1617)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((8D * ToNum(k_1617))))))))), ((V)("#3f9a42")), ((V)("#1e5a2a")), ((V)(0.6))));
return default;
}, 1, "", true));
}
if (SEqN(t_1561, 5D)) {
V a_1638 = default;
V b_1639 = default;
a_1638 = Call(p_1616, V.Undef, ((V)(0D)), ((V)(40D)), ((V)(0D)));
b_1639 = Call(p_1616, V.Undef, ((V)(0D)), ((V)(62D)), ((V)(0D)));
f_1618.V(Invoke(Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis1647, int _argc1640, V i_1646, V _a1643, V _a1644, V _a1645, V[] _rest1641) => {
V e_1648 = default;
e_1648 = Call(p_1616, V.Undef, ((V)((FdLibm.Cos((ToNum(i_1646) * 1.57)) * 18D))), ((V)(40D)), ((V)((FdLibm.Sin((ToNum(i_1646) * 1.57)) * 18D))));
return ((V)(string.Concat("<path d=\"M", ToStr(Call(P2_25, V.Undef, a_1638)), "Q", ToStr(Call(P2_25, V.Undef, b_1639)), " ", ToStr(Call(P2_25, V.Undef, e_1648)), "\" fill=\"none\" stroke=\"#bfeefa\" stroke-width=\"", ToStr(Call(f1_21, V.Undef, ((V)((2D * ToNum(k_1617)))))), "\" stroke-linecap=\"round\" stroke-dasharray=\"4 3\" opacity=\"0.9\">", ToStr(Call(AN_54, V.Undef, ((V)("stroke-dashoffset")), ((V)("0;-14")), ((V)(0.7)))), "</path>")));
return default;
}, 1, "", true)), "join", ((V)(""))));
}
return NewObj(2).Put("front", ((V)(f_1618.Str))).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_1616, V.Undef, ((V)((-40D))), ((V)(0D)), ((V)((-30D)))), Call(p_1616, V.Undef, ((V)(40D)), ((V)(0D)), ((V)(30D))), Call(p_1616, V.Undef, ((V)((-40D))), ((V)(0D)), ((V)(30D))), Call(p_1616, V.Undef, ((V)(40D)), ((V)(0D)), ((V)((-30D)))), Call(p_1616, V.Undef, ((V)(0D)), ((V)((SEqN(t_1561, 5D) ? 66D : 60D))), ((V)(0D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1562;
return default;
}, 1, "", true));
Set(N_42, "bPalm", Fn((V _arrowThis1656, int _argc1649, V S_1655, V _a1652, V _a1653, V _a1654, V[] _rest1650) => {
V t_1657 = default;
V D_1658 = default;
t_1657 = Call(T_48, V.Undef, S_1655);
D_1658 = NewObj(3).Put("w", ((V)((GeN(t_1657, 3D) ? 90D : 50D)))).Put("d", ((V)(50D))).Put("round", ((V)(1D))).V;
Set(D_1658, "build", Fn((V _arrowThis1666, int _argc1659, V P_1665, V _a1662, V _a1663, V _a1664, V[] _rest1660) => {
return Invoke(Arr(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)((GeN(t_1657, 3D) ? 34D : 18D))), ((V)(4D)), SAND_49, Call(pt_31, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.15))), Arr(((V)(4D)), ((V)(0D)), ((V)(0.8))))).V))), "concat", (SEqN(t_1657, 5D) ? Arr(Call(cyl_14, V.Undef, ((V)(0D)), ((V)(4D)), ((V)(0D)), ((V)(14D)), ((V)(1D)), ((V)("#ffe08a")), Call(em_46, V.Undef, NewObj(1).Put("n", ((V)(16D))).V))) : Arr()));
}, 1, "", true));
Set(D_1658, "fx", Fn((V _arrowThis1674, int _argc1667, V c_1673, V _a1670, V _a1671, V _a1672, V[] _rest1668) => {
V p_1675 = default;
V k_1676 = default;
JsStrBuf f_1677 = null;
V bb_1678 = default;
V defs_1679 = default;
V add_1680 = default;
p_1675 = Get(c_1673, "p");
k_1676 = Get(c_1673, "k");
f_1677 = new JsStrBuf("");
bb_1678 = Arr(Call(p_1675, V.Undef, ((V)((-40D))), ((V)(0D)), ((V)((-30D)))), Call(p_1675, V.Undef, ((V)(40D)), ((V)(0D)), ((V)(30D))));
defs_1679 = GLW_63;
add_1680 = Fn((V _arrowThis1688, int _argc1681, V r_1687, V _a1684, V _a1685, V _a1686, V[] _rest1682) => {
f_1677.V(Get(r_1687, "s"));
bb_1678 = Invoke(bb_1678, "concat", Get(r_1687, "pts"));
return default;
}, 1, "", true);
if (SEqN(t_1657, 1D)) {
Call(add_1680, V.Undef, Call(palm_58, V.Undef, p_1675, k_1676, ((V)(0D)), ((V)(0D)), ((V)(62D)), ((V)(22D)), ((V)("p1")), NewObj(5).Put("nf", ((V)(5D))).Put("L", ((V)(22D))).Put("nuts", ((V)(0D))).Put("tw", ((V)(3.2))).Put("leaf", Arr(((V)("#7a9a4a")), ((V)("#8aa85a")))).V));
} else {
if (SEqN(t_1657, 2D)) {
Call(add_1680, V.Undef, Call(palm_58, V.Undef, p_1675, k_1676, ((V)(0D)), ((V)(0D)), ((V)(120D)), ((V)(16D)), ((V)("p2"))));
} else {
if (SEqN(t_1657, 3D)) {
Call(add_1680, V.Undef, Call(palm_58, V.Undef, p_1675, k_1676, ((V)((-18D))), ((V)((-6D))), ((V)(112D)), ((V)((-18D))), ((V)("p3a"))));
Call(add_1680, V.Undef, Call(palm_58, V.Undef, p_1675, k_1676, ((V)(18D)), ((V)(6D)), ((V)(128D)), ((V)(18D)), ((V)("p3b"))));
} else {
if (SEqN(t_1657, 4D)) {
V a_1689 = default;
V b_1690 = default;
V cc_1691 = default;
V lt_1692 = default;
Call(add_1680, V.Undef, Call(palm_58, V.Undef, p_1675, k_1676, ((V)((-26D))), ((V)((-8D))), ((V)(108D)), ((V)((-16D))), ((V)("p4a"))));
Call(add_1680, V.Undef, Call(palm_58, V.Undef, p_1675, k_1676, ((V)(24D)), ((V)((-4D))), ((V)(126D)), ((V)(14D)), ((V)("p4b"))));
Call(add_1680, V.Undef, Call(palm_58, V.Undef, p_1675, k_1676, ((V)(0D)), ((V)(14D)), ((V)(92D)), ((V)(6D)), ((V)("p4c")), NewObj(1).Put("nuts", ((V)(2D))).V));
a_1689 = Call(p_1675, V.Undef, ((V)((-42D))), ((V)(96D)), ((V)((-12D))));
b_1690 = Call(p_1675, V.Undef, ((V)(38D)), ((V)(112D)), ((V)((-2D))));
cc_1691 = Call(p_1675, V.Undef, ((V)(6D)), ((V)(86D)), ((V)(16D)));
lt_1692 = Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, a_1689)), "Q", ToStr(Call(P2_25, V.Undef, Call(p_1675, V.Undef, ((V)(0D)), ((V)(82D)), ((V)((-6D)))))), " ", ToStr(Call(P2_25, V.Undef, b_1690)), "M", ToStr(Call(P2_25, V.Undef, a_1689)), "Q", ToStr(Call(P2_25, V.Undef, Call(p_1675, V.Undef, ((V)((-18D))), ((V)(76D)), ((V)(4D))))), " ", ToStr(Call(P2_25, V.Undef, cc_1691))))), ((V)("none")), ((V)("#4a3a30")), ((V)(0.8)));
Call(rep_22, V.Undef, ((V)(8D)), Fn((V _arrowThis1700, int _argc1693, V i_1699, V _a1696, V _a1697, V _a1698, V[] _rest1694) => {
double u_1701 = 0;
V q_1702 = default;
u_1701 = (ToNum(Add(i_1699, ((V)(0.5)))) / 8D);
q_1702 = Arr(Add(GetIdx(a_1689, 0D), ((V)(((ToNum(GetIdx(b_1690, 0D)) - ToNum(GetIdx(a_1689, 0D))) * u_1701)))), Add(Add(GetIdx(a_1689, 1D), ((V)(((ToNum(GetIdx(b_1690, 1D)) - ToNum(GetIdx(a_1689, 1D))) * u_1701)))), ((V)(((FdLibm.Sin((u_1701 * PI_43)) * 10D) * ToNum(k_1676))))));
lt_1692 = ((V)(JsStrBuf.Begin().V(lt_1692).S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_1702, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, Add(GetIdx(q_1702, 1D), ((V)(2D))))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((2D * ToNum(k_1676)))))), "\" fill=\"", ToStr(GetIdx(Arr(((V)("#ff9d4a")), ((V)("#ffd66b")), ((V)("#6ac8ff")), ((V)("#a6f06a"))), (ToNum(i_1699) % 4D))), "\">", ToStr(Call(AN_54, V.Undef, ((V)("opacity")), ((V)("1;0.4;1")), ((V)(1.4)), ((V)(((-ToNum(i_1699)) * 0.2))))), "</circle>")).End()));
return default;
}, 1, "", true));
f_1677.V(lt_1692);
} else {
Call(add_1680, V.Undef, Call(palm_58, V.Undef, p_1675, k_1676, ((V)(0D)), ((V)(0D)), ((V)(124D)), ((V)(14D)), ((V)("p5")), NewObj(3).Put("trunk", ((V)("#e2b14a"))).Put("leaf", Arr(((V)("#3fae7a")), ((V)("#e8c84a")), ((V)("#4fc08a")))).Put("nutC", ((V)("#fff6c8"))).V));
f_1677.V(Add(Call(glowAt_64, V.Undef, Call(p_1675, V.Undef, ((V)(14D)), ((V)(124D)), ((V)(4D))), ((V)((54D * ToNum(k_1676)))), ((V)("bhG")), ((V)(0.6))), Invoke(Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis1710, int _argc1703, V i_1709, V _a1706, V _a1707, V _a1708, V[] _rest1704) => {
return ((V)(string.Concat("<circle r=\"", ToStr(Call(f1_21, V.Undef, ((V)((1.4 * ToNum(k_1676)))))), "\" fill=\"#fff6c8\"><animateMotion dur=\"", NumStr((3D + (ToNum(i_1709) * 0.5))), "s\" begin=\"", NumStr(((-ToNum(i_1709)) * 0.6)), "s\" repeatCount=\"indefinite\" path=\"M", ToStr(Call(P2_25, V.Undef, Call(p_1675, V.Undef, ((V)(((-20D) + (ToNum(i_1709) * 8D)))), ((V)(20D)), ((V)(6D))))), "L", ToStr(Call(P2_25, V.Undef, Call(p_1675, V.Undef, ((V)(((-24D) + (ToNum(i_1709) * 9D)))), ((V)(120D)), ((V)(6D))))), "\"/>", ToStr(Call(AN_54, V.Undef, ((V)("opacity")), ((V)("0;1;0")), ((V)((3D + (ToNum(i_1709) * 0.5)))), ((V)(((-ToNum(i_1709)) * 0.6))))), "</circle>")));
}, 1, "", true)), "join", ((V)("")))));
}
}
}
}
return NewObj(3).Put("defs", defs_1679).Put("front", ((V)(f_1677.Str))).Put("bb", Call(bbOf_27, V.Undef, bb_1678, ((V)(6D)))).V;
return default;
}, 1, "", true));
return D_1658;
return default;
}, 1, "", true));
Set(N_42, "bHammock", Fn((V _arrowThis1718, int _argc1711, V S_1717, V _a1714, V _a1715, V _a1716, V[] _rest1712) => {
V t_1719 = default;
double XP_1720 = 0;
double HP_1721 = 0;
V D_1722 = default;
t_1719 = Call(T_48, V.Undef, S_1717);
XP_1720 = 62D;
HP_1721 = 58D;
D_1722 = NewObj(4).Put("w", ((V)(160D))).Put("d", ((V)(50D))).Put("act", ((V)("nap"))).Put("seats", Arr(NewObj(4).Put("x", ((V)(0D))).Put("z", ((V)(0D))).Put("h", ((V)(22D))).Put("k", ((V)("nap"))).V)).V;
Set(D_1722, "build", Fn((V _arrowThis1730, int _argc1723, V P_1729, V _a1726, V _a1727, V _a1728, V[] _rest1724) => {
V o_1731 = default;
o_1731 = Arr();
if (SEqN(t_1719, 1D)) {
Invoke(Arr(((V)((-XP_1720))), ((V)(XP_1720))), "forEach", Fn((V _arrowThis1740, int _argc1732, V x_1738, V i_1739, V _a1736, V _a1737, V[] _rest1733) => {
return Invoke(o_1731, "push", Call(cyl_14, V.Undef, x_1738, ((V)(0D)), ((V)(0D)), ((V)(3.4)), ((V)((HP_1721 + (Truthy(i_1739) ? 2D : (-2D))))), ((V)("#a8977c")), Call(wd_29, V.Undef, NewObj(2).Put("n", ((V)(8D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(HP_1721)), ((V)(0D)), ((V)(0.75))))).V)));
}, 2, "", true));
} else {
if (SEqN(t_1719, 2D)) {
Invoke(Arr(((V)((-XP_1720))), ((V)(XP_1720))), "forEach", Fn((V _arrowThis1748, int _argc1741, V x_1747, V _a1744, V _a1745, V _a1746, V[] _rest1742) => {
return Invoke(o_1731, "push", Call(box_12, V.Undef, x_1747, ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(HP_1721)), ((V)(4D)), ((V)("#3e4046")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, x_1747, ((V)(0D)), ((V)(0D)), ((V)(6D)), ((V)(3D)), ((V)(36D)), ((V)("#3e4046")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}, 1, "", true));
Invoke(o_1731, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(((2D * XP_1720) + 6D))), ((V)(3D)), ((V)(4D)), ((V)("#3e4046")), Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
} else {
if (SEqN(t_1719, 4D)) {
Invoke(Arr(((V)((-XP_1720))), ((V)(XP_1720))), "forEach", Fn((V _arrowThis1756, int _argc1749, V x_1755, V _a1752, V _a1753, V _a1754, V[] _rest1750) => {
return Invoke(o_1731, "push", Call(cyl_14, V.Undef, x_1755, ((V)(0D)), ((V)(0D)), ((V)(3D)), ((V)(90D)), ((V)("#c49a62")), Call(wd_29, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)));
}, 1, "", true));
} else {
if (SEqN(t_1719, 5D)) {
Invoke(Arr(((V)((-XP_1720))), ((V)(XP_1720))), "forEach", Fn((V _arrowThis1764, int _argc1757, V x_1763, V _a1760, V _a1761, V _a1762, V[] _rest1758) => {
return Invoke(o_1731, "push", Call(cyl_14, V.Undef, x_1763, ((V)(0D)), ((V)(0D)), ((V)(2.4)), ((V)((HP_1721 + 8D))), ((V)("#f4f1ea")), Call(pt_31, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(ball_15, V.Undef, x_1763, ((V)((HP_1721 + 10D))), ((V)(0D)), ((V)(4D)), ((V)("#fff6c8")), Call(em_46, V.Undef, NewObj(1).Put("k", ((V)(4D))).V)));
}, 1, "", true));
}
}
}
}
return o_1731;
return default;
}, 1, "", true));
Set(D_1722, "fx", Fn((V _arrowThis1772, int _argc1765, V c_1771, V _a1768, V _a1769, V _a1770, V[] _rest1766) => {
V p_1773 = default;
V k_1774 = default;
JsStrBuf f_1775 = null;
V bb_1776 = default;
V defs_1777 = default;
double W_1778 = 0;
double sag_1779 = 0;
V cols_1780 = default;
V edge_1781 = default;
V A_1782 = default;
V Bk_1783 = default;
JsStrBuf band_1784 = null;
p_1773 = Get(c_1771, "p");
k_1774 = Get(c_1771, "k");
f_1775 = new JsStrBuf("");
bb_1776 = Arr(Call(p_1773, V.Undef, ((V)((-90D))), ((V)(0D)), ((V)((-30D)))), Call(p_1773, V.Undef, ((V)(90D)), ((V)(0D)), ((V)(30D))), Call(p_1773, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(0D))));
defs_1777 = GLW_63;
if (SEqN(t_1719, 3D)) {
Invoke(Arr(Arr(((V)((-XP_1720))), ((V)("h3a")), ((V)((-10D)))), Arr(((V)(XP_1720)), ((V)("h3b")), ((V)(12D)))), "forEach", Fn((V _arrowThis1798, int _argc1785, V _a1787, V _a1788, V _a1789, V _a1790, V[] _rest1786) => {
V r_1799 = default;
V x_1793 = default;
V sd_1795 = default;
V l_1797 = default;
{ V _t1791 = ListOf(_a1787);
{ V _t1792 = GetIdx(_t1791, 0D);
x_1793 = _t1792; }
{ V _t1794 = GetIdx(_t1791, 1D);
sd_1795 = _t1794; }
{ V _t1796 = GetIdx(_t1791, 2D);
l_1797 = _t1796; }
}
r_1799 = Call(palm_58, V.Undef, p_1773, k_1774, x_1793, ((V)(0D)), ((V)(104D)), l_1797, sd_1795, NewObj(1).Put("nuts", ((V)(2D))).V);
f_1775.V(Get(r_1799, "s"));
bb_1776 = Invoke(bb_1776, "concat", Get(r_1799, "pts"));
return default;
}, 1, "", true));
}
W_1778 = 16D;
sag_1779 = 24D;
cols_1780 = GetIdx(Arr(Arr(((V)("#c9b896")), ((V)("#a89878"))), Arr(((V)("#ffffff")), ((V)("#3fb0c8"))), Arr(((V)("#e8d2a0")), ((V)("#c9a870"))), Arr(((V)("#f6efe0")), ((V)("#e3946a"))), Arr(((V)("#ffffff")), ((V)("#e6f0ff")))), (ToNum(t_1719) - 1D));
edge_1781 = Fn((V _arrowThis1807, int _argc1800, V z_1806, V _a1803, V _a1804, V _a1805, V[] _rest1801) => {
return Call(rep_22, V.Undef, ((V)(13D)), Fn((V _arrowThis1815, int _argc1808, V i_1814, V _a1811, V _a1812, V _a1813, V[] _rest1809) => {
double u_1816 = 0;
double x_1817 = 0;
u_1816 = (ToNum(i_1814) / 12D);
x_1817 = (((-XP_1720) + 6D) + (((2D * XP_1720) - 12D) * u_1816));
return Arr(((V)(x_1817)), ((V)(((HP_1721 - 4D) - (FdLibm.Sin((u_1816 * PI_43)) * sag_1779)))), z_1806);
return default;
}, 1, "", true));
}, 1, "", true);
A_1782 = Call(edge_1781, V.Undef, ((V)(((-W_1778) / 2D))));
Bk_1783 = Call(edge_1781, V.Undef, ((V)((W_1778 / 2D))));
band_1784 = new JsStrBuf("");
Call(rep_22, V.Undef, ((V)(12D)), Fn((V _arrowThis1825, int _argc1818, V i_1824, V _a1821, V _a1822, V _a1823, V[] _rest1819) => {
V q_1826 = default;
q_1826 = Arr(GetK(A_1782, i_1824), GetK(A_1782, Add(i_1824, ((V)(1D)))), GetK(Bk_1783, Add(i_1824, ((V)(1D)))), GetK(Bk_1783, i_1824));
band_1784.V(Call(PP_51, V.Undef, Call(PQ_52, V.Undef, p_1773, q_1826), GetIdx(cols_1780, (Truthy((((V)((ToNum(i_1824) % 2D))) is var _t1827 && !Truthy(_t1827) ? _t1827 : (SEqN(t_1719, 2D) ? V.True : V.False))) ? 1D : 0D)), Call(ink_56, V.Undef, GetIdx(cols_1780, 0D)), ((V)(0.4))));
return default;
}, 1, "", true));
f_1775.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, Call(p_1773, V.Undef, ((V)((-XP_1720))), ((V)(HP_1721)), ((V)(0D))))), "L", ToStr(Call(P2_25, V.Undef, CallSpread(p_1773, V.Undef, new ArrBuilder().Spread(GetIdx(A_1782, 0D)).V))), "M", ToStr(Call(P2_25, V.Undef, Call(p_1773, V.Undef, ((V)((-XP_1720))), ((V)(HP_1721)), ((V)(0D))))), "L", ToStr(Call(P2_25, V.Undef, CallSpread(p_1773, V.Undef, new ArrBuilder().Spread(GetIdx(Bk_1783, 0D)).V))), "M", ToStr(Call(P2_25, V.Undef, Call(p_1773, V.Undef, ((V)(XP_1720)), ((V)(HP_1721)), ((V)(0D))))), "L", ToStr(Call(P2_25, V.Undef, CallSpread(p_1773, V.Undef, new ArrBuilder().Spread(GetIdx(A_1782, 12D)).V))), "M", ToStr(Call(P2_25, V.Undef, Call(p_1773, V.Undef, ((V)(XP_1720)), ((V)(HP_1721)), ((V)(0D))))), "L", ToStr(Call(P2_25, V.Undef, CallSpread(p_1773, V.Undef, new ArrBuilder().Spread(GetIdx(Bk_1783, 12D)).V)))))), ((V)("none")), ((V)("#8a6a48")), ((V)(1D)))).S(band_1784.Str);
if (SEqN(t_1719, 1D)) {
f_1775.V(Call(PP_51, V.Undef, Invoke(Call(rep_22, V.Undef, ((V)(12D)), Fn((V _arrowThis1835, int _argc1828, V i_1834, V _a1831, V _a1832, V _a1833, V[] _rest1829) => {
return ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, CallSpread(p_1773, V.Undef, new ArrBuilder().Spread(GetK(A_1782, i_1834)).V))), "L", ToStr(Call(P2_25, V.Undef, CallSpread(p_1773, V.Undef, new ArrBuilder().Spread(GetK(Bk_1783, Add(i_1834, ((V)(1D))))).V))), "M", ToStr(Call(P2_25, V.Undef, CallSpread(p_1773, V.Undef, new ArrBuilder().Spread(GetK(Bk_1783, i_1834)).V))), "L", ToStr(Call(P2_25, V.Undef, CallSpread(p_1773, V.Undef, new ArrBuilder().Spread(GetK(A_1782, Add(i_1834, ((V)(1D))))).V))))));
}, 1, "", true)), "join", ((V)(""))), ((V)("none")), ((V)("#6a5a44")), ((V)(0.6))));
}
if (SEqN(t_1719, 4D)) {
f_1775.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, Call(p_1773, V.Undef, ((V)((-XP_1720))), ((V)(90D)), ((V)(0D))))), "Q", ToStr(Call(P2_25, V.Undef, Call(p_1773, V.Undef, ((V)(0D)), ((V)(78D)), ((V)((-24D)))))), " ", ToStr(Call(P2_25, V.Undef, Call(p_1773, V.Undef, ((V)(XP_1720)), ((V)(90D)), ((V)(0D))))), "L", ToStr(Call(P2_25, V.Undef, Call(p_1773, V.Undef, ((V)(0D)), ((V)(70D)), ((V)(30D))))), "Z"))), ((V)("#fffaf1")), ((V)("#c9b896")), ((V)(1D)), ((V)(" opacity=\"0.92\""))));
Call(rep_22, V.Undef, ((V)(10D)), Fn((V _arrowThis1843, int _argc1836, V i_1842, V _a1839, V _a1840, V _a1841, V[] _rest1837) => {
double u_1844 = 0;
V q_1845 = default;
u_1844 = (ToNum(Add(i_1842, ((V)(0.5)))) / 10D);
q_1845 = Call(p_1773, V.Undef, ((V)(((-XP_1720) + ((2D * XP_1720) * u_1844)))), ((V)(((HP_1721 - 4D) - (FdLibm.Sin((u_1844 * PI_43)) * sag_1779)))), ((V)((W_1778 / 2D))));
f_1775.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, q_1845)), "l0 ", ToStr(Call(f1_21, V.Undef, ((V)((8D * ToNum(k_1774))))))))), ((V)("none")), ((V)("#e3946a")), ((V)(1.2))));
return default;
}, 1, "", true));
}
if (SEqN(t_1719, 5D)) {
JsStrBuf fl_1846 = null;
Call(rep_22, V.Undef, ((V)(6D)), Fn((V _arrowThis1854, int _argc1847, V i_1853, V _a1850, V _a1851, V _a1852, V[] _rest1848) => {
double u_1855 = 0;
V q_1856 = default;
u_1855 = (ToNum(Add(i_1853, ((V)(0.5)))) / 6D);
q_1856 = Call(p_1773, V.Undef, ((V)(((-XP_1720) + ((2D * XP_1720) * u_1855)))), ((V)(((HP_1721 - 6D) - (FdLibm.Sin((u_1855 * PI_43)) * sag_1779)))), ((V)(((W_1778 / 2D) + 2D))));
f_1775.S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_1856, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, Add(GetIdx(q_1856, 1D), ((V)(3D))))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((5D * ToNum(k_1774)))))), "\" fill=\"#ffffff\" opacity=\"0.9\"/>"));
return default;
}, 1, "", true));
fl_1846 = new JsStrBuf("");
Call(rep_22, V.Undef, ((V)(12D)), Fn((V _arrowThis1864, int _argc1857, V i_1863, V _a1860, V _a1861, V _a1862, V[] _rest1858) => {
double u_1865 = 0;
V q_1866 = default;
u_1865 = (ToNum(Add(i_1863, ((V)(0.5)))) / 12D);
q_1866 = Call(p_1773, V.Undef, ((V)(((-XP_1720) + ((2D * XP_1720) * u_1865)))), ((V)(((HP_1721 + 8D) - (FdLibm.Sin((u_1865 * PI_43)) * 8D)))), ((V)(0D)));
fl_1846.S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_1866, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_1866, 1D))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((1.6 * ToNum(k_1774)))))), "\" fill=\"#fff6c8\">", ToStr(Call(AN_54, V.Undef, ((V)("opacity")), ((V)("1;0.3;1")), ((V)(1.6)), ((V)(((-ToNum(i_1863)) * 0.13))))), "</circle>"));
return default;
}, 1, "", true));
f_1775.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, Call(p_1773, V.Undef, ((V)((-XP_1720))), ((V)((HP_1721 + 8D))), ((V)(0D))))), "Q", ToStr(Call(P2_25, V.Undef, Call(p_1773, V.Undef, ((V)(0D)), ((V)(HP_1721)), ((V)(0D))))), " ", ToStr(Call(P2_25, V.Undef, Call(p_1773, V.Undef, ((V)(XP_1720)), ((V)((HP_1721 + 8D))), ((V)(0D)))))))), ((V)("none")), ((V)("#6a5a4a")), ((V)(0.6)))).S(fl_1846.Str);
}
return NewObj(3).Put("defs", defs_1777).Put("front", ((V)(f_1775.Str))).Put("bb", Call(bbOf_27, V.Undef, bb_1776, ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1722;
return default;
}, 1, "", true));
Set(N_42, "bCabana", Fn((V _arrowThis1874, int _argc1867, V S_1873, V _a1870, V _a1871, V _a1872, V[] _rest1868) => {
V t_1875 = default;
double W_1876 = 0;
double DZ_1877 = 0;
V H_1878 = default;
V D_1879 = default;
t_1875 = Call(T_48, V.Undef, S_1873);
W_1876 = 50D;
DZ_1877 = 34D;
H_1878 = GetIdx(Arr(((V)(58D)), ((V)(54D)), ((V)(78D)), ((V)(76D)), ((V)(84D))), (ToNum(t_1875) - 1D));
D_1879 = NewObj(4).Put("w", ((V)(130D))).Put("d", ((V)(100D))).Put("act", ((V)("nap"))).Put("seats", Arr(NewObj(4).Put("x", ((V)((-18D)))).Put("z", ((V)(4D))).Put("h", ((V)((GeN(t_1875, 3D) ? 16D : 3D)))).Put("k", ((V)("nap"))).V, NewObj(4).Put("x", ((V)(20D))).Put("z", ((V)(4D))).Put("h", ((V)((GeN(t_1875, 3D) ? 16D : 3D)))).Put("k", ((V)("sit"))).V)).V;
Set(D_1879, "build", Fn((V _arrowThis1887, int _argc1880, V P_1886, V _a1883, V _a1884, V _a1885, V[] _rest1881) => {
V o_1888 = default;
V post_1889 = default;
o_1888 = Arr();
post_1889 = GetK(NewObj(4).Put("1", ((V)("#9a8f80"))).Put("3", ((V)("#ffffff"))).Put("4", ((V)("#8a5a2c"))).Put("5", GOLD_44).V, t_1875);
if (Truthy(post_1889)) {
Invoke(Arr(Arr(((V)((-W_1876))), ((V)((-DZ_1877)))), Arr(((V)(W_1876)), ((V)((-DZ_1877)))), Arr(((V)((-W_1876))), ((V)(DZ_1877))), Arr(((V)(W_1876)), ((V)(DZ_1877)))), "forEach", Fn((V _arrowThis1901, int _argc1890, V _a1892, V _a1893, V _a1894, V _a1895, V[] _rest1891) => {
V x_1898 = default;
V z_1900 = default;
{ V _t1896 = ListOf(_a1892);
{ V _t1897 = GetIdx(_t1896, 0D);
x_1898 = _t1897; }
{ V _t1899 = GetIdx(_t1896, 1D);
z_1900 = _t1899; }
}
return Invoke(o_1888, "push", Call(cyl_14, V.Undef, x_1898, ((V)(0D)), z_1900, ((V)((SEqN(t_1875, 1D) ? 1.6 : 2.6))), H_1878, post_1889, (SEqN(t_1875, 5D) ? Call(mt_28, V.Undef, NewObj(2).Put("n", ((V)(10D))).Put("shine", ((V)(1D))).V) : Call(wd_29, V.Undef, NewObj(1).Put("n", ((V)(8D))).V))));
}, 1, "", true));
}
if (SEqN(t_1875, 2D)) {
Invoke(o_1888, "push", Call(ball_15, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(56D)), ((V)("#3fb0c8")), Call(fb_47, V.Undef, NewObj(4).Put("sy", ((V)(0.9))).Put("sz", ((V)(0.7))).Put("k", ((V)(6D))).Put("n", ((V)(22D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(100D)), ((V)(1.4)), ((V)(70D)), ((V)("#2f8aa8")), Call(fb_47, V.Undef, NewObj(1).Put("r", ((V)(3D))).V)));
}
if (GeN(t_1875, 3D)) {
InvokeSpread(o_1888, "push", new ArrBuilder().Add(Call(cush_13, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(((2D * W_1876) - 8D))), ((V)(14D)), ((V)(((2D * DZ_1877) - 12D))), ((V)((SEqN(t_1875, 5D) ? "#f6e2b6" : "#ffffff"))), Call(fb_47, V.Undef))).Spread(Invoke(Arr(((V)((-24D))), ((V)(0D)), ((V)(24D))), "map", Fn((V _arrowThis1910, int _argc1902, V x_1908, V i_1909, V _a1906, V _a1907, V[] _rest1903) => {
return Call(ball_15, V.Undef, x_1908, ((V)(18D)), ((V)((-18D))), ((V)(7D)), GetK(Arr(((V)("#3fb0c8")), ((V)("#ffd66b")), ((V)("#e3946a"))), i_1909), Call(fb_47, V.Undef, NewObj(4).Put("sx", ((V)(1.5))).Put("sy", ((V)(1.1))).Put("sz", ((V)(0.7))).Put("k", ((V)(4D))).V));
}, 2, "", true))).V);
} else {
if (SEqN(t_1875, 1D)) {
Invoke(o_1888, "push", Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(80D)), ((V)(1.2)), ((V)(56D)), ((V)("#d8d0c0")), Call(fb_47, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
}
}
if (SEqN(t_1875, 3D)) {
Invoke(o_1888, "push", Call(box_12, V.Undef, ((V)(0D)), H_1878, ((V)(0D)), ((V)(((2D * W_1876) + 8D))), ((V)(4D)), ((V)(((2D * DZ_1877) + 8D))), ((V)("#ffffff")), Call(fb_47, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)));
}
return o_1888;
return default;
}, 1, "", true));
Set(D_1879, "fx", Fn((V _arrowThis1918, int _argc1911, V c_1917, V _a1914, V _a1915, V _a1916, V[] _rest1912) => {
V p_1919 = default;
V k_1920 = default;
JsStrBuf f_1921 = null;
V defs_1922 = default;
p_1919 = Get(c_1917, "p");
k_1920 = Get(c_1917, "k");
f_1921 = new JsStrBuf("");
defs_1922 = GLW_63;
if (SEqN(t_1875, 1D)) {
f_1921.V(Add(Call(PP_51, V.Undef, Call(PQ_52, V.Undef, p_1919, Arr(Arr(((V)(((-W_1876) - 4D))), Add(H_1878, ((V)(2D))), ((V)(((-DZ_1877) - 4D)))), Arr(((V)((W_1876 + 4D))), Add(H_1878, ((V)(2D))), ((V)(((-DZ_1877) - 4D)))), Arr(((V)((W_1876 + 6D))), ((V)((ToNum(H_1878) - 10D))), ((V)((DZ_1877 + 8D)))), Arr(((V)(((-W_1876) - 6D))), ((V)((ToNum(H_1878) - 14D))), ((V)((DZ_1877 + 6D)))))), ((V)("#efe8d8")), ((V)("#b8ae9a")), ((V)(1D)), ((V)(" opacity=\"0.95\""))), Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, Call(p_1919, V.Undef, ((V)(((-W_1876) + 10D))), ((V)((ToNum(H_1878) - 6D))), ((V)(0D))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((10D * ToNum(k_1920)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((2D * ToNum(k_1920))))))))), ((V)("none")), ((V)("#d8a0a0")), ((V)(2D)))));
}
if (SEqN(t_1875, 2D)) {
V q_1923 = default;
q_1923 = Call(p_1919, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(40D)));
f_1921.V(Add(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1923, 0D)) - (12D * ToNum(k_1920))))))), " ", ToStr(Call(f1_21, V.Undef, Add(GetIdx(q_1923, 1D), ((V)((12D * ToNum(k_1920))))))), "Q", ToStr(Call(f1_21, V.Undef, GetIdx(q_1923, 0D))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1923, 1D)) - (18D * ToNum(k_1920))))))), " ", ToStr(Call(f1_21, V.Undef, Add(GetIdx(q_1923, 0D), ((V)((12D * ToNum(k_1920))))))), " ", ToStr(Call(f1_21, V.Undef, Add(GetIdx(q_1923, 1D), ((V)((12D * ToNum(k_1920))))))), "Z"))), ((V)("#1e5a72")), ((V)("#123a4a")), ((V)(0.8))), Invoke(Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis1931, int _argc1924, V i_1930, V _a1927, V _a1928, V _a1929, V[] _rest1925) => {
return Call(PP_51, V.Undef, Call(PQ_52, V.Undef, p_1919, Call(rep_22, V.Undef, ((V)(9D)), Fn((V _arrowThis1939, int _argc1932, V j_1938, V _a1935, V _a1936, V _a1937, V[] _rest1933) => {
double a_1940 = 0;
double r_1941 = 0;
a_1940 = (((-PI_43) / 2D) + ((ToNum(j_1938) / 8D) * PI_43));
r_1941 = 56D;
return Arr(((V)((((FdLibm.Cos(a_1940) * r_1941) * 0.3) * (ToNum(i_1930) - 2D)))), ((V)((FdLibm.Sin((a_1940 + (PI_43 / 2D))) * 50D))), ((V)((FdLibm.Cos(a_1940) * 0D))));
return default;
}, 1, "", true))), ((V)("none")), ((V)("#ffffff")), ((V)(0D)), ((V)("")));
}, 1, "", true)), "join", ((V)("")))));
}
if (SEqN(t_1875, 3D)) {
Invoke(Arr(Arr(((V)((-W_1876))), ((V)((-DZ_1877)))), Arr(((V)(W_1876)), ((V)((-DZ_1877)))), Arr(((V)((-W_1876))), ((V)(DZ_1877))), Arr(((V)(W_1876)), ((V)(DZ_1877)))), "forEach", Fn((V _arrowThis1954, int _argc1942, V _a1944, V i_1948, V _a1946, V _a1947, V[] _rest1943) => {
V a_1955 = default;
V b_1956 = default;
V x_1951 = default;
V z_1953 = default;
{ V _t1949 = ListOf(_a1944);
{ V _t1950 = GetIdx(_t1949, 0D);
x_1951 = _t1950; }
{ V _t1952 = GetIdx(_t1949, 1D);
z_1953 = _t1952; }
}
a_1955 = Call(p_1919, V.Undef, x_1951, H_1878, z_1953);
b_1956 = Call(p_1919, V.Undef, Add(x_1951, ((V)((LtN(x_1951, 0D) ? 10D : (-10D))))), ((V)((ToNum(H_1878) * 0.45))), z_1953);
f_1921.S(string.Concat("<g>", ToStr(Call(sway_55, V.Undef, a_1955, ((V)(1.6)), ((V)(4D)), ((V)((-ToNum(i_1948)))))), ToStr(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, a_1955)), "Q", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(b_1956, 0D)) - (4D * ToNum(k_1920))))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(Add(GetIdx(a_1955, 1D), GetIdx(b_1956, 1D))) / 2D))))), " ", ToStr(Call(P2_25, V.Undef, b_1956)), "Q", ToStr(Call(f1_21, V.Undef, Add(GetIdx(b_1956, 0D), ((V)((2D * ToNum(k_1920))))))), " ", ToStr(Call(f1_21, V.Undef, Add(GetIdx(b_1956, 1D), ((V)((14D * ToNum(k_1920))))))), " ", ToStr(Call(P2_25, V.Undef, Call(p_1919, V.Undef, x_1951, ((V)(0D)), z_1953))), "L", ToStr(Call(f1_21, V.Undef, Add(GetIdx(Call(p_1919, V.Undef, x_1951, ((V)(0D)), z_1953), 0D), ((V)(((LtN(x_1951, 0D) ? (-3D) : 3D) * ToNum(k_1920))))))), " ", ToStr(Call(f1_21, V.Undef, GetIdx(Call(p_1919, V.Undef, x_1951, ((V)(0D)), z_1953), 1D))), "Q", ToStr(Call(P2_25, V.Undef, Call(p_1919, V.Undef, x_1951, ((V)((ToNum(H_1878) * 0.6))), z_1953))), " ", ToStr(Call(f1_21, V.Undef, Add(GetIdx(a_1955, 0D), ((V)(((LtN(x_1951, 0D) ? (-2D) : 2D) * ToNum(k_1920))))))), " ", ToStr(Call(f1_21, V.Undef, GetIdx(a_1955, 1D))), "Z"))), ((V)("#fffaf6")), ((V)("#d8d0c4")), ((V)(0.8)), ((V)(" opacity=\"0.95\"")))), "</g>"));
return default;
}, 2, "", true));
}
if (SEqN(t_1875, 4D)) {
f_1921.V(Call(cone_57, V.Undef, p_1919, k_1920, NewObj(9).Put("y", H_1878).Put("h", ((V)(26D))).Put("R", ((V)(76D))).Put("n", ((V)(4D))).Put("a0", ((V)((PI_43 / 4D)))).Put("cols", Arr(((V)("#d8b46a")), ((V)("#c9a45a")))).Put("fringe", ((V)("#b8924a"))).Put("droop", ((V)(0D))).Put("fl", ((V)(10D))).V));
}
if (SEqN(t_1875, 5D)) {
V q_1957 = default;
f_1921.V(Call(cone_57, V.Undef, p_1919, k_1920, NewObj(7).Put("y", H_1878).Put("h", ((V)(30D))).Put("R", ((V)(70D))).Put("n", ((V)(8D))).Put("cols", Arr(((V)("#f6efe0")), ((V)("#e8d6f0")))).Put("scallop", ((V)(1D))).Put("tassel", GOLD_44).V));
q_1957 = Call(p_1919, V.Undef, ((V)(0D)), Add(H_1878, ((V)(30D))), ((V)(0D)));
f_1921.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, q_1957)), "l0 ", ToStr(Call(f1_21, V.Undef, ((V)(((-10D) * ToNum(k_1920))))))))), ((V)("none")), GOLD_44, ((V)(2D)))).S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_1957, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(q_1957, 1D)) - (12D * ToNum(k_1920))))))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((3D * ToNum(k_1920)))))), "\" fill=\"", ToStr(GOLD_44), "\" stroke=\"#8a5d00\" stroke-width=\"0.6\"/>")).V(Call(glowAt_64, V.Undef, Call(p_1919, V.Undef, ((V)(0D)), ((V)(20D)), ((V)(0D))), ((V)((50D * ToNum(k_1920)))), ((V)("bhG")), ((V)(0.4))));
}
return NewObj(3).Put("defs", defs_1922).Put("front", ((V)(f_1921.Str))).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_1919, V.Undef, ((V)(((-W_1876) - 16D))), ((V)(0D)), ((V)(((-DZ_1877) - 16D)))), Call(p_1919, V.Undef, ((V)((W_1876 + 16D))), ((V)(0D)), ((V)((DZ_1877 + 16D)))), Call(p_1919, V.Undef, ((V)(((-W_1876) - 16D))), ((V)(0D)), ((V)((DZ_1877 + 16D)))), Call(p_1919, V.Undef, ((V)((W_1876 + 16D))), ((V)(0D)), ((V)(((-DZ_1877) - 16D)))), Call(p_1919, V.Undef, ((V)(0D)), Add(H_1878, ((V)(44D))), ((V)(0D))), Call(p_1919, V.Undef, ((V)(((-W_1876) - 16D))), H_1878, ((V)(0D))), Call(p_1919, V.Undef, ((V)((W_1876 + 16D))), H_1878, ((V)(0D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1879;
return default;
}, 1, "", true));
Set(N_42, "bShells", Fn((V _arrowThis1965, int _argc1958, V S_1964, V _a1961, V _a1962, V _a1963, V[] _rest1959) => {
V t_1966 = default;
V D_1967 = default;
t_1966 = Call(T_48, V.Undef, S_1964);
D_1967 = NewObj(2).Put("w", ((V)(70D))).Put("d", ((V)(50D))).V;
Set(D_1967, "build", Fn((V _arrowThis1975, int _argc1968, V P_1974, V _a1971, V _a1972, V _a1973, V[] _rest1969) => {
V o_1976 = default;
o_1976 = Arr();
if (SEqN(t_1966, 1D)) {
Invoke(o_1976, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(22D)), ((V)("#dff2f6")), Call(cer_30, V.Undef, NewObj(3).Put("n", ((V)(14D))).Put("shine", ((V)(1D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.94))), Arr(((V)(18D)), ((V)(0D)), ((V)(1D))), Arr(((V)(22D)), ((V)(0D)), ((V)(0.76))))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(8D)), ((V)(3D)), ((V)("#c9cdd2")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(12D))).V)));
} else {
if (SEqN(t_1966, 2D)) {
Invoke(o_1976, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(2.4)), ((V)(70D)), ((V)("#a8977c")), Call(wd_29, V.Undef, NewObj(1).Put("n", ((V)(8D))).V)), Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(7D)), ((V)(2D)), SANDD_50, Call(pt_31, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(box_12, V.Undef, ((V)(0D)), ((V)(66D)), ((V)(0D)), ((V)(34D)), ((V)(3D)), ((V)(3D)), ((V)("#b8a07a")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
} else {
if (SEqN(t_1966, 3D)) {
InvokeSpread(o_1976, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(74D)), ((V)(4D)), ((V)(30D)), ((V)("#a8977c")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(2D))).V))).Spread(Invoke(Arr(((V)((-30D))), ((V)(30D))), "map", Fn((V _arrowThis1984, int _argc1977, V x_1983, V _a1980, V _a1981, V _a1982, V[] _rest1978) => {
return Call(box_12, V.Undef, x_1983, ((V)(4D)), ((V)(0D)), ((V)(6D)), ((V)(34D)), ((V)(26D)), ((V)("#a8977c")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V));
}, 1, "", true))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(66D)), ((V)(3D)), ((V)(26D)), ((V)("#b8a68a")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(1D))).V))).Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(38D)), ((V)(0D)), ((V)(74D)), ((V)(4D)), ((V)(30D)), ((V)("#a8977c")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(2D))).V))).V);
} else {
if (SEqN(t_1966, 4D)) {
InvokeSpread(o_1976, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(56D)), ((V)(26D)), ((V)(36D)), ((V)("#8a5a2c")), Call(wd_29, V.Undef, NewObj(2).Put("r", ((V)(3D))).Put("bev", ((V)(1.6))).V))).Spread(Invoke(Arr(((V)((-20D))), ((V)(20D))), "map", Fn((V _arrowThis1992, int _argc1985, V x_1991, V _a1988, V _a1989, V _a1990, V[] _rest1986) => {
return Call(box_12, V.Undef, x_1991, ((V)(0D)), ((V)(0D)), ((V)(4D)), ((V)(27D)), ((V)(37D)), GOLD_44, Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(1D))).V));
}, 1, "", true))).Add(Call(prismZ_18, V.Undef, ((V)((-18D))), ((V)(18D)), Arr(Arr(((V)((-28D))), ((V)(26D))), Arr(((V)(28D)), ((V)(26D))), Arr(((V)(26D)), ((V)(38D))), Arr(((V)((-26D))), ((V)(38D)))), ((V)("#9a6a38")), Call(wd_29, V.Undef))).V);
} else {
Invoke(o_1976, "push", Call(cyl_14, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(0D)), ((V)(22D)), ((V)(6D)), ((V)("#f4efe6")), Call(cer_30, V.Undef, NewObj(2).Put("n", ((V)(20D))).Put("shine", ((V)(1D))).V)), Call(ball_15, V.Undef, ((V)(0D)), ((V)(22D)), ((V)(0D)), ((V)(18D)), ((V)("#ffd6c8")), Call(cer_30, V.Undef, NewObj(3).Put("sx", ((V)(1.3))).Put("k", ((V)(6D))).Put("shine", ((V)(1D))).V)), Call(cyl_14, V.Undef, ((V)(10D)), ((V)(30D)), ((V)(0D)), ((V)(9D)), ((V)(22D)), ((V)("#ffe6dc")), Call(cer_30, V.Undef, NewObj(3).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1D))), Arr(((V)(22D)), ((V)(0D)), ((V)(0.1))))).Put("shine", ((V)(1D))).V)));
}
}
}
}
return o_1976;
return default;
}, 1, "", true));
Set(D_1967, "fx", Fn((V _arrowThis2000, int _argc1993, V c_1999, V _a1996, V _a1997, V _a1998, V[] _rest1994) => {
V p_2001 = default;
V k_2002 = default;
JsStrBuf f_2003 = null;
V defs_2004 = default;
V SH_2005 = default;
V sh_2006 = default;
p_2001 = Get(c_1999, "p");
k_2002 = Get(c_1999, "k");
f_2003 = new JsStrBuf("");
defs_2004 = GLW_63;
SH_2005 = Get(BE_10, "SHELLK");
sh_2006 = Fn((V _arrowThis2016, int _argc2007, V q_2013, V i_2014, V s_2015, V _a2012, V[] _rest2008) => {
V a_2017 = default;
V b_2018 = default;
{ V _t2019 = GetIdx(SH_2005, (ToNum(i_2014) % ToNum(Get(SH_2005, "length"))));
{ V _t2020 = ListOf(_t2019);
{ V _t2021 = GetIdx(_t2020, 0D);
a_2017 = _t2021; }
{ V _t2022 = GetIdx(_t2020, 1D);
b_2018 = _t2022; }
} }
return ((V)(string.Concat("<g transform=\"translate(", ToStr(Call(P2_25, V.Undef, q_2013)), ") scale(", ToStr(Call(n4_24, V.Undef, ((V)((ToNum(k_2002) * ToNum((s_2015 is var _t2023 && Truthy(_t2023) ? _t2023 : ((V)(1D))))))))), ")\"><path d=\"M-4 1.4C-4-3 4-3 4 1.4Q0 3-4 1.4Z\" fill=\"", ToStr(a_2017), "\" stroke=\"", ToStr(b_2018), "\" stroke-width=\"0.6\"/><path d=\"M0 2V-2M-2 2L-1-2M2 2L1-2\" stroke=\"", ToStr(b_2018), "\" stroke-width=\"0.4\"/></g>")));
return default;
}, 3, "", true);
if (SEqN(t_1966, 1D)) {
Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis2031, int _argc2024, V i_2030, V _a2027, V _a2028, V _a2029, V[] _rest2025) => {
return ((V)(f_2003.V(Call(sh_2006, V.Undef, Call(p_2001, V.Undef, ((V)(((-4D) + ((ToNum(i_2030) % 3D) * 4D)))), ((V)((4D + (ToNum(i_2030) * 3D)))), ((V)(9D))), i_2030, ((V)(0.8)))).Str));
}, 1, "", true));
}
if (SEqN(t_1966, 2D)) {
Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis2039, int _argc2032, V i_2038, V _a2035, V _a2036, V _a2037, V[] _rest2033) => {
double x_2040 = 0;
V a_2041 = default;
V b_2042 = default;
x_2040 = ((-15D) + (ToNum(i_2038) * 7.5));
a_2041 = Call(p_2001, V.Undef, ((V)(x_2040)), ((V)(66D)), ((V)(0D)));
b_2042 = Call(p_2001, V.Undef, ((V)(x_2040)), ((V)((36D + ((ToNum(i_2038) % 2D) * 8D)))), ((V)(0D)));
f_2003.S(string.Concat("<g>", ToStr(Call(sway_55, V.Undef, a_2041, ((V)(6D)), ((V)((2.2 + (ToNum(i_2038) * 0.2)))), ((V)(((-ToNum(i_2038)) * 0.3))))), ToStr(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, a_2041)), "L", ToStr(Call(P2_25, V.Undef, b_2042))))), ((V)("none")), ((V)("#e8dcc0")), ((V)(0.6)))), ToStr(Call(sh_2006, V.Undef, b_2042, i_2038)), ToStr(Call(sh_2006, V.Undef, Arr(GetIdx(b_2042, 0D), ((V)((ToNum(GetIdx(b_2042, 1D)) - (9D * ToNum(k_2002)))))), Add(i_2038, ((V)(2D))), ((V)(0.8)))), "</g>"));
return default;
}, 1, "", true));
}
if (SEqN(t_1966, 3D)) {
Invoke(Arr(Arr(((V)(22D))), Arr(((V)(41D)))), "forEach", Fn((V _arrowThis2052, int _argc2043, V _a2045, V _a2046, V _a2047, V _a2048, V[] _rest2044) => {
V y_2051 = default;
{ V _t2049 = ListOf(_a2045);
{ V _t2050 = GetIdx(_t2049, 0D);
y_2051 = _t2050; }
}
return Call(rep_22, V.Undef, ((V)(5D)), Fn((V _arrowThis2060, int _argc2053, V i_2059, V _a2056, V _a2057, V _a2058, V[] _rest2054) => {
return ((V)(f_2003.V(Call(sh_2006, V.Undef, Call(p_2001, V.Undef, ((V)(((-24D) + (ToNum(i_2059) * 12D)))), Add(y_2051, ((V)(1D))), ((V)(4D))), Add(i_2059, y_2051), ((V)(1.2)))).Str));
}, 1, "", true));
}, 1, "", true));
}
if (SEqN(t_1966, 4D)) {
Call(rep_22, V.Undef, ((V)(7D)), Fn((V _arrowThis2068, int _argc2061, V i_2067, V _a2064, V _a2065, V _a2066, V[] _rest2062) => {
return ((V)(f_2003.V(Call(sh_2006, V.Undef, Call(p_2001, V.Undef, ((V)(((-18D) + (ToNum(i_2067) * 6D)))), ((V)((34D + ((ToNum(i_2067) % 2D) * 2D)))), ((V)(12D))), i_2067, ((V)(1.1)))).Str));
}, 1, "", true));
Call(rep_22, V.Undef, ((V)(4D)), Fn((V _arrowThis2076, int _argc2069, V i_2075, V _a2072, V _a2073, V _a2074, V[] _rest2070) => {
V q_2077 = default;
q_2077 = Call(p_2001, V.Undef, ((V)(((-12D) + (ToNum(i_2075) * 8D)))), ((V)(33D)), ((V)(14D)));
f_2003.S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_2077, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_2077, 1D))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((2.4 * ToNum(k_2002)))))), "\" fill=\"#fffaf6\" stroke=\"#d8d0c8\" stroke-width=\"0.5\"/>"));
return default;
}, 1, "", true));
f_2003.V(Call(glowAt_64, V.Undef, Call(p_2001, V.Undef, ((V)(0D)), ((V)(34D)), ((V)(10D))), ((V)((20D * ToNum(k_2002)))), ((V)("bhG")), ((V)(0.6))));
}
if (SEqN(t_1966, 5D)) {
V q_2078 = default;
q_2078 = Call(p_2001, V.Undef, ((V)(0D)), ((V)(28D)), ((V)(16D)));
f_2003.S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_2078, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(q_2078, 1D))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((5D * ToNum(k_2002)))))), "\" fill=\"#fffaf6\" stroke=\"#e8d8d0\" stroke-width=\"0.6\"/>")).V(Call(glowAt_64, V.Undef, q_2078, ((V)((30D * ToNum(k_2002)))), ((V)("bhG")), ((V)(0.9))));
}
return NewObj(3).Put("defs", defs_2004).Put("front", ((V)(f_2003.Str))).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_2001, V.Undef, ((V)((-44D))), ((V)(0D)), ((V)((-30D)))), Call(p_2001, V.Undef, ((V)(44D)), ((V)(0D)), ((V)(30D))), Call(p_2001, V.Undef, ((V)((-44D))), ((V)(0D)), ((V)(30D))), Call(p_2001, V.Undef, ((V)(44D)), ((V)(0D)), ((V)((-30D)))), Call(p_2001, V.Undef, ((V)(0D)), ((V)((SEqN(t_1966, 2D) ? 76D : 60D))), ((V)(0D)))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_1967;
return default;
}, 1, "", true));
Set(N_42, "bToys", Fn((V _arrowThis2086, int _argc2079, V S_2085, V _a2082, V _a2083, V _a2084, V[] _rest2080) => {
V t_2087 = default;
V D_2088 = default;
t_2087 = Call(T_48, V.Undef, S_2085);
D_2088 = NewObj(4).Put("w", ((V)(80D))).Put("d", ((V)(60D))).Put("act", ((V)("dig"))).Put("use", NewObj(2).Put("x", ((V)(0D))).Put("z", ((V)(40D))).V).V;
Set(D_2088, "build", Fn((V _arrowThis2096, int _argc2089, V P_2095, V _a2092, V _a2093, V _a2094, V[] _rest2090) => {
V o_2097 = default;
V bc_2098 = default;
o_2097 = Arr();
bc_2098 = GetIdx(Arr(((V)("#d8a090")), ((V)("#ff6a5a")), ((V)("#4fb0f0")), ((V)("#ffd23f")), GOLD_44), (ToNum(t_2087) - 1D));
if (!SEqN(t_2087, 3D)) {
Invoke(o_2097, "push", Call(cyl_14, V.Undef, ((V)((-14D))), ((V)(0D)), ((V)(0D)), ((V)(10D)), ((V)(16D)), bc_2098, Call((SEqN(t_2087, 5D) ? mt_28 : pt_31), V.Undef, NewObj(3).Put("n", ((V)(14D))).Put("rg", Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(0.82))), Arr(((V)(16D)), ((V)(0D)), ((V)(1D))))).Put("shine", ((V)((SEqN(t_2087, 5D) ? 1D : 0D)))).V)), Call(cyl_14, V.Undef, ((V)((-14D))), ((V)(15D)), ((V)(0D)), ((V)(9D)), ((V)(0.6)), SAND_49, Call(pt_31, V.Undef, NewObj(1).Put("n", ((V)(14D))).V)));
}
if (SEqN(t_2087, 2D)) {
Invoke(o_2097, "push", Call(cyl_14, V.Undef, ((V)(16D)), ((V)(0D)), ((V)(10D)), ((V)(7D)), ((V)(5D)), ((V)("#a6e870")), Call(pt_31, V.Undef, NewObj(1).Put("n", ((V)(10D))).V)), Call(cyl_14, V.Undef, ((V)(24D)), ((V)(0D)), ((V)((-6D))), ((V)(6D)), ((V)(6D)), ((V)("#ffb3c8")), Call(pt_31, V.Undef, NewObj(1).Put("n", ((V)(5D))).V)));
}
if (SEqN(t_2087, 3D)) {
Invoke(o_2097, "push", Call(ball_15, V.Undef, ((V)((-10D))), ((V)(12D)), ((V)(4D)), ((V)(12D)), ((V)("#ffffff")), Call(cer_30, V.Undef, NewObj(2).Put("k", ((V)(6D))).Put("shine", ((V)(1D))).V)));
}
if (SEqN(t_2087, 4D)) {
InvokeSpread(o_2097, "push", new ArrBuilder().Add(Call(box_12, V.Undef, ((V)(20D)), ((V)(6D)), ((V)(0D)), ((V)(36D)), ((V)(10D)), ((V)(22D)), ((V)("#e2554a")), Call(pt_31, V.Undef, NewObj(1).Put("r", ((V)(2D))).V))).Spread(Invoke(Arr(Arr(((V)(6D)), ((V)(12D))), Arr(((V)(34D)), ((V)(12D))), Arr(((V)(6D)), ((V)((-12D)))), Arr(((V)(34D)), ((V)((-12D))))), "map", Fn((V _arrowThis2110, int _argc2099, V _a2101, V _a2102, V _a2103, V _a2104, V[] _rest2100) => {
V x_2107 = default;
V z_2109 = default;
{ V _t2105 = ListOf(_a2101);
{ V _t2106 = GetIdx(_t2105, 0D);
x_2107 = _t2106; }
{ V _t2108 = GetIdx(_t2105, 1D);
z_2109 = _t2108; }
}
return Call(cyl_14, V.Undef, x_2107, ((V)(0D)), z_2109, ((V)(5D)), ((V)(3D)), ((V)("#2c2d31")), Call(mt_28, V.Undef, NewObj(1).Put("n", ((V)(10D))).V));
}, 1, "", true))).Add(Call(arcW_17, V.Undef, ((V)((-16D))), ((V)(0D)), ((V)(16D)), ((V)(14D)), ((V)(12D)), ((V)(6D)), ((V)(6D)), ((V)(0D)), ((V)((2D * PI_43))), ((V)("#ff8ac0")), Call(cer_30, V.Undef, NewObj(2).Put("n", ((V)(18D))).Put("shine", ((V)(1D))).V))).V);
}
if (SEqN(t_2087, 5D)) {
Invoke(o_2097, "push", Call(box_12, V.Undef, ((V)(16D)), ((V)(0D)), ((V)(10D)), ((V)(34D)), ((V)(1D)), ((V)(24D)), ((V)("#f2e2b6")), Call(fb_47, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)), Call(box_12, V.Undef, ((V)((-2D))), ((V)(0D)), ((V)((-14D))), ((V)(20D)), ((V)(12D)), ((V)(14D)), ((V)("#8a5a2c")), Call(wd_29, V.Undef, NewObj(1).Put("r", ((V)(2D))).V)), Call(box_12, V.Undef, ((V)((-2D))), ((V)(12D)), ((V)((-14D))), ((V)(21D)), ((V)(3D)), ((V)(15D)), GOLD_44, Call(mt_28, V.Undef, NewObj(1).Put("r", ((V)(1D))).V)));
}
return o_2097;
return default;
}, 1, "", true));
Set(D_2088, "fx", Fn((V _arrowThis2118, int _argc2111, V c_2117, V _a2114, V _a2115, V _a2116, V[] _rest2112) => {
V p_2119 = default;
V k_2120 = default;
JsStrBuf f_2121 = null;
V defs_2122 = default;
V spade_2123 = default;
p_2119 = Get(c_2117, "p");
k_2120 = Get(c_2117, "k");
f_2121 = new JsStrBuf("");
defs_2122 = GLW_63;
spade_2123 = Fn((V _arrowThis2132, int _argc2124, V @base_2130, V col_2131, V _a2128, V _a2129, V[] _rest2125) => {
V a_2133 = default;
V b_2134 = default;
a_2133 = CallSpread(p_2119, V.Undef, new ArrBuilder().Spread(@base_2130).V);
b_2134 = Call(p_2119, V.Undef, Add(GetIdx(@base_2130, 0D), ((V)(4D))), Add(GetIdx(@base_2130, 1D), ((V)(26D))), GetIdx(@base_2130, 2D));
return Add(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, a_2133)), "L", ToStr(Call(P2_25, V.Undef, b_2134))))), ((V)("none")), ((V)("#8a6a48")), ((V)(1.6))), Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(a_2133, 0D)) - (4D * ToNum(k_2120))))))), " ", ToStr(Call(f1_21, V.Undef, GetIdx(a_2133, 1D))), "l", ToStr(Call(f1_21, V.Undef, ((V)((4D * ToNum(k_2120)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((6D * ToNum(k_2120)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((4D * ToNum(k_2120)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)(((-6D) * ToNum(k_2120)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)(((-1D) * ToNum(k_2120)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)(((-5D) * ToNum(k_2120)))))), "h", ToStr(Call(f1_21, V.Undef, ((V)(((-6D) * ToNum(k_2120)))))), "Z"))), col_2131, Call(ink_56, V.Undef, col_2131), ((V)(0.6))));
return default;
}, 2, "", true);
if ((SEqN(t_2087, 1D) || SEqN(t_2087, 2D))) {
f_2121.V(Call(spade_2123, V.Undef, Arr(((V)(10D)), ((V)(0D)), ((V)(14D))), ((V)((SEqN(t_2087, 1D) ? "#9aa1a6" : "#3fb0c8")))));
}
if (SEqN(t_2087, 3D)) {
V q_2135 = default;
V a_2136 = default;
V kt_2137 = default;
q_2135 = Call(p_2119, V.Undef, ((V)((-10D))), ((V)(12D)), ((V)(4D)));
f_2121.S(string.Concat("<g transform=\"translate(", ToStr(Call(P2_25, V.Undef, q_2135)), ") scale(", ToStr(Call(n4_24, V.Undef, k_2120)), ")\"><path d=\"M-12 0A12 12 0 0 1 12 0\" fill=\"none\" stroke=\"#e2554a\" stroke-width=\"5\" opacity=\"0.85\" transform=\"rotate(-20)\"/><path d=\"M-10 -6A12 12 0 0 1 10 -6\" fill=\"none\" stroke=\"#ffd23f\" stroke-width=\"3\" opacity=\"0.85\"/></g>"));
a_2136 = Call(p_2119, V.Undef, ((V)(20D)), ((V)(2D)), ((V)(10D)));
kt_2137 = Call(p_2119, V.Undef, ((V)(34D)), ((V)(84D)), ((V)((-6D))));
f_2121.V(Call(PP_51, V.Undef, ((V)(string.Concat("M", ToStr(Call(P2_25, V.Undef, a_2136)), "Q", ToStr(Call(P2_25, V.Undef, Call(p_2119, V.Undef, ((V)(40D)), ((V)(40D)), ((V)(0D))))), " ", ToStr(Call(P2_25, V.Undef, kt_2137))))), ((V)("none")), ((V)("#ffffff")), ((V)(0.6)))).S(string.Concat("<g>", ToStr(Call(AT_53, V.Undef, ((V)("translate")), ((V)("0 0;3 -4;0 0")), ((V)(3D)))), "<path d=\"M", ToStr(Call(f1_21, V.Undef, GetIdx(kt_2137, 0D))), " ", ToStr(Call(f1_21, V.Undef, ((V)((ToNum(GetIdx(kt_2137, 1D)) - (14D * ToNum(k_2120))))))), "l", ToStr(Call(f1_21, V.Undef, ((V)((9D * ToNum(k_2120)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((10D * ToNum(k_2120)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)(((-9D) * ToNum(k_2120)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((10D * ToNum(k_2120)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)(((-9D) * ToNum(k_2120)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)(((-10D) * ToNum(k_2120)))))), "Z\" fill=\"#ff6a8a\" stroke=\"#8a2a40\" stroke-width=\"0.8\"/><path d=\"M", ToStr(Call(f1_21, V.Undef, GetIdx(kt_2137, 0D))), " ", ToStr(Call(f1_21, V.Undef, Add(GetIdx(kt_2137, 1D), ((V)((6D * ToNum(k_2120))))))), "q", ToStr(Call(f1_21, V.Undef, ((V)(((-4D) * ToNum(k_2120)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((6D * ToNum(k_2120)))))), " 0 ", ToStr(Call(f1_21, V.Undef, ((V)((12D * ToNum(k_2120)))))), "\" fill=\"none\" stroke=\"#ffd23f\" stroke-width=\"1.4\"/></g>"));
}
if (SEqN(t_2087, 4D)) {
V pts_2138 = default;
V h_2139 = default;
pts_2138 = Invoke(Call(curve_34, V.Undef, Arr(((V)((-28D))), ((V)(6D)), ((V)(16D))), Arr(((V)((-36D))), ((V)(26D)), ((V)(16D))), Arr(((V)((-26D))), ((V)(36D)), ((V)(16D))), ((V)(6D))), "map", Fn((V _arrowThis2147, int _argc2140, V q_2146, V _a2143, V _a2144, V _a2145, V[] _rest2141) => {
return CallSpread(p_2119, V.Undef, new ArrBuilder().Spread(q_2146).V);
}, 1, "", true));
f_2121.V(Call(tube_33, V.Undef, pts_2138, ((V)(4D)), k_2120, ((V)("#ff8ac0")), ((V)("#ffd0e6")), ((V)("#a8406a"))));
h_2139 = Call(p_2119, V.Undef, ((V)((-26D))), ((V)(38D)), ((V)(16D)));
f_2121.S(string.Concat("<circle cx=\"", ToStr(Call(f1_21, V.Undef, GetIdx(h_2139, 0D))), "\" cy=\"", ToStr(Call(f1_21, V.Undef, GetIdx(h_2139, 1D))), "\" r=\"", ToStr(Call(f1_21, V.Undef, ((V)((4.6 * ToNum(k_2120)))))), "\" fill=\"#ff8ac0\" stroke=\"#a8406a\" stroke-width=\"0.6\"/><path d=\"M", ToStr(Call(f1_21, V.Undef, Add(GetIdx(h_2139, 0D), ((V)((3D * ToNum(k_2120))))))), " ", ToStr(Call(f1_21, V.Undef, GetIdx(h_2139, 1D))), "l", ToStr(Call(f1_21, V.Undef, ((V)((5D * ToNum(k_2120)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((3D * ToNum(k_2120)))))), "l", ToStr(Call(f1_21, V.Undef, ((V)(((-5D) * ToNum(k_2120)))))), " ", ToStr(Call(f1_21, V.Undef, ((V)((1D * ToNum(k_2120)))))), "Z\" fill=\"#2c2d31\"/>"));
}
if (SEqN(t_2087, 5D)) {
f_2121.S(string.Concat("<g transform=\"", ToStr(Call(planeH_26, V.Undef, p_2119, ((V)(1.2)), ((V)(16D)), ((V)(10D)))), "\"><path d=\"M-12 -6L4 2L10 -4\" stroke=\"#c4651f\" stroke-width=\"1.2\" fill=\"none\" stroke-dasharray=\"2 2\"/><path d=\"M8 -6l4 4m0 -4l-4 4\" stroke=\"#e2554a\" stroke-width=\"1.6\"/></g>")).V(Call(spade_2123, V.Undef, Arr(((V)(30D)), ((V)(0D)), ((V)((-8D)))), GOLD_44)).V(Call(glowAt_64, V.Undef, Call(p_2119, V.Undef, ((V)((-2D))), ((V)(14D)), ((V)((-14D)))), ((V)((22D * ToNum(k_2120)))), ((V)("bhG")), ((V)(0.7))));
}
return NewObj(3).Put("defs", defs_2122).Put("front", ((V)(f_2121.Str))).Put("bb", Call(bbOf_27, V.Undef, Arr(Call(p_2119, V.Undef, ((V)((-46D))), ((V)(0D)), ((V)((-34D)))), Call(p_2119, V.Undef, ((V)(46D)), ((V)(0D)), ((V)(34D))), Call(p_2119, V.Undef, ((V)((-46D))), ((V)(0D)), ((V)(34D))), Call(p_2119, V.Undef, ((V)(46D)), ((V)(0D)), ((V)((-34D)))), Call(p_2119, V.Undef, ((V)(0D)), ((V)((SEqN(t_2087, 3D) ? 100D : 50D))), ((V)(0D))), Call(p_2119, V.Undef, ((V)(40D)), ((V)(90D)), ((V)((-6D))))), ((V)(4D)))).V;
return default;
}, 1, "", true));
return D_2088;
return default;
}, 1, "", true));
TN_67 = Arr(((V)("Tier 1: Starter / Fixer-Upper")), ((V)("Tier 2: Cozy Budget")), ((V)("Tier 3: Modern Stylish")), ((V)("Tier 4: Designer Luxury")), ((V)("Tier 5: Ultimate / Mythic")));
RAR_68 = Arr(((V)("Common")), ((V)("Uncommon")), ((V)("Rare")), ((V)("Epic")), ((V)("Legendary")));
BASE_69 = Arr(((V)(320D)), ((V)(1400D)), ((V)(4800D)), ((V)(14000D)), ((V)(42000D)));
TAG_70 = NewObj(13).Put("sun", Arr(((V)("Sunbathe")), ((V)("Tap with a friend selected: they lie down and soak up the sun.")), ((V)("Restores energy")))).Put("nap", Arr(((V)("Nap")), ((V)("Tap with a friend selected: they curl up for a nap in the shade.")), ((V)("Restores energy")))).Put("build", Arr(((V)("Build")), ((V)("A friend builds and pats the sandcastle into shape.")), ((V)("Restores fun")))).Put("surf", Arr(((V)("Surf")), ((V)("A friend grabs a board and rides the waves out at sea.")), ((V)("Restores fun and gets them clean")))).Put("treat", Arr(((V)("Treats")), ((V)("A friend gets a treat and eats it right there.")), ((V)("Restores hunger")))).Put("roast", Arr(((V)("Roast")), ((V)("Up to 3 friends sit round the fire and roast marshmallows.")), ((V)("Restores hunger and fun")))).Put("splash", Arr(((V)("Splash")), ((V)("2 friends splash about with the crabs.")), ((V)("Restores fun")))).Put("ride", Arr(((V)("Ride")), ((V)("Floats out at sea. A friend climbs on and bobs on the waves.")), ((V)("Restores fun")))).Put("sit", Arr(((V)("Sit")), ((V)("A friend climbs up and keeps watch over the sea.")), ((V)("Restores energy")))).Put("dig", Arr(((V)("Dig")), ((V)("A friend digs in the sand with it.")), ((V)("Restores fun")))).Put("game", Arr(((V)("Match \u00b7 2 friends")), ((V)("Tap to start a beach volleyball match. Needs 2 friends at the Beach.")), ((V)("Free friends come and play")))).Put("deco", Arr(((V)("Decor")), ((V)("Makes the Beach look lovely.")))).Put("shells", Arr(((V)("Shells")), ((V)("Shows off the shells your squad finds on the sand. Tap it to count them.")))).V;
SLOTS_71 = Arr(Arr(((V)("Beach Sand")), ((V)("Floor")), ((V)("s:ground")), ((V)(1.2)), Arr(((V)("Pebbly Grey Sand with Seaweed & a Soda Can")), ((V)("Raked Golden Sand")), ((V)("Fine White Sand with Shell Flecks")), ((V)("Pink Coral Sand with Sea Glass")), ((V)("Glittering Starlight Sand"))), NewObj(2).Put("surf", ((V)("ground"))).Put("tag", Arr(((V)("Sand")), ((V)("Covers the whole Beach.")))).V), Arr(((V)("Pier & Boardwalk")), ((V)("Walls")), ((V)("s:fence")), ((V)(1.3)), Arr(((V)("Rickety Driftwood Pier with Missing Boards")), ((V)("Sun-Bleached Boardwalk with Rope Railing")), ((V)("Painted White Pier with Lamp Posts")), ((V)("Teak Yacht Dock with Brass Cleats & Flags")), ((V)("Royal Marble Jetty with Golden Lanterns"))), NewObj(2).Put("surf", ((V)("fence"))).Put("tag", Arr(((V)("Pier")), ((V)("Rebuilds the pier. Friends fish from its end.")))).V), Arr(((V)("Beach Lights")), ((V)("Ceiling")), ((V)("s:ylight")), ((V)(1D)), Arr(((V)("Flashlight Taped to a Driftwood Post")), ((V)("Solar Path Lights Along the Dunes")), ((V)("Tiki Torches on the Dune Fence")), ((V)("Paper Lantern Strings over the Sand")), ((V)("Glowing Bioluminescent Shoreline"))), NewObj(2).Put("surf", ((V)("ylight"))).Put("tag", Arr(((V)("Lights")), ((V)("Lights up the Beach. Glows when the Bedroom lights are off.")))).V), Arr(((V)("Sun Lounger")), ((V)("Furniture")), ((V)("bLounger")), ((V)(1D)), Arr(((V)("Sagging Lawn Lounger with Torn Webbing")), ((V)("Striped Canvas Deck Lounger")), ((V)("Teak Sun Lounger with Navy Cushion")), ((V)("Double Daybed Lounger with Fringed Canopy")), ((V)("Floating Pearl-Shell Lounger"))), NewObj(1).Put("tag", ((V)("sun"))).V), Arr(((V)("Beach Umbrella")), ((V)("Furniture")), ((V)("bUmbrella")), ((V)(0.9)), Arr(((V)("Faded Patched Umbrella Stuck in the Sand")), ((V)("Rainbow Striped Beach Umbrella")), ((V)("Fringed Tiki Straw Parasol")), ((V)("Scalloped Cabana Umbrella with Tassels")), ((V)("Giant Seashell Parasol with Pearl Lamp"))), NewObj(1).Put("tag", ((V)("nap"))).V), Arr(((V)("Beach Towel")), ((V)("Floor")), ((V)("bTowel")), ((V)(0.7)), Arr(((V)("Threadbare Old Bath Towel")), ((V)("Striped Beach Towel & Flip-Flops")), ((V)("Round Mandala Beach Blanket")), ((V)("Plush Padded Sunbed Mat with Pillows")), ((V)("Golden Silk Royal Sun Mat"))), NewObj(1).Put("tag", ((V)("sun"))).V), Arr(((V)("Sandcastle")), ((V)("Furniture")), ((V)("bCastle")), ((V)(0.9)), Arr(((V)("Lumpy Bucket-Mould Sand Pile")), ((V)("Classic Sandcastle with Paper Flag")), ((V)("Three-Tower Castle with a Moat")), ((V)("Grand Sand Palace with Shell Mosaics")), ((V)("Crystal Sand Citadel with Glowing Windows"))), NewObj(1).Put("tag", ((V)("build"))).V), Arr(((V)("Surf Spot")), ((V)("Furniture")), ((V)("bSurf")), ((V)(1.1)), Arr(((V)("Cracked Foam Bodyboard on a Post")), ((V)("Retro Longboard on a Wooden Rack")), ((V)("Twin Surfboard Rack with Wetsuit")), ((V)("Thatched Surf Rack with Hibiscus Boards")), ((V)("Hover Surfboard Dock with Wave Glow"))), NewObj(1).Put("tag", ((V)("surf"))).V), Arr(((V)("Beach Games")), ((V)("Furniture")), ((V)("bVolley")), ((V)(1.1)), Arr(((V)("Sagging Rope Net Between Two Sticks")), ((V)("Volleyball Net with Painted Court Lines")), ((V)("Pro Volleyball Court with Flags")), ((V)("Volleyball Arena with Scoreboard")), ((V)("Starlight Volleyball Court with Glow Ball"))), NewObj(2).Put("tag", ((V)("game"))).Put("game", ((V)(1D))).V), Arr(((V)("Snack Shack")), ((V)("Furniture")), ((V)("bShack")), ((V)(1.3)), Arr(((V)("Crate Lemonade Stand with a Hand-Drawn Sign")), ((V)("Ice Cream Cart with Striped Umbrella")), ((V)("Thatched Smoothie Hut")), ((V)("Surfside Snack Bar with Neon Cone")), ((V)("Golden Ice Cream Palace Kiosk"))), NewObj(1).Put("tag", ((V)("treat"))).V), Arr(((V)("Bonfire")), ((V)("Furniture")), ((V)("bFire")), ((V)(1.2)), Arr(((V)("Driftwood Twig Campfire in a Sand Pit")), ((V)("Stone Ring Bonfire with Log Seats")), ((V)("Iron Fire Bowl with Marshmallow Sticks")), ((V)("Sunken Fire Pit Lounge with Cushions")), ((V)("Blue Flame Crystal Bonfire"))), NewObj(2).Put("tag", ((V)("roast"))).Put("live", ((V)("Fire crackling"))).V), Arr(((V)("Tide Pool")), ((V)("Furniture")), ((V)("bTide")), ((V)(1D)), Arr(((V)("Muddy Puddle with One Shy Crab")), ((V)("Rock Pool with Starfish & Crabs")), ((V)("Mossy Tide Pool with Anemones")), ((V)("Coral Grotto Pool with Little Fish")), ((V)("Glowing Moon Tide Pool"))), NewObj(2).Put("tag", ((V)("splash"))).Put("live", ((V)("Crabs scuttling"))).V), Arr(((V)("Float & Boat")), ((V)("Furniture")), ((V)("bFloat")), ((V)(1.2)), Arr(((V)("Patched Inner Tube")), ((V)("Rubber Duck Pool Float")), ((V)("Wooden Rowboat")), ((V)("Swan Pedal Boat")), ((V)("Golden Royal Barge"))), NewObj(2).Put("tag", ((V)("ride"))).Put("sea", ((V)(1D))).V), Arr(((V)("Lifeguard Tower")), ((V)("Furniture")), ((V)("bTower")), ((V)(1.1)), Arr(((V)("Upturned Crate Lookout")), ((V)("Wooden Lifeguard Chair with Umbrella")), ((V)("Classic Red Lifeguard Tower")), ((V)("Lifeguard Hut with Flag & Life Ring")), ((V)("Lighthouse Lookout Tower"))), NewObj(1).Put("tag", ((V)("sit"))).V), Arr(((V)("Cooler & Drinks")), ((V)("Furniture")), ((V)("bCooler")), ((V)(0.8)), Arr(((V)("Dented Foam Cooler")), ((V)("Retro Red Picnic Cooler")), ((V)("Rolling Drinks Cart with Coconuts")), ((V)("Tiki Barrel with Pineapple Cups")), ((V)("Golden Fountain Drinks Cooler"))), NewObj(1).Put("tag", ((V)("treat"))).V), Arr(((V)("Palm Tree")), ((V)("Furniture")), ((V)("bPalm")), ((V)(1D)), Arr(((V)("Scraggly Leaning Palm Sapling")), ((V)("Coconut Palm")), ((V)("Twin Palms with Coconuts")), ((V)("Palm Trio with String Lights")), ((V)("Golden Glow Palm"))), NewObj(2).Put("tag", ((V)("deco"))).Put("live", ((V)("Swaying in the breeze"))).V), Arr(((V)("Hammock")), ((V)("Furniture")), ((V)("bHammock")), ((V)(1D)), Arr(((V)("Fishing Net Hammock on Driftwood Posts")), ((V)("Striped Canvas Hammock on a Stand")), ((V)("Rope Hammock Between Two Palms")), ((V)("Macram\u00e9 Hammock with Shade Sail")), ((V)("Cloud Hammock with Fairy Lights"))), NewObj(1).Put("tag", ((V)("nap"))).V), Arr(((V)("Beach Cabana")), ((V)("Furniture")), ((V)("bCabana")), ((V)(1.2)), Arr(((V)("Bedsheet Tent on Broomsticks")), ((V)("Striped Pop-Up Beach Tent")), ((V)("White Curtain Cabana")), ((V)("Thatched Tiki Cabana with Daybed")), ((V)("Royal Silk Pavilion with Gold Finial"))), NewObj(1).Put("tag", ((V)("nap"))).V), Arr(((V)("Shell Collection")), ((V)("Furniture")), ((V)("bShells")), ((V)(0.7)), Arr(((V)("Jam Jar of Broken Shells")), ((V)("Shell Wind Chime on a Post")), ((V)("Driftwood Shelf of Seashells")), ((V)("Treasure Chest of Shells & Pearls")), ((V)("Giant Conch with Pearl Glow"))), NewObj(2).Put("tag", ((V)("shells"))).Put("kind", ((V)("shells"))).V), Arr(((V)("Sand Toys")), ((V)("Furniture")), ((V)("bToys")), ((V)(0.6)), Arr(((V)("Cracked Bucket & Bent Spade")), ((V)("Bucket, Spade & Moulds Set")), ((V)("Beach Ball & Kite Bundle")), ((V)("Inflatable Flamingo & Toy Wagon")), ((V)("Treasure Map & Golden Spade"))), NewObj(1).Put("tag", ((V)("dig"))).V));
ROWS_72 = Arr();
Invoke(SLOTS_71, "forEach", Fn((V _arrowThis2168, int _argc2148, V _a2150, V si_2154, V _a2152, V _a2153, V[] _rest2149) => {
V slotName_2157 = default;
V cat_2159 = default;
V spec_2161 = default;
V fac_2163 = default;
V names_2165 = default;
V ex_2167 = default;
{ V _t2155 = ListOf(_a2150);
{ V _t2156 = GetIdx(_t2155, 0D);
slotName_2157 = _t2156; }
{ V _t2158 = GetIdx(_t2155, 1D);
cat_2159 = _t2158; }
{ V _t2160 = GetIdx(_t2155, 2D);
spec_2161 = _t2160; }
{ V _t2162 = GetIdx(_t2155, 3D);
fac_2163 = _t2162; }
{ V _t2164 = GetIdx(_t2155, 4D);
names_2165 = _t2164; }
{ V _t2166 = GetIdx(_t2155, 5D);
ex_2167 = _t2166; }
}
return Invoke(names_2165, "forEach", Fn((V _arrowThis2177, int _argc2169, V name_2175, V ti_2176, V _a2173, V _a2174, V[] _rest2170) => {
V tier_2178 = default;
V n_2179 = default;
double cost_2180 = 0;
V tg_2181 = default;
V r_2182 = default;
tier_2178 = Add(ti_2176, ((V)(1D)));
n_2179 = Add(Add(((V)((ToNum(ti_2176) * 20D))), si_2154), ((V)(1D)));
cost_2180 = (Round(((ToNum(GetK(BASE_69, ti_2176)) * ToNum(fac_2163)) / 5D)) * 5D);
tg_2181 = ((Get(ex_2167, "tag").O is JsArray) ? Get(ex_2167, "tag") : GetK(TAG_70, Get(ex_2167, "tag")));
r_2182 = NewObj(18).Put("id", ((V)(JsStrBuf.Begin().S("BCH-").V(Invoke(((V)(ToStrS(n_2179))), "padStart", ((V)(3D)), ((V)("0")))).End()))).Put("room", ((V)("BCH"))).Put("roomName", ((V)("Beach"))).Put("lv", Call(LVOF_73, V.Undef, tier_2178)).Put("tier", tier_2178).Put("tierName", GetK(TN_67, ti_2176)).Put("rarity", GetK(RAR_68, ti_2176)).Put("slot", Add(si_2154, ((V)(1D)))).Put("cat", cat_2159).Put("slotName", slotName_2157).Put("name", name_2175).Put("cost", ((V)(cost_2180))).Put("stat", ((V)("Fun & Sun"))).Put("bonus", ((V)(JsStrBuf.Begin().S("+").N(((ToNum(tier_2178) * 5D) + (ToNum(si_2154) % 4D))).S(" Fun & Sun").End()))).Put("spec", spec_2161).Put("catO", cat_2159).Put("btag", tg_2181).Put("beach", ((V)(1D))).V;
if (Truthy(Get(ex_2167, "surf"))) {
Set(r_2182, "bsurf", Get(ex_2167, "surf"));
}
if (Truthy(Get(ex_2167, "sea"))) {
Set(r_2182, "sea", ((V)(1D)));
}
if (Truthy(Get(ex_2167, "live"))) {
Set(r_2182, "live", Get(ex_2167, "live"));
}
if (Truthy(Get(ex_2167, "kind"))) {
Set(r_2182, "kind", Get(ex_2167, "kind"));
}
if (Truthy(Get(ex_2167, "game"))) {
Object_assign(r_2182, NewObj(3).Put("play", ((V)("game"))).Put("need", ((V)(2D))).Put("loop", ((V)(60D))).V);
}
Set(r_2182, "note", ((V)(JsStrBuf.Begin().V(name_2175).S(". ").V(GetIdx(tg_2181, 1D)).S((Truthy(GetIdx(tg_2181, 2D)) ? JsStrBuf.Begin().S(" ").V(GetIdx(tg_2181, 2D)).S(".").End() : "")).End())));
Invoke(ROWS_72, "push", r_2182);
return default;
}, 2, "", true));
}, 2, "", true));
edit0_74 = Get(RD_8, "edit");
Set(RD_8, "edit", Fn((V _arrowThis2190, int _argc2183, V rows_2189, V _a2186, V _a2187, V _a2188, V[] _rest2184) => {
V @out_2191 = default;
@out_2191 = Call(edit0_74, V.Undef, rows_2189);
return (Truthy(Invoke(@out_2191, "some", Fn((V _arrowThis2207, int _argc2200, V r_2206, V _a2203, V _a2204, V _a2205, V[] _rest2201) => {
return (SEqS(Get(r_2206, "room"), "BCH") ? V.True : V.False);
}, 1, "", true))) ? @out_2191 : Invoke(@out_2191, "concat", Invoke(ROWS_72, "map", Fn((V _arrowThis2199, int _argc2192, V r_2198, V _a2195, V _a2196, V _a2197, V[] _rest2193) => {
return Object_assign(NewObj(0).V, r_2198);
}, 1, "", true))));
return default;
}, 1, "", true));
BPL_75 = NewObj(1).Put("bVolley", Fn((V _arrowThis2214, int _argc2208, V _a2210, V _a2211, V _a2212, V _a2213, V[] _rest2209) => {
return Arr(NewObj(4).Put("x", ((V)((-52D)))).Put("z", ((V)(22D))).Put("v", ((V)("right"))).Put("a", ((V)("gjump"))).V, NewObj(5).Put("x", ((V)(52D))).Put("z", ((V)((-14D)))).Put("v", ((V)("left"))).Put("a", ((V)("gjump"))).Put("d", ((V)(0.5))).V);
}, 0, "bVolley", true)).V;
SM_76 = New(G("Map"));
d0_77 = Get(RD_8, "draw");
Set(RD_8, "draw", Fn((V _arrowThis2223, int _argc2215, V r_2221, V o_2222, V _a2219, V _a2220, V[] _rest2216) => {
V res_2224 = default;
if (Truthy(((r_2221 is var _t2225 && !Truthy(_t2225) ? _t2225 : (SEqS(Get(r_2221, "room"), "BCH") ? V.True : V.False)) is var _t2226 && !Truthy(_t2226) ? _t2226 : Get(r_2221, "bsurf")))) {
V key_2227 = default;
V svg_2228 = default;
V m_2229 = default;
V res_2230 = default;
key_2227 = Get(r_2221, "id");
if (Truthy(Invoke(SM_76, "has", key_2227))) {
return Invoke(SM_76, "get", key_2227);
}
svg_2228 = Invoke(BE_10, "thumb", Get(r_2221, "bsurf"), Get(r_2221, "tier"));
m_2229 = Invoke(svg_2228, "match", NewRegExp(RX0, "viewBox=\"([^\"]+)\"", ""));
res_2230 = NewObj(10).Put("svg", svg_2228).Put("src", ((V)(JsStrBuf.Begin().S("data:image/svg+xml,").V(Call(G("encodeURIComponent"), V.Undef, svg_2228)).End()))).Put("w", ((V)(0D))).Put("h", ((V)(0D))).Put("surf", (true ? V.True : V.False)).Put("vb", (Truthy(m_2229) ? GetIdx(m_2229, 1D) : ((V)("0 0 80 56")))).Put("kind", Get(r_2221, "bsurf")).Put("arch", ((V)(JsStrBuf.Begin().S("s:").V(Get(r_2221, "bsurf")).End()))).Put("band", ((V)("mod"))).Put("err", ((V)(""))).V;
Invoke(SM_76, "set", key_2227, res_2230);
return res_2230;
}
res_2224 = Call(d0_77, V.Undef, r_2221, o_2222);
if (Truthy(((((!(Truthy(res_2224)) || !(Truthy(r_2221))) || !SEqS(Get(r_2221, "room"), "BCH")) ? V.True : V.False) is var _t2231 && Truthy(_t2231) ? _t2231 : Get(res_2224, "_bp")))) {
return res_2224;
}
Set(res_2224, "_bp", ((V)(1D)));
try {
V sp0_2232 = default;
sp0_2232 = (Truthy(Get(r_2221, "spec")) ? GetIdx(Invoke(Get(r_2221, "spec"), "split", NewRegExp(RX1, "[.@*+]", "")), 0D) : ((V)("")));
if (Truthy((GetK(BPL_75, sp0_2232) is var _t2233 && !Truthy(_t2233) ? _t2233 : Get(res_2224, "bb")))) {
V p_2234 = default;
p_2234 = Invoke(RD_8, "projOf", ((V)(1D)));
Set(res_2224, "players", Invoke(InvokeK(BPL_75, sp0_2232), "map", Fn((V _arrowThis2242, int _argc2235, V q_2241, V _a2238, V _a2239, V _a2240, V[] _rest2236) => {
V s_2243 = default;
s_2243 = Call(p_2234, V.Undef, Get(q_2241, "x"), (Get(q_2241, "y") is var _t2244 && Truthy(_t2244) ? _t2244 : ((V)(0D))), Get(q_2241, "z"));
return NewObj(6).Put("x", GetIdx(s_2243, 0D)).Put("y", GetIdx(s_2243, 1D)).Put("v", Get(q_2241, "v")).Put("a", Get(q_2241, "a")).Put("b", (!(!(Truthy(Get(q_2241, "b")))) ? V.True : V.False)).Put("d", (Get(q_2241, "d") is var _t2245 && Truthy(_t2245) ? _t2245 : ((V)(0D)))).V;
return default;
}, 1, "", true)));
}
} catch (System.Exception _ex2246) {
V e_2247 = default;
e_2247 = Caught(_ex2246);
Invoke(G("console"), "warn", ((V)("beach draw")), Get(r_2221, "id"), e_2247);
}
return res_2224;
return default;
}, 2, "", true));
Set(RD_8, "BEACH", ((V)(1D)));
Set(BE_10, "items", ((V)(1D)));
Set(BE_10, "ROWS", ROWS_72);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
