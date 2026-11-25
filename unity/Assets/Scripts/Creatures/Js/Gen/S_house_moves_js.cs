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
Call(Named(boot_2278 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
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
bv_154 = Fn((V _arrowThis164, int _argc157, V p_163, V _a160, V _a161, V _a162, V[] _rest158) => {
return (!GetK(@base_149, p_163).IsNullish ? GetK(@base_149, p_163) : (GetK(REST_9, p_163) is var _t165 && Truthy(_t165) ? _t165 : ((V)(0D))));
}, 1, "", true);
T_155 = NewObj(10).Put("B", @base_149).Getter("t", Fn((V _self166, int _argc167, V _a169, V _a170, V _a171, V _a172, V[] _rest168) => {
if (_self166.IsNullish) _self166 = GlobalV;
return t_153;
return default;
}, 0, "t", false)).Put("to", Fn((V _self173, int _argc174, V dt_180, V v_181, V ez_182, V _a179, V[] _rest175) => {
if (_self173.IsNullish) _self173 = GlobalV;
{
foreach (V _k183 in ForInKeys(v_181)) {
V p_184 = default;
p_184 = _k183;
V L_185 = default;
L_185 = (GetK(k_150, p_184) is var _t186 && Truthy(_t186) ? _t186 : SetK(k_150, p_184, Arr(Arr(((V)(0D)), Call(bv_154, V.Undef, p_184)))));
if (Lt(GetIdx(GetIdx(L_185, (ToNum(Get(L_185, "length")) - 1D)), 0D), t_153)) {
Invoke(L_185, "push", Arr(t_153, GetIdx(GetIdx(L_185, (ToNum(Get(L_185, "length")) - 1D)), 1D), ((V)("l"))));
}
}
}
t_153 = Add(t_153, dt_180);
{
foreach (V _k187 in ForInKeys(v_181)) {
V p_188 = default;
p_188 = _k187;
Invoke(GetK(k_150, p_188), "push", Arr(t_153, GetK(v_181, p_188), (ez_182 is var _t189 && Truthy(_t189) ? _t189 : ((V)("io")))));
}
}
return T_155;
return default;
}, 3, "to", false)).Put("wait", Fn((V _self190, int _argc191, V dt_197, V _a194, V _a195, V _a196, V[] _rest192) => {
if (_self190.IsNullish) _self190 = GlobalV;
t_153 = Add(t_153, dt_197);
return T_155;
return default;
}, 1, "wait", false)).Put("at", Fn((V _self198, int _argc199, V x_205, V _a202, V _a203, V _a204, V[] _rest200) => {
if (_self198.IsNullish) _self198 = GlobalV;
t_153 = x_205;
return T_155;
return default;
}, 1, "at", false)).Put("e", Fn((V _self206, int _argc207, V _a209, V _a210, V _a211, V _a212, V[] _rest208) => {
V a_213 = default;
if (_self206.IsNullish) _self206 = GlobalV;
a_213 = RestArgs(0, _argc207, _a209, _a210, _a211, _a212, _rest208);
Invoke(ev_151, "push", new ArrBuilder().Add(t_153).Spread(a_213).V);
return T_155;
return default;
}, 1, "e", false)).Put("fx", Fn((V _self214, int _argc215, V n_221, V w_222, V c_223, V _a220, V[] _rest216) => {
if (_self214.IsNullish) _self214 = GlobalV;
Invoke(ev_151, "push", Arr(t_153, ((V)("emit")), n_221, (w_222 is var _t224 && Truthy(_t224) ? _t224 : ((V)("body"))), c_223));
return T_155;
return default;
}, 3, "fx", false)).Put("osc", Fn((V _self225, int _argc226, V dt_232, V n_233, V A_234, V Bv_235, V[] _rest227) => {
double h_237 = 0;
V ez_236 = default;
if (_self225.IsNullish) _self225 = GlobalV;
ez_236 = (_argc226 > 4 ? _rest227[0] : V.Undef);
h_237 = ((ToNum(dt_232) / ToNum(n_233)) / 2D);
{
double i_238 = 0;
i_238 = 0D;
while (true) {
if (!(Lt(((V)(i_238)), n_233))) break;
Invoke(Invoke(T_155, "to", ((V)(h_237)), A_234, (ez_236 is var _t241 && Truthy(_t241) ? _t241 : ((V)("io")))), "to", ((V)(h_237)), Bv_235, (ez_236 is var _t240 && Truthy(_t240) ? _t240 : ((V)("io"))));
i_238++;
}
}
return T_155;
return default;
}, 5, "osc", false)).Put("back", Fn((V _self242, int _argc243, V dt_249, V keys_250, V ez_251, V _a248, V[] _rest244) => {
V v_252 = default;
if (_self242.IsNullish) _self242 = GlobalV;
v_252 = NewObj(0).V;
Invoke((keys_250 is var _t261 && Truthy(_t261) ? _t261 : Object_keys(k_150)), "forEach", Fn((V _arrowThis260, int _argc253, V p_259, V _a256, V _a257, V _a258, V[] _rest254) => {
return SetK(v_252, p_259, Call(bv_154, V.Undef, p_259));
}, 1, "", true));
return Invoke(T_155, "to", (dt_249 is var _t262 && Truthy(_t262) ? _t262 : ((V)(400D))), v_252, ez_251);
return default;
}, 3, "back", false)).Put("out", Fn((V _self263, int _argc264, V x_270, V loop_271, V _a268, V _a269, V[] _rest265) => {
if (_self263.IsNullish) _self263 = GlobalV;
{
foreach (V _k272 in ForInKeys(k_150)) {
V p_273 = default;
p_273 = _k272;
Invoke(GetK(k_150, p_273), "sort", Fn((V _arrowThis282, int _argc274, V a_280, V b_281, V _a278, V _a279, V[] _rest275) => {
return ((V)((ToNum(GetIdx(a_280, 0D)) - ToNum(GetIdx(b_281, 0D)))));
}, 2, "", true));
if (Truthy(loop_271)) {
V L_283 = default;
L_283 = GetK(k_150, p_273);
if (Lt(GetIdx(GetIdx(L_283, (ToNum(Get(L_283, "length")) - 1D)), 0D), t_153)) {
Invoke(L_283, "push", Arr(t_153, GetIdx(GetIdx(L_283, 0D), 1D), ((V)("io"))));
}
}
}
}
Invoke(ev_151, "sort", Fn((V _arrowThis292, int _argc284, V a_290, V b_291, V _a288, V _a289, V[] _rest285) => {
return ((V)((ToNum(GetIdx(a_290, 0D)) - ToNum(GetIdx(b_291, 0D)))));
}, 2, "", true));
return Object_assign((Truthy(loop_271) ? NewObj(1).Put("loop", t_153).V : NewObj(1).Put("dur", t_153).V), NewObj(3).Put("k", k_150).Put("ev", ev_151).Put("emit", em_152).V, (x_270 is var _t293 && Truthy(_t293) ? _t293 : NewObj(0).V));
return default;
}, 2, "out", false)).V;
return T_155;
return default;
}, 1, "TL", false);
seq_19 = Fn((V _self294, int _argc295, V t_301, V list_302, V gap_303, V _a300, V[] _rest296) => {
if (_self294.IsNullish) _self294 = GlobalV;
Invoke(list_302, "forEach", Fn((V _arrowThis312, int _argc304, V b_310, V i_311, V _a308, V _a309, V[] _rest305) => {
Invoke(t_301, "wait", GetIdx(gap_303, (ToNum(i_311) % ToNum(Get(gap_303, "length")))));
if (string.Equals(Typeof(b_310), "function")) {
Call(b_310, V.Undef, t_301);
} else {
V n_313 = default;
V a_314 = default;
{ V _t315 = ((b_310.O is JsArray) ? b_310 : Arr(b_310));
{ V _t316 = ListOf(_t315);
{ V _t317 = GetIdx(_t316, 0D);
n_313 = _t317; }
{ V _t318 = GetIdx(_t316, 1D);
a_314 = _t318; }
} }
InvokeK(BEAT_16, n_313, t_301, a_314);
}
return default;
}, 2, "", true));
return t_301;
return default;
}, 3, "seq", false);
sitdown_20 = Fn((V _self319, int _argc320, V B_326, V P_327, V _a324, V _a325, V[] _rest321) => {
V t_328 = default;
V all_329 = default;
V v_330 = default;
if (_self319.IsNullish) _self319 = GlobalV;
t_328 = Call(TL_11, V.Undef, REST_9);
all_329 = Call(keysOf_15, V.Undef, B_326);
Call(enterMove_21, V.Undef, t_328, B_326, (Get(P_327, "dn") is var _t331 && Truthy(_t331) ? _t331 : ((V)("hop"))));
if (Truthy(Get(P_327, "dnX"))) {
Invoke(P_327, "dnX", t_328, B_326);
}
v_330 = NewObj(0).V;
Invoke(all_329, "forEach", Fn((V _arrowThis339, int _argc332, V p_338, V _a335, V _a336, V _a337, V[] _rest333) => {
return SetK(v_330, p_338, GetK(B_326, p_338));
}, 1, "", true));
Invoke(t_328, "to", ((V)(140D)), v_330, ((V)("io")));
return Invoke(t_328, "out", NewObj(3).Put("next", ((V)("sit"))).Put("blend", ((V)(220D))).Put("look", (true ? V.True : V.False)).V);
return default;
}, 2, "sitdown", false);
enterMove_21 = Fn((V _self340, int _argc341, V t_347, V B_348, V st_349, V _a346, V[] _rest342) => {
V L_350 = default;
V Q_351 = default;
if (_self340.IsNullish) _self340 = GlobalV;
L_350 = (Get(B_348, "lift") is var _t352 && Truthy(_t352) ? _t352 : ((V)(0D)));
Q_351 = (Get(B_348, "sq") is var _t353 && Truthy(_t353) ? _t353 : ((V)(0D)));
if (SEqS(st_349, "float")) {
Invoke(Invoke(Invoke(t_347, "to", ((V)(260D)), NewObj(3).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.04)))).Put("hap", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(900D)), Call(o_10, V.Undef, B_348, NewObj(1).Put("lift", Add(L_350, ((V)(0.6)))).V), ((V)("s"))), "to", ((V)(320D)), NewObj(2).Put("lift", L_350).Put("sq", Q_351).V, ((V)("io")));
} else {
if (SEqS(st_349, "flop")) {
Invoke(Invoke(Invoke(Invoke(Invoke(t_347, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.1))).Put("tilt", ((V)((-4D)))).V), "to", ((V)(260D)), NewObj(4).Put("lift", ((V)(6D))).Put("sq", ((V)((-0.08)))).Put("tilt", ((V)(6D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_10, V.Undef, B_348, NewObj(3).Put("lift", ((V)((ToNum(L_350) - 1D)))).Put("sq", Add(Q_351, ((V)(0.16)))).Put("tilt", ((V)(0D))).V), ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)((ToNum(Q_351) - 0.03)))).Put("lift", Add(L_350, ((V)(0.6)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(3).Put("sq", Q_351).Put("lift", L_350).Put("open", (Get(B_348, "open") is var _t354 && Truthy(_t354) ? _t354 : ((V)(0D)))).V, ((V)("io")));
} else {
if (SEqS(st_349, "bounce")) {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_347, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.14))).V), "to", ((V)(240D)), NewObj(2).Put("lift", ((V)(8D))).Put("sq", ((V)((-0.14)))).V, ((V)("o"))), "to", ((V)(200D)), Call(o_10, V.Undef, B_348, NewObj(2).Put("lift", L_350).Put("sq", Add(Q_351, ((V)(0.2)))).V), ((V)("i"))), "to", ((V)(180D)), NewObj(2).Put("lift", Add(L_350, ((V)(3D)))).Put("sq", ((V)((ToNum(Q_351) - 0.08)))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(2).Put("lift", L_350).Put("sq", Add(Q_351, ((V)(0.1)))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(2).Put("lift", Add(L_350, ((V)(0.8)))).Put("sq", ((V)((ToNum(Q_351) - 0.02)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", L_350).Put("sq", Q_351).V, ((V)("io")));
} else {
if (SEqS(st_349, "spin")) {
Invoke(Invoke(Invoke(Invoke(Invoke(t_347, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.12))).V), "to", ((V)(380D)), NewObj(5).Put("lift", ((V)(9D))).Put("sq", ((V)((-0.12)))).Put("spin", ((V)(360D))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_10, V.Undef, B_348, NewObj(3).Put("lift", ((V)((ToNum(L_350) - 0.4)))).Put("sq", Add(Q_351, ((V)(0.12)))).Put("spin", ((V)(360D))).V), ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)((ToNum(Q_351) - 0.02)))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(3).Put("sq", Q_351).Put("spin", ((V)(360D))).Put("lift", L_350).V, ((V)("io")));
} else {
if (SEqS(st_349, "climb")) {
Invoke(Invoke(Invoke(Invoke(Invoke(t_347, "to", ((V)(220D)), NewObj(4).Put("footL", ((V)(3D))).Put("lift", ((V)(1.5))).Put("tilt", ((V)(2D))).Put("armL", ((V)(30D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(6).Put("footL", ((V)(0D))).Put("footR", ((V)(3D))).Put("lift", ((V)(4D))).Put("tilt", ((V)((-2D)))).Put("armL", ((V)(0D))).Put("armR", ((V)(30D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(5).Put("footR", ((V)(0D))).Put("lift", ((V)(5.5))).Put("tilt", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(240D)), Call(o_10, V.Undef, B_348, NewObj(2).Put("lift", ((V)((ToNum(L_350) - 0.4)))).Put("sq", Add(Q_351, ((V)(0.1)))).V), ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", Q_351).Put("lift", L_350).V, ((V)("io")));
} else {
if (SEqS(st_349, "slide")) {
Invoke(Invoke(Invoke(Invoke(t_347, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.08))).Put("lean", ((V)(2D))).V), "to", ((V)(420D)), Call(o_10, V.Undef, B_348, NewObj(3).Put("lift", Add(L_350, ((V)(2D)))).Put("lean", ((V)((-1.5)))).Put("sq", ((V)((ToNum(Q_351) - 0.03)))).V), ((V)("o"))), "to", ((V)(300D)), NewObj(3).Put("lift", L_350).Put("lean", ((V)(0D))).Put("sq", Add(Q_351, ((V)(0.05)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(1).Put("sq", Q_351).V, ((V)("io")));
} else {
Invoke(Invoke(Invoke(Invoke(Invoke(t_347, "to", ((V)(160D)), NewObj(5).Put("sq", ((V)(0.12))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(6).Put("lift", ((V)(7D))).Put("sq", ((V)((-0.12)))).Put("footL", ((V)(2.2))).Put("footR", ((V)(2.2))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("o"))), "to", ((V)(200D)), Call(o_10, V.Undef, B_348, NewObj(2).Put("lift", ((V)((ToNum(L_350) - 0.6)))).Put("sq", Add(Q_351, ((V)(0.12)))).V), ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)((ToNum(Q_351) - 0.025)))).Put("lift", Add(L_350, ((V)(0.4)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", Q_351).Put("lift", L_350).V, ((V)("io")));
}
}
}
}
}
}
return t_347;
return default;
}, 3, "enterMove", false);
exitMove_22 = Fn((V _self355, int _argc356, V t_362, V B_363, V st_364, V _a361, V[] _rest357) => {
V z_365 = default;
if (_self355.IsNullish) _self355 = GlobalV;
z_365 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_363), "forEach", Fn((V _arrowThis373, int _argc366, V p_372, V _a369, V _a370, V _a371, V[] _rest367) => {
return SetK(z_365, p_372, (GetK(REST_9, p_372) is var _t374 && Truthy(_t374) ? _t374 : ((V)(0D))));
}, 1, "", true));
if (SEqS(st_364, "float")) {
Invoke(Invoke(t_362, "to", ((V)(260D)), NewObj(2).Put("lift", Add((Get(B_363, "lift") is var _t375 && Truthy(_t375) ? _t375 : ((V)(0D))), ((V)(1D)))).Put("sq", Add((Get(B_363, "sq") is var _t376 && Truthy(_t376) ? _t376 : ((V)(0D))), ((V)(0.04)))).V, ((V)("io"))), "to", ((V)(360D)), Call(o_10, V.Undef, z_365, NewObj(2).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.03)))).V), ((V)("o")));
} else {
if (SEqS(st_364, "flop")) {
Invoke(Invoke(Invoke(t_362, "to", ((V)(180D)), NewObj(2).Put("sq", Add((Get(B_363, "sq") is var _t377 && Truthy(_t377) ? _t377 : ((V)(0D))), ((V)(0.06)))).Put("tilt", ((V)(4D))).V, ((V)("io"))), "to", ((V)(240D)), Call(o_10, V.Undef, z_365, NewObj(3).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.1)))).Put("tilt", ((V)((-3D)))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("tilt", ((V)(0D))).V, ((V)("i")));
} else {
Invoke(Invoke(Invoke(t_362, "to", ((V)(200D)), NewObj(4).Put("sq", Add((Get(B_363, "sq") is var _t378 && Truthy(_t378) ? _t378 : ((V)(0D))), ((V)(0.05)))).Put("pitch", ((V)((-0.12)))).Put("lean", ((V)(0.8))).Put("sit", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(220D)), Call(o_10, V.Undef, z_365, NewObj(6).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.1)))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(6).Put("lift", ((V)(0D))).Put("sq", ((V)(0.09))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("i")));
}
}
return t_362;
return default;
}, 3, "exitMove", false);
standup_23 = Fn((V _self379, int _argc380, V B_386, V P_387, V _a384, V _a385, V[] _rest381) => {
V t_388 = default;
V st_389 = default;
V z_390 = default;
if (_self379.IsNullish) _self379 = GlobalV;
t_388 = Call(TL_11, V.Undef, B_386);
st_389 = (Get(P_387, "up") is var _t391 && Truthy(_t391) ? _t391 : ((V)("hop")));
z_390 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_386), "forEach", Fn((V _arrowThis399, int _argc392, V p_398, V _a395, V _a396, V _a397, V[] _rest393) => {
return SetK(z_390, p_398, (GetK(REST_9, p_398) is var _t400 && Truthy(_t400) ? _t400 : ((V)(0D))));
}, 1, "", true));
if (SEqS(st_389, "float")) {
Invoke(Invoke(t_388, "to", ((V)(260D)), NewObj(2).Put("lift", Add((Get(B_386, "lift") is var _t401 && Truthy(_t401) ? _t401 : ((V)(0D))), ((V)(1D)))).Put("sq", Add((Get(B_386, "sq") is var _t402 && Truthy(_t402) ? _t402 : ((V)(0D))), ((V)(0.04)))).V, ((V)("io"))), "to", ((V)(360D)), Call(o_10, V.Undef, z_390, NewObj(2).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.03)))).V), ((V)("o")));
} else {
if (SEqS(st_389, "flop")) {
Invoke(Invoke(Invoke(t_388, "to", ((V)(180D)), NewObj(2).Put("sq", Add((Get(B_386, "sq") is var _t403 && Truthy(_t403) ? _t403 : ((V)(0D))), ((V)(0.06)))).Put("tilt", ((V)(4D))).V, ((V)("io"))), "to", ((V)(240D)), Call(o_10, V.Undef, z_390, NewObj(3).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.1)))).Put("tilt", ((V)((-3D)))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("tilt", ((V)(0D))).V, ((V)("i")));
} else {
Invoke(Invoke(Invoke(t_388, "to", ((V)(200D)), NewObj(4).Put("sq", Add((Get(B_386, "sq") is var _t404 && Truthy(_t404) ? _t404 : ((V)(0D))), ((V)(0.05)))).Put("pitch", ((V)((-0.12)))).Put("lean", ((V)(0.8))).Put("sit", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(220D)), Call(o_10, V.Undef, z_390, NewObj(6).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.1)))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(6).Put("lift", ((V)(0D))).Put("sq", ((V)(0.09))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("i")));
}
}
if (Truthy(Get(P_387, "upX"))) {
Invoke(P_387, "upX", t_388, B_386);
}
Invoke(t_388, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
return Invoke(t_388, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(160D))).V);
return default;
}, 2, "standup", false);
hold_24 = Fn((V _self405, int _argc406, V B_412, V beats_413, V gaps_414, V extra_415, V[] _rest407) => {
V t_416 = default;
V v_417 = default;
if (_self405.IsNullish) _self405 = GlobalV;
t_416 = Call(TL_11, V.Undef, B_412);
v_417 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_412), "forEach", Fn((V _arrowThis425, int _argc418, V p_424, V _a421, V _a422, V _a423, V[] _rest419) => {
return SetK(v_417, p_424, GetK(B_412, p_424));
}, 1, "", true));
Invoke(t_416, "to", ((V)(10D)), v_417);
Call(seq_19, V.Undef, t_416, beats_413, gaps_414);
Invoke(t_416, "wait", ((V)(1400D)));
return Invoke(t_416, "out", Call(o_10, V.Undef, NewObj(3).Put("breathe", ((V)(1D))).Put("look", (true ? V.True : V.False)).Put("blend", ((V)(520D))).V, (extra_415 is var _t426 && Truthy(_t426) ? _t426 : NewObj(0).V)), (true ? V.True : V.False));
return default;
}, 4, "hold", false);
watchHold_33 = Fn((V _self427, int _argc428, V B_434, V P_435, V key_436, V _a433, V[] _rest429) => {
V X_437 = default;
V two_438 = default;
V t_439 = default;
V v_440 = default;
V sig_441 = default;
V win_442 = default;
V bt_443 = default;
V gaps_444 = default;
V st_445 = default;
if (_self427.IsNullish) _self427 = GlobalV;
X_437 = (GetK(WX_29, key_436) is var _t446 && Truthy(_t446) ? _t446 : NewObj(0).V);
two_438 = (Truthy(GetK(LAP_27, key_436)) ? ((V)("lap")) : GetK(TWO_26, key_436));
t_439 = Call(TL_11, V.Undef, B_434);
v_440 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_434), "forEach", Fn((V _arrowThis454, int _argc447, V p_453, V _a450, V _a451, V _a452, V[] _rest448) => {
return SetK(v_440, p_453, GetK(B_434, p_453));
}, 1, "", true));
Invoke(t_439, "to", ((V)(10D)), v_440);
sig_441 = Invoke((Get(P_435, "f") is var _t463 && Truthy(_t463) ? _t463 : Arr()), "find", Fn((V _arrowThis462, int _argc455, V f_461, V _a458, V _a459, V _a460, V[] _rest456) => {
return (string.Equals(Typeof(f_461), "function") ? V.True : V.False);
}, 1, "", true));
win_442 = Arr();
bt_443 = Arr();
gaps_444 = (Get(P_435, "gap") is var _t464 && Truthy(_t464) ? _t464 : Arr(((V)(1600D)), ((V)(2400D)), ((V)(1900D)), ((V)(2600D)), ((V)(2100D))));
Invoke((Get(X_437, "order") is var _t475 && Truthy(_t475) ? _t475 : Arr(((V)("leanin")), ((V)("laugh")), ((V)("popcorn")), ((V)("gasp")), ((V)("sig")), ((V)("clap")), ((V)("popcorn")), ((V)("aww")), ((V)("cheer")))), "forEach", Fn((V _arrowThis473, int _argc465, V n_471, V i_472, V _a469, V _a470, V[] _rest466) => {
V a_474 = default;
Invoke(t_439, "wait", GetIdx(gaps_444, (ToNum(i_472) % ToNum(Get(gaps_444, "length")))));
if (SEqS(n_471, "sig")) {
if (Truthy(sig_441)) {
Call(sig_441, V.Undef, t_439);
}
return default;
}
a_474 = Get(t_439, "t");
InvokeK(WBEAT_30, n_471, t_439, X_437, two_438);
Invoke(bt_443, "push", Arr(n_471, a_474, Get(t_439, "t")));
if (SEqS(n_471, "popcorn")) {
Invoke(win_442, "push", Arr(a_474, Get(t_439, "t")));
}
return default;
}, 2, "", true));
Invoke(t_439, "wait", ((V)(1400D)));
st_445 = Invoke(t_439, "out", NewObj(3).Put("breathe", ((V)(1D))).Put("look", (false ? V.True : V.False)).Put("blend", ((V)(520D))).V, (true ? V.True : V.False));
Set(st_445, "prop", Call(popProp_32, V.Undef, win_442, Get(st_445, "loop"), two_438));
Set(st_445, "beats", bt_443);
return st_445;
return default;
}, 3, "watchHold", false);
snug_34 = Fn((V _self476, int _argc477, V B_483, V P_484, V s_485, V key_486, V[] _rest478) => {
V X_487 = default;
V K_488 = default;
V J_489 = default;
V la_490 = default;
V @short_491 = default;
double rg_492 = 0;
V SB_493 = default;
V t_494 = default;
V v_495 = default;
V NB_496 = default;
V bt_497 = default;
V st_498 = default;
if (_self476.IsNullish) _self476 = GlobalV;
X_487 = (GetK(WX_29, key_486) is var _t499 && Truthy(_t499) ? _t499 : NewObj(0).V);
K_488 = Call(SIDE_14, V.Undef, s_485);
J_489 = Call(SIDE_14, V.Undef, ((V)((-ToNum(s_485)))));
la_490 = ((Get(P_484, "lpose") is var _t500 && !Truthy(_t500) ? _t500 : Get(Get(P_484, "lpose"), "armL")) is var _t501 && Truthy(_t501) ? _t501 : ((V)(34D)));
@short_491 = (LeN(la_490, 14D) ? V.True : V.False);
rg_492 = (Truthy(GetK(RIGID_28, key_486)) ? 0.45 : 1D);
SB_493 = Call(o_10, V.Undef, B_483, NewObj(8).Put("tilt", Add((Get(B_483, "tilt") is var _t502 && Truthy(_t502) ? _t502 : ((V)(0D))), ((V)(((ToNum(s_485) * 5D) * rg_492))))).Put("lean", ((V)(((ToNum(s_485) * 2.4) * rg_492)))).Put("x", ((V)((ToNum(s_485) * 1.8)))).Put("htilt", ((V)(((ToNum(s_485) * 11D) * ((rg_492 < 1D) ? 0.6 : 1D))))).Put("close", ((V)(0.5))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.35))).Put("blush", ((V)(0.55))).V, (Truthy(@short_491) ? Call(hand_12, V.Undef, s_485, ((V)(3D)), ((V)(2D))) : Call(hand_12, V.Undef, s_485, ((V)(0D)), ((V)((-3D))))), NewObj(1).PutK(Get(K_488, "arm"), ((V)((Truthy(@short_491) ? 12D : Min(ToNum(la_490), 30D))))).V, Call(hand_12, V.Undef, ((V)((-ToNum(s_485)))), ((V)(7D)), ((V)(4D))), NewObj(1).PutK(Get(J_489, "arm"), ((V)(6D))).V, (Get(X_487, "snug") is var _t503 && Truthy(_t503) ? _t503 : NewObj(0).V));
t_494 = Call(TL_11, V.Undef, SB_493);
v_495 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, SB_493), "forEach", Fn((V _arrowThis511, int _argc504, V p_510, V _a507, V _a508, V _a509, V[] _rest505) => {
return SetK(v_495, p_510, GetK(SB_493, p_510));
}, 1, "", true));
Invoke(t_494, "to", ((V)(10D)), v_495);
NB_496 = NewObj(8).Put("nuzzle", Fn((V _self512, int _argc513, V t_519, V _a516, V _a517, V _a518, V[] _rest514) => {
if (_self512.IsNullish) _self512 = GlobalV;
Invoke(Invoke(t_519, "to", ((V)(300D)), NewObj(1).Put("close", ((V)(0.8))).V), "osc", ((V)(1800D)), ((V)(4D)), Call(o_10, V.Undef, NewObj(3).Put("htilt", Add(Get(SB_493, "htilt"), ((V)((ToNum(s_485) * 6D))))).Put("x", ((V)((ToNum(s_485) * 2.6)))).Put("sq", Add(Get(SB_493, "sq"), ((V)(0.015)))).V, Get(X_487, "nz")), Call(o_10, V.Undef, NewObj(3).Put("htilt", ((V)((ToNum(Get(SB_493, "htilt")) - (ToNum(s_485) * 2D))))).Put("x", ((V)((ToNum(s_485) * 1.5)))).Put("sq", Get(SB_493, "sq")).V, (Truthy(Get(X_487, "nz")) ? Object_fromEntries(Invoke(Object_keys(Get(X_487, "nz")), "map", Fn((V _arrowThis527, int _argc520, V k_526, V _a523, V _a524, V _a525, V[] _rest521) => {
return Arr(k_526, ((V)(((-ToNum(GetK(Get(X_487, "nz"), k_526))) * (SEqS(k_526, "wag") ? 1D : 0D)))));
}, 1, "", true))) : NewObj(0).V)), ((V)("s")));
return Invoke(t_519, "back", ((V)(500D)));
return default;
}, 1, "nuzzle", false)).Put("heart", Fn((V _self528, int _argc529, V t_535, V _a532, V _a533, V _a534, V[] _rest530) => {
if (_self528.IsNullish) _self528 = GlobalV;
Invoke(Invoke(Invoke(t_535, "to", ((V)(300D)), NewObj(4).Put("blush", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "wait", ((V)(900D)));
return Invoke(t_535, "back", ((V)(500D)));
return default;
}, 1, "heart", false)).Put("pat", Fn((V _self536, int _argc537, V t_543, V _a540, V _a541, V _a542, V[] _rest538) => {
if (_self536.IsNullish) _self536 = GlobalV;
Invoke(t_543, "osc", ((V)(1500D)), ((V)(3D)), NewObj(2).PutK(Get(K_488, "hy"), ((V)((ToNum(GetK(SB_493, Get(K_488, "hy"))) - 5D)))).PutK(Get(K_488, "arm"), Add(GetK(SB_493, Get(K_488, "arm")), ((V)(6D)))).V, NewObj(2).PutK(Get(K_488, "hy"), GetK(SB_493, Get(K_488, "hy"))).PutK(Get(K_488, "arm"), GetK(SB_493, Get(K_488, "arm"))).V, ((V)("o")));
return Invoke(t_543, "back", ((V)(400D)));
return default;
}, 1, "pat", false)).Put("squeeze", Fn((V _self544, int _argc545, V t_551, V _a548, V _a549, V _a550, V[] _rest546) => {
if (_self544.IsNullish) _self544 = GlobalV;
Invoke(Invoke(t_551, "to", ((V)(320D)), NewObj(5).Put("sq", Add(Get(SB_493, "sq"), ((V)(0.06)))).Put("x", ((V)((ToNum(s_485) * 3.2)))).Put("close", ((V)(1D))).Put("hap", ((V)(1D))).PutK(Get(K_488, "arm"), Add(GetK(SB_493, Get(K_488, "arm")), ((V)(10D)))).V, ((V)("o"))), "wait", ((V)(700D)));
return Invoke(t_551, "back", ((V)(520D)));
return default;
}, 1, "squeeze", false)).Put("giggle", Fn((V _self552, int _argc553, V t_559, V _a556, V _a557, V _a558, V[] _rest554) => {
if (_self552.IsNullish) _self552 = GlobalV;
Invoke(BEAT_16, "giggle", t_559, ((V)((-ToNum(s_485)))));
return t_559;
return default;
}, 1, "giggle", false)).Put("sigh", Fn((V _self560, int _argc561, V t_567, V _a564, V _a565, V _a566, V[] _rest562) => {
if (_self560.IsNullish) _self560 = GlobalV;
Invoke(BEAT_16, "sigh", t_567);
return t_567;
return default;
}, 1, "sigh", false)).Put("doze", Fn((V _self568, int _argc569, V t_575, V _a572, V _a573, V _a574, V[] _rest570) => {
if (_self568.IsNullish) _self568 = GlobalV;
Invoke(BEAT_16, "doze", t_575);
return t_575;
return default;
}, 1, "doze", false)).Put("ears", Fn((V _self576, int _argc577, V t_583, V _a580, V _a581, V _a582, V[] _rest578) => {
if (_self576.IsNullish) _self576 = GlobalV;
Invoke(BEAT_16, "ears", t_583);
return t_583;
return default;
}, 1, "ears", false)).V;
bt_497 = Arr();
Invoke((Get(X_487, "snugOrder") is var _t596 && Truthy(_t596) ? _t596 : Arr(((V)("nuzzle")), ((V)("sigh")), ((V)("heart")), ((V)("pat")), ((V)("doze")), ((V)("ears")), ((V)("squeeze")), ((V)("giggle")))), "forEach", Fn((V _arrowThis592, int _argc584, V n_590, V i_591, V _a588, V _a589, V[] _rest585) => {
V g_593 = default;
V a_594 = default;
g_593 = (Get(P_484, "lgap") is var _t595 && Truthy(_t595) ? _t595 : Arr(((V)(1800D)), ((V)(2600D)), ((V)(2200D)), ((V)(3000D))));
Invoke(t_494, "wait", GetIdx(g_593, (ToNum(i_591) % ToNum(Get(g_593, "length")))));
a_594 = Get(t_494, "t");
InvokeK(NB_496, n_590, t_494);
Invoke(bt_497, "push", Arr(n_590, a_594, Get(t_494, "t")));
return default;
}, 2, "", true));
Invoke(t_494, "wait", ((V)(1400D)));
st_498 = Invoke(t_494, "out", NewObj(3).Put("breathe", ((V)(1D))).Put("look", (false ? V.True : V.False)).Put("blend", ((V)(620D))).V, (true ? V.True : V.False));
Set(st_498, "beats", bt_497);
return st_498;
return default;
}, 4, "snug", false);
build_36 = Fn((V _self597, int _argc598, V key_604, V P_605, V _a602, V _a603, V[] _rest599) => {
V B_606 = default;
V LB_607 = default;
V fid_608 = default;
V lf_609 = default;
V S_610 = default;
V dl_611 = default;
V WB_612 = default;
V nm_613 = default;
V dw_614 = default;
if (_self597.IsNullish) _self597 = GlobalV;
P_605 = (P_605 is var _t615 && Truthy(_t615) ? _t615 : NewObj(0).V);
B_606 = Call(o_10, V.Undef, SIT0_17, (Get(P_605, "pose") is var _t616 && Truthy(_t616) ? _t616 : NewObj(0).V));
LB_607 = Call(o_10, V.Undef, B_606, LNG0_18, (Get(P_605, "lpose") is var _t617 && Truthy(_t617) ? _t617 : NewObj(0).V));
fid_608 = (Get(P_605, "f") is var _t618 && Truthy(_t618) ? _t618 : Arr(((V)("look")), ((V)("swing")), ((V)("pat")), ((V)("yawn"))));
lf_609 = (Get(P_605, "lf") is var _t619 && Truthy(_t619) ? _t619 : Arr(((V)("sigh")), ((V)("stretch")), ((V)("doze")), ((V)("belly"))));
S_610 = NewObj(0).V;
SetK(S_610, ((V)((Truthy(key_604) ? JsStrBuf.Begin().S("sitdown@").V(key_604).End() : "sitdown"))), Call(sitdown_20, V.Undef, B_606, P_605));
SetK(S_610, ((V)((Truthy(key_604) ? JsStrBuf.Begin().S("sit@").V(key_604).End() : "sit"))), Call(hold_24, V.Undef, B_606, fid_608, (Get(P_605, "gap") is var _t620 && Truthy(_t620) ? _t620 : Arr(((V)(1600D)), ((V)(2400D)), ((V)(1900D)), ((V)(2600D)), ((V)(2100D))))));
SetK(S_610, ((V)((Truthy(key_604) ? JsStrBuf.Begin().S("standup@").V(key_604).End() : "standup"))), Call(standup_23, V.Undef, B_606, P_605));
SetK(S_610, ((V)((Truthy(key_604) ? JsStrBuf.Begin().S("lounge@").V(key_604).End() : "lounge"))), Call(hold_24, V.Undef, LB_607, lf_609, (Get(P_605, "lgap") is var _t621 && Truthy(_t621) ? _t621 : Arr(((V)(1800D)), ((V)(2600D)), ((V)(2200D)), ((V)(3000D))))));
dl_611 = Call(sitdown_20, V.Undef, LB_607, Call(o_10, V.Undef, P_605, NewObj(1).Put("dnX", (Get(P_605, "ldnX") is var _t622 && Truthy(_t622) ? _t622 : Get(P_605, "dnX"))).V));
Set(dl_611, "next", ((V)("lounge")));
SetK(S_610, ((V)((Truthy(key_604) ? JsStrBuf.Begin().S("sitdown_lounge@").V(key_604).End() : "sitdown_lounge"))), dl_611);
WB_612 = Call(o_10, V.Undef, B_606, NewObj(1).Put("pitch", ((V)((ToNum((Get(B_606, "pitch") is var _t623 && Truthy(_t623) ? _t623 : ((V)(0D)))) - 0.03)))).V, (Get(P_605, "wpose") is var _t624 && Truthy(_t624) ? _t624 : NewObj(0).V));
nm_613 = Fn((V _arrowThis632, int _argc625, V n_631, V _a628, V _a629, V _a630, V[] _rest626) => {
return (Truthy(key_604) ? ((V)(JsStrBuf.Begin().V(n_631).S("@").V(key_604).End())) : n_631);
}, 1, "", true);
SetK(S_610, Call(nm_613, V.Undef, ((V)("watch"))), Call(watchHold_33, V.Undef, WB_612, P_605, key_604));
dw_614 = Call(sitdown_20, V.Undef, WB_612, P_605);
Set(dw_614, "next", ((V)("watch")));
SetK(S_610, Call(nm_613, V.Undef, ((V)("sitdown_watch"))), dw_614);
SetK(S_610, Call(nm_613, V.Undef, ((V)("snuggleL"))), Call(snug_34, V.Undef, B_606, P_605, ((V)((-1D))), key_604));
SetK(S_610, Call(nm_613, V.Undef, ((V)("snuggleR"))), Call(snug_34, V.Undef, B_606, P_605, ((V)(1D)), key_604));
Invoke(R_8, "add", S_610);
Set(R_8, "HS", Object_assign((Get(R_8, "HS") is var _t633 && Truthy(_t633) ? _t633 : NewObj(0).V), S_610));
if (Truthy(key_604)) {
SetK(PROF_35, key_604, P_605);
}
return default;
}, 2, "build", false);
quilt_46 = Fn((V _self634, int _argc635, V I_641, V P_642, V W_643, V qk_644, V[] _rest636) => {
V ok_645 = default;
V hx_646 = default;
double a_647 = 0;
V ux_648 = default;
V uy_649 = default;
V L_650 = default;
V Rr_651 = default;
V sp_652 = default;
double hw_653 = 0;
double mx_654 = 0;
double my_655 = 0;
V M_656 = default;
double mz_657 = 0;
V tg_658 = default;
double y1_659 = 0;
double y0_660 = 0;
V col_661 = default;
V dk_662 = default;
V lt_663 = default;
double hh_664 = 0;
double w2_665 = 0;
V top_666 = default;
V body_667 = default;
JsStrBuf h_668 = null;
if (_self634.IsNullish) _self634 = GlobalV;
ok_645 = Fn((V _arrowThis676, int _argc669, V p_675, V _a672, V _a673, V _a674, V[] _rest670) => {
return ((p_675 is var _t677 && !Truthy(_t677) ? _t677 : (IsFiniteV(GetIdx(p_675, 0D)) ? V.True : V.False)) is var _t678 && !Truthy(_t678) ? _t678 : (IsFiniteV(GetIdx(p_675, 1D)) ? V.True : V.False));
}, 1, "", true);
hx_646 = (Get(I_641, "hq") is var _t679 && Truthy(_t679) ? _t679 : NewObj(0).V);
a_647 = ((ToNum((Get(P_642, "tilt") is var _t680 && Truthy(_t680) ? _t680 : ((V)(0D)))) * System.Math.PI) / 180D);
ux_648 = Arr(((V)(FdLibm.Cos(a_647))), ((V)(FdLibm.Sin(a_647))));
uy_649 = Arr(((V)((-FdLibm.Sin(a_647)))), ((V)(FdLibm.Cos(a_647))));
L_650 = Get(W_643, "sideL");
Rr_651 = Get(W_643, "sideR");
if ((!(Truthy(Call(ok_645, V.Undef, L_650))) || !(Truthy(Call(ok_645, V.Undef, Rr_651))))) {
V fl_681 = default;
V fr_682 = default;
V c_683 = default;
double hs_684 = 0;
fl_681 = Get(W_643, "footL");
fr_682 = Get(W_643, "footR");
c_683 = (Truthy((Call(ok_645, V.Undef, fl_681) is var _t685 && !Truthy(_t685) ? _t685 : Call(ok_645, V.Undef, fr_682))) ? Arr(((V)(((ToNum(Add(GetIdx(fl_681, 0D), GetIdx(fr_682, 0D))) / 2D) - (ToNum(GetIdx(uy_649, 0D)) * 11D)))), ((V)(((ToNum(Add(GetIdx(fl_681, 1D), GetIdx(fr_682, 1D))) / 2D) - (ToNum(GetIdx(uy_649, 1D)) * 11D))))) : (Truthy(Call(ok_645, V.Undef, Get(W_643, "belly"))) ? Get(W_643, "belly") : (Truthy(Call(ok_645, V.Undef, Get(W_643, "body"))) ? Get(W_643, "body") : V.Null)));
if (!(Truthy(c_683))) {
return ((V)(""));
}
hs_684 = (Truthy((Call(ok_645, V.Undef, fl_681) is var _t686 && !Truthy(_t686) ? _t686 : Call(ok_645, V.Undef, fr_682))) ? Max(((Hypot((ToNum(GetIdx(fr_682, 0D)) - ToNum(GetIdx(fl_681, 0D))), (ToNum(GetIdx(fr_682, 1D)) - ToNum(GetIdx(fl_681, 1D)))) * 1.15) + 9D), 18D) : 20D);
L_650 = Arr(((V)((ToNum(GetIdx(c_683, 0D)) - (ToNum(GetIdx(ux_648, 0D)) * hs_684)))), ((V)((ToNum(GetIdx(c_683, 1D)) - (ToNum(GetIdx(ux_648, 1D)) * hs_684)))));
Rr_651 = Arr(Add(GetIdx(c_683, 0D), ((V)((ToNum(GetIdx(ux_648, 0D)) * hs_684)))), Add(GetIdx(c_683, 1D), ((V)((ToNum(GetIdx(ux_648, 1D)) * hs_684)))));
}
sp_652 = (((V)(Hypot((ToNum(GetIdx(Rr_651, 0D)) - ToNum(GetIdx(L_650, 0D))), (ToNum(GetIdx(Rr_651, 1D)) - ToNum(GetIdx(L_650, 1D)))))) is var _t687 && Truthy(_t687) ? _t687 : ((V)(30D)));
Set(I_641, "_qs", ((V)(Max(ToNum((Get(I_641, "_qs") is var _t688 && Truthy(_t688) ? _t688 : ((V)(0D)))), ToNum(sp_652)))));
hw_653 = Min(((ToNum(Get(I_641, "_qs")) * 0.56) + 4D), 40D);
mx_654 = (ToNum(Add(GetIdx(L_650, 0D), GetIdx(Rr_651, 0D))) / 2D);
my_655 = (ToNum(Add(GetIdx(L_650, 1D), GetIdx(Rr_651, 1D))) / 2D);
M_656 = Get(W_643, "mouth");
mz_657 = (Truthy(Call(ok_645, V.Undef, M_656)) ? (((ToNum(GetIdx(M_656, 0D)) - mx_654) * ToNum(GetIdx(uy_649, 0D))) + ((ToNum(GetIdx(M_656, 1D)) - my_655) * ToNum(GetIdx(uy_649, 1D)))) : (-16D));
tg_658 = Add(Call(cl_39, V.Undef, ((V)((mz_657 + 6.5))), ((V)((-24D))), ((V)(2D))), (Get(I_641, "_qy") is var _t689 && Truthy(_t689) ? _t689 : ((V)(0D))));
Set(I_641, "_qt", (Get(I_641, "_qt").IsNullish ? tg_658 : Add(Get(I_641, "_qt"), ((V)(((ToNum(tg_658) - ToNum(Get(I_641, "_qt"))) * 0.12))))));
y1_659 = 17D;
y0_660 = (y1_659 - ((y1_659 - ToNum(Get(I_641, "_qt"))) * ToNum(Call(cl_39, V.Undef, qk_644, ((V)(0D)), ((V)(1D))))));
if (((y1_659 - y0_660) < 1.2)) {
return ((V)(""));
}
col_661 = (Get(hx_646, "quilt") is var _t690 && Truthy(_t690) ? _t690 : ((V)("#7f9fd0")));
dk_662 = Call(shade_42, V.Undef, col_661, ((V)(0.7)));
lt_663 = Call(shade_42, V.Undef, col_661, ((V)(1.35)));
hh_664 = (y1_659 - y0_660);
w2_665 = (hw_653 / 2D);
top_666 = ((V)(JsStrBuf.Begin().S("M").V(Call(r2_38, V.Undef, ((V)((-hw_653))))).S(" ").V(Call(r2_38, V.Undef, ((V)(y0_660)))).S("Q").V(Call(r2_38, V.Undef, ((V)((-w2_665))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 - 1.6))))).S(" 0 ").V(Call(r2_38, V.Undef, ((V)((y0_660 - 0.4))))).S("Q").V(Call(r2_38, V.Undef, ((V)(w2_665)))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 - 1.6))))).S(" ").V(Call(r2_38, V.Undef, ((V)(hw_653)))).S(" ").V(Call(r2_38, V.Undef, ((V)(y0_660)))).End()));
body_667 = ((V)(JsStrBuf.Begin().V(top_666).S("L").V(Call(r2_38, V.Undef, ((V)((hw_653 + 1.5))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_659 - 3D))))).S("Q").V(Call(r2_38, V.Undef, ((V)((hw_653 + 1.5))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_659 + 1D))))).S(" ").V(Call(r2_38, V.Undef, ((V)((hw_653 - 3D))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_659 + 1D))))).S("L").V(Call(r2_38, V.Undef, ((V)(((-hw_653) + 3D))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_659 + 1D))))).S("Q").V(Call(r2_38, V.Undef, ((V)(((-hw_653) - 1.5))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_659 + 1D))))).S(" ").V(Call(r2_38, V.Undef, ((V)(((-hw_653) - 1.5))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_659 - 3D))))).S("Z").End()));
h_668 = new JsStrBuf(JsStrBuf.Begin().S("<g transform=\"matrix(").V(Call(r2_38, V.Undef, GetIdx(ux_648, 0D))).S(" ").V(Call(r2_38, V.Undef, GetIdx(ux_648, 1D))).S(" ").V(Call(r2_38, V.Undef, GetIdx(uy_649, 0D))).S(" ").V(Call(r2_38, V.Undef, GetIdx(uy_649, 1D))).S(" ").V(Call(r2_38, V.Undef, ((V)(mx_654)))).S(" ").V(Call(r2_38, V.Undef, ((V)(my_655)))).S(")\">").V(Call(pa_44, V.Undef, body_667, col_661, dk_662, ((V)(0.7)))).End());
h_668.S("<ellipse cx=\"").V(Call(r2_38, V.Undef, ((V)(((-hw_653) * 0.38))))).S("\" cy=\"").V(Call(r2_38, V.Undef, ((V)((y0_660 + (hh_664 * 0.34)))))).S("\" rx=\"").V(Call(r2_38, V.Undef, ((V)((hw_653 * 0.42))))).S("\" ry=\"").V(Call(r2_38, V.Undef, ((V)((hh_664 * 0.22))))).S("\" fill=\"").V(lt_663).S("\" opacity=\"0.45\"/>");
h_668.V(Invoke(Call(pa_44, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(r2_38, V.Undef, ((V)(((-hw_653) - 1.5))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_659 - 3D))))).S("Q0 ").V(Call(r2_38, V.Undef, ((V)((y1_659 - 5.5))))).S(" ").V(Call(r2_38, V.Undef, ((V)((hw_653 + 1.5))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_659 - 3D))))).S("Q").V(Call(r2_38, V.Undef, ((V)((hw_653 + 1.5))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_659 + 1D))))).S(" ").V(Call(r2_38, V.Undef, ((V)((hw_653 - 3D))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_659 + 1D))))).S("L").V(Call(r2_38, V.Undef, ((V)(((-hw_653) + 3D))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_659 + 1D))))).S("Q").V(Call(r2_38, V.Undef, ((V)(((-hw_653) - 1.5))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_659 + 1D))))).S(" ").V(Call(r2_38, V.Undef, ((V)(((-hw_653) - 1.5))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_659 - 3D))))).S("Z").End())), dk_662), "replace", ((V)("/>")), ((V)(" opacity=\"0.35\"/>"))));
if ((hh_664 > 7D)) {
V ym_691 = default;
ym_691 = Call(r2_38, V.Undef, ((V)((y0_660 + (hh_664 * 0.55)))));
h_668.S("<path d=\"M").V(Call(r2_38, V.Undef, ((V)(((-hw_653) / 3D))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 + 3.4))))).S("V").V(Call(r2_38, V.Undef, ((V)((y1_659 - 0.6))))).S("M").V(Call(r2_38, V.Undef, ((V)((hw_653 / 3D))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 + 3.4))))).S("V").V(Call(r2_38, V.Undef, ((V)((y1_659 - 0.6))))).S("M").V(Call(r2_38, V.Undef, ((V)(((-hw_653) + 1D))))).S(" ").V(ym_691).S("H").V(Call(r2_38, V.Undef, ((V)((hw_653 - 1D))))).S("\" stroke=\"").V(dk_662).S("\" stroke-width=\"0.45\" stroke-dasharray=\"1.2 1\" opacity=\"0.7\" fill=\"none\"/>");
}
h_668.V(Call(pa_44, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(r2_38, V.Undef, ((V)(((-hw_653) - 0.8))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 - 0.2))))).S("Q").V(Call(r2_38, V.Undef, ((V)((-w2_665))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 - 1.8))))).S(" 0 ").V(Call(r2_38, V.Undef, ((V)((y0_660 - 0.6))))).S("Q").V(Call(r2_38, V.Undef, ((V)(w2_665)))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 - 1.8))))).S(" ").V(Call(r2_38, V.Undef, ((V)((hw_653 + 0.8))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 - 0.2))))).S("L").V(Call(r2_38, V.Undef, ((V)((hw_653 + 0.6))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 + 2.6))))).S("Q").V(Call(r2_38, V.Undef, ((V)(w2_665)))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 + 1.4))))).S(" 0 ").V(Call(r2_38, V.Undef, ((V)((y0_660 + 2.2))))).S("Q").V(Call(r2_38, V.Undef, ((V)((-w2_665))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 + 1.4))))).S(" ").V(Call(r2_38, V.Undef, ((V)(((-hw_653) - 0.6))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 + 2.6))))).S("Z").End())), ((V)("#fffaf1")), ((V)("#d6cbb8")), ((V)(0.45))));
h_668.V(Call(pa_44, V.Undef, ((V)(JsStrBuf.Begin().S("M").V(Call(r2_38, V.Undef, ((V)(((-hw_653) * 0.7))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 + 0.4))))).S("Q").V(Call(r2_38, V.Undef, ((V)((-w2_665))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 - 0.6))))).S(" ").V(Call(r2_38, V.Undef, ((V)(((-hw_653) * 0.2))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_660 - 0.1))))).End())), V.Null, ((V)("#ffffff")), ((V)(0.6))));
return ((V)(string.Concat(h_668.Str, "</g>")));
return default;
}, 4, "quilt", false);
sleepFx_47 = Fn((V _self692, int _argc693, V icon_699, V zc_700, V qy_701, V _a698, V[] _rest694) => {
V IC_702 = default;
if (_self692.IsNullish) _self692 = GlobalV;
IC_702 = (GetK(ICON_45, icon_699) is var _t703 && Truthy(_t703) ? _t703 : Get(ICON_45, "star"));
return Fn((V _arrowThis712, int _argc704, V I_710, V tt_711, V _a708, V _a709, V[] _rest705) => {
V P_713 = default;
V W_714 = default;
JsStrBuf h_715 = null;
V qk_716 = default;
V H_717 = default;
V zz_718 = default;
V dm_719 = default;
P_713 = (Get(I_710, "lastP") is var _t720 && Truthy(_t720) ? _t720 : NewObj(0).V);
W_714 = (Get(I_710, "W") is var _t721 && Truthy(_t721) ? _t721 : NewObj(0).V);
h_715 = new JsStrBuf("");
Set(I_710, "_qy", (qy_701 is var _t722 && Truthy(_t722) ? _t722 : ((V)(0D))));
qk_716 = (Get(P_713, "qk") is var _t723 && Truthy(_t723) ? _t723 : ((V)(0D)));
if (GtN(qk_716, 0.02)) {
h_715.V(Call(quilt_46, V.Undef, I_710, P_713, W_714, qk_716));
}
H_717 = (Get(W_714, "head") is var _t724 && Truthy(_t724) ? _t724 : Get(I_710, "topW"));
if (((!(Truthy(H_717)) || !(IsFiniteV(GetIdx(H_717, 0D)))) || !(IsFiniteV(GetIdx(H_717, 1D))))) {
return ((V)(h_715.Str));
}
zz_718 = (Get(P_713, "zz") is var _t725 && Truthy(_t725) ? _t725 : ((V)(0D)));
if (GtN(zz_718, 0.03)) {
{
double i_726 = 0;
i_726 = 0D;
while (true) {
if (!((i_726 < 3D))) break;
double u_728 = 0;
V big_729 = default;
V x_730 = default;
double y_731 = 0;
u_728 = (((ToNum(tt_711) / 2600D) + (i_726 / 3D)) % 1D);
big_729 = Call(cl_39, V.Undef, ((V)((ToNum(zz_718) - 1D))), ((V)(0D)), ((V)(1D)));
x_730 = Add(Add(Add(GetIdx(H_717, 0D), ((V)(11D))), ((V)((u_728 * 13D)))), ((V)((FdLibm.Sin((u_728 * TAU_37)) * 2D))));
y_731 = ((ToNum(Add(GetIdx(H_717, 1D), ((V)(3D)))) - (u_728 * 21D)) - (ToNum(big_729) * 2D));
h_715.S("<text x=\"").V(Call(r2_38, V.Undef, x_730)).S("\" y=\"").V(Call(r2_38, V.Undef, ((V)(y_731)))).S("\" font-family=\"Fredoka,sans-serif\" font-weight=\"700\" font-size=\"").V(Call(r2_38, V.Undef, ((V)(((4.5 + (u_728 * 4.8)) * (1D + (ToNum(big_729) * 0.55))))))).S("\" fill=\"").V((zc_700 is var _t732 && Truthy(_t732) ? _t732 : ((V)("#8f3cf2")))).S("\" stroke=\"#ffffff\" stroke-width=\"0.6\" paint-order=\"stroke\" opacity=\"").V(Call(r2_38, V.Undef, ((V)((FdLibm.Sin((System.Math.PI * u_728)) * ToNum(Call(cl_39, V.Undef, zz_718, ((V)(0D)), ((V)(1D))))))))).S("\">").S((GtN(big_729, 0.4) ? "Z" : "z")).S("</text>");
i_726++;
}
}
}
dm_719 = Call(cl_39, V.Undef, (Get(P_713, "drm") is var _t733 && Truthy(_t733) ? _t733 : ((V)(0D))), ((V)(0D)), ((V)(1D)));
if (GtN(dm_719, 0.02)) {
double s_734 = 0;
double bx_735 = 0;
double by_736 = 0;
s_734 = (0.55 + (0.45 * ToNum(dm_719)));
bx_735 = (ToNum(GetIdx(H_717, 0D)) - 15D);
by_736 = ((ToNum(GetIdx(H_717, 1D)) - 13D) + (FdLibm.Sin((ToNum(tt_711) / 700D)) * 1.2));
h_715.S("<g opacity=\"").V(Call(r2_38, V.Undef, dm_719)).S("\">").V(Call(ci_43, V.Undef, Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(H_717, 0D)) - 5D)))), Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(H_717, 1D)) - 2D)))), ((V)(1.1)), ((V)("#ffffff")), ((V)("#b9a6e0")))).V(Call(ci_43, V.Undef, Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(H_717, 0D)) - 9D)))), Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(H_717, 1D)) - 6.5)))), ((V)(1.7)), ((V)("#ffffff")), ((V)("#b9a6e0")))).S("<g transform=\"translate(").V(Call(r2_38, V.Undef, ((V)(bx_735)))).S(" ").V(Call(r2_38, V.Undef, ((V)(by_736)))).S(") scale(").V(Call(r2_38, V.Undef, ((V)(s_734)))).S(")\"><circle r=\"8\" fill=\"#ffffff\" stroke=\"#b9a6e0\" stroke-width=\"0.7\"/><circle cx=\"-3\" cy=\"-4\" r=\"2.2\" fill=\"#f2ecff\"/><g transform=\"scale(1.05) rotate(").V(Call(r2_38, V.Undef, ((V)((FdLibm.Sin((ToNum(tt_711) / 520D)) * 8D))))).S(")\">").V(IC_702).S("</g></g></g>");
}
return ((V)(h_715.Str));
return default;
}, 2, "", true);
return default;
}, 3, "sleepFx", false);
sleepHold_50 = Fn((V _self737, int _argc738, V LB_744, V X_745, V kind_746, V fx_747, V[] _rest739) => {
V t_748 = default;
V v_749 = default;
V bt_750 = default;
V g_751 = default;
V st_752 = default;
if (_self737.IsNullish) _self737 = GlobalV;
t_748 = Call(TL_11, V.Undef, LB_744);
v_749 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, LB_744), "forEach", Fn((V _arrowThis760, int _argc753, V p_759, V _a756, V _a757, V _a758, V[] _rest754) => {
return SetK(v_749, p_759, GetK(LB_744, p_759));
}, 1, "", true));
Invoke(t_748, "to", ((V)(10D)), v_749);
bt_750 = Arr();
g_751 = (Get(X_745, "gap") is var _t761 && Truthy(_t761) ? _t761 : Arr(((V)(2200D)), ((V)(3000D)), ((V)(2600D)), ((V)(3400D))));
Invoke((GetK(X_745, ((V)(JsStrBuf.Begin().V(kind_746).S("Ord").End()))) is var _t778 && Truthy(_t778) ? _t778 : GetK(SORD_49, kind_746)), "forEach", Fn((V _arrowThis770, int _argc762, V b_768, V i_769, V _a766, V _a767, V[] _rest763) => {
V n_771 = default;
V a_772 = default;
V a0_773 = default;
Invoke(t_748, "wait", GetIdx(g_751, (ToNum(i_769) % ToNum(Get(g_751, "length")))));
{ V _t774 = ((b_768.O is JsArray) ? b_768 : Arr(b_768));
{ V _t775 = ListOf(_t774);
{ V _t776 = GetIdx(_t775, 0D);
n_771 = _t776; }
{ V _t777 = GetIdx(_t775, 1D);
a_772 = _t777; }
} }
a0_773 = Get(t_748, "t");
if (SEqS(n_771, "sig")) {
if (!(Truthy(Get(X_745, "s")))) {
return default;
}
Invoke(X_745, "s", t_748);
} else {
InvokeK(ZB_48, n_771, t_748, a_772, X_745);
}
Invoke(bt_750, "push", Arr(n_771, a0_773, Get(t_748, "t")));
return default;
}, 2, "", true));
Invoke(t_748, "wait", ((V)(1600D)));
st_752 = Invoke(t_748, "out", NewObj(5).Put("breathe", ((V)(0.6))).Put("look", (false ? V.True : V.False)).Put("blend", ((V)(650D))).Put("noBlink", (true ? V.True : V.False)).Put("fx", fx_747).V, (true ? V.True : V.False));
Set(st_752, "beats", bt_750);
return st_752;
return default;
}, 4, "sleepHold", false);
bedIn_51 = Fn((V _self779, int _argc780, V B_786, V LB_787, V P_788, V X_789, V[] _rest781) => {
V t_792 = default;
V dn_793 = default;
V v_794 = default;
V v2_795 = default;
V kind_790 = default;
V fx_791 = default;
if (_self779.IsNullish) _self779 = GlobalV;
kind_790 = (_argc780 > 4 ? _rest781[0] : V.Undef);
fx_791 = (_argc780 > 5 ? _rest781[1] : V.Undef);
t_792 = Call(TL_11, V.Undef, REST_9);
dn_793 = (Get(X_789, "dn") is var _t797 && Truthy(_t797) ? _t797 : (SEqS(kind_790, "bean") ? ((V)((SEqS(Get(P_788, "dn"), "float") ? "float" : "flop"))) : (Get(P_788, "dn") is var _t796 && Truthy(_t796) ? _t796 : ((V)("hop")))));
Call(enterMove_21, V.Undef, t_792, B_786, dn_793);
if (Truthy(Get(P_788, "dnX"))) {
Invoke(P_788, "dnX", t_792, B_786);
}
v_794 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_786), "forEach", Fn((V _arrowThis805, int _argc798, V p_804, V _a801, V _a802, V _a803, V[] _rest799) => {
return SetK(v_794, p_804, GetK(B_786, p_804));
}, 1, "", true));
Invoke(t_792, "to", ((V)(140D)), v_794, ((V)("io")));
if (SEqS(kind_790, "bean")) {
Invoke(Invoke(t_792, "to", ((V)(240D)), NewObj(2).Put("sq", Add(Get(B_786, "sq"), ((V)(0.2)))).Put("lift", ((V)((ToNum(Get(B_786, "lift")) - 2.4)))).V, ((V)("i"))), "to", ((V)(320D)), NewObj(2).Put("sq", Add(Get(B_786, "sq"), ((V)(0.07)))).Put("lift", ((V)((ToNum(Get(B_786, "lift")) - 1.2)))).V, ((V)("o")));
Invoke(Invoke(t_792, "to", ((V)(700D)), NewObj(4).Put("spin", ((V)(180D))).Put("footL", Add((Get(B_786, "footL") is var _t808 && Truthy(_t808) ? _t808 : ((V)(0D))), ((V)(1.6)))).Put("footR", (Get(B_786, "footR") is var _t809 && Truthy(_t809) ? _t809 : ((V)(0D)))).Put("x", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(4).Put("spin", ((V)(360D))).Put("footL", (Get(B_786, "footL") is var _t806 && Truthy(_t806) ? _t806 : ((V)(0D)))).Put("footR", Add((Get(B_786, "footR") is var _t807 && Truthy(_t807) ? _t807 : ((V)(0D))), ((V)(1.6)))).Put("x", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_792, "to", ((V)(1000D)), Call(o_10, V.Undef, LB_787, NewObj(4).Put("spin", ((V)(360D))).Put("close", ((V)(0.6))).Put("zz", ((V)(0D))).Put("smile", ((V)(0.6))).V), ((V)("s"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V), "to", ((V)(900D)), NewObj(3).Put("close", ((V)(1D))).Put("zz", ((V)(1D))).Put("smile", Get(LB_787, "smile")).V, ((V)("s")));
} else {
Invoke(Invoke(Invoke(t_792, "to", ((V)(300D)), NewObj(3).Put("lx", ((V)((-0.5)))).Put("ly", ((V)(0.6))).Put("turn", ((V)((-0.2)))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(3).Put("hLy", Add((Get(B_786, "hLy") is var _t812 && Truthy(_t812) ? _t812 : ((V)(0D))), ((V)(6D)))).Put("armL", ((V)(16D))).Put("sq", Add(Get(B_786, "sq"), ((V)(0.015)))).V, NewObj(3).Put("hLy", Add((Get(B_786, "hLy") is var _t813 && Truthy(_t813) ? _t813 : ((V)(0D))), ((V)(2D)))).Put("armL", ((V)(10D))).Put("sq", Get(B_786, "sq")).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("turn", ((V)(0D))).Put("hLy", (Get(B_786, "hLy") is var _t810 && Truthy(_t810) ? _t810 : ((V)(0D)))).Put("armL", (Get(B_786, "armL") is var _t811 && Truthy(_t811) ? _t811 : ((V)(0D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_792, "to", ((V)(900D)), Call(o_10, V.Undef, LB_787, NewObj(5).Put("qk", ((V)(0D))).Put("zz", ((V)(0D))).Put("drm", ((V)(0D))).Put("close", ((V)(0.3))).Put("smile", ((V)(0.5))).V), ((V)("s"))), "to", ((V)(260D)), NewObj(1).Put("sq", Add(Get(LB_787, "sq"), ((V)(0.06)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(1).Put("sq", Get(LB_787, "sq")).V, ((V)("io")));
if (SEqS(kind_790, "bed")) {
Invoke(Invoke(Invoke(Invoke(t_792, "to", ((V)(320D)), NewObj(5).Put("hLy", ((V)(9D))).Put("hRy", ((V)(9D))).Put("armL", ((V)((-2D)))).Put("armR", ((V)((-2D)))).Put("ly", ((V)(0.7))).V, ((V)("io"))), "to", ((V)(900D)), NewObj(6).Put("hLy", Get(LB_787, "hLy")).Put("hRy", Get(LB_787, "hRy")).Put("armL", Get(LB_787, "armL")).Put("armR", Get(LB_787, "armR")).Put("qk", ((V)(1D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("sq", Add(Get(LB_787, "sq"), ((V)(0.05)))).Put("smile", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(1).Put("sq", Get(LB_787, "sq")).V, ((V)("io")));
} else {
Invoke(t_792, "osc", ((V)(900D)), ((V)(2D)), NewObj(2).Put("x", ((V)(0.8))).Put("tilt", Add(Get(LB_787, "tilt"), ((V)(2D)))).V, NewObj(2).Put("x", ((V)((-0.8)))).Put("tilt", ((V)((ToNum(Get(LB_787, "tilt")) - 2D)))).V, ((V)("s")));
}
Invoke(Invoke(Invoke(t_792, "to", ((V)(700D)), NewObj(1).Put("close", ((V)(0.75))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(1).Put("close", ((V)(0.45))).V), "to", ((V)(1000D)), NewObj(3).Put("close", ((V)(1D))).Put("zz", ((V)(1D))).Put("smile", Get(LB_787, "smile")).V, ((V)("s")));
}
v2_795 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, LB_787), "forEach", Fn((V _arrowThis821, int _argc814, V p_820, V _a817, V _a818, V _a819, V[] _rest815) => {
return SetK(v2_795, p_820, GetK(LB_787, p_820));
}, 1, "", true));
Invoke(t_792, "to", ((V)(220D)), v2_795, ((V)("io")));
return Invoke(t_792, "out", NewObj(3).Put("next", kind_790).Put("blend", ((V)(220D))).Put("fx", fx_791).V);
return default;
}, 6, "bedIn", false);
wakeUp_52 = Fn((V _self822, int _argc823, V LB_829, V SB_830, V P_831, V X_832, V[] _rest824) => {
V t_835 = default;
V up_836 = default;
V W_837 = default;
V rs_838 = default;
V kind_833 = default;
V fx_834 = default;
if (_self822.IsNullish) _self822 = GlobalV;
kind_833 = (_argc823 > 4 ? _rest824[0] : V.Undef);
fx_834 = (_argc823 > 5 ? _rest824[1] : V.Undef);
t_835 = Call(TL_11, V.Undef, LB_829);
Invoke(Invoke(Invoke(Invoke(Invoke(t_835, "wait", ((V)(120D))), "to", ((V)(200D)), NewObj(3).Put("close", ((V)(0.5))).Put("zz", ((V)(0D))).Put("drm", ((V)(0D))).V), "to", ((V)(220D)), NewObj(1).Put("close", ((V)(1D))).V), "wait", ((V)(160D))), "to", ((V)(180D)), NewObj(2).Put("close", ((V)(0.25))).Put("wide", ((V)(0.2))).V);
up_836 = NewObj(16).Put("pitch", (Get(SB_830, "pitch") is var _t839 && Truthy(_t839) ? _t839 : ((V)(0D)))).Put("sq", (Get(SB_830, "sq") is var _t840 && Truthy(_t840) ? _t840 : ((V)(0D)))).Put("lift", (Get(SB_830, "lift") is var _t841 && Truthy(_t841) ? _t841 : ((V)(0D)))).Put("tilt", ((V)(0D))).Put("htilt", ((V)(0D))).Put("turn", ((V)(0D))).Put("curl", (Get(SB_830, "curl") is var _t842 && Truthy(_t842) ? _t842 : ((V)(0D)))).Put("lean", ((V)(0D))).Put("x", ((V)(0D))).Put("footL", (Get(SB_830, "footL") is var _t843 && Truthy(_t843) ? _t843 : ((V)(0D)))).Put("footR", (Get(SB_830, "footR") is var _t844 && Truthy(_t844) ? _t844 : ((V)(0D)))).Put("qk", ((V)((SEqS(kind_833, "bed") ? 0.55 : 0D)))).Put("close", ((V)(0.2))).Put("smile", ((V)(0.3))).Put("mw", ((V)(1D))).Put("winkL", ((V)(0D))).V;
Invoke(t_835, "to", ((V)(650D)), up_836, ((V)("io")));
W_837 = Call(o_10, V.Undef, NewObj(13).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).Put("hLy", ((V)((-5D)))).Put("hRy", ((V)((-5D)))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("sq", ((V)((ToNum((Get(SB_830, "sq") is var _t845 && Truthy(_t845) ? _t845 : ((V)(0D)))) - 0.08)))).Put("close", ((V)(0.9))).Put("open", ((V)(0.9))).Put("mw", ((V)(0.8))).Put("tongue", ((V)(0.18))).Put("pitch", Add((Get(SB_830, "pitch") is var _t846 && Truthy(_t846) ? _t846 : ((V)(0D))), ((V)(0.3)))).Put("wide", ((V)(0D))).V, (Get(X_832, "wk") is var _t847 && Truthy(_t847) ? _t847 : NewObj(0).V));
Invoke(t_835, "to", ((V)(700D)), W_837, ((V)("io")));
if (Truthy(Get(X_832, "wfx"))) {
InvokeSpread(t_835, "fx", new ArrBuilder().Spread(Get(X_832, "wfx")).V);
}
Invoke(t_835, "osc", ((V)(560D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(1.6))).V, NewObj(1).Put("tilt", ((V)((-1.6)))).V, ((V)("s")));
rs_838 = NewObj(13).Put("armL", (Get(SB_830, "armL") is var _t848 && Truthy(_t848) ? _t848 : ((V)(0D)))).Put("armR", (Get(SB_830, "armR") is var _t849 && Truthy(_t849) ? _t849 : ((V)(0D)))).Put("hLy", (Get(SB_830, "hLy") is var _t850 && Truthy(_t850) ? _t850 : ((V)(0D)))).Put("hRy", (Get(SB_830, "hRy") is var _t851 && Truthy(_t851) ? _t851 : ((V)(0D)))).Put("hLx", (Get(SB_830, "hLx") is var _t852 && Truthy(_t852) ? _t852 : ((V)(0D)))).Put("hRx", (Get(SB_830, "hRx") is var _t853 && Truthy(_t853) ? _t853 : ((V)(0D)))).Put("sq", (Get(SB_830, "sq") is var _t854 && Truthy(_t854) ? _t854 : ((V)(0D)))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("tongue", ((V)(0D))).Put("pitch", (Get(SB_830, "pitch") is var _t855 && Truthy(_t855) ? _t855 : ((V)(0D)))).Put("close", ((V)(0.4))).Put("tilt", ((V)(0D))).V;
Invoke(Call(keysOf_15, V.Undef, (Get(X_832, "wk") is var _t865 && Truthy(_t865) ? _t865 : NewObj(0).V)), "forEach", Fn((V _arrowThis863, int _argc856, V p_862, V _a859, V _a860, V _a861, V[] _rest857) => {
if (GetK(rs_838, p_862).IsNullish) {
SetK(rs_838, p_862, (!GetK(SB_830, p_862).IsNullish ? GetK(SB_830, p_862) : (GetK(REST_9, p_862) is var _t864 && Truthy(_t864) ? _t864 : ((V)(0D)))));
}
return default;
}, 1, "", true));
Invoke(Invoke(t_835, "to", ((V)(520D)), rs_838, ((V)("io"))), "e", ((V)("blink")));
Invoke(Invoke(Invoke(Invoke(t_835, "to", ((V)(320D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(9D)), ((V)((-15D)))), NewObj(3).Put("armL", ((V)(36D))).Put("armR", ((V)(36D))).Put("close", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(720D)), ((V)(3D)), NewObj(4).Put("hLx", ((V)(11D))).Put("hRx", ((V)((-11D)))).Put("hLy", ((V)((-14D)))).Put("hRy", ((V)((-14D)))).V, NewObj(4).Put("hLx", ((V)(8D))).Put("hRx", ((V)((-8D)))).Put("hLy", ((V)((-16D)))).Put("hRy", ((V)((-16D)))).V, ((V)("s"))), "to", ((V)(360D)), NewObj(7).Put("hLx", (Get(SB_830, "hLx") is var _t866 && Truthy(_t866) ? _t866 : ((V)(0D)))).Put("hRx", (Get(SB_830, "hRx") is var _t867 && Truthy(_t867) ? _t867 : ((V)(0D)))).Put("hLy", (Get(SB_830, "hLy") is var _t868 && Truthy(_t868) ? _t868 : ((V)(0D)))).Put("hRy", (Get(SB_830, "hRy") is var _t869 && Truthy(_t869) ? _t869 : ((V)(0D)))).Put("armL", (Get(SB_830, "armL") is var _t870 && Truthy(_t870) ? _t870 : ((V)(0D)))).Put("armR", (Get(SB_830, "armR") is var _t871 && Truthy(_t871) ? _t871 : ((V)(0D)))).Put("close", ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink2")));
Invoke(Invoke(t_835, "to", ((V)(240D)), NewObj(2).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(160D)));
return Invoke(t_835, "out", NewObj(3).Put("next", ((V)(JsStrBuf.Begin().V(kind_833).S("out").End()))).Put("blend", ((V)(320D))).Put("fx", fx_834).V);
return default;
}, 6, "wakeUp", false);
bedOut_53 = Fn((V _self872, int _argc873, V SB_879, V P_880, V X_881, V kind_882, V[] _rest874) => {
V B_884 = default;
V t_885 = default;
V fL_886 = default;
V fR_887 = default;
V hop_888 = default;
V st_889 = default;
V fx_883 = default;
if (_self872.IsNullish) _self872 = GlobalV;
fx_883 = (_argc873 > 4 ? _rest874[0] : V.Undef);
B_884 = Call(o_10, V.Undef, SB_879, NewObj(3).Put("qk", ((V)((SEqS(kind_882, "bed") ? 0.55 : 0D)))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V);
t_885 = Call(TL_11, V.Undef, B_884);
fL_886 = (Get(SB_879, "footL") is var _t890 && Truthy(_t890) ? _t890 : ((V)(0D)));
fR_887 = (Get(SB_879, "footR") is var _t891 && Truthy(_t891) ? _t891 : ((V)(0D)));
if (SEqS(kind_882, "bed")) {
Invoke(Invoke(Invoke(t_885, "osc", ((V)(660D)), ((V)(3D)), NewObj(3).Put("footL", Add(fL_886, ((V)(3D)))).Put("footR", fR_887).Put("qk", ((V)(0.42))).V, NewObj(3).Put("footL", fL_886).Put("footR", Add(fR_887, ((V)(3D)))).Put("qk", ((V)(0.32))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(4).Put("qk", ((V)(0D))).Put("footL", Add(fL_886, ((V)(3.6)))).Put("footR", Add(fR_887, ((V)(3.6)))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(3).Put("footL", fL_886).Put("footR", fR_887).Put("open", ((V)(0D))).V);
} else {
if (SEqS(kind_882, "bean")) {
Invoke(Invoke(Invoke(t_885, "to", ((V)(300D)), NewObj(2).Put("sq", Add((Get(SB_879, "sq") is var _t894 && Truthy(_t894) ? _t894 : ((V)(0D))), ((V)(0.12)))).Put("lift", ((V)((ToNum((Get(SB_879, "lift") is var _t895 && Truthy(_t895) ? _t895 : ((V)(0D)))) - 1D)))).V, ((V)("io"))), "osc", ((V)(640D)), ((V)(3D)), NewObj(2).Put("x", ((V)(1D))).Put("tilt", ((V)(3D))).V, NewObj(2).Put("x", ((V)((-1D)))).Put("tilt", ((V)((-3D)))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(4).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sq", (Get(SB_879, "sq") is var _t892 && Truthy(_t892) ? _t892 : ((V)(0D)))).Put("lift", (Get(SB_879, "lift") is var _t893 && Truthy(_t893) ? _t893 : ((V)(0D)))).V, ((V)("io")));
} else {
Invoke(t_885, "osc", ((V)(600D)), ((V)(2D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("s")));
}
}
hop_888 = Get(t_885, "t");
Call(exitMove_22, V.Undef, t_885, B_884, (Get(P_880, "up") is var _t896 && Truthy(_t896) ? _t896 : ((V)("hop"))));
Invoke(t_885, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
st_889 = Invoke(t_885, "out", NewObj(3).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).Put("fx", fx_883).V);
Set(st_889, "hop", hop_888);
return st_889;
return default;
}, 5, "bedOut", false);
bedBuild_55 = Fn((V _self897, int _argc898, V key_904, V X_905, V _a902, V _a903, V[] _rest899) => {
V P_906 = default;
V SB_907 = default;
V nm_908 = default;
V fx_909 = default;
V fl_910 = default;
V sea_911 = default;
V adj_912 = default;
V LB_913 = default;
V LN_914 = default;
V CB_915 = default;
V S_916 = default;
if (_self897.IsNullish) _self897 = GlobalV;
X_905 = (X_905 is var _t917 && Truthy(_t917) ? _t917 : NewObj(0).V);
P_906 = (GetK(PROF_35, key_904) is var _t918 && Truthy(_t918) ? _t918 : NewObj(0).V);
SB_907 = Call(o_10, V.Undef, SIT0_17, (Get(P_906, "pose") is var _t919 && Truthy(_t919) ? _t919 : NewObj(0).V));
nm_908 = Fn((V _arrowThis927, int _argc920, V n_926, V _a923, V _a924, V _a925, V[] _rest921) => {
return (Truthy(key_904) ? ((V)(JsStrBuf.Begin().V(n_926).S("@").V(key_904).End())) : n_926);
}, 1, "", true);
fx_909 = Call(sleepFx_47, V.Undef, Get(X_905, "dr"), Get(X_905, "zc"), Get(X_905, "qy"));
fl_910 = (SEqS(Get(P_906, "dn"), "float") ? V.True : V.False);
sea_911 = ((SEqS(Get(P_906, "dn"), "flop") && SEqN(Get((Get(P_906, "pose") is var _t928 && Truthy(_t928) ? _t928 : NewObj(0).V), "sit"), 0D)) ? V.True : V.False);
adj_912 = (Truthy(fl_910) ? NewObj(2).Put("sit", ((V)(0D))).Put("lift", ((V)(1.2))).V : (Truthy(sea_911) ? NewObj(4).Put("sit", ((V)(0D))).Put("pitch", ((V)((-0.1)))).Put("htilt", ((V)(4D))).Put("lift", ((V)((-1.6)))).V : NewObj(0).V));
LB_913 = Call(o_10, V.Undef, SB_907, LIE0_40, adj_912, (Get(X_905, "lp") is var _t929 && Truthy(_t929) ? _t929 : NewObj(0).V));
LN_914 = Call(o_10, V.Undef, LB_913, NewObj(1).Put("qk", ((V)(0D))).V, (Get(X_905, "np") is var _t930 && Truthy(_t930) ? _t930 : NewObj(0).V));
CB_915 = Call(o_10, V.Undef, SB_907, CURL0_41, (Truthy(fl_910) ? NewObj(2).Put("sit", ((V)(0D))).Put("lift", ((V)(0.4))).V : NewObj(0).V), (Get(X_905, "bp") is var _t931 && Truthy(_t931) ? _t931 : NewObj(0).V));
S_916 = NewObj(0).V;
Invoke(Arr(Arr(((V)("bed")), LB_913), Arr(((V)("lie")), LN_914), Arr(((V)("bean")), CB_915)), "forEach", Fn((V _arrowThis943, int _argc932, V _a934, V _a935, V _a936, V _a937, V[] _rest933) => {
V k_940 = default;
V @base_942 = default;
{ V _t938 = ListOf(_a934);
{ V _t939 = GetIdx(_t938, 0D);
k_940 = _t939; }
{ V _t941 = GetIdx(_t938, 1D);
@base_942 = _t941; }
}
SetK(S_916, Call(nm_908, V.Undef, ((V)(JsStrBuf.Begin().V(k_940).S("in").End()))), Call(bedIn_51, V.Undef, SB_907, @base_942, P_906, X_905, k_940, fx_909));
SetK(S_916, Call(nm_908, V.Undef, k_940), Call(sleepHold_50, V.Undef, @base_942, X_905, k_940, fx_909));
SetK(S_916, Call(nm_908, V.Undef, ((V)(JsStrBuf.Begin().V(k_940).S("wake").End()))), Call(wakeUp_52, V.Undef, @base_942, SB_907, P_906, X_905, k_940, fx_909));
SetK(S_916, Call(nm_908, V.Undef, ((V)(JsStrBuf.Begin().V(k_940).S("out").End()))), Call(bedOut_53, V.Undef, SB_907, P_906, X_905, k_940, fx_909));
return default;
}, 1, "", true));
Invoke(R_8, "add", S_916);
Set(R_8, "HS", Object_assign((Get(R_8, "HS") is var _t944 && Truthy(_t944) ? _t944 : NewObj(0).V), S_916));
if (Truthy(key_904)) {
SetK(BED_54, key_904, X_905);
}
return default;
}, 2, "bedBuild", false);
stroke_60 = Fn((V _self945, int _argc946, V t_952, V d_953, V B_954, V sw_955, V[] _rest947) => {
double n_957 = 0;
double h_958 = 0;
V L_959 = default;
V Q_960 = default;
V xa_961 = default;
V xb_962 = default;
V X_956 = default;
if (_self945.IsNullish) _self945 = GlobalV;
X_956 = (_argc946 > 4 ? _rest947[0] : V.Undef);
n_957 = Max(1D, Round((ToNum(d_953) / (SEqS(sw_955, "glide") ? 1400D : (SEqS(sw_955, "float") ? 1600D : (SEqS(sw_955, "bob") ? 1300D : 900D))))));
h_958 = ((ToNum(d_953) / n_957) / 2D);
L_959 = (Get(B_954, "lift") is var _t963 && Truthy(_t963) ? _t963 : ((V)(0D)));
Q_960 = (Get(B_954, "sq") is var _t964 && Truthy(_t964) ? _t964 : ((V)(0D)));
xa_961 = (Get(X_956, "ka") is var _t965 && Truthy(_t965) ? _t965 : NewObj(0).V);
xb_962 = (Get(X_956, "kb") is var _t966 && Truthy(_t966) ? _t966 : NewObj(0).V);
{
double i_967 = 0;
i_967 = 0D;
while (true) {
if (!((i_967 < n_957))) break;
if (SEqS(sw_955, "glide")) {
Invoke(Invoke(t_952, "to", ((V)(h_958)), Call(o_10, V.Undef, NewObj(5).Put("wag", ((V)(18D))).Put("tilt", ((V)(1.6))).Put("x", ((V)(0.6))).Put("lift", Add(L_959, ((V)(0.6)))).Put("htilt", ((V)((-1.5)))).V, Get(X_956, "sa")), ((V)("s"))), "to", ((V)(h_958)), Call(o_10, V.Undef, NewObj(5).Put("wag", ((V)((-18D)))).Put("tilt", ((V)((-1.6)))).Put("x", ((V)((-0.6)))).Put("lift", ((V)((ToNum(L_959) - 0.3)))).Put("htilt", ((V)(1.5))).V, Get(X_956, "sb")), ((V)("s")));
} else {
if (SEqS(sw_955, "float")) {
Invoke(Invoke(t_952, "to", ((V)(h_958)), Call(o_10, V.Undef, NewObj(5).Put("lift", Add(L_959, ((V)(1.6)))).Put("sq", ((V)((ToNum(Q_960) - 0.03)))).Put("tilt", ((V)(2D))).Put("armL", Add((Get(B_954, "armL") is var _t971 && Truthy(_t971) ? _t971 : ((V)(0D))), ((V)(14D)))).Put("armR", ((V)((ToNum((Get(B_954, "armR") is var _t972 && Truthy(_t972) ? _t972 : ((V)(0D)))) - 6D)))).V, Get(X_956, "sa")), ((V)("s"))), "to", ((V)(h_958)), Call(o_10, V.Undef, NewObj(5).Put("lift", ((V)((ToNum(L_959) - 0.4)))).Put("sq", Add(Q_960, ((V)(0.03)))).Put("tilt", ((V)((-2D)))).Put("armL", ((V)((ToNum((Get(B_954, "armL") is var _t969 && Truthy(_t969) ? _t969 : ((V)(0D)))) - 6D)))).Put("armR", Add((Get(B_954, "armR") is var _t970 && Truthy(_t970) ? _t970 : ((V)(0D))), ((V)(14D)))).V, Get(X_956, "sb")), ((V)("s")));
} else {
if (SEqS(sw_955, "bob")) {
Invoke(Invoke(t_952, "to", ((V)(h_958)), Call(o_10, V.Undef, NewObj(4).Put("lift", Add(L_959, ((V)(1.3)))).Put("sq", ((V)((ToNum(Q_960) - 0.04)))).Put("turn", ((V)(0.14))).Put("tilt", ((V)(1.5))).V, Get(X_956, "sa")), ((V)("s"))), "to", ((V)(h_958)), Call(o_10, V.Undef, NewObj(4).Put("lift", ((V)((ToNum(L_959) - 0.5)))).Put("sq", Add(Q_960, ((V)(0.04)))).Put("turn", ((V)((-0.14)))).Put("tilt", ((V)((-1.5)))).V, Get(X_956, "sb")), ((V)("s")));
} else {
Invoke(Invoke(t_952, "to", ((V)(h_958)), Call(o_10, V.Undef, NewObj(8).Put("armL", Add((Get(B_954, "armL") is var _t975 && Truthy(_t975) ? _t975 : ((V)(0D))), ((V)(26D)))).Put("armR", ((V)((ToNum((Get(B_954, "armR") is var _t976 && Truthy(_t976) ? _t976 : ((V)(0D)))) - 16D)))).Put("tilt", ((V)(2.6))).Put("x", ((V)(0.5))).Put("lift", Add(L_959, ((V)(0.8)))).Put("htilt", ((V)((-2.2)))).Put("footL", ((V)(1.4))).Put("footR", ((V)(0D))).V, Get(X_956, "sa")), ((V)("s"))), "to", ((V)(h_958)), Call(o_10, V.Undef, NewObj(8).Put("armL", ((V)((ToNum((Get(B_954, "armL") is var _t973 && Truthy(_t973) ? _t973 : ((V)(0D)))) - 16D)))).Put("armR", Add((Get(B_954, "armR") is var _t974 && Truthy(_t974) ? _t974 : ((V)(0D))), ((V)(26D)))).Put("tilt", ((V)((-2.6)))).Put("x", ((V)((-0.5)))).Put("lift", ((V)((ToNum(L_959) - 0.3)))).Put("htilt", ((V)(2.2))).Put("footL", ((V)(0D))).Put("footR", ((V)(1.4))).V, Get(X_956, "sb")), ((V)("s")));
}
}
}
if (NumTruthy((i_967 % 2D))) {
Invoke(t_952, "fx", ((V)("drop")), ((V)((((i_967 % 4D) == 1D) ? "sideL" : "sideR"))), ((V)(2D)));
}
i_967++;
}
}
return Invoke(t_952, "back", ((V)(260D)), Arr(((V)("armL")), ((V)("armR")), ((V)("tilt")), ((V)("x")), ((V)("lift")), ((V)("htilt")), ((V)("footL")), ((V)("footR")), ((V)("wag")), ((V)("sq")), ((V)("turn"))));
return default;
}, 5, "stroke", false);
shakeDry_61 = Fn((V _self977, int _argc978, V t_984, V X_985, V _a982, V _a983, V[] _rest979) => {
V k_986 = default;
V A_987 = default;
V Bv_988 = default;
V z_989 = default;
if (_self977.IsNullish) _self977 = GlobalV;
k_986 = (Get(X_985, "k") is var _t990 && Truthy(_t990) ? _t990 : NewObj(0).V);
A_987 = Call(o_10, V.Undef, NewObj(8).Put("x", ((V)(1.7))).Put("tilt", ((V)(8D))).Put("htilt", ((V)((-7D)))).Put("earL", ((V)((-14D)))).Put("earR", ((V)(12D))).Put("sq", ((V)(0.03))).Put("close", ((V)(0.7))).Put("open", ((V)(0.2))).V, Get(k_986, "a"));
Bv_988 = Call(o_10, V.Undef, NewObj(8).Put("x", ((V)((-1.7)))).Put("tilt", ((V)((-8D)))).Put("htilt", ((V)(7D))).Put("earL", ((V)(12D))).Put("earR", ((V)((-14D)))).Put("sq", ((V)((-0.02)))).Put("close", ((V)(0.7))).Put("open", ((V)(0.2))).V, Get(k_986, "b"));
Invoke(t_984, "to", ((V)(220D)), NewObj(4).Put("sq", ((V)(0.08))).Put("close", ((V)(0.5))).Put("wet", ((V)(1D))).Put("lift", ((V)(0D))).V, ((V)("io")));
{
double j_991 = 0;
j_991 = 0D;
while (true) {
if (!((j_991 < 3D))) break;
Invoke(t_984, "osc", ((V)(340D)), ((V)(3D)), A_987, Bv_988, ((V)("l")));
Invoke(Invoke(t_984, "fx", ((V)("splash")), ((V)(((j_991 == 1D) ? "head" : "body"))), ((V)(((j_991 == 1D) ? 5D : 7D)))), "fx", ((V)("drop")), ((V)((NumTruthy((j_991 % 2D)) ? "sideL" : "sideR"))), ((V)(4D)));
j_991++;
}
}
Invoke(Invoke(Invoke(Invoke(t_984, "to", ((V)(160D)), NewObj(6).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("htilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wet", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(220D)), Call(o_10, V.Undef, NewObj(8).Put("sq", ((V)((-0.09)))).Put("lift", ((V)(2D))).Put("wide", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("close", ((V)(0D))).Put("wet", ((V)(0D))).V, Get(k_986, "f")), ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("sq", ((V)(0.03))).Put("lift", ((V)(0D))).V, ((V)("i"))), "e", ((V)("blink2")));
z_989 = NewObj(7).Put("wide", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("close", ((V)(0D))).V;
Invoke(Object_keys(Call(o_10, V.Undef, Get(k_986, "a"), Get(k_986, "f"))), "forEach", Fn((V _arrowThis1000, int _argc993, V p_999, V _a996, V _a997, V _a998, V[] _rest994) => {
return SetK(z_989, p_999, (GetK(REST_9, p_999) is var _t1001 && Truthy(_t1001) ? _t1001 : ((V)(0D))));
}, 1, "", true));
return Invoke(t_984, "to", ((V)(320D)), z_989, ((V)("io")));
return default;
}, 2, "shakeDry", false);
wHold_66 = Fn((V _self1002, int _argc1003, V B_1009, V X_1010, V kind_1011, V sw_1012, V[] _rest1004) => {
V t_1013 = default;
V v_1014 = default;
V bt_1015 = default;
V g_1016 = default;
V L_1017 = default;
V BK_1018 = default;
V sig_1019 = default;
V st_1020 = default;
if (_self1002.IsNullish) _self1002 = GlobalV;
t_1013 = Call(TL_11, V.Undef, B_1009);
v_1014 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1009), "forEach", Fn((V _arrowThis1028, int _argc1021, V p_1027, V _a1024, V _a1025, V _a1026, V[] _rest1022) => {
return SetK(v_1014, p_1027, GetK(B_1009, p_1027));
}, 1, "", true));
Invoke(t_1013, "to", ((V)(10D)), v_1014);
bt_1015 = Arr();
g_1016 = (Get(X_1010, "gap") is var _t1029 && Truthy(_t1029) ? _t1029 : (SEqS(kind_1011, "swim") ? Arr(((V)(1800D)), ((V)(2400D)), ((V)(2000D)), ((V)(2600D))) : Arr(((V)(1700D)), ((V)(2300D)), ((V)(1900D)), ((V)(2500D)))));
L_1017 = (GetK(X_1010, ((V)(JsStrBuf.Begin().V(kind_1011).S("Ord").End()))) is var _t1030 && Truthy(_t1030) ? _t1030 : GetK(WORD_65, kind_1011));
BK_1018 = (SEqS(kind_1011, "tub") ? TB_62 : (SEqS(kind_1011, "shower") ? SB0_63 : WB0_64));
sig_1019 = (SEqS(kind_1011, "swim") ? (Get(X_1010, "ws") is var _t1031 && Truthy(_t1031) ? _t1031 : Get(X_1010, "s")) : (SEqS(kind_1011, "shower") ? (Get(X_1010, "ss") is var _t1032 && Truthy(_t1032) ? _t1032 : Get(X_1010, "s")) : Get(X_1010, "s")));
Invoke(L_1017, "forEach", Fn((V _arrowThis1041, int _argc1033, V n_1039, V i_1040, V _a1037, V _a1038, V[] _rest1034) => {
V a_1042 = default;
if (SEqS(kind_1011, "swim")) {
Call(stroke_60, V.Undef, t_1013, GetIdx(g_1016, (ToNum(i_1040) % ToNum(Get(g_1016, "length")))), B_1009, sw_1012, X_1010);
} else {
Invoke(t_1013, "wait", GetIdx(g_1016, (ToNum(i_1040) % ToNum(Get(g_1016, "length")))));
}
a_1042 = Get(t_1013, "t");
if (SEqS(n_1039, "sig")) {
if (!(Truthy(sig_1019))) {
return default;
}
Call(sig_1019, V.Undef, t_1013);
} else {
InvokeK(BK_1018, n_1039, t_1013);
}
Invoke(bt_1015, "push", Arr(n_1039, a_1042, Get(t_1013, "t")));
return default;
}, 2, "", true));
if (SEqS(kind_1011, "swim")) {
Call(stroke_60, V.Undef, t_1013, ((V)(1600D)), B_1009, sw_1012, X_1010);
} else {
Invoke(t_1013, "wait", ((V)(1400D)));
}
st_1020 = Invoke(t_1013, "out", NewObj(3).Put("breathe", ((V)((SEqS(kind_1011, "swim") ? 0.4 : 0.8)))).Put("look", (!SEqS(kind_1011, "shower") ? V.True : V.False)).Put("blend", ((V)(520D))).V, (true ? V.True : V.False));
Set(st_1020, "beats", bt_1015);
return st_1020;
return default;
}, 4, "wHold", false);
tubIn_67 = Fn((V _self1043, int _argc1044, V B_1050, V P_1051, V X_1052, V _a1049, V[] _rest1045) => {
V t_1053 = default;
V fl_1054 = default;
V v_1055 = default;
if (_self1043.IsNullish) _self1043 = GlobalV;
t_1053 = Call(TL_11, V.Undef, REST_9);
fl_1054 = (SEqS(Get(P_1051, "dn"), "float") ? V.True : V.False);
if (Truthy(fl_1054)) {
Invoke(Invoke(t_1053, "to", ((V)(300D)), NewObj(3).Put("lift", ((V)(6D))).Put("sq", ((V)((-0.04)))).Put("hap", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(3).Put("lift", ((V)(9D))).Put("wd", ((V)(0.25))).Put("fm", ((V)(1D))).V, ((V)("s")));
} else {
Invoke(Invoke(Invoke(t_1053, "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0.12))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(7).Put("lift", ((V)(9D))).Put("sq", ((V)((-0.12)))).Put("footL", ((V)(2.4))).Put("footR", ((V)(2.4))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(10D)), NewObj(2).Put("wd", ((V)(0.25))).Put("fm", ((V)(1D))).V);
}
Invoke(Invoke(Invoke(Invoke(t_1053, "to", ((V)(230D)), NewObj(8).Put("lift", ((V)(0D))).Put("sq", ((V)(0.14))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("sit", ((V)(1D))).Put("wd", ((V)(0.45))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("belly")), ((V)(9D))), "fx", ((V)("drop")), ((V)("sideL")), ((V)(3D))), "fx", ((V)("drop")), ((V)("sideR")), ((V)(3D)));
Invoke(Invoke(Invoke(Invoke(t_1053, "to", ((V)(220D)), NewObj(3).Put("sq", ((V)(0.02))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(1000D)), Call(o_10, V.Undef, B_1050, NewObj(4).Put("close", ((V)(0.65))).Put("open", ((V)(0.3))).Put("smile", ((V)(1D))).Put("dk", ((V)(0D))).V), ((V)("s"))), "to", ((V)(450D)), NewObj(3).Put("dk", ((V)(1D))).Put("close", Get(B_1050, "close")).Put("open", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("bubble")), ((V)("belly")), ((V)(2D)));
if (Truthy(Get(X_1052, "inX"))) {
Invoke(X_1052, "inX", t_1053, B_1050);
}
v_1055 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1050), "forEach", Fn((V _arrowThis1063, int _argc1056, V p_1062, V _a1059, V _a1060, V _a1061, V[] _rest1057) => {
return SetK(v_1055, p_1062, GetK(B_1050, p_1062));
}, 1, "", true));
Invoke(t_1053, "to", ((V)(200D)), v_1055, ((V)("io")));
return Invoke(t_1053, "out", NewObj(2).Put("next", ((V)("tub"))).Put("blend", ((V)(240D))).V);
return default;
}, 3, "tubIn", false);
tubOut_68 = Fn((V _self1064, int _argc1065, V B_1071, V P_1072, V X_1073, V _a1070, V[] _rest1066) => {
V t_1074 = default;
V hop_1075 = default;
V z_1076 = default;
V st_1077 = default;
if (_self1064.IsNullish) _self1064 = GlobalV;
t_1074 = Call(TL_11, V.Undef, B_1071);
Invoke(Invoke(t_1074, "to", ((V)(400D)), NewObj(3).Put("dk", ((V)(0D))).Put("fh", ((V)(0D))).Put("spg", ((V)(0D))).V, ((V)("io"))), "to", ((V)(520D)), NewObj(7).Put("sk", ((V)(0D))).Put("wd", ((V)(0.5))).Put("lift", ((V)(1.5))).Put("sq", ((V)((-0.03)))).Put("open", ((V)(0.15))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_1074, "to", ((V)(160D)), NewObj(3).Put("sq", ((V)(0.1))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(8).Put("lift", ((V)(9D))).Put("sq", ((V)((-0.12)))).Put("wd", ((V)(0.12))).Put("sit", ((V)(0D))).Put("footL", ((V)(2.4))).Put("footR", ((V)(2.4))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("o"))), "to", ((V)(10D)), NewObj(3).Put("wd", ((V)(0D))).Put("fm", ((V)(0D))).Put("wet", ((V)(1D))).V);
hop_1075 = Get(t_1074, "t");
Invoke(t_1074, "to", ((V)(210D)), NewObj(6).Put("lift", ((V)(0D))).Put("sq", ((V)(0.1))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("i")));
Call(shakeDry_61, V.Undef, t_1074, X_1073);
z_1076 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1071), "forEach", Fn((V _arrowThis1085, int _argc1078, V p_1084, V _a1081, V _a1082, V _a1083, V[] _rest1079) => {
return SetK(z_1076, p_1084, (GetK(REST_9, p_1084) is var _t1086 && Truthy(_t1086) ? _t1086 : ((V)(0D))));
}, 1, "", true));
Invoke(t_1074, "to", ((V)(200D)), z_1076, ((V)("io")));
st_1077 = Invoke(t_1074, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V);
Set(st_1077, "hop", hop_1075);
return st_1077;
return default;
}, 3, "tubOut", false);
showerIn_69 = Fn((V _self1087, int _argc1088, V B_1094, V X_1095, V _a1092, V _a1093, V[] _rest1089) => {
V t_1096 = default;
V v_1097 = default;
if (_self1087.IsNullish) _self1087 = GlobalV;
t_1096 = Call(TL_11, V.Undef, REST_9);
Invoke(Invoke(Invoke(Invoke(t_1096, "to", ((V)(220D)), NewObj(3).Put("footL", ((V)(2D))).Put("lift", ((V)(1.2))).Put("tilt", ((V)(2D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(4).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).Put("lift", ((V)(0.4))).Put("tilt", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(5).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("shw", ((V)(1D))).V, ((V)("o")));
Invoke(Invoke(Invoke(Invoke(t_1096, "to", ((V)(110D)), NewObj(7).Put("wide", ((V)(1D))).Put("sq", ((V)((-0.07)))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.5))).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("wet", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(560D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.7))).V, NewObj(1).Put("x", ((V)((-0.7)))).V, ((V)("l"))), "to", ((V)(260D)), NewObj(2).Put("sqz", ((V)(0.7))).Put("wide", ((V)(0D))).V), "fx", ((V)("splash")), ((V)("head")), ((V)(4D)));
v_1097 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1094), "forEach", Fn((V _arrowThis1105, int _argc1098, V p_1104, V _a1101, V _a1102, V _a1103, V[] _rest1099) => {
return SetK(v_1097, p_1104, GetK(B_1094, p_1104));
}, 1, "", true));
Invoke(Invoke(t_1096, "to", ((V)(700D)), Call(o_10, V.Undef, v_1097, NewObj(4).Put("sqz", ((V)(0D))).Put("ly", ((V)(0D))).Put("x", ((V)(0D))).Put("open", ((V)(0.2))).V), ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("stm", Get(B_1094, "stm")).Put("open", ((V)(0D))).V, ((V)("s")));
if (Truthy(Get(X_1095, "inX"))) {
Invoke(X_1095, "inX", t_1096, B_1094);
}
return Invoke(t_1096, "out", NewObj(2).Put("next", ((V)("shower"))).Put("blend", ((V)(220D))).V);
return default;
}, 2, "showerIn", false);
showerOut_70 = Fn((V _self1106, int _argc1107, V B_1113, V X_1114, V _a1111, V _a1112, V[] _rest1108) => {
V t_1115 = default;
V z_1116 = default;
if (_self1106.IsNullish) _self1106 = GlobalV;
t_1115 = Call(TL_11, V.Undef, B_1113);
Invoke(Invoke(t_1115, "to", ((V)(320D)), NewObj(2).Put("shw", ((V)(0D))).Put("fh", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("stm", ((V)(0D))).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
Call(shakeDry_61, V.Undef, t_1115, X_1114);
Invoke(Invoke(Invoke(t_1115, "to", ((V)(220D)), NewObj(2).Put("footL", ((V)(2D))).Put("lift", ((V)(1.2))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(3).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).Put("lift", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(180D)), NewObj(2).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
z_1116 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1113), "forEach", Fn((V _arrowThis1124, int _argc1117, V p_1123, V _a1120, V _a1121, V _a1122, V[] _rest1118) => {
return SetK(z_1116, p_1123, (GetK(REST_9, p_1123) is var _t1125 && Truthy(_t1125) ? _t1125 : ((V)(0D))));
}, 1, "", true));
Invoke(t_1115, "to", ((V)(200D)), z_1116, ((V)("io")));
return Invoke(t_1115, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V);
return default;
}, 2, "showerOut", false);
swimIn_71 = Fn((V _self1126, int _argc1127, V B_1133, V X_1134, V _a1131, V _a1132, V[] _rest1128) => {
V t_1135 = default;
double n_1136 = 0;
V v_1137 = default;
if (_self1126.IsNullish) _self1126 = GlobalV;
t_1135 = Call(TL_11, V.Undef, REST_9);
n_1136 = 4D;
{
double i_1138 = 0;
i_1138 = 0D;
while (true) {
if (!((i_1138 < n_1136))) break;
double u_1140 = 0;
u_1140 = ((i_1138 + 1D) / n_1136);
Invoke(Invoke(t_1135, "to", ((V)(300D)), NewObj(9).Put("footL", ((V)((NumTruthy((i_1138 % 2D)) ? 0D : 2.2)))).Put("footR", ((V)((NumTruthy((i_1138 % 2D)) ? 2.2 : 0D)))).Put("tilt", ((V)((NumTruthy((i_1138 % 2D)) ? (-2D) : 2D)))).Put("wd", ((V)((ToNum(Get(B_1133, "wd")) * u_1140)))).Put("sk", ((V)((ToNum(Get(B_1133, "sk")) * u_1140)))).Put("armL", ((V)((22D + (20D * u_1140))))).Put("armR", ((V)((22D + (20D * u_1140))))).Put("sit", ((V)((ToNum(Get(B_1133, "sit")) * u_1140)))).Put("open", ((V)(0.2))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)((NumTruthy((i_1138 % 2D)) ? "sideR" : "sideL"))), ((V)(3D)));
i_1138++;
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_1135, "to", ((V)(120D)), NewObj(5).Put("wide", ((V)(0.9))).Put("sq", ((V)((-0.05)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("o"))), "osc", ((V)(500D)), ((V)(5D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(240D)), NewObj(4).Put("wide", ((V)(0D))).Put("sqz", ((V)(0.5))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.8))).V), "fx", ((V)("splash")), ((V)("sideL")), ((V)(4D))), "fx", ((V)("splash")), ((V)("sideR")), ((V)(4D)));
v_1137 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1133), "forEach", Fn((V _arrowThis1148, int _argc1141, V p_1147, V _a1144, V _a1145, V _a1146, V[] _rest1142) => {
return SetK(v_1137, p_1147, GetK(B_1133, p_1147));
}, 1, "", true));
Invoke(t_1135, "to", ((V)(500D)), Call(o_10, V.Undef, v_1137, NewObj(2).Put("sqz", ((V)(0D))).Put("x", ((V)(0D))).V), ((V)("io")));
if (Truthy(Get(X_1134, "inX"))) {
Invoke(X_1134, "inX", t_1135, B_1133);
}
return Invoke(t_1135, "out", NewObj(2).Put("next", ((V)("swim"))).Put("blend", ((V)(220D))).V);
return default;
}, 2, "swimIn", false);
swimOut_72 = Fn((V _self1149, int _argc1150, V B_1156, V X_1157, V _a1154, V _a1155, V[] _rest1151) => {
V t_1158 = default;
double n_1159 = 0;
V z_1160 = default;
if (_self1149.IsNullish) _self1149 = GlobalV;
t_1158 = Call(TL_11, V.Undef, B_1156);
n_1159 = 4D;
{
double i_1161 = 0;
i_1161 = 0D;
while (true) {
if (!((i_1161 < n_1159))) break;
double u_1163 = 0;
u_1163 = (1D - ((i_1161 + 1D) / n_1159));
Invoke(Invoke(t_1158, "to", ((V)(300D)), NewObj(11).Put("footL", ((V)((NumTruthy((i_1161 % 2D)) ? 0D : 2.2)))).Put("footR", ((V)((NumTruthy((i_1161 % 2D)) ? 2.2 : 0D)))).Put("tilt", ((V)((NumTruthy((i_1161 % 2D)) ? (-2D) : 2D)))).Put("wd", ((V)((ToNum(Get(B_1156, "wd")) * u_1163)))).Put("sk", ((V)((ToNum(Get(B_1156, "sk")) * u_1163)))).Put("dv", ((V)(0D))).Put("armL", ((V)((10D + (20D * u_1163))))).Put("armR", ((V)((10D + (20D * u_1163))))).Put("sit", ((V)((ToNum((Get(B_1156, "sit") is var _t1164 && Truthy(_t1164) ? _t1164 : ((V)(0D)))) * u_1163)))).Put("pitch", ((V)(0D))).Put("wet", ((V)(1D))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)((NumTruthy((i_1161 % 2D)) ? "sideR" : "sideL"))), ((V)(3D)));
i_1161++;
}
}
Invoke(t_1158, "to", ((V)(160D)), NewObj(4).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("tilt", ((V)(0D))).Put("wd", ((V)(0D))).V, ((V)("io")));
Call(shakeDry_61, V.Undef, t_1158, X_1157);
z_1160 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1156), "forEach", Fn((V _arrowThis1172, int _argc1165, V p_1171, V _a1168, V _a1169, V _a1170, V[] _rest1166) => {
return SetK(z_1160, p_1171, (GetK(REST_9, p_1171) is var _t1173 && Truthy(_t1173) ? _t1173 : ((V)(0D))));
}, 1, "", true));
Invoke(t_1158, "to", ((V)(200D)), z_1160, ((V)("io")));
return Invoke(t_1158, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V);
return default;
}, 2, "swimOut", false);
waterBuild_74 = Fn((V _self1174, int _argc1175, V key_1181, V X_1182, V _a1179, V _a1180, V[] _rest1176) => {
V P_1183 = default;
V nm_1184 = default;
V sw_1185 = default;
V S_1186 = default;
V TBp_1187 = default;
V SHp_1188 = default;
V SWp_1189 = default;
V sk_1190 = default;
if (_self1174.IsNullish) _self1174 = GlobalV;
X_1182 = (X_1182 is var _t1191 && Truthy(_t1191) ? _t1191 : NewObj(0).V);
P_1183 = (GetK(PROF_35, key_1181) is var _t1192 && Truthy(_t1192) ? _t1192 : NewObj(0).V);
nm_1184 = Fn((V _arrowThis1200, int _argc1193, V n_1199, V _a1196, V _a1197, V _a1198, V[] _rest1194) => {
return (Truthy(key_1181) ? ((V)(JsStrBuf.Begin().V(n_1199).S("@").V(key_1181).End())) : n_1199);
}, 1, "", true);
sw_1185 = (Get(X_1182, "sw") is var _t1201 && Truthy(_t1201) ? _t1201 : ((V)((SEqS(Get(P_1183, "dn"), "float") ? "float" : "paddle"))));
S_1186 = NewObj(0).V;
TBp_1187 = Call(o_10, V.Undef, BATH0_56, (SEqS(Get(P_1183, "dn"), "float") ? NewObj(2).Put("sit", ((V)(0D))).Put("sk", ((V)(4D))).V : NewObj(0).V), (Get(X_1182, "bp") is var _t1202 && Truthy(_t1202) ? _t1202 : NewObj(0).V));
SHp_1188 = Call(o_10, V.Undef, SHOW0_57, (Get(X_1182, "hp") is var _t1203 && Truthy(_t1203) ? _t1203 : NewObj(0).V));
SWp_1189 = Call(o_10, V.Undef, SWIM0_58, (GetK(SWS_59, sw_1185) is var _t1204 && Truthy(_t1204) ? _t1204 : NewObj(0).V), (Get(X_1182, "wp") is var _t1205 && Truthy(_t1205) ? _t1205 : NewObj(0).V));
SetK(S_1186, Call(nm_1184, V.Undef, ((V)("tubin"))), Call(tubIn_67, V.Undef, TBp_1187, P_1183, X_1182));
SetK(S_1186, Call(nm_1184, V.Undef, ((V)("tub"))), Call(wHold_66, V.Undef, TBp_1187, X_1182, ((V)("tub")), sw_1185));
SetK(S_1186, Call(nm_1184, V.Undef, ((V)("tubout"))), Call(tubOut_68, V.Undef, TBp_1187, P_1183, X_1182));
SetK(S_1186, Call(nm_1184, V.Undef, ((V)("showerin"))), Call(showerIn_69, V.Undef, SHp_1188, X_1182));
SetK(S_1186, Call(nm_1184, V.Undef, ((V)("shower"))), Call(wHold_66, V.Undef, SHp_1188, X_1182, ((V)("shower")), sw_1185));
SetK(S_1186, Call(nm_1184, V.Undef, ((V)("showerout"))), Call(showerOut_70, V.Undef, SHp_1188, X_1182));
SetK(S_1186, Call(nm_1184, V.Undef, ((V)("swimin"))), Call(swimIn_71, V.Undef, SWp_1189, X_1182));
SetK(S_1186, Call(nm_1184, V.Undef, ((V)("swim"))), Call(wHold_66, V.Undef, SWp_1189, X_1182, ((V)("swim")), sw_1185));
SetK(S_1186, Call(nm_1184, V.Undef, ((V)("swimout"))), Call(swimOut_72, V.Undef, SWp_1189, X_1182));
sk_1190 = Call(TL_11, V.Undef, Call(o_10, V.Undef, REST_9, NewObj(1).Put("wet", ((V)(1D))).V));
Call(shakeDry_61, V.Undef, sk_1190, X_1182);
SetK(S_1186, Call(nm_1184, V.Undef, ((V)("shake"))), Invoke(sk_1190, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V));
Invoke(R_8, "add", S_1186);
Set(R_8, "HS", Object_assign((Get(R_8, "HS") is var _t1206 && Truthy(_t1206) ? _t1206 : NewObj(0).V), S_1186));
if (Truthy(key_1181)) {
SetK(WAT_73, key_1181, X_1182);
}
return default;
}, 2, "waterBuild", false);
playHold_81 = Fn((V _self1207, int _argc1208, V B_1214, V X_1215, V kind_1216, V sig_1217, V[] _rest1209) => {
V t_1218 = default;
V v_1219 = default;
V bt_1220 = default;
V g_1221 = default;
V BK_1222 = default;
V st_1223 = default;
if (_self1207.IsNullish) _self1207 = GlobalV;
t_1218 = Call(TL_11, V.Undef, B_1214);
v_1219 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1214), "forEach", Fn((V _arrowThis1231, int _argc1224, V p_1230, V _a1227, V _a1228, V _a1229, V[] _rest1225) => {
return SetK(v_1219, p_1230, GetK(B_1214, p_1230));
}, 1, "", true));
Invoke(t_1218, "to", ((V)(10D)), v_1219);
bt_1220 = Arr();
g_1221 = (Get(X_1215, "pgap") is var _t1232 && Truthy(_t1232) ? _t1232 : Arr(((V)(1500D)), ((V)(2100D)), ((V)(1700D)), ((V)(2300D))));
BK_1222 = (SEqS(kind_1216, "swing") ? PB_78 : RB_79);
Invoke((GetK(X_1215, ((V)(JsStrBuf.Begin().V(kind_1216).S("Ord").End()))) is var _t1243 && Truthy(_t1243) ? _t1243 : GetK(PORD_80, kind_1216)), "forEach", Fn((V _arrowThis1241, int _argc1233, V n_1239, V i_1240, V _a1237, V _a1238, V[] _rest1234) => {
V a_1242 = default;
Invoke(t_1218, "wait", GetIdx(g_1221, (ToNum(i_1240) % ToNum(Get(g_1221, "length")))));
a_1242 = Get(t_1218, "t");
if (SEqS(n_1239, "sig")) {
if (!(Truthy(sig_1217))) {
return default;
}
Call(sig_1217, V.Undef, t_1218);
} else {
if (SEqS(n_1239, "kick")) {
Invoke(BEAT_16, "kick", t_1218);
} else {
InvokeK(BK_1222, n_1239, t_1218, X_1215);
}
}
Invoke(bt_1220, "push", Arr(n_1239, a_1242, Get(t_1218, "t")));
return default;
}, 2, "", true));
Invoke(t_1218, "wait", ((V)(1200D)));
st_1223 = Invoke(t_1218, "out", NewObj(3).Put("breathe", ((V)(0.6))).Put("look", (SEqS(kind_1216, "swing") ? V.True : V.False)).Put("blend", ((V)(520D))).V, (true ? V.True : V.False));
Set(st_1223, "beats", bt_1220);
Set(st_1223, "sync", Call(o_10, V.Undef, NewObj(2).Put("ear", ((V)(14D))).Put("wag", ((V)(20D))).V, (Get(X_1215, "sy") is var _t1244 && Truthy(_t1244) ? _t1244 : NewObj(0).V)));
return st_1223;
return default;
}, 4, "playHold", false);
playIn_82 = Fn((V _self1245, int _argc1246, V B_1252, V P_1253, V kind_1254, V _a1251, V[] _rest1247) => {
V t_1255 = default;
V dn_1256 = default;
V v_1257 = default;
if (_self1245.IsNullish) _self1245 = GlobalV;
t_1255 = Call(TL_11, V.Undef, REST_9);
dn_1256 = (SEqS(kind_1254, "ride") ? ((SEqS(Get(P_1253, "dn"), "float") || SEqS(Get(P_1253, "dn"), "flop")) ? Get(P_1253, "dn") : ((V)("climb"))) : (Get(P_1253, "dn") is var _t1258 && Truthy(_t1258) ? _t1258 : ((V)("hop"))));
Call(enterMove_21, V.Undef, t_1255, B_1252, dn_1256);
v_1257 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1252), "forEach", Fn((V _arrowThis1266, int _argc1259, V p_1265, V _a1262, V _a1263, V _a1264, V[] _rest1260) => {
return SetK(v_1257, p_1265, GetK(B_1252, p_1265));
}, 1, "", true));
Invoke(t_1255, "to", ((V)(160D)), v_1257, ((V)("io")));
if (SEqS(kind_1254, "swing")) {
Invoke(Invoke(Invoke(Invoke(Invoke(t_1255, "to", ((V)(260D)), NewObj(2).Put("ly", ((V)((-0.8)))).Put("pitch", Add((Get(B_1252, "pitch") is var _t1274 && Truthy(_t1274) ? _t1274 : ((V)(0D))), ((V)(0.12)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(4).Put("sq", Add((Get(B_1252, "sq") is var _t1273 && Truthy(_t1273) ? _t1273 : ((V)(0D))), ((V)(0.05)))).Put("sqz", ((V)(0.5))).Put("hLy", Add(Get(B_1252, "hLy"), ((V)(1D)))).Put("hRy", Add(Get(B_1252, "hRy"), ((V)(1D)))).V, ((V)("o"))), "to", ((V)(280D)), NewObj(8).Put("ly", ((V)(0D))).Put("pitch", (Get(B_1252, "pitch") is var _t1271 && Truthy(_t1271) ? _t1271 : ((V)(0D)))).Put("sq", (Get(B_1252, "sq") is var _t1272 && Truthy(_t1272) ? _t1272 : ((V)(0D)))).Put("sqz", ((V)(0D))).Put("hLy", Get(B_1252, "hLy")).Put("hRy", Get(B_1252, "hRy")).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(3).Put("footL", ((V)((ToNum((Get(B_1252, "footL") is var _t1269 && Truthy(_t1269) ? _t1269 : ((V)(0D)))) - 0.6)))).Put("footR", ((V)((ToNum((Get(B_1252, "footR") is var _t1270 && Truthy(_t1270) ? _t1270 : ((V)(0D)))) - 0.6)))).Put("lean", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(4).Put("footL", (Get(B_1252, "footL") is var _t1267 && Truthy(_t1267) ? _t1267 : ((V)(0D)))).Put("footR", (Get(B_1252, "footR") is var _t1268 && Truthy(_t1268) ? _t1268 : ((V)(0D)))).Put("lean", ((V)(0D))).Put("hap", Get(B_1252, "hap")).V, ((V)("io")));
} else {
Invoke(Invoke(Invoke(Invoke(t_1255, "to", ((V)(240D)), NewObj(3).Put("sqz", ((V)(0.4))).Put("hLx", Add(Get(B_1252, "hLx"), ((V)(1.5)))).Put("hRx", ((V)((ToNum(Get(B_1252, "hRx")) - 1.5)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(6).Put("sqz", ((V)(0D))).Put("hLx", Get(B_1252, "hLx")).Put("hRx", Get(B_1252, "hRx")).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(2).Put("lean", ((V)(1D))).Put("sq", Add((Get(B_1252, "sq") is var _t1275 && Truthy(_t1275) ? _t1275 : ((V)(0D))), ((V)(0.03)))).V, NewObj(2).Put("lean", ((V)((-0.5)))).Put("sq", (Get(B_1252, "sq") is var _t1276 && Truthy(_t1276) ? _t1276 : ((V)(0D)))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(3).Put("open", ((V)(0D))).Put("hap", Get(B_1252, "hap")).Put("lean", ((V)(0D))).V, ((V)("io")));
}
return Invoke(t_1255, "out", NewObj(2).Put("next", kind_1254).Put("blend", ((V)(220D))).V);
return default;
}, 3, "playIn", false);
playOut_83 = Fn((V _self1277, int _argc1278, V B_1284, V P_1285, V kind_1286, V _a1283, V[] _rest1279) => {
V t_1287 = default;
V f_1288 = default;
V g_1289 = default;
V hop_1290 = default;
V st_1291 = default;
if (_self1277.IsNullish) _self1277 = GlobalV;
t_1287 = Call(TL_11, V.Undef, B_1284);
f_1288 = (Get(B_1284, "footL") is var _t1292 && Truthy(_t1292) ? _t1292 : ((V)(0D)));
g_1289 = (Get(B_1284, "footR") is var _t1293 && Truthy(_t1293) ? _t1293 : ((V)(0D)));
if (SEqS(kind_1286, "swing")) {
Invoke(Invoke(Invoke(t_1287, "to", ((V)(360D)), NewObj(5).Put("footL", ((V)((ToNum(f_1288) - 0.8)))).Put("footR", ((V)((ToNum(g_1289) - 0.8)))).Put("sq", Add((Get(B_1284, "sq") is var _t1294 && Truthy(_t1294) ? _t1294 : ((V)(0D))), ((V)(0.04)))).Put("pitch", ((V)((ToNum((Get(B_1284, "pitch") is var _t1295 && Truthy(_t1295) ? _t1295 : ((V)(0D)))) - 0.1)))).Put("wide", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.4))).V, NewObj(1).Put("x", ((V)((-0.4)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("x", ((V)(0D))).Put("wide", ((V)(0D))).V);
} else {
Invoke(Invoke(Invoke(t_1287, "to", ((V)(400D)), NewObj(4).Put("pitch", Add((Get(B_1284, "pitch") is var _t1297 && Truthy(_t1297) ? _t1297 : ((V)(0D))), ((V)(0.18)))).Put("hLy", Add(Get(B_1284, "hLy"), ((V)(4D)))).Put("hRy", Add(Get(B_1284, "hRy"), ((V)(4D)))).Put("open", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(200D)), NewObj(2).Put("open", ((V)(0D))).Put("pitch", (Get(B_1284, "pitch") is var _t1296 && Truthy(_t1296) ? _t1296 : ((V)(0D)))).V);
}
hop_1290 = Get(t_1287, "t");
Call(exitMove_22, V.Undef, t_1287, B_1284, ((SEqS(Get(P_1285, "up"), "float") || SEqS(Get(P_1285, "up"), "flop")) ? Get(P_1285, "up") : ((V)("hop"))));
Invoke(Invoke(Invoke(t_1287, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("hap", (Get(REST_9, "hap") is var _t1298 && Truthy(_t1298) ? _t1298 : ((V)(0D)))).Put("smile", (Get(REST_9, "smile") is var _t1299 && Truthy(_t1299) ? _t1299 : ((V)(0D)))).V, ((V)("io")));
st_1291 = Invoke(t_1287, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V);
Set(st_1291, "hop", hop_1290);
return st_1291;
return default;
}, 3, "playOut", false);
cookProp_89 = Fn((V _self1300, int _argc1301, V bt_1307, V rec_1308, V loop_1309, V _a1306, V[] _rest1302) => {
if (_self1300.IsNullish) _self1300 = GlobalV;
return Fn((V _arrowThis1318, int _argc1310, V I_1316, V tt_1317, V _a1314, V _a1315, V[] _rest1311) => {
V W_1319 = default;
double tl_1320 = 0;
V f_1321 = default;
V x_1322 = default;
V y_1323 = default;
W_1319 = Get(I_1316, "W");
if (((!(Truthy(W_1319)) || !(Truthy(Get(W_1319, "pawR")))) || !(IsFiniteV(GetIdx(Get(W_1319, "pawR"), 0D))))) {
return ((V)(""));
}
tl_1320 = (ToNum(tt_1317) % ToNum(loop_1309));
f_1321 = Call(facing_87, V.Undef, I_1316);
if (LtN(f_1321, 0.02)) {
return ((V)(""));
}
x_1322 = GetIdx(Get(W_1319, "pawR"), 0D);
y_1323 = GetIdx(Get(W_1319, "pawR"), 1D);
{
foreach (V _k1324 in new JsIter(bt_1307)) {
V n_1325 = default;
V a_1326 = default;
V b_1327 = default;
{ V _t1328 = ListOf(_k1324);
{ V _t1329 = GetIdx(_t1328, 0D);
n_1325 = _t1329; }
{ V _t1330 = GetIdx(_t1328, 1D);
a_1326 = _t1330; }
{ V _t1331 = GetIdx(_t1328, 2D);
b_1327 = _t1331; }
}
double k_1332 = 0;
if ((Lt(((V)(tl_1320)), a_1326) || Gt(((V)(tl_1320)), b_1327))) {
continue;
}
k_1332 = (ToNum(Call(win_88, V.Undef, ((V)(tl_1320)), a_1326, b_1327, ((V)(220D)))) * ToNum(f_1321));
if ((k_1332 < 0.02)) {
return ((V)(""));
}
if ((SEqS(n_1325, "stir") || SEqS(n_1325, "taste"))) {
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(r2_38, V.Undef, x_1322)).S(" ").V(Call(r2_38, V.Undef, y_1323)).S(") rotate(").V(Call(r2_38, V.Undef, ((V)((SEqS(n_1325, "stir") ? (18D + (FdLibm.Sin((tl_1320 / 110D)) * 8D)) : 150D))))).S(") scale(").V(Call(r2_38, V.Undef, ((V)((k_1332 * 1.5))))).S(")\">").V(SPOON_85).S("</g>").End()));
}
if ((SEqS(n_1325, "shake") || SEqS(n_1325, "flip"))) {
JsStrBuf cake_1333 = null;
V r0_1334 = default;
cake_1333 = new JsStrBuf("<ellipse cx=\"13\" cy=\"0.9\" rx=\"4.3\" ry=\"2\" fill=\"#f2c26a\" stroke=\"#c98a3a\" stroke-width=\"0.35\"/><ellipse cx=\"11.8\" cy=\"0.4\" rx=\"1.6\" ry=\"0.6\" fill=\"#fff0c0\" opacity=\"0.7\"/>");
r0_1334 = Invoke(rec_1308, "find", Fn((V _arrowThis1342, int _argc1335, V q_1341, V _a1338, V _a1339, V _a1340, V[] _rest1336) => {
return ((Ge(q_1341, a_1326) && Le(q_1341, b_1327)) ? V.True : V.False);
}, 1, "", true));
if ((SEqS(n_1325, "flip") && !r0_1334.IsNullish)) {
double u_1343 = 0;
u_1343 = ((tl_1320 - ToNum(r0_1334)) / 980D);
if (((u_1343 > 0D) && (u_1343 < 1D))) {
double th_1344 = 0;
double ry_1345 = 0;
th_1344 = (System.Math.PI * u_1343);
ry_1345 = Max(0.35, System.Math.Abs(((1.5 * FdLibm.Cos(th_1344)) + (4.3 * FdLibm.Sin(th_1344)))));
cake_1333.Set(JsStrBuf.Begin().S("<ellipse cx=\"13\" cy=\"").V(Call(r2_38, V.Undef, ((V)((0.4 - (22D * FdLibm.Sin((System.Math.PI * u_1343)))))))).S("\" rx=\"4.3\" ry=\"").V(Call(r2_38, V.Undef, ((V)(ry_1345)))).S("\" fill=\"").S(((u_1343 > 0.5) ? "#e0a24a" : "#f2c26a")).S("\" stroke=\"#c98a3a\" stroke-width=\"0.35\"/>").End());
}
}
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(r2_38, V.Undef, x_1322)).S(" ").V(Call(r2_38, V.Undef, y_1323)).S(") scale(").V(Call(r2_38, V.Undef, ((V)((k_1332 * 1.45))))).S(")\">").V(PAN_86).S(cake_1333.Str).S("</g>").End()));
}
return ((V)(""));
}
}
return ((V)(""));
return default;
}, 2, "", true);
return default;
}, 3, "cookProp", false);
cookIn_90 = Fn((V _self1346, int _argc1347, V B_1353, V _a1350, V _a1351, V _a1352, V[] _rest1348) => {
V t_1354 = default;
V v_1355 = default;
if (_self1346.IsNullish) _self1346 = GlobalV;
t_1354 = Call(TL_11, V.Undef, REST_9);
Invoke(Invoke(Invoke(t_1354, "to", ((V)(220D)), NewObj(2).Put("footL", ((V)(2D))).Put("lift", ((V)(1D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).V, ((V)("io"))), "to", ((V)(180D)), NewObj(2).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_1354, "to", ((V)(260D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(11D)), ((V)((-2D)))), NewObj(5).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.5))).V), ((V)("io"))), "osc", ((V)(800D)), ((V)(4D)), NewObj(2).Put("hLx", ((V)(13D))).Put("hRx", ((V)((-13D)))).V, NewObj(2).Put("hLx", ((V)(9D))).Put("hRx", ((V)((-9D)))).V, ((V)("l")));
v_1355 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1353), "forEach", Fn((V _arrowThis1363, int _argc1356, V p_1362, V _a1359, V _a1360, V _a1361, V[] _rest1357) => {
return SetK(v_1355, p_1362, GetK(B_1353, p_1362));
}, 1, "", true));
Invoke(t_1354, "to", ((V)(420D)), Call(o_10, V.Undef, v_1355, NewObj(1).Put("sqz", ((V)(0D))).V), ((V)("io")));
return Invoke(t_1354, "out", NewObj(2).Put("next", ((V)("cook"))).Put("blend", ((V)(200D))).V);
return default;
}, 1, "cookIn", false);
cookHold_91 = Fn((V _self1364, int _argc1365, V B_1371, V X_1372, V sig_1373, V _a1370, V[] _rest1366) => {
V t_1374 = default;
V v_1375 = default;
V bt_1376 = default;
V rec_1377 = default;
V g_1378 = default;
V st_1379 = default;
if (_self1364.IsNullish) _self1364 = GlobalV;
t_1374 = Call(TL_11, V.Undef, B_1371);
v_1375 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1371), "forEach", Fn((V _arrowThis1387, int _argc1380, V p_1386, V _a1383, V _a1384, V _a1385, V[] _rest1381) => {
return SetK(v_1375, p_1386, GetK(B_1371, p_1386));
}, 1, "", true));
Invoke(t_1374, "to", ((V)(10D)), v_1375);
bt_1376 = Arr();
rec_1377 = Arr();
g_1378 = (Get(X_1372, "cgap") is var _t1388 && Truthy(_t1388) ? _t1388 : Arr(((V)(500D)), ((V)(700D)), ((V)(600D)), ((V)(800D))));
Invoke((Get(X_1372, "cOrd") is var _t1399 && Truthy(_t1399) ? _t1399 : Arr(((V)("stir")), ((V)("season")), ((V)("shake")), ((V)("flip")), ((V)("sig")), ((V)("stir")), ((V)("taste")), ((V)("kiss")))), "forEach", Fn((V _arrowThis1397, int _argc1389, V n_1395, V i_1396, V _a1393, V _a1394, V[] _rest1390) => {
V a_1398 = default;
Invoke(t_1374, "wait", GetIdx(g_1378, (ToNum(i_1396) % ToNum(Get(g_1378, "length")))));
a_1398 = Get(t_1374, "t");
if (SEqS(n_1395, "sig")) {
if (!(Truthy(sig_1373))) {
return default;
}
Call(sig_1373, V.Undef, t_1374);
} else {
InvokeK(CB_84, n_1395, t_1374, X_1372, rec_1377);
}
Invoke(bt_1376, "push", Arr(n_1395, a_1398, Get(t_1374, "t")));
return default;
}, 2, "", true));
Invoke(t_1374, "wait", ((V)(900D)));
st_1379 = Invoke(t_1374, "out", NewObj(3).Put("breathe", ((V)(0.6))).Put("look", (false ? V.True : V.False)).Put("blend", ((V)(420D))).V, (true ? V.True : V.False));
Set(st_1379, "beats", bt_1376);
Set(st_1379, "prop", Call(cookProp_89, V.Undef, bt_1376, rec_1377, Get(st_1379, "loop")));
return st_1379;
return default;
}, 3, "cookHold", false);
fridgeMove_92 = Fn((V _self1400, int _argc1401, V X_1407, V icon_1408, V _a1405, V _a1406, V[] _rest1402) => {
V t_1409 = default;
V IC_1410 = default;
V found_1411 = default;
V turn_1412 = default;
V a_1413 = default;
V b_1414 = default;
V st_1415 = default;
if (_self1400.IsNullish) _self1400 = GlobalV;
t_1409 = Call(TL_11, V.Undef, REST_9);
IC_1410 = (GetK(ICON_45, icon_1408) is var _t1416 && Truthy(_t1416) ? _t1416 : Get(ICON_45, "cookie"));
Invoke(Invoke(Invoke(t_1409, "to", ((V)(320D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)((-6D)))), NewObj(3).Put("armR", ((V)(62D))).Put("lx", ((V)(0.3))).Put("ly", ((V)((-0.2)))).V), ((V)("io"))), "to", ((V)(260D)), NewObj(5).Put("lean", ((V)((-1D)))).Put("tilt", ((V)((-3D)))).Put("sq", ((V)(0.04))).Put("armR", ((V)(46D))).Put("pitch", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(4).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sq", ((V)(0D))).Put("armR", ((V)(30D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_1409, "to", ((V)(110D)), NewObj(5).Put("wide", ((V)(1D))).Put("sq", ((V)((-0.05)))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.5))).Put("armR", ((V)(20D))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head"))), "osc", ((V)(520D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(4).Put("wide", ((V)(0D))).Put("sqz", ((V)(0.5))).Put("open", ((V)(0D))).Put("x", ((V)(0D))).V);
Invoke(t_1409, "to", ((V)(360D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(6D)), ((V)((-6D)))), NewObj(7).Put("pitch", ((V)((-0.22)))).Put("ly", ((V)(0.5))).Put("sq", ((V)(0.05))).Put("armL", ((V)(58D))).Put("armR", ((V)(58D))).Put("sqz", ((V)(0D))).Put("mw", ((V)(1D))).V), ((V)("io")));
{
double i_1417 = 0;
i_1417 = 0D;
while (true) {
if (!((i_1417 < 4D))) break;
Invoke(Invoke(t_1409, "to", ((V)(170D)), NewObj(4).Put("armL", ((V)(74D))).Put("armR", ((V)(44D))).Put("htilt", ((V)(5D))).Put("x", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(4).Put("armL", ((V)(44D))).Put("armR", ((V)(74D))).Put("htilt", ((V)((-5D)))).Put("x", ((V)((-0.6)))).V, ((V)("io")));
if ((i_1417 == 1D)) {
Invoke(t_1409, "fx", ((V)("crumb")), ((V)("head")), ((V)(3D)));
}
i_1417++;
}
}
Invoke(Invoke(Invoke(Invoke(t_1409, "to", ((V)(220D)), NewObj(6).Put("armL", ((V)(58D))).Put("armR", ((V)(58D))).Put("htilt", ((V)(0D))).Put("x", ((V)(0D))).Put("lx", ((V)((-0.6)))).Put("ly", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(260D))), "to", ((V)(220D)), NewObj(1).Put("lx", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(240D)));
found_1411 = Get(t_1409, "t");
Invoke(Invoke(t_1409, "to", ((V)(200D)), NewObj(9).Put("wide", ((V)(0.9))).Put("open", ((V)(0.35))).Put("mw", ((V)(0.6))).Put("armL", ((V)(22D))).Put("armR", ((V)(40D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(320D)));
turn_1412 = Get(t_1409, "t");
Invoke(t_1409, "to", ((V)(380D)), Call(o_10, V.Undef, NewObj(12).Put("armR", ((V)(150D))).Put("hRx", ((V)(1D))).Put("hRy", ((V)((-4D)))).Put("armL", ((V)(20D))).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("lift", ((V)(2.4))).Put("sq", ((V)((-0.06)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.5))).V, Get(X_1407, "cheer")), ((V)("o")));
if (Truthy(Get(X_1407, "cheerFx"))) {
InvokeSpread(t_1409, "fx", new ArrBuilder().Spread(Get(X_1407, "cheerFx")).V);
} else {
Invoke(t_1409, "fx", ((V)("spark")), ((V)("pawR")), ((V)(4D)));
}
Invoke(Invoke(Invoke(t_1409, "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V), "wait", ((V)(500D)));
Invoke(Invoke(Invoke(t_1409, "to", ((V)(220D)), NewObj(4).Put("x", ((V)((-1.4)))).Put("tilt", ((V)((-6D)))).Put("armR", ((V)(110D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
a_1413 = Add(found_1411, ((V)(150D)));
b_1414 = Add(Get(t_1409, "t"), ((V)(200D)));
Invoke(t_1409, "back", ((V)(320D)));
st_1415 = Invoke(t_1409, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(180D))).V);
Set(st_1415, "turn", turn_1412);
Set(st_1415, "prop", Fn((V _arrowThis1427, int _argc1419, V I_1425, V tt_1426, V _a1423, V _a1424, V[] _rest1420) => {
V W_1428 = default;
double k_1429 = 0;
W_1428 = Get(I_1425, "W");
if (((!(Truthy(W_1428)) || !(Truthy(Get(W_1428, "pawR")))) || !(IsFiniteV(GetIdx(Get(W_1428, "pawR"), 0D))))) {
return ((V)(""));
}
k_1429 = (ToNum(Call(win_88, V.Undef, tt_1426, a_1413, b_1414, ((V)(200D)))) * ToNum(Call(facing_87, V.Undef, I_1425)));
if ((k_1429 < 0.02)) {
return ((V)(""));
}
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(r2_38, V.Undef, GetIdx(Get(W_1428, "pawR"), 0D))).S(" ").V(Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(Get(W_1428, "pawR"), 1D)) - 3D))))).S(") scale(").V(Call(r2_38, V.Undef, ((V)((k_1429 * 3.2))))).S(")\">").V(IC_1410).S("</g>").End()));
return default;
}, 2, "", true));
return st_1415;
return default;
}, 2, "fridgeMove", false);
playBuild_94 = Fn((V _self1430, int _argc1431, V key_1437, V X_1438, V _a1435, V _a1436, V[] _rest1432) => {
V P_1439 = default;
V nm_1440 = default;
V S_1441 = default;
V SB_1442 = default;
V sig_1443 = default;
V ksig_1444 = default;
V SW_1445 = default;
V RD_1446 = default;
V CK_1447 = default;
if (_self1430.IsNullish) _self1430 = GlobalV;
X_1438 = Call(o_10, V.Undef, (GetK(WX_29, key_1437) is var _t1448 && Truthy(_t1448) ? _t1448 : NewObj(0).V), (X_1438 is var _t1449 && Truthy(_t1449) ? _t1449 : NewObj(0).V));
P_1439 = (GetK(PROF_35, key_1437) is var _t1450 && Truthy(_t1450) ? _t1450 : NewObj(0).V);
nm_1440 = Fn((V _arrowThis1458, int _argc1451, V n_1457, V _a1454, V _a1455, V _a1456, V[] _rest1452) => {
return (Truthy(key_1437) ? ((V)(JsStrBuf.Begin().V(n_1457).S("@").V(key_1437).End())) : n_1457);
}, 1, "", true);
S_1441 = NewObj(0).V;
SB_1442 = Call(o_10, V.Undef, SIT0_17, (Get(P_1439, "pose") is var _t1459 && Truthy(_t1459) ? _t1459 : NewObj(0).V));
sig_1443 = (Get(X_1438, "p") is var _t1469 && Truthy(_t1469) ? _t1469 : Invoke((Get(P_1439, "f") is var _t1468 && Truthy(_t1468) ? _t1468 : Arr()), "find", Fn((V _arrowThis1467, int _argc1460, V f_1466, V _a1463, V _a1464, V _a1465, V[] _rest1461) => {
return (string.Equals(Typeof(f_1466), "function") ? V.True : V.False);
}, 1, "", true)));
ksig_1444 = (Get(X_1438, "k") is var _t1470 && Truthy(_t1470) ? _t1470 : sig_1443);
SW_1445 = Call(o_10, V.Undef, SB_1442, SWG0_75, (Get(X_1438, "sp") is var _t1471 && Truthy(_t1471) ? _t1471 : NewObj(0).V));
RD_1446 = Call(o_10, V.Undef, SB_1442, RID0_76, (Get(X_1438, "rp") is var _t1472 && Truthy(_t1472) ? _t1472 : NewObj(0).V));
CK_1447 = Call(o_10, V.Undef, CK0_77, (Get(X_1438, "cp") is var _t1473 && Truthy(_t1473) ? _t1473 : NewObj(0).V));
Invoke(Arr(Arr(((V)("swing")), SW_1445), Arr(((V)("ride")), RD_1446)), "forEach", Fn((V _arrowThis1485, int _argc1474, V _a1476, V _a1477, V _a1478, V _a1479, V[] _rest1475) => {
V k_1482 = default;
V B_1484 = default;
{ V _t1480 = ListOf(_a1476);
{ V _t1481 = GetIdx(_t1480, 0D);
k_1482 = _t1481; }
{ V _t1483 = GetIdx(_t1480, 1D);
B_1484 = _t1483; }
}
SetK(S_1441, Call(nm_1440, V.Undef, ((V)(JsStrBuf.Begin().V(k_1482).S("in").End()))), Call(playIn_82, V.Undef, B_1484, P_1439, k_1482));
SetK(S_1441, Call(nm_1440, V.Undef, k_1482), Call(playHold_81, V.Undef, B_1484, X_1438, k_1482, sig_1443));
SetK(S_1441, Call(nm_1440, V.Undef, ((V)(JsStrBuf.Begin().V(k_1482).S("out").End()))), Call(playOut_83, V.Undef, B_1484, P_1439, k_1482));
return default;
}, 1, "", true));
SetK(S_1441, Call(nm_1440, V.Undef, ((V)("cookin"))), Call(cookIn_90, V.Undef, CK_1447));
SetK(S_1441, Call(nm_1440, V.Undef, ((V)("cook"))), Call(cookHold_91, V.Undef, CK_1447, X_1438, ksig_1444));
SetK(S_1441, Call(nm_1440, V.Undef, ((V)("fridge"))), Call(fridgeMove_92, V.Undef, X_1438, (Get(X_1438, "sn") is var _t1486 && Truthy(_t1486) ? _t1486 : ((V)("cookie")))));
Invoke(R_8, "add", S_1441);
Set(R_8, "HS", Object_assign((Get(R_8, "HS") is var _t1487 && Truthy(_t1487) ? _t1487 : NewObj(0).V), S_1441));
if (Truthy(key_1437)) {
SetK(PLY_93, key_1437, X_1438);
}
return default;
}, 2, "playBuild", false);
bHold_101 = Fn((V _self1488, int _argc1489, V B_1495, V ord_1496, V BK_1497, V X_1498, V[] _rest1490) => {
V t_1502 = default;
V v_1503 = default;
V bt_1504 = default;
V rec_1505 = default;
V st_1506 = default;
V sig_1499 = default;
V gaps_1500 = default;
V ex_1501 = default;
if (_self1488.IsNullish) _self1488 = GlobalV;
sig_1499 = (_argc1489 > 4 ? _rest1490[0] : V.Undef);
gaps_1500 = (_argc1489 > 5 ? _rest1490[1] : V.Undef);
ex_1501 = (_argc1489 > 6 ? _rest1490[2] : V.Undef);
t_1502 = Call(TL_11, V.Undef, B_1495);
v_1503 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, B_1495), "forEach", Fn((V _arrowThis1514, int _argc1507, V p_1513, V _a1510, V _a1511, V _a1512, V[] _rest1508) => {
return SetK(v_1503, p_1513, GetK(B_1495, p_1513));
}, 1, "", true));
Invoke(t_1502, "to", ((V)(10D)), v_1503);
bt_1504 = Arr();
rec_1505 = NewObj(0).V;
Invoke(ord_1496, "forEach", Fn((V _arrowThis1523, int _argc1515, V n_1521, V i_1522, V _a1519, V _a1520, V[] _rest1516) => {
V a_1524 = default;
Invoke(t_1502, "wait", GetIdx(gaps_1500, (ToNum(i_1522) % ToNum(Get(gaps_1500, "length")))));
a_1524 = Get(t_1502, "t");
if (SEqS(n_1521, "sig")) {
if (!(Truthy(sig_1499))) {
return default;
}
Call(sig_1499, V.Undef, t_1502);
} else {
if (Truthy(GetK(BK_1497, n_1521))) {
InvokeK(BK_1497, n_1521, t_1502, X_1498, rec_1505);
} else {
InvokeK(BEAT_16, n_1521, t_1502);
}
}
Invoke(bt_1504, "push", Arr(n_1521, a_1524, Get(t_1502, "t")));
return default;
}, 2, "", true));
Invoke(t_1502, "wait", ((V)(900D)));
st_1506 = Invoke(t_1502, "out", Call(o_10, V.Undef, NewObj(3).Put("breathe", ((V)(0.6))).Put("look", (false ? V.True : V.False)).Put("blend", ((V)(460D))).V, (ex_1501 is var _t1525 && Truthy(_t1525) ? _t1525 : NewObj(0).V)), (true ? V.True : V.False));
Set(st_1506, "beats", bt_1504);
Set(st_1506, "rec", rec_1505);
return st_1506;
return default;
}, 7, "bHold", false);
brushProp_106 = Fn((V _self1526, int _argc1527, V st_1533, V col_1534, V _a1531, V _a1532, V[] _rest1528) => {
V BRU_1535 = default;
if (_self1526.IsNullish) _self1526 = GlobalV;
BRU_1535 = Fn((V _arrowThis1543, int _argc1536, V L_1542, V _a1539, V _a1540, V _a1541, V[] _rest1537) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"-3\" y=\"-1.2\" width=\"").V(Call(r2_38, V.Undef, Add(L_1542, ((V)(3D))))).S("\" height=\"2.4\" rx=\"1.2\" fill=\"").V(col_1534).S("\" stroke=\"").V(Call(shade_42, V.Undef, col_1534, ((V)(0.7)))).S("\" stroke-width=\"0.45\"/><path d=\"M-1.6-0.5H").V(Call(r2_38, V.Undef, ((V)((ToNum(L_1542) - 6D))))).S("\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.45\" stroke-linecap=\"round\"/><rect x=\"").V(Call(r2_38, V.Undef, ((V)((ToNum(L_1542) - 4.6))))).S("\" y=\"-4.4\" width=\"4.6\" height=\"3.4\" rx=\"0.8\" fill=\"#ffffff\" stroke=\"#b9c6d6\" stroke-width=\"0.45\"/><path d=\"M").V(Call(r2_38, V.Undef, ((V)((ToNum(L_1542) - 3.6))))).S(" -4.2V-1.4M").V(Call(r2_38, V.Undef, ((V)((ToNum(L_1542) - 2.3))))).S(" -4.2V-1.4M").V(Call(r2_38, V.Undef, ((V)((ToNum(L_1542) - 1D))))).S(" -4.2V-1.4\" stroke=\"#d6e2ee\" stroke-width=\"0.4\"/>").End()));
}, 1, "", true);
return Fn((V _arrowThis1552, int _argc1544, V I_1550, V tt_1551, V _a1548, V _a1549, V[] _rest1545) => {
V W_1553 = default;
V f0_1554 = default;
double tl_1555 = 0;
V p_1556 = default;
V M_1557 = default;
double fm_1558 = 0;
double dx_1559 = 0;
double dy_1560 = 0;
V d_1561 = default;
V h_1562 = default;
W_1553 = Get(I_1550, "W");
if ((!(Truthy(W_1553)) || !(Truthy(Call(okp_95, V.Undef, Get(W_1553, "pawR")))))) {
return ((V)(""));
}
f0_1554 = Call(facing_87, V.Undef, I_1550);
if (LtN(f0_1554, 0.02)) {
return ((V)(""));
}
tl_1555 = (ToNum(tt_1551) % ToNum(Get(st_1533, "loop")));
p_1556 = Get(W_1553, "pawR");
M_1557 = (Truthy(Call(okp_95, V.Undef, Get(W_1553, "mouth"))) ? Get(W_1553, "mouth") : Arr(((V)((ToNum(GetIdx(p_1556, 0D)) - 8D))), GetIdx(p_1556, 1D)));
fm_1558 = 0D;
{
foreach (V _k1563 in new JsIter(Get(st_1533, "beats"))) {
V n_1564 = default;
V a_1565 = default;
V b_1566 = default;
{ V _t1567 = ListOf(_k1563);
{ V _t1568 = GetIdx(_t1567, 0D);
n_1564 = _t1568; }
{ V _t1569 = GetIdx(_t1567, 1D);
a_1565 = _t1569; }
{ V _t1570 = GetIdx(_t1567, 2D);
b_1566 = _t1570; }
}
double u_1571 = 0;
if (Lt(((V)(tl_1555)), a_1565)) {
break;
}
u_1571 = Min(1D, ((Min(tl_1555, ToNum(b_1566)) - ToNum(a_1565)) / 900D));
if ((SEqS(n_1564, "brush") || SEqS(n_1564, "side"))) {
fm_1558 = Max(fm_1558, u_1571);
} else {
if (SEqS(n_1564, "spit")) {
fm_1558 = (fm_1558 * (1D - ToNum(Call(ss_25, V.Undef, ((V)((((tl_1555 - ToNum(a_1565)) - 300D) / 180D)))))));
}
}
}
}
dx_1559 = (ToNum(GetIdx(M_1557, 0D)) - ToNum(GetIdx(p_1556, 0D)));
dy_1560 = (ToNum(GetIdx(M_1557, 1D)) - ToNum(GetIdx(p_1556, 1D)));
d_1561 = (((V)(Hypot(dx_1559, dy_1560))) is var _t1572 && Truthy(_t1572) ? _t1572 : ((V)(1D)));
h_1562 = Call(G_100, V.Undef, GetIdx(p_1556, 0D), GetIdx(p_1556, 1D), ((V)(((FdLibm.Atan2(dy_1560, dx_1559) * 180D) / System.Math.PI))), ((V)(1D)), Call(BRU_1535, V.Undef, Call(cl_39, V.Undef, Add(d_1561, ((V)(2D))), ((V)(9D)), ((V)(17D)))), f0_1554);
if ((fm_1558 > 0.03)) {
JsStrBuf fo_1573 = null;
fo_1573 = new JsStrBuf("");
Invoke(Arr(Arr(((V)(0D)), ((V)(0D)), ((V)(1.6))), Arr(((V)((-1.8))), ((V)(0.7)), ((V)(1.2))), Arr(((V)(1.9)), ((V)(0.5)), ((V)(1.3))), Arr(((V)((-0.6))), ((V)(1.6)), ((V)(1D))), Arr(((V)(0.9)), ((V)((-0.9))), ((V)(0.9)))), "forEach", Fn((V _arrowThis1588, int _argc1574, V _a1576, V i_1580, V _a1578, V _a1579, V[] _rest1575) => {
double rr_1589 = 0;
V x_1583 = default;
V y_1585 = default;
V r_1587 = default;
{ V _t1581 = ListOf(_a1576);
{ V _t1582 = GetIdx(_t1581, 0D);
x_1583 = _t1582; }
{ V _t1584 = GetIdx(_t1581, 1D);
y_1585 = _t1584; }
{ V _t1586 = GetIdx(_t1581, 2D);
r_1587 = _t1586; }
}
rr_1589 = (((1.8 * ToNum(r_1587)) * fm_1558) * (0.9 + (0.12 * FdLibm.Sin(((ToNum(tt_1551) / 90D) + (ToNum(i_1580) * 2D))))));
if ((rr_1589 > 0.2)) {
fo_1573.V(Call(ci_43, V.Undef, Call(r2_38, V.Undef, Add(GetIdx(M_1557, 0D), ((V)(((1.8 * ToNum(x_1583)) * (0.6 + (fm_1558 * 0.5))))))), Call(r2_38, V.Undef, Add(Add(GetIdx(M_1557, 1D), ((V)(1.4))), ((V)((1.6 * ToNum(y_1585)))))), Call(r2_38, V.Undef, ((V)(rr_1589))), ((V)("#ffffff")), ((V)("#cfe6f6"))));
}
return default;
}, 2, "", true));
h_1562 = ((V)(JsStrBuf.Begin().V(h_1562).S("<g opacity=\"").V(Call(r2_38, V.Undef, ((V)((0.95 * ToNum(f0_1554)))))).S("\">").S(fo_1573.Str).S("</g>").End()));
}
return h_1562;
return default;
}, 2, "", true);
return default;
}, 2, "brushProp", false);
dineProp_108 = Fn((V _self1590, int _argc1591, V st_1597, V icon_1598, V md_1599, V _a1596, V[] _rest1592) => {
V IC_1600 = default;
if (_self1590.IsNullish) _self1590 = GlobalV;
IC_1600 = (GetK(ICON_45, icon_1598) is var _t1601 && Truthy(_t1601) ? _t1601 : Get(ICON_45, "cookie"));
return Fn((V _arrowThis1610, int _argc1602, V I_1608, V tt_1609, V _a1606, V _a1607, V[] _rest1603) => {
V W_1611 = default;
V f0_1612 = default;
double tl_1613 = 0;
double k_1614 = 0;
V x_1615 = default;
V y_1616 = default;
V h_1617 = default;
V sb_1618 = default;
W_1611 = Get(I_1608, "W");
if (((!(Truthy(W_1611)) || !(Truthy(Call(okp_95, V.Undef, Get(W_1611, "pawR"))))) || !(Truthy(Call(okp_95, V.Undef, Get(W_1611, "pawL")))))) {
return ((V)(""));
}
f0_1612 = Call(facing_87, V.Undef, I_1608);
if (LtN(f0_1612, 0.02)) {
return ((V)(""));
}
tl_1613 = (ToNum(tt_1609) % ToNum(Get(st_1597, "loop")));
k_1614 = Max(0.35, (1D - (ToNum(Call(cnt_98, V.Undef, Get(Get(st_1597, "rec"), "bite"), ((V)(0D)), ((V)(tl_1613)))) * 0.2)));
x_1615 = V.Undef;
y_1616 = V.Undef;
if (SEqS(md_1599, "lap")) {
V B_1619 = default;
B_1619 = (Truthy(Call(okp_95, V.Undef, Get(W_1611, "belly"))) ? Get(W_1611, "belly") : (Get(W_1611, "body") is var _t1620 && Truthy(_t1620) ? _t1620 : Arr(((V)(50D)), ((V)(80D)))));
x_1615 = GetIdx(B_1619, 0D);
y_1616 = Add(GetIdx(B_1619, 1D), ((V)(3D)));
} else {
if (Truthy(((SEqS(md_1599, "two") ? V.True : V.False) is var _t1621 && Truthy(_t1621) ? _t1621 : Get(I_1608, "foodMid")))) {
x_1615 = ((V)((ToNum(Add(GetIdx(Get(W_1611, "pawL"), 0D), GetIdx(Get(W_1611, "pawR"), 0D))) / 2D)));
y_1616 = ((V)(((ToNum(Add(GetIdx(Get(W_1611, "pawL"), 1D), GetIdx(Get(W_1611, "pawR"), 1D))) / 2D) - 2D)));
} else {
x_1615 = GetIdx(Get(W_1611, "pawR"), 0D);
y_1616 = ((V)((ToNum(GetIdx(Get(W_1611, "pawR"), 1D)) - 2.5)));
}
}
h_1617 = Call(G_100, V.Undef, x_1615, ((V)((ToNum(y_1616) - 2D))), ((V)(0D)), ((V)((4D * k_1614))), IC_1600, f0_1612);
sb_1618 = Invoke(Get(st_1597, "beats"), "find", Fn((V _arrowThis1629, int _argc1622, V b_1628, V _a1625, V _a1626, V _a1627, V[] _rest1623) => {
return (((SEqS(GetIdx(b_1628, 0D), "sip") && Ge(((V)(tl_1613)), GetIdx(b_1628, 1D))) && Le(((V)(tl_1613)), GetIdx(b_1628, 2D))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(sb_1618)) {
V u_1630 = default;
u_1630 = Call(win_88, V.Undef, ((V)(tl_1613)), GetIdx(sb_1618, 1D), GetIdx(sb_1618, 2D), ((V)(220D)));
if (GtN(u_1630, 0.02)) {
h_1617 = Add(h_1617, Call(G_100, V.Undef, GetIdx(Get(W_1611, "pawL"), 0D), ((V)((ToNum(GetIdx(Get(W_1611, "pawL"), 1D)) - 4D))), ((V)((-10D))), ((V)((3.8 * ToNum(u_1630)))), Get(ICON_45, "cup"), f0_1612));
}
}
return h_1617;
return default;
}, 2, "", true);
return default;
}, 3, "dineProp", false);
fishProp_113 = Fn((V _self1631, int _argc1632, V st_1638, V icon_1639, V _a1636, V _a1637, V[] _rest1633) => {
V IC_1640 = default;
V R0_1641 = default;
if (_self1631.IsNullish) _self1631 = GlobalV;
IC_1640 = (GetK(ICON_45, icon_1639) is var _t1642 && Truthy(_t1642) ? _t1642 : Get(ICON_45, "fish"));
R0_1641 = Get(st_1638, "rec");
return Fn((V _arrowThis1651, int _argc1643, V I_1649, V tt_1650, V _a1647, V _a1648, V[] _rest1644) => {
V W_1652 = default;
double tl_1653 = 0;
V p_1654 = default;
V gx_1655 = default;
V gy_1656 = default;
V Wp_1657 = default;
V ang_1658 = default;
double bend_1659 = 0;
JsStrBuf mode_1660 = null;
V E_1661 = default;
V fly_1662 = default;
V cat_1663 = default;
V C_1664 = default;
V Rl_1665 = default;
V Ct_1666 = default;
double an_1667 = 0;
double Ln_1668 = 0;
V tip_1669 = default;
double nx_1670 = 0;
double ny_1671 = 0;
V cp_1672 = default;
V hang_1673 = default;
JsStrBuf h_1674 = null;
double sag_1675 = 0;
W_1652 = Get(I_1649, "W");
if ((!(Truthy(W_1652)) || !(Truthy(Call(okp_95, V.Undef, Get(W_1652, "pawR")))))) {
return ((V)(""));
}
tl_1653 = (ToNum(tt_1650) % ToNum(Get(st_1638, "loop")));
p_1654 = Get(W_1652, "pawR");
{ V _t1676 = Call(gnd_96, V.Undef, I_1649);
{ V _t1677 = ListOf(_t1676);
{ V _t1678 = GetIdx(_t1677, 0D);
gx_1655 = _t1678; }
{ V _t1679 = GetIdx(_t1677, 1D);
gy_1656 = _t1679; }
} }
Wp_1657 = Arr(Add(Call(rside_97, V.Undef, I_1649, gx_1655), ((V)(22D))), ((V)(((ToNum(gy_1656) - 2D) + (FdLibm.Sin((ToNum(tt_1650) / 420D)) * 0.6)))));
ang_1658 = ((V)((-40D)));
bend_1659 = 0D;
mode_1660 = new JsStrBuf("tip");
E_1661 = V.Null;
fly_1662 = ((V)(0D));
cat_1663 = ((V)(0D));
C_1664 = GetIdx((Get(R0_1641, "cast") is var _t1680 && Truthy(_t1680) ? _t1680 : Arr()), 0D);
Rl_1665 = GetIdx((Get(R0_1641, "reel") is var _t1681 && Truthy(_t1681) ? _t1681 : Arr()), 0D);
Ct_1666 = GetIdx((Get(R0_1641, "catch") is var _t1682 && Truthy(_t1682) ? _t1682 : Arr()), 0D);
if (Truthy((C_1664 is var _t1683 && !Truthy(_t1683) ? _t1683 : (Ge(((V)(tl_1653)), GetIdx(C_1664, 0D)) ? V.True : V.False)))) {
if (Lt(((V)(tl_1653)), GetIdx(C_1664, 1D))) {
ang_1658 = Call(lerp_99, V.Undef, ((V)((-40D))), ((V)((-122D))), Call(ss_25, V.Undef, ((V)(((tl_1653 - ToNum(GetIdx(C_1664, 0D))) / (ToNum(GetIdx(C_1664, 1D)) - ToNum(GetIdx(C_1664, 0D))))))));
} else {
ang_1658 = Call(lerp_99, V.Undef, ((V)((-122D))), ((V)((-30D))), Call(ss_25, V.Undef, ((V)(((tl_1653 - ToNum(GetIdx(C_1664, 1D))) / 180D)))));
fly_1662 = Call(cl_39, V.Undef, ((V)(((tl_1653 - ToNum(GetIdx(C_1664, 1D))) / 650D))), ((V)(0D)), ((V)(1D)));
mode_1660.Set((LtN(fly_1662, 1D) ? "fly" : "water"));
}
}
if (Truthy((Rl_1665 is var _t1684 && !Truthy(_t1684) ? _t1684 : (Ge(((V)(tl_1653)), GetIdx(Rl_1665, 0D)) ? V.True : V.False)))) {
V u_1685 = default;
u_1685 = Call(cl_39, V.Undef, ((V)(((tl_1653 - ToNum(GetIdx(Rl_1665, 0D))) / (ToNum(GetIdx(Rl_1665, 1D)) - ToNum(GetIdx(Rl_1665, 0D)))))), ((V)(0D)), ((V)(1D)));
ang_1658 = ((V)(((-52D) + (FdLibm.Sin((tl_1653 / 90D)) * 3D))));
bend_1659 = (4D + FdLibm.Sin((tl_1653 / 70D)));
mode_1660.Set("reel");
fly_1662 = u_1685;
}
if (Truthy((Rl_1665 is var _t1686 && !Truthy(_t1686) ? _t1686 : (Gt(((V)(tl_1653)), GetIdx(Rl_1665, 1D)) ? V.True : V.False)))) {
ang_1658 = ((V)((-60D)));
bend_1659 = 3D;
mode_1660.Set("tip");
}
if (Truthy((Ct_1666 is var _t1687 && !Truthy(_t1687) ? _t1687 : (Ge(((V)(tl_1653)), GetIdx(Ct_1666, 0D)) ? V.True : V.False)))) {
ang_1658 = Call(lerp_99, V.Undef, ((V)((-60D))), ((V)((-84D))), Call(ss_25, V.Undef, ((V)(((tl_1653 - ToNum(GetIdx(Ct_1666, 0D))) / 300D)))));
bend_1659 = 1.5;
mode_1660.Set((Lt(((V)(tl_1653)), GetIdx(Ct_1666, 1D)) ? "catch" : "tip"));
cat_1663 = Call(win_88, V.Undef, ((V)(tl_1653)), Add(GetIdx(Ct_1666, 0D), ((V)(120D))), GetIdx(Ct_1666, 1D), ((V)(260D)));
if (Gt(((V)(tl_1653)), GetIdx(Ct_1666, 1D))) {
ang_1658 = Call(lerp_99, V.Undef, ((V)((-84D))), ((V)((-40D))), Call(ss_25, V.Undef, ((V)(((tl_1653 - ToNum(GetIdx(Ct_1666, 1D))) / 400D)))));
}
}
an_1667 = ((ToNum(ang_1658) * System.Math.PI) / 180D);
Ln_1668 = 42D;
tip_1669 = Arr(Add(GetIdx(p_1654, 0D), ((V)((FdLibm.Cos(an_1667) * Ln_1668)))), Add(GetIdx(p_1654, 1D), ((V)((FdLibm.Sin(an_1667) * Ln_1668)))));
nx_1670 = (-FdLibm.Sin(an_1667));
ny_1671 = FdLibm.Cos(an_1667);
cp_1672 = Arr(((V)(((ToNum(Add(GetIdx(p_1654, 0D), GetIdx(tip_1669, 0D))) / 2D) + (nx_1670 * bend_1659)))), ((V)(((ToNum(Add(GetIdx(p_1654, 1D), GetIdx(tip_1669, 1D))) / 2D) + (ny_1671 * bend_1659)))));
hang_1673 = Arr(GetIdx(tip_1669, 0D), Add(GetIdx(tip_1669, 1D), ((V)(10D))));
if (string.Equals(mode_1660.Str, "fly")) {
E_1661 = Arr(Call(lerp_99, V.Undef, GetIdx(tip_1669, 0D), GetIdx(Wp_1657, 0D), fly_1662), ((V)((ToNum(Call(lerp_99, V.Undef, GetIdx(tip_1669, 1D), GetIdx(Wp_1657, 1D), fly_1662)) - (FdLibm.Sin((System.Math.PI * ToNum(fly_1662))) * 22D)))));
} else {
if (string.Equals(mode_1660.Str, "water")) {
V nb_1688 = default;
E_1661 = Arr(GetIdx(Wp_1657, 0D), GetIdx(Wp_1657, 1D));
nb_1688 = Invoke((Get(R0_1641, "nib") is var _t1697 && Truthy(_t1697) ? _t1697 : Arr()), "find", Fn((V _arrowThis1696, int _argc1689, V n_1695, V _a1692, V _a1693, V _a1694, V[] _rest1690) => {
return ((Ge(((V)(tl_1653)), n_1695) && Lt(((V)(tl_1653)), Add(n_1695, ((V)(700D))))) ? V.True : V.False);
}, 1, "", true));
if (!nb_1688.IsNullish) {
OpSetK(E_1661, ((V)(1D)), 0, ((V)((3D * System.Math.Abs(FdLibm.Sin(((tl_1653 - ToNum(nb_1688)) / 115D)))))));
}
} else {
if (string.Equals(mode_1660.Str, "reel")) {
E_1661 = Arr(Call(lerp_99, V.Undef, GetIdx(Wp_1657, 0D), GetIdx(hang_1673, 0D), fly_1662), Call(lerp_99, V.Undef, GetIdx(Wp_1657, 1D), GetIdx(hang_1673, 1D), fly_1662));
} else {
E_1661 = hang_1673;
}
}
}
h_1674 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"M").V(Call(r2_38, V.Undef, GetIdx(p_1654, 0D))).S(" ").V(Call(r2_38, V.Undef, GetIdx(p_1654, 1D))).S("Q").V(Call(r2_38, V.Undef, GetIdx(cp_1672, 0D))).S(" ").V(Call(r2_38, V.Undef, GetIdx(cp_1672, 1D))).S(" ").V(Call(r2_38, V.Undef, GetIdx(tip_1669, 0D))).S(" ").V(Call(r2_38, V.Undef, GetIdx(tip_1669, 1D))).S("\" stroke=\"#8a5a2c\" stroke-width=\"1.7\" fill=\"none\" stroke-linecap=\"round\"/><path d=\"M").V(Call(r2_38, V.Undef, Add(GetIdx(p_1654, 0D), ((V)((FdLibm.Cos(an_1667) * 30D)))))).S(" ").V(Call(r2_38, V.Undef, Add(GetIdx(p_1654, 1D), ((V)((FdLibm.Sin(an_1667) * 30D)))))).S("L").V(Call(r2_38, V.Undef, GetIdx(tip_1669, 0D))).S(" ").V(Call(r2_38, V.Undef, GetIdx(tip_1669, 1D))).S("\" stroke=\"#b07a42\" stroke-width=\"1\" fill=\"none\" stroke-linecap=\"round\"/>").End());
h_1674.V(Call(ci_43, V.Undef, Call(r2_38, V.Undef, Add(Add(GetIdx(p_1654, 0D), ((V)((FdLibm.Cos(an_1667) * 4D)))), ((V)((nx_1670 * 2.6))))), Call(r2_38, V.Undef, Add(Add(GetIdx(p_1654, 1D), ((V)((FdLibm.Sin(an_1667) * 4D)))), ((V)((ny_1671 * 2.6))))), ((V)(2.2)), ((V)("#c9c9d6")), ((V)("#6a6a80"))));
sag_1675 = (string.Equals(mode_1660.Str, "water") ? 8D : 2D);
h_1674.S("<path d=\"M").V(Call(r2_38, V.Undef, GetIdx(tip_1669, 0D))).S(" ").V(Call(r2_38, V.Undef, GetIdx(tip_1669, 1D))).S("Q").V(Call(r2_38, V.Undef, ((V)((ToNum(Add(GetIdx(tip_1669, 0D), GetIdx(E_1661, 0D))) / 2D))))).S(" ").V(Call(r2_38, V.Undef, ((V)(((ToNum(Add(GetIdx(tip_1669, 1D), GetIdx(E_1661, 1D))) / 2D) + sag_1675))))).S(" ").V(Call(r2_38, V.Undef, GetIdx(E_1661, 0D))).S(" ").V(Call(r2_38, V.Undef, GetIdx(E_1661, 1D))).S("\" stroke=\"#5a6a7a\" stroke-width=\"0.45\" fill=\"none\" opacity=\"0.85\"/>");
if (string.Equals(mode_1660.Str, "water")) {
h_1674.S("<ellipse cx=\"").V(Call(r2_38, V.Undef, GetIdx(E_1661, 0D))).S("\" cy=\"").V(Call(r2_38, V.Undef, Add(GetIdx(Wp_1657, 1D), ((V)(2D))))).S("\" rx=\"").V(Call(r2_38, V.Undef, ((V)((5D + (FdLibm.Sin((ToNum(tt_1650) / 300D)) * 1.5)))))).S("\" ry=\"1.5\" fill=\"none\" stroke=\"#8fd3ff\" stroke-width=\"0.6\" opacity=\"0.9\"/>");
}
if (GtN(cat_1663, 0.02)) {
h_1674.V(Call(G_100, V.Undef, GetIdx(E_1661, 0D), Add(GetIdx(E_1661, 1D), ((V)(5D))), ((V)(((FdLibm.Sin((ToNum(tt_1650) / 110D)) * 18D) + 70D))), ((V)((4D * ToNum(cat_1663)))), IC_1640));
}
if ((!string.Equals(mode_1660.Str, "catch") || LtN(cat_1663, 0.5))) {
h_1674.S("<path d=\"M").V(Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(E_1661, 0D)) - 2.1))))).S(" ").V(Call(r2_38, V.Undef, GetIdx(E_1661, 1D))).S("A2.1 2.1 0 0 1 ").V(Call(r2_38, V.Undef, Add(GetIdx(E_1661, 0D), ((V)(2.1))))).S(" ").V(Call(r2_38, V.Undef, GetIdx(E_1661, 1D))).S("Z\" fill=\"#e8483c\" stroke=\"#b8302a\" stroke-width=\"0.35\"/><path d=\"M").V(Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(E_1661, 0D)) - 2.1))))).S(" ").V(Call(r2_38, V.Undef, GetIdx(E_1661, 1D))).S("A2.1 2.1 0 0 0 ").V(Call(r2_38, V.Undef, Add(GetIdx(E_1661, 0D), ((V)(2.1))))).S(" ").V(Call(r2_38, V.Undef, GetIdx(E_1661, 1D))).S("Z\" fill=\"#ffffff\" stroke=\"#c9c9d6\" stroke-width=\"0.35\"/>");
}
return ((V)(h_1674.Str));
return default;
}, 2, "", true);
return default;
}, 2, "fishProp", false);
sunProp_116 = Fn((V _self1698, int _argc1699, V st_1705, V _a1702, V _a1703, V _a1704, V[] _rest1700) => {
if (_self1698.IsNullish) _self1698 = GlobalV;
return Fn((V _arrowThis1714, int _argc1706, V I_1712, V tt_1713, V _a1710, V _a1711, V[] _rest1707) => {
V P_1715 = default;
V W_1716 = default;
V k_1717 = default;
JsStrBuf h_1718 = null;
V f0_1719 = default;
P_1715 = (Get(I_1712, "lastP") is var _t1720 && Truthy(_t1720) ? _t1720 : NewObj(0).V);
W_1716 = (Get(I_1712, "W") is var _t1721 && Truthy(_t1721) ? _t1721 : NewObj(0).V);
k_1717 = Call(cl_39, V.Undef, (Get(P_1715, "shd") is var _t1722 && Truthy(_t1722) ? _t1722 : ((V)(0D))), ((V)(0D)), ((V)(1D)));
h_1718 = new JsStrBuf("");
f0_1719 = Call(facing_87, V.Undef, I_1712);
if ((GtN(k_1717, 0.02) && GtN(f0_1719, 0.05))) {
V a_1723 = default;
V b_1724 = default;
a_1723 = Get(W_1716, "eyeL");
b_1724 = Get(W_1716, "eyeR");
if (Truthy((Call(okp_95, V.Undef, a_1723) is var _t1725 && Truthy(_t1725) ? _t1725 : Call(okp_95, V.Undef, b_1724)))) {
double mx_1726 = 0;
double my_1727 = 0;
double d_1728 = 0;
double s_1729 = 0;
double dn_1730 = 0;
if (!(Truthy(Call(okp_95, V.Undef, a_1723)))) {
a_1723 = b_1724;
}
if (!(Truthy(Call(okp_95, V.Undef, b_1724)))) {
b_1724 = a_1723;
}
mx_1726 = (ToNum(Add(GetIdx(a_1723, 0D), GetIdx(b_1724, 0D))) / 2D);
my_1727 = (ToNum(Add(GetIdx(a_1723, 1D), GetIdx(b_1724, 1D))) / 2D);
d_1728 = Max(Hypot((ToNum(GetIdx(b_1724, 0D)) - ToNum(GetIdx(a_1723, 0D))), (ToNum(GetIdx(b_1724, 1D)) - ToNum(GetIdx(a_1723, 1D)))), 5D);
s_1729 = (d_1728 / 10D);
dn_1730 = (ToNum(Call(cl_39, V.Undef, (Get(P_1715, "shu") is var _t1731 && Truthy(_t1731) ? _t1731 : ((V)(0D))), ((V)(0D)), ((V)(1D)))) * 2.8);
h_1718.V(Call(G_100, V.Undef, ((V)(mx_1726)), ((V)((my_1727 + (dn_1730 * s_1729)))), ((V)(((FdLibm.Atan2((ToNum(GetIdx(b_1724, 1D)) - ToNum(GetIdx(a_1723, 1D))), (ToNum(GetIdx(b_1724, 0D)) - ToNum(GetIdx(a_1723, 0D)))) * 180D) / System.Math.PI))), ((V)((s_1729 * (0.6 + (0.4 * ToNum(k_1717)))))), SHADES_115, ((V)((ToNum(k_1717) * Min(1D, (ToNum(f0_1719) * 1.3)))))));
}
}
if (Truthy((st_1705 is var _t1732 && !Truthy(_t1732) ? _t1732 : Call(okp_95, V.Undef, Get(W_1716, "pawR"))))) {
double tl_1733 = 0;
V sb_1734 = default;
tl_1733 = (ToNum(tt_1713) % ToNum(Get(st_1705, "loop")));
sb_1734 = Invoke(Get(st_1705, "beats"), "find", Fn((V _arrowThis1742, int _argc1735, V q_1741, V _a1738, V _a1739, V _a1740, V[] _rest1736) => {
return (((SEqS(GetIdx(q_1741, 0D), "sip") && Ge(((V)(tl_1733)), GetIdx(q_1741, 1D))) && Le(((V)(tl_1733)), GetIdx(q_1741, 2D))) ? V.True : V.False);
}, 1, "", true));
if (Truthy(sb_1734)) {
V u_1743 = default;
u_1743 = Call(win_88, V.Undef, ((V)(tl_1733)), GetIdx(sb_1734, 1D), GetIdx(sb_1734, 2D), ((V)(220D)));
if (GtN(u_1743, 0.02)) {
h_1718.V(Call(G_100, V.Undef, GetIdx(Get(W_1716, "pawR"), 0D), ((V)((ToNum(GetIdx(Get(W_1716, "pawR"), 1D)) - 4D))), ((V)(0D)), ((V)((3.8 * ToNum(u_1743)))), Get(ICON_45, "cup"), f0_1719));
}
}
}
return ((V)(h_1718.Str));
return default;
}, 2, "", true);
return default;
}, 1, "sunProp", false);
sunIn_117 = Fn((V _self1744, int _argc1745, V SB_1751, V SN_1752, V P_1753, V _a1750, V[] _rest1746) => {
V t_1754 = default;
V v_1755 = default;
V v2_1756 = default;
if (_self1744.IsNullish) _self1744 = GlobalV;
t_1754 = Call(TL_11, V.Undef, REST_9);
Call(enterMove_21, V.Undef, t_1754, SB_1751, (Get(P_1753, "dn") is var _t1757 && Truthy(_t1757) ? _t1757 : ((V)("hop"))));
v_1755 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, SB_1751), "forEach", Fn((V _arrowThis1765, int _argc1758, V p_1764, V _a1761, V _a1762, V _a1763, V[] _rest1759) => {
return SetK(v_1755, p_1764, GetK(SB_1751, p_1764));
}, 1, "", true));
Invoke(t_1754, "to", ((V)(140D)), v_1755, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1754, "to", ((V)(320D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-14D)))), NewObj(3).Put("armR", ((V)(40D))).Put("shd", ((V)(0D))).Put("smile", ((V)(0.8))).V), ((V)("io"))), "to", ((V)(220D)), NewObj(3).Put("shd", ((V)(1D))).Put("sqz", ((V)(0.5))).Put("smile", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(240D)), NewObj(1).Put("sqz", ((V)(0D))).V), "to", ((V)(900D)), Call(o_10, V.Undef, SN_1752, NewObj(1).Put("shd", ((V)(1D))).V), ((V)("s"))), "to", ((V)(260D)), NewObj(1).Put("sq", Add(Get(SN_1752, "sq"), ((V)(0.05)))).V, ((V)("o")));
v2_1756 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, SN_1752), "forEach", Fn((V _arrowThis1773, int _argc1766, V p_1772, V _a1769, V _a1770, V _a1771, V[] _rest1767) => {
return SetK(v2_1756, p_1772, GetK(SN_1752, p_1772));
}, 1, "", true));
Invoke(t_1754, "to", ((V)(300D)), v2_1756, ((V)("io")));
return Invoke(t_1754, "out", NewObj(2).Put("next", ((V)("sun"))).Put("blend", ((V)(220D))).V);
return default;
}, 3, "sunIn", false);
sunOut_118 = Fn((V _self1774, int _argc1775, V SN_1781, V SB_1782, V P_1783, V _a1780, V[] _rest1776) => {
V t_1784 = default;
V hop_1785 = default;
V st_1786 = default;
if (_self1774.IsNullish) _self1774 = GlobalV;
t_1784 = Call(TL_11, V.Undef, SN_1781);
Invoke(Invoke(Invoke(t_1784, "to", ((V)(550D)), Call(o_10, V.Undef, SB_1782, NewObj(3).Put("shd", ((V)(1D))).Put("shu", ((V)(0D))).Put("close", ((V)(0.2))).V), ((V)("io"))), "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-16D)))), NewObj(1).Put("armR", ((V)(44D))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("shd", ((V)(0D))).Put("wide", ((V)(0.4))).V, ((V)("o")));
Invoke(Invoke(t_1784, "to", ((V)(600D)), NewObj(11).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("hLy", ((V)((-5D)))).Put("hRy", ((V)((-5D)))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("sq", ((V)((ToNum((Get(SB_1782, "sq") is var _t1791 && Truthy(_t1791) ? _t1791 : ((V)(0D)))) - 0.08)))).Put("close", ((V)(0.9))).Put("open", ((V)(0.6))).Put("pitch", Add((Get(SB_1782, "pitch") is var _t1792 && Truthy(_t1792) ? _t1792 : ((V)(0D))), ((V)(0.3)))).Put("wide", ((V)(0D))).V, ((V)("io"))), "to", ((V)(420D)), NewObj(11).Put("armL", (Get(SB_1782, "armL") is var _t1787 && Truthy(_t1787) ? _t1787 : ((V)(0D)))).Put("armR", (Get(SB_1782, "armR") is var _t1788 && Truthy(_t1788) ? _t1788 : ((V)(0D)))).Put("hLy", Get(SB_1782, "hLy")).Put("hRy", Get(SB_1782, "hRy")).Put("hLx", Get(SB_1782, "hLx")).Put("hRx", Get(SB_1782, "hRx")).Put("sq", (Get(SB_1782, "sq") is var _t1789 && Truthy(_t1789) ? _t1789 : ((V)(0D)))).Put("close", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", (Get(SB_1782, "pitch") is var _t1790 && Truthy(_t1790) ? _t1790 : ((V)(0D)))).Put("smile", ((V)(1D))).V, ((V)("io")));
hop_1785 = Get(t_1784, "t");
Call(exitMove_22, V.Undef, t_1784, SB_1782, (Get(P_1783, "up") is var _t1793 && Truthy(_t1793) ? _t1793 : ((V)("hop"))));
Invoke(t_1784, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
st_1786 = Invoke(t_1784, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V);
Set(st_1786, "hop", hop_1785);
return st_1786;
return default;
}, 3, "sunOut", false);
slideMove_119 = Fn((V _self1794, int _argc1795, V P_1801, V X_1802, V _a1799, V _a1800, V[] _rest1796) => {
V t_1803 = default;
V w0_1804 = default;
V st_1805 = default;
if (_self1794.IsNullish) _self1794 = GlobalV;
t_1803 = Call(TL_11, V.Undef, REST_9);
{
double i_1806 = 0;
i_1806 = 0D;
while (true) {
if (!((i_1806 < 4D))) break;
double s_1808 = 0;
s_1808 = (NumTruthy((i_1806 % 2D)) ? (-1D) : 1D);
Invoke(t_1803, "to", ((V)(230D)), NewObj(8).Put("footL", ((V)(((s_1808 > 0D) ? 3D : 0D)))).Put("footR", ((V)(((s_1808 > 0D) ? 0D : 3D)))).Put("lift", ((V)((1.5 + (i_1806 * 3.4))))).Put("tilt", ((V)((s_1808 * 2D)))).Put("armL", ((V)(((s_1808 > 0D) ? 64D : 22D)))).Put("armR", ((V)(((s_1808 > 0D) ? 22D : 64D)))).Put("pitch", ((V)(0.12))).Put("ly", ((V)((-0.4)))).V, ((V)("io")));
i_1806++;
}
}
Invoke(t_1803, "to", ((V)(260D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(6D)), ((V)(3D))), NewObj(10).Put("sit", ((V)(1D))).Put("sq", ((V)(0.1))).Put("lift", ((V)(13.5))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).V), ((V)("io")));
Invoke(Invoke(Invoke(t_1803, "to", ((V)(320D)), NewObj(5).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.9))).Put("wide", ((V)(0.7))).Put("open", ((V)(0.25))).Put("mw", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(420D))), "e", ((V)("blink")));
Invoke(t_1803, "to", ((V)(260D)), Call(o_10, V.Undef, NewObj(13).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("hLx", ((V)((-6D)))).Put("hRx", ((V)(6D))).Put("hLy", ((V)((-6D)))).Put("hRy", ((V)((-6D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.8))).Put("pitch", ((V)(0.12))).Put("ly", ((V)((-0.3)))).Put("wide", ((V)(0.5))).V, Get(X_1802, "cheer")), ((V)("o")));
if (Truthy(Get(X_1802, "cheerFx"))) {
InvokeSpread(t_1803, "fx", new ArrBuilder().Spread(Get(X_1802, "cheerFx")).V);
} else {
Invoke(t_1803, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
}
w0_1804 = Get(t_1803, "t");
Invoke(t_1803, "to", ((V)(720D)), NewObj(9).Put("lift", ((V)(0.6))).Put("x", ((V)(5D))).Put("lean", ((V)((-1.6)))).Put("pitch", ((V)(0.28))).Put("earL", ((V)(16D))).Put("earR", ((V)((-16D)))).Put("footL", ((V)(3.4))).Put("footR", ((V)(3.4))).Put("sq", ((V)(0.04))).V, ((V)("i")));
Invoke(Invoke(t_1803, "to", ((V)(140D)), NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.16))).Put("x", ((V)(6D))).Put("lean", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("dust")), ((V)("belly")), ((V)(4D)));
Invoke(Invoke(t_1803, "to", ((V)(220D)), NewObj(10).Put("sit", ((V)(0D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(3.2))).Put("armL", ((V)(110D))).Put("armR", ((V)(110D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i")));
Invoke(Invoke(t_1803, "to", ((V)(260D)), NewObj(12).Put("sqz", ((V)(0.8))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("wide", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(4D)), NewObj(1).Put("sq", ((V)(0.03))).V, NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o")));
Invoke(t_1803, "back", ((V)(500D)));
st_1805 = Invoke(t_1803, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(180D))).V);
Set(st_1805, "whee", w0_1804);
return st_1805;
return default;
}, 2, "slideMove", false);
bounceIn_122 = Fn((V _self1809, int _argc1810, V TB_1816, V P_1817, V _a1814, V _a1815, V[] _rest1811) => {
V t_1818 = default;
V v_1819 = default;
if (_self1809.IsNullish) _self1809 = GlobalV;
t_1818 = Call(TL_11, V.Undef, REST_9);
Call(enterMove_21, V.Undef, t_1818, TB_1816, ((V)((SEqS(Get(P_1817, "dn"), "float") ? "float" : "hop"))));
v_1819 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, TB_1816), "forEach", Fn((V _arrowThis1827, int _argc1820, V p_1826, V _a1823, V _a1824, V _a1825, V[] _rest1821) => {
return SetK(v_1819, p_1826, GetK(TB_1816, p_1826));
}, 1, "", true));
Invoke(t_1818, "to", ((V)(160D)), v_1819, ((V)("io")));
{
double i_1828 = 0;
i_1828 = 0D;
while (true) {
if (!((i_1828 < 2D))) break;
Invoke(Invoke(Invoke(t_1818, "to", ((V)(110D)), NewObj(2).Put("sq", ((V)(0.1))).Put("lift", ((V)((-1D)))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)((-0.05)))).Put("lift", ((V)(5D))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("armL", Get(TB_1816, "armL")).Put("armR", Get(TB_1816, "armR")).V, ((V)("i")));
i_1828++;
}
}
return Invoke(t_1818, "out", NewObj(2).Put("next", ((V)("bounce"))).Put("blend", ((V)(200D))).V);
return default;
}, 2, "bounceIn", false);
bounceOut_123 = Fn((V _self1830, int _argc1831, V TB_1837, V P_1838, V _a1835, V _a1836, V[] _rest1832) => {
V t_1839 = default;
V hop_1840 = default;
V st_1841 = default;
if (_self1830.IsNullish) _self1830 = GlobalV;
t_1839 = Call(TL_11, V.Undef, TB_1837);
Invoke(Invoke(Invoke(Invoke(t_1839, "to", ((V)(130D)), NewObj(2).Put("sq", ((V)(0.15))).Put("lift", ((V)((-1.4)))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(12D))).Put("armL", ((V)(110D))).Put("armR", ((V)(110D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0.1))).Put("lift", ((V)(0D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o")));
hop_1840 = Get(t_1839, "t");
Call(exitMove_22, V.Undef, t_1839, TB_1837, ((V)((SEqS(Get(P_1838, "up"), "float") ? "float" : "hop"))));
Invoke(Invoke(t_1839, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("o")));
st_1841 = Invoke(t_1839, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(200D))).V);
Set(st_1841, "hop", hop_1840);
return st_1841;
return default;
}, 2, "bounceOut", false);
digProp_130 = Fn((V _self1842, int _argc1843, V st_1849, V _a1846, V _a1847, V _a1848, V[] _rest1844) => {
V R0_1850 = default;
double K_1851 = 0;
if (_self1842.IsNullish) _self1842 = GlobalV;
R0_1850 = Get(st_1849, "rec");
K_1851 = 2D;
return Fn((V _arrowThis1860, int _argc1852, V I_1858, V tt_1859, V _a1856, V _a1857, V[] _rest1853) => {
V W_1861 = default;
double tl_1862 = 0;
V gx_1863 = default;
V gy_1864 = default;
V cx_1865 = default;
V cy_1866 = default;
V f0_1867 = default;
double pile_1868 = 0;
double tw_1869 = 0;
double fl_1870 = 0;
V sl_1871 = default;
double pk_1872 = 0;
double ph_1873 = 0;
JsStrBuf c_1874 = null;
V tower_1875 = default;
double th_1876 = 0;
V h_1877 = default;
V B0_1878 = default;
V cur_1879 = default;
double PK_1880 = 0;
W_1861 = Get(I_1858, "W");
if ((!(Truthy(W_1861)) || !(Truthy(Call(okp_95, V.Undef, Get(W_1861, "pawR")))))) {
return ((V)(""));
}
tl_1862 = (ToNum(tt_1859) % ToNum(Get(st_1849, "loop")));
{ V _t1881 = Call(gnd_96, V.Undef, I_1858);
{ V _t1882 = ListOf(_t1881);
{ V _t1883 = GetIdx(_t1882, 0D);
gx_1863 = _t1883; }
{ V _t1884 = GetIdx(_t1882, 1D);
gy_1864 = _t1884; }
} }
cx_1865 = Add(gx_1863, ((V)(2D)));
cy_1866 = Add(gy_1864, ((V)(5D)));
f0_1867 = Call(facing_87, V.Undef, I_1858);
pile_1868 = 0D;
tw_1869 = 0D;
fl_1870 = 0D;
sl_1871 = ((V)(0D));
{
foreach (V _k1885 in new JsIter(Get(st_1849, "beats"))) {
V n_1886 = default;
V a_1887 = default;
V b_1888 = default;
{ V _t1889 = ListOf(_k1885);
{ V _t1890 = GetIdx(_t1889, 0D);
n_1886 = _t1890; }
{ V _t1891 = GetIdx(_t1889, 1D);
a_1887 = _t1891; }
{ V _t1892 = GetIdx(_t1889, 2D);
b_1888 = _t1892; }
}
V u_1893 = default;
if (Lt(((V)(tl_1862)), a_1887)) {
break;
}
u_1893 = Call(cl_39, V.Undef, ((V)(((tl_1862 - ToNum(a_1887)) / Max(1D, (ToNum(b_1888) - ToNum(a_1887)))))), ((V)(0D)), ((V)(1D)));
if (SEqS(n_1886, "scoop")) {
pile_1868 = Max(pile_1868, (0.25 + (0.3 * ToNum(u_1893))));
} else {
if (SEqS(n_1886, "pile")) {
pile_1868 = Max(pile_1868, (0.55 + (0.45 * ToNum(u_1893))));
} else {
if (SEqS(n_1886, "crumble")) {
sl_1871 = Call(ss_25, V.Undef, ((V)((((tl_1862 - ToNum(a_1887)) - 120D) / 700D))));
}
}
}
}
}
Invoke((Get(R0_1850, "bk") is var _t1902 && Truthy(_t1902) ? _t1902 : Arr()), "forEach", Fn((V _arrowThis1901, int _argc1894, V q_1900, V _a1897, V _a1898, V _a1899, V[] _rest1895) => {
if (Ge(((V)(tl_1862)), GetIdx(q_1900, 2D))) {
tw_1869++;
}
return default;
}, 1, "", true));
Invoke((Get(R0_1850, "flag") is var _t1911 && Truthy(_t1911) ? _t1911 : Arr()), "forEach", Fn((V _arrowThis1910, int _argc1903, V q_1909, V _a1906, V _a1907, V _a1908, V[] _rest1904) => {
if (Ge(((V)(tl_1862)), q_1909)) {
fl_1870 = 1D;
}
return default;
}, 1, "", true));
pk_1872 = (pile_1868 * (1D + (ToNum(sl_1871) * 0.25)));
ph_1873 = ((3.6 * pile_1868) * (1D - (ToNum(sl_1871) * 0.4)));
c_1874 = new JsStrBuf("");
if ((pile_1868 > 0.02)) {
c_1874.S("<ellipse cx=\"0\" cy=\"0\" rx=\"").V(Call(r2_38, V.Undef, ((V)((10D * pk_1872))))).S("\" ry=\"").V(Call(r2_38, V.Undef, ((V)(Max(0.6, ph_1873))))).S("\" fill=\"").V(SAND_125).S("\" stroke=\"").V(SANDK_126).S("\" stroke-width=\"0.35\"/><ellipse cx=\"").V(Call(r2_38, V.Undef, ((V)(((-2.4) * pk_1872))))).S("\" cy=\"").V(Call(r2_38, V.Undef, ((V)(((-ph_1873) * 0.45))))).S("\" rx=\"").V(Call(r2_38, V.Undef, ((V)((4D * pk_1872))))).S("\" ry=\"").V(Call(r2_38, V.Undef, ((V)(Max(0.3, (ph_1873 * 0.35)))))).S("\" fill=\"").V(SANDL_127).S("\" opacity=\"0.7\"/>").V(Invoke(Invoke(Arr(Arr(((V)((-6D))), ((V)(0.4))), Arr(((V)(4D)), ((V)((-0.6)))), Arr(((V)(7D)), ((V)(0.8)))), "map", Fn((V _arrowThis1923, int _argc1912, V _a1914, V _a1915, V _a1916, V _a1917, V[] _rest1913) => {
V x_1920 = default;
V y_1922 = default;
{ V _t1918 = ListOf(_a1914);
{ V _t1919 = GetIdx(_t1918, 0D);
x_1920 = _t1919; }
{ V _t1921 = GetIdx(_t1918, 1D);
y_1922 = _t1921; }
}
return Call(ci_43, V.Undef, Call(r2_38, V.Undef, ((V)((ToNum(x_1920) * pk_1872)))), Call(r2_38, V.Undef, ((V)(((ToNum(y_1922) * ph_1873) * 0.4)))), Call(r2_38, V.Undef, ((V)((0.35 * pk_1872)))), SANDK_126);
}, 1, "", true)), "join", ((V)(""))));
}
tower_1875 = Fn((V _arrowThis1932, int _argc1924, V x_1930, V hh_1931, V _a1928, V _a1929, V[] _rest1925) => {
double y0_1933 = 0;
double y1_1934 = 0;
y0_1933 = ((-ph_1873) * 0.6);
y1_1934 = (y0_1933 - ToNum(hh_1931));
if (LtN(hh_1931, 0.4)) {
return ((V)(""));
}
return ((V)(JsStrBuf.Begin().S("<path d=\"M").V(Call(r2_38, V.Undef, ((V)((ToNum(x_1930) - 2.8))))).S(" ").V(Call(r2_38, V.Undef, ((V)(y0_1933)))).S("L").V(Call(r2_38, V.Undef, ((V)((ToNum(x_1930) - 2.4))))).S(" ").V(Call(r2_38, V.Undef, ((V)(y1_1934)))).S("H").V(Call(r2_38, V.Undef, ((V)((ToNum(x_1930) - 1.4))))).S("V").V(Call(r2_38, V.Undef, ((V)((y1_1934 - 1.1))))).S("H").V(Call(r2_38, V.Undef, ((V)((ToNum(x_1930) - 0.5))))).S("V").V(Call(r2_38, V.Undef, ((V)(y1_1934)))).S("H").V(Call(r2_38, V.Undef, Add(x_1930, ((V)(0.5))))).S("V").V(Call(r2_38, V.Undef, ((V)((y1_1934 - 1.1))))).S("H").V(Call(r2_38, V.Undef, Add(x_1930, ((V)(1.4))))).S("V").V(Call(r2_38, V.Undef, ((V)(y1_1934)))).S("H").V(Call(r2_38, V.Undef, Add(x_1930, ((V)(2.4))))).S("L").V(Call(r2_38, V.Undef, Add(x_1930, ((V)(2.8))))).S(" ").V(Call(r2_38, V.Undef, ((V)(y0_1933)))).S("Z\" fill=\"").V(SAND_125).S("\" stroke=\"").V(SANDK_126).S("\" stroke-width=\"0.35\"/><path d=\"M").V(Call(r2_38, V.Undef, Add(x_1930, ((V)(1.2))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_1933 - 0.2))))).S("L").V(Call(r2_38, V.Undef, Add(x_1930, ((V)(1.2))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y1_1934 + 0.4))))).S("H").V(Call(r2_38, V.Undef, Add(x_1930, ((V)(2.3))))).S("L").V(Call(r2_38, V.Undef, Add(x_1930, ((V)(2.7))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_1933 - 0.2))))).S("Z\" fill=\"").V(SANDK_126).S("\" opacity=\"0.35\"/><path d=\"M").V(Call(r2_38, V.Undef, ((V)((ToNum(x_1930) - 0.7))))).S(" ").V(Call(r2_38, V.Undef, ((V)((y0_1933 - (ToNum(hh_1931) * 0.35)))))).S("h1.4v-1.6a0.7 0.7 0 0 0-1.4 0Z\" fill=\"").V(SANDK_126).S("\" opacity=\"0.6\"/>").End()));
return default;
}, 2, "", true);
th_1876 = (6.5 * (1D - ToNum(sl_1871)));
if ((tw_1869 > 0D)) {
c_1874.V(Call(tower_1875, V.Undef, ((V)((-3.2))), ((V)(th_1876))));
}
if ((tw_1869 > 1D)) {
c_1874.V(Call(tower_1875, V.Undef, ((V)(3.4)), ((V)((th_1876 * 0.82)))));
}
if (Truthy((((V)(fl_1870)) is var _t1935 && !Truthy(_t1935) ? _t1935 : (LtN(sl_1871, 0.6) ? V.True : V.False)))) {
double fy0_1936 = 0;
double wv_1937 = 0;
fy0_1936 = ((((-ph_1873) * 0.6) - th_1876) - 1D);
wv_1937 = (FdLibm.Sin((ToNum(tt_1859) / 160D)) * 0.8);
c_1874.S("<g opacity=\"").V(Call(r2_38, V.Undef, ((V)((1D - (ToNum(sl_1871) / 0.6)))))).S("\"><path d=\"M-3.2 ").V(Call(r2_38, V.Undef, ((V)(fy0_1936)))).S("V").V(Call(r2_38, V.Undef, ((V)((fy0_1936 - 6D))))).S("\" stroke=\"#8a5a2c\" stroke-width=\"0.4\"/><path d=\"M-3.2 ").V(Call(r2_38, V.Undef, ((V)((fy0_1936 - 6D))))).S("Q-1.2 ").V(Call(r2_38, V.Undef, ((V)(((fy0_1936 - 5.6) + wv_1937))))).S(" 0.6 ").V(Call(r2_38, V.Undef, ((V)(((fy0_1936 - 4.9) + wv_1937))))).S("L-3.2 ").V(Call(r2_38, V.Undef, ((V)((fy0_1936 - 3.8))))).S("Z\" fill=\"#e8483c\"/></g>");
}
h_1877 = Call(G_100, V.Undef, cx_1865, cy_1866, ((V)(0D)), ((V)(K_1851)), ((V)(c_1874.Str)));
B0_1878 = Arr(Add(Call(rside_97, V.Undef, I_1858, gx_1863), ((V)(6D))), Add(gy_1864, ((V)(2D))));
cur_1879 = Invoke((Get(R0_1850, "bk") is var _t1946 && Truthy(_t1946) ? _t1946 : Arr()), "find", Fn((V _arrowThis1945, int _argc1938, V q_1944, V _a1941, V _a1942, V _a1943, V[] _rest1939) => {
return ((Ge(((V)(tl_1862)), GetIdx(q_1944, 0D)) && Lt(((V)(tl_1862)), GetIdx(q_1944, 3D))) ? V.True : V.False);
}, 1, "", true));
PK_1880 = 2.3;
if (Truthy(cur_1879)) {
V g_1947 = default;
V s_1948 = default;
V l_1949 = default;
V e_1950 = default;
{ V _t1951 = cur_1879;
{ V _t1952 = ListOf(_t1951);
{ V _t1953 = GetIdx(_t1952, 0D);
g_1947 = _t1953; }
{ V _t1954 = GetIdx(_t1952, 1D);
s_1948 = _t1954; }
{ V _t1955 = GetIdx(_t1952, 2D);
l_1949 = _t1955; }
{ V _t1956 = GetIdx(_t1952, 3D);
e_1950 = _t1956; }
} }
if (Lt(((V)(tl_1862)), s_1948)) {
V u_1957 = default;
u_1957 = Call(ss_25, V.Undef, ((V)(((tl_1862 - ToNum(g_1947)) / (ToNum(s_1948) - ToNum(g_1947))))));
h_1877 = Add(h_1877, Call(G_100, V.Undef, GetIdx(Get(W_1861, "pawR"), 0D), Add(GetIdx(Get(W_1861, "pawR"), 1D), ((V)(4D))), ((V)((180D * ToNum(u_1957)))), ((V)(PK_1880)), PAIL_128));
} else {
if (Lt(((V)(tl_1862)), l_1949)) {
h_1877 = Add(h_1877, Call(G_100, V.Undef, Add(cx_1865, ((V)((K_1851 * (NumTruthy(tw_1869) ? 3.4 : (-3.2)))))), ((V)((ToNum(cy_1866) - (K_1851 * ((ph_1873 * 0.6) + 3.4))))), ((V)(180D)), ((V)(PK_1880)), PAIL_128));
} else {
V u_1958 = default;
u_1958 = Call(ss_25, V.Undef, ((V)(((tl_1862 - ToNum(l_1949)) / (ToNum(e_1950) - ToNum(l_1949))))));
h_1877 = Add(h_1877, Call(G_100, V.Undef, GetIdx(Get(W_1861, "pawR"), 0D), Add(GetIdx(Get(W_1861, "pawR"), 1D), ((V)(4D))), ((V)((180D * (1D - ToNum(u_1958))))), ((V)(PK_1880)), PAIL_128));
}
}
} else {
h_1877 = Add(h_1877, Call(G_100, V.Undef, GetIdx(B0_1878, 0D), ((V)((ToNum(GetIdx(B0_1878, 1D)) - 6D))), ((V)(0D)), ((V)(PK_1880)), PAIL_128));
}
if (!(Truthy(cur_1879))) {
h_1877 = Add(h_1877, Call(G_100, V.Undef, GetIdx(Get(W_1861, "pawR"), 0D), GetIdx(Get(W_1861, "pawR"), 1D), ((V)((Truthy(Invoke(Get(st_1849, "beats"), "some", Fn((V _arrowThis1966, int _argc1959, V b_1965, V _a1962, V _a1963, V _a1964, V[] _rest1960) => {
return (((SEqS(GetIdx(b_1965, 0D), "scoop") && Ge(((V)(tl_1862)), GetIdx(b_1965, 1D))) && Le(((V)(tl_1862)), GetIdx(b_1965, 2D))) ? V.True : V.False);
}, 1, "", true))) ? (20D + (FdLibm.Sin((tl_1862 / 130D)) * 26D)) : 18D))), ((V)(2D)), SPADE_129, ((V)(Max(0.3, ToNum(f0_1867))))));
} else {
h_1877 = Add(h_1877, Call(G_100, V.Undef, ((V)((ToNum(gx_1863) - 26D))), Add(gy_1864, ((V)(2D))), ((V)(80D)), ((V)(2D)), SPADE_129));
}
return h_1877;
return default;
}, 2, "", true);
return default;
}, 1, "digProp", false);
blocksProp_135 = Fn((V _self1967, int _argc1968, V st_1974, V _a1971, V _a1972, V _a1973, V[] _rest1969) => {
V R0_1975 = default;
double BS_1976 = 0;
double Z_1977 = 0;
if (_self1967.IsNullish) _self1967 = GlobalV;
R0_1975 = Get(st_1974, "rec");
BS_1976 = 1.45;
Z_1977 = (5.6 * BS_1976);
return Fn((V _arrowThis1986, int _argc1978, V I_1984, V tt_1985, V _a1982, V _a1983, V[] _rest1979) => {
V W_1987 = default;
double tl_1988 = 0;
V gx_1989 = default;
V gy_1990 = default;
V tx_1991 = default;
double ty_1992 = 0;
V PL_1993 = default;
V SC_1994 = default;
V pk_1995 = default;
V pl_1996 = default;
V T0_1997 = default;
V Td_1998 = default;
V TdE_1999 = default;
V Wb_2000 = default;
double rot_2001 = 0;
double cs_2002 = 0;
double sn_2003 = 0;
JsStrBuf h_2004 = null;
W_1987 = Get(I_1984, "W");
if ((!(Truthy(W_1987)) || !(Truthy(Call(okp_95, V.Undef, Get(W_1987, "pawR")))))) {
return ((V)(""));
}
tl_1988 = (ToNum(tt_1985) % ToNum(Get(st_1974, "loop")));
{ V _t2005 = Call(gnd_96, V.Undef, I_1984);
{ V _t2006 = ListOf(_t2005);
{ V _t2007 = GetIdx(_t2006, 0D);
gx_1989 = _t2007; }
{ V _t2008 = GetIdx(_t2006, 1D);
gy_1990 = _t2008; }
} }
tx_1991 = Add(Call(rside_97, V.Undef, I_1984, gx_1989), ((V)(10D)));
ty_1992 = (ToNum(gy_1990) - (Z_1977 / 2D));
PL_1993 = Arr(Arr(((V)((ToNum(tx_1991) - 19D))), ((V)((ToNum(gy_1990) - 2D)))), Arr(((V)((ToNum(tx_1991) - 11D))), ((V)((ToNum(gy_1990) - 2D)))), Arr(((V)((ToNum(tx_1991) - 23D))), Add(gy_1990, ((V)(6D)))), Arr(((V)((ToNum(tx_1991) - 15D))), Add(gy_1990, ((V)(6D)))), Arr(((V)((ToNum(tx_1991) - 7D))), Add(gy_1990, ((V)(6D)))));
SC_1994 = Arr(Arr(((V)((ToNum(tx_1991) - 2D))), Add(gy_1990, ((V)(3D))), ((V)(20D))), Arr(Add(tx_1991, ((V)(8D))), Add(gy_1990, ((V)(1D))), ((V)((-35D)))), Arr(((V)((ToNum(tx_1991) - 10D))), Add(gy_1990, ((V)(8D))), ((V)(60D))), Arr(Add(tx_1991, ((V)(15D))), Add(gy_1990, ((V)(6D))), ((V)(15D))), Arr(((V)((ToNum(tx_1991) - 20D))), Add(gy_1990, ((V)(9D))), ((V)((-50D)))));
pk_1995 = (Get(R0_1975, "pick") is var _t2009 && Truthy(_t2009) ? _t2009 : Arr());
pl_1996 = (Get(R0_1975, "place") is var _t2010 && Truthy(_t2010) ? _t2010 : Arr());
T0_1997 = GetIdx((Get(R0_1975, "top") is var _t2011 && Truthy(_t2011) ? _t2011 : Arr()), 0D);
Td_1998 = GetIdx((Get(R0_1975, "tidy") is var _t2012 && Truthy(_t2012) ? _t2012 : Arr()), 0D);
TdE_1999 = (Get(R0_1975, "tidyE") is var _t2013 && Truthy(_t2013) ? _t2013 : ((V)(0D)));
Wb_2000 = GetIdx((Get(R0_1975, "wob") is var _t2014 && Truthy(_t2014) ? _t2014 : Arr()), 0D);
rot_2001 = 0D;
if (((!Wb_2000.IsNullish && Gt(((V)(tl_1988)), Wb_2000)) && Lt(((V)(tl_1988)), Add(Wb_2000, ((V)(1500D)))))) {
rot_2001 = ((7D * FdLibm.Sin(((tl_1988 - ToNum(Wb_2000)) / 110D))) * (1D - ((tl_1988 - ToNum(Wb_2000)) / 1500D)));
}
if (((!T0_1997.IsNullish && Gt(((V)(tl_1988)), T0_1997)) && Lt(((V)(tl_1988)), Add(T0_1997, ((V)(260D)))))) {
rot_2001 = (14D * ToNum(Call(ss_25, V.Undef, ((V)(((tl_1988 - ToNum(T0_1997)) / 260D))))));
}
cs_2002 = FdLibm.Cos(((rot_2001 * System.Math.PI) / 180D));
sn_2003 = FdLibm.Sin(((rot_2001 * System.Math.PI) / 180D));
h_2004 = new JsStrBuf("");
{
double i_2015 = 0;
i_2015 = 0D;
while (true) {
if (!((i_2015 < 5D))) break;
V x_2017 = default;
V y_2018 = default;
V r_2019 = default;
V slot_2020 = default;
V tow_2021 = default;
x_2017 = V.Undef;
y_2018 = V.Undef;
r_2019 = ((V)(0D));
slot_2020 = Arr(tx_1991, ((V)((ty_1992 - (i_2015 * Z_1977)))));
tow_2021 = Fn((V _arrowThis2028, int _argc2022, V _a2024, V _a2025, V _a2026, V _a2027, V[] _rest2023) => {
double dy_2029 = 0;
dy_2029 = (ToNum(GetIdx(slot_2020, 1D)) - ToNum(gy_1990));
return Arr(((V)((ToNum(tx_1991) - (dy_2029 * sn_2003)))), Add(gy_1990, ((V)((dy_2029 * cs_2002)))), ((V)(rot_2001)));
return default;
}, 0, "", true);
if (((!T0_1997.IsNullish && Ge(((V)(tl_1988)), Add(T0_1997, ((V)(260D))))) && (Td_1998.IsNullish || Lt(((V)(tl_1988)), Td_1998)))) {
V u_2030 = default;
V q_2031 = default;
u_2030 = Call(ss_25, V.Undef, ((V)((((tl_1988 - ToNum(T0_1997)) - 260D) / 520D))));
q_2031 = Call(tow_2021, V.Undef);
x_2017 = Call(lerp_99, V.Undef, GetIdx(q_2031, 0D), GetIdx(GetIdx(SC_1994, i_2015), 0D), u_2030);
y_2018 = ((V)((ToNum(Call(lerp_99, V.Undef, GetIdx(q_2031, 1D), GetIdx(GetIdx(SC_1994, i_2015), 1D), u_2030)) - (FdLibm.Sin((System.Math.PI * ToNum(u_2030))) * (6D + (i_2015 * 2.5))))));
r_2019 = Call(lerp_99, V.Undef, GetIdx(q_2031, 2D), GetIdx(GetIdx(SC_1994, i_2015), 2D), u_2030);
} else {
if ((!Td_1998.IsNullish && Ge(((V)(tl_1988)), Td_1998))) {
V u_2032 = default;
u_2032 = Call(ss_25, V.Undef, ((V)(((tl_1988 - ToNum(Td_1998)) / Max(1D, (ToNum(TdE_1999) - ToNum(Td_1998)))))));
x_2017 = Call(lerp_99, V.Undef, GetIdx(GetIdx(SC_1994, i_2015), 0D), GetIdx(GetIdx(PL_1993, i_2015), 0D), u_2032);
y_2018 = ((V)((ToNum(Call(lerp_99, V.Undef, GetIdx(GetIdx(SC_1994, i_2015), 1D), GetIdx(GetIdx(PL_1993, i_2015), 1D), u_2032)) - (FdLibm.Sin((System.Math.PI * ToNum(u_2032))) * 3D))));
r_2019 = Call(lerp_99, V.Undef, GetIdx(GetIdx(SC_1994, i_2015), 2D), ((V)(0D)), u_2032);
} else {
if ((!GetIdx(pl_1996, i_2015).IsNullish && Ge(((V)(tl_1988)), GetIdx(pl_1996, i_2015)))) {
{ V _t2033 = Call(tow_2021, V.Undef);
{ V _t2034 = ListOf(_t2033);
{ V _t2035 = GetIdx(_t2034, 0D);
x_2017 = _t2035; }
{ V _t2036 = GetIdx(_t2034, 1D);
y_2018 = _t2036; }
{ V _t2037 = GetIdx(_t2034, 2D);
r_2019 = _t2037; }
} }
} else {
if ((!GetIdx(pk_1995, i_2015).IsNullish && Ge(((V)(tl_1988)), GetIdx(pk_1995, i_2015)))) {
V pw_2038 = default;
V u_2039 = default;
pw_2038 = Arr(GetIdx(Get(W_1987, "pawR"), 0D), ((V)((ToNum(GetIdx(Get(W_1987, "pawR"), 1D)) - 4D))));
u_2039 = Call(ss_25, V.Undef, ((V)(((tl_1988 - (ToNum(GetIdx(pl_1996, i_2015)) - 320D)) / 320D))));
x_2017 = Call(lerp_99, V.Undef, GetIdx(pw_2038, 0D), GetIdx(slot_2020, 0D), u_2039);
y_2018 = Call(lerp_99, V.Undef, GetIdx(pw_2038, 1D), GetIdx(slot_2020, 1D), u_2039);
} else {
x_2017 = GetIdx(GetIdx(PL_1993, i_2015), 0D);
y_2018 = GetIdx(GetIdx(PL_1993, i_2015), 1D);
}
}
}
}
h_2004.V(Call(G_100, V.Undef, x_2017, y_2018, r_2019, ((V)(BS_1976)), Call(BLK_133, V.Undef, ((V)(i_2015)))));
i_2015++;
}
}
return ((V)(h_2004.Str));
return default;
}, 2, "", true);
return default;
}, 1, "blocksProp", false);
waterMove_137 = Fn((V _self2040, int _argc2041, V X_2047, V _a2044, V _a2045, V _a2046, V[] _rest2042) => {
V t_2048 = default;
V a_2049 = default;
V p0_2050 = default;
V p1_2051 = default;
V b_2052 = default;
V st_2053 = default;
V e_2054 = default;
if (_self2040.IsNullish) _self2040 = GlobalV;
t_2048 = Call(TL_11, V.Undef, REST_9);
Invoke(t_2048, "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-3D))), ((V)((-1D)))), NewObj(5).Put("armR", ((V)(46D))).Put("lx", ((V)(0.6))).Put("ly", ((V)(0.5))).Put("pitch", ((V)((-0.08)))).Put("smile", ((V)(0.8))).V), ((V)("io")));
a_2049 = Get(t_2048, "t");
Invoke(t_2048, "to", ((V)(420D)), NewObj(4).Put("armR", ((V)(64D))).Put("hRy", ((V)((-5D)))).Put("tilt", ((V)(3D))).Put("lean", ((V)(0.5))).V, ((V)("io")));
p0_2050 = Get(t_2048, "t");
Invoke(t_2048, "osc", ((V)(1800D)), ((V)(4D)), NewObj(2).Put("hRy", ((V)((-4D)))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("hRy", ((V)((-6D)))).Put("htilt", ((V)((-3D)))).V, ((V)("s")));
p1_2051 = Get(t_2048, "t");
Invoke(t_2048, "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(4D)), ((V)(2D))), NewObj(3).Put("armR", ((V)(18D))).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).V), ((V)("io")));
b_2052 = Get(t_2048, "t");
Invoke(t_2048, "to", ((V)(320D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(10D)), ((V)((-7D)))), NewObj(7).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("htilt", ((V)(6D))).Put("ly", ((V)(0.4))).V, Get(X_2047, "cheer")), ((V)("o")));
if (Truthy(Get(X_2047, "cheerFx"))) {
InvokeSpread(t_2048, "fx", new ArrBuilder().Spread(Get(X_2047, "cheerFx")).V);
}
Invoke(Invoke(Invoke(Invoke(t_2048, "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "wait", ((V)(900D))), "to", ((V)(300D)), NewObj(2).Put("sqz", ((V)(0D))).Put("close", ((V)(0.5))).V), "wait", ((V)(300D)));
Invoke(t_2048, "back", ((V)(420D)));
st_2053 = Invoke(t_2048, "out", NewObj(2).Put("next", ((V)("idle"))).Put("blend", ((V)(180D))).V);
e_2054 = Get(st_2053, "dur");
Set(st_2053, "prop", Fn((V _arrowThis2063, int _argc2055, V I_2061, V tt_2062, V _a2059, V _a2060, V[] _rest2056) => {
V W_2064 = default;
V gx_2065 = default;
V gy_2066 = default;
V sx_2067 = default;
V sy_2068 = default;
V f0_2069 = default;
double CK_2070 = 0;
V h_2071 = default;
V gr_2072 = default;
V bl_2073 = default;
double fade_2074 = 0;
double sh_2075 = 0;
double ang_2076 = 0;
double vis_2077 = 0;
W_2064 = Get(I_2061, "W");
if ((!(Truthy(W_2064)) || !(Truthy(Call(okp_95, V.Undef, Get(W_2064, "pawR")))))) {
return ((V)(""));
}
{ V _t2078 = Call(gnd_96, V.Undef, I_2061);
{ V _t2079 = ListOf(_t2078);
{ V _t2080 = GetIdx(_t2079, 0D);
gx_2065 = _t2080; }
{ V _t2081 = GetIdx(_t2079, 1D);
gy_2066 = _t2081; }
} }
sx_2067 = Add(Call(rside_97, V.Undef, I_2061, gx_2065), ((V)(10D)));
sy_2068 = Add(gy_2066, ((V)(1D)));
f0_2069 = Call(facing_87, V.Undef, I_2061);
CK_2070 = 1.9;
h_2071 = ((V)(""));
gr_2072 = Call(ss_25, V.Undef, ((V)(((ToNum(tt_2062) - ToNum(p0_2050)) / (ToNum(p1_2051) - ToNum(p0_2050))))));
bl_2073 = Call(ss_25, V.Undef, ((V)((((ToNum(tt_2062) - ToNum(b_2052)) - 200D) / 500D))));
fade_2074 = (1D - ToNum(Call(ss_25, V.Undef, ((V)((((ToNum(tt_2062) - ToNum(e_2054)) + 500D) / 500D))))));
sh_2075 = ((3D + (13D * ToNum(gr_2072))) * fade_2074);
if ((sh_2075 > 0.3)) {
double lf_2082 = 0;
lf_2082 = ((0.4 + (ToNum(gr_2072) * 0.8)) * fade_2074);
h_2071 = ((V)(JsStrBuf.Begin().V(h_2071).S("<path d=\"M").V(Call(r2_38, V.Undef, sx_2067)).S(" ").V(Call(r2_38, V.Undef, sy_2068)).S("Q").V(Call(r2_38, V.Undef, ((V)((ToNum(sx_2067) - 0.8))))).S(" ").V(Call(r2_38, V.Undef, ((V)((ToNum(sy_2068) - (sh_2075 * 0.5)))))).S(" ").V(Call(r2_38, V.Undef, sx_2067)).S(" ").V(Call(r2_38, V.Undef, ((V)((ToNum(sy_2068) - sh_2075))))).S("\" stroke=\"#4f8f3a\" stroke-width=\"1.3\" fill=\"none\"/>").V(Call(G_100, V.Undef, sx_2067, ((V)((ToNum(sy_2068) - (sh_2075 * 0.55)))), ((V)(((-30D) + (FdLibm.Sin((ToNum(tt_2062) / 400D)) * 6D)))), ((V)((lf_2082 * 1.8))), ((V)("<path d=\"M0 0Q-4-0.6-5-3Q-1.6-3.2 0 0Z\" fill=\"#7cc35a\" stroke=\"#4f8f3a\" stroke-width=\"0.35\"/>")))).V(Call(G_100, V.Undef, sx_2067, ((V)((ToNum(sy_2068) - (sh_2075 * 0.75)))), ((V)((20D - (FdLibm.Sin((ToNum(tt_2062) / 400D)) * 6D)))), ((V)((lf_2082 * 1.8))), ((V)("<path d=\"M0 0Q4-0.6 5-3Q1.6-3.2 0 0Z\" fill=\"#8fd06a\" stroke=\"#4f8f3a\" stroke-width=\"0.35\"/>")))).End()));
if (GtN(bl_2073, 0.02)) {
h_2071 = Add(h_2071, Call(G_100, V.Undef, sx_2067, ((V)((ToNum(sy_2068) - sh_2075))), ((V)(0D)), ((V)((ToNum(bl_2073) * fade_2074))), Get(ICON_45, "flower")));
}
h_2071 = ((V)(JsStrBuf.Begin().V(h_2071).S("<ellipse cx=\"").V(Call(r2_38, V.Undef, sx_2067)).S("\" cy=\"").V(Call(r2_38, V.Undef, Add(sy_2068, ((V)(0.4))))).S("\" rx=\"6\" ry=\"1.6\" fill=\"#8a6a4a\" opacity=\"").V(Call(r2_38, V.Undef, ((V)((0.5 * fade_2074))))).S("\"/>").End()));
}
ang_2076 = (Lt(tt_2062, a_2049) ? 0D : (Lt(tt_2062, p0_2050) ? (45D * ToNum(Call(ss_25, V.Undef, ((V)(((ToNum(tt_2062) - ToNum(a_2049)) / (ToNum(p0_2050) - ToNum(a_2049)))))))) : (Lt(tt_2062, p1_2051) ? (45D + (FdLibm.Sin((ToNum(tt_2062) / 200D)) * 5D)) : (45D * (1D - ToNum(Call(ss_25, V.Undef, ((V)(((ToNum(tt_2062) - ToNum(p1_2051)) / (ToNum(b_2052) - ToNum(p1_2051))))))))))));
vis_2077 = (1D - ToNum(Call(ss_25, V.Undef, ((V)(((ToNum(tt_2062) - ToNum(b_2052)) / 300D))))));
if ((vis_2077 > 0.02)) {
V p_2083 = default;
double an_2084 = 0;
double lx_2085 = 0;
double ly_2086 = 0;
V sp_2087 = default;
p_2083 = Get(W_2064, "pawR");
an_2084 = ((ang_2076 * System.Math.PI) / 180D);
lx_2085 = (12.4 * CK_2070);
ly_2086 = ((-1.2) * CK_2070);
sp_2087 = Arr(((V)((ToNum(Add(GetIdx(p_2083, 0D), ((V)((lx_2085 * FdLibm.Cos(an_2084)))))) - (ly_2086 * FdLibm.Sin(an_2084))))), Add(Add(Add(GetIdx(p_2083, 1D), ((V)(2D))), ((V)((lx_2085 * FdLibm.Sin(an_2084))))), ((V)((ly_2086 * FdLibm.Cos(an_2084))))));
if ((GtN(tt_2062, (ToNum(p0_2050) - 80D)) && Lt(tt_2062, Add(p1_2051, ((V)(80D)))))) {
{
double i_2088 = 0;
i_2088 = 0D;
while (true) {
if (!((i_2088 < 7D))) break;
double u_2090 = 0;
V x_2091 = default;
double y_2092 = 0;
u_2090 = (((ToNum(tt_2062) / 260D) + (i_2088 / 7D)) % 1D);
x_2091 = Call(lerp_99, V.Undef, GetIdx(sp_2087, 0D), sx_2067, ((V)(u_2090)));
y_2092 = ((ToNum(Call(lerp_99, V.Undef, GetIdx(sp_2087, 1D), ((V)((ToNum(sy_2068) - sh_2075))), ((V)(u_2090)))) - (FdLibm.Sin((System.Math.PI * u_2090)) * 2.6)) + ((u_2090 * u_2090) * 2D));
h_2071 = ((V)(JsStrBuf.Begin().V(h_2071).S("<ellipse cx=\"").V(Call(r2_38, V.Undef, x_2091)).S("\" cy=\"").V(Call(r2_38, V.Undef, ((V)(y_2092)))).S("\" rx=\"0.9\" ry=\"1.3\" fill=\"#8fd3ff\" stroke=\"#5ab4f0\" stroke-width=\"0.2\" opacity=\"0.9\"/>").End()));
i_2088++;
}
}
}
h_2071 = Add(Call(G_100, V.Undef, GetIdx(p_2083, 0D), Add(GetIdx(p_2083, 1D), ((V)(2D))), ((V)(ang_2076)), ((V)(CK_2070)), CAN_136, ((V)((vis_2077 * Max(0.35, ToNum(f0_2069)))))), h_2071);
}
return h_2071;
return default;
}, 2, "", true));
return st_2053;
return default;
}, 1, "waterMove", false);
roastProp_139 = Fn((V _self2093, int _argc2094, V st_2100, V _a2097, V _a2098, V _a2099, V[] _rest2095) => {
if (_self2093.IsNullish) _self2093 = GlobalV;
return Fn((V _arrowThis2109, int _argc2101, V I_2107, V tt_2108, V _a2105, V _a2106, V[] _rest2102) => {
V W_2110 = default;
double tl_2111 = 0;
V p_2112 = default;
V M_2113 = default;
double f0_2114 = 0;
double tst_2115 = 0;
V burnt_2116 = default;
V fire_2117 = default;
double gone_2118 = 0;
V eat_2119 = default;
double smk_2120 = 0;
V nw_2121 = default;
double d_2122 = 0;
double a0_2123 = 0;
double a1_2124 = 0;
V an_2125 = default;
V L_2126 = default;
V tip_2127 = default;
JsStrBuf h_2128 = null;
W_2110 = Get(I_2107, "W");
if ((!(Truthy(W_2110)) || !(Truthy(Call(okp_95, V.Undef, Get(W_2110, "pawR")))))) {
return ((V)(""));
}
tl_2111 = (ToNum(tt_2108) % ToNum(Get(st_2100, "loop")));
p_2112 = Get(W_2110, "pawR");
M_2113 = (Truthy(Call(okp_95, V.Undef, Get(W_2110, "mouth"))) ? Get(W_2110, "mouth") : Arr(((V)((ToNum(GetIdx(p_2112, 0D)) - 8D))), ((V)((ToNum(GetIdx(p_2112, 1D)) - 4D)))));
f0_2114 = Max(0.3, ToNum(Call(facing_87, V.Undef, I_2107)));
tst_2115 = 0D;
burnt_2116 = ((V)(0D));
fire_2117 = ((V)(0D));
gone_2118 = 0D;
eat_2119 = ((V)(0D));
smk_2120 = (-1D);
nw_2121 = ((V)(1D));
{
foreach (V _k2129 in new JsIter(Get(st_2100, "beats"))) {
V n_2130 = default;
V a_2131 = default;
V b_2132 = default;
{ V _t2133 = ListOf(_k2129);
{ V _t2134 = GetIdx(_t2133, 0D);
n_2130 = _t2134; }
{ V _t2135 = GetIdx(_t2133, 1D);
a_2131 = _t2135; }
{ V _t2136 = GetIdx(_t2133, 2D);
b_2132 = _t2136; }
}
V u_2137 = default;
if (Lt(((V)(tl_2111)), a_2131)) {
break;
}
u_2137 = Call(cl_39, V.Undef, ((V)(((tl_2111 - ToNum(a_2131)) / Max(1D, (ToNum(b_2132) - ToNum(a_2131)))))), ((V)(0D)), ((V)(1D)));
if ((SEqS(n_2130, "hold") || SEqS(n_2130, "turn"))) {
tst_2115 = Min(1D, (tst_2115 + (0.5 * ToNum(u_2137))));
} else {
if (SEqS(n_2130, "fire")) {
fire_2117 = Call(ss_25, V.Undef, ((V)((ToNum(u_2137) / 0.15))));
burnt_2116 = u_2137;
} else {
if (SEqS(n_2130, "blow")) {
fire_2117 = ((V)((1D - ToNum(Call(ss_25, V.Undef, ((V)((((tl_2111 - ToNum(a_2131)) - 350D) / 250D))))))));
if (Gt(((V)(tl_2111)), Add(a_2131, ((V)(400D))))) {
smk_2120 = ((tl_2111 - ToNum(a_2131)) - 400D);
}
burnt_2116 = ((V)(1D));
} else {
if (SEqS(n_2130, "eat")) {
eat_2119 = Call(win_88, V.Undef, ((V)(tl_2111)), a_2131, b_2132, ((V)(380D)));
if (GtN(u_2137, 0.3)) {
gone_2118 = 1D;
}
} else {
if (SEqS(n_2130, "new")) {
nw_2121 = Call(ss_25, V.Undef, ((V)(((ToNum(u_2137) - 0.35) / 0.25))));
if (GtN(u_2137, 0.35)) {
tst_2115 = 0D;
burnt_2116 = ((V)(0D));
gone_2118 = 0D;
fire_2117 = ((V)(0D));
smk_2120 = (-1D);
}
}
}
}
}
}
}
}
d_2122 = Hypot((ToNum(GetIdx(M_2113, 0D)) - ToNum(GetIdx(p_2112, 0D))), (ToNum(GetIdx(M_2113, 1D)) - ToNum(GetIdx(p_2112, 1D))));
a0_2123 = (((-22D) * System.Math.PI) / 180D);
a1_2124 = FdLibm.Atan2((ToNum(GetIdx(M_2113, 1D)) - ToNum(GetIdx(p_2112, 1D))), (ToNum(GetIdx(M_2113, 0D)) - ToNum(GetIdx(p_2112, 0D))));
an_2125 = Call(lerp_99, V.Undef, ((V)(a0_2123)), ((V)(a1_2124)), eat_2119);
L_2126 = Call(lerp_99, V.Undef, ((V)(32D)), ((V)(Max(7D, d_2122))), eat_2119);
tip_2127 = Arr(Add(GetIdx(p_2112, 0D), ((V)((FdLibm.Cos(ToNum(an_2125)) * ToNum(L_2126))))), Add(GetIdx(p_2112, 1D), ((V)((FdLibm.Sin(ToNum(an_2125)) * ToNum(L_2126))))));
h_2128 = new JsStrBuf(JsStrBuf.Begin().S("<path d=\"M").V(Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(p_2112, 0D)) - (FdLibm.Cos(ToNum(an_2125)) * 2D)))))).S(" ").V(Call(r2_38, V.Undef, ((V)((ToNum(GetIdx(p_2112, 1D)) - (FdLibm.Sin(ToNum(an_2125)) * 2D)))))).S("L").V(Call(r2_38, V.Undef, GetIdx(tip_2127, 0D))).S(" ").V(Call(r2_38, V.Undef, GetIdx(tip_2127, 1D))).S("\" stroke=\"#9a6a3a\" stroke-width=\"1.4\" stroke-linecap=\"round\" opacity=\"").V(Call(r2_38, V.Undef, ((V)(f0_2114)))).S("\"/>").End());
if (!(NumTruthy(gone_2118))) {
V c0_2138 = default;
V c1_2139 = default;
V c2_2140 = default;
V mix_2141 = default;
V c_2142 = default;
V col_2143 = default;
double k_2144 = 0;
c0_2138 = Arr(((V)(246D)), ((V)(241D)), ((V)(230D)));
c1_2139 = Arr(((V)(224D)), ((V)(162D)), ((V)(74D)));
c2_2140 = Arr(((V)(70D)), ((V)(46D)), ((V)(34D)));
mix_2141 = Fn((V _arrowThis2154, int _argc2145, V x_2151, V y_2152, V u_2153, V _a2150, V[] _rest2146) => {
return Invoke(x_2151, "map", Fn((V _arrowThis2163, int _argc2155, V v_2161, V i_2162, V _a2159, V _a2160, V[] _rest2156) => {
return ((V)(Round(ToNum(Call(lerp_99, V.Undef, v_2161, GetK(y_2152, i_2162), u_2153)))));
}, 2, "", true));
}, 3, "", true);
c_2142 = (GtN(burnt_2116, 0D) ? Call(mix_2141, V.Undef, Call(mix_2141, V.Undef, c0_2138, c1_2139, ((V)(tst_2115))), c2_2140, Call(ss_25, V.Undef, ((V)((ToNum(burnt_2116) / 0.6))))) : Call(mix_2141, V.Undef, c0_2138, c1_2139, ((V)(tst_2115))));
col_2143 = ((V)(JsStrBuf.Begin().S("rgb(").V(Invoke(c_2142, "join", ((V)(",")))).S(")").End()));
k_2144 = ((0.4 + (0.6 * ToNum(nw_2121))) * 1.8);
h_2128.V(Call(G_100, V.Undef, GetIdx(tip_2127, 0D), GetIdx(tip_2127, 1D), ((V)(((ToNum(an_2125) * 180D) / System.Math.PI))), ((V)(k_2144)), ((V)(JsStrBuf.Begin().S("<rect x=\"-0.6\" y=\"-2.2\" width=\"5.2\" height=\"4.4\" rx=\"1.8\" fill=\"").V(col_2143).S("\" stroke=\"").S((GtN(burnt_2116, 0.3) ? "#2a1a10" : "#c9a46a")).S("\" stroke-width=\"0.35\"/><ellipse cx=\"1.4\" cy=\"-1\" rx=\"1.4\" ry=\"0.6\" fill=\"#ffffff\" opacity=\"").V(Call(r2_38, V.Undef, ((V)((0.6 * (1D - ToNum(burnt_2116))))))).S("\"/>").S((GtN(burnt_2116, 0.5) ? "<path d=\"M0.4 1.6Q2 0.4 3.8 1.4\" stroke=\"#ff8a2a\" stroke-width=\"0.4\" fill=\"none\" opacity=\"0.7\"/>" : "")).End())), ((V)(f0_2114))));
if (GtN(fire_2117, 0.02)) {
h_2128.V(Call(G_100, V.Undef, Add(GetIdx(tip_2127, 0D), ((V)(3D))), ((V)((ToNum(GetIdx(tip_2127, 1D)) - 6D))), ((V)((FdLibm.Sin((ToNum(tt_2108) / 80D)) * 6D))), ((V)((ToNum(fire_2117) * (2D + (FdLibm.Sin((ToNum(tt_2108) / 60D)) * 0.15))))), Get(ICON_45, "fire")));
}
if (((smk_2120 >= 0D) && (smk_2120 < 1800D))) {
{
double i_2164 = 0;
i_2164 = 0D;
while (true) {
if (!((i_2164 < 3D))) break;
V u_2166 = default;
u_2166 = Call(cl_39, V.Undef, ((V)(((smk_2120 - (i_2164 * 280D)) / 1300D))), ((V)(0D)), ((V)(1D)));
if ((GtN(u_2166, 0D) && LtN(u_2166, 1D))) {
h_2128.V(Call(ci_43, V.Undef, Call(r2_38, V.Undef, Add(Add(GetIdx(tip_2127, 0D), ((V)(3D))), ((V)((FdLibm.Sin(((ToNum(u_2166) * 5D) + i_2164)) * 2.4))))), Call(r2_38, V.Undef, ((V)(((ToNum(GetIdx(tip_2127, 1D)) - 5D) - (ToNum(u_2166) * 18D))))), Call(r2_38, V.Undef, ((V)((2D + (ToNum(u_2166) * 3.6))))), ((V)(JsStrBuf.Begin().S("rgba(150,150,150,").V(Call(r2_38, V.Undef, ((V)((0.55 * (1D - ToNum(u_2166))))))).S(")").End()))));
}
i_2164++;
}
}
}
}
return ((V)(h_2128.Str));
return default;
}, 2, "", true);
return default;
}, 1, "roastProp", false);
bBuild_141 = Fn((V _self2167, int _argc2168, V key_2174, V X_2175, V _a2172, V _a2173, V[] _rest2169) => {
V P_2176 = default;
V nm_2177 = default;
V S_2178 = default;
V SB_2179 = default;
V BX_2180 = default;
V sig_2181 = default;
V md_2182 = default;
if (_self2167.IsNullish) _self2167 = GlobalV;
X_2175 = Call(o_10, V.Undef, (GetK(WX_29, key_2174) is var _t2183 && Truthy(_t2183) ? _t2183 : NewObj(0).V), (GetK(PLY_93, key_2174) is var _t2184 && Truthy(_t2184) ? _t2184 : NewObj(0).V), (X_2175 is var _t2185 && Truthy(_t2185) ? _t2185 : NewObj(0).V));
P_2176 = (GetK(PROF_35, key_2174) is var _t2186 && Truthy(_t2186) ? _t2186 : NewObj(0).V);
nm_2177 = Fn((V _arrowThis2194, int _argc2187, V n_2193, V _a2190, V _a2191, V _a2192, V[] _rest2188) => {
return (Truthy(key_2174) ? ((V)(JsStrBuf.Begin().V(n_2193).S("@").V(key_2174).End())) : n_2193);
}, 1, "", true);
S_2178 = NewObj(0).V;
SB_2179 = Call(o_10, V.Undef, SIT0_17, (Get(P_2176, "pose") is var _t2195 && Truthy(_t2195) ? _t2195 : NewObj(0).V));
BX_2180 = (GetK(BED_54, key_2174) is var _t2196 && Truthy(_t2196) ? _t2196 : NewObj(0).V);
sig_2181 = ((Get(X_2175, "b") is var _t2197 && Truthy(_t2197) ? _t2197 : Get(X_2175, "p")) is var _t2207 && Truthy(_t2207) ? _t2207 : Invoke((Get(P_2176, "f") is var _t2206 && Truthy(_t2206) ? _t2206 : Arr()), "find", Fn((V _arrowThis2205, int _argc2198, V f_2204, V _a2201, V _a2202, V _a2203, V[] _rest2199) => {
return (string.Equals(Typeof(f_2204), "function") ? V.True : V.False);
}, 1, "", true)));
md_2182 = ((V)((Truthy(GetK(LAP_27, key_2174)) ? "lap" : (Truthy(GetK(TWO_26, key_2174)) ? "two" : ""))));
Set(X_2175, "_dm", md_2182);
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("sinkwash"))), Call(bHold_101, V.Undef, Call(o_10, V.Undef, SK0_102, (Get(X_2175, "skp") is var _t2208 && Truthy(_t2208) ? _t2208 : NewObj(0).V)), (Get(X_2175, "skOrd") is var _t2209 && Truthy(_t2209) ? _t2209 : Arr(((V)("scrub")), ((V)("rinse")), ((V)("splash")), ((V)("sig")), ((V)("shake")), ((V)("mirror")), ((V)("scrub")), ((V)("dry")))), SKB_103, X_2175, sig_2181, Arr(((V)(400D)), ((V)(600D)), ((V)(500D)), ((V)(700D)))));
{
V st_2210 = default;
st_2210 = Call(bHold_101, V.Undef, Call(o_10, V.Undef, BR0_104, (Get(X_2175, "brp") is var _t2211 && Truthy(_t2211) ? _t2211 : NewObj(0).V)), (Get(X_2175, "brOrd") is var _t2212 && Truthy(_t2212) ? _t2212 : Arr(((V)("brush")), ((V)("side")), ((V)("brush")), ((V)("gargle")), ((V)("spit")), ((V)("grin")), ((V)("sig")))), BRB_105, X_2175, sig_2181, Arr(((V)(300D)), ((V)(500D)), ((V)(400D)), ((V)(600D))));
Set(st_2210, "prop", Call(brushProp_106, V.Undef, st_2210, (Get(X_2175, "tb") is var _t2213 && Truthy(_t2213) ? _t2213 : ((V)("#5fb8e8")))));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("brush"))), st_2210);
}
{
V DN_2214 = default;
V st_2215 = default;
V di_2216 = default;
DN_2214 = Call(o_10, V.Undef, SB_2179, Call(both_13, V.Undef, ((V)(8D)), ((V)((-3D)))), NewObj(6).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("pitch", ((V)((ToNum((Get(SB_2179, "pitch") is var _t2217 && Truthy(_t2217) ? _t2217 : ((V)(0D)))) - 0.06)))).Put("ly", ((V)(0.5))).Put("smile", ((V)(0.6))).Put("puff", ((V)(0D))).V, (Get(X_2175, "dnp") is var _t2218 && Truthy(_t2218) ? _t2218 : NewObj(0).V));
st_2215 = Call(bHold_101, V.Undef, DN_2214, (Get(X_2175, "dnOrd") is var _t2219 && Truthy(_t2219) ? _t2219 : (Truthy(md_2182) ? Arr(((V)("bite")), ((V)("chew")), ((V)("bite")), ((V)("crumbs")), ((V)("bite")), ((V)("sig")), ((V)("yum"))) : Arr(((V)("bite")), ((V)("chew")), ((V)("bite")), ((V)("sip")), ((V)("crumbs")), ((V)("bite")), ((V)("lick")), ((V)("sig")), ((V)("yum"))))), DNB_107, X_2175, sig_2181, Arr(((V)(700D)), ((V)(1100D)), ((V)(900D)), ((V)(1300D))));
Set(st_2215, "prop", Call(dineProp_108, V.Undef, st_2215, (Get(X_2175, "sn") is var _t2220 && Truthy(_t2220) ? _t2220 : ((V)("cookie"))), md_2182));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("dine"))), st_2215);
di_2216 = Call(sitdown_20, V.Undef, DN_2214, P_2176);
Set(di_2216, "next", ((V)("dine")));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("dinein"))), di_2216);
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("dineout"))), Call(standup_23, V.Undef, DN_2214, P_2176));
}
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("surf"))), Call(bHold_101, V.Undef, Call(o_10, V.Undef, SF0_109, (Get(X_2175, "sfp") is var _t2221 && Truthy(_t2221) ? _t2221 : NewObj(0).V)), (Get(X_2175, "sfOrd") is var _t2222 && Truthy(_t2222) ? _t2222 : Arr(((V)("wobble")), ((V)("carve")), ((V)("bump")), ((V)("hang10")), ((V)("sig")), ((V)("crouch")), ((V)("wipe")))), SFB_110, X_2175, sig_2181, Arr(((V)(500D)), ((V)(800D)), ((V)(600D)), ((V)(900D))), NewObj(1).Put("breathe", ((V)(0.3))).V));
{
V st_2223 = default;
st_2223 = Call(bHold_101, V.Undef, Call(o_10, V.Undef, FS0_111, (Get(X_2175, "fsp") is var _t2224 && Truthy(_t2224) ? _t2224 : NewObj(0).V)), (Get(X_2175, "fsOrd") is var _t2225 && Truthy(_t2225) ? _t2225 : Arr(((V)("cast")), ((V)("look")), ((V)("nibble")), ((V)("hum")), ((V)("nibble")), ((V)("reel")), ((V)("catch")), ((V)("sig")))), FB_112, X_2175, sig_2181, Arr(((V)(600D)), ((V)(900D)), ((V)(700D)), ((V)(1000D))));
Set(st_2223, "prop", Call(fishProp_113, V.Undef, st_2223, (Get(X_2175, "fc") is var _t2226 && Truthy(_t2226) ? _t2226 : ((V)("fish")))));
Set(st_2223, "catchEnd", GetIdx((GetIdx((Get(Get(st_2223, "rec"), "catch") is var _t2227 && Truthy(_t2227) ? _t2227 : Arr()), 0D) is var _t2228 && Truthy(_t2228) ? _t2228 : Arr(((V)(0D)), Get(st_2223, "loop"))), 1D));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("fishing"))), st_2223);
}
{
V fl_2229 = default;
V sea_2230 = default;
V adj_2231 = default;
V SN_2232 = default;
V a_2233 = default;
V st_2234 = default;
V b_2235 = default;
fl_2229 = (SEqS(Get(P_2176, "dn"), "float") ? V.True : V.False);
sea_2230 = ((SEqS(Get(P_2176, "dn"), "flop") && SEqN(Get((Get(P_2176, "pose") is var _t2236 && Truthy(_t2236) ? _t2236 : NewObj(0).V), "sit"), 0D)) ? V.True : V.False);
adj_2231 = (Truthy(fl_2229) ? NewObj(2).Put("sit", ((V)(0D))).Put("lift", ((V)(1.2))).V : (Truthy(sea_2230) ? NewObj(4).Put("sit", ((V)(0D))).Put("pitch", ((V)((-0.1)))).Put("htilt", ((V)(4D))).Put("lift", ((V)((-1.6)))).V : NewObj(0).V));
SN_2232 = Call(o_10, V.Undef, SB_2179, LIE0_40, adj_2231, (Get(BX_2180, "lp") is var _t2237 && Truthy(_t2237) ? _t2237 : NewObj(0).V), (Get(BX_2180, "np") is var _t2238 && Truthy(_t2238) ? _t2238 : NewObj(0).V), NewObj(11).Put("qk", ((V)(0D))).Put("zz", ((V)(0D))).Put("drm", ((V)(0D))).Put("close", ((V)(0.3))).Put("mw", ((V)(1D))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.3))).Put("open", ((V)(0D))).Put("shd", ((V)(1D))).Put("shu", ((V)(0D))).Put("puff", ((V)(0D))).V, (Get(X_2175, "snp") is var _t2239 && Truthy(_t2239) ? _t2239 : NewObj(0).V));
a_2233 = Call(sunIn_117, V.Undef, SB_2179, SN_2232, P_2176);
Set(a_2233, "prop", Call(sunProp_116, V.Undef, V.Null));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("sunin"))), a_2233);
st_2234 = Call(bHold_101, V.Undef, SN_2232, (Get(X_2175, "snOrd") is var _t2240 && Truthy(_t2240) ? _t2240 : Arr(((V)("sigh")), ((V)("toes")), ((V)("sip")), ((V)("sig")), ((V)("lotion")), ((V)("peek")), ((V)("doze")))), SUNB_114, X_2175, (Get(X_2175, "ss") is var _t2241 && Truthy(_t2241) ? _t2241 : Get(BX_2180, "s")), Arr(((V)(1400D)), ((V)(2000D)), ((V)(1700D)), ((V)(2300D))), NewObj(2).Put("breathe", ((V)(0.6))).Put("noBlink", (false ? V.True : V.False)).V);
Set(st_2234, "prop", Call(sunProp_116, V.Undef, st_2234));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("sun"))), st_2234);
b_2235 = Call(sunOut_118, V.Undef, SN_2232, SB_2179, P_2176);
Set(b_2235, "prop", Call(sunProp_116, V.Undef, V.Null));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("sunout"))), b_2235);
}
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("slide"))), Call(slideMove_119, V.Undef, P_2176, X_2175));
{
V TB_2242 = default;
TB_2242 = Call(o_10, V.Undef, TB0_120, (Get(X_2175, "tbp") is var _t2243 && Truthy(_t2243) ? _t2243 : NewObj(0).V));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("bouncein"))), Call(bounceIn_122, V.Undef, TB_2242, P_2176));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("bounce"))), Call(bHold_101, V.Undef, TB_2242, (Get(X_2175, "tbOrd") is var _t2244 && Truthy(_t2244) ? _t2244 : Arr(((V)("hop")), ((V)("jumps")), ((V)("star")), ((V)("hop")), ((V)("tuck")), ((V)("seat")), ((V)("hop")), ((V)("spin")), ((V)("sig")), ((V)("jumps")))), TBB_121, X_2175, sig_2181, Arr(((V)(150D)), ((V)(250D)), ((V)(200D))), NewObj(1).Put("breathe", ((V)(0.2))).V));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("bounceout"))), Call(bounceOut_123, V.Undef, TB_2242, P_2176));
}
{
V DG_2245 = default;
V din_2246 = default;
DG_2245 = Call(o_10, V.Undef, SB_2179, Call(hand_12, V.Undef, ((V)(1D)), ((V)(10D)), ((V)(3D))), Call(hand_12, V.Undef, ((V)((-1D))), ((V)(8D)), ((V)(4D))), NewObj(6).Put("armL", ((V)(20D))).Put("armR", ((V)(26D))).Put("pitch", ((V)((ToNum((Get(SB_2179, "pitch") is var _t2247 && Truthy(_t2247) ? _t2247 : ((V)(0D)))) - 0.16)))).Put("ly", ((V)(0.6))).Put("smile", ((V)(0.7))).Put("hap", ((V)(0.3))).V, (Get(X_2175, "dgp") is var _t2248 && Truthy(_t2248) ? _t2248 : NewObj(0).V));
din_2246 = Fn((V _arrowThis2256, int _argc2249, V nx_2255, V _a2252, V _a2253, V _a2254, V[] _rest2250) => {
V t_2257 = default;
V v_2258 = default;
t_2257 = Call(TL_11, V.Undef, REST_9);
Invoke(t_2257, "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0.12))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("io")));
v_2258 = NewObj(0).V;
Invoke(Call(keysOf_15, V.Undef, DG_2245), "forEach", Fn((V _arrowThis2266, int _argc2259, V p_2265, V _a2262, V _a2263, V _a2264, V[] _rest2260) => {
return SetK(v_2258, p_2265, GetK(DG_2245, p_2265));
}, 1, "", true));
Invoke(Invoke(Invoke(t_2257, "to", ((V)(320D)), Call(o_10, V.Undef, v_2258, NewObj(1).Put("sq", Add(Get(DG_2245, "sq"), ((V)(0.1)))).V), ((V)("i"))), "to", ((V)(180D)), NewObj(1).Put("sq", ((V)((ToNum(Get(DG_2245, "sq")) - 0.02)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(DG_2245, "sq")).V, ((V)("io")));
return Invoke(t_2257, "out", NewObj(2).Put("next", nx_2255).Put("blend", ((V)(200D))).V);
return default;
}, 1, "", true);
{
V st_2267 = default;
st_2267 = Call(bHold_101, V.Undef, DG_2245, (Get(X_2175, "dgOrd") is var _t2268 && Truthy(_t2268) ? _t2268 : Arr(((V)("scoop")), ((V)("pile")), ((V)("bucket")), ((V)("pat")), ((V)("scoop")), ((V)("bucket")), ((V)("flag")), ((V)("admire")), ((V)("sig")), ((V)("crumble")))), DGB_124, X_2175, sig_2181, Arr(((V)(400D)), ((V)(600D)), ((V)(500D)), ((V)(700D))));
Set(st_2267, "prop", Call(digProp_130, V.Undef, st_2267));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("dig"))), st_2267);
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("digin"))), Call(din_2246, V.Undef, ((V)("dig"))));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("digout"))), Call(standup_23, V.Undef, DG_2245, P_2176));
}
{
V st_2269 = default;
st_2269 = Call(bHold_101, V.Undef, DG_2245, (Get(X_2175, "blOrd") is var _t2270 && Truthy(_t2270) ? _t2270 : Arr(((V)("stack")), ((V)("stack")), ((V)("stack")), ((V)("wobble")), ((V)("stack")), ((V)("stack")), ((V)("topple")), ((V)("giggle")), ((V)("sig")), ((V)("tidy")))), BLB_134, X_2175, sig_2181, Arr(((V)(500D)), ((V)(700D)), ((V)(600D))));
Set(st_2269, "prop", Call(blocksProp_135, V.Undef, st_2269));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("blocks"))), st_2269);
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("blocksin"))), Call(din_2246, V.Undef, ((V)("blocks"))));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("blocksout"))), Call(standup_23, V.Undef, DG_2245, P_2176));
}
}
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("water"))), Call(waterMove_137, V.Undef, X_2175));
{
V RS_2271 = default;
V st_2272 = default;
V ri_2273 = default;
RS_2271 = Call(o_10, V.Undef, SB_2179, Call(hand_12, V.Undef, ((V)(1D)), ((V)(1D)), ((V)((-2D)))), Call(hand_12, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)(3D))), NewObj(7).Put("armR", ((V)(42D))).Put("armL", ((V)(16D))).Put("pitch", ((V)((ToNum((Get(SB_2179, "pitch") is var _t2274 && Truthy(_t2274) ? _t2274 : ((V)(0D)))) - 0.02)))).Put("ly", ((V)(0.2))).Put("lx", ((V)(0.5))).Put("smile", ((V)(0.7))).Put("puff", ((V)(0D))).V, (Get(X_2175, "rsp") is var _t2275 && Truthy(_t2275) ? _t2275 : NewObj(0).V));
st_2272 = Call(bHold_101, V.Undef, RS_2271, (Get(X_2175, "rsOrd") is var _t2276 && Truthy(_t2276) ? _t2276 : Arr(((V)("hold")), ((V)("turn")), ((V)("hold")), ((V)("eat")), ((V)("new")), ((V)("hold")), ((V)("turn")), ((V)("fire")), ((V)("blow")), ((V)("eat")), ((V)("new")), ((V)("sig")))), RSB_138, X_2175, sig_2181, Arr(((V)(600D)), ((V)(900D)), ((V)(700D)), ((V)(1000D))));
Set(st_2272, "prop", Call(roastProp_139, V.Undef, st_2272));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("roast"))), st_2272);
ri_2273 = Call(sitdown_20, V.Undef, RS_2271, P_2176);
Set(ri_2273, "next", ((V)("roast")));
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("roastin"))), ri_2273);
SetK(S_2178, Call(nm_2177, V.Undef, ((V)("roastout"))), Call(standup_23, V.Undef, RS_2271, P_2176));
}
Invoke(R_8, "add", S_2178);
Set(R_8, "HS", Object_assign((Get(R_8, "HS") is var _t2277 && Truthy(_t2277) ? _t2277 : NewObj(0).V), S_2178));
if (Truthy(key_2174)) {
SetK(BB_140, key_2174, X_2175);
}
return default;
}, 2, "bBuild", false);
R_8 = Get(G("window"), "RiveRig");
if (((!(Truthy(R_8)) || !(Truthy(Get(R_8, "REST")))) || !(Truthy(Get(R_8, "movesV"))))) {
Call(G("setTimeout"), V.Undef, boot_2278.v, ((V)(30D)));
return default;
}
if (Truthy(Get(R_8, "houseV"))) {
return default;
}
Set(R_8, "houseV", ((V)(1D)));
REST_9 = Get(R_8, "REST");
o_10 = Fn((V _arrowThis2286, int _argc2279, V _a2281, V _a2282, V _a2283, V _a2284, V[] _rest2280) => {
V a_2285 = default;
a_2285 = RestArgs(0, _argc2279, _a2281, _a2282, _a2283, _a2284, _rest2280);
return InvokeSpread(G("Object"), "assign", new ArrBuilder().Add(NewObj(0).V).Spread(a_2285).V);
}, 1, "", true);
hand_12 = Fn((V _arrowThis2296, int _argc2287, V s_2293, V inX_2294, V y_2295, V _a2292, V[] _rest2288) => {
return (LtN(s_2293, 0D) ? NewObj(2).Put("hLx", inX_2294).Put("hLy", y_2295).V : NewObj(2).Put("hRx", ((V)((-ToNum(inX_2294))))).Put("hRy", y_2295).V);
}, 3, "", true);
both_13 = Fn((V _arrowThis2305, int _argc2297, V inX_2303, V y_2304, V _a2301, V _a2302, V[] _rest2298) => {
return Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), inX_2303, y_2304), Call(hand_12, V.Undef, ((V)(1D)), inX_2303, y_2304));
}, 2, "", true);
SIDE_14 = Fn((V _arrowThis2313, int _argc2306, V s_2312, V _a2309, V _a2310, V _a2311, V[] _rest2307) => {
return (LtN(s_2312, 0D) ? NewObj(6).Put("arm", ((V)("armL"))).Put("hx", ((V)("hLx"))).Put("hy", ((V)("hLy"))).Put("ear", ((V)("earL"))).Put("foot", ((V)("footL"))).Put("wink", ((V)("winkL"))).V : NewObj(6).Put("arm", ((V)("armR"))).Put("hx", ((V)("hRx"))).Put("hy", ((V)("hRy"))).Put("ear", ((V)("earR"))).Put("foot", ((V)("footR"))).Put("wink", ((V)("winkR"))).V);
}, 1, "", true);
keysOf_15 = Fn((V _arrowThis2321, int _argc2314, V v_2320, V _a2317, V _a2318, V _a2319, V[] _rest2315) => {
return Object_keys(v_2320);
}, 1, "", true);
BEAT_16 = NewObj(17).Put("swing", Fn((V _self2322, int _argc2323, V t_2329, V _a2326, V _a2327, V _a2328, V[] _rest2324) => {
V B_2330 = default;
V a_2331 = default;
if (_self2322.IsNullish) _self2322 = GlobalV;
B_2330 = Get(t_2329, "B");
a_2331 = (Get(B_2330, "footL") is var _t2332 && Truthy(_t2332) ? _t2332 : ((V)(0D)));
Invoke(t_2329, "osc", ((V)(2600D)), ((V)(4D)), NewObj(3).Put("footL", Add(a_2331, ((V)(1.8)))).Put("footR", ((V)((ToNum(a_2331) - 0.6)))).Put("lean", ((V)(0.5))).V, NewObj(3).Put("footL", ((V)((ToNum(a_2331) - 0.6)))).Put("footR", Add(a_2331, ((V)(1.8)))).Put("lean", ((V)((-0.5)))).V, ((V)("s")));
return Invoke(t_2329, "back", ((V)(380D)), Arr(((V)("footL")), ((V)("footR")), ((V)("lean"))));
return default;
}, 1, "swing", false)).Put("look", Fn((V _self2333, int _argc2334, V t_2340, V _a2337, V _a2338, V _a2339, V[] _rest2335) => {
if (_self2333.IsNullish) _self2333 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2340, "e", ((V)("blink"))), "to", ((V)(420D)), NewObj(3).Put("lx", ((V)((-0.9)))).Put("turn", ((V)((-0.22)))).Put("htilt", ((V)((-4D)))).V, ((V)("io"))), "wait", ((V)(1000D))), "to", ((V)(560D)), NewObj(3).Put("lx", ((V)(0.9))).Put("turn", ((V)(0.22))).Put("htilt", ((V)(4D))).V, ((V)("io"))), "wait", ((V)(1000D)));
return Invoke(t_2340, "back", ((V)(480D)), Arr(((V)("lx")), ((V)("turn")), ((V)("htilt"))));
return default;
}, 1, "look", false)).Put("pat", Fn((V _self2341, int _argc2342, V t_2348, V s_2349, V _a2346, V _a2347, V[] _rest2343) => {
V K_2350 = default;
V B_2351 = default;
if (_self2341.IsNullish) _self2341 = GlobalV;
s_2349 = (s_2349 is var _t2352 && Truthy(_t2352) ? _t2352 : ((V)(1D)));
K_2350 = Call(SIDE_14, V.Undef, s_2349);
B_2351 = Get(t_2348, "B");
Invoke(t_2348, "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, s_2349, ((V)((-11D))), ((V)(9D))), NewObj(4).PutK(Get(K_2350, "arm"), ((V)(18D))).Put("turn", ((V)((ToNum(s_2349) * 0.12)))).Put("lx", ((V)((ToNum(s_2349) * 0.6)))).Put("ly", ((V)(0.4))).V), ((V)("io")));
Invoke(t_2348, "osc", ((V)(1200D)), ((V)(3D)), NewObj(2).PutK(Get(K_2350, "hy"), ((V)(11D))).Put("sq", Add((Get(B_2351, "sq") is var _t2353 && Truthy(_t2353) ? _t2353 : ((V)(0D))), ((V)(0.012)))).V, NewObj(2).PutK(Get(K_2350, "hy"), ((V)(7D))).Put("sq", (Get(B_2351, "sq") is var _t2354 && Truthy(_t2354) ? _t2354 : ((V)(0D)))).V, ((V)("o")));
return Invoke(t_2348, "back", ((V)(420D)), Arr(Get(K_2350, "hx"), Get(K_2350, "hy"), Get(K_2350, "arm"), ((V)("turn")), ((V)("lx")), ((V)("ly")), ((V)("sq"))));
return default;
}, 2, "pat", false)).Put("yawn", Fn((V _self2355, int _argc2356, V t_2362, V _a2359, V _a2360, V _a2361, V[] _rest2357) => {
V B_2363 = default;
if (_self2355.IsNullish) _self2355 = GlobalV;
B_2363 = Get(t_2362, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_2362, "to", ((V)(320D)), NewObj(2).Put("sq", Add((Get(B_2363, "sq") is var _t2371 && Truthy(_t2371) ? _t2371 : ((V)(0D))), ((V)(0.03)))).Put("close", ((V)(0.35))).V), "to", ((V)(620D)), NewObj(10).Put("sq", ((V)((ToNum((Get(B_2363, "sq") is var _t2370 && Truthy(_t2370) ? _t2370 : ((V)(0D)))) - 0.06)))).Put("pitch", ((V)(0.4))).Put("open", ((V)(0.9))).Put("mw", ((V)(0.8))).Put("close", ((V)(0.85))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("hLy", ((V)((-3D)))).Put("hRy", ((V)((-3D)))).Put("tongue", ((V)(0.2))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(1.4))).V, NewObj(1).Put("tilt", ((V)((-1.4)))).V, ((V)("s"))), "to", ((V)(520D)), NewObj(11).Put("sq", (Get(B_2363, "sq") is var _t2364 && Truthy(_t2364) ? _t2364 : ((V)(0D)))).Put("pitch", (Get(B_2363, "pitch") is var _t2365 && Truthy(_t2365) ? _t2365 : ((V)(0D)))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("close", ((V)(0.3))).Put("armL", (Get(B_2363, "armL") is var _t2366 && Truthy(_t2366) ? _t2366 : ((V)(0D)))).Put("armR", (Get(B_2363, "armR") is var _t2367 && Truthy(_t2367) ? _t2367 : ((V)(0D)))).Put("hLy", (Get(B_2363, "hLy") is var _t2368 && Truthy(_t2368) ? _t2368 : ((V)(0D)))).Put("hRy", (Get(B_2363, "hRy") is var _t2369 && Truthy(_t2369) ? _t2369 : ((V)(0D)))).Put("tongue", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink2")));
return Invoke(t_2362, "back", ((V)(300D)), Arr(((V)("close"))));
return default;
}, 1, "yawn", false)).Put("kick", Fn((V _self2372, int _argc2373, V t_2379, V _a2376, V _a2377, V _a2378, V[] _rest2374) => {
V a_2380 = default;
if (_self2372.IsNullish) _self2372 = GlobalV;
a_2380 = (Get(Get(t_2379, "B"), "footL") is var _t2381 && Truthy(_t2381) ? _t2381 : ((V)(0D)));
Invoke(Invoke(t_2379, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(1100D)), ((V)(3D)), NewObj(3).Put("footL", Add(a_2380, ((V)(3D)))).Put("footR", Add(a_2380, ((V)(3D)))).Put("sq", ((V)((ToNum((Get(Get(t_2379, "B"), "sq") is var _t2382 && Truthy(_t2382) ? _t2382 : ((V)(0D)))) - 0.02)))).V, NewObj(3).Put("footL", a_2380).Put("footR", a_2380).Put("sq", (Get(Get(t_2379, "B"), "sq") is var _t2383 && Truthy(_t2383) ? _t2383 : ((V)(0D)))).V, ((V)("o")));
return Invoke(t_2379, "back", ((V)(360D)), Arr(((V)("hap")), ((V)("smile")), ((V)("footL")), ((V)("footR")), ((V)("sq"))));
return default;
}, 1, "kick", false)).Put("wiggle", Fn((V _self2384, int _argc2385, V t_2391, V _a2388, V _a2389, V _a2390, V[] _rest2386) => {
if (_self2384.IsNullish) _self2384 = GlobalV;
Invoke(Invoke(t_2391, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.6))).Put("smile", ((V)(0.8))).V), "osc", ((V)(1500D)), ((V)(3D)), NewObj(2).Put("x", ((V)(1.2))).Put("tilt", ((V)(2.4))).V, NewObj(2).Put("x", ((V)((-1.2)))).Put("tilt", ((V)((-2.4)))).V, ((V)("s")));
return Invoke(t_2391, "back", ((V)(360D)), Arr(((V)("x")), ((V)("tilt")), ((V)("hap")), ((V)("smile"))));
return default;
}, 1, "wiggle", false)).Put("hum", Fn((V _self2392, int _argc2393, V t_2399, V _a2396, V _a2397, V _a2398, V[] _rest2394) => {
if (_self2392.IsNullish) _self2392 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2399, "to", ((V)(260D)), NewObj(3).Put("smile", ((V)(0.9))).Put("close", ((V)(0.5))).Put("hap", ((V)(0.5))).V), "fx", ((V)("note")), ((V)("head"))), "osc", ((V)(2400D)), ((V)(4D)), NewObj(2).Put("htilt", ((V)(6D))).Put("lean", ((V)(0.6))).V, NewObj(2).Put("htilt", ((V)((-6D)))).Put("lean", ((V)((-0.6)))).V, ((V)("s"))), "fx", ((V)("note")), ((V)("head")));
return Invoke(t_2399, "back", ((V)(400D)), Arr(((V)("smile")), ((V)("close")), ((V)("hap")), ((V)("htilt")), ((V)("lean"))));
return default;
}, 1, "hum", false)).Put("ears", Fn((V _self2400, int _argc2401, V t_2407, V _a2404, V _a2405, V _a2406, V[] _rest2402) => {
if (_self2400.IsNullish) _self2400 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2407, "to", ((V)(90D)), NewObj(1).Put("earR", ((V)((-10D)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("earR", ((V)(4D))).V), "to", ((V)(140D)), NewObj(1).Put("earR", ((V)(0D))).V), "wait", ((V)(500D))), "to", ((V)(90D)), NewObj(1).Put("earL", ((V)((-10D)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("earL", ((V)(4D))).V);
return Invoke(t_2407, "back", ((V)(160D)), Arr(((V)("earL")), ((V)("earR"))));
return default;
}, 1, "ears", false)).Put("wag", Fn((V _self2408, int _argc2409, V t_2415, V _a2412, V _a2413, V _a2414, V[] _rest2410) => {
if (_self2408.IsNullish) _self2408 = GlobalV;
Invoke(Invoke(t_2415, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.5))).Put("smile", ((V)(0.7))).V), "osc", ((V)(1800D)), ((V)(5D)), NewObj(1).Put("wag", ((V)(20D))).V, NewObj(1).Put("wag", ((V)((-20D)))).V, ((V)("io")));
return Invoke(t_2415, "back", ((V)(300D)), Arr(((V)("wag")), ((V)("hap")), ((V)("smile"))));
return default;
}, 1, "wag", false)).Put("giggle", Fn((V _self2416, int _argc2417, V t_2423, V s_2424, V _a2421, V _a2422, V[] _rest2418) => {
V K_2425 = default;
if (_self2416.IsNullish) _self2416 = GlobalV;
s_2424 = (s_2424 is var _t2426 && Truthy(_t2426) ? _t2426 : ((V)(1D)));
K_2425 = Call(SIDE_14, V.Undef, s_2424);
Invoke(Invoke(t_2423, "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, s_2424, ((V)(9D)), ((V)((-12D)))), NewObj(6).PutK(Get(K_2425, "arm"), ((V)(30D))).Put("blush", ((V)(0.8))).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).Put("htilt", ((V)((ToNum(s_2424) * 4D)))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("sq", Add((Get(Get(t_2423, "B"), "sq") is var _t2427 && Truthy(_t2427) ? _t2427 : ((V)(0D))), ((V)(0.025)))).V, NewObj(1).Put("sq", (Get(Get(t_2423, "B"), "sq") is var _t2428 && Truthy(_t2428) ? _t2428 : ((V)(0D)))).V, ((V)("o")));
return Invoke(t_2423, "back", ((V)(420D)), Arr(Get(K_2425, "hx"), Get(K_2425, "hy"), Get(K_2425, "arm"), ((V)("blush")), ((V)("hap")), ((V)("sqz")), ((V)("smile")), ((V)("htilt")), ((V)("sq"))));
return default;
}, 2, "giggle", false)).Put("bounce", Fn((V _self2429, int _argc2430, V t_2436, V _a2433, V _a2434, V _a2435, V[] _rest2431) => {
V L_2437 = default;
V Q_2438 = default;
if (_self2429.IsNullish) _self2429 = GlobalV;
L_2437 = (Get(Get(t_2436, "B"), "lift") is var _t2439 && Truthy(_t2439) ? _t2439 : ((V)(0D)));
Q_2438 = (Get(Get(t_2436, "B"), "sq") is var _t2440 && Truthy(_t2440) ? _t2440 : ((V)(0D)));
Invoke(t_2436, "to", ((V)(180D)), NewObj(3).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
{
double i_2441 = 0;
i_2441 = 0D;
while (true) {
if (!((i_2441 < 3D))) break;
Invoke(Invoke(Invoke(t_2436, "to", ((V)(130D)), NewObj(2).Put("sq", Add(Q_2438, ((V)(0.08)))).Put("lift", L_2437).V, ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)((ToNum(Q_2438) - 0.05)))).Put("lift", Add(L_2437, ((V)(2.6)))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(2).Put("sq", Q_2438).Put("lift", L_2437).V, ((V)("i")));
i_2441++;
}
}
return Invoke(t_2436, "back", ((V)(300D)), Arr(((V)("hap")), ((V)("smile")), ((V)("open")), ((V)("sq")), ((V)("lift"))));
return default;
}, 1, "bounce", false)).Put("wave", Fn((V _self2443, int _argc2444, V t_2450, V s_2451, V _a2448, V _a2449, V[] _rest2445) => {
V K_2452 = default;
if (_self2443.IsNullish) _self2443 = GlobalV;
s_2451 = (s_2451 is var _t2453 && Truthy(_t2453) ? _t2453 : ((V)(1D)));
K_2452 = Call(SIDE_14, V.Undef, s_2451);
Invoke(Invoke(t_2450, "to", ((V)(380D)), NewObj(6).PutK(Get(K_2452, "arm"), ((V)(145D))).PutK(Get(K_2452, "hy"), ((V)((-3D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("htilt", ((V)((ToNum(s_2451) * 4D)))).V, ((V)("o"))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).PutK(Get(K_2452, "arm"), ((V)(118D))).V, NewObj(1).PutK(Get(K_2452, "arm"), ((V)(160D))).V, ((V)("io")));
return Invoke(t_2450, "back", ((V)(420D)), Arr(Get(K_2452, "arm"), Get(K_2452, "hy"), ((V)("hap")), ((V)("smile")), ((V)("open")), ((V)("htilt"))));
return default;
}, 2, "wave", false)).Put("nod", Fn((V _self2454, int _argc2455, V t_2461, V _a2458, V _a2459, V _a2460, V[] _rest2456) => {
if (_self2454.IsNullish) _self2454 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2461, "to", ((V)(600D)), NewObj(2).Put("close", ((V)(0.75))).Put("pitch", ((V)((-0.18)))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(140D)), NewObj(3).Put("pitch", ((V)(0.05))).Put("close", ((V)(0D))).Put("wide", ((V)(0.5))).V, ((V)("o"))), "e", ((V)("blink2")));
return Invoke(t_2461, "back", ((V)(380D)), Arr(((V)("close")), ((V)("pitch")), ((V)("wide"))));
return default;
}, 1, "nod", false)).Put("stretch", Fn((V _self2462, int _argc2463, V t_2469, V _a2466, V _a2467, V _a2468, V[] _rest2464) => {
V B_2470 = default;
if (_self2462.IsNullish) _self2462 = GlobalV;
B_2470 = Get(t_2469, "B");
Invoke(Invoke(Invoke(t_2469, "to", ((V)(700D)), NewObj(10).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).Put("hLy", ((V)((-5D)))).Put("hRy", ((V)((-5D)))).Put("sq", ((V)((ToNum((Get(B_2470, "sq") is var _t2471 && Truthy(_t2471) ? _t2471 : ((V)(0D)))) - 0.09)))).Put("close", ((V)(0.9))).Put("open", ((V)(0.45))).Put("pitch", ((V)(0.35))).Put("footL", Add((Get(B_2470, "footL") is var _t2472 && Truthy(_t2472) ? _t2472 : ((V)(0D))), ((V)(2D)))).Put("footR", Add((Get(B_2470, "footR") is var _t2473 && Truthy(_t2473) ? _t2473 : ((V)(0D))), ((V)(2D)))).V, ((V)("io"))), "wait", ((V)(500D))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(1.2))).V, NewObj(1).Put("tilt", ((V)((-1.2)))).V, ((V)("s")));
return Invoke(t_2469, "back", ((V)(650D)), Arr(((V)("armL")), ((V)("armR")), ((V)("hLy")), ((V)("hRy")), ((V)("sq")), ((V)("close")), ((V)("open")), ((V)("pitch")), ((V)("footL")), ((V)("footR")), ((V)("tilt"))));
return default;
}, 1, "stretch", false)).Put("sigh", Fn((V _self2474, int _argc2475, V t_2481, V _a2478, V _a2479, V _a2480, V[] _rest2476) => {
V B_2482 = default;
if (_self2474.IsNullish) _self2474 = GlobalV;
B_2482 = Get(t_2481, "B");
Invoke(Invoke(Invoke(t_2481, "to", ((V)(900D)), NewObj(4).Put("sq", ((V)((ToNum((Get(B_2482, "sq") is var _t2485 && Truthy(_t2485) ? _t2485 : ((V)(0D)))) - 0.05)))).Put("lift", Add((Get(B_2482, "lift") is var _t2486 && Truthy(_t2486) ? _t2486 : ((V)(0D))), ((V)(0.8)))).Put("close", ((V)(0.6))).Put("open", ((V)(0.2))).V, ((V)("s"))), "to", ((V)(1300D)), NewObj(5).Put("sq", Add((Get(B_2482, "sq") is var _t2483 && Truthy(_t2483) ? _t2483 : ((V)(0D))), ((V)(0.07)))).Put("lift", (Get(B_2482, "lift") is var _t2484 && Truthy(_t2484) ? _t2484 : ((V)(0D)))).Put("close", ((V)(0.8))).Put("open", ((V)(0.1))).Put("smile", ((V)(0.9))).V, ((V)("s"))), "wait", ((V)(400D)));
return Invoke(t_2481, "back", ((V)(700D)), Arr(((V)("sq")), ((V)("lift")), ((V)("close")), ((V)("open")), ((V)("smile"))));
return default;
}, 1, "sigh", false)).Put("doze", Fn((V _self2487, int _argc2488, V t_2494, V _a2491, V _a2492, V _a2493, V[] _rest2489) => {
if (_self2487.IsNullish) _self2487 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2494, "to", ((V)(900D)), NewObj(3).Put("close", ((V)(1D))).Put("pitch", ((V)((ToNum((Get(Get(t_2494, "B"), "pitch") is var _t2498 && Truthy(_t2498) ? _t2498 : ((V)(0D)))) - 0.2)))).Put("htilt", ((V)(5D))).V, ((V)("s"))), "osc", ((V)(2400D)), ((V)(2D)), NewObj(1).Put("pitch", ((V)((ToNum((Get(Get(t_2494, "B"), "pitch") is var _t2496 && Truthy(_t2496) ? _t2496 : ((V)(0D)))) - 0.3)))).V, NewObj(1).Put("pitch", ((V)((ToNum((Get(Get(t_2494, "B"), "pitch") is var _t2497 && Truthy(_t2497) ? _t2497 : ((V)(0D)))) - 0.16)))).V, ((V)("s"))), "to", ((V)(160D)), NewObj(4).Put("close", ((V)(0D))).Put("wide", ((V)(0.6))).Put("pitch", (Get(Get(t_2494, "B"), "pitch") is var _t2495 && Truthy(_t2495) ? _t2495 : ((V)(0D)))).Put("htilt", ((V)(0D))).V, ((V)("o"))), "e", ((V)("blink2")));
return Invoke(t_2494, "back", ((V)(420D)), Arr(((V)("close")), ((V)("pitch")), ((V)("htilt")), ((V)("wide"))));
return default;
}, 1, "doze", false)).Put("belly", Fn((V _self2499, int _argc2500, V t_2506, V s_2507, V _a2504, V _a2505, V[] _rest2501) => {
V K_2508 = default;
if (_self2499.IsNullish) _self2499 = GlobalV;
s_2507 = (s_2507 is var _t2509 && Truthy(_t2509) ? _t2509 : ((V)((-1D))));
K_2508 = Call(SIDE_14, V.Undef, s_2507);
Invoke(Invoke(Invoke(t_2506, "to", ((V)(420D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, s_2507, ((V)(6D)), ((V)(6D))), NewObj(1).PutK(Get(K_2508, "arm"), ((V)(10D))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).PutK(Get(K_2508, "hy"), ((V)(8D))).V, NewObj(1).PutK(Get(K_2508, "hy"), ((V)(5D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V);
return Invoke(t_2506, "back", ((V)(460D)), Arr(Get(K_2508, "hx"), Get(K_2508, "hy"), Get(K_2508, "arm"), ((V)("smile")), ((V)("hap"))));
return default;
}, 2, "belly", false)).V;
SIT0_17 = Call(o_10, V.Undef, NewObj(4).Put("sit", ((V)(1D))).Put("sq", ((V)(0.1))).Put("lift", ((V)((-2.6)))).Put("pitch", ((V)(0.06))).V, Call(both_13, V.Undef, ((V)(6D)), ((V)(3D))));
LNG0_18 = Call(o_10, V.Undef, NewObj(14).Put("sit", ((V)(1D))).Put("sq", ((V)(0.14))).Put("lift", ((V)((-3.6)))).Put("pitch", ((V)(0.3))).Put("close", ((V)(0.5))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.25))).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("footL", ((V)(2D))).Put("footR", ((V)(0.3))).Put("tilt", ((V)((-3.5)))).Put("htilt", ((V)(6D))).Put("lean", ((V)((-0.7)))).V, Call(both_13, V.Undef, ((V)((-2D))), ((V)((-1D)))));
ss_25 = Fn((V _arrowThis2517, int _argc2510, V x_2516, V _a2513, V _a2514, V _a2515, V[] _rest2511) => {
return ((V)((LeN(x_2516, 0D) ? 0D : (GeN(x_2516, 1D) ? 1D : ((ToNum(x_2516) * ToNum(x_2516)) * (3D - (2D * ToNum(x_2516))))))));
}, 1, "", true);
TWO_26 = NewObj(3).Put("pip", ((V)(1D))).Put("puff", ((V)(1D))).Put("pearl", ((V)(1D))).V;
LAP_27 = NewObj(8).Put("bubbly", ((V)(1D))).Put("twinkle", ((V)(1D))).Put("jelli", ((V)(1D))).Put("finn", ((V)(1D))).Put("aurora", ((V)(1D))).Put("sealy", ((V)(1D))).Put("shelly", ((V)(1D))).Put("batty", ((V)(1D))).V;
RIGID_28 = NewObj(19).Put("puddi", ((V)(1D))).Put("cakey", ((V)(1D))).Put("maca", ((V)(1D))).Put("melo", ((V)(1D))).Put("choco", ((V)(1D))).Put("chip", ((V)(1D))).Put("twisty", ((V)(1D))).Put("crois", ((V)(1D))).Put("mochi", ((V)(1D))).Put("frybo", ((V)(1D))).Put("boba", ((V)(1D))).Put("bunbun", ((V)(1D))).Put("mallow", ((V)(1D))).Put("dunkie", ((V)(1D))).Put("scoop", ((V)(1D))).Put("cuppy", ((V)(1D))).Put("kernel", ((V)(1D))).Put("bao", ((V)(1D))).Put("chefbun", ((V)(1D))).V;
WX_29 = NewObj(78).Put("mittens", NewObj(2).Put("laughA", NewObj(1).Put("curl", ((V)(0.5))).V).Put("nz", NewObj(1).Put("curl", ((V)(0.7))).V).V).Put("biscuit", NewObj(4).Put("laughA", NewObj(1).Put("wag", ((V)(26D))).V).Put("laughB", NewObj(1).Put("wag", ((V)((-26D)))).V).Put("cheer", NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).V).Put("nz", NewObj(1).Put("wag", ((V)(18D))).V).V).Put("prickle", NewObj(1).Put("gasp", NewObj(9).Put("curl", ((V)(1D))).Put("sq", ((V)(0.24))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).V).V).Put("nibbles", NewObj(2).Put("laugh", NewObj(1).Put("puff", ((V)(0.8))).V).Put("gasp", NewObj(1).Put("puff", ((V)(1D))).V).V).Put("quill", NewObj(1).Put("gasp", NewObj(1).Put("blush", ((V)(1D))).V).V).Put("poppy", NewObj(1).Put("cheer", NewObj(2).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).V).V).Put("duchess", NewObj(2).Put("laugh", NewObj(3).Put("sqz", ((V)(0.3))).Put("close", ((V)(0.5))).Put("open", ((V)(0.25))).V).Put("aww", NewObj(1).Put("tongue", ((V)(0D))).V).V).Put("mamapaws", NewObj(2).Put("aww", NewObj(1).Put("close", ((V)(0.7))).V).Put("nz", NewObj(1).Put("wag", ((V)(12D))).V).V).Put("nimbo", NewObj(2).Put("awwFx", Arr(((V)("drop")), ((V)("body")), ((V)(4D)))).Put("gasp", NewObj(1).Put("sq", ((V)(0.24))).V).V).Put("lumi", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("head")), ((V)(5D)))).V).Put("bubbly", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("body")), ((V)(4D)))).V).Put("twinkle", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("body")), ((V)(6D)))).V).Put("zappi", NewObj(3).Put("gasp", NewObj(1).Put("zap", ((V)(1D))).V).Put("cheer", NewObj(1).Put("zap", ((V)(0.7))).V).Put("cheerFx", Arr(((V)("spark")), ((V)("body")), ((V)(6D)))).V).Put("plip", NewObj(1).Put("awwFx", Arr(((V)("drop")), ((V)("head")), ((V)(2D)))).V).Put("breeze", NewObj(2).Put("gasp", NewObj(1).Put("puff", ((V)(0.6))).V).Put("cheerFx", Arr(((V)("gust")), ((V)("head")))).V).Put("dusty", NewObj(1).Put("cheerFx", Arr(((V)("dust")), ((V)("body")), ((V)(4D)))).V).Put("aurora", NewObj(2).Put("cheer", NewObj(1).Put("spout", ((V)(1D))).V).Put("cheerFx", Arr(((V)("drop")), ((V)("head")), ((V)(4D)))).V).Put("mallow", NewObj(1).Put("aww", NewObj(1).Put("sq", ((V)(0.26))).V).V).Put("bao", NewObj(1).Put("cheerFx", Arr(((V)("steam")), ((V)("head")))).V).Put("dunkie", NewObj(1).Put("cheerFx", Arr(((V)("sprinkle")), ((V)("head")))).V).Put("frybo", NewObj(2).Put("cheer", NewObj(1).Put("fw", ((V)(1D))).V).Put("gasp", NewObj(1).Put("fw", ((V)(0.6))).V).V).Put("bunbun", NewObj(2).Put("gasp", NewObj(1).Put("split", ((V)(0.5))).V).Put("cheer", NewObj(1).Put("split", ((V)(0.3))).V).V).Put("choco", NewObj(1).Put("aww", NewObj(1).Put("melt", ((V)(0.4))).V).V).Put("scoop", NewObj(2).Put("laughA", NewObj(1).Put("chb", ((V)(1D))).V).Put("laughB", NewObj(1).Put("chb", ((V)(0D))).V).V).Put("boba", NewObj(1).Put("cheer", NewObj(1).Put("slurp", ((V)(0.6))).V).V).Put("chefbun", NewObj(0).V).Put("pip", NewObj(0).V).Put("jelli", NewObj(2).Put("laughA", NewObj(1).Put("sq", ((V)(0.2))).V).Put("laughB", NewObj(1).Put("sq", ((V)(0.02))).V).V).Put("finn", NewObj(3).Put("laughA", NewObj(1).Put("wag", ((V)(24D))).V).Put("laughB", NewObj(1).Put("wag", ((V)((-24D)))).V).Put("cheerFx", Arr(((V)("drop")), ((V)("body")), ((V)(4D)))).V).Put("sealy", NewObj(1).Put("clap", NewObj(1).Put("open", ((V)(0.5))).V).V).Put("puff", NewObj(1).Put("gasp", NewObj(2).Put("blo", ((V)(0.8))).Put("puff", ((V)(0.8))).V).V).Put("shelly", NewObj(1).Put("gasp", NewObj(1).Put("hid", ((V)(0.85))).V).V).Put("octo", NewObj(2).Put("gasp", NewObj(1).Put("ocl", ((V)(1D))).V).Put("cheer", NewObj(1).Put("osp", ((V)(1D))).V).V).Put("marina", NewObj(1).Put("cheer", NewObj(1).Put("tlf", ((V)(0.7))).V).V).Put("pearl", NewObj(2).Put("cheer", NewObj(1).Put("glow", ((V)(1D))).V).Put("cheerFx", Arr(((V)("spark")), ((V)("head")), ((V)(4D)))).V).Put("pina", NewObj(1).Put("cheer", NewObj(1).Put("crw", ((V)(1D))).V).V).Put("avo", NewObj(1).Put("gasp", NewObj(1).Put("pp", ((V)(0.4))).V).V).Put("berri", NewObj(1).Put("gasp", NewObj(1).Put("stw", ((V)(1D))).V).V).Put("lemmy", NewObj(1).Put("aww", NewObj(1).Put("sqz", ((V)(1D))).V).V).Put("kiwi", NewObj(1).Put("gasp", NewObj(1).Put("fzz", ((V)(1D))).V).V).Put("melo", NewObj(2).Put("laughA", NewObj(1).Put("sdj", ((V)(1D))).V).Put("laughB", NewObj(1).Put("sdj", ((V)(0D))).V).V).Put("peachy", NewObj(1).Put("aww", NewObj(1).Put("blush", ((V)(1D))).V).V).Put("pitaya", NewObj(1).Put("gasp", NewObj(2).Put("brf", ((V)(1D))).Put("wsp", ((V)(0.8))).V).V).Put("tutti", NewObj(2).Put("cheer", NewObj(1).Put("wfl", ((V)(1D))).V).Put("cheerFx", Arr(((V)("dust")), ((V)("body")), ((V)(3D)))).V).Put("kiko", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("head")), ((V)(3D)))).V).Put("teddy", NewObj(1).Put("aww", NewObj(1).Put("close", ((V)(0.6))).V).V).Put("hoot", NewObj(1).Put("gasp", NewObj(2).Put("tfl", ((V)(1D))).Put("wide", ((V)(1D))).V).V).Put("leo", NewObj(2).Put("gasp", NewObj(1).Put("mfl", ((V)(1D))).V).Put("cheer", NewObj(1).Put("mfl", ((V)(0.7))).V).V).Put("panko", NewObj(0).V).Put("acorn", NewObj(1).Put("gasp", NewObj(1).Put("tfl", ((V)(1D))).V).V).Put("fawn", NewObj(1).Put("gasp", NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).V).V).Put("moss", NewObj(2).Put("laughA", NewObj(1).Put("cb", ((V)(1D))).V).Put("laughB", NewObj(1).Put("cb", ((V)(0D))).V).V).Put("sprout", NewObj(1).Put("cheer", NewObj(1).Put("blm", ((V)(1D))).V).V).Put("hana", NewObj(1).Put("gasp", NewObj(2).Put("flL", ((V)(1D))).Put("flR", ((V)(1D))).V).V).Put("boo", NewObj(1).Put("gasp", NewObj(1).Put("gho", ((V)(0.5))).V).V).Put("pixie", NewObj(2).Put("cheer", NewObj(1).Put("wfl", ((V)(1D))).V).Put("cheerFx", Arr(((V)("dust")), ((V)("body")), ((V)(4D)))).V).Put("floof", NewObj(1).Put("gasp", NewObj(1).Put("fzz", ((V)(1D))).V).V).Put("unibun", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("head")), ((V)(5D)))).V).Put("gumdrop", NewObj(2).Put("laughA", NewObj(1).Put("jig", ((V)(1D))).V).Put("laughB", NewObj(1).Put("jig", ((V)(0.3))).V).V).Put("ember", NewObj(2).Put("gasp", NewObj(1).Put("cfl", ((V)(1D))).V).Put("cheer", NewObj(1).Put("cfl", ((V)(1D))).V).V).Put("drako", NewObj(2).Put("gasp", NewObj(1).Put("wsp", ((V)(1D))).V).Put("cheer", NewObj(2).Put("wsp", ((V)(1D))).Put("wfl", ((V)(1D))).V).V).Put("jinni", NewObj(1).Put("cheer", NewObj(2).Put("glo", ((V)(1D))).Put("gwh", ((V)(1D))).V).V).Put("cuppy", NewObj(1).Put("cheerFx", Arr(((V)("sprinkle")), ((V)("head")))).V).Put("chip", NewObj(0).V).Put("twisty", NewObj(0).V).Put("crois", NewObj(0).V).Put("maca", NewObj(0).V).Put("puddi", NewObj(1).Put("laughA", NewObj(1).Put("sq", ((V)(0.2))).V).V).Put("mochi", NewObj(1).Put("aww", NewObj(1).Put("sq", ((V)(0.24))).V).V).Put("cakey", NewObj(0).V).Put("sugarplum", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("head")), ((V)(3D)))).V).Put("gourdy", NewObj(0).V).Put("batty", NewObj(1).Put("gasp", NewObj(2).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).V).V).Put("kernel", NewObj(0).V).Put("hexie", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("head")), ((V)(4D)))).V).Put("mumbles", NewObj(0).V).Put("hocus", NewObj(1).Put("cheerFx", Arr(((V)("spark")), ((V)("body")), ((V)(4D)))).V).Put("countsquishula", NewObj(1).Put("gasp", NewObj(3).Put("armL", ((V)(90D))).Put("hLy", ((V)((-10D)))).Put("hLx", ((V)(6D))).V).V).V;
WBEAT_30 = NewObj(7).Put("leanin", Fn((V _self2518, int _argc2519, V t_2525, V X_2526, V _a2523, V _a2524, V[] _rest2520) => {
V B_2527 = default;
if (_self2518.IsNullish) _self2518 = GlobalV;
B_2527 = Get(t_2525, "B");
Invoke(Invoke(Invoke(Invoke(t_2525, "to", ((V)(700D)), Call(o_10, V.Undef, NewObj(6).Put("pitch", ((V)((ToNum((Get(B_2527, "pitch") is var _t2528 && Truthy(_t2528) ? _t2528 : ((V)(0D)))) - 0.14)))).Put("sq", Add((Get(B_2527, "sq") is var _t2529 && Truthy(_t2529) ? _t2529 : ((V)(0D))), ((V)(0.03)))).Put("wide", ((V)(0.5))).Put("mw", ((V)(0.6))).Put("open", ((V)(0.12))).Put("ly", ((V)(0.1))).V, Get(X_2526, "lean")), ((V)("io"))), "wait", ((V)(1300D))), "to", ((V)(240D)), NewObj(2).Put("wide", ((V)(0.9))).Put("open", ((V)(0.3))).V, ((V)("o"))), "wait", ((V)(500D)));
return Invoke(t_2525, "back", ((V)(600D)));
return default;
}, 2, "leanin", false)).Put("laugh", Fn((V _self2530, int _argc2531, V t_2537, V X_2538, V _a2535, V _a2536, V[] _rest2532) => {
V B_2539 = default;
V L_2540 = default;
V Q_2541 = default;
if (_self2530.IsNullish) _self2530 = GlobalV;
B_2539 = Get(t_2537, "B");
L_2540 = (Get(B_2539, "lift") is var _t2542 && Truthy(_t2542) ? _t2542 : ((V)(0D)));
Q_2541 = (Get(B_2539, "sq") is var _t2543 && Truthy(_t2543) ? _t2543 : ((V)(0D)));
Invoke(Invoke(t_2537, "to", ((V)(220D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(7D)), ((V)(5D))), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.55))).Put("sqz", ((V)(0.8))).V, Get(X_2538, "laugh")), ((V)("o"))), "osc", ((V)(1500D)), ((V)(7D)), Call(o_10, V.Undef, NewObj(3).Put("sq", Add(Q_2541, ((V)(0.045)))).Put("lift", Add(L_2540, ((V)(0.6)))).Put("htilt", ((V)(4D))).V, Get(X_2538, "laughA")), Call(o_10, V.Undef, NewObj(3).Put("sq", ((V)((ToNum(Q_2541) - 0.01)))).Put("lift", L_2540).Put("htilt", ((V)((-4D)))).V, Get(X_2538, "laughB")), ((V)("o")));
return Invoke(t_2537, "back", ((V)(450D)));
return default;
}, 2, "laugh", false)).Put("gasp", Fn((V _self2544, int _argc2545, V t_2551, V X_2552, V _a2549, V _a2550, V[] _rest2546) => {
V B_2553 = default;
V L_2554 = default;
V Q_2555 = default;
if (_self2544.IsNullish) _self2544 = GlobalV;
B_2553 = Get(t_2551, "B");
L_2554 = (Get(B_2553, "lift") is var _t2556 && Truthy(_t2556) ? _t2556 : ((V)(0D)));
Q_2555 = (Get(B_2553, "sq") is var _t2557 && Truthy(_t2557) ? _t2557 : ((V)(0D)));
Invoke(Invoke(Invoke(Invoke(t_2551, "to", ((V)(170D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(10D)), ((V)((-12D)))), NewObj(8).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.5))).Put("lift", Add(L_2554, ((V)(1.4)))).Put("sq", ((V)((ToNum(Q_2555) - 0.05)))).Put("pitch", Add((Get(B_2553, "pitch") is var _t2558 && Truthy(_t2558) ? _t2558 : ((V)(0D))), ((V)(0.1)))).V, Get(X_2552, "gasp")), ((V)("o"))), "wait", ((V)(1000D))), "to", ((V)(500D)), NewObj(3).Put("wide", ((V)(0.4))).Put("open", ((V)(0.2))).Put("lift", L_2554).V, ((V)("io"))), "wait", ((V)(300D)));
return Invoke(t_2551, "back", ((V)(520D)));
return default;
}, 2, "gasp", false)).Put("popcorn", Fn((V _self2559, int _argc2560, V t_2566, V X_2567, V two_2568, V _a2565, V[] _rest2561) => {
V B_2569 = default;
V p0_2570 = default;
if (_self2559.IsNullish) _self2559 = GlobalV;
B_2569 = Get(t_2566, "B");
p0_2570 = (Get(B_2569, "pitch") is var _t2571 && Truthy(_t2571) ? _t2571 : ((V)(0D)));
if (SEqS(two_2568, "lap")) {
{
double i_2572 = 0;
i_2572 = 0D;
while (true) {
if (!((i_2572 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2566, "to", ((V)(340D)), NewObj(4).Put("pitch", ((V)((ToNum(p0_2570) - 0.24)))).Put("ly", ((V)(0.7))).Put("open", ((V)(0.3))).Put("sq", Add((Get(B_2569, "sq") is var _t2575 && Truthy(_t2575) ? _t2575 : ((V)(0D))), ((V)(0.03)))).V, ((V)("io"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("open", ((V)(0.25))).Put("puff", ((V)(0.5))).V, NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.2))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("mouth"))), "to", ((V)(320D)), NewObj(5).Put("pitch", p0_2570).Put("ly", ((V)(0D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).Put("sq", (Get(B_2569, "sq") is var _t2574 && Truthy(_t2574) ? _t2574 : ((V)(0D)))).V, ((V)("io"))), "wait", ((V)(300D)));
i_2572++;
}
}
} else {
if (Truthy(two_2568)) {
Invoke(t_2566, "to", ((V)(320D)), Call(both_13, V.Undef, ((V)(7D)), ((V)((-1D)))));
{
double i_2576 = 0;
i_2576 = 0D;
while (true) {
if (!((i_2576 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2566, "to", ((V)(320D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(9D)), ((V)((-12D)))), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("open", ((V)(0.35))).Put("pitch", ((V)((ToNum(p0_2570) - 0.05)))).V), ((V)("io"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("open", ((V)(0.25))).Put("puff", ((V)(0.5))).V, NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.2))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("mouth"))), "to", ((V)(300D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(7D)), ((V)((-1D)))), NewObj(5).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).Put("pitch", p0_2570).V), ((V)("io"))), "wait", ((V)(240D)));
i_2576++;
}
}
} else {
Invoke(t_2566, "to", ((V)(320D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)(5D)), ((V)(1D))), NewObj(1).Put("armL", ((V)(8D))).V));
{
double i_2578 = 0;
i_2578 = 0D;
while (true) {
if (!((i_2578 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2566, "to", ((V)(240D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(13D)), ((V)(1D))), NewObj(2).Put("armR", ((V)(6D))).Put("ly", ((V)(0.5))).V), ((V)("io"))), "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-14D)))), NewObj(3).Put("armR", ((V)(36D))).Put("open", ((V)(0.35))).Put("ly", ((V)(0D))).V), ((V)("io"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("open", ((V)(0.25))).Put("puff", ((V)(0.5))).V, NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.2))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("mouth"))), "to", ((V)(260D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(6D)), ((V)(3D))), NewObj(3).Put("armR", ((V)(0D))).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(200D)));
i_2578++;
}
}
}
}
Invoke(t_2566, "to", ((V)(200D)), NewObj(2).Put("smile", ((V)(1D))).Put("hap", ((V)(0.5))).V);
return Invoke(t_2566, "back", ((V)(420D)));
return default;
}, 3, "popcorn", false)).Put("clap", Fn((V _self2580, int _argc2581, V t_2587, V X_2588, V _a2585, V _a2586, V[] _rest2582) => {
if (_self2580.IsNullish) _self2580 = GlobalV;
Invoke(Invoke(Invoke(t_2587, "to", ((V)(260D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(11D)), ((V)((-5D)))), NewObj(5).Put("armL", ((V)(28D))).Put("armR", ((V)(28D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, Get(X_2588, "clap")), ((V)("o"))), "osc", ((V)(1300D)), ((V)(6D)), NewObj(2).Put("hLx", ((V)(14D))).Put("hRx", ((V)((-14D)))).V, NewObj(2).Put("hLx", ((V)(8D))).Put("hRx", ((V)((-8D)))).V, ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
return Invoke(t_2587, "back", ((V)(420D)));
return default;
}, 2, "clap", false)).Put("aww", Fn((V _self2589, int _argc2590, V t_2596, V X_2597, V _a2594, V _a2595, V[] _rest2591) => {
if (_self2589.IsNullish) _self2589 = GlobalV;
Invoke(Invoke(t_2596, "to", ((V)(600D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(8D)), ((V)((-5D)))), NewObj(7).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("close", ((V)(0.35))).Put("frown", ((V)(0.5))).Put("teary", ((V)(0.6))).Put("htilt", ((V)(7D))).Put("mw", ((V)(0.6))).V, Get(X_2597, "aww")), ((V)("io"))), "wait", ((V)(700D)));
if (Truthy(Get(X_2597, "awwFx"))) {
InvokeSpread(t_2596, "fx", new ArrBuilder().Spread(Get(X_2597, "awwFx")).V);
}
Invoke(Invoke(t_2596, "wait", ((V)(600D))), "to", ((V)(400D)), NewObj(3).Put("teary", ((V)(0.2))).Put("frown", ((V)(0D))).Put("smile", ((V)(0.6))).V, ((V)("io")));
return Invoke(t_2596, "back", ((V)(600D)));
return default;
}, 2, "aww", false)).Put("cheer", Fn((V _self2598, int _argc2599, V t_2605, V X_2606, V _a2603, V _a2604, V[] _rest2600) => {
V B_2607 = default;
V L_2608 = default;
V Q_2609 = default;
if (_self2598.IsNullish) _self2598 = GlobalV;
B_2607 = Get(t_2605, "B");
L_2608 = (Get(B_2607, "lift") is var _t2610 && Truthy(_t2610) ? _t2610 : ((V)(0D)));
Q_2609 = (Get(B_2607, "sq") is var _t2611 && Truthy(_t2611) ? _t2611 : ((V)(0D)));
Invoke(t_2605, "to", ((V)(260D)), Call(o_10, V.Undef, NewObj(10).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("hLx", ((V)((-6D)))).Put("hRx", ((V)(6D))).Put("hLy", ((V)((-6D)))).Put("hRy", ((V)((-6D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.55))).Put("wide", ((V)(0.3))).V, Get(X_2606, "cheer")), ((V)("o")));
if (Truthy(Get(X_2606, "cheerFx"))) {
InvokeSpread(t_2605, "fx", new ArrBuilder().Spread(Get(X_2606, "cheerFx")).V);
}
{
double i_2612 = 0;
i_2612 = 0D;
while (true) {
if (!((i_2612 < 2D))) break;
Invoke(Invoke(Invoke(t_2605, "to", ((V)(140D)), NewObj(2).Put("sq", Add(Q_2609, ((V)(0.08)))).Put("lift", L_2608).V, ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)((ToNum(Q_2609) - 0.05)))).Put("lift", Add(L_2608, ((V)(2.6)))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(2).Put("sq", Q_2609).Put("lift", L_2608).V, ((V)("i")));
i_2612++;
}
}
return Invoke(t_2605, "back", ((V)(450D)));
return default;
}, 2, "cheer", false)).V;
BUCKET_31 = ((V)(JsStrBuf.Begin().S("<path d=\"M-4.6 -2.4L4.6 -2.4L3.5 5.2L-3.5 5.2Z\" fill=\"#fffaf0\" stroke=\"#c9b9a0\" stroke-width=\"0.35\"/><path d=\"M-2.6 -2.4L-1.2 -2.4L-1 5.2L-2.1 5.2Z M1.2 -2.4L2.6 -2.4L2.1 5.2L1 5.2Z\" fill=\"#e8483c\"/><path d=\"M1.6 -2.4L4.6 -2.4L3.5 5.2L1.3 5.2Z\" fill=\"#3a1d10\" opacity=\"0.12\"/>").V(Invoke(Invoke(Arr(Arr(((V)((-3D))), ((V)((-3D))), ((V)(1.6))), Arr(((V)((-0.8))), ((V)((-3.9))), ((V)(1.8))), Arr(((V)(1.6)), ((V)((-3.2))), ((V)(1.6))), Arr(((V)(3.4)), ((V)((-2.7))), ((V)(1.2))), Arr(((V)(0.6)), ((V)((-5.2))), ((V)(1.3))), Arr(((V)((-2.2))), ((V)((-4.7))), ((V)(1.2)))), "map", Fn((V _arrowThis2627, int _argc2614, V _a2616, V _a2617, V _a2618, V _a2619, V[] _rest2615) => {
V x_2622 = default;
V y_2624 = default;
V r_2626 = default;
{ V _t2620 = ListOf(_a2616);
{ V _t2621 = GetIdx(_t2620, 0D);
x_2622 = _t2621; }
{ V _t2623 = GetIdx(_t2620, 1D);
y_2624 = _t2623; }
{ V _t2625 = GetIdx(_t2620, 2D);
r_2626 = _t2625; }
}
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(x_2622).S("\" cy=\"").V(y_2624).S("\" r=\"").V(r_2626).S("\" fill=\"#fff4cf\" stroke=\"#e2b85e\" stroke-width=\"0.3\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).S("<path d=\"M-4.9 -2.6L4.9 -2.6L4.7 -1.6L-4.7 -1.6Z\" fill=\"#e8483c\"/>").End()));
popProp_32 = Fn((V _arrowThis2637, int _argc2628, V win_2634, V loop_2635, V two_2636, V _a2633, V[] _rest2629) => {
return Fn((V _arrowThis2646, int _argc2638, V I_2644, V tt_2645, V _a2642, V _a2643, V[] _rest2639) => {
V W_2647 = default;
double tl_2648 = 0;
double k_2649 = 0;
V mid_2650 = default;
V x_2651 = default;
V y_2652 = default;
W_2647 = Get(I_2644, "W");
if (((!(Truthy(W_2647)) || !(Truthy(Get(W_2647, "pawL")))) || !(Truthy(Get(win_2634, "length"))))) {
return ((V)(""));
}
tl_2648 = (ToNum(tt_2645) % ToNum(loop_2635));
k_2649 = 0D;
Invoke(win_2634, "forEach", Fn((V _arrowThis2664, int _argc2653, V _a2655, V _a2656, V _a2657, V _a2658, V[] _rest2654) => {
V a_2661 = default;
V b_2663 = default;
{ V _t2659 = ListOf(_a2655);
{ V _t2660 = GetIdx(_t2659, 0D);
a_2661 = _t2660; }
{ V _t2662 = GetIdx(_t2659, 1D);
b_2663 = _t2662; }
}
if ((Gt(((V)(tl_2648)), a_2661) && Lt(((V)(tl_2648)), b_2663))) {
k_2649 = Max(k_2649, Min(ToNum(Call(ss_25, V.Undef, ((V)(((tl_2648 - ToNum(a_2661)) / 260D))))), ToNum(Call(ss_25, V.Undef, ((V)(((ToNum(b_2663) - tl_2648) / 260D)))))));
}
return default;
}, 1, "", true));
if ((k_2649 < 0.01)) {
return ((V)(""));
}
mid_2650 = (two_2636 is var _t2665 && Truthy(_t2665) ? _t2665 : Get(I_2644, "foodMid"));
x_2651 = (Truthy(mid_2650) ? ((V)((ToNum(Add(GetIdx(Get(W_2647, "pawL"), 0D), GetIdx(Get(W_2647, "pawR"), 0D))) / 2D))) : GetIdx(Get(W_2647, "pawL"), 0D));
y_2652 = Add((Truthy(mid_2650) ? ((V)((ToNum(Add(GetIdx(Get(W_2647, "pawL"), 1D), GetIdx(Get(W_2647, "pawR"), 1D))) / 2D))) : GetIdx(Get(W_2647, "pawL"), 1D)), ((V)((SEqS(two_2636, "lap") ? 5D : 0D))));
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Invoke(x_2651, "toFixed", ((V)(2D)))).S(" ").V(Invoke(((V)((ToNum(y_2652) - 4D))), "toFixed", ((V)(2D)))).S(") scale(").V(Invoke(((V)((k_2649 * 2.3))), "toFixed", ((V)(3D)))).S(")\">").V(BUCKET_31).S("</g>").End()));
return default;
}, 2, "", true);
}, 3, "", true);
PROF_35 = NewObj(0).V;
TAU_37 = (System.Math.PI * 2D);
r2_38 = Fn((V _arrowThis2673, int _argc2666, V v_2672, V _a2669, V _a2670, V _a2671, V[] _rest2667) => {
return ((V)((Round((ToNum(v_2672) * 100D)) / 100D)));
}, 1, "", true);
cl_39 = Fn((V _arrowThis2683, int _argc2674, V v_2680, V a_2681, V b_2682, V _a2679, V[] _rest2675) => {
return (Lt(v_2680, a_2681) ? a_2681 : (Gt(v_2680, b_2682) ? b_2682 : v_2680));
}, 3, "", true);
LIE0_40 = Call(o_10, V.Undef, NewObj(19).Put("sit", ((V)(1D))).Put("sq", ((V)(0.15))).Put("lift", ((V)((-2.6)))).Put("pitch", ((V)(0.34))).Put("close", ((V)(1D))).Put("mw", ((V)(0.7))).Put("smile", ((V)(0.2))).Put("htilt", ((V)(7D))).Put("tilt", ((V)((-3D)))).Put("armL", ((V)(6D))).Put("armR", ((V)(6D))).Put("footL", ((V)(0.6))).Put("footR", ((V)(0.6))).Put("lean", ((V)(0D))).Put("hap", ((V)(0D))).Put("open", ((V)(0D))).Put("qk", ((V)(1D))).Put("zz", ((V)(1D))).Put("drm", ((V)(0D))).V, Call(both_13, V.Undef, ((V)(5D)), ((V)((-2D)))));
CURL0_41 = Call(o_10, V.Undef, NewObj(20).Put("sit", ((V)(1D))).Put("sq", ((V)(0.24))).Put("lift", ((V)((-5.2)))).Put("pitch", ((V)((-0.26)))).Put("close", ((V)(1D))).Put("mw", ((V)(0.7))).Put("smile", ((V)(0.25))).Put("htilt", ((V)(12D))).Put("tilt", ((V)(6D))).Put("turn", ((V)(0.26))).Put("curl", ((V)(0.9))).Put("lean", ((V)(0.6))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("hap", ((V)(0D))).Put("open", ((V)(0D))).Put("zz", ((V)(1D))).Put("drm", ((V)(0D))).V, Call(both_13, V.Undef, ((V)(7D)), ((V)(4D))));
shade_42 = Fn((V _arrowThis2692, int _argc2684, V h_2690, V k_2691, V _a2688, V _a2689, V[] _rest2685) => {
double n_2693 = 0;
if (!(Truthy(Invoke(NewRegExp(RX0, "^#[0-9a-f]{6}$", "i"), "test", (h_2690 is var _t2694 && Truthy(_t2694) ? _t2694 : ((V)(""))))))) {
return ((V)((LtN(k_2691, 1D) ? "#56709a" : "#a9c2e8")));
}
n_2693 = ParseInt(Invoke(h_2690, "slice", ((V)(1D))), ((V)(16D)));
return ((V)(JsStrBuf.Begin().S("#").V(Invoke(Invoke(Arr(((V)(((double)(ToInt32(n_2693) >> (int)(ToUint32(16D) & 31))))), ((V)(((double)(ToInt32(((double)(ToInt32(n_2693) >> (int)(ToUint32(8D) & 31)))) & ToInt32(255D))))), ((V)(((double)(ToInt32(n_2693) & ToInt32(255D)))))), "map", Fn((V _arrowThis2702, int _argc2695, V c_2701, V _a2698, V _a2699, V _a2700, V[] _rest2696) => {
return Invoke(Invoke(((V)(Round(ToNum(Call(cl_39, V.Undef, (LtN(k_2691, 1D) ? ((V)((ToNum(c_2701) * ToNum(k_2691)))) : Add(c_2701, ((V)(((255D - ToNum(c_2701)) * (ToNum(k_2691) - 1D)))))), ((V)(0D)), ((V)(255D))))))), "toString", ((V)(16D))), "padStart", ((V)(2D)), ((V)("0")));
}, 1, "", true)), "join", ((V)("")))).End()));
return default;
}, 2, "", true);
ci_43 = Fn((V _arrowThis2714, int _argc2703, V x_2709, V y_2710, V r_2711, V f_2712, V[] _rest2704) => {
V s_2713 = default;
s_2713 = (_argc2703 > 4 ? _rest2704[0] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<circle cx=\"").V(x_2709).S("\" cy=\"").V(y_2710).S("\" r=\"").V(r_2711).S("\" fill=\"").V(f_2712).S("\"").S((Truthy(s_2713) ? JsStrBuf.Begin().S(" stroke=\"").V(s_2713).S("\" stroke-width=\"0.4\"").End() : "")).S("/>").End()));
}, 5, "", true);
pa_44 = Fn((V _arrowThis2725, int _argc2715, V d_2721, V f_2722, V s_2723, V w_2724, V[] _rest2716) => {
return ((V)(JsStrBuf.Begin().S("<path d=\"").V(d_2721).S("\" fill=\"").V((f_2722 is var _t2726 && Truthy(_t2726) ? _t2726 : ((V)("none")))).S("\"").S((Truthy(s_2723) ? JsStrBuf.Begin().S(" stroke=\"").V(s_2723).S("\" stroke-width=\"").V((w_2724 is var _t2727 && Truthy(_t2727) ? _t2727 : ((V)(0.4)))).S("\" stroke-linecap=\"round\" stroke-linejoin=\"round\"").End() : "")).S("/>").End()));
}, 4, "", true);
ICON_45 = NewObj(31).Put("fish", Add(Add(Call(pa_44, V.Undef, ((V)("M-4 0Q-1-3.2 2.4 0Q-1 3.2-4 0Z")), ((V)("#f2924a")), ((V)("#c96a2a"))), Call(pa_44, V.Undef, ((V)("M2 0L4.6-2.2V2.2Z")), ((V)("#f2924a")), ((V)("#c96a2a")))), Call(ci_43, V.Undef, ((V)((-2.2))), ((V)((-0.5))), ((V)(0.5)), ((V)("#3a2a20"))))).Put("bone", Add(Add(Call(pa_44, V.Undef, ((V)("M-2.6-0.9H2.6V0.9H-2.6Z")), ((V)("#fff4dc"))), Invoke(Invoke(Arr(Arr(((V)((-3D))), ((V)((-0.9)))), Arr(((V)((-3D))), ((V)(0.9))), Arr(((V)(3D)), ((V)((-0.9)))), Arr(((V)(3D)), ((V)(0.9)))), "map", Fn((V _arrowThis2739, int _argc2728, V _a2730, V _a2731, V _a2732, V _a2733, V[] _rest2729) => {
V x_2736 = default;
V y_2738 = default;
{ V _t2734 = ListOf(_a2730);
{ V _t2735 = GetIdx(_t2734, 0D);
x_2736 = _t2735; }
{ V _t2737 = GetIdx(_t2734, 1D);
y_2738 = _t2737; }
}
return Call(ci_43, V.Undef, x_2736, y_2738, ((V)(1.2)), ((V)("#fff4dc")), ((V)("#c9b48a")));
}, 1, "", true)), "join", ((V)("")))), Call(pa_44, V.Undef, ((V)("M-2.6-0.9H2.6M-2.6 0.9H2.6")), V.Null, ((V)("#c9b48a"))))).Put("apple", Add(Add(Add(Call(ci_43, V.Undef, ((V)(0D)), ((V)(0.8)), ((V)(3.2)), ((V)("#e8483c")), ((V)("#b8302a"))), Call(pa_44, V.Undef, ((V)("M0-2.2Q0.4-3.6 1-4")), V.Null, ((V)("#6a4a2a")), ((V)(0.6)))), Call(pa_44, V.Undef, ((V)("M0.4-3Q2.4-4.2 3-2.6Q1.6-2 0.4-3Z")), ((V)("#7cc35a")))), Call(ci_43, V.Undef, ((V)((-1.2))), ((V)((-0.4))), ((V)(0.8)), ((V)("#fff"))))).Put("nut", Add(Add(Call(pa_44, V.Undef, ((V)("M-3-0.4Q0-3.4 3-0.4Z")), ((V)("#8a5a2c"))), Call(pa_44, V.Undef, ((V)("M-2.6-0.4Q-2.4 3.6 0 4Q2.4 3.6 2.6-0.4Z")), ((V)("#d39a5a")), ((V)("#a86b36")))), Call(pa_44, V.Undef, ((V)("M0-2.4V-3.6")), V.Null, ((V)("#6a4a2a")), ((V)(0.6))))).Put("flower", Add(Invoke(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D))), "map", Fn((V _arrowThis2747, int _argc2740, V i_2746, V _a2743, V _a2744, V _a2745, V[] _rest2741) => {
return Call(ci_43, V.Undef, Call(r2_38, V.Undef, ((V)((FdLibm.Cos(((ToNum(i_2746) * 1.2566) - 1.57)) * 2.3)))), Call(r2_38, V.Undef, ((V)((FdLibm.Sin(((ToNum(i_2746) * 1.2566) - 1.57)) * 2.3)))), ((V)(1.6)), ((V)("#f7a8c4")), ((V)("#d9789a")));
}, 1, "", true)), "join", ((V)(""))), Call(ci_43, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(1.3)), ((V)("#ffd84a")), ((V)("#d9a62a"))))).Put("carrot", Add(Call(pa_44, V.Undef, ((V)("M-1.9-1.6L1.9-1.6L0 4.4Z")), ((V)("#f28a1e")), ((V)("#c96a10"))), Call(pa_44, V.Undef, ((V)("M0-1.6L-1.4-4.2M0-1.6L0-4.6M0-1.6L1.4-4.2")), V.Null, ((V)("#5fae4a")), ((V)(0.9))))).Put("crown", Add(Call(pa_44, V.Undef, ((V)("M-4 2.4L-4-1.6L-2-0.2L0-2.8L2-0.2L4-1.6L4 2.4Z")), ((V)("#ffd24a")), ((V)("#c9962a"))), Call(ci_43, V.Undef, ((V)(0D)), ((V)(0.8)), ((V)(0.8)), ((V)("#e8483c"))))).Put("heart", Call(pa_44, V.Undef, ((V)("M0 3.4C-4.6 0.4-4-3.6-1.6-3.2C-0.6-3 0-2.2 0-1.6C0-2.2 0.6-3 1.6-3.2C4-3.6 4.6 0.4 0 3.4Z")), ((V)("#ff6f86")), ((V)("#d9485e")))).Put("sun", Add(Call(pa_44, V.Undef, Invoke(Invoke(Arr(((V)(0D)), ((V)(1D)), ((V)(2D)), ((V)(3D)), ((V)(4D)), ((V)(5D)), ((V)(6D)), ((V)(7D))), "map", Fn((V _arrowThis2755, int _argc2748, V i_2754, V _a2751, V _a2752, V _a2753, V[] _rest2749) => {
double a_2756 = 0;
a_2756 = (ToNum(i_2754) * 0.785);
return ((V)(JsStrBuf.Begin().S("M").V(Call(r2_38, V.Undef, ((V)((FdLibm.Cos(a_2756) * 3D))))).S(" ").V(Call(r2_38, V.Undef, ((V)((FdLibm.Sin(a_2756) * 3D))))).S("L").V(Call(r2_38, V.Undef, ((V)((FdLibm.Cos(a_2756) * 4.4))))).S(" ").V(Call(r2_38, V.Undef, ((V)((FdLibm.Sin(a_2756) * 4.4))))).End()));
return default;
}, 1, "", true)), "join", ((V)(""))), V.Null, ((V)("#f2a81e")), ((V)(0.8))), Call(ci_43, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(2.3)), ((V)("#ffcc3a")), ((V)("#e2961e"))))).Put("star", Call(pa_44, V.Undef, ((V)("M0-4.2L1.2-1.4L4.2-1.2L1.9 0.8L2.6 3.8L0 2.2L-2.6 3.8L-1.9 0.8L-4.2-1.2L-1.2-1.4Z")), ((V)("#ffd24a")), ((V)("#d9a22a")))).Put("bubble", Add(Add(Call(ci_43, V.Undef, ((V)((-1D))), ((V)(0.6)), ((V)(2.6)), ((V)("rgba(160,220,255,0.35)")), ((V)("#5ab4f0"))), Call(ci_43, V.Undef, ((V)(2.4)), ((V)((-2D))), ((V)(1.3)), ((V)("rgba(160,220,255,0.35)")), ((V)("#5ab4f0")))), Call(ci_43, V.Undef, ((V)((-1.9))), ((V)((-0.4))), ((V)(0.6)), ((V)("#fff"))))).Put("moon", Call(pa_44, V.Undef, ((V)("M1.2-3.6A3.8 3.8 0 1 0 1.2 3.6A3 3 0 1 1 1.2-3.6Z")), ((V)("#ffe08a")), ((V)("#d9b24a")))).Put("bolt", Call(pa_44, V.Undef, ((V)("M0.8-4.2L-2.4 0.6H-0.2L-1 4.2L2.4-0.8H0.2Z")), ((V)("#ffd42a")), ((V)("#c9962a")))).Put("rainbow", Add(Add(Call(pa_44, V.Undef, ((V)("M-4 2.4A4 4 0 0 1 4 2.4")), V.Null, ((V)("#ff6a5a")), ((V)(1.1))), Call(pa_44, V.Undef, ((V)("M-2.9 2.4A2.9 2.9 0 0 1 2.9 2.4")), V.Null, ((V)("#ffd24a")), ((V)(1.1)))), Call(pa_44, V.Undef, ((V)("M-1.8 2.4A1.8 1.8 0 0 1 1.8 2.4")), V.Null, ((V)("#5ab4f0")), ((V)(1.1))))).Put("cloud", Add(Add(Add(Call(ci_43, V.Undef, ((V)((-1.8))), ((V)(0.8)), ((V)(1.9)), ((V)("#fff")), ((V)("#a9b9d0"))), Call(ci_43, V.Undef, ((V)(1.8)), ((V)(0.8)), ((V)(1.9)), ((V)("#fff")), ((V)("#a9b9d0")))), Call(ci_43, V.Undef, ((V)(0D)), ((V)((-0.4))), ((V)(2.4)), ((V)("#fff")), ((V)("#a9b9d0")))), Call(pa_44, V.Undef, ((V)("M-3.2 1.4Q0 3.2 3.2 1.4")), ((V)("#fff"))))).Put("cup", Add(Add(Call(pa_44, V.Undef, ((V)("M-2.8-1.2H2L1.6 3.2H-2.4Z")), ((V)("#c98a52")), ((V)("#8a5a2c"))), Call(pa_44, V.Undef, ((V)("M2-0.4Q3.6-0.4 3.4 1Q3.2 2 1.8 2")), V.Null, ((V)("#8a5a2c")), ((V)(0.7)))), Call(pa_44, V.Undef, ((V)("M-1.2-2.2Q-1.8-3.2-1.1-4M0.6-2.2Q0-3.2 0.7-4")), V.Null, ((V)("#b9a6c9")), ((V)(0.5))))).Put("ketchup", Add(Add(Call(pa_44, V.Undef, ((V)("M-1.8-1.2H1.8V3.8Q0 4.4-1.8 3.8Z")), ((V)("#e8483c")), ((V)("#b8302a"))), Call(pa_44, V.Undef, ((V)("M-0.8-3.8H0.8V-1.2H-0.8Z")), ((V)("#fffaf0")), ((V)("#c9b9a0")))), Call(pa_44, V.Undef, ((V)("M-1.8 0.6H1.8V1.8H-1.8Z")), ((V)("#ffd24a"))))).Put("cheese", Add(Add(Call(pa_44, V.Undef, ((V)("M-4 2.6L3.8 2.6L3.8-1.4L-4 0.4Z")), ((V)("#ffd24a")), ((V)("#d9a22a"))), Call(ci_43, V.Undef, ((V)((-1D))), ((V)(1.4)), ((V)(0.6)), ((V)("#e8b22a")))), Call(ci_43, V.Undef, ((V)(1.8)), ((V)(0.2)), ((V)(0.8)), ((V)("#e8b22a"))))).Put("cherry", Add(Add(Add(Call(pa_44, V.Undef, ((V)("M-1.6 0.6Q-0.6-2.8 1-4M1.8 1Q1.6-2 1-4")), V.Null, ((V)("#5fae4a")), ((V)(0.6))), Call(ci_43, V.Undef, ((V)((-1.8))), ((V)(1.6)), ((V)(1.8)), ((V)("#e8283c")), ((V)("#a81a2a")))), Call(ci_43, V.Undef, ((V)(2D)), ((V)(1.8)), ((V)(1.8)), ((V)("#e8283c")), ((V)("#a81a2a")))), Call(ci_43, V.Undef, ((V)((-2.4))), ((V)(1D)), ((V)(0.5)), ((V)("#fff"))))).Put("pearl", Add(Add(Call(ci_43, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(3D)), ((V)("#fff8f0")), ((V)("#c9b8d8"))), Call(ci_43, V.Undef, ((V)((-1D))), ((V)((-1D))), ((V)(0.9)), ((V)("#ffffff")))), Call(pa_44, V.Undef, ((V)("M1.2 1.6Q2.2 0.6 2 -0.6")), V.Null, ((V)("#e6d6ee")), ((V)(0.5))))).Put("cake", Add(Add(Call(pa_44, V.Undef, ((V)("M-3.8 3V-0.4L3.6-2.2V3Z")), ((V)("#f6dca8")), ((V)("#c9a46a"))), Call(pa_44, V.Undef, ((V)("M-3.8-0.4L3.6-2.2V-0.8L-3.8 1Z")), ((V)("#ff9fb6")))), Call(ci_43, V.Undef, ((V)(1.6)), ((V)((-2.8))), ((V)(0.9)), ((V)("#e8283c"))))).Put("shell", Add(Call(pa_44, V.Undef, ((V)("M0 3.2L-3.8-1Q0-4.8 3.8-1Z")), ((V)("#ffc9a8")), ((V)("#d98a6a"))), Call(pa_44, V.Undef, ((V)("M0 3.2L-1.6-3.4M0 3.2L0-3.6M0 3.2L1.6-3.4")), V.Null, ((V)("#d98a6a")), ((V)(0.35))))).Put("leaf", Add(Call(pa_44, V.Undef, ((V)("M-3.6 3Q-3.6-3.6 3.6-3.6Q3.6 3-3.6 3Z")), ((V)("#7cc35a")), ((V)("#4f8f3a"))), Call(pa_44, V.Undef, ((V)("M-3.6 3L2.4-2.4")), V.Null, ((V)("#4f8f3a"))))).Put("honey", Add(Add(Call(pa_44, V.Undef, ((V)("M-2.8-1.4H2.8V2.6Q2.8 3.8 1.6 3.8H-1.6Q-2.8 3.8-2.8 2.6Z")), ((V)("#f2b43a")), ((V)("#c9861a"))), Call(pa_44, V.Undef, ((V)("M-3-2.8H3V-1.4H-3Z")), ((V)("#a86b36")))), Call(pa_44, V.Undef, ((V)("M-1.6 0.6H1.6")), V.Null, ((V)("#fff2c0")), ((V)(0.6))))).Put("bamboo", Add(Add(Call(pa_44, V.Undef, ((V)("M-0.9-4.2H0.9V4.2H-0.9Z")), ((V)("#8fc86a")), ((V)("#5f9a4a"))), Call(pa_44, V.Undef, ((V)("M-0.9-1.2H0.9M-0.9 1.8H0.9")), V.Null, ((V)("#5f9a4a")), ((V)(0.5)))), Call(pa_44, V.Undef, ((V)("M0.9-1.2Q3.4-2.6 3.8-0.8Q2.2-0.2 0.9-1.2Z")), ((V)("#7cc35a"))))).Put("acorn", Add(Add(Call(pa_44, V.Undef, ((V)("M-3-0.6Q0-3.6 3-0.6Z")), ((V)("#8a5a2c")), ((V)("#6a4220"))), Call(pa_44, V.Undef, ((V)("M-2.6-0.6Q-2.6 3.4 0 4Q2.6 3.4 2.6-0.6Z")), ((V)("#d39a5a")), ((V)("#a86b36")))), Call(pa_44, V.Undef, ((V)("M0-2.4L0.6-3.8")), V.Null, ((V)("#6a4220")), ((V)(0.6))))).Put("drop", Add(Call(pa_44, V.Undef, ((V)("M0-4Q3 0.2 2.4 1.6A2.6 2.6 0 0 1-2.4 1.6Q-3 0.2 0-4Z")), ((V)("#5ab4f0")), ((V)("#2e86c8"))), Call(ci_43, V.Undef, ((V)((-0.9))), ((V)(0.8)), ((V)(0.6)), ((V)("#fff"))))).Put("snow", Call(pa_44, V.Undef, ((V)("M0-4V4M-3.5-2L3.5 2M-3.5 2L3.5-2M-0.9-3.2L0-2.3L0.9-3.2M-0.9 3.2L0 2.3L0.9 3.2")), V.Null, ((V)("#6aaee6")), ((V)(0.7)))).Put("candy", Add(Add(Call(pa_44, V.Undef, ((V)("M-2.2 0L-4.2-1.8V1.8Z M2.2 0L4.2-1.8V1.8Z")), ((V)("#ffb84a")), ((V)("#d9861a"))), Call(ci_43, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(2.2)), ((V)("#ff8a4a")), ((V)("#d95a2a")))), Call(pa_44, V.Undef, ((V)("M-1.4-1Q0 0.4 1.4-1")), V.Null, ((V)("#fff2d8")), ((V)(0.5))))).Put("fire", Add(Call(pa_44, V.Undef, ((V)("M0 4Q-3.4 3.4-3 0Q-2.6-2 -1-2.6Q-1.4-1 0-0.6Q0.2-3 1.8-4.2Q1.6-2 2.8-0.8Q3.6 3.2 0 4Z")), ((V)("#ff8a2a")), ((V)("#d95a10"))), Call(pa_44, V.Undef, ((V)("M0 3.4Q-1.6 3-1.3 1.2Q-1 0.4 0 0.2Q0.4 1 1.2 1.2Q1.6 3 0 3.4Z")), ((V)("#ffd24a"))))).Put("berry", Add(Add(Call(pa_44, V.Undef, ((V)("M-3-1Q0-2 3-1Q2.4 3 0 4.2Q-2.4 3-3-1Z")), ((V)("#e8483c")), ((V)("#b8302a"))), Call(pa_44, V.Undef, ((V)("M-2.4-1.2L-1-2.6L0-1.6L1-2.6L2.4-1.2Q0-0.4-2.4-1.2Z")), ((V)("#5fae4a")))), Invoke(Invoke(Arr(Arr(((V)((-1.2))), ((V)(0.6))), Arr(((V)(1D)), ((V)(0.4))), Arr(((V)(0D)), ((V)(2D))), Arr(((V)((-1.4))), ((V)(2.2))), Arr(((V)(1.3)), ((V)(2D)))), "map", Fn((V _arrowThis2768, int _argc2757, V _a2759, V _a2760, V _a2761, V _a2762, V[] _rest2758) => {
V x_2765 = default;
V y_2767 = default;
{ V _t2763 = ListOf(_a2759);
{ V _t2764 = GetIdx(_t2763, 0D);
x_2765 = _t2764; }
{ V _t2766 = GetIdx(_t2763, 1D);
y_2767 = _t2766; }
}
return Call(ci_43, V.Undef, x_2765, y_2767, ((V)(0.3)), ((V)("#ffe9a0")));
}, 1, "", true)), "join", ((V)(""))))).V;
ZB_48 = NewObj(10).Put("breathe", Fn((V _self2769, int _argc2770, V t_2776, V _a2773, V _a2774, V _a2775, V[] _rest2771) => {
V B_2777 = default;
if (_self2769.IsNullish) _self2769 = GlobalV;
B_2777 = Get(t_2776, "B");
Invoke(t_2776, "osc", ((V)(5600D)), ((V)(2D)), NewObj(2).Put("sq", Add(Get(B_2777, "sq"), ((V)(0.05)))).Put("lift", Add(Get(B_2777, "lift"), ((V)(0.5)))).V, NewObj(2).Put("sq", ((V)((ToNum(Get(B_2777, "sq")) - 0.015)))).Put("lift", Get(B_2777, "lift")).V, ((V)("s")));
return Invoke(t_2776, "back", ((V)(300D)), Arr(((V)("sq")), ((V)("lift"))));
return default;
}, 1, "breathe", false)).Put("snore", Fn((V _self2778, int _argc2779, V t_2785, V a_2786, V X_2787, V _a2784, V[] _rest2780) => {
V B_2788 = default;
if (_self2778.IsNullish) _self2778 = GlobalV;
B_2788 = Get(t_2785, "B");
Invoke(t_2785, "to", ((V)(300D)), NewObj(1).Put("zz", ((V)(1.8))).V);
{
double i_2789 = 0;
i_2789 = 0D;
while (true) {
if (!((i_2789 < 3D))) break;
Invoke(Invoke(t_2785, "to", ((V)(1000D)), NewObj(4).Put("sq", ((V)((ToNum(Get(B_2788, "sq")) - 0.03)))).Put("lift", Add(Get(B_2788, "lift"), ((V)(0.6)))).Put("open", ((V)(0.08))).Put("puff", ((V)(0D))).V, ((V)("s"))), "to", ((V)(700D)), Call(o_10, V.Undef, NewObj(5).Put("sq", Add(Get(B_2788, "sq"), ((V)(0.08)))).Put("lift", Get(B_2788, "lift")).Put("open", ((V)(0.45))).Put("mw", ((V)(0.55))).Put("puff", ((V)(0.5))).V, Get(X_2787, "snore")), ((V)("o")));
i_2789++;
}
}
Invoke(t_2785, "to", ((V)(400D)), NewObj(1).Put("zz", ((V)(1D))).V);
return Invoke(t_2785, "back", ((V)(500D)));
return default;
}, 3, "snore", false)).Put("dream", Fn((V _self2791, int _argc2792, V t_2798, V a_2799, V X_2800, V _a2797, V[] _rest2793) => {
if (_self2791.IsNullish) _self2791 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2798, "to", ((V)(700D)), Call(o_10, V.Undef, NewObj(4).Put("drm", ((V)(1D))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.3))).Put("htilt", Add((Get(Get(t_2798, "B"), "htilt") is var _t2801 && Truthy(_t2801) ? _t2801 : ((V)(0D))), ((V)(3D)))).V, Get(X_2800, "dream")), ((V)("s"))), "osc", ((V)(1800D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.14))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("s"))), "wait", ((V)(1600D))), "to", ((V)(600D)), NewObj(1).Put("drm", ((V)(0D))).V, ((V)("io")));
return Invoke(t_2798, "back", ((V)(600D)));
return default;
}, 3, "dream", false)).Put("roll", Fn((V _self2802, int _argc2803, V t_2809, V s_2810, V _a2807, V _a2808, V[] _rest2804) => {
V B_2811 = default;
if (_self2802.IsNullish) _self2802 = GlobalV;
B_2811 = Get(t_2809, "B");
s_2810 = (s_2810 is var _t2812 && Truthy(_t2812) ? _t2812 : ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(t_2809, "to", ((V)(1000D)), NewObj(6).Put("turn", Add((Get(B_2811, "turn") is var _t2813 && Truthy(_t2813) ? _t2813 : ((V)(0D))), ((V)((ToNum(s_2810) * 0.5))))).Put("tilt", Add((Get(B_2811, "tilt") is var _t2814 && Truthy(_t2814) ? _t2814 : ((V)(0D))), ((V)((ToNum(s_2810) * 12D))))).Put("x", ((V)((ToNum(s_2810) * 2.2)))).Put("htilt", ((V)((ToNum(s_2810) * 12D)))).Put("sq", Add(Get(B_2811, "sq"), ((V)(0.03)))).PutK(((V)((LtN(s_2810, 0D) ? "armL" : "armR"))), Add((Get(B_2811, "armL") is var _t2815 && Truthy(_t2815) ? _t2815 : ((V)(0D))), ((V)(12D)))).V, ((V)("s"))), "osc", ((V)(4400D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(B_2811, "sq"), ((V)(0.07)))).V, NewObj(1).Put("sq", Add(Get(B_2811, "sq"), ((V)(0.02)))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(1).Put("sqz", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("sqz", ((V)(0D))).V);
return Invoke(t_2809, "back", ((V)(1000D)));
return default;
}, 2, "roll", false)).Put("twitch", Fn((V _self2816, int _argc2817, V t_2823, V _a2820, V _a2821, V _a2822, V[] _rest2818) => {
V B_2824 = default;
if (_self2816.IsNullish) _self2816 = GlobalV;
B_2824 = Get(t_2823, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2823, "to", ((V)(90D)), NewObj(1).Put("earR", ((V)((-10D)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("earR", ((V)(4D))).V), "to", ((V)(140D)), NewObj(1).Put("earR", ((V)(0D))).V), "wait", ((V)(400D))), "to", ((V)(110D)), NewObj(1).Put("footL", Add((Get(B_2824, "footL") is var _t2826 && Truthy(_t2826) ? _t2826 : ((V)(0D))), ((V)(2.4)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("footL", (Get(B_2824, "footL") is var _t2825 && Truthy(_t2825) ? _t2825 : ((V)(0D)))).V), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(1).Put("sqz", ((V)(0.35))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("sqz", ((V)(0D))).V);
return Invoke(t_2823, "back", ((V)(300D)));
return default;
}, 1, "twitch", false)).Put("nuzzle", Fn((V _self2827, int _argc2828, V t_2834, V _a2831, V _a2832, V _a2833, V[] _rest2829) => {
V B_2835 = default;
if (_self2827.IsNullish) _self2827 = GlobalV;
B_2835 = Get(t_2834, "B");
Invoke(Invoke(t_2834, "to", ((V)(600D)), NewObj(4).Put("htilt", Add((Get(B_2835, "htilt") is var _t2836 && Truthy(_t2836) ? _t2836 : ((V)(0D))), ((V)(6D)))).Put("pitch", Add((Get(B_2835, "pitch") is var _t2837 && Truthy(_t2837) ? _t2837 : ((V)(0D))), ((V)(0.08)))).Put("sq", Add(Get(B_2835, "sq"), ((V)(0.04)))).Put("smile", ((V)(0.7))).V, ((V)("s"))), "osc", ((V)(1500D)), ((V)(3D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("s")));
return Invoke(t_2834, "back", ((V)(700D)));
return default;
}, 1, "nuzzle", false)).Put("curl", Fn((V _self2838, int _argc2839, V t_2845, V _a2842, V _a2843, V _a2844, V[] _rest2840) => {
V B_2846 = default;
if (_self2838.IsNullish) _self2838 = GlobalV;
B_2846 = Get(t_2845, "B");
Invoke(Invoke(t_2845, "to", ((V)(1000D)), NewObj(6).Put("curl", ((V)(1D))).Put("sq", Add(Get(B_2846, "sq"), ((V)(0.05)))).Put("pitch", ((V)((ToNum((Get(B_2846, "pitch") is var _t2847 && Truthy(_t2847) ? _t2847 : ((V)(0D)))) - 0.08)))).Put("htilt", Add((Get(B_2846, "htilt") is var _t2848 && Truthy(_t2848) ? _t2848 : ((V)(0D))), ((V)(3D)))).Put("footL", Add((Get(B_2846, "footL") is var _t2849 && Truthy(_t2849) ? _t2849 : ((V)(0D))), ((V)(0.6)))).Put("footR", Add((Get(B_2846, "footR") is var _t2850 && Truthy(_t2850) ? _t2850 : ((V)(0D))), ((V)(0.6)))).V, ((V)("s"))), "wait", ((V)(2000D)));
return Invoke(t_2845, "back", ((V)(900D)));
return default;
}, 1, "curl", false)).Put("peek", Fn((V _self2851, int _argc2852, V t_2858, V _a2855, V _a2856, V _a2857, V[] _rest2853) => {
if (_self2851.IsNullish) _self2851 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2858, "to", ((V)(300D)), NewObj(5).Put("close", ((V)(0D))).Put("winkL", ((V)(1D))).Put("lx", ((V)(0.5))).Put("ly", ((V)(0.3))).Put("zz", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(1300D))), "to", ((V)(500D)), NewObj(4).Put("close", ((V)(1D))).Put("winkL", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("zz", ((V)(1D))).V);
return Invoke(t_2858, "back", ((V)(300D)));
return default;
}, 1, "peek", false)).Put("knead", Fn((V _self2859, int _argc2860, V t_2866, V _a2863, V _a2864, V _a2865, V[] _rest2861) => {
V B_2867 = default;
if (_self2859.IsNullish) _self2859 = GlobalV;
B_2867 = Get(t_2866, "B");
Invoke(Invoke(t_2866, "to", ((V)(300D)), NewObj(1).Put("smile", ((V)(0.7))).V), "osc", ((V)(2400D)), ((V)(6D)), NewObj(3).Put("hLy", Add(Get(B_2867, "hLy"), ((V)(3D)))).Put("hRy", Get(B_2867, "hRy")).Put("sq", Add(Get(B_2867, "sq"), ((V)(0.01)))).V, NewObj(3).Put("hLy", Get(B_2867, "hLy")).Put("hRy", Add(Get(B_2867, "hRy"), ((V)(3D)))).Put("sq", Get(B_2867, "sq")).V, ((V)("s")));
return Invoke(t_2866, "back", ((V)(400D)));
return default;
}, 1, "knead", false)).Put("shift", Fn((V _self2868, int _argc2869, V t_2875, V _a2872, V _a2873, V _a2874, V[] _rest2870) => {
V B_2876 = default;
if (_self2868.IsNullish) _self2868 = GlobalV;
B_2876 = Get(t_2875, "B");
Invoke(Invoke(t_2875, "to", ((V)(1100D)), NewObj(5).Put("turn", ((V)((-ToNum((Get(B_2876, "turn") is var _t2877 && Truthy(_t2877) ? _t2877 : ((V)(0D)))))))).Put("tilt", ((V)((-ToNum((Get(B_2876, "tilt") is var _t2878 && Truthy(_t2878) ? _t2878 : ((V)(0D)))))))).Put("htilt", ((V)((-ToNum((Get(B_2876, "htilt") is var _t2879 && Truthy(_t2879) ? _t2879 : ((V)(0D)))))))).Put("lean", ((V)((-ToNum((Get(B_2876, "lean") is var _t2880 && Truthy(_t2880) ? _t2880 : ((V)(0D)))))))).Put("sq", Add(Get(B_2876, "sq"), ((V)(0.05)))).V, ((V)("s"))), "osc", ((V)(4000D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(B_2876, "sq"), ((V)(0.07)))).V, NewObj(1).Put("sq", Add(Get(B_2876, "sq"), ((V)(0.03)))).V, ((V)("s")));
return Invoke(t_2875, "back", ((V)(1100D)));
return default;
}, 1, "shift", false)).V;
SORD_49 = NewObj(3).Put("bed", Arr(((V)("breathe")), ((V)("dream")), ((V)("snore")), Arr(((V)("roll")), ((V)(1D))), ((V)("twitch")), ((V)("sig")), ((V)("breathe")), Arr(((V)("roll")), ((V)((-1D)))), ((V)("snore")), ((V)("nuzzle")))).Put("lie", Arr(((V)("breathe")), ((V)("dream")), Arr(((V)("roll")), ((V)((-1D)))), ((V)("snore")), ((V)("sig")), ((V)("twitch")), Arr(((V)("roll")), ((V)(1D))), ((V)("nuzzle")))).Put("bean", Arr(((V)("breathe")), ((V)("dream")), ((V)("curl")), ((V)("peek")), ((V)("sig")), ((V)("snore")), ((V)("knead")), ((V)("shift")))).V;
BED_54 = NewObj(0).V;
BATH0_56 = Call(o_10, V.Undef, NewObj(18).Put("sit", ((V)(1D))).Put("sq", ((V)(0.08))).Put("lift", ((V)(0D))).Put("sk", ((V)(9D))).Put("wd", ((V)(0.74))).Put("fm", ((V)(1D))).Put("dk", ((V)(1D))).Put("dkx", ((V)(0D))).Put("smile", ((V)(0.85))).Put("hap", ((V)(0.35))).Put("close", ((V)(0.2))).Put("pitch", ((V)(0.05))).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("wet", ((V)(0D))).Put("fh", ((V)(0D))).Put("spg", ((V)(0D))).Put("dv", ((V)(0D))).V, Call(both_13, V.Undef, ((V)(3D)), ((V)((-3D)))));
SHOW0_57 = NewObj(19).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("sk", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("shw", ((V)(1D))).Put("stm", ((V)(0.7))).Put("wet", ((V)(1D))).Put("close", ((V)(0.5))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.4))).Put("pitch", ((V)((-0.1)))).Put("fh", ((V)(0D))).Put("spg", ((V)(0D))).V;
SWIM0_58 = Call(o_10, V.Undef, NewObj(14).Put("sit", ((V)(0D))).Put("sq", ((V)(0.03))).Put("lift", ((V)(0D))).Put("sk", ((V)(7D))).Put("wd", ((V)(0.8))).Put("pitch", ((V)((-0.1)))).Put("smile", ((V)(0.7))).Put("hap", ((V)(0.3))).Put("armL", ((V)(38D))).Put("armR", ((V)(38D))).Put("wet", ((V)(0D))).Put("dv", ((V)(0D))).Put("fm", ((V)(0D))).Put("dk", ((V)(0D))).V, Call(both_13, V.Undef, ((V)(1D)), ((V)((-4D)))));
SWS_59 = NewObj(4).Put("paddle", NewObj(0).V).Put("glide", NewObj(5).Put("sk", ((V)(9D))).Put("wd", ((V)(0.86))).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("pitch", ((V)((-0.04)))).V).Put("float", NewObj(4).Put("sk", ((V)(2D))).Put("wd", ((V)(0.55))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V).Put("bob", NewObj(5).Put("sk", ((V)(5D))).Put("wd", ((V)(0.7))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("sq", ((V)(0.05))).V).V;
TB_62 = NewObj(7).Put("soak", Fn((V _self2881, int _argc2882, V t_2888, V _a2885, V _a2886, V _a2887, V[] _rest2883) => {
V B_2889 = default;
if (_self2881.IsNullish) _self2881 = GlobalV;
B_2889 = Get(t_2888, "B");
Invoke(Invoke(Invoke(Invoke(t_2888, "to", ((V)(900D)), NewObj(5).Put("sk", Add(Get(B_2889, "sk"), ((V)(2.5)))).Put("close", ((V)(0.85))).Put("smile", ((V)(1D))).Put("open", ((V)(0.15))).Put("sq", Add(Get(B_2889, "sq"), ((V)(0.04)))).V, ((V)("s"))), "wait", ((V)(1300D))), "to", ((V)(700D)), NewObj(1).Put("open", ((V)(0D))).V), "wait", ((V)(400D)));
return Invoke(t_2888, "back", ((V)(700D)));
return default;
}, 1, "soak", false)).Put("scrub", Fn((V _self2890, int _argc2891, V t_2897, V _a2894, V _a2895, V _a2896, V[] _rest2892) => {
V B_2898 = default;
if (_self2890.IsNullish) _self2890 = GlobalV;
B_2898 = Get(t_2897, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2897, "to", ((V)(300D)), NewObj(1).Put("spg", ((V)(1D))).V, ((V)("o"))), "to", ((V)(420D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-17D)))), NewObj(3).Put("armR", ((V)(118D))).Put("htilt", ((V)(5D))).Put("close", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(1500D)), ((V)(6D)), NewObj(3).Put("hRx", ((V)(2D))).Put("htilt", ((V)(7D))).Put("fh", ((V)(0.5))).V, NewObj(3).Put("hRx", ((V)((-4D)))).Put("htilt", ((V)(3D))).Put("fh", ((V)(0.8))).V, ((V)("s"))), "fx", ((V)("foam")), ((V)("head")), ((V)(2D))), "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-9D)))), NewObj(2).Put("armR", ((V)(40D))).Put("fh", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(2).Put("hRy", ((V)((-7D)))).Put("sqz", ((V)(0.5))).V, NewObj(2).Put("hRy", ((V)((-10D)))).Put("sqz", ((V)(0.2))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(2).Put("spg", ((V)(0D))).Put("sqz", ((V)(0D))).V);
return Invoke(t_2897, "back", ((V)(500D)), Arr(((V)("armR")), ((V)("hRx")), ((V)("hRy")), ((V)("htilt")), ((V)("close")), ((V)("sqz"))));
return default;
}, 1, "scrub", false)).Put("bubbles", Fn((V _self2899, int _argc2900, V t_2906, V _a2903, V _a2904, V _a2905, V[] _rest2901) => {
if (_self2899.IsNullish) _self2899 = GlobalV;
{
double i_2907 = 0;
i_2907 = 0D;
while (true) {
if (!((i_2907 < 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_2906, "to", ((V)(320D)), NewObj(3).Put("puff", ((V)(0.75))).Put("open", ((V)(0D))).Put("close", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.45))).V, ((V)("o"))), "fx", ((V)((NumTruthy(i_2907) ? "bigbubble" : "bubble"))), ((V)("mouth")), ((V)(2D))), "to", ((V)(700D)), NewObj(5).Put("ly", ((V)((-0.9)))).Put("lx", ((V)(0.5))).Put("wide", ((V)(0.5))).Put("open", ((V)(0.1))).Put("mw", ((V)(1D))).V, ((V)("s")));
i_2907++;
}
}
Invoke(Invoke(t_2906, "to", ((V)(300D)), NewObj(4).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "wait", ((V)(400D)));
return Invoke(t_2906, "back", ((V)(500D)));
return default;
}, 1, "bubbles", false)).Put("duck", Fn((V _self2909, int _argc2910, V t_2916, V _a2913, V _a2914, V _a2915, V[] _rest2911) => {
if (_self2909.IsNullish) _self2909 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2916, "to", ((V)(500D)), NewObj(4).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.5))).Put("turn", ((V)(0.22))).Put("htilt", ((V)(4D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(13D)), ((V)(0D))), NewObj(1).Put("armR", ((V)(30D))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(1).Put("dkx", ((V)((-0.25)))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(5).Put("dkx", ((V)(0.35))).Put("hRx", ((V)((-8D)))).Put("wide", ((V)(0.7))).Put("open", ((V)(0.45))).Put("hap", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("note")), ((V)("head"))), "to", ((V)(400D)), NewObj(2).Put("sqz", ((V)(0.7))).Put("smile", ((V)(1D))).V), "wait", ((V)(500D))), "to", ((V)(900D)), NewObj(1).Put("dkx", ((V)(0D))).V, ((V)("s")));
return Invoke(t_2916, "back", ((V)(500D)), Arr(((V)("lx")), ((V)("ly")), ((V)("turn")), ((V)("htilt")), ((V)("armR")), ((V)("hRx")), ((V)("hRy")), ((V)("wide")), ((V)("open")), ((V)("hap")), ((V)("sqz")), ((V)("smile"))));
return default;
}, 1, "duck", false)).Put("splash", Fn((V _self2917, int _argc2918, V t_2924, V _a2921, V _a2922, V _a2923, V[] _rest2919) => {
V B_2925 = default;
if (_self2917.IsNullish) _self2917 = GlobalV;
B_2925 = Get(t_2924, "B");
Invoke(t_2924, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V);
{
double i_2926 = 0;
i_2926 = 0D;
while (true) {
if (!((i_2926 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2924, "to", ((V)(220D)), NewObj(5).Put("armL", ((V)(75D))).Put("armR", ((V)(75D))).Put("hLy", ((V)((-8D)))).Put("hRy", ((V)((-8D)))).Put("lift", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(6).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("hLy", Get(B_2925, "hLy")).Put("hRy", Get(B_2925, "hRy")).Put("lift", ((V)(0D))).Put("sqz", ((V)(0.8))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("sideL")), ((V)(5D))), "fx", ((V)("splash")), ((V)("sideR")), ((V)(5D))), "to", ((V)(180D)), NewObj(1).Put("sqz", ((V)(0.3))).V);
i_2926++;
}
}
return Invoke(t_2924, "back", ((V)(420D)));
return default;
}, 1, "splash", false)).Put("foamhat", Fn((V _self2928, int _argc2929, V t_2935, V _a2932, V _a2933, V _a2934, V[] _rest2930) => {
if (_self2928.IsNullish) _self2928 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2935, "to", ((V)(1400D)), NewObj(4).Put("fh", ((V)(1.7))).Put("ly", ((V)((-1D)))).Put("pitch", ((V)(0.18))).Put("wide", ((V)(0.5))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(4).Put("sqz", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "wait", ((V)(400D))), "to", ((V)(320D)), NewObj(3).Put("puff", ((V)(0.8))).Put("ly", ((V)((-0.6)))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0.35))).Put("fh", ((V)(0D))).Put("pitch", ((V)((-0.05)))).V, ((V)("o"))), "fx", ((V)("foam")), ((V)("head")), ((V)(4D))), "fx", ((V)("bubble")), ((V)("head")), ((V)(3D))), "wait", ((V)(300D)));
return Invoke(t_2935, "back", ((V)(500D)));
return default;
}, 1, "foamhat", false)).Put("sing", Fn((V _self2936, int _argc2937, V t_2943, V _a2940, V _a2941, V _a2942, V[] _rest2938) => {
if (_self2936.IsNullish) _self2936 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2943, "to", ((V)(300D)), NewObj(4).Put("close", ((V)(0.6))).Put("smile", ((V)(0.9))).Put("open", ((V)(0.35))).Put("mw", ((V)(0.6))).V), "fx", ((V)("note")), ((V)("head"))), "osc", ((V)(2400D)), ((V)(4D)), NewObj(3).Put("htilt", ((V)(7D))).Put("x", ((V)(0.8))).Put("open", ((V)(0.45))).V, NewObj(3).Put("htilt", ((V)((-7D)))).Put("x", ((V)((-0.8)))).Put("open", ((V)(0.25))).V, ((V)("s"))), "fx", ((V)("note")), ((V)("head")));
return Invoke(t_2943, "back", ((V)(450D)));
return default;
}, 1, "sing", false)).V;
SB0_63 = NewObj(5).Put("lather", Fn((V _self2944, int _argc2945, V t_2951, V _a2948, V _a2949, V _a2950, V[] _rest2946) => {
if (_self2944.IsNullish) _self2944 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2951, "to", ((V)(380D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(4D)), ((V)((-18D)))), NewObj(4).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("close", ((V)(0.9))).Put("smile", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(1800D)), ((V)(6D)), NewObj(4).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-1D)))).Put("fh", ((V)(0.6))).Put("htilt", ((V)(4D))).V, NewObj(4).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-6D)))).Put("fh", ((V)(1D))).Put("htilt", ((V)((-4D)))).V, ((V)("s"))), "fx", ((V)("foam")), ((V)("head")), ((V)(3D))), "to", ((V)(420D)), NewObj(7).Put("armL", (Get(Get(t_2951, "B"), "armL") is var _t2952 && Truthy(_t2952) ? _t2952 : ((V)(0D)))).Put("armR", (Get(Get(t_2951, "B"), "armR") is var _t2953 && Truthy(_t2953) ? _t2953 : ((V)(0D)))).Put("hLx", (Get(Get(t_2951, "B"), "hLx") is var _t2954 && Truthy(_t2954) ? _t2954 : ((V)(0D)))).Put("hRx", (Get(Get(t_2951, "B"), "hRx") is var _t2955 && Truthy(_t2955) ? _t2955 : ((V)(0D)))).Put("hLy", (Get(Get(t_2951, "B"), "hLy") is var _t2956 && Truthy(_t2956) ? _t2956 : ((V)(0D)))).Put("hRy", (Get(Get(t_2951, "B"), "hRy") is var _t2957 && Truthy(_t2957) ? _t2957 : ((V)(0D)))).Put("fh", ((V)(1.1))).V, ((V)("io")));
return Invoke(t_2951, "back", ((V)(300D)), Arr(((V)("close")), ((V)("smile")), ((V)("htilt"))));
return default;
}, 1, "lather", false)).Put("rinse", Fn((V _self2958, int _argc2959, V t_2965, V _a2962, V _a2963, V _a2964, V[] _rest2960) => {
if (_self2958.IsNullish) _self2958 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_2965, "to", ((V)(500D)), NewObj(4).Put("pitch", ((V)((-0.32)))).Put("close", ((V)(1D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("open", ((V)(0.45))).Put("puff", ((V)(0.3))).V, NewObj(2).Put("open", ((V)(0.15))).Put("puff", ((V)(0D))).V, ((V)("s"))), "to", ((V)(900D)), NewObj(1).Put("fh", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)("head")), ((V)(5D))), "to", ((V)(240D)), NewObj(4).Put("pitch", ((V)((-0.05)))).Put("close", ((V)(0D))).Put("wide", ((V)(0.5))).Put("open", ((V)(0.2))).V, ((V)("o"))), "e", ((V)("blink2")));
return Invoke(t_2965, "back", ((V)(500D)));
return default;
}, 1, "rinse", false)).Put("sing", Fn((V _self2966, int _argc2967, V t_2973, V _a2970, V _a2971, V _a2972, V[] _rest2968) => {
if (_self2966.IsNullish) _self2966 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_2973, "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-12D)))), NewObj(4).Put("armR", ((V)(34D))).Put("close", ((V)(0.55))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.6))).V), ((V)("io"))), "fx", ((V)("note")), ((V)("head"))), "osc", ((V)(2600D)), ((V)(4D)), NewObj(3).Put("htilt", ((V)(8D))).Put("lean", ((V)(0.8))).Put("open", ((V)(0.55))).V, NewObj(3).Put("htilt", ((V)((-8D)))).Put("lean", ((V)((-0.8)))).Put("open", ((V)(0.3))).V, ((V)("s"))), "fx", ((V)("note")), ((V)("head"))), "fx", ((V)("note")), ((V)("head")));
return Invoke(t_2973, "back", ((V)(500D)));
return default;
}, 1, "sing", false)).Put("turn", Fn((V _self2974, int _argc2975, V t_2981, V _a2978, V _a2979, V _a2980, V[] _rest2976) => {
if (_self2974.IsNullish) _self2974 = GlobalV;
Invoke(Invoke(t_2981, "to", ((V)(1800D)), NewObj(2).Put("spin", ((V)(360D))).Put("close", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V);
return Invoke(t_2981, "back", ((V)(300D)), Arr(((V)("close"))));
return default;
}, 1, "turn", false)).Put("shiver", Fn((V _self2982, int _argc2983, V t_2989, V _a2986, V _a2987, V _a2988, V[] _rest2984) => {
if (_self2982.IsNullish) _self2982 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_2989, "to", ((V)(120D)), NewObj(6).Put("wide", ((V)(1D))).Put("sq", ((V)((ToNum((Get(Get(t_2989, "B"), "sq") is var _t2990 && Truthy(_t2990) ? _t2990 : ((V)(0D)))) - 0.05)))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.5))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("o"))), "osc", ((V)(600D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(240D)), NewObj(2).Put("sqz", ((V)(0.6))).Put("wide", ((V)(0D))).V), "to", ((V)(300D)), NewObj(2).Put("sqz", ((V)(0D))).Put("smile", ((V)(1D))).V);
return Invoke(t_2989, "back", ((V)(420D)));
return default;
}, 1, "shiver", false)).V;
WB0_64 = NewObj(5).Put("back", Fn((V _self2991, int _argc2992, V t_2998, V _a2995, V _a2996, V _a2997, V[] _rest2993) => {
V B_2999 = default;
if (_self2991.IsNullish) _self2991 = GlobalV;
B_2999 = Get(t_2998, "B");
Invoke(Invoke(t_2998, "to", ((V)(800D)), NewObj(10).Put("pitch", ((V)(0.45))).Put("sk", ((V)((ToNum(Get(B_2999, "sk")) - 2.5)))).Put("wd", ((V)((ToNum(Get(B_2999, "wd")) * 0.85)))).Put("close", ((V)(0.75))).Put("smile", ((V)(1D))).Put("armL", ((V)(96D))).Put("armR", ((V)(96D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("tilt", ((V)(0D))).V, ((V)("s"))), "osc", ((V)(2600D)), ((V)(2D)), NewObj(2).Put("lift", Add((Get(B_2999, "lift") is var _t3000 && Truthy(_t3000) ? _t3000 : ((V)(0D))), ((V)(0.8)))).Put("tilt", ((V)(2D))).V, NewObj(2).Put("lift", (Get(B_2999, "lift") is var _t3001 && Truthy(_t3001) ? _t3001 : ((V)(0D)))).Put("tilt", ((V)((-2D)))).V, ((V)("s")));
return Invoke(t_2998, "back", ((V)(800D)));
return default;
}, 1, "back", false)).Put("dive", Fn((V _self3002, int _argc3003, V t_3009, V _a3006, V _a3007, V _a3008, V[] _rest3004) => {
if (_self3002.IsNullish) _self3002 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3009, "to", ((V)(300D)), NewObj(3).Put("puff", ((V)(0.7))).Put("close", ((V)(1D))).Put("wide", ((V)(0D))).V, ((V)("io"))), "to", ((V)(420D)), NewObj(2).Put("dv", ((V)(1D))).Put("sq", ((V)((ToNum((Get(Get(t_3009, "B"), "sq") is var _t3014 && Truthy(_t3014) ? _t3014 : ((V)(0D)))) - 0.05)))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("head")), ((V)(5D))), "wait", ((V)(300D))), "fx", ((V)("bubble")), ((V)("head")), ((V)(3D))), "wait", ((V)(600D))), "fx", ((V)("bubble")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D))), "to", ((V)(240D)), NewObj(7).Put("dv", ((V)(0D))).Put("puff", ((V)(0D))).Put("lift", Add((Get(Get(t_3009, "B"), "lift") is var _t3012 && Truthy(_t3012) ? _t3012 : ((V)(0D))), ((V)(3D)))).Put("sq", ((V)((ToNum((Get(Get(t_3009, "B"), "sq") is var _t3013 && Truthy(_t3013) ? _t3013 : ((V)(0D)))) - 0.08)))).Put("close", ((V)(0D))).Put("wide", ((V)(0.8))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("splash")), ((V)("head")), ((V)(7D))), "to", ((V)(240D)), NewObj(2).Put("lift", (Get(Get(t_3009, "B"), "lift") is var _t3010 && Truthy(_t3010) ? _t3010 : ((V)(0D)))).Put("sq", (Get(Get(t_3009, "B"), "sq") is var _t3011 && Truthy(_t3011) ? _t3011 : ((V)(0D)))).V, ((V)("i"))), "osc", ((V)(500D)), ((V)(4D)), NewObj(1).Put("htilt", ((V)(9D))).V, NewObj(1).Put("htilt", ((V)((-9D)))).V, ((V)("l"))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D)));
return Invoke(t_3009, "back", ((V)(400D)));
return default;
}, 1, "dive", false)).Put("splash", Fn((V _self3015, int _argc3016, V t_3022, V _a3019, V _a3020, V _a3021, V[] _rest3017) => {
if (_self3015.IsNullish) _self3015 = GlobalV;
Invoke(TB_62, "splash", t_3022);
return t_3022;
return default;
}, 1, "splash", false)).Put("spout", Fn((V _self3023, int _argc3024, V t_3030, V _a3027, V _a3028, V _a3029, V[] _rest3025) => {
if (_self3023.IsNullish) _self3023 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3030, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.8))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gush")), ((V)("mouth")), ((V)(4D))), "fx", ((V)("splash")), ((V)("mouth")), ((V)(4D))), "wait", ((V)(260D))), "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).V), "wait", ((V)(300D)));
return Invoke(t_3030, "back", ((V)(400D)));
return default;
}, 1, "spout", false)).Put("wave", Fn((V _self3031, int _argc3032, V t_3038, V _a3035, V _a3036, V _a3037, V[] _rest3033) => {
if (_self3031.IsNullish) _self3031 = GlobalV;
Invoke(BEAT_16, "wave", t_3038, ((V)(1D)));
return t_3038;
return default;
}, 1, "wave", false)).V;
WORD_65 = NewObj(3).Put("tub", Arr(((V)("soak")), ((V)("scrub")), ((V)("bubbles")), ((V)("duck")), ((V)("sig")), ((V)("splash")), ((V)("foamhat")), ((V)("sing")))).Put("shower", Arr(((V)("lather")), ((V)("rinse")), ((V)("sing")), ((V)("sig")), ((V)("turn")), ((V)("shiver")))).Put("swim", Arr(((V)("back")), ((V)("splash")), ((V)("dive")), ((V)("sig")), ((V)("spout")), ((V)("wave")))).V;
WAT_73 = NewObj(0).V;
Set(ICON_45, "cookie", Add(Add(Add(Add(Add(Call(ci_43, V.Undef, ((V)(0D)), ((V)(0D)), ((V)(3.6)), ((V)("#e2a85a")), ((V)("#a8702e"))), Call(ci_43, V.Undef, ((V)((-1.2))), ((V)((-1.1))), ((V)(0.6)), ((V)("#5a3420")))), Call(ci_43, V.Undef, ((V)(1.4)), ((V)((-0.3))), ((V)(0.7)), ((V)("#5a3420")))), Call(ci_43, V.Undef, ((V)((-0.3))), ((V)(1.5)), ((V)(0.6)), ((V)("#5a3420")))), Call(ci_43, V.Undef, ((V)(1.7)), ((V)(1.9)), ((V)(0.4)), ((V)("#5a3420")))), Call(ci_43, V.Undef, ((V)((-1.9))), ((V)(0.9)), ((V)(0.4)), ((V)("#5a3420")))));
SWG0_75 = NewObj(8).Put("armL", ((V)(118D))).Put("armR", ((V)(118D))).Put("hLx", ((V)((-1D)))).Put("hRx", ((V)(1D))).Put("hLy", ((V)((-3D)))).Put("hRy", ((V)((-3D)))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.4))).V;
RID0_76 = Call(o_10, V.Undef, NewObj(6).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("smile", ((V)(0.85))).Put("hap", ((V)(0.4))).Put("footL", ((V)(0.8))).Put("footR", ((V)(0.8))).V, Call(both_13, V.Undef, ((V)(10D)), ((V)((-3D)))));
CK0_77 = Call(o_10, V.Undef, NewObj(8).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.6))).Put("smile", ((V)(0.6))).Put("hap", ((V)(0.2))).Put("armR", ((V)(40D))).Put("armL", ((V)(14D))).V, Call(hand_12, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-3D)))), Call(hand_12, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)(2D))));
PB_78 = NewObj(6).Put("wheee", Fn((V _self3039, int _argc3040, V t_3046, V X_3047, V _a3044, V _a3045, V[] _rest3041) => {
V B_3048 = default;
if (_self3039.IsNullish) _self3039 = GlobalV;
B_3048 = Get(t_3046, "B");
Invoke(t_3046, "to", ((V)(300D)), Call(o_10, V.Undef, NewObj(8).Put("open", ((V)(0.6))).Put("mw", ((V)(0.6))).Put("wide", ((V)(0.8))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("pitch", Add((Get(B_3048, "pitch") is var _t3049 && Truthy(_t3049) ? _t3049 : ((V)(0D))), ((V)(0.16)))).Put("footL", Add((Get(B_3048, "footL") is var _t3050 && Truthy(_t3050) ? _t3050 : ((V)(0D))), ((V)(3D)))).Put("footR", Add((Get(B_3048, "footR") is var _t3051 && Truthy(_t3051) ? _t3051 : ((V)(0D))), ((V)(3D)))).V, Get(X_3047, "cheer")), ((V)("o")));
if (Truthy(Get(X_3047, "cheerFx"))) {
InvokeSpread(t_3046, "fx", new ArrBuilder().Spread(Get(X_3047, "cheerFx")).V);
} else {
Invoke(t_3046, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
}
Invoke(t_3046, "wait", ((V)(1300D)));
return Invoke(t_3046, "back", ((V)(500D)));
return default;
}, 2, "wheee", false)).Put("breeze", Fn((V _self3052, int _argc3053, V t_3059, V _a3056, V _a3057, V _a3058, V[] _rest3054) => {
V B_3060 = default;
if (_self3052.IsNullish) _self3052 = GlobalV;
B_3060 = Get(t_3059, "B");
Invoke(Invoke(t_3059, "to", ((V)(800D)), NewObj(7).Put("pitch", Add((Get(B_3060, "pitch") is var _t3061 && Truthy(_t3061) ? _t3061 : ((V)(0D))), ((V)(0.3)))).Put("close", ((V)(0.85))).Put("smile", ((V)(1D))).Put("open", ((V)(0.15))).Put("footL", Add((Get(B_3060, "footL") is var _t3062 && Truthy(_t3062) ? _t3062 : ((V)(0D))), ((V)(2.4)))).Put("footR", Add((Get(B_3060, "footR") is var _t3063 && Truthy(_t3063) ? _t3063 : ((V)(0D))), ((V)(2.4)))).Put("htilt", ((V)(5D))).V, ((V)("s"))), "wait", ((V)(1800D)));
return Invoke(t_3059, "back", ((V)(700D)));
return default;
}, 1, "breeze", false)).Put("peek", Fn((V _self3064, int _argc3065, V t_3071, V _a3068, V _a3069, V _a3070, V[] _rest3066) => {
V B_3072 = default;
if (_self3064.IsNullish) _self3064 = GlobalV;
B_3072 = Get(t_3071, "B");
Invoke(Invoke(Invoke(Invoke(t_3071, "to", ((V)(380D)), NewObj(6).Put("pitch", ((V)((ToNum((Get(B_3072, "pitch") is var _t3075 && Truthy(_t3075) ? _t3075 : ((V)(0D)))) - 0.24)))).Put("ly", ((V)(0.9))).Put("wide", ((V)(1D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).Put("sq", ((V)((ToNum((Get(B_3072, "sq") is var _t3076 && Truthy(_t3076) ? _t3076 : ((V)(0D)))) - 0.03)))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(220D)), NewObj(6).Put("sqz", ((V)(0.8))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("wide", ((V)(0D))).Put("ly", ((V)(0.3))).Put("open", ((V)(0.35))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(4D)), NewObj(1).Put("sq", Add((Get(B_3072, "sq") is var _t3073 && Truthy(_t3073) ? _t3073 : ((V)(0D))), ((V)(0.03)))).V, NewObj(1).Put("sq", (Get(B_3072, "sq") is var _t3074 && Truthy(_t3074) ? _t3074 : ((V)(0D)))).V, ((V)("o")));
return Invoke(t_3071, "back", ((V)(450D)));
return default;
}, 1, "peek", false)).Put("onehand", Fn((V _self3077, int _argc3078, V t_3084, V _a3081, V _a3082, V _a3083, V[] _rest3079) => {
if (_self3077.IsNullish) _self3077 = GlobalV;
Invoke(Invoke(t_3084, "to", ((V)(380D)), NewObj(7).Put("armR", ((V)(152D))).Put("hRx", ((V)(3D))).Put("hRy", ((V)((-5D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("htilt", ((V)(5D))).V, ((V)("o"))), "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("armR", ((V)(136D))).V, NewObj(1).Put("armR", ((V)(168D))).V, ((V)("io")));
return Invoke(t_3084, "back", ((V)(480D)));
return default;
}, 1, "onehand", false)).Put("higher", Fn((V _self3085, int _argc3086, V t_3092, V _a3089, V _a3090, V _a3091, V[] _rest3087) => {
V B_3093 = default;
V f_3094 = default;
V g_3095 = default;
V p0_3096 = default;
if (_self3085.IsNullish) _self3085 = GlobalV;
B_3093 = Get(t_3092, "B");
f_3094 = (Get(B_3093, "footL") is var _t3097 && Truthy(_t3097) ? _t3097 : ((V)(0D)));
g_3095 = (Get(B_3093, "footR") is var _t3098 && Truthy(_t3098) ? _t3098 : ((V)(0D)));
p0_3096 = (Get(B_3093, "pitch") is var _t3099 && Truthy(_t3099) ? _t3099 : ((V)(0D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_3092, "to", ((V)(260D)), NewObj(4).Put("sqz", ((V)(0.3))).Put("smile", ((V)(1D))).Put("mw", ((V)(0.7))).Put("open", ((V)(0.2))).V), "osc", ((V)(1800D)), ((V)(4D)), NewObj(4).Put("footL", Add(f_3094, ((V)(3.4)))).Put("footR", Add(g_3095, ((V)(3.4)))).Put("lean", ((V)(1.2))).Put("pitch", Add(p0_3096, ((V)(0.12)))).V, NewObj(4).Put("footL", ((V)((ToNum(f_3094) - 0.4)))).Put("footR", ((V)((ToNum(g_3095) - 0.4)))).Put("lean", ((V)((-1.2)))).Put("pitch", ((V)((ToNum(p0_3096) - 0.06)))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(4).Put("sqz", ((V)(0D))).Put("wide", ((V)(0.6))).Put("hap", ((V)(1D))).Put("open", ((V)(0.45))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(400D)));
return Invoke(t_3092, "back", ((V)(500D)));
return default;
}, 1, "higher", false)).Put("giggle", Fn((V _self3100, int _argc3101, V t_3107, V _a3104, V _a3105, V _a3106, V[] _rest3102) => {
V B_3108 = default;
if (_self3100.IsNullish) _self3100 = GlobalV;
B_3108 = Get(t_3107, "B");
Invoke(Invoke(t_3107, "to", ((V)(260D)), NewObj(5).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.7))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("blush", ((V)(0.5))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(5D)), NewObj(2).Put("sq", Add((Get(B_3108, "sq") is var _t3109 && Truthy(_t3109) ? _t3109 : ((V)(0D))), ((V)(0.03)))).Put("htilt", ((V)(4D))).V, NewObj(2).Put("sq", (Get(B_3108, "sq") is var _t3110 && Truthy(_t3110) ? _t3110 : ((V)(0D)))).Put("htilt", ((V)((-4D)))).V, ((V)("o")));
return Invoke(t_3107, "back", ((V)(450D)));
return default;
}, 1, "giggle", false)).V;
RB_79 = NewObj(6).Put("gallop", Fn((V _self3111, int _argc3112, V t_3118, V _a3115, V _a3116, V _a3117, V[] _rest3113) => {
V B_3119 = default;
V L_3120 = default;
V Q_3121 = default;
V f_3122 = default;
V g_3123 = default;
if (_self3111.IsNullish) _self3111 = GlobalV;
B_3119 = Get(t_3118, "B");
L_3120 = (Get(B_3119, "lift") is var _t3124 && Truthy(_t3124) ? _t3124 : ((V)(0D)));
Q_3121 = (Get(B_3119, "sq") is var _t3125 && Truthy(_t3125) ? _t3125 : ((V)(0D)));
f_3122 = (Get(B_3119, "footL") is var _t3126 && Truthy(_t3126) ? _t3126 : ((V)(0D)));
g_3123 = (Get(B_3119, "footR") is var _t3127 && Truthy(_t3127) ? _t3127 : ((V)(0D)));
Invoke(Invoke(t_3118, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).V), "osc", ((V)(1500D)), ((V)(6D)), NewObj(4).Put("footL", Add(f_3122, ((V)(2.6)))).Put("footR", Add(g_3123, ((V)(2.6)))).Put("sq", Add(Q_3121, ((V)(0.05)))).Put("lift", L_3120).V, NewObj(4).Put("footL", f_3122).Put("footR", g_3123).Put("sq", ((V)((ToNum(Q_3121) - 0.02)))).Put("lift", Add(L_3120, ((V)(1.4)))).V, ((V)("o")));
return Invoke(t_3118, "back", ((V)(400D)));
return default;
}, 1, "gallop", false)).Put("yeehaw", Fn((V _self3128, int _argc3129, V t_3135, V X_3136, V _a3133, V _a3134, V[] _rest3130) => {
if (_self3128.IsNullish) _self3128 = GlobalV;
Invoke(t_3135, "to", ((V)(320D)), Call(o_10, V.Undef, NewObj(9).Put("armR", ((V)(158D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-8D)))).Put("open", ((V)(0.55))).Put("mw", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("wide", ((V)(0.4))).Put("htilt", ((V)((-4D)))).V, Get(X_3136, "cheer")), ((V)("o")));
{
double i_3137 = 0;
i_3137 = 0D;
while (true) {
if (!((i_3137 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(t_3135, "to", ((V)(150D)), NewObj(2).Put("hRx", ((V)(4D))).Put("hRy", ((V)((-10D)))).V, ((V)("l"))), "to", ((V)(150D)), NewObj(2).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-13D)))).V, ((V)("l"))), "to", ((V)(150D)), NewObj(2).Put("hRx", ((V)((-4D)))).Put("hRy", ((V)((-10D)))).V, ((V)("l"))), "to", ((V)(150D)), NewObj(2).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-7D)))).V, ((V)("l")));
i_3137++;
}
}
Invoke(t_3135, "fx", ((V)("note")), ((V)("head")));
return Invoke(t_3135, "back", ((V)(450D)));
return default;
}, 2, "yeehaw", false)).Put("race", Fn((V _self3139, int _argc3140, V t_3146, V _a3143, V _a3144, V _a3145, V[] _rest3141) => {
V B_3147 = default;
if (_self3139.IsNullish) _self3139 = GlobalV;
B_3147 = Get(t_3146, "B");
Invoke(Invoke(t_3146, "to", ((V)(500D)), NewObj(8).Put("pitch", ((V)((ToNum((Get(B_3147, "pitch") is var _t3148 && Truthy(_t3148) ? _t3148 : ((V)(0D)))) - 0.2)))).Put("sq", Add((Get(B_3147, "sq") is var _t3149 && Truthy(_t3149) ? _t3149 : ((V)(0D))), ((V)(0.03)))).Put("wide", ((V)(0.6))).Put("sqz", ((V)(0.25))).Put("smile", ((V)(1D))).Put("mw", ((V)(0.7))).Put("hLy", Add((Get(B_3147, "hLy") is var _t3150 && Truthy(_t3150) ? _t3150 : ((V)(0D))), ((V)(3D)))).Put("hRy", Add((Get(B_3147, "hRy") is var _t3151 && Truthy(_t3151) ? _t3151 : ((V)(0D))), ((V)(3D)))).V, ((V)("io"))), "osc", ((V)(1400D)), ((V)(4D)), NewObj(1).Put("lean", ((V)(0.8))).V, NewObj(1).Put("lean", ((V)((-0.4)))).V, ((V)("s")));
return Invoke(t_3146, "back", ((V)(500D)));
return default;
}, 1, "race", false)).Put("whoa", Fn((V _self3152, int _argc3153, V t_3159, V _a3156, V _a3157, V _a3158, V[] _rest3154) => {
V B_3160 = default;
if (_self3152.IsNullish) _self3152 = GlobalV;
B_3160 = Get(t_3159, "B");
Invoke(Invoke(Invoke(Invoke(t_3159, "to", ((V)(300D)), NewObj(8).Put("pitch", Add((Get(B_3160, "pitch") is var _t3161 && Truthy(_t3161) ? _t3161 : ((V)(0D))), ((V)(0.26)))).Put("hLy", Add((Get(B_3160, "hLy") is var _t3162 && Truthy(_t3162) ? _t3162 : ((V)(0D))), ((V)(5D)))).Put("hRy", Add((Get(B_3160, "hRy") is var _t3163 && Truthy(_t3163) ? _t3163 : ((V)(0D))), ((V)(5D)))).Put("hLx", ((V)((ToNum((Get(B_3160, "hLx") is var _t3164 && Truthy(_t3164) ? _t3164 : ((V)(0D)))) - 3D)))).Put("hRx", Add((Get(B_3160, "hRx") is var _t3165 && Truthy(_t3165) ? _t3165 : ((V)(0D))), ((V)(3D)))).Put("wide", ((V)(0.8))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "wait", ((V)(700D))), "to", ((V)(240D)), NewObj(5).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("wide", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(300D)));
return Invoke(t_3159, "back", ((V)(500D)));
return default;
}, 1, "whoa", false)).Put("pat", Fn((V _self3166, int _argc3167, V t_3173, V _a3170, V _a3171, V _a3172, V[] _rest3168) => {
if (_self3166.IsNullish) _self3166 = GlobalV;
Invoke(Invoke(Invoke(t_3173, "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(14D)), ((V)(4D))), NewObj(6).Put("armR", ((V)(16D))).Put("htilt", ((V)(5D))).Put("lx", ((V)(0.4))).Put("ly", ((V)(0.5))).Put("smile", ((V)(1D))).Put("close", ((V)(0.3))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(3D)), NewObj(1).Put("hRy", ((V)(7D))).V, NewObj(1).Put("hRy", ((V)(3D))).V, ((V)("o"))), "fx", ((V)("heart")), ((V)("head")));
return Invoke(t_3173, "back", ((V)(450D)));
return default;
}, 1, "pat", false)).Put("cheer", Fn((V _self3174, int _argc3175, V t_3181, V X_3182, V _a3179, V _a3180, V[] _rest3176) => {
if (_self3174.IsNullish) _self3174 = GlobalV;
Invoke(WBEAT_30, "cheer", t_3181, X_3182);
return t_3181;
return default;
}, 2, "cheer", false)).V;
PORD_80 = NewObj(2).Put("swing", Arr(((V)("wheee")), ((V)("peek")), ((V)("sig")), ((V)("breeze")), ((V)("onehand")), ((V)("higher")), ((V)("giggle")), ((V)("kick")))).Put("ride", Arr(((V)("gallop")), ((V)("yeehaw")), ((V)("pat")), ((V)("sig")), ((V)("race")), ((V)("whoa")), ((V)("cheer")))).V;
CB_84 = NewObj(6).Put("stir", Fn((V _self3183, int _argc3184, V t_3190, V _a3187, V _a3188, V _a3189, V[] _rest3185) => {
V B_3191 = default;
V x0_3192 = default;
V y0_3193 = default;
if (_self3183.IsNullish) _self3183 = GlobalV;
B_3191 = Get(t_3190, "B");
x0_3192 = (Get(B_3191, "hRx") is var _t3194 && Truthy(_t3194) ? _t3194 : ((V)(0D)));
y0_3193 = (Get(B_3191, "hRy") is var _t3195 && Truthy(_t3195) ? _t3195 : ((V)(0D)));
Invoke(t_3190, "to", ((V)(200D)), NewObj(1).Put("ly", ((V)(0.8))).V);
{
double i_3196 = 0;
i_3196 = 0D;
while (true) {
if (!((i_3196 < 4D))) break;
Invoke(Invoke(Invoke(Invoke(t_3190, "to", ((V)(170D)), NewObj(3).Put("hRx", ((V)((ToNum(x0_3192) - 3D)))).Put("hRy", Add(y0_3193, ((V)(1.5)))).Put("htilt", ((V)(3D))).V, ((V)("l"))), "to", ((V)(170D)), NewObj(2).Put("hRx", x0_3192).Put("hRy", Add(y0_3193, ((V)(3D)))).V, ((V)("l"))), "to", ((V)(170D)), NewObj(3).Put("hRx", Add(x0_3192, ((V)(3D)))).Put("hRy", Add(y0_3193, ((V)(1.5)))).Put("htilt", ((V)((-3D)))).V, ((V)("l"))), "to", ((V)(170D)), NewObj(2).Put("hRx", x0_3192).Put("hRy", y0_3193).V, ((V)("l")));
i_3196++;
}
}
Invoke(t_3190, "fx", ((V)("steam")), ((V)("pawR")));
return Invoke(t_3190, "back", ((V)(300D)));
return default;
}, 1, "stir", false)).Put("season", Fn((V _self3198, int _argc3199, V t_3205, V _a3202, V _a3203, V _a3204, V[] _rest3200) => {
if (_self3198.IsNullish) _self3198 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_3205, "to", ((V)(340D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)(12D)), ((V)((-10D)))), NewObj(3).Put("armL", ((V)(44D))).Put("htilt", ((V)((-5D)))).Put("close", ((V)(0.3))).V), ((V)("io"))), "osc", ((V)(450D)), ((V)(3D)), NewObj(2).Put("hLy", ((V)((-12D)))).Put("hLx", ((V)(13D))).V, NewObj(2).Put("hLy", ((V)((-9D)))).Put("hLx", ((V)(11D))).V, ((V)("l"))), "fx", ((V)("salt")), ((V)("pawL")), ((V)(3D))), "osc", ((V)(450D)), ((V)(3D)), NewObj(2).Put("hLy", ((V)((-12D)))).Put("hLx", ((V)(13D))).V, NewObj(2).Put("hLy", ((V)((-9D)))).Put("hLx", ((V)(11D))).V, ((V)("l"))), "fx", ((V)("salt")), ((V)("pawL")), ((V)(3D)));
return Invoke(t_3205, "back", ((V)(400D)));
return default;
}, 1, "season", false)).Put("shake", Fn((V _self3206, int _argc3207, V t_3213, V _a3210, V _a3211, V _a3212, V[] _rest3208) => {
if (_self3206.IsNullish) _self3206 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_3213, "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-2D)))), NewObj(3).Put("armR", ((V)(44D))).Put("ly", ((V)(0.7))).Put("lx", ((V)(0.5))).V), ((V)("io"))), "osc", ((V)(600D)), ((V)(4D)), NewObj(2).Put("hRx", ((V)((-4D)))).Put("hRy", ((V)((-3D)))).V, NewObj(2).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-1D)))).V, ((V)("l"))), "fx", ((V)("steam")), ((V)("pawR"))), "osc", ((V)(600D)), ((V)(4D)), NewObj(2).Put("hRx", ((V)((-4D)))).Put("hRy", ((V)((-3D)))).V, NewObj(2).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-1D)))).V, ((V)("l"))), "fx", ((V)("steam")), ((V)("pawR")));
return Invoke(t_3213, "back", ((V)(350D)));
return default;
}, 1, "shake", false)).Put("flip", Fn((V _self3214, int _argc3215, V t_3221, V X_3222, V rec_3223, V _a3220, V[] _rest3216) => {
V B_3224 = default;
V Q_3225 = default;
V p0_3226 = default;
if (_self3214.IsNullish) _self3214 = GlobalV;
B_3224 = Get(t_3221, "B");
Q_3225 = (Get(B_3224, "sq") is var _t3227 && Truthy(_t3227) ? _t3227 : ((V)(0D)));
p0_3226 = (Get(B_3224, "pitch") is var _t3228 && Truthy(_t3228) ? _t3228 : ((V)(0D)));
Invoke(Invoke(t_3221, "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-1D)))), NewObj(2).Put("armR", ((V)(42D))).Put("lx", ((V)(0.5))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hRy", ((V)(2D))).Put("sq", Add(Q_3225, ((V)(0.04)))).V, ((V)("io")));
Invoke(rec_3223, "push", Get(t_3221, "t"));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3221, "to", ((V)(160D)), NewObj(8).Put("armR", ((V)(66D))).Put("hRy", ((V)((-6D)))).Put("sq", ((V)((ToNum(Q_3225) - 0.04)))).Put("lx", ((V)(0.6))).Put("ly", ((V)((-0.9)))).Put("pitch", Add(p0_3226, ((V)(0.24)))).Put("wide", ((V)(0.7))).Put("open", ((V)(0.35))).V, ((V)("o"))), "to", ((V)(520D)), NewObj(3).Put("armR", ((V)(48D))).Put("hRy", ((V)((-2D)))).Put("ly", ((V)((-1D)))).V, ((V)("io"))), "to", ((V)(320D)), NewObj(2).Put("ly", ((V)(0.7))).Put("pitch", ((V)((ToNum(p0_3226) - 0.06)))).V, ((V)("i"))), "to", ((V)(140D)), NewObj(2).Put("sq", Add(Q_3225, ((V)(0.05)))).Put("hRy", ((V)(1D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(6).Put("sq", Q_3225).Put("sqz", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("wide", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(400D)));
return Invoke(t_3221, "back", ((V)(450D)));
return default;
}, 3, "flip", false)).Put("taste", Fn((V _self3229, int _argc3230, V t_3236, V X_3237, V _a3234, V _a3235, V[] _rest3231) => {
V B_3238 = default;
if (_self3229.IsNullish) _self3229 = GlobalV;
B_3238 = Get(t_3236, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3236, "to", ((V)(420D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-13D)))), NewObj(4).Put("armR", ((V)(36D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("pitch", Add((Get(B_3238, "pitch") is var _t3239 && Truthy(_t3239) ? _t3239 : ((V)(0D))), ((V)(0.04)))).V), ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.6))).Put("open", ((V)(0D))).V), "to", ((V)(260D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("pawR"))), "to", ((V)(300D)), NewObj(3).Put("open", ((V)(0.25))).Put("close", ((V)(0.7))).Put("mw", ((V)(0.8))).V), "osc", ((V)(600D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.15))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(6).Put("lx", ((V)(0.6))).Put("ly", ((V)((-0.6)))).Put("htilt", ((V)(7D))).Put("close", ((V)(0D))).Put("hRy", ((V)((-6D)))).Put("armR", ((V)(24D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(260D)), Call(o_10, V.Undef, NewObj(5).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.7))).Put("open", ((V)(0.4))).Put("htilt", ((V)(0D))).V, Get(X_3237, "cheer")), ((V)("o")));
if (Truthy(Get(X_3237, "cheerFx"))) {
InvokeSpread(t_3236, "fx", new ArrBuilder().Spread(Get(X_3237, "cheerFx")).V);
} else {
Invoke(t_3236, "fx", ((V)("heart")), ((V)("head")));
}
Invoke(t_3236, "wait", ((V)(500D)));
return Invoke(t_3236, "back", ((V)(500D)));
return default;
}, 2, "taste", false)).Put("kiss", Fn((V _self3240, int _argc3241, V t_3247, V _a3244, V _a3245, V _a3246, V[] _rest3242) => {
if (_self3240.IsNullish) _self3240 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3247, "to", ((V)(360D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(7D)), ((V)((-14D)))), NewObj(6).Put("armR", ((V)(38D))).Put("puff", ((V)(0.3))).Put("mw", ((V)(0.4))).Put("close", ((V)(0.6))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(10).Put("armR", ((V)(118D))).Put("hRx", ((V)(4D))).Put("hRy", ((V)((-6D)))).Put("open", ((V)(0.35))).Put("mw", ((V)(0.6))).Put("puff", ((V)(0D))).Put("sqz", ((V)(0.8))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D))), "wait", ((V)(600D)));
return Invoke(t_3247, "back", ((V)(500D)));
return default;
}, 1, "kiss", false)).V;
SPOON_85 = ((V)("<path d=\"M-0.55 -3L0.55 -3L0.5 9.5L-0.5 9.5Z\" fill=\"#c98a52\" stroke=\"#8a5a2c\" stroke-width=\"0.3\"/><ellipse cx=\"0\" cy=\"12\" rx=\"2\" ry=\"2.8\" fill=\"#d9a066\" stroke=\"#8a5a2c\" stroke-width=\"0.35\"/><ellipse cx=\"-0.5\" cy=\"11.2\" rx=\"0.7\" ry=\"1.1\" fill=\"#f2c890\" opacity=\"0.8\"/>"));
PAN_86 = ((V)("<path d=\"M1 -0.9L7.5 -0.4L7.5 1.2L1 1.4Z\" fill=\"#3b2a24\" stroke=\"#1e1410\" stroke-width=\"0.3\"/><ellipse cx=\"13\" cy=\"1.6\" rx=\"7\" ry=\"3.6\" fill=\"#55556a\" stroke=\"#24242c\" stroke-width=\"0.45\"/><ellipse cx=\"13\" cy=\"1\" rx=\"6\" ry=\"2.8\" fill=\"#34343f\"/><path d=\"M7.6 0.4Q10 -0.8 13 -0.9\" stroke=\"#8a8a9a\" stroke-width=\"0.4\" fill=\"none\" opacity=\"0.7\"/>"));
facing_87 = Fn((V _arrowThis3255, int _argc3248, V I_3254, V _a3251, V _a3252, V _a3253, V[] _rest3249) => {
double s_3256 = 0;
s_3256 = ((ToNum(((Get(I_3254, "lastP") is var _t3257 && !Truthy(_t3257) ? _t3257 : Get(Get(I_3254, "lastP"), "spin")) is var _t3258 && Truthy(_t3258) ? _t3258 : ((V)(0D)))) * System.Math.PI) / 180D);
return Call(ss_25, V.Undef, ((V)(((FdLibm.Cos(s_3256) + 0.15) / 0.4))));
return default;
}, 1, "", true);
win_88 = Fn((V _arrowThis3269, int _argc3259, V tl_3265, V a_3266, V b_3267, V e_3268, V[] _rest3260) => {
return ((V)(Min(ToNum(Call(ss_25, V.Undef, ((V)(((ToNum(tl_3265) - ToNum(a_3266)) / ToNum(e_3268)))))), ToNum(Call(ss_25, V.Undef, ((V)(((ToNum(b_3267) - ToNum(tl_3265)) / ToNum(e_3268)))))))));
}, 4, "", true);
PLY_93 = NewObj(0).V;
if (Truthy(Get(R_8, "PRE"))) {
Set(Get(R_8, "PRE"), "sand", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(12D))).Put("vy", ((V)((-16D)))).Put("g", ((V)(85D))).Put("life", ((V)(700D))).Put("r", Arr(((V)(0.5)), ((V)(0.95)))).Put("col", Arr(((V)("#e9cf94")), ((V)("#d8b874")), ((V)("#f3e2b0")))).Put("kind", ((V)("dot"))).V);
}
Set(ICON_45, "boot", Add(Add(Add(Call(pa_44, V.Undef, ((V)("M-2.6-4H1V0.6L4 1.4Q4.6 1.8 4.4 3.2H-2.6Z")), ((V)("#8a6a4a")), ((V)("#5a4028"))), Call(pa_44, V.Undef, ((V)("M-2.6 2.4H4.4")), V.Null, ((V)("#5a4028")), ((V)(0.5)))), Call(pa_44, V.Undef, ((V)("M-1.4-2.4L0.2-2.4M-1.4-1L0.2-1")), V.Null, ((V)("#d9c8a8")), ((V)(0.45)))), Call(ci_43, V.Undef, ((V)(3.6)), ((V)((-2.6))), ((V)(0.7)), ((V)("rgba(160,220,255,0.6)")), ((V)("#5ab4f0")))));
Set(ICON_45, "crab", Add(Add(Add(Add(Add(Call(pa_44, V.Undef, ((V)("M-3.4 0.6Q-3.4-2.6 0-2.6Q3.4-2.6 3.4 0.6Q3.4 2.4 0 2.4Q-3.4 2.4-3.4 0.6Z")), ((V)("#f2604a")), ((V)("#b8382a"))), Call(pa_44, V.Undef, ((V)("M-3.2-1Q-5-2.4-4.4-4M3.2-1Q5-2.4 4.4-4")), V.Null, ((V)("#b8382a")), ((V)(0.7)))), Call(ci_43, V.Undef, ((V)((-4.4))), ((V)((-4.2))), ((V)(0.9)), ((V)("#f2604a")), ((V)("#b8382a")))), Call(ci_43, V.Undef, ((V)(4.4)), ((V)((-4.2))), ((V)(0.9)), ((V)("#f2604a")), ((V)("#b8382a")))), Call(ci_43, V.Undef, ((V)((-1.1))), ((V)((-1.2))), ((V)(0.45)), ((V)("#2a1a10")))), Call(ci_43, V.Undef, ((V)(1.1)), ((V)((-1.2))), ((V)(0.45)), ((V)("#2a1a10")))));
okp_95 = Fn((V _arrowThis3277, int _argc3270, V p_3276, V _a3273, V _a3274, V _a3275, V[] _rest3271) => {
return ((p_3276 is var _t3278 && !Truthy(_t3278) ? _t3278 : (IsFiniteV(GetIdx(p_3276, 0D)) ? V.True : V.False)) is var _t3279 && !Truthy(_t3279) ? _t3279 : (IsFiniteV(GetIdx(p_3276, 1D)) ? V.True : V.False));
}, 1, "", true);
gnd_96 = Fn((V _arrowThis3287, int _argc3280, V I_3286, V _a3283, V _a3284, V _a3285, V[] _rest3281) => {
V W_3288 = default;
V a_3289 = default;
V b_3290 = default;
V B_3291 = default;
W_3288 = (Get(I_3286, "W") is var _t3292 && Truthy(_t3292) ? _t3292 : NewObj(0).V);
a_3289 = Get(W_3288, "footL");
b_3290 = Get(W_3288, "footR");
if (Truthy((Call(okp_95, V.Undef, a_3289) is var _t3293 && !Truthy(_t3293) ? _t3293 : Call(okp_95, V.Undef, b_3290)))) {
return Arr(((V)((ToNum(Add(GetIdx(a_3289, 0D), GetIdx(b_3290, 0D))) / 2D))), ((V)((Max(ToNum(GetIdx(a_3289, 1D)), ToNum(GetIdx(b_3290, 1D))) + 2.5))));
}
B_3291 = (Truthy(Call(okp_95, V.Undef, Get(W_3288, "belly"))) ? Get(W_3288, "belly") : Arr(((V)(50D)), ((V)(83D))));
return Arr(GetIdx(B_3291, 0D), Add(GetIdx(B_3291, 1D), ((V)(13D))));
return default;
}, 1, "", true);
rside_97 = Fn((V _arrowThis3302, int _argc3294, V I_3300, V gx_3301, V _a3298, V _a3299, V[] _rest3295) => {
V s_3303 = default;
s_3303 = (Get(I_3300, "W") is var _t3304 && !Truthy(_t3304) ? _t3304 : Get(Get(I_3300, "W"), "sideR"));
return (Truthy(Call(okp_95, V.Undef, s_3303)) ? ((V)(Max(ToNum(Add(gx_3301, ((V)(18D)))), ToNum(Add(GetIdx(s_3303, 0D), ((V)(6D))))))) : Add(gx_3301, ((V)(24D))));
return default;
}, 2, "", true);
cnt_98 = Fn((V _arrowThis3314, int _argc3305, V L_3311, V a_3312, V b_3313, V _a3310, V[] _rest3306) => {
return Get(Invoke((L_3311 is var _t3323 && Truthy(_t3323) ? _t3323 : Arr()), "filter", Fn((V _arrowThis3322, int _argc3315, V x_3321, V _a3318, V _a3319, V _a3320, V[] _rest3316) => {
return ((Ge(x_3321, a_3312) && Le(x_3321, b_3313)) ? V.True : V.False);
}, 1, "", true)), "length");
}, 3, "", true);
lerp_99 = Fn((V _arrowThis3333, int _argc3324, V a_3330, V b_3331, V u_3332, V _a3329, V[] _rest3325) => {
return Add(a_3330, ((V)(((ToNum(b_3331) - ToNum(a_3330)) * ToNum(u_3332)))));
}, 3, "", true);
G_100 = Fn((V _arrowThis3346, int _argc3334, V x_3340, V y_3341, V r_3342, V s_3343, V[] _rest3335) => {
V body_3344 = default;
V op_3345 = default;
body_3344 = (_argc3334 > 4 ? _rest3335[0] : V.Undef);
op_3345 = (_argc3334 > 5 ? _rest3335[1] : V.Undef);
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(r2_38, V.Undef, x_3340)).S(" ").V(Call(r2_38, V.Undef, y_3341)).S(")").S((Truthy(r_3342) ? JsStrBuf.Begin().S(" rotate(").V(Call(r2_38, V.Undef, r_3342)).S(")").End() : "")).S(((!s_3343.IsNullish && !SEqN(s_3343, 1D)) ? JsStrBuf.Begin().S(" scale(").V(Call(r2_38, V.Undef, s_3343)).S(")").End() : "")).S("\"").S(((!op_3345.IsNullish && LtN(op_3345, 0.99)) ? JsStrBuf.Begin().S(" opacity=\"").V(Call(r2_38, V.Undef, ((V)(Max(0D, ToNum(op_3345)))))).S("\"").End() : "")).S(">").V(body_3344).S("</g>").End()));
}, 6, "", true);
SK0_102 = Call(o_10, V.Undef, NewObj(13).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)((-0.14)))).Put("ly", ((V)(0.7))).Put("lx", ((V)(0D))).Put("smile", ((V)(0.5))).Put("hap", ((V)(0.2))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).V, Call(both_13, V.Undef, ((V)(9D)), ((V)((-2D)))));
SKB_103 = NewObj(6).Put("scrub", Fn((V _self3347, int _argc3348, V t_3354, V _a3351, V _a3352, V _a3353, V[] _rest3349) => {
V B_3355 = default;
if (_self3347.IsNullish) _self3347 = GlobalV;
B_3355 = Get(t_3354, "B");
Invoke(t_3354, "to", ((V)(220D)), NewObj(2).Put("sqz", ((V)(0.3))).Put("smile", ((V)(0.8))).V);
{
double i_3356 = 0;
i_3356 = 0D;
while (true) {
if (!((i_3356 < 6D))) break;
Invoke(Invoke(t_3354, "to", ((V)(140D)), NewObj(4).Put("hLx", Add(Get(B_3355, "hLx"), ((V)(2.6)))).Put("hRx", ((V)((ToNum(Get(B_3355, "hRx")) - 2.6)))).Put("hLy", ((V)((ToNum(Get(B_3355, "hLy")) - 1.4)))).Put("hRy", Add(Get(B_3355, "hRy"), ((V)(1.4)))).V, ((V)("l"))), "to", ((V)(140D)), NewObj(4).Put("hLx", ((V)((ToNum(Get(B_3355, "hLx")) - 0.6)))).Put("hRx", Add(Get(B_3355, "hRx"), ((V)(0.6)))).Put("hLy", Add(Get(B_3355, "hLy"), ((V)(1.4)))).Put("hRy", ((V)((ToNum(Get(B_3355, "hRy")) - 1.4)))).V, ((V)("l")));
if (((i_3356 % 2D) == 0D)) {
Invoke(t_3354, "fx", ((V)("foam")), ((V)((NumTruthy((i_3356 % 4D)) ? "pawL" : "pawR"))), ((V)(2D)));
}
i_3356++;
}
}
return Invoke(t_3354, "back", ((V)(300D)));
return default;
}, 1, "scrub", false)).Put("rinse", Fn((V _self3358, int _argc3359, V t_3365, V _a3362, V _a3363, V _a3364, V[] _rest3360) => {
V B_3366 = default;
if (_self3358.IsNullish) _self3358 = GlobalV;
B_3366 = Get(t_3365, "B");
Invoke(t_3365, "to", ((V)(300D)), NewObj(5).Put("hLy", ((V)((ToNum(Get(B_3366, "hLy")) - 2D)))).Put("hRy", ((V)((ToNum(Get(B_3366, "hRy")) - 2D)))).Put("armL", ((V)(38D))).Put("armR", ((V)(38D))).Put("ly", ((V)(0.5))).V, ((V)("io")));
{
double i_3367 = 0;
i_3367 = 0D;
while (true) {
if (!((i_3367 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(t_3365, "to", ((V)(200D)), NewObj(2).Put("hLx", Add(Get(B_3366, "hLx"), ((V)(1.5)))).Put("hRx", Add(Get(B_3366, "hRx"), ((V)(1.5)))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)("pawL")), ((V)(3D))), "to", ((V)(200D)), NewObj(2).Put("hLx", ((V)((ToNum(Get(B_3366, "hLx")) - 1.5)))).Put("hRx", ((V)((ToNum(Get(B_3366, "hRx")) - 1.5)))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)("pawR")), ((V)(3D)));
i_3367++;
}
}
return Invoke(t_3365, "back", ((V)(300D)));
return default;
}, 1, "rinse", false)).Put("splash", Fn((V _self3369, int _argc3370, V t_3376, V X_3377, V _a3374, V _a3375, V[] _rest3371) => {
V B_3378 = default;
if (_self3369.IsNullish) _self3369 = GlobalV;
B_3378 = Get(t_3376, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3376, "to", ((V)(320D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(9D)), ((V)((-13D)))), NewObj(5).Put("armL", ((V)(44D))).Put("armR", ((V)(44D))).Put("pitch", Add(Get(B_3378, "pitch"), ((V)(0.12)))).Put("ly", ((V)(0.2))).Put("close", ((V)(0.5))).V), ((V)("io"))), "to", ((V)(110D)), NewObj(4).Put("close", ((V)(1D))).Put("sqz", ((V)(1D))).Put("open", ((V)(0.25))).Put("sq", ((V)((ToNum(Get(B_3378, "sq")) - 0.05)))).V, ((V)("o"))), "fx", ((V)("splash")), ((V)("head")), ((V)(6D))), "osc", ((V)(560D)), ((V)(4D)), NewObj(2).Put("htilt", ((V)(7D))).Put("x", ((V)(0.4))).V, NewObj(2).Put("htilt", ((V)((-7D)))).Put("x", ((V)((-0.4)))).V, ((V)("l"))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D))), "to", ((V)(220D)), Call(o_10, V.Undef, NewObj(9).Put("sqz", ((V)(0D))).Put("close", ((V)(0D))).Put("wide", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("sq", Get(B_3378, "sq")).Put("htilt", ((V)(0D))).Put("x", ((V)(0D))).V, Get(X_3377, "wash")), ((V)("o"))), "wait", ((V)(400D)));
return Invoke(t_3376, "back", ((V)(420D)));
return default;
}, 2, "splash", false)).Put("shake", Fn((V _self3379, int _argc3380, V t_3386, V _a3383, V _a3384, V _a3385, V[] _rest3381) => {
V B_3387 = default;
if (_self3379.IsNullish) _self3379 = GlobalV;
B_3387 = Get(t_3386, "B");
Invoke(Invoke(Invoke(Invoke(t_3386, "to", ((V)(200D)), NewObj(4).Put("hLy", Add(Get(B_3387, "hLy"), ((V)(2D)))).Put("hRy", Add(Get(B_3387, "hRy"), ((V)(2D)))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "osc", ((V)(720D)), ((V)(6D)), NewObj(4).Put("armL", ((V)(36D))).Put("armR", ((V)(12D))).Put("hLx", Add(Get(B_3387, "hLx"), ((V)(2D)))).Put("hRx", Get(B_3387, "hRx")).V, NewObj(4).Put("armL", ((V)(12D))).Put("armR", ((V)(36D))).Put("hLx", Get(B_3387, "hLx")).Put("hRx", ((V)((ToNum(Get(B_3387, "hRx")) - 2D)))).V, ((V)("l"))), "fx", ((V)("drop")), ((V)("pawL")), ((V)(3D))), "fx", ((V)("drop")), ((V)("pawR")), ((V)(3D)));
return Invoke(t_3386, "back", ((V)(300D)));
return default;
}, 1, "shake", false)).Put("mirror", Fn((V _self3388, int _argc3389, V t_3395, V _a3392, V _a3393, V _a3394, V[] _rest3390) => {
V B_3396 = default;
if (_self3388.IsNullish) _self3388 = GlobalV;
B_3396 = Get(t_3395, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3395, "to", ((V)(420D)), NewObj(5).Put("pitch", Add(Get(B_3396, "pitch"), ((V)(0.22)))).Put("ly", ((V)((-0.5)))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).Put("htilt", ((V)(4D))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(150D)), NewObj(2).Put("winkR", ((V)(1D))).Put("sqz", ((V)(0.3))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(380D))), "to", ((V)(200D)), NewObj(2).Put("winkR", ((V)(0D))).Put("sqz", ((V)(0D))).V), "e", ((V)("blink"))), "wait", ((V)(200D)));
return Invoke(t_3395, "back", ((V)(420D)));
return default;
}, 1, "mirror", false)).Put("dry", Fn((V _self3397, int _argc3398, V t_3404, V _a3401, V _a3402, V _a3403, V[] _rest3399) => {
V B_3405 = default;
if (_self3397.IsNullish) _self3397 = GlobalV;
B_3405 = Get(t_3404, "B");
Invoke(Invoke(Invoke(t_3404, "to", ((V)(320D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(7D)), ((V)(5D))), NewObj(4).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("ly", ((V)(0.8))).Put("pitch", ((V)((ToNum(Get(B_3405, "pitch")) - 0.04)))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(5D)), NewObj(2).Put("hLy", ((V)(8D))).Put("hRy", ((V)(2D))).V, NewObj(2).Put("hLy", ((V)(2D))).Put("hRy", ((V)(8D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V);
return Invoke(t_3404, "back", ((V)(380D)));
return default;
}, 1, "dry", false)).V;
BR0_104 = Call(o_10, V.Undef, NewObj(16).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)((-0.04)))).Put("ly", ((V)(0.2))).Put("lx", ((V)(0D))).Put("armR", ((V)(36D))).Put("armL", ((V)(16D))).Put("open", ((V)(0.28))).Put("mw", ((V)(1.35))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.2))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("puff", ((V)(0D))).V, Call(hand_12, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-13D)))), Call(hand_12, V.Undef, ((V)((-1D))), ((V)(5D)), ((V)(3D))));
BRB_105 = NewObj(5).Put("brush", Fn((V _self3406, int _argc3407, V t_3413, V _a3410, V _a3411, V _a3412, V[] _rest3408) => {
V B_3414 = default;
if (_self3406.IsNullish) _self3406 = GlobalV;
B_3414 = Get(t_3413, "B");
Invoke(t_3413, "to", ((V)(160D)), NewObj(1).Put("sqz", ((V)(0.25))).V);
{
double i_3415 = 0;
i_3415 = 0D;
while (true) {
if (!((i_3415 < 9D))) break;
Invoke(Invoke(t_3413, "to", ((V)(110D)), NewObj(2).Put("hRx", ((V)((ToNum(Get(B_3414, "hRx")) - 2.4)))).Put("htilt", ((V)(2.5))).V, ((V)("l"))), "to", ((V)(110D)), NewObj(2).Put("hRx", Add(Get(B_3414, "hRx"), ((V)(2.4)))).Put("htilt", ((V)((-2.5)))).V, ((V)("l")));
if (((i_3415 % 3D) == 1D)) {
Invoke(t_3413, "fx", ((V)("foam")), ((V)("mouth")), ((V)(1D)));
}
i_3415++;
}
}
return Invoke(t_3413, "back", ((V)(260D)));
return default;
}, 1, "brush", false)).Put("side", Fn((V _self3417, int _argc3418, V t_3424, V _a3421, V _a3422, V _a3423, V[] _rest3419) => {
V B_3425 = default;
if (_self3417.IsNullish) _self3417 = GlobalV;
B_3425 = Get(t_3424, "B");
Invoke(t_3424, "to", ((V)(300D)), NewObj(6).Put("lx", ((V)((-0.6)))).Put("htilt", ((V)((-7D)))).Put("armR", Add(Get(B_3425, "armR"), ((V)(8D)))).Put("hRy", ((V)((ToNum(Get(B_3425, "hRy")) - 1D)))).Put("hRx", Add(Get(B_3425, "hRx"), ((V)(2D)))).Put("mw", ((V)(1.1))).V, ((V)("io")));
{
double i_3426 = 0;
i_3426 = 0D;
while (true) {
if (!((i_3426 < 7D))) break;
Invoke(Invoke(t_3424, "to", ((V)(110D)), NewObj(1).Put("hRy", ((V)((ToNum(Get(B_3425, "hRy")) - 3.4)))).V, ((V)("l"))), "to", ((V)(110D)), NewObj(1).Put("hRy", ((V)((ToNum(Get(B_3425, "hRy")) - 0.4)))).V, ((V)("l")));
i_3426++;
}
}
Invoke(t_3424, "fx", ((V)("foam")), ((V)("mouth")), ((V)(2D)));
return Invoke(t_3424, "back", ((V)(300D)));
return default;
}, 1, "side", false)).Put("gargle", Fn((V _self3428, int _argc3429, V t_3435, V _a3432, V _a3433, V _a3434, V[] _rest3430) => {
V B_3436 = default;
if (_self3428.IsNullish) _self3428 = GlobalV;
B_3436 = Get(t_3435, "B");
Invoke(Invoke(Invoke(Invoke(t_3435, "to", ((V)(340D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(6D)), ((V)(1D))), NewObj(6).Put("armR", ((V)(16D))).Put("pitch", Add(Get(B_3436, "pitch"), ((V)(0.34)))).Put("ly", ((V)((-0.8)))).Put("open", ((V)(0.38))).Put("mw", ((V)(0.7))).Put("close", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(1000D)), ((V)(9D)), NewObj(2).Put("sq", Add(Get(B_3436, "sq"), ((V)(0.025)))).Put("puff", ((V)(0.5))).V, NewObj(2).Put("sq", Get(B_3436, "sq")).Put("puff", ((V)(0.2))).V, ((V)("l"))), "fx", ((V)("bubble")), ((V)("mouth")), ((V)(3D))), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0.7))).Put("open", ((V)(0D))).V);
return t_3435;
return default;
}, 1, "gargle", false)).Put("spit", Fn((V _self3437, int _argc3438, V t_3444, V _a3441, V _a3442, V _a3443, V[] _rest3439) => {
V B_3445 = default;
if (_self3437.IsNullish) _self3437 = GlobalV;
B_3445 = Get(t_3444, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_3444, "to", ((V)(320D)), NewObj(5).Put("pitch", ((V)((ToNum(Get(B_3445, "pitch")) - 0.3)))).Put("ly", ((V)(0.9))).Put("puff", ((V)(0.9))).Put("open", ((V)(0D))).Put("close", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.45))).Put("sq", Add(Get(B_3445, "sq"), ((V)(0.04)))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("mouth")), ((V)(5D))), "wait", ((V)(260D))), "to", ((V)(200D)), NewObj(2).Put("open", ((V)(0.1))).Put("sq", Get(B_3445, "sq")).V);
return Invoke(t_3444, "back", ((V)(380D)));
return default;
}, 1, "spit", false)).Put("grin", Fn((V _self3446, int _argc3447, V t_3453, V X_3454, V _a3451, V _a3452, V[] _rest3448) => {
V B_3455 = default;
if (_self3446.IsNullish) _self3446 = GlobalV;
B_3455 = Get(t_3453, "B");
Invoke(Invoke(Invoke(t_3453, "to", ((V)(300D)), Call(o_10, V.Undef, NewObj(7).Put("smile", ((V)(1D))).Put("hap", ((V)(0.7))).Put("open", ((V)(0.3))).Put("mw", ((V)(1.55))).Put("wide", ((V)(0.4))).Put("pitch", Add(Get(B_3455, "pitch"), ((V)(0.06)))).Put("ly", ((V)(0D))).V, Get(X_3454, "cheer")), ((V)("o"))), "fx", ((V)("spark")), ((V)("mouth")), ((V)(4D))), "wait", ((V)(900D)));
return Invoke(t_3453, "back", ((V)(420D)));
return default;
}, 2, "grin", false)).V;
DNB_107 = NewObj(6).Put("bite", Fn((V _self3456, int _argc3457, V t_3463, V X_3464, V rec_3465, V _a3462, V[] _rest3458) => {
V B_3466 = default;
V p0_3467 = default;
V Q_3468 = default;
V md_3469 = default;
if (_self3456.IsNullish) _self3456 = GlobalV;
B_3466 = Get(t_3463, "B");
p0_3467 = (Get(B_3466, "pitch") is var _t3470 && Truthy(_t3470) ? _t3470 : ((V)(0D)));
Q_3468 = (Get(B_3466, "sq") is var _t3471 && Truthy(_t3471) ? _t3471 : ((V)(0D)));
md_3469 = Get(X_3464, "_dm");
if (SEqS(md_3469, "lap")) {
Invoke(t_3463, "to", ((V)(340D)), NewObj(4).Put("pitch", ((V)((ToNum(p0_3467) - 0.24)))).Put("ly", ((V)(0.7))).Put("open", ((V)(0.3))).Put("sq", Add(Q_3468, ((V)(0.03)))).V, ((V)("io")));
} else {
if (SEqS(md_3469, "two")) {
Invoke(t_3463, "to", ((V)(340D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(9D)), ((V)((-12D)))), NewObj(5).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("open", ((V)(0.35))).Put("pitch", Add(p0_3467, ((V)(0.02)))).Put("ly", ((V)(0D))).V), ((V)("io")));
} else {
Invoke(t_3463, "to", ((V)(340D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-13D)))), NewObj(4).Put("armR", ((V)(34D))).Put("open", ((V)(0.35))).Put("pitch", Add(p0_3467, ((V)(0.02)))).Put("ly", ((V)(0D))).V), ((V)("io")));
}
}
Invoke(t_3463, "to", ((V)(120D)), NewObj(3).Put("open", ((V)(0D))).Put("puff", ((V)(0.55))).Put("sq", Add(Q_3468, ((V)(0.02)))).V, ((V)("o")));
Invoke(Set(rec_3465, "bite", (Get(rec_3465, "bite") is var _t3472 && Truthy(_t3472) ? _t3472 : Arr())), "push", Get(t_3463, "t"));
Invoke(Invoke(t_3463, "fx", ((V)("crumb")), ((V)("mouth")), ((V)(3D))), "osc", ((V)(900D)), ((V)(5D)), NewObj(2).Put("puff", ((V)(0.6))).Put("open", ((V)(0.12))).V, NewObj(2).Put("puff", ((V)(0.2))).Put("open", ((V)(0D))).V, ((V)("l")));
return Invoke(t_3463, "back", ((V)(320D)));
return default;
}, 3, "bite", false)).Put("chew", Fn((V _self3473, int _argc3474, V t_3480, V _a3477, V _a3478, V _a3479, V[] _rest3475) => {
if (_self3473.IsNullish) _self3473 = GlobalV;
Invoke(BEAT_16, "hum", t_3480);
return t_3480;
return default;
}, 1, "chew", false)).Put("sip", Fn((V _self3481, int _argc3482, V t_3488, V _a3485, V _a3486, V _a3487, V[] _rest3483) => {
V B_3489 = default;
if (_self3481.IsNullish) _self3481 = GlobalV;
B_3489 = Get(t_3488, "B");
Invoke(Invoke(Invoke(Invoke(t_3488, "to", ((V)(340D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)(9D)), ((V)((-13D)))), NewObj(3).Put("armL", ((V)(34D))).Put("pitch", Add(Get(B_3489, "pitch"), ((V)(0.12)))).Put("ly", ((V)((-0.2)))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("puff", ((V)(0.3))).Put("close", ((V)(0.5))).V, NewObj(2).Put("puff", ((V)(0D))).Put("close", ((V)(0.3))).V, ((V)("l"))), "to", ((V)(240D)), NewObj(4).Put("close", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(300D)));
return Invoke(t_3488, "back", ((V)(380D)));
return default;
}, 1, "sip", false)).Put("crumbs", Fn((V _self3490, int _argc3491, V t_3497, V _a3494, V _a3495, V _a3496, V[] _rest3492) => {
V B_3498 = default;
if (_self3490.IsNullish) _self3490 = GlobalV;
B_3498 = Get(t_3497, "B");
Invoke(Invoke(Invoke(t_3497, "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)(7D))), NewObj(3).Put("armL", ((V)(10D))).Put("ly", ((V)(0.8))).Put("pitch", ((V)((ToNum(Get(B_3498, "pitch")) - 0.08)))).V), ((V)("io"))), "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("hLx", ((V)(9D))).V, NewObj(1).Put("hLx", ((V)(4D))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("belly")), ((V)(4D)));
return Invoke(t_3497, "back", ((V)(320D)));
return default;
}, 1, "crumbs", false)).Put("lick", Fn((V _self3499, int _argc3500, V t_3506, V _a3503, V _a3504, V _a3505, V[] _rest3501) => {
if (_self3499.IsNullish) _self3499 = GlobalV;
Invoke(Invoke(Invoke(t_3506, "to", ((V)(360D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)(8D)), ((V)((-12D)))), NewObj(2).Put("armL", ((V)(32D))).Put("close", ((V)(0.5))).V), ((V)("io"))), "osc", ((V)(1100D)), ((V)(5D)), NewObj(1).Put("tongue", ((V)(0.6))).V, NewObj(1).Put("tongue", ((V)(0.1))).V, ((V)("s"))), "to", ((V)(160D)), NewObj(1).Put("tongue", ((V)(0D))).V);
return Invoke(t_3506, "back", ((V)(380D)));
return default;
}, 1, "lick", false)).Put("yum", Fn((V _self3507, int _argc3508, V t_3514, V X_3515, V _a3512, V _a3513, V[] _rest3509) => {
if (_self3507.IsNullish) _self3507 = GlobalV;
Invoke(BEAT_16, "belly", t_3514, ((V)((-1D))));
Invoke(Invoke(Invoke(t_3514, "to", ((V)(240D)), Call(o_10, V.Undef, NewObj(3).Put("smile", ((V)(1D))).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.6))).V, Get(X_3515, "cheer")), ((V)("o"))), "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "wait", ((V)(400D)));
return Invoke(t_3514, "back", ((V)(400D)));
return default;
}, 2, "yum", false)).V;
SF0_109 = NewObj(17).Put("sq", ((V)(0.08))).Put("lift", ((V)((-1.2)))).Put("pitch", ((V)(0.04))).Put("armL", ((V)(82D))).Put("armR", ((V)(82D))).Put("hLx", ((V)((-9D)))).Put("hRx", ((V)(9D))).Put("hLy", ((V)((-1D)))).Put("hRy", ((V)((-1D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.4))).Put("wide", ((V)(0.2))).V;
SFB_110 = NewObj(6).Put("wobble", Fn((V _self3516, int _argc3517, V t_3523, V _a3520, V _a3521, V _a3522, V[] _rest3518) => {
V B_3524 = default;
if (_self3516.IsNullish) _self3516 = GlobalV;
B_3524 = Get(t_3523, "B");
Invoke(Invoke(t_3523, "to", ((V)(160D)), NewObj(1).Put("wide", ((V)(0.6))).V), "osc", ((V)(1600D)), ((V)(3D)), NewObj(4).Put("tilt", ((V)(7D))).Put("armL", ((V)(98D))).Put("armR", ((V)(58D))).Put("x", ((V)(0.8))).V, NewObj(4).Put("tilt", ((V)((-7D)))).Put("armL", ((V)(58D))).Put("armR", ((V)(98D))).Put("x", ((V)((-0.8)))).V, ((V)("s")));
return Invoke(t_3523, "back", ((V)(400D)));
return default;
}, 1, "wobble", false)).Put("crouch", Fn((V _self3525, int _argc3526, V t_3532, V _a3529, V _a3530, V _a3531, V[] _rest3527) => {
V B_3533 = default;
if (_self3525.IsNullish) _self3525 = GlobalV;
B_3533 = Get(t_3532, "B");
Invoke(Invoke(Invoke(t_3532, "to", ((V)(400D)), NewObj(8).Put("sq", Add(Get(B_3533, "sq"), ((V)(0.1)))).Put("lift", ((V)((ToNum(Get(B_3533, "lift")) - 1.6)))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).Put("hLy", ((V)(2D))).Put("hRy", ((V)(2D))).Put("pitch", ((V)((ToNum(Get(B_3533, "pitch")) - 0.08)))).Put("sqz", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(600D))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)((ToNum(Get(B_3533, "sq")) - 0.06)))).Put("lift", Add(Get(B_3533, "lift"), ((V)(1.5)))).Put("sqz", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o")));
return Invoke(t_3532, "back", ((V)(400D)));
return default;
}, 1, "crouch", false)).Put("carve", Fn((V _self3534, int _argc3535, V t_3541, V _a3538, V _a3539, V _a3540, V[] _rest3536) => {
if (_self3534.IsNullish) _self3534 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3541, "to", ((V)(500D)), NewObj(6).Put("tilt", ((V)(9D))).Put("lean", ((V)(1.4))).Put("armL", ((V)(110D))).Put("armR", ((V)(40D))).Put("htilt", ((V)((-6D)))).Put("smile", ((V)(1D))).V, ((V)("s"))), "fx", ((V)("gust")), ((V)("head"))), "wait", ((V)(700D))), "to", ((V)(600D)), NewObj(5).Put("tilt", ((V)((-9D)))).Put("lean", ((V)((-1.4)))).Put("armL", ((V)(40D))).Put("armR", ((V)(110D))).Put("htilt", ((V)(6D))).V, ((V)("s"))), "fx", ((V)("splash")), ((V)("belly")), ((V)(4D))), "wait", ((V)(500D)));
return Invoke(t_3541, "back", ((V)(500D)));
return default;
}, 1, "carve", false)).Put("bump", Fn((V _self3542, int _argc3543, V t_3549, V _a3546, V _a3547, V _a3548, V[] _rest3544) => {
V B_3550 = default;
if (_self3542.IsNullish) _self3542 = GlobalV;
B_3550 = Get(t_3549, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_3549, "to", ((V)(200D)), NewObj(2).Put("sq", Add(Get(B_3550, "sq"), ((V)(0.08)))).Put("lift", ((V)((ToNum(Get(B_3550, "lift")) - 1D)))).V, ((V)("i"))), "to", ((V)(260D)), NewObj(6).Put("sq", ((V)((ToNum(Get(B_3550, "sq")) - 0.08)))).Put("lift", Add(Get(B_3550, "lift"), ((V)(5D)))).Put("armL", ((V)(110D))).Put("armR", ((V)(110D))).Put("open", ((V)(0.4))).Put("hap", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("splash")), ((V)("belly")), ((V)(6D))), "to", ((V)(260D)), NewObj(2).Put("sq", Add(Get(B_3550, "sq"), ((V)(0.1)))).Put("lift", Get(B_3550, "lift")).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(B_3550, "sq")).V, ((V)("io")));
return Invoke(t_3549, "back", ((V)(300D)));
return default;
}, 1, "bump", false)).Put("hang10", Fn((V _self3551, int _argc3552, V t_3558, V X_3559, V _a3556, V _a3557, V[] _rest3553) => {
if (_self3551.IsNullish) _self3551 = GlobalV;
Invoke(t_3558, "to", ((V)(320D)), Call(o_10, V.Undef, NewObj(6).Put("armR", ((V)(158D))).Put("hRy", ((V)((-6D)))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("hap", ((V)(1D))).Put("wide", ((V)(0.4))).V, Get(X_3559, "cheer")), ((V)("o")));
if (Truthy(Get(X_3559, "cheerFx"))) {
InvokeSpread(t_3558, "fx", new ArrBuilder().Spread(Get(X_3559, "cheerFx")).V);
} else {
Invoke(t_3558, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
}
Invoke(t_3558, "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("armR", ((V)(140D))).V, NewObj(1).Put("armR", ((V)(165D))).V, ((V)("io")));
return Invoke(t_3558, "back", ((V)(420D)));
return default;
}, 2, "hang10", false)).Put("wipe", Fn((V _self3560, int _argc3561, V t_3567, V _a3564, V _a3565, V _a3566, V[] _rest3562) => {
if (_self3560.IsNullish) _self3560 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3567, "to", ((V)(150D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.5))).Put("tilt", ((V)(12D))).Put("x", ((V)(1.5))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(150D))).Put("armR", ((V)(30D))).V, NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(150D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(2).Put("tilt", ((V)((-4D)))).Put("x", ((V)((-0.5)))).V), "to", ((V)(300D)), NewObj(3).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("wide", ((V)(0.3))).V), "fx", ((V)("sweat")), ((V)("head"))), "to", ((V)(300D)), NewObj(4).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
return Invoke(t_3567, "back", ((V)(420D)));
return default;
}, 1, "wipe", false)).V;
FS0_111 = Call(o_10, V.Undef, NewObj(11).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0.02))).Put("armL", ((V)(24D))).Put("armR", ((V)(30D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("smile", ((V)(0.6))).Put("hap", ((V)(0.2))).V, Call(hand_12, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-4D)))), Call(hand_12, V.Undef, ((V)((-1D))), ((V)(9D)), ((V)((-2D)))));
FB_112 = NewObj(4).Put("cast", Fn((V _self3568, int _argc3569, V t_3575, V X_3576, V rec_3577, V _a3574, V[] _rest3570) => {
V B_3578 = default;
V a_3579 = default;
V f_3580 = default;
if (_self3568.IsNullish) _self3568 = GlobalV;
B_3578 = Get(t_3575, "B");
Invoke(t_3575, "to", ((V)(160D)), NewObj(2).Put("sqz", ((V)(0.3))).Put("ly", ((V)((-0.2)))).V);
a_3579 = Get(t_3575, "t");
Invoke(t_3575, "to", ((V)(420D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-10D)))), NewObj(5).Put("armR", ((V)(128D))).Put("armL", ((V)(60D))).Put("lean", ((V)((-1D)))).Put("tilt", ((V)((-4D)))).Put("pitch", Add(Get(B_3578, "pitch"), ((V)(0.1)))).V), ((V)("io")));
f_3580 = Get(t_3575, "t");
Invoke(t_3575, "to", ((V)(180D)), NewObj(8).Put("armR", ((V)(44D))).Put("hRy", ((V)((-5D)))).Put("armL", ((V)(32D))).Put("lean", ((V)(1.2))).Put("tilt", ((V)(3D))).Put("sqz", ((V)(0D))).Put("open", ((V)(0.35))).Put("pitch", ((V)((ToNum(Get(B_3578, "pitch")) - 0.04)))).V, ((V)("o")));
Invoke(Set(rec_3577, "cast", (Get(rec_3577, "cast") is var _t3581 && Truthy(_t3581) ? _t3581 : Arr())), "push", Arr(a_3579, f_3580));
Invoke(Invoke(t_3575, "to", ((V)(420D)), NewObj(3).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(400D)));
return Invoke(t_3575, "back", ((V)(400D)));
return default;
}, 3, "cast", false)).Put("nibble", Fn((V _self3582, int _argc3583, V t_3589, V X_3590, V rec_3591, V _a3588, V[] _rest3584) => {
V B_3592 = default;
if (_self3582.IsNullish) _self3582 = GlobalV;
B_3592 = Get(t_3589, "B");
Invoke(t_3589, "to", ((V)(200D)), NewObj(6).Put("wide", ((V)(0.8))).Put("pitch", ((V)((ToNum(Get(B_3592, "pitch")) - 0.1)))).Put("ly", ((V)(0.7))).Put("lean", ((V)(0.6))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).V, ((V)("o")));
Invoke(Set(rec_3591, "nib", (Get(rec_3591, "nib") is var _t3593 && Truthy(_t3593) ? _t3593 : Arr())), "push", Get(t_3589, "t"));
Invoke(Invoke(t_3589, "osc", ((V)(700D)), ((V)(2D)), NewObj(1).Put("hRy", Add(Get(B_3592, "hRy"), ((V)(1.5)))).V, NewObj(1).Put("hRy", Get(B_3592, "hRy")).V, ((V)("l"))), "wait", ((V)(400D)));
return Invoke(t_3589, "back", ((V)(380D)));
return default;
}, 3, "nibble", false)).Put("reel", Fn((V _self3594, int _argc3595, V t_3601, V X_3602, V rec_3603, V _a3600, V[] _rest3596) => {
V B_3604 = default;
V a_3605 = default;
if (_self3594.IsNullish) _self3594 = GlobalV;
B_3604 = Get(t_3601, "B");
a_3605 = Get(t_3601, "t");
Invoke(t_3601, "to", ((V)(150D)), NewObj(7).Put("armR", ((V)(66D))).Put("hRy", ((V)((ToNum(Get(B_3604, "hRy")) - 4D)))).Put("lean", ((V)((-1D)))).Put("tilt", ((V)((-3D)))).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.5))).V, ((V)("o")));
{
double i_3606 = 0;
i_3606 = 0D;
while (true) {
if (!((i_3606 < 6D))) break;
Invoke(Invoke(Invoke(Invoke(t_3601, "to", ((V)(140D)), NewObj(3).Put("hLx", Add(Get(B_3604, "hLx"), ((V)(2D)))).Put("hLy", ((V)((ToNum(Get(B_3604, "hLy")) - 2D)))).Put("tilt", ((V)((-4D)))).V, ((V)("l"))), "to", ((V)(140D)), NewObj(2).Put("hLx", Get(B_3604, "hLx")).Put("hLy", ((V)((ToNum(Get(B_3604, "hLy")) - 4D)))).V, ((V)("l"))), "to", ((V)(140D)), NewObj(3).Put("hLx", ((V)((ToNum(Get(B_3604, "hLx")) - 2D)))).Put("hLy", ((V)((ToNum(Get(B_3604, "hLy")) - 2D)))).Put("tilt", ((V)((-2D)))).V, ((V)("l"))), "to", ((V)(140D)), NewObj(2).Put("hLx", Get(B_3604, "hLx")).Put("hLy", Get(B_3604, "hLy")).V, ((V)("l")));
i_3606++;
}
}
Invoke(t_3601, "fx", ((V)("sweat")), ((V)("head")));
Invoke(Set(rec_3603, "reel", (Get(rec_3603, "reel") is var _t3608 && Truthy(_t3608) ? _t3608 : Arr())), "push", Arr(a_3605, Get(t_3601, "t")));
return t_3601;
return default;
}, 3, "reel", false)).Put("catch", Fn((V _self3609, int _argc3610, V t_3616, V X_3617, V rec_3618, V _a3615, V[] _rest3611) => {
V a_3619 = default;
if (_self3609.IsNullish) _self3609 = GlobalV;
a_3619 = Get(t_3616, "t");
Invoke(t_3616, "to", ((V)(240D)), Call(o_10, V.Undef, NewObj(14).Put("armR", ((V)(150D))).Put("hRy", ((V)((-10D)))).Put("hRx", ((V)(0D))).Put("armL", ((V)(124D))).Put("hLy", ((V)((-8D)))).Put("hLx", ((V)(0D))).Put("lift", ((V)(2.4))).Put("sq", ((V)((-0.06)))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("wide", ((V)(0.5))).V, Get(X_3617, "cheer")), ((V)("o")));
if (Truthy(Get(X_3617, "cheerFx"))) {
InvokeSpread(t_3616, "fx", new ArrBuilder().Spread(Get(X_3617, "cheerFx")).V);
} else {
Invoke(t_3616, "fx", ((V)("spark")), ((V)("head")), ((V)(4D)));
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_3616, "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V), "wait", ((V)(600D))), "to", ((V)(400D)), NewObj(5).Put("htilt", ((V)(8D))).Put("lx", ((V)(0.6))).Put("ly", ((V)((-0.6)))).Put("armR", ((V)(128D))).Put("open", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(800D)));
Invoke(Set(rec_3618, "catch", (Get(rec_3618, "catch") is var _t3620 && Truthy(_t3620) ? _t3620 : Arr())), "push", Arr(a_3619, Get(t_3616, "t")));
return Invoke(t_3616, "back", ((V)(450D)));
return default;
}, 3, "catch", false)).V;
SUNB_114 = NewObj(6).Put("sigh", Fn((V _self3621, int _argc3622, V t_3628, V _a3625, V _a3626, V _a3627, V[] _rest3623) => {
if (_self3621.IsNullish) _self3621 = GlobalV;
Invoke(BEAT_16, "sigh", t_3628);
return t_3628;
return default;
}, 1, "sigh", false)).Put("doze", Fn((V _self3629, int _argc3630, V t_3636, V _a3633, V _a3634, V _a3635, V[] _rest3631) => {
if (_self3629.IsNullish) _self3629 = GlobalV;
Invoke(BEAT_16, "doze", t_3636);
return t_3636;
return default;
}, 1, "doze", false)).Put("toes", Fn((V _self3637, int _argc3638, V t_3644, V _a3641, V _a3642, V _a3643, V[] _rest3639) => {
V B_3645 = default;
if (_self3637.IsNullish) _self3637 = GlobalV;
B_3645 = Get(t_3644, "B");
Invoke(Invoke(t_3644, "osc", ((V)(1600D)), ((V)(4D)), NewObj(2).Put("footL", Add(Get(B_3645, "footL"), ((V)(1.6)))).Put("footR", ((V)((ToNum(Get(B_3645, "footR")) - 0.4)))).V, NewObj(2).Put("footL", ((V)((ToNum(Get(B_3645, "footL")) - 0.4)))).Put("footR", Add(Get(B_3645, "footR"), ((V)(1.6)))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(1).Put("smile", ((V)(1D))).V);
return Invoke(t_3644, "back", ((V)(360D)));
return default;
}, 1, "toes", false)).Put("sip", Fn((V _self3646, int _argc3647, V t_3653, V _a3650, V _a3651, V _a3652, V[] _rest3648) => {
V B_3654 = default;
if (_self3646.IsNullish) _self3646 = GlobalV;
B_3654 = Get(t_3653, "B");
Invoke(Invoke(Invoke(Invoke(t_3653, "to", ((V)(400D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-12D)))), NewObj(2).Put("armR", ((V)(40D))).Put("pitch", ((V)((ToNum(Get(B_3654, "pitch")) - 0.06)))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("puff", ((V)(0.35))).V, NewObj(1).Put("puff", ((V)(0D))).V, ((V)("l"))), "to", ((V)(240D)), NewObj(3).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(300D)));
return Invoke(t_3653, "back", ((V)(420D)));
return default;
}, 1, "sip", false)).Put("lotion", Fn((V _self3655, int _argc3656, V t_3662, V _a3659, V _a3660, V _a3661, V[] _rest3657) => {
if (_self3655.IsNullish) _self3655 = GlobalV;
Invoke(Invoke(Invoke(t_3662, "to", ((V)(360D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)(6D))), NewObj(1).Put("armL", ((V)(10D))).V), ((V)("io"))), "osc", ((V)(1400D)), ((V)(4D)), NewObj(2).Put("hLx", ((V)(9D))).Put("hLy", ((V)(4D))).V, NewObj(2).Put("hLx", ((V)(4D))).Put("hLy", ((V)(8D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("belly")), ((V)(2D)));
return Invoke(t_3662, "back", ((V)(380D)));
return default;
}, 1, "lotion", false)).Put("peek", Fn((V _self3663, int _argc3664, V t_3670, V _a3667, V _a3668, V _a3669, V[] _rest3665) => {
V B_3671 = default;
if (_self3663.IsNullish) _self3663 = GlobalV;
B_3671 = Get(t_3670, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_3670, "to", ((V)(300D)), NewObj(7).Put("shu", ((V)(1D))).Put("wide", ((V)(0.7))).Put("lx", ((V)(0.6))).Put("ly", ((V)((-0.3)))).Put("pitch", ((V)((ToNum(Get(B_3671, "pitch")) - 0.1)))).Put("htilt", ((V)((ToNum(Get(B_3671, "htilt")) - 3D)))).Put("close", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(900D))), "to", ((V)(200D)), NewObj(3).Put("sqz", ((V)(0.5))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(6).Put("shu", ((V)(0D))).Put("wide", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("sqz", ((V)(0D))).Put("hap", Get(B_3671, "hap")).V, ((V)("io")));
return Invoke(t_3670, "back", ((V)(300D)));
return default;
}, 1, "peek", false)).V;
SHADES_115 = ((V)(JsStrBuf.Begin().S("<path d=\"M-9.4-1.2L-12.8-2.6M9.4-1.2L12.8-2.6\" stroke=\"#2a1a30\" stroke-width=\"0.7\" stroke-linecap=\"round\"/><path d=\"M-1.4-0.6Q0-1.8 1.4-0.6\" stroke=\"#2a1a30\" stroke-width=\"0.8\" fill=\"none\"/>").V(Invoke(Invoke(Arr(((V)((-5D))), ((V)(5D))), "map", Fn((V _arrowThis3679, int _argc3672, V x_3678, V _a3675, V _a3676, V _a3677, V[] _rest3673) => {
return ((V)(JsStrBuf.Begin().S("<ellipse cx=\"").V(x_3678).S("\" cy=\"0\" rx=\"4.1\" ry=\"3.2\" fill=\"#2a2440\" stroke=\"#e8483c\" stroke-width=\"0.6\"/><path d=\"M").N((ToNum(x_3678) - 2.4)).S(" -1.2Q").N((ToNum(x_3678) - 1D)).S(" -2.4 ").V(Add(x_3678, ((V)(1D)))).S(" -2\" stroke=\"#ffffff\" stroke-width=\"0.7\" fill=\"none\" opacity=\"0.7\" stroke-linecap=\"round\"/>").End()));
}, 1, "", true)), "join", ((V)("")))).End()));
TB0_120 = NewObj(14).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.5))).Put("open", ((V)(0.1))).V;
TBB_121 = NewObj(6).Put("hop", Fn((V _self3680, int _argc3681, V t_3687, V _a3684, V _a3685, V _a3686, V[] _rest3682) => {
V B_3688 = default;
if (_self3680.IsNullish) _self3680 = GlobalV;
B_3688 = Get(t_3687, "B");
{
double i_3689 = 0;
i_3689 = 0D;
while (true) {
if (!((i_3689 < 2D))) break;
Invoke(Invoke(Invoke(t_3687, "to", ((V)(110D)), NewObj(2).Put("sq", Add(Get(B_3688, "sq"), ((V)(0.1)))).Put("lift", ((V)((ToNum(Get(B_3688, "lift")) - 1D)))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)((ToNum(Get(B_3688, "sq")) - 0.05)))).Put("lift", Add(Get(B_3688, "lift"), ((V)(5D)))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(4).Put("sq", Get(B_3688, "sq")).Put("lift", Get(B_3688, "lift")).Put("armL", Get(B_3688, "armL")).Put("armR", Get(B_3688, "armR")).V, ((V)("i")));
i_3689++;
}
}
return t_3687;
return default;
}, 1, "hop", false)).Put("jumps", Fn((V _self3691, int _argc3692, V t_3698, V _a3695, V _a3696, V _a3697, V[] _rest3693) => {
V B_3699 = default;
if (_self3691.IsNullish) _self3691 = GlobalV;
B_3699 = Get(t_3698, "B");
Invoke(t_3698, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V);
{
double i_3700 = 0;
i_3700 = 0D;
while (true) {
if (!((i_3700 < 3D))) break;
Invoke(Invoke(Invoke(t_3698, "to", ((V)(120D)), NewObj(4).Put("sq", Add(Get(B_3699, "sq"), ((V)(0.16)))).Put("lift", ((V)((ToNum(Get(B_3699, "lift")) - 1.6)))).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(6).Put("sq", ((V)((ToNum(Get(B_3699, "sq")) - 0.1)))).Put("lift", Add(Add(Get(B_3699, "lift"), ((V)(11D))), ((V)((i_3700 * 2D))))).Put("armL", ((V)(112D))).Put("armR", ((V)(112D))).Put("footL", ((V)(1.4))).Put("footR", ((V)(1.4))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(6).Put("sq", Add(Get(B_3699, "sq"), ((V)(0.02)))).Put("lift", Get(B_3699, "lift")).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i")));
i_3700++;
}
}
return Invoke(t_3698, "back", ((V)(200D)));
return default;
}, 1, "jumps", false)).Put("star", Fn((V _self3702, int _argc3703, V t_3709, V X_3710, V _a3707, V _a3708, V[] _rest3704) => {
V B_3711 = default;
if (_self3702.IsNullish) _self3702 = GlobalV;
B_3711 = Get(t_3709, "B");
Invoke(Invoke(Invoke(t_3709, "to", ((V)(140D)), NewObj(2).Put("sq", Add(Get(B_3711, "sq"), ((V)(0.18)))).Put("lift", ((V)((ToNum(Get(B_3711, "lift")) - 2D)))).V, ((V)("i"))), "to", ((V)(340D)), NewObj(2).Put("sq", ((V)((ToNum(Get(B_3711, "sq")) - 0.12)))).Put("lift", Add(Get(B_3711, "lift"), ((V)(16D)))).V, ((V)("o"))), "to", ((V)(180D)), Call(o_10, V.Undef, NewObj(13).Put("lift", Add(Get(B_3711, "lift"), ((V)(18D)))).Put("armL", ((V)(160D))).Put("armR", ((V)(160D))).Put("hLx", ((V)((-7D)))).Put("hRx", ((V)(7D))).Put("hLy", ((V)((-4D)))).Put("hRy", ((V)((-4D)))).Put("footL", ((V)(3D))).Put("footR", ((V)(3D))).Put("open", ((V)(0.6))).Put("wide", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, (Get(X_3710, "tk") is var _t3712 && Truthy(_t3712) ? _t3712 : Get(X_3710, "cheer"))), ((V)("o")));
if (Truthy(Get(X_3710, "cheerFx"))) {
InvokeSpread(t_3709, "fx", new ArrBuilder().Spread(Get(X_3710, "cheerFx")).V);
} else {
Invoke(t_3709, "fx", ((V)("spark")), ((V)("body")), ((V)(4D)));
}
Invoke(Invoke(Invoke(t_3709, "to", ((V)(200D)), NewObj(10).Put("lift", Add(Get(B_3711, "lift"), ((V)(15D)))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io"))), "to", ((V)(280D)), NewObj(2).Put("lift", Get(B_3711, "lift")).Put("sq", Add(Get(B_3711, "sq"), ((V)(0.14)))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(B_3711, "sq")).V, ((V)("o")));
return Invoke(t_3709, "back", ((V)(250D)));
return default;
}, 2, "star", false)).Put("tuck", Fn((V _self3713, int _argc3714, V t_3720, V _a3717, V _a3718, V _a3719, V[] _rest3715) => {
V B_3721 = default;
if (_self3713.IsNullish) _self3713 = GlobalV;
B_3721 = Get(t_3720, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3720, "to", ((V)(140D)), NewObj(2).Put("sq", Add(Get(B_3721, "sq"), ((V)(0.18)))).Put("lift", ((V)((ToNum(Get(B_3721, "lift")) - 2D)))).V, ((V)("i"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)((ToNum(Get(B_3721, "sq")) - 0.1)))).Put("lift", Add(Get(B_3721, "lift"), ((V)(15D)))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("o"))), "to", ((V)(180D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(7D)), ((V)(6D))), NewObj(8).Put("lift", Add(Get(B_3721, "lift"), ((V)(17D)))).Put("sq", Add(Get(B_3721, "sq"), ((V)(0.12)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("footL", ((V)(4D))).Put("footR", ((V)(4D))).Put("close", ((V)(1D))).Put("sqz", ((V)(0.8))).V), ((V)("io"))), "to", ((V)(180D)), NewObj(14).Put("lift", Add(Get(B_3721, "lift"), ((V)(14D)))).Put("sq", ((V)((ToNum(Get(B_3721, "sq")) - 0.06)))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("close", ((V)(0D))).Put("sqz", ((V)(0D))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.45))).V, ((V)("io"))), "to", ((V)(280D)), NewObj(2).Put("lift", Get(B_3721, "lift")).Put("sq", Add(Get(B_3721, "sq"), ((V)(0.14)))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", Get(B_3721, "sq")).Put("wide", ((V)(0D))).V, ((V)("o")));
return Invoke(t_3720, "back", ((V)(250D)));
return default;
}, 1, "tuck", false)).Put("seat", Fn((V _self3722, int _argc3723, V t_3729, V _a3726, V _a3727, V _a3728, V[] _rest3724) => {
V B_3730 = default;
if (_self3722.IsNullish) _self3722 = GlobalV;
B_3730 = Get(t_3729, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3729, "to", ((V)(130D)), NewObj(2).Put("sq", Add(Get(B_3730, "sq"), ((V)(0.14)))).Put("lift", ((V)((ToNum(Get(B_3730, "lift")) - 1.4)))).V, ((V)("i"))), "to", ((V)(280D)), NewObj(4).Put("sq", ((V)((ToNum(Get(B_3730, "sq")) - 0.08)))).Put("lift", Add(Get(B_3730, "lift"), ((V)(10D)))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).V, ((V)("o"))), "to", ((V)(260D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(4D)), ((V)(2D))), NewObj(8).Put("sit", ((V)(1D))).Put("sq", Add(Get(B_3730, "sq"), ((V)(0.06)))).Put("lift", Add(Get(B_3730, "lift"), ((V)(4D)))).Put("footL", ((V)(2.4))).Put("footR", ((V)(2.4))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("open", ((V)(0.4))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("lift", ((V)((ToNum(Get(B_3730, "lift")) - 1.5)))).Put("sq", Add(Get(B_3730, "sq"), ((V)(0.2)))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(13).Put("sit", ((V)(0D))).Put("lift", Add(Get(B_3730, "lift"), ((V)(9D)))).Put("sq", ((V)((ToNum(Get(B_3730, "sq")) - 0.08)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(110D))).Put("armR", ((V)(110D))).Put("hLx", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(280D)), NewObj(2).Put("lift", Get(B_3730, "lift")).Put("sq", Add(Get(B_3730, "sq"), ((V)(0.1)))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(2).Put("sq", Get(B_3730, "sq")).Put("sqz", ((V)(0D))).V, ((V)("o")));
return Invoke(t_3729, "back", ((V)(250D)));
return default;
}, 1, "seat", false)).Put("spin", Fn((V _self3731, int _argc3732, V t_3738, V _a3735, V _a3736, V _a3737, V[] _rest3733) => {
V B_3739 = default;
if (_self3731.IsNullish) _self3731 = GlobalV;
B_3739 = Get(t_3738, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(t_3738, "to", ((V)(140D)), NewObj(2).Put("sq", Add(Get(B_3739, "sq"), ((V)(0.16)))).Put("lift", ((V)((ToNum(Get(B_3739, "lift")) - 1.8)))).V, ((V)("i"))), "to", ((V)(380D)), NewObj(7).Put("sq", ((V)((ToNum(Get(B_3739, "sq")) - 0.12)))).Put("lift", Add(Get(B_3739, "lift"), ((V)(16D)))).Put("spin", ((V)(180D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("hap", ((V)(1D))).Put("open", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(5).Put("spin", ((V)(360D))).Put("lift", Get(B_3739, "lift")).Put("sq", Add(Get(B_3739, "sq"), ((V)(0.12)))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("i"))), "to", ((V)(10D)), NewObj(1).Put("spin", ((V)(0D))).V), "to", ((V)(200D)), NewObj(1).Put("sq", Get(B_3739, "sq")).V, ((V)("o")));
return Invoke(t_3738, "back", ((V)(250D)));
return default;
}, 1, "spin", false)).V;
DGB_124 = NewObj(7).Put("scoop", Fn((V _self3740, int _argc3741, V t_3747, V _a3744, V _a3745, V _a3746, V[] _rest3742) => {
V B_3748 = default;
if (_self3740.IsNullish) _self3740 = GlobalV;
B_3748 = Get(t_3747, "B");
{
double i_3749 = 0;
i_3749 = 0D;
while (true) {
if (!((i_3749 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(t_3747, "to", ((V)(240D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-5D))), ((V)(9D))), NewObj(5).Put("armR", ((V)(14D))).Put("lean", ((V)(0.4))).Put("tilt", ((V)(2D))).Put("lx", ((V)(0.6))).Put("ly", ((V)(0.8))).V), ((V)("i"))), "to", ((V)(260D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(6D)), ((V)(2D))), NewObj(5).Put("armR", ((V)(26D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0.7))).V), ((V)("o"))), "fx", ((V)("sand")), ((V)("pawR")), ((V)(4D))), "wait", ((V)(100D)));
i_3749++;
}
}
return Invoke(t_3747, "back", ((V)(300D)));
return default;
}, 1, "scoop", false)).Put("pile", Fn((V _self3751, int _argc3752, V t_3758, V _a3755, V _a3756, V _a3757, V[] _rest3753) => {
V B_3759 = default;
if (_self3751.IsNullish) _self3751 = GlobalV;
B_3759 = Get(t_3758, "B");
Invoke(Invoke(Invoke(t_3758, "to", ((V)(300D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(8D)), ((V)(7D))), NewObj(3).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("ly", ((V)(0.8))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(3).Put("hLy", ((V)(10D))).Put("hRy", ((V)(10D))).Put("sq", Add(Get(B_3759, "sq"), ((V)(0.02)))).V, NewObj(3).Put("hLy", ((V)(6D))).Put("hRy", ((V)(6D))).Put("sq", Get(B_3759, "sq")).V, ((V)("o"))), "fx", ((V)("sand")), ((V)("pawL")), ((V)(3D)));
return Invoke(t_3758, "back", ((V)(320D)));
return default;
}, 1, "pile", false)).Put("bucket", Fn((V _self3760, int _argc3761, V t_3767, V X_3768, V rec_3769, V _a3766, V[] _rest3762) => {
V B_3770 = default;
V g_3771 = default;
V s_3772 = default;
V l_3773 = default;
V e_3774 = default;
if (_self3760.IsNullish) _self3760 = GlobalV;
B_3770 = Get(t_3767, "B");
Invoke(t_3767, "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-9D))), ((V)(7D))), NewObj(4).Put("armR", ((V)(20D))).Put("lx", ((V)(0.7))).Put("ly", ((V)(0.7))).Put("tilt", ((V)(2D))).V), ((V)("io")));
g_3771 = Get(t_3767, "t");
Invoke(t_3767, "to", ((V)(360D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-4D)))), NewObj(4).Put("armR", ((V)(44D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0.4))).Put("tilt", ((V)(0D))).V), ((V)("io")));
Invoke(t_3767, "to", ((V)(260D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(6D)), ((V)(5D))), NewObj(2).Put("armR", ((V)(22D))).Put("sq", Add(Get(B_3770, "sq"), ((V)(0.04)))).V), ((V)("i")));
s_3772 = Get(t_3767, "t");
Invoke(Invoke(t_3767, "fx", ((V)("sand")), ((V)("pawR")), ((V)(5D))), "wait", ((V)(300D)));
Invoke(t_3767, "to", ((V)(320D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-6D)))), NewObj(4).Put("armR", ((V)(48D))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.3))).Put("sq", Get(B_3770, "sq")).V), ((V)("o")));
l_3773 = Get(t_3767, "t");
Invoke(Invoke(t_3767, "to", ((V)(200D)), NewObj(5).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("wide", ((V)(0D))).V, ((V)("o"))), "to", ((V)(380D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-9D))), ((V)(7D))), NewObj(2).Put("armR", ((V)(20D))).Put("lx", ((V)(0.7))).V), ((V)("io")));
e_3774 = Get(t_3767, "t");
Invoke(Set(rec_3769, "bk", (Get(rec_3769, "bk") is var _t3775 && Truthy(_t3775) ? _t3775 : Arr())), "push", Arr(g_3771, s_3772, l_3773, e_3774));
return Invoke(t_3767, "back", ((V)(380D)));
return default;
}, 3, "bucket", false)).Put("pat", Fn((V _self3776, int _argc3777, V t_3783, V _a3780, V _a3781, V _a3782, V[] _rest3778) => {
if (_self3776.IsNullish) _self3776 = GlobalV;
Invoke(Invoke(Invoke(t_3783, "to", ((V)(280D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(8D)), ((V)(2D))), NewObj(3).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("ly", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(5D)), NewObj(2).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V, NewObj(2).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("sand")), ((V)("pawR")), ((V)(2D)));
return Invoke(t_3783, "back", ((V)(300D)));
return default;
}, 1, "pat", false)).Put("flag", Fn((V _self3784, int _argc3785, V t_3791, V X_3792, V rec_3793, V _a3790, V[] _rest3786) => {
if (_self3784.IsNullish) _self3784 = GlobalV;
Invoke(Invoke(t_3791, "to", ((V)(340D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(5D)), ((V)((-6D)))), NewObj(2).Put("armR", ((V)(40D))).Put("ly", ((V)(0.3))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("hRy", ((V)((-2D)))).V, ((V)("i")));
Invoke(Set(rec_3793, "flag", (Get(rec_3793, "flag") is var _t3794 && Truthy(_t3794) ? _t3794 : Arr())), "push", Get(t_3791, "t"));
Invoke(t_3791, "to", ((V)(260D)), Call(o_10, V.Undef, NewObj(5).Put("hRy", ((V)((-7D)))).Put("armR", ((V)(60D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, Get(X_3792, "cheer")), ((V)("o")));
if (Truthy(Get(X_3792, "cheerFx"))) {
InvokeSpread(t_3791, "fx", new ArrBuilder().Spread(Get(X_3792, "cheerFx")).V);
} else {
Invoke(t_3791, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
}
Invoke(t_3791, "wait", ((V)(500D)));
return Invoke(t_3791, "back", ((V)(400D)));
return default;
}, 3, "flag", false)).Put("admire", Fn((V _self3795, int _argc3796, V t_3802, V _a3799, V _a3800, V _a3801, V[] _rest3797) => {
V B_3803 = default;
if (_self3795.IsNullish) _self3795 = GlobalV;
B_3803 = Get(t_3802, "B");
Invoke(Invoke(Invoke(t_3802, "to", ((V)(400D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(10D)), ((V)((-6D)))), NewObj(8).Put("armL", ((V)(28D))).Put("armR", ((V)(28D))).Put("pitch", Add(Get(B_3803, "pitch"), ((V)(0.14)))).Put("ly", ((V)(0.2))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).Put("close", ((V)(0.4))).Put("htilt", ((V)(6D))).V), ((V)("io"))), "fx", ((V)("heart")), ((V)("head"))), "wait", ((V)(900D)));
return Invoke(t_3802, "back", ((V)(420D)));
return default;
}, 1, "admire", false)).Put("crumble", Fn((V _self3804, int _argc3805, V t_3811, V X_3812, V rec_3813, V _a3810, V[] _rest3806) => {
V B_3814 = default;
if (_self3804.IsNullish) _self3804 = GlobalV;
B_3814 = Get(t_3811, "B");
Invoke(Set(rec_3813, "cr", (Get(rec_3813, "cr") is var _t3815 && Truthy(_t3815) ? _t3815 : Arr())), "push", Get(t_3811, "t"));
Invoke(Invoke(Invoke(Invoke(t_3811, "to", ((V)(200D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.55))).Put("mw", ((V)(0.5))).Put("pitch", ((V)((ToNum(Get(B_3814, "pitch")) - 0.08)))).Put("lean", ((V)((-0.6)))).Put("frown", ((V)(0.4))).V, ((V)("o"))), "wait", ((V)(700D))), "to", ((V)(240D)), NewObj(7).Put("frown", ((V)(0D))).Put("sqz", ((V)(0.8))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("wide", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("sq", Add(Get(B_3814, "sq"), ((V)(0.03)))).V, NewObj(1).Put("sq", Get(B_3814, "sq")).V, ((V)("o")));
return Invoke(t_3811, "back", ((V)(420D)));
return default;
}, 3, "crumble", false)).V;
SAND_125 = ((V)("#e6c682"));
SANDK_126 = ((V)("#b8954e"));
SANDL_127 = ((V)("#f5e0b0"));
PAIL_128 = ((V)("<path d=\"M-3-2.6H3L2.3 3H-2.3Z\" fill=\"#5ab4f0\" stroke=\"#2e86c8\" stroke-width=\"0.4\"/><path d=\"M-3-2.6H3V-1.6H-3Z\" fill=\"#ffd24a\" stroke=\"#d9a22a\" stroke-width=\"0.3\"/><path d=\"M-2.6-2.6Q0-6 2.6-2.6\" stroke=\"#2e86c8\" stroke-width=\"0.4\" fill=\"none\"/>"));
SPADE_129 = ((V)("<path d=\"M-0.45 0H0.45V7H-0.45Z\" fill=\"#ffd24a\" stroke=\"#d9a22a\" stroke-width=\"0.25\"/><path d=\"M-2 7H2V9.6Q0 12-2 9.6Z\" fill=\"#e8483c\" stroke=\"#b8302a\" stroke-width=\"0.35\"/>"));
BLC_131 = Arr(((V)("#ff6f6f")), ((V)("#ffcc3a")), ((V)("#5ab4f0")), ((V)("#7cc35a")), ((V)("#b98ae8")));
BLL_132 = ((V)("ABCDE"));
BLK_133 = Fn((V _arrowThis3823, int _argc3816, V i_3822, V _a3819, V _a3820, V _a3821, V[] _rest3817) => {
return ((V)(JsStrBuf.Begin().S("<rect x=\"-2.8\" y=\"-2.8\" width=\"5.6\" height=\"5.6\" rx=\"0.9\" fill=\"").V(GetK(BLC_131, i_3822)).S("\" stroke=\"").V(Call(shade_42, V.Undef, GetK(BLC_131, i_3822), ((V)(0.7)))).S("\" stroke-width=\"0.4\"/><path d=\"M-2.2-2.2H2.2\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.5\" stroke-linecap=\"round\"/><text x=\"0\" y=\"1.6\" text-anchor=\"middle\" font-family=\"Fredoka,sans-serif\" font-weight=\"700\" font-size=\"4.3\" fill=\"#ffffff\" stroke=\"").V(Call(shade_42, V.Undef, GetK(BLC_131, i_3822), ((V)(0.6)))).S("\" stroke-width=\"0.45\" paint-order=\"stroke\">").V(GetK(BLL_132, i_3822)).S("</text>").End()));
}, 1, "", true);
BLB_134 = NewObj(5).Put("stack", Fn((V _self3824, int _argc3825, V t_3831, V X_3832, V rec_3833, V _a3830, V[] _rest3826) => {
double n_3834 = 0;
double top_3835 = 0;
if (_self3824.IsNullish) _self3824 = GlobalV;
n_3834 = (ToNum(Set(rec_3833, "n", Add((Get(rec_3833, "n") is var _t3836 && Truthy(_t3836) ? _t3836 : ((V)(0D))), ((V)(1D))))) - 1D);
top_3835 = (4D + (n_3834 * 8.1));
Invoke(t_3831, "to", ((V)(320D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-6D))), ((V)(8D))), NewObj(4).Put("armR", ((V)(22D))).Put("lean", ((V)(0.5))).Put("lx", ((V)(0.6))).Put("ly", ((V)(0.8))).V), ((V)("io")));
Invoke(Set(rec_3833, "pick", (Get(rec_3833, "pick") is var _t3837 && Truthy(_t3837) ? _t3837 : Arr())), "push", Get(t_3831, "t"));
Invoke(Invoke(t_3831, "to", ((V)(420D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-14D))), ((V)((-top_3835)))), NewObj(3).Put("armR", Call(cl_39, V.Undef, ((V)((34D + (n_3834 * 19D)))), ((V)(34D)), ((V)(118D)))).Put("lean", ((V)(0D))).Put("ly", ((V)(((-0.2) - (n_3834 * 0.12))))).V), ((V)("io"))), "osc", ((V)(300D)), ((V)(2D)), NewObj(1).Put("hRy", ((V)(((-top_3835) - 0.6)))).V, NewObj(1).Put("hRy", ((V)((-top_3835)))).V, ((V)("l")));
Invoke(Set(rec_3833, "place", (Get(rec_3833, "place") is var _t3838 && Truthy(_t3838) ? _t3838 : Arr())), "push", Get(t_3831, "t"));
Invoke(t_3831, "to", ((V)(200D)), NewObj(2).Put("sqz", ((V)(0.4))).Put("smile", ((V)(1D))).V, ((V)("o")));
return Invoke(t_3831, "back", ((V)(380D)));
return default;
}, 3, "stack", false)).Put("wobble", Fn((V _self3839, int _argc3840, V t_3846, V X_3847, V rec_3848, V _a3845, V[] _rest3841) => {
if (_self3839.IsNullish) _self3839 = GlobalV;
Invoke(Set(rec_3848, "wob", (Get(rec_3848, "wob") is var _t3849 && Truthy(_t3849) ? _t3849 : Arr())), "push", Get(t_3846, "t"));
Invoke(Invoke(Invoke(Invoke(Invoke(t_3846, "to", ((V)(200D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(10D)), ((V)((-9D)))), NewObj(6).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.45))).Put("mw", ((V)(0.5))).Put("lean", ((V)((-0.8)))).V), ((V)("o"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("tilt", ((V)(2D))).V, NewObj(1).Put("tilt", ((V)((-2D)))).V, ((V)("s"))), "fx", ((V)("sweat")), ((V)("head"))), "to", ((V)(400D)), NewObj(3).Put("wide", ((V)(0.3))).Put("open", ((V)(0.1))).Put("tilt", ((V)(0D))).V), "to", ((V)(200D)), NewObj(3).Put("sqz", ((V)(0.5))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)("o")));
return Invoke(t_3846, "back", ((V)(380D)));
return default;
}, 3, "wobble", false)).Put("topple", Fn((V _self3850, int _argc3851, V t_3857, V X_3858, V rec_3859, V _a3856, V[] _rest3852) => {
V B_3860 = default;
if (_self3850.IsNullish) _self3850 = GlobalV;
B_3860 = Get(t_3857, "B");
Invoke(Set(rec_3859, "top", (Get(rec_3859, "top") is var _t3861 && Truthy(_t3861) ? _t3861 : Arr())), "push", Get(t_3857, "t"));
Invoke(Invoke(Invoke(t_3857, "wait", ((V)(250D))), "to", ((V)(220D)), Call(o_10, V.Undef, Call(both_13, V.Undef, ((V)(10D)), ((V)((-13D)))), NewObj(6).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.5))).Put("pitch", Add(Get(B_3860, "pitch"), ((V)(0.1)))).V), ((V)("o"))), "wait", ((V)(700D)));
return Invoke(t_3857, "back", ((V)(400D)));
return default;
}, 3, "topple", false)).Put("giggle", Fn((V _self3862, int _argc3863, V t_3869, V _a3866, V _a3867, V _a3868, V[] _rest3864) => {
if (_self3862.IsNullish) _self3862 = GlobalV;
Invoke(BEAT_16, "giggle", t_3869, ((V)((-1D))));
return t_3869;
return default;
}, 1, "giggle", false)).Put("tidy", Fn((V _self3870, int _argc3871, V t_3877, V X_3878, V rec_3879, V _a3876, V[] _rest3872) => {
V B_3880 = default;
if (_self3870.IsNullish) _self3870 = GlobalV;
B_3880 = Get(t_3877, "B");
Invoke(Set(rec_3879, "tidy", (Get(rec_3879, "tidy") is var _t3881 && Truthy(_t3881) ? _t3881 : Arr())), "push", Get(t_3877, "t"));
Invoke(Invoke(t_3877, "to", ((V)(300D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)((-12D))), ((V)(8D))), NewObj(4).Put("armR", ((V)(22D))).Put("lean", ((V)(0.6))).Put("lx", ((V)(0.8))).Put("ly", ((V)(0.7))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("hRx", Add(Get(B_3880, "hRx"), ((V)(4D)))).V, NewObj(1).Put("hRx", ((V)((ToNum(Get(B_3880, "hRx")) - 1D)))).V, ((V)("s")));
Set(rec_3879, "tidyE", Get(t_3877, "t"));
Invoke(t_3877, "to", ((V)(200D)), NewObj(2).Put("smile", ((V)(1D))).Put("hap", ((V)(0.5))).V);
return Invoke(t_3877, "back", ((V)(380D)));
return default;
}, 3, "tidy", false)).V;
CAN_136 = ((V)("<path d=\"M-1.2 0H6.8L6.2 6.4Q2.8 7.4-0.6 6.4Z\" fill=\"#7cc35a\" stroke=\"#4f8f3a\" stroke-width=\"0.45\"/><path d=\"M0 0Q2.8-3.6 5.6 0\" stroke=\"#4f8f3a\" stroke-width=\"0.7\" fill=\"none\"/><path d=\"M6.6 2.2L11.6-1.2L12.2-0.2L7 3.6Z\" fill=\"#7cc35a\" stroke=\"#4f8f3a\" stroke-width=\"0.4\"/><ellipse cx=\"12.1\" cy=\"-0.9\" rx=\"0.9\" ry=\"1.4\" transform=\"rotate(-35 12.1 -0.9)\" fill=\"#a8d88a\" stroke=\"#4f8f3a\" stroke-width=\"0.35\"/><path d=\"M0.4 1.4H5.8\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.4\"/>"));
RSB_138 = NewObj(6).Put("hold", Fn((V _self3882, int _argc3883, V t_3889, V _a3886, V _a3887, V _a3888, V[] _rest3884) => {
V B_3890 = default;
if (_self3882.IsNullish) _self3882 = GlobalV;
B_3890 = Get(t_3889, "B");
Invoke(Invoke(t_3889, "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0.8))).Put("ly", ((V)(0.2))).Put("wide", ((V)(0.3))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "osc", ((V)(1800D)), ((V)(3D)), NewObj(2).Put("hRy", ((V)((ToNum(Get(B_3890, "hRy")) - 0.8)))).Put("htilt", ((V)(2D))).V, NewObj(2).Put("hRy", Add(Get(B_3890, "hRy"), ((V)(0.4)))).Put("htilt", ((V)((-2D)))).V, ((V)("s")));
return Invoke(t_3889, "back", ((V)(300D)));
return default;
}, 1, "hold", false)).Put("turn", Fn((V _self3891, int _argc3892, V t_3898, V _a3895, V _a3896, V _a3897, V[] _rest3893) => {
V B_3899 = default;
if (_self3891.IsNullish) _self3891 = GlobalV;
B_3899 = Get(t_3898, "B");
Invoke(Invoke(t_3898, "to", ((V)(200D)), NewObj(2).Put("sqz", ((V)(0.3))).Put("smile", ((V)(1D))).V), "osc", ((V)(1400D)), ((V)(4D)), NewObj(2).Put("hRx", ((V)((ToNum(Get(B_3899, "hRx")) - 1.2)))).Put("tilt", ((V)(1D))).V, NewObj(2).Put("hRx", Add(Get(B_3899, "hRx"), ((V)(0.6)))).Put("tilt", ((V)((-1D)))).V, ((V)("s")));
return Invoke(t_3898, "back", ((V)(300D)));
return default;
}, 1, "turn", false)).Put("fire", Fn((V _self3900, int _argc3901, V t_3907, V _a3904, V _a3905, V _a3906, V[] _rest3902) => {
V B_3908 = default;
if (_self3900.IsNullish) _self3900 = GlobalV;
B_3908 = Get(t_3907, "B");
Invoke(Invoke(Invoke(Invoke(t_3907, "to", ((V)(160D)), NewObj(7).Put("armR", ((V)(74D))).Put("hRy", ((V)((ToNum(Get(B_3908, "hRy")) - 5D)))).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.5))).Put("lean", ((V)((-0.8)))).Put("sq", ((V)((ToNum(Get(B_3908, "sq")) - 0.04)))).V, ((V)("o"))), "osc", ((V)(600D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(100D)), NewObj(1).Put("x", ((V)(0D))).V), "wait", ((V)(200D)));
return t_3907;
return default;
}, 1, "fire", false)).Put("blow", Fn((V _self3909, int _argc3910, V t_3916, V _a3913, V _a3914, V _a3915, V[] _rest3911) => {
if (_self3909.IsNullish) _self3909 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3916, "to", ((V)(260D)), NewObj(3).Put("puff", ((V)(0.9))).Put("open", ((V)(0D))).Put("lx", ((V)(0.8))).V), "to", ((V)(160D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.45))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth"))), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0.8))).Put("open", ((V)(0D))).V), "to", ((V)(160D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth"))), "wait", ((V)(300D))), "to", ((V)(240D)), NewObj(5).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.2))).Put("wide", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("sweat")), ((V)("head"))), "wait", ((V)(300D)));
return Invoke(t_3916, "back", ((V)(420D)));
return default;
}, 1, "blow", false)).Put("eat", Fn((V _self3917, int _argc3918, V t_3924, V X_3925, V _a3922, V _a3923, V[] _rest3919) => {
V B_3926 = default;
if (_self3917.IsNullish) _self3917 = GlobalV;
B_3926 = Get(t_3924, "B");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_3924, "to", ((V)(420D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-13D)))), NewObj(5).Put("armR", ((V)(36D))).Put("pitch", Add((Get(B_3926, "pitch") is var _t3927 && Truthy(_t3927) ? _t3927 : ((V)(0D))), ((V)(0.02)))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("open", ((V)(0.4))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.6))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(5D)), NewObj(2).Put("puff", ((V)(0.6))).Put("open", ((V)(0.1))).V, NewObj(2).Put("puff", ((V)(0.2))).Put("open", ((V)(0D))).V, ((V)("l"))), "to", ((V)(260D)), Call(o_10, V.Undef, NewObj(4).Put("smile", ((V)(1D))).Put("hap", ((V)(1D))).Put("sqz", ((V)(0.7))).Put("puff", ((V)(0D))).V, Get(X_3925, "cheer")), ((V)("o"))), "fx", ((V)("heart")), ((V)("head"))), "wait", ((V)(300D)));
return Invoke(t_3924, "back", ((V)(420D)));
return default;
}, 2, "eat", false)).Put("new", Fn((V _self3928, int _argc3929, V t_3935, V _a3932, V _a3933, V _a3934, V[] _rest3930) => {
if (_self3928.IsNullish) _self3928 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_3935, "to", ((V)(360D)), Call(o_10, V.Undef, Call(hand_12, V.Undef, ((V)((-1D))), ((V)((-10D))), ((V)((-3D)))), NewObj(2).Put("armL", ((V)(54D))).Put("lx", ((V)(0.6))).V), ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(160D)), NewObj(1).Put("sqz", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("sqz", ((V)(0D))).V);
return Invoke(t_3935, "back", ((V)(380D)));
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
Invoke(Get(G("window"), "HouseCreatures"), "forEach", Fn((V _arrowThis3943, int _argc3936, V f_3942, V _a3939, V _a3940, V _a3941, V[] _rest3937) => {
return Call(f_3942, V.Undef, Get(R_8, "HOUSE"));
}, 1, "", true));
}
Set(G("window"), "HouseCreatures", NewObj(1).Put("push", Fn((V _arrowThis3951, int _argc3944, V f_3950, V _a3947, V _a3948, V _a3949, V[] _rest3945) => {
return Call(f_3950, V.Undef, Get(R_8, "HOUSE"));
}, 1, "push", true)).V);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
