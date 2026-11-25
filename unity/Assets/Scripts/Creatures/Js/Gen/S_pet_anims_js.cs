// pet-anims.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_pet_anims_js
    {

        public static void Run()
        {
Call(Named(boot_204 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
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
B0_45 = Fn((V _arrowThis60, int _argc53, V p_59, V _a56, V _a57, V _a58, V[] _rest54) => {
return (HasProperty(@base_43, p_59) ? GetK(@base_43, p_59) : GetK(REST_9, p_59));
}, 1, "", true);
k_46 = NewObj(0).V;
ev_47 = Arr();
em_48 = Arr();
t_49 = ((V)(0D));
o_50 = NewObj(12).Getter("t", Fn((V _self61, int _argc62, V _a64, V _a65, V _a66, V _a67, V[] _rest63) => {
if (_self61.IsNullish) _self61 = GlobalV;
return t_49;
return default;
}, 0, "t", false)).Put("b", B0_45).Put("to", Fn((V _self68, int _argc69, V dt_75, V v_76, V ez_77, V _a74, V[] _rest70) => {
if (_self68.IsNullish) _self68 = GlobalV;
dt_75 = ((V)((ToNum(dt_75) * ToNum(T_44))));
{
foreach (V _k78 in ForInKeys(v_76)) {
V p_79 = default;
p_79 = _k78;
V L_80 = default;
L_80 = (GetK(k_46, p_79) is var _t81 && Truthy(_t81) ? _t81 : SetK(k_46, p_79, Arr(Arr(((V)(0D)), Call(B0_45, V.Undef, p_79)))));
if (Lt(GetIdx(GetIdx(L_80, (ToNum(Get(L_80, "length")) - 1D)), 0D), t_49)) {
Invoke(L_80, "push", Arr(t_49, GetIdx(GetIdx(L_80, (ToNum(Get(L_80, "length")) - 1D)), 1D), ((V)("l"))));
}
}
}
t_49 = Add(t_49, dt_75);
{
foreach (V _k82 in ForInKeys(v_76)) {
V p_83 = default;
p_83 = _k82;
Invoke(GetK(k_46, p_83), "push", Arr(t_49, GetK(v_76, p_83), (ez_77 is var _t84 && Truthy(_t84) ? _t84 : ((V)("io")))));
}
}
return o_50;
return default;
}, 3, "to", false)).Put("wait", Fn((V _self85, int _argc86, V dt_92, V _a89, V _a90, V _a91, V[] _rest87) => {
if (_self85.IsNullish) _self85 = GlobalV;
t_49 = Add(t_49, ((V)((ToNum(dt_92) * ToNum(T_44)))));
return o_50;
return default;
}, 1, "wait", false)).Put("at", Fn((V _self93, int _argc94, V x_100, V _a97, V _a98, V _a99, V[] _rest95) => {
if (_self93.IsNullish) _self93 = GlobalV;
t_49 = x_100;
return o_50;
return default;
}, 1, "at", false)).Put("e", Fn((V _self101, int _argc102, V _a104, V _a105, V _a106, V _a107, V[] _rest103) => {
V a_108 = default;
if (_self101.IsNullish) _self101 = GlobalV;
a_108 = RestArgs(0, _argc102, _a104, _a105, _a106, _a107, _rest103);
Invoke(ev_47, "push", new ArrBuilder().Add(t_49).Spread(a_108).V);
return o_50;
return default;
}, 1, "e", false)).Put("em", Fn((V _self109, int _argc110, V dur_116, V every_117, V preset_118, V where_119, V[] _rest111) => {
V n_120 = default;
if (_self109.IsNullish) _self109 = GlobalV;
n_120 = (_argc110 > 4 ? _rest111[0] : V.Undef);
Invoke(em_48, "push", Arr(t_49, Add(t_49, dur_116), every_117, preset_118, where_119, n_120));
return o_50;
return default;
}, 5, "em", false)).Put("osc", Fn((V _self121, int _argc122, V dt_128, V n_129, V A_130, V B_131, V[] _rest123) => {
double h_133 = 0;
V ez_132 = default;
if (_self121.IsNullish) _self121 = GlobalV;
ez_132 = (_argc122 > 4 ? _rest123[0] : V.Undef);
h_133 = ((ToNum(dt_128) / ToNum(n_129)) / 2D);
{
double i_134 = 0;
i_134 = 0D;
while (true) {
if (!(Lt(((V)(i_134)), n_129))) break;
Invoke(Invoke(o_50, "to", ((V)(h_133)), A_130, (ez_132 is var _t137 && Truthy(_t137) ? _t137 : ((V)("io")))), "to", ((V)(h_133)), B_131, (ez_132 is var _t136 && Truthy(_t136) ? _t136 : ((V)("io"))));
i_134++;
}
}
return o_50;
return default;
}, 5, "osc", false)).Put("rest", Fn((V _self138, int _argc139, V dt_145, V ez_146, V _a143, V _a144, V[] _rest140) => {
V b_147 = default;
if (_self138.IsNullish) _self138 = GlobalV;
b_147 = NewObj(0).V;
{
foreach (V _k148 in ForInKeys(k_46)) {
V p_149 = default;
p_149 = _k148;
SetK(b_147, p_149, Call(B0_45, V.Undef, p_149));
}
}
return Invoke(o_50, "to", (dt_145 is var _t150 && Truthy(_t150) ? _t150 : ((V)(450D))), b_147, ez_146);
return default;
}, 2, "rest", false)).Put("out", Fn((V _self151, int _argc152, V x_158, V loop_159, V _a156, V _a157, V[] _rest153) => {
if (_self151.IsNullish) _self151 = GlobalV;
{
foreach (V _k160 in ForInKeys(@base_43)) {
V p_161 = default;
p_161 = _k160;
if (!(Truthy(GetK(k_46, p_161)))) {
SetK(k_46, p_161, Arr(Arr(((V)(0D)), GetK(@base_43, p_161))));
}
}
}
{
foreach (V _k162 in ForInKeys(k_46)) {
V p_163 = default;
p_163 = _k162;
V L_164 = default;
L_164 = Invoke(GetK(k_46, p_163), "sort", Fn((V _arrowThis173, int _argc165, V a_171, V b_172, V _a169, V _a170, V[] _rest166) => {
return ((V)((ToNum(GetIdx(a_171, 0D)) - ToNum(GetIdx(b_172, 0D)))));
}, 2, "", true));
if ((GtN(Get(L_164, "length"), 1D) && Lt(GetIdx(GetIdx(L_164, (ToNum(Get(L_164, "length")) - 1D)), 0D), t_49))) {
Invoke(L_164, "push", Arr(t_49, GetIdx(GetIdx(L_164, (ToNum(Get(L_164, "length")) - 1D)), 1D), ((V)("l"))));
}
if (Truthy((loop_159 is var _t174 && !Truthy(_t174) ? _t174 : (GtN(Get(L_164, "length"), 1D) ? V.True : V.False)))) {
V a_175 = default;
V b_176 = default;
a_175 = GetIdx(GetIdx(L_164, 0D), 1D);
b_176 = GetIdx(GetIdx(L_164, (ToNum(Get(L_164, "length")) - 1D)), 1D);
if ((SEqS(p_163, "spin") ? (System.Math.Abs((((((ToNum(b_176) - ToNum(a_175)) % 360D) + 540D) % 360D) - 180D)) > 0.5) : (System.Math.Abs((ToNum(b_176) - ToNum(a_175))) > 0.000001))) {
Invoke(Set(R_8, "LOOPWARN", (Get(R_8, "LOOPWARN") is var _t177 && Truthy(_t177) ? _t177 : Arr())), "push", ((V)(JsStrBuf.Begin().V(p_163).S(" ").V(a_175).S("->").V(b_176).End())));
}
}
}
}
Invoke(ev_47, "sort", Fn((V _arrowThis186, int _argc178, V a_184, V b_185, V _a182, V _a183, V[] _rest179) => {
return ((V)((ToNum(GetIdx(a_184, 0D)) - ToNum(GetIdx(b_185, 0D)))));
}, 2, "", true));
return Object_assign((Truthy(loop_159) ? NewObj(1).Put("loop", t_49).V : NewObj(1).Put("dur", t_49).V), NewObj(3).Put("k", k_46).Put("ev", ev_47).Put("emit", em_48).V, (x_158 is var _t187 && Truthy(_t187) ? _t187 : NewObj(0).V));
return default;
}, 2, "out", false)).Put("done", Fn((V _self188, int _argc189, V x_195, V _a192, V _a193, V _a194, V[] _rest190) => {
if (_self188.IsNullish) _self188 = GlobalV;
return Invoke(o_50, "out", x_195);
return default;
}, 1, "done", false)).Put("loop", Fn((V _self196, int _argc197, V x_203, V _a200, V _a201, V _a202, V[] _rest198) => {
if (_self196.IsNullish) _self196 = GlobalV;
return Invoke(o_50, "out", x_203, (true ? V.True : V.False));
return default;
}, 1, "loop", false)).V;
return o_50;
return default;
}, 2, "TL", false);
R_8 = Get(G("window"), "RiveRig");
if (((((!(Truthy(R_8)) || !(Truthy(Get(R_8, "REST")))) || !(Truthy(Get(R_8, "GROUPS")))) || !(Truthy(Get(Get(R_8, "STATES"), "dance")))) || !(Truthy(Get(Get(R_8, "STATES"), "poke_head"))))) {
Call(G("setTimeout"), V.Undef, boot_204.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_8, "petV"))) {
return default;
}
Set(R_8, "petV", ((V)(1D)));
REST_9 = Get(R_8, "REST");
ST_10 = NewObj(0).V;
DESC_11 = Set(R_8, "DESC", (Get(R_8, "DESC") is var _t205 && Truthy(_t205) ? _t205 : NewObj(0).V));
S_13 = Fn((V _arrowThis213, int _argc206, V s_212, V _a209, V _a210, V _a211, V[] _rest207) => {
return (LtN(s_212, 0D) ? NewObj(7).Put("arm", ((V)("armL"))).Put("hx", ((V)("hLx"))).Put("hy", ((V)("hLy"))).Put("ear", ((V)("earL"))).Put("wink", ((V)("winkL"))).Put("foot", ((V)("footL"))).Put("paw", ((V)("pawL"))).V : NewObj(7).Put("arm", ((V)("armR"))).Put("hx", ((V)("hRx"))).Put("hy", ((V)("hRy"))).Put("ear", ((V)("earR"))).Put("wink", ((V)("winkR"))).Put("foot", ((V)("footR"))).Put("paw", ((V)("pawR"))).V);
}, 1, "", true);
hand_14 = Fn((V _arrowThis223, int _argc214, V s_220, V inX_221, V y_222, V _a219, V[] _rest215) => {
V k_224 = default;
k_224 = Call(S_13, V.Undef, s_220);
return NewObj(2).PutK(Get(k_224, "hx"), (LtN(s_220, 0D) ? inX_221 : ((V)((-ToNum(inX_221)))))).PutK(Get(k_224, "hy"), y_222).V;
return default;
}, 3, "", true);
both_15 = Fn((V _arrowThis233, int _argc225, V inX_231, V y_232, V _a229, V _a230, V[] _rest226) => {
return Object_assign(Call(hand_14, V.Undef, ((V)((-1D))), inX_231, y_232), Call(hand_14, V.Undef, ((V)(1D)), inX_231, y_232));
}, 2, "", true);
o_16 = Fn((V _arrowThis241, int _argc234, V _a236, V _a237, V _a238, V _a239, V[] _rest235) => {
V a_240 = default;
a_240 = RestArgs(0, _argc234, _a236, _a237, _a238, _a239, _rest235);
return InvokeSpread(G("Object"), "assign", new ArrBuilder().Add(NewObj(0).V).Spread(a_240).V);
}, 1, "", true);
NOHANDS_17 = Call(both_15, V.Undef, ((V)(0D)), ((V)(0D)));
jump_18 = Fn((V _arrowThis250, int _argc242, V t_248, V J_249, V _a246, V _a247, V[] _rest243) => {
V h_251 = default;
V up_252 = default;
V dn_253 = default;
V c_254 = default;
V ant_255 = default;
V arm_256 = default;
V st_257 = default;
V a_258 = default;
V b_259 = default;
J_249 = (J_249 is var _t260 && Truthy(_t260) ? _t260 : NewObj(0).V);
h_251 = (Get(J_249, "h") is var _t261 && Truthy(_t261) ? _t261 : ((V)(12D)));
up_252 = (Get(J_249, "up") is var _t262 && Truthy(_t262) ? _t262 : ((V)(260D)));
dn_253 = (Get(J_249, "dn") is var _t263 && Truthy(_t263) ? _t263 : ((V)(Round((ToNum(up_252) * 0.92)))));
c_254 = (Get(J_249, "c").IsNullish ? ((V)(0.18)) : Get(J_249, "c"));
ant_255 = (Get(J_249, "ant") is var _t264 && Truthy(_t264) ? _t264 : ((V)(170D)));
arm_256 = (Get(J_249, "arm").IsNullish ? ((V)(40D)) : Get(J_249, "arm"));
st_257 = (Get(J_249, "st") is var _t265 && Truthy(_t265) ? _t265 : ((V)(1D)));
Invoke(t_248, "to", ant_255, Call(o_16, V.Undef, NewObj(4).Put("sq", c_254).Put("pitch", ((V)((-0.1)))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).V, Get(J_249, "pre")), ((V)("io")));
a_258 = Get(t_248, "t");
Invoke(Invoke(t_248, "to", up_252, Call(o_16, V.Undef, NewObj(1).Put("lift", h_251).V, Get(J_249, "air")), ((V)("o"))), "to", dn_253, Call(o_16, V.Undef, NewObj(1).Put("lift", ((V)(0D))).V, Get(J_249, "fall")), ((V)("i")));
b_259 = Get(t_248, "t");
if (!Get(J_249, "x").IsNullish) {
Invoke(Invoke(t_248, "at", ((V)((ToNum(a_258) - 30D)))), "to", Add(Add(up_252, dn_253), ((V)(30D))), NewObj(1).Put("x", Get(J_249, "x")).V, ((V)("io")));
}
if (Truthy(Get(J_249, "spin"))) {
Invoke(Invoke(t_248, "at", a_258), "to", Add(up_252, dn_253), NewObj(1).Put("spin", Get(J_249, "spin")).V, ((V)("io")));
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_248, "at", a_258), "to", ((V)(80D)), NewObj(1).Put("sq", ((V)(((-0.16) * ToNum(st_257))))).V, ((V)("o"))), "to", ((V)((ToNum(up_252) - 80D))), NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("io"))), "to", ((V)((ToNum(dn_253) * 0.6))), NewObj(1).Put("sq", ((V)((-0.02)))).V, ((V)("io"))), "to", ((V)((ToNum(dn_253) * 0.4))), NewObj(1).Put("sq", ((V)(((-0.09) * ToNum(st_257))))).V, ((V)("i")));
Invoke(Invoke(Invoke(t_248, "at", Add(a_258, ((V)(40D)))), "to", ((V)((ToNum(up_252) - 40D))), NewObj(3).Put("armL", arm_256).Put("armR", arm_256).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "to", dn_253, NewObj(3).Put("armL", ((V)((ToNum(arm_256) * 0.6)))).Put("armR", ((V)((ToNum(arm_256) * 0.6)))).Put("pitch", ((V)((-0.04)))).V, ((V)("io")));
Invoke(t_248, "at", b_259);
if (Truthy(Get(J_249, "spin"))) {
Invoke(t_248, "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
}
Invoke((Get(J_249, "ev") is var _t274 && Truthy(_t274) ? _t274 : Arr()), "forEach", Fn((V _arrowThis273, int _argc266, V e_272, V _a269, V _a270, V _a271, V[] _rest267) => {
return InvokeSpread(t_248, "e", new ArrBuilder().Spread(e_272).V);
}, 1, "", true));
if (Truthy(Get(J_249, "chain"))) {
return Invoke(t_248, "to", ((V)(80D)), Call(o_16, V.Undef, NewObj(4).Put("sq", ((V)((ToNum(c_254) * 1.1)))).Put("pitch", ((V)((-0.08)))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).V, Get(J_249, "land")), ((V)("o")));
}
return Invoke(Invoke(Invoke(t_248, "to", ((V)(80D)), Call(o_16, V.Undef, NewObj(4).Put("sq", ((V)((ToNum(c_254) * 1.2)))).Put("pitch", ((V)((-0.12)))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).V, Get(J_249, "land")), ((V)("o"))), "to", ((V)(150D)), NewObj(4).Put("sq", ((V)((-0.05)))).Put("pitch", ((V)(0.03))).Put("armL", ((V)(4D))).Put("armR", ((V)(4D))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(4).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
steps_19 = Fn((V _arrowThis285, int _argc275, V t_281, V dur_282, V n_283, V h_284, V[] _rest276) => {
double q_286 = 0;
q_286 = ((ToNum(dur_282) / ToNum(n_283)) / 2D);
{
double i_287 = 0;
i_287 = 0D;
while (true) {
if (!(Lt(((V)(i_287)), n_283))) break;
V f_289 = default;
f_289 = ((V)((NumTruthy((i_287 % 2D)) ? "footR" : "footL")));
Invoke(Invoke(t_281, "to", ((V)(q_286)), NewObj(1).PutK(f_289, h_284).V, ((V)("o"))), "to", ((V)(q_286)), NewObj(1).PutK(f_289, ((V)(0D))).V, ((V)("i")));
i_287++;
}
}
return t_281;
return default;
}, 4, "", true);
swing_20 = Fn((V _arrowThis301, int _argc290, V t_296, V dur_297, V n_298, V A_299, V[] _rest291) => {
double h_302 = 0;
V z_303 = default;
V ez_300 = default;
ez_300 = (_argc290 > 4 ? _rest291[0] : V.Undef);
h_302 = (ToNum(dur_297) / ToNum(Add(n_298, ((V)(1D)))));
{
double i_304 = 0;
i_304 = 0D;
while (true) {
if (!(Lt(((V)(i_304)), n_298))) break;
V v_306 = default;
v_306 = NewObj(0).V;
{
foreach (V _k307 in ForInKeys(A_299)) {
V p_308 = default;
p_308 = _k307;
SetK(v_306, p_308, Add(Invoke(t_296, "b", p_308), ((V)((ToNum(GetK(A_299, p_308)) * (NumTruthy((i_304 % 2D)) ? (-1D) : 1D))))));
}
}
Invoke(t_296, "to", ((V)(h_302)), v_306, (ez_300 is var _t309 && Truthy(_t309) ? _t309 : ((V)("io"))));
i_304++;
}
}
z_303 = NewObj(0).V;
{
foreach (V _k310 in ForInKeys(A_299)) {
V p_311 = default;
p_311 = _k310;
SetK(z_303, p_311, Invoke(t_296, "b", p_311));
}
}
return Invoke(t_296, "to", ((V)(h_302)), z_303, (ez_300 is var _t312 && Truthy(_t312) ? _t312 : ((V)("io"))));
return default;
}, 5, "", true);
look_21 = Fn((V _arrowThis323, int _argc313, V t_319, V from_320, V to_321, V J_322, V[] _rest314) => {
V s_324 = default;
double dir_325 = 0;
V k_326 = default;
V d1_327 = default;
V d2_328 = default;
V T_329 = default;
double bendTo_330 = 0;
double twTo_331 = 0;
V e1_332 = default;
J_322 = (J_322 is var _t333 && Truthy(_t333) ? _t333 : NewObj(0).V);
s_324 = (((V)(Sign((ToNum(to_321) - ToNum(from_320))))) is var _t334 && Truthy(_t334) ? _t334 : ((V)(1D)));
dir_325 = Sign(ToNum(to_321));
k_326 = (Get(J_322, "k").IsNullish ? ((V)(1D)) : Get(J_322, "k"));
d1_327 = (Get(J_322, "d1") is var _t335 && Truthy(_t335) ? _t335 : ((V)(170D)));
d2_328 = (Get(J_322, "d2") is var _t336 && Truthy(_t336) ? _t336 : ((V)(210D)));
T_329 = Get(t_319, "t");
bendTo_330 = ((dir_325 * 4D) * ToNum(k_326));
twTo_331 = ((ToNum(to_321) * 0.36) * ToNum(k_326));
Invoke(Invoke(Invoke(Invoke(Invoke(t_319, "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((dir_325 * 0.9)))).V, ((V)("o"))), "e", ((V)("blink"))), "to", d1_327, NewObj(4).Put("hyaw", ((V)((ToNum(Add(from_320, to_321)) / 2D)))).Put("pitch", ((V)((-0.2)))).Put("earL", ((V)((ToNum(s_324) * 7D)))).Put("earR", ((V)(((-ToNum(s_324)) * 7D)))).V, ((V)("i"))), "to", d2_328, NewObj(5).Put("hyaw", Add(to_321, ((V)((ToNum(s_324) * 0.08))))).Put("pitch", ((V)(0.05))).Put("earL", ((V)(((-ToNum(s_324)) * 3D)))).Put("earR", ((V)((ToNum(s_324) * 3D)))).Put("htilt", ((V)(((dir_325 * 3D) - bendTo_330)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("hyaw", to_321).Put("pitch", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
e1_332 = Get(t_319, "t");
Invoke(Invoke(Invoke(t_319, "at", Add(T_329, ((V)(200D)))), "to", Add(d1_327, d2_328), NewObj(2).Put("twist", ((V)((twTo_331 + ((ToNum(s_324) * 0.06) * ToNum(k_326)))))).Put("bend", ((V)((bendTo_330 + ((ToNum(s_324) * 1.2) * ToNum(k_326)))))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(2).Put("twist", ((V)(twTo_331))).Put("bend", ((V)(bendTo_330))).V, ((V)("io")));
return Invoke(t_319, "at", ((V)(Max(ToNum(e1_332), ToNum(Get(t_319, "t"))))));
return default;
}, 4, "", true);
shake_22 = Fn((V _arrowThis345, int _argc337, V t_343, V J_344, V _a341, V _a342, V[] _rest338) => {
V env_346 = default;
V P_347 = default;
V a_348 = default;
V lag_349 = default;
V tr_350 = default;
V e_351 = default;
env_346 = (Get(J_344, "env") is var _t352 && Truthy(_t352) ? _t352 : Arr(((V)(0.45)), ((V)(0.85)), ((V)(1D)), ((V)(1D)), ((V)(0.85)), ((V)(0.6)), ((V)(0.35)), ((V)(0.15))));
P_347 = (Get(J_344, "P") is var _t353 && Truthy(_t353) ? _t353 : ((V)(110D)));
a_348 = Get(t_343, "t");
lag_349 = (Get(J_344, "lag") is var _t354 && Truthy(_t354) ? _t354 : ((V)((ToNum(P_347) * 0.4))));
tr_350 = Fn((V _arrowThis363, int _argc355, V off_361, V f_362, V _a359, V _a360, V[] _rest356) => {
Invoke(t_343, "at", Add(a_348, off_361));
Invoke(env_346, "forEach", Fn((V _arrowThis372, int _argc364, V m_370, V i_371, V _a368, V _a369, V[] _rest365) => {
Invoke(t_343, "to", P_347, Call(f_362, V.Undef, ((V)(((NumTruthy((ToNum(i_371) % 2D)) ? (-1D) : 1D) * ToNum(m_370))))), ((V)("io")));
return default;
}, 2, "", true));
Invoke(t_343, "to", P_347, Call(f_362, V.Undef, ((V)(0D))), ((V)("io")));
return Get(t_343, "t");
return default;
}, 2, "", true);
e_351 = Call(tr_350, V.Undef, ((V)(0D)), Fn((V _arrowThis380, int _argc373, V s_379, V _a376, V _a377, V _a378, V[] _rest374) => {
return NewObj(4).Put("hyaw", ((V)((ToNum(s_379) * ToNum((Get(J_344, "head") is var _t381 && Truthy(_t381) ? _t381 : ((V)(0.38)))))))).Put("htilt", ((V)((ToNum(s_379) * ToNum((Get(J_344, "roll") is var _t382 && Truthy(_t382) ? _t382 : ((V)(4D)))))))).Put("earL", ((V)(((-ToNum(s_379)) * ToNum((Get(J_344, "ear") is var _t383 && Truthy(_t383) ? _t383 : ((V)(12D)))))))).Put("earR", ((V)((ToNum(s_379) * ToNum((Get(J_344, "ear") is var _t384 && Truthy(_t384) ? _t384 : ((V)(12D)))))))).V;
}, 1, "", true));
if (Truthy(Get(J_344, "chest"))) {
e_351 = ((V)(Max(ToNum(e_351), ToNum(Call(tr_350, V.Undef, lag_349, Fn((V _arrowThis392, int _argc385, V s_391, V _a388, V _a389, V _a390, V[] _rest386) => {
return NewObj(1).Put("twist", ((V)((ToNum(s_391) * ToNum(Get(J_344, "chest")))))).V;
}, 1, "", true))))));
}
if (Truthy(Get(J_344, "body"))) {
e_351 = ((V)(Max(ToNum(e_351), ToNum(Call(tr_350, V.Undef, ((V)((ToNum(lag_349) * 1.6))), Fn((V _arrowThis400, int _argc393, V s_399, V _a396, V _a397, V _a398, V[] _rest394) => {
return NewObj(2).Put("x", ((V)((ToNum(s_399) * ToNum(Get(J_344, "body")))))).Put("tilt", ((V)(((ToNum(s_399) * ToNum(Get(J_344, "body"))) * 2.4)))).V;
}, 1, "", true))))));
}
if (Truthy(Get(J_344, "tail"))) {
e_351 = ((V)(Max(ToNum(e_351), ToNum(Call(tr_350, V.Undef, ((V)((ToNum(lag_349) * 2.2))), Fn((V _arrowThis408, int _argc401, V s_407, V _a404, V _a405, V _a406, V[] _rest402) => {
return NewObj(1).Put("wag", ((V)((ToNum(s_407) * ToNum(Get(J_344, "tail")))))).V;
}, 1, "", true))))));
}
return Invoke(t_343, "at", e_351);
return default;
}, 2, "", true);
jelly_23 = Fn((V _arrowThis420, int _argc409, V t_415, V a_416, V n_417, V per_418, V[] _rest410) => {
V ch_419 = default;
ch_419 = (_argc409 > 4 ? _rest410[0] : V.Undef);
ch_419 = (ch_419 is var _t421 && Truthy(_t421) ? _t421 : ((V)("sq")));
{
double i_422 = 0;
i_422 = 0D;
while (true) {
if (!(Lt(((V)(i_422)), n_417))) break;
Invoke(t_415, "to", ((V)((ToNum(per_418) / 2D))), NewObj(1).PutK(ch_419, ((V)((((NumTruthy((i_422 % 2D)) ? 1D : (-1D)) * ToNum(a_416)) * Pow(0.55, i_422))))).V, ((V)("io")));
i_422++;
}
}
return Invoke(t_415, "to", ((V)((ToNum(per_418) / 2D))), NewObj(1).PutK(ch_419, ((V)(0D))).V, ((V)("io")));
return default;
}, 5, "", true);
land_24 = Fn((V _arrowThis434, int _argc424, V t_430, V a_431, V n_432, V per_433, V[] _rest425) => {
V q_435 = default;
V e_436 = default;
q_435 = Get(t_430, "t");
Call(jelly_23, V.Undef, t_430, a_431, n_432, per_433);
e_436 = Get(t_430, "t");
return Invoke(Invoke(Invoke(t_430, "at", q_435), "to", ((V)(Min(320D, (ToNum(e_436) - ToNum(q_435))))), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io"))), "at", e_436);
return default;
}, 4, "", true);
CARD_25 = NewObj(9).Put("biscuit", NewObj(5).Put("T", ((V)(0.86))).Put("b", ((V)(1.2))).Put("s", ((V)(1.1))).Put("w", ((V)(1.6))).Put("e", ((V)(1.3))).V).Put("truffle", NewObj(6).Put("T", ((V)(1.06))).Put("b", ((V)(1.3))).Put("s", ((V)(1.15))).Put("w", ((V)(1D))).Put("e", ((V)(1D))).Put("c", ((V)(1.3))).V).Put("nibbles", NewObj(4).Put("T", ((V)(0.78))).Put("b", ((V)(0.9))).Put("s", ((V)(0.85))).Put("e", ((V)(1.2))).V).Put("quill", NewObj(4).Put("T", ((V)(1.18))).Put("b", ((V)(0.75))).Put("s", ((V)(0.8))).Put("e", ((V)(0.8))).V).Put("waffles", NewObj(5).Put("T", ((V)(0.94))).Put("b", ((V)(1.25))).Put("s", ((V)(1.1))).Put("w", ((V)(1.8))).Put("e", ((V)(1.1))).V).Put("poppy", NewObj(4).Put("T", ((V)(0.86))).Put("b", ((V)(1.15))).Put("s", ((V)(0.9))).Put("e", ((V)(1.4))).V).Put("duchess", NewObj(5).Put("T", ((V)(1.25))).Put("b", ((V)(0.7))).Put("s", ((V)(0.9))).Put("w", ((V)(0.7))).Put("c", ((V)(1.3))).V).Put("mamapaws", NewObj(4).Put("T", ((V)(1.2))).Put("b", ((V)(0.85))).Put("s", ((V)(0.9))).Put("w", ((V)(1.3))).V).Put("ribbit", NewObj(4).Put("T", ((V)(0.9))).Put("b", ((V)(1.3))).Put("s", ((V)(1D))).Put("e", ((V)(1D))).V).V;
GRP_26 = NewObj(10).Put("sq", ((V)("b"))).Put("lift", ((V)("b"))).Put("lean", ((V)("s"))).Put("tilt", ((V)("s"))).Put("x", ((V)("s"))).Put("bend", ((V)("s"))).Put("wag", ((V)("w"))).Put("earL", ((V)("e"))).Put("earR", ((V)("e"))).Put("curl", ((V)("c"))).V;
flavor_27 = Fn((V _arrowThis445, int _argc437, V st_443, V c_444, V _a441, V _a442, V[] _rest438) => {
V T_446 = default;
V @out_447 = default;
if (Truthy((((((!(Truthy(st_443)) ? V.True : V.False) is var _t448 && Truthy(_t448) ? _t448 : Get(st_443, "seq")) is var _t449 && Truthy(_t449) ? _t449 : Get(st_443, "fx")) is var _t450 && Truthy(_t450) ? _t450 : Get(st_443, "prop")) is var _t451 && Truthy(_t451) ? _t451 : (!(Truthy(Get(st_443, "k"))) ? V.True : V.False)))) {
return V.Null;
}
T_446 = (Get(c_444, "T") is var _t452 && Truthy(_t452) ? _t452 : ((V)(1D)));
@out_447 = Object_assign(NewObj(0).V, st_443, NewObj(1).Put("k", NewObj(0).V).V);
{
foreach (V _k453 in ForInKeys(Get(st_443, "k"))) {
V p_454 = default;
p_454 = _k453;
V a_455 = default;
V r_456 = default;
a_455 = (Truthy(GetK(GRP_26, p_454)) ? (GetK(c_444, GetK(GRP_26, p_454)) is var _t457 && Truthy(_t457) ? _t457 : ((V)(1D))) : ((V)(1D)));
r_456 = (GetK(REST_9, p_454) is var _t458 && Truthy(_t458) ? _t458 : ((V)(0D)));
SetK(Get(@out_447, "k"), p_454, Invoke(GetK(Get(st_443, "k"), p_454), "map", Fn((V _arrowThis466, int _argc459, V q_465, V _a462, V _a463, V _a464, V[] _rest460) => {
V v_467 = default;
V n_468 = default;
v_467 = Add(r_456, ((V)(((ToNum(GetIdx(q_465, 1D)) - ToNum(r_456)) * ToNum(a_455)))));
if (SEqS(p_454, "sq")) {
v_467 = ((V)(Max((-0.26), Min(0.36, ToNum(v_467)))));
}
n_468 = Arr(((V)((ToNum(GetIdx(q_465, 0D)) * ToNum(T_446)))), v_467);
if (Truthy(GetIdx(q_465, 2D))) {
Invoke(n_468, "push", GetIdx(q_465, 2D));
}
return n_468;
return default;
}, 1, "", true)));
}
}
if (Truthy(Get(st_443, "dur"))) {
Set(@out_447, "dur", ((V)((ToNum(Get(st_443, "dur")) * ToNum(T_446)))));
}
if (Truthy(Get(st_443, "loop"))) {
Set(@out_447, "loop", ((V)((ToNum(Get(st_443, "loop")) * ToNum(T_446)))));
}
if (Truthy(Get(st_443, "ev"))) {
Set(@out_447, "ev", Invoke(Get(st_443, "ev"), "map", Fn((V _arrowThis476, int _argc469, V e_475, V _a472, V _a473, V _a474, V[] _rest470) => {
return Invoke(Arr(((V)((ToNum(GetIdx(e_475, 0D)) * ToNum(T_446))))), "concat", Invoke(e_475, "slice", ((V)(1D))));
}, 1, "", true)));
}
if (Truthy(Get(st_443, "emit"))) {
Set(@out_447, "emit", Invoke(Get(st_443, "emit"), "map", Fn((V _arrowThis484, int _argc477, V m_483, V _a480, V _a481, V _a482, V[] _rest478) => {
return Invoke(Arr(((V)((ToNum(GetIdx(m_483, 0D)) * ToNum(T_446)))), ((V)((ToNum(GetIdx(m_483, 1D)) * ToNum(T_446)))), ((V)((ToNum(GetIdx(m_483, 2D)) * ToNum(T_446))))), "concat", Invoke(m_483, "slice", ((V)(3D))));
}, 1, "", true)));
}
return @out_447;
return default;
}, 2, "", true);
SHARED_28 = Arr(((V)("idle")), ((V)("look")), ((V)("squish")), ((V)("spin")), ((V)("hop")), ((V)("idle_yawn")), ((V)("idle_waveL")), ((V)("idle_waveR")), ((V)("cry")), ((V)("sob")), ((V)("sleep")), ((V)("poke_head")), ((V)("poke_earL")), ((V)("poke_earR")), ((V)("poke_nose")), ((V)("poke_cheekL")), ((V)("poke_cheekR")), ((V)("poke_eyeL")), ((V)("poke_eyeR")), ((V)("poke_belly")), ((V)("poke_sideL")), ((V)("poke_sideR")), ((V)("poke_footL")), ((V)("poke_footR")), ((V)("poke_tail")));
MOVES_29 = NewObj(0).V;
Set(MOVES_29, "mittens", NewObj(1).Put("quirk", Arr(Call(Fn((V _arrowThis491, int _argc485, V _a487, V _a488, V _a489, V _a490, V[] _rest486) => {
V t_492 = default;
V R1_493 = default;
V R2_494 = default;
V R3_495 = default;
t_492 = Call(TL_12, V.Undef);
R1_493 = Call(hand_14, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D))));
R2_494 = Call(hand_14, V.Undef, ((V)(1D)), ((V)(7D)), ((V)((-27D))));
R3_495 = Call(hand_14, V.Undef, ((V)(1D)), ((V)((-1D))), ((V)((-33D))));
Invoke(Invoke(t_492, "to", ((V)(320D)), Call(o_16, V.Undef, R1_493, NewObj(4).Put("armR", ((V)(20D))).Put("pitch", ((V)((-0.12)))).Put("htilt", ((V)(4D))).Put("ly", ((V)(0.4))).V), ((V)("io"))), "e", ((V)("blink")));
Invoke(t_492, "osc", ((V)(900D)), ((V)(3D)), NewObj(4).Put("tongue", ((V)(0.9))).Put("open", ((V)(0.15))).Put("pitch", ((V)((-0.16)))).Put("sq", ((V)(0.015))).V, NewObj(4).Put("tongue", ((V)(0.1))).Put("open", ((V)(0D))).Put("pitch", ((V)((-0.1)))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_492, "to", ((V)(160D)), NewObj(2).Put("tongue", ((V)(0D))).Put("close", ((V)(0.9))).V, ((V)("io")));
{
double i_496 = 0;
i_496 = 0D;
while (true) {
if (!((i_496 < 2D))) break;
Invoke(Invoke(Invoke(t_492, "to", ((V)(260D)), Call(o_16, V.Undef, R2_494, NewObj(3).Put("htilt", ((V)(9D))).Put("pitch", ((V)((-0.18)))).Put("earR", ((V)(10D))).V), ((V)("io"))), "to", ((V)(260D)), Call(o_16, V.Undef, R3_495, NewObj(3).Put("htilt", ((V)(12D))).Put("earR", ((V)(18D))).Put("sq", ((V)(0.02))).V), ((V)("o"))), "to", ((V)(240D)), Call(o_16, V.Undef, R1_493, NewObj(3).Put("htilt", ((V)(5D))).Put("earR", ((V)(2D))).Put("sq", ((V)(0D))).V), ((V)("io")));
i_496++;
}
}
Invoke(t_492, "to", ((V)(240D)), Call(o_16, V.Undef, NOHANDS_17, NewObj(4).Put("armR", ((V)(0D))).Put("pitch", ((V)((-0.05)))).Put("earR", ((V)(0D))).Put("close", ((V)(0.9))).V), ((V)("io")));
Call(shake_22, V.Undef, t_492, NewObj(6).Put("P", ((V)(85D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.85)), ((V)(0.55)), ((V)(0.25)))).Put("head", ((V)(0.36))).Put("roll", ((V)(4D))).Put("ear", ((V)(13D))).Put("chest", ((V)(0.08))).V);
Invoke(Invoke(Invoke(Invoke(t_492, "to", ((V)(160D)), NewObj(2).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(450D))), "rest", ((V)(420D)));
return Invoke(t_492, "done");
return default;
}, 0, "", true), V.Undef), ((V)("Face wash")), ((V)("Licks a paw three times and wipes it over his ear (head leaning into it), then a quick cat head shake that dies away.")))).V);
Set(MOVES_29, "biscuit", NewObj(7).Put("dance", Arr(Call(Fn((V _arrowThis504, int _argc498, V _a500, V _a501, V _a502, V _a503, V[] _rest499) => {
V t_505 = default;
double B_506 = 0;
V snap_507 = default;
V a_508 = default;
V b_509 = default;
t_505 = Call(TL_12, V.Undef, NewObj(1).Put("smile", ((V)(0.5))).V);
B_506 = 500D;
snap_507 = Fn((V _arrowThis519, int _argc510, V v_516, V over_517, V len_518, V _a515, V[] _rest511) => {
Invoke(Invoke(t_505, "to", ((V)(90D)), over_517, ((V)("o"))), "to", ((V)(80D)), v_516, ((V)("io")));
return Invoke(t_505, "wait", ((V)((ToNum((len_518 is var _t520 && Truthy(_t520) ? _t520 : ((V)(B_506)))) - 170D))));
return default;
}, 3, "", true);
Invoke(Invoke(t_505, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(60D)), NewObj(1).Put("lx", ((V)(0.7))).V, ((V)("o")));
Call(snap_507, V.Undef, NewObj(5).Put("armR", ((V)(88D))).Put("hyaw", ((V)(0.32))).Put("sq", ((V)(0D))).Put("wag", ((V)(14D))).Put("htilt", ((V)((-2D)))).V, NewObj(5).Put("armR", ((V)(97D))).Put("hyaw", ((V)(0.38))).Put("sq", ((V)(0.05))).Put("wag", ((V)(18D))).Put("htilt", ((V)((-3D)))).V, ((V)((B_506 - 60D))));
Invoke(t_505, "to", ((V)(60D)), NewObj(1).Put("lx", ((V)((-0.7)))).V, ((V)("o")));
Call(snap_507, V.Undef, NewObj(5).Put("armL", ((V)(88D))).Put("hyaw", ((V)((-0.32)))).Put("sq", ((V)(0D))).Put("wag", ((V)((-14D)))).Put("htilt", ((V)(2D))).V, NewObj(5).Put("armL", ((V)(97D))).Put("hyaw", ((V)((-0.38)))).Put("sq", ((V)(0.05))).Put("wag", ((V)((-18D)))).Put("htilt", ((V)(3D))).V, ((V)((B_506 - 60D))));
Invoke(t_505, "to", ((V)(60D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("o")));
Call(snap_507, V.Undef, NewObj(4).Put("hyaw", ((V)(0D))).Put("htilt", ((V)(9D))).Put("wag", ((V)(14D))).Put("sq", ((V)(0D))).V, NewObj(4).Put("hyaw", ((V)(0.05))).Put("htilt", ((V)(11D))).Put("wag", ((V)(18D))).Put("sq", ((V)(0.04))).V, ((V)((B_506 - 60D))));
Call(snap_507, V.Undef, NewObj(3).Put("htilt", ((V)((-9D)))).Put("wag", ((V)((-14D)))).Put("sq", ((V)(0D))).V, NewObj(3).Put("htilt", ((V)((-11D)))).Put("wag", ((V)((-18D)))).Put("sq", ((V)(0.04))).V);
Call(snap_507, V.Undef, NewObj(6).Put("armR", ((V)(150D))).Put("armL", ((V)(0D))).Put("x", ((V)(2D))).Put("htilt", ((V)(0D))).Put("wag", ((V)(14D))).Put("sq", ((V)(0D))).V, NewObj(6).Put("armR", ((V)(158D))).Put("armL", ((V)((-6D)))).Put("x", ((V)(2.6))).Put("htilt", ((V)(1D))).Put("wag", ((V)(18D))).Put("sq", ((V)(0.05))).V);
Call(snap_507, V.Undef, NewObj(5).Put("armR", ((V)(0D))).Put("armL", ((V)(150D))).Put("x", ((V)((-2D)))).Put("wag", ((V)((-14D)))).Put("sq", ((V)(0D))).V, NewObj(5).Put("armR", ((V)((-6D)))).Put("armL", ((V)(158D))).Put("x", ((V)((-2.6)))).Put("wag", ((V)((-18D)))).Put("sq", ((V)(0.05))).V);
Call(snap_507, V.Undef, NewObj(5).Put("armR", ((V)(62D))).Put("armL", ((V)(62D))).Put("x", ((V)(0D))).Put("wag", ((V)(0D))).Put("sq", ((V)(0D))).V, NewObj(5).Put("armR", ((V)(68D))).Put("armL", ((V)(68D))).Put("x", ((V)(0.4))).Put("wag", ((V)(4D))).Put("sq", ((V)(0.06))).V);
Call(snap_507, V.Undef, NewObj(3).Put("armR", ((V)(122D))).Put("armL", ((V)(28D))).Put("sq", ((V)(0D))).V, NewObj(3).Put("armR", ((V)(128D))).Put("armL", ((V)(22D))).Put("sq", ((V)(0.05))).V);
Invoke(t_505, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_521 = 0;
i_521 = 0D;
while (true) {
if (!((i_521 < 4D))) break;
double d_523 = 0;
V k_524 = default;
V j_525 = default;
d_523 = (NumTruthy((i_521 % 2D)) ? 1D : (-1D));
k_524 = Call(S_13, V.Undef, ((V)(d_523)));
j_525 = Call(S_13, V.Undef, ((V)((-d_523))));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_505, "to", ((V)(90D)), NewObj(9).PutK(Get(k_524, "foot"), ((V)(4.5))).PutK(Get(j_525, "foot"), ((V)(0D))).PutK(Get(k_524, "arm"), ((V)((-14D)))).PutK(Get(j_525, "arm"), ((V)(46D))).Put("turn", ((V)((d_523 * 0.12)))).Put("sq", ((V)((-0.03)))).Put("lift", ((V)(1D))).Put("x", ((V)((d_523 * 0.8)))).Put("wag", ((V)((d_523 * 12D)))).V, ((V)("o"))), "to", ((V)(80D)), NewObj(2).PutK(Get(k_524, "foot"), ((V)(3.6))).Put("sq", ((V)((-0.01)))).V, ((V)("io"))), "wait", ((V)(80D))), "to", ((V)(90D)), NewObj(3).PutK(Get(k_524, "foot"), ((V)(0D))).Put("sq", ((V)(0.07))).Put("lift", ((V)(0D))).V, ((V)("i"))), "to", ((V)(80D)), NewObj(1).Put("sq", ((V)(0.02))).V, ((V)("io"))), "wait", ((V)(80D)));
i_521++;
}
}
Invoke(Invoke(Invoke(Invoke(t_505, "to", ((V)(120D)), NewObj(6).Put("turn", ((V)(0D))).Put("x", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("wag", ((V)(0D))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(10).Put("sq", ((V)(0.17))).Put("pitch", ((V)((-0.38)))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).Put("earL", ((V)(4D))).Put("earR", ((V)(4D))).Put("close", ((V)(0.8))).Put("smile", ((V)(0D))).Put("ly", ((V)(0.6))).Put("htilt", ((V)(6D))).V, ((V)("i"))), "to", ((V)(90D)), NewObj(1).Put("sq", ((V)(0.21))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(1).Put("sq", ((V)(0.19))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_505, "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(4D))), "to", ((V)(70D)), NewObj(3).Put("close", ((V)(0D))).Put("wide", ((V)(1D))).Put("ly", ((V)((-0.2)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(8).Put("sq", ((V)((-0.09)))).Put("lift", ((V)(5D))).Put("pitch", ((V)(0.12))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).Put("htilt", ((V)(0D))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(3).Put("sq", ((V)(0.1))).Put("lift", ((V)(0D))).Put("pitch", ((V)((-0.02)))).V, ((V)("i"))), "to", ((V)(100D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_505, "to", ((V)(200D)), NewObj(11).Put("wide", ((V)(0D))).Put("ly", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.9))).Put("open", ((V)(0.35))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D)));
a_508 = Get(t_505, "t");
Invoke(t_505, "osc", ((V)(1500D)), ((V)(3D)), NewObj(4).Put("tilt", ((V)(6D))).Put("x", ((V)(1.6))).Put("bend", ((V)(3D))).Put("htilt", ((V)((-3D)))).V, NewObj(4).Put("tilt", ((V)((-6D)))).Put("x", ((V)((-1.6)))).Put("bend", ((V)((-3D)))).Put("htilt", ((V)(3D))).V, ((V)("io")));
b_509 = Get(t_505, "t");
Invoke(Invoke(Invoke(t_505, "at", ((V)((ToNum(a_508) - 300D)))), "osc", ((V)(1800D)), ((V)(6D)), NewObj(1).Put("wag", ((V)(32D))).V, NewObj(1).Put("wag", ((V)((-32D)))).V, ((V)("io"))), "at", b_509);
Invoke(Invoke(t_505, "to", ((V)(350D)), NewObj(12).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0.5))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("wag", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
return Invoke(t_505, "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Biscuit Bot")), ((V)("Robot head ticks, pop-lock arms and a stiff march while his floppy ears and tail keep swinging; powers down, reboots, and breaks into a happy puppy wiggle.")))).Put("happy", Arr(Call(Fn((V _arrowThis532, int _argc526, V _a528, V _a529, V _a530, V _a531, V[] _rest527) => {
V t_533 = default;
V a_534 = default;
V b_535 = default;
t_533 = Call(TL_12, V.Undef, NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("tongue", ((V)(0.75))).V);
Call(jump_18, V.Undef, t_533, NewObj(5).Put("h", ((V)(9D))).Put("ant", ((V)(150D))).Put("up", ((V)(220D))).Put("c", ((V)(0.16))).Put("arm", ((V)(30D))).V);
a_534 = Get(t_533, "t");
Invoke(Invoke(t_533, "osc", ((V)(900D)), ((V)(2D)), NewObj(4).Put("tilt", ((V)(7D))).Put("x", ((V)(2D))).Put("bend", ((V)(3D))).Put("htilt", ((V)((-3D)))).V, NewObj(4).Put("tilt", ((V)((-7D)))).Put("x", ((V)((-2D)))).Put("bend", ((V)((-3D)))).Put("htilt", ((V)(3D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(4).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
b_535 = Get(t_533, "t");
Invoke(t_533, "at", ((V)(0D)));
Call(swing_20, V.Undef, t_533, b_535, ((V)(15D)), NewObj(1).Put("wag", ((V)(34D))).V);
Invoke(Invoke(t_533, "at", b_535), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return Object_assign(Invoke(t_533, "loop"), NewObj(1).Put("dur", ((V)((ToNum(b_535) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Tongue out, a bouncy hop, then a whole-body wiggle with his tail going non-stop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis542, int _argc536, V _a538, V _a539, V _a540, V _a541, V[] _rest537) => {
V t_543 = default;
V a_544 = default;
t_543 = Call(TL_12, V.Undef);
Invoke(Invoke(t_543, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(6).Put("sq", ((V)(0.1))).Put("wide", ((V)(1D))).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).V, ((V)("o")));
Call(jump_18, V.Undef, t_543, NewObj(8).Put("h", ((V)(7D))).Put("ant", ((V)(60D))).Put("up", ((V)(200D))).Put("c", ((V)(0.08))).Put("arm", ((V)(34D))).Put("x", ((V)((-6D)))).Put("air", NewObj(1).Put("lean", ((V)((-3D)))).V).Put("fall", NewObj(1).Put("lean", ((V)((-1D)))).V).V);
Invoke(Invoke(Invoke(t_543, "wait", ((V)(250D))), "e", ((V)("blink"))), "to", ((V)(500D)), NewObj(5).Put("lx", ((V)(0.3))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).Put("open", ((V)(0.15))).Put("mw", ((V)(0.85))).V, ((V)("io")));
Invoke(Invoke(t_543, "to", ((V)(420D)), NewObj(5).Put("htilt", ((V)(15D))).Put("pitch", ((V)(0.05))).Put("earL", ((V)(3D))).Put("earR", ((V)((-5D)))).Put("ly", ((V)((-0.1)))).V, ((V)("io"))), "wait", ((V)(500D)));
Invoke(Invoke(t_543, "to", ((V)(480D)), NewObj(4).Put("htilt", ((V)((-14D)))).Put("earL", ((V)((-5D)))).Put("earR", ((V)(3D))).Put("lx", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(420D)));
Invoke(Invoke(t_543, "e", ((V)("blink"))), "to", ((V)(380D)), NewObj(10).Put("htilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0.35))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.7))).V, ((V)("io")));
a_544 = Get(t_543, "t");
Invoke(t_543, "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("io")));
Invoke(Invoke(t_543, "at", a_544), "to", ((V)(1200D)), NewObj(2).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_543, "rest", ((V)(450D))), "done", NewObj(1).Put("stretch", ((V)(0.5))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Ears jump up and he hops back, then does the puppy head tilt one way and the other, decides it is fine and wags.")))).Put("quirk", Arr(Call(Fn((V _arrowThis551, int _argc545, V _a547, V _a548, V _a549, V _a550, V[] _rest546) => {
V t_552 = default;
t_552 = Call(TL_12, V.Undef);
Call(look_21, V.Undef, t_552, ((V)(0D)), ((V)(0.8)), NewObj(1).Put("k", ((V)(1.2))).V);
Invoke(t_552, "wait", ((V)(150D)));
Invoke(Invoke(t_552, "to", ((V)(140D)), NewObj(2).Put("sq", ((V)(0.1))).Put("wide", ((V)(0.6))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("dust")), ((V)("footL")), ((V)(2D)));
Invoke(Invoke(t_552, "to", ((V)(900D)), NewObj(10).Put("spin", ((V)(360D))).Put("lean", ((V)(3D))).Put("tilt", ((V)(6D))).Put("hyaw", ((V)(0.4))).Put("twist", ((V)(0.2))).Put("bend", ((V)(2D))).Put("x", ((V)(1.5))).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.35))).Put("sq", ((V)((-0.02)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(t_552, "to", ((V)(220D)), NewObj(9).Put("hyaw", ((V)(0D))).Put("twist", ((V)(0D))).Put("bend", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("sq", ((V)(0.06))).Put("cross", ((V)(0.8))).Put("wide", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_552, "osc", ((V)(900D)), ((V)(2D)), NewObj(2).Put("htilt", ((V)(8D))).Put("lean", ((V)(1.2))).V, NewObj(2).Put("htilt", ((V)((-8D)))).Put("lean", ((V)((-1.2)))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(6).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("cross", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("blink2")));
return Invoke(Invoke(Invoke(t_552, "wait", ((V)(300D))), "rest", ((V)(420D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Chases his tail")), ((V)("Spots his tail, spins round after it, gets dizzy (crossed eyes, wobbly head) and pants happily.")))).Put("squish", Arr(Call(Fn((V _arrowThis559, int _argc553, V _a555, V _a556, V _a557, V _a558, V[] _rest554) => {
V t_560 = default;
V a_561 = default;
t_560 = Call(TL_12, V.Undef);
Invoke(Invoke(t_560, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(330D)), NewObj(8).Put("sq", ((V)(0.38))).Put("hap", ((V)(0.9))).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.3))).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("earL", ((V)(5D))).Put("earR", ((V)(5D))).V, ((V)("io")));
a_561 = Get(t_560, "t");
Invoke(t_560, "wait", ((V)(420D)));
Invoke(Invoke(Invoke(t_560, "at", ((V)((ToNum(a_561) - 200D)))), "osc", ((V)(640D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(30D))).V, NewObj(1).Put("wag", ((V)((-30D)))).V, ((V)("io"))), "at", Add(a_561, ((V)(420D))));
Invoke(Invoke(Invoke(Invoke(t_560, "to", ((V)(130D)), NewObj(8).Put("sq", ((V)((-0.18)))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.45))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.08))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)((-0.03)))).Put("tongue", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(180D)), NewObj(9).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("smile", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_560, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_560, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed flat with his tongue out and tail wagging, springs back with a big ear flop.")))).Put("press", NewObj(2).Put("tongue", ((V)(0.75))).Put("open", ((V)(0.25))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(7).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(3.5)), ((V)("o"))), Arr(((V)(280D)), ((V)(0D)), ((V)("i"))))).Put("earL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)((-14D))), ((V)("o"))), Arr(((V)(320D)), ((V)(10D)), ((V)("io"))), Arr(((V)(520D)), ((V)((-4D))), ((V)("io"))), Arr(((V)(720D)), ((V)(0D)), ((V)("io"))))).Put("earR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)((-14D))), ((V)("o"))), Arr(((V)(320D)), ((V)(10D)), ((V)("io"))), Arr(((V)(520D)), ((V)((-4D))), ((V)("io"))), Arr(((V)(720D)), ((V)(0D)), ((V)("io"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(130D)), ((V)(30D))), Arr(((V)(260D)), ((V)((-30D)))), Arr(((V)(390D)), ((V)(30D))), Arr(((V)(520D)), ((V)((-30D)))), Arr(((V)(650D)), ((V)(20D))), Arr(((V)(800D)), ((V)(0D))))).Put("tongue", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(700D)), ((V)(0.6))), Arr(((V)(1000D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("heart")), ((V)("head")), ((V)(1D))))).V).V);
Set(MOVES_29, "truffle", NewObj(7).Put("dance", Arr(Call(Fn((V _arrowThis568, int _argc562, V _a564, V _a565, V _a566, V _a567, V[] _rest563) => {
V t_569 = default;
double B_570 = 0;
V a_571 = default;
t_569 = Call(TL_12, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_570 = 500D;
Invoke(t_569, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
a_571 = Get(t_569, "t");
Call(swing_20, V.Undef, t_569, ((V)((4D * B_570))), ((V)(7D)), NewObj(5).Put("tilt", ((V)(5D))).Put("x", ((V)(1.4))).Put("bend", ((V)(2.5))).Put("wag", ((V)(18D))).Put("htilt", ((V)((-2.5)))).V);
Invoke(Invoke(t_569, "at", a_571), "osc", ((V)((4D * B_570))), ((V)(4D)), NewObj(2).Put("pitch", ((V)((-0.14)))).Put("sq", ((V)(0.06))).V, NewObj(2).Put("pitch", ((V)(0.05))).Put("sq", ((V)((-0.02)))).V, ((V)("io")));
Invoke(t_569, "to", ((V)(200D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(9D)), ((V)(1D))), NewObj(3).Put("pitch", ((V)(0D))).Put("hap", ((V)(0D))).Put("sq", ((V)(0D))).V), ((V)("io")));
{
double i_572 = 0;
i_572 = 0D;
while (true) {
if (!((i_572 < 3D))) break;
double d_574 = 0;
d_574 = (NumTruthy((i_572 % 2D)) ? 1D : (-1D));
Invoke(Invoke(Invoke(t_569, "to", ((V)(140D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(d_574)), ((V)(9D)), ((V)((-1D)))), Call(hand_14, V.Undef, ((V)((-d_574))), ((V)(9D)), ((V)(2D))), NewObj(2).Put("sq", ((V)(0.15))).Put("lift", ((V)(0D))).V), ((V)("i"))), "to", ((V)(170D)), NewObj(2).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2.5))).V, ((V)("o"))), "to", ((V)(190D)), NewObj(2).Put("sq", ((V)(0.02))).Put("lift", ((V)(0D))).V, ((V)("i")));
i_572++;
}
}
Invoke(Invoke(Invoke(t_569, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(140D)), Call(o_16, V.Undef, NOHANDS_17, NewObj(4).Put("open", ((V)(0.6))).Put("mw", ((V)(0.8))).Put("pitch", ((V)(0.2))).Put("sq", ((V)((-0.04)))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
a_571 = Get(t_569, "t");
Invoke(Invoke(Invoke(Invoke(t_569, "to", ((V)(500D)), NewObj(2).Put("spin", ((V)(180D))).Put("hap", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(1000D))), "to", ((V)(500D)), NewObj(2).Put("spin", ((V)(360D))).Put("hap", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(t_569, "at", a_571);
Call(steps_19, V.Undef, t_569, ((V)(500D)), ((V)(2D)), ((V)(2.5)));
Call(swing_20, V.Undef, t_569, ((V)(1000D)), ((V)(4D)), NewObj(4).Put("tilt", ((V)(6D))).Put("x", ((V)(1.6))).Put("wag", ((V)(26D))).Put("curl", ((V)(0.4))).V);
Call(steps_19, V.Undef, t_569, ((V)(500D)), ((V)(2D)), ((V)(2.5)));
Invoke(t_569, "at", Add(a_571, ((V)(2001D))));
Invoke(t_569, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_575 = 0;
i_575 = 0D;
while (true) {
if (!((i_575 < 4D))) break;
double d_577 = 0;
V k_578 = default;
d_577 = (NumTruthy((i_575 % 2D)) ? 1D : (-1D));
k_578 = Call(S_13, V.Undef, ((V)(d_577)));
Invoke(Invoke(Invoke(Invoke(t_569, "to", ((V)(200D)), NewObj(5).Put("bend", ((V)(((-d_577) * 3.5)))).Put("x", ((V)(((-d_577) * 1.2)))).Put("htilt", ((V)((d_577 * 2D)))).PutK(Get(k_578, "foot"), ((V)(4D))).Put("sq", ((V)((-0.02)))).V, ((V)("o"))), "to", ((V)(120D)), NewObj(3).PutK(Get(k_578, "foot"), ((V)(0D))).Put("sq", ((V)(0.1))).Put("bend", ((V)(((-d_577) * 1.5)))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), Get(k_578, "foot"), ((V)(3D))), "to", ((V)(180D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
i_575++;
}
}
Invoke(t_569, "to", ((V)(200D)), NewObj(3).Put("bend", ((V)(0D))).Put("x", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
Call(jump_18, V.Undef, t_569, NewObj(9).Put("h", ((V)(9D))).Put("ant", ((V)(220D))).Put("up", ((V)(280D))).Put("c", ((V)(0.22))).Put("arm", ((V)(45D))).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(3).Put("open", ((V)(0.55))).Put("mw", ((V)(0.8))).Put("hap", ((V)(1D))).V).Put("fall", NewObj(1).Put("open", ((V)(0.2))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(4D))), Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))))).V);
Invoke(Call(land_24, V.Undef, t_569, ((V)(0.1)), ((V)(3D)), ((V)(260D))), "to", ((V)(160D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
return Invoke(t_569, "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Piggy Wiggle")), ((V)("Butt wiggle with snout bops, belly bounces with belly pats, an oink, turns round to wiggle his curly tail at you, mud stomps, and a big happy oink hop.")))).Put("happy", Arr(Call(Fn((V _arrowThis585, int _argc579, V _a581, V _a582, V _a583, V _a584, V[] _rest580) => {
V t_586 = default;
V L_587 = default;
t_586 = Call(TL_12, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(jump_18, V.Undef, t_586, NewObj(6).Put("h", ((V)(7D))).Put("ant", ((V)(200D))).Put("up", ((V)(240D))).Put("c", ((V)(0.2))).Put("arm", ((V)(36D))).Put("chain", (true ? V.True : V.False)).V);
Call(land_24, V.Undef, t_586, ((V)(0.08)), ((V)(2D)), ((V)(240D)));
Call(jump_18, V.Undef, t_586, NewObj(9).Put("h", ((V)(8D))).Put("ant", ((V)(180D))).Put("up", ((V)(250D))).Put("c", ((V)(0.22))).Put("arm", ((V)(44D))).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("curl", ((V)(0.6))).V).Put("fall", NewObj(1).Put("curl", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))))).V);
Call(land_24, V.Undef, t_586, ((V)(0.09)), ((V)(3D)), ((V)(240D)));
L_587 = Get(t_586, "t");
Invoke(t_586, "at", ((V)(0D)));
Call(swing_20, V.Undef, t_586, L_587, ((V)(11D)), NewObj(1).Put("wag", ((V)(20D))).V);
Invoke(t_586, "at", L_587);
return Object_assign(Invoke(t_586, "loop"), NewObj(1).Put("dur", ((V)((ToNum(L_587) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Two heavy happy hops, his round body jiggling after each landing, curly tail spinning, hearts.")))).Put("surprised", Arr(Call(Fn((V _arrowThis594, int _argc588, V _a590, V _a591, V _a592, V _a593, V[] _rest589) => {
V t_595 = default;
V a_596 = default;
t_595 = Call(TL_12, V.Undef);
Invoke(Invoke(t_595, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(5).Put("sq", ((V)(0.12))).Put("wide", ((V)(1D))).Put("earL", ((V)((-12D)))).Put("earR", ((V)((-12D)))).Put("open", ((V)(0.4))).V, ((V)("o")));
Call(jump_18, V.Undef, t_595, NewObj(9).Put("h", ((V)(6D))).Put("ant", ((V)(60D))).Put("up", ((V)(210D))).Put("c", ((V)(0.1))).Put("arm", ((V)(30D))).Put("x", ((V)((-5D)))).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("lean", ((V)((-2.5)))).V).Put("fall", NewObj(1).Put("lean", ((V)((-1D)))).V).V);
Call(land_24, V.Undef, t_595, ((V)(0.08)), ((V)(2D)), ((V)(220D)));
Invoke(t_595, "osc", ((V)(360D)), ((V)(2D)), NewObj(3).Put("sq", ((V)(0.05))).Put("pitch", ((V)(0.1))).Put("mw", ((V)(0.8))).V, NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o")));
Invoke(t_595, "to", ((V)(420D)), NewObj(6).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("open", ((V)(0D))).Put("wide", ((V)(0.4))).Put("pitch", ((V)((-0.18)))).Put("ly", ((V)(0.4))).V, ((V)("io")));
a_596 = Get(t_595, "t");
Invoke(t_595, "osc", ((V)(1200D)), ((V)(5D)), NewObj(2).Put("sq", ((V)(0.02))).Put("pitch", ((V)((-0.22)))).V, NewObj(2).Put("sq", ((V)(0D))).Put("pitch", ((V)((-0.16)))).V, ((V)("io")));
Invoke(Invoke(t_595, "at", a_596), "to", ((V)(1200D)), NewObj(2).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_595, "to", ((V)(300D)), NewObj(5).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(300D)));
return Invoke(Invoke(t_595, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Ears up, a heavy little hop back that wobbles his belly, two snorts, then sniffs his way back nose-first.")))).Put("quirk", Arr(Call(Fn((V _arrowThis603, int _argc597, V _a599, V _a600, V _a601, V _a602, V[] _rest598) => {
V t_604 = default;
V a_605 = default;
V b_606 = default;
t_604 = Call(TL_12, V.Undef);
Invoke(t_604, "to", ((V)(380D)), NewObj(3).Put("pitch", ((V)((-0.34)))).Put("ly", ((V)(0.8))).Put("sq", ((V)(0.04))).V, ((V)("io")));
a_605 = Get(t_604, "t");
Invoke(Invoke(Invoke(t_604, "to", ((V)(700D)), NewObj(4).Put("hyaw", ((V)((-0.48)))).Put("x", ((V)((-2.2)))).Put("bend", ((V)((-2.5)))).Put("twist", ((V)((-0.12)))).V, ((V)("io"))), "to", ((V)(900D)), NewObj(4).Put("hyaw", ((V)(0.45))).Put("x", ((V)(2.2))).Put("bend", ((V)(2.5))).Put("twist", ((V)(0.12))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(4).Put("hyaw", ((V)(0.05))).Put("x", ((V)(0.4))).Put("bend", ((V)(0D))).Put("twist", ((V)(0D))).V, ((V)("io")));
b_606 = Get(t_604, "t");
Invoke(Invoke(Invoke(t_604, "at", a_605), "osc", ((V)((ToNum(b_606) - ToNum(a_605)))), ((V)(10D)), NewObj(3).Put("sq", ((V)(0.055))).Put("pitch", ((V)((-0.4)))).Put("mw", ((V)(0.85))).V, NewObj(3).Put("sq", ((V)(0.015))).Put("pitch", ((V)((-0.3)))).Put("mw", ((V)(1D))).V, ((V)("o"))), "at", b_606);
Invoke(Invoke(Invoke(t_604, "to", ((V)(200D)), NewObj(8).Put("pitch", ((V)(0.1))).Put("ly", ((V)(0D))).Put("sq", ((V)((-0.04)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("hyaw", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "osc", ((V)(500D)), ((V)(2D)), NewObj(2).Put("wag", ((V)(22D))).Put("curl", ((V)(0.4))).V, NewObj(2).Put("wag", ((V)((-22D)))).Put("curl", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_604, "wait", ((V)(250D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sniff sniff")), ((V)("Puts his snout to the ground and follows a scent left and right, then a happy snort.")))).Put("squish", Arr(Call(Fn((V _arrowThis613, int _argc607, V _a609, V _a610, V _a611, V _a612, V[] _rest608) => {
V t_614 = default;
t_614 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_614, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(340D)), NewObj(7).Put("sq", ((V)(0.42))).Put("hap", ((V)(0.9))).Put("puff", ((V)(0.4))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(t_614, "to", ((V)(120D)), NewObj(10).Put("sq", ((V)((-0.2)))).Put("puff", ((V)(0D))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.8))).V, ((V)("o")));
Call(jelly_23, V.Undef, t_614, ((V)(0.14)), ((V)(4D)), ((V)(230D)));
Invoke(t_614, "to", ((V)(160D)), NewObj(7).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
return Object_assign(Invoke(t_614, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_614, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed into a round piggy pancake, then his whole body jiggles like jelly with an oink.")))).Put("press", NewObj(1).Put("puff", ((V)(0.35))).V).Put("rel", NewObj(3).Put("dur", ((V)(1300D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(230D)), ((V)(0.13)), ((V)("io"))), Arr(((V)(350D)), ((V)((-0.08))), ((V)("io"))), Arr(((V)(470D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(590D)), ((V)((-0.025))), ((V)("io"))), Arr(((V)(720D)), ((V)(0D)), ((V)("io"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.5)), ((V)("o"))), Arr(((V)(450D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(900D)), ((V)(1D))), Arr(((V)(1300D)), ((V)(0D)), ((V)("io"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(20D))), Arr(((V)(300D)), ((V)((-20D)))), Arr(((V)(450D)), ((V)(16D))), Arr(((V)(600D)), ((V)((-10D)))), Arr(((V)(750D)), ((V)(0D))))).V).Put("em", Arr(Arr(((V)("note")), ((V)("head")), ((V)(1D))))).V).V);
Set(MOVES_29, "nibbles", NewObj(7).Put("dance", Arr(Call(Fn((V _arrowThis621, int _argc615, V _a617, V _a618, V _a619, V _a620, V[] _rest616) => {
V P_622 = default;
V t_623 = default;
double B_624 = 0;
V a_625 = default;
V b_626 = default;
P_622 = Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D))));
t_623 = Call(TL_12, V.Undef, Call(o_16, V.Undef, P_622, NewObj(1).Put("smile", ((V)(0.7))).V));
B_624 = 500D;
Invoke(t_623, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_627 = 0;
i_627 = 0D;
while (true) {
if (!((i_627 < 4D))) break;
double d_629 = 0;
d_629 = (NumTruthy((i_627 % 2D)) ? 1D : (-1D));
Invoke(Invoke(Invoke(t_623, "to", ((V)(110D)), NewObj(4).Put("puff", ((V)(1D))).Put("sq", ((V)(0.05))).Put("htilt", ((V)((d_629 * 5D)))).PutK(Get(Call(S_13, V.Undef, ((V)(d_629))), "foot"), ((V)(2D))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(2).Put("sq", ((V)(0D))).PutK(Get(Call(S_13, V.Undef, ((V)(d_629))), "foot"), ((V)(0D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("puff", ((V)(0.15))).Put("htilt", ((V)((d_629 * 2D)))).V, ((V)("io")));
i_627++;
}
}
Invoke(t_623, "to", ((V)(150D)), NewObj(5).Put("htilt", ((V)(0D))).Put("puff", ((V)(0D))).Put("pitch", ((V)((-0.2)))).Put("lean", ((V)(0.8))).Put("wide", ((V)(0.3))).V, ((V)("io")));
a_625 = Get(t_623, "t");
Call(steps_19, V.Undef, t_623, ((V)(((4D * B_624) - 150D))), ((V)(14D)), ((V)(5.5)));
Invoke(Invoke(t_623, "at", a_625), "osc", ((V)(((4D * B_624) - 150D))), ((V)(7D)), NewObj(4).Put("armL", ((V)(48D))).Put("armR", ((V)((-10D)))).Put("x", ((V)(0.7))).Put("tilt", ((V)(2D))).V, NewObj(4).Put("armL", ((V)((-10D)))).Put("armR", ((V)(48D))).Put("x", ((V)((-0.7)))).Put("tilt", ((V)((-2D)))).V, ((V)("io")));
Invoke(Invoke(t_623, "at", a_625), "osc", ((V)(((4D * B_624) - 150D))), ((V)(14D)), NewObj(2).Put("lift", ((V)(1.6))).Put("sq", ((V)((-0.03)))).V, NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_623, "at", a_625), "em", ((V)(((4D * B_624) - 300D))), ((V)(220D)), ((V)("dust")), ((V)("footL")), ((V)(1D))), "at", ((V)((ToNum(Add(a_625, ((V)((4D * B_624))))) - 150D))));
Invoke(Invoke(t_623, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(150D)), NewObj(11).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("pitch", ((V)(0D))).Put("lean", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
{
double i_630 = 0;
i_630 = 0D;
while (true) {
if (!((i_630 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(t_623, "to", ((V)(150D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(11D)), ((V)((-14D)))), NewObj(2).Put("pitch", ((V)((-0.06)))).Put("sq", ((V)(0.03))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D))), "to", ((V)(110D)), Call(o_16, V.Undef, P_622, NewObj(2).Put("puff", ((V)((0.35 + (i_630 * 0.32))))).Put("sq", ((V)(0D))).V), ((V)("o"))), "osc", ((V)(240D)), ((V)(2D)), NewObj(1).Put("open", ((V)(0.12))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("io")));
i_630++;
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_623, "to", ((V)(110D)), NewObj(3).Put("sq", ((V)(0.08))).Put("wide", ((V)(0.8))).Put("puff", ((V)(1.2))).V, ((V)("io"))), "to", ((V)(70D)), NewObj(4).Put("puff", ((V)(0D))).Put("sq", ((V)((-0.1)))).Put("open", ((V)(0.5))).Put("lift", ((V)(3D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth")), ((V)(3D))), "to", ((V)(180D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).Put("open", ((V)(0D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
a_625 = Get(t_623, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_623, "to", ((V)(560D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "at", a_625), "to", ((V)(260D)), NewObj(2).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_623, "at", Add(a_625, ((V)(710D))));
Call(jump_18, V.Undef, t_623, NewObj(6).Put("h", ((V)(6D))).Put("ant", ((V)(110D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(20D))).Put("chain", (true ? V.True : V.False)).V);
Call(jump_18, V.Undef, t_623, NewObj(5).Put("h", ((V)(6D))).Put("ant", ((V)(100D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(20D))).V);
Invoke(Invoke(t_623, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), Call(o_16, V.Undef, NOHANDS_17, NewObj(4).Put("armL", ((V)(140D))).Put("armR", ((V)(140D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("o")));
a_625 = Get(t_623, "t");
Invoke(t_623, "osc", ((V)(1200D)), ((V)(4D)), NewObj(4).Put("armL", ((V)(120D))).Put("armR", ((V)(155D))).Put("turn", ((V)(0.15))).Put("htilt", ((V)(3D))).V, NewObj(4).Put("armL", ((V)(155D))).Put("armR", ((V)(120D))).Put("turn", ((V)((-0.15)))).Put("htilt", ((V)((-3D)))).V, ((V)("io")));
b_626 = Get(t_623, "t");
Invoke(Invoke(Invoke(t_623, "at", a_625), "osc", ((V)(1200D)), ((V)(8D)), NewObj(2).Put("sq", ((V)(0.02))).Put("pitch", ((V)(0.04))).V, NewObj(2).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("o"))), "at", b_626);
Invoke(t_623, "to", ((V)(Max(150D, ((20D * B_624) - ToNum(b_626))))), Call(o_16, V.Undef, P_622, NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("turn", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0.7))).V), ((V)("io")));
return Invoke(t_623, "loop", NewObj(1).Put("stretch", ((V)(0.5))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Cheek Wiggle")), ((V)("Cheek puffs on the beat, a hamster-wheel run, stuffs three seeds into his cheeks and pops them out, a quick spin, two tiny hops, paws-up wiggle.")))).Put("happy", Arr(Call(Fn((V _arrowThis638, int _argc632, V _a634, V _a635, V _a636, V _a637, V[] _rest633) => {
V t_639 = default;
t_639 = Call(TL_12, V.Undef, Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D)))), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V));
Call(jump_18, V.Undef, t_639, NewObj(8).Put("h", ((V)(6D))).Put("ant", ((V)(110D))).Put("up", ((V)(160D))).Put("c", ((V)(0.12))).Put("arm", ((V)(18D))).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("puff", ((V)(0.8))).V).Put("fall", NewObj(1).Put("puff", ((V)(0.2))).V).V);
Call(jump_18, V.Undef, t_639, NewObj(8).Put("h", ((V)(7D))).Put("ant", ((V)(100D))).Put("up", ((V)(170D))).Put("c", ((V)(0.12))).Put("arm", ((V)(18D))).Put("air", NewObj(1).Put("puff", ((V)(0.9))).V).Put("fall", NewObj(1).Put("puff", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))))).V);
Invoke(t_639, "osc", ((V)(500D)), ((V)(4D)), NewObj(2).Put("pitch", ((V)(0.05))).Put("sq", ((V)(0.02))).V, NewObj(2).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("o")));
return Object_assign(Invoke(t_639, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_639, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Two quick tiny hops with his cheeks puffing, paws clasped, a nose twitch.")))).Put("surprised", Arr(Call(Fn((V _arrowThis646, int _argc640, V _a642, V _a643, V _a644, V _a645, V[] _rest641) => {
V t_647 = default;
t_647 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_647, "wait", ((V)(120D))), "to", ((V)(70D)), NewObj(5).Put("sq", ((V)(0.1))).Put("wide", ((V)(1D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i")));
Invoke(Invoke(t_647, "to", ((V)(90D)), NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(900D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_647, "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(320D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(320D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(150D)));
Invoke(Invoke(t_647, "e", ((V)("blink"))), "to", ((V)(150D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(11D)), ((V)((-14D)))), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V), ((V)("io")));
Invoke(Invoke(t_647, "osc", ((V)(600D)), ((V)(4D)), NewObj(2).Put("puff", ((V)(0.7))).Put("sq", ((V)(0.02))).V, NewObj(2).Put("puff", ((V)(0.5))).Put("sq", ((V)(0D))).V, ((V)("o"))), "to", ((V)(220D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D)))), NewObj(1).Put("wide", ((V)(0.2))).V), ((V)("io")));
return Invoke(Invoke(Invoke(t_647, "wait", ((V)(300D))), "rest", ((V)(500D))), "done", NewObj(1).Put("noBlink", (true ? V.True : V.False)).V);
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("A tiny jump, then the hamster freeze - completely still, only his eyes dart left and right - and some nervous cheek stuffing.")))).Put("quirk", Arr(Call(Fn((V _arrowThis654, int _argc648, V _a650, V _a651, V _a652, V _a653, V[] _rest649) => {
V t_655 = default;
t_655 = Call(TL_12, V.Undef);
Invoke(Invoke(t_655, "to", ((V)(360D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(9D)), ((V)(6D))), NewObj(4).Put("pitch", ((V)((-0.24)))).Put("ly", ((V)(0.6))).Put("sq", ((V)(0.04))).Put("lean", ((V)(0.5))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("pawL")), ((V)(1D)));
Invoke(Invoke(Invoke(t_655, "to", ((V)(320D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(11D)), ((V)((-14D)))), NewObj(4).Put("pitch", ((V)((-0.04)))).Put("ly", ((V)(0D))).Put("sq", ((V)(0D))).Put("lean", ((V)(0D))).V), ((V)("io"))), "osc", ((V)(420D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.14))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(1).Put("puff", ((V)(0.75))).V, ((V)("o")));
Invoke(Invoke(t_655, "to", ((V)(260D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(2D)), ((V)((-19D)))), NewObj(1).Put("htilt", ((V)(3D))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(3).Put("hLy", ((V)((-21D)))).Put("hRy", ((V)((-17D)))).Put("puff", ((V)(0.85))).V, NewObj(3).Put("hLy", ((V)((-17D)))).Put("hRy", ((V)((-21D)))).Put("puff", ((V)(0.7))).V, ((V)("io")));
Invoke(Invoke(t_655, "to", ((V)(220D)), Call(o_16, V.Undef, NOHANDS_17, NewObj(3).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(400D)), ((V)(4D)), NewObj(2).Put("pitch", ((V)(0.05))).Put("sq", ((V)(0.015))).V, NewObj(2).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("o")));
return Invoke(Invoke(Invoke(t_655, "wait", ((V)(250D))), "rest", ((V)(500D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Cheek stash")), ((V)("Picks a seed off the floor, stuffs it in his cheek, pats his full cheeks, nose twitch.")))).Put("squish", Arr(Call(Fn((V _arrowThis662, int _argc656, V _a658, V _a659, V _a660, V _a661, V[] _rest657) => {
V t_663 = default;
t_663 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_663, "to", ((V)(130D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0.36))).Put("puff", ((V)(1.1))).Put("sqz", ((V)(0.8))).Put("armL", ((V)(16D))).Put("armR", ((V)(16D))).V, ((V)("io"))), "wait", ((V)(420D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_663, "to", ((V)(80D)), NewObj(6).Put("sq", ((V)((-0.2)))).Put("puff", ((V)(0D))).Put("sqz", ((V)(0D))).Put("open", ((V)(0.45))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth")), ((V)(3D))), "to", ((V)(150D)), NewObj(2).Put("sq", ((V)(0.07))).Put("open", ((V)(0.1))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.02)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(4).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_663, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_663, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, his cheeks balloon out - let go and the seeds pop out.")))).Put("press", NewObj(2).Put("puff", ((V)(1D))).Put("sqz", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(900D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)((-0.2))), ((V)("o"))), Arr(((V)(220D)), ((V)(0.08)), ((V)("io"))), Arr(((V)(340D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(460D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(3D)), ((V)("o"))), Arr(((V)(240D)), ((V)(0D)), ((V)("i"))))).Put("open", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(80D)), ((V)(0.45)), ((V)("o"))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).Put("puff", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(90D)), ((V)((-0.3))), ((V)("o"))), Arr(((V)(300D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("seed")), ((V)("mouth")), ((V)(3D))))).V).V);
Set(MOVES_29, "quill", NewObj(7).Put("dance", Arr(Call(Fn((V _arrowThis670, int _argc664, V _a666, V _a667, V _a668, V _a669, V[] _rest665) => {
V P_671 = default;
V t_672 = default;
double B_673 = 0;
V a_674 = default;
P_671 = Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D))));
t_672 = Call(TL_12, V.Undef, Call(o_16, V.Undef, P_671, NewObj(4).Put("pitch", ((V)((-0.08)))).Put("blush", ((V)(0.45))).Put("smile", ((V)(0.5))).Put("ly", ((V)(0.3))).V));
B_673 = 600D;
Invoke(t_672, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_675 = 0;
i_675 = 0D;
while (true) {
if (!((i_675 < 4D))) break;
double d_677 = 0;
V k_678 = default;
d_677 = (NumTruthy((i_675 % 2D)) ? 1D : (-1D));
k_678 = Call(S_13, V.Undef, ((V)(d_677)));
Invoke(Invoke(t_672, "to", ((V)((B_673 * 0.55))), NewObj(5).Put("x", ((V)((d_677 * 3.2)))).Put("bend", ((V)((d_677 * 3D)))).Put("htilt", ((V)(((-d_677) * 2D)))).PutK(Get(k_678, "foot"), ((V)(2D))).Put("ly", ((V)(((i_675 == 2D) ? 0D : 0.3)))).V, ((V)("io"))), "to", ((V)((B_673 * 0.45))), NewObj(2).PutK(Get(k_678, "foot"), ((V)(0D))).Put("bend", ((V)((d_677 * 1.2)))).V, ((V)("io")));
i_675++;
}
}
Invoke(Invoke(t_672, "to", ((V)(400D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-27D)))), NewObj(5).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)((-0.1)))).V), ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(t_672, "to", ((V)(260D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-1D))), ((V)((-19D)))), NewObj(2).Put("lx", ((V)(0.4))).Put("htilt", ((V)(4D))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(2).Put("sq", ((V)(0.025))).Put("htilt", ((V)(6D))).V, NewObj(2).Put("sq", ((V)(0D))).Put("htilt", ((V)(3D))).V, ((V)("io"))), "to", ((V)(240D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-27D)))), NewObj(3).Put("lx", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(160D)));
Invoke(Invoke(Invoke(t_672, "to", ((V)(140D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)((-2D))), ((V)((-18D)))), NewObj(8).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.45))).Put("blush", ((V)(0.9))).Put("pitch", ((V)(0.05))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2D))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.04))).Put("lift", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), Call(o_16, V.Undef, P_671, NewObj(7).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("pitch", ((V)((-0.08)))).Put("blush", ((V)(0.6))).Put("ly", ((V)(0.3))).V), ((V)("io")));
Invoke(t_672, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_679 = 0;
i_679 = 0D;
while (true) {
if (!((i_679 < 4D))) break;
double d_681 = 0;
V k_682 = default;
d_681 = (NumTruthy((i_679 % 2D)) ? 1D : (-1D));
k_682 = Call(S_13, V.Undef, ((V)(d_681)));
Invoke(Invoke(t_672, "to", ((V)((B_673 * 0.5))), Call(o_16, V.Undef, NOHANDS_17, NewObj(10).Put("x", ((V)((d_681 * 3.4)))).Put("bend", ((V)((d_681 * 3.5)))).Put("htilt", ((V)(((-d_681) * 2D)))).PutK(Get(k_682, "foot"), ((V)(2.2))).Put("armL", ((V)(((d_681 < 0D) ? 34D : 6D)))).Put("armR", ((V)(((d_681 > 0D) ? 34D : 6D)))).Put("ly", ((V)(0D))).Put("pitch", ((V)((-0.14)))).Put("sq", ((V)(0.03))).Put("smile", ((V)(0.9))).V), ((V)("io"))), "to", ((V)((B_673 * 0.5))), NewObj(3).PutK(Get(k_682, "foot"), ((V)(0D))).Put("pitch", ((V)((-0.02)))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_679++;
}
}
Invoke(t_672, "to", ((V)(380D)), NewObj(10).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).Put("sq", ((V)(0.16))).Put("pitch", ((V)((-0.6)))).Put("close", ((V)(1D))).Put("smile", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
a_674 = Get(t_672, "t");
Invoke(Invoke(t_672, "to", ((V)(1150D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_672, "at", a_674), "osc", ((V)(1150D)), ((V)(2D)), NewObj(1).Put("lift", ((V)(1.5))).V, NewObj(1).Put("lift", ((V)(0D))).V, ((V)("io"))), "at", Add(a_674, ((V)(1151D))));
Invoke(Invoke(Invoke(Invoke(t_672, "to", ((V)(160D)), NewObj(9).Put("sq", ((V)((-0.12)))).Put("pitch", ((V)(0.08))).Put("close", ((V)(0D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("lift", ((V)(5D))).Put("wide", ((V)(0.4))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(220D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("pitch", ((V)(0D))).V, ((V)("i"))), "to", ((V)(190D)), NewObj(4).Put("sq", ((V)(0D))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("wide", ((V)(0D))).V, ((V)("io")));
a_674 = Get(t_672, "t");
Invoke(Invoke(t_672, "to", ((V)(300D)), NewObj(5).Put("armR", ((V)(112D))).Put("hRy", ((V)((-3D)))).Put("htilt", ((V)(4D))).Put("blush", ((V)(1D))).Put("open", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("armR", ((V)(100D))).V, NewObj(1).Put("armR", ((V)(124D))).V, ((V)("io")));
Invoke(t_672, "to", ((V)(Max(200D, ((20D * B_673) - ToNum(Get(t_672, "t")))))), Call(o_16, V.Undef, P_671, NewObj(7).Put("armR", ((V)(0D))).Put("armL", ((V)(0D))).Put("htilt", ((V)(0D))).Put("blush", ((V)(0.45))).Put("smile", ((V)(0.5))).Put("ly", ((V)(0.3))).Put("pitch", ((V)((-0.08)))).V), ((V)("io")));
return Invoke(t_672, "loop", NewObj(2).Put("stretch", ((V)(0.4))).Put("soft", ((V)(0.8))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Spike Shuffle")), ((V)("A shy side shuffle with paws clasped, peek-a-boo behind his paws, a braver shuffle, curls into a spiky ball and rolls round, pops open, tiny shy wave.")))).Put("happy", Arr(Call(Fn((V _arrowThis689, int _argc683, V _a685, V _a686, V _a687, V _a688, V[] _rest684) => {
V t_690 = default;
t_690 = Call(TL_12, V.Undef, Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D)))), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(0.9))).Put("blush", ((V)(0.8))).V));
Call(swing_20, V.Undef, t_690, ((V)(1600D)), ((V)(3D)), NewObj(4).Put("x", ((V)(1.8))).Put("bend", ((V)(2.5))).Put("tilt", ((V)(2D))).Put("htilt", ((V)((-2D)))).V);
Call(jump_18, V.Undef, t_690, NewObj(5).Put("h", ((V)(5D))).Put("ant", ((V)(200D))).Put("up", ((V)(220D))).Put("c", ((V)(0.12))).Put("arm", ((V)(14D))).V);
Invoke(Invoke(t_690, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(200D)));
return Object_assign(Invoke(t_690, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_690, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Rocks shyly from side to side with happy closed eyes and pink cheeks, a small hop, a heart.")))).Put("surprised", Arr(Call(Fn((V _arrowThis697, int _argc691, V _a693, V _a694, V _a695, V _a696, V[] _rest692) => {
V t_698 = default;
t_698 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_698, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(240D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(4D)), ((V)(2D))), NewObj(5).Put("sq", ((V)(0.17))).Put("pitch", ((V)((-0.6)))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V), ((V)("o")));
Invoke(Invoke(t_698, "osc", ((V)(900D)), ((V)(9D)), NewObj(1).Put("x", ((V)(0.45))).V, NewObj(1).Put("x", ((V)((-0.45)))).V, ((V)("l"))), "to", ((V)(60D)), NewObj(1).Put("x", ((V)(0D))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_698, "wait", ((V)(250D))), "to", ((V)(420D)), NewObj(6).Put("close", ((V)(0.55))).Put("sq", ((V)(0.14))).Put("pitch", ((V)((-0.46)))).Put("lx", ((V)(0.5))).Put("ly", ((V)((-0.2)))).Put("wide", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(260D)), NewObj(1).Put("lx", ((V)((-0.5)))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_698, "to", ((V)(700D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D)))), NewObj(9).Put("sq", ((V)(0D))).Put("pitch", ((V)((-0.08)))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wide", ((V)(0D))).Put("ly", ((V)(0.3))).Put("blush", ((V)(0.9))).Put("smile", ((V)(0.6))).V), ((V)("io"))), "wait", ((V)(500D)));
return Invoke(Invoke(t_698, "rest", ((V)(600D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Curls into a ball at once and trembles, peeks out, then slowly uncurls, blushing.")))).Put("quirk", Arr(Call(Fn((V _arrowThis705, int _argc699, V _a701, V _a702, V _a703, V _a704, V[] _rest700) => {
V t_706 = default;
t_706 = Call(TL_12, V.Undef);
Invoke(Invoke(t_706, "to", ((V)(380D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-27D)))), NewObj(2).Put("pitch", ((V)((-0.12)))).Put("blush", ((V)(0.6))).V), ((V)("io"))), "wait", ((V)(350D)));
Invoke(Invoke(Invoke(t_706, "to", ((V)(300D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)((-1D))), ((V)((-19D)))), NewObj(3).Put("hyaw", ((V)((-0.25)))).Put("lx", ((V)((-0.6)))).Put("htilt", ((V)((-3D)))).V), ((V)("io"))), "wait", ((V)(450D))), "to", ((V)(260D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)((-27D)))), NewObj(3).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("htilt", ((V)(0D))).V), ((V)("io")));
Invoke(Invoke(Invoke(t_706, "to", ((V)(300D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)((-1D))), ((V)((-19D)))), NewObj(3).Put("hyaw", ((V)(0.25))).Put("lx", ((V)(0.6))).Put("htilt", ((V)(3D))).V), ((V)("io"))), "wait", ((V)(450D))), "to", ((V)(260D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-27D)))), NewObj(3).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("htilt", ((V)(0D))).V), ((V)("io")));
Invoke(Invoke(t_706, "to", ((V)(320D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-8D)))), NewObj(3).Put("blush", ((V)(1D))).Put("smile", ((V)(0.7))).Put("pitch", ((V)((-0.06)))).V), ((V)("io"))), "wait", ((V)(500D)));
return Invoke(Invoke(t_706, "rest", ((V)(600D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Peek")), ((V)("Hides his face behind his paws and peeks out one side, then the other, blushing.")))).Put("squish", Arr(Call(Fn((V _arrowThis713, int _argc707, V _a709, V _a710, V _a711, V _a712, V[] _rest708) => {
V t_714 = default;
t_714 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_714, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(380D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(4D)), ((V)(2D))), NewObj(5).Put("sq", ((V)(0.4))).Put("pitch", ((V)((-0.5)))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V), ((V)("io"))), "wait", ((V)(420D)));
Invoke(Invoke(Invoke(Invoke(t_714, "to", ((V)(160D)), Call(o_16, V.Undef, NOHANDS_17, NewObj(7).Put("sq", ((V)((-0.12)))).Put("pitch", ((V)(0.05))).Put("close", ((V)(0D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("smile", ((V)(0.8))).Put("blush", ((V)(0.9))).V), ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.05))).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("smile", ((V)(0D))).Put("blush", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_714, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_714, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Curls into a tight ball when squeezed, unrolls with a stretch and a shy smile.")))).Put("press", NewObj(3).Put("pitch", ((V)((-0.45)))).Put("sqz", ((V)(0.4))).Put("bristle", ((V)(1D))).V).Put("rel", NewObj(2).Put("dur", ((V)(1200D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(360D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(560D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(2.5)), ((V)("o"))), Arr(((V)(360D)), ((V)(0D)), ((V)("i"))))).Put("blush", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.9)), ((V)("io"))), Arr(((V)(900D)), ((V)(0.9))), Arr(((V)(1200D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.7)), ((V)("io"))), Arr(((V)(900D)), ((V)(0.7))), Arr(((V)(1200D)), ((V)(0D)), ((V)("io"))))).V).V).V);
Set(MOVES_29, "waffles", NewObj(7).Put("dance", Arr(Call(Fn((V _arrowThis721, int _argc715, V _a717, V _a718, V _a719, V _a720, V[] _rest716) => {
V t_722 = default;
double B_723 = 0;
t_722 = Call(TL_12, V.Undef, NewObj(4).Put("smile", ((V)(0.8))).Put("hap", ((V)(1D))).Put("open", ((V)(0.3))).Put("tongue", ((V)(0.6))).V);
B_723 = 500D;
Invoke(t_722, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Call(swing_20, V.Undef, t_722, ((V)((4D * B_723))), ((V)(11D)), NewObj(5).Put("tilt", ((V)(6D))).Put("x", ((V)(1D))).Put("bend", ((V)(2D))).Put("htilt", ((V)((-3D)))).Put("wag", ((V)(36D))).V);
{
double i_724 = 0;
i_724 = 0D;
while (true) {
if (!((i_724 < 4D))) break;
Call(jump_18, V.Undef, t_722, NewObj(9).Put("h", ((V)(8D))).Put("ant", ((V)(110D))).Put("up", ((V)(150D))).Put("dn", ((V)(130D))).Put("c", ((V)(0.15))).Put("arm", ((V)(34D))).Put("chain", ((i_724 < 3D) ? V.True : V.False)).Put("air", NewObj(1).Put("wag", ((V)((NumTruthy((i_724 % 2D)) ? 30D : (-30D))))).V).Put("fall", NewObj(1).Put("wag", ((V)(0D))).V).V);
i_724++;
}
}
Invoke(Invoke(Invoke(t_722, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0.36))).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("pitch", ((V)((-0.1)))).Put("open", ((V)(0.35))).V, ((V)("i"))), "to", ((V)(90D)), NewObj(1).Put("sq", ((V)(0.32))).V, ((V)("io")));
GSet("a", Get(t_722, "t"));
Call(swing_20, V.Undef, t_722, ((V)(700D)), ((V)(5D)), NewObj(1).Put("wag", ((V)(32D))).V);
Invoke(Invoke(Invoke(Invoke(t_722, "at", G("a")), "to", ((V)(350D)), NewObj(1).Put("htilt", ((V)(5D))).V, ((V)("io"))), "to", ((V)(350D)), NewObj(1).Put("htilt", ((V)(0D))).V, ((V)("io"))), "at", Add(G("a"), ((V)(700D))));
Invoke(t_722, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.4))).V, ((V)("io")));
Call(jump_18, V.Undef, t_722, NewObj(5).Put("h", ((V)(7D))).Put("ant", ((V)(120D))).Put("up", ((V)(180D))).Put("c", ((V)(0.42))).Put("arm", ((V)(50D))).V);
Invoke(Invoke(t_722, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(160D)), NewObj(7).Put("lean", ((V)((-2D)))).Put("tilt", ((V)((-4D)))).Put("sq", ((V)(0.06))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).Put("tongue", ((V)(1D))).Put("open", ((V)(0.45))).V, ((V)("io")));
GSet("a", Get(t_722, "t"));
Invoke(Invoke(t_722, "to", ((V)(1500D)), NewObj(1).Put("spin", ((V)(720D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(Invoke(t_722, "at", G("a")), "to", ((V)(500D)), NewObj(3).Put("x", ((V)((-6D)))).Put("tilt", ((V)((-7D)))).Put("lean", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(3).Put("x", ((V)(6D))).Put("tilt", ((V)(7D))).Put("lean", ((V)(3D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(3).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_722, "at", G("a")), "em", ((V)(1400D)), ((V)(200D)), ((V)("dust")), ((V)("footL")), ((V)(1D)));
Invoke(t_722, "at", G("a"));
Call(steps_19, V.Undef, t_722, ((V)(1500D)), ((V)(12D)), ((V)(3D)));
Invoke(Invoke(t_722, "at", Add(G("a"), ((V)(1501D)))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).V, ((V)("io")));
Invoke(t_722, "to", ((V)(300D)), NewObj(5).Put("pitch", ((V)((-0.32)))).Put("sq", ((V)(0.1))).Put("armL", ((V)((-12D)))).Put("armR", ((V)((-12D)))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(swing_20, V.Undef, t_722, ((V)(800D)), ((V)(5D)), NewObj(2).Put("tilt", ((V)(4D))).Put("wag", ((V)(36D))).V);
Invoke(Invoke(Invoke(t_722, "to", ((V)(110D)), NewObj(6).Put("pitch", ((V)((-0.1)))).Put("open", ((V)(0.85))).Put("mw", ((V)(0.85))).Put("sq", ((V)((-0.06)))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(160D)), NewObj(5).Put("open", ((V)(0.3))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.03))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Invoke(t_722, "to", ((V)(300D)), NewObj(7).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("open", ((V)(0.3))).Put("tongue", ((V)(0.6))).V, ((V)("io")));
return Invoke(t_722, "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Loaf Hop")), ((V)("Corgi butt wiggle, four loaf hops, a sploot (flops flat) and springs back up, zoomies (two spins), play bow and a happy boof.")))).Put("happy", Arr(Call(Fn((V _arrowThis732, int _argc726, V _a728, V _a729, V _a730, V _a731, V[] _rest727) => {
V t_733 = default;
V a_734 = default;
V L_735 = default;
t_733 = Call(TL_12, V.Undef, NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("tongue", ((V)(0.7))).V);
Invoke(t_733, "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0.1))).Put("lean", ((V)((-2D)))).V, ((V)("io")));
a_734 = Get(t_733, "t");
Invoke(Invoke(t_733, "to", ((V)(700D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_733, "at", a_734), "to", ((V)(350D)), NewObj(4).Put("sq", ((V)((-0.04)))).Put("lean", ((V)((-3D)))).Put("tilt", ((V)((-5D)))).Put("x", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(350D)), NewObj(4).Put("sq", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Invoke(t_733, "at", Add(a_734, ((V)(701D))));
Call(jump_18, V.Undef, t_733, NewObj(6).Put("h", ((V)(8D))).Put("ant", ((V)(130D))).Put("up", ((V)(170D))).Put("c", ((V)(0.15))).Put("arm", ((V)(36D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))))).V);
L_735 = Get(t_733, "t");
Invoke(t_733, "at", ((V)(0D)));
Call(swing_20, V.Undef, t_733, L_735, ((V)(23D)), NewObj(1).Put("wag", ((V)(36D))).V);
Invoke(t_733, "at", L_735);
return Object_assign(Invoke(t_733, "loop"), NewObj(1).Put("dur", ((V)((ToNum(L_735) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A happy zoomie spin and a hop, stub tail going frantic, tongue out.")))).Put("surprised", Arr(Call(Fn((V _arrowThis742, int _argc736, V _a738, V _a739, V _a740, V _a741, V[] _rest737) => {
V t_743 = default;
V a_744 = default;
t_743 = Call(TL_12, V.Undef);
Invoke(Invoke(t_743, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("sq", ((V)(0.08))).Put("wide", ((V)(1D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("o")));
Invoke(Invoke(Invoke(t_743, "to", ((V)(260D)), NewObj(4).Put("x", ((V)((-6D)))).Put("lean", ((V)((-4D)))).Put("tilt", ((V)((-3D)))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("dust")), ((V)("footR")), ((V)(3D))), "to", ((V)(220D)), NewObj(3).Put("lean", ((V)((-1D)))).Put("tilt", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_743, "to", ((V)(110D)), NewObj(4).Put("open", ((V)(0.85))).Put("mw", ((V)(0.85))).Put("sq", ((V)((-0.08)))).Put("pitch", ((V)(0.1))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), NewObj(4).Put("open", ((V)(0.15))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.03))).Put("pitch", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_743, "wait", ((V)(200D))), "to", ((V)(420D)), NewObj(5).Put("htilt", ((V)(13D))).Put("earL", ((V)(4D))).Put("earR", ((V)((-6D)))).Put("open", ((V)(0D))).Put("lx", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(600D)));
Invoke(Invoke(t_743, "e", ((V)("blink"))), "to", ((V)(400D)), NewObj(8).Put("htilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("io")));
a_744 = Get(t_743, "t");
Invoke(t_743, "osc", ((V)(1000D)), ((V)(6D)), NewObj(1).Put("wag", ((V)(34D))).V, NewObj(1).Put("wag", ((V)((-34D)))).V, ((V)("io")));
Invoke(Invoke(t_743, "at", a_744), "to", ((V)(1000D)), NewObj(2).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_743, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Ears shoot up, skids backwards, one big boof, a head tilt - then his stub tail starts going.")))).Put("quirk", Arr(Call(Fn((V _arrowThis751, int _argc745, V _a747, V _a748, V _a749, V _a750, V[] _rest746) => {
V t_752 = default;
t_752 = Call(TL_12, V.Undef);
Invoke(Invoke(t_752, "to", ((V)(300D)), NewObj(5).Put("pitch", ((V)((-0.3)))).Put("sq", ((V)(0.1))).Put("armL", ((V)((-12D)))).Put("armR", ((V)((-12D)))).Put("close", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(5).Put("pitch", ((V)((-0.36)))).Put("sq", ((V)(0.13))).Put("lean", ((V)(0.8))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.9))).V, ((V)("io")));
Invoke(t_752, "to", ((V)(300D)), NewObj(8).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lean", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("close", ((V)(0.85))).V, ((V)("io")));
Invoke(t_752, "to", ((V)(220D)), NewObj(3).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.1)))).Put("close", ((V)(1D))).V, ((V)("io")));
Invoke(t_752, "em", ((V)(900D)), ((V)(130D)), ((V)("dust")), ((V)("body")), ((V)(1D)));
Call(shake_22, V.Undef, t_752, NewObj(7).Put("P", ((V)(110D))).Put("head", ((V)(0.4))).Put("roll", ((V)(5D))).Put("ear", ((V)(14D))).Put("chest", ((V)(0.3))).Put("body", ((V)(1.2))).Put("tail", ((V)(36D))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(t_752, "to", ((V)(220D)), NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink"))), "to", ((V)(150D)), NewObj(1).Put("earL", ((V)((-7D)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(5).Put("earL", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("tongue", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(500D)));
return Invoke(Invoke(t_752, "rest", ((V)(450D))), "done", NewObj(2).Put("stretch", ((V)(0D))).Put("soft", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Stretch and shake")), ((V)("A play-bow stretch with a little yawn, then a wet-dog shake: he braces, his head twists left and right with his body following a moment later, it builds up and dies away with his ears flapping, then a happy blink.")))).Put("squish", Arr(Call(Fn((V _arrowThis759, int _argc753, V _a755, V _a756, V _a757, V _a758, V[] _rest754) => {
V t_760 = default;
t_760 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_760, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(340D)), NewObj(6).Put("sq", ((V)(0.42))).Put("hap", ((V)(0.9))).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("earL", ((V)(12D))).Put("earR", ((V)(12D))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(t_760, "to", ((V)(120D)), NewObj(9).Put("sq", ((V)((-0.22)))).Put("armL", ((V)((-4D)))).Put("armR", ((V)((-4D)))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("tongue", ((V)(0.6))).V, ((V)("o")));
Call(jelly_23, V.Undef, t_760, ((V)(0.12)), ((V)(3D)), ((V)(220D)));
Invoke(t_760, "to", ((V)(160D)), NewObj(7).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("tongue", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_760, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_760, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed flat like bread dough, then springs back with a doughy wobble.")))).Put("press", NewObj(2).Put("tongue", ((V)(0.5))).Put("open", ((V)(0.2))).V).Put("rel", NewObj(2).Put("dur", ((V)(1100D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.22))), ((V)("o"))), Arr(((V)(230D)), ((V)(0.12)), ((V)("io"))), Arr(((V)(350D)), ((V)((-0.06))), ((V)("io"))), Arr(((V)(470D)), ((V)(0.03)), ((V)("io"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(3D)), ((V)("o"))), Arr(((V)(270D)), ((V)(0D)), ((V)("i"))))).Put("wag", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(34D))), Arr(((V)(200D)), ((V)((-34D)))), Arr(((V)(300D)), ((V)(34D))), Arr(((V)(400D)), ((V)((-34D)))), Arr(((V)(500D)), ((V)(30D))), Arr(((V)(600D)), ((V)((-20D)))), Arr(((V)(750D)), ((V)(0D))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).V).V);
popcorn_30 = Fn((V _arrowThis771, int _argc761, V t_767, V h_768, V d_769, V len_770, V[] _rest762) => {
V a_772 = default;
V b_773 = default;
a_772 = Get(t_767, "t");
len_770 = (len_770 is var _t774 && Truthy(_t774) ? _t774 : ((V)(520D)));
Invoke(Invoke(t_767, "to", ((V)((ToNum(len_770) * 0.4))), NewObj(3).Put("lift", h_768).Put("tilt", ((V)((ToNum(d_769) * 14D)))).Put("turn", ((V)((ToNum(d_769) * 0.35)))).V, ((V)("o"))), "to", ((V)((ToNum(len_770) * 0.4))), NewObj(3).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).Put("turn", ((V)(0D))).V, ((V)("i")));
b_773 = Get(t_767, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_767, "at", a_772), "to", ((V)(60D)), NewObj(1).Put("sq", ((V)((-0.14)))).V, ((V)("o"))), "to", ((V)(((ToNum(len_770) * 0.8) - 60D))), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(1).Put("sq", ((V)(0.14))).V, ((V)("o"))), "to", ((V)((((ToNum(len_770) * 0.2) - 90D) + 60D))), NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_767, "at", b_773), "wait", ((V)(((ToNum(len_770) * 0.2) + 200D))));
return default;
}, 4, "", true);
Set(MOVES_29, "poppy", NewObj(7).Put("dance", Arr(Call(Fn((V _arrowThis781, int _argc775, V _a777, V _a778, V _a779, V _a780, V[] _rest776) => {
V t_782 = default;
double B_783 = 0;
V a_784 = default;
t_782 = Call(TL_12, V.Undef, NewObj(1).Put("smile", ((V)(0.7))).V);
B_783 = 500D;
Invoke(t_782, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
a_784 = Get(t_782, "t");
Call(steps_19, V.Undef, t_782, ((V)((3D * B_783))), ((V)(12D)), ((V)(1.8)));
Invoke(t_782, "at", a_784);
Call(swing_20, V.Undef, t_782, ((V)((3D * B_783))), ((V)(5D)), NewObj(2).Put("x", ((V)(1.5))).Put("pitch", ((V)((-0.05)))).V);
Invoke(Invoke(Invoke(t_782, "at", a_784), "osc", ((V)((3D * B_783))), ((V)(12D)), NewObj(1).Put("sq", ((V)(0.02))).V, NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o"))), "at", Add(a_784, ((V)((3D * B_783)))));
Invoke(Invoke(Invoke(Invoke(t_782, "to", ((V)(140D)), NewObj(4).Put("pitch", ((V)(0.22))).Put("open", ((V)(0.65))).Put("mw", ((V)(0.75))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)(0.18))).Put("open", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(4).Put("pitch", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_782, "to", ((V)(80D)), NewObj(1).Put("wide", ((V)(0.6))).V, ((V)("o")));
Call(popcorn_30, V.Undef, t_782, ((V)(11D)), ((V)(1D)));
Invoke(t_782, "wait", ((V)(80D)));
Call(popcorn_30, V.Undef, t_782, ((V)(9D)), ((V)((-1D))), ((V)(480D)));
Invoke(t_782, "wait", ((V)(260D)));
Call(popcorn_30, V.Undef, t_782, ((V)(12D)), ((V)(1D)), ((V)(540D)));
Invoke(t_782, "to", ((V)(100D)), NewObj(2).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
{
double i_785 = 0;
i_785 = 0D;
while (true) {
if (!((i_785 < 4D))) break;
Invoke(Invoke(Invoke(t_782, "to", ((V)(140D)), NewObj(5).Put("pitch", ((V)(0.18))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.75))).Put("sq", ((V)((-0.04)))).Put("lift", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(360D)), NewObj(5).Put("pitch", ((V)(((-0.04) * ((i_785 < 3D) ? 1D : 0D))))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)((0.03 * ((i_785 < 3D) ? 1D : 0D))))).Put("lift", ((V)(0D))).V, ((V)("io")));
i_785++;
}
}
a_784 = Get(t_782, "t");
Invoke(Invoke(t_782, "to", ((V)(1500D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(Invoke(t_782, "at", a_784), "to", ((V)(300D)), NewObj(3).Put("lean", ((V)(2.5))).Put("tilt", ((V)(4D))).Put("pitch", ((V)((-0.12)))).V, ((V)("io"))), "wait", ((V)(900D))), "to", ((V)(300D)), NewObj(3).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
Invoke(t_782, "at", a_784);
Call(steps_19, V.Undef, t_782, ((V)(1500D)), ((V)(10D)), ((V)(2.4)));
Invoke(t_782, "at", Add(a_784, ((V)(1501D))));
Call(popcorn_30, V.Undef, t_782, ((V)(14D)), ((V)((-1D))), ((V)(600D)));
a_784 = Get(t_782, "t");
Call(swing_20, V.Undef, t_782, ((V)(1400D)), ((V)(3D)), NewObj(4).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).Put("bend", ((V)(2.5))).Put("htilt", ((V)((-2D)))).V);
Invoke(Invoke(Invoke(Invoke(t_782, "at", Add(a_784, ((V)(600D)))), "to", ((V)(120D)), NewObj(1).Put("winkR", ((V)(1D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("winkR", ((V)(0D))).V, ((V)("io"))), "at", Add(a_784, ((V)(1400D))));
Invoke(t_782, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0.7))).V, ((V)("io")));
return Invoke(t_782, "loop", NewObj(1).Put("stretch", ((V)(0.8))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Popcorn Bounce")), ((V)("Pitter-patter feet, a wheek, three sudden popcorn jumps with a twist in the air, a wheek song, runs a little circle, a big popcorn and a cheeky wink.")))).Put("happy", Arr(Call(Fn((V _arrowThis793, int _argc787, V _a789, V _a790, V _a791, V _a792, V[] _rest788) => {
V t_794 = default;
t_794 = Call(TL_12, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Call(popcorn_30, V.Undef, t_794, ((V)(10D)), ((V)(1D)));
Invoke(t_794, "wait", ((V)(100D)));
Call(popcorn_30, V.Undef, t_794, ((V)(12D)), ((V)((-1D))), ((V)(560D)));
Invoke(Invoke(Invoke(Invoke(t_794, "to", ((V)(140D)), NewObj(3).Put("pitch", ((V)(0.18))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.75))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(260D)), NewObj(3).Put("pitch", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Object_assign(Invoke(t_794, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_794, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Two popcorn jumps with a twist in the air and a happy wheek.")))).Put("surprised", Arr(Call(Fn((V _arrowThis801, int _argc795, V _a797, V _a798, V _a799, V _a800, V[] _rest796) => {
V t_802 = default;
V a_803 = default;
t_802 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_802, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(4).Put("wide", ((V)(1D))).Put("sq", ((V)(0.06))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("o"))), "wait", ((V)(500D)));
a_803 = Get(t_802, "t");
Invoke(t_802, "to", ((V)(320D)), NewObj(2).Put("x", ((V)((-7D)))).Put("lean", ((V)((-2.5)))).V, ((V)("o")));
Invoke(t_802, "at", a_803);
Call(steps_19, V.Undef, t_802, ((V)(320D)), ((V)(4D)), ((V)(2.2)));
Invoke(Invoke(Invoke(Invoke(t_802, "at", Add(a_803, ((V)(320D)))), "to", ((V)(130D)), NewObj(4).Put("lean", ((V)(0D))).Put("pitch", ((V)(0.22))).Put("open", ((V)(0.8))).Put("mw", ((V)(0.7))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)(0D))).Put("open", ((V)(0.1))).Put("mw", ((V)(1D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_802, "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0.7))).Put("ly", ((V)(0.1))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(5).Put("lx", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wide", ((V)(0.3))).Put("open", ((V)(0D))).V, ((V)("io")));
a_803 = Get(t_802, "t");
Invoke(t_802, "to", ((V)(800D)), NewObj(1).Put("x", ((V)(0D))).V, ((V)("io")));
Invoke(t_802, "at", a_803);
Call(steps_19, V.Undef, t_802, ((V)(800D)), ((V)(6D)), ((V)(1.6)));
return Invoke(Invoke(Invoke(t_802, "at", Add(a_803, ((V)(801D)))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Freezes, zips backwards on pattering feet, an alarm wheek, then creeps back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis810, int _argc804, V _a806, V _a807, V _a808, V _a809, V[] _rest805) => {
V t_811 = default;
V a_812 = default;
t_811 = Call(TL_12, V.Undef);
Invoke(Invoke(t_811, "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.5))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(2D)));
a_812 = Get(t_811, "t");
Invoke(t_811, "osc", ((V)(1600D)), ((V)(8D)), NewObj(5).Put("open", ((V)(0.3))).Put("mw", ((V)(0.75))).Put("sq", ((V)(0.05))).Put("pitch", ((V)((-0.26)))).Put("htilt", ((V)(3D))).V, NewObj(5).Put("open", ((V)(0.03))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.02))).Put("pitch", ((V)((-0.16)))).Put("htilt", ((V)((-3D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_811, "at", Add(a_812, ((V)(400D)))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D))), "at", Add(a_812, ((V)(1000D)))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D))), "at", Add(a_812, ((V)(1600D))));
Invoke(Invoke(Invoke(t_811, "to", ((V)(200D)), NewObj(6).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("sq", ((V)(0D))).Put("htilt", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("earR", ((V)((-18D)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(1).Put("earR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_811, "osc", ((V)(420D)), ((V)(4D)), NewObj(2).Put("pitch", ((V)(0.05))).Put("sq", ((V)(0.015))).V, NewObj(2).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0.05))).Put("pitch", ((V)((-0.15)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_811, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Hay munch")), ((V)("Munches some hay, an ear flick, a nose twitch and a gulp.")))).Put("squish", Arr(Call(Fn((V _arrowThis819, int _argc813, V _a815, V _a816, V _a817, V _a818, V[] _rest814) => {
V t_820 = default;
t_820 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_820, "to", ((V)(130D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.38))).Put("open", ((V)(0.55))).Put("mw", ((V)(0.75))).Put("wide", ((V)(0.6))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "wait", ((V)(400D)));
Invoke(t_820, "to", ((V)(10D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("wide", ((V)(0D))).V);
Call(popcorn_30, V.Undef, t_820, ((V)(9D)), ((V)(1D)), ((V)(480D)));
Invoke(t_820, "to", ((V)(100D)), NewObj(0).V);
return Object_assign(Invoke(t_820, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_820, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeaks when squeezed, then pops straight up in a popcorn jump.")))).Put("press", NewObj(2).Put("open", ((V)(0.4))).Put("mw", ((V)(0.8))).V).Put("rel", NewObj(3).Put("dur", ((V)(900D))).Put("k", NewObj(4).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(9D)), ((V)("o"))), Arr(((V)(400D)), ((V)(0D)), ((V)("i"))))).Put("tilt", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(12D)), ((V)("o"))), Arr(((V)(400D)), ((V)(0D)), ((V)("i"))))).Put("turn", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.3)), ((V)("o"))), Arr(((V)(400D)), ((V)(0D)), ((V)("i"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(380D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(460D)), ((V)(0.12)), ((V)("o"))), Arr(((V)(600D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(740D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("note")), ((V)("head")), ((V)(1D))))).V).V);
Set(MOVES_29, "duchess", NewObj(7).Put("dance", Arr(Call(Fn((V _arrowThis827, int _argc821, V _a823, V _a824, V _a825, V _a826, V[] _rest822) => {
V t_828 = default;
double BAR_829 = 0;
double b3_830 = 0;
V a_831 = default;
t_828 = Call(TL_12, V.Undef, NewObj(3).Put("pitch", ((V)(0.1))).Put("close", ((V)(0.3))).Put("smile", ((V)(0.6))).V);
BAR_829 = 2000D;
b3_830 = (BAR_829 / 3D);
Invoke(t_828, "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D)));
{
double j_832 = 0;
j_832 = 0D;
while (true) {
if (!((j_832 < 2D))) break;
double d_834 = 0;
d_834 = (NumTruthy(j_832) ? 1D : (-1D));
Invoke(Invoke(t_828, "to", ((V)(b3_830)), NewObj(9).Put("sq", ((V)(0.06))).Put("x", ((V)((d_834 * 2.4)))).Put("bend", ((V)((d_834 * 3D)))).Put("tilt", ((V)((d_834 * 2D)))).Put("htilt", ((V)(((-d_834) * 1.5)))).Put("lift", ((V)(0D))).Put("wag", ((V)((d_834 * 14D)))).Put("armR", ((V)((40D + (j_832 * 6D))))).Put("hRy", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)((b3_830 * 2D))), NewObj(4).Put("sq", ((V)((-0.03)))).Put("lift", ((V)(1.6))).Put("bend", ((V)((d_834 * 1.4)))).Put("tilt", ((V)((d_834 * 0.6)))).V, ((V)("io")));
j_832++;
}
}
Invoke(t_828, "to", ((V)(600D)), NewObj(11).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("tilt", ((V)(0D))).Put("htilt", ((V)(0D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("wag", ((V)(0D))).Put("armL", ((V)(72D))).Put("armR", ((V)(72D))).Put("hRy", ((V)(0D))).Put("close", ((V)(0.15))).V, ((V)("io")));
a_831 = Get(t_828, "t");
Invoke(Invoke(t_828, "to", ((V)(2400D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_828, "at", a_831), "to", ((V)(1200D)), NewObj(3).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.04)))).Put("curl", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(1200D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("curl", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_828, "at", Add(a_831, ((V)(600D)))), "e", ((V)("emit")), ((V)("spark")), ((V)("body")), ((V)(3D))), "at", Add(a_831, ((V)(2401D)))), "to", ((V)(1000D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0.3))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_828, "to", ((V)(500D)), NewObj(3).Put("armR", ((V)(100D))).Put("hRx", ((V)((-4D)))).Put("hRy", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(3).Put("armR", ((V)(126D))).Put("hRx", ((V)(3D))).Put("hRy", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(3).Put("armR", ((V)(92D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)((-2D)))).V, ((V)("io")));
a_831 = Get(t_828, "t");
Call(look_21, V.Undef, t_828, ((V)(0D)), ((V)(0.5)), NewObj(3).Put("k", ((V)(0.7))).Put("d1", ((V)(240D))).Put("d2", ((V)(280D))).V);
Invoke(Invoke(Invoke(t_828, "at", Add(a_831, ((V)(1130D)))), "to", ((V)(600D)), NewObj(1).Put("close", ((V)(1D))).V, ((V)("io"))), "to", ((V)(600D)), NewObj(1).Put("close", ((V)(0.3))).V, ((V)("io")));
Invoke(Invoke(t_828, "at", Add(Add(a_831, ((V)(1130D))), ((V)(1200D)))), "to", ((V)(500D)), NewObj(8).Put("hyaw", ((V)(0D))).Put("twist", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).Put("lx", ((V)(0D))).Put("armR", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_828, "to", ((V)(700D)), NewObj(7).Put("footL", ((V)(2.2))).Put("sq", ((V)(0.14))).Put("pitch", ((V)((-0.16)))).Put("armL", ((V)((-14D)))).Put("armR", ((V)((-14D)))).Put("x", ((V)(0.8))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(Max(300D, (12000D - ToNum(Get(t_828, "t")))))), NewObj(7).Put("footL", ((V)(0D))).Put("sq", ((V)(0D))).Put("pitch", ((V)(0.1))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("x", ((V)(0D))).Put("close", ((V)(0.3))).V, ((V)("io")));
return Invoke(t_828, "loop", NewObj(2).Put("stretch", ((V)(0.3))).Put("soft", ((V)(0.8))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Royal Sway")), ((V)("A slow waltz sway with one paw raised daintily, an elegant twirl with sparkles, a paw flourish, a slow cat blink at you over her shoulder, and a curtsy.")))).Put("happy", Arr(Call(Fn((V _arrowThis841, int _argc835, V _a837, V _a838, V _a839, V _a840, V[] _rest836) => {
V t_842 = default;
t_842 = Call(TL_12, V.Undef, NewObj(3).Put("pitch", ((V)(0.12))).Put("smile", ((V)(0.9))).Put("close", ((V)(0.35))).V);
Invoke(Invoke(t_842, "to", ((V)(500D)), NewObj(5).Put("x", ((V)(1.6))).Put("bend", ((V)(2D))).Put("tilt", ((V)(1.5))).Put("wag", ((V)(14D))).Put("curl", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(5).Put("x", ((V)((-1.6)))).Put("bend", ((V)((-2D)))).Put("tilt", ((V)((-1.5)))).Put("wag", ((V)((-14D)))).Put("curl", ((V)(0.1))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_842, "to", ((V)(500D)), NewObj(6).Put("close", ((V)(1D))).Put("x", ((V)(0D))).Put("bend", ((V)(0D))).Put("tilt", ((V)(0D))).Put("wag", ((V)(0D))).Put("curl", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "to", ((V)(600D)), NewObj(1).Put("close", ((V)(0.35))).V, ((V)("io"))), "wait", ((V)(300D)));
return Object_assign(Invoke(t_842, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_842, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Pleased: chin up, a gentle sway with her tail curling, a slow cat blink and a heart.")))).Put("surprised", Arr(Call(Fn((V _arrowThis849, int _argc843, V _a845, V _a846, V _a847, V _a848, V[] _rest844) => {
V t_850 = default;
t_850 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_850, "wait", ((V)(150D))), "to", ((V)(120D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(380D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-8D)))), NewObj(7).Put("lean", ((V)((-4D)))).Put("x", ((V)((-3D)))).Put("pitch", ((V)(0.24))).Put("open", ((V)(0.35))).Put("mw", ((V)(0.6))).Put("armR", ((V)(10D))).Put("sq", ((V)(0D))).V), ((V)("o"))), "wait", ((V)(700D))), "e", ((V)("blink"))), "to", ((V)(500D)), NewObj(3).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_850, "to", ((V)(400D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-2D))))), ((V)("io"))), "to", ((V)(400D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-8D))))), ((V)("io"))), "to", ((V)(300D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-2D))))), ((V)("io")));
Invoke(Invoke(t_850, "to", ((V)(500D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(6).Put("armR", ((V)(0D))).Put("close", ((V)(0.6))).Put("pitch", ((V)(0.3))).Put("hyaw", ((V)(0.4))).Put("lx", ((V)(0.5))).Put("htilt", ((V)((-3D)))).V), ((V)("io"))), "wait", ((V)(700D)));
Invoke(t_850, "to", ((V)(600D)), NewObj(7).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_850, "rest", ((V)(500D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Draws back with a paw to her chest, then composes herself, smooths her fur and turns away with a dignified hmph.")))).Put("quirk", Arr(Call(Fn((V _arrowThis857, int _argc851, V _a853, V _a854, V _a855, V _a856, V[] _rest852) => {
V t_858 = default;
t_858 = Call(TL_12, V.Undef);
Invoke(t_858, "to", ((V)(450D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-6D)))), NewObj(4).Put("armR", ((V)(18D))).Put("pitch", ((V)((-0.14)))).Put("ly", ((V)(0.7))).Put("htilt", ((V)(3D))).V), ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_858, "to", ((V)(220D)), NewObj(2).Put("hRx", ((V)((-10D)))).Put("hRy", ((V)((-5D)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("hRx", ((V)((-6D)))).Put("hRy", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hRx", ((V)((-9D)))).Put("hRy", ((V)((-6D)))).V, ((V)("io"))), "wait", ((V)(200D)));
Invoke(Invoke(t_858, "to", ((V)(450D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D)))), NewObj(3).Put("armR", ((V)(20D))).Put("ly", ((V)(0.3))).Put("pitch", ((V)((-0.08)))).V), ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(2).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.12))).V, NewObj(2).Put("tongue", ((V)(0.1))).Put("open", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_858, "to", ((V)(400D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(6).Put("armR", ((V)(0D))).Put("tongue", ((V)(0D))).Put("pitch", ((V)(0.18))).Put("close", ((V)(0.5))).Put("smile", ((V)(0.8))).Put("ly", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(600D)));
return Invoke(Invoke(t_858, "rest", ((V)(600D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Fixes her bow")), ((V)("Looks down and sets her bow straight with a paw, licks the paw, lifts her chin.")))).Put("squish", Arr(Call(Fn((V _arrowThis865, int _argc859, V _a861, V _a862, V _a863, V _a864, V[] _rest860) => {
V t_866 = default;
t_866 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_866, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(5).Put("sq", ((V)(0.34))).Put("sqz", ((V)(0.8))).Put("frown", ((V)(0.4))).Put("armL", ((V)(14D))).Put("armR", ((V)(14D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(4).Put("sqz", ((V)(0D))).Put("close", ((V)(0.8))).Put("frown", ((V)(0D))).Put("smile", ((V)(0.6))).V, ((V)("io")));
Invoke(Invoke(t_866, "to", ((V)(140D)), NewObj(4).Put("sq", ((V)((-0.12)))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(1).Put("sq", ((V)(0.04))).V, ((V)("io")));
Call(shake_22, V.Undef, t_866, NewObj(6).Put("P", ((V)(95D))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(0.7)), ((V)(0.35)))).Put("head", ((V)(0.12))).Put("roll", ((V)(2D))).Put("ear", ((V)(6D))).Put("body", ((V)(0.45))).V);
Invoke(t_866, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_866, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_866, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Not amused at first, then eyes close and she quite likes it; fluffs herself back up.")))).Put("press", NewObj(2).Put("close", ((V)(0.5))).Put("pitch", ((V)(0.15))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(140D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(320D)), ((V)(0.04)), ((V)("io"))), Arr(((V)(480D)), ((V)(0D)), ((V)("io"))))).Put("x", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(480D)), ((V)(0D))), Arr(((V)(580D)), ((V)(0.45)), ((V)("io"))), Arr(((V)(680D)), ((V)((-0.4))), ((V)("io"))), Arr(((V)(780D)), ((V)(0.25)), ((V)("io"))), Arr(((V)(880D)), ((V)((-0.1))), ((V)("io"))), Arr(((V)(980D)), ((V)(0D)), ((V)("io"))))).Put("pitch", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.18)), ((V)("io"))), Arr(((V)(800D)), ((V)(0.18))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).Put("close", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(0.5)), ((V)("io"))), Arr(((V)(800D)), ((V)(0.5))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("spark")), ((V)("head")), ((V)(2D))))).V).V);
Set(MOVES_29, "mamapaws", NewObj(7).Put("dance", Arr(Call(Fn((V _arrowThis873, int _argc867, V _a869, V _a870, V _a871, V _a872, V[] _rest868) => {
V P_874 = default;
V t_875 = default;
double B_876 = 0;
V a_877 = default;
V e_878 = default;
P_874 = Call(both_15, V.Undef, ((V)(6D)), ((V)((-6D))));
t_875 = Call(TL_12, V.Undef, Call(o_16, V.Undef, P_874, NewObj(1).Put("smile", ((V)(0.85))).V));
B_876 = 600D;
Invoke(t_875, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
a_877 = Get(t_875, "t");
Call(swing_20, V.Undef, t_875, ((V)((4D * B_876))), ((V)(3D)), NewObj(5).Put("x", ((V)(2D))).Put("tilt", ((V)(3D))).Put("bend", ((V)(2.5))).Put("htilt", ((V)((-2D)))).Put("sq", ((V)(0.03))).V);
Invoke(Invoke(Invoke(t_875, "at", a_877), "to", ((V)(400D)), NewObj(1).Put("hap", ((V)(0.9))).V, ((V)("io"))), "at", Add(a_877, ((V)((4D * B_876)))));
a_877 = Get(t_875, "t");
{
double i_879 = 0;
i_879 = 0D;
while (true) {
if (!((i_879 < 4D))) break;
Invoke(Invoke(Invoke(Invoke(t_875, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.13))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0.035))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
i_879++;
}
}
e_878 = Get(t_875, "t");
Invoke(t_875, "at", a_877);
Call(swing_20, V.Undef, t_875, ((V)((8D * B_876))), ((V)(23D)), NewObj(1).Put("wag", ((V)(24D))).V);
Invoke(t_875, "at", e_878);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_875, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(500D)), NewObj(7).Put("twist", ((V)((-0.35)))).Put("turn", ((V)((-0.06)))).Put("pitch", ((V)((-0.22)))).Put("htilt", ((V)((-6D)))).Put("ly", ((V)(0.7))).Put("lx", ((V)((-0.3)))).Put("hap", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(1D)), NewObj(1).Put("htilt", ((V)((-9D)))).V, NewObj(1).Put("htilt", ((V)((-5D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "to", ((V)(600D)), NewObj(4).Put("twist", ((V)(0.35))).Put("turn", ((V)(0.06))).Put("htilt", ((V)(6D))).Put("lx", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(1D)), NewObj(1).Put("htilt", ((V)(9D))).V, NewObj(1).Put("htilt", ((V)(5D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(7).Put("twist", ((V)(0D))).Put("turn", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("hap", ((V)(0.9))).V, ((V)("io")));
Call(jump_18, V.Undef, t_875, NewObj(6).Put("h", ((V)(5D))).Put("ant", ((V)(260D))).Put("up", ((V)(260D))).Put("c", ((V)(0.12))).Put("arm", ((V)(0D))).Put("chain", (true ? V.True : V.False)).V);
Call(land_24, V.Undef, t_875, ((V)(0.1)), ((V)(4D)), ((V)(280D)));
a_877 = Get(t_875, "t");
Invoke(Invoke(t_875, "to", ((V)(400D)), Call(o_16, V.Undef, Call(hand_14, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(2).Put("armR", ((V)(118D))).Put("hRy", ((V)((-3D)))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("armR", ((V)(104D))).V, NewObj(1).Put("armR", ((V)(130D))).V, ((V)("io")));
e_878 = Get(t_875, "t");
Invoke(t_875, "at", a_877);
Call(swing_20, V.Undef, t_875, ((V)(1600D)), ((V)(1D)), NewObj(3).Put("x", ((V)(2.5))).Put("tilt", ((V)(3D))).Put("bend", ((V)(3D))).V);
Invoke(t_875, "at", e_878);
Invoke(t_875, "to", ((V)(500D)), Call(o_16, V.Undef, P_874, NewObj(2).Put("armR", ((V)(0D))).Put("hap", ((V)(0D))).V), ((V)("io")));
return Invoke(t_875, "loop", NewObj(1).Put("stretch", ((V)(0.4))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Puppy Pile Jelly")), ((V)("A soft jelly sway rocking her pup, wobbly jelly bounces, shows the pup off with nuzzles and hearts, a careful little hop and a wave - the pup dances along.")))).Put("happy", Arr(Call(Fn((V _arrowThis887, int _argc881, V _a883, V _a884, V _a885, V _a886, V[] _rest882) => {
V P_888 = default;
V t_889 = default;
V L_890 = default;
P_888 = Call(both_15, V.Undef, ((V)(6D)), ((V)((-6D))));
t_889 = Call(TL_12, V.Undef, Call(o_16, V.Undef, P_888, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V));
{
double i_891 = 0;
i_891 = 0D;
while (true) {
if (!((i_891 < 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_889, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.04))).Put("lift", ((V)(0D))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
i_891++;
}
}
Invoke(Invoke(Invoke(t_889, "to", ((V)(400D)), NewObj(3).Put("pitch", ((V)((-0.2)))).Put("htilt", ((V)((-5D)))).Put("ly", ((V)(0.6))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))), "to", ((V)(400D)), NewObj(3).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
L_890 = Get(t_889, "t");
Invoke(t_889, "at", ((V)(0D)));
Call(swing_20, V.Undef, t_889, L_890, ((V)(11D)), NewObj(1).Put("wag", ((V)(26D))).V);
Invoke(t_889, "at", L_890);
return Object_assign(Invoke(t_889, "loop"), NewObj(1).Put("dur", ((V)((ToNum(L_890) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Soft happy bounces, hugs her pup close, hearts, tail wagging.")))).Put("surprised", Arr(Call(Fn((V _arrowThis899, int _argc893, V _a895, V _a896, V _a897, V _a898, V[] _rest894) => {
V t_900 = default;
V a_901 = default;
t_900 = Call(TL_12, V.Undef);
Invoke(Invoke(t_900, "wait", ((V)(150D))), "to", ((V)(100D)), NewObj(4).Put("wide", ((V)(1D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).Put("sq", ((V)(0.05))).V, ((V)("o")));
Invoke(t_900, "to", ((V)(380D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(8D)), ((V)((-6D)))), NewObj(5).Put("twist", ((V)((-0.45)))).Put("turn", ((V)((-0.08)))).Put("sq", ((V)(0.08))).Put("lean", ((V)((-1.5)))).Put("x", ((V)((-1.5)))).V), ((V)("io")));
Call(look_21, V.Undef, t_900, ((V)(0D)), ((V)((-0.5))), NewObj(1).Put("k", ((V)(0.4))).V);
Invoke(t_900, "wait", ((V)(200D)));
a_901 = Get(t_900, "t");
Invoke(Invoke(Invoke(t_900, "to", ((V)(500D)), NewObj(2).Put("hyaw", ((V)(0.45))).Put("lx", ((V)(0.9))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(400D)), NewObj(2).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
Invoke(t_900, "at", Add(a_901, ((V)(1300D))));
Invoke(Invoke(Invoke(t_900, "to", ((V)(700D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(6D)), ((V)((-6D)))), NewObj(11).Put("twist", ((V)(0D))).Put("turn", ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).Put("sq", ((V)((-0.06)))).Put("lean", ((V)(0D))).Put("x", ((V)(0D))).Put("close", ((V)(0.7))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wide", ((V)(0D))).V), ((V)("io"))), "to", ((V)(500D)), NewObj(3).Put("sq", ((V)(0.03))).Put("close", ((V)(0D))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_900, "rest", ((V)(500D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Turns to shield her pup, ears up, checks around, then a big relieved sigh.")))).Put("quirk", Arr(Call(Fn((V _arrowThis908, int _argc902, V _a904, V _a905, V _a906, V _a907, V[] _rest903) => {
V t_909 = default;
t_909 = Call(TL_12, V.Undef);
Invoke(t_909, "to", ((V)(600D)), NewObj(4).Put("pitch", ((V)((-0.28)))).Put("ly", ((V)(0.8))).Put("htilt", ((V)((-4D)))).Put("smile", ((V)(0.7))).V, ((V)("io")));
Invoke(Invoke(t_909, "osc", ((V)(1600D)), ((V)(2D)), NewObj(4).Put("htilt", ((V)((-9D)))).Put("x", ((V)(0.8))).Put("tilt", ((V)(1.5))).Put("close", ((V)(0.6))).V, NewObj(4).Put("htilt", ((V)((-3D)))).Put("x", ((V)((-0.8)))).Put("tilt", ((V)((-1.5)))).Put("close", ((V)(0.2))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
Invoke(Invoke(t_909, "to", ((V)(500D)), NewObj(7).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("htilt", ((V)(0D))).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(400D)));
return Invoke(Invoke(t_909, "rest", ((V)(500D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Nuzzle the pup")), ((V)("Looks down at her pup, nuzzles it and rocks it gently, a heart.")))).Put("squish", Arr(Call(Fn((V _arrowThis916, int _argc910, V _a912, V _a913, V _a914, V _a915, V[] _rest911) => {
V t_917 = default;
t_917 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_917, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0.36))).Put("hap", ((V)(0.9))).Put("earL", ((V)(5D))).Put("earR", ((V)(5D))).V, ((V)("io"))), "wait", ((V)(400D)));
Invoke(t_917, "to", ((V)(150D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V, ((V)("o")));
Call(jelly_23, V.Undef, t_917, ((V)(0.12)), ((V)(4D)), ((V)(300D)));
Invoke(t_917, "to", ((V)(200D)), NewObj(3).Put("smile", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_917, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_917, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed into a soft cuddle, then a slow jelly wobble.")))).Put("press", NewObj(1).Put("hap", ((V)(0.4))).V).Put("rel", NewObj(3).Put("dur", ((V)(1600D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(300D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(450D)), ((V)((-0.06))), ((V)("io"))), Arr(((V)(600D)), ((V)(0.035)), ((V)("io"))), Arr(((V)(750D)), ((V)((-0.015))), ((V)("io"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(1D)), ((V)("io"))), Arr(((V)(1200D)), ((V)(1D))), Arr(((V)(1600D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("heart")), ((V)("head")), ((V)(2D))))).V).V);
croak_31 = Fn((V _arrowThis927, int _argc918, V t_924, V n_925, V per_926, V _a923, V[] _rest919) => {
{
double i_928 = 0;
i_928 = 0D;
while (true) {
if (!(Lt(((V)(i_928)), n_925))) break;
Invoke(Invoke(t_924, "to", ((V)((ToNum(per_926) * 0.35))), NewObj(2).Put("puff", ((V)(1.1))).Put("pitch", ((V)(0.06))).V, ((V)("o"))), "to", ((V)((ToNum(per_926) * 0.65))), NewObj(2).Put("puff", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
i_928++;
}
}
return t_924;
return default;
}, 3, "", true);
Set(MOVES_29, "ribbit", NewObj(7).Put("dance", Arr(Call(Fn((V _arrowThis936, int _argc930, V _a932, V _a933, V _a934, V _a935, V[] _rest931) => {
V t_937 = default;
double B_938 = 0;
V a_939 = default;
t_937 = Call(TL_12, V.Undef, NewObj(1).Put("smile", ((V)(0.85))).V);
B_938 = 500D;
Invoke(t_937, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
{
double i_940 = 0;
i_940 = 0D;
while (true) {
if (!((i_940 < 3D))) break;
Invoke(Invoke(Invoke(t_937, "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0.26))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("pitch", ((V)((-0.08)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(5).Put("sq", ((V)((-0.13)))).Put("lift", ((V)(2.5))).Put("armL", ((V)(8D))).Put("armR", ((V)(8D))).Put("pitch", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(3).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("i")));
i_940++;
}
}
Invoke(Invoke(t_937, "to", ((V)(120D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Call(croak_31, V.Undef, t_937, ((V)(1D)), ((V)(450D)));
Call(jump_18, V.Undef, t_937, NewObj(10).Put("h", ((V)(15D))).Put("ant", ((V)(160D))).Put("up", ((V)(260D))).Put("dn", ((V)(240D))).Put("c", ((V)(0.26))).Put("arm", ((V)(60D))).Put("x", ((V)((-6D)))).Put("st", ((V)(1.1))).Put("air", NewObj(1).Put("tilt", ((V)((-3D)))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_18, V.Undef, t_937, NewObj(10).Put("h", ((V)(17D))).Put("ant", ((V)(150D))).Put("up", ((V)(280D))).Put("dn", ((V)(260D))).Put("c", ((V)(0.26))).Put("arm", ((V)(60D))).Put("x", ((V)(6D))).Put("st", ((V)(1.1))).Put("air", NewObj(1).Put("tilt", ((V)(3D))).V).Put("fall", NewObj(1).Put("tilt", ((V)(0D))).V).V);
Call(jump_18, V.Undef, t_937, NewObj(8).Put("h", ((V)(13D))).Put("ant", ((V)(150D))).Put("up", ((V)(240D))).Put("dn", ((V)(220D))).Put("c", ((V)(0.24))).Put("arm", ((V)(50D))).Put("x", ((V)(0D))).Put("st", ((V)(1.1))).V);
Invoke(Invoke(t_937, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), NewObj(2).Put("close", ((V)(0.85))).Put("hap", ((V)(1D))).V, ((V)("io")));
a_939 = Get(t_937, "t");
Call(croak_31, V.Undef, t_937, ((V)(4D)), ((V)(400D)));
Invoke(t_937, "at", a_939);
Call(swing_20, V.Undef, t_937, ((V)(1600D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(3D))).Put("bend", ((V)(2D))).Put("x", ((V)(1D))).V);
Invoke(t_937, "at", Add(a_939, ((V)(1600D))));
Invoke(t_937, "to", ((V)(100D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_937, "to", ((V)(250D)), NewObj(3).Put("lx", ((V)((-0.8)))).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.15))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(500D)), NewObj(2).Put("lx", ((V)(0.8))).Put("hyaw", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(150D)));
Invoke(Invoke(Invoke(Invoke(t_937, "to", ((V)(90D)), NewObj(4).Put("tongue", ((V)(1D))).Put("open", ((V)(0.5))).Put("pitch", ((V)(0.2))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(4).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("sq", ((V)(0.08))).Put("pitch", ((V)((-0.06)))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(6).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(120D)));
Call(jump_18, V.Undef, t_937, NewObj(10).Put("h", ((V)(20D))).Put("ant", ((V)(220D))).Put("up", ((V)(330D))).Put("dn", ((V)(300D))).Put("c", ((V)(0.3))).Put("arm", ((V)(80D))).Put("spin", ((V)(360D))).Put("st", ((V)(1.15))).Put("land", NewObj(3).Put("sq", ((V)(0.38))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(1D))), Arr(((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))))).V);
Invoke(t_937, "to", ((V)(150D)), NewObj(1).Put("hap", ((V)(0D))).V, ((V)("io")));
return Invoke(t_937, "loop", NewObj(1).Put("stretch", ((V)(0.7))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Lily Pad Hop")), ((V)("Squat-spring bounces, a croak, big leaps left and right, a croak song with his throat puffing, catches a fly with his tongue, and a spinning belly flop splash.")))).Put("happy", Arr(Call(Fn((V _arrowThis948, int _argc942, V _a944, V _a945, V _a946, V _a947, V[] _rest943) => {
V t_949 = default;
t_949 = Call(TL_12, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Call(jump_18, V.Undef, t_949, NewObj(6).Put("h", ((V)(12D))).Put("ant", ((V)(150D))).Put("up", ((V)(220D))).Put("c", ((V)(0.24))).Put("arm", ((V)(50D))).Put("st", ((V)(1.2))).V);
Call(croak_31, V.Undef, t_949, ((V)(1D)), ((V)(340D)));
Call(jump_18, V.Undef, t_949, NewObj(7).Put("h", ((V)(14D))).Put("ant", ((V)(140D))).Put("up", ((V)(240D))).Put("c", ((V)(0.26))).Put("arm", ((V)(56D))).Put("st", ((V)(1.2))).Put("ev", Arr(Arr(((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(1D))))).V);
Call(croak_31, V.Undef, t_949, ((V)(1D)), ((V)(340D)));
return Object_assign(Invoke(t_949, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_949, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Springy happy hops, a croak with his throat puffing after each.")))).Put("surprised", Arr(Call(Fn((V _arrowThis956, int _argc950, V _a952, V _a953, V _a954, V _a955, V[] _rest951) => {
V t_957 = default;
V a_958 = default;
t_957 = Call(TL_12, V.Undef);
Invoke(Invoke(t_957, "wait", ((V)(120D))), "to", ((V)(70D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)(0.12))).V, ((V)("o")));
Call(jump_18, V.Undef, t_957, NewObj(7).Put("h", ((V)(14D))).Put("ant", ((V)(50D))).Put("up", ((V)(240D))).Put("c", ((V)(0.12))).Put("arm", ((V)(70D))).Put("st", ((V)(1.3))).Put("land", NewObj(1).Put("sq", ((V)(0.3))).V).V);
Invoke(t_957, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.14))).V, ((V)("io")));
Call(croak_31, V.Undef, t_957, ((V)(1D)), ((V)(400D)));
Call(look_21, V.Undef, t_957, ((V)(0D)), ((V)((-0.55))), NewObj(1).Put("k", ((V)(0.6))).V);
Invoke(t_957, "wait", ((V)(150D)));
a_958 = Get(t_957, "t");
Call(look_21, V.Undef, t_957, ((V)((-0.55))), ((V)(0.55)), NewObj(1).Put("k", ((V)(0.6))).V);
Invoke(t_957, "wait", ((V)(150D)));
Call(look_21, V.Undef, t_957, ((V)(0.55)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.6))).V);
Invoke(t_957, "to", ((V)(400D)), NewObj(3).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).Put("smile", ((V)(0.8))).V, ((V)("io")));
return Invoke(Invoke(t_957, "rest", ((V)(500D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Eyes bulge, springs straight up and lands in a squat, a croak, then looks around.")))).Put("quirk", Arr(Call(Fn((V _arrowThis965, int _argc959, V _a961, V _a962, V _a963, V _a964, V[] _rest960) => {
V t_966 = default;
t_966 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_966, "to", ((V)(220D)), NewObj(2).Put("lx", ((V)((-0.8)))).Put("ly", ((V)((-0.6)))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(600D)), NewObj(3).Put("lx", ((V)(0.8))).Put("ly", ((V)((-0.8)))).Put("hyaw", ((V)(0.15))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(3).Put("lx", ((V)((-0.2)))).Put("ly", ((V)((-0.5)))).Put("hyaw", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(120D)));
Invoke(Invoke(Invoke(t_966, "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0.1))).Put("pitch", ((V)((-0.06)))).V, ((V)("io"))), "to", ((V)(80D)), NewObj(4).Put("tongue", ((V)(1D))).Put("open", ((V)(0.5))).Put("sq", ((V)((-0.06)))).Put("pitch", ((V)(0.16))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(4).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.06)))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_966, "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0.06))).Put("puff", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0D))).Put("puff", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_966, "to", ((V)(260D)), Call(o_16, V.Undef, Call(both_15, V.Undef, ((V)(8D)), ((V)(2D)))), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(2).Put("hLy", ((V)(4D))).Put("hRy", ((V)(0D))).V, NewObj(2).Put("hLy", ((V)(0D))).Put("hRy", ((V)(4D))).V, ((V)("io"))), "to", ((V)(240D)), Call(o_16, V.Undef, NOHANDS_17), ((V)("io")));
return Invoke(Invoke(Invoke(t_966, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Fly snack")), ((V)("Watches a fly buzz past, zaps it with his tongue, gulps and pats his belly.")))).Put("squish", Arr(Call(Fn((V _arrowThis973, int _argc967, V _a969, V _a970, V _a971, V _a972, V[] _rest968) => {
V t_974 = default;
t_974 = Call(TL_12, V.Undef);
Invoke(Invoke(Invoke(t_974, "to", ((V)(130D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.36))).Put("puff", ((V)(1.2))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("wide", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(380D)));
Invoke(t_974, "to", ((V)(10D)), NewObj(1).Put("puff", ((V)(0D))).V);
Call(jump_18, V.Undef, t_974, NewObj(6).Put("h", ((V)(12D))).Put("ant", ((V)(40D))).Put("up", ((V)(220D))).Put("c", ((V)(0.36))).Put("arm", ((V)(60D))).Put("st", ((V)(1.3))).V);
Invoke(t_974, "to", ((V)(100D)), NewObj(1).Put("wide", ((V)(0D))).V, ((V)("io")));
return Object_assign(Invoke(t_974, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_974, "t")) * 3D)))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, his throat puffs right out - let go and he springs up high.")))).Put("press", NewObj(2).Put("puff", ((V)(1.1))).Put("wide", ((V)(0.4))).V).Put("rel", NewObj(2).Put("dur", ((V)(1000D))).Put("k", NewObj(4).Put("lift", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(13D)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("i"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(60D)), ((V)((-0.18))), ((V)("o"))), Arr(((V)(260D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(420D)), ((V)((-0.08))), ((V)("i"))), Arr(((V)(520D)), ((V)(0.22)), ((V)("o"))), Arr(((V)(660D)), ((V)((-0.04))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(60D)), ((V)("o"))), Arr(((V)(500D)), ((V)(20D)), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(260D)), ((V)(60D)), ((V)("o"))), Arr(((V)(500D)), ((V)(20D)), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).V).V).V);
PRESS_32 = Set(R_8, "PRESS", (Get(R_8, "PRESS") is var _t975 && Truthy(_t975) ? _t975 : NewObj(0).V));
REL_33 = Set(R_8, "REL", (Get(R_8, "REL") is var _t976 && Truthy(_t976) ? _t976 : NewObj(0).V));
install_34 = Fn((V _arrowThis985, int _argc977, V MOVES_983, V CARDS_984, V _a981, V _a982, V[] _rest978) => {
V ST_986 = default;
V QUIRK_987 = default;
V QK_988 = default;
V hook_989 = default;
double tries_990 = 0;
ST_986 = NewObj(0).V;
QUIRK_987 = Arr();
Invoke(Object_keys(MOVES_983), "forEach", Fn((V _arrowThis998, int _argc991, V key_997, V _a994, V _a995, V _a996, V[] _rest992) => {
V M_999 = default;
V D_1000 = default;
M_999 = GetK(MOVES_983, key_997);
D_1000 = SetK(DESC_11, key_997, (GetK(DESC_11, key_997) is var _t1001 && Truthy(_t1001) ? _t1001 : NewObj(0).V));
Invoke(Arr(((V)("dance")), ((V)("happy")), ((V)("surprised")), ((V)("squish"))), "forEach", Fn((V _arrowThis1009, int _argc1002, V n_1008, V _a1005, V _a1006, V _a1007, V[] _rest1003) => {
if (Truthy(GetK(M_999, n_1008))) {
SetK(ST_986, ((V)(JsStrBuf.Begin().V(n_1008).S("@").V(key_997).End())), GetIdx(GetK(M_999, n_1008), 0D));
SetK(D_1000, n_1008, Arr(GetIdx(GetK(M_999, n_1008), 1D), GetIdx(GetK(M_999, n_1008), 2D)));
}
return default;
}, 1, "", true));
if (Truthy(Get(M_999, "quirk"))) {
SetK(ST_986, ((V)(JsStrBuf.Begin().S("idle_quirk@").V(key_997).End())), Object_assign(GetIdx(Get(M_999, "quirk"), 0D), NewObj(1).Put("next", ((V)("idle"))).V));
Set(D_1000, "idle_quirk", Arr(GetIdx(Get(M_999, "quirk"), 1D), GetIdx(Get(M_999, "quirk"), 2D)));
Invoke(QUIRK_987, "push", key_997);
}
if (Truthy(Get(M_999, "look"))) {
SetK(ST_986, ((V)(JsStrBuf.Begin().S("idle_look@").V(key_997).End())), Get(M_999, "look"));
}
if (Truthy(Get(M_999, "press"))) {
SetK(PRESS_32, key_997, Get(M_999, "press"));
}
if (Truthy(Get(M_999, "rel"))) {
SetK(REL_33, key_997, Get(M_999, "rel"));
}
return default;
}, 1, "", true));
{
foreach (V _k1010 in ForInKeys(CARDS_984)) {
V key_1011 = default;
key_1011 = _k1010;
SetK(CARD_25, key_1011, GetK(CARDS_984, key_1011));
Invoke(SHARED_28, "forEach", Fn((V _arrowThis1019, int _argc1012, V n_1018, V _a1015, V _a1016, V _a1017, V[] _rest1013) => {
V nm_1020 = default;
V f_1021 = default;
nm_1020 = ((V)(JsStrBuf.Begin().V(n_1018).S("@").V(key_1011).End()));
if (Truthy(((GetK(ST_986, nm_1020) is var _t1022 && Truthy(_t1022) ? _t1022 : GetK(Get(R_8, "STATES"), nm_1020)) is var _t1023 && Truthy(_t1023) ? _t1023 : (!(Truthy(GetK(Get(R_8, "STATES"), n_1018))) ? V.True : V.False)))) {
return default;
}
f_1021 = Call(flavor_27, V.Undef, GetK(Get(R_8, "STATES"), n_1018), GetK(CARDS_984, key_1011));
if (Truthy(f_1021)) {
SetK(ST_986, nm_1020, f_1021);
}
return default;
}, 1, "", true));
}
}
Invoke(R_8, "add", ST_986);
QK_988 = Set(R_8, "QUIRKK", (Get(R_8, "QUIRKK") is var _t1024 && Truthy(_t1024) ? _t1024 : New(G("Set"))));
Invoke(QUIRK_987, "forEach", Fn((V _arrowThis1032, int _argc1025, V k_1031, V _a1028, V _a1029, V _a1030, V[] _rest1026) => {
return Invoke(QK_988, "add", k_1031);
}, 1, "", true));
hook_989 = Fn((V _arrowThis1039, int _argc1033, V _a1035, V _a1036, V _a1037, V _a1038, V[] _rest1034) => {
V W_1040 = default;
V b_1041 = default;
W_1040 = Get(G("window"), "HouseIdle");
if (Truthy(((!(Truthy(W_1040)) ? V.True : V.False) is var _t1042 && Truthy(_t1042) ? _t1042 : Get(W_1040, "__q")))) {
return default;
}
Set(W_1040, "__q", ((V)(1D)));
b_1041 = Get(W_1040, "build");
Set(W_1040, "build", Fn((V _self1043, int _argc1044, V key_1050, V _a1047, V _a1048, V _a1049, V[] _rest1045) => {
V r_1052 = default;
V L_1053 = default;
if (_self1043.IsNullish) _self1043 = GlobalV;
V _arguments1051 = Arguments(_argc1044, key_1050, _a1047, _a1048, _a1049, _rest1045);
r_1052 = Invoke(b_1041, "apply", _self1043, _arguments1051);
L_1053 = GetK(Get(R_8, "FIDK"), key_1050);
if (Truthy(((Invoke(QK_988, "has", key_1050) is var _t1054 && !Truthy(_t1054) ? _t1054 : L_1053) is var _t1055 && !Truthy(_t1055) ? _t1055 : (!(Truthy(Invoke(L_1053, "includes", ((V)("idle_quirk"))))) ? V.True : V.False)))) {
Invoke(L_1053, "push", ((V)("idle_quirk")));
}
return r_1052;
return default;
}, 1, "", false));
return default;
}, 0, "", true);
tries_990 = 0D;
Call(Named(addFid_1074 => Fn((V _self1056, int _argc1057, V _a1059, V _a1060, V _a1061, V _a1062, V[] _rest1058) => {
double left_1063 = 0;
if (_self1056.IsNullish) _self1056 = GlobalV;
Call(hook_989, V.Undef);
left_1063 = 0D;
Invoke(QUIRK_987, "forEach", Fn((V _arrowThis1071, int _argc1064, V key_1070, V _a1067, V _a1068, V _a1069, V[] _rest1065) => {
V L_1072 = default;
L_1072 = GetK(Get(R_8, "FIDK"), key_1070);
if (!(Truthy(L_1072))) {
left_1063++;
return default;
}
if (!(Truthy(Invoke(L_1072, "includes", ((V)("idle_quirk")))))) {
Invoke(L_1072, "push", ((V)("idle_quirk")));
}
return default;
}, 1, "", true));
if (Truthy((((V)(left_1063)) is var _t1073 && !Truthy(_t1073) ? _t1073 : ((++tries_990 < 120D) ? V.True : V.False)))) {
Call(G("setTimeout"), V.Undef, addFid_1074.v, ((V)(100D)));
} else {
if (Truthy((((V)(left_1063)) is var _t1075 && !Truthy(_t1075) ? _t1075 : Get(R_8, "idleV")))) {
Invoke(QUIRK_987, "forEach", Fn((V _arrowThis1083, int _argc1076, V key_1082, V _a1079, V _a1080, V _a1081, V[] _rest1077) => {
if (!(Truthy(GetK(Get(R_8, "FIDK"), key_1082)))) {
SetK(Get(R_8, "FIDK"), key_1082, Invoke(Invoke(Get(R_8, "FIDGETS"), "filter", Fn((V _arrowThis1091, int _argc1084, V n_1090, V _a1087, V _a1088, V _a1089, V[] _rest1085) => {
return (!SEqS(n_1090, "idle_waveL") ? V.True : V.False);
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
Set(R_8, "HS", (Get(R_8, "HS") is var _t1092 && Truthy(_t1092) ? _t1092 : NewObj(0).V));
G_35 = Invoke(Get(R_8, "GROUPS"), "find", Fn((V _arrowThis1100, int _argc1093, V g_1099, V _a1096, V _a1097, V _a1098, V[] _rest1094) => {
return (SEqS(Get(g_1099, "name"), "Idle") ? V.True : V.False);
}, 1, "", true));
if (Truthy((G_35 is var _t1109 && !Truthy(_t1109) ? _t1109 : (!(Truthy(Invoke(Get(G_35, "items"), "some", Fn((V _arrowThis1108, int _argc1101, V i_1107, V _a1104, V _a1105, V _a1106, V[] _rest1102) => {
return (SEqS(GetIdx(i_1107, 0D), "idle_quirk") ? V.True : V.False);
}, 1, "", true)))) ? V.True : V.False)))) {
Invoke(Get(G_35, "items"), "splice", ((V)(2D)), ((V)(0D)), Arr(((V)("idle_quirk")), ((V)("Little habit")), ((V)("A habit of its own."))));
}
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
