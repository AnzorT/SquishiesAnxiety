// house-idle-c.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house_idle_c_js
    {

        public static void Run()
        {
Invoke(Set(G("window"), "HouseIdleC", (Get(G("window"), "HouseIdleC") is var _t1000 && Truthy(_t1000) ? _t1000 : Arr())), "push", Fn((V _self1, int _argc2, V W_8, V _a5, V _a6, V _a7, V[] _rest3) => {
V hand_9 = default;
V both_10 = default;
V o_11 = default;
V sp_12 = default;
V d_13 = default;
V fxs_14 = default;
if (_self1.IsNullish) _self1 = GlobalV;
{ V _t15 = Get(Get(G("window"), "RiveRig"), "HOUSE");
if (_t15.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t15));
{ V _t16 = Get(_t15, "hand");
hand_9 = _t16; }
{ V _t17 = Get(_t15, "both");
both_10 = _t17; }
{ V _t18 = Get(_t15, "o");
o_11 = _t18; } }
sp_12 = Get(W_8, "sp");
d_13 = Fn((V _self1, int _argc19, V k_25, V L_26, V X_27, V _a24, V[] _rest20) => {
return Invoke(W_8, "build", k_25, L_26, X_27);
}, 3, "", true);
fxs_14 = Fn((V _self1, int _argc28, V t_34, V n_35, V w_36, V c_37, V[] _rest29) => {
V k_38 = default;
V gap_39 = default;
k_38 = (_argc28 > 4 ? _rest29[0] : V.Undef);
gap_39 = (_argc28 > 5 ? _rest29[1] : V.Undef);
{
V i_40 = default;
i_40 = ((V)(0D));
while (true) {
if (!(Lt(i_40, k_38))) break;
Invoke(Invoke(t_34, "fx", n_35, w_36, c_37), "wait", gap_39);
PostInc(ref i_40, 1D);
}
}
return t_34;
return default;
}, 6, "", true);
Call(d_13, V.Undef, ((V)("mittens")), Arr(((V)("groom")), Arr(((V)("scratch")), ((V)(1D))), Fn((V _self1, int _argc42, V t_48, V _a45, V _a46, V _a47, V[] _rest43) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_48, "to", ((V)(600D)), NewObj(9).Put("pitch", ((V)((-0.3)))).Put("lean", ((V)(1.2))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("sq", ((V)(0.08))).Put("lift", ((V)((-1D)))).Put("wag", ((V)(18D))).Put("curl", ((V)(0.4))).Put("close", ((V)(0.8))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("hLy", ((V)(2D))).Put("hRy", ((V)((-1D)))).V, NewObj(2).Put("hLy", ((V)((-1D)))).Put("hRy", ((V)(2D))).V, ((V)("s"))), "wait", ((V)(300D))), "to", ((V)(500D)), NewObj(8).Put("pitch", ((V)(0.2))).Put("lean", ((V)((-0.6)))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(0.6))).Put("wag", ((V)((-12D)))).Put("open", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(300D)));
return default;
}, 1, "", true), ((V)("wag"))));
Call(d_13, V.Undef, ((V)("biscuit")), Arr(Fn((V _self1, int _argc49, V t_55, V _a52, V _a53, V _a54, V[] _rest50) => {
Invoke(Invoke(t_55, "to", ((V)(200D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("tongue", ((V)(0.5))).V), "osc", ((V)(1600D)), ((V)(8D)), NewObj(3).Put("wag", ((V)(30D))).Put("lift", ((V)(0.8))).Put("tilt", ((V)(1.5))).V, NewObj(3).Put("wag", ((V)((-30D)))).Put("lift", ((V)(0D))).Put("tilt", ((V)((-1.5)))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("sniff")), ((V)("shake")), Fn((V _self1, int _argc56, V t_62, V _a59, V _a60, V _a61, V[] _rest57) => {
Invoke(t_62, "to", ((V)(160D)), NewObj(5).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("tongue", ((V)(0.5))).Put("wag", ((V)(30D))).V);
{
V i_63 = default;
i_63 = ((V)(0D));
while (true) {
if (!(LtN(i_63, 2D))) break;
Invoke(Invoke(t_62, "to", ((V)(700D)), NewObj(3).Put("spin", ((V)(360D))).Put("lift", ((V)(1.6))).Put("wag", ((V)((-30D)))).V, ((V)("l"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
PostInc(ref i_63, 1D);
}
}
Invoke(Invoke(t_62, "to", ((V)(400D)), NewObj(4).Put("lift", ((V)(0D))).Put("sqz", ((V)(0.6))).Put("htilt", ((V)(8D))).Put("wag", ((V)(0D))).V, ((V)("o"))), "osc", ((V)(600D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(3D))).V, NewObj(1).Put("tilt", ((V)((-3D)))).V, ((V)("s")));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("prickle")), Arr(Fn((V _self1, int _argc65, V t_71, V _a68, V _a69, V _a70, V[] _rest66) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_71, "to", ((V)(380D)), NewObj(5).Put("curl", ((V)(1D))).Put("sq", ((V)(0.14))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V, ((V)("io"))), "wait", ((V)(1100D))), "to", ((V)(180D)), NewObj(3).Put("curl", ((V)(0D))).Put("sq", ((V)((-0.05)))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D)));
return default;
}, 1, "", true), ((V)("sniff")), Arr(((V)("scratch")), ((V)((-1D))))));
Call(d_13, V.Undef, ((V)("nibbles")), Arr(Fn((V _self1, int _argc72, V t_78, V _a75, V _a76, V _a77, V[] _rest73) => {
Invoke(Invoke(Invoke(Invoke(t_78, "to", ((V)(300D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(9D)), ((V)((-9D)))), NewObj(3).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("puff", ((V)(1D))).V)), "osc", ((V)(1800D)), ((V)(8D)), NewObj(2).Put("open", ((V)(0.25))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("open", ((V)(0D))).Put("htilt", ((V)((-3D)))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(3).Put("puff", ((V)(0.4))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), Fn((V _self1, int _argc79, V t_85, V _a82, V _a83, V _a84, V[] _rest80) => {
Invoke(Invoke(t_85, "to", ((V)(380D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(6D)), ((V)((-22D)))), NewObj(3).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("close", ((V)(0.9))).V), ((V)("io"))), "osc", ((V)(1300D)), ((V)(5D)), NewObj(2).Put("hLy", ((V)((-26D)))).Put("hRy", ((V)((-18D)))).V, NewObj(2).Put("hLy", ((V)((-18D)))).Put("hRy", ((V)((-26D)))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _self1, int _argc86, V t_92, V _a89, V _a90, V _a91, V[] _rest87) => {
Invoke(Invoke(Invoke(Invoke(t_92, "to", ((V)(400D)), NewObj(6).Put("lift", ((V)(2D))).Put("sq", ((V)((-0.08)))).Put("ly", ((V)((-0.8)))).Put("lx", ((V)(0.6))).Put("armL", ((V)(16D))).Put("armR", ((V)(16D))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(6D)), NewObj(1).Put("mw", ((V)(0.55))).V, NewObj(1).Put("mw", ((V)(1D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("lx", ((V)((-0.6)))).V, ((V)("io"))), "wait", ((V)(500D)));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("quill")), Arr(((V)("shy")), Arr(((V)("scratch")), ((V)(1D))), ((V)("nod")), ((V)("ponder"))));
Call(d_13, V.Undef, ((V)("truffle")), Arr(Fn((V _self1, int _argc93, V t_99, V _a96, V _a97, V _a98, V[] _rest94) => {
Invoke(Invoke(Invoke(t_99, "to", ((V)(260D)), NewObj(3).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.4))).V), "osc", ((V)(1500D)), ((V)(6D)), NewObj(3).Put("tilt", ((V)(3D))).Put("wag", ((V)(22D))).Put("lift", ((V)(0.5))).V, NewObj(3).Put("tilt", ((V)((-3D)))).Put("wag", ((V)((-22D)))).Put("lift", ((V)(0D))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(4).Put("tilt", ((V)(0D))).Put("wag", ((V)(0D))).Put("sqz", ((V)(0D))).Put("hap", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("sniff")), Arr(((V)("scratch")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("ribbit")), Arr(Arr(((V)("hops")), ((V)(3D))), Fn((V _self1, int _argc100, V t_106, V _a103, V _a104, V _a105, V[] _rest101) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_106, "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0.9))).Put("open", ((V)(0D))).V), "wait", ((V)(400D))), "to", ((V)(160D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.5))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(2).Put("open", ((V)(0D))).Put("hap", ((V)(0.6))).V);
return default;
}, 1, "", true), ((V)("nod"))));
Call(d_13, V.Undef, ((V)("poppy")), Arr(Arr(((V)("hops")), ((V)(3D))), ((V)("ears")), Fn((V _self1, int _argc107, V t_113, V _a110, V _a111, V _a112, V[] _rest108) => {
Invoke(Invoke(Invoke(t_113, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.4))).V), "osc", ((V)(1200D)), ((V)(9D)), NewObj(3).Put("mw", ((V)(0.5))).Put("earL", ((V)((-4D)))).Put("earR", ((V)(4D))).V, NewObj(3).Put("mw", ((V)(1D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(3).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("hap", ((V)(0.6))).V);
return default;
}, 1, "", true), Fn((V _self1, int _argc114, V t_120, V _a117, V _a118, V _a119, V[] _rest115) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_120, "to", ((V)(130D)), NewObj(2).Put("footR", ((V)(3.2))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "to", ((V)(110D)), NewObj(2).Put("footR", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)("footR")), ((V)(3D))), "wait", ((V)(300D))), "to", ((V)(130D)), NewObj(1).Put("footR", ((V)(3.2))).V, ((V)("o"))), "to", ((V)(110D)), NewObj(2).Put("footR", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)("footR")), ((V)(3D))), "to", ((V)(220D)), NewObj(4).Put("sq", ((V)(0D))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).Put("htilt", ((V)(5D))).V);
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("duchess")), Arr(((V)("groom")), Fn((V _self1, int _argc121, V t_127, V _a124, V _a125, V _a126, V[] _rest122) => {
return Call(sp_12, V.Undef, t_127, NewObj(6).Put("htilt", ((V)(9D))).Put("close", ((V)(0.7))).Put("smile", ((V)(0.6))).Put("pitch", ((V)(0.3))).Put("lean", ((V)((-0.6)))).Put("wag", ((V)(14D))).V, ((V)(1300D)), ((V)(1400D)));
}, 1, "", true), Fn((V _self1, int _argc128, V t_134, V _a131, V _a132, V _a133, V[] _rest129) => {
Invoke(Invoke(Invoke(t_134, "osc", ((V)(1400D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(22D))).V, NewObj(1).Put("wag", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(260D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-18D)))), NewObj(2).Put("armR", ((V)(60D))).Put("close", ((V)(0.5))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(2D)), NewObj(1).Put("hRy", ((V)((-20D)))).V, NewObj(1).Put("hRy", ((V)((-16D)))).V, ((V)("s")));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("mamapaws")), Arr(Fn((V _self1, int _argc135, V t_141, V _a138, V _a139, V _a140, V[] _rest136) => {
Invoke(Invoke(Invoke(t_141, "to", ((V)(300D)), NewObj(3).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.4))).V), "fx", ((V)("heart")), ((V)("head"))), "osc", ((V)(3200D)), ((V)(4D)), NewObj(3).Put("lean", ((V)(1.4))).Put("tilt", ((V)(2.4))).Put("htilt", ((V)(4D))).V, NewObj(3).Put("lean", ((V)((-1.4)))).Put("tilt", ((V)((-2.4)))).Put("htilt", ((V)((-4D)))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("sniff")), ((V)("wag")), ((V)("belly"))));
Call(d_13, V.Undef, ((V)("nimbo")), Arr(Fn((V _self1, int _argc142, V t_148, V _a145, V _a146, V _a147, V[] _rest143) => {
Invoke(t_148, "to", ((V)(400D)), NewObj(3).Put("puff", ((V)(0.8))).Put("sq", ((V)((-0.06)))).Put("frown", ((V)(0.3))).V, ((V)("io")));
Invoke(Call(fxs_14, V.Undef, t_148, ((V)("drop")), ((V)("body")), ((V)(3D)), ((V)(5D)), ((V)(220D))), "to", ((V)(300D)), NewObj(5).Put("puff", ((V)(0D))).Put("sq", ((V)(0.04))).Put("frown", ((V)(0D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(0.8))).V);
return default;
}, 1, "", true), Fn((V _self1, int _argc149, V t_155, V _a152, V _a153, V _a154, V[] _rest150) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_155, "to", ((V)(500D)), NewObj(4).Put("pitch", ((V)(0.35))).Put("open", ((V)(0.45))).Put("close", ((V)(0.7))).Put("sq", ((V)((-0.08)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(5).Put("pitch", ((V)((-0.4)))).Put("open", ((V)(0.9))).Put("sqz", ((V)(1D))).Put("close", ((V)(0D))).Put("sq", ((V)(0.2))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("nose")), ((V)(8D))), "fx", ((V)("sneeze")), ((V)("nose"))), "to", ((V)(260D)), NewObj(3).Put("pitch", ((V)(0D))).Put("open", ((V)(0.1))).Put("sq", ((V)(0D))).V), "to", ((V)(260D)), NewObj(3).Put("sqz", ((V)(0D))).Put("open", ((V)(0D))).Put("blush", ((V)(0.7))).V), "wait", ((V)(400D)));
return default;
}, 1, "", true), ((V)("hum"))));
Call(d_13, V.Undef, ((V)("lumi")), Arr(Fn((V _self1, int _argc156, V t_162, V _a159, V _a160, V _a161, V[] _rest157) => {
Invoke(Invoke(Invoke(Invoke(t_162, "to", ((V)(450D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-10D)))), NewObj(4).Put("armR", ((V)(90D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).Put("ly", ((V)((-0.7)))).V), ((V)("io"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(2).Put("hRx", ((V)((-3D)))).Put("htilt", ((V)(4D))).V, NewObj(2).Put("hRx", ((V)(3D))).Put("htilt", ((V)((-4D)))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D)));
return default;
}, 1, "", true), ((V)("hum")), Arr(((V)("twirl")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("bubbly")), Arr(Fn((V _self1, int _argc163, V t_169, V _a166, V _a167, V _a168, V[] _rest164) => {
Invoke(Invoke(t_169, "osc", ((V)(3000D)), ((V)(2D)), NewObj(2).Put("turn", ((V)(0.5))).Put("x", ((V)(1D))).V, NewObj(2).Put("turn", ((V)((-0.5)))).Put("x", ((V)((-1D)))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "", true), Fn((V _self1, int _argc170, V t_176, V _a173, V _a174, V _a175, V[] _rest171) => {
Invoke(Invoke(t_176, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(1D))).Put("mw", ((V)(0.4))).V), "to", ((V)(400D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.25))).Put("mw", ((V)(0.35))).V, ((V)("o")));
Invoke(Call(fxs_14, V.Undef, t_176, ((V)("bigbubble")), ((V)("mouth")), ((V)(1D)), ((V)(3D)), ((V)(300D))), "to", ((V)(200D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), ((V)("wiggle"))));
Call(d_13, V.Undef, ((V)("twinkle")), Arr(Fn((V _self1, int _argc177, V t_183, V _a180, V _a181, V _a182, V[] _rest178) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_183, "to", ((V)(260D)), NewObj(3).Put("wide", ((V)(0.7))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("body")), ((V)(5D))), "wait", ((V)(500D))), "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(300D)));
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)((-1D)))), ((V)("nod"))));
Call(d_13, V.Undef, ((V)("zappi")), Arr(Fn((V _self1, int _argc184, V t_190, V _a187, V _a188, V _a189, V[] _rest185) => {
Invoke(Invoke(Invoke(Invoke(t_190, "to", ((V)(80D)), NewObj(3).Put("zap", ((V)(1D))).Put("wide", ((V)(1D))).Put("x", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(7D)), NewObj(1).Put("x", ((V)((-0.8)))).V, NewObj(1).Put("x", ((V)(0.8))).V, ((V)("l"))), "fx", ((V)("spark")), ((V)("body")), ((V)(6D))), "to", ((V)(300D)), NewObj(3).Put("zap", ((V)(0D))).Put("wide", ((V)(0D))).Put("x", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _self1, int _argc191, V t_197, V _a194, V _a195, V _a196, V[] _rest192) => {
Invoke(Invoke(Invoke(t_197, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.9))).Put("smile", ((V)(1D))).V), "osc", ((V)(800D)), ((V)(8D)), NewObj(2).Put("footL", ((V)(1.6))).Put("footR", ((V)(0D))).V, NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(1.6))).V, ((V)("l"))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(2D)))));
Call(d_13, V.Undef, ((V)("plip")), Arr(Fn((V _self1, int _argc198, V t_204, V _a201, V _a202, V _a203, V[] _rest199) => {
Invoke(Invoke(Invoke(t_204, "fx", ((V)("drop")), ((V)("head")), ((V)(2D))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("sq", ((V)(0.08))).V, NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "", true), ((V)("hum")), Arr(((V)("hops")), ((V)(2D)))));
Call(d_13, V.Undef, ((V)("breeze")), Arr(Fn((V _self1, int _argc205, V t_211, V _a208, V _a209, V _a210, V[] _rest206) => {
Invoke(Invoke(Invoke(Invoke(t_211, "to", ((V)(300D)), NewObj(3).Put("open", ((V)(0.5))).Put("puff", ((V)(0.6))).Put("lean", ((V)((-1.4)))).V), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(500D)), NewObj(3).Put("lean", ((V)(2D))).Put("open", ((V)(0.1))).Put("puff", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(400D)));
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("hum"))));
Call(d_13, V.Undef, ((V)("dusty")), Arr(Fn((V _self1, int _argc212, V t_218, V _a215, V _a216, V _a217, V[] _rest213) => {
Invoke(Invoke(Invoke(t_218, "fx", ((V)("dust")), ((V)("body")), ((V)(4D))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("sq", ((V)(0.05))).V, NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "", true), ((V)("sneeze")), ((V)("ears")), ((V)("flap"))));
Call(d_13, V.Undef, ((V)("aurora")), Arr(Fn((V _self1, int _argc219, V t_225, V _a222, V _a223, V _a224, V[] _rest220) => {
Invoke(Invoke(Invoke(Invoke(t_225, "to", ((V)(300D)), NewObj(2).Put("spout", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D))), "wait", ((V)(900D))), "to", ((V)(400D)), NewObj(1).Put("spout", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _self1, int _argc226, V t_232, V _a229, V _a230, V _a231, V[] _rest227) => {
return Call(sp_12, V.Undef, t_232, NewObj(3).Put("glow", ((V)(1D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true), Fn((V _self1, int _argc233, V t_239, V _a236, V _a237, V _a238, V[] _rest234) => {
Invoke(t_239, "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("s")));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("mallow")), Arr(Fn((V _self1, int _argc240, V t_246, V _a243, V _a244, V _a245, V[] _rest241) => {
Invoke(Invoke(Invoke(t_246, "to", ((V)(1200D)), NewObj(4).Put("sq", ((V)(0.2))).Put("lift", ((V)((-1.6)))).Put("close", ((V)(0.85))).Put("smile", ((V)(1D))).V, ((V)("s"))), "wait", ((V)(800D))), "to", ((V)(220D)), NewObj(4).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(1D))).Put("close", ((V)(0D))).Put("wide", ((V)(0.4))).V, ((V)("o")));
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(2D))), Fn((V _self1, int _argc247, V t_253, V _a250, V _a251, V _a252, V[] _rest248) => {
return Invoke(Call(sp_12, V.Undef, t_253, NewObj(3).Put("blush", ((V)(1D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(1200D))), "fx", ((V)("steam")), ((V)("head")));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("bao")), Arr(Fn((V _self1, int _argc254, V t_260, V _a257, V _a258, V _a259, V[] _rest255) => {
Invoke(Invoke(Invoke(Invoke(t_260, "to", ((V)(500D)), NewObj(4).Put("sq", ((V)((-0.07)))).Put("lift", ((V)(1.4))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("head"))), "wait", ((V)(500D))), "fx", ((V)("steam")), ((V)("head")));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("belly"))));
Call(d_13, V.Undef, ((V)("dunkie")), Arr(Fn((V _self1, int _argc261, V t_267, V _a264, V _a265, V _a266, V[] _rest262) => {
Invoke(Invoke(Invoke(t_267, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("x", ((V)(1.1))).Put("tilt", ((V)(3D))).V, NewObj(2).Put("x", ((V)((-1.1)))).Put("tilt", ((V)((-3D)))).V, ((V)("s"))), "fx", ((V)("sprinkle")), ((V)("head")));
return default;
}, 1, "", true), ((V)("belly")), Arr(((V)("hops")), ((V)(2D)))));
Call(d_13, V.Undef, ((V)("frybo")), Arr(Fn((V _self1, int _argc268, V t_274, V _a271, V _a272, V _a273, V[] _rest269) => {
return Call(sp_12, V.Undef, t_274, NewObj(3).Put("fw", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(900D)), ((V)(900D)));
}, 1, "", true), Fn((V _self1, int _argc275, V t_281, V _a278, V _a279, V _a280, V[] _rest276) => {
Invoke(Invoke(Invoke(t_281, "fx", ((V)("salt")), ((V)("head"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("l"))), "fx", ((V)("salt")), ((V)("head")));
return default;
}, 1, "", true), ((V)("clap"))));
Call(d_13, V.Undef, ((V)("bunbun")), Arr(Fn((V _self1, int _argc282, V t_288, V _a285, V _a286, V _a287, V[] _rest283) => {
Invoke(Invoke(Invoke(Invoke(t_288, "to", ((V)(300D)), NewObj(3).Put("split", ((V)(0.4))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(1).Put("shuf", ((V)(0.6))).V, NewObj(1).Put("shuf", ((V)((-0.6)))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(2).Put("split", ((V)(0D))).Put("shuf", ((V)(0D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.06))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("giggle"))));
Call(d_13, V.Undef, ((V)("choco")), Arr(Fn((V _self1, int _argc289, V t_295, V _a292, V _a293, V _a294, V[] _rest290) => {
return Call(sp_12, V.Undef, t_295, NewObj(3).Put("melt", ((V)(0.35))).Put("close", ((V)(0.75))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true), Fn((V _self1, int _argc296, V t_302, V _a299, V _a300, V _a301, V[] _rest297) => {
Invoke(Invoke(Invoke(Invoke(t_302, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0.08))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "fx", ((V)("crumb")), ((V)("body")), ((V)(3D))), "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), ((V)("belly"))));
Call(d_13, V.Undef, ((V)("scoop")), Arr(Fn((V _self1, int _argc303, V t_309, V _a306, V _a307, V _a308, V[] _rest304) => {
Invoke(t_309, "osc", ((V)(1400D)), ((V)(4D)), NewObj(2).Put("chb", ((V)(1D))).Put("hap", ((V)(0.7))).V, NewObj(2).Put("chb", ((V)(0D))).Put("hap", ((V)(0.4))).V, ((V)("o")));
return default;
}, 1, "", true), Fn((V _self1, int _argc310, V t_316, V _a313, V _a314, V _a315, V[] _rest311) => {
Invoke(Invoke(Invoke(t_316, "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)((-0.12)))).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.3))).Put("close", ((V)(0.6))).V), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("htilt", ((V)(6D))).V, NewObj(1).Put("htilt", ((V)((-6D)))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(4).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("boba")), Arr(Fn((V _self1, int _argc317, V t_323, V _a320, V _a321, V _a322, V[] _rest318) => {
Invoke(Invoke(Invoke(Invoke(t_323, "to", ((V)(300D)), NewObj(4).Put("sqz", ((V)(0.6))).Put("open", ((V)(0.15))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.3)))).V), "osc", ((V)(1200D)), ((V)(6D)), NewObj(2).Put("x", ((V)(0.5))).Put("sq", ((V)(0.02))).V, NewObj(2).Put("x", ((V)((-0.5)))).Put("sq", ((V)(0D))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(5).Put("sqz", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(400D)));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("wiggle"))));
Call(d_13, V.Undef, ((V)("chefbun")), Arr(Fn((V _self1, int _argc324, V t_330, V _a327, V _a328, V _a329, V[] _rest325) => {
Invoke(Invoke(Invoke(Invoke(t_330, "to", ((V)(380D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-14D)))), NewObj(3).Put("armR", ((V)(36D))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V)), "wait", ((V)(300D))), "to", ((V)(260D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)((-6D))), ((V)((-16D)))), NewObj(3).Put("armR", ((V)(70D))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).V), ((V)("o"))), "fx", ((V)("heart")), ((V)("head")));
return default;
}, 1, "", true), ((V)("ponder")), ((V)("clap"))));
Call(d_13, V.Undef, ((V)("pip")), Arr(((V)("flap")), Fn((V _self1, int _argc331, V t_337, V _a334, V _a335, V _a336, V[] _rest332) => {
Invoke(Invoke(t_337, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V), "osc", ((V)(1600D)), ((V)(4D)), NewObj(4).Put("tilt", ((V)(7D))).Put("x", ((V)(1.2))).Put("footL", ((V)(1.4))).Put("footR", ((V)(0D))).V, NewObj(4).Put("tilt", ((V)((-7D)))).Put("x", ((V)((-1.2)))).Put("footL", ((V)(0D))).Put("footR", ((V)(1.4))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("shake"))));
Call(d_13, V.Undef, ((V)("jelli")), Arr(Fn((V _self1, int _argc338, V t_344, V _a341, V _a342, V _a343, V[] _rest339) => {
{
V i_345 = default;
i_345 = ((V)(0D));
while (true) {
if (!(LtN(i_345, 3D))) break;
Invoke(Invoke(Invoke(t_344, "to", ((V)(240D)), NewObj(2).Put("sq", ((V)(0.1))).Put("lift", ((V)((-0.4)))).V, ((V)("i"))), "to", ((V)(420D)), NewObj(2).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2.4))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("s")));
PostInc(ref i_345, 1D);
}
}
return default;
}, 1, "", true), ((V)("hum")), Arr(((V)("wave")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("finn")), Arr(Fn((V _self1, int _argc347, V t_353, V _a350, V _a351, V _a352, V[] _rest348) => {
Invoke(Invoke(Invoke(t_353, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(900D)), ((V)(6D)), NewObj(1).Put("open", ((V)(0.5))).V, NewObj(1).Put("open", ((V)(0.1))).V, ((V)("l"))), "fx", ((V)("note")), ((V)("head")));
return default;
}, 1, "", true), Fn((V _self1, int _argc354, V t_360, V _a357, V _a358, V _a359, V[] _rest355) => {
Invoke(Invoke(t_360, "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(28D))).V, NewObj(1).Put("wag", ((V)((-28D)))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)("body")), ((V)(4D)));
return default;
}, 1, "", true), ((V)("clap"))));
Call(d_13, V.Undef, ((V)("sealy")), Arr(Fn((V _self1, int _argc361, V t_367, V _a364, V _a365, V _a366, V[] _rest362) => {
Invoke(Invoke(t_367, "to", ((V)(300D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(1D)), ((V)((-4D)))), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V)), "osc", ((V)(1200D)), ((V)(5D)), NewObj(3).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-1D)))).Put("open", ((V)(0.5))).V, NewObj(3).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-6D)))).Put("open", ((V)(0.1))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("wiggle")), Fn((V _self1, int _argc368, V t_374, V _a371, V _a372, V _a373, V[] _rest369) => {
return Call(sp_12, V.Undef, t_374, NewObj(4).Put("tilt", ((V)((-9D)))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("close", ((V)(0.5))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("puff")), Arr(Fn((V _self1, int _argc375, V t_381, V _a378, V _a379, V _a380, V[] _rest376) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_381, "to", ((V)(500D)), NewObj(3).Put("blo", ((V)(0.6))).Put("puff", ((V)(0.6))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(700D))), "fx", ((V)("bubble")), ((V)("head"))), "to", ((V)(800D)), NewObj(3).Put("blo", ((V)(0D))).Put("puff", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("bubble")), ((V)("head")));
return default;
}, 1, "", true), Fn((V _self1, int _argc382, V t_388, V _a385, V _a386, V _a387, V[] _rest383) => {
Invoke(Invoke(t_388, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(1D))).Put("mw", ((V)(0.4))).V), "to", ((V)(400D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.25))).Put("mw", ((V)(0.35))).V, ((V)("o")));
Invoke(Call(fxs_14, V.Undef, t_388, ((V)("bubble")), ((V)("mouth")), ((V)(2D)), ((V)(3D)), ((V)(280D))), "to", ((V)(200D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(0.8))).V);
return default;
}, 1, "", true), ((V)("hum"))));
Call(d_13, V.Undef, ((V)("shelly")), Arr(Fn((V _self1, int _argc389, V t_395, V _a392, V _a393, V _a394, V[] _rest390) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_395, "to", ((V)(600D)), NewObj(2).Put("nk", ((V)(1D))).Put("ly", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(2).Put("lx", ((V)((-1D)))).Put("turn", ((V)((-0.3)))).V), "wait", ((V)(500D))), "to", ((V)(600D)), NewObj(2).Put("lx", ((V)(1D))).Put("turn", ((V)(0.3))).V), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(4).Put("lx", ((V)(0D))).Put("turn", ((V)(0D))).Put("nk", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _self1, int _argc396, V t_402, V _a399, V _a400, V _a401, V[] _rest397) => {
Invoke(Invoke(Invoke(Invoke(t_402, "to", ((V)(400D)), NewObj(1).Put("hid", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(1300D))), "to", ((V)(260D)), NewObj(1).Put("hid", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "", true), ((V)("nod"))));
Call(d_13, V.Undef, ((V)("octo")), Arr(Fn((V _self1, int _argc403, V t_409, V _a406, V _a407, V _a408, V[] _rest404) => {
return Call(sp_12, V.Undef, t_409, NewObj(3).Put("ow", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), Fn((V _self1, int _argc410, V t_416, V _a413, V _a414, V _a415, V[] _rest411) => {
return Call(sp_12, V.Undef, t_416, NewObj(2).Put("ocl", ((V)(1D))).Put("close", ((V)(0.7))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "", true), Fn((V _self1, int _argc417, V t_423, V _a420, V _a421, V _a422, V[] _rest418) => {
Invoke(Invoke(Invoke(t_423, "to", ((V)(300D)), NewObj(2).Put("ojt", ((V)(0.8))).Put("sq", ((V)(0.08))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(4).Put("ojt", ((V)(0D))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).Put("osp", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(600D)), NewObj(3).Put("lift", ((V)(0D))).Put("osp", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("s")));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("marina")), Arr(Fn((V _self1, int _argc424, V t_430, V _a427, V _a428, V _a429, V[] _rest425) => {
Invoke(Invoke(Invoke(Invoke(t_430, "to", ((V)(400D)), NewObj(2).Put("tlf", ((V)(0.8))).Put("tsw", ((V)(0.6))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)((-0.6)))).V, NewObj(1).Put("tsw", ((V)(0.6))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("body")), ((V)(4D))), "to", ((V)(400D)), NewObj(2).Put("tlf", ((V)(0D))).Put("tsw", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _self1, int _argc431, V t_437, V _a434, V _a435, V _a436, V[] _rest432) => {
return Call(sp_12, V.Undef, t_437, NewObj(4).Put("htilt", ((V)((-10D)))).Put("lean", ((V)((-1.4)))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1000D)), ((V)(600D)));
}, 1, "", true), ((V)("hum"))), NewObj(1).Put("skip", Arr(((V)("idle_yawn")))).V);
Call(d_13, V.Undef, ((V)("pearl")), Arr(Fn((V _self1, int _argc438, V t_444, V _a441, V _a442, V _a443, V[] _rest439) => {
return Invoke(Call(sp_12, V.Undef, t_444, NewObj(4).Put("glow", ((V)(1D))).Put("wide", ((V)(0.3))).Put("hap", ((V)(0.6))).Put("hsw", ((V)(0.6))).V, ((V)(1200D)), ((V)(1000D))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D)));
}, 1, "", true), Fn((V _self1, int _argc445, V t_451, V _a448, V _a449, V _a450, V[] _rest446) => {
return Call(sp_12, V.Undef, t_451, NewObj(3).Put("fflap", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(900D)));
}, 1, "", true), ((V)("hum"))));
Call(d_13, V.Undef, ((V)("pina")), Arr(Fn((V _self1, int _argc452, V t_458, V _a455, V _a456, V _a457, V[] _rest453) => {
Invoke(Invoke(Invoke(t_458, "to", ((V)(220D)), NewObj(2).Put("crw", ((V)(1D))).Put("hap", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(1).Put("htilt", ((V)(6D))).V, NewObj(1).Put("htilt", ((V)((-6D)))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(1).Put("crw", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _self1, int _argc459, V t_465, V _a462, V _a463, V _a464, V[] _rest460) => {
Invoke(Invoke(t_465, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("close", ((V)(0.4))).V), "osc", ((V)(2000D)), ((V)(3D)), NewObj(4).Put("x", ((V)(1.4))).Put("tilt", ((V)(5D))).Put("armL", ((V)(50D))).Put("armR", ((V)(30D))).V, NewObj(4).Put("x", ((V)((-1.4)))).Put("tilt", ((V)((-5D)))).Put("armL", ((V)(30D))).Put("armR", ((V)(50D))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _self1, int _argc466, V t_472, V _a469, V _a470, V _a471, V[] _rest467) => {
return Call(sp_12, V.Undef, t_472, NewObj(2).Put("crs", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("avo")), Arr(Fn((V _self1, int _argc473, V t_479, V _a476, V _a477, V _a478, V[] _rest474) => {
Invoke(Invoke(Invoke(t_479, "to", ((V)(200D)), NewObj(3).Put("prw", ((V)(1D))).Put("pp", ((V)(0.35))).Put("wide", ((V)(0.4))).V, ((V)("o"))), "wait", ((V)(900D))), "to", ((V)(300D)), NewObj(3).Put("prw", ((V)(0D))).Put("pp", ((V)(0D))).Put("wide", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _self1, int _argc480, V t_486, V _a483, V _a484, V _a485, V[] _rest481) => {
return Call(sp_12, V.Undef, t_486, NewObj(3).Put("lfl", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1000D)), ((V)(800D)));
}, 1, "", true), ((V)("belly"))));
Call(d_13, V.Undef, ((V)("berri")), Arr(Fn((V _self1, int _argc487, V t_493, V _a490, V _a491, V _a492, V[] _rest488) => {
Invoke(Invoke(t_493, "to", ((V)(120D)), NewObj(2).Put("stw", ((V)(1D))).Put("hap", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(900D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("bk")));
return default;
}, 1, "", true), Fn((V _self1, int _argc494, V t_500, V _a497, V _a498, V _a499, V[] _rest495) => {
return Call(sp_12, V.Undef, t_500, NewObj(3).Put("lsp", ((V)(1D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(700D)));
}, 1, "", true), ((V)("curtsy"))));
Call(d_13, V.Undef, ((V)("lemmy")), Arr(Fn((V _self1, int _argc501, V t_507, V _a504, V _a505, V _a506, V[] _rest502) => {
Invoke(Invoke(Invoke(Invoke(t_507, "to", ((V)(200D)), NewObj(4).Put("sqz", ((V)(1D))).Put("mw", ((V)(0.4))).Put("open", ((V)(0.12))).Put("frown", ((V)(0.4))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(7D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(5).Put("sqz", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("frown", ((V)(0D))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(300D)));
return default;
}, 1, "", true), Fn((V _self1, int _argc508, V t_514, V _a511, V _a512, V _a513, V[] _rest509) => {
return Call(sp_12, V.Undef, t_514, NewObj(2).Put("lfl", ((V)(1D))).Put("hap", ((V)(0.5))).V, ((V)(900D)), ((V)(600D)));
}, 1, "", true), ((V)("wiggle"))));
Call(d_13, V.Undef, ((V)("kiwi")), Arr(Fn((V _self1, int _argc515, V t_521, V _a518, V _a519, V _a520, V[] _rest516) => {
Invoke(Invoke(Invoke(Invoke(t_521, "to", ((V)(220D)), NewObj(2).Put("fzz", ((V)(1D))).Put("sqz", ((V)(0.6))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.7))).V, NewObj(1).Put("x", ((V)((-0.7)))).V, ((V)("l"))), "fx", ((V)("kiwifuzz")), ((V)("body")), ((V)(3D))), "to", ((V)(400D)), NewObj(3).Put("fzz", ((V)(0D))).Put("sqz", ((V)(0D))).Put("hap", ((V)(0.6))).V);
return default;
}, 1, "", true), Fn((V _self1, int _argc522, V t_528, V _a525, V _a526, V _a527, V[] _rest523) => {
{
V i_529 = default;
i_529 = ((V)(0D));
while (true) {
if (!(LtN(i_529, 3D))) break;
Invoke(Invoke(Invoke(t_528, "to", ((V)(160D)), NewObj(3).Put("pitch", ((V)((-0.35)))).Put("lean", ((V)(1D))).Put("ly", ((V)(0.8))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(3).Put("pitch", ((V)(0D))).Put("lean", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(160D)));
PostInc(ref i_529, 1D);
}
}
return default;
}, 1, "", true), Fn((V _self1, int _argc531, V t_537, V _a534, V _a535, V _a536, V[] _rest532) => {
Invoke(t_537, "osc", ((V)(1400D)), ((V)(4D)), NewObj(3).Put("pitch", ((V)(0.1))).Put("footL", ((V)(2D))).Put("footR", ((V)(0D))).V, NewObj(3).Put("pitch", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).V, ((V)("s")));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("melo")), Arr(Fn((V _self1, int _argc538, V t_544, V _a541, V _a542, V _a543, V[] _rest539) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_544, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.7))).Put("open", ((V)(0D))).V), "to", ((V)(120D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).Put("pitch", ((V)((-0.1)))).V, ((V)("o"))), "fx", ((V)("meloseed")), ((V)("mouth"))), "to", ((V)(300D)), NewObj(4).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "wait", ((V)(400D)));
return default;
}, 1, "", true), Fn((V _self1, int _argc545, V t_551, V _a548, V _a549, V _a550, V[] _rest546) => {
Invoke(t_551, "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("sdj", ((V)(1D))).V, NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(2D)))));
Call(d_13, V.Undef, ((V)("peachy")), Arr(Fn((V _self1, int _argc552, V t_558, V _a555, V _a556, V _a557, V[] _rest553) => {
Invoke(Invoke(t_558, "to", ((V)(400D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(9D)), ((V)((-12D)))), NewObj(5).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("blush", ((V)(1D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V)), "osc", ((V)(1600D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(3D))).Put("htilt", ((V)(6D))).V, NewObj(2).Put("tilt", ((V)((-3D)))).Put("htilt", ((V)((-6D)))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _self1, int _argc559, V t_565, V _a562, V _a563, V _a564, V[] _rest560) => {
return Call(sp_12, V.Undef, t_565, NewObj(2).Put("lsp", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "", true), ((V)("curtsy"))));
Call(d_13, V.Undef, ((V)("pitaya")), Arr(Fn((V _self1, int _argc566, V t_572, V _a569, V _a570, V _a571, V[] _rest567) => {
return Invoke(Call(sp_12, V.Undef, t_572, NewObj(4).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.7))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(1000D))), "fx", ((V)("spark")), ((V)("body")), ((V)(4D)));
}, 1, "", true), Fn((V _self1, int _argc573, V t_579, V _a576, V _a577, V _a578, V[] _rest574) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_579, "to", ((V)(300D)), NewObj(2).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.1)))).V), "to", ((V)(220D)), NewObj(9).Put("brf", ((V)(1D))).Put("crw", ((V)(1D))).Put("open", ((V)(0.7))).Put("wide", ((V)(0.6))).Put("pitch", ((V)(0.15))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("hRx", ((V)(3D))).Put("hLx", ((V)((-3D)))).V, ((V)("o"))), "fx", ((V)("pitseed")), ((V)("mouth")), ((V)(3D))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(11).Put("brf", ((V)(0D))).Put("crw", ((V)(0D))).Put("open", ((V)(0D))).Put("wide", ((V)(0D))).Put("pitch", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLx", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("stomp"))));
Call(d_13, V.Undef, ((V)("tutti")), Arr(Fn((V _self1, int _argc580, V t_586, V _a583, V _a584, V _a585, V[] _rest581) => {
Invoke(Invoke(Invoke(Invoke(t_586, "to", ((V)(300D)), NewObj(3).Put("fL", ((V)(1D))).Put("ly", ((V)((-0.8)))).Put("hap", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("fL", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(2).Put("fR", ((V)(1D))).Put("ly", ((V)((-0.8)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("fR", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("i")));
return default;
}, 1, "", true), Fn((V _self1, int _argc587, V t_593, V _a590, V _a591, V _a592, V[] _rest588) => {
return Invoke(Call(sp_12, V.Undef, t_593, NewObj(3).Put("wfl", ((V)(1D))).Put("hap", ((V)(0.6))).Put("lift", ((V)(2D))).V, ((V)(1200D)), ((V)(900D))), "fx", ((V)("fairydust")), ((V)("body")), ((V)(4D)));
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("kiko")), Arr(Fn((V _self1, int _argc594, V t_600, V _a597, V _a598, V _a599, V[] _rest595) => {
Invoke(Invoke(Invoke(Invoke(t_600, "to", ((V)(300D)), NewObj(2).Put("htilt", ((V)((-10D)))).Put("lean", ((V)((-1.4)))).V), "to", ((V)(360D)), NewObj(4).Put("htilt", ((V)(9D))).Put("lean", ((V)(1.4))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(500D)));
return default;
}, 1, "", true), ((V)("sniff")), Arr(((V)("scratch")), ((V)((-1D))))));
Call(d_13, V.Undef, ((V)("teddy")), Arr(Fn((V _self1, int _argc601, V t_607, V _a604, V _a605, V _a606, V[] _rest602) => {
Invoke(Invoke(Invoke(t_607, "to", ((V)(450D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(14D)), ((V)((-6D)))), NewObj(6).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).Put("blush", ((V)(0.6))).V)), "fx", ((V)("heart")), ((V)("head"))), "osc", ((V)(2000D)), ((V)(2D)), NewObj(2).Put("lean", ((V)(1.2))).Put("tilt", ((V)(2D))).V, NewObj(2).Put("lean", ((V)((-1.2)))).Put("tilt", ((V)((-2D)))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _self1, int _argc608, V t_614, V _a611, V _a612, V _a613, V[] _rest609) => {
Invoke(Invoke(t_614, "to", ((V)(300D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(6D)), ((V)(4D))), NewObj(5).Put("armL", ((V)(14D))).Put("armR", ((V)(14D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V), ((V)("io"))), "osc", ((V)(1000D)), ((V)(6D)), NewObj(2).Put("hLy", ((V)(8D))).Put("hRy", ((V)(2D))).V, NewObj(2).Put("hLy", ((V)(2D))).Put("hRy", ((V)(8D))).V, ((V)("o")));
return default;
}, 1, "", true), Fn((V _self1, int _argc615, V t_621, V _a618, V _a619, V _a620, V[] _rest616) => {
Invoke(Invoke(Invoke(Invoke(t_621, "to", ((V)(380D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-14D)))), NewObj(3).Put("armR", ((V)(32D))).Put("close", ((V)(0.7))).Put("tongue", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("tongue", ((V)(0.9))).Put("hRy", ((V)((-16D)))).V, NewObj(2).Put("tongue", ((V)(0.3))).Put("hRy", ((V)((-13D)))).V, ((V)("l"))), "fx", ((V)("honey")), ((V)("pawR")), ((V)(2D))), "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("hoot")), Arr(Fn((V _self1, int _argc622, V t_628, V _a625, V _a626, V _a627, V[] _rest623) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_628, "to", ((V)(600D)), NewObj(3).Put("turn", ((V)(0.85))).Put("lx", ((V)(1D))).Put("tfl", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(800D)), NewObj(2).Put("turn", ((V)((-0.85)))).Put("lx", ((V)((-1D)))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(3).Put("turn", ((V)(0D))).Put("lx", ((V)(0D))).Put("tfl", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _self1, int _argc629, V t_635, V _a632, V _a633, V _a634, V[] _rest630) => {
Invoke(Invoke(Invoke(Invoke(t_635, "to", ((V)(200D)), NewObj(2).Put("wfl", ((V)(1D))).Put("fzz", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(2).Put("x", ((V)(0.7))).Put("sq", ((V)(0.03))).V, NewObj(2).Put("x", ((V)((-0.7)))).Put("sq", ((V)(0D))).V, ((V)("l"))), "fx", ((V)("feather")), ((V)("body")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("wfl", ((V)(0D))).Put("fzz", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("nod"))), NewObj(1).Put("skip", Arr(((V)("idle_waveR")))).V);
Call(d_13, V.Undef, ((V)("leo")), Arr(Fn((V _self1, int _argc636, V t_642, V _a639, V _a640, V _a641, V[] _rest637) => {
Invoke(Invoke(Invoke(Invoke(t_642, "to", ((V)(200D)), NewObj(2).Put("msh", ((V)(1D))).Put("mfl", ((V)(0.6))).V), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("htilt", ((V)(7D))).V, NewObj(1).Put("htilt", ((V)((-7D)))).V, ((V)("l"))), "fx", ((V)("manefur")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("msh", ((V)(0D))).Put("mfl", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _self1, int _argc643, V t_649, V _a646, V _a647, V _a648, V[] _rest644) => {
return Call(sp_12, V.Undef, t_649, NewObj(6).Put("open", ((V)(0.7))).Put("wide", ((V)(0.4))).Put("mfl", ((V)(1D))).Put("pitch", ((V)(0.15))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)(800D)), ((V)(500D)));
}, 1, "", true), Fn((V _self1, int _argc650, V t_656, V _a653, V _a654, V _a655, V[] _rest651) => {
Invoke(t_656, "osc", ((V)(1800D)), ((V)(3D)), NewObj(1).Put("tsw", ((V)(1D))).V, NewObj(1).Put("tsw", ((V)((-1D)))).V, ((V)("s")));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("panko")), Arr(Fn((V _self1, int _argc657, V t_663, V _a660, V _a661, V _a662, V[] _rest658) => {
Invoke(Invoke(Invoke(t_663, "to", ((V)(400D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(11D)), ((V)((-14D)))), NewObj(1).Put("armR", ((V)(34D))).V)), "osc", ((V)(2000D)), ((V)(7D)), NewObj(2).Put("open", ((V)(0.3))).Put("puff", ((V)(0.6))).V, NewObj(2).Put("open", ((V)(0.05))).Put("puff", ((V)(0.3))).V, ((V)("s"))), "fx", ((V)("bamboo")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "", true), Fn((V _self1, int _argc664, V t_670, V _a667, V _a668, V _a669, V[] _rest665) => {
Invoke(Invoke(t_670, "osc", ((V)(2400D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(9D))).Put("x", ((V)(1.4))).V, NewObj(2).Put("tilt", ((V)((-9D)))).Put("x", ((V)((-1.4)))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), ((V)("belly"))));
Call(d_13, V.Undef, ((V)("acorn")), Arr(Fn((V _self1, int _argc671, V t_677, V _a674, V _a675, V _a676, V[] _rest672) => {
Invoke(t_677, "osc", ((V)(1000D)), ((V)(4D)), NewObj(2).Put("tfl", ((V)(1D))).Put("tsw", ((V)(0.8))).V, NewObj(2).Put("tfl", ((V)(0.2))).Put("tsw", ((V)((-0.8)))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _self1, int _argc678, V t_684, V _a681, V _a682, V _a683, V[] _rest679) => {
Invoke(Invoke(Invoke(t_684, "to", ((V)(300D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(9D)), ((V)((-11D)))), NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V)), "osc", ((V)(1400D)), ((V)(7D)), NewObj(1).Put("open", ((V)(0.25))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("l"))), "fx", ((V)("nutbit")), ((V)("mouth")), ((V)(3D)));
return default;
}, 1, "", true), Fn((V _self1, int _argc685, V t_691, V _a688, V _a689, V _a690, V[] _rest686) => {
return Call(sp_12, V.Undef, t_691, NewObj(4).Put("ctp", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).Put("htilt", ((V)(6D))).V, ((V)(1000D)), ((V)(700D)));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("fawn")), Arr(((V)("ears")), Fn((V _self1, int _argc692, V t_698, V _a695, V _a696, V _a697, V[] _rest693) => {
Invoke(Invoke(t_698, "osc", ((V)(1400D)), ((V)(4D)), NewObj(4).Put("footL", ((V)(2.6))).Put("footR", ((V)(0D))).Put("lift", ((V)(0.8))).Put("pitch", ((V)((-0.04)))).V, NewObj(4).Put("footL", ((V)(0D))).Put("footR", ((V)(2.6))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("s"))), "fx", ((V)("fawnleaf")), ((V)("body")), ((V)(2D)));
return default;
}, 1, "", true), ((V)("sniff"))));
Call(d_13, V.Undef, ((V)("moss")), Arr(Fn((V _self1, int _argc699, V t_705, V _a702, V _a703, V _a704, V[] _rest700) => {
Invoke(Invoke(t_705, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("cb", ((V)(1D))).V, NewObj(1).Put("cb", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("spore")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "", true), Fn((V _self1, int _argc706, V t_712, V _a709, V _a710, V _a711, V[] _rest707) => {
return Call(sp_12, V.Undef, t_712, NewObj(3).Put("csp", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(700D)));
}, 1, "", true), ((V)("wiggle"))));
Call(d_13, V.Undef, ((V)("sprout")), Arr(Fn((V _self1, int _argc713, V t_719, V _a716, V _a717, V _a718, V[] _rest714) => {
return Invoke(Call(sp_12, V.Undef, t_719, NewObj(3).Put("blm", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D))), "fx", ((V)("petal")), ((V)("head")), ((V)(3D)));
}, 1, "", true), Fn((V _self1, int _argc720, V t_726, V _a723, V _a724, V _a725, V[] _rest721) => {
Invoke(t_726, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("stw", ((V)(1D))).V, NewObj(1).Put("stw", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true), Fn((V _self1, int _argc727, V t_733, V _a730, V _a731, V _a732, V[] _rest728) => {
return Call(sp_12, V.Undef, t_733, NewObj(2).Put("lfl", ((V)(1D))).Put("hap", ((V)(0.5))).V, ((V)(1000D)), ((V)(700D)));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("hana")), Arr(Fn((V _self1, int _argc734, V t_740, V _a737, V _a738, V _a739, V[] _rest735) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_740, "to", ((V)(300D)), NewObj(1).Put("flL", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(300D)), NewObj(2).Put("flL", ((V)(0D))).Put("flR", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(300D)), NewObj(1).Put("flR", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _self1, int _argc741, V t_747, V _a744, V _a745, V _a746, V[] _rest742) => {
Invoke(t_747, "osc", ((V)(1000D)), ((V)(4D)), NewObj(1).Put("tw", ((V)(1D))).V, NewObj(1).Put("tw", ((V)((-1D)))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _self1, int _argc748, V t_754, V _a751, V _a752, V _a753, V[] _rest749) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_754, "to", ((V)(130D)), NewObj(2).Put("footR", ((V)(3.2))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "to", ((V)(110D)), NewObj(2).Put("footR", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)("footR")), ((V)(3D))), "wait", ((V)(250D))), "to", ((V)(130D)), NewObj(1).Put("footR", ((V)(3.2))).V, ((V)("o"))), "to", ((V)(110D)), NewObj(2).Put("footR", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)("footR")), ((V)(3D))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V);
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("boo")), Arr(Fn((V _self1, int _argc755, V t_761, V _a758, V _a759, V _a760, V[] _rest756) => {
Invoke(Invoke(Invoke(Invoke(t_761, "to", ((V)(400D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(10D)), ((V)((-14D)))), NewObj(4).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("blush", ((V)(0.9))).Put("gho", ((V)(0.45))).V)), "wait", ((V)(900D))), "to", ((V)(400D)), NewObj(1).Put("gho", ((V)(0D))).V), "wait", ((V)(200D)));
return default;
}, 1, "", true), Fn((V _self1, int _argc762, V t_768, V _a765, V _a766, V _a767, V[] _rest763) => {
return Call(sp_12, V.Undef, t_768, NewObj(2).Put("flr", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(600D)));
}, 1, "", true), Fn((V _self1, int _argc769, V t_775, V _a772, V _a773, V _a774, V[] _rest770) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_775, "to", ((V)(300D)), NewObj(1).Put("gho", ((V)(0.7))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(140D)), NewObj(7).Put("gho", ((V)(0D))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.7))).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(5).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.6))).V);
return default;
}, 1, "", true)), NewObj(1).Put("skip", Arr(((V)("idle_yawn")))).V);
Call(d_13, V.Undef, ((V)("pixie")), Arr(Fn((V _self1, int _argc776, V t_782, V _a779, V _a780, V _a781, V[] _rest777) => {
return Invoke(Call(sp_12, V.Undef, t_782, NewObj(4).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.6))).Put("hap", ((V)(0.8))).Put("lift", ((V)(2D))).V, ((V)(1000D)), ((V)(800D))), "fx", ((V)("pixdust")), ((V)("body")), ((V)(4D)));
}, 1, "", true), ((V)("giggle")), Arr(((V)("twirl")), ((V)((-1D))))));
Call(d_13, V.Undef, ((V)("floof")), Arr(Fn((V _self1, int _argc783, V t_789, V _a786, V _a787, V _a788, V[] _rest784) => {
Invoke(Invoke(Invoke(Invoke(t_789, "to", ((V)(200D)), NewObj(2).Put("fzz", ((V)(1D))).Put("sqz", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(9D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("l"))), "fx", ((V)("snow")), ((V)("body")), ((V)(4D))), "to", ((V)(400D)), NewObj(3).Put("fzz", ((V)(0D))).Put("sqz", ((V)(0D))).Put("hap", ((V)(0.7))).V);
return default;
}, 1, "", true), ((V)("stomp")), Fn((V _self1, int _argc790, V t_796, V _a793, V _a794, V _a795, V[] _rest791) => {
return Call(sp_12, V.Undef, t_796, NewObj(6).Put("open", ((V)(0.8))).Put("wide", ((V)(0.4))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("pitch", ((V)(0.2))).Put("fzz", ((V)(0.6))).V, ((V)(900D)), ((V)(500D)));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("unibun")), Arr(Fn((V _self1, int _argc797, V t_803, V _a800, V _a801, V _a802, V[] _rest798) => {
Invoke(Invoke(Invoke(Invoke(t_803, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.12)))).Put("close", ((V)(0.5))).V), "fx", ((V)("rainbow")), ((V)("head")), ((V)(5D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), ((V)("ears")), Fn((V _self1, int _argc804, V t_810, V _a807, V _a808, V _a809, V[] _rest805) => {
Invoke(Invoke(t_810, "osc", ((V)(1400D)), ((V)(4D)), NewObj(4).Put("footL", ((V)(2.8))).Put("footR", ((V)(0D))).Put("lift", ((V)(1D))).Put("pitch", ((V)((-0.05)))).V, NewObj(4).Put("footL", ((V)(0D))).Put("footR", ((V)(2.8))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("gumdrop")), Arr(Fn((V _self1, int _argc811, V t_817, V _a814, V _a815, V _a816, V[] _rest812) => {
return Call(sp_12, V.Undef, t_817, NewObj(3).Put("jig", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(1000D)), ((V)(900D)));
}, 1, "", true), ((V)("bounce")), ((V)("wiggle"))));
Call(d_13, V.Undef, ((V)("ember")), Arr(Fn((V _self1, int _argc818, V t_824, V _a821, V _a822, V _a823, V[] _rest819) => {
return Invoke(Call(sp_12, V.Undef, t_824, NewObj(3).Put("cfl", ((V)(1D))).Put("hap", ((V)(0.6))).Put("wide", ((V)(0.3))).V, ((V)(1000D)), ((V)(900D))), "fx", ((V)("ember")), ((V)("head")), ((V)(4D)));
}, 1, "", true), Fn((V _self1, int _argc825, V t_831, V _a828, V _a829, V _a830, V[] _rest826) => {
Invoke(Invoke(t_831, "to", ((V)(160D)), NewObj(1).Put("hap", ((V)(0.8))).V), "osc", ((V)(1000D)), ((V)(6D)), NewObj(3).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("wfl", ((V)(1D))).V, NewObj(3).Put("armL", ((V)(4D))).Put("armR", ((V)(4D))).Put("wfl", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("shake"))));
Call(d_13, V.Undef, ((V)("drako")), Arr(Fn((V _self1, int _argc832, V t_838, V _a835, V _a836, V _a837, V[] _rest833) => {
Invoke(t_838, "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("tsw", ((V)(1D))).V, NewObj(1).Put("tsw", ((V)((-1D)))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _self1, int _argc839, V t_845, V _a842, V _a843, V _a844, V[] _rest840) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_845, "to", ((V)(300D)), NewObj(1).Put("puff", ((V)(0.8))).V), "to", ((V)(150D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "fx", ((V)("dsmoke")), ((V)("nose")), ((V)(3D))), "to", ((V)(300D)), NewObj(3).Put("open", ((V)(0D))).Put("blush", ((V)(0.6))).Put("smile", ((V)(1D))).V), "wait", ((V)(500D)));
return default;
}, 1, "", true), Fn((V _self1, int _argc846, V t_852, V _a849, V _a850, V _a851, V[] _rest847) => {
return Call(sp_12, V.Undef, t_852, NewObj(5).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.8))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("hap", ((V)(0.6))).V, ((V)(1000D)), ((V)(700D)));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("jinni")), Arr(Fn((V _self1, int _argc853, V t_859, V _a856, V _a857, V _a858, V[] _rest854) => {
return Invoke(Call(sp_12, V.Undef, t_859, NewObj(4).Put("glo", ((V)(1D))).Put("gwh", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(1200D))), "fx", ((V)("jinni")), ((V)("body")), ((V)(4D)));
}, 1, "", true), Fn((V _self1, int _argc860, V t_866, V _a863, V _a864, V _a865, V[] _rest861) => {
Invoke(Invoke(t_866, "to", ((V)(400D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(12D)), ((V)((-8D)))), NewObj(3).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("close", ((V)(0.6))).V)), "wait", ((V)(1000D)));
return default;
}, 1, "", true), Fn((V _self1, int _argc867, V t_873, V _a870, V _a871, V _a872, V[] _rest868) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_873, "to", ((V)(700D)), NewObj(1).Put("gin", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(1).Put("gin", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("jinni")), ((V)("body")), ((V)(5D))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true)), NewObj(1).Put("skip", Arr(((V)("idle_yawn")))).V);
Call(d_13, V.Undef, ((V)("cuppy")), Arr(Fn((V _self1, int _argc874, V t_880, V _a877, V _a878, V _a879, V[] _rest875) => {
Invoke(Invoke(Invoke(t_880, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "fx", ((V)("sprinkle")), ((V)("head"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("htilt", ((V)(6D))).V, NewObj(1).Put("htilt", ((V)((-6D)))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("wiggle")), Arr(((V)("hops")), ((V)(2D)))));
Call(d_13, V.Undef, ((V)("chip")), Arr(Fn((V _self1, int _argc881, V t_887, V _a884, V _a885, V _a886, V[] _rest882) => {
Invoke(Invoke(t_887, "osc", ((V)(800D)), ((V)(5D)), NewObj(1).Put("x", ((V)(0.7))).V, NewObj(1).Put("x", ((V)((-0.7)))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("body")), ((V)(4D)));
return default;
}, 1, "", true), ((V)("belly")), ((V)("rock"))));
Call(d_13, V.Undef, ((V)("twisty")), Arr(Fn((V _self1, int _argc888, V t_894, V _a891, V _a892, V _a893, V[] _rest889) => {
Invoke(Invoke(Invoke(t_894, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V), "osc", ((V)(1600D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("lean", ((V)(1.4))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("lean", ((V)((-1.4)))).V, ((V)("s"))), "fx", ((V)("salt")), ((V)("head")));
return default;
}, 1, "", true), ((V)("giggle")), ((V)("clap"))));
Call(d_13, V.Undef, ((V)("crois")), Arr(Fn((V _self1, int _argc895, V t_901, V _a898, V _a899, V _a900, V[] _rest896) => {
Invoke(t_901, "osc", ((V)(2600D)), ((V)(2D)), NewObj(3).Put("lean", ((V)(1.6))).Put("tilt", ((V)(3D))).Put("close", ((V)(0.5))).V, NewObj(3).Put("lean", ((V)((-1.6)))).Put("tilt", ((V)((-3D)))).Put("close", ((V)(0.2))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("stretch")), ((V)("hum"))));
Call(d_13, V.Undef, ((V)("maca")), Arr(Fn((V _self1, int _argc902, V t_908, V _a905, V _a906, V _a907, V[] _rest903) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_908, "to", ((V)(100D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(2).Put("sq", ((V)((-0.06)))).Put("hap", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V), "wait", ((V)(200D))), "to", ((V)(100D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("wiggle")), ((V)("giggle"))));
Call(d_13, V.Undef, ((V)("puddi")), Arr(Fn((V _self1, int _argc909, V t_915, V _a912, V _a913, V _a914, V[] _rest910) => {
Invoke(Invoke(t_915, "osc", ((V)(1200D)), ((V)(8D)), NewObj(2).Put("sq", ((V)(0.06))).Put("x", ((V)(0.4))).V, NewObj(2).Put("sq", ((V)((-0.03)))).Put("x", ((V)((-0.4)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), ((V)("hum")), ((V)("bounce"))));
Call(d_13, V.Undef, ((V)("mochi")), Arr(Fn((V _self1, int _argc916, V t_922, V _a919, V _a920, V _a921, V[] _rest917) => {
Invoke(Invoke(Invoke(t_922, "to", ((V)(700D)), NewObj(6).Put("sq", ((V)((-0.16)))).Put("lift", ((V)(1.6))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("close", ((V)(0.8))).Put("open", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(6).Put("sq", ((V)(0.18))).Put("lift", ((V)((-0.6)))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("giggle"))));
Call(d_13, V.Undef, ((V)("cakey")), Arr(Fn((V _self1, int _argc923, V t_929, V _a926, V _a927, V _a928, V[] _rest924) => {
Invoke(Invoke(Invoke(Invoke(t_929, "to", ((V)(400D)), NewObj(2).Put("puff", ((V)(0.9))).Put("pitch", ((V)((-0.1)))).V), "to", ((V)(500D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0.25))).Put("mw", ((V)(0.5))).Put("pitch", ((V)(0.1))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "wait", ((V)(400D)));
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("hum"))));
Call(d_13, V.Undef, ((V)("sugarplum")), Arr(Fn((V _self1, int _argc930, V t_936, V _a933, V _a934, V _a935, V[] _rest931) => {
Invoke(Invoke(Invoke(t_936, "to", ((V)(400D)), NewObj(5).Put("armR", ((V)(110D))).Put("hRy", ((V)((-2D)))).Put("smile", ((V)(1D))).Put("close", ((V)(0.4))).Put("htilt", ((V)(5D))).V, ((V)("o"))), "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-3D)))).V, NewObj(1).Put("hRx", ((V)(3D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D)));
return default;
}, 1, "", true), ((V)("curtsy")), Arr(((V)("twirl")), ((V)((-1D))))));
Call(d_13, V.Undef, ((V)("gourdy")), Arr(Fn((V _self1, int _argc937, V t_943, V _a940, V _a941, V _a942, V[] _rest938) => {
Invoke(t_943, "osc", ((V)(2400D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(7D))).Put("x", ((V)(1.6))).V, NewObj(2).Put("tilt", ((V)((-7D)))).Put("x", ((V)((-1.6)))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("hum")), ((V)("bounce"))));
Call(d_13, V.Undef, ((V)("batty")), Arr(Fn((V _self1, int _argc944, V t_950, V _a947, V _a948, V _a949, V[] _rest945) => {
Invoke(Invoke(t_950, "to", ((V)(400D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(14D)), ((V)((-2D)))), NewObj(4).Put("armL", ((V)(36D))).Put("armR", ((V)(36D))).Put("close", ((V)(0.5))).Put("smile", ((V)(0.8))).V)), "wait", ((V)(1400D)));
return default;
}, 1, "", true), ((V)("flap")), ((V)("ears"))));
Call(d_13, V.Undef, ((V)("kernel")), Arr(Fn((V _self1, int _argc951, V t_957, V _a954, V _a955, V _a956, V[] _rest952) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_957, "to", ((V)(300D)), NewObj(2).Put("sq", ((V)(0.12))).Put("wide", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(6).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(9D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("o"))), "fx", ((V)("crumb")), ((V)("head")), ((V)(4D))), "to", ((V)(260D)), NewObj(6).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.6))).V);
return default;
}, 1, "", true), Fn((V _self1, int _argc958, V t_964, V _a961, V _a962, V _a963, V[] _rest959) => {
Invoke(t_964, "osc", ((V)(1400D)), ((V)(4D)), NewObj(3).Put("x", ((V)(1D))).Put("footL", ((V)(2D))).Put("footR", ((V)(0D))).V, NewObj(3).Put("x", ((V)((-1D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("giggle"))));
Call(d_13, V.Undef, ((V)("hexie")), Arr(Fn((V _self1, int _argc965, V t_971, V _a968, V _a969, V _a970, V[] _rest966) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_971, "to", ((V)(300D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-18D)))), NewObj(2).Put("armR", ((V)(120D))).Put("htilt", ((V)(8D))).V), ((V)("o"))), "wait", ((V)(300D))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D))), "to", ((V)(300D)), NewObj(2).Put("winkR", ((V)(1D))).Put("smile", ((V)(1D))).V), "wait", ((V)(400D)));
return default;
}, 1, "", true), Arr(((V)("scratch")), ((V)(1D))), Arr(((V)("twirl")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("mumbles")), Arr(Fn((V _self1, int _argc972, V t_978, V _a975, V _a976, V _a977, V[] _rest973) => {
Invoke(Invoke(t_978, "to", ((V)(600D)), NewObj(6).Put("armL", ((V)(88D))).Put("armR", ((V)(88D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("close", ((V)(0.6))).Put("open", ((V)(0.25))).V, ((V)("io"))), "osc", ((V)(1400D)), ((V)(2D)), NewObj(1).Put("lean", ((V)(1.2))).V, NewObj(1).Put("lean", ((V)((-1.2)))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("stretch")), ((V)("giggle"))));
Call(d_13, V.Undef, ((V)("hocus")), Arr(Fn((V _self1, int _argc979, V t_985, V _a982, V _a983, V _a984, V[] _rest980) => {
Invoke(Invoke(Invoke(Invoke(t_985, "to", ((V)(400D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-4D)))), NewObj(3).Put("armR", ((V)(50D))).Put("ly", ((V)(0.6))).Put("close", ((V)(0.3))).V)), "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(800D))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "", true), ((V)("bow")), Arr(((V)("twirl")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("countsquishula")), Arr(Fn((V _self1, int _argc986, V t_992, V _a989, V _a990, V _a991, V[] _rest987) => {
Invoke(Invoke(Invoke(Invoke(t_992, "to", ((V)(300D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)((-1D))), ((V)((-6D))), ((V)((-10D)))), NewObj(3).Put("armL", ((V)(90D))).Put("lean", ((V)((-1.2)))).Put("htilt", ((V)((-5D)))).V), ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(3).Put("smile", ((V)(1D))).Put("open", ((V)(0.2))).Put("winkL", ((V)(1D))).V), "wait", ((V)(500D)));
return default;
}, 1, "", true), ((V)("bow")), Fn((V _self1, int _argc993, V t_999, V _a996, V _a997, V _a998, V[] _rest994) => {
Invoke(Invoke(t_999, "to", ((V)(300D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(6D)), ((V)((-6D)))), NewObj(6).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("pitch", ((V)(0.12))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(6D)), NewObj(2).Put("sq", ((V)(0.03))).Put("open", ((V)(0.6))).V, NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0.3))).V, ((V)("o")));
return default;
}, 1, "", true)));
return default;
}, 1, "", false));
        }
    }
}
