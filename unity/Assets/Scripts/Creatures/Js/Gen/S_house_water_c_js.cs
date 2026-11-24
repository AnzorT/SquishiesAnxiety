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
sp_15 = Fn((V _self2, int _argc27, V t_33, V v_34, V d_35, V hold_36, V[] _rest28) => {
V b_37 = default;
b_37 = NewObj(0).V;
Invoke(Object_keys(v_34), "forEach", Fn((V _self2, int _argc38, V k_44, V _a41, V _a42, V _a43, V[] _rest39) => {
return SetK(b_37, k_44, (!GetK(Get(t_33, "B"), k_44).IsNullish ? GetK(Get(t_33, "B"), k_44) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_33, "to", ((V)((ToNum((d_35 is var _t47 && Truthy(_t47) ? _t47 : ((V)(700D)))) * 0.4))), v_34, ((V)("o"))), "wait", (hold_36 is var _t46 && Truthy(_t46) ? _t46 : ((V)(300D)))), "to", ((V)((ToNum((d_35 is var _t45 && Truthy(_t45) ? _t45 : ((V)(700D)))) * 0.6))), b_37, ((V)("io")));
return t_33;
return default;
}, 4, "", true);
bk_16 = Fn((V _self2, int _argc48, V t_54, V d_55, V _a52, V _a53, V[] _rest49) => {
return Invoke(t_54, "back", (d_55 is var _t56 && Truthy(_t56) ? _t56 : ((V)(420D))));
}, 2, "", true);
W_17 = Fn((V _self2, int _argc57, V a_63, V b_64, V _a61, V _a62, V[] _rest58) => {
return NewObj(3).Put("a", NewObj(1).Put("wag", a_63).V).Put("b", NewObj(1).Put("wag", ((V)((-ToNum(a_63))))).V).Put("f", (b_64 is var _t65 && Truthy(_t65) ? _t65 : NewObj(0).V)).V;
}, 2, "", true);
ears_18 = Fn((V _self2, int _argc66, V t_72, V n_73, V _a70, V _a71, V[] _rest67) => {
{
double i_74 = 0;
i_74 = 0D;
while (true) {
if (!(Lt(((V)(i_74)), (n_73 is var _t76 && Truthy(_t76) ? _t76 : ((V)(2D)))))) break;
Invoke(Invoke(t_72, "to", ((V)(110D)), NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)(14D))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(2).Put("earL", ((V)(10D))).Put("earR", ((V)((-10D)))).V);
i_74++;
}
}
return Invoke(t_72, "to", ((V)(140D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V);
return default;
}, 2, "", true);
spray_19 = Fn((V _self2, int _argc77, V t_83, V w_84, V n_85, V _a82, V[] _rest78) => {
return Invoke(t_83, "fx", ((V)("splash")), (w_84 is var _t86 && Truthy(_t86) ? _t86 : ((V)("body"))), (n_85 is var _t87 && Truthy(_t87) ? _t87 : ((V)(6D))));
}, 3, "", true);
C_20 = NewObj(81).Put("mittens", NewObj(2).Put("k", NewObj(3).Put("a", NewObj(1).Put("curl", ((V)(0.6))).V).Put("b", NewObj(1).Put("curl", ((V)(0.2))).V).Put("f", NewObj(1).Put("curl", ((V)(0.9))).V).V).Put("s", Fn((V _self2, int _argc88, V t_94, V _a91, V _a92, V _a93, V[] _rest89) => {
Invoke(Invoke(Invoke(t_94, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-13D)))), NewObj(2).Put("armR", ((V)(32D))).Put("close", ((V)(0.7))).V)), "osc", ((V)(1600D)), ((V)(5D)), NewObj(2).Put("tongue", ((V)(0.6))).Put("hRy", ((V)((-15D)))).V, NewObj(2).Put("tongue", ((V)(0.1))).Put("hRy", ((V)((-12D)))).V, ((V)("s"))), "to", ((V)(300D)), NewObj(1).Put("tongue", ((V)(0D))).V);
Call(bk_16, V.Undef, t_94);
return default;
}, 1, "s", true)).V).Put("biscuit", NewObj(2).Put("k", Call(W_17, V.Undef, ((V)(28D)), NewObj(2).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V)).Put("s", Fn((V _self2, int _argc95, V t_101, V _a98, V _a99, V _a100, V[] _rest96) => {
Invoke(Invoke(t_101, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V), "osc", ((V)(1500D)), ((V)(8D)), NewObj(2).Put("wag", ((V)(28D))).Put("lift", Add(Get(Get(t_101, "B"), "lift"), ((V)(0.6)))).V, NewObj(2).Put("wag", ((V)((-28D)))).Put("lift", Get(Get(t_101, "B"), "lift")).V, ((V)("o")));
Call(spray_19, V.Undef, t_101, ((V)("sideR")), ((V)(8D)));
Call(bk_16, V.Undef, t_101);
return default;
}, 1, "s", true)).V).Put("prickle", NewObj(2).Put("k", NewObj(1).Put("f", NewObj(1).Put("curl", ((V)(0.3))).V).V).Put("s", Fn((V _self2, int _argc102, V t_108, V _a105, V _a106, V _a107, V[] _rest103) => {
Call(sp_15, V.Undef, t_108, NewObj(6).Put("curl", ((V)(1D))).Put("sq", Add(Get(Get(t_108, "B"), "sq"), ((V)(0.14)))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).Put("lift", Add(Get(Get(t_108, "B"), "lift"), ((V)(2D)))).V, ((V)(1600D)), ((V)(1600D)));
Invoke(t_108, "fx", ((V)("bubble")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "s", true)).V).Put("truffle", NewObj(2).Put("k", Call(W_17, V.Undef, ((V)(20D)))).Put("s", Fn((V _self2, int _argc109, V t_115, V _a112, V _a113, V _a114, V[] _rest110) => {
Invoke(Invoke(t_115, "to", ((V)(300D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V), "osc", ((V)(1400D)), ((V)(6D)), NewObj(2).Put("tilt", ((V)(4D))).Put("wag", ((V)(22D))).V, NewObj(2).Put("tilt", ((V)((-4D)))).Put("wag", ((V)((-22D)))).V, ((V)("s")));
Call(spray_19, V.Undef, t_115, ((V)("body")), ((V)(6D)));
Call(bk_16, V.Undef, t_115);
return default;
}, 1, "s", true)).V).Put("ribbit", NewObj(2).Put("sw", ((V)("glide"))).Put("s", Fn((V _self2, int _argc116, V t_122, V _a119, V _a120, V _a121, V[] _rest117) => {
{
double i_123 = 0;
i_123 = 0D;
while (true) {
if (!((i_123 < 3D))) break;
Invoke(Invoke(Invoke(t_122, "to", ((V)(120D)), NewObj(4).Put("lift", Add(Get(Get(t_122, "B"), "lift"), ((V)(3D)))).Put("sq", ((V)((ToNum(Get(Get(t_122, "B"), "sq")) - 0.06)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", Get(Get(t_122, "B"), "lift")).Put("sq", Add(Get(Get(t_122, "B"), "sq"), ((V)(0.04)))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("body")), ((V)(4D)));
i_123++;
}
}
Call(bk_16, V.Undef, t_122);
return default;
}, 1, "s", true)).V).Put("nibbles", NewObj(2).Put("k", NewObj(1).Put("f", NewObj(1).Put("puff", ((V)(0.7))).V).V).Put("s", Fn((V _self2, int _argc125, V t_131, V _a128, V _a129, V _a130, V[] _rest126) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_131, "to", ((V)(400D)), NewObj(1).Put("puff", ((V)(1D))).V), "wait", ((V)(400D))), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gush")), ((V)("mouth")), ((V)(3D))), "fx", ((V)("bubble")), ((V)("mouth")), ((V)(2D)));
Call(bk_16, V.Undef, t_131);
return default;
}, 1, "s", true)).V).Put("quill", NewObj(2).Put("k", NewObj(1).Put("f", NewObj(1).Put("blush", ((V)(0.7))).V).V).Put("s", Fn((V _self2, int _argc132, V t_138, V _a135, V _a136, V _a137, V[] _rest133) => {
return Call(sp_15, V.Undef, t_138, Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(10D)), ((V)((-14D)))), NewObj(5).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("blush", ((V)(1D))).Put("sq", Add(Get(Get(t_138, "B"), "sq"), ((V)(0.04)))).Put("close", ((V)(0.6))).V), ((V)(1400D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("waffles", NewObj(2).Put("k", Call(W_17, V.Undef, ((V)(22D)))).Put("s", Fn((V _self2, int _argc139, V t_145, V _a142, V _a143, V _a144, V[] _rest140) => {
Invoke(Invoke(t_145, "to", ((V)(700D)), NewObj(4).Put("sk", Add(Get(Get(t_145, "B"), "sk"), ((V)(3D)))).Put("close", ((V)(0.9))).Put("smile", ((V)(1D))).Put("sq", Add(Get(Get(t_145, "B"), "sq"), ((V)(0.08)))).V, ((V)("s"))), "osc", ((V)(1600D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(16D))).V, NewObj(1).Put("wag", ((V)((-16D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_145, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("poppy", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(2).Put("earL", ((V)((-18D)))).Put("earR", ((V)(16D))).V).Put("b", NewObj(2).Put("earL", ((V)(16D))).Put("earR", ((V)((-18D)))).V).V).Put("s", Fn((V _self2, int _argc146, V t_152, V _a149, V _a150, V _a151, V[] _rest147) => {
{
double i_153 = 0;
i_153 = 0D;
while (true) {
if (!((i_153 < 3D))) break;
Invoke(Invoke(Invoke(t_152, "to", ((V)(140D)), NewObj(4).Put("lift", Add(Get(Get(t_152, "B"), "lift"), ((V)(3D)))).Put("sq", ((V)((ToNum(Get(Get(t_152, "B"), "sq")) - 0.06)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", Get(Get(t_152, "B"), "lift")).Put("sq", Add(Get(Get(t_152, "B"), "sq"), ((V)(0.04)))).V, ((V)("i"))), "fx", ((V)("splash")), ((V)("body")), ((V)(4D)));
i_153++;
}
}
Call(bk_16, V.Undef, t_152);
return default;
}, 1, "s", true)).V).Put("duchess", NewObj(2).Put("k", NewObj(1).Put("f", NewObj(1).Put("htilt", ((V)(8D))).V).V).Put("s", Fn((V _self2, int _argc155, V t_161, V _a158, V _a159, V _a160, V[] _rest156) => {
Invoke(Invoke(Invoke(Invoke(t_161, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-13D)))), NewObj(4).Put("armR", ((V)(34D))).Put("close", ((V)(0.7))).Put("htilt", ((V)(8D))).Put("pitch", Add(Get(Get(t_161, "B"), "pitch"), ((V)(0.12)))).V)), "wait", ((V)(1200D))), "to", ((V)(300D)), NewObj(1).Put("sqz", ((V)(0.5))).V), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_161);
return default;
}, 1, "s", true)).V).Put("mamapaws", NewObj(2).Put("k", Call(W_17, V.Undef, ((V)(14D)))).Put("s", Fn((V _self2, int _argc162, V t_168, V _a165, V _a166, V _a167, V[] _rest163) => {
Invoke(Invoke(Invoke(t_168, "to", ((V)(600D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(12D)), ((V)(1D))), NewObj(4).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("smile", ((V)(1D))).Put("close", ((V)(0.6))).V)), "fx", ((V)("heart")), ((V)("head"))), "osc", ((V)(1400D)), ((V)(2D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_168, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("nimbo", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _self2, int _argc169, V t_175, V _a172, V _a173, V _a174, V[] _rest170) => {
Invoke(Invoke(Invoke(Invoke(t_175, "fx", ((V)("drop")), ((V)("body")), ((V)(4D))), "osc", ((V)(1800D)), ((V)(3D)), NewObj(2).Put("sq", Add(Get(Get(t_175, "B"), "sq"), ((V)(0.06)))).Put("puff", ((V)(0.4))).V, NewObj(2).Put("sq", Get(Get(t_175, "B"), "sq")).Put("puff", ((V)(0D))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("body")), ((V)(4D))), "fx", ((V)("drop")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_175);
return default;
}, 1, "s", true)).V).Put("lumi", NewObj(1).Put("s", Fn((V _self2, int _argc176, V t_182, V _a179, V _a180, V _a181, V[] _rest177) => {
Invoke(Invoke(Invoke(t_182, "to", ((V)(500D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-10D)))), NewObj(4).Put("armR", ((V)(80D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).Put("ly", ((V)((-0.6)))).V), ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D))), "wait", ((V)(1200D)));
Call(bk_16, V.Undef, t_182, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("bubbly", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _self2, int _argc183, V t_189, V _a186, V _a187, V _a188, V[] _rest184) => {
{
double i_190 = 0;
i_190 = 0D;
while (true) {
if (!((i_190 < 3D))) break;
Invoke(Invoke(Invoke(t_189, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.6))).Put("sq", Add(Get(Get(t_189, "B"), "sq"), ((V)(0.05)))).V), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)(((i_190 == 2D) ? "bigbubble" : "bubble"))), ((V)("mouth")), ((V)(2D)));
i_190++;
}
}
Call(bk_16, V.Undef, t_189);
return default;
}, 1, "s", true)).V).Put("twinkle", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _self2, int _argc192, V t_198, V _a195, V _a196, V _a197, V[] _rest193) => {
Invoke(Invoke(Invoke(Invoke(t_198, "to", ((V)(300D)), NewObj(3).Put("glow", ((V)(1D))).Put("wide", ((V)(0.6))).Put("hap", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("body")), ((V)(6D))), "wait", ((V)(900D))), "to", ((V)(500D)), NewObj(1).Put("glow", ((V)(0D))).V);
Call(bk_16, V.Undef, t_198);
return default;
}, 1, "s", true)).V).Put("zappi", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(1).Put("zap", ((V)(0.8))).V).Put("b", NewObj(1).Put("zap", ((V)(0.3))).V).V).Put("s", Fn((V _self2, int _argc199, V t_205, V _a202, V _a203, V _a204, V[] _rest200) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_205, "to", ((V)(80D)), NewObj(3).Put("zap", ((V)(1D))).Put("x", ((V)(0.5))).Put("wide", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(420D)), ((V)(4D)), NewObj(1).Put("x", ((V)((-0.5)))).V, NewObj(1).Put("x", ((V)(0.5))).V, ((V)("l"))), "fx", ((V)("spark")), ((V)("body")), ((V)(6D))), "to", ((V)(300D)), NewObj(3).Put("zap", ((V)(0D))).Put("x", ((V)(0D))).Put("sqz", ((V)(0.6))).V), "to", ((V)(300D)), NewObj(1).Put("sqz", ((V)(0D))).V);
Call(bk_16, V.Undef, t_205);
return default;
}, 1, "s", true)).V).Put("plip", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc206, V t_212, V _a209, V _a210, V _a211, V[] _rest207) => {
Invoke(Invoke(t_212, "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_212, "B"), "sq"), ((V)(0.08)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_212, "B"), "sq")) - 0.03)))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D)));
Call(bk_16, V.Undef, t_212);
return default;
}, 1, "s", true)).V).Put("breeze", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _self2, int _argc213, V t_219, V _a216, V _a217, V _a218, V[] _rest214) => {
Invoke(Invoke(Invoke(Invoke(t_219, "to", ((V)(500D)), NewObj(2).Put("puff", ((V)(0.8))).Put("open", ((V)(0D))).V), "to", ((V)(500D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.35))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head"))), "fx", ((V)("splash")), ((V)("mouth")), ((V)(6D)));
Call(bk_16, V.Undef, t_219);
return default;
}, 1, "s", true)).V).Put("dusty", NewObj(1).Put("s", Fn((V _self2, int _argc220, V t_226, V _a223, V _a224, V _a225, V[] _rest221) => {
Invoke(Call(ears_18, V.Undef, t_226, ((V)(3D))), "fx", ((V)("dust")), ((V)("body")), ((V)(4D)));
Call(bk_16, V.Undef, t_226);
return default;
}, 1, "s", true)).V).Put("aurora", NewObj(3).Put("sw", ((V)("glide"))).Put("k", NewObj(1).Put("a", NewObj(1).Put("spout", ((V)(0.6))).V).V).Put("s", Fn((V _self2, int _argc227, V t_233, V _a230, V _a231, V _a232, V[] _rest228) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_233, "to", ((V)(300D)), NewObj(1).Put("spout", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("gush")), ((V)("head")), ((V)(4D))), "fx", ((V)("splash")), ((V)("head")), ((V)(6D))), "wait", ((V)(600D))), "to", ((V)(500D)), NewObj(2).Put("spout", ((V)(0D))).Put("glow", ((V)(0.8))).V), "wait", ((V)(700D)));
Call(bk_16, V.Undef, t_233, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("mallow", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc234, V t_240, V _a237, V _a238, V _a239, V[] _rest235) => {
return Call(sp_15, V.Undef, t_240, NewObj(4).Put("sq", Add(Get(Get(t_240, "B"), "sq"), ((V)(0.2)))).Put("sk", Add(Get(Get(t_240, "B"), "sk"), ((V)(2D)))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1800D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("bao", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc241, V t_247, V _a244, V _a245, V _a246, V[] _rest242) => {
Invoke(Invoke(Invoke(t_247, "fx", ((V)("steam")), ((V)("head"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(Get(t_247, "B"), "sq"), ((V)(0.06)))).V, NewObj(1).Put("sq", Get(Get(t_247, "B"), "sq")).V, ((V)("s"))), "fx", ((V)("steam")), ((V)("head")));
Call(bk_16, V.Undef, t_247);
return default;
}, 1, "s", true)).V).Put("dunkie", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc248, V t_254, V _a251, V _a252, V _a253, V[] _rest249) => {
Invoke(Invoke(t_254, "osc", ((V)(1800D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("turn", ((V)(0.3))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("turn", ((V)((-0.3)))).V, ((V)("s"))), "fx", ((V)("sprinkle")), ((V)("head")));
Call(bk_16, V.Undef, t_254);
return default;
}, 1, "s", true)).V).Put("frybo", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("fw", ((V)(1D))).V).Put("b", NewObj(1).Put("fw", ((V)(0.3))).V).V).Put("s", Fn((V _self2, int _argc255, V t_261, V _a258, V _a259, V _a260, V[] _rest256) => {
Call(sp_15, V.Undef, t_261, NewObj(3).Put("fw", ((V)(1D))).Put("smile", ((V)(1D))).Put("hap", ((V)(1D))).V, ((V)(1200D)), ((V)(900D)));
Invoke(t_261, "fx", ((V)("salt")), ((V)("head")));
return default;
}, 1, "s", true)).V).Put("bunbun", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("split", ((V)(0.4))).V).Put("b", NewObj(1).Put("split", ((V)(0.1))).V).V).Put("s", Fn((V _self2, int _argc262, V t_268, V _a265, V _a266, V _a267, V[] _rest263) => {
return Call(sp_15, V.Undef, t_268, NewObj(3).Put("split", ((V)(0.5))).Put("shuf", ((V)(0.4))).Put("hap", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "s", true)).V).Put("choco", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc269, V t_275, V _a272, V _a273, V _a274, V[] _rest270) => {
return Call(sp_15, V.Undef, t_275, NewObj(3).Put("melt", ((V)(0.5))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "s", true)).V).Put("scoop", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("chb", ((V)(1D))).V).Put("b", NewObj(1).Put("chb", ((V)(0D))).V).V).Put("s", Fn((V _self2, int _argc276, V t_282, V _a279, V _a280, V _a281, V[] _rest277) => {
Invoke(Invoke(t_282, "osc", ((V)(1500D)), ((V)(3D)), NewObj(1).Put("chb", ((V)(0.9))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_282);
return default;
}, 1, "s", true)).V).Put("boba", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(1).Put("a", NewObj(1).Put("slurp", ((V)(0.5))).V).V).Put("s", Fn((V _self2, int _argc283, V t_289, V _a286, V _a287, V _a288, V[] _rest284) => {
Invoke(Invoke(t_289, "osc", ((V)(1600D)), ((V)(3D)), NewObj(2).Put("slurp", ((V)(0.6))).Put("sqz", ((V)(0.4))).V, NewObj(2).Put("slurp", ((V)(0D))).Put("sqz", ((V)(0D))).V, ((V)("s"))), "fx", ((V)("bubble")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_289);
return default;
}, 1, "s", true)).V).Put("chefbun", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc290, V t_296, V _a293, V _a294, V _a295, V[] _rest291) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_296, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-13D)))), NewObj(1).Put("armR", ((V)(34D))).V)), "wait", ((V)(300D))), "to", ((V)(260D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-14D)))), NewObj(2).Put("armR", ((V)(60D))).Put("smile", ((V)(1D))).V), ((V)("o"))), "fx", ((V)("heart")), ((V)("head"))), "wait", ((V)(500D)));
Call(bk_16, V.Undef, t_296, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("pip", NewObj(3).Put("sw", ((V)("glide"))).Put("k", NewObj(2).Put("a", NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(20D))).V).Put("b", NewObj(2).Put("armL", ((V)(20D))).Put("armR", ((V)(60D))).V).V).Put("s", Fn((V _self2, int _argc297, V t_303, V _a300, V _a301, V _a302, V[] _rest298) => {
Invoke(t_303, "osc", ((V)(1400D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, NewObj(2).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("o")));
Call(spray_19, V.Undef, t_303, ((V)("body")), ((V)(8D)));
Call(bk_16, V.Undef, t_303);
return default;
}, 1, "s", true)).V).Put("jelli", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _self2, int _argc304, V t_310, V _a307, V _a308, V _a309, V[] _rest305) => {
{
double i_311 = 0;
i_311 = 0D;
while (true) {
if (!((i_311 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(t_310, "to", ((V)(400D)), NewObj(1).Put("sq", Add(Get(Get(t_310, "B"), "sq"), ((V)(0.1)))).V, ((V)("i"))), "to", ((V)(500D)), NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_310, "B"), "sq")) - 0.05)))).Put("lift", Add(Get(Get(t_310, "B"), "lift"), ((V)(1.4)))).V, ((V)("o"))), "fx", ((V)("bubble")), ((V)("body")), ((V)(2D))), "to", ((V)(500D)), NewObj(2).Put("sq", Get(Get(t_310, "B"), "sq")).Put("lift", Get(Get(t_310, "B"), "lift")).V, ((V)("s")));
i_311++;
}
}
Call(bk_16, V.Undef, t_310, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("finn", NewObj(4).Put("sw", ((V)("glide"))).Put("k", Call(W_17, V.Undef, ((V)(26D)))).Put("s", Fn((V _self2, int _argc313, V t_319, V _a316, V _a317, V _a318, V[] _rest314) => {
Invoke(t_319, "osc", ((V)(1600D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("s")));
Call(spray_19, V.Undef, t_319, ((V)("tail")), ((V)(8D)));
Call(bk_16, V.Undef, t_319);
return default;
}, 1, "s", true)).Put("ws", Fn((V _self2, int _argc320, V t_326, V _a323, V _a324, V _a325, V[] _rest321) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_326, "to", ((V)(300D)), NewObj(1).Put("puff", ((V)(0.6))).V), "to", ((V)(160D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gush")), ((V)("blow")), ((V)(5D))), "fx", ((V)("splash")), ((V)("blow")), ((V)(6D))), "wait", ((V)(400D))), "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.6))).V);
Call(bk_16, V.Undef, t_326);
return default;
}, 1, "ws", true)).V).Put("sealy", NewObj(2).Put("sw", ((V)("glide"))).Put("s", Fn((V _self2, int _argc327, V t_333, V _a330, V _a331, V _a332, V[] _rest328) => {
Invoke(Invoke(t_333, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.4))).V, NewObj(1).Put("open", ((V)(0.05))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(4).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, NewObj(4).Put("hLx", ((V)(7D))).Put("hRx", ((V)((-7D)))).Put("armL", ((V)(14D))).Put("armR", ((V)(14D))).V, ((V)("o")));
Call(spray_19, V.Undef, t_333, ((V)("body")), ((V)(6D)));
Call(bk_16, V.Undef, t_333, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("puff", NewObj(3).Put("sw", ((V)("glide"))).Put("k", NewObj(1).Put("f", NewObj(1).Put("blo", ((V)(0.4))).V).V).Put("s", Fn((V _self2, int _argc334, V t_340, V _a337, V _a338, V _a339, V[] _rest335) => {
Invoke(Invoke(Invoke(Invoke(t_340, "to", ((V)(900D)), NewObj(3).Put("blo", ((V)(0.9))).Put("puff", ((V)(0.8))).Put("lift", Add(Get(Get(t_340, "B"), "lift"), ((V)(2D)))).V, ((V)("s"))), "wait", ((V)(700D))), "to", ((V)(500D)), NewObj(2).Put("blo", ((V)(0D))).Put("puff", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("bubble")), ((V)("mouth")), ((V)(4D)));
Call(bk_16, V.Undef, t_340);
return default;
}, 1, "s", true)).V).Put("shelly", NewObj(2).Put("sw", ((V)("glide"))).Put("s", Fn((V _self2, int _argc341, V t_347, V _a344, V _a345, V _a346, V[] _rest342) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_347, "to", ((V)(600D)), NewObj(1).Put("hid", ((V)(0.8))).V, ((V)("io"))), "fx", ((V)("bubble")), ((V)("head")), ((V)(2D))), "wait", ((V)(1400D))), "to", ((V)(400D)), NewObj(2).Put("hid", ((V)(0D))).Put("nk", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(500D)));
Call(bk_16, V.Undef, t_347);
return default;
}, 1, "s", true)).V).Put("octo", NewObj(4).Put("sw", ((V)("glide"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("osp", ((V)(1D))).V).Put("b", NewObj(1).Put("osp", ((V)(0.3))).V).V).Put("s", Fn((V _self2, int _argc348, V t_354, V _a351, V _a352, V _a353, V[] _rest349) => {
return Call(sp_15, V.Undef, t_354, NewObj(3).Put("ow", ((V)(1D))).Put("osp", ((V)(0.8))).Put("hap", ((V)(1D))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "s", true)).Put("ws", Fn((V _self2, int _argc355, V t_361, V _a358, V _a359, V _a360, V[] _rest356) => {
Invoke(Invoke(Invoke(Invoke(t_361, "to", ((V)(300D)), NewObj(2).Put("ojt", ((V)(1D))).Put("sq", ((V)((ToNum(Get(Get(t_361, "B"), "sq")) - 0.12)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("ink", ((V)(1D))).V, ((V)("l"))), "fx", ((V)("bubble")), ((V)("body")), ((V)(3D))), "to", ((V)(400D)), NewObj(3).Put("ojt", ((V)(0D))).Put("ink", ((V)(0D))).Put("sq", Get(Get(t_361, "B"), "sq")).V);
Call(bk_16, V.Undef, t_361);
return default;
}, 1, "ws", true)).V).Put("marina", NewObj(3).Put("sw", ((V)("glide"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("tsw", ((V)(0.8))).V).Put("b", NewObj(1).Put("tsw", ((V)((-0.8)))).V).V).Put("s", Fn((V _self2, int _argc362, V t_368, V _a365, V _a366, V _a367, V[] _rest363) => {
Invoke(Invoke(Invoke(Invoke(t_368, "to", ((V)(500D)), NewObj(1).Put("tlf", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)(0.6))).V, NewObj(1).Put("tsw", ((V)((-0.6)))).V, ((V)("s"))), "fx", ((V)("splash")), ((V)("tail")), ((V)(7D))), "to", ((V)(500D)), NewObj(2).Put("tlf", ((V)(0D))).Put("tsw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_368);
return default;
}, 1, "s", true)).V).Put("pearl", NewObj(3).Put("sw", ((V)("glide"))).Put("s", Fn((V _self2, int _argc369, V t_375, V _a372, V _a373, V _a374, V[] _rest370) => {
Call(sp_15, V.Undef, t_375, NewObj(2).Put("glow", ((V)(1D))).Put("hsw", ((V)(0.6))).V, ((V)(1600D)), ((V)(1200D)));
Invoke(t_375, "fx", ((V)("spark")), ((V)("head")), ((V)(4D)));
return default;
}, 1, "s", true)).Put("ws", Fn((V _self2, int _argc376, V t_382, V _a379, V _a380, V _a381, V[] _rest377) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_382, "to", ((V)(300D)), NewObj(1).Put("puff", ((V)(0.6))).V), "to", ((V)(160D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "fx", ((V)("gush")), ((V)("head")), ((V)(4D))), "fx", ((V)("splash")), ((V)("head")), ((V)(6D))), "to", ((V)(400D)), NewObj(1).Put("glow", ((V)(1D))).V), "wait", ((V)(400D))), "to", ((V)(400D)), NewObj(1).Put("glow", ((V)(0D))).V);
Call(bk_16, V.Undef, t_382);
return default;
}, 1, "ws", true)).V).Put("pina", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("crw", ((V)(1D))).V).Put("b", NewObj(1).Put("crw", ((V)(0.3))).V).V).Put("s", Fn((V _self2, int _argc383, V t_389, V _a386, V _a387, V _a388, V[] _rest384) => {
Invoke(Invoke(Invoke(t_389, "to", ((V)(300D)), NewObj(1).Put("crw", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("crs", ((V)(0.4))).V, NewObj(1).Put("crs", ((V)(0D))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(1).Put("crw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_389);
return default;
}, 1, "s", true)).V).Put("avo", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc390, V t_396, V _a393, V _a394, V _a395, V[] _rest391) => {
Invoke(Invoke(Invoke(Invoke(t_396, "to", ((V)(300D)), NewObj(1).Put("prw", ((V)(0.9))).V), "wait", ((V)(1000D))), "to", ((V)(400D)), NewObj(1).Put("prw", ((V)(0D))).V), "fx", ((V)("bubble")), ((V)("belly")), ((V)(2D)));
Call(bk_16, V.Undef, t_396);
return default;
}, 1, "s", true)).V).Put("berri", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("stw", ((V)(1D))).V).Put("b", NewObj(1).Put("stw", ((V)(0D))).V).V).Put("s", Fn((V _self2, int _argc397, V t_403, V _a400, V _a401, V _a402, V[] _rest398) => {
Invoke(Invoke(Invoke(t_403, "to", ((V)(120D)), NewObj(1).Put("stw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(900D)), NewObj(1).Put("stw", ((V)(0D))).V), "fx", ((V)("juice")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_403);
return default;
}, 1, "s", true)).V).Put("lemmy", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc404, V t_410, V _a407, V _a408, V _a409, V[] _rest405) => {
return Call(sp_15, V.Undef, t_410, NewObj(3).Put("sqz", ((V)(0.9))).Put("mw", ((V)(0.5))).Put("frown", ((V)(0.2))).V, ((V)(1000D)), ((V)(900D)));
}, 1, "s", true)).V).Put("kiwi", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(3).Put("a", NewObj(1).Put("fzz", ((V)(1D))).V).Put("b", NewObj(1).Put("fzz", ((V)(0.6))).V).Put("f", NewObj(1).Put("fzz", ((V)(1D))).V).V).Put("s", Fn((V _self2, int _argc411, V t_417, V _a414, V _a415, V _a416, V[] _rest412) => {
return Call(sp_15, V.Undef, t_417, NewObj(2).Put("fzz", ((V)(0.8))).Put("sqz", ((V)(0.5))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "s", true)).V).Put("melo", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("sdj", ((V)(1D))).V).Put("b", NewObj(1).Put("sdj", ((V)(0D))).V).V).Put("s", Fn((V _self2, int _argc418, V t_424, V _a421, V _a422, V _a423, V[] _rest419) => {
Invoke(Invoke(t_424, "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("sdj", ((V)(1D))).V, NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("meloseed")), ((V)("mouth")), ((V)(2D)));
Call(bk_16, V.Undef, t_424);
return default;
}, 1, "s", true)).V).Put("peachy", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc425, V t_431, V _a428, V _a429, V _a430, V[] _rest426) => {
return Call(sp_15, V.Undef, t_431, NewObj(3).Put("blush", ((V)(1D))).Put("lfl", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("pitaya", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("wfl", ((V)(1D))).V).Put("b", NewObj(1).Put("wfl", ((V)(0.4))).V).V).Put("s", Fn((V _self2, int _argc432, V t_438, V _a435, V _a436, V _a437, V[] _rest433) => {
Call(sp_15, V.Undef, t_438, NewObj(3).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.6))).Put("brf", ((V)(0.5))).V, ((V)(1400D)), ((V)(1000D)));
Call(spray_19, V.Undef, t_438, ((V)("body")), ((V)(5D)));
return default;
}, 1, "s", true)).V).Put("tutti", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(1).Put("a", NewObj(1).Put("wfl", ((V)(1D))).V).V).Put("s", Fn((V _self2, int _argc439, V t_445, V _a442, V _a443, V _a444, V[] _rest440) => {
Call(sp_15, V.Undef, t_445, NewObj(1).Put("wfl", ((V)(0.8))).V, ((V)(1400D)), ((V)(1000D)));
Invoke(t_445, "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("kiko", NewObj(1).Put("s", Fn((V _self2, int _argc446, V t_452, V _a449, V _a450, V _a451, V[] _rest447) => {
Invoke(Call(ears_18, V.Undef, t_452, ((V)(2D))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_452);
return default;
}, 1, "s", true)).V).Put("teddy", NewObj(1).Put("s", Fn((V _self2, int _argc453, V t_459, V _a456, V _a457, V _a458, V[] _rest454) => {
Invoke(Invoke(t_459, "to", ((V)(500D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(14D)), ((V)((-4D)))), NewObj(4).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("smile", ((V)(1D))).Put("blush", ((V)(0.5))).V)), "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("tongue", ((V)(0.4))).V, NewObj(1).Put("tongue", ((V)(0D))).V, ((V)("s")));
Call(bk_16, V.Undef, t_459, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("hoot", NewObj(2).Put("k", NewObj(3).Put("a", NewObj(2).Put("tfl", ((V)(1D))).Put("wfl", ((V)(1D))).V).Put("b", NewObj(1).Put("tfl", ((V)(0.4))).V).Put("f", NewObj(1).Put("tfl", ((V)(1D))).V).V).Put("s", Fn((V _self2, int _argc460, V t_466, V _a463, V _a464, V _a465, V[] _rest461) => {
Invoke(Invoke(t_466, "to", ((V)(300D)), NewObj(3).Put("wfl", ((V)(1D))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).V, NewObj(2).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("l")));
Call(spray_19, V.Undef, t_466, ((V)("sideL")), ((V)(5D)));
Call(spray_19, V.Undef, t_466, ((V)("sideR")), ((V)(5D)));
Call(bk_16, V.Undef, t_466);
return default;
}, 1, "s", true)).V).Put("leo", NewObj(2).Put("k", NewObj(3).Put("a", NewObj(2).Put("msh", ((V)(1D))).Put("mfl", ((V)(1D))).V).Put("b", NewObj(1).Put("msh", ((V)(0.4))).V).Put("f", NewObj(1).Put("mfl", ((V)(1D))).V).V).Put("s", Fn((V _self2, int _argc467, V t_473, V _a470, V _a471, V _a472, V[] _rest468) => {
Invoke(Invoke(Invoke(t_473, "to", ((V)(400D)), NewObj(3).Put("mfl", ((V)(0.8))).Put("open", ((V)(0.4))).Put("puff", ((V)(0.3))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(3).Put("mfl", ((V)(0D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).V);
Call(bk_16, V.Undef, t_473);
return default;
}, 1, "s", true)).V).Put("panko", NewObj(1).Put("s", Fn((V _self2, int _argc474, V t_480, V _a477, V _a478, V _a479, V[] _rest475) => {
Invoke(Invoke(t_480, "to", ((V)(500D)), NewObj(2).Put("sk", Add(Get(Get(t_480, "B"), "sk"), ((V)(3D)))).Put("close", ((V)(0.9))).V, ((V)("s"))), "osc", ((V)(1800D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("x", ((V)(1D))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("x", ((V)((-1D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_480);
return default;
}, 1, "s", true)).V).Put("acorn", NewObj(2).Put("k", NewObj(3).Put("a", NewObj(1).Put("tfl", ((V)(1D))).V).Put("b", NewObj(1).Put("tfl", ((V)(0.5))).V).Put("f", NewObj(1).Put("tfl", ((V)(1D))).V).V).Put("s", Fn((V _self2, int _argc481, V t_487, V _a484, V _a485, V _a486, V[] _rest482) => {
return Call(sp_15, V.Undef, t_487, NewObj(2).Put("tfl", ((V)(1D))).Put("tsw", ((V)(0.6))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "s", true)).V).Put("fawn", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(2).Put("earL", ((V)((-18D)))).Put("earR", ((V)(18D))).V).Put("b", NewObj(2).Put("earL", ((V)(18D))).Put("earR", ((V)((-18D)))).V).V).Put("s", Fn((V _self2, int _argc488, V t_494, V _a491, V _a492, V _a493, V[] _rest489) => {
Call(ears_18, V.Undef, t_494, ((V)(3D)));
Call(bk_16, V.Undef, t_494);
return default;
}, 1, "s", true)).V).Put("moss", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("cb", ((V)(1D))).V).Put("b", NewObj(1).Put("cb", ((V)(0D))).V).V).Put("s", Fn((V _self2, int _argc495, V t_501, V _a498, V _a499, V _a500, V[] _rest496) => {
Invoke(Invoke(t_501, "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("cb", ((V)(0.9))).V, NewObj(1).Put("cb", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("spore")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_501);
return default;
}, 1, "s", true)).V).Put("sprout", NewObj(2).Put("k", NewObj(1).Put("f", NewObj(1).Put("blm", ((V)(1D))).V).V).Put("s", Fn((V _self2, int _argc502, V t_508, V _a505, V _a506, V _a507, V[] _rest503) => {
return Call(sp_15, V.Undef, t_508, NewObj(2).Put("blm", ((V)(1D))).Put("lfl", ((V)(0.6))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "s", true)).V).Put("hana", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(2).Put("flL", ((V)(0.6))).Put("tw", ((V)(1D))).V).Put("b", NewObj(2).Put("flR", ((V)(0.6))).Put("tw", ((V)((-1D)))).V).V).Put("s", Fn((V _self2, int _argc509, V t_515, V _a512, V _a513, V _a514, V[] _rest510) => {
Invoke(Invoke(Invoke(t_515, "to", ((V)(400D)), NewObj(2).Put("flL", ((V)(0.9))).Put("flR", ((V)(0.9))).V), "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("tw", ((V)(1D))).V, NewObj(1).Put("tw", ((V)((-1D)))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(2).Put("flL", ((V)(0D))).Put("flR", ((V)(0D))).V);
Call(bk_16, V.Undef, t_515);
return default;
}, 1, "s", true)).V).Put("boo", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _self2, int _argc516, V t_522, V _a519, V _a520, V _a521, V[] _rest517) => {
return Call(sp_15, V.Undef, t_522, NewObj(2).Put("gho", ((V)(0.5))).Put("flr", ((V)(0.6))).V, ((V)(1800D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("pixie", NewObj(3).Put("sw", ((V)("float"))).Put("k", NewObj(1).Put("a", NewObj(1).Put("wfl", ((V)(1D))).V).V).Put("s", Fn((V _self2, int _argc523, V t_529, V _a526, V _a527, V _a528, V[] _rest524) => {
Call(sp_15, V.Undef, t_529, NewObj(3).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.5))).Put("lift", Add(Get(Get(t_529, "B"), "lift"), ((V)(2D)))).V, ((V)(1400D)), ((V)(1000D)));
Invoke(t_529, "fx", ((V)("dust")), ((V)("body")), ((V)(4D)));
return default;
}, 1, "s", true)).V).Put("floof", NewObj(2).Put("k", NewObj(3).Put("a", NewObj(1).Put("fzz", ((V)(1D))).V).Put("b", NewObj(1).Put("fzz", ((V)(0.7))).V).Put("f", NewObj(1).Put("fzz", ((V)(1D))).V).V).Put("s", Fn((V _self2, int _argc530, V t_536, V _a533, V _a534, V _a535, V[] _rest531) => {
Invoke(Invoke(Invoke(t_536, "to", ((V)(200D)), NewObj(1).Put("fzz", ((V)(0.9))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(1).Put("fzz", ((V)(0D))).V);
Call(bk_16, V.Undef, t_536);
return default;
}, 1, "s", true)).V).Put("unibun", NewObj(1).Put("s", Fn((V _self2, int _argc537, V t_543, V _a540, V _a541, V _a542, V[] _rest538) => {
Invoke(t_543, "fx", ((V)("spark")), ((V)("head")), ((V)(5D)));
Call(ears_18, V.Undef, t_543, ((V)(2D)));
Call(bk_16, V.Undef, t_543);
return default;
}, 1, "s", true)).V).Put("gumdrop", NewObj(3).Put("sw", ((V)("bob"))).Put("k", NewObj(2).Put("a", NewObj(1).Put("jig", ((V)(1D))).V).Put("b", NewObj(1).Put("jig", ((V)(0.4))).V).V).Put("s", Fn((V _self2, int _argc544, V t_550, V _a547, V _a548, V _a549, V[] _rest545) => {
return Call(sp_15, V.Undef, t_550, NewObj(2).Put("jig", ((V)(1D))).Put("hap", ((V)(1D))).V, ((V)(1200D)), ((V)(1000D)));
}, 1, "s", true)).V).Put("ember", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(1).Put("cfl", ((V)(0.6))).V).Put("f", NewObj(1).Put("cfl", ((V)(1D))).V).V).Put("s", Fn((V _self2, int _argc551, V t_557, V _a554, V _a555, V _a556, V[] _rest552) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_557, "to", ((V)(300D)), NewObj(3).Put("cfl", ((V)(0D))).Put("wide", ((V)(0.8))).Put("open", ((V)(0.3))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("head"))), "fx", ((V)("steam")), ((V)("body"))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(3).Put("cfl", ((V)(0.8))).Put("sqz", ((V)(0.6))).Put("smile", ((V)(1D))).V), "fx", ((V)("steam")), ((V)("head")));
Call(bk_16, V.Undef, t_557);
return default;
}, 1, "s", true)).V).Put("drako", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(2).Put("wsp", ((V)(1D))).Put("tsw", ((V)(0.8))).V).Put("b", NewObj(1).Put("tsw", ((V)((-0.8)))).V).V).Put("s", Fn((V _self2, int _argc558, V t_564, V _a561, V _a562, V _a563, V[] _rest559) => {
Invoke(Invoke(Invoke(Invoke(t_564, "to", ((V)(400D)), NewObj(1).Put("puff", ((V)(0.6))).V), "to", ((V)(200D)), NewObj(1).Put("puff", ((V)(0D))).V), "fx", ((V)("steam")), ((V)("head"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)(0.7))).V, NewObj(1).Put("tsw", ((V)((-0.7)))).V, ((V)("s")));
Call(spray_19, V.Undef, t_564, ((V)("tail")), ((V)(6D)));
Call(bk_16, V.Undef, t_564);
return default;
}, 1, "s", true)).V).Put("jinni", NewObj(2).Put("sw", ((V)("float"))).Put("s", Fn((V _self2, int _argc565, V t_571, V _a568, V _a569, V _a570, V[] _rest566) => {
Call(sp_15, V.Undef, t_571, NewObj(2).Put("glo", ((V)(0.8))).Put("gwh", ((V)(0.6))).V, ((V)(1600D)), ((V)(1200D)));
Invoke(t_571, "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("cuppy", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc572, V t_578, V _a575, V _a576, V _a577, V[] _rest573) => {
Invoke(Invoke(t_578, "fx", ((V)("sprinkle")), ((V)("head"))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_578, "B"), "sq"), ((V)(0.05)))).V, NewObj(1).Put("sq", Get(Get(t_578, "B"), "sq")).V, ((V)("o")));
Call(bk_16, V.Undef, t_578);
return default;
}, 1, "s", true)).V).Put("chip", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc579, V t_585, V _a582, V _a583, V _a584, V[] _rest580) => {
Invoke(Invoke(t_585, "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.5))).V, NewObj(1).Put("x", ((V)((-0.5)))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_585, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("twisty", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc586, V t_592, V _a589, V _a590, V _a591, V[] _rest587) => {
Invoke(Invoke(t_592, "osc", ((V)(2000D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(5D))).V, NewObj(1).Put("tilt", ((V)((-5D)))).V, ((V)("s"))), "fx", ((V)("salt")), ((V)("head")));
Call(bk_16, V.Undef, t_592);
return default;
}, 1, "s", true)).V).Put("crois", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc593, V t_599, V _a596, V _a597, V _a598, V[] _rest594) => {
return Call(sp_15, V.Undef, t_599, NewObj(3).Put("lean", ((V)(1.4))).Put("tilt", ((V)(3D))).Put("smile", ((V)(1D))).V, ((V)(1800D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("maca", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc600, V t_606, V _a603, V _a604, V _a605, V[] _rest601) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_606, "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_606, "B"), "sq"), ((V)(0.1)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_606, "B"), "sq")).V), "wait", ((V)(300D))), "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_606, "B"), "sq"), ((V)(0.08)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_606, "B"), "sq")).V);
Call(bk_16, V.Undef, t_606, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("puddi", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc607, V t_613, V _a610, V _a611, V _a612, V[] _rest608) => {
Invoke(t_613, "osc", ((V)(1600D)), ((V)(6D)), NewObj(2).Put("sq", Add(Get(Get(t_613, "B"), "sq"), ((V)(0.06)))).Put("x", ((V)(0.3))).V, NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_613, "B"), "sq")) - 0.02)))).Put("x", ((V)((-0.3)))).V, ((V)("l")));
Call(bk_16, V.Undef, t_613);
return default;
}, 1, "s", true)).V).Put("mochi", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc614, V t_620, V _a617, V _a618, V _a619, V[] _rest615) => {
return Call(sp_15, V.Undef, t_620, NewObj(3).Put("sq", Add(Get(Get(t_620, "B"), "sq"), ((V)(0.16)))).Put("smile", ((V)(1D))).Put("close", ((V)(0.6))).V, ((V)(1800D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("cakey", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc621, V t_627, V _a624, V _a625, V _a626, V[] _rest622) => {
Invoke(Invoke(Invoke(Invoke(t_627, "to", ((V)(500D)), NewObj(1).Put("puff", ((V)(0.7))).V), "to", ((V)(600D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(300D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V);
Call(bk_16, V.Undef, t_627);
return default;
}, 1, "s", true)).V).Put("sugarplum", NewObj(1).Put("s", Fn((V _self2, int _argc628, V t_634, V _a631, V _a632, V _a633, V[] _rest629) => {
Invoke(Invoke(Invoke(t_634, "to", ((V)(400D)), NewObj(3).Put("armR", ((V)(70D))).Put("hRy", ((V)((-2D)))).Put("smile", ((V)(0.9))).V, ((V)("o"))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-3D)))).V, NewObj(1).Put("hRx", ((V)(3D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_634, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("gourdy", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc635, V t_641, V _a638, V _a639, V _a640, V[] _rest636) => {
Invoke(t_641, "osc", ((V)(2400D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(6D))).Put("x", ((V)(1D))).V, NewObj(2).Put("tilt", ((V)((-6D)))).Put("x", ((V)((-1D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_641);
return default;
}, 1, "s", true)).V).Put("batty", NewObj(2).Put("k", NewObj(2).Put("a", NewObj(2).Put("armL", ((V)(80D))).Put("armR", ((V)(40D))).V).Put("b", NewObj(2).Put("armL", ((V)(40D))).Put("armR", ((V)(80D))).V).V).Put("s", Fn((V _self2, int _argc642, V t_648, V _a645, V _a646, V _a647, V[] _rest643) => {
return Call(sp_15, V.Undef, t_648, NewObj(4).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).Put("hLx", ((V)(12D))).Put("hRx", ((V)((-12D)))).V, ((V)(1200D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("kernel", NewObj(2).Put("sw", ((V)("bob"))).Put("s", Fn((V _self2, int _argc649, V t_655, V _a652, V _a653, V _a654, V[] _rest650) => {
Invoke(Invoke(Invoke(t_655, "to", ((V)(120D)), NewObj(2).Put("lift", Add(Get(Get(t_655, "B"), "lift"), ((V)(3D)))).Put("sq", ((V)((ToNum(Get(Get(t_655, "B"), "sq")) - 0.06)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("lift", Get(Get(t_655, "B"), "lift")).Put("sq", Add(Get(Get(t_655, "B"), "sq"), ((V)(0.04)))).V, ((V)("i"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(spray_19, V.Undef, t_655, ((V)("body")), ((V)(5D)));
Call(bk_16, V.Undef, t_655);
return default;
}, 1, "s", true)).V).Put("hexie", NewObj(1).Put("s", Fn((V _self2, int _argc656, V t_662, V _a659, V _a660, V _a661, V[] _rest657) => {
Call(sp_15, V.Undef, t_662, NewObj(1).Put("curl", ((V)(0.7))).V, ((V)(1400D)), ((V)(1200D)));
Invoke(t_662, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("mumbles", NewObj(1).Put("s", Fn((V _self2, int _argc663, V t_669, V _a666, V _a667, V _a668, V[] _rest664) => {
Invoke(Invoke(Invoke(t_669, "to", ((V)(900D)), NewObj(5).Put("armL", ((V)(88D))).Put("armR", ((V)(88D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("open", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(1000D))), "to", ((V)(900D)), NewObj(5).Put("armL", Get(Get(t_669, "B"), "armL")).Put("armR", Get(Get(t_669, "B"), "armR")).Put("hLy", Get(Get(t_669, "B"), "hLy")).Put("hRy", Get(Get(t_669, "B"), "hRy")).Put("open", ((V)(0D))).V, ((V)("io")));
Call(bk_16, V.Undef, t_669, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("hocus", NewObj(1).Put("s", Fn((V _self2, int _argc670, V t_676, V _a673, V _a674, V _a675, V[] _rest671) => {
Invoke(Invoke(Invoke(t_676, "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(800D))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_676, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("countsquishula", NewObj(1).Put("s", Fn((V _self2, int _argc677, V t_683, V _a680, V _a681, V _a682, V[] _rest678) => {
Invoke(Invoke(Invoke(t_683, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)((-1D))), ((V)(10D)), ((V)((-14D)))), NewObj(3).Put("armL", ((V)(60D))).Put("close", ((V)(0.4))).Put("smile", ((V)(0.6))).V)), "wait", ((V)(1000D))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_683, ((V)(500D)));
return default;
}, 1, "s", true)).V).V;
Invoke(Object_keys(PROF_14), "forEach", Fn((V _self2, int _argc684, V k_690, V _a687, V _a688, V _a689, V[] _rest685) => {
return Call(waterBuild_10, V.Undef, k_690, (GetK(C_20, k_690) is var _t691 && Truthy(_t691) ? _t691 : NewObj(0).V));
}, 1, "", true));
return default;
}, 1, "", false));
        }
    }
}
