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
Call(Named(boot_198 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
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
Invoke(GetK(k_57, p_162), "sort", Fn((V _arrowThis171, int _argc163, V a_169, V b_170, V _a167, V _a168, V[] _rest164) => {
return ((V)((ToNum(GetIdx(a_169, 0D)) - ToNum(GetIdx(b_170, 0D)))));
}, 2, "", true));
}
}
Invoke(ev_58, "sort", Fn((V _arrowThis180, int _argc172, V a_178, V b_179, V _a176, V _a177, V[] _rest173) => {
return ((V)((ToNum(GetIdx(a_178, 0D)) - ToNum(GetIdx(b_179, 0D)))));
}, 2, "", true));
return Object_assign((Truthy(loop_160) ? NewObj(1).Put("loop", t_60).V : NewObj(1).Put("dur", t_60).V), NewObj(3).Put("k", k_57).Put("ev", ev_58).Put("emit", em_59).V, (x_159 is var _t181 && Truthy(_t181) ? _t181 : NewObj(0).V));
return default;
}, 2, "out", false)).Put("done", Fn((V _self182, int _argc183, V x_189, V _a186, V _a187, V _a188, V[] _rest184) => {
if (_self182.IsNullish) _self182 = GlobalV;
return Invoke(o_61, "out", x_189);
return default;
}, 1, "done", false)).Put("loop", Fn((V _self190, int _argc191, V x_197, V _a194, V _a195, V _a196, V[] _rest192) => {
if (_self190.IsNullish) _self190 = GlobalV;
return Invoke(o_61, "out", x_197, (true ? V.True : V.False));
return default;
}, 1, "loop", false)).V;
return o_61;
return default;
}, 0, "TL", false);
R_8 = Get(G("window"), "RiveRig");
if ((!(Truthy(R_8)) || !(Truthy(Get(R_8, "REST"))))) {
Call(G("setTimeout"), V.Undef, boot_198.v, ((V)(25D)));
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
S_14 = Fn((V _arrowThis206, int _argc199, V s_205, V _a202, V _a203, V _a204, V[] _rest200) => {
return (LtN(s_205, 0D) ? NewObj(9).Put("arm", ((V)("armL"))).Put("hx", ((V)("hLx"))).Put("hy", ((V)("hLy"))).Put("hz", ((V)("hLz"))).Put("ear", ((V)("earL"))).Put("wink", ((V)("winkL"))).Put("foot", ((V)("footL"))).Put("eye", ((V)("eyeL"))).Put("paw", ((V)("pawL"))).V : NewObj(9).Put("arm", ((V)("armR"))).Put("hx", ((V)("hRx"))).Put("hy", ((V)("hRy"))).Put("hz", ((V)("hRz"))).Put("ear", ((V)("earR"))).Put("wink", ((V)("winkR"))).Put("foot", ((V)("footR"))).Put("eye", ((V)("eyeR"))).Put("paw", ((V)("pawR"))).V);
}, 1, "", true);
hand_15 = Fn((V _arrowThis217, int _argc207, V s_213, V inX_214, V y_215, V z_216, V[] _rest208) => {
V k_218 = default;
V q_219 = default;
k_218 = Call(S_14, V.Undef, s_213);
q_219 = NewObj(2).PutK(Get(k_218, "hx"), (LtN(s_213, 0D) ? inX_214 : ((V)((-ToNum(inX_214)))))).PutK(Get(k_218, "hy"), y_215).V;
if (!z_216.IsNullish) {
SetK(q_219, Get(k_218, "hz"), z_216);
}
return q_219;
return default;
}, 4, "", true);
both_16 = Fn((V _arrowThis229, int _argc220, V inX_226, V y_227, V z_228, V _a225, V[] _rest221) => {
return Object_assign(Call(hand_15, V.Undef, ((V)((-1D))), inX_226, y_227, z_228), Call(hand_15, V.Undef, ((V)(1D)), inX_226, y_227, z_228));
}, 3, "", true);
o_17 = Fn((V _arrowThis237, int _argc230, V _a232, V _a233, V _a234, V _a235, V[] _rest231) => {
V a_236 = default;
a_236 = RestArgs(0, _argc230, _a232, _a233, _a234, _a235, _rest231);
return InvokeSpread(G("Object"), "assign", new ArrBuilder().Add(NewObj(0).V).Spread(a_236).V);
}, 1, "", true);
ST_18 = NewObj(0).V;
Set(ST_18, "idle_look", Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(240D)), NewObj(1).Put("lx", ((V)((-0.9)))).V, ((V)("o"))), "to", ((V)(520D)), NewObj(7).Put("spin", ((V)((-34D)))).Put("turn", ((V)((-0.4)))).Put("lean", ((V)((-1.4)))).Put("x", ((V)((-1.2)))).Put("footL", ((V)(2.2))).Put("htilt", ((V)((-2D)))).Put("wag", ((V)(10D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("footL", ((V)(0D))).Put("sq", ((V)(0.035))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(800D))), "e", ((V)("blink"))), "to", ((V)(240D)), NewObj(1).Put("lx", ((V)(0.9))).V, ((V)("o"))), "to", ((V)(700D)), NewObj(7).Put("spin", ((V)(34D))).Put("turn", ((V)(0.4))).Put("lean", ((V)(1.4))).Put("x", ((V)(1.2))).Put("footR", ((V)(2.2))).Put("htilt", ((V)(2D))).Put("wag", ((V)((-10D)))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("footR", ((V)(0D))).Put("sq", ((V)(0.035))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(800D))), "to", ((V)(220D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("o"))), "to", ((V)(560D)), NewObj(7).Put("spin", ((V)(0D))).Put("turn", ((V)(0D))).Put("lean", ((V)(0D))).Put("x", ((V)(0D))).Put("htilt", ((V)(0D))).Put("footL", ((V)(1.6))).Put("wag", ((V)(0D))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("footL", ((V)(0D))).Put("sq", ((V)(0.03))).V), "rest", ((V)(320D))), "done"));
{
V nat_238 = default;
nat_238 = Fn((V _arrowThis246, int _argc239, V k_245, V _a242, V _a243, V _a244, V[] _rest240) => {
V t_247 = default;
V turn_248 = default;
V e_249 = default;
t_247 = Call(TL_13, V.Undef);
turn_248 = Fn((V _arrowThis261, int _argc250, V T_256, V from_257, V to_258, V d1_259, V[] _rest251) => {
double s_262 = 0;
double dir_263 = 0;
double bendTo_264 = 0;
double twTo_265 = 0;
double wg_266 = 0;
V d2_260 = default;
d2_260 = (_argc250 > 4 ? _rest251[0] : V.Undef);
s_262 = Sign((ToNum(to_258) - ToNum(from_257)));
dir_263 = Sign(ToNum(to_258));
bendTo_264 = ((dir_263 * 4D) * ToNum(k_245));
twTo_265 = ((ToNum(to_258) * 0.36) * ToNum(k_245));
wg_266 = ((-s_262) * 14D);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_247, "at", T_256), "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((dir_263 * 0.9)))).V, ((V)("o"))), "e", ((V)("blink"))), "to", d1_259, NewObj(4).Put("hyaw", ((V)((ToNum(Add(from_257, to_258)) / 2D)))).Put("pitch", ((V)((-0.24)))).Put("earL", ((V)((s_262 * 8D)))).Put("earR", ((V)(((-s_262) * 8D)))).V, ((V)("i"))), "to", d2_260, NewObj(5).Put("hyaw", Add(to_258, ((V)((s_262 * 0.08))))).Put("pitch", ((V)(0.05))).Put("earL", ((V)(((-s_262) * 3D)))).Put("earR", ((V)((s_262 * 3D)))).Put("htilt", ((V)(((dir_263 * 3D) - bendTo_264)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("hyaw", to_258).Put("pitch", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_247, "at", Add(T_256, ((V)(200D)))), "to", Add(d1_259, d2_260), NewObj(4).Put("twist", ((V)((twTo_265 + ((s_262 * 0.06) * ToNum(k_245)))))).Put("turn", ((V)((ToNum(to_258) * 0.07)))).Put("bend", ((V)((bendTo_264 + ((s_262 * 1.2) * ToNum(k_245)))))).Put("wag", ((V)(wg_266))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(3).Put("twist", ((V)(twTo_265))).Put("bend", ((V)(bendTo_264))).Put("wag", ((V)((wg_266 * 0.4)))).V, ((V)("io")));
return Add(Add(Add(Add(T_256, ((V)(110D))), d1_259), d2_260), ((V)(320D)));
return default;
}, 5, "", true);
Invoke(t_247, "to", ((V)(1D)), NewObj(1).Put("lean", ((V)(0D))).V);
e_249 = Call(turn_248, V.Undef, ((V)(250D)), ((V)(0D)), ((V)((-0.78))), ((V)(150D)), ((V)(190D)));
e_249 = Call(turn_248, V.Undef, Add(e_249, ((V)(1000D))), ((V)((-0.78))), ((V)(0.78)), ((V)(190D)), ((V)(230D)));
e_249 = Call(turn_248, V.Undef, Add(e_249, ((V)(1000D))), ((V)(0.78)), ((V)(0D)), ((V)(150D)), ((V)(190D)));
return Invoke(Invoke(Invoke(t_247, "at", Add(e_249, ((V)(260D)))), "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 1, "", true);
Invoke(Arr(((V)("mittens")), ((V)("biscuit")), ((V)("prickle")), ((V)("nibbles")), ((V)("quill")), ((V)("poppy")), ((V)("duchess")), ((V)("mamapaws")), ((V)("waffles")), ((V)("truffle")), ((V)("ribbit"))), "forEach", Fn((V _arrowThis274, int _argc267, V key_273, V _a270, V _a271, V _a272, V[] _rest268) => {
SetK(ST_18, ((V)(JsStrBuf.Begin().S("idle_look@").V(key_273).End())), Call(nat_238, V.Undef, ((V)(1D))));
return default;
}, 1, "", true));
}
Set(ST_18, "idle_yawn", Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(300D)), NewObj(3).Put("sq", ((V)(0.04))).Put("pitch", ((V)((-0.1)))).Put("close", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(650D)), NewObj(13).Put("sq", ((V)((-0.1)))).Put("pitch", ((V)(0.45))).Put("open", ((V)(0.95))).Put("mw", ((V)(0.8))).Put("close", ((V)(0.85))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("hLy", ((V)((-4D)))).Put("hRy", ((V)((-4D)))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).Put("tongue", ((V)(0.25))).Put("lift", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(1.5))).V, NewObj(1).Put("tilt", ((V)((-1.5)))).V, ((V)("s"))), "to", ((V)(550D)), NewObj(14).Put("sq", ((V)(0.05))).Put("pitch", ((V)((-0.05)))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("close", ((V)(0.35))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("earL", ((V)(4D))).Put("earR", ((V)(4D))).Put("tongue", ((V)(0D))).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(520D)), ((V)(2D)), NewObj(2).Put("open", ((V)(0.16))).Put("smile", ((V)(0.3))).V, NewObj(2).Put("open", ((V)(0D))).Put("smile", ((V)(0.2))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(4).Put("close", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V), "e", ((V)("blink2"))), "wait", ((V)(400D))), "rest", ((V)(400D))), "done"));
wave_19 = Fn((V _arrowThis282, int _argc275, V s_281, V _a278, V _a279, V _a280, V[] _rest276) => {
V k_283 = default;
V t_284 = default;
V a_285 = default;
V b_286 = default;
k_283 = Call(S_14, V.Undef, s_281);
t_284 = Call(TL_13, V.Undef);
Invoke(Invoke(t_284, "to", ((V)(220D)), NewObj(3).PutK(Get(k_283, "arm"), ((V)((-10D)))).Put("sq", ((V)(0.04))).Put("lx", ((V)((ToNum(s_281) * 0.2)))).V, ((V)("io"))), "to", ((V)(380D)), NewObj(10).PutK(Get(k_283, "arm"), ((V)(150D))).PutK(Get(k_283, "hy"), ((V)((-3D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("lean", ((V)(((-ToNum(s_281)) * 1.4)))).Put("htilt", ((V)((ToNum(s_281) * 5D)))).Put("sq", ((V)((-0.04)))).Put("turn", ((V)((ToNum(s_281) * 0.15)))).PutK(Get(k_283, "ear"), ((V)((-8D)))).V, ((V)("o")));
a_285 = Get(t_284, "t");
Invoke(t_284, "osc", ((V)(1800D)), ((V)(4D)), NewObj(1).PutK(Get(k_283, "arm"), ((V)(118D))).V, NewObj(1).PutK(Get(k_283, "arm"), ((V)(165D))).V, ((V)("io")));
b_286 = Get(t_284, "t");
Invoke(Invoke(Invoke(t_284, "at", a_285), "osc", ((V)(1800D)), ((V)(3D)), NewObj(2).Put("wag", ((V)(16D))).Put("sq", ((V)((-0.01)))).V, NewObj(2).Put("wag", ((V)((-16D)))).Put("sq", ((V)((-0.05)))).V, ((V)("s"))), "at", b_286);
return Invoke(Invoke(Invoke(Invoke(Invoke(t_284, "wait", ((V)(120D))), "to", ((V)(460D)), NewObj(9).PutK(Get(k_283, "arm"), ((V)(0D))).PutK(Get(k_283, "hy"), ((V)(0D))).Put("lean", ((V)(0D))).Put("htilt", ((V)(0D))).Put("sq", ((V)(0.035))).Put("open", ((V)(0D))).Put("turn", ((V)(0D))).Put("wag", ((V)(0D))).PutK(Get(k_283, "ear"), ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(3).Put("sq", ((V)(0D))).Put("hap", ((V)(0.2))).Put("smile", ((V)(0.4))).V), "rest", ((V)(420D))), "done");
return default;
}, 1, "", true);
Set(ST_18, "idle_waveL", Call(wave_19, V.Undef, ((V)((-1D)))));
Set(ST_18, "idle_waveR", Call(wave_19, V.Undef, ((V)(1D))));
Invoke(Get(R_8, "FIDGETS"), "push", ((V)("idle_look")), ((V)("idle_yawn")), ((V)("idle_waveL")), ((V)("idle_waveR")));
Set(ST_18, "dance", Call(Fn((V _arrowThis293, int _argc287, V _a289, V _a290, V _a291, V _a292, V[] _rest288) => {
V t_294 = default;
double h_295 = 0;
V bt_296 = default;
t_294 = Call(TL_13, V.Undef);
h_295 = 250D;
bt_296 = Fn((V _arrowThis305, int _argc297, V dn_303, V up_304, V _a301, V _a302, V[] _rest298) => {
return Invoke(Invoke(t_294, "to", ((V)(h_295)), Call(o_17, V.Undef, NewObj(2).Put("sq", ((V)(0.1))).Put("lift", ((V)(0D))).V, dn_303), ((V)("io"))), "to", ((V)(h_295)), Call(o_17, V.Undef, NewObj(2).Put("sq", ((V)((-0.04)))).Put("lift", ((V)(1.6))).V, (up_304 is var _t306 && Truthy(_t306) ? _t306 : NewObj(0).V)), ((V)("o")));
}, 2, "", true);
Invoke(t_294, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Call(bt_296, V.Undef, NewObj(8).Put("x", ((V)(4D))).Put("lean", ((V)(2D))).Put("armL", ((V)((-6D)))).Put("armR", ((V)(34D))).Put("htilt", ((V)(3D))).Put("turn", ((V)(0.2))).Put("hap", ((V)(0.7))).Put("smile", ((V)(0.9))).V, NewObj(1).Put("footL", ((V)(2.5))).V);
Call(bt_296, V.Undef, NewObj(2).Put("footL", ((V)(0D))).Put("lean", ((V)(1D))).V);
Call(bt_296, V.Undef, NewObj(6).Put("x", ((V)((-4D)))).Put("lean", ((V)((-2D)))).Put("armL", ((V)(34D))).Put("armR", ((V)((-6D)))).Put("htilt", ((V)((-3D)))).Put("turn", ((V)((-0.2)))).V, NewObj(1).Put("footR", ((V)(2.5))).V);
Call(bt_296, V.Undef, NewObj(2).Put("footR", ((V)(0D))).Put("lean", ((V)((-1D)))).V);
Invoke(t_294, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Invoke(Arr(((V)((-1D))), ((V)(1D)), ((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis314, int _argc307, V d_313, V _a310, V _a311, V _a312, V[] _rest308) => {
return Call(bt_296, V.Undef, NewObj(9).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).Put("htilt", ((V)((ToNum(d_313) * 2D)))).Put("turn", ((V)(0D))).Put("pitch", ((V)(0.1))).Put("footL", ((V)((LtN(d_313, 0D) ? 4.5 : 0D)))).Put("footR", ((V)((GtN(d_313, 0D) ? 4.5 : 0D)))).Put("armL", ((V)((LtN(d_313, 0D) ? 45D : (-12D))))).Put("armR", ((V)((GtN(d_313, 0D) ? 45D : (-12D))))).V, (LtN(d_313, 0D) ? NewObj(1).Put("footL", ((V)(1D))).V : NewObj(1).Put("footR", ((V)(1D))).V));
}, 1, "", true));
Invoke(t_294, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Invoke(Arr(((V)(1D)), ((V)((-1D))), ((V)(1D)), ((V)((-1D)))), "forEach", Fn((V _arrowThis322, int _argc315, V d_321, V _a318, V _a319, V _a320, V[] _rest316) => {
V k_323 = default;
V j_324 = default;
k_323 = Call(S_14, V.Undef, d_321);
j_324 = Call(S_14, V.Undef, ((V)((-ToNum(d_321)))));
Invoke(Invoke(t_294, "to", ((V)(130D)), NewObj(14).Put("sq", ((V)(0.17))).Put("lift", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("pitch", ((V)(0D))).Put("tilt", ((V)((ToNum(d_321) * 7D)))).Put("lean", ((V)((ToNum(d_321) * 3D)))).Put("htilt", ((V)(((-ToNum(d_321)) * 4D)))).PutK(Get(k_323, "arm"), ((V)(150D))).PutK(Get(k_323, "hy"), ((V)((-4D)))).PutK(Get(j_324, "arm"), ((V)((-10D)))).PutK(Get(j_324, "hy"), ((V)(0D))).Put("wide", ((V)(0.3))).Put("hap", ((V)(0D))).V, ((V)("o"))), "to", ((V)(370D)), NewObj(2).Put("sq", ((V)(0.12))).Put("tilt", ((V)((ToNum(d_321) * 6D)))).V, ((V)("io")));
return default;
}, 1, "", true));
Invoke(Invoke(t_294, "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(500D)), NewObj(11).Put("sq", ((V)(0.22))).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)((-14D)))).Put("armR", ((V)((-14D)))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).Put("wide", ((V)(0D))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V, ((V)("io")));
{
V a_325 = default;
V b_326 = default;
a_325 = Get(t_294, "t");
Invoke(Invoke(Invoke(Invoke(t_294, "to", ((V)(260D)), NewObj(8).Put("sq", ((V)((-0.18)))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(480D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0.28))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(1).Put("sq", ((V)((-0.06)))).V, ((V)("io")));
b_326 = Get(t_294, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_294, "at", a_325), "to", ((V)(430D)), NewObj(1).Put("lift", ((V)(15D))).V, ((V)("o"))), "to", ((V)(430D)), NewObj(1).Put("lift", ((V)(0D))).V, ((V)("i"))), "at", Add(a_325, ((V)(60D)))), "to", ((V)(760D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "at", b_326), "e", ((V)("emit")), ((V)("spark")), ((V)("body")), ((V)(6D)));
}
Invoke(t_294, "to", ((V)(500D)), NewObj(5).Put("sq", ((V)(0.04))).Put("armL", ((V)(75D))).Put("armR", ((V)(75D))).Put("open", ((V)(0.3))).Put("winkR", ((V)(1D))).V, ((V)("o")));
Invoke(t_294, "e", ((V)("emit")), ((V)("note")), ((V)("head")));
Invoke(Arr(((V)(1D)), ((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis334, int _argc327, V d_333, V _a330, V _a331, V _a332, V[] _rest328) => {
return Call(bt_296, V.Undef, NewObj(9).Put("sq", ((V)(0.09))).Put("pitch", ((V)((-0.25)))).Put("armL", ((V)((GtN(d_333, 0D) ? 22D : 6D)))).Put("armR", ((V)((GtN(d_333, 0D) ? 6D : 22D)))).Put("htilt", ((V)((ToNum(d_333) * 3D)))).Put("turn", ((V)((ToNum(d_333) * 0.15)))).Put("x", ((V)((ToNum(d_333) * 1.5)))).Put("winkR", ((V)(0D))).Put("open", ((V)(0.15))).V, NewObj(2).Put("sq", ((V)((-0.02)))).Put("lift", ((V)(1D))).V);
}, 1, "", true));
Invoke(Invoke(t_294, "to", ((V)(h_295)), NewObj(7).Put("sq", ((V)(0.09))).Put("pitch", ((V)((-0.25)))).Put("armL", ((V)(6D))).Put("armR", ((V)(22D))).Put("htilt", ((V)((-3D)))).Put("turn", ((V)((-0.15)))).Put("x", ((V)((-1.5)))).V, ((V)("io"))), "rest", ((V)(h_295)), ((V)("io")));
return Invoke(t_294, "loop");
return default;
}, 0, "", true), V.Undef));
HOLD_20 = NewObj(2).Put("two", NewObj(2).Put("chest", Call(both_16, V.Undef, ((V)(7D)), ((V)((-6D))))).Put("mouth", Call(both_16, V.Undef, ((V)(10D)), ((V)((-13D))))).V).Put("R", NewObj(2).Put("chest", Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-8D))))).Put("mouth", Call(hand_15, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-15D))))).V).V;
chew_21 = Fn((V _arrowThis344, int _argc335, V t_341, V n_342, V big_343, V _a340, V[] _rest336) => {
return Invoke(t_341, "osc", ((V)((ToNum(n_342) * 260D))), n_342, NewObj(5).Put("open", ((V)(0.24))).Put("puff", ((V)((Truthy(big_343) ? 1D : 0.65)))).Put("htilt", ((V)(2.5))).Put("sq", ((V)(0.025))).Put("mw", ((V)(0.85))).V, NewObj(5).Put("open", ((V)(0.02))).Put("puff", ((V)((Truthy(big_343) ? 0.85 : 0.5)))).Put("htilt", ((V)((-2.5)))).Put("sq", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("s")));
}, 3, "", true);
gulp_22 = Fn((V _arrowThis352, int _argc345, V t_351, V _a348, V _a349, V _a350, V[] _rest346) => {
return Invoke(Invoke(Invoke(t_351, "to", ((V)(150D)), NewObj(5).Put("puff", ((V)(0D))).Put("sq", ((V)(0.06))).Put("pitch", ((V)(0.18))).Put("open", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("o"))), "e", ((V)("gulp"))), "to", ((V)(220D)), NewObj(2).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
bite_23 = Fn((V _arrowThis362, int _argc353, V t_359, V H_360, V last_361, V _a358, V[] _rest354) => {
Invoke(Invoke(Invoke(Invoke(t_359, "to", ((V)(300D)), Call(o_17, V.Undef, Get(H_360, "mouth"), NewObj(6).Put("open", ((V)(0.75))).Put("pitch", ((V)((-0.1)))).Put("ly", ((V)(0.4))).Put("lean", ((V)(0.4))).Put("hap", ((V)(0D))).Put("wide", ((V)(0.15))).V), ((V)("io"))), "to", ((V)(90D)), NewObj(4).Put("open", ((V)(0D))).Put("sq", ((V)(0.07))).Put("earL", ((V)(4D))).Put("earR", ((V)(4D))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")));
if (Truthy(last_361)) {
Invoke(t_359, "e", ((V)("done")));
}
return Invoke(t_359, "to", ((V)(280D)), Call(o_17, V.Undef, Get(H_360, "chest"), NewObj(8).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("lean", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0.2))).Put("puff", ((V)(0.5))).Put("wide", ((V)(0D))).V), ((V)("io")));
return default;
}, 3, "", true);
STYLE_24 = NewObj(9).Put("chomp", Fn((V _self363, int _argc364, V t_370, V H_371, V f_372, V _a369, V[] _rest365) => {
if (_self363.IsNullish) _self363 = GlobalV;
{
double i_373 = 0;
i_373 = 0D;
while (true) {
if (!(Lt(((V)(i_373)), Get(f_372, "n")))) break;
Call(bite_23, V.Undef, t_370, H_371, ((i_373 == (ToNum(Get(f_372, "n")) - 1D)) ? V.True : V.False));
Call(chew_21, V.Undef, t_370, (Get(f_372, "chew") is var _t375 && Truthy(_t375) ? _t375 : ((V)(3D))));
Call(gulp_22, V.Undef, t_370);
i_373++;
}
}
return default;
}, 3, "chomp", false)).Put("nibble", Fn((V _self376, int _argc377, V t_383, V H_384, V f_385, V _a382, V[] _rest378) => {
if (_self376.IsNullish) _self376 = GlobalV;
Invoke(t_383, "to", ((V)(320D)), Call(o_17, V.Undef, Get(H_384, "mouth"), NewObj(2).Put("pitch", ((V)((-0.05)))).Put("ly", ((V)(0.5))).V), ((V)("io")));
{
double i_386 = 0;
i_386 = 0D;
while (true) {
if (!(Lt(((V)(i_386)), Get(f_385, "n")))) break;
Invoke(Invoke(Invoke(Invoke(t_383, "to", ((V)(85D)), NewObj(3).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).Put("sq", ((V)(0.02))).V, ((V)("o"))), "to", ((V)(85D)), NewObj(3).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("puff", ((V)(0.45))).V, ((V)("io"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D)));
i_386++;
}
}
Invoke(Invoke(t_383, "e", ((V)("done"))), "to", ((V)(260D)), Call(o_17, V.Undef, Get(H_384, "chest"), NewObj(2).Put("puff", ((V)(0.55))).Put("mw", ((V)(1D))).V), ((V)("io")));
Call(chew_21, V.Undef, t_383, ((V)(3D)));
Call(gulp_22, V.Undef, t_383);
return default;
}, 3, "nibble", false)).Put("typewriter", Fn((V _self388, int _argc389, V t_395, V H_396, V f_397, V _a394, V[] _rest390) => {
V m_398 = default;
if (_self388.IsNullish) _self388 = GlobalV;
m_398 = Get(H_396, "mouth");
{
double row_399 = 0;
row_399 = 0D;
while (true) {
if (!((row_399 < 2D))) break;
Invoke(t_395, "to", ((V)(300D)), Call(o_17, V.Undef, m_398, NewObj(5).Put("hLx", Add(Get(m_398, "hLx"), ((V)(6D)))).Put("hRx", Add(Get(m_398, "hRx"), ((V)(6D)))).Put("pitch", ((V)((-0.05)))).Put("ly", ((V)(0.4))).Put("turn", ((V)(0.15))).V), ((V)("io")));
{
double i_401 = 0;
i_401 = 0D;
while (true) {
if (!(Lt(((V)(i_401)), Get(f_397, "n")))) break;
double p_403 = 0;
p_403 = (6D - (((i_401 + 1D) * 12D) / ToNum(Get(f_397, "n"))));
Invoke(Invoke(Invoke(Invoke(t_395, "to", ((V)(110D)), NewObj(4).Put("open", ((V)(0.35))).Put("hLx", Add(Get(m_398, "hLx"), ((V)(p_403)))).Put("hRx", Add(Get(m_398, "hRx"), ((V)(p_403)))).Put("turn", ((V)(((-p_403) / 32D)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(2).Put("open", ((V)(0D))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(1D)));
i_401++;
}
}
Invoke(Invoke(Invoke(t_395, "to", ((V)(170D)), NewObj(5).Put("hLx", Add(Get(m_398, "hLx"), ((V)(6D)))).Put("hRx", Add(Get(m_398, "hRx"), ((V)(6D)))).Put("turn", ((V)(0.2))).Put("sq", ((V)(0D))).Put("wide", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("ding"))), "to", ((V)(120D)), NewObj(1).Put("wide", ((V)(0D))).V);
row_399++;
}
}
Invoke(Invoke(t_395, "e", ((V)("done"))), "to", ((V)(300D)), Call(o_17, V.Undef, Get(H_396, "chest"), NewObj(2).Put("turn", ((V)(0D))).Put("puff", ((V)(0.7))).V), ((V)("io")));
Call(chew_21, V.Undef, t_395, ((V)(3D)));
if (Truthy(Get(f_397, "seed"))) {
Invoke(Invoke(Invoke(t_395, "to", ((V)(160D)), NewObj(4).Put("puff", ((V)(0.3))).Put("mw", ((V)(0.45))).Put("open", ((V)(0.2))).Put("turn", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth"))), "to", ((V)(220D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("turn", ((V)(0D))).V);
}
Call(gulp_22, V.Undef, t_395);
return default;
}, 3, "typewriter", false)).Put("lick", Fn((V _self404, int _argc405, V t_411, V H_412, V f_413, V _a410, V[] _rest406) => {
V L_414 = default;
if (_self404.IsNullish) _self404 = GlobalV;
L_414 = Call(o_17, V.Undef, Get(H_412, "mouth"));
{
foreach (V _k415 in ForInKeys(L_414)) {
V q_416 = default;
q_416 = _k415;
if (Truthy(Invoke(NewRegExp(RX0, "y$", ""), "test", q_416))) {
OpSetK(L_414, q_416, 0, ((V)(3D)));
}
}
}
Invoke(t_411, "to", ((V)(320D)), Call(o_17, V.Undef, L_414, NewObj(1).Put("ly", ((V)(0.5))).V), ((V)("io")));
{
double i_417 = 0;
i_417 = 0D;
while (true) {
if (!(Lt(((V)(i_417)), Get(f_413, "n")))) break;
Invoke(Invoke(Invoke(t_411, "to", ((V)(170D)), NewObj(6).Put("tongue", ((V)(1D))).Put("pitch", ((V)(0.25))).Put("sq", ((V)((-0.04)))).Put("open", ((V)(0.12))).Put("hap", ((V)(0.5))).Put("turn", ((V)((Truthy(Get(f_413, "swirl")) ? (NumTruthy((i_417 % 2D)) ? 0.25 : (-0.25)) : 0D)))).V, ((V)("io"))), "e", ((V)("lick"))), "to", ((V)(230D)), NewObj(4).Put("tongue", ((V)(0.15))).Put("pitch", ((V)((-0.05)))).Put("sq", ((V)(0.01))).Put("open", ((V)(0D))).V, ((V)("io")));
i_417++;
}
}
Invoke(t_411, "to", ((V)(200D)), NewObj(4).Put("tongue", ((V)(0D))).Put("turn", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(0.8))).V, ((V)("io")));
if (Truthy(Get(f_413, "then"))) {
Call(bite_23, V.Undef, t_411, H_412, (true ? V.True : V.False));
Call(chew_21, V.Undef, t_411, ((V)(3D)));
Call(gulp_22, V.Undef, t_411);
} else {
Invoke(Invoke(t_411, "e", ((V)("done"))), "to", ((V)(300D)), Call(o_17, V.Undef, Get(H_412, "chest")), ((V)("io")));
}
return default;
}, 3, "lick", false)).Put("whole", Fn((V _self419, int _argc420, V t_426, V H_427, V _a424, V _a425, V[] _rest421) => {
if (_self419.IsNullish) _self419 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_426, "to", ((V)(320D)), Call(o_17, V.Undef, Get(H_427, "mouth"), NewObj(4).Put("open", ((V)(1D))).Put("mw", ((V)(1.1))).Put("pitch", ((V)(0.1))).Put("wide", ((V)(0.3))).V), ((V)("io"))), "to", ((V)(110D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(1.1))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("done"))), "to", ((V)(300D)), Call(o_17, V.Undef, Get(H_427, "chest"), NewObj(3).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).V), ((V)("io")));
Call(chew_21, V.Undef, t_426, ((V)(5D)), (true ? V.True : V.False));
Call(gulp_22, V.Undef, t_426);
return default;
}, 2, "whole", false)).Put("slurp", Fn((V _self428, int _argc429, V t_435, V H_436, V f_437, V _a434, V[] _rest430) => {
if (_self428.IsNullish) _self428 = GlobalV;
{
double i_438 = 0;
i_438 = 0D;
while (true) {
if (!((i_438 < 3D))) break;
V a_440 = default;
Invoke(t_435, "to", ((V)(220D)), NewObj(4).Put("pitch", ((V)((-0.25)))).Put("ly", ((V)(0.6))).Put("mw", ((V)(0.5))).Put("open", ((V)(0.25))).V, ((V)("io")));
a_440 = Get(t_435, "t");
Invoke(t_435, "osc", ((V)(700D)), ((V)(5D)), NewObj(3).Put("sq", ((V)(0.04))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.42))).V, NewObj(3).Put("sq", ((V)((-0.01)))).Put("open", ((V)(0.28))).Put("mw", ((V)(0.5))).V, ((V)("s")));
Invoke(Get(f_437, "wins"), "push", Arr(a_440, Get(t_435, "t")));
Invoke(t_435, "to", ((V)(120D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0.6))).Put("pitch", ((V)(0.05))).V, ((V)("o")));
Call(chew_21, V.Undef, t_435, ((V)(2D)));
Call(gulp_22, V.Undef, t_435);
i_438++;
}
}
Invoke(t_435, "e", ((V)("done")));
return default;
}, 3, "slurp", false)).Put("sip", Fn((V _self441, int _argc442, V t_448, V H_449, V f_450, V _a447, V[] _rest443) => {
if (_self441.IsNullish) _self441 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_448, "to", ((V)(320D)), Call(o_17, V.Undef, (Get(f_450, "mp") is var _t451 && Truthy(_t451) ? _t451 : Get(H_449, "mouth")), NewObj(1).Put("pitch", ((V)((-0.05)))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(3).Put("mw", ((V)(0.42))).Put("open", ((V)(0.1))).Put("puff", ((V)((-0.4)))).V, ((V)("o"))), "em", ((V)(1800D)), ((V)(450D)), ((V)("bubble")), ((V)("mouth")), ((V)(1D))), "osc", ((V)(1800D)), ((V)(6D)), NewObj(2).Put("puff", ((V)((-0.5)))).Put("sq", ((V)(0.03))).V, NewObj(2).Put("puff", ((V)((-0.3)))).Put("sq", ((V)(0D))).V, ((V)("s"))), "to", ((V)(140D)), NewObj(3).Put("puff", ((V)((-0.6)))).Put("sq", ((V)(0.06))).Put("wide", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("crumple"))), "to", ((V)(260D)), Call(o_17, V.Undef, Get(H_449, "chest"), NewObj(5).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(300D))), "e", ((V)("done")));
return default;
}, 3, "sip", false)).Put("big", Fn((V _self452, int _argc453, V t_459, V H_460, V _a457, V _a458, V[] _rest454) => {
if (_self452.IsNullish) _self452 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_459, "to", ((V)(380D)), Call(o_17, V.Undef, Get(H_460, "mouth"), NewObj(6).Put("open", ((V)(1D))).Put("mw", ((V)(1.45))).Put("pitch", ((V)(0.15))).Put("htilt", ((V)((-6D)))).Put("wide", ((V)(0.5))).Put("sq", ((V)((-0.05)))).V), ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(110D)), NewObj(6).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.1))).Put("puff", ((V)(1.2))).Put("htilt", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(5D))), "to", ((V)(300D)), Call(o_17, V.Undef, Get(H_460, "chest"), NewObj(1).Put("sq", ((V)(0D))).V), ((V)("io")));
Call(chew_21, V.Undef, t_459, ((V)(6D)), (true ? V.True : V.False));
Call(gulp_22, V.Undef, t_459);
Call(bite_23, V.Undef, t_459, H_460, (true ? V.True : V.False));
Call(chew_21, V.Undef, t_459, ((V)(3D)));
Call(gulp_22, V.Undef, t_459);
return default;
}, 2, "big", false)).Put("gobble", Fn((V _self461, int _argc462, V t_468, V H_469, V f_470, V _a467, V[] _rest463) => {
if (_self461.IsNullish) _self461 = GlobalV;
{
double i_471 = 0;
i_471 = 0D;
while (true) {
if (!(Lt(((V)(i_471)), Get(f_470, "n")))) break;
Invoke(Invoke(Invoke(Invoke(t_468, "to", ((V)(160D)), Call(o_17, V.Undef, Get(H_469, "mouth"), NewObj(2).Put("open", ((V)(0.85))).Put("pitch", ((V)((-0.1)))).V), ((V)("io"))), "to", ((V)(70D)), NewObj(3).Put("open", ((V)(0D))).Put("sq", ((V)(0.06))).Put("puff", ((V)(0.7))).V, ((V)("o"))), "e", ((V)("bite"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(2D)));
if ((i_471 == (ToNum(Get(f_470, "n")) - 1D))) {
Invoke(t_468, "e", ((V)("done")));
}
Invoke(t_468, "to", ((V)(160D)), Call(o_17, V.Undef, Get(H_469, "chest"), NewObj(1).Put("sq", ((V)(0D))).V), ((V)("io")));
Call(chew_21, V.Undef, t_468, ((V)(1D)));
i_471++;
}
}
Call(gulp_22, V.Undef, t_468);
return default;
}, 3, "gobble", false)).V;
REACT_25 = NewObj(5).Put("yum", Fn((V _self473, int _argc474, V t_480, V _a477, V _a478, V _a479, V[] _rest475) => {
V a_481 = default;
V b_482 = default;
if (_self473.IsNullish) _self473 = GlobalV;
Invoke(t_480, "to", ((V)(320D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(10D)), ((V)(1D))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(0D)), ((V)(0D))), NewObj(5).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("sq", ((V)(0.03))).Put("pitch", ((V)(0.1))).V), ((V)("io")));
a_481 = Get(t_480, "t");
Invoke(t_480, "osc", ((V)(1200D)), ((V)(3D)), NewObj(4).Put("hLx", ((V)(13D))).Put("hLy", ((V)(3D))).Put("htilt", ((V)(4D))).Put("lean", ((V)(1D))).V, NewObj(4).Put("hLx", ((V)(8D))).Put("hLy", ((V)((-1D)))).Put("htilt", ((V)((-4D)))).Put("lean", ((V)((-1D)))).V, ((V)("s")));
b_482 = Get(t_480, "t");
Invoke(Invoke(Invoke(t_480, "at", a_481), "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(16D))).V, NewObj(1).Put("wag", ((V)((-16D)))).V, ((V)("s"))), "at", b_482);
Invoke(Invoke(Invoke(Invoke(t_480, "to", ((V)(200D)), NewObj(5).Put("sq", ((V)(0.12))).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(4).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(7D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.18))).V, ((V)("i"))), "to", ((V)(220D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", false)).Put("love", Fn((V _self483, int _argc484, V t_490, V _a487, V _a488, V _a489, V[] _rest485) => {
if (_self483.IsNullish) _self483 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_490, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(2D)), ((V)((-18D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-18D)))), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(0.8))).Put("blush", ((V)(1D))).Put("sq", ((V)(0.03))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(3).Put("htilt", ((V)(6D))).Put("lean", ((V)(1.4))).Put("x", ((V)(1D))).V, NewObj(3).Put("htilt", ((V)((-6D)))).Put("lean", ((V)((-1.4)))).Put("x", ((V)((-1D)))).V, ((V)("s"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(3).Put("x", ((V)(0D))).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).V);
return default;
}, 1, "love", false)).Put("spicy", Fn((V _self491, int _argc492, V t_498, V _a495, V _a496, V _a497, V[] _rest493) => {
V a_499 = default;
V b_500 = default;
if (_self491.IsNullish) _self491 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_498, "to", ((V)(150D)), NewObj(3).Put("wide", ((V)(1D))).Put("open", ((V)(0.2))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "wait", ((V)(350D))), "to", ((V)(500D)), NewObj(4).Put("red", ((V)(1D))).Put("wide", ((V)(0.6))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("earL")), ((V)(3D))), "e", ((V)("emit")), ((V)("steam")), ((V)("earR")), ((V)(3D))), "to", ((V)(200D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-14D)))), NewObj(3).Put("tongue", ((V)(1D))).Put("open", ((V)(0.5))).Put("sqz", ((V)(0.8))).V), ((V)("io"))), "em", ((V)(1500D)), ((V)(200D)), ((V)("steam")), ((V)("head")), ((V)(1D)));
a_499 = Get(t_498, "t");
Invoke(t_498, "osc", ((V)(1500D)), ((V)(6D)), NewObj(2).Put("hRx", ((V)((-16D)))).Put("tongue", ((V)(1D))).V, NewObj(2).Put("hRx", ((V)((-8D)))).Put("tongue", ((V)(0.7))).V, ((V)("io")));
b_500 = Get(t_498, "t");
Invoke(Invoke(Invoke(t_498, "at", a_499), "osc", ((V)(1500D)), ((V)(3D)), NewObj(2).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).V, NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("io"))), "at", b_500);
Invoke(Invoke(Invoke(t_498, "to", ((V)(400D)), NewObj(10).Put("red", ((V)(0.4))).Put("tongue", ((V)(0D))).Put("sqz", ((V)(0D))).Put("open", ((V)(0D))).Put("wide", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("red", ((V)(0D))).Put("frown", ((V)(0.3))).V), "wait", ((V)(200D)));
return default;
}, 1, "spicy", false)).Put("sour", Fn((V _self501, int _argc502, V t_508, V _a505, V _a506, V _a507, V[] _rest503) => {
V a_509 = default;
V b_510 = default;
if (_self501.IsNullish) _self501 = GlobalV;
Invoke(t_508, "to", ((V)(130D)), NewObj(7).Put("sqz", ((V)(1D))).Put("mw", ((V)(0.4))).Put("open", ((V)(0.15))).Put("sq", ((V)(0.12))).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).Put("pitch", ((V)((-0.2)))).V, ((V)("o")));
a_509 = Get(t_508, "t");
Invoke(t_508, "wait", ((V)(1000D)));
b_510 = Get(t_508, "t");
Invoke(Invoke(Invoke(t_508, "at", a_509), "osc", ((V)(1000D)), ((V)(10D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("l"))), "at", b_510);
Invoke(Invoke(Invoke(t_508, "osc", ((V)(700D)), ((V)(3D)), NewObj(1).Put("turn", ((V)(0.35))).V, NewObj(1).Put("turn", ((V)((-0.35)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(11).Put("sqz", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("pitch", ((V)(0D))).Put("turn", ((V)(0D))).Put("x", ((V)(0D))).Put("smile", ((V)(0.6))).Put("hap", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(200D)));
return default;
}, 1, "sour", false)).Put("freeze", Fn((V _self511, int _argc512, V t_518, V _a515, V _a516, V _a517, V[] _rest513) => {
V a_519 = default;
V b_520 = default;
if (_self511.IsNullish) _self511 = GlobalV;
Invoke(Invoke(t_518, "to", ((V)(150D)), NewObj(3).Put("sqz", ((V)(1D))).Put("sq", ((V)(0.08))).Put("frown", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)((-1D))), ((V)((-22D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)((-1D))), ((V)((-22D)))), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).V), ((V)("io")));
a_519 = Get(t_518, "t");
Invoke(t_518, "wait", ((V)(1100D)));
b_520 = Get(t_518, "t");
Invoke(Invoke(Invoke(t_518, "at", a_519), "osc", ((V)(1100D)), ((V)(11D)), NewObj(1).Put("x", ((V)(0.7))).V, NewObj(1).Put("x", ((V)((-0.7)))).V, ((V)("l"))), "at", b_520);
Invoke(Invoke(t_518, "to", ((V)(400D)), NewObj(14).Put("sqz", ((V)(0D))).Put("frown", ((V)(0D))).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("sq", ((V)(0D))).Put("x", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(300D)));
return default;
}, 1, "freeze", false)).V;
foodProp_26 = Fn((V _arrowThis529, int _argc521, V f_527, V key_528, V _a525, V _a526, V[] _rest522) => {
return Fn((V _arrowThis538, int _argc530, V I_536, V t_537, V _a534, V _a535, V[] _rest531) => {
V c_539 = default;
V W_540 = default;
V x_541 = default;
V y_542 = default;
double nb_543 = 0;
V id_544 = default;
JsStrBuf m_545 = null;
V body_546 = default;
c_539 = Get(I_536, "ctr");
W_540 = Get(I_536, "W");
if (Truthy((Get(c_539, "done") is var _t547 && Truthy(_t547) ? _t547 : (!(Truthy(Get(W_540, "pawR"))) ? V.True : V.False)))) {
return ((V)(""));
}
x_541 = V.Undef;
y_542 = V.Undef;
if (SEqS(Get(f_527, "hold"), "two")) {
x_541 = ((V)((ToNum(Add(GetIdx(Get(W_540, "pawL"), 0D), GetIdx(Get(W_540, "pawR"), 0D))) / 2D)));
y_542 = ((V)(((ToNum(Add(GetIdx(Get(W_540, "pawL"), 1D), GetIdx(Get(W_540, "pawR"), 1D))) / 2D) - (5.5 * ToNum((!Get(I_536, "foodK").IsNullish ? Get(I_536, "foodK") : ((V)(1D))))))));
} else {
if (Truthy((Get(f_527, "grip") is var _t548 && !Truthy(_t548) ? _t548 : Get(I_536, "gripStick")))) {
V s_549 = default;
double a_550 = 0;
V gx_551 = default;
V gy_552 = default;
s_549 = (Get(f_527, "sc") is var _t553 && Truthy(_t553) ? _t553 : ((V)(1.15)));
a_550 = ((ToNum((GetIdx(Get(f_527, "grip"), 2D) is var _t554 && Truthy(_t554) ? _t554 : ((V)(0D)))) * System.Math.PI) / 180D);
gx_551 = GetIdx(Get(f_527, "grip"), 0D);
gy_552 = GetIdx(Get(f_527, "grip"), 1D);
x_541 = ((V)((ToNum(GetIdx(Get(W_540, "pawR"), 0D)) - (((ToNum(gx_551) * FdLibm.Cos(a_550)) - (ToNum(gy_552) * FdLibm.Sin(a_550))) * ToNum(s_549)))));
y_542 = ((V)((ToNum(GetIdx(Get(W_540, "pawR"), 1D)) - (((ToNum(gx_551) * FdLibm.Sin(a_550)) + (ToNum(gy_552) * FdLibm.Cos(a_550))) * ToNum(s_549)))));
} else {
x_541 = ((V)((ToNum(GetIdx(Get(W_540, "pawR"), 0D)) - 2.5)));
y_542 = ((V)((ToNum(GetIdx(Get(W_540, "pawR"), 1D)) - (6D * ToNum((!Get(I_536, "foodK1").IsNullish ? Get(I_536, "foodK1") : (!Get(I_536, "foodK").IsNullish ? Get(I_536, "foodK") : ((V)(1D)))))))));
}
}
if (Truthy(((Get(I_536, "foodMid") is var _t555 && !Truthy(_t555) ? _t555 : Get(W_540, "pawL")) is var _t557 && !Truthy(_t557) ? _t557 : (!(Truthy((Get(f_527, "grip") is var _t556 && !Truthy(_t556) ? _t556 : Get(I_536, "gripStick")))) ? V.True : V.False)))) {
x_541 = ((V)((ToNum(Add(GetIdx(Get(W_540, "pawL"), 0D), GetIdx(Get(W_540, "pawR"), 0D))) / 2D)));
y_542 = ((V)((ToNum(Add(GetIdx(Get(W_540, "pawL"), 1D), GetIdx(Get(W_540, "pawR"), 1D))) / 2D)));
}
if (Truthy((Get(I_536, "foodDY") is var _t558 && !Truthy(_t558) ? _t558 : GetK(Get(I_536, "foodDY"), key_528)))) {
y_542 = Add(y_542, GetK(Get(I_536, "foodDY"), key_528));
}
nb_543 = Min(ToNum((Get(c_539, "bite") is var _t559 && Truthy(_t559) ? _t559 : ((V)(0D)))), ToNum((Truthy(Get(f_527, "bm")) ? Get(Get(f_527, "bm"), "length") : ((V)(0D)))));
id_544 = ((V)(JsStrBuf.Begin().S("bm").V(Get(I_536, "u")).V(key_528).End()));
m_545 = new JsStrBuf("");
if (NumTruthy(nb_543)) {
m_545.Set(JsStrBuf.Begin().S("<mask id=\"").V(id_544).S("\" maskUnits=\"userSpaceOnUse\" x=\"-30\" y=\"-30\" width=\"60\" height=\"60\"><rect x=\"-30\" y=\"-30\" width=\"60\" height=\"60\" fill=\"#fff\"/>").End());
{
double i_560 = 0;
i_560 = 0D;
while (true) {
if (!((i_560 < nb_543))) break;
V b_562 = default;
b_562 = GetIdx(Get(f_527, "bm"), i_560);
m_545.S("<circle cx=\"").V(GetIdx(b_562, 0D)).S("\" cy=\"").V(GetIdx(b_562, 1D)).S("\" r=\"").V(GetIdx(b_562, 2D)).S("\" fill=\"#000\"/>");
i_560++;
}
}
m_545.S("</mask>");
}
body_546 = (string.Equals(Typeof(Get(f_527, "svg")), "function") ? Invoke(f_527, "svg", I_536, t_537, c_539, x_541, y_542, f_527) : Get(f_527, "svg"));
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(r2_10, V.Undef, x_541)).S(" ").V(Call(r2_10, V.Undef, y_542)).S(") rotate(").V((Truthy((Get(f_527, "grip") is var _t565 && !Truthy(_t565) ? _t565 : Get(I_536, "gripStick"))) ? (GetIdx(Get(f_527, "grip"), 2D) is var _t563 && Truthy(_t563) ? _t563 : ((V)(0D))) : (Get(f_527, "rot") is var _t564 && Truthy(_t564) ? _t564 : ((V)(0D))))).S(") scale(").V(Call(r2_10, V.Undef, ((V)((ToNum(Call(SM_11, V.Undef, ((V)((ToNum(t_537) / 220D))))) * ToNum((Get(f_527, "sc") is var _t566 && Truthy(_t566) ? _t566 : ((V)(1.15))))))))).S(")\">").S(m_545.Str).S("<g").S((NumTruthy(nb_543) ? JsStrBuf.Begin().S(" mask=\"url(#").V(id_544).S(")\"").End() : "")).S(">").V(body_546).S("</g></g>").End()));
return default;
}, 2, "", true);
}, 2, "", true);
top_27 = Fn((V _arrowThis577, int _argc567, V n_573, V y_574, V w_575, V r_576, V[] _rest568) => {
return Array_from(NewObj(1).Put("length", n_573).V, Fn((V _arrowThis586, int _argc578, V __584, V i_585, V _a582, V _a583, V[] _rest579) => {
return Arr(Call(r2_10, V.Undef, ((V)(((ToNum(w_575) / 2D) - ((ToNum(i_585) * ToNum(w_575)) / ToNum((((V)((ToNum(n_573) - 1D))) is var _t587 && Truthy(_t587) ? _t587 : ((V)(1D))))))))), y_574, r_576);
}, 2, "", true));
}, 4, "", true);
FOODS_28 = NewObj(20).Put("apple", NewObj(8).Put("label", ((V)("Apple"))).Put("d", ((V)("Two paws, three crunchy bites."))).Put("hold", ((V)("two"))).Put("style", ((V)("chomp"))).Put("n", ((V)(3D))).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)(1.5)), ((V)((-5D))), ((V)(2.4))), Arr(((V)((-2.4))), ((V)((-4.4))), ((V)(2.4))), Arr(((V)(3.6)), ((V)((-1.2))), ((V)(2.6))))).Put("svg", ((V)("<circle cx=\"0\" cy=\"0.5\" r=\"5.2\" fill=\"#ff5a5f\"/><path d=\"M-2.2 -3.6 Q0 -2.2 2.2 -3.6\" fill=\"none\" stroke=\"#d93a45\" stroke-width=\"0.8\"/><path d=\"M0 -4 L0.6 -6.4\" stroke=\"#7a4a2a\" stroke-width=\"0.9\" stroke-linecap=\"round\"/><path d=\"M0.6 -5.6 Q3 -7.4 4 -5 Q2 -4.4 0.6 -5.6Z\" fill=\"#6fcf5a\"/><ellipse cx=\"-2\" cy=\"-1.4\" rx=\"1.4\" ry=\"0.9\" fill=\"#ffffff\" opacity=\"0.5\"/>"))).V).Put("banana", NewObj(9).Put("label", ((V)("Banana"))).Put("d", ((V)("One paw, bites from the tip."))).Put("hold", ((V)("R"))).Put("style", ((V)("chomp"))).Put("n", ((V)(3D))).Put("react", ((V)("yum"))).Put("rot", ((V)((-10D)))).Put("bm", Arr(Arr(((V)((-1.6))), ((V)((-6.4))), ((V)(2D))), Arr(((V)((-3D))), ((V)((-3.8))), ((V)(2.2))), Arr(((V)((-4D))), ((V)((-0.8))), ((V)(2.4))))).Put("svg", ((V)("<path d=\"M-5 3 Q-6 -3 -2 -6 Q-1 -6.5 -0.6 -5.6 Q-3.6 -2 -2 3 Q0 6 5 5.6 Q5.6 6.4 4.6 7 Q-2 8 -5 3Z\" fill=\"#ffd84a\" stroke=\"#e0b52a\" stroke-width=\"0.5\"/><path d=\"M-2 -6 L-1.2 -7.4\" stroke=\"#7a5a2a\" stroke-width=\"1\" stroke-linecap=\"round\"/>"))).V).Put("carrot", NewObj(8).Put("label", ((V)("Carrot"))).Put("d", ((V)("Fast rabbit nibbles down the carrot."))).Put("hold", ((V)("two"))).Put("style", ((V)("nibble"))).Put("n", ((V)(8D))).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-7D))), ((V)(1.6))), Arr(((V)(0D)), ((V)((-5.4))), ((V)(1.8))), Arr(((V)(0D)), ((V)((-3.6))), ((V)(2D))), Arr(((V)(0D)), ((V)((-1.8))), ((V)(2.1))), Arr(((V)(0D)), ((V)(0D)), ((V)(2.3))), Arr(((V)(0D)), ((V)(1.8)), ((V)(2.4))), Arr(((V)(0D)), ((V)(3.4)), ((V)(2.6))), Arr(((V)(0D)), ((V)(5D)), ((V)(3D))))).Put("svg", ((V)("<path d=\"M-2.6 4 Q0 5 2.6 4 L0.4 -7 Q0 -7.8 -0.4 -7 Z\" fill=\"#ff9a3a\"/><path d=\"M-1.6 0.5 L0.4 0.2 M-1 -2.5 L0.8 -2.8\" stroke=\"#e07a1a\" stroke-width=\"0.5\"/><path d=\"M0 4.4 Q-2.4 8 -1.2 9 Q0 7 0 4.4 Q1 8.6 2.6 8.2 Q1.4 6 0 4.4Z\" fill=\"#6fcf5a\"/>"))).V).Put("cookie", NewObj(8).Put("label", ((V)("Cookie"))).Put("d", ((V)("Crumbly bites, crumbs everywhere, love."))).Put("hold", ((V)("R"))).Put("style", ((V)("chomp"))).Put("n", ((V)(3D))).Put("react", ((V)("love"))).Put("bm", Arr(Arr(((V)(1.5)), ((V)((-4.6))), ((V)(2.3))), Arr(((V)((-2D))), ((V)((-4.2))), ((V)(2.3))), Arr(((V)(3.8)), ((V)((-1.6))), ((V)(2.4))))).Put("svg", ((V)("<circle r=\"5\" fill=\"#e0a75e\"/><circle r=\"5\" fill=\"none\" stroke=\"#c48a45\" stroke-width=\"0.6\"/><circle cx=\"-2\" cy=\"-1.5\" r=\"0.8\" fill=\"#5a3420\"/><circle cx=\"1.8\" cy=\"0.6\" r=\"0.9\" fill=\"#5a3420\"/><circle cx=\"-0.6\" cy=\"2.4\" r=\"0.7\" fill=\"#5a3420\"/><circle cx=\"2.2\" cy=\"-2.6\" r=\"0.6\" fill=\"#5a3420\"/>"))).V).Put("donut", NewObj(9).Put("label", ((V)("Donut"))).Put("d", ((V)("Peeks through the hole first, then bites."))).Put("hold", ((V)("two"))).Put("style", ((V)("chomp"))).Put("n", ((V)(3D))).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)(1.6)), ((V)((-5D))), ((V)(2.4))), Arr(((V)((-2.6))), ((V)((-4.4))), ((V)(2.4))), Arr(((V)(4.2)), ((V)((-1.4))), ((V)(2.4))))).Put("pre", Fn((V _self588, int _argc589, V t_595, V _a592, V _a593, V _a594, V[] _rest590) => {
if (_self588.IsNullish) _self588 = GlobalV;
Invoke(Invoke(Invoke(Invoke(Invoke(t_595, "to", ((V)(420D)), NewObj(9).Put("hLx", ((V)(23D))).Put("hLy", ((V)((-24D)))).Put("hRx", ((V)((-2D)))).Put("hRy", ((V)((-24D)))).Put("lx", ((V)(0.6))).Put("ly", ((V)((-0.1)))).Put("winkL", ((V)(1D))).Put("pitch", ((V)(0.05))).Put("wide", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(240D)), NewObj(2).Put("hLx", ((V)(18D))).Put("hRx", ((V)((-7D)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("hLx", ((V)(23D))).Put("hRx", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(400D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(7D)), ((V)((-6D)))), NewObj(4).Put("winkL", ((V)(0D))).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).V), ((V)("io")));
return default;
}, 1, "pre", false)).Put("svg", ((V)("<path fill-rule=\"evenodd\" d=\"M5.4 0 A5.4 5.4 0 1 0 -5.4 0 A5.4 5.4 0 1 0 5.4 0Z M1.7 0 A1.7 1.7 0 1 1 -1.7 0 A1.7 1.7 0 1 1 1.7 0Z\" fill=\"#e8b06a\"/><path fill-rule=\"evenodd\" d=\"M4.7 -0.4 Q4.4 -4.6 0 -4.7 Q-4.4 -4.6 -4.7 -0.4 Q-4.2 2.6 -2.6 2 Q-1 3.4 0 2.2 Q1.6 3.6 2.8 2.2 Q4.4 2.6 4.7 -0.4Z M2.3 0 A2.3 2.3 0 1 1 -2.3 0 A2.3 2.3 0 1 1 2.3 0Z\" fill=\"#ff8fc8\"/><path d=\"M-3 -2.6 l0.8 -0.6 M1.6 -3.4 l0.9 0.3 M3.4 -1 l0.2 0.9 M-3.6 0.6 l0.6 0.6 M-0.6 -3.6 l-0.3 0.8\" stroke=\"#ffffff\" stroke-width=\"0.6\" stroke-linecap=\"round\"/>"))).V).Put("pizza", NewObj(9).Put("label", ((V)("Pizza slice"))).Put("d", ((V)("Holds it up high, looks up, then bites."))).Put("hold", ((V)("R"))).Put("style", ((V)("chomp"))).Put("n", ((V)(2D))).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-6.4))), ((V)(2.6))), Arr(((V)(0D)), ((V)((-3.4))), ((V)(3D))))).Put("pre", Fn((V _self596, int _argc597, V t_603, V _a600, V _a601, V _a602, V[] _rest598) => {
if (_self596.IsNullish) _self596 = GlobalV;
Invoke(Invoke(Invoke(t_603, "to", ((V)(450D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-30D)))), NewObj(4).Put("pitch", ((V)(0.5))).Put("ly", ((V)((-0.9)))).Put("open", ((V)(0.6))).Put("armR", ((V)(30D))).V), ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(380D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-8D)))), NewObj(4).Put("pitch", ((V)(0D))).Put("ly", ((V)(0.3))).Put("open", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
return default;
}, 1, "pre", false)).Put("svg", ((V)("<path d=\"M-4.5 4 L4.5 4 L0 -7 Z\" fill=\"#ffd25a\"/><path d=\"M-5 4 Q0 6.2 5 4 L4.6 5.6 Q0 7.6 -4.6 5.6Z\" fill=\"#d9903a\"/><circle cx=\"-1.2\" cy=\"1.4\" r=\"1.1\" fill=\"#e2483a\"/><circle cx=\"1.4\" cy=\"-1.4\" r=\"0.9\" fill=\"#e2483a\"/><circle cx=\"1.6\" cy=\"2.4\" r=\"0.8\" fill=\"#e2483a\"/>"))).V).Put("icecream", NewObj(9).Put("label", ((V)("Ice cream"))).Put("d", ((V)("Four long licks, then a bite of cone."))).Put("hold", ((V)("R"))).Put("style", ((V)("lick"))).Put("n", ((V)(4D))).Put("then", (true ? V.True : V.False)).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-6D))), ((V)(3.4))), Arr(((V)(0D)), ((V)((-2.4))), ((V)(3.8))))).Put("svg", Fn((V _arrowThis613, int _argc604, V I_610, V t_611, V c_612, V _a609, V[] _rest605) => {
double k_614 = 0;
k_614 = (1D - (0.07 * Min(4D, ToNum((Get(c_612, "lick") is var _t615 && Truthy(_t615) ? _t615 : ((V)(0D)))))));
return ((V)(JsStrBuf.Begin().S("<path d=\"M-3.4 0 L3.4 0 L0 9 Z\" fill=\"#e8b06a\"/><path d=\"M-2.4 1.6 L1.6 5.6 M2.4 1.6 L-1.6 5.6\" stroke=\"#c48a45\" stroke-width=\"0.5\"/><circle cx=\"0\" cy=\"-1.6\" r=\"3.8\" fill=\"#ffc0de\"/><circle cx=\"0\" cy=\"").V(Call(r2_10, V.Undef, ((V)(((-5.2) * k_614))))).S("\" r=\"").V(Call(r2_10, V.Undef, ((V)((3D * k_614))))).S("\" fill=\"#fff4c2\"/>").End()));
return default;
}, 3, "svg", true)).V).Put("burger", NewObj(7).Put("label", ((V)("Burger"))).Put("d", ((V)("Opens super wide for one huge chomp."))).Put("hold", ((V)("two"))).Put("style", ((V)("big"))).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-6D))), ((V)(3.6))), Arr(((V)(3.6)), ((V)((-4.6))), ((V)(3.6))))).Put("svg", ((V)("<path d=\"M-6 3.6 L6 3.6 Q6 6.4 3 6.4 L-3 6.4 Q-6 6.4 -6 3.6Z\" fill=\"#e8963a\"/><rect x=\"-6.2\" y=\"1.2\" width=\"12.4\" height=\"2.6\" rx=\"1.3\" fill=\"#7a3a24\"/><path d=\"M-5.6 0.6 L5.6 0.6 L4 2.6 L2.4 1.4 L-5.6 1.6Z\" fill=\"#ffd23a\"/><path d=\"M-6.4 -0.6 Q-4.8 1 -3.2 -0.4 Q-1.6 1 0 -0.4 Q1.6 1 3.2 -0.4 Q4.8 1 6.4 -0.6 L6.4 0.8 L-6.4 0.8Z\" fill=\"#7ad36a\"/><path d=\"M-6 -0.6 Q-6 -6.5 0 -6.5 Q6 -6.5 6 -0.6Z\" fill=\"#f0a64a\"/><path d=\"M-2.4 -4.2 l0.8 -0.3 M1 -5 l0.8 0.2 M3 -3.4 l0.6 -0.5 M-4 -2.6 l0.5 -0.6\" stroke=\"#fff4d6\" stroke-width=\"0.6\" stroke-linecap=\"round\"/>"))).V).Put("sushi", NewObj(6).Put("label", ((V)("Sushi"))).Put("d", ((V)("Pops it in whole, cheeks puffed, love."))).Put("hold", ((V)("two"))).Put("style", ((V)("whole"))).Put("react", ((V)("love"))).Put("svg", ((V)("<rect x=\"-4.5\" y=\"-1.5\" width=\"9\" height=\"4.5\" rx=\"2.2\" fill=\"#ffffff\" stroke=\"#e8e0d8\" stroke-width=\"0.4\"/><path d=\"M-4.8 -1 Q-5 -4 0 -4 Q5 -4 4.8 -1 Q0 0 -4.8 -1Z\" fill=\"#ff8a65\"/><path d=\"M-2.5 -3.6 L-1.5 -1 M0.5 -3.9 L1.3 -1.1 M3 -3.4 L3.4 -1.2\" stroke=\"#ffd1bf\" stroke-width=\"0.6\"/><rect x=\"-1.2\" y=\"-4\" width=\"2.4\" height=\"7\" fill=\"#2f4a3a\"/>"))).V).Put("watermelon", NewObj(9).Put("label", ((V)("Watermelon"))).Put("d", ((V)("Typewriter bites across, spits a seed."))).Put("hold", ((V)("two"))).Put("style", ((V)("typewriter"))).Put("n", ((V)(5D))).Put("seed", (true ? V.True : V.False)).Put("react", ((V)("yum"))).Put("bm", Invoke(Call(top_27, V.Undef, ((V)(5D)), ((V)((-0.2))), ((V)(10D)), ((V)(2D))), "concat", Call(top_27, V.Undef, ((V)(5D)), ((V)(1.8)), ((V)(9D)), ((V)(2.2))))).Put("svg", ((V)("<path d=\"M-7 0 A7 7 0 0 0 7 0 Z\" fill=\"#7ad36a\"/><path d=\"M-6 0 A6 6 0 0 0 6 0 Z\" fill=\"#ff5a6a\"/><ellipse cx=\"-2.6\" cy=\"2\" rx=\"0.4\" ry=\"0.7\" fill=\"#2a1a30\"/><ellipse cx=\"0\" cy=\"3.4\" rx=\"0.4\" ry=\"0.7\" fill=\"#2a1a30\"/><ellipse cx=\"2.6\" cy=\"2\" rx=\"0.4\" ry=\"0.7\" fill=\"#2a1a30\"/>"))).V).Put("strawberry", NewObj(7).Put("label", ((V)("Strawberry"))).Put("d", ((V)("One bite, blushes, hearts."))).Put("hold", ((V)("R"))).Put("style", ((V)("whole"))).Put("react", ((V)("love"))).Put("sc", ((V)(0.8))).Put("svg", ((V)("<path d=\"M0 6 Q-5.6 2 -4.6 -2.4 Q-3.6 -4.4 0 -3.6 Q3.6 -4.4 4.6 -2.4 Q5.6 2 0 6Z\" fill=\"#ff4b5c\"/><path d=\"M-3 -3.4 L-1 -5.6 L0 -3.8 L1 -5.6 L3 -3.4 Q0 -2.6 -3 -3.4Z\" fill=\"#5fc24a\"/><circle cx=\"-2\" cy=\"-0.6\" r=\"0.35\" fill=\"#ffe08a\"/><circle cx=\"1.4\" cy=\"0.4\" r=\"0.35\" fill=\"#ffe08a\"/><circle cx=\"-0.4\" cy=\"2.6\" r=\"0.35\" fill=\"#ffe08a\"/><circle cx=\"2.4\" cy=\"-1.8\" r=\"0.35\" fill=\"#ffe08a\"/>"))).V).Put("cupcake", NewObj(9).Put("label", ((V)("Cupcake"))).Put("d", ((V)("Licks the frosting, then bites."))).Put("hold", ((V)("two"))).Put("style", ((V)("lick"))).Put("n", ((V)(2D))).Put("then", (true ? V.True : V.False)).Put("react", ((V)("love"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-5.6))), ((V)(3.4))), Arr(((V)(2.4)), ((V)((-2.6))), ((V)(3.4))))).Put("svg", ((V)("<path d=\"M-4.6 0 L4.6 0 L3.4 6 L-3.4 6Z\" fill=\"#7cc8ff\"/><path d=\"M-2.4 0.4 L-1.8 5.6 M0 0.4 L0 5.6 M2.4 0.4 L1.8 5.6\" stroke=\"#5aa8e8\" stroke-width=\"0.5\"/><path d=\"M-5 0.4 Q-6 -2.6 -3 -3 Q-2.6 -6 0 -5.6 Q2.6 -6 3 -3 Q6 -2.6 5 0.4Z\" fill=\"#ffc0de\"/><circle cx=\"0\" cy=\"-6.4\" r=\"1.4\" fill=\"#ff3b4b\"/>"))).V).Put("noodles", NewObj(7).Put("label", ((V)("Noodles"))).Put("d", ((V)("Slurps long noodles from the bowl."))).Put("hold", ((V)("two"))).Put("style", ((V)("slurp"))).Put("react", ((V)("yum"))).Put("wins", Arr()).Put("svg", Fn((V _arrowThis628, int _argc616, V I_622, V t_623, V c_624, V x_625, V[] _rest617) => {
JsStrBuf h_629 = null;
V w_630 = default;
V y_626 = default;
V F_627 = default;
y_626 = (_argc616 > 4 ? _rest617[0] : V.Undef);
F_627 = (_argc616 > 5 ? _rest617[1] : V.Undef);
h_629 = new JsStrBuf("<path d=\"M-7 -1 L7 -1 Q6.4 6 0 6.4 Q-6.4 6 -7 -1Z\" fill=\"#ff8fa3\"/><path d=\"M-6 3 L6 3\" stroke=\"#ffffff\" stroke-width=\"0.6\" opacity=\"0.7\"/><path d=\"M-6 -1.2 Q-3 -3 0 -1.4 Q3 -3 6 -1.2\" stroke=\"#ffe08a\" stroke-width=\"1.2\" fill=\"none\"/>");
w_630 = Invoke(((F_627 is var _t639 && !Truthy(_t639) ? _t639 : Get(F_627, "wins")) is var _t640 && Truthy(_t640) ? _t640 : Get(Get(FOODS_28, "noodles"), "wins")), "find", Fn((V _arrowThis638, int _argc631, V q_637, V _a634, V _a635, V _a636, V[] _rest632) => {
return ((Ge(t_623, GetIdx(q_637, 0D)) && Le(t_623, GetIdx(q_637, 1D))) ? V.True : V.False);
}, 1, "", true));
if (Truthy((w_630 is var _t641 && !Truthy(_t641) ? _t641 : Get(Get(I_622, "W"), "mouth")))) {
double u_642 = 0;
double mx_643 = 0;
double my_644 = 0;
double by_645 = 0;
u_642 = ((ToNum(t_623) - ToNum(GetIdx(w_630, 0D))) / (ToNum(GetIdx(w_630, 1D)) - ToNum(GetIdx(w_630, 0D))));
mx_643 = (ToNum(GetIdx(Get(Get(I_622, "W"), "mouth"), 0D)) - ToNum(x_625));
my_644 = ((ToNum(GetIdx(Get(Get(I_622, "W"), "mouth"), 1D)) - ToNum(y_626)) + 0.5);
by_645 = ((-1.5) + (((my_644 + 1.5) * u_642) * 0.92));
h_629.S("<path d=\"M0 ").V(Call(r2_10, V.Undef, ((V)(by_645)))).S(" Q").V(Call(r2_10, V.Undef, ((V)(((mx_643 * 0.5) + (FdLibm.Sin((ToNum(t_623) / 60D)) * 1.4)))))).S(" ").V(Call(r2_10, V.Undef, ((V)(((by_645 + my_644) / 2D))))).S(" ").V(Call(r2_10, V.Undef, ((V)(mx_643)))).S(" ").V(Call(r2_10, V.Undef, ((V)(my_644)))).S("\" stroke=\"#ffe08a\" stroke-width=\"1.1\" fill=\"none\" stroke-linecap=\"round\"/>");
}
return ((V)(h_629.Str));
return default;
}, 6, "svg", true)).V).Put("corn", NewObj(8).Put("label", ((V)("Corn on the cob"))).Put("d", ((V)("Typewriter-style rows, ding at each end."))).Put("hold", ((V)("two"))).Put("style", ((V)("typewriter"))).Put("n", ((V)(6D))).Put("react", ((V)("yum"))).Put("bm", Invoke(Call(top_27, V.Undef, ((V)(6D)), ((V)((-2.6))), ((V)(11D)), ((V)(1.6))), "concat", Call(top_27, V.Undef, ((V)(6D)), ((V)((-0.6))), ((V)(11D)), ((V)(1.8))))).Put("svg", ((V)("<path d=\"M-7 0 L-9.6 -2.6 L-9 2.6Z M7 0 L9.6 -2.6 L9 2.6Z\" fill=\"#9be38a\"/><rect x=\"-7\" y=\"-2.8\" width=\"14\" height=\"5.6\" rx=\"2.8\" fill=\"#ffd84a\"/><path d=\"M-5 -2.6 L-5 2.6 M-2.5 -2.8 L-2.5 2.8 M0 -2.8 L0 2.8 M2.5 -2.8 L2.5 2.8 M5 -2.6 L5 2.6 M-7 0 L7 0\" stroke=\"#f0b52a\" stroke-width=\"0.4\"/>"))).V).Put("lollipop", NewObj(9).Put("label", ((V)("Lollipop"))).Put("d", ((V)("Five swirly licks."))).Put("hold", ((V)("R"))).Put("style", ((V)("lick"))).Put("n", ((V)(5D))).Put("swirl", (true ? V.True : V.False)).Put("react", ((V)("love"))).Put("grip", Arr(((V)(0D)), ((V)(10.5)), ((V)((-30D))))).Put("svg", Fn((V _arrowThis655, int _argc646, V I_652, V t_653, V c_654, V _a651, V[] _rest647) => {
double k_656 = 0;
k_656 = (1D - (0.06 * Min(5D, ToNum((Get(c_654, "lick") is var _t657 && Truthy(_t657) ? _t657 : ((V)(0D)))))));
return ((V)(JsStrBuf.Begin().S("<path d=\"M0 3 L0 ").N((Truthy(Get(I_652, "gripStick")) ? 14D : 10D)).S("\" stroke=\"#ffffff\" stroke-width=\"1.2\" stroke-linecap=\"round\"/><g transform=\"scale(").V(Call(r2_10, V.Undef, ((V)(k_656)))).S(")\"><circle cx=\"0\" cy=\"-1\" r=\"4.6\" fill=\"#ff7fc8\"/><path d=\"M0 -1 m-3 0 a3 3 0 1 1 3 3 a2 2 0 1 1 -2 -2 a1 1 0 1 1 1 1\" stroke=\"#fff\" stroke-width=\"0.9\" fill=\"none\"/></g>").End()));
return default;
}, 3, "svg", true)).V).Put("fish", NewObj(9).Put("label", ((V)("Fish"))).Put("d", ((V)("Jumps with excitement, then gobbles it up."))).Put("hold", ((V)("two"))).Put("style", ((V)("gobble"))).Put("n", ((V)(4D))).Put("react", ((V)("yum"))).Put("bm", Arr(Arr(((V)((-5D))), ((V)(0D)), ((V)(2.6))), Arr(((V)((-2.4))), ((V)((-0.4))), ((V)(2.8))), Arr(((V)(0.6)), ((V)(0D)), ((V)(2.8))), Arr(((V)(3.6)), ((V)(0D)), ((V)(3D))))).Put("pre", Fn((V _self658, int _argc659, V t_665, V _a662, V _a663, V _a664, V[] _rest660) => {
if (_self658.IsNullish) _self658 = GlobalV;
Invoke(Invoke(Invoke(Invoke(t_665, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.18))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(6).Put("sq", ((V)((-0.15)))).Put("lift", ((V)(9D))).Put("wide", ((V)(1D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("open", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.2))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(5).Put("sq", ((V)(0D))).Put("wide", ((V)(0.3))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "pre", false)).Put("svg", ((V)("<path d=\"M-6 0 Q-2 -4.6 3.6 -0.4 L7 -3.4 L6.4 0 L7 3.4 L3.6 0.4 Q-2 4.6 -6 0Z\" fill=\"#7cc8ff\"/><path d=\"M-1 -2 Q0 0 -1 2\" stroke=\"#5aa8e8\" stroke-width=\"0.6\" fill=\"none\"/><circle cx=\"-3.6\" cy=\"-0.8\" r=\"0.8\" fill=\"#2a1a30\"/>"))).V).Put("pepper", NewObj(10).Put("label", ((V)("Hot pepper"))).Put("d", ((V)("One bite, turns red, steam, fans her tongue."))).Put("hold", ((V)("R"))).Put("style", ((V)("chomp"))).Put("n", ((V)(1D))).Put("chew", ((V)(2D))).Put("react", ((V)("spicy"))).Put("rot", ((V)(20D))).Put("bm", Arr(Arr(((V)(0.5)), ((V)((-3.4))), ((V)(2.4))))).Put("svg", ((V)("<path d=\"M-1 -4 Q4 -3 3 3 Q2 7 -2 8 Q1 4 0 0 Q-0.6 -2.6 -1 -4Z\" fill=\"#ff3b30\"/><path d=\"M-1 -4 Q-2 -6 0 -7\" stroke=\"#4caf50\" stroke-width=\"1.2\" fill=\"none\" stroke-linecap=\"round\"/>"))).V).Put("lemon", NewObj(9).Put("label", ((V)("Lemon"))).Put("d", ((V)("One bite, huge sour pucker, shivers."))).Put("hold", ((V)("R"))).Put("style", ((V)("chomp"))).Put("n", ((V)(1D))).Put("chew", ((V)(1D))).Put("react", ((V)("sour"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-3.6))), ((V)(2.6))))).Put("svg", ((V)("<path d=\"M-5.4 0 Q-5.4 -4 0 -4 Q5.4 -4 5.4 0 Q5.4 4 0 4 Q-5.4 4 -5.4 0Z M5.2 -0.7 L6.8 0 L5.2 0.7Z M-5.2 -0.7 L-6.8 0 L-5.2 0.7Z\" fill=\"#ffe14a\"/><ellipse cx=\"-1.8\" cy=\"-1.6\" rx=\"1.4\" ry=\"0.7\" fill=\"#ffffff\" opacity=\"0.5\"/>"))).V).Put("juice", NewObj(7).Put("label", ((V)("Juice box"))).Put("d", ((V)("Sips through the straw, squeezes the box."))).Put("hold", ((V)("R"))).Put("style", ((V)("sip"))).Put("react", ((V)("yum"))).Put("mp", Call(hand_15, V.Undef, ((V)(1D)), ((V)(17D)), ((V)((-3D))))).Put("svg", Fn((V _arrowThis675, int _argc666, V I_672, V t_673, V c_674, V _a671, V[] _rest667) => {
double k_676 = 0;
k_676 = (Truthy(Get(c_674, "crumple")) ? 0.75 : 1D);
return ((V)(JsStrBuf.Begin().S("<g transform=\"scale(").N(k_676).S(" 1)\"><rect x=\"-3.4\" y=\"-3\" width=\"6.8\" height=\"9\" rx=\"0.8\" fill=\"#9be38a\"/><rect x=\"-2.4\" y=\"0\" width=\"4.8\" height=\"3.6\" rx=\"0.6\" fill=\"#ffffff\"/><circle cx=\"0\" cy=\"1.8\" r=\"1.1\" fill=\"#ff9a3a\"/></g><path d=\"M1.4 -3 L2.4 -8.4\" stroke=\"#ff5cc6\" stroke-width=\"0.9\" stroke-linecap=\"round\"/>").End()));
return default;
}, 3, "svg", true)).V).Put("popsicle", NewObj(9).Put("label", ((V)("Popsicle"))).Put("d", ((V)("Licks, bites, brain freeze."))).Put("hold", ((V)("R"))).Put("style", ((V)("lick"))).Put("n", ((V)(3D))).Put("then", (true ? V.True : V.False)).Put("react", ((V)("freeze"))).Put("bm", Arr(Arr(((V)(0D)), ((V)((-6D))), ((V)(3.2))))).Put("svg", ((V)("<rect x=\"-0.8\" y=\"3.6\" width=\"1.6\" height=\"5\" rx=\"0.8\" fill=\"#f0c890\"/><rect x=\"-3.4\" y=\"-6\" width=\"6.8\" height=\"10\" rx=\"3.4\" fill=\"#7cc8ff\"/><rect x=\"-3.4\" y=\"-1\" width=\"6.8\" height=\"5\" rx=\"0\" fill=\"#ff8fc8\"/><rect x=\"-3.4\" y=\"-6\" width=\"6.8\" height=\"10\" rx=\"3.4\" fill=\"none\" stroke=\"#ffffff\" stroke-width=\"0.4\"/>"))).V).V;
meal_29 = Fn((V _arrowThis685, int _argc677, V key_683, V f_684, V _a681, V _a682, V[] _rest678) => {
V t_686 = default;
V H_687 = default;
t_686 = Call(TL_13, V.Undef);
H_687 = GetK(HOLD_20, Get(f_684, "hold"));
Invoke(Invoke(Invoke(Invoke(t_686, "e", ((V)("food"))), "to", ((V)(320D)), Call(o_17, V.Undef, Get(H_687, "chest"), NewObj(6).Put("wide", ((V)(0.5))).Put("ly", ((V)(0.6))).Put("pitch", ((V)((-0.25)))).Put("sq", ((V)(0.06))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V), ((V)("o"))), "to", ((V)(300D)), NewObj(6).Put("wide", ((V)(0D))).Put("smile", ((V)(0.7))).Put("hap", ((V)(0.6))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
if (Truthy(Get(f_684, "pre"))) {
Invoke(f_684, "pre", t_686, H_687);
}
InvokeK(STYLE_24, Get(f_684, "style"), t_686, H_687, f_684);
InvokeK(REACT_25, Get(f_684, "react"), t_686);
Invoke(t_686, "rest", ((V)(450D)));
return Invoke(t_686, "done", NewObj(1).Put("prop", Call(foodProp_26, V.Undef, f_684, key_683)).V);
return default;
}, 2, "", true);
Invoke(Object_keys(FOODS_28), "forEach", Fn((V _arrowThis695, int _argc688, V k_694, V _a691, V _a692, V _a693, V[] _rest689) => {
SetK(ST_18, ((V)(JsStrBuf.Begin().S("eat_").V(k_694).End())), Call(meal_29, V.Undef, k_694, GetK(FOODS_28, k_694)));
return default;
}, 1, "", true));
Set(R_8, "FOODHOLD", NewObj(0).V);
Invoke(Object_keys(FOODS_28), "forEach", Fn((V _arrowThis703, int _argc696, V k_702, V _a699, V _a700, V _a701, V[] _rest697) => {
SetK(Get(R_8, "FOODHOLD"), ((V)(JsStrBuf.Begin().S("eat_").V(k_702).End())), Get(GetK(FOODS_28, k_702), "hold"));
return default;
}, 1, "", true));
Set(R_8, "EATLIB", NewObj(4).Put("FOODS", FOODS_28).Put("foodProp", foodProp_26).Put("HOLD", HOLD_20).Put("REACT", REACT_25).V);
toolProp_30 = Fn((V _arrowThis712, int _argc704, V svg_710, V opt_711, V _a708, V _a709, V[] _rest705) => {
return Fn((V _arrowThis721, int _argc713, V I_719, V t_720, V _a717, V _a718, V[] _rest714) => {
V c_722 = default;
V W_723 = default;
V P_724 = default;
double sq_725 = 0;
c_722 = Get(I_719, "ctr");
W_723 = Get(I_719, "W");
if (Truthy((Get(c_722, "toolgone") is var _t726 && Truthy(_t726) ? _t726 : (!(Truthy(Get(W_723, "pawR"))) ? V.True : V.False)))) {
return ((V)(""));
}
P_724 = (SEqS(Get(opt_711, "hold"), "two") ? Arr(((V)((ToNum(Add(GetIdx(Get(W_723, "pawL"), 0D), GetIdx(Get(W_723, "pawR"), 0D))) / 2D))), ((V)(((ToNum(Add(GetIdx(Get(W_723, "pawL"), 1D), GetIdx(Get(W_723, "pawR"), 1D))) / 2D) - 3D)))) : GetK(W_723, ((V)((SEqS(Get(opt_711, "hold"), "L") ? "pawL" : "pawR")))));
sq_725 = (Truthy((Get(opt_711, "squish") is var _t727 && !Truthy(_t727) ? _t727 : Get(Get(I_719, "ctT"), "squeak"))) ? (1D - (0.3 * Max(0D, (1D - ((ToNum(Invoke(G("performance"), "now")) - ToNum(Get(Get(I_719, "ctT"), "squeak"))) / 260D))))) : 1D);
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(r2_10, V.Undef, Add(GetIdx(P_724, 0D), (Get(opt_711, "dx") is var _t728 && Truthy(_t728) ? _t728 : ((V)(0D)))))).S(" ").V(Call(r2_10, V.Undef, Add(GetIdx(P_724, 1D), (Get(opt_711, "dy") is var _t729 && Truthy(_t729) ? _t729 : ((V)(0D)))))).S(") rotate(").V((Get(opt_711, "rot") is var _t730 && Truthy(_t730) ? _t730 : ((V)(0D)))).S(") scale(").V(Call(r2_10, V.Undef, Call(SM_11, V.Undef, ((V)((ToNum(t_720) / 220D)))))).S(" ").V(Call(r2_10, V.Undef, ((V)((ToNum(Call(SM_11, V.Undef, ((V)((ToNum(t_720) / 220D))))) * sq_725))))).S(")\">").V((string.Equals(Typeof(svg_710), "function") ? Call(svg_710, V.Undef, I_719, t_720) : svg_710)).S("</g>").End()));
return default;
}, 2, "", true);
}, 2, "", true);
SPONGE_31 = ((V)("<rect x=\"-4\" y=\"-3\" width=\"8\" height=\"6\" rx=\"2\" fill=\"#ffd84a\" stroke=\"#e8b52a\" stroke-width=\"0.5\"/><circle cx=\"-1.6\" cy=\"-0.8\" r=\"0.6\" fill=\"#e8b52a\"/><circle cx=\"1.4\" cy=\"0.9\" r=\"0.5\" fill=\"#e8b52a\"/><circle cx=\"2\" cy=\"-1.4\" r=\"0.4\" fill=\"#e8b52a\"/><circle cx=\"-2.6\" cy=\"-3\" r=\"1.2\" fill=\"#ffffff\"/><circle cx=\"-0.8\" cy=\"-3.4\" r=\"1\" fill=\"#ffffff\"/>"));
BRUSH_32 = ((V)("<rect x=\"-1\" y=\"-14\" width=\"2\" height=\"13\" rx=\"1\" fill=\"#c88a5a\"/><rect x=\"-3.2\" y=\"-17.5\" width=\"6.4\" height=\"4\" rx=\"1.6\" fill=\"#7cc8ff\"/><path d=\"M-2.6 -17.5 L-2.6 -19.4 M-1 -17.5 L-1 -19.6 M0.6 -17.5 L0.6 -19.6 M2.2 -17.5 L2.2 -19.4\" stroke=\"#ffffff\" stroke-width=\"0.7\"/>"));
DUCK_33 = ((V)("<ellipse cx=\"0\" cy=\"1\" rx=\"5\" ry=\"3.6\" fill=\"#ffd23a\"/><path d=\"M-4.6 0 Q-6.4 -1.8 -5 -3 Q-4.2 -1.2 -3 -1Z\" fill=\"#ffd23a\"/><circle cx=\"2.4\" cy=\"-2.6\" r=\"2.8\" fill=\"#ffd23a\"/><path d=\"M4.8 -2.6 L7.4 -2 L4.8 -1.2Z\" fill=\"#ff9a3a\"/><circle cx=\"3.2\" cy=\"-3.2\" r=\"0.6\" fill=\"#2a1a30\"/><path d=\"M-1.6 0.4 Q0 2 1.6 0.4\" stroke=\"#f0b52a\" stroke-width=\"0.6\" fill=\"none\"/>"));
WAND_34 = ((V)("<path d=\"M0 0 L0 9\" stroke=\"#ff5cc6\" stroke-width=\"1\" stroke-linecap=\"round\"/><circle cx=\"0\" cy=\"-2.4\" r=\"2.6\" fill=\"rgba(220,245,255,0.45)\" stroke=\"#ff5cc6\" stroke-width=\"0.9\"/>"));
FOAM_35 = Arr(Arr(((V)((-12D))), ((V)(4D)), ((V)(5D))), Arr(((V)((-4D))), ((V)((-1D))), ((V)(6D))), Arr(((V)(5D)), ((V)(0D)), ((V)(5.5))), Arr(((V)(13D)), ((V)(5D)), ((V)(4.5))), Arr(((V)(0D)), ((V)(6D)), ((V)(5D))), Arr(((V)((-8D))), ((V)(8D)), ((V)(4D))), Arr(((V)(9D)), ((V)(9D)), ((V)(4D))), Arr(((V)((-15D))), ((V)(10D)), ((V)(3.4))), Arr(((V)(16D)), ((V)(11D)), ((V)(3.2))));
foamFx_36 = Fn((V _arrowThis739, int _argc731, V t0_737, V t1_738, V _a735, V _a736, V[] _rest732) => {
return Fn((V _arrowThis748, int _argc740, V I_746, V t_747, V _a744, V _a745, V[] _rest741) => {
double n_749 = 0;
double fade_750 = 0;
V x_751 = default;
V y_752 = default;
JsStrBuf h_753 = null;
if (Lt(t_747, t0_737)) {
return ((V)(""));
}
n_749 = Min(ToNum(Get(FOAM_35, "length")), (System.Math.Floor(((ToNum(t_747) - ToNum(t0_737)) / 260D)) + 1D));
fade_750 = (1D - ToNum(Call(SM_11, V.Undef, ((V)(((ToNum(t_747) - ToNum(t1_738)) / 500D))))));
if ((fade_750 <= 0D)) {
return ((V)(""));
}
{ V _t754 = (Get(Get(I_746, "W"), "head") is var _t755 && Truthy(_t755) ? _t755 : Arr(((V)(50D)), ((V)(17D))));
{ V _t756 = ListOf(_t754);
{ V _t757 = GetIdx(_t756, 0D);
x_751 = _t757; }
{ V _t758 = GetIdx(_t756, 1D);
y_752 = _t758; }
} }
h_753 = new JsStrBuf(JsStrBuf.Begin().S("<g opacity=\"").V(Call(r2_10, V.Undef, ((V)(fade_750)))).S("\">").End());
{
double i_759 = 0;
i_759 = 0D;
while (true) {
if (!((i_759 < n_749))) break;
V f_761 = default;
V g_762 = default;
double w_763 = 0;
f_761 = GetIdx(FOAM_35, i_759);
g_762 = Call(SM_11, V.Undef, ((V)((((ToNum(t_747) - ToNum(t0_737)) - (i_759 * 260D)) / 300D))));
w_763 = (FdLibm.Sin(((ToNum(t_747) / 300D) + i_759)) * 0.4);
h_753.S("<circle cx=\"").V(Call(r2_10, V.Undef, Add(x_751, GetIdx(f_761, 0D)))).S("\" cy=\"").V(Call(r2_10, V.Undef, ((V)((ToNum(Add(y_752, GetIdx(f_761, 1D))) - 2D))))).S("\" r=\"").V(Call(r2_10, V.Undef, ((V)(((ToNum(GetIdx(f_761, 2D)) * ToNum(g_762)) + w_763))))).S("\" fill=\"#ffffff\" stroke=\"#d6f2fc\" stroke-width=\"0.6\"/>");
i_759++;
}
}
return ((V)(string.Concat(h_753.Str, "</g>")));
return default;
}, 2, "", true);
}, 2, "", true);
B_37 = NewObj(0).V;
Set(B_37, "belly", Arr(((V)("Scrub the belly")), ((V)("Sponge circles on her tummy, bubbles.")), Call(Fn((V _arrowThis770, int _argc764, V _a766, V _a767, V _a768, V _a769, V[] _rest765) => {
V t_771 = default;
V a_772 = default;
V b_773 = default;
t_771 = Call(TL_13, V.Undef);
Invoke(t_771, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(9D)), ((V)(0D))), NewObj(3).Put("pitch", ((V)((-0.4)))).Put("ly", ((V)(0.7))).Put("smile", ((V)(0.5))).V), ((V)("io")));
a_772 = Get(t_771, "t");
Invoke(Invoke(t_771, "em", ((V)(2600D)), ((V)(200D)), ((V)("bubble")), ((V)("belly")), ((V)(1D))), "osc", ((V)(2600D)), ((V)(6D)), NewObj(4).Put("hRx", ((V)((-13D)))).Put("hRy", ((V)(3D))).Put("lean", ((V)(0.8))).Put("htilt", ((V)(2D))).V, NewObj(4).Put("hRx", ((V)((-6D)))).Put("hRy", ((V)((-3D)))).Put("lean", ((V)((-0.8)))).Put("htilt", ((V)((-2D)))).V, ((V)("s")));
b_773 = Get(t_771, "t");
Invoke(Invoke(Invoke(t_771, "at", a_772), "osc", ((V)(2600D)), ((V)(3D)), NewObj(2).Put("sq", ((V)(0.04))).Put("hap", ((V)(0.7))).V, NewObj(2).Put("sq", ((V)(0D))).Put("hap", ((V)(0.3))).V, ((V)("s"))), "at", b_773);
Invoke(Invoke(Invoke(Invoke(t_771, "to", ((V)(300D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(9D)), ((V)(0D))), NewObj(2).Put("pitch", ((V)((-0.1)))).Put("ly", ((V)(0.2))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(4).Put("sq", ((V)(0.06))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0.1))).V), "e", ((V)("toolgone"))), "rest", ((V)(450D)));
return Invoke(t_771, "done", NewObj(1).Put("prop", Call(toolProp_30, V.Undef, SPONGE_31, NewObj(1).Put("dy", ((V)((-1D)))).V)).V);
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "shampoo", Arr(((V)("Shampoo")), ((V)("Rubs her head with both paws, foam piles up.")), Call(Fn((V _arrowThis780, int _argc774, V _a776, V _a777, V _a778, V _a779, V[] _rest775) => {
V t_781 = default;
V a_782 = default;
V b_783 = default;
t_781 = Call(TL_13, V.Undef);
Invoke(t_781, "to", ((V)(450D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(2D)), ((V)((-31D)))), NewObj(7).Put("armL", ((V)(25D))).Put("armR", ((V)(25D))).Put("close", ((V)(1D))).Put("smile", ((V)(0.6))).Put("pitch", ((V)((-0.15)))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V), ((V)("io")));
a_782 = Get(t_781, "t");
Invoke(Invoke(t_781, "em", ((V)(3200D)), ((V)(260D)), ((V)("bubble")), ((V)("head")), ((V)(1D))), "osc", ((V)(3200D)), ((V)(7D)), NewObj(4).Put("hLy", ((V)((-35D)))).Put("hRy", ((V)((-28D)))).Put("htilt", ((V)(3D))).Put("sq", ((V)(0.03))).V, NewObj(4).Put("hLy", ((V)((-28D)))).Put("hRy", ((V)((-35D)))).Put("htilt", ((V)((-3D)))).Put("sq", ((V)(0D))).V, ((V)("s")));
b_783 = Get(t_781, "t");
Invoke(Invoke(Invoke(t_781, "at", a_782), "osc", ((V)(3200D)), ((V)(4D)), NewObj(2).Put("open", ((V)(0.15))).Put("wag", ((V)(12D))).V, NewObj(2).Put("open", ((V)(0D))).Put("wag", ((V)((-12D)))).V, ((V)("s"))), "at", b_783);
Invoke(Invoke(Invoke(Invoke(Invoke(t_781, "to", ((V)(400D)), NewObj(9).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(3D)), NewObj(2).Put("turn", ((V)(0.4))).Put("htilt", ((V)((-5D)))).V, NewObj(2).Put("turn", ((V)((-0.4)))).Put("htilt", ((V)(5D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("drop")), ((V)("head")), ((V)(6D))), "to", ((V)(300D)), NewObj(5).Put("close", ((V)(0D))).Put("turn", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), "rest", ((V)(450D)));
return Invoke(t_781, "done", NewObj(1).Put("fx", Call(foamFx_36, V.Undef, ((V)(500D)), Add(b_783, ((V)(300D))))).V);
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "face", Arr(((V)("Wash the face")), ((V)("Paws rub her cheeks, then splash and blink.")), Call(Fn((V _arrowThis790, int _argc784, V _a786, V _a787, V _a788, V _a789, V[] _rest785) => {
V t_791 = default;
t_791 = Call(TL_13, V.Undef);
Invoke(t_791, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(3D)), ((V)((-17D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(3D)), ((V)((-17D)))), NewObj(4).Put("sqz", ((V)(0.7))).Put("mw", ((V)(0.6))).Put("open", ((V)(0.08))).Put("puff", ((V)(0.2))).V), ((V)("io")));
Invoke(Invoke(t_791, "em", ((V)(2000D)), ((V)(300D)), ((V)("bubble")), ((V)("nose")), ((V)(1D))), "osc", ((V)(2000D)), ((V)(5D)), NewObj(5).Put("hLx", ((V)(6D))).Put("hLy", ((V)((-20D)))).Put("hRx", ((V)((-2D)))).Put("hRy", ((V)((-15D)))).Put("htilt", ((V)(3D))).V, NewObj(5).Put("hLx", ((V)(2D))).Put("hLy", ((V)((-15D)))).Put("hRx", ((V)((-6D)))).Put("hRy", ((V)((-20D)))).Put("htilt", ((V)((-3D)))).V, ((V)("s")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_791, "to", ((V)(160D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(7D)), ((V)((-25D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(7D)), ((V)((-25D)))), NewObj(1).Put("sq", ((V)(0.06))).V), ((V)("o"))), "e", ((V)("emit")), ((V)("splash")), ((V)("nose"))), "to", ((V)(300D)), NewObj(5).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(4).Put("sqz", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).V), "e", ((V)("blink2"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("turn", ((V)(0.35))).Put("htilt", ((V)((-4D)))).V, NewObj(2).Put("turn", ((V)((-0.35)))).Put("htilt", ((V)(4D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("drop")), ((V)("eyeL")), ((V)(3D))), "e", ((V)("emit")), ((V)("drop")), ((V)("eyeR")), ((V)(3D))), "to", ((V)(300D)), NewObj(4).Put("turn", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), "rest", ((V)(450D)));
return Invoke(t_791, "done");
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "back", Arr(((V)("Scrub the back")), ((V)("Reaches behind with a brush, twisting.")), Call(Fn((V _arrowThis798, int _argc792, V _a794, V _a795, V _a796, V _a797, V[] _rest793) => {
V t_799 = default;
V a_800 = default;
V b_801 = default;
t_799 = Call(TL_13, V.Undef);
Invoke(t_799, "to", ((V)(500D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)((-10D))), ((V)((-8D))), ((V)((-10.5)))), NewObj(6).Put("armR", ((V)(150D))).Put("spin", ((V)((-18D)))).Put("lx", ((V)(0.9))).Put("turn", ((V)(0.45))).Put("tongue", ((V)(0.5))).Put("footL", ((V)(2D))).V), ((V)("io")));
a_800 = Get(t_799, "t");
Invoke(Invoke(t_799, "em", ((V)(2800D)), ((V)(240D)), ((V)("bubble")), ((V)("sideR")), ((V)(1D))), "osc", ((V)(2800D)), ((V)(6D)), NewObj(3).Put("armR", ((V)(135D))).Put("spin", ((V)((-24D)))).Put("sq", ((V)(0.03))).V, NewObj(3).Put("armR", ((V)(168D))).Put("spin", ((V)((-12D)))).Put("sq", ((V)((-0.02)))).V, ((V)("s")));
b_801 = Get(t_799, "t");
Invoke(Invoke(Invoke(t_799, "at", a_800), "osc", ((V)(2800D)), ((V)(4D)), NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).V, NewObj(2).Put("footL", ((V)(2D))).Put("footR", ((V)(0D))).V, ((V)("s"))), "at", b_801);
Invoke(Invoke(Invoke(t_799, "to", ((V)(450D)), NewObj(13).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("hRz", ((V)(0D))).Put("armR", ((V)(0D))).Put("spin", ((V)(0D))).Put("lx", ((V)(0D))).Put("turn", ((V)(0D))).Put("tongue", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "e", ((V)("toolgone"))), "rest", ((V)(450D)));
return Invoke(t_799, "done", NewObj(2).Put("propZ", ((V)(0.5))).Put("prop", Call(toolProp_30, V.Undef, BRUSH_32, NewObj(2).Put("dy", ((V)(1D))).Put("rot", ((V)(25D))).V)).V);
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "splash", Arr(((V)("Splash around")), ((V)("Slaps the water with both paws, laughing.")), Call(Fn((V _arrowThis808, int _argc802, V _a804, V _a805, V _a806, V _a807, V[] _rest803) => {
V t_809 = default;
t_809 = Call(TL_13, V.Undef);
Invoke(t_809, "to", ((V)(250D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V);
{
double i_810 = 0;
i_810 = 0D;
while (true) {
if (!((i_810 < 6D))) break;
V two_812 = default;
two_812 = (((i_810 % 3D) != 1D) ? V.True : V.False);
Invoke(Invoke(Invoke(Invoke(Invoke(t_809, "to", ((V)(200D)), NewObj(6).Put("armL", ((V)((Truthy((two_812 is var _t813 && Truthy(_t813) ? _t813 : ((V)((i_810 % 2D))))) ? 70D : 10D)))).Put("armR", ((V)((Truthy((two_812 is var _t814 && Truthy(_t814) ? _t814 : (!(NumTruthy((i_810 % 2D))) ? V.True : V.False))) ? 70D : 10D)))).Put("sq", ((V)((-0.05)))).Put("lift", ((V)(2D))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(110D)), NewObj(6).Put("armL", ((V)((-12D)))).Put("armR", ((V)((-12D)))).Put("sq", ((V)(0.12))).Put("lift", ((V)(0D))).Put("earL", ((V)(8D))).Put("earR", ((V)(8D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("splash")), ((V)("pawL"))), "e", ((V)("emit")), ((V)("splash")), ((V)("pawR"))), "wait", ((V)(120D)));
i_810++;
}
}
Invoke(Invoke(Invoke(t_809, "to", ((V)(300D)), NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("open", ((V)(0.2))).V, ((V)("io"))), "osc", ((V)(600D)), ((V)(2D)), NewObj(1).Put("sq", ((V)(0.05))).V, NewObj(1).Put("sq", ((V)(0D))).V), "rest", ((V)(450D)));
return Invoke(t_809, "done");
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "duck", Arr(((V)("Rubber duck")), ((V)("Squeezes it, it squeaks, it swims, she kisses it.")), Call(Fn((V _arrowThis821, int _argc815, V _a817, V _a818, V _a819, V _a820, V[] _rest816) => {
V t_822 = default;
t_822 = Call(TL_13, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_822, "to", ((V)(350D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(7D)), ((V)((-6D)))), NewObj(3).Put("ly", ((V)(0.5))).Put("pitch", ((V)((-0.2)))).Put("smile", ((V)(0.6))).V), ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(120D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(10D)), ((V)((-6D)))), NewObj(1).Put("sq", ((V)(0.05))).V), ((V)("o"))), "e", ((V)("squeak"))), "to", ((V)(150D)), NewObj(4).Put("wide", ((V)(1D))).Put("sq", ((V)((-0.03)))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).V, ((V)("o"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(7D)), ((V)((-6D)))), NewObj(6).Put("wide", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V), ((V)("io"))), "osc", ((V)(400D)), ((V)(2D)), NewObj(1).Put("sq", ((V)(0.05))).V, NewObj(1).Put("sq", ((V)(0D))).V), "to", ((V)(120D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(10D)), ((V)((-6D))))), ((V)("o"))), "e", ((V)("squeak"))), "to", ((V)(200D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(7D)), ((V)((-6D))))), ((V)("io"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(4).Put("hLx", ((V)(13D))).Put("hRx", ((V)((-1D)))).Put("lx", ((V)(0.6))).Put("turn", ((V)(0.2))).V, NewObj(4).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-13D)))).Put("lx", ((V)((-0.6)))).Put("turn", ((V)((-0.2)))).V, ((V)("s"))), "to", ((V)(400D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(10D)), ((V)((-12D)))), NewObj(7).Put("lx", ((V)(0D))).Put("turn", ((V)(0D))).Put("pitch", ((V)((-0.15)))).Put("mw", ((V)(0.4))).Put("blush", ((V)(1D))).Put("hap", ((V)(0.6))).Put("open", ((V)(0D))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("mouth")), ((V)(2D))), "wait", ((V)(400D))), "to", ((V)(350D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(7D)), ((V)((-6D)))), NewObj(1).Put("mw", ((V)(1D))).V), ((V)("io"))), "e", ((V)("toolgone"))), "rest", ((V)(450D)));
return Invoke(t_822, "done", NewObj(1).Put("prop", Call(toolProp_30, V.Undef, DUCK_33, NewObj(2).Put("hold", ((V)("two"))).Put("squish", (true ? V.True : V.False)).V)).V);
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "bubbles", Arr(((V)("Blow bubbles")), ((V)("Puffs her cheeks, blows big bubbles, pops one.")), Call(Fn((V _arrowThis829, int _argc823, V _a825, V _a826, V _a827, V _a828, V[] _rest824) => {
V t_830 = default;
t_830 = Call(TL_13, V.Undef);
Invoke(t_830, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-8D))))), ((V)("io")));
{
double i_831 = 0;
i_831 = 0D;
while (true) {
if (!((i_831 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(Invoke(t_830, "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-13D)))), NewObj(4).Put("puff", ((V)(1D))).Put("pitch", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).V), ((V)("io"))), "to", ((V)(450D)), NewObj(4).Put("puff", ((V)(0D))).Put("mw", ((V)(0.35))).Put("open", ((V)(0.18))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("bigbubble")), ((V)("pawR"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("pawR")), ((V)(2D))), "to", ((V)(500D)), NewObj(8).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("sq", ((V)(0D))).Put("lx", ((V)(0.7))).Put("ly", ((V)((-0.7)))).Put("pitch", ((V)(0.3))).Put("hap", ((V)(0.6))).Put("smile", ((V)(0.8))).V, ((V)("io")));
i_831++;
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_830, "to", ((V)(260D)), NewObj(2).Put("armL", ((V)(120D))).Put("hLy", ((V)((-6D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), Arr(((V)(70D)), ((V)(26D))), ((V)(5D))), "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hap", ((V)(1D))).Put("open", ((V)(0.35))).V, ((V)("io"))), "e", ((V)("toolgone"))), "rest", ((V)(450D)));
return Invoke(t_830, "done", NewObj(1).Put("prop", Call(toolProp_30, V.Undef, WAND_34, NewObj(2).Put("dx", ((V)((-1D)))).Put("dy", ((V)((-4D)))).V)).V);
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "shake", Arr(((V)("Shake dry")), ((V)("Wet-dog shake from head to tail, then fluffy.")), Call(Fn((V _arrowThis839, int _argc833, V _a835, V _a836, V _a837, V _a838, V[] _rest834) => {
V t_840 = default;
t_840 = Call(TL_13, V.Undef);
Invoke(Invoke(t_840, "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0.1))).Put("close", ((V)(0.6))).Put("earL", ((V)(6D))).Put("earR", ((V)(6D))).V, ((V)("io"))), "em", ((V)(1300D)), ((V)(70D)), ((V)("splash")), ((V)("body")), ((V)(2D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_840, "osc", ((V)(1300D)), ((V)(9D)), NewObj(4).Put("spin", ((V)(26D))).Put("htilt", ((V)((-8D)))).Put("sqz", ((V)(1D))).Put("open", ((V)(0.2))).V, NewObj(2).Put("spin", ((V)((-26D)))).Put("htilt", ((V)(8D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(7).Put("spin", ((V)(0D))).Put("htilt", ((V)(0D))).Put("sqz", ((V)(0D))).Put("open", ((V)(0D))).Put("close", ((V)(0D))).Put("sq", ((V)((-0.06)))).Put("wide", ((V)(0.6))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(2D)), NewObj(3).Put("htilt", ((V)(5D))).Put("lx", ((V)(0.6))).Put("ly", ((V)((-0.3)))).V, NewObj(3).Put("htilt", ((V)((-5D)))).Put("lx", ((V)((-0.6)))).Put("ly", ((V)(0.3))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(6).Put("wide", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), "rest", ((V)(450D)));
return Invoke(t_840, "done");
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "ears", Arr(((V)("Clean the ears")), ((V)("Tilts her head, rubs each ear, ear flicks.")), Call(Fn((V _arrowThis847, int _argc841, V _a843, V _a844, V _a845, V _a846, V[] _rest842) => {
V t_848 = default;
t_848 = Call(TL_13, V.Undef);
Invoke(Arr(((V)((-1D))), ((V)(1D))), "forEach", Fn((V _arrowThis856, int _argc849, V s_855, V _a852, V _a853, V _a854, V[] _rest850) => {
V k_857 = default;
k_857 = Call(S_14, V.Undef, s_855);
Invoke(Invoke(Invoke(t_848, "to", ((V)(400D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, s_855, ((V)((-6D))), ((V)((-26D)))), NewObj(5).PutK(Get(k_857, "arm"), ((V)(35D))).Put("htilt", ((V)((ToNum(s_855) * 12D)))).Put("lean", ((V)((ToNum(s_855) * 1.5)))).PutK(Get(k_857, "wink"), ((V)(1D))).Put("tongue", ((V)(0.3))).V), ((V)("io"))), "osc", ((V)(1400D)), ((V)(4D)), NewObj(2).PutK(Get(k_857, "hy"), ((V)((-30D)))).PutK(Get(k_857, "ear"), ((V)(10D))).V, NewObj(2).PutK(Get(k_857, "hy"), ((V)((-24D)))).PutK(Get(k_857, "ear"), ((V)((-6D)))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(8).PutK(Get(k_857, "hx"), ((V)(0D))).PutK(Get(k_857, "hy"), ((V)(0D))).PutK(Get(k_857, "arm"), ((V)(0D))).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).PutK(Get(k_857, "wink"), ((V)(0D))).PutK(Get(k_857, "ear"), ((V)(0D))).Put("tongue", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true));
Invoke(Invoke(Invoke(Invoke(Invoke(t_848, "osc", ((V)(700D)), ((V)(3D)), NewObj(2).Put("turn", ((V)(0.35))).Put("htilt", ((V)((-5D)))).V, NewObj(2).Put("turn", ((V)((-0.35)))).Put("htilt", ((V)(5D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("drop")), ((V)("earL")), ((V)(3D))), "e", ((V)("emit")), ((V)("drop")), ((V)("earR")), ((V)(3D))), "to", ((V)(250D)), NewObj(4).Put("turn", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(0.8))).V), "rest", ((V)(450D)));
return Invoke(t_848, "done");
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "soak", Arr(((V)("Relax and soak")), ((V)("Leans back, eyes closed, slow happy breaths.")), Call(Fn((V _arrowThis864, int _argc858, V _a860, V _a861, V _a862, V _a863, V[] _rest859) => {
V t_865 = default;
V a_866 = default;
V b_867 = default;
t_865 = Call(TL_13, V.Undef);
Invoke(Invoke(t_865, "to", ((V)(700D)), NewObj(9).Put("pitch", ((V)(0.35))).Put("lean", ((V)((-1.2)))).Put("close", ((V)(1D))).Put("smile", ((V)(0.6))).Put("armL", ((V)(35D))).Put("armR", ((V)(35D))).Put("sq", ((V)(0.05))).Put("earL", ((V)(6D))).Put("earR", ((V)(6D))).V, ((V)("io"))), "em", ((V)(6000D)), ((V)(420D)), ((V)("steam")), ((V)("body")), ((V)(1D)));
a_866 = Get(t_865, "t");
Invoke(t_865, "osc", ((V)(4800D)), ((V)(2D)), NewObj(2).Put("sq", ((V)((-0.03)))).Put("pitch", ((V)(0.42))).V, NewObj(2).Put("sq", ((V)(0.06))).Put("pitch", ((V)(0.32))).V, ((V)("s")));
b_867 = Get(t_865, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_865, "at", Add(a_866, ((V)(1200D)))), "osc", ((V)(1600D)), ((V)(4D)), NewObj(2).Put("footL", ((V)(1.5))).Put("footR", ((V)(0D))).V, NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(1.5))).V, ((V)("s"))), "at", Add(a_866, ((V)(3000D)))), "to", ((V)(400D)), NewObj(2).Put("open", ((V)(0.3))).Put("mw", ((V)(0.7))).V, ((V)("io"))), "to", ((V)(600D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io"))), "at", b_867);
Invoke(Invoke(Invoke(t_865, "to", ((V)(500D)), NewObj(9).Put("pitch", ((V)(0D))).Put("lean", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("hap", ((V)(0.8))).V, ((V)("io"))), "e", ((V)("blink"))), "rest", ((V)(450D)));
return Invoke(t_865, "done");
return default;
}, 0, "", true), V.Undef)));
Set(Get(R_8, "PRE"), "steamBig", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(16D))).Put("vy", ((V)((-9D)))).Put("g", ((V)((-3D)))).Put("life", ((V)(1700D))).Put("r", Arr(((V)(3D)), ((V)(5.5)))).Put("col", Arr(((V)("#ffffff")))).Put("kind", ((V)("puff"))).V);
fxs_38 = Fn((V _arrowThis875, int _argc868, V _a870, V _a871, V _a872, V _a873, V[] _rest869) => {
V f_874 = default;
f_874 = RestArgs(0, _argc868, _a870, _a871, _a872, _a873, _rest869);
return Fn((V _arrowThis884, int _argc876, V I_882, V t_883, V _a880, V _a881, V[] _rest877) => {
return Invoke(Invoke(Invoke(f_874, "filter", G("Boolean")), "map", Fn((V _arrowThis892, int _argc885, V g_891, V _a888, V _a889, V _a890, V[] _rest886) => {
return Call(g_891, V.Undef, I_882, t_883);
}, 1, "", true)), "join", ((V)("")));
}, 2, "", true);
}, 1, "", true);
SOAP_39 = Arr(Arr(((V)("head")), ((V)((-13D))), ((V)(7D)), ((V)(4.2))), Arr(((V)("body")), ((V)((-17D))), ((V)((-2D))), ((V)(4.4))), Arr(((V)("belly")), ((V)(4D)), ((V)(1D)), ((V)(3.6))), Arr(((V)("head")), ((V)(6D)), ((V)(1D)), ((V)(4.6))), Arr(((V)("sideR")), ((V)(1D)), ((V)((-3D))), ((V)(3.8))), Arr(((V)("body")), ((V)(12D)), ((V)(6D)), ((V)(3.8))), Arr(((V)("earL")), ((V)(1D)), ((V)(3D)), ((V)(2.6))), Arr(((V)("sideL")), ((V)((-1D))), ((V)(2D)), ((V)(3.6))), Arr(((V)("head")), ((V)((-4D))), ((V)(2D)), ((V)(4D))), Arr(((V)("body")), ((V)((-8D))), ((V)(7D)), ((V)(3.4))), Arr(((V)("earR")), ((V)((-1D))), ((V)(3D)), ((V)(2.6))), Arr(((V)("body")), ((V)(18D)), ((V)((-4D))), ((V)(3.6))), Arr(((V)("head")), ((V)(14D)), ((V)(8D)), ((V)(3.6))), Arr(((V)("belly")), ((V)((-6D))), ((V)(3D)), ((V)(3.2))), Arr(((V)("body")), ((V)(0D)), ((V)((-6D))), ((V)(3D))), Arr(((V)("sideL")), ((V)(2D)), ((V)((-6D))), ((V)(3D))), Arr(((V)("sideR")), ((V)((-2D))), ((V)(4D)), ((V)(3.2))), Arr(((V)("head")), ((V)(0D)), ((V)(8D)), ((V)(3D))), Arr(((V)("footL")), ((V)(0D)), ((V)((-2D))), ((V)(2.6))), Arr(((V)("footR")), ((V)(0D)), ((V)((-2D))), ((V)(2.6))));
soapFx_40 = Fn((V _arrowThis904, int _argc893, V n_899, V a_900, V f_901, V r_902, V[] _rest894) => {
V rd_903 = default;
rd_903 = (_argc893 > 4 ? _rest894[0] : V.Undef);
return Fn((V _arrowThis913, int _argc905, V I_911, V t_912, V _a909, V _a910, V[] _rest906) => {
V W_914 = default;
JsStrBuf h_915 = null;
W_914 = Get(I_911, "W");
if (!(Truthy(Get(W_914, "body")))) {
return ((V)(""));
}
h_915 = new JsStrBuf("");
n_899 = ((V)(Min(ToNum(n_899), ToNum(Get(SOAP_39, "length")))));
{
double i_916 = 0;
i_916 = 0D;
while (true) {
if (!(Lt(((V)(i_916)), n_899))) break;
V w_918 = default;
V dx_919 = default;
V dy_920 = default;
V rr_921 = default;
V p_922 = default;
double g_923 = 0;
V x_924 = default;
V y_925 = default;
double wb_926 = 0;
double R0_927 = 0;
{ V _t928 = GetIdx(SOAP_39, i_916);
{ V _t929 = ListOf(_t928);
{ V _t930 = GetIdx(_t929, 0D);
w_918 = _t930; }
{ V _t931 = GetIdx(_t929, 1D);
dx_919 = _t931; }
{ V _t932 = GetIdx(_t929, 2D);
dy_920 = _t932; }
{ V _t933 = GetIdx(_t929, 3D);
rr_921 = _t933; }
} }
p_922 = GetK(W_914, w_918);
if (!(Truthy(p_922))) {
goto _cont917;
}
g_923 = (ToNum(Call(SM_11, V.Undef, ((V)((((ToNum(t_912) - ToNum(a_900)) - ((i_916 * (ToNum(f_901) - ToNum(a_900))) / ToNum(n_899))) / 260D))))) * (1D - ToNum(Call(SM_11, V.Undef, ((V)((((ToNum(t_912) - ToNum(r_902)) - ((i_916 % 5D) * 60D)) / ToNum((rd_903 is var _t934 && Truthy(_t934) ? _t934 : ((V)(450D)))))))))));
if ((g_923 <= 0.01)) {
goto _cont917;
}
x_924 = Add(GetIdx(p_922, 0D), dx_919);
y_925 = Add(GetIdx(p_922, 1D), dy_920);
wb_926 = (FdLibm.Sin(((ToNum(t_912) / 340D) + (i_916 * 1.7))) * 0.35);
R0_927 = ((ToNum(rr_921) * (0.4 + (0.6 * g_923))) + wb_926);
h_915.S("<g opacity=\"").V(Call(r2_10, V.Undef, ((V)(g_923)))).S("\"><circle cx=\"").V(Call(r2_10, V.Undef, x_924)).S("\" cy=\"").V(Call(r2_10, V.Undef, y_925)).S("\" r=\"").V(Call(r2_10, V.Undef, ((V)(R0_927)))).S("\" fill=\"#ffffff\" stroke=\"#cfeefc\" stroke-width=\"0.55\"/><circle cx=\"").V(Call(r2_10, V.Undef, Add(x_924, ((V)((R0_927 * 0.85)))))).S("\" cy=\"").V(Call(r2_10, V.Undef, Add(y_925, ((V)((R0_927 * 0.35)))))).S("\" r=\"").V(Call(r2_10, V.Undef, ((V)((R0_927 * 0.55))))).S("\" fill=\"#ffffff\" stroke=\"#cfeefc\" stroke-width=\"0.45\"/><circle cx=\"").V(Call(r2_10, V.Undef, ((V)((ToNum(x_924) - (R0_927 * 0.75)))))).S("\" cy=\"").V(Call(r2_10, V.Undef, Add(y_925, ((V)((R0_927 * 0.45)))))).S("\" r=\"").V(Call(r2_10, V.Undef, ((V)((R0_927 * 0.45))))).S("\" fill=\"#ffffff\" stroke=\"#cfeefc\" stroke-width=\"0.45\"/><circle cx=\"").V(Call(r2_10, V.Undef, ((V)((ToNum(x_924) - (R0_927 * 0.3)))))).S("\" cy=\"").V(Call(r2_10, V.Undef, ((V)((ToNum(y_925) - (R0_927 * 0.35)))))).S("\" r=\"").V(Call(r2_10, V.Undef, ((V)((R0_927 * 0.22))))).S("\" fill=\"#e6f7ff\"/></g>");
_cont917: ;
i_916++;
}
}
return ((V)(h_915.Str));
return default;
}, 2, "", true);
}, 5, "", true);
MINI_41 = Fn((V _arrowThis943, int _argc935, V s_941, V fl_942, V _a939, V _a940, V[] _rest936) => {
return ((V)(JsStrBuf.Begin().S("<g transform=\"scale(").V(Call(r2_10, V.Undef, s_941)).S(")").S((Truthy(fl_942) ? " scale(-1 1)" : "")).S("\">").V(DUCK_33).S("</g>").End()));
}, 2, "", true);
SetIdx(Get(B_37, "duck"), 1D, ((V)("A whole flock of ducks bobs around her; she squeezes one, it squeaks, one hops onto her head.")));
Set(GetIdx(Get(B_37, "duck"), 2D), "fx", Fn((V _arrowThis952, int _argc944, V I_950, V t_951, V _a948, V _a949, V[] _rest945) => {
JsStrBuf h_953 = null;
V hd_954 = default;
V u_955 = default;
double up_956 = 0;
h_953 = new JsStrBuf("");
Invoke(Arr(Arr(((V)(16D)), ((V)(0.62)), ((V)(0D))), Arr(((V)(30D)), ((V)(0.5)), ((V)(1D))), Arr(((V)(72D)), ((V)(0.55)), ((V)(1D))), Arr(((V)(86D)), ((V)(0.66)), ((V)(0D))), Arr(((V)(50D)), ((V)(0.45)), ((V)(0D)))), "forEach", Fn((V _arrowThis971, int _argc957, V _a959, V i_963, V _a961, V _a962, V[] _rest958) => {
V x_972 = default;
double y_973 = 0;
V sp_974 = default;
V x0_966 = default;
V sc_968 = default;
V fl_970 = default;
{ V _t964 = ListOf(_a959);
{ V _t965 = GetIdx(_t964, 0D);
x0_966 = _t965; }
{ V _t967 = GetIdx(_t964, 1D);
sc_968 = _t967; }
{ V _t969 = GetIdx(_t964, 2D);
fl_970 = _t969; }
}
x_972 = Add(x0_966, ((V)((FdLibm.Sin(((ToNum(t_951) / 900D) + (ToNum(i_963) * 2D))) * 3D))));
y_973 = ((92D + (FdLibm.Sin(ToNum(Add(((V)((ToNum(t_951) / 380D))), i_963))) * 0.8)) - (SEqN(i_963, 4D) ? 4D : 0D));
sp_974 = Call(SM_11, V.Undef, ((V)(((ToNum(t_951) - (ToNum(i_963) * 160D)) / 300D))));
h_953.S("<g transform=\"translate(").V(Call(r2_10, V.Undef, x_972)).S(" ").V(Call(r2_10, V.Undef, ((V)(y_973)))).S(") rotate(").V(Call(r2_10, V.Undef, ((V)((FdLibm.Sin(ToNum(Add(((V)((ToNum(t_951) / 420D))), i_963))) * 8D))))).S(") scale(").V(Call(r2_10, V.Undef, sp_974)).S(")\">").V(Call(MINI_41, V.Undef, sc_968, fl_970)).S("</g>");
return default;
}, 2, "", true));
hd_954 = Get(Get(I_950, "W"), "head");
u_955 = Call(SM_11, V.Undef, ((V)(((ToNum(t_951) - 3600D) / 380D))));
up_956 = (FdLibm.Sin((System.Math.PI * Min(1D, Max(0D, ((ToNum(t_951) - 3600D) / 380D))))) * 8D);
if (Truthy(((hd_954 is var _t975 && !Truthy(_t975) ? _t975 : (GtN(t_951, 3600D) ? V.True : V.False)) is var _t976 && !Truthy(_t976) ? _t976 : (LtN(t_951, (Truthy(Get(I_950, "cur")) ? 1000000000D : 1000000000D)) ? V.True : V.False)))) {
h_953.S("<g transform=\"translate(").V(Call(r2_10, V.Undef, Add(Add(GetIdx(hd_954, 0D), ((V)(2D))), ((V)(((1D - ToNum(u_955)) * 26D)))))).S(" ").V(Call(r2_10, V.Undef, ((V)((((ToNum(GetIdx(hd_954, 1D)) - 3D) - up_956) + ((1D - ToNum(u_955)) * 60D)))))).S(") rotate(").V(Call(r2_10, V.Undef, ((V)((FdLibm.Sin((ToNum(t_951) / 300D)) * 6D))))).S(")\">").V(Call(MINI_41, V.Undef, ((V)(0.6)), ((V)(0D)))).S("</g>");
}
return ((V)(h_953.Str));
return default;
}, 2, "", true));
Set(GetIdx(Get(B_37, "duck"), 2D), "emit", Invoke((Get(GetIdx(Get(B_37, "duck"), 2D), "emit") is var _t977 && Truthy(_t977) ? _t977 : Arr()), "concat", Arr(Arr(((V)(3700D)), ((V)(4200D)), ((V)(999D)), ((V)("spark")), ((V)("head")), ((V)(3D))))));
Set(B_37, "mask", Arr(((V)("Face mask")), ((V)("Pats on a green mask, cucumber slices on her eyes, relaxes, wipes it off fresh.")), Call(Fn((V _arrowThis984, int _argc978, V _a980, V _a981, V _a982, V _a983, V[] _rest979) => {
V t_985 = default;
V a_986 = default;
V b_987 = default;
t_985 = Call(TL_13, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_985, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(3D)), ((V)((-17D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(3D)), ((V)((-17D)))), NewObj(2).Put("close", ((V)(0.5))).Put("smile", ((V)(0.4))).V), ((V)("io"))), "e", ((V)("mask"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(3).Put("hLy", ((V)((-19D)))).Put("hRy", ((V)((-15D)))).Put("sq", ((V)(0.03))).V, NewObj(3).Put("hLy", ((V)((-15D)))).Put("hRy", ((V)((-19D)))).Put("sq", ((V)(0D))).V, ((V)("s"))), "to", ((V)(400D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)((-27D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-27D)))), NewObj(1).Put("close", ((V)(1D))).V), ((V)("io"))), "e", ((V)("cuke"))), "to", ((V)(350D)), NewObj(11).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("pitch", ((V)(0.3))).Put("lean", ((V)((-1D)))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("smile", ((V)(0.7))).Put("earL", ((V)(6D))).Put("earR", ((V)(6D))).V, ((V)("io")));
a_986 = Get(t_985, "t");
Invoke(t_985, "osc", ((V)(3000D)), ((V)(2D)), NewObj(2).Put("sq", ((V)((-0.02)))).Put("pitch", ((V)(0.36))).V, NewObj(2).Put("sq", ((V)(0.05))).Put("pitch", ((V)(0.28))).V, ((V)("s")));
b_987 = Get(t_985, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(t_985, "at", Add(a_986, ((V)(600D)))), "e", ((V)("emit")), ((V)("note")), ((V)("mouth"))), "at", Add(a_986, ((V)(1800D)))), "e", ((V)("emit")), ((V)("note")), ((V)("mouth"))), "at", b_987);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_985, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)((-27D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-27D)))), NewObj(4).Put("pitch", ((V)(0D))).Put("lean", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io"))), "e", ((V)("cukeoff"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(3D)), ((V)((-17D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(3D)), ((V)((-17D)))), NewObj(1).Put("close", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(4).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-6D)))).Put("hLy", ((V)((-19D)))).Put("hRy", ((V)((-19D)))).V, NewObj(4).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("hLy", ((V)((-15D)))).Put("hRy", ((V)((-15D)))).V, ((V)("s"))), "e", ((V)("maskoff"))), "to", ((V)(300D)), NewObj(7).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("close", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("eyeL")), ((V)(4D))), "e", ((V)("emit")), ((V)("spark")), ((V)("eyeR")), ((V)(4D))), "to", ((V)(250D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("blush", ((V)(0.8))).Put("sq", ((V)(0.1))).V), "to", ((V)(220D)), NewObj(2).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(6D))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.15))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V), "rest", ((V)(450D)));
return Invoke(t_985, "done", NewObj(1).Put("prop", Fn((V _arrowThis996, int _argc988, V I_994, V tt_995, V _a992, V _a993, V[] _rest989) => {
V c_997 = default;
V W_998 = default;
V now_999 = default;
double ma_1000 = 0;
V eL_1001 = default;
V eR_1002 = default;
V m_1003 = default;
double cx_1004 = 0;
double cy_1005 = 0;
double w_1006 = 0;
double ang_1007 = 0;
V id_1008 = default;
JsStrBuf h_1009 = null;
c_997 = Get(I_994, "ctT");
W_998 = Get(I_994, "W");
if ((!(Truthy(Get(c_997, "mask"))) || !(Truthy(Get(W_998, "eyeL"))))) {
return ((V)(""));
}
now_999 = Invoke(G("performance"), "now");
ma_1000 = (ToNum(Call(SM_11, V.Undef, ((V)(((ToNum(now_999) - ToNum(Get(c_997, "mask"))) / 900D))))) * (Truthy(Get(c_997, "maskoff")) ? (1D - ToNum(Call(SM_11, V.Undef, ((V)(((ToNum(now_999) - ToNum(Get(c_997, "maskoff"))) / 500D)))))) : 1D));
eL_1001 = Get(W_998, "eyeL");
eR_1002 = Get(W_998, "eyeR");
m_1003 = Get(W_998, "mouth");
cx_1004 = (ToNum(Add(GetIdx(eL_1001, 0D), GetIdx(eR_1002, 0D))) / 2D);
cy_1005 = ((ToNum(Add(GetIdx(eL_1001, 1D), GetIdx(eR_1002, 1D))) / 2D) + 3D);
w_1006 = Max(6D, (ToNum(GetIdx(eR_1002, 0D)) - ToNum(GetIdx(eL_1001, 0D))));
ang_1007 = ((FdLibm.Atan2((ToNum(GetIdx(eR_1002, 1D)) - ToNum(GetIdx(eL_1001, 1D))), (ToNum(GetIdx(eR_1002, 0D)) - ToNum(GetIdx(eL_1001, 0D)))) * 180D) / System.Math.PI);
id_1008 = ((V)(JsStrBuf.Begin().S("mk").V(Get(I_994, "u")).End()));
h_1009 = new JsStrBuf("");
if ((ma_1000 > 0.01)) {
h_1009.S("<mask id=\"").V(id_1008).S("\" maskUnits=\"userSpaceOnUse\" x=\"0\" y=\"0\" width=\"100\" height=\"100\"><rect width=\"100\" height=\"100\" fill=\"#fff\"/><ellipse cx=\"").V(Call(r2_10, V.Undef, GetIdx(eL_1001, 0D))).S("\" cy=\"").V(Call(r2_10, V.Undef, GetIdx(eL_1001, 1D))).S("\" rx=\"4.6\" ry=\"4.6\" fill=\"#000\"/><ellipse cx=\"").V(Call(r2_10, V.Undef, GetIdx(eR_1002, 0D))).S("\" cy=\"").V(Call(r2_10, V.Undef, GetIdx(eR_1002, 1D))).S("\" rx=\"4.6\" ry=\"4.6\" fill=\"#000\"/><ellipse cx=\"").V(Call(r2_10, V.Undef, GetIdx(m_1003, 0D))).S("\" cy=\"").V(Call(r2_10, V.Undef, Add(GetIdx(m_1003, 1D), ((V)(0.5))))).S("\" rx=\"3.6\" ry=\"2.2\" fill=\"#000\"/></mask>").S("<g mask=\"url(#").V(id_1008).S(")\" opacity=\"").V(Call(r2_10, V.Undef, ((V)((ma_1000 * 0.92))))).S("\"><ellipse cx=\"").V(Call(r2_10, V.Undef, ((V)(cx_1004)))).S("\" cy=\"").V(Call(r2_10, V.Undef, ((V)(cy_1005)))).S("\" rx=\"").V(Call(r2_10, V.Undef, ((V)((w_1006 * 1.12))))).S("\" ry=\"").V(Call(r2_10, V.Undef, ((V)((w_1006 * 0.86))))).S("\" transform=\"rotate(").V(Call(r2_10, V.Undef, ((V)(ang_1007)))).S(" ").V(Call(r2_10, V.Undef, ((V)(cx_1004)))).S(" ").V(Call(r2_10, V.Undef, ((V)(cy_1005)))).S(")\" fill=\"#9fd67a\"/><circle cx=\"").V(Call(r2_10, V.Undef, ((V)((cx_1004 - (w_1006 * 0.6)))))).S("\" cy=\"").V(Call(r2_10, V.Undef, ((V)((cy_1005 + 3D))))).S("\" r=\"1\" fill=\"#c4eaa6\"/><circle cx=\"").V(Call(r2_10, V.Undef, ((V)((cx_1004 + (w_1006 * 0.5)))))).S("\" cy=\"").V(Call(r2_10, V.Undef, ((V)((cy_1005 - 4D))))).S("\" r=\"0.8\" fill=\"#c4eaa6\"/><circle cx=\"").V(Call(r2_10, V.Undef, ((V)((cx_1004 + (w_1006 * 0.2)))))).S("\" cy=\"").V(Call(r2_10, V.Undef, ((V)((cy_1005 + 6D))))).S("\" r=\"0.7\" fill=\"#c4eaa6\"/></g>");
}
if (Truthy((Get(c_997, "cuke") is var _t1011 && !Truthy(_t1011) ? _t1011 : (!(Truthy((Get(c_997, "cukeoff") is var _t1010 && !Truthy(_t1010) ? _t1010 : (((ToNum(now_999) - ToNum(Get(c_997, "cukeoff"))) > 250D) ? V.True : V.False)))) ? V.True : V.False)))) {
double k_1012 = 0;
k_1012 = (ToNum(Call(SM_11, V.Undef, ((V)(((ToNum(now_999) - ToNum(Get(c_997, "cuke"))) / 200D))))) * (Truthy(Get(c_997, "cukeoff")) ? (1D - ToNum(Call(SM_11, V.Undef, ((V)(((ToNum(now_999) - ToNum(Get(c_997, "cukeoff"))) / 250D)))))) : 1D));
Invoke(Arr(eL_1001, eR_1002), "forEach", Fn((V _arrowThis1020, int _argc1013, V e_1019, V _a1016, V _a1017, V _a1018, V[] _rest1014) => {
h_1009.S("<g transform=\"translate(").V(Call(r2_10, V.Undef, GetIdx(e_1019, 0D))).S(" ").V(Call(r2_10, V.Undef, GetIdx(e_1019, 1D))).S(") scale(").V(Call(r2_10, V.Undef, ((V)(k_1012)))).S(")\"><circle r=\"5\" fill=\"#5fae4a\"/><circle r=\"4.2\" fill=\"#c8ef9a\"/><circle r=\"1.2\" fill=\"#e8ffd0\"/><path d=\"M0 -3.4 L0 -1.6 M0 1.6 L0 3.4 M-3.4 0 L-1.6 0 M1.6 0 L3.4 0\" stroke=\"#a6dc78\" stroke-width=\"0.5\"/></g>");
return default;
}, 1, "", true));
}
return ((V)(h_1009.Str));
return default;
}, 2, "prop", true)).V);
return default;
}, 0, "", true), V.Undef)));
Set(B_37, "sauna", Arr(((V)("Sauna")), ((V)("Towel on her head, steam all around, gets rosy and sweaty, fans herself, phew.")), Call(Fn((V _arrowThis1027, int _argc1021, V _a1023, V _a1024, V _a1025, V _a1026, V[] _rest1022) => {
V t_1028 = default;
V a_1029 = default;
t_1028 = Call(TL_13, V.Undef);
Invoke(Invoke(Invoke(t_1028, "to", ((V)(600D)), NewObj(9).Put("sl", ((V)(1D))).Put("smile", ((V)(0.6))).Put("close", ((V)(0.4))).Put("sq", ((V)(0.06))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("red", ((V)(0.25))).V, ((V)("io"))), "em", ((V)(7200D)), ((V)(160D)), ((V)("steamBig")), ((V)("body")), ((V)(1D))), "em", ((V)(7200D)), ((V)(300D)), ((V)("steam")), ((V)("head")), ((V)(1D)));
a_1029 = Get(t_1028, "t");
Invoke(t_1028, "osc", ((V)(2400D)), ((V)(1D)), NewObj(3).Put("sq", ((V)(0.02))).Put("red", ((V)(0.5))).Put("close", ((V)(0.6))).V, NewObj(3).Put("sq", ((V)(0.08))).Put("red", ((V)(0.6))).Put("close", ((V)(0.5))).V, ((V)("s")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_1028, "at", Add(a_1029, ((V)(900D)))), "e", ((V)("emit")), ((V)("sweat")), Arr(((V)(37D)), ((V)(30D)))), "at", Add(a_1029, ((V)(1700D)))), "e", ((V)("emit")), ((V)("sweat")), Arr(((V)(64D)), ((V)(32D)))), "at", Add(a_1029, ((V)(2400D))));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1028, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-16D)))), NewObj(5).Put("red", ((V)(0.75))).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).Put("close", ((V)(0.2))).Put("sl", ((V)(0.5))).V), ((V)("io"))), "osc", ((V)(1500D)), ((V)(6D)), NewObj(1).Put("hRx", ((V)((-16D)))).V, NewObj(1).Put("hRx", ((V)((-9D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sweat")), Arr(((V)(40D)), ((V)(28D)))), "e", ((V)("emit")), ((V)("sweat")), Arr(((V)(61D)), ((V)(29D)))), "to", ((V)(300D)), NewObj(4).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("armR", ((V)(60D))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("armR", ((V)((-10D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steamBig")), Arr(((V)(70D)), ((V)(88D))), ((V)(6D))), "e", ((V)("emit")), ((V)("steamBig")), Arr(((V)(30D)), ((V)(88D))), ((V)(6D))), "to", ((V)(300D)), NewObj(3).Put("wide", ((V)(0.6))).Put("armR", ((V)(0D))).Put("red", ((V)(0.9))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(6).Put("sq", ((V)(0.12))).Put("earL", ((V)(22D))).Put("earR", ((V)(22D))).Put("sl", ((V)(1D))).Put("close", ((V)(0.55))).Put("red", ((V)(0.95))).V, ((V)("io"))), "to", ((V)(400D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-30D)))), NewObj(2).Put("armR", ((V)(30D))).Put("wide", ((V)(0D))).V), ((V)("io"))), "to", ((V)(450D)), NewObj(2).Put("hRx", ((V)(6D))).Put("hRy", ((V)((-26D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sweat")), Arr(((V)(72D)), ((V)(30D)))), "to", ((V)(300D)), NewObj(5).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("armR", ((V)(0D))).Put("open", ((V)(0.35))).Put("sq", ((V)((-0.04)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("open", ((V)(0D))).Put("sq", ((V)(0.05))).V), "to", ((V)(500D)), NewObj(1).Put("red", ((V)(0.3))).V), "rest", ((V)(500D)));
return Invoke(t_1028, "done", NewObj(1).Put("prop", Fn((V _arrowThis1038, int _argc1030, V I_1036, V tt_1037, V _a1034, V _a1035, V[] _rest1031) => {
V hd_1039 = default;
V k_1040 = default;
hd_1039 = Get(Get(I_1036, "W"), "head");
if (!(Truthy(hd_1039))) {
return ((V)(""));
}
k_1040 = Call(SM_11, V.Undef, ((V)((ToNum(tt_1037) / 300D))));
return ((V)(JsStrBuf.Begin().S("<g transform=\"translate(").V(Call(r2_10, V.Undef, GetIdx(hd_1039, 0D))).S(" ").V(Call(r2_10, V.Undef, Add(GetIdx(hd_1039, 1D), ((V)(3D))))).S(") scale(").V(Call(r2_10, V.Undef, k_1040)).S(")\"><path d=\"M-17 6 Q-18 -6 0 -7 Q18 -6 17 6 Q8 2 0 3 Q-8 2 -17 6Z\" fill=\"#ffffff\" stroke=\"#e3d4f5\" stroke-width=\"0.6\"/><path d=\"M-12 1 Q0 -3 12 1 M-14 4 Q0 0 14 4\" stroke=\"#efe6fb\" stroke-width=\"0.8\" fill=\"none\"/><path d=\"M14 -1 Q22 -6 19 4 Q16 5 14 3Z\" fill=\"#ffffff\" stroke=\"#e3d4f5\" stroke-width=\"0.6\"/></g>").End()));
return default;
}, 2, "prop", true)).V);
return default;
}, 0, "", true), V.Undef)));
SOAPCFG_42 = NewObj(10).Put("belly", Arr(((V)(18D)), ((V)(300D)), ((V)(2600D)), ((V)((-900D))))).Put("shampoo", Arr(((V)(14D)), ((V)(300D)), ((V)(3000D)), ((V)((-1500D))))).Put("face", Arr(((V)(12D)), ((V)(200D)), ((V)(2200D)), ((V)((-1600D))))).Put("back", Arr(((V)(18D)), ((V)(300D)), ((V)(2800D)), ((V)((-900D))))).Put("splash", Arr(((V)(10D)), ((V)(200D)), ((V)(2000D)), ((V)((-700D))))).Put("duck", Arr(((V)(12D)), ((V)(200D)), ((V)(2600D)), ((V)((-700D))))).Put("bubbles", Arr(((V)(9D)), ((V)(200D)), ((V)(2600D)), ((V)((-800D))))).Put("shake", Arr(((V)(20D)), ((V)(0D)), ((V)(1D)), ((V)(400D)), ((V)(1100D)))).Put("ears", Arr(((V)(14D)), ((V)(200D)), ((V)(2600D)), ((V)((-1100D))))).Put("soak", Arr(((V)(8D)), ((V)(300D)), ((V)(2500D)), ((V)((-1000D))))).V;
Invoke(Object_keys(B_37), "forEach", Fn((V _arrowThis1048, int _argc1041, V k_1047, V _a1044, V _a1045, V _a1046, V[] _rest1042) => {
V st_1049 = default;
V c_1050 = default;
st_1049 = GetIdx(GetK(B_37, k_1047), 2D);
c_1050 = GetK(SOAPCFG_42, k_1047);
if (Truthy(c_1050)) {
V r_1051 = default;
r_1051 = (LtN(GetIdx(c_1050, 3D), 0D) ? Add(Get(st_1049, "dur"), GetIdx(c_1050, 3D)) : GetIdx(c_1050, 3D));
Set(st_1049, "fx", Call(fxs_38, V.Undef, Get(st_1049, "fx"), Call(soapFx_40, V.Undef, GetIdx(c_1050, 0D), GetIdx(c_1050, 1D), GetIdx(c_1050, 2D), r_1051, GetIdx(c_1050, 4D))));
}
SetK(ST_18, ((V)(JsStrBuf.Begin().S("bath_").V(k_1047).End())), st_1049);
return default;
}, 1, "", true));
Set(ST_18, "poke_head", Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(80D)), NewObj(5).Put("sq", ((V)(0.26))).Put("sqz", ((V)(1D))).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).Put("pitch", ((V)((-0.3)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)((-0.1)))).Put("pitch", ((V)(0.1))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.04))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(7).Put("sq", ((V)(0D))).Put("sqz", ((V)(0D))).Put("frown", ((V)(0.5))).Put("puff", ((V)(0.35))).Put("ly", ((V)((-0.9)))).Put("earL", ((V)(4D))).Put("earR", ((V)(4D))).V, ((V)("io"))), "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)((-30D)))), NewObj(1).Put("armR", ((V)(25D))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("hRx", ((V)((-4D)))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("hRx", ((V)(4D))).Put("htilt", ((V)((-3D)))).V, ((V)("s"))), "to", ((V)(350D)), NewObj(8).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("armR", ((V)(0D))).Put("frown", ((V)(0D))).Put("puff", ((V)(0D))).Put("smile", ((V)(0.4))).Put("ly", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io"))), "rest", ((V)(350D))), "done", NewObj(1).Put("tap", Arr(((V)(50D)), ((V)(24D)))).V));
pokeEar_43 = Fn((V _arrowThis1059, int _argc1052, V s_1058, V _a1055, V _a1056, V _a1057, V[] _rest1053) => {
V k_1060 = default;
k_1060 = Call(S_14, V.Undef, s_1058);
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(70D)), NewObj(3).PutK(Get(k_1060, "ear"), ((V)((-22D)))).PutK(Get(k_1060, "wink"), ((V)(1D))).Put("htilt", ((V)((ToNum(s_1058) * 5D)))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(1).PutK(Get(k_1060, "ear"), ((V)(14D))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(1).PutK(Get(k_1060, "ear"), ((V)((-10D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).PutK(Get(k_1060, "ear"), ((V)(6D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).PutK(Get(k_1060, "ear"), ((V)(0D))).PutK(Get(k_1060, "wink"), ((V)(0D))).V, ((V)("io"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("turn", ((V)(0.3))).Put("htilt", ((V)((-4D)))).V, NewObj(2).Put("turn", ((V)((-0.3)))).Put("htilt", ((V)(4D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(4).Put("turn", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(3D)), NewObj(1).Put("sq", ((V)(0.05))).V, NewObj(1).Put("sq", ((V)(0D))).V), "rest", ((V)(350D))), "done", NewObj(1).Put("tap", Arr(((V)((LtN(s_1058, 0D) ? 28D : 72D))), ((V)(16D)))).V);
return default;
}, 1, "", true);
Set(ST_18, "poke_earL", Call(pokeEar_43, V.Undef, ((V)((-1D)))));
Set(ST_18, "poke_earR", Call(pokeEar_43, V.Undef, ((V)(1D))));
Set(ST_18, "poke_nose", Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(250D)), NewObj(4).Put("cross", ((V)(1D))).Put("ly", ((V)(0.7))).Put("pitch", ((V)((-0.1)))).Put("wide", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(450D))), "to", ((V)(300D)), NewObj(9).Put("cross", ((V)(0D))).Put("ly", ((V)(0D))).Put("wide", ((V)(0D))).Put("pitch", ((V)(0.35))).Put("open", ((V)(0.4))).Put("close", ((V)(0.6))).Put("sq", ((V)((-0.08)))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(3).Put("pitch", ((V)(0.25))).Put("open", ((V)(0.3))).Put("sq", ((V)((-0.04)))).V), "to", ((V)(260D)), NewObj(4).Put("pitch", ((V)(0.5))).Put("open", ((V)(0.55))).Put("close", ((V)(0.8))).Put("sq", ((V)((-0.12)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(8).Put("pitch", ((V)((-0.55)))).Put("open", ((V)(0.9))).Put("sqz", ((V)(1D))).Put("close", ((V)(0D))).Put("sq", ((V)(0.22))).Put("lean", ((V)(0.5))).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("sneeze")), ((V)("nose"))), "to", ((V)(260D)), NewObj(6).Put("pitch", ((V)((-0.1)))).Put("open", ((V)(0.1))).Put("sq", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("sqz", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-18D))))), ((V)("io"))), "osc", ((V)(450D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-15D)))).V, NewObj(1).Put("hRx", ((V)((-11D)))).V), "to", ((V)(300D)), NewObj(4).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(0.6))).V, ((V)("io"))), "osc", ((V)(400D)), ((V)(2D)), NewObj(1).Put("turn", ((V)(0.2))).V, NewObj(1).Put("turn", ((V)((-0.2)))).V), "rest", ((V)(350D))), "done", NewObj(1).Put("tap", Arr(((V)(50D)), ((V)(54D)))).V));
pokeEye_44 = Fn((V _arrowThis1068, int _argc1061, V s_1067, V _a1064, V _a1065, V _a1066, V[] _rest1062) => {
V k_1069 = default;
k_1069 = Call(S_14, V.Undef, s_1067);
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(60D)), NewObj(5).PutK(Get(k_1069, "wink"), ((V)(1D))).Put("pitch", ((V)(0.2))).Put("lean", ((V)(((-ToNum(s_1067)) * 2.5)))).Put("htilt", ((V)(((-ToNum(s_1067)) * 5D)))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, s_1067, ((V)(6D)), ((V)((-27D))))), ((V)("io"))), "osc", ((V)(700D)), ((V)(3D)), NewObj(2).PutK(Get(k_1069, "hy"), ((V)((-29D)))).PutK(Get(k_1069, "hx"), ((V)((LtN(s_1067, 0D) ? 4D : (-4D))))).V, NewObj(2).PutK(Get(k_1069, "hy"), ((V)((-25D)))).PutK(Get(k_1069, "hx"), ((V)((LtN(s_1067, 0D) ? 7D : (-7D))))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(5).PutK(Get(k_1069, "hx"), ((V)(0D))).PutK(Get(k_1069, "hy"), ((V)(0D))).Put("pitch", ((V)(0D))).Put("lean", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).PutK(Get(k_1069, "wink"), ((V)(0D))).V), "e", ((V)("blink2"))), "to", ((V)(300D)), NewObj(1).Put("frown", ((V)(0.4))).V), "rest", ((V)(400D))), "done", NewObj(1).Put("tap", Arr(((V)((LtN(s_1067, 0D) ? 38D : 62D))), ((V)(47D)))).V);
return default;
}, 1, "", true);
Set(ST_18, "poke_eyeL", Call(pokeEye_44, V.Undef, ((V)((-1D)))));
Set(ST_18, "poke_eyeR", Call(pokeEye_44, V.Undef, ((V)(1D))));
pokeCheek_45 = Fn((V _arrowThis1077, int _argc1070, V s_1076, V _a1073, V _a1074, V _a1075, V[] _rest1071) => {
V k_1078 = default;
k_1078 = Call(S_14, V.Undef, s_1076);
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(90D)), NewObj(4).Put("htilt", ((V)(((-ToNum(s_1076)) * 9D)))).Put("lean", ((V)(((-ToNum(s_1076)) * 2D)))).PutK(Get(k_1078, "wink"), ((V)(0.8))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(250D)), NewObj(5).Put("blush", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, s_1076, ((V)(2D)), ((V)((-18D))))), ((V)("io"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("sq", ((V)(0.05))).Put("htilt", ((V)(((-ToNum(s_1076)) * 7D)))).V, NewObj(2).Put("sq", ((V)(0D))).Put("htilt", ((V)(((-ToNum(s_1076)) * 10D)))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(6).PutK(Get(k_1078, "hx"), ((V)(0D))).PutK(Get(k_1078, "hy"), ((V)(0D))).Put("htilt", ((V)(0D))).Put("lean", ((V)(0D))).PutK(Get(k_1078, "wink"), ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "rest", ((V)(500D))), "done", NewObj(1).Put("tap", Arr(((V)((LtN(s_1076, 0D) ? 33D : 67D))), ((V)(58D)))).V);
return default;
}, 1, "", true);
Set(ST_18, "poke_cheekL", Call(pokeCheek_45, V.Undef, ((V)((-1D)))));
Set(ST_18, "poke_cheekR", Call(pokeCheek_45, V.Undef, ((V)(1D))));
Set(ST_18, "poke_belly", Call(Fn((V _arrowThis1085, int _argc1079, V _a1081, V _a1082, V _a1083, V _a1084, V[] _rest1080) => {
V t_1086 = default;
V a_1087 = default;
V b_1088 = default;
t_1086 = Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(90D)), NewObj(3).Put("sq", ((V)(0.14))).Put("pitch", ((V)((-0.3)))).Put("sqz", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(250D)), Call(o_17, V.Undef, Call(both_16, V.Undef, ((V)(9D)), ((V)(0D))), NewObj(4).Put("hap", ((V)(1D))).Put("sqz", ((V)(0D))).Put("open", ((V)(0.65))).Put("smile", ((V)(1D))).V), ((V)("io")));
a_1087 = Get(t_1086, "t");
Invoke(t_1086, "osc", ((V)(1400D)), ((V)(7D)), NewObj(3).Put("sq", ((V)(0.12))).Put("lift", ((V)(0D))).Put("htilt", ((V)(4D))).V, NewObj(3).Put("sq", ((V)(0.02))).Put("lift", ((V)(1.5))).Put("htilt", ((V)((-4D)))).V, ((V)("io")));
b_1088 = Get(t_1086, "t");
Invoke(Invoke(Invoke(t_1086, "at", a_1087), "osc", ((V)(1400D)), ((V)(5D)), NewObj(1).Put("wag", ((V)(22D))).V, NewObj(1).Put("wag", ((V)((-22D)))).V), "at", b_1088);
return Invoke(Invoke(Invoke(Invoke(t_1086, "to", ((V)(400D)), NewObj(10).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("open", ((V)(0.2))).Put("lift", ((V)(0D))).Put("htilt", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("sq", ((V)((-0.04)))).Put("pitch", ((V)(0.15))).V), "rest", ((V)(400D))), "done", NewObj(1).Put("tap", Arr(((V)(50D)), ((V)(82D)))).V);
return default;
}, 0, "", true), V.Undef));
pokeSide_46 = Fn((V _arrowThis1096, int _argc1089, V s_1095, V _a1092, V _a1093, V _a1094, V[] _rest1090) => {
V k_1097 = default;
V j_1098 = default;
double d_1099 = 0;
k_1097 = Call(S_14, V.Undef, s_1095);
j_1098 = Call(S_14, V.Undef, ((V)((-ToNum(s_1095)))));
d_1099 = (-ToNum(s_1095));
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(90D)), NewObj(8).Put("x", ((V)((d_1099 * 3D)))).Put("lean", ((V)((d_1099 * 4D)))).Put("tilt", ((V)((d_1099 * 8D)))).Put("sq", ((V)(0.06))).Put("wide", ((V)(0.8))).PutK(Get(k_1097, "foot"), ((V)(3D))).PutK(Get(j_1098, "arm"), ((V)(60D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(250D)), NewObj(4).Put("x", ((V)((d_1099 * 6D)))).Put("tilt", ((V)((d_1099 * 10D)))).Put("lean", ((V)((d_1099 * 3D)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(4).Put("lift", ((V)(0D))).Put("tilt", ((V)((d_1099 * 2D)))).Put("sq", ((V)(0.08))).PutK(Get(k_1097, "foot"), ((V)(0D))).V, ((V)("i"))), "to", ((V)(220D)), NewObj(3).Put("tilt", ((V)(((-d_1099) * 2D)))).Put("sq", ((V)(0D))).PutK(Get(j_1098, "arm"), ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(8).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("lx", ((V)((ToNum(s_1095) * 0.9)))).Put("turn", ((V)((ToNum(s_1095) * 0.3)))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("frown", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, s_1095, ((V)((-3D))), ((V)((-2D))))), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).PutK(Get(k_1097, "hy"), ((V)((-4D)))).V, NewObj(1).PutK(Get(k_1097, "hy"), ((V)(0D))).V), "rest", ((V)(400D))), "done", NewObj(1).Put("tap", Arr(((V)((LtN(s_1095, 0D) ? 30D : 70D))), ((V)(78D)))).V);
return default;
}, 1, "", true);
Set(ST_18, "poke_sideL", Call(pokeSide_46, V.Undef, ((V)((-1D)))));
Set(ST_18, "poke_sideR", Call(pokeSide_46, V.Undef, ((V)(1D))));
pokeFoot_47 = Fn((V _arrowThis1107, int _argc1100, V s_1106, V _a1103, V _a1104, V _a1105, V[] _rest1101) => {
V k_1108 = default;
V j_1109 = default;
k_1108 = Call(S_14, V.Undef, s_1106);
j_1109 = Call(S_14, V.Undef, ((V)((-ToNum(s_1106)))));
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(80D)), NewObj(3).Put("sq", ((V)(0.08))).Put("wide", ((V)(1D))).PutK(Get(k_1108, "foot"), ((V)(2D))).V, ((V)("o"))), "to", ((V)(250D)), NewObj(7).Put("lift", ((V)(8D))).Put("sq", ((V)((-0.14)))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).Put("open", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(250D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.2))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(7).Put("sq", ((V)(0D))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("open", ((V)(0.2))).Put("wide", ((V)(0.3))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(5).PutK(Get(k_1108, "foot"), ((V)(4D))).PutK(Get(j_1109, "foot"), ((V)(0D))).Put("tilt", ((V)(((-ToNum(s_1106)) * 3D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, NewObj(3).PutK(Get(k_1108, "foot"), ((V)(0D))).PutK(Get(j_1109, "foot"), ((V)(4D))).Put("tilt", ((V)((ToNum(s_1106) * 3D)))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(3).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("tilt", ((V)(0D))).V), "rest", ((V)(400D))), "done", NewObj(1).Put("tap", Arr(((V)((LtN(s_1106, 0D) ? 38D : 62D))), ((V)(91D)))).V);
return default;
}, 1, "", true);
Set(ST_18, "poke_footL", Call(pokeFoot_47, V.Undef, ((V)((-1D)))));
Set(ST_18, "poke_footR", Call(pokeFoot_47, V.Undef, ((V)(1D))));
Set(ST_18, "poke_tail", Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(80D)), NewObj(3).Put("sq", ((V)(0.1))).Put("wide", ((V)(1D))).Put("curl", ((V)(0.9))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(4).Put("lift", ((V)(6D))).Put("sq", ((V)((-0.12)))).Put("wag", ((V)(30D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.15))).V, ((V)("i"))), "to", ((V)(150D)), NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V), "to", ((V)(500D)), NewObj(5).Put("spin", ((V)(50D))).Put("turn", ((V)(0.7))).Put("lx", ((V)(1D))).Put("ly", ((V)(0.4))).Put("wide", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(25D))).V, NewObj(1).Put("wag", ((V)((-25D)))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("frown", ((V)(0.5))).Put("puff", ((V)(0.4))).V), "wait", ((V)(300D))), "to", ((V)(500D)), NewObj(8).Put("spin", ((V)(0D))).Put("turn", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("curl", ((V)(0D))).Put("wag", ((V)(0D))).Put("puff", ((V)(0D))).Put("frown", ((V)(0D))).V, ((V)("io"))), "rest", ((V)(400D))), "done", NewObj(1).Put("tap", Arr(((V)(86D)), ((V)(70D)))).V));
Set(ST_18, "poke", NewObj(2).Put("seq", Arr(((V)("poke_head")), ((V)("poke_earL")), ((V)("poke_nose")), ((V)("poke_cheekR")), ((V)("poke_eyeL")), ((V)("poke_belly")), ((V)("poke_sideL")), ((V)("poke_sideR")), ((V)("poke_footL")), ((V)("poke_tail")), ((V)("poke_earR")), ((V)("poke_cheekL")), ((V)("poke_eyeR")), ((V)("poke_footR")))).Put("k", NewObj(0).V).V);
Set(ST_18, "cry", Call(Fn((V _arrowThis1116, int _argc1110, V _a1112, V _a1113, V _a1114, V _a1115, V[] _rest1111) => {
V t_1117 = default;
V a_1118 = default;
V b_1119 = default;
t_1117 = Invoke(Call(TL_13, V.Undef), "to", ((V)(700D)), NewObj(11).Put("pitch", ((V)((-0.4)))).Put("ly", ((V)(0.6))).Put("frown", ((V)(0.85))).Put("teary", ((V)(1D))).Put("earL", ((V)(24D))).Put("earR", ((V)(24D))).Put("sl", ((V)(1D))).Put("sq", ((V)(0.06))).Put("curl", ((V)((-0.6)))).Put("armL", ((V)((-6D)))).Put("armR", ((V)((-6D)))).V, ((V)("io")));
a_1118 = Get(t_1117, "t");
Invoke(t_1117, "osc", ((V)(5600D)), ((V)(28D)), NewObj(2).Put("frown", ((V)(1D))).Put("open", ((V)(0.05))).V, NewObj(2).Put("frown", ((V)(0.75))).Put("open", ((V)(0D))).V, ((V)("s")));
b_1119 = Get(t_1117, "t");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1117, "at", Add(a_1118, ((V)(600D)))), "e", ((V)("emit")), ((V)("tear")), ((V)("eyeL"))), "at", Add(a_1118, ((V)(1500D)))), "e", ((V)("emit")), ((V)("tear")), ((V)("eyeR"))), "at", Add(a_1118, ((V)(2900D)))), "e", ((V)("emit")), ((V)("tear")), ((V)("eyeL"))), "at", Add(a_1118, ((V)(4000D)))), "e", ((V)("emit")), ((V)("tear")), ((V)("eyeR"))), "at", Add(a_1118, ((V)(4900D)))), "e", ((V)("emit")), ((V)("tear")), ((V)("eyeL")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_1117, "at", Add(a_1118, ((V)(1800D)))), "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0.02))).Put("pitch", ((V)((-0.25)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.4)))).V), "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0.02))).Put("pitch", ((V)((-0.27)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.4)))).V);
Invoke(Invoke(Invoke(Invoke(t_1117, "at", Add(a_1118, ((V)(3000D)))), "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-27D)))), NewObj(1).Put("htilt", ((V)(4D))).V), ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(2).Put("hRy", ((V)((-29D)))).Put("hRx", ((V)((-4D)))).V, NewObj(2).Put("hRy", ((V)((-25D)))).Put("hRx", ((V)((-7D)))).V, ((V)("s"))), "to", ((V)(350D)), NewObj(3).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_1117, "at", Add(a_1118, ((V)(4500D)))), "to", ((V)(500D)), NewObj(2).Put("sq", ((V)((-0.03)))).Put("pitch", ((V)((-0.2)))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(2).Put("sq", ((V)(0.08))).Put("pitch", ((V)((-0.45)))).V, ((V)("io"))), "at", b_1119);
return Invoke(Invoke(t_1117, "rest", ((V)(600D))), "done");
return default;
}, 0, "", true), V.Undef));
Set(ST_18, "sob", Call(Fn((V _arrowThis1126, int _argc1120, V _a1122, V _a1123, V _a1124, V _a1125, V[] _rest1121) => {
V t_1127 = default;
V a_1128 = default;
V b_1129 = default;
V c_1130 = default;
V d_1131 = default;
t_1127 = Invoke(Invoke(Invoke(Invoke(Invoke(Call(TL_13, V.Undef), "to", ((V)(300D)), NewObj(6).Put("frown", ((V)(1D))).Put("teary", ((V)(1D))).Put("pitch", ((V)((-0.2)))).Put("sq", ((V)(0.05))).Put("earL", ((V)(18D))).Put("earR", ((V)(18D))).V, ((V)("io"))), "osc", ((V)(400D)), ((V)(4D)), NewObj(1).Put("open", ((V)(0.1))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("l"))), "to", ((V)(260D)), NewObj(7).Put("pitch", ((V)(0.5))).Put("open", ((V)(0.85))).Put("mw", ((V)(1.25))).Put("sqz", ((V)(1D))).Put("earL", ((V)(22D))).Put("earR", ((V)(22D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "em", ((V)(2600D)), ((V)(90D)), ((V)("gush")), ((V)("eyeL")), ((V)(1D))), "em", ((V)(2600D)), ((V)(90D)), ((V)("gush")), ((V)("eyeR")), ((V)(1D)));
a_1128 = Get(t_1127, "t");
Invoke(t_1127, "osc", ((V)(2600D)), ((V)(13D)), NewObj(3).Put("sq", ((V)(0.12))).Put("lift", ((V)(0D))).Put("x", ((V)(0.5))).V, NewObj(3).Put("sq", ((V)(0D))).Put("lift", ((V)(1.2))).Put("x", ((V)((-0.5)))).V, ((V)("io")));
b_1129 = Get(t_1127, "t");
Invoke(Invoke(Invoke(t_1127, "at", a_1128), "osc", ((V)(2600D)), ((V)(5D)), NewObj(3).Put("armL", ((V)(100D))).Put("armR", ((V)(40D))).Put("htilt", ((V)(4D))).V, NewObj(3).Put("armL", ((V)(40D))).Put("armR", ((V)(100D))).Put("htilt", ((V)((-4D)))).V, ((V)("io"))), "at", b_1129);
Invoke(Invoke(Invoke(Invoke(Invoke(t_1127, "to", ((V)(400D)), NewObj(9).Put("open", ((V)(0.3))).Put("mw", ((V)(0.9))).Put("pitch", ((V)(0.1))).Put("sq", ((V)((-0.08)))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("x", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.02))).V), "to", ((V)(300D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)((-1D))), ((V)(6D)), ((V)((-27D)))), Call(hand_15, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-27D)))), NewObj(4).Put("pitch", ((V)(0.3))).Put("open", ((V)(0.8))).Put("mw", ((V)(1.1))).Put("sqz", ((V)(1D))).V), ((V)("io"))), "em", ((V)(2000D)), ((V)(110D)), ((V)("gush")), ((V)("eyeL")), ((V)(1D))), "em", ((V)(2000D)), ((V)(110D)), ((V)("gush")), ((V)("eyeR")), ((V)(1D)));
c_1130 = Get(t_1127, "t");
Invoke(t_1127, "osc", ((V)(2000D)), ((V)(8D)), NewObj(3).Put("hLy", ((V)((-29D)))).Put("hRy", ((V)((-25D)))).Put("sq", ((V)(0.1))).V, NewObj(3).Put("hLy", ((V)((-25D)))).Put("hRy", ((V)((-29D)))).Put("sq", ((V)(0D))).V, ((V)("s")));
d_1131 = Get(t_1127, "t");
Invoke(Invoke(Invoke(t_1127, "at", c_1130), "osc", ((V)(2000D)), ((V)(10D)), NewObj(2).Put("lift", ((V)(1D))).Put("x", ((V)(0.4))).V, NewObj(2).Put("lift", ((V)(0D))).Put("x", ((V)((-0.4)))).V, ((V)("io"))), "at", d_1131);
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1127, "to", ((V)(400D)), NewObj(10).Put("hLx", ((V)(0D))).Put("hLy", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("open", ((V)(0.1))).Put("mw", ((V)(1D))).Put("sqz", ((V)(0.2))).Put("pitch", ((V)((-0.2)))).Put("x", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("sq", ((V)(0.05))).Put("pitch", ((V)((-0.1)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V), "to", ((V)(500D)), NewObj(5).Put("teary", ((V)(0.6))).Put("sqz", ((V)(0D))).Put("frown", ((V)(0.8))).Put("earL", ((V)(20D))).Put("earR", ((V)(20D))).V), "rest", ((V)(600D))), "done");
return default;
}, 0, "", true), V.Undef));
Set(ST_18, "stinky", Call(Fn((V _arrowThis1138, int _argc1132, V _a1134, V _a1135, V _a1136, V _a1137, V[] _rest1133) => {
V t_1139 = default;
V a_1140 = default;
V b_1141 = default;
V L_1142 = default;
t_1139 = Call(TL_13, V.Undef);
Invoke(Invoke(Invoke(t_1139, "to", ((V)(450D)), NewObj(7).Put("armR", ((V)(120D))).Put("hRy", ((V)((-3D)))).Put("turn", ((V)(0.6))).Put("pitch", ((V)((-0.25)))).Put("lx", ((V)(1D))).Put("ly", ((V)(0.5))).Put("lean", ((V)(0.8))).V, ((V)("io"))), "osc", ((V)(600D)), ((V)(3D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(14).Put("lean", ((V)((-3D)))).Put("tilt", ((V)((-4D)))).Put("wide", ((V)(1D))).Put("tongue", ((V)(1D))).Put("open", ((V)(0.3))).Put("sqz", ((V)(0.7))).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).Put("armR", ((V)(0D))).Put("hRy", ((V)(0D))).Put("turn", ((V)((-0.2)))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0.15))).V, ((V)("o")));
a_1140 = Get(t_1139, "t");
Invoke(t_1139, "wait", ((V)(700D)));
b_1141 = Get(t_1139, "t");
Invoke(Invoke(Invoke(t_1139, "at", a_1140), "osc", ((V)(700D)), ((V)(7D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "at", b_1141);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1139, "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-16D)))), NewObj(12).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("wide", ((V)(0D))).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("sqz", ((V)(0D))).Put("frown", ((V)(0.6))).Put("puff", ((V)(0.3))).Put("earL", ((V)(8D))).Put("earR", ((V)(8D))).Put("pitch", ((V)(0D))).Put("turn", ((V)(0D))).V), ((V)("io"))), "osc", ((V)(1300D)), ((V)(5D)), NewObj(1).Put("hRx", ((V)((-16D)))).V, NewObj(1).Put("hRx", ((V)((-9D)))).V, ((V)("io"))), "to", ((V)(350D)), NewObj(7).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("puff", ((V)(0D))).Put("frown", ((V)(0.2))).Put("blush", ((V)(1D))).Put("smile", ((V)(0.35))).Put("htilt", ((V)(6D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sweat")), Arr(((V)(67D)), ((V)(26D)))), "to", ((V)(350D)), Call(o_17, V.Undef, Call(hand_15, V.Undef, ((V)(1D)), ((V)((-2D))), ((V)((-30D)))), NewObj(1).Put("armR", ((V)(25D))).V), ((V)("io"))), "osc", ((V)(800D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-4D)))).V, NewObj(1).Put("hRx", ((V)(4D))).V, ((V)("s"))), "to", ((V)(350D)), NewObj(5).Put("hRx", ((V)(0D))).Put("hRy", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("blush", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(6).Put("armL", ((V)(120D))).Put("hLy", ((V)((-3D)))).Put("turn", ((V)((-0.6)))).Put("pitch", ((V)((-0.25)))).Put("lx", ((V)((-1D)))).Put("ly", ((V)(0.5))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(11).Put("armL", ((V)(0D))).Put("hLy", ((V)(0D))).Put("turn", ((V)(0D))).Put("pitch", ((V)((-0.15)))).Put("lx", ((V)(0D))).Put("ly", ((V)(0.3))).Put("earL", ((V)(22D))).Put("earR", ((V)(22D))).Put("sl", ((V)(1D))).Put("frown", ((V)(0.8))).Put("smile", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(500D))), "rest", ((V)(600D)));
L_1142 = Invoke(t_1139, "loop", NewObj(1).Put("emit", Arr(Arr(((V)(0D)), ((V)(1000000000D)), ((V)(280D)), ((V)("stink")), ((V)("body")), ((V)(1D))), Arr(((V)(140D)), ((V)(1000000000D)), ((V)(560D)), ((V)("stink")), ((V)("head")), ((V)(1D))), Arr(((V)(0D)), ((V)(1000000000D)), ((V)(900D)), ((V)("stink")), ((V)("sideL")), ((V)(1D))), Arr(((V)(450D)), ((V)(1000000000D)), ((V)(900D)), ((V)("stink")), ((V)("sideR")), ((V)(1D))))).V);
Set(Get(L_1142, "k"), "green", Arr(Arr(((V)(0D)), ((V)(0.75)))));
Set(L_1142, "fx", Fn((V _arrowThis1151, int _argc1143, V I_1149, V tt_1150, V _a1147, V _a1148, V[] _rest1144) => {
V c_1152 = default;
JsStrBuf h_1153 = null;
c_1152 = (Get(Get(I_1149, "W"), "body") is var _t1154 && Truthy(_t1154) ? _t1154 : Arr(((V)(50D)), ((V)(78D))));
h_1153 = new JsStrBuf("");
{
double i_1155 = 0;
i_1155 = 0D;
while (true) {
if (!((i_1155 < 2D))) break;
double a_1157 = 0;
V x_1158 = default;
double y_1159 = 0;
double fl_1160 = 0;
a_1157 = ((ToNum(tt_1150) / (520D + (i_1155 * 140D))) + (i_1155 * System.Math.PI));
x_1158 = Add(GetIdx(c_1152, 0D), ((V)((FdLibm.Cos(a_1157) * (26D - (i_1155 * 4D))))));
y_1159 = ((ToNum(GetIdx(c_1152, 1D)) - 18D) + (FdLibm.Sin((a_1157 * 1.3)) * 12D));
fl_1160 = (FdLibm.Sin(((ToNum(tt_1150) / 18D) + i_1155)) * 0.6);
h_1153.S("<g transform=\"translate(").V(Call(r2_10, V.Undef, x_1158)).S(" ").V(Call(r2_10, V.Undef, ((V)(y_1159)))).S(")\"><ellipse cx=\"-0.8\" cy=\"-1\" rx=\"1.1\" ry=\"").V(Call(r2_10, V.Undef, ((V)((0.5 + (fl_1160 * 0.4)))))).S("\" fill=\"#ffffff\" opacity=\"0.8\"/><ellipse cx=\"0.8\" cy=\"-1\" rx=\"1.1\" ry=\"").V(Call(r2_10, V.Undef, ((V)((0.5 - (fl_1160 * 0.4)))))).S("\" fill=\"#ffffff\" opacity=\"0.8\"/><circle r=\"0.95\" fill=\"#2a1a30\"/></g>");
i_1155++;
}
}
return ((V)(h_1153.Str));
return default;
}, 2, "", true));
return L_1142;
return default;
}, 0, "", true), V.Undef));
whip_48 = Fn((V _arrowThis1170, int _argc1161, V t_1167, V dir_1168, V chain_1169, V _a1166, V[] _rest1162) => {
V d_1171 = default;
double ld_1172 = 0;
V A_1173 = default;
V B_1174 = default;
V FT_1175 = default;
d_1171 = (dir_1168 is var _t1176 && Truthy(_t1176) ? _t1176 : ((V)(1D)));
ld_1172 = (GtN(d_1171, 0D) ? 1D : (-1D));
A_1173 = Get(Call(S_14, V.Undef, ((V)(ld_1172))), "arm");
B_1174 = Get(Call(S_14, V.Undef, ((V)((-ld_1172)))), "arm");
FT_1175 = Get(Call(S_14, V.Undef, ((V)(ld_1172))), "foot");
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1167, "to", ((V)(75D)), Call(o_17, V.Undef, NewObj(9).Put("lx", ((V)((0.9 * ToNum(d_1171))))).Put("htilt", ((V)((3D * ToNum(d_1171))))).Put("sq", ((V)((-0.03)))).PutK(A_1173, ((V)(6D))).PutK(B_1174, ((V)(6D))).Put("earL", ((V)((-3D)))).Put("earR", ((V)((-3D)))).Put("hap", ((V)(0.2))).Put("open", ((V)(0D))).V), ((V)("io"))), "to", ((V)(155D)), Call(o_17, V.Undef, NewObj(15).Put("sq", ((V)(0.14))).Put("spin", ((V)(((-32D) * ToNum(d_1171))))).Put("turn", ((V)(((-0.12) * ToNum(d_1171))))).Put("hyaw", ((V)((0.55 * ToNum(d_1171))))).Put("tilt", ((V)(((-3D) * ToNum(d_1171))))).Put("lean", ((V)(((-1D) * ToNum(d_1171))))).Put("htilt", ((V)((7D * ToNum(d_1171))))).Put("lx", d_1171).PutK(B_1174, ((V)(70D))).PutK(A_1173, ((V)((-6D)))).Put("close", ((V)(0.2))).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).Put("wag", ((V)((14D * ToNum(d_1171))))).Put("hap", ((V)(0.35))).V, Call(hand_15, V.Undef, ((V)(ld_1172)), ((V)(7D)), ((V)((-2D))), ((V)(5D)))), ((V)("o"))), "to", ((V)(100D)), NewObj(4).Put("sq", ((V)(0.16))).Put("spin", ((V)(((-36D) * ToNum(d_1171))))).Put("htilt", ((V)((8D * ToNum(d_1171))))).PutK(B_1174, ((V)(76D))).V, ((V)("io"))), "to", ((V)(50D)), Call(o_17, V.Undef, NewObj(15).Put("spin", ((V)((40D * ToNum(d_1171))))).Put("sblur", ((V)(0.5))).Put("sq", ((V)((-0.1)))).Put("turn", ((V)(0D))).Put("hyaw", ((V)((0.35 * ToNum(d_1171))))).Put("tilt", ((V)((4D * ToNum(d_1171))))).Put("lean", ((V)((0.6 * ToNum(d_1171))))).Put("htilt", ((V)((10D * ToNum(d_1171))))).Put("lx", ((V)((0.6 * ToNum(d_1171))))).PutK(B_1174, ((V)(125D))).PutK(A_1173, ((V)(30D))).Put("close", ((V)(0D))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).PutK(FT_1175, ((V)(8D))).V, Call(hand_15, V.Undef, ((V)(ld_1172)), ((V)(0D)), ((V)(2D)), ((V)(3D))), Call(hand_15, V.Undef, ((V)((-ld_1172))), ((V)(0D)), ((V)((-4D))), ((V)(3D)))), ((V)("l"))), "to", ((V)(180D)), NewObj(7).Put("spin", ((V)((378D * ToNum(d_1171))))).Put("sq", ((V)((-0.12)))).PutK(B_1174, ((V)(128D))).PutK(A_1173, ((V)(32D))).Put("earL", ((V)((-12D)))).Put("earR", ((V)((-12D)))).PutK(FT_1175, ((V)(9D))).V, ((V)("l"))), "to", ((V)(200D)), Call(o_17, V.Undef, NewObj(17).Put("spin", ((V)((360D * ToNum(d_1171))))).Put("sblur", ((V)(0D))).Put("sq", ((V)(0.12))).PutK(FT_1175, ((V)(0D))).Put("hyaw", ((V)(((-0.12) * ToNum(d_1171))))).Put("tilt", ((V)(((-2D) * ToNum(d_1171))))).Put("lean", ((V)(0D))).Put("htilt", ((V)(((-3D) * ToNum(d_1171))))).Put("lx", ((V)(0D))).PutK(A_1173, ((V)(115D))).PutK(B_1174, ((V)(40D))).Put("earL", ((V)(12D))).Put("earR", ((V)(12D))).Put("wag", ((V)(((-18D) * ToNum(d_1171))))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, Call(hand_15, V.Undef, ((V)(ld_1172)), ((V)(0D)), ((V)(0D)), ((V)(0D))), Call(hand_15, V.Undef, ((V)((-ld_1172))), ((V)(0D)), ((V)(0D)), ((V)(0D)))), ((V)("o"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
if (Truthy(chain_1169)) {
return t_1167;
}
Invoke(Invoke(Invoke(t_1167, "to", ((V)(150D)), NewObj(6).Put("sq", ((V)(0.06))).Put("hyaw", ((V)(0D))).Put("tilt", ((V)(((-0.6) * ToNum(d_1171))))).Put("htilt", ((V)(((-1D) * ToNum(d_1171))))).PutK(A_1173, ((V)(118D))).PutK(B_1174, ((V)(42D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(8).Put("sq", ((V)((-0.05)))).Put("tilt", ((V)((0.5 * ToNum(d_1171))))).Put("htilt", ((V)((1D * ToNum(d_1171))))).PutK(A_1173, ((V)(20D))).PutK(B_1174, ((V)(8D))).Put("earL", ((V)((-5D)))).Put("earR", ((V)((-5D)))).Put("wag", ((V)((8D * ToNum(d_1171))))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(9).Put("sq", ((V)(0D))).Put("tilt", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("wag", ((V)(0D))).Put("hap", ((V)(0.6))).V, ((V)("io")));
return t_1167;
return default;
}, 3, "", true);
Set(ST_18, "spin@mittens", Call(Fn((V _arrowThis1183, int _argc1177, V _a1179, V _a1180, V _a1181, V _a1182, V[] _rest1178) => {
V t_1184 = default;
t_1184 = Call(TL_13, V.Undef);
Invoke(t_1184, "wait", ((V)(150D)));
Call(whip_48, V.Undef, t_1184, ((V)(1D)), (true ? V.True : V.False));
Call(whip_48, V.Undef, t_1184, ((V)((-1D))));
return Invoke(Invoke(Invoke(t_1184, "wait", ((V)(300D))), "rest", ((V)(450D))), "done", NewObj(1).Put("whip", ((V)(1D))).V);
return default;
}, 0, "", true), V.Undef));
Invoke(R_8, "add", ST_18);
F_49 = Object_keys(FOODS_28);
Set(R_8, "GROUPS", Arr(NewObj(3).Put("name", ((V)("Idle"))).Put("where", ((V)("Plays by itself"))).Put("items", Arr(Arr(((V)("idle")), ((V)("Idle")), ((V)("Breathes and sways. Every few seconds she looks around, yawns or waves."))), Arr(((V)("idle_look")), ((V)("Look left and right")), ((V)("Eyes first, then the head turns in a small dipping arc with a blink; the chest follows a beat later, the weight shifts onto that side, ears and tail trail behind. Feet stay planted."))), Arr(((V)("idle_yawn")), ((V)("Yawn")), ((V)("Stretches both arms up, big yawn, smacks her lips."))), Arr(((V)("idle_waveL")), ((V)("Wave, left paw")), ((V)("Lifts her left paw and waves with a big smile."))), Arr(((V)("idle_waveR")), ((V)("Wave, right paw")), ((V)("Same with the right paw."))))).V, NewObj(3).Put("name", ((V)("Dance"))).Put("where", ((V)("10-second loop, repeats non-stop"))).Put("items", Arr(Arr(((V)("dance")), ((V)("Signature dance")), ((V)("Two-step, running man, the Woah, hop-spin, Billy Bounce."))))).V, NewObj(3).Put("name", ((V)("Poke"))).Put("where", ((V)("Tap anywhere on her"))).Put("items", Arr(Arr(((V)("poke")), ((V)("Every spot in turn")), ((V)("Plays all 14 reactions one after another."))), Arr(((V)("poke_head")), ((V)("Top of head")), ((V)("Bonk: squashes, eyes shut, rubs her head."))), Arr(((V)("poke_earL")), ((V)("Left ear")), ((V)("Ear flicks, head shakes, giggles."))), Arr(((V)("poke_earR")), ((V)("Right ear")), ((V)("Ear flicks, head shakes, giggles."))), Arr(((V)("poke_nose")), ((V)("Nose")), ((V)("Goes cross-eyed, then sneezes."))), Arr(((V)("poke_eyeL")), ((V)("Left eye")), ((V)("Flinches and rubs her eye."))), Arr(((V)("poke_eyeR")), ((V)("Right eye")), ((V)("Flinches and rubs her eye."))), Arr(((V)("poke_cheekL")), ((V)("Left cheek")), ((V)("Tilts away, blushes, giggles."))), Arr(((V)("poke_cheekR")), ((V)("Right cheek")), ((V)("Tilts away, blushes, giggles."))), Arr(((V)("poke_belly")), ((V)("Belly")), ((V)("Ticklish: curls up laughing."))), Arr(((V)("poke_sideL")), ((V)("Left side")), ((V)("Pushed off balance, hops back, rubs the spot."))), Arr(((V)("poke_sideR")), ((V)("Right side")), ((V)("Pushed off balance, hops back, rubs the spot."))), Arr(((V)("poke_footL")), ((V)("Left foot")), ((V)("Jumps, then hops foot to foot."))), Arr(((V)("poke_footR")), ((V)("Right foot")), ((V)("Jumps, then hops foot to foot."))), Arr(((V)("poke_tail")), ((V)("Tail")), ((V)("Jumps, turns to look at her tail, pouts."))))).V, NewObj(3).Put("name", ((V)("Eating"))).Put("where", ((V)("20 foods"))).Put("items", Invoke(F_49, "map", Fn((V _arrowThis1192, int _argc1185, V k_1191, V _a1188, V _a1189, V _a1190, V[] _rest1186) => {
return Arr(((V)(JsStrBuf.Begin().S("eat_").V(k_1191).End())), Get(GetK(FOODS_28, k_1191), "label"), Get(GetK(FOODS_28, k_1191), "d"));
}, 1, "", true))).V, NewObj(3).Put("name", ((V)("Bathing"))).Put("where", ((V)("12 kinds, no tub drawn"))).Put("items", Invoke(Object_keys(B_37), "map", Fn((V _arrowThis1200, int _argc1193, V k_1199, V _a1196, V _a1197, V _a1198, V[] _rest1194) => {
return Arr(((V)(JsStrBuf.Begin().S("bath_").V(k_1199).End())), GetIdx(GetK(B_37, k_1199), 0D), GetIdx(GetK(B_37, k_1199), 1D));
}, 1, "", true))).V, NewObj(3).Put("name", ((V)("Feelings"))).Put("where", ((V)("Game, Crib, reveal"))).Put("items", Arr(Arr(((V)("cry")), ((V)("Sad: quiet crying")), ((V)("Ears droop, teary eyes, lip wobbles, a few tears, wipes an eye."))), Arr(((V)("sob")), ((V)("Sad: heavy crying")), ((V)("Wails with tears gushing, sobs shake her body, rubs both eyes."))), Arr(((V)("stinky")), ((V)("Stinky")), ((V)("Needs a bath: stink lines, flies, sniffs herself, fans the smell. Loops."))), Arr(((V)("happy")), ((V)("Happy")), ((V)("Double bounce, arms up, tail wagging."))), Arr(((V)("surprised")), ((V)("Surprised")), ((V)("Jumps back wide-eyed, glances around."))), Arr(((V)("sleep")), ((V)("Sleepy and asleep")), ((V)("Yawns, nods off, breathes, wakes up."))))).V, NewObj(3).Put("name", ((V)("Moves"))).Put("where", ((V)("Crib and game"))).Put("items", Arr(Arr(((V)("look")), ((V)("Look around")), ((V)("Eyes first, head follows."))), Arr(((V)("squish")), ((V)("Squish")), ((V)("Pressed flat, springs back."))), Arr(((V)("spin")), ((V)("Spin around")), ((V)("Full 360\u00b0 turn."))), Arr(((V)("hop")), ((V)("Hop")), ((V)("Crouch, jump, squash landing."))))).V));
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
