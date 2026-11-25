// house-play-c.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house_play_c_js
    {

        public static void Run()
        {
Set(G("window"), "HouseCreatures", (Get(G("window"), "HouseCreatures") is var _t1 && Truthy(_t1) ? _t1 : Arr()));
Invoke(Get(G("window"), "HouseCreatures"), "push", Fn((V _self2, int _argc3, V H_9, V _a6, V _a7, V _a8, V[] _rest4) => {
V playBuild_10 = default;
V hand_11 = default;
V both_12 = default;
V o_13 = default;
V PROF_14 = default;
V sp_15 = default;
V bk_16 = default;
V ears_17 = default;
V lick_18 = default;
V nib_19 = default;
V LAPS_20 = default;
V RND_21 = default;
V C_22 = default;
if (_self2.IsNullish) _self2 = GlobalV;
{ V _t23 = H_9;
if (_t23.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t23));
{ V _t24 = Get(_t23, "playBuild");
playBuild_10 = _t24; }
{ V _t25 = Get(_t23, "hand");
hand_11 = _t25; }
{ V _t26 = Get(_t23, "both");
both_12 = _t26; }
{ V _t27 = Get(_t23, "o");
o_13 = _t27; }
{ V _t28 = Get(_t23, "PROF");
PROF_14 = _t28; } }
sp_15 = Fn((V _arrowThis39, int _argc29, V t_35, V v_36, V d_37, V hold_38, V[] _rest30) => {
V b_40 = default;
b_40 = NewObj(0).V;
Invoke(Object_keys(v_36), "forEach", Fn((V _arrowThis48, int _argc41, V k_47, V _a44, V _a45, V _a46, V[] _rest42) => {
return SetK(b_40, k_47, (!GetK(Get(t_35, "B"), k_47).IsNullish ? GetK(Get(t_35, "B"), k_47) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_35, "to", ((V)((ToNum((d_37 is var _t51 && Truthy(_t51) ? _t51 : ((V)(700D)))) * 0.4))), v_36, ((V)("o"))), "wait", (hold_38 is var _t50 && Truthy(_t50) ? _t50 : ((V)(300D)))), "to", ((V)((ToNum((d_37 is var _t49 && Truthy(_t49) ? _t49 : ((V)(700D)))) * 0.6))), b_40, ((V)("io")));
return t_35;
return default;
}, 4, "", true);
bk_16 = Fn((V _arrowThis60, int _argc52, V t_58, V d_59, V _a56, V _a57, V[] _rest53) => {
return Invoke(t_58, "back", (d_59 is var _t61 && Truthy(_t61) ? _t61 : ((V)(420D))));
}, 2, "", true);
ears_17 = Fn((V _arrowThis70, int _argc62, V t_68, V n_69, V _a66, V _a67, V[] _rest63) => {
{
double i_71 = 0;
i_71 = 0D;
while (true) {
if (!(Lt(((V)(i_71)), (n_69 is var _t73 && Truthy(_t73) ? _t73 : ((V)(2D)))))) break;
Invoke(Invoke(t_68, "to", ((V)(110D)), NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)(14D))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(2).Put("earL", ((V)(10D))).Put("earR", ((V)((-10D)))).V);
i_71++;
}
}
return Invoke(t_68, "to", ((V)(140D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V);
return default;
}, 2, "", true);
lick_18 = Fn((V _arrowThis81, int _argc74, V t_80, V _a77, V _a78, V _a79, V[] _rest75) => {
Invoke(Invoke(Invoke(t_80, "to", ((V)(380D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-13D)))), NewObj(2).Put("armR", ((V)(34D))).Put("close", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(1300D)), ((V)(5D)), NewObj(1).Put("tongue", ((V)(0.6))).V, NewObj(1).Put("tongue", ((V)(0.1))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(1).Put("tongue", ((V)(0D))).V);
return Call(bk_16, V.Undef, t_80);
return default;
}, 1, "", true);
nib_19 = Fn((V _arrowThis89, int _argc82, V t_88, V _a85, V _a86, V _a87, V[] _rest83) => {
Invoke(Invoke(Invoke(Invoke(t_88, "to", ((V)(320D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-12D)))), NewObj(1).Put("armR", ((V)(32D))).V), ((V)("io"))), "to", ((V)(260D)), NewObj(1).Put("puff", ((V)(1D))).V), "osc", ((V)(900D)), ((V)(5D)), NewObj(1).Put("open", ((V)(0.2))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("mouth")));
return Call(bk_16, V.Undef, t_88);
return default;
}, 1, "", true);
LAPS_20 = NewObj(6).Put("armL", ((V)(64D))).Put("armR", ((V)(64D))).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).V;
RND_21 = Object_fromEntries(Invoke(Invoke(((V)("lumi plip mallow bao dunkie frybo bunbun choco scoop boba chefbun pina avo berri lemmy kiwi peachy melo pitaya tutti floof ember cuppy chip twisty crois maca puddi mochi cakey")), "split", ((V)(" "))), "map", Fn((V _arrowThis97, int _argc90, V k_96, V _a93, V _a94, V _a95, V[] _rest91) => {
return Arr(k_96, ((V)(1D)));
}, 1, "", true)));
C_22 = NewObj(80).Put("mittens", NewObj(3).Put("sn", ((V)("fish"))).Put("p", Fn((V _arrowThis105, int _argc98, V t_104, V _a101, V _a102, V _a103, V[] _rest99) => {
return Call(sp_15, V.Undef, t_104, NewObj(4).Put("curl", ((V)(0.9))).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).Put("k", lick_18).V).Put("biscuit", NewObj(3).Put("sn", ((V)("bone"))).Put("p", Fn((V _arrowThis113, int _argc106, V t_112, V _a109, V _a110, V _a111, V[] _rest107) => {
Invoke(Invoke(t_112, "to", ((V)(200D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("tongue", ((V)(0.5))).V), "osc", ((V)(1500D)), ((V)(8D)), NewObj(1).Put("wag", ((V)(28D))).V, NewObj(1).Put("wag", ((V)((-28D)))).V, ((V)("o")));
Call(bk_16, V.Undef, t_112);
return default;
}, 1, "p", true)).Put("k", Fn((V _arrowThis121, int _argc114, V t_120, V _a117, V _a118, V _a119, V[] _rest115) => {
Invoke(Invoke(Invoke(t_120, "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)((ToNum(Get(Get(t_120, "B"), "pitch")) - 0.16)))).Put("ly", ((V)(0.8))).Put("wide", ((V)(0.6))).V), "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("puff", ((V)(0.4))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("puff", ((V)(0D))).Put("htilt", ((V)((-3D)))).V, ((V)("l"))), "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("o")));
Call(bk_16, V.Undef, t_120);
return default;
}, 1, "k", true)).V).Put("prickle", NewObj(3).Put("sn", ((V)("berry"))).Put("p", Fn((V _arrowThis129, int _argc122, V t_128, V _a125, V _a126, V _a127, V[] _rest123) => {
return Call(sp_15, V.Undef, t_128, NewObj(3).Put("curl", ((V)(1D))).Put("sq", Add(Get(Get(t_128, "B"), "sq"), ((V)(0.12)))).Put("close", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).Put("k", Fn((V _arrowThis137, int _argc130, V t_136, V _a133, V _a134, V _a135, V[] _rest131) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_136, "to", ((V)(300D)), NewObj(2).Put("wide", ((V)(0.8))).Put("open", ((V)(0.3))).V), "fx", ((V)("steam")), ((V)("head"))), "to", ((V)(300D)), NewObj(3).Put("curl", ((V)(0.8))).Put("sq", Add(Get(Get(t_136, "B"), "sq"), ((V)(0.1)))).Put("close", ((V)(1D))).V), "wait", ((V)(500D))), "to", ((V)(200D)), NewObj(2).Put("curl", ((V)(0D))).Put("wide", ((V)(0.5))).V, ((V)("o")));
Call(bk_16, V.Undef, t_136);
return default;
}, 1, "k", true)).V).Put("truffle", NewObj(3).Put("sn", ((V)("apple"))).Put("p", Fn((V _arrowThis145, int _argc138, V t_144, V _a141, V _a142, V _a143, V[] _rest139) => {
return Call(sp_15, V.Undef, t_144, NewObj(4).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("wag", ((V)(20D))).V, ((V)(1300D)), ((V)(900D)));
}, 1, "p", true)).Put("k", nib_19).V).Put("ribbit", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _arrowThis153, int _argc146, V t_152, V _a149, V _a150, V _a151, V[] _rest147) => {
{
double i_154 = 0;
i_154 = 0D;
while (true) {
if (!((i_154 < 2D))) break;
Invoke(Invoke(t_152, "to", ((V)(120D)), NewObj(4).Put("lift", Add((Get(Get(t_152, "B"), "lift") is var _t158 && Truthy(_t158) ? _t158 : ((V)(0D))), ((V)(3D)))).Put("sq", ((V)((ToNum((Get(Get(t_152, "B"), "sq") is var _t159 && Truthy(_t159) ? _t159 : ((V)(0D)))) - 0.06)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", (Get(Get(t_152, "B"), "lift") is var _t156 && Truthy(_t156) ? _t156 : ((V)(0D)))).Put("sq", Add((Get(Get(t_152, "B"), "sq") is var _t157 && Truthy(_t157) ? _t157 : ((V)(0D))), ((V)(0.04)))).V, ((V)("i")));
i_154++;
}
}
Call(bk_16, V.Undef, t_152);
return default;
}, 1, "p", true)).V).Put("nibbles", NewObj(3).Put("sn", ((V)("nut"))).Put("p", Fn((V _arrowThis167, int _argc160, V t_166, V _a163, V _a164, V _a165, V[] _rest161) => {
return Call(sp_15, V.Undef, t_166, NewObj(3).Put("puff", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "p", true)).Put("k", nib_19).V).Put("quill", NewObj(3).Put("sn", ((V)("berry"))).Put("p", Fn((V _arrowThis175, int _argc168, V t_174, V _a171, V _a172, V _a173, V[] _rest169) => {
return Call(sp_15, V.Undef, t_174, NewObj(4).Put("blush", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("htilt", ((V)(7D))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).Put("k", Fn((V _arrowThis183, int _argc176, V t_182, V _a179, V _a180, V _a181, V[] _rest177) => {
Call(sp_15, V.Undef, t_182, NewObj(4).Put("blush", ((V)(1D))).Put("close", ((V)(0.7))).Put("smile", ((V)(1D))).Put("htilt", ((V)((-6D)))).V, ((V)(1200D)), ((V)(800D)));
Invoke(t_182, "fx", ((V)("heart")), ((V)("head")));
return default;
}, 1, "k", true)).V).Put("poppy", NewObj(4).Put("sn", ((V)("carrot"))).Put("sy", NewObj(1).Put("ear", ((V)(22D))).V).Put("p", Fn((V _arrowThis191, int _argc184, V t_190, V _a187, V _a188, V _a189, V[] _rest185) => {
Invoke(t_190, "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("earL", ((V)((-18D)))).Put("earR", ((V)(16D))).V, NewObj(2).Put("earL", ((V)(16D))).Put("earR", ((V)((-18D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_190);
return default;
}, 1, "p", true)).Put("k", Fn((V _arrowThis199, int _argc192, V t_198, V _a195, V _a196, V _a197, V[] _rest193) => {
{
double i_200 = 0;
i_200 = 0D;
while (true) {
if (!((i_200 < 2D))) break;
Invoke(Invoke(t_198, "to", ((V)(120D)), NewObj(4).Put("lift", Add((Get(Get(t_198, "B"), "lift") is var _t204 && Truthy(_t204) ? _t204 : ((V)(0D))), ((V)(3D)))).Put("sq", ((V)((ToNum((Get(Get(t_198, "B"), "sq") is var _t205 && Truthy(_t205) ? _t205 : ((V)(0D)))) - 0.06)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", (Get(Get(t_198, "B"), "lift") is var _t202 && Truthy(_t202) ? _t202 : ((V)(0D)))).Put("sq", Add((Get(Get(t_198, "B"), "sq") is var _t203 && Truthy(_t203) ? _t203 : ((V)(0D))), ((V)(0.04)))).V, ((V)("i")));
i_200++;
}
}
Call(bk_16, V.Undef, t_198);
return default;
}, 1, "k", true)).V).Put("duchess", NewObj(3).Put("sn", ((V)("fish"))).Put("p", Fn((V _arrowThis213, int _argc206, V t_212, V _a209, V _a210, V _a211, V[] _rest207) => {
return Call(sp_15, V.Undef, t_212, NewObj(4).Put("htilt", ((V)(9D))).Put("close", ((V)(0.6))).Put("pitch", Add(Get(Get(t_212, "B"), "pitch"), ((V)(0.14)))).Put("smile", ((V)(0.6))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "p", true)).Put("k", Fn((V _arrowThis221, int _argc214, V t_220, V _a217, V _a218, V _a219, V[] _rest215) => {
Invoke(Invoke(Invoke(Invoke(t_220, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-13D)))), NewObj(2).Put("armR", ((V)(34D))).Put("close", ((V)(0.7))).V)), "wait", ((V)(600D))), "to", ((V)(260D)), NewObj(1).Put("sqz", ((V)(0.5))).V), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_220);
return default;
}, 1, "k", true)).V).Put("mamapaws", NewObj(2).Put("sn", ((V)("bone"))).Put("p", Fn((V _arrowThis229, int _argc222, V t_228, V _a225, V _a226, V _a227, V[] _rest223) => {
Call(sp_15, V.Undef, t_228, Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(12D)), ((V)(1D))), NewObj(4).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V), ((V)(1400D)), ((V)(1000D)));
Invoke(t_228, "fx", ((V)("heart")), ((V)("head")));
return default;
}, 1, "p", true)).V).Put("nimbo", NewObj(3).Put("sn", ((V)("candy"))).Put("p", Fn((V _arrowThis237, int _argc230, V t_236, V _a233, V _a234, V _a235, V[] _rest231) => {
Invoke(Invoke(Invoke(t_236, "fx", ((V)("drop")), ((V)("body")), ((V)(4D))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(2).Put("sq", Add(Get(Get(t_236, "B"), "sq"), ((V)(0.06)))).Put("puff", ((V)(0.4))).V, NewObj(2).Put("sq", Get(Get(t_236, "B"), "sq")).Put("puff", ((V)(0D))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_236);
return default;
}, 1, "p", true)).Put("k", Fn((V _arrowThis245, int _argc238, V t_244, V _a241, V _a242, V _a243, V[] _rest239) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_244, "fx", ((V)("drop")), ((V)("body")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("wide", ((V)(0.7))).Put("open", ((V)(0.3))).V), "fx", ((V)("steam")), ((V)("head"))), "wait", ((V)(400D))), "to", ((V)(260D)), NewObj(2).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).V);
Call(bk_16, V.Undef, t_244);
return default;
}, 1, "k", true)).V).Put("lumi", NewObj(2).Put("sn", ((V)("honey"))).Put("p", Fn((V _arrowThis253, int _argc246, V t_252, V _a249, V _a250, V _a251, V[] _rest247) => {
Invoke(Invoke(Invoke(t_252, "fx", ((V)("spark")), ((V)("head")), ((V)(4D))), "to", ((V)(400D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("ly", ((V)((-0.6)))).V), "wait", ((V)(600D)));
Call(bk_16, V.Undef, t_252);
return default;
}, 1, "p", true)).V).Put("bubbly", NewObj(3).Put("sn", ((V)("candy"))).Put("sp", LAPS_20).Put("p", Fn((V _arrowThis261, int _argc254, V t_260, V _a257, V _a258, V _a259, V[] _rest255) => {
{
double i_262 = 0;
i_262 = 0D;
while (true) {
if (!((i_262 < 2D))) break;
Invoke(Invoke(Invoke(t_260, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.6))).Put("sq", Add(Get(Get(t_260, "B"), "sq"), ((V)(0.05)))).V), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)((NumTruthy(i_262) ? "bigbubble" : "bubble"))), ((V)("mouth")), ((V)(2D)));
i_262++;
}
}
Call(bk_16, V.Undef, t_260);
return default;
}, 1, "p", true)).V).Put("twinkle", NewObj(3).Put("sn", ((V)("star"))).Put("sp", LAPS_20).Put("p", Fn((V _arrowThis271, int _argc264, V t_270, V _a267, V _a268, V _a269, V[] _rest265) => {
Call(sp_15, V.Undef, t_270, NewObj(3).Put("glow", ((V)(1D))).Put("wide", ((V)(0.6))).Put("hap", ((V)(1D))).V, ((V)(1200D)), ((V)(800D)));
Invoke(t_270, "fx", ((V)("spark")), ((V)("body")), ((V)(5D)));
return default;
}, 1, "p", true)).V).Put("zappi", NewObj(3).Put("sn", ((V)("bolt"))).Put("p", Fn((V _arrowThis279, int _argc272, V t_278, V _a275, V _a276, V _a277, V[] _rest273) => {
Invoke(Invoke(Invoke(Invoke(t_278, "to", ((V)(80D)), NewObj(2).Put("zap", ((V)(1D))).Put("wide", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(420D)), ((V)(4D)), NewObj(1).Put("x", ((V)((-0.5)))).V, NewObj(1).Put("x", ((V)(0.5))).V, ((V)("l"))), "fx", ((V)("spark")), ((V)("body")), ((V)(5D))), "to", ((V)(300D)), NewObj(2).Put("zap", ((V)(0D))).Put("x", ((V)(0D))).V);
Call(bk_16, V.Undef, t_278);
return default;
}, 1, "p", true)).Put("k", Fn((V _arrowThis287, int _argc280, V t_286, V _a283, V _a284, V _a285, V[] _rest281) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_286, "to", ((V)(80D)), NewObj(3).Put("zap", ((V)(1D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(5D))), "osc", ((V)(420D)), ((V)(4D)), NewObj(1).Put("x", ((V)((-0.5)))).V, NewObj(1).Put("x", ((V)(0.5))).V, ((V)("l"))), "fx", ((V)("steam")), ((V)("pawR"))), "to", ((V)(300D)), NewObj(3).Put("zap", ((V)(0D))).Put("x", ((V)(0D))).Put("sqz", ((V)(0.6))).V);
Call(bk_16, V.Undef, t_286);
return default;
}, 1, "k", true)).V).Put("plip", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _arrowThis295, int _argc288, V t_294, V _a291, V _a292, V _a293, V[] _rest289) => {
Invoke(Invoke(t_294, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_294, "B"), "sq"), ((V)(0.08)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_294, "B"), "sq")) - 0.03)))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_294);
return default;
}, 1, "p", true)).V).Put("breeze", NewObj(3).Put("sn", ((V)("apple"))).Put("p", Fn((V _arrowThis303, int _argc296, V t_302, V _a299, V _a300, V _a301, V[] _rest297) => {
Invoke(Invoke(Invoke(t_302, "to", ((V)(400D)), NewObj(1).Put("puff", ((V)(0.8))).V), "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.35))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head")));
Call(bk_16, V.Undef, t_302);
return default;
}, 1, "p", true)).Put("k", Fn((V _arrowThis311, int _argc304, V t_310, V _a307, V _a308, V _a309, V[] _rest305) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_310, "to", ((V)(380D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-12D)))), NewObj(1).Put("armR", ((V)(34D))).V), ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("puff", ((V)(0.9))).V), "to", ((V)(400D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth"))), "fx", ((V)("steam")), ((V)("pawR"))), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(2).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).V);
Call(bk_16, V.Undef, t_310);
return default;
}, 1, "k", true)).V).Put("dusty", NewObj(2).Put("sn", ((V)("flower"))).Put("p", Fn((V _arrowThis319, int _argc312, V t_318, V _a315, V _a316, V _a317, V[] _rest313) => {
Invoke(Call(ears_17, V.Undef, t_318, ((V)(3D))), "fx", ((V)("dust")), ((V)("body")), ((V)(4D)));
Call(bk_16, V.Undef, t_318);
return default;
}, 1, "p", true)).V).Put("aurora", NewObj(3).Put("sn", ((V)("fish"))).Put("sp", LAPS_20).Put("p", Fn((V _arrowThis327, int _argc320, V t_326, V _a323, V _a324, V _a325, V[] _rest321) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_326, "to", ((V)(300D)), NewObj(1).Put("spout", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("gush")), ((V)("head")), ((V)(3D))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(2).Put("spout", ((V)(0D))).Put("glow", ((V)(0.8))).V), "wait", ((V)(400D)));
Call(bk_16, V.Undef, t_326, ((V)(600D)));
return default;
}, 1, "p", true)).V).Put("mallow", NewObj(3).Put("sn", ((V)("candy"))).Put("p", Fn((V _arrowThis335, int _argc328, V t_334, V _a331, V _a332, V _a333, V[] _rest329) => {
return Call(sp_15, V.Undef, t_334, NewObj(3).Put("sq", Add(Get(Get(t_334, "B"), "sq"), ((V)(0.18)))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "p", true)).Put("k", Fn((V _arrowThis343, int _argc336, V t_342, V _a339, V _a340, V _a341, V[] _rest337) => {
Call(sp_15, V.Undef, t_342, NewObj(4).Put("sq", Add(Get(Get(t_342, "B"), "sq"), ((V)(0.14)))).Put("blush", ((V)(1D))).Put("smile", ((V)(1D))).Put("close", ((V)(0.6))).V, ((V)(1400D)), ((V)(900D)));
Invoke(t_342, "fx", ((V)("steam")), ((V)("head")));
return default;
}, 1, "k", true)).V).Put("bao", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _arrowThis351, int _argc344, V t_350, V _a347, V _a348, V _a349, V[] _rest345) => {
Invoke(Invoke(Invoke(t_350, "fx", ((V)("steam")), ((V)("head"))), "osc", ((V)(1200D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(Get(t_350, "B"), "sq"), ((V)(0.06)))).V, NewObj(1).Put("sq", Get(Get(t_350, "B"), "sq")).V, ((V)("s"))), "fx", ((V)("steam")), ((V)("head")));
Call(bk_16, V.Undef, t_350);
return default;
}, 1, "p", true)).V).Put("dunkie", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _arrowThis359, int _argc352, V t_358, V _a355, V _a356, V _a357, V[] _rest353) => {
Invoke(Invoke(t_358, "osc", ((V)(1600D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("turn", ((V)(0.3))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("turn", ((V)((-0.3)))).V, ((V)("s"))), "fx", ((V)("sprinkle")), ((V)("head")));
Call(bk_16, V.Undef, t_358);
return default;
}, 1, "p", true)).V).Put("frybo", NewObj(3).Put("sn", ((V)("ketchup"))).Put("p", Fn((V _arrowThis367, int _argc360, V t_366, V _a363, V _a364, V _a365, V[] _rest361) => {
Call(sp_15, V.Undef, t_366, NewObj(3).Put("fw", ((V)(1D))).Put("smile", ((V)(1D))).Put("hap", ((V)(1D))).V, ((V)(1200D)), ((V)(800D)));
Invoke(t_366, "fx", ((V)("salt")), ((V)("head")));
return default;
}, 1, "p", true)).Put("k", Fn((V _arrowThis375, int _argc368, V t_374, V _a371, V _a372, V _a373, V[] _rest369) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_374, "to", ((V)(300D)), NewObj(2).Put("fw", ((V)(0.8))).Put("hap", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(6D)), NewObj(1).Put("tilt", ((V)(3D))).V, NewObj(1).Put("tilt", ((V)((-3D)))).V, ((V)("l"))), "fx", ((V)("salt")), ((V)("head")), ((V)(4D))), "fx", ((V)("salt")), ((V)("pawR")), ((V)(3D))), "to", ((V)(300D)), NewObj(1).Put("fw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_374);
return default;
}, 1, "k", true)).V).Put("bunbun", NewObj(2).Put("sn", ((V)("cheese"))).Put("p", Fn((V _arrowThis383, int _argc376, V t_382, V _a379, V _a380, V _a381, V[] _rest377) => {
return Call(sp_15, V.Undef, t_382, NewObj(3).Put("split", ((V)(0.5))).Put("shuf", ((V)(0.3))).Put("hap", ((V)(1D))).V, ((V)(1300D)), ((V)(800D)));
}, 1, "p", true)).V).Put("choco", NewObj(3).Put("sn", ((V)("nut"))).Put("p", Fn((V _arrowThis391, int _argc384, V t_390, V _a387, V _a388, V _a389, V[] _rest385) => {
return Call(sp_15, V.Undef, t_390, NewObj(3).Put("melt", ((V)(0.5))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1500D)), ((V)(1000D)));
}, 1, "p", true)).Put("k", Fn((V _arrowThis399, int _argc392, V t_398, V _a395, V _a396, V _a397, V[] _rest393) => {
Call(sp_15, V.Undef, t_398, NewObj(3).Put("melt", ((V)(0.7))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.3))).V, ((V)(1400D)), ((V)(800D)));
Invoke(Invoke(t_398, "fx", ((V)("steam")), ((V)("head"))), "fx", ((V)("sweat")), ((V)("head")));
return default;
}, 1, "k", true)).V).Put("scoop", NewObj(3).Put("sn", ((V)("cherry"))).Put("p", Fn((V _arrowThis407, int _argc400, V t_406, V _a403, V _a404, V _a405, V[] _rest401) => {
Invoke(t_406, "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("chb", ((V)(0.9))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_406);
return default;
}, 1, "p", true)).Put("k", Fn((V _arrowThis415, int _argc408, V t_414, V _a411, V _a412, V _a413, V[] _rest409) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_414, "fx", ((V)("sweat")), ((V)("head"))), "to", ((V)(300D)), NewObj(3).Put("wide", ((V)(0.7))).Put("open", ((V)(0.3))).Put("frown", ((V)(0.3))).V), "fx", ((V)("drop")), ((V)("head")), ((V)(2D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(3).Put("chb", ((V)(0.9))).Put("frown", ((V)(0D))).Put("smile", ((V)(1D))).V), "to", ((V)(300D)), NewObj(1).Put("chb", ((V)(0D))).V);
Call(bk_16, V.Undef, t_414);
return default;
}, 1, "k", true)).V).Put("boba", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _arrowThis423, int _argc416, V t_422, V _a419, V _a420, V _a421, V[] _rest417) => {
Invoke(Invoke(t_422, "osc", ((V)(1400D)), ((V)(3D)), NewObj(2).Put("slurp", ((V)(0.6))).Put("sqz", ((V)(0.4))).V, NewObj(2).Put("slurp", ((V)(0D))).Put("sqz", ((V)(0D))).V, ((V)("s"))), "fx", ((V)("bubble")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_422);
return default;
}, 1, "p", true)).V).Put("chefbun", NewObj(4).Put("sn", ((V)("cake"))).Put("cOrd", Arr(((V)("stir")), ((V)("season")), ((V)("shake")), ((V)("flip")), ((V)("sig")), ((V)("flip")), ((V)("taste")), ((V)("kiss")))).Put("p", Fn((V _arrowThis431, int _argc424, V t_430, V _a427, V _a428, V _a429, V[] _rest425) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_430, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-13D)))), NewObj(1).Put("armR", ((V)(34D))).V)), "wait", ((V)(300D))), "to", ((V)(260D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-14D)))), NewObj(2).Put("armR", ((V)(60D))).Put("smile", ((V)(1D))).V), ((V)("o"))), "fx", ((V)("heart")), ((V)("head"))), "wait", ((V)(400D)));
Call(bk_16, V.Undef, t_430, ((V)(500D)));
return default;
}, 1, "p", true)).Put("k", Fn((V _arrowThis439, int _argc432, V t_438, V _a435, V _a436, V _a437, V[] _rest433) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_438, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)((-1D))), ((V)(8D)), ((V)((-16D)))), NewObj(3).Put("armL", ((V)(70D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(800D)), ((V)(2D)), NewObj(1).Put("htilt", ((V)(6D))).V, NewObj(1).Put("htilt", ((V)((-2D)))).V, ((V)("s"))), "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(7D)), ((V)((-14D)))), NewObj(2).Put("armR", ((V)(38D))).Put("puff", ((V)(0.3))).V)), "to", ((V)(200D)), NewObj(6).Put("armR", ((V)(120D))).Put("hRx", ((V)(4D))).Put("hRy", ((V)((-6D)))).Put("puff", ((V)(0D))).Put("sqz", ((V)(0.8))).Put("hap", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D))), "wait", ((V)(500D)));
Call(bk_16, V.Undef, t_438, ((V)(500D)));
return default;
}, 1, "k", true)).V).Put("pip", NewObj(2).Put("sn", ((V)("fish"))).Put("p", Fn((V _arrowThis447, int _argc440, V t_446, V _a443, V _a444, V _a445, V[] _rest441) => {
Invoke(t_446, "osc", ((V)(1200D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, NewObj(2).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_446);
return default;
}, 1, "p", true)).V).Put("jelli", NewObj(3).Put("sn", ((V)("candy"))).Put("sp", LAPS_20).Put("p", Fn((V _arrowThis455, int _argc448, V t_454, V _a451, V _a452, V _a453, V[] _rest449) => {
{
double i_456 = 0;
i_456 = 0D;
while (true) {
if (!((i_456 < 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_454, "to", ((V)(350D)), NewObj(1).Put("sq", Add(Get(Get(t_454, "B"), "sq"), ((V)(0.1)))).V, ((V)("i"))), "to", ((V)(450D)), NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_454, "B"), "sq")) - 0.05)))).Put("lift", Add(Get(Get(t_454, "B"), "lift"), ((V)(1.2)))).V, ((V)("o"))), "fx", ((V)("bubble")), ((V)("body")), ((V)(2D))), "to", ((V)(400D)), NewObj(2).Put("sq", Get(Get(t_454, "B"), "sq")).Put("lift", Get(Get(t_454, "B"), "lift")).V, ((V)("s")));
i_456++;
}
}
Call(bk_16, V.Undef, t_454, ((V)(300D)));
return default;
}, 1, "p", true)).V).Put("finn", NewObj(3).Put("sn", ((V)("fish"))).Put("sp", LAPS_20).Put("p", Fn((V _arrowThis465, int _argc458, V t_464, V _a461, V _a462, V _a463, V[] _rest459) => {
Invoke(Invoke(t_464, "osc", ((V)(1400D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("tail")), ((V)(3D)));
Call(bk_16, V.Undef, t_464);
return default;
}, 1, "p", true)).V).Put("sealy", NewObj(3).Put("sn", ((V)("fish"))).Put("sp", LAPS_20).Put("p", Fn((V _arrowThis473, int _argc466, V t_472, V _a469, V _a470, V _a471, V[] _rest467) => {
Invoke(Invoke(t_472, "osc", ((V)(800D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.4))).V, NewObj(1).Put("open", ((V)(0.05))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(4).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, NewObj(4).Put("hLx", ((V)(7D))).Put("hRx", ((V)((-7D)))).Put("armL", ((V)(14D))).Put("armR", ((V)(14D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_472, ((V)(500D)));
return default;
}, 1, "p", true)).V).Put("puff", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _arrowThis481, int _argc474, V t_480, V _a477, V _a478, V _a479, V[] _rest475) => {
Invoke(Invoke(Invoke(Invoke(t_480, "to", ((V)(700D)), NewObj(2).Put("blo", ((V)(0.8))).Put("puff", ((V)(0.8))).V, ((V)("s"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(2).Put("blo", ((V)(0D))).Put("puff", ((V)(0D))).V), "fx", ((V)("bubble")), ((V)("mouth")), ((V)(3D)));
Call(bk_16, V.Undef, t_480);
return default;
}, 1, "p", true)).V).Put("shelly", NewObj(3).Put("sn", ((V)("leaf"))).Put("sp", LAPS_20).Put("p", Fn((V _arrowThis489, int _argc482, V t_488, V _a485, V _a486, V _a487, V[] _rest483) => {
return Call(sp_15, V.Undef, t_488, NewObj(3).Put("nk", ((V)(1D))).Put("wide", ((V)(0.5))).Put("hap", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).V).Put("octo", NewObj(3).Put("sn", ((V)("fish"))).Put("p", Fn((V _arrowThis497, int _argc490, V t_496, V _a493, V _a494, V _a495, V[] _rest491) => {
return Call(sp_15, V.Undef, t_496, NewObj(3).Put("ow", ((V)(1D))).Put("osp", ((V)(0.8))).Put("hap", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).Put("k", Fn((V _arrowThis505, int _argc498, V t_504, V _a501, V _a502, V _a503, V[] _rest499) => {
Call(sp_15, V.Undef, t_504, NewObj(3).Put("ow", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1000D)));
Invoke(Invoke(t_504, "fx", ((V)("steam")), ((V)("pawR"))), "fx", ((V)("salt")), ((V)("pawL")), ((V)(3D)));
return default;
}, 1, "k", true)).V).Put("marina", NewObj(3).Put("sn", ((V)("shell"))).Put("sy", NewObj(1).Put("tsw", ((V)(0.5))).V).Put("p", Fn((V _arrowThis513, int _argc506, V t_512, V _a509, V _a510, V _a511, V[] _rest507) => {
Invoke(Invoke(Invoke(t_512, "to", ((V)(400D)), NewObj(1).Put("tlf", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)(0.6))).V, NewObj(1).Put("tsw", ((V)((-0.6)))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(2).Put("tlf", ((V)(0D))).Put("tsw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_512);
return default;
}, 1, "p", true)).V).Put("pearl", NewObj(2).Put("sn", ((V)("fish"))).Put("p", Fn((V _arrowThis521, int _argc514, V t_520, V _a517, V _a518, V _a519, V[] _rest515) => {
Call(sp_15, V.Undef, t_520, NewObj(2).Put("glow", ((V)(1D))).Put("hsw", ((V)(0.6))).V, ((V)(1400D)), ((V)(900D)));
Invoke(t_520, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "p", true)).V).Put("pina", NewObj(2).Put("sn", ((V)("cake"))).Put("p", Fn((V _arrowThis529, int _argc522, V t_528, V _a525, V _a526, V _a527, V[] _rest523) => {
Invoke(Invoke(Invoke(t_528, "to", ((V)(300D)), NewObj(1).Put("crw", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("crs", ((V)(0.4))).V, NewObj(1).Put("crs", ((V)(0D))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(1).Put("crw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_528);
return default;
}, 1, "p", true)).V).Put("avo", NewObj(2).Put("sn", ((V)("cookie"))).Put("p", Fn((V _arrowThis537, int _argc530, V t_536, V _a533, V _a534, V _a535, V[] _rest531) => {
Invoke(Invoke(Invoke(t_536, "to", ((V)(300D)), NewObj(1).Put("prw", ((V)(0.9))).V), "wait", ((V)(900D))), "to", ((V)(300D)), NewObj(1).Put("prw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_536);
return default;
}, 1, "p", true)).V).Put("berri", NewObj(2).Put("sn", ((V)("cake"))).Put("p", Fn((V _arrowThis545, int _argc538, V t_544, V _a541, V _a542, V _a543, V[] _rest539) => {
Invoke(Invoke(t_544, "to", ((V)(120D)), NewObj(1).Put("stw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(800D)), NewObj(1).Put("stw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_544);
return default;
}, 1, "p", true)).V).Put("lemmy", NewObj(3).Put("sn", ((V)("candy"))).Put("p", Fn((V _arrowThis553, int _argc546, V t_552, V _a549, V _a550, V _a551, V[] _rest547) => {
return Call(sp_15, V.Undef, t_552, NewObj(2).Put("sqz", ((V)(0.9))).Put("mw", ((V)(0.5))).V, ((V)(900D)), ((V)(700D)));
}, 1, "p", true)).Put("k", Fn((V _arrowThis561, int _argc554, V t_560, V _a557, V _a558, V _a559, V[] _rest555) => {
Invoke(Invoke(Invoke(Invoke(t_560, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-13D)))), NewObj(1).Put("armR", ((V)(36D))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(4).Put("sqz", ((V)(1D))).Put("mw", ((V)(0.4))).Put("frown", ((V)(0.3))).Put("wide", ((V)(0D))).V, ((V)("o"))), "osc", ((V)(600D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.5))).V, NewObj(1).Put("x", ((V)((-0.5)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(4).Put("frown", ((V)(0D))).Put("wide", ((V)(0.8))).Put("sqz", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o")));
Call(bk_16, V.Undef, t_560);
return default;
}, 1, "k", true)).V).Put("kiwi", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _arrowThis569, int _argc562, V t_568, V _a565, V _a566, V _a567, V[] _rest563) => {
return Call(sp_15, V.Undef, t_568, NewObj(2).Put("fzz", ((V)(0.8))).Put("sqz", ((V)(0.5))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "p", true)).V).Put("melo", NewObj(2).Put("sn", ((V)("cookie"))).Put("p", Fn((V _arrowThis577, int _argc570, V t_576, V _a573, V _a574, V _a575, V[] _rest571) => {
Invoke(t_576, "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("sdj", ((V)(1D))).V, NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_576);
return default;
}, 1, "p", true)).V).Put("peachy", NewObj(2).Put("sn", ((V)("honey"))).Put("p", Fn((V _arrowThis585, int _argc578, V t_584, V _a581, V _a582, V _a583, V[] _rest579) => {
return Call(sp_15, V.Undef, t_584, NewObj(3).Put("blush", ((V)(1D))).Put("lfl", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).V).Put("pitaya", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _arrowThis593, int _argc586, V t_592, V _a589, V _a590, V _a591, V[] _rest587) => {
return Call(sp_15, V.Undef, t_592, NewObj(3).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.6))).Put("brf", ((V)(0.5))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "p", true)).V).Put("tutti", NewObj(2).Put("sn", ((V)("cherry"))).Put("p", Fn((V _arrowThis601, int _argc594, V t_600, V _a597, V _a598, V _a599, V[] _rest595) => {
Call(sp_15, V.Undef, t_600, NewObj(1).Put("wfl", ((V)(0.8))).V, ((V)(1200D)), ((V)(800D)));
Invoke(t_600, "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "p", true)).V).Put("kiko", NewObj(2).Put("sn", ((V)("nut"))).Put("p", Fn((V _arrowThis609, int _argc602, V t_608, V _a605, V _a606, V _a607, V[] _rest603) => {
Invoke(Call(ears_17, V.Undef, t_608, ((V)(2D))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_608);
return default;
}, 1, "p", true)).V).Put("teddy", NewObj(3).Put("sn", ((V)("honey"))).Put("p", Fn((V _arrowThis617, int _argc610, V t_616, V _a613, V _a614, V _a615, V[] _rest611) => {
return Call(sp_15, V.Undef, t_616, Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(14D)), ((V)((-4D)))), NewObj(4).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("smile", ((V)(1D))).Put("blush", ((V)(0.5))).V), ((V)(1300D)), ((V)(900D)));
}, 1, "p", true)).Put("k", lick_18).V).Put("hoot", NewObj(3).Put("sn", ((V)("nut"))).Put("sp", LAPS_20).Put("p", Fn((V _arrowThis625, int _argc618, V t_624, V _a621, V _a622, V _a623, V[] _rest619) => {
Invoke(Invoke(t_624, "to", ((V)(300D)), NewObj(3).Put("wfl", ((V)(1D))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).V, ((V)("o"))), "osc", ((V)(800D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).V, NewObj(2).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("l")));
Call(bk_16, V.Undef, t_624);
return default;
}, 1, "p", true)).V).Put("leo", NewObj(3).Put("sn", ((V)("cookie"))).Put("sy", NewObj(1).Put("tsw", ((V)(0.4))).V).Put("p", Fn((V _arrowThis633, int _argc626, V t_632, V _a629, V _a630, V _a631, V[] _rest627) => {
Invoke(Invoke(Invoke(t_632, "to", ((V)(400D)), NewObj(2).Put("mfl", ((V)(0.8))).Put("open", ((V)(0.5))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(2).Put("mfl", ((V)(0D))).Put("open", ((V)(0D))).V);
Call(bk_16, V.Undef, t_632);
return default;
}, 1, "p", true)).V).Put("panko", NewObj(3).Put("sn", ((V)("bamboo"))).Put("p", Fn((V _arrowThis641, int _argc634, V t_640, V _a637, V _a638, V _a639, V[] _rest635) => {
Invoke(t_640, "osc", ((V)(1600D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("x", ((V)(1D))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("x", ((V)((-1D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_640);
return default;
}, 1, "p", true)).Put("k", nib_19).V).Put("acorn", NewObj(4).Put("sn", ((V)("acorn"))).Put("sy", NewObj(1).Put("tsw", ((V)(0.4))).V).Put("p", Fn((V _arrowThis649, int _argc642, V t_648, V _a645, V _a646, V _a647, V[] _rest643) => {
return Call(sp_15, V.Undef, t_648, NewObj(2).Put("tfl", ((V)(1D))).Put("tsw", ((V)(0.6))).V, ((V)(1300D)), ((V)(900D)));
}, 1, "p", true)).Put("k", nib_19).V).Put("fawn", NewObj(3).Put("sn", ((V)("apple"))).Put("sy", NewObj(1).Put("ear", ((V)(20D))).V).Put("p", Fn((V _arrowThis657, int _argc650, V t_656, V _a653, V _a654, V _a655, V[] _rest651) => {
Call(ears_17, V.Undef, t_656, ((V)(3D)));
Call(bk_16, V.Undef, t_656);
return default;
}, 1, "p", true)).V).Put("moss", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _arrowThis665, int _argc658, V t_664, V _a661, V _a662, V _a663, V[] _rest659) => {
Invoke(t_664, "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("cb", ((V)(0.9))).V, NewObj(1).Put("cb", ((V)(0D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_664);
return default;
}, 1, "p", true)).V).Put("sprout", NewObj(2).Put("sn", ((V)("drop"))).Put("p", Fn((V _arrowThis673, int _argc666, V t_672, V _a669, V _a670, V _a671, V[] _rest667) => {
return Call(sp_15, V.Undef, t_672, NewObj(2).Put("blm", ((V)(1D))).Put("lfl", ((V)(0.6))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "p", true)).V).Put("hana", NewObj(2).Put("sn", ((V)("carrot"))).Put("p", Fn((V _arrowThis681, int _argc674, V t_680, V _a677, V _a678, V _a679, V[] _rest675) => {
Invoke(Invoke(Invoke(t_680, "to", ((V)(400D)), NewObj(2).Put("flL", ((V)(0.9))).Put("flR", ((V)(0.9))).V), "osc", ((V)(1000D)), ((V)(4D)), NewObj(1).Put("tw", ((V)(1D))).V, NewObj(1).Put("tw", ((V)((-1D)))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(2).Put("flL", ((V)(0D))).Put("flR", ((V)(0D))).V);
Call(bk_16, V.Undef, t_680);
return default;
}, 1, "p", true)).V).Put("boo", NewObj(2).Put("sn", ((V)("candy"))).Put("p", Fn((V _arrowThis689, int _argc682, V t_688, V _a685, V _a686, V _a687, V[] _rest683) => {
return Call(sp_15, V.Undef, t_688, NewObj(2).Put("gho", ((V)(0.5))).Put("flr", ((V)(0.6))).V, ((V)(1500D)), ((V)(900D)));
}, 1, "p", true)).V).Put("pixie", NewObj(2).Put("sn", ((V)("honey"))).Put("p", Fn((V _arrowThis697, int _argc690, V t_696, V _a693, V _a694, V _a695, V[] _rest691) => {
Call(sp_15, V.Undef, t_696, NewObj(2).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.5))).V, ((V)(1200D)), ((V)(800D)));
Invoke(t_696, "fx", ((V)("dust")), ((V)("body")), ((V)(4D)));
return default;
}, 1, "p", true)).V).Put("floof", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _arrowThis705, int _argc698, V t_704, V _a701, V _a702, V _a703, V[] _rest699) => {
Invoke(Invoke(Invoke(t_704, "to", ((V)(200D)), NewObj(1).Put("fzz", ((V)(0.9))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(1).Put("fzz", ((V)(0D))).V);
Call(bk_16, V.Undef, t_704);
return default;
}, 1, "p", true)).V).Put("unibun", NewObj(2).Put("sn", ((V)("carrot"))).Put("p", Fn((V _arrowThis713, int _argc706, V t_712, V _a709, V _a710, V _a711, V[] _rest707) => {
Invoke(t_712, "fx", ((V)("spark")), ((V)("head")), ((V)(5D)));
Call(ears_17, V.Undef, t_712, ((V)(2D)));
Call(bk_16, V.Undef, t_712);
return default;
}, 1, "p", true)).V).Put("gumdrop", NewObj(2).Put("sn", ((V)("candy"))).Put("p", Fn((V _arrowThis721, int _argc714, V t_720, V _a717, V _a718, V _a719, V[] _rest715) => {
return Call(sp_15, V.Undef, t_720, NewObj(2).Put("jig", ((V)(1D))).Put("hap", ((V)(1D))).V, ((V)(1200D)), ((V)(900D)));
}, 1, "p", true)).V).Put("ember", NewObj(3).Put("sn", ((V)("berry"))).Put("p", Fn((V _arrowThis729, int _argc722, V t_728, V _a725, V _a726, V _a727, V[] _rest723) => {
Invoke(Invoke(Invoke(t_728, "to", ((V)(300D)), NewObj(3).Put("cfl", ((V)(1D))).Put("open", ((V)(0.4))).Put("hap", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(700D))), "to", ((V)(400D)), NewObj(1).Put("cfl", ((V)(0D))).V);
Call(bk_16, V.Undef, t_728);
return default;
}, 1, "p", true)).Put("k", Fn((V _arrowThis737, int _argc730, V t_736, V _a733, V _a734, V _a735, V[] _rest731) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_736, "to", ((V)(300D)), NewObj(3).Put("cfl", ((V)(1D))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(4D))), "fx", ((V)("steam")), ((V)("pawR"))), "wait", ((V)(600D))), "to", ((V)(400D)), NewObj(3).Put("cfl", ((V)(0D))).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).V);
Call(bk_16, V.Undef, t_736);
return default;
}, 1, "k", true)).V).Put("drako", NewObj(3).Put("sn", ((V)("apple"))).Put("sy", NewObj(1).Put("tsw", ((V)(0.5))).V).Put("p", Fn((V _arrowThis745, int _argc738, V t_744, V _a741, V _a742, V _a743, V[] _rest739) => {
Invoke(Invoke(Invoke(Invoke(t_744, "osc", ((V)(1400D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)(0.7))).V, NewObj(1).Put("tsw", ((V)((-0.7)))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(1).Put("puff", ((V)(0.6))).V), "to", ((V)(200D)), NewObj(1).Put("puff", ((V)(0D))).V), "fx", ((V)("steam")), ((V)("head")));
Call(bk_16, V.Undef, t_744);
return default;
}, 1, "p", true)).V).Put("jinni", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _arrowThis753, int _argc746, V t_752, V _a749, V _a750, V _a751, V[] _rest747) => {
Call(sp_15, V.Undef, t_752, NewObj(2).Put("glo", ((V)(0.8))).Put("gwh", ((V)(0.6))).V, ((V)(1400D)), ((V)(900D)));
Invoke(t_752, "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "p", true)).V).Put("cuppy", NewObj(2).Put("sn", ((V)("cherry"))).Put("p", Fn((V _arrowThis761, int _argc754, V t_760, V _a757, V _a758, V _a759, V[] _rest755) => {
Invoke(Invoke(t_760, "fx", ((V)("sprinkle")), ((V)("head"))), "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_760, "B"), "sq"), ((V)(0.05)))).V, NewObj(1).Put("sq", Get(Get(t_760, "B"), "sq")).V, ((V)("o")));
Call(bk_16, V.Undef, t_760);
return default;
}, 1, "p", true)).V).Put("chip", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _arrowThis769, int _argc762, V t_768, V _a765, V _a766, V _a767, V[] _rest763) => {
Invoke(Invoke(t_768, "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.5))).V, NewObj(1).Put("x", ((V)((-0.5)))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_768, ((V)(300D)));
return default;
}, 1, "p", true)).V).Put("twisty", NewObj(2).Put("sn", ((V)("cheese"))).Put("p", Fn((V _arrowThis777, int _argc770, V t_776, V _a773, V _a774, V _a775, V[] _rest771) => {
Invoke(Invoke(t_776, "osc", ((V)(1800D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(5D))).V, NewObj(1).Put("tilt", ((V)((-5D)))).V, ((V)("s"))), "fx", ((V)("salt")), ((V)("head")));
Call(bk_16, V.Undef, t_776);
return default;
}, 1, "p", true)).V).Put("crois", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _arrowThis785, int _argc778, V t_784, V _a781, V _a782, V _a783, V[] _rest779) => {
return Call(sp_15, V.Undef, t_784, NewObj(3).Put("lean", ((V)(1.2))).Put("tilt", ((V)(3D))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).V).Put("maca", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _arrowThis793, int _argc786, V t_792, V _a789, V _a790, V _a791, V[] _rest787) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_792, "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_792, "B"), "sq"), ((V)(0.1)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_792, "B"), "sq")).V), "wait", ((V)(250D))), "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_792, "B"), "sq"), ((V)(0.08)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_792, "B"), "sq")).V);
Call(bk_16, V.Undef, t_792, ((V)(300D)));
return default;
}, 1, "p", true)).V).Put("puddi", NewObj(2).Put("sn", ((V)("cherry"))).Put("p", Fn((V _arrowThis801, int _argc794, V t_800, V _a797, V _a798, V _a799, V[] _rest795) => {
Invoke(t_800, "osc", ((V)(1400D)), ((V)(6D)), NewObj(2).Put("sq", Add(Get(Get(t_800, "B"), "sq"), ((V)(0.06)))).Put("x", ((V)(0.3))).V, NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_800, "B"), "sq")) - 0.02)))).Put("x", ((V)((-0.3)))).V, ((V)("l")));
Call(bk_16, V.Undef, t_800);
return default;
}, 1, "p", true)).V).Put("mochi", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _arrowThis809, int _argc802, V t_808, V _a805, V _a806, V _a807, V[] _rest803) => {
return Call(sp_15, V.Undef, t_808, NewObj(3).Put("sq", Add(Get(Get(t_808, "B"), "sq"), ((V)(0.16)))).Put("smile", ((V)(1D))).Put("close", ((V)(0.6))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "p", true)).V).Put("cakey", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _arrowThis817, int _argc810, V t_816, V _a813, V _a814, V _a815, V[] _rest811) => {
Invoke(Invoke(Invoke(Invoke(t_816, "to", ((V)(400D)), NewObj(1).Put("puff", ((V)(0.7))).V), "to", ((V)(500D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(300D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V);
Call(bk_16, V.Undef, t_816);
return default;
}, 1, "p", true)).V).Put("sugarplum", NewObj(2).Put("sn", ((V)("cake"))).Put("p", Fn((V _arrowThis825, int _argc818, V t_824, V _a821, V _a822, V _a823, V[] _rest819) => {
Invoke(Invoke(Invoke(t_824, "to", ((V)(400D)), NewObj(3).Put("armR", ((V)(70D))).Put("hRy", ((V)((-2D)))).Put("smile", ((V)(0.9))).V, ((V)("o"))), "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-3D)))).V, NewObj(1).Put("hRx", ((V)(3D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_824, ((V)(500D)));
return default;
}, 1, "p", true)).V).Put("gourdy", NewObj(2).Put("sn", ((V)("candy"))).Put("p", Fn((V _arrowThis833, int _argc826, V t_832, V _a829, V _a830, V _a831, V[] _rest827) => {
Invoke(t_832, "osc", ((V)(2000D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(6D))).Put("x", ((V)(1D))).V, NewObj(2).Put("tilt", ((V)((-6D)))).Put("x", ((V)((-1D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_832);
return default;
}, 1, "p", true)).V).Put("batty", NewObj(3).Put("sn", ((V)("berry"))).Put("sp", LAPS_20).Put("p", Fn((V _arrowThis841, int _argc834, V t_840, V _a837, V _a838, V _a839, V[] _rest835) => {
return Call(sp_15, V.Undef, t_840, NewObj(4).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).Put("hLx", ((V)(12D))).Put("hRx", ((V)((-12D)))).V, ((V)(1000D)), ((V)(900D)));
}, 1, "p", true)).V).Put("kernel", NewObj(2).Put("sn", ((V)("candy"))).Put("p", Fn((V _arrowThis849, int _argc842, V t_848, V _a845, V _a846, V _a847, V[] _rest843) => {
Invoke(Invoke(Invoke(t_848, "to", ((V)(120D)), NewObj(2).Put("lift", Add(Get(Get(t_848, "B"), "lift"), ((V)(3D)))).Put("sq", ((V)((ToNum(Get(Get(t_848, "B"), "sq")) - 0.06)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("lift", Get(Get(t_848, "B"), "lift")).Put("sq", Add(Get(Get(t_848, "B"), "sq"), ((V)(0.04)))).V, ((V)("i"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_848);
return default;
}, 1, "p", true)).V).Put("hexie", NewObj(2).Put("sn", ((V)("fish"))).Put("p", Fn((V _arrowThis857, int _argc850, V t_856, V _a853, V _a854, V _a855, V[] _rest851) => {
Call(sp_15, V.Undef, t_856, NewObj(1).Put("curl", ((V)(0.7))).V, ((V)(1200D)), ((V)(900D)));
Invoke(t_856, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "p", true)).V).Put("mumbles", NewObj(2).Put("sn", ((V)("candy"))).Put("p", Fn((V _arrowThis865, int _argc858, V t_864, V _a861, V _a862, V _a863, V[] _rest859) => {
Invoke(Invoke(t_864, "to", ((V)(800D)), NewObj(5).Put("armL", ((V)(88D))).Put("armR", ((V)(88D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("open", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(700D)));
Call(bk_16, V.Undef, t_864, ((V)(700D)));
return default;
}, 1, "p", true)).V).Put("hocus", NewObj(2).Put("sn", ((V)("candy"))).Put("p", Fn((V _arrowThis873, int _argc866, V t_872, V _a869, V _a870, V _a871, V[] _rest867) => {
Invoke(Invoke(Invoke(t_872, "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(700D))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_872, ((V)(300D)));
return default;
}, 1, "p", true)).V).Put("countsquishula", NewObj(2).Put("sn", ((V)("cherry"))).Put("p", Fn((V _arrowThis881, int _argc874, V t_880, V _a877, V _a878, V _a879, V[] _rest875) => {
Invoke(Invoke(Invoke(t_880, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)((-1D))), ((V)(10D)), ((V)((-14D)))), NewObj(3).Put("armL", ((V)(60D))).Put("close", ((V)(0.4))).Put("smile", ((V)(0.6))).V)), "wait", ((V)(800D))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_880, ((V)(500D)));
return default;
}, 1, "p", true)).V).V;
Invoke(Object_keys(PROF_14), "forEach", Fn((V _arrowThis889, int _argc882, V k_888, V _a885, V _a886, V _a887, V[] _rest883) => {
V X_890 = default;
X_890 = (GetK(C_22, k_888) is var _t891 && Truthy(_t891) ? _t891 : NewObj(0).V);
if (Truthy((GetK(RND_21, k_888) is var _t892 && !Truthy(_t892) ? _t892 : (!(Truthy(Get(X_890, "sp"))) ? V.True : V.False)))) {
Set(X_890, "sp", NewObj(6).Put("armL", ((V)(42D))).Put("armR", ((V)(42D))).Put("hLy", ((V)((-7D)))).Put("hRy", ((V)((-7D)))).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-1D)))).V);
}
Call(playBuild_10, V.Undef, k_888, X_890);
return default;
}, 1, "", true));
return default;
}, 1, "", false));
        }
    }
}
