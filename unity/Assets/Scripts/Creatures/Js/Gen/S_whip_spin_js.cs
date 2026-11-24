// whip-spin.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_whip_spin_js
    {

        public static void Run()
        {
Call(Named(boot_262 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
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
return Invoke(W_80, "filter", Fn((V _self72, int _argc90, V w_96, V _a93, V _a94, V _a95, V[] _rest91) => {
return (((System.Math.Abs(ToNum(Get(w_96, "net"))) >= 300D) && ((ToNum(Get(w_96, "t1")) - ToNum(Get(w_96, "t0"))) <= 3000D)) ? V.True : V.False);
}, 1, "", true));
return default;
}, 1, "windows", false);
dirsFor_22 = Fn((V _self97, int _argc98, V mode_104, V i_105, V _a102, V _a103, V[] _rest99) => {
if (_self97.IsNullish) _self97 = GlobalV;
if (SEqN(mode_104, 2D)) {
return (SEqN(i_105, 0D) ? Arr(((V)(1D)), ((V)((-1D)))) : Arr(((V)((NumTruthy((ToNum(i_105) % 2D)) ? (-1D) : 1D)))));
}
return Arr(((V)((LtN(mode_104, 0D) ? (-1D) : 1D))));
return default;
}, 2, "dirsFor", false);
splice_23 = Fn((V _self106, int _argc107, V st_113, V w_114, V dirs_115, V _a112, V[] _rest108) => {
V t0_116 = default;
V t1_117 = default;
V L_118 = default;
V sv_119 = default;
V tl_120 = default;
V Wc_121 = default;
V Wk_122 = default;
V Wt_123 = default;
double dl_124 = 0;
V M_125 = default;
V k_126 = default;
V chans_127 = default;
V @out_128 = default;
if (_self106.IsNullish) _self106 = GlobalV;
{ V _t129 = w_114;
if (_t129.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t129));
{ V _t130 = Get(_t129, "t0");
t0_116 = _t130; }
{ V _t131 = Get(_t129, "t1");
t1_117 = _t131; } }
L_118 = (Get(st_113, "loop") is var _t132 && Truthy(_t132) ? _t132 : Get(st_113, "dur"));
sv_119 = Fn((V _self106, int _argc133, V c_139, V t_140, V _a137, V _a138, V[] _rest134) => {
return (Truthy(GetK(Get(st_113, "k"), c_139)) ? Call(kv_11, V.Undef, GetK(Get(st_113, "k"), c_139), t_140) : Call(rv_13, V.Undef, c_139));
}, 2, "", true);
tl_120 = Call(TL_17, V.Undef);
Invoke(dirs_115, "forEach", Fn((V _self106, int _argc141, V d_147, V _a144, V _a145, V _a146, V[] _rest142) => {
return Call(whip_18, V.Undef, tl_120, d_147);
}, 1, "", true));
Wc_121 = Get(tl_120, "t");
Wk_122 = Get(tl_120, "k");
Wt_123 = Add(Wc_121, ((V)(300D)));
{
double dl_148 = 0;
dl_148 = (ToNum(Wt_123) - (ToNum(t1_117) - ToNum(t0_116)));
Wt_123 = Add(Wt_123, ((V)(((System.Math.Ceiling((dl_148 / 250D)) * 250D) - dl_148))));
}
dl_124 = (ToNum(Wt_123) - (ToNum(t1_117) - ToNum(t0_116)));
M_125 = Fn((V _self106, int _argc149, V t_155, V _a152, V _a153, V _a154, V[] _rest150) => {
return (Lt(t_155, t0_116) ? t_155 : (Le(t_155, t1_117) ? Add(t0_116, ((V)((((ToNum(t_155) - ToNum(t0_116)) * ToNum(Wt_123)) / Max(1D, (ToNum(t1_117) - ToNum(t0_116))))))) : Add(t_155, ((V)(dl_124)))));
}, 1, "", true);
k_126 = NewObj(0).V;
chans_127 = New(G("Set"), new ArrBuilder().Spread(Object_keys(Get(st_113, "k"))).Spread(Object_keys(Wk_122)).Spread(Invoke(Object_keys(NEUTRAL_19), "filter", Fn((V _self106, int _argc156, V c_162, V _a159, V _a160, V _a161, V[] _rest157) => {
return GetK(Get(st_113, "k"), c_162);
}, 1, "", true))).V);
Invoke(chans_127, "forEach", Fn((V _self106, int _argc163, V c_169, V _a166, V _a167, V _a168, V[] _rest164) => {
V K_170 = default;
K_170 = GetK(Get(st_113, "k"), c_169);
if (Truthy(((GetK(Wk_122, c_169) is var _t171 && Truthy(_t171) ? _t171 : (!GetK(NEUTRAL_19, c_169).IsNullish ? V.True : V.False)) is var _t172 && Truthy(_t172) ? _t172 : GetK(HOLD_20, c_169)))) {
V v0_173 = default;
V v1_174 = default;
V N_175 = default;
v0_173 = Call(sv_119, V.Undef, c_169, t0_116);
v1_174 = Call(sv_119, V.Undef, c_169, t1_117);
N_175 = Arr();
if (Truthy(K_170)) {
Invoke(K_170, "forEach", Fn((V _self106, int _argc176, V q_182, V _a179, V _a180, V _a181, V[] _rest177) => {
if (Lt(GetIdx(q_182, 0D), t0_116)) {
Invoke(N_175, "push", Invoke(q_182, "slice"));
}
return default;
}, 1, "", true));
} else {
Invoke(N_175, "push", Arr(((V)(0D)), Call(rv_13, V.Undef, c_169)));
}
Invoke(N_175, "push", Arr(t0_116, v0_173, ((V)("l"))));
if (Truthy(GetK(Wk_122, c_169))) {
V off_183 = default;
off_183 = (SEqS(c_169, "spin") ? v0_173 : ((V)(0D)));
Invoke(GetK(Wk_122, c_169), "forEach", Fn((V _self106, int _argc184, V q_190, V _a187, V _a188, V _a189, V[] _rest185) => {
if (GtN(GetIdx(q_190, 0D), 0D)) {
Invoke(N_175, "push", Arr(Add(t0_116, GetIdx(q_190, 0D)), Add(GetIdx(q_190, 1D), off_183), GetIdx(q_190, 2D)));
}
return default;
}, 1, "", true));
if (SEqS(c_169, "spin")) {
Invoke(N_175, "push", Arr(Add(Add(t0_116, Wc_121), ((V)(1D))), Add(v0_173, ((V)((360D * Round(((ToNum(v1_174) - ToNum(v0_173)) / 360D)))))), ((V)("l"))));
}
} else {
if (!GetK(NEUTRAL_19, c_169).IsNullish) {
Invoke(N_175, "push", Arr(Add(t0_116, ((V)(230D))), GetK(NEUTRAL_19, c_169), ((V)("io"))), Arr(Add(t0_116, Wc_121), GetK(NEUTRAL_19, c_169), ((V)("l"))));
} else {
Invoke(N_175, "push", Arr(Add(t0_116, Wc_121), v0_173, ((V)("l"))));
}
}
Invoke(N_175, "push", Arr(Add(t0_116, Wt_123), v1_174, ((V)("io"))));
if (Truthy(K_170)) {
Invoke(K_170, "forEach", Fn((V _self106, int _argc191, V q_197, V _a194, V _a195, V _a196, V[] _rest192) => {
if (Gt(GetIdx(q_197, 0D), t1_117)) {
Invoke(N_175, "push", Arr(Add(GetIdx(q_197, 0D), ((V)(dl_124))), GetIdx(q_197, 1D), GetIdx(q_197, 2D)));
}
return default;
}, 1, "", true));
} else {
Invoke(N_175, "push", Arr(Add(L_118, ((V)(dl_124))), Call(rv_13, V.Undef, c_169), ((V)("l"))));
}
SetK(k_126, c_169, N_175);
} else {
SetK(k_126, c_169, Invoke(K_170, "map", Fn((V _self106, int _argc198, V q_204, V _a201, V _a202, V _a203, V[] _rest199) => {
return Arr(Call(M_125, V.Undef, GetIdx(q_204, 0D)), GetIdx(q_204, 1D), GetIdx(q_204, 2D));
}, 1, "", true)));
}
return default;
}, 1, "", true));
@out_128 = Object_assign(NewObj(0).V, st_113, NewObj(1).Put("k", k_126).V);
if (Truthy(Get(st_113, "loop"))) {
Set(@out_128, "loop", Add(Get(st_113, "loop"), ((V)(dl_124))));
} else {
Set(@out_128, "dur", Add(Get(st_113, "dur"), ((V)(dl_124))));
}
if (Truthy(Get(st_113, "ev"))) {
Set(@out_128, "ev", Invoke(Get(st_113, "ev"), "map", Fn((V _self106, int _argc205, V e_211, V _a208, V _a209, V _a210, V[] _rest206) => {
return new ArrBuilder().Add(Call(M_125, V.Undef, GetIdx(e_211, 0D))).Spread(Invoke(e_211, "slice", ((V)(1D)))).V;
}, 1, "", true)));
}
if (Truthy(Get(st_113, "emit"))) {
Set(@out_128, "emit", Invoke(Get(st_113, "emit"), "map", Fn((V _self106, int _argc212, V e_218, V _a215, V _a216, V _a217, V[] _rest213) => {
return new ArrBuilder().Add(Call(M_125, V.Undef, GetIdx(e_218, 0D))).Add((GeN(GetIdx(e_218, 1D), 100000000D) ? GetIdx(e_218, 1D) : Call(M_125, V.Undef, GetIdx(e_218, 1D)))).Spread(Invoke(e_218, "slice", ((V)(2D)))).V;
}, 1, "", true)));
}
if (Truthy(Get(st_113, "fx"))) {
V f_219 = default;
V Mi_220 = default;
f_219 = Get(st_113, "fx");
Mi_220 = Fn((V _self106, int _argc221, V t_227, V _a224, V _a225, V _a226, V[] _rest222) => {
return (Lt(t_227, t0_116) ? t_227 : (Le(t_227, Add(t0_116, Wt_123)) ? Add(t0_116, ((V)((((ToNum(t_227) - ToNum(t0_116)) * (ToNum(t1_117) - ToNum(t0_116))) / ToNum(Wt_123))))) : ((V)((ToNum(t_227) - dl_124)))));
}, 1, "", true);
Set(@out_128, "fx", Fn((V _self106, int _argc228, V I_234, V tt_235, V _a232, V _a233, V[] _rest229) => {
return Call(f_219, V.Undef, I_234, Call(Mi_220, V.Undef, tt_235));
}, 2, "", true));
}
return @out_128;
return default;
}, 3, "splice", false);
convert_24 = Fn((V _self236, int _argc237, V st_243, V key_244, V _a241, V _a242, V[] _rest238) => {
V mode_245 = default;
V W_246 = default;
V @out_247 = default;
if (_self236.IsNullish) _self236 = GlobalV;
if (Truthy(((((!(Truthy(st_243)) ? V.True : V.False) is var _t248 && Truthy(_t248) ? _t248 : Get(st_243, "__whip")) is var _t249 && Truthy(_t249) ? _t249 : (!(Truthy(Get(st_243, "k"))) ? V.True : V.False)) is var _t251 && Truthy(_t251) ? _t251 : (!(Truthy((Get(st_243, "loop") is var _t250 && Truthy(_t250) ? _t250 : Get(st_243, "dur")))) ? V.True : V.False)))) {
return st_243;
}
mode_245 = GetK(PLAN_12, key_244);
if (!(Truthy(mode_245))) {
return st_243;
}
W_246 = Call(windows_21, V.Undef, Get(Get(st_243, "k"), "spin"));
if (!(Truthy(Get(W_246, "length")))) {
return st_243;
}
@out_247 = st_243;
{
double i_252 = 0;
i_252 = (ToNum(Get(W_246, "length")) - 1D);
while (true) {
if (!((i_252 >= 0D))) break;
@out_247 = Call(splice_23, V.Undef, @out_247, GetIdx(W_246, i_252), Call(dirsFor_22, V.Undef, mode_245, ((V)(i_252))));
i_252--;
}
}
Set(@out_247, "__whip", Get(W_246, "length"));
Set(@out_247, "whip", ((V)(1D)));
Set(@out_247, "whipDirs", Invoke(W_246, "map", Fn((V _self236, int _argc254, V __260, V i_261, V _a258, V _a259, V[] _rest255) => {
return Call(dirsFor_22, V.Undef, mode_245, i_261);
}, 2, "", true)));
return @out_247;
return default;
}, 2, "convert", false);
R_8 = Get(G("window"), "RiveRig");
if (((((!(Truthy(R_8)) || !(Truthy(Get(R_8, "STATES")))) || !(Truthy(Get(Get(R_8, "STATES"), "dance")))) || !(Truthy(Get(R_8, "REST")))) || !(Truthy(Get(R_8, "kv"))))) {
Call(G("setTimeout"), V.Undef, boot_262.v, ((V)(25D)));
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
rv_13 = Fn((V _self1, int _argc263, V c_269, V _a266, V _a267, V _a268, V[] _rest264) => {
return (!GetK(REST_10, c_269).IsNullish ? GetK(REST_10, c_269) : ((V)(0D)));
}, 1, "", true);
S_14 = Fn((V _self1, int _argc270, V s_276, V _a273, V _a274, V _a275, V[] _rest271) => {
return (LtN(s_276, 0D) ? NewObj(5).Put("arm", ((V)("armL"))).Put("hx", ((V)("hLx"))).Put("hy", ((V)("hLy"))).Put("hz", ((V)("hLz"))).Put("foot", ((V)("footL"))).V : NewObj(5).Put("arm", ((V)("armR"))).Put("hx", ((V)("hRx"))).Put("hy", ((V)("hRy"))).Put("hz", ((V)("hRz"))).Put("foot", ((V)("footR"))).V);
}, 1, "", true);
hand_15 = Fn((V _self1, int _argc277, V s_283, V inX_284, V y_285, V z_286, V[] _rest278) => {
V k_287 = default;
k_287 = Call(S_14, V.Undef, s_283);
return NewObj(3).PutK(Get(k_287, "hx"), (LtN(s_283, 0D) ? inX_284 : ((V)((-ToNum(inX_284)))))).PutK(Get(k_287, "hy"), y_285).PutK(Get(k_287, "hz"), z_286).V;
return default;
}, 4, "", true);
o_16 = Fn((V _self1, int _argc288, V _a290, V _a291, V _a292, V _a293, V[] _rest289) => {
V a_294 = default;
a_294 = RestArgs(0, _argc288, _a290, _a291, _a292, _a293, _rest289);
return InvokeSpread(G("Object"), "assign", new ArrBuilder().Add(NewObj(0).V).Spread(a_294).V);
}, 1, "", true);
NEUTRAL_19 = NewObj(15).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).Put("bend", ((V)(0D))).Put("twist", ((V)(0D))).Put("ly", ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).Put("wide", ((V)(0D))).Put("frown", ((V)(0D))).Put("tongue", ((V)(0D))).Put("puff", ((V)(0D))).Put("sit", ((V)(0D))).Put("split", ((V)(0D))).Put("ume", ((V)(0D))).Put("flop", ((V)(0D))).V;
HOLD_20 = NewObj(1).Put("x", ((V)(1D))).V;
Set(R_8, "whipConvert", convert_24);
Invoke(Object_keys(PLAN_12), "forEach", Fn((V _self1, int _argc295, V key_301, V _a298, V _a299, V _a300, V[] _rest296) => {
V nm_302 = default;
V val_303 = default;
V D_304 = default;
nm_302 = ((V)(string.Concat("dance@", ToStr(key_301))));
val_303 = (Call(convert_24, V.Undef, (GetK(STATES_9, nm_302) is var _t305 && Truthy(_t305) ? _t305 : (SEqS(key_301, "mittens") ? Get(STATES_9, "dance") : V.Null)), key_301) is var _t306 && Truthy(_t306) ? _t306 : V.Undef);
D_304 = NewObj(3).Put("configurable", (true ? V.True : V.False)).Put("get", Fn((V _self307, int _argc308, V _a310, V _a311, V _a312, V _a313, V[] _rest309) => {
if (_self307.IsNullish) _self307 = GlobalV;
return val_303;
return default;
}, 0, "get", false)).Put("set", Fn((V _self314, int _argc315, V v_321, V _a318, V _a319, V _a320, V[] _rest316) => {
if (_self314.IsNullish) _self314 = GlobalV;
val_303 = Call(convert_24, V.Undef, v_321, key_301);
if (Truthy(((!(Truthy(Get(D_304, "enumerable"))) ? V.True : V.False) is var _t322 && !Truthy(_t322) ? _t322 : val_303))) {
Set(D_304, "enumerable", (true ? V.True : V.False));
Object_defineProperty(STATES_9, nm_302, D_304);
}
return default;
}, 1, "set", false)).V;
Set(D_304, "enumerable", (!(!(Truthy(val_303))) ? V.True : V.False));
Object_defineProperty(STATES_9, nm_302, D_304);
return default;
}, 1, "", true));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
