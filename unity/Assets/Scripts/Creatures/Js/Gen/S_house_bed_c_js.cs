// house-bed-c.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house_bed_c_js
    {

        public static void Run()
        {
Set(G("window"), "HouseCreatures", (Get(G("window"), "HouseCreatures") is var _t1 && Truthy(_t1) ? _t1 : Arr()));
Invoke(Get(G("window"), "HouseCreatures"), "push", Fn((V _self2, int _argc3, V H_9, V _a6, V _a7, V _a8, V[] _rest4) => {
V bedBuild_10 = default;
V hand_11 = default;
V both_12 = default;
V o_13 = default;
V PROF_14 = default;
V sp_15 = default;
V bk_16 = default;
V ear_17 = default;
V B_18 = default;
if (_self2.IsNullish) _self2 = GlobalV;
{ V _t19 = H_9;
if (_t19.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t19));
{ V _t20 = Get(_t19, "bedBuild");
bedBuild_10 = _t20; }
{ V _t21 = Get(_t19, "hand");
hand_11 = _t21; }
{ V _t22 = Get(_t19, "both");
both_12 = _t22; }
{ V _t23 = Get(_t19, "o");
o_13 = _t23; }
{ V _t24 = Get(_t19, "PROF");
PROF_14 = _t24; } }
sp_15 = Fn((V _self2, int _argc25, V t_31, V v_32, V d_33, V hold_34, V[] _rest26) => {
V b_35 = default;
b_35 = NewObj(0).V;
Invoke(Object_keys(v_32), "forEach", Fn((V _self2, int _argc36, V k_42, V _a39, V _a40, V _a41, V[] _rest37) => {
return SetK(b_35, k_42, (!GetK(Get(t_31, "B"), k_42).IsNullish ? GetK(Get(t_31, "B"), k_42) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_31, "to", ((V)((ToNum((d_33 is var _t45 && Truthy(_t45) ? _t45 : ((V)(700D)))) * 0.4))), v_32, ((V)("o"))), "wait", (hold_34 is var _t44 && Truthy(_t44) ? _t44 : ((V)(300D)))), "to", ((V)((ToNum((d_33 is var _t43 && Truthy(_t43) ? _t43 : ((V)(700D)))) * 0.6))), b_35, ((V)("io")));
return t_31;
return default;
}, 4, "", true);
bk_16 = Fn((V _self2, int _argc46, V t_52, V d_53, V _a50, V _a51, V[] _rest47) => {
return Invoke(t_52, "back", (d_53 is var _t54 && Truthy(_t54) ? _t54 : ((V)(420D))));
}, 2, "", true);
ear_17 = Fn((V _self2, int _argc55, V t_61, V s_62, V a_63, V _a60, V[] _rest56) => {
V e_64 = default;
e_64 = ((V)((LtN(s_62, 0D) ? "earL" : "earR")));
Invoke(Invoke(Invoke(t_61, "to", ((V)(90D)), NewObj(1).PutK(e_64, ((V)((-ToNum((a_63 is var _t65 && Truthy(_t65) ? _t65 : ((V)(10D)))))))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(1).PutK(e_64, ((V)(3D))).V), "to", ((V)(150D)), NewObj(1).PutK(e_64, ((V)(0D))).V);
return t_61;
return default;
}, 3, "", true);
B_18 = NewObj(81).Put("mittens", NewObj(3).Put("dr", ((V)("fish"))).Put("wk", NewObj(3).Put("curl", ((V)(0.6))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).V).Put("s", Fn((V _self2, int _argc66, V t_72, V _a69, V _a70, V _a71, V[] _rest67) => {
Invoke(Invoke(t_72, "to", ((V)(400D)), NewObj(2).Put("curl", ((V)(0.8))).Put("smile", ((V)(0.7))).V), "osc", ((V)(2600D)), ((V)(6D)), NewObj(3).Put("hLy", Add(Get(Get(t_72, "B"), "hLy"), ((V)(3D)))).Put("hRy", Get(Get(t_72, "B"), "hRy")).Put("sq", Add(Get(Get(t_72, "B"), "sq"), ((V)(0.012)))).V, NewObj(3).Put("hLy", Get(Get(t_72, "B"), "hLy")).Put("hRy", Add(Get(Get(t_72, "B"), "hRy"), ((V)(3D)))).Put("sq", Get(Get(t_72, "B"), "sq")).V, ((V)("s")));
Call(bk_16, V.Undef, t_72, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("biscuit", NewObj(3).Put("dr", ((V)("bone"))).Put("wk", NewObj(3).Put("wag", ((V)(24D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V).Put("s", Fn((V _self2, int _argc73, V t_79, V _a76, V _a77, V _a78, V[] _rest74) => {
Invoke(Invoke(Invoke(t_79, "to", ((V)(200D)), NewObj(1).Put("open", ((V)(0.12))).V), "osc", ((V)(2000D)), ((V)(10D)), NewObj(3).Put("footL", Add(Get(Get(t_79, "B"), "footL"), ((V)(2.4)))).Put("footR", Get(Get(t_79, "B"), "footR")).Put("wag", ((V)(16D))).V, NewObj(3).Put("footL", Get(Get(t_79, "B"), "footL")).Put("footR", Add(Get(Get(t_79, "B"), "footR"), ((V)(2.4)))).Put("wag", ((V)((-16D)))).V, ((V)("l"))), "osc", ((V)(800D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.3))).V, NewObj(1).Put("open", ((V)(0.05))).V, ((V)("o")));
Call(bk_16, V.Undef, t_79, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("prickle", NewObj(4).Put("dr", ((V)("apple"))).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(2D)))).Put("bp", NewObj(2).Put("curl", ((V)(1D))).Put("sq", ((V)(0.3))).V).Put("s", Fn((V _self2, int _argc80, V t_86, V _a83, V _a84, V _a85, V[] _rest81) => {
return Call(sp_15, V.Undef, t_86, NewObj(4).Put("curl", ((V)(1D))).Put("sq", Add(Get(Get(t_86, "B"), "sq"), ((V)(0.12)))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V, ((V)(1400D)), ((V)(2200D)));
}, 1, "s", true)).V).Put("truffle", NewObj(3).Put("dr", ((V)("apple"))).Put("wk", NewObj(1).Put("wag", ((V)(18D))).V).Put("s", Fn((V _self2, int _argc87, V t_93, V _a90, V _a91, V _a92, V[] _rest88) => {
return Call(sp_15, V.Undef, t_93, NewObj(3).Put("sq", Add(Get(Get(t_93, "B"), "sq"), ((V)(0.12)))).Put("smile", ((V)(0.9))).Put("blush", ((V)(0.6))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("ribbit", NewObj(2).Put("dr", ((V)("leaf"))).Put("s", Fn((V _self2, int _argc94, V t_100, V _a97, V _a98, V _a99, V[] _rest95) => {
{
V i_101 = default;
i_101 = ((V)(0D));
while (true) {
if (!(LtN(i_101, 2D))) break;
Invoke(Invoke(Invoke(t_100, "to", ((V)(300D)), NewObj(1).Put("sq", Add(Get(Get(t_100, "B"), "sq"), ((V)(0.06)))).V, ((V)("i"))), "to", ((V)(500D)), NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_100, "B"), "sq")) - 0.03)))).Put("lift", Add(Get(Get(t_100, "B"), "lift"), ((V)(0.8)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("sq", Get(Get(t_100, "B"), "sq")).Put("lift", Get(Get(t_100, "B"), "lift")).V, ((V)("s")));
PostInc(ref i_101, 1D);
}
}
Call(bk_16, V.Undef, t_100, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("nibbles", NewObj(3).Put("dr", ((V)("nut"))).Put("wk", NewObj(1).Put("puff", ((V)(0.6))).V).Put("s", Fn((V _self2, int _argc103, V t_109, V _a106, V _a107, V _a108, V[] _rest104) => {
Invoke(Invoke(Invoke(t_109, "to", ((V)(300D)), NewObj(1).Put("puff", ((V)(0.9))).V), "osc", ((V)(1800D)), ((V)(6D)), NewObj(2).Put("open", ((V)(0.15))).Put("htilt", Add(Get(Get(t_109, "B"), "htilt"), ((V)(2D)))).V, NewObj(2).Put("open", ((V)(0D))).Put("htilt", ((V)((ToNum(Get(Get(t_109, "B"), "htilt")) - 2D)))).V, ((V)("s"))), "fx", ((V)("crumb")), ((V)("head")));
Call(bk_16, V.Undef, t_109, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("quill", NewObj(3).Put("dr", ((V)("flower"))).Put("wk", NewObj(1).Put("blush", ((V)(0.6))).V).Put("s", Fn((V _self2, int _argc110, V t_116, V _a113, V _a114, V _a115, V[] _rest111) => {
return Call(sp_15, V.Undef, t_116, NewObj(3).Put("blush", ((V)(0.9))).Put("smile", ((V)(0.9))).Put("htilt", Add(Get(Get(t_116, "B"), "htilt"), ((V)(5D)))).V, ((V)(1400D)), ((V)(1600D)));
}, 1, "s", true)).V).Put("waffles", NewObj(3).Put("dr", ((V)("cookie"))).Put("wk", NewObj(1).Put("wag", ((V)(18D))).V).Put("s", Fn((V _self2, int _argc117, V t_123, V _a120, V _a121, V _a122, V[] _rest118) => {
Invoke(Invoke(t_123, "to", ((V)(800D)), NewObj(2).Put("sq", Add(Get(Get(t_123, "B"), "sq"), ((V)(0.1)))).Put("lift", ((V)((ToNum(Get(Get(t_123, "B"), "lift")) - 1D)))).V, ((V)("s"))), "osc", ((V)(1600D)), ((V)(5D)), NewObj(1).Put("footL", Add(Get(Get(t_123, "B"), "footL"), ((V)(2D)))).V, NewObj(1).Put("footL", Get(Get(t_123, "B"), "footL")).V, ((V)("l")));
Call(bk_16, V.Undef, t_123, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("poppy", NewObj(3).Put("dr", ((V)("carrot"))).Put("wk", NewObj(2).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).V).Put("s", Fn((V _self2, int _argc124, V t_130, V _a127, V _a128, V _a129, V[] _rest125) => {
Invoke(t_130, "osc", ((V)(1200D)), ((V)(6D)), NewObj(2).Put("sqz", ((V)(0.4))).Put("ly", ((V)((-0.1)))).V, NewObj(2).Put("sqz", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("l")));
Call(ear_17, V.Undef, t_130, ((V)((-1D))), ((V)(10D)));
Call(bk_16, V.Undef, t_130, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("duchess", NewObj(4).Put("dr", ((V)("fish"))).Put("lp", NewObj(1).Put("htilt", ((V)(9D))).V).Put("wk", NewObj(1).Put("htilt", ((V)(8D))).V).Put("s", Fn((V _self2, int _argc131, V t_137, V _a134, V _a135, V _a136, V[] _rest132) => {
Invoke(Invoke(t_137, "to", ((V)(500D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-13D)))), NewObj(1).Put("armR", ((V)(30D))).V)), "osc", ((V)(1600D)), ((V)(4D)), NewObj(1).Put("tongue", ((V)(0.5))).V, NewObj(1).Put("tongue", ((V)(0.1))).V, ((V)("s")));
Call(bk_16, V.Undef, t_137, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("mamapaws", NewObj(5).Put("dr", ((V)("heart"))).Put("lp", Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(9D)), ((V)(3D))), NewObj(2).Put("armL", ((V)(14D))).Put("armR", ((V)(14D))).V)).Put("bp", Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(9D)), ((V)(3D))), NewObj(3).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("curl", ((V)(0.6))).V)).Put("wk", NewObj(1).Put("wag", ((V)(12D))).V).Put("s", Fn((V _self2, int _argc138, V t_144, V _a141, V _a142, V _a143, V[] _rest139) => {
Invoke(Invoke(Invoke(t_144, "to", ((V)(600D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(12D)), ((V)(1D))), NewObj(3).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("smile", ((V)(0.9))).V)), "fx", ((V)("heart")), ((V)("head"))), "wait", ((V)(1400D)));
Call(bk_16, V.Undef, t_144, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("nimbo", NewObj(3).Put("dr", ((V)("sun"))).Put("wfx", Arr(((V)("drop")), ((V)("body")), ((V)(4D)))).Put("s", Fn((V _self2, int _argc145, V t_151, V _a148, V _a149, V _a150, V[] _rest146) => {
Invoke(Invoke(Invoke(t_151, "fx", ((V)("drop")), ((V)("body")), ((V)(3D))), "osc", ((V)(2400D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(Get(t_151, "B"), "sq"), ((V)(0.06)))).V, NewObj(1).Put("sq", Get(Get(t_151, "B"), "sq")).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_151, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("lumi", NewObj(3).Put("dr", ((V)("star"))).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(4D)))).Put("s", Fn((V _self2, int _argc152, V t_158, V _a155, V _a156, V _a157, V[] _rest153) => {
Invoke(Invoke(Invoke(t_158, "to", ((V)(600D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-8D)))), NewObj(1).Put("armR", ((V)(40D))).V)), "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "wait", ((V)(1600D)));
Call(bk_16, V.Undef, t_158, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("bubbly", NewObj(3).Put("dr", ((V)("bubble"))).Put("wfx", Arr(((V)("bubble")), ((V)("head")))).Put("s", Fn((V _self2, int _argc159, V t_165, V _a162, V _a163, V _a164, V[] _rest160) => {
Invoke(Invoke(t_165, "osc", ((V)(2400D)), ((V)(2D)), NewObj(2).Put("turn", ((V)(0.3))).Put("x", ((V)(0.8))).V, NewObj(2).Put("turn", ((V)((-0.3)))).Put("x", ((V)((-0.8)))).V, ((V)("s"))), "fx", ((V)("bubble")), ((V)("head")));
Call(bk_16, V.Undef, t_165, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("twinkle", NewObj(4).Put("dr", ((V)("moon"))).Put("zc", ((V)("#c9962a"))).Put("wfx", Arr(((V)("spark")), ((V)("body")), ((V)(6D)))).Put("s", Fn((V _self2, int _argc166, V t_172, V _a169, V _a170, V _a171, V[] _rest167) => {
Invoke(Invoke(Invoke(Invoke(t_172, "to", ((V)(400D)), NewObj(1).Put("glow", ((V)(1D))).V), "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(1200D))), "to", ((V)(600D)), NewObj(1).Put("glow", ((V)(0D))).V);
Call(bk_16, V.Undef, t_172, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("zappi", NewObj(4).Put("dr", ((V)("bolt"))).Put("wk", NewObj(1).Put("zap", ((V)(1D))).V).Put("wfx", Arr(((V)("spark")), ((V)("body")), ((V)(6D)))).Put("s", Fn((V _self2, int _argc173, V t_179, V _a176, V _a177, V _a178, V[] _rest174) => {
Invoke(Invoke(Invoke(Invoke(t_179, "to", ((V)(80D)), NewObj(2).Put("zap", ((V)(0.7))).Put("x", ((V)(0.5))).V, ((V)("o"))), "osc", ((V)(400D)), ((V)(4D)), NewObj(1).Put("x", ((V)((-0.5)))).V, NewObj(1).Put("x", ((V)(0.5))).V, ((V)("l"))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("zap", ((V)(0D))).Put("x", ((V)(0D))).V);
Call(bk_16, V.Undef, t_179, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("plip", NewObj(3).Put("dr", ((V)("rainbow"))).Put("wfx", Arr(((V)("drop")), ((V)("head")), ((V)(3D)))).Put("s", Fn((V _self2, int _argc180, V t_186, V _a183, V _a184, V _a185, V[] _rest181) => {
Invoke(Invoke(t_186, "fx", ((V)("drop")), ((V)("head")), ((V)(2D))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_186, "B"), "sq"), ((V)(0.06)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_186, "B"), "sq")) - 0.02)))).V, ((V)("o")));
Call(bk_16, V.Undef, t_186, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("breeze", NewObj(3).Put("dr", ((V)("cloud"))).Put("wfx", Arr(((V)("gust")), ((V)("head")))).Put("s", Fn((V _self2, int _argc187, V t_193, V _a190, V _a191, V _a192, V[] _rest188) => {
Invoke(Invoke(Invoke(t_193, "to", ((V)(500D)), NewObj(2).Put("puff", ((V)(0.6))).Put("open", ((V)(0.2))).V), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(700D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
Call(bk_16, V.Undef, t_193, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("dusty", NewObj(3).Put("dr", ((V)("star"))).Put("wfx", Arr(((V)("dust")), ((V)("body")), ((V)(4D)))).Put("s", Fn((V _self2, int _argc194, V t_200, V _a197, V _a198, V _a199, V[] _rest195) => {
Invoke(t_200, "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
Call(ear_17, V.Undef, t_200, ((V)(1D)), ((V)(10D)));
Call(ear_17, V.Undef, t_200, ((V)((-1D))), ((V)(8D)));
Call(bk_16, V.Undef, t_200, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("aurora", NewObj(4).Put("dr", ((V)("rainbow"))).Put("wk", NewObj(1).Put("spout", ((V)(1D))).V).Put("wfx", Arr(((V)("drop")), ((V)("head")), ((V)(4D)))).Put("s", Fn((V _self2, int _argc201, V t_207, V _a204, V _a205, V _a206, V[] _rest202) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_207, "to", ((V)(400D)), NewObj(1).Put("spout", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D))), "wait", ((V)(800D))), "to", ((V)(500D)), NewObj(2).Put("spout", ((V)(0D))).Put("glow", ((V)(0.8))).V), "wait", ((V)(800D)));
Call(bk_16, V.Undef, t_207, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("mallow", NewObj(2).Put("dr", ((V)("cup"))).Put("s", Fn((V _self2, int _argc208, V t_214, V _a211, V _a212, V _a213, V[] _rest209) => {
return Call(sp_15, V.Undef, t_214, NewObj(3).Put("sq", Add(Get(Get(t_214, "B"), "sq"), ((V)(0.18)))).Put("lift", ((V)((ToNum(Get(Get(t_214, "B"), "lift")) - 1.4)))).Put("smile", ((V)(0.9))).V, ((V)(2000D)), ((V)(1600D)));
}, 1, "s", true)).V).Put("bao", NewObj(3).Put("dr", ((V)("star"))).Put("wfx", Arr(((V)("steam")), ((V)("head")))).Put("s", Fn((V _self2, int _argc215, V t_221, V _a218, V _a219, V _a220, V[] _rest216) => {
Invoke(Invoke(Invoke(t_221, "fx", ((V)("steam")), ((V)("head"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(Get(t_221, "B"), "sq"), ((V)(0.05)))).V, NewObj(1).Put("sq", Get(Get(t_221, "B"), "sq")).V, ((V)("s"))), "fx", ((V)("steam")), ((V)("head")));
Call(bk_16, V.Undef, t_221, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("dunkie", NewObj(3).Put("dr", ((V)("cup"))).Put("wfx", Arr(((V)("sprinkle")), ((V)("head")))).Put("s", Fn((V _self2, int _argc222, V t_228, V _a225, V _a226, V _a227, V[] _rest223) => {
Invoke(Invoke(t_228, "osc", ((V)(1600D)), ((V)(3D)), NewObj(2).Put("tilt", Add(Get(Get(t_228, "B"), "tilt"), ((V)(3D)))).Put("x", ((V)(0.6))).V, NewObj(2).Put("tilt", ((V)((ToNum(Get(Get(t_228, "B"), "tilt")) - 3D)))).Put("x", ((V)((-0.6)))).V, ((V)("s"))), "fx", ((V)("sprinkle")), ((V)("head")));
Call(bk_16, V.Undef, t_228, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("frybo", NewObj(3).Put("dr", ((V)("ketchup"))).Put("wk", NewObj(1).Put("fw", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc229, V t_235, V _a232, V _a233, V _a234, V[] _rest230) => {
Call(sp_15, V.Undef, t_235, NewObj(2).Put("fw", ((V)(0.8))).Put("smile", ((V)(0.8))).V, ((V)(1400D)), ((V)(1200D)));
Invoke(t_235, "fx", ((V)("salt")), ((V)("head")));
return default;
}, 1, "s", true)).V).Put("bunbun", NewObj(3).Put("dr", ((V)("cheese"))).Put("wk", NewObj(1).Put("split", ((V)(0.4))).V).Put("s", Fn((V _self2, int _argc236, V t_242, V _a239, V _a240, V _a241, V[] _rest237) => {
return Call(sp_15, V.Undef, t_242, NewObj(2).Put("split", ((V)(0.3))).Put("shuf", ((V)(0.3))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "s", true)).V).Put("choco", NewObj(2).Put("dr", ((V)("heart"))).Put("s", Fn((V _self2, int _argc243, V t_249, V _a246, V _a247, V _a248, V[] _rest244) => {
return Call(sp_15, V.Undef, t_249, NewObj(2).Put("melt", ((V)(0.45))).Put("smile", ((V)(1D))).V, ((V)(2000D)), ((V)(1800D)));
}, 1, "s", true)).V).Put("scoop", NewObj(3).Put("dr", ((V)("cherry"))).Put("wk", NewObj(1).Put("chb", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc250, V t_256, V _a253, V _a254, V _a255, V[] _rest251) => {
Invoke(t_256, "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("chb", ((V)(0.8))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_256, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("boba", NewObj(3).Put("dr", ((V)("pearl"))).Put("wk", NewObj(1).Put("slurp", ((V)(0.6))).V).Put("s", Fn((V _self2, int _argc257, V t_263, V _a260, V _a261, V _a262, V[] _rest258) => {
Invoke(t_263, "osc", ((V)(1800D)), ((V)(3D)), NewObj(2).Put("slurp", ((V)(0.5))).Put("sqz", ((V)(0.3))).V, NewObj(2).Put("slurp", ((V)(0D))).Put("sqz", ((V)(0D))).V, ((V)("s")));
Call(bk_16, V.Undef, t_263, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("chefbun", NewObj(2).Put("dr", ((V)("cake"))).Put("s", Fn((V _self2, int _argc264, V t_270, V _a267, V _a268, V _a269, V[] _rest265) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_270, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-13D)))), NewObj(1).Put("armR", ((V)(34D))).V)), "wait", ((V)(300D))), "to", ((V)(260D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-14D)))), NewObj(2).Put("armR", ((V)(60D))).Put("smile", ((V)(1D))).V), ((V)("o"))), "fx", ((V)("heart")), ((V)("head"))), "wait", ((V)(500D)));
Call(bk_16, V.Undef, t_270, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("pip", NewObj(3).Put("dr", ((V)("fish"))).Put("wk", NewObj(2).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V).Put("s", Fn((V _self2, int _argc271, V t_277, V _a274, V _a275, V _a276, V[] _rest272) => {
Invoke(t_277, "osc", ((V)(1400D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).V, NewObj(2).Put("armL", ((V)(4D))).Put("armR", ((V)(4D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_277, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("jelli", NewObj(3).Put("dr", ((V)("bubble"))).Put("wfx", Arr(((V)("bubble")), ((V)("head")))).Put("s", Fn((V _self2, int _argc278, V t_284, V _a281, V _a282, V _a283, V[] _rest279) => {
{
V i_285 = default;
i_285 = ((V)(0D));
while (true) {
if (!(LtN(i_285, 3D))) break;
Invoke(Invoke(Invoke(t_284, "to", ((V)(400D)), NewObj(1).Put("sq", Add(Get(Get(t_284, "B"), "sq"), ((V)(0.08)))).V, ((V)("i"))), "to", ((V)(600D)), NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_284, "B"), "sq")) - 0.04)))).Put("lift", Add(Get(Get(t_284, "B"), "lift"), ((V)(0.8)))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(2).Put("sq", Get(Get(t_284, "B"), "sq")).Put("lift", Get(Get(t_284, "B"), "lift")).V, ((V)("s")));
PostInc(ref i_285, 1D);
}
}
Call(bk_16, V.Undef, t_284, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("finn", NewObj(4).Put("dr", ((V)("shell"))).Put("wk", NewObj(1).Put("wag", ((V)(24D))).V).Put("wfx", Arr(((V)("drop")), ((V)("body")), ((V)(4D)))).Put("s", Fn((V _self2, int _argc287, V t_293, V _a290, V _a291, V _a292, V[] _rest288) => {
Invoke(Invoke(t_293, "osc", ((V)(2000D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(20D))).V, NewObj(1).Put("wag", ((V)((-20D)))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("body")), ((V)(2D)));
Call(bk_16, V.Undef, t_293, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("sealy", NewObj(2).Put("dr", ((V)("fish"))).Put("s", Fn((V _self2, int _argc294, V t_300, V _a297, V _a298, V _a299, V[] _rest295) => {
Invoke(Invoke(t_300, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.35))).V, NewObj(1).Put("open", ((V)(0.05))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(4).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, NewObj(4).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-6D)))).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_300, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("puff", NewObj(3).Put("dr", ((V)("bubble"))).Put("wfx", Arr(((V)("bubble")), ((V)("head")))).Put("s", Fn((V _self2, int _argc301, V t_307, V _a304, V _a305, V _a306, V[] _rest302) => {
Invoke(Invoke(Invoke(Invoke(t_307, "to", ((V)(1200D)), NewObj(2).Put("blo", ((V)(0.5))).Put("puff", ((V)(0.5))).V, ((V)("s"))), "fx", ((V)("bubble")), ((V)("head"))), "wait", ((V)(800D))), "to", ((V)(1400D)), NewObj(2).Put("blo", ((V)(0D))).Put("puff", ((V)(0D))).V, ((V)("s")));
Call(bk_16, V.Undef, t_307, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("shelly", NewObj(4).Put("dr", ((V)("leaf"))).Put("wk", NewObj(1).Put("nk", ((V)(1D))).V).Put("bp", NewObj(1).Put("hid", ((V)(0.35))).V).Put("s", Fn((V _self2, int _argc308, V t_314, V _a311, V _a312, V _a313, V[] _rest309) => {
Invoke(Invoke(Invoke(t_314, "to", ((V)(700D)), NewObj(1).Put("hid", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(2000D))), "to", ((V)(500D)), NewObj(1).Put("hid", (Get(Get(t_314, "B"), "hid") is var _t315 && Truthy(_t315) ? _t315 : ((V)(0D)))).V, ((V)("io")));
Call(bk_16, V.Undef, t_314, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("octo", NewObj(3).Put("dr", ((V)("shell"))).Put("wk", NewObj(1).Put("osp", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc316, V t_322, V _a319, V _a320, V _a321, V[] _rest317) => {
return Call(sp_15, V.Undef, t_322, NewObj(2).Put("ocl", ((V)(0.8))).Put("ow", ((V)(0.6))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "s", true)).V).Put("marina", NewObj(3).Put("dr", ((V)("pearl"))).Put("wk", NewObj(1).Put("tlf", ((V)(0.6))).V).Put("s", Fn((V _self2, int _argc323, V t_329, V _a326, V _a327, V _a328, V[] _rest324) => {
Invoke(Invoke(Invoke(t_329, "to", ((V)(500D)), NewObj(1).Put("tlf", ((V)(0.6))).V, ((V)("o"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("tsw", ((V)(0.5))).V, NewObj(1).Put("tsw", ((V)((-0.5)))).V, ((V)("s"))), "to", ((V)(500D)), NewObj(2).Put("tlf", ((V)(0D))).Put("tsw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_329, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("pearl", NewObj(4).Put("dr", ((V)("star"))).Put("wk", NewObj(1).Put("glow", ((V)(1D))).V).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(4D)))).Put("s", Fn((V _self2, int _argc330, V t_336, V _a333, V _a334, V _a335, V[] _rest331) => {
Call(sp_15, V.Undef, t_336, NewObj(1).Put("glow", ((V)(1D))).V, ((V)(1800D)), ((V)(1400D)));
Invoke(t_336, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("pina", NewObj(3).Put("dr", ((V)("sun"))).Put("wk", NewObj(1).Put("crw", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc337, V t_343, V _a340, V _a341, V _a342, V[] _rest338) => {
Invoke(Invoke(Invoke(t_343, "to", ((V)(300D)), NewObj(1).Put("crw", ((V)(0.7))).V, ((V)("o"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("crs", ((V)(0.3))).V, NewObj(1).Put("crs", ((V)(0D))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(1).Put("crw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_343, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("avo", NewObj(3).Put("dr", ((V)("leaf"))).Put("wk", NewObj(1).Put("pp", ((V)(0.3))).V).Put("s", Fn((V _self2, int _argc344, V t_350, V _a347, V _a348, V _a349, V[] _rest345) => {
Invoke(Invoke(Invoke(t_350, "to", ((V)(300D)), NewObj(1).Put("prw", ((V)(0.8))).V), "wait", ((V)(1200D))), "to", ((V)(400D)), NewObj(1).Put("prw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_350, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("berri", NewObj(3).Put("dr", ((V)("cake"))).Put("wk", NewObj(1).Put("stw", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc351, V t_357, V _a354, V _a355, V _a356, V[] _rest352) => {
Invoke(Invoke(t_357, "to", ((V)(120D)), NewObj(1).Put("stw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(1000D)), NewObj(1).Put("stw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_357, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("lemmy", NewObj(3).Put("dr", ((V)("cup"))).Put("wk", NewObj(1).Put("sqz", ((V)(0.6))).V).Put("s", Fn((V _self2, int _argc358, V t_364, V _a361, V _a362, V _a363, V[] _rest359) => {
return Call(sp_15, V.Undef, t_364, NewObj(3).Put("sqz", ((V)(0.8))).Put("mw", ((V)(0.5))).Put("frown", ((V)(0.2))).V, ((V)(1000D)), ((V)(900D)));
}, 1, "s", true)).V).Put("kiwi", NewObj(3).Put("dr", ((V)("flower"))).Put("wk", NewObj(1).Put("fzz", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc365, V t_371, V _a368, V _a369, V _a370, V[] _rest366) => {
return Call(sp_15, V.Undef, t_371, NewObj(1).Put("fzz", ((V)(0.6))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("melo", NewObj(3).Put("dr", ((V)("sun"))).Put("wk", NewObj(1).Put("sdj", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc372, V t_378, V _a375, V _a376, V _a377, V[] _rest373) => {
Invoke(t_378, "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("sdj", ((V)(1D))).V, NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_378, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("peachy", NewObj(3).Put("dr", ((V)("flower"))).Put("wk", NewObj(1).Put("blush", ((V)(0.8))).V).Put("s", Fn((V _self2, int _argc379, V t_385, V _a382, V _a383, V _a384, V[] _rest380) => {
return Call(sp_15, V.Undef, t_385, NewObj(3).Put("blush", ((V)(1D))).Put("lfl", ((V)(0.5))).Put("smile", ((V)(0.9))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("pitaya", NewObj(3).Put("dr", ((V)("moon"))).Put("wk", NewObj(2).Put("wsp", ((V)(1D))).Put("wfl", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc386, V t_392, V _a389, V _a390, V _a391, V[] _rest387) => {
return Call(sp_15, V.Undef, t_392, NewObj(2).Put("wfl", ((V)(0.7))).Put("wsp", ((V)(0.5))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("tutti", NewObj(4).Put("dr", ((V)("cherry"))).Put("wk", NewObj(1).Put("wfl", ((V)(1D))).V).Put("wfx", Arr(((V)("dust")), ((V)("body")), ((V)(3D)))).Put("s", Fn((V _self2, int _argc393, V t_399, V _a396, V _a397, V _a398, V[] _rest394) => {
Call(sp_15, V.Undef, t_399, NewObj(1).Put("wfl", ((V)(0.6))).V, ((V)(1400D)), ((V)(1000D)));
Invoke(t_399, "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("kiko", NewObj(3).Put("dr", ((V)("leaf"))).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(3D)))).Put("s", Fn((V _self2, int _argc400, V t_406, V _a403, V _a404, V _a405, V[] _rest401) => {
Invoke(Invoke(Invoke(t_406, "to", ((V)(90D)), NewObj(2).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("earL", ((V)(3D))).Put("earR", ((V)(3D))).V), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_406, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("teddy", NewObj(2).Put("dr", ((V)("honey"))).Put("s", Fn((V _self2, int _argc407, V t_413, V _a410, V _a411, V _a412, V[] _rest408) => {
Invoke(Invoke(t_413, "to", ((V)(500D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(14D)), ((V)((-4D)))), NewObj(4).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("smile", ((V)(1D))).Put("blush", ((V)(0.5))).V)), "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("tongue", ((V)(0.4))).V, NewObj(1).Put("tongue", ((V)(0D))).V, ((V)("s")));
Call(bk_16, V.Undef, t_413, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("hoot", NewObj(3).Put("dr", ((V)("moon"))).Put("wk", NewObj(2).Put("tfl", ((V)(1D))).Put("wfl", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc414, V t_420, V _a417, V _a418, V _a419, V[] _rest415) => {
Invoke(Invoke(Invoke(Invoke(t_420, "to", ((V)(300D)), NewObj(5).Put("close", ((V)(0D))).Put("winkL", ((V)(1D))).Put("tfl", ((V)(0.6))).Put("lx", ((V)(0.6))).Put("zz", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(1400D))), "to", ((V)(400D)), NewObj(4).Put("close", ((V)(1D))).Put("winkL", ((V)(0D))).Put("tfl", ((V)(0D))).Put("lx", ((V)(0D))).V), "to", ((V)(400D)), NewObj(1).Put("zz", ((V)(1D))).V);
Call(bk_16, V.Undef, t_420, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("leo", NewObj(3).Put("dr", ((V)("crown"))).Put("wk", NewObj(2).Put("mfl", ((V)(1D))).Put("msh", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc421, V t_427, V _a424, V _a425, V _a426, V[] _rest422) => {
Invoke(Invoke(Invoke(t_427, "to", ((V)(400D)), NewObj(3).Put("mfl", ((V)(0.7))).Put("open", ((V)(0.35))).Put("puff", ((V)(0.3))).V, ((V)("o"))), "wait", ((V)(600D))), "to", ((V)(600D)), NewObj(3).Put("mfl", ((V)(0D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).V);
Call(bk_16, V.Undef, t_427, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("panko", NewObj(2).Put("dr", ((V)("bamboo"))).Put("s", Fn((V _self2, int _argc428, V t_434, V _a431, V _a432, V _a433, V[] _rest429) => {
Invoke(t_434, "osc", ((V)(2000D)), ((V)(6D)), NewObj(2).Put("open", ((V)(0.2))).Put("puff", ((V)(0.5))).V, NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.2))).V, ((V)("s")));
Call(bk_16, V.Undef, t_434, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("acorn", NewObj(3).Put("dr", ((V)("acorn"))).Put("wk", NewObj(1).Put("tfl", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc435, V t_441, V _a438, V _a439, V _a440, V[] _rest436) => {
return Call(sp_15, V.Undef, t_441, NewObj(2).Put("tfl", ((V)(1D))).Put("tsw", ((V)(0.5))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("fawn", NewObj(3).Put("dr", ((V)("flower"))).Put("wk", NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).V).Put("s", Fn((V _self2, int _argc442, V t_448, V _a445, V _a446, V _a447, V[] _rest443) => {
Invoke(Call(ear_17, V.Undef, t_448, ((V)((-1D))), ((V)(12D))), "wait", ((V)(500D)));
Call(ear_17, V.Undef, t_448, ((V)(1D)), ((V)(12D)));
Call(bk_16, V.Undef, t_448, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("moss", NewObj(3).Put("dr", ((V)("drop"))).Put("wk", NewObj(1).Put("cb", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc449, V t_455, V _a452, V _a453, V _a454, V[] _rest450) => {
Invoke(Invoke(t_455, "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("cb", ((V)(0.8))).V, NewObj(1).Put("cb", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("dust")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_455, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("sprout", NewObj(3).Put("dr", ((V)("sun"))).Put("wk", NewObj(1).Put("blm", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc456, V t_462, V _a459, V _a460, V _a461, V[] _rest457) => {
return Call(sp_15, V.Undef, t_462, NewObj(1).Put("blm", ((V)(0.8))).V, ((V)(1800D)), ((V)(1800D)));
}, 1, "s", true)).V).Put("hana", NewObj(3).Put("dr", ((V)("carrot"))).Put("wk", NewObj(1).Put("tw", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc463, V t_469, V _a466, V _a467, V _a468, V[] _rest464) => {
Invoke(Invoke(Invoke(t_469, "to", ((V)(400D)), NewObj(1).Put("flL", ((V)(0.8))).V), "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("tw", ((V)(1D))).V, NewObj(1).Put("tw", ((V)((-1D)))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(1).Put("flL", ((V)(0D))).V);
Call(bk_16, V.Undef, t_469, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("boo", NewObj(2).Put("dr", ((V)("heart"))).Put("s", Fn((V _self2, int _argc470, V t_476, V _a473, V _a474, V _a475, V[] _rest471) => {
return Call(sp_15, V.Undef, t_476, NewObj(1).Put("gho", ((V)(0.45))).V, ((V)(1800D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("pixie", NewObj(4).Put("dr", ((V)("star"))).Put("wk", NewObj(2).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.6))).V).Put("wfx", Arr(((V)("dust")), ((V)("body")), ((V)(4D)))).Put("s", Fn((V _self2, int _argc477, V t_483, V _a480, V _a481, V _a482, V[] _rest478) => {
Call(sp_15, V.Undef, t_483, NewObj(2).Put("wfl", ((V)(0.7))).Put("wsp", ((V)(0.4))).V, ((V)(1400D)), ((V)(1000D)));
Invoke(t_483, "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("floof", NewObj(3).Put("dr", ((V)("snow"))).Put("wk", NewObj(1).Put("fzz", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc484, V t_490, V _a487, V _a488, V _a489, V[] _rest485) => {
Invoke(Invoke(Invoke(t_490, "to", ((V)(200D)), NewObj(1).Put("fzz", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.5))).V, NewObj(1).Put("x", ((V)((-0.5)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(1).Put("fzz", ((V)(0D))).V);
Call(bk_16, V.Undef, t_490, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("unibun", NewObj(3).Put("dr", ((V)("rainbow"))).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(5D)))).Put("s", Fn((V _self2, int _argc491, V t_497, V _a494, V _a495, V _a496, V[] _rest492) => {
Invoke(t_497, "fx", ((V)("spark")), ((V)("head")), ((V)(4D)));
Call(ear_17, V.Undef, t_497, ((V)((-1D))), ((V)(10D)));
Call(bk_16, V.Undef, t_497, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("gumdrop", NewObj(3).Put("dr", ((V)("candy"))).Put("wk", NewObj(1).Put("jig", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc498, V t_504, V _a501, V _a502, V _a503, V[] _rest499) => {
return Call(sp_15, V.Undef, t_504, NewObj(1).Put("jig", ((V)(0.8))).V, ((V)(1200D)), ((V)(1000D)));
}, 1, "s", true)).V).Put("ember", NewObj(4).Put("dr", ((V)("fire"))).Put("zc", ((V)("#e2621e"))).Put("wk", NewObj(1).Put("cfl", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc505, V t_511, V _a508, V _a509, V _a510, V[] _rest506) => {
return Call(sp_15, V.Undef, t_511, NewObj(1).Put("cfl", ((V)(0.6))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("drako", NewObj(3).Put("dr", ((V)("fire"))).Put("wk", NewObj(2).Put("wsp", ((V)(1D))).Put("wfl", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc512, V t_518, V _a515, V _a516, V _a517, V[] _rest513) => {
Invoke(Invoke(Invoke(Invoke(t_518, "to", ((V)(400D)), NewObj(1).Put("puff", ((V)(0.6))).V), "to", ((V)(200D)), NewObj(1).Put("puff", ((V)(0D))).V), "fx", ((V)("steam")), ((V)("head"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)(0.6))).V, NewObj(1).Put("tsw", ((V)((-0.6)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_518, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("jinni", NewObj(3).Put("dr", ((V)("star"))).Put("wk", NewObj(2).Put("glo", ((V)(1D))).Put("gwh", ((V)(1D))).V).Put("s", Fn((V _self2, int _argc519, V t_525, V _a522, V _a523, V _a524, V[] _rest520) => {
Call(sp_15, V.Undef, t_525, NewObj(2).Put("glo", ((V)(0.8))).Put("gwh", ((V)(0.6))).V, ((V)(1600D)), ((V)(1400D)));
Invoke(t_525, "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("cuppy", NewObj(3).Put("dr", ((V)("cherry"))).Put("wfx", Arr(((V)("sprinkle")), ((V)("head")))).Put("s", Fn((V _self2, int _argc526, V t_532, V _a529, V _a530, V _a531, V[] _rest527) => {
Invoke(Invoke(t_532, "fx", ((V)("sprinkle")), ((V)("head"))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_532, "B"), "sq"), ((V)(0.04)))).V, NewObj(1).Put("sq", Get(Get(t_532, "B"), "sq")).V, ((V)("o")));
Call(bk_16, V.Undef, t_532, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("chip", NewObj(3).Put("dr", ((V)("cup"))).Put("wfx", Arr(((V)("crumb")), ((V)("body")), ((V)(4D)))).Put("s", Fn((V _self2, int _argc533, V t_539, V _a536, V _a537, V _a538, V[] _rest534) => {
Invoke(Invoke(t_539, "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.5))).V, NewObj(1).Put("x", ((V)((-0.5)))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_539, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("twisty", NewObj(3).Put("dr", ((V)("heart"))).Put("wfx", Arr(((V)("salt")), ((V)("head")))).Put("s", Fn((V _self2, int _argc540, V t_546, V _a543, V _a544, V _a545, V[] _rest541) => {
Invoke(Invoke(t_546, "osc", ((V)(2000D)), ((V)(2D)), NewObj(1).Put("tilt", Add(Get(Get(t_546, "B"), "tilt"), ((V)(4D)))).V, NewObj(1).Put("tilt", ((V)((ToNum(Get(Get(t_546, "B"), "tilt")) - 4D)))).V, ((V)("s"))), "fx", ((V)("salt")), ((V)("head")));
Call(bk_16, V.Undef, t_546, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("crois", NewObj(2).Put("dr", ((V)("cup"))).Put("s", Fn((V _self2, int _argc547, V t_553, V _a550, V _a551, V _a552, V[] _rest548) => {
return Call(sp_15, V.Undef, t_553, NewObj(3).Put("lean", ((V)(1.4))).Put("tilt", Add(Get(Get(t_553, "B"), "tilt"), ((V)(3D)))).Put("smile", ((V)(0.9))).V, ((V)(1800D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("maca", NewObj(2).Put("dr", ((V)("flower"))).Put("s", Fn((V _self2, int _argc554, V t_560, V _a557, V _a558, V _a559, V[] _rest555) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_560, "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_560, "B"), "sq"), ((V)(0.1)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_560, "B"), "sq")).V), "wait", ((V)(300D))), "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_560, "B"), "sq"), ((V)(0.08)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_560, "B"), "sq")).V);
Call(bk_16, V.Undef, t_560, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("puddi", NewObj(2).Put("dr", ((V)("cherry"))).Put("s", Fn((V _self2, int _argc561, V t_567, V _a564, V _a565, V _a566, V[] _rest562) => {
Invoke(t_567, "osc", ((V)(1600D)), ((V)(6D)), NewObj(2).Put("sq", Add(Get(Get(t_567, "B"), "sq"), ((V)(0.05)))).Put("x", ((V)(0.3))).V, NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_567, "B"), "sq")) - 0.02)))).Put("x", ((V)((-0.3)))).V, ((V)("l")));
Call(bk_16, V.Undef, t_567, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("mochi", NewObj(2).Put("dr", ((V)("berry"))).Put("s", Fn((V _self2, int _argc568, V t_574, V _a571, V _a572, V _a573, V[] _rest569) => {
return Call(sp_15, V.Undef, t_574, NewObj(2).Put("sq", Add(Get(Get(t_574, "B"), "sq"), ((V)(0.14)))).Put("smile", ((V)(0.9))).V, ((V)(1800D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("cakey", NewObj(2).Put("dr", ((V)("star"))).Put("s", Fn((V _self2, int _argc575, V t_581, V _a578, V _a579, V _a580, V[] _rest576) => {
Invoke(Invoke(Invoke(Invoke(t_581, "to", ((V)(500D)), NewObj(1).Put("puff", ((V)(0.7))).V), "to", ((V)(600D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(300D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", Get(Get(t_581, "B"), "mw")).V);
Call(bk_16, V.Undef, t_581, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("sugarplum", NewObj(3).Put("dr", ((V)("candy"))).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(4D)))).Put("s", Fn((V _self2, int _argc582, V t_588, V _a585, V _a586, V _a587, V[] _rest583) => {
Invoke(Invoke(Invoke(t_588, "to", ((V)(400D)), NewObj(3).Put("armR", ((V)(70D))).Put("hRy", ((V)((-2D)))).Put("smile", ((V)(0.9))).V, ((V)("o"))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-3D)))).V, NewObj(1).Put("hRx", ((V)(3D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_588, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("gourdy", NewObj(3).Put("dr", ((V)("moon"))).Put("zc", ((V)("#e2621e"))).Put("s", Fn((V _self2, int _argc589, V t_595, V _a592, V _a593, V _a594, V[] _rest590) => {
Invoke(t_595, "osc", ((V)(2400D)), ((V)(2D)), NewObj(2).Put("tilt", Add(Get(Get(t_595, "B"), "tilt"), ((V)(5D)))).Put("x", ((V)(1D))).V, NewObj(2).Put("tilt", ((V)((ToNum(Get(Get(t_595, "B"), "tilt")) - 5D)))).Put("x", ((V)((-1D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_595, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("batty", NewObj(4).Put("dr", ((V)("moon"))).Put("lp", NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V).Put("wk", NewObj(2).Put("armL", ((V)(172D))).Put("armR", ((V)(172D))).V).Put("s", Fn((V _self2, int _argc596, V t_602, V _a599, V _a600, V _a601, V[] _rest597) => {
return Call(sp_15, V.Undef, t_602, NewObj(4).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("hLx", ((V)(12D))).Put("hRx", ((V)((-12D)))).V, ((V)(1400D)), ((V)(1800D)));
}, 1, "s", true)).V).Put("kernel", NewObj(2).Put("dr", ((V)("star"))).Put("s", Fn((V _self2, int _argc603, V t_609, V _a606, V _a607, V _a608, V[] _rest604) => {
Invoke(Invoke(Invoke(t_609, "to", ((V)(120D)), NewObj(2).Put("lift", Add(Get(Get(t_609, "B"), "lift"), ((V)(2.4)))).Put("sq", ((V)((ToNum(Get(Get(t_609, "B"), "sq")) - 0.06)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("lift", Get(Get(t_609, "B"), "lift")).Put("sq", Add(Get(Get(t_609, "B"), "sq"), ((V)(0.04)))).V, ((V)("i"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_609, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("hexie", NewObj(3).Put("dr", ((V)("moon"))).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(4D)))).Put("s", Fn((V _self2, int _argc610, V t_616, V _a613, V _a614, V _a615, V[] _rest611) => {
Call(sp_15, V.Undef, t_616, NewObj(1).Put("curl", ((V)(0.7))).V, ((V)(1400D)), ((V)(1200D)));
Invoke(t_616, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("mumbles", NewObj(2).Put("dr", ((V)("candy"))).Put("s", Fn((V _self2, int _argc617, V t_623, V _a620, V _a621, V _a622, V[] _rest618) => {
Invoke(Invoke(Invoke(t_623, "to", ((V)(900D)), NewObj(5).Put("armL", ((V)(88D))).Put("armR", ((V)(88D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("open", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(1200D))), "to", ((V)(900D)), NewObj(5).Put("armL", Get(Get(t_623, "B"), "armL")).Put("armR", Get(Get(t_623, "B"), "armR")).Put("hLy", Get(Get(t_623, "B"), "hLy")).Put("hRy", Get(Get(t_623, "B"), "hRy")).Put("open", ((V)(0D))).V, ((V)("io")));
Call(bk_16, V.Undef, t_623, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("hocus", NewObj(3).Put("dr", ((V)("star"))).Put("wfx", Arr(((V)("spark")), ((V)("body")), ((V)(4D)))).Put("s", Fn((V _self2, int _argc624, V t_630, V _a627, V _a628, V _a629, V[] _rest625) => {
Invoke(Invoke(Invoke(t_630, "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(800D))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_630, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("countsquishula", NewObj(3).Put("dr", ((V)("moon"))).Put("lp", Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(12D)), ((V)((-4D)))), NewObj(4).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("htilt", ((V)(0D))).Put("tilt", ((V)(0D))).V)).Put("s", Fn((V _self2, int _argc631, V t_637, V _a634, V _a635, V _a636, V[] _rest632) => {
Invoke(Invoke(Invoke(Invoke(t_637, "to", ((V)(300D)), NewObj(4).Put("close", ((V)(0D))).Put("winkL", ((V)(1D))).Put("smile", ((V)(0.6))).Put("zz", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(1200D))), "to", ((V)(400D)), NewObj(2).Put("close", ((V)(1D))).Put("winkL", ((V)(0D))).V), "to", ((V)(400D)), NewObj(1).Put("zz", ((V)(1D))).V);
Call(bk_16, V.Undef, t_637, ((V)(400D)));
return default;
}, 1, "s", true)).V).V;
Invoke(Object_keys(PROF_14), "forEach", Fn((V _self2, int _argc638, V k_644, V _a641, V _a642, V _a643, V[] _rest639) => {
return Call(bedBuild_10, V.Undef, k_644, (GetK(B_18, k_644) is var _t645 && Truthy(_t645) ? _t645 : NewObj(0).V));
}, 1, "", true));
return default;
}, 1, "", false));
        }
    }
}
