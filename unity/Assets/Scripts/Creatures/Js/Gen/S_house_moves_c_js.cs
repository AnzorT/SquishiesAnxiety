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
sp_14 = Fn((V _arrowThis37, int _argc27, V t_33, V v_34, V d_35, V hold_36, V[] _rest28) => {
V ks_38 = default;
V b_39 = default;
ks_38 = Object_keys(v_34);
b_39 = NewObj(0).V;
Invoke(ks_38, "forEach", Fn((V _arrowThis47, int _argc40, V k_46, V _a43, V _a44, V _a45, V[] _rest41) => {
return SetK(b_39, k_46, (!GetK(Get(t_33, "B"), k_46).IsNullish ? GetK(Get(t_33, "B"), k_46) : ((V)(0D))));
}, 1, "", true));
Invoke(Invoke(Invoke(t_33, "to", ((V)((ToNum((d_35 is var _t50 && Truthy(_t50) ? _t50 : ((V)(700D)))) * 0.4))), v_34, ((V)("o"))), "wait", (hold_36 is var _t49 && Truthy(_t49) ? _t49 : ((V)(300D)))), "to", ((V)((ToNum((d_35 is var _t48 && Truthy(_t48) ? _t48 : ((V)(700D)))) * 0.6))), b_39, ((V)("io")));
return t_33;
return default;
}, 4, "", true);
bk_15 = Fn((V _arrowThis59, int _argc51, V t_57, V d_58, V _a55, V _a56, V[] _rest52) => {
return Invoke(t_57, "back", (d_58 is var _t60 && Truthy(_t60) ? _t60 : ((V)(420D))));
}, 2, "", true);
FL_16 = Call(o_13, V.Undef, NewObj(4).Put("sit", ((V)(0D))).Put("lift", ((V)(1.4))).Put("sq", ((V)(0.02))).Put("pitch", ((V)(0.04))).V, Call(both_12, V.Undef, ((V)(5D)), ((V)(1D))));
SEA_17 = Call(o_13, V.Undef, NewObj(4).Put("sit", ((V)(0D))).Put("lift", ((V)((-1.8)))).Put("sq", ((V)(0.13))).Put("pitch", ((V)(0.08))).V, Call(both_12, V.Undef, ((V)(5D)), ((V)(2D))));
hop_18 = NewObj(2).Put("dn", ((V)("hop"))).Put("up", ((V)("hop"))).V;
flt_19 = NewObj(4).Put("dn", ((V)("float"))).Put("up", ((V)("float"))).Put("pose", FL_16).Put("lpose", NewObj(4).Put("sit", ((V)(0D))).Put("lift", ((V)(0.4))).Put("sq", ((V)(0.06))).Put("tilt", ((V)((-5D)))).V).V;
sea_20 = NewObj(4).Put("dn", ((V)("flop"))).Put("up", ((V)("flop"))).Put("pose", SEA_17).Put("lpose", NewObj(1).Put("sit", ((V)(0D))).V).V;
mk_21 = Fn((V _arrowThis70, int _argc61, V key_67, V @base_68, V P_69, V _a66, V[] _rest62) => {
return Call(build_10, V.Undef, key_67, Call(o_13, V.Undef, @base_68, P_69, NewObj(2).Put("pose", Call(o_13, V.Undef, (Get(@base_68, "pose") is var _t71 && Truthy(_t71) ? _t71 : NewObj(0).V), (Get(P_69, "pose") is var _t72 && Truthy(_t72) ? _t72 : NewObj(0).V))).Put("lpose", Call(o_13, V.Undef, (Get(@base_68, "lpose") is var _t73 && Truthy(_t73) ? _t73 : NewObj(0).V), (Get(P_69, "lpose") is var _t74 && Truthy(_t74) ? _t74 : NewObj(0).V))).V));
}, 3, "", true);
Call(mk_21, V.Undef, ((V)("mittens")), hop_18, NewObj(3).Put("lpose", NewObj(2).Put("armL", ((V)(68D))).Put("armR", ((V)(68D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis82, int _argc75, V t_81, V _a78, V _a79, V _a80, V[] _rest76) => {
Invoke(Invoke(t_81, "to", ((V)(320D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(5D)), ((V)(8D))), NewObj(3).Put("close", ((V)(0.65))).Put("smile", ((V)(0.9))).Put("hap", ((V)(0.4))).V)), "osc", ((V)(2600D)), ((V)(6D)), NewObj(3).Put("hLy", ((V)(11D))).Put("hRy", ((V)(7D))).Put("sq", Add(Get(Get(t_81, "B"), "sq"), ((V)(0.012)))).V, NewObj(3).Put("hLy", ((V)(7D))).Put("hRy", ((V)(11D))).Put("sq", Get(Get(t_81, "B"), "sq")).V, ((V)("s")));
Call(bk_15, V.Undef, t_81);
return default;
}, 1, "", true), ((V)("swing")), ((V)("ears")), ((V)("yawn")))).Put("lf", Arr(((V)("sigh")), Fn((V _arrowThis90, int _argc83, V t_89, V _a86, V _a87, V _a88, V[] _rest84) => {
Call(sp_14, V.Undef, t_89, NewObj(4).Put("curl", ((V)(0.9))).Put("wag", ((V)(14D))).Put("close", ((V)(0.9))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
return default;
}, 1, "", true), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("biscuit")), hop_18, NewObj(4).Put("lpose", NewObj(2).Put("armL", ((V)(68D))).Put("armR", ((V)(68D))).V).Put("gap", Arr(((V)(1300D)), ((V)(2000D)), ((V)(1700D)), ((V)(2400D)))).Put("f", Arr(((V)("look")), Fn((V _arrowThis98, int _argc91, V t_97, V _a94, V _a95, V _a96, V[] _rest92) => {
Invoke(Invoke(t_97, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(0.9))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V), "osc", ((V)(1600D)), ((V)(8D)), NewObj(2).Put("wag", ((V)(26D))).Put("lift", Add(Get(Get(t_97, "B"), "lift"), ((V)(0.7)))).V, NewObj(2).Put("wag", ((V)((-26D)))).Put("lift", Get(Get(t_97, "B"), "lift")).V, ((V)("o")));
Call(bk_15, V.Undef, t_97);
return default;
}, 1, "", true), Fn((V _arrowThis106, int _argc99, V t_105, V _a102, V _a103, V _a104, V[] _rest100) => {
Invoke(Invoke(t_105, "to", ((V)(360D)), NewObj(6).Put("footR", ((V)(6D))).Put("earR", ((V)(18D))).Put("sqz", ((V)(0.8))).Put("tilt", ((V)((-4D)))).Put("htilt", ((V)((-8D)))).Put("open", ((V)(0.2))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(6D)), NewObj(1).Put("footR", ((V)(7.5))).V, NewObj(1).Put("footR", ((V)(5.5))).V, ((V)("l")));
Call(bk_15, V.Undef, t_105, ((V)(360D)));
return default;
}, 1, "", true), ((V)("kick")), ((V)("pat")))).Put("lf", Arr(((V)("belly")), Fn((V _arrowThis114, int _argc107, V t_113, V _a110, V _a111, V _a112, V[] _rest108) => {
return Call(sp_14, V.Undef, t_113, NewObj(10).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("tilt", ((V)((-8D)))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("footL", ((V)(4D))).Put("footR", ((V)(4D))).V, ((V)(1300D)), ((V)(1800D)));
}, 1, "", true), ((V)("doze")), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("prickle")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("hLy", ((V)(2D))).Put("hRy", ((V)(2D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis122, int _argc115, V t_121, V _a118, V _a119, V _a120, V[] _rest116) => {
Invoke(Invoke(Invoke(Invoke(t_121, "to", ((V)(380D)), NewObj(5).Put("curl", ((V)(1D))).Put("sq", Add(Get(Get(t_121, "B"), "sq"), ((V)(0.14)))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V, ((V)("io"))), "wait", ((V)(1000D))), "to", ((V)(180D)), NewObj(3).Put("curl", ((V)(0D))).Put("sq", ((V)((ToNum(Get(Get(t_121, "B"), "sq")) - 0.05)))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_15, V.Undef, t_121);
return default;
}, 1, "", true), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis130, int _argc123, V t_129, V _a126, V _a127, V _a128, V[] _rest124) => {
return Call(sp_14, V.Undef, t_129, NewObj(2).Put("curl", ((V)(0.6))).Put("close", ((V)(0.9))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "", true), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("truffle")), hop_18, NewObj(3).Put("lpose", NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis138, int _argc131, V t_137, V _a134, V _a135, V _a136, V[] _rest132) => {
Invoke(Invoke(t_137, "to", ((V)(260D)), NewObj(3).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).Put("sqz", ((V)(0.4))).V), "osc", ((V)(1500D)), ((V)(6D)), NewObj(3).Put("tilt", ((V)(3D))).Put("wag", ((V)(22D))).Put("lift", Add(Get(Get(t_137, "B"), "lift"), ((V)(0.5)))).V, NewObj(3).Put("tilt", ((V)((-3D)))).Put("wag", ((V)((-22D)))).Put("lift", Get(Get(t_137, "B"), "lift")).V, ((V)("s")));
Call(bk_15, V.Undef, t_137);
return default;
}, 1, "", true), ((V)("ears")), ((V)("giggle")))).Put("lf", Arr(((V)("doze")), ((V)("belly")), Fn((V _arrowThis146, int _argc139, V t_145, V _a142, V _a143, V _a144, V[] _rest140) => {
return Call(sp_14, V.Undef, t_145, NewObj(4).Put("sq", Add(Get(Get(t_145, "B"), "sq"), ((V)(0.12)))).Put("smile", ((V)(1D))).Put("close", ((V)(0.8))).Put("blush", ((V)(0.6))).V, ((V)(1500D)), ((V)(1400D)));
}, 1, "", true), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("ribbit")), NewObj(3).Put("dn", ((V)("hop"))).Put("up", ((V)("hop"))).Put("pose", NewObj(2).Put("lift", ((V)((-1.2)))).Put("sq", ((V)(0.08))).V).V, NewObj(3).Put("lpose", NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis154, int _argc147, V t_153, V _a150, V _a151, V _a152, V[] _rest148) => {
{
double i_155 = 0;
i_155 = 0D;
while (true) {
if (!((i_155 < 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_153, "to", ((V)(110D)), NewObj(1).Put("sq", Add(Get(Get(t_153, "B"), "sq"), ((V)(0.12)))).V, ((V)("i"))), "to", ((V)(170D)), NewObj(4).Put("lift", Add(Get(Get(t_153, "B"), "lift"), ((V)(5D)))).Put("sq", ((V)((ToNum(Get(Get(t_153, "B"), "sq")) - 0.1)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("lift", Get(Get(t_153, "B"), "lift")).Put("sq", Add(Get(Get(t_153, "B"), "sq"), ((V)(0.04)))).V, ((V)("i"))), "wait", ((V)(160D)));
i_155++;
}
}
Call(bk_15, V.Undef, t_153);
return default;
}, 1, "", true), ((V)("giggle")), ((V)("swing")))).Put("lf", Arr(((V)("doze")), ((V)("sigh")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("nibbles")), NewObj(2).Put("dn", ((V)("climb"))).Put("up", ((V)("hop"))).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis164, int _argc157, V t_163, V _a160, V _a161, V _a162, V[] _rest158) => {
Invoke(Invoke(Invoke(t_163, "to", ((V)(300D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(9D)), ((V)((-9D)))), NewObj(3).Put("puff", ((V)(1D))).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).V)), "osc", ((V)(1800D)), ((V)(6D)), NewObj(2).Put("open", ((V)(0.25))).Put("htilt", ((V)(3D))).V, NewObj(2).Put("open", ((V)(0D))).Put("htilt", ((V)((-3D)))).V, ((V)("s"))), "fx", ((V)("crumb")), ((V)("head")));
Call(bk_15, V.Undef, t_163);
return default;
}, 1, "", true), ((V)("kick")), ((V)("ears")), ((V)("swing")))).Put("lf", Arr(((V)("doze")), Fn((V _arrowThis172, int _argc165, V t_171, V _a168, V _a169, V _a170, V[] _rest166) => {
return Call(sp_14, V.Undef, t_171, NewObj(3).Put("puff", ((V)(1D))).Put("smile", ((V)(1D))).Put("close", ((V)(0.8))).V, ((V)(1200D)), ((V)(1400D)));
}, 1, "", true), ((V)("belly")), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("quill")), hop_18, NewObj(4).Put("lpose", NewObj(6).Put("armL", ((V)(44D))).Put("armR", ((V)(44D))).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("hLy", ((V)(2D))).Put("hRy", ((V)(2D))).V).Put("gap", Arr(((V)(2200D)), ((V)(2800D)), ((V)(2000D)))).Put("f", Arr(((V)("look")), Fn((V _arrowThis180, int _argc173, V t_179, V _a176, V _a177, V _a178, V[] _rest174) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_179, "to", ((V)(380D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(10D)), ((V)((-14D)))), NewObj(4).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("blush", ((V)(0.9))).Put("sq", Add(Get(Get(t_179, "B"), "sq"), ((V)(0.04)))).V)), "wait", ((V)(900D))), "to", ((V)(260D)), NewObj(3).Put("hLx", ((V)(4D))).Put("ly", ((V)(0.4))).Put("lx", ((V)((-0.6)))).V), "wait", ((V)(700D))), "to", ((V)(220D)), NewObj(1).Put("hLx", ((V)(10D))).V);
Call(bk_15, V.Undef, t_179, ((V)(480D)));
return default;
}, 1, "", true), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), Fn((V _arrowThis188, int _argc181, V t_187, V _a184, V _a185, V _a186, V[] _rest182) => {
return Call(sp_14, V.Undef, t_187, NewObj(3).Put("blush", ((V)(0.8))).Put("smile", ((V)(1D))).Put("htilt", ((V)(7D))).V, ((V)(1200D)), ((V)(1000D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("waffles")), NewObj(3).Put("dn", ((V)("flop"))).Put("up", ((V)("hop"))).Put("pose", NewObj(2).Put("lift", ((V)((-3.2)))).Put("sq", ((V)(0.15))).V).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis196, int _argc189, V t_195, V _a192, V _a193, V _a194, V[] _rest190) => {
Invoke(Invoke(t_195, "to", ((V)(500D)), NewObj(6).Put("sq", Add(Get(Get(t_195, "B"), "sq"), ((V)(0.1)))).Put("lift", ((V)((ToNum(Get(Get(t_195, "B"), "lift")) - 1.2)))).Put("close", ((V)(0.75))).Put("smile", ((V)(0.9))).Put("footL", ((V)((-1D)))).Put("footR", ((V)((-1D)))).V, ((V)("s"))), "wait", ((V)(1600D)));
Call(bk_15, V.Undef, t_195, ((V)(600D)));
return default;
}, 1, "", true), ((V)("wag")), ((V)("bounce")))).Put("lf", Arr(((V)("doze")), Fn((V _arrowThis204, int _argc197, V t_203, V _a200, V _a201, V _a202, V[] _rest198) => {
Invoke(Invoke(t_203, "to", ((V)(600D)), NewObj(3).Put("close", ((V)(1D))).Put("open", ((V)(0.15))).Put("pitch", ((V)((ToNum(Get(Get(t_203, "B"), "pitch")) - 0.1)))).V), "osc", ((V)(3000D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_203, "B"), "sq"), ((V)(0.05)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_203, "B"), "sq")) - 0.02)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_203);
return default;
}, 1, "", true), ((V)("sigh")), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("poppy")), NewObj(2).Put("dn", ((V)("spin"))).Put("up", ((V)("hop"))).V, NewObj(4).Put("lpose", NewObj(6).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("gap", Arr(((V)(1200D)), ((V)(2000D)), ((V)(1500D)))).Put("f", Arr(((V)("look")), Fn((V _arrowThis212, int _argc205, V t_211, V _a208, V _a209, V _a210, V[] _rest206) => {
{
double i_213 = 0;
i_213 = 0D;
while (true) {
if (!((i_213 < 3D))) break;
Invoke(Invoke(Invoke(Invoke(t_211, "to", ((V)(110D)), NewObj(1).Put("sq", Add(Get(Get(t_211, "B"), "sq"), ((V)(0.1)))).V, ((V)("i"))), "to", ((V)(170D)), NewObj(6).Put("lift", Add(Get(Get(t_211, "B"), "lift"), ((V)(4D)))).Put("sq", ((V)((ToNum(Get(Get(t_211, "B"), "sq")) - 0.08)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.5))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(4).Put("lift", Get(Get(t_211, "B"), "lift")).Put("sq", Get(Get(t_211, "B"), "sq")).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i"))), "wait", ((V)(140D)));
i_213++;
}
}
Call(bk_15, V.Undef, t_211);
return default;
}, 1, "", true), ((V)("swing")), ((V)("ears")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("stretch")), Fn((V _arrowThis222, int _argc215, V t_221, V _a218, V _a219, V _a220, V[] _rest216) => {
return Call(sp_14, V.Undef, t_221, NewObj(3).Put("lift", Add(Get(Get(t_221, "B"), "lift"), ((V)(2D)))).Put("hap", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)(500D)), ((V)(100D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("duchess")), hop_18, NewObj(5).Put("pose", NewObj(1).Put("pitch", ((V)(0.16))).V).Put("lpose", NewObj(6).Put("armL", ((V)(38D))).Put("armR", ((V)(38D))).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("hLy", ((V)(2D))).Put("hRy", ((V)(2D))).V).Put("gap", Arr(((V)(2400D)), ((V)(3000D)), ((V)(2600D)))).Put("f", Arr(((V)("look")), Fn((V _arrowThis230, int _argc223, V t_229, V _a226, V _a227, V _a228, V[] _rest224) => {
Invoke(Invoke(t_229, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(9D)), ((V)((-13D)))), NewObj(3).Put("armR", ((V)(34D))).Put("close", ((V)(0.7))).Put("htilt", ((V)(6D))).V)), "osc", ((V)(1600D)), ((V)(5D)), NewObj(2).Put("tongue", ((V)(0.6))).Put("hRy", ((V)((-15D)))).V, NewObj(2).Put("tongue", ((V)(0.1))).Put("hRy", ((V)((-12D)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_229);
return default;
}, 1, "", true), Fn((V _arrowThis238, int _argc231, V t_237, V _a234, V _a235, V _a236, V[] _rest232) => {
return Call(sp_14, V.Undef, t_237, NewObj(4).Put("htilt", ((V)(9D))).Put("close", ((V)(0.55))).Put("smile", ((V)(0.6))).Put("pitch", ((V)(0.28))).V, ((V)(1200D)), ((V)(1400D)));
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), Fn((V _arrowThis246, int _argc239, V t_245, V _a242, V _a243, V _a244, V[] _rest240) => {
Invoke(Invoke(t_245, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-6D)))), NewObj(1).Put("armR", ((V)(46D))).V)), "osc", ((V)(2400D)), ((V)(4D)), NewObj(2).Put("hRx", ((V)((-2D)))).Put("armR", ((V)(56D))).V, NewObj(2).Put("hRx", ((V)((-6D)))).Put("armR", ((V)(46D))).V, ((V)("s")));
Call(bk_15, V.Undef, t_245);
return default;
}, 1, "", true), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("mamapaws")), hop_18, NewObj(3).Put("lpose", Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(9D)), ((V)(5D))), NewObj(2).Put("armL", ((V)(14D))).Put("armR", ((V)(14D))).V)).Put("f", Arr(((V)("look")), Fn((V _arrowThis254, int _argc247, V t_253, V _a250, V _a251, V _a252, V[] _rest248) => {
Invoke(Invoke(Invoke(t_253, "to", ((V)(300D)), NewObj(3).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.4))).V), "fx", ((V)("heart")), ((V)("head"))), "osc", ((V)(3200D)), ((V)(4D)), NewObj(2).Put("lean", ((V)(1.4))).Put("tilt", ((V)(2.4))).V, NewObj(2).Put("lean", ((V)((-1.4)))).Put("tilt", ((V)((-2.4)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_253);
return default;
}, 1, "", true), ((V)("wag")), ((V)("pat")), ((V)("yawn")))).Put("lf", Arr(((V)("doze")), ((V)("sigh")), ((V)("belly")), Fn((V _arrowThis262, int _argc255, V t_261, V _a258, V _a259, V _a260, V[] _rest256) => {
return Invoke(Call(sp_14, V.Undef, t_261, NewObj(3).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).Put("htilt", ((V)((-6D)))).V, ((V)(1400D)), ((V)(1400D))), "fx", ((V)("heart")), ((V)("head")));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("nimbo")), NewObj(3).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).Put("pose", NewObj(2).Put("sq", ((V)(0.15))).Put("lift", ((V)((-2.2)))).V).V, NewObj(4).Put("lpose", NewObj(6).Put("armL", ((V)(32D))).Put("armR", ((V)(32D))).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("hLy", ((V)(2D))).Put("hRy", ((V)(2D))).V).Put("gap", Arr(((V)(2000D)), ((V)(2600D)), ((V)(2200D)))).Put("f", Arr(((V)("look")), Fn((V _arrowThis270, int _argc263, V t_269, V _a266, V _a267, V _a268, V[] _rest264) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_269, "to", ((V)(400D)), NewObj(2).Put("close", ((V)(0.6))).Put("smile", ((V)(0.5))).V), "fx", ((V)("drop")), ((V)("body")), ((V)(3D))), "wait", ((V)(700D))), "fx", ((V)("drop")), ((V)("body")), ((V)(3D))), "wait", ((V)(700D)));
Call(bk_15, V.Undef, t_269);
return default;
}, 1, "", true), ((V)("nod")), ((V)("wiggle")))).Put("lf", Arr(((V)("doze")), Fn((V _arrowThis278, int _argc271, V t_277, V _a274, V _a275, V _a276, V[] _rest272) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_277, "to", ((V)(500D)), NewObj(1).Put("close", ((V)(1D))).V), "fx", ((V)("drop")), ((V)("body")), ((V)(2D))), "wait", ((V)(900D))), "fx", ((V)("drop")), ((V)("body")), ((V)(2D))), "wait", ((V)(600D)));
Call(bk_15, V.Undef, t_277);
return default;
}, 1, "", true), ((V)("sigh")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("lumi")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis286, int _argc279, V t_285, V _a282, V _a283, V _a284, V[] _rest280) => {
Invoke(Invoke(Invoke(t_285, "to", ((V)(450D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(2D)), ((V)((-10D)))), NewObj(4).Put("armR", ((V)(80D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).Put("ly", ((V)((-0.6)))).V), ((V)("io"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(1300D)));
Call(bk_15, V.Undef, t_285, ((V)(520D)));
return default;
}, 1, "", true), ((V)("swing")), ((V)("ears")), ((V)("hum")))).Put("lf", Arr(((V)("doze")), Fn((V _arrowThis294, int _argc287, V t_293, V _a290, V _a291, V _a292, V[] _rest288) => {
return Invoke(Call(sp_14, V.Undef, t_293, NewObj(3).Put("armR", ((V)(40D))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(1400D))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
}, 1, "", true), ((V)("sigh")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("bubbly")), flt_19, NewObj(3).Put("gap", Arr(((V)(2200D)), ((V)(2600D)))).Put("f", Arr(((V)("look")), Fn((V _arrowThis302, int _argc295, V t_301, V _a298, V _a299, V _a300, V[] _rest296) => {
Invoke(Invoke(t_301, "osc", ((V)(3000D)), ((V)(2D)), NewObj(2).Put("turn", ((V)(0.5))).Put("x", ((V)(1D))).V, NewObj(2).Put("turn", ((V)((-0.5)))).Put("x", ((V)((-1D)))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
Call(bk_15, V.Undef, t_301);
return default;
}, 1, "", true), ((V)("wiggle")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis310, int _argc303, V t_309, V _a306, V _a307, V _a308, V[] _rest304) => {
return Call(sp_14, V.Undef, t_309, NewObj(2).Put("sq", ((V)(0.1))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(800D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("twinkle")), hop_18, NewObj(3).Put("gap", Arr(((V)(1800D)), ((V)(2400D)), ((V)(2000D)))).Put("f", Arr(((V)("look")), ((V)("nod")), Fn((V _arrowThis318, int _argc311, V t_317, V _a314, V _a315, V _a316, V[] _rest312) => {
Invoke(Invoke(Invoke(Invoke(t_317, "to", ((V)(260D)), NewObj(3).Put("wide", ((V)(0.7))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("body")), ((V)(5D))), "wait", ((V)(500D))), "fx", ((V)("spark")), ((V)("body")), ((V)(4D)));
Call(bk_15, V.Undef, t_317);
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("doze")), ((V)("doze")), Fn((V _arrowThis326, int _argc319, V t_325, V _a322, V _a323, V _a324, V[] _rest320) => {
return Call(sp_14, V.Undef, t_325, NewObj(2).Put("close", ((V)(1D))).Put("open", ((V)(0.15))).V, ((V)(1500D)), ((V)(2200D)));
}, 1, "", true), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("zappi")), NewObj(2).Put("dn", ((V)("spin"))).Put("up", ((V)("hop"))).V, NewObj(3).Put("gap", Arr(((V)(1200D)), ((V)(1800D)), ((V)(1500D)))).Put("f", Arr(((V)("look")), Fn((V _arrowThis334, int _argc327, V t_333, V _a330, V _a331, V _a332, V[] _rest328) => {
Invoke(Invoke(Invoke(Invoke(t_333, "to", ((V)(80D)), NewObj(3).Put("zap", ((V)(1D))).Put("wide", ((V)(1D))).Put("x", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(600D)), ((V)(6D)), NewObj(1).Put("x", ((V)((-0.8)))).V, NewObj(1).Put("x", ((V)(0.8))).V, ((V)("l"))), "fx", ((V)("spark")), ((V)("body")), ((V)(6D))), "to", ((V)(300D)), NewObj(3).Put("zap", ((V)(0D))).Put("wide", ((V)(0D))).Put("x", ((V)(0D))).V);
Call(bk_15, V.Undef, t_333);
return default;
}, 1, "", true), ((V)("kick")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), Fn((V _arrowThis342, int _argc335, V t_341, V _a338, V _a339, V _a340, V[] _rest336) => {
Invoke(Invoke(Invoke(t_341, "to", ((V)(80D)), NewObj(1).Put("zap", ((V)(0.6))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D))), "to", ((V)(400D)), NewObj(1).Put("zap", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("plip")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis350, int _argc343, V t_349, V _a346, V _a347, V _a348, V[] _rest344) => {
Invoke(Invoke(t_349, "fx", ((V)("drop")), ((V)("head")), ((V)(2D))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_349, "B"), "sq"), ((V)(0.07)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_349, "B"), "sq")) - 0.03)))).V, ((V)("o")));
Call(bk_15, V.Undef, t_349);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis358, int _argc351, V t_357, V _a354, V _a355, V _a356, V[] _rest352) => {
return Invoke(Call(sp_14, V.Undef, t_357, NewObj(2).Put("sq", Add(Get(Get(t_357, "B"), "sq"), ((V)(0.1)))).Put("close", ((V)(0.9))).V, ((V)(1400D)), ((V)(1000D))), "fx", ((V)("drop")), ((V)("body")), ((V)(2D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("breeze")), flt_19, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis366, int _argc359, V t_365, V _a362, V _a363, V _a364, V[] _rest360) => {
Invoke(Invoke(Invoke(Invoke(t_365, "to", ((V)(300D)), NewObj(3).Put("open", ((V)(0.5))).Put("puff", ((V)(0.6))).Put("lean", ((V)((-1.4)))).V), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(500D)), NewObj(3).Put("lean", ((V)(2D))).Put("open", ((V)(0.1))).Put("puff", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(400D)));
Call(bk_15, V.Undef, t_365);
return default;
}, 1, "", true), ((V)("hum")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis374, int _argc367, V t_373, V _a370, V _a371, V _a372, V[] _rest368) => {
return Invoke(Call(sp_14, V.Undef, t_373, NewObj(2).Put("lean", ((V)(2.4))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(900D))), "fx", ((V)("gust")), ((V)("head")));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("dusty")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), ((V)("ears")), Fn((V _arrowThis382, int _argc375, V t_381, V _a378, V _a379, V _a380, V[] _rest376) => {
Invoke(Invoke(Invoke(t_381, "fx", ((V)("dust")), ((V)("body")), ((V)(4D))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("sq", Add(Get(Get(t_381, "B"), "sq"), ((V)(0.05)))).V, NewObj(1).Put("sq", Get(Get(t_381, "B"), "sq")).V, ((V)("o"))), "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
Call(bk_15, V.Undef, t_381);
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("ears")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("aurora")), sea_20, NewObj(3).Put("gap", Arr(((V)(2200D)), ((V)(2800D)), ((V)(2400D)))).Put("f", Arr(((V)("look")), Fn((V _arrowThis390, int _argc383, V t_389, V _a386, V _a387, V _a388, V[] _rest384) => {
Invoke(Invoke(Invoke(Invoke(t_389, "to", ((V)(300D)), NewObj(2).Put("spout", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)("o"))), "fx", ((V)("drop")), ((V)("head")), ((V)(4D))), "wait", ((V)(900D))), "to", ((V)(400D)), NewObj(1).Put("spout", ((V)(0D))).V);
Call(bk_15, V.Undef, t_389);
return default;
}, 1, "", true), Fn((V _arrowThis398, int _argc391, V t_397, V _a394, V _a395, V _a396, V[] _rest392) => {
return Call(sp_14, V.Undef, t_397, NewObj(3).Put("glow", ((V)(1D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("doze")), Fn((V _arrowThis406, int _argc399, V t_405, V _a402, V _a403, V _a404, V[] _rest400) => {
return Call(sp_14, V.Undef, t_405, NewObj(2).Put("glow", ((V)(0.8))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(2000D)));
}, 1, "", true), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("mallow")), NewObj(2).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).V, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis414, int _argc407, V t_413, V _a410, V _a411, V _a412, V[] _rest408) => {
Invoke(Invoke(Invoke(t_413, "to", ((V)(1200D)), NewObj(4).Put("sq", Add(Get(Get(t_413, "B"), "sq"), ((V)(0.2)))).Put("lift", ((V)((ToNum(Get(Get(t_413, "B"), "lift")) - 1.6)))).Put("close", ((V)(0.85))).Put("smile", ((V)(1D))).V, ((V)("s"))), "wait", ((V)(800D))), "to", ((V)(220D)), NewObj(4).Put("sq", ((V)((ToNum(Get(Get(t_413, "B"), "sq")) - 0.08)))).Put("lift", Add(Get(Get(t_413, "B"), "lift"), ((V)(1D)))).Put("close", ((V)(0D))).Put("wide", ((V)(0.4))).V, ((V)("o")));
Call(bk_15, V.Undef, t_413);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis422, int _argc415, V t_421, V _a418, V _a419, V _a420, V[] _rest416) => {
return Call(sp_14, V.Undef, t_421, NewObj(2).Put("sq", Add(Get(Get(t_421, "B"), "sq"), ((V)(0.14)))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1200D)));
}, 1, "", true), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("bao")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis430, int _argc423, V t_429, V _a426, V _a427, V _a428, V[] _rest424) => {
Invoke(Invoke(Invoke(Invoke(t_429, "to", ((V)(500D)), NewObj(4).Put("sq", ((V)((ToNum(Get(Get(t_429, "B"), "sq")) - 0.07)))).Put("lift", Add(Get(Get(t_429, "B"), "lift"), ((V)(1.4)))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("head"))), "wait", ((V)(500D))), "fx", ((V)("steam")), ((V)("head")));
Call(bk_15, V.Undef, t_429, ((V)(600D)));
return default;
}, 1, "", true), ((V)("swing")), ((V)("bounce")))).Put("lf", Arr(((V)("sigh")), Fn((V _arrowThis438, int _argc431, V t_437, V _a434, V _a435, V _a436, V[] _rest432) => {
Invoke(Invoke(Invoke(t_437, "fx", ((V)("steam")), ((V)("head"))), "wait", ((V)(800D))), "fx", ((V)("steam")), ((V)("head")));
return default;
}, 1, "", true), ((V)("doze")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("dunkie")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis446, int _argc439, V t_445, V _a442, V _a443, V _a444, V[] _rest440) => {
Invoke(Invoke(Invoke(t_445, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("x", ((V)(1.1))).Put("tilt", ((V)(3D))).V, NewObj(2).Put("x", ((V)((-1.1)))).Put("tilt", ((V)((-3D)))).V, ((V)("s"))), "fx", ((V)("sprinkle")), ((V)("head")));
Call(bk_15, V.Undef, t_445);
return default;
}, 1, "", true), ((V)("kick")), ((V)("yawn")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("frybo")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis454, int _argc447, V t_453, V _a450, V _a451, V _a452, V[] _rest448) => {
return Call(sp_14, V.Undef, t_453, NewObj(3).Put("fw", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(900D)), ((V)(900D)));
}, 1, "", true), Fn((V _arrowThis462, int _argc455, V t_461, V _a458, V _a459, V _a460, V[] _rest456) => {
Invoke(Invoke(Invoke(t_461, "fx", ((V)("salt")), ((V)("head"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("l"))), "fx", ((V)("salt")), ((V)("head")));
Call(bk_15, V.Undef, t_461, ((V)(300D)));
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), Fn((V _arrowThis470, int _argc463, V t_469, V _a466, V _a467, V _a468, V[] _rest464) => {
return Call(sp_14, V.Undef, t_469, NewObj(2).Put("fw", ((V)(0.6))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(1200D)));
}, 1, "", true), ((V)("doze")), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("bunbun")), NewObj(2).Put("dn", ((V)("spin"))).Put("up", ((V)("hop"))).V, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis478, int _argc471, V t_477, V _a474, V _a475, V _a476, V[] _rest472) => {
Invoke(Invoke(Invoke(Invoke(t_477, "to", ((V)(300D)), NewObj(3).Put("split", ((V)(0.4))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(1).Put("shuf", ((V)(0.6))).V, NewObj(1).Put("shuf", ((V)((-0.6)))).V, ((V)("s"))), "to", ((V)(260D)), NewObj(2).Put("split", ((V)(0D))).Put("shuf", ((V)(0D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(1).Put("sq", Add(Get(Get(t_477, "B"), "sq"), ((V)(0.06)))).V, ((V)("o")));
Call(bk_15, V.Undef, t_477);
return default;
}, 1, "", true), ((V)("kick")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis486, int _argc479, V t_485, V _a482, V _a483, V _a484, V[] _rest480) => {
return Call(sp_14, V.Undef, t_485, NewObj(2).Put("split", ((V)(0.2))).Put("close", ((V)(0.8))).V, ((V)(1200D)), ((V)(1000D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("choco")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis494, int _argc487, V t_493, V _a490, V _a491, V _a492, V[] _rest488) => {
return Call(sp_14, V.Undef, t_493, NewObj(3).Put("melt", ((V)(0.3))).Put("close", ((V)(0.75))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), Fn((V _arrowThis502, int _argc495, V t_501, V _a498, V _a499, V _a500, V[] _rest496) => {
return Call(sp_14, V.Undef, t_501, NewObj(3).Put("melt", ((V)(0.45))).Put("close", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)(2000D)), ((V)(1800D)));
}, 1, "", true), ((V)("doze")), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("scoop")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis510, int _argc503, V t_509, V _a506, V _a507, V _a508, V[] _rest504) => {
Invoke(t_509, "osc", ((V)(1400D)), ((V)(4D)), NewObj(2).Put("chb", ((V)(1D))).Put("hap", ((V)(0.7))).V, NewObj(2).Put("chb", ((V)(0D))).Put("hap", ((V)(0.4))).V, ((V)("o")));
Call(bk_15, V.Undef, t_509);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis518, int _argc511, V t_517, V _a514, V _a515, V _a516, V[] _rest512) => {
Invoke(t_517, "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("chb", ((V)(0.6))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("boba")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis526, int _argc519, V t_525, V _a522, V _a523, V _a524, V[] _rest520) => {
Invoke(Invoke(Invoke(Invoke(t_525, "to", ((V)(300D)), NewObj(4).Put("sqz", ((V)(0.6))).Put("open", ((V)(0.15))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.3)))).V), "osc", ((V)(1200D)), ((V)(6D)), NewObj(2).Put("x", ((V)(0.5))).Put("sq", Add(Get(Get(t_525, "B"), "sq"), ((V)(0.02)))).V, NewObj(2).Put("x", ((V)((-0.5)))).Put("sq", Get(Get(t_525, "B"), "sq")).V, ((V)("l"))), "to", ((V)(200D)), NewObj(5).Put("sqz", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V, ((V)("o"))), "wait", ((V)(400D)));
Call(bk_15, V.Undef, t_525);
return default;
}, 1, "", true), ((V)("kick")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("chefbun")), hop_18, NewObj(4).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("pose", NewObj(1).Put("pitch", ((V)(0.1))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis534, int _argc527, V t_533, V _a530, V _a531, V _a532, V[] _rest528) => {
Invoke(Invoke(Invoke(Invoke(t_533, "to", ((V)(380D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-14D)))), NewObj(3).Put("armR", ((V)(36D))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).V)), "wait", ((V)(300D))), "to", ((V)(260D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)((-6D))), ((V)((-16D)))), NewObj(3).Put("armR", ((V)(70D))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).V), ((V)("o"))), "fx", ((V)("heart")), ((V)("head")));
Call(bk_15, V.Undef, t_533);
return default;
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("pip")), NewObj(2).Put("dn", ((V)("slide"))).Put("up", ((V)("hop"))).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis542, int _argc535, V t_541, V _a538, V _a539, V _a540, V[] _rest536) => {
Invoke(Invoke(t_541, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(1000D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(42D))).Put("armR", ((V)(42D))).V, NewObj(2).Put("armL", ((V)(4D))).Put("armR", ((V)(4D))).V, ((V)("o")));
Call(bk_15, V.Undef, t_541);
return default;
}, 1, "", true), ((V)("kick")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis550, int _argc543, V t_549, V _a546, V _a547, V _a548, V[] _rest544) => {
Invoke(t_549, "osc", ((V)(1200D)), ((V)(3D)), NewObj(2).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).V, NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("jelli")), flt_19, NewObj(3).Put("gap", Arr(((V)(1800D)), ((V)(2400D)), ((V)(2000D)))).Put("f", Arr(((V)("look")), Fn((V _arrowThis558, int _argc551, V t_557, V _a554, V _a555, V _a556, V[] _rest552) => {
{
double i_559 = 0;
i_559 = 0D;
while (true) {
if (!((i_559 < 3D))) break;
Invoke(Invoke(Invoke(t_557, "to", ((V)(240D)), NewObj(2).Put("sq", Add(Get(Get(t_557, "B"), "sq"), ((V)(0.1)))).Put("lift", ((V)((ToNum(Get(Get(t_557, "B"), "lift")) - 0.4)))).V, ((V)("i"))), "to", ((V)(420D)), NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_557, "B"), "sq")) - 0.08)))).Put("lift", Add(Get(Get(t_557, "B"), "lift"), ((V)(2D)))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(2).Put("sq", Get(Get(t_557, "B"), "sq")).Put("lift", Get(Get(t_557, "B"), "lift")).V, ((V)("s")));
i_559++;
}
}
Call(bk_15, V.Undef, t_557);
return default;
}, 1, "", true), ((V)("hum")), Arr(((V)("wave")), ((V)(1D))))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis568, int _argc561, V t_567, V _a564, V _a565, V _a566, V[] _rest562) => {
Invoke(t_567, "osc", ((V)(2400D)), ((V)(2D)), NewObj(1).Put("sq", Add(Get(Get(t_567, "B"), "sq"), ((V)(0.06)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_567, "B"), "sq")) - 0.04)))).V, ((V)("s")));
return default;
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("finn")), sea_20, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis576, int _argc569, V t_575, V _a572, V _a573, V _a574, V[] _rest570) => {
Invoke(Invoke(Invoke(t_575, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "osc", ((V)(900D)), ((V)(6D)), NewObj(1).Put("open", ((V)(0.5))).V, NewObj(1).Put("open", ((V)(0.1))).V, ((V)("l"))), "fx", ((V)("note")), ((V)("head")));
Call(bk_15, V.Undef, t_575);
return default;
}, 1, "", true), Fn((V _arrowThis584, int _argc577, V t_583, V _a580, V _a581, V _a582, V[] _rest578) => {
Invoke(Invoke(t_583, "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("wag", ((V)(28D))).V, NewObj(1).Put("wag", ((V)((-28D)))).V, ((V)("io"))), "fx", ((V)("drop")), ((V)("body")), ((V)(4D)));
Call(bk_15, V.Undef, t_583);
return default;
}, 1, "", true), Arr(((V)("wave")), ((V)(1D))))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis592, int _argc585, V t_591, V _a588, V _a589, V _a590, V[] _rest586) => {
Invoke(t_591, "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("wag", ((V)(14D))).V, NewObj(1).Put("wag", ((V)((-14D)))).V, ((V)("s")));
return default;
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("sealy")), sea_20, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis600, int _argc593, V t_599, V _a596, V _a597, V _a598, V[] _rest594) => {
Invoke(Invoke(t_599, "to", ((V)(300D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(1D)), ((V)((-4D)))), NewObj(4).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V)), "osc", ((V)(1200D)), ((V)(5D)), NewObj(3).Put("hLx", ((V)(1D))).Put("hRx", ((V)((-1D)))).Put("open", ((V)(0.5))).V, NewObj(3).Put("hLx", ((V)(6D))).Put("hRx", ((V)((-6D)))).Put("open", ((V)(0.1))).V, ((V)("o")));
Call(bk_15, V.Undef, t_599);
return default;
}, 1, "", true), ((V)("wiggle")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), Fn((V _arrowThis608, int _argc601, V t_607, V _a604, V _a605, V _a606, V[] _rest602) => {
return Call(sp_14, V.Undef, t_607, NewObj(3).Put("tilt", ((V)((-9D)))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("puff")), Call(o_13, V.Undef, flt_19, NewObj(1).Put("dn", ((V)("float"))).V), NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis616, int _argc609, V t_615, V _a612, V _a613, V _a614, V[] _rest610) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_615, "to", ((V)(500D)), NewObj(3).Put("blo", ((V)(0.55))).Put("puff", ((V)(0.6))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(700D))), "fx", ((V)("bubble")), ((V)("head"))), "to", ((V)(800D)), NewObj(3).Put("blo", ((V)(0D))).Put("puff", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io"))), "fx", ((V)("bubble")), ((V)("head")));
Call(bk_15, V.Undef, t_615);
return default;
}, 1, "", true), ((V)("hum")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis624, int _argc617, V t_623, V _a620, V _a621, V _a622, V[] _rest618) => {
return Call(sp_14, V.Undef, t_623, NewObj(2).Put("blo", ((V)(0.3))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("shelly")), NewObj(2).Put("dn", ((V)("climb"))).Put("up", ((V)("hop"))).V, NewObj(3).Put("gap", Arr(((V)(2000D)), ((V)(2800D)), ((V)(2200D)))).Put("f", Arr(((V)("look")), Fn((V _arrowThis632, int _argc625, V t_631, V _a628, V _a629, V _a630, V[] _rest626) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_631, "to", ((V)(600D)), NewObj(2).Put("nk", ((V)(1D))).Put("ly", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(2).Put("lx", ((V)((-1D)))).Put("turn", ((V)((-0.3)))).V), "wait", ((V)(500D))), "to", ((V)(600D)), NewObj(2).Put("lx", ((V)(1D))).Put("turn", ((V)(0.3))).V), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(4).Put("lx", ((V)(0D))).Put("turn", ((V)(0D))).Put("nk", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Call(bk_15, V.Undef, t_631);
return default;
}, 1, "", true), Fn((V _arrowThis640, int _argc633, V t_639, V _a636, V _a637, V _a638, V[] _rest634) => {
Invoke(Invoke(Invoke(Invoke(t_639, "to", ((V)(400D)), NewObj(1).Put("hid", ((V)(0.75))).V, ((V)("io"))), "wait", ((V)(1200D))), "to", ((V)(260D)), NewObj(1).Put("hid", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(2D)));
Call(bk_15, V.Undef, t_639);
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("doze")), Fn((V _arrowThis648, int _argc641, V t_647, V _a644, V _a645, V _a646, V[] _rest642) => {
Invoke(Invoke(Invoke(t_647, "to", ((V)(700D)), NewObj(1).Put("hid", ((V)(0.5))).V), "wait", ((V)(2400D))), "to", ((V)(400D)), NewObj(1).Put("hid", ((V)(0D))).V);
return default;
}, 1, "", true), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("octo")), NewObj(3).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).Put("pose", NewObj(1).Put("sit", ((V)(0D))).V).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis656, int _argc649, V t_655, V _a652, V _a653, V _a654, V[] _rest650) => {
return Call(sp_14, V.Undef, t_655, NewObj(3).Put("ow", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), Fn((V _arrowThis664, int _argc657, V t_663, V _a660, V _a661, V _a662, V[] _rest658) => {
return Call(sp_14, V.Undef, t_663, NewObj(2).Put("ocl", ((V)(1D))).Put("close", ((V)(0.7))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis672, int _argc665, V t_671, V _a668, V _a669, V _a670, V[] _rest666) => {
return Call(sp_14, V.Undef, t_671, NewObj(2).Put("osp", ((V)(0.7))).Put("close", ((V)(0.8))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("marina")), NewObj(3).Put("dn", ((V)("slide"))).Put("up", ((V)("hop"))).Put("pose", NewObj(1).Put("sit", ((V)(0D))).V).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis680, int _argc673, V t_679, V _a676, V _a677, V _a678, V[] _rest674) => {
Invoke(Invoke(Invoke(Invoke(t_679, "to", ((V)(400D)), NewObj(2).Put("tlf", ((V)(0.8))).Put("tsw", ((V)(0.6))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(1).Put("tsw", ((V)((-0.6)))).V, NewObj(1).Put("tsw", ((V)(0.6))).V, ((V)("s"))), "fx", ((V)("drop")), ((V)("body")), ((V)(4D))), "to", ((V)(400D)), NewObj(2).Put("tlf", ((V)(0D))).Put("tsw", ((V)(0D))).V);
Call(bk_15, V.Undef, t_679);
return default;
}, 1, "", true), Fn((V _arrowThis688, int _argc681, V t_687, V _a684, V _a685, V _a686, V[] _rest682) => {
return Call(sp_14, V.Undef, t_687, NewObj(4).Put("htilt", ((V)((-10D)))).Put("lean", ((V)((-1.4)))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1000D)), ((V)(600D)));
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis696, int _argc689, V t_695, V _a692, V _a693, V _a694, V[] _rest690) => {
return Call(sp_14, V.Undef, t_695, NewObj(2).Put("tlf", ((V)(0.5))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("pearl")), sea_20, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis704, int _argc697, V t_703, V _a700, V _a701, V _a702, V[] _rest698) => {
return Invoke(Call(sp_14, V.Undef, t_703, NewObj(3).Put("glow", ((V)(1D))).Put("wide", ((V)(0.3))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(1000D))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D)));
}, 1, "", true), Fn((V _arrowThis712, int _argc705, V t_711, V _a708, V _a709, V _a710, V[] _rest706) => {
return Call(sp_14, V.Undef, t_711, NewObj(3).Put("fflap", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(1200D)), ((V)(900D)));
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("doze")), Fn((V _arrowThis720, int _argc713, V t_719, V _a716, V _a717, V _a718, V[] _rest714) => {
return Call(sp_14, V.Undef, t_719, NewObj(2).Put("glow", ((V)(0.6))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1800D)));
}, 1, "", true), ((V)("sigh")))).V);
Call(mk_21, V.Undef, ((V)("pina")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis728, int _argc721, V t_727, V _a724, V _a725, V _a726, V[] _rest722) => {
Invoke(Invoke(Invoke(t_727, "to", ((V)(220D)), NewObj(2).Put("crw", ((V)(1D))).Put("hap", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(1000D)), ((V)(4D)), NewObj(1).Put("htilt", ((V)(6D))).V, NewObj(1).Put("htilt", ((V)((-6D)))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(1).Put("crw", ((V)(0D))).V);
Call(bk_15, V.Undef, t_727);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis736, int _argc729, V t_735, V _a732, V _a733, V _a734, V[] _rest730) => {
return Call(sp_14, V.Undef, t_735, NewObj(2).Put("crs", ((V)(0.6))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("avo")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis744, int _argc737, V t_743, V _a740, V _a741, V _a742, V[] _rest738) => {
Invoke(Invoke(Invoke(t_743, "to", ((V)(200D)), NewObj(3).Put("prw", ((V)(1D))).Put("pp", ((V)(0.35))).Put("wide", ((V)(0.4))).V, ((V)("o"))), "wait", ((V)(900D))), "to", ((V)(300D)), NewObj(3).Put("prw", ((V)(0D))).Put("pp", ((V)(0D))).Put("wide", ((V)(0D))).V);
Call(bk_15, V.Undef, t_743);
return default;
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("belly")), ((V)("doze")), Fn((V _arrowThis752, int _argc745, V t_751, V _a748, V _a749, V _a750, V[] _rest746) => {
return Call(sp_14, V.Undef, t_751, NewObj(2).Put("pr", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1000D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("berri")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis760, int _argc753, V t_759, V _a756, V _a757, V _a758, V[] _rest754) => {
Invoke(Invoke(t_759, "to", ((V)(120D)), NewObj(2).Put("stw", ((V)(1D))).Put("hap", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(900D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("bk")));
Call(bk_15, V.Undef, t_759);
return default;
}, 1, "", true), ((V)("kick")), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis768, int _argc761, V t_767, V _a764, V _a765, V _a766, V[] _rest762) => {
return Call(sp_14, V.Undef, t_767, NewObj(2).Put("lfl", ((V)(0.6))).Put("close", ((V)(0.8))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("lemmy")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis776, int _argc769, V t_775, V _a772, V _a773, V _a774, V[] _rest770) => {
Invoke(Invoke(Invoke(Invoke(t_775, "to", ((V)(200D)), NewObj(4).Put("sqz", ((V)(1D))).Put("mw", ((V)(0.4))).Put("open", ((V)(0.12))).Put("frown", ((V)(0.4))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(7D)), NewObj(1).Put("x", ((V)(0.6))).V, NewObj(1).Put("x", ((V)((-0.6)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(5).Put("sqz", ((V)(0D))).Put("mw", ((V)(1D))).Put("open", ((V)(0D))).Put("frown", ((V)(0D))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(300D)));
Call(bk_15, V.Undef, t_775);
return default;
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis784, int _argc777, V t_783, V _a780, V _a781, V _a782, V[] _rest778) => {
return Call(sp_14, V.Undef, t_783, NewObj(2).Put("lfl", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1400D)), ((V)(1000D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("kiwi")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis792, int _argc785, V t_791, V _a788, V _a789, V _a790, V[] _rest786) => {
Invoke(Invoke(Invoke(t_791, "to", ((V)(220D)), NewObj(2).Put("fzz", ((V)(1D))).Put("sqz", ((V)(0.6))).V, ((V)("o"))), "osc", ((V)(700D)), ((V)(6D)), NewObj(1).Put("x", ((V)(0.7))).V, NewObj(1).Put("x", ((V)((-0.7)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(3).Put("fzz", ((V)(0D))).Put("sqz", ((V)(0D))).Put("hap", ((V)(0.6))).V);
Call(bk_15, V.Undef, t_791);
return default;
}, 1, "", true), ((V)("kick")), ((V)("ears")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis800, int _argc793, V t_799, V _a796, V _a797, V _a798, V[] _rest794) => {
return Call(sp_14, V.Undef, t_799, NewObj(2).Put("fzz", ((V)(0.4))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("melo")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis808, int _argc801, V t_807, V _a804, V _a805, V _a806, V[] _rest802) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_807, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.7))).Put("open", ((V)(0D))).V), "to", ((V)(120D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).Put("pitch", ((V)((ToNum(Get(Get(t_807, "B"), "pitch")) - 0.1)))).V, ((V)("o"))), "fx", ((V)("seed")), ((V)("head"))), "to", ((V)(300D)), NewObj(4).Put("open", ((V)(0D))).Put("pitch", Get(Get(t_807, "B"), "pitch")).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "wait", ((V)(400D)));
Call(bk_15, V.Undef, t_807);
return default;
}, 1, "", true), ((V)("swing")), Fn((V _arrowThis816, int _argc809, V t_815, V _a812, V _a813, V _a814, V[] _rest810) => {
Invoke(t_815, "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("sdj", ((V)(1D))).V, NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("peachy")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis824, int _argc817, V t_823, V _a820, V _a821, V _a822, V[] _rest818) => {
Invoke(Invoke(t_823, "to", ((V)(400D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(9D)), ((V)((-12D)))), NewObj(5).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("blush", ((V)(1D))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V)), "osc", ((V)(1600D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(3D))).Put("htilt", ((V)(6D))).V, NewObj(2).Put("tilt", ((V)((-3D)))).Put("htilt", ((V)((-6D)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_823);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis832, int _argc825, V t_831, V _a828, V _a829, V _a830, V[] _rest826) => {
return Call(sp_14, V.Undef, t_831, NewObj(3).Put("blush", ((V)(0.9))).Put("lfl", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("pitaya")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis840, int _argc833, V t_839, V _a836, V _a837, V _a838, V[] _rest834) => {
return Invoke(Call(sp_14, V.Undef, t_839, NewObj(4).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.6))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(1000D))), "fx", ((V)("spark")), ((V)("body")), ((V)(4D)));
}, 1, "", true), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis848, int _argc841, V t_847, V _a844, V _a845, V _a846, V[] _rest842) => {
return Call(sp_14, V.Undef, t_847, NewObj(2).Put("wsp", ((V)(0.8))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("tutti")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis856, int _argc849, V t_855, V _a852, V _a853, V _a854, V[] _rest850) => {
Invoke(Invoke(Invoke(Invoke(t_855, "to", ((V)(300D)), NewObj(3).Put("fL", ((V)(1D))).Put("ly", ((V)((-0.8)))).Put("hap", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("fL", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(2).Put("fR", ((V)(1D))).Put("ly", ((V)((-0.8)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("fR", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("i")));
Call(bk_15, V.Undef, t_855);
return default;
}, 1, "", true), ((V)("swing")), Fn((V _arrowThis864, int _argc857, V t_863, V _a860, V _a861, V _a862, V[] _rest858) => {
return Invoke(Call(sp_14, V.Undef, t_863, NewObj(2).Put("wfl", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(900D))), "fx", ((V)("dust")), ((V)("body")), ((V)(3D)));
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis872, int _argc865, V t_871, V _a868, V _a869, V _a870, V[] _rest866) => {
return Call(sp_14, V.Undef, t_871, NewObj(2).Put("wfl", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("kiko")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis880, int _argc873, V t_879, V _a876, V _a877, V _a878, V[] _rest874) => {
Invoke(Invoke(Invoke(Invoke(t_879, "to", ((V)(300D)), NewObj(2).Put("htilt", ((V)((-10D)))).Put("lean", ((V)((-1.4)))).V), "to", ((V)(360D)), NewObj(4).Put("htilt", ((V)(9D))).Put("lean", ((V)(1.4))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("o"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(500D)));
Call(bk_15, V.Undef, t_879);
return default;
}, 1, "", true), ((V)("swing")), ((V)("ears")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("teddy")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis888, int _argc881, V t_887, V _a884, V _a885, V _a886, V[] _rest882) => {
Invoke(Invoke(Invoke(t_887, "to", ((V)(450D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(14D)), ((V)((-6D)))), NewObj(6).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("close", ((V)(0.8))).Put("smile", ((V)(1D))).Put("hap", ((V)(0.6))).Put("blush", ((V)(0.6))).V)), "fx", ((V)("heart")), ((V)("head"))), "osc", ((V)(2000D)), ((V)(2D)), NewObj(2).Put("lean", ((V)(1.2))).Put("tilt", ((V)(2D))).V, NewObj(2).Put("lean", ((V)((-1.2)))).Put("tilt", ((V)((-2D)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_887, ((V)(500D)));
return default;
}, 1, "", true), ((V)("swing")), ((V)("ears")), ((V)("yawn")))).Put("lf", Arr(((V)("belly")), ((V)("doze")), ((V)("sigh")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("hoot")), hop_18, NewObj(3).Put("gap", Arr(((V)(1800D)), ((V)(2400D)), ((V)(2000D)))).Put("f", Arr(((V)("look")), Fn((V _arrowThis896, int _argc889, V t_895, V _a892, V _a893, V _a894, V[] _rest890) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_895, "to", ((V)(600D)), NewObj(3).Put("turn", ((V)(0.85))).Put("lx", ((V)(1D))).Put("tfl", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(800D)), NewObj(2).Put("turn", ((V)((-0.85)))).Put("lx", ((V)((-1D)))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(3).Put("turn", ((V)(0D))).Put("lx", ((V)(0D))).Put("tfl", ((V)(0D))).V);
Call(bk_15, V.Undef, t_895);
return default;
}, 1, "", true), ((V)("nod")), Fn((V _arrowThis904, int _argc897, V t_903, V _a900, V _a901, V _a902, V[] _rest898) => {
return Call(sp_14, V.Undef, t_903, NewObj(2).Put("wfl", ((V)(1D))).Put("hap", ((V)(0.5))).V, ((V)(900D)), ((V)(500D)));
}, 1, "", true))).Put("lf", Arr(((V)("doze")), ((V)("sigh")), Fn((V _arrowThis912, int _argc905, V t_911, V _a908, V _a909, V _a910, V[] _rest906) => {
return Call(sp_14, V.Undef, t_911, NewObj(2).Put("tfl", ((V)(0.6))).Put("close", ((V)(1D))).V, ((V)(1400D)), ((V)(1400D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("leo")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis920, int _argc913, V t_919, V _a916, V _a917, V _a918, V[] _rest914) => {
Invoke(Invoke(Invoke(t_919, "to", ((V)(200D)), NewObj(2).Put("msh", ((V)(1D))).Put("mfl", ((V)(0.6))).V), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("htilt", ((V)(7D))).V, NewObj(1).Put("htilt", ((V)((-7D)))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(2).Put("msh", ((V)(0D))).Put("mfl", ((V)(0D))).V);
Call(bk_15, V.Undef, t_919);
return default;
}, 1, "", true), Fn((V _arrowThis928, int _argc921, V t_927, V _a924, V _a925, V _a926, V[] _rest922) => {
return Call(sp_14, V.Undef, t_927, NewObj(4).Put("open", ((V)(0.6))).Put("wide", ((V)(0.4))).Put("mfl", ((V)(0.8))).Put("pitch", Add(Get(Get(t_927, "B"), "pitch"), ((V)(0.15)))).V, ((V)(700D)), ((V)(400D)));
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("panko")), hop_18, NewObj(3).Put("pose", NewObj(1).Put("sq", ((V)(0.13))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis936, int _argc929, V t_935, V _a932, V _a933, V _a934, V[] _rest930) => {
Invoke(Invoke(Invoke(t_935, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(11D)), ((V)((-14D)))), NewObj(1).Put("armR", ((V)(34D))).V)), "osc", ((V)(2000D)), ((V)(7D)), NewObj(2).Put("open", ((V)(0.3))).Put("puff", ((V)(0.6))).V, NewObj(2).Put("open", ((V)(0.05))).Put("puff", ((V)(0.3))).V, ((V)("s"))), "fx", ((V)("crumb")), ((V)("head")));
Call(bk_15, V.Undef, t_935);
return default;
}, 1, "", true), ((V)("swing")), ((V)("bounce")))).Put("lf", Arr(((V)("doze")), ((V)("belly")), ((V)("sigh")), Fn((V _arrowThis944, int _argc937, V t_943, V _a940, V _a941, V _a942, V[] _rest938) => {
return Call(sp_14, V.Undef, t_943, NewObj(3).Put("tilt", ((V)((-10D)))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1500D)), ((V)(1200D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("acorn")), NewObj(2).Put("dn", ((V)("climb"))).Put("up", ((V)("hop"))).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis952, int _argc945, V t_951, V _a948, V _a949, V _a950, V[] _rest946) => {
Invoke(t_951, "osc", ((V)(1000D)), ((V)(4D)), NewObj(2).Put("tfl", ((V)(1D))).Put("tsw", ((V)(0.8))).V, NewObj(2).Put("tfl", ((V)(0.2))).Put("tsw", ((V)((-0.8)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_951);
return default;
}, 1, "", true), Fn((V _arrowThis960, int _argc953, V t_959, V _a956, V _a957, V _a958, V[] _rest954) => {
Invoke(Invoke(Invoke(t_959, "to", ((V)(300D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(9D)), ((V)((-11D)))), NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V)), "osc", ((V)(1400D)), ((V)(7D)), NewObj(1).Put("open", ((V)(0.25))).V, NewObj(1).Put("open", ((V)(0D))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("head")));
Call(bk_15, V.Undef, t_959);
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis968, int _argc961, V t_967, V _a964, V _a965, V _a966, V[] _rest962) => {
return Call(sp_14, V.Undef, t_967, NewObj(2).Put("tsw", ((V)(0.6))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("fawn")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), ((V)("ears")), Fn((V _arrowThis976, int _argc969, V t_975, V _a972, V _a973, V _a974, V[] _rest970) => {
Invoke(Invoke(t_975, "osc", ((V)(700D)), ((V)(4D)), NewObj(2).Put("ly", ((V)((-0.2)))).Put("sq", Add(Get(Get(t_975, "B"), "sq"), ((V)(0.01)))).V, NewObj(2).Put("ly", ((V)(0D))).Put("sq", Get(Get(t_975, "B"), "sq")).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.5))).Put("smile", ((V)(1D))).V);
Call(bk_15, V.Undef, t_975);
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("ears")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("moss")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis984, int _argc977, V t_983, V _a980, V _a981, V _a982, V[] _rest978) => {
Invoke(Invoke(t_983, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("cb", ((V)(1D))).V, NewObj(1).Put("cb", ((V)(0D))).V, ((V)("o"))), "fx", ((V)("dust")), ((V)("head")), ((V)(3D)));
Call(bk_15, V.Undef, t_983);
return default;
}, 1, "", true), ((V)("swing")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis992, int _argc985, V t_991, V _a988, V _a989, V _a990, V[] _rest986) => {
return Call(sp_14, V.Undef, t_991, NewObj(2).Put("csp", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1000D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("sprout")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1000, int _argc993, V t_999, V _a996, V _a997, V _a998, V[] _rest994) => {
return Invoke(Call(sp_14, V.Undef, t_999, NewObj(3).Put("blm", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
}, 1, "", true), ((V)("swing")), Fn((V _arrowThis1008, int _argc1001, V t_1007, V _a1004, V _a1005, V _a1006, V[] _rest1002) => {
Invoke(t_1007, "osc", ((V)(1200D)), ((V)(3D)), NewObj(1).Put("stw", ((V)(1D))).V, NewObj(1).Put("stw", ((V)(0D))).V, ((V)("o")));
return default;
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis1016, int _argc1009, V t_1015, V _a1012, V _a1013, V _a1014, V[] _rest1010) => {
return Call(sp_14, V.Undef, t_1015, NewObj(2).Put("blm", ((V)(0.7))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1600D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("hana")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1024, int _argc1017, V t_1023, V _a1020, V _a1021, V _a1022, V[] _rest1018) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_1023, "to", ((V)(300D)), NewObj(1).Put("flL", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(300D)), NewObj(2).Put("flL", ((V)(0D))).Put("flR", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(300D)), NewObj(1).Put("flR", ((V)(0D))).V);
Call(bk_15, V.Undef, t_1023);
return default;
}, 1, "", true), ((V)("kick")), Fn((V _arrowThis1032, int _argc1025, V t_1031, V _a1028, V _a1029, V _a1030, V[] _rest1026) => {
Invoke(t_1031, "osc", ((V)(1000D)), ((V)(4D)), NewObj(1).Put("tw", ((V)(1D))).V, NewObj(1).Put("tw", ((V)((-1D)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_1031);
return default;
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis1040, int _argc1033, V t_1039, V _a1036, V _a1037, V _a1038, V[] _rest1034) => {
return Call(sp_14, V.Undef, t_1039, NewObj(3).Put("flL", ((V)(0.8))).Put("flR", ((V)(0.8))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1600D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("boo")), flt_19, NewObj(3).Put("gap", Arr(((V)(2200D)), ((V)(2600D)), ((V)(2000D)))).Put("f", Arr(((V)("look")), Fn((V _arrowThis1048, int _argc1041, V t_1047, V _a1044, V _a1045, V _a1046, V[] _rest1042) => {
Invoke(Invoke(Invoke(Invoke(t_1047, "to", ((V)(400D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(10D)), ((V)((-14D)))), NewObj(4).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("blush", ((V)(0.9))).Put("gho", ((V)(0.45))).V)), "wait", ((V)(900D))), "to", ((V)(400D)), NewObj(1).Put("gho", ((V)(0D))).V), "wait", ((V)(200D)));
Call(bk_15, V.Undef, t_1047);
return default;
}, 1, "", true), Fn((V _arrowThis1056, int _argc1049, V t_1055, V _a1052, V _a1053, V _a1054, V[] _rest1050) => {
return Call(sp_14, V.Undef, t_1055, NewObj(2).Put("flr", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)(1200D)), ((V)(600D)));
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis1064, int _argc1057, V t_1063, V _a1060, V _a1061, V _a1062, V[] _rest1058) => {
return Call(sp_14, V.Undef, t_1063, NewObj(2).Put("gho", ((V)(0.3))).Put("close", ((V)(1D))).V, ((V)(1800D)), ((V)(1400D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("pixie")), Call(o_13, V.Undef, flt_19, NewObj(1).Put("dn", ((V)("float"))).V), NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1072, int _argc1065, V t_1071, V _a1068, V _a1069, V _a1070, V[] _rest1066) => {
return Invoke(Call(sp_14, V.Undef, t_1071, NewObj(3).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.6))).Put("hap", ((V)(0.8))).V, ((V)(1000D)), ((V)(800D))), "fx", ((V)("dust")), ((V)("body")), ((V)(4D)));
}, 1, "", true), ((V)("giggle")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis1080, int _argc1073, V t_1079, V _a1076, V _a1077, V _a1078, V[] _rest1074) => {
return Call(sp_14, V.Undef, t_1079, NewObj(2).Put("wfl", ((V)(0.5))).Put("close", ((V)(0.9))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("floof")), hop_18, NewObj(4).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("pose", NewObj(1).Put("sq", ((V)(0.12))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis1088, int _argc1081, V t_1087, V _a1084, V _a1085, V _a1086, V[] _rest1082) => {
Invoke(Invoke(Invoke(Invoke(t_1087, "to", ((V)(200D)), NewObj(2).Put("fzz", ((V)(1D))).Put("sqz", ((V)(0.8))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(9D)), NewObj(1).Put("x", ((V)(0.8))).V, NewObj(1).Put("x", ((V)((-0.8)))).V, ((V)("l"))), "fx", ((V)("dust")), ((V)("body")), ((V)(4D))), "to", ((V)(400D)), NewObj(3).Put("fzz", ((V)(0D))).Put("sqz", ((V)(0D))).Put("hap", ((V)(0.7))).V);
Call(bk_15, V.Undef, t_1087);
return default;
}, 1, "", true), ((V)("swing")), ((V)("bounce")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("unibun")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1096, int _argc1089, V t_1095, V _a1092, V _a1093, V _a1094, V[] _rest1090) => {
Invoke(Invoke(Invoke(Invoke(t_1095, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((ToNum(Get(Get(t_1095, "B"), "pitch")) - 0.12)))).Put("close", ((V)(0.5))).V), "fx", ((V)("spark")), ((V)("head")), ((V)(5D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(4).Put("pitch", Get(Get(t_1095, "B"), "pitch")).Put("close", ((V)(0D))).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V);
Call(bk_15, V.Undef, t_1095);
return default;
}, 1, "", true), ((V)("ears")), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("ears")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("gumdrop")), NewObj(2).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1104, int _argc1097, V t_1103, V _a1100, V _a1101, V _a1102, V[] _rest1098) => {
return Call(sp_14, V.Undef, t_1103, NewObj(3).Put("jig", ((V)(1D))).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V, ((V)(1000D)), ((V)(900D)));
}, 1, "", true), ((V)("bounce")), ((V)("wiggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis1112, int _argc1105, V t_1111, V _a1108, V _a1109, V _a1110, V[] _rest1106) => {
return Call(sp_14, V.Undef, t_1111, NewObj(2).Put("jig", ((V)(0.5))).Put("close", ((V)(1D))).V, ((V)(1400D)), ((V)(900D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("ember")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis1120, int _argc1113, V t_1119, V _a1116, V _a1117, V _a1118, V[] _rest1114) => {
return Call(sp_14, V.Undef, t_1119, NewObj(3).Put("cfl", ((V)(1D))).Put("hap", ((V)(0.6))).Put("wide", ((V)(0.3))).V, ((V)(1000D)), ((V)(900D)));
}, 1, "", true), ((V)("swing")), Fn((V _arrowThis1128, int _argc1121, V t_1127, V _a1124, V _a1125, V _a1126, V[] _rest1122) => {
Invoke(Invoke(t_1127, "to", ((V)(160D)), NewObj(1).Put("hap", ((V)(0.8))).V), "osc", ((V)(1000D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, NewObj(2).Put("armL", ((V)(4D))).Put("armR", ((V)(4D))).V, ((V)("o")));
Call(bk_15, V.Undef, t_1127);
return default;
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis1136, int _argc1129, V t_1135, V _a1132, V _a1133, V _a1134, V[] _rest1130) => {
return Call(sp_14, V.Undef, t_1135, NewObj(2).Put("cfl", ((V)(0.4))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("drako")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1144, int _argc1137, V t_1143, V _a1140, V _a1141, V _a1142, V[] _rest1138) => {
Invoke(t_1143, "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("tsw", ((V)(1D))).V, NewObj(1).Put("tsw", ((V)((-1D)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_1143);
return default;
}, 1, "", true), Fn((V _arrowThis1152, int _argc1145, V t_1151, V _a1148, V _a1149, V _a1150, V[] _rest1146) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_1151, "to", ((V)(300D)), NewObj(1).Put("puff", ((V)(0.8))).V), "to", ((V)(150D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "fx", ((V)("steam")), ((V)("head"))), "to", ((V)(300D)), NewObj(3).Put("open", ((V)(0D))).Put("blush", ((V)(0.6))).Put("smile", ((V)(1D))).V), "wait", ((V)(500D)));
Call(bk_15, V.Undef, t_1151);
return default;
}, 1, "", true), ((V)("swing")), Fn((V _arrowThis1160, int _argc1153, V t_1159, V _a1156, V _a1157, V _a1158, V[] _rest1154) => {
return Call(sp_14, V.Undef, t_1159, NewObj(2).Put("wfl", ((V)(1D))).Put("wsp", ((V)(0.5))).V, ((V)(900D)), ((V)(600D)));
}, 1, "", true))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis1168, int _argc1161, V t_1167, V _a1164, V _a1165, V _a1166, V[] _rest1162) => {
return Call(sp_14, V.Undef, t_1167, NewObj(2).Put("tcu", ((V)(0.5))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("jinni")), flt_19, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1176, int _argc1169, V t_1175, V _a1172, V _a1173, V _a1174, V[] _rest1170) => {
return Invoke(Call(sp_14, V.Undef, t_1175, NewObj(4).Put("glo", ((V)(1D))).Put("gwh", ((V)(1D))).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)(1400D)), ((V)(1200D))), "fx", ((V)("spark")), ((V)("body")), ((V)(4D)));
}, 1, "", true), Fn((V _arrowThis1184, int _argc1177, V t_1183, V _a1180, V _a1181, V _a1182, V[] _rest1178) => {
Invoke(Invoke(t_1183, "to", ((V)(400D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(12D)), ((V)((-8D)))), NewObj(3).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).Put("close", ((V)(0.6))).V)), "wait", ((V)(1000D)));
Call(bk_15, V.Undef, t_1183);
return default;
}, 1, "", true), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis1192, int _argc1185, V t_1191, V _a1188, V _a1189, V _a1190, V[] _rest1186) => {
return Call(sp_14, V.Undef, t_1191, NewObj(2).Put("glo", ((V)(0.6))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("cuppy")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis1200, int _argc1193, V t_1199, V _a1196, V _a1197, V _a1198, V[] _rest1194) => {
Invoke(Invoke(Invoke(t_1199, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "fx", ((V)("sprinkle")), ((V)("head"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("htilt", ((V)(6D))).V, NewObj(1).Put("htilt", ((V)((-6D)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_1199);
return default;
}, 1, "", true), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("chip")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis1208, int _argc1201, V t_1207, V _a1204, V _a1205, V _a1206, V[] _rest1202) => {
Invoke(Invoke(t_1207, "osc", ((V)(800D)), ((V)(5D)), NewObj(1).Put("x", ((V)(0.7))).V, NewObj(1).Put("x", ((V)((-0.7)))).V, ((V)("l"))), "fx", ((V)("crumb")), ((V)("body")), ((V)(4D)));
Call(bk_15, V.Undef, t_1207, ((V)(300D)));
return default;
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("twisty")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis1216, int _argc1209, V t_1215, V _a1212, V _a1213, V _a1214, V[] _rest1210) => {
Invoke(Invoke(Invoke(t_1215, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.7))).Put("smile", ((V)(1D))).V), "osc", ((V)(1600D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("lean", ((V)(1.4))).V, NewObj(2).Put("tilt", ((V)((-5D)))).Put("lean", ((V)((-1.4)))).V, ((V)("s"))), "fx", ((V)("salt")), ((V)("head")));
Call(bk_15, V.Undef, t_1215);
return default;
}, 1, "", true), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("crois")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1224, int _argc1217, V t_1223, V _a1220, V _a1221, V _a1222, V[] _rest1218) => {
Invoke(t_1223, "osc", ((V)(2600D)), ((V)(2D)), NewObj(3).Put("lean", ((V)(1.6))).Put("tilt", ((V)(3D))).Put("close", ((V)(0.5))).V, NewObj(3).Put("lean", ((V)((-1.6)))).Put("tilt", ((V)((-3D)))).Put("close", ((V)(0.2))).V, ((V)("s")));
Call(bk_15, V.Undef, t_1223);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("maca")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis1232, int _argc1225, V t_1231, V _a1228, V _a1229, V _a1230, V[] _rest1226) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1231, "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_1231, "B"), "sq"), ((V)(0.12)))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_1231, "B"), "sq")) - 0.06)))).Put("hap", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("sq", Get(Get(t_1231, "B"), "sq")).V), "wait", ((V)(200D))), "to", ((V)(100D)), NewObj(1).Put("sq", Add(Get(Get(t_1231, "B"), "sq"), ((V)(0.1)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", Get(Get(t_1231, "B"), "sq")).V);
Call(bk_15, V.Undef, t_1231);
return default;
}, 1, "", true), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("puddi")), NewObj(2).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).V, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis1240, int _argc1233, V t_1239, V _a1236, V _a1237, V _a1238, V[] _rest1234) => {
Invoke(Invoke(t_1239, "osc", ((V)(1200D)), ((V)(8D)), NewObj(2).Put("sq", Add(Get(Get(t_1239, "B"), "sq"), ((V)(0.06)))).Put("x", ((V)(0.4))).V, NewObj(2).Put("sq", ((V)((ToNum(Get(Get(t_1239, "B"), "sq")) - 0.03)))).Put("x", ((V)((-0.4)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0.6))).Put("smile", ((V)(1D))).V);
Call(bk_15, V.Undef, t_1239);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis1248, int _argc1241, V t_1247, V _a1244, V _a1245, V _a1246, V[] _rest1242) => {
Invoke(t_1247, "osc", ((V)(1600D)), ((V)(4D)), NewObj(1).Put("sq", Add(Get(Get(t_1247, "B"), "sq"), ((V)(0.04)))).V, NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_1247, "B"), "sq")) - 0.02)))).V, ((V)("s")));
return default;
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("mochi")), NewObj(2).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).V, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis1256, int _argc1249, V t_1255, V _a1252, V _a1253, V _a1254, V[] _rest1250) => {
Invoke(Invoke(Invoke(t_1255, "to", ((V)(700D)), NewObj(6).Put("sq", ((V)((ToNum(Get(Get(t_1255, "B"), "sq")) - 0.16)))).Put("lift", Add(Get(Get(t_1255, "B"), "lift"), ((V)(1.6)))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("close", ((V)(0.8))).Put("open", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(6).Put("sq", Add(Get(Get(t_1255, "B"), "sq"), ((V)(0.18)))).Put("lift", ((V)((ToNum(Get(Get(t_1255, "B"), "lift")) - 0.6)))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(1).Put("sq", ((V)((ToNum(Get(Get(t_1255, "B"), "sq")) - 0.03)))).V, ((V)("o")));
Call(bk_15, V.Undef, t_1255);
return default;
}, 1, "", true), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis1264, int _argc1257, V t_1263, V _a1260, V _a1261, V _a1262, V[] _rest1258) => {
return Call(sp_14, V.Undef, t_1263, NewObj(2).Put("sq", Add(Get(Get(t_1263, "B"), "sq"), ((V)(0.12)))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "", true), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("cakey")), hop_18, NewObj(3).Put("lpose", NewObj(6).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).Put("hLx", ((V)(3D))).Put("hRx", ((V)((-3D)))).Put("hLy", ((V)(3D))).Put("hRy", ((V)(3D))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis1272, int _argc1265, V t_1271, V _a1268, V _a1269, V _a1270, V[] _rest1266) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_1271, "to", ((V)(400D)), NewObj(2).Put("puff", ((V)(0.9))).Put("pitch", ((V)((ToNum(Get(Get(t_1271, "B"), "pitch")) - 0.1)))).V), "to", ((V)(500D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0.25))).Put("mw", ((V)(0.5))).Put("pitch", Add(Get(Get(t_1271, "B"), "pitch"), ((V)(0.1)))).V, ((V)("o"))), "fx", ((V)("gust")), ((V)("head"))), "to", ((V)(300D)), NewObj(5).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", Get(Get(t_1271, "B"), "pitch")).Put("hap", ((V)(0.8))).Put("smile", ((V)(1D))).V), "wait", ((V)(400D)));
Call(bk_15, V.Undef, t_1271);
return default;
}, 1, "", true), ((V)("swing")), ((V)("kick")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("sugarplum")), hop_18, NewObj(3).Put("pose", NewObj(1).Put("pitch", ((V)(0.12))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis1280, int _argc1273, V t_1279, V _a1276, V _a1277, V _a1278, V[] _rest1274) => {
Invoke(Invoke(Invoke(t_1279, "to", ((V)(400D)), NewObj(5).Put("armR", ((V)(110D))).Put("hRy", ((V)((-2D)))).Put("smile", ((V)(1D))).Put("close", ((V)(0.4))).Put("htilt", ((V)(5D))).V, ((V)("o"))), "osc", ((V)(1600D)), ((V)(3D)), NewObj(1).Put("hRx", ((V)((-3D)))).V, NewObj(1).Put("hRx", ((V)(3D))).V, ((V)("s"))), "fx", ((V)("spark")), ((V)("head")), ((V)(3D)));
Call(bk_15, V.Undef, t_1279);
return default;
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("gourdy")), NewObj(2).Put("dn", ((V)("bounce"))).Put("up", ((V)("hop"))).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1288, int _argc1281, V t_1287, V _a1284, V _a1285, V _a1286, V[] _rest1282) => {
Invoke(t_1287, "osc", ((V)(2400D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(7D))).Put("x", ((V)(1.6))).V, NewObj(2).Put("tilt", ((V)((-7D)))).Put("x", ((V)((-1.6)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_1287);
return default;
}, 1, "", true), ((V)("swing")), ((V)("hum")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), Fn((V _arrowThis1296, int _argc1289, V t_1295, V _a1292, V _a1293, V _a1294, V[] _rest1290) => {
return Call(sp_14, V.Undef, t_1295, NewObj(2).Put("tilt", ((V)((-9D)))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1200D)));
}, 1, "", true))).V);
Call(mk_21, V.Undef, ((V)("batty")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1304, int _argc1297, V t_1303, V _a1300, V _a1301, V _a1302, V[] _rest1298) => {
Invoke(Invoke(t_1303, "to", ((V)(400D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(14D)), ((V)((-2D)))), NewObj(4).Put("armL", ((V)(36D))).Put("armR", ((V)(36D))).Put("close", ((V)(0.5))).Put("smile", ((V)(0.8))).V)), "wait", ((V)(1400D)));
Call(bk_15, V.Undef, t_1303, ((V)(500D)));
return default;
}, 1, "", true), Fn((V _arrowThis1312, int _argc1305, V t_1311, V _a1308, V _a1309, V _a1310, V[] _rest1306) => {
Invoke(Invoke(t_1311, "to", ((V)(160D)), NewObj(1).Put("hap", ((V)(0.7))).V), "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, NewObj(2).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("o")));
Call(bk_15, V.Undef, t_1311);
return default;
}, 1, "", true), ((V)("swing")))).Put("lf", Arr(((V)("doze")), ((V)("sigh")), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("kernel")), NewObj(2).Put("dn", ((V)("climb"))).Put("up", ((V)("hop"))).V, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1320, int _argc1313, V t_1319, V _a1316, V _a1317, V _a1318, V[] _rest1314) => {
Invoke(t_1319, "osc", ((V)(1400D)), ((V)(4D)), NewObj(3).Put("x", ((V)(1D))).Put("footL", ((V)(2D))).Put("footR", ((V)(0D))).V, NewObj(3).Put("x", ((V)((-1D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).V, ((V)("s")));
Call(bk_15, V.Undef, t_1319);
return default;
}, 1, "", true), ((V)("kick")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("hexie")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1328, int _argc1321, V t_1327, V _a1324, V _a1325, V _a1326, V[] _rest1322) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_1327, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(4D)), ((V)((-18D)))), NewObj(2).Put("armR", ((V)(120D))).Put("htilt", ((V)(8D))).V), ((V)("o"))), "wait", ((V)(300D))), "fx", ((V)("spark")), ((V)("head")), ((V)(4D))), "to", ((V)(300D)), NewObj(2).Put("winkR", ((V)(1D))).Put("smile", ((V)(1D))).V), "wait", ((V)(400D)));
Call(bk_15, V.Undef, t_1327);
return default;
}, 1, "", true), ((V)("ears")), ((V)("swing")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), Fn((V _arrowThis1336, int _argc1329, V t_1335, V _a1332, V _a1333, V _a1334, V[] _rest1330) => {
return Call(sp_14, V.Undef, t_1335, NewObj(2).Put("curl", ((V)(0.7))).Put("close", ((V)(1D))).V, ((V)(1600D)), ((V)(1400D)));
}, 1, "", true), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("mumbles")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1344, int _argc1337, V t_1343, V _a1340, V _a1341, V _a1342, V[] _rest1338) => {
Invoke(Invoke(t_1343, "to", ((V)(600D)), NewObj(6).Put("armL", ((V)(88D))).Put("armR", ((V)(88D))).Put("hLy", ((V)((-2D)))).Put("hRy", ((V)((-2D)))).Put("close", ((V)(0.6))).Put("open", ((V)(0.25))).V, ((V)("io"))), "osc", ((V)(1400D)), ((V)(2D)), NewObj(1).Put("lean", ((V)(1.2))).V, NewObj(1).Put("lean", ((V)((-1.2)))).V, ((V)("s")));
Call(bk_15, V.Undef, t_1343, ((V)(600D)));
return default;
}, 1, "", true), ((V)("swing")), ((V)("giggle")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
Call(mk_21, V.Undef, ((V)("hocus")), hop_18, NewObj(2).Put("f", Arr(((V)("look")), Fn((V _arrowThis1352, int _argc1345, V t_1351, V _a1348, V _a1349, V _a1350, V[] _rest1346) => {
Invoke(Invoke(Invoke(Invoke(t_1351, "to", ((V)(400D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(8D)), ((V)((-4D)))), NewObj(3).Put("armR", ((V)(50D))).Put("ly", ((V)(0.6))).Put("close", ((V)(0.3))).V)), "fx", ((V)("spark")), ((V)("body")), ((V)(4D))), "wait", ((V)(800D))), "fx", ((V)("spark")), ((V)("body")), ((V)(3D)));
Call(bk_15, V.Undef, t_1351);
return default;
}, 1, "", true), ((V)("nod")), ((V)("swing")))).Put("lf", Arr(((V)("doze")), ((V)("sigh")), ((V)("belly")))).V);
Call(mk_21, V.Undef, ((V)("countsquishula")), hop_18, NewObj(3).Put("pose", NewObj(1).Put("pitch", ((V)(0.12))).V).Put("f", Arr(((V)("look")), Fn((V _arrowThis1360, int _argc1353, V t_1359, V _a1356, V _a1357, V _a1358, V[] _rest1354) => {
Invoke(Invoke(Invoke(Invoke(t_1359, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)((-1D))), ((V)((-6D))), ((V)((-10D)))), NewObj(3).Put("armL", ((V)(90D))).Put("lean", ((V)((-1.2)))).Put("htilt", ((V)((-5D)))).V), ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(3).Put("smile", ((V)(1D))).Put("open", ((V)(0.2))).Put("winkL", ((V)(1D))).V), "wait", ((V)(500D)));
Call(bk_15, V.Undef, t_1359);
return default;
}, 1, "", true), ((V)("swing")), ((V)("pat")))).Put("lf", Arr(((V)("sigh")), ((V)("doze")), ((V)("belly")), ((V)("stretch")))).V);
return default;
}, 1, "", false));
        }
    }
}
