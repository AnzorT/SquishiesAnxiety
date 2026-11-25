// house-idle-c.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house_idle_c_js
    {

        public static void Run()
        {
Invoke(Set(G("window"), "HouseIdleC", (Get(G("window"), "HouseIdleC") is var _t1138 && Truthy(_t1138) ? _t1138 : Arr())), "push", Fn((V _self1, int _argc2, V W_8, V _a5, V _a6, V _a7, V[] _rest3) => {
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
d_13 = Fn((V _arrowThis28, int _argc19, V k_25, V L_26, V X_27, V _a24, V[] _rest20) => {
return Invoke(W_8, "build", k_25, L_26, X_27);
}, 3, "", true);
fxs_14 = Fn((V _arrowThis41, int _argc29, V t_35, V n_36, V w_37, V c_38, V[] _rest30) => {
V k_39 = default;
V gap_40 = default;
k_39 = (_argc29 > 4 ? _rest30[0] : V.Undef);
gap_40 = (_argc29 > 5 ? _rest30[1] : V.Undef);
{
double i_42 = 0;
i_42 = 0D;
while (true) {
if (!(Lt(((V)(i_42)), k_39))) break;
Invoke(Invoke(t_35, "fx", n_36, w_37, c_38), "wait", gap_40);
i_42++;
}
}
return t_35;
return default;
}, 6, "", true);
Call(d_13, V.Undef, ((V)("mittens")), Arr(((V)("groom")), Arr(((V)("scratch")), ((V)(1D))), Fn((V _arrowThis51, int _argc44, V t_50, V _a47, V _a48, V _a49, V[] _rest45) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_50, "to", ((V)(600D)), NewObj(9).Put("pitch", ((V)((-0.3)))).Put("lean", ((V)(1.2))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("sq", ((V)(0.08))).Put("lift", ((V)((-1D)))).Put("wag", ((V)(18D))).Put("curl", ((V)(0.4))).Put("close", ((V)(0.8))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("hLy", ((V)(2D))).Put("hRy", ((V)((-1D)))).V, NewObj(2).Put("hLy", ((V)((-1D)))).Put("hRy", ((V)(2D))).V, ((V)("s"))), "wait", ((V)(300D))), "to", ((V)(500D)), NewObj(8).Put("pitch", ((V)(0.2))).Put("lean", ((V)((-0.6)))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(0.6))).Put("wag", ((V)((-12D)))).Put("open", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(300D)));
return default;
}, 1, "", true), ((V)("wag"))));
Call(d_13, V.Undef, ((V)("biscuit")), Arr(Fn((V _arrowThis59, int _argc52, V t_58, V _a55, V _a56, V _a57, V[] _rest53) => {
Invoke(Invoke(t_58, "to", ((V)(200D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("tongue", ((V)(0.5))).V), "osc", ((V)(1600D)), ((V)(8D)), NewObj(3).Put("wag", ((V)(30D))).Put("lift", ((V)(0.8))).Put("tilt", ((V)(1.5))).V, NewObj(3).Put("wag", ((V)((-30D)))).Put("lift", ((V)(0D))).Put("tilt", ((V)((-1.5)))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("sniff")), ((V)("shake")), Fn((V _arrowThis67, int _argc60, V t_66, V _a63, V _a64, V _a65, V[] _rest61) => {
Invoke(t_66, "to", ((V)(160D)), NewObj(5).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("tongue", ((V)(0.5))).Put("wag", ((V)(30D))).V);
{
double i_68 = 0;
i_68 = 0D;
while (true) {
if (!((i_68 < 2D))) break;
Invoke(Invoke(t_66, "to", ((V)(700D)), NewObj(3).Put("spin", ((V)(360D))).Put("lift", ((V)(1.6))).Put("wag", ((V)((-30D)))).V, ((V)("l"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
i_68++;
}
}
Invoke(Invoke(t_66, "to", ((V)(400D)), NewObj(4).Put("lift", ((V)(0D))).Put("sqz", ((V)(0.6))).Put("htilt", ((V)(8D))).Put("wag", ((V)(0D))).V, ((V)("o"))), "osc", ((V)(600D)), ((V)(2D)), NewObj(1).Put("tilt", ((V)(3D))).V, NewObj(1).Put("tilt", ((V)((-3D)))).V, ((V)("s")));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("prickle")), Arr(Fn((V _arrowThis77, int _argc70, V t_76, V _a73, V _a74, V _a75, V[] _rest71) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_76, "to", ((V)(380D)), NewObj(5).Put("curl", ((V)(1D))).Put("sq", ((V)(0.14))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V, ((V)("io"))), "wait", ((V)(1100D))), "to", ((V)(180D)), NewObj(3).Put("curl", ((V)(0D))).Put("sq", ((V)((-0.05)))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D)));
return default;
}, 1, "", true), ((V)("sniff")), Arr(((V)("scratch")), ((V)((-1D))))));
Call(d_13, V.Undef, ((V)("nibbles")), Arr(Fn((V _arrowThis85, int _argc78, V t_84, V _a81, V _a82, V _a83, V[] _rest79) => {
Invoke(Invoke(Invoke(Invoke(t_84, "to", ((V)(300D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(9D)), ((V)((-9D)))), NewObj(3).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("puff", ((V)(1D))).V)), "osc", ((V)(1800D)), ((V)(8D)), NewObj(2).Put("open", ((V)(0.25))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("open", ((V)(0D))).Put("htilt", ((V)((-3D)))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(3).Put("puff", ((V)(0.4))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), Fn((V _arrowThis93, int _argc86, V t_92, V _a89, V _a90, V _a91, V[] _rest87) => {
Invoke(Invoke(t_92, "to", ((V)(380D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(6D)), ((V)((-22D)))), NewObj(3).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("close", ((V)(0.9))).V), ((V)("io"))), "osc", ((V)(1300D)), ((V)(5D)), NewObj(2).Put("hLy", ((V)((-26D)))).Put("hRy", ((V)((-18D)))).V, NewObj(2).Put("hLy", ((V)((-18D)))).Put("hRy", ((V)((-26D)))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _arrowThis101, int _argc94, V t_100, V _a97, V _a98, V _a99, V[] _rest95) => {
Invoke(Invoke(Invoke(Invoke(t_100, "to", ((V)(400D)), NewObj(6).Put("lift", ((V)(2D))).Put("sq", ((V)((-0.08)))).Put("ly", ((V)((-0.8)))).Put("lx", ((V)(0.6))).Put("armL", ((V)(16D))).Put("armR", ((V)(16D))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(6D)), NewObj(1).Put("mw", ((V)(0.55))).V, NewObj(1).Put("mw", ((V)(1D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("lx", ((V)((-0.6)))).V, ((V)("io"))), "wait", ((V)(500D)));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("quill")), Arr(((V)("shy")), Arr(((V)("scratch")), ((V)(1D))), ((V)("nod")), ((V)("ponder"))));
Call(d_13, V.Undef, ((V)("truffle")), Arr(Fn((V _arrowThis109, int _argc102, V t_108, V _a105, V _a106, V _a107, V[] _rest103) => {
Invoke(Invoke(Invoke(t_108, "to", ((V)(260D)), NewObj(3).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.4))).V), "osc", ((V)(1500D)), ((V)(6D)), NewObj(3).Put("tilt", ((V)(3D))).Put("wag", ((V)(22D))).Put("lift", ((V)(0.5))).V, NewObj(3).Put("tilt", ((V)((-3D)))).Put("wag", ((V)((-22D)))).Put("lift", ((V)(0D))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(4).Put("tilt", ((V)(0D))).Put("wag", ((V)(0D))).Put("sqz", ((V)(0D))).Put("hap", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("sniff")), Arr(((V)("scratch")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("ribbit")), Arr(Arr(((V)("hops")), ((V)(3D))), Fn((V _arrowThis117, int _argc110, V t_116, V _a113, V _a114, V _a115, V[] _rest111) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_116, "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0.9))).Put("open", ((V)(0D))).V), "wait", ((V)(400D))), "to", ((V)(160D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.5))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(2).Put("open", ((V)(0D))).Put("hap", ((V)(0.6))).V);
return default;
}, 1, "", true), ((V)("nod"))));
Call(d_13, V.Undef, ((V)("poppy")), Arr(Arr(((V)("hops")), ((V)(3D))), ((V)("ears")), Fn((V _arrowThis125, int _argc118, V t_124, V _a121, V _a122, V _a123, V[] _rest119) => {
Invoke(Invoke(Invoke(t_124, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.4))).V), "osc", ((V)(1200D)), ((V)(9D)), NewObj(3).Put("mw", ((V)(0.5))).Put("earL", ((V)((-4D)))).Put("earR", ((V)(4D))).V, NewObj(3).Put("mw", ((V)(1D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(3).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("hap", ((V)(0.6))).V);
return default;
}, 1, "", true), Fn((V _arrowThis133, int _argc126, V t_132, V _a129, V _a130, V _a131, V[] _rest127) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_132, "to", ((V)(130D)), NewObj(2).Put("footR", ((V)(3.2))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "to", ((V)(110D)), NewObj(2).Put("footR", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)("footR")), ((V)(3D))), "wait", ((V)(300D))), "to", ((V)(130D)), NewObj(1).Put("footR", ((V)(3.2))).V, ((V)("o"))), "to", ((V)(110D)), NewObj(2).Put("footR", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)("footR")), ((V)(3D))), "to", ((V)(220D)), NewObj(4).Put("sq", ((V)(0D))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).Put("htilt", ((V)(5D))).V);
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("duchess")), Arr(((V)("groom")), Fn((V _arrowThis141, int _argc134, V t_140, V _a137, V _a138, V _a139, V[] _rest135) => {
return Call(sp_12, V.Undef, t_140, NewObj(6).Put("htilt", ((V)(9D))).Put("close", ((V)(0.7))).Put("smile", ((V)(0.6))).Put("pitch", ((V)(0.3))).Put("lean", ((V)((-0.6)))).Put("wag", ((V)(14D))).V, ((V)(1300D)), ((V)(1400D)));
}, 1, "", true), Fn((V _arrowThis149, int _argc142, V t_148, V _a145, V _a146, V _a147, V[] _rest143) => {
Invoke(Invoke(Invoke(t_148, "osc", ((V)(1400D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(22D))).V, NewObj(1).Put("wag", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(260D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-18D)))), NewObj(2).Put("armR", ((V)(60D))).Put("close", ((V)(0.5))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(2D)), NewObj(1).Put("hRy", ((V)((-20D)))).V, NewObj(1).Put("hRy", ((V)((-16D)))).V, ((V)("s")));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("mamapaws")), Arr(Fn((V _arrowThis157, int _argc150, V t_156, V _a153, V _a154, V _a155, V[] _rest151) => {
Invoke(Invoke(Invoke(t_156, "to", ((V)(300D)), NewObj(3).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.4))).V), "fx", ((V)("heart")), ((V)("head"))), "osc", ((V)(3200D)), ((V)(4D)), NewObj(3).Put("lean", ((V)(1.4))).Put("tilt", ((V)(2.4))).Put("htilt", ((V)(4D))).V, NewObj(3).Put("lean", ((V)((-1.4)))).Put("tilt", ((V)((-2.4)))).Put("htilt", ((V)((-4D)))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("sniff")), ((V)("wag")), ((V)("belly"))));
Call(d_13, V.Undef, ((V)("nimbo")), Arr(Fn((V _arrowThis165, int _argc158, V t_164, V _a161, V _a162, V _a163, V[] _rest159) => {
Invoke(t_164, "to", ((V)(400D)), NewObj(3).Put("puff", ((V)(0.8))).Put("sq", ((V)((-0.06)))).Put("frown", ((V)(0.3))).V, ((V)("io")));
Invoke(Call(fxs_14, V.Undef, t_164, ((V)("drop")), ((V)("body")), ((V)(3D)), ((V)(5D)), ((V)(220D))), "to", ((V)(300D)), NewObj(5).Put("puff", ((V)(0D))).Put("sq", ((V)(0.04))).Put("frown", ((V)(0D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(0.8))).V);
return default;
}, 1, "", true), Fn((V _arrowThis173, int _argc166, V t_172, V _a169, V _a170, V _a171, V[] _rest167) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_172, "to", ((V)(500D)), NewObj(4).Put("pitch", ((V)(0.35))).Put("open", ((V)(0.45))).Put("close", ((V)(0.7))).Put("sq", ((V)((-0.08)))).V, ((V)("io"))), "to", ((V)(90D)), NewObj(5).Put("pitch", ((V)((-0.4)))).Put("open", ((V)(0.9))).Put("sqz", ((V)(1D))).Put("close", ((V)(0D))).Put("sq", ((V)(0.2))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("nose")), ((V)(8D))), "fx", ((V)("sneeze")), ((V)("nose"))), "to", ((V)(260D)), NewObj(3).Put("pitch", ((V)(0D))).Put("open", ((V)(0.1))).Put("sq", ((V)(0D))).V), "to", ((V)(260D)), NewObj(3).Put("sqz", ((V)(0D))).Put("open", ((V)(0D))).Put("blush", ((V)(0.7))).V), "wait", ((V)(400D)));
return default;
}, 1, "", true), ((V)("hum"))));
Call(d_13, V.Undef, ((V)("lumi")), Arr(Fn((V _arrowThis181, int _argc174, V t_180, V _a177, V _a178, V _a179, V[] _rest175) => {
Invoke(Invoke(Invoke(Invoke(t_180, "to", ((V)(450D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-10D)))), NewObj(4).Put("armR", ((V)(90D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).Put("ly", ((V)((-0.7)))).V), ((V)("io"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D))), "osc", ((V)(1400D)), ((V)(3D)), NewObj(2).Put("hRx", ((V)((-3D)))).Put("htilt", ((V)(4D))).V, NewObj(2).Put("hRx", ((V)(3D))).Put("htilt", ((V)((-4D)))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D)));
return default;
}, 1, "", true), ((V)("hum")), Arr(((V)("twirl")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("bubbly")), Arr(Fn((V _arrowThis189, int _argc182, V t_188, V _a185, V _a186, V _a187, V[] _rest183) => {
Invoke(Invoke(t_188, "osc", ((V)(3000D)), ((V)(2D)), NewObj(2).Put("turn", ((V)(0.5))).Put("x", ((V)(1D))).V, NewObj(2).Put("turn", ((V)((-0.5)))).Put("x", ((V)((-1D)))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "", true), Fn((V _arrowThis197, int _argc190, V t_196, V _a193, V _a194, V _a195, V[] _rest191) => {
Invoke(Invoke(t_196, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(1D))).Put("mw", ((V)(0.4))).V), "to", ((V)(400D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.25))).Put("mw", ((V)(0.35))).V, ((V)("o")));
Invoke(Call(fxs_14, V.Undef, t_196, ((V)("bigbubble")), ((V)("mouth")), ((V)(1D)), ((V)(3D)), ((V)(300D))), "to", ((V)(200D)), NewObj(4).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), ((V)("wiggle"))));
Call(d_13, V.Undef, ((V)("twinkle")), Arr(Fn((V _arrowThis205, int _argc198, V t_204, V _a201, V _a202, V _a203, V[] _rest199) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_204, "to", ((V)(260D)), NewObj(3).Put("wide", ((V)(0.7))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("body")), ((V)(5D))), "wait", ((V)(500D))), "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(300D)));
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)((-1D)))), ((V)("nod"))));
Call(d_13, V.Undef, ((V)("zappi")), Arr(Fn((V _arrowThis213, int _argc206, V t_212, V _a209, V _a210, V _a211, V[] _rest207) => {
Invoke(Invoke(Invoke(Invoke(t_212, "to", ((V)(80D)), NewObj(3).Put("zap", ((V)(1D))).Put("wide", ((V)(1D))).Put("x", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(7D)), NewObj(1).Put("x", ((V)((-0.8)))).V, NewObj(1).Put("x", ((V)(0.8))).V, ((V)("l"))), "fx", ((V)("spark")), ((V)("body")), ((V)(6D))), "to", ((V)(300D)), NewObj(3).Put("zap", ((V)(0D))).Put("wide", ((V)(0D))).Put("x", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _arrowThis221, int _argc214, V t_220, V _a217, V _a218, V _a219, V[] _rest215) => {
Invoke(Invoke(Invoke(t_220, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.9))).Put("smile", ((V)(1D))).V), "osc", ((V)(800D)), ((V)(8D)), NewObj(2).Put("footL", ((V)(1.6))).Put("footR", ((V)(0D))).V, NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(1.6))).V, ((V)("l"))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(2D)))));
Call(d_13, V.Undef, ((V)("plip")), Arr(Fn((V _arrowThis229, int _argc222, V t_228, V _a225, V _a226, V _a227, V[] _rest223) => {
Invoke(Invoke(Invoke(t_228, "fx", ((V)("drop")), ((V)("head")), ((V)(2D))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("sq", ((V)(0.08))).V, NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "", true), ((V)("hum")), Arr(((V)("hops")), ((V)(2D)))));
Call(d_13, V.Undef, ((V)("breeze")), Arr(Fn((V _arrowThis237, int _argc230, V t_236, V _a233, V _a234, V _a235, V[] _rest231) => {
Invoke(Invoke(Invoke(Invoke(t_236, "to", ((V)(300D)), NewObj(3).Put("open", ((V)(0.5))).Put("puff", ((V)(0.6))).Put("lean", ((V)((-1.4)))).V), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(500D)), NewObj(3).Put("lean", ((V)(2D))).Put("open", ((V)(0.1))).Put("puff", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(400D)));
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("hum"))));
Call(d_13, V.Undef, ((V)("dusty")), Arr(Fn((V _arrowThis245, int _argc238, V t_244, V _a241, V _a242, V _a243, V[] _rest239) => {
Invoke(Invoke(Invoke(t_244, "fx", ((V)("dust")), ((V)("body")), ((V)(4D))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("sq", ((V)(0.05))).V, NewObj(1).Put("sq", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "", true), ((V)("sneeze")), ((V)("ears")), ((V)("flap"))));
Call(d_13, V.Undef, ((V)("aurora")), Arr(Fn((V _arrowThis253, int _argc246, V t_252, V _a249, V _a250, V _a251, V[] _rest247) => {
Invoke(Invoke(Invoke(Invoke(t_252, "to", ((V)(300D)), NewObj(2).Put("spout", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D))), "wait", ((V)(900D))), "to", ((V)(400D)), NewObj(1).Put("spout", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _arrowThis261, int _argc254, V t_260, V _a257, V _a258, V _a259, V[] _rest255) => {
return Call(sp_12, V.Undef, t_260, NewObj(3).Put("glow", ((V)(1D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true), Fn((V _arrowThis269, int _argc262, V t_268, V _a265, V _a266, V _a267, V[] _rest263) => {
Invoke(t_268, "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("s")));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("mallow")), Arr(Fn((V _arrowThis277, int _argc270, V t_276, V _a273, V _a274, V _a275, V[] _rest271) => {
Invoke(Invoke(Invoke(t_276, "to", ((V)(1200D)), NewObj(4).Put("sq", ((V)(0.2))).Put("lift", ((V)((-1.6)))).Put("close", ((V)(0.85))).Put("smile", ((V)(1D))).V, ((V)("s"))), "wait", ((V)(800D))), "to", ((V)(220D)), NewObj(4).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(1D))).Put("close", ((V)(0D))).Put("wide", ((V)(0.4))).V, ((V)("o")));
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(2D))), Fn((V _arrowThis285, int _argc278, V t_284, V _a281, V _a282, V _a283, V[] _rest279) => {
return Invoke(Call(sp_12, V.Undef, t_284, NewObj(3).Put("blush", ((V)(1D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(1200D))), "fx", ((V)("steam")), ((V)("head")));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("bao")), Arr(Fn((V _arrowThis293, int _argc286, V t_292, V _a289, V _a290, V _a291, V[] _rest287) => {
Invoke(Invoke(Invoke(Invoke(t_292, "to", ((V)(500D)), NewObj(4).Put("sq", ((V)((-0.07)))).Put("lift", ((V)(1.4))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("head"))), "wait", ((V)(500D))), "fx", ((V)("steam")), ((V)("head")));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("belly"))));
Call(d_13, V.Undef, ((V)("dunkie")), Arr(Fn((V _arrowThis301, int _argc294, V t_300, V _a297, V _a298, V _a299, V[] _rest295) => {
Invoke(Invoke(Invoke(t_300, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("x", ((V)(1.1))).Put("tilt", ((V)(3D))).V, NewObj(2).Put("x", ((V)((-1.1)))).Put("tilt", ((V)((-3D)))).V, ((V)("s"))), "fx", ((V)("sprinkle")), ((V)("head")));
return default;
}, 1, "", true), ((V)("belly")), Arr(((V)("hops")), ((V)(2D)))));
Call(d_13, V.Undef, ((V)("frybo")), Arr(Fn((V _arrowThis309, int _argc302, V t_308, V _a305, V _a306, V _a307, V[] _rest303) => {
return Call(sp_12, V.Undef, t_308, NewObj(3).Put("fw", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(900D)), ((V)(900D)));
}, 1, "", true), Fn((V _arrowThis317, int _argc310, V t_316, V _a313, V _a314, V _a315, V[] _rest311) => {
Invoke(Invoke(Invoke(t_316, "fx", ((V)("salt")), ((V)("head"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("l"))), "fx", ((V)("salt")), ((V)("head")));
return default;
}, 1, "", true), ((V)("clap"))));
Call(d_13, V.Undef, ((V)("bunbun")), Arr(Fn((V _arrowThis325, int _argc318, V t_324, V _a321, V _a322, V _a323, V[] _rest319) => {
Invoke(Invoke(Invoke(Invoke(t_324, "to", ((V)(300D)), NewObj(3).Put("split", ((V)(0.4))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(1).Put("shuf", ((V)(0.6))).V, NewObj(1).Put("shuf", ((V)((-0.6)))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(2).Put("split", ((V)(0D))).Put("shuf", ((V)(0D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.06))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("giggle"))));
Call(d_13, V.Undef, ((V)("choco")), Arr(Fn((V _arrowThis333, int _argc326, V t_332, V _a329, V _a330, V _a331, V[] _rest327) => {
return Call(sp_12, V.Undef, t_332, NewObj(3).Put("melt", ((V)(0.35))).Put("close", ((V)(0.75))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true), Fn((V _arrowThis341, int _argc334, V t_340, V _a337, V _a338, V _a339, V[] _rest335) => {
Invoke(Invoke(Invoke(Invoke(t_340, "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0.08))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "fx", ((V)("crumb")), ((V)("body")), ((V)(3D))), "to", ((V)(200D)), NewObj(3).Put("sq", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), ((V)("belly"))));
Call(d_13, V.Undef, ((V)("scoop")), Arr(Fn((V _arrowThis349, int _argc342, V t_348, V _a345, V _a346, V _a347, V[] _rest343) => {
Invoke(t_348, "osc", ((V)(1400D)), ((V)(4D)), NewObj(2).Put("chb", ((V)(1D))).Put("hap", ((V)(0.7))).V, NewObj(2).Put("chb", ((V)(0D))).Put("hap", ((V)(0.4))).V, ((V)("o")));
return default;
}, 1, "", true), Fn((V _arrowThis357, int _argc350, V t_356, V _a353, V _a354, V _a355, V[] _rest351) => {
Invoke(Invoke(Invoke(t_356, "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)((-0.12)))).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.3))).Put("close", ((V)(0.6))).V), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("htilt", ((V)(6D))).V, NewObj(1).Put("htilt", ((V)((-6D)))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(4).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("boba")), Arr(Fn((V _arrowThis365, int _argc358, V t_364, V _a361, V _a362, V _a363, V[] _rest359) => {
Invoke(Invoke(Invoke(Invoke(t_364, "to", ((V)(300D)), NewObj(4).Put("sqz", ((V)(0.6))).Put("open", ((V)(0.15))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.3)))).V), "osc", ((V)(1200D)), ((V)(6D)), NewObj(2).Put("x", ((V)(0.5))).Put("sq", ((V)(0.02))).V, NewObj(2).Put("x", ((V)((-0.5)))).Put("sq", ((V)(0D))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(5).Put("sqz", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(400D)));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("wiggle"))));
Call(d_13, V.Undef, ((V)("chefbun")), Arr(Fn((V _arrowThis373, int _argc366, V t_372, V _a369, V _a370, V _a371, V[] _rest367) => {
Invoke(Invoke(Invoke(Invoke(t_372, "to", ((V)(380D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-14D)))), NewObj(3).Put("armR", ((V)(36D))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V)), "wait", ((V)(300D))), "to", ((V)(260D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)((-6D))), ((V)((-16D)))), NewObj(3).Put("armR", ((V)(70D))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).V), ((V)("o"))), "fx", ((V)("heart")), ((V)("head")));
return default;
}, 1, "", true), ((V)("ponder")), ((V)("clap"))));
Call(d_13, V.Undef, ((V)("pip")), Arr(((V)("flap")), Fn((V _arrowThis381, int _argc374, V t_380, V _a377, V _a378, V _a379, V[] _rest375) => {
Invoke(Invoke(t_380, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V), "osc", ((V)(1600D)), ((V)(4D)), NewObj(4).Put("tilt", ((V)(7D))).Put("x", ((V)(1.2))).Put("footL", ((V)(1.4))).Put("footR", ((V)(0D))).V, NewObj(4).Put("tilt", ((V)((-7D)))).Put("x", ((V)((-1.2)))).Put("footL", ((V)(0D))).Put("footR", ((V)(1.4))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("shake"))));
Call(d_13, V.Undef, ((V)("jelli")), Arr(Fn((V _arrowThis389, int _argc382, V t_388, V _a385, V _a386, V _a387, V[] _rest383) => {
{
double i_390 = 0;
i_390 = 0D;
while (true) {
if (!((i_390 < 3D))) break;
Invoke(Invoke(Invoke(t_388, "to", ((V)(240D)), NewObj(2).Put("sq", ((V)(0.1))).Put("lift", ((V)((-0.4)))).V, ((V)("i"))), "to", ((V)(420D)), NewObj(2).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2.4))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("s")));
i_390++;
}
}
return default;
}, 1, "", true), ((V)("hum")), Arr(((V)("wave")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("finn")), Arr(Fn((V _arrowThis399, int _argc392, V t_398, V _a395, V _a396, V _a397, V[] _rest393) => {
Invoke(Invoke(Invoke(t_398, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(900D)), ((V)(6D)), NewObj(1).Put("open", ((V)(0.5))).V, NewObj(1).Put("open", ((V)(0.1))).V, ((V)("l"))), "fx", ((V)("note")), ((V)("head")));
return default;
}, 1, "", true), Fn((V _arrowThis407, int _argc400, V t_406, V _a403, V _a404, V _a405, V[] _rest401) => {
Invoke(Invoke(t_406, "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(28D))).V, NewObj(1).Put("wag", ((V)((-28D)))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)("body")), ((V)(4D)));
return default;
}, 1, "", true), ((V)("clap"))));
Call(d_13, V.Undef, ((V)("sealy")), Arr(Fn((V _arrowThis415, int _argc408, V t_414, V _a411, V _a412, V _a413, V[] _rest409) => {
Invoke(Invoke(t_414, "to", ((V)(300D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(1D)), ((V)((-4D)))), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V)), "osc", ((V)(1200D)), ((V)(5D)), NewObj(3).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-1D)))).Put("open", ((V)(0.5))).V, NewObj(3).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-6D)))).Put("open", ((V)(0.1))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("wiggle")), Fn((V _arrowThis423, int _argc416, V t_422, V _a419, V _a420, V _a421, V[] _rest417) => {
return Call(sp_12, V.Undef, t_422, NewObj(4).Put("tilt", ((V)((-9D)))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("close", ((V)(0.5))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("puff")), Arr(Fn((V _arrowThis431, int _argc424, V t_430, V _a427, V _a428, V _a429, V[] _rest425) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_430, "to", ((V)(500D)), NewObj(3).Put("blo", ((V)(0.6))).Put("puff", ((V)(0.6))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(700D))), "fx", ((V)("bubble")), ((V)("head"))), "to", ((V)(800D)), NewObj(3).Put("blo", ((V)(0D))).Put("puff", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("bubble")), ((V)("head")));
return default;
}, 1, "", true), Fn((V _arrowThis439, int _argc432, V t_438, V _a435, V _a436, V _a437, V[] _rest433) => {
Invoke(Invoke(t_438, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(1D))).Put("mw", ((V)(0.4))).V), "to", ((V)(400D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.25))).Put("mw", ((V)(0.35))).V, ((V)("o")));
Invoke(Call(fxs_14, V.Undef, t_438, ((V)("bubble")), ((V)("mouth")), ((V)(2D)), ((V)(3D)), ((V)(280D))), "to", ((V)(200D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(0.8))).V);
return default;
}, 1, "", true), ((V)("hum"))));
Call(d_13, V.Undef, ((V)("shelly")), Arr(Fn((V _arrowThis447, int _argc440, V t_446, V _a443, V _a444, V _a445, V[] _rest441) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_446, "to", ((V)(600D)), NewObj(2).Put("nk", ((V)(1D))).Put("ly", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(2).Put("lx", ((V)((-1D)))).Put("turn", ((V)((-0.3)))).V), "wait", ((V)(500D))), "to", ((V)(600D)), NewObj(2).Put("lx", ((V)(1D))).Put("turn", ((V)(0.3))).V), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(4).Put("lx", ((V)(0D))).Put("turn", ((V)(0D))).Put("nk", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true), Fn((V _arrowThis455, int _argc448, V t_454, V _a451, V _a452, V _a453, V[] _rest449) => {
Invoke(Invoke(Invoke(Invoke(t_454, "to", ((V)(400D)), NewObj(1).Put("hid", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(1300D))), "to", ((V)(260D)), NewObj(1).Put("hid", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "", true), ((V)("nod"))));
Call(d_13, V.Undef, ((V)("octo")), Arr(Fn((V _arrowThis463, int _argc456, V t_462, V _a459, V _a460, V _a461, V[] _rest457) => {
return Call(sp_12, V.Undef, t_462, NewObj(3).Put("ow", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), Fn((V _arrowThis471, int _argc464, V t_470, V _a467, V _a468, V _a469, V[] _rest465) => {
return Call(sp_12, V.Undef, t_470, NewObj(2).Put("ocl", ((V)(1D))).Put("close", ((V)(0.7))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "", true), Fn((V _arrowThis479, int _argc472, V t_478, V _a475, V _a476, V _a477, V[] _rest473) => {
Invoke(Invoke(Invoke(t_478, "to", ((V)(300D)), NewObj(2).Put("ojt", ((V)(0.8))).Put("sq", ((V)(0.08))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(4).Put("ojt", ((V)(0D))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.06)))).Put("osp", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(600D)), NewObj(3).Put("lift", ((V)(0D))).Put("osp", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("s")));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("marina")), Arr(Fn((V _arrowThis487, int _argc480, V t_486, V _a483, V _a484, V _a485, V[] _rest481) => {
Invoke(Invoke(Invoke(Invoke(t_486, "to", ((V)(400D)), NewObj(2).Put("tlf", ((V)(0.8))).Put("tsw", ((V)(0.6))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)((-0.6)))).V, NewObj(1).Put("tsw", ((V)(0.6))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("body")), ((V)(4D))), "to", ((V)(400D)), NewObj(2).Put("tlf", ((V)(0D))).Put("tsw", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _arrowThis495, int _argc488, V t_494, V _a491, V _a492, V _a493, V[] _rest489) => {
return Call(sp_12, V.Undef, t_494, NewObj(4).Put("htilt", ((V)((-10D)))).Put("lean", ((V)((-1.4)))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1000D)), ((V)(600D)));
}, 1, "", true), ((V)("hum"))), NewObj(1).Put("skip", Arr(((V)("idle_yawn")))).V);
Call(d_13, V.Undef, ((V)("pearl")), Arr(Fn((V _arrowThis503, int _argc496, V t_502, V _a499, V _a500, V _a501, V[] _rest497) => {
return Invoke(Call(sp_12, V.Undef, t_502, NewObj(4).Put("glow", ((V)(1D))).Put("wide", ((V)(0.3))).Put("hap", ((V)(0.6))).Put("hsw", ((V)(0.6))).V, ((V)(1200D)), ((V)(1000D))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D)));
}, 1, "", true), Fn((V _arrowThis511, int _argc504, V t_510, V _a507, V _a508, V _a509, V[] _rest505) => {
return Call(sp_12, V.Undef, t_510, NewObj(3).Put("fflap", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(900D)));
}, 1, "", true), ((V)("hum"))));
Call(d_13, V.Undef, ((V)("pina")), Arr(Fn((V _arrowThis519, int _argc512, V t_518, V _a515, V _a516, V _a517, V[] _rest513) => {
Invoke(Invoke(Invoke(t_518, "to", ((V)(220D)), NewObj(2).Put("crw", ((V)(1D))).Put("hap", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(1).Put("htilt", ((V)(6D))).V, NewObj(1).Put("htilt", ((V)((-6D)))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(1).Put("crw", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _arrowThis527, int _argc520, V t_526, V _a523, V _a524, V _a525, V[] _rest521) => {
Invoke(Invoke(t_526, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("close", ((V)(0.4))).V), "osc", ((V)(2000D)), ((V)(3D)), NewObj(4).Put("x", ((V)(1.4))).Put("tilt", ((V)(5D))).Put("armL", ((V)(50D))).Put("armR", ((V)(30D))).V, NewObj(4).Put("x", ((V)((-1.4)))).Put("tilt", ((V)((-5D)))).Put("armL", ((V)(30D))).Put("armR", ((V)(50D))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _arrowThis535, int _argc528, V t_534, V _a531, V _a532, V _a533, V[] _rest529) => {
return Call(sp_12, V.Undef, t_534, NewObj(2).Put("crs", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("avo")), Arr(Fn((V _arrowThis543, int _argc536, V t_542, V _a539, V _a540, V _a541, V[] _rest537) => {
Invoke(Invoke(Invoke(t_542, "to", ((V)(200D)), NewObj(3).Put("prw", ((V)(1D))).Put("pp", ((V)(0.35))).Put("wide", ((V)(0.4))).V, ((V)("o"))), "wait", ((V)(900D))), "to", ((V)(300D)), NewObj(3).Put("prw", ((V)(0D))).Put("pp", ((V)(0D))).Put("wide", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _arrowThis551, int _argc544, V t_550, V _a547, V _a548, V _a549, V[] _rest545) => {
return Call(sp_12, V.Undef, t_550, NewObj(3).Put("lfl", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1000D)), ((V)(800D)));
}, 1, "", true), ((V)("belly"))));
Call(d_13, V.Undef, ((V)("berri")), Arr(Fn((V _arrowThis559, int _argc552, V t_558, V _a555, V _a556, V _a557, V[] _rest553) => {
Invoke(Invoke(t_558, "to", ((V)(120D)), NewObj(2).Put("stw", ((V)(1D))).Put("hap", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(900D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("bk")));
return default;
}, 1, "", true), Fn((V _arrowThis567, int _argc560, V t_566, V _a563, V _a564, V _a565, V[] _rest561) => {
return Call(sp_12, V.Undef, t_566, NewObj(3).Put("lsp", ((V)(1D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(700D)));
}, 1, "", true), ((V)("curtsy"))));
Call(d_13, V.Undef, ((V)("lemmy")), Arr(Fn((V _arrowThis575, int _argc568, V t_574, V _a571, V _a572, V _a573, V[] _rest569) => {
Invoke(Invoke(Invoke(Invoke(t_574, "to", ((V)(200D)), NewObj(4).Put("sqz", ((V)(1D))).Put("mw", ((V)(0.4))).Put("open", ((V)(0.12))).Put("frown", ((V)(0.4))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(7D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(5).Put("sqz", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("frown", ((V)(0D))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(300D)));
return default;
}, 1, "", true), Fn((V _arrowThis583, int _argc576, V t_582, V _a579, V _a580, V _a581, V[] _rest577) => {
return Call(sp_12, V.Undef, t_582, NewObj(2).Put("lfl", ((V)(1D))).Put("hap", ((V)(0.5))).V, ((V)(900D)), ((V)(600D)));
}, 1, "", true), ((V)("wiggle"))));
Call(d_13, V.Undef, ((V)("kiwi")), Arr(Fn((V _arrowThis591, int _argc584, V t_590, V _a587, V _a588, V _a589, V[] _rest585) => {
Invoke(Invoke(Invoke(Invoke(t_590, "to", ((V)(220D)), NewObj(2).Put("fzz", ((V)(1D))).Put("sqz", ((V)(0.6))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.7))).V, NewObj(1).Put("x", ((V)((-0.7)))).V, ((V)("l"))), "fx", ((V)("kiwifuzz")), ((V)("body")), ((V)(3D))), "to", ((V)(400D)), NewObj(3).Put("fzz", ((V)(0D))).Put("sqz", ((V)(0D))).Put("hap", ((V)(0.6))).V);
return default;
}, 1, "", true), Fn((V _arrowThis599, int _argc592, V t_598, V _a595, V _a596, V _a597, V[] _rest593) => {
{
double i_600 = 0;
i_600 = 0D;
while (true) {
if (!((i_600 < 3D))) break;
Invoke(Invoke(Invoke(t_598, "to", ((V)(160D)), NewObj(3).Put("pitch", ((V)((-0.35)))).Put("lean", ((V)(1D))).Put("ly", ((V)(0.8))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(3).Put("pitch", ((V)(0D))).Put("lean", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(160D)));
i_600++;
}
}
return default;
}, 1, "", true), Fn((V _arrowThis609, int _argc602, V t_608, V _a605, V _a606, V _a607, V[] _rest603) => {
Invoke(t_608, "osc", ((V)(1400D)), ((V)(4D)), NewObj(3).Put("pitch", ((V)(0.1))).Put("footL", ((V)(2D))).Put("footR", ((V)(0D))).V, NewObj(3).Put("pitch", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).V, ((V)("s")));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("melo")), Arr(Fn((V _arrowThis617, int _argc610, V t_616, V _a613, V _a614, V _a615, V[] _rest611) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_616, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.7))).Put("open", ((V)(0D))).V), "to", ((V)(120D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).Put("pitch", ((V)((-0.1)))).V, ((V)("o"))), "fx", ((V)("meloseed")), ((V)("mouth"))), "to", ((V)(300D)), NewObj(4).Put("open", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "wait", ((V)(400D)));
return default;
}, 1, "", true), Fn((V _arrowThis625, int _argc618, V t_624, V _a621, V _a622, V _a623, V[] _rest619) => {
Invoke(t_624, "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("sdj", ((V)(1D))).V, NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true), Arr(((V)("hops")), ((V)(2D)))));
Call(d_13, V.Undef, ((V)("peachy")), Arr(Fn((V _arrowThis633, int _argc626, V t_632, V _a629, V _a630, V _a631, V[] _rest627) => {
Invoke(Invoke(t_632, "to", ((V)(400D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(9D)), ((V)((-12D)))), NewObj(5).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("blush", ((V)(1D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V)), "osc", ((V)(1600D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(3D))).Put("htilt", ((V)(6D))).V, NewObj(2).Put("tilt", ((V)((-3D)))).Put("htilt", ((V)((-6D)))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _arrowThis641, int _argc634, V t_640, V _a637, V _a638, V _a639, V[] _rest635) => {
return Call(sp_12, V.Undef, t_640, NewObj(2).Put("lsp", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(800D)));
}, 1, "", true), ((V)("curtsy"))));
Call(d_13, V.Undef, ((V)("pitaya")), Arr(Fn((V _arrowThis649, int _argc642, V t_648, V _a645, V _a646, V _a647, V[] _rest643) => {
return Invoke(Call(sp_12, V.Undef, t_648, NewObj(4).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.7))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(1000D))), "fx", ((V)("spark")), ((V)("body")), ((V)(4D)));
}, 1, "", true), Fn((V _arrowThis657, int _argc650, V t_656, V _a653, V _a654, V _a655, V[] _rest651) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_656, "to", ((V)(300D)), NewObj(2).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.1)))).V), "to", ((V)(220D)), NewObj(9).Put("brf", ((V)(1D))).Put("crw", ((V)(1D))).Put("open", ((V)(0.7))).Put("wide", ((V)(0.6))).Put("pitch", ((V)(0.15))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("hRx", ((V)(3D))).Put("hLx", ((V)((-3D)))).V, ((V)("o"))), "fx", ((V)("pitseed")), ((V)("mouth")), ((V)(3D))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(11).Put("brf", ((V)(0D))).Put("crw", ((V)(0D))).Put("open", ((V)(0D))).Put("wide", ((V)(0D))).Put("pitch", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hRx", ((V)(0D))).Put("hLx", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("io")));
return default;
}, 1, "", true), ((V)("stomp"))));
Call(d_13, V.Undef, ((V)("tutti")), Arr(Fn((V _arrowThis665, int _argc658, V t_664, V _a661, V _a662, V _a663, V[] _rest659) => {
Invoke(Invoke(Invoke(Invoke(t_664, "to", ((V)(300D)), NewObj(3).Put("fL", ((V)(1D))).Put("ly", ((V)((-0.8)))).Put("hap", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("fL", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(2).Put("fR", ((V)(1D))).Put("ly", ((V)((-0.8)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("fR", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("i")));
return default;
}, 1, "", true), Fn((V _arrowThis673, int _argc666, V t_672, V _a669, V _a670, V _a671, V[] _rest667) => {
return Invoke(Call(sp_12, V.Undef, t_672, NewObj(3).Put("wfl", ((V)(1D))).Put("hap", ((V)(0.6))).Put("lift", ((V)(2D))).V, ((V)(1200D)), ((V)(900D))), "fx", ((V)("fairydust")), ((V)("body")), ((V)(4D)));
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("kiko")), Arr(Fn((V _arrowThis681, int _argc674, V t_680, V _a677, V _a678, V _a679, V[] _rest675) => {
Invoke(Invoke(Invoke(Invoke(t_680, "to", ((V)(300D)), NewObj(2).Put("htilt", ((V)((-10D)))).Put("lean", ((V)((-1.4)))).V), "to", ((V)(360D)), NewObj(4).Put("htilt", ((V)(9D))).Put("lean", ((V)(1.4))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(500D)));
return default;
}, 1, "", true), ((V)("sniff")), Arr(((V)("scratch")), ((V)((-1D))))));
Call(d_13, V.Undef, ((V)("teddy")), Arr(Fn((V _arrowThis689, int _argc682, V t_688, V _a685, V _a686, V _a687, V[] _rest683) => {
Invoke(Invoke(Invoke(t_688, "to", ((V)(450D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(14D)), ((V)((-6D)))), NewObj(6).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).Put("blush", ((V)(0.6))).V)), "fx", ((V)("heart")), ((V)("head"))), "osc", ((V)(2000D)), ((V)(2D)), NewObj(2).Put("lean", ((V)(1.2))).Put("tilt", ((V)(2D))).V, NewObj(2).Put("lean", ((V)((-1.2)))).Put("tilt", ((V)((-2D)))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _arrowThis697, int _argc690, V t_696, V _a693, V _a694, V _a695, V[] _rest691) => {
Invoke(Invoke(t_696, "to", ((V)(300D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(6D)), ((V)(4D))), NewObj(5).Put("armL", ((V)(14D))).Put("armR", ((V)(14D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V), ((V)("io"))), "osc", ((V)(1000D)), ((V)(6D)), NewObj(2).Put("hLy", ((V)(8D))).Put("hRy", ((V)(2D))).V, NewObj(2).Put("hLy", ((V)(2D))).Put("hRy", ((V)(8D))).V, ((V)("o")));
return default;
}, 1, "", true), Fn((V _arrowThis705, int _argc698, V t_704, V _a701, V _a702, V _a703, V[] _rest699) => {
Invoke(Invoke(Invoke(Invoke(t_704, "to", ((V)(380D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-14D)))), NewObj(3).Put("armR", ((V)(32D))).Put("close", ((V)(0.7))).Put("tongue", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("tongue", ((V)(0.9))).Put("hRy", ((V)((-16D)))).V, NewObj(2).Put("tongue", ((V)(0.3))).Put("hRy", ((V)((-13D)))).V, ((V)("l"))), "fx", ((V)("honey")), ((V)("pawR")), ((V)(2D))), "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("hoot")), Arr(Fn((V _arrowThis713, int _argc706, V t_712, V _a709, V _a710, V _a711, V[] _rest707) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_712, "to", ((V)(600D)), NewObj(3).Put("turn", ((V)(0.85))).Put("lx", ((V)(1D))).Put("tfl", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(800D)), NewObj(2).Put("turn", ((V)((-0.85)))).Put("lx", ((V)((-1D)))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(3).Put("turn", ((V)(0D))).Put("lx", ((V)(0D))).Put("tfl", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _arrowThis721, int _argc714, V t_720, V _a717, V _a718, V _a719, V[] _rest715) => {
Invoke(Invoke(Invoke(Invoke(t_720, "to", ((V)(200D)), NewObj(2).Put("wfl", ((V)(1D))).Put("fzz", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(2).Put("x", ((V)(0.7))).Put("sq", ((V)(0.03))).V, NewObj(2).Put("x", ((V)((-0.7)))).Put("sq", ((V)(0D))).V, ((V)("l"))), "fx", ((V)("feather")), ((V)("body")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("wfl", ((V)(0D))).Put("fzz", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("nod"))), NewObj(1).Put("skip", Arr(((V)("idle_waveR")))).V);
Call(d_13, V.Undef, ((V)("leo")), Arr(Fn((V _arrowThis729, int _argc722, V t_728, V _a725, V _a726, V _a727, V[] _rest723) => {
Invoke(Invoke(Invoke(Invoke(t_728, "to", ((V)(200D)), NewObj(2).Put("msh", ((V)(1D))).Put("mfl", ((V)(0.6))).V), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("htilt", ((V)(7D))).V, NewObj(1).Put("htilt", ((V)((-7D)))).V, ((V)("l"))), "fx", ((V)("manefur")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("msh", ((V)(0D))).Put("mfl", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _arrowThis737, int _argc730, V t_736, V _a733, V _a734, V _a735, V[] _rest731) => {
return Call(sp_12, V.Undef, t_736, NewObj(6).Put("open", ((V)(0.7))).Put("wide", ((V)(0.4))).Put("mfl", ((V)(1D))).Put("pitch", ((V)(0.15))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)(800D)), ((V)(500D)));
}, 1, "", true), Fn((V _arrowThis745, int _argc738, V t_744, V _a741, V _a742, V _a743, V[] _rest739) => {
Invoke(t_744, "osc", ((V)(1800D)), ((V)(3D)), NewObj(1).Put("tsw", ((V)(1D))).V, NewObj(1).Put("tsw", ((V)((-1D)))).V, ((V)("s")));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("panko")), Arr(Fn((V _arrowThis753, int _argc746, V t_752, V _a749, V _a750, V _a751, V[] _rest747) => {
Invoke(Invoke(Invoke(t_752, "to", ((V)(400D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(11D)), ((V)((-14D)))), NewObj(1).Put("armR", ((V)(34D))).V)), "osc", ((V)(2000D)), ((V)(7D)), NewObj(2).Put("open", ((V)(0.3))).Put("puff", ((V)(0.6))).V, NewObj(2).Put("open", ((V)(0.05))).Put("puff", ((V)(0.3))).V, ((V)("s"))), "fx", ((V)("bamboo")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "", true), Fn((V _arrowThis761, int _argc754, V t_760, V _a757, V _a758, V _a759, V[] _rest755) => {
Invoke(Invoke(t_760, "osc", ((V)(2400D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(9D))).Put("x", ((V)(1.4))).V, NewObj(2).Put("tilt", ((V)((-9D)))).Put("x", ((V)((-1.4)))).V, ((V)("s"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), ((V)("belly"))));
Call(d_13, V.Undef, ((V)("acorn")), Arr(Fn((V _arrowThis769, int _argc762, V t_768, V _a765, V _a766, V _a767, V[] _rest763) => {
Invoke(t_768, "osc", ((V)(1000D)), ((V)(4D)), NewObj(2).Put("tfl", ((V)(1D))).Put("tsw", ((V)(0.8))).V, NewObj(2).Put("tfl", ((V)(0.2))).Put("tsw", ((V)((-0.8)))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _arrowThis777, int _argc770, V t_776, V _a773, V _a774, V _a775, V[] _rest771) => {
Invoke(Invoke(Invoke(t_776, "to", ((V)(300D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(9D)), ((V)((-11D)))), NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V)), "osc", ((V)(1400D)), ((V)(7D)), NewObj(1).Put("open", ((V)(0.25))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("l"))), "fx", ((V)("nutbit")), ((V)("mouth")), ((V)(3D)));
return default;
}, 1, "", true), Fn((V _arrowThis785, int _argc778, V t_784, V _a781, V _a782, V _a783, V[] _rest779) => {
return Call(sp_12, V.Undef, t_784, NewObj(4).Put("ctp", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).Put("htilt", ((V)(6D))).V, ((V)(1000D)), ((V)(700D)));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("fawn")), Arr(((V)("ears")), Fn((V _arrowThis793, int _argc786, V t_792, V _a789, V _a790, V _a791, V[] _rest787) => {
Invoke(Invoke(t_792, "osc", ((V)(1400D)), ((V)(4D)), NewObj(4).Put("footL", ((V)(2.6))).Put("footR", ((V)(0D))).Put("lift", ((V)(0.8))).Put("pitch", ((V)((-0.04)))).V, NewObj(4).Put("footL", ((V)(0D))).Put("footR", ((V)(2.6))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("s"))), "fx", ((V)("fawnleaf")), ((V)("body")), ((V)(2D)));
return default;
}, 1, "", true), ((V)("sniff"))));
Call(d_13, V.Undef, ((V)("moss")), Arr(Fn((V _arrowThis801, int _argc794, V t_800, V _a797, V _a798, V _a799, V[] _rest795) => {
Invoke(Invoke(t_800, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("cb", ((V)(1D))).V, NewObj(1).Put("cb", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("spore")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "", true), Fn((V _arrowThis809, int _argc802, V t_808, V _a805, V _a806, V _a807, V[] _rest803) => {
return Call(sp_12, V.Undef, t_808, NewObj(3).Put("csp", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(700D)));
}, 1, "", true), ((V)("wiggle"))));
Call(d_13, V.Undef, ((V)("sprout")), Arr(Fn((V _arrowThis817, int _argc810, V t_816, V _a813, V _a814, V _a815, V[] _rest811) => {
return Invoke(Call(sp_12, V.Undef, t_816, NewObj(3).Put("blm", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D))), "fx", ((V)("petal")), ((V)("head")), ((V)(3D)));
}, 1, "", true), Fn((V _arrowThis825, int _argc818, V t_824, V _a821, V _a822, V _a823, V[] _rest819) => {
Invoke(t_824, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("stw", ((V)(1D))).V, NewObj(1).Put("stw", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true), Fn((V _arrowThis833, int _argc826, V t_832, V _a829, V _a830, V _a831, V[] _rest827) => {
return Call(sp_12, V.Undef, t_832, NewObj(2).Put("lfl", ((V)(1D))).Put("hap", ((V)(0.5))).V, ((V)(1000D)), ((V)(700D)));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("hana")), Arr(Fn((V _arrowThis841, int _argc834, V t_840, V _a837, V _a838, V _a839, V[] _rest835) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_840, "to", ((V)(300D)), NewObj(1).Put("flL", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(300D)), NewObj(2).Put("flL", ((V)(0D))).Put("flR", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(300D)), NewObj(1).Put("flR", ((V)(0D))).V);
return default;
}, 1, "", true), Fn((V _arrowThis849, int _argc842, V t_848, V _a845, V _a846, V _a847, V[] _rest843) => {
Invoke(t_848, "osc", ((V)(1000D)), ((V)(4D)), NewObj(1).Put("tw", ((V)(1D))).V, NewObj(1).Put("tw", ((V)((-1D)))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _arrowThis857, int _argc850, V t_856, V _a853, V _a854, V _a855, V[] _rest851) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_856, "to", ((V)(130D)), NewObj(2).Put("footR", ((V)(3.2))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "to", ((V)(110D)), NewObj(2).Put("footR", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)("footR")), ((V)(3D))), "wait", ((V)(250D))), "to", ((V)(130D)), NewObj(1).Put("footR", ((V)(3.2))).V, ((V)("o"))), "to", ((V)(110D)), NewObj(2).Put("footR", ((V)(0D))).Put("sq", ((V)(0.08))).V, ((V)("i"))), "fx", ((V)("dust")), ((V)("footR")), ((V)(3D))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V);
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("boo")), Arr(Fn((V _arrowThis865, int _argc858, V t_864, V _a861, V _a862, V _a863, V[] _rest859) => {
Invoke(Invoke(Invoke(Invoke(t_864, "to", ((V)(400D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(10D)), ((V)((-14D)))), NewObj(4).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("blush", ((V)(0.9))).Put("gho", ((V)(0.45))).V)), "wait", ((V)(900D))), "to", ((V)(400D)), NewObj(1).Put("gho", ((V)(0D))).V), "wait", ((V)(200D)));
return default;
}, 1, "", true), Fn((V _arrowThis873, int _argc866, V t_872, V _a869, V _a870, V _a871, V[] _rest867) => {
return Call(sp_12, V.Undef, t_872, NewObj(2).Put("flr", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(600D)));
}, 1, "", true), Fn((V _arrowThis881, int _argc874, V t_880, V _a877, V _a878, V _a879, V[] _rest875) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_880, "to", ((V)(300D)), NewObj(1).Put("gho", ((V)(0.7))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(140D)), NewObj(7).Put("gho", ((V)(0D))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.7))).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(5).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.6))).V);
return default;
}, 1, "", true)), NewObj(1).Put("skip", Arr(((V)("idle_yawn")))).V);
Call(d_13, V.Undef, ((V)("pixie")), Arr(Fn((V _arrowThis889, int _argc882, V t_888, V _a885, V _a886, V _a887, V[] _rest883) => {
return Invoke(Call(sp_12, V.Undef, t_888, NewObj(4).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.6))).Put("hap", ((V)(0.8))).Put("lift", ((V)(2D))).V, ((V)(1000D)), ((V)(800D))), "fx", ((V)("pixdust")), ((V)("body")), ((V)(4D)));
}, 1, "", true), ((V)("giggle")), Arr(((V)("twirl")), ((V)((-1D))))));
Call(d_13, V.Undef, ((V)("floof")), Arr(Fn((V _arrowThis897, int _argc890, V t_896, V _a893, V _a894, V _a895, V[] _rest891) => {
Invoke(Invoke(Invoke(Invoke(t_896, "to", ((V)(200D)), NewObj(2).Put("fzz", ((V)(1D))).Put("sqz", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(9D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("l"))), "fx", ((V)("snow")), ((V)("body")), ((V)(4D))), "to", ((V)(400D)), NewObj(3).Put("fzz", ((V)(0D))).Put("sqz", ((V)(0D))).Put("hap", ((V)(0.7))).V);
return default;
}, 1, "", true), ((V)("stomp")), Fn((V _arrowThis905, int _argc898, V t_904, V _a901, V _a902, V _a903, V[] _rest899) => {
return Call(sp_12, V.Undef, t_904, NewObj(6).Put("open", ((V)(0.8))).Put("wide", ((V)(0.4))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("pitch", ((V)(0.2))).Put("fzz", ((V)(0.6))).V, ((V)(900D)), ((V)(500D)));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("unibun")), Arr(Fn((V _arrowThis913, int _argc906, V t_912, V _a909, V _a910, V _a911, V[] _rest907) => {
Invoke(Invoke(Invoke(Invoke(t_912, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.12)))).Put("close", ((V)(0.5))).V), "fx", ((V)("rainbow")), ((V)("head")), ((V)(5D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), ((V)("ears")), Fn((V _arrowThis921, int _argc914, V t_920, V _a917, V _a918, V _a919, V[] _rest915) => {
Invoke(Invoke(t_920, "osc", ((V)(1400D)), ((V)(4D)), NewObj(4).Put("footL", ((V)(2.8))).Put("footR", ((V)(0D))).Put("lift", ((V)(1D))).Put("pitch", ((V)((-0.05)))).V, NewObj(4).Put("footL", ((V)(0D))).Put("footR", ((V)(2.8))).Put("lift", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("gumdrop")), Arr(Fn((V _arrowThis929, int _argc922, V t_928, V _a925, V _a926, V _a927, V[] _rest923) => {
return Call(sp_12, V.Undef, t_928, NewObj(3).Put("jig", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(1000D)), ((V)(900D)));
}, 1, "", true), ((V)("bounce")), ((V)("wiggle"))));
Call(d_13, V.Undef, ((V)("ember")), Arr(Fn((V _arrowThis937, int _argc930, V t_936, V _a933, V _a934, V _a935, V[] _rest931) => {
return Invoke(Call(sp_12, V.Undef, t_936, NewObj(3).Put("cfl", ((V)(1D))).Put("hap", ((V)(0.6))).Put("wide", ((V)(0.3))).V, ((V)(1000D)), ((V)(900D))), "fx", ((V)("ember")), ((V)("head")), ((V)(4D)));
}, 1, "", true), Fn((V _arrowThis945, int _argc938, V t_944, V _a941, V _a942, V _a943, V[] _rest939) => {
Invoke(Invoke(t_944, "to", ((V)(160D)), NewObj(1).Put("hap", ((V)(0.8))).V), "osc", ((V)(1000D)), ((V)(6D)), NewObj(3).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("wfl", ((V)(1D))).V, NewObj(3).Put("armL", ((V)(4D))).Put("armR", ((V)(4D))).Put("wfl", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("shake"))));
Call(d_13, V.Undef, ((V)("drako")), Arr(Fn((V _arrowThis953, int _argc946, V t_952, V _a949, V _a950, V _a951, V[] _rest947) => {
Invoke(t_952, "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("tsw", ((V)(1D))).V, NewObj(1).Put("tsw", ((V)((-1D)))).V, ((V)("s")));
return default;
}, 1, "", true), Fn((V _arrowThis961, int _argc954, V t_960, V _a957, V _a958, V _a959, V[] _rest955) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_960, "to", ((V)(300D)), NewObj(1).Put("puff", ((V)(0.8))).V), "to", ((V)(150D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "fx", ((V)("dsmoke")), ((V)("nose")), ((V)(3D))), "to", ((V)(300D)), NewObj(3).Put("open", ((V)(0D))).Put("blush", ((V)(0.6))).Put("smile", ((V)(1D))).V), "wait", ((V)(500D)));
return default;
}, 1, "", true), Fn((V _arrowThis969, int _argc962, V t_968, V _a965, V _a966, V _a967, V[] _rest963) => {
return Call(sp_12, V.Undef, t_968, NewObj(5).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.8))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("hap", ((V)(0.6))).V, ((V)(1000D)), ((V)(700D)));
}, 1, "", true)));
Call(d_13, V.Undef, ((V)("jinni")), Arr(Fn((V _arrowThis977, int _argc970, V t_976, V _a973, V _a974, V _a975, V[] _rest971) => {
return Invoke(Call(sp_12, V.Undef, t_976, NewObj(4).Put("glo", ((V)(1D))).Put("gwh", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(1200D))), "fx", ((V)("jinni")), ((V)("body")), ((V)(4D)));
}, 1, "", true), Fn((V _arrowThis985, int _argc978, V t_984, V _a981, V _a982, V _a983, V[] _rest979) => {
Invoke(Invoke(t_984, "to", ((V)(400D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(12D)), ((V)((-8D)))), NewObj(3).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("close", ((V)(0.6))).V)), "wait", ((V)(1000D)));
return default;
}, 1, "", true), Fn((V _arrowThis993, int _argc986, V t_992, V _a989, V _a990, V _a991, V[] _rest987) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_992, "to", ((V)(700D)), NewObj(1).Put("gin", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(1).Put("gin", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("jinni")), ((V)("body")), ((V)(5D))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true)), NewObj(1).Put("skip", Arr(((V)("idle_yawn")))).V);
Call(d_13, V.Undef, ((V)("cuppy")), Arr(Fn((V _arrowThis1001, int _argc994, V t_1000, V _a997, V _a998, V _a999, V[] _rest995) => {
Invoke(Invoke(Invoke(t_1000, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "fx", ((V)("sprinkle")), ((V)("head"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("htilt", ((V)(6D))).V, NewObj(1).Put("htilt", ((V)((-6D)))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("wiggle")), Arr(((V)("hops")), ((V)(2D)))));
Call(d_13, V.Undef, ((V)("chip")), Arr(Fn((V _arrowThis1009, int _argc1002, V t_1008, V _a1005, V _a1006, V _a1007, V[] _rest1003) => {
Invoke(Invoke(t_1008, "osc", ((V)(800D)), ((V)(5D)), NewObj(1).Put("x", ((V)(0.7))).V, NewObj(1).Put("x", ((V)((-0.7)))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("body")), ((V)(4D)));
return default;
}, 1, "", true), ((V)("belly")), ((V)("rock"))));
Call(d_13, V.Undef, ((V)("twisty")), Arr(Fn((V _arrowThis1017, int _argc1010, V t_1016, V _a1013, V _a1014, V _a1015, V[] _rest1011) => {
Invoke(Invoke(Invoke(t_1016, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V), "osc", ((V)(1600D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("lean", ((V)(1.4))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("lean", ((V)((-1.4)))).V, ((V)("s"))), "fx", ((V)("salt")), ((V)("head")));
return default;
}, 1, "", true), ((V)("giggle")), ((V)("clap"))));
Call(d_13, V.Undef, ((V)("crois")), Arr(Fn((V _arrowThis1025, int _argc1018, V t_1024, V _a1021, V _a1022, V _a1023, V[] _rest1019) => {
Invoke(t_1024, "osc", ((V)(2600D)), ((V)(2D)), NewObj(3).Put("lean", ((V)(1.6))).Put("tilt", ((V)(3D))).Put("close", ((V)(0.5))).V, NewObj(3).Put("lean", ((V)((-1.6)))).Put("tilt", ((V)((-3D)))).Put("close", ((V)(0.2))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("stretch")), ((V)("hum"))));
Call(d_13, V.Undef, ((V)("maca")), Arr(Fn((V _arrowThis1033, int _argc1026, V t_1032, V _a1029, V _a1030, V _a1031, V[] _rest1027) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1032, "to", ((V)(100D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(2).Put("sq", ((V)((-0.06)))).Put("hap", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V), "wait", ((V)(200D))), "to", ((V)(100D)), NewObj(1).Put("sq", ((V)(0.1))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("wiggle")), ((V)("giggle"))));
Call(d_13, V.Undef, ((V)("puddi")), Arr(Fn((V _arrowThis1041, int _argc1034, V t_1040, V _a1037, V _a1038, V _a1039, V[] _rest1035) => {
Invoke(Invoke(t_1040, "osc", ((V)(1200D)), ((V)(8D)), NewObj(2).Put("sq", ((V)(0.06))).Put("x", ((V)(0.4))).V, NewObj(2).Put("sq", ((V)((-0.03)))).Put("x", ((V)((-0.4)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V);
return default;
}, 1, "", true), ((V)("hum")), ((V)("bounce"))));
Call(d_13, V.Undef, ((V)("mochi")), Arr(Fn((V _arrowThis1049, int _argc1042, V t_1048, V _a1045, V _a1046, V _a1047, V[] _rest1043) => {
Invoke(Invoke(Invoke(t_1048, "to", ((V)(700D)), NewObj(6).Put("sq", ((V)((-0.16)))).Put("lift", ((V)(1.6))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("close", ((V)(0.8))).Put("open", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(6).Put("sq", ((V)(0.18))).Put("lift", ((V)((-0.6)))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("bounce")), ((V)("giggle"))));
Call(d_13, V.Undef, ((V)("cakey")), Arr(Fn((V _arrowThis1057, int _argc1050, V t_1056, V _a1053, V _a1054, V _a1055, V[] _rest1051) => {
Invoke(Invoke(Invoke(Invoke(t_1056, "to", ((V)(400D)), NewObj(2).Put("puff", ((V)(0.9))).Put("pitch", ((V)((-0.1)))).V), "to", ((V)(500D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0.25))).Put("mw", ((V)(0.5))).Put("pitch", ((V)(0.1))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "wait", ((V)(400D)));
return default;
}, 1, "", true), Arr(((V)("twirl")), ((V)(1D))), ((V)("hum"))));
Call(d_13, V.Undef, ((V)("sugarplum")), Arr(Fn((V _arrowThis1065, int _argc1058, V t_1064, V _a1061, V _a1062, V _a1063, V[] _rest1059) => {
Invoke(Invoke(Invoke(t_1064, "to", ((V)(400D)), NewObj(5).Put("armR", ((V)(110D))).Put("hRy", ((V)((-2D)))).Put("smile", ((V)(1D))).Put("close", ((V)(0.4))).Put("htilt", ((V)(5D))).V, ((V)("o"))), "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-3D)))).V, NewObj(1).Put("hRx", ((V)(3D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("pawR")), ((V)(3D)));
return default;
}, 1, "", true), ((V)("curtsy")), Arr(((V)("twirl")), ((V)((-1D))))));
Call(d_13, V.Undef, ((V)("gourdy")), Arr(Fn((V _arrowThis1073, int _argc1066, V t_1072, V _a1069, V _a1070, V _a1071, V[] _rest1067) => {
Invoke(t_1072, "osc", ((V)(2400D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(7D))).Put("x", ((V)(1.6))).V, NewObj(2).Put("tilt", ((V)((-7D)))).Put("x", ((V)((-1.6)))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("hum")), ((V)("bounce"))));
Call(d_13, V.Undef, ((V)("batty")), Arr(Fn((V _arrowThis1081, int _argc1074, V t_1080, V _a1077, V _a1078, V _a1079, V[] _rest1075) => {
Invoke(Invoke(t_1080, "to", ((V)(400D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(14D)), ((V)((-2D)))), NewObj(4).Put("armL", ((V)(36D))).Put("armR", ((V)(36D))).Put("close", ((V)(0.5))).Put("smile", ((V)(0.8))).V)), "wait", ((V)(1400D)));
return default;
}, 1, "", true), ((V)("flap")), ((V)("ears"))));
Call(d_13, V.Undef, ((V)("kernel")), Arr(Fn((V _arrowThis1089, int _argc1082, V t_1088, V _a1085, V _a1086, V _a1087, V[] _rest1083) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_1088, "to", ((V)(300D)), NewObj(2).Put("sq", ((V)(0.12))).Put("wide", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(6).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(9D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("o"))), "fx", ((V)("crumb")), ((V)("head")), ((V)(4D))), "to", ((V)(260D)), NewObj(6).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.6))).V);
return default;
}, 1, "", true), Fn((V _arrowThis1097, int _argc1090, V t_1096, V _a1093, V _a1094, V _a1095, V[] _rest1091) => {
Invoke(t_1096, "osc", ((V)(1400D)), ((V)(4D)), NewObj(3).Put("x", ((V)(1D))).Put("footL", ((V)(2D))).Put("footR", ((V)(0D))).V, NewObj(3).Put("x", ((V)((-1D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("giggle"))));
Call(d_13, V.Undef, ((V)("hexie")), Arr(Fn((V _arrowThis1105, int _argc1098, V t_1104, V _a1101, V _a1102, V _a1103, V[] _rest1099) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_1104, "to", ((V)(300D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-18D)))), NewObj(2).Put("armR", ((V)(120D))).Put("htilt", ((V)(8D))).V), ((V)("o"))), "wait", ((V)(300D))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D))), "to", ((V)(300D)), NewObj(2).Put("winkR", ((V)(1D))).Put("smile", ((V)(1D))).V), "wait", ((V)(400D)));
return default;
}, 1, "", true), Arr(((V)("scratch")), ((V)(1D))), Arr(((V)("twirl")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("mumbles")), Arr(Fn((V _arrowThis1113, int _argc1106, V t_1112, V _a1109, V _a1110, V _a1111, V[] _rest1107) => {
Invoke(Invoke(t_1112, "to", ((V)(600D)), NewObj(6).Put("armL", ((V)(88D))).Put("armR", ((V)(88D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("close", ((V)(0.6))).Put("open", ((V)(0.25))).V, ((V)("io"))), "osc", ((V)(1400D)), ((V)(2D)), NewObj(1).Put("lean", ((V)(1.2))).V, NewObj(1).Put("lean", ((V)((-1.2)))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("stretch")), ((V)("giggle"))));
Call(d_13, V.Undef, ((V)("hocus")), Arr(Fn((V _arrowThis1121, int _argc1114, V t_1120, V _a1117, V _a1118, V _a1119, V[] _rest1115) => {
Invoke(Invoke(Invoke(Invoke(t_1120, "to", ((V)(400D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-4D)))), NewObj(3).Put("armR", ((V)(50D))).Put("ly", ((V)(0.6))).Put("close", ((V)(0.3))).V)), "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(800D))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
return default;
}, 1, "", true), ((V)("bow")), Arr(((V)("twirl")), ((V)(1D)))));
Call(d_13, V.Undef, ((V)("countsquishula")), Arr(Fn((V _arrowThis1129, int _argc1122, V t_1128, V _a1125, V _a1126, V _a1127, V[] _rest1123) => {
Invoke(Invoke(Invoke(Invoke(t_1128, "to", ((V)(300D)), Call(o_11, V.Undef, Call(hand_9, V.Undef, ((V)((-1D))), ((V)((-6D))), ((V)((-10D)))), NewObj(3).Put("armL", ((V)(90D))).Put("lean", ((V)((-1.2)))).Put("htilt", ((V)((-5D)))).V), ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(3).Put("smile", ((V)(1D))).Put("open", ((V)(0.2))).Put("winkL", ((V)(1D))).V), "wait", ((V)(500D)));
return default;
}, 1, "", true), ((V)("bow")), Fn((V _arrowThis1137, int _argc1130, V t_1136, V _a1133, V _a1134, V _a1135, V[] _rest1131) => {
Invoke(Invoke(t_1136, "to", ((V)(300D)), Call(o_11, V.Undef, Call(both_10, V.Undef, ((V)(6D)), ((V)((-6D)))), NewObj(6).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("pitch", ((V)(0.12))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(6D)), NewObj(2).Put("sq", ((V)(0.03))).Put("open", ((V)(0.6))).V, NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0.3))).V, ((V)("o")));
return default;
}, 1, "", true)));
return default;
}, 1, "", false));
        }
    }
}
