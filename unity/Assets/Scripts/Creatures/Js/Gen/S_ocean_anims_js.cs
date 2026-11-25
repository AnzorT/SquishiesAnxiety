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
Invoke(Arr(((V)("hid")), ((V)("nk")), ((V)("swim")), ((V)("dz"))), "forEach", Fn((V _arrowThis42, int _argc35, V k_41, V _a38, V _a39, V _a40, V[] _rest36) => {
if (GetK(Get(R_16, "REST"), k_41).IsNullish) {
SetK(Get(R_16, "REST"), k_41, ((V)(0D)));
}
return default;
}, 1, "", true));
{ V _t43 = Get(R_16, "PETLIB");
if (_t43.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t43));
{ V _t44 = Get(_t43, "TL");
TL_17 = _t44; }
{ V _t45 = Get(_t43, "o");
o_18 = _t45; }
{ V _t46 = Get(_t43, "jump");
jump_19 = _t46; }
{ V _t47 = Get(_t43, "look");
look_20 = _t47; }
{ V _t48 = Get(_t43, "shake");
shake_21 = _t48; }
{ V _t49 = Get(_t43, "swing");
swing_22 = _t49; }
{ V _t50 = Get(_t43, "jelly");
jelly_23 = _t50; }
{ V _t51 = Get(_t43, "land");
land_24 = _t51; }
{ V _t52 = Get(_t43, "install");
install_25 = _t52; } }
Invoke(KEYS_8, "forEach", Fn((V _arrowThis60, int _argc53, V k_59, V _a56, V _a57, V _a58, V[] _rest54) => {
return Invoke(Get(R_16, "SOFT"), "add", k_59);
}, 1, "", true));
loopN_26 = Fn((V _arrowThis69, int _argc61, V t_67, V n_68, V _a65, V _a66, V[] _rest62) => {
return Object_assign(Invoke(t_67, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_67, "t")) * ToNum((n_68 is var _t70 && Truthy(_t70) ? _t70 : ((V)(3D)))))))).V);
}, 2, "", true);
spinR_27 = Fn((V _arrowThis82, int _argc71, V t_77, V dur_78, V deg_79, V x_80, V[] _rest72) => {
V a_83 = default;
V ez_81 = default;
ez_81 = (_argc71 > 4 ? _rest72[0] : V.Undef);
a_83 = Get(t_77, "t");
Invoke(Invoke(t_77, "to", dur_78, Call(o_18, V.Undef, NewObj(1).Put("spin", deg_79).V, (x_80 is var _t84 && Truthy(_t84) ? _t84 : NewObj(0).V)), (ez_81 is var _t85 && Truthy(_t85) ? _t85 : ((V)("io")))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
return a_83;
return default;
}, 5, "", true);
duck_28 = Fn((V _arrowThis94, int _argc86, V t_92, V x_93, V _a90, V _a91, V[] _rest87) => {
return Invoke(Invoke(Invoke(t_92, "to", ((V)(110D)), NewObj(3).Put("nk", ((V)(0.35))).Put("wide", ((V)(0.6))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(120D)), Call(o_18, V.Undef, NewObj(4).Put("hid", ((V)(1D))).Put("sq", ((V)(0.14))).Put("wide", ((V)(0D))).Put("nk", ((V)(0D))).V, (x_93 is var _t95 && Truthy(_t95) ? _t95 : NewObj(0).V)), ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.06))).V, ((V)("io")));
}, 2, "", true);
popOut_29 = Fn((V _arrowThis104, int _argc96, V t_102, V x_103, V _a100, V _a101, V[] _rest97) => {
return Invoke(Invoke(Invoke(Invoke(t_102, "to", ((V)(160D)), Call(o_18, V.Undef, NewObj(4).Put("hid", ((V)(0D))).Put("nk", ((V)(1.1))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(1.5))).V, (x_103 is var _t105 && Truthy(_t105) ? _t105 : NewObj(0).V)), ((V)("o"))), "to", ((V)(220D)), NewObj(3).Put("nk", ((V)(0.25))).Put("sq", ((V)(0.04))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("nk", ((V)(0.45))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(1).Put("nk", ((V)(0.3))).V, ((V)("io")));
}, 2, "", true);
stroke_30 = Fn((V _arrowThis116, int _argc106, V t_112, V n_113, V per_114, V lift_115, V[] _rest107) => {
{
double i_117 = 0;
i_117 = 0D;
while (true) {
if (!(Lt(((V)(i_117)), n_113))) break;
Invoke(Invoke(t_112, "to", ((V)((ToNum(per_114) * 0.45))), NewObj(4).Put("armL", ((V)(115D))).Put("armR", ((V)(115D))).Put("lift", Add((lift_115 is var _t120 && Truthy(_t120) ? _t120 : ((V)(0D))), ((V)(1.2)))).Put("pitch", ((V)(0.04))).V, ((V)("o"))), "to", ((V)((ToNum(per_114) * 0.55))), NewObj(4).Put("armL", ((V)((-15D)))).Put("armR", ((V)((-15D)))).Put("lift", (lift_115 is var _t119 && Truthy(_t119) ? _t119 : ((V)(0D)))).Put("pitch", ((V)((-0.02)))).V, ((V)("io")));
i_117++;
}
}
return t_112;
return default;
}, 4, "", true);
CARDS_31 = NewObj(2).Put("shelly", NewObj(4).Put("T", ((V)(1.15))).Put("b", ((V)(0.85))).Put("s", ((V)(0.95))).Put("w", ((V)(1D))).V).Put("seaturtle", NewObj(4).Put("T", ((V)(1.1))).Put("b", ((V)(0.9))).Put("s", ((V)(1D))).Put("w", ((V)(1D))).V).V;
MOVES_32 = NewObj(2).Put("shelly", NewObj(7).Put("happy", Arr(Call(Fn((V _arrowThis127, int _argc121, V _a123, V _a124, V _a125, V _a126, V[] _rest122) => {
V t_128 = default;
t_128 = Call(TL_17, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)(1.1)));
Invoke(Invoke(t_128, "to", ((V)(160D)), NewObj(2).Put("lx", ((V)(0D))).Put("ly", ((V)((-0.4)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(3).Put("nk", ((V)(1.3))).Put("pitch", ((V)(0.14))).Put("sq", ((V)((-0.04)))).V, ((V)("o")));
Invoke(Invoke(Invoke(Invoke(t_128, "to", ((V)(260D)), NewObj(4).Put("armL", ((V)(70D))).Put("armR", ((V)(0D))).Put("tilt", ((V)((-3D)))).Put("wag", ((V)(20D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(70D))).Put("tilt", ((V)(3D))).Put("wag", ((V)((-20D)))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(4).Put("armL", ((V)(70D))).Put("armR", ((V)(0D))).Put("tilt", ((V)((-3D)))).Put("wag", ((V)(20D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(7).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("tilt", ((V)(0D))).Put("wag", ((V)(0D))).Put("nk", ((V)(0.6))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Call(jump_19, V.Undef, t_128, NewObj(6).Put("h", ((V)(4D))).Put("ant", ((V)(170D))).Put("up", ((V)(200D))).Put("c", ((V)(0.12))).Put("arm", ((V)(30D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(2D))))).V);
return Call(loopN_26, V.Undef, Invoke(t_128, "rest", ((V)(320D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Stretches her neck up with a big smile, flaps her flippers left and right, then a little shell hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis135, int _argc129, V _a131, V _a132, V _a133, V _a134, V[] _rest130) => {
V t_136 = default;
t_136 = Call(TL_17, V.Undef);
Invoke(Invoke(t_136, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("nk", ((V)(0.5))).V, ((V)("o")));
Call(duck_28, V.Undef, t_136);
Invoke(t_136, "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D)));
Invoke(Invoke(Invoke(t_136, "osc", ((V)(600D)), ((V)(4D)), NewObj(1).Put("tilt", ((V)(2.2))).V, NewObj(1).Put("tilt", ((V)((-2.2)))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_136, "to", ((V)(380D)), NewObj(3).Put("hid", ((V)(0.55))).Put("wide", ((V)(0.3))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("lx", ((V)((-0.9)))).V, ((V)("o"))), "wait", ((V)(220D))), "to", ((V)(260D)), NewObj(1).Put("lx", ((V)(0.9))).V, ((V)("io"))), "wait", ((V)(220D))), "to", ((V)(160D)), NewObj(1).Put("lx", ((V)(0D))).V, ((V)("io")));
Call(popOut_29, V.Undef, t_136, NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("wide", ((V)(0D))).Put("mw", ((V)(1D))).V);
return Invoke(Invoke(t_136, "rest", ((V)(420D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Eyes pop and she snaps into her shell, it trembles, she peeks out with darting eyes, then pops back out relieved.")))).Put("squish", Arr(Call(Fn((V _arrowThis143, int _argc137, V _a139, V _a140, V _a141, V _a142, V[] _rest138) => {
V t_144 = default;
t_144 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_144, "to", ((V)(150D)), NewObj(2).Put("sq", ((V)((-0.04)))).Put("nk", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.3))).Put("hid", ((V)(0.85))).Put("hap", ((V)(0.9))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(t_144, "to", ((V)(140D)), NewObj(8).Put("hid", ((V)(0D))).Put("nk", ((V)(1.5))).Put("sq", ((V)((-0.14)))).Put("close", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(3D))), "to", ((V)(200D)), NewObj(4).Put("nk", ((V)(0.6))).Put("sq", ((V)(0.06))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("io")));
Call(jelly_23, V.Undef, t_144, ((V)(0.5)), ((V)(3D)), ((V)(300D)), ((V)("nk")));
Invoke(t_144, "to", ((V)(200D)), NewObj(7).Put("nk", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_144);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, she pulls into her shell; let go and her neck boings out and wobbles.")))).Put("quirk", Arr(Call(Fn((V _arrowThis151, int _argc145, V _a147, V _a148, V _a149, V _a150, V[] _rest146) => {
V t_152 = default;
t_152 = Call(TL_17, V.Undef);
Invoke(t_152, "to", ((V)(500D)), NewObj(8).Put("nk", ((V)(1.25))).Put("pitch", ((V)(0.2))).Put("close", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)((-18D)))).Put("armR", ((V)((-18D)))).Put("footL", ((V)(1D))).Put("footR", ((V)(1D))).V, ((V)("io")));
Invoke(Invoke(t_152, "osc", ((V)(1600D)), ((V)(2D)), NewObj(2).Put("sq", ((V)((-0.03)))).Put("lift", ((V)(0.4))).V, NewObj(2).Put("sq", ((V)(0.02))).Put("lift", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_152, "to", ((V)(420D)), NewObj(2).Put("pitch", ((V)(0.05))).Put("nk", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(1).Put("close", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("close", ((V)(1D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("nk", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_152, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sunbathe")), ((V)("Stretches her neck out to the sun with her flippers spread and eyes shut, two slow happy breaths, a slow turtle blink.")))).Put("press", NewObj(2).Put("hid", ((V)(0.55))).Put("sq", ((V)(0.06))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(5).Put("hid", Arr(Arr(((V)(0D)), ((V)(0.55))), Arr(((V)(140D)), ((V)(0D)), ((V)("o"))))).Put("nk", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(1.3)), ((V)("o"))), Arr(((V)(420D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(650D)), ((V)(0.45)), ((V)("io"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(270D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(430D)), ((V)(0D)), ((V)("io"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(40D)), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(40D)), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("bubble")), ((V)("head")), ((V)(3D))))).V).Put("look", Call(Fn((V _arrowThis159, int _argc153, V _a155, V _a156, V _a157, V _a158, V[] _rest154) => {
V t_160 = default;
t_160 = Call(TL_17, V.Undef);
Invoke(t_160, "to", ((V)(320D)), NewObj(1).Put("nk", ((V)(0.55))).V, ((V)("io")));
Call(look_20, V.Undef, t_160, ((V)(0D)), ((V)((-0.6))), NewObj(1).Put("k", ((V)(0.7))).V);
Invoke(t_160, "wait", ((V)(700D)));
Call(look_20, V.Undef, t_160, ((V)((-0.6))), ((V)(0.6)), NewObj(3).Put("k", ((V)(0.7))).Put("d1", ((V)(210D))).Put("d2", ((V)(250D))).V);
Invoke(t_160, "wait", ((V)(700D)));
Call(look_20, V.Undef, t_160, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.7))).V);
return Invoke(Invoke(Invoke(t_160, "to", ((V)(320D)), NewObj(1).Put("nk", ((V)(0D))).V, ((V)("io"))), "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).Put("seaturtle", NewObj(7).Put("happy", Arr(Call(Fn((V _arrowThis167, int _argc161, V _a163, V _a164, V _a165, V _a166, V[] _rest162) => {
V t_168 = default;
t_168 = Call(TL_17, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)(1.05)));
Invoke(Invoke(t_168, "to", ((V)(160D)), NewObj(1).Put("ly", ((V)((-0.4)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("nk", ((V)(0.9))).Put("pitch", ((V)(0.12))).V, ((V)("o")));
{
double i_169 = 0;
i_169 = 0D;
while (true) {
if (!((i_169 < 3D))) break;
Invoke(Invoke(t_168, "to", ((V)(200D)), NewObj(5).Put("armL", ((V)(75D))).Put("armR", ((V)(75D))).Put("lift", ((V)(1.2))).Put("sq", ((V)((-0.03)))).Put("wag", ((V)(14D))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(5).Put("armL", ((V)(5D))).Put("armR", ((V)(5D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.02))).Put("wag", ((V)((-14D)))).V, ((V)("io")));
i_169++;
}
}
Invoke(t_168, "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(3D)));
Invoke(t_168, "to", ((V)(260D)), NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wag", ((V)(0D))).Put("nk", ((V)(0.5))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
Call(jump_19, V.Undef, t_168, NewObj(5).Put("h", ((V)(3D))).Put("ant", ((V)(160D))).Put("up", ((V)(200D))).Put("c", ((V)(0.1))).Put("arm", ((V)(0D))).V);
return Call(loopN_26, V.Undef, Invoke(t_168, "rest", ((V)(320D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Lifts its head with a big smile, flaps both front flippers three times like a swim stroke (bubbles!), then a little hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis177, int _argc171, V _a173, V _a174, V _a175, V _a176, V[] _rest172) => {
V t_178 = default;
t_178 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_178, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(8).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("nk", ((V)(0.8))).Put("armL", ((V)(95D))).Put("armR", ((V)(95D))).Put("lift", ((V)(2.5))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(2D)));
Invoke(Invoke(t_178, "to", ((V)(180D)), NewObj(5).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("nk", ((V)((-0.3)))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_178, "to", ((V)(260D)), NewObj(1).Put("lx", ((V)((-0.9)))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.9))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(220D)), NewObj(2).Put("lx", ((V)(0D))).Put("wide", ((V)(0.3))).V, ((V)("io")));
Invoke(t_178, "to", ((V)(320D)), NewObj(8).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("nk", ((V)(0.2))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_178, "rest", ((V)(420D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Eyes pop and both flippers fly up, it plops back down with its neck tucked, looks left and right, then relaxes with a smile.")))).Put("squish", Arr(Call(Fn((V _arrowThis185, int _argc179, V _a181, V _a182, V _a183, V _a184, V[] _rest180) => {
V t_186 = default;
t_186 = Call(TL_17, V.Undef);
Invoke(Invoke(Invoke(t_186, "to", ((V)(150D)), NewObj(2).Put("sq", ((V)((-0.04)))).Put("nk", ((V)(0.2))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(8).Put("sq", ((V)(0.3))).Put("armL", ((V)((-25D)))).Put("armR", ((V)((-25D)))).Put("footL", ((V)(3D))).Put("footR", ((V)(3D))).Put("nk", ((V)((-0.4)))).Put("hap", ((V)(0.9))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(t_186, "to", ((V)(140D)), NewObj(9).Put("sq", ((V)((-0.14)))).Put("nk", ((V)(1D))).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("close", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(3D))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0.06))).Put("nk", ((V)(0.4))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("io")));
Call(jelly_23, V.Undef, t_186, ((V)(0.5)), ((V)(3D)), ((V)(300D)), ((V)("nk")));
Invoke(t_186, "to", ((V)(200D)), NewObj(7).Put("nk", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("io")));
return Call(loopN_26, V.Undef, t_186);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed flat with its flippers splayed out; let go and it boings up with both flippers raised, its neck wobbling.")))).Put("quirk", Arr(Call(Fn((V _arrowThis193, int _argc187, V _a189, V _a190, V _a191, V _a192, V[] _rest188) => {
V t_194 = default;
t_194 = Call(TL_17, V.Undef);
Invoke(t_194, "to", ((V)(500D)), NewObj(4).Put("close", ((V)(1D))).Put("smile", ((V)(1D))).Put("nk", ((V)(0.5))).Put("pitch", ((V)(0.06))).V, ((V)("io")));
{
double i_195 = 0;
i_195 = 0D;
while (true) {
if (!((i_195 < 3D))) break;
Invoke(Invoke(Invoke(t_194, "to", ((V)(520D)), NewObj(6).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("lift", ((V)(0.8))).Put("tilt", ((V)((NumTruthy((i_195 % 2D)) ? 2D : (-2D))))).V, ((V)("io"))), "to", ((V)(620D)), NewObj(6).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(1D)));
i_195++;
}
}
Invoke(Invoke(Invoke(Invoke(t_194, "to", ((V)(300D)), NewObj(1).Put("close", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("close", ((V)(1D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("nk", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_194, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sea Dream")), ((V)("Closes its eyes and dreams of the sea: three slow swimming strokes with its big flippers, bubbles rising, a slow blink.")))).Put("press", NewObj(3).Put("sq", ((V)(0.1))).Put("armL", ((V)((-12D)))).Put("armR", ((V)((-12D)))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(4).Put("nk", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(1D)), ((V)("o"))), Arr(((V)(420D)), ((V)(0.1)), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.12))), ((V)("o"))), Arr(((V)(270D)), ((V)(0.05)), ((V)("io"))), Arr(((V)(430D)), ((V)(0D)), ((V)("io"))))).Put("armL", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(60D)), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).Put("armR", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), ((V)(60D)), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("bubble")), ((V)("head")), ((V)(3D))))).V).Put("look", Call(Fn((V _arrowThis203, int _argc197, V _a199, V _a200, V _a201, V _a202, V[] _rest198) => {
V t_204 = default;
t_204 = Call(TL_17, V.Undef);
Invoke(t_204, "to", ((V)(320D)), NewObj(1).Put("nk", ((V)(0.5))).V, ((V)("io")));
Call(look_20, V.Undef, t_204, ((V)(0D)), ((V)((-0.6))), NewObj(1).Put("k", ((V)(0.7))).V);
Invoke(t_204, "wait", ((V)(700D)));
Call(look_20, V.Undef, t_204, ((V)((-0.6))), ((V)(0.6)), NewObj(3).Put("k", ((V)(0.7))).Put("d1", ((V)(210D))).Put("d2", ((V)(250D))).V);
Invoke(t_204, "wait", ((V)(700D)));
Call(look_20, V.Undef, t_204, ((V)(0.6)), ((V)(0D)), NewObj(1).Put("k", ((V)(0.7))).V);
return Invoke(Invoke(Invoke(t_204, "to", ((V)(320D)), NewObj(1).Put("nk", ((V)(0D))).V, ((V)("io"))), "rest", ((V)(300D))), "done", NewObj(2).Put("soft", ((V)(0.4))).Put("stretch", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef)).V).V;
DANCES_33 = NewObj(2).Put("shelly", Arr(Call(Fn((V _arrowThis211, int _argc205, V _a207, V _a208, V _a209, V _a210, V[] _rest206) => {
V t_212 = default;
double d_213 = 0;
double V_214 = 0;
V s0_215 = default;
double END_216 = 0;
double RUN_217 = 0;
double TOT_218 = 0;
double nW_219 = 0;
V sk_220 = default;
V sk2_221 = default;
t_212 = Call(TL_17, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
d_213 = 1D;
Invoke(Invoke(t_212, "to", ((V)(220D)), NewObj(3).Put("nk", ((V)(0.9))).Put("sq", ((V)((-0.04)))).Put("hap", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(3).Put("nk", ((V)(0.6))).Put("pitch", ((V)((-0.08)))).Put("sq", ((V)(0.03))).V, ((V)("io")));
Call(duck_28, V.Undef, t_212, NewObj(2).Put("hap", ((V)(1D))).Put("pitch", ((V)(0D))).V);
Invoke(t_212, "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(3D)));
Invoke(t_212, "wait", ((V)(140D)));
Invoke(t_212, "to", ((V)(75D)), NewObj(3).Put("tilt", ((V)((1.5 * d_213)))).Put("lean", ((V)((0.4 * d_213)))).Put("sq", ((V)(0.03))).V, ((V)("io")));
Invoke(t_212, "to", ((V)(155D)), NewObj(6).Put("sq", ((V)(0.14))).Put("spin", ((V)(((-32D) * d_213)))).Put("turn", ((V)(((-0.12) * d_213)))).Put("tilt", ((V)(((-3D) * d_213)))).Put("lean", ((V)(((-1D) * d_213)))).Put("wag", ((V)((14D * d_213)))).V, ((V)("o")));
Invoke(t_212, "to", ((V)(100D)), NewObj(2).Put("sq", ((V)(0.16))).Put("spin", ((V)(((-36D) * d_213)))).V, ((V)("io")));
V_214 = 1980D;
s0_215 = Get(t_212, "t");
END_216 = (59D * 360D);
RUN_217 = Round(((((END_216 + 18D) - 40D) / V_214) * 1000D));
TOT_218 = ((50D + RUN_217) + 200D);
Invoke(Invoke(Invoke(t_212, "to", ((V)(50D)), NewObj(5).Put("sblur", ((V)(0.5))).Put("sq", ((V)((-0.1)))).Put("turn", ((V)(0D))).Put("tilt", ((V)((4D * d_213)))).Put("lean", ((V)((0.6 * d_213)))).V, ((V)("l"))), "to", ((V)(110D)), NewObj(4).Put("sq", ((V)(0.08))).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("wag", ((V)(0D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.04))).V, ((V)("io")));
Invoke(Invoke(t_212, "at", s0_215), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D)));
Invoke(t_212, "at", Add(s0_215, ((V)(250D))));
nW_219 = System.Math.Floor(((TOT_218 - 750D) / 400D));
{
double i_222 = 0;
i_222 = 0D;
while (true) {
if (!((i_222 < nW_219))) break;
double g_224 = 0;
double w_225 = 0;
g_224 = (Min(1D, (i_222 / 3D)) * ((i_222 > (nW_219 - 4D)) ? ((nW_219 - i_222) / 4D) : 1D));
w_225 = (2D + (4D * g_224));
Invoke(Invoke(t_212, "to", ((V)(200D)), NewObj(2).Put("tilt", ((V)(w_225))).Put("lean", ((V)((w_225 * 0.5)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("tilt", ((V)((-w_225)))).Put("lean", ((V)(((-w_225) * 0.5)))).V, ((V)("io")));
i_222++;
}
}
Invoke(t_212, "to", ((V)(300D)), NewObj(2).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
Invoke(Arr(((V)(3200D)), ((V)(8200D))), "forEach", Fn((V _arrowThis233, int _argc226, V h_232, V _a229, V _a230, V _a231, V[] _rest227) => {
Invoke(t_212, "at", Add(s0_215, h_232));
Call(jump_19, V.Undef, t_212, NewObj(6).Put("h", ((V)(5D))).Put("ant", ((V)(140D))).Put("up", ((V)(220D))).Put("c", ((V)(0.1))).Put("arm", ((V)(0D))).Put("ev", Arr(Arr(((V)("emit")), ((V)("spark")), ((V)("body")), ((V)(3D))))).V);
return default;
}, 1, "", true));
{
double k_234 = 0;
k_234 = 0D;
while (true) {
if (!(((k_234 * 400D) < (TOT_218 - 300D)))) break;
Invoke(Invoke(t_212, "at", Add(Add(s0_215, ((V)(250D))), ((V)((k_234 * 400D))))), "e", ((V)("emit")), ((V)((NumTruthy((k_234 % 2D)) ? "spark" : "dust"))), ((V)("body")), ((V)((NumTruthy((k_234 % 2D)) ? 2D : 1D))));
k_234++;
}
}
Invoke(Invoke(t_212, "at", Add(Add(s0_215, ((V)(50D))), ((V)(RUN_217)))), "to", ((V)(200D)), NewObj(2).Put("sblur", ((V)(0D))).Put("sq", ((V)(0.12))).V, ((V)("o")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_212, "at", s0_215), "to", ((V)(50D)), NewObj(1).Put("spin", ((V)((40D * d_213)))).V, ((V)("l"))), "to", ((V)(RUN_217)), NewObj(1).Put("spin", ((V)(((END_216 + 18D) * d_213)))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(1).Put("spin", ((V)((END_216 * d_213)))).V, ((V)("o"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(t_212, "at", Add(Add(s0_215, ((V)(TOT_218))), ((V)(60D))));
Call(popOut_29, V.Undef, t_212, NewObj(5).Put("cross", ((V)(1D))).Put("open", ((V)(0.4))).Put("hap", ((V)(0D))).Put("smile", ((V)(0.4))).Put("wide", ((V)(0.4))).V);
Invoke(Invoke(t_212, "at", Add(Add(s0_215, ((V)(TOT_218))), ((V)(120D)))), "to", ((V)(320D)), NewObj(1).Put("dz", ((V)(1D))).V, ((V)("o")));
Invoke(Invoke(t_212, "osc", ((V)(1500D)), ((V)(3D)), NewObj(5).Put("htilt", ((V)(10D))).Put("tilt", ((V)(3.5))).Put("nk", ((V)(0.6))).Put("x", ((V)(1.2))).Put("hyaw", ((V)(0.12))).V, NewObj(5).Put("htilt", ((V)((-10D)))).Put("tilt", ((V)((-3.5)))).Put("nk", ((V)(0.15))).Put("x", ((V)((-1.2)))).Put("hyaw", ((V)((-0.12)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(5).Put("htilt", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("nk", ((V)(0.3))).V, ((V)("io")));
sk_220 = Get(t_212, "t");
Call(shake_21, V.Undef, t_212, NewObj(6).Put("P", ((V)(115D))).Put("env", Arr(((V)(0.7)), ((V)(1D)), ((V)(0.55)), ((V)(0.2)))).Put("head", ((V)(0.3))).Put("roll", ((V)(5D))).Put("ear", ((V)(0D))).Put("chest", ((V)(0.05))).V);
sk2_221 = Get(t_212, "t");
Invoke(Invoke(Invoke(t_212, "at", Add(sk_220, ((V)(150D)))), "to", ((V)((ToNum(sk2_221) - ToNum(sk_220)))), NewObj(1).Put("dz", ((V)(0D))).V, ((V)("io"))), "at", sk2_221);
Invoke(t_212, "to", ((V)(220D)), NewObj(5).Put("cross", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.45))).V, ((V)("io")));
Invoke(t_212, "wait", ((V)(200D)));
return Invoke(Invoke(t_212, "rest", ((V)(260D))), "loop", NewObj(2).Put("stretch", ((V)(0.6))).Put("whip", ((V)(1D))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Shell Spin")), ((V)("Ducks into her shell, then gets ready like a pirouette (the shell coils the other way and holds), whips round with a blur - and keeps spinning super fast (5.5 turns a second) for over 10 seconds like a spinning top (two hops along the way), lands facing you, pops out dizzy and cross-eyed with cartoon stars circling over her head, shakes it off - and goes again, until you stop her.")))).Put("seaturtle", Arr(Call(Fn((V _arrowThis242, int _argc236, V _a238, V _a239, V _a240, V _a241, V[] _rest237) => {
V t_243 = default;
V stroke2_244 = default;
t_243 = Call(TL_17, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
stroke2_244 = Fn((V _arrowThis254, int _argc245, V dur_251, V x_252, V tl_253, V _a250, V[] _rest246) => {
return Invoke(Invoke(t_243, "to", ((V)((ToNum(dur_251) * 0.45))), NewObj(8).Put("armL", ((V)(85D))).Put("armR", ((V)(85D))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).Put("lift", ((V)(1.4))).Put("x", x_252).Put("tilt", tl_253).Put("nk", ((V)(0.6))).V, ((V)("o"))), "to", ((V)((ToNum(dur_251) * 0.55))), NewObj(6).Put("armL", ((V)((-8D)))).Put("armR", ((V)((-8D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).Put("nk", ((V)(0.3))).V, ((V)("io")));
}, 3, "", true);
Invoke(Invoke(t_243, "to", ((V)(300D)), NewObj(2).Put("nk", ((V)(0.7))).Put("pitch", ((V)(0.08))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(2D)));
Call(stroke2_244, V.Undef, ((V)(900D)), ((V)((-4D))), ((V)((-4D))));
Call(stroke2_244, V.Undef, ((V)(900D)), ((V)((-7D))), ((V)((-5D))));
Invoke(t_243, "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(2D)));
Call(stroke2_244, V.Undef, ((V)(900D)), ((V)(4D)), ((V)(4D)));
Call(stroke2_244, V.Undef, ((V)(900D)), ((V)(7D)), ((V)(5D)));
Invoke(t_243, "e", ((V)("emit")), ((V)("bubble")), ((V)("head")), ((V)(2D)));
Invoke(Invoke(Invoke(t_243, "to", ((V)(500D)), NewObj(5).Put("x", ((V)(0D))).Put("tilt", ((V)((-14D)))).Put("lean", ((V)((-4D)))).Put("armL", ((V)(90D))).Put("armR", ((V)((-10D)))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(4).Put("tilt", ((V)(14D))).Put("lean", ((V)(4D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)(90D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(4).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
{
double i_255 = 0;
i_255 = 0D;
while (true) {
if (!((i_255 < 2D))) break;
Invoke(Invoke(Invoke(Invoke(t_243, "to", ((V)(220D)), NewObj(2).Put("armR", ((V)(100D))).Put("hyaw", ((V)(0.2))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(1).Put("armR", ((V)(60D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(1).Put("armR", ((V)(100D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("armR", ((V)(0D))).Put("hyaw", ((V)(0D))).V, ((V)("io")));
i_255++;
}
}
Invoke(t_243, "to", ((V)(700D)), NewObj(2).Put("spin", ((V)(90D))).Put("nk", ((V)(0.8))).V, ((V)("io")));
Call(stroke2_244, V.Undef, ((V)(800D)), ((V)(0D)), ((V)(0D)));
Call(stroke2_244, V.Undef, ((V)(800D)), ((V)(0D)), ((V)(0D)));
Invoke(t_243, "to", ((V)(700D)), NewObj(2).Put("spin", ((V)(0D))).Put("nk", ((V)(0.4))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_243, "to", ((V)(1400D)), NewObj(7).Put("spin", ((V)(360D))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).Put("footL", ((V)(3D))).Put("footR", ((V)(3D))).Put("lift", ((V)(2D))).Put("nk", ((V)(0.9))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("bubble")), ((V)("body")), ((V)(4D))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_243, "to", ((V)(400D)), NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).Put("nk", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("winkL", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(1).Put("winkL", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return Invoke(Invoke(t_243, "rest", ((V)(400D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Ocean Glide")), ((V)("Swims on the spot: gliding strokes to the left and right with its big flippers, a slow graceful roll, waves a flipper at you, turns to show its side as it swims past, a dreamy full turn on the current, bubbles all along, then a wink.")))).V;
Invoke(KEYS_8, "forEach", Fn((V _arrowThis264, int _argc257, V k_263, V _a260, V _a261, V _a262, V[] _rest258) => {
Set(GetK(MOVES_32, k_263), "dance", GetK(DANCES_33, k_263));
return default;
}, 1, "", true));
Call(install_25, V.Undef, MOVES_32, CARDS_31);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_292 => Fn((V _self265, int _argc266, V _a268, V _a269, V _a270, V _a271, V[] _rest267) => {
V R_272 = default;
V S_273 = default;
V o_274 = default;
V jump_275 = default;
V shake_276 = default;
V jelly_277 = default;
V see_278 = default;
V unsee_279 = default;
V giggle_280 = default;
V sniff_281 = default;
V lick_282 = default;
V leanIn_283 = default;
V para_284 = default;
V build_285 = default;
V duck_286 = default;
V popOut_287 = default;
V tasteHeart_288 = default;
V BODY_289 = default;
V RE_290 = default;
V TXT_291 = default;
if (_self265.IsNullish) _self265 = GlobalV;
R_272 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_272)) || !(Truthy(Get(R_272, "POKELIB")))) || !(Truthy(Get(R_272, "oceanV")))) || !(Truthy(Get(Get(R_272, "STATES"), "poke_head"))))) {
Call(G("setTimeout"), V.Undef, boot_292.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_272, "oceanPokeV"))) {
return default;
}
Set(R_272, "oceanPokeV", ((V)(1D)));
{ V _t293 = Get(R_272, "PETLIB");
if (_t293.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t293));
{ V _t294 = Get(_t293, "S");
S_273 = _t294; }
{ V _t295 = Get(_t293, "o");
o_274 = _t295; }
{ V _t296 = Get(_t293, "jump");
jump_275 = _t296; }
{ V _t297 = Get(_t293, "shake");
shake_276 = _t297; }
{ V _t298 = Get(_t293, "jelly");
jelly_277 = _t298; } }
{ V _t299 = Get(R_272, "POKELIB");
if (_t299.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t299));
{ V _t300 = Get(_t299, "see");
see_278 = _t300; }
{ V _t301 = Get(_t299, "unsee");
unsee_279 = _t301; }
{ V _t302 = Get(_t299, "giggle");
giggle_280 = _t302; }
{ V _t303 = Get(_t299, "sniff");
sniff_281 = _t303; }
{ V _t304 = Get(_t299, "lick");
lick_282 = _t304; }
{ V _t305 = Get(_t299, "leanIn");
leanIn_283 = _t305; }
{ V _t306 = Get(_t299, "para");
para_284 = _t306; }
{ V _t307 = Get(_t299, "build");
build_285 = _t307; } }
duck_286 = Fn((V _arrowThis316, int _argc308, V t_314, V a_315, V _a312, V _a313, V[] _rest309) => {
return Invoke(Invoke(Invoke(t_314, "to", ((V)(110D)), NewObj(2).Put("nk", ((V)(0.3))).Put("wide", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(120D)), NewObj(4).Put("hid", (a_315.IsNullish ? ((V)(1D)) : a_315)).Put("sq", ((V)(0.12))).Put("wide", ((V)(0D))).Put("nk", ((V)(0D))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.05))).V, ((V)("io")));
}, 2, "", true);
popOut_287 = Fn((V _arrowThis324, int _argc317, V t_323, V _a320, V _a321, V _a322, V[] _rest318) => {
return Invoke(Invoke(Invoke(t_323, "to", ((V)(160D)), NewObj(3).Put("hid", ((V)(0D))).Put("nk", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(2).Put("nk", ((V)(0.2))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("nk", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
tasteHeart_288 = Fn((V _arrowThis332, int _argc325, V t_331, V _a328, V _a329, V _a330, V[] _rest326) => {
Call(lick_282, V.Undef, t_331, ((V)(2D)));
return Invoke(Invoke(Invoke(Invoke(t_331, "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(320D))), "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true);
BODY_289 = NewObj(2).Put("shelly", NewObj(5).Put("ear", ((V)(0D))).Put("tail", ((V)(1D))).Put("noWalk", ((V)(1D))).Put("earTap", Arr(((V)(33D)), ((V)(37D)))).Put("lbl", NewObj(7).Put("ear", ((V)("shell top"))).Put("head", ((V)("Head"))).Put("nose", ((V)("Nose"))).Put("belly", ((V)("Belly shell"))).Put("side", ((V)("shell"))).Put("foot", ((V)("flipper"))).Put("tail", ((V)("Little tail"))).V).V).Put("seaturtle", NewObj(5).Put("ear", ((V)(0D))).Put("tail", ((V)(1D))).Put("noWalk", ((V)(1D))).Put("earTap", Arr(((V)(33D)), ((V)(37D)))).Put("lbl", NewObj(7).Put("ear", ((V)("shell top"))).Put("head", ((V)("Head"))).Put("nose", ((V)("Nose"))).Put("belly", ((V)("Belly shell"))).Put("side", ((V)("shell"))).Put("foot", ((V)("flipper"))).Put("tail", ((V)("Little tail"))).V).V).V;
RE_290 = NewObj(2).Put("shelly", NewObj(9).Put("head", Fn((V _arrowThis341, int _argc333, V t_339, V s_340, V _a337, V _a338, V[] _rest334) => {
Call(duck_286, V.Undef, t_339);
Invoke(Invoke(Invoke(t_339, "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(3).Put("hid", ((V)(0.55))).Put("lx", ((V)(0D))).Put("ly", ((V)((-0.6)))).V, ((V)("io"))), "wait", ((V)(300D)));
Call(popOut_287, V.Undef, t_339);
Call(giggle_280, V.Undef, t_339, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis350, int _argc342, V t_348, V s_349, V _a346, V _a347, V[] _rest343) => {
V k_351 = default;
k_351 = Call(S_273, V.Undef, s_349);
Invoke(Invoke(Invoke(t_348, "to", ((V)(80D)), NewObj(2).Put("tilt", ((V)((ToNum(s_349) * 4D)))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)(((-ToNum(s_349)) * 2D)))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(see_278, V.Undef, t_348, ((V)("ear")), s_349, ((V)(250D)));
Invoke(Invoke(Invoke(t_348, "to", ((V)(260D)), NewObj(2).PutK(Get(k_351, "arm"), ((V)(70D))).Put("nk", ((V)(0.3))).V, ((V)("io"))), "osc", ((V)(420D)), ((V)(2D)), NewObj(1).PutK(Get(k_351, "arm"), ((V)(85D))).V, NewObj(1).PutK(Get(k_351, "arm"), ((V)(65D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).PutK(Get(k_351, "arm"), ((V)(0D))).V, ((V)("io")));
Call(unsee_279, V.Undef, t_348);
Call(giggle_280, V.Undef, t_348, ((V)(1D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis360, int _argc352, V t_358, V s_359, V _a356, V _a357, V[] _rest353) => {
Invoke(t_358, "to", ((V)(250D)), NewObj(2).Put("nk", ((V)(0.7))).Put("cross", ((V)(0D))).V, ((V)("io")));
Call(sniff_281, V.Undef, t_358, ((V)(2D)));
Call(tasteHeart_288, V.Undef, t_358);
Invoke(t_358, "to", ((V)(250D)), NewObj(1).Put("nk", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis369, int _argc361, V t_367, V s_368, V _a365, V _a366, V[] _rest362) => {
V k_370 = default;
k_370 = Call(S_273, V.Undef, s_368);
Invoke(Invoke(Invoke(Invoke(t_367, "e", ((V)("blink2"))), "to", ((V)(200D)), NewObj(2).PutK(Get(k_370, "wink"), ((V)(1D))).Put("nk", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(220D)), NewObj(2).PutK(Get(k_370, "wink"), ((V)(0D))).Put("nk", ((V)(0D))).V, ((V)("io")));
Call(shake_276, V.Undef, t_367, NewObj(5).Put("P", ((V)(110D))).Put("env", Arr(((V)(0.5)), ((V)(0.8)), ((V)(0.4)))).Put("head", ((V)(0.22))).Put("roll", ((V)(3D))).Put("ear", ((V)(0D))).V);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis379, int _argc371, V t_377, V s_378, V _a375, V _a376, V[] _rest372) => {
Call(leanIn_283, V.Undef, t_377, s_378);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis388, int _argc380, V t_386, V s_387, V _a384, V _a385, V[] _rest381) => {
V a_389 = default;
Invoke(t_386, "to", ((V)(220D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("io")));
a_389 = Get(t_386, "t");
Call(giggle_280, V.Undef, t_386, ((V)(3D)), ((V)(0.9)));
Call(para_284, V.Undef, t_386, a_389, Fn((V _arrowThis397, int _argc390, V u_396, V _a393, V _a394, V _a395, V[] _rest391) => {
return Invoke(Invoke(u_396, "osc", ((V)(1000D)), ((V)(3D)), NewObj(5).Put("footL", ((V)(3D))).Put("footR", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(0D))).Put("tilt", ((V)(4D))).V, NewObj(5).Put("footL", ((V)(0D))).Put("footR", ((V)(3D))).Put("armL", ((V)(0D))).Put("armR", ((V)(30D))).Put("tilt", ((V)((-4D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(5).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis406, int _argc398, V t_404, V s_405, V _a402, V _a403, V[] _rest399) => {
Call(duck_286, V.Undef, t_404, ((V)(0.75)));
Invoke(Invoke(Invoke(t_404, "to", ((V)(420D)), NewObj(1).Put("spin", ((V)(((-ToNum(s_405)) * 70D)))).V, ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(460D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("io")));
Call(popOut_287, V.Undef, t_404);
Call(see_278, V.Undef, t_404, ((V)("side")), s_405, ((V)(200D)));
Call(unsee_279, V.Undef, t_404, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis415, int _argc407, V t_413, V s_414, V _a411, V _a412, V[] _rest408) => {
V k_416 = default;
k_416 = Call(S_273, V.Undef, s_414);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_413, "to", ((V)(100D)), NewObj(2).PutK(Get(k_416, "foot"), ((V)(0D))).Put("hid", ((V)(0.4))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(160D)), NewObj(2).Put("hid", ((V)(0D))).PutK(Get(k_416, "foot"), ((V)(3D))).V, ((V)("o"))), "to", ((V)(120D)), NewObj(2).PutK(Get(k_416, "foot"), ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(1D))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(see_278, V.Undef, t_413, ((V)("foot")), s_414, ((V)(200D)));
Call(unsee_279, V.Undef, t_413);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis425, int _argc417, V t_423, V s_424, V _a421, V _a422, V[] _rest418) => {
Invoke(Invoke(t_423, "osc", ((V)(600D)), ((V)(3D)), NewObj(1).Put("wag", ((V)(26D))).V, NewObj(1).Put("wag", ((V)((-26D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
Call(see_278, V.Undef, t_423, ((V)("tail")), ((V)(1D)), ((V)(350D)));
Call(unsee_279, V.Undef, t_423, ((V)(380D)));
Call(giggle_280, V.Undef, t_423, ((V)(1D)));
return default;
}, 2, "tail", true)).V).Put("seaturtle", NewObj(9).Put("head", Fn((V _arrowThis434, int _argc426, V t_432, V s_433, V _a430, V _a431, V[] _rest427) => {
Invoke(Invoke(t_432, "to", ((V)(120D)), NewObj(3).Put("nk", ((V)((-0.4)))).Put("close", ((V)(0.7))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(3).Put("nk", ((V)(0.5))).Put("close", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(giggle_280, V.Undef, t_432, ((V)(2D)));
Invoke(Invoke(t_432, "to", ((V)(260D)), NewObj(2).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis443, int _argc435, V t_441, V s_442, V _a439, V _a440, V[] _rest436) => {
V k_444 = default;
k_444 = Call(S_273, V.Undef, s_442);
Invoke(Invoke(Invoke(t_441, "to", ((V)(80D)), NewObj(2).Put("tilt", ((V)((ToNum(s_442) * 4D)))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)(((-ToNum(s_442)) * 2D)))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(see_278, V.Undef, t_441, ((V)("ear")), s_442, ((V)(250D)));
Invoke(Invoke(Invoke(t_441, "to", ((V)(260D)), NewObj(2).PutK(Get(k_444, "arm"), ((V)(80D))).Put("nk", ((V)(0.4))).V, ((V)("io"))), "osc", ((V)(420D)), ((V)(2D)), NewObj(1).PutK(Get(k_444, "arm"), ((V)(95D))).V, NewObj(1).PutK(Get(k_444, "arm"), ((V)(70D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).PutK(Get(k_444, "arm"), ((V)(0D))).V, ((V)("io")));
Call(unsee_279, V.Undef, t_441);
Call(giggle_280, V.Undef, t_441, ((V)(1D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis453, int _argc445, V t_451, V s_452, V _a449, V _a450, V[] _rest446) => {
Invoke(t_451, "to", ((V)(250D)), NewObj(1).Put("nk", ((V)(0.8))).V, ((V)("io")));
Call(sniff_281, V.Undef, t_451, ((V)(2D)));
Call(tasteHeart_288, V.Undef, t_451);
Invoke(t_451, "to", ((V)(250D)), NewObj(1).Put("nk", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis462, int _argc454, V t_460, V s_461, V _a458, V _a459, V[] _rest455) => {
V k_463 = default;
k_463 = Call(S_273, V.Undef, s_461);
Invoke(Invoke(Invoke(Invoke(t_460, "e", ((V)("blink2"))), "to", ((V)(200D)), NewObj(2).PutK(Get(k_463, "wink"), ((V)(1D))).Put("nk", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(220D)), NewObj(2).PutK(Get(k_463, "wink"), ((V)(0D))).Put("nk", ((V)(0D))).V, ((V)("io")));
Call(shake_276, V.Undef, t_460, NewObj(5).Put("P", ((V)(110D))).Put("env", Arr(((V)(0.5)), ((V)(0.8)), ((V)(0.4)))).Put("head", ((V)(0.22))).Put("roll", ((V)(3D))).Put("ear", ((V)(0D))).V);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis472, int _argc464, V t_470, V s_471, V _a468, V _a469, V[] _rest465) => {
Call(leanIn_283, V.Undef, t_470, s_471);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis481, int _argc473, V t_479, V s_480, V _a477, V _a478, V[] _rest474) => {
V a_482 = default;
Invoke(t_479, "to", ((V)(220D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("io")));
a_482 = Get(t_479, "t");
Call(giggle_280, V.Undef, t_479, ((V)(3D)), ((V)(0.9)));
Call(para_284, V.Undef, t_479, a_482, Fn((V _arrowThis490, int _argc483, V u_489, V _a486, V _a487, V _a488, V[] _rest484) => {
return Invoke(Invoke(u_489, "osc", ((V)(1000D)), ((V)(4D)), NewObj(5).Put("armL", ((V)(70D))).Put("armR", ((V)(10D))).Put("footL", ((V)(3D))).Put("footR", ((V)(0D))).Put("tilt", ((V)(3D))).V, NewObj(5).Put("armL", ((V)(10D))).Put("armR", ((V)(70D))).Put("footL", ((V)(0D))).Put("footR", ((V)(3D))).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(5).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis499, int _argc491, V t_497, V s_498, V _a495, V _a496, V[] _rest492) => {
Invoke(Invoke(Invoke(t_497, "to", ((V)(380D)), NewObj(3).Put("spin", ((V)(((-ToNum(s_498)) * 40D)))).PutK(Get(Call(S_273, V.Undef, ((V)((-ToNum(s_498))))), "arm"), ((V)(60D))).Put("nk", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(420D)), NewObj(3).Put("spin", ((V)(0D))).PutK(Get(Call(S_273, V.Undef, ((V)((-ToNum(s_498))))), "arm"), ((V)(0D))).Put("nk", ((V)(0D))).V, ((V)("io")));
Call(see_278, V.Undef, t_497, ((V)("side")), s_498, ((V)(200D)));
Call(unsee_279, V.Undef, t_497, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis508, int _argc500, V t_506, V s_507, V _a504, V _a505, V[] _rest501) => {
V k_509 = default;
k_509 = Call(S_273, V.Undef, s_507);
Invoke(Invoke(Invoke(Invoke(Invoke(t_506, "to", ((V)(120D)), NewObj(1).PutK(Get(k_509, "arm"), ((V)(90D))).V, ((V)("o"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).PutK(Get(k_509, "arm"), ((V)(60D))).V, NewObj(1).PutK(Get(k_509, "arm"), ((V)(95D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).PutK(Get(k_509, "arm"), ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(1D))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(see_278, V.Undef, t_506, ((V)("foot")), s_507, ((V)(200D)));
Call(unsee_279, V.Undef, t_506);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis518, int _argc510, V t_516, V s_517, V _a514, V _a515, V[] _rest511) => {
Invoke(Invoke(t_516, "osc", ((V)(600D)), ((V)(3D)), NewObj(3).Put("wag", ((V)(26D))).Put("footL", ((V)(2D))).Put("footR", ((V)(2D))).V, NewObj(3).Put("wag", ((V)((-26D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("wag", ((V)(0D))).V, ((V)("io")));
Call(see_278, V.Undef, t_516, ((V)("tail")), ((V)(1D)), ((V)(350D)));
Call(unsee_279, V.Undef, t_516, ((V)(380D)));
Call(giggle_280, V.Undef, t_516, ((V)(1D)));
return default;
}, 2, "tail", true)).V).V;
TXT_291 = NewObj(2).Put("shelly", NewObj(9).Put("head", ((V)("Boop! She ducks into her shell, peeks out and pops back out giggling."))).Put("ear", ((V)("Knock knock on her shell - it rocks, she looks up and pats the spot with a flipper."))).Put("nose", ((V)("Stretches her neck out to sniff your finger and licks it: a heart."))).Put("eye", ((V)("Blinks hard, tucks her neck a little, a small head shake."))).Put("cheek", ((V)("Leans her head into your finger."))).Put("belly", ((V)("Ticklish: giggles with her little legs kicking and her shell rocking."))).Put("side", ((V)("Tucks in and her shell turns away from the poke, then she turns back and peeks."))).Put("foot", ((V)("Pulls that flipper into her shell, then stomps it back down."))).Put("tail", ((V)("Her little tail wiggles, she looks back and giggles."))).V).Put("seaturtle", NewObj(9).Put("head", ((V)("Boop! Its head bobs down, it giggles and gives a happy flipper flap."))).Put("ear", ((V)("Tap on its shell - it rocks, looks up and pats the spot with a big flipper."))).Put("nose", ((V)("Stretches its neck out to sniff your finger and licks it: a heart."))).Put("eye", ((V)("Blinks hard, tucks its neck a little, a small head shake."))).Put("cheek", ((V)("Leans its head into your finger."))).Put("belly", ((V)("Ticklish: giggles while all four flippers paddle."))).Put("side", ((V)("Turns a little away from the poke with a flipper flap, then turns back and peeks."))).Put("foot", ((V)("Waves that big flipper, then pats it down on the ground."))).Put("tail", ((V)("Its little tail wiggles with the back flippers, it looks back and giggles."))).V).V;
Call(build_285, V.Undef, RE_290, TXT_291, BODY_289);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_535 => Fn((V _self519, int _argc520, V _a522, V _a523, V _a524, V _a525, V[] _rest521) => {
V R_526 = default;
V o_527 = default;
V jump_528 = default;
V EAR_529 = default;
V sniffF_530 = default;
V lipLick_531 = default;
V hearts_532 = default;
V buildAll_533 = default;
V CARDS_534 = default;
if (_self519.IsNullish) _self519 = GlobalV;
R_526 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_526)) || !(Truthy(Get(R_526, "EATKIT")))) || !(Truthy(Get(R_526, "oceanV")))) || !(Truthy(Get(R_526, "EATLIB"))))) {
Call(G("setTimeout"), V.Undef, boot_535.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_526, "oceanEatV"))) {
return default;
}
Set(R_526, "oceanEatV", ((V)(1D)));
{ V _t536 = Get(R_526, "PETLIB");
if (_t536.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t536));
{ V _t537 = Get(_t536, "o");
o_527 = _t537; }
{ V _t538 = Get(_t536, "jump");
jump_528 = _t538; } }
{ V _t539 = Get(R_526, "EATKIT");
if (_t539.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t539));
{ V _t540 = Get(_t539, "EAR");
EAR_529 = _t540; }
{ V _t541 = Get(_t539, "sniffF");
sniffF_530 = _t541; }
{ V _t542 = Get(_t539, "lipLick");
lipLick_531 = _t542; }
{ V _t543 = Get(_t539, "hearts");
hearts_532 = _t543; }
{ V _t544 = Get(_t539, "buildAll");
buildAll_533 = _t544; } }
Object_assign(EAR_529, NewObj(2).Put("shelly", ((V)(0D))).Put("seaturtle", ((V)(0D))).V);
CARDS_534 = NewObj(2).Put("shelly", NewObj(9).Put("chewMs", ((V)(150D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Stretches her neck out to sniff it, slow careful turtle bites; flaps her flippers and wags her little tail when she likes it."))).Put("pre", Fn((V _arrowThis552, int _argc545, V t_551, V _a548, V _a549, V _a550, V[] _rest546) => {
Invoke(t_551, "to", ((V)(300D)), NewObj(1).Put("nk", ((V)(0.8))).V, ((V)("io")));
Call(sniffF_530, V.Undef, t_551, ((V)(1D)));
Invoke(t_551, "to", ((V)(260D)), NewObj(1).Put("nk", ((V)(0.3))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis560, int _argc553, V t_559, V _a556, V _a557, V _a558, V[] _rest554) => {
Call(lipLick_531, V.Undef, t_559);
Invoke(t_559, "to", ((V)(250D)), NewObj(1).Put("nk", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _arrowThis568, int _argc561, V t_567, V _a564, V _a565, V _a566, V[] _rest562) => {
Invoke(Invoke(Invoke(Invoke(t_567, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(4).Put("nk", ((V)(1D))).Put("armL", ((V)(60D))).Put("armR", ((V)(0D))).Put("wag", ((V)(18D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(60D))).Put("wag", ((V)((-18D)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wag", ((V)(0D))).Put("nk", ((V)(0.2))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis576, int _argc569, V t_575, V _a572, V _a573, V _a574, V[] _rest570) => {
Call(hearts_532, V.Undef, t_575, ((V)(2D)));
Invoke(Invoke(Invoke(Invoke(t_575, "to", ((V)(120D)), NewObj(2).Put("hid", ((V)(0.6))).Put("blush", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(180D)), NewObj(2).Put("hid", ((V)(0D))).Put("nk", ((V)(1D))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(1).Put("nk", ((V)(0.2))).V, ((V)("io")));
Invoke(Get(CARDS_534, "shelly"), "yum", t_575);
return default;
}, 1, "love", true)).V).Put("seaturtle", NewObj(9).Put("chewMs", ((V)(150D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Stretches its neck out to sniff it, slow careful sea-turtle bites; paddles its big flippers when it likes it."))).Put("pre", Fn((V _arrowThis584, int _argc577, V t_583, V _a580, V _a581, V _a582, V[] _rest578) => {
Invoke(t_583, "to", ((V)(300D)), NewObj(1).Put("nk", ((V)(0.8))).V, ((V)("io")));
Call(sniffF_530, V.Undef, t_583, ((V)(1D)));
Invoke(t_583, "to", ((V)(260D)), NewObj(1).Put("nk", ((V)(0.3))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis592, int _argc585, V t_591, V _a588, V _a589, V _a590, V[] _rest586) => {
Call(lipLick_531, V.Undef, t_591);
Invoke(t_591, "to", ((V)(250D)), NewObj(1).Put("nk", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _arrowThis600, int _argc593, V t_599, V _a596, V _a597, V _a598, V[] _rest594) => {
Invoke(Invoke(Invoke(Invoke(t_599, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(4).Put("nk", ((V)(0.9))).Put("armL", ((V)(70D))).Put("armR", ((V)(10D))).Put("wag", ((V)(14D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(3).Put("armL", ((V)(10D))).Put("armR", ((V)(70D))).Put("wag", ((V)((-14D)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wag", ((V)(0D))).Put("nk", ((V)(0.2))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis608, int _argc601, V t_607, V _a604, V _a605, V _a606, V[] _rest602) => {
Call(hearts_532, V.Undef, t_607, ((V)(2D)));
Invoke(Invoke(t_607, "to", ((V)(160D)), NewObj(4).Put("blush", ((V)(1D))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("lift", ((V)(1.5))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
Invoke(Get(CARDS_534, "seaturtle"), "yum", t_607);
return default;
}, 1, "love", true)).V).V;
Call(buildAll_533, V.Undef, CARDS_534);
return default;
}, 0, "boot", false)), V.Undef);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
