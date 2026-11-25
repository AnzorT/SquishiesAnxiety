// fruit-anims.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_fruit_anims_js
    {

        public static void Run()
        {
Call(Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V CH_8 = default;
V OLD_9 = default;
V NEW_10 = default;
V KEYS_11 = default;
V drop_12 = default;
V preset_13 = default;
V JUICE_14 = default;
if (_self1.IsNullish) _self1 = GlobalV;
CH_8 = NewObj(9).Put("lf", ((V)(0D))).Put("stw", ((V)(0D))).Put("crf", ((V)(0D))).Put("jig", ((V)(0D))).Put("pol", ((V)(0D))).Put("cv", ((V)(0D))).Put("fz", ((V)(0D))).Put("rl", ((V)(0D))).Put("rig", ((V)(0D))).V;
OLD_9 = Arr(((V)("pina")), ((V)("avo")), ((V)("berri")), ((V)("lemmy")), ((V)("kiwi")), ((V)("melo")), ((V)("peachy")), ((V)("pitaya")), ((V)("tutti")));
NEW_10 = Arr(((V)("nana")), ((V)("bing")), ((V)("plummy")), ((V)("clemmy")), ((V)("appy")), ((V)("blueby")), ((V)("coco")), ((V)("perry")), ((V)("grana")), ((V)("mangie")), ((V)("razzy")));
KEYS_11 = Invoke(OLD_9, "concat", NEW_10);
drop_12 = Fn((V _arrowThis23, int _argc15, V c_21, V x_22, V _a19, V _a20, V[] _rest16) => {
return Object_assign(NewObj(8).Put("n", ((V)(5D))).Put("sp", ((V)(22D))).Put("vy", ((V)((-20D)))).Put("g", ((V)(90D))).Put("life", ((V)(800D))).Put("r", Arr(((V)(0.8)), ((V)(1.3)))).Put("col", c_21).Put("kind", ((V)("drop"))).V, (x_22 is var _t24 && Truthy(_t24) ? _t24 : NewObj(0).V));
}, 2, "", true);
preset_13 = Fn((V _arrowThis32, int _argc25, V R_31, V _a28, V _a29, V _a30, V[] _rest26) => {
V P_33 = default;
P_33 = Get(R_31, "PRE");
if (Truthy(((!(Truthy(P_33)) ? V.True : V.False) is var _t34 && Truthy(_t34) ? _t34 : Get(P_33, "zest")))) {
return default;
}
Object_assign(P_33, NewObj(15).Put("pinjuice", Call(drop_12, V.Undef, Arr(((V)("#ffd84a")), ((V)("#fff3a0")), ((V)("#f2b81c"))))).Put("guac", Call(drop_12, V.Undef, Arr(((V)("#a8d86a")), ((V)("#d6f0a0")), ((V)("#6aa83a"))), NewObj(2).Put("kind", ((V)("dot"))).Put("r", Arr(((V)(0.7)), ((V)(1.2)))).V)).Put("banjuice", Call(drop_12, V.Undef, Arr(((V)("#fff3a0")), ((V)("#ffe14a")), ((V)("#f2c41c"))))).Put("chjuice", Call(drop_12, V.Undef, Arr(((V)("#e3263a")), ((V)("#ff6a7a")), ((V)("#9c0f26"))))).Put("pljuice", Call(drop_12, V.Undef, Arr(((V)("#8e2a6e")), ((V)("#d070b0")), ((V)("#5a1050"))))).Put("zest", NewObj(8).Put("n", ((V)(6D))).Put("sp", ((V)(28D))).Put("vy", ((V)((-18D)))).Put("g", ((V)(50D))).Put("life", ((V)(700D))).Put("r", Arr(((V)(0.45)), ((V)(0.8)))).Put("col", Arr(((V)("#ff9a26")), ((V)("#ffd9a0")), ((V)("#ffb84a")), ((V)("#ffffff")))).Put("kind", ((V)("dot"))).V).Put("apjuice", Call(drop_12, V.Undef, Arr(((V)("#b8f070")), ((V)("#e8ffb0")), ((V)("#8ed84a"))))).Put("bljuice", Call(drop_12, V.Undef, Arr(((V)("#5866d6")), ((V)("#9aa6ff")), ((V)("#2a3482"))))).Put("cocomilk", Call(drop_12, V.Undef, Arr(((V)("#ffffff")), ((V)("#f4efe6")), ((V)("#fffaf0"))))).Put("fibre", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(18D))).Put("vy", ((V)((-14D)))).Put("g", ((V)(70D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.5)), ((V)(0.8)))).Put("col", Arr(((V)("#5a3820")), ((V)("#8a5a30")), ((V)("#3e2614")))).Put("kind", ((V)("seed"))).V).Put("pearjuice", Call(drop_12, V.Undef, Arr(((V)("#e8f59a")), ((V)("#c6de4a")), ((V)("#fffbd0"))))).Put("arils", NewObj(8).Put("n", ((V)(6D))).Put("sp", ((V)(24D))).Put("vy", ((V)((-24D)))).Put("g", ((V)(90D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.8)), ((V)(1.1)))).Put("col", Arr(((V)("#d42a3a")), ((V)("#ff6a7a")), ((V)("#a8102a")))).Put("kind", ((V)("seed"))).V).Put("mjuice", Call(drop_12, V.Undef, Arr(((V)("#ffa83a")), ((V)("#ffd27a")), ((V)("#e45a2a"))))).Put("rzjuice", Call(drop_12, V.Undef, Arr(((V)("#ec3a6c")), ((V)("#ff8fb0")), ((V)("#a81846"))))).Put("knock", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(6D))).Put("vy", ((V)((-12D)))).Put("g", ((V)((-2D)))).Put("life", ((V)(1100D))).Put("r", Arr(((V)(1D)), ((V)(1D)))).Put("col", Arr(((V)("#8a5a30")), ((V)("#5a3820")))).Put("kind", ((V)("note"))).V).V);
return default;
}, 1, "", true);
JUICE_14 = NewObj(20).Put("pina", ((V)("pinjuice"))).Put("avo", ((V)("guac"))).Put("berri", ((V)("juice"))).Put("lemmy", ((V)("lemjuice"))).Put("kiwi", ((V)("kiwijuice"))).Put("melo", ((V)("melojuice"))).Put("peachy", ((V)("peachjuice"))).Put("pitaya", ((V)("pitjuice"))).Put("tutti", ((V)("fruitjuice"))).Put("nana", ((V)("banjuice"))).Put("bing", ((V)("chjuice"))).Put("plummy", ((V)("pljuice"))).Put("clemmy", ((V)("zest"))).Put("appy", ((V)("apjuice"))).Put("blueby", ((V)("bljuice"))).Put("coco", ((V)("cocomilk"))).Put("perry", ((V)("pearjuice"))).Put("grana", ((V)("arils"))).Put("mangie", ((V)("mjuice"))).Put("razzy", ((V)("rzjuice"))).V;
Call(Named(boot_65 => Fn((V _self35, int _argc36, V _a38, V _a39, V _a40, V _a41, V[] _rest37) => {
V R_42 = default;
V TL_43 = default;
V hand_44 = default;
V both_45 = default;
V o_46 = default;
V NOHANDS_47 = default;
V jump_48 = default;
V shake_49 = default;
V swing_50 = default;
V steps_51 = default;
V jelly_52 = default;
V land_53 = default;
V install_54 = default;
V natF_55 = default;
V loopN_56 = default;
V hopC_57 = default;
V J_58 = default;
V sparkle_59 = default;
V relK_60 = default;
V spinR_61 = default;
V CARDS_62 = default;
V MOVES_63 = default;
V DANCES_64 = default;
if (_self35.IsNullish) _self35 = GlobalV;
R_42 = Get(G("window"), "RiveRig");
if (((((!(Truthy(R_42)) || !(Truthy(Get(R_42, "PETLIB")))) || !(Truthy(Get(Get(R_42, "PETLIB"), "install")))) || !(Truthy(Get(R_42, "SOFT")))) || !(Truthy(Get(R_42, "SNACKLIB"))))) {
Call(G("setTimeout"), V.Undef, boot_65.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_42, "fruitV"))) {
return default;
}
Set(R_42, "fruitV", ((V)(1D)));
Invoke(Object_keys(CH_8), "forEach", Fn((V _arrowThis73, int _argc66, V k_72, V _a69, V _a70, V _a71, V[] _rest67) => {
if (GetK(Get(R_42, "REST"), k_72).IsNullish) {
SetK(Get(R_42, "REST"), k_72, ((V)(0D)));
}
return default;
}, 1, "", true));
Call(preset_13, V.Undef, R_42);
Set(R_42, "FRUITLIB", NewObj(4).Put("KEYS", KEYS_11).Put("OLD", OLD_9).Put("NEW", NEW_10).Put("JUICE", JUICE_14).V);
{ V _t74 = Get(R_42, "PETLIB");
if (_t74.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t74));
{ V _t75 = Get(_t74, "TL");
TL_43 = _t75; }
{ V _t76 = Get(_t74, "hand");
hand_44 = _t76; }
{ V _t77 = Get(_t74, "both");
both_45 = _t77; }
{ V _t78 = Get(_t74, "o");
o_46 = _t78; }
{ V _t79 = Get(_t74, "NOHANDS");
NOHANDS_47 = _t79; }
{ V _t80 = Get(_t74, "jump");
jump_48 = _t80; }
{ V _t81 = Get(_t74, "shake");
shake_49 = _t81; }
{ V _t82 = Get(_t74, "swing");
swing_50 = _t82; }
{ V _t83 = Get(_t74, "steps");
steps_51 = _t83; }
{ V _t84 = Get(_t74, "jelly");
jelly_52 = _t84; }
{ V _t85 = Get(_t74, "land");
land_53 = _t85; }
{ V _t86 = Get(_t74, "install");
install_54 = _t86; } }
natF_55 = Get(Get(R_42, "SNACKLIB"), "natF");
Invoke(KEYS_11, "forEach", Fn((V _arrowThis94, int _argc87, V k_93, V _a90, V _a91, V _a92, V[] _rest88) => {
return Invoke(Get(R_42, "SOFT"), "add", k_93);
}, 1, "", true));
if (Truthy(Get(Get(R_42, "SNACKLIB"), "KEYS"))) {
Invoke(KEYS_11, "forEach", Fn((V _arrowThis102, int _argc95, V k_101, V _a98, V _a99, V _a100, V[] _rest96) => {
if (!(Truthy(Invoke(Get(Get(R_42, "SNACKLIB"), "KEYS"), "includes", k_101)))) {
Invoke(Get(Get(R_42, "SNACKLIB"), "KEYS"), "push", k_101);
}
return default;
}, 1, "", true));
}
loopN_56 = Fn((V _arrowThis111, int _argc103, V t_109, V n_110, V _a107, V _a108, V[] _rest104) => {
return Object_assign(Invoke(t_109, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_109, "t")) * ToNum((n_110 is var _t112 && Truthy(_t112) ? _t112 : ((V)(3D)))))))).V);
}, 2, "", true);
hopC_57 = Fn((V _arrowThis122, int _argc113, V t_119, V h_120, V x_121, V _a118, V[] _rest114) => {
return Call(jump_48, V.Undef, t_119, Call(o_46, V.Undef, NewObj(5).Put("h", (h_120 is var _t123 && Truthy(_t123) ? _t123 : ((V)(7D)))).Put("ant", ((V)(150D))).Put("up", ((V)(210D))).Put("c", ((V)(0.16))).Put("arm", ((V)(46D))).V, (x_121 is var _t124 && Truthy(_t124) ? _t124 : NewObj(0).V)));
}, 3, "", true);
J_58 = Fn((V _arrowThis135, int _argc125, V t_131, V k_132, V w_133, V n_134, V[] _rest126) => {
return Invoke(t_131, "e", ((V)("emit")), GetK(JUICE_14, k_132), (w_133 is var _t136 && Truthy(_t136) ? _t136 : ((V)("head"))), (n_134 is var _t137 && Truthy(_t137) ? _t137 : ((V)(3D))));
}, 4, "", true);
sparkle_59 = Fn((V _arrowThis146, int _argc138, V t_144, V n_145, V _a142, V _a143, V[] _rest139) => {
return Invoke(t_144, "e", ((V)("emit")), ((V)("spark")), ((V)("head")), (n_145 is var _t147 && Truthy(_t147) ? _t147 : ((V)(2D))));
}, 2, "", true);
relK_60 = Fn((V _arrowThis158, int _argc148, V ch_154, V a_155, V em_156, V x_157, V[] _rest149) => {
return NewObj(1).Put("__rel", Arr(ch_154, a_155, em_156, x_157)).V;
}, 4, "", true);
spinR_61 = Fn((V _arrowThis169, int _argc159, V t_165, V dur_166, V deg_167, V x_168, V[] _rest160) => {
V a_170 = default;
a_170 = Get(t_165, "t");
Invoke(Invoke(t_165, "to", dur_166, Call(o_46, V.Undef, NewObj(1).Put("spin", deg_167).V, (x_168 is var _t171 && Truthy(_t171) ? _t171 : NewObj(0).V)), ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
return a_170;
return default;
}, 4, "", true);
CARDS_62 = NewObj(20).Put("pina", NewObj(3).Put("T", ((V)(0.95))).Put("b", ((V)(1.1))).Put("s", ((V)(1.25))).V).Put("avo", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1.1))).Put("s", ((V)(1D))).V).Put("berri", NewObj(3).Put("T", ((V)(0.9))).Put("b", ((V)(1.2))).Put("s", ((V)(1.05))).V).Put("lemmy", NewObj(3).Put("T", ((V)(0.85))).Put("b", ((V)(0.95))).Put("s", ((V)(1D))).V).Put("kiwi", NewObj(3).Put("T", ((V)(0.85))).Put("b", ((V)(1.05))).Put("s", ((V)(0.95))).V).Put("melo", NewObj(3).Put("T", ((V)(1.1))).Put("b", ((V)(1.15))).Put("s", ((V)(1.15))).V).Put("peachy", NewObj(3).Put("T", ((V)(1.1))).Put("b", ((V)(1.15))).Put("s", ((V)(1.1))).V).Put("pitaya", NewObj(3).Put("T", ((V)(0.9))).Put("b", ((V)(1.05))).Put("s", ((V)(1.1))).V).Put("tutti", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1D))).Put("s", ((V)(1.15))).V).Put("nana", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1D))).Put("s", ((V)(1.3))).V).Put("bing", NewObj(3).Put("T", ((V)(0.9))).Put("b", ((V)(1.25))).Put("s", ((V)(1D))).V).Put("plummy", NewObj(3).Put("T", ((V)(1.1))).Put("b", ((V)(0.95))).Put("s", ((V)(1.15))).V).Put("clemmy", NewObj(3).Put("T", ((V)(0.85))).Put("b", ((V)(1.1))).Put("s", ((V)(1D))).V).Put("appy", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(1.05))).Put("s", ((V)(1D))).V).Put("blueby", NewObj(3).Put("T", ((V)(0.95))).Put("b", ((V)(1.2))).Put("s", ((V)(1.05))).V).Put("coco", NewObj(3).Put("T", ((V)(1.1))).Put("b", ((V)(0.85))).Put("s", ((V)(1.1))).V).Put("perry", NewObj(3).Put("T", ((V)(1.1))).Put("b", ((V)(1D))).Put("s", ((V)(1.25))).V).Put("grana", NewObj(3).Put("T", ((V)(1.15))).Put("b", ((V)(0.95))).Put("s", ((V)(0.95))).V).Put("mangie", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1.1))).Put("s", ((V)(1.2))).V).Put("razzy", NewObj(3).Put("T", ((V)(0.9))).Put("b", ((V)(1.2))).Put("s", ((V)(1.05))).V).V;
MOVES_63 = NewObj(20).Put("pina", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis178, int _argc172, V _a174, V _a175, V _a176, V _a177, V[] _rest173) => {
V t_179 = default;
t_179 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(swing_50, V.Undef, t_179, ((V)(1400D)), ((V)(3D)), NewObj(4).Put("tilt", ((V)(6D))).Put("x", ((V)(2D))).Put("armL", ((V)(30D))).Put("armR", ((V)((-20D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_179, "to", ((V)(160D)), NewObj(2).Put("crw", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("pinjuice")), ((V)("head")), ((V)(2D))), "to", ((V)(360D)), NewObj(2).Put("crw", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(hopC_57, V.Undef, t_179, ((V)(7D)), NewObj(2).Put("air", NewObj(1).Put("crs", ((V)(0.5))).V).Put("fall", NewObj(1).Put("crs", ((V)(0D))).V).V);
return Call(loopN_56, V.Undef, Invoke(t_179, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A happy hula sway, his crown pops open, then a hop that whirls his crown.")))).Put("surprised", Arr(Call(Fn((V _arrowThis186, int _argc180, V _a182, V _a183, V _a184, V _a185, V[] _rest181) => {
V t_187 = default;
t_187 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_187, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("crw", ((V)(1.3))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).Put("x", ((V)((-2D)))).V, ((V)("i"))), "to", ((V)(500D)), NewObj(2).Put("crw", ((V)(0.6))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(320D)), NewObj(2).Put("lx", ((V)(0.8))).Put("ly", ((V)((-0.8)))).V, ((V)("io"))), "wait", ((V)(200D)));
Invoke(Invoke(Invoke(t_187, "to", ((V)(320D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("crs", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("crw", ((V)(0D))).Put("crs", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_46, V.Undef, NOHANDS_47, NewObj(10).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("x", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
return Invoke(Invoke(t_187, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His crown leaves shoot up like hair standing on end - he looks up and pats them back down.")))).Put("squish", Arr(Call(Fn((V _arrowThis194, int _argc188, V _a190, V _a191, V _a192, V _a193, V[] _rest189) => {
V t_195 = default;
t_195 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_195, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.26))).Put("crw", ((V)(0.9))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("pinjuice")), ((V)("head")), ((V)(3D))), "wait", ((V)(220D)));
Invoke(t_195, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("crw", ((V)((-0.3)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_195, ((V)(0.6)), ((V)(3D)), ((V)(280D)), ((V)("crw")));
Call(jelly_52, V.Undef, t_195, ((V)(0.07)), ((V)(2D)), ((V)(240D)));
Invoke(t_195, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_195);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, his crown flares out with a squirt of juice, then he springs back and it wobbles.")))).Put("quirk", Arr(Call(Fn((V _arrowThis202, int _argc196, V _a198, V _a199, V _a200, V _a201, V[] _rest197) => {
V t_203 = default;
t_203 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_203, "to", ((V)(320D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.8)))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(2).Put("crs", ((V)(0.4))).Put("crw", ((V)(0.4))).V, NewObj(2).Put("crs", ((V)((-0.2)))).Put("crw", ((V)(0.1))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("crs", ((V)(0D))).Put("crw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(swing_50, V.Undef, t_203, ((V)(1200D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_203, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Crown fluff")), ((V)("Reaches up and fluffs his crown leaves like a hairdo, then a little hula sway.")))).Put("press", NewObj(1).Put("crw", ((V)(0.6))).V).Put("rel", Call(relK_60, V.Undef, ((V)("crw")), ((V)(0.6)), Arr(((V)("pinjuice")), ((V)("head")), ((V)(3D))))).V).Put("avo", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis210, int _argc204, V _a206, V _a207, V _a208, V _a209, V[] _rest205) => {
V t_211 = default;
t_211 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_211, "to", ((V)(240D)), NewObj(2).Put("prw", ((V)(1D))).Put("lfl", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("prw", ((V)((-0.6)))).Put("lfl", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("prw", ((V)(0D))).V, ((V)("io")));
Call(hopC_57, V.Undef, t_211, ((V)(7D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(2).Put("pp", ((V)(0.4))).Put("lfl", ((V)(0.8))).V).Put("fall", NewObj(2).Put("pp", ((V)(0D))).Put("lfl", ((V)(0D))).V).V);
Call(land_53, V.Undef, t_211, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
Call(hopC_57, V.Undef, t_211, ((V)(8D)), NewObj(2).Put("air", NewObj(1).Put("lsp", ((V)(0.5))).V).Put("fall", NewObj(1).Put("lsp", ((V)(1D))).V).V);
Invoke(t_211, "to", ((V)(1D)), NewObj(1).Put("lsp", ((V)(0D))).V, ((V)("l")));
return Call(loopN_56, V.Undef, Invoke(t_211, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("His pit wiggles in his belly, two hops - the pit bobs out and his leaves spin.")))).Put("surprised", Arr(Call(Fn((V _arrowThis218, int _argc212, V _a214, V _a215, V _a216, V _a217, V[] _rest213) => {
V t_219 = default;
t_219 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(t_219, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("pp", ((V)(1D))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "to", ((V)(250D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_219, "to", ((V)(300D)), NewObj(2).Put("ly", ((V)(0.9))).Put("pitch", ((V)((-0.12)))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(340D)), Call(o_46, V.Undef, Call(both_45, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(2).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V), ((V)("io"))), "to", ((V)(260D)), NewObj(1).Put("pp", ((V)(0D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("guac")), ((V)("body")), ((V)(2D))), "to", ((V)(320D)), Call(o_46, V.Undef, NOHANDS_47, NewObj(9).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("prw", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("prw", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_219, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His pit pops out of his belly - he stares at it and pushes it back in with both paws.")))).Put("squish", Arr(Call(Fn((V _arrowThis226, int _argc220, V _a222, V _a223, V _a224, V _a225, V[] _rest221) => {
V t_227 = default;
t_227 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(t_227, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.26))).Put("pp", ((V)(0.7))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(220D)));
Invoke(Invoke(t_227, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("pp", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("guac")), ((V)("body")), ((V)(3D)));
Call(jelly_52, V.Undef, t_227, ((V)(0.8)), ((V)(3D)), ((V)(300D)), ((V)("prw")));
Invoke(t_227, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_227);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, his pit squeezes out a little - he springs back and it wobbles in its socket.")))).Put("quirk", Arr(Call(Fn((V _arrowThis234, int _argc228, V _a230, V _a231, V _a232, V _a233, V[] _rest229) => {
V t_235 = default;
t_235 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(t_235, "to", ((V)(320D)), Call(o_46, V.Undef, Call(both_45, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(4).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("ly", ((V)(0.8))).Put("pitch", ((V)((-0.1)))).V), ((V)("io"))), "to", ((V)(1400D)), NewObj(1).Put("pr", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("pr", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(Invoke(t_235, "to", ((V)(300D)), Call(o_46, V.Undef, NOHANDS_47, NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("body")), ((V)(2D))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0.7))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_235, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Pit polish")), ((V)("Rubs his pit with both paws so it rolls round and shines, then a proud leaf flap.")))).Put("press", NewObj(1).Put("pp", ((V)(0.4))).V).Put("rel", Call(relK_60, V.Undef, ((V)("prw")), ((V)(1D)), Arr(((V)("guac")), ((V)("body")), ((V)(2D))), NewObj(1).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(410D)), ((V)(0D)), ((V)("io"))))).Put("pp", Arr(Arr(((V)(0D)), ((V)(0.4))), Arr(((V)(150D)), ((V)(0D)), ((V)("i"))))).Put("prw", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(1D)), ((V)("o"))), Arr(((V)(450D)), ((V)((-0.5))), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).V).V)).V).Put("berri", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis242, int _argc236, V _a238, V _a239, V _a240, V _a241, V[] _rest237) => {
V t_243 = default;
t_243 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(hopC_57, V.Undef, t_243, ((V)(7D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(2).Put("lfl", ((V)(0.8))).Put("stw", ((V)(0.6))).V).Put("fall", NewObj(2).Put("lfl", ((V)(0D))).Put("stw", ((V)(0D))).V).V);
Call(land_53, V.Undef, t_243, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
Call(hopC_57, V.Undef, t_243, ((V)(8D)), NewObj(2).Put("air", NewObj(2).Put("lsp", ((V)(0.5))).Put("lfl", ((V)(0.6))).V).Put("fall", NewObj(2).Put("lsp", ((V)(1D))).Put("lfl", ((V)(0D))).V).V);
Invoke(Invoke(Invoke(Invoke(t_243, "to", ((V)(1D)), NewObj(1).Put("lsp", ((V)(0D))).V, ((V)("l"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("juice")), ((V)("head")), ((V)(2D))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, Invoke(t_243, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Juicy bounces - his leafy top flaps and twirls, a happy squirt of juice.")))).Put("surprised", Arr(Call(Fn((V _arrowThis250, int _argc244, V _a246, V _a247, V _a248, V _a249, V[] _rest245) => {
V t_251 = default;
t_251 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_251, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(7).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("lfl", ((V)(1.3))).Put("stw", ((V)(1D))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.03))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("juice")), ((V)("head")), ((V)(2D)));
Invoke(Invoke(Invoke(Invoke(t_251, "to", ((V)(500D)), NewObj(3).Put("lfl", ((V)(0D))).Put("stw", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("ly", ((V)((-0.8)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(6).Put("ly", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_251, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His leaves fly up and his stem boings, a drop of juice - he looks up at them settling.")))).Put("squish", Arr(Call(Fn((V _arrowThis258, int _argc252, V _a254, V _a255, V _a256, V _a257, V[] _rest253) => {
V t_259 = default;
t_259 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_259, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.27))).Put("lfl", ((V)((-0.4)))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("juice")), ((V)("body")), ((V)(4D))), "wait", ((V)(220D)));
Invoke(t_259, "to", ((V)(130D)), NewObj(6).Put("sq", ((V)((-0.15)))).Put("lfl", ((V)(1D))).Put("stw", ((V)(0.8))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_259, ((V)(0.8)), ((V)(3D)), ((V)(280D)), ((V)("stw")));
Invoke(t_259, "to", ((V)(260D)), NewObj(6).Put("sq", ((V)(0D))).Put("lfl", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_259);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed so the juice runs, then he springs back - leaves up, stem boinging.")))).Put("quirk", Arr(Call(Fn((V _arrowThis266, int _argc260, V _a262, V _a263, V _a264, V _a265, V[] _rest261) => {
V t_267 = default;
t_267 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_267, "to", ((V)(320D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.8)))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("lfl", ((V)(0.7))).V, NewObj(1).Put("lfl", ((V)(0.1))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("lfl", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(3).Put("lsp", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("lsp", ((V)(0D))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(1).Put("stw", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_267, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Leaf fluff")), ((V)("Fluffs up his leafy top with both paws, gives it a twirl and a stem boing.")))).Put("press", NewObj(1).Put("lfl", ((V)(0.6))).V).Put("rel", Call(relK_60, V.Undef, ((V)("stw")), ((V)(0.9)), Arr(((V)("juice")), ((V)("head")), ((V)(3D))))).V).Put("lemmy", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis274, int _argc268, V _a270, V _a271, V _a272, V _a273, V[] _rest269) => {
V t_275 = default;
t_275 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(t_275, "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("tilt", ((V)(4D))).Put("lfl", ((V)(0.5))).V, NewObj(2).Put("tilt", ((V)((-4D)))).Put("lfl", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(hopC_57, V.Undef, t_275, ((V)(8D)), NewObj(3).Put("air", NewObj(1).Put("stw", ((V)(0.8))).V).Put("fall", NewObj(1).Put("stw", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("lemjuice")), ((V)("head")), ((V)(2D))))).V);
return Call(loopN_56, V.Undef, Invoke(t_275, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A quick zesty shimmy with his leaf flapping, then a hop that sprays a little lemon juice.")))).Put("surprised", Arr(Call(Fn((V _arrowThis282, int _argc276, V _a278, V _a279, V _a280, V _a281, V[] _rest277) => {
V t_283 = default;
t_283 = Call(TL_43, V.Undef);
Invoke(Invoke(t_283, "wait", ((V)(150D))), "to", ((V)(90D)), NewObj(4).Put("close", ((V)(0.85))).Put("mw", ((V)(0.35))).Put("puff", ((V)((-0.3)))).Put("sq", ((V)(0.05))).V, ((V)("o")));
Call(shake_49, V.Undef, t_283, NewObj(5).Put("P", ((V)(70D))).Put("head", ((V)(0.2))).Put("roll", ((V)(3D))).Put("body", ((V)(0.6))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).V);
Invoke(Invoke(Invoke(Invoke(t_283, "to", ((V)(80D)), NewObj(9).Put("close", ((V)(0D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("puff", ((V)(0D))).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.08)))).Put("lfl", ((V)(1D))).Put("stw", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("lemjuice")), ((V)("head")), ((V)(3D))), "to", ((V)(320D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i"))), "to", ((V)(400D)), NewObj(7).Put("lfl", ((V)(0D))).Put("stw", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_283, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("A sour pucker shiver, then a wide-eyed zing that pops him up and sprays juice.")))).Put("squish", Arr(Call(Fn((V _arrowThis290, int _argc284, V _a286, V _a287, V _a288, V _a289, V[] _rest285) => {
V t_291 = default;
t_291 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_291, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.18))).Put("close", ((V)(0.8))).Put("mw", ((V)(0.4))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("lemjuice")), ((V)("head")), ((V)(5D))), "wait", ((V)(250D)));
Invoke(t_291, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.1)))).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_291, ((V)(0.05)), ((V)(2D)), ((V)(220D)));
Invoke(t_291, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_291);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed like a real lemon - juice sprays, he puckers, then springs back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis298, int _argc292, V _a294, V _a295, V _a296, V _a297, V[] _rest293) => {
V t_299 = default;
t_299 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(t_299, "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0.8))).Put("hyaw", ((V)(0.15))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(120D)), NewObj(3).Put("close", ((V)(0.85))).Put("mw", ((V)(0.35))).Put("puff", ((V)((-0.3)))).V, ((V)("o")));
Call(shake_49, V.Undef, t_299, NewObj(4).Put("P", ((V)(75D))).Put("head", ((V)(0.15))).Put("roll", ((V)(2D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.7)), ((V)(0.3)))).V);
Invoke(Invoke(Invoke(t_299, "to", ((V)(300D)), NewObj(7).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_299, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sour face")), ((V)("Catches a whiff of something sour, puckers up and shivers, then grins and flaps his leaf.")))).Put("press", NewObj(2).Put("mw", ((V)(0.5))).Put("close", ((V)(0.4))).V).Put("rel", Call(relK_60, V.Undef, ((V)("stw")), ((V)(0.9)), Arr(((V)("lemjuice")), ((V)("head")), ((V)(4D))))).V).Put("kiwi", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis306, int _argc300, V _a302, V _a303, V _a304, V _a305, V[] _rest301) => {
V t_307 = default;
t_307 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
{
double i_308 = 0;
i_308 = 0D;
while (true) {
if (!((i_308 < 4D))) break;
Invoke(Invoke(t_307, "to", ((V)(170D)), NewObj(3).Put("pitch", ((V)(0.12))).Put("x", ((V)(((NumTruthy((i_308 % 2D)) ? 1D : (-1D)) * 1.5)))).PutK(((V)((NumTruthy((i_308 % 2D)) ? "footR" : "footL"))), ((V)(2.2))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(3).Put("pitch", ((V)((-0.05)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i")));
i_308++;
}
}
Invoke(Invoke(Invoke(Invoke(t_307, "to", ((V)(200D)), NewObj(2).Put("x", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(1).Put("fzz", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("kiwifuzz")), ((V)("head")), ((V)(3D))), "to", ((V)(400D)), NewObj(1).Put("fzz", ((V)(0D))).V, ((V)("io")));
Call(hopC_57, V.Undef, t_307, ((V)(6D)));
return Call(loopN_56, V.Undef, Invoke(t_307, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A bird-like strut with head bobs, a fluff-up of his fuzz, then a little hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis316, int _argc310, V _a312, V _a313, V _a314, V _a315, V[] _rest311) => {
V t_317 = default;
t_317 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_317, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.6))).Put("fzz", ((V)(1.3))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("kiwifuzz")), ((V)("head")), ((V)(4D))), "wait", ((V)(500D)));
Invoke(Invoke(Invoke(t_317, "to", ((V)(200D)), NewObj(2).Put("lx", ((V)((-0.9)))).Put("hyaw", ((V)((-0.2)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lx", ((V)(0.9))).Put("hyaw", ((V)(0.2))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(9).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("fzz", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_317, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His fuzz bristles all over and he freezes like a startled bird, then darts a look both ways.")))).Put("squish", Arr(Call(Fn((V _arrowThis324, int _argc318, V _a320, V _a321, V _a322, V _a323, V[] _rest319) => {
V t_325 = default;
t_325 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(t_325, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.24))).Put("fzz", ((V)(0.6))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(220D)));
Invoke(Invoke(Invoke(t_325, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("fzz", ((V)(1.1))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("kiwifuzz")), ((V)("head")), ((V)(4D))), "e", ((V)("emit")), ((V)("kiwijuice")), ((V)("body")), ((V)(2D)));
Call(jelly_52, V.Undef, t_325, ((V)(0.07)), ((V)(3D)), ((V)(240D)));
Invoke(t_325, "to", ((V)(300D)), NewObj(6).Put("sq", ((V)(0D))).Put("fzz", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_325);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, then he springs back with his fuzz puffed up and bits of fuzz floating.")))).Put("quirk", Arr(Call(Fn((V _arrowThis332, int _argc326, V _a328, V _a329, V _a330, V _a331, V[] _rest327) => {
V t_333 = default;
t_333 = Call(TL_43, V.Undef);
{
double i_334 = 0;
i_334 = 0D;
while (true) {
if (!((i_334 < 3D))) break;
double d_336 = 0;
d_336 = (NumTruthy((i_334 % 2D)) ? 1D : (-1D));
Invoke(Invoke(Invoke(t_333, "to", ((V)(220D)), NewObj(4).Put("hyaw", ((V)((d_336 * 0.3)))).Put("pitch", ((V)((-0.22)))).Put("ly", ((V)(0.8))).Put("lx", ((V)((d_336 * 0.6)))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("fzz", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("fzz", ((V)(0.1))).V, ((V)("io")));
i_334++;
}
}
Invoke(Invoke(Invoke(t_333, "to", ((V)(300D)), NewObj(7).Put("hyaw", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("fzz", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("stw", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_333, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Preen")), ((V)("Preens his fuzz like a little bird - left, right, left - then a proud stem bob.")))).Put("press", NewObj(1).Put("fzz", ((V)(0.6))).V).Put("rel", Call(relK_60, V.Undef, ((V)("fzz")), ((V)(0.8)), Arr(((V)("kiwifuzz")), ((V)("head")), ((V)(3D))))).V).Put("melo", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis343, int _argc337, V _a339, V _a340, V _a341, V _a342, V[] _rest338) => {
V t_344 = default;
t_344 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(swing_50, V.Undef, t_344, ((V)(1500D)), ((V)(3D)), NewObj(5).Put("tilt", ((V)(7D))).Put("x", ((V)(2.5))).Put("armL", ((V)(40D))).Put("armR", ((V)((-10D)))).Put("sdj", ((V)(0.6))).V, ((V)("io")));
Call(hopC_57, V.Undef, t_344, ((V)(8D)), NewObj(3).Put("air", NewObj(1).Put("sdj", ((V)(1D))).V).Put("fall", NewObj(1).Put("sdj", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("melojuice")), ((V)("head")), ((V)(3D))))).V);
return Call(loopN_56, V.Undef, Invoke(t_344, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Surfs a little swell with his arms out, then a juicy hop that jiggles all his seeds.")))).Put("surprised", Arr(Call(Fn((V _arrowThis351, int _argc345, V _a347, V _a348, V _a349, V _a350, V[] _rest346) => {
V t_352 = default;
t_352 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_352, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sdj", ((V)(1.4))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("meloseed")), ((V)("head")), ((V)(2D))), "to", ((V)(320D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i")));
Invoke(Invoke(Invoke(Invoke(t_352, "to", ((V)(500D)), NewObj(2).Put("sdj", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("ly", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("ly", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_352, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His seeds jump in his flesh (two pop out!) - he checks the rest are still there.")))).Put("squish", Arr(Call(Fn((V _arrowThis359, int _argc353, V _a355, V _a356, V _a357, V _a358, V[] _rest354) => {
V t_360 = default;
t_360 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_360, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.24))).Put("sdj", ((V)(0.8))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("melojuice")), ((V)("body")), ((V)(5D))), "wait", ((V)(220D)));
Invoke(t_360, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("sdj", ((V)(1.2))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_360, ((V)(0.07)), ((V)(3D)), ((V)(260D)));
Invoke(t_360, "to", ((V)(300D)), NewObj(6).Put("sq", ((V)(0D))).Put("sdj", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_360);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed so the juice splashes, then he springs back and his seeds jiggle.")))).Put("quirk", Arr(Call(Fn((V _arrowThis367, int _argc361, V _a363, V _a364, V _a365, V _a366, V[] _rest362) => {
V t_368 = default;
t_368 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_368, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.7))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(80D)), NewObj(4).Put("puff", ((V)((-0.2)))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.4))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth")), ((V)(1D))), "to", ((V)(200D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_368, "to", ((V)(400D)), NewObj(2).Put("lx", ((V)(0.9))).Put("hyaw", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(600D)), ((V)(2D)), NewObj(1).Put("sdj", ((V)(0.5))).V, NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_368, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Seed spit")), ((V)("Puffs his cheeks and spits a seed - watches how far it went, very proud.")))).Put("press", NewObj(1).Put("sdj", ((V)(0.6))).V).Put("rel", Call(relK_60, V.Undef, ((V)("sdj")), ((V)(1D)), Arr(((V)("melojuice")), ((V)("head")), ((V)(3D))))).V).Put("peachy", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis375, int _argc369, V _a371, V _a372, V _a373, V _a374, V[] _rest370) => {
V t_376 = default;
t_376 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.2))).V);
Invoke(t_376, "to", ((V)(400D)), NewObj(2).Put("blush", ((V)(1D))).Put("close", ((V)(0.5))).V, ((V)("io")));
Call(swing_50, V.Undef, t_376, ((V)(1600D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).Put("lfl", ((V)(0.5))).V, ((V)("io")));
Invoke(t_376, "to", ((V)(300D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io")));
Call(hopC_57, V.Undef, t_376, ((V)(5D)), NewObj(2).Put("air", NewObj(1).Put("lfl", ((V)(0.8))).V).Put("fall", NewObj(1).Put("lfl", ((V)(0D))).V).V);
Invoke(t_376, "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, Invoke(t_376, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Blushes with her eyes half shut, a soft sway, then a gentle hop that lifts her leaf.")))).Put("surprised", Arr(Call(Fn((V _arrowThis383, int _argc377, V _a379, V _a380, V _a381, V _a382, V[] _rest378) => {
V t_384 = default;
t_384 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_384, "wait", ((V)(150D))), "to", ((V)(100D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.6))).Put("lfl", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), Call(o_46, V.Undef, Call(both_45, V.Undef, ((V)(10D)), ((V)((-12D)))), NewObj(3).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("blush", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(400D)), Call(o_46, V.Undef, NOHANDS_47, NewObj(9).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lfl", ((V)(0D))).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("blush", ((V)(0.3))).V, ((V)("io")));
return Invoke(Invoke(t_384, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("A little gasp with her paws to her cheeks, blushing pink all over.")))).Put("squish", Arr(Call(Fn((V _arrowThis391, int _argc385, V _a387, V _a388, V _a389, V _a390, V[] _rest386) => {
V t_392 = default;
t_392 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_392, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "to", ((V)(625D)), NewObj(5).Put("sq", ((V)(0.27))).Put("blush", ((V)(0.8))).Put("close", ((V)(0.7))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("peachjuice")), ((V)("body")), ((V)(3D))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(t_392, "to", ((V)(900D)), NewObj(3).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).Put("smile", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("lfl", ((V)(0D))).Put("blush", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_392);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Sinks down soft and slow like a ripe peach (a little juice), blushing, and slowly rises.")))).Put("quirk", Arr(Call(Fn((V _arrowThis399, int _argc393, V _a395, V _a396, V _a397, V _a398, V[] _rest394) => {
V t_400 = default;
t_400 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_400, "to", ((V)(320D)), Call(o_46, V.Undef, Call(hand_44, V.Undef, ((V)((-1D))), ((V)(10D)), ((V)((-12D)))), NewObj(3).Put("armL", ((V)(30D))).Put("close", ((V)(0.5))).Put("blush", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("hLy", ((V)((-10D)))).V, NewObj(1).Put("hLy", ((V)((-13D)))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_46, V.Undef, NOHANDS_47, NewObj(2).Put("armL", ((V)(0D))).Put("close", ((V)(0D))).V), ((V)("io"))), "to", ((V)(800D)), NewObj(3).Put("lsp", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("lsp", ((V)(0D))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_400, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Fuzzy cheek")), ((V)("Rubs her fuzzy cheek, blushes, and her leaf gives a happy whirl.")))).Put("press", NewObj(2).Put("blush", ((V)(0.8))).Put("close", ((V)(0.4))).V).Put("rel", Call(relK_60, V.Undef, ((V)("lfl")), ((V)(0.8)), Arr(((V)("peachjuice")), ((V)("head")), ((V)(2D))))).V).Put("pitaya", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis407, int _argc401, V _a403, V _a404, V _a405, V _a406, V[] _rest402) => {
V t_408 = default;
t_408 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(t_408, "to", ((V)(240D)), NewObj(2).Put("wsp", ((V)(1D))).Put("wfl", ((V)(1.2))).V, ((V)("o")));
Call(hopC_57, V.Undef, t_408, ((V)(9D)), NewObj(2).Put("air", NewObj(2).Put("brf", ((V)(0.8))).Put("crw", ((V)(0.8))).V).Put("fall", NewObj(2).Put("brf", ((V)(0D))).Put("crw", ((V)(0D))).V).V);
Invoke(Invoke(Invoke(t_408, "to", ((V)(260D)), NewObj(1).Put("spk", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(3).Put("wsp", ((V)(0D))).Put("wfl", ((V)(0D))).Put("spk", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, Invoke(t_408, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Spreads his leafy wings and flaps up in a little hop, bracts flaring, sparkling.")))).Put("surprised", Arr(Call(Fn((V _arrowThis415, int _argc409, V _a411, V _a412, V _a413, V _a414, V[] _rest410) => {
V t_416 = default;
t_416 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_416, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(8).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.6))).Put("brf", ((V)(1.2))).Put("crw", ((V)(1.2))).Put("wsp", ((V)(1.3))).Put("sq", ((V)((-0.1)))).Put("x", ((V)((-2D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("pitseed")), ((V)("head")), ((V)(4D))), "wait", ((V)(400D)));
Invoke(Invoke(t_416, "to", ((V)(400D)), NewObj(5).Put("brf", ((V)(0D))).Put("crw", ((V)(0D))).Put("wsp", ((V)(0D))).Put("sq", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_416, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Every bract, his crown and both wings flare out at once like a startled dragon, then fold back.")))).Put("squish", Arr(Call(Fn((V _arrowThis423, int _argc417, V _a419, V _a420, V _a421, V _a422, V[] _rest418) => {
V t_424 = default;
t_424 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(t_424, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.24))).Put("brf", ((V)(0.6))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(220D)));
Invoke(Invoke(t_424, "to", ((V)(120D)), NewObj(6).Put("sq", ((V)((-0.14)))).Put("brf", ((V)(1.1))).Put("crw", ((V)(0.8))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("pitseed")), ((V)("body")), ((V)(5D)));
Call(jelly_52, V.Undef, t_424, ((V)(0.07)), ((V)(3D)), ((V)(240D)));
Invoke(t_424, "to", ((V)(300D)), NewObj(7).Put("sq", ((V)(0D))).Put("brf", ((V)(0D))).Put("crw", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_424);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, then his bracts burst open and a shower of little seeds flies out.")))).Put("quirk", Arr(Call(Fn((V _arrowThis431, int _argc425, V _a427, V _a428, V _a429, V _a430, V[] _rest426) => {
V t_432 = default;
t_432 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(t_432, "to", ((V)(500D)), NewObj(5).Put("wsp", ((V)(1.2))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("pitch", ((V)(0.08))).Put("close", ((V)(0.4))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(1).Put("wfl", ((V)(1.4))).V, NewObj(1).Put("wfl", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(6).Put("wsp", ((V)(0D))).Put("wfl", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_432, "to", ((V)(300D)), NewObj(3).Put("spk", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(1).Put("spk", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_432, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Wing stretch")), ((V)("Stretches his leafy wings out wide, two big flaps, folds them and sparkles.")))).Put("press", NewObj(2).Put("brf", ((V)(0.6))).Put("wsp", ((V)(0.4))).V).Put("rel", Call(relK_60, V.Undef, ((V)("brf")), ((V)(0.9)), Arr(((V)("pitseed")), ((V)("head")), ((V)(3D))))).V).Put("tutti", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis439, int _argc433, V _a435, V _a436, V _a437, V _a438, V[] _rest434) => {
V t_440 = default;
t_440 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(t_440, "to", ((V)(400D)), NewObj(3).Put("wfl", ((V)(1.4))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("head")), ((V)(3D))), "to", ((V)(1000D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(3).Put("lift", ((V)(0D))).Put("wfl", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
Invoke(Invoke(t_440, "to", ((V)(160D)), NewObj(1).Put("cb", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("cb", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, Invoke(t_440, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Flutters up off the ground in a sparkly fairy twirl, lands and her fruit crown bounces.")))).Put("surprised", Arr(Call(Fn((V _arrowThis447, int _argc441, V _a443, V _a444, V _a445, V _a446, V[] _rest442) => {
V t_448 = default;
t_448 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_448, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "to", ((V)(520D)), NewObj(1).Put("fR", ((V)(1D))).V, ((V)("l"))), "to", ((V)(1D)), NewObj(1).Put("fR", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_448, "to", ((V)(160D)), NewObj(2).Put("armR", ((V)(60D))).Put("wfl", ((V)(1.2))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(8).Put("armR", ((V)(0D))).Put("wfl", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("body")), ((V)(2D)));
return Invoke(Invoke(t_448, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Her pear jumps out of the basket in fright - she catches it with a flutter of her wings.")))).Put("squish", Arr(Call(Fn((V _arrowThis455, int _argc449, V _a451, V _a452, V _a453, V _a454, V[] _rest450) => {
V t_456 = default;
t_456 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(t_456, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.24))).Put("cb", ((V)((-0.6)))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(220D)));
Invoke(Invoke(t_456, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("cb", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("head")), ((V)(3D)));
Call(jelly_52, V.Undef, t_456, ((V)(0.7)), ((V)(3D)), ((V)(260D)), ((V)("cb")));
Invoke(t_456, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_456);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed into her basket, then she springs back up in a puff of fairy dust, crown bouncing.")))).Put("quirk", Arr(Call(Fn((V _arrowThis463, int _argc457, V _a459, V _a460, V _a461, V _a462, V[] _rest458) => {
V t_464 = default;
t_464 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_464, "to", ((V)(300D)), NewObj(2).Put("ly", ((V)(0.9))).Put("pitch", ((V)((-0.12)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(700D)), NewObj(1).Put("fL", ((V)(1D))).V, ((V)("l"))), "to", ((V)(1D)), NewObj(1).Put("fL", ((V)(0D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(4).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(1).Put("wfl", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(1).Put("wfl", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_464, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Basket check")), ((V)("Peeks into her basket, tosses her cherry up and catches it, then a happy flutter.")))).Put("press", NewObj(2).Put("cb", ((V)((-0.4)))).Put("wfl", ((V)(0.6))).V).Put("rel", Call(relK_60, V.Undef, ((V)("cb")), ((V)(1D)), Arr(((V)("fairydust")), ((V)("head")), ((V)(3D))))).V).Put("nana", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis471, int _argc465, V _a467, V _a468, V _a469, V _a470, V[] _rest466) => {
V t_472 = default;
t_472 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
{
double i_473 = 0;
i_473 = 0D;
while (true) {
if (!((i_473 < 2D))) break;
Invoke(Invoke(t_472, "to", ((V)(380D)), NewObj(5).Put("cv", ((V)(0.8))).Put("tilt", ((V)((-4D)))).Put("x", ((V)((-1.5)))).Put("armL", ((V)(40D))).Put("armR", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(380D)), NewObj(5).Put("cv", ((V)((-0.6)))).Put("tilt", ((V)(4D))).Put("x", ((V)(1.5))).Put("armL", ((V)((-6D)))).Put("armR", ((V)(40D))).V, ((V)("io")));
i_473++;
}
}
Invoke(t_472, "to", ((V)(300D)), NewObj(5).Put("cv", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(hopC_57, V.Undef, t_472, ((V)(7D)), NewObj(2).Put("air", NewObj(1).Put("cv", ((V)((-0.5)))).V).Put("fall", NewObj(1).Put("cv", ((V)(0.3))).V).V);
Call(jelly_52, V.Undef, t_472, ((V)(0.4)), ((V)(2D)), ((V)(260D)), ((V)("cv")));
return Call(loopN_56, V.Undef, Invoke(t_472, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Flips her curve from side to side like a wiggly smile, then a hop that straightens her out.")))).Put("surprised", Arr(Call(Fn((V _arrowThis481, int _argc475, V _a477, V _a478, V _a479, V _a480, V[] _rest476) => {
V t_482 = default;
t_482 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_482, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(8).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("cv", ((V)((-1D)))).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.08)))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i"))), "wait", ((V)(400D))), "to", ((V)(500D)), NewObj(3).Put("cv", ((V)(0.3))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(6).Put("cv", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_482, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("She goes stiff and straight as a stick in fright, then slowly curves back into her smile.")))).Put("squish", Arr(Call(Fn((V _arrowThis489, int _argc483, V _a485, V _a486, V _a487, V _a488, V[] _rest484) => {
V t_490 = default;
t_490 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_490, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.22))).Put("cv", ((V)(0.9))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("banjuice")), ((V)("body")), ((V)(2D))), "wait", ((V)(220D)));
Invoke(t_490, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("cv", ((V)((-0.6)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_490, ((V)(0.5)), ((V)(3D)), ((V)(300D)), ((V)("cv")));
Invoke(t_490, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_490);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, she folds into a deep C, then springs back and her curve wobbles.")))).Put("quirk", Arr(Call(Fn((V _arrowThis497, int _argc491, V _a493, V _a494, V _a495, V _a496, V[] _rest492) => {
V t_498 = default;
t_498 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_498, "to", ((V)(600D)), NewObj(6).Put("cv", ((V)((-0.9)))).Put("lift", ((V)(2D))).Put("sq", ((V)((-0.05)))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(600D)), NewObj(7).Put("cv", ((V)(1D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(500D)), NewObj(5).Put("cv", ((V)(0D))).Put("sq", ((V)(0D))).Put("tilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_498, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Banana stretch")), ((V)("Stretches up tall and straight, then curls into a big lazy C and back.")))).Put("press", NewObj(1).Put("cv", ((V)(0.5))).V).Put("rel", Call(relK_60, V.Undef, ((V)("cv")), ((V)(0.8)), Arr(((V)("banjuice")), ((V)("head")), ((V)(2D))))).V).Put("bing", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis505, int _argc499, V _a501, V _a502, V _a503, V _a504, V[] _rest500) => {
V t_506 = default;
t_506 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(hopC_57, V.Undef, t_506, ((V)(8D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(2).Put("stw", ((V)(0.5))).Put("lf", ((V)(1D))).V).Put("fall", NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0.3))).V).V);
Call(land_53, V.Undef, t_506, ((V)(0.07)), ((V)(2D)), ((V)(220D)));
Call(hopC_57, V.Undef, t_506, ((V)(9D)), NewObj(2).Put("air", NewObj(2).Put("stw", ((V)((-0.5)))).Put("lf", ((V)(1D))).V).Put("fall", NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V).V);
Invoke(Invoke(Invoke(t_506, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("chjuice")), ((V)("head")), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, Invoke(t_506, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Two bouncy hops - her stem twirls one way, then the other, the leaf fluttering.")))).Put("surprised", Arr(Call(Fn((V _arrowThis513, int _argc507, V _a509, V _a510, V _a511, V _a512, V[] _rest508) => {
V t_514 = default;
t_514 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_514, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("lf", ((V)(1.2))).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(4D))).V, ((V)("o"))), "to", ((V)(340D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i"))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_514, "to", ((V)(300D)), NewObj(1).Put("ly", ((V)((-0.9)))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(1).Put("stw", ((V)(0.4))).V, NewObj(1).Put("stw", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(8).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).Put("ly", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_514, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Bounces straight up in fright, then looks up as her stem sways to a stop.")))).Put("squish", Arr(Call(Fn((V _arrowThis521, int _argc515, V _a517, V _a518, V _a519, V _a520, V[] _rest516) => {
V t_522 = default;
t_522 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_522, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(4).Put("sq", ((V)(0.27))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("chjuice")), ((V)("body")), ((V)(4D))), "wait", ((V)(220D)));
Invoke(t_522, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.16)))).Put("lf", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_522, ((V)(0.4)), ((V)(3D)), ((V)(260D)), ((V)("stw")));
Call(jelly_52, V.Undef, t_522, ((V)(0.07)), ((V)(2D)), ((V)(240D)));
Invoke(t_522, "to", ((V)(240D)), NewObj(6).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_522);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed so the cherry juice runs, then she bounces back and her stem wobbles.")))).Put("quirk", Arr(Call(Fn((V _arrowThis529, int _argc523, V _a525, V _a526, V _a527, V _a528, V[] _rest524) => {
V t_530 = default;
t_530 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_530, "to", ((V)(340D)), NewObj(3).Put("armR", ((V)(160D))).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.06))).V, ((V)("io"))), "to", ((V)(1400D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(600D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(hopC_57, V.Undef, t_530, ((V)(5D)));
return Invoke(Invoke(Invoke(t_530, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Stem twirl")), ((V)("Reaches up and twirls her stem all the way round, then a happy little hop.")))).Put("press", NewObj(1).Put("lf", ((V)(0.6))).V).Put("rel", Call(relK_60, V.Undef, ((V)("stw")), ((V)(0.5)), Arr(((V)("chjuice")), ((V)("head")), ((V)(3D))))).V).Put("plummy", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis537, int _argc531, V _a533, V _a534, V _a535, V _a536, V[] _rest532) => {
V t_538 = default;
t_538 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(t_538, "to", ((V)(320D)), NewObj(4).Put("lift", ((V)(2D))).Put("sq", ((V)((-0.05)))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)("io")));
Call(spinR_61, V.Undef, t_538, ((V)(1100D)), ((V)(360D)), NewObj(2).Put("lf", ((V)(1D))).Put("footR", ((V)(1.6))).V);
Invoke(Invoke(t_538, "to", ((V)(300D)), NewObj(6).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("footR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_538, "to", ((V)(320D)), NewObj(5).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.4))).Put("armL", ((V)(20D))).Put("armR", ((V)(90D))).Put("close", ((V)(0.5))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(260D))), "to", ((V)(320D)), NewObj(5).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, Invoke(t_538, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Rises on tiptoe with his arms over his head, a pirouette and a little bow.")))).Put("surprised", Arr(Call(Fn((V _arrowThis545, int _argc539, V _a541, V _a542, V _a543, V _a544, V[] _rest540) => {
V t_546 = default;
t_546 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_546, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(10).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("lf", ((V)(1.2))).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(4D))).Put("armL", ((V)(140D))).Put("armR", ((V)(140D))).Put("footL", ((V)(1.2))).Put("footR", ((V)(1.2))).V, ((V)("o"))), "to", ((V)(340D)), NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i"))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_546, "to", ((V)(320D)), Call(o_46, V.Undef, Call(both_45, V.Undef, ((V)(7D)), ((V)(8D))), NewObj(4).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("ly", ((V)(0.5))).Put("pitch", ((V)((-0.08)))).V), ((V)("io")));
Invoke(t_546, "osc", ((V)(700D)), ((V)(2D)), NewObj(3).Put("hLx", ((V)(9D))).Put("hRx", ((V)((-9D)))).Put("pol", ((V)(0.4))).V, NewObj(3).Put("hLx", ((V)(5D))).Put("hRx", ((V)((-5D)))).Put("pol", ((V)(0.15))).V, ((V)("io")));
Invoke(t_546, "to", ((V)(320D)), Call(o_46, V.Undef, NOHANDS_47, NewObj(11).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("lf", ((V)(0D))).Put("pol", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
return Invoke(Invoke(t_546, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Leaps up with his arms over his head like a startled ballerina, then smooths his tummy and smiles.")))).Put("squish", Arr(Call(Fn((V _arrowThis553, int _argc547, V _a549, V _a550, V _a551, V _a552, V[] _rest548) => {
V t_554 = default;
t_554 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_554, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.26))).Put("pol", ((V)(0.5))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("pljuice")), ((V)("body")), ((V)(4D))), "wait", ((V)(220D)));
Invoke(t_554, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("lf", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_554, ((V)(0.4)), ((V)(3D)), ((V)(260D)), ((V)("stw")));
Call(jelly_52, V.Undef, t_554, ((V)(0.07)), ((V)(2D)), ((V)(240D)));
Invoke(Invoke(t_554, "to", ((V)(260D)), NewObj(6).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(1).Put("pol", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_554);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed so the plum juice runs and his dusty bloom rubs shiny, then he springs back and his stem wobbles.")))).Put("quirk", Arr(Call(Fn((V _arrowThis561, int _argc555, V _a557, V _a558, V _a559, V _a560, V[] _rest556) => {
V t_562 = default;
t_562 = Call(TL_43, V.Undef);
Invoke(t_562, "to", ((V)(320D)), Call(o_46, V.Undef, Call(hand_44, V.Undef, ((V)(1D)), ((V)(7D)), ((V)(8D))), NewObj(3).Put("armR", ((V)(26D))).Put("ly", ((V)(0.6))).Put("pitch", ((V)((-0.1)))).V), ((V)("io")));
{
double i_563 = 0;
i_563 = 0D;
while (true) {
if (!((i_563 < 3D))) break;
Invoke(Invoke(t_562, "to", ((V)(230D)), NewObj(3).Put("hRx", ((V)((-10D)))).Put("hRy", ((V)(10D))).Put("pol", ((V)((0.3 + (i_563 * 0.25))))).V, ((V)("io"))), "to", ((V)(230D)), NewObj(2).Put("hRx", ((V)((-5D)))).Put("hRy", ((V)(6D))).V, ((V)("io")));
i_563++;
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_562, "to", ((V)(320D)), Call(o_46, V.Undef, NOHANDS_47, NewObj(6).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("pol", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(300D))), "to", ((V)(340D)), NewObj(4).Put("armL", ((V)(60D))).Put("armR", ((V)(150D))).Put("tilt", ((V)((-4D)))).Put("winkR", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(450D))), "to", ((V)(320D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("tilt", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1500D)), NewObj(1).Put("pol", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_562, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Polish")), ((V)("Rubs the dusty bloom off his tummy in little circles until he shines, strikes a pose, and the bloom slowly comes back.")))).Put("press", NewObj(2).Put("lf", ((V)(0.6))).Put("pol", ((V)(0.3))).V).Put("rel", Call(relK_60, V.Undef, ((V)("stw")), ((V)(0.5)), Arr(((V)("pljuice")), ((V)("head")), ((V)(3D))))).V).Put("clemmy", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis571, int _argc565, V _a567, V _a568, V _a569, V _a570, V[] _rest566) => {
V t_572 = default;
V a_573 = default;
t_572 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
a_573 = Call(spinR_61, V.Undef, t_572, ((V)(700D)), ((V)(360D)), NewObj(3).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).Put("lf", ((V)(1D))).V);
Invoke(Invoke(Invoke(t_572, "at", Add(a_573, ((V)(701D)))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(4D))), "to", ((V)(200D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(hopC_57, V.Undef, t_572, ((V)(8D)), NewObj(3).Put("air", NewObj(1).Put("stw", ((V)(0.4))).V).Put("fall", NewObj(1).Put("stw", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(3D))))).V);
return Call(loopN_56, V.Undef, Invoke(t_572, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A zippy spin that sprays zesty mist, then a quick hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis580, int _argc574, V _a576, V _a577, V _a578, V _a579, V[] _rest575) => {
V t_581 = default;
t_581 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_581, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(3D))).Put("lf", ((V)(1.2))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(6D))), "to", ((V)(300D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i")));
Invoke(Invoke(Invoke(Invoke(t_581, "to", ((V)(240D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(7).Put("lx", ((V)(0D))).Put("lf", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_581, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Jumps with a burst of zesty spray, her leaves flapping, and looks around.")))).Put("squish", Arr(Call(Fn((V _arrowThis588, int _argc582, V _a584, V _a585, V _a586, V _a587, V[] _rest583) => {
V t_589 = default;
t_589 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_589, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.24))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("close", ((V)(0.4))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(6D))), "wait", ((V)(220D)));
Invoke(t_589, "to", ((V)(120D)), NewObj(6).Put("sq", ((V)((-0.15)))).Put("lf", ((V)(1D))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_589, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_589, "to", ((V)(240D)), NewObj(6).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_589);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed so her peel spritzes zesty mist, then she pops back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis596, int _argc590, V _a592, V _a593, V _a594, V _a595, V[] _rest591) => {
V t_597 = default;
t_597 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(t_597, "to", ((V)(1200D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_597, "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)(0.08))).Put("close", ((V)(0.6))).Put("puff", ((V)(0.3))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(5).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("puff", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_597, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Zesty sniff")), ((V)("Twirls her leaves round, then breathes in her own zesty smell with a happy sigh.")))).Put("press", NewObj(2).Put("lf", ((V)(0.6))).Put("close", ((V)(0.3))).V).Put("rel", Call(relK_60, V.Undef, ((V)("lf")), ((V)(1D)), Arr(((V)("zest")), ((V)("head")), ((V)(5D))))).V).Put("appy", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis604, int _argc598, V _a600, V _a601, V _a602, V _a603, V[] _rest599) => {
V t_605 = default;
t_605 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(t_605, "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(hopC_57, V.Undef, t_605, ((V)(8D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("lf", ((V)(1D))).V).Put("fall", NewObj(1).Put("lf", ((V)(0D))).V).V);
Call(land_53, V.Undef, t_605, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
Call(swing_50, V.Undef, t_605, ((V)(900D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(4D))).Put("lf", ((V)(0.6))).V, ((V)("io")));
return Call(loopN_56, V.Undef, Invoke(t_605, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A crisp little bounce with a sparkle, a hop and a cheerful sway of her leaf.")))).Put("surprised", Arr(Call(Fn((V _arrowThis612, int _argc606, V _a608, V _a609, V _a610, V _a611, V[] _rest607) => {
V t_613 = default;
t_613 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(t_613, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("lf", ((V)(1D))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_613, "to", ((V)(260D)), NewObj(2).Put("lx", ((V)((-0.9)))).Put("hyaw", ((V)((-0.2)))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(260D)), NewObj(2).Put("lx", ((V)(0.9))).Put("hyaw", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("ly", ((V)(0.8))).Put("pitch", ((V)((-0.12)))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(9).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("lf", ((V)(0D))).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_613, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Freezes, then checks herself all over for worms - none, phew.")))).Put("squish", Arr(Call(Fn((V _arrowThis620, int _argc614, V _a616, V _a617, V _a618, V _a619, V[] _rest615) => {
V t_621 = default;
t_621 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_621, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(4).Put("sq", ((V)(0.2))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("apjuice")), ((V)("body")), ((V)(3D))), "wait", ((V)(200D)));
Invoke(t_621, "to", ((V)(110D)), NewObj(5).Put("sq", ((V)((-0.12)))).Put("lf", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_621, ((V)(0.05)), ((V)(2D)), ((V)(220D)));
Invoke(t_621, "to", ((V)(240D)), NewObj(6).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_621);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("A crisp apple squashes less - a little juice and a quick bounce back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis628, int _argc622, V _a624, V _a625, V _a626, V _a627, V[] _rest623) => {
V t_629 = default;
t_629 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_629, "to", ((V)(320D)), Call(o_46, V.Undef, Call(both_45, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(4).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("ly", ((V)(0.6))).Put("pitch", ((V)((-0.08)))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("hLy", ((V)(6D))).Put("hRy", ((V)(10D))).V, NewObj(2).Put("hLy", ((V)(10D))).Put("hRy", ((V)(6D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_46, V.Undef, NOHANDS_47, NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(200D)), NewObj(1).Put("lf", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_629, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Polish")), ((V)("Polishes herself with both paws until she shines and sparkles.")))).Put("press", NewObj(1).Put("lf", ((V)(0.5))).V).Put("rel", Call(relK_60, V.Undef, ((V)("lf")), ((V)(1D)), Arr(((V)("apjuice")), ((V)("head")), ((V)(2D))))).V).Put("blueby", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis636, int _argc630, V _a632, V _a633, V _a634, V _a635, V[] _rest631) => {
V t_637 = default;
t_637 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_637, "to", ((V)(400D)), NewObj(3).Put("rl", ((V)((-28D)))).Put("x", ((V)((-4D)))).Put("armR", ((V)(40D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(4).Put("rl", ((V)(28D))).Put("x", ((V)(4D))).Put("armR", ((V)(0D))).Put("armL", ((V)(40D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(3).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).V, ((V)("io")));
Call(hopC_57, V.Undef, t_637, ((V)(7D)), NewObj(2).Put("air", NewObj(1).Put("stw", ((V)(0.6))).V).Put("fall", NewObj(1).Put("stw", ((V)(0D))).V).V);
return Call(loopN_56, V.Undef, Invoke(t_637, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Rocks and rolls on her round tummy from side to side, then a hop that spins her crown.")))).Put("surprised", Arr(Call(Fn((V _arrowThis644, int _argc638, V _a640, V _a641, V _a642, V _a643, V[] _rest639) => {
V t_645 = default;
t_645 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_645, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "to", ((V)(700D)), NewObj(2).Put("rl", ((V)((-360D)))).Put("x", ((V)((-10D)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(1).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("x", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink"))), "to", ((V)(300D)), NewObj(5).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_645, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Startled, she rolls right over and back onto her feet, blinking.")))).Put("squish", Arr(Call(Fn((V _arrowThis652, int _argc646, V _a648, V _a649, V _a650, V _a651, V[] _rest647) => {
V t_653 = default;
t_653 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_653, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(4).Put("sq", ((V)(0.27))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("bljuice")), ((V)("body")), ((V)(3D))), "wait", ((V)(220D)));
Invoke(t_653, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.16)))).Put("crf", ((V)(0.8))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_653, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_653, "to", ((V)(260D)), NewObj(6).Put("sq", ((V)(0D))).Put("crf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_653);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed like a squishy berry, then she pops back and her crown flares.")))).Put("quirk", Arr(Call(Fn((V _arrowThis660, int _argc654, V _a656, V _a657, V _a658, V _a659, V[] _rest655) => {
V t_661 = default;
t_661 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_661, "to", ((V)(900D)), NewObj(3).Put("rl", ((V)(360D))).Put("x", ((V)(10D))).Put("lx", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "wait", ((V)(300D))), "to", ((V)(900D)), NewObj(3).Put("rl", ((V)((-360D)))).Put("x", ((V)(0D))).Put("lx", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(3).Put("lx", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("stw", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_661, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Roll about")), ((V)("Rolls away a little, rolls back again and spins her crown.")))).Put("press", NewObj(1).Put("crf", ((V)(0.5))).V).Put("rel", Call(relK_60, V.Undef, ((V)("crf")), ((V)(0.8)), Arr(((V)("bljuice")), ((V)("head")), ((V)(2D))))).V).Put("coco", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis668, int _argc662, V _a664, V _a665, V _a666, V _a667, V[] _rest663) => {
V t_669 = default;
t_669 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(t_669, "to", ((V)(300D)), Call(o_46, V.Undef, Call(both_45, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(2).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V), ((V)("io")));
{
double i_670 = 0;
i_670 = 0D;
while (true) {
if (!((i_670 < 4D))) break;
Invoke(Invoke(Invoke(t_669, "to", ((V)(120D)), NewObj(2).PutK(((V)((NumTruthy((i_670 % 2D)) ? "hRy" : "hLy"))), ((V)(12D))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("body")), ((V)(1D))), "to", ((V)(160D)), NewObj(3).Put("hLy", ((V)(8D))).Put("hRy", ((V)(8D))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_670++;
}
}
Invoke(t_669, "to", ((V)(300D)), Call(o_46, V.Undef, NOHANDS_47, NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
Call(swing_50, V.Undef, t_669, ((V)(1200D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).Put("lf", ((V)(0.6))).V, ((V)("io")));
return Call(loopN_56, V.Undef, Invoke(t_669, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Drums a little bongo beat on his hollow belly, then sways like a palm tree.")))).Put("surprised", Arr(Call(Fn((V _arrowThis678, int _argc672, V _a674, V _a675, V _a676, V _a677, V[] _rest673) => {
V t_679 = default;
t_679 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_679, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("fz", ((V)(1.2))).Put("lf", ((V)(1D))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("fibre")), ((V)("head")), ((V)(4D))), "wait", ((V)(500D)));
Invoke(Invoke(t_679, "to", ((V)(400D)), NewObj(3).Put("fz", ((V)(0D))).Put("lf", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_679, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Every hair on him stands on end and a few fibres fly, then it all lies back down.")))).Put("squish", Arr(Call(Fn((V _arrowThis686, int _argc680, V _a682, V _a683, V _a684, V _a685, V[] _rest681) => {
V t_687 = default;
t_687 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_687, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(325D)), NewObj(4).Put("sq", ((V)(0.14))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("knock")), ((V)("head")), ((V)(1D))), "wait", ((V)(200D)));
Invoke(Invoke(t_687, "to", ((V)(110D)), NewObj(5).Put("sq", ((V)((-0.08)))).Put("fz", ((V)(0.8))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("cocomilk")), ((V)("head")), ((V)(2D)));
Call(jelly_52, V.Undef, t_687, ((V)(0.04)), ((V)(2D)), ((V)(200D)));
Invoke(t_687, "to", ((V)(300D)), NewObj(6).Put("sq", ((V)(0D))).Put("fz", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_687);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("A hard nut hardly squashes - knock! - his hair puffs and a drop of coconut milk splashes.")))).Put("quirk", Arr(Call(Fn((V _arrowThis694, int _argc688, V _a690, V _a691, V _a692, V _a693, V[] _rest689) => {
V t_695 = default;
t_695 = Call(TL_43, V.Undef);
Invoke(Invoke(t_695, "to", ((V)(500D)), NewObj(2).Put("rl", ((V)(24D))).Put("x", ((V)(3D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Invoke(t_695, "to", ((V)(320D)), NewObj(2).Put("armR", ((V)(150D))).Put("hyaw", ((V)(0.15))).V, ((V)("io")));
{
double i_696 = 0;
i_696 = 0D;
while (true) {
if (!((i_696 < 3D))) break;
Invoke(Invoke(Invoke(t_695, "to", ((V)(110D)), NewObj(2).Put("armR", ((V)(138D))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("head")), ((V)(1D))), "to", ((V)(180D)), NewObj(2).Put("armR", ((V)(150D))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_696++;
}
}
Invoke(Invoke(Invoke(t_695, "to", ((V)(400D)), NewObj(3).Put("lx", ((V)(0.9))).Put("hyaw", ((V)(0.25))).Put("close", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(6).Put("armR", ((V)(0D))).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_695, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Knock knock")), ((V)("Knocks on his own head three times and listens - hollow! He grins.")))).Put("press", NewObj(1).Put("fz", ((V)(0.6))).V).Put("rel", Call(relK_60, V.Undef, ((V)("fz")), ((V)(0.9)), Arr(((V)("fibre")), ((V)("head")), ((V)(3D))))).V).Put("perry", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis704, int _argc698, V _a700, V _a701, V _a702, V _a703, V[] _rest699) => {
V t_705 = default;
t_705 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(t_705, "to", ((V)(300D)), NewObj(3).Put("tilt", ((V)(9D))).Put("x", ((V)(1.2))).Put("armL", ((V)(40D))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_705, ((V)(9D)), ((V)(4D)), ((V)(420D)), ((V)("tilt")));
Invoke(t_705, "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Call(hopC_57, V.Undef, t_705, ((V)(6D)), NewObj(2).Put("air", NewObj(1).Put("lf", ((V)(1D))).V).Put("fall", NewObj(1).Put("lf", ((V)(0D))).V).V);
return Call(loopN_56, V.Undef, Invoke(t_705, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Tips over on his round bottom and wobbles back like a roly-poly, then a happy hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis712, int _argc706, V _a708, V _a709, V _a710, V _a711, V[] _rest707) => {
V t_713 = default;
t_713 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_713, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)((-16D)))).Put("x", ((V)((-2D)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("tilt", ((V)(14D))).Put("x", ((V)(2D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)((-8D)))).Put("x", ((V)((-1D)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("tilt", ((V)(4D))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(7).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_713, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Wobbles wildly, arms out, nearly topples over - and rights himself.")))).Put("squish", Arr(Call(Fn((V _arrowThis720, int _argc714, V _a716, V _a717, V _a718, V _a719, V[] _rest715) => {
V t_721 = default;
t_721 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_721, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0.24))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("pearjuice")), ((V)("body")), ((V)(3D))), "wait", ((V)(220D)));
Invoke(t_721, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("lf", ((V)(1D))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_721, ((V)(6D)), ((V)(3D)), ((V)(360D)), ((V)("tilt")));
Invoke(t_721, "to", ((V)(240D)), NewObj(6).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_721);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed (a little pear juice), then he springs back and wobbles on his bottom.")))).Put("quirk", Arr(Call(Fn((V _arrowThis728, int _argc722, V _a724, V _a725, V _a726, V _a727, V[] _rest723) => {
V t_729 = default;
t_729 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(t_729, "to", ((V)(700D)), NewObj(3).Put("tilt", ((V)(15D))).Put("x", ((V)(2D))).Put("close", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(4).Put("tilt", ((V)((-6D)))).Put("x", ((V)((-1D)))).Put("close", ((V)(0D))).Put("wide", ((V)(0.5))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_729, ((V)(6D)), ((V)(3D)), ((V)(400D)), ((V)("tilt")));
Invoke(t_729, "to", ((V)(300D)), NewObj(4).Put("x", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_729, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Wobble")), ((V)("Leans further and further over... and springs back upright with a wobble.")))).Put("press", NewObj(1).Put("lf", ((V)(0.5))).V).Put("rel", Call(relK_60, V.Undef, ((V)("tilt")), ((V)(8D)), Arr(((V)("pearjuice")), ((V)("head")), ((V)(2D))))).V).Put("grana", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis736, int _argc730, V _a732, V _a733, V _a734, V _a735, V[] _rest731) => {
V t_737 = default;
t_737 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.2))).V);
Invoke(Invoke(Invoke(t_737, "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)((-0.16)))).Put("close", ((V)(0.6))).Put("armL", ((V)(40D))).Put("armR", ((V)((-10D)))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_737, "to", ((V)(200D)), NewObj(1).Put("crf", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("arils")), ((V)("head")), ((V)(4D))), "to", ((V)(400D)), NewObj(1).Put("crf", ((V)(0D))).V, ((V)("io"))), "to", ((V)(800D)), NewObj(1).Put("stw", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, Invoke(t_737, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A dignified royal nod, then his crown flares and a shower of ruby seeds sparkles out.")))).Put("surprised", Arr(Call(Fn((V _arrowThis744, int _argc738, V _a740, V _a741, V _a742, V _a743, V[] _rest739) => {
V t_745 = default;
t_745 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_745, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("crf", ((V)(1.1))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("arils")), ((V)("head")), ((V)(5D))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(t_745, "to", ((V)(320D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.8)))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(2).Put("crf", ((V)(0D))).Put("stw", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(9).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_745, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His crown flares and seeds burst out - he composes himself and straightens his crown.")))).Put("squish", Arr(Call(Fn((V _arrowThis752, int _argc746, V _a748, V _a749, V _a750, V _a751, V[] _rest747) => {
V t_753 = default;
t_753 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(t_753, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0.23))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(220D)));
Invoke(Invoke(t_753, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.13)))).Put("crf", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("arils")), ((V)("head")), ((V)(6D)));
Call(jelly_52, V.Undef, t_753, ((V)(0.06)), ((V)(2D)), ((V)(260D)));
Invoke(t_753, "to", ((V)(300D)), NewObj(6).Put("sq", ((V)(0D))).Put("crf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_753);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, then he springs back and his crown sprays ruby seeds.")))).Put("quirk", Arr(Call(Fn((V _arrowThis760, int _argc754, V _a756, V _a757, V _a758, V _a759, V[] _rest755) => {
V t_761 = default;
t_761 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_761, "to", ((V)(340D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.9)))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(2D)), NewObj(1).Put("stw", ((V)(0.3))).V, NewObj(1).Put("stw", ((V)((-0.2)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)(0.08))).Put("close", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_761, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Crown adjust")), ((V)("Straightens his crown just so with both paws, then lifts his chin like a king.")))).Put("press", NewObj(1).Put("crf", ((V)(0.5))).V).Put("rel", Call(relK_60, V.Undef, ((V)("crf")), ((V)(1D)), Arr(((V)("arils")), ((V)("head")), ((V)(4D))))).V).Put("mangie", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis768, int _argc762, V _a764, V _a765, V _a766, V _a767, V[] _rest763) => {
V t_769 = default;
t_769 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(t_769, "to", ((V)(300D)), NewObj(5).Put("tilt", ((V)((-6D)))).Put("lean", ((V)((-3D)))).Put("armL", ((V)(150D))).Put("armR", ((V)(20D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(1).Put("stw", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(hopC_57, V.Undef, t_769, ((V)(7D)), NewObj(1).Put("ev", Arr(Arr(((V)("emit")), ((V)("mjuice")), ((V)("head")), ((V)(2D))))).V);
return Call(loopN_56, V.Undef, Invoke(t_769, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A dramatic leaf flip like tossing her hair, then a sunny hop.")))).Put("surprised", Arr(Call(Fn((V _arrowThis776, int _argc770, V _a772, V _a773, V _a774, V _a775, V[] _rest771) => {
V t_777 = default;
t_777 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_777, "wait", ((V)(150D))), "to", ((V)(100D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.6))).Put("lf", ((V)(1D))).V, ((V)("o"))), "to", ((V)(320D)), Call(o_46, V.Undef, Call(hand_44, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-12D)))), NewObj(3).Put("armR", ((V)(30D))).Put("lean", ((V)(3D))).Put("tilt", ((V)(3D))).V), ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(400D)), Call(o_46, V.Undef, NOHANDS_47, NewObj(9).Put("armR", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lf", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
return Invoke(Invoke(t_777, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("A big dramatic gasp with a paw to her cheek - then she smiles as if nothing happened.")))).Put("squish", Arr(Call(Fn((V _arrowThis784, int _argc778, V _a780, V _a781, V _a782, V _a783, V[] _rest779) => {
V t_785 = default;
t_785 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_785, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0.27))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("mjuice")), ((V)("body")), ((V)(4D))), "wait", ((V)(220D)));
Invoke(t_785, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("lf", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_785, ((V)(0.08)), ((V)(3D)), ((V)(260D)));
Invoke(t_785, "to", ((V)(240D)), NewObj(6).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_785);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed so the mango juice runs, then she bounces back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis792, int _argc786, V _a788, V _a789, V _a790, V _a791, V[] _rest787) => {
V t_793 = default;
t_793 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_793, "to", ((V)(600D)), NewObj(7).Put("lean", ((V)((-4D)))).Put("tilt", ((V)((-4D)))).Put("pitch", ((V)(0.1))).Put("close", ((V)(1D))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("blush", ((V)(0.8))).V, ((V)("io"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("lf", ((V)(0.6))).V, NewObj(1).Put("lf", ((V)(0.1))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(9).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_793, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sunbathe")), ((V)("Leans back with her paws behind her head and sunbathes, ripening to a blush.")))).Put("press", NewObj(2).Put("lf", ((V)(0.6))).Put("blush", ((V)(0.5))).V).Put("rel", Call(relK_60, V.Undef, ((V)("lf")), ((V)(1D)), Arr(((V)("mjuice")), ((V)("head")), ((V)(3D))))).V).Put("razzy", NewObj(6).Put("happy", Arr(Call(Fn((V _arrowThis800, int _argc794, V _a796, V _a797, V _a798, V _a799, V[] _rest795) => {
V t_801 = default;
V a_802 = default;
t_801 = Call(TL_43, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_801, "to", ((V)(200D)), NewObj(1).Put("jig", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("tilt", ((V)(4D))).V, NewObj(1).Put("tilt", ((V)((-4D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
a_802 = Call(spinR_61, V.Undef, t_801, ((V)(800D)), ((V)(360D)), NewObj(3).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("stw", ((V)(0.6))).V);
Invoke(Invoke(Invoke(t_801, "at", Add(a_802, ((V)(801D)))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(260D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("stw", ((V)(0D))).Put("jig", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, Invoke(t_801, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A jiggly shimmy (every bead wobbles), then a jazz-hands spin with sparkles.")))).Put("surprised", Arr(Call(Fn((V _arrowThis809, int _argc803, V _a805, V _a806, V _a807, V _a808, V[] _rest804) => {
V t_810 = default;
t_810 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_810, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("jig", ((V)(1.5))).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(4D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(320D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
Invoke(Invoke(t_810, "to", ((V)(700D)), NewObj(2).Put("jig", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_810, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Jumps with every bead on her jiggling and a burst of sparkles.")))).Put("squish", Arr(Call(Fn((V _arrowThis817, int _argc811, V _a813, V _a814, V _a815, V _a816, V[] _rest812) => {
V t_818 = default;
t_818 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_818, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.27))).Put("jig", ((V)(0.6))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("rzjuice")), ((V)("body")), ((V)(4D))), "wait", ((V)(220D)));
Invoke(Invoke(t_818, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("jig", ((V)(1.4))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(800D)), NewObj(1).Put("jig", ((V)(0D))).V, ((V)("io")));
Invoke(t_818, "to", ((V)(240D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_56, V.Undef, t_818);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed so the raspberry juice runs, then all her beads wobble back.")))).Put("quirk", Arr(Call(Fn((V _arrowThis825, int _argc819, V _a821, V _a822, V _a823, V _a824, V[] _rest820) => {
V t_826 = default;
t_826 = Call(TL_43, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_826, "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("close", ((V)(0.5))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(4D)), NewObj(3).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("jig", ((V)(0.6))).V, NewObj(3).Put("hLx", ((V)((-1D)))).Put("hRx", ((V)(1D))).Put("jig", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_46, V.Undef, NOHANDS_47, NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("jig", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(600D)), NewObj(1).Put("stw", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_826, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sparkle")), ((V)("Jazz hands with a jiggle, a burst of sparkles and a twirl of her leafy top.")))).Put("press", NewObj(1).Put("jig", ((V)(0.6))).V).Put("rel", Call(relK_60, V.Undef, ((V)("jig")), ((V)(1.2)), Arr(((V)("rzjuice")), ((V)("head")), ((V)(3D))), NewObj(1).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(410D)), ((V)(0D)), ((V)("io"))))).Put("jig", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(150D)), ((V)(1.4)), ((V)("o"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).V)).V).V;
Invoke(KEYS_11, "forEach", Fn((V _arrowThis834, int _argc827, V k_833, V _a830, V _a831, V _a832, V[] _rest828) => {
V M_835 = default;
V r_836 = default;
V ch_837 = default;
V a_838 = default;
V em_839 = default;
V x_840 = default;
V from_841 = default;
V kk_842 = default;
M_835 = GetK(MOVES_63, k_833);
r_836 = Get(M_835, "rel");
if ((!(Truthy(r_836)) || !(Truthy(Get(r_836, "__rel"))))) {
return default;
}
{ V _t843 = Get(r_836, "__rel");
{ V _t844 = ListOf(_t843);
{ V _t845 = GetIdx(_t844, 0D);
ch_837 = _t845; }
{ V _t846 = GetIdx(_t844, 1D);
a_838 = _t846; }
{ V _t847 = GetIdx(_t844, 2D);
em_839 = _t847; }
{ V _t848 = GetIdx(_t844, 3D);
x_840 = _t848; }
} }
from_841 = (GetK((Get(M_835, "press") is var _t849 && Truthy(_t849) ? _t849 : NewObj(0).V), ch_837) is var _t850 && Truthy(_t850) ? _t850 : ((V)(0D)));
kk_842 = NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(410D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(560D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V;
SetK(kk_842, ch_837, (Truthy(from_841) ? Arr(Arr(((V)(0D)), from_841), Arr(((V)(160D)), ((V)(((-ToNum(from_841)) * 0.7))), ((V)("o"))), Arr(((V)(380D)), ((V)((ToNum(from_841) * 0.35))), ((V)("io"))), Arr(((V)(600D)), ((V)(((-ToNum(from_841)) * 0.12))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io")))) : Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), a_838, ((V)("o"))), Arr(((V)(380D)), ((V)(((-ToNum(a_838)) * 0.4))), ((V)("io"))), Arr(((V)(600D)), ((V)((ToNum(a_838) * 0.15))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))));
Set(M_835, "rel", Object_assign(NewObj(3).Put("dur", ((V)(1100D))).Put("k", kk_842).Put("em", (Truthy(em_839) ? Arr(em_839) : Arr())).V, (x_840 is var _t851 && Truthy(_t851) ? _t851 : NewObj(0).V)));
return default;
}, 1, "", true));
DANCES_64 = NewObj(11).Put("nana", Arr(Call(Fn((V _arrowThis858, int _argc852, V _a854, V _a855, V _a856, V _a857, V[] _rest853) => {
V t_859 = default;
double B_860 = 0;
V a_861 = default;
t_859 = Call(TL_43, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_860 = 460D;
{
double i_862 = 0;
i_862 = 0D;
while (true) {
if (!((i_862 < 4D))) break;
double d_864 = 0;
d_864 = (NumTruthy((i_862 % 2D)) ? 1D : (-1D));
Invoke(t_859, "to", ((V)(B_860)), NewObj(7).Put("cv", ((V)((d_864 * 0.9)))).Put("tilt", ((V)(((-d_864) * 4D)))).Put("x", ((V)(((-d_864) * 1.5)))).PutK(((V)(((d_864 < 0D) ? "armL" : "armR"))), ((V)(60D))).PutK(((V)(((d_864 < 0D) ? "armR" : "armL"))), ((V)((-6D)))).Put("footL", ((V)(((d_864 < 0D) ? 2D : 0D)))).Put("footR", ((V)(((d_864 > 0D) ? 2D : 0D)))).V, ((V)("io")));
i_862++;
}
}
Invoke(t_859, "to", ((V)(300D)), NewObj(7).Put("cv", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_859, "osc", ((V)(1600D)), ((V)(4D)), NewObj(3).Put("cv", ((V)(0.6))).Put("x", ((V)(2.5))).Put("lean", ((V)(2D))).V, NewObj(3).Put("cv", ((V)((-0.4)))).Put("x", ((V)((-2.5)))).Put("lean", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(3).Put("cv", ((V)(0D))).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_859, "to", ((V)(500D)), NewObj(5).Put("cv", ((V)((-1D)))).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.06)))).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(400D)), NewObj(5).Put("cv", ((V)(0.3))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.03))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("io")));
a_861 = Call(spinR_61, V.Undef, t_859, ((V)(1100D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).V);
Invoke(Invoke(Invoke(t_859, "at", a_861), "to", ((V)(500D)), NewObj(1).Put("cv", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(600D)), NewObj(1).Put("cv", ((V)(0D))).V, ((V)("io")));
Invoke(t_859, "at", Add(a_861, ((V)(1101D))));
Invoke(Invoke(Invoke(Invoke(t_859, "to", ((V)(400D)), NewObj(6).Put("cv", ((V)(1D))).Put("sq", ((V)(0.1))).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).Put("footL", ((V)(1.5))).Put("footR", ((V)(1.5))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("banjuice")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(6).Put("cv", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_859, "to", ((V)(300D)), NewObj(4).Put("cv", ((V)(0.6))).Put("tilt", ((V)((-5D)))).Put("armR", ((V)(150D))).Put("winkR", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(4).Put("cv", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armR", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_859, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Banana Boogie")), ((V)("Her curve flips from side to side on the beat, a hip hula, stretches straight up to the sky, a spin that whips her curve round, a banana-split squat and a curvy pose with a wink.")))).Put("bing", Arr(Call(Fn((V _arrowThis871, int _argc865, V _a867, V _a868, V _a869, V _a870, V[] _rest866) => {
V t_872 = default;
double B_873 = 0;
V a_874 = default;
t_872 = Call(TL_43, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_873 = 420D;
{
double i_875 = 0;
i_875 = 0D;
while (true) {
if (!((i_875 < 3D))) break;
Call(hopC_57, V.Undef, t_872, ((V)(7D)), NewObj(3).Put("chain", ((i_875 < 2D) ? V.True : V.False)).Put("air", NewObj(2).Put("stw", ((V)(((NumTruthy((i_875 % 2D)) ? (-1D) : 1D) * 0.5)))).Put("lf", ((V)(1D))).V).Put("fall", NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0.3))).V).V);
i_875++;
}
}
Call(land_53, V.Undef, t_872, ((V)(0.07)), ((V)(2D)), ((V)(220D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_872, "to", ((V)(600D)), NewObj(4).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).V, ((V)("i"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(700D)), NewObj(3).Put("stw", ((V)(1D))).Put("lift", ((V)(9D))).Put("sq", ((V)((-0.06)))).V, ((V)("l"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(700D)), NewObj(2).Put("stw", ((V)(1D))).Put("lift", ((V)(9D))).V, ((V)("l"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(800D)), NewObj(6).Put("stw", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
{
double i_877 = 0;
i_877 = 0D;
while (true) {
if (!((i_877 < 3D))) break;
Invoke(Invoke(Invoke(t_872, "to", ((V)((B_873 / 2D))), NewObj(2).Put("sq", ((V)(0.1))).Put("x", ((V)(((i_877 - 1D) * 2D)))).V, ((V)("o"))), "to", ((V)((B_873 / 2D))), NewObj(2).Put("sq", ((V)((-0.04)))).Put("lift", ((V)(2.5))).V, ((V)("o"))), "to", ((V)((B_873 / 3D))), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
i_877++;
}
}
a_874 = Call(spinR_61, V.Undef, t_872, ((V)(1200D)), ((V)(720D)), NewObj(2).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).V);
Invoke(Invoke(Invoke(t_872, "at", a_874), "to", ((V)(600D)), NewObj(1).Put("stw", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(600D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_872, "at", Add(a_874, ((V)(1201D)))), "to", ((V)(200D)), NewObj(3).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_872, "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("chjuice")), ((V)("head")), ((V)(4D))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D)));
return Invoke(Invoke(t_872, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Stem Twirl")), ((V)("Hops with her stem twirling, then spins it up like a propeller for a helicopter lift-off, three bouncy bounces, a double pirouette and a juicy finale.")))).Put("plummy", Arr(Call(Fn((V _arrowThis885, int _argc879, V _a881, V _a882, V _a883, V _a884, V[] _rest880) => {
V t_886 = default;
double B_887 = 0;
t_886 = Call(TL_43, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_887 = 480D;
Invoke(Invoke(Invoke(t_886, "to", ((V)(B_887)), NewObj(5).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("lift", ((V)(2D))).Put("sq", ((V)((-0.05)))).Put("close", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(B_887)), NewObj(5).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
{
double i_888 = 0;
i_888 = 0D;
while (true) {
if (!((i_888 < 2D))) break;
Invoke(Invoke(t_886, "to", ((V)(B_887)), NewObj(4).Put("sq", ((V)(0.12))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("pitch", ((V)((-0.05)))).V, ((V)("io"))), "to", ((V)(B_887)), NewObj(5).Put("sq", ((V)((-0.05)))).Put("lift", ((V)(2D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("pitch", ((V)(0.04))).V, ((V)("io")));
i_888++;
}
}
Invoke(t_886, "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
Call(spinR_61, V.Undef, t_886, ((V)(1300D)), ((V)(720D)), NewObj(5).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("footR", ((V)(2D))).Put("lift", ((V)(1.5))).Put("lf", ((V)(1D))).V);
Invoke(t_886, "to", ((V)(300D)), NewObj(5).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_886, "to", ((V)(600D)), NewObj(7).Put("pitch", ((V)(0.08))).Put("lean", ((V)(3D))).Put("tilt", ((V)((-6D)))).Put("armL", ((V)(40D))).Put("armR", ((V)(140D))).Put("footL", ((V)(2.4))).Put("stw", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(7).Put("pitch", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("footL", ((V)(0D))).Put("stw", ((V)(0D))).V, ((V)("io")));
Invoke(t_886, "to", ((V)(200D)), NewObj(1).Put("lift", ((V)(1.5))).V, ((V)("io")));
{
double i_890 = 0;
i_890 = 0D;
while (true) {
if (!((i_890 < 8D))) break;
Invoke(t_886, "to", ((V)(115D)), NewObj(3).Put("x", ((V)((((i_890 < 4D) ? (i_890 + 1D) : (7D - i_890)) * 1.4)))).Put("footL", ((V)((NumTruthy((i_890 % 2D)) ? 0.9 : 0D)))).Put("footR", ((V)((NumTruthy((i_890 % 2D)) ? 0D : 0.9)))).V, ((V)("io")));
i_890++;
}
}
Invoke(t_886, "to", ((V)(160D)), NewObj(4).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Call(jump_48, V.Undef, t_886, NewObj(7).Put("h", ((V)(9D))).Put("ant", ((V)(170D))).Put("up", ((V)(240D))).Put("c", ((V)(0.12))).Put("arm", ((V)(30D))).Put("air", NewObj(5).Put("footL", ((V)(2.2))).Put("footR", ((V)(2.2))).Put("armL", ((V)(150D))).Put("armR", ((V)(70D))).Put("lf", ((V)(1D))).V).Put("fall", NewObj(5).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("lf", ((V)(0D))).V).V);
Call(land_53, V.Undef, t_886, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
Invoke(Invoke(Invoke(t_886, "to", ((V)(300D)), NewObj(3).Put("pol", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_886, "to", ((V)(600D)), NewObj(6).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.6))).Put("armR", ((V)(100D))).Put("armL", ((V)(20D))).Put("sq", ((V)(0.06))).Put("close", ((V)(0.6))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(400D))), "to", ((V)(500D)), NewObj(6).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("armR", ((V)(0D))).Put("armL", ((V)(0D))).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(1).Put("pol", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_886, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.5))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Sugar Plum Twirl")), ((V)("A little ballet: up on tiptoe with his arms over his head, two plies, a double pirouette, an arabesque, tiny tiptoe steps there and back, a grand leap, a shiny polish and a deep bow.")))).Put("clemmy", Arr(Call(Fn((V _arrowThis898, int _argc892, V _a894, V _a895, V _a896, V _a897, V[] _rest893) => {
V t_899 = default;
double B_900 = 0;
V a_901 = default;
t_899 = Call(TL_43, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_900 = 380D;
{
double i_902 = 0;
i_902 = 0D;
while (true) {
if (!((i_902 < 4D))) break;
Invoke(Invoke(Invoke(t_899, "to", ((V)((B_900 / 2D))), NewObj(3).Put("sq", ((V)(0.06))).PutK(((V)((NumTruthy((i_902 % 2D)) ? "footR" : "footL"))), ((V)(2.2))).Put("x", ((V)(((NumTruthy((i_902 % 2D)) ? 1D : (-1D)) * 1.2)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(2D))), "to", ((V)((B_900 / 2D))), NewObj(3).Put("sq", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i")));
i_902++;
}
}
Invoke(t_899, "to", ((V)(200D)), NewObj(3).Put("x", ((V)(0D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("io")));
a_901 = Call(spinR_61, V.Undef, t_899, ((V)(2200D)), ((V)(1440D)), NewObj(1).Put("lf", ((V)(1D))).V);
Invoke(Invoke(t_899, "at", Add(a_901, ((V)(1500D)))), "osc", ((V)(700D)), ((V)(3D)), NewObj(1).Put("tilt", ((V)(4D))).V, NewObj(1).Put("tilt", ((V)((-4D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_899, "at", Add(a_901, ((V)(2201D)))), "to", ((V)(200D)), NewObj(4).Put("tilt", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(5D)));
Invoke(Invoke(Invoke(t_899, "to", ((V)(1000D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
{
double i_904 = 0;
i_904 = 0D;
while (true) {
if (!((i_904 < 2D))) break;
Call(hopC_57, V.Undef, t_899, ((V)(8D)), NewObj(4).Put("chain", ((i_904 < 1D) ? V.True : V.False)).Put("air", NewObj(1).Put("lf", ((V)(1D))).V).Put("fall", NewObj(1).Put("lf", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(2D))))).V);
i_904++;
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_899, "to", ((V)(240D)), NewObj(4).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(6D))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(300D)));
return Invoke(Invoke(t_899, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Peel Spin")), ((V)("Zippy steps that spritz zest, then she spins like a top (wobbling as she slows), twirls her leaves, two quick hops and a zesty finale.")))).Put("appy", Arr(Call(Fn((V _arrowThis912, int _argc906, V _a908, V _a909, V _a910, V _a911, V[] _rest907) => {
V t_913 = default;
double B_914 = 0;
V a_915 = default;
t_913 = Call(TL_43, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_914 = 520D;
{
double i_916 = 0;
i_916 = 0D;
while (true) {
if (!((i_916 < 4D))) break;
Invoke(t_913, "to", ((V)(B_914)), NewObj(4).Put("lift", ((V)((NumTruthy((i_916 % 2D)) ? 1D : (-2.5))))).Put("tilt", ((V)((NumTruthy((i_916 % 2D)) ? (-4D) : 4D)))).Put("sq", ((V)((NumTruthy((i_916 % 2D)) ? (-0.02) : 0.04)))).Put("lf", ((V)((NumTruthy((i_916 % 2D)) ? 0.2 : 0.6)))).V, ((V)("io")));
i_916++;
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_913, "to", ((V)(300D)), NewObj(3).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(3).Put("sq", ((V)(0.14))).Put("pitch", ((V)((-0.1)))).Put("close", ((V)(1D))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(2).Put("lift", ((V)((-4D)))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("drop")), ((V)("body")), ((V)(5D))), "to", ((V)(260D)), NewObj(5).Put("lift", ((V)(6D))).Put("sq", ((V)((-0.08)))).Put("close", ((V)(0D))).Put("wide", ((V)(0.6))).Put("pitch", ((V)(0.08))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).Put("wide", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(1D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
a_915 = Call(spinR_61, V.Undef, t_913, ((V)(1000D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V);
Invoke(Invoke(Invoke(t_913, "at", Add(a_915, ((V)(1001D)))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
{
double i_918 = 0;
i_918 = 0D;
while (true) {
if (!((i_918 < 4D))) break;
Invoke(Invoke(t_913, "to", ((V)((B_914 / 2D))), NewObj(4).Put("sq", ((V)(0.08))).PutK(((V)((NumTruthy((i_918 % 2D)) ? "footR" : "footL"))), ((V)(2.4))).Put("armL", ((V)((NumTruthy((i_918 % 2D)) ? 40D : 10D)))).Put("armR", ((V)((NumTruthy((i_918 % 2D)) ? 10D : 40D)))).V, ((V)("o"))), "to", ((V)((B_914 / 2D))), NewObj(3).Put("sq", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i")));
i_918++;
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_913, "to", ((V)(300D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(150D))).Put("tilt", ((V)((-4D)))).Put("winkR", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "wait", ((V)(450D))), "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(0D))).Put("tilt", ((V)(0D))).Put("winkR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_913, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Apple Bob")), ((V)("Bobs like an apple floating in a tub, dunks under and pops back up with a splash, a polishing spin, crunchy stomps and a shiny wink.")))).Put("blueby", Arr(Call(Fn((V _arrowThis926, int _argc920, V _a922, V _a923, V _a924, V _a925, V[] _rest921) => {
V t_927 = default;
double B_928 = 0;
t_927 = Call(TL_43, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_928 = 480D;
{
double i_929 = 0;
i_929 = 0D;
while (true) {
if (!((i_929 < 4D))) break;
double d_931 = 0;
d_931 = (NumTruthy((i_929 % 2D)) ? 1D : (-1D));
Invoke(t_927, "to", ((V)(B_928)), NewObj(4).Put("rl", ((V)((d_931 * 26D)))).Put("x", ((V)((d_931 * 4D)))).PutK(((V)(((d_931 < 0D) ? "armR" : "armL"))), ((V)(60D))).PutK(((V)(((d_931 < 0D) ? "armL" : "armR"))), ((V)(0D))).V, ((V)("io")));
i_929++;
}
}
Invoke(t_927, "to", ((V)(300D)), NewObj(4).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_927, "to", ((V)(1000D)), NewObj(2).Put("rl", ((V)(360D))).Put("x", ((V)(14D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "wait", ((V)(150D))), "to", ((V)(1000D)), NewObj(2).Put("rl", ((V)((-360D)))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l")));
Call(jump_48, V.Undef, t_927, NewObj(7).Put("h", ((V)(12D))).Put("ant", ((V)(180D))).Put("up", ((V)(280D))).Put("c", ((V)(0.2))).Put("arm", ((V)(90D))).Put("air", NewObj(2).Put("rl", ((V)((-360D)))).Put("stw", ((V)(0.6))).V).Put("fall", NewObj(1).Put("stw", ((V)(0D))).V).V);
Invoke(t_927, "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_927, "to", ((V)(900D)), NewObj(4).Put("stw", ((V)(1D))).Put("crf", ((V)(0.6))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(4).Put("stw", ((V)(0D))).Put("crf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_927, "to", ((V)(500D)), NewObj(4).Put("rl", ((V)((-20D)))).Put("x", ((V)((-3D)))).Put("pitch", ((V)((-0.12)))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(4).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(200D)));
return Invoke(Invoke(t_927, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Blueberry Roll")), ((V)("Rock and roll on her round tummy, a full roll away and back, a roly-poly somersault, her star crown spinning and a rolling bow.")))).Put("coco", Arr(Call(Fn((V _arrowThis938, int _argc932, V _a934, V _a935, V _a936, V _a937, V[] _rest933) => {
V t_939 = default;
double B_940 = 0;
t_939 = Call(TL_43, V.Undef, NewObj(3).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).Put("rig", ((V)(1D))).V);
B_940 = 400D;
Invoke(t_939, "to", ((V)(250D)), Call(o_46, V.Undef, Call(both_45, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(2).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V), ((V)("io")));
{
double i_941 = 0;
i_941 = 0D;
while (true) {
if (!((i_941 < 8D))) break;
Invoke(Invoke(Invoke(t_939, "to", ((V)((B_940 / 2D))), NewObj(3).PutK(((V)((NumTruthy((i_941 % 2D)) ? "hRy" : "hLy"))), ((V)(12D))).Put("sq", ((V)(0.03))).Put("tilt", ((V)((NumTruthy((i_941 % 2D)) ? 2D : (-2D))))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("body")), ((V)(1D))), "to", ((V)((B_940 / 2D))), NewObj(3).Put("hLy", ((V)(8D))).Put("hRy", ((V)(8D))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_941++;
}
}
Invoke(t_939, "to", ((V)(250D)), Call(o_46, V.Undef, NOHANDS_47, NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("tilt", ((V)(0D))).V), ((V)("io")));
Call(swing_50, V.Undef, t_939, ((V)(2000D)), ((V)(3D)), NewObj(5).Put("tilt", ((V)(7D))).Put("x", ((V)(2D))).Put("armL", ((V)(50D))).Put("armR", ((V)((-20D)))).Put("lf", ((V)(0.8))).V, ((V)("io")));
Invoke(t_939, "to", ((V)(200D)), NewObj(2).Put("fz", ((V)(1.2))).Put("wide", ((V)(0.5))).V, ((V)("o")));
Call(shake_49, V.Undef, t_939, NewObj(5).Put("P", ((V)(85D))).Put("head", ((V)(0.25))).Put("roll", ((V)(3D))).Put("body", ((V)(0.8))).Put("env", Arr(((V)(0.5)), ((V)(0.9)), ((V)(1D)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).V);
Invoke(Invoke(t_939, "to", ((V)(300D)), NewObj(2).Put("fz", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("fibre")), ((V)("head")), ((V)(4D)));
Call(jump_48, V.Undef, t_939, NewObj(7).Put("h", ((V)(14D))).Put("ant", ((V)(200D))).Put("up", ((V)(300D))).Put("dn", ((V)(220D))).Put("c", ((V)(0.2))).Put("arm", ((V)(100D))).Put("st", ((V)(0.4))).V);
Invoke(Invoke(t_939, "e", ((V)("emit")), ((V)("knock")), ((V)("body")), ((V)(1D))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(4D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_939, "to", ((V)(900D)), NewObj(4).Put("rl", ((V)(360D))).Put("x", ((V)(12D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "wait", ((V)(150D))), "to", ((V)(900D)), NewObj(2).Put("rl", ((V)((-360D)))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(t_939, "to", ((V)(300D)), NewObj(2).Put("armR", ((V)(150D))).Put("hyaw", ((V)(0.15))).V, ((V)("io")));
{
double i_943 = 0;
i_943 = 0D;
while (true) {
if (!((i_943 < 3D))) break;
Invoke(Invoke(Invoke(t_939, "to", ((V)(110D)), NewObj(2).Put("armR", ((V)(138D))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("head")), ((V)(1D))), "to", ((V)(170D)), NewObj(2).Put("armR", ((V)(150D))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_943++;
}
}
Invoke(Invoke(Invoke(Invoke(t_939, "to", ((V)(300D)), NewObj(2).Put("armR", ((V)(0D))).Put("hyaw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(4).Put("lean", ((V)((-3D)))).Put("close", ((V)(0.6))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(4).Put("lean", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_939, "rest", ((V)(300D))), "loop", NewObj(2).Put("stretch", ((V)(0D))).Put("soft", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Coconut Knock")), ((V)("Bongo beats on his hollow belly, a palm-tree sway, a hair-raising shake, a coconut drop that lands with a thud, a roll away and back, knock-knock on his head and a chill pose.")))).Put("perry", Arr(Call(Fn((V _arrowThis951, int _argc945, V _a947, V _a948, V _a949, V _a950, V[] _rest946) => {
V t_952 = default;
double B_953 = 0;
V a_954 = default;
t_952 = Call(TL_43, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_953 = 520D;
{
double i_955 = 0;
i_955 = 0D;
while (true) {
if (!((i_955 < 4D))) break;
double d_957 = 0;
d_957 = (NumTruthy((i_955 % 2D)) ? 1D : (-1D));
Invoke(t_952, "to", ((V)(B_953)), NewObj(4).Put("tilt", ((V)((d_957 * 14D)))).Put("x", ((V)((d_957 * 1.5)))).Put("armL", ((V)(((d_957 > 0D) ? 70D : 10D)))).Put("armR", ((V)(((d_957 < 0D) ? 70D : 10D)))).V, ((V)("io")));
i_955++;
}
}
Invoke(t_952, "to", ((V)(300D)), NewObj(4).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("io")));
{
double i_958 = 0;
i_958 = 0D;
while (true) {
if (!((i_958 < 8D))) break;
double a_960 = 0;
a_960 = (((i_958 / 8D) * System.Math.PI) * 2D);
Invoke(t_952, "to", ((V)(200D)), NewObj(2).Put("tilt", ((V)((8D * FdLibm.Cos(a_960))))).Put("lean", ((V)((3D * FdLibm.Sin(a_960))))).V, ((V)("l")));
i_958++;
}
}
Invoke(t_952, "to", ((V)(200D)), NewObj(2).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_952, "to", ((V)(600D)), NewObj(5).Put("tilt", ((V)((-20D)))).Put("x", ((V)((-2D)))).Put("wide", ((V)(0.6))).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(1).Put("tilt", ((V)((-14D)))).V, ((V)("o")));
Call(jelly_52, V.Undef, t_952, ((V)(8D)), ((V)(3D)), ((V)(380D)), ((V)("tilt")));
Invoke(t_952, "to", ((V)(300D)), NewObj(4).Put("x", ((V)(0D))).Put("wide", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
a_954 = Call(spinR_61, V.Undef, t_952, ((V)(1300D)), ((V)(360D)), NewObj(3).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("lf", ((V)(1D))).V);
Invoke(Invoke(t_952, "at", a_954), "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("tilt", ((V)(4D))).V, NewObj(1).Put("tilt", ((V)((-4D)))).V, ((V)("io")));
Invoke(Invoke(t_952, "at", Add(a_954, ((V)(1301D)))), "to", ((V)(200D)), NewObj(4).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(jump_48, V.Undef, t_952, NewObj(5).Put("h", ((V)(6D))).Put("ant", ((V)(200D))).Put("up", ((V)(220D))).Put("c", ((V)(0.2))).Put("arm", ((V)(40D))).V);
Invoke(t_952, "e", ((V)("emit")), ((V)("pearjuice")), ((V)("head")), ((V)(2D)));
Invoke(t_952, "to", ((V)(300D)), NewObj(3).Put("tilt", ((V)(8D))).Put("armR", ((V)(150D))).Put("winkR", ((V)(1D))).V, ((V)("io")));
Call(jelly_52, V.Undef, t_952, ((V)(6D)), ((V)(3D)), ((V)(400D)), ((V)("tilt")));
Invoke(t_952, "to", ((V)(300D)), NewObj(2).Put("armR", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_952, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Pear Wobble")), ((V)("Tips side to side on his round bottom like a roly-poly toy, wobbles round in a circle, nearly falls over, spins on his bottom, a heavy little hop and a wobbly wink.")))).Put("grana", Arr(Call(Fn((V _arrowThis967, int _argc961, V _a963, V _a964, V _a965, V _a966, V[] _rest962) => {
V t_968 = default;
double B_969 = 0;
t_968 = Call(TL_43, V.Undef, NewObj(2).Put("smile", ((V)(0.8))).Put("hap", ((V)(1D))).V);
B_969 = 520D;
{
double i_970 = 0;
i_970 = 0D;
while (true) {
if (!((i_970 < 2D))) break;
double d_972 = 0;
V a_973 = default;
d_972 = (NumTruthy((i_970 % 2D)) ? (-1D) : 1D);
Invoke(Invoke(Invoke(t_968, "to", ((V)(B_969)), NewObj(4).Put("x", ((V)((d_972 * 3D)))).Put("tilt", ((V)((d_972 * 3D)))).Put("sq", ((V)(0.04))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)((B_969 * 0.7))), NewObj(2).Put("lift", ((V)(2D))).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "to", ((V)((B_969 * 0.7))), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
a_973 = Call(spinR_61, V.Undef, t_968, ((V)(1100D)), ((V)((d_972 * 360D))), NewObj(2).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V);
Invoke(t_968, "at", Add(a_973, ((V)(1101D))));
i_970++;
}
}
Invoke(Invoke(Invoke(Invoke(t_968, "to", ((V)(300D)), NewObj(4).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(600D)), NewObj(4).Put("pitch", ((V)((-0.25)))).Put("close", ((V)(0.7))).Put("armL", ((V)(60D))).Put("armR", ((V)((-10D)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(500D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_968, "to", ((V)(1200D)), NewObj(2).Put("stw", ((V)(1D))).Put("crf", ((V)(0.7))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("crf", ((V)(0D))).V, ((V)("io")));
{
double i_974 = 0;
i_974 = 0D;
while (true) {
if (!((i_974 < 3D))) break;
Invoke(Invoke(Invoke(t_968, "to", ((V)(140D)), NewObj(2).Put("crf", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("arils")), ((V)("head")), ((V)(4D))), "to", ((V)(300D)), NewObj(2).Put("crf", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_974++;
}
}
Invoke(Invoke(Invoke(t_968, "to", ((V)(300D)), NewObj(1).Put("armR", ((V)(150D))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("armR", ((V)(135D))).V, NewObj(1).Put("armR", ((V)(155D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_968, "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)(0.1))).Put("close", ((V)(0.5))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_968, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Seed Shower")), ((V)("A royal waltz with turns, a slow regal bow, his crown spins and flares, ruby seeds burst out like confetti, a royal wave and a proud chin-up pose.")))).Put("mangie", Arr(Call(Fn((V _arrowThis982, int _argc976, V _a978, V _a979, V _a980, V _a981, V[] _rest977) => {
V t_983 = default;
double B_984 = 0;
V tango_985 = default;
V a_986 = default;
t_983 = Call(TL_43, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_984 = 500D;
tango_985 = Fn((V _arrowThis994, int _argc987, V d_993, V _a990, V _a991, V _a992, V[] _rest988) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_983, "to", ((V)(B_984)), NewObj(6).Put("x", ((V)((ToNum(d_993) * 2.5)))).Put("lean", ((V)((ToNum(d_993) * 2D)))).Put("armL", ((V)(90D))).Put("armR", ((V)(40D))).Put("footL", ((V)(2D))).Put("hyaw", ((V)((ToNum(d_993) * 0.2)))).V, ((V)("io"))), "to", ((V)(B_984)), NewObj(3).Put("x", ((V)((ToNum(d_993) * 5D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).V, ((V)("io"))), "to", ((V)((B_984 / 2D))), NewObj(3).Put("x", ((V)((ToNum(d_993) * 6D)))).Put("footR", ((V)(0D))).Put("footL", ((V)(1.5))).V, ((V)("o"))), "to", ((V)((B_984 / 2D))), NewObj(3).Put("x", ((V)((ToNum(d_993) * 6.5)))).Put("footL", ((V)(0D))).Put("hyaw", ((V)(((-ToNum(d_993)) * 0.25)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("hyaw", ((V)((ToNum(d_993) * 0.15)))).V, ((V)("o")));
return default;
}, 1, "", true);
Call(tango_985, V.Undef, ((V)(1D)));
Call(tango_985, V.Undef, ((V)((-1D))));
Invoke(t_983, "to", ((V)(400D)), NewObj(5).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_983, "to", ((V)(700D)), NewObj(7).Put("lean", ((V)((-5D)))).Put("tilt", ((V)((-10D)))).Put("pitch", ((V)(0.15))).Put("armL", ((V)(150D))).Put("armR", ((V)(60D))).Put("close", ((V)(0.6))).Put("lf", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(500D)), NewObj(7).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("pitch", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_983, "to", ((V)(200D)), NewObj(2).Put("stw", ((V)(0.6))).Put("lf", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
a_986 = Call(spinR_61, V.Undef, t_983, ((V)(1300D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(150D))).Put("armR", ((V)(20D))).V);
Invoke(Invoke(t_983, "at", Add(a_986, ((V)(1301D)))), "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_983, "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(40D))).Put("armL", ((V)(120D))).Put("tilt", ((V)((-4D)))).Put("winkL", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("mouth")), ((V)(1D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(0D))).Put("armL", ((V)(0D))).Put("tilt", ((V)(0D))).Put("winkL", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("mjuice")), ((V)("head")), ((V)(2D)));
return Invoke(Invoke(t_983, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Mango Tango")), ((V)("A tango both ways - slow, slow, quick-quick with sharp head snaps - a dramatic dip, a leaf flick, a promenade spin and a heart-on-the-lips wink.")))).Put("razzy", Arr(Call(Fn((V _arrowThis1001, int _argc995, V _a997, V _a998, V _a999, V _a1000, V[] _rest996) => {
V t_1002 = default;
double B_1003 = 0;
V a_1004 = default;
t_1002 = Call(TL_43, V.Undef, NewObj(3).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).Put("jig", ((V)(0.2))).V);
B_1003 = 400D;
Invoke(Invoke(t_1002, "osc", ((V)(1600D)), ((V)(8D)), NewObj(3).Put("tilt", ((V)(4D))).Put("jig", ((V)(1.2))).Put("x", ((V)(1D))).V, NewObj(3).Put("tilt", ((V)((-4D)))).Put("jig", ((V)(0.5))).Put("x", ((V)((-1D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(3).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("jig", ((V)(0.2))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_1002, "to", ((V)(300D)), NewObj(2).Put("armL", ((V)(130D))).Put("armR", ((V)(130D))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(5D)), NewObj(3).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("jig", ((V)(0.8))).V, NewObj(3).Put("hLx", ((V)((-1D)))).Put("hRx", ((V)(1D))).Put("jig", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(200D)), Call(o_46, V.Undef, NOHANDS_47, NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
a_1004 = Call(spinR_61, V.Undef, t_1002, ((V)(1200D)), ((V)(720D)), NewObj(4).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).Put("jig", ((V)(1.2))).Put("stw", ((V)(0.6))).V);
Invoke(Invoke(Invoke(t_1002, "at", Add(a_1004, ((V)(1201D)))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(4D))), "to", ((V)(250D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("jig", ((V)(0.2))).Put("stw", ((V)(0D))).V, ((V)("io")));
{
double i_1005 = 0;
i_1005 = 0D;
while (true) {
if (!((i_1005 < 4D))) break;
Invoke(Invoke(Invoke(t_1002, "to", ((V)((B_1003 / 2D))), NewObj(2).Put("sq", ((V)(0.1))).Put("jig", ((V)(1D))).V, ((V)("o"))), "to", ((V)((B_1003 / 2D))), NewObj(3).Put("sq", ((V)((-0.03)))).Put("lift", ((V)(2D))).Put("jig", ((V)(0.4))).V, ((V)("o"))), "to", ((V)((B_1003 / 3D))), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
i_1005++;
}
}
Invoke(t_1002, "to", ((V)(200D)), NewObj(1).Put("jig", ((V)(1.4))).V, ((V)("o")));
Call(shake_49, V.Undef, t_1002, NewObj(5).Put("P", ((V)(80D))).Put("head", ((V)(0.2))).Put("roll", ((V)(3D))).Put("body", ((V)(0.7))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.2)))).V);
Invoke(Invoke(t_1002, "to", ((V)(300D)), NewObj(1).Put("jig", ((V)(0.2))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("rzjuice")), ((V)("head")), ((V)(2D)));
Invoke(Invoke(Invoke(Invoke(t_1002, "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("sq", ((V)((-0.06)))).Put("winkR", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(450D))), "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_1002, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Razzle Dazzle")), ((V)("A jiggle shimmy that wobbles every bead, jazz hands, a sparkling double spin, bead-bouncing beats, a shimmy-shake and a starry wink.")))).V;
Invoke(KEYS_11, "forEach", Fn((V _arrowThis1014, int _argc1007, V k_1013, V _a1010, V _a1011, V _a1012, V[] _rest1008) => {
if (Truthy(GetK(DANCES_64, k_1013))) {
Set(GetK(MOVES_63, k_1013), "dance", GetK(DANCES_64, k_1013));
}
Set(GetK(MOVES_63, k_1013), "look", Call(natF_55, V.Undef, ((V)(1D))));
return default;
}, 1, "", true));
Call(install_54, V.Undef, MOVES_63, CARDS_62);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_1057 => Fn((V _self1015, int _argc1016, V _a1018, V _a1019, V _a1020, V _a1021, V[] _rest1017) => {
V R_1022 = default;
V S_1023 = default;
V hand_1024 = default;
V both_1025 = default;
V o_1026 = default;
V NOHANDS_1027 = default;
V jump_1028 = default;
V shake_1029 = default;
V jelly_1030 = default;
V see_1031 = default;
V unsee_1032 = default;
V giggle_1033 = default;
V sniff_1034 = default;
V lick_1035 = default;
V para_1036 = default;
V leanIn_1037 = default;
V happy_1038 = default;
V build_1039 = default;
V eyeRub_1040 = default;
V lookBack_1041 = default;
V hop_1042 = default;
V tickle_1043 = default;
V tasteHeart_1044 = default;
V nose_1045 = default;
V pulse_1046 = default;
V JU_1047 = default;
V J_1048 = default;
V P_1049 = default;
V RE_1050 = default;
V BODY_1051 = default;
V he_1052 = default;
V pr_1053 = default;
V T0_1054 = default;
V TX_1055 = default;
V TXT_1056 = default;
if (_self1015.IsNullish) _self1015 = GlobalV;
R_1022 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_1022)) || !(Truthy(Get(R_1022, "POKELIB")))) || !(Truthy(Get(R_1022, "fruitV")))) || !(Truthy(Get(Get(R_1022, "STATES"), "poke_head"))))) {
Call(G("setTimeout"), V.Undef, boot_1057.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_1022, "fruitPokeV"))) {
return default;
}
Set(R_1022, "fruitPokeV", ((V)(1D)));
{ V _t1058 = Get(R_1022, "PETLIB");
if (_t1058.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1058));
{ V _t1059 = Get(_t1058, "S");
S_1023 = _t1059; }
{ V _t1060 = Get(_t1058, "hand");
hand_1024 = _t1060; }
{ V _t1061 = Get(_t1058, "both");
both_1025 = _t1061; }
{ V _t1062 = Get(_t1058, "o");
o_1026 = _t1062; }
{ V _t1063 = Get(_t1058, "NOHANDS");
NOHANDS_1027 = _t1063; }
{ V _t1064 = Get(_t1058, "jump");
jump_1028 = _t1064; }
{ V _t1065 = Get(_t1058, "shake");
shake_1029 = _t1065; }
{ V _t1066 = Get(_t1058, "jelly");
jelly_1030 = _t1066; } }
{ V _t1067 = Get(R_1022, "POKELIB");
if (_t1067.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1067));
{ V _t1068 = Get(_t1067, "see");
see_1031 = _t1068; }
{ V _t1069 = Get(_t1067, "unsee");
unsee_1032 = _t1069; }
{ V _t1070 = Get(_t1067, "giggle");
giggle_1033 = _t1070; }
{ V _t1071 = Get(_t1067, "sniff");
sniff_1034 = _t1071; }
{ V _t1072 = Get(_t1067, "lick");
lick_1035 = _t1072; }
{ V _t1073 = Get(_t1067, "para");
para_1036 = _t1073; }
{ V _t1074 = Get(_t1067, "leanIn");
leanIn_1037 = _t1074; }
{ V _t1075 = Get(_t1067, "happy");
happy_1038 = _t1075; }
{ V _t1076 = Get(_t1067, "build");
build_1039 = _t1076; } }
eyeRub_1040 = Fn((V _arrowThis1085, int _argc1077, V t_1083, V s_1084, V _a1081, V _a1082, V[] _rest1078) => {
V k_1086 = default;
V h_1087 = default;
k_1086 = Call(S_1023, V.Undef, s_1084);
h_1087 = Call(hand_1024, V.Undef, s_1084, ((V)(12D)), ((V)((-20D))));
Invoke(Invoke(t_1083, "e", ((V)("blink2"))), "to", ((V)(300D)), Call(o_1026, V.Undef, h_1087, NewObj(2).PutK(Get(k_1086, "arm"), ((V)(20D))).PutK(Get(k_1086, "wink"), ((V)(1D))).V), ((V)("io")));
{
double i_1088 = 0;
i_1088 = 0D;
while (true) {
if (!((i_1088 < 2D))) break;
Invoke(Invoke(t_1083, "to", ((V)(170D)), NewObj(2).PutK(Get(k_1086, "hx"), Add(GetK(h_1087, Get(k_1086, "hx")), ((V)((LtN(s_1084, 0D) ? 3D : (-3D)))))).PutK(Get(k_1086, "hy"), ((V)((ToNum(GetK(h_1087, Get(k_1086, "hy"))) - 1.5)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(2).PutK(Get(k_1086, "hx"), GetK(h_1087, Get(k_1086, "hx"))).PutK(Get(k_1086, "hy"), GetK(h_1087, Get(k_1086, "hy"))).V, ((V)("io")));
i_1088++;
}
}
return Invoke(Invoke(t_1083, "to", ((V)(300D)), NewObj(4).PutK(Get(k_1086, "hx"), ((V)(0D))).PutK(Get(k_1086, "hy"), ((V)(0D))).PutK(Get(k_1086, "arm"), ((V)(0D))).PutK(Get(k_1086, "wink"), ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink")));
return default;
}, 2, "", true);
lookBack_1041 = Fn((V _arrowThis1098, int _argc1090, V t_1096, V hold_1097, V _a1094, V _a1095, V[] _rest1091) => {
Call(see_1031, V.Undef, t_1096, ((V)("tail")), ((V)(1D)), (hold_1097 is var _t1099 && Truthy(_t1099) ? _t1099 : ((V)(350D))));
return Call(unsee_1032, V.Undef, t_1096, ((V)(380D)));
return default;
}, 2, "", true);
hop_1042 = Fn((V _arrowThis1110, int _argc1100, V t_1106, V h_1107, V ev_1108, V x_1109, V[] _rest1101) => {
return Call(jump_1028, V.Undef, t_1106, Call(o_1026, V.Undef, NewObj(6).Put("h", (h_1107 is var _t1111 && Truthy(_t1111) ? _t1111 : ((V)(6D)))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).Put("ev", ev_1108).V, (x_1109 is var _t1112 && Truthy(_t1112) ? _t1112 : NewObj(0).V)));
}, 4, "", true);
tickle_1043 = Fn((V _arrowThis1121, int _argc1113, V t_1119, V extra_1120, V _a1117, V _a1118, V[] _rest1114) => {
V a_1122 = default;
Invoke(t_1119, "to", ((V)(220D)), Call(o_1026, V.Undef, Call(both_1025, V.Undef, ((V)(8D)), ((V)((-4D)))), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
a_1122 = Get(t_1119, "t");
Call(giggle_1033, V.Undef, t_1119, ((V)(3D)), ((V)(0.9)));
if (Truthy(extra_1120)) {
Call(para_1036, V.Undef, t_1119, a_1122, extra_1120);
}
return Invoke(t_1119, "to", ((V)(260D)), NOHANDS_1027, ((V)("io")));
return default;
}, 2, "", true);
tasteHeart_1044 = Fn((V _arrowThis1130, int _argc1123, V t_1129, V _a1126, V _a1127, V _a1128, V[] _rest1124) => {
Call(lick_1035, V.Undef, t_1129, ((V)(2D)));
return Invoke(Invoke(Invoke(Invoke(t_1129, "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(320D))), "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true);
nose_1045 = Fn((V _arrowThis1139, int _argc1131, V t_1137, V k_1138, V _a1135, V _a1136, V[] _rest1132) => {
Invoke(t_1137, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
if (Truthy(k_1138)) {
Call(k_1138, V.Undef, t_1137);
}
return Invoke(t_1137, "to", ((V)(200D)), NewObj(1).Put("ly", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
pulse_1046 = Fn((V _arrowThis1150, int _argc1140, V t_1146, V v_1147, V d1_1148, V d2_1149, V[] _rest1141) => {
V z_1151 = default;
z_1151 = NewObj(0).V;
{
foreach (V _k1152 in ForInKeys(v_1147)) {
V p_1153 = default;
p_1153 = _k1152;
SetK(z_1151, p_1153, ((V)(0D)));
}
}
return Invoke(Invoke(t_1146, "to", (d1_1148 is var _t1155 && Truthy(_t1155) ? _t1155 : ((V)(140D))), v_1147, ((V)("o"))), "to", (d2_1149 is var _t1154 && Truthy(_t1154) ? _t1154 : ((V)(340D))), z_1151, ((V)("io")));
return default;
}, 4, "", true);
JU_1047 = Get(Get(R_1022, "FRUITLIB"), "JUICE");
J_1048 = Fn((V _arrowThis1166, int _argc1156, V t_1162, V k_1163, V w_1164, V n_1165, V[] _rest1157) => {
return Invoke(t_1162, "e", ((V)("emit")), GetK(JU_1047, k_1163), (w_1164 is var _t1167 && Truthy(_t1167) ? _t1167 : ((V)("head"))), (n_1165 is var _t1168 && Truthy(_t1168) ? _t1168 : ((V)(2D))));
}, 4, "", true);
P_1049 = NewObj(20).Put("pina", NewObj(3).Put("part", Fn((V _arrowThis1177, int _argc1169, V t_1175, V a_1176, V _a1173, V _a1174, V[] _rest1170) => {
return Call(pulse_1046, V.Undef, t_1175, NewObj(1).Put("crw", a_1176).V);
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1185, int _argc1178, V u_1184, V _a1181, V _a1182, V _a1183, V[] _rest1179) => {
return Invoke(Invoke(u_1184, "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("crs", ((V)(0.3))).Put("crw", ((V)(0.4))).V, NewObj(2).Put("crs", ((V)((-0.2)))).Put("crw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("crs", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("side", Fn((V _arrowThis1194, int _argc1186, V t_1192, V s_1193, V _a1190, V _a1191, V[] _rest1187) => {
Invoke(Invoke(Invoke(t_1192, "to", ((V)(300D)), NewObj(3).Put("tilt", ((V)(((-ToNum(s_1193)) * 7D)))).Put("x", ((V)(((-ToNum(s_1193)) * 2D)))).Put("crs", ((V)((ToNum(s_1193) * 0.3)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("tilt", ((V)((ToNum(s_1193) * 2D)))).Put("crs", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).V).Put("avo", NewObj(3).Put("part", Fn((V _arrowThis1203, int _argc1195, V t_1201, V a_1202, V _a1199, V _a1200, V[] _rest1196) => {
Call(pulse_1046, V.Undef, t_1201, NewObj(1).Put("pp", ((V)((0.6 * ToNum(a_1202))))).V);
Invoke(Invoke(t_1201, "to", ((V)(200D)), NewObj(1).Put("prw", a_1202).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("prw", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1211, int _argc1204, V u_1210, V _a1207, V _a1208, V _a1209, V[] _rest1205) => {
return Invoke(Invoke(u_1210, "to", ((V)(800D)), NewObj(1).Put("pr", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("pr", ((V)(0D))).V, ((V)("l")));
}, 1, "tick", true)).Put("head", Fn((V _arrowThis1220, int _argc1212, V t_1218, V s_1219, V _a1216, V _a1217, V[] _rest1213) => {
Invoke(Invoke(Invoke(Invoke(t_1218, "to", ((V)(150D)), NewObj(2).Put("lfl", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("lfl", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(600D)), NewObj(1).Put("lsp", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("lsp", ((V)(0D))).V, ((V)("l")));
Call(giggle_1033, V.Undef, t_1218, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("berri", NewObj(3).Put("part", Fn((V _arrowThis1229, int _argc1221, V t_1227, V a_1228, V _a1225, V _a1226, V[] _rest1222) => {
return Call(pulse_1046, V.Undef, t_1227, NewObj(2).Put("lfl", a_1228).Put("stw", ((V)((0.7 * ToNum(a_1228))))).V);
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1237, int _argc1230, V u_1236, V _a1233, V _a1234, V _a1235, V[] _rest1231) => {
return Invoke(Invoke(u_1236, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("stw", ((V)(0.6))).V, NewObj(1).Put("stw", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("head", Fn((V _arrowThis1246, int _argc1238, V t_1244, V s_1245, V _a1242, V _a1243, V[] _rest1239) => {
Invoke(Invoke(Invoke(t_1244, "to", ((V)(140D)), NewObj(3).Put("lfl", ((V)(1D))).Put("stw", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("juice")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(2).Put("lfl", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(jelly_1030, V.Undef, t_1244, ((V)(0.7)), ((V)(3D)), ((V)(260D)), ((V)("stw")));
Call(giggle_1033, V.Undef, t_1244, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("lemmy", NewObj(3).Put("part", Fn((V _arrowThis1255, int _argc1247, V t_1253, V a_1254, V _a1251, V _a1252, V[] _rest1248) => {
Invoke(Invoke(Invoke(t_1253, "to", ((V)(110D)), NewObj(3).Put("close", ((V)((0.85 * ToNum(a_1254))))).Put("mw", ((V)((1D - (0.6 * ToNum(a_1254)))))).Put("puff", ((V)(((-0.3) * ToNum(a_1254))))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(260D)), NewObj(3).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("nose", Fn((V _arrowThis1263, int _argc1256, V u_1262, V _a1259, V _a1260, V _a1261, V[] _rest1257) => {
Call(sniff_1034, V.Undef, u_1262, ((V)(2D)));
Invoke(u_1262, "to", ((V)(110D)), NewObj(2).Put("close", ((V)(0.85))).Put("mw", ((V)(0.35))).V, ((V)("o")));
Call(shake_1029, V.Undef, u_1262, NewObj(4).Put("P", ((V)(70D))).Put("head", ((V)(0.14))).Put("roll", ((V)(2D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.6)), ((V)(0.3)))).V);
Invoke(Invoke(Invoke(u_1262, "to", ((V)(250D)), NewObj(4).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "nose", true)).Put("belly", Fn((V _arrowThis1272, int _argc1264, V t_1270, V s_1271, V _a1268, V _a1269, V[] _rest1265) => {
Call(tickle_1043, V.Undef, t_1270, Fn((V _arrowThis1280, int _argc1273, V u_1279, V _a1276, V _a1277, V _a1278, V[] _rest1274) => {
return Invoke(Invoke(u_1279, "osc", ((V)(900D)), ((V)(6D)), NewObj(1).Put("tilt", ((V)(3D))).V, NewObj(1).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
Call(J_1048, V.Undef, t_1270, ((V)("lemmy")), ((V)("head")), ((V)(2D)));
return default;
}, 2, "belly", true)).V).Put("kiwi", NewObj(3).Put("part", Fn((V _arrowThis1289, int _argc1281, V t_1287, V a_1288, V _a1285, V _a1286, V[] _rest1282) => {
return Call(pulse_1046, V.Undef, t_1287, NewObj(1).Put("fzz", a_1288).V, ((V)(120D)), ((V)(420D)));
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1297, int _argc1290, V u_1296, V _a1293, V _a1294, V _a1295, V[] _rest1291) => {
return Invoke(Invoke(Invoke(u_1296, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("fzz", ((V)(0.7))).V, NewObj(1).Put("fzz", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("fzz", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("kiwifuzz")), ((V)("head")), ((V)(2D)));
}, 1, "tick", true)).Put("head", Fn((V _arrowThis1306, int _argc1298, V t_1304, V s_1305, V _a1302, V _a1303, V[] _rest1299) => {
{
double i_1307 = 0;
i_1307 = 0D;
while (true) {
if (!((i_1307 < 3D))) break;
Invoke(Invoke(t_1304, "to", ((V)(130D)), NewObj(1).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(1).Put("pitch", ((V)((-0.05)))).V, ((V)("i")));
i_1307++;
}
}
Invoke(Invoke(t_1304, "to", ((V)(150D)), NewObj(2).Put("pitch", ((V)(0D))).Put("stw", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
Call(giggle_1033, V.Undef, t_1304, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("melo", NewObj(3).Put("part", Fn((V _arrowThis1317, int _argc1309, V t_1315, V a_1316, V _a1313, V _a1314, V[] _rest1310) => {
return Call(pulse_1046, V.Undef, t_1315, NewObj(1).Put("sdj", a_1316).V, ((V)(120D)), ((V)(500D)));
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1325, int _argc1318, V u_1324, V _a1321, V _a1322, V _a1323, V[] _rest1319) => {
return Invoke(Invoke(u_1324, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("sdj", ((V)(0.9))).V, NewObj(1).Put("sdj", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("foot", Fn((V _arrowThis1334, int _argc1326, V t_1332, V s_1333, V _a1330, V _a1331, V[] _rest1327) => {
Call(hop_1042, V.Undef, t_1332, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("melojuice")), ((V)("head")), ((V)(3D)))), NewObj(2).Put("air", NewObj(1).Put("sdj", ((V)(1D))).V).Put("fall", NewObj(1).Put("sdj", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).V).Put("peachy", NewObj(3).Put("part", Fn((V _arrowThis1343, int _argc1335, V t_1341, V a_1342, V _a1339, V _a1340, V[] _rest1336) => {
Invoke(Invoke(Invoke(Invoke(t_1341, "to", ((V)(200D)), NewObj(2).Put("blush", a_1342).Put("lfl", ((V)((0.6 * ToNum(a_1342))))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(400D)), NewObj(1).Put("lfl", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("cheekX", NewObj(2).Put("blush", ((V)(1D))).Put("lfl", ((V)(0.4))).V).Put("tick", Fn((V _arrowThis1351, int _argc1344, V u_1350, V _a1347, V _a1348, V _a1349, V[] _rest1345) => {
return Invoke(Invoke(Invoke(u_1350, "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).V).Put("pitaya", NewObj(4).Put("part", Fn((V _arrowThis1360, int _argc1352, V t_1358, V a_1359, V _a1356, V _a1357, V[] _rest1353) => {
return Call(pulse_1046, V.Undef, t_1358, NewObj(2).Put("brf", a_1359).Put("wsp", ((V)((0.6 * ToNum(a_1359))))).V);
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1368, int _argc1361, V u_1367, V _a1364, V _a1365, V _a1366, V[] _rest1362) => {
return Invoke(Invoke(u_1367, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("wfl", ((V)(1.2))).V, NewObj(1).Put("wfl", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("wfl", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("ear", Fn((V _arrowThis1377, int _argc1369, V t_1375, V s_1376, V _a1373, V _a1374, V[] _rest1370) => {
Invoke(Invoke(Invoke(t_1375, "to", ((V)(150D)), NewObj(2).Put("wsp", ((V)(1D))).Put("wfl", ((V)(1.4))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("wsp", ((V)(0D))).Put("wfl", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("head", Fn((V _arrowThis1386, int _argc1378, V t_1384, V s_1385, V _a1382, V _a1383, V[] _rest1379) => {
Invoke(Invoke(Invoke(t_1384, "to", ((V)(130D)), NewObj(3).Put("crw", ((V)(1D))).Put("spk", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(400D)), NewObj(3).Put("crw", ((V)(0D))).Put("spk", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(giggle_1033, V.Undef, t_1384, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("tutti", NewObj(4).Put("part", Fn((V _arrowThis1395, int _argc1387, V t_1393, V a_1394, V _a1391, V _a1392, V[] _rest1388) => {
return Call(pulse_1046, V.Undef, t_1393, NewObj(2).Put("cb", a_1394).Put("wfl", a_1394).V, ((V)(140D)), ((V)(400D)));
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1403, int _argc1396, V u_1402, V _a1399, V _a1400, V _a1401, V[] _rest1397) => {
return Invoke(Invoke(Invoke(u_1402, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("wfl", ((V)(1.4))).V, NewObj(1).Put("wfl", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("wfl", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("head")), ((V)(2D)));
}, 1, "tick", true)).Put("ear", Fn((V _arrowThis1412, int _argc1404, V t_1410, V s_1411, V _a1408, V _a1409, V[] _rest1405) => {
Invoke(Invoke(Invoke(Invoke(t_1410, "to", ((V)(150D)), NewObj(1).Put("wfl", ((V)(1.5))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(1).Put("wfl", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("belly", Fn((V _arrowThis1421, int _argc1413, V t_1419, V s_1420, V _a1417, V _a1418, V[] _rest1414) => {
Call(tickle_1043, V.Undef, t_1419, Fn((V _arrowThis1429, int _argc1422, V u_1428, V _a1425, V _a1426, V _a1427, V[] _rest1423) => {
return Invoke(Invoke(u_1428, "to", ((V)(600D)), NewObj(1).PutK(((V)((LtN(s_1420, 0D) ? "fL" : "fR"))), ((V)(1D))).V, ((V)("l"))), "to", ((V)(1D)), NewObj(2).Put("fL", ((V)(0D))).Put("fR", ((V)(0D))).V, ((V)("l")));
}, 1, "", true));
return default;
}, 2, "belly", true)).V).Put("nana", NewObj(3).Put("part", Fn((V _arrowThis1438, int _argc1430, V t_1436, V a_1437, V _a1434, V _a1435, V[] _rest1431) => {
Call(jelly_1030, V.Undef, t_1436, ((V)((0.6 * ToNum(a_1437)))), ((V)(3D)), ((V)(280D)), ((V)("cv")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1446, int _argc1439, V u_1445, V _a1442, V _a1443, V _a1444, V[] _rest1440) => {
return Invoke(Invoke(u_1445, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("cv", ((V)(0.7))).V, NewObj(1).Put("cv", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("cv", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("side", Fn((V _arrowThis1455, int _argc1447, V t_1453, V s_1454, V _a1451, V _a1452, V[] _rest1448) => {
Invoke(Invoke(t_1453, "to", ((V)(200D)), NewObj(2).Put("cv", ((V)((ToNum(s_1454) * 0.9)))).Put("tilt", ((V)(((-ToNum(s_1454)) * 3D)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("cv", ((V)(((-ToNum(s_1454)) * 0.4)))).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(jelly_1030, V.Undef, t_1453, ((V)(0.3)), ((V)(2D)), ((V)(260D)), ((V)("cv")));
return default;
}, 2, "side", true)).V).Put("bing", NewObj(3).Put("part", Fn((V _arrowThis1464, int _argc1456, V t_1462, V a_1463, V _a1460, V _a1461, V[] _rest1457) => {
Invoke(t_1462, "to", ((V)(120D)), NewObj(1).Put("lf", a_1463).V, ((V)("o")));
Call(jelly_1030, V.Undef, t_1462, ((V)((0.5 * ToNum(a_1463)))), ((V)(3D)), ((V)(260D)), ((V)("stw")));
Invoke(t_1462, "to", ((V)(200D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1472, int _argc1465, V u_1471, V _a1468, V _a1469, V _a1470, V[] _rest1466) => {
return Invoke(Invoke(u_1471, "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("stw", ((V)(0.4))).Put("lf", ((V)(0.8))).V, NewObj(2).Put("stw", ((V)((-0.4)))).Put("lf", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("head", Fn((V _arrowThis1481, int _argc1473, V t_1479, V s_1480, V _a1477, V _a1478, V[] _rest1474) => {
Invoke(Invoke(Invoke(t_1479, "to", ((V)(600D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(giggle_1033, V.Undef, t_1479, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("plummy", NewObj(5).Put("part", Fn((V _arrowThis1490, int _argc1482, V t_1488, V a_1489, V _a1486, V _a1487, V[] _rest1483) => {
Invoke(t_1488, "to", ((V)(120D)), NewObj(1).Put("lf", a_1489).V, ((V)("o")));
Call(jelly_1030, V.Undef, t_1488, ((V)((0.4 * ToNum(a_1489)))), ((V)(3D)), ((V)(260D)), ((V)("stw")));
Invoke(t_1488, "to", ((V)(200D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1498, int _argc1491, V u_1497, V _a1494, V _a1495, V _a1496, V[] _rest1492) => {
return Invoke(Invoke(u_1497, "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("pol", ((V)(0.7))).Put("lf", ((V)(0.8))).V, NewObj(2).Put("pol", ((V)(0.3))).Put("lf", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(2).Put("pol", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("head", Fn((V _arrowThis1507, int _argc1499, V t_1505, V s_1506, V _a1503, V _a1504, V[] _rest1500) => {
Invoke(Invoke(Invoke(t_1505, "to", ((V)(600D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(giggle_1033, V.Undef, t_1505, ((V)(2D)));
return default;
}, 2, "head", true)).Put("foot", Fn((V _arrowThis1516, int _argc1508, V t_1514, V s_1515, V _a1512, V _a1513, V[] _rest1509) => {
Invoke(Invoke(Invoke(Invoke(t_1514, "to", ((V)(260D)), NewObj(4).Put("lift", ((V)(1.5))).Put("sq", ((V)((-0.04)))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)("io"))), "to", ((V)(750D)), NewObj(2).Put("spin", ((V)(360D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(260D)), NewObj(5).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(giggle_1033, V.Undef, t_1514, ((V)(2D)));
return default;
}, 2, "foot", true)).Put("cheekX", NewObj(1).Put("blush", ((V)(0.7))).V).V).Put("clemmy", NewObj(3).Put("part", Fn((V _arrowThis1525, int _argc1517, V t_1523, V a_1524, V _a1521, V _a1522, V[] _rest1518) => {
Invoke(Invoke(Invoke(t_1523, "to", ((V)(120D)), NewObj(1).Put("lf", a_1524).V, ((V)("o"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(Round((2D + (3D * ToNum(a_1524))))))), "to", ((V)(300D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1533, int _argc1526, V u_1532, V _a1529, V _a1530, V _a1531, V[] _rest1527) => {
return Invoke(Invoke(Invoke(u_1532, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("lf", ((V)(0.9))).V, NewObj(1).Put("lf", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(3D)));
}, 1, "tick", true)).Put("head", Fn((V _arrowThis1542, int _argc1534, V t_1540, V s_1541, V _a1538, V _a1539, V[] _rest1535) => {
Invoke(Invoke(Invoke(Invoke(t_1540, "to", ((V)(700D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(3D)));
Call(giggle_1033, V.Undef, t_1540, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("appy", NewObj(3).Put("part", Fn((V _arrowThis1551, int _argc1543, V t_1549, V a_1550, V _a1547, V _a1548, V[] _rest1544) => {
Invoke(Invoke(t_1549, "to", ((V)(120D)), NewObj(1).Put("lf", a_1550).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1559, int _argc1552, V u_1558, V _a1555, V _a1556, V _a1557, V[] _rest1553) => {
return Invoke(Invoke(u_1558, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("lf", ((V)(0.8))).V, NewObj(1).Put("lf", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("head", Fn((V _arrowThis1568, int _argc1560, V t_1566, V s_1567, V _a1564, V _a1565, V[] _rest1561) => {
Invoke(Invoke(Invoke(t_1566, "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0.05))).Put("lf", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(2).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(giggle_1033, V.Undef, t_1566, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("blueby", NewObj(4).Put("part", Fn((V _arrowThis1577, int _argc1569, V t_1575, V a_1576, V _a1573, V _a1574, V[] _rest1570) => {
return Call(pulse_1046, V.Undef, t_1575, NewObj(1).Put("crf", a_1576).V);
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1585, int _argc1578, V u_1584, V _a1581, V _a1582, V _a1583, V[] _rest1579) => {
return Invoke(Invoke(u_1584, "osc", ((V)(1000D)), ((V)(3D)), NewObj(2).Put("rl", ((V)(14D))).Put("x", ((V)(2D))).V, NewObj(2).Put("rl", ((V)((-14D)))).Put("x", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("side", Fn((V _arrowThis1594, int _argc1586, V t_1592, V s_1593, V _a1590, V _a1591, V[] _rest1587) => {
Invoke(Invoke(Invoke(t_1592, "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(((-ToNum(s_1593)) * 40D)))).Put("x", ((V)(((-ToNum(s_1593)) * 5D)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("rl", ((V)((ToNum(s_1593) * 8D)))).Put("x", ((V)(((-ToNum(s_1593)) * 2D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1603, int _argc1595, V t_1601, V s_1602, V _a1599, V _a1600, V[] _rest1596) => {
Invoke(Invoke(Invoke(t_1601, "to", ((V)(700D)), NewObj(2).Put("rl", ((V)(((-ToNum(s_1602)) * 360D)))).Put("x", ((V)(((-ToNum(s_1602)) * 6D)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(1).Put("x", ((V)(0D))).V, ((V)("io")));
Call(giggle_1033, V.Undef, t_1601, ((V)(2D)));
return default;
}, 2, "foot", true)).V).Put("coco", NewObj(4).Put("part", Fn((V _arrowThis1612, int _argc1604, V t_1610, V a_1611, V _a1608, V _a1609, V[] _rest1605) => {
Invoke(Invoke(t_1610, "to", ((V)(120D)), NewObj(1).Put("fz", a_1611).V, ((V)("o"))), "to", ((V)(500D)), NewObj(1).Put("fz", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("foot", Fn((V _arrowThis1621, int _argc1613, V t_1619, V s_1620, V _a1617, V _a1618, V[] _rest1614) => {
Invoke(Invoke(Invoke(t_1619, "to", ((V)(800D)), NewObj(2).Put("rl", ((V)(((-ToNum(s_1620)) * 360D)))).Put("x", ((V)(((-ToNum(s_1620)) * 7D)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(1).Put("x", ((V)(0D))).V, ((V)("io")));
Call(giggle_1033, V.Undef, t_1619, ((V)(2D)));
return default;
}, 2, "foot", true)).Put("head", Fn((V _arrowThis1630, int _argc1622, V t_1628, V s_1629, V _a1626, V _a1627, V[] _rest1623) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1628, "to", ((V)(80D)), NewObj(1).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("head")), ((V)(1D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("lx", ((V)(0.8))).Put("hyaw", ((V)(0.2))).Put("close", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(3).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Call(giggle_1033, V.Undef, t_1628, ((V)(2D)));
return default;
}, 2, "head", true)).Put("belly", Fn((V _arrowThis1639, int _argc1631, V t_1637, V s_1638, V _a1635, V _a1636, V[] _rest1632) => {
Call(tickle_1043, V.Undef, t_1637, Fn((V _arrowThis1647, int _argc1640, V u_1646, V _a1643, V _a1644, V _a1645, V[] _rest1641) => {
{
double i_1648 = 0;
i_1648 = 0D;
while (true) {
if (!((i_1648 < 3D))) break;
Invoke(Invoke(Invoke(u_1646, "to", ((V)(120D)), NewObj(1).Put("fz", ((V)(0.8))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("body")), ((V)(1D))), "to", ((V)(200D)), NewObj(1).Put("fz", ((V)(0.2))).V, ((V)("io")));
i_1648++;
}
}
Invoke(u_1646, "to", ((V)(150D)), NewObj(1).Put("fz", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true));
return default;
}, 2, "belly", true)).V).Put("perry", NewObj(3).Put("part", Fn((V _arrowThis1658, int _argc1650, V t_1656, V a_1657, V _a1654, V _a1655, V[] _rest1651) => {
Invoke(t_1656, "to", ((V)(200D)), NewObj(1).Put("tilt", ((V)((7D * ToNum(a_1657))))).V, ((V)("o")));
Call(jelly_1030, V.Undef, t_1656, ((V)((6D * ToNum(a_1657)))), ((V)(3D)), ((V)(380D)), ((V)("tilt")));
return default;
}, 2, "part", true)).Put("side", Fn((V _arrowThis1667, int _argc1659, V t_1665, V s_1666, V _a1663, V _a1664, V[] _rest1660) => {
Invoke(t_1665, "to", ((V)(260D)), NewObj(4).Put("tilt", ((V)(((-ToNum(s_1666)) * 15D)))).Put("x", ((V)(((-ToNum(s_1666)) * 1.5)))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o")));
Call(jelly_1030, V.Undef, t_1665, ((V)(((-ToNum(s_1666)) * 10D))), ((V)(4D)), ((V)(420D)), ((V)("tilt")));
Invoke(t_1665, "to", ((V)(260D)), NewObj(3).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1676, int _argc1668, V t_1674, V s_1675, V _a1672, V _a1673, V[] _rest1669) => {
Invoke(t_1674, "to", ((V)(220D)), NewObj(1).Put("tilt", ((V)((ToNum(s_1675) * 10D)))).V, ((V)("o")));
Call(jelly_1030, V.Undef, t_1674, ((V)((ToNum(s_1675) * 8D))), ((V)(4D)), ((V)(400D)), ((V)("tilt")));
Call(giggle_1033, V.Undef, t_1674, ((V)(2D)));
return default;
}, 2, "foot", true)).V).Put("grana", NewObj(3).Put("part", Fn((V _arrowThis1685, int _argc1677, V t_1683, V a_1684, V _a1681, V _a1682, V[] _rest1678) => {
Invoke(Invoke(Invoke(t_1683, "to", ((V)(120D)), NewObj(1).Put("crf", a_1684).V, ((V)("o"))), "e", ((V)("emit")), ((V)("arils")), ((V)("head")), ((V)(Round((1D + (3D * ToNum(a_1684))))))), "to", ((V)(400D)), NewObj(1).Put("crf", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("head", Fn((V _arrowThis1694, int _argc1686, V t_1692, V s_1693, V _a1690, V _a1691, V[] _rest1687) => {
Invoke(Invoke(Invoke(t_1692, "to", ((V)(800D)), NewObj(2).Put("stw", ((V)(1D))).Put("crf", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("crf", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_1692, "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)(0.08))).Put("close", ((V)(0.5))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("cheekX", NewObj(1).Put("close", ((V)(0.6))).V).V).Put("mangie", NewObj(3).Put("part", Fn((V _arrowThis1703, int _argc1695, V t_1701, V a_1702, V _a1699, V _a1700, V[] _rest1696) => {
Invoke(Invoke(t_1701, "to", ((V)(150D)), NewObj(2).Put("lf", a_1702).Put("stw", ((V)((0.4 * ToNum(a_1702))))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("lf", ((V)(0D))).Put("stw", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1711, int _argc1704, V u_1710, V _a1707, V _a1708, V _a1709, V[] _rest1705) => {
return Invoke(Invoke(u_1710, "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("lf", ((V)(0.9))).Put("tilt", ((V)(3D))).V, NewObj(2).Put("lf", ((V)(0.2))).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("lf", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("cheekX", NewObj(1).Put("blush", ((V)(0.9))).V).V).Put("razzy", NewObj(2).Put("part", Fn((V _arrowThis1720, int _argc1712, V t_1718, V a_1719, V _a1716, V _a1717, V[] _rest1713) => {
Invoke(Invoke(Invoke(t_1718, "to", ((V)(120D)), NewObj(1).Put("jig", ((V)((1.3 * ToNum(a_1719))))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(1D))), "to", ((V)(700D)), NewObj(1).Put("jig", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _arrowThis1728, int _argc1721, V u_1727, V _a1724, V _a1725, V _a1726, V[] _rest1722) => {
return Invoke(Invoke(Invoke(u_1727, "to", ((V)(200D)), NewObj(1).Put("jig", ((V)(1.4))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(1).Put("jig", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).V).V;
RE_1050 = NewObj(0).V;
Invoke(Get(Get(R_1022, "FRUITLIB"), "KEYS"), "forEach", Fn((V _arrowThis1736, int _argc1729, V k_1735, V _a1732, V _a1733, V _a1734, V[] _rest1730) => {
V F_1737 = default;
V part_1738 = default;
F_1737 = GetK(P_1049, k_1735);
part_1738 = Get(F_1737, "part");
SetK(RE_1050, k_1735, NewObj(9).Put("head", (Get(F_1737, "head") is var _t1748 && Truthy(_t1748) ? _t1748 : Fn((V _arrowThis1747, int _argc1739, V t_1745, V s_1746, V _a1743, V _a1744, V[] _rest1740) => {
Call(part_1738, V.Undef, t_1745, ((V)(1D)));
Call(giggle_1033, V.Undef, t_1745, ((V)(2D)));
return default;
}, 2, "", true))).Put("ear", Fn((V _arrowThis1757, int _argc1749, V t_1755, V s_1756, V _a1753, V _a1754, V[] _rest1750) => {
Call(see_1031, V.Undef, t_1755, ((V)("ear")), s_1756, ((V)(120D)));
Call((Get(F_1737, "ear") is var _t1767 && Truthy(_t1767) ? _t1767 : Fn((V _arrowThis1766, int _argc1758, V u_1764, V s_1765, V _a1762, V _a1763, V[] _rest1759) => {
return Call(part_1738, V.Undef, u_1764, ((V)(0.7)));
}, 2, "", true)), V.Undef, t_1755, s_1756);
Call(unsee_1032, V.Undef, t_1755);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1776, int _argc1768, V t_1774, V s_1775, V _a1772, V _a1773, V[] _rest1769) => {
return Call(nose_1045, V.Undef, t_1774, (Get(F_1737, "nose") is var _t1785 && Truthy(_t1785) ? _t1785 : Fn((V _arrowThis1784, int _argc1777, V u_1783, V _a1780, V _a1781, V _a1782, V[] _rest1778) => {
Call(sniff_1034, V.Undef, u_1783, ((V)(2D)));
Call(tasteHeart_1044, V.Undef, u_1783);
return default;
}, 1, "", true)));
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1794, int _argc1786, V t_1792, V s_1793, V _a1790, V _a1791, V[] _rest1787) => {
Call(eyeRub_1040, V.Undef, t_1792, s_1793);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1803, int _argc1795, V t_1801, V s_1802, V _a1799, V _a1800, V[] _rest1796) => {
Call(leanIn_1037, V.Undef, t_1801, s_1802, Get(F_1737, "cheekX"));
if (Truthy(Get(F_1737, "cheekX"))) {
V z_1804 = default;
z_1804 = NewObj(0).V;
{
foreach (V _k1805 in ForInKeys(Get(F_1737, "cheekX"))) {
V p_1806 = default;
p_1806 = _k1805;
SetK(z_1804, p_1806, ((V)(0D)));
}
}
Invoke(t_1801, "to", ((V)(220D)), z_1804, ((V)("io")));
}
return default;
}, 2, "cheek", true)).Put("belly", (Get(F_1737, "belly") is var _t1825 && Truthy(_t1825) ? _t1825 : Fn((V _arrowThis1815, int _argc1807, V t_1813, V s_1814, V _a1811, V _a1812, V[] _rest1808) => {
Call(tickle_1043, V.Undef, t_1813, (Get(F_1737, "tick") is var _t1824 && Truthy(_t1824) ? _t1824 : Fn((V _arrowThis1823, int _argc1816, V u_1822, V _a1819, V _a1820, V _a1821, V[] _rest1817) => {
return Call(part_1738, V.Undef, u_1822, ((V)(0.7)));
}, 1, "", true)));
return default;
}, 2, "", true))).Put("side", Fn((V _arrowThis1834, int _argc1826, V t_1832, V s_1833, V _a1830, V _a1831, V[] _rest1827) => {
Call((Get(F_1737, "side") is var _t1844 && Truthy(_t1844) ? _t1844 : Fn((V _arrowThis1843, int _argc1835, V u_1841, V s_1842, V _a1839, V _a1840, V[] _rest1836) => {
return Call(jelly_1030, V.Undef, u_1841, ((V)(3D)), ((V)(3D)), ((V)(320D)), ((V)("bend")));
}, 2, "", true)), V.Undef, t_1832, s_1833);
Call(see_1031, V.Undef, t_1832, ((V)("side")), s_1833, ((V)(200D)));
Call(unsee_1032, V.Undef, t_1832, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", (Get(F_1737, "foot") is var _t1854 && Truthy(_t1854) ? _t1854 : Fn((V _arrowThis1853, int _argc1845, V t_1851, V s_1852, V _a1849, V _a1850, V[] _rest1846) => {
Call(hop_1042, V.Undef, t_1851, ((V)(6D)), Arr(Arr(((V)("emit")), GetK(JU_1047, k_1735), ((V)("head")), ((V)(2D)))));
return default;
}, 2, "", true))).Put("tail", Fn((V _arrowThis1863, int _argc1855, V t_1861, V s_1862, V _a1859, V _a1860, V[] _rest1856) => {
Call(part_1738, V.Undef, t_1861, ((V)(0.5)));
Call(lookBack_1041, V.Undef, t_1861);
return default;
}, 2, "tail", true)).V);
return default;
}, 1, "", true));
BODY_1051 = NewObj(20).Put("pina", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("crown"))).Put("head", ((V)("Crown"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("avo", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("leaf"))).Put("head", ((V)("Sprout leaves"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Pit"))).Put("tail", ((V)("Back"))).V).V).Put("berri", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("leaf"))).Put("head", ((V)("Leafy top"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Seeds"))).Put("tail", ((V)("Back"))).V).V).Put("lemmy", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _arrowThis1871, int _argc1864, V s_1870, V _a1867, V _a1868, V _a1869, V[] _rest1865) => {
return ((V)((GtN(s_1870, 0D) ? "Right tip" : "Left tip")));
}, 1, "ear", true)).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("kiwi", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("fuzz"))).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Kiwi slice"))).Put("tail", ((V)("Back"))).V).V).Put("melo", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("rind corner"))).Put("head", ((V)("Top"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Seeds"))).Put("tail", ((V)("Rind (back)"))).V).V).Put("peachy", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("leaf"))).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("pitaya", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _arrowThis1879, int _argc1872, V s_1878, V _a1875, V _a1876, V _a1877, V[] _rest1873) => {
return ((V)((GtN(s_1878, 0D) ? "Right wing" : "Left wing")));
}, 1, "ear", true)).Put("head", ((V)("Crown"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Bracts"))).Put("tail", ((V)("Back"))).V).V).Put("tutti", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _arrowThis1887, int _argc1880, V s_1886, V _a1883, V _a1884, V _a1885, V[] _rest1881) => {
return ((V)((GtN(s_1886, 0D) ? "Right wing" : "Left wing")));
}, 1, "ear", true)).Put("head", ((V)("Fruit crown"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Basket"))).Put("tail", ((V)("Basket (back)"))).V).V).Put("nana", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _arrowThis1895, int _argc1888, V s_1894, V _a1891, V _a1892, V _a1893, V[] _rest1889) => {
return ((V)((GtN(s_1894, 0D) ? "Stalk" : "Peel (top left)")));
}, 1, "ear", true)).Put("head", ((V)("Stalk"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("bing", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _arrowThis1903, int _argc1896, V s_1902, V _a1899, V _a1900, V _a1901, V[] _rest1897) => {
return ((V)((GtN(s_1902, 0D) ? "Leaf" : "Top left")));
}, 1, "ear", true)).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("plummy", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _arrowThis1911, int _argc1904, V s_1910, V _a1907, V _a1908, V _a1909, V[] _rest1905) => {
return ((V)((GtN(s_1910, 0D) ? "Leaf" : "Top left")));
}, 1, "ear", true)).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("clemmy", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("leaf"))).Put("head", ((V)("Leaves"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Peel"))).Put("tail", ((V)("Back"))).V).V).Put("appy", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _arrowThis1919, int _argc1912, V s_1918, V _a1915, V _a1916, V _a1917, V[] _rest1913) => {
return ((V)((GtN(s_1918, 0D) ? "Leaf" : "Top left")));
}, 1, "ear", true)).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("blueby", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("crown"))).Put("head", ((V)("Star crown"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("coco", NewObj(3).Put("ear", ((V)(0.6))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("ear", ((V)("top"))).Put("head", ((V)("Coconut eyes"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Hairy tummy"))).Put("foot", ((V)("bottom"))).Put("tail", ((V)("Back"))).V).V).Put("perry", NewObj(3).Put("ear", ((V)(0.6))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("ear", ((V)("neck"))).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("foot", ((V)("bottom"))).Put("tail", ((V)("Back"))).V).V).Put("grana", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("crown"))).Put("head", ((V)("Crown"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("mangie", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _arrowThis1927, int _argc1920, V s_1926, V _a1923, V _a1924, V _a1925, V[] _rest1921) => {
return ((V)((GtN(s_1926, 0D) ? "Leaf" : "Top left")));
}, 1, "ear", true)).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("razzy", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("leafy top"))).Put("head", ((V)("Leafy top"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Beads"))).Put("tail", ((V)("Back"))).V).V).V;
he_1052 = NewObj(11).Put("pina", ((V)(1D))).Put("avo", ((V)(1D))).Put("berri", ((V)(1D))).Put("lemmy", ((V)(1D))).Put("kiwi", ((V)(1D))).Put("melo", ((V)(1D))).Put("pitaya", ((V)(1D))).Put("plummy", ((V)(1D))).Put("coco", ((V)(1D))).Put("perry", ((V)(1D))).Put("grana", ((V)(1D))).V;
pr_1053 = Fn((V _arrowThis1935, int _argc1928, V k_1934, V _a1931, V _a1932, V _a1933, V[] _rest1929) => {
return (Truthy(GetK(he_1052, k_1934)) ? Arr(((V)("he")), ((V)("his")), ((V)("him"))) : Arr(((V)("she")), ((V)("her")), ((V)("her"))));
}, 1, "", true);
T0_1054 = Fn((V _arrowThis1943, int _argc1936, V k_1942, V _a1939, V _a1940, V _a1941, V[] _rest1937) => {
V a_1944 = default;
V b_1945 = default;
V A_1946 = default;
{ V _t1947 = Call(pr_1053, V.Undef, k_1942);
{ V _t1948 = ListOf(_t1947);
{ V _t1949 = GetIdx(_t1948, 0D);
a_1944 = _t1949; }
{ V _t1950 = GetIdx(_t1948, 1D);
b_1945 = _t1950; }
} }
A_1946 = Add(Invoke(GetIdx(a_1944, 0D), "toUpperCase"), Invoke(a_1944, "slice", ((V)(1D))));
return NewObj(6).Put("nose", ((V)("Sniffs your finger and licks it: a heart."))).Put("eye", ((V)(JsStrBuf.Begin().S("Blinks hard and rubs ").V(b_1945).S(" eye.").End()))).Put("cheek", ((V)("Leans into your finger, eyes closed."))).Put("side", ((V)("Wobbles away from the poke and looks at the spot."))).Put("A", A_1946).Put("b", b_1945).V;
return default;
}, 1, "", true);
TX_1055 = NewObj(20).Put("pina", NewObj(6).Put("head", ((V)("His crown pops open, he giggles."))).Put("ear", ((V)("His crown leaves flare at the touch."))).Put("belly", ((V)("Ticklish tummy: giggles while his crown whirls."))).Put("side", ((V)("Sways away like a palm tree and back, crown whirling."))).Put("foot", ((V)("A hop with a squirt of pineapple juice."))).Put("tail", ((V)("His crown flares, he looks back."))).V).Put("avo", NewObj(5).Put("head", ((V)("His sprout leaves flap and spin like a propeller, he giggles."))).Put("ear", ((V)("His pit pops out a little and wobbles back in."))).Put("belly", ((V)("Ticklish pit: it rolls round in its socket while he giggles."))).Put("foot", ((V)("A hop - a bit of guac flies."))).Put("tail", ((V)("His pit bobs, he looks back."))).V).Put("berri", NewObj(5).Put("head", ((V)("His leaves fly up and his stem boings, a drop of juice, a giggle."))).Put("ear", ((V)("His leafy top flaps at the touch."))).Put("belly", ((V)("Ticklish seeds: giggles while his stem boings."))).Put("foot", ((V)("A juicy hop."))).Put("tail", ((V)("His leaves flap, he looks back."))).V).Put("lemmy", NewObj(6).Put("head", ((V)("Puckers up sour, then grins."))).Put("ear", ((V)("A sour little pucker at the touch."))).Put("nose", ((V)("Sniffs your finger - so sour! - shivers, then grins."))).Put("belly", ((V)("Ticklish: a zesty shimmy and a spray of juice."))).Put("foot", ((V)("A hop with a squirt of lemon juice."))).Put("tail", ((V)("Puckers, looks back."))).V).Put("kiwi", NewObj(5).Put("head", ((V)("Bobs his head like a little bird, his stem bobs, a giggle."))).Put("ear", ((V)("His fuzz bristles at the touch."))).Put("belly", ((V)("Ticklish slice: giggles, fuzz puffing up."))).Put("foot", ((V)("A hop - kiwi juice drips."))).Put("tail", ((V)("His fuzz ruffles, he looks back."))).V).Put("melo", NewObj(5).Put("head", ((V)("All his seeds jiggle, he giggles."))).Put("ear", ((V)("His seeds jiggle at the touch."))).Put("belly", ((V)("Ticklish seeds: giggles while they jiggle."))).Put("foot", ((V)("A hop - his seeds jump and juice splashes."))).Put("tail", ((V)("His seeds wobble, he looks back."))).V).Put("peachy", NewObj(6).Put("head", ((V)("Blushes pink and her leaf flaps, she giggles."))).Put("ear", ((V)("Blushes at the touch, her leaf fluttering."))).Put("cheek", ((V)("Leans her fuzzy cheek into your finger and blushes."))).Put("belly", ((V)("Ticklish: giggles and blushes all over."))).Put("foot", ((V)("A gentle hop - a drop of peach juice."))).Put("tail", ((V)("Blushes, looks back."))).V).Put("pitaya", NewObj(5).Put("head", ((V)("His crown flares and he sparkles, a giggle."))).Put("ear", Fn((V _arrowThis1958, int _argc1951, V s_1957, V _a1954, V _a1955, V _a1956, V[] _rest1952) => {
return ((V)(string.Concat("His ", (GtN(s_1957, 0D) ? "right" : "left"), " wing spreads and flaps.")));
}, 1, "ear", true)).Put("belly", ((V)("Ticklish bracts: giggles, wings flapping."))).Put("foot", ((V)("A hop - dragonfruit juice drips."))).Put("tail", ((V)("His bracts flare, he looks back."))).V).Put("tutti", NewObj(5).Put("head", ((V)("Her fruit crown bounces and her wings flutter, a giggle."))).Put("ear", Fn((V _arrowThis1966, int _argc1959, V s_1965, V _a1962, V _a1963, V _a1964, V[] _rest1960) => {
return ((V)(string.Concat("Her ", (GtN(s_1965, 0D) ? "right" : "left"), " wing flutters fast, fairy dust falls.")));
}, 1, "ear", true)).Put("belly", Fn((V _arrowThis1974, int _argc1967, V s_1973, V _a1970, V _a1971, V _a1972, V[] _rest1968) => {
return ((V)(string.Concat("Ticklish basket: giggles - her ", (LtN(s_1973, 0D) ? "cherry" : "pear"), " hops out and back in.")));
}, 1, "belly", true)).Put("foot", ((V)("A hop - fairy juice drips."))).Put("tail", ((V)("Her crown bounces, she looks back."))).V).Put("nana", NewObj(6).Put("head", ((V)("Her curve wobbles like jelly, she giggles."))).Put("ear", Fn((V _arrowThis1982, int _argc1975, V s_1981, V _a1978, V _a1979, V _a1980, V[] _rest1976) => {
return ((V)((GtN(s_1981, 0D) ? "Her stalk gets a tap - her curve wobbles." : "Her peel gets a tap - her curve wobbles.")));
}, 1, "ear", true)).Put("belly", ((V)("Ticklish: her curve flips side to side while she giggles."))).Put("side", ((V)("Bends away from the poke like a reed and springs back."))).Put("foot", ((V)("A hop - a drop of banana."))).Put("tail", ((V)("Her curve wobbles, she looks back."))).V).Put("bing", NewObj(5).Put("head", ((V)("Her stem spins right round, she giggles."))).Put("ear", Fn((V _arrowThis1990, int _argc1983, V s_1989, V _a1986, V _a1987, V _a1988, V[] _rest1984) => {
return ((V)((GtN(s_1989, 0D) ? "Her leaf flutters and the stem wobbles." : "Her stem wobbles at the touch.")));
}, 1, "ear", true)).Put("belly", ((V)("Ticklish: giggles while her stem sways."))).Put("foot", ((V)("A bouncy hop - cherry juice drips."))).Put("tail", ((V)("Her stem wobbles, she looks back."))).V).Put("plummy", NewObj(6).Put("head", ((V)("His stem spins right round, he giggles."))).Put("ear", Fn((V _arrowThis1998, int _argc1991, V s_1997, V _a1994, V _a1995, V _a1996, V[] _rest1992) => {
return ((V)((GtN(s_1997, 0D) ? "His leaf flutters at the touch." : "His stem wobbles at the touch.")));
}, 1, "ear", true)).Put("cheek", ((V)("Leans into your finger and blushes."))).Put("belly", ((V)("Ticklish: giggles - the tickle rubs a shiny spot in his dusty bloom."))).Put("foot", ((V)("Rises on tiptoe and does a little pirouette, giggling."))).Put("tail", ((V)("His leaf flutters, he looks back."))).V).Put("clemmy", NewObj(5).Put("head", ((V)("Her leaves twirl round and she spritzes zest, a giggle."))).Put("ear", ((V)("Her leaf flaps and a little zest sprays."))).Put("belly", ((V)("Ticklish peel: giggles, spritzing zest."))).Put("foot", ((V)("A zippy hop - zest sprays."))).Put("tail", ((V)("A spritz of zest, she looks back."))).V).Put("appy", NewObj(5).Put("head", ((V)("A crisp little bounce with a sparkle, she giggles."))).Put("ear", Fn((V _arrowThis2006, int _argc1999, V s_2005, V _a2002, V _a2003, V _a2004, V[] _rest2000) => {
return ((V)((GtN(s_2005, 0D) ? "Her leaf flutters at the touch." : "Looks up at the touch, her leaf flutters.")));
}, 1, "ear", true)).Put("belly", ((V)("Ticklish: giggles, leaf fluttering."))).Put("foot", ((V)("A crisp hop - apple juice drips."))).Put("tail", ((V)("Her leaf flutters, she looks back."))).V).Put("blueby", NewObj(6).Put("head", ((V)("Her star crown flares, she giggles."))).Put("ear", ((V)("Her crown flares at the touch."))).Put("belly", ((V)("Ticklish tummy: rocks and rolls with giggles."))).Put("side", Fn((V _arrowThis2014, int _argc2007, V s_2013, V _a2010, V _a2011, V _a2012, V[] _rest2008) => {
return ((V)("Rolls away from the poke and rocks back onto her feet."));
}, 1, "side", true)).Put("foot", Fn((V _arrowThis2022, int _argc2015, V s_2021, V _a2018, V _a2019, V _a2020, V[] _rest2016) => {
return ((V)(string.Concat("Rolls right over ", (LtN(s_2021, 0D) ? "to the right" : "to the left"), " and back up, giggling.")));
}, 1, "foot", true)).Put("tail", ((V)("Her crown flares, she looks back."))).V).Put("coco", NewObj(5).Put("head", ((V)("Knock! Hollow - he listens, then grins."))).Put("ear", ((V)("His hair stands up at the touch."))).Put("belly", ((V)("Ticklish hairy tummy: knock, knock, knock - giggles."))).Put("foot", Fn((V _arrowThis2030, int _argc2023, V s_2029, V _a2026, V _a2027, V _a2028, V[] _rest2024) => {
return ((V)(string.Concat("Rolls right over ", (LtN(s_2029, 0D) ? "to the right" : "to the left"), " and back, giggling.")));
}, 1, "foot", true)).Put("tail", ((V)("His hair bristles, he looks back."))).V).Put("perry", NewObj(6).Put("head", ((V)("Wobbles on his round bottom, he giggles."))).Put("ear", ((V)("Wobbles at the touch on his neck."))).Put("belly", ((V)("Ticklish tummy: giggles, wobbling."))).Put("side", ((V)("Tips far over away from the poke and wobbles back like a roly-poly."))).Put("foot", ((V)("Tips over on his round bottom and wobbles back up, giggling."))).Put("tail", ((V)("A wobble, he looks back."))).V).Put("grana", NewObj(6).Put("head", ((V)("His crown spins and flares - he lifts his chin proudly."))).Put("ear", ((V)("His crown flares and a few ruby seeds fall."))).Put("cheek", ((V)("Leans into your finger with royal dignity."))).Put("belly", ((V)("Ticklish: giggles, ruby seeds falling."))).Put("foot", ((V)("A royal hop - ruby seeds bounce."))).Put("tail", ((V)("His crown flares, he looks back."))).V).Put("mangie", NewObj(6).Put("head", ((V)("Her leaf flicks like a hair toss, she giggles."))).Put("ear", Fn((V _arrowThis2038, int _argc2031, V s_2037, V _a2034, V _a2035, V _a2036, V[] _rest2032) => {
return ((V)((GtN(s_2037, 0D) ? "Her leaf flicks at the touch." : "Her leaf flicks from the touch.")));
}, 1, "ear", true)).Put("cheek", ((V)("Leans into your finger, blushing like a sunset."))).Put("belly", ((V)("Ticklish: giggles, leaf flicking."))).Put("foot", ((V)("A sunny hop - mango juice drips."))).Put("tail", ((V)("Her leaf flicks, she looks back."))).V).Put("razzy", NewObj(5).Put("head", ((V)("Every bead on her jiggles and sparkles, she giggles."))).Put("ear", ((V)("Her beads jiggle at the touch."))).Put("belly", ((V)("Ticklish beads: giggles, wobbling all over."))).Put("foot", ((V)("A hop - raspberry juice drips."))).Put("tail", ((V)("Her beads jiggle, she looks back."))).V).V;
TXT_1056 = NewObj(0).V;
Invoke(Get(Get(R_1022, "FRUITLIB"), "KEYS"), "forEach", Fn((V _arrowThis2046, int _argc2039, V k_2045, V _a2042, V _a2043, V _a2044, V[] _rest2040) => {
V d_2047 = default;
d_2047 = Call(T0_1054, V.Undef, k_2045);
SetK(TXT_1056, k_2045, Object_assign(NewObj(4).Put("nose", Get(d_2047, "nose")).Put("eye", Get(d_2047, "eye")).Put("cheek", Get(d_2047, "cheek")).Put("side", Get(d_2047, "side")).V, GetK(TX_1055, k_2045)));
return default;
}, 1, "", true));
Call(build_1039, V.Undef, RE_1050, TXT_1056, BODY_1051);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_2074 => Fn((V _self2048, int _argc2049, V _a2051, V _a2052, V _a2053, V _a2054, V[] _rest2050) => {
V R_2055 = default;
V hand_2056 = default;
V both_2057 = default;
V o_2058 = default;
V NOHANDS_2059 = default;
V jump_2060 = default;
V swing_2061 = default;
V jelly_2062 = default;
V shake_2063 = default;
V EAR_2064 = default;
V sniffF_2065 = default;
V lipLick_2066 = default;
V hearts_2067 = default;
V pat_2068 = default;
V buildAll_2069 = default;
V JU_2070 = default;
V hop_2071 = default;
V yay_2072 = default;
V C_2073 = default;
if (_self2048.IsNullish) _self2048 = GlobalV;
R_2055 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_2055)) || !(Truthy(Get(R_2055, "EATKIT")))) || !(Truthy(Get(R_2055, "fruitV")))) || !(Truthy(Get(R_2055, "EATLIB"))))) {
Call(G("setTimeout"), V.Undef, boot_2074.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_2055, "fruitEatV"))) {
return default;
}
Set(R_2055, "fruitEatV", ((V)(1D)));
{ V _t2075 = Get(R_2055, "PETLIB");
if (_t2075.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2075));
{ V _t2076 = Get(_t2075, "hand");
hand_2056 = _t2076; }
{ V _t2077 = Get(_t2075, "both");
both_2057 = _t2077; }
{ V _t2078 = Get(_t2075, "o");
o_2058 = _t2078; }
{ V _t2079 = Get(_t2075, "NOHANDS");
NOHANDS_2059 = _t2079; }
{ V _t2080 = Get(_t2075, "jump");
jump_2060 = _t2080; }
{ V _t2081 = Get(_t2075, "swing");
swing_2061 = _t2081; }
{ V _t2082 = Get(_t2075, "jelly");
jelly_2062 = _t2082; }
{ V _t2083 = Get(_t2075, "shake");
shake_2063 = _t2083; } }
{ V _t2084 = Get(R_2055, "EATKIT");
if (_t2084.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t2084));
{ V _t2085 = Get(_t2084, "EAR");
EAR_2064 = _t2085; }
{ V _t2086 = Get(_t2084, "sniffF");
sniffF_2065 = _t2086; }
{ V _t2087 = Get(_t2084, "lipLick");
lipLick_2066 = _t2087; }
{ V _t2088 = Get(_t2084, "hearts");
hearts_2067 = _t2088; }
{ V _t2089 = Get(_t2084, "pat");
pat_2068 = _t2089; }
{ V _t2090 = Get(_t2084, "buildAll");
buildAll_2069 = _t2090; } }
JU_2070 = Get(Get(R_2055, "FRUITLIB"), "JUICE");
Invoke(Get(Get(R_2055, "FRUITLIB"), "KEYS"), "forEach", Fn((V _arrowThis2098, int _argc2091, V k_2097, V _a2094, V _a2095, V _a2096, V[] _rest2092) => {
if (GetK(EAR_2064, k_2097).IsNullish) {
SetK(EAR_2064, k_2097, ((V)(0.6)));
}
return default;
}, 1, "", true));
hop_2071 = Fn((V _arrowThis2108, int _argc2099, V t_2105, V h_2106, V x_2107, V _a2104, V[] _rest2100) => {
return Call(jump_2060, V.Undef, t_2105, Call(o_2058, V.Undef, NewObj(5).Put("h", (h_2106 is var _t2109 && Truthy(_t2109) ? _t2109 : ((V)(6D)))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).V, (x_2107 is var _t2110 && Truthy(_t2110) ? _t2110 : NewObj(0).V)));
}, 3, "", true);
yay_2072 = Fn((V _arrowThis2118, int _argc2111, V t_2117, V _a2114, V _a2115, V _a2116, V[] _rest2112) => {
return Invoke(t_2117, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
}, 1, "", true);
C_2073 = NewObj(20).Put("pina", NewObj(8).Put("chewMs", ((V)(125D))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.8))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("A happy hula wiggle first, big tropical bites, his crown pops open when he likes it."))).Put("pre", Fn((V _arrowThis2126, int _argc2119, V t_2125, V _a2122, V _a2123, V _a2124, V[] _rest2120) => {
return Call(swing_2061, V.Undef, t_2125, ((V)(700D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(4D))).Put("x", ((V)(1D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2134, int _argc2127, V t_2133, V _a2130, V _a2131, V _a2132, V[] _rest2128) => {
return Call(lipLick_2066, V.Undef, t_2133);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2142, int _argc2135, V t_2141, V _a2138, V _a2139, V _a2140, V[] _rest2136) => {
Call(yay_2072, V.Undef, t_2141);
Invoke(Invoke(Invoke(t_2141, "to", ((V)(140D)), NewObj(1).Put("crw", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("pinjuice")), ((V)("head")), ((V)(2D))), "to", ((V)(360D)), NewObj(1).Put("crw", ((V)(0D))).V, ((V)("io")));
Call(swing_2061, V.Undef, t_2141, ((V)(900D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("avo", NewObj(9).Put("savor", ((V)(0.5))).Put("chewMs", ((V)(140D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Calm, buttery bites, pats his pit when he is full, his leaves flap when he likes it."))).Put("pre", Fn((V _arrowThis2150, int _argc2143, V t_2149, V _a2146, V _a2147, V _a2148, V[] _rest2144) => {
return Call(sniffF_2065, V.Undef, t_2149, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2158, int _argc2151, V t_2157, V _a2154, V _a2155, V _a2156, V[] _rest2152) => {
Invoke(Invoke(Invoke(Invoke(t_2157, "to", ((V)(300D)), Call(o_2058, V.Undef, Call(both_2057, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(2).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("prw", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("prw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), Call(o_2058, V.Undef, NOHANDS_2059, NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2166, int _argc2159, V t_2165, V _a2162, V _a2163, V _a2164, V[] _rest2160) => {
Call(yay_2072, V.Undef, t_2165);
Invoke(Invoke(t_2165, "to", ((V)(200D)), NewObj(2).Put("lfl", ((V)(0.9))).Put("pp", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("lfl", ((V)(0D))).Put("pp", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("berri", NewObj(8).Put("chewMs", ((V)(120D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Quick sweet bites, a happy squirt of juice, his leaves flap and his stem boings when he likes it."))).Put("pre", Fn((V _arrowThis2174, int _argc2167, V t_2173, V _a2170, V _a2171, V _a2172, V[] _rest2168) => {
return Call(sniffF_2065, V.Undef, t_2173, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2182, int _argc2175, V t_2181, V _a2178, V _a2179, V _a2180, V[] _rest2176) => {
return Call(lipLick_2066, V.Undef, t_2181);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2190, int _argc2183, V t_2189, V _a2186, V _a2187, V _a2188, V[] _rest2184) => {
Call(yay_2072, V.Undef, t_2189);
Invoke(Invoke(Invoke(t_2189, "to", ((V)(140D)), NewObj(2).Put("lfl", ((V)(1D))).Put("stw", ((V)(0.8))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("juice")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0D))).V, ((V)("io")));
Call(jelly_2062, V.Undef, t_2189, ((V)(0.6)), ((V)(3D)), ((V)(240D)), ((V)("stw")));
return default;
}, 1, "yum", true)).V).Put("lemmy", NewObj(9).Put("chewMs", ((V)(110D))).Put("chewN", ((V)(0.9))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Sniffs it suspiciously, quick zesty bites - a sour pucker shiver - then he grins and flaps his leaf."))).Put("pre", Fn((V _arrowThis2198, int _argc2191, V t_2197, V _a2194, V _a2195, V _a2196, V[] _rest2192) => {
Call(sniffF_2065, V.Undef, t_2197, ((V)(1D)));
Invoke(Invoke(t_2197, "to", ((V)(120D)), NewObj(2).Put("close", ((V)(0.6))).Put("mw", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2206, int _argc2199, V t_2205, V _a2202, V _a2203, V _a2204, V[] _rest2200) => {
Invoke(t_2205, "to", ((V)(110D)), NewObj(2).Put("close", ((V)(0.85))).Put("mw", ((V)(0.35))).V, ((V)("o")));
Call(shake_2063, V.Undef, t_2205, NewObj(4).Put("P", ((V)(70D))).Put("head", ((V)(0.14))).Put("roll", ((V)(2D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.6)), ((V)(0.3)))).V);
Invoke(t_2205, "to", ((V)(200D)), NewObj(2).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2214, int _argc2207, V t_2213, V _a2210, V _a2211, V _a2212, V[] _rest2208) => {
Call(yay_2072, V.Undef, t_2213);
Invoke(Invoke(Invoke(t_2213, "to", ((V)(200D)), NewObj(1).Put("lfl", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("lemjuice")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "yum", true)).V).Put("kiwi", NewObj(9).Put("chewMs", ((V)(100D))).Put("chewN", ((V)(1.2))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Pecks at it like a little bird - lots of quick small bites - and fluffs his fuzz when he likes it."))).Put("pre", Fn((V _arrowThis2222, int _argc2215, V t_2221, V _a2218, V _a2219, V _a2220, V[] _rest2216) => {
{
double i_2223 = 0;
i_2223 = 0D;
while (true) {
if (!((i_2223 < 2D))) break;
Invoke(Invoke(t_2221, "to", ((V)(130D)), NewObj(1).Put("pitch", ((V)((-0.12)))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("i")));
i_2223++;
}
}
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2232, int _argc2225, V t_2231, V _a2228, V _a2229, V _a2230, V[] _rest2226) => {
return Invoke(Invoke(t_2231, "to", ((V)(200D)), NewObj(1).Put("fzz", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("fzz", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2240, int _argc2233, V t_2239, V _a2236, V _a2237, V _a2238, V[] _rest2234) => {
Call(yay_2072, V.Undef, t_2239);
Invoke(Invoke(Invoke(t_2239, "to", ((V)(200D)), NewObj(1).Put("fzz", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("kiwifuzz")), ((V)("head")), ((V)(2D))), "to", ((V)(400D)), NewObj(1).Put("fzz", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("melo", NewObj(9).Put("savor", ((V)(0.4))).Put("chewMs", ((V)(135D))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.85))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Big juicy summer bites, spits a seed after, his seeds jiggle when he likes it."))).Put("pre", Fn((V _arrowThis2248, int _argc2241, V t_2247, V _a2244, V _a2245, V _a2246, V[] _rest2242) => {
return Call(sniffF_2065, V.Undef, t_2247, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2256, int _argc2249, V t_2255, V _a2252, V _a2253, V _a2254, V[] _rest2250) => {
Invoke(Invoke(Invoke(Invoke(t_2255, "to", ((V)(250D)), NewObj(1).Put("puff", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(80D)), NewObj(3).Put("puff", ((V)((-0.2)))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth")), ((V)(1D))), "to", ((V)(200D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2264, int _argc2257, V t_2263, V _a2260, V _a2261, V _a2262, V[] _rest2258) => {
Call(yay_2072, V.Undef, t_2263);
Invoke(Invoke(Invoke(t_2263, "to", ((V)(150D)), NewObj(1).Put("sdj", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("melojuice")), ((V)("head")), ((V)(2D))), "to", ((V)(500D)), NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("peachy", NewObj(10).Put("savor", ((V)(0.7))).Put("chewMs", ((V)(150D))).Put("chewN", ((V)(1D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Dainty little bites with her eyes closed, blushing - her leaf whirls when she likes it."))).Put("pre", Fn((V _arrowThis2272, int _argc2265, V t_2271, V _a2268, V _a2269, V _a2270, V[] _rest2266) => {
return Invoke(t_2271, "to", ((V)(260D)), NewObj(1).Put("blush", ((V)(0.6))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2280, int _argc2273, V t_2279, V _a2276, V _a2277, V _a2278, V[] _rest2274) => {
return Invoke(Invoke(Invoke(t_2279, "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0.6))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(250D)), NewObj(2).Put("close", ((V)(0D))).Put("blush", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2288, int _argc2281, V t_2287, V _a2284, V _a2285, V _a2286, V[] _rest2282) => {
Call(yay_2072, V.Undef, t_2287);
Invoke(Invoke(Invoke(t_2287, "to", ((V)(700D)), NewObj(2).Put("lsp", ((V)(1D))).Put("blush", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("lsp", ((V)(0D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("pitaya", NewObj(8).Put("chewMs", ((V)(115D))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.9))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Fierce dragon chomps, bracts bristling, then his wings flap and he sparkles when he likes it."))).Put("pre", Fn((V _arrowThis2296, int _argc2289, V t_2295, V _a2292, V _a2293, V _a2294, V[] _rest2290) => {
return Invoke(Invoke(t_2295, "to", ((V)(200D)), NewObj(2).Put("brf", ((V)(0.6))).Put("wsp", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("brf", ((V)(0D))).Put("wsp", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2304, int _argc2297, V t_2303, V _a2300, V _a2301, V _a2302, V[] _rest2298) => {
return Call(lipLick_2066, V.Undef, t_2303, (true ? V.True : V.False));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2312, int _argc2305, V t_2311, V _a2308, V _a2309, V _a2310, V[] _rest2306) => {
Call(yay_2072, V.Undef, t_2311);
Invoke(Invoke(Invoke(t_2311, "to", ((V)(200D)), NewObj(3).Put("wsp", ((V)(1D))).Put("wfl", ((V)(1.3))).Put("spk", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(400D)), NewObj(3).Put("wsp", ((V)(0D))).Put("wfl", ((V)(0D))).Put("spk", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("tutti", NewObj(9).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(140D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Flutters up to it, dainty fairy bites, her crown bounces and fairy dust falls when she likes it."))).Put("pre", Fn((V _arrowThis2320, int _argc2313, V t_2319, V _a2316, V _a2317, V _a2318, V[] _rest2314) => {
return Invoke(Invoke(t_2319, "to", ((V)(260D)), NewObj(2).Put("wfl", ((V)(1D))).Put("lift", ((V)(2D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(2).Put("wfl", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2328, int _argc2321, V t_2327, V _a2324, V _a2325, V _a2326, V[] _rest2322) => {
return Call(lipLick_2066, V.Undef, t_2327);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2336, int _argc2329, V t_2335, V _a2332, V _a2333, V _a2334, V[] _rest2330) => {
Call(yay_2072, V.Undef, t_2335);
Invoke(Invoke(Invoke(t_2335, "to", ((V)(150D)), NewObj(2).Put("cb", ((V)(1D))).Put("wfl", ((V)(1.2))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("head")), ((V)(3D))), "to", ((V)(400D)), NewObj(2).Put("cb", ((V)(0D))).Put("wfl", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("nana", NewObj(8).Put("chewMs", ((V)(130D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Curls round the food to look at it, happy bites, and her curve wiggles when she likes it."))).Put("pre", Fn((V _arrowThis2344, int _argc2337, V t_2343, V _a2340, V _a2341, V _a2342, V[] _rest2338) => {
return Invoke(Invoke(t_2343, "to", ((V)(320D)), NewObj(2).Put("cv", ((V)(0.7))).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("cv", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2352, int _argc2345, V t_2351, V _a2348, V _a2349, V _a2350, V[] _rest2346) => {
return Call(lipLick_2066, V.Undef, t_2351);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2360, int _argc2353, V t_2359, V _a2356, V _a2357, V _a2358, V[] _rest2354) => {
Call(yay_2072, V.Undef, t_2359);
Invoke(Invoke(t_2359, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("cv", ((V)(0.7))).V, NewObj(1).Put("cv", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("cv", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("bing", NewObj(8).Put("chewMs", ((V)(115D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.65))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Bouncy little bites, a squirt of cherry juice, her stem twirls when she likes it."))).Put("pre", Fn((V _arrowThis2368, int _argc2361, V t_2367, V _a2364, V _a2365, V _a2366, V[] _rest2362) => {
return Call(sniffF_2065, V.Undef, t_2367, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2376, int _argc2369, V t_2375, V _a2372, V _a2373, V _a2374, V[] _rest2370) => {
return Call(lipLick_2066, V.Undef, t_2375);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2384, int _argc2377, V t_2383, V _a2380, V _a2381, V _a2382, V[] _rest2378) => {
Call(yay_2072, V.Undef, t_2383);
Invoke(Invoke(Invoke(t_2383, "to", ((V)(600D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(hop_2071, V.Undef, t_2383, ((V)(5D)));
return default;
}, 1, "yum", true)).V).Put("plummy", NewObj(9).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(135D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Dainty ballet bites with his eyes closed, then a twirl on tiptoe when he likes it."))).Put("pre", Fn((V _arrowThis2392, int _argc2385, V t_2391, V _a2388, V _a2389, V _a2390, V[] _rest2386) => {
return Call(sniffF_2065, V.Undef, t_2391, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2400, int _argc2393, V t_2399, V _a2396, V _a2397, V _a2398, V[] _rest2394) => {
return Call(lipLick_2066, V.Undef, t_2399);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2408, int _argc2401, V t_2407, V _a2404, V _a2405, V _a2406, V[] _rest2402) => {
Call(yay_2072, V.Undef, t_2407);
Invoke(Invoke(Invoke(Invoke(t_2407, "to", ((V)(260D)), NewObj(3).Put("lift", ((V)(1.5))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)("io"))), "to", ((V)(750D)), NewObj(2).Put("spin", ((V)(360D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(260D)), NewObj(4).Put("lift", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("clemmy", NewObj(9).Put("chewMs", ((V)(105D))).Put("chewN", ((V)(1.1))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.65))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Zippy quick bites, a spritz of zest after every few, a spin when she likes it."))).Put("pre", Fn((V _arrowThis2416, int _argc2409, V t_2415, V _a2412, V _a2413, V _a2414, V[] _rest2410) => {
return Call(sniffF_2065, V.Undef, t_2415, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2424, int _argc2417, V t_2423, V _a2420, V _a2421, V _a2422, V[] _rest2418) => {
return Invoke(t_2423, "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(3D)));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2432, int _argc2425, V t_2431, V _a2428, V _a2429, V _a2430, V[] _rest2426) => {
Call(yay_2072, V.Undef, t_2431);
Invoke(Invoke(Invoke(Invoke(t_2431, "to", ((V)(600D)), NewObj(2).Put("spin", ((V)(360D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(4D))), "to", ((V)(200D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("appy", NewObj(8).Put("chewMs", ((V)(120D))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Crisp crunchy bites, wipes her mouth neatly, a shiny sparkle when she likes it."))).Put("pre", Fn((V _arrowThis2440, int _argc2433, V t_2439, V _a2436, V _a2437, V _a2438, V[] _rest2434) => {
return Call(sniffF_2065, V.Undef, t_2439, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2448, int _argc2441, V t_2447, V _a2444, V _a2445, V _a2446, V[] _rest2442) => {
Invoke(Invoke(Invoke(t_2447, "to", ((V)(260D)), Call(o_2058, V.Undef, Call(hand_2056, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-14D)))), NewObj(1).Put("armR", ((V)(30D))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("hRx", ((V)((-14D)))).V, ((V)("io"))), "to", ((V)(260D)), Call(o_2058, V.Undef, NOHANDS_2059, NewObj(1).Put("armR", ((V)(0D))).V), ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2456, int _argc2449, V t_2455, V _a2452, V _a2453, V _a2454, V[] _rest2450) => {
Call(yay_2072, V.Undef, t_2455);
Invoke(Invoke(Invoke(t_2455, "to", ((V)(150D)), NewObj(2).Put("lf", ((V)(1D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("lf", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("blueby", NewObj(8).Put("chewMs", ((V)(120D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Rolls up to it, small round bites, rocks and rolls happily when she likes it."))).Put("pre", Fn((V _arrowThis2464, int _argc2457, V t_2463, V _a2460, V _a2461, V _a2462, V[] _rest2458) => {
return Invoke(Invoke(t_2463, "to", ((V)(400D)), NewObj(2).Put("rl", ((V)(20D))).Put("x", ((V)(3D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2472, int _argc2465, V t_2471, V _a2468, V _a2469, V _a2470, V[] _rest2466) => {
return Call(lipLick_2066, V.Undef, t_2471);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2480, int _argc2473, V t_2479, V _a2476, V _a2477, V _a2478, V[] _rest2474) => {
Call(yay_2072, V.Undef, t_2479);
Invoke(Invoke(Invoke(Invoke(Invoke(t_2479, "to", ((V)(350D)), NewObj(2).Put("rl", ((V)((-24D)))).Put("x", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(2).Put("rl", ((V)(24D))).Put("x", ((V)(3D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("coco", NewObj(9).Put("savor", ((V)(0.5))).Put("chewMs", ((V)(145D))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.8))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Chill, slow island bites, knocks on his belly when he is full, his hair fluffs when he likes it."))).Put("pre", Fn((V _arrowThis2488, int _argc2481, V t_2487, V _a2484, V _a2485, V _a2486, V[] _rest2482) => {
return Call(sniffF_2065, V.Undef, t_2487, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2496, int _argc2489, V t_2495, V _a2492, V _a2493, V _a2494, V[] _rest2490) => {
Invoke(Invoke(Invoke(Invoke(t_2495, "to", ((V)(250D)), Call(o_2058, V.Undef, Call(both_2057, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(2).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V), ((V)("io"))), "to", ((V)(110D)), NewObj(2).Put("hLy", ((V)(12D))).Put("hRy", ((V)(12D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("body")), ((V)(1D))), "to", ((V)(200D)), Call(o_2058, V.Undef, NOHANDS_2059, NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2504, int _argc2497, V t_2503, V _a2500, V _a2501, V _a2502, V[] _rest2498) => {
Call(yay_2072, V.Undef, t_2503);
Invoke(Invoke(t_2503, "to", ((V)(150D)), NewObj(2).Put("fz", ((V)(0.9))).Put("lf", ((V)(1D))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(2).Put("fz", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(swing_2061, V.Undef, t_2503, ((V)(900D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(4D))).Put("x", ((V)(1D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("perry", NewObj(9).Put("savor", ((V)(0.5))).Put("chewMs", ((V)(140D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.65))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Leans forward to each bite and wobbles back, juicy bites, a happy roly-poly wobble when he likes it."))).Put("pre", Fn((V _arrowThis2512, int _argc2505, V t_2511, V _a2508, V _a2509, V _a2510, V[] _rest2506) => {
Invoke(t_2511, "to", ((V)(300D)), NewObj(1).Put("tilt", ((V)(5D))).V, ((V)("io")));
Call(jelly_2062, V.Undef, t_2511, ((V)(4D)), ((V)(2D)), ((V)(360D)), ((V)("tilt")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2520, int _argc2513, V t_2519, V _a2516, V _a2517, V _a2518, V[] _rest2514) => {
return Call(lipLick_2066, V.Undef, t_2519);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2528, int _argc2521, V t_2527, V _a2524, V _a2525, V _a2526, V[] _rest2522) => {
Call(yay_2072, V.Undef, t_2527);
Invoke(t_2527, "to", ((V)(200D)), NewObj(1).Put("tilt", ((V)(8D))).V, ((V)("o")));
Call(jelly_2062, V.Undef, t_2527, ((V)(7D)), ((V)(3D)), ((V)(380D)), ((V)("tilt")));
return default;
}, 1, "yum", true)).V).Put("grana", NewObj(10).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(150D))).Put("chewN", ((V)(1D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Inspects it like a king, small royal bites, his crown flares and ruby seeds sparkle when he likes it."))).Put("pre", Fn((V _arrowThis2536, int _argc2529, V t_2535, V _a2532, V _a2533, V _a2534, V[] _rest2530) => {
return Invoke(Invoke(Invoke(t_2535, "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)(0.08))).Put("close", ((V)(0.5))).Put("htilt", ((V)(4D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(260D)), NewObj(3).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2544, int _argc2537, V t_2543, V _a2540, V _a2541, V _a2542, V[] _rest2538) => {
return Call(lipLick_2066, V.Undef, t_2543);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2552, int _argc2545, V t_2551, V _a2548, V _a2549, V _a2550, V[] _rest2546) => {
Call(yay_2072, V.Undef, t_2551);
Invoke(Invoke(Invoke(t_2551, "to", ((V)(150D)), NewObj(1).Put("crf", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("arils")), ((V)("head")), ((V)(4D))), "to", ((V)(400D)), NewObj(1).Put("crf", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("mangie", NewObj(9).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(135D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Dramatic first bite with her eyes closed - mmm! - her leaf flicks and she blushes when she likes it."))).Put("pre", Fn((V _arrowThis2560, int _argc2553, V t_2559, V _a2556, V _a2557, V _a2558, V[] _rest2554) => {
return Invoke(Invoke(t_2559, "to", ((V)(260D)), NewObj(2).Put("close", ((V)(0.6))).Put("pitch", ((V)(0.06))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2568, int _argc2561, V t_2567, V _a2564, V _a2565, V _a2566, V[] _rest2562) => {
return Invoke(Invoke(Invoke(t_2567, "to", ((V)(300D)), NewObj(3).Put("close", ((V)(0.7))).Put("smile", ((V)(1D))).Put("blush", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0D))).Put("blush", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2576, int _argc2569, V t_2575, V _a2572, V _a2573, V _a2574, V[] _rest2570) => {
Call(yay_2072, V.Undef, t_2575);
Invoke(Invoke(Invoke(t_2575, "to", ((V)(200D)), NewObj(3).Put("lf", ((V)(1D))).Put("stw", ((V)(0.5))).Put("tilt", ((V)((-4D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mjuice")), ((V)("head")), ((V)(2D))), "to", ((V)(400D)), NewObj(3).Put("lf", ((V)(0D))).Put("stw", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("razzy", NewObj(9).Put("chewMs", ((V)(110D))).Put("chewN", ((V)(1.1))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Bubbly quick bites with her beads jiggling, then a sparkly jiggle when she likes it."))).Put("pre", Fn((V _arrowThis2584, int _argc2577, V t_2583, V _a2580, V _a2581, V _a2582, V[] _rest2578) => {
return Call(sniffF_2065, V.Undef, t_2583, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _arrowThis2592, int _argc2585, V t_2591, V _a2588, V _a2589, V _a2590, V[] _rest2586) => {
return Call(lipLick_2066, V.Undef, t_2591);
}, 1, "post", true)).Put("yum", Fn((V _arrowThis2600, int _argc2593, V t_2599, V _a2596, V _a2597, V _a2598, V[] _rest2594) => {
Call(yay_2072, V.Undef, t_2599);
Invoke(Invoke(Invoke(t_2599, "to", ((V)(150D)), NewObj(1).Put("jig", ((V)(1.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(600D)), NewObj(1).Put("jig", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).V;
Invoke(Get(Get(R_2055, "FRUITLIB"), "KEYS"), "forEach", Fn((V _arrowThis2608, int _argc2601, V k_2607, V _a2604, V _a2605, V _a2606, V[] _rest2602) => {
V c_2609 = default;
c_2609 = GetK(C_2073, k_2607);
if (!(Truthy(Get(c_2609, "love")))) {
Set(c_2609, "love", Fn((V _arrowThis2617, int _argc2610, V t_2616, V _a2613, V _a2614, V _a2615, V[] _rest2611) => {
Call(hearts_2067, V.Undef, t_2616, ((V)(2D)));
Invoke(c_2609, "yum", t_2616);
return default;
}, 1, "", true));
}
return default;
}, 1, "", true));
Call(buildAll_2069, V.Undef, C_2073);
return default;
}, 0, "boot", false)), V.Undef);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
