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
sp_15 = Fn((V _arrowThis35, int _argc25, V t_31, V v_32, V d_33, V hold_34, V[] _rest26) => {
V b_36 = default;
b_36 = NewObj(0).V;
Invoke(Object_keys(v_32), "forEach", Fn((V _arrowThis44, int _argc37, V k_43, V _a40, V _a41, V _a42, V[] _rest38) => {
return SetK(b_36, k_43, (!GetK(Get(t_31, "B"), k_43).IsNullish ? GetK(Get(t_31, "B"), k_43) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_31, "to", ((V)((ToNum((d_33 is var _t47 && Truthy(_t47) ? _t47 : ((V)(700D)))) * 0.4))), v_32, ((V)("o"))), "wait", (hold_34 is var _t46 && Truthy(_t46) ? _t46 : ((V)(300D)))), "to", ((V)((ToNum((d_33 is var _t45 && Truthy(_t45) ? _t45 : ((V)(700D)))) * 0.6))), b_36, ((V)("io")));
return t_31;
return default;
}, 4, "", true);
bk_16 = Fn((V _arrowThis56, int _argc48, V t_54, V d_55, V _a52, V _a53, V[] _rest49) => {
return Invoke(t_54, "back", (d_55 is var _t57 && Truthy(_t57) ? _t57 : ((V)(420D))));
}, 2, "", true);
ear_17 = Fn((V _arrowThis67, int _argc58, V t_64, V s_65, V a_66, V _a63, V[] _rest59) => {
V e_68 = default;
e_68 = ((V)((LtN(s_65, 0D) ? "earL" : "earR")));
Invoke(Invoke(Invoke(t_64, "to", ((V)(90D)), NewObj(1).PutK(e_68, ((V)((-ToNum((a_66 is var _t69 && Truthy(_t69) ? _t69 : ((V)(10D)))))))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(1).PutK(e_68, ((V)(3D))).V), "to", ((V)(150D)), NewObj(1).PutK(e_68, ((V)(0D))).V);
return t_64;
return default;
}, 3, "", true);
B_18 = NewObj(81).Put("mittens", NewObj(3).Put("dr", ((V)("fish"))).Put("wk", NewObj(3).Put("curl", ((V)(0.6))).Put("earL", ((V)((-8D)))).Put("earR", ((V)((-8D)))).V).Put("s", Fn((V _arrowThis77, int _argc70, V t_76, V _a73, V _a74, V _a75, V[] _rest71) => {
Invoke(Invoke(t_76, "to", ((V)(400D)), NewObj(2).Put("curl", ((V)(0.8))).Put("smile", ((V)(0.7))).V), "osc", ((V)(2600D)), ((V)(6D)), NewObj(3).Put("hLy", Add(Get(Get(t_76, "B"), "hLy"), ((V)(3D)))).Put("hRy", Get(Get(t_76, "B"), "hRy")).Put("sq", Add(Get(Get(t_76, "B"), "sq"), ((V)(0.012)))).V, NewObj(3).Put("hLy", Get(Get(t_76, "B"), "hLy")).Put("hRy", Add(Get(Get(t_76, "B"), "hRy"), ((V)(3D)))).Put("sq", Get(Get(t_76, "B"), "sq")).V, ((V)("s")));
Call(bk_16, V.Undef, t_76, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("biscuit", NewObj(3).Put("dr", ((V)("bone"))).Put("wk", NewObj(3).Put("wag", ((V)(24D))).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V).Put("s", Fn((V _arrowThis85, int _argc78, V t_84, V _a81, V _a82, V _a83, V[] _rest79) => {
Invoke(Invoke(Invoke(t_84, "to", ((V)(200D)), NewObj(1).Put("open", ((V)(0.12))).V), "osc", ((V)(2000D)), ((V)(10D)), NewObj(3).Put("footL", Add(Get(Get(t_84, "B"), "footL"), ((V)(2.4)))).Put("footR", Get(Get(t_84, "B"), "footR")).Put("wag", ((V)(16D))).V, NewObj(3).Put("footL", Get(Get(t_84, "B"), "footL")).Put("footR", Add(Get(Get(t_84, "B"), "footR"), ((V)(2.4)))).Put("wag", ((V)((-16D)))).V, ((V)("l"))), "osc", ((V)(800D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.3))).V, NewObj(1).Put("open", ((V)(0.05))).V, ((V)("o")));
Call(bk_16, V.Undef, t_84, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("prickle", NewObj(4).Put("dr", ((V)("apple"))).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(2D)))).Put("bp", NewObj(2).Put("curl", ((V)(1D))).Put("sq", ((V)(0.3))).V).Put("s", Fn((V _arrowThis93, int _argc86, V t_92, V _a89, V _a90, V _a91, V[] _rest87) => {
return Call(sp_15, V.Undef, t_92, NewObj(4).Put("curl", ((V)(1D))).Put("sq", Add(Get(Get(t_92, "B"), "sq"), ((V)(0.12)))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V, ((V)(1400D)), ((V)(2200D)));
}, 1, "s", true)).V).Put("truffle", NewObj(3).Put("dr", ((V)("apple"))).Put("wk", NewObj(1).Put("wag", ((V)(18D))).V).Put("s", Fn((V _arrowThis101, int _argc94, V t_100, V _a97, V _a98, V _a99, V[] _rest95) => {
return Call(sp_15, V.Undef, t_100, NewObj(3).Put("sq", Add(Get(Get(t_100, "B"), "sq"), ((V)(0.12)))).Put("smile", ((V)(0.9))).Put("blush", ((V)(0.6))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("ribbit", NewObj(2).Put("dr", ((V)("leaf"))).Put("s", Fn((V _arrowThis109, int _argc102, V t_108, V _a105, V _a106, V _a107, V[] _rest103) => {
{
double i_110 = 0;
i_110 = 0D;
while (true) {
if (!((i_110 < 2D))) break;
Invoke(Invoke(Invoke(t_108, "to", ((V)(300D)), NewObj(1).Put("sq", Add(Get(Get(t_108, "B"), "sq"), ((V)(0.06)))).V, ((V)("i"))), "to", ((V)(500D)), NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_108, "B"), "sq")) - 0.03)))).Put("lift", Add(Get(Get(t_108, "B"), "lift"), ((V)(0.8)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("sq", Get(Get(t_108, "B"), "sq")).Put("lift", Get(Get(t_108, "B"), "lift")).V, ((V)("s")));
i_110++;
}
}
Call(bk_16, V.Undef, t_108, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("nibbles", NewObj(3).Put("dr", ((V)("nut"))).Put("wk", NewObj(1).Put("puff", ((V)(0.6))).V).Put("s", Fn((V _arrowThis119, int _argc112, V t_118, V _a115, V _a116, V _a117, V[] _rest113) => {
Invoke(Invoke(Invoke(t_118, "to", ((V)(300D)), NewObj(1).Put("puff", ((V)(0.9))).V), "osc", ((V)(1800D)), ((V)(6D)), NewObj(2).Put("open", ((V)(0.15))).Put("htilt", Add(Get(Get(t_118, "B"), "htilt"), ((V)(2D)))).V, NewObj(2).Put("open", ((V)(0D))).Put("htilt", ((V)((ToNum(Get(Get(t_118, "B"), "htilt")) - 2D)))).V, ((V)("s"))), "fx", ((V)("crumb")), ((V)("head")));
Call(bk_16, V.Undef, t_118, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("quill", NewObj(3).Put("dr", ((V)("flower"))).Put("wk", NewObj(1).Put("blush", ((V)(0.6))).V).Put("s", Fn((V _arrowThis127, int _argc120, V t_126, V _a123, V _a124, V _a125, V[] _rest121) => {
return Call(sp_15, V.Undef, t_126, NewObj(3).Put("blush", ((V)(0.9))).Put("smile", ((V)(0.9))).Put("htilt", Add(Get(Get(t_126, "B"), "htilt"), ((V)(5D)))).V, ((V)(1400D)), ((V)(1600D)));
}, 1, "s", true)).V).Put("waffles", NewObj(3).Put("dr", ((V)("cookie"))).Put("wk", NewObj(1).Put("wag", ((V)(18D))).V).Put("s", Fn((V _arrowThis135, int _argc128, V t_134, V _a131, V _a132, V _a133, V[] _rest129) => {
Invoke(Invoke(t_134, "to", ((V)(800D)), NewObj(2).Put("sq", Add(Get(Get(t_134, "B"), "sq"), ((V)(0.1)))).Put("lift", ((V)((ToNum(Get(Get(t_134, "B"), "lift")) - 1D)))).V, ((V)("s"))), "osc", ((V)(1600D)), ((V)(5D)), NewObj(1).Put("footL", Add(Get(Get(t_134, "B"), "footL"), ((V)(2D)))).V, NewObj(1).Put("footL", Get(Get(t_134, "B"), "footL")).V, ((V)("l")));
Call(bk_16, V.Undef, t_134, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("poppy", NewObj(3).Put("dr", ((V)("carrot"))).Put("wk", NewObj(2).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).V).Put("s", Fn((V _arrowThis143, int _argc136, V t_142, V _a139, V _a140, V _a141, V[] _rest137) => {
Invoke(t_142, "osc", ((V)(1200D)), ((V)(6D)), NewObj(2).Put("sqz", ((V)(0.4))).Put("ly", ((V)((-0.1)))).V, NewObj(2).Put("sqz", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("l")));
Call(ear_17, V.Undef, t_142, ((V)((-1D))), ((V)(10D)));
Call(bk_16, V.Undef, t_142, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("duchess", NewObj(4).Put("dr", ((V)("fish"))).Put("lp", NewObj(1).Put("htilt", ((V)(9D))).V).Put("wk", NewObj(1).Put("htilt", ((V)(8D))).V).Put("s", Fn((V _arrowThis151, int _argc144, V t_150, V _a147, V _a148, V _a149, V[] _rest145) => {
Invoke(Invoke(t_150, "to", ((V)(500D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-13D)))), NewObj(1).Put("armR", ((V)(30D))).V)), "osc", ((V)(1600D)), ((V)(4D)), NewObj(1).Put("tongue", ((V)(0.5))).V, NewObj(1).Put("tongue", ((V)(0.1))).V, ((V)("s")));
Call(bk_16, V.Undef, t_150, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("mamapaws", NewObj(5).Put("dr", ((V)("heart"))).Put("lp", Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(9D)), ((V)(3D))), NewObj(2).Put("armL", ((V)(14D))).Put("armR", ((V)(14D))).V)).Put("bp", Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(9D)), ((V)(3D))), NewObj(3).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).Put("curl", ((V)(0.6))).V)).Put("wk", NewObj(1).Put("wag", ((V)(12D))).V).Put("s", Fn((V _arrowThis159, int _argc152, V t_158, V _a155, V _a156, V _a157, V[] _rest153) => {
Invoke(Invoke(Invoke(t_158, "to", ((V)(600D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(12D)), ((V)(1D))), NewObj(3).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("smile", ((V)(0.9))).V)), "fx", ((V)("heart")), ((V)("head"))), "wait", ((V)(1400D)));
Call(bk_16, V.Undef, t_158, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("nimbo", NewObj(3).Put("dr", ((V)("sun"))).Put("wfx", Arr(((V)("drop")), ((V)("body")), ((V)(4D)))).Put("s", Fn((V _arrowThis167, int _argc160, V t_166, V _a163, V _a164, V _a165, V[] _rest161) => {
Invoke(Invoke(Invoke(t_166, "fx", ((V)("drop")), ((V)("body")), ((V)(3D))), "osc", ((V)(2400D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(Get(t_166, "B"), "sq"), ((V)(0.06)))).V, NewObj(1).Put("sq", Get(Get(t_166, "B"), "sq")).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_166, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("lumi", NewObj(3).Put("dr", ((V)("star"))).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(4D)))).Put("s", Fn((V _arrowThis175, int _argc168, V t_174, V _a171, V _a172, V _a173, V[] _rest169) => {
Invoke(Invoke(Invoke(t_174, "to", ((V)(600D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-8D)))), NewObj(1).Put("armR", ((V)(40D))).V)), "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "wait", ((V)(1600D)));
Call(bk_16, V.Undef, t_174, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("bubbly", NewObj(3).Put("dr", ((V)("bubble"))).Put("wfx", Arr(((V)("bubble")), ((V)("head")))).Put("s", Fn((V _arrowThis183, int _argc176, V t_182, V _a179, V _a180, V _a181, V[] _rest177) => {
Invoke(Invoke(t_182, "osc", ((V)(2400D)), ((V)(2D)), NewObj(2).Put("turn", ((V)(0.3))).Put("x", ((V)(0.8))).V, NewObj(2).Put("turn", ((V)((-0.3)))).Put("x", ((V)((-0.8)))).V, ((V)("s"))), "fx", ((V)("bubble")), ((V)("head")));
Call(bk_16, V.Undef, t_182, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("twinkle", NewObj(4).Put("dr", ((V)("moon"))).Put("zc", ((V)("#c9962a"))).Put("wfx", Arr(((V)("spark")), ((V)("body")), ((V)(6D)))).Put("s", Fn((V _arrowThis191, int _argc184, V t_190, V _a187, V _a188, V _a189, V[] _rest185) => {
Invoke(Invoke(Invoke(Invoke(t_190, "to", ((V)(400D)), NewObj(1).Put("glow", ((V)(1D))).V), "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(1200D))), "to", ((V)(600D)), NewObj(1).Put("glow", ((V)(0D))).V);
Call(bk_16, V.Undef, t_190, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("zappi", NewObj(4).Put("dr", ((V)("bolt"))).Put("wk", NewObj(1).Put("zap", ((V)(1D))).V).Put("wfx", Arr(((V)("spark")), ((V)("body")), ((V)(6D)))).Put("s", Fn((V _arrowThis199, int _argc192, V t_198, V _a195, V _a196, V _a197, V[] _rest193) => {
Invoke(Invoke(Invoke(Invoke(t_198, "to", ((V)(80D)), NewObj(2).Put("zap", ((V)(0.7))).Put("x", ((V)(0.5))).V, ((V)("o"))), "osc", ((V)(400D)), ((V)(4D)), NewObj(1).Put("x", ((V)((-0.5)))).V, NewObj(1).Put("x", ((V)(0.5))).V, ((V)("l"))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("zap", ((V)(0D))).Put("x", ((V)(0D))).V);
Call(bk_16, V.Undef, t_198, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("plip", NewObj(3).Put("dr", ((V)("rainbow"))).Put("wfx", Arr(((V)("drop")), ((V)("head")), ((V)(3D)))).Put("s", Fn((V _arrowThis207, int _argc200, V t_206, V _a203, V _a204, V _a205, V[] _rest201) => {
Invoke(Invoke(t_206, "fx", ((V)("drop")), ((V)("head")), ((V)(2D))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_206, "B"), "sq"), ((V)(0.06)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_206, "B"), "sq")) - 0.02)))).V, ((V)("o")));
Call(bk_16, V.Undef, t_206, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("breeze", NewObj(3).Put("dr", ((V)("cloud"))).Put("wfx", Arr(((V)("gust")), ((V)("head")))).Put("s", Fn((V _arrowThis215, int _argc208, V t_214, V _a211, V _a212, V _a213, V[] _rest209) => {
Invoke(Invoke(Invoke(t_214, "to", ((V)(500D)), NewObj(2).Put("puff", ((V)(0.6))).Put("open", ((V)(0.2))).V), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(700D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
Call(bk_16, V.Undef, t_214, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("dusty", NewObj(3).Put("dr", ((V)("star"))).Put("wfx", Arr(((V)("dust")), ((V)("body")), ((V)(4D)))).Put("s", Fn((V _arrowThis223, int _argc216, V t_222, V _a219, V _a220, V _a221, V[] _rest217) => {
Invoke(t_222, "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
Call(ear_17, V.Undef, t_222, ((V)(1D)), ((V)(10D)));
Call(ear_17, V.Undef, t_222, ((V)((-1D))), ((V)(8D)));
Call(bk_16, V.Undef, t_222, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("aurora", NewObj(4).Put("dr", ((V)("rainbow"))).Put("wk", NewObj(1).Put("spout", ((V)(1D))).V).Put("wfx", Arr(((V)("drop")), ((V)("head")), ((V)(4D)))).Put("s", Fn((V _arrowThis231, int _argc224, V t_230, V _a227, V _a228, V _a229, V[] _rest225) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_230, "to", ((V)(400D)), NewObj(1).Put("spout", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D))), "wait", ((V)(800D))), "to", ((V)(500D)), NewObj(2).Put("spout", ((V)(0D))).Put("glow", ((V)(0.8))).V), "wait", ((V)(800D)));
Call(bk_16, V.Undef, t_230, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("mallow", NewObj(2).Put("dr", ((V)("cup"))).Put("s", Fn((V _arrowThis239, int _argc232, V t_238, V _a235, V _a236, V _a237, V[] _rest233) => {
return Call(sp_15, V.Undef, t_238, NewObj(3).Put("sq", Add(Get(Get(t_238, "B"), "sq"), ((V)(0.18)))).Put("lift", ((V)((ToNum(Get(Get(t_238, "B"), "lift")) - 1.4)))).Put("smile", ((V)(0.9))).V, ((V)(2000D)), ((V)(1600D)));
}, 1, "s", true)).V).Put("bao", NewObj(3).Put("dr", ((V)("star"))).Put("wfx", Arr(((V)("steam")), ((V)("head")))).Put("s", Fn((V _arrowThis247, int _argc240, V t_246, V _a243, V _a244, V _a245, V[] _rest241) => {
Invoke(Invoke(Invoke(t_246, "fx", ((V)("steam")), ((V)("head"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(Get(t_246, "B"), "sq"), ((V)(0.05)))).V, NewObj(1).Put("sq", Get(Get(t_246, "B"), "sq")).V, ((V)("s"))), "fx", ((V)("steam")), ((V)("head")));
Call(bk_16, V.Undef, t_246, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("dunkie", NewObj(3).Put("dr", ((V)("cup"))).Put("wfx", Arr(((V)("sprinkle")), ((V)("head")))).Put("s", Fn((V _arrowThis255, int _argc248, V t_254, V _a251, V _a252, V _a253, V[] _rest249) => {
Invoke(Invoke(t_254, "osc", ((V)(1600D)), ((V)(3D)), NewObj(2).Put("tilt", Add(Get(Get(t_254, "B"), "tilt"), ((V)(3D)))).Put("x", ((V)(0.6))).V, NewObj(2).Put("tilt", ((V)((ToNum(Get(Get(t_254, "B"), "tilt")) - 3D)))).Put("x", ((V)((-0.6)))).V, ((V)("s"))), "fx", ((V)("sprinkle")), ((V)("head")));
Call(bk_16, V.Undef, t_254, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("frybo", NewObj(3).Put("dr", ((V)("ketchup"))).Put("wk", NewObj(1).Put("fw", ((V)(1D))).V).Put("s", Fn((V _arrowThis263, int _argc256, V t_262, V _a259, V _a260, V _a261, V[] _rest257) => {
Call(sp_15, V.Undef, t_262, NewObj(2).Put("fw", ((V)(0.8))).Put("smile", ((V)(0.8))).V, ((V)(1400D)), ((V)(1200D)));
Invoke(t_262, "fx", ((V)("salt")), ((V)("head")));
return default;
}, 1, "s", true)).V).Put("bunbun", NewObj(3).Put("dr", ((V)("cheese"))).Put("wk", NewObj(1).Put("split", ((V)(0.4))).V).Put("s", Fn((V _arrowThis271, int _argc264, V t_270, V _a267, V _a268, V _a269, V[] _rest265) => {
return Call(sp_15, V.Undef, t_270, NewObj(2).Put("split", ((V)(0.3))).Put("shuf", ((V)(0.3))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "s", true)).V).Put("choco", NewObj(2).Put("dr", ((V)("heart"))).Put("s", Fn((V _arrowThis279, int _argc272, V t_278, V _a275, V _a276, V _a277, V[] _rest273) => {
return Call(sp_15, V.Undef, t_278, NewObj(2).Put("melt", ((V)(0.45))).Put("smile", ((V)(1D))).V, ((V)(2000D)), ((V)(1800D)));
}, 1, "s", true)).V).Put("scoop", NewObj(3).Put("dr", ((V)("cherry"))).Put("wk", NewObj(1).Put("chb", ((V)(1D))).V).Put("s", Fn((V _arrowThis287, int _argc280, V t_286, V _a283, V _a284, V _a285, V[] _rest281) => {
Invoke(t_286, "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("chb", ((V)(0.8))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_286, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("boba", NewObj(3).Put("dr", ((V)("pearl"))).Put("wk", NewObj(1).Put("slurp", ((V)(0.6))).V).Put("s", Fn((V _arrowThis295, int _argc288, V t_294, V _a291, V _a292, V _a293, V[] _rest289) => {
Invoke(t_294, "osc", ((V)(1800D)), ((V)(3D)), NewObj(2).Put("slurp", ((V)(0.5))).Put("sqz", ((V)(0.3))).V, NewObj(2).Put("slurp", ((V)(0D))).Put("sqz", ((V)(0D))).V, ((V)("s")));
Call(bk_16, V.Undef, t_294, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("chefbun", NewObj(2).Put("dr", ((V)("cake"))).Put("s", Fn((V _arrowThis303, int _argc296, V t_302, V _a299, V _a300, V _a301, V[] _rest297) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_302, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-13D)))), NewObj(1).Put("armR", ((V)(34D))).V)), "wait", ((V)(300D))), "to", ((V)(260D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-4D))), ((V)((-14D)))), NewObj(2).Put("armR", ((V)(60D))).Put("smile", ((V)(1D))).V), ((V)("o"))), "fx", ((V)("heart")), ((V)("head"))), "wait", ((V)(500D)));
Call(bk_16, V.Undef, t_302, ((V)(600D)));
return default;
}, 1, "s", true)).V).Put("pip", NewObj(3).Put("dr", ((V)("fish"))).Put("wk", NewObj(2).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V).Put("s", Fn((V _arrowThis311, int _argc304, V t_310, V _a307, V _a308, V _a309, V[] _rest305) => {
Invoke(t_310, "osc", ((V)(1400D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).V, NewObj(2).Put("armL", ((V)(4D))).Put("armR", ((V)(4D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_310, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("jelli", NewObj(3).Put("dr", ((V)("bubble"))).Put("wfx", Arr(((V)("bubble")), ((V)("head")))).Put("s", Fn((V _arrowThis319, int _argc312, V t_318, V _a315, V _a316, V _a317, V[] _rest313) => {
{
double i_320 = 0;
i_320 = 0D;
while (true) {
if (!((i_320 < 3D))) break;
Invoke(Invoke(Invoke(t_318, "to", ((V)(400D)), NewObj(1).Put("sq", Add(Get(Get(t_318, "B"), "sq"), ((V)(0.08)))).V, ((V)("i"))), "to", ((V)(600D)), NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_318, "B"), "sq")) - 0.04)))).Put("lift", Add(Get(Get(t_318, "B"), "lift"), ((V)(0.8)))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(2).Put("sq", Get(Get(t_318, "B"), "sq")).Put("lift", Get(Get(t_318, "B"), "lift")).V, ((V)("s")));
i_320++;
}
}
Call(bk_16, V.Undef, t_318, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("finn", NewObj(4).Put("dr", ((V)("shell"))).Put("wk", NewObj(1).Put("wag", ((V)(24D))).V).Put("wfx", Arr(((V)("drop")), ((V)("body")), ((V)(4D)))).Put("s", Fn((V _arrowThis329, int _argc322, V t_328, V _a325, V _a326, V _a327, V[] _rest323) => {
Invoke(Invoke(t_328, "osc", ((V)(2000D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(20D))).V, NewObj(1).Put("wag", ((V)((-20D)))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("body")), ((V)(2D)));
Call(bk_16, V.Undef, t_328, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("sealy", NewObj(2).Put("dr", ((V)("fish"))).Put("s", Fn((V _arrowThis337, int _argc330, V t_336, V _a333, V _a334, V _a335, V[] _rest331) => {
Invoke(Invoke(t_336, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("open", ((V)(0.35))).V, NewObj(1).Put("open", ((V)(0.05))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(4).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, NewObj(4).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-6D)))).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_336, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("puff", NewObj(3).Put("dr", ((V)("bubble"))).Put("wfx", Arr(((V)("bubble")), ((V)("head")))).Put("s", Fn((V _arrowThis345, int _argc338, V t_344, V _a341, V _a342, V _a343, V[] _rest339) => {
Invoke(Invoke(Invoke(Invoke(t_344, "to", ((V)(1200D)), NewObj(2).Put("blo", ((V)(0.5))).Put("puff", ((V)(0.5))).V, ((V)("s"))), "fx", ((V)("bubble")), ((V)("head"))), "wait", ((V)(800D))), "to", ((V)(1400D)), NewObj(2).Put("blo", ((V)(0D))).Put("puff", ((V)(0D))).V, ((V)("s")));
Call(bk_16, V.Undef, t_344, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("shelly", NewObj(4).Put("dr", ((V)("leaf"))).Put("wk", NewObj(1).Put("nk", ((V)(1D))).V).Put("bp", NewObj(1).Put("hid", ((V)(0.35))).V).Put("s", Fn((V _arrowThis353, int _argc346, V t_352, V _a349, V _a350, V _a351, V[] _rest347) => {
Invoke(Invoke(Invoke(t_352, "to", ((V)(700D)), NewObj(1).Put("hid", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(2000D))), "to", ((V)(500D)), NewObj(1).Put("hid", (Get(Get(t_352, "B"), "hid") is var _t354 && Truthy(_t354) ? _t354 : ((V)(0D)))).V, ((V)("io")));
Call(bk_16, V.Undef, t_352, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("octo", NewObj(3).Put("dr", ((V)("shell"))).Put("wk", NewObj(1).Put("osp", ((V)(1D))).V).Put("s", Fn((V _arrowThis362, int _argc355, V t_361, V _a358, V _a359, V _a360, V[] _rest356) => {
return Call(sp_15, V.Undef, t_361, NewObj(2).Put("ocl", ((V)(0.8))).Put("ow", ((V)(0.6))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "s", true)).V).Put("marina", NewObj(3).Put("dr", ((V)("pearl"))).Put("wk", NewObj(1).Put("tlf", ((V)(0.6))).V).Put("s", Fn((V _arrowThis370, int _argc363, V t_369, V _a366, V _a367, V _a368, V[] _rest364) => {
Invoke(Invoke(Invoke(t_369, "to", ((V)(500D)), NewObj(1).Put("tlf", ((V)(0.6))).V, ((V)("o"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("tsw", ((V)(0.5))).V, NewObj(1).Put("tsw", ((V)((-0.5)))).V, ((V)("s"))), "to", ((V)(500D)), NewObj(2).Put("tlf", ((V)(0D))).Put("tsw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_369, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("pearl", NewObj(4).Put("dr", ((V)("star"))).Put("wk", NewObj(1).Put("glow", ((V)(1D))).V).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(4D)))).Put("s", Fn((V _arrowThis378, int _argc371, V t_377, V _a374, V _a375, V _a376, V[] _rest372) => {
Call(sp_15, V.Undef, t_377, NewObj(1).Put("glow", ((V)(1D))).V, ((V)(1800D)), ((V)(1400D)));
Invoke(t_377, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("pina", NewObj(3).Put("dr", ((V)("sun"))).Put("wk", NewObj(1).Put("crw", ((V)(1D))).V).Put("s", Fn((V _arrowThis386, int _argc379, V t_385, V _a382, V _a383, V _a384, V[] _rest380) => {
Invoke(Invoke(Invoke(t_385, "to", ((V)(300D)), NewObj(1).Put("crw", ((V)(0.7))).V, ((V)("o"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("crs", ((V)(0.3))).V, NewObj(1).Put("crs", ((V)(0D))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(1).Put("crw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_385, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("avo", NewObj(3).Put("dr", ((V)("leaf"))).Put("wk", NewObj(1).Put("pp", ((V)(0.3))).V).Put("s", Fn((V _arrowThis394, int _argc387, V t_393, V _a390, V _a391, V _a392, V[] _rest388) => {
Invoke(Invoke(Invoke(t_393, "to", ((V)(300D)), NewObj(1).Put("prw", ((V)(0.8))).V), "wait", ((V)(1200D))), "to", ((V)(400D)), NewObj(1).Put("prw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_393, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("berri", NewObj(3).Put("dr", ((V)("cake"))).Put("wk", NewObj(1).Put("stw", ((V)(1D))).V).Put("s", Fn((V _arrowThis402, int _argc395, V t_401, V _a398, V _a399, V _a400, V[] _rest396) => {
Invoke(Invoke(t_401, "to", ((V)(120D)), NewObj(1).Put("stw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(1000D)), NewObj(1).Put("stw", ((V)(0D))).V);
Call(bk_16, V.Undef, t_401, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("lemmy", NewObj(3).Put("dr", ((V)("cup"))).Put("wk", NewObj(1).Put("sqz", ((V)(0.6))).V).Put("s", Fn((V _arrowThis410, int _argc403, V t_409, V _a406, V _a407, V _a408, V[] _rest404) => {
return Call(sp_15, V.Undef, t_409, NewObj(3).Put("sqz", ((V)(0.8))).Put("mw", ((V)(0.5))).Put("frown", ((V)(0.2))).V, ((V)(1000D)), ((V)(900D)));
}, 1, "s", true)).V).Put("kiwi", NewObj(3).Put("dr", ((V)("flower"))).Put("wk", NewObj(1).Put("fzz", ((V)(1D))).V).Put("s", Fn((V _arrowThis418, int _argc411, V t_417, V _a414, V _a415, V _a416, V[] _rest412) => {
return Call(sp_15, V.Undef, t_417, NewObj(1).Put("fzz", ((V)(0.6))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("melo", NewObj(3).Put("dr", ((V)("sun"))).Put("wk", NewObj(1).Put("sdj", ((V)(1D))).V).Put("s", Fn((V _arrowThis426, int _argc419, V t_425, V _a422, V _a423, V _a424, V[] _rest420) => {
Invoke(t_425, "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("sdj", ((V)(1D))).V, NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("o")));
Call(bk_16, V.Undef, t_425, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("peachy", NewObj(3).Put("dr", ((V)("flower"))).Put("wk", NewObj(1).Put("blush", ((V)(0.8))).V).Put("s", Fn((V _arrowThis434, int _argc427, V t_433, V _a430, V _a431, V _a432, V[] _rest428) => {
return Call(sp_15, V.Undef, t_433, NewObj(3).Put("blush", ((V)(1D))).Put("lfl", ((V)(0.5))).Put("smile", ((V)(0.9))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("pitaya", NewObj(3).Put("dr", ((V)("moon"))).Put("wk", NewObj(2).Put("wsp", ((V)(1D))).Put("wfl", ((V)(1D))).V).Put("s", Fn((V _arrowThis442, int _argc435, V t_441, V _a438, V _a439, V _a440, V[] _rest436) => {
return Call(sp_15, V.Undef, t_441, NewObj(2).Put("wfl", ((V)(0.7))).Put("wsp", ((V)(0.5))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("tutti", NewObj(4).Put("dr", ((V)("cherry"))).Put("wk", NewObj(1).Put("wfl", ((V)(1D))).V).Put("wfx", Arr(((V)("dust")), ((V)("body")), ((V)(3D)))).Put("s", Fn((V _arrowThis450, int _argc443, V t_449, V _a446, V _a447, V _a448, V[] _rest444) => {
Call(sp_15, V.Undef, t_449, NewObj(1).Put("wfl", ((V)(0.6))).V, ((V)(1400D)), ((V)(1000D)));
Invoke(t_449, "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("kiko", NewObj(3).Put("dr", ((V)("leaf"))).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(3D)))).Put("s", Fn((V _arrowThis458, int _argc451, V t_457, V _a454, V _a455, V _a456, V[] _rest452) => {
Invoke(Invoke(Invoke(t_457, "to", ((V)(90D)), NewObj(2).Put("earL", ((V)((-10D)))).Put("earR", ((V)((-10D)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("earL", ((V)(3D))).Put("earR", ((V)(3D))).V), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_457, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("teddy", NewObj(2).Put("dr", ((V)("honey"))).Put("s", Fn((V _arrowThis466, int _argc459, V t_465, V _a462, V _a463, V _a464, V[] _rest460) => {
Invoke(Invoke(t_465, "to", ((V)(500D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(14D)), ((V)((-4D)))), NewObj(4).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("smile", ((V)(1D))).Put("blush", ((V)(0.5))).V)), "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("tongue", ((V)(0.4))).V, NewObj(1).Put("tongue", ((V)(0D))).V, ((V)("s")));
Call(bk_16, V.Undef, t_465, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("hoot", NewObj(3).Put("dr", ((V)("moon"))).Put("wk", NewObj(2).Put("tfl", ((V)(1D))).Put("wfl", ((V)(1D))).V).Put("s", Fn((V _arrowThis474, int _argc467, V t_473, V _a470, V _a471, V _a472, V[] _rest468) => {
Invoke(Invoke(Invoke(Invoke(t_473, "to", ((V)(300D)), NewObj(5).Put("close", ((V)(0D))).Put("winkL", ((V)(1D))).Put("tfl", ((V)(0.6))).Put("lx", ((V)(0.6))).Put("zz", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(1400D))), "to", ((V)(400D)), NewObj(4).Put("close", ((V)(1D))).Put("winkL", ((V)(0D))).Put("tfl", ((V)(0D))).Put("lx", ((V)(0D))).V), "to", ((V)(400D)), NewObj(1).Put("zz", ((V)(1D))).V);
Call(bk_16, V.Undef, t_473, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("leo", NewObj(3).Put("dr", ((V)("crown"))).Put("wk", NewObj(2).Put("mfl", ((V)(1D))).Put("msh", ((V)(1D))).V).Put("s", Fn((V _arrowThis482, int _argc475, V t_481, V _a478, V _a479, V _a480, V[] _rest476) => {
Invoke(Invoke(Invoke(t_481, "to", ((V)(400D)), NewObj(3).Put("mfl", ((V)(0.7))).Put("open", ((V)(0.35))).Put("puff", ((V)(0.3))).V, ((V)("o"))), "wait", ((V)(600D))), "to", ((V)(600D)), NewObj(3).Put("mfl", ((V)(0D))).Put("open", ((V)(0D))).Put("puff", ((V)(0D))).V);
Call(bk_16, V.Undef, t_481, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("panko", NewObj(2).Put("dr", ((V)("bamboo"))).Put("s", Fn((V _arrowThis490, int _argc483, V t_489, V _a486, V _a487, V _a488, V[] _rest484) => {
Invoke(t_489, "osc", ((V)(2000D)), ((V)(6D)), NewObj(2).Put("open", ((V)(0.2))).Put("puff", ((V)(0.5))).V, NewObj(2).Put("open", ((V)(0D))).Put("puff", ((V)(0.2))).V, ((V)("s")));
Call(bk_16, V.Undef, t_489, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("acorn", NewObj(3).Put("dr", ((V)("acorn"))).Put("wk", NewObj(1).Put("tfl", ((V)(1D))).V).Put("s", Fn((V _arrowThis498, int _argc491, V t_497, V _a494, V _a495, V _a496, V[] _rest492) => {
return Call(sp_15, V.Undef, t_497, NewObj(2).Put("tfl", ((V)(1D))).Put("tsw", ((V)(0.5))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("fawn", NewObj(3).Put("dr", ((V)("flower"))).Put("wk", NewObj(2).Put("earL", ((V)((-14D)))).Put("earR", ((V)((-14D)))).V).Put("s", Fn((V _arrowThis506, int _argc499, V t_505, V _a502, V _a503, V _a504, V[] _rest500) => {
Invoke(Call(ear_17, V.Undef, t_505, ((V)((-1D))), ((V)(12D))), "wait", ((V)(500D)));
Call(ear_17, V.Undef, t_505, ((V)(1D)), ((V)(12D)));
Call(bk_16, V.Undef, t_505, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("moss", NewObj(3).Put("dr", ((V)("drop"))).Put("wk", NewObj(1).Put("cb", ((V)(1D))).V).Put("s", Fn((V _arrowThis514, int _argc507, V t_513, V _a510, V _a511, V _a512, V[] _rest508) => {
Invoke(Invoke(t_513, "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("cb", ((V)(0.8))).V, NewObj(1).Put("cb", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("dust")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_513, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("sprout", NewObj(3).Put("dr", ((V)("sun"))).Put("wk", NewObj(1).Put("blm", ((V)(1D))).V).Put("s", Fn((V _arrowThis522, int _argc515, V t_521, V _a518, V _a519, V _a520, V[] _rest516) => {
return Call(sp_15, V.Undef, t_521, NewObj(1).Put("blm", ((V)(0.8))).V, ((V)(1800D)), ((V)(1800D)));
}, 1, "s", true)).V).Put("hana", NewObj(3).Put("dr", ((V)("carrot"))).Put("wk", NewObj(1).Put("tw", ((V)(1D))).V).Put("s", Fn((V _arrowThis530, int _argc523, V t_529, V _a526, V _a527, V _a528, V[] _rest524) => {
Invoke(Invoke(Invoke(t_529, "to", ((V)(400D)), NewObj(1).Put("flL", ((V)(0.8))).V), "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("tw", ((V)(1D))).V, NewObj(1).Put("tw", ((V)((-1D)))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(1).Put("flL", ((V)(0D))).V);
Call(bk_16, V.Undef, t_529, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("boo", NewObj(2).Put("dr", ((V)("heart"))).Put("s", Fn((V _arrowThis538, int _argc531, V t_537, V _a534, V _a535, V _a536, V[] _rest532) => {
return Call(sp_15, V.Undef, t_537, NewObj(1).Put("gho", ((V)(0.45))).V, ((V)(1800D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("pixie", NewObj(4).Put("dr", ((V)("star"))).Put("wk", NewObj(2).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.6))).V).Put("wfx", Arr(((V)("dust")), ((V)("body")), ((V)(4D)))).Put("s", Fn((V _arrowThis546, int _argc539, V t_545, V _a542, V _a543, V _a544, V[] _rest540) => {
Call(sp_15, V.Undef, t_545, NewObj(2).Put("wfl", ((V)(0.7))).Put("wsp", ((V)(0.4))).V, ((V)(1400D)), ((V)(1000D)));
Invoke(t_545, "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("floof", NewObj(3).Put("dr", ((V)("snow"))).Put("wk", NewObj(1).Put("fzz", ((V)(1D))).V).Put("s", Fn((V _arrowThis554, int _argc547, V t_553, V _a550, V _a551, V _a552, V[] _rest548) => {
Invoke(Invoke(Invoke(t_553, "to", ((V)(200D)), NewObj(1).Put("fzz", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.5))).V, NewObj(1).Put("x", ((V)((-0.5)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(1).Put("fzz", ((V)(0D))).V);
Call(bk_16, V.Undef, t_553, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("unibun", NewObj(3).Put("dr", ((V)("rainbow"))).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(5D)))).Put("s", Fn((V _arrowThis562, int _argc555, V t_561, V _a558, V _a559, V _a560, V[] _rest556) => {
Invoke(t_561, "fx", ((V)("spark")), ((V)("head")), ((V)(4D)));
Call(ear_17, V.Undef, t_561, ((V)((-1D))), ((V)(10D)));
Call(bk_16, V.Undef, t_561, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("gumdrop", NewObj(3).Put("dr", ((V)("candy"))).Put("wk", NewObj(1).Put("jig", ((V)(1D))).V).Put("s", Fn((V _arrowThis570, int _argc563, V t_569, V _a566, V _a567, V _a568, V[] _rest564) => {
return Call(sp_15, V.Undef, t_569, NewObj(1).Put("jig", ((V)(0.8))).V, ((V)(1200D)), ((V)(1000D)));
}, 1, "s", true)).V).Put("ember", NewObj(4).Put("dr", ((V)("fire"))).Put("zc", ((V)("#e2621e"))).Put("wk", NewObj(1).Put("cfl", ((V)(1D))).V).Put("s", Fn((V _arrowThis578, int _argc571, V t_577, V _a574, V _a575, V _a576, V[] _rest572) => {
return Call(sp_15, V.Undef, t_577, NewObj(1).Put("cfl", ((V)(0.6))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("drako", NewObj(3).Put("dr", ((V)("fire"))).Put("wk", NewObj(2).Put("wsp", ((V)(1D))).Put("wfl", ((V)(1D))).V).Put("s", Fn((V _arrowThis586, int _argc579, V t_585, V _a582, V _a583, V _a584, V[] _rest580) => {
Invoke(Invoke(Invoke(Invoke(t_585, "to", ((V)(400D)), NewObj(1).Put("puff", ((V)(0.6))).V), "to", ((V)(200D)), NewObj(1).Put("puff", ((V)(0D))).V), "fx", ((V)("steam")), ((V)("head"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)(0.6))).V, NewObj(1).Put("tsw", ((V)((-0.6)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_585, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("jinni", NewObj(3).Put("dr", ((V)("star"))).Put("wk", NewObj(2).Put("glo", ((V)(1D))).Put("gwh", ((V)(1D))).V).Put("s", Fn((V _arrowThis594, int _argc587, V t_593, V _a590, V _a591, V _a592, V[] _rest588) => {
Call(sp_15, V.Undef, t_593, NewObj(2).Put("glo", ((V)(0.8))).Put("gwh", ((V)(0.6))).V, ((V)(1600D)), ((V)(1400D)));
Invoke(t_593, "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("cuppy", NewObj(3).Put("dr", ((V)("cherry"))).Put("wfx", Arr(((V)("sprinkle")), ((V)("head")))).Put("s", Fn((V _arrowThis602, int _argc595, V t_601, V _a598, V _a599, V _a600, V[] _rest596) => {
Invoke(Invoke(t_601, "fx", ((V)("sprinkle")), ((V)("head"))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_601, "B"), "sq"), ((V)(0.04)))).V, NewObj(1).Put("sq", Get(Get(t_601, "B"), "sq")).V, ((V)("o")));
Call(bk_16, V.Undef, t_601, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("chip", NewObj(3).Put("dr", ((V)("cup"))).Put("wfx", Arr(((V)("crumb")), ((V)("body")), ((V)(4D)))).Put("s", Fn((V _arrowThis610, int _argc603, V t_609, V _a606, V _a607, V _a608, V[] _rest604) => {
Invoke(Invoke(t_609, "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.5))).V, NewObj(1).Put("x", ((V)((-0.5)))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_609, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("twisty", NewObj(3).Put("dr", ((V)("heart"))).Put("wfx", Arr(((V)("salt")), ((V)("head")))).Put("s", Fn((V _arrowThis618, int _argc611, V t_617, V _a614, V _a615, V _a616, V[] _rest612) => {
Invoke(Invoke(t_617, "osc", ((V)(2000D)), ((V)(2D)), NewObj(1).Put("tilt", Add(Get(Get(t_617, "B"), "tilt"), ((V)(4D)))).V, NewObj(1).Put("tilt", ((V)((ToNum(Get(Get(t_617, "B"), "tilt")) - 4D)))).V, ((V)("s"))), "fx", ((V)("salt")), ((V)("head")));
Call(bk_16, V.Undef, t_617, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("crois", NewObj(2).Put("dr", ((V)("cup"))).Put("s", Fn((V _arrowThis626, int _argc619, V t_625, V _a622, V _a623, V _a624, V[] _rest620) => {
return Call(sp_15, V.Undef, t_625, NewObj(3).Put("lean", ((V)(1.4))).Put("tilt", Add(Get(Get(t_625, "B"), "tilt"), ((V)(3D)))).Put("smile", ((V)(0.9))).V, ((V)(1800D)), ((V)(1200D)));
}, 1, "s", true)).V).Put("maca", NewObj(2).Put("dr", ((V)("flower"))).Put("s", Fn((V _arrowThis634, int _argc627, V t_633, V _a630, V _a631, V _a632, V[] _rest628) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_633, "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_633, "B"), "sq"), ((V)(0.1)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_633, "B"), "sq")).V), "wait", ((V)(300D))), "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_633, "B"), "sq"), ((V)(0.08)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_633, "B"), "sq")).V);
Call(bk_16, V.Undef, t_633, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("puddi", NewObj(2).Put("dr", ((V)("cherry"))).Put("s", Fn((V _arrowThis642, int _argc635, V t_641, V _a638, V _a639, V _a640, V[] _rest636) => {
Invoke(t_641, "osc", ((V)(1600D)), ((V)(6D)), NewObj(2).Put("sq", Add(Get(Get(t_641, "B"), "sq"), ((V)(0.05)))).Put("x", ((V)(0.3))).V, NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_641, "B"), "sq")) - 0.02)))).Put("x", ((V)((-0.3)))).V, ((V)("l")));
Call(bk_16, V.Undef, t_641, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("mochi", NewObj(2).Put("dr", ((V)("berry"))).Put("s", Fn((V _arrowThis650, int _argc643, V t_649, V _a646, V _a647, V _a648, V[] _rest644) => {
return Call(sp_15, V.Undef, t_649, NewObj(2).Put("sq", Add(Get(Get(t_649, "B"), "sq"), ((V)(0.14)))).Put("smile", ((V)(0.9))).V, ((V)(1800D)), ((V)(1400D)));
}, 1, "s", true)).V).Put("cakey", NewObj(2).Put("dr", ((V)("star"))).Put("s", Fn((V _arrowThis658, int _argc651, V t_657, V _a654, V _a655, V _a656, V[] _rest652) => {
Invoke(Invoke(Invoke(Invoke(t_657, "to", ((V)(500D)), NewObj(1).Put("puff", ((V)(0.7))).V), "to", ((V)(600D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(300D)), NewObj(2).Put("open", ((V)(0D))).Put("mw", Get(Get(t_657, "B"), "mw")).V);
Call(bk_16, V.Undef, t_657, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("sugarplum", NewObj(3).Put("dr", ((V)("candy"))).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(4D)))).Put("s", Fn((V _arrowThis666, int _argc659, V t_665, V _a662, V _a663, V _a664, V[] _rest660) => {
Invoke(Invoke(Invoke(t_665, "to", ((V)(400D)), NewObj(3).Put("armR", ((V)(70D))).Put("hRy", ((V)((-2D)))).Put("smile", ((V)(0.9))).V, ((V)("o"))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-3D)))).V, NewObj(1).Put("hRx", ((V)(3D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(bk_16, V.Undef, t_665, ((V)(500D)));
return default;
}, 1, "s", true)).V).Put("gourdy", NewObj(3).Put("dr", ((V)("moon"))).Put("zc", ((V)("#e2621e"))).Put("s", Fn((V _arrowThis674, int _argc667, V t_673, V _a670, V _a671, V _a672, V[] _rest668) => {
Invoke(t_673, "osc", ((V)(2400D)), ((V)(2D)), NewObj(2).Put("tilt", Add(Get(Get(t_673, "B"), "tilt"), ((V)(5D)))).Put("x", ((V)(1D))).V, NewObj(2).Put("tilt", ((V)((ToNum(Get(Get(t_673, "B"), "tilt")) - 5D)))).Put("x", ((V)((-1D)))).V, ((V)("s")));
Call(bk_16, V.Undef, t_673, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("batty", NewObj(4).Put("dr", ((V)("moon"))).Put("lp", NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V).Put("wk", NewObj(2).Put("armL", ((V)(172D))).Put("armR", ((V)(172D))).V).Put("s", Fn((V _arrowThis682, int _argc675, V t_681, V _a678, V _a679, V _a680, V[] _rest676) => {
return Call(sp_15, V.Undef, t_681, NewObj(4).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("hLx", ((V)(12D))).Put("hRx", ((V)((-12D)))).V, ((V)(1400D)), ((V)(1800D)));
}, 1, "s", true)).V).Put("kernel", NewObj(2).Put("dr", ((V)("star"))).Put("s", Fn((V _arrowThis690, int _argc683, V t_689, V _a686, V _a687, V _a688, V[] _rest684) => {
Invoke(Invoke(Invoke(t_689, "to", ((V)(120D)), NewObj(2).Put("lift", Add(Get(Get(t_689, "B"), "lift"), ((V)(2.4)))).Put("sq", ((V)((ToNum(Get(Get(t_689, "B"), "sq")) - 0.06)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("lift", Get(Get(t_689, "B"), "lift")).Put("sq", Add(Get(Get(t_689, "B"), "sq"), ((V)(0.04)))).V, ((V)("i"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_16, V.Undef, t_689, ((V)(400D)));
return default;
}, 1, "s", true)).V).Put("hexie", NewObj(3).Put("dr", ((V)("moon"))).Put("wfx", Arr(((V)("spark")), ((V)("head")), ((V)(4D)))).Put("s", Fn((V _arrowThis698, int _argc691, V t_697, V _a694, V _a695, V _a696, V[] _rest692) => {
Call(sp_15, V.Undef, t_697, NewObj(1).Put("curl", ((V)(0.7))).V, ((V)(1400D)), ((V)(1200D)));
Invoke(t_697, "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "s", true)).V).Put("mumbles", NewObj(2).Put("dr", ((V)("candy"))).Put("s", Fn((V _arrowThis706, int _argc699, V t_705, V _a702, V _a703, V _a704, V[] _rest700) => {
Invoke(Invoke(Invoke(t_705, "to", ((V)(900D)), NewObj(5).Put("armL", ((V)(88D))).Put("armR", ((V)(88D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("open", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(1200D))), "to", ((V)(900D)), NewObj(5).Put("armL", Get(Get(t_705, "B"), "armL")).Put("armR", Get(Get(t_705, "B"), "armR")).Put("hLy", Get(Get(t_705, "B"), "hLy")).Put("hRy", Get(Get(t_705, "B"), "hRy")).Put("open", ((V)(0D))).V, ((V)("io")));
Call(bk_16, V.Undef, t_705, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("hocus", NewObj(3).Put("dr", ((V)("star"))).Put("wfx", Arr(((V)("spark")), ((V)("body")), ((V)(4D)))).Put("s", Fn((V _arrowThis714, int _argc707, V t_713, V _a710, V _a711, V _a712, V[] _rest708) => {
Invoke(Invoke(Invoke(t_713, "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(800D))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
Call(bk_16, V.Undef, t_713, ((V)(300D)));
return default;
}, 1, "s", true)).V).Put("countsquishula", NewObj(3).Put("dr", ((V)("moon"))).Put("lp", Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(12D)), ((V)((-4D)))), NewObj(4).Put("armL", ((V)(26D))).Put("armR", ((V)(26D))).Put("htilt", ((V)(0D))).Put("tilt", ((V)(0D))).V)).Put("s", Fn((V _arrowThis722, int _argc715, V t_721, V _a718, V _a719, V _a720, V[] _rest716) => {
Invoke(Invoke(Invoke(Invoke(t_721, "to", ((V)(300D)), NewObj(4).Put("close", ((V)(0D))).Put("winkL", ((V)(1D))).Put("smile", ((V)(0.6))).Put("zz", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(1200D))), "to", ((V)(400D)), NewObj(2).Put("close", ((V)(1D))).Put("winkL", ((V)(0D))).V), "to", ((V)(400D)), NewObj(1).Put("zz", ((V)(1D))).V);
Call(bk_16, V.Undef, t_721, ((V)(400D)));
return default;
}, 1, "s", true)).V).V;
Invoke(Object_keys(PROF_14), "forEach", Fn((V _arrowThis730, int _argc723, V k_729, V _a726, V _a727, V _a728, V[] _rest724) => {
return Call(bedBuild_10, V.Undef, k_729, (GetK(B_18, k_729) is var _t731 && Truthy(_t731) ? _t731 : NewObj(0).V));
}, 1, "", true));
return default;
}, 1, "", false));
        }
    }
}
