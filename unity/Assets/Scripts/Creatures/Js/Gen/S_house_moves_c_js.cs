// house-moves-c.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_house_moves_c_js
    {

        public static void Run()
        {
Set(G("window"), "HouseCreatures", (Get(G("window"), "HouseCreatures") is var _t1 && Truthy(_t1) ? _t1 : Arr()));
Invoke(Get(G("window"), "HouseCreatures"), "push", Fn((V _self2, int _argc3, V H_9, V _a6, V _a7, V _a8, V[] _rest4) => {
V build_10 = default;
V hand_11 = default;
V both_12 = default;
V o_13 = default;
V sp_14 = default;
V bk_15 = default;
V FL_16 = default;
V SEA_17 = default;
V hop_18 = default;
V flt_19 = default;
V sea_20 = default;
V mk_21 = default;
if (_self2.IsNullish) _self2 = GlobalV;
{ V _t22 = H_9;
if (_t22.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t22));
{ V _t23 = Get(_t22, "build");
build_10 = _t23; }
{ V _t24 = Get(_t22, "hand");
hand_11 = _t24; }
{ V _t25 = Get(_t22, "both");
both_12 = _t25; }
{ V _t26 = Get(_t22, "o");
o_13 = _t26; } }
sp_14 = Fn((V _self2, int _argc27, V t_33, V v_34, V d_35, V hold_36, V[] _rest28) => {
V ks_37 = default;
V b_38 = default;
ks_37 = Object_keys(v_34);
b_38 = NewObj(0).V;
Invoke(ks_37, "forEach", Fn((V _self2, int _argc39, V k_45, V _a42, V _a43, V _a44, V[] _rest40) => {
return SetK(b_38, k_45, (!GetK(Get(t_33, "B"), k_45).IsNullish ? GetK(Get(t_33, "B"), k_45) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_33, "to", ((V)((ToNum((d_35 is var _t48 && Truthy(_t48) ? _t48 : ((V)(700D)))) * 0.4))), v_34, ((V)("o"))), "wait", (hold_36 is var _t47 && Truthy(_t47) ? _t47 : ((V)(300D)))), "to", ((V)((ToNum((d_35 is var _t46 && Truthy(_t46) ? _t46 : ((V)(700D)))) * 0.6))), b_38, ((V)("io")));
return t_33;
return default;
}, 4, "", true);
bk_15 = Fn((V _self2, int _argc49, V t_55, V d_56, V _a53, V _a54, V[] _rest50) => {
return Invoke(t_55, "back", (d_56 is var _t57 && Truthy(_t57) ? _t57 : ((V)(420D))));
}, 2, "", true);
FL_16 = Call(o_13, V.Undef, NewObj(4).Put("sit", ((V)(0D))).Put("lift", ((V)(1.4))).Put("sq", ((V)(0.02))).Put("pitch", ((V)(0.04))).V, Call(both_12, V.Undef, ((V)(5D)), ((V)(1D))));
SEA_17 = Call(o_13, V.Undef, NewObj(4).Put("sit", ((V)(0D))).Put("lift", ((V)((-1.8)))).Put("sq", ((V)(0.13))).Put("pitch", ((V)(0.08))).V, Call(both_12, V.Undef, ((V)(5D)), ((V)(2D))));
hop_18 = NewObj(2).Put("dn", ((V)("hop"))).Put("up", ((V)("hop"))).V;
flt_19 = NewObj(4).Put("dn", ((V)("float"))).Put("up", ((V)("float"))).Put("pose", FL_16).Put("lpose", NewObj(4).Put("sit", ((V)(0D))).Put("lift", ((V)(0.4))).Put("sq", ((V)(0.06))).Put("tilt", ((V)((-5D)))).V).V;
sea_20 = NewObj(4).Put("dn", ((V)("flop"))).Put("up", ((V)("flop"))).Put("pose", SEA_17).Put("lpose", NewObj(1).Put("sit", ((V)(0D))).V).V;
mk_21 = Fn((V _self2, int _argc58, V key_64, V @base_65, V P_66, V _a63, V[] _rest59) => {
return Call(build_10, V.Undef, key_64, Call(o_13, V.Undef, @base_65, P_66, NewObj(2).Put("pose", Call(o_13, V.Undef, (Get(@base_65, "pose") is var _t67 && Truthy(_t67) ? _t67 : NewObj(0).V), (Get(P_66, "pose") is var _t68 && Truthy(_t68) ? _t68 : NewObj(0).V))).Put("lpose", Call(o_13, V.Undef, (Get(@base_65, "lpose") is var _t69 && Truthy(_t69) ? _t69 : NewObj(0).V), (Get(P_66, "lpose") is var _t70 && Truthy(_t70) ? _t70 : NewObj(0).V))).V));
}, 3, "", true);
Call(mk_21, V.Undef, ((V)("mittens")), hop_18, NewObj(3).Put("lpose", NewObj(2).Put("armL", ((V)(68D))).Put("armR", ((V)(68D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc71, V t_77, V _a74, V _a75, V _a76, V[] _rest72) => {
Invoke(Invoke(t_77, "to", ((V)(320D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(5D)), ((V)(8D))), NewObj(3).Put("close", ((V)(0.65))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.4))).V)), "osc", ((V)(2600D)), ((V)(6D)), NewObj(3).Put("hLy", ((V)(11D))).Put("hRy", ((V)(7D))).Put("sq", Add(Get(Get(t_77, "B"), "sq"), ((V)(0.012)))).V, NewObj(3).Put("hLy", ((V)(7D))).Put("hRy", ((V)(11D))).Put("sq", Get(Get(t_77, "B"), "sq")).V, ((V)("s")));
Call(bk_15, V.Undef, t_77);
return default;
}, 1, "", true), ((V)("swing")), ((V)("ears")), ((V)("yawn")))).Put("lf", Arr(((V)("sigh")), Fn((V _self2, int _argc78, V t_84, V _a81, V _a82, V _a83, V[] _rest79) => {
Call(sp_14, V.Undef, t_84, NewObj(4).Put("curl", ((V)(0.9))).Put("wag", ((V)(14D))).Put("close", ((V)(0.9))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
return default;
}, 1, "", true), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("biscuit")), hop_18, NewObj(4).Put("lpose", NewObj(2).Put("armL", ((V)(68D))).Put("armR", ((V)(68D))).V).Put("gap", Arr(((V)(1300D)), ((V)(2000D)), ((V)(1700D)), ((V)(2400D)))).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc85, V t_91, V _a88, V _a89, V _a90, V[] _rest86) => {
Invoke(Invoke(t_91, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(0.9))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V), "osc", ((V)(1600D)), ((V)(8D)), NewObj(2).Put("wag", ((V)(26D))).Put("lift", Add(Get(Get(t_91, "B"), "lift"), ((V)(0.7)))).V, NewObj(2).Put("wag", ((V)((-26D)))).Put("lift", Get(Get(t_91, "B"), "lift")).V, ((V)("o")));
Call(bk_15, V.Undef, t_91);
return default;
}, 1, "", true), Fn((V _self2, int _argc92, V t_98, V _a95, V _a96, V _a97, V[] _rest93) => {
Invoke(Invoke(t_98, "to", ((V)(360D)), NewObj(6).Put("footR", ((V)(6D))).Put("earR", ((V)(18D))).Put("sqz", ((V)(0.8))).Put("tilt", ((V)((-4D)))).Put("htilt", ((V)((-8D)))).Put("open", ((V)(0.2))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(6D)), NewObj(1).Put("footR", ((V)(7.5))).V, NewObj(1).Put("footR", ((V)(5.5))).V, ((V)("l")));
Call(bk_15, V.Undef, t_98, ((V)(360D)));
return default;
}, 1, "", true), ((V)("kick")), ((V)("pat")))).Put("lf", Arr(((V)("belly")), Fn((V _self2, int _argc99, V t_105, V _a102, V _a103, V _a104, V[] _rest100) => {
return Call(sp_14, V.Undef, t_105, NewObj(10).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("tilt", ((V)((-8D)))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("footL", ((V)(4D))).Put("footR", ((V)(4D))).V, ((V)(1300D)), ((V)(1800D)));
}, 1, "", true), ((V)("doze")), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("prickle")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("hLy", ((V)(2D))).Put("hRy", ((V)(2D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc106, V t_112, V _a109, V _a110, V _a111, V[] _rest107) => {
Invoke(Invoke(Invoke(Invoke(t_112, "to", ((V)(380D)), NewObj(5).Put("curl", ((V)(1D))).Put("sq", Add(Get(Get(t_112, "B"), "sq"), ((V)(0.14)))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V, ((V)("io"))), "wait", ((V)(1000D))), "to", ((V)(180D)), NewObj(3).Put("curl", ((V)(0D))).Put("sq", ((V)((ToNum(Get(Get(t_112, "B"), "sq")) - 0.05)))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_15, V.Undef, t_112);
return default;
}, 1, "", true), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc113, V t_119, V _a116, V _a117, V _a118, V[] _rest114) => {
return Call(sp_14, V.Undef, t_119, NewObj(2).Put("curl", ((V)(0.6))).Put("close", ((V)(0.9))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "", true), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("truffle")), hop_18, NewObj(3).Put("lpose", NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc120, V t_126, V _a123, V _a124, V _a125, V[] _rest121) => {
Invoke(Invoke(t_126, "to", ((V)(260D)), NewObj(3).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.4))).V), "osc", ((V)(1500D)), ((V)(6D)), NewObj(3).Put("tilt", ((V)(3D))).Put("wag", ((V)(22D))).Put("lift", Add(Get(Get(t_126, "B"), "lift"), ((V)(0.5)))).V, NewObj(3).Put("tilt", ((V)((-3D)))).Put("wag", ((V)((-22D)))).Put("lift", Get(Get(t_126, "B"), "lift")).V, ((V)("s")));
Call(bk_15, V.Undef, t_126);
return default;
}, 1, "", true), ((V)("ears")), ((V)("giggle")))).Put("lf", Arr(((V)("doze")), ((V)("belly")), Fn((V _self2, int _argc127, V t_133, V _a130, V _a131, V _a132, V[] _rest128) => {
return Call(sp_14, V.Undef, t_133, NewObj(4).Put("sq", Add(Get(Get(t_133, "B"), "sq"), ((V)(0.12)))).Put("smile", ((V)(1D))).Put("close", ((V)(0.8))).Put("blush", ((V)(0.6))).V, ((V)(1500D)), ((V)(1400D)));
}, 1, "", true), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("ribbit")), NewObj(3).Put("dn", ((V)("hop"))).Put("up", ((V)("hop"))).Put("pose", NewObj(2).Put("lift", ((V)((-1.2)))).Put("sq", ((V)(0.08))).V).V, NewObj(3).Put("lpose", NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc134, V t_140, V _a137, V _a138, V _a139, V[] _rest135) => {
{
V i_141 = default;
i_141 = ((V)(0D));
while (true) {
if (!(LtN(i_141, 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_140, "to", ((V)(110D)), NewObj(1).Put("sq", Add(Get(Get(t_140, "B"), "sq"), ((V)(0.12)))).V, ((V)("i"))), "to", ((V)(170D)), NewObj(4).Put("lift", Add(Get(Get(t_140, "B"), "lift"), ((V)(5D)))).Put("sq", ((V)((ToNum(Get(Get(t_140, "B"), "sq")) - 0.1)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", Get(Get(t_140, "B"), "lift")).Put("sq", Add(Get(Get(t_140, "B"), "sq"), ((V)(0.04)))).V, ((V)("i"))), "wait", ((V)(160D)));
PostInc(ref i_141, 1D);
}
}
Call(bk_15, V.Undef, t_140);
return default;
}, 1, "", true), ((V)("giggle")), ((V)("swing")))).Put("lf", Arr(((V)("doze")), ((V)("sigh")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("nibbles")), NewObj(2).Put("dn", ((V)("climb"))).Put("up", ((V)("hop"))).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc143, V t_149, V _a146, V _a147, V _a148, V[] _rest144) => {
Invoke(Invoke(Invoke(t_149, "to", ((V)(300D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(9D)), ((V)((-9D)))), NewObj(3).Put("puff", ((V)(1D))).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).V)), "osc", ((V)(1800D)), ((V)(6D)), NewObj(2).Put("open", ((V)(0.25))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("open", ((V)(0D))).Put("htilt", ((V)((-3D)))).V, ((V)("s"))), "fx", ((V)("crumb")), ((V)("head")));
Call(bk_15, V.Undef, t_149);
return default;
}, 1, "", true), ((V)("kick")), ((V)("ears")), ((V)("swing")))).Put("lf", Arr(((V)("doze")), Fn((V _self2, int _argc150, V t_156, V _a153, V _a154, V _a155, V[] _rest151) => {
return Call(sp_14, V.Undef, t_156, NewObj(3).Put("puff", ((V)(1D))).Put("smile", ((V)(1D))).Put("close", ((V)(0.8))).V, ((V)(1200D)), ((V)(1400D)));
}, 1, "", true), ((V)("belly")), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("quill")), hop_18, NewObj(4).Put("lpose", NewObj(6).Put("armL", ((V)(44D))).Put("armR", ((V)(44D))).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("hLy", ((V)(2D))).Put("hRy", ((V)(2D))).V).Put("gap", Arr(((V)(2200D)), ((V)(2800D)), ((V)(2000D)))).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc157, V t_163, V _a160, V _a161, V _a162, V[] _rest158) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_163, "to", ((V)(380D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(10D)), ((V)((-14D)))), NewObj(4).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("blush", ((V)(0.9))).Put("sq", Add(Get(Get(t_163, "B"), "sq"), ((V)(0.04)))).V)), "wait", ((V)(900D))), "to", ((V)(260D)), NewObj(3).Put("hLx", ((V)(4D))).Put("ly", ((V)(0.4))).Put("lx", ((V)((-0.6)))).V), "wait", ((V)(700D))), "to", ((V)(220D)), NewObj(1).Put("hLx", ((V)(10D))).V);
Call(bk_15, V.Undef, t_163, ((V)(480D)));
return default;
}, 1, "", true), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), Fn((V _self2, int _argc164, V t_170, V _a167, V _a168, V _a169, V[] _rest165) => {
return Call(sp_14, V.Undef, t_170, NewObj(3).Put("blush", ((V)(0.8))).Put("smile", ((V)(1D))).Put("htilt", ((V)(7D))).V, ((V)(1200D)), ((V)(1000D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("waffles")), NewObj(3).Put("dn", ((V)("flop"))).Put("up", ((V)("hop"))).Put("pose", NewObj(2).Put("lift", ((V)((-3.2)))).Put("sq", ((V)(0.15))).V).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc171, V t_177, V _a174, V _a175, V _a176, V[] _rest172) => {
Invoke(Invoke(t_177, "to", ((V)(500D)), NewObj(6).Put("sq", Add(Get(Get(t_177, "B"), "sq"), ((V)(0.1)))).Put("lift", ((V)((ToNum(Get(Get(t_177, "B"), "lift")) - 1.2)))).Put("close", ((V)(0.75))).Put("smile", ((V)(0.9))).Put("footL", ((V)((-1D)))).Put("footR", ((V)((-1D)))).V, ((V)("s"))), "wait", ((V)(1600D)));
Call(bk_15, V.Undef, t_177, ((V)(600D)));
return default;
}, 1, "", true), ((V)("wag")), ((V)("bounce")))).Put("lf", Arr(((V)("doze")), Fn((V _self2, int _argc178, V t_184, V _a181, V _a182, V _a183, V[] _rest179) => {
Invoke(Invoke(t_184, "to", ((V)(600D)), NewObj(3).Put("close", ((V)(1D))).Put("open", ((V)(0.15))).Put("pitch", ((V)((ToNum(Get(Get(t_184, "B"), "pitch")) - 0.1)))).V), "osc", ((V)(3000D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_184, "B"), "sq"), ((V)(0.05)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_184, "B"), "sq")) - 0.02)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_184);
return default;
}, 1, "", true), ((V)("sigh")), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("poppy")), NewObj(2).Put("dn", ((V)("spin"))).Put("up", ((V)("hop"))).V, NewObj(4).Put("lpose", NewObj(6).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("gap", Arr(((V)(1200D)), ((V)(2000D)), ((V)(1500D)))).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc185, V t_191, V _a188, V _a189, V _a190, V[] _rest186) => {
{
V i_192 = default;
i_192 = ((V)(0D));
while (true) {
if (!(LtN(i_192, 3D))) break;
Invoke(Invoke(Invoke(Invoke(t_191, "to", ((V)(110D)), NewObj(1).Put("sq", Add(Get(Get(t_191, "B"), "sq"), ((V)(0.1)))).V, ((V)("i"))), "to", ((V)(170D)), NewObj(6).Put("lift", Add(Get(Get(t_191, "B"), "lift"), ((V)(4D)))).Put("sq", ((V)((ToNum(Get(Get(t_191, "B"), "sq")) - 0.08)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.5))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(4).Put("lift", Get(Get(t_191, "B"), "lift")).Put("sq", Get(Get(t_191, "B"), "sq")).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i"))), "wait", ((V)(140D)));
PostInc(ref i_192, 1D);
}
}
Call(bk_15, V.Undef, t_191);
return default;
}, 1, "", true), ((V)("swing")), ((V)("ears")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("stretch")), Fn((V _self2, int _argc194, V t_200, V _a197, V _a198, V _a199, V[] _rest195) => {
return Call(sp_14, V.Undef, t_200, NewObj(3).Put("lift", Add(Get(Get(t_200, "B"), "lift"), ((V)(2D)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)(500D)), ((V)(100D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("duchess")), hop_18, NewObj(5).Put("pose", NewObj(1).Put("pitch", ((V)(0.16))).V).Put("lpose", NewObj(6).Put("armL", ((V)(38D))).Put("armR", ((V)(38D))).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("hLy", ((V)(2D))).Put("hRy", ((V)(2D))).V).Put("gap", Arr(((V)(2400D)), ((V)(3000D)), ((V)(2600D)))).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc201, V t_207, V _a204, V _a205, V _a206, V[] _rest202) => {
Invoke(Invoke(t_207, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-13D)))), NewObj(3).Put("armR", ((V)(34D))).Put("close", ((V)(0.7))).Put("htilt", ((V)(6D))).V)), "osc", ((V)(1600D)), ((V)(5D)), NewObj(2).Put("tongue", ((V)(0.6))).Put("hRy", ((V)((-15D)))).V, NewObj(2).Put("tongue", ((V)(0.1))).Put("hRy", ((V)((-12D)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_207);
return default;
}, 1, "", true), Fn((V _self2, int _argc208, V t_214, V _a211, V _a212, V _a213, V[] _rest209) => {
return Call(sp_14, V.Undef, t_214, NewObj(4).Put("htilt", ((V)(9D))).Put("close", ((V)(0.55))).Put("smile", ((V)(0.6))).Put("pitch", ((V)(0.28))).V, ((V)(1200D)), ((V)(1400D)));
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), Fn((V _self2, int _argc215, V t_221, V _a218, V _a219, V _a220, V[] _rest216) => {
Invoke(Invoke(t_221, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-6D)))), NewObj(1).Put("armR", ((V)(46D))).V)), "osc", ((V)(2400D)), ((V)(4D)), NewObj(2).Put("hRx", ((V)((-2D)))).Put("armR", ((V)(56D))).V, NewObj(2).Put("hRx", ((V)((-6D)))).Put("armR", ((V)(46D))).V, ((V)("s")));
Call(bk_15, V.Undef, t_221);
return default;
}, 1, "", true), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("mamapaws")), hop_18, NewObj(3).Put("lpose", Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(9D)), ((V)(5D))), NewObj(2).Put("armL", ((V)(14D))).Put("armR", ((V)(14D))).V)).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc222, V t_228, V _a225, V _a226, V _a227, V[] _rest223) => {
Invoke(Invoke(Invoke(t_228, "to", ((V)(300D)), NewObj(3).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.4))).V), "fx", ((V)("heart")), ((V)("head"))), "osc", ((V)(3200D)), ((V)(4D)), NewObj(2).Put("lean", ((V)(1.4))).Put("tilt", ((V)(2.4))).V, NewObj(2).Put("lean", ((V)((-1.4)))).Put("tilt", ((V)((-2.4)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_228);
return default;
}, 1, "", true), ((V)("wag")), ((V)("pat")), ((V)("yawn")))).Put("lf", Arr(((V)("doze")), ((V)("sigh")), ((V)("belly")), Fn((V _self2, int _argc229, V t_235, V _a232, V _a233, V _a234, V[] _rest230) => {
return Invoke(Call(sp_14, V.Undef, t_235, NewObj(3).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).Put("htilt", ((V)((-6D)))).V, ((V)(1400D)), ((V)(1400D))), "fx", ((V)("heart")), ((V)("head")));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("nimbo")), NewObj(3).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).Put("pose", NewObj(2).Put("sq", ((V)(0.15))).Put("lift", ((V)((-2.2)))).V).V, NewObj(4).Put("lpose", NewObj(6).Put("armL", ((V)(32D))).Put("armR", ((V)(32D))).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("hLy", ((V)(2D))).Put("hRy", ((V)(2D))).V).Put("gap", Arr(((V)(2000D)), ((V)(2600D)), ((V)(2200D)))).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc236, V t_242, V _a239, V _a240, V _a241, V[] _rest237) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_242, "to", ((V)(400D)), NewObj(2).Put("close", ((V)(0.6))).Put("smile", ((V)(0.5))).V), "fx", ((V)("drop")), ((V)("body")), ((V)(3D))), "wait", ((V)(700D))), "fx", ((V)("drop")), ((V)("body")), ((V)(3D))), "wait", ((V)(700D)));
Call(bk_15, V.Undef, t_242);
return default;
}, 1, "", true), ((V)("nod")), ((V)("wiggle")))).Put("lf", Arr(((V)("doze")), Fn((V _self2, int _argc243, V t_249, V _a246, V _a247, V _a248, V[] _rest244) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_249, "to", ((V)(500D)), NewObj(1).Put("close", ((V)(1D))).V), "fx", ((V)("drop")), ((V)("body")), ((V)(2D))), "wait", ((V)(900D))), "fx", ((V)("drop")), ((V)("body")), ((V)(2D))), "wait", ((V)(600D)));
Call(bk_15, V.Undef, t_249);
return default;
}, 1, "", true), ((V)("sigh")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("lumi")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc250, V t_256, V _a253, V _a254, V _a255, V[] _rest251) => {
Invoke(Invoke(Invoke(t_256, "to", ((V)(450D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-10D)))), NewObj(4).Put("armR", ((V)(80D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).Put("ly", ((V)((-0.6)))).V), ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(1300D)));
Call(bk_15, V.Undef, t_256, ((V)(520D)));
return default;
}, 1, "", true), ((V)("swing")), ((V)("ears")), ((V)("hum")))).Put("lf", Arr(((V)("doze")), Fn((V _self2, int _argc257, V t_263, V _a260, V _a261, V _a262, V[] _rest258) => {
return Invoke(Call(sp_14, V.Undef, t_263, NewObj(3).Put("armR", ((V)(40D))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(1400D))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
}, 1, "", true), ((V)("sigh")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("bubbly")), flt_19, NewObj(3).Put("gap", Arr(((V)(2200D)), ((V)(2600D)))).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc264, V t_270, V _a267, V _a268, V _a269, V[] _rest265) => {
Invoke(Invoke(t_270, "osc", ((V)(3000D)), ((V)(2D)), NewObj(2).Put("turn", ((V)(0.5))).Put("x", ((V)(1D))).V, NewObj(2).Put("turn", ((V)((-0.5)))).Put("x", ((V)((-1D)))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
Call(bk_15, V.Undef, t_270);
return default;
}, 1, "", true), ((V)("wiggle")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc271, V t_277, V _a274, V _a275, V _a276, V[] _rest272) => {
return Call(sp_14, V.Undef, t_277, NewObj(2).Put("sq", ((V)(0.1))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(800D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("twinkle")), hop_18, NewObj(3).Put("gap", Arr(((V)(1800D)), ((V)(2400D)), ((V)(2000D)))).Put("f", Arr(((V)("look")), ((V)("nod")), Fn((V _self2, int _argc278, V t_284, V _a281, V _a282, V _a283, V[] _rest279) => {
Invoke(Invoke(Invoke(Invoke(t_284, "to", ((V)(260D)), NewObj(3).Put("wide", ((V)(0.7))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("body")), ((V)(5D))), "wait", ((V)(500D))), "fx", ((V)("spark")), ((V)("body")), ((V)(4D)));
Call(bk_15, V.Undef, t_284);
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("doze")), ((V)("doze")), Fn((V _self2, int _argc285, V t_291, V _a288, V _a289, V _a290, V[] _rest286) => {
return Call(sp_14, V.Undef, t_291, NewObj(2).Put("close", ((V)(1D))).Put("open", ((V)(0.15))).V, ((V)(1500D)), ((V)(2200D)));
}, 1, "", true), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("zappi")), NewObj(2).Put("dn", ((V)("spin"))).Put("up", ((V)("hop"))).V, NewObj(3).Put("gap", Arr(((V)(1200D)), ((V)(1800D)), ((V)(1500D)))).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc292, V t_298, V _a295, V _a296, V _a297, V[] _rest293) => {
Invoke(Invoke(Invoke(Invoke(t_298, "to", ((V)(80D)), NewObj(3).Put("zap", ((V)(1D))).Put("wide", ((V)(1D))).Put("x", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(600D)), ((V)(6D)), NewObj(1).Put("x", ((V)((-0.8)))).V, NewObj(1).Put("x", ((V)(0.8))).V, ((V)("l"))), "fx", ((V)("spark")), ((V)("body")), ((V)(6D))), "to", ((V)(300D)), NewObj(3).Put("zap", ((V)(0D))).Put("wide", ((V)(0D))).Put("x", ((V)(0D))).V);
Call(bk_15, V.Undef, t_298);
return default;
}, 1, "", true), ((V)("kick")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), Fn((V _self2, int _argc299, V t_305, V _a302, V _a303, V _a304, V[] _rest300) => {
Invoke(Invoke(Invoke(t_305, "to", ((V)(80D)), NewObj(1).Put("zap", ((V)(0.6))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D))), "to", ((V)(400D)), NewObj(1).Put("zap", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("plip")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc306, V t_312, V _a309, V _a310, V _a311, V[] _rest307) => {
Invoke(Invoke(t_312, "fx", ((V)("drop")), ((V)("head")), ((V)(2D))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_312, "B"), "sq"), ((V)(0.07)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_312, "B"), "sq")) - 0.03)))).V, ((V)("o")));
Call(bk_15, V.Undef, t_312);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc313, V t_319, V _a316, V _a317, V _a318, V[] _rest314) => {
return Invoke(Call(sp_14, V.Undef, t_319, NewObj(2).Put("sq", Add(Get(Get(t_319, "B"), "sq"), ((V)(0.1)))).Put("close", ((V)(0.9))).V, ((V)(1400D)), ((V)(1000D))), "fx", ((V)("drop")), ((V)("body")), ((V)(2D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("breeze")), flt_19, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc320, V t_326, V _a323, V _a324, V _a325, V[] _rest321) => {
Invoke(Invoke(Invoke(Invoke(t_326, "to", ((V)(300D)), NewObj(3).Put("open", ((V)(0.5))).Put("puff", ((V)(0.6))).Put("lean", ((V)((-1.4)))).V), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(500D)), NewObj(3).Put("lean", ((V)(2D))).Put("open", ((V)(0.1))).Put("puff", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(400D)));
Call(bk_15, V.Undef, t_326);
return default;
}, 1, "", true), ((V)("hum")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc327, V t_333, V _a330, V _a331, V _a332, V[] _rest328) => {
return Invoke(Call(sp_14, V.Undef, t_333, NewObj(2).Put("lean", ((V)(2.4))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(900D))), "fx", ((V)("gust")), ((V)("head")));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("dusty")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), ((V)("ears")), Fn((V _self2, int _argc334, V t_340, V _a337, V _a338, V _a339, V[] _rest335) => {
Invoke(Invoke(Invoke(t_340, "fx", ((V)("dust")), ((V)("body")), ((V)(4D))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_340, "B"), "sq"), ((V)(0.05)))).V, NewObj(1).Put("sq", Get(Get(t_340, "B"), "sq")).V, ((V)("o"))), "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
Call(bk_15, V.Undef, t_340);
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("ears")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("aurora")), sea_20, NewObj(3).Put("gap", Arr(((V)(2200D)), ((V)(2800D)), ((V)(2400D)))).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc341, V t_347, V _a344, V _a345, V _a346, V[] _rest342) => {
Invoke(Invoke(Invoke(Invoke(t_347, "to", ((V)(300D)), NewObj(2).Put("spout", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D))), "wait", ((V)(900D))), "to", ((V)(400D)), NewObj(1).Put("spout", ((V)(0D))).V);
Call(bk_15, V.Undef, t_347);
return default;
}, 1, "", true), Fn((V _self2, int _argc348, V t_354, V _a351, V _a352, V _a353, V[] _rest349) => {
return Call(sp_14, V.Undef, t_354, NewObj(3).Put("glow", ((V)(1D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("doze")), Fn((V _self2, int _argc355, V t_361, V _a358, V _a359, V _a360, V[] _rest356) => {
return Call(sp_14, V.Undef, t_361, NewObj(2).Put("glow", ((V)(0.8))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(2000D)));
}, 1, "", true), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("mallow")), NewObj(2).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).V, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc362, V t_368, V _a365, V _a366, V _a367, V[] _rest363) => {
Invoke(Invoke(Invoke(t_368, "to", ((V)(1200D)), NewObj(4).Put("sq", Add(Get(Get(t_368, "B"), "sq"), ((V)(0.2)))).Put("lift", ((V)((ToNum(Get(Get(t_368, "B"), "lift")) - 1.6)))).Put("close", ((V)(0.85))).Put("smile", ((V)(1D))).V, ((V)("s"))), "wait", ((V)(800D))), "to", ((V)(220D)), NewObj(4).Put("sq", ((V)((ToNum(Get(Get(t_368, "B"), "sq")) - 0.08)))).Put("lift", Add(Get(Get(t_368, "B"), "lift"), ((V)(1D)))).Put("close", ((V)(0D))).Put("wide", ((V)(0.4))).V, ((V)("o")));
Call(bk_15, V.Undef, t_368);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc369, V t_375, V _a372, V _a373, V _a374, V[] _rest370) => {
return Call(sp_14, V.Undef, t_375, NewObj(2).Put("sq", Add(Get(Get(t_375, "B"), "sq"), ((V)(0.14)))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1200D)));
}, 1, "", true), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("bao")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc376, V t_382, V _a379, V _a380, V _a381, V[] _rest377) => {
Invoke(Invoke(Invoke(Invoke(t_382, "to", ((V)(500D)), NewObj(4).Put("sq", ((V)((ToNum(Get(Get(t_382, "B"), "sq")) - 0.07)))).Put("lift", Add(Get(Get(t_382, "B"), "lift"), ((V)(1.4)))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("head"))), "wait", ((V)(500D))), "fx", ((V)("steam")), ((V)("head")));
Call(bk_15, V.Undef, t_382, ((V)(600D)));
return default;
}, 1, "", true), ((V)("swing")), ((V)("bounce")))).Put("lf", Arr(((V)("sigh")), Fn((V _self2, int _argc383, V t_389, V _a386, V _a387, V _a388, V[] _rest384) => {
Invoke(Invoke(Invoke(t_389, "fx", ((V)("steam")), ((V)("head"))), "wait", ((V)(800D))), "fx", ((V)("steam")), ((V)("head")));
return default;
}, 1, "", true), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("dunkie")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc390, V t_396, V _a393, V _a394, V _a395, V[] _rest391) => {
Invoke(Invoke(Invoke(t_396, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("x", ((V)(1.1))).Put("tilt", ((V)(3D))).V, NewObj(2).Put("x", ((V)((-1.1)))).Put("tilt", ((V)((-3D)))).V, ((V)("s"))), "fx", ((V)("sprinkle")), ((V)("head")));
Call(bk_15, V.Undef, t_396);
return default;
}, 1, "", true), ((V)("kick")), ((V)("yawn")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("frybo")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc397, V t_403, V _a400, V _a401, V _a402, V[] _rest398) => {
return Call(sp_14, V.Undef, t_403, NewObj(3).Put("fw", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(900D)), ((V)(900D)));
}, 1, "", true), Fn((V _self2, int _argc404, V t_410, V _a407, V _a408, V _a409, V[] _rest405) => {
Invoke(Invoke(Invoke(t_410, "fx", ((V)("salt")), ((V)("head"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("l"))), "fx", ((V)("salt")), ((V)("head")));
Call(bk_15, V.Undef, t_410, ((V)(300D)));
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), Fn((V _self2, int _argc411, V t_417, V _a414, V _a415, V _a416, V[] _rest412) => {
return Call(sp_14, V.Undef, t_417, NewObj(2).Put("fw", ((V)(0.6))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "", true), ((V)("doze")), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("bunbun")), NewObj(2).Put("dn", ((V)("spin"))).Put("up", ((V)("hop"))).V, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc418, V t_424, V _a421, V _a422, V _a423, V[] _rest419) => {
Invoke(Invoke(Invoke(Invoke(t_424, "to", ((V)(300D)), NewObj(3).Put("split", ((V)(0.4))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(1).Put("shuf", ((V)(0.6))).V, NewObj(1).Put("shuf", ((V)((-0.6)))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(2).Put("split", ((V)(0D))).Put("shuf", ((V)(0D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(1).Put("sq", Add(Get(Get(t_424, "B"), "sq"), ((V)(0.06)))).V, ((V)("o")));
Call(bk_15, V.Undef, t_424);
return default;
}, 1, "", true), ((V)("kick")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc425, V t_431, V _a428, V _a429, V _a430, V[] _rest426) => {
return Call(sp_14, V.Undef, t_431, NewObj(2).Put("split", ((V)(0.2))).Put("close", ((V)(0.8))).V, ((V)(1200D)), ((V)(1000D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("choco")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc432, V t_438, V _a435, V _a436, V _a437, V[] _rest433) => {
return Call(sp_14, V.Undef, t_438, NewObj(3).Put("melt", ((V)(0.3))).Put("close", ((V)(0.75))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), Fn((V _self2, int _argc439, V t_445, V _a442, V _a443, V _a444, V[] _rest440) => {
return Call(sp_14, V.Undef, t_445, NewObj(3).Put("melt", ((V)(0.45))).Put("close", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)(2000D)), ((V)(1800D)));
}, 1, "", true), ((V)("doze")), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("scoop")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc446, V t_452, V _a449, V _a450, V _a451, V[] _rest447) => {
Invoke(t_452, "osc", ((V)(1400D)), ((V)(4D)), NewObj(2).Put("chb", ((V)(1D))).Put("hap", ((V)(0.7))).V, NewObj(2).Put("chb", ((V)(0D))).Put("hap", ((V)(0.4))).V, ((V)("o")));
Call(bk_15, V.Undef, t_452);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc453, V t_459, V _a456, V _a457, V _a458, V[] _rest454) => {
Invoke(t_459, "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("chb", ((V)(0.6))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("boba")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc460, V t_466, V _a463, V _a464, V _a465, V[] _rest461) => {
Invoke(Invoke(Invoke(Invoke(t_466, "to", ((V)(300D)), NewObj(4).Put("sqz", ((V)(0.6))).Put("open", ((V)(0.15))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.3)))).V), "osc", ((V)(1200D)), ((V)(6D)), NewObj(2).Put("x", ((V)(0.5))).Put("sq", Add(Get(Get(t_466, "B"), "sq"), ((V)(0.02)))).V, NewObj(2).Put("x", ((V)((-0.5)))).Put("sq", Get(Get(t_466, "B"), "sq")).V, ((V)("l"))), "to", ((V)(200D)), NewObj(5).Put("sqz", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(400D)));
Call(bk_15, V.Undef, t_466);
return default;
}, 1, "", true), ((V)("kick")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("chefbun")), hop_18, NewObj(4).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("pose", NewObj(1).Put("pitch", ((V)(0.1))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc467, V t_473, V _a470, V _a471, V _a472, V[] _rest468) => {
Invoke(Invoke(Invoke(Invoke(t_473, "to", ((V)(380D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-14D)))), NewObj(3).Put("armR", ((V)(36D))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V)), "wait", ((V)(300D))), "to", ((V)(260D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-6D))), ((V)((-16D)))), NewObj(3).Put("armR", ((V)(70D))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).V), ((V)("o"))), "fx", ((V)("heart")), ((V)("head")));
Call(bk_15, V.Undef, t_473);
return default;
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("pip")), NewObj(2).Put("dn", ((V)("slide"))).Put("up", ((V)("hop"))).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc474, V t_480, V _a477, V _a478, V _a479, V[] _rest475) => {
Invoke(Invoke(t_480, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(1000D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(42D))).Put("armR", ((V)(42D))).V, NewObj(2).Put("armL", ((V)(4D))).Put("armR", ((V)(4D))).V, ((V)("o")));
Call(bk_15, V.Undef, t_480);
return default;
}, 1, "", true), ((V)("kick")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc481, V t_487, V _a484, V _a485, V _a486, V[] _rest482) => {
Invoke(t_487, "osc", ((V)(1200D)), ((V)(3D)), NewObj(2).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).V, NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("jelli")), flt_19, NewObj(3).Put("gap", Arr(((V)(1800D)), ((V)(2400D)), ((V)(2000D)))).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc488, V t_494, V _a491, V _a492, V _a493, V[] _rest489) => {
{
V i_495 = default;
i_495 = ((V)(0D));
while (true) {
if (!(LtN(i_495, 3D))) break;
Invoke(Invoke(Invoke(t_494, "to", ((V)(240D)), NewObj(2).Put("sq", Add(Get(Get(t_494, "B"), "sq"), ((V)(0.1)))).Put("lift", ((V)((ToNum(Get(Get(t_494, "B"), "lift")) - 0.4)))).V, ((V)("i"))), "to", ((V)(420D)), NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_494, "B"), "sq")) - 0.08)))).Put("lift", Add(Get(Get(t_494, "B"), "lift"), ((V)(2D)))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(2).Put("sq", Get(Get(t_494, "B"), "sq")).Put("lift", Get(Get(t_494, "B"), "lift")).V, ((V)("s")));
PostInc(ref i_495, 1D);
}
}
Call(bk_15, V.Undef, t_494);
return default;
}, 1, "", true), ((V)("hum")), Arr(((V)("wave")), ((V)(1D))))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc497, V t_503, V _a500, V _a501, V _a502, V[] _rest498) => {
Invoke(t_503, "osc", ((V)(2400D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(Get(t_503, "B"), "sq"), ((V)(0.06)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_503, "B"), "sq")) - 0.04)))).V, ((V)("s")));
return default;
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("finn")), sea_20, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc504, V t_510, V _a507, V _a508, V _a509, V[] _rest505) => {
Invoke(Invoke(Invoke(t_510, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(900D)), ((V)(6D)), NewObj(1).Put("open", ((V)(0.5))).V, NewObj(1).Put("open", ((V)(0.1))).V, ((V)("l"))), "fx", ((V)("note")), ((V)("head")));
Call(bk_15, V.Undef, t_510);
return default;
}, 1, "", true), Fn((V _self2, int _argc511, V t_517, V _a514, V _a515, V _a516, V[] _rest512) => {
Invoke(Invoke(t_517, "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(28D))).V, NewObj(1).Put("wag", ((V)((-28D)))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)("body")), ((V)(4D)));
Call(bk_15, V.Undef, t_517);
return default;
}, 1, "", true), Arr(((V)("wave")), ((V)(1D))))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc518, V t_524, V _a521, V _a522, V _a523, V[] _rest519) => {
Invoke(t_524, "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("wag", ((V)(14D))).V, NewObj(1).Put("wag", ((V)((-14D)))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("sealy")), sea_20, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc525, V t_531, V _a528, V _a529, V _a530, V[] _rest526) => {
Invoke(Invoke(t_531, "to", ((V)(300D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(1D)), ((V)((-4D)))), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V)), "osc", ((V)(1200D)), ((V)(5D)), NewObj(3).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-1D)))).Put("open", ((V)(0.5))).V, NewObj(3).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-6D)))).Put("open", ((V)(0.1))).V, ((V)("o")));
Call(bk_15, V.Undef, t_531);
return default;
}, 1, "", true), ((V)("wiggle")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), Fn((V _self2, int _argc532, V t_538, V _a535, V _a536, V _a537, V[] _rest533) => {
return Call(sp_14, V.Undef, t_538, NewObj(3).Put("tilt", ((V)((-9D)))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("puff")), Call(o_13, V.Undef, flt_19, NewObj(1).Put("dn", ((V)("float"))).V), NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc539, V t_545, V _a542, V _a543, V _a544, V[] _rest540) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_545, "to", ((V)(500D)), NewObj(3).Put("blo", ((V)(0.55))).Put("puff", ((V)(0.6))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(700D))), "fx", ((V)("bubble")), ((V)("head"))), "to", ((V)(800D)), NewObj(3).Put("blo", ((V)(0D))).Put("puff", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("bubble")), ((V)("head")));
Call(bk_15, V.Undef, t_545);
return default;
}, 1, "", true), ((V)("hum")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc546, V t_552, V _a549, V _a550, V _a551, V[] _rest547) => {
return Call(sp_14, V.Undef, t_552, NewObj(2).Put("blo", ((V)(0.3))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("shelly")), NewObj(2).Put("dn", ((V)("climb"))).Put("up", ((V)("hop"))).V, NewObj(3).Put("gap", Arr(((V)(2000D)), ((V)(2800D)), ((V)(2200D)))).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc553, V t_559, V _a556, V _a557, V _a558, V[] _rest554) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_559, "to", ((V)(600D)), NewObj(2).Put("nk", ((V)(1D))).Put("ly", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(2).Put("lx", ((V)((-1D)))).Put("turn", ((V)((-0.3)))).V), "wait", ((V)(500D))), "to", ((V)(600D)), NewObj(2).Put("lx", ((V)(1D))).Put("turn", ((V)(0.3))).V), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(4).Put("lx", ((V)(0D))).Put("turn", ((V)(0D))).Put("nk", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Call(bk_15, V.Undef, t_559);
return default;
}, 1, "", true), Fn((V _self2, int _argc560, V t_566, V _a563, V _a564, V _a565, V[] _rest561) => {
Invoke(Invoke(Invoke(Invoke(t_566, "to", ((V)(400D)), NewObj(1).Put("hid", ((V)(0.75))).V, ((V)("io"))), "wait", ((V)(1200D))), "to", ((V)(260D)), NewObj(1).Put("hid", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_15, V.Undef, t_566);
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("doze")), Fn((V _self2, int _argc567, V t_573, V _a570, V _a571, V _a572, V[] _rest568) => {
Invoke(Invoke(Invoke(t_573, "to", ((V)(700D)), NewObj(1).Put("hid", ((V)(0.5))).V), "wait", ((V)(2400D))), "to", ((V)(400D)), NewObj(1).Put("hid", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("octo")), NewObj(3).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).Put("pose", NewObj(1).Put("sit", ((V)(0D))).V).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc574, V t_580, V _a577, V _a578, V _a579, V[] _rest575) => {
return Call(sp_14, V.Undef, t_580, NewObj(3).Put("ow", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), Fn((V _self2, int _argc581, V t_587, V _a584, V _a585, V _a586, V[] _rest582) => {
return Call(sp_14, V.Undef, t_587, NewObj(2).Put("ocl", ((V)(1D))).Put("close", ((V)(0.7))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc588, V t_594, V _a591, V _a592, V _a593, V[] _rest589) => {
return Call(sp_14, V.Undef, t_594, NewObj(2).Put("osp", ((V)(0.7))).Put("close", ((V)(0.8))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("marina")), NewObj(3).Put("dn", ((V)("slide"))).Put("up", ((V)("hop"))).Put("pose", NewObj(1).Put("sit", ((V)(0D))).V).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc595, V t_601, V _a598, V _a599, V _a600, V[] _rest596) => {
Invoke(Invoke(Invoke(Invoke(t_601, "to", ((V)(400D)), NewObj(2).Put("tlf", ((V)(0.8))).Put("tsw", ((V)(0.6))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)((-0.6)))).V, NewObj(1).Put("tsw", ((V)(0.6))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("body")), ((V)(4D))), "to", ((V)(400D)), NewObj(2).Put("tlf", ((V)(0D))).Put("tsw", ((V)(0D))).V);
Call(bk_15, V.Undef, t_601);
return default;
}, 1, "", true), Fn((V _self2, int _argc602, V t_608, V _a605, V _a606, V _a607, V[] _rest603) => {
return Call(sp_14, V.Undef, t_608, NewObj(4).Put("htilt", ((V)((-10D)))).Put("lean", ((V)((-1.4)))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1000D)), ((V)(600D)));
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc609, V t_615, V _a612, V _a613, V _a614, V[] _rest610) => {
return Call(sp_14, V.Undef, t_615, NewObj(2).Put("tlf", ((V)(0.5))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("pearl")), sea_20, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc616, V t_622, V _a619, V _a620, V _a621, V[] _rest617) => {
return Invoke(Call(sp_14, V.Undef, t_622, NewObj(3).Put("glow", ((V)(1D))).Put("wide", ((V)(0.3))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(1000D))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D)));
}, 1, "", true), Fn((V _self2, int _argc623, V t_629, V _a626, V _a627, V _a628, V[] _rest624) => {
return Call(sp_14, V.Undef, t_629, NewObj(3).Put("fflap", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(900D)));
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("doze")), Fn((V _self2, int _argc630, V t_636, V _a633, V _a634, V _a635, V[] _rest631) => {
return Call(sp_14, V.Undef, t_636, NewObj(2).Put("glow", ((V)(0.6))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1800D)));
}, 1, "", true), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("pina")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc637, V t_643, V _a640, V _a641, V _a642, V[] _rest638) => {
Invoke(Invoke(Invoke(t_643, "to", ((V)(220D)), NewObj(2).Put("crw", ((V)(1D))).Put("hap", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(1).Put("htilt", ((V)(6D))).V, NewObj(1).Put("htilt", ((V)((-6D)))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(1).Put("crw", ((V)(0D))).V);
Call(bk_15, V.Undef, t_643);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc644, V t_650, V _a647, V _a648, V _a649, V[] _rest645) => {
return Call(sp_14, V.Undef, t_650, NewObj(2).Put("crs", ((V)(0.6))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("avo")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc651, V t_657, V _a654, V _a655, V _a656, V[] _rest652) => {
Invoke(Invoke(Invoke(t_657, "to", ((V)(200D)), NewObj(3).Put("prw", ((V)(1D))).Put("pp", ((V)(0.35))).Put("wide", ((V)(0.4))).V, ((V)("o"))), "wait", ((V)(900D))), "to", ((V)(300D)), NewObj(3).Put("prw", ((V)(0D))).Put("pp", ((V)(0D))).Put("wide", ((V)(0D))).V);
Call(bk_15, V.Undef, t_657);
return default;
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("belly")), ((V)("doze")), Fn((V _self2, int _argc658, V t_664, V _a661, V _a662, V _a663, V[] _rest659) => {
return Call(sp_14, V.Undef, t_664, NewObj(2).Put("pr", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1000D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("berri")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc665, V t_671, V _a668, V _a669, V _a670, V[] _rest666) => {
Invoke(Invoke(t_671, "to", ((V)(120D)), NewObj(2).Put("stw", ((V)(1D))).Put("hap", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(900D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("bk")));
Call(bk_15, V.Undef, t_671);
return default;
}, 1, "", true), ((V)("kick")), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc672, V t_678, V _a675, V _a676, V _a677, V[] _rest673) => {
return Call(sp_14, V.Undef, t_678, NewObj(2).Put("lfl", ((V)(0.6))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("lemmy")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc679, V t_685, V _a682, V _a683, V _a684, V[] _rest680) => {
Invoke(Invoke(Invoke(Invoke(t_685, "to", ((V)(200D)), NewObj(4).Put("sqz", ((V)(1D))).Put("mw", ((V)(0.4))).Put("open", ((V)(0.12))).Put("frown", ((V)(0.4))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(7D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(5).Put("sqz", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("frown", ((V)(0D))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(300D)));
Call(bk_15, V.Undef, t_685);
return default;
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc686, V t_692, V _a689, V _a690, V _a691, V[] _rest687) => {
return Call(sp_14, V.Undef, t_692, NewObj(2).Put("lfl", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("kiwi")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc693, V t_699, V _a696, V _a697, V _a698, V[] _rest694) => {
Invoke(Invoke(Invoke(t_699, "to", ((V)(220D)), NewObj(2).Put("fzz", ((V)(1D))).Put("sqz", ((V)(0.6))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.7))).V, NewObj(1).Put("x", ((V)((-0.7)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(3).Put("fzz", ((V)(0D))).Put("sqz", ((V)(0D))).Put("hap", ((V)(0.6))).V);
Call(bk_15, V.Undef, t_699);
return default;
}, 1, "", true), ((V)("kick")), ((V)("ears")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc700, V t_706, V _a703, V _a704, V _a705, V[] _rest701) => {
return Call(sp_14, V.Undef, t_706, NewObj(2).Put("fzz", ((V)(0.4))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("melo")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc707, V t_713, V _a710, V _a711, V _a712, V[] _rest708) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_713, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.7))).Put("open", ((V)(0D))).V), "to", ((V)(120D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).Put("pitch", ((V)((ToNum(Get(Get(t_713, "B"), "pitch")) - 0.1)))).V, ((V)("o"))), "fx", ((V)("seed")), ((V)("head"))), "to", ((V)(300D)), NewObj(4).Put("open", ((V)(0D))).Put("pitch", Get(Get(t_713, "B"), "pitch")).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "wait", ((V)(400D)));
Call(bk_15, V.Undef, t_713);
return default;
}, 1, "", true), ((V)("swing")), Fn((V _self2, int _argc714, V t_720, V _a717, V _a718, V _a719, V[] _rest715) => {
Invoke(t_720, "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("sdj", ((V)(1D))).V, NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("peachy")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc721, V t_727, V _a724, V _a725, V _a726, V[] _rest722) => {
Invoke(Invoke(t_727, "to", ((V)(400D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(9D)), ((V)((-12D)))), NewObj(5).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("blush", ((V)(1D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V)), "osc", ((V)(1600D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(3D))).Put("htilt", ((V)(6D))).V, NewObj(2).Put("tilt", ((V)((-3D)))).Put("htilt", ((V)((-6D)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_727);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc728, V t_734, V _a731, V _a732, V _a733, V[] _rest729) => {
return Call(sp_14, V.Undef, t_734, NewObj(3).Put("blush", ((V)(0.9))).Put("lfl", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("pitaya")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc735, V t_741, V _a738, V _a739, V _a740, V[] _rest736) => {
return Invoke(Call(sp_14, V.Undef, t_741, NewObj(4).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.6))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(1000D))), "fx", ((V)("spark")), ((V)("body")), ((V)(4D)));
}, 1, "", true), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc742, V t_748, V _a745, V _a746, V _a747, V[] _rest743) => {
return Call(sp_14, V.Undef, t_748, NewObj(2).Put("wsp", ((V)(0.8))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("tutti")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc749, V t_755, V _a752, V _a753, V _a754, V[] _rest750) => {
Invoke(Invoke(Invoke(Invoke(t_755, "to", ((V)(300D)), NewObj(3).Put("fL", ((V)(1D))).Put("ly", ((V)((-0.8)))).Put("hap", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("fL", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(2).Put("fR", ((V)(1D))).Put("ly", ((V)((-0.8)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("fR", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("i")));
Call(bk_15, V.Undef, t_755);
return default;
}, 1, "", true), ((V)("swing")), Fn((V _self2, int _argc756, V t_762, V _a759, V _a760, V _a761, V[] _rest757) => {
return Invoke(Call(sp_14, V.Undef, t_762, NewObj(2).Put("wfl", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(900D))), "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc763, V t_769, V _a766, V _a767, V _a768, V[] _rest764) => {
return Call(sp_14, V.Undef, t_769, NewObj(2).Put("wfl", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("kiko")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc770, V t_776, V _a773, V _a774, V _a775, V[] _rest771) => {
Invoke(Invoke(Invoke(Invoke(t_776, "to", ((V)(300D)), NewObj(2).Put("htilt", ((V)((-10D)))).Put("lean", ((V)((-1.4)))).V), "to", ((V)(360D)), NewObj(4).Put("htilt", ((V)(9D))).Put("lean", ((V)(1.4))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(500D)));
Call(bk_15, V.Undef, t_776);
return default;
}, 1, "", true), ((V)("swing")), ((V)("ears")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("teddy")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc777, V t_783, V _a780, V _a781, V _a782, V[] _rest778) => {
Invoke(Invoke(Invoke(t_783, "to", ((V)(450D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(14D)), ((V)((-6D)))), NewObj(6).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).Put("blush", ((V)(0.6))).V)), "fx", ((V)("heart")), ((V)("head"))), "osc", ((V)(2000D)), ((V)(2D)), NewObj(2).Put("lean", ((V)(1.2))).Put("tilt", ((V)(2D))).V, NewObj(2).Put("lean", ((V)((-1.2)))).Put("tilt", ((V)((-2D)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_783, ((V)(500D)));
return default;
}, 1, "", true), ((V)("swing")), ((V)("ears")), ((V)("yawn")))).Put("lf", Arr(((V)("belly")), ((V)("doze")), ((V)("sigh")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("hoot")), hop_18, NewObj(3).Put("gap", Arr(((V)(1800D)), ((V)(2400D)), ((V)(2000D)))).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc784, V t_790, V _a787, V _a788, V _a789, V[] _rest785) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_790, "to", ((V)(600D)), NewObj(3).Put("turn", ((V)(0.85))).Put("lx", ((V)(1D))).Put("tfl", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(800D)), NewObj(2).Put("turn", ((V)((-0.85)))).Put("lx", ((V)((-1D)))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(3).Put("turn", ((V)(0D))).Put("lx", ((V)(0D))).Put("tfl", ((V)(0D))).V);
Call(bk_15, V.Undef, t_790);
return default;
}, 1, "", true), ((V)("nod")), Fn((V _self2, int _argc791, V t_797, V _a794, V _a795, V _a796, V[] _rest792) => {
return Call(sp_14, V.Undef, t_797, NewObj(2).Put("wfl", ((V)(1D))).Put("hap", ((V)(0.5))).V, ((V)(900D)), ((V)(500D)));
}, 1, "", true))).Put("lf", Arr(((V)("doze")), ((V)("sigh")), Fn((V _self2, int _argc798, V t_804, V _a801, V _a802, V _a803, V[] _rest799) => {
return Call(sp_14, V.Undef, t_804, NewObj(2).Put("tfl", ((V)(0.6))).Put("close", ((V)(1D))).V, ((V)(1400D)), ((V)(1400D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("leo")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc805, V t_811, V _a808, V _a809, V _a810, V[] _rest806) => {
Invoke(Invoke(Invoke(t_811, "to", ((V)(200D)), NewObj(2).Put("msh", ((V)(1D))).Put("mfl", ((V)(0.6))).V), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("htilt", ((V)(7D))).V, NewObj(1).Put("htilt", ((V)((-7D)))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(2).Put("msh", ((V)(0D))).Put("mfl", ((V)(0D))).V);
Call(bk_15, V.Undef, t_811);
return default;
}, 1, "", true), Fn((V _self2, int _argc812, V t_818, V _a815, V _a816, V _a817, V[] _rest813) => {
return Call(sp_14, V.Undef, t_818, NewObj(4).Put("open", ((V)(0.6))).Put("wide", ((V)(0.4))).Put("mfl", ((V)(0.8))).Put("pitch", Add(Get(Get(t_818, "B"), "pitch"), ((V)(0.15)))).V, ((V)(700D)), ((V)(400D)));
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("panko")), hop_18, NewObj(3).Put("pose", NewObj(1).Put("sq", ((V)(0.13))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc819, V t_825, V _a822, V _a823, V _a824, V[] _rest820) => {
Invoke(Invoke(Invoke(t_825, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(11D)), ((V)((-14D)))), NewObj(1).Put("armR", ((V)(34D))).V)), "osc", ((V)(2000D)), ((V)(7D)), NewObj(2).Put("open", ((V)(0.3))).Put("puff", ((V)(0.6))).V, NewObj(2).Put("open", ((V)(0.05))).Put("puff", ((V)(0.3))).V, ((V)("s"))), "fx", ((V)("crumb")), ((V)("head")));
Call(bk_15, V.Undef, t_825);
return default;
}, 1, "", true), ((V)("swing")), ((V)("bounce")))).Put("lf", Arr(((V)("doze")), ((V)("belly")), ((V)("sigh")), Fn((V _self2, int _argc826, V t_832, V _a829, V _a830, V _a831, V[] _rest827) => {
return Call(sp_14, V.Undef, t_832, NewObj(3).Put("tilt", ((V)((-10D)))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1500D)), ((V)(1200D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("acorn")), NewObj(2).Put("dn", ((V)("climb"))).Put("up", ((V)("hop"))).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc833, V t_839, V _a836, V _a837, V _a838, V[] _rest834) => {
Invoke(t_839, "osc", ((V)(1000D)), ((V)(4D)), NewObj(2).Put("tfl", ((V)(1D))).Put("tsw", ((V)(0.8))).V, NewObj(2).Put("tfl", ((V)(0.2))).Put("tsw", ((V)((-0.8)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_839);
return default;
}, 1, "", true), Fn((V _self2, int _argc840, V t_846, V _a843, V _a844, V _a845, V[] _rest841) => {
Invoke(Invoke(Invoke(t_846, "to", ((V)(300D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(9D)), ((V)((-11D)))), NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V)), "osc", ((V)(1400D)), ((V)(7D)), NewObj(1).Put("open", ((V)(0.25))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("head")));
Call(bk_15, V.Undef, t_846);
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc847, V t_853, V _a850, V _a851, V _a852, V[] _rest848) => {
return Call(sp_14, V.Undef, t_853, NewObj(2).Put("tsw", ((V)(0.6))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("fawn")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), ((V)("ears")), Fn((V _self2, int _argc854, V t_860, V _a857, V _a858, V _a859, V[] _rest855) => {
Invoke(Invoke(t_860, "osc", ((V)(700D)), ((V)(4D)), NewObj(2).Put("ly", ((V)((-0.2)))).Put("sq", Add(Get(Get(t_860, "B"), "sq"), ((V)(0.01)))).V, NewObj(2).Put("ly", ((V)(0D))).Put("sq", Get(Get(t_860, "B"), "sq")).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.5))).Put("smile", ((V)(1D))).V);
Call(bk_15, V.Undef, t_860);
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("ears")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("moss")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc861, V t_867, V _a864, V _a865, V _a866, V[] _rest862) => {
Invoke(Invoke(t_867, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("cb", ((V)(1D))).V, NewObj(1).Put("cb", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("dust")), ((V)("head")), ((V)(3D)));
Call(bk_15, V.Undef, t_867);
return default;
}, 1, "", true), ((V)("swing")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc868, V t_874, V _a871, V _a872, V _a873, V[] _rest869) => {
return Call(sp_14, V.Undef, t_874, NewObj(2).Put("csp", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1000D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("sprout")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc875, V t_881, V _a878, V _a879, V _a880, V[] _rest876) => {
return Invoke(Call(sp_14, V.Undef, t_881, NewObj(3).Put("blm", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
}, 1, "", true), ((V)("swing")), Fn((V _self2, int _argc882, V t_888, V _a885, V _a886, V _a887, V[] _rest883) => {
Invoke(t_888, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("stw", ((V)(1D))).V, NewObj(1).Put("stw", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc889, V t_895, V _a892, V _a893, V _a894, V[] _rest890) => {
return Call(sp_14, V.Undef, t_895, NewObj(2).Put("blm", ((V)(0.7))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("hana")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc896, V t_902, V _a899, V _a900, V _a901, V[] _rest897) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_902, "to", ((V)(300D)), NewObj(1).Put("flL", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(300D)), NewObj(2).Put("flL", ((V)(0D))).Put("flR", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(300D)), NewObj(1).Put("flR", ((V)(0D))).V);
Call(bk_15, V.Undef, t_902);
return default;
}, 1, "", true), ((V)("kick")), Fn((V _self2, int _argc903, V t_909, V _a906, V _a907, V _a908, V[] _rest904) => {
Invoke(t_909, "osc", ((V)(1000D)), ((V)(4D)), NewObj(1).Put("tw", ((V)(1D))).V, NewObj(1).Put("tw", ((V)((-1D)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_909);
return default;
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc910, V t_916, V _a913, V _a914, V _a915, V[] _rest911) => {
return Call(sp_14, V.Undef, t_916, NewObj(3).Put("flL", ((V)(0.8))).Put("flR", ((V)(0.8))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("boo")), flt_19, NewObj(3).Put("gap", Arr(((V)(2200D)), ((V)(2600D)), ((V)(2000D)))).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc917, V t_923, V _a920, V _a921, V _a922, V[] _rest918) => {
Invoke(Invoke(Invoke(Invoke(t_923, "to", ((V)(400D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(10D)), ((V)((-14D)))), NewObj(4).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("blush", ((V)(0.9))).Put("gho", ((V)(0.45))).V)), "wait", ((V)(900D))), "to", ((V)(400D)), NewObj(1).Put("gho", ((V)(0D))).V), "wait", ((V)(200D)));
Call(bk_15, V.Undef, t_923);
return default;
}, 1, "", true), Fn((V _self2, int _argc924, V t_930, V _a927, V _a928, V _a929, V[] _rest925) => {
return Call(sp_14, V.Undef, t_930, NewObj(2).Put("flr", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(600D)));
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc931, V t_937, V _a934, V _a935, V _a936, V[] _rest932) => {
return Call(sp_14, V.Undef, t_937, NewObj(2).Put("gho", ((V)(0.3))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1400D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("pixie")), Call(o_13, V.Undef, flt_19, NewObj(1).Put("dn", ((V)("float"))).V), NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc938, V t_944, V _a941, V _a942, V _a943, V[] _rest939) => {
return Invoke(Call(sp_14, V.Undef, t_944, NewObj(3).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.6))).Put("hap", ((V)(0.8))).V, ((V)(1000D)), ((V)(800D))), "fx", ((V)("dust")), ((V)("body")), ((V)(4D)));
}, 1, "", true), ((V)("giggle")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc945, V t_951, V _a948, V _a949, V _a950, V[] _rest946) => {
return Call(sp_14, V.Undef, t_951, NewObj(2).Put("wfl", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("floof")), hop_18, NewObj(4).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("pose", NewObj(1).Put("sq", ((V)(0.12))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc952, V t_958, V _a955, V _a956, V _a957, V[] _rest953) => {
Invoke(Invoke(Invoke(Invoke(t_958, "to", ((V)(200D)), NewObj(2).Put("fzz", ((V)(1D))).Put("sqz", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(9D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("l"))), "fx", ((V)("dust")), ((V)("body")), ((V)(4D))), "to", ((V)(400D)), NewObj(3).Put("fzz", ((V)(0D))).Put("sqz", ((V)(0D))).Put("hap", ((V)(0.7))).V);
Call(bk_15, V.Undef, t_958);
return default;
}, 1, "", true), ((V)("swing")), ((V)("bounce")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("unibun")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc959, V t_965, V _a962, V _a963, V _a964, V[] _rest960) => {
Invoke(Invoke(Invoke(Invoke(t_965, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((ToNum(Get(Get(t_965, "B"), "pitch")) - 0.12)))).Put("close", ((V)(0.5))).V), "fx", ((V)("spark")), ((V)("head")), ((V)(5D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(4).Put("pitch", Get(Get(t_965, "B"), "pitch")).Put("close", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V);
Call(bk_15, V.Undef, t_965);
return default;
}, 1, "", true), ((V)("ears")), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("ears")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("gumdrop")), NewObj(2).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc966, V t_972, V _a969, V _a970, V _a971, V[] _rest967) => {
return Call(sp_14, V.Undef, t_972, NewObj(3).Put("jig", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(1000D)), ((V)(900D)));
}, 1, "", true), ((V)("bounce")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc973, V t_979, V _a976, V _a977, V _a978, V[] _rest974) => {
return Call(sp_14, V.Undef, t_979, NewObj(2).Put("jig", ((V)(0.5))).Put("close", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("ember")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc980, V t_986, V _a983, V _a984, V _a985, V[] _rest981) => {
return Call(sp_14, V.Undef, t_986, NewObj(3).Put("cfl", ((V)(1D))).Put("hap", ((V)(0.6))).Put("wide", ((V)(0.3))).V, ((V)(1000D)), ((V)(900D)));
}, 1, "", true), ((V)("swing")), Fn((V _self2, int _argc987, V t_993, V _a990, V _a991, V _a992, V[] _rest988) => {
Invoke(Invoke(t_993, "to", ((V)(160D)), NewObj(1).Put("hap", ((V)(0.8))).V), "osc", ((V)(1000D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, NewObj(2).Put("armL", ((V)(4D))).Put("armR", ((V)(4D))).V, ((V)("o")));
Call(bk_15, V.Undef, t_993);
return default;
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc994, V t_1000, V _a997, V _a998, V _a999, V[] _rest995) => {
return Call(sp_14, V.Undef, t_1000, NewObj(2).Put("cfl", ((V)(0.4))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("drako")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1001, V t_1007, V _a1004, V _a1005, V _a1006, V[] _rest1002) => {
Invoke(t_1007, "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("tsw", ((V)(1D))).V, NewObj(1).Put("tsw", ((V)((-1D)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_1007);
return default;
}, 1, "", true), Fn((V _self2, int _argc1008, V t_1014, V _a1011, V _a1012, V _a1013, V[] _rest1009) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_1014, "to", ((V)(300D)), NewObj(1).Put("puff", ((V)(0.8))).V), "to", ((V)(150D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("head"))), "to", ((V)(300D)), NewObj(3).Put("open", ((V)(0D))).Put("blush", ((V)(0.6))).Put("smile", ((V)(1D))).V), "wait", ((V)(500D)));
Call(bk_15, V.Undef, t_1014);
return default;
}, 1, "", true), ((V)("swing")), Fn((V _self2, int _argc1015, V t_1021, V _a1018, V _a1019, V _a1020, V[] _rest1016) => {
return Call(sp_14, V.Undef, t_1021, NewObj(2).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.5))).V, ((V)(900D)), ((V)(600D)));
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc1022, V t_1028, V _a1025, V _a1026, V _a1027, V[] _rest1023) => {
return Call(sp_14, V.Undef, t_1028, NewObj(2).Put("tcu", ((V)(0.5))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("jinni")), flt_19, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1029, V t_1035, V _a1032, V _a1033, V _a1034, V[] _rest1030) => {
return Invoke(Call(sp_14, V.Undef, t_1035, NewObj(4).Put("glo", ((V)(1D))).Put("gwh", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(1200D))), "fx", ((V)("spark")), ((V)("body")), ((V)(4D)));
}, 1, "", true), Fn((V _self2, int _argc1036, V t_1042, V _a1039, V _a1040, V _a1041, V[] _rest1037) => {
Invoke(Invoke(t_1042, "to", ((V)(400D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(12D)), ((V)((-8D)))), NewObj(3).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("close", ((V)(0.6))).V)), "wait", ((V)(1000D)));
Call(bk_15, V.Undef, t_1042);
return default;
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc1043, V t_1049, V _a1046, V _a1047, V _a1048, V[] _rest1044) => {
return Call(sp_14, V.Undef, t_1049, NewObj(2).Put("glo", ((V)(0.6))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("cuppy")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1050, V t_1056, V _a1053, V _a1054, V _a1055, V[] _rest1051) => {
Invoke(Invoke(Invoke(t_1056, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "fx", ((V)("sprinkle")), ((V)("head"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("htilt", ((V)(6D))).V, NewObj(1).Put("htilt", ((V)((-6D)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_1056);
return default;
}, 1, "", true), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("chip")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1057, V t_1063, V _a1060, V _a1061, V _a1062, V[] _rest1058) => {
Invoke(Invoke(t_1063, "osc", ((V)(800D)), ((V)(5D)), NewObj(1).Put("x", ((V)(0.7))).V, NewObj(1).Put("x", ((V)((-0.7)))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("body")), ((V)(4D)));
Call(bk_15, V.Undef, t_1063, ((V)(300D)));
return default;
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("twisty")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1064, V t_1070, V _a1067, V _a1068, V _a1069, V[] _rest1065) => {
Invoke(Invoke(Invoke(t_1070, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V), "osc", ((V)(1600D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("lean", ((V)(1.4))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("lean", ((V)((-1.4)))).V, ((V)("s"))), "fx", ((V)("salt")), ((V)("head")));
Call(bk_15, V.Undef, t_1070);
return default;
}, 1, "", true), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("crois")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1071, V t_1077, V _a1074, V _a1075, V _a1076, V[] _rest1072) => {
Invoke(t_1077, "osc", ((V)(2600D)), ((V)(2D)), NewObj(3).Put("lean", ((V)(1.6))).Put("tilt", ((V)(3D))).Put("close", ((V)(0.5))).V, NewObj(3).Put("lean", ((V)((-1.6)))).Put("tilt", ((V)((-3D)))).Put("close", ((V)(0.2))).V, ((V)("s")));
Call(bk_15, V.Undef, t_1077);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("maca")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1078, V t_1084, V _a1081, V _a1082, V _a1083, V[] _rest1079) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1084, "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_1084, "B"), "sq"), ((V)(0.12)))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_1084, "B"), "sq")) - 0.06)))).Put("hap", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_1084, "B"), "sq")).V), "wait", ((V)(200D))), "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_1084, "B"), "sq"), ((V)(0.1)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", Get(Get(t_1084, "B"), "sq")).V);
Call(bk_15, V.Undef, t_1084);
return default;
}, 1, "", true), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("puddi")), NewObj(2).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).V, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1085, V t_1091, V _a1088, V _a1089, V _a1090, V[] _rest1086) => {
Invoke(Invoke(t_1091, "osc", ((V)(1200D)), ((V)(8D)), NewObj(2).Put("sq", Add(Get(Get(t_1091, "B"), "sq"), ((V)(0.06)))).Put("x", ((V)(0.4))).V, NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_1091, "B"), "sq")) - 0.03)))).Put("x", ((V)((-0.4)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V);
Call(bk_15, V.Undef, t_1091);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc1092, V t_1098, V _a1095, V _a1096, V _a1097, V[] _rest1093) => {
Invoke(t_1098, "osc", ((V)(1600D)), ((V)(4D)), NewObj(1).Put("sq", Add(Get(Get(t_1098, "B"), "sq"), ((V)(0.04)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_1098, "B"), "sq")) - 0.02)))).V, ((V)("s")));
return default;
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("mochi")), NewObj(2).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).V, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1099, V t_1105, V _a1102, V _a1103, V _a1104, V[] _rest1100) => {
Invoke(Invoke(Invoke(t_1105, "to", ((V)(700D)), NewObj(6).Put("sq", ((V)((ToNum(Get(Get(t_1105, "B"), "sq")) - 0.16)))).Put("lift", Add(Get(Get(t_1105, "B"), "lift"), ((V)(1.6)))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("close", ((V)(0.8))).Put("open", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(6).Put("sq", Add(Get(Get(t_1105, "B"), "sq"), ((V)(0.18)))).Put("lift", ((V)((ToNum(Get(Get(t_1105, "B"), "lift")) - 0.6)))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_1105, "B"), "sq")) - 0.03)))).V, ((V)("o")));
Call(bk_15, V.Undef, t_1105);
return default;
}, 1, "", true), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc1106, V t_1112, V _a1109, V _a1110, V _a1111, V[] _rest1107) => {
return Call(sp_14, V.Undef, t_1112, NewObj(2).Put("sq", Add(Get(Get(t_1112, "B"), "sq"), ((V)(0.12)))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("cakey")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1113, V t_1119, V _a1116, V _a1117, V _a1118, V[] _rest1114) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_1119, "to", ((V)(400D)), NewObj(2).Put("puff", ((V)(0.9))).Put("pitch", ((V)((ToNum(Get(Get(t_1119, "B"), "pitch")) - 0.1)))).V), "to", ((V)(500D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0.25))).Put("mw", ((V)(0.5))).Put("pitch", Add(Get(Get(t_1119, "B"), "pitch"), ((V)(0.1)))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(300D)), NewObj(5).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", Get(Get(t_1119, "B"), "pitch")).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "wait", ((V)(400D)));
Call(bk_15, V.Undef, t_1119);
return default;
}, 1, "", true), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("sugarplum")), hop_18, NewObj(3).Put("pose", NewObj(1).Put("pitch", ((V)(0.12))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1120, V t_1126, V _a1123, V _a1124, V _a1125, V[] _rest1121) => {
Invoke(Invoke(Invoke(t_1126, "to", ((V)(400D)), NewObj(5).Put("armR", ((V)(110D))).Put("hRy", ((V)((-2D)))).Put("smile", ((V)(1D))).Put("close", ((V)(0.4))).Put("htilt", ((V)(5D))).V, ((V)("o"))), "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-3D)))).V, NewObj(1).Put("hRx", ((V)(3D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(bk_15, V.Undef, t_1126);
return default;
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("gourdy")), NewObj(2).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1127, V t_1133, V _a1130, V _a1131, V _a1132, V[] _rest1128) => {
Invoke(t_1133, "osc", ((V)(2400D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(7D))).Put("x", ((V)(1.6))).V, NewObj(2).Put("tilt", ((V)((-7D)))).Put("x", ((V)((-1.6)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_1133);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), Fn((V _self2, int _argc1134, V t_1140, V _a1137, V _a1138, V _a1139, V[] _rest1135) => {
return Call(sp_14, V.Undef, t_1140, NewObj(2).Put("tilt", ((V)((-9D)))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("batty")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1141, V t_1147, V _a1144, V _a1145, V _a1146, V[] _rest1142) => {
Invoke(Invoke(t_1147, "to", ((V)(400D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(14D)), ((V)((-2D)))), NewObj(4).Put("armL", ((V)(36D))).Put("armR", ((V)(36D))).Put("close", ((V)(0.5))).Put("smile", ((V)(0.8))).V)), "wait", ((V)(1400D)));
Call(bk_15, V.Undef, t_1147, ((V)(500D)));
return default;
}, 1, "", true), Fn((V _self2, int _argc1148, V t_1154, V _a1151, V _a1152, V _a1153, V[] _rest1149) => {
Invoke(Invoke(t_1154, "to", ((V)(160D)), NewObj(1).Put("hap", ((V)(0.7))).V), "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, NewObj(2).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("o")));
Call(bk_15, V.Undef, t_1154);
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("doze")), ((V)("sigh")), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("kernel")), NewObj(2).Put("dn", ((V)("climb"))).Put("up", ((V)("hop"))).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1155, V t_1161, V _a1158, V _a1159, V _a1160, V[] _rest1156) => {
Invoke(t_1161, "osc", ((V)(1400D)), ((V)(4D)), NewObj(3).Put("x", ((V)(1D))).Put("footL", ((V)(2D))).Put("footR", ((V)(0D))).V, NewObj(3).Put("x", ((V)((-1D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).V, ((V)("s")));
Call(bk_15, V.Undef, t_1161);
return default;
}, 1, "", true), ((V)("kick")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("hexie")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1162, V t_1168, V _a1165, V _a1166, V _a1167, V[] _rest1163) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_1168, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-18D)))), NewObj(2).Put("armR", ((V)(120D))).Put("htilt", ((V)(8D))).V), ((V)("o"))), "wait", ((V)(300D))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D))), "to", ((V)(300D)), NewObj(2).Put("winkR", ((V)(1D))).Put("smile", ((V)(1D))).V), "wait", ((V)(400D)));
Call(bk_15, V.Undef, t_1168);
return default;
}, 1, "", true), ((V)("ears")), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _self2, int _argc1169, V t_1175, V _a1172, V _a1173, V _a1174, V[] _rest1170) => {
return Call(sp_14, V.Undef, t_1175, NewObj(2).Put("curl", ((V)(0.7))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("mumbles")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1176, V t_1182, V _a1179, V _a1180, V _a1181, V[] _rest1177) => {
Invoke(Invoke(t_1182, "to", ((V)(600D)), NewObj(6).Put("armL", ((V)(88D))).Put("armR", ((V)(88D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("close", ((V)(0.6))).Put("open", ((V)(0.25))).V, ((V)("io"))), "osc", ((V)(1400D)), ((V)(2D)), NewObj(1).Put("lean", ((V)(1.2))).V, NewObj(1).Put("lean", ((V)((-1.2)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_1182, ((V)(600D)));
return default;
}, 1, "", true), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("hocus")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1183, V t_1189, V _a1186, V _a1187, V _a1188, V[] _rest1184) => {
Invoke(Invoke(Invoke(Invoke(t_1189, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-4D)))), NewObj(3).Put("armR", ((V)(50D))).Put("ly", ((V)(0.6))).Put("close", ((V)(0.3))).V)), "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(800D))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
Call(bk_15, V.Undef, t_1189);
return default;
}, 1, "", true), ((V)("nod")), ((V)("swing")))).Put("lf", Arr(((V)("doze")), ((V)("sigh")), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("countsquishula")), hop_18, NewObj(3).Put("pose", NewObj(1).Put("pitch", ((V)(0.12))).V).Put("f", Arr(((V)("look")), Fn((V _self2, int _argc1190, V t_1196, V _a1193, V _a1194, V _a1195, V[] _rest1191) => {
Invoke(Invoke(Invoke(Invoke(t_1196, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)((-1D))), ((V)((-6D))), ((V)((-10D)))), NewObj(3).Put("armL", ((V)(90D))).Put("lean", ((V)((-1.2)))).Put("htilt", ((V)((-5D)))).V), ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(3).Put("smile", ((V)(1D))).Put("open", ((V)(0.2))).Put("winkL", ((V)(1D))).V), "wait", ((V)(500D)));
Call(bk_15, V.Undef, t_1196);
return default;
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
return default;
}, 1, "", false));
        }
    }
}
