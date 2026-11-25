// whip-spin.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_whip_spin_js
    {

        public static void Run()
        {
Call(Named(boot_277 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V R_8 = default;
V STATES_9 = default;
V REST_10 = default;
V kv_11 = default;
V PLAN_12 = default;
V rv_13 = default;
V S_14 = default;
V hand_15 = default;
V o_16 = default;
V TL_17 = default;
V whip_18 = default;
V NEUTRAL_19 = default;
V HOLD_20 = default;
V windows_21 = default;
V dirsFor_22 = default;
V splice_23 = default;
V convert_24 = default;
if (_self1.IsNullish) _self1 = GlobalV;
TL_17 = Fn((V _self25, int _argc26, V _a28, V _a29, V _a30, V _a31, V[] _rest27) => {
V k_32 = default;
V t_33 = default;
V q_34 = default;
if (_self25.IsNullish) _self25 = GlobalV;
k_32 = NewObj(0).V;
t_33 = ((V)(0D));
q_34 = NewObj(3).Getter("t", Fn((V _self35, int _argc36, V _a38, V _a39, V _a40, V _a41, V[] _rest37) => {
if (_self35.IsNullish) _self35 = GlobalV;
return t_33;
return default;
}, 0, "t", false)).Put("k", k_32).Put("to", Fn((V _self42, int _argc43, V dt_49, V v_50, V ez_51, V _a48, V[] _rest44) => {
if (_self42.IsNullish) _self42 = GlobalV;
{
foreach (V _k52 in ForInKeys(v_50)) {
V p_53 = default;
p_53 = _k52;
V L_54 = default;
L_54 = (GetK(k_32, p_53) is var _t55 && Truthy(_t55) ? _t55 : SetK(k_32, p_53, Arr(Arr(((V)(0D)), Call(rv_13, V.Undef, p_53)))));
if (Lt(GetIdx(GetIdx(L_54, (ToNum(Get(L_54, "length")) - 1D)), 0D), t_33)) {
Invoke(L_54, "push", Arr(t_33, GetIdx(GetIdx(L_54, (ToNum(Get(L_54, "length")) - 1D)), 1D), ((V)("l"))));
}
}
}
t_33 = Add(t_33, dt_49);
{
foreach (V _k56 in ForInKeys(v_50)) {
V p_57 = default;
p_57 = _k56;
Invoke(GetK(k_32, p_57), "push", Arr(t_33, GetK(v_50, p_57), (ez_51 is var _t58 && Truthy(_t58) ? _t58 : ((V)("io")))));
}
}
return q_34;
return default;
}, 3, "to", false)).V;
return q_34;
return default;
}, 0, "TL", false);
whip_18 = Fn((V _self59, int _argc60, V t_66, V d_67, V _a64, V _a65, V[] _rest61) => {
double ld_68 = 0;
V A_69 = default;
V B_70 = default;
V FT_71 = default;
if (_self59.IsNullish) _self59 = GlobalV;
ld_68 = (GtN(d_67, 0D) ? 1D : (-1D));
A_69 = Get(Call(S_14, V.Undef, ((V)(ld_68))), "arm");
B_70 = Get(Call(S_14, V.Undef, ((V)((-ld_68)))), "arm");
FT_71 = Get(Call(S_14, V.Undef, ((V)(ld_68))), "foot");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_66, "to", ((V)(75D)), NewObj(9).Put("lx", ((V)((0.9 * ToNum(d_67))))).Put("htilt", ((V)((3D * ToNum(d_67))))).Put("sq", ((V)((-0.03)))).PutK(A_69, ((V)(6D))).PutK(B_70, ((V)(6D))).Put("earL", ((V)((-3D)))).Put("earR", ((V)((-3D)))).Put("hap", ((V)(0.2))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(155D)), Call(o_16, V.Undef, NewObj(15).Put("sq", ((V)(0.14))).Put("spin", ((V)(((-32D) * ToNum(d_67))))).Put("turn", ((V)(((-0.12) * ToNum(d_67))))).Put("hyaw", ((V)((0.55 * ToNum(d_67))))).Put("tilt", ((V)(((-3D) * ToNum(d_67))))).Put("lean", ((V)(((-1D) * ToNum(d_67))))).Put("htilt", ((V)((7D * ToNum(d_67))))).Put("lx", d_67).PutK(B_70, ((V)(70D))).PutK(A_69, ((V)((-6D)))).Put("close", ((V)(0.2))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).Put("wag", ((V)((14D * ToNum(d_67))))).Put("hap", ((V)(0.35))).V, Call(hand_15, V.Undef, ((V)(ld_68)), ((V)(7D)), ((V)((-2D))), ((V)(5D)))), ((V)("o"))), "to", ((V)(100D)), NewObj(4).Put("sq", ((V)(0.16))).Put("spin", ((V)(((-36D) * ToNum(d_67))))).Put("htilt", ((V)((8D * ToNum(d_67))))).PutK(B_70, ((V)(76D))).V, ((V)("io"))), "to", ((V)(50D)), Call(o_16, V.Undef, NewObj(15).Put("spin", ((V)((40D * ToNum(d_67))))).Put("sblur", ((V)(0.5))).Put("sq", ((V)((-0.1)))).Put("turn", ((V)(0D))).Put("hyaw", ((V)((0.35 * ToNum(d_67))))).Put("tilt", ((V)((4D * ToNum(d_67))))).Put("lean", ((V)((0.6 * ToNum(d_67))))).Put("htilt", ((V)((10D * ToNum(d_67))))).Put("lx", ((V)((0.6 * ToNum(d_67))))).PutK(B_70, ((V)(125D))).PutK(A_69, ((V)(30D))).Put("close", ((V)(0D))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).PutK(FT_71, ((V)(8D))).V, Call(hand_15, V.Undef, ((V)(ld_68)), ((V)(0D)), ((V)(2D)), ((V)(3D))), Call(hand_15, V.Undef, ((V)((-ld_68))), ((V)(0D)), ((V)((-4D))), ((V)(3D)))), ((V)("l"))), "to", ((V)(180D)), NewObj(7).Put("spin", ((V)((378D * ToNum(d_67))))).Put("sq", ((V)((-0.12)))).PutK(B_70, ((V)(128D))).PutK(A_69, ((V)(32D))).Put("earL", ((V)((-12D)))).Put("earR", ((V)((-12D)))).PutK(FT_71, ((V)(9D))).V, ((V)("l"))), "to", ((V)(200D)), Call(o_16, V.Undef, NewObj(17).Put("spin", ((V)((360D * ToNum(d_67))))).Put("sblur", ((V)(0D))).Put("sq", ((V)(0.12))).PutK(FT_71, ((V)(0D))).Put("hyaw", ((V)(((-0.12) * ToNum(d_67))))).Put("tilt", ((V)(((-2D) * ToNum(d_67))))).Put("lean", ((V)(0D))).Put("htilt", ((V)(((-3D) * ToNum(d_67))))).Put("lx", ((V)(0D))).PutK(A_69, ((V)(115D))).PutK(B_70, ((V)(40D))).Put("earL", ((V)(12D))).Put("earR", ((V)(12D))).Put("wag", ((V)(((-18D) * ToNum(d_67))))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, Call(hand_15, V.Undef, ((V)(ld_68)), ((V)(0D)), ((V)(0D)), ((V)(0D))), Call(hand_15, V.Undef, ((V)((-ld_68))), ((V)(0D)), ((V)(0D)), ((V)(0D)))), ((V)("o"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
return t_66;
return default;
}, 2, "whip", false);
windows_21 = Fn((V _self72, int _argc73, V K_79, V _a76, V _a77, V _a78, V[] _rest74) => {
V W_80 = default;
V cur_81 = default;
if (_self72.IsNullish) _self72 = GlobalV;
if ((!(Truthy(K_79)) || LtN(Get(K_79, "length"), 2D))) {
return Arr();
}
W_80 = Arr();
cur_81 = V.Null;
{
double i_82 = 0;
i_82 = 1D;
while (true) {
if (!(Lt(((V)(i_82)), Get(K_79, "length")))) break;
V a_84 = default;
V b_85 = default;
double dv_86 = 0;
double dt_87 = 0;
a_84 = GetIdx(K_79, (i_82 - 1D));
b_85 = GetIdx(K_79, i_82);
dv_86 = (ToNum(GetIdx(b_85, 1D)) - ToNum(GetIdx(a_84, 1D)));
dt_87 = (ToNum(GetIdx(b_85, 0D)) - ToNum(GetIdx(a_84, 0D)));
if (((dt_87 <= 2D) && (System.Math.Abs(dv_86) >= 90D))) {
goto _cont83;
}
if ((System.Math.Abs(dv_86) < 0.01)) {
if (Truthy((cur_81 is var _t88 && !Truthy(_t88) ? _t88 : (((ToNum(GetIdx(a_84, 0D)) - ToNum(Get(cur_81, "t1"))) > 0D) ? V.True : V.False)))) {
Invoke(W_80, "push", cur_81);
cur_81 = V.Null;
}
goto _cont83;
}
if (Truthy((cur_81 is var _t89 && !Truthy(_t89) ? _t89 : (((ToNum(GetIdx(a_84, 0D)) - ToNum(Get(cur_81, "t1"))) <= 60D) ? V.True : V.False)))) {
Set(cur_81, "t1", GetIdx(b_85, 0D));
OpSet(cur_81, "net", 0, ((V)(dv_86)));
} else {
if (Truthy(cur_81)) {
Invoke(W_80, "push", cur_81);
}
cur_81 = NewObj(3).Put("t0", GetIdx(a_84, 0D)).Put("t1", GetIdx(b_85, 0D)).Put("net", ((V)(dv_86))).V;
}
_cont83: ;
i_82++;
}
}
if (Truthy(cur_81)) {
Invoke(W_80, "push", cur_81);
}
return Invoke(W_80, "filter", Fn((V _arrowThis97, int _argc90, V w_96, V _a93, V _a94, V _a95, V[] _rest91) => {
return (((System.Math.Abs(ToNum(Get(w_96, "net"))) >= 300D) && ((ToNum(Get(w_96, "t1")) - ToNum(Get(w_96, "t0"))) <= 3000D)) ? V.True : V.False);
}, 1, "", true));
return default;
}, 1, "windows", false);
dirsFor_22 = Fn((V _self98, int _argc99, V mode_105, V i_106, V _a103, V _a104, V[] _rest100) => {
if (_self98.IsNullish) _self98 = GlobalV;
if (SEqN(mode_105, 2D)) {
return (SEqN(i_106, 0D) ? Arr(((V)(1D)), ((V)((-1D)))) : Arr(((V)((NumTruthy((ToNum(i_106) % 2D)) ? (-1D) : 1D)))));
}
return Arr(((V)((LtN(mode_105, 0D) ? (-1D) : 1D))));
return default;
}, 2, "dirsFor", false);
splice_23 = Fn((V _self107, int _argc108, V st_114, V w_115, V dirs_116, V _a113, V[] _rest109) => {
V t0_117 = default;
V t1_118 = default;
V L_119 = default;
V sv_120 = default;
V tl_121 = default;
V Wc_122 = default;
V Wk_123 = default;
V Wt_124 = default;
double dl_125 = 0;
V M_126 = default;
V k_127 = default;
V chans_128 = default;
V @out_129 = default;
if (_self107.IsNullish) _self107 = GlobalV;
{ V _t130 = w_115;
if (_t130.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t130));
{ V _t131 = Get(_t130, "t0");
t0_117 = _t131; }
{ V _t132 = Get(_t130, "t1");
t1_118 = _t132; } }
L_119 = (Get(st_114, "loop") is var _t133 && Truthy(_t133) ? _t133 : Get(st_114, "dur"));
sv_120 = Fn((V _arrowThis142, int _argc134, V c_140, V t_141, V _a138, V _a139, V[] _rest135) => {
return (Truthy(GetK(Get(st_114, "k"), c_140)) ? Call(kv_11, V.Undef, GetK(Get(st_114, "k"), c_140), t_141) : Call(rv_13, V.Undef, c_140));
}, 2, "", true);
tl_121 = Call(TL_17, V.Undef);
Invoke(dirs_116, "forEach", Fn((V _arrowThis150, int _argc143, V d_149, V _a146, V _a147, V _a148, V[] _rest144) => {
return Call(whip_18, V.Undef, tl_121, d_149);
}, 1, "", true));
Wc_122 = Get(tl_121, "t");
Wk_123 = Get(tl_121, "k");
Wt_124 = Add(Wc_122, ((V)(300D)));
{
double dl_151 = 0;
dl_151 = (ToNum(Wt_124) - (ToNum(t1_118) - ToNum(t0_117)));
Wt_124 = Add(Wt_124, ((V)(((System.Math.Ceiling((dl_151 / 250D)) * 250D) - dl_151))));
}
dl_125 = (ToNum(Wt_124) - (ToNum(t1_118) - ToNum(t0_117)));
M_126 = Fn((V _arrowThis159, int _argc152, V t_158, V _a155, V _a156, V _a157, V[] _rest153) => {
return (Lt(t_158, t0_117) ? t_158 : (Le(t_158, t1_118) ? Add(t0_117, ((V)((((ToNum(t_158) - ToNum(t0_117)) * ToNum(Wt_124)) / Max(1D, (ToNum(t1_118) - ToNum(t0_117))))))) : Add(t_158, ((V)(dl_125)))));
}, 1, "", true);
k_127 = NewObj(0).V;
chans_128 = New(G("Set"), new ArrBuilder().Spread(Object_keys(Get(st_114, "k"))).Spread(Object_keys(Wk_123)).Spread(Invoke(Object_keys(NEUTRAL_19), "filter", Fn((V _arrowThis167, int _argc160, V c_166, V _a163, V _a164, V _a165, V[] _rest161) => {
return GetK(Get(st_114, "k"), c_166);
}, 1, "", true))).V);
Invoke(chans_128, "forEach", Fn((V _arrowThis175, int _argc168, V c_174, V _a171, V _a172, V _a173, V[] _rest169) => {
V K_176 = default;
K_176 = GetK(Get(st_114, "k"), c_174);
if (Truthy(((GetK(Wk_123, c_174) is var _t177 && Truthy(_t177) ? _t177 : (!GetK(NEUTRAL_19, c_174).IsNullish ? V.True : V.False)) is var _t178 && Truthy(_t178) ? _t178 : GetK(HOLD_20, c_174)))) {
V v0_179 = default;
V v1_180 = default;
V N_181 = default;
v0_179 = Call(sv_120, V.Undef, c_174, t0_117);
v1_180 = Call(sv_120, V.Undef, c_174, t1_118);
N_181 = Arr();
if (Truthy(K_176)) {
Invoke(K_176, "forEach", Fn((V _arrowThis189, int _argc182, V q_188, V _a185, V _a186, V _a187, V[] _rest183) => {
if (Lt(GetIdx(q_188, 0D), t0_117)) {
Invoke(N_181, "push", Invoke(q_188, "slice"));
}
return default;
}, 1, "", true));
} else {
Invoke(N_181, "push", Arr(((V)(0D)), Call(rv_13, V.Undef, c_174)));
}
Invoke(N_181, "push", Arr(t0_117, v0_179, ((V)("l"))));
if (Truthy(GetK(Wk_123, c_174))) {
V off_190 = default;
off_190 = (SEqS(c_174, "spin") ? v0_179 : ((V)(0D)));
Invoke(GetK(Wk_123, c_174), "forEach", Fn((V _arrowThis198, int _argc191, V q_197, V _a194, V _a195, V _a196, V[] _rest192) => {
if (GtN(GetIdx(q_197, 0D), 0D)) {
Invoke(N_181, "push", Arr(Add(t0_117, GetIdx(q_197, 0D)), Add(GetIdx(q_197, 1D), off_190), GetIdx(q_197, 2D)));
}
return default;
}, 1, "", true));
if (SEqS(c_174, "spin")) {
Invoke(N_181, "push", Arr(Add(Add(t0_117, Wc_122), ((V)(1D))), Add(v0_179, ((V)((360D * Round(((ToNum(v1_180) - ToNum(v0_179)) / 360D)))))), ((V)("l"))));
}
} else {
if (!GetK(NEUTRAL_19, c_174).IsNullish) {
Invoke(N_181, "push", Arr(Add(t0_117, ((V)(230D))), GetK(NEUTRAL_19, c_174), ((V)("io"))), Arr(Add(t0_117, Wc_122), GetK(NEUTRAL_19, c_174), ((V)("l"))));
} else {
Invoke(N_181, "push", Arr(Add(t0_117, Wc_122), v0_179, ((V)("l"))));
}
}
Invoke(N_181, "push", Arr(Add(t0_117, Wt_124), v1_180, ((V)("io"))));
if (Truthy(K_176)) {
Invoke(K_176, "forEach", Fn((V _arrowThis206, int _argc199, V q_205, V _a202, V _a203, V _a204, V[] _rest200) => {
if (Gt(GetIdx(q_205, 0D), t1_118)) {
Invoke(N_181, "push", Arr(Add(GetIdx(q_205, 0D), ((V)(dl_125))), GetIdx(q_205, 1D), GetIdx(q_205, 2D)));
}
return default;
}, 1, "", true));
} else {
Invoke(N_181, "push", Arr(Add(L_119, ((V)(dl_125))), Call(rv_13, V.Undef, c_174), ((V)("l"))));
}
SetK(k_127, c_174, N_181);
} else {
SetK(k_127, c_174, Invoke(K_176, "map", Fn((V _arrowThis214, int _argc207, V q_213, V _a210, V _a211, V _a212, V[] _rest208) => {
return Arr(Call(M_126, V.Undef, GetIdx(q_213, 0D)), GetIdx(q_213, 1D), GetIdx(q_213, 2D));
}, 1, "", true)));
}
return default;
}, 1, "", true));
@out_129 = Object_assign(NewObj(0).V, st_114, NewObj(1).Put("k", k_127).V);
if (Truthy(Get(st_114, "loop"))) {
Set(@out_129, "loop", Add(Get(st_114, "loop"), ((V)(dl_125))));
} else {
Set(@out_129, "dur", Add(Get(st_114, "dur"), ((V)(dl_125))));
}
if (Truthy(Get(st_114, "ev"))) {
Set(@out_129, "ev", Invoke(Get(st_114, "ev"), "map", Fn((V _arrowThis222, int _argc215, V e_221, V _a218, V _a219, V _a220, V[] _rest216) => {
return new ArrBuilder().Add(Call(M_126, V.Undef, GetIdx(e_221, 0D))).Spread(Invoke(e_221, "slice", ((V)(1D)))).V;
}, 1, "", true)));
}
if (Truthy(Get(st_114, "emit"))) {
Set(@out_129, "emit", Invoke(Get(st_114, "emit"), "map", Fn((V _arrowThis230, int _argc223, V e_229, V _a226, V _a227, V _a228, V[] _rest224) => {
return new ArrBuilder().Add(Call(M_126, V.Undef, GetIdx(e_229, 0D))).Add((GeN(GetIdx(e_229, 1D), 100000000D) ? GetIdx(e_229, 1D) : Call(M_126, V.Undef, GetIdx(e_229, 1D)))).Spread(Invoke(e_229, "slice", ((V)(2D)))).V;
}, 1, "", true)));
}
if (Truthy(Get(st_114, "fx"))) {
V f_231 = default;
V Mi_232 = default;
f_231 = Get(st_114, "fx");
Mi_232 = Fn((V _arrowThis240, int _argc233, V t_239, V _a236, V _a237, V _a238, V[] _rest234) => {
return (Lt(t_239, t0_117) ? t_239 : (Le(t_239, Add(t0_117, Wt_124)) ? Add(t0_117, ((V)((((ToNum(t_239) - ToNum(t0_117)) * (ToNum(t1_118) - ToNum(t0_117))) / ToNum(Wt_124))))) : ((V)((ToNum(t_239) - dl_125)))));
}, 1, "", true);
Set(@out_129, "fx", Fn((V _arrowThis249, int _argc241, V I_247, V tt_248, V _a245, V _a246, V[] _rest242) => {
return Call(f_231, V.Undef, I_247, Call(Mi_232, V.Undef, tt_248));
}, 2, "", true));
}
return @out_129;
return default;
}, 3, "splice", false);
convert_24 = Fn((V _self250, int _argc251, V st_257, V key_258, V _a255, V _a256, V[] _rest252) => {
V mode_259 = default;
V W_260 = default;
V @out_261 = default;
if (_self250.IsNullish) _self250 = GlobalV;
if (Truthy(((((!(Truthy(st_257)) ? V.True : V.False) is var _t262 && Truthy(_t262) ? _t262 : Get(st_257, "__whip")) is var _t263 && Truthy(_t263) ? _t263 : (!(Truthy(Get(st_257, "k"))) ? V.True : V.False)) is var _t265 && Truthy(_t265) ? _t265 : (!(Truthy((Get(st_257, "loop") is var _t264 && Truthy(_t264) ? _t264 : Get(st_257, "dur")))) ? V.True : V.False)))) {
return st_257;
}
mode_259 = GetK(PLAN_12, key_258);
if (!(Truthy(mode_259))) {
return st_257;
}
W_260 = Call(windows_21, V.Undef, Get(Get(st_257, "k"), "spin"));
if (!(Truthy(Get(W_260, "length")))) {
return st_257;
}
@out_261 = st_257;
{
double i_266 = 0;
i_266 = (ToNum(Get(W_260, "length")) - 1D);
while (true) {
if (!((i_266 >= 0D))) break;
@out_261 = Call(splice_23, V.Undef, @out_261, GetIdx(W_260, i_266), Call(dirsFor_22, V.Undef, mode_259, ((V)(i_266))));
i_266--;
}
}
Set(@out_261, "__whip", Get(W_260, "length"));
Set(@out_261, "whip", ((V)(1D)));
Set(@out_261, "whipDirs", Invoke(W_260, "map", Fn((V _arrowThis276, int _argc268, V __274, V i_275, V _a272, V _a273, V[] _rest269) => {
return Call(dirsFor_22, V.Undef, mode_259, i_275);
}, 2, "", true)));
return @out_261;
return default;
}, 2, "convert", false);
R_8 = Get(G("window"), "RiveRig");
if (((((!(Truthy(R_8)) || !(Truthy(Get(R_8, "STATES")))) || !(Truthy(Get(Get(R_8, "STATES"), "dance")))) || !(Truthy(Get(R_8, "REST")))) || !(Truthy(Get(R_8, "kv"))))) {
Call(G("setTimeout"), V.Undef, boot_277.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_8, "whipV"))) {
return default;
}
Set(R_8, "whipV", ((V)(1D)));
STATES_9 = Get(R_8, "STATES");
REST_10 = Get(R_8, "REST");
kv_11 = Get(R_8, "kv");
PLAN_12 = NewObj(45).Put("bean", ((V)(1D))).Put("clover", ((V)((-1D)))).Put("duchess", ((V)(2D))).Put("mimi", ((V)(2D))).Put("mittens", ((V)(1D))).Put("nibbles", ((V)(1D))).Put("pico", ((V)(2D))).Put("poppy", ((V)(2D))).Put("puddles", ((V)(1D))).Put("quill", ((V)((-1D)))).Put("ribbit", ((V)(2D))).Put("tilly", ((V)((-1D)))).Put("waffles", ((V)((-1D)))).Put("zippy", ((V)(2D))).Put("boba", ((V)(1D))).Put("bunbun", ((V)(2D))).Put("chefbun", ((V)(2D))).Put("choco", ((V)(1D))).Put("churro", ((V)(2D))).Put("corny", ((V)(1D))).Put("dunkie", ((V)(1D))).Put("flossie", ((V)((-1D)))).Put("frankie", ((V)(2D))).Put("khinki", ((V)((-1D)))).Put("maki", ((V)(2D))).Put("mallow", ((V)((-1D)))).Put("noodle", ((V)(1D))).Put("nori", ((V)((-1D)))).Put("peppi", ((V)(2D))).Put("scoop", ((V)(2D))).Put("toco", ((V)((-1D)))).Put("appy", ((V)(2D))).Put("avo", ((V)(2D))).Put("berri", ((V)(2D))).Put("bing", ((V)(2D))).Put("clemmy", ((V)(1D))).Put("grana", ((V)(2D))).Put("lemmy", ((V)(1D))).Put("mangie", ((V)((-1D)))).Put("nana", ((V)((-1D)))).Put("perry", ((V)(1D))).Put("pitaya", ((V)(1D))).Put("plummy", ((V)(2D))).Put("razzy", ((V)((-1D)))).Put("tutti", ((V)((-1D)))).V;
Set(R_8, "WHIP_PLAN", PLAN_12);
rv_13 = Fn((V _arrowThis285, int _argc278, V c_284, V _a281, V _a282, V _a283, V[] _rest279) => {
return (!GetK(REST_10, c_284).IsNullish ? GetK(REST_10, c_284) : ((V)(0D)));
}, 1, "", true);
S_14 = Fn((V _arrowThis293, int _argc286, V s_292, V _a289, V _a290, V _a291, V[] _rest287) => {
return (LtN(s_292, 0D) ? NewObj(5).Put("arm", ((V)("armL"))).Put("hx", ((V)("hLx"))).Put("hy", ((V)("hLy"))).Put("hz", ((V)("hLz"))).Put("foot", ((V)("footL"))).V : NewObj(5).Put("arm", ((V)("armR"))).Put("hx", ((V)("hRx"))).Put("hy", ((V)("hRy"))).Put("hz", ((V)("hRz"))).Put("foot", ((V)("footR"))).V);
}, 1, "", true);
hand_15 = Fn((V _arrowThis304, int _argc294, V s_300, V inX_301, V y_302, V z_303, V[] _rest295) => {
V k_305 = default;
k_305 = Call(S_14, V.Undef, s_300);
return NewObj(3).PutK(Get(k_305, "hx"), (LtN(s_300, 0D) ? inX_301 : ((V)((-ToNum(inX_301)))))).PutK(Get(k_305, "hy"), y_302).PutK(Get(k_305, "hz"), z_303).V;
return default;
}, 4, "", true);
o_16 = Fn((V _arrowThis313, int _argc306, V _a308, V _a309, V _a310, V _a311, V[] _rest307) => {
V a_312 = default;
a_312 = RestArgs(0, _argc306, _a308, _a309, _a310, _a311, _rest307);
return InvokeSpread(G("Object"), "assign", new ArrBuilder().Add(NewObj(0).V).Spread(a_312).V);
}, 1, "", true);
NEUTRAL_19 = NewObj(15).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).Put("bend", ((V)(0D))).Put("twist", ((V)(0D))).Put("ly", ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).Put("wide", ((V)(0D))).Put("frown", ((V)(0D))).Put("tongue", ((V)(0D))).Put("puff", ((V)(0D))).Put("sit", ((V)(0D))).Put("split", ((V)(0D))).Put("ume", ((V)(0D))).Put("flop", ((V)(0D))).V;
HOLD_20 = NewObj(1).Put("x", ((V)(1D))).V;
Set(R_8, "whipConvert", convert_24);
Invoke(Object_keys(PLAN_12), "forEach", Fn((V _arrowThis321, int _argc314, V key_320, V _a317, V _a318, V _a319, V[] _rest315) => {
V nm_322 = default;
V val_323 = default;
V D_324 = default;
nm_322 = ((V)(JsStrBuf.Begin().S("dance@").V(key_320).End()));
val_323 = (Call(convert_24, V.Undef, (GetK(STATES_9, nm_322) is var _t325 && Truthy(_t325) ? _t325 : (SEqS(key_320, "mittens") ? Get(STATES_9, "dance") : V.Null)), key_320) is var _t326 && Truthy(_t326) ? _t326 : V.Undef);
D_324 = NewObj(3).Put("configurable", (true ? V.True : V.False)).Put("get", Fn((V _self327, int _argc328, V _a330, V _a331, V _a332, V _a333, V[] _rest329) => {
if (_self327.IsNullish) _self327 = GlobalV;
return val_323;
return default;
}, 0, "get", false)).Put("set", Fn((V _self334, int _argc335, V v_341, V _a338, V _a339, V _a340, V[] _rest336) => {
if (_self334.IsNullish) _self334 = GlobalV;
val_323 = Call(convert_24, V.Undef, v_341, key_320);
if (Truthy(((!(Truthy(Get(D_324, "enumerable"))) ? V.True : V.False) is var _t342 && !Truthy(_t342) ? _t342 : val_323))) {
Set(D_324, "enumerable", (true ? V.True : V.False));
Object_defineProperty(STATES_9, nm_322, D_324);
}
return default;
}, 1, "set", false)).V;
Set(D_324, "enumerable", (!(!(Truthy(val_323))) ? V.True : V.False));
Object_defineProperty(STATES_9, nm_322, D_324);
return default;
}, 1, "", true));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
