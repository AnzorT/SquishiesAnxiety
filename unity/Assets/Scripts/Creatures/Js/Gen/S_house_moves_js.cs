// house-moves.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house_moves_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("^#[0-9a-f]{6}$", "i");
        public static void Run()
        {
Call(Named(boot_2200 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V R_8 = default;
V REST_9 = default;
V o_10 = default;
V TL_11 = default;
V hand_12 = default;
V both_13 = default;
V SIDE_14 = default;
V keysOf_15 = default;
V BEAT_16 = default;
V SIT0_17 = default;
V LNG0_18 = default;
V seq_19 = default;
V sitdown_20 = default;
V enterMove_21 = default;
V exitMove_22 = default;
V standup_23 = default;
V hold_24 = default;
V ss_25 = default;
V TWO_26 = default;
V LAP_27 = default;
V RIGID_28 = default;
V WX_29 = default;
V WBEAT_30 = default;
V BUCKET_31 = default;
V popProp_32 = default;
V watchHold_33 = default;
V snug_34 = default;
V PROF_35 = default;
V build_36 = default;
double TAU_37 = 0;
V r2_38 = default;
V cl_39 = default;
V LIE0_40 = default;
V CURL0_41 = default;
V shade_42 = default;
V ci_43 = default;
V pa_44 = default;
V ICON_45 = default;
V quilt_46 = default;
V sleepFx_47 = default;
V ZB_48 = default;
V SORD_49 = default;
V sleepHold_50 = default;
V bedIn_51 = default;
V wakeUp_52 = default;
V bedOut_53 = default;
V BED_54 = default;
V bedBuild_55 = default;
V BATH0_56 = default;
V SHOW0_57 = default;
V SWIM0_58 = default;
V SWS_59 = default;
V stroke_60 = default;
V shakeDry_61 = default;
V TB_62 = default;
V SB0_63 = default;
V WB0_64 = default;
V WORD_65 = default;
V wHold_66 = default;
V tubIn_67 = default;
V tubOut_68 = default;
V showerIn_69 = default;
V showerOut_70 = default;
V swimIn_71 = default;
V swimOut_72 = default;
V WAT_73 = default;
V waterBuild_74 = default;
V SWG0_75 = default;
V RID0_76 = default;
V CK0_77 = default;
V PB_78 = default;
V RB_79 = default;
V PORD_80 = default;
V playHold_81 = default;
V playIn_82 = default;
V playOut_83 = default;
V CB_84 = default;
V SPOON_85 = default;
V PAN_86 = default;
V facing_87 = default;
V win_88 = default;
V cookProp_89 = default;
V cookIn_90 = default;
V cookHold_91 = default;
V fridgeMove_92 = default;
V PLY_93 = default;
V playBuild_94 = default;
V okp_95 = default;
V gnd_96 = default;
V rside_97 = default;
V cnt_98 = default;
V lerp_99 = default;
V G_100 = default;
V bHold_101 = default;
V SK0_102 = default;
V SKB_103 = default;
V BR0_104 = default;
V BRB_105 = default;
V brushProp_106 = default;
V DNB_107 = default;
V dineProp_108 = default;
V SF0_109 = default;
V SFB_110 = default;
V FS0_111 = default;
V FB_112 = default;
V fishProp_113 = default;
V SUNB_114 = default;
V SHADES_115 = default;
V sunProp_116 = default;
V sunIn_117 = default;
V sunOut_118 = default;
V slideMove_119 = default;
V TB0_120 = default;
V TBB_121 = default;
V bounceIn_122 = default;
V bounceOut_123 = default;
V DGB_124 = default;
V SAND_125 = default;
V SANDK_126 = default;
V SANDL_127 = default;
V PAIL_128 = default;
V SPADE_129 = default;
V digProp_130 = default;
V BLC_131 = default;
V BLL_132 = default;
V BLK_133 = default;
V BLB_134 = default;
V blocksProp_135 = default;
V CAN_136 = default;
V waterMove_137 = default;
V RSB_138 = default;
V roastProp_139 = default;
V BB_140 = default;
V bBuild_141 = default;
if (_self1.IsNullish) _self1 = GlobalV;
TL_11 = Fn((V _self142, int _argc143, V @base_149, V _a146, V _a147, V _a148, V[] _rest144) => {
V k_150 = default;
V ev_151 = default;
V em_152 = default;
V t_153 = default;
V bv_154 = default;
V T_155 = default;
if (_self142.IsNullish) _self142 = GlobalV;
k_150 = NewObj(0).V;
ev_151 = Arr();
em_152 = Arr();
t_153 = ((V)(0D));
@base_149 = (@base_149 is var _t156 && Truthy(_t156) ? _t156 : NewObj(0).V);
bv_154 = Fn((V _self142, int _argc157, V p_163, V _a160, V _a161, V _a162, V[] _rest158) => {
return (!GetK(@base_149, p_163).IsNullish ? GetK(@base_149, p_163) : (GetK(REST_9, p_163) is var _t164 && Truthy(_t164) ? _t164 : ((V)(0D))));
}, 1, "", true);
T_155 = NewObj(10).Put("B", @base_149).Getter("t", Fn((V _self165, int _argc166, V _a168, V _a169, V _a170, V _a171, V[] _rest167) => {
if (_self165.IsNullish) _self165 = GlobalV;
return t_153;
return default;
}, 0, "t", false)).Put("to", Fn((V _self172, int _argc173, V dt_179, V v_180, V ez_181, V _a178, V[] _rest174) => {
if (_self172.IsNullish) _self172 = GlobalV;
{
foreach (V _k182 in ForInKeys(v_180)) {
V p_183 = default;
p_183 = _k182;
V L_184 = default;
L_184 = (GetK(k_150, p_183) is var _t185 && Truthy(_t185) ? _t185 : SetK(k_150, p_183, Arr(Arr(((V)(0D)), Call(bv_154, V.Undef, p_183)))));
if (Lt(GetIdx(GetIdx(L_184, (ToNum(Get(L_184, "length")) - 1D)), 0D), t_153)) {
Invoke(L_184, "push", Arr(t_153, GetIdx(GetIdx(L_184, (ToNum(Get(L_184, "length")) - 1D)), 1D), ((V)("l"))));
}
}
}
t_153 = Add(t_153, dt_179);
{
foreach (V _k186 in ForInKeys(v_180)) {
V p_187 = default;
p_187 = _k186;
Invoke(GetK(k_150, p_187), "push", Arr(t_153, GetK(v_180, p_187), (ez_181 is var _t188 && Truthy(_t188) ? _t188 : ((V)("io")))));
}
}
return T_155;
return default;
}, 3, "to", false)).Put("wait", Fn((V _self189, int _argc190, V dt_196, V _a193, V _a194, V _a195, V[] _rest191) => {
if (_self189.IsNullish) _self189 = GlobalV;
t_153 = Add(t_153, dt_196);
return T_155;
return default;
}, 1, "wait", false)).Put("at", Fn((V _self197, int _argc198, V x_204, V _a201, V _a202, V _a203, V[] _rest199) => {
if (_self197.IsNullish) _self197 = GlobalV;
t_153 = x_204;
return T_155;
return default;
}, 1, "at", false)).Put("e", Fn((V _self205, int _argc206, V _a208, V _a209, V _a210, V _a211, V[] _rest207) => {
V a_212 = default;
if (_self205.IsNullish) _self205 = GlobalV;
a_212 = RestArgs(0, _argc206, _a208, _a209, _a210, _a211, _rest207);
Invoke(ev_151, "push", new ArrBuilder().Add(t_153).Spread(a_212).V);
return T_155;
return default;
}, 1, "e", false)).Put("fx", Fn((V _self213, int _argc214, V n_220, V w_221, V c_222, V _a219, V[] _rest215) => {
if (_self213.IsNullish) _self213 = GlobalV;
Invoke(ev_151, "push", Arr(t_153, ((V)("emit")), n_220, (w_221 is var _t223 && Truthy(_t223) ? _t223 : ((V)("body"))), c_222));
return T_155;
return default;
}, 3, "fx", false)).Put("osc", Fn((V _self224, int _argc225, V dt_231, V n_232, V A_233, V Bv_234, V[] _rest226) => {
double h_236 = 0;
V ez_235 = default;
if (_self224.IsNullish) _self224 = GlobalV;
ez_235 = (_argc225 > 4 ? _rest226[0] : V.Undef);
h_236 = ((ToNum(dt_231) / ToNum(n_232)) / 2D);
{
double i_237 = 0;
i_237 = 0D;
while (true) {
if (!(Lt(((V)(i_237)), n_232))) break;
Invoke(Invoke(T_155, "to", ((V)(h_236)), A_233, (ez_235 is var _t240 && Truthy(_t240) ? _t240 : ((V)("io")))), "to", ((V)(h_236)), Bv_234, (ez_235 is var _t239 && Truthy(_t239) ? _t239 : ((V)("io"))));
i_237++;
}
}
return T_155;
return default;
}, 5, "osc", false)).Put("back", Fn((V _self241, int _argc242, V dt_248, V keys_249, V ez_250, V _a247, V[] _rest243) => {
V v_251 = default;
if (_self241.IsNullish) _self241 = GlobalV;
v_251 = NewObj(0).V;
Invoke((keys_249 is var _t259 && Truthy(_t259) ? _t259 : Object_keys(k_150)), "forEach", Fn((V _self241, int _argc252, V p_258, V _a255, V _a256, V _a257, V[] _rest253) => {
return SetK(v_251, p_258, Call(bv_154, V.Undef, p_258));
}, 1, "", true));
return Invoke(T_155, "to", (dt_248 is var _t260 && Truthy(_t260) ? _t260 : ((V)(400D))), v_251, ez_250);
return default;
}, 3, "back", false)).Put("out", Fn((V _self261, int _argc262, V x_268, V loop_269, V _a266, V _a267, V[] _rest263) => {
if (_self261.IsNullish) _self261 = GlobalV;
{
foreach (V _k270 in ForInKeys(k_150)) {
V p_271 = default;
p_271 = _k270;
Invoke(GetK(k_150, p_271), "sort", Fn((V _self261, int _argc272, V a_278, V b_279, V _a276, V _a277, V[] _rest273) => {
return ((V)((ToNum(GetIdx(a_278, 0D)) - ToNum(GetIdx(b_279, 0D)))));
}, 2, "", true));
if (Truthy(loop_269)) {
V L_280 = default;
L_280 = GetK(k_150, p_271);
if (Lt(GetIdx(GetIdx(L_280, (ToNum(Get(L_280, "length")) - 1D)), 0D), t_153)) {
Invoke(L_280, "push", Arr(t_153, GetIdx(GetIdx(L_280, 0D), 1D), ((V)("io"))));
}
}
}
}
Invoke(ev_151, "sort", Fn((V _self261, int _argc281, V a_287, V b_288, V _a285, V _a286, V[] _rest282) => {
return ((V)((ToNum(GetIdx(a_287, 0D)) - ToNum(GetIdx(b_288, 0D)))));
}, 2, "", true));
return Object_assign((Truthy(loop_269) ? NewObj(1).Put("loop", t_153).V : NewObj(1).Put("dur", t_153).V), NewObj(3).Put("k", k_150).Put("ev", ev_151).Put("emit", em_152).V, (x_268 is var _t289 && Truthy(_t289) ? _t289 : NewObj(0).V));
return default;
}, 2, "out", false)).V;
return T_155;
return default;
}, 1, "TL", false);
seq_19 = Fn((V _self290, int _argc291, V t_297, V list_298, V gap_299, V _a296, V[] _rest292) => {
if (_self290.IsNullish) _self290 = GlobalV;
Invoke(list_298, "forEach", Fn((V _self290, int _argc300, V b_306, V i_307, V _a304, V _a305, V[] _rest301) => {
Invoke(t_297, "wait", GetIdx(gap_299, (ToNum(i_307) % ToNum(Get(gap_299, "length")))));
if (string.Equals(Typeof(b_306), "function")) {
Call(b_306, V.Undef, t_297);
} else {
V n_308 = default;
V a_309 = default;
{ V _t310 = ((b_306.O is JsArray) ? b_306 : Arr(b_306));
{ V _t311 = ListOf(_t310);
{ V _t312 = GetIdx(_t311, 0D);
n_308 = _t312; }
{ V _t313 = GetIdx(_t311, 1D);
a_309 = _t313; }
} }
InvokeK(BEAT_16, n_308, t_297, a_309);
}
return default;
}, 2, "", true));
return t_297;
return default;
}, 3, "seq", false);
sitdown_20 = Fn((V _self314, int _argc315, V B_321, V P_322, V _a319, V _a320, V[] _rest316) => {
V t_323 = default;
V all_324 = default;
V v_325 = default;
if (_self314.IsNullish) _self314 = GlobalV;
t_323 = Call(TL_11, V.Undef, REST_9);
all_324 = Call(keysOf_15, V.Undef, B_321);
Call(enterMove_21, V.Undef, t_323, B_321, (Get(P_322, "dn") is var _t326 && Truthy(_t326) ? _t326 : ((V)("hop"))));
if (Truthy(Get(P_322, "dnX"))) {
Invoke(P_322, "dnX", t_323, B_321);
}
v_325 = NewObj(0).V;
Invoke(all_324, "forEach", Fn((V _self314, int _argc327, V p_333, V _a330, V _a331, V _a332, V[] _rest328) => {
return SetK(v_325, p_333, GetK(B_321, p_333));
}, 1, "", true));
Invoke(t_323, "to", ((V)(140D)), v_325, ((V)("io")));
return Invoke(t_323, "out", NewObj(3).Put("next", ((V)("sit"))).Put("blend", ((V)(220D))).Put("look", (true ? V.True : V.False)).V);
return default;
}, 2, "sitdown", false);
enterMove_21 = Fn((V _self334, int _argc335, V t_341, V B_342, V st_343, V _a340, V[] _rest336) => {
V L_344 = default;
V Q_345 = default;
if (_self334.IsNullish) _self334 = GlobalV;
L_344 = (Get(B_342, "lift") is var _t346 && Truthy(_t346) ? _t346 : ((V)(0D)));
Q_345 = (Get(B_342, "sq") is var _t347 && Truthy(_t347) ? _t347 : ((V)(0D)));
if (SEqS(st_343, "float")) {
Invoke(Invoke(Invoke(t_341, "to", ((V)(260D)), NewObj(3).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.04)))).Put("hap", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(900D)), Call(o_10, V.Undef, B_342, NewObj(1).Put("lift", Add(L_344, ((V)(0.6)))).V), ((V)("s"))), "to", ((V)(320D)), NewObj(2).Put("lift", L_344).Put("sq", Q_345).V, ((V)("io")));
} else {
if (SEqS(st_343, "flop")) {
Invoke(Invoke(Invoke(Invoke(Invoke(t_341, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.1))).Put("tilt", ((V)((-4D)))).V), "to", ((V)(260D)), NewObj(4).Put("lift", ((V)(6D))).Put("sq", ((V)((-0.08)))).Put("tilt", ((V)(6D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_10, V.Undef, B_342, NewObj(3).Put("lift", ((V)((ToNum(L_344) - 1D)))).Put("sq", Add(Q_345, ((V)(0.16)))).Put("tilt", ((V)(0D))).V), ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)((ToNum(Q_345) - 0.03)))).Put("lift", Add(L_344, ((V)(0.6)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(3).Put("sq", Q_345).Put("lift", L_344).Put("open", (Get(B_342, "open") is var _t348 && Truthy(_t348) ? _t348 : ((V)(0D)))).V, ((V)("io")));
} else {
if (SEqS(st_343, "bounce")) {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_341, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.14))).V), "to", ((V)(240D)), NewObj(2).Put("lift", ((V)(8D))).Put("sq", ((V)((-0.14)))).V, ((V)("o"))), "to", ((V)(200D)), Call(o_10, V.Undef, B_342, NewObj(2).Put("lift", L_344).Put("sq", Add(Q_345, ((V)(0.2)))).V), ((V)("i"))), "to", ((V)(180D)), NewObj(2).Put("lift", Add(L_344, ((V)(3D)))).Put("sq", ((V)((ToNum(Q_345) - 0.08)))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(2).Put("lift", L_344).Put("sq", Add(Q_345, ((V)(0.1)))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(2).Put("lift", Add(L_344, ((V)(0.8)))).Put("sq", ((V)((ToNum(Q_345) - 0.02)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", L_344).Put("sq", Q_345).V, ((V)("io")));
} else {
if (SEqS(st_343, "spin")) {
Invoke(Invoke(Invoke(Invoke(Invoke(t_341, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.12))).V), "to", ((V)(380D)), NewObj(5).Put("lift", ((V)(9D))).Put("sq", ((V)((-0.12)))).Put("spin", ((V)(360D))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_10, V.Undef, B_342, NewObj(3).Put("lift", ((V)((ToNum(L_344) - 0.4)))).Put("sq", Add(Q_345, ((V)(0.12)))).Put("spin", ((V)(360D))).V), ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)((ToNum(Q_345) - 0.02)))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(3).Put("sq", Q_345).Put("spin", ((V)(360D))).Put("lift", L_344).V, ((V)("io")));
} else {
if (SEqS(st_343, "climb")) {
Invoke(Invoke(Invoke(Invoke(Invoke(t_341, "to", ((V)(220D)), NewObj(4).Put("footL", ((V)(3D))).Put("lift", ((V)(1.5))).Put("tilt", ((V)(2D))).Put("armL", ((V)(30D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(6).Put("footL", ((V)(0D))).Put("footR", ((V)(3D))).Put("lift", ((V)(4D))).Put("tilt", ((V)((-2D)))).Put("armL", ((V)(0D))).Put("armR", ((V)(30D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(5).Put("footR", ((V)(0D))).Put("lift", ((V)(5.5))).Put("tilt", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(240D)), Call(o_10, V.Undef, B_342, NewObj(2).Put("lift", ((V)((ToNum(L_344) - 0.4)))).Put("sq", Add(Q_345, ((V)(0.1)))).V), ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", Q_345).Put("lift", L_344).V, ((V)("io")));
} else {
if (SEqS(st_343, "slide")) {
Invoke(Invoke(Invoke(Invoke(t_341, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.08))).Put("lean", ((V)(2D))).V), "to", ((V)(420D)), Call(o_10, V.Undef, B_342, NewObj(3).Put("lift", Add(L_344, ((V)(2D)))).Put("lean", ((V)((-1.5)))).Put("sq", ((V)((ToNum(Q_345) - 0.03)))).V), ((V)("o"))), "to", ((V)(300D)), NewObj(3).Put("lift", L_344).Put("lean", ((V)(0D))).Put("sq", Add(Q_345, ((V)(0.05)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(1).Put("sq", Q_345).V, ((V)("io")));
} else {
Invoke(Invoke(Invoke(Invoke(Invoke(t_341, "to", ((V)(160D)), NewObj(5).Put("sq", ((V)(0.12))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(6).Put("lift", ((V)(7D))).Put("sq", ((V)((-0.12)))).Put("footL", ((V)(2.2))).Put("footR", ((V)(2.2))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("o"))), "to", ((V)(200D)), Call(o_10, V.Undef, B_342, NewObj(2).Put("lift", ((V)((ToNum(L_344) - 0.6)))).Put("sq", Add(Q_345, ((V)(0.12)))).V), ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)((ToNum(Q_345) - 0.025)))).Put("lift", Add(L_344, ((V)(0.4)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", Q_345).Put("lift", L_344).V, ((V)("io")));
}
}
}
}
}
}
return t_341;
return default;
}, 3, "enterMove", false);
exitMove_22 = Fn((V _self349, int _argc350, V t_356, V B_357, V st_358, V _a355, V[] _rest351) => {
V z_359 = default;
if (_self349.IsNullish) _self349 = GlobalV;
z_359 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_357), "forEach", Fn((V _self349, int _argc360, V p_366, V _a363, V _a364, V _a365, V[] _rest361) => {
return SetK(z_359, p_366, (GetK(REST_9, p_366) is var _t367 && Truthy(_t367) ? _t367 : ((V)(0D))));
}, 1, "", true));
if (SEqS(st_358, "float")) {
Invoke(Invoke(t_356, "to", ((V)(260D)), NewObj(2).Put("lift", Add((Get(B_357, "lift") is var _t368 && Truthy(_t368) ? _t368 : ((V)(0D))), ((V)(1D)))).Put("sq", Add((Get(B_357, "sq") is var _t369 && Truthy(_t369) ? _t369 : ((V)(0D))), ((V)(0.04)))).V, ((V)("io"))), "to", ((V)(360D)), Call(o_10, V.Undef, z_359, NewObj(2).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.03)))).V), ((V)("o")));
} else {
if (SEqS(st_358, "flop")) {
Invoke(Invoke(Invoke(t_356, "to", ((V)(180D)), NewObj(2).Put("sq", Add((Get(B_357, "sq") is var _t370 && Truthy(_t370) ? _t370 : ((V)(0D))), ((V)(0.06)))).Put("tilt", ((V)(4D))).V, ((V)("io"))), "to", ((V)(240D)), Call(o_10, V.Undef, z_359, NewObj(3).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.1)))).Put("tilt", ((V)((-3D)))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("tilt", ((V)(0D))).V, ((V)("i")));
} else {
Invoke(Invoke(Invoke(t_356, "to", ((V)(200D)), NewObj(4).Put("sq", Add((Get(B_357, "sq") is var _t371 && Truthy(_t371) ? _t371 : ((V)(0D))), ((V)(0.05)))).Put("pitch", ((V)((-0.12)))).Put("lean", ((V)(0.8))).Put("sit", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(220D)), Call(o_10, V.Undef, z_359, NewObj(6).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.1)))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(6).Put("lift", ((V)(0D))).Put("sq", ((V)(0.09))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("i")));
}
}
return t_356;
return default;
}, 3, "exitMove", false);
standup_23 = Fn((V _self372, int _argc373, V B_379, V P_380, V _a377, V _a378, V[] _rest374) => {
V t_381 = default;
V st_382 = default;
V z_383 = default;
if (_self372.IsNullish) _self372 = GlobalV;
t_381 = Call(TL_11, V.Undef, B_379);
st_382 = (Get(P_380, "up") is var _t384 && Truthy(_t384) ? _t384 : ((V)("hop")));
z_383 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_379), "forEach", Fn((V _self372, int _argc385, V p_391, V _a388, V _a389, V _a390, V[] _rest386) => {
return SetK(z_383, p_391, (GetK(REST_9, p_391) is var _t392 && Truthy(_t392) ? _t392 : ((V)(0D))));
}, 1, "", true));
if (SEqS(st_382, "float")) {
Invoke(Invoke(t_381, "to", ((V)(260D)), NewObj(2).Put("lift", Add((Get(B_379, "lift") is var _t393 && Truthy(_t393) ? _t393 : ((V)(0D))), ((V)(1D)))).Put("sq", Add((Get(B_379, "sq") is var _t394 && Truthy(_t394) ? _t394 : ((V)(0D))), ((V)(0.04)))).V, ((V)("io"))), "to", ((V)(360D)), Call(o_10, V.Undef, z_383, NewObj(2).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.03)))).V), ((V)("o")));
} else {
if (SEqS(st_382, "flop")) {
Invoke(Invoke(Invoke(t_381, "to", ((V)(180D)), NewObj(2).Put("sq", Add((Get(B_379, "sq") is var _t395 && Truthy(_t395) ? _t395 : ((V)(0D))), ((V)(0.06)))).Put("tilt", ((V)(4D))).V, ((V)("io"))), "to", ((V)(240D)), Call(o_10, V.Undef, z_383, NewObj(3).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.1)))).Put("tilt", ((V)((-3D)))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("tilt", ((V)(0D))).V, ((V)("i")));
} else {
Invoke(Invoke(Invoke(t_381, "to", ((V)(200D)), NewObj(4).Put("sq", Add((Get(B_379, "sq") is var _t396 && Truthy(_t396) ? _t396 : ((V)(0D))), ((V)(0.05)))).Put("pitch", ((V)((-0.12)))).Put("lean", ((V)(0.8))).Put("sit", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(220D)), Call(o_10, V.Undef, z_383, NewObj(6).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.1)))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(6).Put("lift", ((V)(0D))).Put("sq", ((V)(0.09))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("i")));
}
}
if (Truthy(Get(P_380, "upX"))) {
Invoke(P_380, "upX", t_381, B_379);
}
Invoke(t_381, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
return Invoke(t_381, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(160D))).V);
return default;
}, 2, "standup", false);
hold_24 = Fn((V _self397, int _argc398, V B_404, V beats_405, V gaps_406, V extra_407, V[] _rest399) => {
V t_408 = default;
V v_409 = default;
if (_self397.IsNullish) _self397 = GlobalV;
t_408 = Call(TL_11, V.Undef, B_404);
v_409 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_404), "forEach", Fn((V _self397, int _argc410, V p_416, V _a413, V _a414, V _a415, V[] _rest411) => {
return SetK(v_409, p_416, GetK(B_404, p_416));
}, 1, "", true));
Invoke(t_408, "to", ((V)(10D)), v_409);
Call(seq_19, V.Undef, t_408, beats_405, gaps_406);
Invoke(t_408, "wait", ((V)(1400D)));
return Invoke(t_408, "out", Call(o_10, V.Undef, NewObj(3).Put("breathe", ((V)(1D))).Put("look", (true ? V.True : V.False)).Put("blend", ((V)(520D))).V, (extra_407 is var _t417 && Truthy(_t417) ? _t417 : NewObj(0).V)), (true ? V.True : V.False));
return default;
}, 4, "hold", false);
watchHold_33 = Fn((V _self418, int _argc419, V B_425, V P_426, V key_427, V _a424, V[] _rest420) => {
V X_428 = default;
V two_429 = default;
V t_430 = default;
V v_431 = default;
V sig_432 = default;
V win_433 = default;
V bt_434 = default;
V gaps_435 = default;
V st_436 = default;
if (_self418.IsNullish) _self418 = GlobalV;
X_428 = (GetK(WX_29, key_427) is var _t437 && Truthy(_t437) ? _t437 : NewObj(0).V);
two_429 = (Truthy(GetK(LAP_27, key_427)) ? ((V)("lap")) : GetK(TWO_26, key_427));
t_430 = Call(TL_11, V.Undef, B_425);
v_431 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_425), "forEach", Fn((V _self418, int _argc438, V p_444, V _a441, V _a442, V _a443, V[] _rest439) => {
return SetK(v_431, p_444, GetK(B_425, p_444));
}, 1, "", true));
Invoke(t_430, "to", ((V)(10D)), v_431);
sig_432 = Invoke((Get(P_426, "f") is var _t452 && Truthy(_t452) ? _t452 : Arr()), "find", Fn((V _self418, int _argc445, V f_451, V _a448, V _a449, V _a450, V[] _rest446) => {
return (string.Equals(Typeof(f_451), "function") ? V.True : V.False);
}, 1, "", true));
win_433 = Arr();
bt_434 = Arr();
gaps_435 = (Get(P_426, "gap") is var _t453 && Truthy(_t453) ? _t453 : Arr(((V)(1600D)), ((V)(2400D)), ((V)(1900D)), ((V)(2600D)), ((V)(2100D))));
Invoke((Get(X_428, "order") is var _t463 && Truthy(_t463) ? _t463 : Arr(((V)("leanin")), ((V)("laugh")), ((V)("popcorn")), ((V)("gasp")), ((V)("sig")), ((V)("clap")), ((V)("popcorn")), ((V)("aww")), ((V)("cheer")))), "forEach", Fn((V _self418, int _argc454, V n_460, V i_461, V _a458, V _a459, V[] _rest455) => {
V a_462 = default;
Invoke(t_430, "wait", GetIdx(gaps_435, (ToNum(i_461) % ToNum(Get(gaps_435, "length")))));
if (SEqS(n_460, "sig")) {
if (Truthy(sig_432)) {
Call(sig_432, V.Undef, t_430);
}
return default;
}
a_462 = Get(t_430, "t");
InvokeK(WBEAT_30, n_460, t_430, X_428, two_429);
Invoke(bt_434, "push", Arr(n_460, a_462, Get(t_430, "t")));
if (SEqS(n_460, "popcorn")) {
Invoke(win_433, "push", Arr(a_462, Get(t_430, "t")));
}
return default;
}, 2, "", true));
Invoke(t_430, "wait", ((V)(1400D)));
st_436 = Invoke(t_430, "out", NewObj(3).Put("breathe", ((V)(1D))).Put("look", (false ? V.True : V.False)).Put("blend", ((V)(520D))).V, (true ? V.True : V.False));
Set(st_436, "prop", Call(popProp_32, V.Undef, win_433, Get(st_436, "loop"), two_429));
Set(st_436, "beats", bt_434);
return st_436;
return default;
}, 3, "watchHold", false);
snug_34 = Fn((V _self464, int _argc465, V B_471, V P_472, V s_473, V key_474, V[] _rest466) => {
V X_475 = default;
V K_476 = default;
V J_477 = default;
V la_478 = default;
V @short_479 = default;
double rg_480 = 0;
V SB_481 = default;
V t_482 = default;
V v_483 = default;
V NB_484 = default;
V bt_485 = default;
V st_486 = default;
if (_self464.IsNullish) _self464 = GlobalV;
X_475 = (GetK(WX_29, key_474) is var _t487 && Truthy(_t487) ? _t487 : NewObj(0).V);
K_476 = Call(SIDE_14, V.Undef, s_473);
J_477 = Call(SIDE_14, V.Undef, ((V)((-ToNum(s_473)))));
la_478 = ((Get(P_472, "lpose") is var _t488 && !Truthy(_t488) ? _t488 : Get(Get(P_472, "lpose"), "armL")) is var _t489 && Truthy(_t489) ? _t489 : ((V)(34D)));
@short_479 = (LeN(la_478, 14D) ? V.True : V.False);
rg_480 = (Truthy(GetK(RIGID_28, key_474)) ? 0.45 : 1D);
SB_481 = Call(o_10, V.Undef, B_471, NewObj(8).Put("tilt", Add((Get(B_471, "tilt") is var _t490 && Truthy(_t490) ? _t490 : ((V)(0D))), ((V)(((ToNum(s_473) * 5D) * rg_480))))).Put("lean", ((V)(((ToNum(s_473) * 2.4) * rg_480)))).Put("x", ((V)((ToNum(s_473) * 1.8)))).Put("htilt", ((V)(((ToNum(s_473) * 11D) * ((rg_480 < 1D) ? 0.6 : 1D))))).Put("close", ((V)(0.5))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.35))).Put("blush", ((V)(0.55))).V, (Truthy(@short_479) ? Call(hand_12, V.Undef, s_473, ((V)(3D)), ((V)(2D))) : Call(hand_12, V.Undef, s_473, ((V)(0D)), ((V)((-3D))))), NewObj(1).PutK(Get(K_476, "arm"), ((V)((Truthy(@short_479) ? 12D : Min(ToNum(la_478), 30D))))).V, Call(hand_12, V.Undef, ((V)((-ToNum(s_473)))), ((V)(7D)), ((V)(4D))), NewObj(1).PutK(Get(J_477, "arm"), ((V)(6D))).V, (Get(X_475, "snug") is var _t491 && Truthy(_t491) ? _t491 : NewObj(0).V));
t_482 = Call(TL_11, V.Undef, SB_481);
v_483 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, SB_481), "forEach", Fn((V _self464, int _argc492, V p_498, V _a495, V _a496, V _a497, V[] _rest493) => {
return SetK(v_483, p_498, GetK(SB_481, p_498));
}, 1, "", true));
Invoke(t_482, "to", ((V)(10D)), v_483);
NB_484 = NewObj(8).Put("nuzzle", Fn((V _self499, int _argc500, V t_506, V _a503, V _a504, V _a505, V[] _rest501) => {
if (_self499.IsNullish) _self499 = GlobalV;
Invoke(Invoke(t_506, "to", ((V)(300D)), NewObj(1).Put("close", ((V)(0.8))).V), "osc", ((V)(1800D)), ((V)(4D)), Call(o_10, V.Undef, NewObj(3).Put("htilt", Add(Get(SB_481, "htilt"), ((V)((ToNum(s_473) * 6D))))).Put("x", ((V)((ToNum(s_473) * 2.6)))).Put("sq", Add(Get(SB_481, "sq"), ((V)(0.015)))).V, Get(X_475, "nz")), Call(o_10, V.Undef, NewObj(3).Put("htilt", ((V)((ToNum(Get(SB_481, "htilt")) - (ToNum(s_473) * 2D))))).Put("x", ((V)((ToNum(s_473) * 1.5)))).Put("sq", Get(SB_481, "sq")).V, (Truthy(Get(X_475, "nz")) ? Object_fromEntries(Invoke(Object_keys(Get(X_475, "nz")), "map", Fn((V _self499, int _argc507, V k_513, V _a510, V _a511, V _a512, V[] _rest508) => {
return Arr(k_513, ((V)(((-ToNum(GetK(Get(X_475, "nz"), k_513))) * (SEqS(k_513, "wag") ? 1D : 0D)))));
}, 1, "", true))) : NewObj(0).V)), ((V)("s")));
return Invoke(t_506, "back", ((V)(500D)));
return default;
}, 1, "nuzzle", false)).Put("heart", Fn((V _self514, int _argc515, V t_521, V _a518, V _a519, V _a520, V[] _rest516) => {
if (_self514.IsNullish) _self514 = GlobalV;
Invoke(Invoke(Invoke(t_521, "to", ((V)(300D)), NewObj(4).Put("blush", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "wait", ((V)(900D)));
return Invoke(t_521, "back", ((V)(500D)));
return default;
}, 1, "heart", false)).Put("pat", Fn((V _self522, int _argc523, V t_529, V _a526, V _a527, V _a528, V[] _rest524) => {
if (_self522.IsNullish) _self522 = GlobalV;
Invoke(t_529, "osc", ((V)(1500D)), ((V)(3D)), NewObj(2).PutK(Get(K_476, "hy"), ((V)((ToNum(GetK(SB_481, Get(K_476, "hy"))) - 5D)))).PutK(Get(K_476, "arm"), Add(GetK(SB_481, Get(K_476, "arm")), ((V)(6D)))).V, NewObj(2).PutK(Get(K_476, "hy"), GetK(SB_481, Get(K_476, "hy"))).PutK(Get(K_476, "arm"), GetK(SB_481, Get(K_476, "arm"))).V, ((V)("o")));
return Invoke(t_529, "back", ((V)(400D)));
return default;
}, 1, "pat", false)).Put("squeeze", Fn((V _self530, int _argc531, V t_537, V _a534, V _a535, V _a536, V[] _rest532) => {
if (_self530.IsNullish) _self530 = GlobalV;
Invoke(Invoke(t_537, "to", ((V)(320D)), NewObj(5).Put("sq", Add(Get(SB_481, "sq"), ((V)(0.06)))).Put("x", ((V)((ToNum(s_473) * 3.2)))).Put("close", ((V)(1D))).Put("hap", ((V)(1D))).PutK(Get(K_476, "arm"), Add(GetK(SB_481, Get(K_476, "arm")), ((V)(10D)))).V, ((V)("o"))), "wait", ((V)(700D)));
return Invoke(t_537, "back", ((V)(520D)));
return default;
}, 1, "squeeze", false)).Put("giggle", Fn((V _self538, int _argc539, V t_545, V _a542, V _a543, V _a544, V[] _rest540) => {
if (_self538.IsNullish) _self538 = GlobalV;
Invoke(BEAT_16, "giggle", t_545, ((V)((-ToNum(s_473)))));
return t_545;
return default;
}, 1, "giggle", false)).Put("sigh", Fn((V _self546, int _argc547, V t_553, V _a550, V _a551, V _a552, V[] _rest548) => {
if (_self546.IsNullish) _self546 = GlobalV;
Invoke(BEAT_16, "sigh", t_553);
return t_553;
return default;
}, 1, "sigh", false)).Put("doze", Fn((V _self554, int _argc555, V t_561, V _a558, V _a559, V _a560, V[] _rest556) => {
if (_self554.IsNullish) _self554 = GlobalV;
Invoke(BEAT_16, "doze", t_561);
return t_561;
return default;
}, 1, "doze", false)).Put("ears", Fn((V _self562, int _argc563, V t_569, V _a566, V _a567, V _a568, V[] _rest564) => {
if (_self562.IsNullish) _self562 = GlobalV;
Invoke(BEAT_16, "ears", t_569);
return t_569;
return default;
}, 1, "ears", false)).V;
bt_485 = Arr();
Invoke((Get(X_475, "snugOrder") is var _t581 && Truthy(_t581) ? _t581 : Arr(((V)("nuzzle")), ((V)("sigh")), ((V)("heart")), ((V)("pat")), ((V)("doze")), ((V)("ears")), ((V)("squeeze")), ((V)("giggle")))), "forEach", Fn((V _self464, int _argc570, V n_576, V i_577, V _a574, V _a575, V[] _rest571) => {
V g_578 = default;
V a_579 = default;
g_578 = (Get(P_472, "lgap") is var _t580 && Truthy(_t580) ? _t580 : Arr(((V)(1800D)), ((V)(2600D)), ((V)(2200D)), ((V)(3000D))));
Invoke(t_482, "wait", GetIdx(g_578, (ToNum(i_577) % ToNum(Get(g_578, "length")))));
a_579 = Get(t_482, "t");
InvokeK(NB_484, n_576, t_482);
Invoke(bt_485, "push", Arr(n_576, a_579, Get(t_482, "t")));
return default;
}, 2, "", true));
Invoke(t_482, "wait", ((V)(1400D)));
st_486 = Invoke(t_482, "out", NewObj(3).Put("breathe", ((V)(1D))).Put("look", (false ? V.True : V.False)).Put("blend", ((V)(620D))).V, (true ? V.True : V.False));
Set(st_486, "beats", bt_485);
return st_486;
return default;
}, 4, "snug", false);
build_36 = Fn((V _self582, int _argc583, V key_589, V P_590, V _a587, V _a588, V[] _rest584) => {
V B_591 = default;
V LB_592 = default;
V fid_593 = default;
V lf_594 = default;
V S_595 = default;
V dl_596 = default;
V WB_597 = default;
V nm_598 = default;
V dw_599 = default;
if (_self582.IsNullish) _self582 = GlobalV;
P_590 = (P_590 is var _t600 && Truthy(_t600) ? _t600 : NewObj(0).V);
B_591 = Call(o_10, V.Undef, SIT0_17, (Get(P_590, "pose") is var _t601 && Truthy(_t601) ? _t601 : NewObj(0).V));
LB_592 = Call(o_10, V.Undef, B_591, LNG0_18, (Get(P_590, "lpose") is var _t602 && Truthy(_t602) ? _t602 : NewObj(0).V));
fid_593 = (Get(P_590, "f") is var _t603 && Truthy(_t603) ? _t603 : Arr(((V)("look")), ((V)("swing")), ((V)("pat")), ((V)("yawn"))));
lf_594 = (Get(P_590, "lf") is var _t604 && Truthy(_t604) ? _t604 : Arr(((V)("sigh")), ((V)("stretch")), ((V)("doze")), ((V)("belly"))));
S_595 = NewObj(0).V;
SetK(S_595, ((V)((Truthy(key_589) ? string.Concat("sitdown@", ToStr(key_589)) : "sitdown"))), Call(sitdown_20, V.Undef, B_591, P_590));
SetK(S_595, ((V)((Truthy(key_589) ? string.Concat("sit@", ToStr(key_589)) : "sit"))), Call(hold_24, V.Undef, B_591, fid_593, (Get(P_590, "gap") is var _t605 && Truthy(_t605) ? _t605 : Arr(((V)(1600D)), ((V)(2400D)), ((V)(1900D)), ((V)(2600D)), ((V)(2100D))))));
SetK(S_595, ((V)((Truthy(key_589) ? string.Concat("standup@", ToStr(key_589)) : "standup"))), Call(standup_23, V.Undef, B_591, P_590));
SetK(S_595, ((V)((Truthy(key_589) ? string.Concat("lounge@", ToStr(key_589)) : "lounge"))), Call(hold_24, V.Undef, LB_592, lf_594, (Get(P_590, "lgap") is var _t606 && Truthy(_t606) ? _t606 : Arr(((V)(1800D)), ((V)(2600D)), ((V)(2200D)), ((V)(3000D))))));
dl_596 = Call(sitdown_20, V.Undef, LB_592, Call(o_10, V.Undef, P_590, NewObj(1).Put("dnX", (Get(P_590, "ldnX") is var _t607 && Truthy(_t607) ? _t607 : Get(P_590, "dnX"))).V));
Set(dl_596, "next", ((V)("lounge")));
SetK(S_595, ((V)((Truthy(key_589) ? string.Concat("sitdown_lounge@", ToStr(key_589)) : "sitdown_lounge"))), dl_596);
WB_597 = Call(o_10, V.Undef, B_591, NewObj(1).Put("pitch", ((V)((ToNum((Get(B_591, "pitch") is var _t608 && Truthy(_t608) ? _t608 : ((V)(0D)))) - 0.03)))).V, (Get(P_590, "wpose") is var _t609 && Truthy(_t609) ? _t609 : NewObj(0).V));
nm_598 = Fn((V _self582, int _argc610, V n_616, V _a613, V _a614, V _a615, V[] _rest611) => {
return (Truthy(key_589) ? ((V)(string.Concat(ToStr(n_616), "@", ToStr(key_589)))) : n_616);
}, 1, "", true);
SetK(S_595, Call(nm_598, V.Undef, ((V)("watch"))), Call(watchHold_33, V.Undef, WB_597, P_590, key_589));
dw_599 = Call(sitdown_20, V.Undef, WB_597, P_590);
Set(dw_599, "next", ((V)("watch")));
SetK(S_595, Call(nm_598, V.Undef, ((V)("sitdown_watch"))), dw_599);
SetK(S_595, Call(nm_598, V.Undef, ((V)("snuggleL"))), Call(snug_34, V.Undef, B_591, P_590, ((V)((-1D))), key_589));
SetK(S_595, Call(nm_598, V.Undef, ((V)("snuggleR"))), Call(snug_34, V.Undef, B_591, P_590, ((V)(1D)), key_589));
Invoke(R_8, "add", S_595);
Set(R_8, "HS", Object_assign((Get(R_8, "HS") is var _t617 && Truthy(_t617) ? _t617 : NewObj(0).V), S_595));
if (Truthy(key_589)) {
SetK(PROF_35, key_589, P_590);
}
return default;
}, 2, "build", false);
quilt_46 = Fn((V _self618, int _argc619, V I_625, V P_626, V W_627, V qk_628, V[] _rest620) => {
V ok_629 = default;
V hx_630 = default;
double a_631 = 0;
V ux_632 = default;
V uy_633 = default;
V L_634 = default;
V Rr_635 = default;
V sp_636 = default;
double hw_637 = 0;
double mx_638 = 0;
double my_639 = 0;
V M_640 = default;
double mz_641 = 0;
V tg_642 = default;
double y1_643 = 0;
double y0_644 = 0;
V col_645 = default;
V dk_646 = default;
V lt_647 = default;
double hh_648 = 0;
double w2_649 = 0;
V top_650 = default;
V body_651 = default;
V h_652 = default;
if (_self618.IsNullish) _self618 = GlobalV;
ok_629 = Fn((V _self618, int _argc653, V p_659, V _a656, V _a657, V _a658, V[] _rest654) => {
return ((p_659 is var _t660 && !Truthy(_t660) ? _t660 : (IsFiniteV(GetIdx(p_659, 0D)) ? V.True : V.False)) is var _t661 && !Truthy(_t661) ? _t661 : (IsFiniteV(GetIdx(p_659, 1D)) ? V.True : V.False));
}, 1, "", true);
hx_630 = (Get(I_625, "hq") is var _t662 && Truthy(_t662) ? _t662 : NewObj(0).V);
a_631 = ((ToNum((Get(P_626, "tilt") is var _t663 && Truthy(_t663) ? _t663 : ((V)(0D)))) * System.Math.PI) / 180D);
ux_632 = Arr(((V)(FdLibm.Cos(a_631))), ((V)(FdLibm.Sin(a_631))));
uy_633 = Arr(((V)((-FdLibm.Sin(a_631)))), ((V)(FdLibm.Cos(a_631))));
L_634 = Get(W_627, "sideL");
Rr_635 = Get(W_627, "sideR");
if ((!(Truthy(Call(ok_629, V.Undef, L_634))) || !(Truthy(Call(ok_629, V.Undef, Rr_635))))) {
V fl_664 = default;
V fr_665 = default;
V c_666 = default;
double hs_667 = 0;
fl_664 = Get(W_627, "footL");
fr_665 = Get(W_627, "footR");
c_666 = (Truthy((Call(ok_629, V.Undef, fl_664) is var _t668 && !Truthy(_t668) ? _t668 : Call(ok_629, V.Undef, fr_665))) ? Arr(((V)(((ToNum(Add(GetIdx(fl_664, 0D), GetIdx(fr_665, 0D))) / 2D) - (ToNum(GetIdx(uy_633, 0D)) * 11D)))), ((V)(((ToNum(Add(GetIdx(fl_664, 1D), GetIdx(fr_665, 1D))) / 2D) - (ToNum(GetIdx(uy_633, 1D)) * 11D))))) : (Truthy(Call(ok_629, V.Undef, Get(W_627, "belly"))) ? Get(W_627, "belly") : (Truthy(Call(ok_629, V.Undef, Get(W_627, "body"))) ? Get(W_627, "body") : V.Null)));
if (!(Truthy(c_666))) {
return ((V)(""));
}
hs_667 = (Truthy((Call(ok_629, V.Undef, fl_664) is var _t669 && !Truthy(_t669) ? _t669 : Call(ok_629, V.Undef, fr_665))) ? Max(((Hypot((ToNum(GetIdx(fr_665, 0D)) - ToNum(GetIdx(fl_664, 0D))), (ToNum(GetIdx(fr_665, 1D)) - ToNum(GetIdx(fl_664, 1D)))) * 1.15) + 9D), 18D) : 20D);
L_634 = Arr(((V)((ToNum(GetIdx(c_666, 0D)) - (ToNum(GetIdx(ux_632, 0D)) * hs_667)))), ((V)((ToNum(GetIdx(c_666, 1D)) - (ToNum(GetIdx(ux_632, 1D)) * hs_667)))));
Rr_635 = Arr(Add(GetIdx(c_666, 0D), ((V)((ToNum(GetIdx(ux_632, 0D)) * hs_667)))), Add(GetIdx(c_666, 1D), ((V)((ToNum(GetIdx(ux_632, 1D)) * hs_667)))));
}
sp_636 = (((V)(Hypot((ToNum(GetIdx(Rr_635, 0D)) - ToNum(GetIdx(L_634, 0D))), (ToNum(GetIdx(Rr_635, 1D)) - ToNum(GetIdx(L_634, 1D)))))) is var _t670 && Truthy(_t670) ? _t670 : ((V)(30D)));
Set(I_625, "_qs", ((V)(Max(ToNum((Get(I_625, "_qs") is var _t671 && Truthy(_t671) ? _t671 : ((V)(0D)))), ToNum(sp_636)))));
hw_637 = Min(((ToNum(Get(I_625, "_qs")) * 0.56) + 4D), 40D);
mx_638 = (ToNum(Add(GetIdx(L_634, 0D), GetIdx(Rr_635, 0D))) / 2D);
my_639 = (ToNum(Add(GetIdx(L_634, 1D), GetIdx(Rr_635, 1D))) / 2D);
M_640 = Get(W_627, "mouth");
mz_641 = (Truthy(Call(ok_629, V.Undef, M_640)) ? (((ToNum(GetIdx(M_640, 0D)) - mx_638) * ToNum(GetIdx(uy_633, 0D))) + ((ToNum(GetIdx(M_640, 1D)) - my_639) * ToNum(GetIdx(uy_633, 1D)))) : (-16D));
tg_642 = Add(Call(cl_39, V.Undef, ((V)((mz_641 + 6.5))), ((V)((-24D))), ((V)(2D))), (Get(I_625, "_qy") is var _t672 && Truthy(_t672) ? _t672 : ((V)(0D))));
Set(I_625, "_qt", (Get(I_625, "_qt").IsNullish ? tg_642 : Add(Get(I_625, "_qt"), ((V)(((ToNum(tg_642) - ToNum(Get(I_625, "_qt"))) * 0.12))))));
y1_643 = 17D;
y0_644 = (y1_643 - ((y1_643 - ToNum(Get(I_625, "_qt"))) * ToNum(Call(cl_39, V.Undef, qk_628, ((V)(0D)), ((V)(1D))))));
if (((y1_643 - y0_644) < 1.2)) {
return ((V)(""));
}
col_645 = (Get(hx_630, "quilt") is var _t673 && Truthy(_t673) ? _t673 : ((V)("#7f9fd0")));
dk_646 = Call(shade_42, V.Undef, col_645, ((V)(0.7)));
lt_647 = Call(shade_42, V.Undef, col_645, ((V)(1.35)));
hh_648 = (y1_643 - y0_644);
w2_649 = (hw_637 / 2D);
top_650 = ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_38, V.Undef, ((V)((-hw_637))))), " ", ToStr(Call(r2_38, V.Undef, ((V)(y0_644)))), "Q", ToStr(Call(r2_38, V.Undef, ((V)((-w2_649))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 - 1.6))))), " 0 ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 - 0.4))))), "Q", ToStr(Call(r2_38, V.Undef, ((V)(w2_649)))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 - 1.6))))), " ", ToStr(Call(r2_38, V.Undef, ((V)(hw_637)))), " ", ToStr(Call(r2_38, V.Undef, ((V)(y0_644)))) })));
body_651 = ((V)(string.Concat(new string[] { ToStr(top_650), "L", ToStr(Call(r2_38, V.Undef, ((V)((hw_637 + 1.5))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 - 3D))))), "Q", ToStr(Call(r2_38, V.Undef, ((V)((hw_637 + 1.5))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 + 1D))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((hw_637 - 3D))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 + 1D))))), "L", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) + 3D))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 + 1D))))), "Q", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) - 1.5))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 + 1D))))), " ", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) - 1.5))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 - 3D))))), "Z" })));
h_652 = ((V)(string.Concat(new string[] { "<g transform=\"matrix(", ToStr(Call(r2_38, V.Undef, GetIdx(ux_632, 0D))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(ux_632, 1D))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(uy_633, 0D))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(uy_633, 1D))), " ", ToStr(Call(r2_38, V.Undef, ((V)(mx_638)))), " ", ToStr(Call(r2_38, V.Undef, ((V)(my_639)))), ")\">", ToStr(Call(pa_44, V.Undef, body_651, col_645, dk_646, ((V)(0.7)))) })));
h_652 = ((V)(string.Concat(new string[] { ToStr(h_652), "<ellipse cx=\"", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) * 0.38))))), "\" cy=\"", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 + (hh_648 * 0.34)))))), "\" rx=\"", ToStr(Call(r2_38, V.Undef, ((V)((hw_637 * 0.42))))), "\" ry=\"", ToStr(Call(r2_38, V.Undef, ((V)((hh_648 * 0.22))))), "\" fill=\"", ToStr(lt_647), "\" opacity=\"0.45\"/>" })));
h_652 = Add(h_652, Invoke(Call(pa_44, V.Undef, ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) - 1.5))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 - 3D))))), "Q0 ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 - 5.5))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((hw_637 + 1.5))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 - 3D))))), "Q", ToStr(Call(r2_38, V.Undef, ((V)((hw_637 + 1.5))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 + 1D))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((hw_637 - 3D))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 + 1D))))), "L", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) + 3D))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 + 1D))))), "Q", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) - 1.5))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 + 1D))))), " ", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) - 1.5))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 - 3D))))), "Z" }))), dk_646), "replace", ((V)("/>")), ((V)(" opacity=\"0.35\"/>"))));
if ((hh_648 > 7D)) {
V ym_674 = default;
ym_674 = Call(r2_38, V.Undef, ((V)((y0_644 + (hh_648 * 0.55)))));
h_652 = ((V)(string.Concat(new string[] { ToStr(h_652), "<path d=\"M", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) / 3D))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 + 3.4))))), "V", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 - 0.6))))), "M", ToStr(Call(r2_38, V.Undef, ((V)((hw_637 / 3D))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 + 3.4))))), "V", ToStr(Call(r2_38, V.Undef, ((V)((y1_643 - 0.6))))), "M", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) + 1D))))), " ", ToStr(ym_674), "H", ToStr(Call(r2_38, V.Undef, ((V)((hw_637 - 1D))))), "\" stroke=\"", ToStr(dk_646), "\" stroke-width=\"0.45\" stroke-dasharray=\"1.2 1\" opacity=\"0.7\" fill=\"none\"/>" })));
}
h_652 = Add(h_652, Call(pa_44, V.Undef, ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) - 0.8))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 - 0.2))))), "Q", ToStr(Call(r2_38, V.Undef, ((V)((-w2_649))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 - 1.8))))), " 0 ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 - 0.6))))), "Q", ToStr(Call(r2_38, V.Undef, ((V)(w2_649)))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 - 1.8))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((hw_637 + 0.8))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 - 0.2))))), "L", ToStr(Call(r2_38, V.Undef, ((V)((hw_637 + 0.6))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 + 2.6))))), "Q", ToStr(Call(r2_38, V.Undef, ((V)(w2_649)))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 + 1.4))))), " 0 ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 + 2.2))))), "Q", ToStr(Call(r2_38, V.Undef, ((V)((-w2_649))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 + 1.4))))), " ", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) - 0.6))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 + 2.6))))), "Z" }))), ((V)("#fffaf1")), ((V)("#d6cbb8")), ((V)(0.45))));
h_652 = Add(h_652, Call(pa_44, V.Undef, ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) * 0.7))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 + 0.4))))), "Q", ToStr(Call(r2_38, V.Undef, ((V)((-w2_649))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 - 0.6))))), " ", ToStr(Call(r2_38, V.Undef, ((V)(((-hw_637) * 0.2))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_644 - 0.1))))) }))), V.Null, ((V)("#ffffff")), ((V)(0.6))));
return ((V)(string.Concat(ToStr(h_652), "</g>")));
return default;
}, 4, "quilt", false);
sleepFx_47 = Fn((V _self675, int _argc676, V icon_682, V zc_683, V qy_684, V _a681, V[] _rest677) => {
V IC_685 = default;
if (_self675.IsNullish) _self675 = GlobalV;
IC_685 = (GetK(ICON_45, icon_682) is var _t686 && Truthy(_t686) ? _t686 : Get(ICON_45, "star"));
return Fn((V _self675, int _argc687, V I_693, V tt_694, V _a691, V _a692, V[] _rest688) => {
V P_695 = default;
V W_696 = default;
V h_697 = default;
V qk_698 = default;
V H_699 = default;
V zz_700 = default;
V dm_701 = default;
P_695 = (Get(I_693, "lastP") is var _t702 && Truthy(_t702) ? _t702 : NewObj(0).V);
W_696 = (Get(I_693, "W") is var _t703 && Truthy(_t703) ? _t703 : NewObj(0).V);
h_697 = ((V)(""));
Set(I_693, "_qy", (qy_684 is var _t704 && Truthy(_t704) ? _t704 : ((V)(0D))));
qk_698 = (Get(P_695, "qk") is var _t705 && Truthy(_t705) ? _t705 : ((V)(0D)));
if (GtN(qk_698, 0.02)) {
h_697 = Add(h_697, Call(quilt_46, V.Undef, I_693, P_695, W_696, qk_698));
}
H_699 = (Get(W_696, "head") is var _t706 && Truthy(_t706) ? _t706 : Get(I_693, "topW"));
if (((!(Truthy(H_699)) || !(IsFiniteV(GetIdx(H_699, 0D)))) || !(IsFiniteV(GetIdx(H_699, 1D))))) {
return h_697;
}
zz_700 = (Get(P_695, "zz") is var _t707 && Truthy(_t707) ? _t707 : ((V)(0D)));
if (GtN(zz_700, 0.03)) {
{
double i_708 = 0;
i_708 = 0D;
while (true) {
if (!((i_708 < 3D))) break;
double u_710 = 0;
V big_711 = default;
V x_712 = default;
double y_713 = 0;
u_710 = (((ToNum(tt_694) / 2600D) + (i_708 / 3D)) % 1D);
big_711 = Call(cl_39, V.Undef, ((V)((ToNum(zz_700) - 1D))), ((V)(0D)), ((V)(1D)));
x_712 = Add(Add(Add(GetIdx(H_699, 0D), ((V)(11D))), ((V)((u_710 * 13D)))), ((V)((FdLibm.Sin((u_710 * TAU_37)) * 2D))));
y_713 = ((ToNum(Add(GetIdx(H_699, 1D), ((V)(3D)))) - (u_710 * 21D)) - (ToNum(big_711) * 2D));
h_697 = ((V)(string.Concat(new string[] { ToStr(h_697), "<text x=\"", ToStr(Call(r2_38, V.Undef, x_712)), "\" y=\"", ToStr(Call(r2_38, V.Undef, ((V)(y_713)))), "\" font-family=\"Fredoka,sans-serif\" font-weight=\"700\" font-size=\"", ToStr(Call(r2_38, V.Undef, ((V)(((4.5 + (u_710 * 4.8)) * (1D + (ToNum(big_711) * 0.55))))))), "\" fill=\"", ToStr((zc_683 is var _t714 && Truthy(_t714) ? _t714 : ((V)("#8f3cf2")))), "\" stroke=\"#ffffff\" stroke-width=\"0.6\" paint-order=\"stroke\" opacity=\"", ToStr(Call(r2_38, V.Undef, ((V)((FdLibm.Sin((System.Math.PI * u_710)) * ToNum(Call(cl_39, V.Undef, zz_700, ((V)(0D)), ((V)(1D))))))))), "\">", (GtN(big_711, 0.4) ? "Z" : "z"), "</text>" })));
i_708++;
}
}
}
dm_701 = Call(cl_39, V.Undef, (Get(P_695, "drm") is var _t715 && Truthy(_t715) ? _t715 : ((V)(0D))), ((V)(0D)), ((V)(1D)));
if (GtN(dm_701, 0.02)) {
double s_716 = 0;
double bx_717 = 0;
double by_718 = 0;
s_716 = (0.55 + (0.45 * ToNum(dm_701)));
bx_717 = (ToNum(GetIdx(H_699, 0D)) - 15D);
by_718 = ((ToNum(GetIdx(H_699, 1D)) - 13D) + (FdLibm.Sin((ToNum(tt_694) / 700D)) * 1.2));
h_697 = ((V)(string.Concat(new string[] { ToStr(h_697), "<g opacity=\"", ToStr(Call(r2_38, V.Undef, dm_701)), "\">", ToStr(Call(ci_43, V.Undef, Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(H_699, 0D)) - 5D)))), Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(H_699, 1D)) - 2D)))), ((V)(1.1)), ((V)("#ffffff")), ((V)("#b9a6e0")))), ToStr(Call(ci_43, V.Undef, Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(H_699, 0D)) - 9D)))), Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(H_699, 1D)) - 6.5)))), ((V)(1.7)), ((V)("#ffffff")), ((V)("#b9a6e0")))), "<g transform=\"translate(", ToStr(Call(r2_38, V.Undef, ((V)(bx_717)))), " ", ToStr(Call(r2_38, V.Undef, ((V)(by_718)))), ") scale(", ToStr(Call(r2_38, V.Undef, ((V)(s_716)))), ")\"><circle r=\"8\" fill=\"#ffffff\" stroke=\"#b9a6e0\" stroke-width=\"0.7\"/><circle cx=\"-3\" cy=\"-4\" r=\"2.2\" fill=\"#f2ecff\"/><g transform=\"scale(1.05) rotate(", ToStr(Call(r2_38, V.Undef, ((V)((FdLibm.Sin((ToNum(tt_694) / 520D)) * 8D))))), ")\">", ToStr(IC_685), "</g></g></g>" })));
}
return h_697;
return default;
}, 2, "", true);
return default;
}, 3, "sleepFx", false);
sleepHold_50 = Fn((V _self719, int _argc720, V LB_726, V X_727, V kind_728, V fx_729, V[] _rest721) => {
V t_730 = default;
V v_731 = default;
V bt_732 = default;
V g_733 = default;
V st_734 = default;
if (_self719.IsNullish) _self719 = GlobalV;
t_730 = Call(TL_11, V.Undef, LB_726);
v_731 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, LB_726), "forEach", Fn((V _self719, int _argc735, V p_741, V _a738, V _a739, V _a740, V[] _rest736) => {
return SetK(v_731, p_741, GetK(LB_726, p_741));
}, 1, "", true));
Invoke(t_730, "to", ((V)(10D)), v_731);
bt_732 = Arr();
g_733 = (Get(X_727, "gap") is var _t742 && Truthy(_t742) ? _t742 : Arr(((V)(2200D)), ((V)(3000D)), ((V)(2600D)), ((V)(3400D))));
Invoke((GetK(X_727, ((V)(string.Concat(ToStr(kind_728), "Ord")))) is var _t758 && Truthy(_t758) ? _t758 : GetK(SORD_49, kind_728)), "forEach", Fn((V _self719, int _argc743, V b_749, V i_750, V _a747, V _a748, V[] _rest744) => {
V n_751 = default;
V a_752 = default;
V a0_753 = default;
Invoke(t_730, "wait", GetIdx(g_733, (ToNum(i_750) % ToNum(Get(g_733, "length")))));
{ V _t754 = ((b_749.O is JsArray) ? b_749 : Arr(b_749));
{ V _t755 = ListOf(_t754);
{ V _t756 = GetIdx(_t755, 0D);
n_751 = _t756; }
{ V _t757 = GetIdx(_t755, 1D);
a_752 = _t757; }
} }
a0_753 = Get(t_730, "t");
if (SEqS(n_751, "sig")) {
if (!(Truthy(Get(X_727, "s")))) {
return default;
}
Invoke(X_727, "s", t_730);
} else {
InvokeK(ZB_48, n_751, t_730, a_752, X_727);
}
Invoke(bt_732, "push", Arr(n_751, a0_753, Get(t_730, "t")));
return default;
}, 2, "", true));
Invoke(t_730, "wait", ((V)(1600D)));
st_734 = Invoke(t_730, "out", NewObj(5).Put("breathe", ((V)(0.6))).Put("look", (false ? V.True : V.False)).Put("blend", ((V)(650D))).Put("noBlink", (true ? V.True : V.False)).Put("fx", fx_729).V, (true ? V.True : V.False));
Set(st_734, "beats", bt_732);
return st_734;
return default;
}, 4, "sleepHold", false);
bedIn_51 = Fn((V _self759, int _argc760, V B_766, V LB_767, V P_768, V X_769, V[] _rest761) => {
V t_772 = default;
V dn_773 = default;
V v_774 = default;
V v2_775 = default;
V kind_770 = default;
V fx_771 = default;
if (_self759.IsNullish) _self759 = GlobalV;
kind_770 = (_argc760 > 4 ? _rest761[0] : V.Undef);
fx_771 = (_argc760 > 5 ? _rest761[1] : V.Undef);
t_772 = Call(TL_11, V.Undef, REST_9);
dn_773 = (Get(X_769, "dn") is var _t777 && Truthy(_t777) ? _t777 : (SEqS(kind_770, "bean") ? ((V)((SEqS(Get(P_768, "dn"), "float") ? "float" : "flop"))) : (Get(P_768, "dn") is var _t776 && Truthy(_t776) ? _t776 : ((V)("hop")))));
Call(enterMove_21, V.Undef, t_772, B_766, dn_773);
if (Truthy(Get(P_768, "dnX"))) {
Invoke(P_768, "dnX", t_772, B_766);
}
v_774 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_766), "forEach", Fn((V _self759, int _argc778, V p_784, V _a781, V _a782, V _a783, V[] _rest779) => {
return SetK(v_774, p_784, GetK(B_766, p_784));
}, 1, "", true));
Invoke(t_772, "to", ((V)(140D)), v_774, ((V)("io")));
if (SEqS(kind_770, "bean")) {
Invoke(Invoke(t_772, "to", ((V)(240D)), NewObj(2).Put("sq", Add(Get(B_766, "sq"), ((V)(0.2)))).Put("lift", ((V)((ToNum(Get(B_766, "lift")) - 2.4)))).V, ((V)("i"))), "to", ((V)(320D)), NewObj(2).Put("sq", Add(Get(B_766, "sq"), ((V)(0.07)))).Put("lift", ((V)((ToNum(Get(B_766, "lift")) - 1.2)))).V, ((V)("o")));
Invoke(Invoke(t_772, "to", ((V)(700D)), NewObj(4).Put("spin", ((V)(180D))).Put("footL", Add((Get(B_766, "footL") is var _t787 && Truthy(_t787) ? _t787 : ((V)(0D))), ((V)(1.6)))).Put("footR", (Get(B_766, "footR") is var _t788 && Truthy(_t788) ? _t788 : ((V)(0D)))).Put("x", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(4).Put("spin", ((V)(360D))).Put("footL", (Get(B_766, "footL") is var _t785 && Truthy(_t785) ? _t785 : ((V)(0D)))).Put("footR", Add((Get(B_766, "footR") is var _t786 && Truthy(_t786) ? _t786 : ((V)(0D))), ((V)(1.6)))).Put("x", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_772, "to", ((V)(1000D)), Call(o_10, V.Undef, LB_767, NewObj(4).Put("spin", ((V)(360D))).Put("close", ((V)(0.6))).Put("zz", ((V)(0D))).Put("smile", ((V)(0.6))).V), ((V)("s"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V), "to", ((V)(900D)), NewObj(3).Put("close", ((V)(1D))).Put("zz", ((V)(1D))).Put("smile", Get(LB_767, "smile")).V, ((V)("s")));
} else {
Invoke(Invoke(Invoke(t_772, "to", ((V)(300D)), NewObj(3).Put("lx", ((V)((-0.5)))).Put("ly", ((V)(0.6))).Put("turn", ((V)((-0.2)))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(3).Put("hLy", Add((Get(B_766, "hLy") is var _t791 && Truthy(_t791) ? _t791 : ((V)(0D))), ((V)(6D)))).Put("armL", ((V)(16D))).Put("sq", Add(Get(B_766, "sq"), ((V)(0.015)))).V, NewObj(3).Put("hLy", Add((Get(B_766, "hLy") is var _t792 && Truthy(_t792) ? _t792 : ((V)(0D))), ((V)(2D)))).Put("armL", ((V)(10D))).Put("sq", Get(B_766, "sq")).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("turn", ((V)(0D))).Put("hLy", (Get(B_766, "hLy") is var _t789 && Truthy(_t789) ? _t789 : ((V)(0D)))).Put("armL", (Get(B_766, "armL") is var _t790 && Truthy(_t790) ? _t790 : ((V)(0D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_772, "to", ((V)(900D)), Call(o_10, V.Undef, LB_767, NewObj(5).Put("qk", ((V)(0D))).Put("zz", ((V)(0D))).Put("drm", ((V)(0D))).Put("close", ((V)(0.3))).Put("smile", ((V)(0.5))).V), ((V)("s"))), "to", ((V)(260D)), NewObj(1).Put("sq", Add(Get(LB_767, "sq"), ((V)(0.06)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(1).Put("sq", Get(LB_767, "sq")).V, ((V)("io")));
if (SEqS(kind_770, "bed")) {
Invoke(Invoke(Invoke(Invoke(t_772, "to", ((V)(320D)), NewObj(5).Put("hLy", ((V)(9D))).Put("hRy", ((V)(9D))).Put("armL", ((V)((-2D)))).Put("armR", ((V)((-2D)))).Put("ly", ((V)(0.7))).V, ((V)("io"))), "to", ((V)(900D)), NewObj(6).Put("hLy", Get(LB_767, "hLy")).Put("hRy", Get(LB_767, "hRy")).Put("armL", Get(LB_767, "armL")).Put("armR", Get(LB_767, "armR")).Put("qk", ((V)(1D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("sq", Add(Get(LB_767, "sq"), ((V)(0.05)))).Put("smile", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(1).Put("sq", Get(LB_767, "sq")).V, ((V)("io")));
} else {
Invoke(t_772, "osc", ((V)(900D)), ((V)(2D)), NewObj(2).Put("x", ((V)(0.8))).Put("tilt", Add(Get(LB_767, "tilt"), ((V)(2D)))).V, NewObj(2).Put("x", ((V)((-0.8)))).Put("tilt", ((V)((ToNum(Get(LB_767, "tilt")) - 2D)))).V, ((V)("s")));
}
Invoke(Invoke(Invoke(t_772, "to", ((V)(700D)), NewObj(1).Put("close", ((V)(0.75))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(1).Put("close", ((V)(0.45))).V), "to", ((V)(1000D)), NewObj(3).Put("close", ((V)(1D))).Put("zz", ((V)(1D))).Put("smile", Get(LB_767, "smile")).V, ((V)("s")));
}
v2_775 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, LB_767), "forEach", Fn((V _self759, int _argc793, V p_799, V _a796, V _a797, V _a798, V[] _rest794) => {
return SetK(v2_775, p_799, GetK(LB_767, p_799));
}, 1, "", true));
Invoke(t_772, "to", ((V)(220D)), v2_775, ((V)("io")));
return Invoke(t_772, "out", NewObj(3).Put("next", kind_770).Put("blend", ((V)(220D))).Put("fx", fx_771).V);
return default;
}, 6, "bedIn", false);
wakeUp_52 = Fn((V _self800, int _argc801, V LB_807, V SB_808, V P_809, V X_810, V[] _rest802) => {
V t_813 = default;
V up_814 = default;
V W_815 = default;
V rs_816 = default;
V kind_811 = default;
V fx_812 = default;
if (_self800.IsNullish) _self800 = GlobalV;
kind_811 = (_argc801 > 4 ? _rest802[0] : V.Undef);
fx_812 = (_argc801 > 5 ? _rest802[1] : V.Undef);
t_813 = Call(TL_11, V.Undef, LB_807);
Invoke(Invoke(Invoke(Invoke(Invoke(t_813, "wait", ((V)(120D))), "to", ((V)(200D)), NewObj(3).Put("close", ((V)(0.5))).Put("zz", ((V)(0D))).Put("drm", ((V)(0D))).V), "to", ((V)(220D)), NewObj(1).Put("close", ((V)(1D))).V), "wait", ((V)(160D))), "to", ((V)(180D)), NewObj(2).Put("close", ((V)(0.25))).Put("wide", ((V)(0.2))).V);
up_814 = NewObj(16).Put("pitch", (Get(SB_808, "pitch") is var _t817 && Truthy(_t817) ? _t817 : ((V)(0D)))).Put("sq", (Get(SB_808, "sq") is var _t818 && Truthy(_t818) ? _t818 : ((V)(0D)))).Put("lift", (Get(SB_808, "lift") is var _t819 && Truthy(_t819) ? _t819 : ((V)(0D)))).Put("tilt", ((V)(0D))).Put("htilt", ((V)(0D))).Put("turn", ((V)(0D))).Put("curl", (Get(SB_808, "curl") is var _t820 && Truthy(_t820) ? _t820 : ((V)(0D)))).Put("lean", ((V)(0D))).Put("x", ((V)(0D))).Put("footL", (Get(SB_808, "footL") is var _t821 && Truthy(_t821) ? _t821 : ((V)(0D)))).Put("footR", (Get(SB_808, "footR") is var _t822 && Truthy(_t822) ? _t822 : ((V)(0D)))).Put("qk", ((V)((SEqS(kind_811, "bed") ? 0.55 : 0D)))).Put("close", ((V)(0.2))).Put("smile", ((V)(0.3))).Put("mw", ((V)(1D))).Put("winkL", ((V)(0D))).V;
Invoke(t_813, "to", ((V)(650D)), up_814, ((V)("io")));
W_815 = Call(o_10, V.Undef, NewObj(13).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).Put("hLy", ((V)((-5D)))).Put("hRy", ((V)((-5D)))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("sq", ((V)((ToNum((Get(SB_808, "sq") is var _t823 && Truthy(_t823) ? _t823 : ((V)(0D)))) - 0.08)))).Put("close", ((V)(0.9))).Put("open", ((V)(0.9))).Put("mw", ((V)(0.8))).Put("tongue", ((V)(0.18))).Put("pitch", Add((Get(SB_808, "pitch") is var _t824 && Truthy(_t824) ? _t824 : ((V)(0D))), ((V)(0.3)))).Put("wide", ((V)(0D))).V, (Get(X_810, "wk") is var _t825 && Truthy(_t825) ? _t825 : NewObj(0).V));
Invoke(t_813, "to", ((V)(700D)), W_815, ((V)("io")));
if (Truthy(Get(X_810, "wfx"))) {
InvokeSpread(t_813, "fx", new ArrBuilder().Spread(Get(X_810, "wfx")).V);
}
Invoke(t_813, "osc", ((V)(560D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(1.6))).V, NewObj(1).Put("tilt", ((V)((-1.6)))).V, ((V)("s")));
rs_816 = NewObj(13).Put("armL", (Get(SB_808, "armL") is var _t826 && Truthy(_t826) ? _t826 : ((V)(0D)))).Put("armR", (Get(SB_808, "armR") is var _t827 && Truthy(_t827) ? _t827 : ((V)(0D)))).Put("hLy", (Get(SB_808, "hLy") is var _t828 && Truthy(_t828) ? _t828 : ((V)(0D)))).Put("hRy", (Get(SB_808, "hRy") is var _t829 && Truthy(_t829) ? _t829 : ((V)(0D)))).Put("hLx", (Get(SB_808, "hLx") is var _t830 && Truthy(_t830) ? _t830 : ((V)(0D)))).Put("hRx", (Get(SB_808, "hRx") is var _t831 && Truthy(_t831) ? _t831 : ((V)(0D)))).Put("sq", (Get(SB_808, "sq") is var _t832 && Truthy(_t832) ? _t832 : ((V)(0D)))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("tongue", ((V)(0D))).Put("pitch", (Get(SB_808, "pitch") is var _t833 && Truthy(_t833) ? _t833 : ((V)(0D)))).Put("close", ((V)(0.4))).Put("tilt", ((V)(0D))).V;
Invoke(Call(keysOf_15, V.Undef, (Get(X_810, "wk") is var _t842 && Truthy(_t842) ? _t842 : NewObj(0).V)), "forEach", Fn((V _self800, int _argc834, V p_840, V _a837, V _a838, V _a839, V[] _rest835) => {
if (GetK(rs_816, p_840).IsNullish) {
SetK(rs_816, p_840, (!GetK(SB_808, p_840).IsNullish ? GetK(SB_808, p_840) : (GetK(REST_9, p_840) is var _t841 && Truthy(_t841) ? _t841 : ((V)(0D)))));
}
return default;
}, 1, "", true));
Invoke(Invoke(t_813, "to", ((V)(520D)), rs_816, ((V)("io"))), "e", ((V)("blink")));
Invoke(Invoke(Invoke(Invoke(t_813, "to", ((V)(320D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(9D)), ((V)((-15D)))), NewObj(3).Put("armL", ((V)(36D))).Put("armR", ((V)(36D))).Put("close", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(720D)), ((V)(3D)), NewObj(4).Put("hLx", ((V)(11D))).Put("hRx", ((V)((-11D)))).Put("hLy", ((V)((-14D)))).Put("hRy", ((V)((-14D)))).V, NewObj(4).Put("hLx", ((V)(8D))).Put("hRx", ((V)((-8D)))).Put("hLy", ((V)((-16D)))).Put("hRy", ((V)((-16D)))).V, ((V)("s"))), "to", ((V)(360D)), NewObj(7).Put("hLx", (Get(SB_808, "hLx") is var _t843 && Truthy(_t843) ? _t843 : ((V)(0D)))).Put("hRx", (Get(SB_808, "hRx") is var _t844 && Truthy(_t844) ? _t844 : ((V)(0D)))).Put("hLy", (Get(SB_808, "hLy") is var _t845 && Truthy(_t845) ? _t845 : ((V)(0D)))).Put("hRy", (Get(SB_808, "hRy") is var _t846 && Truthy(_t846) ? _t846 : ((V)(0D)))).Put("armL", (Get(SB_808, "armL") is var _t847 && Truthy(_t847) ? _t847 : ((V)(0D)))).Put("armR", (Get(SB_808, "armR") is var _t848 && Truthy(_t848) ? _t848 : ((V)(0D)))).Put("close", ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink2")));
Invoke(Invoke(t_813, "to", ((V)(240D)), NewObj(2).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(160D)));
return Invoke(t_813, "out", NewObj(3).Put("next", ((V)(string.Concat(ToStr(kind_811), "out")))).Put("blend", ((V)(320D))).Put("fx", fx_812).V);
return default;
}, 6, "wakeUp", false);
bedOut_53 = Fn((V _self849, int _argc850, V SB_856, V P_857, V X_858, V kind_859, V[] _rest851) => {
V B_861 = default;
V t_862 = default;
V fL_863 = default;
V fR_864 = default;
V hop_865 = default;
V st_866 = default;
V fx_860 = default;
if (_self849.IsNullish) _self849 = GlobalV;
fx_860 = (_argc850 > 4 ? _rest851[0] : V.Undef);
B_861 = Call(o_10, V.Undef, SB_856, NewObj(3).Put("qk", ((V)((SEqS(kind_859, "bed") ? 0.55 : 0D)))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V);
t_862 = Call(TL_11, V.Undef, B_861);
fL_863 = (Get(SB_856, "footL") is var _t867 && Truthy(_t867) ? _t867 : ((V)(0D)));
fR_864 = (Get(SB_856, "footR") is var _t868 && Truthy(_t868) ? _t868 : ((V)(0D)));
if (SEqS(kind_859, "bed")) {
Invoke(Invoke(Invoke(t_862, "osc", ((V)(660D)), ((V)(3D)), NewObj(3).Put("footL", Add(fL_863, ((V)(3D)))).Put("footR", fR_864).Put("qk", ((V)(0.42))).V, NewObj(3).Put("footL", fL_863).Put("footR", Add(fR_864, ((V)(3D)))).Put("qk", ((V)(0.32))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(4).Put("qk", ((V)(0D))).Put("footL", Add(fL_863, ((V)(3.6)))).Put("footR", Add(fR_864, ((V)(3.6)))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(3).Put("footL", fL_863).Put("footR", fR_864).Put("open", ((V)(0D))).V);
} else {
if (SEqS(kind_859, "bean")) {
Invoke(Invoke(Invoke(t_862, "to", ((V)(300D)), NewObj(2).Put("sq", Add((Get(SB_856, "sq") is var _t871 && Truthy(_t871) ? _t871 : ((V)(0D))), ((V)(0.12)))).Put("lift", ((V)((ToNum((Get(SB_856, "lift") is var _t872 && Truthy(_t872) ? _t872 : ((V)(0D)))) - 1D)))).V, ((V)("io"))), "osc", ((V)(640D)), ((V)(3D)), NewObj(2).Put("x", ((V)(1D))).Put("tilt", ((V)(3D))).V, NewObj(2).Put("x", ((V)((-1D)))).Put("tilt", ((V)((-3D)))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(4).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sq", (Get(SB_856, "sq") is var _t869 && Truthy(_t869) ? _t869 : ((V)(0D)))).Put("lift", (Get(SB_856, "lift") is var _t870 && Truthy(_t870) ? _t870 : ((V)(0D)))).V, ((V)("io")));
} else {
Invoke(t_862, "osc", ((V)(600D)), ((V)(2D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("s")));
}
}
hop_865 = Get(t_862, "t");
Call(exitMove_22, V.Undef, t_862, B_861, (Get(P_857, "up") is var _t873 && Truthy(_t873) ? _t873 : ((V)("hop"))));
Invoke(t_862, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
st_866 = Invoke(t_862, "out", NewObj(3).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).Put("fx", fx_860).V);
Set(st_866, "hop", hop_865);
return st_866;
return default;
}, 5, "bedOut", false);
bedBuild_55 = Fn((V _self874, int _argc875, V key_881, V X_882, V _a879, V _a880, V[] _rest876) => {
V P_883 = default;
V SB_884 = default;
V nm_885 = default;
V fx_886 = default;
V fl_887 = default;
V sea_888 = default;
V adj_889 = default;
V LB_890 = default;
V LN_891 = default;
V CB_892 = default;
V S_893 = default;
if (_self874.IsNullish) _self874 = GlobalV;
X_882 = (X_882 is var _t894 && Truthy(_t894) ? _t894 : NewObj(0).V);
P_883 = (GetK(PROF_35, key_881) is var _t895 && Truthy(_t895) ? _t895 : NewObj(0).V);
SB_884 = Call(o_10, V.Undef, SIT0_17, (Get(P_883, "pose") is var _t896 && Truthy(_t896) ? _t896 : NewObj(0).V));
nm_885 = Fn((V _self874, int _argc897, V n_903, V _a900, V _a901, V _a902, V[] _rest898) => {
return (Truthy(key_881) ? ((V)(string.Concat(ToStr(n_903), "@", ToStr(key_881)))) : n_903);
}, 1, "", true);
fx_886 = Call(sleepFx_47, V.Undef, Get(X_882, "dr"), Get(X_882, "zc"), Get(X_882, "qy"));
fl_887 = (SEqS(Get(P_883, "dn"), "float") ? V.True : V.False);
sea_888 = ((SEqS(Get(P_883, "dn"), "flop") && SEqN(Get((Get(P_883, "pose") is var _t904 && Truthy(_t904) ? _t904 : NewObj(0).V), "sit"), 0D)) ? V.True : V.False);
adj_889 = (Truthy(fl_887) ? NewObj(2).Put("sit", ((V)(0D))).Put("lift", ((V)(1.2))).V : (Truthy(sea_888) ? NewObj(4).Put("sit", ((V)(0D))).Put("pitch", ((V)((-0.1)))).Put("htilt", ((V)(4D))).Put("lift", ((V)((-1.6)))).V : NewObj(0).V));
LB_890 = Call(o_10, V.Undef, SB_884, LIE0_40, adj_889, (Get(X_882, "lp") is var _t905 && Truthy(_t905) ? _t905 : NewObj(0).V));
LN_891 = Call(o_10, V.Undef, LB_890, NewObj(1).Put("qk", ((V)(0D))).V, (Get(X_882, "np") is var _t906 && Truthy(_t906) ? _t906 : NewObj(0).V));
CB_892 = Call(o_10, V.Undef, SB_884, CURL0_41, (Truthy(fl_887) ? NewObj(2).Put("sit", ((V)(0D))).Put("lift", ((V)(0.4))).V : NewObj(0).V), (Get(X_882, "bp") is var _t907 && Truthy(_t907) ? _t907 : NewObj(0).V));
S_893 = NewObj(0).V;
Invoke(Arr(Arr(((V)("bed")), LB_890), Arr(((V)("lie")), LN_891), Arr(((V)("bean")), CB_892)), "forEach", Fn((V _self874, int _argc908, V _a910, V _a911, V _a912, V _a913, V[] _rest909) => {
V k_916 = default;
V @base_918 = default;
{ V _t914 = ListOf(_a910);
{ V _t915 = GetIdx(_t914, 0D);
k_916 = _t915; }
{ V _t917 = GetIdx(_t914, 1D);
@base_918 = _t917; }
}
SetK(S_893, Call(nm_885, V.Undef, ((V)(string.Concat(ToStr(k_916), "in")))), Call(bedIn_51, V.Undef, SB_884, @base_918, P_883, X_882, k_916, fx_886));
SetK(S_893, Call(nm_885, V.Undef, k_916), Call(sleepHold_50, V.Undef, @base_918, X_882, k_916, fx_886));
SetK(S_893, Call(nm_885, V.Undef, ((V)(string.Concat(ToStr(k_916), "wake")))), Call(wakeUp_52, V.Undef, @base_918, SB_884, P_883, X_882, k_916, fx_886));
SetK(S_893, Call(nm_885, V.Undef, ((V)(string.Concat(ToStr(k_916), "out")))), Call(bedOut_53, V.Undef, SB_884, P_883, X_882, k_916, fx_886));
return default;
}, 1, "", true));
Invoke(R_8, "add", S_893);
Set(R_8, "HS", Object_assign((Get(R_8, "HS") is var _t919 && Truthy(_t919) ? _t919 : NewObj(0).V), S_893));
if (Truthy(key_881)) {
SetK(BED_54, key_881, X_882);
}
return default;
}, 2, "bedBuild", false);
stroke_60 = Fn((V _self920, int _argc921, V t_927, V d_928, V B_929, V sw_930, V[] _rest922) => {
double n_932 = 0;
double h_933 = 0;
V L_934 = default;
V Q_935 = default;
V xa_936 = default;
V xb_937 = default;
V X_931 = default;
if (_self920.IsNullish) _self920 = GlobalV;
X_931 = (_argc921 > 4 ? _rest922[0] : V.Undef);
n_932 = Max(1D, Round((ToNum(d_928) / (SEqS(sw_930, "glide") ? 1400D : (SEqS(sw_930, "float") ? 1600D : (SEqS(sw_930, "bob") ? 1300D : 900D))))));
h_933 = ((ToNum(d_928) / n_932) / 2D);
L_934 = (Get(B_929, "lift") is var _t938 && Truthy(_t938) ? _t938 : ((V)(0D)));
Q_935 = (Get(B_929, "sq") is var _t939 && Truthy(_t939) ? _t939 : ((V)(0D)));
xa_936 = (Get(X_931, "ka") is var _t940 && Truthy(_t940) ? _t940 : NewObj(0).V);
xb_937 = (Get(X_931, "kb") is var _t941 && Truthy(_t941) ? _t941 : NewObj(0).V);
{
double i_942 = 0;
i_942 = 0D;
while (true) {
if (!((i_942 < n_932))) break;
if (SEqS(sw_930, "glide")) {
Invoke(Invoke(t_927, "to", ((V)(h_933)), Call(o_10, V.Undef, NewObj(5).Put("wag", ((V)(18D))).Put("tilt", ((V)(1.6))).Put("x", ((V)(0.6))).Put("lift", Add(L_934, ((V)(0.6)))).Put("htilt", ((V)((-1.5)))).V, Get(X_931, "sa")), ((V)("s"))), "to", ((V)(h_933)), Call(o_10, V.Undef, NewObj(5).Put("wag", ((V)((-18D)))).Put("tilt", ((V)((-1.6)))).Put("x", ((V)((-0.6)))).Put("lift", ((V)((ToNum(L_934) - 0.3)))).Put("htilt", ((V)(1.5))).V, Get(X_931, "sb")), ((V)("s")));
} else {
if (SEqS(sw_930, "float")) {
Invoke(Invoke(t_927, "to", ((V)(h_933)), Call(o_10, V.Undef, NewObj(5).Put("lift", Add(L_934, ((V)(1.6)))).Put("sq", ((V)((ToNum(Q_935) - 0.03)))).Put("tilt", ((V)(2D))).Put("armL", Add((Get(B_929, "armL") is var _t946 && Truthy(_t946) ? _t946 : ((V)(0D))), ((V)(14D)))).Put("armR", ((V)((ToNum((Get(B_929, "armR") is var _t947 && Truthy(_t947) ? _t947 : ((V)(0D)))) - 6D)))).V, Get(X_931, "sa")), ((V)("s"))), "to", ((V)(h_933)), Call(o_10, V.Undef, NewObj(5).Put("lift", ((V)((ToNum(L_934) - 0.4)))).Put("sq", Add(Q_935, ((V)(0.03)))).Put("tilt", ((V)((-2D)))).Put("armL", ((V)((ToNum((Get(B_929, "armL") is var _t944 && Truthy(_t944) ? _t944 : ((V)(0D)))) - 6D)))).Put("armR", Add((Get(B_929, "armR") is var _t945 && Truthy(_t945) ? _t945 : ((V)(0D))), ((V)(14D)))).V, Get(X_931, "sb")), ((V)("s")));
} else {
if (SEqS(sw_930, "bob")) {
Invoke(Invoke(t_927, "to", ((V)(h_933)), Call(o_10, V.Undef, NewObj(4).Put("lift", Add(L_934, ((V)(1.3)))).Put("sq", ((V)((ToNum(Q_935) - 0.04)))).Put("turn", ((V)(0.14))).Put("tilt", ((V)(1.5))).V, Get(X_931, "sa")), ((V)("s"))), "to", ((V)(h_933)), Call(o_10, V.Undef, NewObj(4).Put("lift", ((V)((ToNum(L_934) - 0.5)))).Put("sq", Add(Q_935, ((V)(0.04)))).Put("turn", ((V)((-0.14)))).Put("tilt", ((V)((-1.5)))).V, Get(X_931, "sb")), ((V)("s")));
} else {
Invoke(Invoke(t_927, "to", ((V)(h_933)), Call(o_10, V.Undef, NewObj(8).Put("armL", Add((Get(B_929, "armL") is var _t950 && Truthy(_t950) ? _t950 : ((V)(0D))), ((V)(26D)))).Put("armR", ((V)((ToNum((Get(B_929, "armR") is var _t951 && Truthy(_t951) ? _t951 : ((V)(0D)))) - 16D)))).Put("tilt", ((V)(2.6))).Put("x", ((V)(0.5))).Put("lift", Add(L_934, ((V)(0.8)))).Put("htilt", ((V)((-2.2)))).Put("footL", ((V)(1.4))).Put("footR", ((V)(0D))).V, Get(X_931, "sa")), ((V)("s"))), "to", ((V)(h_933)), Call(o_10, V.Undef, NewObj(8).Put("armL", ((V)((ToNum((Get(B_929, "armL") is var _t948 && Truthy(_t948) ? _t948 : ((V)(0D)))) - 16D)))).Put("armR", Add((Get(B_929, "armR") is var _t949 && Truthy(_t949) ? _t949 : ((V)(0D))), ((V)(26D)))).Put("tilt", ((V)((-2.6)))).Put("x", ((V)((-0.5)))).Put("lift", ((V)((ToNum(L_934) - 0.3)))).Put("htilt", ((V)(2.2))).Put("footL", ((V)(0D))).Put("footR", ((V)(1.4))).V, Get(X_931, "sb")), ((V)("s")));
}
}
}
if (NumTruthy((i_942 % 2D))) {
Invoke(t_927, "fx", ((V)("drop")), ((V)((((i_942 % 4D) == 1D) ? "sideL" : "sideR"))), ((V)(2D)));
}
i_942++;
}
}
return Invoke(t_927, "back", ((V)(260D)), Arr(((V)("armL")), ((V)("armR")), ((V)("tilt")), ((V)("x")), ((V)("lift")), ((V)("htilt")), ((V)("footL")), ((V)("footR")), ((V)("wag")), ((V)("sq")), ((V)("turn"))));
return default;
}, 5, "stroke", false);
shakeDry_61 = Fn((V _self952, int _argc953, V t_959, V X_960, V _a957, V _a958, V[] _rest954) => {
V k_961 = default;
V A_962 = default;
V Bv_963 = default;
V z_964 = default;
if (_self952.IsNullish) _self952 = GlobalV;
k_961 = (Get(X_960, "k") is var _t965 && Truthy(_t965) ? _t965 : NewObj(0).V);
A_962 = Call(o_10, V.Undef, NewObj(8).Put("x", ((V)(1.7))).Put("tilt", ((V)(8D))).Put("htilt", ((V)((-7D)))).Put("earL", ((V)((-14D)))).Put("earR", ((V)(12D))).Put("sq", ((V)(0.03))).Put("close", ((V)(0.7))).Put("open", ((V)(0.2))).V, Get(k_961, "a"));
Bv_963 = Call(o_10, V.Undef, NewObj(8).Put("x", ((V)((-1.7)))).Put("tilt", ((V)((-8D)))).Put("htilt", ((V)(7D))).Put("earL", ((V)(12D))).Put("earR", ((V)((-14D)))).Put("sq", ((V)((-0.02)))).Put("close", ((V)(0.7))).Put("open", ((V)(0.2))).V, Get(k_961, "b"));
Invoke(t_959, "to", ((V)(220D)), NewObj(4).Put("sq", ((V)(0.08))).Put("close", ((V)(0.5))).Put("wet", ((V)(1D))).Put("lift", ((V)(0D))).V, ((V)("io")));
{
double j_966 = 0;
j_966 = 0D;
while (true) {
if (!((j_966 < 3D))) break;
Invoke(t_959, "osc", ((V)(340D)), ((V)(3D)), A_962, Bv_963, ((V)("l")));
Invoke(Invoke(t_959, "fx", ((V)("splash")), ((V)(((j_966 == 1D) ? "head" : "body"))), ((V)(((j_966 == 1D) ? 5D : 7D)))), "fx", ((V)("drop")), ((V)((NumTruthy((j_966 % 2D)) ? "sideL" : "sideR"))), ((V)(4D)));
j_966++;
}
}
Invoke(Invoke(Invoke(Invoke(t_959, "to", ((V)(160D)), NewObj(6).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("htilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wet", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(220D)), Call(o_10, V.Undef, NewObj(8).Put("sq", ((V)((-0.09)))).Put("lift", ((V)(2D))).Put("wide", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("close", ((V)(0D))).Put("wet", ((V)(0D))).V, Get(k_961, "f")), ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("sq", ((V)(0.03))).Put("lift", ((V)(0D))).V, ((V)("i"))), "e", ((V)("blink2")));
z_964 = NewObj(7).Put("wide", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("close", ((V)(0D))).V;
Invoke(Object_keys(Call(o_10, V.Undef, Get(k_961, "a"), Get(k_961, "f"))), "forEach", Fn((V _self952, int _argc968, V p_974, V _a971, V _a972, V _a973, V[] _rest969) => {
return SetK(z_964, p_974, (GetK(REST_9, p_974) is var _t975 && Truthy(_t975) ? _t975 : ((V)(0D))));
}, 1, "", true));
return Invoke(t_959, "to", ((V)(320D)), z_964, ((V)("io")));
return default;
}, 2, "shakeDry", false);
wHold_66 = Fn((V _self976, int _argc977, V B_983, V X_984, V kind_985, V sw_986, V[] _rest978) => {
V t_987 = default;
V v_988 = default;
V bt_989 = default;
V g_990 = default;
V L_991 = default;
V BK_992 = default;
V sig_993 = default;
V st_994 = default;
if (_self976.IsNullish) _self976 = GlobalV;
t_987 = Call(TL_11, V.Undef, B_983);
v_988 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_983), "forEach", Fn((V _self976, int _argc995, V p_1001, V _a998, V _a999, V _a1000, V[] _rest996) => {
return SetK(v_988, p_1001, GetK(B_983, p_1001));
}, 1, "", true));
Invoke(t_987, "to", ((V)(10D)), v_988);
bt_989 = Arr();
g_990 = (Get(X_984, "gap") is var _t1002 && Truthy(_t1002) ? _t1002 : (SEqS(kind_985, "swim") ? Arr(((V)(1800D)), ((V)(2400D)), ((V)(2000D)), ((V)(2600D))) : Arr(((V)(1700D)), ((V)(2300D)), ((V)(1900D)), ((V)(2500D)))));
L_991 = (GetK(X_984, ((V)(string.Concat(ToStr(kind_985), "Ord")))) is var _t1003 && Truthy(_t1003) ? _t1003 : GetK(WORD_65, kind_985));
BK_992 = (SEqS(kind_985, "tub") ? TB_62 : (SEqS(kind_985, "shower") ? SB0_63 : WB0_64));
sig_993 = (SEqS(kind_985, "swim") ? (Get(X_984, "ws") is var _t1004 && Truthy(_t1004) ? _t1004 : Get(X_984, "s")) : (SEqS(kind_985, "shower") ? (Get(X_984, "ss") is var _t1005 && Truthy(_t1005) ? _t1005 : Get(X_984, "s")) : Get(X_984, "s")));
Invoke(L_991, "forEach", Fn((V _self976, int _argc1006, V n_1012, V i_1013, V _a1010, V _a1011, V[] _rest1007) => {
V a_1014 = default;
if (SEqS(kind_985, "swim")) {
Call(stroke_60, V.Undef, t_987, GetIdx(g_990, (ToNum(i_1013) % ToNum(Get(g_990, "length")))), B_983, sw_986, X_984);
} else {
Invoke(t_987, "wait", GetIdx(g_990, (ToNum(i_1013) % ToNum(Get(g_990, "length")))));
}
a_1014 = Get(t_987, "t");
if (SEqS(n_1012, "sig")) {
if (!(Truthy(sig_993))) {
return default;
}
Call(sig_993, V.Undef, t_987);
} else {
InvokeK(BK_992, n_1012, t_987);
}
Invoke(bt_989, "push", Arr(n_1012, a_1014, Get(t_987, "t")));
return default;
}, 2, "", true));
if (SEqS(kind_985, "swim")) {
Call(stroke_60, V.Undef, t_987, ((V)(1600D)), B_983, sw_986, X_984);
} else {
Invoke(t_987, "wait", ((V)(1400D)));
}
st_994 = Invoke(t_987, "out", NewObj(3).Put("breathe", ((V)((SEqS(kind_985, "swim") ? 0.4 : 0.8)))).Put("look", (!SEqS(kind_985, "shower") ? V.True : V.False)).Put("blend", ((V)(520D))).V, (true ? V.True : V.False));
Set(st_994, "beats", bt_989);
return st_994;
return default;
}, 4, "wHold", false);
tubIn_67 = Fn((V _self1015, int _argc1016, V B_1022, V P_1023, V X_1024, V _a1021, V[] _rest1017) => {
V t_1025 = default;
V fl_1026 = default;
V v_1027 = default;
if (_self1015.IsNullish) _self1015 = GlobalV;
t_1025 = Call(TL_11, V.Undef, REST_9);
fl_1026 = (SEqS(Get(P_1023, "dn"), "float") ? V.True : V.False);
if (Truthy(fl_1026)) {
Invoke(Invoke(t_1025, "to", ((V)(300D)), NewObj(3).Put("lift", ((V)(6D))).Put("sq", ((V)((-0.04)))).Put("hap", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(3).Put("lift", ((V)(9D))).Put("wd", ((V)(0.25))).Put("fm", ((V)(1D))).V, ((V)("s")));
} else {
Invoke(Invoke(Invoke(t_1025, "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0.12))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(7).Put("lift", ((V)(9D))).Put("sq", ((V)((-0.12)))).Put("footL", ((V)(2.4))).Put("footR", ((V)(2.4))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(10D)), NewObj(2).Put("wd", ((V)(0.25))).Put("fm", ((V)(1D))).V);
}
Invoke(Invoke(Invoke(Invoke(t_1025, "to", ((V)(230D)), NewObj(8).Put("lift", ((V)(0D))).Put("sq", ((V)(0.14))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("sit", ((V)(1D))).Put("wd", ((V)(0.45))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("belly")), ((V)(9D))), "fx", ((V)("drop")), ((V)("sideL")), ((V)(3D))), "fx", ((V)("drop")), ((V)("sideR")), ((V)(3D)));
Invoke(Invoke(Invoke(Invoke(t_1025, "to", ((V)(220D)), NewObj(3).Put("sq", ((V)(0.02))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(1000D)), Call(o_10, V.Undef, B_1022, NewObj(4).Put("close", ((V)(0.65))).Put("open", ((V)(0.3))).Put("smile", ((V)(1D))).Put("dk", ((V)(0D))).V), ((V)("s"))), "to", ((V)(450D)), NewObj(3).Put("dk", ((V)(1D))).Put("close", Get(B_1022, "close")).Put("open", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("bubble")), ((V)("belly")), ((V)(2D)));
if (Truthy(Get(X_1024, "inX"))) {
Invoke(X_1024, "inX", t_1025, B_1022);
}
v_1027 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1022), "forEach", Fn((V _self1015, int _argc1028, V p_1034, V _a1031, V _a1032, V _a1033, V[] _rest1029) => {
return SetK(v_1027, p_1034, GetK(B_1022, p_1034));
}, 1, "", true));
Invoke(t_1025, "to", ((V)(200D)), v_1027, ((V)("io")));
return Invoke(t_1025, "out", NewObj(2).Put("next", ((V)("tub"))).Put("blend", ((V)(240D))).V);
return default;
}, 3, "tubIn", false);
tubOut_68 = Fn((V _self1035, int _argc1036, V B_1042, V P_1043, V X_1044, V _a1041, V[] _rest1037) => {
V t_1045 = default;
V hop_1046 = default;
V z_1047 = default;
V st_1048 = default;
if (_self1035.IsNullish) _self1035 = GlobalV;
t_1045 = Call(TL_11, V.Undef, B_1042);
Invoke(Invoke(t_1045, "to", ((V)(400D)), NewObj(3).Put("dk", ((V)(0D))).Put("fh", ((V)(0D))).Put("spg", ((V)(0D))).V, ((V)("io"))), "to", ((V)(520D)), NewObj(7).Put("sk", ((V)(0D))).Put("wd", ((V)(0.5))).Put("lift", ((V)(1.5))).Put("sq", ((V)((-0.03)))).Put("open", ((V)(0.15))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_1045, "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0.1))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(8).Put("lift", ((V)(9D))).Put("sq", ((V)((-0.12)))).Put("wd", ((V)(0.12))).Put("sit", ((V)(0D))).Put("footL", ((V)(2.4))).Put("footR", ((V)(2.4))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("o"))), "to", ((V)(10D)), NewObj(3).Put("wd", ((V)(0D))).Put("fm", ((V)(0D))).Put("wet", ((V)(1D))).V);
hop_1046 = Get(t_1045, "t");
Invoke(t_1045, "to", ((V)(210D)), NewObj(6).Put("lift", ((V)(0D))).Put("sq", ((V)(0.1))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("i")));
Call(shakeDry_61, V.Undef, t_1045, X_1044);
z_1047 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1042), "forEach", Fn((V _self1035, int _argc1049, V p_1055, V _a1052, V _a1053, V _a1054, V[] _rest1050) => {
return SetK(z_1047, p_1055, (GetK(REST_9, p_1055) is var _t1056 && Truthy(_t1056) ? _t1056 : ((V)(0D))));
}, 1, "", true));
Invoke(t_1045, "to", ((V)(200D)), z_1047, ((V)("io")));
st_1048 = Invoke(t_1045, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V);
Set(st_1048, "hop", hop_1046);
return st_1048;
return default;
}, 3, "tubOut", false);
showerIn_69 = Fn((V _self1057, int _argc1058, V B_1064, V X_1065, V _a1062, V _a1063, V[] _rest1059) => {
V t_1066 = default;
V v_1067 = default;
if (_self1057.IsNullish) _self1057 = GlobalV;
t_1066 = Call(TL_11, V.Undef, REST_9);
Invoke(Invoke(Invoke(Invoke(t_1066, "to", ((V)(220D)), NewObj(3).Put("footL", ((V)(2D))).Put("lift", ((V)(1.2))).Put("tilt", ((V)(2D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(4).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).Put("lift", ((V)(0.4))).Put("tilt", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(5).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("shw", ((V)(1D))).V, ((V)("o")));
Invoke(Invoke(Invoke(Invoke(t_1066, "to", ((V)(110D)), NewObj(7).Put("wide", ((V)(1D))).Put("sq", ((V)((-0.07)))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.5))).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("wet", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(560D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.7))).V, NewObj(1).Put("x", ((V)((-0.7)))).V, ((V)("l"))), "to", ((V)(260D)), NewObj(2).Put("sqz", ((V)(0.7))).Put("wide", ((V)(0D))).V), "fx", ((V)("splash")), ((V)("head")), ((V)(4D)));
v_1067 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1064), "forEach", Fn((V _self1057, int _argc1068, V p_1074, V _a1071, V _a1072, V _a1073, V[] _rest1069) => {
return SetK(v_1067, p_1074, GetK(B_1064, p_1074));
}, 1, "", true));
Invoke(Invoke(t_1066, "to", ((V)(700D)), Call(o_10, V.Undef, v_1067, NewObj(4).Put("sqz", ((V)(0D))).Put("ly", ((V)(0D))).Put("x", ((V)(0D))).Put("open", ((V)(0.2))).V), ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("stm", Get(B_1064, "stm")).Put("open", ((V)(0D))).V, ((V)("s")));
if (Truthy(Get(X_1065, "inX"))) {
Invoke(X_1065, "inX", t_1066, B_1064);
}
return Invoke(t_1066, "out", NewObj(2).Put("next", ((V)("shower"))).Put("blend", ((V)(220D))).V);
return default;
}, 2, "showerIn", false);
showerOut_70 = Fn((V _self1075, int _argc1076, V B_1082, V X_1083, V _a1080, V _a1081, V[] _rest1077) => {
V t_1084 = default;
V z_1085 = default;
if (_self1075.IsNullish) _self1075 = GlobalV;
t_1084 = Call(TL_11, V.Undef, B_1082);
Invoke(Invoke(t_1084, "to", ((V)(320D)), NewObj(2).Put("shw", ((V)(0D))).Put("fh", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("stm", ((V)(0D))).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
Call(shakeDry_61, V.Undef, t_1084, X_1083);
Invoke(Invoke(Invoke(t_1084, "to", ((V)(220D)), NewObj(2).Put("footL", ((V)(2D))).Put("lift", ((V)(1.2))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(3).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).Put("lift", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(180D)), NewObj(2).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
z_1085 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1082), "forEach", Fn((V _self1075, int _argc1086, V p_1092, V _a1089, V _a1090, V _a1091, V[] _rest1087) => {
return SetK(z_1085, p_1092, (GetK(REST_9, p_1092) is var _t1093 && Truthy(_t1093) ? _t1093 : ((V)(0D))));
}, 1, "", true));
Invoke(t_1084, "to", ((V)(200D)), z_1085, ((V)("io")));
return Invoke(t_1084, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V);
return default;
}, 2, "showerOut", false);
swimIn_71 = Fn((V _self1094, int _argc1095, V B_1101, V X_1102, V _a1099, V _a1100, V[] _rest1096) => {
V t_1103 = default;
double n_1104 = 0;
V v_1105 = default;
if (_self1094.IsNullish) _self1094 = GlobalV;
t_1103 = Call(TL_11, V.Undef, REST_9);
n_1104 = 4D;
{
double i_1106 = 0;
i_1106 = 0D;
while (true) {
if (!((i_1106 < n_1104))) break;
double u_1108 = 0;
u_1108 = ((i_1106 + 1D) / n_1104);
Invoke(Invoke(t_1103, "to", ((V)(300D)), NewObj(9).Put("footL", ((V)((NumTruthy((i_1106 % 2D)) ? 0D : 2.2)))).Put("footR", ((V)((NumTruthy((i_1106 % 2D)) ? 2.2 : 0D)))).Put("tilt", ((V)((NumTruthy((i_1106 % 2D)) ? (-2D) : 2D)))).Put("wd", ((V)((ToNum(Get(B_1101, "wd")) * u_1108)))).Put("sk", ((V)((ToNum(Get(B_1101, "sk")) * u_1108)))).Put("armL", ((V)((22D + (20D * u_1108))))).Put("armR", ((V)((22D + (20D * u_1108))))).Put("sit", ((V)((ToNum(Get(B_1101, "sit")) * u_1108)))).Put("open", ((V)(0.2))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)((NumTruthy((i_1106 % 2D)) ? "sideR" : "sideL"))), ((V)(3D)));
i_1106++;
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_1103, "to", ((V)(120D)), NewObj(5).Put("wide", ((V)(0.9))).Put("sq", ((V)((-0.05)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("o"))), "osc", ((V)(500D)), ((V)(5D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(240D)), NewObj(4).Put("wide", ((V)(0D))).Put("sqz", ((V)(0.5))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.8))).V), "fx", ((V)("splash")), ((V)("sideL")), ((V)(4D))), "fx", ((V)("splash")), ((V)("sideR")), ((V)(4D)));
v_1105 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1101), "forEach", Fn((V _self1094, int _argc1109, V p_1115, V _a1112, V _a1113, V _a1114, V[] _rest1110) => {
return SetK(v_1105, p_1115, GetK(B_1101, p_1115));
}, 1, "", true));
Invoke(t_1103, "to", ((V)(500D)), Call(o_10, V.Undef, v_1105, NewObj(2).Put("sqz", ((V)(0D))).Put("x", ((V)(0D))).V), ((V)("io")));
if (Truthy(Get(X_1102, "inX"))) {
Invoke(X_1102, "inX", t_1103, B_1101);
}
return Invoke(t_1103, "out", NewObj(2).Put("next", ((V)("swim"))).Put("blend", ((V)(220D))).V);
return default;
}, 2, "swimIn", false);
swimOut_72 = Fn((V _self1116, int _argc1117, V B_1123, V X_1124, V _a1121, V _a1122, V[] _rest1118) => {
V t_1125 = default;
double n_1126 = 0;
V z_1127 = default;
if (_self1116.IsNullish) _self1116 = GlobalV;
t_1125 = Call(TL_11, V.Undef, B_1123);
n_1126 = 4D;
{
double i_1128 = 0;
i_1128 = 0D;
while (true) {
if (!((i_1128 < n_1126))) break;
double u_1130 = 0;
u_1130 = (1D - ((i_1128 + 1D) / n_1126));
Invoke(Invoke(t_1125, "to", ((V)(300D)), NewObj(11).Put("footL", ((V)((NumTruthy((i_1128 % 2D)) ? 0D : 2.2)))).Put("footR", ((V)((NumTruthy((i_1128 % 2D)) ? 2.2 : 0D)))).Put("tilt", ((V)((NumTruthy((i_1128 % 2D)) ? (-2D) : 2D)))).Put("wd", ((V)((ToNum(Get(B_1123, "wd")) * u_1130)))).Put("sk", ((V)((ToNum(Get(B_1123, "sk")) * u_1130)))).Put("dv", ((V)(0D))).Put("armL", ((V)((10D + (20D * u_1130))))).Put("armR", ((V)((10D + (20D * u_1130))))).Put("sit", ((V)((ToNum((Get(B_1123, "sit") is var _t1131 && Truthy(_t1131) ? _t1131 : ((V)(0D)))) * u_1130)))).Put("pitch", ((V)(0D))).Put("wet", ((V)(1D))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)((NumTruthy((i_1128 % 2D)) ? "sideR" : "sideL"))), ((V)(3D)));
i_1128++;
}
}
Invoke(t_1125, "to", ((V)(160D)), NewObj(4).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("tilt", ((V)(0D))).Put("wd", ((V)(0D))).V, ((V)("io")));
Call(shakeDry_61, V.Undef, t_1125, X_1124);
z_1127 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1123), "forEach", Fn((V _self1116, int _argc1132, V p_1138, V _a1135, V _a1136, V _a1137, V[] _rest1133) => {
return SetK(z_1127, p_1138, (GetK(REST_9, p_1138) is var _t1139 && Truthy(_t1139) ? _t1139 : ((V)(0D))));
}, 1, "", true));
Invoke(t_1125, "to", ((V)(200D)), z_1127, ((V)("io")));
return Invoke(t_1125, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V);
return default;
}, 2, "swimOut", false);
waterBuild_74 = Fn((V _self1140, int _argc1141, V key_1147, V X_1148, V _a1145, V _a1146, V[] _rest1142) => {
V P_1149 = default;
V nm_1150 = default;
V sw_1151 = default;
V S_1152 = default;
V TBp_1153 = default;
V SHp_1154 = default;
V SWp_1155 = default;
V sk_1156 = default;
if (_self1140.IsNullish) _self1140 = GlobalV;
X_1148 = (X_1148 is var _t1157 && Truthy(_t1157) ? _t1157 : NewObj(0).V);
P_1149 = (GetK(PROF_35, key_1147) is var _t1158 && Truthy(_t1158) ? _t1158 : NewObj(0).V);
nm_1150 = Fn((V _self1140, int _argc1159, V n_1165, V _a1162, V _a1163, V _a1164, V[] _rest1160) => {
return (Truthy(key_1147) ? ((V)(string.Concat(ToStr(n_1165), "@", ToStr(key_1147)))) : n_1165);
}, 1, "", true);
sw_1151 = (Get(X_1148, "sw") is var _t1166 && Truthy(_t1166) ? _t1166 : ((V)((SEqS(Get(P_1149, "dn"), "float") ? "float" : "paddle"))));
S_1152 = NewObj(0).V;
TBp_1153 = Call(o_10, V.Undef, BATH0_56, (SEqS(Get(P_1149, "dn"), "float") ? NewObj(2).Put("sit", ((V)(0D))).Put("sk", ((V)(4D))).V : NewObj(0).V), (Get(X_1148, "bp") is var _t1167 && Truthy(_t1167) ? _t1167 : NewObj(0).V));
SHp_1154 = Call(o_10, V.Undef, SHOW0_57, (Get(X_1148, "hp") is var _t1168 && Truthy(_t1168) ? _t1168 : NewObj(0).V));
SWp_1155 = Call(o_10, V.Undef, SWIM0_58, (GetK(SWS_59, sw_1151) is var _t1169 && Truthy(_t1169) ? _t1169 : NewObj(0).V), (Get(X_1148, "wp") is var _t1170 && Truthy(_t1170) ? _t1170 : NewObj(0).V));
SetK(S_1152, Call(nm_1150, V.Undef, ((V)("tubin"))), Call(tubIn_67, V.Undef, TBp_1153, P_1149, X_1148));
SetK(S_1152, Call(nm_1150, V.Undef, ((V)("tub"))), Call(wHold_66, V.Undef, TBp_1153, X_1148, ((V)("tub")), sw_1151));
SetK(S_1152, Call(nm_1150, V.Undef, ((V)("tubout"))), Call(tubOut_68, V.Undef, TBp_1153, P_1149, X_1148));
SetK(S_1152, Call(nm_1150, V.Undef, ((V)("showerin"))), Call(showerIn_69, V.Undef, SHp_1154, X_1148));
SetK(S_1152, Call(nm_1150, V.Undef, ((V)("shower"))), Call(wHold_66, V.Undef, SHp_1154, X_1148, ((V)("shower")), sw_1151));
SetK(S_1152, Call(nm_1150, V.Undef, ((V)("showerout"))), Call(showerOut_70, V.Undef, SHp_1154, X_1148));
SetK(S_1152, Call(nm_1150, V.Undef, ((V)("swimin"))), Call(swimIn_71, V.Undef, SWp_1155, X_1148));
SetK(S_1152, Call(nm_1150, V.Undef, ((V)("swim"))), Call(wHold_66, V.Undef, SWp_1155, X_1148, ((V)("swim")), sw_1151));
SetK(S_1152, Call(nm_1150, V.Undef, ((V)("swimout"))), Call(swimOut_72, V.Undef, SWp_1155, X_1148));
sk_1156 = Call(TL_11, V.Undef, Call(o_10, V.Undef, REST_9, NewObj(1).Put("wet", ((V)(1D))).V));
Call(shakeDry_61, V.Undef, sk_1156, X_1148);
SetK(S_1152, Call(nm_1150, V.Undef, ((V)("shake"))), Invoke(sk_1156, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V));
Invoke(R_8, "add", S_1152);
Set(R_8, "HS", Object_assign((Get(R_8, "HS") is var _t1171 && Truthy(_t1171) ? _t1171 : NewObj(0).V), S_1152));
if (Truthy(key_1147)) {
SetK(WAT_73, key_1147, X_1148);
}
return default;
}, 2, "waterBuild", false);
playHold_81 = Fn((V _self1172, int _argc1173, V B_1179, V X_1180, V kind_1181, V sig_1182, V[] _rest1174) => {
V t_1183 = default;
V v_1184 = default;
V bt_1185 = default;
V g_1186 = default;
V BK_1187 = default;
V st_1188 = default;
if (_self1172.IsNullish) _self1172 = GlobalV;
t_1183 = Call(TL_11, V.Undef, B_1179);
v_1184 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1179), "forEach", Fn((V _self1172, int _argc1189, V p_1195, V _a1192, V _a1193, V _a1194, V[] _rest1190) => {
return SetK(v_1184, p_1195, GetK(B_1179, p_1195));
}, 1, "", true));
Invoke(t_1183, "to", ((V)(10D)), v_1184);
bt_1185 = Arr();
g_1186 = (Get(X_1180, "pgap") is var _t1196 && Truthy(_t1196) ? _t1196 : Arr(((V)(1500D)), ((V)(2100D)), ((V)(1700D)), ((V)(2300D))));
BK_1187 = (SEqS(kind_1181, "swing") ? PB_78 : RB_79);
Invoke((GetK(X_1180, ((V)(string.Concat(ToStr(kind_1181), "Ord")))) is var _t1206 && Truthy(_t1206) ? _t1206 : GetK(PORD_80, kind_1181)), "forEach", Fn((V _self1172, int _argc1197, V n_1203, V i_1204, V _a1201, V _a1202, V[] _rest1198) => {
V a_1205 = default;
Invoke(t_1183, "wait", GetIdx(g_1186, (ToNum(i_1204) % ToNum(Get(g_1186, "length")))));
a_1205 = Get(t_1183, "t");
if (SEqS(n_1203, "sig")) {
if (!(Truthy(sig_1182))) {
return default;
}
Call(sig_1182, V.Undef, t_1183);
} else {
if (SEqS(n_1203, "kick")) {
Invoke(BEAT_16, "kick", t_1183);
} else {
InvokeK(BK_1187, n_1203, t_1183, X_1180);
}
}
Invoke(bt_1185, "push", Arr(n_1203, a_1205, Get(t_1183, "t")));
return default;
}, 2, "", true));
Invoke(t_1183, "wait", ((V)(1200D)));
st_1188 = Invoke(t_1183, "out", NewObj(3).Put("breathe", ((V)(0.6))).Put("look", (SEqS(kind_1181, "swing") ? V.True : V.False)).Put("blend", ((V)(520D))).V, (true ? V.True : V.False));
Set(st_1188, "beats", bt_1185);
Set(st_1188, "sync", Call(o_10, V.Undef, NewObj(2).Put("ear", ((V)(14D))).Put("wag", ((V)(20D))).V, (Get(X_1180, "sy") is var _t1207 && Truthy(_t1207) ? _t1207 : NewObj(0).V)));
return st_1188;
return default;
}, 4, "playHold", false);
playIn_82 = Fn((V _self1208, int _argc1209, V B_1215, V P_1216, V kind_1217, V _a1214, V[] _rest1210) => {
V t_1218 = default;
V dn_1219 = default;
V v_1220 = default;
if (_self1208.IsNullish) _self1208 = GlobalV;
t_1218 = Call(TL_11, V.Undef, REST_9);
dn_1219 = (SEqS(kind_1217, "ride") ? ((SEqS(Get(P_1216, "dn"), "float") || SEqS(Get(P_1216, "dn"), "flop")) ? Get(P_1216, "dn") : ((V)("climb"))) : (Get(P_1216, "dn") is var _t1221 && Truthy(_t1221) ? _t1221 : ((V)("hop"))));
Call(enterMove_21, V.Undef, t_1218, B_1215, dn_1219);
v_1220 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1215), "forEach", Fn((V _self1208, int _argc1222, V p_1228, V _a1225, V _a1226, V _a1227, V[] _rest1223) => {
return SetK(v_1220, p_1228, GetK(B_1215, p_1228));
}, 1, "", true));
Invoke(t_1218, "to", ((V)(160D)), v_1220, ((V)("io")));
if (SEqS(kind_1217, "swing")) {
Invoke(Invoke(Invoke(Invoke(Invoke(t_1218, "to", ((V)(260D)), NewObj(2).Put("ly", ((V)((-0.8)))).Put("pitch", Add((Get(B_1215, "pitch") is var _t1236 && Truthy(_t1236) ? _t1236 : ((V)(0D))), ((V)(0.12)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(4).Put("sq", Add((Get(B_1215, "sq") is var _t1235 && Truthy(_t1235) ? _t1235 : ((V)(0D))), ((V)(0.05)))).Put("sqz", ((V)(0.5))).Put("hLy", Add(Get(B_1215, "hLy"), ((V)(1D)))).Put("hRy", Add(Get(B_1215, "hRy"), ((V)(1D)))).V, ((V)("o"))), "to", ((V)(280D)), NewObj(8).Put("ly", ((V)(0D))).Put("pitch", (Get(B_1215, "pitch") is var _t1233 && Truthy(_t1233) ? _t1233 : ((V)(0D)))).Put("sq", (Get(B_1215, "sq") is var _t1234 && Truthy(_t1234) ? _t1234 : ((V)(0D)))).Put("sqz", ((V)(0D))).Put("hLy", Get(B_1215, "hLy")).Put("hRy", Get(B_1215, "hRy")).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(3).Put("footL", ((V)((ToNum((Get(B_1215, "footL") is var _t1231 && Truthy(_t1231) ? _t1231 : ((V)(0D)))) - 0.6)))).Put("footR", ((V)((ToNum((Get(B_1215, "footR") is var _t1232 && Truthy(_t1232) ? _t1232 : ((V)(0D)))) - 0.6)))).Put("lean", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(4).Put("footL", (Get(B_1215, "footL") is var _t1229 && Truthy(_t1229) ? _t1229 : ((V)(0D)))).Put("footR", (Get(B_1215, "footR") is var _t1230 && Truthy(_t1230) ? _t1230 : ((V)(0D)))).Put("lean", ((V)(0D))).Put("hap", Get(B_1215, "hap")).V, ((V)("io")));
} else {
Invoke(Invoke(Invoke(Invoke(t_1218, "to", ((V)(240D)), NewObj(3).Put("sqz", ((V)(0.4))).Put("hLx", Add(Get(B_1215, "hLx"), ((V)(1.5)))).Put("hRx", ((V)((ToNum(Get(B_1215, "hRx")) - 1.5)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(6).Put("sqz", ((V)(0D))).Put("hLx", Get(B_1215, "hLx")).Put("hRx", Get(B_1215, "hRx")).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(2).Put("lean", ((V)(1D))).Put("sq", Add((Get(B_1215, "sq") is var _t1237 && Truthy(_t1237) ? _t1237 : ((V)(0D))), ((V)(0.03)))).V, NewObj(2).Put("lean", ((V)((-0.5)))).Put("sq", (Get(B_1215, "sq") is var _t1238 && Truthy(_t1238) ? _t1238 : ((V)(0D)))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(3).Put("open", ((V)(0D))).Put("hap", Get(B_1215, "hap")).Put("lean", ((V)(0D))).V, ((V)("io")));
}
return Invoke(t_1218, "out", NewObj(2).Put("next", kind_1217).Put("blend", ((V)(220D))).V);
return default;
}, 3, "playIn", false);
playOut_83 = Fn((V _self1239, int _argc1240, V B_1246, V P_1247, V kind_1248, V _a1245, V[] _rest1241) => {
V t_1249 = default;
V f_1250 = default;
V g_1251 = default;
V hop_1252 = default;
V st_1253 = default;
if (_self1239.IsNullish) _self1239 = GlobalV;
t_1249 = Call(TL_11, V.Undef, B_1246);
f_1250 = (Get(B_1246, "footL") is var _t1254 && Truthy(_t1254) ? _t1254 : ((V)(0D)));
g_1251 = (Get(B_1246, "footR") is var _t1255 && Truthy(_t1255) ? _t1255 : ((V)(0D)));
if (SEqS(kind_1248, "swing")) {
Invoke(Invoke(Invoke(t_1249, "to", ((V)(360D)), NewObj(5).Put("footL", ((V)((ToNum(f_1250) - 0.8)))).Put("footR", ((V)((ToNum(g_1251) - 0.8)))).Put("sq", Add((Get(B_1246, "sq") is var _t1256 && Truthy(_t1256) ? _t1256 : ((V)(0D))), ((V)(0.04)))).Put("pitch", ((V)((ToNum((Get(B_1246, "pitch") is var _t1257 && Truthy(_t1257) ? _t1257 : ((V)(0D)))) - 0.1)))).Put("wide", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.4))).V, NewObj(1).Put("x", ((V)((-0.4)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("x", ((V)(0D))).Put("wide", ((V)(0D))).V);
} else {
Invoke(Invoke(Invoke(t_1249, "to", ((V)(400D)), NewObj(4).Put("pitch", Add((Get(B_1246, "pitch") is var _t1259 && Truthy(_t1259) ? _t1259 : ((V)(0D))), ((V)(0.18)))).Put("hLy", Add(Get(B_1246, "hLy"), ((V)(4D)))).Put("hRy", Add(Get(B_1246, "hRy"), ((V)(4D)))).Put("open", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(200D)), NewObj(2).Put("open", ((V)(0D))).Put("pitch", (Get(B_1246, "pitch") is var _t1258 && Truthy(_t1258) ? _t1258 : ((V)(0D)))).V);
}
hop_1252 = Get(t_1249, "t");
Call(exitMove_22, V.Undef, t_1249, B_1246, ((SEqS(Get(P_1247, "up"), "float") || SEqS(Get(P_1247, "up"), "flop")) ? Get(P_1247, "up") : ((V)("hop"))));
Invoke(Invoke(Invoke(t_1249, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("hap", (Get(REST_9, "hap") is var _t1260 && Truthy(_t1260) ? _t1260 : ((V)(0D)))).Put("smile", (Get(REST_9, "smile") is var _t1261 && Truthy(_t1261) ? _t1261 : ((V)(0D)))).V, ((V)("io")));
st_1253 = Invoke(t_1249, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V);
Set(st_1253, "hop", hop_1252);
return st_1253;
return default;
}, 3, "playOut", false);
cookProp_89 = Fn((V _self1262, int _argc1263, V bt_1269, V rec_1270, V loop_1271, V _a1268, V[] _rest1264) => {
if (_self1262.IsNullish) _self1262 = GlobalV;
return Fn((V _self1262, int _argc1272, V I_1278, V tt_1279, V _a1276, V _a1277, V[] _rest1273) => {
V W_1280 = default;
double tl_1281 = 0;
V f_1282 = default;
V x_1283 = default;
V y_1284 = default;
W_1280 = Get(I_1278, "W");
if (((!(Truthy(W_1280)) || !(Truthy(Get(W_1280, "pawR")))) || !(IsFiniteV(GetIdx(Get(W_1280, "pawR"), 0D))))) {
return ((V)(""));
}
tl_1281 = (ToNum(tt_1279) % ToNum(loop_1271));
f_1282 = Call(facing_87, V.Undef, I_1278);
if (LtN(f_1282, 0.02)) {
return ((V)(""));
}
x_1283 = GetIdx(Get(W_1280, "pawR"), 0D);
y_1284 = GetIdx(Get(W_1280, "pawR"), 1D);
{
foreach (V _k1285 in Iterate(bt_1269)) {
V n_1286 = default;
V a_1287 = default;
V b_1288 = default;
{ V _t1289 = ListOf(_k1285);
{ V _t1290 = GetIdx(_t1289, 0D);
n_1286 = _t1290; }
{ V _t1291 = GetIdx(_t1289, 1D);
a_1287 = _t1291; }
{ V _t1292 = GetIdx(_t1289, 2D);
b_1288 = _t1292; }
}
double k_1293 = 0;
if ((Lt(((V)(tl_1281)), a_1287) || Gt(((V)(tl_1281)), b_1288))) {
continue;
}
k_1293 = (ToNum(Call(win_88, V.Undef, ((V)(tl_1281)), a_1287, b_1288, ((V)(220D)))) * ToNum(f_1282));
if ((k_1293 < 0.02)) {
return ((V)(""));
}
if ((SEqS(n_1286, "stir") || SEqS(n_1286, "taste"))) {
return ((V)(string.Concat(new string[] { "<g transform=\"translate(", ToStr(Call(r2_38, V.Undef, x_1283)), " ", ToStr(Call(r2_38, V.Undef, y_1284)), ") rotate(", ToStr(Call(r2_38, V.Undef, ((V)((SEqS(n_1286, "stir") ? (18D + (FdLibm.Sin((tl_1281 / 110D)) * 8D)) : 150D))))), ") scale(", ToStr(Call(r2_38, V.Undef, ((V)((k_1293 * 1.5))))), ")\">", ToStr(SPOON_85), "</g>" })));
}
if ((SEqS(n_1286, "shake") || SEqS(n_1286, "flip"))) {
V cake_1294 = default;
V r0_1295 = default;
cake_1294 = ((V)("<ellipse cx=\"13\" cy=\"0.9\" rx=\"4.3\" ry=\"2\" fill=\"#f2c26a\" stroke=\"#c98a3a\" stroke-width=\"0.35\"/><ellipse cx=\"11.8\" cy=\"0.4\" rx=\"1.6\" ry=\"0.6\" fill=\"#fff0c0\" opacity=\"0.7\"/>"));
r0_1295 = Invoke(rec_1270, "find", Fn((V _self1262, int _argc1296, V q_1302, V _a1299, V _a1300, V _a1301, V[] _rest1297) => {
return ((Ge(q_1302, a_1287) && Le(q_1302, b_1288)) ? V.True : V.False);
}, 1, "", true));
if ((SEqS(n_1286, "flip") && !r0_1295.IsNullish)) {
double u_1303 = 0;
u_1303 = ((tl_1281 - ToNum(r0_1295)) / 980D);
if (((u_1303 > 0D) && (u_1303 < 1D))) {
double th_1304 = 0;
double ry_1305 = 0;
th_1304 = (System.Math.PI * u_1303);
ry_1305 = Max(0.35, System.Math.Abs(((1.5 * FdLibm.Cos(th_1304)) + (4.3 * FdLibm.Sin(th_1304)))));
cake_1294 = ((V)(string.Concat(new string[] { "<ellipse cx=\"13\" cy=\"", ToStr(Call(r2_38, V.Undef, ((V)((0.4 - (22D * FdLibm.Sin((System.Math.PI * u_1303)))))))), "\" rx=\"4.3\" ry=\"", ToStr(Call(r2_38, V.Undef, ((V)(ry_1305)))), "\" fill=\"", ((u_1303 > 0.5) ? "#e0a24a" : "#f2c26a"), "\" stroke=\"#c98a3a\" stroke-width=\"0.35\"/>" })));
}
}
return ((V)(string.Concat(new string[] { "<g transform=\"translate(", ToStr(Call(r2_38, V.Undef, x_1283)), " ", ToStr(Call(r2_38, V.Undef, y_1284)), ") scale(", ToStr(Call(r2_38, V.Undef, ((V)((k_1293 * 1.45))))), ")\">", ToStr(PAN_86), ToStr(cake_1294), "</g>" })));
}
return ((V)(""));
}
}
return ((V)(""));
return default;
}, 2, "", true);
return default;
}, 3, "cookProp", false);
cookIn_90 = Fn((V _self1306, int _argc1307, V B_1313, V _a1310, V _a1311, V _a1312, V[] _rest1308) => {
V t_1314 = default;
V v_1315 = default;
if (_self1306.IsNullish) _self1306 = GlobalV;
t_1314 = Call(TL_11, V.Undef, REST_9);
Invoke(Invoke(Invoke(t_1314, "to", ((V)(220D)), NewObj(2).Put("footL", ((V)(2D))).Put("lift", ((V)(1D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).V, ((V)("io"))), "to", ((V)(180D)), NewObj(2).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_1314, "to", ((V)(260D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(11D)), ((V)((-2D)))), NewObj(5).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.5))).V), ((V)("io"))), "osc", ((V)(800D)), ((V)(4D)), NewObj(2).Put("hLx", ((V)(13D))).Put("hRx", ((V)((-13D)))).V, NewObj(2).Put("hLx", ((V)(9D))).Put("hRx", ((V)((-9D)))).V, ((V)("l")));
v_1315 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1313), "forEach", Fn((V _self1306, int _argc1316, V p_1322, V _a1319, V _a1320, V _a1321, V[] _rest1317) => {
return SetK(v_1315, p_1322, GetK(B_1313, p_1322));
}, 1, "", true));
Invoke(t_1314, "to", ((V)(420D)), Call(o_10, V.Undef, v_1315, NewObj(1).Put("sqz", ((V)(0D))).V), ((V)("io")));
return Invoke(t_1314, "out", NewObj(2).Put("next", ((V)("cook"))).Put("blend", ((V)(200D))).V);
return default;
}, 1, "cookIn", false);
cookHold_91 = Fn((V _self1323, int _argc1324, V B_1330, V X_1331, V sig_1332, V _a1329, V[] _rest1325) => {
V t_1333 = default;
V v_1334 = default;
V bt_1335 = default;
V rec_1336 = default;
V g_1337 = default;
V st_1338 = default;
if (_self1323.IsNullish) _self1323 = GlobalV;
t_1333 = Call(TL_11, V.Undef, B_1330);
v_1334 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1330), "forEach", Fn((V _self1323, int _argc1339, V p_1345, V _a1342, V _a1343, V _a1344, V[] _rest1340) => {
return SetK(v_1334, p_1345, GetK(B_1330, p_1345));
}, 1, "", true));
Invoke(t_1333, "to", ((V)(10D)), v_1334);
bt_1335 = Arr();
rec_1336 = Arr();
g_1337 = (Get(X_1331, "cgap") is var _t1346 && Truthy(_t1346) ? _t1346 : Arr(((V)(500D)), ((V)(700D)), ((V)(600D)), ((V)(800D))));
Invoke((Get(X_1331, "cOrd") is var _t1356 && Truthy(_t1356) ? _t1356 : Arr(((V)("stir")), ((V)("season")), ((V)("shake")), ((V)("flip")), ((V)("sig")), ((V)("stir")), ((V)("taste")), ((V)("kiss")))), "forEach", Fn((V _self1323, int _argc1347, V n_1353, V i_1354, V _a1351, V _a1352, V[] _rest1348) => {
V a_1355 = default;
Invoke(t_1333, "wait", GetIdx(g_1337, (ToNum(i_1354) % ToNum(Get(g_1337, "length")))));
a_1355 = Get(t_1333, "t");
if (SEqS(n_1353, "sig")) {
if (!(Truthy(sig_1332))) {
return default;
}
Call(sig_1332, V.Undef, t_1333);
} else {
InvokeK(CB_84, n_1353, t_1333, X_1331, rec_1336);
}
Invoke(bt_1335, "push", Arr(n_1353, a_1355, Get(t_1333, "t")));
return default;
}, 2, "", true));
Invoke(t_1333, "wait", ((V)(900D)));
st_1338 = Invoke(t_1333, "out", NewObj(3).Put("breathe", ((V)(0.6))).Put("look", (false ? V.True : V.False)).Put("blend", ((V)(420D))).V, (true ? V.True : V.False));
Set(st_1338, "beats", bt_1335);
Set(st_1338, "prop", Call(cookProp_89, V.Undef, bt_1335, rec_1336, Get(st_1338, "loop")));
return st_1338;
return default;
}, 3, "cookHold", false);
fridgeMove_92 = Fn((V _self1357, int _argc1358, V X_1364, V icon_1365, V _a1362, V _a1363, V[] _rest1359) => {
V t_1366 = default;
V IC_1367 = default;
V found_1368 = default;
V turn_1369 = default;
V a_1370 = default;
V b_1371 = default;
V st_1372 = default;
if (_self1357.IsNullish) _self1357 = GlobalV;
t_1366 = Call(TL_11, V.Undef, REST_9);
IC_1367 = (GetK(ICON_45, icon_1365) is var _t1373 && Truthy(_t1373) ? _t1373 : Get(ICON_45, "cookie"));
Invoke(Invoke(Invoke(t_1366, "to", ((V)(320D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)((-6D)))), NewObj(3).Put("armR", ((V)(62D))).Put("lx", ((V)(0.3))).Put("ly", ((V)((-0.2)))).V), ((V)("io"))), "to", ((V)(260D)), NewObj(5).Put("lean", ((V)((-1D)))).Put("tilt", ((V)((-3D)))).Put("sq", ((V)(0.04))).Put("armR", ((V)(46D))).Put("pitch", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(4).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sq", ((V)(0D))).Put("armR", ((V)(30D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_1366, "to", ((V)(110D)), NewObj(5).Put("wide", ((V)(1D))).Put("sq", ((V)((-0.05)))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.5))).Put("armR", ((V)(20D))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head"))), "osc", ((V)(520D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(4).Put("wide", ((V)(0D))).Put("sqz", ((V)(0.5))).Put("open", ((V)(0D))).Put("x", ((V)(0D))).V);
Invoke(t_1366, "to", ((V)(360D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(6D)), ((V)((-6D)))), NewObj(7).Put("pitch", ((V)((-0.22)))).Put("ly", ((V)(0.5))).Put("sq", ((V)(0.05))).Put("armL", ((V)(58D))).Put("armR", ((V)(58D))).Put("sqz", ((V)(0D))).Put("mw", ((V)(1D))).V), ((V)("io")));
{
double i_1374 = 0;
i_1374 = 0D;
while (true) {
if (!((i_1374 < 4D))) break;
Invoke(Invoke(t_1366, "to", ((V)(170D)), NewObj(4).Put("armL", ((V)(74D))).Put("armR", ((V)(44D))).Put("htilt", ((V)(5D))).Put("x", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(4).Put("armL", ((V)(44D))).Put("armR", ((V)(74D))).Put("htilt", ((V)((-5D)))).Put("x", ((V)((-0.6)))).V, ((V)("io")));
if ((i_1374 == 1D)) {
Invoke(t_1366, "fx", ((V)("crumb")), ((V)("head")), ((V)(3D)));
}
i_1374++;
}
}
Invoke(Invoke(Invoke(Invoke(t_1366, "to", ((V)(220D)), NewObj(6).Put("armL", ((V)(58D))).Put("armR", ((V)(58D))).Put("htilt", ((V)(0D))).Put("x", ((V)(0D))).Put("lx", ((V)((-0.6)))).Put("ly", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(260D))), "to", ((V)(220D)), NewObj(1).Put("lx", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(240D)));
found_1368 = Get(t_1366, "t");
Invoke(Invoke(t_1366, "to", ((V)(200D)), NewObj(9).Put("wide", ((V)(0.9))).Put("open", ((V)(0.35))).Put("mw", ((V)(0.6))).Put("armL", ((V)(22D))).Put("armR", ((V)(40D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(320D)));
turn_1369 = Get(t_1366, "t");
Invoke(t_1366, "to", ((V)(380D)), Call(o_10, V.Undef, NewObj(12).Put("armR", ((V)(150D))).Put("hRx", ((V)(1D))).Put("hRy", ((V)((-4D)))).Put("armL", ((V)(20D))).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("lift", ((V)(2.4))).Put("sq", ((V)((-0.06)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.5))).V, Get(X_1364, "cheer")), ((V)("o")));
if (Truthy(Get(X_1364, "cheerFx"))) {
InvokeSpread(t_1366, "fx", new ArrBuilder().Spread(Get(X_1364, "cheerFx")).V);
} else {
Invoke(t_1366, "fx", ((V)("spark")), ((V)("pawR")), ((V)(4D)));
}
Invoke(Invoke(Invoke(t_1366, "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V), "wait", ((V)(500D)));
Invoke(Invoke(Invoke(t_1366, "to", ((V)(220D)), NewObj(4).Put("x", ((V)((-1.4)))).Put("tilt", ((V)((-6D)))).Put("armR", ((V)(110D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
a_1370 = Add(found_1368, ((V)(150D)));
b_1371 = Add(Get(t_1366, "t"), ((V)(200D)));
Invoke(t_1366, "back", ((V)(320D)));
st_1372 = Invoke(t_1366, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(180D))).V);
Set(st_1372, "turn", turn_1369);
Set(st_1372, "prop", Fn((V _self1357, int _argc1376, V I_1382, V tt_1383, V _a1380, V _a1381, V[] _rest1377) => {
V W_1384 = default;
double k_1385 = 0;
W_1384 = Get(I_1382, "W");
if (((!(Truthy(W_1384)) || !(Truthy(Get(W_1384, "pawR")))) || !(IsFiniteV(GetIdx(Get(W_1384, "pawR"), 0D))))) {
return ((V)(""));
}
k_1385 = (ToNum(Call(win_88, V.Undef, tt_1383, a_1370, b_1371, ((V)(200D)))) * ToNum(Call(facing_87, V.Undef, I_1382)));
if ((k_1385 < 0.02)) {
return ((V)(""));
}
return ((V)(string.Concat(new string[] { "<g transform=\"translate(", ToStr(Call(r2_38, V.Undef, GetIdx(Get(W_1384, "pawR"), 0D))), " ", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(Get(W_1384, "pawR"), 1D)) - 3D))))), ") scale(", ToStr(Call(r2_38, V.Undef, ((V)((k_1385 * 3.2))))), ")\">", ToStr(IC_1367), "</g>" })));
return default;
}, 2, "", true));
return st_1372;
return default;
}, 2, "fridgeMove", false);
playBuild_94 = Fn((V _self1386, int _argc1387, V key_1393, V X_1394, V _a1391, V _a1392, V[] _rest1388) => {
V P_1395 = default;
V nm_1396 = default;
V S_1397 = default;
V SB_1398 = default;
V sig_1399 = default;
V ksig_1400 = default;
V SW_1401 = default;
V RD_1402 = default;
V CK_1403 = default;
if (_self1386.IsNullish) _self1386 = GlobalV;
X_1394 = Call(o_10, V.Undef, (GetK(WX_29, key_1393) is var _t1404 && Truthy(_t1404) ? _t1404 : NewObj(0).V), (X_1394 is var _t1405 && Truthy(_t1405) ? _t1405 : NewObj(0).V));
P_1395 = (GetK(PROF_35, key_1393) is var _t1406 && Truthy(_t1406) ? _t1406 : NewObj(0).V);
nm_1396 = Fn((V _self1386, int _argc1407, V n_1413, V _a1410, V _a1411, V _a1412, V[] _rest1408) => {
return (Truthy(key_1393) ? ((V)(string.Concat(ToStr(n_1413), "@", ToStr(key_1393)))) : n_1413);
}, 1, "", true);
S_1397 = NewObj(0).V;
SB_1398 = Call(o_10, V.Undef, SIT0_17, (Get(P_1395, "pose") is var _t1414 && Truthy(_t1414) ? _t1414 : NewObj(0).V));
sig_1399 = (Get(X_1394, "p") is var _t1423 && Truthy(_t1423) ? _t1423 : Invoke((Get(P_1395, "f") is var _t1422 && Truthy(_t1422) ? _t1422 : Arr()), "find", Fn((V _self1386, int _argc1415, V f_1421, V _a1418, V _a1419, V _a1420, V[] _rest1416) => {
return (string.Equals(Typeof(f_1421), "function") ? V.True : V.False);
}, 1, "", true)));
ksig_1400 = (Get(X_1394, "k") is var _t1424 && Truthy(_t1424) ? _t1424 : sig_1399);
SW_1401 = Call(o_10, V.Undef, SB_1398, SWG0_75, (Get(X_1394, "sp") is var _t1425 && Truthy(_t1425) ? _t1425 : NewObj(0).V));
RD_1402 = Call(o_10, V.Undef, SB_1398, RID0_76, (Get(X_1394, "rp") is var _t1426 && Truthy(_t1426) ? _t1426 : NewObj(0).V));
CK_1403 = Call(o_10, V.Undef, CK0_77, (Get(X_1394, "cp") is var _t1427 && Truthy(_t1427) ? _t1427 : NewObj(0).V));
Invoke(Arr(Arr(((V)("swing")), SW_1401), Arr(((V)("ride")), RD_1402)), "forEach", Fn((V _self1386, int _argc1428, V _a1430, V _a1431, V _a1432, V _a1433, V[] _rest1429) => {
V k_1436 = default;
V B_1438 = default;
{ V _t1434 = ListOf(_a1430);
{ V _t1435 = GetIdx(_t1434, 0D);
k_1436 = _t1435; }
{ V _t1437 = GetIdx(_t1434, 1D);
B_1438 = _t1437; }
}
SetK(S_1397, Call(nm_1396, V.Undef, ((V)(string.Concat(ToStr(k_1436), "in")))), Call(playIn_82, V.Undef, B_1438, P_1395, k_1436));
SetK(S_1397, Call(nm_1396, V.Undef, k_1436), Call(playHold_81, V.Undef, B_1438, X_1394, k_1436, sig_1399));
SetK(S_1397, Call(nm_1396, V.Undef, ((V)(string.Concat(ToStr(k_1436), "out")))), Call(playOut_83, V.Undef, B_1438, P_1395, k_1436));
return default;
}, 1, "", true));
SetK(S_1397, Call(nm_1396, V.Undef, ((V)("cookin"))), Call(cookIn_90, V.Undef, CK_1403));
SetK(S_1397, Call(nm_1396, V.Undef, ((V)("cook"))), Call(cookHold_91, V.Undef, CK_1403, X_1394, ksig_1400));
SetK(S_1397, Call(nm_1396, V.Undef, ((V)("fridge"))), Call(fridgeMove_92, V.Undef, X_1394, (Get(X_1394, "sn") is var _t1439 && Truthy(_t1439) ? _t1439 : ((V)("cookie")))));
Invoke(R_8, "add", S_1397);
Set(R_8, "HS", Object_assign((Get(R_8, "HS") is var _t1440 && Truthy(_t1440) ? _t1440 : NewObj(0).V), S_1397));
if (Truthy(key_1393)) {
SetK(PLY_93, key_1393, X_1394);
}
return default;
}, 2, "playBuild", false);
bHold_101 = Fn((V _self1441, int _argc1442, V B_1448, V ord_1449, V BK_1450, V X_1451, V[] _rest1443) => {
V t_1455 = default;
V v_1456 = default;
V bt_1457 = default;
V rec_1458 = default;
V st_1459 = default;
V sig_1452 = default;
V gaps_1453 = default;
V ex_1454 = default;
if (_self1441.IsNullish) _self1441 = GlobalV;
sig_1452 = (_argc1442 > 4 ? _rest1443[0] : V.Undef);
gaps_1453 = (_argc1442 > 5 ? _rest1443[1] : V.Undef);
ex_1454 = (_argc1442 > 6 ? _rest1443[2] : V.Undef);
t_1455 = Call(TL_11, V.Undef, B_1448);
v_1456 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1448), "forEach", Fn((V _self1441, int _argc1460, V p_1466, V _a1463, V _a1464, V _a1465, V[] _rest1461) => {
return SetK(v_1456, p_1466, GetK(B_1448, p_1466));
}, 1, "", true));
Invoke(t_1455, "to", ((V)(10D)), v_1456);
bt_1457 = Arr();
rec_1458 = NewObj(0).V;
Invoke(ord_1449, "forEach", Fn((V _self1441, int _argc1467, V n_1473, V i_1474, V _a1471, V _a1472, V[] _rest1468) => {
V a_1475 = default;
Invoke(t_1455, "wait", GetIdx(gaps_1453, (ToNum(i_1474) % ToNum(Get(gaps_1453, "length")))));
a_1475 = Get(t_1455, "t");
if (SEqS(n_1473, "sig")) {
if (!(Truthy(sig_1452))) {
return default;
}
Call(sig_1452, V.Undef, t_1455);
} else {
if (Truthy(GetK(BK_1450, n_1473))) {
InvokeK(BK_1450, n_1473, t_1455, X_1451, rec_1458);
} else {
InvokeK(BEAT_16, n_1473, t_1455);
}
}
Invoke(bt_1457, "push", Arr(n_1473, a_1475, Get(t_1455, "t")));
return default;
}, 2, "", true));
Invoke(t_1455, "wait", ((V)(900D)));
st_1459 = Invoke(t_1455, "out", Call(o_10, V.Undef, NewObj(3).Put("breathe", ((V)(0.6))).Put("look", (false ? V.True : V.False)).Put("blend", ((V)(460D))).V, (ex_1454 is var _t1476 && Truthy(_t1476) ? _t1476 : NewObj(0).V)), (true ? V.True : V.False));
Set(st_1459, "beats", bt_1457);
Set(st_1459, "rec", rec_1458);
return st_1459;
return default;
}, 7, "bHold", false);
brushProp_106 = Fn((V _self1477, int _argc1478, V st_1484, V col_1485, V _a1482, V _a1483, V[] _rest1479) => {
V BRU_1486 = default;
if (_self1477.IsNullish) _self1477 = GlobalV;
BRU_1486 = Fn((V _self1477, int _argc1487, V L_1493, V _a1490, V _a1491, V _a1492, V[] _rest1488) => {
return ((V)(string.Concat(new string[] { "<rect x=\"-3\" y=\"-1.2\" width=\"", ToStr(Call(r2_38, V.Undef, Add(L_1493, ((V)(3D))))), "\" height=\"2.4\" rx=\"1.2\" fill=\"", ToStr(col_1485), "\" stroke=\"", ToStr(Call(shade_42, V.Undef, col_1485, ((V)(0.7)))), "\" stroke-width=\"0.45\"/><path d=\"M-1.6-0.5H", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(L_1493) - 6D))))), "\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.45\" stroke-linecap=\"round\"/><rect x=\"", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(L_1493) - 4.6))))), "\" y=\"-4.4\" width=\"4.6\" height=\"3.4\" rx=\"0.8\" fill=\"#ffffff\" stroke=\"#b9c6d6\" stroke-width=\"0.45\"/><path d=\"M", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(L_1493) - 3.6))))), " -4.2V-1.4M", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(L_1493) - 2.3))))), " -4.2V-1.4M", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(L_1493) - 1D))))), " -4.2V-1.4\" stroke=\"#d6e2ee\" stroke-width=\"0.4\"/>" })));
}, 1, "", true);
return Fn((V _self1477, int _argc1494, V I_1500, V tt_1501, V _a1498, V _a1499, V[] _rest1495) => {
V W_1502 = default;
V f0_1503 = default;
double tl_1504 = 0;
V p_1505 = default;
V M_1506 = default;
double fm_1507 = 0;
double dx_1508 = 0;
double dy_1509 = 0;
V d_1510 = default;
V h_1511 = default;
W_1502 = Get(I_1500, "W");
if ((!(Truthy(W_1502)) || !(Truthy(Call(okp_95, V.Undef, Get(W_1502, "pawR")))))) {
return ((V)(""));
}
f0_1503 = Call(facing_87, V.Undef, I_1500);
if (LtN(f0_1503, 0.02)) {
return ((V)(""));
}
tl_1504 = (ToNum(tt_1501) % ToNum(Get(st_1484, "loop")));
p_1505 = Get(W_1502, "pawR");
M_1506 = (Truthy(Call(okp_95, V.Undef, Get(W_1502, "mouth"))) ? Get(W_1502, "mouth") : Arr(((V)((ToNum(GetIdx(p_1505, 0D)) - 8D))), GetIdx(p_1505, 1D)));
fm_1507 = 0D;
{
foreach (V _k1512 in Iterate(Get(st_1484, "beats"))) {
V n_1513 = default;
V a_1514 = default;
V b_1515 = default;
{ V _t1516 = ListOf(_k1512);
{ V _t1517 = GetIdx(_t1516, 0D);
n_1513 = _t1517; }
{ V _t1518 = GetIdx(_t1516, 1D);
a_1514 = _t1518; }
{ V _t1519 = GetIdx(_t1516, 2D);
b_1515 = _t1519; }
}
double u_1520 = 0;
if (Lt(((V)(tl_1504)), a_1514)) {
break;
}
u_1520 = Min(1D, ((Min(tl_1504, ToNum(b_1515)) - ToNum(a_1514)) / 900D));
if ((SEqS(n_1513, "brush") || SEqS(n_1513, "side"))) {
fm_1507 = Max(fm_1507, u_1520);
} else {
if (SEqS(n_1513, "spit")) {
fm_1507 = (fm_1507 * (1D - ToNum(Call(ss_25, V.Undef, ((V)((((tl_1504 - ToNum(a_1514)) - 300D) / 180D)))))));
}
}
}
}
dx_1508 = (ToNum(GetIdx(M_1506, 0D)) - ToNum(GetIdx(p_1505, 0D)));
dy_1509 = (ToNum(GetIdx(M_1506, 1D)) - ToNum(GetIdx(p_1505, 1D)));
d_1510 = (((V)(Hypot(dx_1508, dy_1509))) is var _t1521 && Truthy(_t1521) ? _t1521 : ((V)(1D)));
h_1511 = Call(G_100, V.Undef, GetIdx(p_1505, 0D), GetIdx(p_1505, 1D), ((V)(((FdLibm.Atan2(dy_1509, dx_1508) * 180D) / System.Math.PI))), ((V)(1D)), Call(BRU_1486, V.Undef, Call(cl_39, V.Undef, Add(d_1510, ((V)(2D))), ((V)(9D)), ((V)(17D)))), f0_1503);
if ((fm_1507 > 0.03)) {
V fo_1522 = default;
fo_1522 = ((V)(""));
Invoke(Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.6))), Arr(((V)((-1.8))), ((V)(0.7)), ((V)(1.2))), Arr(((V)(1.9)), ((V)(0.5)), ((V)(1.3))), Arr(((V)((-0.6))), ((V)(1.6)), ((V)(1D))), Arr(((V)(0.9)), ((V)((-0.9))), ((V)(0.9)))), "forEach", Fn((V _self1477, int _argc1523, V _a1525, V i_1529, V _a1527, V _a1528, V[] _rest1524) => {
double rr_1537 = 0;
V x_1532 = default;
V y_1534 = default;
V r_1536 = default;
{ V _t1530 = ListOf(_a1525);
{ V _t1531 = GetIdx(_t1530, 0D);
x_1532 = _t1531; }
{ V _t1533 = GetIdx(_t1530, 1D);
y_1534 = _t1533; }
{ V _t1535 = GetIdx(_t1530, 2D);
r_1536 = _t1535; }
}
rr_1537 = (((1.8 * ToNum(r_1536)) * fm_1507) * (0.9 + (0.12 * FdLibm.Sin(((ToNum(tt_1501) / 90D) + (ToNum(i_1529) * 2D))))));
if ((rr_1537 > 0.2)) {
fo_1522 = Add(fo_1522, Call(ci_43, V.Undef, Call(r2_38, V.Undef, Add(GetIdx(M_1506, 0D), ((V)(((1.8 * ToNum(x_1532)) * (0.6 + (fm_1507 * 0.5))))))), Call(r2_38, V.Undef, Add(Add(GetIdx(M_1506, 1D), ((V)(1.4))), ((V)((1.6 * ToNum(y_1534)))))), Call(r2_38, V.Undef, ((V)(rr_1537))), ((V)("#ffffff")), ((V)("#cfe6f6"))));
}
return default;
}, 2, "", true));
h_1511 = ((V)(string.Concat(new string[] { ToStr(h_1511), "<g opacity=\"", ToStr(Call(r2_38, V.Undef, ((V)((0.95 * ToNum(f0_1503)))))), "\">", ToStr(fo_1522), "</g>" })));
}
return h_1511;
return default;
}, 2, "", true);
return default;
}, 2, "brushProp", false);
dineProp_108 = Fn((V _self1538, int _argc1539, V st_1545, V icon_1546, V md_1547, V _a1544, V[] _rest1540) => {
V IC_1548 = default;
if (_self1538.IsNullish) _self1538 = GlobalV;
IC_1548 = (GetK(ICON_45, icon_1546) is var _t1549 && Truthy(_t1549) ? _t1549 : Get(ICON_45, "cookie"));
return Fn((V _self1538, int _argc1550, V I_1556, V tt_1557, V _a1554, V _a1555, V[] _rest1551) => {
V W_1558 = default;
V f0_1559 = default;
double tl_1560 = 0;
double k_1561 = 0;
V x_1562 = default;
V y_1563 = default;
V h_1564 = default;
V sb_1565 = default;
W_1558 = Get(I_1556, "W");
if (((!(Truthy(W_1558)) || !(Truthy(Call(okp_95, V.Undef, Get(W_1558, "pawR"))))) || !(Truthy(Call(okp_95, V.Undef, Get(W_1558, "pawL")))))) {
return ((V)(""));
}
f0_1559 = Call(facing_87, V.Undef, I_1556);
if (LtN(f0_1559, 0.02)) {
return ((V)(""));
}
tl_1560 = (ToNum(tt_1557) % ToNum(Get(st_1545, "loop")));
k_1561 = Max(0.35, (1D - (ToNum(Call(cnt_98, V.Undef, Get(Get(st_1545, "rec"), "bite"), ((V)(0D)), ((V)(tl_1560)))) * 0.2)));
x_1562 = V.Undef;
y_1563 = V.Undef;
if (SEqS(md_1547, "lap")) {
V B_1566 = default;
B_1566 = (Truthy(Call(okp_95, V.Undef, Get(W_1558, "belly"))) ? Get(W_1558, "belly") : (Get(W_1558, "body") is var _t1567 && Truthy(_t1567) ? _t1567 : Arr(((V)(50D)), ((V)(80D)))));
x_1562 = GetIdx(B_1566, 0D);
y_1563 = Add(GetIdx(B_1566, 1D), ((V)(3D)));
} else {
if (Truthy(((SEqS(md_1547, "two") ? V.True : V.False) is var _t1568 && Truthy(_t1568) ? _t1568 : Get(I_1556, "foodMid")))) {
x_1562 = ((V)((ToNum(Add(GetIdx(Get(W_1558, "pawL"), 0D), GetIdx(Get(W_1558, "pawR"), 0D))) / 2D)));
y_1563 = ((V)(((ToNum(Add(GetIdx(Get(W_1558, "pawL"), 1D), GetIdx(Get(W_1558, "pawR"), 1D))) / 2D) - 2D)));
} else {
x_1562 = GetIdx(Get(W_1558, "pawR"), 0D);
y_1563 = ((V)((ToNum(GetIdx(Get(W_1558, "pawR"), 1D)) - 2.5)));
}
}
h_1564 = Call(G_100, V.Undef, x_1562, ((V)((ToNum(y_1563) - 2D))), ((V)(0D)), ((V)((4D * k_1561))), IC_1548, f0_1559);
sb_1565 = Invoke(Get(st_1545, "beats"), "find", Fn((V _self1538, int _argc1569, V b_1575, V _a1572, V _a1573, V _a1574, V[] _rest1570) => {
return (((SEqS(GetIdx(b_1575, 0D), "sip") && Ge(((V)(tl_1560)), GetIdx(b_1575, 1D))) && Le(((V)(tl_1560)), GetIdx(b_1575, 2D))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(sb_1565)) {
V u_1576 = default;
u_1576 = Call(win_88, V.Undef, ((V)(tl_1560)), GetIdx(sb_1565, 1D), GetIdx(sb_1565, 2D), ((V)(220D)));
if (GtN(u_1576, 0.02)) {
h_1564 = Add(h_1564, Call(G_100, V.Undef, GetIdx(Get(W_1558, "pawL"), 0D), ((V)((ToNum(GetIdx(Get(W_1558, "pawL"), 1D)) - 4D))), ((V)((-10D))), ((V)((3.8 * ToNum(u_1576)))), Get(ICON_45, "cup"), f0_1559));
}
}
return h_1564;
return default;
}, 2, "", true);
return default;
}, 3, "dineProp", false);
fishProp_113 = Fn((V _self1577, int _argc1578, V st_1584, V icon_1585, V _a1582, V _a1583, V[] _rest1579) => {
V IC_1586 = default;
V R0_1587 = default;
if (_self1577.IsNullish) _self1577 = GlobalV;
IC_1586 = (GetK(ICON_45, icon_1585) is var _t1588 && Truthy(_t1588) ? _t1588 : Get(ICON_45, "fish"));
R0_1587 = Get(st_1584, "rec");
return Fn((V _self1577, int _argc1589, V I_1595, V tt_1596, V _a1593, V _a1594, V[] _rest1590) => {
V W_1597 = default;
double tl_1598 = 0;
V p_1599 = default;
V gx_1600 = default;
V gy_1601 = default;
V Wp_1602 = default;
V ang_1603 = default;
double bend_1604 = 0;
V mode_1605 = default;
V E_1606 = default;
V fly_1607 = default;
V cat_1608 = default;
V C_1609 = default;
V Rl_1610 = default;
V Ct_1611 = default;
double an_1612 = 0;
double Ln_1613 = 0;
V tip_1614 = default;
double nx_1615 = 0;
double ny_1616 = 0;
V cp_1617 = default;
V hang_1618 = default;
V h_1619 = default;
double sag_1620 = 0;
W_1597 = Get(I_1595, "W");
if ((!(Truthy(W_1597)) || !(Truthy(Call(okp_95, V.Undef, Get(W_1597, "pawR")))))) {
return ((V)(""));
}
tl_1598 = (ToNum(tt_1596) % ToNum(Get(st_1584, "loop")));
p_1599 = Get(W_1597, "pawR");
{ V _t1621 = Call(gnd_96, V.Undef, I_1595);
{ V _t1622 = ListOf(_t1621);
{ V _t1623 = GetIdx(_t1622, 0D);
gx_1600 = _t1623; }
{ V _t1624 = GetIdx(_t1622, 1D);
gy_1601 = _t1624; }
} }
Wp_1602 = Arr(Add(Call(rside_97, V.Undef, I_1595, gx_1600), ((V)(22D))), ((V)(((ToNum(gy_1601) - 2D) + (FdLibm.Sin((ToNum(tt_1596) / 420D)) * 0.6)))));
ang_1603 = ((V)((-40D)));
bend_1604 = 0D;
mode_1605 = ((V)("tip"));
E_1606 = V.Null;
fly_1607 = ((V)(0D));
cat_1608 = ((V)(0D));
C_1609 = GetIdx((Get(R0_1587, "cast") is var _t1625 && Truthy(_t1625) ? _t1625 : Arr()), 0D);
Rl_1610 = GetIdx((Get(R0_1587, "reel") is var _t1626 && Truthy(_t1626) ? _t1626 : Arr()), 0D);
Ct_1611 = GetIdx((Get(R0_1587, "catch") is var _t1627 && Truthy(_t1627) ? _t1627 : Arr()), 0D);
if (Truthy((C_1609 is var _t1628 && !Truthy(_t1628) ? _t1628 : (Ge(((V)(tl_1598)), GetIdx(C_1609, 0D)) ? V.True : V.False)))) {
if (Lt(((V)(tl_1598)), GetIdx(C_1609, 1D))) {
ang_1603 = Call(lerp_99, V.Undef, ((V)((-40D))), ((V)((-122D))), Call(ss_25, V.Undef, ((V)(((tl_1598 - ToNum(GetIdx(C_1609, 0D))) / (ToNum(GetIdx(C_1609, 1D)) - ToNum(GetIdx(C_1609, 0D))))))));
} else {
ang_1603 = Call(lerp_99, V.Undef, ((V)((-122D))), ((V)((-30D))), Call(ss_25, V.Undef, ((V)(((tl_1598 - ToNum(GetIdx(C_1609, 1D))) / 180D)))));
fly_1607 = Call(cl_39, V.Undef, ((V)(((tl_1598 - ToNum(GetIdx(C_1609, 1D))) / 650D))), ((V)(0D)), ((V)(1D)));
mode_1605 = ((V)((LtN(fly_1607, 1D) ? "fly" : "water")));
}
}
if (Truthy((Rl_1610 is var _t1629 && !Truthy(_t1629) ? _t1629 : (Ge(((V)(tl_1598)), GetIdx(Rl_1610, 0D)) ? V.True : V.False)))) {
V u_1630 = default;
u_1630 = Call(cl_39, V.Undef, ((V)(((tl_1598 - ToNum(GetIdx(Rl_1610, 0D))) / (ToNum(GetIdx(Rl_1610, 1D)) - ToNum(GetIdx(Rl_1610, 0D)))))), ((V)(0D)), ((V)(1D)));
ang_1603 = ((V)(((-52D) + (FdLibm.Sin((tl_1598 / 90D)) * 3D))));
bend_1604 = (4D + FdLibm.Sin((tl_1598 / 70D)));
mode_1605 = ((V)("reel"));
fly_1607 = u_1630;
}
if (Truthy((Rl_1610 is var _t1631 && !Truthy(_t1631) ? _t1631 : (Gt(((V)(tl_1598)), GetIdx(Rl_1610, 1D)) ? V.True : V.False)))) {
ang_1603 = ((V)((-60D)));
bend_1604 = 3D;
mode_1605 = ((V)("tip"));
}
if (Truthy((Ct_1611 is var _t1632 && !Truthy(_t1632) ? _t1632 : (Ge(((V)(tl_1598)), GetIdx(Ct_1611, 0D)) ? V.True : V.False)))) {
ang_1603 = Call(lerp_99, V.Undef, ((V)((-60D))), ((V)((-84D))), Call(ss_25, V.Undef, ((V)(((tl_1598 - ToNum(GetIdx(Ct_1611, 0D))) / 300D)))));
bend_1604 = 1.5;
mode_1605 = ((V)((Lt(((V)(tl_1598)), GetIdx(Ct_1611, 1D)) ? "catch" : "tip")));
cat_1608 = Call(win_88, V.Undef, ((V)(tl_1598)), Add(GetIdx(Ct_1611, 0D), ((V)(120D))), GetIdx(Ct_1611, 1D), ((V)(260D)));
if (Gt(((V)(tl_1598)), GetIdx(Ct_1611, 1D))) {
ang_1603 = Call(lerp_99, V.Undef, ((V)((-84D))), ((V)((-40D))), Call(ss_25, V.Undef, ((V)(((tl_1598 - ToNum(GetIdx(Ct_1611, 1D))) / 400D)))));
}
}
an_1612 = ((ToNum(ang_1603) * System.Math.PI) / 180D);
Ln_1613 = 42D;
tip_1614 = Arr(Add(GetIdx(p_1599, 0D), ((V)((FdLibm.Cos(an_1612) * Ln_1613)))), Add(GetIdx(p_1599, 1D), ((V)((FdLibm.Sin(an_1612) * Ln_1613)))));
nx_1615 = (-FdLibm.Sin(an_1612));
ny_1616 = FdLibm.Cos(an_1612);
cp_1617 = Arr(((V)(((ToNum(Add(GetIdx(p_1599, 0D), GetIdx(tip_1614, 0D))) / 2D) + (nx_1615 * bend_1604)))), ((V)(((ToNum(Add(GetIdx(p_1599, 1D), GetIdx(tip_1614, 1D))) / 2D) + (ny_1616 * bend_1604)))));
hang_1618 = Arr(GetIdx(tip_1614, 0D), Add(GetIdx(tip_1614, 1D), ((V)(10D))));
if (SEqS(mode_1605, "fly")) {
E_1606 = Arr(Call(lerp_99, V.Undef, GetIdx(tip_1614, 0D), GetIdx(Wp_1602, 0D), fly_1607), ((V)((ToNum(Call(lerp_99, V.Undef, GetIdx(tip_1614, 1D), GetIdx(Wp_1602, 1D), fly_1607)) - (FdLibm.Sin((System.Math.PI * ToNum(fly_1607))) * 22D)))));
} else {
if (SEqS(mode_1605, "water")) {
V nb_1633 = default;
E_1606 = Arr(GetIdx(Wp_1602, 0D), GetIdx(Wp_1602, 1D));
nb_1633 = Invoke((Get(R0_1587, "nib") is var _t1641 && Truthy(_t1641) ? _t1641 : Arr()), "find", Fn((V _self1577, int _argc1634, V n_1640, V _a1637, V _a1638, V _a1639, V[] _rest1635) => {
return ((Ge(((V)(tl_1598)), n_1640) && Lt(((V)(tl_1598)), Add(n_1640, ((V)(700D))))) ? V.True : V.False);
}, 1, "", true));
if (!nb_1633.IsNullish) {
OpSetK(E_1606, ((V)(1D)), 0, ((V)((3D * System.Math.Abs(FdLibm.Sin(((tl_1598 - ToNum(nb_1633)) / 115D)))))));
}
} else {
if (SEqS(mode_1605, "reel")) {
E_1606 = Arr(Call(lerp_99, V.Undef, GetIdx(Wp_1602, 0D), GetIdx(hang_1618, 0D), fly_1607), Call(lerp_99, V.Undef, GetIdx(Wp_1602, 1D), GetIdx(hang_1618, 1D), fly_1607));
} else {
E_1606 = hang_1618;
}
}
}
h_1619 = ((V)(string.Concat(new string[] { "<path d=\"M", ToStr(Call(r2_38, V.Undef, GetIdx(p_1599, 0D))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(p_1599, 1D))), "Q", ToStr(Call(r2_38, V.Undef, GetIdx(cp_1617, 0D))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(cp_1617, 1D))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(tip_1614, 0D))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(tip_1614, 1D))), "\" stroke=\"#8a5a2c\" stroke-width=\"1.7\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M", ToStr(Call(r2_38, V.Undef, Add(GetIdx(p_1599, 0D), ((V)((FdLibm.Cos(an_1612) * 30D)))))), " ", ToStr(Call(r2_38, V.Undef, Add(GetIdx(p_1599, 1D), ((V)((FdLibm.Sin(an_1612) * 30D)))))), "L", ToStr(Call(r2_38, V.Undef, GetIdx(tip_1614, 0D))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(tip_1614, 1D))), "\" stroke=\"#b07a42\" stroke-width=\"1\" fill=\"none\" stroke-linecap=\"round\"/>" })));
h_1619 = Add(h_1619, Call(ci_43, V.Undef, Call(r2_38, V.Undef, Add(Add(GetIdx(p_1599, 0D), ((V)((FdLibm.Cos(an_1612) * 4D)))), ((V)((nx_1615 * 2.6))))), Call(r2_38, V.Undef, Add(Add(GetIdx(p_1599, 1D), ((V)((FdLibm.Sin(an_1612) * 4D)))), ((V)((ny_1616 * 2.6))))), ((V)(2.2)), ((V)("#c9c9d6")), ((V)("#6a6a80"))));
sag_1620 = (SEqS(mode_1605, "water") ? 8D : 2D);
h_1619 = ((V)(string.Concat(new string[] { ToStr(h_1619), "<path d=\"M", ToStr(Call(r2_38, V.Undef, GetIdx(tip_1614, 0D))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(tip_1614, 1D))), "Q", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(Add(GetIdx(tip_1614, 0D), GetIdx(E_1606, 0D))) / 2D))))), " ", ToStr(Call(r2_38, V.Undef, ((V)(((ToNum(Add(GetIdx(tip_1614, 1D), GetIdx(E_1606, 1D))) / 2D) + sag_1620))))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(E_1606, 0D))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(E_1606, 1D))), "\" stroke=\"#5a6a7a\" stroke-width=\"0.45\" fill=\"none\" opacity=\"0.85\"/>" })));
if (SEqS(mode_1605, "water")) {
h_1619 = ((V)(string.Concat(new string[] { ToStr(h_1619), "<ellipse cx=\"", ToStr(Call(r2_38, V.Undef, GetIdx(E_1606, 0D))), "\" cy=\"", ToStr(Call(r2_38, V.Undef, Add(GetIdx(Wp_1602, 1D), ((V)(2D))))), "\" rx=\"", ToStr(Call(r2_38, V.Undef, ((V)((5D + (FdLibm.Sin((ToNum(tt_1596) / 300D)) * 1.5)))))), "\" ry=\"1.5\" fill=\"none\" stroke=\"#8fd3ff\" stroke-width=\"0.6\" opacity=\"0.9\"/>" })));
}
if (GtN(cat_1608, 0.02)) {
h_1619 = Add(h_1619, Call(G_100, V.Undef, GetIdx(E_1606, 0D), Add(GetIdx(E_1606, 1D), ((V)(5D))), ((V)(((FdLibm.Sin((ToNum(tt_1596) / 110D)) * 18D) + 70D))), ((V)((4D * ToNum(cat_1608)))), IC_1586));
}
if ((!SEqS(mode_1605, "catch") || LtN(cat_1608, 0.5))) {
h_1619 = ((V)(string.Concat(new string[] { ToStr(h_1619), "<path d=\"M", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(E_1606, 0D)) - 2.1))))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(E_1606, 1D))), "A2.1 2.1 0 0 1 ", ToStr(Call(r2_38, V.Undef, Add(GetIdx(E_1606, 0D), ((V)(2.1))))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(E_1606, 1D))), "Z\" fill=\"#e8483c\" stroke=\"#b8302a\" stroke-width=\"0.35\"/><path d=\"M", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(E_1606, 0D)) - 2.1))))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(E_1606, 1D))), "A2.1 2.1 0 0 0 ", ToStr(Call(r2_38, V.Undef, Add(GetIdx(E_1606, 0D), ((V)(2.1))))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(E_1606, 1D))), "Z\" fill=\"#ffffff\" stroke=\"#c9c9d6\" stroke-width=\"0.35\"/>" })));
}
return h_1619;
return default;
}, 2, "", true);
return default;
}, 2, "fishProp", false);
sunProp_116 = Fn((V _self1642, int _argc1643, V st_1649, V _a1646, V _a1647, V _a1648, V[] _rest1644) => {
if (_self1642.IsNullish) _self1642 = GlobalV;
return Fn((V _self1642, int _argc1650, V I_1656, V tt_1657, V _a1654, V _a1655, V[] _rest1651) => {
V P_1658 = default;
V W_1659 = default;
V k_1660 = default;
V h_1661 = default;
V f0_1662 = default;
P_1658 = (Get(I_1656, "lastP") is var _t1663 && Truthy(_t1663) ? _t1663 : NewObj(0).V);
W_1659 = (Get(I_1656, "W") is var _t1664 && Truthy(_t1664) ? _t1664 : NewObj(0).V);
k_1660 = Call(cl_39, V.Undef, (Get(P_1658, "shd") is var _t1665 && Truthy(_t1665) ? _t1665 : ((V)(0D))), ((V)(0D)), ((V)(1D)));
h_1661 = ((V)(""));
f0_1662 = Call(facing_87, V.Undef, I_1656);
if ((GtN(k_1660, 0.02) && GtN(f0_1662, 0.05))) {
V a_1666 = default;
V b_1667 = default;
a_1666 = Get(W_1659, "eyeL");
b_1667 = Get(W_1659, "eyeR");
if (Truthy((Call(okp_95, V.Undef, a_1666) is var _t1668 && Truthy(_t1668) ? _t1668 : Call(okp_95, V.Undef, b_1667)))) {
double mx_1669 = 0;
double my_1670 = 0;
double d_1671 = 0;
double s_1672 = 0;
double dn_1673 = 0;
if (!(Truthy(Call(okp_95, V.Undef, a_1666)))) {
a_1666 = b_1667;
}
if (!(Truthy(Call(okp_95, V.Undef, b_1667)))) {
b_1667 = a_1666;
}
mx_1669 = (ToNum(Add(GetIdx(a_1666, 0D), GetIdx(b_1667, 0D))) / 2D);
my_1670 = (ToNum(Add(GetIdx(a_1666, 1D), GetIdx(b_1667, 1D))) / 2D);
d_1671 = Max(Hypot((ToNum(GetIdx(b_1667, 0D)) - ToNum(GetIdx(a_1666, 0D))), (ToNum(GetIdx(b_1667, 1D)) - ToNum(GetIdx(a_1666, 1D)))), 5D);
s_1672 = (d_1671 / 10D);
dn_1673 = (ToNum(Call(cl_39, V.Undef, (Get(P_1658, "shu") is var _t1674 && Truthy(_t1674) ? _t1674 : ((V)(0D))), ((V)(0D)), ((V)(1D)))) * 2.8);
h_1661 = Add(h_1661, Call(G_100, V.Undef, ((V)(mx_1669)), ((V)((my_1670 + (dn_1673 * s_1672)))), ((V)(((FdLibm.Atan2((ToNum(GetIdx(b_1667, 1D)) - ToNum(GetIdx(a_1666, 1D))), (ToNum(GetIdx(b_1667, 0D)) - ToNum(GetIdx(a_1666, 0D)))) * 180D) / System.Math.PI))), ((V)((s_1672 * (0.6 + (0.4 * ToNum(k_1660)))))), SHADES_115, ((V)((ToNum(k_1660) * Min(1D, (ToNum(f0_1662) * 1.3)))))));
}
}
if (Truthy((st_1649 is var _t1675 && !Truthy(_t1675) ? _t1675 : Call(okp_95, V.Undef, Get(W_1659, "pawR"))))) {
double tl_1676 = 0;
V sb_1677 = default;
tl_1676 = (ToNum(tt_1657) % ToNum(Get(st_1649, "loop")));
sb_1677 = Invoke(Get(st_1649, "beats"), "find", Fn((V _self1642, int _argc1678, V q_1684, V _a1681, V _a1682, V _a1683, V[] _rest1679) => {
return (((SEqS(GetIdx(q_1684, 0D), "sip") && Ge(((V)(tl_1676)), GetIdx(q_1684, 1D))) && Le(((V)(tl_1676)), GetIdx(q_1684, 2D))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(sb_1677)) {
V u_1685 = default;
u_1685 = Call(win_88, V.Undef, ((V)(tl_1676)), GetIdx(sb_1677, 1D), GetIdx(sb_1677, 2D), ((V)(220D)));
if (GtN(u_1685, 0.02)) {
h_1661 = Add(h_1661, Call(G_100, V.Undef, GetIdx(Get(W_1659, "pawR"), 0D), ((V)((ToNum(GetIdx(Get(W_1659, "pawR"), 1D)) - 4D))), ((V)(0D)), ((V)((3.8 * ToNum(u_1685)))), Get(ICON_45, "cup"), f0_1662));
}
}
}
return h_1661;
return default;
}, 2, "", true);
return default;
}, 1, "sunProp", false);
sunIn_117 = Fn((V _self1686, int _argc1687, V SB_1693, V SN_1694, V P_1695, V _a1692, V[] _rest1688) => {
V t_1696 = default;
V v_1697 = default;
V v2_1698 = default;
if (_self1686.IsNullish) _self1686 = GlobalV;
t_1696 = Call(TL_11, V.Undef, REST_9);
Call(enterMove_21, V.Undef, t_1696, SB_1693, (Get(P_1695, "dn") is var _t1699 && Truthy(_t1699) ? _t1699 : ((V)("hop"))));
v_1697 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, SB_1693), "forEach", Fn((V _self1686, int _argc1700, V p_1706, V _a1703, V _a1704, V _a1705, V[] _rest1701) => {
return SetK(v_1697, p_1706, GetK(SB_1693, p_1706));
}, 1, "", true));
Invoke(t_1696, "to", ((V)(140D)), v_1697, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1696, "to", ((V)(320D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-14D)))), NewObj(3).Put("armR", ((V)(40D))).Put("shd", ((V)(0D))).Put("smile", ((V)(0.8))).V), ((V)("io"))), "to", ((V)(220D)), NewObj(3).Put("shd", ((V)(1D))).Put("sqz", ((V)(0.5))).Put("smile", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(240D)), NewObj(1).Put("sqz", ((V)(0D))).V), "to", ((V)(900D)), Call(o_10, V.Undef, SN_1694, NewObj(1).Put("shd", ((V)(1D))).V), ((V)("s"))), "to", ((V)(260D)), NewObj(1).Put("sq", Add(Get(SN_1694, "sq"), ((V)(0.05)))).V, ((V)("o")));
v2_1698 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, SN_1694), "forEach", Fn((V _self1686, int _argc1707, V p_1713, V _a1710, V _a1711, V _a1712, V[] _rest1708) => {
return SetK(v2_1698, p_1713, GetK(SN_1694, p_1713));
}, 1, "", true));
Invoke(t_1696, "to", ((V)(300D)), v2_1698, ((V)("io")));
return Invoke(t_1696, "out", NewObj(2).Put("next", ((V)("sun"))).Put("blend", ((V)(220D))).V);
return default;
}, 3, "sunIn", false);
sunOut_118 = Fn((V _self1714, int _argc1715, V SN_1721, V SB_1722, V P_1723, V _a1720, V[] _rest1716) => {
V t_1724 = default;
V hop_1725 = default;
V st_1726 = default;
if (_self1714.IsNullish) _self1714 = GlobalV;
t_1724 = Call(TL_11, V.Undef, SN_1721);
Invoke(Invoke(Invoke(t_1724, "to", ((V)(550D)), Call(o_10, V.Undef, SB_1722, NewObj(3).Put("shd", ((V)(1D))).Put("shu", ((V)(0D))).Put("close", ((V)(0.2))).V), ((V)("io"))), "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-16D)))), NewObj(1).Put("armR", ((V)(44D))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("shd", ((V)(0D))).Put("wide", ((V)(0.4))).V, ((V)("o")));
Invoke(Invoke(t_1724, "to", ((V)(600D)), NewObj(11).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("hLy", ((V)((-5D)))).Put("hRy", ((V)((-5D)))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("sq", ((V)((ToNum((Get(SB_1722, "sq") is var _t1731 && Truthy(_t1731) ? _t1731 : ((V)(0D)))) - 0.08)))).Put("close", ((V)(0.9))).Put("open", ((V)(0.6))).Put("pitch", Add((Get(SB_1722, "pitch") is var _t1732 && Truthy(_t1732) ? _t1732 : ((V)(0D))), ((V)(0.3)))).Put("wide", ((V)(0D))).V, ((V)("io"))), "to", ((V)(420D)), NewObj(11).Put("armL", (Get(SB_1722, "armL") is var _t1727 && Truthy(_t1727) ? _t1727 : ((V)(0D)))).Put("armR", (Get(SB_1722, "armR") is var _t1728 && Truthy(_t1728) ? _t1728 : ((V)(0D)))).Put("hLy", Get(SB_1722, "hLy")).Put("hRy", Get(SB_1722, "hRy")).Put("hLx", Get(SB_1722, "hLx")).Put("hRx", Get(SB_1722, "hRx")).Put("sq", (Get(SB_1722, "sq") is var _t1729 && Truthy(_t1729) ? _t1729 : ((V)(0D)))).Put("close", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", (Get(SB_1722, "pitch") is var _t1730 && Truthy(_t1730) ? _t1730 : ((V)(0D)))).Put("smile", ((V)(1D))).V, ((V)("io")));
hop_1725 = Get(t_1724, "t");
Call(exitMove_22, V.Undef, t_1724, SB_1722, (Get(P_1723, "up") is var _t1733 && Truthy(_t1733) ? _t1733 : ((V)("hop"))));
Invoke(t_1724, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
st_1726 = Invoke(t_1724, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V);
Set(st_1726, "hop", hop_1725);
return st_1726;
return default;
}, 3, "sunOut", false);
slideMove_119 = Fn((V _self1734, int _argc1735, V P_1741, V X_1742, V _a1739, V _a1740, V[] _rest1736) => {
V t_1743 = default;
V w0_1744 = default;
V st_1745 = default;
if (_self1734.IsNullish) _self1734 = GlobalV;
t_1743 = Call(TL_11, V.Undef, REST_9);
{
double i_1746 = 0;
i_1746 = 0D;
while (true) {
if (!((i_1746 < 4D))) break;
double s_1748 = 0;
s_1748 = (NumTruthy((i_1746 % 2D)) ? (-1D) : 1D);
Invoke(t_1743, "to", ((V)(230D)), NewObj(8).Put("footL", ((V)(((s_1748 > 0D) ? 3D : 0D)))).Put("footR", ((V)(((s_1748 > 0D) ? 0D : 3D)))).Put("lift", ((V)((1.5 + (i_1746 * 3.4))))).Put("tilt", ((V)((s_1748 * 2D)))).Put("armL", ((V)(((s_1748 > 0D) ? 64D : 22D)))).Put("armR", ((V)(((s_1748 > 0D) ? 22D : 64D)))).Put("pitch", ((V)(0.12))).Put("ly", ((V)((-0.4)))).V, ((V)("io")));
i_1746++;
}
}
Invoke(t_1743, "to", ((V)(260D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(6D)), ((V)(3D))), NewObj(10).Put("sit", ((V)(1D))).Put("sq", ((V)(0.1))).Put("lift", ((V)(13.5))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).V), ((V)("io")));
Invoke(Invoke(Invoke(t_1743, "to", ((V)(320D)), NewObj(5).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.9))).Put("wide", ((V)(0.7))).Put("open", ((V)(0.25))).Put("mw", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(420D))), "e", ((V)("blink")));
Invoke(t_1743, "to", ((V)(260D)), Call(o_10, V.Undef, NewObj(13).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("hLx", ((V)((-6D)))).Put("hRx", ((V)(6D))).Put("hLy", ((V)((-6D)))).Put("hRy", ((V)((-6D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.8))).Put("pitch", ((V)(0.12))).Put("ly", ((V)((-0.3)))).Put("wide", ((V)(0.5))).V, Get(X_1742, "cheer")), ((V)("o")));
if (Truthy(Get(X_1742, "cheerFx"))) {
InvokeSpread(t_1743, "fx", new ArrBuilder().Spread(Get(X_1742, "cheerFx")).V);
} else {
Invoke(t_1743, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
}
w0_1744 = Get(t_1743, "t");
Invoke(t_1743, "to", ((V)(720D)), NewObj(9).Put("lift", ((V)(0.6))).Put("x", ((V)(5D))).Put("lean", ((V)((-1.6)))).Put("pitch", ((V)(0.28))).Put("earL", ((V)(16D))).Put("earR", ((V)((-16D)))).Put("footL", ((V)(3.4))).Put("footR", ((V)(3.4))).Put("sq", ((V)(0.04))).V, ((V)("i")));
Invoke(Invoke(t_1743, "to", ((V)(140D)), NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.16))).Put("x", ((V)(6D))).Put("lean", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("dust")), ((V)("belly")), ((V)(4D)));
Invoke(Invoke(t_1743, "to", ((V)(220D)), NewObj(10).Put("sit", ((V)(0D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(3.2))).Put("armL", ((V)(110D))).Put("armR", ((V)(110D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i")));
Invoke(Invoke(t_1743, "to", ((V)(260D)), NewObj(12).Put("sqz", ((V)(0.8))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("wide", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(4D)), NewObj(1).Put("sq", ((V)(0.03))).V, NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o")));
Invoke(t_1743, "back", ((V)(500D)));
st_1745 = Invoke(t_1743, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(180D))).V);
Set(st_1745, "whee", w0_1744);
return st_1745;
return default;
}, 2, "slideMove", false);
bounceIn_122 = Fn((V _self1749, int _argc1750, V TB_1756, V P_1757, V _a1754, V _a1755, V[] _rest1751) => {
V t_1758 = default;
V v_1759 = default;
if (_self1749.IsNullish) _self1749 = GlobalV;
t_1758 = Call(TL_11, V.Undef, REST_9);
Call(enterMove_21, V.Undef, t_1758, TB_1756, ((V)((SEqS(Get(P_1757, "dn"), "float") ? "float" : "hop"))));
v_1759 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, TB_1756), "forEach", Fn((V _self1749, int _argc1760, V p_1766, V _a1763, V _a1764, V _a1765, V[] _rest1761) => {
return SetK(v_1759, p_1766, GetK(TB_1756, p_1766));
}, 1, "", true));
Invoke(t_1758, "to", ((V)(160D)), v_1759, ((V)("io")));
{
double i_1767 = 0;
i_1767 = 0D;
while (true) {
if (!((i_1767 < 2D))) break;
Invoke(Invoke(Invoke(t_1758, "to", ((V)(110D)), NewObj(2).Put("sq", ((V)(0.1))).Put("lift", ((V)((-1D)))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)((-0.05)))).Put("lift", ((V)(5D))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("armL", Get(TB_1756, "armL")).Put("armR", Get(TB_1756, "armR")).V, ((V)("i")));
i_1767++;
}
}
return Invoke(t_1758, "out", NewObj(2).Put("next", ((V)("bounce"))).Put("blend", ((V)(200D))).V);
return default;
}, 2, "bounceIn", false);
bounceOut_123 = Fn((V _self1769, int _argc1770, V TB_1776, V P_1777, V _a1774, V _a1775, V[] _rest1771) => {
V t_1778 = default;
V hop_1779 = default;
V st_1780 = default;
if (_self1769.IsNullish) _self1769 = GlobalV;
t_1778 = Call(TL_11, V.Undef, TB_1776);
Invoke(Invoke(Invoke(Invoke(t_1778, "to", ((V)(130D)), NewObj(2).Put("sq", ((V)(0.15))).Put("lift", ((V)((-1.4)))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(12D))).Put("armL", ((V)(110D))).Put("armR", ((V)(110D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0.1))).Put("lift", ((V)(0D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o")));
hop_1779 = Get(t_1778, "t");
Call(exitMove_22, V.Undef, t_1778, TB_1776, ((V)((SEqS(Get(P_1777, "up"), "float") ? "float" : "hop"))));
Invoke(Invoke(t_1778, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("o")));
st_1780 = Invoke(t_1778, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V);
Set(st_1780, "hop", hop_1779);
return st_1780;
return default;
}, 2, "bounceOut", false);
digProp_130 = Fn((V _self1781, int _argc1782, V st_1788, V _a1785, V _a1786, V _a1787, V[] _rest1783) => {
V R0_1789 = default;
double K_1790 = 0;
if (_self1781.IsNullish) _self1781 = GlobalV;
R0_1789 = Get(st_1788, "rec");
K_1790 = 2D;
return Fn((V _self1781, int _argc1791, V I_1797, V tt_1798, V _a1795, V _a1796, V[] _rest1792) => {
V W_1799 = default;
double tl_1800 = 0;
V gx_1801 = default;
V gy_1802 = default;
V cx_1803 = default;
V cy_1804 = default;
V f0_1805 = default;
double pile_1806 = 0;
double tw_1807 = 0;
double fl_1808 = 0;
V sl_1809 = default;
double pk_1810 = 0;
double ph_1811 = 0;
V c_1812 = default;
V tower_1813 = default;
double th_1814 = 0;
V h_1815 = default;
V B0_1816 = default;
V cur_1817 = default;
double PK_1818 = 0;
W_1799 = Get(I_1797, "W");
if ((!(Truthy(W_1799)) || !(Truthy(Call(okp_95, V.Undef, Get(W_1799, "pawR")))))) {
return ((V)(""));
}
tl_1800 = (ToNum(tt_1798) % ToNum(Get(st_1788, "loop")));
{ V _t1819 = Call(gnd_96, V.Undef, I_1797);
{ V _t1820 = ListOf(_t1819);
{ V _t1821 = GetIdx(_t1820, 0D);
gx_1801 = _t1821; }
{ V _t1822 = GetIdx(_t1820, 1D);
gy_1802 = _t1822; }
} }
cx_1803 = Add(gx_1801, ((V)(2D)));
cy_1804 = Add(gy_1802, ((V)(5D)));
f0_1805 = Call(facing_87, V.Undef, I_1797);
pile_1806 = 0D;
tw_1807 = 0D;
fl_1808 = 0D;
sl_1809 = ((V)(0D));
{
foreach (V _k1823 in Iterate(Get(st_1788, "beats"))) {
V n_1824 = default;
V a_1825 = default;
V b_1826 = default;
{ V _t1827 = ListOf(_k1823);
{ V _t1828 = GetIdx(_t1827, 0D);
n_1824 = _t1828; }
{ V _t1829 = GetIdx(_t1827, 1D);
a_1825 = _t1829; }
{ V _t1830 = GetIdx(_t1827, 2D);
b_1826 = _t1830; }
}
V u_1831 = default;
if (Lt(((V)(tl_1800)), a_1825)) {
break;
}
u_1831 = Call(cl_39, V.Undef, ((V)(((tl_1800 - ToNum(a_1825)) / Max(1D, (ToNum(b_1826) - ToNum(a_1825)))))), ((V)(0D)), ((V)(1D)));
if (SEqS(n_1824, "scoop")) {
pile_1806 = Max(pile_1806, (0.25 + (0.3 * ToNum(u_1831))));
} else {
if (SEqS(n_1824, "pile")) {
pile_1806 = Max(pile_1806, (0.55 + (0.45 * ToNum(u_1831))));
} else {
if (SEqS(n_1824, "crumble")) {
sl_1809 = Call(ss_25, V.Undef, ((V)((((tl_1800 - ToNum(a_1825)) - 120D) / 700D))));
}
}
}
}
}
Invoke((Get(R0_1789, "bk") is var _t1839 && Truthy(_t1839) ? _t1839 : Arr()), "forEach", Fn((V _self1781, int _argc1832, V q_1838, V _a1835, V _a1836, V _a1837, V[] _rest1833) => {
if (Ge(((V)(tl_1800)), GetIdx(q_1838, 2D))) {
tw_1807++;
}
return default;
}, 1, "", true));
Invoke((Get(R0_1789, "flag") is var _t1847 && Truthy(_t1847) ? _t1847 : Arr()), "forEach", Fn((V _self1781, int _argc1840, V q_1846, V _a1843, V _a1844, V _a1845, V[] _rest1841) => {
if (Ge(((V)(tl_1800)), q_1846)) {
fl_1808 = 1D;
}
return default;
}, 1, "", true));
pk_1810 = (pile_1806 * (1D + (ToNum(sl_1809) * 0.25)));
ph_1811 = ((3.6 * pile_1806) * (1D - (ToNum(sl_1809) * 0.4)));
c_1812 = ((V)(""));
if ((pile_1806 > 0.02)) {
c_1812 = ((V)(string.Concat(new string[] { ToStr(c_1812), "<ellipse cx=\"0\" cy=\"0\" rx=\"", ToStr(Call(r2_38, V.Undef, ((V)((10D * pk_1810))))), "\" ry=\"", ToStr(Call(r2_38, V.Undef, ((V)(Max(0.6, ph_1811))))), "\" fill=\"", ToStr(SAND_125), "\" stroke=\"", ToStr(SANDK_126), "\" stroke-width=\"0.35\"/><ellipse cx=\"", ToStr(Call(r2_38, V.Undef, ((V)(((-2.4) * pk_1810))))), "\" cy=\"", ToStr(Call(r2_38, V.Undef, ((V)(((-ph_1811) * 0.45))))), "\" rx=\"", ToStr(Call(r2_38, V.Undef, ((V)((4D * pk_1810))))), "\" ry=\"", ToStr(Call(r2_38, V.Undef, ((V)(Max(0.3, (ph_1811 * 0.35)))))), "\" fill=\"", ToStr(SANDL_127), "\" opacity=\"0.7\"/>", ToStr(Invoke(Invoke(Arr(Arr(((V)((-6D))), ((V)(0.4))), Arr(((V)(4D)), ((V)((-0.6)))), Arr(((V)(7D)), ((V)(0.8)))), "map", Fn((V _self1781, int _argc1848, V _a1850, V _a1851, V _a1852, V _a1853, V[] _rest1849) => {
V x_1856 = default;
V y_1858 = default;
{ V _t1854 = ListOf(_a1850);
{ V _t1855 = GetIdx(_t1854, 0D);
x_1856 = _t1855; }
{ V _t1857 = GetIdx(_t1854, 1D);
y_1858 = _t1857; }
}
return Call(ci_43, V.Undef, Call(r2_38, V.Undef, ((V)((ToNum(x_1856) * pk_1810)))), Call(r2_38, V.Undef, ((V)(((ToNum(y_1858) * ph_1811) * 0.4)))), Call(r2_38, V.Undef, ((V)((0.35 * pk_1810)))), SANDK_126);
}, 1, "", true)), "join", ((V)("")))) })));
}
tower_1813 = Fn((V _self1781, int _argc1859, V x_1865, V hh_1866, V _a1863, V _a1864, V[] _rest1860) => {
double y0_1867 = 0;
double y1_1868 = 0;
y0_1867 = ((-ph_1811) * 0.6);
y1_1868 = (y0_1867 - ToNum(hh_1866));
if (LtN(hh_1866, 0.4)) {
return ((V)(""));
}
return ((V)(string.Concat(new string[] { "<path d=\"M", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(x_1865) - 2.8))))), " ", ToStr(Call(r2_38, V.Undef, ((V)(y0_1867)))), "L", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(x_1865) - 2.4))))), " ", ToStr(Call(r2_38, V.Undef, ((V)(y1_1868)))), "H", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(x_1865) - 1.4))))), "V", ToStr(Call(r2_38, V.Undef, ((V)((y1_1868 - 1.1))))), "H", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(x_1865) - 0.5))))), "V", ToStr(Call(r2_38, V.Undef, ((V)(y1_1868)))), "H", ToStr(Call(r2_38, V.Undef, Add(x_1865, ((V)(0.5))))), "V", ToStr(Call(r2_38, V.Undef, ((V)((y1_1868 - 1.1))))), "H", ToStr(Call(r2_38, V.Undef, Add(x_1865, ((V)(1.4))))), "V", ToStr(Call(r2_38, V.Undef, ((V)(y1_1868)))), "H", ToStr(Call(r2_38, V.Undef, Add(x_1865, ((V)(2.4))))), "L", ToStr(Call(r2_38, V.Undef, Add(x_1865, ((V)(2.8))))), " ", ToStr(Call(r2_38, V.Undef, ((V)(y0_1867)))), "Z\" fill=\"", ToStr(SAND_125), "\" stroke=\"", ToStr(SANDK_126), "\" stroke-width=\"0.35\"/><path d=\"M", ToStr(Call(r2_38, V.Undef, Add(x_1865, ((V)(1.2))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_1867 - 0.2))))), "L", ToStr(Call(r2_38, V.Undef, Add(x_1865, ((V)(1.2))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y1_1868 + 0.4))))), "H", ToStr(Call(r2_38, V.Undef, Add(x_1865, ((V)(2.3))))), "L", ToStr(Call(r2_38, V.Undef, Add(x_1865, ((V)(2.7))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_1867 - 0.2))))), "Z\" fill=\"", ToStr(SANDK_126), "\" opacity=\"0.35\"/><path d=\"M", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(x_1865) - 0.7))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((y0_1867 - (ToNum(hh_1866) * 0.35)))))), "h1.4v-1.6a0.7 0.7 0 0 0-1.4 0Z\" fill=\"", ToStr(SANDK_126), "\" opacity=\"0.6\"/>" })));
return default;
}, 2, "", true);
th_1814 = (6.5 * (1D - ToNum(sl_1809)));
if ((tw_1807 > 0D)) {
c_1812 = Add(c_1812, Call(tower_1813, V.Undef, ((V)((-3.2))), ((V)(th_1814))));
}
if ((tw_1807 > 1D)) {
c_1812 = Add(c_1812, Call(tower_1813, V.Undef, ((V)(3.4)), ((V)((th_1814 * 0.82)))));
}
if (Truthy((((V)(fl_1808)) is var _t1869 && !Truthy(_t1869) ? _t1869 : (LtN(sl_1809, 0.6) ? V.True : V.False)))) {
double fy0_1870 = 0;
double wv_1871 = 0;
fy0_1870 = ((((-ph_1811) * 0.6) - th_1814) - 1D);
wv_1871 = (FdLibm.Sin((ToNum(tt_1798) / 160D)) * 0.8);
c_1812 = ((V)(string.Concat(new string[] { ToStr(c_1812), "<g opacity=\"", ToStr(Call(r2_38, V.Undef, ((V)((1D - (ToNum(sl_1809) / 0.6)))))), "\"><path d=\"M-3.2 ", ToStr(Call(r2_38, V.Undef, ((V)(fy0_1870)))), "V", ToStr(Call(r2_38, V.Undef, ((V)((fy0_1870 - 6D))))), "\" stroke=\"#8a5a2c\" stroke-width=\"0.4\"/><path d=\"M-3.2 ", ToStr(Call(r2_38, V.Undef, ((V)((fy0_1870 - 6D))))), "Q-1.2 ", ToStr(Call(r2_38, V.Undef, ((V)(((fy0_1870 - 5.6) + wv_1871))))), " 0.6 ", ToStr(Call(r2_38, V.Undef, ((V)(((fy0_1870 - 4.9) + wv_1871))))), "L-3.2 ", ToStr(Call(r2_38, V.Undef, ((V)((fy0_1870 - 3.8))))), "Z\" fill=\"#e8483c\"/></g>" })));
}
h_1815 = Call(G_100, V.Undef, cx_1803, cy_1804, ((V)(0D)), ((V)(K_1790)), c_1812);
B0_1816 = Arr(Add(Call(rside_97, V.Undef, I_1797, gx_1801), ((V)(6D))), Add(gy_1802, ((V)(2D))));
cur_1817 = Invoke((Get(R0_1789, "bk") is var _t1879 && Truthy(_t1879) ? _t1879 : Arr()), "find", Fn((V _self1781, int _argc1872, V q_1878, V _a1875, V _a1876, V _a1877, V[] _rest1873) => {
return ((Ge(((V)(tl_1800)), GetIdx(q_1878, 0D)) && Lt(((V)(tl_1800)), GetIdx(q_1878, 3D))) ? V.True : V.False);
}, 1, "", true));
PK_1818 = 2.3;
if (Truthy(cur_1817)) {
V g_1880 = default;
V s_1881 = default;
V l_1882 = default;
V e_1883 = default;
{ V _t1884 = cur_1817;
{ V _t1885 = ListOf(_t1884);
{ V _t1886 = GetIdx(_t1885, 0D);
g_1880 = _t1886; }
{ V _t1887 = GetIdx(_t1885, 1D);
s_1881 = _t1887; }
{ V _t1888 = GetIdx(_t1885, 2D);
l_1882 = _t1888; }
{ V _t1889 = GetIdx(_t1885, 3D);
e_1883 = _t1889; }
} }
if (Lt(((V)(tl_1800)), s_1881)) {
V u_1890 = default;
u_1890 = Call(ss_25, V.Undef, ((V)(((tl_1800 - ToNum(g_1880)) / (ToNum(s_1881) - ToNum(g_1880))))));
h_1815 = Add(h_1815, Call(G_100, V.Undef, GetIdx(Get(W_1799, "pawR"), 0D), Add(GetIdx(Get(W_1799, "pawR"), 1D), ((V)(4D))), ((V)((180D * ToNum(u_1890)))), ((V)(PK_1818)), PAIL_128));
} else {
if (Lt(((V)(tl_1800)), l_1882)) {
h_1815 = Add(h_1815, Call(G_100, V.Undef, Add(cx_1803, ((V)((K_1790 * (NumTruthy(tw_1807) ? 3.4 : (-3.2)))))), ((V)((ToNum(cy_1804) - (K_1790 * ((ph_1811 * 0.6) + 3.4))))), ((V)(180D)), ((V)(PK_1818)), PAIL_128));
} else {
V u_1891 = default;
u_1891 = Call(ss_25, V.Undef, ((V)(((tl_1800 - ToNum(l_1882)) / (ToNum(e_1883) - ToNum(l_1882))))));
h_1815 = Add(h_1815, Call(G_100, V.Undef, GetIdx(Get(W_1799, "pawR"), 0D), Add(GetIdx(Get(W_1799, "pawR"), 1D), ((V)(4D))), ((V)((180D * (1D - ToNum(u_1891))))), ((V)(PK_1818)), PAIL_128));
}
}
} else {
h_1815 = Add(h_1815, Call(G_100, V.Undef, GetIdx(B0_1816, 0D), ((V)((ToNum(GetIdx(B0_1816, 1D)) - 6D))), ((V)(0D)), ((V)(PK_1818)), PAIL_128));
}
if (!(Truthy(cur_1817))) {
h_1815 = Add(h_1815, Call(G_100, V.Undef, GetIdx(Get(W_1799, "pawR"), 0D), GetIdx(Get(W_1799, "pawR"), 1D), ((V)((Truthy(Invoke(Get(st_1788, "beats"), "some", Fn((V _self1781, int _argc1892, V b_1898, V _a1895, V _a1896, V _a1897, V[] _rest1893) => {
return (((SEqS(GetIdx(b_1898, 0D), "scoop") && Ge(((V)(tl_1800)), GetIdx(b_1898, 1D))) && Le(((V)(tl_1800)), GetIdx(b_1898, 2D))) ? V.True : V.False);
}, 1, "", true))) ? (20D + (FdLibm.Sin((tl_1800 / 130D)) * 26D)) : 18D))), ((V)(2D)), SPADE_129, ((V)(Max(0.3, ToNum(f0_1805))))));
} else {
h_1815 = Add(h_1815, Call(G_100, V.Undef, ((V)((ToNum(gx_1801) - 26D))), Add(gy_1802, ((V)(2D))), ((V)(80D)), ((V)(2D)), SPADE_129));
}
return h_1815;
return default;
}, 2, "", true);
return default;
}, 1, "digProp", false);
blocksProp_135 = Fn((V _self1899, int _argc1900, V st_1906, V _a1903, V _a1904, V _a1905, V[] _rest1901) => {
V R0_1907 = default;
double BS_1908 = 0;
double Z_1909 = 0;
if (_self1899.IsNullish) _self1899 = GlobalV;
R0_1907 = Get(st_1906, "rec");
BS_1908 = 1.45;
Z_1909 = (5.6 * BS_1908);
return Fn((V _self1899, int _argc1910, V I_1916, V tt_1917, V _a1914, V _a1915, V[] _rest1911) => {
V W_1918 = default;
double tl_1919 = 0;
V gx_1920 = default;
V gy_1921 = default;
V tx_1922 = default;
double ty_1923 = 0;
V PL_1924 = default;
V SC_1925 = default;
V pk_1926 = default;
V pl_1927 = default;
V T0_1928 = default;
V Td_1929 = default;
V TdE_1930 = default;
V Wb_1931 = default;
double rot_1932 = 0;
double cs_1933 = 0;
double sn_1934 = 0;
V h_1935 = default;
W_1918 = Get(I_1916, "W");
if ((!(Truthy(W_1918)) || !(Truthy(Call(okp_95, V.Undef, Get(W_1918, "pawR")))))) {
return ((V)(""));
}
tl_1919 = (ToNum(tt_1917) % ToNum(Get(st_1906, "loop")));
{ V _t1936 = Call(gnd_96, V.Undef, I_1916);
{ V _t1937 = ListOf(_t1936);
{ V _t1938 = GetIdx(_t1937, 0D);
gx_1920 = _t1938; }
{ V _t1939 = GetIdx(_t1937, 1D);
gy_1921 = _t1939; }
} }
tx_1922 = Add(Call(rside_97, V.Undef, I_1916, gx_1920), ((V)(10D)));
ty_1923 = (ToNum(gy_1921) - (Z_1909 / 2D));
PL_1924 = Arr(Arr(((V)((ToNum(tx_1922) - 19D))), ((V)((ToNum(gy_1921) - 2D)))), Arr(((V)((ToNum(tx_1922) - 11D))), ((V)((ToNum(gy_1921) - 2D)))), Arr(((V)((ToNum(tx_1922) - 23D))), Add(gy_1921, ((V)(6D)))), Arr(((V)((ToNum(tx_1922) - 15D))), Add(gy_1921, ((V)(6D)))), Arr(((V)((ToNum(tx_1922) - 7D))), Add(gy_1921, ((V)(6D)))));
SC_1925 = Arr(Arr(((V)((ToNum(tx_1922) - 2D))), Add(gy_1921, ((V)(3D))), ((V)(20D))), Arr(Add(tx_1922, ((V)(8D))), Add(gy_1921, ((V)(1D))), ((V)((-35D)))), Arr(((V)((ToNum(tx_1922) - 10D))), Add(gy_1921, ((V)(8D))), ((V)(60D))), Arr(Add(tx_1922, ((V)(15D))), Add(gy_1921, ((V)(6D))), ((V)(15D))), Arr(((V)((ToNum(tx_1922) - 20D))), Add(gy_1921, ((V)(9D))), ((V)((-50D)))));
pk_1926 = (Get(R0_1907, "pick") is var _t1940 && Truthy(_t1940) ? _t1940 : Arr());
pl_1927 = (Get(R0_1907, "place") is var _t1941 && Truthy(_t1941) ? _t1941 : Arr());
T0_1928 = GetIdx((Get(R0_1907, "top") is var _t1942 && Truthy(_t1942) ? _t1942 : Arr()), 0D);
Td_1929 = GetIdx((Get(R0_1907, "tidy") is var _t1943 && Truthy(_t1943) ? _t1943 : Arr()), 0D);
TdE_1930 = (Get(R0_1907, "tidyE") is var _t1944 && Truthy(_t1944) ? _t1944 : ((V)(0D)));
Wb_1931 = GetIdx((Get(R0_1907, "wob") is var _t1945 && Truthy(_t1945) ? _t1945 : Arr()), 0D);
rot_1932 = 0D;
if (((!Wb_1931.IsNullish && Gt(((V)(tl_1919)), Wb_1931)) && Lt(((V)(tl_1919)), Add(Wb_1931, ((V)(1500D)))))) {
rot_1932 = ((7D * FdLibm.Sin(((tl_1919 - ToNum(Wb_1931)) / 110D))) * (1D - ((tl_1919 - ToNum(Wb_1931)) / 1500D)));
}
if (((!T0_1928.IsNullish && Gt(((V)(tl_1919)), T0_1928)) && Lt(((V)(tl_1919)), Add(T0_1928, ((V)(260D)))))) {
rot_1932 = (14D * ToNum(Call(ss_25, V.Undef, ((V)(((tl_1919 - ToNum(T0_1928)) / 260D))))));
}
cs_1933 = FdLibm.Cos(((rot_1932 * System.Math.PI) / 180D));
sn_1934 = FdLibm.Sin(((rot_1932 * System.Math.PI) / 180D));
h_1935 = ((V)(""));
{
double i_1946 = 0;
i_1946 = 0D;
while (true) {
if (!((i_1946 < 5D))) break;
V x_1948 = default;
V y_1949 = default;
V r_1950 = default;
V slot_1951 = default;
V tow_1952 = default;
x_1948 = V.Undef;
y_1949 = V.Undef;
r_1950 = ((V)(0D));
slot_1951 = Arr(tx_1922, ((V)((ty_1923 - (i_1946 * Z_1909)))));
tow_1952 = Fn((V _self1899, int _argc1953, V _a1955, V _a1956, V _a1957, V _a1958, V[] _rest1954) => {
double dy_1959 = 0;
dy_1959 = (ToNum(GetIdx(slot_1951, 1D)) - ToNum(gy_1921));
return Arr(((V)((ToNum(tx_1922) - (dy_1959 * sn_1934)))), Add(gy_1921, ((V)((dy_1959 * cs_1933)))), ((V)(rot_1932)));
return default;
}, 0, "", true);
if (((!T0_1928.IsNullish && Ge(((V)(tl_1919)), Add(T0_1928, ((V)(260D))))) && (Td_1929.IsNullish || Lt(((V)(tl_1919)), Td_1929)))) {
V u_1960 = default;
V q_1961 = default;
u_1960 = Call(ss_25, V.Undef, ((V)((((tl_1919 - ToNum(T0_1928)) - 260D) / 520D))));
q_1961 = Call(tow_1952, V.Undef);
x_1948 = Call(lerp_99, V.Undef, GetIdx(q_1961, 0D), GetIdx(GetIdx(SC_1925, i_1946), 0D), u_1960);
y_1949 = ((V)((ToNum(Call(lerp_99, V.Undef, GetIdx(q_1961, 1D), GetIdx(GetIdx(SC_1925, i_1946), 1D), u_1960)) - (FdLibm.Sin((System.Math.PI * ToNum(u_1960))) * (6D + (i_1946 * 2.5))))));
r_1950 = Call(lerp_99, V.Undef, GetIdx(q_1961, 2D), GetIdx(GetIdx(SC_1925, i_1946), 2D), u_1960);
} else {
if ((!Td_1929.IsNullish && Ge(((V)(tl_1919)), Td_1929))) {
V u_1962 = default;
u_1962 = Call(ss_25, V.Undef, ((V)(((tl_1919 - ToNum(Td_1929)) / Max(1D, (ToNum(TdE_1930) - ToNum(Td_1929)))))));
x_1948 = Call(lerp_99, V.Undef, GetIdx(GetIdx(SC_1925, i_1946), 0D), GetIdx(GetIdx(PL_1924, i_1946), 0D), u_1962);
y_1949 = ((V)((ToNum(Call(lerp_99, V.Undef, GetIdx(GetIdx(SC_1925, i_1946), 1D), GetIdx(GetIdx(PL_1924, i_1946), 1D), u_1962)) - (FdLibm.Sin((System.Math.PI * ToNum(u_1962))) * 3D))));
r_1950 = Call(lerp_99, V.Undef, GetIdx(GetIdx(SC_1925, i_1946), 2D), ((V)(0D)), u_1962);
} else {
if ((!GetIdx(pl_1927, i_1946).IsNullish && Ge(((V)(tl_1919)), GetIdx(pl_1927, i_1946)))) {
{ V _t1963 = Call(tow_1952, V.Undef);
{ V _t1964 = ListOf(_t1963);
{ V _t1965 = GetIdx(_t1964, 0D);
x_1948 = _t1965; }
{ V _t1966 = GetIdx(_t1964, 1D);
y_1949 = _t1966; }
{ V _t1967 = GetIdx(_t1964, 2D);
r_1950 = _t1967; }
} }
} else {
if ((!GetIdx(pk_1926, i_1946).IsNullish && Ge(((V)(tl_1919)), GetIdx(pk_1926, i_1946)))) {
V pw_1968 = default;
V u_1969 = default;
pw_1968 = Arr(GetIdx(Get(W_1918, "pawR"), 0D), ((V)((ToNum(GetIdx(Get(W_1918, "pawR"), 1D)) - 4D))));
u_1969 = Call(ss_25, V.Undef, ((V)(((tl_1919 - (ToNum(GetIdx(pl_1927, i_1946)) - 320D)) / 320D))));
x_1948 = Call(lerp_99, V.Undef, GetIdx(pw_1968, 0D), GetIdx(slot_1951, 0D), u_1969);
y_1949 = Call(lerp_99, V.Undef, GetIdx(pw_1968, 1D), GetIdx(slot_1951, 1D), u_1969);
} else {
x_1948 = GetIdx(GetIdx(PL_1924, i_1946), 0D);
y_1949 = GetIdx(GetIdx(PL_1924, i_1946), 1D);
}
}
}
}
h_1935 = Add(h_1935, Call(G_100, V.Undef, x_1948, y_1949, r_1950, ((V)(BS_1908)), Call(BLK_133, V.Undef, ((V)(i_1946)))));
i_1946++;
}
}
return h_1935;
return default;
}, 2, "", true);
return default;
}, 1, "blocksProp", false);
waterMove_137 = Fn((V _self1970, int _argc1971, V X_1977, V _a1974, V _a1975, V _a1976, V[] _rest1972) => {
V t_1978 = default;
V a_1979 = default;
V p0_1980 = default;
V p1_1981 = default;
V b_1982 = default;
V st_1983 = default;
V e_1984 = default;
if (_self1970.IsNullish) _self1970 = GlobalV;
t_1978 = Call(TL_11, V.Undef, REST_9);
Invoke(t_1978, "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-3D))), ((V)((-1D)))), NewObj(5).Put("armR", ((V)(46D))).Put("lx", ((V)(0.6))).Put("ly", ((V)(0.5))).Put("pitch", ((V)((-0.08)))).Put("smile", ((V)(0.8))).V), ((V)("io")));
a_1979 = Get(t_1978, "t");
Invoke(t_1978, "to", ((V)(420D)), NewObj(4).Put("armR", ((V)(64D))).Put("hRy", ((V)((-5D)))).Put("tilt", ((V)(3D))).Put("lean", ((V)(0.5))).V, ((V)("io")));
p0_1980 = Get(t_1978, "t");
Invoke(t_1978, "osc", ((V)(1800D)), ((V)(4D)), NewObj(2).Put("hRy", ((V)((-4D)))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("hRy", ((V)((-6D)))).Put("htilt", ((V)((-3D)))).V, ((V)("s")));
p1_1981 = Get(t_1978, "t");
Invoke(t_1978, "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(4D)), ((V)(2D))), NewObj(3).Put("armR", ((V)(18D))).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).V), ((V)("io")));
b_1982 = Get(t_1978, "t");
Invoke(t_1978, "to", ((V)(320D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(10D)), ((V)((-7D)))), NewObj(7).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("htilt", ((V)(6D))).Put("ly", ((V)(0.4))).V, Get(X_1977, "cheer")), ((V)("o")));
if (Truthy(Get(X_1977, "cheerFx"))) {
InvokeSpread(t_1978, "fx", new ArrBuilder().Spread(Get(X_1977, "cheerFx")).V);
}
Invoke(Invoke(Invoke(Invoke(t_1978, "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "wait", ((V)(900D))), "to", ((V)(300D)), NewObj(2).Put("sqz", ((V)(0D))).Put("close", ((V)(0.5))).V), "wait", ((V)(300D)));
Invoke(t_1978, "back", ((V)(420D)));
st_1983 = Invoke(t_1978, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(180D))).V);
e_1984 = Get(st_1983, "dur");
Set(st_1983, "prop", Fn((V _self1970, int _argc1985, V I_1991, V tt_1992, V _a1989, V _a1990, V[] _rest1986) => {
V W_1993 = default;
V gx_1994 = default;
V gy_1995 = default;
V sx_1996 = default;
V sy_1997 = default;
V f0_1998 = default;
double CK_1999 = 0;
V h_2000 = default;
V gr_2001 = default;
V bl_2002 = default;
double fade_2003 = 0;
double sh_2004 = 0;
double ang_2005 = 0;
double vis_2006 = 0;
W_1993 = Get(I_1991, "W");
if ((!(Truthy(W_1993)) || !(Truthy(Call(okp_95, V.Undef, Get(W_1993, "pawR")))))) {
return ((V)(""));
}
{ V _t2007 = Call(gnd_96, V.Undef, I_1991);
{ V _t2008 = ListOf(_t2007);
{ V _t2009 = GetIdx(_t2008, 0D);
gx_1994 = _t2009; }
{ V _t2010 = GetIdx(_t2008, 1D);
gy_1995 = _t2010; }
} }
sx_1996 = Add(Call(rside_97, V.Undef, I_1991, gx_1994), ((V)(10D)));
sy_1997 = Add(gy_1995, ((V)(1D)));
f0_1998 = Call(facing_87, V.Undef, I_1991);
CK_1999 = 1.9;
h_2000 = ((V)(""));
gr_2001 = Call(ss_25, V.Undef, ((V)(((ToNum(tt_1992) - ToNum(p0_1980)) / (ToNum(p1_1981) - ToNum(p0_1980))))));
bl_2002 = Call(ss_25, V.Undef, ((V)((((ToNum(tt_1992) - ToNum(b_1982)) - 200D) / 500D))));
fade_2003 = (1D - ToNum(Call(ss_25, V.Undef, ((V)((((ToNum(tt_1992) - ToNum(e_1984)) + 500D) / 500D))))));
sh_2004 = ((3D + (13D * ToNum(gr_2001))) * fade_2003);
if ((sh_2004 > 0.3)) {
double lf_2011 = 0;
lf_2011 = ((0.4 + (ToNum(gr_2001) * 0.8)) * fade_2003);
h_2000 = ((V)(string.Concat(new string[] { ToStr(h_2000), "<path d=\"M", ToStr(Call(r2_38, V.Undef, sx_1996)), " ", ToStr(Call(r2_38, V.Undef, sy_1997)), "Q", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(sx_1996) - 0.8))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(sy_1997) - (sh_2004 * 0.5)))))), " ", ToStr(Call(r2_38, V.Undef, sx_1996)), " ", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(sy_1997) - sh_2004))))), "\" stroke=\"#4f8f3a\" stroke-width=\"1.3\" fill=\"none\"/>", ToStr(Call(G_100, V.Undef, sx_1996, ((V)((ToNum(sy_1997) - (sh_2004 * 0.55)))), ((V)(((-30D) + (FdLibm.Sin((ToNum(tt_1992) / 400D)) * 6D)))), ((V)((lf_2011 * 1.8))), ((V)("<path d=\"M0 0Q-4-0.6-5-3Q-1.6-3.2 0 0Z\" fill=\"#7cc35a\" stroke=\"#4f8f3a\" stroke-width=\"0.35\"/>")))), ToStr(Call(G_100, V.Undef, sx_1996, ((V)((ToNum(sy_1997) - (sh_2004 * 0.75)))), ((V)((20D - (FdLibm.Sin((ToNum(tt_1992) / 400D)) * 6D)))), ((V)((lf_2011 * 1.8))), ((V)("<path d=\"M0 0Q4-0.6 5-3Q1.6-3.2 0 0Z\" fill=\"#8fd06a\" stroke=\"#4f8f3a\" stroke-width=\"0.35\"/>")))) })));
if (GtN(bl_2002, 0.02)) {
h_2000 = Add(h_2000, Call(G_100, V.Undef, sx_1996, ((V)((ToNum(sy_1997) - sh_2004))), ((V)(0D)), ((V)((ToNum(bl_2002) * fade_2003))), Get(ICON_45, "flower")));
}
h_2000 = ((V)(string.Concat(new string[] { ToStr(h_2000), "<ellipse cx=\"", ToStr(Call(r2_38, V.Undef, sx_1996)), "\" cy=\"", ToStr(Call(r2_38, V.Undef, Add(sy_1997, ((V)(0.4))))), "\" rx=\"6\" ry=\"1.6\" fill=\"#8a6a4a\" opacity=\"", ToStr(Call(r2_38, V.Undef, ((V)((0.5 * fade_2003))))), "\"/>" })));
}
ang_2005 = (Lt(tt_1992, a_1979) ? 0D : (Lt(tt_1992, p0_1980) ? (45D * ToNum(Call(ss_25, V.Undef, ((V)(((ToNum(tt_1992) - ToNum(a_1979)) / (ToNum(p0_1980) - ToNum(a_1979)))))))) : (Lt(tt_1992, p1_1981) ? (45D + (FdLibm.Sin((ToNum(tt_1992) / 200D)) * 5D)) : (45D * (1D - ToNum(Call(ss_25, V.Undef, ((V)(((ToNum(tt_1992) - ToNum(p1_1981)) / (ToNum(b_1982) - ToNum(p1_1981))))))))))));
vis_2006 = (1D - ToNum(Call(ss_25, V.Undef, ((V)(((ToNum(tt_1992) - ToNum(b_1982)) / 300D))))));
if ((vis_2006 > 0.02)) {
V p_2012 = default;
double an_2013 = 0;
double lx_2014 = 0;
double ly_2015 = 0;
V sp_2016 = default;
p_2012 = Get(W_1993, "pawR");
an_2013 = ((ang_2005 * System.Math.PI) / 180D);
lx_2014 = (12.4 * CK_1999);
ly_2015 = ((-1.2) * CK_1999);
sp_2016 = Arr(((V)((ToNum(Add(GetIdx(p_2012, 0D), ((V)((lx_2014 * FdLibm.Cos(an_2013)))))) - (ly_2015 * FdLibm.Sin(an_2013))))), Add(Add(Add(GetIdx(p_2012, 1D), ((V)(2D))), ((V)((lx_2014 * FdLibm.Sin(an_2013))))), ((V)((ly_2015 * FdLibm.Cos(an_2013))))));
if ((GtN(tt_1992, (ToNum(p0_1980) - 80D)) && Lt(tt_1992, Add(p1_1981, ((V)(80D)))))) {
{
double i_2017 = 0;
i_2017 = 0D;
while (true) {
if (!((i_2017 < 7D))) break;
double u_2019 = 0;
V x_2020 = default;
double y_2021 = 0;
u_2019 = (((ToNum(tt_1992) / 260D) + (i_2017 / 7D)) % 1D);
x_2020 = Call(lerp_99, V.Undef, GetIdx(sp_2016, 0D), sx_1996, ((V)(u_2019)));
y_2021 = ((ToNum(Call(lerp_99, V.Undef, GetIdx(sp_2016, 1D), ((V)((ToNum(sy_1997) - sh_2004))), ((V)(u_2019)))) - (FdLibm.Sin((System.Math.PI * u_2019)) * 2.6)) + ((u_2019 * u_2019) * 2D));
h_2000 = ((V)(string.Concat(new string[] { ToStr(h_2000), "<ellipse cx=\"", ToStr(Call(r2_38, V.Undef, x_2020)), "\" cy=\"", ToStr(Call(r2_38, V.Undef, ((V)(y_2021)))), "\" rx=\"0.9\" ry=\"1.3\" fill=\"#8fd3ff\" stroke=\"#5ab4f0\" stroke-width=\"0.2\" opacity=\"0.9\"/>" })));
i_2017++;
}
}
}
h_2000 = Add(Call(G_100, V.Undef, GetIdx(p_2012, 0D), Add(GetIdx(p_2012, 1D), ((V)(2D))), ((V)(ang_2005)), ((V)(CK_1999)), CAN_136, ((V)((vis_2006 * Max(0.35, ToNum(f0_1998)))))), h_2000);
}
return h_2000;
return default;
}, 2, "", true));
return st_1983;
return default;
}, 1, "waterMove", false);
roastProp_139 = Fn((V _self2022, int _argc2023, V st_2029, V _a2026, V _a2027, V _a2028, V[] _rest2024) => {
if (_self2022.IsNullish) _self2022 = GlobalV;
return Fn((V _self2022, int _argc2030, V I_2036, V tt_2037, V _a2034, V _a2035, V[] _rest2031) => {
V W_2038 = default;
double tl_2039 = 0;
V p_2040 = default;
V M_2041 = default;
double f0_2042 = 0;
double tst_2043 = 0;
V burnt_2044 = default;
V fire_2045 = default;
double gone_2046 = 0;
V eat_2047 = default;
double smk_2048 = 0;
V nw_2049 = default;
double d_2050 = 0;
double a0_2051 = 0;
double a1_2052 = 0;
V an_2053 = default;
V L_2054 = default;
V tip_2055 = default;
V h_2056 = default;
W_2038 = Get(I_2036, "W");
if ((!(Truthy(W_2038)) || !(Truthy(Call(okp_95, V.Undef, Get(W_2038, "pawR")))))) {
return ((V)(""));
}
tl_2039 = (ToNum(tt_2037) % ToNum(Get(st_2029, "loop")));
p_2040 = Get(W_2038, "pawR");
M_2041 = (Truthy(Call(okp_95, V.Undef, Get(W_2038, "mouth"))) ? Get(W_2038, "mouth") : Arr(((V)((ToNum(GetIdx(p_2040, 0D)) - 8D))), ((V)((ToNum(GetIdx(p_2040, 1D)) - 4D)))));
f0_2042 = Max(0.3, ToNum(Call(facing_87, V.Undef, I_2036)));
tst_2043 = 0D;
burnt_2044 = ((V)(0D));
fire_2045 = ((V)(0D));
gone_2046 = 0D;
eat_2047 = ((V)(0D));
smk_2048 = (-1D);
nw_2049 = ((V)(1D));
{
foreach (V _k2057 in Iterate(Get(st_2029, "beats"))) {
V n_2058 = default;
V a_2059 = default;
V b_2060 = default;
{ V _t2061 = ListOf(_k2057);
{ V _t2062 = GetIdx(_t2061, 0D);
n_2058 = _t2062; }
{ V _t2063 = GetIdx(_t2061, 1D);
a_2059 = _t2063; }
{ V _t2064 = GetIdx(_t2061, 2D);
b_2060 = _t2064; }
}
V u_2065 = default;
if (Lt(((V)(tl_2039)), a_2059)) {
break;
}
u_2065 = Call(cl_39, V.Undef, ((V)(((tl_2039 - ToNum(a_2059)) / Max(1D, (ToNum(b_2060) - ToNum(a_2059)))))), ((V)(0D)), ((V)(1D)));
if ((SEqS(n_2058, "hold") || SEqS(n_2058, "turn"))) {
tst_2043 = Min(1D, (tst_2043 + (0.5 * ToNum(u_2065))));
} else {
if (SEqS(n_2058, "fire")) {
fire_2045 = Call(ss_25, V.Undef, ((V)((ToNum(u_2065) / 0.15))));
burnt_2044 = u_2065;
} else {
if (SEqS(n_2058, "blow")) {
fire_2045 = ((V)((1D - ToNum(Call(ss_25, V.Undef, ((V)((((tl_2039 - ToNum(a_2059)) - 350D) / 250D))))))));
if (Gt(((V)(tl_2039)), Add(a_2059, ((V)(400D))))) {
smk_2048 = ((tl_2039 - ToNum(a_2059)) - 400D);
}
burnt_2044 = ((V)(1D));
} else {
if (SEqS(n_2058, "eat")) {
eat_2047 = Call(win_88, V.Undef, ((V)(tl_2039)), a_2059, b_2060, ((V)(380D)));
if (GtN(u_2065, 0.3)) {
gone_2046 = 1D;
}
} else {
if (SEqS(n_2058, "new")) {
nw_2049 = Call(ss_25, V.Undef, ((V)(((ToNum(u_2065) - 0.35) / 0.25))));
if (GtN(u_2065, 0.35)) {
tst_2043 = 0D;
burnt_2044 = ((V)(0D));
gone_2046 = 0D;
fire_2045 = ((V)(0D));
smk_2048 = (-1D);
}
}
}
}
}
}
}
}
d_2050 = Hypot((ToNum(GetIdx(M_2041, 0D)) - ToNum(GetIdx(p_2040, 0D))), (ToNum(GetIdx(M_2041, 1D)) - ToNum(GetIdx(p_2040, 1D))));
a0_2051 = (((-22D) * System.Math.PI) / 180D);
a1_2052 = FdLibm.Atan2((ToNum(GetIdx(M_2041, 1D)) - ToNum(GetIdx(p_2040, 1D))), (ToNum(GetIdx(M_2041, 0D)) - ToNum(GetIdx(p_2040, 0D))));
an_2053 = Call(lerp_99, V.Undef, ((V)(a0_2051)), ((V)(a1_2052)), eat_2047);
L_2054 = Call(lerp_99, V.Undef, ((V)(32D)), ((V)(Max(7D, d_2050))), eat_2047);
tip_2055 = Arr(Add(GetIdx(p_2040, 0D), ((V)((FdLibm.Cos(ToNum(an_2053)) * ToNum(L_2054))))), Add(GetIdx(p_2040, 1D), ((V)((FdLibm.Sin(ToNum(an_2053)) * ToNum(L_2054))))));
h_2056 = ((V)(string.Concat(new string[] { "<path d=\"M", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(p_2040, 0D)) - (FdLibm.Cos(ToNum(an_2053)) * 2D)))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(p_2040, 1D)) - (FdLibm.Sin(ToNum(an_2053)) * 2D)))))), "L", ToStr(Call(r2_38, V.Undef, GetIdx(tip_2055, 0D))), " ", ToStr(Call(r2_38, V.Undef, GetIdx(tip_2055, 1D))), "\" stroke=\"#9a6a3a\" stroke-width=\"1.4\" stroke-linecap=\"round\" opacity=\"", ToStr(Call(r2_38, V.Undef, ((V)(f0_2042)))), "\"/>" })));
if (!(NumTruthy(gone_2046))) {
V c0_2066 = default;
V c1_2067 = default;
V c2_2068 = default;
V mix_2069 = default;
V c_2070 = default;
V col_2071 = default;
double k_2072 = 0;
c0_2066 = Arr(((V)(246D)), ((V)(241D)), ((V)(230D)));
c1_2067 = Arr(((V)(224D)), ((V)(162D)), ((V)(74D)));
c2_2068 = Arr(((V)(70D)), ((V)(46D)), ((V)(34D)));
mix_2069 = Fn((V _self2022, int _argc2073, V x_2079, V y_2080, V u_2081, V _a2078, V[] _rest2074) => {
return Invoke(x_2079, "map", Fn((V _self2022, int _argc2082, V v_2088, V i_2089, V _a2086, V _a2087, V[] _rest2083) => {
return ((V)(Round(ToNum(Call(lerp_99, V.Undef, v_2088, GetK(y_2080, i_2089), u_2081)))));
}, 2, "", true));
}, 3, "", true);
c_2070 = (GtN(burnt_2044, 0D) ? Call(mix_2069, V.Undef, Call(mix_2069, V.Undef, c0_2066, c1_2067, ((V)(tst_2043))), c2_2068, Call(ss_25, V.Undef, ((V)((ToNum(burnt_2044) / 0.6))))) : Call(mix_2069, V.Undef, c0_2066, c1_2067, ((V)(tst_2043))));
col_2071 = ((V)(string.Concat("rgb(", ToStr(Invoke(c_2070, "join", ((V)(",")))), ")")));
k_2072 = ((0.4 + (0.6 * ToNum(nw_2049))) * 1.8);
h_2056 = Add(h_2056, Call(G_100, V.Undef, GetIdx(tip_2055, 0D), GetIdx(tip_2055, 1D), ((V)(((ToNum(an_2053) * 180D) / System.Math.PI))), ((V)(k_2072)), ((V)(string.Concat(new string[] { "<rect x=\"-0.6\" y=\"-2.2\" width=\"5.2\" height=\"4.4\" rx=\"1.8\" fill=\"", ToStr(col_2071), "\" stroke=\"", (GtN(burnt_2044, 0.3) ? "#2a1a10" : "#c9a46a"), "\" stroke-width=\"0.35\"/><ellipse cx=\"1.4\" cy=\"-1\" rx=\"1.4\" ry=\"0.6\" fill=\"#ffffff\" opacity=\"", ToStr(Call(r2_38, V.Undef, ((V)((0.6 * (1D - ToNum(burnt_2044))))))), "\"/>", (GtN(burnt_2044, 0.5) ? "<path d=\"M0.4 1.6Q2 0.4 3.8 1.4\" stroke=\"#ff8a2a\" stroke-width=\"0.4\" fill=\"none\" opacity=\"0.7\"/>" : "") }))), ((V)(f0_2042))));
if (GtN(fire_2045, 0.02)) {
h_2056 = Add(h_2056, Call(G_100, V.Undef, Add(GetIdx(tip_2055, 0D), ((V)(3D))), ((V)((ToNum(GetIdx(tip_2055, 1D)) - 6D))), ((V)((FdLibm.Sin((ToNum(tt_2037) / 80D)) * 6D))), ((V)((ToNum(fire_2045) * (2D + (FdLibm.Sin((ToNum(tt_2037) / 60D)) * 0.15))))), Get(ICON_45, "fire")));
}
if (((smk_2048 >= 0D) && (smk_2048 < 1800D))) {
{
double i_2090 = 0;
i_2090 = 0D;
while (true) {
if (!((i_2090 < 3D))) break;
V u_2092 = default;
u_2092 = Call(cl_39, V.Undef, ((V)(((smk_2048 - (i_2090 * 280D)) / 1300D))), ((V)(0D)), ((V)(1D)));
if ((GtN(u_2092, 0D) && LtN(u_2092, 1D))) {
h_2056 = Add(h_2056, Call(ci_43, V.Undef, Call(r2_38, V.Undef, Add(Add(GetIdx(tip_2055, 0D), ((V)(3D))), ((V)((FdLibm.Sin(((ToNum(u_2092) * 5D) + i_2090)) * 2.4))))), Call(r2_38, V.Undef, ((V)(((ToNum(GetIdx(tip_2055, 1D)) - 5D) - (ToNum(u_2092) * 18D))))), Call(r2_38, V.Undef, ((V)((2D + (ToNum(u_2092) * 3.6))))), ((V)(string.Concat("rgba(150,150,150,", ToStr(Call(r2_38, V.Undef, ((V)((0.55 * (1D - ToNum(u_2092))))))), ")")))));
}
i_2090++;
}
}
}
}
return h_2056;
return default;
}, 2, "", true);
return default;
}, 1, "roastProp", false);
bBuild_141 = Fn((V _self2093, int _argc2094, V key_2100, V X_2101, V _a2098, V _a2099, V[] _rest2095) => {
V P_2102 = default;
V nm_2103 = default;
V S_2104 = default;
V SB_2105 = default;
V BX_2106 = default;
V sig_2107 = default;
V md_2108 = default;
if (_self2093.IsNullish) _self2093 = GlobalV;
X_2101 = Call(o_10, V.Undef, (GetK(WX_29, key_2100) is var _t2109 && Truthy(_t2109) ? _t2109 : NewObj(0).V), (GetK(PLY_93, key_2100) is var _t2110 && Truthy(_t2110) ? _t2110 : NewObj(0).V), (X_2101 is var _t2111 && Truthy(_t2111) ? _t2111 : NewObj(0).V));
P_2102 = (GetK(PROF_35, key_2100) is var _t2112 && Truthy(_t2112) ? _t2112 : NewObj(0).V);
nm_2103 = Fn((V _self2093, int _argc2113, V n_2119, V _a2116, V _a2117, V _a2118, V[] _rest2114) => {
return (Truthy(key_2100) ? ((V)(string.Concat(ToStr(n_2119), "@", ToStr(key_2100)))) : n_2119);
}, 1, "", true);
S_2104 = NewObj(0).V;
SB_2105 = Call(o_10, V.Undef, SIT0_17, (Get(P_2102, "pose") is var _t2120 && Truthy(_t2120) ? _t2120 : NewObj(0).V));
BX_2106 = (GetK(BED_54, key_2100) is var _t2121 && Truthy(_t2121) ? _t2121 : NewObj(0).V);
sig_2107 = ((Get(X_2101, "b") is var _t2122 && Truthy(_t2122) ? _t2122 : Get(X_2101, "p")) is var _t2131 && Truthy(_t2131) ? _t2131 : Invoke((Get(P_2102, "f") is var _t2130 && Truthy(_t2130) ? _t2130 : Arr()), "find", Fn((V _self2093, int _argc2123, V f_2129, V _a2126, V _a2127, V _a2128, V[] _rest2124) => {
return (string.Equals(Typeof(f_2129), "function") ? V.True : V.False);
}, 1, "", true)));
md_2108 = ((V)((Truthy(GetK(LAP_27, key_2100)) ? "lap" : (Truthy(GetK(TWO_26, key_2100)) ? "two" : ""))));
Set(X_2101, "_dm", md_2108);
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("sinkwash"))), Call(bHold_101, V.Undef, Call(o_10, V.Undef, SK0_102, (Get(X_2101, "skp") is var _t2132 && Truthy(_t2132) ? _t2132 : NewObj(0).V)), (Get(X_2101, "skOrd") is var _t2133 && Truthy(_t2133) ? _t2133 : Arr(((V)("scrub")), ((V)("rinse")), ((V)("splash")), ((V)("sig")), ((V)("shake")), ((V)("mirror")), ((V)("scrub")), ((V)("dry")))), SKB_103, X_2101, sig_2107, Arr(((V)(400D)), ((V)(600D)), ((V)(500D)), ((V)(700D)))));
{
V st_2134 = default;
st_2134 = Call(bHold_101, V.Undef, Call(o_10, V.Undef, BR0_104, (Get(X_2101, "brp") is var _t2135 && Truthy(_t2135) ? _t2135 : NewObj(0).V)), (Get(X_2101, "brOrd") is var _t2136 && Truthy(_t2136) ? _t2136 : Arr(((V)("brush")), ((V)("side")), ((V)("brush")), ((V)("gargle")), ((V)("spit")), ((V)("grin")), ((V)("sig")))), BRB_105, X_2101, sig_2107, Arr(((V)(300D)), ((V)(500D)), ((V)(400D)), ((V)(600D))));
Set(st_2134, "prop", Call(brushProp_106, V.Undef, st_2134, (Get(X_2101, "tb") is var _t2137 && Truthy(_t2137) ? _t2137 : ((V)("#5fb8e8")))));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("brush"))), st_2134);
}
{
V DN_2138 = default;
V st_2139 = default;
V di_2140 = default;
DN_2138 = Call(o_10, V.Undef, SB_2105, Call(both_13, V.Undef, ((V)(8D)), ((V)((-3D)))), NewObj(6).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("pitch", ((V)((ToNum((Get(SB_2105, "pitch") is var _t2141 && Truthy(_t2141) ? _t2141 : ((V)(0D)))) - 0.06)))).Put("ly", ((V)(0.5))).Put("smile", ((V)(0.6))).Put("puff", ((V)(0D))).V, (Get(X_2101, "dnp") is var _t2142 && Truthy(_t2142) ? _t2142 : NewObj(0).V));
st_2139 = Call(bHold_101, V.Undef, DN_2138, (Get(X_2101, "dnOrd") is var _t2143 && Truthy(_t2143) ? _t2143 : (Truthy(md_2108) ? Arr(((V)("bite")), ((V)("chew")), ((V)("bite")), ((V)("crumbs")), ((V)("bite")), ((V)("sig")), ((V)("yum"))) : Arr(((V)("bite")), ((V)("chew")), ((V)("bite")), ((V)("sip")), ((V)("crumbs")), ((V)("bite")), ((V)("lick")), ((V)("sig")), ((V)("yum"))))), DNB_107, X_2101, sig_2107, Arr(((V)(700D)), ((V)(1100D)), ((V)(900D)), ((V)(1300D))));
Set(st_2139, "prop", Call(dineProp_108, V.Undef, st_2139, (Get(X_2101, "sn") is var _t2144 && Truthy(_t2144) ? _t2144 : ((V)("cookie"))), md_2108));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("dine"))), st_2139);
di_2140 = Call(sitdown_20, V.Undef, DN_2138, P_2102);
Set(di_2140, "next", ((V)("dine")));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("dinein"))), di_2140);
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("dineout"))), Call(standup_23, V.Undef, DN_2138, P_2102));
}
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("surf"))), Call(bHold_101, V.Undef, Call(o_10, V.Undef, SF0_109, (Get(X_2101, "sfp") is var _t2145 && Truthy(_t2145) ? _t2145 : NewObj(0).V)), (Get(X_2101, "sfOrd") is var _t2146 && Truthy(_t2146) ? _t2146 : Arr(((V)("wobble")), ((V)("carve")), ((V)("bump")), ((V)("hang10")), ((V)("sig")), ((V)("crouch")), ((V)("wipe")))), SFB_110, X_2101, sig_2107, Arr(((V)(500D)), ((V)(800D)), ((V)(600D)), ((V)(900D))), NewObj(1).Put("breathe", ((V)(0.3))).V));
{
V st_2147 = default;
st_2147 = Call(bHold_101, V.Undef, Call(o_10, V.Undef, FS0_111, (Get(X_2101, "fsp") is var _t2148 && Truthy(_t2148) ? _t2148 : NewObj(0).V)), (Get(X_2101, "fsOrd") is var _t2149 && Truthy(_t2149) ? _t2149 : Arr(((V)("cast")), ((V)("look")), ((V)("nibble")), ((V)("hum")), ((V)("nibble")), ((V)("reel")), ((V)("catch")), ((V)("sig")))), FB_112, X_2101, sig_2107, Arr(((V)(600D)), ((V)(900D)), ((V)(700D)), ((V)(1000D))));
Set(st_2147, "prop", Call(fishProp_113, V.Undef, st_2147, (Get(X_2101, "fc") is var _t2150 && Truthy(_t2150) ? _t2150 : ((V)("fish")))));
Set(st_2147, "catchEnd", GetIdx((GetIdx((Get(Get(st_2147, "rec"), "catch") is var _t2151 && Truthy(_t2151) ? _t2151 : Arr()), 0D) is var _t2152 && Truthy(_t2152) ? _t2152 : Arr(((V)(0D)), Get(st_2147, "loop"))), 1D));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("fishing"))), st_2147);
}
{
V fl_2153 = default;
V sea_2154 = default;
V adj_2155 = default;
V SN_2156 = default;
V a_2157 = default;
V st_2158 = default;
V b_2159 = default;
fl_2153 = (SEqS(Get(P_2102, "dn"), "float") ? V.True : V.False);
sea_2154 = ((SEqS(Get(P_2102, "dn"), "flop") && SEqN(Get((Get(P_2102, "pose") is var _t2160 && Truthy(_t2160) ? _t2160 : NewObj(0).V), "sit"), 0D)) ? V.True : V.False);
adj_2155 = (Truthy(fl_2153) ? NewObj(2).Put("sit", ((V)(0D))).Put("lift", ((V)(1.2))).V : (Truthy(sea_2154) ? NewObj(4).Put("sit", ((V)(0D))).Put("pitch", ((V)((-0.1)))).Put("htilt", ((V)(4D))).Put("lift", ((V)((-1.6)))).V : NewObj(0).V));
SN_2156 = Call(o_10, V.Undef, SB_2105, LIE0_40, adj_2155, (Get(BX_2106, "lp") is var _t2161 && Truthy(_t2161) ? _t2161 : NewObj(0).V), (Get(BX_2106, "np") is var _t2162 && Truthy(_t2162) ? _t2162 : NewObj(0).V), NewObj(11).Put("qk", ((V)(0D))).Put("zz", ((V)(0D))).Put("drm", ((V)(0D))).Put("close", ((V)(0.3))).Put("mw", ((V)(1D))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.3))).Put("open", ((V)(0D))).Put("shd", ((V)(1D))).Put("shu", ((V)(0D))).Put("puff", ((V)(0D))).V, (Get(X_2101, "snp") is var _t2163 && Truthy(_t2163) ? _t2163 : NewObj(0).V));
a_2157 = Call(sunIn_117, V.Undef, SB_2105, SN_2156, P_2102);
Set(a_2157, "prop", Call(sunProp_116, V.Undef, V.Null));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("sunin"))), a_2157);
st_2158 = Call(bHold_101, V.Undef, SN_2156, (Get(X_2101, "snOrd") is var _t2164 && Truthy(_t2164) ? _t2164 : Arr(((V)("sigh")), ((V)("toes")), ((V)("sip")), ((V)("sig")), ((V)("lotion")), ((V)("peek")), ((V)("doze")))), SUNB_114, X_2101, (Get(X_2101, "ss") is var _t2165 && Truthy(_t2165) ? _t2165 : Get(BX_2106, "s")), Arr(((V)(1400D)), ((V)(2000D)), ((V)(1700D)), ((V)(2300D))), NewObj(2).Put("breathe", ((V)(0.6))).Put("noBlink", (false ? V.True : V.False)).V);
Set(st_2158, "prop", Call(sunProp_116, V.Undef, st_2158));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("sun"))), st_2158);
b_2159 = Call(sunOut_118, V.Undef, SN_2156, SB_2105, P_2102);
Set(b_2159, "prop", Call(sunProp_116, V.Undef, V.Null));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("sunout"))), b_2159);
}
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("slide"))), Call(slideMove_119, V.Undef, P_2102, X_2101));
{
V TB_2166 = default;
TB_2166 = Call(o_10, V.Undef, TB0_120, (Get(X_2101, "tbp") is var _t2167 && Truthy(_t2167) ? _t2167 : NewObj(0).V));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("bouncein"))), Call(bounceIn_122, V.Undef, TB_2166, P_2102));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("bounce"))), Call(bHold_101, V.Undef, TB_2166, (Get(X_2101, "tbOrd") is var _t2168 && Truthy(_t2168) ? _t2168 : Arr(((V)("hop")), ((V)("jumps")), ((V)("star")), ((V)("hop")), ((V)("tuck")), ((V)("seat")), ((V)("hop")), ((V)("spin")), ((V)("sig")), ((V)("jumps")))), TBB_121, X_2101, sig_2107, Arr(((V)(150D)), ((V)(250D)), ((V)(200D))), NewObj(1).Put("breathe", ((V)(0.2))).V));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("bounceout"))), Call(bounceOut_123, V.Undef, TB_2166, P_2102));
}
{
V DG_2169 = default;
V din_2170 = default;
DG_2169 = Call(o_10, V.Undef, SB_2105, Call(hand_12, V.Undef, ((V)(1D)), ((V)(10D)), ((V)(3D))), Call(hand_12, V.Undef, ((V)((-1D))), ((V)(8D)), ((V)(4D))), NewObj(6).Put("armL", ((V)(20D))).Put("armR", ((V)(26D))).Put("pitch", ((V)((ToNum((Get(SB_2105, "pitch") is var _t2171 && Truthy(_t2171) ? _t2171 : ((V)(0D)))) - 0.16)))).Put("ly", ((V)(0.6))).Put("smile", ((V)(0.7))).Put("hap", ((V)(0.3))).V, (Get(X_2101, "dgp") is var _t2172 && Truthy(_t2172) ? _t2172 : NewObj(0).V));
din_2170 = Fn((V _self2093, int _argc2173, V nx_2179, V _a2176, V _a2177, V _a2178, V[] _rest2174) => {
V t_2180 = default;
V v_2181 = default;
t_2180 = Call(TL_11, V.Undef, REST_9);
Invoke(t_2180, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0.12))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("io")));
v_2181 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, DG_2169), "forEach", Fn((V _self2093, int _argc2182, V p_2188, V _a2185, V _a2186, V _a2187, V[] _rest2183) => {
return SetK(v_2181, p_2188, GetK(DG_2169, p_2188));
}, 1, "", true));
Invoke(Invoke(Invoke(t_2180, "to", ((V)(320D)), Call(o_10, V.Undef, v_2181, NewObj(1).Put("sq", Add(Get(DG_2169, "sq"), ((V)(0.1)))).V), ((V)("i"))), "to", ((V)(180D)), NewObj(1).Put("sq", ((V)((ToNum(Get(DG_2169, "sq")) - 0.02)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(DG_2169, "sq")).V, ((V)("io")));
return Invoke(t_2180, "out", NewObj(2).Put("next", nx_2179).Put("blend", ((V)(200D))).V);
return default;
}, 1, "", true);
{
V st_2189 = default;
st_2189 = Call(bHold_101, V.Undef, DG_2169, (Get(X_2101, "dgOrd") is var _t2190 && Truthy(_t2190) ? _t2190 : Arr(((V)("scoop")), ((V)("pile")), ((V)("bucket")), ((V)("pat")), ((V)("scoop")), ((V)("bucket")), ((V)("flag")), ((V)("admire")), ((V)("sig")), ((V)("crumble")))), DGB_124, X_2101, sig_2107, Arr(((V)(400D)), ((V)(600D)), ((V)(500D)), ((V)(700D))));
Set(st_2189, "prop", Call(digProp_130, V.Undef, st_2189));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("dig"))), st_2189);
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("digin"))), Call(din_2170, V.Undef, ((V)("dig"))));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("digout"))), Call(standup_23, V.Undef, DG_2169, P_2102));
}
{
V st_2191 = default;
st_2191 = Call(bHold_101, V.Undef, DG_2169, (Get(X_2101, "blOrd") is var _t2192 && Truthy(_t2192) ? _t2192 : Arr(((V)("stack")), ((V)("stack")), ((V)("stack")), ((V)("wobble")), ((V)("stack")), ((V)("stack")), ((V)("topple")), ((V)("giggle")), ((V)("sig")), ((V)("tidy")))), BLB_134, X_2101, sig_2107, Arr(((V)(500D)), ((V)(700D)), ((V)(600D))));
Set(st_2191, "prop", Call(blocksProp_135, V.Undef, st_2191));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("blocks"))), st_2191);
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("blocksin"))), Call(din_2170, V.Undef, ((V)("blocks"))));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("blocksout"))), Call(standup_23, V.Undef, DG_2169, P_2102));
}
}
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("water"))), Call(waterMove_137, V.Undef, X_2101));
{
V RS_2193 = default;
V st_2194 = default;
V ri_2195 = default;
RS_2193 = Call(o_10, V.Undef, SB_2105, Call(hand_12, V.Undef, ((V)(1D)), ((V)(1D)), ((V)((-2D)))), Call(hand_12, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)(3D))), NewObj(7).Put("armR", ((V)(42D))).Put("armL", ((V)(16D))).Put("pitch", ((V)((ToNum((Get(SB_2105, "pitch") is var _t2196 && Truthy(_t2196) ? _t2196 : ((V)(0D)))) - 0.02)))).Put("ly", ((V)(0.2))).Put("lx", ((V)(0.5))).Put("smile", ((V)(0.7))).Put("puff", ((V)(0D))).V, (Get(X_2101, "rsp") is var _t2197 && Truthy(_t2197) ? _t2197 : NewObj(0).V));
st_2194 = Call(bHold_101, V.Undef, RS_2193, (Get(X_2101, "rsOrd") is var _t2198 && Truthy(_t2198) ? _t2198 : Arr(((V)("hold")), ((V)("turn")), ((V)("hold")), ((V)("eat")), ((V)("new")), ((V)("hold")), ((V)("turn")), ((V)("fire")), ((V)("blow")), ((V)("eat")), ((V)("new")), ((V)("sig")))), RSB_138, X_2101, sig_2107, Arr(((V)(600D)), ((V)(900D)), ((V)(700D)), ((V)(1000D))));
Set(st_2194, "prop", Call(roastProp_139, V.Undef, st_2194));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("roast"))), st_2194);
ri_2195 = Call(sitdown_20, V.Undef, RS_2193, P_2102);
Set(ri_2195, "next", ((V)("roast")));
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("roastin"))), ri_2195);
SetK(S_2104, Call(nm_2103, V.Undef, ((V)("roastout"))), Call(standup_23, V.Undef, RS_2193, P_2102));
}
Invoke(R_8, "add", S_2104);
Set(R_8, "HS", Object_assign((Get(R_8, "HS") is var _t2199 && Truthy(_t2199) ? _t2199 : NewObj(0).V), S_2104));
if (Truthy(key_2100)) {
SetK(BB_140, key_2100, X_2101);
}
return default;
}, 2, "bBuild", false);
R_8 = Get(G("window"), "RiveRig");
if (((!(Truthy(R_8)) || !(Truthy(Get(R_8, "REST")))) || !(Truthy(Get(R_8, "movesV"))))) {
Call(G("setTimeout"), V.Undef, boot_2200.v, ((V)(30D)));
return default;
}
if (Truthy(Get(R_8, "houseV"))) {
return default;
}
Set(R_8, "houseV", ((V)(1D)));
REST_9 = Get(R_8, "REST");
o_10 = Fn((V _self1, int _argc2201, V _a2203, V _a2204, V _a2205, V _a2206, V[] _rest2202) => {
V a_2207 = default;
a_2207 = RestArgs(0, _argc2201, _a2203, _a2204, _a2205, _a2206, _rest2202);
return InvokeSpread(G("Object"), "assign", new ArrBuilder().Add(NewObj(0).V).Spread(a_2207).V);
}, 1, "", true);
hand_12 = Fn((V _self1, int _argc2208, V s_2214, V inX_2215, V y_2216, V _a2213, V[] _rest2209) => {
return (LtN(s_2214, 0D) ? NewObj(2).Put("hLx", inX_2215).Put("hLy", y_2216).V : NewObj(2).Put("hRx", ((V)((-ToNum(inX_2215))))).Put("hRy", y_2216).V);
}, 3, "", true);
both_13 = Fn((V _self1, int _argc2217, V inX_2223, V y_2224, V _a2221, V _a2222, V[] _rest2218) => {
return Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), inX_2223, y_2224), Call(hand_12, V.Undef, ((V)(1D)), inX_2223, y_2224));
}, 2, "", true);
SIDE_14 = Fn((V _self1, int _argc2225, V s_2231, V _a2228, V _a2229, V _a2230, V[] _rest2226) => {
return (LtN(s_2231, 0D) ? NewObj(6).Put("arm", ((V)("armL"))).Put("hx", ((V)("hLx"))).Put("hy", ((V)("hLy"))).Put("ear", ((V)("earL"))).Put("foot", ((V)("footL"))).Put("wink", ((V)("winkL"))).V : NewObj(6).Put("arm", ((V)("armR"))).Put("hx", ((V)("hRx"))).Put("hy", ((V)("hRy"))).Put("ear", ((V)("earR"))).Put("foot", ((V)("footR"))).Put("wink", ((V)("winkR"))).V);
}, 1, "", true);
keysOf_15 = Fn((V _self1, int _argc2232, V v_2238, V _a2235, V _a2236, V _a2237, V[] _rest2233) => {
return Object_keys(v_2238);
}, 1, "", true);
BEAT_16 = NewObj(17).Put("swing", Fn((V _self2239, int _argc2240, V t_2246, V _a2243, V _a2244, V _a2245, V[] _rest2241) => {
V B_2247 = default;
V a_2248 = default;
if (_self2239.IsNullish) _self2239 = GlobalV;
B_2247 = Get(t_2246, "B");
a_2248 = (Get(B_2247, "footL") is var _t2249 && Truthy(_t2249) ? _t2249 : ((V)(0D)));
Invoke(t_2246, "osc", ((V)(2600D)), ((V)(4D)), NewObj(3).Put("footL", Add(a_2248, ((V)(1.8)))).Put("footR", ((V)((ToNum(a_2248) - 0.6)))).Put("lean", ((V)(0.5))).V, NewObj(3).Put("footL", ((V)((ToNum(a_2248) - 0.6)))).Put("footR", Add(a_2248, ((V)(1.8)))).Put("lean", ((V)((-0.5)))).V, ((V)("s")));
return Invoke(t_2246, "back", ((V)(380D)), Arr(((V)("footL")), ((V)("footR")), ((V)("lean"))));
return default;
}, 1, "swing", false)).Put("look", Fn((V _self2250, int _argc2251, V t_2257, V _a2254, V _a2255, V _a2256, V[] _rest2252) => {
if (_self2250.IsNullish) _self2250 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2257, "e", ((V)("blink"))), "to", ((V)(420D)), NewObj(3).Put("lx", ((V)((-0.9)))).Put("turn", ((V)((-0.22)))).Put("htilt", ((V)((-4D)))).V, ((V)("io"))), "wait", ((V)(1000D))), "to", ((V)(560D)), NewObj(3).Put("lx", ((V)(0.9))).Put("turn", ((V)(0.22))).Put("htilt", ((V)(4D))).V, ((V)("io"))), "wait", ((V)(1000D)));
return Invoke(t_2257, "back", ((V)(480D)), Arr(((V)("lx")), ((V)("turn")), ((V)("htilt"))));
return default;
}, 1, "look", false)).Put("pat", Fn((V _self2258, int _argc2259, V t_2265, V s_2266, V _a2263, V _a2264, V[] _rest2260) => {
V K_2267 = default;
V B_2268 = default;
if (_self2258.IsNullish) _self2258 = GlobalV;
s_2266 = (s_2266 is var _t2269 && Truthy(_t2269) ? _t2269 : ((V)(1D)));
K_2267 = Call(SIDE_14, V.Undef, s_2266);
B_2268 = Get(t_2265, "B");
Invoke(t_2265, "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, s_2266, ((V)((-11D))), ((V)(9D))), NewObj(4).PutK(Get(K_2267, "arm"), ((V)(18D))).Put("turn", ((V)((ToNum(s_2266) * 0.12)))).Put("lx", ((V)((ToNum(s_2266) * 0.6)))).Put("ly", ((V)(0.4))).V), ((V)("io")));
Invoke(t_2265, "osc", ((V)(1200D)), ((V)(3D)), NewObj(2).PutK(Get(K_2267, "hy"), ((V)(11D))).Put("sq", Add((Get(B_2268, "sq") is var _t2270 && Truthy(_t2270) ? _t2270 : ((V)(0D))), ((V)(0.012)))).V, NewObj(2).PutK(Get(K_2267, "hy"), ((V)(7D))).Put("sq", (Get(B_2268, "sq") is var _t2271 && Truthy(_t2271) ? _t2271 : ((V)(0D)))).V, ((V)("o")));
return Invoke(t_2265, "back", ((V)(420D)), Arr(Get(K_2267, "hx"), Get(K_2267, "hy"), Get(K_2267, "arm"), ((V)("turn")), ((V)("lx")), ((V)("ly")), ((V)("sq"))));
return default;
}, 2, "pat", false)).Put("yawn", Fn((V _self2272, int _argc2273, V t_2279, V _a2276, V _a2277, V _a2278, V[] _rest2274) => {
V B_2280 = default;
if (_self2272.IsNullish) _self2272 = GlobalV;
B_2280 = Get(t_2279, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_2279, "to", ((V)(320D)), NewObj(2).Put("sq", Add((Get(B_2280, "sq") is var _t2288 && Truthy(_t2288) ? _t2288 : ((V)(0D))), ((V)(0.03)))).Put("close", ((V)(0.35))).V), "to", ((V)(620D)), NewObj(10).Put("sq", ((V)((ToNum((Get(B_2280, "sq") is var _t2287 && Truthy(_t2287) ? _t2287 : ((V)(0D)))) - 0.06)))).Put("pitch", ((V)(0.4))).Put("open", ((V)(0.9))).Put("mw", ((V)(0.8))).Put("close", ((V)(0.85))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("hLy", ((V)((-3D)))).Put("hRy", ((V)((-3D)))).Put("tongue", ((V)(0.2))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(1.4))).V, NewObj(1).Put("tilt", ((V)((-1.4)))).V, ((V)("s"))), "to", ((V)(520D)), NewObj(11).Put("sq", (Get(B_2280, "sq") is var _t2281 && Truthy(_t2281) ? _t2281 : ((V)(0D)))).Put("pitch", (Get(B_2280, "pitch") is var _t2282 && Truthy(_t2282) ? _t2282 : ((V)(0D)))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("close", ((V)(0.3))).Put("armL", (Get(B_2280, "armL") is var _t2283 && Truthy(_t2283) ? _t2283 : ((V)(0D)))).Put("armR", (Get(B_2280, "armR") is var _t2284 && Truthy(_t2284) ? _t2284 : ((V)(0D)))).Put("hLy", (Get(B_2280, "hLy") is var _t2285 && Truthy(_t2285) ? _t2285 : ((V)(0D)))).Put("hRy", (Get(B_2280, "hRy") is var _t2286 && Truthy(_t2286) ? _t2286 : ((V)(0D)))).Put("tongue", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink2")));
return Invoke(t_2279, "back", ((V)(300D)), Arr(((V)("close"))));
return default;
}, 1, "yawn", false)).Put("kick", Fn((V _self2289, int _argc2290, V t_2296, V _a2293, V _a2294, V _a2295, V[] _rest2291) => {
V a_2297 = default;
if (_self2289.IsNullish) _self2289 = GlobalV;
a_2297 = (Get(Get(t_2296, "B"), "footL") is var _t2298 && Truthy(_t2298) ? _t2298 : ((V)(0D)));
Invoke(Invoke(t_2296, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(1100D)), ((V)(3D)), NewObj(3).Put("footL", Add(a_2297, ((V)(3D)))).Put("footR", Add(a_2297, ((V)(3D)))).Put("sq", ((V)((ToNum((Get(Get(t_2296, "B"), "sq") is var _t2299 && Truthy(_t2299) ? _t2299 : ((V)(0D)))) - 0.02)))).V, NewObj(3).Put("footL", a_2297).Put("footR", a_2297).Put("sq", (Get(Get(t_2296, "B"), "sq") is var _t2300 && Truthy(_t2300) ? _t2300 : ((V)(0D)))).V, ((V)("o")));
return Invoke(t_2296, "back", ((V)(360D)), Arr(((V)("hap")), ((V)("smile")), ((V)("footL")), ((V)("footR")), ((V)("sq"))));
return default;
}, 1, "kick", false)).Put("wiggle", Fn((V _self2301, int _argc2302, V t_2308, V _a2305, V _a2306, V _a2307, V[] _rest2303) => {
if (_self2301.IsNullish) _self2301 = GlobalV;
Invoke(Invoke(t_2308, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.6))).Put("smile", ((V)(0.8))).V), "osc", ((V)(1500D)), ((V)(3D)), NewObj(2).Put("x", ((V)(1.2))).Put("tilt", ((V)(2.4))).V, NewObj(2).Put("x", ((V)((-1.2)))).Put("tilt", ((V)((-2.4)))).V, ((V)("s")));
return Invoke(t_2308, "back", ((V)(360D)), Arr(((V)("x")), ((V)("tilt")), ((V)("hap")), ((V)("smile"))));
return default;
}, 1, "wiggle", false)).Put("hum", Fn((V _self2309, int _argc2310, V t_2316, V _a2313, V _a2314, V _a2315, V[] _rest2311) => {
if (_self2309.IsNullish) _self2309 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2316, "to", ((V)(260D)), NewObj(3).Put("smile", ((V)(0.9))).Put("close", ((V)(0.5))).Put("hap", ((V)(0.5))).V), "fx", ((V)("note")), ((V)("head"))), "osc", ((V)(2400D)), ((V)(4D)), NewObj(2).Put("htilt", ((V)(6D))).Put("lean", ((V)(0.6))).V, NewObj(2).Put("htilt", ((V)((-6D)))).Put("lean", ((V)((-0.6)))).V, ((V)("s"))), "fx", ((V)("note")), ((V)("head")));
return Invoke(t_2316, "back", ((V)(400D)), Arr(((V)("smile")), ((V)("close")), ((V)("hap")), ((V)("htilt")), ((V)("lean"))));
return default;
}, 1, "hum", false)).Put("ears", Fn((V _self2317, int _argc2318, V t_2324, V _a2321, V _a2322, V _a2323, V[] _rest2319) => {
if (_self2317.IsNullish) _self2317 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2324, "to", ((V)(90D)), NewObj(1).Put("earR", ((V)((-10D)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("earR", ((V)(4D))).V), "to", ((V)(140D)), NewObj(1).Put("earR", ((V)(0D))).V), "wait", ((V)(500D))), "to", ((V)(90D)), NewObj(1).Put("earL", ((V)((-10D)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("earL", ((V)(4D))).V);
return Invoke(t_2324, "back", ((V)(160D)), Arr(((V)("earL")), ((V)("earR"))));
return default;
}, 1, "ears", false)).Put("wag", Fn((V _self2325, int _argc2326, V t_2332, V _a2329, V _a2330, V _a2331, V[] _rest2327) => {
if (_self2325.IsNullish) _self2325 = GlobalV;
Invoke(Invoke(t_2332, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.5))).Put("smile", ((V)(0.7))).V), "osc", ((V)(1800D)), ((V)(5D)), NewObj(1).Put("wag", ((V)(20D))).V, NewObj(1).Put("wag", ((V)((-20D)))).V, ((V)("io")));
return Invoke(t_2332, "back", ((V)(300D)), Arr(((V)("wag")), ((V)("hap")), ((V)("smile"))));
return default;
}, 1, "wag", false)).Put("giggle", Fn((V _self2333, int _argc2334, V t_2340, V s_2341, V _a2338, V _a2339, V[] _rest2335) => {
V K_2342 = default;
if (_self2333.IsNullish) _self2333 = GlobalV;
s_2341 = (s_2341 is var _t2343 && Truthy(_t2343) ? _t2343 : ((V)(1D)));
K_2342 = Call(SIDE_14, V.Undef, s_2341);
Invoke(Invoke(t_2340, "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, s_2341, ((V)(9D)), ((V)((-12D)))), NewObj(6).PutK(Get(K_2342, "arm"), ((V)(30D))).Put("blush", ((V)(0.8))).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).Put("htilt", ((V)((ToNum(s_2341) * 4D)))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("sq", Add((Get(Get(t_2340, "B"), "sq") is var _t2344 && Truthy(_t2344) ? _t2344 : ((V)(0D))), ((V)(0.025)))).V, NewObj(1).Put("sq", (Get(Get(t_2340, "B"), "sq") is var _t2345 && Truthy(_t2345) ? _t2345 : ((V)(0D)))).V, ((V)("o")));
return Invoke(t_2340, "back", ((V)(420D)), Arr(Get(K_2342, "hx"), Get(K_2342, "hy"), Get(K_2342, "arm"), ((V)("blush")), ((V)("hap")), ((V)("sqz")), ((V)("smile")), ((V)("htilt")), ((V)("sq"))));
return default;
}, 2, "giggle", false)).Put("bounce", Fn((V _self2346, int _argc2347, V t_2353, V _a2350, V _a2351, V _a2352, V[] _rest2348) => {
V L_2354 = default;
V Q_2355 = default;
if (_self2346.IsNullish) _self2346 = GlobalV;
L_2354 = (Get(Get(t_2353, "B"), "lift") is var _t2356 && Truthy(_t2356) ? _t2356 : ((V)(0D)));
Q_2355 = (Get(Get(t_2353, "B"), "sq") is var _t2357 && Truthy(_t2357) ? _t2357 : ((V)(0D)));
Invoke(t_2353, "to", ((V)(180D)), NewObj(3).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
{
double i_2358 = 0;
i_2358 = 0D;
while (true) {
if (!((i_2358 < 3D))) break;
Invoke(Invoke(Invoke(t_2353, "to", ((V)(130D)), NewObj(2).Put("sq", Add(Q_2355, ((V)(0.08)))).Put("lift", L_2354).V, ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)((ToNum(Q_2355) - 0.05)))).Put("lift", Add(L_2354, ((V)(2.6)))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(2).Put("sq", Q_2355).Put("lift", L_2354).V, ((V)("i")));
i_2358++;
}
}
return Invoke(t_2353, "back", ((V)(300D)), Arr(((V)("hap")), ((V)("smile")), ((V)("open")), ((V)("sq")), ((V)("lift"))));
return default;
}, 1, "bounce", false)).Put("wave", Fn((V _self2360, int _argc2361, V t_2367, V s_2368, V _a2365, V _a2366, V[] _rest2362) => {
V K_2369 = default;
if (_self2360.IsNullish) _self2360 = GlobalV;
s_2368 = (s_2368 is var _t2370 && Truthy(_t2370) ? _t2370 : ((V)(1D)));
K_2369 = Call(SIDE_14, V.Undef, s_2368);
Invoke(Invoke(t_2367, "to", ((V)(380D)), NewObj(6).PutK(Get(K_2369, "arm"), ((V)(145D))).PutK(Get(K_2369, "hy"), ((V)((-3D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("htilt", ((V)((ToNum(s_2368) * 4D)))).V, ((V)("o"))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).PutK(Get(K_2369, "arm"), ((V)(118D))).V, NewObj(1).PutK(Get(K_2369, "arm"), ((V)(160D))).V, ((V)("io")));
return Invoke(t_2367, "back", ((V)(420D)), Arr(Get(K_2369, "arm"), Get(K_2369, "hy"), ((V)("hap")), ((V)("smile")), ((V)("open")), ((V)("htilt"))));
return default;
}, 2, "wave", false)).Put("nod", Fn((V _self2371, int _argc2372, V t_2378, V _a2375, V _a2376, V _a2377, V[] _rest2373) => {
if (_self2371.IsNullish) _self2371 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2378, "to", ((V)(600D)), NewObj(2).Put("close", ((V)(0.75))).Put("pitch", ((V)((-0.18)))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(140D)), NewObj(3).Put("pitch", ((V)(0.05))).Put("close", ((V)(0D))).Put("wide", ((V)(0.5))).V, ((V)("o"))), "e", ((V)("blink2")));
return Invoke(t_2378, "back", ((V)(380D)), Arr(((V)("close")), ((V)("pitch")), ((V)("wide"))));
return default;
}, 1, "nod", false)).Put("stretch", Fn((V _self2379, int _argc2380, V t_2386, V _a2383, V _a2384, V _a2385, V[] _rest2381) => {
V B_2387 = default;
if (_self2379.IsNullish) _self2379 = GlobalV;
B_2387 = Get(t_2386, "B");
Invoke(Invoke(Invoke(t_2386, "to", ((V)(700D)), NewObj(10).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).Put("hLy", ((V)((-5D)))).Put("hRy", ((V)((-5D)))).Put("sq", ((V)((ToNum((Get(B_2387, "sq") is var _t2388 && Truthy(_t2388) ? _t2388 : ((V)(0D)))) - 0.09)))).Put("close", ((V)(0.9))).Put("open", ((V)(0.45))).Put("pitch", ((V)(0.35))).Put("footL", Add((Get(B_2387, "footL") is var _t2389 && Truthy(_t2389) ? _t2389 : ((V)(0D))), ((V)(2D)))).Put("footR", Add((Get(B_2387, "footR") is var _t2390 && Truthy(_t2390) ? _t2390 : ((V)(0D))), ((V)(2D)))).V, ((V)("io"))), "wait", ((V)(500D))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(1.2))).V, NewObj(1).Put("tilt", ((V)((-1.2)))).V, ((V)("s")));
return Invoke(t_2386, "back", ((V)(650D)), Arr(((V)("armL")), ((V)("armR")), ((V)("hLy")), ((V)("hRy")), ((V)("sq")), ((V)("close")), ((V)("open")), ((V)("pitch")), ((V)("footL")), ((V)("footR")), ((V)("tilt"))));
return default;
}, 1, "stretch", false)).Put("sigh", Fn((V _self2391, int _argc2392, V t_2398, V _a2395, V _a2396, V _a2397, V[] _rest2393) => {
V B_2399 = default;
if (_self2391.IsNullish) _self2391 = GlobalV;
B_2399 = Get(t_2398, "B");
Invoke(Invoke(Invoke(t_2398, "to", ((V)(900D)), NewObj(4).Put("sq", ((V)((ToNum((Get(B_2399, "sq") is var _t2402 && Truthy(_t2402) ? _t2402 : ((V)(0D)))) - 0.05)))).Put("lift", Add((Get(B_2399, "lift") is var _t2403 && Truthy(_t2403) ? _t2403 : ((V)(0D))), ((V)(0.8)))).Put("close", ((V)(0.6))).Put("open", ((V)(0.2))).V, ((V)("s"))), "to", ((V)(1300D)), NewObj(5).Put("sq", Add((Get(B_2399, "sq") is var _t2400 && Truthy(_t2400) ? _t2400 : ((V)(0D))), ((V)(0.07)))).Put("lift", (Get(B_2399, "lift") is var _t2401 && Truthy(_t2401) ? _t2401 : ((V)(0D)))).Put("close", ((V)(0.8))).Put("open", ((V)(0.1))).Put("smile", ((V)(0.9))).V, ((V)("s"))), "wait", ((V)(400D)));
return Invoke(t_2398, "back", ((V)(700D)), Arr(((V)("sq")), ((V)("lift")), ((V)("close")), ((V)("open")), ((V)("smile"))));
return default;
}, 1, "sigh", false)).Put("doze", Fn((V _self2404, int _argc2405, V t_2411, V _a2408, V _a2409, V _a2410, V[] _rest2406) => {
if (_self2404.IsNullish) _self2404 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2411, "to", ((V)(900D)), NewObj(3).Put("close", ((V)(1D))).Put("pitch", ((V)((ToNum((Get(Get(t_2411, "B"), "pitch") is var _t2415 && Truthy(_t2415) ? _t2415 : ((V)(0D)))) - 0.2)))).Put("htilt", ((V)(5D))).V, ((V)("s"))), "osc", ((V)(2400D)), ((V)(2D)), NewObj(1).Put("pitch", ((V)((ToNum((Get(Get(t_2411, "B"), "pitch") is var _t2413 && Truthy(_t2413) ? _t2413 : ((V)(0D)))) - 0.3)))).V, NewObj(1).Put("pitch", ((V)((ToNum((Get(Get(t_2411, "B"), "pitch") is var _t2414 && Truthy(_t2414) ? _t2414 : ((V)(0D)))) - 0.16)))).V, ((V)("s"))), "to", ((V)(160D)), NewObj(4).Put("close", ((V)(0D))).Put("wide", ((V)(0.6))).Put("pitch", (Get(Get(t_2411, "B"), "pitch") is var _t2412 && Truthy(_t2412) ? _t2412 : ((V)(0D)))).Put("htilt", ((V)(0D))).V, ((V)("o"))), "e", ((V)("blink2")));
return Invoke(t_2411, "back", ((V)(420D)), Arr(((V)("close")), ((V)("pitch")), ((V)("htilt")), ((V)("wide"))));
return default;
}, 1, "doze", false)).Put("belly", Fn((V _self2416, int _argc2417, V t_2423, V s_2424, V _a2421, V _a2422, V[] _rest2418) => {
V K_2425 = default;
if (_self2416.IsNullish) _self2416 = GlobalV;
s_2424 = (s_2424 is var _t2426 && Truthy(_t2426) ? _t2426 : ((V)((-1D))));
K_2425 = Call(SIDE_14, V.Undef, s_2424);
Invoke(Invoke(Invoke(t_2423, "to", ((V)(420D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, s_2424, ((V)(6D)), ((V)(6D))), NewObj(1).PutK(Get(K_2425, "arm"), ((V)(10D))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).PutK(Get(K_2425, "hy"), ((V)(8D))).V, NewObj(1).PutK(Get(K_2425, "hy"), ((V)(5D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V);
return Invoke(t_2423, "back", ((V)(460D)), Arr(Get(K_2425, "hx"), Get(K_2425, "hy"), Get(K_2425, "arm"), ((V)("smile")), ((V)("hap"))));
return default;
}, 2, "belly", false)).V;
SIT0_17 = Call(o_10, V.Undef, NewObj(4).Put("sit", ((V)(1D))).Put("sq", ((V)(0.1))).Put("lift", ((V)((-2.6)))).Put("pitch", ((V)(0.06))).V, Call(both_13, V.Undef, ((V)(6D)), ((V)(3D))));
LNG0_18 = Call(o_10, V.Undef, NewObj(14).Put("sit", ((V)(1D))).Put("sq", ((V)(0.14))).Put("lift", ((V)((-3.6)))).Put("pitch", ((V)(0.3))).Put("close", ((V)(0.5))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.25))).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("footL", ((V)(2D))).Put("footR", ((V)(0.3))).Put("tilt", ((V)((-3.5)))).Put("htilt", ((V)(6D))).Put("lean", ((V)((-0.7)))).V, Call(both_13, V.Undef, ((V)((-2D))), ((V)((-1D)))));
ss_25 = Fn((V _self1, int _argc2427, V x_2433, V _a2430, V _a2431, V _a2432, V[] _rest2428) => {
return ((V)((LeN(x_2433, 0D) ? 0D : (GeN(x_2433, 1D) ? 1D : ((ToNum(x_2433) * ToNum(x_2433)) * (3D - (2D * ToNum(x_2433))))))));
}, 1, "", true);
TWO_26 = NewObj(3).Put("pip", ((V)(1D))).Put("puff", ((V)(1D))).Put("pearl", ((V)(1D))).V;
LAP_27 = NewObj(8).Put("bubbly", ((V)(1D))).Put("twinkle", ((V)(1D))).Put("jelli", ((V)(1D))).Put("finn", ((V)(1D))).Put("aurora", ((V)(1D))).Put("sealy", ((V)(1D))).Put("shelly", ((V)(1D))).Put("batty", ((V)(1D))).V;
RIGID_28 = NewObj(19).Put("puddi", ((V)(1D))).Put("cakey", ((V)(1D))).Put("maca", ((V)(1D))).Put("melo", ((V)(1D))).Put("choco", ((V)(1D))).Put("chip", ((V)(1D))).Put("twisty", ((V)(1D))).Put("crois", ((V)(1D))).Put("mochi", ((V)(1D))).Put("frybo", ((V)(1D))).Put("boba", ((V)(1D))).Put("bunbun", ((V)(1D))).Put("mallow", ((V)(1D))).Put("dunkie", ((V)(1D))).Put("scoop", ((V)(1D))).Put("cuppy", ((V)(1D))).Put("kernel", ((V)(1D))).Put("bao", ((V)(1D))).Put("chefbun", ((V)(1D))).V;
WX_29 = NewObj(78).Put("mittens", NewObj(2).Put("laughA", NewObj(1).Put("curl", ((V)(0.5))).V).Put("nz", NewObj(1).Put("curl", ((V)(0.7))).V).V).Put("biscuit", NewObj(4).Put("laughA", NewObj(1).Put("wag", ((V)(26D))).V).Put("laughB", NewObj(1).Put("wag", ((V)((-26D)))).V).Put("cheer", NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).V).Put("nz", NewObj(1).Put("wag", ((V)(18D))).V).V).Put("prickle", NewObj(1).Put("gasp", NewObj(9).Put("curl", ((V)(1D))).Put("sq", ((V)(0.24))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).V).V).Put("nibbles", NewObj(2).Put("laugh", NewObj(1).Put("puff", ((V)(0.8))).V).Put("gasp", NewObj(1).Put("puff", ((V)(1D))).V).V).Put("quill", NewObj(1).Put("gasp", NewObj(1).Put("blush", ((V)(1D))).V).V).Put("poppy", NewObj(1).Put("cheer", NewObj(2).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).V).V).Put("duchess", NewObj(2).Put("laugh", NewObj(3).Put("sqz", ((V)(0.3))).Put("close", ((V)(0.5))).Put("open", ((V)(0.25))).V).Put("aww", NewObj(1).Put("tongue", ((V)(0D))).V).V).Put("mamapaws", NewObj(2).Put("aww", NewObj(1).Put("close", ((V)(0.7))).V).Put("nz", NewObj(1).Put("wag", ((V)(12D))).V).V).Put("nimbo", NewObj(2).Put("awwFx", Arr(((V)("drop")), ((V)("body")), ((V)(4D)))).Put("gasp", NewObj(1).Put("sq", ((V)(0.24))).V).V).Put("lumi", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("head")), ((V)(5D)))).V).Put("bubbly", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("body")), ((V)(4D)))).V).Put("twinkle", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("body")), ((V)(6D)))).V).Put("zappi", NewObj(3).Put("gasp", NewObj(1).Put("zap", ((V)(1D))).V).Put("cheer", NewObj(1).Put("zap", ((V)(0.7))).V).Put("cheerFx", Arr(((V)("spark")), ((V)("body")), ((V)(6D)))).V).Put("plip", NewObj(1).Put("awwFx", Arr(((V)("drop")), ((V)("head")), ((V)(2D)))).V).Put("breeze", NewObj(2).Put("gasp", NewObj(1).Put("puff", ((V)(0.6))).V).Put("cheerFx", Arr(((V)("gust")), ((V)("head")))).V).Put("dusty", NewObj(1).Put("cheerFx", Arr(((V)("dust")), ((V)("body")), ((V)(4D)))).V).Put("aurora", NewObj(2).Put("cheer", NewObj(1).Put("spout", ((V)(1D))).V).Put("cheerFx", Arr(((V)("drop")), ((V)("head")), ((V)(4D)))).V).Put("mallow", NewObj(1).Put("aww", NewObj(1).Put("sq", ((V)(0.26))).V).V).Put("bao", NewObj(1).Put("cheerFx", Arr(((V)("steam")), ((V)("head")))).V).Put("dunkie", NewObj(1).Put("cheerFx", Arr(((V)("sprinkle")), ((V)("head")))).V).Put("frybo", NewObj(2).Put("cheer", NewObj(1).Put("fw", ((V)(1D))).V).Put("gasp", NewObj(1).Put("fw", ((V)(0.6))).V).V).Put("bunbun", NewObj(2).Put("gasp", NewObj(1).Put("split", ((V)(0.5))).V).Put("cheer", NewObj(1).Put("split", ((V)(0.3))).V).V).Put("choco", NewObj(1).Put("aww", NewObj(1).Put("melt", ((V)(0.4))).V).V).Put("scoop", NewObj(2).Put("laughA", NewObj(1).Put("chb", ((V)(1D))).V).Put("laughB", NewObj(1).Put("chb", ((V)(0D))).V).V).Put("boba", NewObj(1).Put("cheer", NewObj(1).Put("slurp", ((V)(0.6))).V).V).Put("chefbun", NewObj(0).V).Put("pip", NewObj(0).V).Put("jelli", NewObj(2).Put("laughA", NewObj(1).Put("sq", ((V)(0.2))).V).Put("laughB", NewObj(1).Put("sq", ((V)(0.02))).V).V).Put("finn", NewObj(3).Put("laughA", NewObj(1).Put("wag", ((V)(24D))).V).Put("laughB", NewObj(1).Put("wag", ((V)((-24D)))).V).Put("cheerFx", Arr(((V)("drop")), ((V)("body")), ((V)(4D)))).V).Put("sealy", NewObj(1).Put("clap", NewObj(1).Put("open", ((V)(0.5))).V).V).Put("puff", NewObj(1).Put("gasp", NewObj(2).Put("blo", ((V)(0.8))).Put("puff", ((V)(0.8))).V).V).Put("shelly", NewObj(1).Put("gasp", NewObj(1).Put("hid", ((V)(0.85))).V).V).Put("octo", NewObj(2).Put("gasp", NewObj(1).Put("ocl", ((V)(1D))).V).Put("cheer", NewObj(1).Put("osp", ((V)(1D))).V).V).Put("marina", NewObj(1).Put("cheer", NewObj(1).Put("tlf", ((V)(0.7))).V).V).Put("pearl", NewObj(2).Put("cheer", NewObj(1).Put("glow", ((V)(1D))).V).Put("cheerFx", Arr(((V)("spark")), ((V)("head")), ((V)(4D)))).V).Put("pina", NewObj(1).Put("cheer", NewObj(1).Put("crw", ((V)(1D))).V).V).Put("avo", NewObj(1).Put("gasp", NewObj(1).Put("pp", ((V)(0.4))).V).V).Put("berri", NewObj(1).Put("gasp", NewObj(1).Put("stw", ((V)(1D))).V).V).Put("lemmy", NewObj(1).Put("aww", NewObj(1).Put("sqz", ((V)(1D))).V).V).Put("kiwi", NewObj(1).Put("gasp", NewObj(1).Put("fzz", ((V)(1D))).V).V).Put("melo", NewObj(2).Put("laughA", NewObj(1).Put("sdj", ((V)(1D))).V).Put("laughB", NewObj(1).Put("sdj", ((V)(0D))).V).V).Put("peachy", NewObj(1).Put("aww", NewObj(1).Put("blush", ((V)(1D))).V).V).Put("pitaya", NewObj(1).Put("gasp", NewObj(2).Put("brf", ((V)(1D))).Put("wsp", ((V)(0.8))).V).V).Put("tutti", NewObj(2).Put("cheer", NewObj(1).Put("wfl", ((V)(1D))).V).Put("cheerFx", Arr(((V)("dust")), ((V)("body")), ((V)(3D)))).V).Put("kiko", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("head")), ((V)(3D)))).V).Put("teddy", NewObj(1).Put("aww", NewObj(1).Put("close", ((V)(0.6))).V).V).Put("hoot", NewObj(1).Put("gasp", NewObj(2).Put("tfl", ((V)(1D))).Put("wide", ((V)(1D))).V).V).Put("leo", NewObj(2).Put("gasp", NewObj(1).Put("mfl", ((V)(1D))).V).Put("cheer", NewObj(1).Put("mfl", ((V)(0.7))).V).V).Put("panko", NewObj(0).V).Put("acorn", NewObj(1).Put("gasp", NewObj(1).Put("tfl", ((V)(1D))).V).V).Put("fawn", NewObj(1).Put("gasp", NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).V).V).Put("moss", NewObj(2).Put("laughA", NewObj(1).Put("cb", ((V)(1D))).V).Put("laughB", NewObj(1).Put("cb", ((V)(0D))).V).V).Put("sprout", NewObj(1).Put("cheer", NewObj(1).Put("blm", ((V)(1D))).V).V).Put("hana", NewObj(1).Put("gasp", NewObj(2).Put("flL", ((V)(1D))).Put("flR", ((V)(1D))).V).V).Put("boo", NewObj(1).Put("gasp", NewObj(1).Put("gho", ((V)(0.5))).V).V).Put("pixie", NewObj(2).Put("cheer", NewObj(1).Put("wfl", ((V)(1D))).V).Put("cheerFx", Arr(((V)("dust")), ((V)("body")), ((V)(4D)))).V).Put("floof", NewObj(1).Put("gasp", NewObj(1).Put("fzz", ((V)(1D))).V).V).Put("unibun", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("head")), ((V)(5D)))).V).Put("gumdrop", NewObj(2).Put("laughA", NewObj(1).Put("jig", ((V)(1D))).V).Put("laughB", NewObj(1).Put("jig", ((V)(0.3))).V).V).Put("ember", NewObj(2).Put("gasp", NewObj(1).Put("cfl", ((V)(1D))).V).Put("cheer", NewObj(1).Put("cfl", ((V)(1D))).V).V).Put("drako", NewObj(2).Put("gasp", NewObj(1).Put("wsp", ((V)(1D))).V).Put("cheer", NewObj(2).Put("wsp", ((V)(1D))).Put("wfl", ((V)(1D))).V).V).Put("jinni", NewObj(1).Put("cheer", NewObj(2).Put("glo", ((V)(1D))).Put("gwh", ((V)(1D))).V).V).Put("cuppy", NewObj(1).Put("cheerFx", Arr(((V)("sprinkle")), ((V)("head")))).V).Put("chip", NewObj(0).V).Put("twisty", NewObj(0).V).Put("crois", NewObj(0).V).Put("maca", NewObj(0).V).Put("puddi", NewObj(1).Put("laughA", NewObj(1).Put("sq", ((V)(0.2))).V).V).Put("mochi", NewObj(1).Put("aww", NewObj(1).Put("sq", ((V)(0.24))).V).V).Put("cakey", NewObj(0).V).Put("sugarplum", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("head")), ((V)(3D)))).V).Put("gourdy", NewObj(0).V).Put("batty", NewObj(1).Put("gasp", NewObj(2).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).V).V).Put("kernel", NewObj(0).V).Put("hexie", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("head")), ((V)(4D)))).V).Put("mumbles", NewObj(0).V).Put("hocus", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("body")), ((V)(4D)))).V).Put("countsquishula", NewObj(1).Put("gasp", NewObj(3).Put("armL", ((V)(90D))).Put("hLy", ((V)((-10D)))).Put("hLx", ((V)(6D))).V).V).V;
WBEAT_30 = NewObj(7).Put("leanin", Fn((V _self2434, int _argc2435, V t_2441, V X_2442, V _a2439, V _a2440, V[] _rest2436) => {
V B_2443 = default;
if (_self2434.IsNullish) _self2434 = GlobalV;
B_2443 = Get(t_2441, "B");
Invoke(Invoke(Invoke(Invoke(t_2441, "to", ((V)(700D)), Call(o_10, V.Undef, NewObj(6).Put("pitch", ((V)((ToNum((Get(B_2443, "pitch") is var _t2444 && Truthy(_t2444) ? _t2444 : ((V)(0D)))) - 0.14)))).Put("sq", Add((Get(B_2443, "sq") is var _t2445 && Truthy(_t2445) ? _t2445 : ((V)(0D))), ((V)(0.03)))).Put("wide", ((V)(0.5))).Put("mw", ((V)(0.6))).Put("open", ((V)(0.12))).Put("ly", ((V)(0.1))).V, Get(X_2442, "lean")), ((V)("io"))), "wait", ((V)(1300D))), "to", ((V)(240D)), NewObj(2).Put("wide", ((V)(0.9))).Put("open", ((V)(0.3))).V, ((V)("o"))), "wait", ((V)(500D)));
return Invoke(t_2441, "back", ((V)(600D)));
return default;
}, 2, "leanin", false)).Put("laugh", Fn((V _self2446, int _argc2447, V t_2453, V X_2454, V _a2451, V _a2452, V[] _rest2448) => {
V B_2455 = default;
V L_2456 = default;
V Q_2457 = default;
if (_self2446.IsNullish) _self2446 = GlobalV;
B_2455 = Get(t_2453, "B");
L_2456 = (Get(B_2455, "lift") is var _t2458 && Truthy(_t2458) ? _t2458 : ((V)(0D)));
Q_2457 = (Get(B_2455, "sq") is var _t2459 && Truthy(_t2459) ? _t2459 : ((V)(0D)));
Invoke(Invoke(t_2453, "to", ((V)(220D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(7D)), ((V)(5D))), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.55))).Put("sqz", ((V)(0.8))).V, Get(X_2454, "laugh")), ((V)("o"))), "osc", ((V)(1500D)), ((V)(7D)), Call(o_10, V.Undef, NewObj(3).Put("sq", Add(Q_2457, ((V)(0.045)))).Put("lift", Add(L_2456, ((V)(0.6)))).Put("htilt", ((V)(4D))).V, Get(X_2454, "laughA")), Call(o_10, V.Undef, NewObj(3).Put("sq", ((V)((ToNum(Q_2457) - 0.01)))).Put("lift", L_2456).Put("htilt", ((V)((-4D)))).V, Get(X_2454, "laughB")), ((V)("o")));
return Invoke(t_2453, "back", ((V)(450D)));
return default;
}, 2, "laugh", false)).Put("gasp", Fn((V _self2460, int _argc2461, V t_2467, V X_2468, V _a2465, V _a2466, V[] _rest2462) => {
V B_2469 = default;
V L_2470 = default;
V Q_2471 = default;
if (_self2460.IsNullish) _self2460 = GlobalV;
B_2469 = Get(t_2467, "B");
L_2470 = (Get(B_2469, "lift") is var _t2472 && Truthy(_t2472) ? _t2472 : ((V)(0D)));
Q_2471 = (Get(B_2469, "sq") is var _t2473 && Truthy(_t2473) ? _t2473 : ((V)(0D)));
Invoke(Invoke(Invoke(Invoke(t_2467, "to", ((V)(170D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(10D)), ((V)((-12D)))), NewObj(8).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.5))).Put("lift", Add(L_2470, ((V)(1.4)))).Put("sq", ((V)((ToNum(Q_2471) - 0.05)))).Put("pitch", Add((Get(B_2469, "pitch") is var _t2474 && Truthy(_t2474) ? _t2474 : ((V)(0D))), ((V)(0.1)))).V, Get(X_2468, "gasp")), ((V)("o"))), "wait", ((V)(1000D))), "to", ((V)(500D)), NewObj(3).Put("wide", ((V)(0.4))).Put("open", ((V)(0.2))).Put("lift", L_2470).V, ((V)("io"))), "wait", ((V)(300D)));
return Invoke(t_2467, "back", ((V)(520D)));
return default;
}, 2, "gasp", false)).Put("popcorn", Fn((V _self2475, int _argc2476, V t_2482, V X_2483, V two_2484, V _a2481, V[] _rest2477) => {
V B_2485 = default;
V p0_2486 = default;
if (_self2475.IsNullish) _self2475 = GlobalV;
B_2485 = Get(t_2482, "B");
p0_2486 = (Get(B_2485, "pitch") is var _t2487 && Truthy(_t2487) ? _t2487 : ((V)(0D)));
if (SEqS(two_2484, "lap")) {
{
double i_2488 = 0;
i_2488 = 0D;
while (true) {
if (!((i_2488 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2482, "to", ((V)(340D)), NewObj(4).Put("pitch", ((V)((ToNum(p0_2486) - 0.24)))).Put("ly", ((V)(0.7))).Put("open", ((V)(0.3))).Put("sq", Add((Get(B_2485, "sq") is var _t2491 && Truthy(_t2491) ? _t2491 : ((V)(0D))), ((V)(0.03)))).V, ((V)("io"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("open", ((V)(0.25))).Put("puff", ((V)(0.5))).V, NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.2))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("mouth"))), "to", ((V)(320D)), NewObj(5).Put("pitch", p0_2486).Put("ly", ((V)(0D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).Put("sq", (Get(B_2485, "sq") is var _t2490 && Truthy(_t2490) ? _t2490 : ((V)(0D)))).V, ((V)("io"))), "wait", ((V)(300D)));
i_2488++;
}
}
} else {
if (Truthy(two_2484)) {
Invoke(t_2482, "to", ((V)(320D)), Call(both_13, V.Undef, ((V)(7D)), ((V)((-1D)))));
{
double i_2492 = 0;
i_2492 = 0D;
while (true) {
if (!((i_2492 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2482, "to", ((V)(320D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(9D)), ((V)((-12D)))), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("open", ((V)(0.35))).Put("pitch", ((V)((ToNum(p0_2486) - 0.05)))).V), ((V)("io"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("open", ((V)(0.25))).Put("puff", ((V)(0.5))).V, NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.2))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("mouth"))), "to", ((V)(300D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(7D)), ((V)((-1D)))), NewObj(5).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).Put("pitch", p0_2486).V), ((V)("io"))), "wait", ((V)(240D)));
i_2492++;
}
}
} else {
Invoke(t_2482, "to", ((V)(320D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)(5D)), ((V)(1D))), NewObj(1).Put("armL", ((V)(8D))).V));
{
double i_2494 = 0;
i_2494 = 0D;
while (true) {
if (!((i_2494 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2482, "to", ((V)(240D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(13D)), ((V)(1D))), NewObj(2).Put("armR", ((V)(6D))).Put("ly", ((V)(0.5))).V), ((V)("io"))), "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-14D)))), NewObj(3).Put("armR", ((V)(36D))).Put("open", ((V)(0.35))).Put("ly", ((V)(0D))).V), ((V)("io"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("open", ((V)(0.25))).Put("puff", ((V)(0.5))).V, NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.2))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("mouth"))), "to", ((V)(260D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(6D)), ((V)(3D))), NewObj(3).Put("armR", ((V)(0D))).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(200D)));
i_2494++;
}
}
}
}
Invoke(t_2482, "to", ((V)(200D)), NewObj(2).Put("smile", ((V)(1D))).Put("hap", ((V)(0.5))).V);
return Invoke(t_2482, "back", ((V)(420D)));
return default;
}, 3, "popcorn", false)).Put("clap", Fn((V _self2496, int _argc2497, V t_2503, V X_2504, V _a2501, V _a2502, V[] _rest2498) => {
if (_self2496.IsNullish) _self2496 = GlobalV;
Invoke(Invoke(Invoke(t_2503, "to", ((V)(260D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(11D)), ((V)((-5D)))), NewObj(5).Put("armL", ((V)(28D))).Put("armR", ((V)(28D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, Get(X_2504, "clap")), ((V)("o"))), "osc", ((V)(1300D)), ((V)(6D)), NewObj(2).Put("hLx", ((V)(14D))).Put("hRx", ((V)((-14D)))).V, NewObj(2).Put("hLx", ((V)(8D))).Put("hRx", ((V)((-8D)))).V, ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
return Invoke(t_2503, "back", ((V)(420D)));
return default;
}, 2, "clap", false)).Put("aww", Fn((V _self2505, int _argc2506, V t_2512, V X_2513, V _a2510, V _a2511, V[] _rest2507) => {
if (_self2505.IsNullish) _self2505 = GlobalV;
Invoke(Invoke(t_2512, "to", ((V)(600D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(8D)), ((V)((-5D)))), NewObj(7).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("close", ((V)(0.35))).Put("frown", ((V)(0.5))).Put("teary", ((V)(0.6))).Put("htilt", ((V)(7D))).Put("mw", ((V)(0.6))).V, Get(X_2513, "aww")), ((V)("io"))), "wait", ((V)(700D)));
if (Truthy(Get(X_2513, "awwFx"))) {
InvokeSpread(t_2512, "fx", new ArrBuilder().Spread(Get(X_2513, "awwFx")).V);
}
Invoke(Invoke(t_2512, "wait", ((V)(600D))), "to", ((V)(400D)), NewObj(3).Put("teary", ((V)(0.2))).Put("frown", ((V)(0D))).Put("smile", ((V)(0.6))).V, ((V)("io")));
return Invoke(t_2512, "back", ((V)(600D)));
return default;
}, 2, "aww", false)).Put("cheer", Fn((V _self2514, int _argc2515, V t_2521, V X_2522, V _a2519, V _a2520, V[] _rest2516) => {
V B_2523 = default;
V L_2524 = default;
V Q_2525 = default;
if (_self2514.IsNullish) _self2514 = GlobalV;
B_2523 = Get(t_2521, "B");
L_2524 = (Get(B_2523, "lift") is var _t2526 && Truthy(_t2526) ? _t2526 : ((V)(0D)));
Q_2525 = (Get(B_2523, "sq") is var _t2527 && Truthy(_t2527) ? _t2527 : ((V)(0D)));
Invoke(t_2521, "to", ((V)(260D)), Call(o_10, V.Undef, NewObj(10).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("hLx", ((V)((-6D)))).Put("hRx", ((V)(6D))).Put("hLy", ((V)((-6D)))).Put("hRy", ((V)((-6D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.55))).Put("wide", ((V)(0.3))).V, Get(X_2522, "cheer")), ((V)("o")));
if (Truthy(Get(X_2522, "cheerFx"))) {
InvokeSpread(t_2521, "fx", new ArrBuilder().Spread(Get(X_2522, "cheerFx")).V);
}
{
double i_2528 = 0;
i_2528 = 0D;
while (true) {
if (!((i_2528 < 2D))) break;
Invoke(Invoke(Invoke(t_2521, "to", ((V)(140D)), NewObj(2).Put("sq", Add(Q_2525, ((V)(0.08)))).Put("lift", L_2524).V, ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)((ToNum(Q_2525) - 0.05)))).Put("lift", Add(L_2524, ((V)(2.6)))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(2).Put("sq", Q_2525).Put("lift", L_2524).V, ((V)("i")));
i_2528++;
}
}
return Invoke(t_2521, "back", ((V)(450D)));
return default;
}, 2, "cheer", false)).V;
BUCKET_31 = ((V)(string.Concat("<path d=\"M-4.6 -2.4L4.6 -2.4L3.5 5.2L-3.5 5.2Z\" fill=\"#fffaf0\" stroke=\"#c9b9a0\" stroke-width=\"0.35\"/><path d=\"M-2.6 -2.4L-1.2 -2.4L-1 5.2L-2.1 5.2Z M1.2 -2.4L2.6 -2.4L2.1 5.2L1 5.2Z\" fill=\"#e8483c\"/><path d=\"M1.6 -2.4L4.6 -2.4L3.5 5.2L1.3 5.2Z\" fill=\"#3a1d10\" opacity=\"0.12\"/>", ToStr(Invoke(Invoke(Arr(Arr(((V)((-3D))), ((V)((-3D))), ((V)(1.6))), Arr(((V)((-0.8))), ((V)((-3.9))), ((V)(1.8))), Arr(((V)(1.6)), ((V)((-3.2))), ((V)(1.6))), Arr(((V)(3.4)), ((V)((-2.7))), ((V)(1.2))), Arr(((V)(0.6)), ((V)((-5.2))), ((V)(1.3))), Arr(((V)((-2.2))), ((V)((-4.7))), ((V)(1.2)))), "map", Fn((V _self1, int _argc2530, V _a2532, V _a2533, V _a2534, V _a2535, V[] _rest2531) => {
V x_2538 = default;
V y_2540 = default;
V r_2542 = default;
{ V _t2536 = ListOf(_a2532);
{ V _t2537 = GetIdx(_t2536, 0D);
x_2538 = _t2537; }
{ V _t2539 = GetIdx(_t2536, 1D);
y_2540 = _t2539; }
{ V _t2541 = GetIdx(_t2536, 2D);
r_2542 = _t2541; }
}
return ((V)(string.Concat(new string[] { "<circle cx=\"", ToStr(x_2538), "\" cy=\"", ToStr(y_2540), "\" r=\"", ToStr(r_2542), "\" fill=\"#fff4cf\" stroke=\"#e2b85e\" stroke-width=\"0.3\"/>" })));
}, 1, "", true)), "join", ((V)("")))), "<path d=\"M-4.9 -2.6L4.9 -2.6L4.7 -1.6L-4.7 -1.6Z\" fill=\"#e8483c\"/>")));
popProp_32 = Fn((V _self1, int _argc2543, V win_2549, V loop_2550, V two_2551, V _a2548, V[] _rest2544) => {
return Fn((V _self1, int _argc2552, V I_2558, V tt_2559, V _a2556, V _a2557, V[] _rest2553) => {
V W_2560 = default;
double tl_2561 = 0;
double k_2562 = 0;
V mid_2563 = default;
V x_2564 = default;
V y_2565 = default;
W_2560 = Get(I_2558, "W");
if (((!(Truthy(W_2560)) || !(Truthy(Get(W_2560, "pawL")))) || !(Truthy(Get(win_2549, "length"))))) {
return ((V)(""));
}
tl_2561 = (ToNum(tt_2559) % ToNum(loop_2550));
k_2562 = 0D;
Invoke(win_2549, "forEach", Fn((V _self1, int _argc2566, V _a2568, V _a2569, V _a2570, V _a2571, V[] _rest2567) => {
V a_2574 = default;
V b_2576 = default;
{ V _t2572 = ListOf(_a2568);
{ V _t2573 = GetIdx(_t2572, 0D);
a_2574 = _t2573; }
{ V _t2575 = GetIdx(_t2572, 1D);
b_2576 = _t2575; }
}
if ((Gt(((V)(tl_2561)), a_2574) && Lt(((V)(tl_2561)), b_2576))) {
k_2562 = Max(k_2562, Min(ToNum(Call(ss_25, V.Undef, ((V)(((tl_2561 - ToNum(a_2574)) / 260D))))), ToNum(Call(ss_25, V.Undef, ((V)(((ToNum(b_2576) - tl_2561) / 260D)))))));
}
return default;
}, 1, "", true));
if ((k_2562 < 0.01)) {
return ((V)(""));
}
mid_2563 = (two_2551 is var _t2577 && Truthy(_t2577) ? _t2577 : Get(I_2558, "foodMid"));
x_2564 = (Truthy(mid_2563) ? ((V)((ToNum(Add(GetIdx(Get(W_2560, "pawL"), 0D), GetIdx(Get(W_2560, "pawR"), 0D))) / 2D))) : GetIdx(Get(W_2560, "pawL"), 0D));
y_2565 = Add((Truthy(mid_2563) ? ((V)((ToNum(Add(GetIdx(Get(W_2560, "pawL"), 1D), GetIdx(Get(W_2560, "pawR"), 1D))) / 2D))) : GetIdx(Get(W_2560, "pawL"), 1D)), ((V)((SEqS(two_2551, "lap") ? 5D : 0D))));
return ((V)(string.Concat(new string[] { "<g transform=\"translate(", ToStr(Invoke(x_2564, "toFixed", ((V)(2D)))), " ", ToStr(Invoke(((V)((ToNum(y_2565) - 4D))), "toFixed", ((V)(2D)))), ") scale(", ToStr(Invoke(((V)((k_2562 * 2.3))), "toFixed", ((V)(3D)))), ")\">", ToStr(BUCKET_31), "</g>" })));
return default;
}, 2, "", true);
}, 3, "", true);
PROF_35 = NewObj(0).V;
TAU_37 = (System.Math.PI * 2D);
r2_38 = Fn((V _self1, int _argc2578, V v_2584, V _a2581, V _a2582, V _a2583, V[] _rest2579) => {
return ((V)((Round((ToNum(v_2584) * 100D)) / 100D)));
}, 1, "", true);
cl_39 = Fn((V _self1, int _argc2585, V v_2591, V a_2592, V b_2593, V _a2590, V[] _rest2586) => {
return (Lt(v_2591, a_2592) ? a_2592 : (Gt(v_2591, b_2593) ? b_2593 : v_2591));
}, 3, "", true);
LIE0_40 = Call(o_10, V.Undef, NewObj(19).Put("sit", ((V)(1D))).Put("sq", ((V)(0.15))).Put("lift", ((V)((-2.6)))).Put("pitch", ((V)(0.34))).Put("close", ((V)(1D))).Put("mw", ((V)(0.7))).Put("smile", ((V)(0.2))).Put("htilt", ((V)(7D))).Put("tilt", ((V)((-3D)))).Put("armL", ((V)(6D))).Put("armR", ((V)(6D))).Put("footL", ((V)(0.6))).Put("footR", ((V)(0.6))).Put("lean", ((V)(0D))).Put("hap", ((V)(0D))).Put("open", ((V)(0D))).Put("qk", ((V)(1D))).Put("zz", ((V)(1D))).Put("drm", ((V)(0D))).V, Call(both_13, V.Undef, ((V)(5D)), ((V)((-2D)))));
CURL0_41 = Call(o_10, V.Undef, NewObj(20).Put("sit", ((V)(1D))).Put("sq", ((V)(0.24))).Put("lift", ((V)((-5.2)))).Put("pitch", ((V)((-0.26)))).Put("close", ((V)(1D))).Put("mw", ((V)(0.7))).Put("smile", ((V)(0.25))).Put("htilt", ((V)(12D))).Put("tilt", ((V)(6D))).Put("turn", ((V)(0.26))).Put("curl", ((V)(0.9))).Put("lean", ((V)(0.6))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("hap", ((V)(0D))).Put("open", ((V)(0D))).Put("zz", ((V)(1D))).Put("drm", ((V)(0D))).V, Call(both_13, V.Undef, ((V)(7D)), ((V)(4D))));
shade_42 = Fn((V _self1, int _argc2594, V h_2600, V k_2601, V _a2598, V _a2599, V[] _rest2595) => {
double n_2602 = 0;
if (!(Truthy(Invoke(NewRegExp(RX0, "^#[0-9a-f]{6}$", "i"), "test", (h_2600 is var _t2603 && Truthy(_t2603) ? _t2603 : ((V)(""))))))) {
return ((V)((LtN(k_2601, 1D) ? "#56709a" : "#a9c2e8")));
}
n_2602 = ParseInt(Invoke(h_2600, "slice", ((V)(1D))), ((V)(16D)));
return ((V)(string.Concat("#", ToStr(Invoke(Invoke(Arr(((V)(((double)(ToInt32(n_2602) >> (int)(ToUint32(16D) & 31))))), ((V)(((double)(ToInt32(((double)(ToInt32(n_2602) >> (int)(ToUint32(8D) & 31)))) & ToInt32(255D))))), ((V)(((double)(ToInt32(n_2602) & ToInt32(255D)))))), "map", Fn((V _self1, int _argc2604, V c_2610, V _a2607, V _a2608, V _a2609, V[] _rest2605) => {
return Invoke(Invoke(((V)(Round(ToNum(Call(cl_39, V.Undef, (LtN(k_2601, 1D) ? ((V)((ToNum(c_2610) * ToNum(k_2601)))) : Add(c_2610, ((V)(((255D - ToNum(c_2610)) * (ToNum(k_2601) - 1D)))))), ((V)(0D)), ((V)(255D))))))), "toString", ((V)(16D))), "padStart", ((V)(2D)), ((V)("0")));
}, 1, "", true)), "join", ((V)("")))))));
return default;
}, 2, "", true);
ci_43 = Fn((V _self1, int _argc2611, V x_2617, V y_2618, V r_2619, V f_2620, V[] _rest2612) => {
V s_2621 = default;
s_2621 = (_argc2611 > 4 ? _rest2612[0] : V.Undef);
return ((V)(string.Concat(new string[] { "<circle cx=\"", ToStr(x_2617), "\" cy=\"", ToStr(y_2618), "\" r=\"", ToStr(r_2619), "\" fill=\"", ToStr(f_2620), "\"", (Truthy(s_2621) ? string.Concat(" stroke=\"", ToStr(s_2621), "\" stroke-width=\"0.4\"") : ""), "/>" })));
}, 5, "", true);
pa_44 = Fn((V _self1, int _argc2622, V d_2628, V f_2629, V s_2630, V w_2631, V[] _rest2623) => {
return ((V)(string.Concat(new string[] { "<path d=\"", ToStr(d_2628), "\" fill=\"", ToStr((f_2629 is var _t2632 && Truthy(_t2632) ? _t2632 : ((V)("none")))), "\"", (Truthy(s_2630) ? string.Concat(new string[] { " stroke=\"", ToStr(s_2630), "\" stroke-width=\"", ToStr((w_2631 is var _t2633 && Truthy(_t2633) ? _t2633 : ((V)(0.4)))), "\" stroke-linecap=\"round\" stroke-linejoin=\"round\"" }) : ""), "/>" })));
}, 4, "", true);
ICON_45 = NewObj(31).Put("fish", Add(Add(Call(pa_44, V.Undef, ((V)("M-4 0Q-1-3.2 2.4 0Q-1 3.2-4 0Z")), ((V)("#f2924a")), ((V)("#c96a2a"))), Call(pa_44, V.Undef, ((V)("M2 0L4.6-2.2V2.2Z")), ((V)("#f2924a")), ((V)("#c96a2a")))), Call(ci_43, V.Undef, ((V)((-2.2))), ((V)((-0.5))), ((V)(0.5)), ((V)("#3a2a20"))))).Put("bone", Add(Add(Call(pa_44, V.Undef, ((V)("M-2.6-0.9H2.6V0.9H-2.6Z")), ((V)("#fff4dc"))), Invoke(Invoke(Arr(Arr(((V)((-3D))), ((V)((-0.9)))), Arr(((V)((-3D))), ((V)(0.9))), Arr(((V)(3D)), ((V)((-0.9)))), Arr(((V)(3D)), ((V)(0.9)))), "map", Fn((V _self1, int _argc2634, V _a2636, V _a2637, V _a2638, V _a2639, V[] _rest2635) => {
V x_2642 = default;
V y_2644 = default;
{ V _t2640 = ListOf(_a2636);
{ V _t2641 = GetIdx(_t2640, 0D);
x_2642 = _t2641; }
{ V _t2643 = GetIdx(_t2640, 1D);
y_2644 = _t2643; }
}
return Call(ci_43, V.Undef, x_2642, y_2644, ((V)(1.2)), ((V)("#fff4dc")), ((V)("#c9b48a")));
}, 1, "", true)), "join", ((V)("")))), Call(pa_44, V.Undef, ((V)("M-2.6-0.9H2.6M-2.6 0.9H2.6")), V.Null, ((V)("#c9b48a"))))).Put("apple", Add(Add(Add(Call(ci_43, V.Undef, ((V)(0D)), ((V)(0.8)), ((V)(3.2)), ((V)("#e8483c")), ((V)("#b8302a"))), Call(pa_44, V.Undef, ((V)("M0-2.2Q0.4-3.6 1-4")), V.Null, ((V)("#6a4a2a")), ((V)(0.6)))), Call(pa_44, V.Undef, ((V)("M0.4-3Q2.4-4.2 3-2.6Q1.6-2 0.4-3Z")), ((V)("#7cc35a")))), Call(ci_43, V.Undef, ((V)((-1.2))), ((V)((-0.4))), ((V)(0.8)), ((V)("#fff"))))).Put("nut", Add(Add(Call(pa_44, V.Undef, ((V)("M-3-0.4Q0-3.4 3-0.4Z")), ((V)("#8a5a2c"))), Call(pa_44, V.Undef, ((V)("M-2.6-0.4Q-2.4 3.6 0 4Q2.4 3.6 2.6-0.4Z")), ((V)("#d39a5a")), ((V)("#a86b36")))), Call(pa_44, V.Undef, ((V)("M0-2.4V-3.6")), V.Null, ((V)("#6a4a2a")), ((V)(0.6))))).Put("flower", Add(Invoke(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D))), "map", Fn((V _self1, int _argc2645, V i_2651, V _a2648, V _a2649, V _a2650, V[] _rest2646) => {
return Call(ci_43, V.Undef, Call(r2_38, V.Undef, ((V)((FdLibm.Cos(((ToNum(i_2651) * 1.2566) - 1.57)) * 2.3)))), Call(r2_38, V.Undef, ((V)((FdLibm.Sin(((ToNum(i_2651) * 1.2566) - 1.57)) * 2.3)))), ((V)(1.6)), ((V)("#f7a8c4")), ((V)("#d9789a")));
}, 1, "", true)), "join", ((V)(""))), Call(ci_43, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(1.3)), ((V)("#ffd84a")), ((V)("#d9a62a"))))).Put("carrot", Add(Call(pa_44, V.Undef, ((V)("M-1.9-1.6L1.9-1.6L0 4.4Z")), ((V)("#f28a1e")), ((V)("#c96a10"))), Call(pa_44, V.Undef, ((V)("M0-1.6L-1.4-4.2M0-1.6L0-4.6M0-1.6L1.4-4.2")), V.Null, ((V)("#5fae4a")), ((V)(0.9))))).Put("crown", Add(Call(pa_44, V.Undef, ((V)("M-4 2.4L-4-1.6L-2-0.2L0-2.8L2-0.2L4-1.6L4 2.4Z")), ((V)("#ffd24a")), ((V)("#c9962a"))), Call(ci_43, V.Undef, ((V)(0D)), ((V)(0.8)), ((V)(0.8)), ((V)("#e8483c"))))).Put("heart", Call(pa_44, V.Undef, ((V)("M0 3.4C-4.6 0.4-4-3.6-1.6-3.2C-0.6-3 0-2.2 0-1.6C0-2.2 0.6-3 1.6-3.2C4-3.6 4.6 0.4 0 3.4Z")), ((V)("#ff6f86")), ((V)("#d9485e")))).Put("sun", Add(Call(pa_44, V.Undef, Invoke(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D)), ((V)(5D)), ((V)(6D)), ((V)(7D))), "map", Fn((V _self1, int _argc2652, V i_2658, V _a2655, V _a2656, V _a2657, V[] _rest2653) => {
double a_2659 = 0;
a_2659 = (ToNum(i_2658) * 0.785);
return ((V)(string.Concat(new string[] { "M", ToStr(Call(r2_38, V.Undef, ((V)((FdLibm.Cos(a_2659) * 3D))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((FdLibm.Sin(a_2659) * 3D))))), "L", ToStr(Call(r2_38, V.Undef, ((V)((FdLibm.Cos(a_2659) * 4.4))))), " ", ToStr(Call(r2_38, V.Undef, ((V)((FdLibm.Sin(a_2659) * 4.4))))) })));
return default;
}, 1, "", true)), "join", ((V)(""))), V.Null, ((V)("#f2a81e")), ((V)(0.8))), Call(ci_43, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(2.3)), ((V)("#ffcc3a")), ((V)("#e2961e"))))).Put("star", Call(pa_44, V.Undef, ((V)("M0-4.2L1.2-1.4L4.2-1.2L1.9 0.8L2.6 3.8L0 2.2L-2.6 3.8L-1.9 0.8L-4.2-1.2L-1.2-1.4Z")), ((V)("#ffd24a")), ((V)("#d9a22a")))).Put("bubble", Add(Add(Call(ci_43, V.Undef, ((V)((-1D))), ((V)(0.6)), ((V)(2.6)), ((V)("rgba(160,220,255,0.35)")), ((V)("#5ab4f0"))), Call(ci_43, V.Undef, ((V)(2.4)), ((V)((-2D))), ((V)(1.3)), ((V)("rgba(160,220,255,0.35)")), ((V)("#5ab4f0")))), Call(ci_43, V.Undef, ((V)((-1.9))), ((V)((-0.4))), ((V)(0.6)), ((V)("#fff"))))).Put("moon", Call(pa_44, V.Undef, ((V)("M1.2-3.6A3.8 3.8 0 1 0 1.2 3.6A3 3 0 1 1 1.2-3.6Z")), ((V)("#ffe08a")), ((V)("#d9b24a")))).Put("bolt", Call(pa_44, V.Undef, ((V)("M0.8-4.2L-2.4 0.6H-0.2L-1 4.2L2.4-0.8H0.2Z")), ((V)("#ffd42a")), ((V)("#c9962a")))).Put("rainbow", Add(Add(Call(pa_44, V.Undef, ((V)("M-4 2.4A4 4 0 0 1 4 2.4")), V.Null, ((V)("#ff6a5a")), ((V)(1.1))), Call(pa_44, V.Undef, ((V)("M-2.9 2.4A2.9 2.9 0 0 1 2.9 2.4")), V.Null, ((V)("#ffd24a")), ((V)(1.1)))), Call(pa_44, V.Undef, ((V)("M-1.8 2.4A1.8 1.8 0 0 1 1.8 2.4")), V.Null, ((V)("#5ab4f0")), ((V)(1.1))))).Put("cloud", Add(Add(Add(Call(ci_43, V.Undef, ((V)((-1.8))), ((V)(0.8)), ((V)(1.9)), ((V)("#fff")), ((V)("#a9b9d0"))), Call(ci_43, V.Undef, ((V)(1.8)), ((V)(0.8)), ((V)(1.9)), ((V)("#fff")), ((V)("#a9b9d0")))), Call(ci_43, V.Undef, ((V)(0D)), ((V)((-0.4))), ((V)(2.4)), ((V)("#fff")), ((V)("#a9b9d0")))), Call(pa_44, V.Undef, ((V)("M-3.2 1.4Q0 3.2 3.2 1.4")), ((V)("#fff"))))).Put("cup", Add(Add(Call(pa_44, V.Undef, ((V)("M-2.8-1.2H2L1.6 3.2H-2.4Z")), ((V)("#c98a52")), ((V)("#8a5a2c"))), Call(pa_44, V.Undef, ((V)("M2-0.4Q3.6-0.4 3.4 1Q3.2 2 1.8 2")), V.Null, ((V)("#8a5a2c")), ((V)(0.7)))), Call(pa_44, V.Undef, ((V)("M-1.2-2.2Q-1.8-3.2-1.1-4M0.6-2.2Q0-3.2 0.7-4")), V.Null, ((V)("#b9a6c9")), ((V)(0.5))))).Put("ketchup", Add(Add(Call(pa_44, V.Undef, ((V)("M-1.8-1.2H1.8V3.8Q0 4.4-1.8 3.8Z")), ((V)("#e8483c")), ((V)("#b8302a"))), Call(pa_44, V.Undef, ((V)("M-0.8-3.8H0.8V-1.2H-0.8Z")), ((V)("#fffaf0")), ((V)("#c9b9a0")))), Call(pa_44, V.Undef, ((V)("M-1.8 0.6H1.8V1.8H-1.8Z")), ((V)("#ffd24a"))))).Put("cheese", Add(Add(Call(pa_44, V.Undef, ((V)("M-4 2.6L3.8 2.6L3.8-1.4L-4 0.4Z")), ((V)("#ffd24a")), ((V)("#d9a22a"))), Call(ci_43, V.Undef, ((V)((-1D))), ((V)(1.4)), ((V)(0.6)), ((V)("#e8b22a")))), Call(ci_43, V.Undef, ((V)(1.8)), ((V)(0.2)), ((V)(0.8)), ((V)("#e8b22a"))))).Put("cherry", Add(Add(Add(Call(pa_44, V.Undef, ((V)("M-1.6 0.6Q-0.6-2.8 1-4M1.8 1Q1.6-2 1-4")), V.Null, ((V)("#5fae4a")), ((V)(0.6))), Call(ci_43, V.Undef, ((V)((-1.8))), ((V)(1.6)), ((V)(1.8)), ((V)("#e8283c")), ((V)("#a81a2a")))), Call(ci_43, V.Undef, ((V)(2D)), ((V)(1.8)), ((V)(1.8)), ((V)("#e8283c")), ((V)("#a81a2a")))), Call(ci_43, V.Undef, ((V)((-2.4))), ((V)(1D)), ((V)(0.5)), ((V)("#fff"))))).Put("pearl", Add(Add(Call(ci_43, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(3D)), ((V)("#fff8f0")), ((V)("#c9b8d8"))), Call(ci_43, V.Undef, ((V)((-1D))), ((V)((-1D))), ((V)(0.9)), ((V)("#ffffff")))), Call(pa_44, V.Undef, ((V)("M1.2 1.6Q2.2 0.6 2 -0.6")), V.Null, ((V)("#e6d6ee")), ((V)(0.5))))).Put("cake", Add(Add(Call(pa_44, V.Undef, ((V)("M-3.8 3V-0.4L3.6-2.2V3Z")), ((V)("#f6dca8")), ((V)("#c9a46a"))), Call(pa_44, V.Undef, ((V)("M-3.8-0.4L3.6-2.2V-0.8L-3.8 1Z")), ((V)("#ff9fb6")))), Call(ci_43, V.Undef, ((V)(1.6)), ((V)((-2.8))), ((V)(0.9)), ((V)("#e8283c"))))).Put("shell", Add(Call(pa_44, V.Undef, ((V)("M0 3.2L-3.8-1Q0-4.8 3.8-1Z")), ((V)("#ffc9a8")), ((V)("#d98a6a"))), Call(pa_44, V.Undef, ((V)("M0 3.2L-1.6-3.4M0 3.2L0-3.6M0 3.2L1.6-3.4")), V.Null, ((V)("#d98a6a")), ((V)(0.35))))).Put("leaf", Add(Call(pa_44, V.Undef, ((V)("M-3.6 3Q-3.6-3.6 3.6-3.6Q3.6 3-3.6 3Z")), ((V)("#7cc35a")), ((V)("#4f8f3a"))), Call(pa_44, V.Undef, ((V)("M-3.6 3L2.4-2.4")), V.Null, ((V)("#4f8f3a"))))).Put("honey", Add(Add(Call(pa_44, V.Undef, ((V)("M-2.8-1.4H2.8V2.6Q2.8 3.8 1.6 3.8H-1.6Q-2.8 3.8-2.8 2.6Z")), ((V)("#f2b43a")), ((V)("#c9861a"))), Call(pa_44, V.Undef, ((V)("M-3-2.8H3V-1.4H-3Z")), ((V)("#a86b36")))), Call(pa_44, V.Undef, ((V)("M-1.6 0.6H1.6")), V.Null, ((V)("#fff2c0")), ((V)(0.6))))).Put("bamboo", Add(Add(Call(pa_44, V.Undef, ((V)("M-0.9-4.2H0.9V4.2H-0.9Z")), ((V)("#8fc86a")), ((V)("#5f9a4a"))), Call(pa_44, V.Undef, ((V)("M-0.9-1.2H0.9M-0.9 1.8H0.9")), V.Null, ((V)("#5f9a4a")), ((V)(0.5)))), Call(pa_44, V.Undef, ((V)("M0.9-1.2Q3.4-2.6 3.8-0.8Q2.2-0.2 0.9-1.2Z")), ((V)("#7cc35a"))))).Put("acorn", Add(Add(Call(pa_44, V.Undef, ((V)("M-3-0.6Q0-3.6 3-0.6Z")), ((V)("#8a5a2c")), ((V)("#6a4220"))), Call(pa_44, V.Undef, ((V)("M-2.6-0.6Q-2.6 3.4 0 4Q2.6 3.4 2.6-0.6Z")), ((V)("#d39a5a")), ((V)("#a86b36")))), Call(pa_44, V.Undef, ((V)("M0-2.4L0.6-3.8")), V.Null, ((V)("#6a4220")), ((V)(0.6))))).Put("drop", Add(Call(pa_44, V.Undef, ((V)("M0-4Q3 0.2 2.4 1.6A2.6 2.6 0 0 1-2.4 1.6Q-3 0.2 0-4Z")), ((V)("#5ab4f0")), ((V)("#2e86c8"))), Call(ci_43, V.Undef, ((V)((-0.9))), ((V)(0.8)), ((V)(0.6)), ((V)("#fff"))))).Put("snow", Call(pa_44, V.Undef, ((V)("M0-4V4M-3.5-2L3.5 2M-3.5 2L3.5-2M-0.9-3.2L0-2.3L0.9-3.2M-0.9 3.2L0 2.3L0.9 3.2")), V.Null, ((V)("#6aaee6")), ((V)(0.7)))).Put("candy", Add(Add(Call(pa_44, V.Undef, ((V)("M-2.2 0L-4.2-1.8V1.8Z M2.2 0L4.2-1.8V1.8Z")), ((V)("#ffb84a")), ((V)("#d9861a"))), Call(ci_43, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(2.2)), ((V)("#ff8a4a")), ((V)("#d95a2a")))), Call(pa_44, V.Undef, ((V)("M-1.4-1Q0 0.4 1.4-1")), V.Null, ((V)("#fff2d8")), ((V)(0.5))))).Put("fire", Add(Call(pa_44, V.Undef, ((V)("M0 4Q-3.4 3.4-3 0Q-2.6-2 -1-2.6Q-1.4-1 0-0.6Q0.2-3 1.8-4.2Q1.6-2 2.8-0.8Q3.6 3.2 0 4Z")), ((V)("#ff8a2a")), ((V)("#d95a10"))), Call(pa_44, V.Undef, ((V)("M0 3.4Q-1.6 3-1.3 1.2Q-1 0.4 0 0.2Q0.4 1 1.2 1.2Q1.6 3 0 3.4Z")), ((V)("#ffd24a"))))).Put("berry", Add(Add(Call(pa_44, V.Undef, ((V)("M-3-1Q0-2 3-1Q2.4 3 0 4.2Q-2.4 3-3-1Z")), ((V)("#e8483c")), ((V)("#b8302a"))), Call(pa_44, V.Undef, ((V)("M-2.4-1.2L-1-2.6L0-1.6L1-2.6L2.4-1.2Q0-0.4-2.4-1.2Z")), ((V)("#5fae4a")))), Invoke(Invoke(Arr(Arr(((V)((-1.2))), ((V)(0.6))), Arr(((V)(1D)), ((V)(0.4))), Arr(((V)(0D)), ((V)(2D))), Arr(((V)((-1.4))), ((V)(2.2))), Arr(((V)(1.3)), ((V)(2D)))), "map", Fn((V _self1, int _argc2660, V _a2662, V _a2663, V _a2664, V _a2665, V[] _rest2661) => {
V x_2668 = default;
V y_2670 = default;
{ V _t2666 = ListOf(_a2662);
{ V _t2667 = GetIdx(_t2666, 0D);
x_2668 = _t2667; }
{ V _t2669 = GetIdx(_t2666, 1D);
y_2670 = _t2669; }
}
return Call(ci_43, V.Undef, x_2668, y_2670, ((V)(0.3)), ((V)("#ffe9a0")));
}, 1, "", true)), "join", ((V)(""))))).V;
ZB_48 = NewObj(10).Put("breathe", Fn((V _self2671, int _argc2672, V t_2678, V _a2675, V _a2676, V _a2677, V[] _rest2673) => {
V B_2679 = default;
if (_self2671.IsNullish) _self2671 = GlobalV;
B_2679 = Get(t_2678, "B");
Invoke(t_2678, "osc", ((V)(5600D)), ((V)(2D)), NewObj(2).Put("sq", Add(Get(B_2679, "sq"), ((V)(0.05)))).Put("lift", Add(Get(B_2679, "lift"), ((V)(0.5)))).V, NewObj(2).Put("sq", ((V)((ToNum(Get(B_2679, "sq")) - 0.015)))).Put("lift", Get(B_2679, "lift")).V, ((V)("s")));
return Invoke(t_2678, "back", ((V)(300D)), Arr(((V)("sq")), ((V)("lift"))));
return default;
}, 1, "breathe", false)).Put("snore", Fn((V _self2680, int _argc2681, V t_2687, V a_2688, V X_2689, V _a2686, V[] _rest2682) => {
V B_2690 = default;
if (_self2680.IsNullish) _self2680 = GlobalV;
B_2690 = Get(t_2687, "B");
Invoke(t_2687, "to", ((V)(300D)), NewObj(1).Put("zz", ((V)(1.8))).V);
{
double i_2691 = 0;
i_2691 = 0D;
while (true) {
if (!((i_2691 < 3D))) break;
Invoke(Invoke(t_2687, "to", ((V)(1000D)), NewObj(4).Put("sq", ((V)((ToNum(Get(B_2690, "sq")) - 0.03)))).Put("lift", Add(Get(B_2690, "lift"), ((V)(0.6)))).Put("open", ((V)(0.08))).Put("puff", ((V)(0D))).V, ((V)("s"))), "to", ((V)(700D)), Call(o_10, V.Undef, NewObj(5).Put("sq", Add(Get(B_2690, "sq"), ((V)(0.08)))).Put("lift", Get(B_2690, "lift")).Put("open", ((V)(0.45))).Put("mw", ((V)(0.55))).Put("puff", ((V)(0.5))).V, Get(X_2689, "snore")), ((V)("o")));
i_2691++;
}
}
Invoke(t_2687, "to", ((V)(400D)), NewObj(1).Put("zz", ((V)(1D))).V);
return Invoke(t_2687, "back", ((V)(500D)));
return default;
}, 3, "snore", false)).Put("dream", Fn((V _self2693, int _argc2694, V t_2700, V a_2701, V X_2702, V _a2699, V[] _rest2695) => {
if (_self2693.IsNullish) _self2693 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2700, "to", ((V)(700D)), Call(o_10, V.Undef, NewObj(4).Put("drm", ((V)(1D))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.3))).Put("htilt", Add((Get(Get(t_2700, "B"), "htilt") is var _t2703 && Truthy(_t2703) ? _t2703 : ((V)(0D))), ((V)(3D)))).V, Get(X_2702, "dream")), ((V)("s"))), "osc", ((V)(1800D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.14))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("s"))), "wait", ((V)(1600D))), "to", ((V)(600D)), NewObj(1).Put("drm", ((V)(0D))).V, ((V)("io")));
return Invoke(t_2700, "back", ((V)(600D)));
return default;
}, 3, "dream", false)).Put("roll", Fn((V _self2704, int _argc2705, V t_2711, V s_2712, V _a2709, V _a2710, V[] _rest2706) => {
V B_2713 = default;
if (_self2704.IsNullish) _self2704 = GlobalV;
B_2713 = Get(t_2711, "B");
s_2712 = (s_2712 is var _t2714 && Truthy(_t2714) ? _t2714 : ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(t_2711, "to", ((V)(1000D)), NewObj(6).Put("turn", Add((Get(B_2713, "turn") is var _t2715 && Truthy(_t2715) ? _t2715 : ((V)(0D))), ((V)((ToNum(s_2712) * 0.5))))).Put("tilt", Add((Get(B_2713, "tilt") is var _t2716 && Truthy(_t2716) ? _t2716 : ((V)(0D))), ((V)((ToNum(s_2712) * 12D))))).Put("x", ((V)((ToNum(s_2712) * 2.2)))).Put("htilt", ((V)((ToNum(s_2712) * 12D)))).Put("sq", Add(Get(B_2713, "sq"), ((V)(0.03)))).PutK(((V)((LtN(s_2712, 0D) ? "armL" : "armR"))), Add((Get(B_2713, "armL") is var _t2717 && Truthy(_t2717) ? _t2717 : ((V)(0D))), ((V)(12D)))).V, ((V)("s"))), "osc", ((V)(4400D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(B_2713, "sq"), ((V)(0.07)))).V, NewObj(1).Put("sq", Add(Get(B_2713, "sq"), ((V)(0.02)))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(1).Put("sqz", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("sqz", ((V)(0D))).V);
return Invoke(t_2711, "back", ((V)(1000D)));
return default;
}, 2, "roll", false)).Put("twitch", Fn((V _self2718, int _argc2719, V t_2725, V _a2722, V _a2723, V _a2724, V[] _rest2720) => {
V B_2726 = default;
if (_self2718.IsNullish) _self2718 = GlobalV;
B_2726 = Get(t_2725, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2725, "to", ((V)(90D)), NewObj(1).Put("earR", ((V)((-10D)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("earR", ((V)(4D))).V), "to", ((V)(140D)), NewObj(1).Put("earR", ((V)(0D))).V), "wait", ((V)(400D))), "to", ((V)(110D)), NewObj(1).Put("footL", Add((Get(B_2726, "footL") is var _t2728 && Truthy(_t2728) ? _t2728 : ((V)(0D))), ((V)(2.4)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("footL", (Get(B_2726, "footL") is var _t2727 && Truthy(_t2727) ? _t2727 : ((V)(0D)))).V), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(1).Put("sqz", ((V)(0.35))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("sqz", ((V)(0D))).V);
return Invoke(t_2725, "back", ((V)(300D)));
return default;
}, 1, "twitch", false)).Put("nuzzle", Fn((V _self2729, int _argc2730, V t_2736, V _a2733, V _a2734, V _a2735, V[] _rest2731) => {
V B_2737 = default;
if (_self2729.IsNullish) _self2729 = GlobalV;
B_2737 = Get(t_2736, "B");
Invoke(Invoke(t_2736, "to", ((V)(600D)), NewObj(4).Put("htilt", Add((Get(B_2737, "htilt") is var _t2738 && Truthy(_t2738) ? _t2738 : ((V)(0D))), ((V)(6D)))).Put("pitch", Add((Get(B_2737, "pitch") is var _t2739 && Truthy(_t2739) ? _t2739 : ((V)(0D))), ((V)(0.08)))).Put("sq", Add(Get(B_2737, "sq"), ((V)(0.04)))).Put("smile", ((V)(0.7))).V, ((V)("s"))), "osc", ((V)(1500D)), ((V)(3D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("s")));
return Invoke(t_2736, "back", ((V)(700D)));
return default;
}, 1, "nuzzle", false)).Put("curl", Fn((V _self2740, int _argc2741, V t_2747, V _a2744, V _a2745, V _a2746, V[] _rest2742) => {
V B_2748 = default;
if (_self2740.IsNullish) _self2740 = GlobalV;
B_2748 = Get(t_2747, "B");
Invoke(Invoke(t_2747, "to", ((V)(1000D)), NewObj(6).Put("curl", ((V)(1D))).Put("sq", Add(Get(B_2748, "sq"), ((V)(0.05)))).Put("pitch", ((V)((ToNum((Get(B_2748, "pitch") is var _t2749 && Truthy(_t2749) ? _t2749 : ((V)(0D)))) - 0.08)))).Put("htilt", Add((Get(B_2748, "htilt") is var _t2750 && Truthy(_t2750) ? _t2750 : ((V)(0D))), ((V)(3D)))).Put("footL", Add((Get(B_2748, "footL") is var _t2751 && Truthy(_t2751) ? _t2751 : ((V)(0D))), ((V)(0.6)))).Put("footR", Add((Get(B_2748, "footR") is var _t2752 && Truthy(_t2752) ? _t2752 : ((V)(0D))), ((V)(0.6)))).V, ((V)("s"))), "wait", ((V)(2000D)));
return Invoke(t_2747, "back", ((V)(900D)));
return default;
}, 1, "curl", false)).Put("peek", Fn((V _self2753, int _argc2754, V t_2760, V _a2757, V _a2758, V _a2759, V[] _rest2755) => {
if (_self2753.IsNullish) _self2753 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2760, "to", ((V)(300D)), NewObj(5).Put("close", ((V)(0D))).Put("winkL", ((V)(1D))).Put("lx", ((V)(0.5))).Put("ly", ((V)(0.3))).Put("zz", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(1300D))), "to", ((V)(500D)), NewObj(4).Put("close", ((V)(1D))).Put("winkL", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("zz", ((V)(1D))).V);
return Invoke(t_2760, "back", ((V)(300D)));
return default;
}, 1, "peek", false)).Put("knead", Fn((V _self2761, int _argc2762, V t_2768, V _a2765, V _a2766, V _a2767, V[] _rest2763) => {
V B_2769 = default;
if (_self2761.IsNullish) _self2761 = GlobalV;
B_2769 = Get(t_2768, "B");
Invoke(Invoke(t_2768, "to", ((V)(300D)), NewObj(1).Put("smile", ((V)(0.7))).V), "osc", ((V)(2400D)), ((V)(6D)), NewObj(3).Put("hLy", Add(Get(B_2769, "hLy"), ((V)(3D)))).Put("hRy", Get(B_2769, "hRy")).Put("sq", Add(Get(B_2769, "sq"), ((V)(0.01)))).V, NewObj(3).Put("hLy", Get(B_2769, "hLy")).Put("hRy", Add(Get(B_2769, "hRy"), ((V)(3D)))).Put("sq", Get(B_2769, "sq")).V, ((V)("s")));
return Invoke(t_2768, "back", ((V)(400D)));
return default;
}, 1, "knead", false)).Put("shift", Fn((V _self2770, int _argc2771, V t_2777, V _a2774, V _a2775, V _a2776, V[] _rest2772) => {
V B_2778 = default;
if (_self2770.IsNullish) _self2770 = GlobalV;
B_2778 = Get(t_2777, "B");
Invoke(Invoke(t_2777, "to", ((V)(1100D)), NewObj(5).Put("turn", ((V)((-ToNum((Get(B_2778, "turn") is var _t2779 && Truthy(_t2779) ? _t2779 : ((V)(0D)))))))).Put("tilt", ((V)((-ToNum((Get(B_2778, "tilt") is var _t2780 && Truthy(_t2780) ? _t2780 : ((V)(0D)))))))).Put("htilt", ((V)((-ToNum((Get(B_2778, "htilt") is var _t2781 && Truthy(_t2781) ? _t2781 : ((V)(0D)))))))).Put("lean", ((V)((-ToNum((Get(B_2778, "lean") is var _t2782 && Truthy(_t2782) ? _t2782 : ((V)(0D)))))))).Put("sq", Add(Get(B_2778, "sq"), ((V)(0.05)))).V, ((V)("s"))), "osc", ((V)(4000D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(B_2778, "sq"), ((V)(0.07)))).V, NewObj(1).Put("sq", Add(Get(B_2778, "sq"), ((V)(0.03)))).V, ((V)("s")));
return Invoke(t_2777, "back", ((V)(1100D)));
return default;
}, 1, "shift", false)).V;
SORD_49 = NewObj(3).Put("bed", Arr(((V)("breathe")), ((V)("dream")), ((V)("snore")), Arr(((V)("roll")), ((V)(1D))), ((V)("twitch")), ((V)("sig")), ((V)("breathe")), Arr(((V)("roll")), ((V)((-1D)))), ((V)("snore")), ((V)("nuzzle")))).Put("lie", Arr(((V)("breathe")), ((V)("dream")), Arr(((V)("roll")), ((V)((-1D)))), ((V)("snore")), ((V)("sig")), ((V)("twitch")), Arr(((V)("roll")), ((V)(1D))), ((V)("nuzzle")))).Put("bean", Arr(((V)("breathe")), ((V)("dream")), ((V)("curl")), ((V)("peek")), ((V)("sig")), ((V)("snore")), ((V)("knead")), ((V)("shift")))).V;
BED_54 = NewObj(0).V;
BATH0_56 = Call(o_10, V.Undef, NewObj(18).Put("sit", ((V)(1D))).Put("sq", ((V)(0.08))).Put("lift", ((V)(0D))).Put("sk", ((V)(9D))).Put("wd", ((V)(0.74))).Put("fm", ((V)(1D))).Put("dk", ((V)(1D))).Put("dkx", ((V)(0D))).Put("smile", ((V)(0.85))).Put("hap", ((V)(0.35))).Put("close", ((V)(0.2))).Put("pitch", ((V)(0.05))).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("wet", ((V)(0D))).Put("fh", ((V)(0D))).Put("spg", ((V)(0D))).Put("dv", ((V)(0D))).V, Call(both_13, V.Undef, ((V)(3D)), ((V)((-3D)))));
SHOW0_57 = NewObj(19).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("sk", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("shw", ((V)(1D))).Put("stm", ((V)(0.7))).Put("wet", ((V)(1D))).Put("close", ((V)(0.5))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.4))).Put("pitch", ((V)((-0.1)))).Put("fh", ((V)(0D))).Put("spg", ((V)(0D))).V;
SWIM0_58 = Call(o_10, V.Undef, NewObj(14).Put("sit", ((V)(0D))).Put("sq", ((V)(0.03))).Put("lift", ((V)(0D))).Put("sk", ((V)(7D))).Put("wd", ((V)(0.8))).Put("pitch", ((V)((-0.1)))).Put("smile", ((V)(0.7))).Put("hap", ((V)(0.3))).Put("armL", ((V)(38D))).Put("armR", ((V)(38D))).Put("wet", ((V)(0D))).Put("dv", ((V)(0D))).Put("fm", ((V)(0D))).Put("dk", ((V)(0D))).V, Call(both_13, V.Undef, ((V)(1D)), ((V)((-4D)))));
SWS_59 = NewObj(4).Put("paddle", NewObj(0).V).Put("glide", NewObj(5).Put("sk", ((V)(9D))).Put("wd", ((V)(0.86))).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("pitch", ((V)((-0.04)))).V).Put("float", NewObj(4).Put("sk", ((V)(2D))).Put("wd", ((V)(0.55))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V).Put("bob", NewObj(5).Put("sk", ((V)(5D))).Put("wd", ((V)(0.7))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("sq", ((V)(0.05))).V).V;
TB_62 = NewObj(7).Put("soak", Fn((V _self2783, int _argc2784, V t_2790, V _a2787, V _a2788, V _a2789, V[] _rest2785) => {
V B_2791 = default;
if (_self2783.IsNullish) _self2783 = GlobalV;
B_2791 = Get(t_2790, "B");
Invoke(Invoke(Invoke(Invoke(t_2790, "to", ((V)(900D)), NewObj(5).Put("sk", Add(Get(B_2791, "sk"), ((V)(2.5)))).Put("close", ((V)(0.85))).Put("smile", ((V)(1D))).Put("open", ((V)(0.15))).Put("sq", Add(Get(B_2791, "sq"), ((V)(0.04)))).V, ((V)("s"))), "wait", ((V)(1300D))), "to", ((V)(700D)), NewObj(1).Put("open", ((V)(0D))).V), "wait", ((V)(400D)));
return Invoke(t_2790, "back", ((V)(700D)));
return default;
}, 1, "soak", false)).Put("scrub", Fn((V _self2792, int _argc2793, V t_2799, V _a2796, V _a2797, V _a2798, V[] _rest2794) => {
V B_2800 = default;
if (_self2792.IsNullish) _self2792 = GlobalV;
B_2800 = Get(t_2799, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2799, "to", ((V)(300D)), NewObj(1).Put("spg", ((V)(1D))).V, ((V)("o"))), "to", ((V)(420D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-17D)))), NewObj(3).Put("armR", ((V)(118D))).Put("htilt", ((V)(5D))).Put("close", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(1500D)), ((V)(6D)), NewObj(3).Put("hRx", ((V)(2D))).Put("htilt", ((V)(7D))).Put("fh", ((V)(0.5))).V, NewObj(3).Put("hRx", ((V)((-4D)))).Put("htilt", ((V)(3D))).Put("fh", ((V)(0.8))).V, ((V)("s"))), "fx", ((V)("foam")), ((V)("head")), ((V)(2D))), "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-9D)))), NewObj(2).Put("armR", ((V)(40D))).Put("fh", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(2).Put("hRy", ((V)((-7D)))).Put("sqz", ((V)(0.5))).V, NewObj(2).Put("hRy", ((V)((-10D)))).Put("sqz", ((V)(0.2))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(2).Put("spg", ((V)(0D))).Put("sqz", ((V)(0D))).V);
return Invoke(t_2799, "back", ((V)(500D)), Arr(((V)("armR")), ((V)("hRx")), ((V)("hRy")), ((V)("htilt")), ((V)("close")), ((V)("sqz"))));
return default;
}, 1, "scrub", false)).Put("bubbles", Fn((V _self2801, int _argc2802, V t_2808, V _a2805, V _a2806, V _a2807, V[] _rest2803) => {
if (_self2801.IsNullish) _self2801 = GlobalV;
{
double i_2809 = 0;
i_2809 = 0D;
while (true) {
if (!((i_2809 < 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_2808, "to", ((V)(320D)), NewObj(3).Put("puff", ((V)(0.75))).Put("open", ((V)(0D))).Put("close", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.45))).V, ((V)("o"))), "fx", ((V)((NumTruthy(i_2809) ? "bigbubble" : "bubble"))), ((V)("mouth")), ((V)(2D))), "to", ((V)(700D)), NewObj(5).Put("ly", ((V)((-0.9)))).Put("lx", ((V)(0.5))).Put("wide", ((V)(0.5))).Put("open", ((V)(0.1))).Put("mw", ((V)(1D))).V, ((V)("s")));
i_2809++;
}
}
Invoke(Invoke(t_2808, "to", ((V)(300D)), NewObj(4).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "wait", ((V)(400D)));
return Invoke(t_2808, "back", ((V)(500D)));
return default;
}, 1, "bubbles", false)).Put("duck", Fn((V _self2811, int _argc2812, V t_2818, V _a2815, V _a2816, V _a2817, V[] _rest2813) => {
if (_self2811.IsNullish) _self2811 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2818, "to", ((V)(500D)), NewObj(4).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.5))).Put("turn", ((V)(0.22))).Put("htilt", ((V)(4D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(13D)), ((V)(0D))), NewObj(1).Put("armR", ((V)(30D))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(1).Put("dkx", ((V)((-0.25)))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(5).Put("dkx", ((V)(0.35))).Put("hRx", ((V)((-8D)))).Put("wide", ((V)(0.7))).Put("open", ((V)(0.45))).Put("hap", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("note")), ((V)("head"))), "to", ((V)(400D)), NewObj(2).Put("sqz", ((V)(0.7))).Put("smile", ((V)(1D))).V), "wait", ((V)(500D))), "to", ((V)(900D)), NewObj(1).Put("dkx", ((V)(0D))).V, ((V)("s")));
return Invoke(t_2818, "back", ((V)(500D)), Arr(((V)("lx")), ((V)("ly")), ((V)("turn")), ((V)("htilt")), ((V)("armR")), ((V)("hRx")), ((V)("hRy")), ((V)("wide")), ((V)("open")), ((V)("hap")), ((V)("sqz")), ((V)("smile"))));
return default;
}, 1, "duck", false)).Put("splash", Fn((V _self2819, int _argc2820, V t_2826, V _a2823, V _a2824, V _a2825, V[] _rest2821) => {
V B_2827 = default;
if (_self2819.IsNullish) _self2819 = GlobalV;
B_2827 = Get(t_2826, "B");
Invoke(t_2826, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V);
{
double i_2828 = 0;
i_2828 = 0D;
while (true) {
if (!((i_2828 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2826, "to", ((V)(220D)), NewObj(5).Put("armL", ((V)(75D))).Put("armR", ((V)(75D))).Put("hLy", ((V)((-8D)))).Put("hRy", ((V)((-8D)))).Put("lift", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(6).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("hLy", Get(B_2827, "hLy")).Put("hRy", Get(B_2827, "hRy")).Put("lift", ((V)(0D))).Put("sqz", ((V)(0.8))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("sideL")), ((V)(5D))), "fx", ((V)("splash")), ((V)("sideR")), ((V)(5D))), "to", ((V)(180D)), NewObj(1).Put("sqz", ((V)(0.3))).V);
i_2828++;
}
}
return Invoke(t_2826, "back", ((V)(420D)));
return default;
}, 1, "splash", false)).Put("foamhat", Fn((V _self2830, int _argc2831, V t_2837, V _a2834, V _a2835, V _a2836, V[] _rest2832) => {
if (_self2830.IsNullish) _self2830 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2837, "to", ((V)(1400D)), NewObj(4).Put("fh", ((V)(1.7))).Put("ly", ((V)((-1D)))).Put("pitch", ((V)(0.18))).Put("wide", ((V)(0.5))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(4).Put("sqz", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "wait", ((V)(400D))), "to", ((V)(320D)), NewObj(3).Put("puff", ((V)(0.8))).Put("ly", ((V)((-0.6)))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0.35))).Put("fh", ((V)(0D))).Put("pitch", ((V)((-0.05)))).V, ((V)("o"))), "fx", ((V)("foam")), ((V)("head")), ((V)(4D))), "fx", ((V)("bubble")), ((V)("head")), ((V)(3D))), "wait", ((V)(300D)));
return Invoke(t_2837, "back", ((V)(500D)));
return default;
}, 1, "foamhat", false)).Put("sing", Fn((V _self2838, int _argc2839, V t_2845, V _a2842, V _a2843, V _a2844, V[] _rest2840) => {
if (_self2838.IsNullish) _self2838 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2845, "to", ((V)(300D)), NewObj(4).Put("close", ((V)(0.6))).Put("smile", ((V)(0.9))).Put("open", ((V)(0.35))).Put("mw", ((V)(0.6))).V), "fx", ((V)("note")), ((V)("head"))), "osc", ((V)(2400D)), ((V)(4D)), NewObj(3).Put("htilt", ((V)(7D))).Put("x", ((V)(0.8))).Put("open", ((V)(0.45))).V, NewObj(3).Put("htilt", ((V)((-7D)))).Put("x", ((V)((-0.8)))).Put("open", ((V)(0.25))).V, ((V)("s"))), "fx", ((V)("note")), ((V)("head")));
return Invoke(t_2845, "back", ((V)(450D)));
return default;
}, 1, "sing", false)).V;
SB0_63 = NewObj(5).Put("lather", Fn((V _self2846, int _argc2847, V t_2853, V _a2850, V _a2851, V _a2852, V[] _rest2848) => {
if (_self2846.IsNullish) _self2846 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2853, "to", ((V)(380D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(4D)), ((V)((-18D)))), NewObj(4).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("close", ((V)(0.9))).Put("smile", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(1800D)), ((V)(6D)), NewObj(4).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-1D)))).Put("fh", ((V)(0.6))).Put("htilt", ((V)(4D))).V, NewObj(4).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-6D)))).Put("fh", ((V)(1D))).Put("htilt", ((V)((-4D)))).V, ((V)("s"))), "fx", ((V)("foam")), ((V)("head")), ((V)(3D))), "to", ((V)(420D)), NewObj(7).Put("armL", (Get(Get(t_2853, "B"), "armL") is var _t2854 && Truthy(_t2854) ? _t2854 : ((V)(0D)))).Put("armR", (Get(Get(t_2853, "B"), "armR") is var _t2855 && Truthy(_t2855) ? _t2855 : ((V)(0D)))).Put("hLx", (Get(Get(t_2853, "B"), "hLx") is var _t2856 && Truthy(_t2856) ? _t2856 : ((V)(0D)))).Put("hRx", (Get(Get(t_2853, "B"), "hRx") is var _t2857 && Truthy(_t2857) ? _t2857 : ((V)(0D)))).Put("hLy", (Get(Get(t_2853, "B"), "hLy") is var _t2858 && Truthy(_t2858) ? _t2858 : ((V)(0D)))).Put("hRy", (Get(Get(t_2853, "B"), "hRy") is var _t2859 && Truthy(_t2859) ? _t2859 : ((V)(0D)))).Put("fh", ((V)(1.1))).V, ((V)("io")));
return Invoke(t_2853, "back", ((V)(300D)), Arr(((V)("close")), ((V)("smile")), ((V)("htilt"))));
return default;
}, 1, "lather", false)).Put("rinse", Fn((V _self2860, int _argc2861, V t_2867, V _a2864, V _a2865, V _a2866, V[] _rest2862) => {
if (_self2860.IsNullish) _self2860 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2867, "to", ((V)(500D)), NewObj(4).Put("pitch", ((V)((-0.32)))).Put("close", ((V)(1D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("open", ((V)(0.45))).Put("puff", ((V)(0.3))).V, NewObj(2).Put("open", ((V)(0.15))).Put("puff", ((V)(0D))).V, ((V)("s"))), "to", ((V)(900D)), NewObj(1).Put("fh", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)("head")), ((V)(5D))), "to", ((V)(240D)), NewObj(4).Put("pitch", ((V)((-0.05)))).Put("close", ((V)(0D))).Put("wide", ((V)(0.5))).Put("open", ((V)(0.2))).V, ((V)("o"))), "e", ((V)("blink2")));
return Invoke(t_2867, "back", ((V)(500D)));
return default;
}, 1, "rinse", false)).Put("sing", Fn((V _self2868, int _argc2869, V t_2875, V _a2872, V _a2873, V _a2874, V[] _rest2870) => {
if (_self2868.IsNullish) _self2868 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2875, "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-12D)))), NewObj(4).Put("armR", ((V)(34D))).Put("close", ((V)(0.55))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.6))).V), ((V)("io"))), "fx", ((V)("note")), ((V)("head"))), "osc", ((V)(2600D)), ((V)(4D)), NewObj(3).Put("htilt", ((V)(8D))).Put("lean", ((V)(0.8))).Put("open", ((V)(0.55))).V, NewObj(3).Put("htilt", ((V)((-8D)))).Put("lean", ((V)((-0.8)))).Put("open", ((V)(0.3))).V, ((V)("s"))), "fx", ((V)("note")), ((V)("head"))), "fx", ((V)("note")), ((V)("head")));
return Invoke(t_2875, "back", ((V)(500D)));
return default;
}, 1, "sing", false)).Put("turn", Fn((V _self2876, int _argc2877, V t_2883, V _a2880, V _a2881, V _a2882, V[] _rest2878) => {
if (_self2876.IsNullish) _self2876 = GlobalV;
Invoke(Invoke(t_2883, "to", ((V)(1800D)), NewObj(2).Put("spin", ((V)(360D))).Put("close", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V);
return Invoke(t_2883, "back", ((V)(300D)), Arr(((V)("close"))));
return default;
}, 1, "turn", false)).Put("shiver", Fn((V _self2884, int _argc2885, V t_2891, V _a2888, V _a2889, V _a2890, V[] _rest2886) => {
if (_self2884.IsNullish) _self2884 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2891, "to", ((V)(120D)), NewObj(6).Put("wide", ((V)(1D))).Put("sq", ((V)((ToNum((Get(Get(t_2891, "B"), "sq") is var _t2892 && Truthy(_t2892) ? _t2892 : ((V)(0D)))) - 0.05)))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.5))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("o"))), "osc", ((V)(600D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(240D)), NewObj(2).Put("sqz", ((V)(0.6))).Put("wide", ((V)(0D))).V), "to", ((V)(300D)), NewObj(2).Put("sqz", ((V)(0D))).Put("smile", ((V)(1D))).V);
return Invoke(t_2891, "back", ((V)(420D)));
return default;
}, 1, "shiver", false)).V;
WB0_64 = NewObj(5).Put("back", Fn((V _self2893, int _argc2894, V t_2900, V _a2897, V _a2898, V _a2899, V[] _rest2895) => {
V B_2901 = default;
if (_self2893.IsNullish) _self2893 = GlobalV;
B_2901 = Get(t_2900, "B");
Invoke(Invoke(t_2900, "to", ((V)(800D)), NewObj(10).Put("pitch", ((V)(0.45))).Put("sk", ((V)((ToNum(Get(B_2901, "sk")) - 2.5)))).Put("wd", ((V)((ToNum(Get(B_2901, "wd")) * 0.85)))).Put("close", ((V)(0.75))).Put("smile", ((V)(1D))).Put("armL", ((V)(96D))).Put("armR", ((V)(96D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("tilt", ((V)(0D))).V, ((V)("s"))), "osc", ((V)(2600D)), ((V)(2D)), NewObj(2).Put("lift", Add((Get(B_2901, "lift") is var _t2902 && Truthy(_t2902) ? _t2902 : ((V)(0D))), ((V)(0.8)))).Put("tilt", ((V)(2D))).V, NewObj(2).Put("lift", (Get(B_2901, "lift") is var _t2903 && Truthy(_t2903) ? _t2903 : ((V)(0D)))).Put("tilt", ((V)((-2D)))).V, ((V)("s")));
return Invoke(t_2900, "back", ((V)(800D)));
return default;
}, 1, "back", false)).Put("dive", Fn((V _self2904, int _argc2905, V t_2911, V _a2908, V _a2909, V _a2910, V[] _rest2906) => {
if (_self2904.IsNullish) _self2904 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2911, "to", ((V)(300D)), NewObj(3).Put("puff", ((V)(0.7))).Put("close", ((V)(1D))).Put("wide", ((V)(0D))).V, ((V)("io"))), "to", ((V)(420D)), NewObj(2).Put("dv", ((V)(1D))).Put("sq", ((V)((ToNum((Get(Get(t_2911, "B"), "sq") is var _t2916 && Truthy(_t2916) ? _t2916 : ((V)(0D)))) - 0.05)))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("head")), ((V)(5D))), "wait", ((V)(300D))), "fx", ((V)("bubble")), ((V)("head")), ((V)(3D))), "wait", ((V)(600D))), "fx", ((V)("bubble")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D))), "to", ((V)(240D)), NewObj(7).Put("dv", ((V)(0D))).Put("puff", ((V)(0D))).Put("lift", Add((Get(Get(t_2911, "B"), "lift") is var _t2914 && Truthy(_t2914) ? _t2914 : ((V)(0D))), ((V)(3D)))).Put("sq", ((V)((ToNum((Get(Get(t_2911, "B"), "sq") is var _t2915 && Truthy(_t2915) ? _t2915 : ((V)(0D)))) - 0.08)))).Put("close", ((V)(0D))).Put("wide", ((V)(0.8))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("splash")), ((V)("head")), ((V)(7D))), "to", ((V)(240D)), NewObj(2).Put("lift", (Get(Get(t_2911, "B"), "lift") is var _t2912 && Truthy(_t2912) ? _t2912 : ((V)(0D)))).Put("sq", (Get(Get(t_2911, "B"), "sq") is var _t2913 && Truthy(_t2913) ? _t2913 : ((V)(0D)))).V, ((V)("i"))), "osc", ((V)(500D)), ((V)(4D)), NewObj(1).Put("htilt", ((V)(9D))).V, NewObj(1).Put("htilt", ((V)((-9D)))).V, ((V)("l"))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D)));
return Invoke(t_2911, "back", ((V)(400D)));
return default;
}, 1, "dive", false)).Put("splash", Fn((V _self2917, int _argc2918, V t_2924, V _a2921, V _a2922, V _a2923, V[] _rest2919) => {
if (_self2917.IsNullish) _self2917 = GlobalV;
Invoke(TB_62, "splash", t_2924);
return t_2924;
return default;
}, 1, "splash", false)).Put("spout", Fn((V _self2925, int _argc2926, V t_2932, V _a2929, V _a2930, V _a2931, V[] _rest2927) => {
if (_self2925.IsNullish) _self2925 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2932, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.8))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gush")), ((V)("mouth")), ((V)(4D))), "fx", ((V)("splash")), ((V)("mouth")), ((V)(4D))), "wait", ((V)(260D))), "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).V), "wait", ((V)(300D)));
return Invoke(t_2932, "back", ((V)(400D)));
return default;
}, 1, "spout", false)).Put("wave", Fn((V _self2933, int _argc2934, V t_2940, V _a2937, V _a2938, V _a2939, V[] _rest2935) => {
if (_self2933.IsNullish) _self2933 = GlobalV;
Invoke(BEAT_16, "wave", t_2940, ((V)(1D)));
return t_2940;
return default;
}, 1, "wave", false)).V;
WORD_65 = NewObj(3).Put("tub", Arr(((V)("soak")), ((V)("scrub")), ((V)("bubbles")), ((V)("duck")), ((V)("sig")), ((V)("splash")), ((V)("foamhat")), ((V)("sing")))).Put("shower", Arr(((V)("lather")), ((V)("rinse")), ((V)("sing")), ((V)("sig")), ((V)("turn")), ((V)("shiver")))).Put("swim", Arr(((V)("back")), ((V)("splash")), ((V)("dive")), ((V)("sig")), ((V)("spout")), ((V)("wave")))).V;
WAT_73 = NewObj(0).V;
Set(ICON_45, "cookie", Add(Add(Add(Add(Add(Call(ci_43, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(3.6)), ((V)("#e2a85a")), ((V)("#a8702e"))), Call(ci_43, V.Undef, ((V)((-1.2))), ((V)((-1.1))), ((V)(0.6)), ((V)("#5a3420")))), Call(ci_43, V.Undef, ((V)(1.4)), ((V)((-0.3))), ((V)(0.7)), ((V)("#5a3420")))), Call(ci_43, V.Undef, ((V)((-0.3))), ((V)(1.5)), ((V)(0.6)), ((V)("#5a3420")))), Call(ci_43, V.Undef, ((V)(1.7)), ((V)(1.9)), ((V)(0.4)), ((V)("#5a3420")))), Call(ci_43, V.Undef, ((V)((-1.9))), ((V)(0.9)), ((V)(0.4)), ((V)("#5a3420")))));
SWG0_75 = NewObj(8).Put("armL", ((V)(118D))).Put("armR", ((V)(118D))).Put("hLx", ((V)((-1D)))).Put("hRx", ((V)(1D))).Put("hLy", ((V)((-3D)))).Put("hRy", ((V)((-3D)))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.4))).V;
RID0_76 = Call(o_10, V.Undef, NewObj(6).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("smile", ((V)(0.85))).Put("hap", ((V)(0.4))).Put("footL", ((V)(0.8))).Put("footR", ((V)(0.8))).V, Call(both_13, V.Undef, ((V)(10D)), ((V)((-3D)))));
CK0_77 = Call(o_10, V.Undef, NewObj(8).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.6))).Put("smile", ((V)(0.6))).Put("hap", ((V)(0.2))).Put("armR", ((V)(40D))).Put("armL", ((V)(14D))).V, Call(hand_12, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-3D)))), Call(hand_12, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)(2D))));
PB_78 = NewObj(6).Put("wheee", Fn((V _self2941, int _argc2942, V t_2948, V X_2949, V _a2946, V _a2947, V[] _rest2943) => {
V B_2950 = default;
if (_self2941.IsNullish) _self2941 = GlobalV;
B_2950 = Get(t_2948, "B");
Invoke(t_2948, "to", ((V)(300D)), Call(o_10, V.Undef, NewObj(8).Put("open", ((V)(0.6))).Put("mw", ((V)(0.6))).Put("wide", ((V)(0.8))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("pitch", Add((Get(B_2950, "pitch") is var _t2951 && Truthy(_t2951) ? _t2951 : ((V)(0D))), ((V)(0.16)))).Put("footL", Add((Get(B_2950, "footL") is var _t2952 && Truthy(_t2952) ? _t2952 : ((V)(0D))), ((V)(3D)))).Put("footR", Add((Get(B_2950, "footR") is var _t2953 && Truthy(_t2953) ? _t2953 : ((V)(0D))), ((V)(3D)))).V, Get(X_2949, "cheer")), ((V)("o")));
if (Truthy(Get(X_2949, "cheerFx"))) {
InvokeSpread(t_2948, "fx", new ArrBuilder().Spread(Get(X_2949, "cheerFx")).V);
} else {
Invoke(t_2948, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
}
Invoke(t_2948, "wait", ((V)(1300D)));
return Invoke(t_2948, "back", ((V)(500D)));
return default;
}, 2, "wheee", false)).Put("breeze", Fn((V _self2954, int _argc2955, V t_2961, V _a2958, V _a2959, V _a2960, V[] _rest2956) => {
V B_2962 = default;
if (_self2954.IsNullish) _self2954 = GlobalV;
B_2962 = Get(t_2961, "B");
Invoke(Invoke(t_2961, "to", ((V)(800D)), NewObj(7).Put("pitch", Add((Get(B_2962, "pitch") is var _t2963 && Truthy(_t2963) ? _t2963 : ((V)(0D))), ((V)(0.3)))).Put("close", ((V)(0.85))).Put("smile", ((V)(1D))).Put("open", ((V)(0.15))).Put("footL", Add((Get(B_2962, "footL") is var _t2964 && Truthy(_t2964) ? _t2964 : ((V)(0D))), ((V)(2.4)))).Put("footR", Add((Get(B_2962, "footR") is var _t2965 && Truthy(_t2965) ? _t2965 : ((V)(0D))), ((V)(2.4)))).Put("htilt", ((V)(5D))).V, ((V)("s"))), "wait", ((V)(1800D)));
return Invoke(t_2961, "back", ((V)(700D)));
return default;
}, 1, "breeze", false)).Put("peek", Fn((V _self2966, int _argc2967, V t_2973, V _a2970, V _a2971, V _a2972, V[] _rest2968) => {
V B_2974 = default;
if (_self2966.IsNullish) _self2966 = GlobalV;
B_2974 = Get(t_2973, "B");
Invoke(Invoke(Invoke(Invoke(t_2973, "to", ((V)(380D)), NewObj(6).Put("pitch", ((V)((ToNum((Get(B_2974, "pitch") is var _t2977 && Truthy(_t2977) ? _t2977 : ((V)(0D)))) - 0.24)))).Put("ly", ((V)(0.9))).Put("wide", ((V)(1D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).Put("sq", ((V)((ToNum((Get(B_2974, "sq") is var _t2978 && Truthy(_t2978) ? _t2978 : ((V)(0D)))) - 0.03)))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(220D)), NewObj(6).Put("sqz", ((V)(0.8))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("wide", ((V)(0D))).Put("ly", ((V)(0.3))).Put("open", ((V)(0.35))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(4D)), NewObj(1).Put("sq", Add((Get(B_2974, "sq") is var _t2975 && Truthy(_t2975) ? _t2975 : ((V)(0D))), ((V)(0.03)))).V, NewObj(1).Put("sq", (Get(B_2974, "sq") is var _t2976 && Truthy(_t2976) ? _t2976 : ((V)(0D)))).V, ((V)("o")));
return Invoke(t_2973, "back", ((V)(450D)));
return default;
}, 1, "peek", false)).Put("onehand", Fn((V _self2979, int _argc2980, V t_2986, V _a2983, V _a2984, V _a2985, V[] _rest2981) => {
if (_self2979.IsNullish) _self2979 = GlobalV;
Invoke(Invoke(t_2986, "to", ((V)(380D)), NewObj(7).Put("armR", ((V)(152D))).Put("hRx", ((V)(3D))).Put("hRy", ((V)((-5D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("htilt", ((V)(5D))).V, ((V)("o"))), "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("armR", ((V)(136D))).V, NewObj(1).Put("armR", ((V)(168D))).V, ((V)("io")));
return Invoke(t_2986, "back", ((V)(480D)));
return default;
}, 1, "onehand", false)).Put("higher", Fn((V _self2987, int _argc2988, V t_2994, V _a2991, V _a2992, V _a2993, V[] _rest2989) => {
V B_2995 = default;
V f_2996 = default;
V g_2997 = default;
V p0_2998 = default;
if (_self2987.IsNullish) _self2987 = GlobalV;
B_2995 = Get(t_2994, "B");
f_2996 = (Get(B_2995, "footL") is var _t2999 && Truthy(_t2999) ? _t2999 : ((V)(0D)));
g_2997 = (Get(B_2995, "footR") is var _t3000 && Truthy(_t3000) ? _t3000 : ((V)(0D)));
p0_2998 = (Get(B_2995, "pitch") is var _t3001 && Truthy(_t3001) ? _t3001 : ((V)(0D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_2994, "to", ((V)(260D)), NewObj(4).Put("sqz", ((V)(0.3))).Put("smile", ((V)(1D))).Put("mw", ((V)(0.7))).Put("open", ((V)(0.2))).V), "osc", ((V)(1800D)), ((V)(4D)), NewObj(4).Put("footL", Add(f_2996, ((V)(3.4)))).Put("footR", Add(g_2997, ((V)(3.4)))).Put("lean", ((V)(1.2))).Put("pitch", Add(p0_2998, ((V)(0.12)))).V, NewObj(4).Put("footL", ((V)((ToNum(f_2996) - 0.4)))).Put("footR", ((V)((ToNum(g_2997) - 0.4)))).Put("lean", ((V)((-1.2)))).Put("pitch", ((V)((ToNum(p0_2998) - 0.06)))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(4).Put("sqz", ((V)(0D))).Put("wide", ((V)(0.6))).Put("hap", ((V)(1D))).Put("open", ((V)(0.45))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(400D)));
return Invoke(t_2994, "back", ((V)(500D)));
return default;
}, 1, "higher", false)).Put("giggle", Fn((V _self3002, int _argc3003, V t_3009, V _a3006, V _a3007, V _a3008, V[] _rest3004) => {
V B_3010 = default;
if (_self3002.IsNullish) _self3002 = GlobalV;
B_3010 = Get(t_3009, "B");
Invoke(Invoke(t_3009, "to", ((V)(260D)), NewObj(5).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.7))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("blush", ((V)(0.5))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(5D)), NewObj(2).Put("sq", Add((Get(B_3010, "sq") is var _t3011 && Truthy(_t3011) ? _t3011 : ((V)(0D))), ((V)(0.03)))).Put("htilt", ((V)(4D))).V, NewObj(2).Put("sq", (Get(B_3010, "sq") is var _t3012 && Truthy(_t3012) ? _t3012 : ((V)(0D)))).Put("htilt", ((V)((-4D)))).V, ((V)("o")));
return Invoke(t_3009, "back", ((V)(450D)));
return default;
}, 1, "giggle", false)).V;
RB_79 = NewObj(6).Put("gallop", Fn((V _self3013, int _argc3014, V t_3020, V _a3017, V _a3018, V _a3019, V[] _rest3015) => {
V B_3021 = default;
V L_3022 = default;
V Q_3023 = default;
V f_3024 = default;
V g_3025 = default;
if (_self3013.IsNullish) _self3013 = GlobalV;
B_3021 = Get(t_3020, "B");
L_3022 = (Get(B_3021, "lift") is var _t3026 && Truthy(_t3026) ? _t3026 : ((V)(0D)));
Q_3023 = (Get(B_3021, "sq") is var _t3027 && Truthy(_t3027) ? _t3027 : ((V)(0D)));
f_3024 = (Get(B_3021, "footL") is var _t3028 && Truthy(_t3028) ? _t3028 : ((V)(0D)));
g_3025 = (Get(B_3021, "footR") is var _t3029 && Truthy(_t3029) ? _t3029 : ((V)(0D)));
Invoke(Invoke(t_3020, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).V), "osc", ((V)(1500D)), ((V)(6D)), NewObj(4).Put("footL", Add(f_3024, ((V)(2.6)))).Put("footR", Add(g_3025, ((V)(2.6)))).Put("sq", Add(Q_3023, ((V)(0.05)))).Put("lift", L_3022).V, NewObj(4).Put("footL", f_3024).Put("footR", g_3025).Put("sq", ((V)((ToNum(Q_3023) - 0.02)))).Put("lift", Add(L_3022, ((V)(1.4)))).V, ((V)("o")));
return Invoke(t_3020, "back", ((V)(400D)));
return default;
}, 1, "gallop", false)).Put("yeehaw", Fn((V _self3030, int _argc3031, V t_3037, V X_3038, V _a3035, V _a3036, V[] _rest3032) => {
if (_self3030.IsNullish) _self3030 = GlobalV;
Invoke(t_3037, "to", ((V)(320D)), Call(o_10, V.Undef, NewObj(9).Put("armR", ((V)(158D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-8D)))).Put("open", ((V)(0.55))).Put("mw", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("wide", ((V)(0.4))).Put("htilt", ((V)((-4D)))).V, Get(X_3038, "cheer")), ((V)("o")));
{
double i_3039 = 0;
i_3039 = 0D;
while (true) {
if (!((i_3039 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(t_3037, "to", ((V)(150D)), NewObj(2).Put("hRx", ((V)(4D))).Put("hRy", ((V)((-10D)))).V, ((V)("l"))), "to", ((V)(150D)), NewObj(2).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-13D)))).V, ((V)("l"))), "to", ((V)(150D)), NewObj(2).Put("hRx", ((V)((-4D)))).Put("hRy", ((V)((-10D)))).V, ((V)("l"))), "to", ((V)(150D)), NewObj(2).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-7D)))).V, ((V)("l")));
i_3039++;
}
}
Invoke(t_3037, "fx", ((V)("note")), ((V)("head")));
return Invoke(t_3037, "back", ((V)(450D)));
return default;
}, 2, "yeehaw", false)).Put("race", Fn((V _self3041, int _argc3042, V t_3048, V _a3045, V _a3046, V _a3047, V[] _rest3043) => {
V B_3049 = default;
if (_self3041.IsNullish) _self3041 = GlobalV;
B_3049 = Get(t_3048, "B");
Invoke(Invoke(t_3048, "to", ((V)(500D)), NewObj(8).Put("pitch", ((V)((ToNum((Get(B_3049, "pitch") is var _t3050 && Truthy(_t3050) ? _t3050 : ((V)(0D)))) - 0.2)))).Put("sq", Add((Get(B_3049, "sq") is var _t3051 && Truthy(_t3051) ? _t3051 : ((V)(0D))), ((V)(0.03)))).Put("wide", ((V)(0.6))).Put("sqz", ((V)(0.25))).Put("smile", ((V)(1D))).Put("mw", ((V)(0.7))).Put("hLy", Add((Get(B_3049, "hLy") is var _t3052 && Truthy(_t3052) ? _t3052 : ((V)(0D))), ((V)(3D)))).Put("hRy", Add((Get(B_3049, "hRy") is var _t3053 && Truthy(_t3053) ? _t3053 : ((V)(0D))), ((V)(3D)))).V, ((V)("io"))), "osc", ((V)(1400D)), ((V)(4D)), NewObj(1).Put("lean", ((V)(0.8))).V, NewObj(1).Put("lean", ((V)((-0.4)))).V, ((V)("s")));
return Invoke(t_3048, "back", ((V)(500D)));
return default;
}, 1, "race", false)).Put("whoa", Fn((V _self3054, int _argc3055, V t_3061, V _a3058, V _a3059, V _a3060, V[] _rest3056) => {
V B_3062 = default;
if (_self3054.IsNullish) _self3054 = GlobalV;
B_3062 = Get(t_3061, "B");
Invoke(Invoke(Invoke(Invoke(t_3061, "to", ((V)(300D)), NewObj(8).Put("pitch", Add((Get(B_3062, "pitch") is var _t3063 && Truthy(_t3063) ? _t3063 : ((V)(0D))), ((V)(0.26)))).Put("hLy", Add((Get(B_3062, "hLy") is var _t3064 && Truthy(_t3064) ? _t3064 : ((V)(0D))), ((V)(5D)))).Put("hRy", Add((Get(B_3062, "hRy") is var _t3065 && Truthy(_t3065) ? _t3065 : ((V)(0D))), ((V)(5D)))).Put("hLx", ((V)((ToNum((Get(B_3062, "hLx") is var _t3066 && Truthy(_t3066) ? _t3066 : ((V)(0D)))) - 3D)))).Put("hRx", Add((Get(B_3062, "hRx") is var _t3067 && Truthy(_t3067) ? _t3067 : ((V)(0D))), ((V)(3D)))).Put("wide", ((V)(0.8))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "wait", ((V)(700D))), "to", ((V)(240D)), NewObj(5).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("wide", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(300D)));
return Invoke(t_3061, "back", ((V)(500D)));
return default;
}, 1, "whoa", false)).Put("pat", Fn((V _self3068, int _argc3069, V t_3075, V _a3072, V _a3073, V _a3074, V[] _rest3070) => {
if (_self3068.IsNullish) _self3068 = GlobalV;
Invoke(Invoke(Invoke(t_3075, "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(14D)), ((V)(4D))), NewObj(6).Put("armR", ((V)(16D))).Put("htilt", ((V)(5D))).Put("lx", ((V)(0.4))).Put("ly", ((V)(0.5))).Put("smile", ((V)(1D))).Put("close", ((V)(0.3))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(3D)), NewObj(1).Put("hRy", ((V)(7D))).V, NewObj(1).Put("hRy", ((V)(3D))).V, ((V)("o"))), "fx", ((V)("heart")), ((V)("head")));
return Invoke(t_3075, "back", ((V)(450D)));
return default;
}, 1, "pat", false)).Put("cheer", Fn((V _self3076, int _argc3077, V t_3083, V X_3084, V _a3081, V _a3082, V[] _rest3078) => {
if (_self3076.IsNullish) _self3076 = GlobalV;
Invoke(WBEAT_30, "cheer", t_3083, X_3084);
return t_3083;
return default;
}, 2, "cheer", false)).V;
PORD_80 = NewObj(2).Put("swing", Arr(((V)("wheee")), ((V)("peek")), ((V)("sig")), ((V)("breeze")), ((V)("onehand")), ((V)("higher")), ((V)("giggle")), ((V)("kick")))).Put("ride", Arr(((V)("gallop")), ((V)("yeehaw")), ((V)("pat")), ((V)("sig")), ((V)("race")), ((V)("whoa")), ((V)("cheer")))).V;
CB_84 = NewObj(6).Put("stir", Fn((V _self3085, int _argc3086, V t_3092, V _a3089, V _a3090, V _a3091, V[] _rest3087) => {
V B_3093 = default;
V x0_3094 = default;
V y0_3095 = default;
if (_self3085.IsNullish) _self3085 = GlobalV;
B_3093 = Get(t_3092, "B");
x0_3094 = (Get(B_3093, "hRx") is var _t3096 && Truthy(_t3096) ? _t3096 : ((V)(0D)));
y0_3095 = (Get(B_3093, "hRy") is var _t3097 && Truthy(_t3097) ? _t3097 : ((V)(0D)));
Invoke(t_3092, "to", ((V)(200D)), NewObj(1).Put("ly", ((V)(0.8))).V);
{
double i_3098 = 0;
i_3098 = 0D;
while (true) {
if (!((i_3098 < 4D))) break;
Invoke(Invoke(Invoke(Invoke(t_3092, "to", ((V)(170D)), NewObj(3).Put("hRx", ((V)((ToNum(x0_3094) - 3D)))).Put("hRy", Add(y0_3095, ((V)(1.5)))).Put("htilt", ((V)(3D))).V, ((V)("l"))), "to", ((V)(170D)), NewObj(2).Put("hRx", x0_3094).Put("hRy", Add(y0_3095, ((V)(3D)))).V, ((V)("l"))), "to", ((V)(170D)), NewObj(3).Put("hRx", Add(x0_3094, ((V)(3D)))).Put("hRy", Add(y0_3095, ((V)(1.5)))).Put("htilt", ((V)((-3D)))).V, ((V)("l"))), "to", ((V)(170D)), NewObj(2).Put("hRx", x0_3094).Put("hRy", y0_3095).V, ((V)("l")));
i_3098++;
}
}
Invoke(t_3092, "fx", ((V)("steam")), ((V)("pawR")));
return Invoke(t_3092, "back", ((V)(300D)));
return default;
}, 1, "stir", false)).Put("season", Fn((V _self3100, int _argc3101, V t_3107, V _a3104, V _a3105, V _a3106, V[] _rest3102) => {
if (_self3100.IsNullish) _self3100 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_3107, "to", ((V)(340D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)(12D)), ((V)((-10D)))), NewObj(3).Put("armL", ((V)(44D))).Put("htilt", ((V)((-5D)))).Put("close", ((V)(0.3))).V), ((V)("io"))), "osc", ((V)(450D)), ((V)(3D)), NewObj(2).Put("hLy", ((V)((-12D)))).Put("hLx", ((V)(13D))).V, NewObj(2).Put("hLy", ((V)((-9D)))).Put("hLx", ((V)(11D))).V, ((V)("l"))), "fx", ((V)("salt")), ((V)("pawL")), ((V)(3D))), "osc", ((V)(450D)), ((V)(3D)), NewObj(2).Put("hLy", ((V)((-12D)))).Put("hLx", ((V)(13D))).V, NewObj(2).Put("hLy", ((V)((-9D)))).Put("hLx", ((V)(11D))).V, ((V)("l"))), "fx", ((V)("salt")), ((V)("pawL")), ((V)(3D)));
return Invoke(t_3107, "back", ((V)(400D)));
return default;
}, 1, "season", false)).Put("shake", Fn((V _self3108, int _argc3109, V t_3115, V _a3112, V _a3113, V _a3114, V[] _rest3110) => {
if (_self3108.IsNullish) _self3108 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_3115, "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-2D)))), NewObj(3).Put("armR", ((V)(44D))).Put("ly", ((V)(0.7))).Put("lx", ((V)(0.5))).V), ((V)("io"))), "osc", ((V)(600D)), ((V)(4D)), NewObj(2).Put("hRx", ((V)((-4D)))).Put("hRy", ((V)((-3D)))).V, NewObj(2).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-1D)))).V, ((V)("l"))), "fx", ((V)("steam")), ((V)("pawR"))), "osc", ((V)(600D)), ((V)(4D)), NewObj(2).Put("hRx", ((V)((-4D)))).Put("hRy", ((V)((-3D)))).V, NewObj(2).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-1D)))).V, ((V)("l"))), "fx", ((V)("steam")), ((V)("pawR")));
return Invoke(t_3115, "back", ((V)(350D)));
return default;
}, 1, "shake", false)).Put("flip", Fn((V _self3116, int _argc3117, V t_3123, V X_3124, V rec_3125, V _a3122, V[] _rest3118) => {
V B_3126 = default;
V Q_3127 = default;
V p0_3128 = default;
if (_self3116.IsNullish) _self3116 = GlobalV;
B_3126 = Get(t_3123, "B");
Q_3127 = (Get(B_3126, "sq") is var _t3129 && Truthy(_t3129) ? _t3129 : ((V)(0D)));
p0_3128 = (Get(B_3126, "pitch") is var _t3130 && Truthy(_t3130) ? _t3130 : ((V)(0D)));
Invoke(Invoke(t_3123, "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-1D)))), NewObj(2).Put("armR", ((V)(42D))).Put("lx", ((V)(0.5))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hRy", ((V)(2D))).Put("sq", Add(Q_3127, ((V)(0.04)))).V, ((V)("io")));
Invoke(rec_3125, "push", Get(t_3123, "t"));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3123, "to", ((V)(160D)), NewObj(8).Put("armR", ((V)(66D))).Put("hRy", ((V)((-6D)))).Put("sq", ((V)((ToNum(Q_3127) - 0.04)))).Put("lx", ((V)(0.6))).Put("ly", ((V)((-0.9)))).Put("pitch", Add(p0_3128, ((V)(0.24)))).Put("wide", ((V)(0.7))).Put("open", ((V)(0.35))).V, ((V)("o"))), "to", ((V)(520D)), NewObj(3).Put("armR", ((V)(48D))).Put("hRy", ((V)((-2D)))).Put("ly", ((V)((-1D)))).V, ((V)("io"))), "to", ((V)(320D)), NewObj(2).Put("ly", ((V)(0.7))).Put("pitch", ((V)((ToNum(p0_3128) - 0.06)))).V, ((V)("i"))), "to", ((V)(140D)), NewObj(2).Put("sq", Add(Q_3127, ((V)(0.05)))).Put("hRy", ((V)(1D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(6).Put("sq", Q_3127).Put("sqz", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("wide", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(400D)));
return Invoke(t_3123, "back", ((V)(450D)));
return default;
}, 3, "flip", false)).Put("taste", Fn((V _self3131, int _argc3132, V t_3138, V X_3139, V _a3136, V _a3137, V[] _rest3133) => {
V B_3140 = default;
if (_self3131.IsNullish) _self3131 = GlobalV;
B_3140 = Get(t_3138, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3138, "to", ((V)(420D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-13D)))), NewObj(4).Put("armR", ((V)(36D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("pitch", Add((Get(B_3140, "pitch") is var _t3141 && Truthy(_t3141) ? _t3141 : ((V)(0D))), ((V)(0.04)))).V), ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.6))).Put("open", ((V)(0D))).V), "to", ((V)(260D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("pawR"))), "to", ((V)(300D)), NewObj(3).Put("open", ((V)(0.25))).Put("close", ((V)(0.7))).Put("mw", ((V)(0.8))).V), "osc", ((V)(600D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.15))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(6).Put("lx", ((V)(0.6))).Put("ly", ((V)((-0.6)))).Put("htilt", ((V)(7D))).Put("close", ((V)(0D))).Put("hRy", ((V)((-6D)))).Put("armR", ((V)(24D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(260D)), Call(o_10, V.Undef, NewObj(5).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.7))).Put("open", ((V)(0.4))).Put("htilt", ((V)(0D))).V, Get(X_3139, "cheer")), ((V)("o")));
if (Truthy(Get(X_3139, "cheerFx"))) {
InvokeSpread(t_3138, "fx", new ArrBuilder().Spread(Get(X_3139, "cheerFx")).V);
} else {
Invoke(t_3138, "fx", ((V)("heart")), ((V)("head")));
}
Invoke(t_3138, "wait", ((V)(500D)));
return Invoke(t_3138, "back", ((V)(500D)));
return default;
}, 2, "taste", false)).Put("kiss", Fn((V _self3142, int _argc3143, V t_3149, V _a3146, V _a3147, V _a3148, V[] _rest3144) => {
if (_self3142.IsNullish) _self3142 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3149, "to", ((V)(360D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(7D)), ((V)((-14D)))), NewObj(6).Put("armR", ((V)(38D))).Put("puff", ((V)(0.3))).Put("mw", ((V)(0.4))).Put("close", ((V)(0.6))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(10).Put("armR", ((V)(118D))).Put("hRx", ((V)(4D))).Put("hRy", ((V)((-6D)))).Put("open", ((V)(0.35))).Put("mw", ((V)(0.6))).Put("puff", ((V)(0D))).Put("sqz", ((V)(0.8))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D))), "wait", ((V)(600D)));
return Invoke(t_3149, "back", ((V)(500D)));
return default;
}, 1, "kiss", false)).V;
SPOON_85 = ((V)("<path d=\"M-0.55 -3L0.55 -3L0.5 9.5L-0.5 9.5Z\" fill=\"#c98a52\" stroke=\"#8a5a2c\" stroke-width=\"0.3\"/><ellipse cx=\"0\" cy=\"12\" rx=\"2\" ry=\"2.8\" fill=\"#d9a066\" stroke=\"#8a5a2c\" stroke-width=\"0.35\"/><ellipse cx=\"-0.5\" cy=\"11.2\" rx=\"0.7\" ry=\"1.1\" fill=\"#f2c890\" opacity=\"0.8\"/>"));
PAN_86 = ((V)("<path d=\"M1 -0.9L7.5 -0.4L7.5 1.2L1 1.4Z\" fill=\"#3b2a24\" stroke=\"#1e1410\" stroke-width=\"0.3\"/><ellipse cx=\"13\" cy=\"1.6\" rx=\"7\" ry=\"3.6\" fill=\"#55556a\" stroke=\"#24242c\" stroke-width=\"0.45\"/><ellipse cx=\"13\" cy=\"1\" rx=\"6\" ry=\"2.8\" fill=\"#34343f\"/><path d=\"M7.6 0.4Q10 -0.8 13 -0.9\" stroke=\"#8a8a9a\" stroke-width=\"0.4\" fill=\"none\" opacity=\"0.7\"/>"));
facing_87 = Fn((V _self1, int _argc3150, V I_3156, V _a3153, V _a3154, V _a3155, V[] _rest3151) => {
double s_3157 = 0;
s_3157 = ((ToNum(((Get(I_3156, "lastP") is var _t3158 && !Truthy(_t3158) ? _t3158 : Get(Get(I_3156, "lastP"), "spin")) is var _t3159 && Truthy(_t3159) ? _t3159 : ((V)(0D)))) * System.Math.PI) / 180D);
return Call(ss_25, V.Undef, ((V)(((FdLibm.Cos(s_3157) + 0.15) / 0.4))));
return default;
}, 1, "", true);
win_88 = Fn((V _self1, int _argc3160, V tl_3166, V a_3167, V b_3168, V e_3169, V[] _rest3161) => {
return ((V)(Min(ToNum(Call(ss_25, V.Undef, ((V)(((ToNum(tl_3166) - ToNum(a_3167)) / ToNum(e_3169)))))), ToNum(Call(ss_25, V.Undef, ((V)(((ToNum(b_3168) - ToNum(tl_3166)) / ToNum(e_3169)))))))));
}, 4, "", true);
PLY_93 = NewObj(0).V;
if (Truthy(Get(R_8, "PRE"))) {
Set(Get(R_8, "PRE"), "sand", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(12D))).Put("vy", ((V)((-16D)))).Put("g", ((V)(85D))).Put("life", ((V)(700D))).Put("r", Arr(((V)(0.5)), ((V)(0.95)))).Put("col", Arr(((V)("#e9cf94")), ((V)("#d8b874")), ((V)("#f3e2b0")))).Put("kind", ((V)("dot"))).V);
}
Set(ICON_45, "boot", Add(Add(Add(Call(pa_44, V.Undef, ((V)("M-2.6-4H1V0.6L4 1.4Q4.6 1.8 4.4 3.2H-2.6Z")), ((V)("#8a6a4a")), ((V)("#5a4028"))), Call(pa_44, V.Undef, ((V)("M-2.6 2.4H4.4")), V.Null, ((V)("#5a4028")), ((V)(0.5)))), Call(pa_44, V.Undef, ((V)("M-1.4-2.4L0.2-2.4M-1.4-1L0.2-1")), V.Null, ((V)("#d9c8a8")), ((V)(0.45)))), Call(ci_43, V.Undef, ((V)(3.6)), ((V)((-2.6))), ((V)(0.7)), ((V)("rgba(160,220,255,0.6)")), ((V)("#5ab4f0")))));
Set(ICON_45, "crab", Add(Add(Add(Add(Add(Call(pa_44, V.Undef, ((V)("M-3.4 0.6Q-3.4-2.6 0-2.6Q3.4-2.6 3.4 0.6Q3.4 2.4 0 2.4Q-3.4 2.4-3.4 0.6Z")), ((V)("#f2604a")), ((V)("#b8382a"))), Call(pa_44, V.Undef, ((V)("M-3.2-1Q-5-2.4-4.4-4M3.2-1Q5-2.4 4.4-4")), V.Null, ((V)("#b8382a")), ((V)(0.7)))), Call(ci_43, V.Undef, ((V)((-4.4))), ((V)((-4.2))), ((V)(0.9)), ((V)("#f2604a")), ((V)("#b8382a")))), Call(ci_43, V.Undef, ((V)(4.4)), ((V)((-4.2))), ((V)(0.9)), ((V)("#f2604a")), ((V)("#b8382a")))), Call(ci_43, V.Undef, ((V)((-1.1))), ((V)((-1.2))), ((V)(0.45)), ((V)("#2a1a10")))), Call(ci_43, V.Undef, ((V)(1.1)), ((V)((-1.2))), ((V)(0.45)), ((V)("#2a1a10")))));
okp_95 = Fn((V _self1, int _argc3170, V p_3176, V _a3173, V _a3174, V _a3175, V[] _rest3171) => {
return ((p_3176 is var _t3177 && !Truthy(_t3177) ? _t3177 : (IsFiniteV(GetIdx(p_3176, 0D)) ? V.True : V.False)) is var _t3178 && !Truthy(_t3178) ? _t3178 : (IsFiniteV(GetIdx(p_3176, 1D)) ? V.True : V.False));
}, 1, "", true);
gnd_96 = Fn((V _self1, int _argc3179, V I_3185, V _a3182, V _a3183, V _a3184, V[] _rest3180) => {
V W_3186 = default;
V a_3187 = default;
V b_3188 = default;
V B_3189 = default;
W_3186 = (Get(I_3185, "W") is var _t3190 && Truthy(_t3190) ? _t3190 : NewObj(0).V);
a_3187 = Get(W_3186, "footL");
b_3188 = Get(W_3186, "footR");
if (Truthy((Call(okp_95, V.Undef, a_3187) is var _t3191 && !Truthy(_t3191) ? _t3191 : Call(okp_95, V.Undef, b_3188)))) {
return Arr(((V)((ToNum(Add(GetIdx(a_3187, 0D), GetIdx(b_3188, 0D))) / 2D))), ((V)((Max(ToNum(GetIdx(a_3187, 1D)), ToNum(GetIdx(b_3188, 1D))) + 2.5))));
}
B_3189 = (Truthy(Call(okp_95, V.Undef, Get(W_3186, "belly"))) ? Get(W_3186, "belly") : Arr(((V)(50D)), ((V)(83D))));
return Arr(GetIdx(B_3189, 0D), Add(GetIdx(B_3189, 1D), ((V)(13D))));
return default;
}, 1, "", true);
rside_97 = Fn((V _self1, int _argc3192, V I_3198, V gx_3199, V _a3196, V _a3197, V[] _rest3193) => {
V s_3200 = default;
s_3200 = (Get(I_3198, "W") is var _t3201 && !Truthy(_t3201) ? _t3201 : Get(Get(I_3198, "W"), "sideR"));
return (Truthy(Call(okp_95, V.Undef, s_3200)) ? ((V)(Max(ToNum(Add(gx_3199, ((V)(18D)))), ToNum(Add(GetIdx(s_3200, 0D), ((V)(6D))))))) : Add(gx_3199, ((V)(24D))));
return default;
}, 2, "", true);
cnt_98 = Fn((V _self1, int _argc3202, V L_3208, V a_3209, V b_3210, V _a3207, V[] _rest3203) => {
return Get(Invoke((L_3208 is var _t3218 && Truthy(_t3218) ? _t3218 : Arr()), "filter", Fn((V _self1, int _argc3211, V x_3217, V _a3214, V _a3215, V _a3216, V[] _rest3212) => {
return ((Ge(x_3217, a_3209) && Le(x_3217, b_3210)) ? V.True : V.False);
}, 1, "", true)), "length");
}, 3, "", true);
lerp_99 = Fn((V _self1, int _argc3219, V a_3225, V b_3226, V u_3227, V _a3224, V[] _rest3220) => {
return Add(a_3225, ((V)(((ToNum(b_3226) - ToNum(a_3225)) * ToNum(u_3227)))));
}, 3, "", true);
G_100 = Fn((V _self1, int _argc3228, V x_3234, V y_3235, V r_3236, V s_3237, V[] _rest3229) => {
V body_3238 = default;
V op_3239 = default;
body_3238 = (_argc3228 > 4 ? _rest3229[0] : V.Undef);
op_3239 = (_argc3228 > 5 ? _rest3229[1] : V.Undef);
return ((V)(string.Concat(new string[] { "<g transform=\"translate(", ToStr(Call(r2_38, V.Undef, x_3234)), " ", ToStr(Call(r2_38, V.Undef, y_3235)), ")", (Truthy(r_3236) ? string.Concat(" rotate(", ToStr(Call(r2_38, V.Undef, r_3236)), ")") : ""), ((!s_3237.IsNullish && !SEqN(s_3237, 1D)) ? string.Concat(" scale(", ToStr(Call(r2_38, V.Undef, s_3237)), ")") : ""), "\"", ((!op_3239.IsNullish && LtN(op_3239, 0.99)) ? string.Concat(" opacity=\"", ToStr(Call(r2_38, V.Undef, ((V)(Max(0D, ToNum(op_3239)))))), "\"") : ""), ">", ToStr(body_3238), "</g>" })));
}, 6, "", true);
SK0_102 = Call(o_10, V.Undef, NewObj(13).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)((-0.14)))).Put("ly", ((V)(0.7))).Put("lx", ((V)(0D))).Put("smile", ((V)(0.5))).Put("hap", ((V)(0.2))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).V, Call(both_13, V.Undef, ((V)(9D)), ((V)((-2D)))));
SKB_103 = NewObj(6).Put("scrub", Fn((V _self3240, int _argc3241, V t_3247, V _a3244, V _a3245, V _a3246, V[] _rest3242) => {
V B_3248 = default;
if (_self3240.IsNullish) _self3240 = GlobalV;
B_3248 = Get(t_3247, "B");
Invoke(t_3247, "to", ((V)(220D)), NewObj(2).Put("sqz", ((V)(0.3))).Put("smile", ((V)(0.8))).V);
{
double i_3249 = 0;
i_3249 = 0D;
while (true) {
if (!((i_3249 < 6D))) break;
Invoke(Invoke(t_3247, "to", ((V)(140D)), NewObj(4).Put("hLx", Add(Get(B_3248, "hLx"), ((V)(2.6)))).Put("hRx", ((V)((ToNum(Get(B_3248, "hRx")) - 2.6)))).Put("hLy", ((V)((ToNum(Get(B_3248, "hLy")) - 1.4)))).Put("hRy", Add(Get(B_3248, "hRy"), ((V)(1.4)))).V, ((V)("l"))), "to", ((V)(140D)), NewObj(4).Put("hLx", ((V)((ToNum(Get(B_3248, "hLx")) - 0.6)))).Put("hRx", Add(Get(B_3248, "hRx"), ((V)(0.6)))).Put("hLy", Add(Get(B_3248, "hLy"), ((V)(1.4)))).Put("hRy", ((V)((ToNum(Get(B_3248, "hRy")) - 1.4)))).V, ((V)("l")));
if (((i_3249 % 2D) == 0D)) {
Invoke(t_3247, "fx", ((V)("foam")), ((V)((NumTruthy((i_3249 % 4D)) ? "pawL" : "pawR"))), ((V)(2D)));
}
i_3249++;
}
}
return Invoke(t_3247, "back", ((V)(300D)));
return default;
}, 1, "scrub", false)).Put("rinse", Fn((V _self3251, int _argc3252, V t_3258, V _a3255, V _a3256, V _a3257, V[] _rest3253) => {
V B_3259 = default;
if (_self3251.IsNullish) _self3251 = GlobalV;
B_3259 = Get(t_3258, "B");
Invoke(t_3258, "to", ((V)(300D)), NewObj(5).Put("hLy", ((V)((ToNum(Get(B_3259, "hLy")) - 2D)))).Put("hRy", ((V)((ToNum(Get(B_3259, "hRy")) - 2D)))).Put("armL", ((V)(38D))).Put("armR", ((V)(38D))).Put("ly", ((V)(0.5))).V, ((V)("io")));
{
double i_3260 = 0;
i_3260 = 0D;
while (true) {
if (!((i_3260 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(t_3258, "to", ((V)(200D)), NewObj(2).Put("hLx", Add(Get(B_3259, "hLx"), ((V)(1.5)))).Put("hRx", Add(Get(B_3259, "hRx"), ((V)(1.5)))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)("pawL")), ((V)(3D))), "to", ((V)(200D)), NewObj(2).Put("hLx", ((V)((ToNum(Get(B_3259, "hLx")) - 1.5)))).Put("hRx", ((V)((ToNum(Get(B_3259, "hRx")) - 1.5)))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)("pawR")), ((V)(3D)));
i_3260++;
}
}
return Invoke(t_3258, "back", ((V)(300D)));
return default;
}, 1, "rinse", false)).Put("splash", Fn((V _self3262, int _argc3263, V t_3269, V X_3270, V _a3267, V _a3268, V[] _rest3264) => {
V B_3271 = default;
if (_self3262.IsNullish) _self3262 = GlobalV;
B_3271 = Get(t_3269, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3269, "to", ((V)(320D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(9D)), ((V)((-13D)))), NewObj(5).Put("armL", ((V)(44D))).Put("armR", ((V)(44D))).Put("pitch", Add(Get(B_3271, "pitch"), ((V)(0.12)))).Put("ly", ((V)(0.2))).Put("close", ((V)(0.5))).V), ((V)("io"))), "to", ((V)(110D)), NewObj(4).Put("close", ((V)(1D))).Put("sqz", ((V)(1D))).Put("open", ((V)(0.25))).Put("sq", ((V)((ToNum(Get(B_3271, "sq")) - 0.05)))).V, ((V)("o"))), "fx", ((V)("splash")), ((V)("head")), ((V)(6D))), "osc", ((V)(560D)), ((V)(4D)), NewObj(2).Put("htilt", ((V)(7D))).Put("x", ((V)(0.4))).V, NewObj(2).Put("htilt", ((V)((-7D)))).Put("x", ((V)((-0.4)))).V, ((V)("l"))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D))), "to", ((V)(220D)), Call(o_10, V.Undef, NewObj(9).Put("sqz", ((V)(0D))).Put("close", ((V)(0D))).Put("wide", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("sq", Get(B_3271, "sq")).Put("htilt", ((V)(0D))).Put("x", ((V)(0D))).V, Get(X_3270, "wash")), ((V)("o"))), "wait", ((V)(400D)));
return Invoke(t_3269, "back", ((V)(420D)));
return default;
}, 2, "splash", false)).Put("shake", Fn((V _self3272, int _argc3273, V t_3279, V _a3276, V _a3277, V _a3278, V[] _rest3274) => {
V B_3280 = default;
if (_self3272.IsNullish) _self3272 = GlobalV;
B_3280 = Get(t_3279, "B");
Invoke(Invoke(Invoke(Invoke(t_3279, "to", ((V)(200D)), NewObj(4).Put("hLy", Add(Get(B_3280, "hLy"), ((V)(2D)))).Put("hRy", Add(Get(B_3280, "hRy"), ((V)(2D)))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "osc", ((V)(720D)), ((V)(6D)), NewObj(4).Put("armL", ((V)(36D))).Put("armR", ((V)(12D))).Put("hLx", Add(Get(B_3280, "hLx"), ((V)(2D)))).Put("hRx", Get(B_3280, "hRx")).V, NewObj(4).Put("armL", ((V)(12D))).Put("armR", ((V)(36D))).Put("hLx", Get(B_3280, "hLx")).Put("hRx", ((V)((ToNum(Get(B_3280, "hRx")) - 2D)))).V, ((V)("l"))), "fx", ((V)("drop")), ((V)("pawL")), ((V)(3D))), "fx", ((V)("drop")), ((V)("pawR")), ((V)(3D)));
return Invoke(t_3279, "back", ((V)(300D)));
return default;
}, 1, "shake", false)).Put("mirror", Fn((V _self3281, int _argc3282, V t_3288, V _a3285, V _a3286, V _a3287, V[] _rest3283) => {
V B_3289 = default;
if (_self3281.IsNullish) _self3281 = GlobalV;
B_3289 = Get(t_3288, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3288, "to", ((V)(420D)), NewObj(5).Put("pitch", Add(Get(B_3289, "pitch"), ((V)(0.22)))).Put("ly", ((V)((-0.5)))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).Put("htilt", ((V)(4D))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(150D)), NewObj(2).Put("winkR", ((V)(1D))).Put("sqz", ((V)(0.3))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(380D))), "to", ((V)(200D)), NewObj(2).Put("winkR", ((V)(0D))).Put("sqz", ((V)(0D))).V), "e", ((V)("blink"))), "wait", ((V)(200D)));
return Invoke(t_3288, "back", ((V)(420D)));
return default;
}, 1, "mirror", false)).Put("dry", Fn((V _self3290, int _argc3291, V t_3297, V _a3294, V _a3295, V _a3296, V[] _rest3292) => {
V B_3298 = default;
if (_self3290.IsNullish) _self3290 = GlobalV;
B_3298 = Get(t_3297, "B");
Invoke(Invoke(Invoke(t_3297, "to", ((V)(320D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(7D)), ((V)(5D))), NewObj(4).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("ly", ((V)(0.8))).Put("pitch", ((V)((ToNum(Get(B_3298, "pitch")) - 0.04)))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(5D)), NewObj(2).Put("hLy", ((V)(8D))).Put("hRy", ((V)(2D))).V, NewObj(2).Put("hLy", ((V)(2D))).Put("hRy", ((V)(8D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V);
return Invoke(t_3297, "back", ((V)(380D)));
return default;
}, 1, "dry", false)).V;
BR0_104 = Call(o_10, V.Undef, NewObj(16).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)((-0.04)))).Put("ly", ((V)(0.2))).Put("lx", ((V)(0D))).Put("armR", ((V)(36D))).Put("armL", ((V)(16D))).Put("open", ((V)(0.28))).Put("mw", ((V)(1.35))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.2))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("puff", ((V)(0D))).V, Call(hand_12, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-13D)))), Call(hand_12, V.Undef, ((V)((-1D))), ((V)(5D)), ((V)(3D))));
BRB_105 = NewObj(5).Put("brush", Fn((V _self3299, int _argc3300, V t_3306, V _a3303, V _a3304, V _a3305, V[] _rest3301) => {
V B_3307 = default;
if (_self3299.IsNullish) _self3299 = GlobalV;
B_3307 = Get(t_3306, "B");
Invoke(t_3306, "to", ((V)(160D)), NewObj(1).Put("sqz", ((V)(0.25))).V);
{
double i_3308 = 0;
i_3308 = 0D;
while (true) {
if (!((i_3308 < 9D))) break;
Invoke(Invoke(t_3306, "to", ((V)(110D)), NewObj(2).Put("hRx", ((V)((ToNum(Get(B_3307, "hRx")) - 2.4)))).Put("htilt", ((V)(2.5))).V, ((V)("l"))), "to", ((V)(110D)), NewObj(2).Put("hRx", Add(Get(B_3307, "hRx"), ((V)(2.4)))).Put("htilt", ((V)((-2.5)))).V, ((V)("l")));
if (((i_3308 % 3D) == 1D)) {
Invoke(t_3306, "fx", ((V)("foam")), ((V)("mouth")), ((V)(1D)));
}
i_3308++;
}
}
return Invoke(t_3306, "back", ((V)(260D)));
return default;
}, 1, "brush", false)).Put("side", Fn((V _self3310, int _argc3311, V t_3317, V _a3314, V _a3315, V _a3316, V[] _rest3312) => {
V B_3318 = default;
if (_self3310.IsNullish) _self3310 = GlobalV;
B_3318 = Get(t_3317, "B");
Invoke(t_3317, "to", ((V)(300D)), NewObj(6).Put("lx", ((V)((-0.6)))).Put("htilt", ((V)((-7D)))).Put("armR", Add(Get(B_3318, "armR"), ((V)(8D)))).Put("hRy", ((V)((ToNum(Get(B_3318, "hRy")) - 1D)))).Put("hRx", Add(Get(B_3318, "hRx"), ((V)(2D)))).Put("mw", ((V)(1.1))).V, ((V)("io")));
{
double i_3319 = 0;
i_3319 = 0D;
while (true) {
if (!((i_3319 < 7D))) break;
Invoke(Invoke(t_3317, "to", ((V)(110D)), NewObj(1).Put("hRy", ((V)((ToNum(Get(B_3318, "hRy")) - 3.4)))).V, ((V)("l"))), "to", ((V)(110D)), NewObj(1).Put("hRy", ((V)((ToNum(Get(B_3318, "hRy")) - 0.4)))).V, ((V)("l")));
i_3319++;
}
}
Invoke(t_3317, "fx", ((V)("foam")), ((V)("mouth")), ((V)(2D)));
return Invoke(t_3317, "back", ((V)(300D)));
return default;
}, 1, "side", false)).Put("gargle", Fn((V _self3321, int _argc3322, V t_3328, V _a3325, V _a3326, V _a3327, V[] _rest3323) => {
V B_3329 = default;
if (_self3321.IsNullish) _self3321 = GlobalV;
B_3329 = Get(t_3328, "B");
Invoke(Invoke(Invoke(Invoke(t_3328, "to", ((V)(340D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(6D)), ((V)(1D))), NewObj(6).Put("armR", ((V)(16D))).Put("pitch", Add(Get(B_3329, "pitch"), ((V)(0.34)))).Put("ly", ((V)((-0.8)))).Put("open", ((V)(0.38))).Put("mw", ((V)(0.7))).Put("close", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(1000D)), ((V)(9D)), NewObj(2).Put("sq", Add(Get(B_3329, "sq"), ((V)(0.025)))).Put("puff", ((V)(0.5))).V, NewObj(2).Put("sq", Get(B_3329, "sq")).Put("puff", ((V)(0.2))).V, ((V)("l"))), "fx", ((V)("bubble")), ((V)("mouth")), ((V)(3D))), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0.7))).Put("open", ((V)(0D))).V);
return t_3328;
return default;
}, 1, "gargle", false)).Put("spit", Fn((V _self3330, int _argc3331, V t_3337, V _a3334, V _a3335, V _a3336, V[] _rest3332) => {
V B_3338 = default;
if (_self3330.IsNullish) _self3330 = GlobalV;
B_3338 = Get(t_3337, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_3337, "to", ((V)(320D)), NewObj(5).Put("pitch", ((V)((ToNum(Get(B_3338, "pitch")) - 0.3)))).Put("ly", ((V)(0.9))).Put("puff", ((V)(0.9))).Put("open", ((V)(0D))).Put("close", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.45))).Put("sq", Add(Get(B_3338, "sq"), ((V)(0.04)))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("mouth")), ((V)(5D))), "wait", ((V)(260D))), "to", ((V)(200D)), NewObj(2).Put("open", ((V)(0.1))).Put("sq", Get(B_3338, "sq")).V);
return Invoke(t_3337, "back", ((V)(380D)));
return default;
}, 1, "spit", false)).Put("grin", Fn((V _self3339, int _argc3340, V t_3346, V X_3347, V _a3344, V _a3345, V[] _rest3341) => {
V B_3348 = default;
if (_self3339.IsNullish) _self3339 = GlobalV;
B_3348 = Get(t_3346, "B");
Invoke(Invoke(Invoke(t_3346, "to", ((V)(300D)), Call(o_10, V.Undef, NewObj(7).Put("smile", ((V)(1D))).Put("hap", ((V)(0.7))).Put("open", ((V)(0.3))).Put("mw", ((V)(1.55))).Put("wide", ((V)(0.4))).Put("pitch", Add(Get(B_3348, "pitch"), ((V)(0.06)))).Put("ly", ((V)(0D))).V, Get(X_3347, "cheer")), ((V)("o"))), "fx", ((V)("spark")), ((V)("mouth")), ((V)(4D))), "wait", ((V)(900D)));
return Invoke(t_3346, "back", ((V)(420D)));
return default;
}, 2, "grin", false)).V;
DNB_107 = NewObj(6).Put("bite", Fn((V _self3349, int _argc3350, V t_3356, V X_3357, V rec_3358, V _a3355, V[] _rest3351) => {
V B_3359 = default;
V p0_3360 = default;
V Q_3361 = default;
V md_3362 = default;
if (_self3349.IsNullish) _self3349 = GlobalV;
B_3359 = Get(t_3356, "B");
p0_3360 = (Get(B_3359, "pitch") is var _t3363 && Truthy(_t3363) ? _t3363 : ((V)(0D)));
Q_3361 = (Get(B_3359, "sq") is var _t3364 && Truthy(_t3364) ? _t3364 : ((V)(0D)));
md_3362 = Get(X_3357, "_dm");
if (SEqS(md_3362, "lap")) {
Invoke(t_3356, "to", ((V)(340D)), NewObj(4).Put("pitch", ((V)((ToNum(p0_3360) - 0.24)))).Put("ly", ((V)(0.7))).Put("open", ((V)(0.3))).Put("sq", Add(Q_3361, ((V)(0.03)))).V, ((V)("io")));
} else {
if (SEqS(md_3362, "two")) {
Invoke(t_3356, "to", ((V)(340D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(9D)), ((V)((-12D)))), NewObj(5).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("open", ((V)(0.35))).Put("pitch", Add(p0_3360, ((V)(0.02)))).Put("ly", ((V)(0D))).V), ((V)("io")));
} else {
Invoke(t_3356, "to", ((V)(340D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-13D)))), NewObj(4).Put("armR", ((V)(34D))).Put("open", ((V)(0.35))).Put("pitch", Add(p0_3360, ((V)(0.02)))).Put("ly", ((V)(0D))).V), ((V)("io")));
}
}
Invoke(t_3356, "to", ((V)(120D)), NewObj(3).Put("open", ((V)(0D))).Put("puff", ((V)(0.55))).Put("sq", Add(Q_3361, ((V)(0.02)))).V, ((V)("o")));
Invoke(Set(rec_3358, "bite", (Get(rec_3358, "bite") is var _t3365 && Truthy(_t3365) ? _t3365 : Arr())), "push", Get(t_3356, "t"));
Invoke(Invoke(t_3356, "fx", ((V)("crumb")), ((V)("mouth")), ((V)(3D))), "osc", ((V)(900D)), ((V)(5D)), NewObj(2).Put("puff", ((V)(0.6))).Put("open", ((V)(0.12))).V, NewObj(2).Put("puff", ((V)(0.2))).Put("open", ((V)(0D))).V, ((V)("l")));
return Invoke(t_3356, "back", ((V)(320D)));
return default;
}, 3, "bite", false)).Put("chew", Fn((V _self3366, int _argc3367, V t_3373, V _a3370, V _a3371, V _a3372, V[] _rest3368) => {
if (_self3366.IsNullish) _self3366 = GlobalV;
Invoke(BEAT_16, "hum", t_3373);
return t_3373;
return default;
}, 1, "chew", false)).Put("sip", Fn((V _self3374, int _argc3375, V t_3381, V _a3378, V _a3379, V _a3380, V[] _rest3376) => {
V B_3382 = default;
if (_self3374.IsNullish) _self3374 = GlobalV;
B_3382 = Get(t_3381, "B");
Invoke(Invoke(Invoke(Invoke(t_3381, "to", ((V)(340D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)(9D)), ((V)((-13D)))), NewObj(3).Put("armL", ((V)(34D))).Put("pitch", Add(Get(B_3382, "pitch"), ((V)(0.12)))).Put("ly", ((V)((-0.2)))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("puff", ((V)(0.3))).Put("close", ((V)(0.5))).V, NewObj(2).Put("puff", ((V)(0D))).Put("close", ((V)(0.3))).V, ((V)("l"))), "to", ((V)(240D)), NewObj(4).Put("close", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(300D)));
return Invoke(t_3381, "back", ((V)(380D)));
return default;
}, 1, "sip", false)).Put("crumbs", Fn((V _self3383, int _argc3384, V t_3390, V _a3387, V _a3388, V _a3389, V[] _rest3385) => {
V B_3391 = default;
if (_self3383.IsNullish) _self3383 = GlobalV;
B_3391 = Get(t_3390, "B");
Invoke(Invoke(Invoke(t_3390, "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)(7D))), NewObj(3).Put("armL", ((V)(10D))).Put("ly", ((V)(0.8))).Put("pitch", ((V)((ToNum(Get(B_3391, "pitch")) - 0.08)))).V), ((V)("io"))), "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("hLx", ((V)(9D))).V, NewObj(1).Put("hLx", ((V)(4D))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("belly")), ((V)(4D)));
return Invoke(t_3390, "back", ((V)(320D)));
return default;
}, 1, "crumbs", false)).Put("lick", Fn((V _self3392, int _argc3393, V t_3399, V _a3396, V _a3397, V _a3398, V[] _rest3394) => {
if (_self3392.IsNullish) _self3392 = GlobalV;
Invoke(Invoke(Invoke(t_3399, "to", ((V)(360D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)(8D)), ((V)((-12D)))), NewObj(2).Put("armL", ((V)(32D))).Put("close", ((V)(0.5))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(5D)), NewObj(1).Put("tongue", ((V)(0.6))).V, NewObj(1).Put("tongue", ((V)(0.1))).V, ((V)("s"))), "to", ((V)(160D)), NewObj(1).Put("tongue", ((V)(0D))).V);
return Invoke(t_3399, "back", ((V)(380D)));
return default;
}, 1, "lick", false)).Put("yum", Fn((V _self3400, int _argc3401, V t_3407, V X_3408, V _a3405, V _a3406, V[] _rest3402) => {
if (_self3400.IsNullish) _self3400 = GlobalV;
Invoke(BEAT_16, "belly", t_3407, ((V)((-1D))));
Invoke(Invoke(Invoke(t_3407, "to", ((V)(240D)), Call(o_10, V.Undef, NewObj(3).Put("smile", ((V)(1D))).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.6))).V, Get(X_3408, "cheer")), ((V)("o"))), "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "wait", ((V)(400D)));
return Invoke(t_3407, "back", ((V)(400D)));
return default;
}, 2, "yum", false)).V;
SF0_109 = NewObj(17).Put("sq", ((V)(0.08))).Put("lift", ((V)((-1.2)))).Put("pitch", ((V)(0.04))).Put("armL", ((V)(82D))).Put("armR", ((V)(82D))).Put("hLx", ((V)((-9D)))).Put("hRx", ((V)(9D))).Put("hLy", ((V)((-1D)))).Put("hRy", ((V)((-1D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.4))).Put("wide", ((V)(0.2))).V;
SFB_110 = NewObj(6).Put("wobble", Fn((V _self3409, int _argc3410, V t_3416, V _a3413, V _a3414, V _a3415, V[] _rest3411) => {
V B_3417 = default;
if (_self3409.IsNullish) _self3409 = GlobalV;
B_3417 = Get(t_3416, "B");
Invoke(Invoke(t_3416, "to", ((V)(160D)), NewObj(1).Put("wide", ((V)(0.6))).V), "osc", ((V)(1600D)), ((V)(3D)), NewObj(4).Put("tilt", ((V)(7D))).Put("armL", ((V)(98D))).Put("armR", ((V)(58D))).Put("x", ((V)(0.8))).V, NewObj(4).Put("tilt", ((V)((-7D)))).Put("armL", ((V)(58D))).Put("armR", ((V)(98D))).Put("x", ((V)((-0.8)))).V, ((V)("s")));
return Invoke(t_3416, "back", ((V)(400D)));
return default;
}, 1, "wobble", false)).Put("crouch", Fn((V _self3418, int _argc3419, V t_3425, V _a3422, V _a3423, V _a3424, V[] _rest3420) => {
V B_3426 = default;
if (_self3418.IsNullish) _self3418 = GlobalV;
B_3426 = Get(t_3425, "B");
Invoke(Invoke(Invoke(t_3425, "to", ((V)(400D)), NewObj(8).Put("sq", Add(Get(B_3426, "sq"), ((V)(0.1)))).Put("lift", ((V)((ToNum(Get(B_3426, "lift")) - 1.6)))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).Put("hLy", ((V)(2D))).Put("hRy", ((V)(2D))).Put("pitch", ((V)((ToNum(Get(B_3426, "pitch")) - 0.08)))).Put("sqz", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(600D))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)((ToNum(Get(B_3426, "sq")) - 0.06)))).Put("lift", Add(Get(B_3426, "lift"), ((V)(1.5)))).Put("sqz", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o")));
return Invoke(t_3425, "back", ((V)(400D)));
return default;
}, 1, "crouch", false)).Put("carve", Fn((V _self3427, int _argc3428, V t_3434, V _a3431, V _a3432, V _a3433, V[] _rest3429) => {
if (_self3427.IsNullish) _self3427 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3434, "to", ((V)(500D)), NewObj(6).Put("tilt", ((V)(9D))).Put("lean", ((V)(1.4))).Put("armL", ((V)(110D))).Put("armR", ((V)(40D))).Put("htilt", ((V)((-6D)))).Put("smile", ((V)(1D))).V, ((V)("s"))), "fx", ((V)("gust")), ((V)("head"))), "wait", ((V)(700D))), "to", ((V)(600D)), NewObj(5).Put("tilt", ((V)((-9D)))).Put("lean", ((V)((-1.4)))).Put("armL", ((V)(40D))).Put("armR", ((V)(110D))).Put("htilt", ((V)(6D))).V, ((V)("s"))), "fx", ((V)("splash")), ((V)("belly")), ((V)(4D))), "wait", ((V)(500D)));
return Invoke(t_3434, "back", ((V)(500D)));
return default;
}, 1, "carve", false)).Put("bump", Fn((V _self3435, int _argc3436, V t_3442, V _a3439, V _a3440, V _a3441, V[] _rest3437) => {
V B_3443 = default;
if (_self3435.IsNullish) _self3435 = GlobalV;
B_3443 = Get(t_3442, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_3442, "to", ((V)(200D)), NewObj(2).Put("sq", Add(Get(B_3443, "sq"), ((V)(0.08)))).Put("lift", ((V)((ToNum(Get(B_3443, "lift")) - 1D)))).V, ((V)("i"))), "to", ((V)(260D)), NewObj(6).Put("sq", ((V)((ToNum(Get(B_3443, "sq")) - 0.08)))).Put("lift", Add(Get(B_3443, "lift"), ((V)(5D)))).Put("armL", ((V)(110D))).Put("armR", ((V)(110D))).Put("open", ((V)(0.4))).Put("hap", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("splash")), ((V)("belly")), ((V)(6D))), "to", ((V)(260D)), NewObj(2).Put("sq", Add(Get(B_3443, "sq"), ((V)(0.1)))).Put("lift", Get(B_3443, "lift")).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(B_3443, "sq")).V, ((V)("io")));
return Invoke(t_3442, "back", ((V)(300D)));
return default;
}, 1, "bump", false)).Put("hang10", Fn((V _self3444, int _argc3445, V t_3451, V X_3452, V _a3449, V _a3450, V[] _rest3446) => {
if (_self3444.IsNullish) _self3444 = GlobalV;
Invoke(t_3451, "to", ((V)(320D)), Call(o_10, V.Undef, NewObj(6).Put("armR", ((V)(158D))).Put("hRy", ((V)((-6D)))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("hap", ((V)(1D))).Put("wide", ((V)(0.4))).V, Get(X_3452, "cheer")), ((V)("o")));
if (Truthy(Get(X_3452, "cheerFx"))) {
InvokeSpread(t_3451, "fx", new ArrBuilder().Spread(Get(X_3452, "cheerFx")).V);
} else {
Invoke(t_3451, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
}
Invoke(t_3451, "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("armR", ((V)(140D))).V, NewObj(1).Put("armR", ((V)(165D))).V, ((V)("io")));
return Invoke(t_3451, "back", ((V)(420D)));
return default;
}, 2, "hang10", false)).Put("wipe", Fn((V _self3453, int _argc3454, V t_3460, V _a3457, V _a3458, V _a3459, V[] _rest3455) => {
if (_self3453.IsNullish) _self3453 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3460, "to", ((V)(150D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.5))).Put("tilt", ((V)(12D))).Put("x", ((V)(1.5))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(150D))).Put("armR", ((V)(30D))).V, NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(150D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(2).Put("tilt", ((V)((-4D)))).Put("x", ((V)((-0.5)))).V), "to", ((V)(300D)), NewObj(3).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("wide", ((V)(0.3))).V), "fx", ((V)("sweat")), ((V)("head"))), "to", ((V)(300D)), NewObj(4).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
return Invoke(t_3460, "back", ((V)(420D)));
return default;
}, 1, "wipe", false)).V;
FS0_111 = Call(o_10, V.Undef, NewObj(11).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0.02))).Put("armL", ((V)(24D))).Put("armR", ((V)(30D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("smile", ((V)(0.6))).Put("hap", ((V)(0.2))).V, Call(hand_12, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-4D)))), Call(hand_12, V.Undef, ((V)((-1D))), ((V)(9D)), ((V)((-2D)))));
FB_112 = NewObj(4).Put("cast", Fn((V _self3461, int _argc3462, V t_3468, V X_3469, V rec_3470, V _a3467, V[] _rest3463) => {
V B_3471 = default;
V a_3472 = default;
V f_3473 = default;
if (_self3461.IsNullish) _self3461 = GlobalV;
B_3471 = Get(t_3468, "B");
Invoke(t_3468, "to", ((V)(160D)), NewObj(2).Put("sqz", ((V)(0.3))).Put("ly", ((V)((-0.2)))).V);
a_3472 = Get(t_3468, "t");
Invoke(t_3468, "to", ((V)(420D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-10D)))), NewObj(5).Put("armR", ((V)(128D))).Put("armL", ((V)(60D))).Put("lean", ((V)((-1D)))).Put("tilt", ((V)((-4D)))).Put("pitch", Add(Get(B_3471, "pitch"), ((V)(0.1)))).V), ((V)("io")));
f_3473 = Get(t_3468, "t");
Invoke(t_3468, "to", ((V)(180D)), NewObj(8).Put("armR", ((V)(44D))).Put("hRy", ((V)((-5D)))).Put("armL", ((V)(32D))).Put("lean", ((V)(1.2))).Put("tilt", ((V)(3D))).Put("sqz", ((V)(0D))).Put("open", ((V)(0.35))).Put("pitch", ((V)((ToNum(Get(B_3471, "pitch")) - 0.04)))).V, ((V)("o")));
Invoke(Set(rec_3470, "cast", (Get(rec_3470, "cast") is var _t3474 && Truthy(_t3474) ? _t3474 : Arr())), "push", Arr(a_3472, f_3473));
Invoke(Invoke(t_3468, "to", ((V)(420D)), NewObj(3).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(400D)));
return Invoke(t_3468, "back", ((V)(400D)));
return default;
}, 3, "cast", false)).Put("nibble", Fn((V _self3475, int _argc3476, V t_3482, V X_3483, V rec_3484, V _a3481, V[] _rest3477) => {
V B_3485 = default;
if (_self3475.IsNullish) _self3475 = GlobalV;
B_3485 = Get(t_3482, "B");
Invoke(t_3482, "to", ((V)(200D)), NewObj(6).Put("wide", ((V)(0.8))).Put("pitch", ((V)((ToNum(Get(B_3485, "pitch")) - 0.1)))).Put("ly", ((V)(0.7))).Put("lean", ((V)(0.6))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).V, ((V)("o")));
Invoke(Set(rec_3484, "nib", (Get(rec_3484, "nib") is var _t3486 && Truthy(_t3486) ? _t3486 : Arr())), "push", Get(t_3482, "t"));
Invoke(Invoke(t_3482, "osc", ((V)(700D)), ((V)(2D)), NewObj(1).Put("hRy", Add(Get(B_3485, "hRy"), ((V)(1.5)))).V, NewObj(1).Put("hRy", Get(B_3485, "hRy")).V, ((V)("l"))), "wait", ((V)(400D)));
return Invoke(t_3482, "back", ((V)(380D)));
return default;
}, 3, "nibble", false)).Put("reel", Fn((V _self3487, int _argc3488, V t_3494, V X_3495, V rec_3496, V _a3493, V[] _rest3489) => {
V B_3497 = default;
V a_3498 = default;
if (_self3487.IsNullish) _self3487 = GlobalV;
B_3497 = Get(t_3494, "B");
a_3498 = Get(t_3494, "t");
Invoke(t_3494, "to", ((V)(150D)), NewObj(7).Put("armR", ((V)(66D))).Put("hRy", ((V)((ToNum(Get(B_3497, "hRy")) - 4D)))).Put("lean", ((V)((-1D)))).Put("tilt", ((V)((-3D)))).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.5))).V, ((V)("o")));
{
double i_3499 = 0;
i_3499 = 0D;
while (true) {
if (!((i_3499 < 6D))) break;
Invoke(Invoke(Invoke(Invoke(t_3494, "to", ((V)(140D)), NewObj(3).Put("hLx", Add(Get(B_3497, "hLx"), ((V)(2D)))).Put("hLy", ((V)((ToNum(Get(B_3497, "hLy")) - 2D)))).Put("tilt", ((V)((-4D)))).V, ((V)("l"))), "to", ((V)(140D)), NewObj(2).Put("hLx", Get(B_3497, "hLx")).Put("hLy", ((V)((ToNum(Get(B_3497, "hLy")) - 4D)))).V, ((V)("l"))), "to", ((V)(140D)), NewObj(3).Put("hLx", ((V)((ToNum(Get(B_3497, "hLx")) - 2D)))).Put("hLy", ((V)((ToNum(Get(B_3497, "hLy")) - 2D)))).Put("tilt", ((V)((-2D)))).V, ((V)("l"))), "to", ((V)(140D)), NewObj(2).Put("hLx", Get(B_3497, "hLx")).Put("hLy", Get(B_3497, "hLy")).V, ((V)("l")));
i_3499++;
}
}
Invoke(t_3494, "fx", ((V)("sweat")), ((V)("head")));
Invoke(Set(rec_3496, "reel", (Get(rec_3496, "reel") is var _t3501 && Truthy(_t3501) ? _t3501 : Arr())), "push", Arr(a_3498, Get(t_3494, "t")));
return t_3494;
return default;
}, 3, "reel", false)).Put("catch", Fn((V _self3502, int _argc3503, V t_3509, V X_3510, V rec_3511, V _a3508, V[] _rest3504) => {
V a_3512 = default;
if (_self3502.IsNullish) _self3502 = GlobalV;
a_3512 = Get(t_3509, "t");
Invoke(t_3509, "to", ((V)(240D)), Call(o_10, V.Undef, NewObj(14).Put("armR", ((V)(150D))).Put("hRy", ((V)((-10D)))).Put("hRx", ((V)(0D))).Put("armL", ((V)(124D))).Put("hLy", ((V)((-8D)))).Put("hLx", ((V)(0D))).Put("lift", ((V)(2.4))).Put("sq", ((V)((-0.06)))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.5))).V, Get(X_3510, "cheer")), ((V)("o")));
if (Truthy(Get(X_3510, "cheerFx"))) {
InvokeSpread(t_3509, "fx", new ArrBuilder().Spread(Get(X_3510, "cheerFx")).V);
} else {
Invoke(t_3509, "fx", ((V)("spark")), ((V)("head")), ((V)(4D)));
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_3509, "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V), "wait", ((V)(600D))), "to", ((V)(400D)), NewObj(5).Put("htilt", ((V)(8D))).Put("lx", ((V)(0.6))).Put("ly", ((V)((-0.6)))).Put("armR", ((V)(128D))).Put("open", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(800D)));
Invoke(Set(rec_3511, "catch", (Get(rec_3511, "catch") is var _t3513 && Truthy(_t3513) ? _t3513 : Arr())), "push", Arr(a_3512, Get(t_3509, "t")));
return Invoke(t_3509, "back", ((V)(450D)));
return default;
}, 3, "catch", false)).V;
SUNB_114 = NewObj(6).Put("sigh", Fn((V _self3514, int _argc3515, V t_3521, V _a3518, V _a3519, V _a3520, V[] _rest3516) => {
if (_self3514.IsNullish) _self3514 = GlobalV;
Invoke(BEAT_16, "sigh", t_3521);
return t_3521;
return default;
}, 1, "sigh", false)).Put("doze", Fn((V _self3522, int _argc3523, V t_3529, V _a3526, V _a3527, V _a3528, V[] _rest3524) => {
if (_self3522.IsNullish) _self3522 = GlobalV;
Invoke(BEAT_16, "doze", t_3529);
return t_3529;
return default;
}, 1, "doze", false)).Put("toes", Fn((V _self3530, int _argc3531, V t_3537, V _a3534, V _a3535, V _a3536, V[] _rest3532) => {
V B_3538 = default;
if (_self3530.IsNullish) _self3530 = GlobalV;
B_3538 = Get(t_3537, "B");
Invoke(Invoke(t_3537, "osc", ((V)(1600D)), ((V)(4D)), NewObj(2).Put("footL", Add(Get(B_3538, "footL"), ((V)(1.6)))).Put("footR", ((V)((ToNum(Get(B_3538, "footR")) - 0.4)))).V, NewObj(2).Put("footL", ((V)((ToNum(Get(B_3538, "footL")) - 0.4)))).Put("footR", Add(Get(B_3538, "footR"), ((V)(1.6)))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(1).Put("smile", ((V)(1D))).V);
return Invoke(t_3537, "back", ((V)(360D)));
return default;
}, 1, "toes", false)).Put("sip", Fn((V _self3539, int _argc3540, V t_3546, V _a3543, V _a3544, V _a3545, V[] _rest3541) => {
V B_3547 = default;
if (_self3539.IsNullish) _self3539 = GlobalV;
B_3547 = Get(t_3546, "B");
Invoke(Invoke(Invoke(Invoke(t_3546, "to", ((V)(400D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-12D)))), NewObj(2).Put("armR", ((V)(40D))).Put("pitch", ((V)((ToNum(Get(B_3547, "pitch")) - 0.06)))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("puff", ((V)(0.35))).V, NewObj(1).Put("puff", ((V)(0D))).V, ((V)("l"))), "to", ((V)(240D)), NewObj(3).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(300D)));
return Invoke(t_3546, "back", ((V)(420D)));
return default;
}, 1, "sip", false)).Put("lotion", Fn((V _self3548, int _argc3549, V t_3555, V _a3552, V _a3553, V _a3554, V[] _rest3550) => {
if (_self3548.IsNullish) _self3548 = GlobalV;
Invoke(Invoke(Invoke(t_3555, "to", ((V)(360D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)(6D))), NewObj(1).Put("armL", ((V)(10D))).V), ((V)("io"))), "osc", ((V)(1400D)), ((V)(4D)), NewObj(2).Put("hLx", ((V)(9D))).Put("hLy", ((V)(4D))).V, NewObj(2).Put("hLx", ((V)(4D))).Put("hLy", ((V)(8D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("belly")), ((V)(2D)));
return Invoke(t_3555, "back", ((V)(380D)));
return default;
}, 1, "lotion", false)).Put("peek", Fn((V _self3556, int _argc3557, V t_3563, V _a3560, V _a3561, V _a3562, V[] _rest3558) => {
V B_3564 = default;
if (_self3556.IsNullish) _self3556 = GlobalV;
B_3564 = Get(t_3563, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_3563, "to", ((V)(300D)), NewObj(7).Put("shu", ((V)(1D))).Put("wide", ((V)(0.7))).Put("lx", ((V)(0.6))).Put("ly", ((V)((-0.3)))).Put("pitch", ((V)((ToNum(Get(B_3564, "pitch")) - 0.1)))).Put("htilt", ((V)((ToNum(Get(B_3564, "htilt")) - 3D)))).Put("close", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(900D))), "to", ((V)(200D)), NewObj(3).Put("sqz", ((V)(0.5))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(6).Put("shu", ((V)(0D))).Put("wide", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("sqz", ((V)(0D))).Put("hap", Get(B_3564, "hap")).V, ((V)("io")));
return Invoke(t_3563, "back", ((V)(300D)));
return default;
}, 1, "peek", false)).V;
SHADES_115 = ((V)(string.Concat("<path d=\"M-9.4-1.2L-12.8-2.6M9.4-1.2L12.8-2.6\" stroke=\"#2a1a30\" stroke-width=\"0.7\" stroke-linecap=\"round\"/><path d=\"M-1.4-0.6Q0-1.8 1.4-0.6\" stroke=\"#2a1a30\" stroke-width=\"0.8\" fill=\"none\"/>", ToStr(Invoke(Invoke(Arr(((V)((-5D))), ((V)(5D))), "map", Fn((V _self1, int _argc3565, V x_3571, V _a3568, V _a3569, V _a3570, V[] _rest3566) => {
return ((V)(string.Concat(new string[] { "<ellipse cx=\"", ToStr(x_3571), "\" cy=\"0\" rx=\"4.1\" ry=\"3.2\" fill=\"#2a2440\" stroke=\"#e8483c\" stroke-width=\"0.6\"/><path d=\"M", NumStr((ToNum(x_3571) - 2.4)), " -1.2Q", NumStr((ToNum(x_3571) - 1D)), " -2.4 ", ToStr(Add(x_3571, ((V)(1D)))), " -2\" stroke=\"#ffffff\" stroke-width=\"0.7\" fill=\"none\" opacity=\"0.7\" stroke-linecap=\"round\"/>" })));
}, 1, "", true)), "join", ((V)("")))))));
TB0_120 = NewObj(14).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.5))).Put("open", ((V)(0.1))).V;
TBB_121 = NewObj(6).Put("hop", Fn((V _self3572, int _argc3573, V t_3579, V _a3576, V _a3577, V _a3578, V[] _rest3574) => {
V B_3580 = default;
if (_self3572.IsNullish) _self3572 = GlobalV;
B_3580 = Get(t_3579, "B");
{
double i_3581 = 0;
i_3581 = 0D;
while (true) {
if (!((i_3581 < 2D))) break;
Invoke(Invoke(Invoke(t_3579, "to", ((V)(110D)), NewObj(2).Put("sq", Add(Get(B_3580, "sq"), ((V)(0.1)))).Put("lift", ((V)((ToNum(Get(B_3580, "lift")) - 1D)))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)((ToNum(Get(B_3580, "sq")) - 0.05)))).Put("lift", Add(Get(B_3580, "lift"), ((V)(5D)))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(4).Put("sq", Get(B_3580, "sq")).Put("lift", Get(B_3580, "lift")).Put("armL", Get(B_3580, "armL")).Put("armR", Get(B_3580, "armR")).V, ((V)("i")));
i_3581++;
}
}
return t_3579;
return default;
}, 1, "hop", false)).Put("jumps", Fn((V _self3583, int _argc3584, V t_3590, V _a3587, V _a3588, V _a3589, V[] _rest3585) => {
V B_3591 = default;
if (_self3583.IsNullish) _self3583 = GlobalV;
B_3591 = Get(t_3590, "B");
Invoke(t_3590, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V);
{
double i_3592 = 0;
i_3592 = 0D;
while (true) {
if (!((i_3592 < 3D))) break;
Invoke(Invoke(Invoke(t_3590, "to", ((V)(120D)), NewObj(4).Put("sq", Add(Get(B_3591, "sq"), ((V)(0.16)))).Put("lift", ((V)((ToNum(Get(B_3591, "lift")) - 1.6)))).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(6).Put("sq", ((V)((ToNum(Get(B_3591, "sq")) - 0.1)))).Put("lift", Add(Add(Get(B_3591, "lift"), ((V)(11D))), ((V)((i_3592 * 2D))))).Put("armL", ((V)(112D))).Put("armR", ((V)(112D))).Put("footL", ((V)(1.4))).Put("footR", ((V)(1.4))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(6).Put("sq", Add(Get(B_3591, "sq"), ((V)(0.02)))).Put("lift", Get(B_3591, "lift")).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i")));
i_3592++;
}
}
return Invoke(t_3590, "back", ((V)(200D)));
return default;
}, 1, "jumps", false)).Put("star", Fn((V _self3594, int _argc3595, V t_3601, V X_3602, V _a3599, V _a3600, V[] _rest3596) => {
V B_3603 = default;
if (_self3594.IsNullish) _self3594 = GlobalV;
B_3603 = Get(t_3601, "B");
Invoke(Invoke(Invoke(t_3601, "to", ((V)(140D)), NewObj(2).Put("sq", Add(Get(B_3603, "sq"), ((V)(0.18)))).Put("lift", ((V)((ToNum(Get(B_3603, "lift")) - 2D)))).V, ((V)("i"))), "to", ((V)(340D)), NewObj(2).Put("sq", ((V)((ToNum(Get(B_3603, "sq")) - 0.12)))).Put("lift", Add(Get(B_3603, "lift"), ((V)(16D)))).V, ((V)("o"))), "to", ((V)(180D)), Call(o_10, V.Undef, NewObj(13).Put("lift", Add(Get(B_3603, "lift"), ((V)(18D)))).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("hLx", ((V)((-7D)))).Put("hRx", ((V)(7D))).Put("hLy", ((V)((-4D)))).Put("hRy", ((V)((-4D)))).Put("footL", ((V)(3D))).Put("footR", ((V)(3D))).Put("open", ((V)(0.6))).Put("wide", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, (Get(X_3602, "tk") is var _t3604 && Truthy(_t3604) ? _t3604 : Get(X_3602, "cheer"))), ((V)("o")));
if (Truthy(Get(X_3602, "cheerFx"))) {
InvokeSpread(t_3601, "fx", new ArrBuilder().Spread(Get(X_3602, "cheerFx")).V);
} else {
Invoke(t_3601, "fx", ((V)("spark")), ((V)("body")), ((V)(4D)));
}
Invoke(Invoke(Invoke(t_3601, "to", ((V)(200D)), NewObj(10).Put("lift", Add(Get(B_3603, "lift"), ((V)(15D)))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io"))), "to", ((V)(280D)), NewObj(2).Put("lift", Get(B_3603, "lift")).Put("sq", Add(Get(B_3603, "sq"), ((V)(0.14)))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(B_3603, "sq")).V, ((V)("o")));
return Invoke(t_3601, "back", ((V)(250D)));
return default;
}, 2, "star", false)).Put("tuck", Fn((V _self3605, int _argc3606, V t_3612, V _a3609, V _a3610, V _a3611, V[] _rest3607) => {
V B_3613 = default;
if (_self3605.IsNullish) _self3605 = GlobalV;
B_3613 = Get(t_3612, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3612, "to", ((V)(140D)), NewObj(2).Put("sq", Add(Get(B_3613, "sq"), ((V)(0.18)))).Put("lift", ((V)((ToNum(Get(B_3613, "lift")) - 2D)))).V, ((V)("i"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)((ToNum(Get(B_3613, "sq")) - 0.1)))).Put("lift", Add(Get(B_3613, "lift"), ((V)(15D)))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("o"))), "to", ((V)(180D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(7D)), ((V)(6D))), NewObj(8).Put("lift", Add(Get(B_3613, "lift"), ((V)(17D)))).Put("sq", Add(Get(B_3613, "sq"), ((V)(0.12)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("footL", ((V)(4D))).Put("footR", ((V)(4D))).Put("close", ((V)(1D))).Put("sqz", ((V)(0.8))).V), ((V)("io"))), "to", ((V)(180D)), NewObj(14).Put("lift", Add(Get(B_3613, "lift"), ((V)(14D)))).Put("sq", ((V)((ToNum(Get(B_3613, "sq")) - 0.06)))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("close", ((V)(0D))).Put("sqz", ((V)(0D))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.45))).V, ((V)("io"))), "to", ((V)(280D)), NewObj(2).Put("lift", Get(B_3613, "lift")).Put("sq", Add(Get(B_3613, "sq"), ((V)(0.14)))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", Get(B_3613, "sq")).Put("wide", ((V)(0D))).V, ((V)("o")));
return Invoke(t_3612, "back", ((V)(250D)));
return default;
}, 1, "tuck", false)).Put("seat", Fn((V _self3614, int _argc3615, V t_3621, V _a3618, V _a3619, V _a3620, V[] _rest3616) => {
V B_3622 = default;
if (_self3614.IsNullish) _self3614 = GlobalV;
B_3622 = Get(t_3621, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3621, "to", ((V)(130D)), NewObj(2).Put("sq", Add(Get(B_3622, "sq"), ((V)(0.14)))).Put("lift", ((V)((ToNum(Get(B_3622, "lift")) - 1.4)))).V, ((V)("i"))), "to", ((V)(280D)), NewObj(4).Put("sq", ((V)((ToNum(Get(B_3622, "sq")) - 0.08)))).Put("lift", Add(Get(B_3622, "lift"), ((V)(10D)))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).V, ((V)("o"))), "to", ((V)(260D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(4D)), ((V)(2D))), NewObj(8).Put("sit", ((V)(1D))).Put("sq", Add(Get(B_3622, "sq"), ((V)(0.06)))).Put("lift", Add(Get(B_3622, "lift"), ((V)(4D)))).Put("footL", ((V)(2.4))).Put("footR", ((V)(2.4))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("open", ((V)(0.4))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("lift", ((V)((ToNum(Get(B_3622, "lift")) - 1.5)))).Put("sq", Add(Get(B_3622, "sq"), ((V)(0.2)))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(13).Put("sit", ((V)(0D))).Put("lift", Add(Get(B_3622, "lift"), ((V)(9D)))).Put("sq", ((V)((ToNum(Get(B_3622, "sq")) - 0.08)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(110D))).Put("armR", ((V)(110D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(280D)), NewObj(2).Put("lift", Get(B_3622, "lift")).Put("sq", Add(Get(B_3622, "sq"), ((V)(0.1)))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", Get(B_3622, "sq")).Put("sqz", ((V)(0D))).V, ((V)("o")));
return Invoke(t_3621, "back", ((V)(250D)));
return default;
}, 1, "seat", false)).Put("spin", Fn((V _self3623, int _argc3624, V t_3630, V _a3627, V _a3628, V _a3629, V[] _rest3625) => {
V B_3631 = default;
if (_self3623.IsNullish) _self3623 = GlobalV;
B_3631 = Get(t_3630, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_3630, "to", ((V)(140D)), NewObj(2).Put("sq", Add(Get(B_3631, "sq"), ((V)(0.16)))).Put("lift", ((V)((ToNum(Get(B_3631, "lift")) - 1.8)))).V, ((V)("i"))), "to", ((V)(380D)), NewObj(7).Put("sq", ((V)((ToNum(Get(B_3631, "sq")) - 0.12)))).Put("lift", Add(Get(B_3631, "lift"), ((V)(16D)))).Put("spin", ((V)(180D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("hap", ((V)(1D))).Put("open", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(5).Put("spin", ((V)(360D))).Put("lift", Get(B_3631, "lift")).Put("sq", Add(Get(B_3631, "sq"), ((V)(0.12)))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("i"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V), "to", ((V)(200D)), NewObj(1).Put("sq", Get(B_3631, "sq")).V, ((V)("o")));
return Invoke(t_3630, "back", ((V)(250D)));
return default;
}, 1, "spin", false)).V;
DGB_124 = NewObj(7).Put("scoop", Fn((V _self3632, int _argc3633, V t_3639, V _a3636, V _a3637, V _a3638, V[] _rest3634) => {
V B_3640 = default;
if (_self3632.IsNullish) _self3632 = GlobalV;
B_3640 = Get(t_3639, "B");
{
double i_3641 = 0;
i_3641 = 0D;
while (true) {
if (!((i_3641 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(t_3639, "to", ((V)(240D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-5D))), ((V)(9D))), NewObj(5).Put("armR", ((V)(14D))).Put("lean", ((V)(0.4))).Put("tilt", ((V)(2D))).Put("lx", ((V)(0.6))).Put("ly", ((V)(0.8))).V), ((V)("i"))), "to", ((V)(260D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(6D)), ((V)(2D))), NewObj(5).Put("armR", ((V)(26D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0.7))).V), ((V)("o"))), "fx", ((V)("sand")), ((V)("pawR")), ((V)(4D))), "wait", ((V)(100D)));
i_3641++;
}
}
return Invoke(t_3639, "back", ((V)(300D)));
return default;
}, 1, "scoop", false)).Put("pile", Fn((V _self3643, int _argc3644, V t_3650, V _a3647, V _a3648, V _a3649, V[] _rest3645) => {
V B_3651 = default;
if (_self3643.IsNullish) _self3643 = GlobalV;
B_3651 = Get(t_3650, "B");
Invoke(Invoke(Invoke(t_3650, "to", ((V)(300D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(8D)), ((V)(7D))), NewObj(3).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("ly", ((V)(0.8))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(3).Put("hLy", ((V)(10D))).Put("hRy", ((V)(10D))).Put("sq", Add(Get(B_3651, "sq"), ((V)(0.02)))).V, NewObj(3).Put("hLy", ((V)(6D))).Put("hRy", ((V)(6D))).Put("sq", Get(B_3651, "sq")).V, ((V)("o"))), "fx", ((V)("sand")), ((V)("pawL")), ((V)(3D)));
return Invoke(t_3650, "back", ((V)(320D)));
return default;
}, 1, "pile", false)).Put("bucket", Fn((V _self3652, int _argc3653, V t_3659, V X_3660, V rec_3661, V _a3658, V[] _rest3654) => {
V B_3662 = default;
V g_3663 = default;
V s_3664 = default;
V l_3665 = default;
V e_3666 = default;
if (_self3652.IsNullish) _self3652 = GlobalV;
B_3662 = Get(t_3659, "B");
Invoke(t_3659, "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-9D))), ((V)(7D))), NewObj(4).Put("armR", ((V)(20D))).Put("lx", ((V)(0.7))).Put("ly", ((V)(0.7))).Put("tilt", ((V)(2D))).V), ((V)("io")));
g_3663 = Get(t_3659, "t");
Invoke(t_3659, "to", ((V)(360D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-4D)))), NewObj(4).Put("armR", ((V)(44D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0.4))).Put("tilt", ((V)(0D))).V), ((V)("io")));
Invoke(t_3659, "to", ((V)(260D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(6D)), ((V)(5D))), NewObj(2).Put("armR", ((V)(22D))).Put("sq", Add(Get(B_3662, "sq"), ((V)(0.04)))).V), ((V)("i")));
s_3664 = Get(t_3659, "t");
Invoke(Invoke(t_3659, "fx", ((V)("sand")), ((V)("pawR")), ((V)(5D))), "wait", ((V)(300D)));
Invoke(t_3659, "to", ((V)(320D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-6D)))), NewObj(4).Put("armR", ((V)(48D))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.3))).Put("sq", Get(B_3662, "sq")).V), ((V)("o")));
l_3665 = Get(t_3659, "t");
Invoke(Invoke(t_3659, "to", ((V)(200D)), NewObj(5).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("wide", ((V)(0D))).V, ((V)("o"))), "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-9D))), ((V)(7D))), NewObj(2).Put("armR", ((V)(20D))).Put("lx", ((V)(0.7))).V), ((V)("io")));
e_3666 = Get(t_3659, "t");
Invoke(Set(rec_3661, "bk", (Get(rec_3661, "bk") is var _t3667 && Truthy(_t3667) ? _t3667 : Arr())), "push", Arr(g_3663, s_3664, l_3665, e_3666));
return Invoke(t_3659, "back", ((V)(380D)));
return default;
}, 3, "bucket", false)).Put("pat", Fn((V _self3668, int _argc3669, V t_3675, V _a3672, V _a3673, V _a3674, V[] _rest3670) => {
if (_self3668.IsNullish) _self3668 = GlobalV;
Invoke(Invoke(Invoke(t_3675, "to", ((V)(280D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(8D)), ((V)(2D))), NewObj(3).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("ly", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(5D)), NewObj(2).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V, NewObj(2).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("sand")), ((V)("pawR")), ((V)(2D)));
return Invoke(t_3675, "back", ((V)(300D)));
return default;
}, 1, "pat", false)).Put("flag", Fn((V _self3676, int _argc3677, V t_3683, V X_3684, V rec_3685, V _a3682, V[] _rest3678) => {
if (_self3676.IsNullish) _self3676 = GlobalV;
Invoke(Invoke(t_3683, "to", ((V)(340D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(5D)), ((V)((-6D)))), NewObj(2).Put("armR", ((V)(40D))).Put("ly", ((V)(0.3))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("hRy", ((V)((-2D)))).V, ((V)("i")));
Invoke(Set(rec_3685, "flag", (Get(rec_3685, "flag") is var _t3686 && Truthy(_t3686) ? _t3686 : Arr())), "push", Get(t_3683, "t"));
Invoke(t_3683, "to", ((V)(260D)), Call(o_10, V.Undef, NewObj(5).Put("hRy", ((V)((-7D)))).Put("armR", ((V)(60D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, Get(X_3684, "cheer")), ((V)("o")));
if (Truthy(Get(X_3684, "cheerFx"))) {
InvokeSpread(t_3683, "fx", new ArrBuilder().Spread(Get(X_3684, "cheerFx")).V);
} else {
Invoke(t_3683, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
}
Invoke(t_3683, "wait", ((V)(500D)));
return Invoke(t_3683, "back", ((V)(400D)));
return default;
}, 3, "flag", false)).Put("admire", Fn((V _self3687, int _argc3688, V t_3694, V _a3691, V _a3692, V _a3693, V[] _rest3689) => {
V B_3695 = default;
if (_self3687.IsNullish) _self3687 = GlobalV;
B_3695 = Get(t_3694, "B");
Invoke(Invoke(Invoke(t_3694, "to", ((V)(400D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(10D)), ((V)((-6D)))), NewObj(8).Put("armL", ((V)(28D))).Put("armR", ((V)(28D))).Put("pitch", Add(Get(B_3695, "pitch"), ((V)(0.14)))).Put("ly", ((V)(0.2))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).Put("close", ((V)(0.4))).Put("htilt", ((V)(6D))).V), ((V)("io"))), "fx", ((V)("heart")), ((V)("head"))), "wait", ((V)(900D)));
return Invoke(t_3694, "back", ((V)(420D)));
return default;
}, 1, "admire", false)).Put("crumble", Fn((V _self3696, int _argc3697, V t_3703, V X_3704, V rec_3705, V _a3702, V[] _rest3698) => {
V B_3706 = default;
if (_self3696.IsNullish) _self3696 = GlobalV;
B_3706 = Get(t_3703, "B");
Invoke(Set(rec_3705, "cr", (Get(rec_3705, "cr") is var _t3707 && Truthy(_t3707) ? _t3707 : Arr())), "push", Get(t_3703, "t"));
Invoke(Invoke(Invoke(Invoke(t_3703, "to", ((V)(200D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.55))).Put("mw", ((V)(0.5))).Put("pitch", ((V)((ToNum(Get(B_3706, "pitch")) - 0.08)))).Put("lean", ((V)((-0.6)))).Put("frown", ((V)(0.4))).V, ((V)("o"))), "wait", ((V)(700D))), "to", ((V)(240D)), NewObj(7).Put("frown", ((V)(0D))).Put("sqz", ((V)(0.8))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("wide", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("sq", Add(Get(B_3706, "sq"), ((V)(0.03)))).V, NewObj(1).Put("sq", Get(B_3706, "sq")).V, ((V)("o")));
return Invoke(t_3703, "back", ((V)(420D)));
return default;
}, 3, "crumble", false)).V;
SAND_125 = ((V)("#e6c682"));
SANDK_126 = ((V)("#b8954e"));
SANDL_127 = ((V)("#f5e0b0"));
PAIL_128 = ((V)("<path d=\"M-3-2.6H3L2.3 3H-2.3Z\" fill=\"#5ab4f0\" stroke=\"#2e86c8\" stroke-width=\"0.4\"/><path d=\"M-3-2.6H3V-1.6H-3Z\" fill=\"#ffd24a\" stroke=\"#d9a22a\" stroke-width=\"0.3\"/><path d=\"M-2.6-2.6Q0-6 2.6-2.6\" stroke=\"#2e86c8\" stroke-width=\"0.4\" fill=\"none\"/>"));
SPADE_129 = ((V)("<path d=\"M-0.45 0H0.45V7H-0.45Z\" fill=\"#ffd24a\" stroke=\"#d9a22a\" stroke-width=\"0.25\"/><path d=\"M-2 7H2V9.6Q0 12-2 9.6Z\" fill=\"#e8483c\" stroke=\"#b8302a\" stroke-width=\"0.35\"/>"));
BLC_131 = Arr(((V)("#ff6f6f")), ((V)("#ffcc3a")), ((V)("#5ab4f0")), ((V)("#7cc35a")), ((V)("#b98ae8")));
BLL_132 = ((V)("ABCDE"));
BLK_133 = Fn((V _self1, int _argc3708, V i_3714, V _a3711, V _a3712, V _a3713, V[] _rest3709) => {
return ((V)(string.Concat(new string[] { "<rect x=\"-2.8\" y=\"-2.8\" width=\"5.6\" height=\"5.6\" rx=\"0.9\" fill=\"", ToStr(GetK(BLC_131, i_3714)), "\" stroke=\"", ToStr(Call(shade_42, V.Undef, GetK(BLC_131, i_3714), ((V)(0.7)))), "\" stroke-width=\"0.4\"/><path d=\"M-2.2-2.2H2.2\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.5\" stroke-linecap=\"round\"/><text x=\"0\" y=\"1.6\" text-anchor=\"middle\" font-family=\"Fredoka,sans-serif\" font-weight=\"700\" font-size=\"4.3\" fill=\"#ffffff\" stroke=\"", ToStr(Call(shade_42, V.Undef, GetK(BLC_131, i_3714), ((V)(0.6)))), "\" stroke-width=\"0.45\" paint-order=\"stroke\">", ToStr(GetK(BLL_132, i_3714)), "</text>" })));
}, 1, "", true);
BLB_134 = NewObj(5).Put("stack", Fn((V _self3715, int _argc3716, V t_3722, V X_3723, V rec_3724, V _a3721, V[] _rest3717) => {
double n_3725 = 0;
double top_3726 = 0;
if (_self3715.IsNullish) _self3715 = GlobalV;
n_3725 = (ToNum(Set(rec_3724, "n", Add((Get(rec_3724, "n") is var _t3727 && Truthy(_t3727) ? _t3727 : ((V)(0D))), ((V)(1D))))) - 1D);
top_3726 = (4D + (n_3725 * 8.1));
Invoke(t_3722, "to", ((V)(320D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-6D))), ((V)(8D))), NewObj(4).Put("armR", ((V)(22D))).Put("lean", ((V)(0.5))).Put("lx", ((V)(0.6))).Put("ly", ((V)(0.8))).V), ((V)("io")));
Invoke(Set(rec_3724, "pick", (Get(rec_3724, "pick") is var _t3728 && Truthy(_t3728) ? _t3728 : Arr())), "push", Get(t_3722, "t"));
Invoke(Invoke(t_3722, "to", ((V)(420D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-14D))), ((V)((-top_3726)))), NewObj(3).Put("armR", Call(cl_39, V.Undef, ((V)((34D + (n_3725 * 19D)))), ((V)(34D)), ((V)(118D)))).Put("lean", ((V)(0D))).Put("ly", ((V)(((-0.2) - (n_3725 * 0.12))))).V), ((V)("io"))), "osc", ((V)(300D)), ((V)(2D)), NewObj(1).Put("hRy", ((V)(((-top_3726) - 0.6)))).V, NewObj(1).Put("hRy", ((V)((-top_3726)))).V, ((V)("l")));
Invoke(Set(rec_3724, "place", (Get(rec_3724, "place") is var _t3729 && Truthy(_t3729) ? _t3729 : Arr())), "push", Get(t_3722, "t"));
Invoke(t_3722, "to", ((V)(200D)), NewObj(2).Put("sqz", ((V)(0.4))).Put("smile", ((V)(1D))).V, ((V)("o")));
return Invoke(t_3722, "back", ((V)(380D)));
return default;
}, 3, "stack", false)).Put("wobble", Fn((V _self3730, int _argc3731, V t_3737, V X_3738, V rec_3739, V _a3736, V[] _rest3732) => {
if (_self3730.IsNullish) _self3730 = GlobalV;
Invoke(Set(rec_3739, "wob", (Get(rec_3739, "wob") is var _t3740 && Truthy(_t3740) ? _t3740 : Arr())), "push", Get(t_3737, "t"));
Invoke(Invoke(Invoke(Invoke(Invoke(t_3737, "to", ((V)(200D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(10D)), ((V)((-9D)))), NewObj(6).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.5))).Put("lean", ((V)((-0.8)))).V), ((V)("o"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("tilt", ((V)(2D))).V, NewObj(1).Put("tilt", ((V)((-2D)))).V, ((V)("s"))), "fx", ((V)("sweat")), ((V)("head"))), "to", ((V)(400D)), NewObj(3).Put("wide", ((V)(0.3))).Put("open", ((V)(0.1))).Put("tilt", ((V)(0D))).V), "to", ((V)(200D)), NewObj(3).Put("sqz", ((V)(0.5))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)("o")));
return Invoke(t_3737, "back", ((V)(380D)));
return default;
}, 3, "wobble", false)).Put("topple", Fn((V _self3741, int _argc3742, V t_3748, V X_3749, V rec_3750, V _a3747, V[] _rest3743) => {
V B_3751 = default;
if (_self3741.IsNullish) _self3741 = GlobalV;
B_3751 = Get(t_3748, "B");
Invoke(Set(rec_3750, "top", (Get(rec_3750, "top") is var _t3752 && Truthy(_t3752) ? _t3752 : Arr())), "push", Get(t_3748, "t"));
Invoke(Invoke(Invoke(t_3748, "wait", ((V)(250D))), "to", ((V)(220D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(10D)), ((V)((-13D)))), NewObj(6).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.5))).Put("pitch", Add(Get(B_3751, "pitch"), ((V)(0.1)))).V), ((V)("o"))), "wait", ((V)(700D)));
return Invoke(t_3748, "back", ((V)(400D)));
return default;
}, 3, "topple", false)).Put("giggle", Fn((V _self3753, int _argc3754, V t_3760, V _a3757, V _a3758, V _a3759, V[] _rest3755) => {
if (_self3753.IsNullish) _self3753 = GlobalV;
Invoke(BEAT_16, "giggle", t_3760, ((V)((-1D))));
return t_3760;
return default;
}, 1, "giggle", false)).Put("tidy", Fn((V _self3761, int _argc3762, V t_3768, V X_3769, V rec_3770, V _a3767, V[] _rest3763) => {
V B_3771 = default;
if (_self3761.IsNullish) _self3761 = GlobalV;
B_3771 = Get(t_3768, "B");
Invoke(Set(rec_3770, "tidy", (Get(rec_3770, "tidy") is var _t3772 && Truthy(_t3772) ? _t3772 : Arr())), "push", Get(t_3768, "t"));
Invoke(Invoke(t_3768, "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-12D))), ((V)(8D))), NewObj(4).Put("armR", ((V)(22D))).Put("lean", ((V)(0.6))).Put("lx", ((V)(0.8))).Put("ly", ((V)(0.7))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("hRx", Add(Get(B_3771, "hRx"), ((V)(4D)))).V, NewObj(1).Put("hRx", ((V)((ToNum(Get(B_3771, "hRx")) - 1D)))).V, ((V)("s")));
Set(rec_3770, "tidyE", Get(t_3768, "t"));
Invoke(t_3768, "to", ((V)(200D)), NewObj(2).Put("smile", ((V)(1D))).Put("hap", ((V)(0.5))).V);
return Invoke(t_3768, "back", ((V)(380D)));
return default;
}, 3, "tidy", false)).V;
CAN_136 = ((V)("<path d=\"M-1.2 0H6.8L6.2 6.4Q2.8 7.4-0.6 6.4Z\" fill=\"#7cc35a\" stroke=\"#4f8f3a\" stroke-width=\"0.45\"/><path d=\"M0 0Q2.8-3.6 5.6 0\" stroke=\"#4f8f3a\" stroke-width=\"0.7\" fill=\"none\"/><path d=\"M6.6 2.2L11.6-1.2L12.2-0.2L7 3.6Z\" fill=\"#7cc35a\" stroke=\"#4f8f3a\" stroke-width=\"0.4\"/><ellipse cx=\"12.1\" cy=\"-0.9\" rx=\"0.9\" ry=\"1.4\" transform=\"rotate(-35 12.1 -0.9)\" fill=\"#a8d88a\" stroke=\"#4f8f3a\" stroke-width=\"0.35\"/><path d=\"M0.4 1.4H5.8\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.4\"/>"));
RSB_138 = NewObj(6).Put("hold", Fn((V _self3773, int _argc3774, V t_3780, V _a3777, V _a3778, V _a3779, V[] _rest3775) => {
V B_3781 = default;
if (_self3773.IsNullish) _self3773 = GlobalV;
B_3781 = Get(t_3780, "B");
Invoke(Invoke(t_3780, "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0.8))).Put("ly", ((V)(0.2))).Put("wide", ((V)(0.3))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "osc", ((V)(1800D)), ((V)(3D)), NewObj(2).Put("hRy", ((V)((ToNum(Get(B_3781, "hRy")) - 0.8)))).Put("htilt", ((V)(2D))).V, NewObj(2).Put("hRy", Add(Get(B_3781, "hRy"), ((V)(0.4)))).Put("htilt", ((V)((-2D)))).V, ((V)("s")));
return Invoke(t_3780, "back", ((V)(300D)));
return default;
}, 1, "hold", false)).Put("turn", Fn((V _self3782, int _argc3783, V t_3789, V _a3786, V _a3787, V _a3788, V[] _rest3784) => {
V B_3790 = default;
if (_self3782.IsNullish) _self3782 = GlobalV;
B_3790 = Get(t_3789, "B");
Invoke(Invoke(t_3789, "to", ((V)(200D)), NewObj(2).Put("sqz", ((V)(0.3))).Put("smile", ((V)(1D))).V), "osc", ((V)(1400D)), ((V)(4D)), NewObj(2).Put("hRx", ((V)((ToNum(Get(B_3790, "hRx")) - 1.2)))).Put("tilt", ((V)(1D))).V, NewObj(2).Put("hRx", Add(Get(B_3790, "hRx"), ((V)(0.6)))).Put("tilt", ((V)((-1D)))).V, ((V)("s")));
return Invoke(t_3789, "back", ((V)(300D)));
return default;
}, 1, "turn", false)).Put("fire", Fn((V _self3791, int _argc3792, V t_3798, V _a3795, V _a3796, V _a3797, V[] _rest3793) => {
V B_3799 = default;
if (_self3791.IsNullish) _self3791 = GlobalV;
B_3799 = Get(t_3798, "B");
Invoke(Invoke(Invoke(Invoke(t_3798, "to", ((V)(160D)), NewObj(7).Put("armR", ((V)(74D))).Put("hRy", ((V)((ToNum(Get(B_3799, "hRy")) - 5D)))).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.5))).Put("lean", ((V)((-0.8)))).Put("sq", ((V)((ToNum(Get(B_3799, "sq")) - 0.04)))).V, ((V)("o"))), "osc", ((V)(600D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(100D)), NewObj(1).Put("x", ((V)(0D))).V), "wait", ((V)(200D)));
return t_3798;
return default;
}, 1, "fire", false)).Put("blow", Fn((V _self3800, int _argc3801, V t_3807, V _a3804, V _a3805, V _a3806, V[] _rest3802) => {
if (_self3800.IsNullish) _self3800 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3807, "to", ((V)(260D)), NewObj(3).Put("puff", ((V)(0.9))).Put("open", ((V)(0D))).Put("lx", ((V)(0.8))).V), "to", ((V)(160D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.45))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth"))), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0.8))).Put("open", ((V)(0D))).V), "to", ((V)(160D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth"))), "wait", ((V)(300D))), "to", ((V)(240D)), NewObj(5).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.2))).Put("wide", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("sweat")), ((V)("head"))), "wait", ((V)(300D)));
return Invoke(t_3807, "back", ((V)(420D)));
return default;
}, 1, "blow", false)).Put("eat", Fn((V _self3808, int _argc3809, V t_3815, V X_3816, V _a3813, V _a3814, V[] _rest3810) => {
V B_3817 = default;
if (_self3808.IsNullish) _self3808 = GlobalV;
B_3817 = Get(t_3815, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3815, "to", ((V)(420D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-13D)))), NewObj(5).Put("armR", ((V)(36D))).Put("pitch", Add((Get(B_3817, "pitch") is var _t3818 && Truthy(_t3818) ? _t3818 : ((V)(0D))), ((V)(0.02)))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("open", ((V)(0.4))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.6))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(5D)), NewObj(2).Put("puff", ((V)(0.6))).Put("open", ((V)(0.1))).V, NewObj(2).Put("puff", ((V)(0.2))).Put("open", ((V)(0D))).V, ((V)("l"))), "to", ((V)(260D)), Call(o_10, V.Undef, NewObj(4).Put("smile", ((V)(1D))).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.7))).Put("puff", ((V)(0D))).V, Get(X_3816, "cheer")), ((V)("o"))), "fx", ((V)("heart")), ((V)("head"))), "wait", ((V)(300D)));
return Invoke(t_3815, "back", ((V)(420D)));
return default;
}, 2, "eat", false)).Put("new", Fn((V _self3819, int _argc3820, V t_3826, V _a3823, V _a3824, V _a3825, V[] _rest3821) => {
if (_self3819.IsNullish) _self3819 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_3826, "to", ((V)(360D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)((-10D))), ((V)((-3D)))), NewObj(2).Put("armL", ((V)(54D))).Put("lx", ((V)(0.6))).V), ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(160D)), NewObj(1).Put("sqz", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("sqz", ((V)(0D))).V);
return Invoke(t_3826, "back", ((V)(380D)));
return default;
}, 1, "new", false)).V;
BB_140 = NewObj(0).V;
Call(build_36, V.Undef, V.Null, NewObj(0).V);
Call(bedBuild_55, V.Undef, V.Null, NewObj(0).V);
Call(waterBuild_74, V.Undef, V.Null, NewObj(0).V);
Call(playBuild_94, V.Undef, V.Null, NewObj(0).V);
Call(bBuild_141, V.Undef, V.Null, NewObj(0).V);
Set(R_8, "HOUSE", NewObj(49).Put("TL", TL_11).Put("BEAT", BEAT_16).Put("ZB", ZB_48).Put("TB", TB_62).Put("SB0", SB0_63).Put("WB0", WB0_64).Put("PB", PB_78).Put("RB", RB_79).Put("CB", CB_84).Put("build", build_36).Put("bedBuild", bedBuild_55).Put("waterBuild", waterBuild_74).Put("playBuild", playBuild_94).Put("bBuild", bBuild_141).Put("hand", hand_12).Put("both", both_13).Put("SIDE", SIDE_14).Put("SIT0", SIT0_17).Put("LNG0", LNG0_18).Put("LIE0", LIE0_40).Put("CURL0", CURL0_41).Put("PROF", PROF_35).Put("BED", BED_54).Put("WAT", WAT_73).Put("PLY", PLY_93).Put("BB", BB_140).Put("ICON", ICON_45).Put("o", o_10).Put("sitdown", sitdown_20).Put("standup", standup_23).Put("enterMove", enterMove_21).Put("exitMove", exitMove_22).Put("bHold", bHold_101).Put("gnd", gnd_96).Put("rside", rside_97).Put("G", G_100).Put("facing", facing_87).Put("win", win_88).Put("ss", ss_25).Put("cl", cl_39).Put("r2", r2_38).Put("shade", shade_42).Put("ci", ci_43).Put("pa", pa_44).Put("lerp", lerp_99).Put("okp", okp_95).Put("LAP", LAP_27).Put("TWO", TWO_26).Put("BATH0", BATH0_56).V);
if (Truthy(Get(G("window"), "SquishLazy"))) {
Invoke(Get(G("window"), "SquishLazy"), "house", Get(R_8, "HOUSE"));
}
if (Truthy(Get(G("window"), "HouseCreatures"))) {
Invoke(Get(G("window"), "HouseCreatures"), "forEach", Fn((V _self1, int _argc3827, V f_3833, V _a3830, V _a3831, V _a3832, V[] _rest3828) => {
return Call(f_3833, V.Undef, Get(R_8, "HOUSE"));
}, 1, "", true));
}
Set(G("window"), "HouseCreatures", NewObj(1).Put("push", Fn((V _self1, int _argc3834, V f_3840, V _a3837, V _a3838, V _a3839, V[] _rest3835) => {
return Call(f_3840, V.Undef, Get(R_8, "HOUSE"));
}, 1, "push", true)).V);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
