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
Invoke(Set(G("window"), "HouseCreatures", (Get(G("window"), "HouseCreatures") is var _t266 && Truthy(_t266) ? _t266 : Arr())), "push", Fn((V _self10, int _argc11, V H_17, V _a14, V _a15, V _a16, V[] _rest12) => {
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
sp_24 = Fn((V _self10, int _argc47, V t_53, V v_54, V d_55, V hold_56, V[] _rest48) => {
V b_57 = default;
b_57 = NewObj(0).V;
Invoke(Object_keys(v_54), "forEach", Fn((V _self10, int _argc58, V k_64, V _a61, V _a62, V _a63, V[] _rest59) => {
return SetK(b_57, k_64, (!GetK(Get(t_53, "B"), k_64).IsNullish ? GetK(Get(t_53, "B"), k_64) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_53, "to", ((V)((ToNum((d_55 is var _t67 && Truthy(_t67) ? _t67 : ((V)(700D)))) * 0.4))), v_54, ((V)("o"))), "wait", (hold_56 is var _t66 && Truthy(_t66) ? _t66 : ((V)(300D)))), "to", ((V)((ToNum((d_55 is var _t65 && Truthy(_t65) ? _t65 : ((V)(700D)))) * 0.6))), b_57, ((V)("io")));
return t_53;
return default;
}, 4, "", true);
bk_25 = Fn((V _self10, int _argc68, V t_74, V d_75, V _a72, V _a73, V[] _rest69) => {
return Invoke(t_74, "back", (d_75 is var _t76 && Truthy(_t76) ? _t76 : ((V)(420D))));
}, 2, "", true);
B_26 = Fn((V _self10, int _argc77, V t_83, V k_84, V _a81, V _a82, V[] _rest78) => {
return (GetK(Get(t_83, "B"), k_84) is var _t85 && Truthy(_t85) ? _t85 : ((V)(0D)));
}, 2, "", true);
hop_27 = NewObj(2).Put("dn", ((V)("hop"))).Put("up", ((V)("hop"))).V;
mk_28 = Fn((V _self10, int _argc86, V key_92, V @base_93, V P_94, V _a91, V[] _rest87) => {
return Call(build_18, V.Undef, key_92, Call(o_23, V.Undef, @base_93, P_94, NewObj(2).Put("pose", Call(o_23, V.Undef, (Get(@base_93, "pose") is var _t95 && Truthy(_t95) ? _t95 : NewObj(0).V), (Get(P_94, "pose") is var _t96 && Truthy(_t96) ? _t96 : NewObj(0).V))).Put("lpose", Call(o_23, V.Undef, (Get(@base_93, "lpose") is var _t97 && Truthy(_t97) ? _t97 : NewObj(0).V), (Get(P_94, "lpose") is var _t98 && Truthy(_t98) ? _t98 : NewObj(0).V))).V));
}, 3, "", true);
SIG_29 = NewObj(9).Put("tilly", Fn((V _self10, int _argc99, V t_105, V _a102, V _a103, V _a104, V[] _rest100) => {
Invoke(t_105, "to", ((V)(160D)), NewObj(2).Put("earL", ((V)((-24D)))).Put("earR", ((V)((-24D)))).V, ((V)("o")));
{
V i_106 = default;
i_106 = ((V)(0D));
while (true) {
if (!(LtN(i_106, 3D))) break;
Invoke(Invoke(t_105, "to", ((V)(110D)), NewObj(1).Put("pitch", ((V)((ToNum(Call(B_26, V.Undef, t_105, ((V)("pitch")))) - 0.15)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("pitch", Call(B_26, V.Undef, t_105, ((V)("pitch")))).V, ((V)("io")));
PostInc(ref i_106, 1D);
}
}
Invoke(t_105, "fx", ((V)("note")), ((V)("head")));
return Call(bk_25, V.Undef, t_105);
return default;
}, 1, "tilly", true)).Put("pico", Fn((V _self10, int _argc108, V t_114, V _a111, V _a112, V _a113, V[] _rest109) => {
Invoke(Invoke(t_114, "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("open", ((V)(0.4))).Put("mw", ((V)(0.6))).V, NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("note")), ((V)("head")));
return Call(bk_25, V.Undef, t_114);
return default;
}, 1, "pico", true)).Put("clover", Fn((V _self10, int _argc115, V t_121, V _a118, V _a119, V _a120, V[] _rest116) => {
Invoke(Invoke(Invoke(t_121, "osc", ((V)(600D)), ((V)(4D)), NewObj(1).Put("mw", ((V)(0.7))).V, NewObj(1).Put("mw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("earL", ((V)(16D))).Put("earR", ((V)(16D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_121);
return default;
}, 1, "clover", true)).Put("chilla", Fn((V _self10, int _argc122, V t_128, V _a125, V _a126, V _a127, V[] _rest123) => {
Invoke(Invoke(Invoke(Invoke(t_128, "to", ((V)(160D)), NewObj(1).Put("sq", Add(Call(B_26, V.Undef, t_128, ((V)("sq"))), ((V)(0.08)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("lift", Add(Call(B_26, V.Undef, t_128, ((V)("lift"))), ((V)(4D)))).Put("sq", ((V)((ToNum(Call(B_26, V.Undef, t_128, ((V)("sq")))) - 0.06)))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(2).Put("lift", Call(B_26, V.Undef, t_128, ((V)("lift")))).Put("sq", Call(B_26, V.Undef, t_128, ((V)("sq")))).V, ((V)("i"))), "fx", ((V)("poof")), ((V)("body")), ((V)(2D)));
return Call(bk_25, V.Undef, t_128);
return default;
}, 1, "chilla", true)).Put("mimi", Fn((V _self10, int _argc129, V t_135, V _a132, V _a133, V _a134, V[] _rest130) => {
Invoke(Invoke(t_135, "osc", ((V)(800D)), ((V)(5D)), NewObj(2).Put("mw", ((V)(0.7))).Put("pitch", Add(Call(B_26, V.Undef, t_135, ((V)("pitch"))), ((V)(0.05)))).V, NewObj(2).Put("mw", ((V)(1D))).Put("pitch", Call(B_26, V.Undef, t_135, ((V)("pitch")))).V, ((V)("o"))), "fx", ((V)("note")), ((V)("head")));
return Call(bk_25, V.Undef, t_135);
return default;
}, 1, "mimi", true)).Put("puddles", Fn((V _self10, int _argc136, V t_142, V _a139, V _a140, V _a141, V[] _rest137) => {
Invoke(Invoke(Invoke(t_142, "osc", ((V)(800D)), ((V)(6D)), NewObj(1).Put("wag", ((V)(30D))).V, NewObj(1).Put("wag", ((V)((-30D)))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("wag", ((V)(0D))).V), "fx", ((V)("note")), ((V)("head")));
return Call(bk_25, V.Undef, t_142);
return default;
}, 1, "puddles", true)).Put("bean", Fn((V _self10, int _argc143, V t_149, V _a146, V _a147, V _a148, V[] _rest144) => {
Invoke(Invoke(t_149, "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.25))).Put("hap", ((V)(0.8))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(6D)), NewObj(1).Put("wag", ((V)(40D))).V, NewObj(1).Put("wag", ((V)((-40D)))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_149);
return default;
}, 1, "bean", true)).Put("zippy", Fn((V _self10, int _argc150, V t_156, V _a153, V _a154, V _a155, V[] _rest151) => {
{
V i_157 = default;
i_157 = ((V)(0D));
while (true) {
if (!(LtN(i_157, 3D))) break;
Invoke(Invoke(t_156, "to", ((V)(80D)), NewObj(1).Put("lift", Add(Call(B_26, V.Undef, t_156, ((V)("lift"))), ((V)(1.6)))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(1).Put("lift", Call(B_26, V.Undef, t_156, ((V)("lift")))).V, ((V)("i")));
PostInc(ref i_157, 1D);
}
}
Invoke(t_156, "fx", ((V)("note")), ((V)("head")));
return Call(bk_25, V.Undef, t_156);
return default;
}, 1, "zippy", true)).Put("mango", Fn((V _self10, int _argc159, V t_165, V _a162, V _a163, V _a164, V[] _rest160) => {
Invoke(Invoke(Invoke(Invoke(t_165, "to", ((V)(380D)), NewObj(1).Put("close", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io"))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("io")));
return Call(bk_25, V.Undef, t_165);
return default;
}, 1, "mango", true)).V;
SLEEPY_30 = NewObj(9).Put("tilly", Fn((V _self10, int _argc166, V t_172, V _a169, V _a170, V _a171, V[] _rest167) => {
return Call(sp_24, V.Undef, t_172, NewObj(4).Put("earL", ((V)(22D))).Put("earR", ((V)(22D))).Put("sq", Add(Call(B_26, V.Undef, t_172, ((V)("sq"))), ((V)(0.08)))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1500D)));
}, 1, "tilly", true)).Put("pico", Fn((V _self10, int _argc173, V t_179, V _a176, V _a177, V _a178, V[] _rest174) => {
return Call(sp_24, V.Undef, t_179, NewObj(3).Put("sq", Add(Call(B_26, V.Undef, t_179, ((V)("sq"))), ((V)(0.1)))).Put("close", ((V)(1D))).Put("pitch", ((V)((ToNum(Call(B_26, V.Undef, t_179, ((V)("pitch")))) - 0.1)))).V, ((V)(1500D)), ((V)(1400D)));
}, 1, "pico", true)).Put("clover", Fn((V _self10, int _argc180, V t_186, V _a183, V _a184, V _a185, V[] _rest181) => {
return Call(sp_24, V.Undef, t_186, NewObj(4).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).Put("close", ((V)(1D))).Put("sq", Add(Call(B_26, V.Undef, t_186, ((V)("sq"))), ((V)(0.06)))).V, ((V)(1600D)), ((V)(1500D)));
}, 1, "clover", true)).Put("chilla", Fn((V _self10, int _argc187, V t_193, V _a190, V _a191, V _a192, V[] _rest188) => {
return Call(sp_24, V.Undef, t_193, NewObj(2).Put("sq", Add(Call(B_26, V.Undef, t_193, ((V)("sq"))), ((V)(0.1)))).Put("close", ((V)(1D))).V, ((V)(1500D)), ((V)(1400D)));
}, 1, "chilla", true)).Put("mimi", Fn((V _self10, int _argc194, V t_200, V _a197, V _a198, V _a199, V[] _rest195) => {
return Call(sp_24, V.Undef, t_200, NewObj(3).Put("sq", Add(Call(B_26, V.Undef, t_200, ((V)("sq"))), ((V)(0.08)))).Put("close", ((V)(1D))).Put("wag", ((V)(14D))).V, ((V)(1400D)), ((V)(1300D)));
}, 1, "mimi", true)).Put("puddles", Fn((V _self10, int _argc201, V t_207, V _a204, V _a205, V _a206, V[] _rest202) => {
return Call(sp_24, V.Undef, t_207, NewObj(3).Put("sq", Add(Call(B_26, V.Undef, t_207, ((V)("sq"))), ((V)(0.08)))).Put("close", ((V)(1D))).Put("pitch", ((V)((ToNum(Call(B_26, V.Undef, t_207, ((V)("pitch")))) - 0.12)))).V, ((V)(1500D)), ((V)(1400D)));
}, 1, "puddles", true)).Put("bean", Fn((V _self10, int _argc208, V t_214, V _a211, V _a212, V _a213, V[] _rest209) => {
Call(sp_24, V.Undef, t_214, NewObj(4).Put("sq", Add(Call(B_26, V.Undef, t_214, ((V)("sq"))), ((V)(0.08)))).Put("close", ((V)(1D))).Put("tongue", ((V)(0.4))).Put("open", ((V)(0.15))).V, ((V)(1700D)), ((V)(1600D)));
Invoke(t_214, "fx", ((V)("note")), ((V)("head")));
return t_214;
return default;
}, 1, "bean", true)).Put("zippy", Fn((V _self10, int _argc215, V t_221, V _a218, V _a219, V _a220, V[] _rest216) => {
return Call(sp_24, V.Undef, t_221, NewObj(3).Put("sq", Add(Call(B_26, V.Undef, t_221, ((V)("sq"))), ((V)(0.12)))).Put("close", ((V)(1D))).Put("bend", ((V)(3D))).V, ((V)(1500D)), ((V)(1400D)));
}, 1, "zippy", true)).Put("mango", Fn((V _self10, int _argc222, V t_228, V _a225, V _a226, V _a227, V[] _rest223) => {
return Call(sp_24, V.Undef, t_228, NewObj(3).Put("close", ((V)(1D))).Put("sq", Add(Call(B_26, V.Undef, t_228, ((V)("sq"))), ((V)(0.06)))).Put("wag", ((V)(18D))).V, ((V)(1900D)), ((V)(1800D)));
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
Invoke(K_8, "forEach", Fn((V _self10, int _argc229, V k_235, V _a232, V _a233, V _a234, V[] _rest230) => {
return Call(bedBuild_19, V.Undef, k_235, NewObj(3).Put("dr", GetK(DR_33, k_235)).Put("wk", GetK(WK_34, k_235)).Put("s", GetK(SLEEPY_30, k_235)).V);
}, 1, "", true));
SW_35 = NewObj(9).Put("tilly", ((V)("bob"))).Put("pico", ((V)("bob"))).Put("clover", ((V)("bob"))).Put("chilla", ((V)("bob"))).Put("mimi", ((V)("bob"))).Put("puddles", ((V)("glide"))).Put("bean", ((V)("bob"))).Put("zippy", ((V)("glide"))).Put("mango", ((V)("float"))).V;
Invoke(K_8, "forEach", Fn((V _self10, int _argc236, V k_242, V _a239, V _a240, V _a241, V[] _rest237) => {
return Call(waterBuild_20, V.Undef, k_242, NewObj(3).Put("sw", GetK(SW_35, k_242)).Put("k", NewObj(3).Put("a", GetK(WK_34, k_242)).Put("b", NewObj(0).V).Put("f", GetK(WK_34, k_242)).V).Put("s", GetK(SIG_29, k_242)).V);
}, 1, "", true));
SN_36 = NewObj(9).Put("tilly", ((V)("berry"))).Put("pico", ((V)("apple"))).Put("clover", ((V)("carrot"))).Put("chilla", ((V)("apple"))).Put("mimi", ((V)("cheese"))).Put("puddles", ((V)("berry"))).Put("bean", ((V)("bone"))).Put("zippy", ((V)("apple"))).Put("mango", ((V)("berry"))).V;
CHEER_37 = NewObj(9).Put("tilly", NewObj(1).Put("cheer", NewObj(2).Put("earL", ((V)((-26D)))).Put("earR", ((V)((-26D)))).V).V).Put("pico", NewObj(2).Put("cheer", NewObj(2).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V).Put("cheerFx", Arr(((V)("featherG")), ((V)("body")))).V).Put("clover", NewObj(1).Put("cheer", NewObj(2).Put("earL", ((V)(24D))).Put("earR", ((V)(24D))).V).V).Put("chilla", NewObj(2).Put("cheer", NewObj(2).Put("earL", ((V)(10D))).Put("earR", ((V)(10D))).V).Put("cheerFx", Arr(((V)("poof")), ((V)("body")))).V).Put("mimi", NewObj(1).Put("cheer", NewObj(1).Put("wag", ((V)(30D))).V).V).Put("puddles", NewObj(2).Put("cheer", NewObj(1).Put("wag", ((V)(30D))).V).Put("cheerFx", Arr(((V)("splash")), ((V)("body")))).V).Put("bean", NewObj(1).Put("cheer", NewObj(2).Put("tongue", ((V)(0.7))).Put("wag", ((V)(40D))).V).V).Put("zippy", NewObj(1).Put("cheer", NewObj(2).Put("bend", ((V)((-3D)))).Put("wag", ((V)(30D))).V).V).Put("mango", NewObj(1).Put("cheer", NewObj(1).Put("wag", ((V)(30D))).V).V).V;
Invoke(K_8, "forEach", Fn((V _self10, int _argc243, V k_249, V _a246, V _a247, V _a248, V[] _rest244) => {
return Call(playBuild_21, V.Undef, k_249, Call(o_23, V.Undef, GetK(CHEER_37, k_249), NewObj(2).Put("sn", GetK(SN_36, k_249)).Put("p", GetK(SIG_29, k_249)).V));
}, 1, "", true));
FC_38 = NewObj(9).Put("tilly", ((V)("flower"))).Put("pico", ((V)("star"))).Put("clover", ((V)("carrot"))).Put("chilla", ((V)("acorn"))).Put("mimi", ((V)("cheese"))).Put("puddles", ((V)("boot"))).Put("bean", ((V)("bone"))).Put("zippy", ((V)("crown"))).Put("mango", ((V)("shell"))).V;
TBC_39 = Arr(((V)("#5fb8e8")), ((V)("#7cc35a")), ((V)("#ff8fa8")), ((V)("#ffcc3a")), ((V)("#b98ae8")), ((V)("#ff8a4a")));
Invoke(K_8, "forEach", Fn((V _self10, int _argc250, V k_256, V i_257, V _a254, V _a255, V[] _rest251) => {
return Call(bBuild_22, V.Undef, k_256, Call(o_23, V.Undef, GetK(CHEER_37, k_256), NewObj(4).Put("fc", GetK(FC_38, k_256)).Put("tk", Call(o_23, V.Undef, GetK(WK_34, k_256))).Put("tb", GetIdx(TBC_39, (ToNum(i_257) % ToNum(Get(TBC_39, "length"))))).Put("sn", GetK(SN_36, k_256)).V));
}, 2, "", true));
if (Truthy(Get(H_17, "cBuild"))) {
Invoke(K_8, "forEach", Fn((V _self10, int _argc258, V k_264, V _a261, V _a262, V _a263, V[] _rest259) => {
return Invoke(H_17, "cBuild", k_264, NewObj(5).Put("ks", ((V)("foot"))).Put("pc", ((V)("#e8483c"))).Put("hc", ((V)("#e8483c"))).Put("mc", ((V)("#3b3b4a"))).Put("fc2", GetK(Arr(((V)("#ffcc3a")), ((V)("#5ab4f0")), ((V)("#ff8fa8")), ((V)("#b98ae8")), ((V)("#7cc35a")), ((V)("#ff8a4a")), ((V)("#ffcc3a")), ((V)("#5ab4f0")), ((V)("#ff8fa8"))), Invoke(K_8, "indexOf", k_264))).V);
}, 1, "", true));
}
Set(G("window"), "HouseWalkRUN", Object_assign((Get(G("window"), "HouseWalkRUN") is var _t265 && Truthy(_t265) ? _t265 : NewObj(0).V), NewObj(5).Put("tilly", NewObj(2).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).V).Put("pico", NewObj(2).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V).Put("clover", NewObj(2).Put("earL", ((V)(14D))).Put("earR", ((V)(14D))).V).Put("zippy", NewObj(1).Put("bend", ((V)((-2D)))).V).Put("bean", NewObj(2).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.25))).V).V));
return default;
}, 1, "", false));
walks_9 = Fn((V _self1, int _argc267, V W_273, V _a270, V _a271, V _a272, V[] _rest268) => {
V d_274 = default;
d_274 = Fn((V _self1, int _argc275, V k_281, V P_282, V _a279, V _a280, V[] _rest276) => {
return Invoke(W_273, "def", k_281, P_282);
}, 2, "", true);
Call(d_274, V.Undef, ((V)("tilly")), NewObj(2).Put("g", ((V)("strut"))).Put("a", ((V)(0.9))).V);
Call(d_274, V.Undef, ((V)("pico")), NewObj(2).Put("g", ((V)("hop"))).Put("a", ((V)(1.1))).V);
Call(d_274, V.Undef, ((V)("clover")), NewObj(2).Put("g", ((V)("hop"))).Put("a", ((V)(1.2))).V);
Call(d_274, V.Undef, ((V)("chilla")), NewObj(2).Put("g", ((V)("hop"))).Put("a", ((V)(1.25))).V);
Call(d_274, V.Undef, ((V)("mimi")), NewObj(2).Put("g", ((V)("scurry"))).Put("a", ((V)(1D))).V);
Call(d_274, V.Undef, ((V)("puddles")), NewObj(2).Put("g", ((V)("waddle"))).Put("a", ((V)(1.1))).V);
Call(d_274, V.Undef, ((V)("bean")), NewObj(2).Put("g", ((V)("trot"))).Put("a", ((V)(1D))).V);
Call(d_274, V.Undef, ((V)("zippy")), NewObj(2).Put("g", ((V)("skip"))).Put("a", ((V)(1.1))).V);
Call(d_274, V.Undef, ((V)("mango")), NewObj(2).Put("g", ((V)("crawl"))).Put("a", ((V)(0.8))).V);
return default;
}, 1, "", true);
if (Truthy(Get(G("window"), "HouseWalk"))) {
Call(walks_9, V.Undef, Get(G("window"), "HouseWalk"));
} else {
Invoke(Set(G("window"), "HouseWalkC", (Get(G("window"), "HouseWalkC") is var _t283 && Truthy(_t283) ? _t283 : Arr())), "push", walks_9);
}
Invoke(Set(G("window"), "HouseIdleC", (Get(G("window"), "HouseIdleC") is var _t406 && Truthy(_t406) ? _t406 : Arr())), "push", Fn((V _self284, int _argc285, V W_291, V _a288, V _a289, V _a290, V[] _rest286) => {
V hand_292 = default;
V both_293 = default;
V o_294 = default;
V sp_295 = default;
V d_296 = default;
V CB_297 = default;
if (_self284.IsNullish) _self284 = GlobalV;
{ V _t298 = Get(Get(G("window"), "RiveRig"), "HOUSE");
if (_t298.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t298));
{ V _t299 = Get(_t298, "hand");
hand_292 = _t299; }
{ V _t300 = Get(_t298, "both");
both_293 = _t300; }
{ V _t301 = Get(_t298, "o");
o_294 = _t301; } }
sp_295 = Get(W_291, "sp");
d_296 = Fn((V _self284, int _argc302, V k_308, V L_309, V _a306, V _a307, V[] _rest303) => {
return Invoke(W_291, "build", k_308, L_309);
}, 2, "", true);
Call(d_296, V.Undef, ((V)("tilly")), Arr(Fn((V _self284, int _argc310, V t_316, V _a313, V _a314, V _a315, V[] _rest311) => {
Invoke(Invoke(t_316, "to", ((V)(160D)), NewObj(2).Put("earL", ((V)((-24D)))).Put("earR", ((V)((-24D)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("armL", ((V)(96D))).Put("armR", ((V)(96D))).V, ((V)("o")));
{
V i_317 = default;
i_317 = ((V)(0D));
while (true) {
if (!(LtN(i_317, 3D))) break;
Invoke(Invoke(t_316, "to", ((V)(110D)), NewObj(1).Put("pitch", ((V)((-0.15)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_317, 1D);
}
}
Invoke(Invoke(t_316, "fx", ((V)("note")), ((V)("head"))), "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _self284, int _argc319, V t_325, V _a322, V _a323, V _a324, V[] _rest320) => {
Invoke(Invoke(Invoke(t_325, "to", ((V)(380D)), NewObj(4).Put("hyaw", ((V)((-0.5)))).Put("pitch", ((V)((-0.25)))).Put("htilt", ((V)((-10D)))).Put("armL", ((V)(30D))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(3D)), NewObj(2).Put("pitch", ((V)((-0.32)))).Put("open", ((V)(0.2))).V, NewObj(2).Put("pitch", ((V)((-0.22)))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(4).Put("hyaw", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("armL", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("flap"))));
Call(d_296, V.Undef, ((V)("pico")), Arr(Fn((V _self284, int _argc326, V t_332, V _a329, V _a330, V _a331, V[] _rest327) => {
Invoke(Invoke(t_332, "osc", ((V)(1000D)), ((V)(7D)), NewObj(3).Put("open", ((V)(0.4))).Put("mw", ((V)(0.6))).Put("pitch", ((V)(0.05))).V, NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("note")), ((V)("head")));
{
V i_333 = default;
i_333 = ((V)(0D));
while (true) {
if (!(LtN(i_333, 3D))) break;
Invoke(Invoke(t_332, "to", ((V)(100D)), NewObj(1).Put("pitch", ((V)((-0.18)))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_333, 1D);
}
}
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(2D))), ((V)("flap"))));
Call(d_296, V.Undef, ((V)("clover")), Arr(Fn((V _self284, int _argc335, V t_341, V _a338, V _a339, V _a340, V[] _rest336) => {
Invoke(Invoke(Invoke(Invoke(t_341, "osc", ((V)(600D)), ((V)(4D)), NewObj(1).Put("mw", ((V)(0.7))).V, NewObj(1).Put("mw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), Call(o_294, V.Undef, Call(both_293, V.Undef, ((V)(4D)), ((V)((-16D)))), NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), Call(both_293, V.Undef, ((V)(5D)), ((V)((-22D)))), Call(both_293, V.Undef, ((V)(4D)), ((V)((-13D)))), ((V)("io"))), "to", ((V)(280D)), Call(o_294, V.Undef, Call(both_293, V.Undef, ((V)(0D)), ((V)(0D))), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(2D))), ((V)("sniff"))));
CB_297 = NewObj(3).Put("LIE", NewObj(23).Put("tilt", ((V)(99D))).Put("x", ((V)((-43.5)))).Put("lift", ((V)(26.5))).Put("spin", ((V)((-16D)))).Put("sq", ((V)(0.1))).Put("sit", ((V)(1D))).Put("close", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("earL", ((V)(18D))).Put("earR", ((V)(50D))).Put("footL", ((V)(1.5))).Put("footR", ((V)(1.5))).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("bend", ((V)(0D))).Put("twist", ((V)(0D))).Put("lean", ((V)(0D))).Put("wag", ((V)(0D))).Put("dbs", ((V)(1D))).Put("wsk", ((V)(1D))).V).Put("A", NewObj(16).Put("tilt", ((V)(105D))).Put("x", ((V)((-42D)))).Put("lift", ((V)(28.5))).Put("spin", ((V)((-82D)))).Put("sq", ((V)(0.18))).Put("footL", ((V)(3.4))).Put("footR", ((V)(1.2))).Put("armL", ((V)((-28D)))).Put("armR", ((V)(6D))).Put("earL", ((V)(27D))).Put("earR", ((V)(50D))).Put("htilt", ((V)((-11D)))).Put("hyaw", ((V)((-0.14)))).Put("bend", ((V)((-14D)))).Put("twist", ((V)((-0.12)))).Put("wag", ((V)((-32D)))).V).Put("B", NewObj(16).Put("tilt", ((V)(95D))).Put("x", ((V)((-46D)))).Put("lift", ((V)(25.5))).Put("spin", ((V)(38D))).Put("sq", ((V)(0.18))).Put("footL", ((V)(0.6))).Put("footR", ((V)(3.4))).Put("armL", ((V)(6D))).Put("armR", ((V)((-28D)))).Put("earL", ((V)(26D))).Put("earR", ((V)(55D))).Put("htilt", ((V)(11D))).Put("hyaw", ((V)(0.14))).Put("bend", ((V)(18D))).Put("twist", ((V)(0.12))).Put("wag", ((V)(32D))).V).V;
Call(d_296, V.Undef, ((V)("chilla")), Arr(Fn((V _self284, int _argc342, V t_348, V _a345, V _a346, V _a347, V[] _rest343) => {
Invoke(Invoke(Invoke(Invoke(t_348, "to", ((V)(240D)), NewObj(1).Put("dbb", ((V)(1.12))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("dbb", ((V)(1D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(5).Put("lift", ((V)((-2.5)))).Put("sq", ((V)(0.14))).Put("close", ((V)(0.7))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "fx", ((V)("dustbath")), Arr(((V)(50D)), ((V)(84D))), ((V)(3D)));
{
V L_349 = default;
V mx_350 = default;
L_349 = Get(CB_297, "LIE");
mx_350 = Fn((V _self284, int _argc351, V q_357, V g_358, V _a355, V _a356, V[] _rest352) => {
V r_359 = default;
r_359 = NewObj(0).V;
{
foreach (V _k360 in ForInKeys(q_357)) {
V k_361 = default;
k_361 = _k360;
SetK(r_359, k_361, Add(GetK(L_349, k_361), ((V)(((ToNum(GetK(q_357, k_361)) - ToNum(GetK(L_349, k_361))) * ToNum(g_358))))));
}
}
return r_359;
return default;
}, 2, "", true);
Invoke(Invoke(Invoke(Invoke(Invoke(t_348, "to", ((V)(200D)), NewObj(9).Put("tilt", ((V)(44D))).Put("x", ((V)((-17D)))).Put("lift", ((V)(9D))).Put("spin", ((V)((-6D)))).Put("sq", ((V)(0.06))).Put("sit", ((V)(0.6))).Put("earL", ((V)(18D))).Put("earR", ((V)(18D))).Put("close", ((V)(1D))).V, ((V)("i"))), "to", ((V)(190D)), Object_assign(NewObj(0).V, L_349, NewObj(3).Put("tilt", ((V)(105D))).Put("lift", ((V)(25D))).Put("x", ((V)((-42.5)))).V), ((V)("o"))), "fx", ((V)("dustbath")), Arr(((V)(30D)), ((V)(83D))), ((V)(3D))), "fx", ((V)("dustbath")), Arr(((V)(70D)), ((V)(83D))), ((V)(3D))), "to", ((V)(170D)), NewObj(4).Put("tilt", ((V)(99D))).Put("lift", ((V)(26.5))).Put("x", ((V)((-43.5)))).Put("dbh", ((V)(0.4))).V, ((V)("io")));
{
V i_362 = default;
i_362 = ((V)(0D));
while (true) {
if (!(LtN(i_362, 10D))) break;
V g_364 = default;
g_364 = ((V)(Min(1D, (ToNum(Add(i_362, ((V)(1D)))) / 3D), ((10D - ToNum(i_362)) / 3D))));
Invoke(t_348, "to", ((V)(170D)), Object_assign(Call(mx_350, V.Undef, (NumTruthy((ToNum(i_362) % 2D)) ? Get(CB_297, "B") : Get(CB_297, "A")), g_364), NewObj(1).Put("dbh", ((V)(0.8))).V), ((V)("io")));
if (NumTruthy((ToNum(i_362) % 2D))) {
Invoke(Invoke(t_348, "fx", ((V)("dustbath")), Arr(((V)((24D + ((ToNum(i_362) * 13D) % 52D)))), ((V)(83D))), ((V)(2D))), "fx", ((V)("dustspray")), Arr(((V)((((ToNum(i_362) % 4D) == 1D) ? 24D : 80D))), ((V)(82D))), ((V)(2D)));
}
PostInc(ref i_362, 1D);
}
}
Invoke(Invoke(Invoke(Invoke(t_348, "to", ((V)(200D)), Object_assign(Call(mx_350, V.Undef, Get(CB_297, "A"), ((V)(0D))), NewObj(1).Put("dbh", ((V)(0.3))).V), ((V)("io"))), "to", ((V)(230D)), NewObj(20).Put("tilt", ((V)(46D))).Put("x", ((V)((-16D)))).Put("lift", ((V)(10D))).Put("spin", ((V)((-6D)))).Put("sit", ((V)(0.4))).Put("sq", ((V)(0.06))).Put("close", ((V)(0.4))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("bend", ((V)(0D))).Put("twist", ((V)(0D))).Put("lean", ((V)(0D))).Put("wag", ((V)(0D))).Put("dbh", ((V)(0D))).Put("dbs", ((V)(0D))).Put("wsk", ((V)(0.4))).V, ((V)("i"))), "to", ((V)(230D)), NewObj(12).Put("tilt", ((V)((-6D)))).Put("x", ((V)(0D))).Put("lift", ((V)((-1D)))).Put("spin", ((V)(0D))).Put("sit", ((V)(0D))).Put("sq", ((V)(0.04))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("smile", ((V)(0D))).Put("wsk", ((V)(0D))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(3).Put("tilt", ((V)(0D))).Put("lift", ((V)((-2.5)))).Put("sq", ((V)(0.1))).V, ((V)("io")));
}
Invoke(Invoke(Invoke(t_348, "to", ((V)(180D)), NewObj(1).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(3).Put("dbb", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i"))), "fx", ((V)("poof")), ((V)("body")), ((V)(2D)));
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(2D))), ((V)("shake"))));
Call(d_296, V.Undef, ((V)("mimi")), Arr(Fn((V _self284, int _argc365, V t_371, V _a368, V _a369, V _a370, V[] _rest366) => {
Invoke(Invoke(Invoke(t_371, "to", ((V)(240D)), Call(o_294, V.Undef, Call(both_293, V.Undef, ((V)(5D)), ((V)((-15D)))), NewObj(2).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(4D)), Call(both_293, V.Undef, ((V)(9D)), ((V)((-13D)))), Call(both_293, V.Undef, ((V)(4D)), ((V)((-15D)))), ((V)("io"))), "to", ((V)(240D)), Call(o_294, V.Undef, Call(both_293, V.Undef, ((V)(0D)), ((V)(0D))), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
return default;
}, 1, "", true), ((V)("sniff")), ((V)("clap"))));
Call(d_296, V.Undef, ((V)("puddles")), Arr(Fn((V _self284, int _argc372, V t_378, V _a375, V _a376, V _a377, V[] _rest373) => {
{
V i_379 = default;
i_379 = ((V)(0D));
while (true) {
if (!(LtN(i_379, 4D))) break;
V f_381 = default;
f_381 = ((V)((NumTruthy((ToNum(i_379) % 2D)) ? "footL" : "footR")));
Invoke(Invoke(Invoke(Invoke(t_378, "to", ((V)(140D)), NewObj(1).PutK(f_381, ((V)(3.5))).V, ((V)("o"))), "to", ((V)(90D)), NewObj(2).PutK(f_381, ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("body")), ((V)(2D))), "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_379, 1D);
}
}
return default;
}, 1, "", true), ((V)("flap")), ((V)("shimmy"))));
Call(d_296, V.Undef, ((V)("bean")), Arr(Fn((V _self284, int _argc382, V t_388, V _a385, V _a386, V _a387, V[] _rest383) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_388, "to", ((V)(320D)), NewObj(3).Put("htilt", ((V)(16D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(340D)), NewObj(1).Put("htilt", ((V)((-12D)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(260D)), NewObj(3).Put("htilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("shimmy")), ((V)("sniff"))));
Call(d_296, V.Undef, ((V)("zippy")), Arr(Fn((V _self284, int _argc389, V t_395, V _a392, V _a393, V _a394, V[] _rest390) => {
{
V i_396 = default;
i_396 = ((V)(0D));
while (true) {
if (!(LtN(i_396, 4D))) break;
V s_398 = default;
s_398 = ((V)((NumTruthy((ToNum(i_396) % 2D)) ? (-1D) : 1D)));
Invoke(Invoke(Invoke(t_395, "to", ((V)(70D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(3).Put("lift", ((V)(5D))).Put("x", ((V)((ToNum(s_398) * 2.5)))).Put("tilt", ((V)((ToNum(s_398) * 10D)))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(2).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_396, 1D);
}
}
Invoke(Invoke(t_395, "to", ((V)(300D)), NewObj(1).Put("x", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("note")), ((V)("head")));
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(3D))), ((V)("shimmy"))));
Call(d_296, V.Undef, ((V)("mango")), Arr(Fn((V _self284, int _argc399, V t_405, V _a402, V _a403, V _a404, V[] _rest400) => {
Invoke(Invoke(Invoke(Invoke(t_405, "to", ((V)(120D)), NewObj(5).Put("tongue", ((V)(1D))).Put("open", ((V)(0.3))).Put("pitch", ((V)(0.18))).Put("htilt", ((V)(8D))).Put("winkR", ((V)(1D))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(5).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(300D))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("stretch")), ((V)("rock"))));
return default;
}, 1, "", false));
return default;
}, 0, "", false), V.Undef);
        }
    }
}
