// pet2-house.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_pet2_house_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V K_8 = default;
V walks_9 = default;
if (_self1.IsNullish) _self1 = GlobalV;
K_8 = Arr(((V)("tilly")), ((V)("pico")), ((V)("clover")), ((V)("chilla")), ((V)("mimi")), ((V)("puddles")), ((V)("bean")), ((V)("zippy")), ((V)("mango")));
Invoke(Set(G("window"), "HouseCreatures", (Get(G("window"), "HouseCreatures") is var _t294 && Truthy(_t294) ? _t294 : Arr())), "push", Fn((V _self10, int _argc11, V H_17, V _a14, V _a15, V _a16, V[] _rest12) => {
V build_18 = default;
V bedBuild_19 = default;
V waterBuild_20 = default;
V playBuild_21 = default;
V bBuild_22 = default;
V o_23 = default;
V sp_24 = default;
V bk_25 = default;
V B_26 = default;
V hop_27 = default;
V mk_28 = default;
V SIG_29 = default;
V SLEEPY_30 = default;
V AR_31 = default;
V WG_32 = default;
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
{ V _t46 = Get(_t40, "o");
o_23 = _t46; } }
sp_24 = Fn((V _arrowThis57, int _argc47, V t_53, V v_54, V d_55, V hold_56, V[] _rest48) => {
V b_58 = default;
b_58 = NewObj(0).V;
Invoke(Object_keys(v_54), "forEach", Fn((V _arrowThis66, int _argc59, V k_65, V _a62, V _a63, V _a64, V[] _rest60) => {
return SetK(b_58, k_65, (!GetK(Get(t_53, "B"), k_65).IsNullish ? GetK(Get(t_53, "B"), k_65) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_53, "to", ((V)((ToNum((d_55 is var _t69 && Truthy(_t69) ? _t69 : ((V)(700D)))) * 0.4))), v_54, ((V)("o"))), "wait", (hold_56 is var _t68 && Truthy(_t68) ? _t68 : ((V)(300D)))), "to", ((V)((ToNum((d_55 is var _t67 && Truthy(_t67) ? _t67 : ((V)(700D)))) * 0.6))), b_58, ((V)("io")));
return t_53;
return default;
}, 4, "", true);
bk_25 = Fn((V _arrowThis78, int _argc70, V t_76, V d_77, V _a74, V _a75, V[] _rest71) => {
return Invoke(t_76, "back", (d_77 is var _t79 && Truthy(_t79) ? _t79 : ((V)(420D))));
}, 2, "", true);
B_26 = Fn((V _arrowThis88, int _argc80, V t_86, V k_87, V _a84, V _a85, V[] _rest81) => {
return (GetK(Get(t_86, "B"), k_87) is var _t89 && Truthy(_t89) ? _t89 : ((V)(0D)));
}, 2, "", true);
hop_27 = NewObj(2).Put("dn", ((V)("hop"))).Put("up", ((V)("hop"))).V;
mk_28 = Fn((V _arrowThis99, int _argc90, V key_96, V @base_97, V P_98, V _a95, V[] _rest91) => {
return Call(build_18, V.Undef, key_96, Call(o_23, V.Undef, @base_97, P_98, NewObj(2).Put("pose", Call(o_23, V.Undef, (Get(@base_97, "pose") is var _t100 && Truthy(_t100) ? _t100 : NewObj(0).V), (Get(P_98, "pose") is var _t101 && Truthy(_t101) ? _t101 : NewObj(0).V))).Put("lpose", Call(o_23, V.Undef, (Get(@base_97, "lpose") is var _t102 && Truthy(_t102) ? _t102 : NewObj(0).V), (Get(P_98, "lpose") is var _t103 && Truthy(_t103) ? _t103 : NewObj(0).V))).V));
}, 3, "", true);
SIG_29 = NewObj(9).Put("tilly", Fn((V _arrowThis111, int _argc104, V t_110, V _a107, V _a108, V _a109, V[] _rest105) => {
Invoke(t_110, "to", ((V)(160D)), NewObj(2).Put("earL", ((V)((-24D)))).Put("earR", ((V)((-24D)))).V, ((V)("o")));
{
double i_112 = 0;
i_112 = 0D;
while (true) {
if (!((i_112 < 3D))) break;
Invoke(Invoke(t_110, "to", ((V)(110D)), NewObj(1).Put("pitch", ((V)((ToNum(Call(B_26, V.Undef, t_110, ((V)("pitch")))) - 0.15)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("pitch", Call(B_26, V.Undef, t_110, ((V)("pitch")))).V, ((V)("io")));
i_112++;
}
}
Invoke(t_110, "fx", ((V)("note")), ((V)("head")));
return Call(bk_25, V.Undef, t_110);
return default;
}, 1, "tilly", true)).Put("pico", Fn((V _arrowThis121, int _argc114, V t_120, V _a117, V _a118, V _a119, V[] _rest115) => {
Invoke(Invoke(t_120, "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("open", ((V)(0.4))).Put("mw", ((V)(0.6))).V, NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("note")), ((V)("head")));
return Call(bk_25, V.Undef, t_120);
return default;
}, 1, "pico", true)).Put("clover", Fn((V _arrowThis129, int _argc122, V t_128, V _a125, V _a126, V _a127, V[] _rest123) => {
Invoke(Invoke(Invoke(t_128, "osc", ((V)(600D)), ((V)(4D)), NewObj(1).Put("mw", ((V)(0.7))).V, NewObj(1).Put("mw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_128);
return default;
}, 1, "clover", true)).Put("chilla", Fn((V _arrowThis137, int _argc130, V t_136, V _a133, V _a134, V _a135, V[] _rest131) => {
Invoke(Invoke(Invoke(Invoke(t_136, "to", ((V)(160D)), NewObj(1).Put("sq", Add(Call(B_26, V.Undef, t_136, ((V)("sq"))), ((V)(0.08)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("lift", Add(Call(B_26, V.Undef, t_136, ((V)("lift"))), ((V)(4D)))).Put("sq", ((V)((ToNum(Call(B_26, V.Undef, t_136, ((V)("sq")))) - 0.06)))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(2).Put("lift", Call(B_26, V.Undef, t_136, ((V)("lift")))).Put("sq", Call(B_26, V.Undef, t_136, ((V)("sq")))).V, ((V)("i"))), "fx", ((V)("poof")), ((V)("body")), ((V)(2D)));
return Call(bk_25, V.Undef, t_136);
return default;
}, 1, "chilla", true)).Put("mimi", Fn((V _arrowThis145, int _argc138, V t_144, V _a141, V _a142, V _a143, V[] _rest139) => {
Invoke(Invoke(t_144, "osc", ((V)(800D)), ((V)(5D)), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", Add(Call(B_26, V.Undef, t_144, ((V)("pitch"))), ((V)(0.05)))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", Call(B_26, V.Undef, t_144, ((V)("pitch")))).V, ((V)("o"))), "fx", ((V)("note")), ((V)("head")));
return Call(bk_25, V.Undef, t_144);
return default;
}, 1, "mimi", true)).Put("puddles", Fn((V _arrowThis153, int _argc146, V t_152, V _a149, V _a150, V _a151, V[] _rest147) => {
Invoke(Invoke(Invoke(t_152, "osc", ((V)(800D)), ((V)(6D)), NewObj(1).Put("wag", ((V)(30D))).V, NewObj(1).Put("wag", ((V)((-30D)))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("wag", ((V)(0D))).V), "fx", ((V)("note")), ((V)("head")));
return Call(bk_25, V.Undef, t_152);
return default;
}, 1, "puddles", true)).Put("bean", Fn((V _arrowThis161, int _argc154, V t_160, V _a157, V _a158, V _a159, V[] _rest155) => {
Invoke(Invoke(t_160, "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.25))).Put("hap", ((V)(0.8))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(6D)), NewObj(1).Put("wag", ((V)(40D))).V, NewObj(1).Put("wag", ((V)((-40D)))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_160);
return default;
}, 1, "bean", true)).Put("zippy", Fn((V _arrowThis169, int _argc162, V t_168, V _a165, V _a166, V _a167, V[] _rest163) => {
{
double i_170 = 0;
i_170 = 0D;
while (true) {
if (!((i_170 < 3D))) break;
Invoke(Invoke(t_168, "to", ((V)(80D)), NewObj(1).Put("lift", Add(Call(B_26, V.Undef, t_168, ((V)("lift"))), ((V)(1.6)))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(1).Put("lift", Call(B_26, V.Undef, t_168, ((V)("lift")))).V, ((V)("i")));
i_170++;
}
}
Invoke(t_168, "fx", ((V)("note")), ((V)("head")));
return Call(bk_25, V.Undef, t_168);
return default;
}, 1, "zippy", true)).Put("mango", Fn((V _arrowThis179, int _argc172, V t_178, V _a175, V _a176, V _a177, V[] _rest173) => {
Invoke(Invoke(Invoke(Invoke(t_178, "to", ((V)(380D)), NewObj(1).Put("close", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_178);
return default;
}, 1, "mango", true)).V;
SLEEPY_30 = NewObj(9).Put("tilly", Fn((V _arrowThis187, int _argc180, V t_186, V _a183, V _a184, V _a185, V[] _rest181) => {
return Call(sp_24, V.Undef, t_186, NewObj(4).Put("earL", ((V)(22D))).Put("earR", ((V)(22D))).Put("sq", Add(Call(B_26, V.Undef, t_186, ((V)("sq"))), ((V)(0.08)))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1500D)));
}, 1, "tilly", true)).Put("pico", Fn((V _arrowThis195, int _argc188, V t_194, V _a191, V _a192, V _a193, V[] _rest189) => {
return Call(sp_24, V.Undef, t_194, NewObj(3).Put("sq", Add(Call(B_26, V.Undef, t_194, ((V)("sq"))), ((V)(0.1)))).Put("close", ((V)(1D))).Put("pitch", ((V)((ToNum(Call(B_26, V.Undef, t_194, ((V)("pitch")))) - 0.1)))).V, ((V)(1500D)), ((V)(1400D)));
}, 1, "pico", true)).Put("clover", Fn((V _arrowThis203, int _argc196, V t_202, V _a199, V _a200, V _a201, V[] _rest197) => {
return Call(sp_24, V.Undef, t_202, NewObj(4).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).Put("close", ((V)(1D))).Put("sq", Add(Call(B_26, V.Undef, t_202, ((V)("sq"))), ((V)(0.06)))).V, ((V)(1600D)), ((V)(1500D)));
}, 1, "clover", true)).Put("chilla", Fn((V _arrowThis211, int _argc204, V t_210, V _a207, V _a208, V _a209, V[] _rest205) => {
return Call(sp_24, V.Undef, t_210, NewObj(2).Put("sq", Add(Call(B_26, V.Undef, t_210, ((V)("sq"))), ((V)(0.1)))).Put("close", ((V)(1D))).V, ((V)(1500D)), ((V)(1400D)));
}, 1, "chilla", true)).Put("mimi", Fn((V _arrowThis219, int _argc212, V t_218, V _a215, V _a216, V _a217, V[] _rest213) => {
return Call(sp_24, V.Undef, t_218, NewObj(3).Put("sq", Add(Call(B_26, V.Undef, t_218, ((V)("sq"))), ((V)(0.08)))).Put("close", ((V)(1D))).Put("wag", ((V)(14D))).V, ((V)(1400D)), ((V)(1300D)));
}, 1, "mimi", true)).Put("puddles", Fn((V _arrowThis227, int _argc220, V t_226, V _a223, V _a224, V _a225, V[] _rest221) => {
return Call(sp_24, V.Undef, t_226, NewObj(3).Put("sq", Add(Call(B_26, V.Undef, t_226, ((V)("sq"))), ((V)(0.08)))).Put("close", ((V)(1D))).Put("pitch", ((V)((ToNum(Call(B_26, V.Undef, t_226, ((V)("pitch")))) - 0.12)))).V, ((V)(1500D)), ((V)(1400D)));
}, 1, "puddles", true)).Put("bean", Fn((V _arrowThis235, int _argc228, V t_234, V _a231, V _a232, V _a233, V[] _rest229) => {
Call(sp_24, V.Undef, t_234, NewObj(4).Put("sq", Add(Call(B_26, V.Undef, t_234, ((V)("sq"))), ((V)(0.08)))).Put("close", ((V)(1D))).Put("tongue", ((V)(0.4))).Put("open", ((V)(0.15))).V, ((V)(1700D)), ((V)(1600D)));
Invoke(t_234, "fx", ((V)("note")), ((V)("head")));
return t_234;
return default;
}, 1, "bean", true)).Put("zippy", Fn((V _arrowThis243, int _argc236, V t_242, V _a239, V _a240, V _a241, V[] _rest237) => {
return Call(sp_24, V.Undef, t_242, NewObj(3).Put("sq", Add(Call(B_26, V.Undef, t_242, ((V)("sq"))), ((V)(0.12)))).Put("close", ((V)(1D))).Put("bend", ((V)(3D))).V, ((V)(1500D)), ((V)(1400D)));
}, 1, "zippy", true)).Put("mango", Fn((V _arrowThis251, int _argc244, V t_250, V _a247, V _a248, V _a249, V[] _rest245) => {
return Call(sp_24, V.Undef, t_250, NewObj(3).Put("close", ((V)(1D))).Put("sq", Add(Call(B_26, V.Undef, t_250, ((V)("sq"))), ((V)(0.06)))).Put("wag", ((V)(18D))).V, ((V)(1900D)), ((V)(1800D)));
}, 1, "mango", true)).V;
AR_31 = NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V;
WG_32 = NewObj(2).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).V;
Call(mk_28, V.Undef, ((V)("tilly")), hop_27, NewObj(3).Put("lpose", WG_32).Put("f", Arr(((V)("look")), Get(SIG_29, "tilly"), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), Get(SLEEPY_30, "tilly"), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("pico")), hop_27, NewObj(3).Put("lpose", WG_32).Put("f", Arr(((V)("look")), Get(SIG_29, "pico"), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "pico"), ((V)("belly")))).V);
Call(mk_28, V.Undef, ((V)("clover")), hop_27, NewObj(3).Put("lpose", AR_31).Put("f", Arr(((V)("look")), Get(SIG_29, "clover"), ((V)("swing")), ((V)("ears")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "clover"), ((V)("belly")))).V);
Call(mk_28, V.Undef, ((V)("chilla")), hop_27, NewObj(3).Put("lpose", AR_31).Put("f", Arr(((V)("look")), Get(SIG_29, "chilla"), ((V)("swing")), ((V)("ears")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "chilla"), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("mimi")), hop_27, NewObj(3).Put("lpose", AR_31).Put("f", Arr(((V)("look")), Get(SIG_29, "mimi"), ((V)("kick")), ((V)("ears")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "mimi"), ((V)("belly")))).V);
Call(mk_28, V.Undef, ((V)("puddles")), hop_27, NewObj(3).Put("lpose", WG_32).Put("f", Arr(((V)("look")), Get(SIG_29, "puddles"), ((V)("kick")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "puddles"), ((V)("belly")))).V);
Call(mk_28, V.Undef, ((V)("bean")), hop_27, NewObj(3).Put("lpose", AR_31).Put("f", Arr(((V)("look")), Get(SIG_29, "bean"), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("belly")), Get(SLEEPY_30, "bean"), ((V)("doze")), ((V)("sigh")))).V);
Call(mk_28, V.Undef, ((V)("zippy")), hop_27, NewObj(3).Put("lpose", AR_31).Put("f", Arr(((V)("look")), Get(SIG_29, "zippy"), ((V)("kick")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "zippy"), ((V)("stretch")))).V);
Call(mk_28, V.Undef, ((V)("mango")), hop_27, NewObj(3).Put("lpose", AR_31).Put("f", Arr(((V)("look")), Get(SIG_29, "mango"), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Get(SLEEPY_30, "mango"), ((V)("belly")))).V);
DR_33 = NewObj(9).Put("tilly", ((V)("flower"))).Put("pico", ((V)("nut"))).Put("clover", ((V)("carrot"))).Put("chilla", ((V)("acorn"))).Put("mimi", ((V)("cheese"))).Put("puddles", ((V)("drop"))).Put("bean", ((V)("bone"))).Put("zippy", ((V)("crown"))).Put("mango", ((V)("sun"))).V;
WK_34 = NewObj(9).Put("tilly", NewObj(2).Put("earL", ((V)((-26D)))).Put("earR", ((V)((-26D)))).V).Put("pico", NewObj(2).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).V).Put("clover", NewObj(2).Put("earL", ((V)(22D))).Put("earR", ((V)(22D))).V).Put("chilla", NewObj(1).Put("lift", ((V)(3D))).V).Put("mimi", NewObj(2).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V).Put("puddles", NewObj(1).Put("wag", ((V)(30D))).V).Put("bean", NewObj(2).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.3))).V).Put("zippy", NewObj(1).Put("lift", ((V)(2D))).V).Put("mango", NewObj(1).Put("wag", ((V)(24D))).V).V;
Invoke(K_8, "forEach", Fn((V _arrowThis259, int _argc252, V k_258, V _a255, V _a256, V _a257, V[] _rest253) => {
return Call(bedBuild_19, V.Undef, k_258, NewObj(3).Put("dr", GetK(DR_33, k_258)).Put("wk", GetK(WK_34, k_258)).Put("s", GetK(SLEEPY_30, k_258)).V);
}, 1, "", true));
SW_35 = NewObj(9).Put("tilly", ((V)("bob"))).Put("pico", ((V)("bob"))).Put("clover", ((V)("bob"))).Put("chilla", ((V)("bob"))).Put("mimi", ((V)("bob"))).Put("puddles", ((V)("glide"))).Put("bean", ((V)("bob"))).Put("zippy", ((V)("glide"))).Put("mango", ((V)("float"))).V;
Invoke(K_8, "forEach", Fn((V _arrowThis267, int _argc260, V k_266, V _a263, V _a264, V _a265, V[] _rest261) => {
return Call(waterBuild_20, V.Undef, k_266, NewObj(3).Put("sw", GetK(SW_35, k_266)).Put("k", NewObj(3).Put("a", GetK(WK_34, k_266)).Put("b", NewObj(0).V).Put("f", GetK(WK_34, k_266)).V).Put("s", GetK(SIG_29, k_266)).V);
}, 1, "", true));
SN_36 = NewObj(9).Put("tilly", ((V)("berry"))).Put("pico", ((V)("apple"))).Put("clover", ((V)("carrot"))).Put("chilla", ((V)("apple"))).Put("mimi", ((V)("cheese"))).Put("puddles", ((V)("berry"))).Put("bean", ((V)("bone"))).Put("zippy", ((V)("apple"))).Put("mango", ((V)("berry"))).V;
CHEER_37 = NewObj(9).Put("tilly", NewObj(1).Put("cheer", NewObj(2).Put("earL", ((V)((-26D)))).Put("earR", ((V)((-26D)))).V).V).Put("pico", NewObj(2).Put("cheer", NewObj(2).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V).Put("cheerFx", Arr(((V)("featherG")), ((V)("body")))).V).Put("clover", NewObj(1).Put("cheer", NewObj(2).Put("earL", ((V)(24D))).Put("earR", ((V)(24D))).V).V).Put("chilla", NewObj(2).Put("cheer", NewObj(2).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V).Put("cheerFx", Arr(((V)("poof")), ((V)("body")))).V).Put("mimi", NewObj(1).Put("cheer", NewObj(1).Put("wag", ((V)(30D))).V).V).Put("puddles", NewObj(2).Put("cheer", NewObj(1).Put("wag", ((V)(30D))).V).Put("cheerFx", Arr(((V)("splash")), ((V)("body")))).V).Put("bean", NewObj(1).Put("cheer", NewObj(2).Put("tongue", ((V)(0.7))).Put("wag", ((V)(40D))).V).V).Put("zippy", NewObj(1).Put("cheer", NewObj(2).Put("bend", ((V)((-3D)))).Put("wag", ((V)(30D))).V).V).Put("mango", NewObj(1).Put("cheer", NewObj(1).Put("wag", ((V)(30D))).V).V).V;
Invoke(K_8, "forEach", Fn((V _arrowThis275, int _argc268, V k_274, V _a271, V _a272, V _a273, V[] _rest269) => {
return Call(playBuild_21, V.Undef, k_274, Call(o_23, V.Undef, GetK(CHEER_37, k_274), NewObj(2).Put("sn", GetK(SN_36, k_274)).Put("p", GetK(SIG_29, k_274)).V));
}, 1, "", true));
FC_38 = NewObj(9).Put("tilly", ((V)("flower"))).Put("pico", ((V)("star"))).Put("clover", ((V)("carrot"))).Put("chilla", ((V)("acorn"))).Put("mimi", ((V)("cheese"))).Put("puddles", ((V)("boot"))).Put("bean", ((V)("bone"))).Put("zippy", ((V)("crown"))).Put("mango", ((V)("shell"))).V;
TBC_39 = Arr(((V)("#5fb8e8")), ((V)("#7cc35a")), ((V)("#ff8fa8")), ((V)("#ffcc3a")), ((V)("#b98ae8")), ((V)("#ff8a4a")));
Invoke(K_8, "forEach", Fn((V _arrowThis284, int _argc276, V k_282, V i_283, V _a280, V _a281, V[] _rest277) => {
return Call(bBuild_22, V.Undef, k_282, Call(o_23, V.Undef, GetK(CHEER_37, k_282), NewObj(4).Put("fc", GetK(FC_38, k_282)).Put("tk", Call(o_23, V.Undef, GetK(WK_34, k_282))).Put("tb", GetIdx(TBC_39, (ToNum(i_283) % ToNum(Get(TBC_39, "length"))))).Put("sn", GetK(SN_36, k_282)).V));
}, 2, "", true));
if (Truthy(Get(H_17, "cBuild"))) {
Invoke(K_8, "forEach", Fn((V _arrowThis292, int _argc285, V k_291, V _a288, V _a289, V _a290, V[] _rest286) => {
return Invoke(H_17, "cBuild", k_291, NewObj(5).Put("ks", ((V)("foot"))).Put("pc", ((V)("#e8483c"))).Put("hc", ((V)("#e8483c"))).Put("mc", ((V)("#3b3b4a"))).Put("fc2", GetK(Arr(((V)("#ffcc3a")), ((V)("#5ab4f0")), ((V)("#ff8fa8")), ((V)("#b98ae8")), ((V)("#7cc35a")), ((V)("#ff8a4a")), ((V)("#ffcc3a")), ((V)("#5ab4f0")), ((V)("#ff8fa8"))), Invoke(K_8, "indexOf", k_291))).V);
}, 1, "", true));
}
Set(G("window"), "HouseWalkRUN", Object_assign((Get(G("window"), "HouseWalkRUN") is var _t293 && Truthy(_t293) ? _t293 : NewObj(0).V), NewObj(5).Put("tilly", NewObj(2).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).V).Put("pico", NewObj(2).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V).Put("clover", NewObj(2).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).V).Put("zippy", NewObj(1).Put("bend", ((V)((-2D)))).V).Put("bean", NewObj(2).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.25))).V).V));
return default;
}, 1, "", false));
walks_9 = Fn((V _arrowThis302, int _argc295, V W_301, V _a298, V _a299, V _a300, V[] _rest296) => {
V d_303 = default;
d_303 = Fn((V _arrowThis312, int _argc304, V k_310, V P_311, V _a308, V _a309, V[] _rest305) => {
return Invoke(W_301, "def", k_310, P_311);
}, 2, "", true);
Call(d_303, V.Undef, ((V)("tilly")), NewObj(2).Put("g", ((V)("strut"))).Put("a", ((V)(0.9))).V);
Call(d_303, V.Undef, ((V)("pico")), NewObj(2).Put("g", ((V)("hop"))).Put("a", ((V)(1.1))).V);
Call(d_303, V.Undef, ((V)("clover")), NewObj(2).Put("g", ((V)("hop"))).Put("a", ((V)(1.2))).V);
Call(d_303, V.Undef, ((V)("chilla")), NewObj(2).Put("g", ((V)("hop"))).Put("a", ((V)(1.25))).V);
Call(d_303, V.Undef, ((V)("mimi")), NewObj(2).Put("g", ((V)("scurry"))).Put("a", ((V)(1D))).V);
Call(d_303, V.Undef, ((V)("puddles")), NewObj(2).Put("g", ((V)("waddle"))).Put("a", ((V)(1.1))).V);
Call(d_303, V.Undef, ((V)("bean")), NewObj(2).Put("g", ((V)("trot"))).Put("a", ((V)(1D))).V);
Call(d_303, V.Undef, ((V)("zippy")), NewObj(2).Put("g", ((V)("skip"))).Put("a", ((V)(1.1))).V);
Call(d_303, V.Undef, ((V)("mango")), NewObj(2).Put("g", ((V)("crawl"))).Put("a", ((V)(0.8))).V);
return default;
}, 1, "", true);
if (Truthy(Get(G("window"), "HouseWalk"))) {
Call(walks_9, V.Undef, Get(G("window"), "HouseWalk"));
} else {
Invoke(Set(G("window"), "HouseWalkC", (Get(G("window"), "HouseWalkC") is var _t313 && Truthy(_t313) ? _t313 : Arr())), "push", walks_9);
}
Invoke(Set(G("window"), "HouseIdleC", (Get(G("window"), "HouseIdleC") is var _t448 && Truthy(_t448) ? _t448 : Arr())), "push", Fn((V _self314, int _argc315, V W_321, V _a318, V _a319, V _a320, V[] _rest316) => {
V hand_322 = default;
V both_323 = default;
V o_324 = default;
V sp_325 = default;
V d_326 = default;
V CB_327 = default;
if (_self314.IsNullish) _self314 = GlobalV;
{ V _t328 = Get(Get(G("window"), "RiveRig"), "HOUSE");
if (_t328.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t328));
{ V _t329 = Get(_t328, "hand");
hand_322 = _t329; }
{ V _t330 = Get(_t328, "both");
both_323 = _t330; }
{ V _t331 = Get(_t328, "o");
o_324 = _t331; } }
sp_325 = Get(W_321, "sp");
d_326 = Fn((V _arrowThis340, int _argc332, V k_338, V L_339, V _a336, V _a337, V[] _rest333) => {
return Invoke(W_321, "build", k_338, L_339);
}, 2, "", true);
Call(d_326, V.Undef, ((V)("tilly")), Arr(Fn((V _arrowThis348, int _argc341, V t_347, V _a344, V _a345, V _a346, V[] _rest342) => {
Invoke(Invoke(t_347, "to", ((V)(160D)), NewObj(2).Put("earL", ((V)((-24D)))).Put("earR", ((V)((-24D)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("armL", ((V)(96D))).Put("armR", ((V)(96D))).V, ((V)("o")));
{
double i_349 = 0;
i_349 = 0D;
while (true) {
if (!((i_349 < 3D))) break;
Invoke(Invoke(t_347, "to", ((V)(110D)), NewObj(1).Put("pitch", ((V)((-0.15)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io")));
i_349++;
}
}
Invoke(Invoke(t_347, "fx", ((V)("note")), ((V)("head"))), "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _arrowThis358, int _argc351, V t_357, V _a354, V _a355, V _a356, V[] _rest352) => {
Invoke(Invoke(Invoke(t_357, "to", ((V)(380D)), NewObj(4).Put("hyaw", ((V)((-0.5)))).Put("pitch", ((V)((-0.25)))).Put("htilt", ((V)((-10D)))).Put("armL", ((V)(30D))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(3D)), NewObj(2).Put("pitch", ((V)((-0.32)))).Put("open", ((V)(0.2))).V, NewObj(2).Put("pitch", ((V)((-0.22)))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(4).Put("hyaw", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("flap"))));
Call(d_326, V.Undef, ((V)("pico")), Arr(Fn((V _arrowThis366, int _argc359, V t_365, V _a362, V _a363, V _a364, V[] _rest360) => {
Invoke(Invoke(t_365, "osc", ((V)(1000D)), ((V)(7D)), NewObj(3).Put("open", ((V)(0.4))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.05))).V, NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("note")), ((V)("head")));
{
double i_367 = 0;
i_367 = 0D;
while (true) {
if (!((i_367 < 3D))) break;
Invoke(Invoke(t_365, "to", ((V)(100D)), NewObj(1).Put("pitch", ((V)((-0.18)))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io")));
i_367++;
}
}
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(2D))), ((V)("flap"))));
Call(d_326, V.Undef, ((V)("clover")), Arr(Fn((V _arrowThis376, int _argc369, V t_375, V _a372, V _a373, V _a374, V[] _rest370) => {
Invoke(Invoke(Invoke(Invoke(t_375, "osc", ((V)(600D)), ((V)(4D)), NewObj(1).Put("mw", ((V)(0.7))).V, NewObj(1).Put("mw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), Call(o_324, V.Undef, Call(both_323, V.Undef, ((V)(4D)), ((V)((-16D)))), NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), Call(both_323, V.Undef, ((V)(5D)), ((V)((-22D)))), Call(both_323, V.Undef, ((V)(4D)), ((V)((-13D)))), ((V)("io"))), "to", ((V)(280D)), Call(o_324, V.Undef, Call(both_323, V.Undef, ((V)(0D)), ((V)(0D))), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(2D))), ((V)("sniff"))));
CB_327 = NewObj(3).Put("LIE", NewObj(23).Put("tilt", ((V)(99D))).Put("x", ((V)((-43.5)))).Put("lift", ((V)(26.5))).Put("spin", ((V)((-16D)))).Put("sq", ((V)(0.1))).Put("sit", ((V)(1D))).Put("close", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("earL", ((V)(18D))).Put("earR", ((V)(50D))).Put("footL", ((V)(1.5))).Put("footR", ((V)(1.5))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("bend", ((V)(0D))).Put("twist", ((V)(0D))).Put("lean", ((V)(0D))).Put("wag", ((V)(0D))).Put("dbs", ((V)(1D))).Put("wsk", ((V)(1D))).V).Put("A", NewObj(16).Put("tilt", ((V)(105D))).Put("x", ((V)((-42D)))).Put("lift", ((V)(28.5))).Put("spin", ((V)((-82D)))).Put("sq", ((V)(0.18))).Put("footL", ((V)(3.4))).Put("footR", ((V)(1.2))).Put("armL", ((V)((-28D)))).Put("armR", ((V)(6D))).Put("earL", ((V)(27D))).Put("earR", ((V)(50D))).Put("htilt", ((V)((-11D)))).Put("hyaw", ((V)((-0.14)))).Put("bend", ((V)((-14D)))).Put("twist", ((V)((-0.12)))).Put("wag", ((V)((-32D)))).V).Put("B", NewObj(16).Put("tilt", ((V)(95D))).Put("x", ((V)((-46D)))).Put("lift", ((V)(25.5))).Put("spin", ((V)(38D))).Put("sq", ((V)(0.18))).Put("footL", ((V)(0.6))).Put("footR", ((V)(3.4))).Put("armL", ((V)(6D))).Put("armR", ((V)((-28D)))).Put("earL", ((V)(26D))).Put("earR", ((V)(55D))).Put("htilt", ((V)(11D))).Put("hyaw", ((V)(0.14))).Put("bend", ((V)(18D))).Put("twist", ((V)(0.12))).Put("wag", ((V)(32D))).V).V;
Call(d_326, V.Undef, ((V)("chilla")), Arr(Fn((V _arrowThis384, int _argc377, V t_383, V _a380, V _a381, V _a382, V[] _rest378) => {
Invoke(Invoke(Invoke(Invoke(t_383, "to", ((V)(240D)), NewObj(1).Put("dbb", ((V)(1.12))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("dbb", ((V)(1D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(5).Put("lift", ((V)((-2.5)))).Put("sq", ((V)(0.14))).Put("close", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "fx", ((V)("dustbath")), Arr(((V)(50D)), ((V)(84D))), ((V)(3D)));
{
V L_385 = default;
V mx_386 = default;
L_385 = Get(CB_327, "LIE");
mx_386 = Fn((V _arrowThis395, int _argc387, V q_393, V g_394, V _a391, V _a392, V[] _rest388) => {
V r_396 = default;
r_396 = NewObj(0).V;
{
foreach (V _k397 in ForInKeys(q_393)) {
V k_398 = default;
k_398 = _k397;
SetK(r_396, k_398, Add(GetK(L_385, k_398), ((V)(((ToNum(GetK(q_393, k_398)) - ToNum(GetK(L_385, k_398))) * ToNum(g_394))))));
}
}
return r_396;
return default;
}, 2, "", true);
Invoke(Invoke(Invoke(Invoke(Invoke(t_383, "to", ((V)(200D)), NewObj(9).Put("tilt", ((V)(44D))).Put("x", ((V)((-17D)))).Put("lift", ((V)(9D))).Put("spin", ((V)((-6D)))).Put("sq", ((V)(0.06))).Put("sit", ((V)(0.6))).Put("earL", ((V)(18D))).Put("earR", ((V)(18D))).Put("close", ((V)(1D))).V, ((V)("i"))), "to", ((V)(190D)), Object_assign(NewObj(0).V, L_385, NewObj(3).Put("tilt", ((V)(105D))).Put("lift", ((V)(25D))).Put("x", ((V)((-42.5)))).V), ((V)("o"))), "fx", ((V)("dustbath")), Arr(((V)(30D)), ((V)(83D))), ((V)(3D))), "fx", ((V)("dustbath")), Arr(((V)(70D)), ((V)(83D))), ((V)(3D))), "to", ((V)(170D)), NewObj(4).Put("tilt", ((V)(99D))).Put("lift", ((V)(26.5))).Put("x", ((V)((-43.5)))).Put("dbh", ((V)(0.4))).V, ((V)("io")));
{
double i_399 = 0;
i_399 = 0D;
while (true) {
if (!((i_399 < 10D))) break;
double g_401 = 0;
g_401 = Min(1D, ((i_399 + 1D) / 3D), ((10D - i_399) / 3D));
Invoke(t_383, "to", ((V)(170D)), Object_assign(Call(mx_386, V.Undef, (NumTruthy((i_399 % 2D)) ? Get(CB_327, "B") : Get(CB_327, "A")), ((V)(g_401))), NewObj(1).Put("dbh", ((V)(0.8))).V), ((V)("io")));
if (NumTruthy((i_399 % 2D))) {
Invoke(Invoke(t_383, "fx", ((V)("dustbath")), Arr(((V)((24D + ((i_399 * 13D) % 52D)))), ((V)(83D))), ((V)(2D))), "fx", ((V)("dustspray")), Arr(((V)((((i_399 % 4D) == 1D) ? 24D : 80D))), ((V)(82D))), ((V)(2D)));
}
i_399++;
}
}
Invoke(Invoke(Invoke(Invoke(t_383, "to", ((V)(200D)), Object_assign(Call(mx_386, V.Undef, Get(CB_327, "A"), ((V)(0D))), NewObj(1).Put("dbh", ((V)(0.3))).V), ((V)("io"))), "to", ((V)(230D)), NewObj(20).Put("tilt", ((V)(46D))).Put("x", ((V)((-16D)))).Put("lift", ((V)(10D))).Put("spin", ((V)((-6D)))).Put("sit", ((V)(0.4))).Put("sq", ((V)(0.06))).Put("close", ((V)(0.4))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("bend", ((V)(0D))).Put("twist", ((V)(0D))).Put("lean", ((V)(0D))).Put("wag", ((V)(0D))).Put("dbh", ((V)(0D))).Put("dbs", ((V)(0D))).Put("wsk", ((V)(0.4))).V, ((V)("i"))), "to", ((V)(230D)), NewObj(12).Put("tilt", ((V)((-6D)))).Put("x", ((V)(0D))).Put("lift", ((V)((-1D)))).Put("spin", ((V)(0D))).Put("sit", ((V)(0D))).Put("sq", ((V)(0.04))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("smile", ((V)(0D))).Put("wsk", ((V)(0D))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(3).Put("tilt", ((V)(0D))).Put("lift", ((V)((-2.5)))).Put("sq", ((V)(0.1))).V, ((V)("io")));
}
Invoke(Invoke(Invoke(t_383, "to", ((V)(180D)), NewObj(1).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(3).Put("dbb", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i"))), "fx", ((V)("poof")), ((V)("body")), ((V)(2D)));
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(2D))), ((V)("shake"))));
Call(d_326, V.Undef, ((V)("mimi")), Arr(Fn((V _arrowThis409, int _argc402, V t_408, V _a405, V _a406, V _a407, V[] _rest403) => {
Invoke(Invoke(Invoke(t_408, "to", ((V)(240D)), Call(o_324, V.Undef, Call(both_323, V.Undef, ((V)(5D)), ((V)((-15D)))), NewObj(2).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(4D)), Call(both_323, V.Undef, ((V)(9D)), ((V)((-13D)))), Call(both_323, V.Undef, ((V)(4D)), ((V)((-15D)))), ((V)("io"))), "to", ((V)(240D)), Call(o_324, V.Undef, Call(both_323, V.Undef, ((V)(0D)), ((V)(0D))), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
return default;
}, 1, "", true), ((V)("sniff")), ((V)("clap"))));
Call(d_326, V.Undef, ((V)("puddles")), Arr(Fn((V _arrowThis417, int _argc410, V t_416, V _a413, V _a414, V _a415, V[] _rest411) => {
{
double i_418 = 0;
i_418 = 0D;
while (true) {
if (!((i_418 < 4D))) break;
V f_420 = default;
f_420 = ((V)((NumTruthy((i_418 % 2D)) ? "footL" : "footR")));
Invoke(Invoke(Invoke(Invoke(t_416, "to", ((V)(140D)), NewObj(1).PutK(f_420, ((V)(3.5))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(2).PutK(f_420, ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("body")), ((V)(2D))), "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
i_418++;
}
}
return default;
}, 1, "", true), ((V)("flap")), ((V)("shimmy"))));
Call(d_326, V.Undef, ((V)("bean")), Arr(Fn((V _arrowThis428, int _argc421, V t_427, V _a424, V _a425, V _a426, V[] _rest422) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_427, "to", ((V)(320D)), NewObj(3).Put("htilt", ((V)(16D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(340D)), NewObj(1).Put("htilt", ((V)((-12D)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(260D)), NewObj(3).Put("htilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("shimmy")), ((V)("sniff"))));
Call(d_326, V.Undef, ((V)("zippy")), Arr(Fn((V _arrowThis436, int _argc429, V t_435, V _a432, V _a433, V _a434, V[] _rest430) => {
{
double i_437 = 0;
i_437 = 0D;
while (true) {
if (!((i_437 < 4D))) break;
double s_439 = 0;
s_439 = (NumTruthy((i_437 % 2D)) ? (-1D) : 1D);
Invoke(Invoke(Invoke(t_435, "to", ((V)(70D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(3).Put("lift", ((V)(5D))).Put("x", ((V)((s_439 * 2.5)))).Put("tilt", ((V)((s_439 * 10D)))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(2).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("i")));
i_437++;
}
}
Invoke(Invoke(t_435, "to", ((V)(300D)), NewObj(1).Put("x", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("note")), ((V)("head")));
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(3D))), ((V)("shimmy"))));
Call(d_326, V.Undef, ((V)("mango")), Arr(Fn((V _arrowThis447, int _argc440, V t_446, V _a443, V _a444, V _a445, V[] _rest441) => {
Invoke(Invoke(Invoke(Invoke(t_446, "to", ((V)(120D)), NewObj(5).Put("tongue", ((V)(1D))).Put("open", ((V)(0.3))).Put("pitch", ((V)(0.18))).Put("htilt", ((V)(8D))).Put("winkR", ((V)(1D))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(5).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(300D))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("stretch")), ((V)("rock"))));
return default;
}, 1, "", false));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
