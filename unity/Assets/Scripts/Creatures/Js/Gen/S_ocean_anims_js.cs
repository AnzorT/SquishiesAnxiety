// ocean-anims.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_ocean_anims_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V KEYS_8 = default;
if (_self1.IsNullish) _self1 = GlobalV;
KEYS_8 = Arr(((V)("shelly")), ((V)("seaturtle")));
Call(Named(boot_34 => Fn((V _self9, int _argc10, V _a12, V _a13, V _a14, V _a15, V[] _rest11) => {
V R_16 = default;
V TL_17 = default;
V o_18 = default;
V jump_19 = default;
V look_20 = default;
V shake_21 = default;
V swing_22 = default;
V jelly_23 = default;
V land_24 = default;
V install_25 = default;
V loopN_26 = default;
V spinR_27 = default;
V duck_28 = default;
V popOut_29 = default;
V stroke_30 = default;
V CARDS_31 = default;
V MOVES_32 = default;
V DANCES_33 = default;
if (_self9.IsNullish) _self9 = GlobalV;
R_16 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_16)) || !(Truthy(Get(R_16, "PETLIB")))) || !(Truthy(Get(Get(R_16, "PETLIB"), "install")))) || !(Truthy(Get(R_16, "SOFT"))))) {
Call(G("setTimeout"), V.Undef, boot_34.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_16, "oceanV"))) {
return default;
}
Set(R_16, "oceanV", ((V)(1D)));
Invoke(Arr(((V)("hid")), ((V)("nk")), ((V)("swim")), ((V)("dz"))), "forEach", Fn((V _self9, int _argc35, V k_41, V _a38, V _a39, V _a40, V[] _rest36) => {
if (GetK(Get(R_16, "REST"), k_41).IsNullish) {
SetK(Get(R_16, "REST"), k_41, ((V)(0D)));
}
return default;
}, 1, "", true));
{ V _t42 = Get(R_16, "PETLIB");
if (_t42.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t42));
{ V _t43 = Get(_t42, "TL");
TL_17 = _t43; }
{ V _t44 = Get(_t42, "o");
o_18 = _t44; }
{ V _t45 = Get(_t42, "jump");
jump_19 = _t45; }
{ V _t46 = Get(_t42, "look");
look_20 = _t46; }
{ V _t47 = Get(_t42, "shake");
shake_21 = _t47; }
{ V _t48 = Get(_t42, "swing");
swing_22 = _t48; }
{ V _t49 = Get(_t42, "jelly");
jelly_23 = _t49; }
{ V _t50 = Get(_t42, "land");
land_24 = _t50; }
{ V _t51 = Get(_t42, "install");
install_25 = _t51; } }
Invoke(KEYS_8, "forEach", Fn((V _self9, int _argc52, V k_58, V _a55, V _a56, V _a57, V[] _rest53) => {
return Invoke(Get(R_16, "SOFT"), "add", k_58);
}, 1, "", true));
loopN_26 = Fn((V _self9, int _argc59, V t_65, V n_66, V _a63, V _a64, V[] _rest60) => {
return Object_assign(Invoke(t_65, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_65, "t")) * ToNum((n_66 is var _t67 && Truthy(_t67) ? _t67 : ((V)(3D)))))))).V);
}, 2, "", true);
spinR_27 = Fn((V _self9, int _argc68, V t_74, V dur_75, V deg_76, V x_77, V[] _rest69) => {
V a_79 = default;
V ez_78 = default;
ez_78 = (_argc68 > 4 ? _rest69[0] : V.Undef);
a_79 = Get(t_74, "t");
Invoke(Invoke(t_74, "to", dur_75, Call(o_18, V.Undef, NewObj(1).Put("spin", deg_76).V, (x_77 is var _t80 && Truthy(_t80) ? _t80 : NewObj(0).V)), (ez_78 is var _t81 && Truthy(_t81) ? _t81 : ((V)("io")))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
return a_79;
return default;
}, 5, "", true);
duck_28 = Fn((V _self9, int _argc82, V t_88, V x_89, V _a86, V _a87, V[] _rest83) => {
return Invoke(Invoke(Invoke(t_88, "to", ((V)(110D)), NewObj(3).Put("nk", ((V)(0.35))).Put("wide", ((V)(0.6))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(120D)), Call(o_18, V.Undef, NewObj(4).Put("hid", ((V)(1D))).Put("sq", ((V)(0.14))).Put("wide", ((V)(0D))).Put("nk", ((V)(0D))).V, (x_89 is var _t90 && Truthy(_t90) ? _t90 : NewObj(0).V)), ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.06))).V, ((V)("io")));
}, 2, "", true);
popOut_29 = Fn((V _self9, int _argc91, V t_97, V x_98, V _a95, V _a96, V[] _rest92) => {
return Invoke(Invoke(Invoke(Invoke(t_97, "to", ((V)(160D)), Call(o_18, V.Undef, NewObj(4).Put("hid", ((V)(0D))).Put("nk", ((V)(1.1))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(1.5))).V, (x_98 is var _t99 && Truthy(_t99) ? _t99 : NewObj(0).V)), ((V)("o"))), "to", ((V)(220D)), NewObj(3).Put("nk", ((V)(0.25))).Put("sq", ((V)(0.04))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("nk", ((V)(0.45))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(1).Put("nk", ((V)(0.3))).V, ((V)("io")));
}, 2, "", true);
stroke_30 = Fn((V _self9, int _argc100, V t_106, V n_107, V per_108, V lift_109, V[] _rest101) => {
{
V i_110 = default;
i_110 = ((V)(0D));
while (true) {
if (!(Lt(i_110, n_107))) break;
Invoke(Invoke(t_106, "to", ((V)((ToNum(per_108) * 0.45))), NewObj(4).Put("armL", ((V)(115D))).Put("armR", ((V)(115D))).Put("lift", Add((lift_109 is var _t113 && Truthy(_t113) ? _t113 : ((V)(0D))), ((V)(1.2)))).Put("pitch", ((V)(0.04))).V, ((V)("o"))), "to", ((V)((ToNum(per_108) * 0.55))), NewObj(4).Put("armL", ((V)((-15D)))).Put("armR", ((V)((-15D)))).Put("lift", (lift_109 is var _t112 && Truthy(_t112) ? _t112 : ((V)(0D)))).Put("pitch", ((V)((-0.02)))).V, ((V)("io")));
PostInc(ref i_110, 1D);
}
}
return t_106;
return default;
}, 4, "", true);
CARDS_31 = NewObj(2).Put("shelly", NewObj(4).Put("T", ((V)(1.15))).Put("b", ((V)(0.85))).Put("s", ((V)(0.95))).Put("w", ((V)(1D))).V).Put("seaturtle", NewObj(4).Put("T", ((V)(1.1))).Put("b", ((V)(0.9))).Put("s", ((V)(1D))).Put("w", ((V)(1D))).V).V;
MOVES_32 = NewObj(2).Put("shelly", NewObj(7).Put("happy", Arr(Call(Fn((V _self9, int _argc114, V _a116, V _a117, V _a118, V _a119, V[] _rest115) => {
V t_120 = default;
t_120 = Call(TL_17, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)(1.1)));
Invoke(Invoke(t_120, "to", ((V)(160D)), NewObj(2).Put("lx", ((V)(0D))).Put("ly", ((V)((-0.4)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(3).Put("nk", ((V)(1.3))).Put("pitch", ((V)(0.14))).Put("sq", ((V)((-0.04)))).V, ((V)("o")));
Invoke(Invoke(Invoke(Invoke(t_120, "to", ((V)(260D)), NewObj(4).Put("armL", ((V)(70D))).Put("armR", ((V)(0D))).Put("tilt", ((V)((-3D)))).Put("wag", ((V)(20D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(70D))).Put("tilt", ((V)(3D))).Put("wag", ((V)((-20D)))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(4).Put("armL", ((V)(70D))).Put("armR", ((V)(0D))).Put("tilt", ((V)((-3D)))).Put("wag", ((V)(20D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(7).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("tilt", ((V)(0D))).Put("wag", ((V)(0D))).Put("nk", ((V)(0.6))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Call(jump_19, V.Undef, t_120, NewObj(6).Put("h", ((V)(4D))).Put("ant", ((V)(170D))).Put("up", ((V)(200D))).Put("c", ((V)(0.12))).Put("arm", ((V)(30D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(2D))))).V);
return Call(loopN_26, V.Undef, Invoke(t_120, "rest", ((V)(320D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Stretches her neck up with a big smile, flaps her flippers left and right, then a little shell hop.")))).Put("surprised", Arr(Call(Fn((V _self9, int _argc121, V _a123, V _a124, V _a125, V _a126, V[] _rest122) => {
V t_127 = default;
t_127 = Call(TL_17, V.Undef);
Invoke(Invoke(t_127, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("nk", ((V)(0.5))).V, ((V)("o")));
Call(duck_28, V.Undef, t_127);
Invoke(t_127, "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D)));
Invoke(Invoke(Invoke(t_127, "osc", ((V)(600D)), ((V)(4D)), NewObj(1).Put("tilt", ((V)(2.2))).V, NewObj(1).Put("tilt", ((V)((-2.2)))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_127, "to", ((V)(380D)), NewObj(3).Put("hid", ((V)(0.55))).Put("wide", ((V)(0.3))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("lx", ((V)((-0.9)))).V, ((V)("o"))), "wait", ((V)(220D))), "to", ((V)(260D)), NewObj(1).Put("lx", ((V)(0.9))).V, ((V)("io"))), "wait", ((V)(220D))), "to", ((V)(160D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("io")));
Call(popOut_29, V.Undef, t_127, NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("wide", ((V)(0D))).Put("mw", ((V)(1D))).V);
return Invoke(Invoke(t_127, "rest", ((V)(420D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Eyes pop and she snaps into her shell, it trembles, she peeks out with darting eyes, then pops back out relieved.")))).Put("squish", Arr(Call(Fn((V _self9, int _argc128, V _a130, V _a131, V _a132, V _a133, V[] _rest129) => {
V t_134 = default;
t_134 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_134, "to", ((V)(150D)), NewObj(2).Put("sq", ((V)((-0.04)))).Put("nk", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.3))).Put("hid", ((V)(0.85))).Put("hap", ((V)(0.9))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(t_134, "to", ((V)(140D)), NewObj(8).Put("hid", ((V)(0D))).Put("nk", ((V)(1.5))).Put("sq", ((V)((-0.14)))).Put("close", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(3D))), "to", ((V)(200D)), NewObj(4).Put("nk", ((V)(0.6))).Put("sq", ((V)(0.06))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("io")));
Call(jelly_23, V.Undef, t_134, ((V)(0.5)), ((V)(3D)), ((V)(300D)), ((V)("nk")));
Invoke(t_134, "to", ((V)(200D)), NewObj(7).Put("nk", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_134);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, she pulls into her shell; let go and her neck boings out and wobbles.")))).Put("quirk", Arr(Call(Fn((V _self9, int _argc135, V _a137, V _a138, V _a139, V _a140, V[] _rest136) => {
V t_141 = default;
t_141 = Call(TL_17, V.Undef);
Invoke(t_141, "to", ((V)(500D)), NewObj(8).Put("nk", ((V)(1.25))).Put("pitch", ((V)(0.2))).Put("close", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)((-18D)))).Put("armR", ((V)((-18D)))).Put("footL", ((V)(1D))).Put("footR", ((V)(1D))).V, ((V)("io")));
Invoke(Invoke(t_141, "osc", ((V)(1600D)), ((V)(2D)), NewObj(2).Put("sq", ((V)((-0.03)))).Put("lift", ((V)(0.4))).V, NewObj(2).Put("sq", ((V)(0.02))).Put("lift", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_141, "to", ((V)(420D)), NewObj(2).Put("pitch", ((V)(0.05))).Put("nk", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(1).Put("close", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("close", ((V)(1D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("nk", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_141, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sunbathe")), ((V)("Stretches her neck out to the sun with her flippers spread and eyes shut, two slow happy breaths, a slow turtle blink.")))).Put("press", NewObj(2).Put("hid", ((V)(0.55))).Put("sq", ((V)(0.06))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(5).Put("hid", Arr(Arr(((V)(0D)), ((V)(0.55))), Arr(((V)(140D)), ((V)(0D)), ((V)("o"))))).Put("nk", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(1.3)), ((V)("o"))), Arr(((V)(420D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(650D)), ((V)(0.45)), ((V)("io"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(270D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(430D)), ((V)(0D)), ((V)("io"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(40D)), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(40D)), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("bubble")), ((V)("head")), ((V)(3D))))).V).Put("look", Call(Fn((V _self9, int _argc142, V _a144, V _a145, V _a146, V _a147, V[] _rest143) => {
V t_148 = default;
t_148 = Call(TL_17, V.Undef);
Invoke(t_148, "to", ((V)(320D)), NewObj(1).Put("nk", ((V)(0.55))).V, ((V)("io")));
Call(look_20, V.Undef, t_148, ((V)(0D)), ((V)((-0.6))), NewObj(1).Put("k", ((V)(0.7))).V);
Invoke(t_148, "wait", ((V)(700D)));
Call(look_20, V.Undef, t_148, ((V)((-0.6))), ((V)(0.6)), NewObj(3).Put("k", ((V)(0.7))).Put("d1", ((V)(210D))).Put("d2", ((V)(250D))).V);
Invoke(t_148, "wait", ((V)(700D)));
Call(look_20, V.Undef, t_148, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.7))).V);
return Invoke(Invoke(Invoke(t_148, "to", ((V)(320D)), NewObj(1).Put("nk", ((V)(0D))).V, ((V)("io"))), "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("seaturtle", NewObj(7).Put("happy", Arr(Call(Fn((V _self9, int _argc149, V _a151, V _a152, V _a153, V _a154, V[] _rest150) => {
V t_155 = default;
t_155 = Call(TL_17, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)(1.05)));
Invoke(Invoke(t_155, "to", ((V)(160D)), NewObj(1).Put("ly", ((V)((-0.4)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("nk", ((V)(0.9))).Put("pitch", ((V)(0.12))).V, ((V)("o")));
{
V i_156 = default;
i_156 = ((V)(0D));
while (true) {
if (!(LtN(i_156, 3D))) break;
Invoke(Invoke(t_155, "to", ((V)(200D)), NewObj(5).Put("armL", ((V)(75D))).Put("armR", ((V)(75D))).Put("lift", ((V)(1.2))).Put("sq", ((V)((-0.03)))).Put("wag", ((V)(14D))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(5).Put("armL", ((V)(5D))).Put("armR", ((V)(5D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.02))).Put("wag", ((V)((-14D)))).V, ((V)("io")));
PostInc(ref i_156, 1D);
}
}
Invoke(t_155, "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(3D)));
Invoke(t_155, "to", ((V)(260D)), NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wag", ((V)(0D))).Put("nk", ((V)(0.5))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Call(jump_19, V.Undef, t_155, NewObj(5).Put("h", ((V)(3D))).Put("ant", ((V)(160D))).Put("up", ((V)(200D))).Put("c", ((V)(0.1))).Put("arm", ((V)(0D))).V);
return Call(loopN_26, V.Undef, Invoke(t_155, "rest", ((V)(320D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Lifts its head with a big smile, flaps both front flippers three times like a swim stroke (bubbles!), then a little hop.")))).Put("surprised", Arr(Call(Fn((V _self9, int _argc158, V _a160, V _a161, V _a162, V _a163, V[] _rest159) => {
V t_164 = default;
t_164 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_164, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(8).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("nk", ((V)(0.8))).Put("armL", ((V)(95D))).Put("armR", ((V)(95D))).Put("lift", ((V)(2.5))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(2D)));
Invoke(Invoke(t_164, "to", ((V)(180D)), NewObj(5).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("nk", ((V)((-0.3)))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_164, "to", ((V)(260D)), NewObj(1).Put("lx", ((V)((-0.9)))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.9))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(220D)), NewObj(2).Put("lx", ((V)(0D))).Put("wide", ((V)(0.3))).V, ((V)("io")));
Invoke(t_164, "to", ((V)(320D)), NewObj(8).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("nk", ((V)(0.2))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_164, "rest", ((V)(420D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Eyes pop and both flippers fly up, it plops back down with its neck tucked, looks left and right, then relaxes with a smile.")))).Put("squish", Arr(Call(Fn((V _self9, int _argc165, V _a167, V _a168, V _a169, V _a170, V[] _rest166) => {
V t_171 = default;
t_171 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_171, "to", ((V)(150D)), NewObj(2).Put("sq", ((V)((-0.04)))).Put("nk", ((V)(0.2))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(8).Put("sq", ((V)(0.3))).Put("armL", ((V)((-25D)))).Put("armR", ((V)((-25D)))).Put("footL", ((V)(3D))).Put("footR", ((V)(3D))).Put("nk", ((V)((-0.4)))).Put("hap", ((V)(0.9))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(t_171, "to", ((V)(140D)), NewObj(9).Put("sq", ((V)((-0.14)))).Put("nk", ((V)(1D))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("close", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(3D))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0.06))).Put("nk", ((V)(0.4))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("io")));
Call(jelly_23, V.Undef, t_171, ((V)(0.5)), ((V)(3D)), ((V)(300D)), ((V)("nk")));
Invoke(t_171, "to", ((V)(200D)), NewObj(7).Put("nk", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_171);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed flat with its flippers splayed out; let go and it boings up with both flippers raised, its neck wobbling.")))).Put("quirk", Arr(Call(Fn((V _self9, int _argc172, V _a174, V _a175, V _a176, V _a177, V[] _rest173) => {
V t_178 = default;
t_178 = Call(TL_17, V.Undef);
Invoke(t_178, "to", ((V)(500D)), NewObj(4).Put("close", ((V)(1D))).Put("smile", ((V)(1D))).Put("nk", ((V)(0.5))).Put("pitch", ((V)(0.06))).V, ((V)("io")));
{
V i_179 = default;
i_179 = ((V)(0D));
while (true) {
if (!(LtN(i_179, 3D))) break;
Invoke(Invoke(Invoke(t_178, "to", ((V)(520D)), NewObj(6).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("lift", ((V)(0.8))).Put("tilt", ((V)((NumTruthy((ToNum(i_179) % 2D)) ? 2D : (-2D))))).V, ((V)("io"))), "to", ((V)(620D)), NewObj(6).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(1D)));
PostInc(ref i_179, 1D);
}
}
Invoke(Invoke(Invoke(Invoke(t_178, "to", ((V)(300D)), NewObj(1).Put("close", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("close", ((V)(1D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("nk", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_178, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sea Dream")), ((V)("Closes its eyes and dreams of the sea: three slow swimming strokes with its big flippers, bubbles rising, a slow blink.")))).Put("press", NewObj(3).Put("sq", ((V)(0.1))).Put("armL", ((V)((-12D)))).Put("armR", ((V)((-12D)))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(4).Put("nk", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(1D)), ((V)("o"))), Arr(((V)(420D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(270D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(430D)), ((V)(0D)), ((V)("io"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(60D)), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(60D)), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("bubble")), ((V)("head")), ((V)(3D))))).V).Put("look", Call(Fn((V _self9, int _argc181, V _a183, V _a184, V _a185, V _a186, V[] _rest182) => {
V t_187 = default;
t_187 = Call(TL_17, V.Undef);
Invoke(t_187, "to", ((V)(320D)), NewObj(1).Put("nk", ((V)(0.5))).V, ((V)("io")));
Call(look_20, V.Undef, t_187, ((V)(0D)), ((V)((-0.6))), NewObj(1).Put("k", ((V)(0.7))).V);
Invoke(t_187, "wait", ((V)(700D)));
Call(look_20, V.Undef, t_187, ((V)((-0.6))), ((V)(0.6)), NewObj(3).Put("k", ((V)(0.7))).Put("d1", ((V)(210D))).Put("d2", ((V)(250D))).V);
Invoke(t_187, "wait", ((V)(700D)));
Call(look_20, V.Undef, t_187, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.7))).V);
return Invoke(Invoke(Invoke(t_187, "to", ((V)(320D)), NewObj(1).Put("nk", ((V)(0D))).V, ((V)("io"))), "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).V;
DANCES_33 = NewObj(2).Put("shelly", Arr(Call(Fn((V _self9, int _argc188, V _a190, V _a191, V _a192, V _a193, V[] _rest189) => {
V t_194 = default;
V d_195 = default;
V V_196 = default;
V s0_197 = default;
V END_198 = default;
V RUN_199 = default;
V TOT_200 = default;
V nW_201 = default;
V sk_202 = default;
V sk2_203 = default;
t_194 = Call(TL_17, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
d_195 = ((V)(1D));
Invoke(Invoke(t_194, "to", ((V)(220D)), NewObj(3).Put("nk", ((V)(0.9))).Put("sq", ((V)((-0.04)))).Put("hap", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(3).Put("nk", ((V)(0.6))).Put("pitch", ((V)((-0.08)))).Put("sq", ((V)(0.03))).V, ((V)("io")));
Call(duck_28, V.Undef, t_194, NewObj(2).Put("hap", ((V)(1D))).Put("pitch", ((V)(0D))).V);
Invoke(t_194, "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(3D)));
Invoke(t_194, "wait", ((V)(140D)));
Invoke(t_194, "to", ((V)(75D)), NewObj(3).Put("tilt", ((V)((1.5 * ToNum(d_195))))).Put("lean", ((V)((0.4 * ToNum(d_195))))).Put("sq", ((V)(0.03))).V, ((V)("io")));
Invoke(t_194, "to", ((V)(155D)), NewObj(6).Put("sq", ((V)(0.14))).Put("spin", ((V)(((-32D) * ToNum(d_195))))).Put("turn", ((V)(((-0.12) * ToNum(d_195))))).Put("tilt", ((V)(((-3D) * ToNum(d_195))))).Put("lean", ((V)(((-1D) * ToNum(d_195))))).Put("wag", ((V)((14D * ToNum(d_195))))).V, ((V)("o")));
Invoke(t_194, "to", ((V)(100D)), NewObj(2).Put("sq", ((V)(0.16))).Put("spin", ((V)(((-36D) * ToNum(d_195))))).V, ((V)("io")));
V_196 = ((V)(1980D));
s0_197 = Get(t_194, "t");
END_198 = ((V)((59D * 360D)));
RUN_199 = ((V)(Round((((ToNum(Add(END_198, ((V)(18D)))) - 40D) / ToNum(V_196)) * 1000D))));
TOT_200 = Add(Add(((V)(50D)), RUN_199), ((V)(200D)));
Invoke(Invoke(Invoke(t_194, "to", ((V)(50D)), NewObj(5).Put("sblur", ((V)(0.5))).Put("sq", ((V)((-0.1)))).Put("turn", ((V)(0D))).Put("tilt", ((V)((4D * ToNum(d_195))))).Put("lean", ((V)((0.6 * ToNum(d_195))))).V, ((V)("l"))), "to", ((V)(110D)), NewObj(4).Put("sq", ((V)(0.08))).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.04))).V, ((V)("io")));
Invoke(Invoke(t_194, "at", s0_197), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D)));
Invoke(t_194, "at", Add(s0_197, ((V)(250D))));
nW_201 = ((V)(System.Math.Floor(((ToNum(TOT_200) - 750D) / 400D))));
{
V i_204 = default;
i_204 = ((V)(0D));
while (true) {
if (!(Lt(i_204, nW_201))) break;
V g_206 = default;
V w_207 = default;
g_206 = ((V)((Min(1D, (ToNum(i_204) / 3D)) * (GtN(i_204, (ToNum(nW_201) - 4D)) ? ((ToNum(nW_201) - ToNum(i_204)) / 4D) : 1D))));
w_207 = ((V)((2D + (4D * ToNum(g_206)))));
Invoke(Invoke(t_194, "to", ((V)(200D)), NewObj(2).Put("tilt", w_207).Put("lean", ((V)((ToNum(w_207) * 0.5)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("tilt", ((V)((-ToNum(w_207))))).Put("lean", ((V)(((-ToNum(w_207)) * 0.5)))).V, ((V)("io")));
PostInc(ref i_204, 1D);
}
}
Invoke(t_194, "to", ((V)(300D)), NewObj(2).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
Invoke(Arr(((V)(3200D)), ((V)(8200D))), "forEach", Fn((V _self9, int _argc208, V h_214, V _a211, V _a212, V _a213, V[] _rest209) => {
Invoke(t_194, "at", Add(s0_197, h_214));
Call(jump_19, V.Undef, t_194, NewObj(6).Put("h", ((V)(5D))).Put("ant", ((V)(140D))).Put("up", ((V)(220D))).Put("c", ((V)(0.1))).Put("arm", ((V)(0D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("spark")), ((V)("body")), ((V)(3D))))).V);
return default;
}, 1, "", true));
{
V k_215 = default;
k_215 = ((V)(0D));
while (true) {
if (!(((ToNum(k_215) * 400D) < (ToNum(TOT_200) - 300D)))) break;
Invoke(Invoke(t_194, "at", Add(Add(s0_197, ((V)(250D))), ((V)((ToNum(k_215) * 400D))))), "e", ((V)("emit")), ((V)((NumTruthy((ToNum(k_215) % 2D)) ? "spark" : "dust"))), ((V)("body")), ((V)((NumTruthy((ToNum(k_215) % 2D)) ? 2D : 1D))));
PostInc(ref k_215, 1D);
}
}
Invoke(Invoke(t_194, "at", Add(Add(s0_197, ((V)(50D))), RUN_199)), "to", ((V)(200D)), NewObj(2).Put("sblur", ((V)(0D))).Put("sq", ((V)(0.12))).V, ((V)("o")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_194, "at", s0_197), "to", ((V)(50D)), NewObj(1).Put("spin", ((V)((40D * ToNum(d_195))))).V, ((V)("l"))), "to", RUN_199, NewObj(1).Put("spin", ((V)((ToNum(Add(END_198, ((V)(18D)))) * ToNum(d_195))))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(1).Put("spin", ((V)((ToNum(END_198) * ToNum(d_195))))).V, ((V)("o"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(t_194, "at", Add(Add(s0_197, TOT_200), ((V)(60D))));
Call(popOut_29, V.Undef, t_194, NewObj(5).Put("cross", ((V)(1D))).Put("open", ((V)(0.4))).Put("hap", ((V)(0D))).Put("smile", ((V)(0.4))).Put("wide", ((V)(0.4))).V);
Invoke(Invoke(t_194, "at", Add(Add(s0_197, TOT_200), ((V)(120D)))), "to", ((V)(320D)), NewObj(1).Put("dz", ((V)(1D))).V, ((V)("o")));
Invoke(Invoke(t_194, "osc", ((V)(1500D)), ((V)(3D)), NewObj(5).Put("htilt", ((V)(10D))).Put("tilt", ((V)(3.5))).Put("nk", ((V)(0.6))).Put("x", ((V)(1.2))).Put("hyaw", ((V)(0.12))).V, NewObj(5).Put("htilt", ((V)((-10D)))).Put("tilt", ((V)((-3.5)))).Put("nk", ((V)(0.15))).Put("x", ((V)((-1.2)))).Put("hyaw", ((V)((-0.12)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(5).Put("htilt", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("nk", ((V)(0.3))).V, ((V)("io")));
sk_202 = Get(t_194, "t");
Call(shake_21, V.Undef, t_194, NewObj(6).Put("P", ((V)(115D))).Put("env", Arr(((V)(0.7)), ((V)(1D)), ((V)(0.55)), ((V)(0.2)))).Put("head", ((V)(0.3))).Put("roll", ((V)(5D))).Put("ear", ((V)(0D))).Put("chest", ((V)(0.05))).V);
sk2_203 = Get(t_194, "t");
Invoke(Invoke(Invoke(t_194, "at", Add(sk_202, ((V)(150D)))), "to", ((V)((ToNum(sk2_203) - ToNum(sk_202)))), NewObj(1).Put("dz", ((V)(0D))).V, ((V)("io"))), "at", sk2_203);
Invoke(t_194, "to", ((V)(220D)), NewObj(5).Put("cross", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.45))).V, ((V)("io")));
Invoke(t_194, "wait", ((V)(200D)));
return Invoke(Invoke(t_194, "rest", ((V)(260D))), "loop", NewObj(2).Put("stretch", ((V)(0.6))).Put("whip", ((V)(1D))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Shell Spin")), ((V)("Ducks into her shell, then gets ready like a pirouette (the shell coils the other way and holds), whips round with a blur - and keeps spinning super fast (5.5 turns a second) for over 10 seconds like a spinning top (two hops along the way), lands facing you, pops out dizzy and cross-eyed with cartoon stars circling over her head, shakes it off - and goes again, until you stop her.")))).Put("seaturtle", Arr(Call(Fn((V _self9, int _argc217, V _a219, V _a220, V _a221, V _a222, V[] _rest218) => {
V t_223 = default;
V stroke2_224 = default;
t_223 = Call(TL_17, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
stroke2_224 = Fn((V _self9, int _argc225, V dur_231, V x_232, V tl_233, V _a230, V[] _rest226) => {
return Invoke(Invoke(t_223, "to", ((V)((ToNum(dur_231) * 0.45))), NewObj(8).Put("armL", ((V)(85D))).Put("armR", ((V)(85D))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("lift", ((V)(1.4))).Put("x", x_232).Put("tilt", tl_233).Put("nk", ((V)(0.6))).V, ((V)("o"))), "to", ((V)((ToNum(dur_231) * 0.55))), NewObj(6).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).Put("nk", ((V)(0.3))).V, ((V)("io")));
}, 3, "", true);
Invoke(Invoke(t_223, "to", ((V)(300D)), NewObj(2).Put("nk", ((V)(0.7))).Put("pitch", ((V)(0.08))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(2D)));
Call(stroke2_224, V.Undef, ((V)(900D)), ((V)((-4D))), ((V)((-4D))));
Call(stroke2_224, V.Undef, ((V)(900D)), ((V)((-7D))), ((V)((-5D))));
Invoke(t_223, "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(2D)));
Call(stroke2_224, V.Undef, ((V)(900D)), ((V)(4D)), ((V)(4D)));
Call(stroke2_224, V.Undef, ((V)(900D)), ((V)(7D)), ((V)(5D)));
Invoke(t_223, "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(2D)));
Invoke(Invoke(Invoke(t_223, "to", ((V)(500D)), NewObj(5).Put("x", ((V)(0D))).Put("tilt", ((V)((-14D)))).Put("lean", ((V)((-4D)))).Put("armL", ((V)(90D))).Put("armR", ((V)((-10D)))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(4).Put("tilt", ((V)(14D))).Put("lean", ((V)(4D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)(90D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(4).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
{
V i_234 = default;
i_234 = ((V)(0D));
while (true) {
if (!(LtN(i_234, 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_223, "to", ((V)(220D)), NewObj(2).Put("armR", ((V)(100D))).Put("hyaw", ((V)(0.2))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(1).Put("armR", ((V)(60D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(1).Put("armR", ((V)(100D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("armR", ((V)(0D))).Put("hyaw", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_234, 1D);
}
}
Invoke(t_223, "to", ((V)(700D)), NewObj(2).Put("spin", ((V)(90D))).Put("nk", ((V)(0.8))).V, ((V)("io")));
Call(stroke2_224, V.Undef, ((V)(800D)), ((V)(0D)), ((V)(0D)));
Call(stroke2_224, V.Undef, ((V)(800D)), ((V)(0D)), ((V)(0D)));
Invoke(t_223, "to", ((V)(700D)), NewObj(2).Put("spin", ((V)(0D))).Put("nk", ((V)(0.4))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_223, "to", ((V)(1400D)), NewObj(7).Put("spin", ((V)(360D))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).Put("footL", ((V)(3D))).Put("footR", ((V)(3D))).Put("lift", ((V)(2D))).Put("nk", ((V)(0.9))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("body")), ((V)(4D))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_223, "to", ((V)(400D)), NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).Put("nk", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("winkL", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(1).Put("winkL", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return Invoke(Invoke(t_223, "rest", ((V)(400D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Ocean Glide")), ((V)("Swims on the spot: gliding strokes to the left and right with its big flippers, a slow graceful roll, waves a flipper at you, turns to show its side as it swims past, a dreamy full turn on the current, bubbles all along, then a wink.")))).V;
Invoke(KEYS_8, "forEach", Fn((V _self9, int _argc236, V k_242, V _a239, V _a240, V _a241, V[] _rest237) => {
Set(GetK(MOVES_32, k_242), "dance", GetK(DANCES_33, k_242));
return default;
}, 1, "", true));
Call(install_25, V.Undef, MOVES_32, CARDS_31);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_270 => Fn((V _self243, int _argc244, V _a246, V _a247, V _a248, V _a249, V[] _rest245) => {
V R_250 = default;
V S_251 = default;
V o_252 = default;
V jump_253 = default;
V shake_254 = default;
V jelly_255 = default;
V see_256 = default;
V unsee_257 = default;
V giggle_258 = default;
V sniff_259 = default;
V lick_260 = default;
V leanIn_261 = default;
V para_262 = default;
V build_263 = default;
V duck_264 = default;
V popOut_265 = default;
V tasteHeart_266 = default;
V BODY_267 = default;
V RE_268 = default;
V TXT_269 = default;
if (_self243.IsNullish) _self243 = GlobalV;
R_250 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_250)) || !(Truthy(Get(R_250, "POKELIB")))) || !(Truthy(Get(R_250, "oceanV")))) || !(Truthy(Get(Get(R_250, "STATES"), "poke_head"))))) {
Call(G("setTimeout"), V.Undef, boot_270.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_250, "oceanPokeV"))) {
return default;
}
Set(R_250, "oceanPokeV", ((V)(1D)));
{ V _t271 = Get(R_250, "PETLIB");
if (_t271.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t271));
{ V _t272 = Get(_t271, "S");
S_251 = _t272; }
{ V _t273 = Get(_t271, "o");
o_252 = _t273; }
{ V _t274 = Get(_t271, "jump");
jump_253 = _t274; }
{ V _t275 = Get(_t271, "shake");
shake_254 = _t275; }
{ V _t276 = Get(_t271, "jelly");
jelly_255 = _t276; } }
{ V _t277 = Get(R_250, "POKELIB");
if (_t277.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t277));
{ V _t278 = Get(_t277, "see");
see_256 = _t278; }
{ V _t279 = Get(_t277, "unsee");
unsee_257 = _t279; }
{ V _t280 = Get(_t277, "giggle");
giggle_258 = _t280; }
{ V _t281 = Get(_t277, "sniff");
sniff_259 = _t281; }
{ V _t282 = Get(_t277, "lick");
lick_260 = _t282; }
{ V _t283 = Get(_t277, "leanIn");
leanIn_261 = _t283; }
{ V _t284 = Get(_t277, "para");
para_262 = _t284; }
{ V _t285 = Get(_t277, "build");
build_263 = _t285; } }
duck_264 = Fn((V _self243, int _argc286, V t_292, V a_293, V _a290, V _a291, V[] _rest287) => {
return Invoke(Invoke(Invoke(t_292, "to", ((V)(110D)), NewObj(2).Put("nk", ((V)(0.3))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(120D)), NewObj(4).Put("hid", (a_293.IsNullish ? ((V)(1D)) : a_293)).Put("sq", ((V)(0.12))).Put("wide", ((V)(0D))).Put("nk", ((V)(0D))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.05))).V, ((V)("io")));
}, 2, "", true);
popOut_265 = Fn((V _self243, int _argc294, V t_300, V _a297, V _a298, V _a299, V[] _rest295) => {
return Invoke(Invoke(Invoke(t_300, "to", ((V)(160D)), NewObj(3).Put("hid", ((V)(0D))).Put("nk", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(2).Put("nk", ((V)(0.2))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("nk", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
tasteHeart_266 = Fn((V _self243, int _argc301, V t_307, V _a304, V _a305, V _a306, V[] _rest302) => {
Call(lick_260, V.Undef, t_307, ((V)(2D)));
return Invoke(Invoke(Invoke(Invoke(t_307, "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(320D))), "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true);
BODY_267 = NewObj(2).Put("shelly", NewObj(5).Put("ear", ((V)(0D))).Put("tail", ((V)(1D))).Put("noWalk", ((V)(1D))).Put("earTap", Arr(((V)(33D)), ((V)(37D)))).Put("lbl", NewObj(7).Put("ear", ((V)("shell top"))).Put("head", ((V)("Head"))).Put("nose", ((V)("Nose"))).Put("belly", ((V)("Belly shell"))).Put("side", ((V)("shell"))).Put("foot", ((V)("flipper"))).Put("tail", ((V)("Little tail"))).V).V).Put("seaturtle", NewObj(5).Put("ear", ((V)(0D))).Put("tail", ((V)(1D))).Put("noWalk", ((V)(1D))).Put("earTap", Arr(((V)(33D)), ((V)(37D)))).Put("lbl", NewObj(7).Put("ear", ((V)("shell top"))).Put("head", ((V)("Head"))).Put("nose", ((V)("Nose"))).Put("belly", ((V)("Belly shell"))).Put("side", ((V)("shell"))).Put("foot", ((V)("flipper"))).Put("tail", ((V)("Little tail"))).V).V).V;
RE_268 = NewObj(2).Put("shelly", NewObj(9).Put("head", Fn((V _self243, int _argc308, V t_314, V s_315, V _a312, V _a313, V[] _rest309) => {
Call(duck_264, V.Undef, t_314);
Invoke(Invoke(Invoke(t_314, "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(3).Put("hid", ((V)(0.55))).Put("lx", ((V)(0D))).Put("ly", ((V)((-0.6)))).V, ((V)("io"))), "wait", ((V)(300D)));
Call(popOut_265, V.Undef, t_314);
Call(giggle_258, V.Undef, t_314, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self243, int _argc316, V t_322, V s_323, V _a320, V _a321, V[] _rest317) => {
V k_324 = default;
k_324 = Call(S_251, V.Undef, s_323);
Invoke(Invoke(Invoke(t_322, "to", ((V)(80D)), NewObj(2).Put("tilt", ((V)((ToNum(s_323) * 4D)))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)(((-ToNum(s_323)) * 2D)))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(see_256, V.Undef, t_322, ((V)("ear")), s_323, ((V)(250D)));
Invoke(Invoke(Invoke(t_322, "to", ((V)(260D)), NewObj(2).PutK(Get(k_324, "arm"), ((V)(70D))).Put("nk", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(420D)), ((V)(2D)), NewObj(1).PutK(Get(k_324, "arm"), ((V)(85D))).V, NewObj(1).PutK(Get(k_324, "arm"), ((V)(65D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).PutK(Get(k_324, "arm"), ((V)(0D))).V, ((V)("io")));
Call(unsee_257, V.Undef, t_322);
Call(giggle_258, V.Undef, t_322, ((V)(1D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self243, int _argc325, V t_331, V s_332, V _a329, V _a330, V[] _rest326) => {
Invoke(t_331, "to", ((V)(250D)), NewObj(2).Put("nk", ((V)(0.7))).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(sniff_259, V.Undef, t_331, ((V)(2D)));
Call(tasteHeart_266, V.Undef, t_331);
Invoke(t_331, "to", ((V)(250D)), NewObj(1).Put("nk", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self243, int _argc333, V t_339, V s_340, V _a337, V _a338, V[] _rest334) => {
V k_341 = default;
k_341 = Call(S_251, V.Undef, s_340);
Invoke(Invoke(Invoke(Invoke(t_339, "e", ((V)("blink2"))), "to", ((V)(200D)), NewObj(2).PutK(Get(k_341, "wink"), ((V)(1D))).Put("nk", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(220D)), NewObj(2).PutK(Get(k_341, "wink"), ((V)(0D))).Put("nk", ((V)(0D))).V, ((V)("io")));
Call(shake_254, V.Undef, t_339, NewObj(5).Put("P", ((V)(110D))).Put("env", Arr(((V)(0.5)), ((V)(0.8)), ((V)(0.4)))).Put("head", ((V)(0.22))).Put("roll", ((V)(3D))).Put("ear", ((V)(0D))).V);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self243, int _argc342, V t_348, V s_349, V _a346, V _a347, V[] _rest343) => {
Call(leanIn_261, V.Undef, t_348, s_349);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self243, int _argc350, V t_356, V s_357, V _a354, V _a355, V[] _rest351) => {
V a_358 = default;
Invoke(t_356, "to", ((V)(220D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("io")));
a_358 = Get(t_356, "t");
Call(giggle_258, V.Undef, t_356, ((V)(3D)), ((V)(0.9)));
Call(para_262, V.Undef, t_356, a_358, Fn((V _self243, int _argc359, V u_365, V _a362, V _a363, V _a364, V[] _rest360) => {
return Invoke(Invoke(u_365, "osc", ((V)(1000D)), ((V)(3D)), NewObj(5).Put("footL", ((V)(3D))).Put("footR", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(0D))).Put("tilt", ((V)(4D))).V, NewObj(5).Put("footL", ((V)(0D))).Put("footR", ((V)(3D))).Put("armL", ((V)(0D))).Put("armR", ((V)(30D))).Put("tilt", ((V)((-4D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(5).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self243, int _argc366, V t_372, V s_373, V _a370, V _a371, V[] _rest367) => {
Call(duck_264, V.Undef, t_372, ((V)(0.75)));
Invoke(Invoke(Invoke(t_372, "to", ((V)(420D)), NewObj(1).Put("spin", ((V)(((-ToNum(s_373)) * 70D)))).V, ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(460D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("io")));
Call(popOut_265, V.Undef, t_372);
Call(see_256, V.Undef, t_372, ((V)("side")), s_373, ((V)(200D)));
Call(unsee_257, V.Undef, t_372, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self243, int _argc374, V t_380, V s_381, V _a378, V _a379, V[] _rest375) => {
V k_382 = default;
k_382 = Call(S_251, V.Undef, s_381);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_380, "to", ((V)(100D)), NewObj(2).PutK(Get(k_382, "foot"), ((V)(0D))).Put("hid", ((V)(0.4))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(160D)), NewObj(2).Put("hid", ((V)(0D))).PutK(Get(k_382, "foot"), ((V)(3D))).V, ((V)("o"))), "to", ((V)(120D)), NewObj(2).PutK(Get(k_382, "foot"), ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(1D))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(see_256, V.Undef, t_380, ((V)("foot")), s_381, ((V)(200D)));
Call(unsee_257, V.Undef, t_380);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self243, int _argc383, V t_389, V s_390, V _a387, V _a388, V[] _rest384) => {
Invoke(Invoke(t_389, "osc", ((V)(600D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
Call(see_256, V.Undef, t_389, ((V)("tail")), ((V)(1D)), ((V)(350D)));
Call(unsee_257, V.Undef, t_389, ((V)(380D)));
Call(giggle_258, V.Undef, t_389, ((V)(1D)));
return default;
}, 2, "tail", true)).V).Put("seaturtle", NewObj(9).Put("head", Fn((V _self243, int _argc391, V t_397, V s_398, V _a395, V _a396, V[] _rest392) => {
Invoke(Invoke(t_397, "to", ((V)(120D)), NewObj(3).Put("nk", ((V)((-0.4)))).Put("close", ((V)(0.7))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(3).Put("nk", ((V)(0.5))).Put("close", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(giggle_258, V.Undef, t_397, ((V)(2D)));
Invoke(Invoke(t_397, "to", ((V)(260D)), NewObj(2).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self243, int _argc399, V t_405, V s_406, V _a403, V _a404, V[] _rest400) => {
V k_407 = default;
k_407 = Call(S_251, V.Undef, s_406);
Invoke(Invoke(Invoke(t_405, "to", ((V)(80D)), NewObj(2).Put("tilt", ((V)((ToNum(s_406) * 4D)))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)(((-ToNum(s_406)) * 2D)))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(see_256, V.Undef, t_405, ((V)("ear")), s_406, ((V)(250D)));
Invoke(Invoke(Invoke(t_405, "to", ((V)(260D)), NewObj(2).PutK(Get(k_407, "arm"), ((V)(80D))).Put("nk", ((V)(0.4))).V, ((V)("io"))), "osc", ((V)(420D)), ((V)(2D)), NewObj(1).PutK(Get(k_407, "arm"), ((V)(95D))).V, NewObj(1).PutK(Get(k_407, "arm"), ((V)(70D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).PutK(Get(k_407, "arm"), ((V)(0D))).V, ((V)("io")));
Call(unsee_257, V.Undef, t_405);
Call(giggle_258, V.Undef, t_405, ((V)(1D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self243, int _argc408, V t_414, V s_415, V _a412, V _a413, V[] _rest409) => {
Invoke(t_414, "to", ((V)(250D)), NewObj(1).Put("nk", ((V)(0.8))).V, ((V)("io")));
Call(sniff_259, V.Undef, t_414, ((V)(2D)));
Call(tasteHeart_266, V.Undef, t_414);
Invoke(t_414, "to", ((V)(250D)), NewObj(1).Put("nk", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self243, int _argc416, V t_422, V s_423, V _a420, V _a421, V[] _rest417) => {
V k_424 = default;
k_424 = Call(S_251, V.Undef, s_423);
Invoke(Invoke(Invoke(Invoke(t_422, "e", ((V)("blink2"))), "to", ((V)(200D)), NewObj(2).PutK(Get(k_424, "wink"), ((V)(1D))).Put("nk", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(220D)), NewObj(2).PutK(Get(k_424, "wink"), ((V)(0D))).Put("nk", ((V)(0D))).V, ((V)("io")));
Call(shake_254, V.Undef, t_422, NewObj(5).Put("P", ((V)(110D))).Put("env", Arr(((V)(0.5)), ((V)(0.8)), ((V)(0.4)))).Put("head", ((V)(0.22))).Put("roll", ((V)(3D))).Put("ear", ((V)(0D))).V);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self243, int _argc425, V t_431, V s_432, V _a429, V _a430, V[] _rest426) => {
Call(leanIn_261, V.Undef, t_431, s_432);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self243, int _argc433, V t_439, V s_440, V _a437, V _a438, V[] _rest434) => {
V a_441 = default;
Invoke(t_439, "to", ((V)(220D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("io")));
a_441 = Get(t_439, "t");
Call(giggle_258, V.Undef, t_439, ((V)(3D)), ((V)(0.9)));
Call(para_262, V.Undef, t_439, a_441, Fn((V _self243, int _argc442, V u_448, V _a445, V _a446, V _a447, V[] _rest443) => {
return Invoke(Invoke(u_448, "osc", ((V)(1000D)), ((V)(4D)), NewObj(5).Put("armL", ((V)(70D))).Put("armR", ((V)(10D))).Put("footL", ((V)(3D))).Put("footR", ((V)(0D))).Put("tilt", ((V)(3D))).V, NewObj(5).Put("armL", ((V)(10D))).Put("armR", ((V)(70D))).Put("footL", ((V)(0D))).Put("footR", ((V)(3D))).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(5).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self243, int _argc449, V t_455, V s_456, V _a453, V _a454, V[] _rest450) => {
Invoke(Invoke(Invoke(t_455, "to", ((V)(380D)), NewObj(3).Put("spin", ((V)(((-ToNum(s_456)) * 40D)))).PutK(Get(Call(S_251, V.Undef, ((V)((-ToNum(s_456))))), "arm"), ((V)(60D))).Put("nk", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(420D)), NewObj(3).Put("spin", ((V)(0D))).PutK(Get(Call(S_251, V.Undef, ((V)((-ToNum(s_456))))), "arm"), ((V)(0D))).Put("nk", ((V)(0D))).V, ((V)("io")));
Call(see_256, V.Undef, t_455, ((V)("side")), s_456, ((V)(200D)));
Call(unsee_257, V.Undef, t_455, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self243, int _argc457, V t_463, V s_464, V _a461, V _a462, V[] _rest458) => {
V k_465 = default;
k_465 = Call(S_251, V.Undef, s_464);
Invoke(Invoke(Invoke(Invoke(Invoke(t_463, "to", ((V)(120D)), NewObj(1).PutK(Get(k_465, "arm"), ((V)(90D))).V, ((V)("o"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).PutK(Get(k_465, "arm"), ((V)(60D))).V, NewObj(1).PutK(Get(k_465, "arm"), ((V)(95D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).PutK(Get(k_465, "arm"), ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(1D))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(see_256, V.Undef, t_463, ((V)("foot")), s_464, ((V)(200D)));
Call(unsee_257, V.Undef, t_463);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self243, int _argc466, V t_472, V s_473, V _a470, V _a471, V[] _rest467) => {
Invoke(Invoke(t_472, "osc", ((V)(600D)), ((V)(3D)), NewObj(3).Put("wag", ((V)(26D))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).V, NewObj(3).Put("wag", ((V)((-26D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
Call(see_256, V.Undef, t_472, ((V)("tail")), ((V)(1D)), ((V)(350D)));
Call(unsee_257, V.Undef, t_472, ((V)(380D)));
Call(giggle_258, V.Undef, t_472, ((V)(1D)));
return default;
}, 2, "tail", true)).V).V;
TXT_269 = NewObj(2).Put("shelly", NewObj(9).Put("head", ((V)("Boop! She ducks into her shell, peeks out and pops back out giggling."))).Put("ear", ((V)("Knock knock on her shell - it rocks, she looks up and pats the spot with a flipper."))).Put("nose", ((V)("Stretches her neck out to sniff your finger and licks it: a heart."))).Put("eye", ((V)("Blinks hard, tucks her neck a little, a small head shake."))).Put("cheek", ((V)("Leans her head into your finger."))).Put("belly", ((V)("Ticklish: giggles with her little legs kicking and her shell rocking."))).Put("side", ((V)("Tucks in and her shell turns away from the poke, then she turns back and peeks."))).Put("foot", ((V)("Pulls that flipper into her shell, then stomps it back down."))).Put("tail", ((V)("Her little tail wiggles, she looks back and giggles."))).V).Put("seaturtle", NewObj(9).Put("head", ((V)("Boop! Its head bobs down, it giggles and gives a happy flipper flap."))).Put("ear", ((V)("Tap on its shell - it rocks, looks up and pats the spot with a big flipper."))).Put("nose", ((V)("Stretches its neck out to sniff your finger and licks it: a heart."))).Put("eye", ((V)("Blinks hard, tucks its neck a little, a small head shake."))).Put("cheek", ((V)("Leans its head into your finger."))).Put("belly", ((V)("Ticklish: giggles while all four flippers paddle."))).Put("side", ((V)("Turns a little away from the poke with a flipper flap, then turns back and peeks."))).Put("foot", ((V)("Waves that big flipper, then pats it down on the ground."))).Put("tail", ((V)("Its little tail wiggles with the back flippers, it looks back and giggles."))).V).V;
Call(build_263, V.Undef, RE_268, TXT_269, BODY_267);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_490 => Fn((V _self474, int _argc475, V _a477, V _a478, V _a479, V _a480, V[] _rest476) => {
V R_481 = default;
V o_482 = default;
V jump_483 = default;
V EAR_484 = default;
V sniffF_485 = default;
V lipLick_486 = default;
V hearts_487 = default;
V buildAll_488 = default;
V CARDS_489 = default;
if (_self474.IsNullish) _self474 = GlobalV;
R_481 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_481)) || !(Truthy(Get(R_481, "EATKIT")))) || !(Truthy(Get(R_481, "oceanV")))) || !(Truthy(Get(R_481, "EATLIB"))))) {
Call(G("setTimeout"), V.Undef, boot_490.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_481, "oceanEatV"))) {
return default;
}
Set(R_481, "oceanEatV", ((V)(1D)));
{ V _t491 = Get(R_481, "PETLIB");
if (_t491.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t491));
{ V _t492 = Get(_t491, "o");
o_482 = _t492; }
{ V _t493 = Get(_t491, "jump");
jump_483 = _t493; } }
{ V _t494 = Get(R_481, "EATKIT");
if (_t494.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t494));
{ V _t495 = Get(_t494, "EAR");
EAR_484 = _t495; }
{ V _t496 = Get(_t494, "sniffF");
sniffF_485 = _t496; }
{ V _t497 = Get(_t494, "lipLick");
lipLick_486 = _t497; }
{ V _t498 = Get(_t494, "hearts");
hearts_487 = _t498; }
{ V _t499 = Get(_t494, "buildAll");
buildAll_488 = _t499; } }
Object_assign(EAR_484, NewObj(2).Put("shelly", ((V)(0D))).Put("seaturtle", ((V)(0D))).V);
CARDS_489 = NewObj(2).Put("shelly", NewObj(9).Put("chewMs", ((V)(150D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Stretches her neck out to sniff it, slow careful turtle bites; flaps her flippers and wags her little tail when she likes it."))).Put("pre", Fn((V _self474, int _argc500, V t_506, V _a503, V _a504, V _a505, V[] _rest501) => {
Invoke(t_506, "to", ((V)(300D)), NewObj(1).Put("nk", ((V)(0.8))).V, ((V)("io")));
Call(sniffF_485, V.Undef, t_506, ((V)(1D)));
Invoke(t_506, "to", ((V)(260D)), NewObj(1).Put("nk", ((V)(0.3))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self474, int _argc507, V t_513, V _a510, V _a511, V _a512, V[] _rest508) => {
Call(lipLick_486, V.Undef, t_513);
Invoke(t_513, "to", ((V)(250D)), NewObj(1).Put("nk", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _self474, int _argc514, V t_520, V _a517, V _a518, V _a519, V[] _rest515) => {
Invoke(Invoke(Invoke(Invoke(t_520, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(4).Put("nk", ((V)(1D))).Put("armL", ((V)(60D))).Put("armR", ((V)(0D))).Put("wag", ((V)(18D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(60D))).Put("wag", ((V)((-18D)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wag", ((V)(0D))).Put("nk", ((V)(0.2))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self474, int _argc521, V t_527, V _a524, V _a525, V _a526, V[] _rest522) => {
Call(hearts_487, V.Undef, t_527, ((V)(2D)));
Invoke(Invoke(Invoke(Invoke(t_527, "to", ((V)(120D)), NewObj(2).Put("hid", ((V)(0.6))).Put("blush", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(180D)), NewObj(2).Put("hid", ((V)(0D))).Put("nk", ((V)(1D))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(1).Put("nk", ((V)(0.2))).V, ((V)("io")));
Invoke(Get(CARDS_489, "shelly"), "yum", t_527);
return default;
}, 1, "love", true)).V).Put("seaturtle", NewObj(9).Put("chewMs", ((V)(150D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Stretches its neck out to sniff it, slow careful sea-turtle bites; paddles its big flippers when it likes it."))).Put("pre", Fn((V _self474, int _argc528, V t_534, V _a531, V _a532, V _a533, V[] _rest529) => {
Invoke(t_534, "to", ((V)(300D)), NewObj(1).Put("nk", ((V)(0.8))).V, ((V)("io")));
Call(sniffF_485, V.Undef, t_534, ((V)(1D)));
Invoke(t_534, "to", ((V)(260D)), NewObj(1).Put("nk", ((V)(0.3))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self474, int _argc535, V t_541, V _a538, V _a539, V _a540, V[] _rest536) => {
Call(lipLick_486, V.Undef, t_541);
Invoke(t_541, "to", ((V)(250D)), NewObj(1).Put("nk", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _self474, int _argc542, V t_548, V _a545, V _a546, V _a547, V[] _rest543) => {
Invoke(Invoke(Invoke(Invoke(t_548, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(4).Put("nk", ((V)(0.9))).Put("armL", ((V)(70D))).Put("armR", ((V)(10D))).Put("wag", ((V)(14D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(3).Put("armL", ((V)(10D))).Put("armR", ((V)(70D))).Put("wag", ((V)((-14D)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wag", ((V)(0D))).Put("nk", ((V)(0.2))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self474, int _argc549, V t_555, V _a552, V _a553, V _a554, V[] _rest550) => {
Call(hearts_487, V.Undef, t_555, ((V)(2D)));
Invoke(Invoke(t_555, "to", ((V)(160D)), NewObj(4).Put("blush", ((V)(1D))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("lift", ((V)(1.5))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
Invoke(Get(CARDS_489, "seaturtle"), "yum", t_555);
return default;
}, 1, "love", true)).V).V;
Call(buildAll_488, V.Undef, CARDS_489);
return default;
}, 0, "boot", false)), V.Undef);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
