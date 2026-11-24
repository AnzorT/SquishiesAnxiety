// mittens-moves.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_mittens_moves_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("y$", "");
        public static void Run()
        {
Call(Named(boot_196 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V R_8 = default;
V REST_9 = default;
V r2_10 = default;
V SM_11 = default;
double TAU_12 = 0;
V TL_13 = default;
V S_14 = default;
V hand_15 = default;
V both_16 = default;
V o_17 = default;
V ST_18 = default;
V wave_19 = default;
V HOLD_20 = default;
V chew_21 = default;
V gulp_22 = default;
V bite_23 = default;
V STYLE_24 = default;
V REACT_25 = default;
V foodProp_26 = default;
V top_27 = default;
V FOODS_28 = default;
V meal_29 = default;
V toolProp_30 = default;
V SPONGE_31 = default;
V BRUSH_32 = default;
V DUCK_33 = default;
V WAND_34 = default;
V FOAM_35 = default;
V foamFx_36 = default;
V B_37 = default;
V fxs_38 = default;
V SOAP_39 = default;
V soapFx_40 = default;
V MINI_41 = default;
V SOAPCFG_42 = default;
V pokeEar_43 = default;
V pokeEye_44 = default;
V pokeCheek_45 = default;
V pokeSide_46 = default;
V pokeFoot_47 = default;
V whip_48 = default;
V F_49 = default;
if (_self1.IsNullish) _self1 = GlobalV;
TL_13 = Fn((V _self50, int _argc51, V _a53, V _a54, V _a55, V _a56, V[] _rest52) => {
V k_57 = default;
V ev_58 = default;
V em_59 = default;
V t_60 = default;
V o_61 = default;
if (_self50.IsNullish) _self50 = GlobalV;
k_57 = NewObj(0).V;
ev_58 = Arr();
em_59 = Arr();
t_60 = ((V)(0D));
o_61 = NewObj(11).Getter("t", Fn((V _self62, int _argc63, V _a65, V _a66, V _a67, V _a68, V[] _rest64) => {
if (_self62.IsNullish) _self62 = GlobalV;
return t_60;
return default;
}, 0, "t", false)).Put("to", Fn((V _self69, int _argc70, V dt_76, V v_77, V ez_78, V _a75, V[] _rest71) => {
if (_self69.IsNullish) _self69 = GlobalV;
{
foreach (V _k79 in ForInKeys(v_77)) {
V p_80 = default;
p_80 = _k79;
V L_81 = default;
L_81 = (GetK(k_57, p_80) is var _t82 && Truthy(_t82) ? _t82 : SetK(k_57, p_80, Arr(Arr(((V)(0D)), GetK(REST_9, p_80)))));
if (Lt(GetIdx(GetIdx(L_81, (ToNum(Get(L_81, "length")) - 1D)), 0D), t_60)) {
Invoke(L_81, "push", Arr(t_60, GetIdx(GetIdx(L_81, (ToNum(Get(L_81, "length")) - 1D)), 1D), ((V)("l"))));
}
}
}
t_60 = Add(t_60, dt_76);
{
foreach (V _k83 in ForInKeys(v_77)) {
V p_84 = default;
p_84 = _k83;
Invoke(GetK(k_57, p_84), "push", Arr(t_60, GetK(v_77, p_84), (ez_78 is var _t85 && Truthy(_t85) ? _t85 : ((V)("io")))));
}
}
return o_61;
return default;
}, 3, "to", false)).Put("wait", Fn((V _self86, int _argc87, V dt_93, V _a90, V _a91, V _a92, V[] _rest88) => {
if (_self86.IsNullish) _self86 = GlobalV;
t_60 = Add(t_60, dt_93);
return o_61;
return default;
}, 1, "wait", false)).Put("at", Fn((V _self94, int _argc95, V x_101, V _a98, V _a99, V _a100, V[] _rest96) => {
if (_self94.IsNullish) _self94 = GlobalV;
t_60 = x_101;
return o_61;
return default;
}, 1, "at", false)).Put("e", Fn((V _self102, int _argc103, V _a105, V _a106, V _a107, V _a108, V[] _rest104) => {
V a_109 = default;
if (_self102.IsNullish) _self102 = GlobalV;
a_109 = RestArgs(0, _argc103, _a105, _a106, _a107, _a108, _rest104);
Invoke(ev_58, "push", new ArrBuilder().Add(t_60).Spread(a_109).V);
return o_61;
return default;
}, 1, "e", false)).Put("em", Fn((V _self110, int _argc111, V dur_117, V every_118, V preset_119, V where_120, V[] _rest112) => {
V n_121 = default;
if (_self110.IsNullish) _self110 = GlobalV;
n_121 = (_argc111 > 4 ? _rest112[0] : V.Undef);
Invoke(em_59, "push", Arr(t_60, Add(t_60, dur_117), every_118, preset_119, where_120, n_121));
return o_61;
return default;
}, 5, "em", false)).Put("osc", Fn((V _self122, int _argc123, V dt_129, V n_130, V A_131, V B_132, V[] _rest124) => {
double h_134 = 0;
V ez_133 = default;
if (_self122.IsNullish) _self122 = GlobalV;
ez_133 = (_argc123 > 4 ? _rest124[0] : V.Undef);
h_134 = ((ToNum(dt_129) / ToNum(n_130)) / 2D);
{
double i_135 = 0;
i_135 = 0D;
while (true) {
if (!(Lt(((V)(i_135)), n_130))) break;
Invoke(Invoke(o_61, "to", ((V)(h_134)), A_131, (ez_133 is var _t138 && Truthy(_t138) ? _t138 : ((V)("io")))), "to", ((V)(h_134)), B_132, (ez_133 is var _t137 && Truthy(_t137) ? _t137 : ((V)("io"))));
i_135++;
}
}
return o_61;
return default;
}, 5, "osc", false)).Put("rest", Fn((V _self139, int _argc140, V dt_146, V ez_147, V _a144, V _a145, V[] _rest141) => {
V b_148 = default;
if (_self139.IsNullish) _self139 = GlobalV;
b_148 = NewObj(0).V;
{
foreach (V _k149 in ForInKeys(k_57)) {
V p_150 = default;
p_150 = _k149;
SetK(b_148, p_150, GetK(REST_9, p_150));
}
}
return Invoke(o_61, "to", (dt_146 is var _t151 && Truthy(_t151) ? _t151 : ((V)(450D))), b_148, ez_147);
return default;
}, 2, "rest", false)).Put("out", Fn((V _self152, int _argc153, V x_159, V loop_160, V _a157, V _a158, V[] _rest154) => {
if (_self152.IsNullish) _self152 = GlobalV;
{
foreach (V _k161 in ForInKeys(k_57)) {
V p_162 = default;
p_162 = _k161;
Invoke(GetK(k_57, p_162), "sort", Fn((V _self152, int _argc163, V a_169, V b_170, V _a167, V _a168, V[] _rest164) => {
return ((V)((ToNum(GetIdx(a_169, 0D)) - ToNum(GetIdx(b_170, 0D)))));
}, 2, "", true));
}
}
Invoke(ev_58, "sort", Fn((V _self152, int _argc171, V a_177, V b_178, V _a175, V _a176, V[] _rest172) => {
return ((V)((ToNum(GetIdx(a_177, 0D)) - ToNum(GetIdx(b_178, 0D)))));
}, 2, "", true));
return Object_assign((Truthy(loop_160) ? NewObj(1).Put("loop", t_60).V : NewObj(1).Put("dur", t_60).V), NewObj(3).Put("k", k_57).Put("ev", ev_58).Put("emit", em_59).V, (x_159 is var _t179 && Truthy(_t179) ? _t179 : NewObj(0).V));
return default;
}, 2, "out", false)).Put("done", Fn((V _self180, int _argc181, V x_187, V _a184, V _a185, V _a186, V[] _rest182) => {
if (_self180.IsNullish) _self180 = GlobalV;
return Invoke(o_61, "out", x_187);
return default;
}, 1, "done", false)).Put("loop", Fn((V _self188, int _argc189, V x_195, V _a192, V _a193, V _a194, V[] _rest190) => {
if (_self188.IsNullish) _self188 = GlobalV;
return Invoke(o_61, "out", x_195, (true ? V.True : V.False));
return default;
}, 1, "loop", false)).V;
return o_61;
return default;
}, 0, "TL", false);
R_8 = Get(G("window"), "RiveRig");
if ((!(Truthy(R_8)) || !(Truthy(Get(R_8, "REST"))))) {
Call(G("setTimeout"), V.Undef, boot_196.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_8, "movesV"))) {
return default;
}
Set(R_8, "movesV", ((V)(1D)));
REST_9 = Get(R_8, "REST");
r2_10 = Get(R_8, "r2");
SM_11 = Get(R_8, "SM");
TAU_12 = (System.Math.PI * 2D);
S_14 = Fn((V _self1, int _argc197, V s_203, V _a200, V _a201, V _a202, V[] _rest198) => {
return (LtN(s_203, 0D) ? NewObj(9).Put("arm", ((V)("armL"))).Put("hx", ((V)("hLx"))).Put("hy", ((V)("hLy"))).Put("hz", ((V)("hLz"))).Put("ear", ((V)("earL"))).Put("wink", ((V)("winkL"))).Put("foot", ((V)("footL"))).Put("eye", ((V)("eyeL"))).Put("paw", ((V)("pawL"))).V : NewObj(9).Put("arm", ((V)("armR"))).Put("hx", ((V)("hRx"))).Put("hy", ((V)("hRy"))).Put("hz", ((V)("hRz"))).Put("ear", ((V)("earR"))).Put("wink", ((V)("winkR"))).Put("foot", ((V)("footR"))).Put("eye", ((V)("eyeR"))).Put("paw", ((V)("pawR"))).V);
}, 1, "", true);
hand_15 = Fn((V _self1, int _argc204, V s_210, V inX_211, V y_212, V z_213, V[] _rest205) => {
V k_214 = default;
V q_215 = default;
k_214 = Call(S_14, V.Undef, s_210);
q_215 = NewObj(2).PutK(Get(k_214, "hx"), (LtN(s_210, 0D) ? inX_211 : ((V)((-ToNum(inX_211)))))).PutK(Get(k_214, "hy"), y_212).V;
if (!z_213.IsNullish) {
SetK(q_215, Get(k_214, "hz"), z_213);
}
return q_215;
return default;
}, 4, "", true);
both_16 = Fn((V _self1, int _argc216, V inX_222, V y_223, V z_224, V _a221, V[] _rest217) => {
return Object_assign(Call(hand_15, V.Undef, ((V)((-1D))), inX_222, y_223, z_224), Call(hand_15, V.Undef, ((V)(1D)), inX_222, y_223, z_224));
}, 3, "", true);
o_17 = Fn((V _self1, int _argc225, V _a227, V _a228, V _a229, V _a230, V[] _rest226) => {
V a_231 = default;
a_231 = RestArgs(0, _argc225, _a227, _a228, _a229, _a230, _rest226);
return InvokeSpread(G("Object"), "assign", new ArrBuilder().Add(NewObj(0).V).Spread(a_231).V);
}, 1, "", true);
ST_18 = NewObj(0).V;
Set(ST_18, "idle_look", Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(240D)), NewObj(1).Put("lx", ((V)((-0.9)))).V, ((V)("o"))), "to", ((V)(520D)), NewObj(7).Put("spin", ((V)((-34D)))).Put("turn", ((V)((-0.4)))).Put("lean", ((V)((-1.4)))).Put("x", ((V)((-1.2)))).Put("footL", ((V)(2.2))).Put("htilt", ((V)((-2D)))).Put("wag", ((V)(10D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("footL", ((V)(0D))).Put("sq", ((V)(0.035))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(800D))), "e", ((V)("blink"))), "to", ((V)(240D)), NewObj(1).Put("lx", ((V)(0.9))).V, ((V)("o"))), "to", ((V)(700D)), NewObj(7).Put("spin", ((V)(34D))).Put("turn", ((V)(0.4))).Put("lean", ((V)(1.4))).Put("x", ((V)(1.2))).Put("footR", ((V)(2.2))).Put("htilt", ((V)(2D))).Put("wag", ((V)((-10D)))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("footR", ((V)(0D))).Put("sq", ((V)(0.035))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(800D))), "to", ((V)(220D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("o"))), "to", ((V)(560D)), NewObj(7).Put("spin", ((V)(0D))).Put("turn", ((V)(0D))).Put("lean", ((V)(0D))).Put("x", ((V)(0D))).Put("htilt", ((V)(0D))).Put("footL", ((V)(1.6))).Put("wag", ((V)(0D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("footL", ((V)(0D))).Put("sq", ((V)(0.03))).V), "rest", ((V)(320D))), "done"));
{
V nat_232 = default;
nat_232 = Fn((V _self1, int _argc233, V k_239, V _a236, V _a237, V _a238, V[] _rest234) => {
V t_240 = default;
V turn_241 = default;
V e_242 = default;
t_240 = Call(TL_13, V.Undef);
turn_241 = Fn((V _self1, int _argc243, V T_249, V from_250, V to_251, V d1_252, V[] _rest244) => {
double s_254 = 0;
double dir_255 = 0;
double bendTo_256 = 0;
double twTo_257 = 0;
double wg_258 = 0;
V d2_253 = default;
d2_253 = (_argc243 > 4 ? _rest244[0] : V.Undef);
s_254 = Sign((ToNum(to_251) - ToNum(from_250)));
dir_255 = Sign(ToNum(to_251));
bendTo_256 = ((dir_255 * 4D) * ToNum(k_239));
twTo_257 = ((ToNum(to_251) * 0.36) * ToNum(k_239));
wg_258 = ((-s_254) * 14D);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_240, "at", T_249), "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((dir_255 * 0.9)))).V, ((V)("o"))), "e", ((V)("blink"))), "to", d1_252, NewObj(4).Put("hyaw", ((V)((ToNum(Add(from_250, to_251)) / 2D)))).Put("pitch", ((V)((-0.24)))).Put("earL", ((V)((s_254 * 8D)))).Put("earR", ((V)(((-s_254) * 8D)))).V, ((V)("i"))), "to", d2_253, NewObj(5).Put("hyaw", Add(to_251, ((V)((s_254 * 0.08))))).Put("pitch", ((V)(0.05))).Put("earL", ((V)(((-s_254) * 3D)))).Put("earR", ((V)((s_254 * 3D)))).Put("htilt", ((V)(((dir_255 * 3D) - bendTo_256)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("hyaw", to_251).Put("pitch", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_240, "at", Add(T_249, ((V)(200D)))), "to", Add(d1_252, d2_253), NewObj(4).Put("twist", ((V)((twTo_257 + ((s_254 * 0.06) * ToNum(k_239)))))).Put("turn", ((V)((ToNum(to_251) * 0.07)))).Put("bend", ((V)((bendTo_256 + ((s_254 * 1.2) * ToNum(k_239)))))).Put("wag", ((V)(wg_258))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(3).Put("twist", ((V)(twTo_257))).Put("bend", ((V)(bendTo_256))).Put("wag", ((V)((wg_258 * 0.4)))).V, ((V)("io")));
return Add(Add(Add(Add(T_249, ((V)(110D))), d1_252), d2_253), ((V)(320D)));
return default;
}, 5, "", true);
Invoke(t_240, "to", ((V)(1D)), NewObj(1).Put("lean", ((V)(0D))).V);
e_242 = Call(turn_241, V.Undef, ((V)(250D)), ((V)(0D)), ((V)((-0.78))), ((V)(150D)), ((V)(190D)));
e_242 = Call(turn_241, V.Undef, Add(e_242, ((V)(1000D))), ((V)((-0.78))), ((V)(0.78)), ((V)(190D)), ((V)(230D)));
e_242 = Call(turn_241, V.Undef, Add(e_242, ((V)(1000D))), ((V)(0.78)), ((V)(0D)), ((V)(150D)), ((V)(190D)));
return Invoke(Invoke(Invoke(t_240, "at", Add(e_242, ((V)(260D)))), "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 1, "", true);
Invoke(Arr(((V)("mittens")), ((V)("biscuit")), ((V)("prickle")), ((V)("nibbles")), ((V)("quill")), ((V)("poppy")), ((V)("duchess")), ((V)("mamapaws")), ((V)("waffles")), ((V)("truffle")), ((V)("ribbit"))), "forEach", Fn((V _self1, int _argc259, V key_265, V _a262, V _a263, V _a264, V[] _rest260) => {
SetK(ST_18, ((V)(JsStrBuf.Begin().S("idle_look@").V(key_265).End())), Call(nat_232, V.Undef, ((V)(1D))));
return default;
}, 1, "", true));
}
Set(ST_18, "idle_yawn", Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(300D)), NewObj(3).Put("sq", ((V)(0.04))).Put("pitch", ((V)((-0.1)))).Put("close", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(650D)), NewObj(13).Put("sq", ((V)((-0.1)))).Put("pitch", ((V)(0.45))).Put("open", ((V)(0.95))).Put("mw", ((V)(0.8))).Put("close", ((V)(0.85))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("hLy", ((V)((-4D)))).Put("hRy", ((V)((-4D)))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).Put("tongue", ((V)(0.25))).Put("lift", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(1.5))).V, NewObj(1).Put("tilt", ((V)((-1.5)))).V, ((V)("s"))), "to", ((V)(550D)), NewObj(14).Put("sq", ((V)(0.05))).Put("pitch", ((V)((-0.05)))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("close", ((V)(0.35))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("earL", ((V)(4D))).Put("earR", ((V)(4D))).Put("tongue", ((V)(0D))).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(520D)), ((V)(2D)), NewObj(2).Put("open", ((V)(0.16))).Put("smile", ((V)(0.3))).V, NewObj(2).Put("open", ((V)(0D))).Put("smile", ((V)(0.2))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(4).Put("close", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V), "e", ((V)("blink2"))), "wait", ((V)(400D))), "rest", ((V)(400D))), "done"));
wave_19 = Fn((V _self1, int _argc266, V s_272, V _a269, V _a270, V _a271, V[] _rest267) => {
V k_273 = default;
V t_274 = default;
V a_275 = default;
V b_276 = default;
k_273 = Call(S_14, V.Undef, s_272);
t_274 = Call(TL_13, V.Undef);
Invoke(Invoke(t_274, "to", ((V)(220D)), NewObj(3).PutK(Get(k_273, "arm"), ((V)((-10D)))).Put("sq", ((V)(0.04))).Put("lx", ((V)((ToNum(s_272) * 0.2)))).V, ((V)("io"))), "to", ((V)(380D)), NewObj(10).PutK(Get(k_273, "arm"), ((V)(150D))).PutK(Get(k_273, "hy"), ((V)((-3D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("lean", ((V)(((-ToNum(s_272)) * 1.4)))).Put("htilt", ((V)((ToNum(s_272) * 5D)))).Put("sq", ((V)((-0.04)))).Put("turn", ((V)((ToNum(s_272) * 0.15)))).PutK(Get(k_273, "ear"), ((V)((-8D)))).V, ((V)("o")));
a_275 = Get(t_274, "t");
Invoke(t_274, "osc", ((V)(1800D)), ((V)(4D)), NewObj(1).PutK(Get(k_273, "arm"), ((V)(118D))).V, NewObj(1).PutK(Get(k_273, "arm"), ((V)(165D))).V, ((V)("io")));
b_276 = Get(t_274, "t");
Invoke(Invoke(Invoke(t_274, "at", a_275), "osc", ((V)(1800D)), ((V)(3D)), NewObj(2).Put("wag", ((V)(16D))).Put("sq", ((V)((-0.01)))).V, NewObj(2).Put("wag", ((V)((-16D)))).Put("sq", ((V)((-0.05)))).V, ((V)("s"))), "at", b_276);
return Invoke(Invoke(Invoke(Invoke(Invoke(t_274, "wait", ((V)(120D))), "to", ((V)(460D)), NewObj(9).PutK(Get(k_273, "arm"), ((V)(0D))).PutK(Get(k_273, "hy"), ((V)(0D))).Put("lean", ((V)(0D))).Put("htilt", ((V)(0D))).Put("sq", ((V)(0.035))).Put("open", ((V)(0D))).Put("turn", ((V)(0D))).Put("wag", ((V)(0D))).PutK(Get(k_273, "ear"), ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(3).Put("sq", ((V)(0D))).Put("hap", ((V)(0.2))).Put("smile", ((V)(0.4))).V), "rest", ((V)(420D))), "done");
return default;
}, 1, "", true);
Set(ST_18, "idle_waveL", Call(wave_19, V.Undef, ((V)((-1D)))));
Set(ST_18, "idle_waveR", Call(wave_19, V.Undef, ((V)(1D))));
Invoke(Get(R_8, "FIDGETS"), "push", ((V)("idle_look")), ((V)("idle_yawn")), ((V)("idle_waveL")), ((V)("idle_waveR")));
Set(ST_18, "dance", Call(Fn((V _self1, int _argc277, V _a279, V _a280, V _a281, V _a282, V[] _rest278) => {
V t_283 = default;
double h_284 = 0;
V bt_285 = default;
t_283 = Call(TL_13, V.Undef);
h_284 = 250D;
bt_285 = Fn((V _self1, int _argc286, V dn_292, V up_293, V _a290, V _a291, V[] _rest287) => {
return Invoke(Invoke(t_283, "to", ((V)(h_284)), Call(o_17, V.Undef, NewObj(2).Put("sq", ((V)(0.1))).Put("lift", ((V)(0D))).V, dn_292), ((V)("io"))), "to", ((V)(h_284)), Call(o_17, V.Undef, NewObj(2).Put("sq", ((V)((-0.04)))).Put("lift", ((V)(1.6))).V, (up_293 is var _t294 && Truthy(_t294) ? _t294 : NewObj(0).V)), ((V)("o")));
}, 2, "", true);
Invoke(t_283, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Call(bt_285, V.Undef, NewObj(8).Put("x", ((V)(4D))).Put("lean", ((V)(2D))).Put("armL", ((V)((-6D)))).Put("armR", ((V)(34D))).Put("htilt", ((V)(3D))).Put("turn", ((V)(0.2))).Put("hap", ((V)(0.7))).Put("smile", ((V)(0.9))).V, NewObj(1).Put("footL", ((V)(2.5))).V);
Call(bt_285, V.Undef, NewObj(2).Put("footL", ((V)(0D))).Put("lean", ((V)(1D))).V);
Call(bt_285, V.Undef, NewObj(6).Put("x", ((V)((-4D)))).Put("lean", ((V)((-2D)))).Put("armL", ((V)(34D))).Put("armR", ((V)((-6D)))).Put("htilt", ((V)((-3D)))).Put("turn", ((V)((-0.2)))).V, NewObj(1).Put("footR", ((V)(2.5))).V);
Call(bt_285, V.Undef, NewObj(2).Put("footR", ((V)(0D))).Put("lean", ((V)((-1D)))).V);
Invoke(t_283, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Invoke(Arr(((V)((-1D))), ((V)(1D)), ((V)((-1D))), ((V)(1D))), "forEach", Fn((V _self1, int _argc295, V d_301, V _a298, V _a299, V _a300, V[] _rest296) => {
return Call(bt_285, V.Undef, NewObj(9).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).Put("htilt", ((V)((ToNum(d_301) * 2D)))).Put("turn", ((V)(0D))).Put("pitch", ((V)(0.1))).Put("footL", ((V)((LtN(d_301, 0D) ? 4.5 : 0D)))).Put("footR", ((V)((GtN(d_301, 0D) ? 4.5 : 0D)))).Put("armL", ((V)((LtN(d_301, 0D) ? 45D : (-12D))))).Put("armR", ((V)((GtN(d_301, 0D) ? 45D : (-12D))))).V, (LtN(d_301, 0D) ? NewObj(1).Put("footL", ((V)(1D))).V : NewObj(1).Put("footR", ((V)(1D))).V));
}, 1, "", true));
Invoke(t_283, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Invoke(Arr(((V)(1D)), ((V)((-1D))), ((V)(1D)), ((V)((-1D)))), "forEach", Fn((V _self1, int _argc302, V d_308, V _a305, V _a306, V _a307, V[] _rest303) => {
V k_309 = default;
V j_310 = default;
k_309 = Call(S_14, V.Undef, d_308);
j_310 = Call(S_14, V.Undef, ((V)((-ToNum(d_308)))));
Invoke(Invoke(t_283, "to", ((V)(130D)), NewObj(14).Put("sq", ((V)(0.17))).Put("lift", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("pitch", ((V)(0D))).Put("tilt", ((V)((ToNum(d_308) * 7D)))).Put("lean", ((V)((ToNum(d_308) * 3D)))).Put("htilt", ((V)(((-ToNum(d_308)) * 4D)))).PutK(Get(k_309, "arm"), ((V)(150D))).PutK(Get(k_309, "hy"), ((V)((-4D)))).PutK(Get(j_310, "arm"), ((V)((-10D)))).PutK(Get(j_310, "hy"), ((V)(0D))).Put("wide", ((V)(0.3))).Put("hap", ((V)(0D))).V, ((V)("o"))), "to", ((V)(370D)), NewObj(2).Put("sq", ((V)(0.12))).Put("tilt", ((V)((ToNum(d_308) * 6D)))).V, ((V)("io")));
return default;
}, 1, "", true));
Invoke(Invoke(t_283, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(500D)), NewObj(11).Put("sq", ((V)(0.22))).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)((-14D)))).Put("armR", ((V)((-14D)))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("wide", ((V)(0D))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V, ((V)("io")));
{
V a_311 = default;
V b_312 = default;
a_311 = Get(t_283, "t");
Invoke(Invoke(Invoke(Invoke(t_283, "to", ((V)(260D)), NewObj(8).Put("sq", ((V)((-0.18)))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(480D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0.28))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(1).Put("sq", ((V)((-0.06)))).V, ((V)("io")));
b_312 = Get(t_283, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_283, "at", a_311), "to", ((V)(430D)), NewObj(1).Put("lift", ((V)(15D))).V, ((V)("o"))), "to", ((V)(430D)), NewObj(1).Put("lift", ((V)(0D))).V, ((V)("i"))), "at", Add(a_311, ((V)(60D)))), "to", ((V)(760D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "at", b_312), "e", ((V)("emit")), ((V)("spark")), ((V)("body")), ((V)(6D)));
}
Invoke(t_283, "to", ((V)(500D)), NewObj(5).Put("sq", ((V)(0.04))).Put("armL", ((V)(75D))).Put("armR", ((V)(75D))).Put("open", ((V)(0.3))).Put("winkR", ((V)(1D))).V, ((V)("o")));
Invoke(t_283, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Invoke(Arr(((V)(1D)), ((V)((-1D))), ((V)(1D))), "forEach", Fn((V _self1, int _argc313, V d_319, V _a316, V _a317, V _a318, V[] _rest314) => {
return Call(bt_285, V.Undef, NewObj(9).Put("sq", ((V)(0.09))).Put("pitch", ((V)((-0.25)))).Put("armL", ((V)((GtN(d_319, 0D) ? 22D : 6D)))).Put("armR", ((V)((GtN(d_319, 0D) ? 6D : 22D)))).Put("htilt", ((V)((ToNum(d_319) * 3D)))).Put("turn", ((V)((ToNum(d_319) * 0.15)))).Put("x", ((V)((ToNum(d_319) * 1.5)))).Put("winkR", ((V)(0D))).Put("open", ((V)(0.15))).V, NewObj(2).Put("sq", ((V)((-0.02)))).Put("lift", ((V)(1D))).V);
}, 1, "", true));
Invoke(Invoke(t_283, "to", ((V)(h_284)), NewObj(7).Put("sq", ((V)(0.09))).Put("pitch", ((V)((-0.25)))).Put("armL", ((V)(6D))).Put("armR", ((V)(22D))).Put("htilt", ((V)((-3D)))).Put("turn", ((V)((-0.15)))).Put("x", ((V)((-1.5)))).V, ((V)("io"))), "rest", ((V)(h_284)), ((V)("io")));
return Invoke(t_283, "loop");
return default;
}, 0, "", true), V.Undef));
HOLD_20 = NewObj(2).Put("two", NewObj(2).Put("chest", Call(both_16, V.Undef, ((V)(7D)), ((V)((-6D))))).Put("mouth", Call(both_16, V.Undef, ((V)(10D)), ((V)((-13D))))).V).Put("R", NewObj(2).Put("chest", Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-8D))))).Put("mouth", Call(hand_15, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D))))).V).V;
chew_21 = Fn((V _self1, int _argc320, V t_326, V n_327, V big_328, V _a325, V[] _rest321) => {
return Invoke(t_326, "osc", ((V)((ToNum(n_327) * 260D))), n_327, NewObj(5).Put("open", ((V)(0.24))).Put("puff", ((V)((Truthy(big_328) ? 1D : 0.65)))).Put("htilt", ((V)(2.5))).Put("sq", ((V)(0.025))).Put("mw", ((V)(0.85))).V, NewObj(5).Put("open", ((V)(0.02))).Put("puff", ((V)((Truthy(big_328) ? 0.85 : 0.5)))).Put("htilt", ((V)((-2.5)))).Put("sq", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("s")));
}, 3, "", true);
gulp_22 = Fn((V _self1, int _argc329, V t_335, V _a332, V _a333, V _a334, V[] _rest330) => {
return Invoke(Invoke(Invoke(t_335, "to", ((V)(150D)), NewObj(5).Put("puff", ((V)(0D))).Put("sq", ((V)(0.06))).Put("pitch", ((V)(0.18))).Put("open", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("o"))), "e", ((V)("gulp"))), "to", ((V)(220D)), NewObj(2).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
bite_23 = Fn((V _self1, int _argc336, V t_342, V H_343, V last_344, V _a341, V[] _rest337) => {
Invoke(Invoke(Invoke(Invoke(t_342, "to", ((V)(300D)), Call(o_17, V.Undef, Get(H_343, "mouth"), NewObj(6).Put("open", ((V)(0.75))).Put("pitch", ((V)((-0.1)))).Put("ly", ((V)(0.4))).Put("lean", ((V)(0.4))).Put("hap", ((V)(0D))).Put("wide", ((V)(0.15))).V), ((V)("io"))), "to", ((V)(90D)), NewObj(4).Put("open", ((V)(0D))).Put("sq", ((V)(0.07))).Put("earL", ((V)(4D))).Put("earR", ((V)(4D))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")));
if (Truthy(last_344)) {
Invoke(t_342, "e", ((V)("done")));
}
return Invoke(t_342, "to", ((V)(280D)), Call(o_17, V.Undef, Get(H_343, "chest"), NewObj(8).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("lean", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0.2))).Put("puff", ((V)(0.5))).Put("wide", ((V)(0D))).V), ((V)("io")));
return default;
}, 3, "", true);
STYLE_24 = NewObj(9).Put("chomp", Fn((V _self345, int _argc346, V t_352, V H_353, V f_354, V _a351, V[] _rest347) => {
if (_self345.IsNullish) _self345 = GlobalV;
{
double i_355 = 0;
i_355 = 0D;
while (true) {
if (!(Lt(((V)(i_355)), Get(f_354, "n")))) break;
Call(bite_23, V.Undef, t_352, H_353, ((i_355 == (ToNum(Get(f_354, "n")) - 1D)) ? V.True : V.False));
Call(chew_21, V.Undef, t_352, (Get(f_354, "chew") is var _t357 && Truthy(_t357) ? _t357 : ((V)(3D))));
Call(gulp_22, V.Undef, t_352);
i_355++;
}
}
return default;
}, 3, "chomp", false)).Put("nibble", Fn((V _self358, int _argc359, V t_365, V H_366, V f_367, V _a364, V[] _rest360) => {
if (_self358.IsNullish) _self358 = GlobalV;
Invoke(t_365, "to", ((V)(320D)), Call(o_17, V.Undef, Get(H_366, "mouth"), NewObj(2).Put("pitch", ((V)((-0.05)))).Put("ly", ((V)(0.5))).V), ((V)("io")));
{
double i_368 = 0;
i_368 = 0D;
while (true) {
if (!(Lt(((V)(i_368)), Get(f_367, "n")))) break;
Invoke(Invoke(Invoke(Invoke(t_365, "to", ((V)(85D)), NewObj(3).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).Put("sq", ((V)(0.02))).V, ((V)("o"))), "to", ((V)(85D)), NewObj(3).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("puff", ((V)(0.45))).V, ((V)("io"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D)));
i_368++;
}
}
Invoke(Invoke(t_365, "e", ((V)("done"))), "to", ((V)(260D)), Call(o_17, V.Undef, Get(H_366, "chest"), NewObj(2).Put("puff", ((V)(0.55))).Put("mw", ((V)(1D))).V), ((V)("io")));
Call(chew_21, V.Undef, t_365, ((V)(3D)));
Call(gulp_22, V.Undef, t_365);
return default;
}, 3, "nibble", false)).Put("typewriter", Fn((V _self370, int _argc371, V t_377, V H_378, V f_379, V _a376, V[] _rest372) => {
V m_380 = default;
if (_self370.IsNullish) _self370 = GlobalV;
m_380 = Get(H_378, "mouth");
{
double row_381 = 0;
row_381 = 0D;
while (true) {
if (!((row_381 < 2D))) break;
Invoke(t_377, "to", ((V)(300D)), Call(o_17, V.Undef, m_380, NewObj(5).Put("hLx", Add(Get(m_380, "hLx"), ((V)(6D)))).Put("hRx", Add(Get(m_380, "hRx"), ((V)(6D)))).Put("pitch", ((V)((-0.05)))).Put("ly", ((V)(0.4))).Put("turn", ((V)(0.15))).V), ((V)("io")));
{
double i_383 = 0;
i_383 = 0D;
while (true) {
if (!(Lt(((V)(i_383)), Get(f_379, "n")))) break;
double p_385 = 0;
p_385 = (6D - (((i_383 + 1D) * 12D) / ToNum(Get(f_379, "n"))));
Invoke(Invoke(Invoke(Invoke(t_377, "to", ((V)(110D)), NewObj(4).Put("open", ((V)(0.35))).Put("hLx", Add(Get(m_380, "hLx"), ((V)(p_385)))).Put("hRx", Add(Get(m_380, "hRx"), ((V)(p_385)))).Put("turn", ((V)(((-p_385) / 32D)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(2).Put("open", ((V)(0D))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D)));
i_383++;
}
}
Invoke(Invoke(Invoke(t_377, "to", ((V)(170D)), NewObj(5).Put("hLx", Add(Get(m_380, "hLx"), ((V)(6D)))).Put("hRx", Add(Get(m_380, "hRx"), ((V)(6D)))).Put("turn", ((V)(0.2))).Put("sq", ((V)(0D))).Put("wide", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("ding"))), "to", ((V)(120D)), NewObj(1).Put("wide", ((V)(0D))).V);
row_381++;
}
}
Invoke(Invoke(t_377, "e", ((V)("done"))), "to", ((V)(300D)), Call(o_17, V.Undef, Get(H_378, "chest"), NewObj(2).Put("turn", ((V)(0D))).Put("puff", ((V)(0.7))).V), ((V)("io")));
Call(chew_21, V.Undef, t_377, ((V)(3D)));
if (Truthy(Get(f_379, "seed"))) {
Invoke(Invoke(Invoke(t_377, "to", ((V)(160D)), NewObj(4).Put("puff", ((V)(0.3))).Put("mw", ((V)(0.45))).Put("open", ((V)(0.2))).Put("turn", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth"))), "to", ((V)(220D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("turn", ((V)(0D))).V);
}
Call(gulp_22, V.Undef, t_377);
return default;
}, 3, "typewriter", false)).Put("lick", Fn((V _self386, int _argc387, V t_393, V H_394, V f_395, V _a392, V[] _rest388) => {
V L_396 = default;
if (_self386.IsNullish) _self386 = GlobalV;
L_396 = Call(o_17, V.Undef, Get(H_394, "mouth"));
{
foreach (V _k397 in ForInKeys(L_396)) {
V q_398 = default;
q_398 = _k397;
if (Truthy(Invoke(NewRegExp(RX0, "y$", ""), "test", q_398))) {
OpSetK(L_396, q_398, 0, ((V)(3D)));
}
}
}
Invoke(t_393, "to", ((V)(320D)), Call(o_17, V.Undef, L_396, NewObj(1).Put("ly", ((V)(0.5))).V), ((V)("io")));
{
double i_399 = 0;
i_399 = 0D;
while (true) {
if (!(Lt(((V)(i_399)), Get(f_395, "n")))) break;
Invoke(Invoke(Invoke(t_393, "to", ((V)(170D)), NewObj(6).Put("tongue", ((V)(1D))).Put("pitch", ((V)(0.25))).Put("sq", ((V)((-0.04)))).Put("open", ((V)(0.12))).Put("hap", ((V)(0.5))).Put("turn", ((V)((Truthy(Get(f_395, "swirl")) ? (NumTruthy((i_399 % 2D)) ? 0.25 : (-0.25)) : 0D)))).V, ((V)("io"))), "e", ((V)("lick"))), "to", ((V)(230D)), NewObj(4).Put("tongue", ((V)(0.15))).Put("pitch", ((V)((-0.05)))).Put("sq", ((V)(0.01))).Put("open", ((V)(0D))).V, ((V)("io")));
i_399++;
}
}
Invoke(t_393, "to", ((V)(200D)), NewObj(4).Put("tongue", ((V)(0D))).Put("turn", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(0.8))).V, ((V)("io")));
if (Truthy(Get(f_395, "then"))) {
Call(bite_23, V.Undef, t_393, H_394, (true ? V.True : V.False));
Call(chew_21, V.Undef, t_393, ((V)(3D)));
Call(gulp_22, V.Undef, t_393);
} else {
Invoke(Invoke(t_393, "e", ((V)("done"))), "to", ((V)(300D)), Call(o_17, V.Undef, Get(H_394, "chest")), ((V)("io")));
}
return default;
}, 3, "lick", false)).Put("whole", Fn((V _self401, int _argc402, V t_408, V H_409, V _a406, V _a407, V[] _rest403) => {
if (_self401.IsNullish) _self401 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_408, "to", ((V)(320D)), Call(o_17, V.Undef, Get(H_409, "mouth"), NewObj(4).Put("open", ((V)(1D))).Put("mw", ((V)(1.1))).Put("pitch", ((V)(0.1))).Put("wide", ((V)(0.3))).V), ((V)("io"))), "to", ((V)(110D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(1.1))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("done"))), "to", ((V)(300D)), Call(o_17, V.Undef, Get(H_409, "chest"), NewObj(3).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).V), ((V)("io")));
Call(chew_21, V.Undef, t_408, ((V)(5D)), (true ? V.True : V.False));
Call(gulp_22, V.Undef, t_408);
return default;
}, 2, "whole", false)).Put("slurp", Fn((V _self410, int _argc411, V t_417, V H_418, V f_419, V _a416, V[] _rest412) => {
if (_self410.IsNullish) _self410 = GlobalV;
{
double i_420 = 0;
i_420 = 0D;
while (true) {
if (!((i_420 < 3D))) break;
V a_422 = default;
Invoke(t_417, "to", ((V)(220D)), NewObj(4).Put("pitch", ((V)((-0.25)))).Put("ly", ((V)(0.6))).Put("mw", ((V)(0.5))).Put("open", ((V)(0.25))).V, ((V)("io")));
a_422 = Get(t_417, "t");
Invoke(t_417, "osc", ((V)(700D)), ((V)(5D)), NewObj(3).Put("sq", ((V)(0.04))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.42))).V, NewObj(3).Put("sq", ((V)((-0.01)))).Put("open", ((V)(0.28))).Put("mw", ((V)(0.5))).V, ((V)("s")));
Invoke(Get(f_419, "wins"), "push", Arr(a_422, Get(t_417, "t")));
Invoke(t_417, "to", ((V)(120D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0.6))).Put("pitch", ((V)(0.05))).V, ((V)("o")));
Call(chew_21, V.Undef, t_417, ((V)(2D)));
Call(gulp_22, V.Undef, t_417);
i_420++;
}
}
Invoke(t_417, "e", ((V)("done")));
return default;
}, 3, "slurp", false)).Put("sip", Fn((V _self423, int _argc424, V t_430, V H_431, V f_432, V _a429, V[] _rest425) => {
if (_self423.IsNullish) _self423 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_430, "to", ((V)(320D)), Call(o_17, V.Undef, (Get(f_432, "mp") is var _t433 && Truthy(_t433) ? _t433 : Get(H_431, "mouth")), NewObj(1).Put("pitch", ((V)((-0.05)))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(3).Put("mw", ((V)(0.42))).Put("open", ((V)(0.1))).Put("puff", ((V)((-0.4)))).V, ((V)("o"))), "em", ((V)(1800D)), ((V)(450D)), ((V)("bubble")), ((V)("mouth")), ((V)(1D))), "osc", ((V)(1800D)), ((V)(6D)), NewObj(2).Put("puff", ((V)((-0.5)))).Put("sq", ((V)(0.03))).V, NewObj(2).Put("puff", ((V)((-0.3)))).Put("sq", ((V)(0D))).V, ((V)("s"))), "to", ((V)(140D)), NewObj(3).Put("puff", ((V)((-0.6)))).Put("sq", ((V)(0.06))).Put("wide", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("crumple"))), "to", ((V)(260D)), Call(o_17, V.Undef, Get(H_431, "chest"), NewObj(5).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(300D))), "e", ((V)("done")));
return default;
}, 3, "sip", false)).Put("big", Fn((V _self434, int _argc435, V t_441, V H_442, V _a439, V _a440, V[] _rest436) => {
if (_self434.IsNullish) _self434 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_441, "to", ((V)(380D)), Call(o_17, V.Undef, Get(H_442, "mouth"), NewObj(6).Put("open", ((V)(1D))).Put("mw", ((V)(1.45))).Put("pitch", ((V)(0.15))).Put("htilt", ((V)((-6D)))).Put("wide", ((V)(0.5))).Put("sq", ((V)((-0.05)))).V), ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(110D)), NewObj(6).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.1))).Put("puff", ((V)(1.2))).Put("htilt", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(5D))), "to", ((V)(300D)), Call(o_17, V.Undef, Get(H_442, "chest"), NewObj(1).Put("sq", ((V)(0D))).V), ((V)("io")));
Call(chew_21, V.Undef, t_441, ((V)(6D)), (true ? V.True : V.False));
Call(gulp_22, V.Undef, t_441);
Call(bite_23, V.Undef, t_441, H_442, (true ? V.True : V.False));
Call(chew_21, V.Undef, t_441, ((V)(3D)));
Call(gulp_22, V.Undef, t_441);
return default;
}, 2, "big", false)).Put("gobble", Fn((V _self443, int _argc444, V t_450, V H_451, V f_452, V _a449, V[] _rest445) => {
if (_self443.IsNullish) _self443 = GlobalV;
{
double i_453 = 0;
i_453 = 0D;
while (true) {
if (!(Lt(((V)(i_453)), Get(f_452, "n")))) break;
Invoke(Invoke(Invoke(Invoke(t_450, "to", ((V)(160D)), Call(o_17, V.Undef, Get(H_451, "mouth"), NewObj(2).Put("open", ((V)(0.85))).Put("pitch", ((V)((-0.1)))).V), ((V)("io"))), "to", ((V)(70D)), NewObj(3).Put("open", ((V)(0D))).Put("sq", ((V)(0.06))).Put("puff", ((V)(0.7))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(2D)));
if ((i_453 == (ToNum(Get(f_452, "n")) - 1D))) {
Invoke(t_450, "e", ((V)("done")));
}
Invoke(t_450, "to", ((V)(160D)), Call(o_17, V.Undef, Get(H_451, "chest"), NewObj(1).Put("sq", ((V)(0D))).V), ((V)("io")));
Call(chew_21, V.Undef, t_450, ((V)(1D)));
i_453++;
}
}
Call(gulp_22, V.Undef, t_450);
return default;
}, 3, "gobble", false)).V;
REACT_25 = NewObj(5).Put("yum", Fn((V _self455, int _argc456, V t_462, V _a459, V _a460, V _a461, V[] _rest457) => {
V a_463 = default;
V b_464 = default;
if (_self455.IsNullish) _self455 = GlobalV;
Invoke(t_462, "to", ((V)(320D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(10D)), ((V)(1D))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(5).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("sq", ((V)(0.03))).Put("pitch", ((V)(0.1))).V), ((V)("io")));
a_463 = Get(t_462, "t");
Invoke(t_462, "osc", ((V)(1200D)), ((V)(3D)), NewObj(4).Put("hLx", ((V)(13D))).Put("hLy", ((V)(3D))).Put("htilt", ((V)(4D))).Put("lean", ((V)(1D))).V, NewObj(4).Put("hLx", ((V)(8D))).Put("hLy", ((V)((-1D)))).Put("htilt", ((V)((-4D)))).Put("lean", ((V)((-1D)))).V, ((V)("s")));
b_464 = Get(t_462, "t");
Invoke(Invoke(Invoke(t_462, "at", a_463), "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(16D))).V, NewObj(1).Put("wag", ((V)((-16D)))).V, ((V)("s"))), "at", b_464);
Invoke(Invoke(Invoke(Invoke(t_462, "to", ((V)(200D)), NewObj(5).Put("sq", ((V)(0.12))).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(4).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(7D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.18))).V, ((V)("i"))), "to", ((V)(220D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", false)).Put("love", Fn((V _self465, int _argc466, V t_472, V _a469, V _a470, V _a471, V[] _rest467) => {
if (_self465.IsNullish) _self465 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_472, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(2D)), ((V)((-18D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-18D)))), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(0.8))).Put("blush", ((V)(1D))).Put("sq", ((V)(0.03))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(3).Put("htilt", ((V)(6D))).Put("lean", ((V)(1.4))).Put("x", ((V)(1D))).V, NewObj(3).Put("htilt", ((V)((-6D)))).Put("lean", ((V)((-1.4)))).Put("x", ((V)((-1D)))).V, ((V)("s"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(3).Put("x", ((V)(0D))).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).V);
return default;
}, 1, "love", false)).Put("spicy", Fn((V _self473, int _argc474, V t_480, V _a477, V _a478, V _a479, V[] _rest475) => {
V a_481 = default;
V b_482 = default;
if (_self473.IsNullish) _self473 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_480, "to", ((V)(150D)), NewObj(3).Put("wide", ((V)(1D))).Put("open", ((V)(0.2))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "wait", ((V)(350D))), "to", ((V)(500D)), NewObj(4).Put("red", ((V)(1D))).Put("wide", ((V)(0.6))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("earL")), ((V)(3D))), "e", ((V)("emit")), ((V)("steam")), ((V)("earR")), ((V)(3D))), "to", ((V)(200D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-14D)))), NewObj(3).Put("tongue", ((V)(1D))).Put("open", ((V)(0.5))).Put("sqz", ((V)(0.8))).V), ((V)("io"))), "em", ((V)(1500D)), ((V)(200D)), ((V)("steam")), ((V)("head")), ((V)(1D)));
a_481 = Get(t_480, "t");
Invoke(t_480, "osc", ((V)(1500D)), ((V)(6D)), NewObj(2).Put("hRx", ((V)((-16D)))).Put("tongue", ((V)(1D))).V, NewObj(2).Put("hRx", ((V)((-8D)))).Put("tongue", ((V)(0.7))).V, ((V)("io")));
b_482 = Get(t_480, "t");
Invoke(Invoke(Invoke(t_480, "at", a_481), "osc", ((V)(1500D)), ((V)(3D)), NewObj(2).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).V, NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("io"))), "at", b_482);
Invoke(Invoke(Invoke(t_480, "to", ((V)(400D)), NewObj(10).Put("red", ((V)(0.4))).Put("tongue", ((V)(0D))).Put("sqz", ((V)(0D))).Put("open", ((V)(0D))).Put("wide", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("red", ((V)(0D))).Put("frown", ((V)(0.3))).V), "wait", ((V)(200D)));
return default;
}, 1, "spicy", false)).Put("sour", Fn((V _self483, int _argc484, V t_490, V _a487, V _a488, V _a489, V[] _rest485) => {
V a_491 = default;
V b_492 = default;
if (_self483.IsNullish) _self483 = GlobalV;
Invoke(t_490, "to", ((V)(130D)), NewObj(7).Put("sqz", ((V)(1D))).Put("mw", ((V)(0.4))).Put("open", ((V)(0.15))).Put("sq", ((V)(0.12))).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).Put("pitch", ((V)((-0.2)))).V, ((V)("o")));
a_491 = Get(t_490, "t");
Invoke(t_490, "wait", ((V)(1000D)));
b_492 = Get(t_490, "t");
Invoke(Invoke(Invoke(t_490, "at", a_491), "osc", ((V)(1000D)), ((V)(10D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("l"))), "at", b_492);
Invoke(Invoke(Invoke(t_490, "osc", ((V)(700D)), ((V)(3D)), NewObj(1).Put("turn", ((V)(0.35))).V, NewObj(1).Put("turn", ((V)((-0.35)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(11).Put("sqz", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("pitch", ((V)(0D))).Put("turn", ((V)(0D))).Put("x", ((V)(0D))).Put("smile", ((V)(0.6))).Put("hap", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(200D)));
return default;
}, 1, "sour", false)).Put("freeze", Fn((V _self493, int _argc494, V t_500, V _a497, V _a498, V _a499, V[] _rest495) => {
V a_501 = default;
V b_502 = default;
if (_self493.IsNullish) _self493 = GlobalV;
Invoke(Invoke(t_500, "to", ((V)(150D)), NewObj(3).Put("sqz", ((V)(1D))).Put("sq", ((V)(0.08))).Put("frown", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)((-1D))), ((V)((-22D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)((-1D))), ((V)((-22D)))), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).V), ((V)("io")));
a_501 = Get(t_500, "t");
Invoke(t_500, "wait", ((V)(1100D)));
b_502 = Get(t_500, "t");
Invoke(Invoke(Invoke(t_500, "at", a_501), "osc", ((V)(1100D)), ((V)(11D)), NewObj(1).Put("x", ((V)(0.7))).V, NewObj(1).Put("x", ((V)((-0.7)))).V, ((V)("l"))), "at", b_502);
Invoke(Invoke(t_500, "to", ((V)(400D)), NewObj(14).Put("sqz", ((V)(0D))).Put("frown", ((V)(0D))).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("sq", ((V)(0D))).Put("x", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(300D)));
return default;
}, 1, "freeze", false)).V;
foodProp_26 = Fn((V _self1, int _argc503, V f_509, V key_510, V _a507, V _a508, V[] _rest504) => {
return Fn((V _self1, int _argc511, V I_517, V t_518, V _a515, V _a516, V[] _rest512) => {
V c_519 = default;
V W_520 = default;
V x_521 = default;
V y_522 = default;
double nb_523 = 0;
V id_524 = default;
JsStrBuf m_525 = null;
V body_526 = default;
c_519 = Get(I_517, "ctr");
W_520 = Get(I_517, "W");
if (Truthy((Get(c_519, "done") is var _t527 && Truthy(_t527) ? _t527 : (!(Truthy(Get(W_520, "pawR"))) ? V.True : V.False)))) {
return ((V)(""));
}
x_521 = V.Undef;
y_522 = V.Undef;
if (SEqS(Get(f_509, "hold"), "two")) {
x_521 = ((V)((ToNum(Add(GetIdx(Get(W_520, "pawL"), 0D), GetIdx(Get(W_520, "pawR"), 0D))) / 2D)));
y_522 = ((V)(((ToNum(Add(GetIdx(Get(W_520, "pawL"), 1D), GetIdx(Get(W_520, "pawR"), 1D))) / 2D) - (5.5 * ToNum((!Get(I_517, "foodK").IsNullish ? Get(I_517, "foodK") : ((V)(1D))))))));
} else {
if (Truthy((Get(f_509, "grip") is var _t528 && !Truthy(_t528) ? _t528 : Get(I_517, "gripStick")))) {
V s_529 = default;
double a_530 = 0;
V gx_531 = default;
V gy_532 = default;
s_529 = (Get(f_509, "sc") is var _t533 && Truthy(_t533) ? _t533 : ((V)(1.15)));
a_530 = ((ToNum((GetIdx(Get(f_509, "grip"), 2D) is var _t534 && Truthy(_t534) ? _t534 : ((V)(0D)))) * System.Math.PI) / 180D);
gx_531 = GetIdx(Get(f_509, "grip"), 0D);
gy_532 = GetIdx(Get(f_509, "grip"), 1D);
x_521 = ((V)((ToNum(GetIdx(Get(W_520, "pawR"), 0D)) - (((ToNum(gx_531) * FdLibm.Cos(a_530)) - (ToNum(gy_532) * FdLibm.Sin(a_530))) * ToNum(s_529)))));
y_522 = ((V)((ToNum(GetIdx(Get(W_520, "pawR"), 1D)) - (((ToNum(gx_531) * FdLibm.Sin(a_530)) + (ToNum(gy_532) * FdLibm.Cos(a_530))) * ToNum(s_529)))));
} else {
x_521 = ((V)((ToNum(GetIdx(Get(W_520, "pawR"), 0D)) - 2.5)));
y_522 = ((V)((ToNum(GetIdx(Get(W_520, "pawR"), 1D)) - (6D * ToNum((!Get(I_517, "foodK1").IsNullish ? Get(I_517, "foodK1") : (!Get(I_517, "foodK").IsNullish ? Get(I_517, "foodK") : ((V)(1D)))))))));
}
}
if (Truthy(((Get(I_517, "foodMid") is var _t535 && !Truthy(_t535) ? _t535 : Get(W_520, "pawL")) is var _t537 && !Truthy(_t537) ? _t537 : (!(Truthy((Get(f_509, "grip") is var _t536 && !Truthy(_t536) ? _t536 : Get(I_517, "gripStick")))) ? V.True : V.False)))) {
x_521 = ((V)((ToNum(Add(GetIdx(Get(W_520, "pawL"), 0D), GetIdx(Get(W_520, "pawR"), 0D))) / 2D)));
y_522 = ((V)((ToNum(Add(GetIdx(Get(W_520, "pawL"), 1D), GetIdx(Get(W_520, "pawR"), 1D))) / 2D)));
}
if (Truthy((Get(I_517, "foodDY") is var _t538 && !Truthy(_t538) ? _t538 : GetK(Get(I_517, "foodDY"), key_510)))) {
y_522 = Add(y_522, GetK(Get(I_517, "foodDY"), key_510));
}
nb_523 = Min(ToNum((Get(c_519, "bite") is var _t539 && Truthy(_t539) ? _t539 : ((V)(0D)))), ToNum((Truthy(Get(f_509, "bm")) ? Get(Get(f_509, "bm"), "length") : ((V)(0D)))));
id_524 = ((V)(JsStrBuf.Begin().S("bm").V(Get(I_517, "u")).V(key_510).End()));
m_525 = new JsStrBuf("");
if (NumTruthy(nb_523)) {
m_525.Set(JsStrBuf.Begin().S("<mask id=\"").V(id_524).S("\" maskUnits=\"userSpaceOnUse\" x=\"-30\" y=\"-30\" width=\"60\" height=\"60\"><rect x=\"-30\" y=\"-30\" width=\"60\" height=\"60\" fill=\"#fff\"/>").End());
{
double i_540 = 0;
i_540 = 0D;
while (true) {
if (!((i_540 < nb_523))) break;
V b_542 = default;
b_542 = GetIdx(Get(f_509, "bm"), i_540);
m_525.S("<circle cx=\"").V(GetIdx(b_542, 0D)).S("\" cy=\"").V(GetIdx(b_542, 1D)).S("\" r=\"").V(GetIdx(b_542, 2D)).S("\" fill=\"#000\"/>");
i_540++;
}
}
m_525.S("</mask>");
}
body_526 = (string.Equals(Typeof(Get(f_509, "svg")), "function") ? Invoke(f_509, "svg", I_517, t_518, c_519, x_521, y_522, f_509) : Get(f_509, "svg"));
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(r2_10, V.Undef, x_521)).S(" ").V(Call(r2_10, V.Undef, y_522)).S(") rotate(").V((Truthy((Get(f_509, "grip") is var _t545 && !Truthy(_t545) ? _t545 : Get(I_517, "gripStick"))) ? (GetIdx(Get(f_509, "grip"), 2D) is var _t543 && Truthy(_t543) ? _t543 : ((V)(0D))) : (Get(f_509, "rot") is var _t544 && Truthy(_t544) ? _t544 : ((V)(0D))))).S(") scale(").V(Call(r2_10, V.Undef, ((V)((ToNum(Call(SM_11, V.Undef, ((V)((ToNum(t_518) / 220D))))) * ToNum((Get(f_509, "sc") is var _t546 && Truthy(_t546) ? _t546 : ((V)(1.15))))))))).S(")\">").S(m_525.Str).S("<g").S((NumTruthy(nb_523) ? JsStrBuf.Begin().S(" mask=\"url(#").V(id_524).S(")\"").End() : "")).S(">").V(body_526).S("</g></g>").End()));
return default;
}, 2, "", true);
}, 2, "", true);
top_27 = Fn((V _self1, int _argc547, V n_553, V y_554, V w_555, V r_556, V[] _rest548) => {
return Array_from(NewObj(1).Put("length", n_553).V, Fn((V _self1, int _argc557, V __563, V i_564, V _a561, V _a562, V[] _rest558) => {
return Arr(Call(r2_10, V.Undef, ((V)(((ToNum(w_555) / 2D) - ((ToNum(i_564) * ToNum(w_555)) / ToNum((((V)((ToNum(n_553) - 1D))) is var _t565 && Truthy(_t565) ? _t565 : ((V)(1D))))))))), y_554, r_556);
}, 2, "", true));
}, 4, "", true);
FOODS_28 = NewObj(20).Put("apple", NewObj(8).Put("label", ((V)("Apple"))).Put("d", ((V)("Two paws, three crunchy bites."))).Put("hold", ((V)("two"))).Put("style", ((V)("chomp"))).Put("n", ((V)(3D))).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)(1.5)), ((V)((-5D))), ((V)(2.4))), Arr(((V)((-2.4))), ((V)((-4.4))), ((V)(2.4))), Arr(((V)(3.6)), ((V)((-1.2))), ((V)(2.6))))).Put("svg", ((V)("<circle cx=\"0\" cy=\"0.5\" r=\"5.2\" fill=\"#ff5a5f\"/><path d=\"M-2.2 -3.6 Q0 -2.2 2.2 -3.6\" fill=\"none\" stroke=\"#d93a45\" stroke-width=\"0.8\"/><path d=\"M0 -4 L0.6 -6.4\" stroke=\"#7a4a2a\" stroke-width=\"0.9\" stroke-linecap=\"round\"/><path d=\"M0.6 -5.6 Q3 -7.4 4 -5 Q2 -4.4 0.6 -5.6Z\" fill=\"#6fcf5a\"/><ellipse cx=\"-2\" cy=\"-1.4\" rx=\"1.4\" ry=\"0.9\" fill=\"#ffffff\" opacity=\"0.5\"/>"))).V).Put("banana", NewObj(9).Put("label", ((V)("Banana"))).Put("d", ((V)("One paw, bites from the tip."))).Put("hold", ((V)("R"))).Put("style", ((V)("chomp"))).Put("n", ((V)(3D))).Put("react", ((V)("yum"))).Put("rot", ((V)((-10D)))).Put("bm", Arr(Arr(((V)((-1.6))), ((V)((-6.4))), ((V)(2D))), Arr(((V)((-3D))), ((V)((-3.8))), ((V)(2.2))), Arr(((V)((-4D))), ((V)((-0.8))), ((V)(2.4))))).Put("svg", ((V)("<path d=\"M-5 3 Q-6 -3 -2 -6 Q-1 -6.5 -0.6 -5.6 Q-3.6 -2 -2 3 Q0 6 5 5.6 Q5.6 6.4 4.6 7 Q-2 8 -5 3Z\" fill=\"#ffd84a\" stroke=\"#e0b52a\" stroke-width=\"0.5\"/><path d=\"M-2 -6 L-1.2 -7.4\" stroke=\"#7a5a2a\" stroke-width=\"1\" stroke-linecap=\"round\"/>"))).V).Put("carrot", NewObj(8).Put("label", ((V)("Carrot"))).Put("d", ((V)("Fast rabbit nibbles down the carrot."))).Put("hold", ((V)("two"))).Put("style", ((V)("nibble"))).Put("n", ((V)(8D))).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-7D))), ((V)(1.6))), Arr(((V)(0D)), ((V)((-5.4))), ((V)(1.8))), Arr(((V)(0D)), ((V)((-3.6))), ((V)(2D))), Arr(((V)(0D)), ((V)((-1.8))), ((V)(2.1))), Arr(((V)(0D)), ((V)(0D)), ((V)(2.3))), Arr(((V)(0D)), ((V)(1.8)), ((V)(2.4))), Arr(((V)(0D)), ((V)(3.4)), ((V)(2.6))), Arr(((V)(0D)), ((V)(5D)), ((V)(3D))))).Put("svg", ((V)("<path d=\"M-2.6 4 Q0 5 2.6 4 L0.4 -7 Q0 -7.8 -0.4 -7 Z\" fill=\"#ff9a3a\"/><path d=\"M-1.6 0.5 L0.4 0.2 M-1 -2.5 L0.8 -2.8\" stroke=\"#e07a1a\" stroke-width=\"0.5\"/><path d=\"M0 4.4 Q-2.4 8 -1.2 9 Q0 7 0 4.4 Q1 8.6 2.6 8.2 Q1.4 6 0 4.4Z\" fill=\"#6fcf5a\"/>"))).V).Put("cookie", NewObj(8).Put("label", ((V)("Cookie"))).Put("d", ((V)("Crumbly bites, crumbs everywhere, love."))).Put("hold", ((V)("R"))).Put("style", ((V)("chomp"))).Put("n", ((V)(3D))).Put("react", ((V)("love"))).Put("bm", Arr(Arr(((V)(1.5)), ((V)((-4.6))), ((V)(2.3))), Arr(((V)((-2D))), ((V)((-4.2))), ((V)(2.3))), Arr(((V)(3.8)), ((V)((-1.6))), ((V)(2.4))))).Put("svg", ((V)("<circle r=\"5\" fill=\"#e0a75e\"/><circle r=\"5\" fill=\"none\" stroke=\"#c48a45\" stroke-width=\"0.6\"/><circle cx=\"-2\" cy=\"-1.5\" r=\"0.8\" fill=\"#5a3420\"/><circle cx=\"1.8\" cy=\"0.6\" r=\"0.9\" fill=\"#5a3420\"/><circle cx=\"-0.6\" cy=\"2.4\" r=\"0.7\" fill=\"#5a3420\"/><circle cx=\"2.2\" cy=\"-2.6\" r=\"0.6\" fill=\"#5a3420\"/>"))).V).Put("donut", NewObj(9).Put("label", ((V)("Donut"))).Put("d", ((V)("Peeks through the hole first, then bites."))).Put("hold", ((V)("two"))).Put("style", ((V)("chomp"))).Put("n", ((V)(3D))).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)(1.6)), ((V)((-5D))), ((V)(2.4))), Arr(((V)((-2.6))), ((V)((-4.4))), ((V)(2.4))), Arr(((V)(4.2)), ((V)((-1.4))), ((V)(2.4))))).Put("pre", Fn((V _self566, int _argc567, V t_573, V _a570, V _a571, V _a572, V[] _rest568) => {
if (_self566.IsNullish) _self566 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_573, "to", ((V)(420D)), NewObj(9).Put("hLx", ((V)(23D))).Put("hLy", ((V)((-24D)))).Put("hRx", ((V)((-2D)))).Put("hRy", ((V)((-24D)))).Put("lx", ((V)(0.6))).Put("ly", ((V)((-0.1)))).Put("winkL", ((V)(1D))).Put("pitch", ((V)(0.05))).Put("wide", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(240D)), NewObj(2).Put("hLx", ((V)(18D))).Put("hRx", ((V)((-7D)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("hLx", ((V)(23D))).Put("hRx", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(400D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(7D)), ((V)((-6D)))), NewObj(4).Put("winkL", ((V)(0D))).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).V), ((V)("io")));
return default;
}, 1, "pre", false)).Put("svg", ((V)("<path fill-rule=\"evenodd\" d=\"M5.4 0 A5.4 5.4 0 1 0 -5.4 0 A5.4 5.4 0 1 0 5.4 0Z M1.7 0 A1.7 1.7 0 1 1 -1.7 0 A1.7 1.7 0 1 1 1.7 0Z\" fill=\"#e8b06a\"/><path fill-rule=\"evenodd\" d=\"M4.7 -0.4 Q4.4 -4.6 0 -4.7 Q-4.4 -4.6 -4.7 -0.4 Q-4.2 2.6 -2.6 2 Q-1 3.4 0 2.2 Q1.6 3.6 2.8 2.2 Q4.4 2.6 4.7 -0.4Z M2.3 0 A2.3 2.3 0 1 1 -2.3 0 A2.3 2.3 0 1 1 2.3 0Z\" fill=\"#ff8fc8\"/><path d=\"M-3 -2.6 l0.8 -0.6 M1.6 -3.4 l0.9 0.3 M3.4 -1 l0.2 0.9 M-3.6 0.6 l0.6 0.6 M-0.6 -3.6 l-0.3 0.8\" stroke=\"#ffffff\" stroke-width=\"0.6\" stroke-linecap=\"round\"/>"))).V).Put("pizza", NewObj(9).Put("label", ((V)("Pizza slice"))).Put("d", ((V)("Holds it up high, looks up, then bites."))).Put("hold", ((V)("R"))).Put("style", ((V)("chomp"))).Put("n", ((V)(2D))).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-6.4))), ((V)(2.6))), Arr(((V)(0D)), ((V)((-3.4))), ((V)(3D))))).Put("pre", Fn((V _self574, int _argc575, V t_581, V _a578, V _a579, V _a580, V[] _rest576) => {
if (_self574.IsNullish) _self574 = GlobalV;
Invoke(Invoke(Invoke(t_581, "to", ((V)(450D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-30D)))), NewObj(4).Put("pitch", ((V)(0.5))).Put("ly", ((V)((-0.9)))).Put("open", ((V)(0.6))).Put("armR", ((V)(30D))).V), ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(380D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-8D)))), NewObj(4).Put("pitch", ((V)(0D))).Put("ly", ((V)(0.3))).Put("open", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
return default;
}, 1, "pre", false)).Put("svg", ((V)("<path d=\"M-4.5 4 L4.5 4 L0 -7 Z\" fill=\"#ffd25a\"/><path d=\"M-5 4 Q0 6.2 5 4 L4.6 5.6 Q0 7.6 -4.6 5.6Z\" fill=\"#d9903a\"/><circle cx=\"-1.2\" cy=\"1.4\" r=\"1.1\" fill=\"#e2483a\"/><circle cx=\"1.4\" cy=\"-1.4\" r=\"0.9\" fill=\"#e2483a\"/><circle cx=\"1.6\" cy=\"2.4\" r=\"0.8\" fill=\"#e2483a\"/>"))).V).Put("icecream", NewObj(9).Put("label", ((V)("Ice cream"))).Put("d", ((V)("Four long licks, then a bite of cone."))).Put("hold", ((V)("R"))).Put("style", ((V)("lick"))).Put("n", ((V)(4D))).Put("then", (true ? V.True : V.False)).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-6D))), ((V)(3.4))), Arr(((V)(0D)), ((V)((-2.4))), ((V)(3.8))))).Put("svg", Fn((V _self1, int _argc582, V I_588, V t_589, V c_590, V _a587, V[] _rest583) => {
double k_591 = 0;
k_591 = (1D - (0.07 * Min(4D, ToNum((Get(c_590, "lick") is var _t592 && Truthy(_t592) ? _t592 : ((V)(0D)))))));
return ((V)(JsStrBuf.Begin().S("<path d=\"M-3.4 0 L3.4 0 L0 9 Z\" fill=\"#e8b06a\"/><path d=\"M-2.4 1.6 L1.6 5.6 M2.4 1.6 L-1.6 5.6\" stroke=\"#c48a45\" stroke-width=\"0.5\"/><circle cx=\"0\" cy=\"-1.6\" r=\"3.8\" fill=\"#ffc0de\"/><circle cx=\"0\" cy=\"").V(Call(r2_10, V.Undef, ((V)(((-5.2) * k_591))))).S("\" r=\"").V(Call(r2_10, V.Undef, ((V)((3D * k_591))))).S("\" fill=\"#fff4c2\"/>").End()));
return default;
}, 3, "svg", true)).V).Put("burger", NewObj(7).Put("label", ((V)("Burger"))).Put("d", ((V)("Opens super wide for one huge chomp."))).Put("hold", ((V)("two"))).Put("style", ((V)("big"))).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-6D))), ((V)(3.6))), Arr(((V)(3.6)), ((V)((-4.6))), ((V)(3.6))))).Put("svg", ((V)("<path d=\"M-6 3.6 L6 3.6 Q6 6.4 3 6.4 L-3 6.4 Q-6 6.4 -6 3.6Z\" fill=\"#e8963a\"/><rect x=\"-6.2\" y=\"1.2\" width=\"12.4\" height=\"2.6\" rx=\"1.3\" fill=\"#7a3a24\"/><path d=\"M-5.6 0.6 L5.6 0.6 L4 2.6 L2.4 1.4 L-5.6 1.6Z\" fill=\"#ffd23a\"/><path d=\"M-6.4 -0.6 Q-4.8 1 -3.2 -0.4 Q-1.6 1 0 -0.4 Q1.6 1 3.2 -0.4 Q4.8 1 6.4 -0.6 L6.4 0.8 L-6.4 0.8Z\" fill=\"#7ad36a\"/><path d=\"M-6 -0.6 Q-6 -6.5 0 -6.5 Q6 -6.5 6 -0.6Z\" fill=\"#f0a64a\"/><path d=\"M-2.4 -4.2 l0.8 -0.3 M1 -5 l0.8 0.2 M3 -3.4 l0.6 -0.5 M-4 -2.6 l0.5 -0.6\" stroke=\"#fff4d6\" stroke-width=\"0.6\" stroke-linecap=\"round\"/>"))).V).Put("sushi", NewObj(6).Put("label", ((V)("Sushi"))).Put("d", ((V)("Pops it in whole, cheeks puffed, love."))).Put("hold", ((V)("two"))).Put("style", ((V)("whole"))).Put("react", ((V)("love"))).Put("svg", ((V)("<rect x=\"-4.5\" y=\"-1.5\" width=\"9\" height=\"4.5\" rx=\"2.2\" fill=\"#ffffff\" stroke=\"#e8e0d8\" stroke-width=\"0.4\"/><path d=\"M-4.8 -1 Q-5 -4 0 -4 Q5 -4 4.8 -1 Q0 0 -4.8 -1Z\" fill=\"#ff8a65\"/><path d=\"M-2.5 -3.6 L-1.5 -1 M0.5 -3.9 L1.3 -1.1 M3 -3.4 L3.4 -1.2\" stroke=\"#ffd1bf\" stroke-width=\"0.6\"/><rect x=\"-1.2\" y=\"-4\" width=\"2.4\" height=\"7\" fill=\"#2f4a3a\"/>"))).V).Put("watermelon", NewObj(9).Put("label", ((V)("Watermelon"))).Put("d", ((V)("Typewriter bites across, spits a seed."))).Put("hold", ((V)("two"))).Put("style", ((V)("typewriter"))).Put("n", ((V)(5D))).Put("seed", (true ? V.True : V.False)).Put("react", ((V)("yum"))).Put("bm", Invoke(Call(top_27, V.Undef, ((V)(5D)), ((V)((-0.2))), ((V)(10D)), ((V)(2D))), "concat", Call(top_27, V.Undef, ((V)(5D)), ((V)(1.8)), ((V)(9D)), ((V)(2.2))))).Put("svg", ((V)("<path d=\"M-7 0 A7 7 0 0 0 7 0 Z\" fill=\"#7ad36a\"/><path d=\"M-6 0 A6 6 0 0 0 6 0 Z\" fill=\"#ff5a6a\"/><ellipse cx=\"-2.6\" cy=\"2\" rx=\"0.4\" ry=\"0.7\" fill=\"#2a1a30\"/><ellipse cx=\"0\" cy=\"3.4\" rx=\"0.4\" ry=\"0.7\" fill=\"#2a1a30\"/><ellipse cx=\"2.6\" cy=\"2\" rx=\"0.4\" ry=\"0.7\" fill=\"#2a1a30\"/>"))).V).Put("strawberry", NewObj(7).Put("label", ((V)("Strawberry"))).Put("d", ((V)("One bite, blushes, hearts."))).Put("hold", ((V)("R"))).Put("style", ((V)("whole"))).Put("react", ((V)("love"))).Put("sc", ((V)(0.8))).Put("svg", ((V)("<path d=\"M0 6 Q-5.6 2 -4.6 -2.4 Q-3.6 -4.4 0 -3.6 Q3.6 -4.4 4.6 -2.4 Q5.6 2 0 6Z\" fill=\"#ff4b5c\"/><path d=\"M-3 -3.4 L-1 -5.6 L0 -3.8 L1 -5.6 L3 -3.4 Q0 -2.6 -3 -3.4Z\" fill=\"#5fc24a\"/><circle cx=\"-2\" cy=\"-0.6\" r=\"0.35\" fill=\"#ffe08a\"/><circle cx=\"1.4\" cy=\"0.4\" r=\"0.35\" fill=\"#ffe08a\"/><circle cx=\"-0.4\" cy=\"2.6\" r=\"0.35\" fill=\"#ffe08a\"/><circle cx=\"2.4\" cy=\"-1.8\" r=\"0.35\" fill=\"#ffe08a\"/>"))).V).Put("cupcake", NewObj(9).Put("label", ((V)("Cupcake"))).Put("d", ((V)("Licks the frosting, then bites."))).Put("hold", ((V)("two"))).Put("style", ((V)("lick"))).Put("n", ((V)(2D))).Put("then", (true ? V.True : V.False)).Put("react", ((V)("love"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-5.6))), ((V)(3.4))), Arr(((V)(2.4)), ((V)((-2.6))), ((V)(3.4))))).Put("svg", ((V)("<path d=\"M-4.6 0 L4.6 0 L3.4 6 L-3.4 6Z\" fill=\"#7cc8ff\"/><path d=\"M-2.4 0.4 L-1.8 5.6 M0 0.4 L0 5.6 M2.4 0.4 L1.8 5.6\" stroke=\"#5aa8e8\" stroke-width=\"0.5\"/><path d=\"M-5 0.4 Q-6 -2.6 -3 -3 Q-2.6 -6 0 -5.6 Q2.6 -6 3 -3 Q6 -2.6 5 0.4Z\" fill=\"#ffc0de\"/><circle cx=\"0\" cy=\"-6.4\" r=\"1.4\" fill=\"#ff3b4b\"/>"))).V).Put("noodles", NewObj(7).Put("label", ((V)("Noodles"))).Put("d", ((V)("Slurps long noodles from the bowl."))).Put("hold", ((V)("two"))).Put("style", ((V)("slurp"))).Put("react", ((V)("yum"))).Put("wins", Arr()).Put("svg", Fn((V _self1, int _argc593, V I_599, V t_600, V c_601, V x_602, V[] _rest594) => {
JsStrBuf h_605 = null;
V w_606 = default;
V y_603 = default;
V F_604 = default;
y_603 = (_argc593 > 4 ? _rest594[0] : V.Undef);
F_604 = (_argc593 > 5 ? _rest594[1] : V.Undef);
h_605 = new JsStrBuf("<path d=\"M-7 -1 L7 -1 Q6.4 6 0 6.4 Q-6.4 6 -7 -1Z\" fill=\"#ff8fa3\"/><path d=\"M-6 3 L6 3\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.7\"/><path d=\"M-6 -1.2 Q-3 -3 0 -1.4 Q3 -3 6 -1.2\" stroke=\"#ffe08a\" stroke-width=\"1.2\" fill=\"none\"/>");
w_606 = Invoke(((F_604 is var _t614 && !Truthy(_t614) ? _t614 : Get(F_604, "wins")) is var _t615 && Truthy(_t615) ? _t615 : Get(Get(FOODS_28, "noodles"), "wins")), "find", Fn((V _self1, int _argc607, V q_613, V _a610, V _a611, V _a612, V[] _rest608) => {
return ((Ge(t_600, GetIdx(q_613, 0D)) && Le(t_600, GetIdx(q_613, 1D))) ? V.True : V.False);
}, 1, "", true));
if (Truthy((w_606 is var _t616 && !Truthy(_t616) ? _t616 : Get(Get(I_599, "W"), "mouth")))) {
double u_617 = 0;
double mx_618 = 0;
double my_619 = 0;
double by_620 = 0;
u_617 = ((ToNum(t_600) - ToNum(GetIdx(w_606, 0D))) / (ToNum(GetIdx(w_606, 1D)) - ToNum(GetIdx(w_606, 0D))));
mx_618 = (ToNum(GetIdx(Get(Get(I_599, "W"), "mouth"), 0D)) - ToNum(x_602));
my_619 = ((ToNum(GetIdx(Get(Get(I_599, "W"), "mouth"), 1D)) - ToNum(y_603)) + 0.5);
by_620 = ((-1.5) + (((my_619 + 1.5) * u_617) * 0.92));
h_605.S("<path d=\"M0 ").V(Call(r2_10, V.Undef, ((V)(by_620)))).S(" Q").V(Call(r2_10, V.Undef, ((V)(((mx_618 * 0.5) + (FdLibm.Sin((ToNum(t_600) / 60D)) * 1.4)))))).S(" ").V(Call(r2_10, V.Undef, ((V)(((by_620 + my_619) / 2D))))).S(" ").V(Call(r2_10, V.Undef, ((V)(mx_618)))).S(" ").V(Call(r2_10, V.Undef, ((V)(my_619)))).S("\" stroke=\"#ffe08a\" stroke-width=\"1.1\" fill=\"none\" stroke-linecap=\"round\"/>");
}
return ((V)(h_605.Str));
return default;
}, 6, "svg", true)).V).Put("corn", NewObj(8).Put("label", ((V)("Corn on the cob"))).Put("d", ((V)("Typewriter-style rows, ding at each end."))).Put("hold", ((V)("two"))).Put("style", ((V)("typewriter"))).Put("n", ((V)(6D))).Put("react", ((V)("yum"))).Put("bm", Invoke(Call(top_27, V.Undef, ((V)(6D)), ((V)((-2.6))), ((V)(11D)), ((V)(1.6))), "concat", Call(top_27, V.Undef, ((V)(6D)), ((V)((-0.6))), ((V)(11D)), ((V)(1.8))))).Put("svg", ((V)("<path d=\"M-7 0 L-9.6 -2.6 L-9 2.6Z M7 0 L9.6 -2.6 L9 2.6Z\" fill=\"#9be38a\"/><rect x=\"-7\" y=\"-2.8\" width=\"14\" height=\"5.6\" rx=\"2.8\" fill=\"#ffd84a\"/><path d=\"M-5 -2.6 L-5 2.6 M-2.5 -2.8 L-2.5 2.8 M0 -2.8 L0 2.8 M2.5 -2.8 L2.5 2.8 M5 -2.6 L5 2.6 M-7 0 L7 0\" stroke=\"#f0b52a\" stroke-width=\"0.4\"/>"))).V).Put("lollipop", NewObj(9).Put("label", ((V)("Lollipop"))).Put("d", ((V)("Five swirly licks."))).Put("hold", ((V)("R"))).Put("style", ((V)("lick"))).Put("n", ((V)(5D))).Put("swirl", (true ? V.True : V.False)).Put("react", ((V)("love"))).Put("grip", Arr(((V)(0D)), ((V)(10.5)), ((V)((-30D))))).Put("svg", Fn((V _self1, int _argc621, V I_627, V t_628, V c_629, V _a626, V[] _rest622) => {
double k_630 = 0;
k_630 = (1D - (0.06 * Min(5D, ToNum((Get(c_629, "lick") is var _t631 && Truthy(_t631) ? _t631 : ((V)(0D)))))));
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 3 L0 ").N((Truthy(Get(I_627, "gripStick")) ? 14D : 10D)).S("\" stroke=\"#ffffff\" stroke-width=\"1.2\" stroke-linecap=\"round\"/><g transform=\"scale(").V(Call(r2_10, V.Undef, ((V)(k_630)))).S(")\"><circle cx=\"0\" cy=\"-1\" r=\"4.6\" fill=\"#ff7fc8\"/><path d=\"M0 -1 m-3 0 a3 3 0 1 1 3 3 a2 2 0 1 1 -2 -2 a1 1 0 1 1 1 1\" stroke=\"#fff\" stroke-width=\"0.9\" fill=\"none\"/></g>").End()));
return default;
}, 3, "svg", true)).V).Put("fish", NewObj(9).Put("label", ((V)("Fish"))).Put("d", ((V)("Jumps with excitement, then gobbles it up."))).Put("hold", ((V)("two"))).Put("style", ((V)("gobble"))).Put("n", ((V)(4D))).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)((-5D))), ((V)(0D)), ((V)(2.6))), Arr(((V)((-2.4))), ((V)((-0.4))), ((V)(2.8))), Arr(((V)(0.6)), ((V)(0D)), ((V)(2.8))), Arr(((V)(3.6)), ((V)(0D)), ((V)(3D))))).Put("pre", Fn((V _self632, int _argc633, V t_639, V _a636, V _a637, V _a638, V[] _rest634) => {
if (_self632.IsNullish) _self632 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_639, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.18))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(6).Put("sq", ((V)((-0.15)))).Put("lift", ((V)(9D))).Put("wide", ((V)(1D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("open", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.2))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(5).Put("sq", ((V)(0D))).Put("wide", ((V)(0.3))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "pre", false)).Put("svg", ((V)("<path d=\"M-6 0 Q-2 -4.6 3.6 -0.4 L7 -3.4 L6.4 0 L7 3.4 L3.6 0.4 Q-2 4.6 -6 0Z\" fill=\"#7cc8ff\"/><path d=\"M-1 -2 Q0 0 -1 2\" stroke=\"#5aa8e8\" stroke-width=\"0.6\" fill=\"none\"/><circle cx=\"-3.6\" cy=\"-0.8\" r=\"0.8\" fill=\"#2a1a30\"/>"))).V).Put("pepper", NewObj(10).Put("label", ((V)("Hot pepper"))).Put("d", ((V)("One bite, turns red, steam, fans her tongue."))).Put("hold", ((V)("R"))).Put("style", ((V)("chomp"))).Put("n", ((V)(1D))).Put("chew", ((V)(2D))).Put("react", ((V)("spicy"))).Put("rot", ((V)(20D))).Put("bm", Arr(Arr(((V)(0.5)), ((V)((-3.4))), ((V)(2.4))))).Put("svg", ((V)("<path d=\"M-1 -4 Q4 -3 3 3 Q2 7 -2 8 Q1 4 0 0 Q-0.6 -2.6 -1 -4Z\" fill=\"#ff3b30\"/><path d=\"M-1 -4 Q-2 -6 0 -7\" stroke=\"#4caf50\" stroke-width=\"1.2\" fill=\"none\" stroke-linecap=\"round\"/>"))).V).Put("lemon", NewObj(9).Put("label", ((V)("Lemon"))).Put("d", ((V)("One bite, huge sour pucker, shivers."))).Put("hold", ((V)("R"))).Put("style", ((V)("chomp"))).Put("n", ((V)(1D))).Put("chew", ((V)(1D))).Put("react", ((V)("sour"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-3.6))), ((V)(2.6))))).Put("svg", ((V)("<path d=\"M-5.4 0 Q-5.4 -4 0 -4 Q5.4 -4 5.4 0 Q5.4 4 0 4 Q-5.4 4 -5.4 0Z M5.2 -0.7 L6.8 0 L5.2 0.7Z M-5.2 -0.7 L-6.8 0 L-5.2 0.7Z\" fill=\"#ffe14a\"/><ellipse cx=\"-1.8\" cy=\"-1.6\" rx=\"1.4\" ry=\"0.7\" fill=\"#ffffff\" opacity=\"0.5\"/>"))).V).Put("juice", NewObj(7).Put("label", ((V)("Juice box"))).Put("d", ((V)("Sips through the straw, squeezes the box."))).Put("hold", ((V)("R"))).Put("style", ((V)("sip"))).Put("react", ((V)("yum"))).Put("mp", Call(hand_15, V.Undef, ((V)(1D)), ((V)(17D)), ((V)((-3D))))).Put("svg", Fn((V _self1, int _argc640, V I_646, V t_647, V c_648, V _a645, V[] _rest641) => {
double k_649 = 0;
k_649 = (Truthy(Get(c_648, "crumple")) ? 0.75 : 1D);
return ((V)(JsStrBuf.Begin().S("<g transform=\"scale(").N(k_649).S(" 1)\"><rect x=\"-3.4\" y=\"-3\" width=\"6.8\" height=\"9\" rx=\"0.8\" fill=\"#9be38a\"/><rect x=\"-2.4\" y=\"0\" width=\"4.8\" height=\"3.6\" rx=\"0.6\" fill=\"#ffffff\"/><circle cx=\"0\" cy=\"1.8\" r=\"1.1\" fill=\"#ff9a3a\"/></g><path d=\"M1.4 -3 L2.4 -8.4\" stroke=\"#ff5cc6\" stroke-width=\"0.9\" stroke-linecap=\"round\"/>").End()));
return default;
}, 3, "svg", true)).V).Put("popsicle", NewObj(9).Put("label", ((V)("Popsicle"))).Put("d", ((V)("Licks, bites, brain freeze."))).Put("hold", ((V)("R"))).Put("style", ((V)("lick"))).Put("n", ((V)(3D))).Put("then", (true ? V.True : V.False)).Put("react", ((V)("freeze"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-6D))), ((V)(3.2))))).Put("svg", ((V)("<rect x=\"-0.8\" y=\"3.6\" width=\"1.6\" height=\"5\" rx=\"0.8\" fill=\"#f0c890\"/><rect x=\"-3.4\" y=\"-6\" width=\"6.8\" height=\"10\" rx=\"3.4\" fill=\"#7cc8ff\"/><rect x=\"-3.4\" y=\"-1\" width=\"6.8\" height=\"5\" rx=\"0\" fill=\"#ff8fc8\"/><rect x=\"-3.4\" y=\"-6\" width=\"6.8\" height=\"10\" rx=\"3.4\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.4\"/>"))).V).V;
meal_29 = Fn((V _self1, int _argc650, V key_656, V f_657, V _a654, V _a655, V[] _rest651) => {
V t_658 = default;
V H_659 = default;
t_658 = Call(TL_13, V.Undef);
H_659 = GetK(HOLD_20, Get(f_657, "hold"));
Invoke(Invoke(Invoke(Invoke(t_658, "e", ((V)("food"))), "to", ((V)(320D)), Call(o_17, V.Undef, Get(H_659, "chest"), NewObj(6).Put("wide", ((V)(0.5))).Put("ly", ((V)(0.6))).Put("pitch", ((V)((-0.25)))).Put("sq", ((V)(0.06))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V), ((V)("o"))), "to", ((V)(300D)), NewObj(6).Put("wide", ((V)(0D))).Put("smile", ((V)(0.7))).Put("hap", ((V)(0.6))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
if (Truthy(Get(f_657, "pre"))) {
Invoke(f_657, "pre", t_658, H_659);
}
InvokeK(STYLE_24, Get(f_657, "style"), t_658, H_659, f_657);
InvokeK(REACT_25, Get(f_657, "react"), t_658);
Invoke(t_658, "rest", ((V)(450D)));
return Invoke(t_658, "done", NewObj(1).Put("prop", Call(foodProp_26, V.Undef, f_657, key_656)).V);
return default;
}, 2, "", true);
Invoke(Object_keys(FOODS_28), "forEach", Fn((V _self1, int _argc660, V k_666, V _a663, V _a664, V _a665, V[] _rest661) => {
SetK(ST_18, ((V)(JsStrBuf.Begin().S("eat_").V(k_666).End())), Call(meal_29, V.Undef, k_666, GetK(FOODS_28, k_666)));
return default;
}, 1, "", true));
Set(R_8, "FOODHOLD", NewObj(0).V);
Invoke(Object_keys(FOODS_28), "forEach", Fn((V _self1, int _argc667, V k_673, V _a670, V _a671, V _a672, V[] _rest668) => {
SetK(Get(R_8, "FOODHOLD"), ((V)(JsStrBuf.Begin().S("eat_").V(k_673).End())), Get(GetK(FOODS_28, k_673), "hold"));
return default;
}, 1, "", true));
Set(R_8, "EATLIB", NewObj(4).Put("FOODS", FOODS_28).Put("foodProp", foodProp_26).Put("HOLD", HOLD_20).Put("REACT", REACT_25).V);
toolProp_30 = Fn((V _self1, int _argc674, V svg_680, V opt_681, V _a678, V _a679, V[] _rest675) => {
return Fn((V _self1, int _argc682, V I_688, V t_689, V _a686, V _a687, V[] _rest683) => {
V c_690 = default;
V W_691 = default;
V P_692 = default;
double sq_693 = 0;
c_690 = Get(I_688, "ctr");
W_691 = Get(I_688, "W");
if (Truthy((Get(c_690, "toolgone") is var _t694 && Truthy(_t694) ? _t694 : (!(Truthy(Get(W_691, "pawR"))) ? V.True : V.False)))) {
return ((V)(""));
}
P_692 = (SEqS(Get(opt_681, "hold"), "two") ? Arr(((V)((ToNum(Add(GetIdx(Get(W_691, "pawL"), 0D), GetIdx(Get(W_691, "pawR"), 0D))) / 2D))), ((V)(((ToNum(Add(GetIdx(Get(W_691, "pawL"), 1D), GetIdx(Get(W_691, "pawR"), 1D))) / 2D) - 3D)))) : GetK(W_691, ((V)((SEqS(Get(opt_681, "hold"), "L") ? "pawL" : "pawR")))));
sq_693 = (Truthy((Get(opt_681, "squish") is var _t695 && !Truthy(_t695) ? _t695 : Get(Get(I_688, "ctT"), "squeak"))) ? (1D - (0.3 * Max(0D, (1D - ((ToNum(Invoke(G("performance"), "now")) - ToNum(Get(Get(I_688, "ctT"), "squeak"))) / 260D))))) : 1D);
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(r2_10, V.Undef, Add(GetIdx(P_692, 0D), (Get(opt_681, "dx") is var _t696 && Truthy(_t696) ? _t696 : ((V)(0D)))))).S(" ").V(Call(r2_10, V.Undef, Add(GetIdx(P_692, 1D), (Get(opt_681, "dy") is var _t697 && Truthy(_t697) ? _t697 : ((V)(0D)))))).S(") rotate(").V((Get(opt_681, "rot") is var _t698 && Truthy(_t698) ? _t698 : ((V)(0D)))).S(") scale(").V(Call(r2_10, V.Undef, Call(SM_11, V.Undef, ((V)((ToNum(t_689) / 220D)))))).S(" ").V(Call(r2_10, V.Undef, ((V)((ToNum(Call(SM_11, V.Undef, ((V)((ToNum(t_689) / 220D))))) * sq_693))))).S(")\">").V((string.Equals(Typeof(svg_680), "function") ? Call(svg_680, V.Undef, I_688, t_689) : svg_680)).S("</g>").End()));
return default;
}, 2, "", true);
}, 2, "", true);
SPONGE_31 = ((V)("<rect x=\"-4\" y=\"-3\" width=\"8\" height=\"6\" rx=\"2\" fill=\"#ffd84a\" stroke=\"#e8b52a\" stroke-width=\"0.5\"/><circle cx=\"-1.6\" cy=\"-0.8\" r=\"0.6\" fill=\"#e8b52a\"/><circle cx=\"1.4\" cy=\"0.9\" r=\"0.5\" fill=\"#e8b52a\"/><circle cx=\"2\" cy=\"-1.4\" r=\"0.4\" fill=\"#e8b52a\"/><circle cx=\"-2.6\" cy=\"-3\" r=\"1.2\" fill=\"#ffffff\"/><circle cx=\"-0.8\" cy=\"-3.4\" r=\"1\" fill=\"#ffffff\"/>"));
BRUSH_32 = ((V)("<rect x=\"-1\" y=\"-14\" width=\"2\" height=\"13\" rx=\"1\" fill=\"#c88a5a\"/><rect x=\"-3.2\" y=\"-17.5\" width=\"6.4\" height=\"4\" rx=\"1.6\" fill=\"#7cc8ff\"/><path d=\"M-2.6 -17.5 L-2.6 -19.4 M-1 -17.5 L-1 -19.6 M0.6 -17.5 L0.6 -19.6 M2.2 -17.5 L2.2 -19.4\" stroke=\"#ffffff\" stroke-width=\"0.7\"/>"));
DUCK_33 = ((V)("<ellipse cx=\"0\" cy=\"1\" rx=\"5\" ry=\"3.6\" fill=\"#ffd23a\"/><path d=\"M-4.6 0 Q-6.4 -1.8 -5 -3 Q-4.2 -1.2 -3 -1Z\" fill=\"#ffd23a\"/><circle cx=\"2.4\" cy=\"-2.6\" r=\"2.8\" fill=\"#ffd23a\"/><path d=\"M4.8 -2.6 L7.4 -2 L4.8 -1.2Z\" fill=\"#ff9a3a\"/><circle cx=\"3.2\" cy=\"-3.2\" r=\"0.6\" fill=\"#2a1a30\"/><path d=\"M-1.6 0.4 Q0 2 1.6 0.4\" stroke=\"#f0b52a\" stroke-width=\"0.6\" fill=\"none\"/>"));
WAND_34 = ((V)("<path d=\"M0 0 L0 9\" stroke=\"#ff5cc6\" stroke-width=\"1\" stroke-linecap=\"round\"/><circle cx=\"0\" cy=\"-2.4\" r=\"2.6\" fill=\"rgba(220,245,255,0.45)\" stroke=\"#ff5cc6\" stroke-width=\"0.9\"/>"));
FOAM_35 = Arr(Arr(((V)((-12D))), ((V)(4D)), ((V)(5D))), Arr(((V)((-4D))), ((V)((-1D))), ((V)(6D))), Arr(((V)(5D)), ((V)(0D)), ((V)(5.5))), Arr(((V)(13D)), ((V)(5D)), ((V)(4.5))), Arr(((V)(0D)), ((V)(6D)), ((V)(5D))), Arr(((V)((-8D))), ((V)(8D)), ((V)(4D))), Arr(((V)(9D)), ((V)(9D)), ((V)(4D))), Arr(((V)((-15D))), ((V)(10D)), ((V)(3.4))), Arr(((V)(16D)), ((V)(11D)), ((V)(3.2))));
foamFx_36 = Fn((V _self1, int _argc699, V t0_705, V t1_706, V _a703, V _a704, V[] _rest700) => {
return Fn((V _self1, int _argc707, V I_713, V t_714, V _a711, V _a712, V[] _rest708) => {
double n_715 = 0;
double fade_716 = 0;
V x_717 = default;
V y_718 = default;
JsStrBuf h_719 = null;
if (Lt(t_714, t0_705)) {
return ((V)(""));
}
n_715 = Min(ToNum(Get(FOAM_35, "length")), (System.Math.Floor(((ToNum(t_714) - ToNum(t0_705)) / 260D)) + 1D));
fade_716 = (1D - ToNum(Call(SM_11, V.Undef, ((V)(((ToNum(t_714) - ToNum(t1_706)) / 500D))))));
if ((fade_716 <= 0D)) {
return ((V)(""));
}
{ V _t720 = (Get(Get(I_713, "W"), "head") is var _t721 && Truthy(_t721) ? _t721 : Arr(((V)(50D)), ((V)(17D))));
{ V _t722 = ListOf(_t720);
{ V _t723 = GetIdx(_t722, 0D);
x_717 = _t723; }
{ V _t724 = GetIdx(_t722, 1D);
y_718 = _t724; }
} }
h_719 = new JsStrBuf(JsStrBuf.Begin().S("<g opacity=\"").V(Call(r2_10, V.Undef, ((V)(fade_716)))).S("\">").End());
{
double i_725 = 0;
i_725 = 0D;
while (true) {
if (!((i_725 < n_715))) break;
V f_727 = default;
V g_728 = default;
double w_729 = 0;
f_727 = GetIdx(FOAM_35, i_725);
g_728 = Call(SM_11, V.Undef, ((V)((((ToNum(t_714) - ToNum(t0_705)) - (i_725 * 260D)) / 300D))));
w_729 = (FdLibm.Sin(((ToNum(t_714) / 300D) + i_725)) * 0.4);
h_719.S("<circle cx=\"").V(Call(r2_10, V.Undef, Add(x_717, GetIdx(f_727, 0D)))).S("\" cy=\"").V(Call(r2_10, V.Undef, ((V)((ToNum(Add(y_718, GetIdx(f_727, 1D))) - 2D))))).S("\" r=\"").V(Call(r2_10, V.Undef, ((V)(((ToNum(GetIdx(f_727, 2D)) * ToNum(g_728)) + w_729))))).S("\" fill=\"#ffffff\" stroke=\"#d6f2fc\" stroke-width=\"0.6\"/>");
i_725++;
}
}
return ((V)(string.Concat(h_719.Str, "</g>")));
return default;
}, 2, "", true);
}, 2, "", true);
B_37 = NewObj(0).V;
Set(B_37, "belly", Arr(((V)("Scrub the belly")), ((V)("Sponge circles on her tummy, bubbles.")), Call(Fn((V _self1, int _argc730, V _a732, V _a733, V _a734, V _a735, V[] _rest731) => {
V t_736 = default;
V a_737 = default;
V b_738 = default;
t_736 = Call(TL_13, V.Undef);
Invoke(t_736, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(9D)), ((V)(0D))), NewObj(3).Put("pitch", ((V)((-0.4)))).Put("ly", ((V)(0.7))).Put("smile", ((V)(0.5))).V), ((V)("io")));
a_737 = Get(t_736, "t");
Invoke(Invoke(t_736, "em", ((V)(2600D)), ((V)(200D)), ((V)("bubble")), ((V)("belly")), ((V)(1D))), "osc", ((V)(2600D)), ((V)(6D)), NewObj(4).Put("hRx", ((V)((-13D)))).Put("hRy", ((V)(3D))).Put("lean", ((V)(0.8))).Put("htilt", ((V)(2D))).V, NewObj(4).Put("hRx", ((V)((-6D)))).Put("hRy", ((V)((-3D)))).Put("lean", ((V)((-0.8)))).Put("htilt", ((V)((-2D)))).V, ((V)("s")));
b_738 = Get(t_736, "t");
Invoke(Invoke(Invoke(t_736, "at", a_737), "osc", ((V)(2600D)), ((V)(3D)), NewObj(2).Put("sq", ((V)(0.04))).Put("hap", ((V)(0.7))).V, NewObj(2).Put("sq", ((V)(0D))).Put("hap", ((V)(0.3))).V, ((V)("s"))), "at", b_738);
Invoke(Invoke(Invoke(Invoke(t_736, "to", ((V)(300D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(9D)), ((V)(0D))), NewObj(2).Put("pitch", ((V)((-0.1)))).Put("ly", ((V)(0.2))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(4).Put("sq", ((V)(0.06))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0.1))).V), "e", ((V)("toolgone"))), "rest", ((V)(450D)));
return Invoke(t_736, "done", NewObj(1).Put("prop", Call(toolProp_30, V.Undef, SPONGE_31, NewObj(1).Put("dy", ((V)((-1D)))).V)).V);
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "shampoo", Arr(((V)("Shampoo")), ((V)("Rubs her head with both paws, foam piles up.")), Call(Fn((V _self1, int _argc739, V _a741, V _a742, V _a743, V _a744, V[] _rest740) => {
V t_745 = default;
V a_746 = default;
V b_747 = default;
t_745 = Call(TL_13, V.Undef);
Invoke(t_745, "to", ((V)(450D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(2D)), ((V)((-31D)))), NewObj(7).Put("armL", ((V)(25D))).Put("armR", ((V)(25D))).Put("close", ((V)(1D))).Put("smile", ((V)(0.6))).Put("pitch", ((V)((-0.15)))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V), ((V)("io")));
a_746 = Get(t_745, "t");
Invoke(Invoke(t_745, "em", ((V)(3200D)), ((V)(260D)), ((V)("bubble")), ((V)("head")), ((V)(1D))), "osc", ((V)(3200D)), ((V)(7D)), NewObj(4).Put("hLy", ((V)((-35D)))).Put("hRy", ((V)((-28D)))).Put("htilt", ((V)(3D))).Put("sq", ((V)(0.03))).V, NewObj(4).Put("hLy", ((V)((-28D)))).Put("hRy", ((V)((-35D)))).Put("htilt", ((V)((-3D)))).Put("sq", ((V)(0D))).V, ((V)("s")));
b_747 = Get(t_745, "t");
Invoke(Invoke(Invoke(t_745, "at", a_746), "osc", ((V)(3200D)), ((V)(4D)), NewObj(2).Put("open", ((V)(0.15))).Put("wag", ((V)(12D))).V, NewObj(2).Put("open", ((V)(0D))).Put("wag", ((V)((-12D)))).V, ((V)("s"))), "at", b_747);
Invoke(Invoke(Invoke(Invoke(Invoke(t_745, "to", ((V)(400D)), NewObj(9).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(3D)), NewObj(2).Put("turn", ((V)(0.4))).Put("htilt", ((V)((-5D)))).V, NewObj(2).Put("turn", ((V)((-0.4)))).Put("htilt", ((V)(5D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("drop")), ((V)("head")), ((V)(6D))), "to", ((V)(300D)), NewObj(5).Put("close", ((V)(0D))).Put("turn", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), "rest", ((V)(450D)));
return Invoke(t_745, "done", NewObj(1).Put("fx", Call(foamFx_36, V.Undef, ((V)(500D)), Add(b_747, ((V)(300D))))).V);
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "face", Arr(((V)("Wash the face")), ((V)("Paws rub her cheeks, then splash and blink.")), Call(Fn((V _self1, int _argc748, V _a750, V _a751, V _a752, V _a753, V[] _rest749) => {
V t_754 = default;
t_754 = Call(TL_13, V.Undef);
Invoke(t_754, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(3D)), ((V)((-17D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(3D)), ((V)((-17D)))), NewObj(4).Put("sqz", ((V)(0.7))).Put("mw", ((V)(0.6))).Put("open", ((V)(0.08))).Put("puff", ((V)(0.2))).V), ((V)("io")));
Invoke(Invoke(t_754, "em", ((V)(2000D)), ((V)(300D)), ((V)("bubble")), ((V)("nose")), ((V)(1D))), "osc", ((V)(2000D)), ((V)(5D)), NewObj(5).Put("hLx", ((V)(6D))).Put("hLy", ((V)((-20D)))).Put("hRx", ((V)((-2D)))).Put("hRy", ((V)((-15D)))).Put("htilt", ((V)(3D))).V, NewObj(5).Put("hLx", ((V)(2D))).Put("hLy", ((V)((-15D)))).Put("hRx", ((V)((-6D)))).Put("hRy", ((V)((-20D)))).Put("htilt", ((V)((-3D)))).V, ((V)("s")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_754, "to", ((V)(160D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(7D)), ((V)((-25D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(7D)), ((V)((-25D)))), NewObj(1).Put("sq", ((V)(0.06))).V), ((V)("o"))), "e", ((V)("emit")), ((V)("splash")), ((V)("nose"))), "to", ((V)(300D)), NewObj(5).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(4).Put("sqz", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).V), "e", ((V)("blink2"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("turn", ((V)(0.35))).Put("htilt", ((V)((-4D)))).V, NewObj(2).Put("turn", ((V)((-0.35)))).Put("htilt", ((V)(4D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("drop")), ((V)("eyeL")), ((V)(3D))), "e", ((V)("emit")), ((V)("drop")), ((V)("eyeR")), ((V)(3D))), "to", ((V)(300D)), NewObj(4).Put("turn", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), "rest", ((V)(450D)));
return Invoke(t_754, "done");
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "back", Arr(((V)("Scrub the back")), ((V)("Reaches behind with a brush, twisting.")), Call(Fn((V _self1, int _argc755, V _a757, V _a758, V _a759, V _a760, V[] _rest756) => {
V t_761 = default;
V a_762 = default;
V b_763 = default;
t_761 = Call(TL_13, V.Undef);
Invoke(t_761, "to", ((V)(500D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)((-10D))), ((V)((-8D))), ((V)((-10.5)))), NewObj(6).Put("armR", ((V)(150D))).Put("spin", ((V)((-18D)))).Put("lx", ((V)(0.9))).Put("turn", ((V)(0.45))).Put("tongue", ((V)(0.5))).Put("footL", ((V)(2D))).V), ((V)("io")));
a_762 = Get(t_761, "t");
Invoke(Invoke(t_761, "em", ((V)(2800D)), ((V)(240D)), ((V)("bubble")), ((V)("sideR")), ((V)(1D))), "osc", ((V)(2800D)), ((V)(6D)), NewObj(3).Put("armR", ((V)(135D))).Put("spin", ((V)((-24D)))).Put("sq", ((V)(0.03))).V, NewObj(3).Put("armR", ((V)(168D))).Put("spin", ((V)((-12D)))).Put("sq", ((V)((-0.02)))).V, ((V)("s")));
b_763 = Get(t_761, "t");
Invoke(Invoke(Invoke(t_761, "at", a_762), "osc", ((V)(2800D)), ((V)(4D)), NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).V, NewObj(2).Put("footL", ((V)(2D))).Put("footR", ((V)(0D))).V, ((V)("s"))), "at", b_763);
Invoke(Invoke(Invoke(t_761, "to", ((V)(450D)), NewObj(13).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("hRz", ((V)(0D))).Put("armR", ((V)(0D))).Put("spin", ((V)(0D))).Put("lx", ((V)(0D))).Put("turn", ((V)(0D))).Put("tongue", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "e", ((V)("toolgone"))), "rest", ((V)(450D)));
return Invoke(t_761, "done", NewObj(2).Put("propZ", ((V)(0.5))).Put("prop", Call(toolProp_30, V.Undef, BRUSH_32, NewObj(2).Put("dy", ((V)(1D))).Put("rot", ((V)(25D))).V)).V);
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "splash", Arr(((V)("Splash around")), ((V)("Slaps the water with both paws, laughing.")), Call(Fn((V _self1, int _argc764, V _a766, V _a767, V _a768, V _a769, V[] _rest765) => {
V t_770 = default;
t_770 = Call(TL_13, V.Undef);
Invoke(t_770, "to", ((V)(250D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V);
{
double i_771 = 0;
i_771 = 0D;
while (true) {
if (!((i_771 < 6D))) break;
V two_773 = default;
two_773 = (((i_771 % 3D) != 1D) ? V.True : V.False);
Invoke(Invoke(Invoke(Invoke(Invoke(t_770, "to", ((V)(200D)), NewObj(6).Put("armL", ((V)((Truthy((two_773 is var _t774 && Truthy(_t774) ? _t774 : ((V)((i_771 % 2D))))) ? 70D : 10D)))).Put("armR", ((V)((Truthy((two_773 is var _t775 && Truthy(_t775) ? _t775 : (!(NumTruthy((i_771 % 2D))) ? V.True : V.False))) ? 70D : 10D)))).Put("sq", ((V)((-0.05)))).Put("lift", ((V)(2D))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(110D)), NewObj(6).Put("armL", ((V)((-12D)))).Put("armR", ((V)((-12D)))).Put("sq", ((V)(0.12))).Put("lift", ((V)(0D))).Put("earL", ((V)(8D))).Put("earR", ((V)(8D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("splash")), ((V)("pawL"))), "e", ((V)("emit")), ((V)("splash")), ((V)("pawR"))), "wait", ((V)(120D)));
i_771++;
}
}
Invoke(Invoke(Invoke(t_770, "to", ((V)(300D)), NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("open", ((V)(0.2))).V, ((V)("io"))), "osc", ((V)(600D)), ((V)(2D)), NewObj(1).Put("sq", ((V)(0.05))).V, NewObj(1).Put("sq", ((V)(0D))).V), "rest", ((V)(450D)));
return Invoke(t_770, "done");
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "duck", Arr(((V)("Rubber duck")), ((V)("Squeezes it, it squeaks, it swims, she kisses it.")), Call(Fn((V _self1, int _argc776, V _a778, V _a779, V _a780, V _a781, V[] _rest777) => {
V t_782 = default;
t_782 = Call(TL_13, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_782, "to", ((V)(350D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(7D)), ((V)((-6D)))), NewObj(3).Put("ly", ((V)(0.5))).Put("pitch", ((V)((-0.2)))).Put("smile", ((V)(0.6))).V), ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(120D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(10D)), ((V)((-6D)))), NewObj(1).Put("sq", ((V)(0.05))).V), ((V)("o"))), "e", ((V)("squeak"))), "to", ((V)(150D)), NewObj(4).Put("wide", ((V)(1D))).Put("sq", ((V)((-0.03)))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).V, ((V)("o"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(7D)), ((V)((-6D)))), NewObj(6).Put("wide", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V), ((V)("io"))), "osc", ((V)(400D)), ((V)(2D)), NewObj(1).Put("sq", ((V)(0.05))).V, NewObj(1).Put("sq", ((V)(0D))).V), "to", ((V)(120D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(10D)), ((V)((-6D))))), ((V)("o"))), "e", ((V)("squeak"))), "to", ((V)(200D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(7D)), ((V)((-6D))))), ((V)("io"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(4).Put("hLx", ((V)(13D))).Put("hRx", ((V)((-1D)))).Put("lx", ((V)(0.6))).Put("turn", ((V)(0.2))).V, NewObj(4).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-13D)))).Put("lx", ((V)((-0.6)))).Put("turn", ((V)((-0.2)))).V, ((V)("s"))), "to", ((V)(400D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(10D)), ((V)((-12D)))), NewObj(7).Put("lx", ((V)(0D))).Put("turn", ((V)(0D))).Put("pitch", ((V)((-0.15)))).Put("mw", ((V)(0.4))).Put("blush", ((V)(1D))).Put("hap", ((V)(0.6))).Put("open", ((V)(0D))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("mouth")), ((V)(2D))), "wait", ((V)(400D))), "to", ((V)(350D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(7D)), ((V)((-6D)))), NewObj(1).Put("mw", ((V)(1D))).V), ((V)("io"))), "e", ((V)("toolgone"))), "rest", ((V)(450D)));
return Invoke(t_782, "done", NewObj(1).Put("prop", Call(toolProp_30, V.Undef, DUCK_33, NewObj(2).Put("hold", ((V)("two"))).Put("squish", (true ? V.True : V.False)).V)).V);
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "bubbles", Arr(((V)("Blow bubbles")), ((V)("Puffs her cheeks, blows big bubbles, pops one.")), Call(Fn((V _self1, int _argc783, V _a785, V _a786, V _a787, V _a788, V[] _rest784) => {
V t_789 = default;
t_789 = Call(TL_13, V.Undef);
Invoke(t_789, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-8D))))), ((V)("io")));
{
double i_790 = 0;
i_790 = 0D;
while (true) {
if (!((i_790 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(Invoke(t_789, "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-13D)))), NewObj(4).Put("puff", ((V)(1D))).Put("pitch", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V), ((V)("io"))), "to", ((V)(450D)), NewObj(4).Put("puff", ((V)(0D))).Put("mw", ((V)(0.35))).Put("open", ((V)(0.18))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("bigbubble")), ((V)("pawR"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("pawR")), ((V)(2D))), "to", ((V)(500D)), NewObj(8).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("lx", ((V)(0.7))).Put("ly", ((V)((-0.7)))).Put("pitch", ((V)(0.3))).Put("hap", ((V)(0.6))).Put("smile", ((V)(0.8))).V, ((V)("io")));
i_790++;
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_789, "to", ((V)(260D)), NewObj(2).Put("armL", ((V)(120D))).Put("hLy", ((V)((-6D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), Arr(((V)(70D)), ((V)(26D))), ((V)(5D))), "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hap", ((V)(1D))).Put("open", ((V)(0.35))).V, ((V)("io"))), "e", ((V)("toolgone"))), "rest", ((V)(450D)));
return Invoke(t_789, "done", NewObj(1).Put("prop", Call(toolProp_30, V.Undef, WAND_34, NewObj(2).Put("dx", ((V)((-1D)))).Put("dy", ((V)((-4D)))).V)).V);
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "shake", Arr(((V)("Shake dry")), ((V)("Wet-dog shake from head to tail, then fluffy.")), Call(Fn((V _self1, int _argc792, V _a794, V _a795, V _a796, V _a797, V[] _rest793) => {
V t_798 = default;
t_798 = Call(TL_13, V.Undef);
Invoke(Invoke(t_798, "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0.1))).Put("close", ((V)(0.6))).Put("earL", ((V)(6D))).Put("earR", ((V)(6D))).V, ((V)("io"))), "em", ((V)(1300D)), ((V)(70D)), ((V)("splash")), ((V)("body")), ((V)(2D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_798, "osc", ((V)(1300D)), ((V)(9D)), NewObj(4).Put("spin", ((V)(26D))).Put("htilt", ((V)((-8D)))).Put("sqz", ((V)(1D))).Put("open", ((V)(0.2))).V, NewObj(2).Put("spin", ((V)((-26D)))).Put("htilt", ((V)(8D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(7).Put("spin", ((V)(0D))).Put("htilt", ((V)(0D))).Put("sqz", ((V)(0D))).Put("open", ((V)(0D))).Put("close", ((V)(0D))).Put("sq", ((V)((-0.06)))).Put("wide", ((V)(0.6))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(2D)), NewObj(3).Put("htilt", ((V)(5D))).Put("lx", ((V)(0.6))).Put("ly", ((V)((-0.3)))).V, NewObj(3).Put("htilt", ((V)((-5D)))).Put("lx", ((V)((-0.6)))).Put("ly", ((V)(0.3))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(6).Put("wide", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), "rest", ((V)(450D)));
return Invoke(t_798, "done");
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "ears", Arr(((V)("Clean the ears")), ((V)("Tilts her head, rubs each ear, ear flicks.")), Call(Fn((V _self1, int _argc799, V _a801, V _a802, V _a803, V _a804, V[] _rest800) => {
V t_805 = default;
t_805 = Call(TL_13, V.Undef);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _self1, int _argc806, V s_812, V _a809, V _a810, V _a811, V[] _rest807) => {
V k_813 = default;
k_813 = Call(S_14, V.Undef, s_812);
Invoke(Invoke(Invoke(t_805, "to", ((V)(400D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, s_812, ((V)((-6D))), ((V)((-26D)))), NewObj(5).PutK(Get(k_813, "arm"), ((V)(35D))).Put("htilt", ((V)((ToNum(s_812) * 12D)))).Put("lean", ((V)((ToNum(s_812) * 1.5)))).PutK(Get(k_813, "wink"), ((V)(1D))).Put("tongue", ((V)(0.3))).V), ((V)("io"))), "osc", ((V)(1400D)), ((V)(4D)), NewObj(2).PutK(Get(k_813, "hy"), ((V)((-30D)))).PutK(Get(k_813, "ear"), ((V)(10D))).V, NewObj(2).PutK(Get(k_813, "hy"), ((V)((-24D)))).PutK(Get(k_813, "ear"), ((V)((-6D)))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(8).PutK(Get(k_813, "hx"), ((V)(0D))).PutK(Get(k_813, "hy"), ((V)(0D))).PutK(Get(k_813, "arm"), ((V)(0D))).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).PutK(Get(k_813, "wink"), ((V)(0D))).PutK(Get(k_813, "ear"), ((V)(0D))).Put("tongue", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true));
Invoke(Invoke(Invoke(Invoke(Invoke(t_805, "osc", ((V)(700D)), ((V)(3D)), NewObj(2).Put("turn", ((V)(0.35))).Put("htilt", ((V)((-5D)))).V, NewObj(2).Put("turn", ((V)((-0.35)))).Put("htilt", ((V)(5D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("drop")), ((V)("earL")), ((V)(3D))), "e", ((V)("emit")), ((V)("drop")), ((V)("earR")), ((V)(3D))), "to", ((V)(250D)), NewObj(4).Put("turn", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(0.8))).V), "rest", ((V)(450D)));
return Invoke(t_805, "done");
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "soak", Arr(((V)("Relax and soak")), ((V)("Leans back, eyes closed, slow happy breaths.")), Call(Fn((V _self1, int _argc814, V _a816, V _a817, V _a818, V _a819, V[] _rest815) => {
V t_820 = default;
V a_821 = default;
V b_822 = default;
t_820 = Call(TL_13, V.Undef);
Invoke(Invoke(t_820, "to", ((V)(700D)), NewObj(9).Put("pitch", ((V)(0.35))).Put("lean", ((V)((-1.2)))).Put("close", ((V)(1D))).Put("smile", ((V)(0.6))).Put("armL", ((V)(35D))).Put("armR", ((V)(35D))).Put("sq", ((V)(0.05))).Put("earL", ((V)(6D))).Put("earR", ((V)(6D))).V, ((V)("io"))), "em", ((V)(6000D)), ((V)(420D)), ((V)("steam")), ((V)("body")), ((V)(1D)));
a_821 = Get(t_820, "t");
Invoke(t_820, "osc", ((V)(4800D)), ((V)(2D)), NewObj(2).Put("sq", ((V)((-0.03)))).Put("pitch", ((V)(0.42))).V, NewObj(2).Put("sq", ((V)(0.06))).Put("pitch", ((V)(0.32))).V, ((V)("s")));
b_822 = Get(t_820, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_820, "at", Add(a_821, ((V)(1200D)))), "osc", ((V)(1600D)), ((V)(4D)), NewObj(2).Put("footL", ((V)(1.5))).Put("footR", ((V)(0D))).V, NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(1.5))).V, ((V)("s"))), "at", Add(a_821, ((V)(3000D)))), "to", ((V)(400D)), NewObj(2).Put("open", ((V)(0.3))).Put("mw", ((V)(0.7))).V, ((V)("io"))), "to", ((V)(600D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io"))), "at", b_822);
Invoke(Invoke(Invoke(t_820, "to", ((V)(500D)), NewObj(9).Put("pitch", ((V)(0D))).Put("lean", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("hap", ((V)(0.8))).V, ((V)("io"))), "e", ((V)("blink"))), "rest", ((V)(450D)));
return Invoke(t_820, "done");
return default;
}, 0, "", true), V.Undef)));
Set(Get(R_8, "PRE"), "steamBig", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(16D))).Put("vy", ((V)((-9D)))).Put("g", ((V)((-3D)))).Put("life", ((V)(1700D))).Put("r", Arr(((V)(3D)), ((V)(5.5)))).Put("col", Arr(((V)("#ffffff")))).Put("kind", ((V)("puff"))).V);
fxs_38 = Fn((V _self1, int _argc823, V _a825, V _a826, V _a827, V _a828, V[] _rest824) => {
V f_829 = default;
f_829 = RestArgs(0, _argc823, _a825, _a826, _a827, _a828, _rest824);
return Fn((V _self1, int _argc830, V I_836, V t_837, V _a834, V _a835, V[] _rest831) => {
return Invoke(Invoke(Invoke(f_829, "filter", G("Boolean")), "map", Fn((V _self1, int _argc838, V g_844, V _a841, V _a842, V _a843, V[] _rest839) => {
return Call(g_844, V.Undef, I_836, t_837);
}, 1, "", true)), "join", ((V)("")));
}, 2, "", true);
}, 1, "", true);
SOAP_39 = Arr(Arr(((V)("head")), ((V)((-13D))), ((V)(7D)), ((V)(4.2))), Arr(((V)("body")), ((V)((-17D))), ((V)((-2D))), ((V)(4.4))), Arr(((V)("belly")), ((V)(4D)), ((V)(1D)), ((V)(3.6))), Arr(((V)("head")), ((V)(6D)), ((V)(1D)), ((V)(4.6))), Arr(((V)("sideR")), ((V)(1D)), ((V)((-3D))), ((V)(3.8))), Arr(((V)("body")), ((V)(12D)), ((V)(6D)), ((V)(3.8))), Arr(((V)("earL")), ((V)(1D)), ((V)(3D)), ((V)(2.6))), Arr(((V)("sideL")), ((V)((-1D))), ((V)(2D)), ((V)(3.6))), Arr(((V)("head")), ((V)((-4D))), ((V)(2D)), ((V)(4D))), Arr(((V)("body")), ((V)((-8D))), ((V)(7D)), ((V)(3.4))), Arr(((V)("earR")), ((V)((-1D))), ((V)(3D)), ((V)(2.6))), Arr(((V)("body")), ((V)(18D)), ((V)((-4D))), ((V)(3.6))), Arr(((V)("head")), ((V)(14D)), ((V)(8D)), ((V)(3.6))), Arr(((V)("belly")), ((V)((-6D))), ((V)(3D)), ((V)(3.2))), Arr(((V)("body")), ((V)(0D)), ((V)((-6D))), ((V)(3D))), Arr(((V)("sideL")), ((V)(2D)), ((V)((-6D))), ((V)(3D))), Arr(((V)("sideR")), ((V)((-2D))), ((V)(4D)), ((V)(3.2))), Arr(((V)("head")), ((V)(0D)), ((V)(8D)), ((V)(3D))), Arr(((V)("footL")), ((V)(0D)), ((V)((-2D))), ((V)(2.6))), Arr(((V)("footR")), ((V)(0D)), ((V)((-2D))), ((V)(2.6))));
soapFx_40 = Fn((V _self1, int _argc845, V n_851, V a_852, V f_853, V r_854, V[] _rest846) => {
V rd_855 = default;
rd_855 = (_argc845 > 4 ? _rest846[0] : V.Undef);
return Fn((V _self1, int _argc856, V I_862, V t_863, V _a860, V _a861, V[] _rest857) => {
V W_864 = default;
JsStrBuf h_865 = null;
W_864 = Get(I_862, "W");
if (!(Truthy(Get(W_864, "body")))) {
return ((V)(""));
}
h_865 = new JsStrBuf("");
n_851 = ((V)(Min(ToNum(n_851), ToNum(Get(SOAP_39, "length")))));
{
double i_866 = 0;
i_866 = 0D;
while (true) {
if (!(Lt(((V)(i_866)), n_851))) break;
V w_868 = default;
V dx_869 = default;
V dy_870 = default;
V rr_871 = default;
V p_872 = default;
double g_873 = 0;
V x_874 = default;
V y_875 = default;
double wb_876 = 0;
double R0_877 = 0;
{ V _t878 = GetIdx(SOAP_39, i_866);
{ V _t879 = ListOf(_t878);
{ V _t880 = GetIdx(_t879, 0D);
w_868 = _t880; }
{ V _t881 = GetIdx(_t879, 1D);
dx_869 = _t881; }
{ V _t882 = GetIdx(_t879, 2D);
dy_870 = _t882; }
{ V _t883 = GetIdx(_t879, 3D);
rr_871 = _t883; }
} }
p_872 = GetK(W_864, w_868);
if (!(Truthy(p_872))) {
goto _cont867;
}
g_873 = (ToNum(Call(SM_11, V.Undef, ((V)((((ToNum(t_863) - ToNum(a_852)) - ((i_866 * (ToNum(f_853) - ToNum(a_852))) / ToNum(n_851))) / 260D))))) * (1D - ToNum(Call(SM_11, V.Undef, ((V)((((ToNum(t_863) - ToNum(r_854)) - ((i_866 % 5D) * 60D)) / ToNum((rd_855 is var _t884 && Truthy(_t884) ? _t884 : ((V)(450D)))))))))));
if ((g_873 <= 0.01)) {
goto _cont867;
}
x_874 = Add(GetIdx(p_872, 0D), dx_869);
y_875 = Add(GetIdx(p_872, 1D), dy_870);
wb_876 = (FdLibm.Sin(((ToNum(t_863) / 340D) + (i_866 * 1.7))) * 0.35);
R0_877 = ((ToNum(rr_871) * (0.4 + (0.6 * g_873))) + wb_876);
h_865.S("<g opacity=\"").V(Call(r2_10, V.Undef, ((V)(g_873)))).S("\"><circle cx=\"").V(Call(r2_10, V.Undef, x_874)).S("\" cy=\"").V(Call(r2_10, V.Undef, y_875)).S("\" r=\"").V(Call(r2_10, V.Undef, ((V)(R0_877)))).S("\" fill=\"#ffffff\" stroke=\"#cfeefc\" stroke-width=\"0.55\"/><circle cx=\"").V(Call(r2_10, V.Undef, Add(x_874, ((V)((R0_877 * 0.85)))))).S("\" cy=\"").V(Call(r2_10, V.Undef, Add(y_875, ((V)((R0_877 * 0.35)))))).S("\" r=\"").V(Call(r2_10, V.Undef, ((V)((R0_877 * 0.55))))).S("\" fill=\"#ffffff\" stroke=\"#cfeefc\" stroke-width=\"0.45\"/><circle cx=\"").V(Call(r2_10, V.Undef, ((V)((ToNum(x_874) - (R0_877 * 0.75)))))).S("\" cy=\"").V(Call(r2_10, V.Undef, Add(y_875, ((V)((R0_877 * 0.45)))))).S("\" r=\"").V(Call(r2_10, V.Undef, ((V)((R0_877 * 0.45))))).S("\" fill=\"#ffffff\" stroke=\"#cfeefc\" stroke-width=\"0.45\"/><circle cx=\"").V(Call(r2_10, V.Undef, ((V)((ToNum(x_874) - (R0_877 * 0.3)))))).S("\" cy=\"").V(Call(r2_10, V.Undef, ((V)((ToNum(y_875) - (R0_877 * 0.35)))))).S("\" r=\"").V(Call(r2_10, V.Undef, ((V)((R0_877 * 0.22))))).S("\" fill=\"#e6f7ff\"/></g>");
_cont867: ;
i_866++;
}
}
return ((V)(h_865.Str));
return default;
}, 2, "", true);
}, 5, "", true);
MINI_41 = Fn((V _self1, int _argc885, V s_891, V fl_892, V _a889, V _a890, V[] _rest886) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"scale(").V(Call(r2_10, V.Undef, s_891)).S(")").S((Truthy(fl_892) ? " scale(-1 1)" : "")).S("\">").V(DUCK_33).S("</g>").End()));
}, 2, "", true);
SetIdx(Get(B_37, "duck"), 1D, ((V)("A whole flock of ducks bobs around her; she squeezes one, it squeaks, one hops onto her head.")));
Set(GetIdx(Get(B_37, "duck"), 2D), "fx", Fn((V _self1, int _argc893, V I_899, V t_900, V _a897, V _a898, V[] _rest894) => {
JsStrBuf h_901 = null;
V hd_902 = default;
V u_903 = default;
double up_904 = 0;
h_901 = new JsStrBuf("");
Invoke(Arr(Arr(((V)(16D)), ((V)(0.62)), ((V)(0D))), Arr(((V)(30D)), ((V)(0.5)), ((V)(1D))), Arr(((V)(72D)), ((V)(0.55)), ((V)(1D))), Arr(((V)(86D)), ((V)(0.66)), ((V)(0D))), Arr(((V)(50D)), ((V)(0.45)), ((V)(0D)))), "forEach", Fn((V _self1, int _argc905, V _a907, V i_911, V _a909, V _a910, V[] _rest906) => {
V x_919 = default;
double y_920 = 0;
V sp_921 = default;
V x0_914 = default;
V sc_916 = default;
V fl_918 = default;
{ V _t912 = ListOf(_a907);
{ V _t913 = GetIdx(_t912, 0D);
x0_914 = _t913; }
{ V _t915 = GetIdx(_t912, 1D);
sc_916 = _t915; }
{ V _t917 = GetIdx(_t912, 2D);
fl_918 = _t917; }
}
x_919 = Add(x0_914, ((V)((FdLibm.Sin(((ToNum(t_900) / 900D) + (ToNum(i_911) * 2D))) * 3D))));
y_920 = ((92D + (FdLibm.Sin(ToNum(Add(((V)((ToNum(t_900) / 380D))), i_911))) * 0.8)) - (SEqN(i_911, 4D) ? 4D : 0D));
sp_921 = Call(SM_11, V.Undef, ((V)(((ToNum(t_900) - (ToNum(i_911) * 160D)) / 300D))));
h_901.S("<g transform=\"translate(").V(Call(r2_10, V.Undef, x_919)).S(" ").V(Call(r2_10, V.Undef, ((V)(y_920)))).S(") rotate(").V(Call(r2_10, V.Undef, ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_900) / 420D))), i_911))) * 8D))))).S(") scale(").V(Call(r2_10, V.Undef, sp_921)).S(")\">").V(Call(MINI_41, V.Undef, sc_916, fl_918)).S("</g>");
return default;
}, 2, "", true));
hd_902 = Get(Get(I_899, "W"), "head");
u_903 = Call(SM_11, V.Undef, ((V)(((ToNum(t_900) - 3600D) / 380D))));
up_904 = (FdLibm.Sin((System.Math.PI * Min(1D, Max(0D, ((ToNum(t_900) - 3600D) / 380D))))) * 8D);
if (Truthy(((hd_902 is var _t922 && !Truthy(_t922) ? _t922 : (GtN(t_900, 3600D) ? V.True : V.False)) is var _t923 && !Truthy(_t923) ? _t923 : (LtN(t_900, (Truthy(Get(I_899, "cur")) ? 1000000000D : 1000000000D)) ? V.True : V.False)))) {
h_901.S("<g transform=\"translate(").V(Call(r2_10, V.Undef, Add(Add(GetIdx(hd_902, 0D), ((V)(2D))), ((V)(((1D - ToNum(u_903)) * 26D)))))).S(" ").V(Call(r2_10, V.Undef, ((V)((((ToNum(GetIdx(hd_902, 1D)) - 3D) - up_904) + ((1D - ToNum(u_903)) * 60D)))))).S(") rotate(").V(Call(r2_10, V.Undef, ((V)((FdLibm.Sin((ToNum(t_900) / 300D)) * 6D))))).S(")\">").V(Call(MINI_41, V.Undef, ((V)(0.6)), ((V)(0D)))).S("</g>");
}
return ((V)(h_901.Str));
return default;
}, 2, "", true));
Set(GetIdx(Get(B_37, "duck"), 2D), "emit", Invoke((Get(GetIdx(Get(B_37, "duck"), 2D), "emit") is var _t924 && Truthy(_t924) ? _t924 : Arr()), "concat", Arr(Arr(((V)(3700D)), ((V)(4200D)), ((V)(999D)), ((V)("spark")), ((V)("head")), ((V)(3D))))));
Set(B_37, "mask", Arr(((V)("Face mask")), ((V)("Pats on a green mask, cucumber slices on her eyes, relaxes, wipes it off fresh.")), Call(Fn((V _self1, int _argc925, V _a927, V _a928, V _a929, V _a930, V[] _rest926) => {
V t_931 = default;
V a_932 = default;
V b_933 = default;
t_931 = Call(TL_13, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_931, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(3D)), ((V)((-17D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(3D)), ((V)((-17D)))), NewObj(2).Put("close", ((V)(0.5))).Put("smile", ((V)(0.4))).V), ((V)("io"))), "e", ((V)("mask"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(3).Put("hLy", ((V)((-19D)))).Put("hRy", ((V)((-15D)))).Put("sq", ((V)(0.03))).V, NewObj(3).Put("hLy", ((V)((-15D)))).Put("hRy", ((V)((-19D)))).Put("sq", ((V)(0D))).V, ((V)("s"))), "to", ((V)(400D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)((-27D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-27D)))), NewObj(1).Put("close", ((V)(1D))).V), ((V)("io"))), "e", ((V)("cuke"))), "to", ((V)(350D)), NewObj(11).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("pitch", ((V)(0.3))).Put("lean", ((V)((-1D)))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("smile", ((V)(0.7))).Put("earL", ((V)(6D))).Put("earR", ((V)(6D))).V, ((V)("io")));
a_932 = Get(t_931, "t");
Invoke(t_931, "osc", ((V)(3000D)), ((V)(2D)), NewObj(2).Put("sq", ((V)((-0.02)))).Put("pitch", ((V)(0.36))).V, NewObj(2).Put("sq", ((V)(0.05))).Put("pitch", ((V)(0.28))).V, ((V)("s")));
b_933 = Get(t_931, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(t_931, "at", Add(a_932, ((V)(600D)))), "e", ((V)("emit")), ((V)("note")), ((V)("mouth"))), "at", Add(a_932, ((V)(1800D)))), "e", ((V)("emit")), ((V)("note")), ((V)("mouth"))), "at", b_933);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_931, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)((-27D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-27D)))), NewObj(4).Put("pitch", ((V)(0D))).Put("lean", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io"))), "e", ((V)("cukeoff"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(3D)), ((V)((-17D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(3D)), ((V)((-17D)))), NewObj(1).Put("close", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(4).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-6D)))).Put("hLy", ((V)((-19D)))).Put("hRy", ((V)((-19D)))).V, NewObj(4).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("hLy", ((V)((-15D)))).Put("hRy", ((V)((-15D)))).V, ((V)("s"))), "e", ((V)("maskoff"))), "to", ((V)(300D)), NewObj(7).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("close", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("eyeL")), ((V)(4D))), "e", ((V)("emit")), ((V)("spark")), ((V)("eyeR")), ((V)(4D))), "to", ((V)(250D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("blush", ((V)(0.8))).Put("sq", ((V)(0.1))).V), "to", ((V)(220D)), NewObj(2).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(6D))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.15))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V), "rest", ((V)(450D)));
return Invoke(t_931, "done", NewObj(1).Put("prop", Fn((V _self1, int _argc934, V I_940, V tt_941, V _a938, V _a939, V[] _rest935) => {
V c_942 = default;
V W_943 = default;
V now_944 = default;
double ma_945 = 0;
V eL_946 = default;
V eR_947 = default;
V m_948 = default;
double cx_949 = 0;
double cy_950 = 0;
double w_951 = 0;
double ang_952 = 0;
V id_953 = default;
JsStrBuf h_954 = null;
c_942 = Get(I_940, "ctT");
W_943 = Get(I_940, "W");
if ((!(Truthy(Get(c_942, "mask"))) || !(Truthy(Get(W_943, "eyeL"))))) {
return ((V)(""));
}
now_944 = Invoke(G("performance"), "now");
ma_945 = (ToNum(Call(SM_11, V.Undef, ((V)(((ToNum(now_944) - ToNum(Get(c_942, "mask"))) / 900D))))) * (Truthy(Get(c_942, "maskoff")) ? (1D - ToNum(Call(SM_11, V.Undef, ((V)(((ToNum(now_944) - ToNum(Get(c_942, "maskoff"))) / 500D)))))) : 1D));
eL_946 = Get(W_943, "eyeL");
eR_947 = Get(W_943, "eyeR");
m_948 = Get(W_943, "mouth");
cx_949 = (ToNum(Add(GetIdx(eL_946, 0D), GetIdx(eR_947, 0D))) / 2D);
cy_950 = ((ToNum(Add(GetIdx(eL_946, 1D), GetIdx(eR_947, 1D))) / 2D) + 3D);
w_951 = Max(6D, (ToNum(GetIdx(eR_947, 0D)) - ToNum(GetIdx(eL_946, 0D))));
ang_952 = ((FdLibm.Atan2((ToNum(GetIdx(eR_947, 1D)) - ToNum(GetIdx(eL_946, 1D))), (ToNum(GetIdx(eR_947, 0D)) - ToNum(GetIdx(eL_946, 0D)))) * 180D) / System.Math.PI);
id_953 = ((V)(JsStrBuf.Begin().S("mk").V(Get(I_940, "u")).End()));
h_954 = new JsStrBuf("");
if ((ma_945 > 0.01)) {
h_954.S("<mask id=\"").V(id_953).S("\" maskUnits=\"userSpaceOnUse\" x=\"0\" y=\"0\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"#fff\"/><ellipse cx=\"").V(Call(r2_10, V.Undef, GetIdx(eL_946, 0D))).S("\" cy=\"").V(Call(r2_10, V.Undef, GetIdx(eL_946, 1D))).S("\" rx=\"4.6\" ry=\"4.6\" fill=\"#000\"/><ellipse cx=\"").V(Call(r2_10, V.Undef, GetIdx(eR_947, 0D))).S("\" cy=\"").V(Call(r2_10, V.Undef, GetIdx(eR_947, 1D))).S("\" rx=\"4.6\" ry=\"4.6\" fill=\"#000\"/><ellipse cx=\"").V(Call(r2_10, V.Undef, GetIdx(m_948, 0D))).S("\" cy=\"").V(Call(r2_10, V.Undef, Add(GetIdx(m_948, 1D), ((V)(0.5))))).S("\" rx=\"3.6\" ry=\"2.2\" fill=\"#000\"/></mask>").S("<g mask=\"url(#").V(id_953).S(")\" opacity=\"").V(Call(r2_10, V.Undef, ((V)((ma_945 * 0.92))))).S("\"><ellipse cx=\"").V(Call(r2_10, V.Undef, ((V)(cx_949)))).S("\" cy=\"").V(Call(r2_10, V.Undef, ((V)(cy_950)))).S("\" rx=\"").V(Call(r2_10, V.Undef, ((V)((w_951 * 1.12))))).S("\" ry=\"").V(Call(r2_10, V.Undef, ((V)((w_951 * 0.86))))).S("\" transform=\"rotate(").V(Call(r2_10, V.Undef, ((V)(ang_952)))).S(" ").V(Call(r2_10, V.Undef, ((V)(cx_949)))).S(" ").V(Call(r2_10, V.Undef, ((V)(cy_950)))).S(")\" fill=\"#9fd67a\"/><circle cx=\"").V(Call(r2_10, V.Undef, ((V)((cx_949 - (w_951 * 0.6)))))).S("\" cy=\"").V(Call(r2_10, V.Undef, ((V)((cy_950 + 3D))))).S("\" r=\"1\" fill=\"#c4eaa6\"/><circle cx=\"").V(Call(r2_10, V.Undef, ((V)((cx_949 + (w_951 * 0.5)))))).S("\" cy=\"").V(Call(r2_10, V.Undef, ((V)((cy_950 - 4D))))).S("\" r=\"0.8\" fill=\"#c4eaa6\"/><circle cx=\"").V(Call(r2_10, V.Undef, ((V)((cx_949 + (w_951 * 0.2)))))).S("\" cy=\"").V(Call(r2_10, V.Undef, ((V)((cy_950 + 6D))))).S("\" r=\"0.7\" fill=\"#c4eaa6\"/></g>");
}
if (Truthy((Get(c_942, "cuke") is var _t956 && !Truthy(_t956) ? _t956 : (!(Truthy((Get(c_942, "cukeoff") is var _t955 && !Truthy(_t955) ? _t955 : (((ToNum(now_944) - ToNum(Get(c_942, "cukeoff"))) > 250D) ? V.True : V.False)))) ? V.True : V.False)))) {
double k_957 = 0;
k_957 = (ToNum(Call(SM_11, V.Undef, ((V)(((ToNum(now_944) - ToNum(Get(c_942, "cuke"))) / 200D))))) * (Truthy(Get(c_942, "cukeoff")) ? (1D - ToNum(Call(SM_11, V.Undef, ((V)(((ToNum(now_944) - ToNum(Get(c_942, "cukeoff"))) / 250D)))))) : 1D));
Invoke(Arr(eL_946, eR_947), "forEach", Fn((V _self1, int _argc958, V e_964, V _a961, V _a962, V _a963, V[] _rest959) => {
h_954.S("<g transform=\"translate(").V(Call(r2_10, V.Undef, GetIdx(e_964, 0D))).S(" ").V(Call(r2_10, V.Undef, GetIdx(e_964, 1D))).S(") scale(").V(Call(r2_10, V.Undef, ((V)(k_957)))).S(")\"><circle r=\"5\" fill=\"#5fae4a\"/><circle r=\"4.2\" fill=\"#c8ef9a\"/><circle r=\"1.2\" fill=\"#e8ffd0\"/><path d=\"M0 -3.4 L0 -1.6 M0 1.6 L0 3.4 M-3.4 0 L-1.6 0 M1.6 0 L3.4 0\" stroke=\"#a6dc78\" stroke-width=\"0.5\"/></g>");
return default;
}, 1, "", true));
}
return ((V)(h_954.Str));
return default;
}, 2, "prop", true)).V);
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "sauna", Arr(((V)("Sauna")), ((V)("Towel on her head, steam all around, gets rosy and sweaty, fans herself, phew.")), Call(Fn((V _self1, int _argc965, V _a967, V _a968, V _a969, V _a970, V[] _rest966) => {
V t_971 = default;
V a_972 = default;
t_971 = Call(TL_13, V.Undef);
Invoke(Invoke(Invoke(t_971, "to", ((V)(600D)), NewObj(9).Put("sl", ((V)(1D))).Put("smile", ((V)(0.6))).Put("close", ((V)(0.4))).Put("sq", ((V)(0.06))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("red", ((V)(0.25))).V, ((V)("io"))), "em", ((V)(7200D)), ((V)(160D)), ((V)("steamBig")), ((V)("body")), ((V)(1D))), "em", ((V)(7200D)), ((V)(300D)), ((V)("steam")), ((V)("head")), ((V)(1D)));
a_972 = Get(t_971, "t");
Invoke(t_971, "osc", ((V)(2400D)), ((V)(1D)), NewObj(3).Put("sq", ((V)(0.02))).Put("red", ((V)(0.5))).Put("close", ((V)(0.6))).V, NewObj(3).Put("sq", ((V)(0.08))).Put("red", ((V)(0.6))).Put("close", ((V)(0.5))).V, ((V)("s")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_971, "at", Add(a_972, ((V)(900D)))), "e", ((V)("emit")), ((V)("sweat")), Arr(((V)(37D)), ((V)(30D)))), "at", Add(a_972, ((V)(1700D)))), "e", ((V)("emit")), ((V)("sweat")), Arr(((V)(64D)), ((V)(32D)))), "at", Add(a_972, ((V)(2400D))));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_971, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-16D)))), NewObj(5).Put("red", ((V)(0.75))).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).Put("close", ((V)(0.2))).Put("sl", ((V)(0.5))).V), ((V)("io"))), "osc", ((V)(1500D)), ((V)(6D)), NewObj(1).Put("hRx", ((V)((-16D)))).V, NewObj(1).Put("hRx", ((V)((-9D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sweat")), Arr(((V)(40D)), ((V)(28D)))), "e", ((V)("emit")), ((V)("sweat")), Arr(((V)(61D)), ((V)(29D)))), "to", ((V)(300D)), NewObj(4).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("armR", ((V)(60D))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("armR", ((V)((-10D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steamBig")), Arr(((V)(70D)), ((V)(88D))), ((V)(6D))), "e", ((V)("emit")), ((V)("steamBig")), Arr(((V)(30D)), ((V)(88D))), ((V)(6D))), "to", ((V)(300D)), NewObj(3).Put("wide", ((V)(0.6))).Put("armR", ((V)(0D))).Put("red", ((V)(0.9))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(6).Put("sq", ((V)(0.12))).Put("earL", ((V)(22D))).Put("earR", ((V)(22D))).Put("sl", ((V)(1D))).Put("close", ((V)(0.55))).Put("red", ((V)(0.95))).V, ((V)("io"))), "to", ((V)(400D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-30D)))), NewObj(2).Put("armR", ((V)(30D))).Put("wide", ((V)(0D))).V), ((V)("io"))), "to", ((V)(450D)), NewObj(2).Put("hRx", ((V)(6D))).Put("hRy", ((V)((-26D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sweat")), Arr(((V)(72D)), ((V)(30D)))), "to", ((V)(300D)), NewObj(5).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("armR", ((V)(0D))).Put("open", ((V)(0.35))).Put("sq", ((V)((-0.04)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("open", ((V)(0D))).Put("sq", ((V)(0.05))).V), "to", ((V)(500D)), NewObj(1).Put("red", ((V)(0.3))).V), "rest", ((V)(500D)));
return Invoke(t_971, "done", NewObj(1).Put("prop", Fn((V _self1, int _argc973, V I_979, V tt_980, V _a977, V _a978, V[] _rest974) => {
V hd_981 = default;
V k_982 = default;
hd_981 = Get(Get(I_979, "W"), "head");
if (!(Truthy(hd_981))) {
return ((V)(""));
}
k_982 = Call(SM_11, V.Undef, ((V)((ToNum(tt_980) / 300D))));
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(r2_10, V.Undef, GetIdx(hd_981, 0D))).S(" ").V(Call(r2_10, V.Undef, Add(GetIdx(hd_981, 1D), ((V)(3D))))).S(") scale(").V(Call(r2_10, V.Undef, k_982)).S(")\"><path d=\"M-17 6 Q-18 -6 0 -7 Q18 -6 17 6 Q8 2 0 3 Q-8 2 -17 6Z\" fill=\"#ffffff\" stroke=\"#e3d4f5\" stroke-width=\"0.6\"/><path d=\"M-12 1 Q0 -3 12 1 M-14 4 Q0 0 14 4\" stroke=\"#efe6fb\" stroke-width=\"0.8\" fill=\"none\"/><path d=\"M14 -1 Q22 -6 19 4 Q16 5 14 3Z\" fill=\"#ffffff\" stroke=\"#e3d4f5\" stroke-width=\"0.6\"/></g>").End()));
return default;
}, 2, "prop", true)).V);
return default;
}, 0, "", true), V.Undef)));
SOAPCFG_42 = NewObj(10).Put("belly", Arr(((V)(18D)), ((V)(300D)), ((V)(2600D)), ((V)((-900D))))).Put("shampoo", Arr(((V)(14D)), ((V)(300D)), ((V)(3000D)), ((V)((-1500D))))).Put("face", Arr(((V)(12D)), ((V)(200D)), ((V)(2200D)), ((V)((-1600D))))).Put("back", Arr(((V)(18D)), ((V)(300D)), ((V)(2800D)), ((V)((-900D))))).Put("splash", Arr(((V)(10D)), ((V)(200D)), ((V)(2000D)), ((V)((-700D))))).Put("duck", Arr(((V)(12D)), ((V)(200D)), ((V)(2600D)), ((V)((-700D))))).Put("bubbles", Arr(((V)(9D)), ((V)(200D)), ((V)(2600D)), ((V)((-800D))))).Put("shake", Arr(((V)(20D)), ((V)(0D)), ((V)(1D)), ((V)(400D)), ((V)(1100D)))).Put("ears", Arr(((V)(14D)), ((V)(200D)), ((V)(2600D)), ((V)((-1100D))))).Put("soak", Arr(((V)(8D)), ((V)(300D)), ((V)(2500D)), ((V)((-1000D))))).V;
Invoke(Object_keys(B_37), "forEach", Fn((V _self1, int _argc983, V k_989, V _a986, V _a987, V _a988, V[] _rest984) => {
V st_990 = default;
V c_991 = default;
st_990 = GetIdx(GetK(B_37, k_989), 2D);
c_991 = GetK(SOAPCFG_42, k_989);
if (Truthy(c_991)) {
V r_992 = default;
r_992 = (LtN(GetIdx(c_991, 3D), 0D) ? Add(Get(st_990, "dur"), GetIdx(c_991, 3D)) : GetIdx(c_991, 3D));
Set(st_990, "fx", Call(fxs_38, V.Undef, Get(st_990, "fx"), Call(soapFx_40, V.Undef, GetIdx(c_991, 0D), GetIdx(c_991, 1D), GetIdx(c_991, 2D), r_992, GetIdx(c_991, 4D))));
}
SetK(ST_18, ((V)(JsStrBuf.Begin().S("bath_").V(k_989).End())), st_990);
return default;
}, 1, "", true));
Set(ST_18, "poke_head", Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(80D)), NewObj(5).Put("sq", ((V)(0.26))).Put("sqz", ((V)(1D))).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).Put("pitch", ((V)((-0.3)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)((-0.1)))).Put("pitch", ((V)(0.1))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.04))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(7).Put("sq", ((V)(0D))).Put("sqz", ((V)(0D))).Put("frown", ((V)(0.5))).Put("puff", ((V)(0.35))).Put("ly", ((V)((-0.9)))).Put("earL", ((V)(4D))).Put("earR", ((V)(4D))).V, ((V)("io"))), "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)((-30D)))), NewObj(1).Put("armR", ((V)(25D))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("hRx", ((V)((-4D)))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("hRx", ((V)(4D))).Put("htilt", ((V)((-3D)))).V, ((V)("s"))), "to", ((V)(350D)), NewObj(8).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("armR", ((V)(0D))).Put("frown", ((V)(0D))).Put("puff", ((V)(0D))).Put("smile", ((V)(0.4))).Put("ly", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io"))), "rest", ((V)(350D))), "done", NewObj(1).Put("tap", Arr(((V)(50D)), ((V)(24D)))).V));
pokeEar_43 = Fn((V _self1, int _argc993, V s_999, V _a996, V _a997, V _a998, V[] _rest994) => {
V k_1000 = default;
k_1000 = Call(S_14, V.Undef, s_999);
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(70D)), NewObj(3).PutK(Get(k_1000, "ear"), ((V)((-22D)))).PutK(Get(k_1000, "wink"), ((V)(1D))).Put("htilt", ((V)((ToNum(s_999) * 5D)))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(1).PutK(Get(k_1000, "ear"), ((V)(14D))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(1).PutK(Get(k_1000, "ear"), ((V)((-10D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).PutK(Get(k_1000, "ear"), ((V)(6D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).PutK(Get(k_1000, "ear"), ((V)(0D))).PutK(Get(k_1000, "wink"), ((V)(0D))).V, ((V)("io"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("turn", ((V)(0.3))).Put("htilt", ((V)((-4D)))).V, NewObj(2).Put("turn", ((V)((-0.3)))).Put("htilt", ((V)(4D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(4).Put("turn", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(3D)), NewObj(1).Put("sq", ((V)(0.05))).V, NewObj(1).Put("sq", ((V)(0D))).V), "rest", ((V)(350D))), "done", NewObj(1).Put("tap", Arr(((V)((LtN(s_999, 0D) ? 28D : 72D))), ((V)(16D)))).V);
return default;
}, 1, "", true);
Set(ST_18, "poke_earL", Call(pokeEar_43, V.Undef, ((V)((-1D)))));
Set(ST_18, "poke_earR", Call(pokeEar_43, V.Undef, ((V)(1D))));
Set(ST_18, "poke_nose", Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(250D)), NewObj(4).Put("cross", ((V)(1D))).Put("ly", ((V)(0.7))).Put("pitch", ((V)((-0.1)))).Put("wide", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(450D))), "to", ((V)(300D)), NewObj(9).Put("cross", ((V)(0D))).Put("ly", ((V)(0D))).Put("wide", ((V)(0D))).Put("pitch", ((V)(0.35))).Put("open", ((V)(0.4))).Put("close", ((V)(0.6))).Put("sq", ((V)((-0.08)))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(3).Put("pitch", ((V)(0.25))).Put("open", ((V)(0.3))).Put("sq", ((V)((-0.04)))).V), "to", ((V)(260D)), NewObj(4).Put("pitch", ((V)(0.5))).Put("open", ((V)(0.55))).Put("close", ((V)(0.8))).Put("sq", ((V)((-0.12)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(8).Put("pitch", ((V)((-0.55)))).Put("open", ((V)(0.9))).Put("sqz", ((V)(1D))).Put("close", ((V)(0D))).Put("sq", ((V)(0.22))).Put("lean", ((V)(0.5))).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("sneeze")), ((V)("nose"))), "to", ((V)(260D)), NewObj(6).Put("pitch", ((V)((-0.1)))).Put("open", ((V)(0.1))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("sqz", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-18D))))), ((V)("io"))), "osc", ((V)(450D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-15D)))).V, NewObj(1).Put("hRx", ((V)((-11D)))).V), "to", ((V)(300D)), NewObj(4).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(0.6))).V, ((V)("io"))), "osc", ((V)(400D)), ((V)(2D)), NewObj(1).Put("turn", ((V)(0.2))).V, NewObj(1).Put("turn", ((V)((-0.2)))).V), "rest", ((V)(350D))), "done", NewObj(1).Put("tap", Arr(((V)(50D)), ((V)(54D)))).V));
pokeEye_44 = Fn((V _self1, int _argc1001, V s_1007, V _a1004, V _a1005, V _a1006, V[] _rest1002) => {
V k_1008 = default;
k_1008 = Call(S_14, V.Undef, s_1007);
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(60D)), NewObj(5).PutK(Get(k_1008, "wink"), ((V)(1D))).Put("pitch", ((V)(0.2))).Put("lean", ((V)(((-ToNum(s_1007)) * 2.5)))).Put("htilt", ((V)(((-ToNum(s_1007)) * 5D)))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, s_1007, ((V)(6D)), ((V)((-27D))))), ((V)("io"))), "osc", ((V)(700D)), ((V)(3D)), NewObj(2).PutK(Get(k_1008, "hy"), ((V)((-29D)))).PutK(Get(k_1008, "hx"), ((V)((LtN(s_1007, 0D) ? 4D : (-4D))))).V, NewObj(2).PutK(Get(k_1008, "hy"), ((V)((-25D)))).PutK(Get(k_1008, "hx"), ((V)((LtN(s_1007, 0D) ? 7D : (-7D))))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(5).PutK(Get(k_1008, "hx"), ((V)(0D))).PutK(Get(k_1008, "hy"), ((V)(0D))).Put("pitch", ((V)(0D))).Put("lean", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).PutK(Get(k_1008, "wink"), ((V)(0D))).V), "e", ((V)("blink2"))), "to", ((V)(300D)), NewObj(1).Put("frown", ((V)(0.4))).V), "rest", ((V)(400D))), "done", NewObj(1).Put("tap", Arr(((V)((LtN(s_1007, 0D) ? 38D : 62D))), ((V)(47D)))).V);
return default;
}, 1, "", true);
Set(ST_18, "poke_eyeL", Call(pokeEye_44, V.Undef, ((V)((-1D)))));
Set(ST_18, "poke_eyeR", Call(pokeEye_44, V.Undef, ((V)(1D))));
pokeCheek_45 = Fn((V _self1, int _argc1009, V s_1015, V _a1012, V _a1013, V _a1014, V[] _rest1010) => {
V k_1016 = default;
k_1016 = Call(S_14, V.Undef, s_1015);
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(90D)), NewObj(4).Put("htilt", ((V)(((-ToNum(s_1015)) * 9D)))).Put("lean", ((V)(((-ToNum(s_1015)) * 2D)))).PutK(Get(k_1016, "wink"), ((V)(0.8))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(250D)), NewObj(5).Put("blush", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, s_1015, ((V)(2D)), ((V)((-18D))))), ((V)("io"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("sq", ((V)(0.05))).Put("htilt", ((V)(((-ToNum(s_1015)) * 7D)))).V, NewObj(2).Put("sq", ((V)(0D))).Put("htilt", ((V)(((-ToNum(s_1015)) * 10D)))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(6).PutK(Get(k_1016, "hx"), ((V)(0D))).PutK(Get(k_1016, "hy"), ((V)(0D))).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).PutK(Get(k_1016, "wink"), ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "rest", ((V)(500D))), "done", NewObj(1).Put("tap", Arr(((V)((LtN(s_1015, 0D) ? 33D : 67D))), ((V)(58D)))).V);
return default;
}, 1, "", true);
Set(ST_18, "poke_cheekL", Call(pokeCheek_45, V.Undef, ((V)((-1D)))));
Set(ST_18, "poke_cheekR", Call(pokeCheek_45, V.Undef, ((V)(1D))));
Set(ST_18, "poke_belly", Call(Fn((V _self1, int _argc1017, V _a1019, V _a1020, V _a1021, V _a1022, V[] _rest1018) => {
V t_1023 = default;
V a_1024 = default;
V b_1025 = default;
t_1023 = Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(90D)), NewObj(3).Put("sq", ((V)(0.14))).Put("pitch", ((V)((-0.3)))).Put("sqz", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(250D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(9D)), ((V)(0D))), NewObj(4).Put("hap", ((V)(1D))).Put("sqz", ((V)(0D))).Put("open", ((V)(0.65))).Put("smile", ((V)(1D))).V), ((V)("io")));
a_1024 = Get(t_1023, "t");
Invoke(t_1023, "osc", ((V)(1400D)), ((V)(7D)), NewObj(3).Put("sq", ((V)(0.12))).Put("lift", ((V)(0D))).Put("htilt", ((V)(4D))).V, NewObj(3).Put("sq", ((V)(0.02))).Put("lift", ((V)(1.5))).Put("htilt", ((V)((-4D)))).V, ((V)("io")));
b_1025 = Get(t_1023, "t");
Invoke(Invoke(Invoke(t_1023, "at", a_1024), "osc", ((V)(1400D)), ((V)(5D)), NewObj(1).Put("wag", ((V)(22D))).V, NewObj(1).Put("wag", ((V)((-22D)))).V), "at", b_1025);
return Invoke(Invoke(Invoke(Invoke(t_1023, "to", ((V)(400D)), NewObj(10).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("open", ((V)(0.2))).Put("lift", ((V)(0D))).Put("htilt", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("sq", ((V)((-0.04)))).Put("pitch", ((V)(0.15))).V), "rest", ((V)(400D))), "done", NewObj(1).Put("tap", Arr(((V)(50D)), ((V)(82D)))).V);
return default;
}, 0, "", true), V.Undef));
pokeSide_46 = Fn((V _self1, int _argc1026, V s_1032, V _a1029, V _a1030, V _a1031, V[] _rest1027) => {
V k_1033 = default;
V j_1034 = default;
double d_1035 = 0;
k_1033 = Call(S_14, V.Undef, s_1032);
j_1034 = Call(S_14, V.Undef, ((V)((-ToNum(s_1032)))));
d_1035 = (-ToNum(s_1032));
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(90D)), NewObj(8).Put("x", ((V)((d_1035 * 3D)))).Put("lean", ((V)((d_1035 * 4D)))).Put("tilt", ((V)((d_1035 * 8D)))).Put("sq", ((V)(0.06))).Put("wide", ((V)(0.8))).PutK(Get(k_1033, "foot"), ((V)(3D))).PutK(Get(j_1034, "arm"), ((V)(60D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(250D)), NewObj(4).Put("x", ((V)((d_1035 * 6D)))).Put("tilt", ((V)((d_1035 * 10D)))).Put("lean", ((V)((d_1035 * 3D)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(4).Put("lift", ((V)(0D))).Put("tilt", ((V)((d_1035 * 2D)))).Put("sq", ((V)(0.08))).PutK(Get(k_1033, "foot"), ((V)(0D))).V, ((V)("i"))), "to", ((V)(220D)), NewObj(3).Put("tilt", ((V)(((-d_1035) * 2D)))).Put("sq", ((V)(0D))).PutK(Get(j_1034, "arm"), ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(8).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("lx", ((V)((ToNum(s_1032) * 0.9)))).Put("turn", ((V)((ToNum(s_1032) * 0.3)))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("frown", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, s_1032, ((V)((-3D))), ((V)((-2D))))), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).PutK(Get(k_1033, "hy"), ((V)((-4D)))).V, NewObj(1).PutK(Get(k_1033, "hy"), ((V)(0D))).V), "rest", ((V)(400D))), "done", NewObj(1).Put("tap", Arr(((V)((LtN(s_1032, 0D) ? 30D : 70D))), ((V)(78D)))).V);
return default;
}, 1, "", true);
Set(ST_18, "poke_sideL", Call(pokeSide_46, V.Undef, ((V)((-1D)))));
Set(ST_18, "poke_sideR", Call(pokeSide_46, V.Undef, ((V)(1D))));
pokeFoot_47 = Fn((V _self1, int _argc1036, V s_1042, V _a1039, V _a1040, V _a1041, V[] _rest1037) => {
V k_1043 = default;
V j_1044 = default;
k_1043 = Call(S_14, V.Undef, s_1042);
j_1044 = Call(S_14, V.Undef, ((V)((-ToNum(s_1042)))));
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(80D)), NewObj(3).Put("sq", ((V)(0.08))).Put("wide", ((V)(1D))).PutK(Get(k_1043, "foot"), ((V)(2D))).V, ((V)("o"))), "to", ((V)(250D)), NewObj(7).Put("lift", ((V)(8D))).Put("sq", ((V)((-0.14)))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).Put("open", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(250D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.2))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(7).Put("sq", ((V)(0D))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("open", ((V)(0.2))).Put("wide", ((V)(0.3))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(5).PutK(Get(k_1043, "foot"), ((V)(4D))).PutK(Get(j_1044, "foot"), ((V)(0D))).Put("tilt", ((V)(((-ToNum(s_1042)) * 3D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, NewObj(3).PutK(Get(k_1043, "foot"), ((V)(0D))).PutK(Get(j_1044, "foot"), ((V)(4D))).Put("tilt", ((V)((ToNum(s_1042) * 3D)))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(3).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("tilt", ((V)(0D))).V), "rest", ((V)(400D))), "done", NewObj(1).Put("tap", Arr(((V)((LtN(s_1042, 0D) ? 38D : 62D))), ((V)(91D)))).V);
return default;
}, 1, "", true);
Set(ST_18, "poke_footL", Call(pokeFoot_47, V.Undef, ((V)((-1D)))));
Set(ST_18, "poke_footR", Call(pokeFoot_47, V.Undef, ((V)(1D))));
Set(ST_18, "poke_tail", Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(80D)), NewObj(3).Put("sq", ((V)(0.1))).Put("wide", ((V)(1D))).Put("curl", ((V)(0.9))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(4).Put("lift", ((V)(6D))).Put("sq", ((V)((-0.12)))).Put("wag", ((V)(30D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.15))).V, ((V)("i"))), "to", ((V)(150D)), NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V), "to", ((V)(500D)), NewObj(5).Put("spin", ((V)(50D))).Put("turn", ((V)(0.7))).Put("lx", ((V)(1D))).Put("ly", ((V)(0.4))).Put("wide", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(25D))).V, NewObj(1).Put("wag", ((V)((-25D)))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("frown", ((V)(0.5))).Put("puff", ((V)(0.4))).V), "wait", ((V)(300D))), "to", ((V)(500D)), NewObj(8).Put("spin", ((V)(0D))).Put("turn", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("curl", ((V)(0D))).Put("wag", ((V)(0D))).Put("puff", ((V)(0D))).Put("frown", ((V)(0D))).V, ((V)("io"))), "rest", ((V)(400D))), "done", NewObj(1).Put("tap", Arr(((V)(86D)), ((V)(70D)))).V));
Set(ST_18, "poke", NewObj(2).Put("seq", Arr(((V)("poke_head")), ((V)("poke_earL")), ((V)("poke_nose")), ((V)("poke_cheekR")), ((V)("poke_eyeL")), ((V)("poke_belly")), ((V)("poke_sideL")), ((V)("poke_sideR")), ((V)("poke_footL")), ((V)("poke_tail")), ((V)("poke_earR")), ((V)("poke_cheekL")), ((V)("poke_eyeR")), ((V)("poke_footR")))).Put("k", NewObj(0).V).V);
Set(ST_18, "cry", Call(Fn((V _self1, int _argc1045, V _a1047, V _a1048, V _a1049, V _a1050, V[] _rest1046) => {
V t_1051 = default;
V a_1052 = default;
V b_1053 = default;
t_1051 = Invoke(Call(TL_13, V.Undef), "to", ((V)(700D)), NewObj(11).Put("pitch", ((V)((-0.4)))).Put("ly", ((V)(0.6))).Put("frown", ((V)(0.85))).Put("teary", ((V)(1D))).Put("earL", ((V)(24D))).Put("earR", ((V)(24D))).Put("sl", ((V)(1D))).Put("sq", ((V)(0.06))).Put("curl", ((V)((-0.6)))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).V, ((V)("io")));
a_1052 = Get(t_1051, "t");
Invoke(t_1051, "osc", ((V)(5600D)), ((V)(28D)), NewObj(2).Put("frown", ((V)(1D))).Put("open", ((V)(0.05))).V, NewObj(2).Put("frown", ((V)(0.75))).Put("open", ((V)(0D))).V, ((V)("s")));
b_1053 = Get(t_1051, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1051, "at", Add(a_1052, ((V)(600D)))), "e", ((V)("emit")), ((V)("tear")), ((V)("eyeL"))), "at", Add(a_1052, ((V)(1500D)))), "e", ((V)("emit")), ((V)("tear")), ((V)("eyeR"))), "at", Add(a_1052, ((V)(2900D)))), "e", ((V)("emit")), ((V)("tear")), ((V)("eyeL"))), "at", Add(a_1052, ((V)(4000D)))), "e", ((V)("emit")), ((V)("tear")), ((V)("eyeR"))), "at", Add(a_1052, ((V)(4900D)))), "e", ((V)("emit")), ((V)("tear")), ((V)("eyeL")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_1051, "at", Add(a_1052, ((V)(1800D)))), "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0.02))).Put("pitch", ((V)((-0.25)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.4)))).V), "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0.02))).Put("pitch", ((V)((-0.27)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.4)))).V);
Invoke(Invoke(Invoke(Invoke(t_1051, "at", Add(a_1052, ((V)(3000D)))), "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-27D)))), NewObj(1).Put("htilt", ((V)(4D))).V), ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(2).Put("hRy", ((V)((-29D)))).Put("hRx", ((V)((-4D)))).V, NewObj(2).Put("hRy", ((V)((-25D)))).Put("hRx", ((V)((-7D)))).V, ((V)("s"))), "to", ((V)(350D)), NewObj(3).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_1051, "at", Add(a_1052, ((V)(4500D)))), "to", ((V)(500D)), NewObj(2).Put("sq", ((V)((-0.03)))).Put("pitch", ((V)((-0.2)))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(2).Put("sq", ((V)(0.08))).Put("pitch", ((V)((-0.45)))).V, ((V)("io"))), "at", b_1053);
return Invoke(Invoke(t_1051, "rest", ((V)(600D))), "done");
return default;
}, 0, "", true), V.Undef));
Set(ST_18, "sob", Call(Fn((V _self1, int _argc1054, V _a1056, V _a1057, V _a1058, V _a1059, V[] _rest1055) => {
V t_1060 = default;
V a_1061 = default;
V b_1062 = default;
V c_1063 = default;
V d_1064 = default;
t_1060 = Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(300D)), NewObj(6).Put("frown", ((V)(1D))).Put("teary", ((V)(1D))).Put("pitch", ((V)((-0.2)))).Put("sq", ((V)(0.05))).Put("earL", ((V)(18D))).Put("earR", ((V)(18D))).V, ((V)("io"))), "osc", ((V)(400D)), ((V)(4D)), NewObj(1).Put("open", ((V)(0.1))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("l"))), "to", ((V)(260D)), NewObj(7).Put("pitch", ((V)(0.5))).Put("open", ((V)(0.85))).Put("mw", ((V)(1.25))).Put("sqz", ((V)(1D))).Put("earL", ((V)(22D))).Put("earR", ((V)(22D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "em", ((V)(2600D)), ((V)(90D)), ((V)("gush")), ((V)("eyeL")), ((V)(1D))), "em", ((V)(2600D)), ((V)(90D)), ((V)("gush")), ((V)("eyeR")), ((V)(1D)));
a_1061 = Get(t_1060, "t");
Invoke(t_1060, "osc", ((V)(2600D)), ((V)(13D)), NewObj(3).Put("sq", ((V)(0.12))).Put("lift", ((V)(0D))).Put("x", ((V)(0.5))).V, NewObj(3).Put("sq", ((V)(0D))).Put("lift", ((V)(1.2))).Put("x", ((V)((-0.5)))).V, ((V)("io")));
b_1062 = Get(t_1060, "t");
Invoke(Invoke(Invoke(t_1060, "at", a_1061), "osc", ((V)(2600D)), ((V)(5D)), NewObj(3).Put("armL", ((V)(100D))).Put("armR", ((V)(40D))).Put("htilt", ((V)(4D))).V, NewObj(3).Put("armL", ((V)(40D))).Put("armR", ((V)(100D))).Put("htilt", ((V)((-4D)))).V, ((V)("io"))), "at", b_1062);
Invoke(Invoke(Invoke(Invoke(Invoke(t_1060, "to", ((V)(400D)), NewObj(9).Put("open", ((V)(0.3))).Put("mw", ((V)(0.9))).Put("pitch", ((V)(0.1))).Put("sq", ((V)((-0.08)))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("x", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.02))).V), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)((-27D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-27D)))), NewObj(4).Put("pitch", ((V)(0.3))).Put("open", ((V)(0.8))).Put("mw", ((V)(1.1))).Put("sqz", ((V)(1D))).V), ((V)("io"))), "em", ((V)(2000D)), ((V)(110D)), ((V)("gush")), ((V)("eyeL")), ((V)(1D))), "em", ((V)(2000D)), ((V)(110D)), ((V)("gush")), ((V)("eyeR")), ((V)(1D)));
c_1063 = Get(t_1060, "t");
Invoke(t_1060, "osc", ((V)(2000D)), ((V)(8D)), NewObj(3).Put("hLy", ((V)((-29D)))).Put("hRy", ((V)((-25D)))).Put("sq", ((V)(0.1))).V, NewObj(3).Put("hLy", ((V)((-25D)))).Put("hRy", ((V)((-29D)))).Put("sq", ((V)(0D))).V, ((V)("s")));
d_1064 = Get(t_1060, "t");
Invoke(Invoke(Invoke(t_1060, "at", c_1063), "osc", ((V)(2000D)), ((V)(10D)), NewObj(2).Put("lift", ((V)(1D))).Put("x", ((V)(0.4))).V, NewObj(2).Put("lift", ((V)(0D))).Put("x", ((V)((-0.4)))).V, ((V)("io"))), "at", d_1064);
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1060, "to", ((V)(400D)), NewObj(10).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("open", ((V)(0.1))).Put("mw", ((V)(1D))).Put("sqz", ((V)(0.2))).Put("pitch", ((V)((-0.2)))).Put("x", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("sq", ((V)(0.05))).Put("pitch", ((V)((-0.1)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V), "to", ((V)(500D)), NewObj(5).Put("teary", ((V)(0.6))).Put("sqz", ((V)(0D))).Put("frown", ((V)(0.8))).Put("earL", ((V)(20D))).Put("earR", ((V)(20D))).V), "rest", ((V)(600D))), "done");
return default;
}, 0, "", true), V.Undef));
Set(ST_18, "stinky", Call(Fn((V _self1, int _argc1065, V _a1067, V _a1068, V _a1069, V _a1070, V[] _rest1066) => {
V t_1071 = default;
V a_1072 = default;
V b_1073 = default;
V L_1074 = default;
t_1071 = Call(TL_13, V.Undef);
Invoke(Invoke(Invoke(t_1071, "to", ((V)(450D)), NewObj(7).Put("armR", ((V)(120D))).Put("hRy", ((V)((-3D)))).Put("turn", ((V)(0.6))).Put("pitch", ((V)((-0.25)))).Put("lx", ((V)(1D))).Put("ly", ((V)(0.5))).Put("lean", ((V)(0.8))).V, ((V)("io"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(14).Put("lean", ((V)((-3D)))).Put("tilt", ((V)((-4D)))).Put("wide", ((V)(1D))).Put("tongue", ((V)(1D))).Put("open", ((V)(0.3))).Put("sqz", ((V)(0.7))).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).Put("armR", ((V)(0D))).Put("hRy", ((V)(0D))).Put("turn", ((V)((-0.2)))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0.15))).V, ((V)("o")));
a_1072 = Get(t_1071, "t");
Invoke(t_1071, "wait", ((V)(700D)));
b_1073 = Get(t_1071, "t");
Invoke(Invoke(Invoke(t_1071, "at", a_1072), "osc", ((V)(700D)), ((V)(7D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "at", b_1073);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1071, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-16D)))), NewObj(12).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("wide", ((V)(0D))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("sqz", ((V)(0D))).Put("frown", ((V)(0.6))).Put("puff", ((V)(0.3))).Put("earL", ((V)(8D))).Put("earR", ((V)(8D))).Put("pitch", ((V)(0D))).Put("turn", ((V)(0D))).V), ((V)("io"))), "osc", ((V)(1300D)), ((V)(5D)), NewObj(1).Put("hRx", ((V)((-16D)))).V, NewObj(1).Put("hRx", ((V)((-9D)))).V, ((V)("io"))), "to", ((V)(350D)), NewObj(7).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("puff", ((V)(0D))).Put("frown", ((V)(0.2))).Put("blush", ((V)(1D))).Put("smile", ((V)(0.35))).Put("htilt", ((V)(6D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sweat")), Arr(((V)(67D)), ((V)(26D)))), "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)((-30D)))), NewObj(1).Put("armR", ((V)(25D))).V), ((V)("io"))), "osc", ((V)(800D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-4D)))).V, NewObj(1).Put("hRx", ((V)(4D))).V, ((V)("s"))), "to", ((V)(350D)), NewObj(5).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("blush", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(6).Put("armL", ((V)(120D))).Put("hLy", ((V)((-3D)))).Put("turn", ((V)((-0.6)))).Put("pitch", ((V)((-0.25)))).Put("lx", ((V)((-1D)))).Put("ly", ((V)(0.5))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(11).Put("armL", ((V)(0D))).Put("hLy", ((V)(0D))).Put("turn", ((V)(0D))).Put("pitch", ((V)((-0.15)))).Put("lx", ((V)(0D))).Put("ly", ((V)(0.3))).Put("earL", ((V)(22D))).Put("earR", ((V)(22D))).Put("sl", ((V)(1D))).Put("frown", ((V)(0.8))).Put("smile", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(500D))), "rest", ((V)(600D)));
L_1074 = Invoke(t_1071, "loop", NewObj(1).Put("emit", Arr(Arr(((V)(0D)), ((V)(1000000000D)), ((V)(280D)), ((V)("stink")), ((V)("body")), ((V)(1D))), Arr(((V)(140D)), ((V)(1000000000D)), ((V)(560D)), ((V)("stink")), ((V)("head")), ((V)(1D))), Arr(((V)(0D)), ((V)(1000000000D)), ((V)(900D)), ((V)("stink")), ((V)("sideL")), ((V)(1D))), Arr(((V)(450D)), ((V)(1000000000D)), ((V)(900D)), ((V)("stink")), ((V)("sideR")), ((V)(1D))))).V);
Set(Get(L_1074, "k"), "green", Arr(Arr(((V)(0D)), ((V)(0.75)))));
Set(L_1074, "fx", Fn((V _self1, int _argc1075, V I_1081, V tt_1082, V _a1079, V _a1080, V[] _rest1076) => {
V c_1083 = default;
JsStrBuf h_1084 = null;
c_1083 = (Get(Get(I_1081, "W"), "body") is var _t1085 && Truthy(_t1085) ? _t1085 : Arr(((V)(50D)), ((V)(78D))));
h_1084 = new JsStrBuf("");
{
double i_1086 = 0;
i_1086 = 0D;
while (true) {
if (!((i_1086 < 2D))) break;
double a_1088 = 0;
V x_1089 = default;
double y_1090 = 0;
double fl_1091 = 0;
a_1088 = ((ToNum(tt_1082) / (520D + (i_1086 * 140D))) + (i_1086 * System.Math.PI));
x_1089 = Add(GetIdx(c_1083, 0D), ((V)((FdLibm.Cos(a_1088) * (26D - (i_1086 * 4D))))));
y_1090 = ((ToNum(GetIdx(c_1083, 1D)) - 18D) + (FdLibm.Sin((a_1088 * 1.3)) * 12D));
fl_1091 = (FdLibm.Sin(((ToNum(tt_1082) / 18D) + i_1086)) * 0.6);
h_1084.S("<g transform=\"translate(").V(Call(r2_10, V.Undef, x_1089)).S(" ").V(Call(r2_10, V.Undef, ((V)(y_1090)))).S(")\"><ellipse cx=\"-0.8\" cy=\"-1\" rx=\"1.1\" ry=\"").V(Call(r2_10, V.Undef, ((V)((0.5 + (fl_1091 * 0.4)))))).S("\" fill=\"#ffffff\" opacity=\"0.8\"/><ellipse cx=\"0.8\" cy=\"-1\" rx=\"1.1\" ry=\"").V(Call(r2_10, V.Undef, ((V)((0.5 - (fl_1091 * 0.4)))))).S("\" fill=\"#ffffff\" opacity=\"0.8\"/><circle r=\"0.95\" fill=\"#2a1a30\"/></g>");
i_1086++;
}
}
return ((V)(h_1084.Str));
return default;
}, 2, "", true));
return L_1074;
return default;
}, 0, "", true), V.Undef));
whip_48 = Fn((V _self1, int _argc1092, V t_1098, V dir_1099, V chain_1100, V _a1097, V[] _rest1093) => {
V d_1101 = default;
double ld_1102 = 0;
V A_1103 = default;
V B_1104 = default;
V FT_1105 = default;
d_1101 = (dir_1099 is var _t1106 && Truthy(_t1106) ? _t1106 : ((V)(1D)));
ld_1102 = (GtN(d_1101, 0D) ? 1D : (-1D));
A_1103 = Get(Call(S_14, V.Undef, ((V)(ld_1102))), "arm");
B_1104 = Get(Call(S_14, V.Undef, ((V)((-ld_1102)))), "arm");
FT_1105 = Get(Call(S_14, V.Undef, ((V)(ld_1102))), "foot");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1098, "to", ((V)(75D)), Call(o_17, V.Undef, NewObj(9).Put("lx", ((V)((0.9 * ToNum(d_1101))))).Put("htilt", ((V)((3D * ToNum(d_1101))))).Put("sq", ((V)((-0.03)))).PutK(A_1103, ((V)(6D))).PutK(B_1104, ((V)(6D))).Put("earL", ((V)((-3D)))).Put("earR", ((V)((-3D)))).Put("hap", ((V)(0.2))).Put("open", ((V)(0D))).V), ((V)("io"))), "to", ((V)(155D)), Call(o_17, V.Undef, NewObj(15).Put("sq", ((V)(0.14))).Put("spin", ((V)(((-32D) * ToNum(d_1101))))).Put("turn", ((V)(((-0.12) * ToNum(d_1101))))).Put("hyaw", ((V)((0.55 * ToNum(d_1101))))).Put("tilt", ((V)(((-3D) * ToNum(d_1101))))).Put("lean", ((V)(((-1D) * ToNum(d_1101))))).Put("htilt", ((V)((7D * ToNum(d_1101))))).Put("lx", d_1101).PutK(B_1104, ((V)(70D))).PutK(A_1103, ((V)((-6D)))).Put("close", ((V)(0.2))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).Put("wag", ((V)((14D * ToNum(d_1101))))).Put("hap", ((V)(0.35))).V, Call(hand_15, V.Undef, ((V)(ld_1102)), ((V)(7D)), ((V)((-2D))), ((V)(5D)))), ((V)("o"))), "to", ((V)(100D)), NewObj(4).Put("sq", ((V)(0.16))).Put("spin", ((V)(((-36D) * ToNum(d_1101))))).Put("htilt", ((V)((8D * ToNum(d_1101))))).PutK(B_1104, ((V)(76D))).V, ((V)("io"))), "to", ((V)(50D)), Call(o_17, V.Undef, NewObj(15).Put("spin", ((V)((40D * ToNum(d_1101))))).Put("sblur", ((V)(0.5))).Put("sq", ((V)((-0.1)))).Put("turn", ((V)(0D))).Put("hyaw", ((V)((0.35 * ToNum(d_1101))))).Put("tilt", ((V)((4D * ToNum(d_1101))))).Put("lean", ((V)((0.6 * ToNum(d_1101))))).Put("htilt", ((V)((10D * ToNum(d_1101))))).Put("lx", ((V)((0.6 * ToNum(d_1101))))).PutK(B_1104, ((V)(125D))).PutK(A_1103, ((V)(30D))).Put("close", ((V)(0D))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).PutK(FT_1105, ((V)(8D))).V, Call(hand_15, V.Undef, ((V)(ld_1102)), ((V)(0D)), ((V)(2D)), ((V)(3D))), Call(hand_15, V.Undef, ((V)((-ld_1102))), ((V)(0D)), ((V)((-4D))), ((V)(3D)))), ((V)("l"))), "to", ((V)(180D)), NewObj(7).Put("spin", ((V)((378D * ToNum(d_1101))))).Put("sq", ((V)((-0.12)))).PutK(B_1104, ((V)(128D))).PutK(A_1103, ((V)(32D))).Put("earL", ((V)((-12D)))).Put("earR", ((V)((-12D)))).PutK(FT_1105, ((V)(9D))).V, ((V)("l"))), "to", ((V)(200D)), Call(o_17, V.Undef, NewObj(17).Put("spin", ((V)((360D * ToNum(d_1101))))).Put("sblur", ((V)(0D))).Put("sq", ((V)(0.12))).PutK(FT_1105, ((V)(0D))).Put("hyaw", ((V)(((-0.12) * ToNum(d_1101))))).Put("tilt", ((V)(((-2D) * ToNum(d_1101))))).Put("lean", ((V)(0D))).Put("htilt", ((V)(((-3D) * ToNum(d_1101))))).Put("lx", ((V)(0D))).PutK(A_1103, ((V)(115D))).PutK(B_1104, ((V)(40D))).Put("earL", ((V)(12D))).Put("earR", ((V)(12D))).Put("wag", ((V)(((-18D) * ToNum(d_1101))))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, Call(hand_15, V.Undef, ((V)(ld_1102)), ((V)(0D)), ((V)(0D)), ((V)(0D))), Call(hand_15, V.Undef, ((V)((-ld_1102))), ((V)(0D)), ((V)(0D)), ((V)(0D)))), ((V)("o"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
if (Truthy(chain_1100)) {
return t_1098;
}
Invoke(Invoke(Invoke(t_1098, "to", ((V)(150D)), NewObj(6).Put("sq", ((V)(0.06))).Put("hyaw", ((V)(0D))).Put("tilt", ((V)(((-0.6) * ToNum(d_1101))))).Put("htilt", ((V)(((-1D) * ToNum(d_1101))))).PutK(A_1103, ((V)(118D))).PutK(B_1104, ((V)(42D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(8).Put("sq", ((V)((-0.05)))).Put("tilt", ((V)((0.5 * ToNum(d_1101))))).Put("htilt", ((V)((1D * ToNum(d_1101))))).PutK(A_1103, ((V)(20D))).PutK(B_1104, ((V)(8D))).Put("earL", ((V)((-5D)))).Put("earR", ((V)((-5D)))).Put("wag", ((V)((8D * ToNum(d_1101))))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(9).Put("sq", ((V)(0D))).Put("tilt", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wag", ((V)(0D))).Put("hap", ((V)(0.6))).V, ((V)("io")));
return t_1098;
return default;
}, 3, "", true);
Set(ST_18, "spin@mittens", Call(Fn((V _self1, int _argc1107, V _a1109, V _a1110, V _a1111, V _a1112, V[] _rest1108) => {
V t_1113 = default;
t_1113 = Call(TL_13, V.Undef);
Invoke(t_1113, "wait", ((V)(150D)));
Call(whip_48, V.Undef, t_1113, ((V)(1D)), (true ? V.True : V.False));
Call(whip_48, V.Undef, t_1113, ((V)((-1D))));
return Invoke(Invoke(Invoke(t_1113, "wait", ((V)(300D))), "rest", ((V)(450D))), "done", NewObj(1).Put("whip", ((V)(1D))).V);
return default;
}, 0, "", true), V.Undef));
Invoke(R_8, "add", ST_18);
F_49 = Object_keys(FOODS_28);
Set(R_8, "GROUPS", Arr(NewObj(3).Put("name", ((V)("Idle"))).Put("where", ((V)("Plays by itself"))).Put("items", Arr(Arr(((V)("idle")), ((V)("Idle")), ((V)("Breathes and sways. Every few seconds she looks around, yawns or waves."))), Arr(((V)("idle_look")), ((V)("Look left and right")), ((V)("Eyes first, then the head turns in a small dipping arc with a blink; the chest follows a beat later, the weight shifts onto that side, ears and tail trail behind. Feet stay planted."))), Arr(((V)("idle_yawn")), ((V)("Yawn")), ((V)("Stretches both arms up, big yawn, smacks her lips."))), Arr(((V)("idle_waveL")), ((V)("Wave, left paw")), ((V)("Lifts her left paw and waves with a big smile."))), Arr(((V)("idle_waveR")), ((V)("Wave, right paw")), ((V)("Same with the right paw."))))).V, NewObj(3).Put("name", ((V)("Dance"))).Put("where", ((V)("10-second loop, repeats non-stop"))).Put("items", Arr(Arr(((V)("dance")), ((V)("Signature dance")), ((V)("Two-step, running man, the Woah, hop-spin, Billy Bounce."))))).V, NewObj(3).Put("name", ((V)("Poke"))).Put("where", ((V)("Tap anywhere on her"))).Put("items", Arr(Arr(((V)("poke")), ((V)("Every spot in turn")), ((V)("Plays all 14 reactions one after another."))), Arr(((V)("poke_head")), ((V)("Top of head")), ((V)("Bonk: squashes, eyes shut, rubs her head."))), Arr(((V)("poke_earL")), ((V)("Left ear")), ((V)("Ear flicks, head shakes, giggles."))), Arr(((V)("poke_earR")), ((V)("Right ear")), ((V)("Ear flicks, head shakes, giggles."))), Arr(((V)("poke_nose")), ((V)("Nose")), ((V)("Goes cross-eyed, then sneezes."))), Arr(((V)("poke_eyeL")), ((V)("Left eye")), ((V)("Flinches and rubs her eye."))), Arr(((V)("poke_eyeR")), ((V)("Right eye")), ((V)("Flinches and rubs her eye."))), Arr(((V)("poke_cheekL")), ((V)("Left cheek")), ((V)("Tilts away, blushes, giggles."))), Arr(((V)("poke_cheekR")), ((V)("Right cheek")), ((V)("Tilts away, blushes, giggles."))), Arr(((V)("poke_belly")), ((V)("Belly")), ((V)("Ticklish: curls up laughing."))), Arr(((V)("poke_sideL")), ((V)("Left side")), ((V)("Pushed off balance, hops back, rubs the spot."))), Arr(((V)("poke_sideR")), ((V)("Right side")), ((V)("Pushed off balance, hops back, rubs the spot."))), Arr(((V)("poke_footL")), ((V)("Left foot")), ((V)("Jumps, then hops foot to foot."))), Arr(((V)("poke_footR")), ((V)("Right foot")), ((V)("Jumps, then hops foot to foot."))), Arr(((V)("poke_tail")), ((V)("Tail")), ((V)("Jumps, turns to look at her tail, pouts."))))).V, NewObj(3).Put("name", ((V)("Eating"))).Put("where", ((V)("20 foods"))).Put("items", Invoke(F_49, "map", Fn((V _self1, int _argc1114, V k_1120, V _a1117, V _a1118, V _a1119, V[] _rest1115) => {
return Arr(((V)(JsStrBuf.Begin().S("eat_").V(k_1120).End())), Get(GetK(FOODS_28, k_1120), "label"), Get(GetK(FOODS_28, k_1120), "d"));
}, 1, "", true))).V, NewObj(3).Put("name", ((V)("Bathing"))).Put("where", ((V)("12 kinds, no tub drawn"))).Put("items", Invoke(Object_keys(B_37), "map", Fn((V _self1, int _argc1121, V k_1127, V _a1124, V _a1125, V _a1126, V[] _rest1122) => {
return Arr(((V)(JsStrBuf.Begin().S("bath_").V(k_1127).End())), GetIdx(GetK(B_37, k_1127), 0D), GetIdx(GetK(B_37, k_1127), 1D));
}, 1, "", true))).V, NewObj(3).Put("name", ((V)("Feelings"))).Put("where", ((V)("Game, Crib, reveal"))).Put("items", Arr(Arr(((V)("cry")), ((V)("Sad: quiet crying")), ((V)("Ears droop, teary eyes, lip wobbles, a few tears, wipes an eye."))), Arr(((V)("sob")), ((V)("Sad: heavy crying")), ((V)("Wails with tears gushing, sobs shake her body, rubs both eyes."))), Arr(((V)("stinky")), ((V)("Stinky")), ((V)("Needs a bath: stink lines, flies, sniffs herself, fans the smell. Loops."))), Arr(((V)("happy")), ((V)("Happy")), ((V)("Double bounce, arms up, tail wagging."))), Arr(((V)("surprised")), ((V)("Surprised")), ((V)("Jumps back wide-eyed, glances around."))), Arr(((V)("sleep")), ((V)("Sleepy and asleep")), ((V)("Yawns, nods off, breathes, wakes up."))))).V, NewObj(3).Put("name", ((V)("Moves"))).Put("where", ((V)("Crib and game"))).Put("items", Arr(Arr(((V)("look")), ((V)("Look around")), ((V)("Eyes first, head follows."))), Arr(((V)("squish")), ((V)("Squish")), ((V)("Pressed flat, springs back."))), Arr(((V)("spin")), ((V)("Spin around")), ((V)("Full 360\u00b0 turn."))), Arr(((V)("hop")), ((V)("Hop")), ((V)("Crouch, jump, squash landing."))))).V));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
