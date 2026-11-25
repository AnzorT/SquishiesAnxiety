// snack2-anims.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_snack2_anims_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V CH_8 = default;
V KEYS_9 = default;
V preset_10 = default;
if (_self1.IsNullish) _self1 = GlobalV;
CH_8 = NewObj(20).Put("slip", ((V)(0D))).Put("hug", ((V)(0D))).Put("pop", ((V)(0D))).Put("cfz", ((V)(0D))).Put("pull", ((V)(0D))).Put("flop", ((V)(0D))).Put("ume", ((V)(0D))).Put("nwr", ((V)(0D))).Put("wob", ((V)(0D))).Put("cap", ((V)(0D))).Put("rl", ((V)(0D))).Put("snap", ((V)(0D))).Put("cork", ((V)(0D))).Put("kt", ((V)(0D))).Put("knot", ((V)(0D))).Put("veg", ((V)(0D))).Put("slurp", ((V)(0D))).Put("lid", ((V)(0D))).Put("fluff", ((V)(0D))).Put("swirl", ((V)(0D))).V;
KEYS_9 = Arr(((V)("frankie")), ((V)("corny")), ((V)("peppi")), ((V)("nori")), ((V)("sunny")), ((V)("toco")), ((V)("churro")), ((V)("khinki")), ((V)("maki")), ((V)("noodle")), ((V)("flossie")));
preset_10 = Fn((V _arrowThis18, int _argc11, V R_17, V _a14, V _a15, V _a16, V[] _rest12) => {
V P_19 = default;
P_19 = Get(R_17, "PRE");
if (Truthy(((!(Truthy(P_19)) ? V.True : V.False) is var _t20 && Truthy(_t20) ? _t20 : Get(P_19, "mustard")))) {
return default;
}
Object_assign(P_19, NewObj(8).Put("mustard", NewObj(8).Put("n", ((V)(5D))).Put("sp", ((V)(18D))).Put("vy", ((V)((-16D)))).Put("g", ((V)(70D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.7)), ((V)(1.2)))).Put("col", Arr(((V)("#ffd43b")), ((V)("#ffc21a")), ((V)("#ffe27a")))).Put("kind", ((V)("drop"))).V).Put("popk", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(26D))).Put("vy", ((V)((-30D)))).Put("g", ((V)(90D))).Put("life", ((V)(1100D))).Put("r", Arr(((V)(1.5)), ((V)(2.3)))).Put("col", Arr(((V)("#fffdf0")), ((V)("#ffeaa8")), ((V)("#fff3c4")))).Put("kind", ((V)("puff"))).V).Put("cheese", NewObj(8).Put("n", ((V)(5D))).Put("sp", ((V)(16D))).Put("vy", ((V)((-10D)))).Put("g", ((V)(80D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.8)), ((V)(1.3)))).Put("col", Arr(((V)("#ffd45c")), ((V)("#ffc63a")), ((V)("#ffe27a")))).Put("kind", ((V)("drop"))).V).Put("rice", NewObj(8).Put("n", ((V)(6D))).Put("sp", ((V)(18D))).Put("vy", ((V)((-14D)))).Put("g", ((V)(80D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.5)), ((V)(0.9)))).Put("col", Arr(((V)("#ffffff")), ((V)("#f6f2e8")))).Put("kind", ((V)("dot"))).V).Put("floss", NewObj(8).Put("n", ((V)(5D))).Put("sp", ((V)(14D))).Put("vy", ((V)((-10D)))).Put("g", ((V)(10D))).Put("life", ((V)(1500D))).Put("r", Arr(((V)(1.2)), ((V)(2.2)))).Put("col", Arr(((V)("#ffc6e2")), ((V)("#c4e6ff")), ((V)("#fff0f7")))).Put("kind", ((V)("puff"))).V).Put("broth", NewObj(8).Put("n", ((V)(5D))).Put("sp", ((V)(18D))).Put("vy", ((V)((-18D)))).Put("g", ((V)(80D))).Put("life", ((V)(800D))).Put("r", Arr(((V)(0.6)), ((V)(1.1)))).Put("col", Arr(((V)("#f0b25a")), ((V)("#ffd79a")))).Put("kind", ((V)("drop"))).V).Put("pepper", NewObj(8).Put("n", ((V)(6D))).Put("sp", ((V)(16D))).Put("vy", ((V)((-14D)))).Put("g", ((V)(70D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.4)), ((V)(0.7)))).Put("col", Arr(((V)("#3e3028")), ((V)("#5a4a3e")))).Put("kind", ((V)("dot"))).V).Put("lettuce", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(16D))).Put("vy", ((V)((-12D)))).Put("g", ((V)(60D))).Put("life", ((V)(1100D))).Put("r", Arr(((V)(1D)), ((V)(1.6)))).Put("col", Arr(((V)("#86d24e")), ((V)("#a8e870")))).Put("kind", ((V)("leaf"))).V).V);
return default;
}, 1, "", true);
Call(Named(boot_51 => Fn((V _self21, int _argc22, V _a24, V _a25, V _a26, V _a27, V[] _rest23) => {
V R_28 = default;
V TL_29 = default;
V hand_30 = default;
V both_31 = default;
V o_32 = default;
V NOHANDS_33 = default;
V jump_34 = default;
V shake_35 = default;
V swing_36 = default;
V steps_37 = default;
V jelly_38 = default;
V land_39 = default;
V install_40 = default;
V natF_41 = default;
V loopN_42 = default;
V eyes_43 = default;
V hopC_44 = default;
V yay_45 = default;
V calm_46 = default;
V spinR_47 = default;
V CARDS_48 = default;
V MOVES_49 = default;
V DANCES_50 = default;
if (_self21.IsNullish) _self21 = GlobalV;
R_28 = Get(G("window"), "RiveRig");
if (((((!(Truthy(R_28)) || !(Truthy(Get(R_28, "PETLIB")))) || !(Truthy(Get(Get(R_28, "PETLIB"), "install")))) || !(Truthy(Get(R_28, "SOFT")))) || !(Truthy(Get(R_28, "SNACKLIB"))))) {
Call(G("setTimeout"), V.Undef, boot_51.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_28, "snack2V"))) {
return default;
}
Set(R_28, "snack2V", ((V)(1D)));
Invoke(Object_keys(CH_8), "forEach", Fn((V _arrowThis59, int _argc52, V k_58, V _a55, V _a56, V _a57, V[] _rest53) => {
if (GetK(Get(R_28, "REST"), k_58).IsNullish) {
SetK(Get(R_28, "REST"), k_58, ((V)(0D)));
}
return default;
}, 1, "", true));
Call(preset_10, V.Undef, R_28);
{ V _t60 = Get(R_28, "PETLIB");
if (_t60.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t60));
{ V _t61 = Get(_t60, "TL");
TL_29 = _t61; }
{ V _t62 = Get(_t60, "hand");
hand_30 = _t62; }
{ V _t63 = Get(_t60, "both");
both_31 = _t63; }
{ V _t64 = Get(_t60, "o");
o_32 = _t64; }
{ V _t65 = Get(_t60, "NOHANDS");
NOHANDS_33 = _t65; }
{ V _t66 = Get(_t60, "jump");
jump_34 = _t66; }
{ V _t67 = Get(_t60, "shake");
shake_35 = _t67; }
{ V _t68 = Get(_t60, "swing");
swing_36 = _t68; }
{ V _t69 = Get(_t60, "steps");
steps_37 = _t69; }
{ V _t70 = Get(_t60, "jelly");
jelly_38 = _t70; }
{ V _t71 = Get(_t60, "land");
land_39 = _t71; }
{ V _t72 = Get(_t60, "install");
install_40 = _t72; } }
natF_41 = Get(Get(R_28, "SNACKLIB"), "natF");
Invoke(KEYS_9, "forEach", Fn((V _arrowThis80, int _argc73, V k_79, V _a76, V _a77, V _a78, V[] _rest74) => {
return Invoke(Get(R_28, "SOFT"), "add", k_79);
}, 1, "", true));
if (Truthy(Get(Get(R_28, "SNACKLIB"), "KEYS"))) {
Invoke(KEYS_9, "forEach", Fn((V _arrowThis88, int _argc81, V k_87, V _a84, V _a85, V _a86, V[] _rest82) => {
if (!(Truthy(Invoke(Get(Get(R_28, "SNACKLIB"), "KEYS"), "includes", k_87)))) {
Invoke(Get(Get(R_28, "SNACKLIB"), "KEYS"), "push", k_87);
}
return default;
}, 1, "", true));
}
loopN_42 = Fn((V _arrowThis97, int _argc89, V t_95, V n_96, V _a93, V _a94, V[] _rest90) => {
return Object_assign(Invoke(t_95, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_95, "t")) * ToNum((n_96 is var _t98 && Truthy(_t98) ? _t98 : ((V)(3D)))))))).V);
}, 2, "", true);
eyes_43 = Fn((V _arrowThis107, int _argc99, V t_105, V d_106, V _a103, V _a104, V[] _rest100) => {
return Invoke(Invoke(t_105, "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((ToNum(d_106) * 0.9)))).V, ((V)("o"))), "e", ((V)("blink")));
}, 2, "", true);
hopC_44 = Fn((V _arrowThis117, int _argc108, V t_114, V h_115, V x_116, V _a113, V[] _rest109) => {
return Call(jump_34, V.Undef, t_114, Call(o_32, V.Undef, NewObj(5).Put("h", (h_115 is var _t118 && Truthy(_t118) ? _t118 : ((V)(7D)))).Put("ant", ((V)(150D))).Put("up", ((V)(210D))).Put("c", ((V)(0.16))).Put("arm", ((V)(46D))).V, (x_116 is var _t119 && Truthy(_t119) ? _t119 : NewObj(0).V)));
}, 3, "", true);
yay_45 = Fn((V _arrowThis128, int _argc120, V t_126, V d_127, V _a124, V _a125, V[] _rest121) => {
return Invoke(t_126, "to", (d_127 is var _t129 && Truthy(_t129) ? _t129 : ((V)(260D))), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("io")));
}, 2, "", true);
calm_46 = Fn((V _arrowThis137, int _argc130, V t_136, V _a133, V _a134, V _a135, V[] _rest131) => {
return Invoke(t_136, "to", ((V)(300D)), NewObj(9).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("wide", ((V)(0D))).Put("mw", ((V)(1D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hyaw", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
spinR_47 = Fn((V _arrowThis148, int _argc138, V t_144, V dur_145, V deg_146, V x_147, V[] _rest139) => {
V a_149 = default;
a_149 = Get(t_144, "t");
Invoke(Invoke(t_144, "to", dur_145, Call(o_32, V.Undef, NewObj(1).Put("spin", deg_146).V, (x_147 is var _t150 && Truthy(_t150) ? _t150 : NewObj(0).V)), ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
return a_149;
return default;
}, 4, "", true);
CARDS_48 = NewObj(11).Put("frankie", NewObj(3).Put("T", ((V)(0.95))).Put("b", ((V)(1.1))).Put("s", ((V)(1.05))).V).Put("corny", NewObj(3).Put("T", ((V)(0.9))).Put("b", ((V)(1.15))).Put("s", ((V)(1D))).V).Put("peppi", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1D))).Put("s", ((V)(1.15))).V).Put("nori", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1.05))).Put("s", ((V)(0.95))).V).Put("sunny", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1.3))).Put("s", ((V)(1.05))).V).Put("toco", NewObj(3).Put("T", ((V)(0.9))).Put("b", ((V)(1.15))).Put("s", ((V)(1D))).V).Put("churro", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(0.95))).Put("s", ((V)(1.1))).V).Put("khinki", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(1.15))).Put("s", ((V)(1D))).V).Put("maki", NewObj(3).Put("T", ((V)(0.95))).Put("b", ((V)(1D))).Put("s", ((V)(1D))).V).Put("noodle", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(1.05))).Put("s", ((V)(1.05))).V).Put("flossie", NewObj(3).Put("T", ((V)(1.1))).Put("b", ((V)(1.25))).Put("s", ((V)(1.2))).V).V;
MOVES_49 = NewObj(11).Put("frankie", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis157, int _argc151, V _a153, V _a154, V _a155, V _a156, V[] _rest152) => {
V t_158 = default;
t_158 = Call(TL_29, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(t_158, "to", ((V)(260D)), NewObj(4).Put("hug", ((V)((-0.7)))).Put("sq", ((V)(0.06))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("hug", ((V)(0.4))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(3D))), "to", ((V)(200D)), NewObj(1).Put("hug", ((V)(0D))).V, ((V)("io")));
Call(hopC_44, V.Undef, t_158, ((V)(7D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("slip", ((V)(0.35))).V).Put("fall", NewObj(1).Put("slip", ((V)(0D))).V).V);
Call(land_39, V.Undef, t_158, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
Call(hopC_44, V.Undef, t_158, ((V)(8D)), NewObj(2).Put("air", NewObj(1).Put("slip", ((V)((-0.35)))).V).Put("fall", NewObj(1).Put("slip", ((V)(0D))).V).V);
return Call(loopN_42, V.Undef, Invoke(t_158, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Gives his sausage a big bun hug (a squirt of mustard), then hops so it slides back and forth.")))).Put("surprised", Arr(Call(Fn((V _arrowThis165, int _argc159, V _a161, V _a162, V _a163, V _a164, V[] _rest160) => {
V t_166 = default;
t_166 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_166, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(6).Put("slip", ((V)(1.1))).Put("x", ((V)((-2D)))).Put("tilt", ((V)((-4D)))).Put("sq", ((V)((-0.06)))).Put("armL", ((V)(40D))).Put("armR", ((V)(60D))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0.9))).Put("hyaw", ((V)(0.22))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_166, "to", ((V)(320D)), Call(o_32, V.Undef, Call(hand_30, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-6D)))), NewObj(3).Put("armR", ((V)(60D))).Put("slip", ((V)(0.25))).Put("sq", ((V)(0D))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(3).Put("slip", ((V)(0D))).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(2D))), "to", ((V)(320D)), Call(o_32, V.Undef, NOHANDS_33, NewObj(9).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(250D)));
return Invoke(Invoke(t_166, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His sausage shoots out of the bun - he stares at it, pushes it back in with a paw, phew.")))).Put("squish", Arr(Call(Fn((V _arrowThis173, int _argc167, V _a169, V _a170, V _a171, V _a172, V[] _rest168) => {
V t_174 = default;
t_174 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(t_174, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.42))).Put("hug", ((V)((-1D)))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(Invoke(t_174, "to", ((V)(140D)), NewObj(6).Put("sq", ((V)((-0.16)))).Put("hug", ((V)(0.6))).Put("slip", ((V)(0.4))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(3D)));
Call(jelly_38, V.Undef, t_174, ((V)(0.5)), ((V)(3D)), ((V)(260D)), ((V)("slip")));
Call(jelly_38, V.Undef, t_174, ((V)(0.06)), ((V)(2D)), ((V)(240D)));
Invoke(t_174, "to", ((V)(260D)), NewObj(5).Put("hug", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_42, V.Undef, t_174);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("The bun squeezes the sausage, then it springs back and the sausage wobbles.")))).Put("quirk", Arr(Call(Fn((V _arrowThis181, int _argc175, V _a177, V _a178, V _a179, V _a180, V[] _rest176) => {
V t_182 = default;
t_182 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(t_182, "to", ((V)(300D)), NewObj(3).Put("hug", ((V)(1D))).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.7))).V, ((V)("io"))), "wait", ((V)(450D))), "e", ((V)("blink")));
Invoke(Invoke(Invoke(t_182, "to", ((V)(260D)), NewObj(6).Put("hug", ((V)((-0.7)))).Put("sq", ((V)(0.06))).Put("close", ((V)(0.7))).Put("smile", ((V)(1D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(2).Put("x", ((V)(0.6))).Put("slip", ((V)(0.12))).V, NewObj(2).Put("x", ((V)((-0.6)))).Put("slip", ((V)((-0.12)))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(10).Put("hug", ((V)(0D))).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("x", ((V)(0D))).Put("slip", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_182, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Snug check")), ((V)("Opens his bun to check on his sausage, then hugs it snug and rocks it.")))).Put("press", NewObj(1).Put("hug", ((V)((-0.6)))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.08)), ((V)("io"))), Arr(((V)(400D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(560D)), ((V)(0D)), ((V)("io"))))).Put("slip", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(130D)), ((V)(0.5)), ((V)("o"))), Arr(((V)(420D)), ((V)((-0.2))), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("mustard")), ((V)("head")), ((V)(3D))))).V).V).Put("corny", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis189, int _argc183, V _a185, V _a186, V _a187, V _a188, V[] _rest184) => {
V t_190 = default;
t_190 = Call(TL_29, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(t_190, "to", ((V)(200D)), NewObj(1).Put("cfz", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(150D)), NewObj(3).Put("pop", ((V)(1.1))).Put("sq", ((V)((-0.08)))).Put("cfz", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(3D))), "to", ((V)(420D)), NewObj(3).Put("pop", ((V)(0D))).Put("sq", ((V)(0D))).Put("cfz", ((V)(0D))).V, ((V)("i")));
Call(hopC_44, V.Undef, t_190, ((V)(7D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("pop", ((V)(0.6))).V).Put("fall", NewObj(1).Put("pop", ((V)(0D))).V).V);
Call(land_39, V.Undef, t_190, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
Call(hopC_44, V.Undef, t_190, ((V)(8D)), NewObj(3).Put("air", NewObj(1).Put("pop", ((V)(0.9))).V).Put("fall", NewObj(1).Put("pop", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(2D))))).V);
return Call(loopN_42, V.Undef, Invoke(t_190, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Fizzes with excitement, her popcorn pops up, then bouncy hops that toss the kernels.")))).Put("surprised", Arr(Call(Fn((V _arrowThis197, int _argc191, V _a193, V _a194, V _a195, V _a196, V[] _rest192) => {
V t_198 = default;
t_198 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_198, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(8).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.6))).Put("pop", ((V)(1.5))).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(3D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(6D))), "to", ((V)(520D)), NewObj(3).Put("pop", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_198, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.14)))).Put("ly", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(9).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_198, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Every kernel pops at once - then she peeks into her bucket to check they all came back.")))).Put("squish", Arr(Call(Fn((V _arrowThis205, int _argc199, V _a201, V _a202, V _a203, V _a204, V[] _rest200) => {
V t_206 = default;
t_206 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(t_206, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0.4))).Put("pop", ((V)(0.4))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(Invoke(Invoke(t_206, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.16)))).Put("pop", ((V)(1.2))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(3D))), "to", ((V)(420D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
Call(jelly_38, V.Undef, t_206, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_206, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_42, V.Undef, t_206);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed down, then she springs back and her popcorn pops up and rains back in.")))).Put("quirk", Arr(Call(Fn((V _arrowThis213, int _argc207, V _a209, V _a210, V _a211, V _a212, V[] _rest208) => {
V t_214 = default;
t_214 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_214, "to", ((V)(320D)), NewObj(3).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.8)))).Put("pitch", ((V)(0.06))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(160D)), NewObj(2).Put("armR", ((V)(140D))).Put("pop", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_214, "to", ((V)(300D)), Call(o_32, V.Undef, Call(hand_30, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-15D)))), NewObj(4).Put("armR", ((V)(22D))).Put("ly", ((V)(0.2))).Put("pitch", ((V)(0D))).Put("open", ((V)(0.4))).V), ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("open", ((V)(0D))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("puff", ((V)(0.35))).V, NewObj(1).Put("puff", ((V)(0D))).V, ((V)("l"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(2D))), "to", ((V)(300D)), Call(o_32, V.Undef, NOHANDS_33, NewObj(5).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("cfz", ((V)(0.6))).V), ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(1).Put("cfz", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_214, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Snack break")), ((V)("Reaches up, takes one of her own kernels and munches it, fizzing with joy.")))).Put("press", NewObj(2).Put("pop", ((V)(0.4))).Put("cfz", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(240D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(520D)), ((V)(0D)), ((V)("io"))))).Put("pop", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(1.1)), ((V)("o"))), Arr(((V)(560D)), ((V)(0D)), ((V)("i"))))).Put("cfz", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("popk")), ((V)("head")), ((V)(4D))))).V).V).Put("peppi", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis221, int _argc215, V _a217, V _a218, V _a219, V _a220, V[] _rest216) => {
V t_222 = default;
t_222 = Call(TL_29, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(t_222, "to", ((V)(420D)), NewObj(5).Put("pull", ((V)(1D))).Put("lift", ((V)(2.5))).Put("sq", ((V)((-0.06)))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(220D)), NewObj(5).Put("pull", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("cheese")), ((V)("head")), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(swing_36, V.Undef, t_222, ((V)(1300D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(6D))).Put("flop", ((V)(0.6))).Put("x", ((V)(1.2))).V, ((V)("io")));
return Call(loopN_42, V.Undef, Invoke(t_222, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A big cheesy stretch (the strings pull from his crust), then a lazy sway that flops his tip.")))).Put("surprised", Arr(Call(Fn((V _arrowThis229, int _argc223, V _a225, V _a226, V _a227, V _a228, V[] _rest224) => {
V t_230 = default;
t_230 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_230, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(3).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(5).Put("flop", ((V)((-1D)))).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(3D))).Put("armL", ((V)(55D))).Put("armR", ((V)(55D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(3).Put("flop", ((V)(0.8))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).Put("flop", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("flop", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_230, "to", ((V)(300D)), NewObj(2).Put("ly", ((V)(0.8))).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(9).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_230, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Jumps - his tip flaps back and forth like a floppy slice - then checks it.")))).Put("squish", Arr(Call(Fn((V _arrowThis237, int _argc231, V _a233, V _a234, V _a235, V _a236, V[] _rest232) => {
V t_238 = default;
t_238 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_238, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(6).Put("sq", ((V)(0.4))).Put("flop", ((V)(0.9))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("pull", ((V)(0.5))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("cheese")), ((V)("body")), ((V)(3D))), "wait", ((V)(250D)));
Invoke(t_238, "to", ((V)(120D)), NewObj(6).Put("sq", ((V)((-0.15)))).Put("flop", ((V)((-0.5)))).Put("pull", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_38, V.Undef, t_238, ((V)(0.7)), ((V)(3D)), ((V)(280D)), ((V)("flop")));
Invoke(t_238, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_42, V.Undef, t_238);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, his tip flops and the cheese stretches; it all wobbles back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis245, int _argc239, V _a241, V _a242, V _a243, V _a244, V[] _rest240) => {
V t_246 = default;
t_246 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_246, "to", ((V)(900D)), NewObj(3).Put("flop", ((V)(1D))).Put("sq", ((V)(0.03))).Put("close", ((V)(0.4))).V, ((V)("i"))), "wait", ((V)(300D))), "e", ((V)("blink"))), "to", ((V)(200D)), NewObj(2).Put("wide", ((V)(0.6))).Put("close", ((V)(0D))).V, ((V)("o")));
Invoke(Invoke(Invoke(Invoke(t_246, "to", ((V)(200D)), NewObj(2).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.06))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(3).Put("armL", ((V)(145D))).Put("armR", ((V)(145D))).Put("flop", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).Put("flop", ((V)((-0.15)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(9).Put("flop", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wide", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_246, "wait", ((V)(250D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Floppy tip")), ((V)("His tip slowly droops over his head - he looks up and props it back up with both paws.")))).Put("press", NewObj(2).Put("flop", ((V)(0.5))).Put("pull", ((V)(0.3))).V).Put("rel", NewObj(2).Put("dur", ((V)(1100D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(260D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(420D)), ((V)(0D)), ((V)("io"))))).Put("flop", Arr(Arr(((V)(0D)), ((V)(0.5))), Arr(((V)(160D)), ((V)((-0.6))), ((V)("o"))), Arr(((V)(380D)), ((V)(0.35)), ((V)("io"))), Arr(((V)(600D)), ((V)((-0.12))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("pull", Arr(Arr(((V)(0D)), ((V)(0.3))), Arr(((V)(300D)), ((V)(0D)), ((V)("io"))))).V).V).V).Put("nori", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis253, int _argc247, V _a249, V _a250, V _a251, V _a252, V[] _rest248) => {
V t_254 = default;
t_254 = Call(TL_29, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Invoke(Invoke(Invoke(Invoke(t_254, "to", ((V)(320D)), NewObj(3).Put("pitch", ((V)((-0.2)))).Put("sq", ((V)(0.04))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)(0.04))).Put("sq", ((V)((-0.04)))).Put("close", ((V)(0D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_254, "to", ((V)(150D)), NewObj(2).Put("ume", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(1).Put("ume", ((V)(0D))).V, ((V)("i")));
Call(hopC_44, V.Undef, t_254, ((V)(6D)));
return Call(loopN_42, V.Undef, Invoke(t_254, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A polite little bow, the salmon flakes on his head hop up, then a neat little hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis261, int _argc255, V _a257, V _a258, V _a259, V _a260, V[] _rest256) => {
V t_262 = default;
t_262 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_262, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(3).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("nwr", ((V)(1D))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_262, "to", ((V)(250D)), NewObj(3).Put("ly", ((V)(0.9))).Put("pitch", ((V)((-0.12)))).Put("blush", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(320D)), Call(o_32, V.Undef, Call(both_31, V.Undef, ((V)(4D)), ((V)(4D))), NewObj(2).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V), ((V)("io"))), "to", ((V)(300D)), Call(o_32, V.Undef, Call(both_31, V.Undef, ((V)(4D)), ((V)((-2D)))), NewObj(3).Put("nwr", ((V)(0D))).Put("armL", ((V)(35D))).Put("armR", ((V)(35D))).V), ((V)("io"))), "to", ((V)(300D)), Call(o_32, V.Undef, NOHANDS_33, NewObj(9).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("blush", ((V)(0.3))).Put("smile", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_262, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His seaweed jacket slips down - he blushes and tugs it back up neatly.")))).Put("squish", Arr(Call(Fn((V _arrowThis269, int _argc263, V _a265, V _a266, V _a267, V _a268, V[] _rest264) => {
V t_270 = default;
t_270 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_270, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.4))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(4D))), "wait", ((V)(250D)));
Invoke(Invoke(t_270, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("ume", ((V)(0.7))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("ume", ((V)(0D))).V, ((V)("i")));
Call(jelly_38, V.Undef, t_270, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_270, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_42, V.Undef, t_270);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, a few rice grains fly, he springs back and his salmon flakes bob.")))).Put("quirk", Arr(Call(Fn((V _arrowThis277, int _argc271, V _a273, V _a274, V _a275, V _a276, V[] _rest272) => {
V t_278 = default;
t_278 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_278, "to", ((V)(300D)), Call(o_32, V.Undef, Call(both_31, V.Undef, ((V)(3D)), ((V)(6D))), NewObj(4).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("ly", ((V)(0.7))).Put("pitch", ((V)((-0.08)))).V), ((V)("io"))), "osc", ((V)(800D)), ((V)(2D)), NewObj(1).Put("nwr", ((V)(0.6))).V, NewObj(1).Put("nwr", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("nwr", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_32, V.Undef, NOHANDS_33, NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_278, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Jacket tug")), ((V)("Straightens his seaweed jacket with both paws, smooths it and gives a neat nod.")))).Put("press", NewObj(1).Put("nwr", ((V)(0.3))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(400D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("ume", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(400D)), ((V)(0D)), ((V)("i"))))).Put("nwr", Arr(Arr(((V)(0D)), ((V)(0.3))), Arr(((V)(300D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("rice")), ((V)("body")), ((V)(3D))))).V).V).Put("sunny", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis285, int _argc279, V _a281, V _a282, V _a283, V _a284, V[] _rest280) => {
V t_286 = default;
t_286 = Call(TL_29, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(t_286, "to", ((V)(320D)), NewObj(2).Put("cap", ((V)(0.8))).Put("armR", ((V)(120D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("wob", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(260D)), NewObj(2).Put("cap", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("wob", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_286, "osc", ((V)(900D)), ((V)(2D)), NewObj(2).Put("rl", ((V)((-14D)))).Put("x", ((V)((-4D)))).V, NewObj(2).Put("rl", ((V)(14D))).Put("x", ((V)(4D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Call(jump_34, V.Undef, t_286, NewObj(8).Put("h", ((V)(10D))).Put("ant", ((V)(160D))).Put("up", ((V)(250D))).Put("c", ((V)(0.16))).Put("arm", ((V)(50D))).Put("air", NewObj(1).Put("rl", ((V)(180D))).V).Put("fall", NewObj(1).Put("rl", ((V)(360D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))))).V);
Invoke(t_286, "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l")));
Call(land_39, V.Undef, t_286, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
return Call(loopN_42, V.Undef, Invoke(t_286, "rest", ((V)(300D))), ((V)(2D)));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Tips her shell cap like a hat (her runny yolk wobbles), rocks on her round bottom, then a happy little somersault.")))).Put("surprised", Arr(Call(Fn((V _arrowThis293, int _argc287, V _a289, V _a290, V _a291, V _a292, V[] _rest288) => {
V t_294 = default;
t_294 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_294, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("cap", ((V)(1.1))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("wob", ((V)(1.3))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(320D)), NewObj(2).Put("cap", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0D))).Put("wob", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_294, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_294, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Her shell cap pops right off in surprise, the yolk jiggles, and it drops back on.")))).Put("squish", Arr(Call(Fn((V _arrowThis301, int _argc295, V _a297, V _a298, V _a299, V _a300, V[] _rest296) => {
V t_302 = default;
t_302 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(t_302, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.36))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(Invoke(t_302, "to", ((V)(140D)), NewObj(6).Put("sq", ((V)((-0.12)))).Put("cap", ((V)(0.7))).Put("wob", ((V)(1.5))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("cap", ((V)(0D))).V, ((V)("i")));
Call(jelly_38, V.Undef, t_302, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_302, "to", ((V)(400D)), NewObj(5).Put("wob", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_42, V.Undef, t_302);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed down flat - her cap pops up and the yolk wobbles - then she springs back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis309, int _argc303, V _a305, V _a306, V _a307, V _a308, V[] _rest304) => {
V t_310 = default;
t_310 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_310, "to", ((V)(400D)), NewObj(5).Put("cap", ((V)(0.75))).Put("armR", ((V)(140D))).Put("htilt", ((V)((-4D)))).Put("close", ((V)(0.4))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(250D)), NewObj(1).Put("wob", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("pitch", ((V)((-0.12)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(6).Put("cap", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("close", ((V)(0D))).Put("wob", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_310, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Hat tip")), ((V)("Lifts her shell cap like a hat and gives a little bow, her runny yolk peeking out.")))).Put("press", NewObj(1).Put("cap", ((V)(0.3))).V).Put("rel", NewObj(2).Put("dur", ((V)(1100D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(260D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(420D)), ((V)(0D)), ((V)("io"))))).Put("cap", Arr(Arr(((V)(0D)), ((V)(0.3))), Arr(((V)(120D)), ((V)(0.9)), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("i"))))).Put("wob", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1.2)), ((V)("o"))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).V).V).Put("toco", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis317, int _argc311, V _a313, V _a314, V _a315, V _a316, V[] _rest312) => {
V t_318 = default;
t_318 = Call(TL_29, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
{
double i_319 = 0;
i_319 = 0D;
while (true) {
if (!((i_319 < 2D))) break;
Invoke(Invoke(Invoke(t_318, "to", ((V)(120D)), NewObj(2).Put("snap", ((V)((-0.7)))).Put("sq", ((V)(0.04))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("snap", ((V)(0.6))).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(1D)));
i_319++;
}
}
Invoke(t_318, "to", ((V)(200D)), NewObj(2).Put("snap", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(hopC_44, V.Undef, t_318, ((V)(7D)), NewObj(2).Put("air", NewObj(1).Put("snap", ((V)(0.5))).V).Put("fall", NewObj(1).Put("snap", ((V)(0D))).V).V);
return Call(loopN_42, V.Undef, Invoke(t_318, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Snaps his shell open and shut like happy chomps, lettuce flies, then a hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis327, int _argc321, V _a323, V _a324, V _a325, V _a326, V[] _rest322) => {
V t_328 = default;
t_328 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_328, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(4).Put("snap", ((V)((-0.8)))).Put("wide", ((V)(1D))).Put("open", ((V)(0.4))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(260D)), NewObj(2).Put("snap", ((V)(0.8))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("snap", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_328, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(5).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_328, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Snaps shut with a crunch, then pops back open and lettuce flies.")))).Put("squish", Arr(Call(Fn((V _arrowThis335, int _argc329, V _a331, V _a332, V _a333, V _a334, V[] _rest330) => {
V t_336 = default;
t_336 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_336, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.4))).Put("snap", ((V)(1.2))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(3D))), "wait", ((V)(250D)));
Invoke(Invoke(t_336, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("snap", ((V)((-0.5)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
Call(jelly_38, V.Undef, t_336, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_336, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_42, V.Undef, t_336);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Pressed down, his shell bursts open (lettuce flies), then snaps back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis343, int _argc337, V _a339, V _a340, V _a341, V _a342, V[] _rest338) => {
V t_344 = default;
t_344 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_344, "to", ((V)(260D)), NewObj(1).Put("snap", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(3).Put("armR", ((V)(140D))).Put("ly", ((V)((-0.7)))).Put("pitch", ((V)(0.05))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).Put("armR", ((V)(126D))).V, NewObj(1).Put("armR", ((V)(140D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_344, "to", ((V)(160D)), NewObj(1).Put("snap", ((V)((-0.3)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(5).Put("snap", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_344, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Filling fix")), ((V)("Opens up, tucks a stray lettuce leaf back in, snaps shut - perfect.")))).Put("press", NewObj(1).Put("snap", ((V)((-0.5)))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(240D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).Put("snap", Arr(Arr(((V)(0D)), ((V)((-0.5)))), Arr(((V)(120D)), ((V)(0.9)), ((V)("o"))), Arr(((V)(360D)), ((V)((-0.25))), ((V)("io"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("lettuce")), ((V)("head")), ((V)(2D))))).V).V).Put("churro", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis351, int _argc345, V _a347, V _a348, V _a349, V _a350, V[] _rest346) => {
V t_352 = default;
t_352 = Call(TL_29, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(t_352, "to", ((V)(400D)), NewObj(3).Put("cork", ((V)(1D))).Put("lift", ((V)(1D))).Put("sq", ((V)((-0.06)))).V, ((V)("io"))), "to", ((V)(420D)), NewObj(1).Put("cork", ((V)((-1D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("cork", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sugar")), ((V)("head")), ((V)(3D)));
Call(hopC_44, V.Undef, t_352, ((V)(7D)));
return Call(loopN_42, V.Undef, Invoke(t_352, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Twists like a corkscrew one way then the other, sugar sparkles, then a hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis359, int _argc353, V _a355, V _a356, V _a357, V _a358, V[] _rest354) => {
V t_360 = default;
t_360 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_360, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(3).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)((-0.16)))).Put("lift", ((V)(3D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("sugar")), ((V)("body")), ((V)(5D))), "to", ((V)(250D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_360, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(8).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_360, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Stands up straight in surprise and sugar puffs off him.")))).Put("squish", Arr(Call(Fn((V _arrowThis367, int _argc361, V _a363, V _a364, V _a365, V _a366, V[] _rest362) => {
V t_368 = default;
t_368 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_368, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.36))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sugar")), ((V)("body")), ((V)(4D))), "wait", ((V)(250D)));
Invoke(t_368, "to", ((V)(120D)), NewObj(4).Put("sq", ((V)((-0.14)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_38, V.Undef, t_368, ((V)(0.6)), ((V)(3D)), ((V)(280D)), ((V)("cork")));
Invoke(t_368, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_42, V.Undef, t_368);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("A crunchy squash, a puff of sugar, his ridges twist as he springs back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis375, int _argc369, V _a371, V _a372, V _a373, V _a374, V[] _rest370) => {
V t_376 = default;
t_376 = Call(TL_29, V.Undef);
Call(shake_35, V.Undef, t_376, NewObj(6).Put("P", ((V)(90D))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(1D)), ((V)(0.7)), ((V)(0.35)))).Put("head", ((V)(0.08))).Put("roll", ((V)(3D))).Put("ear", ((V)(0D))).Put("body", ((V)(0.6))).V);
Invoke(t_376, "e", ((V)("emit")), ((V)("sugar")), ((V)("body")), ((V)(5D)));
Invoke(Invoke(t_376, "to", ((V)(300D)), NewObj(3).Put("cork", ((V)(0.4))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("cork", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_376, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sugar shake")), ((V)("Shakes off the extra sugar like a dog after a bath, then a smug little twist.")))).Put("press", NewObj(1).Put("cork", ((V)(0.4))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(240D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).Put("cork", Arr(Arr(((V)(0D)), ((V)(0.4))), Arr(((V)(150D)), ((V)((-0.8))), ((V)("o"))), Arr(((V)(400D)), ((V)(0.4)), ((V)("io"))), Arr(((V)(650D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("sugar")), ((V)("head")), ((V)(3D))))).V).V).Put("khinki", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis383, int _argc377, V _a379, V _a380, V _a381, V _a382, V[] _rest378) => {
V t_384 = default;
t_384 = Call(TL_29, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_384, "to", ((V)(220D)), NewObj(2).Put("knot", ((V)(0.8))).Put("kt", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("knot", ((V)((-0.7)))).Put("kt", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("knot", ((V)(0D))).Put("kt", ((V)(0D))).V, ((V)("io")));
Call(hopC_44, V.Undef, t_384, ((V)(7D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("knot", ((V)(0.4))).V).Put("fall", NewObj(1).Put("knot", ((V)(0D))).V).V);
Call(land_39, V.Undef, t_384, ((V)(0.08)), ((V)(2D)), ((V)(240D)));
Call(hopC_44, V.Undef, t_384, ((V)(7D)), NewObj(2).Put("air", NewObj(1).Put("knot", ((V)((-0.4)))).V).Put("fall", NewObj(1).Put("knot", ((V)(0D))).V).V);
return Call(loopN_42, V.Undef, Invoke(t_384, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Flicks his knot like a ponytail, then juicy little hops that make it bounce.")))).Put("surprised", Arr(Call(Fn((V _arrowThis391, int _argc385, V _a387, V _a388, V _a389, V _a390, V[] _rest386) => {
V t_392 = default;
t_392 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_392, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(3D))).Put("kt", ((V)(0.8))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(4D))), "to", ((V)(240D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("kt", ((V)((-0.3)))).V, ((V)("i"))), "to", ((V)(260D)), NewObj(2).Put("sq", ((V)(0D))).Put("kt", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_392, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_392, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Jumps - his pleats twist tight and a squirt of broth shoots out of his knot.")))).Put("squish", Arr(Call(Fn((V _arrowThis399, int _argc393, V _a395, V _a396, V _a397, V _a398, V[] _rest394) => {
V t_400 = default;
t_400 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_400, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.42))).Put("kt", ((V)(0.6))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(5D))), "wait", ((V)(250D)));
Invoke(t_400, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("kt", ((V)((-0.3)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_38, V.Undef, t_400, ((V)(0.09)), ((V)(3D)), ((V)(260D)));
Invoke(t_400, "to", ((V)(220D)), NewObj(5).Put("kt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_42, V.Undef, t_400);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, a juicy squirt of broth shoots out of his knot; a doughy wobble back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis407, int _argc401, V _a403, V _a404, V _a405, V _a406, V[] _rest402) => {
V t_408 = default;
t_408 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_408, "to", ((V)(320D)), NewObj(3).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.8)))).Put("pitch", ((V)(0.06))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(2).Put("kt", ((V)(1D))).Put("knot", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(2).Put("kt", ((V)((-0.3)))).Put("knot", ((V)((-0.2)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("kt", ((V)(0D))).Put("knot", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("pepper")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(4).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_408, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Knot twirl")), ((V)("Reaches up and twirls his top knot neat (the pleats twist with it), a sprinkle of pepper falls.")))).Put("press", NewObj(1).Put("kt", ((V)(0.4))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.08)), ((V)("io"))), Arr(((V)(420D)), ((V)(0D)), ((V)("io"))))).Put("knot", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(400D)), ((V)((-0.4))), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("kt", Arr(Arr(((V)(0D)), ((V)(0.4))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("broth")), ((V)("head")), ((V)(3D))))).V).V).Put("maki", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis415, int _argc409, V _a411, V _a412, V _a413, V _a414, V[] _rest410) => {
V t_416 = default;
t_416 = Call(TL_29, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_416, "to", ((V)(160D)), NewObj(2).Put("veg", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(360D)), NewObj(2).Put("veg", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(spinR_47, V.Undef, t_416, ((V)(900D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V);
Invoke(t_416, "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(hopC_44, V.Undef, t_416, ((V)(6D)));
return Call(loopN_42, V.Undef, Invoke(t_416, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("His salmon and veggies pop up out of the rice, a quick spin like a top, then a hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis423, int _argc417, V _a419, V _a420, V _a421, V _a422, V[] _rest418) => {
V t_424 = default;
t_424 = Call(TL_29, V.Undef);
Invoke(Invoke(t_424, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("veg", ((V)(1.3))).V, ((V)("o")));
Call(hopC_44, V.Undef, t_424, ((V)(8D)), NewObj(1).Put("ant", ((V)(60D))).V);
Invoke(t_424, "to", ((V)(400D)), NewObj(1).Put("veg", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_424, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_424, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His salmon and veggies shoot up out of the rice and he jumps.")))).Put("squish", Arr(Call(Fn((V _arrowThis431, int _argc425, V _a427, V _a428, V _a429, V _a430, V[] _rest426) => {
V t_432 = default;
t_432 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_432, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.38))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("rice")), ((V)("head")), ((V)(4D))), "wait", ((V)(250D)));
Invoke(Invoke(t_432, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("veg", ((V)(0.9))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("veg", ((V)(0D))).V, ((V)("io")));
Call(jelly_38, V.Undef, t_432, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_432, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_42, V.Undef, t_432);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Pressed like rolling a mat, rice grains fly, his salmon and veggies pop up.")))).Put("quirk", Arr(Call(Fn((V _arrowThis439, int _argc433, V _a435, V _a436, V _a437, V _a438, V[] _rest434) => {
V t_440 = default;
t_440 = Call(TL_29, V.Undef);
Invoke(Invoke(t_440, "to", ((V)(400D)), NewObj(2).Put("close", ((V)(1D))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(200D)));
Call(spinR_47, V.Undef, t_440, ((V)(2600D)), ((V)(360D)), NewObj(1).Put("veg", ((V)(0.3))).V);
Invoke(t_440, "to", ((V)(300D)), NewObj(4).Put("veg", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_440, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Zen spin")), ((V)("Closes his eyes and turns slowly round like a spinning top, perfectly calm.")))).Put("press", NewObj(2).Put("sq", ((V)(0.05))).Put("veg", ((V)(0.3))).V).Put("rel", NewObj(3).Put("dur", ((V)(900D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(240D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).Put("veg", Arr(Arr(((V)(0D)), ((V)(0.3))), Arr(((V)(120D)), ((V)(1D)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("rice")), ((V)("head")), ((V)(3D))))).V).V).Put("noodle", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis447, int _argc441, V _a443, V _a444, V _a445, V _a446, V[] _rest442) => {
V t_448 = default;
t_448 = Call(TL_29, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(t_448, "to", ((V)(300D)), NewObj(4).Put("slurp", ((V)(1D))).Put("puff", ((V)((-0.3)))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(250D)), NewObj(4).Put("slurp", ((V)(0D))).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).Put("mw", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D)));
Call(hopC_44, V.Undef, t_448, ((V)(7D)), NewObj(2).Put("air", NewObj(1).Put("lid", ((V)(0.8))).V).Put("fall", NewObj(1).Put("lid", ((V)(0D))).V).V);
return Call(loopN_42, V.Undef, Invoke(t_448, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Slurps up his noodles, a happy puff of steam, then a hop that lifts a pinch of noodles with his chopsticks.")))).Put("surprised", Arr(Call(Fn((V _arrowThis455, int _argc449, V _a451, V _a452, V _a453, V _a454, V[] _rest450) => {
V t_456 = default;
t_456 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_456, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("lid", ((V)((-1D)))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(3D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(5D))), "to", ((V)(250D)), NewObj(3).Put("lid", ((V)(1D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("lid", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_456, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_456, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His chopsticks jump up out of the noodles and a burst of steam puffs out like a whistle.")))).Put("squish", Arr(Call(Fn((V _arrowThis463, int _argc457, V _a459, V _a460, V _a461, V _a462, V[] _rest458) => {
V t_464 = default;
t_464 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_464, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.38))).Put("lid", ((V)(0.8))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(4D))), "wait", ((V)(250D)));
Invoke(Invoke(t_464, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("lid", ((V)((-0.4)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("lid", ((V)(0D))).V, ((V)("io")));
Call(jelly_38, V.Undef, t_464, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_464, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_42, V.Undef, t_464);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, a splash of broth and his chopsticks bob, then he springs back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis471, int _argc465, V _a467, V _a468, V _a469, V _a470, V[] _rest466) => {
V t_472 = default;
t_472 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_472, "to", ((V)(400D)), NewObj(3).Put("close", ((V)(1D))).Put("smile", ((V)(1D))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D))), "osc", ((V)(1600D)), ((V)(4D)), NewObj(1).Put("lid", ((V)(0.7))).V, NewObj(1).Put("lid", ((V)((-0.2)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(4).Put("lid", ((V)(0D))).Put("close", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_472, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Steam sigh")), ((V)("Closes his eyes in a cosy cloud of steam while his chopsticks twirl up noodles.")))).Put("press", NewObj(1).Put("lid", ((V)(0.5))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).Put("lid", Arr(Arr(((V)(0D)), ((V)(0.5))), Arr(((V)(150D)), ((V)((-0.6))), ((V)("o"))), Arr(((V)(400D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(650D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("steam")), ((V)("head")), ((V)(4D))))).V).V).Put("flossie", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis479, int _argc473, V _a475, V _a476, V _a477, V _a478, V[] _rest474) => {
V t_480 = default;
t_480 = Call(TL_29, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_480, "to", ((V)(300D)), NewObj(3).Put("fluff", ((V)(1.2))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(3D))), "to", ((V)(500D)), NewObj(3).Put("fluff", ((V)(0D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_480, "to", ((V)(1100D)), NewObj(1).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("l")));
Call(hopC_44, V.Undef, t_480, ((V)(6D)));
return Call(loopN_42, V.Undef, Invoke(t_480, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Poofs up big and fluffy, her floss swirls round her, then a soft hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis487, int _argc481, V _a483, V _a484, V _a485, V _a486, V[] _rest482) => {
V t_488 = default;
t_488 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_488, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("fluff", ((V)(1.6))).Put("sq", ((V)((-0.1)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(4D))), "wait", ((V)(300D))), "to", ((V)(900D)), NewObj(2).Put("fluff", ((V)(0D))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_488, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_488, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Poofs out huge in surprise, then slowly fluffs back down.")))).Put("squish", Arr(Call(Fn((V _arrowThis495, int _argc489, V _a491, V _a492, V _a493, V _a494, V[] _rest490) => {
V t_496 = default;
t_496 = Call(TL_29, V.Undef);
Invoke(Invoke(Invoke(t_496, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.42))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(Invoke(Invoke(t_496, "to", ((V)(160D)), NewObj(5).Put("sq", ((V)((-0.16)))).Put("fluff", ((V)(1.3))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(4D))), "to", ((V)(500D)), NewObj(1).Put("fluff", ((V)(0D))).V, ((V)("io")));
Call(jelly_38, V.Undef, t_496, ((V)(0.08)), ((V)(3D)), ((V)(260D)));
Invoke(t_496, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_42, V.Undef, t_496);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squished down, then she poofs back out fluffier than before.")))).Put("quirk", Arr(Call(Fn((V _arrowThis503, int _argc497, V _a499, V _a500, V _a501, V _a502, V[] _rest498) => {
V t_504 = default;
V a_505 = default;
t_504 = Call(TL_29, V.Undef);
Invoke(t_504, "to", ((V)(700D)), NewObj(5).Put("lift", ((V)(6D))).Put("close", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("io")));
a_505 = Get(t_504, "t");
Invoke(t_504, "osc", ((V)(1800D)), ((V)(2D)), NewObj(1).Put("lift", ((V)(7.5))).V, NewObj(1).Put("lift", ((V)(5.5))).V, ((V)("s")));
Invoke(Invoke(Invoke(t_504, "at", a_505), "to", ((V)(1800D)), NewObj(1).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_504, "to", ((V)(800D)), NewObj(4).Put("lift", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_504, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Cloud float")), ((V)("Closes her eyes and floats up like a little cloud, her floss drifting round, then sinks softly down.")))).Put("press", NewObj(1).Put("fluff", ((V)(0.5))).V).Put("rel", NewObj(3).Put("dur", ((V)(1200D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(420D)), ((V)(0D)), ((V)("io"))))).Put("fluff", Arr(Arr(((V)(0D)), ((V)(0.5))), Arr(((V)(160D)), ((V)(1.3)), ((V)("o"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("floss")), ((V)("head")), ((V)(3D))))).V).V).V;
DANCES_50 = NewObj(11).Put("frankie", Arr(Call(Fn((V _arrowThis512, int _argc506, V _a508, V _a509, V _a510, V _a511, V[] _rest507) => {
V t_513 = default;
double B_514 = 0;
V a_515 = default;
t_513 = Call(TL_29, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_514 = 500D;
Call(eyes_43, V.Undef, t_513, ((V)(1D)));
{
double i_516 = 0;
i_516 = 0D;
while (true) {
if (!((i_516 < 2D))) break;
Invoke(Invoke(t_513, "to", ((V)(B_514)), NewObj(5).Put("slip", ((V)(0.9))).Put("x", ((V)((-1.6)))).Put("tilt", ((V)((-3D)))).Put("armL", ((V)(30D))).Put("armR", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(B_514)), NewObj(5).Put("slip", ((V)((-0.9)))).Put("x", ((V)(1.6))).Put("tilt", ((V)(3D))).Put("armL", ((V)((-6D)))).Put("armR", ((V)(30D))).V, ((V)("io")));
i_516++;
}
}
Invoke(t_513, "to", ((V)((B_514 * 0.6))), NewObj(6).Put("slip", ((V)(0D))).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
{
double i_518 = 0;
i_518 = 0D;
while (true) {
if (!((i_518 < 3D))) break;
Invoke(Invoke(Invoke(t_513, "to", ((V)(150D)), NewObj(2).Put("hug", ((V)((-0.9)))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(2D))), "to", ((V)((B_514 - 150D))), NewObj(2).Put("hug", ((V)(0.3))).Put("sq", ((V)((-0.03)))).V, ((V)("io")));
i_518++;
}
}
Invoke(t_513, "to", ((V)(200D)), NewObj(2).Put("hug", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
{
double i_520 = 0;
i_520 = 0D;
while (true) {
if (!((i_520 < 2D))) break;
Call(hopC_44, V.Undef, t_513, ((V)(8D)), NewObj(3).Put("chain", ((i_520 < 1D) ? V.True : V.False)).Put("air", NewObj(1).Put("slip", ((V)((NumTruthy(i_520) ? (-0.5) : 0.5)))).V).Put("fall", NewObj(1).Put("slip", ((V)(0D))).V).V);
i_520++;
}
}
a_515 = Call(spinR_47, V.Undef, t_513, ((V)(1300D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).V);
Invoke(Invoke(Invoke(t_513, "at", a_515), "to", ((V)(500D)), NewObj(1).Put("slip", ((V)((-0.7)))).V, ((V)("o"))), "to", ((V)(800D)), NewObj(1).Put("slip", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_513, "at", Add(a_515, ((V)(1301D)))), "to", ((V)(250D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_513, "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(4D))), "to", ((V)(160D)), NewObj(3).Put("hug", ((V)((-0.8)))).Put("sq", ((V)(0.1))).Put("lift", ((V)(0D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(3D))), "to", ((V)(400D)), NewObj(4).Put("hug", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D)));
return Invoke(Invoke(t_513, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Bun Hug Wiggle")), ((V)("His sausage slides side to side in the bun while he sways the other way, bun-hug beats squirt mustard, two hops it rides, a spin it trails behind, and a big mustard finale.")))).Put("corny", Arr(Call(Fn((V _arrowThis528, int _argc522, V _a524, V _a525, V _a526, V _a527, V[] _rest523) => {
V t_529 = default;
double B_530 = 0;
V a_531 = default;
t_529 = Call(TL_29, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_530 = 460D;
{
double i_532 = 0;
i_532 = 0D;
while (true) {
if (!((i_532 < 4D))) break;
Invoke(Invoke(Invoke(t_529, "to", ((V)((B_530 / 2D))), NewObj(5).Put("pop", ((V)(0.9))).Put("footL", ((V)((NumTruthy((i_532 % 2D)) ? 0D : 2.4)))).Put("footR", ((V)((NumTruthy((i_532 % 2D)) ? 2.4 : 0D)))).Put("x", ((V)((NumTruthy((i_532 % 2D)) ? 1D : (-1D))))).Put("tilt", ((V)((NumTruthy((i_532 % 2D)) ? 3D : (-3D))))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(1D))), "to", ((V)((B_530 / 2D))), NewObj(3).Put("pop", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i")));
i_532++;
}
}
Invoke(Invoke(Invoke(t_529, "to", ((V)(200D)), NewObj(3).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("cfz", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(1300D)), ((V)(6D)), NewObj(3).Put("tilt", ((V)(4D))).Put("armL", ((V)(40D))).Put("armR", ((V)(10D))).V, NewObj(3).Put("tilt", ((V)((-4D)))).Put("armL", ((V)(10D))).Put("armR", ((V)(40D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(4).Put("cfz", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(jump_34, V.Undef, t_529, NewObj(8).Put("h", ((V)(13D))).Put("ant", ((V)(200D))).Put("up", ((V)(280D))).Put("c", ((V)(0.2))).Put("arm", ((V)(120D))).Put("air", NewObj(1).Put("pop", ((V)(1.5))).V).Put("fall", NewObj(1).Put("pop", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(6D))))).V);
a_531 = Call(spinR_47, V.Undef, t_529, ((V)(1200D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V);
Invoke(t_529, "at", a_531);
{
double i_534 = 0;
i_534 = 0D;
while (true) {
if (!((i_534 < 3D))) break;
Invoke(Invoke(t_529, "to", ((V)(200D)), NewObj(1).Put("pop", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
i_534++;
}
}
Invoke(t_529, "at", Add(a_531, ((V)(1201D))));
Invoke(Invoke(Invoke(Invoke(t_529, "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("cfz", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(400D))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("cfz", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_529, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Popcorn Pop")), ((V)("Her kernels pop on every step, a fizzing shimmy, a big jump that pops them all at once, a spin with popcorn bouncing and a fizzy cheer.")))).Put("peppi", Arr(Call(Fn((V _arrowThis542, int _argc536, V _a538, V _a539, V _a540, V _a541, V[] _rest537) => {
V t_543 = default;
double B_544 = 0;
t_543 = Call(TL_29, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_544 = 520D;
Call(swing_36, V.Undef, t_543, ((V)(2400D)), ((V)(4D)), NewObj(5).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).Put("flop", ((V)(0.7))).Put("armL", ((V)(20D))).Put("armR", ((V)((-20D)))).V, ((V)("io")));
{
double i_545 = 0;
i_545 = 0D;
while (true) {
if (!((i_545 < 2D))) break;
Invoke(Invoke(Invoke(Invoke(Invoke(t_543, "to", ((V)(320D)), NewObj(4).Put("pull", ((V)(1D))).Put("lift", ((V)(3D))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("cheese")), ((V)("head")), ((V)(2D))), "wait", ((V)(160D))), "to", ((V)(260D)), NewObj(4).Put("pull", ((V)(0D))).Put("lift", ((V)(0D))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("i"))), "wait", ((V)((B_544 - 260D))));
i_545++;
}
}
Invoke(t_543, "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(jump_34, V.Undef, t_543, NewObj(8).Put("h", ((V)(11D))).Put("ant", ((V)(180D))).Put("up", ((V)(260D))).Put("c", ((V)(0.18))).Put("arm", ((V)(90D))).Put("spin", ((V)(360D))).Put("air", NewObj(1).Put("flop", ((V)((-0.7)))).V).Put("fall", NewObj(1).Put("flop", ((V)(0D))).V).V);
Invoke(Invoke(t_543, "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("flop", ((V)(1D))).Put("tilt", ((V)(3D))).V, NewObj(2).Put("flop", ((V)((-0.6)))).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("flop", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_543, "to", ((V)(400D)), NewObj(5).Put("pitch", ((V)((-0.18)))).Put("flop", ((V)(0.6))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("close", ((V)(0.6))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("cheese")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(5).Put("pitch", ((V)(0D))).Put("flop", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_543, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Cheese Pull Sway")), ((V)("A lazy floppy sway, two big cheese pulls with his crust lifting, a slice spin in the air, a floppy-tip shimmy and a cheesy bow.")))).Put("nori", Arr(Call(Fn((V _arrowThis553, int _argc547, V _a549, V _a550, V _a551, V _a552, V[] _rest548) => {
V t_554 = default;
double B_555 = 0;
t_554 = Call(TL_29, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_555 = 500D;
Invoke(Invoke(Invoke(t_554, "to", ((V)(400D)), NewObj(2).Put("pitch", ((V)((-0.2)))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
{
double i_556 = 0;
i_556 = 0D;
while (true) {
if (!((i_556 < 4D))) break;
double d_558 = 0;
d_558 = (NumTruthy((i_556 % 2D)) ? 1D : (-1D));
Invoke(Invoke(t_554, "to", ((V)((B_555 / 2D))), NewObj(5).Put("x", ((V)((d_558 * 3D)))).Put("footL", ((V)(((d_558 < 0D) ? 2.4 : 0D)))).Put("footR", ((V)(((d_558 > 0D) ? 2.4 : 0D)))).Put("ume", ((V)(0.6))).Put("tilt", ((V)((d_558 * 2D)))).V, ((V)("o"))), "to", ((V)((B_555 / 2D))), NewObj(3).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("ume", ((V)(0D))).V, ((V)("i")));
i_556++;
}
}
Invoke(Invoke(Invoke(Invoke(t_554, "to", ((V)(300D)), NewObj(2).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), Call(o_32, V.Undef, Call(both_31, V.Undef, ((V)(3D)), ((V)(6D))), NewObj(2).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("nwr", ((V)(0.7))).Put("sq", ((V)(0.03))).V, NewObj(2).Put("nwr", ((V)((-0.3)))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(240D)), Call(o_32, V.Undef, NOHANDS_33, NewObj(3).Put("nwr", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
Call(jump_34, V.Undef, t_554, NewObj(9).Put("h", ((V)(11D))).Put("ant", ((V)(180D))).Put("up", ((V)(260D))).Put("c", ((V)(0.18))).Put("arm", ((V)(80D))).Put("spin", ((V)(360D))).Put("air", NewObj(1).Put("ume", ((V)(1D))).V).Put("fall", NewObj(1).Put("ume", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(6D))))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_554, "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("hap", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(2).Put("pitch", ((V)((-0.2)))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_554, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Rice Ball Roll")), ((V)("A polite bow, neat side steps with his salmon flakes bobbing, a seaweed-jacket shimmy, a spinning hop that scatters rice, a cheer and another bow.")))).Put("sunny", Arr(Call(Fn((V _arrowThis565, int _argc559, V _a561, V _a562, V _a563, V _a564, V[] _rest560) => {
V t_566 = default;
double B_567 = 0;
t_566 = Call(TL_29, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_567 = 480D;
{
double i_568 = 0;
i_568 = 0D;
while (true) {
if (!((i_568 < 4D))) break;
double d_570 = 0;
d_570 = (NumTruthy((i_568 % 2D)) ? 1D : (-1D));
Invoke(Invoke(t_566, "to", ((V)((B_567 * 0.55))), NewObj(6).Put("rl", ((V)((d_570 * 22D)))).Put("x", ((V)((d_570 * 6D)))).Put("cap", ((V)(0.5))).PutK(((V)(((d_570 < 0D) ? "armL" : "armR"))), ((V)(120D))).PutK(((V)(((d_570 < 0D) ? "armR" : "armL"))), ((V)(20D))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)((B_567 * 0.45))), NewObj(2).Put("cap", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
i_568++;
}
}
Invoke(t_566, "to", ((V)(260D)), NewObj(4).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_566, "to", ((V)(1000D)), NewObj(4).Put("rl", ((V)(360D))).Put("x", ((V)(22D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "wait", ((V)(150D))), "to", ((V)(1000D)), NewObj(2).Put("rl", ((V)((-360D)))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_566, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.14))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(5).Put("cap", ((V)(1.2))).Put("sq", ((V)((-0.1)))).Put("wob", ((V)(1.4))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.5))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(360D)), NewObj(2).Put("cap", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0D))).Put("wob", ((V)(0.6))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
Call(jump_34, V.Undef, t_566, NewObj(7).Put("h", ((V)(12D))).Put("ant", ((V)(180D))).Put("up", ((V)(280D))).Put("c", ((V)(0.18))).Put("arm", ((V)(80D))).Put("air", NewObj(1).Put("rl", ((V)((-180D)))).V).Put("fall", NewObj(1).Put("rl", ((V)((-360D)))).V).V);
Invoke(t_566, "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(t_566, "osc", ((V)(1000D)), ((V)(4D)), NewObj(2).Put("rl", ((V)(10D))).Put("wob", ((V)(0.8))).V, NewObj(2).Put("rl", ((V)((-10D)))).Put("wob", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("rl", ((V)(0D))).Put("wob", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_566, "to", ((V)(400D)), NewObj(4).Put("cap", ((V)(0.6))).Put("pitch", ((V)((-0.14)))).Put("close", ((V)(0.6))).Put("armR", ((V)(120D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(4).Put("cap", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(200D)));
return Invoke(Invoke(t_566, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Roly-Poly Rock")), ((V)("Rocks side to side on her round bottom tipping her shell cap on every beat, rolls right over and back, the cap pops off and lands back while her yolk wobbles, a somersault, a wobble and a hat-tip bow.")))).Put("toco", Arr(Call(Fn((V _arrowThis577, int _argc571, V _a573, V _a574, V _a575, V _a576, V[] _rest572) => {
V t_578 = default;
double B_579 = 0;
V a_580 = default;
t_578 = Call(TL_29, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_579 = 420D;
{
double i_581 = 0;
i_581 = 0D;
while (true) {
if (!((i_581 < 6D))) break;
double d_583 = 0;
d_583 = (NumTruthy((i_581 % 2D)) ? 1D : (-1D));
Invoke(Invoke(t_578, "to", ((V)((B_579 * 0.3))), NewObj(5).Put("snap", ((V)((-0.6)))).PutK(((V)(((d_583 < 0D) ? "armL" : "armR"))), ((V)(150D))).PutK(((V)(((d_583 < 0D) ? "armR" : "armL"))), ((V)(30D))).PutK(((V)(((d_583 < 0D) ? "footL" : "footR"))), ((V)(2.2))).Put("tilt", ((V)((d_583 * 3D)))).V, ((V)("o"))), "to", ((V)((B_579 * 0.7))), NewObj(3).Put("snap", ((V)(0.5))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("io")));
i_581++;
}
}
Invoke(t_578, "to", ((V)(200D)), NewObj(4).Put("snap", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
a_580 = Call(spinR_47, V.Undef, t_578, ((V)(1200D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(150D))).V);
Invoke(t_578, "at", a_580);
{
double i_584 = 0;
i_584 = 0D;
while (true) {
if (!((i_584 < 3D))) break;
Invoke(Invoke(t_578, "to", ((V)(150D)), NewObj(1).Put("snap", ((V)((-0.5)))).V, ((V)("o"))), "to", ((V)(250D)), NewObj(1).Put("snap", ((V)(0.4))).V, ((V)("io")));
i_584++;
}
}
Invoke(Invoke(t_578, "at", Add(a_580, ((V)(1201D)))), "to", ((V)(200D)), NewObj(3).Put("snap", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(jump_34, V.Undef, t_578, NewObj(8).Put("h", ((V)(10D))).Put("ant", ((V)(160D))).Put("up", ((V)(240D))).Put("c", ((V)(0.18))).Put("arm", ((V)(120D))).Put("air", NewObj(1).Put("snap", ((V)(1.2))).V).Put("fall", NewObj(1).Put("snap", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(5D))))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(t_578, "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(160D))).Put("armL", ((V)(20D))).Put("tilt", ((V)((-4D)))).Put("snap", ((V)((-0.4)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(0D))).Put("armL", ((V)(0D))).Put("tilt", ((V)(0D))).Put("snap", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_578, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Taco Snap")), ((V)("Snaps his shell like castanets on every beat with flamenco arms and stamps, a spin, a jump that showers lettuce, and an ole.")))).Put("churro", Arr(Call(Fn((V _arrowThis592, int _argc586, V _a588, V _a589, V _a590, V _a591, V[] _rest587) => {
V t_593 = default;
double B_594 = 0;
V a_595 = default;
t_593 = Call(TL_29, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_594 = 520D;
{
double i_596 = 0;
i_596 = 0D;
while (true) {
if (!((i_596 < 4D))) break;
double d_598 = 0;
d_598 = ((i_596 < 2D) ? 1D : (-1D));
Invoke(Invoke(t_593, "to", ((V)((B_594 * 0.4))), NewObj(5).Put("x", ((V)((d_598 * (NumTruthy((i_596 % 2D)) ? 4D : 2D))))).PutK(((V)((NumTruthy((i_596 % 2D)) ? "footR" : "footL"))), ((V)(2.5))).Put("armL", ((V)(60D))).Put("armR", ((V)(20D))).Put("lean", ((V)((d_598 * 1.2)))).V, ((V)("o"))), "to", ((V)((B_594 * 0.6))), NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i")));
i_596++;
}
}
Invoke(t_593, "to", ((V)(300D)), NewObj(4).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
a_595 = Call(spinR_47, V.Undef, t_593, ((V)(1500D)), ((V)(720D)), NewObj(3).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("lift", ((V)(2D))).V);
Invoke(Invoke(Invoke(Invoke(t_593, "at", a_595), "to", ((V)(600D)), NewObj(1).Put("cork", ((V)(1.2))).V, ((V)("io"))), "to", ((V)(900D)), NewObj(1).Put("cork", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("cork", ((V)((-0.4)))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_593, "at", Add(a_595, ((V)(1501D)))), "to", ((V)(300D)), NewObj(4).Put("cork", ((V)(0D))).Put("lift", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sugar")), ((V)("head")), ((V)(4D)));
Invoke(Invoke(Invoke(t_593, "to", ((V)(600D)), NewObj(5).Put("bend", ((V)((-14D)))).Put("lean", ((V)((-2D)))).Put("armL", ((V)(150D))).Put("armR", ((V)(40D))).Put("close", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(5).Put("bend", ((V)(0D))).Put("lean", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_593, "to", ((V)(300D)), NewObj(2).Put("armR", ((V)(150D))).Put("htilt", ((V)(6D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("sugar")), ((V)("body")), ((V)(5D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(2).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_593, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Churro Corkscrew")), ((V)("Suave tango steps, a double spin that twists his ridges into a corkscrew, a deep tango dip and a sugar-dusted pose.")))).Put("khinki", Arr(Call(Fn((V _arrowThis605, int _argc599, V _a601, V _a602, V _a603, V _a604, V[] _rest600) => {
V t_606 = default;
double B_607 = 0;
V a_608 = default;
t_606 = Call(TL_29, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_607 = 500D;
{
double i_609 = 0;
i_609 = 0D;
while (true) {
if (!((i_609 < 4D))) break;
double d_611 = 0;
d_611 = (NumTruthy((i_609 % 2D)) ? 1D : (-1D));
Invoke(t_606, "to", ((V)(B_607)), NewObj(5).Put("kt", ((V)((d_611 * 1D)))).Put("knot", ((V)(((-d_611) * 0.8)))).Put("tilt", ((V)((d_611 * 3D)))).Put("armL", ((V)(((d_611 < 0D) ? 60D : 10D)))).Put("armR", ((V)(((d_611 > 0D) ? 60D : 10D)))).V, ((V)("io")));
i_609++;
}
}
Invoke(t_606, "to", ((V)(300D)), NewObj(5).Put("kt", ((V)(0D))).Put("knot", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
{
double i_612 = 0;
i_612 = 0D;
while (true) {
if (!((i_612 < 3D))) break;
Call(hopC_44, V.Undef, t_606, ((V)(7D)), NewObj(3).Put("chain", ((i_612 < 2D) ? V.True : V.False)).Put("air", NewObj(1).Put("knot", ((V)((NumTruthy((i_612 % 2D)) ? 0.6 : (-0.6))))).V).Put("fall", NewObj(1).Put("knot", ((V)(0D))).V).V);
i_612++;
}
}
a_608 = Call(spinR_47, V.Undef, t_606, ((V)(1400D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).V);
Invoke(Invoke(Invoke(t_606, "at", a_608), "to", ((V)(700D)), NewObj(2).Put("kt", ((V)(1.1))).Put("knot", ((V)((-0.8)))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(2).Put("kt", ((V)(0D))).Put("knot", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_606, "at", Add(a_608, ((V)(1401D)))), "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(shake_35, V.Undef, t_606, NewObj(6).Put("P", ((V)(90D))).Put("env", Arr(((V)(0.4)), ((V)(0.9)), ((V)(1D)), ((V)(0.6)), ((V)(0.3)))).Put("head", ((V)(0.06))).Put("roll", ((V)(3D))).Put("ear", ((V)(0D))).Put("body", ((V)(0.5))).V);
Invoke(t_606, "e", ((V)("emit")), ((V)("pepper")), ((V)("head")), ((V)(5D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_606, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.18))).Put("kt", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(7).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(3D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("kt", ((V)((-0.3)))).Put("wide", ((V)(0.5))).Put("open", ((V)(0.5))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(6D))), "to", ((V)(300D)), NewObj(7).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("kt", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(200D)));
return Invoke(Invoke(t_606, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Topknot Twist")), ((V)("Twists his pleats one way and the other with his knot whipping round, juicy bounces, a twirling spin, a pepper shake and a big juicy squirt.")))).Put("maki", Arr(Call(Fn((V _arrowThis620, int _argc614, V _a616, V _a617, V _a618, V _a619, V[] _rest615) => {
V t_621 = default;
double B_622 = 0;
V a_623 = default;
t_621 = Call(TL_29, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_622 = 500D;
{
double i_624 = 0;
i_624 = 0D;
while (true) {
if (!((i_624 < 4D))) break;
Invoke(Invoke(t_621, "to", ((V)((B_622 / 2D))), NewObj(5).Put("veg", ((V)(0.9))).Put("x", ((V)((NumTruthy((i_624 % 2D)) ? 1.5 : (-1.5))))).Put("tilt", ((V)((NumTruthy((i_624 % 2D)) ? 3D : (-3D))))).Put("footL", ((V)((NumTruthy((i_624 % 2D)) ? 0D : 2D)))).Put("footR", ((V)((NumTruthy((i_624 % 2D)) ? 2D : 0D)))).V, ((V)("o"))), "to", ((V)((B_622 / 2D))), NewObj(3).Put("veg", ((V)(0.1))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("io")));
i_624++;
}
}
Invoke(t_621, "to", ((V)(200D)), NewObj(3).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("veg", ((V)(0D))).V, ((V)("io")));
a_623 = Call(spinR_47, V.Undef, t_621, ((V)(1600D)), ((V)(720D)), NewObj(3).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("lift", ((V)(2D))).V);
Invoke(Invoke(t_621, "at", a_623), "osc", ((V)(1600D)), ((V)(4D)), NewObj(1).Put("veg", ((V)(1D))).V, NewObj(1).Put("veg", ((V)(0.2))).V, ((V)("io")));
Invoke(Invoke(t_621, "at", Add(a_623, ((V)(1601D)))), "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lift", ((V)(0D))).Put("veg", ((V)(0D))).V, ((V)("io")));
{
double i_626 = 0;
i_626 = 0D;
while (true) {
if (!((i_626 < 3D))) break;
Call(hopC_44, V.Undef, t_621, ((V)(6D)), NewObj(4).Put("chain", ((i_626 < 2D) ? V.True : V.False)).Put("air", NewObj(1).Put("veg", ((V)(0.8))).V).Put("fall", NewObj(1).Put("veg", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("rice")), ((V)("head")), ((V)(2D))))).V);
i_626++;
}
}
Invoke(t_621, "to", ((V)(300D)), NewObj(1).Put("close", ((V)(0.7))).V, ((V)("io")));
a_623 = Call(spinR_47, V.Undef, t_621, ((V)(2000D)), ((V)(360D)), NewObj(0).V);
Invoke(t_621, "to", ((V)(200D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_621, "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)((-0.2)))).Put("close", ((V)(0.6))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_621, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Sushi Spin")), ((V)("Sways with his salmon and veggies wiggling, spins like a top twice, three hops that toss rice, a slow calm turn and a bow.")))).Put("noodle", Arr(Call(Fn((V _arrowThis634, int _argc628, V _a630, V _a631, V _a632, V _a633, V[] _rest629) => {
V t_635 = default;
double B_636 = 0;
V a_637 = default;
t_635 = Call(TL_29, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_636 = 480D;
{
double i_638 = 0;
i_638 = 0D;
while (true) {
if (!((i_638 < 4D))) break;
Invoke(Invoke(t_635, "to", ((V)((B_636 / 2D))), NewObj(5).Put("slurp", ((V)(0.8))).Put("x", ((V)((NumTruthy((i_638 % 2D)) ? 1D : (-1D))))).Put("tilt", ((V)((NumTruthy((i_638 % 2D)) ? 3D : (-3D))))).Put("puff", ((V)((-0.2)))).Put("mw", ((V)(0.6))).V, ((V)("o"))), "to", ((V)((B_636 / 2D))), NewObj(3).Put("slurp", ((V)(0D))).Put("puff", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
i_638++;
}
}
Invoke(t_635, "to", ((V)(200D)), NewObj(2).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
{
double i_640 = 0;
i_640 = 0D;
while (true) {
if (!((i_640 < 3D))) break;
Invoke(Invoke(t_635, "to", ((V)(150D)), NewObj(2).Put("lid", ((V)((-0.8)))).Put("armR", ((V)(120D))).V, ((V)("o"))), "to", ((V)((B_636 - 150D))), NewObj(2).Put("lid", ((V)(0.6))).Put("armR", ((V)(30D))).V, ((V)("io")));
i_640++;
}
}
Invoke(t_635, "to", ((V)(200D)), NewObj(2).Put("lid", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
a_637 = Call(spinR_47, V.Undef, t_635, ((V)(1300D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V);
Invoke(t_635, "at", a_637);
Invoke(Arr(((V)(0D)), ((V)(400D)), ((V)(800D))), "forEach", Fn((V _arrowThis649, int _argc642, V d_648, V _a645, V _a646, V _a647, V[] _rest643) => {
return Invoke(Invoke(t_635, "at", Add(a_637, d_648)), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
}, 1, "", true));
Invoke(Invoke(t_635, "at", Add(a_637, ((V)(1301D)))), "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_635, "to", ((V)(400D)), NewObj(5).Put("slurp", ((V)(1.2))).Put("puff", ((V)((-0.3)))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.5))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(5).Put("slurp", ((V)(0D))).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).Put("mw", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(4D))), "wait", ((V)(300D)));
return Invoke(Invoke(t_635, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Noodle Slurp")), ((V)("A slurpy shimmy, lifts noodles with his chopsticks on the beat, a steamy spin and one big slurp.")))).Put("flossie", Arr(Call(Fn((V _arrowThis656, int _argc650, V _a652, V _a653, V _a654, V _a655, V[] _rest651) => {
V t_657 = default;
double B_658 = 0;
V a_659 = default;
t_657 = Call(TL_29, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_658 = 560D;
Invoke(t_657, "to", ((V)(800D)), NewObj(3).Put("lift", ((V)(6D))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("io")));
a_659 = Get(t_657, "t");
Invoke(t_657, "osc", ((V)(2200D)), ((V)(2D)), NewObj(1).Put("lift", ((V)(8D))).V, NewObj(1).Put("lift", ((V)(5D))).V, ((V)("s")));
Invoke(Invoke(Invoke(t_657, "at", a_659), "to", ((V)(2200D)), NewObj(1).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("l")));
Invoke(t_657, "to", ((V)(600D)), NewObj(3).Put("lift", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
{
double i_660 = 0;
i_660 = 0D;
while (true) {
if (!((i_660 < 4D))) break;
Invoke(Invoke(Invoke(t_657, "to", ((V)(150D)), NewObj(2).Put("fluff", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(1D))), "to", ((V)((B_658 - 150D))), NewObj(2).Put("fluff", ((V)(0.1))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_660++;
}
}
Invoke(t_657, "to", ((V)(200D)), NewObj(1).Put("fluff", ((V)(0D))).V, ((V)("io")));
a_659 = Call(spinR_47, V.Undef, t_657, ((V)(1500D)), ((V)(360D)), NewObj(3).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("lift", ((V)(3D))).V);
Invoke(Invoke(Invoke(t_657, "at", a_659), "to", ((V)(1500D)), NewObj(1).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(t_657, "at", Add(a_659, ((V)(1501D)))), "to", ((V)(400D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_657, "to", ((V)(300D)), NewObj(3).Put("fluff", ((V)(1.4))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(4D))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(300D))), "to", ((V)(700D)), NewObj(3).Put("fluff", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_657, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Candy Cloud Float")), ((V)("Floats up and down with her floss swirling round her, poofs on the beat, a twirling spin and a big sparkly poof.")))).V;
Invoke(KEYS_9, "forEach", Fn((V _arrowThis669, int _argc662, V k_668, V _a665, V _a666, V _a667, V[] _rest663) => {
Set(GetK(MOVES_49, k_668), "dance", GetK(DANCES_50, k_668));
Set(GetK(MOVES_49, k_668), "look", Call(natF_41, V.Undef, ((V)(1D))));
return default;
}, 1, "", true));
Call(install_40, V.Undef, MOVES_49, CARDS_48);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_708 => Fn((V _self670, int _argc671, V _a673, V _a674, V _a675, V _a676, V[] _rest672) => {
V R_677 = default;
V S_678 = default;
V hand_679 = default;
V both_680 = default;
V o_681 = default;
V NOHANDS_682 = default;
V jump_683 = default;
V shake_684 = default;
V swing_685 = default;
V jelly_686 = default;
V see_687 = default;
V unsee_688 = default;
V giggle_689 = default;
V sniff_690 = default;
V lick_691 = default;
V para_692 = default;
V leanIn_693 = default;
V happy_694 = default;
V build_695 = default;
V armUp_696 = default;
V eyeRub_697 = default;
V wobble_698 = default;
V lookBack_699 = default;
V hop_700 = default;
V tickle_701 = default;
V tasteHeart_702 = default;
V fizz_703 = default;
V nose_704 = default;
V BODY_705 = default;
V RE_706 = default;
V TXT_707 = default;
if (_self670.IsNullish) _self670 = GlobalV;
R_677 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_677)) || !(Truthy(Get(R_677, "POKELIB")))) || !(Truthy(Get(R_677, "snack2V")))) || !(Truthy(Get(Get(R_677, "STATES"), "poke_head"))))) {
Call(G("setTimeout"), V.Undef, boot_708.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_677, "snack2PokeV"))) {
return default;
}
Set(R_677, "snack2PokeV", ((V)(1D)));
{ V _t709 = Get(R_677, "PETLIB");
if (_t709.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t709));
{ V _t710 = Get(_t709, "S");
S_678 = _t710; }
{ V _t711 = Get(_t709, "hand");
hand_679 = _t711; }
{ V _t712 = Get(_t709, "both");
both_680 = _t712; }
{ V _t713 = Get(_t709, "o");
o_681 = _t713; }
{ V _t714 = Get(_t709, "NOHANDS");
NOHANDS_682 = _t714; }
{ V _t715 = Get(_t709, "jump");
jump_683 = _t715; }
{ V _t716 = Get(_t709, "shake");
shake_684 = _t716; }
{ V _t717 = Get(_t709, "swing");
swing_685 = _t717; }
{ V _t718 = Get(_t709, "jelly");
jelly_686 = _t718; } }
{ V _t719 = Get(R_677, "POKELIB");
if (_t719.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t719));
{ V _t720 = Get(_t719, "see");
see_687 = _t720; }
{ V _t721 = Get(_t719, "unsee");
unsee_688 = _t721; }
{ V _t722 = Get(_t719, "giggle");
giggle_689 = _t722; }
{ V _t723 = Get(_t719, "sniff");
sniff_690 = _t723; }
{ V _t724 = Get(_t719, "lick");
lick_691 = _t724; }
{ V _t725 = Get(_t719, "para");
para_692 = _t725; }
{ V _t726 = Get(_t719, "leanIn");
leanIn_693 = _t726; }
{ V _t727 = Get(_t719, "happy");
happy_694 = _t727; }
{ V _t728 = Get(_t719, "build");
build_695 = _t728; } }
armUp_696 = Fn((V _arrowThis740, int _argc729, V t_735, V s_736, V n_737, V a_738, V[] _rest730) => {
V k_741 = default;
V x_739 = default;
x_739 = (_argc729 > 4 ? _rest730[0] : V.Undef);
k_741 = Call(S_678, V.Undef, s_736);
a_738 = (a_738 is var _t742 && Truthy(_t742) ? _t742 : ((V)(150D)));
Invoke(t_735, "to", ((V)(300D)), Call(o_681, V.Undef, NewObj(1).PutK(Get(k_741, "arm"), a_738).V, (x_739 is var _t743 && Truthy(_t743) ? _t743 : NewObj(0).V)), ((V)("io")));
{
double i_744 = 0;
i_744 = 0D;
while (true) {
if (!(Lt(((V)(i_744)), (n_737 is var _t746 && Truthy(_t746) ? _t746 : ((V)(2D)))))) break;
Invoke(Invoke(t_735, "to", ((V)(170D)), NewObj(1).PutK(Get(k_741, "arm"), ((V)((ToNum(a_738) - 16D)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(1).PutK(Get(k_741, "arm"), a_738).V, ((V)("io")));
i_744++;
}
}
return Invoke(t_735, "to", ((V)(300D)), NewObj(3).PutK(Get(k_741, "arm"), ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
return default;
}, 5, "", true);
eyeRub_697 = Fn((V _arrowThis755, int _argc747, V t_753, V s_754, V _a751, V _a752, V[] _rest748) => {
V k_756 = default;
V h_757 = default;
k_756 = Call(S_678, V.Undef, s_754);
h_757 = Call(hand_679, V.Undef, s_754, ((V)(12D)), ((V)((-20D))));
Invoke(Invoke(t_753, "e", ((V)("blink2"))), "to", ((V)(300D)), Call(o_681, V.Undef, h_757, NewObj(2).PutK(Get(k_756, "arm"), ((V)(20D))).PutK(Get(k_756, "wink"), ((V)(1D))).V), ((V)("io")));
{
double i_758 = 0;
i_758 = 0D;
while (true) {
if (!((i_758 < 2D))) break;
Invoke(Invoke(t_753, "to", ((V)(170D)), NewObj(2).PutK(Get(k_756, "hx"), Add(GetK(h_757, Get(k_756, "hx")), ((V)((LtN(s_754, 0D) ? 3D : (-3D)))))).PutK(Get(k_756, "hy"), ((V)((ToNum(GetK(h_757, Get(k_756, "hy"))) - 1.5)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(2).PutK(Get(k_756, "hx"), GetK(h_757, Get(k_756, "hx"))).PutK(Get(k_756, "hy"), GetK(h_757, Get(k_756, "hy"))).V, ((V)("io")));
i_758++;
}
}
return Invoke(Invoke(t_753, "to", ((V)(300D)), NewObj(4).PutK(Get(k_756, "hx"), ((V)(0D))).PutK(Get(k_756, "hy"), ((V)(0D))).PutK(Get(k_756, "arm"), ((V)(0D))).PutK(Get(k_756, "wink"), ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink")));
return default;
}, 2, "", true);
wobble_698 = Fn((V _arrowThis769, int _argc760, V t_766, V a_767, V ch_768, V _a765, V[] _rest761) => {
return Call(jelly_686, V.Undef, t_766, (a_767 is var _t770 && Truthy(_t770) ? _t770 : ((V)(0.12))), ((V)(3D)), ((V)(300D)), ch_768);
}, 3, "", true);
lookBack_699 = Fn((V _arrowThis779, int _argc771, V t_777, V hold_778, V _a775, V _a776, V[] _rest772) => {
Call(see_687, V.Undef, t_777, ((V)("tail")), ((V)(1D)), (hold_778 is var _t780 && Truthy(_t780) ? _t780 : ((V)(350D))));
return Call(unsee_688, V.Undef, t_777, ((V)(380D)));
return default;
}, 2, "", true);
hop_700 = Fn((V _arrowThis791, int _argc781, V t_787, V h_788, V ev_789, V x_790, V[] _rest782) => {
return Call(jump_683, V.Undef, t_787, Call(o_681, V.Undef, NewObj(6).Put("h", (h_788 is var _t792 && Truthy(_t792) ? _t792 : ((V)(6D)))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).Put("ev", ev_789).V, (x_790 is var _t793 && Truthy(_t793) ? _t793 : NewObj(0).V)));
}, 4, "", true);
tickle_701 = Fn((V _arrowThis802, int _argc794, V t_800, V extra_801, V _a798, V _a799, V[] _rest795) => {
V a_803 = default;
Invoke(t_800, "to", ((V)(220D)), Call(o_681, V.Undef, Call(both_680, V.Undef, ((V)(8D)), ((V)((-4D)))), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
a_803 = Get(t_800, "t");
Call(giggle_689, V.Undef, t_800, ((V)(3D)), ((V)(0.9)));
if (Truthy(extra_801)) {
Call(para_692, V.Undef, t_800, a_803, extra_801);
}
return Invoke(t_800, "to", ((V)(260D)), NOHANDS_682, ((V)("io")));
return default;
}, 2, "", true);
tasteHeart_702 = Fn((V _arrowThis811, int _argc804, V t_810, V _a807, V _a808, V _a809, V[] _rest805) => {
Call(lick_691, V.Undef, t_810, ((V)(2D)));
return Invoke(Invoke(Invoke(Invoke(t_810, "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(320D))), "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true);
fizz_703 = Fn((V _arrowThis822, int _argc812, V t_818, V ch_819, V a_820, V n_821, V[] _rest813) => {
return Invoke(t_818, "osc", ((V)((ToNum(n_821) * 160D))), n_821, NewObj(1).PutK(ch_819, a_820).V, NewObj(1).PutK(ch_819, ((V)(0D))).V, ((V)("io")));
}, 4, "", true);
nose_704 = Fn((V _arrowThis831, int _argc823, V t_829, V k_830, V _a827, V _a828, V[] _rest824) => {
Invoke(t_829, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
if (Truthy(k_830)) {
Call(k_830, V.Undef, t_829);
}
return Invoke(t_829, "to", ((V)(200D)), NewObj(1).Put("ly", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
BODY_705 = NewObj(11).Put("frankie", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _arrowThis839, int _argc832, V s_838, V _a835, V _a836, V _a837, V[] _rest833) => {
return ((V)((GtN(s_838, 0D) ? "Sausage end (right)" : "Sausage end (left)")));
}, 1, "ear", true)).Put("head", ((V)("Sausage"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Bun"))).Put("tail", ((V)("Back of the bun"))).V).V).Put("corny", NewObj(3).Put("ear", ((V)(0.6))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("ear", ((V)("popcorn"))).Put("head", ((V)("Popcorn"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Stripes"))).Put("foot", ((V)("bucket bottom"))).Put("tail", ((V)("Back of the bucket"))).V).V).Put("peppi", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(6).Put("ear", ((V)("crust corner"))).Put("head", ((V)("Crust"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Pepperoni"))).Put("foot", ((V)("tip"))).Put("tail", ((V)("Underside"))).V).V).Put("nori", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("rice corner"))).Put("head", ((V)("Salmon"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Seaweed jacket"))).Put("tail", ((V)("Back"))).V).V).Put("sunny", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(6).Put("ear", ((V)("shell"))).Put("head", ((V)("Shell cap"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("foot", ((V)("Round bottom"))).Put("tail", ((V)("Back"))).V).V).Put("toco", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("lettuce"))).Put("head", ((V)("Fillings"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Shell"))).Put("tail", ((V)("Back of the shell"))).V).V).Put("churro", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("chocolate"))).Put("head", ((V)("Chocolate top"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Ridges"))).Put("tail", ((V)("Back"))).V).V).Put("khinki", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("pleats"))).Put("head", ((V)("Top knot"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Dough belly"))).Put("tail", ((V)("Back"))).V).V).Put("maki", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(6).Put("ear", ((V)("rice rim"))).Put("head", ((V)("Filling"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Rice belly"))).Put("side", ((V)("rice"))).Put("tail", ((V)("Back"))).V).V).Put("noodle", NewObj(3).Put("ear", ((V)(0.6))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("ear", Fn((V _arrowThis847, int _argc840, V s_846, V _a843, V _a844, V _a845, V[] _rest841) => {
return ((V)((GtN(s_846, 0D) ? "Chopsticks" : "Noodles")));
}, 1, "ear", true)).Put("head", ((V)("Toppings"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Red band"))).Put("foot", ((V)("bowl bottom"))).Put("tail", ((V)("Bowl (back)"))).V).V).Put("flossie", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(6).Put("ear", ((V)("floss"))).Put("head", ((V)("Floss top"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Floss"))).Put("foot", ((V)("stick"))).Put("tail", ((V)("Back"))).V).V).V;
RE_706 = NewObj(11).Put("frankie", NewObj(9).Put("head", Fn((V _arrowThis856, int _argc848, V t_854, V s_855, V _a852, V _a853, V[] _rest849) => {
Invoke(Invoke(Invoke(t_854, "to", ((V)(140D)), NewObj(2).Put("hug", ((V)((-0.6)))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(3D))), "to", ((V)(260D)), NewObj(2).Put("hug", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(giggle_689, V.Undef, t_854, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis865, int _argc857, V t_863, V s_864, V _a861, V _a862, V[] _rest858) => {
Invoke(t_863, "to", ((V)(220D)), NewObj(2).Put("slip", ((V)(((-ToNum(s_864)) * 0.8)))).Put("wide", ((V)(0.5))).V, ((V)("o")));
Call(see_687, V.Undef, t_863, ((V)("ear")), s_864, ((V)(150D)));
Invoke(Invoke(t_863, "to", ((V)(320D)), Call(o_681, V.Undef, Call(hand_679, V.Undef, s_864, ((V)(6D)), ((V)((-6D)))), NewObj(2).PutK(Get(Call(S_678, V.Undef, s_864), "arm"), ((V)(60D))).Put("slip", ((V)(0D))).V), ((V)("io"))), "to", ((V)(260D)), Call(o_681, V.Undef, NOHANDS_682, NewObj(2).PutK(Get(Call(S_678, V.Undef, s_864), "arm"), ((V)(0D))).Put("wide", ((V)(0D))).V), ((V)("io")));
Call(unsee_688, V.Undef, t_863);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis874, int _argc866, V t_872, V s_873, V _a870, V _a871, V[] _rest867) => {
return Call(nose_704, V.Undef, t_872, Fn((V _arrowThis882, int _argc875, V u_881, V _a878, V _a879, V _a880, V[] _rest876) => {
Call(sniff_690, V.Undef, u_881, ((V)(2D)));
Call(tasteHeart_702, V.Undef, u_881);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis891, int _argc883, V t_889, V s_890, V _a887, V _a888, V[] _rest884) => {
Call(eyeRub_697, V.Undef, t_889, s_890);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis900, int _argc892, V t_898, V s_899, V _a896, V _a897, V[] _rest893) => {
Call(leanIn_693, V.Undef, t_898, s_899, NewObj(1).Put("hug", ((V)((-0.3)))).V);
Invoke(t_898, "to", ((V)(200D)), NewObj(1).Put("hug", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis909, int _argc901, V t_907, V s_908, V _a905, V _a906, V[] _rest902) => {
Call(tickle_701, V.Undef, t_907, Fn((V _arrowThis917, int _argc910, V u_916, V _a913, V _a914, V _a915, V[] _rest911) => {
return Invoke(Invoke(u_916, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("slip", ((V)(0.5))).V, NewObj(1).Put("slip", ((V)((-0.5)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("slip", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis926, int _argc918, V t_924, V s_925, V _a922, V _a923, V[] _rest919) => {
Invoke(Invoke(Invoke(t_924, "to", ((V)(200D)), NewObj(2).Put("slip", ((V)(((-ToNum(s_925)) * 1D)))).Put("tilt", ((V)(((-ToNum(s_925)) * 4D)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("slip", ((V)(((-ToNum(s_925)) * 0.3)))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("slip", ((V)(0D))).V, ((V)("io")));
Call(see_687, V.Undef, t_924, ((V)("side")), s_925, ((V)(200D)));
Call(unsee_688, V.Undef, t_924, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis935, int _argc927, V t_933, V s_934, V _a931, V _a932, V[] _rest928) => {
Call(hop_700, V.Undef, t_933, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(2D)))), NewObj(2).Put("air", NewObj(1).Put("slip", ((V)(0.4))).V).Put("fall", NewObj(1).Put("slip", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis944, int _argc936, V t_942, V s_943, V _a940, V _a941, V[] _rest937) => {
Invoke(Invoke(t_942, "to", ((V)(160D)), NewObj(1).Put("hug", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("hug", ((V)(0D))).V, ((V)("io")));
Call(lookBack_699, V.Undef, t_942);
return default;
}, 2, "tail", true)).V).Put("corny", NewObj(9).Put("head", Fn((V _arrowThis953, int _argc945, V t_951, V s_952, V _a949, V _a950, V[] _rest946) => {
Invoke(Invoke(Invoke(t_951, "to", ((V)(100D)), NewObj(2).Put("pop", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(3D))), "to", ((V)(380D)), NewObj(2).Put("pop", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
Call(giggle_689, V.Undef, t_951, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis962, int _argc954, V t_960, V s_961, V _a958, V _a959, V[] _rest955) => {
Call(see_687, V.Undef, t_960, ((V)("ear")), s_961, ((V)(100D)));
Invoke(Invoke(t_960, "to", ((V)(100D)), NewObj(1).Put("pop", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
Call(fizz_703, V.Undef, t_960, ((V)("cfz")), ((V)(0.8)), ((V)(3D)));
Call(unsee_688, V.Undef, t_960);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis971, int _argc963, V t_969, V s_970, V _a967, V _a968, V[] _rest964) => {
return Call(nose_704, V.Undef, t_969, Fn((V _arrowThis979, int _argc972, V u_978, V _a975, V _a976, V _a977, V[] _rest973) => {
Call(sniff_690, V.Undef, u_978, ((V)(3D)));
Invoke(Invoke(Invoke(u_978, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("cfz", ((V)(0.7))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("cfz", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis988, int _argc980, V t_986, V s_987, V _a984, V _a985, V[] _rest981) => {
Call(eyeRub_697, V.Undef, t_986, s_987);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis997, int _argc989, V t_995, V s_996, V _a993, V _a994, V[] _rest990) => {
Call(leanIn_693, V.Undef, t_995, s_996, NewObj(1).Put("cfz", ((V)(0.5))).V);
Invoke(t_995, "to", ((V)(200D)), NewObj(1).Put("cfz", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1006, int _argc998, V t_1004, V s_1005, V _a1002, V _a1003, V[] _rest999) => {
Call(tickle_701, V.Undef, t_1004, Fn((V _arrowThis1014, int _argc1007, V u_1013, V _a1010, V _a1011, V _a1012, V[] _rest1008) => {
{
double i_1015 = 0;
i_1015 = 0D;
while (true) {
if (!((i_1015 < 3D))) break;
Invoke(Invoke(u_1013, "to", ((V)(120D)), NewObj(1).Put("pop", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
i_1015++;
}
}
return default;
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1025, int _argc1017, V t_1023, V s_1024, V _a1021, V _a1022, V[] _rest1018) => {
double d_1026 = 0;
d_1026 = (-ToNum(s_1024));
Invoke(Invoke(Invoke(t_1023, "to", ((V)(260D)), NewObj(3).Put("tilt", ((V)((d_1026 * 8D)))).Put("x", ((V)((d_1026 * 2D)))).Put("pop", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(2).Put("tilt", ((V)(((-d_1026) * 3D)))).Put("pop", ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Call(see_687, V.Undef, t_1023, ((V)("side")), s_1024, ((V)(200D)));
Call(unsee_688, V.Undef, t_1023, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1035, int _argc1027, V t_1033, V s_1034, V _a1031, V _a1032, V[] _rest1028) => {
Call(hop_700, V.Undef, t_1033, ((V)(7D)), Arr(Arr(((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(3D)))), NewObj(2).Put("air", NewObj(1).Put("pop", ((V)(1D))).V).Put("fall", NewObj(1).Put("pop", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1044, int _argc1036, V t_1042, V s_1043, V _a1040, V _a1041, V[] _rest1037) => {
Invoke(Invoke(t_1042, "to", ((V)(100D)), NewObj(1).Put("pop", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
Call(lookBack_699, V.Undef, t_1042);
return default;
}, 2, "tail", true)).V).Put("peppi", NewObj(9).Put("head", Fn((V _arrowThis1053, int _argc1045, V t_1051, V s_1052, V _a1049, V _a1050, V[] _rest1046) => {
Invoke(Invoke(Invoke(t_1051, "to", ((V)(200D)), NewObj(2).Put("pull", ((V)(0.8))).Put("lift", ((V)(1.5))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("pull", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("cheese")), ((V)("head")), ((V)(2D)));
Call(giggle_689, V.Undef, t_1051, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1062, int _argc1054, V t_1060, V s_1061, V _a1058, V _a1059, V[] _rest1055) => {
Call(see_687, V.Undef, t_1060, ((V)("ear")), s_1061, ((V)(100D)));
Invoke(t_1060, "osc", ((V)(520D)), ((V)(2D)), NewObj(2).Put("htilt", ((V)((ToNum(s_1061) * 5D)))).Put("tilt", ((V)((ToNum(s_1061) * 2D)))).V, NewObj(2).Put("htilt", s_1061).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(unsee_688, V.Undef, t_1060);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1071, int _argc1063, V t_1069, V s_1070, V _a1067, V _a1068, V[] _rest1064) => {
return Call(nose_704, V.Undef, t_1069, Fn((V _arrowThis1079, int _argc1072, V u_1078, V _a1075, V _a1076, V _a1077, V[] _rest1073) => {
Call(sniff_690, V.Undef, u_1078, ((V)(2D)));
Call(tasteHeart_702, V.Undef, u_1078);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1088, int _argc1080, V t_1086, V s_1087, V _a1084, V _a1085, V[] _rest1081) => {
Call(eyeRub_697, V.Undef, t_1086, s_1087);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1097, int _argc1089, V t_1095, V s_1096, V _a1093, V _a1094, V[] _rest1090) => {
Call(leanIn_693, V.Undef, t_1095, s_1096, NewObj(1).Put("flop", ((V)(0.3))).V);
Invoke(t_1095, "to", ((V)(200D)), NewObj(1).Put("flop", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1106, int _argc1098, V t_1104, V s_1105, V _a1102, V _a1103, V[] _rest1099) => {
Call(tickle_701, V.Undef, t_1104, Fn((V _arrowThis1114, int _argc1107, V u_1113, V _a1110, V _a1111, V _a1112, V[] _rest1108) => {
return Invoke(Invoke(u_1113, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("flop", ((V)(0.8))).V, NewObj(1).Put("flop", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("flop", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1123, int _argc1115, V t_1121, V s_1122, V _a1119, V _a1120, V[] _rest1116) => {
Call(jelly_686, V.Undef, t_1121, ((V)(4D)), ((V)(3D)), ((V)(320D)), ((V)("bend")));
Call(see_687, V.Undef, t_1121, ((V)("side")), s_1122, ((V)(200D)));
Call(unsee_688, V.Undef, t_1121, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1132, int _argc1124, V t_1130, V s_1131, V _a1128, V _a1129, V[] _rest1125) => {
Invoke(t_1130, "to", ((V)(160D)), NewObj(1).Put("flop", ((V)(1D))).V, ((V)("o")));
Call(jelly_686, V.Undef, t_1130, ((V)(0.7)), ((V)(3D)), ((V)(300D)), ((V)("flop")));
Call(see_687, V.Undef, t_1130, ((V)("foot")), s_1131, ((V)(200D)));
Call(unsee_688, V.Undef, t_1130, ((V)(300D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1141, int _argc1133, V t_1139, V s_1140, V _a1137, V _a1138, V[] _rest1134) => {
Invoke(Invoke(t_1139, "to", ((V)(200D)), NewObj(1).Put("flop", ((V)((-0.8)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("flop", ((V)(0D))).V, ((V)("io")));
Call(lookBack_699, V.Undef, t_1139);
return default;
}, 2, "tail", true)).V).Put("nori", NewObj(9).Put("head", Fn((V _arrowThis1150, int _argc1142, V t_1148, V s_1149, V _a1146, V _a1147, V[] _rest1143) => {
Invoke(Invoke(Invoke(t_1148, "to", ((V)(120D)), NewObj(2).Put("ume", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(320D)), NewObj(2).Put("ume", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
Call(giggle_689, V.Undef, t_1148, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1159, int _argc1151, V t_1157, V s_1158, V _a1155, V _a1156, V[] _rest1152) => {
Call(see_687, V.Undef, t_1157, ((V)("ear")), s_1158, ((V)(150D)));
Invoke(t_1157, "to", ((V)(200D)), NewObj(1).Put("blush", ((V)(0.6))).V, ((V)("io")));
Call(unsee_688, V.Undef, t_1157);
Invoke(Invoke(t_1157, "to", ((V)(200D)), NewObj(1).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)(0D))).Put("blush", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1168, int _argc1160, V t_1166, V s_1167, V _a1164, V _a1165, V[] _rest1161) => {
return Call(nose_704, V.Undef, t_1166, Fn((V _arrowThis1176, int _argc1169, V u_1175, V _a1172, V _a1173, V _a1174, V[] _rest1170) => {
Call(sniff_690, V.Undef, u_1175, ((V)(2D)));
Call(tasteHeart_702, V.Undef, u_1175);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1185, int _argc1177, V t_1183, V s_1184, V _a1181, V _a1182, V[] _rest1178) => {
Call(eyeRub_697, V.Undef, t_1183, s_1184);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1194, int _argc1186, V t_1192, V s_1193, V _a1190, V _a1191, V[] _rest1187) => {
Call(leanIn_693, V.Undef, t_1192, s_1193, NewObj(1).Put("blush", ((V)(0.5))).V);
Invoke(t_1192, "to", ((V)(200D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1203, int _argc1195, V t_1201, V s_1202, V _a1199, V _a1200, V[] _rest1196) => {
Invoke(Invoke(Invoke(t_1201, "to", ((V)(200D)), NewObj(3).Put("nwr", ((V)(0.8))).Put("wide", ((V)(0.6))).Put("blush", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(320D)), Call(o_681, V.Undef, Call(both_680, V.Undef, ((V)(4D)), ((V)(4D))), NewObj(2).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V), ((V)("io"))), "to", ((V)(300D)), Call(o_681, V.Undef, NOHANDS_682, NewObj(4).Put("nwr", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wide", ((V)(0D))).V), ((V)("io")));
Call(giggle_689, V.Undef, t_1201, ((V)(2D)));
Invoke(t_1201, "to", ((V)(200D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1212, int _argc1204, V t_1210, V s_1211, V _a1208, V _a1209, V[] _rest1205) => {
Call(jelly_686, V.Undef, t_1210, ((V)(3D)), ((V)(3D)), ((V)(320D)), ((V)("bend")));
Invoke(t_1210, "e", ((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(2D)));
Call(see_687, V.Undef, t_1210, ((V)("side")), s_1211, ((V)(200D)));
Call(unsee_688, V.Undef, t_1210, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1221, int _argc1213, V t_1219, V s_1220, V _a1217, V _a1218, V[] _rest1214) => {
Call(hop_700, V.Undef, t_1219, ((V)(5D)), Arr(Arr(((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(2D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1230, int _argc1222, V t_1228, V s_1229, V _a1226, V _a1227, V[] _rest1223) => {
Invoke(t_1228, "e", ((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(2D)));
Call(lookBack_699, V.Undef, t_1228);
return default;
}, 2, "tail", true)).V).Put("sunny", NewObj(9).Put("head", Fn((V _arrowThis1239, int _argc1231, V t_1237, V s_1238, V _a1235, V _a1236, V[] _rest1232) => {
Invoke(Invoke(Invoke(Invoke(t_1237, "to", ((V)(100D)), NewObj(2).Put("cap", ((V)(0.9))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("wob", ((V)(1D))).V, ((V)("io"))), "to", ((V)(320D)), NewObj(2).Put("cap", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(1).Put("wob", ((V)(0D))).V, ((V)("io")));
Call(giggle_689, V.Undef, t_1237, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1248, int _argc1240, V t_1246, V s_1247, V _a1244, V _a1245, V[] _rest1241) => {
Call(see_687, V.Undef, t_1246, ((V)("ear")), s_1247, ((V)(150D)));
Invoke(Invoke(t_1246, "to", ((V)(140D)), NewObj(1).PutK(((V)((LtN(s_1247, 0D) ? "armL" : "armR"))), ((V)(60D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).PutK(((V)((LtN(s_1247, 0D) ? "armL" : "armR"))), ((V)(0D))).V, ((V)("io")));
Call(unsee_688, V.Undef, t_1246);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1257, int _argc1249, V t_1255, V s_1256, V _a1253, V _a1254, V[] _rest1250) => {
return Call(nose_704, V.Undef, t_1255, Fn((V _arrowThis1265, int _argc1258, V u_1264, V _a1261, V _a1262, V _a1263, V[] _rest1259) => {
Call(sniff_690, V.Undef, u_1264, ((V)(2D)));
Call(tasteHeart_702, V.Undef, u_1264);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1274, int _argc1266, V t_1272, V s_1273, V _a1270, V _a1271, V[] _rest1267) => {
Call(eyeRub_697, V.Undef, t_1272, s_1273);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1283, int _argc1275, V t_1281, V s_1282, V _a1279, V _a1280, V[] _rest1276) => {
Call(leanIn_693, V.Undef, t_1281, s_1282, NewObj(1).Put("cap", ((V)(0.2))).V);
Invoke(t_1281, "to", ((V)(200D)), NewObj(1).Put("cap", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1292, int _argc1284, V t_1290, V s_1291, V _a1288, V _a1289, V[] _rest1285) => {
Call(tickle_701, V.Undef, t_1290, Fn((V _arrowThis1300, int _argc1293, V u_1299, V _a1296, V _a1297, V _a1298, V[] _rest1294) => {
return Invoke(Invoke(u_1299, "osc", ((V)(900D)), ((V)(3D)), NewObj(3).Put("rl", ((V)(10D))).Put("x", ((V)(2D))).Put("cap", ((V)(0.3))).V, NewObj(3).Put("rl", ((V)((-10D)))).Put("x", ((V)((-2D)))).Put("cap", ((V)(0D))).V, ((V)("io"))), "to", ((V)(180D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1309, int _argc1301, V t_1307, V s_1308, V _a1305, V _a1306, V[] _rest1302) => {
double d_1310 = 0;
d_1310 = (-ToNum(s_1308));
Invoke(Invoke(Invoke(Invoke(t_1307, "to", ((V)(240D)), NewObj(3).Put("rl", ((V)((d_1310 * 28D)))).Put("x", ((V)((d_1310 * 6D)))).Put("cap", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(3).Put("rl", ((V)(((-d_1310) * 10D)))).Put("x", ((V)(((-d_1310) * 1.5)))).Put("cap", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)((d_1310 * 3D)))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("io")));
Call(see_687, V.Undef, t_1307, ((V)("side")), s_1308, ((V)(200D)));
Call(unsee_688, V.Undef, t_1307, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1319, int _argc1311, V t_1317, V s_1318, V _a1315, V _a1316, V[] _rest1312) => {
V d_1320 = default;
d_1320 = (s_1318 is var _t1321 && Truthy(_t1321) ? _t1321 : ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(t_1317, "to", ((V)(260D)), NewObj(3).Put("rl", ((V)((ToNum(d_1320) * 38D)))).Put("x", ((V)((ToNum(d_1320) * 8D)))).Put("cap", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(3).Put("rl", ((V)(((-ToNum(d_1320)) * 14D)))).Put("x", ((V)(((-ToNum(d_1320)) * 2D)))).Put("cap", ((V)(0D))).V, ((V)("io"))), "to", ((V)(320D)), NewObj(2).Put("rl", ((V)((ToNum(d_1320) * 5D)))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("io")));
Call(giggle_689, V.Undef, t_1317, ((V)(1D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1330, int _argc1322, V t_1328, V s_1329, V _a1326, V _a1327, V[] _rest1323) => {
Call(wobble_698, V.Undef, t_1328, ((V)(0.1)));
Call(lookBack_699, V.Undef, t_1328);
return default;
}, 2, "tail", true)).V).Put("toco", NewObj(9).Put("head", Fn((V _arrowThis1339, int _argc1331, V t_1337, V s_1338, V _a1335, V _a1336, V[] _rest1332) => {
Invoke(Invoke(Invoke(Invoke(t_1337, "to", ((V)(80D)), NewObj(2).Put("snap", ((V)((-0.7)))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("snap", ((V)(0.5))).Put("sq", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
Call(giggle_689, V.Undef, t_1337, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1348, int _argc1340, V t_1346, V s_1347, V _a1344, V _a1345, V[] _rest1341) => {
Call(see_687, V.Undef, t_1346, ((V)("ear")), s_1347, ((V)(100D)));
Invoke(t_1346, "to", ((V)(240D)), NewObj(1).Put("snap", ((V)(0.6))).V, ((V)("o")));
Call(armUp_696, V.Undef, t_1346, s_1347, ((V)(1D)), ((V)(138D)));
Invoke(t_1346, "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
Call(unsee_688, V.Undef, t_1346);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1357, int _argc1349, V t_1355, V s_1356, V _a1353, V _a1354, V[] _rest1350) => {
return Call(nose_704, V.Undef, t_1355, Fn((V _arrowThis1365, int _argc1358, V u_1364, V _a1361, V _a1362, V _a1363, V[] _rest1359) => {
Call(sniff_690, V.Undef, u_1364, ((V)(2D)));
Invoke(Invoke(u_1364, "to", ((V)(100D)), NewObj(1).Put("snap", ((V)((-0.5)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
Call(tasteHeart_702, V.Undef, u_1364);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1374, int _argc1366, V t_1372, V s_1373, V _a1370, V _a1371, V[] _rest1367) => {
Call(eyeRub_697, V.Undef, t_1372, s_1373);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1383, int _argc1375, V t_1381, V s_1382, V _a1379, V _a1380, V[] _rest1376) => {
Call(leanIn_693, V.Undef, t_1381, s_1382, NewObj(1).Put("snap", ((V)((-0.3)))).V);
Invoke(t_1381, "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1392, int _argc1384, V t_1390, V s_1391, V _a1388, V _a1389, V[] _rest1385) => {
Call(tickle_701, V.Undef, t_1390, Fn((V _arrowThis1400, int _argc1393, V u_1399, V _a1396, V _a1397, V _a1398, V[] _rest1394) => {
{
double i_1401 = 0;
i_1401 = 0D;
while (true) {
if (!((i_1401 < 3D))) break;
Invoke(Invoke(u_1399, "to", ((V)(100D)), NewObj(1).Put("snap", ((V)((-0.5)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0.4))).V, ((V)("io")));
i_1401++;
}
}
Invoke(u_1399, "to", ((V)(100D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1411, int _argc1403, V t_1409, V s_1410, V _a1407, V _a1408, V[] _rest1404) => {
Call(jelly_686, V.Undef, t_1409, ((V)(3D)), ((V)(3D)), ((V)(300D)), ((V)("bend")));
Invoke(t_1409, "e", ((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(1D)));
Call(see_687, V.Undef, t_1409, ((V)("side")), s_1410, ((V)(200D)));
Call(unsee_688, V.Undef, t_1409, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1420, int _argc1412, V t_1418, V s_1419, V _a1416, V _a1417, V[] _rest1413) => {
Call(hop_700, V.Undef, t_1418, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(2D)))), NewObj(2).Put("air", NewObj(1).Put("snap", ((V)(0.6))).V).Put("fall", NewObj(1).Put("snap", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1429, int _argc1421, V t_1427, V s_1428, V _a1425, V _a1426, V[] _rest1422) => {
Invoke(Invoke(t_1427, "to", ((V)(100D)), NewObj(1).Put("snap", ((V)((-0.6)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
Call(lookBack_699, V.Undef, t_1427);
return default;
}, 2, "tail", true)).V).Put("churro", NewObj(9).Put("head", Fn((V _arrowThis1438, int _argc1430, V t_1436, V s_1437, V _a1434, V _a1435, V[] _rest1431) => {
Invoke(Invoke(Invoke(t_1436, "e", ((V)("emit")), ((V)("sugar")), ((V)("head")), ((V)(4D))), "to", ((V)(300D)), NewObj(1).Put("cork", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io")));
Call(giggle_689, V.Undef, t_1436, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1447, int _argc1439, V t_1445, V s_1446, V _a1443, V _a1444, V[] _rest1440) => {
Call(see_687, V.Undef, t_1445, ((V)("ear")), s_1446, ((V)(100D)));
Call(armUp_696, V.Undef, t_1445, s_1446, ((V)(2D)), ((V)(140D)));
Invoke(Invoke(Invoke(t_1445, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
Call(unsee_688, V.Undef, t_1445);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1456, int _argc1448, V t_1454, V s_1455, V _a1452, V _a1453, V[] _rest1449) => {
return Call(nose_704, V.Undef, t_1454, Fn((V _arrowThis1464, int _argc1457, V u_1463, V _a1460, V _a1461, V _a1462, V[] _rest1458) => {
Call(sniff_690, V.Undef, u_1463, ((V)(2D)));
Call(tasteHeart_702, V.Undef, u_1463);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1473, int _argc1465, V t_1471, V s_1472, V _a1469, V _a1470, V[] _rest1466) => {
Call(eyeRub_697, V.Undef, t_1471, s_1472);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1482, int _argc1474, V t_1480, V s_1481, V _a1478, V _a1479, V[] _rest1475) => {
Call(leanIn_693, V.Undef, t_1480, s_1481, NewObj(1).Put("cork", ((V)(0.3))).V);
Invoke(t_1480, "to", ((V)(200D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1491, int _argc1483, V t_1489, V s_1490, V _a1487, V _a1488, V[] _rest1484) => {
Call(tickle_701, V.Undef, t_1489, Fn((V _arrowThis1499, int _argc1492, V u_1498, V _a1495, V _a1496, V _a1497, V[] _rest1493) => {
return Invoke(Invoke(u_1498, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("cork", ((V)(0.7))).V, NewObj(1).Put("cork", ((V)((-0.7)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1508, int _argc1500, V t_1506, V s_1507, V _a1504, V _a1505, V[] _rest1501) => {
Invoke(Invoke(Invoke(t_1506, "to", ((V)(400D)), NewObj(2).Put("cork", ((V)(((-ToNum(s_1507)) * 0.9)))).Put("spin", ((V)(((-ToNum(s_1507)) * 18D)))).V, ((V)("io"))), "to", ((V)(450D)), NewObj(2).Put("cork", ((V)((ToNum(s_1507) * 0.2)))).Put("spin", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io")));
Call(see_687, V.Undef, t_1506, ((V)("side")), s_1507, ((V)(200D)));
Call(unsee_688, V.Undef, t_1506, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1517, int _argc1509, V t_1515, V s_1516, V _a1513, V _a1514, V[] _rest1510) => {
Call(hop_700, V.Undef, t_1515, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("sugar")), ((V)("body")), ((V)(3D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1526, int _argc1518, V t_1524, V s_1525, V _a1522, V _a1523, V[] _rest1519) => {
Invoke(t_1524, "e", ((V)("emit")), ((V)("sugar")), ((V)("body")), ((V)(3D)));
Call(lookBack_699, V.Undef, t_1524);
return default;
}, 2, "tail", true)).V).Put("khinki", NewObj(9).Put("head", Fn((V _arrowThis1535, int _argc1527, V t_1533, V s_1534, V _a1531, V _a1532, V[] _rest1528) => {
Invoke(Invoke(Invoke(t_1533, "to", ((V)(120D)), NewObj(2).Put("knot", ((V)(0.9))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("knot", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("knot", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(giggle_689, V.Undef, t_1533, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1544, int _argc1536, V t_1542, V s_1543, V _a1540, V _a1541, V[] _rest1537) => {
Call(see_687, V.Undef, t_1542, ((V)("ear")), s_1543, ((V)(100D)));
Invoke(Invoke(t_1542, "to", ((V)(300D)), NewObj(1).Put("kt", ((V)((ToNum(s_1543) * 0.7)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("kt", ((V)(0D))).V, ((V)("io")));
Call(unsee_688, V.Undef, t_1542);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1553, int _argc1545, V t_1551, V s_1552, V _a1549, V _a1550, V[] _rest1546) => {
return Call(nose_704, V.Undef, t_1551, Fn((V _arrowThis1561, int _argc1554, V u_1560, V _a1557, V _a1558, V _a1559, V[] _rest1555) => {
Call(sniff_690, V.Undef, u_1560, ((V)(2D)));
Call(tasteHeart_702, V.Undef, u_1560);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1570, int _argc1562, V t_1568, V s_1569, V _a1566, V _a1567, V[] _rest1563) => {
Call(eyeRub_697, V.Undef, t_1568, s_1569);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1579, int _argc1571, V t_1577, V s_1578, V _a1575, V _a1576, V[] _rest1572) => {
Call(leanIn_693, V.Undef, t_1577, s_1578, NewObj(1).Put("knot", ((V)(((-ToNum(s_1578)) * 0.3)))).V);
Invoke(t_1577, "to", ((V)(200D)), NewObj(1).Put("knot", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1588, int _argc1580, V t_1586, V s_1587, V _a1584, V _a1585, V[] _rest1581) => {
Invoke(Invoke(Invoke(t_1586, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(tickle_701, V.Undef, t_1586, Fn((V _arrowThis1596, int _argc1589, V u_1595, V _a1592, V _a1593, V _a1594, V[] _rest1590) => {
return Invoke(Invoke(u_1595, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("knot", ((V)(0.5))).V, NewObj(1).Put("knot", ((V)((-0.5)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("knot", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1605, int _argc1597, V t_1603, V s_1604, V _a1601, V _a1602, V[] _rest1598) => {
Call(jelly_686, V.Undef, t_1603, ((V)(4D)), ((V)(3D)), ((V)(320D)), ((V)("bend")));
Invoke(Invoke(t_1603, "to", ((V)(200D)), NewObj(1).Put("knot", ((V)(((-ToNum(s_1604)) * 0.6)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("knot", ((V)(0D))).V, ((V)("io")));
Call(see_687, V.Undef, t_1603, ((V)("side")), s_1604, ((V)(200D)));
Call(unsee_688, V.Undef, t_1603, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1614, int _argc1606, V t_1612, V s_1613, V _a1610, V _a1611, V[] _rest1607) => {
Call(hop_700, V.Undef, t_1612, ((V)(6D)), V.Null, NewObj(2).Put("air", NewObj(1).Put("knot", ((V)(0.5))).V).Put("fall", NewObj(1).Put("knot", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1623, int _argc1615, V t_1621, V s_1622, V _a1619, V _a1620, V[] _rest1616) => {
Invoke(t_1621, "e", ((V)("emit")), ((V)("pepper")), ((V)("head")), ((V)(2D)));
Call(lookBack_699, V.Undef, t_1621);
return default;
}, 2, "tail", true)).V).Put("maki", NewObj(9).Put("head", Fn((V _arrowThis1632, int _argc1624, V t_1630, V s_1631, V _a1628, V _a1629, V[] _rest1625) => {
Invoke(Invoke(t_1630, "to", ((V)(120D)), NewObj(3).Put("veg", ((V)(1D))).Put("sq", ((V)(0.06))).Put("close", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(3).Put("veg", ((V)(0D))).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Call(giggle_689, V.Undef, t_1630, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1641, int _argc1633, V t_1639, V s_1640, V _a1637, V _a1638, V[] _rest1634) => {
Call(see_687, V.Undef, t_1639, ((V)("ear")), s_1640, ((V)(150D)));
Invoke(Invoke(t_1639, "to", ((V)(120D)), NewObj(1).Put("veg", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("veg", ((V)(0D))).V, ((V)("io")));
Call(unsee_688, V.Undef, t_1639);
Call(giggle_689, V.Undef, t_1639, ((V)(1D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1650, int _argc1642, V t_1648, V s_1649, V _a1646, V _a1647, V[] _rest1643) => {
return Call(nose_704, V.Undef, t_1648, Fn((V _arrowThis1658, int _argc1651, V u_1657, V _a1654, V _a1655, V _a1656, V[] _rest1652) => {
Call(sniff_690, V.Undef, u_1657, ((V)(2D)));
Call(tasteHeart_702, V.Undef, u_1657);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1667, int _argc1659, V t_1665, V s_1666, V _a1663, V _a1664, V[] _rest1660) => {
Call(eyeRub_697, V.Undef, t_1665, s_1666);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1676, int _argc1668, V t_1674, V s_1675, V _a1672, V _a1673, V[] _rest1669) => {
Call(leanIn_693, V.Undef, t_1674, s_1675);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1685, int _argc1677, V t_1683, V s_1684, V _a1681, V _a1682, V[] _rest1678) => {
Call(tickle_701, V.Undef, t_1683, Fn((V _arrowThis1693, int _argc1686, V u_1692, V _a1689, V _a1690, V _a1691, V[] _rest1687) => {
return Invoke(Invoke(u_1692, "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(6D))).Put("veg", ((V)(0.5))).V, NewObj(2).Put("tilt", ((V)((-6D)))).Put("veg", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1702, int _argc1694, V t_1700, V s_1701, V _a1698, V _a1699, V[] _rest1695) => {
Invoke(Invoke(t_1700, "to", ((V)(420D)), NewObj(2).Put("spin", ((V)(((-ToNum(s_1701)) * 50D)))).Put("veg", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(420D)), NewObj(2).Put("spin", ((V)(0D))).Put("veg", ((V)(0D))).V, ((V)("io")));
Call(see_687, V.Undef, t_1700, ((V)("side")), s_1701, ((V)(200D)));
Call(unsee_688, V.Undef, t_1700, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1711, int _argc1703, V t_1709, V s_1710, V _a1707, V _a1708, V[] _rest1704) => {
Call(hop_700, V.Undef, t_1709, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(2D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1720, int _argc1712, V t_1718, V s_1719, V _a1716, V _a1717, V[] _rest1713) => {
Invoke(t_1718, "e", ((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(2D)));
Call(lookBack_699, V.Undef, t_1718);
return default;
}, 2, "tail", true)).V).Put("noodle", NewObj(9).Put("head", Fn((V _arrowThis1729, int _argc1721, V t_1727, V s_1728, V _a1725, V _a1726, V[] _rest1722) => {
Invoke(Invoke(Invoke(t_1727, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(4D))), "to", ((V)(150D)), NewObj(2).Put("slurp", ((V)(0.6))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("slurp", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(giggle_689, V.Undef, t_1727, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1738, int _argc1730, V t_1736, V s_1737, V _a1734, V _a1735, V[] _rest1731) => {
Call(see_687, V.Undef, t_1736, ((V)("ear")), s_1737, ((V)(100D)));
if (GtN(s_1737, 0D)) {
Invoke(Invoke(t_1736, "osc", ((V)(600D)), ((V)(3D)), NewObj(1).Put("lid", ((V)((-0.7)))).V, NewObj(1).Put("lid", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("lid", ((V)(0D))).V, ((V)("io")));
} else {
Invoke(Invoke(t_1736, "to", ((V)(300D)), NewObj(1).Put("slurp", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("slurp", ((V)(0D))).V, ((V)("io")));
}
Call(unsee_688, V.Undef, t_1736);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1747, int _argc1739, V t_1745, V s_1746, V _a1743, V _a1744, V[] _rest1740) => {
return Call(nose_704, V.Undef, t_1745, Fn((V _arrowThis1755, int _argc1748, V u_1754, V _a1751, V _a1752, V _a1753, V[] _rest1749) => {
Call(sniff_690, V.Undef, u_1754, ((V)(3D)));
Invoke(u_1754, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
Call(tasteHeart_702, V.Undef, u_1754);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1764, int _argc1756, V t_1762, V s_1763, V _a1760, V _a1761, V[] _rest1757) => {
Call(eyeRub_697, V.Undef, t_1762, s_1763);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1773, int _argc1765, V t_1771, V s_1772, V _a1769, V _a1770, V[] _rest1766) => {
Call(leanIn_693, V.Undef, t_1771, s_1772, NewObj(1).Put("lid", ((V)(0.3))).V);
Invoke(t_1771, "to", ((V)(200D)), NewObj(1).Put("lid", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1782, int _argc1774, V t_1780, V s_1781, V _a1778, V _a1779, V[] _rest1775) => {
Call(tickle_701, V.Undef, t_1780, Fn((V _arrowThis1790, int _argc1783, V u_1789, V _a1786, V _a1787, V _a1788, V[] _rest1784) => {
return Invoke(Invoke(u_1789, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("lid", ((V)(0.6))).V, NewObj(1).Put("lid", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("lid", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1799, int _argc1791, V t_1797, V s_1798, V _a1795, V _a1796, V[] _rest1792) => {
Call(jelly_686, V.Undef, t_1797, ((V)(3D)), ((V)(3D)), ((V)(300D)), ((V)("bend")));
Invoke(t_1797, "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(2D)));
Call(see_687, V.Undef, t_1797, ((V)("side")), s_1798, ((V)(200D)));
Call(unsee_688, V.Undef, t_1797, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1808, int _argc1800, V t_1806, V s_1807, V _a1804, V _a1805, V[] _rest1801) => {
Call(hop_700, V.Undef, t_1806, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)))), NewObj(2).Put("air", NewObj(1).Put("lid", ((V)(0.7))).V).Put("fall", NewObj(1).Put("lid", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1817, int _argc1809, V t_1815, V s_1816, V _a1813, V _a1814, V[] _rest1810) => {
Invoke(t_1815, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
Call(lookBack_699, V.Undef, t_1815);
return default;
}, 2, "tail", true)).V).Put("flossie", NewObj(9).Put("head", Fn((V _arrowThis1826, int _argc1818, V t_1824, V s_1825, V _a1822, V _a1823, V[] _rest1819) => {
Invoke(Invoke(Invoke(t_1824, "to", ((V)(150D)), NewObj(2).Put("fluff", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(2D))), "to", ((V)(500D)), NewObj(2).Put("fluff", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(giggle_689, V.Undef, t_1824, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1835, int _argc1827, V t_1833, V s_1834, V _a1831, V _a1832, V[] _rest1828) => {
Call(see_687, V.Undef, t_1833, ((V)("ear")), s_1834, ((V)(150D)));
Invoke(Invoke(t_1833, "to", ((V)(600D)), NewObj(1).Put("swirl", ((V)((ToNum(s_1834) * 0.3)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("io")));
Call(unsee_688, V.Undef, t_1833);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1844, int _argc1836, V t_1842, V s_1843, V _a1840, V _a1841, V[] _rest1837) => {
return Call(nose_704, V.Undef, t_1842, Fn((V _arrowThis1852, int _argc1845, V u_1851, V _a1848, V _a1849, V _a1850, V[] _rest1846) => {
Call(sniff_690, V.Undef, u_1851, ((V)(2D)));
Call(tasteHeart_702, V.Undef, u_1851);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1861, int _argc1853, V t_1859, V s_1860, V _a1857, V _a1858, V[] _rest1854) => {
Call(eyeRub_697, V.Undef, t_1859, s_1860);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1870, int _argc1862, V t_1868, V s_1869, V _a1866, V _a1867, V[] _rest1863) => {
Call(leanIn_693, V.Undef, t_1868, s_1869, NewObj(1).Put("fluff", ((V)(0.4))).V);
Invoke(t_1868, "to", ((V)(200D)), NewObj(1).Put("fluff", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1879, int _argc1871, V t_1877, V s_1878, V _a1875, V _a1876, V[] _rest1872) => {
Call(tickle_701, V.Undef, t_1877, Fn((V _arrowThis1887, int _argc1880, V u_1886, V _a1883, V _a1884, V _a1885, V[] _rest1881) => {
return Invoke(Invoke(u_1886, "to", ((V)(300D)), NewObj(1).Put("fluff", ((V)(1D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("fluff", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1896, int _argc1888, V t_1894, V s_1895, V _a1892, V _a1893, V[] _rest1889) => {
Invoke(Invoke(t_1894, "to", ((V)(500D)), NewObj(2).Put("swirl", ((V)(((-ToNum(s_1895)) * 0.4)))).Put("x", ((V)(((-ToNum(s_1895)) * 2D)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(2).Put("swirl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Call(see_687, V.Undef, t_1894, ((V)("side")), s_1895, ((V)(200D)));
Call(unsee_688, V.Undef, t_1894, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1905, int _argc1897, V t_1903, V s_1904, V _a1901, V _a1902, V[] _rest1898) => {
Call(hop_700, V.Undef, t_1903, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(2D)))), NewObj(2).Put("air", NewObj(1).Put("fluff", ((V)(0.8))).V).Put("fall", NewObj(1).Put("fluff", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1914, int _argc1906, V t_1912, V s_1913, V _a1910, V _a1911, V[] _rest1907) => {
Invoke(Invoke(t_1912, "to", ((V)(200D)), NewObj(1).Put("fluff", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("fluff", ((V)(0D))).V, ((V)("io")));
Call(lookBack_699, V.Undef, t_1912);
return default;
}, 2, "tail", true)).V).V;
TXT_707 = NewObj(11).Put("frankie", NewObj(9).Put("head", ((V)("His bun hugs the sausage tight, a squirt of mustard, a giggle."))).Put("ear", ((V)("The sausage slides out the other end - he pushes it back with a paw."))).Put("nose", ((V)("Sniffs your finger and licks it: a heart."))).Put("eye", ((V)("Blinks hard and rubs the eye."))).Put("cheek", ((V)("Leans into your finger, his bun squeezes a little."))).Put("belly", ((V)("Ticklish bun: giggles while the sausage slides back and forth."))).Put("side", ((V)("The sausage slides away from the poke and back, he looks."))).Put("foot", ((V)("A hop - the sausage slides as he lands."))).Put("tail", ((V)("The bun opens a little, he looks back."))).V).Put("corny", NewObj(9).Put("head", ((V)("Pop! Kernels jump up and fall back in, she giggles."))).Put("ear", ((V)("A few kernels pop and she fizzes."))).Put("nose", ((V)("Sniffs your finger, fizzes with happiness."))).Put("eye", ((V)("Blinks and rubs her eye."))).Put("cheek", ((V)("Leans in, fizzing a little."))).Put("belly", ((V)("Ticklish stripes: giggles, popcorn popping."))).Put("side", ((V)("Rocks away, popcorn bouncing, looks at the spot."))).Put("foot", ((V)("Hops - all the popcorn jumps."))).Put("tail", ((V)("A few kernels hop, she looks back."))).V).Put("peppi", NewObj(9).Put("head", ((V)("His crust lifts and the cheese stretches, he giggles."))).Put("ear", ((V)("Tilts at the poke on his crust corner."))).Put("nose", ((V)("Sniffs your finger and licks it: a cheesy heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his tip flopping."))).Put("belly", ((V)("Ticklish pepperoni: giggles, tip flapping."))).Put("side", ((V)("Wobbles like a soft slice, looks at the spot."))).Put("foot", ((V)("His tip flops and wobbles, he looks down."))).Put("tail", ((V)("His tip flips back, he looks behind."))).V).Put("nori", NewObj(9).Put("head", ((V)("His salmon flakes hop up with a sparkle, he giggles."))).Put("ear", ((V)("Looks up at his rice corner, blushes, a little bow."))).Put("nose", ((V)("Sniffs your finger politely, then a lick: a heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, blushing."))).Put("belly", ((V)("Oh no, his seaweed jacket slips - he blushes and tugs it back."))).Put("side", ((V)("Wobbles, a few rice grains fall, he looks."))).Put("foot", ((V)("A neat little hop, rice grains fly."))).Put("tail", ((V)("A grain of rice drops, he looks back."))).V).Put("sunny", NewObj(9).Put("head", ((V)("Her shell cap pops up and drops back on, the yolk wobbles, she giggles."))).Put("ear", ((V)("Looks at the tap on her shell and pats it."))).Put("nose", ((V)("Sniffs your finger and licks it: a heart."))).Put("eye", ((V)("Blinks and rubs her eye."))).Put("cheek", ((V)("Leans into your finger, her cap lifting a little."))).Put("belly", ((V)("Ticklish tummy: giggles, rocking on her round bottom."))).Put("side", ((V)("Rolls a little away from the poke and wobbles back upright."))).Put("foot", ((V)("Tap her round bottom: she rocks right over and wobbles back, giggling."))).Put("tail", ((V)("A soft wobble, she looks back."))).V).Put("toco", NewObj(9).Put("head", ((V)("His shell snaps shut and pops open, lettuce flies."))).Put("ear", ((V)("Opens his shell and pats his lettuce back in."))).Put("nose", ((V)("Sniffs, a crunchy little chomp, then licks your finger."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his shell closing a little."))).Put("belly", ((V)("Ticklish shell: giggles, snapping like castanets."))).Put("side", ((V)("Wobbles, a lettuce leaf falls, he looks."))).Put("foot", ((V)("Hops, his shell opens in the air."))).Put("tail", ((V)("Snaps his shell, looks back."))).V).Put("churro", NewObj(9).Put("head", ((V)("Sugar puffs off him and his ridges twist, he giggles."))).Put("ear", ((V)("Reaches up and dabs his chocolate top."))).Put("nose", ((V)("Sniffs your finger and licks it: a sweet heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, a little twist."))).Put("belly", ((V)("Ticklish ridges: giggles, twisting like a corkscrew."))).Put("side", ((V)("Twists away from the poke and back, looks."))).Put("foot", ((V)("A hop, sugar falls."))).Put("tail", ((V)("Sugar sprinkles off, he looks back."))).V).Put("khinki", NewObj(9).Put("head", ((V)("His top knot flicks like a ponytail, he giggles."))).Put("ear", ((V)("His pleats twist round from the poke."))).Put("nose", ((V)("Sniffs your finger and licks it: a heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans into your finger, his knot tipping."))).Put("belly", ((V)("So juicy: a squirt of broth, then he giggles, knot wagging."))).Put("side", ((V)("A doughy wobble, his knot flicks, he looks."))).Put("foot", ((V)("A hop, his knot bounces."))).Put("tail", ((V)("A sprinkle of pepper, he looks back."))).V).Put("maki", NewObj(9).Put("head", ((V)("His salmon and veggies pop up out of the rice, he giggles."))).Put("ear", ((V)("Looks at his rice rim, the veggies bob."))).Put("nose", ((V)("Sniffs your finger and licks it: a heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Ticklish rice: rocks with giggles, veggies wiggling."))).Put("side", ((V)("Turns away like a spinning top and back."))).Put("foot", ((V)("A hop, rice grains fly."))).Put("tail", ((V)("A grain of rice falls, he looks back."))).V).Put("noodle", NewObj(9).Put("head", ((V)("Steam puffs out, his noodles slurp, he giggles."))).Put("ear", Fn((V _arrowThis1922, int _argc1915, V s_1921, V _a1918, V _a1919, V _a1920, V[] _rest1916) => {
return ((V)((GtN(s_1921, 0D) ? "His chopsticks bob up and down with noodles." : "His noodles slurp up out of reach.")));
}, 1, "ear", true)).Put("nose", ((V)("Sniffs your finger, steam, then a lick: a heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his chopsticks lifting a few noodles."))).Put("belly", ((V)("Ticklish band: giggles, chopsticks bobbing."))).Put("side", ((V)("Wobbles, a splash of broth, he looks."))).Put("foot", ((V)("A hop that lifts his chopsticks."))).Put("tail", ((V)("A puff of steam, he looks back."))).V).Put("flossie", NewObj(9).Put("head", ((V)("Her floss poofs up big, she giggles."))).Put("ear", ((V)("Her floss swirls round from the poke."))).Put("nose", ((V)("Sniffs your finger and licks it: a sugary heart."))).Put("eye", ((V)("Blinks and rubs her eye."))).Put("cheek", ((V)("Leans into your finger, fluffing up."))).Put("belly", ((V)("Ticklish floss: giggles and poofs."))).Put("side", ((V)("Her floss swirls away from the poke and back."))).Put("foot", ((V)("A hop, her floss poofs."))).Put("tail", ((V)("A soft poof, she looks back."))).V).V;
Call(build_695, V.Undef, RE_706, TXT_707, BODY_705);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_1946 => Fn((V _self1923, int _argc1924, V _a1926, V _a1927, V _a1928, V _a1929, V[] _rest1925) => {
V R_1930 = default;
V hand_1931 = default;
V both_1932 = default;
V o_1933 = default;
V NOHANDS_1934 = default;
V jump_1935 = default;
V swing_1936 = default;
V jelly_1937 = default;
V EAR_1938 = default;
V sniffF_1939 = default;
V lipLick_1940 = default;
V hearts_1941 = default;
V pat_1942 = default;
V buildAll_1943 = default;
V hop_1944 = default;
V CARDS_1945 = default;
if (_self1923.IsNullish) _self1923 = GlobalV;
R_1930 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_1930)) || !(Truthy(Get(R_1930, "EATKIT")))) || !(Truthy(Get(R_1930, "snack2V")))) || !(Truthy(Get(R_1930, "EATLIB"))))) {
Call(G("setTimeout"), V.Undef, boot_1946.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_1930, "snack2EatV"))) {
return default;
}
Set(R_1930, "snack2EatV", ((V)(1D)));
{ V _t1947 = Get(R_1930, "PETLIB");
if (_t1947.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1947));
{ V _t1948 = Get(_t1947, "hand");
hand_1931 = _t1948; }
{ V _t1949 = Get(_t1947, "both");
both_1932 = _t1949; }
{ V _t1950 = Get(_t1947, "o");
o_1933 = _t1950; }
{ V _t1951 = Get(_t1947, "NOHANDS");
NOHANDS_1934 = _t1951; }
{ V _t1952 = Get(_t1947, "jump");
jump_1935 = _t1952; }
{ V _t1953 = Get(_t1947, "swing");
swing_1936 = _t1953; }
{ V _t1954 = Get(_t1947, "jelly");
jelly_1937 = _t1954; } }
{ V _t1955 = Get(R_1930, "EATKIT");
if (_t1955.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1955));
{ V _t1956 = Get(_t1955, "EAR");
EAR_1938 = _t1956; }
{ V _t1957 = Get(_t1955, "sniffF");
sniffF_1939 = _t1957; }
{ V _t1958 = Get(_t1955, "lipLick");
lipLick_1940 = _t1958; }
{ V _t1959 = Get(_t1955, "hearts");
hearts_1941 = _t1959; }
{ V _t1960 = Get(_t1955, "pat");
pat_1942 = _t1960; }
{ V _t1961 = Get(_t1955, "buildAll");
buildAll_1943 = _t1961; } }
Object_assign(EAR_1938, NewObj(11).Put("frankie", ((V)(0.6))).Put("corny", ((V)(0.6))).Put("peppi", ((V)(0.6))).Put("nori", ((V)(0.6))).Put("sunny", ((V)(0.6))).Put("toco", ((V)(0.6))).Put("churro", ((V)(0.6))).Put("khinki", ((V)(0.6))).Put("maki", ((V)(0.6))).Put("noodle", ((V)(0.6))).Put("flossie", ((V)(0.6))).V);
hop_1944 = Fn((V _arrowThis1971, int _argc1962, V t_1968, V h_1969, V x_1970, V _a1967, V[] _rest1963) => {
return Call(jump_1935, V.Undef, t_1968, Call(o_1933, V.Undef, NewObj(5).Put("h", (h_1969 is var _t1972 && Truthy(_t1972) ? _t1972 : ((V)(6D)))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).V, (x_1970 is var _t1973 && Truthy(_t1973) ? _t1973 : NewObj(0).V)));
}, 3, "", true);
CARDS_1945 = NewObj(11).Put("frankie", NewObj(8).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.8))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("A squirt of mustard first, big happy bites, then hugs his sausage in his bun when he likes it."))).Put("pre", Fn((V _arrowThis1981, int _argc1974, V t_1980, V _a1977, V _a1978, V _a1979, V[] _rest1975) => {
return Invoke(Invoke(Invoke(t_1980, "to", ((V)(200D)), NewObj(1).Put("hug", ((V)((-0.5)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(2D))), "to", ((V)(220D)), NewObj(1).Put("hug", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis1989, int _argc1982, V t_1988, V _a1985, V _a1986, V _a1987, V[] _rest1983) => {
return Call(lipLick_1940, V.Undef, t_1988);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis1997, int _argc1990, V t_1996, V _a1993, V _a1994, V _a1995, V[] _rest1991) => {
Invoke(Invoke(Invoke(t_1996, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hug", ((V)((-0.7)))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("hug", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(hop_1944, V.Undef, t_1996, ((V)(6D)), NewObj(2).Put("air", NewObj(1).Put("slip", ((V)(0.4))).V).Put("fall", NewObj(1).Put("slip", ((V)(0D))).V).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2005, int _argc1998, V t_2004, V _a2001, V _a2002, V _a2003, V[] _rest1999) => {
Call(hearts_1941, V.Undef, t_2004, ((V)(2D)));
Invoke(Get(CARDS_1945, "frankie"), "yum", t_2004);
return default;
}, 1, "love", true)).V).Put("corny", NewObj(9).Put("chewMs", ((V)(115D))).Put("chewN", ((V)(0.9))).Put("crumbs", ((V)(2D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Quick crunchy nibbles, fizzing with excitement; her popcorn pops when she likes it."))).Put("pre", Fn((V _arrowThis2013, int _argc2006, V t_2012, V _a2009, V _a2010, V _a2011, V[] _rest2007) => {
Call(sniffF_1939, V.Undef, t_2012, ((V)(1D)));
Invoke(t_2012, "to", ((V)(150D)), NewObj(1).Put("cfz", ((V)(0.6))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2021, int _argc2014, V t_2020, V _a2017, V _a2018, V _a2019, V[] _rest2015) => {
return Invoke(t_2020, "to", ((V)(200D)), NewObj(1).Put("cfz", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2029, int _argc2022, V t_2028, V _a2025, V _a2026, V _a2027, V[] _rest2023) => {
Invoke(Invoke(Invoke(Invoke(t_2028, "to", ((V)(140D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("pop", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(3D))), "to", ((V)(380D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2037, int _argc2030, V t_2036, V _a2033, V _a2034, V _a2035, V[] _rest2031) => {
Call(hearts_1941, V.Undef, t_2036, ((V)(2D)));
Invoke(Get(CARDS_1945, "corny"), "yum", t_2036);
Call(hop_1944, V.Undef, t_2036, ((V)(6D)), NewObj(2).Put("air", NewObj(1).Put("pop", ((V)(0.8))).V).Put("fall", NewObj(1).Put("pop", ((V)(0D))).V).V);
return default;
}, 1, "love", true)).V).Put("peppi", NewObj(10).Put("savor", ((V)(0.5))).Put("chewMs", ((V)(140D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Lazy, cheesy bites (a string of cheese stretches), then a floppy happy sway."))).Put("pre", Fn((V _arrowThis2045, int _argc2038, V t_2044, V _a2041, V _a2042, V _a2043, V[] _rest2039) => {
return Call(sniffF_1939, V.Undef, t_2044, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2053, int _argc2046, V t_2052, V _a2049, V _a2050, V _a2051, V[] _rest2047) => {
return Invoke(Invoke(t_2052, "to", ((V)(200D)), NewObj(1).Put("pull", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("pull", ((V)(0D))).V, ((V)("i")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2061, int _argc2054, V t_2060, V _a2057, V _a2058, V _a2059, V[] _rest2055) => {
Invoke(t_2060, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(swing_1936, V.Undef, t_2060, ((V)(1100D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("flop", ((V)(0.6))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2069, int _argc2062, V t_2068, V _a2065, V _a2066, V _a2067, V[] _rest2063) => {
Call(hearts_1941, V.Undef, t_2068, ((V)(2D)));
Invoke(Invoke(t_2068, "to", ((V)(300D)), NewObj(2).Put("pull", ((V)(1D))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("pull", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i")));
Invoke(Get(CARDS_1945, "peppi"), "yum", t_2068);
return default;
}, 1, "love", true)).V).Put("nori", NewObj(9).Put("chewMs", ((V)(135D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("A polite little bow first, small neat bites, his salmon flakes hop when he likes it."))).Put("pre", Fn((V _arrowThis2077, int _argc2070, V t_2076, V _a2073, V _a2074, V _a2075, V[] _rest2071) => {
return Invoke(Invoke(t_2076, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.16)))).Put("close", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2085, int _argc2078, V t_2084, V _a2081, V _a2082, V _a2083, V[] _rest2079) => {
return Call(lipLick_1940, V.Undef, t_2084);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2093, int _argc2086, V t_2092, V _a2089, V _a2090, V _a2091, V[] _rest2087) => {
Invoke(Invoke(Invoke(Invoke(t_2092, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("ume", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(1).Put("ume", ((V)(0D))).V, ((V)("i")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2101, int _argc2094, V t_2100, V _a2097, V _a2098, V _a2099, V[] _rest2095) => {
Call(hearts_1941, V.Undef, t_2100, ((V)(2D)));
Invoke(t_2100, "to", ((V)(250D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
Invoke(Get(CARDS_1945, "nori"), "yum", t_2100);
return default;
}, 1, "love", true)).V).Put("sunny", NewObj(9).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(130D))).Put("crumbs", ((V)(1D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Lifts her shell cap first (manners!), soft bites, her yolk wobbles when she likes it."))).Put("pre", Fn((V _arrowThis2109, int _argc2102, V t_2108, V _a2105, V _a2106, V _a2107, V[] _rest2103) => {
return Invoke(Invoke(Invoke(t_2108, "to", ((V)(260D)), NewObj(1).Put("cap", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(260D)), NewObj(1).Put("cap", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2117, int _argc2110, V t_2116, V _a2113, V _a2114, V _a2115, V[] _rest2111) => {
return Call(lipLick_1940, V.Undef, t_2116);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2125, int _argc2118, V t_2124, V _a2121, V _a2122, V _a2123, V[] _rest2119) => {
Invoke(Invoke(Invoke(t_2124, "to", ((V)(300D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("cap", ((V)(0.7))).Put("wob", ((V)(1.2))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(2).Put("cap", ((V)(0D))).Put("wob", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2133, int _argc2126, V t_2132, V _a2129, V _a2130, V _a2131, V[] _rest2127) => {
Call(hearts_1941, V.Undef, t_2132, ((V)(2D)));
Call(hop_1944, V.Undef, t_2132, ((V)(6D)));
Invoke(Get(CARDS_1945, "sunny"), "yum", t_2132);
return default;
}, 1, "love", true)).V).Put("toco", NewObj(10).Put("chewMs", ((V)(110D))).Put("chewN", ((V)(0.9))).Put("crumbs", ((V)(3D))).Put("open", ((V)(0.9))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Opens his shell wide, big crunchy chomps (bits of lettuce fly), castanet snaps when he likes it."))).Put("pre", Fn((V _arrowThis2141, int _argc2134, V t_2140, V _a2137, V _a2138, V _a2139, V[] _rest2135) => {
return Invoke(Invoke(Invoke(t_2140, "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(150D))), "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2149, int _argc2142, V t_2148, V _a2145, V _a2146, V _a2147, V[] _rest2143) => {
return Call(pat_1942, V.Undef, t_2148, ((V)(1D)));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2157, int _argc2150, V t_2156, V _a2153, V _a2154, V _a2155, V[] _rest2151) => {
Invoke(t_2156, "to", ((V)(140D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
{
double i_2158 = 0;
i_2158 = 0D;
while (true) {
if (!((i_2158 < 2D))) break;
Invoke(Invoke(Invoke(t_2156, "to", ((V)(100D)), NewObj(1).Put("snap", ((V)((-0.5)))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(1).Put("snap", ((V)(0.5))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(1D)));
i_2158++;
}
}
Invoke(t_2156, "to", ((V)(150D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2167, int _argc2160, V t_2166, V _a2163, V _a2164, V _a2165, V[] _rest2161) => {
Call(hearts_1941, V.Undef, t_2166, ((V)(2D)));
Invoke(Get(CARDS_1945, "toco"), "yum", t_2166);
return default;
}, 1, "love", true)).V).Put("churro", NewObj(8).Put("chewMs", ((V)(120D))).Put("crumbs", ((V)(2D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Dips it first like a churro in chocolate, crunchy bites, twists happily when he likes it."))).Put("pre", Fn((V _arrowThis2175, int _argc2168, V t_2174, V _a2171, V _a2172, V _a2173, V[] _rest2169) => {
return Invoke(Invoke(Invoke(t_2174, "to", ((V)(320D)), NewObj(3).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.9))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0.07))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)(0D))).Put("ly", ((V)(0.3))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2183, int _argc2176, V t_2182, V _a2179, V _a2180, V _a2181, V[] _rest2177) => {
return Call(lipLick_1940, V.Undef, t_2182, (true ? V.True : V.False));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2191, int _argc2184, V t_2190, V _a2187, V _a2188, V _a2189, V[] _rest2185) => {
Invoke(Invoke(Invoke(Invoke(t_2190, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("cork", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sugar")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2199, int _argc2192, V t_2198, V _a2195, V _a2196, V _a2197, V[] _rest2193) => {
Call(hearts_1941, V.Undef, t_2198, ((V)(2D)));
Invoke(Get(CARDS_1945, "churro"), "yum", t_2198);
return default;
}, 1, "love", true)).V).Put("khinki", NewObj(9).Put("chewMs", ((V)(130D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.75))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("A careful first nibble and a slurp of the juice (the khinkali way), then big bites; his knot wags when he likes it."))).Put("pre", Fn((V _arrowThis2207, int _argc2200, V t_2206, V _a2203, V _a2204, V _a2205, V[] _rest2201) => {
Call(sniffF_1939, V.Undef, t_2206, ((V)(1D)));
Invoke(Invoke(Invoke(t_2206, "to", ((V)(200D)), NewObj(3).Put("open", ((V)(0.25))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2215, int _argc2208, V t_2214, V _a2211, V _a2212, V _a2213, V[] _rest2209) => {
return Call(lipLick_1940, V.Undef, t_2214);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2223, int _argc2216, V t_2222, V _a2219, V _a2220, V _a2221, V[] _rest2217) => {
Invoke(Invoke(Invoke(t_2222, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(3D)), NewObj(1).Put("knot", ((V)(0.6))).V, NewObj(1).Put("knot", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("knot", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2231, int _argc2224, V t_2230, V _a2227, V _a2228, V _a2229, V[] _rest2225) => {
Call(hearts_1941, V.Undef, t_2230, ((V)(2D)));
Invoke(t_2230, "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(2D)));
Invoke(Get(CARDS_1945, "khinki"), "yum", t_2230);
return default;
}, 1, "love", true)).V).Put("maki", NewObj(10).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(140D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Calm, careful bites with his eyes closed; his salmon and veggies pop up when he likes it."))).Put("pre", Fn((V _arrowThis2239, int _argc2232, V t_2238, V _a2235, V _a2236, V _a2237, V[] _rest2233) => {
return Invoke(Invoke(Invoke(t_2238, "to", ((V)(260D)), NewObj(1).Put("close", ((V)(0.7))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2247, int _argc2240, V t_2246, V _a2243, V _a2244, V _a2245, V[] _rest2241) => {
return Call(lipLick_1940, V.Undef, t_2246);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2255, int _argc2248, V t_2254, V _a2251, V _a2252, V _a2253, V[] _rest2249) => {
Invoke(Invoke(Invoke(t_2254, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("veg", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("veg", ((V)(0D))).V, ((V)("io")));
Call(swing_1936, V.Undef, t_2254, ((V)(1000D)), ((V)(3D)), NewObj(1).Put("tilt", ((V)(6D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2263, int _argc2256, V t_2262, V _a2259, V _a2260, V _a2261, V[] _rest2257) => {
Call(hearts_1941, V.Undef, t_2262, ((V)(2D)));
Invoke(Get(CARDS_1945, "maki"), "yum", t_2262);
return default;
}, 1, "love", true)).V).Put("noodle", NewObj(9).Put("chewMs", ((V)(125D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Blows on it (steam), slurps it up, his chopsticks bob happily."))).Put("pre", Fn((V _arrowThis2271, int _argc2264, V t_2270, V _a2267, V _a2268, V _a2269, V[] _rest2265) => {
return Invoke(Invoke(Invoke(Invoke(t_2270, "to", ((V)(250D)), NewObj(3).Put("puff", ((V)(0.6))).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(3).Put("puff", ((V)((-0.3)))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("mouth")), ((V)(2D))), "to", ((V)(260D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2279, int _argc2272, V t_2278, V _a2275, V _a2276, V _a2277, V[] _rest2273) => {
return Invoke(Invoke(t_2278, "to", ((V)(260D)), NewObj(1).Put("slurp", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("slurp", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2287, int _argc2280, V t_2286, V _a2283, V _a2284, V _a2285, V[] _rest2281) => {
Invoke(Invoke(Invoke(Invoke(t_2286, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(3D)), NewObj(1).Put("lid", ((V)(0.7))).V, NewObj(1).Put("lid", ((V)((-0.2)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("lid", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2295, int _argc2288, V t_2294, V _a2291, V _a2292, V _a2293, V[] _rest2289) => {
Call(hearts_1941, V.Undef, t_2294, ((V)(2D)));
Invoke(Get(CARDS_1945, "noodle"), "yum", t_2294);
return default;
}, 1, "love", true)).V).Put("flossie", NewObj(11).Put("savor", ((V)(0.7))).Put("chewMs", ((V)(150D))).Put("chewN", ((V)(1D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Dainty little bites, savours it dreamily, poofs up fluffy when she likes it."))).Put("pre", Fn((V _arrowThis2303, int _argc2296, V t_2302, V _a2299, V _a2300, V _a2301, V[] _rest2297) => {
return Call(sniffF_1939, V.Undef, t_2302, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2311, int _argc2304, V t_2310, V _a2307, V _a2308, V _a2309, V[] _rest2305) => {
return Invoke(Invoke(Invoke(t_2310, "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0.6))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(250D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2319, int _argc2312, V t_2318, V _a2315, V _a2316, V _a2317, V[] _rest2313) => {
Invoke(Invoke(Invoke(t_2318, "to", ((V)(300D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("fluff", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(2D))), "to", ((V)(600D)), NewObj(1).Put("fluff", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _arrowThis2327, int _argc2320, V t_2326, V _a2323, V _a2324, V _a2325, V[] _rest2321) => {
Call(hearts_1941, V.Undef, t_2326, ((V)(2D)));
Invoke(t_2326, "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
Invoke(Get(CARDS_1945, "flossie"), "yum", t_2326);
return default;
}, 1, "love", true)).V).V;
Call(buildAll_1943, V.Undef, CARDS_1945);
return default;
}, 0, "boot", false)), V.Undef);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
