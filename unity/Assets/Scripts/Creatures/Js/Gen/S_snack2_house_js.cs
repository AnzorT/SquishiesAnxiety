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
Invoke(Set(G("window"), "HouseCreatures", (Get(G("window"), "HouseCreatures") is var _t301 && Truthy(_t301) ? _t301 : Arr())), "push", Fn((V _self10, int _argc11, V H_17, V _a14, V _a15, V _a16, V[] _rest12) => {
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
sp_26 = Fn((V _self10, int _argc49, V t_55, V v_56, V d_57, V hold_58, V[] _rest50) => {
V b_59 = default;
b_59 = NewObj(0).V;
Invoke(Object_keys(v_56), "forEach", Fn((V _self10, int _argc60, V k_66, V _a63, V _a64, V _a65, V[] _rest61) => {
return SetK(b_59, k_66, (!GetK(Get(t_55, "B"), k_66).IsNullish ? GetK(Get(t_55, "B"), k_66) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_55, "to", ((V)((ToNum((d_57 is var _t69 && Truthy(_t69) ? _t69 : ((V)(700D)))) * 0.4))), v_56, ((V)("o"))), "wait", (hold_58 is var _t68 && Truthy(_t68) ? _t68 : ((V)(300D)))), "to", ((V)((ToNum((d_57 is var _t67 && Truthy(_t67) ? _t67 : ((V)(700D)))) * 0.6))), b_59, ((V)("io")));
return t_55;
return default;
}, 4, "", true);
bk_27 = Fn((V _self10, int _argc70, V t_76, V d_77, V _a74, V _a75, V[] _rest71) => {
return Invoke(t_76, "back", (d_77 is var _t78 && Truthy(_t78) ? _t78 : ((V)(420D))));
}, 2, "", true);
hop_28 = NewObj(2).Put("dn", ((V)("hop"))).Put("up", ((V)("hop"))).V;
RL_29 = NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V;
mk_30 = Fn((V _self10, int _argc79, V key_85, V @base_86, V P_87, V _a84, V[] _rest80) => {
return Call(build_18, V.Undef, key_85, Call(o_25, V.Undef, @base_86, P_87, NewObj(2).Put("pose", Call(o_25, V.Undef, (Get(@base_86, "pose") is var _t88 && Truthy(_t88) ? _t88 : NewObj(0).V), (Get(P_87, "pose") is var _t89 && Truthy(_t89) ? _t89 : NewObj(0).V))).Put("lpose", Call(o_25, V.Undef, (Get(@base_86, "lpose") is var _t90 && Truthy(_t90) ? _t90 : NewObj(0).V), RL_29, (Get(P_87, "lpose") is var _t91 && Truthy(_t91) ? _t91 : NewObj(0).V))).V));
}, 3, "", true);
SIG_31 = NewObj(11).Put("frankie", Fn((V _self10, int _argc92, V t_98, V _a95, V _a96, V _a97, V[] _rest93) => {
Call(sp_26, V.Undef, t_98, NewObj(4).Put("hug", ((V)((-0.7)))).Put("sq", Add(Get(Get(t_98, "B"), "sq"), ((V)(0.04)))).Put("smile", ((V)(1D))).Put("close", ((V)(0.6))).V, ((V)(1200D)), ((V)(900D)));
Invoke(t_98, "fx", ((V)("mustard")), ((V)("head")));
return t_98;
return default;
}, 1, "frankie", true)).Put("corny", Fn((V _self10, int _argc99, V t_105, V _a102, V _a103, V _a104, V[] _rest100) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_105, "to", ((V)(200D)), NewObj(1).Put("cfz", ((V)(1D))).V), "wait", ((V)(300D))), "to", ((V)(120D)), NewObj(1).Put("pop", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("popk")), ((V)("head")), ((V)(3D))), "to", ((V)(380D)), NewObj(2).Put("pop", ((V)(0D))).Put("cfz", ((V)(0D))).V, ((V)("i")));
return Call(bk_27, V.Undef, t_105);
return default;
}, 1, "corny", true)).Put("peppi", Fn((V _self10, int _argc106, V t_112, V _a109, V _a110, V _a111, V[] _rest107) => {
return Call(sp_26, V.Undef, t_112, NewObj(3).Put("flop", ((V)(0.8))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "peppi", true)).Put("nori", Fn((V _self10, int _argc113, V t_119, V _a116, V _a117, V _a118, V[] _rest114) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_119, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((ToNum((Get(Get(t_119, "B"), "pitch") is var _t121 && Truthy(_t121) ? _t121 : ((V)(0D)))) - 0.15)))).Put("close", ((V)(0.6))).V), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(2).Put("pitch", (Get(Get(t_119, "B"), "pitch") is var _t120 && Truthy(_t120) ? _t120 : ((V)(0D)))).Put("close", ((V)(0D))).V), "to", ((V)(140D)), NewObj(1).Put("ume", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("ume", ((V)(0D))).V, ((V)("i")));
return Call(bk_27, V.Undef, t_119);
return default;
}, 1, "nori", true)).Put("sunny", Fn((V _self10, int _argc122, V t_128, V _a125, V _a126, V _a127, V[] _rest123) => {
return Call(sp_26, V.Undef, t_128, NewObj(4).Put("cap", ((V)(0.7))).Put("wob", ((V)(0.8))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(700D)));
}, 1, "sunny", true)).Put("toco", Fn((V _self10, int _argc129, V t_135, V _a132, V _a133, V _a134, V[] _rest130) => {
{
V i_136 = default;
i_136 = ((V)(0D));
while (true) {
if (!(LtN(i_136, 2D))) break;
Invoke(Invoke(t_135, "to", ((V)(110D)), NewObj(1).Put("snap", ((V)((-0.5)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0.4))).V, ((V)("io")));
PostInc(ref i_136, 1D);
}
}
Invoke(Invoke(t_135, "to", ((V)(150D)), NewObj(1).Put("snap", ((V)(0D))).V), "fx", ((V)("lettuce")), ((V)("head")), ((V)(2D)));
return Call(bk_27, V.Undef, t_135);
return default;
}, 1, "toco", true)).Put("churro", Fn((V _self10, int _argc138, V t_144, V _a141, V _a142, V _a143, V[] _rest139) => {
Invoke(Invoke(Invoke(Invoke(t_144, "to", ((V)(400D)), NewObj(1).Put("cork", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("cork", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("sugar")), ((V)("head")), ((V)(3D)));
return Call(bk_27, V.Undef, t_144);
return default;
}, 1, "churro", true)).Put("khinki", Fn((V _self10, int _argc145, V t_151, V _a148, V _a149, V _a150, V[] _rest146) => {
Invoke(Invoke(t_151, "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("knot", ((V)(0.6))).V, NewObj(1).Put("knot", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("knot", ((V)(0D))).V);
return Call(bk_27, V.Undef, t_151);
return default;
}, 1, "khinki", true)).Put("maki", Fn((V _self10, int _argc152, V t_158, V _a155, V _a156, V _a157, V[] _rest153) => {
return Call(sp_26, V.Undef, t_158, NewObj(3).Put("veg", ((V)(0.9))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.5))).V, ((V)(900D)), ((V)(600D)));
}, 1, "maki", true)).Put("noodle", Fn((V _self10, int _argc159, V t_165, V _a162, V _a163, V _a164, V[] _rest160) => {
Invoke(Invoke(Invoke(Invoke(t_165, "to", ((V)(300D)), NewObj(3).Put("slurp", ((V)(1D))).Put("puff", ((V)((-0.3)))).Put("mw", ((V)(0.5))).V), "wait", ((V)(300D))), "to", ((V)(250D)), NewObj(5).Put("slurp", ((V)(0D))).Put("puff", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("head")));
return Call(bk_27, V.Undef, t_165);
return default;
}, 1, "noodle", true)).Put("flossie", Fn((V _self10, int _argc166, V t_172, V _a169, V _a170, V _a171, V[] _rest167) => {
return Call(sp_26, V.Undef, t_172, NewObj(3).Put("fluff", ((V)(1D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1000D)), ((V)(700D)));
}, 1, "flossie", true)).V;
SLEEPY_32 = NewObj(11).Put("frankie", Fn((V _self10, int _argc173, V t_179, V _a176, V _a177, V _a178, V[] _rest174) => {
return Call(sp_26, V.Undef, t_179, NewObj(2).Put("hug", ((V)((-0.5)))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "frankie", true)).Put("corny", Fn((V _self10, int _argc180, V t_186, V _a183, V _a184, V _a185, V[] _rest181) => {
return Call(sp_26, V.Undef, t_186, NewObj(2).Put("cfz", ((V)(0.5))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "corny", true)).Put("peppi", Fn((V _self10, int _argc187, V t_193, V _a190, V _a191, V _a192, V[] _rest188) => {
return Call(sp_26, V.Undef, t_193, NewObj(2).Put("flop", ((V)(1D))).Put("close", ((V)(1D))).V, ((V)(2000D)), ((V)(1800D)));
}, 1, "peppi", true)).Put("nori", Fn((V _self10, int _argc194, V t_200, V _a197, V _a198, V _a199, V[] _rest195) => {
return Call(sp_26, V.Undef, t_200, NewObj(2).Put("nwr", ((V)(0.5))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "nori", true)).Put("sunny", Fn((V _self10, int _argc201, V t_207, V _a204, V _a205, V _a206, V[] _rest202) => {
return Call(sp_26, V.Undef, t_207, NewObj(2).Put("cap", ((V)(0.3))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "sunny", true)).Put("toco", Fn((V _self10, int _argc208, V t_214, V _a211, V _a212, V _a213, V[] _rest209) => {
return Call(sp_26, V.Undef, t_214, NewObj(2).Put("snap", ((V)(0.6))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "toco", true)).Put("churro", Fn((V _self10, int _argc215, V t_221, V _a218, V _a219, V _a220, V[] _rest216) => {
return Call(sp_26, V.Undef, t_221, NewObj(2).Put("cork", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "churro", true)).Put("khinki", Fn((V _self10, int _argc222, V t_228, V _a225, V _a226, V _a227, V[] _rest223) => {
return Call(sp_26, V.Undef, t_228, NewObj(2).Put("kt", ((V)(0.6))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "khinki", true)).Put("maki", Fn((V _self10, int _argc229, V t_235, V _a232, V _a233, V _a234, V[] _rest230) => {
return Call(sp_26, V.Undef, t_235, NewObj(2).Put("veg", ((V)(0.4))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "maki", true)).Put("noodle", Fn((V _self10, int _argc236, V t_242, V _a239, V _a240, V _a241, V[] _rest237) => {
Invoke(Invoke(Invoke(t_242, "fx", ((V)("steam")), ((V)("head"))), "wait", ((V)(800D))), "fx", ((V)("steam")), ((V)("head")));
return t_242;
return default;
}, 1, "noodle", true)).Put("flossie", Fn((V _self10, int _argc243, V t_249, V _a246, V _a247, V _a248, V[] _rest244) => {
return Call(sp_26, V.Undef, t_249, NewObj(2).Put("fluff", ((V)(0.6))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "flossie", true)).V;
Call(mk_30, V.Undef, ((V)("frankie")), hop_28, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_31, "frankie"), Fn((V _self10, int _argc250, V t_256, V _a253, V _a254, V _a255, V[] _rest251) => {
Invoke(Invoke(t_256, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("slip", ((V)(0.4))).V, NewObj(1).Put("slip", ((V)((-0.4)))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(1).Put("slip", ((V)(0D))).V);
Call(bk_27, V.Undef, t_256);
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
Call(mk_30, V.Undef, ((V)("flossie")), NewObj(2).Put("dn", ((V)("float"))).Put("up", ((V)("float"))).V, NewObj(2).Put("f", Arr(((V)("look")), Get(SIG_31, "flossie"), Fn((V _self10, int _argc257, V t_263, V _a260, V _a261, V _a262, V[] _rest258) => {
Invoke(Invoke(t_263, "to", ((V)(1400D)), NewObj(1).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("l")));
Call(bk_27, V.Undef, t_263);
return default;
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_32, "flossie"), ((V)("stretch")))).V);
DR_33 = NewObj(11).Put("frankie", ((V)("ketchup"))).Put("corny", ((V)("star"))).Put("peppi", ((V)("cheese"))).Put("nori", ((V)("fish"))).Put("sunny", ((V)("sun"))).Put("toco", ((V)("cheese"))).Put("churro", ((V)("cookie"))).Put("khinki", ((V)("cup"))).Put("maki", ((V)("fish"))).Put("noodle", ((V)("cup"))).Put("flossie", ((V)("cloud"))).V;
WK_34 = NewObj(11).Put("frankie", NewObj(1).Put("hug", ((V)(0.6))).V).Put("corny", NewObj(1).Put("pop", ((V)(0.8))).V).Put("peppi", NewObj(1).Put("flop", ((V)((-0.6)))).V).Put("nori", NewObj(1).Put("ume", ((V)(0.8))).V).Put("sunny", NewObj(1).Put("cap", ((V)(0.6))).V).Put("toco", NewObj(1).Put("snap", ((V)(0.8))).V).Put("churro", NewObj(1).Put("cork", ((V)(0.8))).V).Put("khinki", NewObj(1).Put("knot", ((V)(0.6))).V).Put("maki", NewObj(1).Put("veg", ((V)(0.8))).V).Put("noodle", NewObj(1).Put("lid", ((V)(0.8))).V).Put("flossie", NewObj(1).Put("fluff", ((V)(1D))).V).V;
Invoke(K_8, "forEach", Fn((V _self10, int _argc264, V k_270, V _a267, V _a268, V _a269, V[] _rest265) => {
return Call(bedBuild_19, V.Undef, k_270, NewObj(3).Put("dr", GetK(DR_33, k_270)).Put("wk", GetK(WK_34, k_270)).Put("s", GetK(SLEEPY_32, k_270)).V);
}, 1, "", true));
SW_35 = NewObj(11).Put("frankie", ((V)("bob"))).Put("corny", ((V)("bob"))).Put("peppi", ((V)("float"))).Put("nori", ((V)("bob"))).Put("sunny", ((V)("bob"))).Put("toco", ((V)("bob"))).Put("churro", ((V)("float"))).Put("khinki", ((V)("bob"))).Put("maki", ((V)("bob"))).Put("noodle", ((V)("bob"))).Put("flossie", ((V)("float"))).V;
Invoke(K_8, "forEach", Fn((V _self10, int _argc271, V k_277, V _a274, V _a275, V _a276, V[] _rest272) => {
return Call(waterBuild_20, V.Undef, k_277, NewObj(3).Put("sw", GetK(SW_35, k_277)).Put("k", NewObj(3).Put("a", GetK(WK_34, k_277)).Put("b", NewObj(0).V).Put("f", GetK(WK_34, k_277)).V).Put("s", GetK(SIG_31, k_277)).V);
}, 1, "", true));
SN_36 = NewObj(11).Put("frankie", ((V)("ketchup"))).Put("corny", ((V)("candy"))).Put("peppi", ((V)("cheese"))).Put("nori", ((V)("fish"))).Put("sunny", ((V)("cookie"))).Put("toco", ((V)("cheese"))).Put("churro", ((V)("cookie"))).Put("khinki", ((V)("cup"))).Put("maki", ((V)("fish"))).Put("noodle", ((V)("cup"))).Put("flossie", ((V)("candy"))).V;
CHEER_37 = NewObj(11).Put("frankie", NewObj(2).Put("cheer", NewObj(1).Put("hug", ((V)(0.6))).V).Put("cheerFx", Arr(((V)("mustard")), ((V)("head")))).V).Put("corny", NewObj(2).Put("cheer", NewObj(1).Put("pop", ((V)(1D))).V).Put("cheerFx", Arr(((V)("popk")), ((V)("head")))).V).Put("peppi", NewObj(1).Put("cheer", NewObj(1).Put("pull", ((V)(0.6))).V).V).Put("nori", NewObj(1).Put("cheer", NewObj(1).Put("ume", ((V)(1D))).V).V).Put("sunny", NewObj(1).Put("cheer", NewObj(1).Put("cap", ((V)(0.8))).V).V).Put("toco", NewObj(2).Put("cheer", NewObj(1).Put("snap", ((V)(0.8))).V).Put("cheerFx", Arr(((V)("lettuce")), ((V)("head")))).V).Put("churro", NewObj(2).Put("cheer", NewObj(1).Put("cork", ((V)(0.8))).V).Put("cheerFx", Arr(((V)("sugar")), ((V)("head")))).V).Put("khinki", NewObj(1).Put("cheer", NewObj(1).Put("knot", ((V)(0.6))).V).V).Put("maki", NewObj(1).Put("cheer", NewObj(1).Put("veg", ((V)(1D))).V).V).Put("noodle", NewObj(2).Put("cheer", NewObj(1).Put("lid", ((V)(0.8))).V).Put("cheerFx", Arr(((V)("steam")), ((V)("head")))).V).Put("flossie", NewObj(2).Put("cheer", NewObj(1).Put("fluff", ((V)(1D))).V).Put("cheerFx", Arr(((V)("floss")), ((V)("head")))).V).V;
Invoke(K_8, "forEach", Fn((V _self10, int _argc278, V k_284, V _a281, V _a282, V _a283, V[] _rest279) => {
return Call(playBuild_21, V.Undef, k_284, Call(o_25, V.Undef, GetK(CHEER_37, k_284), NewObj(3).Put("sn", GetK(SN_36, k_284)).Put("p", GetK(SIG_31, k_284)).Put("sp", NewObj(6).Put("armL", ((V)(42D))).Put("armR", ((V)(42D))).Put("hLy", ((V)((-7D)))).Put("hRy", ((V)((-7D)))).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-1D)))).V).V));
}, 1, "", true));
FC_38 = NewObj(11).Put("frankie", ((V)("boot"))).Put("corny", ((V)("star"))).Put("peppi", ((V)("cheese"))).Put("nori", ((V)("fish"))).Put("sunny", ((V)("shell"))).Put("toco", ((V)("leaf"))).Put("churro", ((V)("cookie"))).Put("khinki", ((V)("cup"))).Put("maki", ((V)("fish"))).Put("noodle", ((V)("cup"))).Put("flossie", ((V)("cloud"))).V;
TBC_39 = Arr(((V)("#5fb8e8")), ((V)("#7cc35a")), ((V)("#ff8fa8")), ((V)("#ffcc3a")), ((V)("#b98ae8")), ((V)("#ff8a4a")));
Invoke(K_8, "forEach", Fn((V _self10, int _argc285, V k_291, V i_292, V _a289, V _a290, V[] _rest286) => {
return Call(bBuild_22, V.Undef, k_291, Call(o_25, V.Undef, GetK(CHEER_37, k_291), NewObj(4).Put("fc", GetK(FC_38, k_291)).Put("tk", Call(o_25, V.Undef, GetK(WK_34, k_291))).Put("tb", GetIdx(TBC_39, (ToNum(i_292) % ToNum(Get(TBC_39, "length"))))).Put("sn", GetK(SN_36, k_291)).V));
}, 2, "", true));
if (Truthy(Get(H_17, "cBuild"))) {
Invoke(K_8, "forEach", Fn((V _self10, int _argc293, V k_299, V _a296, V _a297, V _a298, V[] _rest294) => {
return Invoke(H_17, "cBuild", k_299, NewObj(4).Put("ks", ((V)(((((SEqS(k_299, "maki") || SEqS(k_299, "corny")) || SEqS(k_299, "noodle")) || SEqS(k_299, "sunny")) ? "body" : "foot")))).Put("pc", ((V)("#ffb84a"))).Put("hc", ((V)("#ffb84a"))).Put("mc", ((V)((SEqS(k_299, "flossie") ? "#ff8fc8" : "#3b3b4a")))).V);
}, 1, "", true));
}
Set(G("window"), "HouseWalkRUN", Object_assign((Get(G("window"), "HouseWalkRUN") is var _t300 && Truthy(_t300) ? _t300 : NewObj(0).V), NewObj(4).Put("corny", NewObj(1).Put("pop", ((V)(0.4))).V).Put("toco", NewObj(1).Put("snap", ((V)(0.3))).V).Put("flossie", NewObj(1).Put("fluff", ((V)(0.4))).V).Put("khinki", NewObj(1).Put("knot", ((V)(0.4))).V).V));
return default;
}, 1, "", false));
walks_9 = Fn((V _self1, int _argc302, V W_308, V _a305, V _a306, V _a307, V[] _rest303) => {
V d_309 = default;
d_309 = Fn((V _self1, int _argc310, V k_316, V P_317, V _a314, V _a315, V[] _rest311) => {
return Invoke(W_308, "def", k_316, P_317);
}, 2, "", true);
Call(d_309, V.Undef, ((V)("frankie")), NewObj(3).Put("g", ((V)("shuffle"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("slip", Arr(((V)(0.25)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_309, V.Undef, ((V)("corny")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("pop", Arr(((V)(0.35)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_309, V.Undef, ((V)("peppi")), NewObj(3).Put("g", ((V)("waddle"))).Put("a", ((V)(0.8))).Put("x", NewObj(1).Put("flop", Arr(((V)(0.4)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_309, V.Undef, ((V)("nori")), NewObj(2).Put("g", ((V)("shuffle"))).Put("a", ((V)(0.8))).V);
Call(d_309, V.Undef, ((V)("sunny")), NewObj(2).Put("g", ((V)("eggroll"))).Put("a", ((V)(0.8))).V);
Call(d_309, V.Undef, ((V)("toco")), NewObj(3).Put("g", ((V)("bounce"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("snap", Arr(((V)(0.35)), ((V)(2D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_309, V.Undef, ((V)("churro")), NewObj(3).Put("g", ((V)("prance"))).Put("a", ((V)(0.9))).Put("x", NewObj(1).Put("cork", Arr(((V)(0.3)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_309, V.Undef, ((V)("khinki")), NewObj(3).Put("g", ((V)("waddle"))).Put("a", ((V)(0.85))).Put("x", NewObj(1).Put("knot", Arr(((V)(0.4)), ((V)(1D)), ((V)(0D)), ((V)(0D)))).V).V);
Call(d_309, V.Undef, ((V)("maki")), NewObj(3).Put("g", ((V)("shuffle"))).Put("a", ((V)(0.85))).Put("x", NewObj(1).Put("veg", Arr(((V)(0.3)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).V);
Call(d_309, V.Undef, ((V)("noodle")), NewObj(4).Put("g", ((V)("bounce"))).Put("a", ((V)(0.8))).Put("x", NewObj(1).Put("lid", Arr(((V)(0.3)), ((V)(2D)), ((V)(0D)), ((V)(1D)))).V).Put("fx", Arr(((V)("steam")), ((V)(1100D)))).V);
Call(d_309, V.Undef, ((V)("flossie")), NewObj(2).Put("g", ((V)("float"))).Put("a", ((V)(0.9))).V);
Set(Get(W_308, "G"), "eggroll", (Get(Get(W_308, "G"), "eggroll") is var _t328 && Truthy(_t328) ? _t328 : NewObj(3).Put("r", ((V)(0.9))).Put("dl", ((V)(0D))).Put("f", Fn((V _self318, int _argc319, V p_325, V A_326, V o_327, V _a324, V[] _rest320) => {
if (_self318.IsNullish) _self318 = GlobalV;
Set(o_327, "armL", ((V)((24D + ((7D * ToNum(A_326)) * FdLibm.Sin(ToNum(p_325)))))));
Set(o_327, "armR", ((V)((24D - ((7D * ToNum(A_326)) * FdLibm.Sin(ToNum(p_325)))))));
Set(o_327, "sq", ((V)(((0.02 * ToNum(A_326)) * FdLibm.Sin((2D * ToNum(p_325)))))));
return default;
}, 3, "f", false)).V));
if (!(Truthy(Get(W_308, "__snRoll")))) {
V st0_329 = default;
Set(W_308, "__snRoll", ((V)(1D)));
st0_329 = Get(W_308, "step");
Set(W_308, "step", Fn((V _self330, int _argc331, V key_337, V st_338, V E_339, V w_340, V[] _rest332) => {
V r_345 = default;
V dir_346 = default;
V mv_347 = default;
V dt_341 = default;
V spd_342 = default;
V spin_343 = default;
if (_self330.IsNullish) _self330 = GlobalV;
dt_341 = (_argc331 > 4 ? _rest332[0] : V.Undef);
spd_342 = (_argc331 > 5 ? _rest332[1] : V.Undef);
spin_343 = (_argc331 > 6 ? _rest332[2] : V.Undef);
V _arguments344 = Arguments(_argc331, key_337, st_338, E_339, w_340, _rest332);
r_345 = Invoke(st0_329, "apply", _self330, _arguments344);
if (!SEqS(key_337, "sunny")) {
return r_345;
}
dir_346 = ((V)(FdLibm.Sin(((ToNum((spin_343 is var _t348 && Truthy(_t348) ? _t348 : ((V)(0D)))) * System.Math.PI) / 180D))));
mv_347 = ((GtN((spd_342 is var _t349 && Truthy(_t349) ? _t349 : ((V)(0D))), 0D) && GtN(w_340, 0.3)) ? V.True : V.False);
Set(st_338, "ra", (Get(st_338, "ra") is var _t350 && Truthy(_t350) ? _t350 : ((V)(0D))));
Set(st_338, "rv", (Get(st_338, "rv") is var _t351 && Truthy(_t351) ? _t351 : ((V)(0D))));
if (Truthy(mv_347)) {
V tv_352 = default;
tv_352 = ((V)((((300D * ToNum(spd_342)) * (Truthy(Get(st_338, "run")) ? 1.6 : 1D)) * ToNum(((System.Math.Abs(ToNum(dir_346)) < 0.3) ? ((V)((LtN(dir_346, 0D) ? (-0.3) : 0.3))) : dir_346)))));
OpSet(st_338, "rv", 0, ((V)(((ToNum(tv_352) - ToNum(Get(st_338, "rv"))) * Min(1D, (ToNum(dt_341) * 6D))))));
OpSet(st_338, "ra", 0, ((V)((ToNum(Get(st_338, "rv")) * ToNum(dt_341)))));
} else {
V tg_353 = default;
tg_353 = ((V)((Round((ToNum(Get(st_338, "ra")) / 360D)) * 360D)));
OpSet(st_338, "rv", 0, ((V)(((((ToNum(tg_353) - ToNum(Get(st_338, "ra"))) * 60D) - (ToNum(Get(st_338, "rv")) * 7D)) * Min(ToNum(dt_341), 0.05)))));
OpSet(st_338, "ra", 0, ((V)((ToNum(Get(st_338, "rv")) * Min(ToNum(dt_341), 0.05)))));
if (((System.Math.Abs((ToNum(tg_353) - ToNum(Get(st_338, "ra")))) < 0.3) && (System.Math.Abs(ToNum(Get(st_338, "rv"))) < 2D))) {
Set(st_338, "ra", ((V)(0D)));
Set(st_338, "rv", ((V)(0D)));
}
}
Set(E_339, "rl", ((V)((ToNum(Add((Get(E_339, "rl") is var _t354 && Truthy(_t354) ? _t354 : ((V)(0D))), ((V)((((ToNum(Get(st_338, "ra")) % 360D) + 540D) % 360D))))) - 180D))));
return r_345;
return default;
}, 7, "", false));
}
return default;
}, 1, "", true);
if (Truthy(Get(G("window"), "HouseWalk"))) {
Call(walks_9, V.Undef, Get(G("window"), "HouseWalk"));
} else {
Invoke(Set(G("window"), "HouseWalkC", (Get(G("window"), "HouseWalkC") is var _t355 && Truthy(_t355) ? _t355 : Arr())), "push", walks_9);
}
Invoke(Set(G("window"), "HouseIdleC", (Get(G("window"), "HouseIdleC") is var _t486 && Truthy(_t486) ? _t486 : Arr())), "push", Fn((V _self356, int _argc357, V W_363, V _a360, V _a361, V _a362, V[] _rest358) => {
V hand_364 = default;
V o_365 = default;
V sp_366 = default;
V d_367 = default;
if (_self356.IsNullish) _self356 = GlobalV;
{ V _t368 = Get(Get(G("window"), "RiveRig"), "HOUSE");
if (_t368.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t368));
{ V _t369 = Get(_t368, "hand");
hand_364 = _t369; }
{ V _t370 = Get(_t368, "o");
o_365 = _t370; } }
sp_366 = Get(W_363, "sp");
d_367 = Fn((V _self356, int _argc371, V k_377, V L_378, V _a375, V _a376, V[] _rest372) => {
return Invoke(W_363, "build", k_377, L_378);
}, 2, "", true);
Call(d_367, V.Undef, ((V)("frankie")), Arr(Fn((V _self356, int _argc379, V t_385, V _a382, V _a383, V _a384, V[] _rest380) => {
Call(sp_366, V.Undef, t_385, NewObj(4).Put("hug", ((V)((-0.7)))).Put("sq", ((V)(0.04))).Put("smile", ((V)(1D))).Put("close", ((V)(0.6))).V, ((V)(1200D)), ((V)(900D)));
Invoke(t_385, "fx", ((V)("mustard")), ((V)("head")));
return default;
}, 1, "", true), Fn((V _self356, int _argc386, V t_392, V _a389, V _a390, V _a391, V[] _rest387) => {
Invoke(Invoke(t_392, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("slip", ((V)(0.4))).V, NewObj(1).Put("slip", ((V)((-0.4)))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(1).Put("slip", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("clap"))));
Call(d_367, V.Undef, ((V)("corny")), Arr(Fn((V _self356, int _argc393, V t_399, V _a396, V _a397, V _a398, V[] _rest394) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_399, "to", ((V)(200D)), NewObj(1).Put("cfz", ((V)(1D))).V), "wait", ((V)(300D))), "to", ((V)(120D)), NewObj(1).Put("pop", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("popk")), ((V)("head")), ((V)(3D))), "to", ((V)(380D)), NewObj(2).Put("pop", ((V)(0D))).Put("cfz", ((V)(0D))).V, ((V)("i")));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("giggle"))));
Call(d_367, V.Undef, ((V)("peppi")), Arr(Fn((V _self356, int _argc400, V t_406, V _a403, V _a404, V _a405, V[] _rest401) => {
return Call(sp_366, V.Undef, t_406, NewObj(3).Put("flop", ((V)(0.8))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), Fn((V _self356, int _argc407, V t_413, V _a410, V _a411, V _a412, V[] _rest408) => {
Invoke(Invoke(Invoke(t_413, "to", ((V)(300D)), NewObj(2).Put("pull", ((V)(1D))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("pull", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i"))), "fx", ((V)("cheese")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "", true), ((V)("hum"))));
Call(d_367, V.Undef, ((V)("nori")), Arr(Fn((V _self356, int _argc414, V t_420, V _a417, V _a418, V _a419, V[] _rest415) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_420, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.15)))).Put("close", ((V)(0.6))).V), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V), "to", ((V)(140D)), NewObj(1).Put("ume", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("ume", ((V)(0D))).V, ((V)("i")));
return default;
}, 1, "", true), ((V)("bow")), ((V)("nod"))));
Call(d_367, V.Undef, ((V)("sunny")), Arr(Fn((V _self356, int _argc421, V t_427, V _a424, V _a425, V _a426, V[] _rest422) => {
return Call(sp_366, V.Undef, t_427, NewObj(4).Put("cap", ((V)(0.7))).Put("wob", ((V)(0.8))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(700D)));
}, 1, "", true), Fn((V _self356, int _argc428, V t_434, V _a431, V _a432, V _a433, V[] _rest429) => {
Invoke(Invoke(t_434, "osc", ((V)(1400D)), ((V)(3D)), NewObj(2).Put("rl", ((V)(14D))).Put("x", ((V)(3D))).V, NewObj(2).Put("rl", ((V)((-14D)))).Put("x", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("curtsy"))));
Call(d_367, V.Undef, ((V)("toco")), Arr(Fn((V _self356, int _argc435, V t_441, V _a438, V _a439, V _a440, V[] _rest436) => {
{
V i_442 = default;
i_442 = ((V)(0D));
while (true) {
if (!(LtN(i_442, 2D))) break;
Invoke(Invoke(t_441, "to", ((V)(110D)), NewObj(1).Put("snap", ((V)((-0.5)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0.4))).V, ((V)("io")));
PostInc(ref i_442, 1D);
}
}
Invoke(Invoke(t_441, "to", ((V)(150D)), NewObj(1).Put("snap", ((V)(0D))).V), "fx", ((V)("lettuce")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "", true), ((V)("clap")), ((V)("wiggle"))));
Call(d_367, V.Undef, ((V)("churro")), Arr(Fn((V _self356, int _argc444, V t_450, V _a447, V _a448, V _a449, V[] _rest445) => {
Invoke(Invoke(Invoke(Invoke(t_450, "to", ((V)(400D)), NewObj(1).Put("cork", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("cork", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("sugar")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("bow"))));
Call(d_367, V.Undef, ((V)("khinki")), Arr(Fn((V _self356, int _argc451, V t_457, V _a454, V _a455, V _a456, V[] _rest452) => {
Invoke(Invoke(t_457, "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("knot", ((V)(0.6))).V, NewObj(1).Put("knot", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("knot", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("belly")), ((V)("nod"))));
Call(d_367, V.Undef, ((V)("maki")), Arr(Fn((V _self356, int _argc458, V t_464, V _a461, V _a462, V _a463, V[] _rest459) => {
return Call(sp_366, V.Undef, t_464, NewObj(3).Put("veg", ((V)(0.9))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.5))).V, ((V)(900D)), ((V)(600D)));
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("bow"))));
Call(d_367, V.Undef, ((V)("noodle")), Arr(Fn((V _self356, int _argc465, V t_471, V _a468, V _a469, V _a470, V[] _rest466) => {
Invoke(Invoke(Invoke(Invoke(t_471, "to", ((V)(300D)), NewObj(3).Put("slurp", ((V)(1D))).Put("puff", ((V)((-0.3)))).Put("mw", ((V)(0.5))).V), "wait", ((V)(300D))), "to", ((V)(250D)), NewObj(5).Put("slurp", ((V)(0D))).Put("puff", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("head")));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("hum"))));
Call(d_367, V.Undef, ((V)("flossie")), Arr(Fn((V _self356, int _argc472, V t_478, V _a475, V _a476, V _a477, V[] _rest473) => {
return Call(sp_366, V.Undef, t_478, NewObj(3).Put("fluff", ((V)(1D))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1000D)), ((V)(700D)));
}, 1, "", true), Fn((V _self356, int _argc479, V t_485, V _a482, V _a483, V _a484, V[] _rest480) => {
Invoke(Invoke(t_485, "to", ((V)(1400D)), NewObj(1).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("l")));
return default;
}, 1, "", true), ((V)("curtsy"))));
return default;
}, 1, "", false));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
