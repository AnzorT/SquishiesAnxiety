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
sp_15 = Fn((V _self2, int _argc29, V t_35, V v_36, V d_37, V hold_38, V[] _rest30) => {
V b_39 = default;
b_39 = NewObj(0).V;
Invoke(Object_keys(v_36), "forEach", Fn((V _self2, int _argc40, V k_46, V _a43, V _a44, V _a45, V[] _rest41) => {
return SetK(b_39, k_46, (!GetK(Get(t_35, "B"), k_46).IsNullish ? GetK(Get(t_35, "B"), k_46) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_35, "to", ((V)((ToNum((d_37 is var _t49 && Truthy(_t49) ? _t49 : ((V)(700D)))) * 0.4))), v_36, ((V)("o"))), "wait", (hold_38 is var _t48 && Truthy(_t48) ? _t48 : ((V)(300D)))), "to", ((V)((ToNum((d_37 is var _t47 && Truthy(_t47) ? _t47 : ((V)(700D)))) * 0.6))), b_39, ((V)("io")));
return t_35;
return default;
}, 4, "", true);
bk_16 = Fn((V _self2, int _argc50, V t_56, V d_57, V _a54, V _a55, V[] _rest51) => {
return Invoke(t_56, "back", (d_57 is var _t58 && Truthy(_t58) ? _t58 : ((V)(420D))));
}, 2, "", true);
ears_17 = Fn((V _self2, int _argc59, V t_65, V n_66, V _a63, V _a64, V[] _rest60) => {
{
V i_67 = default;
i_67 = ((V)(0D));
while (true) {
if (!(Lt(i_67, (n_66 is var _t69 && Truthy(_t69) ? _t69 : ((V)(2D)))))) break;
Invoke(Invoke(t_65, "to", ((V)(110D)), NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)(14D))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(2).Put("earL", ((V)(10D))).Put("earR", ((V)((-10D)))).V);
PostInc(ref i_67, 1D);
}
}
return Invoke(t_65, "to", ((V)(140D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V);
return default;
}, 2, "", true);
lick_18 = Fn((V _self2, int _argc70, V t_76, V _a73, V _a74, V _a75, V[] _rest71) => {
Invoke(Invoke(Invoke(t_76, "to", ((V)(380D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-13D)))), NewObj(2).Put("armR", ((V)(34D))).Put("close", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(1300D)), ((V)(5D)), NewObj(1).Put("tongue", ((V)(0.6))).V, NewObj(1).Put("tongue", ((V)(0.1))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(1).Put("tongue", ((V)(0D))).V);
return Call(bk_16, V.Undef, t_76);
return default;
}, 1, "", true);
nib_19 = Fn((V _self2, int _argc77, V t_83, V _a80, V _a81, V _a82, V[] _rest78) => {
Invoke(Invoke(Invoke(Invoke(t_83, "to", ((V)(320D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-12D)))), NewObj(1).Put("armR", ((V)(32D))).V), ((V)("io"))), "to", ((V)(260D)), NewObj(1).Put("puff", ((V)(1D))).V), "osc", ((V)(900D)), ((V)(5D)), NewObj(1).Put("open", ((V)(0.2))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("mouth")));
return Call(bk_16, V.Undef, t_83);
return default;
}, 1, "", true);
LAPS_20 = NewObj(6).Put("armL", ((V)(64D))).Put("armR", ((V)(64D))).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("hLy", ((V)(0D))).Put("hRy", ((V)(0D))).V;
RND_21 = Object_fromEntries(Invoke(Invoke(((V)("lumi plip mallow bao dunkie frybo bunbun choco scoop boba chefbun pina avo berri lemmy kiwi peachy melo pitaya tutti floof ember cuppy chip twisty crois maca puddi mochi cakey")), "split", ((V)(" "))), "map", Fn((V _self2, int _argc84, V k_90, V _a87, V _a88, V _a89, V[] _rest85) => {
return Arr(k_90, ((V)(1D)));
}, 1, "", true)));
C_22 = NewObj(80).Put("mittens", NewObj(3).Put("sn", ((V)("fish"))).Put("p", Fn((V _self2, int _argc91, V t_97, V _a94, V _a95, V _a96, V[] _rest92) => {
return Call(sp_15, V.Undef, t_97, NewObj(4).Put("curl", ((V)(0.9))).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).Put("k", lick_18).V).Put("biscuit", NewObj(3).Put("sn", ((V)("bone"))).Put("p", Fn((V _self2, int _argc98, V t_104, V _a101, V _a102, V _a103, V[] _rest99) => {
Invoke(Invoke(t_104, "to", ((V)(200D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.5))).Put("tongue", ((V)(0.5))).V), "osc", ((V)(1500D)), ((V)(8D)), NewObj(1).Put("wag", ((V)(28D))).V, NewObj(1).Put("wag", ((V)((-28D)))).V, ((V)("o")));
Call(bk_16, V.Undef, t_104);
return default;
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc105, V t_111, V _a108, V _a109, V _a110, V[] _rest106) => {
Invoke(Invoke(Invoke(t_111, "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)((ToNum(Get(Get(t_111, "B"), "pitch")) - 0.16)))).Put("ly", ((V)(0.8))).Put("wide", ((V)(0.6))).V), "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("puff", ((V)(0.4))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("puff", ((V)(0D))).Put("htilt", ((V)((-3D)))).V, ((V)("l"))), "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("o")));
Call(bk_16, V.Undef, t_111);
return default;
}, 1, "k", true)).V).Put("prickle", NewObj(3).Put("sn", ((V)("berry"))).Put("p", Fn((V _self2, int _argc112, V t_118, V _a115, V _a116, V _a117, V[] _rest113) => {
return Call(sp_15, V.Undef, t_118, NewObj(3).Put("curl", ((V)(1D))).Put("sq", Add(Get(Get(t_118, "B"), "sq"), ((V)(0.12)))).Put("close", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc119, V t_125, V _a122, V _a123, V _a124, V[] _rest120) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_125, "to", ((V)(300D)), NewObj(2).Put("wide", ((V)(0.8))).Put("open", ((V)(0.3))).V), "fx", ((V)("steam")), ((V)("head"))), "to", ((V)(300D)), NewObj(3).Put("curl", ((V)(0.8))).Put("sq", Add(Get(Get(t_125, "B"), "sq"), ((V)(0.1)))).Put("close", ((V)(1D))).V), "wait", ((V)(500D))), "to", ((V)(200D)), NewObj(2).Put("curl", ((V)(0D))).Put("wide", ((V)(0.5))).V, ((V)("o")));
Call(bk_16, V.Undef, t_125);
return default;
}, 1, "k", true)).V).Put("truffle", NewObj(3).Put("sn", ((V)("apple"))).Put("p", Fn((V _self2, int _argc126, V t_132, V _a129, V _a130, V _a131, V[] _rest127) => {
return Call(sp_15, V.Undef, t_132, NewObj(4).Put("sqz", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("wag", ((V)(20D))).V, ((V)(1300D)), ((V)(900D)));
}, 1, "p", true)).Put("k", nib_19).V).Put("ribbit", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _self2, int _argc133, V t_139, V _a136, V _a137, V _a138, V[] _rest134) => {
{
V i_140 = default;
i_140 = ((V)(0D));
while (true) {
if (!(LtN(i_140, 2D))) break;
Invoke(Invoke(t_139, "to", ((V)(120D)), NewObj(4).Put("lift", Add((Get(Get(t_139, "B"), "lift") is var _t144 && Truthy(_t144) ? _t144 : ((V)(0D))), ((V)(3D)))).Put("sq", ((V)((ToNum((Get(Get(t_139, "B"), "sq") is var _t145 && Truthy(_t145) ? _t145 : ((V)(0D)))) - 0.06)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", (Get(Get(t_139, "B"), "lift") is var _t142 && Truthy(_t142) ? _t142 : ((V)(0D)))).Put("sq", Add((Get(Get(t_139, "B"), "sq") is var _t143 && Truthy(_t143) ? _t143 : ((V)(0D))), ((V)(0.04)))).V, ((V)("i")));
PostInc(ref i_140, 1D);
}
}
Call(bk_16, V.Undef, t_139);
return default;
}, 1, "p", true)).V).Put("nibbles", NewObj(3).Put("sn", ((V)("nut"))).Put("p", Fn((V _self2, int _argc146, V t_152, V _a149, V _a150, V _a151, V[] _rest147) => {
return Call(sp_15, V.Undef, t_152, NewObj(3).Put("puff", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "p", true)).Put("k", nib_19).V).Put("quill", NewObj(3).Put("sn", ((V)("berry"))).Put("p", Fn((V _self2, int _argc153, V t_159, V _a156, V _a157, V _a158, V[] _rest154) => {
return Call(sp_15, V.Undef, t_159, NewObj(4).Put("blush", ((V)(1D))).Put("sqz", ((V)(0.6))).Put("htilt", ((V)(7D))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc160, V t_166, V _a163, V _a164, V _a165, V[] _rest161) => {
Call(sp_15, V.Undef, t_166, NewObj(4).Put("blush", ((V)(1D))).Put("close", ((V)(0.7))).Put("smile", ((V)(1D))).Put("htilt", ((V)((-6D)))).V, ((V)(1200D)), ((V)(800D)));
Invoke(t_166, "fx", ((V)("heart")), ((V)("head")));
return default;
}, 1, "k", true)).V).Put("poppy", NewObj(4).Put("sn", ((V)("carrot"))).Put("sy", NewObj(1).Put("ear", ((V)(22D))).V).Put("p", Fn((V _self2, int _argc167, V t_173, V _a170, V _a171, V _a172, V[] _rest168) => {
Invoke(t_173, "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("earL", ((V)((-18D)))).Put("earR", ((V)(16D))).V, NewObj(2).Put("earL", ((V)(16D))).Put("earR", ((V)((-18D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_173);
return default;
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc174, V t_180, V _a177, V _a178, V _a179, V[] _rest175) => {
{
V i_181 = default;
i_181 = ((V)(0D));
while (true) {
if (!(LtN(i_181, 2D))) break;
Invoke(Invoke(t_180, "to", ((V)(120D)), NewObj(4).Put("lift", Add((Get(Get(t_180, "B"), "lift") is var _t185 && Truthy(_t185) ? _t185 : ((V)(0D))), ((V)(3D)))).Put("sq", ((V)((ToNum((Get(Get(t_180, "B"), "sq") is var _t186 && Truthy(_t186) ? _t186 : ((V)(0D)))) - 0.06)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", (Get(Get(t_180, "B"), "lift") is var _t183 && Truthy(_t183) ? _t183 : ((V)(0D)))).Put("sq", Add((Get(Get(t_180, "B"), "sq") is var _t184 && Truthy(_t184) ? _t184 : ((V)(0D))), ((V)(0.04)))).V, ((V)("i")));
PostInc(ref i_181, 1D);
}
}
Call(bk_16, V.Undef, t_180);
return default;
}, 1, "k", true)).V).Put("duchess", NewObj(3).Put("sn", ((V)("fish"))).Put("p", Fn((V _self2, int _argc187, V t_193, V _a190, V _a191, V _a192, V[] _rest188) => {
return Call(sp_15, V.Undef, t_193, NewObj(4).Put("htilt", ((V)(9D))).Put("close", ((V)(0.6))).Put("pitch", Add(Get(Get(t_193, "B"), "pitch"), ((V)(0.14)))).Put("smile", ((V)(0.6))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc194, V t_200, V _a197, V _a198, V _a199, V[] _rest195) => {
Invoke(Invoke(Invoke(Invoke(t_200, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-13D)))), NewObj(2).Put("armR", ((V)(34D))).Put("close", ((V)(0.7))).V)), "wait", ((V)(600D))), "to", ((V)(260D)), NewObj(1).Put("sqz", ((V)(0.5))).V), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_200);
return default;
}, 1, "k", true)).V).Put("mamapaws", NewObj(2).Put("sn", ((V)("bone"))).Put("p", Fn((V _self2, int _argc201, V t_207, V _a204, V _a205, V _a206, V[] _rest202) => {
Call(sp_15, V.Undef, t_207, Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(12D)), ((V)(1D))), NewObj(4).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V), ((V)(1400D)), ((V)(1000D)));
Invoke(t_207, "fx", ((V)("heart")), ((V)("head")));
return default;
}, 1, "p", true)).V).Put("nimbo", NewObj(3).Put("sn", ((V)("candy"))).Put("p", Fn((V _self2, int _argc208, V t_214, V _a211, V _a212, V _a213, V[] _rest209) => {
Invoke(Invoke(Invoke(t_214, "fx", ((V)("drop")), ((V)("body")), ((V)(4D))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(2).Put("sq", Add(Get(Get(t_214, "B"), "sq"), ((V)(0.06)))).Put("puff", ((V)(0.4))).V, NewObj(2).Put("sq", Get(Get(t_214, "B"), "sq")).Put("puff", ((V)(0D))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_214);
return default;
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc215, V t_221, V _a218, V _a219, V _a220, V[] _rest216) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_221, "fx", ((V)("drop")), ((V)("body")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("wide", ((V)(0.7))).Put("open", ((V)(0.3))).V), "fx", ((V)("steam")), ((V)("head"))), "wait", ((V)(400D))), "to", ((V)(260D)), NewObj(2).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).V);
Call(bk_16, V.Undef, t_221);
return default;
}, 1, "k", true)).V).Put("lumi", NewObj(2).Put("sn", ((V)("honey"))).Put("p", Fn((V _self2, int _argc222, V t_228, V _a225, V _a226, V _a227, V[] _rest223) => {
Invoke(Invoke(Invoke(t_228, "fx", ((V)("spark")), ((V)("head")), ((V)(4D))), "to", ((V)(400D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("ly", ((V)((-0.6)))).V), "wait", ((V)(600D)));
Call(bk_16, V.Undef, t_228);
return default;
}, 1, "p", true)).V).Put("bubbly", NewObj(3).Put("sn", ((V)("candy"))).Put("sp", LAPS_20).Put("p", Fn((V _self2, int _argc229, V t_235, V _a232, V _a233, V _a234, V[] _rest230) => {
{
V i_236 = default;
i_236 = ((V)(0D));
while (true) {
if (!(LtN(i_236, 2D))) break;
Invoke(Invoke(Invoke(t_235, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.6))).Put("sq", Add(Get(Get(t_235, "B"), "sq"), ((V)(0.05)))).V), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)((Truthy(i_236) ? "bigbubble" : "bubble"))), ((V)("mouth")), ((V)(2D)));
PostInc(ref i_236, 1D);
}
}
Call(bk_16, V.Undef, t_235);
return default;
}, 1, "p", true)).V).Put("twinkle", NewObj(3).Put("sn", ((V)("star"))).Put("sp", LAPS_20).Put("p", Fn((V _self2, int _argc238, V t_244, V _a241, V _a242, V _a243, V[] _rest239) => {
Call(sp_15, V.Undef, t_244, NewObj(3).Put("glow", ((V)(1D))).Put("wide", ((V)(0.6))).Put("hap", ((V)(1D))).V, ((V)(1200D)), ((V)(800D)));
Invoke(t_244, "fx", ((V)("spark")), ((V)("body")), ((V)(5D)));
return default;
}, 1, "p", true)).V).Put("zappi", NewObj(3).Put("sn", ((V)("bolt"))).Put("p", Fn((V _self2, int _argc245, V t_251, V _a248, V _a249, V _a250, V[] _rest246) => {
Invoke(Invoke(Invoke(Invoke(t_251, "to", ((V)(80D)), NewObj(2).Put("zap", ((V)(1D))).Put("wide", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(420D)), ((V)(4D)), NewObj(1).Put("x", ((V)((-0.5)))).V, NewObj(1).Put("x", ((V)(0.5))).V, ((V)("l"))), "fx", ((V)("spark")), ((V)("body")), ((V)(5D))), "to", ((V)(300D)), NewObj(2).Put("zap", ((V)(0D))).Put("x", ((V)(0D))).V);
Call(bk_16, V.Undef, t_251);
return default;
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc252, V t_258, V _a255, V _a256, V _a257, V[] _rest253) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_258, "to", ((V)(80D)), NewObj(3).Put("zap", ((V)(1D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(5D))), "osc", ((V)(420D)), ((V)(4D)), NewObj(1).Put("x", ((V)((-0.5)))).V, NewObj(1).Put("x", ((V)(0.5))).V, ((V)("l"))), "fx", ((V)("steam")), ((V)("pawR"))), "to", ((V)(300D)), NewObj(3).Put("zap", ((V)(0D))).Put("x", ((V)(0D))).Put("sqz", ((V)(0.6))).V);
Call(bk_16, V.Undef, t_258);
return default;
}, 1, "k", true)).V).Put("plip", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _self2, int _argc259, V t_265, V _a262, V _a263, V _a264, V[] _rest260) => {
Invoke(Invoke(t_265, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_265, "B"), "sq"), ((V)(0.08)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_265, "B"), "sq")) - 0.03)))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_265);
return default;
}, 1, "p", true)).V).Put("breeze", NewObj(3).Put("sn", ((V)("apple"))).Put("p", Fn((V _self2, int _argc266, V t_272, V _a269, V _a270, V _a271, V[] _rest267) => {
Invoke(Invoke(Invoke(t_272, "to", ((V)(400D)), NewObj(1).Put("puff", ((V)(0.8))).V), "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.35))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head")));
Call(bk_16, V.Undef, t_272);
return default;
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc273, V t_279, V _a276, V _a277, V _a278, V[] _rest274) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_279, "to", ((V)(380D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-12D)))), NewObj(1).Put("armR", ((V)(34D))).V), ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("puff", ((V)(0.9))).V), "to", ((V)(400D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("mouth"))), "fx", ((V)("steam")), ((V)("pawR"))), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(2).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).V);
Call(bk_16, V.Undef, t_279);
return default;
}, 1, "k", true)).V).Put("dusty", NewObj(2).Put("sn", ((V)("flower"))).Put("p", Fn((V _self2, int _argc280, V t_286, V _a283, V _a284, V _a285, V[] _rest281) => {
Invoke(Call(ears_17, V.Undef, t_286, ((V)(3D))), "fx", ((V)("dust")), ((V)("body")), ((V)(4D)));
Call(bk_16, V.Undef, t_286);
return default;
}, 1, "p", true)).V).Put("aurora", NewObj(3).Put("sn", ((V)("fish"))).Put("sp", LAPS_20).Put("p", Fn((V _self2, int _argc287, V t_293, V _a290, V _a291, V _a292, V[] _rest288) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_293, "to", ((V)(300D)), NewObj(1).Put("spout", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("gush")), ((V)("head")), ((V)(3D))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(2).Put("spout", ((V)(0D))).Put("glow", ((V)(0.8))).V), "wait", ((V)(400D)));
Call(bk_16, V.Undef, t_293, ((V)(600D)));
return default;
}, 1, "p", true)).V).Put("mallow", NewObj(3).Put("sn", ((V)("candy"))).Put("p", Fn((V _self2, int _argc294, V t_300, V _a297, V _a298, V _a299, V[] _rest295) => {
return Call(sp_15, V.Undef, t_300, NewObj(3).Put("sq", Add(Get(Get(t_300, "B"), "sq"), ((V)(0.18)))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc301, V t_307, V _a304, V _a305, V _a306, V[] _rest302) => {
Call(sp_15, V.Undef, t_307, NewObj(4).Put("sq", Add(Get(Get(t_307, "B"), "sq"), ((V)(0.14)))).Put("blush", ((V)(1D))).Put("smile", ((V)(1D))).Put("close", ((V)(0.6))).V, ((V)(1400D)), ((V)(900D)));
Invoke(t_307, "fx", ((V)("steam")), ((V)("head")));
return default;
}, 1, "k", true)).V).Put("bao", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _self2, int _argc308, V t_314, V _a311, V _a312, V _a313, V[] _rest309) => {
Invoke(Invoke(Invoke(t_314, "fx", ((V)("steam")), ((V)("head"))), "osc", ((V)(1200D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(Get(t_314, "B"), "sq"), ((V)(0.06)))).V, NewObj(1).Put("sq", Get(Get(t_314, "B"), "sq")).V, ((V)("s"))), "fx", ((V)("steam")), ((V)("head")));
Call(bk_16, V.Undef, t_314);
return default;
}, 1, "p", true)).V).Put("dunkie", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _self2, int _argc315, V t_321, V _a318, V _a319, V _a320, V[] _rest316) => {
Invoke(Invoke(t_321, "osc", ((V)(1600D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("turn", ((V)(0.3))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("turn", ((V)((-0.3)))).V, ((V)("s"))), "fx", ((V)("sprinkle")), ((V)("head")));
Call(bk_16, V.Undef, t_321);
return default;
}, 1, "p", true)).V).Put("frybo", NewObj(3).Put("sn", ((V)("ketchup"))).Put("p", Fn((V _self2, int _argc322, V t_328, V _a325, V _a326, V _a327, V[] _rest323) => {
Call(sp_15, V.Undef, t_328, NewObj(3).Put("fw", ((V)(1D))).Put("smile", ((V)(1D))).Put("hap", ((V)(1D))).V, ((V)(1200D)), ((V)(800D)));
Invoke(t_328, "fx", ((V)("salt")), ((V)("head")));
return default;
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc329, V t_335, V _a332, V _a333, V _a334, V[] _rest330) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_335, "to", ((V)(300D)), NewObj(2).Put("fw", ((V)(0.8))).Put("hap", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(6D)), NewObj(1).Put("tilt", ((V)(3D))).V, NewObj(1).Put("tilt", ((V)((-3D)))).V, ((V)("l"))), "fx", ((V)("salt")), ((V)("head")), ((V)(4D))), "fx", ((V)("salt")), ((V)("pawR")), ((V)(3D))), "to", ((V)(300D)), NewObj(1).Put("fw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_335);
return default;
}, 1, "k", true)).V).Put("bunbun", NewObj(2).Put("sn", ((V)("cheese"))).Put("p", Fn((V _self2, int _argc336, V t_342, V _a339, V _a340, V _a341, V[] _rest337) => {
return Call(sp_15, V.Undef, t_342, NewObj(3).Put("split", ((V)(0.5))).Put("shuf", ((V)(0.3))).Put("hap", ((V)(1D))).V, ((V)(1300D)), ((V)(800D)));
}, 1, "p", true)).V).Put("choco", NewObj(3).Put("sn", ((V)("nut"))).Put("p", Fn((V _self2, int _argc343, V t_349, V _a346, V _a347, V _a348, V[] _rest344) => {
return Call(sp_15, V.Undef, t_349, NewObj(3).Put("melt", ((V)(0.5))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1500D)), ((V)(1000D)));
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc350, V t_356, V _a353, V _a354, V _a355, V[] _rest351) => {
Call(sp_15, V.Undef, t_356, NewObj(3).Put("melt", ((V)(0.7))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.3))).V, ((V)(1400D)), ((V)(800D)));
Invoke(Invoke(t_356, "fx", ((V)("steam")), ((V)("head"))), "fx", ((V)("sweat")), ((V)("head")));
return default;
}, 1, "k", true)).V).Put("scoop", NewObj(3).Put("sn", ((V)("cherry"))).Put("p", Fn((V _self2, int _argc357, V t_363, V _a360, V _a361, V _a362, V[] _rest358) => {
Invoke(t_363, "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("chb", ((V)(0.9))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_363);
return default;
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc364, V t_370, V _a367, V _a368, V _a369, V[] _rest365) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_370, "fx", ((V)("sweat")), ((V)("head"))), "to", ((V)(300D)), NewObj(3).Put("wide", ((V)(0.7))).Put("open", ((V)(0.3))).Put("frown", ((V)(0.3))).V), "fx", ((V)("drop")), ((V)("head")), ((V)(2D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(3).Put("chb", ((V)(0.9))).Put("frown", ((V)(0D))).Put("smile", ((V)(1D))).V), "to", ((V)(300D)), NewObj(1).Put("chb", ((V)(0D))).V);
Call(bk_16, V.Undef, t_370);
return default;
}, 1, "k", true)).V).Put("boba", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _self2, int _argc371, V t_377, V _a374, V _a375, V _a376, V[] _rest372) => {
Invoke(Invoke(t_377, "osc", ((V)(1400D)), ((V)(3D)), NewObj(2).Put("slurp", ((V)(0.6))).Put("sqz", ((V)(0.4))).V, NewObj(2).Put("slurp", ((V)(0D))).Put("sqz", ((V)(0D))).V, ((V)("s"))), "fx", ((V)("bubble")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_377);
return default;
}, 1, "p", true)).V).Put("chefbun", NewObj(4).Put("sn", ((V)("cake"))).Put("cOrd", Arr(((V)("stir")), ((V)("season")), ((V)("shake")), ((V)("flip")), ((V)("sig")), ((V)("flip")), ((V)("taste")), ((V)("kiss")))).Put("p", Fn((V _self2, int _argc378, V t_384, V _a381, V _a382, V _a383, V[] _rest379) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_384, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-13D)))), NewObj(1).Put("armR", ((V)(34D))).V)), "wait", ((V)(300D))), "to", ((V)(260D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-14D)))), NewObj(2).Put("armR", ((V)(60D))).Put("smile", ((V)(1D))).V), ((V)("o"))), "fx", ((V)("heart")), ((V)("head"))), "wait", ((V)(400D)));
Call(bk_16, V.Undef, t_384, ((V)(500D)));
return default;
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc385, V t_391, V _a388, V _a389, V _a390, V[] _rest386) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_391, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)((-1D))), ((V)(8D)), ((V)((-16D)))), NewObj(3).Put("armL", ((V)(70D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V), ((V)("io"))), "osc", ((V)(800D)), ((V)(2D)), NewObj(1).Put("htilt", ((V)(6D))).V, NewObj(1).Put("htilt", ((V)((-2D)))).V, ((V)("s"))), "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(7D)), ((V)((-14D)))), NewObj(2).Put("armR", ((V)(38D))).Put("puff", ((V)(0.3))).V)), "to", ((V)(200D)), NewObj(6).Put("armR", ((V)(120D))).Put("hRx", ((V)(4D))).Put("hRy", ((V)((-6D)))).Put("puff", ((V)(0D))).Put("sqz", ((V)(0.8))).Put("hap", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("heart")), ((V)("head")), ((V)(2D))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D))), "wait", ((V)(500D)));
Call(bk_16, V.Undef, t_391, ((V)(500D)));
return default;
}, 1, "k", true)).V).Put("pip", NewObj(2).Put("sn", ((V)("fish"))).Put("p", Fn((V _self2, int _argc392, V t_398, V _a395, V _a396, V _a397, V[] _rest393) => {
Invoke(t_398, "osc", ((V)(1200D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, NewObj(2).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_398);
return default;
}, 1, "p", true)).V).Put("jelli", NewObj(3).Put("sn", ((V)("candy"))).Put("sp", LAPS_20).Put("p", Fn((V _self2, int _argc399, V t_405, V _a402, V _a403, V _a404, V[] _rest400) => {
{
V i_406 = default;
i_406 = ((V)(0D));
while (true) {
if (!(LtN(i_406, 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_405, "to", ((V)(350D)), NewObj(1).Put("sq", Add(Get(Get(t_405, "B"), "sq"), ((V)(0.1)))).V, ((V)("i"))), "to", ((V)(450D)), NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_405, "B"), "sq")) - 0.05)))).Put("lift", Add(Get(Get(t_405, "B"), "lift"), ((V)(1.2)))).V, ((V)("o"))), "fx", ((V)("bubble")), ((V)("body")), ((V)(2D))), "to", ((V)(400D)), NewObj(2).Put("sq", Get(Get(t_405, "B"), "sq")).Put("lift", Get(Get(t_405, "B"), "lift")).V, ((V)("s")));
PostInc(ref i_406, 1D);
}
}
Call(bk_16, V.Undef, t_405, ((V)(300D)));
return default;
}, 1, "p", true)).V).Put("finn", NewObj(3).Put("sn", ((V)("fish"))).Put("sp", LAPS_20).Put("p", Fn((V _self2, int _argc408, V t_414, V _a411, V _a412, V _a413, V[] _rest409) => {
Invoke(Invoke(t_414, "osc", ((V)(1400D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("tail")), ((V)(3D)));
Call(bk_16, V.Undef, t_414);
return default;
}, 1, "p", true)).V).Put("sealy", NewObj(3).Put("sn", ((V)("fish"))).Put("sp", LAPS_20).Put("p", Fn((V _self2, int _argc415, V t_421, V _a418, V _a419, V _a420, V[] _rest416) => {
Invoke(Invoke(t_421, "osc", ((V)(800D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.4))).V, NewObj(1).Put("open", ((V)(0.05))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(4).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, NewObj(4).Put("hLx", ((V)(7D))).Put("hRx", ((V)((-7D)))).Put("armL", ((V)(14D))).Put("armR", ((V)(14D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_421, ((V)(500D)));
return default;
}, 1, "p", true)).V).Put("puff", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _self2, int _argc422, V t_428, V _a425, V _a426, V _a427, V[] _rest423) => {
Invoke(Invoke(Invoke(Invoke(t_428, "to", ((V)(700D)), NewObj(2).Put("blo", ((V)(0.8))).Put("puff", ((V)(0.8))).V, ((V)("s"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(2).Put("blo", ((V)(0D))).Put("puff", ((V)(0D))).V), "fx", ((V)("bubble")), ((V)("mouth")), ((V)(3D)));
Call(bk_16, V.Undef, t_428);
return default;
}, 1, "p", true)).V).Put("shelly", NewObj(3).Put("sn", ((V)("leaf"))).Put("sp", LAPS_20).Put("p", Fn((V _self2, int _argc429, V t_435, V _a432, V _a433, V _a434, V[] _rest430) => {
return Call(sp_15, V.Undef, t_435, NewObj(3).Put("nk", ((V)(1D))).Put("wide", ((V)(0.5))).Put("hap", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).V).Put("octo", NewObj(3).Put("sn", ((V)("fish"))).Put("p", Fn((V _self2, int _argc436, V t_442, V _a439, V _a440, V _a441, V[] _rest437) => {
return Call(sp_15, V.Undef, t_442, NewObj(3).Put("ow", ((V)(1D))).Put("osp", ((V)(0.8))).Put("hap", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc443, V t_449, V _a446, V _a447, V _a448, V[] _rest444) => {
Call(sp_15, V.Undef, t_449, NewObj(3).Put("ow", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1000D)));
Invoke(Invoke(t_449, "fx", ((V)("steam")), ((V)("pawR"))), "fx", ((V)("salt")), ((V)("pawL")), ((V)(3D)));
return default;
}, 1, "k", true)).V).Put("marina", NewObj(3).Put("sn", ((V)("shell"))).Put("sy", NewObj(1).Put("tsw", ((V)(0.5))).V).Put("p", Fn((V _self2, int _argc450, V t_456, V _a453, V _a454, V _a455, V[] _rest451) => {
Invoke(Invoke(Invoke(t_456, "to", ((V)(400D)), NewObj(1).Put("tlf", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)(0.6))).V, NewObj(1).Put("tsw", ((V)((-0.6)))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(2).Put("tlf", ((V)(0D))).Put("tsw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_456);
return default;
}, 1, "p", true)).V).Put("pearl", NewObj(2).Put("sn", ((V)("fish"))).Put("p", Fn((V _self2, int _argc457, V t_463, V _a460, V _a461, V _a462, V[] _rest458) => {
Call(sp_15, V.Undef, t_463, NewObj(2).Put("glow", ((V)(1D))).Put("hsw", ((V)(0.6))).V, ((V)(1400D)), ((V)(900D)));
Invoke(t_463, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "p", true)).V).Put("pina", NewObj(2).Put("sn", ((V)("cake"))).Put("p", Fn((V _self2, int _argc464, V t_470, V _a467, V _a468, V _a469, V[] _rest465) => {
Invoke(Invoke(Invoke(t_470, "to", ((V)(300D)), NewObj(1).Put("crw", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("crs", ((V)(0.4))).V, NewObj(1).Put("crs", ((V)(0D))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(1).Put("crw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_470);
return default;
}, 1, "p", true)).V).Put("avo", NewObj(2).Put("sn", ((V)("cookie"))).Put("p", Fn((V _self2, int _argc471, V t_477, V _a474, V _a475, V _a476, V[] _rest472) => {
Invoke(Invoke(Invoke(t_477, "to", ((V)(300D)), NewObj(1).Put("prw", ((V)(0.9))).V), "wait", ((V)(900D))), "to", ((V)(300D)), NewObj(1).Put("prw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_477);
return default;
}, 1, "p", true)).V).Put("berri", NewObj(2).Put("sn", ((V)("cake"))).Put("p", Fn((V _self2, int _argc478, V t_484, V _a481, V _a482, V _a483, V[] _rest479) => {
Invoke(Invoke(t_484, "to", ((V)(120D)), NewObj(1).Put("stw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(800D)), NewObj(1).Put("stw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_484);
return default;
}, 1, "p", true)).V).Put("lemmy", NewObj(3).Put("sn", ((V)("candy"))).Put("p", Fn((V _self2, int _argc485, V t_491, V _a488, V _a489, V _a490, V[] _rest486) => {
return Call(sp_15, V.Undef, t_491, NewObj(2).Put("sqz", ((V)(0.9))).Put("mw", ((V)(0.5))).V, ((V)(900D)), ((V)(700D)));
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc492, V t_498, V _a495, V _a496, V _a497, V[] _rest493) => {
Invoke(Invoke(Invoke(Invoke(t_498, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-13D)))), NewObj(1).Put("armR", ((V)(36D))).V), ((V)("io"))), "to", ((V)(160D)), NewObj(4).Put("sqz", ((V)(1D))).Put("mw", ((V)(0.4))).Put("frown", ((V)(0.3))).Put("wide", ((V)(0D))).V, ((V)("o"))), "osc", ((V)(600D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.5))).V, NewObj(1).Put("x", ((V)((-0.5)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(4).Put("frown", ((V)(0D))).Put("wide", ((V)(0.8))).Put("sqz", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o")));
Call(bk_16, V.Undef, t_498);
return default;
}, 1, "k", true)).V).Put("kiwi", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _self2, int _argc499, V t_505, V _a502, V _a503, V _a504, V[] _rest500) => {
return Call(sp_15, V.Undef, t_505, NewObj(2).Put("fzz", ((V)(0.8))).Put("sqz", ((V)(0.5))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "p", true)).V).Put("melo", NewObj(2).Put("sn", ((V)("cookie"))).Put("p", Fn((V _self2, int _argc506, V t_512, V _a509, V _a510, V _a511, V[] _rest507) => {
Invoke(t_512, "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("sdj", ((V)(1D))).V, NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_512);
return default;
}, 1, "p", true)).V).Put("peachy", NewObj(2).Put("sn", ((V)("honey"))).Put("p", Fn((V _self2, int _argc513, V t_519, V _a516, V _a517, V _a518, V[] _rest514) => {
return Call(sp_15, V.Undef, t_519, NewObj(3).Put("blush", ((V)(1D))).Put("lfl", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).V).Put("pitaya", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _self2, int _argc520, V t_526, V _a523, V _a524, V _a525, V[] _rest521) => {
return Call(sp_15, V.Undef, t_526, NewObj(3).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.6))).Put("brf", ((V)(0.5))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "p", true)).V).Put("tutti", NewObj(2).Put("sn", ((V)("cherry"))).Put("p", Fn((V _self2, int _argc527, V t_533, V _a530, V _a531, V _a532, V[] _rest528) => {
Call(sp_15, V.Undef, t_533, NewObj(1).Put("wfl", ((V)(0.8))).V, ((V)(1200D)), ((V)(800D)));
Invoke(t_533, "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "p", true)).V).Put("kiko", NewObj(2).Put("sn", ((V)("nut"))).Put("p", Fn((V _self2, int _argc534, V t_540, V _a537, V _a538, V _a539, V[] _rest535) => {
Invoke(Call(ears_17, V.Undef, t_540, ((V)(2D))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_540);
return default;
}, 1, "p", true)).V).Put("teddy", NewObj(3).Put("sn", ((V)("honey"))).Put("p", Fn((V _self2, int _argc541, V t_547, V _a544, V _a545, V _a546, V[] _rest542) => {
return Call(sp_15, V.Undef, t_547, Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(14D)), ((V)((-4D)))), NewObj(4).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("smile", ((V)(1D))).Put("blush", ((V)(0.5))).V), ((V)(1300D)), ((V)(900D)));
}, 1, "p", true)).Put("k", lick_18).V).Put("hoot", NewObj(3).Put("sn", ((V)("nut"))).Put("sp", LAPS_20).Put("p", Fn((V _self2, int _argc548, V t_554, V _a551, V _a552, V _a553, V[] _rest549) => {
Invoke(Invoke(t_554, "to", ((V)(300D)), NewObj(3).Put("wfl", ((V)(1D))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).V, ((V)("o"))), "osc", ((V)(800D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).V, NewObj(2).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("l")));
Call(bk_16, V.Undef, t_554);
return default;
}, 1, "p", true)).V).Put("leo", NewObj(3).Put("sn", ((V)("cookie"))).Put("sy", NewObj(1).Put("tsw", ((V)(0.4))).V).Put("p", Fn((V _self2, int _argc555, V t_561, V _a558, V _a559, V _a560, V[] _rest556) => {
Invoke(Invoke(Invoke(t_561, "to", ((V)(400D)), NewObj(2).Put("mfl", ((V)(0.8))).Put("open", ((V)(0.5))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(2).Put("mfl", ((V)(0D))).Put("open", ((V)(0D))).V);
Call(bk_16, V.Undef, t_561);
return default;
}, 1, "p", true)).V).Put("panko", NewObj(3).Put("sn", ((V)("bamboo"))).Put("p", Fn((V _self2, int _argc562, V t_568, V _a565, V _a566, V _a567, V[] _rest563) => {
Invoke(t_568, "osc", ((V)(1600D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("x", ((V)(1D))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("x", ((V)((-1D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_568);
return default;
}, 1, "p", true)).Put("k", nib_19).V).Put("acorn", NewObj(4).Put("sn", ((V)("acorn"))).Put("sy", NewObj(1).Put("tsw", ((V)(0.4))).V).Put("p", Fn((V _self2, int _argc569, V t_575, V _a572, V _a573, V _a574, V[] _rest570) => {
return Call(sp_15, V.Undef, t_575, NewObj(2).Put("tfl", ((V)(1D))).Put("tsw", ((V)(0.6))).V, ((V)(1300D)), ((V)(900D)));
}, 1, "p", true)).Put("k", nib_19).V).Put("fawn", NewObj(3).Put("sn", ((V)("apple"))).Put("sy", NewObj(1).Put("ear", ((V)(20D))).V).Put("p", Fn((V _self2, int _argc576, V t_582, V _a579, V _a580, V _a581, V[] _rest577) => {
Call(ears_17, V.Undef, t_582, ((V)(3D)));
Call(bk_16, V.Undef, t_582);
return default;
}, 1, "p", true)).V).Put("moss", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _self2, int _argc583, V t_589, V _a586, V _a587, V _a588, V[] _rest584) => {
Invoke(t_589, "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("cb", ((V)(0.9))).V, NewObj(1).Put("cb", ((V)(0D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_589);
return default;
}, 1, "p", true)).V).Put("sprout", NewObj(2).Put("sn", ((V)("drop"))).Put("p", Fn((V _self2, int _argc590, V t_596, V _a593, V _a594, V _a595, V[] _rest591) => {
return Call(sp_15, V.Undef, t_596, NewObj(2).Put("blm", ((V)(1D))).Put("lfl", ((V)(0.6))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "p", true)).V).Put("hana", NewObj(2).Put("sn", ((V)("carrot"))).Put("p", Fn((V _self2, int _argc597, V t_603, V _a600, V _a601, V _a602, V[] _rest598) => {
Invoke(Invoke(Invoke(t_603, "to", ((V)(400D)), NewObj(2).Put("flL", ((V)(0.9))).Put("flR", ((V)(0.9))).V), "osc", ((V)(1000D)), ((V)(4D)), NewObj(1).Put("tw", ((V)(1D))).V, NewObj(1).Put("tw", ((V)((-1D)))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(2).Put("flL", ((V)(0D))).Put("flR", ((V)(0D))).V);
Call(bk_16, V.Undef, t_603);
return default;
}, 1, "p", true)).V).Put("boo", NewObj(2).Put("sn", ((V)("candy"))).Put("p", Fn((V _self2, int _argc604, V t_610, V _a607, V _a608, V _a609, V[] _rest605) => {
return Call(sp_15, V.Undef, t_610, NewObj(2).Put("gho", ((V)(0.5))).Put("flr", ((V)(0.6))).V, ((V)(1500D)), ((V)(900D)));
}, 1, "p", true)).V).Put("pixie", NewObj(2).Put("sn", ((V)("honey"))).Put("p", Fn((V _self2, int _argc611, V t_617, V _a614, V _a615, V _a616, V[] _rest612) => {
Call(sp_15, V.Undef, t_617, NewObj(2).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.5))).V, ((V)(1200D)), ((V)(800D)));
Invoke(t_617, "fx", ((V)("dust")), ((V)("body")), ((V)(4D)));
return default;
}, 1, "p", true)).V).Put("floof", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _self2, int _argc618, V t_624, V _a621, V _a622, V _a623, V[] _rest619) => {
Invoke(Invoke(Invoke(t_624, "to", ((V)(200D)), NewObj(1).Put("fzz", ((V)(0.9))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(1).Put("fzz", ((V)(0D))).V);
Call(bk_16, V.Undef, t_624);
return default;
}, 1, "p", true)).V).Put("unibun", NewObj(2).Put("sn", ((V)("carrot"))).Put("p", Fn((V _self2, int _argc625, V t_631, V _a628, V _a629, V _a630, V[] _rest626) => {
Invoke(t_631, "fx", ((V)("spark")), ((V)("head")), ((V)(5D)));
Call(ears_17, V.Undef, t_631, ((V)(2D)));
Call(bk_16, V.Undef, t_631);
return default;
}, 1, "p", true)).V).Put("gumdrop", NewObj(2).Put("sn", ((V)("candy"))).Put("p", Fn((V _self2, int _argc632, V t_638, V _a635, V _a636, V _a637, V[] _rest633) => {
return Call(sp_15, V.Undef, t_638, NewObj(2).Put("jig", ((V)(1D))).Put("hap", ((V)(1D))).V, ((V)(1200D)), ((V)(900D)));
}, 1, "p", true)).V).Put("ember", NewObj(3).Put("sn", ((V)("berry"))).Put("p", Fn((V _self2, int _argc639, V t_645, V _a642, V _a643, V _a644, V[] _rest640) => {
Invoke(Invoke(Invoke(t_645, "to", ((V)(300D)), NewObj(3).Put("cfl", ((V)(1D))).Put("open", ((V)(0.4))).Put("hap", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(700D))), "to", ((V)(400D)), NewObj(1).Put("cfl", ((V)(0D))).V);
Call(bk_16, V.Undef, t_645);
return default;
}, 1, "p", true)).Put("k", Fn((V _self2, int _argc646, V t_652, V _a649, V _a650, V _a651, V[] _rest647) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_652, "to", ((V)(300D)), NewObj(3).Put("cfl", ((V)(1D))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(4D))), "fx", ((V)("steam")), ((V)("pawR"))), "wait", ((V)(600D))), "to", ((V)(400D)), NewObj(3).Put("cfl", ((V)(0D))).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).V);
Call(bk_16, V.Undef, t_652);
return default;
}, 1, "k", true)).V).Put("drako", NewObj(3).Put("sn", ((V)("apple"))).Put("sy", NewObj(1).Put("tsw", ((V)(0.5))).V).Put("p", Fn((V _self2, int _argc653, V t_659, V _a656, V _a657, V _a658, V[] _rest654) => {
Invoke(Invoke(Invoke(Invoke(t_659, "osc", ((V)(1400D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)(0.7))).V, NewObj(1).Put("tsw", ((V)((-0.7)))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(1).Put("puff", ((V)(0.6))).V), "to", ((V)(200D)), NewObj(1).Put("puff", ((V)(0D))).V), "fx", ((V)("steam")), ((V)("head")));
Call(bk_16, V.Undef, t_659);
return default;
}, 1, "p", true)).V).Put("jinni", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _self2, int _argc660, V t_666, V _a663, V _a664, V _a665, V[] _rest661) => {
Call(sp_15, V.Undef, t_666, NewObj(2).Put("glo", ((V)(0.8))).Put("gwh", ((V)(0.6))).V, ((V)(1400D)), ((V)(900D)));
Invoke(t_666, "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "p", true)).V).Put("cuppy", NewObj(2).Put("sn", ((V)("cherry"))).Put("p", Fn((V _self2, int _argc667, V t_673, V _a670, V _a671, V _a672, V[] _rest668) => {
Invoke(Invoke(t_673, "fx", ((V)("sprinkle")), ((V)("head"))), "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_673, "B"), "sq"), ((V)(0.05)))).V, NewObj(1).Put("sq", Get(Get(t_673, "B"), "sq")).V, ((V)("o")));
Call(bk_16, V.Undef, t_673);
return default;
}, 1, "p", true)).V).Put("chip", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _self2, int _argc674, V t_680, V _a677, V _a678, V _a679, V[] _rest675) => {
Invoke(Invoke(t_680, "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.5))).V, NewObj(1).Put("x", ((V)((-0.5)))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_680, ((V)(300D)));
return default;
}, 1, "p", true)).V).Put("twisty", NewObj(2).Put("sn", ((V)("cheese"))).Put("p", Fn((V _self2, int _argc681, V t_687, V _a684, V _a685, V _a686, V[] _rest682) => {
Invoke(Invoke(t_687, "osc", ((V)(1800D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(5D))).V, NewObj(1).Put("tilt", ((V)((-5D)))).V, ((V)("s"))), "fx", ((V)("salt")), ((V)("head")));
Call(bk_16, V.Undef, t_687);
return default;
}, 1, "p", true)).V).Put("crois", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _self2, int _argc688, V t_694, V _a691, V _a692, V _a693, V[] _rest689) => {
return Call(sp_15, V.Undef, t_694, NewObj(3).Put("lean", ((V)(1.2))).Put("tilt", ((V)(3D))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "p", true)).V).Put("maca", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _self2, int _argc695, V t_701, V _a698, V _a699, V _a700, V[] _rest696) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_701, "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_701, "B"), "sq"), ((V)(0.1)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_701, "B"), "sq")).V), "wait", ((V)(250D))), "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_701, "B"), "sq"), ((V)(0.08)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_701, "B"), "sq")).V);
Call(bk_16, V.Undef, t_701, ((V)(300D)));
return default;
}, 1, "p", true)).V).Put("puddi", NewObj(2).Put("sn", ((V)("cherry"))).Put("p", Fn((V _self2, int _argc702, V t_708, V _a705, V _a706, V _a707, V[] _rest703) => {
Invoke(t_708, "osc", ((V)(1400D)), ((V)(6D)), NewObj(2).Put("sq", Add(Get(Get(t_708, "B"), "sq"), ((V)(0.06)))).Put("x", ((V)(0.3))).V, NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_708, "B"), "sq")) - 0.02)))).Put("x", ((V)((-0.3)))).V, ((V)("l")));
Call(bk_16, V.Undef, t_708);
return default;
}, 1, "p", true)).V).Put("mochi", NewObj(2).Put("sn", ((V)("berry"))).Put("p", Fn((V _self2, int _argc709, V t_715, V _a712, V _a713, V _a714, V[] _rest710) => {
return Call(sp_15, V.Undef, t_715, NewObj(3).Put("sq", Add(Get(Get(t_715, "B"), "sq"), ((V)(0.16)))).Put("smile", ((V)(1D))).Put("close", ((V)(0.6))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "p", true)).V).Put("cakey", NewObj(2).Put("sn", ((V)("cup"))).Put("p", Fn((V _self2, int _argc716, V t_722, V _a719, V _a720, V _a721, V[] _rest717) => {
Invoke(Invoke(Invoke(Invoke(t_722, "to", ((V)(400D)), NewObj(1).Put("puff", ((V)(0.7))).V), "to", ((V)(500D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(300D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V);
Call(bk_16, V.Undef, t_722);
return default;
}, 1, "p", true)).V).Put("sugarplum", NewObj(2).Put("sn", ((V)("cake"))).Put("p", Fn((V _self2, int _argc723, V t_729, V _a726, V _a727, V _a728, V[] _rest724) => {
Invoke(Invoke(Invoke(t_729, "to", ((V)(400D)), NewObj(3).Put("armR", ((V)(70D))).Put("hRy", ((V)((-2D)))).Put("smile", ((V)(0.9))).V, ((V)("o"))), "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-3D)))).V, NewObj(1).Put("hRx", ((V)(3D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_729, ((V)(500D)));
return default;
}, 1, "p", true)).V).Put("gourdy", NewObj(2).Put("sn", ((V)("candy"))).Put("p", Fn((V _self2, int _argc730, V t_736, V _a733, V _a734, V _a735, V[] _rest731) => {
Invoke(t_736, "osc", ((V)(2000D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(6D))).Put("x", ((V)(1D))).V, NewObj(2).Put("tilt", ((V)((-6D)))).Put("x", ((V)((-1D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_736);
return default;
}, 1, "p", true)).V).Put("batty", NewObj(3).Put("sn", ((V)("berry"))).Put("sp", LAPS_20).Put("p", Fn((V _self2, int _argc737, V t_743, V _a740, V _a741, V _a742, V[] _rest738) => {
return Call(sp_15, V.Undef, t_743, NewObj(4).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).Put("hLx", ((V)(12D))).Put("hRx", ((V)((-12D)))).V, ((V)(1000D)), ((V)(900D)));
}, 1, "p", true)).V).Put("kernel", NewObj(2).Put("sn", ((V)("candy"))).Put("p", Fn((V _self2, int _argc744, V t_750, V _a747, V _a748, V _a749, V[] _rest745) => {
Invoke(Invoke(Invoke(t_750, "to", ((V)(120D)), NewObj(2).Put("lift", Add(Get(Get(t_750, "B"), "lift"), ((V)(3D)))).Put("sq", ((V)((ToNum(Get(Get(t_750, "B"), "sq")) - 0.06)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("lift", Get(Get(t_750, "B"), "lift")).Put("sq", Add(Get(Get(t_750, "B"), "sq"), ((V)(0.04)))).V, ((V)("i"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_750);
return default;
}, 1, "p", true)).V).Put("hexie", NewObj(2).Put("sn", ((V)("fish"))).Put("p", Fn((V _self2, int _argc751, V t_757, V _a754, V _a755, V _a756, V[] _rest752) => {
Call(sp_15, V.Undef, t_757, NewObj(1).Put("curl", ((V)(0.7))).V, ((V)(1200D)), ((V)(900D)));
Invoke(t_757, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "p", true)).V).Put("mumbles", NewObj(2).Put("sn", ((V)("candy"))).Put("p", Fn((V _self2, int _argc758, V t_764, V _a761, V _a762, V _a763, V[] _rest759) => {
Invoke(Invoke(t_764, "to", ((V)(800D)), NewObj(5).Put("armL", ((V)(88D))).Put("armR", ((V)(88D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("open", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(700D)));
Call(bk_16, V.Undef, t_764, ((V)(700D)));
return default;
}, 1, "p", true)).V).Put("hocus", NewObj(2).Put("sn", ((V)("candy"))).Put("p", Fn((V _self2, int _argc765, V t_771, V _a768, V _a769, V _a770, V[] _rest766) => {
Invoke(Invoke(Invoke(t_771, "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(700D))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_771, ((V)(300D)));
return default;
}, 1, "p", true)).V).Put("countsquishula", NewObj(2).Put("sn", ((V)("cherry"))).Put("p", Fn((V _self2, int _argc772, V t_778, V _a775, V _a776, V _a777, V[] _rest773) => {
Invoke(Invoke(Invoke(t_778, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)((-1D))), ((V)(10D)), ((V)((-14D)))), NewObj(3).Put("armL", ((V)(60D))).Put("close", ((V)(0.4))).Put("smile", ((V)(0.6))).V)), "wait", ((V)(800D))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_778, ((V)(500D)));
return default;
}, 1, "p", true)).V).V;
Invoke(Object_keys(PROF_14), "forEach", Fn((V _self2, int _argc779, V k_785, V _a782, V _a783, V _a784, V[] _rest780) => {
V X_786 = default;
X_786 = (GetK(C_22, k_785) is var _t787 && Truthy(_t787) ? _t787 : NewObj(0).V);
if (Truthy((GetK(RND_21, k_785) is var _t788 && !Truthy(_t788) ? _t788 : (!(Truthy(Get(X_786, "sp"))) ? V.True : V.False)))) {
Set(X_786, "sp", NewObj(6).Put("armL", ((V)(42D))).Put("armR", ((V)(42D))).Put("hLy", ((V)((-7D)))).Put("hRy", ((V)((-7D)))).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-1D)))).V);
}
Call(playBuild_10, V.Undef, k_785, X_786);
return default;
}, 1, "", true));
return default;
}, 1, "", false));
        }
    }
}
