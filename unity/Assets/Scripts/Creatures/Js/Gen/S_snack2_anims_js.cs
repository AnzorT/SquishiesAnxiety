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
preset_10 = Fn((V _self1, int _argc11, V R_17, V _a14, V _a15, V _a16, V[] _rest12) => {
V P_18 = default;
P_18 = Get(R_17, "PRE");
if (Truthy(((!(Truthy(P_18)) ? V.True : V.False) is var _t19 && Truthy(_t19) ? _t19 : Get(P_18, "mustard")))) {
return default;
}
Object_assign(P_18, NewObj(8).Put("mustard", NewObj(8).Put("n", ((V)(5D))).Put("sp", ((V)(18D))).Put("vy", ((V)((-16D)))).Put("g", ((V)(70D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.7)), ((V)(1.2)))).Put("col", Arr(((V)("#ffd43b")), ((V)("#ffc21a")), ((V)("#ffe27a")))).Put("kind", ((V)("drop"))).V).Put("popk", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(26D))).Put("vy", ((V)((-30D)))).Put("g", ((V)(90D))).Put("life", ((V)(1100D))).Put("r", Arr(((V)(1.5)), ((V)(2.3)))).Put("col", Arr(((V)("#fffdf0")), ((V)("#ffeaa8")), ((V)("#fff3c4")))).Put("kind", ((V)("puff"))).V).Put("cheese", NewObj(8).Put("n", ((V)(5D))).Put("sp", ((V)(16D))).Put("vy", ((V)((-10D)))).Put("g", ((V)(80D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.8)), ((V)(1.3)))).Put("col", Arr(((V)("#ffd45c")), ((V)("#ffc63a")), ((V)("#ffe27a")))).Put("kind", ((V)("drop"))).V).Put("rice", NewObj(8).Put("n", ((V)(6D))).Put("sp", ((V)(18D))).Put("vy", ((V)((-14D)))).Put("g", ((V)(80D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.5)), ((V)(0.9)))).Put("col", Arr(((V)("#ffffff")), ((V)("#f6f2e8")))).Put("kind", ((V)("dot"))).V).Put("floss", NewObj(8).Put("n", ((V)(5D))).Put("sp", ((V)(14D))).Put("vy", ((V)((-10D)))).Put("g", ((V)(10D))).Put("life", ((V)(1500D))).Put("r", Arr(((V)(1.2)), ((V)(2.2)))).Put("col", Arr(((V)("#ffc6e2")), ((V)("#c4e6ff")), ((V)("#fff0f7")))).Put("kind", ((V)("puff"))).V).Put("broth", NewObj(8).Put("n", ((V)(5D))).Put("sp", ((V)(18D))).Put("vy", ((V)((-18D)))).Put("g", ((V)(80D))).Put("life", ((V)(800D))).Put("r", Arr(((V)(0.6)), ((V)(1.1)))).Put("col", Arr(((V)("#f0b25a")), ((V)("#ffd79a")))).Put("kind", ((V)("drop"))).V).Put("pepper", NewObj(8).Put("n", ((V)(6D))).Put("sp", ((V)(16D))).Put("vy", ((V)((-14D)))).Put("g", ((V)(70D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.4)), ((V)(0.7)))).Put("col", Arr(((V)("#3e3028")), ((V)("#5a4a3e")))).Put("kind", ((V)("dot"))).V).Put("lettuce", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(16D))).Put("vy", ((V)((-12D)))).Put("g", ((V)(60D))).Put("life", ((V)(1100D))).Put("r", Arr(((V)(1D)), ((V)(1.6)))).Put("col", Arr(((V)("#86d24e")), ((V)("#a8e870")))).Put("kind", ((V)("leaf"))).V).V);
return default;
}, 1, "", true);
Call(Named(boot_50 => Fn((V _self20, int _argc21, V _a23, V _a24, V _a25, V _a26, V[] _rest22) => {
V R_27 = default;
V TL_28 = default;
V hand_29 = default;
V both_30 = default;
V o_31 = default;
V NOHANDS_32 = default;
V jump_33 = default;
V shake_34 = default;
V swing_35 = default;
V steps_36 = default;
V jelly_37 = default;
V land_38 = default;
V install_39 = default;
V natF_40 = default;
V loopN_41 = default;
V eyes_42 = default;
V hopC_43 = default;
V yay_44 = default;
V calm_45 = default;
V spinR_46 = default;
V CARDS_47 = default;
V MOVES_48 = default;
V DANCES_49 = default;
if (_self20.IsNullish) _self20 = GlobalV;
R_27 = Get(G("window"), "RiveRig");
if (((((!(Truthy(R_27)) || !(Truthy(Get(R_27, "PETLIB")))) || !(Truthy(Get(Get(R_27, "PETLIB"), "install")))) || !(Truthy(Get(R_27, "SOFT")))) || !(Truthy(Get(R_27, "SNACKLIB"))))) {
Call(G("setTimeout"), V.Undef, boot_50.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_27, "snack2V"))) {
return default;
}
Set(R_27, "snack2V", ((V)(1D)));
Invoke(Object_keys(CH_8), "forEach", Fn((V _self20, int _argc51, V k_57, V _a54, V _a55, V _a56, V[] _rest52) => {
if (GetK(Get(R_27, "REST"), k_57).IsNullish) {
SetK(Get(R_27, "REST"), k_57, ((V)(0D)));
}
return default;
}, 1, "", true));
Call(preset_10, V.Undef, R_27);
{ V _t58 = Get(R_27, "PETLIB");
if (_t58.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t58));
{ V _t59 = Get(_t58, "TL");
TL_28 = _t59; }
{ V _t60 = Get(_t58, "hand");
hand_29 = _t60; }
{ V _t61 = Get(_t58, "both");
both_30 = _t61; }
{ V _t62 = Get(_t58, "o");
o_31 = _t62; }
{ V _t63 = Get(_t58, "NOHANDS");
NOHANDS_32 = _t63; }
{ V _t64 = Get(_t58, "jump");
jump_33 = _t64; }
{ V _t65 = Get(_t58, "shake");
shake_34 = _t65; }
{ V _t66 = Get(_t58, "swing");
swing_35 = _t66; }
{ V _t67 = Get(_t58, "steps");
steps_36 = _t67; }
{ V _t68 = Get(_t58, "jelly");
jelly_37 = _t68; }
{ V _t69 = Get(_t58, "land");
land_38 = _t69; }
{ V _t70 = Get(_t58, "install");
install_39 = _t70; } }
natF_40 = Get(Get(R_27, "SNACKLIB"), "natF");
Invoke(KEYS_9, "forEach", Fn((V _self20, int _argc71, V k_77, V _a74, V _a75, V _a76, V[] _rest72) => {
return Invoke(Get(R_27, "SOFT"), "add", k_77);
}, 1, "", true));
if (Truthy(Get(Get(R_27, "SNACKLIB"), "KEYS"))) {
Invoke(KEYS_9, "forEach", Fn((V _self20, int _argc78, V k_84, V _a81, V _a82, V _a83, V[] _rest79) => {
if (!(Truthy(Invoke(Get(Get(R_27, "SNACKLIB"), "KEYS"), "includes", k_84)))) {
Invoke(Get(Get(R_27, "SNACKLIB"), "KEYS"), "push", k_84);
}
return default;
}, 1, "", true));
}
loopN_41 = Fn((V _self20, int _argc85, V t_91, V n_92, V _a89, V _a90, V[] _rest86) => {
return Object_assign(Invoke(t_91, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_91, "t")) * ToNum((n_92 is var _t93 && Truthy(_t93) ? _t93 : ((V)(3D)))))))).V);
}, 2, "", true);
eyes_42 = Fn((V _self20, int _argc94, V t_100, V d_101, V _a98, V _a99, V[] _rest95) => {
return Invoke(Invoke(t_100, "to", ((V)(110D)), NewObj(1).Put("lx", ((V)((ToNum(d_101) * 0.9)))).V, ((V)("o"))), "e", ((V)("blink")));
}, 2, "", true);
hopC_43 = Fn((V _self20, int _argc102, V t_108, V h_109, V x_110, V _a107, V[] _rest103) => {
return Call(jump_33, V.Undef, t_108, Call(o_31, V.Undef, NewObj(5).Put("h", (h_109 is var _t111 && Truthy(_t111) ? _t111 : ((V)(7D)))).Put("ant", ((V)(150D))).Put("up", ((V)(210D))).Put("c", ((V)(0.16))).Put("arm", ((V)(46D))).V, (x_110 is var _t112 && Truthy(_t112) ? _t112 : NewObj(0).V)));
}, 3, "", true);
yay_44 = Fn((V _self20, int _argc113, V t_119, V d_120, V _a117, V _a118, V[] _rest114) => {
return Invoke(t_119, "to", (d_120 is var _t121 && Truthy(_t121) ? _t121 : ((V)(260D))), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("io")));
}, 2, "", true);
calm_45 = Fn((V _self20, int _argc122, V t_128, V _a125, V _a126, V _a127, V[] _rest123) => {
return Invoke(t_128, "to", ((V)(300D)), NewObj(9).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).Put("wide", ((V)(0D))).Put("mw", ((V)(1D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hyaw", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
spinR_46 = Fn((V _self20, int _argc129, V t_135, V dur_136, V deg_137, V x_138, V[] _rest130) => {
V a_139 = default;
a_139 = Get(t_135, "t");
Invoke(Invoke(t_135, "to", dur_136, Call(o_31, V.Undef, NewObj(1).Put("spin", deg_137).V, (x_138 is var _t140 && Truthy(_t140) ? _t140 : NewObj(0).V)), ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
return a_139;
return default;
}, 4, "", true);
CARDS_47 = NewObj(11).Put("frankie", NewObj(3).Put("T", ((V)(0.95))).Put("b", ((V)(1.1))).Put("s", ((V)(1.05))).V).Put("corny", NewObj(3).Put("T", ((V)(0.9))).Put("b", ((V)(1.15))).Put("s", ((V)(1D))).V).Put("peppi", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1D))).Put("s", ((V)(1.15))).V).Put("nori", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1.05))).Put("s", ((V)(0.95))).V).Put("sunny", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1.3))).Put("s", ((V)(1.05))).V).Put("toco", NewObj(3).Put("T", ((V)(0.9))).Put("b", ((V)(1.15))).Put("s", ((V)(1D))).V).Put("churro", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(0.95))).Put("s", ((V)(1.1))).V).Put("khinki", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(1.15))).Put("s", ((V)(1D))).V).Put("maki", NewObj(3).Put("T", ((V)(0.95))).Put("b", ((V)(1D))).Put("s", ((V)(1D))).V).Put("noodle", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(1.05))).Put("s", ((V)(1.05))).V).Put("flossie", NewObj(3).Put("T", ((V)(1.1))).Put("b", ((V)(1.25))).Put("s", ((V)(1.2))).V).V;
MOVES_48 = NewObj(11).Put("frankie", NewObj(6).Put("happy", Arr(Call(Fn((V _self20, int _argc141, V _a143, V _a144, V _a145, V _a146, V[] _rest142) => {
V t_147 = default;
t_147 = Call(TL_28, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(t_147, "to", ((V)(260D)), NewObj(4).Put("hug", ((V)((-0.7)))).Put("sq", ((V)(0.06))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("hug", ((V)(0.4))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(3D))), "to", ((V)(200D)), NewObj(1).Put("hug", ((V)(0D))).V, ((V)("io")));
Call(hopC_43, V.Undef, t_147, ((V)(7D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("slip", ((V)(0.35))).V).Put("fall", NewObj(1).Put("slip", ((V)(0D))).V).V);
Call(land_38, V.Undef, t_147, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
Call(hopC_43, V.Undef, t_147, ((V)(8D)), NewObj(2).Put("air", NewObj(1).Put("slip", ((V)((-0.35)))).V).Put("fall", NewObj(1).Put("slip", ((V)(0D))).V).V);
return Call(loopN_41, V.Undef, Invoke(t_147, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Gives his sausage a big bun hug (a squirt of mustard), then hops so it slides back and forth.")))).Put("surprised", Arr(Call(Fn((V _self20, int _argc148, V _a150, V _a151, V _a152, V _a153, V[] _rest149) => {
V t_154 = default;
t_154 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_154, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(6).Put("slip", ((V)(1.1))).Put("x", ((V)((-2D)))).Put("tilt", ((V)((-4D)))).Put("sq", ((V)((-0.06)))).Put("armL", ((V)(40D))).Put("armR", ((V)(60D))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0.9))).Put("hyaw", ((V)(0.22))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_154, "to", ((V)(320D)), Call(o_31, V.Undef, Call(hand_29, V.Undef, ((V)(1D)), ((V)(6D)), ((V)((-6D)))), NewObj(3).Put("armR", ((V)(60D))).Put("slip", ((V)(0.25))).Put("sq", ((V)(0D))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(3).Put("slip", ((V)(0D))).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(2D))), "to", ((V)(320D)), Call(o_31, V.Undef, NOHANDS_32, NewObj(9).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io"))), "wait", ((V)(250D)));
return Invoke(Invoke(t_154, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His sausage shoots out of the bun - he stares at it, pushes it back in with a paw, phew.")))).Put("squish", Arr(Call(Fn((V _self20, int _argc155, V _a157, V _a158, V _a159, V _a160, V[] _rest156) => {
V t_161 = default;
t_161 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(t_161, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.42))).Put("hug", ((V)((-1D)))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(Invoke(t_161, "to", ((V)(140D)), NewObj(6).Put("sq", ((V)((-0.16)))).Put("hug", ((V)(0.6))).Put("slip", ((V)(0.4))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(3D)));
Call(jelly_37, V.Undef, t_161, ((V)(0.5)), ((V)(3D)), ((V)(260D)), ((V)("slip")));
Call(jelly_37, V.Undef, t_161, ((V)(0.06)), ((V)(2D)), ((V)(240D)));
Invoke(t_161, "to", ((V)(260D)), NewObj(5).Put("hug", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_41, V.Undef, t_161);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("The bun squeezes the sausage, then it springs back and the sausage wobbles.")))).Put("quirk", Arr(Call(Fn((V _self20, int _argc162, V _a164, V _a165, V _a166, V _a167, V[] _rest163) => {
V t_168 = default;
t_168 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(t_168, "to", ((V)(300D)), NewObj(3).Put("hug", ((V)(1D))).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.7))).V, ((V)("io"))), "wait", ((V)(450D))), "e", ((V)("blink")));
Invoke(Invoke(Invoke(t_168, "to", ((V)(260D)), NewObj(6).Put("hug", ((V)((-0.7)))).Put("sq", ((V)(0.06))).Put("close", ((V)(0.7))).Put("smile", ((V)(1D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(2).Put("x", ((V)(0.6))).Put("slip", ((V)(0.12))).V, NewObj(2).Put("x", ((V)((-0.6)))).Put("slip", ((V)((-0.12)))).V, ((V)("s"))), "to", ((V)(400D)), NewObj(10).Put("hug", ((V)(0D))).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("x", ((V)(0D))).Put("slip", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_168, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Snug check")), ((V)("Opens his bun to check on his sausage, then hugs it snug and rocks it.")))).Put("press", NewObj(1).Put("hug", ((V)((-0.6)))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.08)), ((V)("io"))), Arr(((V)(400D)), ((V)((-0.03))), ((V)("io"))), Arr(((V)(560D)), ((V)(0D)), ((V)("io"))))).Put("slip", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(130D)), ((V)(0.5)), ((V)("o"))), Arr(((V)(420D)), ((V)((-0.2))), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("mustard")), ((V)("head")), ((V)(3D))))).V).V).Put("corny", NewObj(6).Put("happy", Arr(Call(Fn((V _self20, int _argc169, V _a171, V _a172, V _a173, V _a174, V[] _rest170) => {
V t_175 = default;
t_175 = Call(TL_28, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(t_175, "to", ((V)(200D)), NewObj(1).Put("cfz", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(150D)), NewObj(3).Put("pop", ((V)(1.1))).Put("sq", ((V)((-0.08)))).Put("cfz", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(3D))), "to", ((V)(420D)), NewObj(3).Put("pop", ((V)(0D))).Put("sq", ((V)(0D))).Put("cfz", ((V)(0D))).V, ((V)("i")));
Call(hopC_43, V.Undef, t_175, ((V)(7D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("pop", ((V)(0.6))).V).Put("fall", NewObj(1).Put("pop", ((V)(0D))).V).V);
Call(land_38, V.Undef, t_175, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
Call(hopC_43, V.Undef, t_175, ((V)(8D)), NewObj(3).Put("air", NewObj(1).Put("pop", ((V)(0.9))).V).Put("fall", NewObj(1).Put("pop", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(2D))))).V);
return Call(loopN_41, V.Undef, Invoke(t_175, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Fizzes with excitement, her popcorn pops up, then bouncy hops that toss the kernels.")))).Put("surprised", Arr(Call(Fn((V _self20, int _argc176, V _a178, V _a179, V _a180, V _a181, V[] _rest177) => {
V t_182 = default;
t_182 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_182, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(8).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.6))).Put("pop", ((V)(1.5))).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(3D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(6D))), "to", ((V)(520D)), NewObj(3).Put("pop", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_182, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.14)))).Put("ly", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(9).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_182, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Every kernel pops at once - then she peeks into her bucket to check they all came back.")))).Put("squish", Arr(Call(Fn((V _self20, int _argc183, V _a185, V _a186, V _a187, V _a188, V[] _rest184) => {
V t_189 = default;
t_189 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(t_189, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(5).Put("sq", ((V)(0.4))).Put("pop", ((V)(0.4))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(Invoke(Invoke(t_189, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.16)))).Put("pop", ((V)(1.2))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(3D))), "to", ((V)(420D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
Call(jelly_37, V.Undef, t_189, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_189, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_41, V.Undef, t_189);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed down, then she springs back and her popcorn pops up and rains back in.")))).Put("quirk", Arr(Call(Fn((V _self20, int _argc190, V _a192, V _a193, V _a194, V _a195, V[] _rest191) => {
V t_196 = default;
t_196 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_196, "to", ((V)(320D)), NewObj(3).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.8)))).Put("pitch", ((V)(0.06))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(160D)), NewObj(2).Put("armR", ((V)(140D))).Put("pop", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_196, "to", ((V)(300D)), Call(o_31, V.Undef, Call(hand_29, V.Undef, ((V)(1D)), ((V)(12D)), ((V)((-15D)))), NewObj(4).Put("armR", ((V)(22D))).Put("ly", ((V)(0.2))).Put("pitch", ((V)(0D))).Put("open", ((V)(0.4))).V), ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("open", ((V)(0D))).V, ((V)("o"))), "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("puff", ((V)(0.35))).V, NewObj(1).Put("puff", ((V)(0D))).V, ((V)("l"))), "e", ((V)("emit")), ((V)("crumb")), ((V)("mouth")), ((V)(2D))), "to", ((V)(300D)), Call(o_31, V.Undef, NOHANDS_32, NewObj(5).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("cfz", ((V)(0.6))).V), ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(1).Put("cfz", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_196, "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Snack break")), ((V)("Reaches up, takes one of her own kernels and munches it, fizzing with joy.")))).Put("press", NewObj(2).Put("pop", ((V)(0.4))).Put("cfz", ((V)(0.6))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(240D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(390D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(520D)), ((V)(0D)), ((V)("io"))))).Put("pop", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)(1.1)), ((V)("o"))), Arr(((V)(560D)), ((V)(0D)), ((V)("i"))))).Put("cfz", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("popk")), ((V)("head")), ((V)(4D))))).V).V).Put("peppi", NewObj(6).Put("happy", Arr(Call(Fn((V _self20, int _argc197, V _a199, V _a200, V _a201, V _a202, V[] _rest198) => {
V t_203 = default;
t_203 = Call(TL_28, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(t_203, "to", ((V)(420D)), NewObj(5).Put("pull", ((V)(1D))).Put("lift", ((V)(2.5))).Put("sq", ((V)((-0.06)))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(220D)), NewObj(5).Put("pull", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("cheese")), ((V)("head")), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(swing_35, V.Undef, t_203, ((V)(1300D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(6D))).Put("flop", ((V)(0.6))).Put("x", ((V)(1.2))).V, ((V)("io")));
return Call(loopN_41, V.Undef, Invoke(t_203, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A big cheesy stretch (the strings pull from his crust), then a lazy sway that flops his tip.")))).Put("surprised", Arr(Call(Fn((V _self20, int _argc204, V _a206, V _a207, V _a208, V _a209, V[] _rest205) => {
V t_210 = default;
t_210 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_210, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(3).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(5).Put("flop", ((V)((-1D)))).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(3D))).Put("armL", ((V)(55D))).Put("armR", ((V)(55D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(3).Put("flop", ((V)(0.8))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).Put("flop", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("flop", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_210, "to", ((V)(300D)), NewObj(2).Put("ly", ((V)(0.8))).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(9).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_210, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Jumps - his tip flaps back and forth like a floppy slice - then checks it.")))).Put("squish", Arr(Call(Fn((V _self20, int _argc211, V _a213, V _a214, V _a215, V _a216, V[] _rest212) => {
V t_217 = default;
t_217 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_217, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(6).Put("sq", ((V)(0.4))).Put("flop", ((V)(0.9))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("pull", ((V)(0.5))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("cheese")), ((V)("body")), ((V)(3D))), "wait", ((V)(250D)));
Invoke(t_217, "to", ((V)(120D)), NewObj(6).Put("sq", ((V)((-0.15)))).Put("flop", ((V)((-0.5)))).Put("pull", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_37, V.Undef, t_217, ((V)(0.7)), ((V)(3D)), ((V)(280D)), ((V)("flop")));
Invoke(t_217, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_41, V.Undef, t_217);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, his tip flops and the cheese stretches; it all wobbles back.")))).Put("quirk", Arr(Call(Fn((V _self20, int _argc218, V _a220, V _a221, V _a222, V _a223, V[] _rest219) => {
V t_224 = default;
t_224 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_224, "to", ((V)(900D)), NewObj(3).Put("flop", ((V)(1D))).Put("sq", ((V)(0.03))).Put("close", ((V)(0.4))).V, ((V)("i"))), "wait", ((V)(300D))), "e", ((V)("blink"))), "to", ((V)(200D)), NewObj(2).Put("wide", ((V)(0.6))).Put("close", ((V)(0D))).V, ((V)("o")));
Invoke(Invoke(Invoke(Invoke(t_224, "to", ((V)(200D)), NewObj(2).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.06))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(3).Put("armL", ((V)(145D))).Put("armR", ((V)(145D))).Put("flop", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).Put("flop", ((V)((-0.15)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(9).Put("flop", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wide", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_224, "wait", ((V)(250D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Floppy tip")), ((V)("His tip slowly droops over his head - he looks up and props it back up with both paws.")))).Put("press", NewObj(2).Put("flop", ((V)(0.5))).Put("pull", ((V)(0.3))).V).Put("rel", NewObj(2).Put("dur", ((V)(1100D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(260D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(420D)), ((V)(0D)), ((V)("io"))))).Put("flop", Arr(Arr(((V)(0D)), ((V)(0.5))), Arr(((V)(160D)), ((V)((-0.6))), ((V)("o"))), Arr(((V)(380D)), ((V)(0.35)), ((V)("io"))), Arr(((V)(600D)), ((V)((-0.12))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))).Put("pull", Arr(Arr(((V)(0D)), ((V)(0.3))), Arr(((V)(300D)), ((V)(0D)), ((V)("io"))))).V).V).V).Put("nori", NewObj(6).Put("happy", Arr(Call(Fn((V _self20, int _argc225, V _a227, V _a228, V _a229, V _a230, V[] _rest226) => {
V t_231 = default;
t_231 = Call(TL_28, V.Undef, NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V);
Invoke(Invoke(Invoke(Invoke(t_231, "to", ((V)(320D)), NewObj(3).Put("pitch", ((V)((-0.2)))).Put("sq", ((V)(0.04))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)(0.04))).Put("sq", ((V)((-0.04)))).Put("close", ((V)(0D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_231, "to", ((V)(150D)), NewObj(2).Put("ume", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(1).Put("ume", ((V)(0D))).V, ((V)("i")));
Call(hopC_43, V.Undef, t_231, ((V)(6D)));
return Call(loopN_41, V.Undef, Invoke(t_231, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A polite little bow, the salmon flakes on his head hop up, then a neat little hop.")))).Put("surprised", Arr(Call(Fn((V _self20, int _argc232, V _a234, V _a235, V _a236, V _a237, V[] _rest233) => {
V t_238 = default;
t_238 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_238, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(3).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("nwr", ((V)(1D))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_238, "to", ((V)(250D)), NewObj(3).Put("ly", ((V)(0.9))).Put("pitch", ((V)((-0.12)))).Put("blush", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(320D)), Call(o_31, V.Undef, Call(both_30, V.Undef, ((V)(4D)), ((V)(4D))), NewObj(2).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V), ((V)("io"))), "to", ((V)(300D)), Call(o_31, V.Undef, Call(both_30, V.Undef, ((V)(4D)), ((V)((-2D)))), NewObj(3).Put("nwr", ((V)(0D))).Put("armL", ((V)(35D))).Put("armR", ((V)(35D))).V), ((V)("io"))), "to", ((V)(300D)), Call(o_31, V.Undef, NOHANDS_32, NewObj(9).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("blush", ((V)(0.3))).Put("smile", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_238, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His seaweed jacket slips down - he blushes and tugs it back up neatly.")))).Put("squish", Arr(Call(Fn((V _self20, int _argc239, V _a241, V _a242, V _a243, V _a244, V[] _rest240) => {
V t_245 = default;
t_245 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_245, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.4))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(4D))), "wait", ((V)(250D)));
Invoke(Invoke(t_245, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("ume", ((V)(0.7))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("ume", ((V)(0D))).V, ((V)("i")));
Call(jelly_37, V.Undef, t_245, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_245, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_41, V.Undef, t_245);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, a few rice grains fly, he springs back and his salmon flakes bob.")))).Put("quirk", Arr(Call(Fn((V _self20, int _argc246, V _a248, V _a249, V _a250, V _a251, V[] _rest247) => {
V t_252 = default;
t_252 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_252, "to", ((V)(300D)), Call(o_31, V.Undef, Call(both_30, V.Undef, ((V)(3D)), ((V)(6D))), NewObj(4).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).Put("ly", ((V)(0.7))).Put("pitch", ((V)((-0.08)))).V), ((V)("io"))), "osc", ((V)(800D)), ((V)(2D)), NewObj(1).Put("nwr", ((V)(0.6))).V, NewObj(1).Put("nwr", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("nwr", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_31, V.Undef, NOHANDS_32, NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_252, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Jacket tug")), ((V)("Straightens his seaweed jacket with both paws, smooths it and gives a neat nod.")))).Put("press", NewObj(1).Put("nwr", ((V)(0.3))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(4).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(400D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(540D)), ((V)(0D)), ((V)("io"))))).Put("ume", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(120D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(400D)), ((V)(0D)), ((V)("i"))))).Put("nwr", Arr(Arr(((V)(0D)), ((V)(0.3))), Arr(((V)(300D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("rice")), ((V)("body")), ((V)(3D))))).V).V).Put("sunny", NewObj(6).Put("happy", Arr(Call(Fn((V _self20, int _argc253, V _a255, V _a256, V _a257, V _a258, V[] _rest254) => {
V t_259 = default;
t_259 = Call(TL_28, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(t_259, "to", ((V)(320D)), NewObj(2).Put("cap", ((V)(0.8))).Put("armR", ((V)(120D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("wob", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(260D)), NewObj(2).Put("cap", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("wob", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_259, "osc", ((V)(900D)), ((V)(2D)), NewObj(2).Put("rl", ((V)((-14D)))).Put("x", ((V)((-4D)))).V, NewObj(2).Put("rl", ((V)(14D))).Put("x", ((V)(4D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Call(jump_33, V.Undef, t_259, NewObj(8).Put("h", ((V)(10D))).Put("ant", ((V)(160D))).Put("up", ((V)(250D))).Put("c", ((V)(0.16))).Put("arm", ((V)(50D))).Put("air", NewObj(1).Put("rl", ((V)(180D))).V).Put("fall", NewObj(1).Put("rl", ((V)(360D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))))).V);
Invoke(t_259, "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l")));
Call(land_38, V.Undef, t_259, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
return Call(loopN_41, V.Undef, Invoke(t_259, "rest", ((V)(300D))), ((V)(2D)));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Tips her shell cap like a hat (her runny yolk wobbles), rocks on her round bottom, then a happy little somersault.")))).Put("surprised", Arr(Call(Fn((V _self20, int _argc260, V _a262, V _a263, V _a264, V _a265, V[] _rest261) => {
V t_266 = default;
t_266 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_266, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("cap", ((V)(1.1))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("wob", ((V)(1.3))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(320D)), NewObj(2).Put("cap", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0D))).Put("wob", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_266, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_266, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Her shell cap pops right off in surprise, the yolk jiggles, and it drops back on.")))).Put("squish", Arr(Call(Fn((V _self20, int _argc267, V _a269, V _a270, V _a271, V _a272, V[] _rest268) => {
V t_273 = default;
t_273 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(t_273, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.36))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(Invoke(t_273, "to", ((V)(140D)), NewObj(6).Put("sq", ((V)((-0.12)))).Put("cap", ((V)(0.7))).Put("wob", ((V)(1.5))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("cap", ((V)(0D))).V, ((V)("i")));
Call(jelly_37, V.Undef, t_273, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_273, "to", ((V)(400D)), NewObj(5).Put("wob", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_41, V.Undef, t_273);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed down flat - her cap pops up and the yolk wobbles - then she springs back.")))).Put("quirk", Arr(Call(Fn((V _self20, int _argc274, V _a276, V _a277, V _a278, V _a279, V[] _rest275) => {
V t_280 = default;
t_280 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_280, "to", ((V)(400D)), NewObj(5).Put("cap", ((V)(0.75))).Put("armR", ((V)(140D))).Put("htilt", ((V)((-4D)))).Put("close", ((V)(0.4))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(250D)), NewObj(1).Put("wob", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("pitch", ((V)((-0.12)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(360D)), NewObj(6).Put("cap", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("close", ((V)(0D))).Put("wob", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_280, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Hat tip")), ((V)("Lifts her shell cap like a hat and gives a little bow, her runny yolk peeking out.")))).Put("press", NewObj(1).Put("cap", ((V)(0.3))).V).Put("rel", NewObj(2).Put("dur", ((V)(1100D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(260D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(420D)), ((V)(0D)), ((V)("io"))))).Put("cap", Arr(Arr(((V)(0D)), ((V)(0.3))), Arr(((V)(120D)), ((V)(0.9)), ((V)("o"))), Arr(((V)(600D)), ((V)(0D)), ((V)("i"))))).Put("wob", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1.2)), ((V)("o"))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).V).V).Put("toco", NewObj(6).Put("happy", Arr(Call(Fn((V _self20, int _argc281, V _a283, V _a284, V _a285, V _a286, V[] _rest282) => {
V t_287 = default;
t_287 = Call(TL_28, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
{
V i_288 = default;
i_288 = ((V)(0D));
while (true) {
if (!(LtN(i_288, 2D))) break;
Invoke(Invoke(Invoke(t_287, "to", ((V)(120D)), NewObj(2).Put("snap", ((V)((-0.7)))).Put("sq", ((V)(0.04))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("snap", ((V)(0.6))).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(1D)));
PostInc(ref i_288, 1D);
}
}
Invoke(t_287, "to", ((V)(200D)), NewObj(2).Put("snap", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(hopC_43, V.Undef, t_287, ((V)(7D)), NewObj(2).Put("air", NewObj(1).Put("snap", ((V)(0.5))).V).Put("fall", NewObj(1).Put("snap", ((V)(0D))).V).V);
return Call(loopN_41, V.Undef, Invoke(t_287, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Snaps his shell open and shut like happy chomps, lettuce flies, then a hop.")))).Put("surprised", Arr(Call(Fn((V _self20, int _argc290, V _a292, V _a293, V _a294, V _a295, V[] _rest291) => {
V t_296 = default;
t_296 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_296, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(4).Put("snap", ((V)((-0.8)))).Put("wide", ((V)(1D))).Put("open", ((V)(0.4))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(260D)), NewObj(2).Put("snap", ((V)(0.8))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("snap", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_296, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(5).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_296, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Snaps shut with a crunch, then pops back open and lettuce flies.")))).Put("squish", Arr(Call(Fn((V _self20, int _argc297, V _a299, V _a300, V _a301, V _a302, V[] _rest298) => {
V t_303 = default;
t_303 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_303, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.4))).Put("snap", ((V)(1.2))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(3D))), "wait", ((V)(250D)));
Invoke(Invoke(t_303, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("snap", ((V)((-0.5)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
Call(jelly_37, V.Undef, t_303, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_303, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_41, V.Undef, t_303);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Pressed down, his shell bursts open (lettuce flies), then snaps back.")))).Put("quirk", Arr(Call(Fn((V _self20, int _argc304, V _a306, V _a307, V _a308, V _a309, V[] _rest305) => {
V t_310 = default;
t_310 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_310, "to", ((V)(260D)), NewObj(1).Put("snap", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(3).Put("armR", ((V)(140D))).Put("ly", ((V)((-0.7)))).Put("pitch", ((V)(0.05))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).Put("armR", ((V)(126D))).V, NewObj(1).Put("armR", ((V)(140D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_310, "to", ((V)(160D)), NewObj(1).Put("snap", ((V)((-0.3)))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(5).Put("snap", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_310, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Filling fix")), ((V)("Opens up, tucks a stray lettuce leaf back in, snaps shut - perfect.")))).Put("press", NewObj(1).Put("snap", ((V)((-0.5)))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(240D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).Put("snap", Arr(Arr(((V)(0D)), ((V)((-0.5)))), Arr(((V)(120D)), ((V)(0.9)), ((V)("o"))), Arr(((V)(360D)), ((V)((-0.25))), ((V)("io"))), Arr(((V)(600D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("lettuce")), ((V)("head")), ((V)(2D))))).V).V).Put("churro", NewObj(6).Put("happy", Arr(Call(Fn((V _self20, int _argc311, V _a313, V _a314, V _a315, V _a316, V[] _rest312) => {
V t_317 = default;
t_317 = Call(TL_28, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(t_317, "to", ((V)(400D)), NewObj(3).Put("cork", ((V)(1D))).Put("lift", ((V)(1D))).Put("sq", ((V)((-0.06)))).V, ((V)("io"))), "to", ((V)(420D)), NewObj(1).Put("cork", ((V)((-1D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("cork", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sugar")), ((V)("head")), ((V)(3D)));
Call(hopC_43, V.Undef, t_317, ((V)(7D)));
return Call(loopN_41, V.Undef, Invoke(t_317, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Twists like a corkscrew one way then the other, sugar sparkles, then a hop.")))).Put("surprised", Arr(Call(Fn((V _self20, int _argc318, V _a320, V _a321, V _a322, V _a323, V[] _rest319) => {
V t_324 = default;
t_324 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_324, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(3).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)((-0.16)))).Put("lift", ((V)(3D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("sugar")), ((V)("body")), ((V)(5D))), "to", ((V)(250D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_324, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(8).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_324, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Stands up straight in surprise and sugar puffs off him.")))).Put("squish", Arr(Call(Fn((V _self20, int _argc325, V _a327, V _a328, V _a329, V _a330, V[] _rest326) => {
V t_331 = default;
t_331 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_331, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.36))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sugar")), ((V)("body")), ((V)(4D))), "wait", ((V)(250D)));
Invoke(t_331, "to", ((V)(120D)), NewObj(4).Put("sq", ((V)((-0.14)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_37, V.Undef, t_331, ((V)(0.6)), ((V)(3D)), ((V)(280D)), ((V)("cork")));
Invoke(t_331, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_41, V.Undef, t_331);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("A crunchy squash, a puff of sugar, his ridges twist as he springs back.")))).Put("quirk", Arr(Call(Fn((V _self20, int _argc332, V _a334, V _a335, V _a336, V _a337, V[] _rest333) => {
V t_338 = default;
t_338 = Call(TL_28, V.Undef);
Call(shake_34, V.Undef, t_338, NewObj(6).Put("P", ((V)(90D))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(1D)), ((V)(0.7)), ((V)(0.35)))).Put("head", ((V)(0.08))).Put("roll", ((V)(3D))).Put("ear", ((V)(0D))).Put("body", ((V)(0.6))).V);
Invoke(t_338, "e", ((V)("emit")), ((V)("sugar")), ((V)("body")), ((V)(5D)));
Invoke(Invoke(t_338, "to", ((V)(300D)), NewObj(3).Put("cork", ((V)(0.4))).Put("close", ((V)(0.6))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("cork", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_338, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sugar shake")), ((V)("Shakes off the extra sugar like a dog after a bath, then a smug little twist.")))).Put("press", NewObj(1).Put("cork", ((V)(0.4))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(240D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).Put("cork", Arr(Arr(((V)(0D)), ((V)(0.4))), Arr(((V)(150D)), ((V)((-0.8))), ((V)("o"))), Arr(((V)(400D)), ((V)(0.4)), ((V)("io"))), Arr(((V)(650D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("sugar")), ((V)("head")), ((V)(3D))))).V).V).Put("khinki", NewObj(6).Put("happy", Arr(Call(Fn((V _self20, int _argc339, V _a341, V _a342, V _a343, V _a344, V[] _rest340) => {
V t_345 = default;
t_345 = Call(TL_28, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_345, "to", ((V)(220D)), NewObj(2).Put("knot", ((V)(0.8))).Put("kt", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("knot", ((V)((-0.7)))).Put("kt", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("knot", ((V)(0D))).Put("kt", ((V)(0D))).V, ((V)("io")));
Call(hopC_43, V.Undef, t_345, ((V)(7D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("knot", ((V)(0.4))).V).Put("fall", NewObj(1).Put("knot", ((V)(0D))).V).V);
Call(land_38, V.Undef, t_345, ((V)(0.08)), ((V)(2D)), ((V)(240D)));
Call(hopC_43, V.Undef, t_345, ((V)(7D)), NewObj(2).Put("air", NewObj(1).Put("knot", ((V)((-0.4)))).V).Put("fall", NewObj(1).Put("knot", ((V)(0D))).V).V);
return Call(loopN_41, V.Undef, Invoke(t_345, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Flicks his knot like a ponytail, then juicy little hops that make it bounce.")))).Put("surprised", Arr(Call(Fn((V _self20, int _argc346, V _a348, V _a349, V _a350, V _a351, V[] _rest347) => {
V t_352 = default;
t_352 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_352, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sq", ((V)((-0.12)))).Put("lift", ((V)(3D))).Put("kt", ((V)(0.8))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(4D))), "to", ((V)(240D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).Put("kt", ((V)((-0.3)))).V, ((V)("i"))), "to", ((V)(260D)), NewObj(2).Put("sq", ((V)(0D))).Put("kt", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_352, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_352, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Jumps - his pleats twist tight and a squirt of broth shoots out of his knot.")))).Put("squish", Arr(Call(Fn((V _self20, int _argc353, V _a355, V _a356, V _a357, V _a358, V[] _rest354) => {
V t_359 = default;
t_359 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_359, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.42))).Put("kt", ((V)(0.6))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(5D))), "wait", ((V)(250D)));
Invoke(t_359, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("kt", ((V)((-0.3)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_37, V.Undef, t_359, ((V)(0.09)), ((V)(3D)), ((V)(260D)));
Invoke(t_359, "to", ((V)(220D)), NewObj(5).Put("kt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_41, V.Undef, t_359);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, a juicy squirt of broth shoots out of his knot; a doughy wobble back.")))).Put("quirk", Arr(Call(Fn((V _self20, int _argc360, V _a362, V _a363, V _a364, V _a365, V[] _rest361) => {
V t_366 = default;
t_366 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_366, "to", ((V)(320D)), NewObj(3).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.8)))).Put("pitch", ((V)(0.06))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(2).Put("kt", ((V)(1D))).Put("knot", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(2).Put("kt", ((V)((-0.3)))).Put("knot", ((V)((-0.2)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("kt", ((V)(0D))).Put("knot", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("pepper")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(4).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_366, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Knot twirl")), ((V)("Reaches up and twirls his top knot neat (the pleats twist with it), a sprinkle of pepper falls.")))).Put("press", NewObj(1).Put("kt", ((V)(0.4))).V).Put("rel", NewObj(3).Put("dur", ((V)(1100D))).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.16))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.08)), ((V)("io"))), Arr(((V)(420D)), ((V)(0D)), ((V)("io"))))).Put("knot", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(0.8)), ((V)("o"))), Arr(((V)(400D)), ((V)((-0.4))), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).Put("kt", Arr(Arr(((V)(0D)), ((V)(0.4))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("broth")), ((V)("head")), ((V)(3D))))).V).V).Put("maki", NewObj(6).Put("happy", Arr(Call(Fn((V _self20, int _argc367, V _a369, V _a370, V _a371, V _a372, V[] _rest368) => {
V t_373 = default;
t_373 = Call(TL_28, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_373, "to", ((V)(160D)), NewObj(2).Put("veg", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(360D)), NewObj(2).Put("veg", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(spinR_46, V.Undef, t_373, ((V)(900D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V);
Invoke(t_373, "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(hopC_43, V.Undef, t_373, ((V)(6D)));
return Call(loopN_41, V.Undef, Invoke(t_373, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("His salmon and veggies pop up out of the rice, a quick spin like a top, then a hop.")))).Put("surprised", Arr(Call(Fn((V _self20, int _argc374, V _a376, V _a377, V _a378, V _a379, V[] _rest375) => {
V t_380 = default;
t_380 = Call(TL_28, V.Undef);
Invoke(Invoke(t_380, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("veg", ((V)(1.3))).V, ((V)("o")));
Call(hopC_43, V.Undef, t_380, ((V)(8D)), NewObj(1).Put("ant", ((V)(60D))).V);
Invoke(t_380, "to", ((V)(400D)), NewObj(1).Put("veg", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_380, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_380, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His salmon and veggies shoot up out of the rice and he jumps.")))).Put("squish", Arr(Call(Fn((V _self20, int _argc381, V _a383, V _a384, V _a385, V _a386, V[] _rest382) => {
V t_387 = default;
t_387 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_387, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.38))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("rice")), ((V)("head")), ((V)(4D))), "wait", ((V)(250D)));
Invoke(Invoke(t_387, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("veg", ((V)(0.9))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("veg", ((V)(0D))).V, ((V)("io")));
Call(jelly_37, V.Undef, t_387, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_387, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_41, V.Undef, t_387);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Pressed like rolling a mat, rice grains fly, his salmon and veggies pop up.")))).Put("quirk", Arr(Call(Fn((V _self20, int _argc388, V _a390, V _a391, V _a392, V _a393, V[] _rest389) => {
V t_394 = default;
t_394 = Call(TL_28, V.Undef);
Invoke(Invoke(t_394, "to", ((V)(400D)), NewObj(2).Put("close", ((V)(1D))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(200D)));
Call(spinR_46, V.Undef, t_394, ((V)(2600D)), ((V)(360D)), NewObj(1).Put("veg", ((V)(0.3))).V);
Invoke(t_394, "to", ((V)(300D)), NewObj(4).Put("veg", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_394, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Zen spin")), ((V)("Closes his eyes and turns slowly round like a spinning top, perfectly calm.")))).Put("press", NewObj(2).Put("sq", ((V)(0.05))).Put("veg", ((V)(0.3))).V).Put("rel", NewObj(3).Put("dur", ((V)(900D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.14))), ((V)("o"))), Arr(((V)(240D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).Put("veg", Arr(Arr(((V)(0D)), ((V)(0.3))), Arr(((V)(120D)), ((V)(1D)), ((V)("o"))), Arr(((V)(500D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("rice")), ((V)("head")), ((V)(3D))))).V).V).Put("noodle", NewObj(6).Put("happy", Arr(Call(Fn((V _self20, int _argc395, V _a397, V _a398, V _a399, V _a400, V[] _rest396) => {
V t_401 = default;
t_401 = Call(TL_28, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(t_401, "to", ((V)(300D)), NewObj(4).Put("slurp", ((V)(1D))).Put("puff", ((V)((-0.3)))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(250D)), NewObj(4).Put("slurp", ((V)(0D))).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).Put("mw", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D)));
Call(hopC_43, V.Undef, t_401, ((V)(7D)), NewObj(2).Put("air", NewObj(1).Put("lid", ((V)(0.8))).V).Put("fall", NewObj(1).Put("lid", ((V)(0D))).V).V);
return Call(loopN_41, V.Undef, Invoke(t_401, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Slurps up his noodles, a happy puff of steam, then a hop that lifts a pinch of noodles with his chopsticks.")))).Put("surprised", Arr(Call(Fn((V _self20, int _argc402, V _a404, V _a405, V _a406, V _a407, V[] _rest403) => {
V t_408 = default;
t_408 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_408, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("lid", ((V)((-1D)))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(3D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(5D))), "to", ((V)(250D)), NewObj(3).Put("lid", ((V)(1D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(2).Put("lid", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_408, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_408, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His chopsticks jump up out of the noodles and a burst of steam puffs out like a whistle.")))).Put("squish", Arr(Call(Fn((V _self20, int _argc409, V _a411, V _a412, V _a413, V _a414, V[] _rest410) => {
V t_415 = default;
t_415 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_415, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(5).Put("sq", ((V)(0.38))).Put("lid", ((V)(0.8))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(4D))), "wait", ((V)(250D)));
Invoke(Invoke(t_415, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("lid", ((V)((-0.4)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("lid", ((V)(0D))).V, ((V)("io")));
Call(jelly_37, V.Undef, t_415, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_415, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_41, V.Undef, t_415);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed, a splash of broth and his chopsticks bob, then he springs back.")))).Put("quirk", Arr(Call(Fn((V _self20, int _argc416, V _a418, V _a419, V _a420, V _a421, V[] _rest417) => {
V t_422 = default;
t_422 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_422, "to", ((V)(400D)), NewObj(3).Put("close", ((V)(1D))).Put("smile", ((V)(1D))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D))), "osc", ((V)(1600D)), ((V)(4D)), NewObj(1).Put("lid", ((V)(0.7))).V, NewObj(1).Put("lid", ((V)((-0.2)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(4).Put("lid", ((V)(0D))).Put("close", ((V)(0D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_422, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Steam sigh")), ((V)("Closes his eyes in a cosy cloud of steam while his chopsticks twirl up noodles.")))).Put("press", NewObj(1).Put("lid", ((V)(0.5))).V).Put("rel", NewObj(3).Put("dur", ((V)(1000D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.06)), ((V)("io"))), Arr(((V)(400D)), ((V)(0D)), ((V)("io"))))).Put("lid", Arr(Arr(((V)(0D)), ((V)(0.5))), Arr(((V)(150D)), ((V)((-0.6))), ((V)("o"))), Arr(((V)(400D)), ((V)(0.3)), ((V)("io"))), Arr(((V)(650D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("steam")), ((V)("head")), ((V)(4D))))).V).V).Put("flossie", NewObj(6).Put("happy", Arr(Call(Fn((V _self20, int _argc423, V _a425, V _a426, V _a427, V _a428, V[] _rest424) => {
V t_429 = default;
t_429 = Call(TL_28, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_429, "to", ((V)(300D)), NewObj(3).Put("fluff", ((V)(1.2))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(3D))), "to", ((V)(500D)), NewObj(3).Put("fluff", ((V)(0D))).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_429, "to", ((V)(1100D)), NewObj(1).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("l")));
Call(hopC_43, V.Undef, t_429, ((V)(6D)));
return Call(loopN_41, V.Undef, Invoke(t_429, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Poofs up big and fluffy, her floss swirls round her, then a soft hop.")))).Put("surprised", Arr(Call(Fn((V _self20, int _argc430, V _a432, V _a433, V _a434, V _a435, V[] _rest431) => {
V t_436 = default;
t_436 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_436, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("fluff", ((V)(1.6))).Put("sq", ((V)((-0.1)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(4D))), "wait", ((V)(300D))), "to", ((V)(900D)), NewObj(2).Put("fluff", ((V)(0D))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_436, "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("lx", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_436, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Poofs out huge in surprise, then slowly fluffs back down.")))).Put("squish", Arr(Call(Fn((V _self20, int _argc437, V _a439, V _a440, V _a441, V _a442, V[] _rest438) => {
V t_443 = default;
t_443 = Call(TL_28, V.Undef);
Invoke(Invoke(Invoke(t_443, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(4).Put("sq", ((V)(0.42))).Put("hap", ((V)(0.9))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(Invoke(Invoke(t_443, "to", ((V)(160D)), NewObj(5).Put("sq", ((V)((-0.16)))).Put("fluff", ((V)(1.3))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(4D))), "to", ((V)(500D)), NewObj(1).Put("fluff", ((V)(0D))).V, ((V)("io")));
Call(jelly_37, V.Undef, t_443, ((V)(0.08)), ((V)(3D)), ((V)(260D)));
Invoke(t_443, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_41, V.Undef, t_443);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squished down, then she poofs back out fluffier than before.")))).Put("quirk", Arr(Call(Fn((V _self20, int _argc444, V _a446, V _a447, V _a448, V _a449, V[] _rest445) => {
V t_450 = default;
V a_451 = default;
t_450 = Call(TL_28, V.Undef);
Invoke(t_450, "to", ((V)(700D)), NewObj(5).Put("lift", ((V)(6D))).Put("close", ((V)(1D))).Put("smile", ((V)(1D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("io")));
a_451 = Get(t_450, "t");
Invoke(t_450, "osc", ((V)(1800D)), ((V)(2D)), NewObj(1).Put("lift", ((V)(7.5))).V, NewObj(1).Put("lift", ((V)(5.5))).V, ((V)("s")));
Invoke(Invoke(Invoke(t_450, "at", a_451), "to", ((V)(1800D)), NewObj(1).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_450, "to", ((V)(800D)), NewObj(4).Put("lift", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_450, "wait", ((V)(300D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Cloud float")), ((V)("Closes her eyes and floats up like a little cloud, her floss drifting round, then sinks softly down.")))).Put("press", NewObj(1).Put("fluff", ((V)(0.5))).V).Put("rel", NewObj(3).Put("dur", ((V)(1200D))).Put("k", NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(100D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(420D)), ((V)(0D)), ((V)("io"))))).Put("fluff", Arr(Arr(((V)(0D)), ((V)(0.5))), Arr(((V)(160D)), ((V)(1.3)), ((V)("o"))), Arr(((V)(1200D)), ((V)(0D)), ((V)("io"))))).V).Put("em", Arr(Arr(((V)("floss")), ((V)("head")), ((V)(3D))))).V).V).V;
DANCES_49 = NewObj(11).Put("frankie", Arr(Call(Fn((V _self20, int _argc452, V _a454, V _a455, V _a456, V _a457, V[] _rest453) => {
V t_458 = default;
V B_459 = default;
V a_460 = default;
t_458 = Call(TL_28, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_459 = ((V)(500D));
Call(eyes_42, V.Undef, t_458, ((V)(1D)));
{
V i_461 = default;
i_461 = ((V)(0D));
while (true) {
if (!(LtN(i_461, 2D))) break;
Invoke(Invoke(t_458, "to", B_459, NewObj(5).Put("slip", ((V)(0.9))).Put("x", ((V)((-1.6)))).Put("tilt", ((V)((-3D)))).Put("armL", ((V)(30D))).Put("armR", ((V)((-6D)))).V, ((V)("io"))), "to", B_459, NewObj(5).Put("slip", ((V)((-0.9)))).Put("x", ((V)(1.6))).Put("tilt", ((V)(3D))).Put("armL", ((V)((-6D)))).Put("armR", ((V)(30D))).V, ((V)("io")));
PostInc(ref i_461, 1D);
}
}
Invoke(t_458, "to", ((V)((ToNum(B_459) * 0.6))), NewObj(6).Put("slip", ((V)(0D))).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io")));
{
V i_463 = default;
i_463 = ((V)(0D));
while (true) {
if (!(LtN(i_463, 3D))) break;
Invoke(Invoke(Invoke(t_458, "to", ((V)(150D)), NewObj(2).Put("hug", ((V)((-0.9)))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(2D))), "to", ((V)((ToNum(B_459) - 150D))), NewObj(2).Put("hug", ((V)(0.3))).Put("sq", ((V)((-0.03)))).V, ((V)("io")));
PostInc(ref i_463, 1D);
}
}
Invoke(t_458, "to", ((V)(200D)), NewObj(2).Put("hug", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
{
V i_465 = default;
i_465 = ((V)(0D));
while (true) {
if (!(LtN(i_465, 2D))) break;
Call(hopC_43, V.Undef, t_458, ((V)(8D)), NewObj(3).Put("chain", (LtN(i_465, 1D) ? V.True : V.False)).Put("air", NewObj(1).Put("slip", ((V)((Truthy(i_465) ? (-0.5) : 0.5)))).V).Put("fall", NewObj(1).Put("slip", ((V)(0D))).V).V);
PostInc(ref i_465, 1D);
}
}
a_460 = Call(spinR_46, V.Undef, t_458, ((V)(1300D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).V);
Invoke(Invoke(Invoke(t_458, "at", a_460), "to", ((V)(500D)), NewObj(1).Put("slip", ((V)((-0.7)))).V, ((V)("o"))), "to", ((V)(800D)), NewObj(1).Put("slip", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_458, "at", Add(a_460, ((V)(1301D)))), "to", ((V)(250D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_458, "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(4D))), "to", ((V)(160D)), NewObj(3).Put("hug", ((V)((-0.8)))).Put("sq", ((V)(0.1))).Put("lift", ((V)(0D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(3D))), "to", ((V)(400D)), NewObj(4).Put("hug", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D)));
return Invoke(Invoke(t_458, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Bun Hug Wiggle")), ((V)("His sausage slides side to side in the bun while he sways the other way, bun-hug beats squirt mustard, two hops it rides, a spin it trails behind, and a big mustard finale.")))).Put("corny", Arr(Call(Fn((V _self20, int _argc467, V _a469, V _a470, V _a471, V _a472, V[] _rest468) => {
V t_473 = default;
V B_474 = default;
V a_475 = default;
t_473 = Call(TL_28, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_474 = ((V)(460D));
{
V i_476 = default;
i_476 = ((V)(0D));
while (true) {
if (!(LtN(i_476, 4D))) break;
Invoke(Invoke(Invoke(t_473, "to", ((V)((ToNum(B_474) / 2D))), NewObj(5).Put("pop", ((V)(0.9))).Put("footL", ((V)((NumTruthy((ToNum(i_476) % 2D)) ? 0D : 2.4)))).Put("footR", ((V)((NumTruthy((ToNum(i_476) % 2D)) ? 2.4 : 0D)))).Put("x", ((V)((NumTruthy((ToNum(i_476) % 2D)) ? 1D : (-1D))))).Put("tilt", ((V)((NumTruthy((ToNum(i_476) % 2D)) ? 3D : (-3D))))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(1D))), "to", ((V)((ToNum(B_474) / 2D))), NewObj(3).Put("pop", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_476, 1D);
}
}
Invoke(Invoke(Invoke(t_473, "to", ((V)(200D)), NewObj(3).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("cfz", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(1300D)), ((V)(6D)), NewObj(3).Put("tilt", ((V)(4D))).Put("armL", ((V)(40D))).Put("armR", ((V)(10D))).V, NewObj(3).Put("tilt", ((V)((-4D)))).Put("armL", ((V)(10D))).Put("armR", ((V)(40D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(4).Put("cfz", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(jump_33, V.Undef, t_473, NewObj(8).Put("h", ((V)(13D))).Put("ant", ((V)(200D))).Put("up", ((V)(280D))).Put("c", ((V)(0.2))).Put("arm", ((V)(120D))).Put("air", NewObj(1).Put("pop", ((V)(1.5))).V).Put("fall", NewObj(1).Put("pop", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(6D))))).V);
a_475 = Call(spinR_46, V.Undef, t_473, ((V)(1200D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V);
Invoke(t_473, "at", a_475);
{
V i_478 = default;
i_478 = ((V)(0D));
while (true) {
if (!(LtN(i_478, 3D))) break;
Invoke(Invoke(t_473, "to", ((V)(200D)), NewObj(1).Put("pop", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_478, 1D);
}
}
Invoke(t_473, "at", Add(a_475, ((V)(1201D))));
Invoke(Invoke(Invoke(Invoke(t_473, "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("cfz", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(400D))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("cfz", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_473, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Popcorn Pop")), ((V)("Her kernels pop on every step, a fizzing shimmy, a big jump that pops them all at once, a spin with popcorn bouncing and a fizzy cheer.")))).Put("peppi", Arr(Call(Fn((V _self20, int _argc480, V _a482, V _a483, V _a484, V _a485, V[] _rest481) => {
V t_486 = default;
V B_487 = default;
t_486 = Call(TL_28, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_487 = ((V)(520D));
Call(swing_35, V.Undef, t_486, ((V)(2400D)), ((V)(4D)), NewObj(5).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).Put("flop", ((V)(0.7))).Put("armL", ((V)(20D))).Put("armR", ((V)((-20D)))).V, ((V)("io")));
{
V i_488 = default;
i_488 = ((V)(0D));
while (true) {
if (!(LtN(i_488, 2D))) break;
Invoke(Invoke(Invoke(Invoke(Invoke(t_486, "to", ((V)(320D)), NewObj(4).Put("pull", ((V)(1D))).Put("lift", ((V)(3D))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("cheese")), ((V)("head")), ((V)(2D))), "wait", ((V)(160D))), "to", ((V)(260D)), NewObj(4).Put("pull", ((V)(0D))).Put("lift", ((V)(0D))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V, ((V)("i"))), "wait", ((V)((ToNum(B_487) - 260D))));
PostInc(ref i_488, 1D);
}
}
Invoke(t_486, "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(jump_33, V.Undef, t_486, NewObj(8).Put("h", ((V)(11D))).Put("ant", ((V)(180D))).Put("up", ((V)(260D))).Put("c", ((V)(0.18))).Put("arm", ((V)(90D))).Put("spin", ((V)(360D))).Put("air", NewObj(1).Put("flop", ((V)((-0.7)))).V).Put("fall", NewObj(1).Put("flop", ((V)(0D))).V).V);
Invoke(Invoke(t_486, "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("flop", ((V)(1D))).Put("tilt", ((V)(3D))).V, NewObj(2).Put("flop", ((V)((-0.6)))).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("flop", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_486, "to", ((V)(400D)), NewObj(5).Put("pitch", ((V)((-0.18)))).Put("flop", ((V)(0.6))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("close", ((V)(0.6))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("cheese")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(5).Put("pitch", ((V)(0D))).Put("flop", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_486, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Cheese Pull Sway")), ((V)("A lazy floppy sway, two big cheese pulls with his crust lifting, a slice spin in the air, a floppy-tip shimmy and a cheesy bow.")))).Put("nori", Arr(Call(Fn((V _self20, int _argc490, V _a492, V _a493, V _a494, V _a495, V[] _rest491) => {
V t_496 = default;
V B_497 = default;
t_496 = Call(TL_28, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_497 = ((V)(500D));
Invoke(Invoke(Invoke(t_496, "to", ((V)(400D)), NewObj(2).Put("pitch", ((V)((-0.2)))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
{
V i_498 = default;
i_498 = ((V)(0D));
while (true) {
if (!(LtN(i_498, 4D))) break;
V d_500 = default;
d_500 = ((V)((NumTruthy((ToNum(i_498) % 2D)) ? 1D : (-1D))));
Invoke(Invoke(t_496, "to", ((V)((ToNum(B_497) / 2D))), NewObj(5).Put("x", ((V)((ToNum(d_500) * 3D)))).Put("footL", ((V)((LtN(d_500, 0D) ? 2.4 : 0D)))).Put("footR", ((V)((GtN(d_500, 0D) ? 2.4 : 0D)))).Put("ume", ((V)(0.6))).Put("tilt", ((V)((ToNum(d_500) * 2D)))).V, ((V)("o"))), "to", ((V)((ToNum(B_497) / 2D))), NewObj(3).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("ume", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_498, 1D);
}
}
Invoke(Invoke(Invoke(Invoke(t_496, "to", ((V)(300D)), NewObj(2).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), Call(o_31, V.Undef, Call(both_30, V.Undef, ((V)(3D)), ((V)(6D))), NewObj(2).Put("armL", ((V)(18D))).Put("armR", ((V)(18D))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("nwr", ((V)(0.7))).Put("sq", ((V)(0.03))).V, NewObj(2).Put("nwr", ((V)((-0.3)))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(240D)), Call(o_31, V.Undef, NOHANDS_32, NewObj(3).Put("nwr", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
Call(jump_33, V.Undef, t_496, NewObj(9).Put("h", ((V)(11D))).Put("ant", ((V)(180D))).Put("up", ((V)(260D))).Put("c", ((V)(0.18))).Put("arm", ((V)(80D))).Put("spin", ((V)(360D))).Put("air", NewObj(1).Put("ume", ((V)(1D))).V).Put("fall", NewObj(1).Put("ume", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(6D))))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_496, "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("hap", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(2).Put("pitch", ((V)((-0.2)))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_496, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Rice Ball Roll")), ((V)("A polite bow, neat side steps with his salmon flakes bobbing, a seaweed-jacket shimmy, a spinning hop that scatters rice, a cheer and another bow.")))).Put("sunny", Arr(Call(Fn((V _self20, int _argc501, V _a503, V _a504, V _a505, V _a506, V[] _rest502) => {
V t_507 = default;
V B_508 = default;
t_507 = Call(TL_28, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_508 = ((V)(480D));
{
V i_509 = default;
i_509 = ((V)(0D));
while (true) {
if (!(LtN(i_509, 4D))) break;
V d_511 = default;
d_511 = ((V)((NumTruthy((ToNum(i_509) % 2D)) ? 1D : (-1D))));
Invoke(Invoke(t_507, "to", ((V)((ToNum(B_508) * 0.55))), NewObj(6).Put("rl", ((V)((ToNum(d_511) * 22D)))).Put("x", ((V)((ToNum(d_511) * 6D)))).Put("cap", ((V)(0.5))).PutK(((V)((LtN(d_511, 0D) ? "armL" : "armR"))), ((V)(120D))).PutK(((V)((LtN(d_511, 0D) ? "armR" : "armL"))), ((V)(20D))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)((ToNum(B_508) * 0.45))), NewObj(2).Put("cap", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_509, 1D);
}
}
Invoke(t_507, "to", ((V)(260D)), NewObj(4).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_507, "to", ((V)(1000D)), NewObj(4).Put("rl", ((V)(360D))).Put("x", ((V)(22D))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "wait", ((V)(150D))), "to", ((V)(1000D)), NewObj(2).Put("rl", ((V)((-360D)))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_507, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.14))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(5).Put("cap", ((V)(1.2))).Put("sq", ((V)((-0.1)))).Put("wob", ((V)(1.4))).Put("wide", ((V)(0.6))).Put("open", ((V)(0.5))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(360D)), NewObj(2).Put("cap", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "to", ((V)(200D)), NewObj(4).Put("sq", ((V)(0D))).Put("wob", ((V)(0.6))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
Call(jump_33, V.Undef, t_507, NewObj(7).Put("h", ((V)(12D))).Put("ant", ((V)(180D))).Put("up", ((V)(280D))).Put("c", ((V)(0.18))).Put("arm", ((V)(80D))).Put("air", NewObj(1).Put("rl", ((V)((-180D)))).V).Put("fall", NewObj(1).Put("rl", ((V)((-360D)))).V).V);
Invoke(t_507, "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(t_507, "osc", ((V)(1000D)), ((V)(4D)), NewObj(2).Put("rl", ((V)(10D))).Put("wob", ((V)(0.8))).V, NewObj(2).Put("rl", ((V)((-10D)))).Put("wob", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("rl", ((V)(0D))).Put("wob", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_507, "to", ((V)(400D)), NewObj(4).Put("cap", ((V)(0.6))).Put("pitch", ((V)((-0.14)))).Put("close", ((V)(0.6))).Put("armR", ((V)(120D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(4).Put("cap", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(200D)));
return Invoke(Invoke(t_507, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Roly-Poly Rock")), ((V)("Rocks side to side on her round bottom tipping her shell cap on every beat, rolls right over and back, the cap pops off and lands back while her yolk wobbles, a somersault, a wobble and a hat-tip bow.")))).Put("toco", Arr(Call(Fn((V _self20, int _argc512, V _a514, V _a515, V _a516, V _a517, V[] _rest513) => {
V t_518 = default;
V B_519 = default;
V a_520 = default;
t_518 = Call(TL_28, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_519 = ((V)(420D));
{
V i_521 = default;
i_521 = ((V)(0D));
while (true) {
if (!(LtN(i_521, 6D))) break;
V d_523 = default;
d_523 = ((V)((NumTruthy((ToNum(i_521) % 2D)) ? 1D : (-1D))));
Invoke(Invoke(t_518, "to", ((V)((ToNum(B_519) * 0.3))), NewObj(5).Put("snap", ((V)((-0.6)))).PutK(((V)((LtN(d_523, 0D) ? "armL" : "armR"))), ((V)(150D))).PutK(((V)((LtN(d_523, 0D) ? "armR" : "armL"))), ((V)(30D))).PutK(((V)((LtN(d_523, 0D) ? "footL" : "footR"))), ((V)(2.2))).Put("tilt", ((V)((ToNum(d_523) * 3D)))).V, ((V)("o"))), "to", ((V)((ToNum(B_519) * 0.7))), NewObj(3).Put("snap", ((V)(0.5))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_521, 1D);
}
}
Invoke(t_518, "to", ((V)(200D)), NewObj(4).Put("snap", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
a_520 = Call(spinR_46, V.Undef, t_518, ((V)(1200D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(150D))).V);
Invoke(t_518, "at", a_520);
{
V i_524 = default;
i_524 = ((V)(0D));
while (true) {
if (!(LtN(i_524, 3D))) break;
Invoke(Invoke(t_518, "to", ((V)(150D)), NewObj(1).Put("snap", ((V)((-0.5)))).V, ((V)("o"))), "to", ((V)(250D)), NewObj(1).Put("snap", ((V)(0.4))).V, ((V)("io")));
PostInc(ref i_524, 1D);
}
}
Invoke(Invoke(t_518, "at", Add(a_520, ((V)(1201D)))), "to", ((V)(200D)), NewObj(3).Put("snap", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(jump_33, V.Undef, t_518, NewObj(8).Put("h", ((V)(10D))).Put("ant", ((V)(160D))).Put("up", ((V)(240D))).Put("c", ((V)(0.18))).Put("arm", ((V)(120D))).Put("air", NewObj(1).Put("snap", ((V)(1.2))).V).Put("fall", NewObj(1).Put("snap", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(5D))))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(t_518, "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(160D))).Put("armL", ((V)(20D))).Put("tilt", ((V)((-4D)))).Put("snap", ((V)((-0.4)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(0D))).Put("armL", ((V)(0D))).Put("tilt", ((V)(0D))).Put("snap", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_518, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Taco Snap")), ((V)("Snaps his shell like castanets on every beat with flamenco arms and stamps, a spin, a jump that showers lettuce, and an ole.")))).Put("churro", Arr(Call(Fn((V _self20, int _argc526, V _a528, V _a529, V _a530, V _a531, V[] _rest527) => {
V t_532 = default;
V B_533 = default;
V a_534 = default;
t_532 = Call(TL_28, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_533 = ((V)(520D));
{
V i_535 = default;
i_535 = ((V)(0D));
while (true) {
if (!(LtN(i_535, 4D))) break;
V d_537 = default;
d_537 = ((V)((LtN(i_535, 2D) ? 1D : (-1D))));
Invoke(Invoke(t_532, "to", ((V)((ToNum(B_533) * 0.4))), NewObj(5).Put("x", ((V)((ToNum(d_537) * (NumTruthy((ToNum(i_535) % 2D)) ? 4D : 2D))))).PutK(((V)((NumTruthy((ToNum(i_535) % 2D)) ? "footR" : "footL"))), ((V)(2.5))).Put("armL", ((V)(60D))).Put("armR", ((V)(20D))).Put("lean", ((V)((ToNum(d_537) * 1.2)))).V, ((V)("o"))), "to", ((V)((ToNum(B_533) * 0.6))), NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_535, 1D);
}
}
Invoke(t_532, "to", ((V)(300D)), NewObj(4).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
a_534 = Call(spinR_46, V.Undef, t_532, ((V)(1500D)), ((V)(720D)), NewObj(3).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("lift", ((V)(2D))).V);
Invoke(Invoke(Invoke(Invoke(t_532, "at", a_534), "to", ((V)(600D)), NewObj(1).Put("cork", ((V)(1.2))).V, ((V)("io"))), "to", ((V)(900D)), NewObj(1).Put("cork", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("cork", ((V)((-0.4)))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_532, "at", Add(a_534, ((V)(1501D)))), "to", ((V)(300D)), NewObj(4).Put("cork", ((V)(0D))).Put("lift", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sugar")), ((V)("head")), ((V)(4D)));
Invoke(Invoke(Invoke(t_532, "to", ((V)(600D)), NewObj(5).Put("bend", ((V)((-14D)))).Put("lean", ((V)((-2D)))).Put("armL", ((V)(150D))).Put("armR", ((V)(40D))).Put("close", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(5).Put("bend", ((V)(0D))).Put("lean", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_532, "to", ((V)(300D)), NewObj(2).Put("armR", ((V)(150D))).Put("htilt", ((V)(6D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("sugar")), ((V)("body")), ((V)(5D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(2).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_532, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Churro Corkscrew")), ((V)("Suave tango steps, a double spin that twists his ridges into a corkscrew, a deep tango dip and a sugar-dusted pose.")))).Put("khinki", Arr(Call(Fn((V _self20, int _argc538, V _a540, V _a541, V _a542, V _a543, V[] _rest539) => {
V t_544 = default;
V B_545 = default;
V a_546 = default;
t_544 = Call(TL_28, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_545 = ((V)(500D));
{
V i_547 = default;
i_547 = ((V)(0D));
while (true) {
if (!(LtN(i_547, 4D))) break;
V d_549 = default;
d_549 = ((V)((NumTruthy((ToNum(i_547) % 2D)) ? 1D : (-1D))));
Invoke(t_544, "to", B_545, NewObj(5).Put("kt", ((V)((ToNum(d_549) * 1D)))).Put("knot", ((V)(((-ToNum(d_549)) * 0.8)))).Put("tilt", ((V)((ToNum(d_549) * 3D)))).Put("armL", ((V)((LtN(d_549, 0D) ? 60D : 10D)))).Put("armR", ((V)((GtN(d_549, 0D) ? 60D : 10D)))).V, ((V)("io")));
PostInc(ref i_547, 1D);
}
}
Invoke(t_544, "to", ((V)(300D)), NewObj(5).Put("kt", ((V)(0D))).Put("knot", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
{
V i_550 = default;
i_550 = ((V)(0D));
while (true) {
if (!(LtN(i_550, 3D))) break;
Call(hopC_43, V.Undef, t_544, ((V)(7D)), NewObj(3).Put("chain", (LtN(i_550, 2D) ? V.True : V.False)).Put("air", NewObj(1).Put("knot", ((V)((NumTruthy((ToNum(i_550) % 2D)) ? 0.6 : (-0.6))))).V).Put("fall", NewObj(1).Put("knot", ((V)(0D))).V).V);
PostInc(ref i_550, 1D);
}
}
a_546 = Call(spinR_46, V.Undef, t_544, ((V)(1400D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(70D))).Put("armR", ((V)(70D))).V);
Invoke(Invoke(Invoke(t_544, "at", a_546), "to", ((V)(700D)), NewObj(2).Put("kt", ((V)(1.1))).Put("knot", ((V)((-0.8)))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(2).Put("kt", ((V)(0D))).Put("knot", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_544, "at", Add(a_546, ((V)(1401D)))), "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(shake_34, V.Undef, t_544, NewObj(6).Put("P", ((V)(90D))).Put("env", Arr(((V)(0.4)), ((V)(0.9)), ((V)(1D)), ((V)(0.6)), ((V)(0.3)))).Put("head", ((V)(0.06))).Put("roll", ((V)(3D))).Put("ear", ((V)(0D))).Put("body", ((V)(0.5))).V);
Invoke(t_544, "e", ((V)("emit")), ((V)("pepper")), ((V)("head")), ((V)(5D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_544, "to", ((V)(200D)), NewObj(2).Put("sq", ((V)(0.18))).Put("kt", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(7).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(3D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("kt", ((V)((-0.3)))).Put("wide", ((V)(0.5))).Put("open", ((V)(0.5))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(6D))), "to", ((V)(300D)), NewObj(7).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("kt", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(200D)));
return Invoke(Invoke(t_544, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Topknot Twist")), ((V)("Twists his pleats one way and the other with his knot whipping round, juicy bounces, a twirling spin, a pepper shake and a big juicy squirt.")))).Put("maki", Arr(Call(Fn((V _self20, int _argc552, V _a554, V _a555, V _a556, V _a557, V[] _rest553) => {
V t_558 = default;
V B_559 = default;
V a_560 = default;
t_558 = Call(TL_28, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_559 = ((V)(500D));
{
V i_561 = default;
i_561 = ((V)(0D));
while (true) {
if (!(LtN(i_561, 4D))) break;
Invoke(Invoke(t_558, "to", ((V)((ToNum(B_559) / 2D))), NewObj(5).Put("veg", ((V)(0.9))).Put("x", ((V)((NumTruthy((ToNum(i_561) % 2D)) ? 1.5 : (-1.5))))).Put("tilt", ((V)((NumTruthy((ToNum(i_561) % 2D)) ? 3D : (-3D))))).Put("footL", ((V)((NumTruthy((ToNum(i_561) % 2D)) ? 0D : 2D)))).Put("footR", ((V)((NumTruthy((ToNum(i_561) % 2D)) ? 2D : 0D)))).V, ((V)("o"))), "to", ((V)((ToNum(B_559) / 2D))), NewObj(3).Put("veg", ((V)(0.1))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_561, 1D);
}
}
Invoke(t_558, "to", ((V)(200D)), NewObj(3).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("veg", ((V)(0D))).V, ((V)("io")));
a_560 = Call(spinR_46, V.Undef, t_558, ((V)(1600D)), ((V)(720D)), NewObj(3).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("lift", ((V)(2D))).V);
Invoke(Invoke(t_558, "at", a_560), "osc", ((V)(1600D)), ((V)(4D)), NewObj(1).Put("veg", ((V)(1D))).V, NewObj(1).Put("veg", ((V)(0.2))).V, ((V)("io")));
Invoke(Invoke(t_558, "at", Add(a_560, ((V)(1601D)))), "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lift", ((V)(0D))).Put("veg", ((V)(0D))).V, ((V)("io")));
{
V i_563 = default;
i_563 = ((V)(0D));
while (true) {
if (!(LtN(i_563, 3D))) break;
Call(hopC_43, V.Undef, t_558, ((V)(6D)), NewObj(4).Put("chain", (LtN(i_563, 2D) ? V.True : V.False)).Put("air", NewObj(1).Put("veg", ((V)(0.8))).V).Put("fall", NewObj(1).Put("veg", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("rice")), ((V)("head")), ((V)(2D))))).V);
PostInc(ref i_563, 1D);
}
}
Invoke(t_558, "to", ((V)(300D)), NewObj(1).Put("close", ((V)(0.7))).V, ((V)("io")));
a_560 = Call(spinR_46, V.Undef, t_558, ((V)(2000D)), ((V)(360D)), NewObj(0).V);
Invoke(t_558, "to", ((V)(200D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_558, "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)((-0.2)))).Put("close", ((V)(0.6))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_558, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Sushi Spin")), ((V)("Sways with his salmon and veggies wiggling, spins like a top twice, three hops that toss rice, a slow calm turn and a bow.")))).Put("noodle", Arr(Call(Fn((V _self20, int _argc565, V _a567, V _a568, V _a569, V _a570, V[] _rest566) => {
V t_571 = default;
V B_572 = default;
V a_573 = default;
t_571 = Call(TL_28, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_572 = ((V)(480D));
{
V i_574 = default;
i_574 = ((V)(0D));
while (true) {
if (!(LtN(i_574, 4D))) break;
Invoke(Invoke(t_571, "to", ((V)((ToNum(B_572) / 2D))), NewObj(5).Put("slurp", ((V)(0.8))).Put("x", ((V)((NumTruthy((ToNum(i_574) % 2D)) ? 1D : (-1D))))).Put("tilt", ((V)((NumTruthy((ToNum(i_574) % 2D)) ? 3D : (-3D))))).Put("puff", ((V)((-0.2)))).Put("mw", ((V)(0.6))).V, ((V)("o"))), "to", ((V)((ToNum(B_572) / 2D))), NewObj(3).Put("slurp", ((V)(0D))).Put("puff", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
PostInc(ref i_574, 1D);
}
}
Invoke(t_571, "to", ((V)(200D)), NewObj(2).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
{
V i_576 = default;
i_576 = ((V)(0D));
while (true) {
if (!(LtN(i_576, 3D))) break;
Invoke(Invoke(t_571, "to", ((V)(150D)), NewObj(2).Put("lid", ((V)((-0.8)))).Put("armR", ((V)(120D))).V, ((V)("o"))), "to", ((V)((ToNum(B_572) - 150D))), NewObj(2).Put("lid", ((V)(0.6))).Put("armR", ((V)(30D))).V, ((V)("io")));
PostInc(ref i_576, 1D);
}
}
Invoke(t_571, "to", ((V)(200D)), NewObj(2).Put("lid", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
a_573 = Call(spinR_46, V.Undef, t_571, ((V)(1300D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V);
Invoke(t_571, "at", a_573);
Invoke(Arr(((V)(0D)), ((V)(400D)), ((V)(800D))), "forEach", Fn((V _self20, int _argc578, V d_584, V _a581, V _a582, V _a583, V[] _rest579) => {
return Invoke(Invoke(t_571, "at", Add(a_573, d_584)), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
}, 1, "", true));
Invoke(Invoke(t_571, "at", Add(a_573, ((V)(1301D)))), "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_571, "to", ((V)(400D)), NewObj(5).Put("slurp", ((V)(1.2))).Put("puff", ((V)((-0.3)))).Put("open", ((V)(0.2))).Put("mw", ((V)(0.5))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(5).Put("slurp", ((V)(0D))).Put("puff", ((V)(0D))).Put("open", ((V)(0.3))).Put("mw", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(4D))), "wait", ((V)(300D)));
return Invoke(Invoke(t_571, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Noodle Slurp")), ((V)("A slurpy shimmy, lifts noodles with his chopsticks on the beat, a steamy spin and one big slurp.")))).Put("flossie", Arr(Call(Fn((V _self20, int _argc585, V _a587, V _a588, V _a589, V _a590, V[] _rest586) => {
V t_591 = default;
V B_592 = default;
V a_593 = default;
t_591 = Call(TL_28, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_592 = ((V)(560D));
Invoke(t_591, "to", ((V)(800D)), NewObj(3).Put("lift", ((V)(6D))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("io")));
a_593 = Get(t_591, "t");
Invoke(t_591, "osc", ((V)(2200D)), ((V)(2D)), NewObj(1).Put("lift", ((V)(8D))).V, NewObj(1).Put("lift", ((V)(5D))).V, ((V)("s")));
Invoke(Invoke(Invoke(t_591, "at", a_593), "to", ((V)(2200D)), NewObj(1).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("l")));
Invoke(t_591, "to", ((V)(600D)), NewObj(3).Put("lift", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
{
V i_594 = default;
i_594 = ((V)(0D));
while (true) {
if (!(LtN(i_594, 4D))) break;
Invoke(Invoke(Invoke(t_591, "to", ((V)(150D)), NewObj(2).Put("fluff", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(1D))), "to", ((V)((ToNum(B_592) - 150D))), NewObj(2).Put("fluff", ((V)(0.1))).Put("sq", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_594, 1D);
}
}
Invoke(t_591, "to", ((V)(200D)), NewObj(1).Put("fluff", ((V)(0D))).V, ((V)("io")));
a_593 = Call(spinR_46, V.Undef, t_591, ((V)(1500D)), ((V)(360D)), NewObj(3).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("lift", ((V)(3D))).V);
Invoke(Invoke(Invoke(t_591, "at", a_593), "to", ((V)(1500D)), NewObj(1).Put("swirl", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(t_591, "at", Add(a_593, ((V)(1501D)))), "to", ((V)(400D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_591, "to", ((V)(300D)), NewObj(3).Put("fluff", ((V)(1.4))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(4D))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(300D))), "to", ((V)(700D)), NewObj(3).Put("fluff", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return Invoke(Invoke(t_591, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Candy Cloud Float")), ((V)("Floats up and down with her floss swirling round her, poofs on the beat, a twirling spin and a big sparkly poof.")))).V;
Invoke(KEYS_9, "forEach", Fn((V _self20, int _argc596, V k_602, V _a599, V _a600, V _a601, V[] _rest597) => {
Set(GetK(MOVES_48, k_602), "dance", GetK(DANCES_49, k_602));
Set(GetK(MOVES_48, k_602), "look", Call(natF_40, V.Undef, ((V)(1D))));
return default;
}, 1, "", true));
Call(install_39, V.Undef, MOVES_48, CARDS_47);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_641 => Fn((V _self603, int _argc604, V _a606, V _a607, V _a608, V _a609, V[] _rest605) => {
V R_610 = default;
V S_611 = default;
V hand_612 = default;
V both_613 = default;
V o_614 = default;
V NOHANDS_615 = default;
V jump_616 = default;
V shake_617 = default;
V swing_618 = default;
V jelly_619 = default;
V see_620 = default;
V unsee_621 = default;
V giggle_622 = default;
V sniff_623 = default;
V lick_624 = default;
V para_625 = default;
V leanIn_626 = default;
V happy_627 = default;
V build_628 = default;
V armUp_629 = default;
V eyeRub_630 = default;
V wobble_631 = default;
V lookBack_632 = default;
V hop_633 = default;
V tickle_634 = default;
V tasteHeart_635 = default;
V fizz_636 = default;
V nose_637 = default;
V BODY_638 = default;
V RE_639 = default;
V TXT_640 = default;
if (_self603.IsNullish) _self603 = GlobalV;
R_610 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_610)) || !(Truthy(Get(R_610, "POKELIB")))) || !(Truthy(Get(R_610, "snack2V")))) || !(Truthy(Get(Get(R_610, "STATES"), "poke_head"))))) {
Call(G("setTimeout"), V.Undef, boot_641.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_610, "snack2PokeV"))) {
return default;
}
Set(R_610, "snack2PokeV", ((V)(1D)));
{ V _t642 = Get(R_610, "PETLIB");
if (_t642.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t642));
{ V _t643 = Get(_t642, "S");
S_611 = _t643; }
{ V _t644 = Get(_t642, "hand");
hand_612 = _t644; }
{ V _t645 = Get(_t642, "both");
both_613 = _t645; }
{ V _t646 = Get(_t642, "o");
o_614 = _t646; }
{ V _t647 = Get(_t642, "NOHANDS");
NOHANDS_615 = _t647; }
{ V _t648 = Get(_t642, "jump");
jump_616 = _t648; }
{ V _t649 = Get(_t642, "shake");
shake_617 = _t649; }
{ V _t650 = Get(_t642, "swing");
swing_618 = _t650; }
{ V _t651 = Get(_t642, "jelly");
jelly_619 = _t651; } }
{ V _t652 = Get(R_610, "POKELIB");
if (_t652.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t652));
{ V _t653 = Get(_t652, "see");
see_620 = _t653; }
{ V _t654 = Get(_t652, "unsee");
unsee_621 = _t654; }
{ V _t655 = Get(_t652, "giggle");
giggle_622 = _t655; }
{ V _t656 = Get(_t652, "sniff");
sniff_623 = _t656; }
{ V _t657 = Get(_t652, "lick");
lick_624 = _t657; }
{ V _t658 = Get(_t652, "para");
para_625 = _t658; }
{ V _t659 = Get(_t652, "leanIn");
leanIn_626 = _t659; }
{ V _t660 = Get(_t652, "happy");
happy_627 = _t660; }
{ V _t661 = Get(_t652, "build");
build_628 = _t661; } }
armUp_629 = Fn((V _self603, int _argc662, V t_668, V s_669, V n_670, V a_671, V[] _rest663) => {
V k_673 = default;
V x_672 = default;
x_672 = (_argc662 > 4 ? _rest663[0] : V.Undef);
k_673 = Call(S_611, V.Undef, s_669);
a_671 = (a_671 is var _t674 && Truthy(_t674) ? _t674 : ((V)(150D)));
Invoke(t_668, "to", ((V)(300D)), Call(o_614, V.Undef, NewObj(1).PutK(Get(k_673, "arm"), a_671).V, (x_672 is var _t675 && Truthy(_t675) ? _t675 : NewObj(0).V)), ((V)("io")));
{
V i_676 = default;
i_676 = ((V)(0D));
while (true) {
if (!(Lt(i_676, (n_670 is var _t678 && Truthy(_t678) ? _t678 : ((V)(2D)))))) break;
Invoke(Invoke(t_668, "to", ((V)(170D)), NewObj(1).PutK(Get(k_673, "arm"), ((V)((ToNum(a_671) - 16D)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(1).PutK(Get(k_673, "arm"), a_671).V, ((V)("io")));
PostInc(ref i_676, 1D);
}
}
return Invoke(t_668, "to", ((V)(300D)), NewObj(3).PutK(Get(k_673, "arm"), ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
return default;
}, 5, "", true);
eyeRub_630 = Fn((V _self603, int _argc679, V t_685, V s_686, V _a683, V _a684, V[] _rest680) => {
V k_687 = default;
V h_688 = default;
k_687 = Call(S_611, V.Undef, s_686);
h_688 = Call(hand_612, V.Undef, s_686, ((V)(12D)), ((V)((-20D))));
Invoke(Invoke(t_685, "e", ((V)("blink2"))), "to", ((V)(300D)), Call(o_614, V.Undef, h_688, NewObj(2).PutK(Get(k_687, "arm"), ((V)(20D))).PutK(Get(k_687, "wink"), ((V)(1D))).V), ((V)("io")));
{
V i_689 = default;
i_689 = ((V)(0D));
while (true) {
if (!(LtN(i_689, 2D))) break;
Invoke(Invoke(t_685, "to", ((V)(170D)), NewObj(2).PutK(Get(k_687, "hx"), Add(GetK(h_688, Get(k_687, "hx")), ((V)((LtN(s_686, 0D) ? 3D : (-3D)))))).PutK(Get(k_687, "hy"), ((V)((ToNum(GetK(h_688, Get(k_687, "hy"))) - 1.5)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(2).PutK(Get(k_687, "hx"), GetK(h_688, Get(k_687, "hx"))).PutK(Get(k_687, "hy"), GetK(h_688, Get(k_687, "hy"))).V, ((V)("io")));
PostInc(ref i_689, 1D);
}
}
return Invoke(Invoke(t_685, "to", ((V)(300D)), NewObj(4).PutK(Get(k_687, "hx"), ((V)(0D))).PutK(Get(k_687, "hy"), ((V)(0D))).PutK(Get(k_687, "arm"), ((V)(0D))).PutK(Get(k_687, "wink"), ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink")));
return default;
}, 2, "", true);
wobble_631 = Fn((V _self603, int _argc691, V t_697, V a_698, V ch_699, V _a696, V[] _rest692) => {
return Call(jelly_619, V.Undef, t_697, (a_698 is var _t700 && Truthy(_t700) ? _t700 : ((V)(0.12))), ((V)(3D)), ((V)(300D)), ch_699);
}, 3, "", true);
lookBack_632 = Fn((V _self603, int _argc701, V t_707, V hold_708, V _a705, V _a706, V[] _rest702) => {
Call(see_620, V.Undef, t_707, ((V)("tail")), ((V)(1D)), (hold_708 is var _t709 && Truthy(_t709) ? _t709 : ((V)(350D))));
return Call(unsee_621, V.Undef, t_707, ((V)(380D)));
return default;
}, 2, "", true);
hop_633 = Fn((V _self603, int _argc710, V t_716, V h_717, V ev_718, V x_719, V[] _rest711) => {
return Call(jump_616, V.Undef, t_716, Call(o_614, V.Undef, NewObj(6).Put("h", (h_717 is var _t720 && Truthy(_t720) ? _t720 : ((V)(6D)))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).Put("ev", ev_718).V, (x_719 is var _t721 && Truthy(_t721) ? _t721 : NewObj(0).V)));
}, 4, "", true);
tickle_634 = Fn((V _self603, int _argc722, V t_728, V extra_729, V _a726, V _a727, V[] _rest723) => {
V a_730 = default;
Invoke(t_728, "to", ((V)(220D)), Call(o_614, V.Undef, Call(both_613, V.Undef, ((V)(8D)), ((V)((-4D)))), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
a_730 = Get(t_728, "t");
Call(giggle_622, V.Undef, t_728, ((V)(3D)), ((V)(0.9)));
if (Truthy(extra_729)) {
Call(para_625, V.Undef, t_728, a_730, extra_729);
}
return Invoke(t_728, "to", ((V)(260D)), NOHANDS_615, ((V)("io")));
return default;
}, 2, "", true);
tasteHeart_635 = Fn((V _self603, int _argc731, V t_737, V _a734, V _a735, V _a736, V[] _rest732) => {
Call(lick_624, V.Undef, t_737, ((V)(2D)));
return Invoke(Invoke(Invoke(Invoke(t_737, "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(320D))), "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true);
fizz_636 = Fn((V _self603, int _argc738, V t_744, V ch_745, V a_746, V n_747, V[] _rest739) => {
return Invoke(t_744, "osc", ((V)((ToNum(n_747) * 160D))), n_747, NewObj(1).PutK(ch_745, a_746).V, NewObj(1).PutK(ch_745, ((V)(0D))).V, ((V)("io")));
}, 4, "", true);
nose_637 = Fn((V _self603, int _argc748, V t_754, V k_755, V _a752, V _a753, V[] _rest749) => {
Invoke(t_754, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
if (Truthy(k_755)) {
Call(k_755, V.Undef, t_754);
}
return Invoke(t_754, "to", ((V)(200D)), NewObj(1).Put("ly", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
BODY_638 = NewObj(11).Put("frankie", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _self603, int _argc756, V s_762, V _a759, V _a760, V _a761, V[] _rest757) => {
return ((V)((GtN(s_762, 0D) ? "Sausage end (right)" : "Sausage end (left)")));
}, 1, "ear", true)).Put("head", ((V)("Sausage"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Bun"))).Put("tail", ((V)("Back of the bun"))).V).V).Put("corny", NewObj(3).Put("ear", ((V)(0.6))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("ear", ((V)("popcorn"))).Put("head", ((V)("Popcorn"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Stripes"))).Put("foot", ((V)("bucket bottom"))).Put("tail", ((V)("Back of the bucket"))).V).V).Put("peppi", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(6).Put("ear", ((V)("crust corner"))).Put("head", ((V)("Crust"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Pepperoni"))).Put("foot", ((V)("tip"))).Put("tail", ((V)("Underside"))).V).V).Put("nori", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("rice corner"))).Put("head", ((V)("Salmon"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Seaweed jacket"))).Put("tail", ((V)("Back"))).V).V).Put("sunny", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(6).Put("ear", ((V)("shell"))).Put("head", ((V)("Shell cap"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("foot", ((V)("Round bottom"))).Put("tail", ((V)("Back"))).V).V).Put("toco", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("lettuce"))).Put("head", ((V)("Fillings"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Shell"))).Put("tail", ((V)("Back of the shell"))).V).V).Put("churro", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("chocolate"))).Put("head", ((V)("Chocolate top"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Ridges"))).Put("tail", ((V)("Back"))).V).V).Put("khinki", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("pleats"))).Put("head", ((V)("Top knot"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Dough belly"))).Put("tail", ((V)("Back"))).V).V).Put("maki", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(6).Put("ear", ((V)("rice rim"))).Put("head", ((V)("Filling"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Rice belly"))).Put("side", ((V)("rice"))).Put("tail", ((V)("Back"))).V).V).Put("noodle", NewObj(3).Put("ear", ((V)(0.6))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("ear", Fn((V _self603, int _argc763, V s_769, V _a766, V _a767, V _a768, V[] _rest764) => {
return ((V)((GtN(s_769, 0D) ? "Chopsticks" : "Noodles")));
}, 1, "ear", true)).Put("head", ((V)("Toppings"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Red band"))).Put("foot", ((V)("bowl bottom"))).Put("tail", ((V)("Bowl (back)"))).V).V).Put("flossie", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(6).Put("ear", ((V)("floss"))).Put("head", ((V)("Floss top"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Floss"))).Put("foot", ((V)("stick"))).Put("tail", ((V)("Back"))).V).V).V;
RE_639 = NewObj(11).Put("frankie", NewObj(9).Put("head", Fn((V _self603, int _argc770, V t_776, V s_777, V _a774, V _a775, V[] _rest771) => {
Invoke(Invoke(Invoke(t_776, "to", ((V)(140D)), NewObj(2).Put("hug", ((V)((-0.6)))).Put("sq", ((V)(0.08))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(3D))), "to", ((V)(260D)), NewObj(2).Put("hug", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(giggle_622, V.Undef, t_776, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self603, int _argc778, V t_784, V s_785, V _a782, V _a783, V[] _rest779) => {
Invoke(t_784, "to", ((V)(220D)), NewObj(2).Put("slip", ((V)(((-ToNum(s_785)) * 0.8)))).Put("wide", ((V)(0.5))).V, ((V)("o")));
Call(see_620, V.Undef, t_784, ((V)("ear")), s_785, ((V)(150D)));
Invoke(Invoke(t_784, "to", ((V)(320D)), Call(o_614, V.Undef, Call(hand_612, V.Undef, s_785, ((V)(6D)), ((V)((-6D)))), NewObj(2).PutK(Get(Call(S_611, V.Undef, s_785), "arm"), ((V)(60D))).Put("slip", ((V)(0D))).V), ((V)("io"))), "to", ((V)(260D)), Call(o_614, V.Undef, NOHANDS_615, NewObj(2).PutK(Get(Call(S_611, V.Undef, s_785), "arm"), ((V)(0D))).Put("wide", ((V)(0D))).V), ((V)("io")));
Call(unsee_621, V.Undef, t_784);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self603, int _argc786, V t_792, V s_793, V _a790, V _a791, V[] _rest787) => {
return Call(nose_637, V.Undef, t_792, Fn((V _self603, int _argc794, V u_800, V _a797, V _a798, V _a799, V[] _rest795) => {
Call(sniff_623, V.Undef, u_800, ((V)(2D)));
Call(tasteHeart_635, V.Undef, u_800);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _self603, int _argc801, V t_807, V s_808, V _a805, V _a806, V[] _rest802) => {
Call(eyeRub_630, V.Undef, t_807, s_808);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self603, int _argc809, V t_815, V s_816, V _a813, V _a814, V[] _rest810) => {
Call(leanIn_626, V.Undef, t_815, s_816, NewObj(1).Put("hug", ((V)((-0.3)))).V);
Invoke(t_815, "to", ((V)(200D)), NewObj(1).Put("hug", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self603, int _argc817, V t_823, V s_824, V _a821, V _a822, V[] _rest818) => {
Call(tickle_634, V.Undef, t_823, Fn((V _self603, int _argc825, V u_831, V _a828, V _a829, V _a830, V[] _rest826) => {
return Invoke(Invoke(u_831, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("slip", ((V)(0.5))).V, NewObj(1).Put("slip", ((V)((-0.5)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("slip", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self603, int _argc832, V t_838, V s_839, V _a836, V _a837, V[] _rest833) => {
Invoke(Invoke(Invoke(t_838, "to", ((V)(200D)), NewObj(2).Put("slip", ((V)(((-ToNum(s_839)) * 1D)))).Put("tilt", ((V)(((-ToNum(s_839)) * 4D)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("slip", ((V)(((-ToNum(s_839)) * 0.3)))).Put("tilt", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("slip", ((V)(0D))).V, ((V)("io")));
Call(see_620, V.Undef, t_838, ((V)("side")), s_839, ((V)(200D)));
Call(unsee_621, V.Undef, t_838, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self603, int _argc840, V t_846, V s_847, V _a844, V _a845, V[] _rest841) => {
Call(hop_633, V.Undef, t_846, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(2D)))), NewObj(2).Put("air", NewObj(1).Put("slip", ((V)(0.4))).V).Put("fall", NewObj(1).Put("slip", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self603, int _argc848, V t_854, V s_855, V _a852, V _a853, V[] _rest849) => {
Invoke(Invoke(t_854, "to", ((V)(160D)), NewObj(1).Put("hug", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("hug", ((V)(0D))).V, ((V)("io")));
Call(lookBack_632, V.Undef, t_854);
return default;
}, 2, "tail", true)).V).Put("corny", NewObj(9).Put("head", Fn((V _self603, int _argc856, V t_862, V s_863, V _a860, V _a861, V[] _rest857) => {
Invoke(Invoke(Invoke(t_862, "to", ((V)(100D)), NewObj(2).Put("pop", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(3D))), "to", ((V)(380D)), NewObj(2).Put("pop", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
Call(giggle_622, V.Undef, t_862, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self603, int _argc864, V t_870, V s_871, V _a868, V _a869, V[] _rest865) => {
Call(see_620, V.Undef, t_870, ((V)("ear")), s_871, ((V)(100D)));
Invoke(Invoke(t_870, "to", ((V)(100D)), NewObj(1).Put("pop", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
Call(fizz_636, V.Undef, t_870, ((V)("cfz")), ((V)(0.8)), ((V)(3D)));
Call(unsee_621, V.Undef, t_870);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self603, int _argc872, V t_878, V s_879, V _a876, V _a877, V[] _rest873) => {
return Call(nose_637, V.Undef, t_878, Fn((V _self603, int _argc880, V u_886, V _a883, V _a884, V _a885, V[] _rest881) => {
Call(sniff_623, V.Undef, u_886, ((V)(3D)));
Invoke(Invoke(Invoke(u_886, "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("cfz", ((V)(0.7))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(200D)), NewObj(3).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("cfz", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _self603, int _argc887, V t_893, V s_894, V _a891, V _a892, V[] _rest888) => {
Call(eyeRub_630, V.Undef, t_893, s_894);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self603, int _argc895, V t_901, V s_902, V _a899, V _a900, V[] _rest896) => {
Call(leanIn_626, V.Undef, t_901, s_902, NewObj(1).Put("cfz", ((V)(0.5))).V);
Invoke(t_901, "to", ((V)(200D)), NewObj(1).Put("cfz", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self603, int _argc903, V t_909, V s_910, V _a907, V _a908, V[] _rest904) => {
Call(tickle_634, V.Undef, t_909, Fn((V _self603, int _argc911, V u_917, V _a914, V _a915, V _a916, V[] _rest912) => {
{
V i_918 = default;
i_918 = ((V)(0D));
while (true) {
if (!(LtN(i_918, 3D))) break;
Invoke(Invoke(u_917, "to", ((V)(120D)), NewObj(1).Put("pop", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_918, 1D);
}
}
return default;
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self603, int _argc920, V t_926, V s_927, V _a924, V _a925, V[] _rest921) => {
V d_928 = default;
d_928 = ((V)((-ToNum(s_927))));
Invoke(Invoke(Invoke(t_926, "to", ((V)(260D)), NewObj(3).Put("tilt", ((V)((ToNum(d_928) * 8D)))).Put("x", ((V)((ToNum(d_928) * 2D)))).Put("pop", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(2).Put("tilt", ((V)(((-ToNum(d_928)) * 3D)))).Put("pop", ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Call(see_620, V.Undef, t_926, ((V)("side")), s_927, ((V)(200D)));
Call(unsee_621, V.Undef, t_926, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self603, int _argc929, V t_935, V s_936, V _a933, V _a934, V[] _rest930) => {
Call(hop_633, V.Undef, t_935, ((V)(7D)), Arr(Arr(((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(3D)))), NewObj(2).Put("air", NewObj(1).Put("pop", ((V)(1D))).V).Put("fall", NewObj(1).Put("pop", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self603, int _argc937, V t_943, V s_944, V _a941, V _a942, V[] _rest938) => {
Invoke(Invoke(t_943, "to", ((V)(100D)), NewObj(1).Put("pop", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
Call(lookBack_632, V.Undef, t_943);
return default;
}, 2, "tail", true)).V).Put("peppi", NewObj(9).Put("head", Fn((V _self603, int _argc945, V t_951, V s_952, V _a949, V _a950, V[] _rest946) => {
Invoke(Invoke(Invoke(t_951, "to", ((V)(200D)), NewObj(2).Put("pull", ((V)(0.8))).Put("lift", ((V)(1.5))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("pull", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("cheese")), ((V)("head")), ((V)(2D)));
Call(giggle_622, V.Undef, t_951, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self603, int _argc953, V t_959, V s_960, V _a957, V _a958, V[] _rest954) => {
Call(see_620, V.Undef, t_959, ((V)("ear")), s_960, ((V)(100D)));
Invoke(t_959, "osc", ((V)(520D)), ((V)(2D)), NewObj(2).Put("htilt", ((V)((ToNum(s_960) * 5D)))).Put("tilt", ((V)((ToNum(s_960) * 2D)))).V, NewObj(2).Put("htilt", s_960).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(unsee_621, V.Undef, t_959);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self603, int _argc961, V t_967, V s_968, V _a965, V _a966, V[] _rest962) => {
return Call(nose_637, V.Undef, t_967, Fn((V _self603, int _argc969, V u_975, V _a972, V _a973, V _a974, V[] _rest970) => {
Call(sniff_623, V.Undef, u_975, ((V)(2D)));
Call(tasteHeart_635, V.Undef, u_975);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _self603, int _argc976, V t_982, V s_983, V _a980, V _a981, V[] _rest977) => {
Call(eyeRub_630, V.Undef, t_982, s_983);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self603, int _argc984, V t_990, V s_991, V _a988, V _a989, V[] _rest985) => {
Call(leanIn_626, V.Undef, t_990, s_991, NewObj(1).Put("flop", ((V)(0.3))).V);
Invoke(t_990, "to", ((V)(200D)), NewObj(1).Put("flop", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self603, int _argc992, V t_998, V s_999, V _a996, V _a997, V[] _rest993) => {
Call(tickle_634, V.Undef, t_998, Fn((V _self603, int _argc1000, V u_1006, V _a1003, V _a1004, V _a1005, V[] _rest1001) => {
return Invoke(Invoke(u_1006, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("flop", ((V)(0.8))).V, NewObj(1).Put("flop", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("flop", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self603, int _argc1007, V t_1013, V s_1014, V _a1011, V _a1012, V[] _rest1008) => {
Call(jelly_619, V.Undef, t_1013, ((V)(4D)), ((V)(3D)), ((V)(320D)), ((V)("bend")));
Call(see_620, V.Undef, t_1013, ((V)("side")), s_1014, ((V)(200D)));
Call(unsee_621, V.Undef, t_1013, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self603, int _argc1015, V t_1021, V s_1022, V _a1019, V _a1020, V[] _rest1016) => {
Invoke(t_1021, "to", ((V)(160D)), NewObj(1).Put("flop", ((V)(1D))).V, ((V)("o")));
Call(jelly_619, V.Undef, t_1021, ((V)(0.7)), ((V)(3D)), ((V)(300D)), ((V)("flop")));
Call(see_620, V.Undef, t_1021, ((V)("foot")), s_1022, ((V)(200D)));
Call(unsee_621, V.Undef, t_1021, ((V)(300D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self603, int _argc1023, V t_1029, V s_1030, V _a1027, V _a1028, V[] _rest1024) => {
Invoke(Invoke(t_1029, "to", ((V)(200D)), NewObj(1).Put("flop", ((V)((-0.8)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("flop", ((V)(0D))).V, ((V)("io")));
Call(lookBack_632, V.Undef, t_1029);
return default;
}, 2, "tail", true)).V).Put("nori", NewObj(9).Put("head", Fn((V _self603, int _argc1031, V t_1037, V s_1038, V _a1035, V _a1036, V[] _rest1032) => {
Invoke(Invoke(Invoke(t_1037, "to", ((V)(120D)), NewObj(2).Put("ume", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(320D)), NewObj(2).Put("ume", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
Call(giggle_622, V.Undef, t_1037, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self603, int _argc1039, V t_1045, V s_1046, V _a1043, V _a1044, V[] _rest1040) => {
Call(see_620, V.Undef, t_1045, ((V)("ear")), s_1046, ((V)(150D)));
Invoke(t_1045, "to", ((V)(200D)), NewObj(1).Put("blush", ((V)(0.6))).V, ((V)("io")));
Call(unsee_621, V.Undef, t_1045);
Invoke(Invoke(t_1045, "to", ((V)(200D)), NewObj(1).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)(0D))).Put("blush", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self603, int _argc1047, V t_1053, V s_1054, V _a1051, V _a1052, V[] _rest1048) => {
return Call(nose_637, V.Undef, t_1053, Fn((V _self603, int _argc1055, V u_1061, V _a1058, V _a1059, V _a1060, V[] _rest1056) => {
Call(sniff_623, V.Undef, u_1061, ((V)(2D)));
Call(tasteHeart_635, V.Undef, u_1061);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _self603, int _argc1062, V t_1068, V s_1069, V _a1066, V _a1067, V[] _rest1063) => {
Call(eyeRub_630, V.Undef, t_1068, s_1069);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self603, int _argc1070, V t_1076, V s_1077, V _a1074, V _a1075, V[] _rest1071) => {
Call(leanIn_626, V.Undef, t_1076, s_1077, NewObj(1).Put("blush", ((V)(0.5))).V);
Invoke(t_1076, "to", ((V)(200D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self603, int _argc1078, V t_1084, V s_1085, V _a1082, V _a1083, V[] _rest1079) => {
Invoke(Invoke(Invoke(t_1084, "to", ((V)(200D)), NewObj(3).Put("nwr", ((V)(0.8))).Put("wide", ((V)(0.6))).Put("blush", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(320D)), Call(o_614, V.Undef, Call(both_613, V.Undef, ((V)(4D)), ((V)(4D))), NewObj(2).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).V), ((V)("io"))), "to", ((V)(300D)), Call(o_614, V.Undef, NOHANDS_615, NewObj(4).Put("nwr", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wide", ((V)(0D))).V), ((V)("io")));
Call(giggle_622, V.Undef, t_1084, ((V)(2D)));
Invoke(t_1084, "to", ((V)(200D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self603, int _argc1086, V t_1092, V s_1093, V _a1090, V _a1091, V[] _rest1087) => {
Call(jelly_619, V.Undef, t_1092, ((V)(3D)), ((V)(3D)), ((V)(320D)), ((V)("bend")));
Invoke(t_1092, "e", ((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(2D)));
Call(see_620, V.Undef, t_1092, ((V)("side")), s_1093, ((V)(200D)));
Call(unsee_621, V.Undef, t_1092, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self603, int _argc1094, V t_1100, V s_1101, V _a1098, V _a1099, V[] _rest1095) => {
Call(hop_633, V.Undef, t_1100, ((V)(5D)), Arr(Arr(((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(2D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self603, int _argc1102, V t_1108, V s_1109, V _a1106, V _a1107, V[] _rest1103) => {
Invoke(t_1108, "e", ((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(2D)));
Call(lookBack_632, V.Undef, t_1108);
return default;
}, 2, "tail", true)).V).Put("sunny", NewObj(9).Put("head", Fn((V _self603, int _argc1110, V t_1116, V s_1117, V _a1114, V _a1115, V[] _rest1111) => {
Invoke(Invoke(Invoke(Invoke(t_1116, "to", ((V)(100D)), NewObj(2).Put("cap", ((V)(0.9))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("wob", ((V)(1D))).V, ((V)("io"))), "to", ((V)(320D)), NewObj(2).Put("cap", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(1).Put("wob", ((V)(0D))).V, ((V)("io")));
Call(giggle_622, V.Undef, t_1116, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self603, int _argc1118, V t_1124, V s_1125, V _a1122, V _a1123, V[] _rest1119) => {
Call(see_620, V.Undef, t_1124, ((V)("ear")), s_1125, ((V)(150D)));
Invoke(Invoke(t_1124, "to", ((V)(140D)), NewObj(1).PutK(((V)((LtN(s_1125, 0D) ? "armL" : "armR"))), ((V)(60D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).PutK(((V)((LtN(s_1125, 0D) ? "armL" : "armR"))), ((V)(0D))).V, ((V)("io")));
Call(unsee_621, V.Undef, t_1124);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self603, int _argc1126, V t_1132, V s_1133, V _a1130, V _a1131, V[] _rest1127) => {
return Call(nose_637, V.Undef, t_1132, Fn((V _self603, int _argc1134, V u_1140, V _a1137, V _a1138, V _a1139, V[] _rest1135) => {
Call(sniff_623, V.Undef, u_1140, ((V)(2D)));
Call(tasteHeart_635, V.Undef, u_1140);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _self603, int _argc1141, V t_1147, V s_1148, V _a1145, V _a1146, V[] _rest1142) => {
Call(eyeRub_630, V.Undef, t_1147, s_1148);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self603, int _argc1149, V t_1155, V s_1156, V _a1153, V _a1154, V[] _rest1150) => {
Call(leanIn_626, V.Undef, t_1155, s_1156, NewObj(1).Put("cap", ((V)(0.2))).V);
Invoke(t_1155, "to", ((V)(200D)), NewObj(1).Put("cap", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self603, int _argc1157, V t_1163, V s_1164, V _a1161, V _a1162, V[] _rest1158) => {
Call(tickle_634, V.Undef, t_1163, Fn((V _self603, int _argc1165, V u_1171, V _a1168, V _a1169, V _a1170, V[] _rest1166) => {
return Invoke(Invoke(u_1171, "osc", ((V)(900D)), ((V)(3D)), NewObj(3).Put("rl", ((V)(10D))).Put("x", ((V)(2D))).Put("cap", ((V)(0.3))).V, NewObj(3).Put("rl", ((V)((-10D)))).Put("x", ((V)((-2D)))).Put("cap", ((V)(0D))).V, ((V)("io"))), "to", ((V)(180D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self603, int _argc1172, V t_1178, V s_1179, V _a1176, V _a1177, V[] _rest1173) => {
V d_1180 = default;
d_1180 = ((V)((-ToNum(s_1179))));
Invoke(Invoke(Invoke(Invoke(t_1178, "to", ((V)(240D)), NewObj(3).Put("rl", ((V)((ToNum(d_1180) * 28D)))).Put("x", ((V)((ToNum(d_1180) * 6D)))).Put("cap", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(380D)), NewObj(3).Put("rl", ((V)(((-ToNum(d_1180)) * 10D)))).Put("x", ((V)(((-ToNum(d_1180)) * 1.5)))).Put("cap", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)((ToNum(d_1180) * 3D)))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("io")));
Call(see_620, V.Undef, t_1178, ((V)("side")), s_1179, ((V)(200D)));
Call(unsee_621, V.Undef, t_1178, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self603, int _argc1181, V t_1187, V s_1188, V _a1185, V _a1186, V[] _rest1182) => {
V d_1189 = default;
d_1189 = (s_1188 is var _t1190 && Truthy(_t1190) ? _t1190 : ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(t_1187, "to", ((V)(260D)), NewObj(3).Put("rl", ((V)((ToNum(d_1189) * 38D)))).Put("x", ((V)((ToNum(d_1189) * 8D)))).Put("cap", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(3).Put("rl", ((V)(((-ToNum(d_1189)) * 14D)))).Put("x", ((V)(((-ToNum(d_1189)) * 2D)))).Put("cap", ((V)(0D))).V, ((V)("io"))), "to", ((V)(320D)), NewObj(2).Put("rl", ((V)((ToNum(d_1189) * 5D)))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("io")));
Call(giggle_622, V.Undef, t_1187, ((V)(1D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self603, int _argc1191, V t_1197, V s_1198, V _a1195, V _a1196, V[] _rest1192) => {
Call(wobble_631, V.Undef, t_1197, ((V)(0.1)));
Call(lookBack_632, V.Undef, t_1197);
return default;
}, 2, "tail", true)).V).Put("toco", NewObj(9).Put("head", Fn((V _self603, int _argc1199, V t_1205, V s_1206, V _a1203, V _a1204, V[] _rest1200) => {
Invoke(Invoke(Invoke(Invoke(t_1205, "to", ((V)(80D)), NewObj(2).Put("snap", ((V)((-0.7)))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(2).Put("snap", ((V)(0.5))).Put("sq", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
Call(giggle_622, V.Undef, t_1205, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self603, int _argc1207, V t_1213, V s_1214, V _a1211, V _a1212, V[] _rest1208) => {
Call(see_620, V.Undef, t_1213, ((V)("ear")), s_1214, ((V)(100D)));
Invoke(t_1213, "to", ((V)(240D)), NewObj(1).Put("snap", ((V)(0.6))).V, ((V)("o")));
Call(armUp_629, V.Undef, t_1213, s_1214, ((V)(1D)), ((V)(138D)));
Invoke(t_1213, "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
Call(unsee_621, V.Undef, t_1213);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self603, int _argc1215, V t_1221, V s_1222, V _a1219, V _a1220, V[] _rest1216) => {
return Call(nose_637, V.Undef, t_1221, Fn((V _self603, int _argc1223, V u_1229, V _a1226, V _a1227, V _a1228, V[] _rest1224) => {
Call(sniff_623, V.Undef, u_1229, ((V)(2D)));
Invoke(Invoke(u_1229, "to", ((V)(100D)), NewObj(1).Put("snap", ((V)((-0.5)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
Call(tasteHeart_635, V.Undef, u_1229);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _self603, int _argc1230, V t_1236, V s_1237, V _a1234, V _a1235, V[] _rest1231) => {
Call(eyeRub_630, V.Undef, t_1236, s_1237);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self603, int _argc1238, V t_1244, V s_1245, V _a1242, V _a1243, V[] _rest1239) => {
Call(leanIn_626, V.Undef, t_1244, s_1245, NewObj(1).Put("snap", ((V)((-0.3)))).V);
Invoke(t_1244, "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self603, int _argc1246, V t_1252, V s_1253, V _a1250, V _a1251, V[] _rest1247) => {
Call(tickle_634, V.Undef, t_1252, Fn((V _self603, int _argc1254, V u_1260, V _a1257, V _a1258, V _a1259, V[] _rest1255) => {
{
V i_1261 = default;
i_1261 = ((V)(0D));
while (true) {
if (!(LtN(i_1261, 3D))) break;
Invoke(Invoke(u_1260, "to", ((V)(100D)), NewObj(1).Put("snap", ((V)((-0.5)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0.4))).V, ((V)("io")));
PostInc(ref i_1261, 1D);
}
}
Invoke(u_1260, "to", ((V)(100D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self603, int _argc1263, V t_1269, V s_1270, V _a1267, V _a1268, V[] _rest1264) => {
Call(jelly_619, V.Undef, t_1269, ((V)(3D)), ((V)(3D)), ((V)(300D)), ((V)("bend")));
Invoke(t_1269, "e", ((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(1D)));
Call(see_620, V.Undef, t_1269, ((V)("side")), s_1270, ((V)(200D)));
Call(unsee_621, V.Undef, t_1269, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self603, int _argc1271, V t_1277, V s_1278, V _a1275, V _a1276, V[] _rest1272) => {
Call(hop_633, V.Undef, t_1277, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(2D)))), NewObj(2).Put("air", NewObj(1).Put("snap", ((V)(0.6))).V).Put("fall", NewObj(1).Put("snap", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self603, int _argc1279, V t_1285, V s_1286, V _a1283, V _a1284, V[] _rest1280) => {
Invoke(Invoke(t_1285, "to", ((V)(100D)), NewObj(1).Put("snap", ((V)((-0.6)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
Call(lookBack_632, V.Undef, t_1285);
return default;
}, 2, "tail", true)).V).Put("churro", NewObj(9).Put("head", Fn((V _self603, int _argc1287, V t_1293, V s_1294, V _a1291, V _a1292, V[] _rest1288) => {
Invoke(Invoke(Invoke(t_1293, "e", ((V)("emit")), ((V)("sugar")), ((V)("head")), ((V)(4D))), "to", ((V)(300D)), NewObj(1).Put("cork", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io")));
Call(giggle_622, V.Undef, t_1293, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self603, int _argc1295, V t_1301, V s_1302, V _a1299, V _a1300, V[] _rest1296) => {
Call(see_620, V.Undef, t_1301, ((V)("ear")), s_1302, ((V)(100D)));
Call(armUp_629, V.Undef, t_1301, s_1302, ((V)(2D)), ((V)(140D)));
Invoke(Invoke(Invoke(t_1301, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
Call(unsee_621, V.Undef, t_1301);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self603, int _argc1303, V t_1309, V s_1310, V _a1307, V _a1308, V[] _rest1304) => {
return Call(nose_637, V.Undef, t_1309, Fn((V _self603, int _argc1311, V u_1317, V _a1314, V _a1315, V _a1316, V[] _rest1312) => {
Call(sniff_623, V.Undef, u_1317, ((V)(2D)));
Call(tasteHeart_635, V.Undef, u_1317);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _self603, int _argc1318, V t_1324, V s_1325, V _a1322, V _a1323, V[] _rest1319) => {
Call(eyeRub_630, V.Undef, t_1324, s_1325);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self603, int _argc1326, V t_1332, V s_1333, V _a1330, V _a1331, V[] _rest1327) => {
Call(leanIn_626, V.Undef, t_1332, s_1333, NewObj(1).Put("cork", ((V)(0.3))).V);
Invoke(t_1332, "to", ((V)(200D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self603, int _argc1334, V t_1340, V s_1341, V _a1338, V _a1339, V[] _rest1335) => {
Call(tickle_634, V.Undef, t_1340, Fn((V _self603, int _argc1342, V u_1348, V _a1345, V _a1346, V _a1347, V[] _rest1343) => {
return Invoke(Invoke(u_1348, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("cork", ((V)(0.7))).V, NewObj(1).Put("cork", ((V)((-0.7)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self603, int _argc1349, V t_1355, V s_1356, V _a1353, V _a1354, V[] _rest1350) => {
Invoke(Invoke(Invoke(t_1355, "to", ((V)(400D)), NewObj(2).Put("cork", ((V)(((-ToNum(s_1356)) * 0.9)))).Put("spin", ((V)(((-ToNum(s_1356)) * 18D)))).V, ((V)("io"))), "to", ((V)(450D)), NewObj(2).Put("cork", ((V)((ToNum(s_1356) * 0.2)))).Put("spin", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io")));
Call(see_620, V.Undef, t_1355, ((V)("side")), s_1356, ((V)(200D)));
Call(unsee_621, V.Undef, t_1355, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self603, int _argc1357, V t_1363, V s_1364, V _a1361, V _a1362, V[] _rest1358) => {
Call(hop_633, V.Undef, t_1363, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("sugar")), ((V)("body")), ((V)(3D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self603, int _argc1365, V t_1371, V s_1372, V _a1369, V _a1370, V[] _rest1366) => {
Invoke(t_1371, "e", ((V)("emit")), ((V)("sugar")), ((V)("body")), ((V)(3D)));
Call(lookBack_632, V.Undef, t_1371);
return default;
}, 2, "tail", true)).V).Put("khinki", NewObj(9).Put("head", Fn((V _self603, int _argc1373, V t_1379, V s_1380, V _a1377, V _a1378, V[] _rest1374) => {
Invoke(Invoke(Invoke(t_1379, "to", ((V)(120D)), NewObj(2).Put("knot", ((V)(0.9))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("knot", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("knot", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(giggle_622, V.Undef, t_1379, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self603, int _argc1381, V t_1387, V s_1388, V _a1385, V _a1386, V[] _rest1382) => {
Call(see_620, V.Undef, t_1387, ((V)("ear")), s_1388, ((V)(100D)));
Invoke(Invoke(t_1387, "to", ((V)(300D)), NewObj(1).Put("kt", ((V)((ToNum(s_1388) * 0.7)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("kt", ((V)(0D))).V, ((V)("io")));
Call(unsee_621, V.Undef, t_1387);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self603, int _argc1389, V t_1395, V s_1396, V _a1393, V _a1394, V[] _rest1390) => {
return Call(nose_637, V.Undef, t_1395, Fn((V _self603, int _argc1397, V u_1403, V _a1400, V _a1401, V _a1402, V[] _rest1398) => {
Call(sniff_623, V.Undef, u_1403, ((V)(2D)));
Call(tasteHeart_635, V.Undef, u_1403);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _self603, int _argc1404, V t_1410, V s_1411, V _a1408, V _a1409, V[] _rest1405) => {
Call(eyeRub_630, V.Undef, t_1410, s_1411);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self603, int _argc1412, V t_1418, V s_1419, V _a1416, V _a1417, V[] _rest1413) => {
Call(leanIn_626, V.Undef, t_1418, s_1419, NewObj(1).Put("knot", ((V)(((-ToNum(s_1419)) * 0.3)))).V);
Invoke(t_1418, "to", ((V)(200D)), NewObj(1).Put("knot", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self603, int _argc1420, V t_1426, V s_1427, V _a1424, V _a1425, V[] _rest1421) => {
Invoke(Invoke(Invoke(t_1426, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(tickle_634, V.Undef, t_1426, Fn((V _self603, int _argc1428, V u_1434, V _a1431, V _a1432, V _a1433, V[] _rest1429) => {
return Invoke(Invoke(u_1434, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("knot", ((V)(0.5))).V, NewObj(1).Put("knot", ((V)((-0.5)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("knot", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self603, int _argc1435, V t_1441, V s_1442, V _a1439, V _a1440, V[] _rest1436) => {
Call(jelly_619, V.Undef, t_1441, ((V)(4D)), ((V)(3D)), ((V)(320D)), ((V)("bend")));
Invoke(Invoke(t_1441, "to", ((V)(200D)), NewObj(1).Put("knot", ((V)(((-ToNum(s_1442)) * 0.6)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("knot", ((V)(0D))).V, ((V)("io")));
Call(see_620, V.Undef, t_1441, ((V)("side")), s_1442, ((V)(200D)));
Call(unsee_621, V.Undef, t_1441, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self603, int _argc1443, V t_1449, V s_1450, V _a1447, V _a1448, V[] _rest1444) => {
Call(hop_633, V.Undef, t_1449, ((V)(6D)), V.Null, NewObj(2).Put("air", NewObj(1).Put("knot", ((V)(0.5))).V).Put("fall", NewObj(1).Put("knot", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self603, int _argc1451, V t_1457, V s_1458, V _a1455, V _a1456, V[] _rest1452) => {
Invoke(t_1457, "e", ((V)("emit")), ((V)("pepper")), ((V)("head")), ((V)(2D)));
Call(lookBack_632, V.Undef, t_1457);
return default;
}, 2, "tail", true)).V).Put("maki", NewObj(9).Put("head", Fn((V _self603, int _argc1459, V t_1465, V s_1466, V _a1463, V _a1464, V[] _rest1460) => {
Invoke(Invoke(t_1465, "to", ((V)(120D)), NewObj(3).Put("veg", ((V)(1D))).Put("sq", ((V)(0.06))).Put("close", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(3).Put("veg", ((V)(0D))).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Call(giggle_622, V.Undef, t_1465, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self603, int _argc1467, V t_1473, V s_1474, V _a1471, V _a1472, V[] _rest1468) => {
Call(see_620, V.Undef, t_1473, ((V)("ear")), s_1474, ((V)(150D)));
Invoke(Invoke(t_1473, "to", ((V)(120D)), NewObj(1).Put("veg", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("veg", ((V)(0D))).V, ((V)("io")));
Call(unsee_621, V.Undef, t_1473);
Call(giggle_622, V.Undef, t_1473, ((V)(1D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self603, int _argc1475, V t_1481, V s_1482, V _a1479, V _a1480, V[] _rest1476) => {
return Call(nose_637, V.Undef, t_1481, Fn((V _self603, int _argc1483, V u_1489, V _a1486, V _a1487, V _a1488, V[] _rest1484) => {
Call(sniff_623, V.Undef, u_1489, ((V)(2D)));
Call(tasteHeart_635, V.Undef, u_1489);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _self603, int _argc1490, V t_1496, V s_1497, V _a1494, V _a1495, V[] _rest1491) => {
Call(eyeRub_630, V.Undef, t_1496, s_1497);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self603, int _argc1498, V t_1504, V s_1505, V _a1502, V _a1503, V[] _rest1499) => {
Call(leanIn_626, V.Undef, t_1504, s_1505);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self603, int _argc1506, V t_1512, V s_1513, V _a1510, V _a1511, V[] _rest1507) => {
Call(tickle_634, V.Undef, t_1512, Fn((V _self603, int _argc1514, V u_1520, V _a1517, V _a1518, V _a1519, V[] _rest1515) => {
return Invoke(Invoke(u_1520, "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(6D))).Put("veg", ((V)(0.5))).V, NewObj(2).Put("tilt", ((V)((-6D)))).Put("veg", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self603, int _argc1521, V t_1527, V s_1528, V _a1525, V _a1526, V[] _rest1522) => {
Invoke(Invoke(t_1527, "to", ((V)(420D)), NewObj(2).Put("spin", ((V)(((-ToNum(s_1528)) * 50D)))).Put("veg", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(420D)), NewObj(2).Put("spin", ((V)(0D))).Put("veg", ((V)(0D))).V, ((V)("io")));
Call(see_620, V.Undef, t_1527, ((V)("side")), s_1528, ((V)(200D)));
Call(unsee_621, V.Undef, t_1527, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self603, int _argc1529, V t_1535, V s_1536, V _a1533, V _a1534, V[] _rest1530) => {
Call(hop_633, V.Undef, t_1535, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(2D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self603, int _argc1537, V t_1543, V s_1544, V _a1541, V _a1542, V[] _rest1538) => {
Invoke(t_1543, "e", ((V)("emit")), ((V)("rice")), ((V)("body")), ((V)(2D)));
Call(lookBack_632, V.Undef, t_1543);
return default;
}, 2, "tail", true)).V).Put("noodle", NewObj(9).Put("head", Fn((V _self603, int _argc1545, V t_1551, V s_1552, V _a1549, V _a1550, V[] _rest1546) => {
Invoke(Invoke(Invoke(t_1551, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(4D))), "to", ((V)(150D)), NewObj(2).Put("slurp", ((V)(0.6))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("slurp", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(giggle_622, V.Undef, t_1551, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self603, int _argc1553, V t_1559, V s_1560, V _a1557, V _a1558, V[] _rest1554) => {
Call(see_620, V.Undef, t_1559, ((V)("ear")), s_1560, ((V)(100D)));
if (GtN(s_1560, 0D)) {
Invoke(Invoke(t_1559, "osc", ((V)(600D)), ((V)(3D)), NewObj(1).Put("lid", ((V)((-0.7)))).V, NewObj(1).Put("lid", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("lid", ((V)(0D))).V, ((V)("io")));
} else {
Invoke(Invoke(t_1559, "to", ((V)(300D)), NewObj(1).Put("slurp", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("slurp", ((V)(0D))).V, ((V)("io")));
}
Call(unsee_621, V.Undef, t_1559);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self603, int _argc1561, V t_1567, V s_1568, V _a1565, V _a1566, V[] _rest1562) => {
return Call(nose_637, V.Undef, t_1567, Fn((V _self603, int _argc1569, V u_1575, V _a1572, V _a1573, V _a1574, V[] _rest1570) => {
Call(sniff_623, V.Undef, u_1575, ((V)(3D)));
Invoke(u_1575, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
Call(tasteHeart_635, V.Undef, u_1575);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _self603, int _argc1576, V t_1582, V s_1583, V _a1580, V _a1581, V[] _rest1577) => {
Call(eyeRub_630, V.Undef, t_1582, s_1583);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self603, int _argc1584, V t_1590, V s_1591, V _a1588, V _a1589, V[] _rest1585) => {
Call(leanIn_626, V.Undef, t_1590, s_1591, NewObj(1).Put("lid", ((V)(0.3))).V);
Invoke(t_1590, "to", ((V)(200D)), NewObj(1).Put("lid", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self603, int _argc1592, V t_1598, V s_1599, V _a1596, V _a1597, V[] _rest1593) => {
Call(tickle_634, V.Undef, t_1598, Fn((V _self603, int _argc1600, V u_1606, V _a1603, V _a1604, V _a1605, V[] _rest1601) => {
return Invoke(Invoke(u_1606, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("lid", ((V)(0.6))).V, NewObj(1).Put("lid", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("lid", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self603, int _argc1607, V t_1613, V s_1614, V _a1611, V _a1612, V[] _rest1608) => {
Call(jelly_619, V.Undef, t_1613, ((V)(3D)), ((V)(3D)), ((V)(300D)), ((V)("bend")));
Invoke(t_1613, "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(2D)));
Call(see_620, V.Undef, t_1613, ((V)("side")), s_1614, ((V)(200D)));
Call(unsee_621, V.Undef, t_1613, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self603, int _argc1615, V t_1621, V s_1622, V _a1619, V _a1620, V[] _rest1616) => {
Call(hop_633, V.Undef, t_1621, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)))), NewObj(2).Put("air", NewObj(1).Put("lid", ((V)(0.7))).V).Put("fall", NewObj(1).Put("lid", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self603, int _argc1623, V t_1629, V s_1630, V _a1627, V _a1628, V[] _rest1624) => {
Invoke(t_1629, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
Call(lookBack_632, V.Undef, t_1629);
return default;
}, 2, "tail", true)).V).Put("flossie", NewObj(9).Put("head", Fn((V _self603, int _argc1631, V t_1637, V s_1638, V _a1635, V _a1636, V[] _rest1632) => {
Invoke(Invoke(Invoke(t_1637, "to", ((V)(150D)), NewObj(2).Put("fluff", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(2D))), "to", ((V)(500D)), NewObj(2).Put("fluff", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(giggle_622, V.Undef, t_1637, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self603, int _argc1639, V t_1645, V s_1646, V _a1643, V _a1644, V[] _rest1640) => {
Call(see_620, V.Undef, t_1645, ((V)("ear")), s_1646, ((V)(150D)));
Invoke(Invoke(t_1645, "to", ((V)(600D)), NewObj(1).Put("swirl", ((V)((ToNum(s_1646) * 0.3)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("io")));
Call(unsee_621, V.Undef, t_1645);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self603, int _argc1647, V t_1653, V s_1654, V _a1651, V _a1652, V[] _rest1648) => {
return Call(nose_637, V.Undef, t_1653, Fn((V _self603, int _argc1655, V u_1661, V _a1658, V _a1659, V _a1660, V[] _rest1656) => {
Call(sniff_623, V.Undef, u_1661, ((V)(2D)));
Call(tasteHeart_635, V.Undef, u_1661);
return default;
}, 1, "", true));
}, 2, "nose", true)).Put("eye", Fn((V _self603, int _argc1662, V t_1668, V s_1669, V _a1666, V _a1667, V[] _rest1663) => {
Call(eyeRub_630, V.Undef, t_1668, s_1669);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self603, int _argc1670, V t_1676, V s_1677, V _a1674, V _a1675, V[] _rest1671) => {
Call(leanIn_626, V.Undef, t_1676, s_1677, NewObj(1).Put("fluff", ((V)(0.4))).V);
Invoke(t_1676, "to", ((V)(200D)), NewObj(1).Put("fluff", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self603, int _argc1678, V t_1684, V s_1685, V _a1682, V _a1683, V[] _rest1679) => {
Call(tickle_634, V.Undef, t_1684, Fn((V _self603, int _argc1686, V u_1692, V _a1689, V _a1690, V _a1691, V[] _rest1687) => {
return Invoke(Invoke(u_1692, "to", ((V)(300D)), NewObj(1).Put("fluff", ((V)(1D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("fluff", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self603, int _argc1693, V t_1699, V s_1700, V _a1697, V _a1698, V[] _rest1694) => {
Invoke(Invoke(t_1699, "to", ((V)(500D)), NewObj(2).Put("swirl", ((V)(((-ToNum(s_1700)) * 0.4)))).Put("x", ((V)(((-ToNum(s_1700)) * 2D)))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(2).Put("swirl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Call(see_620, V.Undef, t_1699, ((V)("side")), s_1700, ((V)(200D)));
Call(unsee_621, V.Undef, t_1699, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self603, int _argc1701, V t_1707, V s_1708, V _a1705, V _a1706, V[] _rest1702) => {
Call(hop_633, V.Undef, t_1707, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(2D)))), NewObj(2).Put("air", NewObj(1).Put("fluff", ((V)(0.8))).V).Put("fall", NewObj(1).Put("fluff", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self603, int _argc1709, V t_1715, V s_1716, V _a1713, V _a1714, V[] _rest1710) => {
Invoke(Invoke(t_1715, "to", ((V)(200D)), NewObj(1).Put("fluff", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("fluff", ((V)(0D))).V, ((V)("io")));
Call(lookBack_632, V.Undef, t_1715);
return default;
}, 2, "tail", true)).V).V;
TXT_640 = NewObj(11).Put("frankie", NewObj(9).Put("head", ((V)("His bun hugs the sausage tight, a squirt of mustard, a giggle."))).Put("ear", ((V)("The sausage slides out the other end - he pushes it back with a paw."))).Put("nose", ((V)("Sniffs your finger and licks it: a heart."))).Put("eye", ((V)("Blinks hard and rubs the eye."))).Put("cheek", ((V)("Leans into your finger, his bun squeezes a little."))).Put("belly", ((V)("Ticklish bun: giggles while the sausage slides back and forth."))).Put("side", ((V)("The sausage slides away from the poke and back, he looks."))).Put("foot", ((V)("A hop - the sausage slides as he lands."))).Put("tail", ((V)("The bun opens a little, he looks back."))).V).Put("corny", NewObj(9).Put("head", ((V)("Pop! Kernels jump up and fall back in, she giggles."))).Put("ear", ((V)("A few kernels pop and she fizzes."))).Put("nose", ((V)("Sniffs your finger, fizzes with happiness."))).Put("eye", ((V)("Blinks and rubs her eye."))).Put("cheek", ((V)("Leans in, fizzing a little."))).Put("belly", ((V)("Ticklish stripes: giggles, popcorn popping."))).Put("side", ((V)("Rocks away, popcorn bouncing, looks at the spot."))).Put("foot", ((V)("Hops - all the popcorn jumps."))).Put("tail", ((V)("A few kernels hop, she looks back."))).V).Put("peppi", NewObj(9).Put("head", ((V)("His crust lifts and the cheese stretches, he giggles."))).Put("ear", ((V)("Tilts at the poke on his crust corner."))).Put("nose", ((V)("Sniffs your finger and licks it: a cheesy heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his tip flopping."))).Put("belly", ((V)("Ticklish pepperoni: giggles, tip flapping."))).Put("side", ((V)("Wobbles like a soft slice, looks at the spot."))).Put("foot", ((V)("His tip flops and wobbles, he looks down."))).Put("tail", ((V)("His tip flips back, he looks behind."))).V).Put("nori", NewObj(9).Put("head", ((V)("His salmon flakes hop up with a sparkle, he giggles."))).Put("ear", ((V)("Looks up at his rice corner, blushes, a little bow."))).Put("nose", ((V)("Sniffs your finger politely, then a lick: a heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, blushing."))).Put("belly", ((V)("Oh no, his seaweed jacket slips - he blushes and tugs it back."))).Put("side", ((V)("Wobbles, a few rice grains fall, he looks."))).Put("foot", ((V)("A neat little hop, rice grains fly."))).Put("tail", ((V)("A grain of rice drops, he looks back."))).V).Put("sunny", NewObj(9).Put("head", ((V)("Her shell cap pops up and drops back on, the yolk wobbles, she giggles."))).Put("ear", ((V)("Looks at the tap on her shell and pats it."))).Put("nose", ((V)("Sniffs your finger and licks it: a heart."))).Put("eye", ((V)("Blinks and rubs her eye."))).Put("cheek", ((V)("Leans into your finger, her cap lifting a little."))).Put("belly", ((V)("Ticklish tummy: giggles, rocking on her round bottom."))).Put("side", ((V)("Rolls a little away from the poke and wobbles back upright."))).Put("foot", ((V)("Tap her round bottom: she rocks right over and wobbles back, giggling."))).Put("tail", ((V)("A soft wobble, she looks back."))).V).Put("toco", NewObj(9).Put("head", ((V)("His shell snaps shut and pops open, lettuce flies."))).Put("ear", ((V)("Opens his shell and pats his lettuce back in."))).Put("nose", ((V)("Sniffs, a crunchy little chomp, then licks your finger."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his shell closing a little."))).Put("belly", ((V)("Ticklish shell: giggles, snapping like castanets."))).Put("side", ((V)("Wobbles, a lettuce leaf falls, he looks."))).Put("foot", ((V)("Hops, his shell opens in the air."))).Put("tail", ((V)("Snaps his shell, looks back."))).V).Put("churro", NewObj(9).Put("head", ((V)("Sugar puffs off him and his ridges twist, he giggles."))).Put("ear", ((V)("Reaches up and dabs his chocolate top."))).Put("nose", ((V)("Sniffs your finger and licks it: a sweet heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, a little twist."))).Put("belly", ((V)("Ticklish ridges: giggles, twisting like a corkscrew."))).Put("side", ((V)("Twists away from the poke and back, looks."))).Put("foot", ((V)("A hop, sugar falls."))).Put("tail", ((V)("Sugar sprinkles off, he looks back."))).V).Put("khinki", NewObj(9).Put("head", ((V)("His top knot flicks like a ponytail, he giggles."))).Put("ear", ((V)("His pleats twist round from the poke."))).Put("nose", ((V)("Sniffs your finger and licks it: a heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans into your finger, his knot tipping."))).Put("belly", ((V)("So juicy: a squirt of broth, then he giggles, knot wagging."))).Put("side", ((V)("A doughy wobble, his knot flicks, he looks."))).Put("foot", ((V)("A hop, his knot bounces."))).Put("tail", ((V)("A sprinkle of pepper, he looks back."))).V).Put("maki", NewObj(9).Put("head", ((V)("His salmon and veggies pop up out of the rice, he giggles."))).Put("ear", ((V)("Looks at his rice rim, the veggies bob."))).Put("nose", ((V)("Sniffs your finger and licks it: a heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Ticklish rice: rocks with giggles, veggies wiggling."))).Put("side", ((V)("Turns away like a spinning top and back."))).Put("foot", ((V)("A hop, rice grains fly."))).Put("tail", ((V)("A grain of rice falls, he looks back."))).V).Put("noodle", NewObj(9).Put("head", ((V)("Steam puffs out, his noodles slurp, he giggles."))).Put("ear", Fn((V _self603, int _argc1717, V s_1723, V _a1720, V _a1721, V _a1722, V[] _rest1718) => {
return ((V)((GtN(s_1723, 0D) ? "His chopsticks bob up and down with noodles." : "His noodles slurp up out of reach.")));
}, 1, "ear", true)).Put("nose", ((V)("Sniffs your finger, steam, then a lick: a heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his chopsticks lifting a few noodles."))).Put("belly", ((V)("Ticklish band: giggles, chopsticks bobbing."))).Put("side", ((V)("Wobbles, a splash of broth, he looks."))).Put("foot", ((V)("A hop that lifts his chopsticks."))).Put("tail", ((V)("A puff of steam, he looks back."))).V).Put("flossie", NewObj(9).Put("head", ((V)("Her floss poofs up big, she giggles."))).Put("ear", ((V)("Her floss swirls round from the poke."))).Put("nose", ((V)("Sniffs your finger and licks it: a sugary heart."))).Put("eye", ((V)("Blinks and rubs her eye."))).Put("cheek", ((V)("Leans into your finger, fluffing up."))).Put("belly", ((V)("Ticklish floss: giggles and poofs."))).Put("side", ((V)("Her floss swirls away from the poke and back."))).Put("foot", ((V)("A hop, her floss poofs."))).Put("tail", ((V)("A soft poof, she looks back."))).V).V;
Call(build_628, V.Undef, RE_639, TXT_640, BODY_638);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_1747 => Fn((V _self1724, int _argc1725, V _a1727, V _a1728, V _a1729, V _a1730, V[] _rest1726) => {
V R_1731 = default;
V hand_1732 = default;
V both_1733 = default;
V o_1734 = default;
V NOHANDS_1735 = default;
V jump_1736 = default;
V swing_1737 = default;
V jelly_1738 = default;
V EAR_1739 = default;
V sniffF_1740 = default;
V lipLick_1741 = default;
V hearts_1742 = default;
V pat_1743 = default;
V buildAll_1744 = default;
V hop_1745 = default;
V CARDS_1746 = default;
if (_self1724.IsNullish) _self1724 = GlobalV;
R_1731 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_1731)) || !(Truthy(Get(R_1731, "EATKIT")))) || !(Truthy(Get(R_1731, "snack2V")))) || !(Truthy(Get(R_1731, "EATLIB"))))) {
Call(G("setTimeout"), V.Undef, boot_1747.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_1731, "snack2EatV"))) {
return default;
}
Set(R_1731, "snack2EatV", ((V)(1D)));
{ V _t1748 = Get(R_1731, "PETLIB");
if (_t1748.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1748));
{ V _t1749 = Get(_t1748, "hand");
hand_1732 = _t1749; }
{ V _t1750 = Get(_t1748, "both");
both_1733 = _t1750; }
{ V _t1751 = Get(_t1748, "o");
o_1734 = _t1751; }
{ V _t1752 = Get(_t1748, "NOHANDS");
NOHANDS_1735 = _t1752; }
{ V _t1753 = Get(_t1748, "jump");
jump_1736 = _t1753; }
{ V _t1754 = Get(_t1748, "swing");
swing_1737 = _t1754; }
{ V _t1755 = Get(_t1748, "jelly");
jelly_1738 = _t1755; } }
{ V _t1756 = Get(R_1731, "EATKIT");
if (_t1756.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1756));
{ V _t1757 = Get(_t1756, "EAR");
EAR_1739 = _t1757; }
{ V _t1758 = Get(_t1756, "sniffF");
sniffF_1740 = _t1758; }
{ V _t1759 = Get(_t1756, "lipLick");
lipLick_1741 = _t1759; }
{ V _t1760 = Get(_t1756, "hearts");
hearts_1742 = _t1760; }
{ V _t1761 = Get(_t1756, "pat");
pat_1743 = _t1761; }
{ V _t1762 = Get(_t1756, "buildAll");
buildAll_1744 = _t1762; } }
Object_assign(EAR_1739, NewObj(11).Put("frankie", ((V)(0.6))).Put("corny", ((V)(0.6))).Put("peppi", ((V)(0.6))).Put("nori", ((V)(0.6))).Put("sunny", ((V)(0.6))).Put("toco", ((V)(0.6))).Put("churro", ((V)(0.6))).Put("khinki", ((V)(0.6))).Put("maki", ((V)(0.6))).Put("noodle", ((V)(0.6))).Put("flossie", ((V)(0.6))).V);
hop_1745 = Fn((V _self1724, int _argc1763, V t_1769, V h_1770, V x_1771, V _a1768, V[] _rest1764) => {
return Call(jump_1736, V.Undef, t_1769, Call(o_1734, V.Undef, NewObj(5).Put("h", (h_1770 is var _t1772 && Truthy(_t1772) ? _t1772 : ((V)(6D)))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).V, (x_1771 is var _t1773 && Truthy(_t1773) ? _t1773 : NewObj(0).V)));
}, 3, "", true);
CARDS_1746 = NewObj(11).Put("frankie", NewObj(8).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.8))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("A squirt of mustard first, big happy bites, then hugs his sausage in his bun when he likes it."))).Put("pre", Fn((V _self1724, int _argc1774, V t_1780, V _a1777, V _a1778, V _a1779, V[] _rest1775) => {
return Invoke(Invoke(Invoke(t_1780, "to", ((V)(200D)), NewObj(1).Put("hug", ((V)((-0.5)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mustard")), ((V)("head")), ((V)(2D))), "to", ((V)(220D)), NewObj(1).Put("hug", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1724, int _argc1781, V t_1787, V _a1784, V _a1785, V _a1786, V[] _rest1782) => {
return Call(lipLick_1741, V.Undef, t_1787);
}, 1, "post", true)).Put("yum", Fn((V _self1724, int _argc1788, V t_1794, V _a1791, V _a1792, V _a1793, V[] _rest1789) => {
Invoke(Invoke(Invoke(t_1794, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("hug", ((V)((-0.7)))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("hug", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(hop_1745, V.Undef, t_1794, ((V)(6D)), NewObj(2).Put("air", NewObj(1).Put("slip", ((V)(0.4))).V).Put("fall", NewObj(1).Put("slip", ((V)(0D))).V).V);
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1724, int _argc1795, V t_1801, V _a1798, V _a1799, V _a1800, V[] _rest1796) => {
Call(hearts_1742, V.Undef, t_1801, ((V)(2D)));
Invoke(Get(CARDS_1746, "frankie"), "yum", t_1801);
return default;
}, 1, "love", true)).V).Put("corny", NewObj(9).Put("chewMs", ((V)(115D))).Put("chewN", ((V)(0.9))).Put("crumbs", ((V)(2D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Quick crunchy nibbles, fizzing with excitement; her popcorn pops when she likes it."))).Put("pre", Fn((V _self1724, int _argc1802, V t_1808, V _a1805, V _a1806, V _a1807, V[] _rest1803) => {
Call(sniffF_1740, V.Undef, t_1808, ((V)(1D)));
Invoke(t_1808, "to", ((V)(150D)), NewObj(1).Put("cfz", ((V)(0.6))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1724, int _argc1809, V t_1815, V _a1812, V _a1813, V _a1814, V[] _rest1810) => {
return Invoke(t_1815, "to", ((V)(200D)), NewObj(1).Put("cfz", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1724, int _argc1816, V t_1822, V _a1819, V _a1820, V _a1821, V[] _rest1817) => {
Invoke(Invoke(Invoke(Invoke(t_1822, "to", ((V)(140D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("pop", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("popk")), ((V)("head")), ((V)(3D))), "to", ((V)(380D)), NewObj(1).Put("pop", ((V)(0D))).V, ((V)("i")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1724, int _argc1823, V t_1829, V _a1826, V _a1827, V _a1828, V[] _rest1824) => {
Call(hearts_1742, V.Undef, t_1829, ((V)(2D)));
Invoke(Get(CARDS_1746, "corny"), "yum", t_1829);
Call(hop_1745, V.Undef, t_1829, ((V)(6D)), NewObj(2).Put("air", NewObj(1).Put("pop", ((V)(0.8))).V).Put("fall", NewObj(1).Put("pop", ((V)(0D))).V).V);
return default;
}, 1, "love", true)).V).Put("peppi", NewObj(10).Put("savor", ((V)(0.5))).Put("chewMs", ((V)(140D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Lazy, cheesy bites (a string of cheese stretches), then a floppy happy sway."))).Put("pre", Fn((V _self1724, int _argc1830, V t_1836, V _a1833, V _a1834, V _a1835, V[] _rest1831) => {
return Call(sniffF_1740, V.Undef, t_1836, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _self1724, int _argc1837, V t_1843, V _a1840, V _a1841, V _a1842, V[] _rest1838) => {
return Invoke(Invoke(t_1843, "to", ((V)(200D)), NewObj(1).Put("pull", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("pull", ((V)(0D))).V, ((V)("i")));
}, 1, "post", true)).Put("yum", Fn((V _self1724, int _argc1844, V t_1850, V _a1847, V _a1848, V _a1849, V[] _rest1845) => {
Invoke(t_1850, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(swing_1737, V.Undef, t_1850, ((V)(1100D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("flop", ((V)(0.6))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1724, int _argc1851, V t_1857, V _a1854, V _a1855, V _a1856, V[] _rest1852) => {
Call(hearts_1742, V.Undef, t_1857, ((V)(2D)));
Invoke(Invoke(t_1857, "to", ((V)(300D)), NewObj(2).Put("pull", ((V)(1D))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("pull", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i")));
Invoke(Get(CARDS_1746, "peppi"), "yum", t_1857);
return default;
}, 1, "love", true)).V).Put("nori", NewObj(9).Put("chewMs", ((V)(135D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("A polite little bow first, small neat bites, his salmon flakes hop when he likes it."))).Put("pre", Fn((V _self1724, int _argc1858, V t_1864, V _a1861, V _a1862, V _a1863, V[] _rest1859) => {
return Invoke(Invoke(t_1864, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.16)))).Put("close", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1724, int _argc1865, V t_1871, V _a1868, V _a1869, V _a1870, V[] _rest1866) => {
return Call(lipLick_1741, V.Undef, t_1871);
}, 1, "post", true)).Put("yum", Fn((V _self1724, int _argc1872, V t_1878, V _a1875, V _a1876, V _a1877, V[] _rest1873) => {
Invoke(Invoke(Invoke(Invoke(t_1878, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("ume", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(1).Put("ume", ((V)(0D))).V, ((V)("i")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1724, int _argc1879, V t_1885, V _a1882, V _a1883, V _a1884, V[] _rest1880) => {
Call(hearts_1742, V.Undef, t_1885, ((V)(2D)));
Invoke(t_1885, "to", ((V)(250D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
Invoke(Get(CARDS_1746, "nori"), "yum", t_1885);
return default;
}, 1, "love", true)).V).Put("sunny", NewObj(9).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(130D))).Put("crumbs", ((V)(1D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Lifts her shell cap first (manners!), soft bites, her yolk wobbles when she likes it."))).Put("pre", Fn((V _self1724, int _argc1886, V t_1892, V _a1889, V _a1890, V _a1891, V[] _rest1887) => {
return Invoke(Invoke(Invoke(t_1892, "to", ((V)(260D)), NewObj(1).Put("cap", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(150D))), "to", ((V)(260D)), NewObj(1).Put("cap", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1724, int _argc1893, V t_1899, V _a1896, V _a1897, V _a1898, V[] _rest1894) => {
return Call(lipLick_1741, V.Undef, t_1899);
}, 1, "post", true)).Put("yum", Fn((V _self1724, int _argc1900, V t_1906, V _a1903, V _a1904, V _a1905, V[] _rest1901) => {
Invoke(Invoke(Invoke(t_1906, "to", ((V)(300D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("cap", ((V)(0.7))).Put("wob", ((V)(1.2))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(2).Put("cap", ((V)(0D))).Put("wob", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1724, int _argc1907, V t_1913, V _a1910, V _a1911, V _a1912, V[] _rest1908) => {
Call(hearts_1742, V.Undef, t_1913, ((V)(2D)));
Call(hop_1745, V.Undef, t_1913, ((V)(6D)));
Invoke(Get(CARDS_1746, "sunny"), "yum", t_1913);
return default;
}, 1, "love", true)).V).Put("toco", NewObj(10).Put("chewMs", ((V)(110D))).Put("chewN", ((V)(0.9))).Put("crumbs", ((V)(3D))).Put("open", ((V)(0.9))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Opens his shell wide, big crunchy chomps (bits of lettuce fly), castanet snaps when he likes it."))).Put("pre", Fn((V _self1724, int _argc1914, V t_1920, V _a1917, V _a1918, V _a1919, V[] _rest1915) => {
return Invoke(Invoke(Invoke(t_1920, "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0.8))).V, ((V)("o"))), "wait", ((V)(150D))), "to", ((V)(200D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1724, int _argc1921, V t_1927, V _a1924, V _a1925, V _a1926, V[] _rest1922) => {
return Call(pat_1743, V.Undef, t_1927, ((V)(1D)));
}, 1, "post", true)).Put("yum", Fn((V _self1724, int _argc1928, V t_1934, V _a1931, V _a1932, V _a1933, V[] _rest1929) => {
Invoke(t_1934, "to", ((V)(140D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
{
V i_1935 = default;
i_1935 = ((V)(0D));
while (true) {
if (!(LtN(i_1935, 2D))) break;
Invoke(Invoke(Invoke(t_1934, "to", ((V)(100D)), NewObj(1).Put("snap", ((V)((-0.5)))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(1).Put("snap", ((V)(0.5))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("lettuce")), ((V)("head")), ((V)(1D)));
PostInc(ref i_1935, 1D);
}
}
Invoke(t_1934, "to", ((V)(150D)), NewObj(1).Put("snap", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1724, int _argc1937, V t_1943, V _a1940, V _a1941, V _a1942, V[] _rest1938) => {
Call(hearts_1742, V.Undef, t_1943, ((V)(2D)));
Invoke(Get(CARDS_1746, "toco"), "yum", t_1943);
return default;
}, 1, "love", true)).V).Put("churro", NewObj(8).Put("chewMs", ((V)(120D))).Put("crumbs", ((V)(2D))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Dips it first like a churro in chocolate, crunchy bites, twists happily when he likes it."))).Put("pre", Fn((V _self1724, int _argc1944, V t_1950, V _a1947, V _a1948, V _a1949, V[] _rest1945) => {
return Invoke(Invoke(Invoke(t_1950, "to", ((V)(320D)), NewObj(3).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.9))).Put("sq", ((V)(0.04))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0.07))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)(0D))).Put("ly", ((V)(0.3))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1724, int _argc1951, V t_1957, V _a1954, V _a1955, V _a1956, V[] _rest1952) => {
return Call(lipLick_1741, V.Undef, t_1957, (true ? V.True : V.False));
}, 1, "post", true)).Put("yum", Fn((V _self1724, int _argc1958, V t_1964, V _a1961, V _a1962, V _a1963, V[] _rest1959) => {
Invoke(Invoke(Invoke(Invoke(t_1964, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("cork", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("cork", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("sugar")), ((V)("head")), ((V)(3D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1724, int _argc1965, V t_1971, V _a1968, V _a1969, V _a1970, V[] _rest1966) => {
Call(hearts_1742, V.Undef, t_1971, ((V)(2D)));
Invoke(Get(CARDS_1746, "churro"), "yum", t_1971);
return default;
}, 1, "love", true)).V).Put("khinki", NewObj(9).Put("chewMs", ((V)(130D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.75))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("A careful first nibble and a slurp of the juice (the khinkali way), then big bites; his knot wags when he likes it."))).Put("pre", Fn((V _self1724, int _argc1972, V t_1978, V _a1975, V _a1976, V _a1977, V[] _rest1973) => {
Call(sniffF_1740, V.Undef, t_1978, ((V)(1D)));
Invoke(Invoke(Invoke(t_1978, "to", ((V)(200D)), NewObj(3).Put("open", ((V)(0.25))).Put("mw", ((V)(0.5))).Put("puff", ((V)((-0.3)))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1724, int _argc1979, V t_1985, V _a1982, V _a1983, V _a1984, V[] _rest1980) => {
return Call(lipLick_1741, V.Undef, t_1985);
}, 1, "post", true)).Put("yum", Fn((V _self1724, int _argc1986, V t_1992, V _a1989, V _a1990, V _a1991, V[] _rest1987) => {
Invoke(Invoke(Invoke(t_1992, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(3D)), NewObj(1).Put("knot", ((V)(0.6))).V, NewObj(1).Put("knot", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("knot", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1724, int _argc1993, V t_1999, V _a1996, V _a1997, V _a1998, V[] _rest1994) => {
Call(hearts_1742, V.Undef, t_1999, ((V)(2D)));
Invoke(t_1999, "e", ((V)("emit")), ((V)("broth")), ((V)("head")), ((V)(2D)));
Invoke(Get(CARDS_1746, "khinki"), "yum", t_1999);
return default;
}, 1, "love", true)).V).Put("maki", NewObj(10).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(140D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Calm, careful bites with his eyes closed; his salmon and veggies pop up when he likes it."))).Put("pre", Fn((V _self1724, int _argc2000, V t_2006, V _a2003, V _a2004, V _a2005, V[] _rest2001) => {
return Invoke(Invoke(Invoke(t_2006, "to", ((V)(260D)), NewObj(1).Put("close", ((V)(0.7))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1724, int _argc2007, V t_2013, V _a2010, V _a2011, V _a2012, V[] _rest2008) => {
return Call(lipLick_1741, V.Undef, t_2013);
}, 1, "post", true)).Put("yum", Fn((V _self1724, int _argc2014, V t_2020, V _a2017, V _a2018, V _a2019, V[] _rest2015) => {
Invoke(Invoke(Invoke(t_2020, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).Put("veg", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("veg", ((V)(0D))).V, ((V)("io")));
Call(swing_1737, V.Undef, t_2020, ((V)(1000D)), ((V)(3D)), NewObj(1).Put("tilt", ((V)(6D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1724, int _argc2021, V t_2027, V _a2024, V _a2025, V _a2026, V[] _rest2022) => {
Call(hearts_1742, V.Undef, t_2027, ((V)(2D)));
Invoke(Get(CARDS_1746, "maki"), "yum", t_2027);
return default;
}, 1, "love", true)).V).Put("noodle", NewObj(9).Put("chewMs", ((V)(125D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Blows on it (steam), slurps it up, his chopsticks bob happily."))).Put("pre", Fn((V _self1724, int _argc2028, V t_2034, V _a2031, V _a2032, V _a2033, V[] _rest2029) => {
return Invoke(Invoke(Invoke(Invoke(t_2034, "to", ((V)(250D)), NewObj(3).Put("puff", ((V)(0.6))).Put("pitch", ((V)((-0.08)))).Put("ly", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(3).Put("puff", ((V)((-0.3)))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("steam")), ((V)("mouth")), ((V)(2D))), "to", ((V)(260D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1724, int _argc2035, V t_2041, V _a2038, V _a2039, V _a2040, V[] _rest2036) => {
return Invoke(Invoke(t_2041, "to", ((V)(260D)), NewObj(1).Put("slurp", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("slurp", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1724, int _argc2042, V t_2048, V _a2045, V _a2046, V _a2047, V[] _rest2043) => {
Invoke(Invoke(Invoke(Invoke(t_2048, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(3D)), NewObj(1).Put("lid", ((V)(0.7))).V, NewObj(1).Put("lid", ((V)((-0.2)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("lid", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1724, int _argc2049, V t_2055, V _a2052, V _a2053, V _a2054, V[] _rest2050) => {
Call(hearts_1742, V.Undef, t_2055, ((V)(2D)));
Invoke(Get(CARDS_1746, "noodle"), "yum", t_2055);
return default;
}, 1, "love", true)).V).Put("flossie", NewObj(11).Put("savor", ((V)(0.7))).Put("chewMs", ((V)(150D))).Put("chewN", ((V)(1D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Dainty little bites, savours it dreamily, poofs up fluffy when she likes it."))).Put("pre", Fn((V _self1724, int _argc2056, V t_2062, V _a2059, V _a2060, V _a2061, V[] _rest2057) => {
return Call(sniffF_1740, V.Undef, t_2062, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _self1724, int _argc2063, V t_2069, V _a2066, V _a2067, V _a2068, V[] _rest2064) => {
return Invoke(Invoke(Invoke(t_2069, "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0.6))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(250D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1724, int _argc2070, V t_2076, V _a2073, V _a2074, V _a2075, V[] _rest2071) => {
Invoke(Invoke(Invoke(t_2076, "to", ((V)(300D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("fluff", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("floss")), ((V)("head")), ((V)(2D))), "to", ((V)(600D)), NewObj(1).Put("fluff", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).Put("love", Fn((V _self1724, int _argc2077, V t_2083, V _a2080, V _a2081, V _a2082, V[] _rest2078) => {
Call(hearts_1742, V.Undef, t_2083, ((V)(2D)));
Invoke(t_2083, "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
Invoke(Get(CARDS_1746, "flossie"), "yum", t_2083);
return default;
}, 1, "love", true)).V).V;
Call(buildAll_1744, V.Undef, CARDS_1746);
return default;
}, 0, "boot", false)), V.Undef);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
