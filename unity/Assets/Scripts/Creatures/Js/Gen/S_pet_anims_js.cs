// pet-anims.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_pet_anims_js
    {

        public static void Run()
        {
Call(Named(boot_201 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V R_8 = default;
V REST_9 = default;
V ST_10 = default;
V DESC_11 = default;
V TL_12 = default;
V S_13 = default;
V hand_14 = default;
V both_15 = default;
V o_16 = default;
V NOHANDS_17 = default;
V jump_18 = default;
V steps_19 = default;
V swing_20 = default;
V look_21 = default;
V shake_22 = default;
V jelly_23 = default;
V land_24 = default;
V CARD_25 = default;
V GRP_26 = default;
V flavor_27 = default;
V SHARED_28 = default;
V MOVES_29 = default;
V popcorn_30 = default;
V croak_31 = default;
V PRESS_32 = default;
V REL_33 = default;
V install_34 = default;
V G_35 = default;
if (_self1.IsNullish) _self1 = GlobalV;
TL_12 = Fn((V _self36, int _argc37, V @base_43, V T_44, V _a41, V _a42, V[] _rest38) => {
V B0_45 = default;
V k_46 = default;
V ev_47 = default;
V em_48 = default;
V t_49 = default;
V o_50 = default;
if (_self36.IsNullish) _self36 = GlobalV;
@base_43 = (@base_43 is var _t51 && Truthy(_t51) ? _t51 : NewObj(0).V);
T_44 = (T_44 is var _t52 && Truthy(_t52) ? _t52 : ((V)(1D)));
B0_45 = Fn((V _self36, int _argc53, V p_59, V _a56, V _a57, V _a58, V[] _rest54) => {
return (HasProperty(@base_43, p_59) ? GetK(@base_43, p_59) : GetK(REST_9, p_59));
}, 1, "", true);
k_46 = NewObj(0).V;
ev_47 = Arr();
em_48 = Arr();
t_49 = ((V)(0D));
o_50 = NewObj(12).Getter("t", Fn((V _self60, int _argc61, V _a63, V _a64, V _a65, V _a66, V[] _rest62) => {
if (_self60.IsNullish) _self60 = GlobalV;
return t_49;
return default;
}, 0, "t", false)).Put("b", B0_45).Put("to", Fn((V _self67, int _argc68, V dt_74, V v_75, V ez_76, V _a73, V[] _rest69) => {
if (_self67.IsNullish) _self67 = GlobalV;
dt_74 = ((V)((ToNum(dt_74) * ToNum(T_44))));
{
foreach (V _k77 in ForInKeys(v_75)) {
V p_78 = default;
p_78 = _k77;
V L_79 = default;
L_79 = (GetK(k_46, p_78) is var _t80 && Truthy(_t80) ? _t80 : SetK(k_46, p_78, Arr(Arr(((V)(0D)), Call(B0_45, V.Undef, p_78)))));
if (Lt(GetIdx(GetIdx(L_79, (ToNum(Get(L_79, "length")) - 1D)), 0D), t_49)) {
Invoke(L_79, "push", Arr(t_49, GetIdx(GetIdx(L_79, (ToNum(Get(L_79, "length")) - 1D)), 1D), ((V)("l"))));
}
}
}
t_49 = Add(t_49, dt_74);
{
foreach (V _k81 in ForInKeys(v_75)) {
V p_82 = default;
p_82 = _k81;
Invoke(GetK(k_46, p_82), "push", Arr(t_49, GetK(v_75, p_82), (ez_76 is var _t83 && Truthy(_t83) ? _t83 : ((V)("io")))));
}
}
return o_50;
return default;
}, 3, "to", false)).Put("wait", Fn((V _self84, int _argc85, V dt_91, V _a88, V _a89, V _a90, V[] _rest86) => {
if (_self84.IsNullish) _self84 = GlobalV;
t_49 = Add(t_49, ((V)((ToNum(dt_91) * ToNum(T_44)))));
return o_50;
return default;
}, 1, "wait", false)).Put("at", Fn((V _self92, int _argc93, V x_99, V _a96, V _a97, V _a98, V[] _rest94) => {
if (_self92.IsNullish) _self92 = GlobalV;
t_49 = x_99;
return o_50;
return default;
}, 1, "at", false)).Put("e", Fn((V _self100, int _argc101, V _a103, V _a104, V _a105, V _a106, V[] _rest102) => {
V a_107 = default;
if (_self100.IsNullish) _self100 = GlobalV;
a_107 = RestArgs(0, _argc101, _a103, _a104, _a105, _a106, _rest102);
Invoke(ev_47, "push", new ArrBuilder().Add(t_49).Spread(a_107).V);
return o_50;
return default;
}, 1, "e", false)).Put("em", Fn((V _self108, int _argc109, V dur_115, V every_116, V preset_117, V where_118, V[] _rest110) => {
V n_119 = default;
if (_self108.IsNullish) _self108 = GlobalV;
n_119 = (_argc109 > 4 ? _rest110[0] : V.Undef);
Invoke(em_48, "push", Arr(t_49, Add(t_49, dur_115), every_116, preset_117, where_118, n_119));
return o_50;
return default;
}, 5, "em", false)).Put("osc", Fn((V _self120, int _argc121, V dt_127, V n_128, V A_129, V B_130, V[] _rest122) => {
double h_132 = 0;
V ez_131 = default;
if (_self120.IsNullish) _self120 = GlobalV;
ez_131 = (_argc121 > 4 ? _rest122[0] : V.Undef);
h_132 = ((ToNum(dt_127) / ToNum(n_128)) / 2D);
{
double i_133 = 0;
i_133 = 0D;
while (true) {
if (!(Lt(((V)(i_133)), n_128))) break;
Invoke(Invoke(o_50, "to", ((V)(h_132)), A_129, (ez_131 is var _t136 && Truthy(_t136) ? _t136 : ((V)("io")))), "to", ((V)(h_132)), B_130, (ez_131 is var _t135 && Truthy(_t135) ? _t135 : ((V)("io"))));
i_133++;
}
}
return o_50;
return default;
}, 5, "osc", false)).Put("rest", Fn((V _self137, int _argc138, V dt_144, V ez_145, V _a142, V _a143, V[] _rest139) => {
V b_146 = default;
if (_self137.IsNullish) _self137 = GlobalV;
b_146 = NewObj(0).V;
{
foreach (V _k147 in ForInKeys(k_46)) {
V p_148 = default;
p_148 = _k147;
SetK(b_146, p_148, Call(B0_45, V.Undef, p_148));
}
}
return Invoke(o_50, "to", (dt_144 is var _t149 && Truthy(_t149) ? _t149 : ((V)(450D))), b_146, ez_145);
return default;
}, 2, "rest", false)).Put("out", Fn((V _self150, int _argc151, V x_157, V loop_158, V _a155, V _a156, V[] _rest152) => {
if (_self150.IsNullish) _self150 = GlobalV;
{
foreach (V _k159 in ForInKeys(@base_43)) {
V p_160 = default;
p_160 = _k159;
if (!(Truthy(GetK(k_46, p_160)))) {
SetK(k_46, p_160, Arr(Arr(((V)(0D)), GetK(@base_43, p_160))));
}
}
}
{
foreach (V _k161 in ForInKeys(k_46)) {
V p_162 = default;
p_162 = _k161;
V L_163 = default;
L_163 = Invoke(GetK(k_46, p_162), "sort", Fn((V _self150, int _argc164, V a_170, V b_171, V _a168, V _a169, V[] _rest165) => {
return ((V)((ToNum(GetIdx(a_170, 0D)) - ToNum(GetIdx(b_171, 0D)))));
}, 2, "", true));
if ((GtN(Get(L_163, "length"), 1D) && Lt(GetIdx(GetIdx(L_163, (ToNum(Get(L_163, "length")) - 1D)), 0D), t_49))) {
Invoke(L_163, "push", Arr(t_49, GetIdx(GetIdx(L_163, (ToNum(Get(L_163, "length")) - 1D)), 1D), ((V)("l"))));
}
if (Truthy((loop_158 is var _t172 && !Truthy(_t172) ? _t172 : (GtN(Get(L_163, "length"), 1D) ? V.True : V.False)))) {
V a_173 = default;
V b_174 = default;
a_173 = GetIdx(GetIdx(L_163, 0D), 1D);
b_174 = GetIdx(GetIdx(L_163, (ToNum(Get(L_163, "length")) - 1D)), 1D);
if ((SEqS(p_162, "spin") ? (System.Math.Abs((((((ToNum(b_174) - ToNum(a_173)) % 360D) + 540D) % 360D) - 180D)) > 0.5) : (System.Math.Abs((ToNum(b_174) - ToNum(a_173))) > 0.000001))) {
Invoke(Set(R_8, "LOOPWARN", (Get(R_8, "LOOPWARN") is var _t175 && Truthy(_t175) ? _t175 : Arr())), "push", ((V)(string.Concat(new string[] { ToStr(p_162), " ", ToStr(a_173), "->", ToStr(b_174) }))));
}
}
}
}
Invoke(ev_47, "sort", Fn((V _self150, int _argc176, V a_182, V b_183, V _a180, V _a181, V[] _rest177) => {
return ((V)((ToNum(GetIdx(a_182, 0D)) - ToNum(GetIdx(b_183, 0D)))));
}, 2, "", true));
return Object_assign((Truthy(loop_158) ? NewObj(1).Put("loop", t_49).V : NewObj(1).Put("dur", t_49).V), NewObj(3).Put("k", k_46).Put("ev", ev_47).Put("emit", em_48).V, (x_157 is var _t184 && Truthy(_t184) ? _t184 : NewObj(0).V));
return default;
}, 2, "out", false)).Put("done", Fn((V _self185, int _argc186, V x_192, V _a189, V _a190, V _a191, V[] _rest187) => {
if (_self185.IsNullish) _self185 = GlobalV;
return Invoke(o_50, "out", x_192);
return default;
}, 1, "done", false)).Put("loop", Fn((V _self193, int _argc194, V x_200, V _a197, V _a198, V _a199, V[] _rest195) => {
if (_self193.IsNullish) _self193 = GlobalV;
return Invoke(o_50, "out", x_200, (true ? V.True : V.False));
return default;
}, 1, "loop", false)).V;
return o_50;
return default;
}, 2, "TL", false);
R_8 = Get(G("window"), "RiveRig");
if (((((!(Truthy(R_8)) || !(Truthy(Get(R_8, "REST")))) || !(Truthy(Get(R_8, "GROUPS")))) || !(Truthy(Get(Get(R_8, "STATES"), "dance")))) || !(Truthy(Get(Get(R_8, "STATES"), "poke_head"))))) {
Call(G("setTimeout"), V.Undef, boot_201.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_8, "petV"))) {
return default;
}
Set(R_8, "petV", ((V)(1D)));
REST_9 = Get(R_8, "REST");
ST_10 = NewObj(0).V;
DESC_11 = Set(R_8, "DESC", (Get(R_8, "DESC") is var _t202 && Truthy(_t202) ? _t202 : NewObj(0).V));
S_13 = Fn((V _self1, int _argc203, V s_209, V _a206, V _a207, V _a208, V[] _rest204) => {
return (LtN(s_209, 0D) ? NewObj(7).Put("arm", ((V)("armL"))).Put("hx", ((V)("hLx"))).Put("hy", ((V)("hLy"))).Put("ear", ((V)("earL"))).Put("wink", ((V)("winkL"))).Put("foot", ((V)("footL"))).Put("paw", ((V)("pawL"))).V : NewObj(7).Put("arm", ((V)("armR"))).Put("hx", ((V)("hRx"))).Put("hy", ((V)("hRy"))).Put("ear", ((V)("earR"))).Put("wink", ((V)("winkR"))).Put("foot", ((V)("footR"))).Put("paw", ((V)("pawR"))).V);
}, 1, "", true);
hand_14 = Fn((V _self1, int _argc210, V s_216, V inX_217, V y_218, V _a215, V[] _rest211) => {
V k_219 = default;
k_219 = Call(S_13, V.Undef, s_216);
return NewObj(2).PutK(Get(k_219, "hx"), (LtN(s_216, 0D) ? inX_217 : ((V)((-ToNum(inX_217)))))).PutK(Get(k_219, "hy"), y_218).V;
return default;
}, 3, "", true);
both_15 = Fn((V _self1, int _argc220, V inX_226, V y_227, V _a224, V _a225, V[] _rest221) => {
return Object_assign(Call(hand_14, V.Undef, ((V)((-1D))), inX_226, y_227), Call(hand_14, V.Undef, ((V)(1D)), inX_226, y_227));
}, 2, "", true);
o_16 = Fn((V _self1, int _argc228, V _a230, V _a231, V _a232, V _a233, V[] _rest229) => {
V a_234 = default;
a_234 = RestArgs(0, _argc228, _a230, _a231, _a232, _a233, _rest229);
return InvokeSpread(G("Object"), "assign", new ArrBuilder().Add(NewObj(0).V).Spread(a_234).V);
}, 1, "", true);
NOHANDS_17 = Call(both_15, V.Undef, ((V)(0D)), ((V)(0D)));
jump_18 = Fn((V _self1, int _argc235, V t_241, V J_242, V _a239, V _a240, V[] _rest236) => {
V h_243 = default;
V up_244 = default;
V dn_245 = default;
V c_246 = default;
V ant_247 = default;
V arm_248 = default;
V st_249 = default;
V a_250 = default;
V b_251 = default;
J_242 = (J_242 is var _t252 && Truthy(_t252) ? _t252 : NewObj(0).V);
h_243 = (Get(J_242, "h") is var _t253 && Truthy(_t253) ? _t253 : ((V)(12D)));
up_244 = (Get(J_242, "up") is var _t254 && Truthy(_t254) ? _t254 : ((V)(260D)));
dn_245 = (Get(J_242, "dn") is var _t255 && Truthy(_t255) ? _t255 : ((V)(Round((ToNum(up_244) * 0.92)))));
c_246 = (Get(J_242, "c").IsNullish ? ((V)(0.18)) : Get(J_242, "c"));
ant_247 = (Get(J_242, "ant") is var _t256 && Truthy(_t256) ? _t256 : ((V)(170D)));
arm_248 = (Get(J_242, "arm").IsNullish ? ((V)(40D)) : Get(J_242, "arm"));
st_249 = (Get(J_242, "st") is var _t257 && Truthy(_t257) ? _t257 : ((V)(1D)));
Invoke(t_241, "to", ant_247, Call(o_16, V.Undef, NewObj(4).Put("sq", c_246).Put("pitch", ((V)((-0.1)))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).V, Get(J_242, "pre")), ((V)("io")));
a_250 = Get(t_241, "t");
Invoke(Invoke(t_241, "to", up_244, Call(o_16, V.Undef, NewObj(1).Put("lift", h_243).V, Get(J_242, "air")), ((V)("o"))), "to", dn_245, Call(o_16, V.Undef, NewObj(1).Put("lift", ((V)(0D))).V, Get(J_242, "fall")), ((V)("i")));
b_251 = Get(t_241, "t");
if (!Get(J_242, "x").IsNullish) {
Invoke(Invoke(t_241, "at", ((V)((ToNum(a_250) - 30D)))), "to", Add(Add(up_244, dn_245), ((V)(30D))), NewObj(1).Put("x", Get(J_242, "x")).V, ((V)("io")));
}
if (Truthy(Get(J_242, "spin"))) {
Invoke(Invoke(t_241, "at", a_250), "to", Add(up_244, dn_245), NewObj(1).Put("spin", Get(J_242, "spin")).V, ((V)("io")));
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_241, "at", a_250), "to", ((V)(80D)), NewObj(1).Put("sq", ((V)(((-0.16) * ToNum(st_249))))).V, ((V)("o"))), "to", ((V)((ToNum(up_244) - 80D))), NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("io"))), "to", ((V)((ToNum(dn_245) * 0.6))), NewObj(1).Put("sq", ((V)((-0.02)))).V, ((V)("io"))), "to", ((V)((ToNum(dn_245) * 0.4))), NewObj(1).Put("sq", ((V)(((-0.09) * ToNum(st_249))))).V, ((V)("i")));
Invoke(Invoke(Invoke(t_241, "at", Add(a_250, ((V)(40D)))), "to", ((V)((ToNum(up_244) - 40D))), NewObj(3).Put("armL", arm_248).Put("armR", arm_248).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "to", dn_245, NewObj(3).Put("armL", ((V)((ToNum(arm_248) * 0.6)))).Put("armR", ((V)((ToNum(arm_248) * 0.6)))).Put("pitch", ((V)((-0.04)))).V, ((V)("io")));
Invoke(t_241, "at", b_251);
if (Truthy(Get(J_242, "spin"))) {
Invoke(t_241, "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
}
Invoke((Get(J_242, "ev") is var _t265 && Truthy(_t265) ? _t265 : Arr()), "forEach", Fn((V _self1, int _argc258, V e_264, V _a261, V _a262, V _a263, V[] _rest259) => {
return InvokeSpread(t_241, "e", new ArrBuilder().Spread(e_264).V);
}, 1, "", true));
if (Truthy(Get(J_242, "chain"))) {
return Invoke(t_241, "to", ((V)(80D)), Call(o_16, V.Undef, NewObj(4).Put("sq", ((V)((ToNum(c_246) * 1.1)))).Put("pitch", ((V)((-0.08)))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).V, Get(J_242, "land")), ((V)("o")));
}
return Invoke(Invoke(Invoke(t_241, "to", ((V)(80D)), Call(o_16, V.Undef, NewObj(4).Put("sq", ((V)((ToNum(c_246) * 1.2)))).Put("pitch", ((V)((-0.12)))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).V, Get(J_242, "land")), ((V)("o"))), "to", ((V)(150D)), NewObj(4).Put("sq", ((V)((-0.05)))).Put("pitch", ((V)(0.03))).Put("armL", ((V)(4D))).Put("armR", ((V)(4D))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(4).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
steps_19 = Fn((V _self1, int _argc266, V t_272, V dur_273, V n_274, V h_275, V[] _rest267) => {
double q_276 = 0;
q_276 = ((ToNum(dur_273) / ToNum(n_274)) / 2D);
{
double i_277 = 0;
i_277 = 0D;
while (true) {
if (!(Lt(((V)(i_277)), n_274))) break;
V f_279 = default;
f_279 = ((V)((NumTruthy((i_277 % 2D)) ? "footR" : "footL")));
Invoke(Invoke(t_272, "to", ((V)(q_276)), NewObj(1).PutK(f_279, h_275).V, ((V)("o"))), "to", ((V)(q_276)), NewObj(1).PutK(f_279, ((V)(0D))).V, ((V)("i")));
i_277++;
}
}
return t_272;
return default;
}, 4, "", true);
swing_20 = Fn((V _self1, int _argc280, V t_286, V dur_287, V n_288, V A_289, V[] _rest281) => {
double h_291 = 0;
V z_292 = default;
V ez_290 = default;
ez_290 = (_argc280 > 4 ? _rest281[0] : V.Undef);
h_291 = (ToNum(dur_287) / ToNum(Add(n_288, ((V)(1D)))));
{
double i_293 = 0;
i_293 = 0D;
while (true) {
if (!(Lt(((V)(i_293)), n_288))) break;
V v_295 = default;
v_295 = NewObj(0).V;
{
foreach (V _k296 in ForInKeys(A_289)) {
V p_297 = default;
p_297 = _k296;
SetK(v_295, p_297, Add(Invoke(t_286, "b", p_297), ((V)((ToNum(GetK(A_289, p_297)) * (NumTruthy((i_293 % 2D)) ? (-1D) : 1D))))));
}
}
Invoke(t_286, "to", ((V)(h_291)), v_295, (ez_290 is var _t298 && Truthy(_t298) ? _t298 : ((V)("io"))));
i_293++;
}
}
z_292 = NewObj(0).V;
{
foreach (V _k299 in ForInKeys(A_289)) {
V p_300 = default;
p_300 = _k299;
SetK(z_292, p_300, Invoke(t_286, "b", p_300));
}
}
return Invoke(t_286, "to", ((V)(h_291)), z_292, (ez_290 is var _t301 && Truthy(_t301) ? _t301 : ((V)("io"))));
return default;
}, 5, "", true);
look_21 = Fn((V _self1, int _argc302, V t_308, V from_309, V to_310, V J_311, V[] _rest303) => {
V s_312 = default;
double dir_313 = 0;
V k_314 = default;
V d1_315 = default;
V d2_316 = default;
V T_317 = default;
double bendTo_318 = 0;
double twTo_319 = 0;
V e1_320 = default;
J_311 = (J_311 is var _t321 && Truthy(_t321) ? _t321 : NewObj(0).V);
s_312 = (((V)(Sign((ToNum(to_310) - ToNum(from_309))))) is var _t322 && Truthy(_t322) ? _t322 : ((V)(1D)));
dir_313 = Sign(ToNum(to_310));
k_314 = (Get(J_311, "k").IsNullish ? ((V)(1D)) : Get(J_311, "k"));
d1_315 = (Get(J_311, "d1") is var _t323 && Truthy(_t323) ? _t323 : ((V)(170D)));
d2_316 = (Get(J_311, "d2") is var _t324 && Truthy(_t324) ? _t324 : ((V)(210D)));
T_317 = Get(t_308, "t");
bendTo_318 = ((dir_313 * 4D) * ToNum(k_314));
twTo_319 = ((ToNum(to_310) * 0.36) * ToNum(k_314));
Invoke(Invoke(Invoke(Invoke(Invoke(t_308, "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((dir_313 * 0.9)))).V, ((V)("o"))), "e", ((V)("blink"))), "to", d1_315, NewObj(4).Put("hyaw", ((V)((ToNum(Add(from_309, to_310)) / 2D)))).Put("pitch", ((V)((-0.2)))).Put("earL", ((V)((ToNum(s_312) * 7D)))).Put("earR", ((V)(((-ToNum(s_312)) * 7D)))).V, ((V)("i"))), "to", d2_316, NewObj(5).Put("hyaw", Add(to_310, ((V)((ToNum(s_312) * 0.08))))).Put("pitch", ((V)(0.05))).Put("earL", ((V)(((-ToNum(s_312)) * 3D)))).Put("earR", ((V)((ToNum(s_312) * 3D)))).Put("htilt", ((V)(((dir_313 * 3D) - bendTo_318)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("hyaw", to_310).Put("pitch", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
e1_320 = Get(t_308, "t");
Invoke(Invoke(Invoke(t_308, "at", Add(T_317, ((V)(200D)))), "to", Add(d1_315, d2_316), NewObj(2).Put("twist", ((V)((twTo_319 + ((ToNum(s_312) * 0.06) * ToNum(k_314)))))).Put("bend", ((V)((bendTo_318 + ((ToNum(s_312) * 1.2) * ToNum(k_314)))))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(2).Put("twist", ((V)(twTo_319))).Put("bend", ((V)(bendTo_318))).V, ((V)("io")));
return Invoke(t_308, "at", ((V)(Max(ToNum(e1_320), ToNum(Get(t_308, "t"))))));
return default;
}, 4, "", true);
shake_22 = Fn((V _self1, int _argc325, V t_331, V J_332, V _a329, V _a330, V[] _rest326) => {
V env_333 = default;
V P_334 = default;
V a_335 = default;
V lag_336 = default;
V tr_337 = default;
V e_338 = default;
env_333 = (Get(J_332, "env") is var _t339 && Truthy(_t339) ? _t339 : Arr(((V)(0.45)), ((V)(0.85)), ((V)(1D)), ((V)(1D)), ((V)(0.85)), ((V)(0.6)), ((V)(0.35)), ((V)(0.15))));
P_334 = (Get(J_332, "P") is var _t340 && Truthy(_t340) ? _t340 : ((V)(110D)));
a_335 = Get(t_331, "t");
lag_336 = (Get(J_332, "lag") is var _t341 && Truthy(_t341) ? _t341 : ((V)((ToNum(P_334) * 0.4))));
tr_337 = Fn((V _self1, int _argc342, V off_348, V f_349, V _a346, V _a347, V[] _rest343) => {
Invoke(t_331, "at", Add(a_335, off_348));
Invoke(env_333, "forEach", Fn((V _self1, int _argc350, V m_356, V i_357, V _a354, V _a355, V[] _rest351) => {
Invoke(t_331, "to", P_334, Call(f_349, V.Undef, ((V)(((NumTruthy((ToNum(i_357) % 2D)) ? (-1D) : 1D) * ToNum(m_356))))), ((V)("io")));
return default;
}, 2, "", true));
Invoke(t_331, "to", P_334, Call(f_349, V.Undef, ((V)(0D))), ((V)("io")));
return Get(t_331, "t");
return default;
}, 2, "", true);
e_338 = Call(tr_337, V.Undef, ((V)(0D)), Fn((V _self1, int _argc358, V s_364, V _a361, V _a362, V _a363, V[] _rest359) => {
return NewObj(4).Put("hyaw", ((V)((ToNum(s_364) * ToNum((Get(J_332, "head") is var _t365 && Truthy(_t365) ? _t365 : ((V)(0.38)))))))).Put("htilt", ((V)((ToNum(s_364) * ToNum((Get(J_332, "roll") is var _t366 && Truthy(_t366) ? _t366 : ((V)(4D)))))))).Put("earL", ((V)(((-ToNum(s_364)) * ToNum((Get(J_332, "ear") is var _t367 && Truthy(_t367) ? _t367 : ((V)(12D)))))))).Put("earR", ((V)((ToNum(s_364) * ToNum((Get(J_332, "ear") is var _t368 && Truthy(_t368) ? _t368 : ((V)(12D)))))))).V;
}, 1, "", true));
if (Truthy(Get(J_332, "chest"))) {
e_338 = ((V)(Max(ToNum(e_338), ToNum(Call(tr_337, V.Undef, lag_336, Fn((V _self1, int _argc369, V s_375, V _a372, V _a373, V _a374, V[] _rest370) => {
return NewObj(1).Put("twist", ((V)((ToNum(s_375) * ToNum(Get(J_332, "chest")))))).V;
}, 1, "", true))))));
}
if (Truthy(Get(J_332, "body"))) {
e_338 = ((V)(Max(ToNum(e_338), ToNum(Call(tr_337, V.Undef, ((V)((ToNum(lag_336) * 1.6))), Fn((V _self1, int _argc376, V s_382, V _a379, V _a380, V _a381, V[] _rest377) => {
return NewObj(2).Put("x", ((V)((ToNum(s_382) * ToNum(Get(J_332, "body")))))).Put("tilt", ((V)(((ToNum(s_382) * ToNum(Get(J_332, "body"))) * 2.4)))).V;
}, 1, "", true))))));
}
if (Truthy(Get(J_332, "tail"))) {
e_338 = ((V)(Max(ToNum(e_338), ToNum(Call(tr_337, V.Undef, ((V)((ToNum(lag_336) * 2.2))), Fn((V _self1, int _argc383, V s_389, V _a386, V _a387, V _a388, V[] _rest384) => {
return NewObj(1).Put("wag", ((V)((ToNum(s_389) * ToNum(Get(J_332, "tail")))))).V;
}, 1, "", true))))));
}
return Invoke(t_331, "at", e_338);
return default;
}, 2, "", true);
jelly_23 = Fn((V _self1, int _argc390, V t_396, V a_397, V n_398, V per_399, V[] _rest391) => {
V ch_400 = default;
ch_400 = (_argc390 > 4 ? _rest391[0] : V.Undef);
ch_400 = (ch_400 is var _t401 && Truthy(_t401) ? _t401 : ((V)("sq")));
{
double i_402 = 0;
i_402 = 0D;
while (true) {
if (!(Lt(((V)(i_402)), n_398))) break;
Invoke(t_396, "to", ((V)((ToNum(per_399) / 2D))), NewObj(1).PutK(ch_400, ((V)((((NumTruthy((i_402 % 2D)) ? 1D : (-1D)) * ToNum(a_397)) * Pow(0.55, i_402))))).V, ((V)("io")));
i_402++;
}
}
return Invoke(t_396, "to", ((V)((ToNum(per_399) / 2D))), NewObj(1).PutK(ch_400, ((V)(0D))).V, ((V)("io")));
return default;
}, 5, "", true);
land_24 = Fn((V _self1, int _argc404, V t_410, V a_411, V n_412, V per_413, V[] _rest405) => {
V q_414 = default;
V e_415 = default;
q_414 = Get(t_410, "t");
Call(jelly_23, V.Undef, t_410, a_411, n_412, per_413);
e_415 = Get(t_410, "t");
return Invoke(Invoke(Invoke(t_410, "at", q_414), "to", ((V)(Min(320D, (ToNum(e_415) - ToNum(q_414))))), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io"))), "at", e_415);
return default;
}, 4, "", true);
CARD_25 = NewObj(9).Put("biscuit", NewObj(5).Put("T", ((V)(0.86))).Put("b", ((V)(1.2))).Put("s", ((V)(1.1))).Put("w", ((V)(1.6))).Put("e", ((V)(1.3))).V).Put("truffle", NewObj(6).Put("T", ((V)(1.06))).Put("b", ((V)(1.3))).Put("s", ((V)(1.15))).Put("w", ((V)(1D))).Put("e", ((V)(1D))).Put("c", ((V)(1.3))).V).Put("nibbles", NewObj(4).Put("T", ((V)(0.78))).Put("b", ((V)(0.9))).Put("s", ((V)(0.85))).Put("e", ((V)(1.2))).V).Put("quill", NewObj(4).Put("T", ((V)(1.18))).Put("b", ((V)(0.75))).Put("s", ((V)(0.8))).Put("e", ((V)(0.8))).V).Put("waffles", NewObj(5).Put("T", ((V)(0.94))).Put("b", ((V)(1.25))).Put("s", ((V)(1.1))).Put("w", ((V)(1.8))).Put("e", ((V)(1.1))).V).Put("poppy", NewObj(4).Put("T", ((V)(0.86))).Put("b", ((V)(1.15))).Put("s", ((V)(0.9))).Put("e", ((V)(1.4))).V).Put("duchess", NewObj(5).Put("T", ((V)(1.25))).Put("b", ((V)(0.7))).Put("s", ((V)(0.9))).Put("w", ((V)(0.7))).Put("c", ((V)(1.3))).V).Put("mamapaws", NewObj(4).Put("T", ((V)(1.2))).Put("b", ((V)(0.85))).Put("s", ((V)(0.9))).Put("w", ((V)(1.3))).V).Put("ribbit", NewObj(4).Put("T", ((V)(0.9))).Put("b", ((V)(1.3))).Put("s", ((V)(1D))).Put("e", ((V)(1D))).V).V;
GRP_26 = NewObj(10).Put("sq", ((V)("b"))).Put("lift", ((V)("b"))).Put("lean", ((V)("s"))).Put("tilt", ((V)("s"))).Put("x", ((V)("s"))).Put("bend", ((V)("s"))).Put("wag", ((V)("w"))).Put("earL", ((V)("e"))).Put("earR", ((V)("e"))).Put("curl", ((V)("c"))).V;
flavor_27 = Fn((V _self1, int _argc416, V st_422, V c_423, V _a420, V _a421, V[] _rest417) => {
V T_424 = default;
V @out_425 = default;
if (Truthy((((((!(Truthy(st_422)) ? V.True : V.False) is var _t426 && Truthy(_t426) ? _t426 : Get(st_422, "seq")) is var _t427 && Truthy(_t427) ? _t427 : Get(st_422, "fx")) is var _t428 && Truthy(_t428) ? _t428 : Get(st_422, "prop")) is var _t429 && Truthy(_t429) ? _t429 : (!(Truthy(Get(st_422, "k"))) ? V.True : V.False)))) {
return V.Null;
}
T_424 = (Get(c_423, "T") is var _t430 && Truthy(_t430) ? _t430 : ((V)(1D)));
@out_425 = Object_assign(NewObj(0).V, st_422, NewObj(1).Put("k", NewObj(0).V).V);
{
foreach (V _k431 in ForInKeys(Get(st_422, "k"))) {
V p_432 = default;
p_432 = _k431;
V a_433 = default;
V r_434 = default;
a_433 = (Truthy(GetK(GRP_26, p_432)) ? (GetK(c_423, GetK(GRP_26, p_432)) is var _t435 && Truthy(_t435) ? _t435 : ((V)(1D))) : ((V)(1D)));
r_434 = (GetK(REST_9, p_432) is var _t436 && Truthy(_t436) ? _t436 : ((V)(0D)));
SetK(Get(@out_425, "k"), p_432, Invoke(GetK(Get(st_422, "k"), p_432), "map", Fn((V _self1, int _argc437, V q_443, V _a440, V _a441, V _a442, V[] _rest438) => {
V v_444 = default;
V n_445 = default;
v_444 = Add(r_434, ((V)(((ToNum(GetIdx(q_443, 1D)) - ToNum(r_434)) * ToNum(a_433)))));
if (SEqS(p_432, "sq")) {
v_444 = ((V)(Max((-0.26), Min(0.36, ToNum(v_444)))));
}
n_445 = Arr(((V)((ToNum(GetIdx(q_443, 0D)) * ToNum(T_424)))), v_444);
if (Truthy(GetIdx(q_443, 2D))) {
Invoke(n_445, "push", GetIdx(q_443, 2D));
}
return n_445;
return default;
}, 1, "", true)));
}
}
if (Truthy(Get(st_422, "dur"))) {
Set(@out_425, "dur", ((V)((ToNum(Get(st_422, "dur")) * ToNum(T_424)))));
}
if (Truthy(Get(st_422, "loop"))) {
Set(@out_425, "loop", ((V)((ToNum(Get(st_422, "loop")) * ToNum(T_424)))));
}
if (Truthy(Get(st_422, "ev"))) {
Set(@out_425, "ev", Invoke(Get(st_422, "ev"), "map", Fn((V _self1, int _argc446, V e_452, V _a449, V _a450, V _a451, V[] _rest447) => {
return Invoke(Arr(((V)((ToNum(GetIdx(e_452, 0D)) * ToNum(T_424))))), "concat", Invoke(e_452, "slice", ((V)(1D))));
}, 1, "", true)));
}
if (Truthy(Get(st_422, "emit"))) {
Set(@out_425, "emit", Invoke(Get(st_422, "emit"), "map", Fn((V _self1, int _argc453, V m_459, V _a456, V _a457, V _a458, V[] _rest454) => {
return Invoke(Arr(((V)((ToNum(GetIdx(m_459, 0D)) * ToNum(T_424)))), ((V)((ToNum(GetIdx(m_459, 1D)) * ToNum(T_424)))), ((V)((ToNum(GetIdx(m_459, 2D)) * ToNum(T_424))))), "concat", Invoke(m_459, "slice", ((V)(3D))));
}, 1, "", true)));
}
return @out_425;
return default;
}, 2, "", true);
SHARED_28 = Arr(((V)("idle")), ((V)("look")), ((V)("squish")), ((V)("spin")), ((V)("hop")), ((V)("idle_yawn")), ((V)("idle_waveL")), ((V)("idle_waveR")), ((V)("cry")), ((V)("sob")), ((V)("sleep")), ((V)("poke_head")), ((V)("poke_earL")), ((V)("poke_earR")), ((V)("poke_nose")), ((V)("poke_cheekL")), ((V)("poke_cheekR")), ((V)("poke_eyeL")), ((V)("poke_eyeR")), ((V)("poke_belly")), ((V)("poke_sideL")), ((V)("poke_sideR")), ((V)("poke_footL")), ((V)("poke_footR")), ((V)("poke_tail")));
MOVES_29 = NewObj(0).V;
Set(MOVES_29, "mittens", NewObj(1).Put("quirk", Arr(Call(Fn((V _self1, int _argc460, V _a462, V _a463, V _a464, V _a465, V[] _rest461) => {
V t_466 = default;
V R1_467 = default;
V R2_468 = default;
V R3_469 = default;
t_466 = Call(TL_12, V.Undef);
R1_467 = Call(hand_14, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D))));
R2_468 = Call(hand_14, V.Undef, ((V)(1D)), ((V)(7D)), ((V)((-27D))));
R3_469 = Call(hand_14, V.Undef, ((V)(1D)), ((V)((-1D))), ((V)((-33D))));
Invoke(Invoke(t_466, "to", ((V)(320D)), Call(o_16, V.Undef, R1_467, NewObj(4).Put("armR", ((V)(20D))).Put("pitch", ((V)((-0.12)))).Put("htilt", ((V)(4D))).Put("ly", ((V)(0.4))).V), ((V)("io"))), "e", ((V)("blink")));
Invoke(t_466, "osc", ((V)(900D)), ((V)(3D)), NewObj(4).Put("tongue", ((V)(0.9))).Put("open", ((V)(0.15))).Put("pitch", ((V)((-0.16)))).Put("sq", ((V)(0.015))).V, NewObj(4).Put("tongue", ((V)(0.1))).Put("open", ((V)(0D))).Put("pitch", ((V)((-0.1)))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_466, "to", ((V)(160D)), NewObj(2).Put("tongue", ((V)(0D))).Put("close", ((V)(0.9))).V, ((V)("io")));
{
double i_470 = 0;
i_470 = 0D;
while (true) {
if (!((i_470 < 2D))) break;
Invoke(Invoke(Invoke(t_466, "to", ((V)(260D)), Call(o_16, V.Undef, R2_468, NewObj(3).Put("htilt", ((V)(9D))).Put("pitch", ((V)((-0.18)))).Put("earR", ((V)(10D))).V), ((V)("io"))), "to", ((V)(260D)), Call(o_16, V.Undef, R3_469, NewObj(3).Put("htilt", ((V)(12D))).Put("earR", ((V)(18D))).Put("sq", ((V)(0.02))).V), ((V)("o"))), "to", ((V)(240D)), Call(o_16, V.Undef, R1_467, NewObj(3).Put("htilt", ((V)(5D))).Put("earR", ((V)(2D))).Put("sq", ((V)(0D))).V), ((V)("io")));
i_470++;
}
}
Invoke(t_466, "to", ((V)(240D)), Call(o_16, V.Undef, NOHANDS_17, NewObj(4).Put("armR", ((V)(0D))).Put("pitch", ((V)((-0.05)))).Put("earR", ((V)(0D))).Put("close", ((V)(0.9))).V), ((V)("io")));
Call(shake_22, V.Undef, t_466, NewObj(6).Put("P", ((V)(85D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.85)), ((V)(0.55)), ((V)(0.25)))).Put("head", ((V)(0.36))).Put("roll", ((V)(4D))).Put("ear", ((V)(13D))).Put("chest", ((V)(0.08))).V);
Invoke(Invoke(Invoke(Invoke(t_466, "to", ((V)(160D)), NewObj(2).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(450D))), "rest", ((V)(420D)));
return Invoke(t_466, "done");
return default;
}, 0, "", true), V.Undef), ((V)("Face wash")), ((V)("Licks a paw three times and wipes it over his ear (head leaning into it), then a quick cat head shake that dies away.")))).V);
Set(MOVES_29, "biscuit", NewObj(7).Put("dance", Arr(Call(Fn((V _self1, int _argc472, V _a474, V _a475, V _a476, V _a477, V[] _rest473) => {
V t_478 = default;
double B_479 = 0;
V snap_480 = default;
V a_481 = default;
V b_482 = default;
t_478 = Call(TL_12, V.Undef, NewObj(1).Put("smile", ((V)(0.5))).V);
B_479 = 500D;
snap_480 = Fn((V _self1, int _argc483, V v_489, V over_490, V len_491, V _a488, V[] _rest484) => {
Invoke(Invoke(t_478, "to", ((V)(90D)), over_490, ((V)("o"))), "to", ((V)(80D)), v_489, ((V)("io")));
return Invoke(t_478, "wait", ((V)((ToNum((len_491 is var _t492 && Truthy(_t492) ? _t492 : ((V)(B_479)))) - 170D))));
return default;
}, 3, "", true);
Invoke(Invoke(t_478, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(60D)), NewObj(1).Put("lx", ((V)(0.7))).V, ((V)("o")));
Call(snap_480, V.Undef, NewObj(5).Put("armR", ((V)(88D))).Put("hyaw", ((V)(0.32))).Put("sq", ((V)(0D))).Put("wag", ((V)(14D))).Put("htilt", ((V)((-2D)))).V, NewObj(5).Put("armR", ((V)(97D))).Put("hyaw", ((V)(0.38))).Put("sq", ((V)(0.05))).Put("wag", ((V)(18D))).Put("htilt", ((V)((-3D)))).V, ((V)((B_479 - 60D))));
Invoke(t_478, "to", ((V)(60D)), NewObj(1).Put("lx", ((V)((-0.7)))).V, ((V)("o")));
Call(snap_480, V.Undef, NewObj(5).Put("armL", ((V)(88D))).Put("hyaw", ((V)((-0.32)))).Put("sq", ((V)(0D))).Put("wag", ((V)((-14D)))).Put("htilt", ((V)(2D))).V, NewObj(5).Put("armL", ((V)(97D))).Put("hyaw", ((V)((-0.38)))).Put("sq", ((V)(0.05))).Put("wag", ((V)((-18D)))).Put("htilt", ((V)(3D))).V, ((V)((B_479 - 60D))));
Invoke(t_478, "to", ((V)(60D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("o")));
Call(snap_480, V.Undef, NewObj(4).Put("hyaw", ((V)(0D))).Put("htilt", ((V)(9D))).Put("wag", ((V)(14D))).Put("sq", ((V)(0D))).V, NewObj(4).Put("hyaw", ((V)(0.05))).Put("htilt", ((V)(11D))).Put("wag", ((V)(18D))).Put("sq", ((V)(0.04))).V, ((V)((B_479 - 60D))));
Call(snap_480, V.Undef, NewObj(3).Put("htilt", ((V)((-9D)))).Put("wag", ((V)((-14D)))).Put("sq", ((V)(0D))).V, NewObj(3).Put("htilt", ((V)((-11D)))).Put("wag", ((V)((-18D)))).Put("sq", ((V)(0.04))).V);
Call(snap_480, V.Undef, NewObj(6).Put("armR", ((V)(150D))).Put("armL", ((V)(0D))).Put("x", ((V)(2D))).Put("htilt", ((V)(0D))).Put("wag", ((V)(14D))).Put("sq", ((V)(0D))).V, NewObj(6).Put("armR", ((V)(158D))).Put("armL", ((V)((-6D)))).Put("x", ((V)(2.6))).Put("htilt", ((V)(1D))).Put("wag", ((V)(18D))).Put("sq", ((V)(0.05))).V);
Call(snap_480, V.Undef, NewObj(5).Put("armR", ((V)(0D))).Put("armL", ((V)(150D))).Put("x", ((V)((-2D)))).Put("wag", ((V)((-14D)))).Put("sq", ((V)(0D))).V, NewObj(5).Put("armR", ((V)((-6D)))).Put("armL", ((V)(158D))).Put("x", ((V)((-2.6)))).Put("wag", ((V)((-18D)))).Put("sq", ((V)(0.05))).V);
Call(snap_480, V.Undef, NewObj(5).Put("armR", ((V)(62D))).Put("armL", ((V)(62D))).Put("x", ((V)(0D))).Put("wag", ((V)(0D))).Put("sq", ((V)(0D))).V, NewObj(5).Put("armR", ((V)(68D))).Put("armL", ((V)(68D))).Put("x", ((V)(0.4))).Put("wag", ((V)(4D))).Put("sq", ((V)(0.06))).V);
Call(snap_480, V.Undef, NewObj(3).Put("armR", ((V)(122D))).Put("armL", ((V)(28D))).Put("sq", ((V)(0D))).V, NewObj(3).Put("armR", ((V)(128D))).Put("armL", ((V)(22D))).Put("sq", ((V)(0.05))).V);
Invoke(t_478, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_493 = 0;
i_493 = 0D;
while (true) {
if (!((i_493 < 4D))) break;
double d_495 = 0;
V k_496 = default;
V j_497 = default;
d_495 = (NumTruthy((i_493 % 2D)) ? 1D : (-1D));
k_496 = Call(S_13, V.Undef, ((V)(d_495)));
j_497 = Call(S_13, V.Undef, ((V)((-d_495))));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_478, "to", ((V)(90D)), NewObj(9).PutK(Get(k_496, "foot"), ((V)(4.5))).PutK(Get(j_497, "foot"), ((V)(0D))).PutK(Get(k_496, "arm"), ((V)((-14D)))).PutK(Get(j_497, "arm"), ((V)(46D))).Put("turn", ((V)((d_495 * 0.12)))).Put("sq", ((V)((-0.03)))).Put("lift", ((V)(1D))).Put("x", ((V)((d_495 * 0.8)))).Put("wag", ((V)((d_495 * 12D)))).V, ((V)("o"))), "to", ((V)(80D)), NewObj(2).PutK(Get(k_496, "foot"), ((V)(3.6))).Put("sq", ((V)((-0.01)))).V, ((V)("io"))), "wait", ((V)(80D))), "to", ((V)(90D)), NewObj(3).PutK(Get(k_496, "foot"), ((V)(0D))).Put("sq", ((V)(0.07))).Put("lift", ((V)(0D))).V, ((V)("i"))), "to", ((V)(80D)), NewObj(1).Put("sq", ((V)(0.02))).V, ((V)("io"))), "wait", ((V)(80D)));
i_493++;
}
}
Invoke(Invoke(Invoke(Invoke(t_478, "to", ((V)(120D)), NewObj(6).Put("turn", ((V)(0D))).Put("x", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("wag", ((V)(0D))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(10).Put("sq", ((V)(0.17))).Put("pitch", ((V)((-0.38)))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).Put("earL", ((V)(4D))).Put("earR", ((V)(4D))).Put("close", ((V)(0.8))).Put("smile", ((V)(0D))).Put("ly", ((V)(0.6))).Put("htilt", ((V)(6D))).V, ((V)("i"))), "to", ((V)(90D)), NewObj(1).Put("sq", ((V)(0.21))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(1).Put("sq", ((V)(0.19))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_478, "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(4D))), "to", ((V)(70D)), NewObj(3).Put("close", ((V)(0D))).Put("wide", ((V)(1D))).Put("ly", ((V)((-0.2)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(8).Put("sq", ((V)((-0.09)))).Put("lift", ((V)(5D))).Put("pitch", ((V)(0.12))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).Put("htilt", ((V)(0D))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(3).Put("sq", ((V)(0.1))).Put("lift", ((V)(0D))).Put("pitch", ((V)((-0.02)))).V, ((V)("i"))), "to", ((V)(100D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_478, "to", ((V)(200D)), NewObj(11).Put("wide", ((V)(0D))).Put("ly", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.9))).Put("open", ((V)(0.35))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D)));
a_481 = Get(t_478, "t");
Invoke(t_478, "osc", ((V)(1500D)), ((V)(3D)), NewObj(4).Put("tilt", ((V)(6D))).Put("x", ((V)(1.6))).Put("bend", ((V)(3D))).Put("htilt", ((V)((-3D)))).V, NewObj(4).Put("tilt", ((V)((-6D)))).Put("x", ((V)((-1.6)))).Put("bend", ((V)((-3D)))).Put("htilt", ((V)(3D))).V, ((V)("io")));
b_482 = Get(t_478, "t");
Invoke(Invoke(Invoke(t_478, "at", ((V)((ToNum(a_481) - 300D)))), "osc", ((V)(1800D)), ((V)(6D)), NewObj(1).Put("wag", ((V)(32D))).V, NewObj(1).Put("wag", ((V)((-32D)))).V, ((V)("io"))), "at", b_482);
Invoke(Invoke(t_478, "to", ((V)(350D)), NewObj(12).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0.5))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("wag", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
return Invoke(t_478, "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Biscuit Bot")), ((V)("Robot head ticks, pop-lock arms and a stiff march while his floppy ears and tail keep swinging; powers down, reboots, and breaks into a happy puppy wiggle.")))).Put("happy", Arr(Call(Fn((V _self1, int _argc498, V _a500, V _a501, V _a502, V _a503, V[] _rest499) => {
V t_504 = default;
V a_505 = default;
V b_506 = default;
t_504 = Call(TL_12, V.Undef, NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("tongue", ((V)(0.75))).V);
Call(jump_18, V.Undef, t_504, NewObj(5).Put("h", ((V)(9D))).Put("ant", ((V)(150D))).Put("up", ((V)(220D))).Put("c", ((V)(0.16))).Put("arm", ((V)(30D))).V);
a_505 = Get(t_504, "t");
Invoke(Invoke(t_504, "osc", ((V)(900D)), ((V)(2D)), NewObj(4).Put("tilt", ((V)(7D))).Put("x", ((V)(2D))).Put("bend", ((V)(3D))).Put("htilt", ((V)((-3D)))).V, NewObj(4).Put("tilt", ((V)((-7D)))).Put("x", ((V)((-2D)))).Put("bend", ((V)((-3D)))).Put("htilt", ((V)(3D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(4).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
b_506 = Get(t_504, "t");
Invoke(t_504, "at", ((V)(0D)));
Call(swing_20, V.Undef, t_504, b_506, ((V)(15D)), NewObj(1).Put("wag", ((V)(34D))).V);
Invoke(Invoke(t_504, "at", b_506), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return Object_assign(Invoke(t_504, "loop"), NewObj(1).Put("dur", ((V)((ToNum(b_506) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Tongue out, a bouncy hop, then a whole-body wiggle with his tail going non-stop.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc507, V _a509, V _a510, V _a511, V _a512, V[] _rest508) => {
V t_513 = default;
V a_514 = default;
t_513 = Call(TL_12, V.Undef);
Invoke(Invoke(t_513, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(6).Put("sq", ((V)(0.1))).Put("wide", ((V)(1D))).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).V, ((V)("o")));
Call(jump_18, V.Undef, t_513, NewObj(8).Put("h", ((V)(7D))).Put("ant", ((V)(60D))).Put("up", ((V)(200D))).Put("c", ((V)(0.08))).Put("arm", ((V)(34D))).Put("x", ((V)((-6D)))).Put("air", NewObj(1).Put("lean", ((V)((-3D)))).V).Put("fall", NewObj(1).Put("lean", ((V)((-1D)))).V).V);
Invoke(Invoke(Invoke(t_513, "wait", ((V)(250D))), "e", ((V)("blink"))), "to", ((V)(500D)), NewObj(5).Put("lx", ((V)(0.3))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).Put("open", ((V)(0.15))).Put("mw", ((V)(0.85))).V, ((V)("io")));
Invoke(Invoke(t_513, "to", ((V)(420D)), NewObj(5).Put("htilt", ((V)(15D))).Put("pitch", ((V)(0.05))).Put("earL", ((V)(3D))).Put("earR", ((V)((-5D)))).Put("ly", ((V)((-0.1)))).V, ((V)("io"))), "wait", ((V)(500D)));
Invoke(Invoke(t_513, "to", ((V)(480D)), NewObj(4).Put("htilt", ((V)((-14D)))).Put("earL", ((V)((-5D)))).Put("earR", ((V)(3D))).Put("lx", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(420D)));
Invoke(Invoke(t_513, "e", ((V)("blink"))), "to", ((V)(380D)), NewObj(10).Put("htilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0.35))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.7))).V, ((V)("io")));
a_514 = Get(t_513, "t");
Invoke(t_513, "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("io")));
Invoke(Invoke(t_513, "at", a_514), "to", ((V)(1200D)), NewObj(2).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_513, "rest", ((V)(450D))), "done", NewObj(1).Put("stretch", ((V)(0.5))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Ears jump up and he hops back, then does the puppy head tilt one way and the other, decides it is fine and wags.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc515, V _a517, V _a518, V _a519, V _a520, V[] _rest516) => {
V t_521 = default;
t_521 = Call(TL_12, V.Undef);
Call(look_21, V.Undef, t_521, ((V)(0D)), ((V)(0.8)), NewObj(1).Put("k", ((V)(1.2))).V);
Invoke(t_521, "wait", ((V)(150D)));
Invoke(Invoke(t_521, "to", ((V)(140D)), NewObj(2).Put("sq", ((V)(0.1))).Put("wide", ((V)(0.6))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("dust")), ((V)("footL")), ((V)(2D)));
Invoke(Invoke(t_521, "to", ((V)(900D)), NewObj(10).Put("spin", ((V)(360D))).Put("lean", ((V)(3D))).Put("tilt", ((V)(6D))).Put("hyaw", ((V)(0.4))).Put("twist", ((V)(0.2))).Put("bend", ((V)(2D))).Put("x", ((V)(1.5))).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.35))).Put("sq", ((V)((-0.02)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(t_521, "to", ((V)(220D)), NewObj(9).Put("hyaw", ((V)(0D))).Put("twist", ((V)(0D))).Put("bend", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("sq", ((V)(0.06))).Put("cross", ((V)(0.8))).Put("wide", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_521, "osc", ((V)(900D)), ((V)(2D)), NewObj(2).Put("htilt", ((V)(8D))).Put("lean", ((V)(1.2))).V, NewObj(2).Put("htilt", ((V)((-8D)))).Put("lean", ((V)((-1.2)))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(6).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("cross", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("blink2")));
return Invoke(Invoke(Invoke(t_521, "wait", ((V)(300D))), "rest", ((V)(420D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Chases his tail")), ((V)("Spots his tail, spins round after it, gets dizzy (crossed eyes, wobbly head) and pants happily.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc522, V _a524, V _a525, V _a526, V _a527, V[] _rest523) => {
V t_528 = default;
V a_529 = default;
t_528 = Call(TL_12, V.Undef);
Invoke(Invoke(t_528, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(330D)), NewObj(8).Put("sq", ((V)(0.38))).Put("hap", ((V)(0.9))).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.3))).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("earL", ((V)(5D))).Put("earR", ((V)(5D))).V, ((V)("io")));
a_529 = Get(t_528, "t");
Invoke(t_528, "wait", ((V)(420D)));
Invoke(Invoke(Invoke(t_528, "at", ((V)((ToNum(a_529) - 200D)))), "osc", ((V)(640D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(30D))).V, NewObj(1).Put("wag", ((V)((-30D)))).V, ((V)("io"))), "at", Add(a_529, ((V)(420D))));
Invoke(Invoke(Invoke(Invoke(t_528, "to", ((V)(130D)), NewObj(8).Put("sq", ((V)((-0.18)))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.45))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.08))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)((-0.03)))).Put("tongue", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(180D)), NewObj(9).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("smile", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_528, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_528, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed flat with his tongue out and tail wagging, springs back with a big ear flop.")))).Put("press", NewObj(2).Put("tongue", ((V)(0.75))).Put("open", ((V)(0.25))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(7).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(3.5)), ((V)("o"))), Arr(((V)(280D)), ((V)(0D)), ((V)("i"))))).Put("earL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)((-14D))), ((V)("o"))), Arr(((V)(320D)), ((V)(10D)), ((V)("io"))), Arr(((V)(520D)), ((V)((-4D))), ((V)("io"))), Arr(((V)(720D)), ((V)(0D)), ((V)("io"))))).Put("earR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)((-14D))), ((V)("o"))), Arr(((V)(320D)), ((V)(10D)), ((V)("io"))), Arr(((V)(520D)), ((V)((-4D))), ((V)("io"))), Arr(((V)(720D)), ((V)(0D)), ((V)("io"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(130D)), ((V)(30D))), Arr(((V)(260D)), ((V)((-30D)))), Arr(((V)(390D)), ((V)(30D))), Arr(((V)(520D)), ((V)((-30D)))), Arr(((V)(650D)), ((V)(20D))), Arr(((V)(800D)), ((V)(0D))))).Put("tongue", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(700D)), ((V)(0.6))), Arr(((V)(1000D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("heart")), ((V)("head")), ((V)(1D))))).V).V);
Set(MOVES_29, "truffle", NewObj(7).Put("dance", Arr(Call(Fn((V _self1, int _argc530, V _a532, V _a533, V _a534, V _a535, V[] _rest531) => {
V t_536 = default;
double B_537 = 0;
V a_538 = default;
t_536 = Call(TL_12, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_537 = 500D;
Invoke(t_536, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
a_538 = Get(t_536, "t");
Call(swing_20, V.Undef, t_536, ((V)((4D * B_537))), ((V)(7D)), NewObj(5).Put("tilt", ((V)(5D))).Put("x", ((V)(1.4))).Put("bend", ((V)(2.5))).Put("wag", ((V)(18D))).Put("htilt", ((V)((-2.5)))).V);
Invoke(Invoke(t_536, "at", a_538), "osc", ((V)((4D * B_537))), ((V)(4D)), NewObj(2).Put("pitch", ((V)((-0.14)))).Put("sq", ((V)(0.06))).V, NewObj(2).Put("pitch", ((V)(0.05))).Put("sq", ((V)((-0.02)))).V, ((V)("io")));
Invoke(t_536, "to", ((V)(200D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(9D)), ((V)(1D))), NewObj(3).Put("pitch", ((V)(0D))).Put("hap", ((V)(0D))).Put("sq", ((V)(0D))).V), ((V)("io")));
{
double i_539 = 0;
i_539 = 0D;
while (true) {
if (!((i_539 < 3D))) break;
double d_541 = 0;
d_541 = (NumTruthy((i_539 % 2D)) ? 1D : (-1D));
Invoke(Invoke(Invoke(t_536, "to", ((V)(140D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(d_541)), ((V)(9D)), ((V)((-1D)))), Call(hand_14, V.Undef, ((V)((-d_541))), ((V)(9D)), ((V)(2D))), NewObj(2).Put("sq", ((V)(0.15))).Put("lift", ((V)(0D))).V), ((V)("i"))), "to", ((V)(170D)), NewObj(2).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2.5))).V, ((V)("o"))), "to", ((V)(190D)), NewObj(2).Put("sq", ((V)(0.02))).Put("lift", ((V)(0D))).V, ((V)("i")));
i_539++;
}
}
Invoke(Invoke(Invoke(t_536, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), Call(o_16, V.Undef, NOHANDS_17, NewObj(4).Put("open", ((V)(0.6))).Put("mw", ((V)(0.8))).Put("pitch", ((V)(0.2))).Put("sq", ((V)((-0.04)))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
a_538 = Get(t_536, "t");
Invoke(Invoke(Invoke(Invoke(t_536, "to", ((V)(500D)), NewObj(2).Put("spin", ((V)(180D))).Put("hap", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(1000D))), "to", ((V)(500D)), NewObj(2).Put("spin", ((V)(360D))).Put("hap", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(t_536, "at", a_538);
Call(steps_19, V.Undef, t_536, ((V)(500D)), ((V)(2D)), ((V)(2.5)));
Call(swing_20, V.Undef, t_536, ((V)(1000D)), ((V)(4D)), NewObj(4).Put("tilt", ((V)(6D))).Put("x", ((V)(1.6))).Put("wag", ((V)(26D))).Put("curl", ((V)(0.4))).V);
Call(steps_19, V.Undef, t_536, ((V)(500D)), ((V)(2D)), ((V)(2.5)));
Invoke(t_536, "at", Add(a_538, ((V)(2001D))));
Invoke(t_536, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_542 = 0;
i_542 = 0D;
while (true) {
if (!((i_542 < 4D))) break;
double d_544 = 0;
V k_545 = default;
d_544 = (NumTruthy((i_542 % 2D)) ? 1D : (-1D));
k_545 = Call(S_13, V.Undef, ((V)(d_544)));
Invoke(Invoke(Invoke(Invoke(t_536, "to", ((V)(200D)), NewObj(5).Put("bend", ((V)(((-d_544) * 3.5)))).Put("x", ((V)(((-d_544) * 1.2)))).Put("htilt", ((V)((d_544 * 2D)))).PutK(Get(k_545, "foot"), ((V)(4D))).Put("sq", ((V)((-0.02)))).V, ((V)("o"))), "to", ((V)(120D)), NewObj(3).PutK(Get(k_545, "foot"), ((V)(0D))).Put("sq", ((V)(0.1))).Put("bend", ((V)(((-d_544) * 1.5)))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), Get(k_545, "foot"), ((V)(3D))), "to", ((V)(180D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
i_542++;
}
}
Invoke(t_536, "to", ((V)(200D)), NewObj(3).Put("bend", ((V)(0D))).Put("x", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
Call(jump_18, V.Undef, t_536, NewObj(9).Put("h", ((V)(9D))).Put("ant", ((V)(220D))).Put("up", ((V)(280D))).Put("c", ((V)(0.22))).Put("arm", ((V)(45D))).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(3).Put("open", ((V)(0.55))).Put("mw", ((V)(0.8))).Put("hap", ((V)(1D))).V).Put("fall", NewObj(1).Put("open", ((V)(0.2))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(4D))), Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))))).V);
Invoke(Call(land_24, V.Undef, t_536, ((V)(0.1)), ((V)(3D)), ((V)(260D))), "to", ((V)(160D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
return Invoke(t_536, "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Piggy Wiggle")), ((V)("Butt wiggle with snout bops, belly bounces with belly pats, an oink, turns round to wiggle his curly tail at you, mud stomps, and a big happy oink hop.")))).Put("happy", Arr(Call(Fn((V _self1, int _argc546, V _a548, V _a549, V _a550, V _a551, V[] _rest547) => {
V t_552 = default;
V L_553 = default;
t_552 = Call(TL_12, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(jump_18, V.Undef, t_552, NewObj(6).Put("h", ((V)(7D))).Put("ant", ((V)(200D))).Put("up", ((V)(240D))).Put("c", ((V)(0.2))).Put("arm", ((V)(36D))).Put("chain", (true ? V.True : V.False)).V);
Call(land_24, V.Undef, t_552, ((V)(0.08)), ((V)(2D)), ((V)(240D)));
Call(jump_18, V.Undef, t_552, NewObj(9).Put("h", ((V)(8D))).Put("ant", ((V)(180D))).Put("up", ((V)(250D))).Put("c", ((V)(0.22))).Put("arm", ((V)(44D))).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("curl", ((V)(0.6))).V).Put("fall", NewObj(1).Put("curl", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))))).V);
Call(land_24, V.Undef, t_552, ((V)(0.09)), ((V)(3D)), ((V)(240D)));
L_553 = Get(t_552, "t");
Invoke(t_552, "at", ((V)(0D)));
Call(swing_20, V.Undef, t_552, L_553, ((V)(11D)), NewObj(1).Put("wag", ((V)(20D))).V);
Invoke(t_552, "at", L_553);
return Object_assign(Invoke(t_552, "loop"), NewObj(1).Put("dur", ((V)((ToNum(L_553) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Two heavy happy hops, his round body jiggling after each landing, curly tail spinning, hearts.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc554, V _a556, V _a557, V _a558, V _a559, V[] _rest555) => {
V t_560 = default;
V a_561 = default;
t_560 = Call(TL_12, V.Undef);
Invoke(Invoke(t_560, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(5).Put("sq", ((V)(0.12))).Put("wide", ((V)(1D))).Put("earL", ((V)((-12D)))).Put("earR", ((V)((-12D)))).Put("open", ((V)(0.4))).V, ((V)("o")));
Call(jump_18, V.Undef, t_560, NewObj(9).Put("h", ((V)(6D))).Put("ant", ((V)(60D))).Put("up", ((V)(210D))).Put("c", ((V)(0.1))).Put("arm", ((V)(30D))).Put("x", ((V)((-5D)))).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("lean", ((V)((-2.5)))).V).Put("fall", NewObj(1).Put("lean", ((V)((-1D)))).V).V);
Call(land_24, V.Undef, t_560, ((V)(0.08)), ((V)(2D)), ((V)(220D)));
Invoke(t_560, "osc", ((V)(360D)), ((V)(2D)), NewObj(3).Put("sq", ((V)(0.05))).Put("pitch", ((V)(0.1))).Put("mw", ((V)(0.8))).V, NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o")));
Invoke(t_560, "to", ((V)(420D)), NewObj(6).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("open", ((V)(0D))).Put("wide", ((V)(0.4))).Put("pitch", ((V)((-0.18)))).Put("ly", ((V)(0.4))).V, ((V)("io")));
a_561 = Get(t_560, "t");
Invoke(t_560, "osc", ((V)(1200D)), ((V)(5D)), NewObj(2).Put("sq", ((V)(0.02))).Put("pitch", ((V)((-0.22)))).V, NewObj(2).Put("sq", ((V)(0D))).Put("pitch", ((V)((-0.16)))).V, ((V)("io")));
Invoke(Invoke(t_560, "at", a_561), "to", ((V)(1200D)), NewObj(2).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_560, "to", ((V)(300D)), NewObj(5).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(300D)));
return Invoke(Invoke(t_560, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Ears up, a heavy little hop back that wobbles his belly, two snorts, then sniffs his way back nose-first.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc562, V _a564, V _a565, V _a566, V _a567, V[] _rest563) => {
V t_568 = default;
V a_569 = default;
V b_570 = default;
t_568 = Call(TL_12, V.Undef);
Invoke(t_568, "to", ((V)(380D)), NewObj(3).Put("pitch", ((V)((-0.34)))).Put("ly", ((V)(0.8))).Put("sq", ((V)(0.04))).V, ((V)("io")));
a_569 = Get(t_568, "t");
Invoke(Invoke(Invoke(t_568, "to", ((V)(700D)), NewObj(4).Put("hyaw", ((V)((-0.48)))).Put("x", ((V)((-2.2)))).Put("bend", ((V)((-2.5)))).Put("twist", ((V)((-0.12)))).V, ((V)("io"))), "to", ((V)(900D)), NewObj(4).Put("hyaw", ((V)(0.45))).Put("x", ((V)(2.2))).Put("bend", ((V)(2.5))).Put("twist", ((V)(0.12))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(4).Put("hyaw", ((V)(0.05))).Put("x", ((V)(0.4))).Put("bend", ((V)(0D))).Put("twist", ((V)(0D))).V, ((V)("io")));
b_570 = Get(t_568, "t");
Invoke(Invoke(Invoke(t_568, "at", a_569), "osc", ((V)((ToNum(b_570) - ToNum(a_569)))), ((V)(10D)), NewObj(3).Put("sq", ((V)(0.055))).Put("pitch", ((V)((-0.4)))).Put("mw", ((V)(0.85))).V, NewObj(3).Put("sq", ((V)(0.015))).Put("pitch", ((V)((-0.3)))).Put("mw", ((V)(1D))).V, ((V)("o"))), "at", b_570);
Invoke(Invoke(Invoke(t_568, "to", ((V)(200D)), NewObj(8).Put("pitch", ((V)(0.1))).Put("ly", ((V)(0D))).Put("sq", ((V)((-0.04)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("hyaw", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "osc", ((V)(500D)), ((V)(2D)), NewObj(2).Put("wag", ((V)(22D))).Put("curl", ((V)(0.4))).V, NewObj(2).Put("wag", ((V)((-22D)))).Put("curl", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_568, "wait", ((V)(250D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sniff sniff")), ((V)("Puts his snout to the ground and follows a scent left and right, then a happy snort.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc571, V _a573, V _a574, V _a575, V _a576, V[] _rest572) => {
V t_577 = default;
t_577 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_577, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(340D)), NewObj(7).Put("sq", ((V)(0.42))).Put("hap", ((V)(0.9))).Put("puff", ((V)(0.4))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(t_577, "to", ((V)(120D)), NewObj(10).Put("sq", ((V)((-0.2)))).Put("puff", ((V)(0D))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.8))).V, ((V)("o")));
Call(jelly_23, V.Undef, t_577, ((V)(0.14)), ((V)(4D)), ((V)(230D)));
Invoke(t_577, "to", ((V)(160D)), NewObj(7).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
return Object_assign(Invoke(t_577, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_577, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed into a round piggy pancake, then his whole body jiggles like jelly with an oink.")))).Put("press", NewObj(1).Put("puff", ((V)(0.35))).V).Put("rel", NewObj(3).Put("dur", ((V)(1300D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(230D)), ((V)(0.13)), ((V)("io"))), Arr(((V)(350D)), ((V)((-0.08))), ((V)("io"))), Arr(((V)(470D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(590D)), ((V)((-0.025))), ((V)("io"))), Arr(((V)(720D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.5)), ((V)("o"))), Arr(((V)(450D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(900D)), ((V)(1D))), Arr(((V)(1300D)), ((V)(0D)), ((V)("io"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(20D))), Arr(((V)(300D)), ((V)((-20D)))), Arr(((V)(450D)), ((V)(16D))), Arr(((V)(600D)), ((V)((-10D)))), Arr(((V)(750D)), ((V)(0D))))).V).Put("em", Arr(Arr(((V)("note")), ((V)("head")), ((V)(1D))))).V).V);
Set(MOVES_29, "nibbles", NewObj(7).Put("dance", Arr(Call(Fn((V _self1, int _argc578, V _a580, V _a581, V _a582, V _a583, V[] _rest579) => {
V P_584 = default;
V t_585 = default;
double B_586 = 0;
V a_587 = default;
V b_588 = default;
P_584 = Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D))));
t_585 = Call(TL_12, V.Undef, Call(o_16, V.Undef, P_584, NewObj(1).Put("smile", ((V)(0.7))).V));
B_586 = 500D;
Invoke(t_585, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_589 = 0;
i_589 = 0D;
while (true) {
if (!((i_589 < 4D))) break;
double d_591 = 0;
d_591 = (NumTruthy((i_589 % 2D)) ? 1D : (-1D));
Invoke(Invoke(Invoke(t_585, "to", ((V)(110D)), NewObj(4).Put("puff", ((V)(1D))).Put("sq", ((V)(0.05))).Put("htilt", ((V)((d_591 * 5D)))).PutK(Get(Call(S_13, V.Undef, ((V)(d_591))), "foot"), ((V)(2D))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(2).Put("sq", ((V)(0D))).PutK(Get(Call(S_13, V.Undef, ((V)(d_591))), "foot"), ((V)(0D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("puff", ((V)(0.15))).Put("htilt", ((V)((d_591 * 2D)))).V, ((V)("io")));
i_589++;
}
}
Invoke(t_585, "to", ((V)(150D)), NewObj(5).Put("htilt", ((V)(0D))).Put("puff", ((V)(0D))).Put("pitch", ((V)((-0.2)))).Put("lean", ((V)(0.8))).Put("wide", ((V)(0.3))).V, ((V)("io")));
a_587 = Get(t_585, "t");
Call(steps_19, V.Undef, t_585, ((V)(((4D * B_586) - 150D))), ((V)(14D)), ((V)(5.5)));
Invoke(Invoke(t_585, "at", a_587), "osc", ((V)(((4D * B_586) - 150D))), ((V)(7D)), NewObj(4).Put("armL", ((V)(48D))).Put("armR", ((V)((-10D)))).Put("x", ((V)(0.7))).Put("tilt", ((V)(2D))).V, NewObj(4).Put("armL", ((V)((-10D)))).Put("armR", ((V)(48D))).Put("x", ((V)((-0.7)))).Put("tilt", ((V)((-2D)))).V, ((V)("io")));
Invoke(Invoke(t_585, "at", a_587), "osc", ((V)(((4D * B_586) - 150D))), ((V)(14D)), NewObj(2).Put("lift", ((V)(1.6))).Put("sq", ((V)((-0.03)))).V, NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_585, "at", a_587), "em", ((V)(((4D * B_586) - 300D))), ((V)(220D)), ((V)("dust")), ((V)("footL")), ((V)(1D))), "at", ((V)((ToNum(Add(a_587, ((V)((4D * B_586))))) - 150D))));
Invoke(Invoke(t_585, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(150D)), NewObj(11).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("pitch", ((V)(0D))).Put("lean", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
{
double i_592 = 0;
i_592 = 0D;
while (true) {
if (!((i_592 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(t_585, "to", ((V)(150D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(11D)), ((V)((-14D)))), NewObj(2).Put("pitch", ((V)((-0.06)))).Put("sq", ((V)(0.03))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D))), "to", ((V)(110D)), Call(o_16, V.Undef, P_584, NewObj(2).Put("puff", ((V)((0.35 + (i_592 * 0.32))))).Put("sq", ((V)(0D))).V), ((V)("o"))), "osc", ((V)(240D)), ((V)(2D)), NewObj(1).Put("open", ((V)(0.12))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("io")));
i_592++;
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_585, "to", ((V)(110D)), NewObj(3).Put("sq", ((V)(0.08))).Put("wide", ((V)(0.8))).Put("puff", ((V)(1.2))).V, ((V)("io"))), "to", ((V)(70D)), NewObj(4).Put("puff", ((V)(0D))).Put("sq", ((V)((-0.1)))).Put("open", ((V)(0.5))).Put("lift", ((V)(3D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth")), ((V)(3D))), "to", ((V)(180D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).Put("open", ((V)(0D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
a_587 = Get(t_585, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_585, "to", ((V)(560D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "at", a_587), "to", ((V)(260D)), NewObj(2).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_585, "at", Add(a_587, ((V)(710D))));
Call(jump_18, V.Undef, t_585, NewObj(6).Put("h", ((V)(6D))).Put("ant", ((V)(110D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(20D))).Put("chain", (true ? V.True : V.False)).V);
Call(jump_18, V.Undef, t_585, NewObj(5).Put("h", ((V)(6D))).Put("ant", ((V)(100D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(20D))).V);
Invoke(Invoke(t_585, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), Call(o_16, V.Undef, NOHANDS_17, NewObj(4).Put("armL", ((V)(140D))).Put("armR", ((V)(140D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("o")));
a_587 = Get(t_585, "t");
Invoke(t_585, "osc", ((V)(1200D)), ((V)(4D)), NewObj(4).Put("armL", ((V)(120D))).Put("armR", ((V)(155D))).Put("turn", ((V)(0.15))).Put("htilt", ((V)(3D))).V, NewObj(4).Put("armL", ((V)(155D))).Put("armR", ((V)(120D))).Put("turn", ((V)((-0.15)))).Put("htilt", ((V)((-3D)))).V, ((V)("io")));
b_588 = Get(t_585, "t");
Invoke(Invoke(Invoke(t_585, "at", a_587), "osc", ((V)(1200D)), ((V)(8D)), NewObj(2).Put("sq", ((V)(0.02))).Put("pitch", ((V)(0.04))).V, NewObj(2).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("o"))), "at", b_588);
Invoke(t_585, "to", ((V)(Max(150D, ((20D * B_586) - ToNum(b_588))))), Call(o_16, V.Undef, P_584, NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("turn", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0.7))).V), ((V)("io")));
return Invoke(t_585, "loop", NewObj(1).Put("stretch", ((V)(0.5))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Cheek Wiggle")), ((V)("Cheek puffs on the beat, a hamster-wheel run, stuffs three seeds into his cheeks and pops them out, a quick spin, two tiny hops, paws-up wiggle.")))).Put("happy", Arr(Call(Fn((V _self1, int _argc594, V _a596, V _a597, V _a598, V _a599, V[] _rest595) => {
V t_600 = default;
t_600 = Call(TL_12, V.Undef, Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D)))), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V));
Call(jump_18, V.Undef, t_600, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(110D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(18D))).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("puff", ((V)(0.8))).V).Put("fall", NewObj(1).Put("puff", ((V)(0.2))).V).V);
Call(jump_18, V.Undef, t_600, NewObj(8).Put("h", ((V)(7D))).Put("ant", ((V)(100D))).Put("up", ((V)(170D))).Put("c", ((V)(0.12))).Put("arm", ((V)(18D))).Put("air", NewObj(1).Put("puff", ((V)(0.9))).V).Put("fall", NewObj(1).Put("puff", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))))).V);
Invoke(t_600, "osc", ((V)(500D)), ((V)(4D)), NewObj(2).Put("pitch", ((V)(0.05))).Put("sq", ((V)(0.02))).V, NewObj(2).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("o")));
return Object_assign(Invoke(t_600, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_600, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Two quick tiny hops with his cheeks puffing, paws clasped, a nose twitch.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc601, V _a603, V _a604, V _a605, V _a606, V[] _rest602) => {
V t_607 = default;
t_607 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_607, "wait", ((V)(120D))), "to", ((V)(70D)), NewObj(5).Put("sq", ((V)(0.1))).Put("wide", ((V)(1D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i")));
Invoke(Invoke(t_607, "to", ((V)(90D)), NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(900D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_607, "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(320D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(320D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(150D)));
Invoke(Invoke(t_607, "e", ((V)("blink"))), "to", ((V)(150D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(11D)), ((V)((-14D)))), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V), ((V)("io")));
Invoke(Invoke(t_607, "osc", ((V)(600D)), ((V)(4D)), NewObj(2).Put("puff", ((V)(0.7))).Put("sq", ((V)(0.02))).V, NewObj(2).Put("puff", ((V)(0.5))).Put("sq", ((V)(0D))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D)))), NewObj(1).Put("wide", ((V)(0.2))).V), ((V)("io")));
return Invoke(Invoke(Invoke(t_607, "wait", ((V)(300D))), "rest", ((V)(500D))), "done", NewObj(1).Put("noBlink", (true ? V.True : V.False)).V);
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("A tiny jump, then the hamster freeze - completely still, only his eyes dart left and right - and some nervous cheek stuffing.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc608, V _a610, V _a611, V _a612, V _a613, V[] _rest609) => {
V t_614 = default;
t_614 = Call(TL_12, V.Undef);
Invoke(Invoke(t_614, "to", ((V)(360D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(9D)), ((V)(6D))), NewObj(4).Put("pitch", ((V)((-0.24)))).Put("ly", ((V)(0.6))).Put("sq", ((V)(0.04))).Put("lean", ((V)(0.5))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("pawL")), ((V)(1D)));
Invoke(Invoke(Invoke(t_614, "to", ((V)(320D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(11D)), ((V)((-14D)))), NewObj(4).Put("pitch", ((V)((-0.04)))).Put("ly", ((V)(0D))).Put("sq", ((V)(0D))).Put("lean", ((V)(0D))).V), ((V)("io"))), "osc", ((V)(420D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.14))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(1).Put("puff", ((V)(0.75))).V, ((V)("o")));
Invoke(Invoke(t_614, "to", ((V)(260D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(2D)), ((V)((-19D)))), NewObj(1).Put("htilt", ((V)(3D))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(3).Put("hLy", ((V)((-21D)))).Put("hRy", ((V)((-17D)))).Put("puff", ((V)(0.85))).V, NewObj(3).Put("hLy", ((V)((-17D)))).Put("hRy", ((V)((-21D)))).Put("puff", ((V)(0.7))).V, ((V)("io")));
Invoke(Invoke(t_614, "to", ((V)(220D)), Call(o_16, V.Undef, NOHANDS_17, NewObj(3).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(400D)), ((V)(4D)), NewObj(2).Put("pitch", ((V)(0.05))).Put("sq", ((V)(0.015))).V, NewObj(2).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("o")));
return Invoke(Invoke(Invoke(t_614, "wait", ((V)(250D))), "rest", ((V)(500D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Cheek stash")), ((V)("Picks a seed off the floor, stuffs it in his cheek, pats his full cheeks, nose twitch.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc615, V _a617, V _a618, V _a619, V _a620, V[] _rest616) => {
V t_621 = default;
t_621 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_621, "to", ((V)(130D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0.36))).Put("puff", ((V)(1.1))).Put("sqz", ((V)(0.8))).Put("armL", ((V)(16D))).Put("armR", ((V)(16D))).V, ((V)("io"))), "wait", ((V)(420D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_621, "to", ((V)(80D)), NewObj(6).Put("sq", ((V)((-0.2)))).Put("puff", ((V)(0D))).Put("sqz", ((V)(0D))).Put("open", ((V)(0.45))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth")), ((V)(3D))), "to", ((V)(150D)), NewObj(2).Put("sq", ((V)(0.07))).Put("open", ((V)(0.1))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.02)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(4).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_621, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_621, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, his cheeks balloon out - let go and the seeds pop out.")))).Put("press", NewObj(2).Put("puff", ((V)(1D))).Put("sqz", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(900D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(220D)), ((V)(0.08)), ((V)("io"))), Arr(((V)(340D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(460D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(3D)), ((V)("o"))), Arr(((V)(240D)), ((V)(0D)), ((V)("i"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(0.45)), ((V)("o"))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).Put("puff", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)((-0.3))), ((V)("o"))), Arr(((V)(300D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("seed")), ((V)("mouth")), ((V)(3D))))).V).V);
Set(MOVES_29, "quill", NewObj(7).Put("dance", Arr(Call(Fn((V _self1, int _argc622, V _a624, V _a625, V _a626, V _a627, V[] _rest623) => {
V P_628 = default;
V t_629 = default;
double B_630 = 0;
V a_631 = default;
P_628 = Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D))));
t_629 = Call(TL_12, V.Undef, Call(o_16, V.Undef, P_628, NewObj(4).Put("pitch", ((V)((-0.08)))).Put("blush", ((V)(0.45))).Put("smile", ((V)(0.5))).Put("ly", ((V)(0.3))).V));
B_630 = 600D;
Invoke(t_629, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_632 = 0;
i_632 = 0D;
while (true) {
if (!((i_632 < 4D))) break;
double d_634 = 0;
V k_635 = default;
d_634 = (NumTruthy((i_632 % 2D)) ? 1D : (-1D));
k_635 = Call(S_13, V.Undef, ((V)(d_634)));
Invoke(Invoke(t_629, "to", ((V)((B_630 * 0.55))), NewObj(5).Put("x", ((V)((d_634 * 3.2)))).Put("bend", ((V)((d_634 * 3D)))).Put("htilt", ((V)(((-d_634) * 2D)))).PutK(Get(k_635, "foot"), ((V)(2D))).Put("ly", ((V)(((i_632 == 2D) ? 0D : 0.3)))).V, ((V)("io"))), "to", ((V)((B_630 * 0.45))), NewObj(2).PutK(Get(k_635, "foot"), ((V)(0D))).Put("bend", ((V)((d_634 * 1.2)))).V, ((V)("io")));
i_632++;
}
}
Invoke(Invoke(t_629, "to", ((V)(400D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-27D)))), NewObj(5).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)((-0.1)))).V), ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(t_629, "to", ((V)(260D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-1D))), ((V)((-19D)))), NewObj(2).Put("lx", ((V)(0.4))).Put("htilt", ((V)(4D))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(2).Put("sq", ((V)(0.025))).Put("htilt", ((V)(6D))).V, NewObj(2).Put("sq", ((V)(0D))).Put("htilt", ((V)(3D))).V, ((V)("io"))), "to", ((V)(240D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-27D)))), NewObj(3).Put("lx", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(160D)));
Invoke(Invoke(Invoke(t_629, "to", ((V)(140D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)((-2D))), ((V)((-18D)))), NewObj(8).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.45))).Put("blush", ((V)(0.9))).Put("pitch", ((V)(0.05))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2D))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.04))).Put("lift", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), Call(o_16, V.Undef, P_628, NewObj(7).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("pitch", ((V)((-0.08)))).Put("blush", ((V)(0.6))).Put("ly", ((V)(0.3))).V), ((V)("io")));
Invoke(t_629, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_636 = 0;
i_636 = 0D;
while (true) {
if (!((i_636 < 4D))) break;
double d_638 = 0;
V k_639 = default;
d_638 = (NumTruthy((i_636 % 2D)) ? 1D : (-1D));
k_639 = Call(S_13, V.Undef, ((V)(d_638)));
Invoke(Invoke(t_629, "to", ((V)((B_630 * 0.5))), Call(o_16, V.Undef, NOHANDS_17, NewObj(10).Put("x", ((V)((d_638 * 3.4)))).Put("bend", ((V)((d_638 * 3.5)))).Put("htilt", ((V)(((-d_638) * 2D)))).PutK(Get(k_639, "foot"), ((V)(2.2))).Put("armL", ((V)(((d_638 < 0D) ? 34D : 6D)))).Put("armR", ((V)(((d_638 > 0D) ? 34D : 6D)))).Put("ly", ((V)(0D))).Put("pitch", ((V)((-0.14)))).Put("sq", ((V)(0.03))).Put("smile", ((V)(0.9))).V), ((V)("io"))), "to", ((V)((B_630 * 0.5))), NewObj(3).PutK(Get(k_639, "foot"), ((V)(0D))).Put("pitch", ((V)((-0.02)))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_636++;
}
}
Invoke(t_629, "to", ((V)(380D)), NewObj(10).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).Put("sq", ((V)(0.16))).Put("pitch", ((V)((-0.6)))).Put("close", ((V)(1D))).Put("smile", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
a_631 = Get(t_629, "t");
Invoke(Invoke(t_629, "to", ((V)(1150D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_629, "at", a_631), "osc", ((V)(1150D)), ((V)(2D)), NewObj(1).Put("lift", ((V)(1.5))).V, NewObj(1).Put("lift", ((V)(0D))).V, ((V)("io"))), "at", Add(a_631, ((V)(1151D))));
Invoke(Invoke(Invoke(Invoke(t_629, "to", ((V)(160D)), NewObj(9).Put("sq", ((V)((-0.12)))).Put("pitch", ((V)(0.08))).Put("close", ((V)(0D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("lift", ((V)(5D))).Put("wide", ((V)(0.4))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(220D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("pitch", ((V)(0D))).V, ((V)("i"))), "to", ((V)(190D)), NewObj(4).Put("sq", ((V)(0D))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("wide", ((V)(0D))).V, ((V)("io")));
a_631 = Get(t_629, "t");
Invoke(Invoke(t_629, "to", ((V)(300D)), NewObj(5).Put("armR", ((V)(112D))).Put("hRy", ((V)((-3D)))).Put("htilt", ((V)(4D))).Put("blush", ((V)(1D))).Put("open", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("armR", ((V)(100D))).V, NewObj(1).Put("armR", ((V)(124D))).V, ((V)("io")));
Invoke(t_629, "to", ((V)(Max(200D, ((20D * B_630) - ToNum(Get(t_629, "t")))))), Call(o_16, V.Undef, P_628, NewObj(7).Put("armR", ((V)(0D))).Put("armL", ((V)(0D))).Put("htilt", ((V)(0D))).Put("blush", ((V)(0.45))).Put("smile", ((V)(0.5))).Put("ly", ((V)(0.3))).Put("pitch", ((V)((-0.08)))).V), ((V)("io")));
return Invoke(t_629, "loop", NewObj(2).Put("stretch", ((V)(0.4))).Put("soft", ((V)(0.8))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Spike Shuffle")), ((V)("A shy side shuffle with paws clasped, peek-a-boo behind his paws, a braver shuffle, curls into a spiky ball and rolls round, pops open, tiny shy wave.")))).Put("happy", Arr(Call(Fn((V _self1, int _argc640, V _a642, V _a643, V _a644, V _a645, V[] _rest641) => {
V t_646 = default;
t_646 = Call(TL_12, V.Undef, Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D)))), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(0.9))).Put("blush", ((V)(0.8))).V));
Call(swing_20, V.Undef, t_646, ((V)(1600D)), ((V)(3D)), NewObj(4).Put("x", ((V)(1.8))).Put("bend", ((V)(2.5))).Put("tilt", ((V)(2D))).Put("htilt", ((V)((-2D)))).V);
Call(jump_18, V.Undef, t_646, NewObj(5).Put("h", ((V)(5D))).Put("ant", ((V)(200D))).Put("up", ((V)(220D))).Put("c", ((V)(0.12))).Put("arm", ((V)(14D))).V);
Invoke(Invoke(t_646, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(200D)));
return Object_assign(Invoke(t_646, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_646, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Rocks shyly from side to side with happy closed eyes and pink cheeks, a small hop, a heart.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc647, V _a649, V _a650, V _a651, V _a652, V[] _rest648) => {
V t_653 = default;
t_653 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_653, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(240D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(4D)), ((V)(2D))), NewObj(5).Put("sq", ((V)(0.17))).Put("pitch", ((V)((-0.6)))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V), ((V)("o")));
Invoke(Invoke(t_653, "osc", ((V)(900D)), ((V)(9D)), NewObj(1).Put("x", ((V)(0.45))).V, NewObj(1).Put("x", ((V)((-0.45)))).V, ((V)("l"))), "to", ((V)(60D)), NewObj(1).Put("x", ((V)(0D))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_653, "wait", ((V)(250D))), "to", ((V)(420D)), NewObj(6).Put("close", ((V)(0.55))).Put("sq", ((V)(0.14))).Put("pitch", ((V)((-0.46)))).Put("lx", ((V)(0.5))).Put("ly", ((V)((-0.2)))).Put("wide", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(260D)), NewObj(1).Put("lx", ((V)((-0.5)))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_653, "to", ((V)(700D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D)))), NewObj(9).Put("sq", ((V)(0D))).Put("pitch", ((V)((-0.08)))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wide", ((V)(0D))).Put("ly", ((V)(0.3))).Put("blush", ((V)(0.9))).Put("smile", ((V)(0.6))).V), ((V)("io"))), "wait", ((V)(500D)));
return Invoke(Invoke(t_653, "rest", ((V)(600D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Curls into a ball at once and trembles, peeks out, then slowly uncurls, blushing.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc654, V _a656, V _a657, V _a658, V _a659, V[] _rest655) => {
V t_660 = default;
t_660 = Call(TL_12, V.Undef);
Invoke(Invoke(t_660, "to", ((V)(380D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-27D)))), NewObj(2).Put("pitch", ((V)((-0.12)))).Put("blush", ((V)(0.6))).V), ((V)("io"))), "wait", ((V)(350D)));
Invoke(Invoke(Invoke(t_660, "to", ((V)(300D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)((-1D))), ((V)((-19D)))), NewObj(3).Put("hyaw", ((V)((-0.25)))).Put("lx", ((V)((-0.6)))).Put("htilt", ((V)((-3D)))).V), ((V)("io"))), "wait", ((V)(450D))), "to", ((V)(260D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)((-27D)))), NewObj(3).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("htilt", ((V)(0D))).V), ((V)("io")));
Invoke(Invoke(Invoke(t_660, "to", ((V)(300D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-1D))), ((V)((-19D)))), NewObj(3).Put("hyaw", ((V)(0.25))).Put("lx", ((V)(0.6))).Put("htilt", ((V)(3D))).V), ((V)("io"))), "wait", ((V)(450D))), "to", ((V)(260D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-27D)))), NewObj(3).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("htilt", ((V)(0D))).V), ((V)("io")));
Invoke(Invoke(t_660, "to", ((V)(320D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D)))), NewObj(3).Put("blush", ((V)(1D))).Put("smile", ((V)(0.7))).Put("pitch", ((V)((-0.06)))).V), ((V)("io"))), "wait", ((V)(500D)));
return Invoke(Invoke(t_660, "rest", ((V)(600D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Peek")), ((V)("Hides his face behind his paws and peeks out one side, then the other, blushing.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc661, V _a663, V _a664, V _a665, V _a666, V[] _rest662) => {
V t_667 = default;
t_667 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_667, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(380D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(4D)), ((V)(2D))), NewObj(5).Put("sq", ((V)(0.4))).Put("pitch", ((V)((-0.5)))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V), ((V)("io"))), "wait", ((V)(420D)));
Invoke(Invoke(Invoke(Invoke(t_667, "to", ((V)(160D)), Call(o_16, V.Undef, NOHANDS_17, NewObj(7).Put("sq", ((V)((-0.12)))).Put("pitch", ((V)(0.05))).Put("close", ((V)(0D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("smile", ((V)(0.8))).Put("blush", ((V)(0.9))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.05))).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("smile", ((V)(0D))).Put("blush", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_667, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_667, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Curls into a tight ball when squeezed, unrolls with a stretch and a shy smile.")))).Put("press", NewObj(3).Put("pitch", ((V)((-0.45)))).Put("sqz", ((V)(0.4))).Put("bristle", ((V)(1D))).V).Put("rel", NewObj(2).Put("dur", ((V)(1200D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(360D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(560D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(2.5)), ((V)("o"))), Arr(((V)(360D)), ((V)(0D)), ((V)("i"))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.9)), ((V)("io"))), Arr(((V)(900D)), ((V)(0.9))), Arr(((V)(1200D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.7)), ((V)("io"))), Arr(((V)(900D)), ((V)(0.7))), Arr(((V)(1200D)), ((V)(0D)), ((V)("io"))))).V).V).V);
Set(MOVES_29, "waffles", NewObj(7).Put("dance", Arr(Call(Fn((V _self1, int _argc668, V _a670, V _a671, V _a672, V _a673, V[] _rest669) => {
V t_674 = default;
double B_675 = 0;
t_674 = Call(TL_12, V.Undef, NewObj(4).Put("smile", ((V)(0.8))).Put("hap", ((V)(1D))).Put("open", ((V)(0.3))).Put("tongue", ((V)(0.6))).V);
B_675 = 500D;
Invoke(t_674, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Call(swing_20, V.Undef, t_674, ((V)((4D * B_675))), ((V)(11D)), NewObj(5).Put("tilt", ((V)(6D))).Put("x", ((V)(1D))).Put("bend", ((V)(2D))).Put("htilt", ((V)((-3D)))).Put("wag", ((V)(36D))).V);
{
double i_676 = 0;
i_676 = 0D;
while (true) {
if (!((i_676 < 4D))) break;
Call(jump_18, V.Undef, t_674, NewObj(9).Put("h", ((V)(8D))).Put("ant", ((V)(110D))).Put("up", ((V)(150D))).Put("dn", ((V)(130D))).Put("c", ((V)(0.15))).Put("arm", ((V)(34D))).Put("chain", ((i_676 < 3D) ? V.True : V.False)).Put("air", NewObj(1).Put("wag", ((V)((NumTruthy((i_676 % 2D)) ? 30D : (-30D))))).V).Put("fall", NewObj(1).Put("wag", ((V)(0D))).V).V);
i_676++;
}
}
Invoke(Invoke(Invoke(t_674, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0.36))).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("pitch", ((V)((-0.1)))).Put("open", ((V)(0.35))).V, ((V)("i"))), "to", ((V)(90D)), NewObj(1).Put("sq", ((V)(0.32))).V, ((V)("io")));
GSet("a", Get(t_674, "t"));
Call(swing_20, V.Undef, t_674, ((V)(700D)), ((V)(5D)), NewObj(1).Put("wag", ((V)(32D))).V);
Invoke(Invoke(Invoke(Invoke(t_674, "at", G("a")), "to", ((V)(350D)), NewObj(1).Put("htilt", ((V)(5D))).V, ((V)("io"))), "to", ((V)(350D)), NewObj(1).Put("htilt", ((V)(0D))).V, ((V)("io"))), "at", Add(G("a"), ((V)(700D))));
Invoke(t_674, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.4))).V, ((V)("io")));
Call(jump_18, V.Undef, t_674, NewObj(5).Put("h", ((V)(7D))).Put("ant", ((V)(120D))).Put("up", ((V)(180D))).Put("c", ((V)(0.42))).Put("arm", ((V)(50D))).V);
Invoke(Invoke(t_674, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(160D)), NewObj(7).Put("lean", ((V)((-2D)))).Put("tilt", ((V)((-4D)))).Put("sq", ((V)(0.06))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).Put("tongue", ((V)(1D))).Put("open", ((V)(0.45))).V, ((V)("io")));
GSet("a", Get(t_674, "t"));
Invoke(Invoke(t_674, "to", ((V)(1500D)), NewObj(1).Put("spin", ((V)(720D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(Invoke(t_674, "at", G("a")), "to", ((V)(500D)), NewObj(3).Put("x", ((V)((-6D)))).Put("tilt", ((V)((-7D)))).Put("lean", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(3).Put("x", ((V)(6D))).Put("tilt", ((V)(7D))).Put("lean", ((V)(3D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(3).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_674, "at", G("a")), "em", ((V)(1400D)), ((V)(200D)), ((V)("dust")), ((V)("footL")), ((V)(1D)));
Invoke(t_674, "at", G("a"));
Call(steps_19, V.Undef, t_674, ((V)(1500D)), ((V)(12D)), ((V)(3D)));
Invoke(Invoke(t_674, "at", Add(G("a"), ((V)(1501D)))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).V, ((V)("io")));
Invoke(t_674, "to", ((V)(300D)), NewObj(5).Put("pitch", ((V)((-0.32)))).Put("sq", ((V)(0.1))).Put("armL", ((V)((-12D)))).Put("armR", ((V)((-12D)))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(swing_20, V.Undef, t_674, ((V)(800D)), ((V)(5D)), NewObj(2).Put("tilt", ((V)(4D))).Put("wag", ((V)(36D))).V);
Invoke(Invoke(Invoke(t_674, "to", ((V)(110D)), NewObj(6).Put("pitch", ((V)((-0.1)))).Put("open", ((V)(0.85))).Put("mw", ((V)(0.85))).Put("sq", ((V)((-0.06)))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(160D)), NewObj(5).Put("open", ((V)(0.3))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.03))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Invoke(t_674, "to", ((V)(300D)), NewObj(7).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("open", ((V)(0.3))).Put("tongue", ((V)(0.6))).V, ((V)("io")));
return Invoke(t_674, "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Loaf Hop")), ((V)("Corgi butt wiggle, four loaf hops, a sploot (flops flat) and springs back up, zoomies (two spins), play bow and a happy boof.")))).Put("happy", Arr(Call(Fn((V _self1, int _argc678, V _a680, V _a681, V _a682, V _a683, V[] _rest679) => {
V t_684 = default;
V a_685 = default;
V L_686 = default;
t_684 = Call(TL_12, V.Undef, NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("tongue", ((V)(0.7))).V);
Invoke(t_684, "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0.1))).Put("lean", ((V)((-2D)))).V, ((V)("io")));
a_685 = Get(t_684, "t");
Invoke(Invoke(t_684, "to", ((V)(700D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_684, "at", a_685), "to", ((V)(350D)), NewObj(4).Put("sq", ((V)((-0.04)))).Put("lean", ((V)((-3D)))).Put("tilt", ((V)((-5D)))).Put("x", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(350D)), NewObj(4).Put("sq", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Invoke(t_684, "at", Add(a_685, ((V)(701D))));
Call(jump_18, V.Undef, t_684, NewObj(6).Put("h", ((V)(8D))).Put("ant", ((V)(130D))).Put("up", ((V)(170D))).Put("c", ((V)(0.15))).Put("arm", ((V)(36D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))))).V);
L_686 = Get(t_684, "t");
Invoke(t_684, "at", ((V)(0D)));
Call(swing_20, V.Undef, t_684, L_686, ((V)(23D)), NewObj(1).Put("wag", ((V)(36D))).V);
Invoke(t_684, "at", L_686);
return Object_assign(Invoke(t_684, "loop"), NewObj(1).Put("dur", ((V)((ToNum(L_686) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A happy zoomie spin and a hop, stub tail going frantic, tongue out.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc687, V _a689, V _a690, V _a691, V _a692, V[] _rest688) => {
V t_693 = default;
V a_694 = default;
t_693 = Call(TL_12, V.Undef);
Invoke(Invoke(t_693, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("sq", ((V)(0.08))).Put("wide", ((V)(1D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("o")));
Invoke(Invoke(Invoke(t_693, "to", ((V)(260D)), NewObj(4).Put("x", ((V)((-6D)))).Put("lean", ((V)((-4D)))).Put("tilt", ((V)((-3D)))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("dust")), ((V)("footR")), ((V)(3D))), "to", ((V)(220D)), NewObj(3).Put("lean", ((V)((-1D)))).Put("tilt", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_693, "to", ((V)(110D)), NewObj(4).Put("open", ((V)(0.85))).Put("mw", ((V)(0.85))).Put("sq", ((V)((-0.08)))).Put("pitch", ((V)(0.1))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), NewObj(4).Put("open", ((V)(0.15))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.03))).Put("pitch", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_693, "wait", ((V)(200D))), "to", ((V)(420D)), NewObj(5).Put("htilt", ((V)(13D))).Put("earL", ((V)(4D))).Put("earR", ((V)((-6D)))).Put("open", ((V)(0D))).Put("lx", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(600D)));
Invoke(Invoke(t_693, "e", ((V)("blink"))), "to", ((V)(400D)), NewObj(8).Put("htilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("io")));
a_694 = Get(t_693, "t");
Invoke(t_693, "osc", ((V)(1000D)), ((V)(6D)), NewObj(1).Put("wag", ((V)(34D))).V, NewObj(1).Put("wag", ((V)((-34D)))).V, ((V)("io")));
Invoke(Invoke(t_693, "at", a_694), "to", ((V)(1000D)), NewObj(2).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_693, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Ears shoot up, skids backwards, one big boof, a head tilt - then his stub tail starts going.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc695, V _a697, V _a698, V _a699, V _a700, V[] _rest696) => {
V t_701 = default;
t_701 = Call(TL_12, V.Undef);
Invoke(Invoke(t_701, "to", ((V)(300D)), NewObj(5).Put("pitch", ((V)((-0.3)))).Put("sq", ((V)(0.1))).Put("armL", ((V)((-12D)))).Put("armR", ((V)((-12D)))).Put("close", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(5).Put("pitch", ((V)((-0.36)))).Put("sq", ((V)(0.13))).Put("lean", ((V)(0.8))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.9))).V, ((V)("io")));
Invoke(t_701, "to", ((V)(300D)), NewObj(8).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lean", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("close", ((V)(0.85))).V, ((V)("io")));
Invoke(t_701, "to", ((V)(220D)), NewObj(3).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.1)))).Put("close", ((V)(1D))).V, ((V)("io")));
Invoke(t_701, "em", ((V)(900D)), ((V)(130D)), ((V)("dust")), ((V)("body")), ((V)(1D)));
Call(shake_22, V.Undef, t_701, NewObj(7).Put("P", ((V)(110D))).Put("head", ((V)(0.4))).Put("roll", ((V)(5D))).Put("ear", ((V)(14D))).Put("chest", ((V)(0.3))).Put("body", ((V)(1.2))).Put("tail", ((V)(36D))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(t_701, "to", ((V)(220D)), NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink"))), "to", ((V)(150D)), NewObj(1).Put("earL", ((V)((-7D)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(5).Put("earL", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("tongue", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(500D)));
return Invoke(Invoke(t_701, "rest", ((V)(450D))), "done", NewObj(2).Put("stretch", ((V)(0D))).Put("soft", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Stretch and shake")), ((V)("A play-bow stretch with a little yawn, then a wet-dog shake: he braces, his head twists left and right with his body following a moment later, it builds up and dies away with his ears flapping, then a happy blink.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc702, V _a704, V _a705, V _a706, V _a707, V[] _rest703) => {
V t_708 = default;
t_708 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_708, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(340D)), NewObj(6).Put("sq", ((V)(0.42))).Put("hap", ((V)(0.9))).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("earL", ((V)(12D))).Put("earR", ((V)(12D))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(t_708, "to", ((V)(120D)), NewObj(9).Put("sq", ((V)((-0.22)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("tongue", ((V)(0.6))).V, ((V)("o")));
Call(jelly_23, V.Undef, t_708, ((V)(0.12)), ((V)(3D)), ((V)(220D)));
Invoke(t_708, "to", ((V)(160D)), NewObj(7).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("tongue", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_708, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_708, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed flat like bread dough, then springs back with a doughy wobble.")))).Put("press", NewObj(2).Put("tongue", ((V)(0.5))).Put("open", ((V)(0.2))).V).Put("rel", NewObj(2).Put("dur", ((V)(1100D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.22))), ((V)("o"))), Arr(((V)(230D)), ((V)(0.12)), ((V)("io"))), Arr(((V)(350D)), ((V)((-0.06))), ((V)("io"))), Arr(((V)(470D)), ((V)(0.03)), ((V)("io"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(3D)), ((V)("o"))), Arr(((V)(270D)), ((V)(0D)), ((V)("i"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(34D))), Arr(((V)(200D)), ((V)((-34D)))), Arr(((V)(300D)), ((V)(34D))), Arr(((V)(400D)), ((V)((-34D)))), Arr(((V)(500D)), ((V)(30D))), Arr(((V)(600D)), ((V)((-20D)))), Arr(((V)(750D)), ((V)(0D))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).V).V);
popcorn_30 = Fn((V _self1, int _argc709, V t_715, V h_716, V d_717, V len_718, V[] _rest710) => {
V a_719 = default;
V b_720 = default;
a_719 = Get(t_715, "t");
len_718 = (len_718 is var _t721 && Truthy(_t721) ? _t721 : ((V)(520D)));
Invoke(Invoke(t_715, "to", ((V)((ToNum(len_718) * 0.4))), NewObj(3).Put("lift", h_716).Put("tilt", ((V)((ToNum(d_717) * 14D)))).Put("turn", ((V)((ToNum(d_717) * 0.35)))).V, ((V)("o"))), "to", ((V)((ToNum(len_718) * 0.4))), NewObj(3).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).Put("turn", ((V)(0D))).V, ((V)("i")));
b_720 = Get(t_715, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_715, "at", a_719), "to", ((V)(60D)), NewObj(1).Put("sq", ((V)((-0.14)))).V, ((V)("o"))), "to", ((V)(((ToNum(len_718) * 0.8) - 60D))), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(1).Put("sq", ((V)(0.14))).V, ((V)("o"))), "to", ((V)((((ToNum(len_718) * 0.2) - 90D) + 60D))), NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_715, "at", b_720), "wait", ((V)(((ToNum(len_718) * 0.2) + 200D))));
return default;
}, 4, "", true);
Set(MOVES_29, "poppy", NewObj(7).Put("dance", Arr(Call(Fn((V _self1, int _argc722, V _a724, V _a725, V _a726, V _a727, V[] _rest723) => {
V t_728 = default;
double B_729 = 0;
V a_730 = default;
t_728 = Call(TL_12, V.Undef, NewObj(1).Put("smile", ((V)(0.7))).V);
B_729 = 500D;
Invoke(t_728, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
a_730 = Get(t_728, "t");
Call(steps_19, V.Undef, t_728, ((V)((3D * B_729))), ((V)(12D)), ((V)(1.8)));
Invoke(t_728, "at", a_730);
Call(swing_20, V.Undef, t_728, ((V)((3D * B_729))), ((V)(5D)), NewObj(2).Put("x", ((V)(1.5))).Put("pitch", ((V)((-0.05)))).V);
Invoke(Invoke(Invoke(t_728, "at", a_730), "osc", ((V)((3D * B_729))), ((V)(12D)), NewObj(1).Put("sq", ((V)(0.02))).V, NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o"))), "at", Add(a_730, ((V)((3D * B_729)))));
Invoke(Invoke(Invoke(Invoke(t_728, "to", ((V)(140D)), NewObj(4).Put("pitch", ((V)(0.22))).Put("open", ((V)(0.65))).Put("mw", ((V)(0.75))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)(0.18))).Put("open", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(4).Put("pitch", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_728, "to", ((V)(80D)), NewObj(1).Put("wide", ((V)(0.6))).V, ((V)("o")));
Call(popcorn_30, V.Undef, t_728, ((V)(11D)), ((V)(1D)));
Invoke(t_728, "wait", ((V)(80D)));
Call(popcorn_30, V.Undef, t_728, ((V)(9D)), ((V)((-1D))), ((V)(480D)));
Invoke(t_728, "wait", ((V)(260D)));
Call(popcorn_30, V.Undef, t_728, ((V)(12D)), ((V)(1D)), ((V)(540D)));
Invoke(t_728, "to", ((V)(100D)), NewObj(2).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
{
double i_731 = 0;
i_731 = 0D;
while (true) {
if (!((i_731 < 4D))) break;
Invoke(Invoke(Invoke(t_728, "to", ((V)(140D)), NewObj(5).Put("pitch", ((V)(0.18))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.75))).Put("sq", ((V)((-0.04)))).Put("lift", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(360D)), NewObj(5).Put("pitch", ((V)(((-0.04) * ((i_731 < 3D) ? 1D : 0D))))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)((0.03 * ((i_731 < 3D) ? 1D : 0D))))).Put("lift", ((V)(0D))).V, ((V)("io")));
i_731++;
}
}
a_730 = Get(t_728, "t");
Invoke(Invoke(t_728, "to", ((V)(1500D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(Invoke(t_728, "at", a_730), "to", ((V)(300D)), NewObj(3).Put("lean", ((V)(2.5))).Put("tilt", ((V)(4D))).Put("pitch", ((V)((-0.12)))).V, ((V)("io"))), "wait", ((V)(900D))), "to", ((V)(300D)), NewObj(3).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
Invoke(t_728, "at", a_730);
Call(steps_19, V.Undef, t_728, ((V)(1500D)), ((V)(10D)), ((V)(2.4)));
Invoke(t_728, "at", Add(a_730, ((V)(1501D))));
Call(popcorn_30, V.Undef, t_728, ((V)(14D)), ((V)((-1D))), ((V)(600D)));
a_730 = Get(t_728, "t");
Call(swing_20, V.Undef, t_728, ((V)(1400D)), ((V)(3D)), NewObj(4).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).Put("bend", ((V)(2.5))).Put("htilt", ((V)((-2D)))).V);
Invoke(Invoke(Invoke(Invoke(t_728, "at", Add(a_730, ((V)(600D)))), "to", ((V)(120D)), NewObj(1).Put("winkR", ((V)(1D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("winkR", ((V)(0D))).V, ((V)("io"))), "at", Add(a_730, ((V)(1400D))));
Invoke(t_728, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0.7))).V, ((V)("io")));
return Invoke(t_728, "loop", NewObj(1).Put("stretch", ((V)(0.8))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Popcorn Bounce")), ((V)("Pitter-patter feet, a wheek, three sudden popcorn jumps with a twist in the air, a wheek song, runs a little circle, a big popcorn and a cheeky wink.")))).Put("happy", Arr(Call(Fn((V _self1, int _argc733, V _a735, V _a736, V _a737, V _a738, V[] _rest734) => {
V t_739 = default;
t_739 = Call(TL_12, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Call(popcorn_30, V.Undef, t_739, ((V)(10D)), ((V)(1D)));
Invoke(t_739, "wait", ((V)(100D)));
Call(popcorn_30, V.Undef, t_739, ((V)(12D)), ((V)((-1D))), ((V)(560D)));
Invoke(Invoke(Invoke(Invoke(t_739, "to", ((V)(140D)), NewObj(3).Put("pitch", ((V)(0.18))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.75))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(260D)), NewObj(3).Put("pitch", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Object_assign(Invoke(t_739, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_739, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Two popcorn jumps with a twist in the air and a happy wheek.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc740, V _a742, V _a743, V _a744, V _a745, V[] _rest741) => {
V t_746 = default;
V a_747 = default;
t_746 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_746, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(4).Put("wide", ((V)(1D))).Put("sq", ((V)(0.06))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("o"))), "wait", ((V)(500D)));
a_747 = Get(t_746, "t");
Invoke(t_746, "to", ((V)(320D)), NewObj(2).Put("x", ((V)((-7D)))).Put("lean", ((V)((-2.5)))).V, ((V)("o")));
Invoke(t_746, "at", a_747);
Call(steps_19, V.Undef, t_746, ((V)(320D)), ((V)(4D)), ((V)(2.2)));
Invoke(Invoke(Invoke(Invoke(t_746, "at", Add(a_747, ((V)(320D)))), "to", ((V)(130D)), NewObj(4).Put("lean", ((V)(0D))).Put("pitch", ((V)(0.22))).Put("open", ((V)(0.8))).Put("mw", ((V)(0.7))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)(0D))).Put("open", ((V)(0.1))).Put("mw", ((V)(1D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_746, "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0.7))).Put("ly", ((V)(0.1))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(5).Put("lx", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wide", ((V)(0.3))).Put("open", ((V)(0D))).V, ((V)("io")));
a_747 = Get(t_746, "t");
Invoke(t_746, "to", ((V)(800D)), NewObj(1).Put("x", ((V)(0D))).V, ((V)("io")));
Invoke(t_746, "at", a_747);
Call(steps_19, V.Undef, t_746, ((V)(800D)), ((V)(6D)), ((V)(1.6)));
return Invoke(Invoke(Invoke(t_746, "at", Add(a_747, ((V)(801D)))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Freezes, zips backwards on pattering feet, an alarm wheek, then creeps back.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc748, V _a750, V _a751, V _a752, V _a753, V[] _rest749) => {
V t_754 = default;
V a_755 = default;
t_754 = Call(TL_12, V.Undef);
Invoke(Invoke(t_754, "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.5))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(2D)));
a_755 = Get(t_754, "t");
Invoke(t_754, "osc", ((V)(1600D)), ((V)(8D)), NewObj(5).Put("open", ((V)(0.3))).Put("mw", ((V)(0.75))).Put("sq", ((V)(0.05))).Put("pitch", ((V)((-0.26)))).Put("htilt", ((V)(3D))).V, NewObj(5).Put("open", ((V)(0.03))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.02))).Put("pitch", ((V)((-0.16)))).Put("htilt", ((V)((-3D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_754, "at", Add(a_755, ((V)(400D)))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D))), "at", Add(a_755, ((V)(1000D)))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D))), "at", Add(a_755, ((V)(1600D))));
Invoke(Invoke(Invoke(t_754, "to", ((V)(200D)), NewObj(6).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("sq", ((V)(0D))).Put("htilt", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("earR", ((V)((-18D)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(1).Put("earR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_754, "osc", ((V)(420D)), ((V)(4D)), NewObj(2).Put("pitch", ((V)(0.05))).Put("sq", ((V)(0.015))).V, NewObj(2).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0.05))).Put("pitch", ((V)((-0.15)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_754, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Hay munch")), ((V)("Munches some hay, an ear flick, a nose twitch and a gulp.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc756, V _a758, V _a759, V _a760, V _a761, V[] _rest757) => {
V t_762 = default;
t_762 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_762, "to", ((V)(130D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.38))).Put("open", ((V)(0.55))).Put("mw", ((V)(0.75))).Put("wide", ((V)(0.6))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "wait", ((V)(400D)));
Invoke(t_762, "to", ((V)(10D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("wide", ((V)(0D))).V);
Call(popcorn_30, V.Undef, t_762, ((V)(9D)), ((V)(1D)), ((V)(480D)));
Invoke(t_762, "to", ((V)(100D)), NewObj(0).V);
return Object_assign(Invoke(t_762, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_762, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeaks when squeezed, then pops straight up in a popcorn jump.")))).Put("press", NewObj(2).Put("open", ((V)(0.4))).Put("mw", ((V)(0.8))).V).Put("rel", NewObj(3).Put("dur", ((V)(900D))).Put("k", NewObj(4).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(9D)), ((V)("o"))), Arr(((V)(400D)), ((V)(0D)), ((V)("i"))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(12D)), ((V)("o"))), Arr(((V)(400D)), ((V)(0D)), ((V)("i"))))).Put("turn", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(400D)), ((V)(0D)), ((V)("i"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(380D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(460D)), ((V)(0.12)), ((V)("o"))), Arr(((V)(600D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(740D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("note")), ((V)("head")), ((V)(1D))))).V).V);
Set(MOVES_29, "duchess", NewObj(7).Put("dance", Arr(Call(Fn((V _self1, int _argc763, V _a765, V _a766, V _a767, V _a768, V[] _rest764) => {
V t_769 = default;
double BAR_770 = 0;
double b3_771 = 0;
V a_772 = default;
t_769 = Call(TL_12, V.Undef, NewObj(3).Put("pitch", ((V)(0.1))).Put("close", ((V)(0.3))).Put("smile", ((V)(0.6))).V);
BAR_770 = 2000D;
b3_771 = (BAR_770 / 3D);
Invoke(t_769, "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D)));
{
double j_773 = 0;
j_773 = 0D;
while (true) {
if (!((j_773 < 2D))) break;
double d_775 = 0;
d_775 = (NumTruthy(j_773) ? 1D : (-1D));
Invoke(Invoke(t_769, "to", ((V)(b3_771)), NewObj(9).Put("sq", ((V)(0.06))).Put("x", ((V)((d_775 * 2.4)))).Put("bend", ((V)((d_775 * 3D)))).Put("tilt", ((V)((d_775 * 2D)))).Put("htilt", ((V)(((-d_775) * 1.5)))).Put("lift", ((V)(0D))).Put("wag", ((V)((d_775 * 14D)))).Put("armR", ((V)((40D + (j_773 * 6D))))).Put("hRy", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)((b3_771 * 2D))), NewObj(4).Put("sq", ((V)((-0.03)))).Put("lift", ((V)(1.6))).Put("bend", ((V)((d_775 * 1.4)))).Put("tilt", ((V)((d_775 * 0.6)))).V, ((V)("io")));
j_773++;
}
}
Invoke(t_769, "to", ((V)(600D)), NewObj(11).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("tilt", ((V)(0D))).Put("htilt", ((V)(0D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("wag", ((V)(0D))).Put("armL", ((V)(72D))).Put("armR", ((V)(72D))).Put("hRy", ((V)(0D))).Put("close", ((V)(0.15))).V, ((V)("io")));
a_772 = Get(t_769, "t");
Invoke(Invoke(t_769, "to", ((V)(2400D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_769, "at", a_772), "to", ((V)(1200D)), NewObj(3).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.04)))).Put("curl", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(1200D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("curl", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_769, "at", Add(a_772, ((V)(600D)))), "e", ((V)("emit")), ((V)("spark")), ((V)("body")), ((V)(3D))), "at", Add(a_772, ((V)(2401D)))), "to", ((V)(1000D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0.3))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_769, "to", ((V)(500D)), NewObj(3).Put("armR", ((V)(100D))).Put("hRx", ((V)((-4D)))).Put("hRy", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(3).Put("armR", ((V)(126D))).Put("hRx", ((V)(3D))).Put("hRy", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(3).Put("armR", ((V)(92D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-2D)))).V, ((V)("io")));
a_772 = Get(t_769, "t");
Call(look_21, V.Undef, t_769, ((V)(0D)), ((V)(0.5)), NewObj(3).Put("k", ((V)(0.7))).Put("d1", ((V)(240D))).Put("d2", ((V)(280D))).V);
Invoke(Invoke(Invoke(t_769, "at", Add(a_772, ((V)(1130D)))), "to", ((V)(600D)), NewObj(1).Put("close", ((V)(1D))).V, ((V)("io"))), "to", ((V)(600D)), NewObj(1).Put("close", ((V)(0.3))).V, ((V)("io")));
Invoke(Invoke(t_769, "at", Add(Add(a_772, ((V)(1130D))), ((V)(1200D)))), "to", ((V)(500D)), NewObj(8).Put("hyaw", ((V)(0D))).Put("twist", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).Put("lx", ((V)(0D))).Put("armR", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_769, "to", ((V)(700D)), NewObj(7).Put("footL", ((V)(2.2))).Put("sq", ((V)(0.14))).Put("pitch", ((V)((-0.16)))).Put("armL", ((V)((-14D)))).Put("armR", ((V)((-14D)))).Put("x", ((V)(0.8))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(Max(300D, (12000D - ToNum(Get(t_769, "t")))))), NewObj(7).Put("footL", ((V)(0D))).Put("sq", ((V)(0D))).Put("pitch", ((V)(0.1))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("x", ((V)(0D))).Put("close", ((V)(0.3))).V, ((V)("io")));
return Invoke(t_769, "loop", NewObj(2).Put("stretch", ((V)(0.3))).Put("soft", ((V)(0.8))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Royal Sway")), ((V)("A slow waltz sway with one paw raised daintily, an elegant twirl with sparkles, a paw flourish, a slow cat blink at you over her shoulder, and a curtsy.")))).Put("happy", Arr(Call(Fn((V _self1, int _argc776, V _a778, V _a779, V _a780, V _a781, V[] _rest777) => {
V t_782 = default;
t_782 = Call(TL_12, V.Undef, NewObj(3).Put("pitch", ((V)(0.12))).Put("smile", ((V)(0.9))).Put("close", ((V)(0.35))).V);
Invoke(Invoke(t_782, "to", ((V)(500D)), NewObj(5).Put("x", ((V)(1.6))).Put("bend", ((V)(2D))).Put("tilt", ((V)(1.5))).Put("wag", ((V)(14D))).Put("curl", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(5).Put("x", ((V)((-1.6)))).Put("bend", ((V)((-2D)))).Put("tilt", ((V)((-1.5)))).Put("wag", ((V)((-14D)))).Put("curl", ((V)(0.1))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_782, "to", ((V)(500D)), NewObj(6).Put("close", ((V)(1D))).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("tilt", ((V)(0D))).Put("wag", ((V)(0D))).Put("curl", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "to", ((V)(600D)), NewObj(1).Put("close", ((V)(0.35))).V, ((V)("io"))), "wait", ((V)(300D)));
return Object_assign(Invoke(t_782, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_782, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Pleased: chin up, a gentle sway with her tail curling, a slow cat blink and a heart.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc783, V _a785, V _a786, V _a787, V _a788, V[] _rest784) => {
V t_789 = default;
t_789 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_789, "wait", ((V)(150D))), "to", ((V)(120D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(380D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-8D)))), NewObj(7).Put("lean", ((V)((-4D)))).Put("x", ((V)((-3D)))).Put("pitch", ((V)(0.24))).Put("open", ((V)(0.35))).Put("mw", ((V)(0.6))).Put("armR", ((V)(10D))).Put("sq", ((V)(0D))).V), ((V)("o"))), "wait", ((V)(700D))), "e", ((V)("blink"))), "to", ((V)(500D)), NewObj(3).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_789, "to", ((V)(400D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-2D))))), ((V)("io"))), "to", ((V)(400D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-8D))))), ((V)("io"))), "to", ((V)(300D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-2D))))), ((V)("io")));
Invoke(Invoke(t_789, "to", ((V)(500D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(6).Put("armR", ((V)(0D))).Put("close", ((V)(0.6))).Put("pitch", ((V)(0.3))).Put("hyaw", ((V)(0.4))).Put("lx", ((V)(0.5))).Put("htilt", ((V)((-3D)))).V), ((V)("io"))), "wait", ((V)(700D)));
Invoke(t_789, "to", ((V)(600D)), NewObj(7).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_789, "rest", ((V)(500D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Draws back with a paw to her chest, then composes herself, smooths her fur and turns away with a dignified hmph.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc790, V _a792, V _a793, V _a794, V _a795, V[] _rest791) => {
V t_796 = default;
t_796 = Call(TL_12, V.Undef);
Invoke(t_796, "to", ((V)(450D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-6D)))), NewObj(4).Put("armR", ((V)(18D))).Put("pitch", ((V)((-0.14)))).Put("ly", ((V)(0.7))).Put("htilt", ((V)(3D))).V), ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_796, "to", ((V)(220D)), NewObj(2).Put("hRx", ((V)((-10D)))).Put("hRy", ((V)((-5D)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("hRx", ((V)((-6D)))).Put("hRy", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hRx", ((V)((-9D)))).Put("hRy", ((V)((-6D)))).V, ((V)("io"))), "wait", ((V)(200D)));
Invoke(Invoke(t_796, "to", ((V)(450D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D)))), NewObj(3).Put("armR", ((V)(20D))).Put("ly", ((V)(0.3))).Put("pitch", ((V)((-0.08)))).V), ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(2).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.12))).V, NewObj(2).Put("tongue", ((V)(0.1))).Put("open", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_796, "to", ((V)(400D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(6).Put("armR", ((V)(0D))).Put("tongue", ((V)(0D))).Put("pitch", ((V)(0.18))).Put("close", ((V)(0.5))).Put("smile", ((V)(0.8))).Put("ly", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(600D)));
return Invoke(Invoke(t_796, "rest", ((V)(600D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Fixes her bow")), ((V)("Looks down and sets her bow straight with a paw, licks the paw, lifts her chin.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc797, V _a799, V _a800, V _a801, V _a802, V[] _rest798) => {
V t_803 = default;
t_803 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_803, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(5).Put("sq", ((V)(0.34))).Put("sqz", ((V)(0.8))).Put("frown", ((V)(0.4))).Put("armL", ((V)(14D))).Put("armR", ((V)(14D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(4).Put("sqz", ((V)(0D))).Put("close", ((V)(0.8))).Put("frown", ((V)(0D))).Put("smile", ((V)(0.6))).V, ((V)("io")));
Invoke(Invoke(t_803, "to", ((V)(140D)), NewObj(4).Put("sq", ((V)((-0.12)))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(1).Put("sq", ((V)(0.04))).V, ((V)("io")));
Call(shake_22, V.Undef, t_803, NewObj(6).Put("P", ((V)(95D))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(0.7)), ((V)(0.35)))).Put("head", ((V)(0.12))).Put("roll", ((V)(2D))).Put("ear", ((V)(6D))).Put("body", ((V)(0.45))).V);
Invoke(t_803, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_803, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_803, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Not amused at first, then eyes close and she quite likes it; fluffs herself back up.")))).Put("press", NewObj(2).Put("close", ((V)(0.5))).Put("pitch", ((V)(0.15))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(140D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(320D)), ((V)(0.04)), ((V)("io"))), Arr(((V)(480D)), ((V)(0D)), ((V)("io"))))).Put("x", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(480D)), ((V)(0D))), Arr(((V)(580D)), ((V)(0.45)), ((V)("io"))), Arr(((V)(680D)), ((V)((-0.4))), ((V)("io"))), Arr(((V)(780D)), ((V)(0.25)), ((V)("io"))), Arr(((V)(880D)), ((V)((-0.1))), ((V)("io"))), Arr(((V)(980D)), ((V)(0D)), ((V)("io"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.18)), ((V)("io"))), Arr(((V)(800D)), ((V)(0.18))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.5)), ((V)("io"))), Arr(((V)(800D)), ((V)(0.5))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("spark")), ((V)("head")), ((V)(2D))))).V).V);
Set(MOVES_29, "mamapaws", NewObj(7).Put("dance", Arr(Call(Fn((V _self1, int _argc804, V _a806, V _a807, V _a808, V _a809, V[] _rest805) => {
V P_810 = default;
V t_811 = default;
double B_812 = 0;
V a_813 = default;
V e_814 = default;
P_810 = Call(both_15, V.Undef, ((V)(6D)), ((V)((-6D))));
t_811 = Call(TL_12, V.Undef, Call(o_16, V.Undef, P_810, NewObj(1).Put("smile", ((V)(0.85))).V));
B_812 = 600D;
Invoke(t_811, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
a_813 = Get(t_811, "t");
Call(swing_20, V.Undef, t_811, ((V)((4D * B_812))), ((V)(3D)), NewObj(5).Put("x", ((V)(2D))).Put("tilt", ((V)(3D))).Put("bend", ((V)(2.5))).Put("htilt", ((V)((-2D)))).Put("sq", ((V)(0.03))).V);
Invoke(Invoke(Invoke(t_811, "at", a_813), "to", ((V)(400D)), NewObj(1).Put("hap", ((V)(0.9))).V, ((V)("io"))), "at", Add(a_813, ((V)((4D * B_812)))));
a_813 = Get(t_811, "t");
{
double i_815 = 0;
i_815 = 0D;
while (true) {
if (!((i_815 < 4D))) break;
Invoke(Invoke(Invoke(Invoke(t_811, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.13))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0.035))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
i_815++;
}
}
e_814 = Get(t_811, "t");
Invoke(t_811, "at", a_813);
Call(swing_20, V.Undef, t_811, ((V)((8D * B_812))), ((V)(23D)), NewObj(1).Put("wag", ((V)(24D))).V);
Invoke(t_811, "at", e_814);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_811, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(500D)), NewObj(7).Put("twist", ((V)((-0.35)))).Put("turn", ((V)((-0.06)))).Put("pitch", ((V)((-0.22)))).Put("htilt", ((V)((-6D)))).Put("ly", ((V)(0.7))).Put("lx", ((V)((-0.3)))).Put("hap", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(1D)), NewObj(1).Put("htilt", ((V)((-9D)))).V, NewObj(1).Put("htilt", ((V)((-5D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "to", ((V)(600D)), NewObj(4).Put("twist", ((V)(0.35))).Put("turn", ((V)(0.06))).Put("htilt", ((V)(6D))).Put("lx", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(1D)), NewObj(1).Put("htilt", ((V)(9D))).V, NewObj(1).Put("htilt", ((V)(5D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(7).Put("twist", ((V)(0D))).Put("turn", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("hap", ((V)(0.9))).V, ((V)("io")));
Call(jump_18, V.Undef, t_811, NewObj(6).Put("h", ((V)(5D))).Put("ant", ((V)(260D))).Put("up", ((V)(260D))).Put("c", ((V)(0.12))).Put("arm", ((V)(0D))).Put("chain", (true ? V.True : V.False)).V);
Call(land_24, V.Undef, t_811, ((V)(0.1)), ((V)(4D)), ((V)(280D)));
a_813 = Get(t_811, "t");
Invoke(Invoke(t_811, "to", ((V)(400D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(2).Put("armR", ((V)(118D))).Put("hRy", ((V)((-3D)))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("armR", ((V)(104D))).V, NewObj(1).Put("armR", ((V)(130D))).V, ((V)("io")));
e_814 = Get(t_811, "t");
Invoke(t_811, "at", a_813);
Call(swing_20, V.Undef, t_811, ((V)(1600D)), ((V)(1D)), NewObj(3).Put("x", ((V)(2.5))).Put("tilt", ((V)(3D))).Put("bend", ((V)(3D))).V);
Invoke(t_811, "at", e_814);
Invoke(t_811, "to", ((V)(500D)), Call(o_16, V.Undef, P_810, NewObj(2).Put("armR", ((V)(0D))).Put("hap", ((V)(0D))).V), ((V)("io")));
return Invoke(t_811, "loop", NewObj(1).Put("stretch", ((V)(0.4))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Puppy Pile Jelly")), ((V)("A soft jelly sway rocking her pup, wobbly jelly bounces, shows the pup off with nuzzles and hearts, a careful little hop and a wave - the pup dances along.")))).Put("happy", Arr(Call(Fn((V _self1, int _argc817, V _a819, V _a820, V _a821, V _a822, V[] _rest818) => {
V P_823 = default;
V t_824 = default;
V L_825 = default;
P_823 = Call(both_15, V.Undef, ((V)(6D)), ((V)((-6D))));
t_824 = Call(TL_12, V.Undef, Call(o_16, V.Undef, P_823, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V));
{
double i_826 = 0;
i_826 = 0D;
while (true) {
if (!((i_826 < 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_824, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.04))).Put("lift", ((V)(0D))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
i_826++;
}
}
Invoke(Invoke(Invoke(t_824, "to", ((V)(400D)), NewObj(3).Put("pitch", ((V)((-0.2)))).Put("htilt", ((V)((-5D)))).Put("ly", ((V)(0.6))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))), "to", ((V)(400D)), NewObj(3).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
L_825 = Get(t_824, "t");
Invoke(t_824, "at", ((V)(0D)));
Call(swing_20, V.Undef, t_824, L_825, ((V)(11D)), NewObj(1).Put("wag", ((V)(26D))).V);
Invoke(t_824, "at", L_825);
return Object_assign(Invoke(t_824, "loop"), NewObj(1).Put("dur", ((V)((ToNum(L_825) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Soft happy bounces, hugs her pup close, hearts, tail wagging.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc828, V _a830, V _a831, V _a832, V _a833, V[] _rest829) => {
V t_834 = default;
V a_835 = default;
t_834 = Call(TL_12, V.Undef);
Invoke(Invoke(t_834, "wait", ((V)(150D))), "to", ((V)(100D)), NewObj(4).Put("wide", ((V)(1D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).Put("sq", ((V)(0.05))).V, ((V)("o")));
Invoke(t_834, "to", ((V)(380D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(8D)), ((V)((-6D)))), NewObj(5).Put("twist", ((V)((-0.45)))).Put("turn", ((V)((-0.08)))).Put("sq", ((V)(0.08))).Put("lean", ((V)((-1.5)))).Put("x", ((V)((-1.5)))).V), ((V)("io")));
Call(look_21, V.Undef, t_834, ((V)(0D)), ((V)((-0.5))), NewObj(1).Put("k", ((V)(0.4))).V);
Invoke(t_834, "wait", ((V)(200D)));
a_835 = Get(t_834, "t");
Invoke(Invoke(Invoke(t_834, "to", ((V)(500D)), NewObj(2).Put("hyaw", ((V)(0.45))).Put("lx", ((V)(0.9))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(400D)), NewObj(2).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
Invoke(t_834, "at", Add(a_835, ((V)(1300D))));
Invoke(Invoke(Invoke(t_834, "to", ((V)(700D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-6D)))), NewObj(11).Put("twist", ((V)(0D))).Put("turn", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).Put("sq", ((V)((-0.06)))).Put("lean", ((V)(0D))).Put("x", ((V)(0D))).Put("close", ((V)(0.7))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wide", ((V)(0D))).V), ((V)("io"))), "to", ((V)(500D)), NewObj(3).Put("sq", ((V)(0.03))).Put("close", ((V)(0D))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_834, "rest", ((V)(500D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Turns to shield her pup, ears up, checks around, then a big relieved sigh.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc836, V _a838, V _a839, V _a840, V _a841, V[] _rest837) => {
V t_842 = default;
t_842 = Call(TL_12, V.Undef);
Invoke(t_842, "to", ((V)(600D)), NewObj(4).Put("pitch", ((V)((-0.28)))).Put("ly", ((V)(0.8))).Put("htilt", ((V)((-4D)))).Put("smile", ((V)(0.7))).V, ((V)("io")));
Invoke(Invoke(t_842, "osc", ((V)(1600D)), ((V)(2D)), NewObj(4).Put("htilt", ((V)((-9D)))).Put("x", ((V)(0.8))).Put("tilt", ((V)(1.5))).Put("close", ((V)(0.6))).V, NewObj(4).Put("htilt", ((V)((-3D)))).Put("x", ((V)((-0.8)))).Put("tilt", ((V)((-1.5)))).Put("close", ((V)(0.2))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
Invoke(Invoke(t_842, "to", ((V)(500D)), NewObj(7).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("htilt", ((V)(0D))).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(400D)));
return Invoke(Invoke(t_842, "rest", ((V)(500D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Nuzzle the pup")), ((V)("Looks down at her pup, nuzzles it and rocks it gently, a heart.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc843, V _a845, V _a846, V _a847, V _a848, V[] _rest844) => {
V t_849 = default;
t_849 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_849, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0.36))).Put("hap", ((V)(0.9))).Put("earL", ((V)(5D))).Put("earR", ((V)(5D))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(t_849, "to", ((V)(150D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V, ((V)("o")));
Call(jelly_23, V.Undef, t_849, ((V)(0.12)), ((V)(4D)), ((V)(300D)));
Invoke(t_849, "to", ((V)(200D)), NewObj(3).Put("smile", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_849, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_849, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed into a soft cuddle, then a slow jelly wobble.")))).Put("press", NewObj(1).Put("hap", ((V)(0.4))).V).Put("rel", NewObj(3).Put("dur", ((V)(1600D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(300D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(450D)), ((V)((-0.06))), ((V)("io"))), Arr(((V)(600D)), ((V)(0.035)), ((V)("io"))), Arr(((V)(750D)), ((V)((-0.015))), ((V)("io"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(1D)), ((V)("io"))), Arr(((V)(1200D)), ((V)(1D))), Arr(((V)(1600D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("heart")), ((V)("head")), ((V)(2D))))).V).V);
croak_31 = Fn((V _self1, int _argc850, V t_856, V n_857, V per_858, V _a855, V[] _rest851) => {
{
double i_859 = 0;
i_859 = 0D;
while (true) {
if (!(Lt(((V)(i_859)), n_857))) break;
Invoke(Invoke(t_856, "to", ((V)((ToNum(per_858) * 0.35))), NewObj(2).Put("puff", ((V)(1.1))).Put("pitch", ((V)(0.06))).V, ((V)("o"))), "to", ((V)((ToNum(per_858) * 0.65))), NewObj(2).Put("puff", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
i_859++;
}
}
return t_856;
return default;
}, 3, "", true);
Set(MOVES_29, "ribbit", NewObj(7).Put("dance", Arr(Call(Fn((V _self1, int _argc861, V _a863, V _a864, V _a865, V _a866, V[] _rest862) => {
V t_867 = default;
double B_868 = 0;
V a_869 = default;
t_867 = Call(TL_12, V.Undef, NewObj(1).Put("smile", ((V)(0.85))).V);
B_868 = 500D;
Invoke(t_867, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_870 = 0;
i_870 = 0D;
while (true) {
if (!((i_870 < 3D))) break;
Invoke(Invoke(Invoke(t_867, "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0.26))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("pitch", ((V)((-0.08)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(5).Put("sq", ((V)((-0.13)))).Put("lift", ((V)(2.5))).Put("armL", ((V)(8D))).Put("armR", ((V)(8D))).Put("pitch", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(3).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("i")));
i_870++;
}
}
Invoke(Invoke(t_867, "to", ((V)(120D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Call(croak_31, V.Undef, t_867, ((V)(1D)), ((V)(450D)));
Call(jump_18, V.Undef, t_867, NewObj(10).Put("h", ((V)(15D))).Put("ant", ((V)(160D))).Put("up", ((V)(260D))).Put("dn", ((V)(240D))).Put("c", ((V)(0.26))).Put("arm", ((V)(60D))).Put("x", ((V)((-6D)))).Put("st", ((V)(1.1))).Put("air", NewObj(1).Put("tilt", ((V)((-3D)))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_18, V.Undef, t_867, NewObj(10).Put("h", ((V)(17D))).Put("ant", ((V)(150D))).Put("up", ((V)(280D))).Put("dn", ((V)(260D))).Put("c", ((V)(0.26))).Put("arm", ((V)(60D))).Put("x", ((V)(6D))).Put("st", ((V)(1.1))).Put("air", NewObj(1).Put("tilt", ((V)(3D))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_18, V.Undef, t_867, NewObj(8).Put("h", ((V)(13D))).Put("ant", ((V)(150D))).Put("up", ((V)(240D))).Put("dn", ((V)(220D))).Put("c", ((V)(0.24))).Put("arm", ((V)(50D))).Put("x", ((V)(0D))).Put("st", ((V)(1.1))).V);
Invoke(Invoke(t_867, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), NewObj(2).Put("close", ((V)(0.85))).Put("hap", ((V)(1D))).V, ((V)("io")));
a_869 = Get(t_867, "t");
Call(croak_31, V.Undef, t_867, ((V)(4D)), ((V)(400D)));
Invoke(t_867, "at", a_869);
Call(swing_20, V.Undef, t_867, ((V)(1600D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(3D))).Put("bend", ((V)(2D))).Put("x", ((V)(1D))).V);
Invoke(t_867, "at", Add(a_869, ((V)(1600D))));
Invoke(t_867, "to", ((V)(100D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_867, "to", ((V)(250D)), NewObj(3).Put("lx", ((V)((-0.8)))).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.15))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(500D)), NewObj(2).Put("lx", ((V)(0.8))).Put("hyaw", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(150D)));
Invoke(Invoke(Invoke(Invoke(t_867, "to", ((V)(90D)), NewObj(4).Put("tongue", ((V)(1D))).Put("open", ((V)(0.5))).Put("pitch", ((V)(0.2))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(4).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("sq", ((V)(0.08))).Put("pitch", ((V)((-0.06)))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(6).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(120D)));
Call(jump_18, V.Undef, t_867, NewObj(10).Put("h", ((V)(20D))).Put("ant", ((V)(220D))).Put("up", ((V)(330D))).Put("dn", ((V)(300D))).Put("c", ((V)(0.3))).Put("arm", ((V)(80D))).Put("spin", ((V)(360D))).Put("st", ((V)(1.15))).Put("land", NewObj(3).Put("sq", ((V)(0.38))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(1D))), Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))))).V);
Invoke(t_867, "to", ((V)(150D)), NewObj(1).Put("hap", ((V)(0D))).V, ((V)("io")));
return Invoke(t_867, "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Lily Pad Hop")), ((V)("Squat-spring bounces, a croak, big leaps left and right, a croak song with his throat puffing, catches a fly with his tongue, and a spinning belly flop splash.")))).Put("happy", Arr(Call(Fn((V _self1, int _argc872, V _a874, V _a875, V _a876, V _a877, V[] _rest873) => {
V t_878 = default;
t_878 = Call(TL_12, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Call(jump_18, V.Undef, t_878, NewObj(6).Put("h", ((V)(12D))).Put("ant", ((V)(150D))).Put("up", ((V)(220D))).Put("c", ((V)(0.24))).Put("arm", ((V)(50D))).Put("st", ((V)(1.2))).V);
Call(croak_31, V.Undef, t_878, ((V)(1D)), ((V)(340D)));
Call(jump_18, V.Undef, t_878, NewObj(7).Put("h", ((V)(14D))).Put("ant", ((V)(140D))).Put("up", ((V)(240D))).Put("c", ((V)(0.26))).Put("arm", ((V)(56D))).Put("st", ((V)(1.2))).Put("ev", Arr(Arr(((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(1D))))).V);
Call(croak_31, V.Undef, t_878, ((V)(1D)), ((V)(340D)));
return Object_assign(Invoke(t_878, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_878, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Springy happy hops, a croak with his throat puffing after each.")))).Put("surprised", Arr(Call(Fn((V _self1, int _argc879, V _a881, V _a882, V _a883, V _a884, V[] _rest880) => {
V t_885 = default;
V a_886 = default;
t_885 = Call(TL_12, V.Undef);
Invoke(Invoke(t_885, "wait", ((V)(120D))), "to", ((V)(70D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)(0.12))).V, ((V)("o")));
Call(jump_18, V.Undef, t_885, NewObj(7).Put("h", ((V)(14D))).Put("ant", ((V)(50D))).Put("up", ((V)(240D))).Put("c", ((V)(0.12))).Put("arm", ((V)(70D))).Put("st", ((V)(1.3))).Put("land", NewObj(1).Put("sq", ((V)(0.3))).V).V);
Invoke(t_885, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.14))).V, ((V)("io")));
Call(croak_31, V.Undef, t_885, ((V)(1D)), ((V)(400D)));
Call(look_21, V.Undef, t_885, ((V)(0D)), ((V)((-0.55))), NewObj(1).Put("k", ((V)(0.6))).V);
Invoke(t_885, "wait", ((V)(150D)));
a_886 = Get(t_885, "t");
Call(look_21, V.Undef, t_885, ((V)((-0.55))), ((V)(0.55)), NewObj(1).Put("k", ((V)(0.6))).V);
Invoke(t_885, "wait", ((V)(150D)));
Call(look_21, V.Undef, t_885, ((V)(0.55)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.6))).V);
Invoke(t_885, "to", ((V)(400D)), NewObj(3).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).Put("smile", ((V)(0.8))).V, ((V)("io")));
return Invoke(Invoke(t_885, "rest", ((V)(500D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Eyes bulge, springs straight up and lands in a squat, a croak, then looks around.")))).Put("quirk", Arr(Call(Fn((V _self1, int _argc887, V _a889, V _a890, V _a891, V _a892, V[] _rest888) => {
V t_893 = default;
t_893 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_893, "to", ((V)(220D)), NewObj(2).Put("lx", ((V)((-0.8)))).Put("ly", ((V)((-0.6)))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(600D)), NewObj(3).Put("lx", ((V)(0.8))).Put("ly", ((V)((-0.8)))).Put("hyaw", ((V)(0.15))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(3).Put("lx", ((V)((-0.2)))).Put("ly", ((V)((-0.5)))).Put("hyaw", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(120D)));
Invoke(Invoke(Invoke(t_893, "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0.1))).Put("pitch", ((V)((-0.06)))).V, ((V)("io"))), "to", ((V)(80D)), NewObj(4).Put("tongue", ((V)(1D))).Put("open", ((V)(0.5))).Put("sq", ((V)((-0.06)))).Put("pitch", ((V)(0.16))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(4).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.06)))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_893, "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0.06))).Put("puff", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0D))).Put("puff", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_893, "to", ((V)(260D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(8D)), ((V)(2D)))), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(2).Put("hLy", ((V)(4D))).Put("hRy", ((V)(0D))).V, NewObj(2).Put("hLy", ((V)(0D))).Put("hRy", ((V)(4D))).V, ((V)("io"))), "to", ((V)(240D)), Call(o_16, V.Undef, NOHANDS_17), ((V)("io")));
return Invoke(Invoke(Invoke(t_893, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Fly snack")), ((V)("Watches a fly buzz past, zaps it with his tongue, gulps and pats his belly.")))).Put("squish", Arr(Call(Fn((V _self1, int _argc894, V _a896, V _a897, V _a898, V _a899, V[] _rest895) => {
V t_900 = default;
t_900 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_900, "to", ((V)(130D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.36))).Put("puff", ((V)(1.2))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("wide", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(380D)));
Invoke(t_900, "to", ((V)(10D)), NewObj(1).Put("puff", ((V)(0D))).V);
Call(jump_18, V.Undef, t_900, NewObj(6).Put("h", ((V)(12D))).Put("ant", ((V)(40D))).Put("up", ((V)(220D))).Put("c", ((V)(0.36))).Put("arm", ((V)(60D))).Put("st", ((V)(1.3))).V);
Invoke(t_900, "to", ((V)(100D)), NewObj(1).Put("wide", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_900, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_900, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, his throat puffs right out - let go and he springs up high.")))).Put("press", NewObj(2).Put("puff", ((V)(1.1))).Put("wide", ((V)(0.4))).V).Put("rel", NewObj(2).Put("dur", ((V)(1000D))).Put("k", NewObj(4).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(13D)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("i"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(260D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(420D)), ((V)((-0.08))), ((V)("i"))), Arr(((V)(520D)), ((V)(0.22)), ((V)("o"))), Arr(((V)(660D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(60D)), ((V)("o"))), Arr(((V)(500D)), ((V)(20D)), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(60D)), ((V)("o"))), Arr(((V)(500D)), ((V)(20D)), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).V).V).V);
PRESS_32 = Set(R_8, "PRESS", (Get(R_8, "PRESS") is var _t901 && Truthy(_t901) ? _t901 : NewObj(0).V));
REL_33 = Set(R_8, "REL", (Get(R_8, "REL") is var _t902 && Truthy(_t902) ? _t902 : NewObj(0).V));
install_34 = Fn((V _self1, int _argc903, V MOVES_909, V CARDS_910, V _a907, V _a908, V[] _rest904) => {
V ST_911 = default;
V QUIRK_912 = default;
V QK_913 = default;
V hook_914 = default;
double tries_915 = 0;
ST_911 = NewObj(0).V;
QUIRK_912 = Arr();
Invoke(Object_keys(MOVES_909), "forEach", Fn((V _self1, int _argc916, V key_922, V _a919, V _a920, V _a921, V[] _rest917) => {
V M_923 = default;
V D_924 = default;
M_923 = GetK(MOVES_909, key_922);
D_924 = SetK(DESC_11, key_922, (GetK(DESC_11, key_922) is var _t925 && Truthy(_t925) ? _t925 : NewObj(0).V));
Invoke(Arr(((V)("dance")), ((V)("happy")), ((V)("surprised")), ((V)("squish"))), "forEach", Fn((V _self1, int _argc926, V n_932, V _a929, V _a930, V _a931, V[] _rest927) => {
if (Truthy(GetK(M_923, n_932))) {
SetK(ST_911, ((V)(string.Concat(ToStr(n_932), "@", ToStr(key_922)))), GetIdx(GetK(M_923, n_932), 0D));
SetK(D_924, n_932, Arr(GetIdx(GetK(M_923, n_932), 1D), GetIdx(GetK(M_923, n_932), 2D)));
}
return default;
}, 1, "", true));
if (Truthy(Get(M_923, "quirk"))) {
SetK(ST_911, ((V)(string.Concat("idle_quirk@", ToStr(key_922)))), Object_assign(GetIdx(Get(M_923, "quirk"), 0D), NewObj(1).Put("next", ((V)("idle"))).V));
Set(D_924, "idle_quirk", Arr(GetIdx(Get(M_923, "quirk"), 1D), GetIdx(Get(M_923, "quirk"), 2D)));
Invoke(QUIRK_912, "push", key_922);
}
if (Truthy(Get(M_923, "look"))) {
SetK(ST_911, ((V)(string.Concat("idle_look@", ToStr(key_922)))), Get(M_923, "look"));
}
if (Truthy(Get(M_923, "press"))) {
SetK(PRESS_32, key_922, Get(M_923, "press"));
}
if (Truthy(Get(M_923, "rel"))) {
SetK(REL_33, key_922, Get(M_923, "rel"));
}
return default;
}, 1, "", true));
{
foreach (V _k933 in ForInKeys(CARDS_910)) {
V key_934 = default;
key_934 = _k933;
SetK(CARD_25, key_934, GetK(CARDS_910, key_934));
Invoke(SHARED_28, "forEach", Fn((V _self1, int _argc935, V n_941, V _a938, V _a939, V _a940, V[] _rest936) => {
V nm_942 = default;
V f_943 = default;
nm_942 = ((V)(string.Concat(ToStr(n_941), "@", ToStr(key_934))));
if (Truthy(((GetK(ST_911, nm_942) is var _t944 && Truthy(_t944) ? _t944 : GetK(Get(R_8, "STATES"), nm_942)) is var _t945 && Truthy(_t945) ? _t945 : (!(Truthy(GetK(Get(R_8, "STATES"), n_941))) ? V.True : V.False)))) {
return default;
}
f_943 = Call(flavor_27, V.Undef, GetK(Get(R_8, "STATES"), n_941), GetK(CARDS_910, key_934));
if (Truthy(f_943)) {
SetK(ST_911, nm_942, f_943);
}
return default;
}, 1, "", true));
}
}
Invoke(R_8, "add", ST_911);
QK_913 = Set(R_8, "QUIRKK", (Get(R_8, "QUIRKK") is var _t946 && Truthy(_t946) ? _t946 : New(G("Set"))));
Invoke(QUIRK_912, "forEach", Fn((V _self1, int _argc947, V k_953, V _a950, V _a951, V _a952, V[] _rest948) => {
return Invoke(QK_913, "add", k_953);
}, 1, "", true));
hook_914 = Fn((V _self1, int _argc954, V _a956, V _a957, V _a958, V _a959, V[] _rest955) => {
V W_960 = default;
V b_961 = default;
W_960 = Get(G("window"), "HouseIdle");
if (Truthy(((!(Truthy(W_960)) ? V.True : V.False) is var _t962 && Truthy(_t962) ? _t962 : Get(W_960, "__q")))) {
return default;
}
Set(W_960, "__q", ((V)(1D)));
b_961 = Get(W_960, "build");
Set(W_960, "build", Fn((V _self963, int _argc964, V key_970, V _a967, V _a968, V _a969, V[] _rest965) => {
V r_972 = default;
V L_973 = default;
if (_self963.IsNullish) _self963 = GlobalV;
V _arguments971 = Arguments(_argc964, key_970, _a967, _a968, _a969, _rest965);
r_972 = Invoke(b_961, "apply", _self963, _arguments971);
L_973 = GetK(Get(R_8, "FIDK"), key_970);
if (Truthy(((Invoke(QK_913, "has", key_970) is var _t974 && !Truthy(_t974) ? _t974 : L_973) is var _t975 && !Truthy(_t975) ? _t975 : (!(Truthy(Invoke(L_973, "includes", ((V)("idle_quirk"))))) ? V.True : V.False)))) {
Invoke(L_973, "push", ((V)("idle_quirk")));
}
return r_972;
return default;
}, 1, "", false));
return default;
}, 0, "", true);
tries_915 = 0D;
Call(Named(addFid_993 => Fn((V _self976, int _argc977, V _a979, V _a980, V _a981, V _a982, V[] _rest978) => {
double left_983 = 0;
if (_self976.IsNullish) _self976 = GlobalV;
Call(hook_914, V.Undef);
left_983 = 0D;
Invoke(QUIRK_912, "forEach", Fn((V _self976, int _argc984, V key_990, V _a987, V _a988, V _a989, V[] _rest985) => {
V L_991 = default;
L_991 = GetK(Get(R_8, "FIDK"), key_990);
if (!(Truthy(L_991))) {
left_983++;
return default;
}
if (!(Truthy(Invoke(L_991, "includes", ((V)("idle_quirk")))))) {
Invoke(L_991, "push", ((V)("idle_quirk")));
}
return default;
}, 1, "", true));
if (Truthy((((V)(left_983)) is var _t992 && !Truthy(_t992) ? _t992 : ((++tries_915 < 120D) ? V.True : V.False)))) {
Call(G("setTimeout"), V.Undef, addFid_993.v, ((V)(100D)));
} else {
if (Truthy((((V)(left_983)) is var _t994 && !Truthy(_t994) ? _t994 : Get(R_8, "idleV")))) {
Invoke(QUIRK_912, "forEach", Fn((V _self976, int _argc995, V key_1001, V _a998, V _a999, V _a1000, V[] _rest996) => {
if (!(Truthy(GetK(Get(R_8, "FIDK"), key_1001)))) {
SetK(Get(R_8, "FIDK"), key_1001, Invoke(Invoke(Get(R_8, "FIDGETS"), "filter", Fn((V _self976, int _argc1002, V n_1008, V _a1005, V _a1006, V _a1007, V[] _rest1003) => {
return (!SEqS(n_1008, "idle_waveL") ? V.True : V.False);
}, 1, "", true)), "concat", ((V)("idle_quirk"))));
}
return default;
}, 1, "", true));
}
}
return default;
}, 0, "addFid", false)), V.Undef);
return default;
}, 2, "", true);
Invoke(R_8, "add", NewObj(1).Put("idle_quirk", Object_assign(NewObj(0).V, Get(Get(R_8, "STATES"), "idle_yawn"), NewObj(1).Put("next", ((V)("idle"))).V)).V);
Set(R_8, "PETLIB", NewObj(19).Put("TL", TL_12).Put("S", S_13).Put("hand", hand_14).Put("both", both_15).Put("o", o_16).Put("NOHANDS", NOHANDS_17).Put("jump", jump_18).Put("look", look_21).Put("shake", shake_22).Put("swing", swing_20).Put("steps", steps_19).Put("jelly", jelly_23).Put("land", land_24).Put("popcorn", popcorn_30).Put("croak", croak_31).Put("CARD", CARD_25).Put("DESC", DESC_11).Put("install", install_34).Put("flavor", flavor_27).V);
Call(install_34, V.Undef, MOVES_29, Object_assign(NewObj(0).V, CARD_25));
Set(R_8, "HS", (Get(R_8, "HS") is var _t1009 && Truthy(_t1009) ? _t1009 : NewObj(0).V));
G_35 = Invoke(Get(R_8, "GROUPS"), "find", Fn((V _self1, int _argc1010, V g_1016, V _a1013, V _a1014, V _a1015, V[] _rest1011) => {
return (SEqS(Get(g_1016, "name"), "Idle") ? V.True : V.False);
}, 1, "", true));
if (Truthy((G_35 is var _t1024 && !Truthy(_t1024) ? _t1024 : (!(Truthy(Invoke(Get(G_35, "items"), "some", Fn((V _self1, int _argc1017, V i_1023, V _a1020, V _a1021, V _a1022, V[] _rest1018) => {
return (SEqS(GetIdx(i_1023, 0D), "idle_quirk") ? V.True : V.False);
}, 1, "", true)))) ? V.True : V.False)))) {
Invoke(Get(G_35, "items"), "splice", ((V)(2D)), ((V)(0D)), Arr(((V)("idle_quirk")), ((V)("Little habit")), ((V)("A habit of its own."))));
}
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
