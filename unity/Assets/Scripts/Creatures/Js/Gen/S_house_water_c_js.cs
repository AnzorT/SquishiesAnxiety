// house-water-c.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house_water_c_js
    {

        public static void Run()
        {
Set(G("window"), "HouseCreatures", (Get(G("window"), "HouseCreatures") is var _t1 && Truthy(_t1) ? _t1 : Arr()));
Invoke(Get(G("window"), "HouseCreatures"), "push", Fn((V _self2, int _argc3, V H_9, V _a6, V _a7, V _a8, V[] _rest4) => {
V waterBuild_10 = default;
V hand_11 = default;
V both_12 = default;
V o_13 = default;
V PROF_14 = default;
V sp_15 = default;
V bk_16 = default;
V W_17 = default;
V ears_18 = default;
V spray_19 = default;
V C_20 = default;
if (_self2.IsNullish) _self2 = GlobalV;
{ V _t21 = H_9;
if (_t21.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t21));
{ V _t22 = Get(_t21, "waterBuild");
waterBuild_10 = _t22; }
{ V _t23 = Get(_t21, "hand");
hand_11 = _t23; }
{ V _t24 = Get(_t21, "both");
both_12 = _t24; }
{ V _t25 = Get(_t21, "o");
o_13 = _t25; }
{ V _t26 = Get(_t21, "PROF");
PROF_14 = _t26; } }
sp_15 = Fn((V _arrowThis37, int _argc27, V t_33, V v_34, V d_35, V hold_36, V[] _rest28) => {
V b_38 = default;
b_38 = NewObj(0).V;
Invoke(Object_keys(v_34), "forEach", Fn((V _arrowThis46, int _argc39, V k_45, V _a42, V _a43, V _a44, V[] _rest40) => {
return SetK(b_38, k_45, (!GetK(Get(t_33, "B"), k_45).IsNullish ? GetK(Get(t_33, "B"), k_45) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_33, "to", ((V)((ToNum((d_35 is var _t49 && Truthy(_t49) ? _t49 : ((V)(700D)))) * 0.4))), v_34, ((V)("o"))), "wait", (hold_36 is var _t48 && Truthy(_t48) ? _t48 : ((V)(300D)))), "to", ((V)((ToNum((d_35 is var _t47 && Truthy(_t47) ? _t47 : ((V)(700D)))) * 0.6))), b_38, ((V)("io")));
return t_33;
return default;
}, 4, "", true);
bk_16 = Fn((V _arrowThis58, int _argc50, V t_56, V d_57, V _a54, V _a55, V[] _rest51) => {
return Invoke(t_56, "back", (d_57 is var _t59 && Truthy(_t59) ? _t59 : ((V)(420D))));
}, 2, "", true);
W_17 = Fn((V _arrowThis68, int _argc60, V a_66, V b_67, V _a64, V _a65, V[] _rest61) => {
return NewObj(3).Put("a", NewObj(1).Put("wag", a_66).V).Put("b", NewObj(1).Put("wag", ((V)((-ToNum(a_66))))).V).Put("f", (b_67 is var _t69 && Truthy(_t69) ? _t69 : NewObj(0).V)).V;
}, 2, "", true);
ears_18 = Fn((V _arrowThis78, int _argc70, V t_76, V n_77, V _a74, V _a75, V[] _rest71) => {
{
double i_79 = 0;
i_79 = 0D;
while (true) {
if (!(Lt(((V)(i_79)), (n_77 is var _t81 && Truthy(_t81) ? _t81 : ((V)(2D)))))) break;
Invoke(Invoke(t_76, "to", ((V)(110D)), NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)(14D))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(2).Put("earL", ((V)(10D))).Put("earR", ((V)((-10D)))).V);
i_79++;
}
}
return Invoke(t_76, "to", ((V)(140D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V);
return default;
}, 2, "", true);
spray_19 = Fn((V _arrowThis91, int _argc82, V t_88, V w_89, V n_90, V _a87, V[] _rest83) => {
return Invoke(t_88, "fx", ((V)("splash")), (w_89 is var _t92 && Truthy(_t92) ? _t92 : ((V)("body"))), (n_90 is var _t93 && Truthy(_t93) ? _t93 : ((V)(6D))));
}, 3, "", true);
C_20 = NewObj(81).Put("mittens", NewObj(2).Put("k", NewObj(3).Put("a", NewObj(1).Put("curl", ((V)(0.6))).V).Put("b", NewObj(1).Put("curl", ((V)(0.2))).V).Put("f", NewObj(1).Put("curl", ((V)(0.9))).V).V).Put("s", Fn((V _arrowThis101, int _argc94, V t_100, V _a97, V _a98, V _a99, V[] _rest95) => {
Invoke(Invoke(Invoke(t_100, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-13D)))), NewObj(2).Put("armR", ((V)(32D))).Put("close", ((V)(0.7))).V)), "osc", ((V)(1600D)), ((V)(5D)), NewObj(2).Put("tongue", ((V)(0.6))).Put("hRy", ((V)((-15D)))).V, NewObj(2).Put("tongue", ((V)(0.1))).Put("hRy", ((V)((-12D)))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(1).Put("tongue", ((V)(0D))).V);
Call(bk_16, V.Undef, t_100);
return default;
}, 1, "s", true)).V).Put("biscuit", NewObj(2).Put("k", Call(W_17, V.Undef, ((V)(28D)), NewObj(2).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V)).Put("s", Fn((V _arrowThis109, int _argc102, V t_108, V _a105, V _a106, V _a107, V[] _rest103) => {
Invoke(Invoke(t_108, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V), "osc", ((V)(1500D)), ((V)(8D)), NewObj(2).Put("wag", ((V)(28D))).Put("lift", Add(Get(Get(t_108, "B"), "lift"), ((V)(0.6)))).V, NewObj(2).Put("wag", ((V)((-28D)))).Put("lift", Get(Get(t_108, "B"), "lift")).V, ((V)("o")));
Call(spray_19, V.Undef, t_108, ((V)("sideR")), ((V)(8D)));
Call(bk_16, V.Undef, t_108);
return default;
}, 1, "s", true)).V).Put("prickle", NewObj(2).Put("k", NewObj(1).Put("f", NewObj(1).Put("curl", ((V)(0.3))).V).V).Put("s", Fn((V _arrowThis117, int _argc110, V t_116, V _a113, V _a114, V _a115, V[] _rest111) => {
Call(sp_15, V.Undef, t_116, NewObj(6).Put("curl", ((V)(1D))).Put("sq", Add(Get(Get(t_116, "B"), "sq"), ((V)(0.14)))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).Put("lift", Add(Get(Get(t_116, "B"), "lift"), ((V)(2D)))).V, ((V)(1600D)), ((V)(1600D)));
Invoke(t_116, "fx", ((V)("bubble")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "s", true)).V).Put("truffle", NewObj(2).Put("k", Call(W_17, V.Undef, ((V)(20D)))).Put("s", Fn((V _arrowThis125, int _argc118, V t_124, V _a121, V _a122, V _a123, V[] _rest119) => {
Invoke(Invoke(t_124, "to", ((V)(300D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V), "osc", ((V)(1400D)), ((V)(6D)), NewObj(2).Put("tilt", ((V)(4D))).Put("wag", ((V)(22D))).V, NewObj(2).Put("tilt", ((V)((-4D)))).Put("wag", ((V)((-22D)))).V, ((V)("s")));
Call(spray_19, V.Undef, t_124, ((V)("body")), ((V)(6D)));
Call(bk_16, V.Undef, t_124);
return default;
}, 1, "s", true)).V).Put("ribbit", NewObj(2).Put("sw", ((V)("glide"))).Put("s", Fn((V _arrowThis133, int _argc126, V t_132, V _a129, V _a130, V _a131, V[] _rest127) => {
{
double i_134 = 0;
i_134 = 0D;
while (true) {
if (!((i_134 < 3D))) break;
Invoke(Invoke(Invoke(t_132, "to", ((V)(120D)), NewObj(4).Put("lift", Add(Get(Get(t_132, "B"), "lift"), ((V)(3D)))).Put("sq", ((V)((ToNum(Get(Get(t_132, "B"), "sq")) - 0.06)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", Get(Get(t_132, "B"), "lift")).Put("sq", Add(Get(Get(t_132, "B"), "sq"), ((V)(0.04)))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("body")), ((V)(4D)));
i_134++;
}
}
Call(bk_16, V.Undef, t_132);
return default;
}, 1, "s", true)).V).Put("nibbles", NewObj(2).Put("k", NewObj(1).Put("f", NewObj(1).Put("puff", ((V)(0.7))).V).V).Put("s", Fn((V _arrowThis143, int _argc136, V t_142, V _a139, V _a140, V _a141, V[] _rest137) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_142, "to", ((V)(400D)), NewObj(1).Put("puff", ((V)(1D))).V), "wait", ((V)(400D))), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gush")), ((V)("mouth")), ((V)(3D))), "fx", ((V)("bubble")), ((V)("mouth")), ((V)(2D)));
Call(bk_16, V.Undef, t_142);
return default;
}, 1, "s", true)).V).Put("quill", NewObj(2).Put("k", NewObj(1).Put("f", NewObj(1).Put("blush", ((V)(0.7))).V).V).Put("s", Fn((V _arrowThis151, int _argc144, V t_150, V _a147, V _a148, V _a149, V[] _rest145) => {
return Call(sp_15, V.Undef, t_150, Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(10D)), ((V)((-14D)))), NewObj(5).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("blush", ((V)(1D))).Put("sq", Add(Get(Get(t_150, "B"), "sq"), ((V)(0.04)))).Put("close", ((V)(0.6))).V), ((V)(1400D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("waffles", NewObj(2).Put("k", Call(W_17, V.Undef, ((V)(22D)))).Put("s", Fn((V _arrowThis159, int _argc152, V t_158, V _a155, V _a156, V _a157, V[] _rest153) => {
Invoke(Invoke(t_158, "to", ((V)(700D)), NewObj(4).Put("sk", Add(Get(Get(t_158, "B"), "sk"), ((V)(3D)))).Put("close", ((V)(0.9))).Put("smile", ((V)(1D))).Put("sq", Add(Get(Get(t_158, "B"), "sq"), ((V)(0.08)))).V, ((V)("s"))), "osc", ((V)(1600D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(16D))).V, NewObj(1).Put("wag", ((V)((-16D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_158, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("poppy", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(2).Put("earL", ((V)((-18D)))).Put("earR", ((V)(16D))).V).Put("b", NewObj(2).Put("earL", ((V)(16D))).Put("earR", ((V)((-18D)))).V).V).Put("s", Fn((V _arrowThis167, int _argc160, V t_166, V _a163, V _a164, V _a165, V[] _rest161) => {
{
double i_168 = 0;
i_168 = 0D;
while (true) {
if (!((i_168 < 3D))) break;
Invoke(Invoke(Invoke(t_166, "to", ((V)(140D)), NewObj(4).Put("lift", Add(Get(Get(t_166, "B"), "lift"), ((V)(3D)))).Put("sq", ((V)((ToNum(Get(Get(t_166, "B"), "sq")) - 0.06)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", Get(Get(t_166, "B"), "lift")).Put("sq", Add(Get(Get(t_166, "B"), "sq"), ((V)(0.04)))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("body")), ((V)(4D)));
i_168++;
}
}
Call(bk_16, V.Undef, t_166);
return default;
}, 1, "s", true)).V).Put("duchess", NewObj(2).Put("k", NewObj(1).Put("f", NewObj(1).Put("htilt", ((V)(8D))).V).V).Put("s", Fn((V _arrowThis177, int _argc170, V t_176, V _a173, V _a174, V _a175, V[] _rest171) => {
Invoke(Invoke(Invoke(Invoke(t_176, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-13D)))), NewObj(4).Put("armR", ((V)(34D))).Put("close", ((V)(0.7))).Put("htilt", ((V)(8D))).Put("pitch", Add(Get(Get(t_176, "B"), "pitch"), ((V)(0.12)))).V)), "wait", ((V)(1200D))), "to", ((V)(300D)), NewObj(1).Put("sqz", ((V)(0.5))).V), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_176);
return default;
}, 1, "s", true)).V).Put("mamapaws", NewObj(2).Put("k", Call(W_17, V.Undef, ((V)(14D)))).Put("s", Fn((V _arrowThis185, int _argc178, V t_184, V _a181, V _a182, V _a183, V[] _rest179) => {
Invoke(Invoke(Invoke(t_184, "to", ((V)(600D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(12D)), ((V)(1D))), NewObj(4).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("smile", ((V)(1D))).Put("close", ((V)(0.6))).V)), "fx", ((V)("heart")), ((V)("head"))), "osc", ((V)(1400D)), ((V)(2D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_184, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("nimbo", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _arrowThis193, int _argc186, V t_192, V _a189, V _a190, V _a191, V[] _rest187) => {
Invoke(Invoke(Invoke(Invoke(t_192, "fx", ((V)("drop")), ((V)("body")), ((V)(4D))), "osc", ((V)(1800D)), ((V)(3D)), NewObj(2).Put("sq", Add(Get(Get(t_192, "B"), "sq"), ((V)(0.06)))).Put("puff", ((V)(0.4))).V, NewObj(2).Put("sq", Get(Get(t_192, "B"), "sq")).Put("puff", ((V)(0D))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("body")), ((V)(4D))), "fx", ((V)("drop")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_192);
return default;
}, 1, "s", true)).V).Put("lumi", NewObj(1).Put("s", Fn((V _arrowThis201, int _argc194, V t_200, V _a197, V _a198, V _a199, V[] _rest195) => {
Invoke(Invoke(Invoke(t_200, "to", ((V)(500D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-10D)))), NewObj(4).Put("armR", ((V)(80D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).Put("ly", ((V)((-0.6)))).V), ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D))), "wait", ((V)(1200D)));
Call(bk_16, V.Undef, t_200, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("bubbly", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _arrowThis209, int _argc202, V t_208, V _a205, V _a206, V _a207, V[] _rest203) => {
{
double i_210 = 0;
i_210 = 0D;
while (true) {
if (!((i_210 < 3D))) break;
Invoke(Invoke(Invoke(t_208, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.6))).Put("sq", Add(Get(Get(t_208, "B"), "sq"), ((V)(0.05)))).V), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)(((i_210 == 2D) ? "bigbubble" : "bubble"))), ((V)("mouth")), ((V)(2D)));
i_210++;
}
}
Call(bk_16, V.Undef, t_208);
return default;
}, 1, "s", true)).V).Put("twinkle", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _arrowThis219, int _argc212, V t_218, V _a215, V _a216, V _a217, V[] _rest213) => {
Invoke(Invoke(Invoke(Invoke(t_218, "to", ((V)(300D)), NewObj(3).Put("glow", ((V)(1D))).Put("wide", ((V)(0.6))).Put("hap", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("body")), ((V)(6D))), "wait", ((V)(900D))), "to", ((V)(500D)), NewObj(1).Put("glow", ((V)(0D))).V);
Call(bk_16, V.Undef, t_218);
return default;
}, 1, "s", true)).V).Put("zappi", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(1).Put("zap", ((V)(0.8))).V).Put("b", NewObj(1).Put("zap", ((V)(0.3))).V).V).Put("s", Fn((V _arrowThis227, int _argc220, V t_226, V _a223, V _a224, V _a225, V[] _rest221) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_226, "to", ((V)(80D)), NewObj(3).Put("zap", ((V)(1D))).Put("x", ((V)(0.5))).Put("wide", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(420D)), ((V)(4D)), NewObj(1).Put("x", ((V)((-0.5)))).V, NewObj(1).Put("x", ((V)(0.5))).V, ((V)("l"))), "fx", ((V)("spark")), ((V)("body")), ((V)(6D))), "to", ((V)(300D)), NewObj(3).Put("zap", ((V)(0D))).Put("x", ((V)(0D))).Put("sqz", ((V)(0.6))).V), "to", ((V)(300D)), NewObj(1).Put("sqz", ((V)(0D))).V);
Call(bk_16, V.Undef, t_226);
return default;
}, 1, "s", true)).V).Put("plip", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis235, int _argc228, V t_234, V _a231, V _a232, V _a233, V[] _rest229) => {
Invoke(Invoke(t_234, "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_234, "B"), "sq"), ((V)(0.08)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_234, "B"), "sq")) - 0.03)))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D)));
Call(bk_16, V.Undef, t_234);
return default;
}, 1, "s", true)).V).Put("breeze", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _arrowThis243, int _argc236, V t_242, V _a239, V _a240, V _a241, V[] _rest237) => {
Invoke(Invoke(Invoke(Invoke(t_242, "to", ((V)(500D)), NewObj(2).Put("puff", ((V)(0.8))).Put("open", ((V)(0D))).V), "to", ((V)(500D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.35))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head"))), "fx", ((V)("splash")), ((V)("mouth")), ((V)(6D)));
Call(bk_16, V.Undef, t_242);
return default;
}, 1, "s", true)).V).Put("dusty", NewObj(1).Put("s", Fn((V _arrowThis251, int _argc244, V t_250, V _a247, V _a248, V _a249, V[] _rest245) => {
Invoke(Call(ears_18, V.Undef, t_250, ((V)(3D))), "fx", ((V)("dust")), ((V)("body")), ((V)(4D)));
Call(bk_16, V.Undef, t_250);
return default;
}, 1, "s", true)).V).Put("aurora", NewObj(3).Put("sw", ((V)("glide"))).Put("k", NewObj(1).Put("a", NewObj(1).Put("spout", ((V)(0.6))).V).V).Put("s", Fn((V _arrowThis259, int _argc252, V t_258, V _a255, V _a256, V _a257, V[] _rest253) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_258, "to", ((V)(300D)), NewObj(1).Put("spout", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("gush")), ((V)("head")), ((V)(4D))), "fx", ((V)("splash")), ((V)("head")), ((V)(6D))), "wait", ((V)(600D))), "to", ((V)(500D)), NewObj(2).Put("spout", ((V)(0D))).Put("glow", ((V)(0.8))).V), "wait", ((V)(700D)));
Call(bk_16, V.Undef, t_258, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("mallow", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis267, int _argc260, V t_266, V _a263, V _a264, V _a265, V[] _rest261) => {
return Call(sp_15, V.Undef, t_266, NewObj(4).Put("sq", Add(Get(Get(t_266, "B"), "sq"), ((V)(0.2)))).Put("sk", Add(Get(Get(t_266, "B"), "sk"), ((V)(2D)))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1800D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("bao", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis275, int _argc268, V t_274, V _a271, V _a272, V _a273, V[] _rest269) => {
Invoke(Invoke(Invoke(t_274, "fx", ((V)("steam")), ((V)("head"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(Get(t_274, "B"), "sq"), ((V)(0.06)))).V, NewObj(1).Put("sq", Get(Get(t_274, "B"), "sq")).V, ((V)("s"))), "fx", ((V)("steam")), ((V)("head")));
Call(bk_16, V.Undef, t_274);
return default;
}, 1, "s", true)).V).Put("dunkie", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis283, int _argc276, V t_282, V _a279, V _a280, V _a281, V[] _rest277) => {
Invoke(Invoke(t_282, "osc", ((V)(1800D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("turn", ((V)(0.3))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("turn", ((V)((-0.3)))).V, ((V)("s"))), "fx", ((V)("sprinkle")), ((V)("head")));
Call(bk_16, V.Undef, t_282);
return default;
}, 1, "s", true)).V).Put("frybo", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("fw", ((V)(1D))).V).Put("b", NewObj(1).Put("fw", ((V)(0.3))).V).V).Put("s", Fn((V _arrowThis291, int _argc284, V t_290, V _a287, V _a288, V _a289, V[] _rest285) => {
Call(sp_15, V.Undef, t_290, NewObj(3).Put("fw", ((V)(1D))).Put("smile", ((V)(1D))).Put("hap", ((V)(1D))).V, ((V)(1200D)), ((V)(900D)));
Invoke(t_290, "fx", ((V)("salt")), ((V)("head")));
return default;
}, 1, "s", true)).V).Put("bunbun", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("split", ((V)(0.4))).V).Put("b", NewObj(1).Put("split", ((V)(0.1))).V).V).Put("s", Fn((V _arrowThis299, int _argc292, V t_298, V _a295, V _a296, V _a297, V[] _rest293) => {
return Call(sp_15, V.Undef, t_298, NewObj(3).Put("split", ((V)(0.5))).Put("shuf", ((V)(0.4))).Put("hap", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "s", true)).V).Put("choco", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis307, int _argc300, V t_306, V _a303, V _a304, V _a305, V[] _rest301) => {
return Call(sp_15, V.Undef, t_306, NewObj(3).Put("melt", ((V)(0.5))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "s", true)).V).Put("scoop", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("chb", ((V)(1D))).V).Put("b", NewObj(1).Put("chb", ((V)(0D))).V).V).Put("s", Fn((V _arrowThis315, int _argc308, V t_314, V _a311, V _a312, V _a313, V[] _rest309) => {
Invoke(Invoke(t_314, "osc", ((V)(1500D)), ((V)(3D)), NewObj(1).Put("chb", ((V)(0.9))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_314);
return default;
}, 1, "s", true)).V).Put("boba", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(1).Put("a", NewObj(1).Put("slurp", ((V)(0.5))).V).V).Put("s", Fn((V _arrowThis323, int _argc316, V t_322, V _a319, V _a320, V _a321, V[] _rest317) => {
Invoke(Invoke(t_322, "osc", ((V)(1600D)), ((V)(3D)), NewObj(2).Put("slurp", ((V)(0.6))).Put("sqz", ((V)(0.4))).V, NewObj(2).Put("slurp", ((V)(0D))).Put("sqz", ((V)(0D))).V, ((V)("s"))), "fx", ((V)("bubble")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_322);
return default;
}, 1, "s", true)).V).Put("chefbun", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis331, int _argc324, V t_330, V _a327, V _a328, V _a329, V[] _rest325) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_330, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-13D)))), NewObj(1).Put("armR", ((V)(34D))).V)), "wait", ((V)(300D))), "to", ((V)(260D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-14D)))), NewObj(2).Put("armR", ((V)(60D))).Put("smile", ((V)(1D))).V), ((V)("o"))), "fx", ((V)("heart")), ((V)("head"))), "wait", ((V)(500D)));
Call(bk_16, V.Undef, t_330, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("pip", NewObj(3).Put("sw", ((V)("glide"))).Put("k", NewObj(2).Put("a", NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(20D))).V).Put("b", NewObj(2).Put("armL", ((V)(20D))).Put("armR", ((V)(60D))).V).V).Put("s", Fn((V _arrowThis339, int _argc332, V t_338, V _a335, V _a336, V _a337, V[] _rest333) => {
Invoke(t_338, "osc", ((V)(1400D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, NewObj(2).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("o")));
Call(spray_19, V.Undef, t_338, ((V)("body")), ((V)(8D)));
Call(bk_16, V.Undef, t_338);
return default;
}, 1, "s", true)).V).Put("jelli", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _arrowThis347, int _argc340, V t_346, V _a343, V _a344, V _a345, V[] _rest341) => {
{
double i_348 = 0;
i_348 = 0D;
while (true) {
if (!((i_348 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(t_346, "to", ((V)(400D)), NewObj(1).Put("sq", Add(Get(Get(t_346, "B"), "sq"), ((V)(0.1)))).V, ((V)("i"))), "to", ((V)(500D)), NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_346, "B"), "sq")) - 0.05)))).Put("lift", Add(Get(Get(t_346, "B"), "lift"), ((V)(1.4)))).V, ((V)("o"))), "fx", ((V)("bubble")), ((V)("body")), ((V)(2D))), "to", ((V)(500D)), NewObj(2).Put("sq", Get(Get(t_346, "B"), "sq")).Put("lift", Get(Get(t_346, "B"), "lift")).V, ((V)("s")));
i_348++;
}
}
Call(bk_16, V.Undef, t_346, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("finn", NewObj(4).Put("sw", ((V)("glide"))).Put("k", Call(W_17, V.Undef, ((V)(26D)))).Put("s", Fn((V _arrowThis357, int _argc350, V t_356, V _a353, V _a354, V _a355, V[] _rest351) => {
Invoke(t_356, "osc", ((V)(1600D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("s")));
Call(spray_19, V.Undef, t_356, ((V)("tail")), ((V)(8D)));
Call(bk_16, V.Undef, t_356);
return default;
}, 1, "s", true)).Put("ws", Fn((V _arrowThis365, int _argc358, V t_364, V _a361, V _a362, V _a363, V[] _rest359) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_364, "to", ((V)(300D)), NewObj(1).Put("puff", ((V)(0.6))).V), "to", ((V)(160D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gush")), ((V)("blow")), ((V)(5D))), "fx", ((V)("splash")), ((V)("blow")), ((V)(6D))), "wait", ((V)(400D))), "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.6))).V);
Call(bk_16, V.Undef, t_364);
return default;
}, 1, "ws", true)).V).Put("sealy", NewObj(2).Put("sw", ((V)("glide"))).Put("s", Fn((V _arrowThis373, int _argc366, V t_372, V _a369, V _a370, V _a371, V[] _rest367) => {
Invoke(Invoke(t_372, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.4))).V, NewObj(1).Put("open", ((V)(0.05))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(4).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, NewObj(4).Put("hLx", ((V)(7D))).Put("hRx", ((V)((-7D)))).Put("armL", ((V)(14D))).Put("armR", ((V)(14D))).V, ((V)("o")));
Call(spray_19, V.Undef, t_372, ((V)("body")), ((V)(6D)));
Call(bk_16, V.Undef, t_372, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("puff", NewObj(3).Put("sw", ((V)("glide"))).Put("k", NewObj(1).Put("f", NewObj(1).Put("blo", ((V)(0.4))).V).V).Put("s", Fn((V _arrowThis381, int _argc374, V t_380, V _a377, V _a378, V _a379, V[] _rest375) => {
Invoke(Invoke(Invoke(Invoke(t_380, "to", ((V)(900D)), NewObj(3).Put("blo", ((V)(0.9))).Put("puff", ((V)(0.8))).Put("lift", Add(Get(Get(t_380, "B"), "lift"), ((V)(2D)))).V, ((V)("s"))), "wait", ((V)(700D))), "to", ((V)(500D)), NewObj(2).Put("blo", ((V)(0D))).Put("puff", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("bubble")), ((V)("mouth")), ((V)(4D)));
Call(bk_16, V.Undef, t_380);
return default;
}, 1, "s", true)).V).Put("shelly", NewObj(2).Put("sw", ((V)("glide"))).Put("s", Fn((V _arrowThis389, int _argc382, V t_388, V _a385, V _a386, V _a387, V[] _rest383) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_388, "to", ((V)(600D)), NewObj(1).Put("hid", ((V)(0.8))).V, ((V)("io"))), "fx", ((V)("bubble")), ((V)("head")), ((V)(2D))), "wait", ((V)(1400D))), "to", ((V)(400D)), NewObj(2).Put("hid", ((V)(0D))).Put("nk", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(500D)));
Call(bk_16, V.Undef, t_388);
return default;
}, 1, "s", true)).V).Put("octo", NewObj(4).Put("sw", ((V)("glide"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("osp", ((V)(1D))).V).Put("b", NewObj(1).Put("osp", ((V)(0.3))).V).V).Put("s", Fn((V _arrowThis397, int _argc390, V t_396, V _a393, V _a394, V _a395, V[] _rest391) => {
return Call(sp_15, V.Undef, t_396, NewObj(3).Put("ow", ((V)(1D))).Put("osp", ((V)(0.8))).Put("hap", ((V)(1D))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "s", true)).Put("ws", Fn((V _arrowThis405, int _argc398, V t_404, V _a401, V _a402, V _a403, V[] _rest399) => {
Invoke(Invoke(Invoke(Invoke(t_404, "to", ((V)(300D)), NewObj(2).Put("ojt", ((V)(1D))).Put("sq", ((V)((ToNum(Get(Get(t_404, "B"), "sq")) - 0.12)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("ink", ((V)(1D))).V, ((V)("l"))), "fx", ((V)("bubble")), ((V)("body")), ((V)(3D))), "to", ((V)(400D)), NewObj(3).Put("ojt", ((V)(0D))).Put("ink", ((V)(0D))).Put("sq", Get(Get(t_404, "B"), "sq")).V);
Call(bk_16, V.Undef, t_404);
return default;
}, 1, "ws", true)).V).Put("marina", NewObj(3).Put("sw", ((V)("glide"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("tsw", ((V)(0.8))).V).Put("b", NewObj(1).Put("tsw", ((V)((-0.8)))).V).V).Put("s", Fn((V _arrowThis413, int _argc406, V t_412, V _a409, V _a410, V _a411, V[] _rest407) => {
Invoke(Invoke(Invoke(Invoke(t_412, "to", ((V)(500D)), NewObj(1).Put("tlf", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)(0.6))).V, NewObj(1).Put("tsw", ((V)((-0.6)))).V, ((V)("s"))), "fx", ((V)("splash")), ((V)("tail")), ((V)(7D))), "to", ((V)(500D)), NewObj(2).Put("tlf", ((V)(0D))).Put("tsw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_412);
return default;
}, 1, "s", true)).V).Put("pearl", NewObj(3).Put("sw", ((V)("glide"))).Put("s", Fn((V _arrowThis421, int _argc414, V t_420, V _a417, V _a418, V _a419, V[] _rest415) => {
Call(sp_15, V.Undef, t_420, NewObj(2).Put("glow", ((V)(1D))).Put("hsw", ((V)(0.6))).V, ((V)(1600D)), ((V)(1200D)));
Invoke(t_420, "fx", ((V)("spark")), ((V)("head")), ((V)(4D)));
return default;
}, 1, "s", true)).Put("ws", Fn((V _arrowThis429, int _argc422, V t_428, V _a425, V _a426, V _a427, V[] _rest423) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_428, "to", ((V)(300D)), NewObj(1).Put("puff", ((V)(0.6))).V), "to", ((V)(160D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("gush")), ((V)("head")), ((V)(4D))), "fx", ((V)("splash")), ((V)("head")), ((V)(6D))), "to", ((V)(400D)), NewObj(1).Put("glow", ((V)(1D))).V), "wait", ((V)(400D))), "to", ((V)(400D)), NewObj(1).Put("glow", ((V)(0D))).V);
Call(bk_16, V.Undef, t_428);
return default;
}, 1, "ws", true)).V).Put("pina", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("crw", ((V)(1D))).V).Put("b", NewObj(1).Put("crw", ((V)(0.3))).V).V).Put("s", Fn((V _arrowThis437, int _argc430, V t_436, V _a433, V _a434, V _a435, V[] _rest431) => {
Invoke(Invoke(Invoke(t_436, "to", ((V)(300D)), NewObj(1).Put("crw", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("crs", ((V)(0.4))).V, NewObj(1).Put("crs", ((V)(0D))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(1).Put("crw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_436);
return default;
}, 1, "s", true)).V).Put("avo", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis445, int _argc438, V t_444, V _a441, V _a442, V _a443, V[] _rest439) => {
Invoke(Invoke(Invoke(Invoke(t_444, "to", ((V)(300D)), NewObj(1).Put("prw", ((V)(0.9))).V), "wait", ((V)(1000D))), "to", ((V)(400D)), NewObj(1).Put("prw", ((V)(0D))).V), "fx", ((V)("bubble")), ((V)("belly")), ((V)(2D)));
Call(bk_16, V.Undef, t_444);
return default;
}, 1, "s", true)).V).Put("berri", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("stw", ((V)(1D))).V).Put("b", NewObj(1).Put("stw", ((V)(0D))).V).V).Put("s", Fn((V _arrowThis453, int _argc446, V t_452, V _a449, V _a450, V _a451, V[] _rest447) => {
Invoke(Invoke(Invoke(t_452, "to", ((V)(120D)), NewObj(1).Put("stw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(900D)), NewObj(1).Put("stw", ((V)(0D))).V), "fx", ((V)("juice")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_452);
return default;
}, 1, "s", true)).V).Put("lemmy", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis461, int _argc454, V t_460, V _a457, V _a458, V _a459, V[] _rest455) => {
return Call(sp_15, V.Undef, t_460, NewObj(3).Put("sqz", ((V)(0.9))).Put("mw", ((V)(0.5))).Put("frown", ((V)(0.2))).V, ((V)(1000D)), ((V)(900D)));
}, 1, "s", true)).V).Put("kiwi", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(3).Put("a", NewObj(1).Put("fzz", ((V)(1D))).V).Put("b", NewObj(1).Put("fzz", ((V)(0.6))).V).Put("f", NewObj(1).Put("fzz", ((V)(1D))).V).V).Put("s", Fn((V _arrowThis469, int _argc462, V t_468, V _a465, V _a466, V _a467, V[] _rest463) => {
return Call(sp_15, V.Undef, t_468, NewObj(2).Put("fzz", ((V)(0.8))).Put("sqz", ((V)(0.5))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "s", true)).V).Put("melo", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("sdj", ((V)(1D))).V).Put("b", NewObj(1).Put("sdj", ((V)(0D))).V).V).Put("s", Fn((V _arrowThis477, int _argc470, V t_476, V _a473, V _a474, V _a475, V[] _rest471) => {
Invoke(Invoke(t_476, "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("sdj", ((V)(1D))).V, NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("meloseed")), ((V)("mouth")), ((V)(2D)));
Call(bk_16, V.Undef, t_476);
return default;
}, 1, "s", true)).V).Put("peachy", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis485, int _argc478, V t_484, V _a481, V _a482, V _a483, V[] _rest479) => {
return Call(sp_15, V.Undef, t_484, NewObj(3).Put("blush", ((V)(1D))).Put("lfl", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("pitaya", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("wfl", ((V)(1D))).V).Put("b", NewObj(1).Put("wfl", ((V)(0.4))).V).V).Put("s", Fn((V _arrowThis493, int _argc486, V t_492, V _a489, V _a490, V _a491, V[] _rest487) => {
Call(sp_15, V.Undef, t_492, NewObj(3).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.6))).Put("brf", ((V)(0.5))).V, ((V)(1400D)), ((V)(1000D)));
Call(spray_19, V.Undef, t_492, ((V)("body")), ((V)(5D)));
return default;
}, 1, "s", true)).V).Put("tutti", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(1).Put("a", NewObj(1).Put("wfl", ((V)(1D))).V).V).Put("s", Fn((V _arrowThis501, int _argc494, V t_500, V _a497, V _a498, V _a499, V[] _rest495) => {
Call(sp_15, V.Undef, t_500, NewObj(1).Put("wfl", ((V)(0.8))).V, ((V)(1400D)), ((V)(1000D)));
Invoke(t_500, "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("kiko", NewObj(1).Put("s", Fn((V _arrowThis509, int _argc502, V t_508, V _a505, V _a506, V _a507, V[] _rest503) => {
Invoke(Call(ears_18, V.Undef, t_508, ((V)(2D))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_508);
return default;
}, 1, "s", true)).V).Put("teddy", NewObj(1).Put("s", Fn((V _arrowThis517, int _argc510, V t_516, V _a513, V _a514, V _a515, V[] _rest511) => {
Invoke(Invoke(t_516, "to", ((V)(500D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(14D)), ((V)((-4D)))), NewObj(4).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("smile", ((V)(1D))).Put("blush", ((V)(0.5))).V)), "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("tongue", ((V)(0.4))).V, NewObj(1).Put("tongue", ((V)(0D))).V, ((V)("s")));
Call(bk_16, V.Undef, t_516, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("hoot", NewObj(2).Put("k", NewObj(3).Put("a", NewObj(2).Put("tfl", ((V)(1D))).Put("wfl", ((V)(1D))).V).Put("b", NewObj(1).Put("tfl", ((V)(0.4))).V).Put("f", NewObj(1).Put("tfl", ((V)(1D))).V).V).Put("s", Fn((V _arrowThis525, int _argc518, V t_524, V _a521, V _a522, V _a523, V[] _rest519) => {
Invoke(Invoke(t_524, "to", ((V)(300D)), NewObj(3).Put("wfl", ((V)(1D))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).V, NewObj(2).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("l")));
Call(spray_19, V.Undef, t_524, ((V)("sideL")), ((V)(5D)));
Call(spray_19, V.Undef, t_524, ((V)("sideR")), ((V)(5D)));
Call(bk_16, V.Undef, t_524);
return default;
}, 1, "s", true)).V).Put("leo", NewObj(2).Put("k", NewObj(3).Put("a", NewObj(2).Put("msh", ((V)(1D))).Put("mfl", ((V)(1D))).V).Put("b", NewObj(1).Put("msh", ((V)(0.4))).V).Put("f", NewObj(1).Put("mfl", ((V)(1D))).V).V).Put("s", Fn((V _arrowThis533, int _argc526, V t_532, V _a529, V _a530, V _a531, V[] _rest527) => {
Invoke(Invoke(Invoke(t_532, "to", ((V)(400D)), NewObj(3).Put("mfl", ((V)(0.8))).Put("open", ((V)(0.4))).Put("puff", ((V)(0.3))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(3).Put("mfl", ((V)(0D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).V);
Call(bk_16, V.Undef, t_532);
return default;
}, 1, "s", true)).V).Put("panko", NewObj(1).Put("s", Fn((V _arrowThis541, int _argc534, V t_540, V _a537, V _a538, V _a539, V[] _rest535) => {
Invoke(Invoke(t_540, "to", ((V)(500D)), NewObj(2).Put("sk", Add(Get(Get(t_540, "B"), "sk"), ((V)(3D)))).Put("close", ((V)(0.9))).V, ((V)("s"))), "osc", ((V)(1800D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("x", ((V)(1D))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("x", ((V)((-1D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_540);
return default;
}, 1, "s", true)).V).Put("acorn", NewObj(2).Put("k", NewObj(3).Put("a", NewObj(1).Put("tfl", ((V)(1D))).V).Put("b", NewObj(1).Put("tfl", ((V)(0.5))).V).Put("f", NewObj(1).Put("tfl", ((V)(1D))).V).V).Put("s", Fn((V _arrowThis549, int _argc542, V t_548, V _a545, V _a546, V _a547, V[] _rest543) => {
return Call(sp_15, V.Undef, t_548, NewObj(2).Put("tfl", ((V)(1D))).Put("tsw", ((V)(0.6))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "s", true)).V).Put("fawn", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(2).Put("earL", ((V)((-18D)))).Put("earR", ((V)(18D))).V).Put("b", NewObj(2).Put("earL", ((V)(18D))).Put("earR", ((V)((-18D)))).V).V).Put("s", Fn((V _arrowThis557, int _argc550, V t_556, V _a553, V _a554, V _a555, V[] _rest551) => {
Call(ears_18, V.Undef, t_556, ((V)(3D)));
Call(bk_16, V.Undef, t_556);
return default;
}, 1, "s", true)).V).Put("moss", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("cb", ((V)(1D))).V).Put("b", NewObj(1).Put("cb", ((V)(0D))).V).V).Put("s", Fn((V _arrowThis565, int _argc558, V t_564, V _a561, V _a562, V _a563, V[] _rest559) => {
Invoke(Invoke(t_564, "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("cb", ((V)(0.9))).V, NewObj(1).Put("cb", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("spore")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_564);
return default;
}, 1, "s", true)).V).Put("sprout", NewObj(2).Put("k", NewObj(1).Put("f", NewObj(1).Put("blm", ((V)(1D))).V).V).Put("s", Fn((V _arrowThis573, int _argc566, V t_572, V _a569, V _a570, V _a571, V[] _rest567) => {
return Call(sp_15, V.Undef, t_572, NewObj(2).Put("blm", ((V)(1D))).Put("lfl", ((V)(0.6))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "s", true)).V).Put("hana", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(2).Put("flL", ((V)(0.6))).Put("tw", ((V)(1D))).V).Put("b", NewObj(2).Put("flR", ((V)(0.6))).Put("tw", ((V)((-1D)))).V).V).Put("s", Fn((V _arrowThis581, int _argc574, V t_580, V _a577, V _a578, V _a579, V[] _rest575) => {
Invoke(Invoke(Invoke(t_580, "to", ((V)(400D)), NewObj(2).Put("flL", ((V)(0.9))).Put("flR", ((V)(0.9))).V), "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("tw", ((V)(1D))).V, NewObj(1).Put("tw", ((V)((-1D)))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(2).Put("flL", ((V)(0D))).Put("flR", ((V)(0D))).V);
Call(bk_16, V.Undef, t_580);
return default;
}, 1, "s", true)).V).Put("boo", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _arrowThis589, int _argc582, V t_588, V _a585, V _a586, V _a587, V[] _rest583) => {
return Call(sp_15, V.Undef, t_588, NewObj(2).Put("gho", ((V)(0.5))).Put("flr", ((V)(0.6))).V, ((V)(1800D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("pixie", NewObj(3).Put("sw", ((V)("float"))).Put("k", NewObj(1).Put("a", NewObj(1).Put("wfl", ((V)(1D))).V).V).Put("s", Fn((V _arrowThis597, int _argc590, V t_596, V _a593, V _a594, V _a595, V[] _rest591) => {
Call(sp_15, V.Undef, t_596, NewObj(3).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.5))).Put("lift", Add(Get(Get(t_596, "B"), "lift"), ((V)(2D)))).V, ((V)(1400D)), ((V)(1000D)));
Invoke(t_596, "fx", ((V)("dust")), ((V)("body")), ((V)(4D)));
return default;
}, 1, "s", true)).V).Put("floof", NewObj(2).Put("k", NewObj(3).Put("a", NewObj(1).Put("fzz", ((V)(1D))).V).Put("b", NewObj(1).Put("fzz", ((V)(0.7))).V).Put("f", NewObj(1).Put("fzz", ((V)(1D))).V).V).Put("s", Fn((V _arrowThis605, int _argc598, V t_604, V _a601, V _a602, V _a603, V[] _rest599) => {
Invoke(Invoke(Invoke(t_604, "to", ((V)(200D)), NewObj(1).Put("fzz", ((V)(0.9))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(1).Put("fzz", ((V)(0D))).V);
Call(bk_16, V.Undef, t_604);
return default;
}, 1, "s", true)).V).Put("unibun", NewObj(1).Put("s", Fn((V _arrowThis613, int _argc606, V t_612, V _a609, V _a610, V _a611, V[] _rest607) => {
Invoke(t_612, "fx", ((V)("spark")), ((V)("head")), ((V)(5D)));
Call(ears_18, V.Undef, t_612, ((V)(2D)));
Call(bk_16, V.Undef, t_612);
return default;
}, 1, "s", true)).V).Put("gumdrop", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("jig", ((V)(1D))).V).Put("b", NewObj(1).Put("jig", ((V)(0.4))).V).V).Put("s", Fn((V _arrowThis621, int _argc614, V t_620, V _a617, V _a618, V _a619, V[] _rest615) => {
return Call(sp_15, V.Undef, t_620, NewObj(2).Put("jig", ((V)(1D))).Put("hap", ((V)(1D))).V, ((V)(1200D)), ((V)(1000D)));
}, 1, "s", true)).V).Put("ember", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(1).Put("cfl", ((V)(0.6))).V).Put("f", NewObj(1).Put("cfl", ((V)(1D))).V).V).Put("s", Fn((V _arrowThis629, int _argc622, V t_628, V _a625, V _a626, V _a627, V[] _rest623) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_628, "to", ((V)(300D)), NewObj(3).Put("cfl", ((V)(0D))).Put("wide", ((V)(0.8))).Put("open", ((V)(0.3))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("head"))), "fx", ((V)("steam")), ((V)("body"))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(3).Put("cfl", ((V)(0.8))).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).V), "fx", ((V)("steam")), ((V)("head")));
Call(bk_16, V.Undef, t_628);
return default;
}, 1, "s", true)).V).Put("drako", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(2).Put("wsp", ((V)(1D))).Put("tsw", ((V)(0.8))).V).Put("b", NewObj(1).Put("tsw", ((V)((-0.8)))).V).V).Put("s", Fn((V _arrowThis637, int _argc630, V t_636, V _a633, V _a634, V _a635, V[] _rest631) => {
Invoke(Invoke(Invoke(Invoke(t_636, "to", ((V)(400D)), NewObj(1).Put("puff", ((V)(0.6))).V), "to", ((V)(200D)), NewObj(1).Put("puff", ((V)(0D))).V), "fx", ((V)("steam")), ((V)("head"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)(0.7))).V, NewObj(1).Put("tsw", ((V)((-0.7)))).V, ((V)("s")));
Call(spray_19, V.Undef, t_636, ((V)("tail")), ((V)(6D)));
Call(bk_16, V.Undef, t_636);
return default;
}, 1, "s", true)).V).Put("jinni", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _arrowThis645, int _argc638, V t_644, V _a641, V _a642, V _a643, V[] _rest639) => {
Call(sp_15, V.Undef, t_644, NewObj(2).Put("glo", ((V)(0.8))).Put("gwh", ((V)(0.6))).V, ((V)(1600D)), ((V)(1200D)));
Invoke(t_644, "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("cuppy", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis653, int _argc646, V t_652, V _a649, V _a650, V _a651, V[] _rest647) => {
Invoke(Invoke(t_652, "fx", ((V)("sprinkle")), ((V)("head"))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_652, "B"), "sq"), ((V)(0.05)))).V, NewObj(1).Put("sq", Get(Get(t_652, "B"), "sq")).V, ((V)("o")));
Call(bk_16, V.Undef, t_652);
return default;
}, 1, "s", true)).V).Put("chip", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis661, int _argc654, V t_660, V _a657, V _a658, V _a659, V[] _rest655) => {
Invoke(Invoke(t_660, "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.5))).V, NewObj(1).Put("x", ((V)((-0.5)))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_660, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("twisty", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis669, int _argc662, V t_668, V _a665, V _a666, V _a667, V[] _rest663) => {
Invoke(Invoke(t_668, "osc", ((V)(2000D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(5D))).V, NewObj(1).Put("tilt", ((V)((-5D)))).V, ((V)("s"))), "fx", ((V)("salt")), ((V)("head")));
Call(bk_16, V.Undef, t_668);
return default;
}, 1, "s", true)).V).Put("crois", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis677, int _argc670, V t_676, V _a673, V _a674, V _a675, V[] _rest671) => {
return Call(sp_15, V.Undef, t_676, NewObj(3).Put("lean", ((V)(1.4))).Put("tilt", ((V)(3D))).Put("smile", ((V)(1D))).V, ((V)(1800D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("maca", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis685, int _argc678, V t_684, V _a681, V _a682, V _a683, V[] _rest679) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_684, "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_684, "B"), "sq"), ((V)(0.1)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_684, "B"), "sq")).V), "wait", ((V)(300D))), "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_684, "B"), "sq"), ((V)(0.08)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_684, "B"), "sq")).V);
Call(bk_16, V.Undef, t_684, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("puddi", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis693, int _argc686, V t_692, V _a689, V _a690, V _a691, V[] _rest687) => {
Invoke(t_692, "osc", ((V)(1600D)), ((V)(6D)), NewObj(2).Put("sq", Add(Get(Get(t_692, "B"), "sq"), ((V)(0.06)))).Put("x", ((V)(0.3))).V, NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_692, "B"), "sq")) - 0.02)))).Put("x", ((V)((-0.3)))).V, ((V)("l")));
Call(bk_16, V.Undef, t_692);
return default;
}, 1, "s", true)).V).Put("mochi", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis701, int _argc694, V t_700, V _a697, V _a698, V _a699, V[] _rest695) => {
return Call(sp_15, V.Undef, t_700, NewObj(3).Put("sq", Add(Get(Get(t_700, "B"), "sq"), ((V)(0.16)))).Put("smile", ((V)(1D))).Put("close", ((V)(0.6))).V, ((V)(1800D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("cakey", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis709, int _argc702, V t_708, V _a705, V _a706, V _a707, V[] _rest703) => {
Invoke(Invoke(Invoke(Invoke(t_708, "to", ((V)(500D)), NewObj(1).Put("puff", ((V)(0.7))).V), "to", ((V)(600D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(300D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V);
Call(bk_16, V.Undef, t_708);
return default;
}, 1, "s", true)).V).Put("sugarplum", NewObj(1).Put("s", Fn((V _arrowThis717, int _argc710, V t_716, V _a713, V _a714, V _a715, V[] _rest711) => {
Invoke(Invoke(Invoke(t_716, "to", ((V)(400D)), NewObj(3).Put("armR", ((V)(70D))).Put("hRy", ((V)((-2D)))).Put("smile", ((V)(0.9))).V, ((V)("o"))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-3D)))).V, NewObj(1).Put("hRx", ((V)(3D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_716, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("gourdy", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis725, int _argc718, V t_724, V _a721, V _a722, V _a723, V[] _rest719) => {
Invoke(t_724, "osc", ((V)(2400D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(6D))).Put("x", ((V)(1D))).V, NewObj(2).Put("tilt", ((V)((-6D)))).Put("x", ((V)((-1D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_724);
return default;
}, 1, "s", true)).V).Put("batty", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(2).Put("armL", ((V)(80D))).Put("armR", ((V)(40D))).V).Put("b", NewObj(2).Put("armL", ((V)(40D))).Put("armR", ((V)(80D))).V).V).Put("s", Fn((V _arrowThis733, int _argc726, V t_732, V _a729, V _a730, V _a731, V[] _rest727) => {
return Call(sp_15, V.Undef, t_732, NewObj(4).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).Put("hLx", ((V)(12D))).Put("hRx", ((V)((-12D)))).V, ((V)(1200D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("kernel", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _arrowThis741, int _argc734, V t_740, V _a737, V _a738, V _a739, V[] _rest735) => {
Invoke(Invoke(Invoke(t_740, "to", ((V)(120D)), NewObj(2).Put("lift", Add(Get(Get(t_740, "B"), "lift"), ((V)(3D)))).Put("sq", ((V)((ToNum(Get(Get(t_740, "B"), "sq")) - 0.06)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("lift", Get(Get(t_740, "B"), "lift")).Put("sq", Add(Get(Get(t_740, "B"), "sq"), ((V)(0.04)))).V, ((V)("i"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(spray_19, V.Undef, t_740, ((V)("body")), ((V)(5D)));
Call(bk_16, V.Undef, t_740);
return default;
}, 1, "s", true)).V).Put("hexie", NewObj(1).Put("s", Fn((V _arrowThis749, int _argc742, V t_748, V _a745, V _a746, V _a747, V[] _rest743) => {
Call(sp_15, V.Undef, t_748, NewObj(1).Put("curl", ((V)(0.7))).V, ((V)(1400D)), ((V)(1200D)));
Invoke(t_748, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("mumbles", NewObj(1).Put("s", Fn((V _arrowThis757, int _argc750, V t_756, V _a753, V _a754, V _a755, V[] _rest751) => {
Invoke(Invoke(Invoke(t_756, "to", ((V)(900D)), NewObj(5).Put("armL", ((V)(88D))).Put("armR", ((V)(88D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("open", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(1000D))), "to", ((V)(900D)), NewObj(5).Put("armL", Get(Get(t_756, "B"), "armL")).Put("armR", Get(Get(t_756, "B"), "armR")).Put("hLy", Get(Get(t_756, "B"), "hLy")).Put("hRy", Get(Get(t_756, "B"), "hRy")).Put("open", ((V)(0D))).V, ((V)("io")));
Call(bk_16, V.Undef, t_756, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("hocus", NewObj(1).Put("s", Fn((V _arrowThis765, int _argc758, V t_764, V _a761, V _a762, V _a763, V[] _rest759) => {
Invoke(Invoke(Invoke(t_764, "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(800D))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_764, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("countsquishula", NewObj(1).Put("s", Fn((V _arrowThis773, int _argc766, V t_772, V _a769, V _a770, V _a771, V[] _rest767) => {
Invoke(Invoke(Invoke(t_772, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)((-1D))), ((V)(10D)), ((V)((-14D)))), NewObj(3).Put("armL", ((V)(60D))).Put("close", ((V)(0.4))).Put("smile", ((V)(0.6))).V)), "wait", ((V)(1000D))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_772, ((V)(500D)));
return default;
}, 1, "s", true)).V).V;
Invoke(Object_keys(PROF_14), "forEach", Fn((V _arrowThis781, int _argc774, V k_780, V _a777, V _a778, V _a779, V[] _rest775) => {
return Call(waterBuild_10, V.Undef, k_780, (GetK(C_20, k_780) is var _t782 && Truthy(_t782) ? _t782 : NewObj(0).V));
}, 1, "", true));
return default;
}, 1, "", false));
        }
    }
}
