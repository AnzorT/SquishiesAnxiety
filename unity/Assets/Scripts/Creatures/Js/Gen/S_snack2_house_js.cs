// snack2-house.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_snack2_house_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V K_8 = default;
V walks_9 = default;
if (_self1.IsNullish) _self1 = GlobalV;
K_8 = Arr(((V)("frankie")), ((V)("corny")), ((V)("peppi")), ((V)("nori")), ((V)("sunny")), ((V)("toco")), ((V)("churro")), ((V)("khinki")), ((V)("maki")), ((V)("noodle")), ((V)("flossie")));
Invoke(Set(G("window"), "HouseCreatures", (Get(G("window"), "HouseCreatures") is var _t334 && Truthy(_t334) ? _t334 : Arr())), "push", Fn((V _self10, int _argc11, V H_17, V _a14, V _a15, V _a16, V[] _rest12) => {
V build_18 = default;
V bedBuild_19 = default;
V waterBuild_20 = default;
V playBuild_21 = default;
V bBuild_22 = default;
V hand_23 = default;
V both_24 = default;
V o_25 = default;
V sp_26 = default;
V bk_27 = default;
V hop_28 = default;
V RL_29 = default;
V mk_30 = default;
V SIG_31 = default;
V SLEEPY_32 = default;
V DR_33 = default;
V WK_34 = default;
V SW_35 = default;
V SN_36 = default;
V CHEER_37 = default;
V FC_38 = default;
V TBC_39 = default;
if (_self10.IsNullish) _self10 = GlobalV;
{ V _t40 = H_17;
if (_t40.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t40));
{ V _t41 = Get(_t40, "build");
build_18 = _t41; }
{ V _t42 = Get(_t40, "bedBuild");
bedBuild_19 = _t42; }
{ V _t43 = Get(_t40, "waterBuild");
waterBuild_20 = _t43; }
{ V _t44 = Get(_t40, "playBuild");
playBuild_21 = _t44; }
{ V _t45 = Get(_t40, "bBuild");
bBuild_22 = _t45; }
{ V _t46 = Get(_t40, "hand");
hand_23 = _t46; }
{ V _t47 = Get(_t40, "both");
both_24 = _t47; }
{ V _t48 = Get(_t40, "o");
o_25 = _t48; } }
sp_26 = Fn((V _arrowThis59, int _argc49, V t_55, V v_56, V d_57, V hold_58, V[] _rest50) => {
V b_60 = default;
b_60 = NewObj(0).V;
Invoke(Object_keys(v_56), "forEach", Fn((V _arrowThis68, int _argc61, V k_67, V _a64, V _a65, V _a66, V[] _rest62) => {
return SetK(b_60, k_67, (!GetK(Get(t_55, "B"), k_67).IsNullish ? GetK(Get(t_55, "B"), k_67) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_55, "to", ((V)((ToNum((d_57 is var _t71 && Truthy(_t71) ? _t71 : ((V)(700D)))) * 0.4))), v_56, ((V)("o"))), "wait", (hold_58 is var _t70 && Truthy(_t70) ? _t70 : ((V)(300D)))), "to", ((V)((ToNum((d_57 is var _t69 && Truthy(_t69) ? _t69 : ((V)(700D)))) * 0.6))), b_60, ((V)("io")));
return t_55;
return default;
}, 4, "", true);
bk_27 = Fn((V _arrowThis80, int _argc72, V t_78, V d_79, V _a76, V _a77, V[] _rest73) => {
return Invoke(t_78, "back", (d_79 is var _t81 && Truthy(_t81) ? _t81 : ((V)(420D))));
}, 2, "", true);
hop_28 = NewObj(2).Put("dn", ((V)("hop"))).Put("up", ((V)("hop"))).V;
RL_29 = NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V;
mk_30 = Fn((V _arrowThis91, int _argc82, V key_88, V @base_89, V P_90, V _a87, V[] _rest83) => {
return Call(build_18, V.Undef, key_88, Call(o_25, V.Undef, @base_89, P_90, NewObj(2).Put("pose", Call(o_25, V.Undef, (Get(@base_89, "pose") is var _t92 && Truthy(_t92) ? _t92 : NewObj(0).V), (Get(P_90, "pose") is var _t93 && Truthy(_t93) ? _t93 : NewObj(0).V))).Put("lpose", Call(o_25, V.Undef, (Get(@base_89, "lpose") is var _t94 && Truthy(_t94) ? _t94 : NewObj(0).V), RL_29, (Get(P_90, "lpose") is var _t95 && Truthy(_t95) ? _t95 : NewObj(0).V))).V));
}, 3, "", true);
SIG_31 = NewObj(11).Put("frankie", Fn((V _arrowThis103, int _argc96, V t_102, V _a99, V _a100, V _a101, V[] _rest97) => {
Call(sp_26, V.Undef, t_102, NewObj(4).Put("hug", ((V)((-0.7)))).Put("sq", Add(Get(Get(t_102, "B"), "sq"), ((V)(0.04)))).Put("smile", ((V)(1D))).Put("close", ((V)(0.6))).V, ((V)(1200D)), ((V)(900D)));
Invoke(t_102, "fx", ((V)("mustard")), ((V)("head")));
return t_102;
return default;
}, 1, "frankie", true)).Put("corny", Fn((V _arrowThis111, int _argc104, V t_110, V _a107, V _a108, V _a109, V[] _rest105) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_110, "to", ((V)(200D)), NewObj(1).Put("cfz", ((V)(1D))).V), "wait", ((V)(300D))), "to", ((V)(120D)), NewObj(1).Put("pop", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("popk")), ((V)("head")), ((V)(3D))), "to", ((V)(380D)), NewObj(2).Put("pop", ((V)(0D))).Put("cfz", ((V)(0D))).V, ((V)("i")));
return Call(bk_27, V.Undef, t_110);
return default;
}, 1, "corny", true)).Put("peppi", Fn((V _arrowThis119, int _argc112, V t_118, V _a115, V _a116, V _a117, V[] _rest113) => {
return Call(sp_26, V.Undef, t_118, NewObj(3).Put("flop", ((V)(0.8))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "peppi", true)).Put("nori", Fn((V _arrowThis127, int _argc120, V t_126, V _a123, V _a124, V _a125, V[] _rest121) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_126, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((ToNum((Get(Get(t_126, "B"), "pitch") is var _t129 && Truthy(_t129) ? _t129 : ((V)(0D)))) - 0.15)))).Put("close", ((V)(0.6))).V), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(2).Put("pitch", (Get(Get(t_126, "B"), "pitch") is var _t128 && Truthy(_t128) ? _t128 : ((V)(0D)))).Put("close", ((V)(0D))).V), "to", ((V)(140D)), NewObj(1).Put("ume", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("ume", ((V)(0D))).V, ((V)("i")));
return Call(bk_27, V.Undef, t_126);
return default;
}, 1, "nori", true)).Put("sunny", Fn((V _arrowThis137, int _argc130, V t_136, V _a133, V _a134, V _a135, V[] _rest131) => {
return Call(sp_26, V.Undef, t_136, NewObj(4).Put("cap", ((V)(0.7))).Put("wob", ((V)(0.8))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(700D)));
}, 1, "sunny", true)).Put("toco", Fn((V _arrowThis145, int _argc138, V t_144, V _a141, V _a142, V _a143, V[] _rest139) => {
{
double i_146 = 0;
i_146 = 0D;
while (true) {
if (!((i_146 < 2D))) break;
Invoke(Invoke(t_144, "to", ((V)(110D)), NewObj(1).Put("snap", ((V)((-0.5)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0.4))).V, ((V)("io")));
i_146++;
}
}
Invoke(Invoke(t_144, "to", ((V)(150D)), NewObj(1).Put("snap", ((V)(0D))).V), "fx", ((V)("lettuce")), ((V)("head")), ((V)(2D)));
return Call(bk_27, V.Undef, t_144);
return default;
}, 1, "toco", true)).Put("churro", Fn((V _arrowThis155, int _argc148, V t_154, V _a151, V _a152, V _a153, V[] _rest149) => {
Invoke(Invoke(Invoke(Invoke(t_154, "to", ((V)(400D)), NewObj(1).Put("cork", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("cork", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("sugar")), ((V)("head")), ((V)(3D)));
return Call(bk_27, V.Undef, t_154);
return default;
}, 1, "churro", true)).Put("khinki", Fn((V _arrowThis163, int _argc156, V t_162, V _a159, V _a160, V _a161, V[] _rest157) => {
Invoke(Invoke(t_162, "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("knot", ((V)(0.6))).V, NewObj(1).Put("knot", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("knot", ((V)(0D))).V);
return Call(bk_27, V.Undef, t_162);
return default;
}, 1, "khinki", true)).Put("maki", Fn((V _arrowThis171, int _argc164, V t_170, V _a167, V _a168, V _a169, V[] _rest165) => {
return Call(sp_26, V.Undef, t_170, NewObj(3).Put("veg", ((V)(0.9))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.5))).V, ((V)(900D)), ((V)(600D)));
}, 1, "maki", true)).Put("noodle", Fn((V _arrowThis179, int _argc172, V t_178, V _a175, V _a176, V _a177, V[] _rest173) => {
Invoke(Invoke(Invoke(Invoke(t_178, "to", ((V)(300D)), NewObj(3).Put("slurp", ((V)(1D))).Put("puff", ((V)((-0.3)))).Put("mw", ((V)(0.5))).V), "wait", ((V)(300D))), "to", ((V)(250D)), NewObj(5).Put("slurp", ((V)(0D))).Put("puff", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("head")));
return Call(bk_27, V.Undef, t_178);
return default;
}, 1, "noodle", true)).Put("flossie", Fn((V _arrowThis187, int _argc180, V t_186, V _a183, V _a184, V _a185, V[] _rest181) => {
return Call(sp_26, V.Undef, t_186, NewObj(3).Put("fluff", ((V)(1D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1000D)), ((V)(700D)));
}, 1, "flossie", true)).V;
SLEEPY_32 = NewObj(11).Put("frankie", Fn((V _arrowThis195, int _argc188, V t_194, V _a191, V _a192, V _a193, V[] _rest189) => {
return Call(sp_26, V.Undef, t_194, NewObj(2).Put("hug", ((V)((-0.5)))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "frankie", true)).Put("corny", Fn((V _arrowThis203, int _argc196, V t_202, V _a199, V _a200, V _a201, V[] _rest197) => {
return Call(sp_26, V.Undef, t_202, NewObj(2).Put("cfz", ((V)(0.5))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "corny", true)).Put("peppi", Fn((V _arrowThis211, int _argc204, V t_210, V _a207, V _a208, V _a209, V[] _rest205) => {
return Call(sp_26, V.Undef, t_210, NewObj(2).Put("flop", ((V)(1D))).Put("close", ((V)(1D))).V, ((V)(2000D)), ((V)(1800D)));
}, 1, "peppi", true)).Put("nori", Fn((V _arrowThis219, int _argc212, V t_218, V _a215, V _a216, V _a217, V[] _rest213) => {
return Call(sp_26, V.Undef, t_218, NewObj(2).Put("nwr", ((V)(0.5))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "nori", true)).Put("sunny", Fn((V _arrowThis227, int _argc220, V t_226, V _a223, V _a224, V _a225, V[] _rest221) => {
return Call(sp_26, V.Undef, t_226, NewObj(2).Put("cap", ((V)(0.3))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "sunny", true)).Put("toco", Fn((V _arrowThis235, int _argc228, V t_234, V _a231, V _a232, V _a233, V[] _rest229) => {
return Call(sp_26, V.Undef, t_234, NewObj(2).Put("snap", ((V)(0.6))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "toco", true)).Put("churro", Fn((V _arrowThis243, int _argc236, V t_242, V _a239, V _a240, V _a241, V[] _rest237) => {
return Call(sp_26, V.Undef, t_242, NewObj(2).Put("cork", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "churro", true)).Put("khinki", Fn((V _arrowThis251, int _argc244, V t_250, V _a247, V _a248, V _a249, V[] _rest245) => {
return Call(sp_26, V.Undef, t_250, NewObj(2).Put("kt", ((V)(0.6))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "khinki", true)).Put("maki", Fn((V _arrowThis259, int _argc252, V t_258, V _a255, V _a256, V _a257, V[] _rest253) => {
return Call(sp_26, V.Undef, t_258, NewObj(2).Put("veg", ((V)(0.4))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "maki", true)).Put("noodle", Fn((V _arrowThis267, int _argc260, V t_266, V _a263, V _a264, V _a265, V[] _rest261) => {
Invoke(Invoke(Invoke(t_266, "fx", ((V)("steam")), ((V)("head"))), "wait", ((V)(800D))), "fx", ((V)("steam")), ((V)("head")));
return t_266;
return default;
}, 1, "noodle", true)).Put("flossie", Fn((V _arrowThis275, int _argc268, V t_274, V _a271, V _a272, V _a273, V[] _rest269) => {
return Call(sp_26, V.Undef, t_274, NewObj(2).Put("fluff", ((V)(0.6))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "flossie", true)).V;
Call(mk_30, V.Undef, ((V)("frankie")), hop_28, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_31, "frankie"), Fn((V _arrowThis283, int _argc276, V t_282, V _a279, V _a280, V _a281, V[] _rest277) => {
Invoke(Invoke(t_282, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("slip", ((V)(0.4))).V, NewObj(1).Put("slip", ((V)((-0.4)))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(1).Put("slip", ((V)(0D))).V);
Call(bk_27, V.Undef, t_282);
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), Get(SLEEPY_32, "frankie"), ((V)("doze")), ((V)("belly")))).V);
Call(mk_30, V.Undef, ((V)("corny")), hop_28, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_31, "corny"), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_32, "corny"), ((V)("belly")))).V);
Call(mk_30, V.Undef, ((V)("peppi")), hop_28, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_31, "peppi"), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), Get(SLEEPY_32, "peppi"), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_30, V.Undef, ((V)("nori")), hop_28, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_31, "nori"), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_32, "nori"), ((V)("stretch")))).V);
Call(mk_30, V.Undef, ((V)("sunny")), hop_28, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_31, "sunny"), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_32, "sunny"), ((V)("belly")))).V);
Call(mk_30, V.Undef, ((V)("toco")), hop_28, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_31, "toco"), ((V)("kick")), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_32, "toco"), ((V)("belly")))).V);
Call(mk_30, V.Undef, ((V)("churro")), hop_28, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_31, "churro"), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("stretch")), ((V)("belly")))).V);
Call(mk_30, V.Undef, ((V)("khinki")), hop_28, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_31, "khinki"), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_32, "khinki"), ((V)("belly")))).V);
Call(mk_30, V.Undef, ((V)("maki")), hop_28, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_31, "maki"), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_30, V.Undef, ((V)("noodle")), hop_28, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_31, "noodle"), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), Get(SLEEPY_32, "noodle"), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_30, V.Undef, ((V)("flossie")), NewObj(2).Put("dn", ((V)("float"))).Put("up", ((V)("float"))).V, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_31, "flossie"), Fn((V _arrowThis291, int _argc284, V t_290, V _a287, V _a288, V _a289, V[] _rest285) => {
Invoke(Invoke(t_290, "to", ((V)(1400D)), NewObj(1).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("l")));
Call(bk_27, V.Undef, t_290);
return default;
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_32, "flossie"), ((V)("stretch")))).V);
DR_33 = NewObj(11).Put("frankie", ((V)("ketchup"))).Put("corny", ((V)("star"))).Put("peppi", ((V)("cheese"))).Put("nori", ((V)("fish"))).Put("sunny", ((V)("sun"))).Put("toco", ((V)("cheese"))).Put("churro", ((V)("cookie"))).Put("khinki", ((V)("cup"))).Put("maki", ((V)("fish"))).Put("noodle", ((V)("cup"))).Put("flossie", ((V)("cloud"))).V;
WK_34 = NewObj(11).Put("frankie", NewObj(1).Put("hug", ((V)(0.6))).V).Put("corny", NewObj(1).Put("pop", ((V)(0.8))).V).Put("peppi", NewObj(1).Put("flop", ((V)((-0.6)))).V).Put("nori", NewObj(1).Put("ume", ((V)(0.8))).V).Put("sunny", NewObj(1).Put("cap", ((V)(0.6))).V).Put("toco", NewObj(1).Put("snap", ((V)(0.8))).V).Put("churro", NewObj(1).Put("cork", ((V)(0.8))).V).Put("khinki", NewObj(1).Put("knot", ((V)(0.6))).V).Put("maki", NewObj(1).Put("veg", ((V)(0.8))).V).Put("noodle", NewObj(1).Put("lid", ((V)(0.8))).V).Put("flossie", NewObj(1).Put("fluff", ((V)(1D))).V).V;
Invoke(K_8, "forEach", Fn((V _arrowThis299, int _argc292, V k_298, V _a295, V _a296, V _a297, V[] _rest293) => {
return Call(bedBuild_19, V.Undef, k_298, NewObj(3).Put("dr", GetK(DR_33, k_298)).Put("wk", GetK(WK_34, k_298)).Put("s", GetK(SLEEPY_32, k_298)).V);
}, 1, "", true));
SW_35 = NewObj(11).Put("frankie", ((V)("bob"))).Put("corny", ((V)("bob"))).Put("peppi", ((V)("float"))).Put("nori", ((V)("bob"))).Put("sunny", ((V)("bob"))).Put("toco", ((V)("bob"))).Put("churro", ((V)("float"))).Put("khinki", ((V)("bob"))).Put("maki", ((V)("bob"))).Put("noodle", ((V)("bob"))).Put("flossie", ((V)("float"))).V;
Invoke(K_8, "forEach", Fn((V _arrowThis307, int _argc300, V k_306, V _a303, V _a304, V _a305, V[] _rest301) => {
return Call(waterBuild_20, V.Undef, k_306, NewObj(3).Put("sw", GetK(SW_35, k_306)).Put("k", NewObj(3).Put("a", GetK(WK_34, k_306)).Put("b", NewObj(0).V).Put("f", GetK(WK_34, k_306)).V).Put("s", GetK(SIG_31, k_306)).V);
}, 1, "", true));
SN_36 = NewObj(11).Put("frankie", ((V)("ketchup"))).Put("corny", ((V)("candy"))).Put("peppi", ((V)("cheese"))).Put("nori", ((V)("fish"))).Put("sunny", ((V)("cookie"))).Put("toco", ((V)("cheese"))).Put("churro", ((V)("cookie"))).Put("khinki", ((V)("cup"))).Put("maki", ((V)("fish"))).Put("noodle", ((V)("cup"))).Put("flossie", ((V)("candy"))).V;
CHEER_37 = NewObj(11).Put("frankie", NewObj(2).Put("cheer", NewObj(1).Put("hug", ((V)(0.6))).V).Put("cheerFx", Arr(((V)("mustard")), ((V)("head")))).V).Put("corny", NewObj(2).Put("cheer", NewObj(1).Put("pop", ((V)(1D))).V).Put("cheerFx", Arr(((V)("popk")), ((V)("head")))).V).Put("peppi", NewObj(1).Put("cheer", NewObj(1).Put("pull", ((V)(0.6))).V).V).Put("nori", NewObj(1).Put("cheer", NewObj(1).Put("ume", ((V)(1D))).V).V).Put("sunny", NewObj(1).Put("cheer", NewObj(1).Put("cap", ((V)(0.8))).V).V).Put("toco", NewObj(2).Put("cheer", NewObj(1).Put("snap", ((V)(0.8))).V).Put("cheerFx", Arr(((V)("lettuce")), ((V)("head")))).V).Put("churro", NewObj(2).Put("cheer", NewObj(1).Put("cork", ((V)(0.8))).V).Put("cheerFx", Arr(((V)("sugar")), ((V)("head")))).V).Put("khinki", NewObj(1).Put("cheer", NewObj(1).Put("knot", ((V)(0.6))).V).V).Put("maki", NewObj(1).Put("cheer", NewObj(1).Put("veg", ((V)(1D))).V).V).Put("noodle", NewObj(2).Put("cheer", NewObj(1).Put("lid", ((V)(0.8))).V).Put("cheerFx", Arr(((V)("steam")), ((V)("head")))).V).Put("flossie", NewObj(2).Put("cheer", NewObj(1).Put("fluff", ((V)(1D))).V).Put("cheerFx", Arr(((V)("floss")), ((V)("head")))).V).V;
Invoke(K_8, "forEach", Fn((V _arrowThis315, int _argc308, V k_314, V _a311, V _a312, V _a313, V[] _rest309) => {
return Call(playBuild_21, V.Undef, k_314, Call(o_25, V.Undef, GetK(CHEER_37, k_314), NewObj(3).Put("sn", GetK(SN_36, k_314)).Put("p", GetK(SIG_31, k_314)).Put("sp", NewObj(6).Put("armL", ((V)(42D))).Put("armR", ((V)(42D))).Put("hLy", ((V)((-7D)))).Put("hRy", ((V)((-7D)))).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-1D)))).V).V));
}, 1, "", true));
FC_38 = NewObj(11).Put("frankie", ((V)("boot"))).Put("corny", ((V)("star"))).Put("peppi", ((V)("cheese"))).Put("nori", ((V)("fish"))).Put("sunny", ((V)("shell"))).Put("toco", ((V)("leaf"))).Put("churro", ((V)("cookie"))).Put("khinki", ((V)("cup"))).Put("maki", ((V)("fish"))).Put("noodle", ((V)("cup"))).Put("flossie", ((V)("cloud"))).V;
TBC_39 = Arr(((V)("#5fb8e8")), ((V)("#7cc35a")), ((V)("#ff8fa8")), ((V)("#ffcc3a")), ((V)("#b98ae8")), ((V)("#ff8a4a")));
Invoke(K_8, "forEach", Fn((V _arrowThis324, int _argc316, V k_322, V i_323, V _a320, V _a321, V[] _rest317) => {
return Call(bBuild_22, V.Undef, k_322, Call(o_25, V.Undef, GetK(CHEER_37, k_322), NewObj(4).Put("fc", GetK(FC_38, k_322)).Put("tk", Call(o_25, V.Undef, GetK(WK_34, k_322))).Put("tb", GetIdx(TBC_39, (ToNum(i_323) % ToNum(Get(TBC_39, "length"))))).Put("sn", GetK(SN_36, k_322)).V));
}, 2, "", true));
if (Truthy(Get(H_17, "cBuild"))) {
Invoke(K_8, "forEach", Fn((V _arrowThis332, int _argc325, V k_331, V _a328, V _a329, V _a330, V[] _rest326) => {
return Invoke(H_17, "cBuild", k_331, NewObj(4).Put("ks", ((V)(((((SEqS(k_331, "maki") || SEqS(k_331, "corny")) || SEqS(k_331, "noodle")) || SEqS(k_331, "sunny")) ? "body" : "foot")))).Put("pc", ((V)("#ffb84a"))).Put("hc", ((V)("#ffb84a"))).Put("mc", ((V)((SEqS(k_331, "flossie") ? "#ff8fc8" : "#3b3b4a")))).V);
}, 1, "", true));
}
Set(G("window"), "HouseWalkRUN", Object_assign((Get(G("window"), "HouseWalkRUN") is var _t333 && Truthy(_t333) ? _t333 : NewObj(0).V), NewObj(4).Put("corny", NewObj(1).Put("pop", ((V)(0.4))).V).Put("toco", NewObj(1).Put("snap", ((V)(0.3))).V).Put("flossie", NewObj(1).Put("fluff", ((V)(0.4))).V).Put("khinki", NewObj(1).Put("knot", ((V)(0.4))).V).V));
return default;
}, 1, "", false));
walks_9 = Fn((V _arrowThis342, int _argc335, V W_341, V _a338, V _a339, V _a340, V[] _rest336) => {
V d_343 = default;
d_343 = Fn((V _arrowThis352, int _argc344, V k_350, V P_351, V _a348, V _a349, V[] _rest345) => {
return Invoke(W_341, "def", k_350, P_351);
}, 2, "", true);
Call(d_343, V.Undef, ((V)("frankie")), NewObj(3).Put("g", ((V)("shuffle"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("slip", Arr(((V)(0.25)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_343, V.Undef, ((V)("corny")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("pop", Arr(((V)(0.35)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_343, V.Undef, ((V)("peppi")), NewObj(3).Put("g", ((V)("waddle"))).Put("a", ((V)(0.8))).Put("x", NewObj(1).Put("flop", Arr(((V)(0.4)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_343, V.Undef, ((V)("nori")), NewObj(2).Put("g", ((V)("shuffle"))).Put("a", ((V)(0.8))).V);
Call(d_343, V.Undef, ((V)("sunny")), NewObj(2).Put("g", ((V)("eggroll"))).Put("a", ((V)(0.8))).V);
Call(d_343, V.Undef, ((V)("toco")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("snap", Arr(((V)(0.35)), ((V)(2D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_343, V.Undef, ((V)("churro")), NewObj(3).Put("g", ((V)("prance"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("cork", Arr(((V)(0.3)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_343, V.Undef, ((V)("khinki")), NewObj(3).Put("g", ((V)("waddle"))).Put("a", ((V)(0.85))).Put("x", NewObj(1).Put("knot", Arr(((V)(0.4)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_343, V.Undef, ((V)("maki")), NewObj(3).Put("g", ((V)("shuffle"))).Put("a", ((V)(0.85))).Put("x", NewObj(1).Put("veg", Arr(((V)(0.3)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_343, V.Undef, ((V)("noodle")), NewObj(4).Put("g", ((V)("bounce"))).Put("a", ((V)(0.8))).Put("x", NewObj(1).Put("lid", Arr(((V)(0.3)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).Put("fx", Arr(((V)("steam")), ((V)(1100D)))).V);
Call(d_343, V.Undef, ((V)("flossie")), NewObj(2).Put("g", ((V)("float"))).Put("a", ((V)(0.9))).V);
Set(Get(W_341, "G"), "eggroll", (Get(Get(W_341, "G"), "eggroll") is var _t363 && Truthy(_t363) ? _t363 : NewObj(3).Put("r", ((V)(0.9))).Put("dl", ((V)(0D))).Put("f", Fn((V _self353, int _argc354, V p_360, V A_361, V o_362, V _a359, V[] _rest355) => {
if (_self353.IsNullish) _self353 = GlobalV;
Set(o_362, "armL", ((V)((24D + ((7D * ToNum(A_361)) * FdLibm.Sin(ToNum(p_360)))))));
Set(o_362, "armR", ((V)((24D - ((7D * ToNum(A_361)) * FdLibm.Sin(ToNum(p_360)))))));
Set(o_362, "sq", ((V)(((0.02 * ToNum(A_361)) * FdLibm.Sin((2D * ToNum(p_360)))))));
return default;
}, 3, "f", false)).V));
if (!(Truthy(Get(W_341, "__snRoll")))) {
V st0_364 = default;
Set(W_341, "__snRoll", ((V)(1D)));
st0_364 = Get(W_341, "step");
Set(W_341, "step", Fn((V _self365, int _argc366, V key_372, V st_373, V E_374, V w_375, V[] _rest367) => {
V r_380 = default;
double dir_381 = 0;
V mv_382 = default;
V dt_376 = default;
V spd_377 = default;
V spin_378 = default;
if (_self365.IsNullish) _self365 = GlobalV;
dt_376 = (_argc366 > 4 ? _rest367[0] : V.Undef);
spd_377 = (_argc366 > 5 ? _rest367[1] : V.Undef);
spin_378 = (_argc366 > 6 ? _rest367[2] : V.Undef);
V _arguments379 = Arguments(_argc366, key_372, st_373, E_374, w_375, _rest367);
r_380 = Invoke(st0_364, "apply", _self365, _arguments379);
if (!SEqS(key_372, "sunny")) {
return r_380;
}
dir_381 = FdLibm.Sin(((ToNum((spin_378 is var _t383 && Truthy(_t383) ? _t383 : ((V)(0D)))) * System.Math.PI) / 180D));
mv_382 = ((GtN((spd_377 is var _t384 && Truthy(_t384) ? _t384 : ((V)(0D))), 0D) && GtN(w_375, 0.3)) ? V.True : V.False);
Set(st_373, "ra", (Get(st_373, "ra") is var _t385 && Truthy(_t385) ? _t385 : ((V)(0D))));
Set(st_373, "rv", (Get(st_373, "rv") is var _t386 && Truthy(_t386) ? _t386 : ((V)(0D))));
if (Truthy(mv_382)) {
double tv_387 = 0;
tv_387 = (((300D * ToNum(spd_377)) * (Truthy(Get(st_373, "run")) ? 1.6 : 1D)) * ((System.Math.Abs(dir_381) < 0.3) ? ((dir_381 < 0D) ? (-0.3) : 0.3) : dir_381));
OpSet(st_373, "rv", 0, ((V)(((tv_387 - ToNum(Get(st_373, "rv"))) * Min(1D, (ToNum(dt_376) * 6D))))));
OpSet(st_373, "ra", 0, ((V)((ToNum(Get(st_373, "rv")) * ToNum(dt_376)))));
} else {
double tg_388 = 0;
tg_388 = (Round((ToNum(Get(st_373, "ra")) / 360D)) * 360D);
OpSet(st_373, "rv", 0, ((V)(((((tg_388 - ToNum(Get(st_373, "ra"))) * 60D) - (ToNum(Get(st_373, "rv")) * 7D)) * Min(ToNum(dt_376), 0.05)))));
OpSet(st_373, "ra", 0, ((V)((ToNum(Get(st_373, "rv")) * Min(ToNum(dt_376), 0.05)))));
if (((System.Math.Abs((tg_388 - ToNum(Get(st_373, "ra")))) < 0.3) && (System.Math.Abs(ToNum(Get(st_373, "rv"))) < 2D))) {
Set(st_373, "ra", ((V)(0D)));
Set(st_373, "rv", ((V)(0D)));
}
}
Set(E_374, "rl", ((V)((ToNum(Add((Get(E_374, "rl") is var _t389 && Truthy(_t389) ? _t389 : ((V)(0D))), ((V)((((ToNum(Get(st_373, "ra")) % 360D) + 540D) % 360D))))) - 180D))));
return r_380;
return default;
}, 7, "", false));
}
return default;
}, 1, "", true);
if (Truthy(Get(G("window"), "HouseWalk"))) {
Call(walks_9, V.Undef, Get(G("window"), "HouseWalk"));
} else {
Invoke(Set(G("window"), "HouseWalkC", (Get(G("window"), "HouseWalkC") is var _t390 && Truthy(_t390) ? _t390 : Arr())), "push", walks_9);
}
Invoke(Set(G("window"), "HouseIdleC", (Get(G("window"), "HouseIdleC") is var _t537 && Truthy(_t537) ? _t537 : Arr())), "push", Fn((V _self391, int _argc392, V W_398, V _a395, V _a396, V _a397, V[] _rest393) => {
V hand_399 = default;
V o_400 = default;
V sp_401 = default;
V d_402 = default;
if (_self391.IsNullish) _self391 = GlobalV;
{ V _t403 = Get(Get(G("window"), "RiveRig"), "HOUSE");
if (_t403.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t403));
{ V _t404 = Get(_t403, "hand");
hand_399 = _t404; }
{ V _t405 = Get(_t403, "o");
o_400 = _t405; } }
sp_401 = Get(W_398, "sp");
d_402 = Fn((V _arrowThis414, int _argc406, V k_412, V L_413, V _a410, V _a411, V[] _rest407) => {
return Invoke(W_398, "build", k_412, L_413);
}, 2, "", true);
Call(d_402, V.Undef, ((V)("frankie")), Arr(Fn((V _arrowThis422, int _argc415, V t_421, V _a418, V _a419, V _a420, V[] _rest416) => {
Call(sp_401, V.Undef, t_421, NewObj(4).Put("hug", ((V)((-0.7)))).Put("sq", ((V)(0.04))).Put("smile", ((V)(1D))).Put("close", ((V)(0.6))).V, ((V)(1200D)), ((V)(900D)));
Invoke(t_421, "fx", ((V)("mustard")), ((V)("head")));
return default;
}, 1, "", true), Fn((V _arrowThis430, int _argc423, V t_429, V _a426, V _a427, V _a428, V[] _rest424) => {
Invoke(Invoke(t_429, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("slip", ((V)(0.4))).V, NewObj(1).Put("slip", ((V)((-0.4)))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(1).Put("slip", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("clap"))));
Call(d_402, V.Undef, ((V)("corny")), Arr(Fn((V _arrowThis438, int _argc431, V t_437, V _a434, V _a435, V _a436, V[] _rest432) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_437, "to", ((V)(200D)), NewObj(1).Put("cfz", ((V)(1D))).V), "wait", ((V)(300D))), "to", ((V)(120D)), NewObj(1).Put("pop", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("popk")), ((V)("head")), ((V)(3D))), "to", ((V)(380D)), NewObj(2).Put("pop", ((V)(0D))).Put("cfz", ((V)(0D))).V, ((V)("i")));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("giggle"))));
Call(d_402, V.Undef, ((V)("peppi")), Arr(Fn((V _arrowThis446, int _argc439, V t_445, V _a442, V _a443, V _a444, V[] _rest440) => {
return Call(sp_401, V.Undef, t_445, NewObj(3).Put("flop", ((V)(0.8))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), Fn((V _arrowThis454, int _argc447, V t_453, V _a450, V _a451, V _a452, V[] _rest448) => {
Invoke(Invoke(Invoke(t_453, "to", ((V)(300D)), NewObj(2).Put("pull", ((V)(1D))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("pull", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i"))), "fx", ((V)("cheese")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "", true), ((V)("hum"))));
Call(d_402, V.Undef, ((V)("nori")), Arr(Fn((V _arrowThis462, int _argc455, V t_461, V _a458, V _a459, V _a460, V[] _rest456) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_461, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.15)))).Put("close", ((V)(0.6))).V), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V), "to", ((V)(140D)), NewObj(1).Put("ume", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("ume", ((V)(0D))).V, ((V)("i")));
return default;
}, 1, "", true), ((V)("bow")), ((V)("nod"))));
Call(d_402, V.Undef, ((V)("sunny")), Arr(Fn((V _arrowThis470, int _argc463, V t_469, V _a466, V _a467, V _a468, V[] _rest464) => {
return Call(sp_401, V.Undef, t_469, NewObj(4).Put("cap", ((V)(0.7))).Put("wob", ((V)(0.8))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(700D)));
}, 1, "", true), Fn((V _arrowThis478, int _argc471, V t_477, V _a474, V _a475, V _a476, V[] _rest472) => {
Invoke(Invoke(t_477, "osc", ((V)(1400D)), ((V)(3D)), NewObj(2).Put("rl", ((V)(14D))).Put("x", ((V)(3D))).V, NewObj(2).Put("rl", ((V)((-14D)))).Put("x", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("curtsy"))));
Call(d_402, V.Undef, ((V)("toco")), Arr(Fn((V _arrowThis486, int _argc479, V t_485, V _a482, V _a483, V _a484, V[] _rest480) => {
{
double i_487 = 0;
i_487 = 0D;
while (true) {
if (!((i_487 < 2D))) break;
Invoke(Invoke(t_485, "to", ((V)(110D)), NewObj(1).Put("snap", ((V)((-0.5)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0.4))).V, ((V)("io")));
i_487++;
}
}
Invoke(Invoke(t_485, "to", ((V)(150D)), NewObj(1).Put("snap", ((V)(0D))).V), "fx", ((V)("lettuce")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "", true), ((V)("clap")), ((V)("wiggle"))));
Call(d_402, V.Undef, ((V)("churro")), Arr(Fn((V _arrowThis496, int _argc489, V t_495, V _a492, V _a493, V _a494, V[] _rest490) => {
Invoke(Invoke(Invoke(Invoke(t_495, "to", ((V)(400D)), NewObj(1).Put("cork", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("cork", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("sugar")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("bow"))));
Call(d_402, V.Undef, ((V)("khinki")), Arr(Fn((V _arrowThis504, int _argc497, V t_503, V _a500, V _a501, V _a502, V[] _rest498) => {
Invoke(Invoke(t_503, "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("knot", ((V)(0.6))).V, NewObj(1).Put("knot", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("knot", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("belly")), ((V)("nod"))));
Call(d_402, V.Undef, ((V)("maki")), Arr(Fn((V _arrowThis512, int _argc505, V t_511, V _a508, V _a509, V _a510, V[] _rest506) => {
return Call(sp_401, V.Undef, t_511, NewObj(3).Put("veg", ((V)(0.9))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.5))).V, ((V)(900D)), ((V)(600D)));
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("bow"))));
Call(d_402, V.Undef, ((V)("noodle")), Arr(Fn((V _arrowThis520, int _argc513, V t_519, V _a516, V _a517, V _a518, V[] _rest514) => {
Invoke(Invoke(Invoke(Invoke(t_519, "to", ((V)(300D)), NewObj(3).Put("slurp", ((V)(1D))).Put("puff", ((V)((-0.3)))).Put("mw", ((V)(0.5))).V), "wait", ((V)(300D))), "to", ((V)(250D)), NewObj(5).Put("slurp", ((V)(0D))).Put("puff", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("head")));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("hum"))));
Call(d_402, V.Undef, ((V)("flossie")), Arr(Fn((V _arrowThis528, int _argc521, V t_527, V _a524, V _a525, V _a526, V[] _rest522) => {
return Call(sp_401, V.Undef, t_527, NewObj(3).Put("fluff", ((V)(1D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1000D)), ((V)(700D)));
}, 1, "", true), Fn((V _arrowThis536, int _argc529, V t_535, V _a532, V _a533, V _a534, V[] _rest530) => {
Invoke(Invoke(t_535, "to", ((V)(1400D)), NewObj(1).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("l")));
return default;
}, 1, "", true), ((V)("curtsy"))));
return default;
}, 1, "", false));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
