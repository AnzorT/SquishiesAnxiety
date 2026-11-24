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
drop_12 = Fn((V _self1, int _argc15, V c_21, V x_22, V _a19, V _a20, V[] _rest16) => {
return Object_assign(NewObj(8).Put("n", ((V)(5D))).Put("sp", ((V)(22D))).Put("vy", ((V)((-20D)))).Put("g", ((V)(90D))).Put("life", ((V)(800D))).Put("r", Arr(((V)(0.8)), ((V)(1.3)))).Put("col", c_21).Put("kind", ((V)("drop"))).V, (x_22 is var _t23 && Truthy(_t23) ? _t23 : NewObj(0).V));
}, 2, "", true);
preset_13 = Fn((V _self1, int _argc24, V R_30, V _a27, V _a28, V _a29, V[] _rest25) => {
V P_31 = default;
P_31 = Get(R_30, "PRE");
if (Truthy(((!(Truthy(P_31)) ? V.True : V.False) is var _t32 && Truthy(_t32) ? _t32 : Get(P_31, "zest")))) {
return default;
}
Object_assign(P_31, NewObj(15).Put("pinjuice", Call(drop_12, V.Undef, Arr(((V)("#ffd84a")), ((V)("#fff3a0")), ((V)("#f2b81c"))))).Put("guac", Call(drop_12, V.Undef, Arr(((V)("#a8d86a")), ((V)("#d6f0a0")), ((V)("#6aa83a"))), NewObj(2).Put("kind", ((V)("dot"))).Put("r", Arr(((V)(0.7)), ((V)(1.2)))).V)).Put("banjuice", Call(drop_12, V.Undef, Arr(((V)("#fff3a0")), ((V)("#ffe14a")), ((V)("#f2c41c"))))).Put("chjuice", Call(drop_12, V.Undef, Arr(((V)("#e3263a")), ((V)("#ff6a7a")), ((V)("#9c0f26"))))).Put("pljuice", Call(drop_12, V.Undef, Arr(((V)("#8e2a6e")), ((V)("#d070b0")), ((V)("#5a1050"))))).Put("zest", NewObj(8).Put("n", ((V)(6D))).Put("sp", ((V)(28D))).Put("vy", ((V)((-18D)))).Put("g", ((V)(50D))).Put("life", ((V)(700D))).Put("r", Arr(((V)(0.45)), ((V)(0.8)))).Put("col", Arr(((V)("#ff9a26")), ((V)("#ffd9a0")), ((V)("#ffb84a")), ((V)("#ffffff")))).Put("kind", ((V)("dot"))).V).Put("apjuice", Call(drop_12, V.Undef, Arr(((V)("#b8f070")), ((V)("#e8ffb0")), ((V)("#8ed84a"))))).Put("bljuice", Call(drop_12, V.Undef, Arr(((V)("#5866d6")), ((V)("#9aa6ff")), ((V)("#2a3482"))))).Put("cocomilk", Call(drop_12, V.Undef, Arr(((V)("#ffffff")), ((V)("#f4efe6")), ((V)("#fffaf0"))))).Put("fibre", NewObj(8).Put("n", ((V)(4D))).Put("sp", ((V)(18D))).Put("vy", ((V)((-14D)))).Put("g", ((V)(70D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.5)), ((V)(0.8)))).Put("col", Arr(((V)("#5a3820")), ((V)("#8a5a30")), ((V)("#3e2614")))).Put("kind", ((V)("seed"))).V).Put("pearjuice", Call(drop_12, V.Undef, Arr(((V)("#e8f59a")), ((V)("#c6de4a")), ((V)("#fffbd0"))))).Put("arils", NewObj(8).Put("n", ((V)(6D))).Put("sp", ((V)(24D))).Put("vy", ((V)((-24D)))).Put("g", ((V)(90D))).Put("life", ((V)(900D))).Put("r", Arr(((V)(0.8)), ((V)(1.1)))).Put("col", Arr(((V)("#d42a3a")), ((V)("#ff6a7a")), ((V)("#a8102a")))).Put("kind", ((V)("seed"))).V).Put("mjuice", Call(drop_12, V.Undef, Arr(((V)("#ffa83a")), ((V)("#ffd27a")), ((V)("#e45a2a"))))).Put("rzjuice", Call(drop_12, V.Undef, Arr(((V)("#ec3a6c")), ((V)("#ff8fb0")), ((V)("#a81846"))))).Put("knock", NewObj(8).Put("n", ((V)(1D))).Put("sp", ((V)(6D))).Put("vy", ((V)((-12D)))).Put("g", ((V)((-2D)))).Put("life", ((V)(1100D))).Put("r", Arr(((V)(1D)), ((V)(1D)))).Put("col", Arr(((V)("#8a5a30")), ((V)("#5a3820")))).Put("kind", ((V)("note"))).V).V);
return default;
}, 1, "", true);
JUICE_14 = NewObj(20).Put("pina", ((V)("pinjuice"))).Put("avo", ((V)("guac"))).Put("berri", ((V)("juice"))).Put("lemmy", ((V)("lemjuice"))).Put("kiwi", ((V)("kiwijuice"))).Put("melo", ((V)("melojuice"))).Put("peachy", ((V)("peachjuice"))).Put("pitaya", ((V)("pitjuice"))).Put("tutti", ((V)("fruitjuice"))).Put("nana", ((V)("banjuice"))).Put("bing", ((V)("chjuice"))).Put("plummy", ((V)("pljuice"))).Put("clemmy", ((V)("zest"))).Put("appy", ((V)("apjuice"))).Put("blueby", ((V)("bljuice"))).Put("coco", ((V)("cocomilk"))).Put("perry", ((V)("pearjuice"))).Put("grana", ((V)("arils"))).Put("mangie", ((V)("mjuice"))).Put("razzy", ((V)("rzjuice"))).V;
Call(Named(boot_63 => Fn((V _self33, int _argc34, V _a36, V _a37, V _a38, V _a39, V[] _rest35) => {
V R_40 = default;
V TL_41 = default;
V hand_42 = default;
V both_43 = default;
V o_44 = default;
V NOHANDS_45 = default;
V jump_46 = default;
V shake_47 = default;
V swing_48 = default;
V steps_49 = default;
V jelly_50 = default;
V land_51 = default;
V install_52 = default;
V natF_53 = default;
V loopN_54 = default;
V hopC_55 = default;
V J_56 = default;
V sparkle_57 = default;
V relK_58 = default;
V spinR_59 = default;
V CARDS_60 = default;
V MOVES_61 = default;
V DANCES_62 = default;
if (_self33.IsNullish) _self33 = GlobalV;
R_40 = Get(G("window"), "RiveRig");
if (((((!(Truthy(R_40)) || !(Truthy(Get(R_40, "PETLIB")))) || !(Truthy(Get(Get(R_40, "PETLIB"), "install")))) || !(Truthy(Get(R_40, "SOFT")))) || !(Truthy(Get(R_40, "SNACKLIB"))))) {
Call(G("setTimeout"), V.Undef, boot_63.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_40, "fruitV"))) {
return default;
}
Set(R_40, "fruitV", ((V)(1D)));
Invoke(Object_keys(CH_8), "forEach", Fn((V _self33, int _argc64, V k_70, V _a67, V _a68, V _a69, V[] _rest65) => {
if (GetK(Get(R_40, "REST"), k_70).IsNullish) {
SetK(Get(R_40, "REST"), k_70, ((V)(0D)));
}
return default;
}, 1, "", true));
Call(preset_13, V.Undef, R_40);
Set(R_40, "FRUITLIB", NewObj(4).Put("KEYS", KEYS_11).Put("OLD", OLD_9).Put("NEW", NEW_10).Put("JUICE", JUICE_14).V);
{ V _t71 = Get(R_40, "PETLIB");
if (_t71.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t71));
{ V _t72 = Get(_t71, "TL");
TL_41 = _t72; }
{ V _t73 = Get(_t71, "hand");
hand_42 = _t73; }
{ V _t74 = Get(_t71, "both");
both_43 = _t74; }
{ V _t75 = Get(_t71, "o");
o_44 = _t75; }
{ V _t76 = Get(_t71, "NOHANDS");
NOHANDS_45 = _t76; }
{ V _t77 = Get(_t71, "jump");
jump_46 = _t77; }
{ V _t78 = Get(_t71, "shake");
shake_47 = _t78; }
{ V _t79 = Get(_t71, "swing");
swing_48 = _t79; }
{ V _t80 = Get(_t71, "steps");
steps_49 = _t80; }
{ V _t81 = Get(_t71, "jelly");
jelly_50 = _t81; }
{ V _t82 = Get(_t71, "land");
land_51 = _t82; }
{ V _t83 = Get(_t71, "install");
install_52 = _t83; } }
natF_53 = Get(Get(R_40, "SNACKLIB"), "natF");
Invoke(KEYS_11, "forEach", Fn((V _self33, int _argc84, V k_90, V _a87, V _a88, V _a89, V[] _rest85) => {
return Invoke(Get(R_40, "SOFT"), "add", k_90);
}, 1, "", true));
if (Truthy(Get(Get(R_40, "SNACKLIB"), "KEYS"))) {
Invoke(KEYS_11, "forEach", Fn((V _self33, int _argc91, V k_97, V _a94, V _a95, V _a96, V[] _rest92) => {
if (!(Truthy(Invoke(Get(Get(R_40, "SNACKLIB"), "KEYS"), "includes", k_97)))) {
Invoke(Get(Get(R_40, "SNACKLIB"), "KEYS"), "push", k_97);
}
return default;
}, 1, "", true));
}
loopN_54 = Fn((V _self33, int _argc98, V t_104, V n_105, V _a102, V _a103, V[] _rest99) => {
return Object_assign(Invoke(t_104, "loop"), NewObj(1).Put("dur", ((V)((ToNum(Get(t_104, "t")) * ToNum((n_105 is var _t106 && Truthy(_t106) ? _t106 : ((V)(3D)))))))).V);
}, 2, "", true);
hopC_55 = Fn((V _self33, int _argc107, V t_113, V h_114, V x_115, V _a112, V[] _rest108) => {
return Call(jump_46, V.Undef, t_113, Call(o_44, V.Undef, NewObj(5).Put("h", (h_114 is var _t116 && Truthy(_t116) ? _t116 : ((V)(7D)))).Put("ant", ((V)(150D))).Put("up", ((V)(210D))).Put("c", ((V)(0.16))).Put("arm", ((V)(46D))).V, (x_115 is var _t117 && Truthy(_t117) ? _t117 : NewObj(0).V)));
}, 3, "", true);
J_56 = Fn((V _self33, int _argc118, V t_124, V k_125, V w_126, V n_127, V[] _rest119) => {
return Invoke(t_124, "e", ((V)("emit")), GetK(JUICE_14, k_125), (w_126 is var _t128 && Truthy(_t128) ? _t128 : ((V)("head"))), (n_127 is var _t129 && Truthy(_t129) ? _t129 : ((V)(3D))));
}, 4, "", true);
sparkle_57 = Fn((V _self33, int _argc130, V t_136, V n_137, V _a134, V _a135, V[] _rest131) => {
return Invoke(t_136, "e", ((V)("emit")), ((V)("spark")), ((V)("head")), (n_137 is var _t138 && Truthy(_t138) ? _t138 : ((V)(2D))));
}, 2, "", true);
relK_58 = Fn((V _self33, int _argc139, V ch_145, V a_146, V em_147, V x_148, V[] _rest140) => {
return NewObj(1).Put("__rel", Arr(ch_145, a_146, em_147, x_148)).V;
}, 4, "", true);
spinR_59 = Fn((V _self33, int _argc149, V t_155, V dur_156, V deg_157, V x_158, V[] _rest150) => {
V a_159 = default;
a_159 = Get(t_155, "t");
Invoke(Invoke(t_155, "to", dur_156, Call(o_44, V.Undef, NewObj(1).Put("spin", deg_157).V, (x_158 is var _t160 && Truthy(_t160) ? _t160 : NewObj(0).V)), ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
return a_159;
return default;
}, 4, "", true);
CARDS_60 = NewObj(20).Put("pina", NewObj(3).Put("T", ((V)(0.95))).Put("b", ((V)(1.1))).Put("s", ((V)(1.25))).V).Put("avo", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1.1))).Put("s", ((V)(1D))).V).Put("berri", NewObj(3).Put("T", ((V)(0.9))).Put("b", ((V)(1.2))).Put("s", ((V)(1.05))).V).Put("lemmy", NewObj(3).Put("T", ((V)(0.85))).Put("b", ((V)(0.95))).Put("s", ((V)(1D))).V).Put("kiwi", NewObj(3).Put("T", ((V)(0.85))).Put("b", ((V)(1.05))).Put("s", ((V)(0.95))).V).Put("melo", NewObj(3).Put("T", ((V)(1.1))).Put("b", ((V)(1.15))).Put("s", ((V)(1.15))).V).Put("peachy", NewObj(3).Put("T", ((V)(1.1))).Put("b", ((V)(1.15))).Put("s", ((V)(1.1))).V).Put("pitaya", NewObj(3).Put("T", ((V)(0.9))).Put("b", ((V)(1.05))).Put("s", ((V)(1.1))).V).Put("tutti", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1D))).Put("s", ((V)(1.15))).V).Put("nana", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1D))).Put("s", ((V)(1.3))).V).Put("bing", NewObj(3).Put("T", ((V)(0.9))).Put("b", ((V)(1.25))).Put("s", ((V)(1D))).V).Put("plummy", NewObj(3).Put("T", ((V)(1.1))).Put("b", ((V)(0.95))).Put("s", ((V)(1.15))).V).Put("clemmy", NewObj(3).Put("T", ((V)(0.85))).Put("b", ((V)(1.1))).Put("s", ((V)(1D))).V).Put("appy", NewObj(3).Put("T", ((V)(1D))).Put("b", ((V)(1.05))).Put("s", ((V)(1D))).V).Put("blueby", NewObj(3).Put("T", ((V)(0.95))).Put("b", ((V)(1.2))).Put("s", ((V)(1.05))).V).Put("coco", NewObj(3).Put("T", ((V)(1.1))).Put("b", ((V)(0.85))).Put("s", ((V)(1.1))).V).Put("perry", NewObj(3).Put("T", ((V)(1.1))).Put("b", ((V)(1D))).Put("s", ((V)(1.25))).V).Put("grana", NewObj(3).Put("T", ((V)(1.15))).Put("b", ((V)(0.95))).Put("s", ((V)(0.95))).V).Put("mangie", NewObj(3).Put("T", ((V)(1.05))).Put("b", ((V)(1.1))).Put("s", ((V)(1.2))).V).Put("razzy", NewObj(3).Put("T", ((V)(0.9))).Put("b", ((V)(1.2))).Put("s", ((V)(1.05))).V).V;
MOVES_61 = NewObj(20).Put("pina", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc161, V _a163, V _a164, V _a165, V _a166, V[] _rest162) => {
V t_167 = default;
t_167 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(swing_48, V.Undef, t_167, ((V)(1400D)), ((V)(3D)), NewObj(4).Put("tilt", ((V)(6D))).Put("x", ((V)(2D))).Put("armL", ((V)(30D))).Put("armR", ((V)((-20D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_167, "to", ((V)(160D)), NewObj(2).Put("crw", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("pinjuice")), ((V)("head")), ((V)(2D))), "to", ((V)(360D)), NewObj(2).Put("crw", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(hopC_55, V.Undef, t_167, ((V)(7D)), NewObj(2).Put("air", NewObj(1).Put("crs", ((V)(0.5))).V).Put("fall", NewObj(1).Put("crs", ((V)(0D))).V).V);
return Call(loopN_54, V.Undef, Invoke(t_167, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A happy hula sway, his crown pops open, then a hop that whirls his crown.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc168, V _a170, V _a171, V _a172, V _a173, V[] _rest169) => {
V t_174 = default;
t_174 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_174, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("crw", ((V)(1.3))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(3).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).Put("x", ((V)((-2D)))).V, ((V)("i"))), "to", ((V)(500D)), NewObj(2).Put("crw", ((V)(0.6))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(320D)), NewObj(2).Put("lx", ((V)(0.8))).Put("ly", ((V)((-0.8)))).V, ((V)("io"))), "wait", ((V)(200D)));
Invoke(Invoke(Invoke(t_174, "to", ((V)(320D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("crs", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("crw", ((V)(0D))).Put("crs", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_44, V.Undef, NOHANDS_45, NewObj(10).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("x", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
return Invoke(Invoke(t_174, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His crown leaves shoot up like hair standing on end - he looks up and pats them back down.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc175, V _a177, V _a178, V _a179, V _a180, V[] _rest176) => {
V t_181 = default;
t_181 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_181, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.26))).Put("crw", ((V)(0.9))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("pinjuice")), ((V)("head")), ((V)(3D))), "wait", ((V)(220D)));
Invoke(t_181, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("crw", ((V)((-0.3)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_181, ((V)(0.6)), ((V)(3D)), ((V)(280D)), ((V)("crw")));
Call(jelly_50, V.Undef, t_181, ((V)(0.07)), ((V)(2D)), ((V)(240D)));
Invoke(t_181, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_181);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, his crown flares out with a squirt of juice, then he springs back and it wobbles.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc182, V _a184, V _a185, V _a186, V _a187, V[] _rest183) => {
V t_188 = default;
t_188 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_188, "to", ((V)(320D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.8)))).V, ((V)("io"))), "osc", ((V)(1200D)), ((V)(3D)), NewObj(2).Put("crs", ((V)(0.4))).Put("crw", ((V)(0.4))).V, NewObj(2).Put("crs", ((V)((-0.2)))).Put("crw", ((V)(0.1))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("crs", ((V)(0D))).Put("crw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(swing_48, V.Undef, t_188, ((V)(1200D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_188, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Crown fluff")), ((V)("Reaches up and fluffs his crown leaves like a hairdo, then a little hula sway.")))).Put("press", NewObj(1).Put("crw", ((V)(0.6))).V).Put("rel", Call(relK_58, V.Undef, ((V)("crw")), ((V)(0.6)), Arr(((V)("pinjuice")), ((V)("head")), ((V)(3D))))).V).Put("avo", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc189, V _a191, V _a192, V _a193, V _a194, V[] _rest190) => {
V t_195 = default;
t_195 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_195, "to", ((V)(240D)), NewObj(2).Put("prw", ((V)(1D))).Put("lfl", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("prw", ((V)((-0.6)))).Put("lfl", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("prw", ((V)(0D))).V, ((V)("io")));
Call(hopC_55, V.Undef, t_195, ((V)(7D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(2).Put("pp", ((V)(0.4))).Put("lfl", ((V)(0.8))).V).Put("fall", NewObj(2).Put("pp", ((V)(0D))).Put("lfl", ((V)(0D))).V).V);
Call(land_51, V.Undef, t_195, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
Call(hopC_55, V.Undef, t_195, ((V)(8D)), NewObj(2).Put("air", NewObj(1).Put("lsp", ((V)(0.5))).V).Put("fall", NewObj(1).Put("lsp", ((V)(1D))).V).V);
Invoke(t_195, "to", ((V)(1D)), NewObj(1).Put("lsp", ((V)(0D))).V, ((V)("l")));
return Call(loopN_54, V.Undef, Invoke(t_195, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("His pit wiggles in his belly, two hops - the pit bobs out and his leaves spin.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc196, V _a198, V _a199, V _a200, V _a201, V[] _rest197) => {
V t_202 = default;
t_202 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(t_202, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("pp", ((V)(1D))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "to", ((V)(250D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_202, "to", ((V)(300D)), NewObj(2).Put("ly", ((V)(0.9))).Put("pitch", ((V)((-0.12)))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(340D)), Call(o_44, V.Undef, Call(both_43, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(2).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V), ((V)("io"))), "to", ((V)(260D)), NewObj(1).Put("pp", ((V)(0D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("guac")), ((V)("body")), ((V)(2D))), "to", ((V)(320D)), Call(o_44, V.Undef, NOHANDS_45, NewObj(9).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("prw", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("prw", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_202, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His pit pops out of his belly - he stares at it and pushes it back in with both paws.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc203, V _a205, V _a206, V _a207, V _a208, V[] _rest204) => {
V t_209 = default;
t_209 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(t_209, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.26))).Put("pp", ((V)(0.7))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(220D)));
Invoke(Invoke(t_209, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("pp", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("guac")), ((V)("body")), ((V)(3D)));
Call(jelly_50, V.Undef, t_209, ((V)(0.8)), ((V)(3D)), ((V)(300D)), ((V)("prw")));
Invoke(t_209, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_209);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, his pit squeezes out a little - he springs back and it wobbles in its socket.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc210, V _a212, V _a213, V _a214, V _a215, V[] _rest211) => {
V t_216 = default;
t_216 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(t_216, "to", ((V)(320D)), Call(o_44, V.Undef, Call(both_43, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(4).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("ly", ((V)(0.8))).Put("pitch", ((V)((-0.1)))).V), ((V)("io"))), "to", ((V)(1400D)), NewObj(1).Put("pr", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("pr", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(Invoke(t_216, "to", ((V)(300D)), Call(o_44, V.Undef, NOHANDS_45, NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("body")), ((V)(2D))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0.7))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_216, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Pit polish")), ((V)("Rubs his pit with both paws so it rolls round and shines, then a proud leaf flap.")))).Put("press", NewObj(1).Put("pp", ((V)(0.4))).V).Put("rel", Call(relK_58, V.Undef, ((V)("prw")), ((V)(1D)), Arr(((V)("guac")), ((V)("body")), ((V)(2D))), NewObj(1).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(410D)), ((V)(0D)), ((V)("io"))))).Put("pp", Arr(Arr(((V)(0D)), ((V)(0.4))), Arr(((V)(150D)), ((V)(0D)), ((V)("i"))))).Put("prw", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(200D)), ((V)(1D)), ((V)("o"))), Arr(((V)(450D)), ((V)((-0.5))), ((V)("io"))), Arr(((V)(700D)), ((V)(0D)), ((V)("io"))))).V).V)).V).Put("berri", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc217, V _a219, V _a220, V _a221, V _a222, V[] _rest218) => {
V t_223 = default;
t_223 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(hopC_55, V.Undef, t_223, ((V)(7D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(2).Put("lfl", ((V)(0.8))).Put("stw", ((V)(0.6))).V).Put("fall", NewObj(2).Put("lfl", ((V)(0D))).Put("stw", ((V)(0D))).V).V);
Call(land_51, V.Undef, t_223, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
Call(hopC_55, V.Undef, t_223, ((V)(8D)), NewObj(2).Put("air", NewObj(2).Put("lsp", ((V)(0.5))).Put("lfl", ((V)(0.6))).V).Put("fall", NewObj(2).Put("lsp", ((V)(1D))).Put("lfl", ((V)(0D))).V).V);
Invoke(Invoke(Invoke(Invoke(t_223, "to", ((V)(1D)), NewObj(1).Put("lsp", ((V)(0D))).V, ((V)("l"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("juice")), ((V)("head")), ((V)(2D))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, Invoke(t_223, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Juicy bounces - his leafy top flaps and twirls, a happy squirt of juice.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc224, V _a226, V _a227, V _a228, V _a229, V[] _rest225) => {
V t_230 = default;
t_230 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_230, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(7).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("lfl", ((V)(1.3))).Put("stw", ((V)(1D))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.03))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("juice")), ((V)("head")), ((V)(2D)));
Invoke(Invoke(Invoke(Invoke(t_230, "to", ((V)(500D)), NewObj(3).Put("lfl", ((V)(0D))).Put("stw", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("ly", ((V)((-0.8)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(6).Put("ly", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_230, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His leaves fly up and his stem boings, a drop of juice - he looks up at them settling.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc231, V _a233, V _a234, V _a235, V _a236, V[] _rest232) => {
V t_237 = default;
t_237 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_237, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.27))).Put("lfl", ((V)((-0.4)))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("juice")), ((V)("body")), ((V)(4D))), "wait", ((V)(220D)));
Invoke(t_237, "to", ((V)(130D)), NewObj(6).Put("sq", ((V)((-0.15)))).Put("lfl", ((V)(1D))).Put("stw", ((V)(0.8))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_237, ((V)(0.8)), ((V)(3D)), ((V)(280D)), ((V)("stw")));
Invoke(t_237, "to", ((V)(260D)), NewObj(6).Put("sq", ((V)(0D))).Put("lfl", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_237);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed so the juice runs, then he springs back - leaves up, stem boinging.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc238, V _a240, V _a241, V _a242, V _a243, V[] _rest239) => {
V t_244 = default;
t_244 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_244, "to", ((V)(320D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.8)))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("lfl", ((V)(0.7))).V, NewObj(1).Put("lfl", ((V)(0.1))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("lfl", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(3).Put("lsp", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("lsp", ((V)(0D))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(1).Put("stw", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_244, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Leaf fluff")), ((V)("Fluffs up his leafy top with both paws, gives it a twirl and a stem boing.")))).Put("press", NewObj(1).Put("lfl", ((V)(0.6))).V).Put("rel", Call(relK_58, V.Undef, ((V)("stw")), ((V)(0.9)), Arr(((V)("juice")), ((V)("head")), ((V)(3D))))).V).Put("lemmy", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc245, V _a247, V _a248, V _a249, V _a250, V[] _rest246) => {
V t_251 = default;
t_251 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(t_251, "osc", ((V)(900D)), ((V)(6D)), NewObj(2).Put("tilt", ((V)(4D))).Put("lfl", ((V)(0.5))).V, NewObj(2).Put("tilt", ((V)((-4D)))).Put("lfl", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(hopC_55, V.Undef, t_251, ((V)(8D)), NewObj(3).Put("air", NewObj(1).Put("stw", ((V)(0.8))).V).Put("fall", NewObj(1).Put("stw", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("lemjuice")), ((V)("head")), ((V)(2D))))).V);
return Call(loopN_54, V.Undef, Invoke(t_251, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A quick zesty shimmy with his leaf flapping, then a hop that sprays a little lemon juice.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc252, V _a254, V _a255, V _a256, V _a257, V[] _rest253) => {
V t_258 = default;
t_258 = Call(TL_41, V.Undef);
Invoke(Invoke(t_258, "wait", ((V)(150D))), "to", ((V)(90D)), NewObj(4).Put("close", ((V)(0.85))).Put("mw", ((V)(0.35))).Put("puff", ((V)((-0.3)))).Put("sq", ((V)(0.05))).V, ((V)("o")));
Call(shake_47, V.Undef, t_258, NewObj(5).Put("P", ((V)(70D))).Put("head", ((V)(0.2))).Put("roll", ((V)(3D))).Put("body", ((V)(0.6))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).V);
Invoke(Invoke(Invoke(Invoke(t_258, "to", ((V)(80D)), NewObj(9).Put("close", ((V)(0D))).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("puff", ((V)(0D))).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.08)))).Put("lfl", ((V)(1D))).Put("stw", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("lemjuice")), ((V)("head")), ((V)(3D))), "to", ((V)(320D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i"))), "to", ((V)(400D)), NewObj(7).Put("lfl", ((V)(0D))).Put("stw", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_258, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("A sour pucker shiver, then a wide-eyed zing that pops him up and sprays juice.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc259, V _a261, V _a262, V _a263, V _a264, V[] _rest260) => {
V t_265 = default;
t_265 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_265, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.18))).Put("close", ((V)(0.8))).Put("mw", ((V)(0.4))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("lemjuice")), ((V)("head")), ((V)(5D))), "wait", ((V)(250D)));
Invoke(t_265, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.1)))).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_265, ((V)(0.05)), ((V)(2D)), ((V)(220D)));
Invoke(t_265, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_265);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed like a real lemon - juice sprays, he puckers, then springs back.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc266, V _a268, V _a269, V _a270, V _a271, V[] _rest267) => {
V t_272 = default;
t_272 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(t_272, "to", ((V)(300D)), NewObj(2).Put("lx", ((V)(0.8))).Put("hyaw", ((V)(0.15))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(120D)), NewObj(3).Put("close", ((V)(0.85))).Put("mw", ((V)(0.35))).Put("puff", ((V)((-0.3)))).V, ((V)("o")));
Call(shake_47, V.Undef, t_272, NewObj(4).Put("P", ((V)(75D))).Put("head", ((V)(0.15))).Put("roll", ((V)(2D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.7)), ((V)(0.3)))).V);
Invoke(Invoke(Invoke(t_272, "to", ((V)(300D)), NewObj(7).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_272, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sour face")), ((V)("Catches a whiff of something sour, puckers up and shivers, then grins and flaps his leaf.")))).Put("press", NewObj(2).Put("mw", ((V)(0.5))).Put("close", ((V)(0.4))).V).Put("rel", Call(relK_58, V.Undef, ((V)("stw")), ((V)(0.9)), Arr(((V)("lemjuice")), ((V)("head")), ((V)(4D))))).V).Put("kiwi", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc273, V _a275, V _a276, V _a277, V _a278, V[] _rest274) => {
V t_279 = default;
t_279 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
{
V i_280 = default;
i_280 = ((V)(0D));
while (true) {
if (!(LtN(i_280, 4D))) break;
Invoke(Invoke(t_279, "to", ((V)(170D)), NewObj(3).Put("pitch", ((V)(0.12))).Put("x", ((V)(((NumTruthy((ToNum(i_280) % 2D)) ? 1D : (-1D)) * 1.5)))).PutK(((V)((NumTruthy((ToNum(i_280) % 2D)) ? "footR" : "footL"))), ((V)(2.2))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(3).Put("pitch", ((V)((-0.05)))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_280, 1D);
}
}
Invoke(Invoke(Invoke(Invoke(t_279, "to", ((V)(200D)), NewObj(2).Put("x", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(1).Put("fzz", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("kiwifuzz")), ((V)("head")), ((V)(3D))), "to", ((V)(400D)), NewObj(1).Put("fzz", ((V)(0D))).V, ((V)("io")));
Call(hopC_55, V.Undef, t_279, ((V)(6D)));
return Call(loopN_54, V.Undef, Invoke(t_279, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A bird-like strut with head bobs, a fluff-up of his fuzz, then a little hop.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc282, V _a284, V _a285, V _a286, V _a287, V[] _rest283) => {
V t_288 = default;
t_288 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_288, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.4))).Put("mw", ((V)(0.6))).Put("fzz", ((V)(1.3))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("kiwifuzz")), ((V)("head")), ((V)(4D))), "wait", ((V)(500D)));
Invoke(Invoke(Invoke(t_288, "to", ((V)(200D)), NewObj(2).Put("lx", ((V)((-0.9)))).Put("hyaw", ((V)((-0.2)))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(2).Put("lx", ((V)(0.9))).Put("hyaw", ((V)(0.2))).V, ((V)("o"))), "to", ((V)(240D)), NewObj(9).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("fzz", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_288, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His fuzz bristles all over and he freezes like a startled bird, then darts a look both ways.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc289, V _a291, V _a292, V _a293, V _a294, V[] _rest290) => {
V t_295 = default;
t_295 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(t_295, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.24))).Put("fzz", ((V)(0.6))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(220D)));
Invoke(Invoke(Invoke(t_295, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("fzz", ((V)(1.1))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("kiwifuzz")), ((V)("head")), ((V)(4D))), "e", ((V)("emit")), ((V)("kiwijuice")), ((V)("body")), ((V)(2D)));
Call(jelly_50, V.Undef, t_295, ((V)(0.07)), ((V)(3D)), ((V)(240D)));
Invoke(t_295, "to", ((V)(300D)), NewObj(6).Put("sq", ((V)(0D))).Put("fzz", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_295);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, then he springs back with his fuzz puffed up and bits of fuzz floating.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc296, V _a298, V _a299, V _a300, V _a301, V[] _rest297) => {
V t_302 = default;
t_302 = Call(TL_41, V.Undef);
{
V i_303 = default;
i_303 = ((V)(0D));
while (true) {
if (!(LtN(i_303, 3D))) break;
V d_305 = default;
d_305 = ((V)((NumTruthy((ToNum(i_303) % 2D)) ? 1D : (-1D))));
Invoke(Invoke(Invoke(t_302, "to", ((V)(220D)), NewObj(4).Put("hyaw", ((V)((ToNum(d_305) * 0.3)))).Put("pitch", ((V)((-0.22)))).Put("ly", ((V)(0.8))).Put("lx", ((V)((ToNum(d_305) * 0.6)))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).Put("fzz", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("fzz", ((V)(0.1))).V, ((V)("io")));
PostInc(ref i_303, 1D);
}
}
Invoke(Invoke(Invoke(t_302, "to", ((V)(300D)), NewObj(7).Put("hyaw", ((V)(0D))).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("lx", ((V)(0D))).Put("fzz", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("stw", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_302, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Preen")), ((V)("Preens his fuzz like a little bird - left, right, left - then a proud stem bob.")))).Put("press", NewObj(1).Put("fzz", ((V)(0.6))).V).Put("rel", Call(relK_58, V.Undef, ((V)("fzz")), ((V)(0.8)), Arr(((V)("kiwifuzz")), ((V)("head")), ((V)(3D))))).V).Put("melo", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc306, V _a308, V _a309, V _a310, V _a311, V[] _rest307) => {
V t_312 = default;
t_312 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(swing_48, V.Undef, t_312, ((V)(1500D)), ((V)(3D)), NewObj(5).Put("tilt", ((V)(7D))).Put("x", ((V)(2.5))).Put("armL", ((V)(40D))).Put("armR", ((V)((-10D)))).Put("sdj", ((V)(0.6))).V, ((V)("io")));
Call(hopC_55, V.Undef, t_312, ((V)(8D)), NewObj(3).Put("air", NewObj(1).Put("sdj", ((V)(1D))).V).Put("fall", NewObj(1).Put("sdj", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("melojuice")), ((V)("head")), ((V)(3D))))).V);
return Call(loopN_54, V.Undef, Invoke(t_312, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Surfs a little swell with his arms out, then a juicy hop that jiggles all his seeds.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc313, V _a315, V _a316, V _a317, V _a318, V[] _rest314) => {
V t_319 = default;
t_319 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_319, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sdj", ((V)(1.4))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("meloseed")), ((V)("head")), ((V)(2D))), "to", ((V)(320D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i")));
Invoke(Invoke(Invoke(Invoke(t_319, "to", ((V)(500D)), NewObj(2).Put("sdj", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("ly", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(6).Put("ly", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_319, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His seeds jump in his flesh (two pop out!) - he checks the rest are still there.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc320, V _a322, V _a323, V _a324, V _a325, V[] _rest321) => {
V t_326 = default;
t_326 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_326, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.24))).Put("sdj", ((V)(0.8))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("melojuice")), ((V)("body")), ((V)(5D))), "wait", ((V)(220D)));
Invoke(t_326, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("sdj", ((V)(1.2))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_326, ((V)(0.07)), ((V)(3D)), ((V)(260D)));
Invoke(t_326, "to", ((V)(300D)), NewObj(6).Put("sq", ((V)(0D))).Put("sdj", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_326);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed so the juice splashes, then he springs back and his seeds jiggle.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc327, V _a329, V _a330, V _a331, V _a332, V[] _rest328) => {
V t_333 = default;
t_333 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_333, "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0.7))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(80D)), NewObj(4).Put("puff", ((V)((-0.2)))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.4))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth")), ((V)(1D))), "to", ((V)(200D)), NewObj(4).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_333, "to", ((V)(400D)), NewObj(2).Put("lx", ((V)(0.9))).Put("hyaw", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(600D)), ((V)(2D)), NewObj(1).Put("sdj", ((V)(0.5))).V, NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_333, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Seed spit")), ((V)("Puffs his cheeks and spits a seed - watches how far it went, very proud.")))).Put("press", NewObj(1).Put("sdj", ((V)(0.6))).V).Put("rel", Call(relK_58, V.Undef, ((V)("sdj")), ((V)(1D)), Arr(((V)("melojuice")), ((V)("head")), ((V)(3D))))).V).Put("peachy", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc334, V _a336, V _a337, V _a338, V _a339, V[] _rest335) => {
V t_340 = default;
t_340 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.2))).V);
Invoke(t_340, "to", ((V)(400D)), NewObj(2).Put("blush", ((V)(1D))).Put("close", ((V)(0.5))).V, ((V)("io")));
Call(swing_48, V.Undef, t_340, ((V)(1600D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).Put("lfl", ((V)(0.5))).V, ((V)("io")));
Invoke(t_340, "to", ((V)(300D)), NewObj(1).Put("close", ((V)(0D))).V, ((V)("io")));
Call(hopC_55, V.Undef, t_340, ((V)(5D)), NewObj(2).Put("air", NewObj(1).Put("lfl", ((V)(0.8))).V).Put("fall", NewObj(1).Put("lfl", ((V)(0D))).V).V);
Invoke(t_340, "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, Invoke(t_340, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Blushes with her eyes half shut, a soft sway, then a gentle hop that lifts her leaf.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc341, V _a343, V _a344, V _a345, V _a346, V[] _rest342) => {
V t_347 = default;
t_347 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_347, "wait", ((V)(150D))), "to", ((V)(100D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.6))).Put("lfl", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(320D)), Call(o_44, V.Undef, Call(both_43, V.Undef, ((V)(10D)), ((V)((-12D)))), NewObj(3).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).Put("blush", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(400D)), Call(o_44, V.Undef, NOHANDS_45, NewObj(9).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lfl", ((V)(0D))).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("blush", ((V)(0.3))).V, ((V)("io")));
return Invoke(Invoke(t_347, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("A little gasp with her paws to her cheeks, blushing pink all over.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc348, V _a350, V _a351, V _a352, V _a353, V[] _rest349) => {
V t_354 = default;
t_354 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_354, "to", ((V)(200D)), NewObj(1).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "to", ((V)(625D)), NewObj(5).Put("sq", ((V)(0.27))).Put("blush", ((V)(0.8))).Put("close", ((V)(0.7))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("peachjuice")), ((V)("body")), ((V)(3D))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(t_354, "to", ((V)(900D)), NewObj(3).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).Put("smile", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("lfl", ((V)(0D))).Put("blush", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_354);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Sinks down soft and slow like a ripe peach (a little juice), blushing, and slowly rises.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc355, V _a357, V _a358, V _a359, V _a360, V[] _rest356) => {
V t_361 = default;
t_361 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_361, "to", ((V)(320D)), Call(o_44, V.Undef, Call(hand_42, V.Undef, ((V)((-1D))), ((V)(10D)), ((V)((-12D)))), NewObj(3).Put("armL", ((V)(30D))).Put("close", ((V)(0.5))).Put("blush", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("hLy", ((V)((-10D)))).V, NewObj(1).Put("hLy", ((V)((-13D)))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_44, V.Undef, NOHANDS_45, NewObj(2).Put("armL", ((V)(0D))).Put("close", ((V)(0D))).V), ((V)("io"))), "to", ((V)(800D)), NewObj(3).Put("lsp", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("lsp", ((V)(0D))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_361, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Fuzzy cheek")), ((V)("Rubs her fuzzy cheek, blushes, and her leaf gives a happy whirl.")))).Put("press", NewObj(2).Put("blush", ((V)(0.8))).Put("close", ((V)(0.4))).V).Put("rel", Call(relK_58, V.Undef, ((V)("lfl")), ((V)(0.8)), Arr(((V)("peachjuice")), ((V)("head")), ((V)(2D))))).V).Put("pitaya", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc362, V _a364, V _a365, V _a366, V _a367, V[] _rest363) => {
V t_368 = default;
t_368 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(t_368, "to", ((V)(240D)), NewObj(2).Put("wsp", ((V)(1D))).Put("wfl", ((V)(1.2))).V, ((V)("o")));
Call(hopC_55, V.Undef, t_368, ((V)(9D)), NewObj(2).Put("air", NewObj(2).Put("brf", ((V)(0.8))).Put("crw", ((V)(0.8))).V).Put("fall", NewObj(2).Put("brf", ((V)(0D))).Put("crw", ((V)(0D))).V).V);
Invoke(Invoke(Invoke(t_368, "to", ((V)(260D)), NewObj(1).Put("spk", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(3).Put("wsp", ((V)(0D))).Put("wfl", ((V)(0D))).Put("spk", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, Invoke(t_368, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Spreads his leafy wings and flaps up in a little hop, bracts flaring, sparkling.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc369, V _a371, V _a372, V _a373, V _a374, V[] _rest370) => {
V t_375 = default;
t_375 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_375, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(8).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.6))).Put("brf", ((V)(1.2))).Put("crw", ((V)(1.2))).Put("wsp", ((V)(1.3))).Put("sq", ((V)((-0.1)))).Put("x", ((V)((-2D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("pitseed")), ((V)("head")), ((V)(4D))), "wait", ((V)(400D)));
Invoke(Invoke(t_375, "to", ((V)(400D)), NewObj(5).Put("brf", ((V)(0D))).Put("crw", ((V)(0D))).Put("wsp", ((V)(0D))).Put("sq", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_375, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Every bract, his crown and both wings flare out at once like a startled dragon, then fold back.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc376, V _a378, V _a379, V _a380, V _a381, V[] _rest377) => {
V t_382 = default;
t_382 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(t_382, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.24))).Put("brf", ((V)(0.6))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(220D)));
Invoke(Invoke(t_382, "to", ((V)(120D)), NewObj(6).Put("sq", ((V)((-0.14)))).Put("brf", ((V)(1.1))).Put("crw", ((V)(0.8))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("pitseed")), ((V)("body")), ((V)(5D)));
Call(jelly_50, V.Undef, t_382, ((V)(0.07)), ((V)(3D)), ((V)(240D)));
Invoke(t_382, "to", ((V)(300D)), NewObj(7).Put("sq", ((V)(0D))).Put("brf", ((V)(0D))).Put("crw", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_382);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, then his bracts burst open and a shower of little seeds flies out.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc383, V _a385, V _a386, V _a387, V _a388, V[] _rest384) => {
V t_389 = default;
t_389 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(t_389, "to", ((V)(500D)), NewObj(5).Put("wsp", ((V)(1.2))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("pitch", ((V)(0.08))).Put("close", ((V)(0.4))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(1).Put("wfl", ((V)(1.4))).V, NewObj(1).Put("wfl", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(6).Put("wsp", ((V)(0D))).Put("wfl", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_389, "to", ((V)(300D)), NewObj(3).Put("spk", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(1).Put("spk", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_389, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Wing stretch")), ((V)("Stretches his leafy wings out wide, two big flaps, folds them and sparkles.")))).Put("press", NewObj(2).Put("brf", ((V)(0.6))).Put("wsp", ((V)(0.4))).V).Put("rel", Call(relK_58, V.Undef, ((V)("brf")), ((V)(0.9)), Arr(((V)("pitseed")), ((V)("head")), ((V)(3D))))).V).Put("tutti", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc390, V _a392, V _a393, V _a394, V _a395, V[] _rest391) => {
V t_396 = default;
t_396 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(Invoke(t_396, "to", ((V)(400D)), NewObj(3).Put("wfl", ((V)(1.4))).Put("lift", ((V)(4D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("head")), ((V)(3D))), "to", ((V)(1000D)), NewObj(1).Put("spin", ((V)(360D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(3).Put("lift", ((V)(0D))).Put("wfl", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
Invoke(Invoke(t_396, "to", ((V)(160D)), NewObj(1).Put("cb", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("cb", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, Invoke(t_396, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Flutters up off the ground in a sparkly fairy twirl, lands and her fruit crown bounces.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc397, V _a399, V _a400, V _a401, V _a402, V[] _rest398) => {
V t_403 = default;
t_403 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_403, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sq", ((V)((-0.08)))).V, ((V)("o"))), "to", ((V)(520D)), NewObj(1).Put("fR", ((V)(1D))).V, ((V)("l"))), "to", ((V)(1D)), NewObj(1).Put("fR", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_403, "to", ((V)(160D)), NewObj(2).Put("armR", ((V)(60D))).Put("wfl", ((V)(1.2))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(8).Put("armR", ((V)(0D))).Put("wfl", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("body")), ((V)(2D)));
return Invoke(Invoke(t_403, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Her pear jumps out of the basket in fright - she catches it with a flutter of her wings.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc404, V _a406, V _a407, V _a408, V _a409, V[] _rest405) => {
V t_410 = default;
t_410 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(t_410, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.24))).Put("cb", ((V)((-0.6)))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(220D)));
Invoke(Invoke(t_410, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("cb", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("head")), ((V)(3D)));
Call(jelly_50, V.Undef, t_410, ((V)(0.7)), ((V)(3D)), ((V)(260D)), ((V)("cb")));
Invoke(t_410, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_410);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed into her basket, then she springs back up in a puff of fairy dust, crown bouncing.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc411, V _a413, V _a414, V _a415, V _a416, V[] _rest412) => {
V t_417 = default;
t_417 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_417, "to", ((V)(300D)), NewObj(2).Put("ly", ((V)(0.9))).Put("pitch", ((V)((-0.12)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(700D)), NewObj(1).Put("fL", ((V)(1D))).V, ((V)("l"))), "to", ((V)(1D)), NewObj(1).Put("fL", ((V)(0D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(4).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(1).Put("wfl", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(1).Put("wfl", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_417, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Basket check")), ((V)("Peeks into her basket, tosses her cherry up and catches it, then a happy flutter.")))).Put("press", NewObj(2).Put("cb", ((V)((-0.4)))).Put("wfl", ((V)(0.6))).V).Put("rel", Call(relK_58, V.Undef, ((V)("cb")), ((V)(1D)), Arr(((V)("fairydust")), ((V)("head")), ((V)(3D))))).V).Put("nana", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc418, V _a420, V _a421, V _a422, V _a423, V[] _rest419) => {
V t_424 = default;
t_424 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
{
V i_425 = default;
i_425 = ((V)(0D));
while (true) {
if (!(LtN(i_425, 2D))) break;
Invoke(Invoke(t_424, "to", ((V)(380D)), NewObj(5).Put("cv", ((V)(0.8))).Put("tilt", ((V)((-4D)))).Put("x", ((V)((-1.5)))).Put("armL", ((V)(40D))).Put("armR", ((V)((-6D)))).V, ((V)("io"))), "to", ((V)(380D)), NewObj(5).Put("cv", ((V)((-0.6)))).Put("tilt", ((V)(4D))).Put("x", ((V)(1.5))).Put("armL", ((V)((-6D)))).Put("armR", ((V)(40D))).V, ((V)("io")));
PostInc(ref i_425, 1D);
}
}
Invoke(t_424, "to", ((V)(300D)), NewObj(5).Put("cv", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Call(hopC_55, V.Undef, t_424, ((V)(7D)), NewObj(2).Put("air", NewObj(1).Put("cv", ((V)((-0.5)))).V).Put("fall", NewObj(1).Put("cv", ((V)(0.3))).V).V);
Call(jelly_50, V.Undef, t_424, ((V)(0.4)), ((V)(2D)), ((V)(260D)), ((V)("cv")));
return Call(loopN_54, V.Undef, Invoke(t_424, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Flips her curve from side to side like a wiggly smile, then a hop that straightens her out.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc427, V _a429, V _a430, V _a431, V _a432, V[] _rest428) => {
V t_433 = default;
t_433 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_433, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(8).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("cv", ((V)((-1D)))).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.08)))).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i"))), "wait", ((V)(400D))), "to", ((V)(500D)), NewObj(3).Put("cv", ((V)(0.3))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(6).Put("cv", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_433, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("She goes stiff and straight as a stick in fright, then slowly curves back into her smile.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc434, V _a436, V _a437, V _a438, V _a439, V[] _rest435) => {
V t_440 = default;
t_440 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_440, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.22))).Put("cv", ((V)(0.9))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("banjuice")), ((V)("body")), ((V)(2D))), "wait", ((V)(220D)));
Invoke(t_440, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("cv", ((V)((-0.6)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_440, ((V)(0.5)), ((V)(3D)), ((V)(300D)), ((V)("cv")));
Invoke(t_440, "to", ((V)(220D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_440);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, she folds into a deep C, then springs back and her curve wobbles.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc441, V _a443, V _a444, V _a445, V _a446, V[] _rest442) => {
V t_447 = default;
t_447 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_447, "to", ((V)(600D)), NewObj(6).Put("cv", ((V)((-0.9)))).Put("lift", ((V)(2D))).Put("sq", ((V)((-0.05)))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(600D)), NewObj(7).Put("cv", ((V)(1D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(500D)), NewObj(5).Put("cv", ((V)(0D))).Put("sq", ((V)(0D))).Put("tilt", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_447, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Banana stretch")), ((V)("Stretches up tall and straight, then curls into a big lazy C and back.")))).Put("press", NewObj(1).Put("cv", ((V)(0.5))).V).Put("rel", Call(relK_58, V.Undef, ((V)("cv")), ((V)(0.8)), Arr(((V)("banjuice")), ((V)("head")), ((V)(2D))))).V).Put("bing", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc448, V _a450, V _a451, V _a452, V _a453, V[] _rest449) => {
V t_454 = default;
t_454 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Call(hopC_55, V.Undef, t_454, ((V)(8D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(2).Put("stw", ((V)(0.5))).Put("lf", ((V)(1D))).V).Put("fall", NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0.3))).V).V);
Call(land_51, V.Undef, t_454, ((V)(0.07)), ((V)(2D)), ((V)(220D)));
Call(hopC_55, V.Undef, t_454, ((V)(9D)), NewObj(2).Put("air", NewObj(2).Put("stw", ((V)((-0.5)))).Put("lf", ((V)(1D))).V).Put("fall", NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V).V);
Invoke(Invoke(Invoke(t_454, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("chjuice")), ((V)("head")), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, Invoke(t_454, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Two bouncy hops - her stem twirls one way, then the other, the leaf fluttering.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc455, V _a457, V _a458, V _a459, V _a460, V[] _rest456) => {
V t_461 = default;
t_461 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_461, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("lf", ((V)(1.2))).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(4D))).V, ((V)("o"))), "to", ((V)(340D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i"))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_461, "to", ((V)(300D)), NewObj(1).Put("ly", ((V)((-0.9)))).V, ((V)("io"))), "osc", ((V)(700D)), ((V)(2D)), NewObj(1).Put("stw", ((V)(0.4))).V, NewObj(1).Put("stw", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(8).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).Put("ly", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_461, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Bounces straight up in fright, then looks up as her stem sways to a stop.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc462, V _a464, V _a465, V _a466, V _a467, V[] _rest463) => {
V t_468 = default;
t_468 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_468, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(4).Put("sq", ((V)(0.27))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("chjuice")), ((V)("body")), ((V)(4D))), "wait", ((V)(220D)));
Invoke(t_468, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.16)))).Put("lf", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_468, ((V)(0.4)), ((V)(3D)), ((V)(260D)), ((V)("stw")));
Call(jelly_50, V.Undef, t_468, ((V)(0.07)), ((V)(2D)), ((V)(240D)));
Invoke(t_468, "to", ((V)(240D)), NewObj(6).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_468);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed so the cherry juice runs, then she bounces back and her stem wobbles.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc469, V _a471, V _a472, V _a473, V _a474, V[] _rest470) => {
V t_475 = default;
t_475 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_475, "to", ((V)(340D)), NewObj(3).Put("armR", ((V)(160D))).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.06))).V, ((V)("io"))), "to", ((V)(1400D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(600D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(hopC_55, V.Undef, t_475, ((V)(5D)));
return Invoke(Invoke(Invoke(t_475, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Stem twirl")), ((V)("Reaches up and twirls her stem all the way round, then a happy little hop.")))).Put("press", NewObj(1).Put("lf", ((V)(0.6))).V).Put("rel", Call(relK_58, V.Undef, ((V)("stw")), ((V)(0.5)), Arr(((V)("chjuice")), ((V)("head")), ((V)(3D))))).V).Put("plummy", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc476, V _a478, V _a479, V _a480, V _a481, V[] _rest477) => {
V t_482 = default;
t_482 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(t_482, "to", ((V)(320D)), NewObj(4).Put("lift", ((V)(2D))).Put("sq", ((V)((-0.05)))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)("io")));
Call(spinR_59, V.Undef, t_482, ((V)(1100D)), ((V)(360D)), NewObj(2).Put("lf", ((V)(1D))).Put("footR", ((V)(1.6))).V);
Invoke(Invoke(t_482, "to", ((V)(300D)), NewObj(6).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("footR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_482, "to", ((V)(320D)), NewObj(5).Put("pitch", ((V)((-0.12)))).Put("ly", ((V)(0.4))).Put("armL", ((V)(20D))).Put("armR", ((V)(90D))).Put("close", ((V)(0.5))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(260D))), "to", ((V)(320D)), NewObj(5).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, Invoke(t_482, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Rises on tiptoe with his arms over his head, a pirouette and a little bow.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc483, V _a485, V _a486, V _a487, V _a488, V[] _rest484) => {
V t_489 = default;
t_489 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_489, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(10).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("lf", ((V)(1.2))).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(4D))).Put("armL", ((V)(140D))).Put("armR", ((V)(140D))).Put("footL", ((V)(1.2))).Put("footR", ((V)(1.2))).V, ((V)("o"))), "to", ((V)(340D)), NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i"))), "to", ((V)(220D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_489, "to", ((V)(320D)), Call(o_44, V.Undef, Call(both_43, V.Undef, ((V)(7D)), ((V)(8D))), NewObj(4).Put("armL", ((V)(24D))).Put("armR", ((V)(24D))).Put("ly", ((V)(0.5))).Put("pitch", ((V)((-0.08)))).V), ((V)("io")));
Invoke(t_489, "osc", ((V)(700D)), ((V)(2D)), NewObj(3).Put("hLx", ((V)(9D))).Put("hRx", ((V)((-9D)))).Put("pol", ((V)(0.4))).V, NewObj(3).Put("hLx", ((V)(5D))).Put("hRx", ((V)((-5D)))).Put("pol", ((V)(0.15))).V, ((V)("io")));
Invoke(t_489, "to", ((V)(320D)), Call(o_44, V.Undef, NOHANDS_45, NewObj(11).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("lf", ((V)(0D))).Put("pol", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
return Invoke(Invoke(t_489, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Leaps up with his arms over his head like a startled ballerina, then smooths his tummy and smiles.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc490, V _a492, V _a493, V _a494, V _a495, V[] _rest491) => {
V t_496 = default;
t_496 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_496, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.26))).Put("pol", ((V)(0.5))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("pljuice")), ((V)("body")), ((V)(4D))), "wait", ((V)(220D)));
Invoke(t_496, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("lf", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_496, ((V)(0.4)), ((V)(3D)), ((V)(260D)), ((V)("stw")));
Call(jelly_50, V.Undef, t_496, ((V)(0.07)), ((V)(2D)), ((V)(240D)));
Invoke(Invoke(t_496, "to", ((V)(260D)), NewObj(6).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(1).Put("pol", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_496);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed so the plum juice runs and his dusty bloom rubs shiny, then he springs back and his stem wobbles.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc497, V _a499, V _a500, V _a501, V _a502, V[] _rest498) => {
V t_503 = default;
t_503 = Call(TL_41, V.Undef);
Invoke(t_503, "to", ((V)(320D)), Call(o_44, V.Undef, Call(hand_42, V.Undef, ((V)(1D)), ((V)(7D)), ((V)(8D))), NewObj(3).Put("armR", ((V)(26D))).Put("ly", ((V)(0.6))).Put("pitch", ((V)((-0.1)))).V), ((V)("io")));
{
V i_504 = default;
i_504 = ((V)(0D));
while (true) {
if (!(LtN(i_504, 3D))) break;
Invoke(Invoke(t_503, "to", ((V)(230D)), NewObj(3).Put("hRx", ((V)((-10D)))).Put("hRy", ((V)(10D))).Put("pol", ((V)((0.3 + (ToNum(i_504) * 0.25))))).V, ((V)("io"))), "to", ((V)(230D)), NewObj(2).Put("hRx", ((V)((-5D)))).Put("hRy", ((V)(6D))).V, ((V)("io")));
PostInc(ref i_504, 1D);
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_503, "to", ((V)(320D)), Call(o_44, V.Undef, NOHANDS_45, NewObj(6).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("pol", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(300D))), "to", ((V)(340D)), NewObj(4).Put("armL", ((V)(60D))).Put("armR", ((V)(150D))).Put("tilt", ((V)((-4D)))).Put("winkR", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(450D))), "to", ((V)(320D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("tilt", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1500D)), NewObj(1).Put("pol", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_503, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Polish")), ((V)("Rubs the dusty bloom off his tummy in little circles until he shines, strikes a pose, and the bloom slowly comes back.")))).Put("press", NewObj(2).Put("lf", ((V)(0.6))).Put("pol", ((V)(0.3))).V).Put("rel", Call(relK_58, V.Undef, ((V)("stw")), ((V)(0.5)), Arr(((V)("pljuice")), ((V)("head")), ((V)(3D))))).V).Put("clemmy", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc506, V _a508, V _a509, V _a510, V _a511, V[] _rest507) => {
V t_512 = default;
V a_513 = default;
t_512 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
a_513 = Call(spinR_59, V.Undef, t_512, ((V)(700D)), ((V)(360D)), NewObj(3).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).Put("lf", ((V)(1D))).V);
Invoke(Invoke(Invoke(t_512, "at", Add(a_513, ((V)(701D)))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(4D))), "to", ((V)(200D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(hopC_55, V.Undef, t_512, ((V)(8D)), NewObj(3).Put("air", NewObj(1).Put("stw", ((V)(0.4))).V).Put("fall", NewObj(1).Put("stw", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(3D))))).V);
return Call(loopN_54, V.Undef, Invoke(t_512, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A zippy spin that sprays zesty mist, then a quick hop.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc514, V _a516, V _a517, V _a518, V _a519, V[] _rest515) => {
V t_520 = default;
t_520 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_520, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(3D))).Put("lf", ((V)(1.2))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(6D))), "to", ((V)(300D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).V, ((V)("i")));
Invoke(Invoke(Invoke(Invoke(t_520, "to", ((V)(240D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)((-0.8)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lx", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(7).Put("lx", ((V)(0D))).Put("lf", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_520, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Jumps with a burst of zesty spray, her leaves flapping, and looks around.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc521, V _a523, V _a524, V _a525, V _a526, V[] _rest522) => {
V t_527 = default;
t_527 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_527, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.24))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("close", ((V)(0.4))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(6D))), "wait", ((V)(220D)));
Invoke(t_527, "to", ((V)(120D)), NewObj(6).Put("sq", ((V)((-0.15)))).Put("lf", ((V)(1D))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_527, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_527, "to", ((V)(240D)), NewObj(6).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_527);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squeezed so her peel spritzes zesty mist, then she pops back.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc528, V _a530, V _a531, V _a532, V _a533, V[] _rest529) => {
V t_534 = default;
t_534 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(t_534, "to", ((V)(1200D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_534, "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)(0.08))).Put("close", ((V)(0.6))).Put("puff", ((V)(0.3))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(5).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("puff", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_534, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Zesty sniff")), ((V)("Twirls her leaves round, then breathes in her own zesty smell with a happy sigh.")))).Put("press", NewObj(2).Put("lf", ((V)(0.6))).Put("close", ((V)(0.3))).V).Put("rel", Call(relK_58, V.Undef, ((V)("lf")), ((V)(1D)), Arr(((V)("zest")), ((V)("head")), ((V)(5D))))).V).Put("appy", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc535, V _a537, V _a538, V _a539, V _a540, V[] _rest536) => {
V t_541 = default;
t_541 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(t_541, "to", ((V)(140D)), NewObj(1).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(hopC_55, V.Undef, t_541, ((V)(8D)), NewObj(3).Put("chain", (true ? V.True : V.False)).Put("air", NewObj(1).Put("lf", ((V)(1D))).V).Put("fall", NewObj(1).Put("lf", ((V)(0D))).V).V);
Call(land_51, V.Undef, t_541, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
Call(swing_48, V.Undef, t_541, ((V)(900D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(4D))).Put("lf", ((V)(0.6))).V, ((V)("io")));
return Call(loopN_54, V.Undef, Invoke(t_541, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A crisp little bounce with a sparkle, a hop and a cheerful sway of her leaf.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc542, V _a544, V _a545, V _a546, V _a547, V[] _rest543) => {
V t_548 = default;
t_548 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(t_548, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("lf", ((V)(1D))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_548, "to", ((V)(260D)), NewObj(2).Put("lx", ((V)((-0.9)))).Put("hyaw", ((V)((-0.2)))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(260D)), NewObj(2).Put("lx", ((V)(0.9))).Put("hyaw", ((V)(0.2))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(4).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("ly", ((V)(0.8))).Put("pitch", ((V)((-0.12)))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(9).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("lf", ((V)(0D))).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_548, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Freezes, then checks herself all over for worms - none, phew.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc549, V _a551, V _a552, V _a553, V _a554, V[] _rest550) => {
V t_555 = default;
t_555 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_555, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(4).Put("sq", ((V)(0.2))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("apjuice")), ((V)("body")), ((V)(3D))), "wait", ((V)(200D)));
Invoke(t_555, "to", ((V)(110D)), NewObj(5).Put("sq", ((V)((-0.12)))).Put("lf", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_555, ((V)(0.05)), ((V)(2D)), ((V)(220D)));
Invoke(t_555, "to", ((V)(240D)), NewObj(6).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_555);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("A crisp apple squashes less - a little juice and a quick bounce back.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc556, V _a558, V _a559, V _a560, V _a561, V[] _rest557) => {
V t_562 = default;
t_562 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_562, "to", ((V)(320D)), Call(o_44, V.Undef, Call(both_43, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(4).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).Put("ly", ((V)(0.6))).Put("pitch", ((V)((-0.08)))).V), ((V)("io"))), "osc", ((V)(1200D)), ((V)(4D)), NewObj(2).Put("hLy", ((V)(6D))).Put("hRy", ((V)(10D))).V, NewObj(2).Put("hLy", ((V)(10D))).Put("hRy", ((V)(6D))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_44, V.Undef, NOHANDS_45, NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(200D)), NewObj(1).Put("lf", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_562, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Polish")), ((V)("Polishes herself with both paws until she shines and sparkles.")))).Put("press", NewObj(1).Put("lf", ((V)(0.5))).V).Put("rel", Call(relK_58, V.Undef, ((V)("lf")), ((V)(1D)), Arr(((V)("apjuice")), ((V)("head")), ((V)(2D))))).V).Put("blueby", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc563, V _a565, V _a566, V _a567, V _a568, V[] _rest564) => {
V t_569 = default;
t_569 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_569, "to", ((V)(400D)), NewObj(3).Put("rl", ((V)((-28D)))).Put("x", ((V)((-4D)))).Put("armR", ((V)(40D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(4).Put("rl", ((V)(28D))).Put("x", ((V)(4D))).Put("armR", ((V)(0D))).Put("armL", ((V)(40D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(3).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).V, ((V)("io")));
Call(hopC_55, V.Undef, t_569, ((V)(7D)), NewObj(2).Put("air", NewObj(1).Put("stw", ((V)(0.6))).V).Put("fall", NewObj(1).Put("stw", ((V)(0D))).V).V);
return Call(loopN_54, V.Undef, Invoke(t_569, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Rocks and rolls on her round tummy from side to side, then a hop that spins her crown.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc570, V _a572, V _a573, V _a574, V _a575, V[] _rest571) => {
V t_576 = default;
t_576 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_576, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "to", ((V)(700D)), NewObj(2).Put("rl", ((V)((-360D)))).Put("x", ((V)((-10D)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(1).Put("sq", ((V)(0.05))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("x", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink"))), "to", ((V)(300D)), NewObj(5).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_576, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Startled, she rolls right over and back onto her feet, blinking.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc577, V _a579, V _a580, V _a581, V _a582, V[] _rest578) => {
V t_583 = default;
t_583 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_583, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(4).Put("sq", ((V)(0.27))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("bljuice")), ((V)("body")), ((V)(3D))), "wait", ((V)(220D)));
Invoke(t_583, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.16)))).Put("crf", ((V)(0.8))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_583, ((V)(0.08)), ((V)(3D)), ((V)(240D)));
Invoke(t_583, "to", ((V)(260D)), NewObj(6).Put("sq", ((V)(0D))).Put("crf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_583);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed like a squishy berry, then she pops back and her crown flares.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc584, V _a586, V _a587, V _a588, V _a589, V[] _rest585) => {
V t_590 = default;
t_590 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_590, "to", ((V)(900D)), NewObj(3).Put("rl", ((V)(360D))).Put("x", ((V)(10D))).Put("lx", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "wait", ((V)(300D))), "to", ((V)(900D)), NewObj(3).Put("rl", ((V)((-360D)))).Put("x", ((V)(0D))).Put("lx", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(3).Put("lx", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("stw", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_590, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Roll about")), ((V)("Rolls away a little, rolls back again and spins her crown.")))).Put("press", NewObj(1).Put("crf", ((V)(0.5))).V).Put("rel", Call(relK_58, V.Undef, ((V)("crf")), ((V)(0.8)), Arr(((V)("bljuice")), ((V)("head")), ((V)(2D))))).V).Put("coco", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc591, V _a593, V _a594, V _a595, V _a596, V[] _rest592) => {
V t_597 = default;
t_597 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(t_597, "to", ((V)(300D)), Call(o_44, V.Undef, Call(both_43, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(2).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V), ((V)("io")));
{
V i_598 = default;
i_598 = ((V)(0D));
while (true) {
if (!(LtN(i_598, 4D))) break;
Invoke(Invoke(Invoke(t_597, "to", ((V)(120D)), NewObj(2).PutK(((V)((NumTruthy((ToNum(i_598) % 2D)) ? "hRy" : "hLy"))), ((V)(12D))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("body")), ((V)(1D))), "to", ((V)(160D)), NewObj(3).Put("hLy", ((V)(8D))).Put("hRy", ((V)(8D))).Put("sq", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_598, 1D);
}
}
Invoke(t_597, "to", ((V)(300D)), Call(o_44, V.Undef, NOHANDS_45, NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
Call(swing_48, V.Undef, t_597, ((V)(1200D)), ((V)(3D)), NewObj(3).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).Put("lf", ((V)(0.6))).V, ((V)("io")));
return Call(loopN_54, V.Undef, Invoke(t_597, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Drums a little bongo beat on his hollow belly, then sways like a palm tree.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc600, V _a602, V _a603, V _a604, V _a605, V[] _rest601) => {
V t_606 = default;
t_606 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_606, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("fz", ((V)(1.2))).Put("lf", ((V)(1D))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("fibre")), ((V)("head")), ((V)(4D))), "wait", ((V)(500D)));
Invoke(Invoke(t_606, "to", ((V)(400D)), NewObj(3).Put("fz", ((V)(0D))).Put("lf", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_606, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Every hair on him stands on end and a few fibres fly, then it all lies back down.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc607, V _a609, V _a610, V _a611, V _a612, V[] _rest608) => {
V t_613 = default;
t_613 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_613, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "to", ((V)(325D)), NewObj(4).Put("sq", ((V)(0.14))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("knock")), ((V)("head")), ((V)(1D))), "wait", ((V)(200D)));
Invoke(Invoke(t_613, "to", ((V)(110D)), NewObj(5).Put("sq", ((V)((-0.08)))).Put("fz", ((V)(0.8))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("cocomilk")), ((V)("head")), ((V)(2D)));
Call(jelly_50, V.Undef, t_613, ((V)(0.04)), ((V)(2D)), ((V)(200D)));
Invoke(t_613, "to", ((V)(300D)), NewObj(6).Put("sq", ((V)(0D))).Put("fz", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_613);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("A hard nut hardly squashes - knock! - his hair puffs and a drop of coconut milk splashes.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc614, V _a616, V _a617, V _a618, V _a619, V[] _rest615) => {
V t_620 = default;
t_620 = Call(TL_41, V.Undef);
Invoke(Invoke(t_620, "to", ((V)(500D)), NewObj(2).Put("rl", ((V)(24D))).Put("x", ((V)(3D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Invoke(t_620, "to", ((V)(320D)), NewObj(2).Put("armR", ((V)(150D))).Put("hyaw", ((V)(0.15))).V, ((V)("io")));
{
V i_621 = default;
i_621 = ((V)(0D));
while (true) {
if (!(LtN(i_621, 3D))) break;
Invoke(Invoke(Invoke(t_620, "to", ((V)(110D)), NewObj(2).Put("armR", ((V)(138D))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("head")), ((V)(1D))), "to", ((V)(180D)), NewObj(2).Put("armR", ((V)(150D))).Put("sq", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_621, 1D);
}
}
Invoke(Invoke(Invoke(t_620, "to", ((V)(400D)), NewObj(3).Put("lx", ((V)(0.9))).Put("hyaw", ((V)(0.25))).Put("close", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(6).Put("armR", ((V)(0D))).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_620, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Knock knock")), ((V)("Knocks on his own head three times and listens - hollow! He grins.")))).Put("press", NewObj(1).Put("fz", ((V)(0.6))).V).Put("rel", Call(relK_58, V.Undef, ((V)("fz")), ((V)(0.9)), Arr(((V)("fibre")), ((V)("head")), ((V)(3D))))).V).Put("perry", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc623, V _a625, V _a626, V _a627, V _a628, V[] _rest624) => {
V t_629 = default;
t_629 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(t_629, "to", ((V)(300D)), NewObj(3).Put("tilt", ((V)(9D))).Put("x", ((V)(1.2))).Put("armL", ((V)(40D))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_629, ((V)(9D)), ((V)(4D)), ((V)(420D)), ((V)("tilt")));
Invoke(t_629, "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Call(hopC_55, V.Undef, t_629, ((V)(6D)), NewObj(2).Put("air", NewObj(1).Put("lf", ((V)(1D))).V).Put("fall", NewObj(1).Put("lf", ((V)(0D))).V).V);
return Call(loopN_54, V.Undef, Invoke(t_629, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("Tips over on his round bottom and wobbles back like a roly-poly, then a happy hop.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc630, V _a632, V _a633, V _a634, V _a635, V[] _rest631) => {
V t_636 = default;
t_636 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_636, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)((-16D)))).Put("x", ((V)((-2D)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("tilt", ((V)(14D))).Put("x", ((V)(2D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)((-8D)))).Put("x", ((V)((-1D)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(2).Put("tilt", ((V)(4D))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(7).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_636, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Wobbles wildly, arms out, nearly topples over - and rights himself.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc637, V _a639, V _a640, V _a641, V _a642, V[] _rest638) => {
V t_643 = default;
t_643 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_643, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0.24))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("pearjuice")), ((V)("body")), ((V)(3D))), "wait", ((V)(220D)));
Invoke(t_643, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.14)))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("lf", ((V)(1D))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_643, ((V)(6D)), ((V)(3D)), ((V)(360D)), ((V)("tilt")));
Invoke(t_643, "to", ((V)(240D)), NewObj(6).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_643);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed (a little pear juice), then he springs back and wobbles on his bottom.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc644, V _a646, V _a647, V _a648, V _a649, V[] _rest645) => {
V t_650 = default;
t_650 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(t_650, "to", ((V)(700D)), NewObj(3).Put("tilt", ((V)(15D))).Put("x", ((V)(2D))).Put("close", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(200D)), NewObj(4).Put("tilt", ((V)((-6D)))).Put("x", ((V)((-1D)))).Put("close", ((V)(0D))).Put("wide", ((V)(0.5))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_650, ((V)(6D)), ((V)(3D)), ((V)(400D)), ((V)("tilt")));
Invoke(t_650, "to", ((V)(300D)), NewObj(4).Put("x", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_650, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Wobble")), ((V)("Leans further and further over... and springs back upright with a wobble.")))).Put("press", NewObj(1).Put("lf", ((V)(0.5))).V).Put("rel", Call(relK_58, V.Undef, ((V)("tilt")), ((V)(8D)), Arr(((V)("pearjuice")), ((V)("head")), ((V)(2D))))).V).Put("grana", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc651, V _a653, V _a654, V _a655, V _a656, V[] _rest652) => {
V t_657 = default;
t_657 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.2))).V);
Invoke(Invoke(Invoke(t_657, "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)((-0.16)))).Put("close", ((V)(0.6))).Put("armL", ((V)(40D))).Put("armR", ((V)((-10D)))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_657, "to", ((V)(200D)), NewObj(1).Put("crf", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("arils")), ((V)("head")), ((V)(4D))), "to", ((V)(400D)), NewObj(1).Put("crf", ((V)(0D))).V, ((V)("io"))), "to", ((V)(800D)), NewObj(1).Put("stw", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, Invoke(t_657, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A dignified royal nod, then his crown flares and a shower of ruby seeds sparkles out.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc658, V _a660, V _a661, V _a662, V _a663, V[] _rest659) => {
V t_664 = default;
t_664 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_664, "wait", ((V)(150D))), "to", ((V)(80D)), NewObj(5).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("crf", ((V)(1.1))).Put("sq", ((V)((-0.06)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("arils")), ((V)("head")), ((V)(5D))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(t_664, "to", ((V)(320D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.8)))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(2).Put("crf", ((V)(0D))).Put("stw", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(9).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).Put("sq", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_664, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("His crown flares and seeds burst out - he composes himself and straightens his crown.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc665, V _a667, V _a668, V _a669, V _a670, V[] _rest666) => {
V t_671 = default;
t_671 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(t_671, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0.23))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "wait", ((V)(220D)));
Invoke(Invoke(t_671, "to", ((V)(120D)), NewObj(5).Put("sq", ((V)((-0.13)))).Put("crf", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("arils")), ((V)("head")), ((V)(6D)));
Call(jelly_50, V.Undef, t_671, ((V)(0.06)), ((V)(2D)), ((V)(260D)));
Invoke(t_671, "to", ((V)(300D)), NewObj(6).Put("sq", ((V)(0D))).Put("crf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_671);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed, then he springs back and his crown sprays ruby seeds.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc672, V _a674, V _a675, V _a676, V _a677, V[] _rest673) => {
V t_678 = default;
t_678 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_678, "to", ((V)(340D)), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("ly", ((V)((-0.9)))).V, ((V)("io"))), "osc", ((V)(900D)), ((V)(2D)), NewObj(1).Put("stw", ((V)(0.3))).V, NewObj(1).Put("stw", ((V)((-0.2)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)(0.08))).Put("close", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_678, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Crown adjust")), ((V)("Straightens his crown just so with both paws, then lifts his chin like a king.")))).Put("press", NewObj(1).Put("crf", ((V)(0.5))).V).Put("rel", Call(relK_58, V.Undef, ((V)("crf")), ((V)(1D)), Arr(((V)("arils")), ((V)("head")), ((V)(4D))))).V).Put("mangie", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc679, V _a681, V _a682, V _a683, V _a684, V[] _rest680) => {
V t_685 = default;
t_685 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(Invoke(t_685, "to", ((V)(300D)), NewObj(5).Put("tilt", ((V)((-6D)))).Put("lean", ((V)((-3D)))).Put("armL", ((V)(150D))).Put("armR", ((V)(20D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(1).Put("stw", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(hopC_55, V.Undef, t_685, ((V)(7D)), NewObj(1).Put("ev", Arr(Arr(((V)("emit")), ((V)("mjuice")), ((V)("head")), ((V)(2D))))).V);
return Call(loopN_54, V.Undef, Invoke(t_685, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A dramatic leaf flip like tossing her hair, then a sunny hop.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc686, V _a688, V _a689, V _a690, V _a691, V[] _rest687) => {
V t_692 = default;
t_692 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(t_692, "wait", ((V)(150D))), "to", ((V)(100D)), NewObj(4).Put("wide", ((V)(1D))).Put("open", ((V)(0.6))).Put("mw", ((V)(0.6))).Put("lf", ((V)(1D))).V, ((V)("o"))), "to", ((V)(320D)), Call(o_44, V.Undef, Call(hand_42, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-12D)))), NewObj(3).Put("armR", ((V)(30D))).Put("lean", ((V)(3D))).Put("tilt", ((V)(3D))).V), ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(400D)), Call(o_44, V.Undef, NOHANDS_45, NewObj(9).Put("armR", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("lf", ((V)(0D))).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
return Invoke(Invoke(t_692, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("A big dramatic gasp with a paw to her cheek - then she smiles as if nothing happened.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc693, V _a695, V _a696, V _a697, V _a698, V[] _rest694) => {
V t_699 = default;
t_699 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_699, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(4).Put("sq", ((V)(0.27))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("mjuice")), ((V)("body")), ((V)(4D))), "wait", ((V)(220D)));
Invoke(t_699, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("lf", ((V)(1D))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_699, ((V)(0.08)), ((V)(3D)), ((V)(260D)));
Invoke(t_699, "to", ((V)(240D)), NewObj(6).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_699);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed so the mango juice runs, then she bounces back.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc700, V _a702, V _a703, V _a704, V _a705, V[] _rest701) => {
V t_706 = default;
t_706 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_706, "to", ((V)(600D)), NewObj(7).Put("lean", ((V)((-4D)))).Put("tilt", ((V)((-4D)))).Put("pitch", ((V)(0.1))).Put("close", ((V)(1D))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("blush", ((V)(0.8))).V, ((V)("io"))), "osc", ((V)(1600D)), ((V)(2D)), NewObj(1).Put("lf", ((V)(0.6))).V, NewObj(1).Put("lf", ((V)(0.1))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(9).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_706, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sunbathe")), ((V)("Leans back with her paws behind her head and sunbathes, ripening to a blush.")))).Put("press", NewObj(2).Put("lf", ((V)(0.6))).Put("blush", ((V)(0.5))).V).Put("rel", Call(relK_58, V.Undef, ((V)("lf")), ((V)(1D)), Arr(((V)("mjuice")), ((V)("head")), ((V)(3D))))).V).Put("razzy", NewObj(6).Put("happy", Arr(Call(Fn((V _self33, int _argc707, V _a709, V _a710, V _a711, V _a712, V[] _rest708) => {
V t_713 = default;
V a_714 = default;
t_713 = Call(TL_41, V.Undef, NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V);
Invoke(Invoke(Invoke(t_713, "to", ((V)(200D)), NewObj(1).Put("jig", ((V)(1D))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(4D)), NewObj(1).Put("tilt", ((V)(4D))).V, NewObj(1).Put("tilt", ((V)((-4D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
a_714 = Call(spinR_59, V.Undef, t_713, ((V)(800D)), ((V)(360D)), NewObj(3).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("stw", ((V)(0.6))).V);
Invoke(Invoke(Invoke(t_713, "at", Add(a_714, ((V)(801D)))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(260D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("stw", ((V)(0D))).Put("jig", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, Invoke(t_713, "rest", ((V)(300D))));
return default;
}, 0, "", true), V.Undef), ((V)("Happy")), ((V)("A jiggly shimmy (every bead wobbles), then a jazz-hands spin with sparkles.")))).Put("surprised", Arr(Call(Fn((V _self33, int _argc715, V _a717, V _a718, V _a719, V _a720, V[] _rest716) => {
V t_721 = default;
t_721 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_721, "wait", ((V)(150D))), "to", ((V)(70D)), NewObj(6).Put("wide", ((V)(1D))).Put("open", ((V)(0.5))).Put("mw", ((V)(0.7))).Put("jig", ((V)(1.5))).Put("sq", ((V)((-0.1)))).Put("lift", ((V)(4D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(320D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i")));
Invoke(Invoke(t_721, "to", ((V)(700D)), NewObj(2).Put("jig", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(5).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return Invoke(Invoke(t_721, "rest", ((V)(400D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Surprised")), ((V)("Jumps with every bead on her jiggling and a burst of sparkles.")))).Put("squish", Arr(Call(Fn((V _self33, int _argc722, V _a724, V _a725, V _a726, V _a727, V[] _rest723) => {
V t_728 = default;
t_728 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(t_728, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(375D)), NewObj(5).Put("sq", ((V)(0.27))).Put("jig", ((V)(0.6))).Put("hap", ((V)(0.9))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("rzjuice")), ((V)("body")), ((V)(4D))), "wait", ((V)(220D)));
Invoke(Invoke(t_728, "to", ((V)(130D)), NewObj(5).Put("sq", ((V)((-0.15)))).Put("jig", ((V)(1.4))).Put("hap", ((V)(0D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(800D)), NewObj(1).Put("jig", ((V)(0D))).V, ((V)("io")));
Invoke(t_728, "to", ((V)(240D)), NewObj(5).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return Call(loopN_54, V.Undef, t_728);
return default;
}, 0, "", true), V.Undef), ((V)("Squish")), ((V)("Squashed so the raspberry juice runs, then all her beads wobble back.")))).Put("quirk", Arr(Call(Fn((V _self33, int _argc729, V _a731, V _a732, V _a733, V _a734, V[] _rest730) => {
V t_735 = default;
t_735 = Call(TL_41, V.Undef);
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_735, "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).Put("close", ((V)(0.5))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(4D)), NewObj(3).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("jig", ((V)(0.6))).V, NewObj(3).Put("hLx", ((V)((-1D)))).Put("hRx", ((V)(1D))).Put("jig", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(300D)), Call(o_44, V.Undef, NOHANDS_45, NewObj(6).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("jig", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(600D)), NewObj(1).Put("stw", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(Invoke(t_735, "wait", ((V)(200D))), "rest", ((V)(450D))), "done");
return default;
}, 0, "", true), V.Undef), ((V)("Sparkle")), ((V)("Jazz hands with a jiggle, a burst of sparkles and a twirl of her leafy top.")))).Put("press", NewObj(1).Put("jig", ((V)(0.6))).V).Put("rel", Call(relK_58, V.Undef, ((V)("jig")), ((V)(1.2)), Arr(((V)("rzjuice")), ((V)("head")), ((V)(3D))), NewObj(1).Put("k", NewObj(3).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(410D)), ((V)(0D)), ((V)("io"))))).Put("jig", Arr(Arr(((V)(0D)), ((V)(0.6))), Arr(((V)(150D)), ((V)(1.4)), ((V)("o"))), Arr(((V)(900D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V).V)).V).V;
Invoke(KEYS_11, "forEach", Fn((V _self33, int _argc736, V k_742, V _a739, V _a740, V _a741, V[] _rest737) => {
V M_743 = default;
V r_744 = default;
V ch_745 = default;
V a_746 = default;
V em_747 = default;
V x_748 = default;
V from_749 = default;
V kk_750 = default;
M_743 = GetK(MOVES_61, k_742);
r_744 = Get(M_743, "rel");
if ((!(Truthy(r_744)) || !(Truthy(Get(r_744, "__rel"))))) {
return default;
}
{ V _t751 = Get(r_744, "__rel");
{ V _t752 = ListOf(_t751);
{ V _t753 = GetIdx(_t752, 0D);
ch_745 = _t753; }
{ V _t754 = GetIdx(_t752, 1D);
a_746 = _t754; }
{ V _t755 = GetIdx(_t752, 2D);
em_747 = _t755; }
{ V _t756 = GetIdx(_t752, 3D);
x_748 = _t756; }
} }
from_749 = (GetK((Get(M_743, "press") is var _t757 && Truthy(_t757) ? _t757 : NewObj(0).V), ch_745) is var _t758 && Truthy(_t758) ? _t758 : ((V)(0D)));
kk_750 = NewObj(2).Put("sq", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(110D)), ((V)((-0.15))), ((V)("o"))), Arr(((V)(250D)), ((V)(0.07)), ((V)("io"))), Arr(((V)(410D)), ((V)((-0.02))), ((V)("io"))), Arr(((V)(560D)), ((V)(0D)), ((V)("io"))))).Put("smile", Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(150D)), ((V)(1D)), ((V)("o"))), Arr(((V)(800D)), ((V)(1D))), Arr(((V)(1100D)), ((V)(0D)), ((V)("io"))))).V;
SetK(kk_750, ch_745, (Truthy(from_749) ? Arr(Arr(((V)(0D)), from_749), Arr(((V)(160D)), ((V)(((-ToNum(from_749)) * 0.7))), ((V)("o"))), Arr(((V)(380D)), ((V)((ToNum(from_749) * 0.35))), ((V)("io"))), Arr(((V)(600D)), ((V)(((-ToNum(from_749)) * 0.12))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io")))) : Arr(Arr(((V)(0D)), ((V)(0D))), Arr(((V)(160D)), a_746, ((V)("o"))), Arr(((V)(380D)), ((V)(((-ToNum(a_746)) * 0.4))), ((V)("io"))), Arr(((V)(600D)), ((V)((ToNum(a_746) * 0.15))), ((V)("io"))), Arr(((V)(800D)), ((V)(0D)), ((V)("io"))))));
Set(M_743, "rel", Object_assign(NewObj(3).Put("dur", ((V)(1100D))).Put("k", kk_750).Put("em", (Truthy(em_747) ? Arr(em_747) : Arr())).V, (x_748 is var _t759 && Truthy(_t759) ? _t759 : NewObj(0).V)));
return default;
}, 1, "", true));
DANCES_62 = NewObj(11).Put("nana", Arr(Call(Fn((V _self33, int _argc760, V _a762, V _a763, V _a764, V _a765, V[] _rest761) => {
V t_766 = default;
V B_767 = default;
V a_768 = default;
t_766 = Call(TL_41, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_767 = ((V)(460D));
{
V i_769 = default;
i_769 = ((V)(0D));
while (true) {
if (!(LtN(i_769, 4D))) break;
V d_771 = default;
d_771 = ((V)((NumTruthy((ToNum(i_769) % 2D)) ? 1D : (-1D))));
Invoke(t_766, "to", B_767, NewObj(7).Put("cv", ((V)((ToNum(d_771) * 0.9)))).Put("tilt", ((V)(((-ToNum(d_771)) * 4D)))).Put("x", ((V)(((-ToNum(d_771)) * 1.5)))).PutK(((V)((LtN(d_771, 0D) ? "armL" : "armR"))), ((V)(60D))).PutK(((V)((LtN(d_771, 0D) ? "armR" : "armL"))), ((V)((-6D)))).Put("footL", ((V)((LtN(d_771, 0D) ? 2D : 0D)))).Put("footR", ((V)((GtN(d_771, 0D) ? 2D : 0D)))).V, ((V)("io")));
PostInc(ref i_769, 1D);
}
}
Invoke(t_766, "to", ((V)(300D)), NewObj(7).Put("cv", ((V)(0D))).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_766, "osc", ((V)(1600D)), ((V)(4D)), NewObj(3).Put("cv", ((V)(0.6))).Put("x", ((V)(2.5))).Put("lean", ((V)(2D))).V, NewObj(3).Put("cv", ((V)((-0.4)))).Put("x", ((V)((-2.5)))).Put("lean", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(250D)), NewObj(3).Put("cv", ((V)(0D))).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_766, "to", ((V)(500D)), NewObj(5).Put("cv", ((V)((-1D)))).Put("lift", ((V)(3D))).Put("sq", ((V)((-0.06)))).Put("armL", ((V)(165D))).Put("armR", ((V)(165D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(400D)), NewObj(5).Put("cv", ((V)(0.3))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.03))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("io")));
a_768 = Call(spinR_59, V.Undef, t_766, ((V)(1100D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).V);
Invoke(Invoke(Invoke(t_766, "at", a_768), "to", ((V)(500D)), NewObj(1).Put("cv", ((V)(0.8))).V, ((V)("o"))), "to", ((V)(600D)), NewObj(1).Put("cv", ((V)(0D))).V, ((V)("io")));
Invoke(t_766, "at", Add(a_768, ((V)(1101D))));
Invoke(Invoke(Invoke(Invoke(t_766, "to", ((V)(400D)), NewObj(6).Put("cv", ((V)(1D))).Put("sq", ((V)(0.1))).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).Put("footL", ((V)(1.5))).Put("footR", ((V)(1.5))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("banjuice")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(6).Put("cv", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_766, "to", ((V)(300D)), NewObj(4).Put("cv", ((V)(0.6))).Put("tilt", ((V)((-5D)))).Put("armR", ((V)(150D))).Put("winkR", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(4).Put("cv", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armR", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_766, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Banana Boogie")), ((V)("Her curve flips from side to side on the beat, a hip hula, stretches straight up to the sky, a spin that whips her curve round, a banana-split squat and a curvy pose with a wink.")))).Put("bing", Arr(Call(Fn((V _self33, int _argc772, V _a774, V _a775, V _a776, V _a777, V[] _rest773) => {
V t_778 = default;
V B_779 = default;
V a_780 = default;
t_778 = Call(TL_41, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_779 = ((V)(420D));
{
V i_781 = default;
i_781 = ((V)(0D));
while (true) {
if (!(LtN(i_781, 3D))) break;
Call(hopC_55, V.Undef, t_778, ((V)(7D)), NewObj(3).Put("chain", (LtN(i_781, 2D) ? V.True : V.False)).Put("air", NewObj(2).Put("stw", ((V)(((NumTruthy((ToNum(i_781) % 2D)) ? (-1D) : 1D) * 0.5)))).Put("lf", ((V)(1D))).V).Put("fall", NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0.3))).V).V);
PostInc(ref i_781, 1D);
}
}
Call(land_51, V.Undef, t_778, ((V)(0.07)), ((V)(2D)), ((V)(220D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_778, "to", ((V)(600D)), NewObj(4).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).V, ((V)("i"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(700D)), NewObj(3).Put("stw", ((V)(1D))).Put("lift", ((V)(9D))).Put("sq", ((V)((-0.06)))).V, ((V)("l"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(700D)), NewObj(2).Put("stw", ((V)(1D))).Put("lift", ((V)(9D))).V, ((V)("l"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(800D)), NewObj(6).Put("stw", ((V)(0D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).Put("armL", ((V)(20D))).Put("armR", ((V)(20D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
{
V i_783 = default;
i_783 = ((V)(0D));
while (true) {
if (!(LtN(i_783, 3D))) break;
Invoke(Invoke(Invoke(t_778, "to", ((V)((ToNum(B_779) / 2D))), NewObj(2).Put("sq", ((V)(0.1))).Put("x", ((V)(((ToNum(i_783) - 1D) * 2D)))).V, ((V)("o"))), "to", ((V)((ToNum(B_779) / 2D))), NewObj(2).Put("sq", ((V)((-0.04)))).Put("lift", ((V)(2.5))).V, ((V)("o"))), "to", ((V)((ToNum(B_779) / 3D))), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_783, 1D);
}
}
a_780 = Call(spinR_59, V.Undef, t_778, ((V)(1200D)), ((V)(720D)), NewObj(2).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).V);
Invoke(Invoke(Invoke(t_778, "at", a_780), "to", ((V)(600D)), NewObj(1).Put("stw", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(600D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_778, "at", Add(a_780, ((V)(1201D)))), "to", ((V)(200D)), NewObj(3).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_778, "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("sq", ((V)((-0.06)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("chjuice")), ((V)("head")), ((V)(4D))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(300D)));
return Invoke(Invoke(t_778, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Stem Twirl")), ((V)("Hops with her stem twirling, then spins it up like a propeller for a helicopter lift-off, three bouncy bounces, a double pirouette and a juicy finale.")))).Put("plummy", Arr(Call(Fn((V _self33, int _argc785, V _a787, V _a788, V _a789, V _a790, V[] _rest786) => {
V t_791 = default;
V B_792 = default;
t_791 = Call(TL_41, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_792 = ((V)(480D));
Invoke(Invoke(Invoke(t_791, "to", B_792, NewObj(5).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("lift", ((V)(2D))).Put("sq", ((V)((-0.05)))).Put("close", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(200D))), "to", B_792, NewObj(5).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
{
V i_793 = default;
i_793 = ((V)(0D));
while (true) {
if (!(LtN(i_793, 2D))) break;
Invoke(Invoke(t_791, "to", B_792, NewObj(4).Put("sq", ((V)(0.12))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("pitch", ((V)((-0.05)))).V, ((V)("io"))), "to", B_792, NewObj(5).Put("sq", ((V)((-0.05)))).Put("lift", ((V)(2D))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("pitch", ((V)(0.04))).V, ((V)("io")));
PostInc(ref i_793, 1D);
}
}
Invoke(t_791, "to", ((V)(260D)), NewObj(5).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).Put("armL", ((V)(90D))).Put("armR", ((V)(90D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
Call(spinR_59, V.Undef, t_791, ((V)(1300D)), ((V)(720D)), NewObj(5).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("footR", ((V)(2D))).Put("lift", ((V)(1.5))).Put("lf", ((V)(1D))).V);
Invoke(t_791, "to", ((V)(300D)), NewObj(5).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_791, "to", ((V)(600D)), NewObj(7).Put("pitch", ((V)(0.08))).Put("lean", ((V)(3D))).Put("tilt", ((V)((-6D)))).Put("armL", ((V)(40D))).Put("armR", ((V)(140D))).Put("footL", ((V)(2.4))).Put("stw", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(500D)), NewObj(7).Put("pitch", ((V)(0D))).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("footL", ((V)(0D))).Put("stw", ((V)(0D))).V, ((V)("io")));
Invoke(t_791, "to", ((V)(200D)), NewObj(1).Put("lift", ((V)(1.5))).V, ((V)("io")));
{
V i_795 = default;
i_795 = ((V)(0D));
while (true) {
if (!(LtN(i_795, 8D))) break;
Invoke(t_791, "to", ((V)(115D)), NewObj(3).Put("x", ((V)((ToNum((LtN(i_795, 4D) ? Add(i_795, ((V)(1D))) : ((V)((7D - ToNum(i_795)))))) * 1.4)))).Put("footL", ((V)((NumTruthy((ToNum(i_795) % 2D)) ? 0.9 : 0D)))).Put("footR", ((V)((NumTruthy((ToNum(i_795) % 2D)) ? 0D : 0.9)))).V, ((V)("io")));
PostInc(ref i_795, 1D);
}
}
Invoke(t_791, "to", ((V)(160D)), NewObj(4).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("lift", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
Call(jump_46, V.Undef, t_791, NewObj(7).Put("h", ((V)(9D))).Put("ant", ((V)(170D))).Put("up", ((V)(240D))).Put("c", ((V)(0.12))).Put("arm", ((V)(30D))).Put("air", NewObj(5).Put("footL", ((V)(2.2))).Put("footR", ((V)(2.2))).Put("armL", ((V)(150D))).Put("armR", ((V)(70D))).Put("lf", ((V)(1D))).V).Put("fall", NewObj(5).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("lf", ((V)(0D))).V).V);
Call(land_51, V.Undef, t_791, ((V)(0.06)), ((V)(2D)), ((V)(220D)));
Invoke(Invoke(Invoke(t_791, "to", ((V)(300D)), NewObj(3).Put("pol", ((V)(1D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(300D)));
Invoke(Invoke(Invoke(Invoke(Invoke(t_791, "to", ((V)(600D)), NewObj(6).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.6))).Put("armR", ((V)(100D))).Put("armL", ((V)(20D))).Put("sq", ((V)(0.06))).Put("close", ((V)(0.6))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(400D))), "to", ((V)(500D)), NewObj(6).Put("pitch", ((V)(0D))).Put("ly", ((V)(0D))).Put("armR", ((V)(0D))).Put("armL", ((V)(0D))).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(1).Put("pol", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_791, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.5))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Sugar Plum Twirl")), ((V)("A little ballet: up on tiptoe with his arms over his head, two plies, a double pirouette, an arabesque, tiny tiptoe steps there and back, a grand leap, a shiny polish and a deep bow.")))).Put("clemmy", Arr(Call(Fn((V _self33, int _argc797, V _a799, V _a800, V _a801, V _a802, V[] _rest798) => {
V t_803 = default;
V B_804 = default;
V a_805 = default;
t_803 = Call(TL_41, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_804 = ((V)(380D));
{
V i_806 = default;
i_806 = ((V)(0D));
while (true) {
if (!(LtN(i_806, 4D))) break;
Invoke(Invoke(Invoke(t_803, "to", ((V)((ToNum(B_804) / 2D))), NewObj(3).Put("sq", ((V)(0.06))).PutK(((V)((NumTruthy((ToNum(i_806) % 2D)) ? "footR" : "footL"))), ((V)(2.2))).Put("x", ((V)(((NumTruthy((ToNum(i_806) % 2D)) ? 1D : (-1D)) * 1.2)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(2D))), "to", ((V)((ToNum(B_804) / 2D))), NewObj(3).Put("sq", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_806, 1D);
}
}
Invoke(t_803, "to", ((V)(200D)), NewObj(3).Put("x", ((V)(0D))).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).V, ((V)("io")));
a_805 = Call(spinR_59, V.Undef, t_803, ((V)(2200D)), ((V)(1440D)), NewObj(1).Put("lf", ((V)(1D))).V);
Invoke(Invoke(t_803, "at", Add(a_805, ((V)(1500D)))), "osc", ((V)(700D)), ((V)(3D)), NewObj(1).Put("tilt", ((V)(4D))).V, NewObj(1).Put("tilt", ((V)((-4D)))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_803, "at", Add(a_805, ((V)(2201D)))), "to", ((V)(200D)), NewObj(4).Put("tilt", ((V)(0D))).Put("lf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(5D)));
Invoke(Invoke(Invoke(t_803, "to", ((V)(1000D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(0.8))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
{
V i_808 = default;
i_808 = ((V)(0D));
while (true) {
if (!(LtN(i_808, 2D))) break;
Call(hopC_55, V.Undef, t_803, ((V)(8D)), NewObj(4).Put("chain", (LtN(i_808, 1D) ? V.True : V.False)).Put("air", NewObj(1).Put("lf", ((V)(1D))).V).Put("fall", NewObj(1).Put("lf", ((V)(0D))).V).Put("ev", Arr(Arr(((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(2D))))).V);
PostInc(ref i_808, 1D);
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_803, "to", ((V)(240D)), NewObj(4).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("sq", ((V)((-0.08)))).Put("lift", ((V)(2D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(6D))), "to", ((V)(200D)), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0.05))).V, ((V)("i"))), "to", ((V)(300D)), NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(300D)));
return Invoke(Invoke(t_803, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Peel Spin")), ((V)("Zippy steps that spritz zest, then she spins like a top (wobbling as she slows), twirls her leaves, two quick hops and a zesty finale.")))).Put("appy", Arr(Call(Fn((V _self33, int _argc810, V _a812, V _a813, V _a814, V _a815, V[] _rest811) => {
V t_816 = default;
V B_817 = default;
V a_818 = default;
t_816 = Call(TL_41, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_817 = ((V)(520D));
{
V i_819 = default;
i_819 = ((V)(0D));
while (true) {
if (!(LtN(i_819, 4D))) break;
Invoke(t_816, "to", B_817, NewObj(4).Put("lift", ((V)((NumTruthy((ToNum(i_819) % 2D)) ? 1D : (-2.5))))).Put("tilt", ((V)((NumTruthy((ToNum(i_819) % 2D)) ? (-4D) : 4D)))).Put("sq", ((V)((NumTruthy((ToNum(i_819) % 2D)) ? (-0.02) : 0.04)))).Put("lf", ((V)((NumTruthy((ToNum(i_819) % 2D)) ? 0.2 : 0.6)))).V, ((V)("io")));
PostInc(ref i_819, 1D);
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_816, "to", ((V)(300D)), NewObj(3).Put("lift", ((V)(0D))).Put("tilt", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(3).Put("sq", ((V)(0.14))).Put("pitch", ((V)((-0.1)))).Put("close", ((V)(1D))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(2).Put("lift", ((V)((-4D)))).Put("sq", ((V)(0.06))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("drop")), ((V)("body")), ((V)(5D))), "to", ((V)(260D)), NewObj(5).Put("lift", ((V)(6D))).Put("sq", ((V)((-0.08)))).Put("close", ((V)(0D))).Put("wide", ((V)(0.6))).Put("pitch", ((V)(0.08))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("lift", ((V)(0D))).Put("sq", ((V)(0.04))).Put("wide", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("splash")), ((V)("body")), ((V)(1D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
a_818 = Call(spinR_59, V.Undef, t_816, ((V)(1000D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V);
Invoke(Invoke(Invoke(t_816, "at", Add(a_818, ((V)(1001D)))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
{
V i_821 = default;
i_821 = ((V)(0D));
while (true) {
if (!(LtN(i_821, 4D))) break;
Invoke(Invoke(t_816, "to", ((V)((ToNum(B_817) / 2D))), NewObj(4).Put("sq", ((V)(0.08))).PutK(((V)((NumTruthy((ToNum(i_821) % 2D)) ? "footR" : "footL"))), ((V)(2.4))).Put("armL", ((V)((NumTruthy((ToNum(i_821) % 2D)) ? 40D : 10D)))).Put("armR", ((V)((NumTruthy((ToNum(i_821) % 2D)) ? 10D : 40D)))).V, ((V)("o"))), "to", ((V)((ToNum(B_817) / 2D))), NewObj(3).Put("sq", ((V)(0D))).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_821, 1D);
}
}
Invoke(Invoke(Invoke(Invoke(Invoke(t_816, "to", ((V)(300D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(150D))).Put("tilt", ((V)((-4D)))).Put("winkR", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "wait", ((V)(450D))), "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(0D))).Put("tilt", ((V)(0D))).Put("winkR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_816, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Apple Bob")), ((V)("Bobs like an apple floating in a tub, dunks under and pops back up with a splash, a polishing spin, crunchy stomps and a shiny wink.")))).Put("blueby", Arr(Call(Fn((V _self33, int _argc823, V _a825, V _a826, V _a827, V _a828, V[] _rest824) => {
V t_829 = default;
V B_830 = default;
t_829 = Call(TL_41, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_830 = ((V)(480D));
{
V i_831 = default;
i_831 = ((V)(0D));
while (true) {
if (!(LtN(i_831, 4D))) break;
V d_833 = default;
d_833 = ((V)((NumTruthy((ToNum(i_831) % 2D)) ? 1D : (-1D))));
Invoke(t_829, "to", B_830, NewObj(4).Put("rl", ((V)((ToNum(d_833) * 26D)))).Put("x", ((V)((ToNum(d_833) * 4D)))).PutK(((V)((LtN(d_833, 0D) ? "armR" : "armL"))), ((V)(60D))).PutK(((V)((LtN(d_833, 0D) ? "armL" : "armR"))), ((V)(0D))).V, ((V)("io")));
PostInc(ref i_831, 1D);
}
}
Invoke(t_829, "to", ((V)(300D)), NewObj(4).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_829, "to", ((V)(1000D)), NewObj(2).Put("rl", ((V)(360D))).Put("x", ((V)(14D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "wait", ((V)(150D))), "to", ((V)(1000D)), NewObj(2).Put("rl", ((V)((-360D)))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l")));
Call(jump_46, V.Undef, t_829, NewObj(7).Put("h", ((V)(12D))).Put("ant", ((V)(180D))).Put("up", ((V)(280D))).Put("c", ((V)(0.2))).Put("arm", ((V)(90D))).Put("air", NewObj(2).Put("rl", ((V)((-360D)))).Put("stw", ((V)(0.6))).V).Put("fall", NewObj(1).Put("stw", ((V)(0D))).V).V);
Invoke(t_829, "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(Invoke(t_829, "to", ((V)(900D)), NewObj(4).Put("stw", ((V)(1D))).Put("crf", ((V)(0.6))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(4).Put("stw", ((V)(0D))).Put("crf", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_829, "to", ((V)(500D)), NewObj(4).Put("rl", ((V)((-20D)))).Put("x", ((V)((-3D)))).Put("pitch", ((V)((-0.12)))).Put("close", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(400D)), NewObj(4).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(200D)));
return Invoke(Invoke(t_829, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Blueberry Roll")), ((V)("Rock and roll on her round tummy, a full roll away and back, a roly-poly somersault, her star crown spinning and a rolling bow.")))).Put("coco", Arr(Call(Fn((V _self33, int _argc834, V _a836, V _a837, V _a838, V _a839, V[] _rest835) => {
V t_840 = default;
V B_841 = default;
t_840 = Call(TL_41, V.Undef, NewObj(3).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).Put("rig", ((V)(1D))).V);
B_841 = ((V)(400D));
Invoke(t_840, "to", ((V)(250D)), Call(o_44, V.Undef, Call(both_43, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(2).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V), ((V)("io")));
{
V i_842 = default;
i_842 = ((V)(0D));
while (true) {
if (!(LtN(i_842, 8D))) break;
Invoke(Invoke(Invoke(t_840, "to", ((V)((ToNum(B_841) / 2D))), NewObj(3).PutK(((V)((NumTruthy((ToNum(i_842) % 2D)) ? "hRy" : "hLy"))), ((V)(12D))).Put("sq", ((V)(0.03))).Put("tilt", ((V)((NumTruthy((ToNum(i_842) % 2D)) ? 2D : (-2D))))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("body")), ((V)(1D))), "to", ((V)((ToNum(B_841) / 2D))), NewObj(3).Put("hLy", ((V)(8D))).Put("hRy", ((V)(8D))).Put("sq", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_842, 1D);
}
}
Invoke(t_840, "to", ((V)(250D)), Call(o_44, V.Undef, NOHANDS_45, NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("tilt", ((V)(0D))).V), ((V)("io")));
Call(swing_48, V.Undef, t_840, ((V)(2000D)), ((V)(3D)), NewObj(5).Put("tilt", ((V)(7D))).Put("x", ((V)(2D))).Put("armL", ((V)(50D))).Put("armR", ((V)((-20D)))).Put("lf", ((V)(0.8))).V, ((V)("io")));
Invoke(t_840, "to", ((V)(200D)), NewObj(2).Put("fz", ((V)(1.2))).Put("wide", ((V)(0.5))).V, ((V)("o")));
Call(shake_47, V.Undef, t_840, NewObj(5).Put("P", ((V)(85D))).Put("head", ((V)(0.25))).Put("roll", ((V)(3D))).Put("body", ((V)(0.8))).Put("env", Arr(((V)(0.5)), ((V)(0.9)), ((V)(1D)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).V);
Invoke(Invoke(t_840, "to", ((V)(300D)), NewObj(2).Put("fz", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("fibre")), ((V)("head")), ((V)(4D)));
Call(jump_46, V.Undef, t_840, NewObj(7).Put("h", ((V)(14D))).Put("ant", ((V)(200D))).Put("up", ((V)(300D))).Put("dn", ((V)(220D))).Put("c", ((V)(0.2))).Put("arm", ((V)(100D))).Put("st", ((V)(0.4))).V);
Invoke(Invoke(t_840, "e", ((V)("emit")), ((V)("knock")), ((V)("body")), ((V)(1D))), "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(4D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_840, "to", ((V)(900D)), NewObj(4).Put("rl", ((V)(360D))).Put("x", ((V)(12D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "wait", ((V)(150D))), "to", ((V)(900D)), NewObj(2).Put("rl", ((V)((-360D)))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(t_840, "to", ((V)(300D)), NewObj(2).Put("armR", ((V)(150D))).Put("hyaw", ((V)(0.15))).V, ((V)("io")));
{
V i_844 = default;
i_844 = ((V)(0D));
while (true) {
if (!(LtN(i_844, 3D))) break;
Invoke(Invoke(Invoke(t_840, "to", ((V)(110D)), NewObj(2).Put("armR", ((V)(138D))).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("head")), ((V)(1D))), "to", ((V)(170D)), NewObj(2).Put("armR", ((V)(150D))).Put("sq", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_844, 1D);
}
}
Invoke(Invoke(Invoke(Invoke(t_840, "to", ((V)(300D)), NewObj(2).Put("armR", ((V)(0D))).Put("hyaw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(4).Put("lean", ((V)((-3D)))).Put("close", ((V)(0.6))).Put("armL", ((V)(120D))).Put("armR", ((V)(120D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(4).Put("lean", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_840, "rest", ((V)(300D))), "loop", NewObj(2).Put("stretch", ((V)(0D))).Put("soft", ((V)(0D))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Coconut Knock")), ((V)("Bongo beats on his hollow belly, a palm-tree sway, a hair-raising shake, a coconut drop that lands with a thud, a roll away and back, knock-knock on his head and a chill pose.")))).Put("perry", Arr(Call(Fn((V _self33, int _argc846, V _a848, V _a849, V _a850, V _a851, V[] _rest847) => {
V t_852 = default;
V B_853 = default;
V a_854 = default;
t_852 = Call(TL_41, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_853 = ((V)(520D));
{
V i_855 = default;
i_855 = ((V)(0D));
while (true) {
if (!(LtN(i_855, 4D))) break;
V d_857 = default;
d_857 = ((V)((NumTruthy((ToNum(i_855) % 2D)) ? 1D : (-1D))));
Invoke(t_852, "to", B_853, NewObj(4).Put("tilt", ((V)((ToNum(d_857) * 14D)))).Put("x", ((V)((ToNum(d_857) * 1.5)))).Put("armL", ((V)((GtN(d_857, 0D) ? 70D : 10D)))).Put("armR", ((V)((LtN(d_857, 0D) ? 70D : 10D)))).V, ((V)("io")));
PostInc(ref i_855, 1D);
}
}
Invoke(t_852, "to", ((V)(300D)), NewObj(4).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("io")));
{
V i_858 = default;
i_858 = ((V)(0D));
while (true) {
if (!(LtN(i_858, 8D))) break;
V a_860 = default;
a_860 = ((V)((((ToNum(i_858) / 8D) * System.Math.PI) * 2D)));
Invoke(t_852, "to", ((V)(200D)), NewObj(2).Put("tilt", ((V)((8D * FdLibm.Cos(ToNum(a_860)))))).Put("lean", ((V)((3D * FdLibm.Sin(ToNum(a_860)))))).V, ((V)("l")));
PostInc(ref i_858, 1D);
}
}
Invoke(t_852, "to", ((V)(200D)), NewObj(2).Put("tilt", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_852, "to", ((V)(600D)), NewObj(5).Put("tilt", ((V)((-20D)))).Put("x", ((V)((-2D)))).Put("wide", ((V)(0.6))).Put("armL", ((V)(80D))).Put("armR", ((V)(80D))).V, ((V)("i"))), "to", ((V)(160D)), NewObj(1).Put("tilt", ((V)((-14D)))).V, ((V)("o")));
Call(jelly_50, V.Undef, t_852, ((V)(8D)), ((V)(3D)), ((V)(380D)), ((V)("tilt")));
Invoke(t_852, "to", ((V)(300D)), NewObj(4).Put("x", ((V)(0D))).Put("wide", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
a_854 = Call(spinR_59, V.Undef, t_852, ((V)(1300D)), ((V)(360D)), NewObj(3).Put("armL", ((V)(60D))).Put("armR", ((V)(60D))).Put("lf", ((V)(1D))).V);
Invoke(Invoke(t_852, "at", a_854), "osc", ((V)(1300D)), ((V)(3D)), NewObj(1).Put("tilt", ((V)(4D))).V, NewObj(1).Put("tilt", ((V)((-4D)))).V, ((V)("io")));
Invoke(Invoke(t_852, "at", Add(a_854, ((V)(1301D)))), "to", ((V)(200D)), NewObj(4).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(jump_46, V.Undef, t_852, NewObj(5).Put("h", ((V)(6D))).Put("ant", ((V)(200D))).Put("up", ((V)(220D))).Put("c", ((V)(0.2))).Put("arm", ((V)(40D))).V);
Invoke(t_852, "e", ((V)("emit")), ((V)("pearjuice")), ((V)("head")), ((V)(2D)));
Invoke(t_852, "to", ((V)(300D)), NewObj(3).Put("tilt", ((V)(8D))).Put("armR", ((V)(150D))).Put("winkR", ((V)(1D))).V, ((V)("io")));
Call(jelly_50, V.Undef, t_852, ((V)(6D)), ((V)(3D)), ((V)(400D)), ((V)("tilt")));
Invoke(t_852, "to", ((V)(300D)), NewObj(2).Put("armR", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_852, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Pear Wobble")), ((V)("Tips side to side on his round bottom like a roly-poly toy, wobbles round in a circle, nearly falls over, spins on his bottom, a heavy little hop and a wobbly wink.")))).Put("grana", Arr(Call(Fn((V _self33, int _argc861, V _a863, V _a864, V _a865, V _a866, V[] _rest862) => {
V t_867 = default;
V B_868 = default;
t_867 = Call(TL_41, V.Undef, NewObj(2).Put("smile", ((V)(0.8))).Put("hap", ((V)(1D))).V);
B_868 = ((V)(520D));
{
V i_869 = default;
i_869 = ((V)(0D));
while (true) {
if (!(LtN(i_869, 2D))) break;
V d_871 = default;
V a_872 = default;
d_871 = ((V)((NumTruthy((ToNum(i_869) % 2D)) ? (-1D) : 1D)));
Invoke(Invoke(Invoke(t_867, "to", B_868, NewObj(4).Put("x", ((V)((ToNum(d_871) * 3D)))).Put("tilt", ((V)((ToNum(d_871) * 3D)))).Put("sq", ((V)(0.04))).Put("lift", ((V)(0D))).V, ((V)("io"))), "to", ((V)((ToNum(B_868) * 0.7))), NewObj(2).Put("lift", ((V)(2D))).Put("sq", ((V)((-0.03)))).V, ((V)("o"))), "to", ((V)((ToNum(B_868) * 0.7))), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
a_872 = Call(spinR_59, V.Undef, t_867, ((V)(1100D)), ((V)((ToNum(d_871) * 360D))), NewObj(2).Put("armL", ((V)(40D))).Put("armR", ((V)(40D))).V);
Invoke(t_867, "at", Add(a_872, ((V)(1101D))));
PostInc(ref i_869, 1D);
}
}
Invoke(Invoke(Invoke(Invoke(t_867, "to", ((V)(300D)), NewObj(4).Put("x", ((V)(0D))).Put("tilt", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(600D)), NewObj(4).Put("pitch", ((V)((-0.25)))).Put("close", ((V)(0.7))).Put("armL", ((V)(60D))).Put("armR", ((V)((-10D)))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(500D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_867, "to", ((V)(1200D)), NewObj(2).Put("stw", ((V)(1D))).Put("crf", ((V)(0.7))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("crf", ((V)(0D))).V, ((V)("io")));
{
V i_873 = default;
i_873 = ((V)(0D));
while (true) {
if (!(LtN(i_873, 3D))) break;
Invoke(Invoke(Invoke(t_867, "to", ((V)(140D)), NewObj(2).Put("crf", ((V)(1D))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("arils")), ((V)("head")), ((V)(4D))), "to", ((V)(300D)), NewObj(2).Put("crf", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
PostInc(ref i_873, 1D);
}
}
Invoke(Invoke(Invoke(t_867, "to", ((V)(300D)), NewObj(1).Put("armR", ((V)(150D))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(3D)), NewObj(1).Put("armR", ((V)(135D))).V, NewObj(1).Put("armR", ((V)(155D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_867, "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)(0.1))).Put("close", ((V)(0.5))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_867, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Seed Shower")), ((V)("A royal waltz with turns, a slow regal bow, his crown spins and flares, ruby seeds burst out like confetti, a royal wave and a proud chin-up pose.")))).Put("mangie", Arr(Call(Fn((V _self33, int _argc875, V _a877, V _a878, V _a879, V _a880, V[] _rest876) => {
V t_881 = default;
V B_882 = default;
V tango_883 = default;
V a_884 = default;
t_881 = Call(TL_41, V.Undef, NewObj(2).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).V);
B_882 = ((V)(500D));
tango_883 = Fn((V _self33, int _argc885, V d_891, V _a888, V _a889, V _a890, V[] _rest886) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_881, "to", B_882, NewObj(6).Put("x", ((V)((ToNum(d_891) * 2.5)))).Put("lean", ((V)((ToNum(d_891) * 2D)))).Put("armL", ((V)(90D))).Put("armR", ((V)(40D))).Put("footL", ((V)(2D))).Put("hyaw", ((V)((ToNum(d_891) * 0.2)))).V, ((V)("io"))), "to", B_882, NewObj(3).Put("x", ((V)((ToNum(d_891) * 5D)))).Put("footL", ((V)(0D))).Put("footR", ((V)(2D))).V, ((V)("io"))), "to", ((V)((ToNum(B_882) / 2D))), NewObj(3).Put("x", ((V)((ToNum(d_891) * 6D)))).Put("footR", ((V)(0D))).Put("footL", ((V)(1.5))).V, ((V)("o"))), "to", ((V)((ToNum(B_882) / 2D))), NewObj(3).Put("x", ((V)((ToNum(d_891) * 6.5)))).Put("footL", ((V)(0D))).Put("hyaw", ((V)(((-ToNum(d_891)) * 0.25)))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(1).Put("hyaw", ((V)((ToNum(d_891) * 0.15)))).V, ((V)("o")));
return default;
}, 1, "", true);
Call(tango_883, V.Undef, ((V)(1D)));
Call(tango_883, V.Undef, ((V)((-1D))));
Invoke(t_881, "to", ((V)(400D)), NewObj(5).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_881, "to", ((V)(700D)), NewObj(7).Put("lean", ((V)((-5D)))).Put("tilt", ((V)((-10D)))).Put("pitch", ((V)(0.15))).Put("armL", ((V)(150D))).Put("armR", ((V)(60D))).Put("close", ((V)(0.6))).Put("lf", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(500D)), NewObj(7).Put("lean", ((V)(0D))).Put("tilt", ((V)(0D))).Put("pitch", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(t_881, "to", ((V)(200D)), NewObj(2).Put("stw", ((V)(0.6))).Put("lf", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
a_884 = Call(spinR_59, V.Undef, t_881, ((V)(1300D)), ((V)(360D)), NewObj(2).Put("armL", ((V)(150D))).Put("armR", ((V)(20D))).V);
Invoke(Invoke(t_881, "at", Add(a_884, ((V)(1301D)))), "to", ((V)(200D)), NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(Invoke(t_881, "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(40D))).Put("armL", ((V)(120D))).Put("tilt", ((V)((-4D)))).Put("winkL", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("mouth")), ((V)(1D))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(0D))).Put("armL", ((V)(0D))).Put("tilt", ((V)(0D))).Put("winkL", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("mjuice")), ((V)("head")), ((V)(2D)));
return Invoke(Invoke(t_881, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Mango Tango")), ((V)("A tango both ways - slow, slow, quick-quick with sharp head snaps - a dramatic dip, a leaf flick, a promenade spin and a heart-on-the-lips wink.")))).Put("razzy", Arr(Call(Fn((V _self33, int _argc892, V _a894, V _a895, V _a896, V _a897, V[] _rest893) => {
V t_898 = default;
V B_899 = default;
V a_900 = default;
t_898 = Call(TL_41, V.Undef, NewObj(3).Put("smile", ((V)(0.9))).Put("hap", ((V)(1D))).Put("jig", ((V)(0.2))).V);
B_899 = ((V)(400D));
Invoke(Invoke(t_898, "osc", ((V)(1600D)), ((V)(8D)), NewObj(3).Put("tilt", ((V)(4D))).Put("jig", ((V)(1.2))).Put("x", ((V)(1D))).V, NewObj(3).Put("tilt", ((V)((-4D)))).Put("jig", ((V)(0.5))).Put("x", ((V)((-1D)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(3).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).Put("jig", ((V)(0.2))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_898, "to", ((V)(300D)), NewObj(2).Put("armL", ((V)(130D))).Put("armR", ((V)(130D))).V, ((V)("io"))), "osc", ((V)(1000D)), ((V)(5D)), NewObj(3).Put("hLx", ((V)(2D))).Put("hRx", ((V)((-2D)))).Put("jig", ((V)(0.8))).V, NewObj(3).Put("hLx", ((V)((-1D)))).Put("hRx", ((V)(1D))).Put("jig", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(200D)), Call(o_44, V.Undef, NOHANDS_45, NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
a_900 = Call(spinR_59, V.Undef, t_898, ((V)(1200D)), ((V)(720D)), NewObj(4).Put("armL", ((V)(100D))).Put("armR", ((V)(100D))).Put("jig", ((V)(1.2))).Put("stw", ((V)(0.6))).V);
Invoke(Invoke(Invoke(t_898, "at", Add(a_900, ((V)(1201D)))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(4D))), "to", ((V)(250D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("jig", ((V)(0.2))).Put("stw", ((V)(0D))).V, ((V)("io")));
{
V i_901 = default;
i_901 = ((V)(0D));
while (true) {
if (!(LtN(i_901, 4D))) break;
Invoke(Invoke(Invoke(t_898, "to", ((V)((ToNum(B_899) / 2D))), NewObj(2).Put("sq", ((V)(0.1))).Put("jig", ((V)(1D))).V, ((V)("o"))), "to", ((V)((ToNum(B_899) / 2D))), NewObj(3).Put("sq", ((V)((-0.03)))).Put("lift", ((V)(2D))).Put("jig", ((V)(0.4))).V, ((V)("o"))), "to", ((V)((ToNum(B_899) / 3D))), NewObj(2).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_901, 1D);
}
}
Invoke(t_898, "to", ((V)(200D)), NewObj(1).Put("jig", ((V)(1.4))).V, ((V)("o")));
Call(shake_47, V.Undef, t_898, NewObj(5).Put("P", ((V)(80D))).Put("head", ((V)(0.2))).Put("roll", ((V)(3D))).Put("body", ((V)(0.7))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.2)))).V);
Invoke(Invoke(t_898, "to", ((V)(300D)), NewObj(1).Put("jig", ((V)(0.2))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("rzjuice")), ((V)("head")), ((V)(2D)));
Invoke(Invoke(Invoke(Invoke(t_898, "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("sq", ((V)((-0.06)))).Put("winkR", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "wait", ((V)(450D))), "to", ((V)(300D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("sq", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
return Invoke(Invoke(t_898, "rest", ((V)(300D))), "loop", NewObj(1).Put("stretch", ((V)(0.6))).V);
return default;
}, 0, "", true), V.Undef), ((V)("Razzle Dazzle")), ((V)("A jiggle shimmy that wobbles every bead, jazz hands, a sparkling double spin, bead-bouncing beats, a shimmy-shake and a starry wink.")))).V;
Invoke(KEYS_11, "forEach", Fn((V _self33, int _argc903, V k_909, V _a906, V _a907, V _a908, V[] _rest904) => {
if (Truthy(GetK(DANCES_62, k_909))) {
Set(GetK(MOVES_61, k_909), "dance", GetK(DANCES_62, k_909));
}
Set(GetK(MOVES_61, k_909), "look", Call(natF_53, V.Undef, ((V)(1D))));
return default;
}, 1, "", true));
Call(install_52, V.Undef, MOVES_61, CARDS_60);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_952 => Fn((V _self910, int _argc911, V _a913, V _a914, V _a915, V _a916, V[] _rest912) => {
V R_917 = default;
V S_918 = default;
V hand_919 = default;
V both_920 = default;
V o_921 = default;
V NOHANDS_922 = default;
V jump_923 = default;
V shake_924 = default;
V jelly_925 = default;
V see_926 = default;
V unsee_927 = default;
V giggle_928 = default;
V sniff_929 = default;
V lick_930 = default;
V para_931 = default;
V leanIn_932 = default;
V happy_933 = default;
V build_934 = default;
V eyeRub_935 = default;
V lookBack_936 = default;
V hop_937 = default;
V tickle_938 = default;
V tasteHeart_939 = default;
V nose_940 = default;
V pulse_941 = default;
V JU_942 = default;
V J_943 = default;
V P_944 = default;
V RE_945 = default;
V BODY_946 = default;
V he_947 = default;
V pr_948 = default;
V T0_949 = default;
V TX_950 = default;
V TXT_951 = default;
if (_self910.IsNullish) _self910 = GlobalV;
R_917 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_917)) || !(Truthy(Get(R_917, "POKELIB")))) || !(Truthy(Get(R_917, "fruitV")))) || !(Truthy(Get(Get(R_917, "STATES"), "poke_head"))))) {
Call(G("setTimeout"), V.Undef, boot_952.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_917, "fruitPokeV"))) {
return default;
}
Set(R_917, "fruitPokeV", ((V)(1D)));
{ V _t953 = Get(R_917, "PETLIB");
if (_t953.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t953));
{ V _t954 = Get(_t953, "S");
S_918 = _t954; }
{ V _t955 = Get(_t953, "hand");
hand_919 = _t955; }
{ V _t956 = Get(_t953, "both");
both_920 = _t956; }
{ V _t957 = Get(_t953, "o");
o_921 = _t957; }
{ V _t958 = Get(_t953, "NOHANDS");
NOHANDS_922 = _t958; }
{ V _t959 = Get(_t953, "jump");
jump_923 = _t959; }
{ V _t960 = Get(_t953, "shake");
shake_924 = _t960; }
{ V _t961 = Get(_t953, "jelly");
jelly_925 = _t961; } }
{ V _t962 = Get(R_917, "POKELIB");
if (_t962.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t962));
{ V _t963 = Get(_t962, "see");
see_926 = _t963; }
{ V _t964 = Get(_t962, "unsee");
unsee_927 = _t964; }
{ V _t965 = Get(_t962, "giggle");
giggle_928 = _t965; }
{ V _t966 = Get(_t962, "sniff");
sniff_929 = _t966; }
{ V _t967 = Get(_t962, "lick");
lick_930 = _t967; }
{ V _t968 = Get(_t962, "para");
para_931 = _t968; }
{ V _t969 = Get(_t962, "leanIn");
leanIn_932 = _t969; }
{ V _t970 = Get(_t962, "happy");
happy_933 = _t970; }
{ V _t971 = Get(_t962, "build");
build_934 = _t971; } }
eyeRub_935 = Fn((V _self910, int _argc972, V t_978, V s_979, V _a976, V _a977, V[] _rest973) => {
V k_980 = default;
V h_981 = default;
k_980 = Call(S_918, V.Undef, s_979);
h_981 = Call(hand_919, V.Undef, s_979, ((V)(12D)), ((V)((-20D))));
Invoke(Invoke(t_978, "e", ((V)("blink2"))), "to", ((V)(300D)), Call(o_921, V.Undef, h_981, NewObj(2).PutK(Get(k_980, "arm"), ((V)(20D))).PutK(Get(k_980, "wink"), ((V)(1D))).V), ((V)("io")));
{
V i_982 = default;
i_982 = ((V)(0D));
while (true) {
if (!(LtN(i_982, 2D))) break;
Invoke(Invoke(t_978, "to", ((V)(170D)), NewObj(2).PutK(Get(k_980, "hx"), Add(GetK(h_981, Get(k_980, "hx")), ((V)((LtN(s_979, 0D) ? 3D : (-3D)))))).PutK(Get(k_980, "hy"), ((V)((ToNum(GetK(h_981, Get(k_980, "hy"))) - 1.5)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(2).PutK(Get(k_980, "hx"), GetK(h_981, Get(k_980, "hx"))).PutK(Get(k_980, "hy"), GetK(h_981, Get(k_980, "hy"))).V, ((V)("io")));
PostInc(ref i_982, 1D);
}
}
return Invoke(Invoke(t_978, "to", ((V)(300D)), NewObj(4).PutK(Get(k_980, "hx"), ((V)(0D))).PutK(Get(k_980, "hy"), ((V)(0D))).PutK(Get(k_980, "arm"), ((V)(0D))).PutK(Get(k_980, "wink"), ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink")));
return default;
}, 2, "", true);
lookBack_936 = Fn((V _self910, int _argc984, V t_990, V hold_991, V _a988, V _a989, V[] _rest985) => {
Call(see_926, V.Undef, t_990, ((V)("tail")), ((V)(1D)), (hold_991 is var _t992 && Truthy(_t992) ? _t992 : ((V)(350D))));
return Call(unsee_927, V.Undef, t_990, ((V)(380D)));
return default;
}, 2, "", true);
hop_937 = Fn((V _self910, int _argc993, V t_999, V h_1000, V ev_1001, V x_1002, V[] _rest994) => {
return Call(jump_923, V.Undef, t_999, Call(o_921, V.Undef, NewObj(6).Put("h", (h_1000 is var _t1003 && Truthy(_t1003) ? _t1003 : ((V)(6D)))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).Put("ev", ev_1001).V, (x_1002 is var _t1004 && Truthy(_t1004) ? _t1004 : NewObj(0).V)));
}, 4, "", true);
tickle_938 = Fn((V _self910, int _argc1005, V t_1011, V extra_1012, V _a1009, V _a1010, V[] _rest1006) => {
V a_1013 = default;
Invoke(t_1011, "to", ((V)(220D)), Call(o_921, V.Undef, Call(both_920, V.Undef, ((V)(8D)), ((V)((-4D)))), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
a_1013 = Get(t_1011, "t");
Call(giggle_928, V.Undef, t_1011, ((V)(3D)), ((V)(0.9)));
if (Truthy(extra_1012)) {
Call(para_931, V.Undef, t_1011, a_1013, extra_1012);
}
return Invoke(t_1011, "to", ((V)(260D)), NOHANDS_922, ((V)("io")));
return default;
}, 2, "", true);
tasteHeart_939 = Fn((V _self910, int _argc1014, V t_1020, V _a1017, V _a1018, V _a1019, V[] _rest1015) => {
Call(lick_930, V.Undef, t_1020, ((V)(2D)));
return Invoke(Invoke(Invoke(Invoke(t_1020, "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(320D))), "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true);
nose_940 = Fn((V _self910, int _argc1021, V t_1027, V k_1028, V _a1025, V _a1026, V[] _rest1022) => {
Invoke(t_1027, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
if (Truthy(k_1028)) {
Call(k_1028, V.Undef, t_1027);
}
return Invoke(t_1027, "to", ((V)(200D)), NewObj(1).Put("ly", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
pulse_941 = Fn((V _self910, int _argc1029, V t_1035, V v_1036, V d1_1037, V d2_1038, V[] _rest1030) => {
V z_1039 = default;
z_1039 = NewObj(0).V;
{
foreach (V _k1040 in ForInKeys(v_1036)) {
V p_1041 = default;
p_1041 = _k1040;
SetK(z_1039, p_1041, ((V)(0D)));
}
}
return Invoke(Invoke(t_1035, "to", (d1_1037 is var _t1043 && Truthy(_t1043) ? _t1043 : ((V)(140D))), v_1036, ((V)("o"))), "to", (d2_1038 is var _t1042 && Truthy(_t1042) ? _t1042 : ((V)(340D))), z_1039, ((V)("io")));
return default;
}, 4, "", true);
JU_942 = Get(Get(R_917, "FRUITLIB"), "JUICE");
J_943 = Fn((V _self910, int _argc1044, V t_1050, V k_1051, V w_1052, V n_1053, V[] _rest1045) => {
return Invoke(t_1050, "e", ((V)("emit")), GetK(JU_942, k_1051), (w_1052 is var _t1054 && Truthy(_t1054) ? _t1054 : ((V)("head"))), (n_1053 is var _t1055 && Truthy(_t1055) ? _t1055 : ((V)(2D))));
}, 4, "", true);
P_944 = NewObj(20).Put("pina", NewObj(3).Put("part", Fn((V _self910, int _argc1056, V t_1062, V a_1063, V _a1060, V _a1061, V[] _rest1057) => {
return Call(pulse_941, V.Undef, t_1062, NewObj(1).Put("crw", a_1063).V);
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1064, V u_1070, V _a1067, V _a1068, V _a1069, V[] _rest1065) => {
return Invoke(Invoke(u_1070, "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("crs", ((V)(0.3))).Put("crw", ((V)(0.4))).V, NewObj(2).Put("crs", ((V)((-0.2)))).Put("crw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("crs", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("side", Fn((V _self910, int _argc1071, V t_1077, V s_1078, V _a1075, V _a1076, V[] _rest1072) => {
Invoke(Invoke(Invoke(t_1077, "to", ((V)(300D)), NewObj(3).Put("tilt", ((V)(((-ToNum(s_1078)) * 7D)))).Put("x", ((V)(((-ToNum(s_1078)) * 2D)))).Put("crs", ((V)((ToNum(s_1078) * 0.3)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("tilt", ((V)((ToNum(s_1078) * 2D)))).Put("crs", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("tilt", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).V).Put("avo", NewObj(3).Put("part", Fn((V _self910, int _argc1079, V t_1085, V a_1086, V _a1083, V _a1084, V[] _rest1080) => {
Call(pulse_941, V.Undef, t_1085, NewObj(1).Put("pp", ((V)((0.6 * ToNum(a_1086))))).V);
Invoke(Invoke(t_1085, "to", ((V)(200D)), NewObj(1).Put("prw", a_1086).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("prw", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1087, V u_1093, V _a1090, V _a1091, V _a1092, V[] _rest1088) => {
return Invoke(Invoke(u_1093, "to", ((V)(800D)), NewObj(1).Put("pr", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("pr", ((V)(0D))).V, ((V)("l")));
}, 1, "tick", true)).Put("head", Fn((V _self910, int _argc1094, V t_1100, V s_1101, V _a1098, V _a1099, V[] _rest1095) => {
Invoke(Invoke(Invoke(Invoke(t_1100, "to", ((V)(150D)), NewObj(2).Put("lfl", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("lfl", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(600D)), NewObj(1).Put("lsp", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("lsp", ((V)(0D))).V, ((V)("l")));
Call(giggle_928, V.Undef, t_1100, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("berri", NewObj(3).Put("part", Fn((V _self910, int _argc1102, V t_1108, V a_1109, V _a1106, V _a1107, V[] _rest1103) => {
return Call(pulse_941, V.Undef, t_1108, NewObj(2).Put("lfl", a_1109).Put("stw", ((V)((0.7 * ToNum(a_1109))))).V);
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1110, V u_1116, V _a1113, V _a1114, V _a1115, V[] _rest1111) => {
return Invoke(Invoke(u_1116, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("stw", ((V)(0.6))).V, NewObj(1).Put("stw", ((V)((-0.3)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("head", Fn((V _self910, int _argc1117, V t_1123, V s_1124, V _a1121, V _a1122, V[] _rest1118) => {
Invoke(Invoke(Invoke(t_1123, "to", ((V)(140D)), NewObj(3).Put("lfl", ((V)(1D))).Put("stw", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("juice")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(2).Put("lfl", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(jelly_925, V.Undef, t_1123, ((V)(0.7)), ((V)(3D)), ((V)(260D)), ((V)("stw")));
Call(giggle_928, V.Undef, t_1123, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("lemmy", NewObj(3).Put("part", Fn((V _self910, int _argc1125, V t_1131, V a_1132, V _a1129, V _a1130, V[] _rest1126) => {
Invoke(Invoke(Invoke(t_1131, "to", ((V)(110D)), NewObj(3).Put("close", ((V)((0.85 * ToNum(a_1132))))).Put("mw", ((V)((1D - (0.6 * ToNum(a_1132)))))).Put("puff", ((V)(((-0.3) * ToNum(a_1132))))).V, ((V)("o"))), "wait", ((V)(250D))), "to", ((V)(260D)), NewObj(3).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).Put("puff", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("nose", Fn((V _self910, int _argc1133, V u_1139, V _a1136, V _a1137, V _a1138, V[] _rest1134) => {
Call(sniff_929, V.Undef, u_1139, ((V)(2D)));
Invoke(u_1139, "to", ((V)(110D)), NewObj(2).Put("close", ((V)(0.85))).Put("mw", ((V)(0.35))).V, ((V)("o")));
Call(shake_924, V.Undef, u_1139, NewObj(4).Put("P", ((V)(70D))).Put("head", ((V)(0.14))).Put("roll", ((V)(2D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.6)), ((V)(0.3)))).V);
Invoke(Invoke(Invoke(u_1139, "to", ((V)(250D)), NewObj(4).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "nose", true)).Put("belly", Fn((V _self910, int _argc1140, V t_1146, V s_1147, V _a1144, V _a1145, V[] _rest1141) => {
Call(tickle_938, V.Undef, t_1146, Fn((V _self910, int _argc1148, V u_1154, V _a1151, V _a1152, V _a1153, V[] _rest1149) => {
return Invoke(Invoke(u_1154, "osc", ((V)(900D)), ((V)(6D)), NewObj(1).Put("tilt", ((V)(3D))).V, NewObj(1).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
Call(J_943, V.Undef, t_1146, ((V)("lemmy")), ((V)("head")), ((V)(2D)));
return default;
}, 2, "belly", true)).V).Put("kiwi", NewObj(3).Put("part", Fn((V _self910, int _argc1155, V t_1161, V a_1162, V _a1159, V _a1160, V[] _rest1156) => {
return Call(pulse_941, V.Undef, t_1161, NewObj(1).Put("fzz", a_1162).V, ((V)(120D)), ((V)(420D)));
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1163, V u_1169, V _a1166, V _a1167, V _a1168, V[] _rest1164) => {
return Invoke(Invoke(Invoke(u_1169, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("fzz", ((V)(0.7))).V, NewObj(1).Put("fzz", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("fzz", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("kiwifuzz")), ((V)("head")), ((V)(2D)));
}, 1, "tick", true)).Put("head", Fn((V _self910, int _argc1170, V t_1176, V s_1177, V _a1174, V _a1175, V[] _rest1171) => {
{
V i_1178 = default;
i_1178 = ((V)(0D));
while (true) {
if (!(LtN(i_1178, 3D))) break;
Invoke(Invoke(t_1176, "to", ((V)(130D)), NewObj(1).Put("pitch", ((V)(0.12))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(1).Put("pitch", ((V)((-0.05)))).V, ((V)("i")));
PostInc(ref i_1178, 1D);
}
}
Invoke(Invoke(t_1176, "to", ((V)(150D)), NewObj(2).Put("pitch", ((V)(0D))).Put("stw", ((V)(0.7))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
Call(giggle_928, V.Undef, t_1176, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("melo", NewObj(3).Put("part", Fn((V _self910, int _argc1180, V t_1186, V a_1187, V _a1184, V _a1185, V[] _rest1181) => {
return Call(pulse_941, V.Undef, t_1186, NewObj(1).Put("sdj", a_1187).V, ((V)(120D)), ((V)(500D)));
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1188, V u_1194, V _a1191, V _a1192, V _a1193, V[] _rest1189) => {
return Invoke(Invoke(u_1194, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("sdj", ((V)(0.9))).V, NewObj(1).Put("sdj", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("foot", Fn((V _self910, int _argc1195, V t_1201, V s_1202, V _a1199, V _a1200, V[] _rest1196) => {
Call(hop_937, V.Undef, t_1201, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("melojuice")), ((V)("head")), ((V)(3D)))), NewObj(2).Put("air", NewObj(1).Put("sdj", ((V)(1D))).V).Put("fall", NewObj(1).Put("sdj", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).V).Put("peachy", NewObj(3).Put("part", Fn((V _self910, int _argc1203, V t_1209, V a_1210, V _a1207, V _a1208, V[] _rest1204) => {
Invoke(Invoke(Invoke(Invoke(t_1209, "to", ((V)(200D)), NewObj(2).Put("blush", a_1210).Put("lfl", ((V)((0.6 * ToNum(a_1210))))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(400D)), NewObj(1).Put("lfl", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("cheekX", NewObj(2).Put("blush", ((V)(1D))).Put("lfl", ((V)(0.4))).V).Put("tick", Fn((V _self910, int _argc1211, V u_1217, V _a1214, V _a1215, V _a1216, V[] _rest1212) => {
return Invoke(Invoke(Invoke(u_1217, "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).V).Put("pitaya", NewObj(4).Put("part", Fn((V _self910, int _argc1218, V t_1224, V a_1225, V _a1222, V _a1223, V[] _rest1219) => {
return Call(pulse_941, V.Undef, t_1224, NewObj(2).Put("brf", a_1225).Put("wsp", ((V)((0.6 * ToNum(a_1225))))).V);
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1226, V u_1232, V _a1229, V _a1230, V _a1231, V[] _rest1227) => {
return Invoke(Invoke(u_1232, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("wfl", ((V)(1.2))).V, NewObj(1).Put("wfl", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("wfl", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("ear", Fn((V _self910, int _argc1233, V t_1239, V s_1240, V _a1237, V _a1238, V[] _rest1234) => {
Invoke(Invoke(Invoke(t_1239, "to", ((V)(150D)), NewObj(2).Put("wsp", ((V)(1D))).Put("wfl", ((V)(1.4))).V, ((V)("o"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("wsp", ((V)(0D))).Put("wfl", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("head", Fn((V _self910, int _argc1241, V t_1247, V s_1248, V _a1245, V _a1246, V[] _rest1242) => {
Invoke(Invoke(Invoke(t_1247, "to", ((V)(130D)), NewObj(3).Put("crw", ((V)(1D))).Put("spk", ((V)(1D))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(400D)), NewObj(3).Put("crw", ((V)(0D))).Put("spk", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(giggle_928, V.Undef, t_1247, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("tutti", NewObj(4).Put("part", Fn((V _self910, int _argc1249, V t_1255, V a_1256, V _a1253, V _a1254, V[] _rest1250) => {
return Call(pulse_941, V.Undef, t_1255, NewObj(2).Put("cb", a_1256).Put("wfl", a_1256).V, ((V)(140D)), ((V)(400D)));
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1257, V u_1263, V _a1260, V _a1261, V _a1262, V[] _rest1258) => {
return Invoke(Invoke(Invoke(u_1263, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("wfl", ((V)(1.4))).V, NewObj(1).Put("wfl", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("wfl", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("head")), ((V)(2D)));
}, 1, "tick", true)).Put("ear", Fn((V _self910, int _argc1264, V t_1270, V s_1271, V _a1268, V _a1269, V[] _rest1265) => {
Invoke(Invoke(Invoke(Invoke(t_1270, "to", ((V)(150D)), NewObj(1).Put("wfl", ((V)(1.5))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(1).Put("wfl", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("belly", Fn((V _self910, int _argc1272, V t_1278, V s_1279, V _a1276, V _a1277, V[] _rest1273) => {
Call(tickle_938, V.Undef, t_1278, Fn((V _self910, int _argc1280, V u_1286, V _a1283, V _a1284, V _a1285, V[] _rest1281) => {
return Invoke(Invoke(u_1286, "to", ((V)(600D)), NewObj(1).PutK(((V)((LtN(s_1279, 0D) ? "fL" : "fR"))), ((V)(1D))).V, ((V)("l"))), "to", ((V)(1D)), NewObj(2).Put("fL", ((V)(0D))).Put("fR", ((V)(0D))).V, ((V)("l")));
}, 1, "", true));
return default;
}, 2, "belly", true)).V).Put("nana", NewObj(3).Put("part", Fn((V _self910, int _argc1287, V t_1293, V a_1294, V _a1291, V _a1292, V[] _rest1288) => {
Call(jelly_925, V.Undef, t_1293, ((V)((0.6 * ToNum(a_1294)))), ((V)(3D)), ((V)(280D)), ((V)("cv")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1295, V u_1301, V _a1298, V _a1299, V _a1300, V[] _rest1296) => {
return Invoke(Invoke(u_1301, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("cv", ((V)(0.7))).V, NewObj(1).Put("cv", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("cv", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("side", Fn((V _self910, int _argc1302, V t_1308, V s_1309, V _a1306, V _a1307, V[] _rest1303) => {
Invoke(Invoke(t_1308, "to", ((V)(200D)), NewObj(2).Put("cv", ((V)((ToNum(s_1309) * 0.9)))).Put("tilt", ((V)(((-ToNum(s_1309)) * 3D)))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("cv", ((V)(((-ToNum(s_1309)) * 0.4)))).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(jelly_925, V.Undef, t_1308, ((V)(0.3)), ((V)(2D)), ((V)(260D)), ((V)("cv")));
return default;
}, 2, "side", true)).V).Put("bing", NewObj(3).Put("part", Fn((V _self910, int _argc1310, V t_1316, V a_1317, V _a1314, V _a1315, V[] _rest1311) => {
Invoke(t_1316, "to", ((V)(120D)), NewObj(1).Put("lf", a_1317).V, ((V)("o")));
Call(jelly_925, V.Undef, t_1316, ((V)((0.5 * ToNum(a_1317)))), ((V)(3D)), ((V)(260D)), ((V)("stw")));
Invoke(t_1316, "to", ((V)(200D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1318, V u_1324, V _a1321, V _a1322, V _a1323, V[] _rest1319) => {
return Invoke(Invoke(u_1324, "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("stw", ((V)(0.4))).Put("lf", ((V)(0.8))).V, NewObj(2).Put("stw", ((V)((-0.4)))).Put("lf", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("head", Fn((V _self910, int _argc1325, V t_1331, V s_1332, V _a1329, V _a1330, V[] _rest1326) => {
Invoke(Invoke(Invoke(t_1331, "to", ((V)(600D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(giggle_928, V.Undef, t_1331, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("plummy", NewObj(5).Put("part", Fn((V _self910, int _argc1333, V t_1339, V a_1340, V _a1337, V _a1338, V[] _rest1334) => {
Invoke(t_1339, "to", ((V)(120D)), NewObj(1).Put("lf", a_1340).V, ((V)("o")));
Call(jelly_925, V.Undef, t_1339, ((V)((0.4 * ToNum(a_1340)))), ((V)(3D)), ((V)(260D)), ((V)("stw")));
Invoke(t_1339, "to", ((V)(200D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1341, V u_1347, V _a1344, V _a1345, V _a1346, V[] _rest1342) => {
return Invoke(Invoke(u_1347, "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("pol", ((V)(0.7))).Put("lf", ((V)(0.8))).V, NewObj(2).Put("pol", ((V)(0.3))).Put("lf", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(2).Put("pol", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("head", Fn((V _self910, int _argc1348, V t_1354, V s_1355, V _a1352, V _a1353, V[] _rest1349) => {
Invoke(Invoke(Invoke(t_1354, "to", ((V)(600D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(500D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(giggle_928, V.Undef, t_1354, ((V)(2D)));
return default;
}, 2, "head", true)).Put("foot", Fn((V _self910, int _argc1356, V t_1362, V s_1363, V _a1360, V _a1361, V[] _rest1357) => {
Invoke(Invoke(Invoke(Invoke(t_1362, "to", ((V)(260D)), NewObj(4).Put("lift", ((V)(1.5))).Put("sq", ((V)((-0.04)))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)("io"))), "to", ((V)(750D)), NewObj(2).Put("spin", ((V)(360D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(260D)), NewObj(5).Put("lift", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(giggle_928, V.Undef, t_1362, ((V)(2D)));
return default;
}, 2, "foot", true)).Put("cheekX", NewObj(1).Put("blush", ((V)(0.7))).V).V).Put("clemmy", NewObj(3).Put("part", Fn((V _self910, int _argc1364, V t_1370, V a_1371, V _a1368, V _a1369, V[] _rest1365) => {
Invoke(Invoke(Invoke(t_1370, "to", ((V)(120D)), NewObj(1).Put("lf", a_1371).V, ((V)("o"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(Round((2D + (3D * ToNum(a_1371))))))), "to", ((V)(300D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1372, V u_1378, V _a1375, V _a1376, V _a1377, V[] _rest1373) => {
return Invoke(Invoke(Invoke(u_1378, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("lf", ((V)(0.9))).V, NewObj(1).Put("lf", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(3D)));
}, 1, "tick", true)).Put("head", Fn((V _self910, int _argc1379, V t_1385, V s_1386, V _a1383, V _a1384, V[] _rest1380) => {
Invoke(Invoke(Invoke(Invoke(t_1385, "to", ((V)(700D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(3D)));
Call(giggle_928, V.Undef, t_1385, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("appy", NewObj(3).Put("part", Fn((V _self910, int _argc1387, V t_1393, V a_1394, V _a1391, V _a1392, V[] _rest1388) => {
Invoke(Invoke(t_1393, "to", ((V)(120D)), NewObj(1).Put("lf", a_1394).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1395, V u_1401, V _a1398, V _a1399, V _a1400, V[] _rest1396) => {
return Invoke(Invoke(u_1401, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("lf", ((V)(0.8))).V, NewObj(1).Put("lf", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("head", Fn((V _self910, int _argc1402, V t_1408, V s_1409, V _a1406, V _a1407, V[] _rest1403) => {
Invoke(Invoke(Invoke(t_1408, "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0.05))).Put("lf", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(2).Put("sq", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(giggle_928, V.Undef, t_1408, ((V)(2D)));
return default;
}, 2, "head", true)).V).Put("blueby", NewObj(4).Put("part", Fn((V _self910, int _argc1410, V t_1416, V a_1417, V _a1414, V _a1415, V[] _rest1411) => {
return Call(pulse_941, V.Undef, t_1416, NewObj(1).Put("crf", a_1417).V);
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1418, V u_1424, V _a1421, V _a1422, V _a1423, V[] _rest1419) => {
return Invoke(Invoke(u_1424, "osc", ((V)(1000D)), ((V)(3D)), NewObj(2).Put("rl", ((V)(14D))).Put("x", ((V)(2D))).V, NewObj(2).Put("rl", ((V)((-14D)))).Put("x", ((V)((-2D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("side", Fn((V _self910, int _argc1425, V t_1431, V s_1432, V _a1429, V _a1430, V[] _rest1426) => {
Invoke(Invoke(Invoke(t_1431, "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(((-ToNum(s_1432)) * 40D)))).Put("x", ((V)(((-ToNum(s_1432)) * 5D)))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("rl", ((V)((ToNum(s_1432) * 8D)))).Put("x", ((V)(((-ToNum(s_1432)) * 2D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self910, int _argc1433, V t_1439, V s_1440, V _a1437, V _a1438, V[] _rest1434) => {
Invoke(Invoke(Invoke(t_1439, "to", ((V)(700D)), NewObj(2).Put("rl", ((V)(((-ToNum(s_1440)) * 360D)))).Put("x", ((V)(((-ToNum(s_1440)) * 6D)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(1).Put("x", ((V)(0D))).V, ((V)("io")));
Call(giggle_928, V.Undef, t_1439, ((V)(2D)));
return default;
}, 2, "foot", true)).V).Put("coco", NewObj(4).Put("part", Fn((V _self910, int _argc1441, V t_1447, V a_1448, V _a1445, V _a1446, V[] _rest1442) => {
Invoke(Invoke(t_1447, "to", ((V)(120D)), NewObj(1).Put("fz", a_1448).V, ((V)("o"))), "to", ((V)(500D)), NewObj(1).Put("fz", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("foot", Fn((V _self910, int _argc1449, V t_1455, V s_1456, V _a1453, V _a1454, V[] _rest1450) => {
Invoke(Invoke(Invoke(t_1455, "to", ((V)(800D)), NewObj(2).Put("rl", ((V)(((-ToNum(s_1456)) * 360D)))).Put("x", ((V)(((-ToNum(s_1456)) * 7D)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("rl", ((V)(0D))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(1).Put("x", ((V)(0D))).V, ((V)("io")));
Call(giggle_928, V.Undef, t_1455, ((V)(2D)));
return default;
}, 2, "foot", true)).Put("head", Fn((V _self910, int _argc1457, V t_1463, V s_1464, V _a1461, V _a1462, V[] _rest1458) => {
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_1463, "to", ((V)(80D)), NewObj(1).Put("sq", ((V)(0.03))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("head")), ((V)(1D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(3).Put("lx", ((V)(0.8))).Put("hyaw", ((V)(0.2))).Put("close", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(3).Put("lx", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Call(giggle_928, V.Undef, t_1463, ((V)(2D)));
return default;
}, 2, "head", true)).Put("belly", Fn((V _self910, int _argc1465, V t_1471, V s_1472, V _a1469, V _a1470, V[] _rest1466) => {
Call(tickle_938, V.Undef, t_1471, Fn((V _self910, int _argc1473, V u_1479, V _a1476, V _a1477, V _a1478, V[] _rest1474) => {
{
V i_1480 = default;
i_1480 = ((V)(0D));
while (true) {
if (!(LtN(i_1480, 3D))) break;
Invoke(Invoke(Invoke(u_1479, "to", ((V)(120D)), NewObj(1).Put("fz", ((V)(0.8))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("body")), ((V)(1D))), "to", ((V)(200D)), NewObj(1).Put("fz", ((V)(0.2))).V, ((V)("io")));
PostInc(ref i_1480, 1D);
}
}
Invoke(u_1479, "to", ((V)(150D)), NewObj(1).Put("fz", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true));
return default;
}, 2, "belly", true)).V).Put("perry", NewObj(3).Put("part", Fn((V _self910, int _argc1482, V t_1488, V a_1489, V _a1486, V _a1487, V[] _rest1483) => {
Invoke(t_1488, "to", ((V)(200D)), NewObj(1).Put("tilt", ((V)((7D * ToNum(a_1489))))).V, ((V)("o")));
Call(jelly_925, V.Undef, t_1488, ((V)((6D * ToNum(a_1489)))), ((V)(3D)), ((V)(380D)), ((V)("tilt")));
return default;
}, 2, "part", true)).Put("side", Fn((V _self910, int _argc1490, V t_1496, V s_1497, V _a1494, V _a1495, V[] _rest1491) => {
Invoke(t_1496, "to", ((V)(260D)), NewObj(4).Put("tilt", ((V)(((-ToNum(s_1497)) * 15D)))).Put("x", ((V)(((-ToNum(s_1497)) * 1.5)))).Put("armL", ((V)(50D))).Put("armR", ((V)(50D))).V, ((V)("o")));
Call(jelly_925, V.Undef, t_1496, ((V)(((-ToNum(s_1497)) * 10D))), ((V)(4D)), ((V)(420D)), ((V)("tilt")));
Invoke(t_1496, "to", ((V)(260D)), NewObj(3).Put("x", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self910, int _argc1498, V t_1504, V s_1505, V _a1502, V _a1503, V[] _rest1499) => {
Invoke(t_1504, "to", ((V)(220D)), NewObj(1).Put("tilt", ((V)((ToNum(s_1505) * 10D)))).V, ((V)("o")));
Call(jelly_925, V.Undef, t_1504, ((V)((ToNum(s_1505) * 8D))), ((V)(4D)), ((V)(400D)), ((V)("tilt")));
Call(giggle_928, V.Undef, t_1504, ((V)(2D)));
return default;
}, 2, "foot", true)).V).Put("grana", NewObj(3).Put("part", Fn((V _self910, int _argc1506, V t_1512, V a_1513, V _a1510, V _a1511, V[] _rest1507) => {
Invoke(Invoke(Invoke(t_1512, "to", ((V)(120D)), NewObj(1).Put("crf", a_1513).V, ((V)("o"))), "e", ((V)("emit")), ((V)("arils")), ((V)("head")), ((V)(Round((1D + (3D * ToNum(a_1513))))))), "to", ((V)(400D)), NewObj(1).Put("crf", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("head", Fn((V _self910, int _argc1514, V t_1520, V s_1521, V _a1518, V _a1519, V[] _rest1515) => {
Invoke(Invoke(Invoke(t_1520, "to", ((V)(800D)), NewObj(2).Put("stw", ((V)(1D))).Put("crf", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("crf", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_1520, "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)(0.08))).Put("close", ((V)(0.5))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(4).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("cheekX", NewObj(1).Put("close", ((V)(0.6))).V).V).Put("mangie", NewObj(3).Put("part", Fn((V _self910, int _argc1522, V t_1528, V a_1529, V _a1526, V _a1527, V[] _rest1523) => {
Invoke(Invoke(t_1528, "to", ((V)(150D)), NewObj(2).Put("lf", a_1529).Put("stw", ((V)((0.4 * ToNum(a_1529))))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("lf", ((V)(0D))).Put("stw", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1530, V u_1536, V _a1533, V _a1534, V _a1535, V[] _rest1531) => {
return Invoke(Invoke(u_1536, "osc", ((V)(900D)), ((V)(3D)), NewObj(2).Put("lf", ((V)(0.9))).Put("tilt", ((V)(3D))).V, NewObj(2).Put("lf", ((V)(0.2))).Put("tilt", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("lf", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).Put("cheekX", NewObj(1).Put("blush", ((V)(0.9))).V).V).Put("razzy", NewObj(2).Put("part", Fn((V _self910, int _argc1537, V t_1543, V a_1544, V _a1541, V _a1542, V[] _rest1538) => {
Invoke(Invoke(Invoke(t_1543, "to", ((V)(120D)), NewObj(1).Put("jig", ((V)((1.3 * ToNum(a_1544))))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(1D))), "to", ((V)(700D)), NewObj(1).Put("jig", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "part", true)).Put("tick", Fn((V _self910, int _argc1545, V u_1551, V _a1548, V _a1549, V _a1550, V[] _rest1546) => {
return Invoke(Invoke(Invoke(u_1551, "to", ((V)(200D)), NewObj(1).Put("jig", ((V)(1.4))).V, ((V)("o"))), "wait", ((V)(500D))), "to", ((V)(400D)), NewObj(1).Put("jig", ((V)(0D))).V, ((V)("io")));
}, 1, "tick", true)).V).V;
RE_945 = NewObj(0).V;
Invoke(Get(Get(R_917, "FRUITLIB"), "KEYS"), "forEach", Fn((V _self910, int _argc1552, V k_1558, V _a1555, V _a1556, V _a1557, V[] _rest1553) => {
V F_1559 = default;
V part_1560 = default;
F_1559 = GetK(P_944, k_1558);
part_1560 = Get(F_1559, "part");
SetK(RE_945, k_1558, NewObj(9).Put("head", (Get(F_1559, "head") is var _t1569 && Truthy(_t1569) ? _t1569 : Fn((V _self910, int _argc1561, V t_1567, V s_1568, V _a1565, V _a1566, V[] _rest1562) => {
Call(part_1560, V.Undef, t_1567, ((V)(1D)));
Call(giggle_928, V.Undef, t_1567, ((V)(2D)));
return default;
}, 2, "", true))).Put("ear", Fn((V _self910, int _argc1570, V t_1576, V s_1577, V _a1574, V _a1575, V[] _rest1571) => {
Call(see_926, V.Undef, t_1576, ((V)("ear")), s_1577, ((V)(120D)));
Call((Get(F_1559, "ear") is var _t1586 && Truthy(_t1586) ? _t1586 : Fn((V _self910, int _argc1578, V u_1584, V s_1585, V _a1582, V _a1583, V[] _rest1579) => {
return Call(part_1560, V.Undef, u_1584, ((V)(0.7)));
}, 2, "", true)), V.Undef, t_1576, s_1577);
Call(unsee_927, V.Undef, t_1576);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self910, int _argc1587, V t_1593, V s_1594, V _a1591, V _a1592, V[] _rest1588) => {
return Call(nose_940, V.Undef, t_1593, (Get(F_1559, "nose") is var _t1602 && Truthy(_t1602) ? _t1602 : Fn((V _self910, int _argc1595, V u_1601, V _a1598, V _a1599, V _a1600, V[] _rest1596) => {
Call(sniff_929, V.Undef, u_1601, ((V)(2D)));
Call(tasteHeart_939, V.Undef, u_1601);
return default;
}, 1, "", true)));
}, 2, "nose", true)).Put("eye", Fn((V _self910, int _argc1603, V t_1609, V s_1610, V _a1607, V _a1608, V[] _rest1604) => {
Call(eyeRub_935, V.Undef, t_1609, s_1610);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self910, int _argc1611, V t_1617, V s_1618, V _a1615, V _a1616, V[] _rest1612) => {
Call(leanIn_932, V.Undef, t_1617, s_1618, Get(F_1559, "cheekX"));
if (Truthy(Get(F_1559, "cheekX"))) {
V z_1619 = default;
z_1619 = NewObj(0).V;
{
foreach (V _k1620 in ForInKeys(Get(F_1559, "cheekX"))) {
V p_1621 = default;
p_1621 = _k1620;
SetK(z_1619, p_1621, ((V)(0D)));
}
}
Invoke(t_1617, "to", ((V)(220D)), z_1619, ((V)("io")));
}
return default;
}, 2, "cheek", true)).Put("belly", (Get(F_1559, "belly") is var _t1638 && Truthy(_t1638) ? _t1638 : Fn((V _self910, int _argc1622, V t_1628, V s_1629, V _a1626, V _a1627, V[] _rest1623) => {
Call(tickle_938, V.Undef, t_1628, (Get(F_1559, "tick") is var _t1637 && Truthy(_t1637) ? _t1637 : Fn((V _self910, int _argc1630, V u_1636, V _a1633, V _a1634, V _a1635, V[] _rest1631) => {
return Call(part_1560, V.Undef, u_1636, ((V)(0.7)));
}, 1, "", true)));
return default;
}, 2, "", true))).Put("side", Fn((V _self910, int _argc1639, V t_1645, V s_1646, V _a1643, V _a1644, V[] _rest1640) => {
Call((Get(F_1559, "side") is var _t1655 && Truthy(_t1655) ? _t1655 : Fn((V _self910, int _argc1647, V u_1653, V s_1654, V _a1651, V _a1652, V[] _rest1648) => {
return Call(jelly_925, V.Undef, u_1653, ((V)(3D)), ((V)(3D)), ((V)(320D)), ((V)("bend")));
}, 2, "", true)), V.Undef, t_1645, s_1646);
Call(see_926, V.Undef, t_1645, ((V)("side")), s_1646, ((V)(200D)));
Call(unsee_927, V.Undef, t_1645, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", (Get(F_1559, "foot") is var _t1664 && Truthy(_t1664) ? _t1664 : Fn((V _self910, int _argc1656, V t_1662, V s_1663, V _a1660, V _a1661, V[] _rest1657) => {
Call(hop_937, V.Undef, t_1662, ((V)(6D)), Arr(Arr(((V)("emit")), GetK(JU_942, k_1558), ((V)("head")), ((V)(2D)))));
return default;
}, 2, "", true))).Put("tail", Fn((V _self910, int _argc1665, V t_1671, V s_1672, V _a1669, V _a1670, V[] _rest1666) => {
Call(part_1560, V.Undef, t_1671, ((V)(0.5)));
Call(lookBack_936, V.Undef, t_1671);
return default;
}, 2, "tail", true)).V);
return default;
}, 1, "", true));
BODY_946 = NewObj(20).Put("pina", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("crown"))).Put("head", ((V)("Crown"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("avo", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("leaf"))).Put("head", ((V)("Sprout leaves"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Pit"))).Put("tail", ((V)("Back"))).V).V).Put("berri", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("leaf"))).Put("head", ((V)("Leafy top"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Seeds"))).Put("tail", ((V)("Back"))).V).V).Put("lemmy", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _self910, int _argc1673, V s_1679, V _a1676, V _a1677, V _a1678, V[] _rest1674) => {
return ((V)((GtN(s_1679, 0D) ? "Right tip" : "Left tip")));
}, 1, "ear", true)).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("kiwi", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("fuzz"))).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Kiwi slice"))).Put("tail", ((V)("Back"))).V).V).Put("melo", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("rind corner"))).Put("head", ((V)("Top"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Seeds"))).Put("tail", ((V)("Rind (back)"))).V).V).Put("peachy", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("leaf"))).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("pitaya", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _self910, int _argc1680, V s_1686, V _a1683, V _a1684, V _a1685, V[] _rest1681) => {
return ((V)((GtN(s_1686, 0D) ? "Right wing" : "Left wing")));
}, 1, "ear", true)).Put("head", ((V)("Crown"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Bracts"))).Put("tail", ((V)("Back"))).V).V).Put("tutti", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _self910, int _argc1687, V s_1693, V _a1690, V _a1691, V _a1692, V[] _rest1688) => {
return ((V)((GtN(s_1693, 0D) ? "Right wing" : "Left wing")));
}, 1, "ear", true)).Put("head", ((V)("Fruit crown"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Basket"))).Put("tail", ((V)("Basket (back)"))).V).V).Put("nana", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _self910, int _argc1694, V s_1700, V _a1697, V _a1698, V _a1699, V[] _rest1695) => {
return ((V)((GtN(s_1700, 0D) ? "Stalk" : "Peel (top left)")));
}, 1, "ear", true)).Put("head", ((V)("Stalk"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("bing", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _self910, int _argc1701, V s_1707, V _a1704, V _a1705, V _a1706, V[] _rest1702) => {
return ((V)((GtN(s_1707, 0D) ? "Leaf" : "Top left")));
}, 1, "ear", true)).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("plummy", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _self910, int _argc1708, V s_1714, V _a1711, V _a1712, V _a1713, V[] _rest1709) => {
return ((V)((GtN(s_1714, 0D) ? "Leaf" : "Top left")));
}, 1, "ear", true)).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("clemmy", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("leaf"))).Put("head", ((V)("Leaves"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Peel"))).Put("tail", ((V)("Back"))).V).V).Put("appy", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _self910, int _argc1715, V s_1721, V _a1718, V _a1719, V _a1720, V[] _rest1716) => {
return ((V)((GtN(s_1721, 0D) ? "Leaf" : "Top left")));
}, 1, "ear", true)).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("blueby", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("crown"))).Put("head", ((V)("Star crown"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("coco", NewObj(3).Put("ear", ((V)(0.6))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("ear", ((V)("top"))).Put("head", ((V)("Coconut eyes"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Hairy tummy"))).Put("foot", ((V)("bottom"))).Put("tail", ((V)("Back"))).V).V).Put("perry", NewObj(3).Put("ear", ((V)(0.6))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("ear", ((V)("neck"))).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("foot", ((V)("bottom"))).Put("tail", ((V)("Back"))).V).V).Put("grana", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("crown"))).Put("head", ((V)("Crown"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("mangie", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", Fn((V _self910, int _argc1722, V s_1728, V _a1725, V _a1726, V _a1727, V[] _rest1723) => {
return ((V)((GtN(s_1728, 0D) ? "Leaf" : "Top left")));
}, 1, "ear", true)).Put("head", ((V)("Stem"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Tummy"))).Put("tail", ((V)("Back"))).V).V).Put("razzy", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(5).Put("ear", ((V)("leafy top"))).Put("head", ((V)("Leafy top"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Beads"))).Put("tail", ((V)("Back"))).V).V).V;
he_947 = NewObj(11).Put("pina", ((V)(1D))).Put("avo", ((V)(1D))).Put("berri", ((V)(1D))).Put("lemmy", ((V)(1D))).Put("kiwi", ((V)(1D))).Put("melo", ((V)(1D))).Put("pitaya", ((V)(1D))).Put("plummy", ((V)(1D))).Put("coco", ((V)(1D))).Put("perry", ((V)(1D))).Put("grana", ((V)(1D))).V;
pr_948 = Fn((V _self910, int _argc1729, V k_1735, V _a1732, V _a1733, V _a1734, V[] _rest1730) => {
return (Truthy(GetK(he_947, k_1735)) ? Arr(((V)("he")), ((V)("his")), ((V)("him"))) : Arr(((V)("she")), ((V)("her")), ((V)("her"))));
}, 1, "", true);
T0_949 = Fn((V _self910, int _argc1736, V k_1742, V _a1739, V _a1740, V _a1741, V[] _rest1737) => {
V a_1743 = default;
V b_1744 = default;
V A_1745 = default;
{ V _t1746 = Call(pr_948, V.Undef, k_1742);
{ V _t1747 = ListOf(_t1746);
{ V _t1748 = GetIdx(_t1747, 0D);
a_1743 = _t1748; }
{ V _t1749 = GetIdx(_t1747, 1D);
b_1744 = _t1749; }
} }
A_1745 = Add(Invoke(GetIdx(a_1743, 0D), "toUpperCase"), Invoke(a_1743, "slice", ((V)(1D))));
return NewObj(6).Put("nose", ((V)("Sniffs your finger and licks it: a heart."))).Put("eye", ((V)(string.Concat("Blinks hard and rubs ", ToStr(b_1744), " eye.")))).Put("cheek", ((V)("Leans into your finger, eyes closed."))).Put("side", ((V)("Wobbles away from the poke and looks at the spot."))).Put("A", A_1745).Put("b", b_1744).V;
return default;
}, 1, "", true);
TX_950 = NewObj(20).Put("pina", NewObj(6).Put("head", ((V)("His crown pops open, he giggles."))).Put("ear", ((V)("His crown leaves flare at the touch."))).Put("belly", ((V)("Ticklish tummy: giggles while his crown whirls."))).Put("side", ((V)("Sways away like a palm tree and back, crown whirling."))).Put("foot", ((V)("A hop with a squirt of pineapple juice."))).Put("tail", ((V)("His crown flares, he looks back."))).V).Put("avo", NewObj(5).Put("head", ((V)("His sprout leaves flap and spin like a propeller, he giggles."))).Put("ear", ((V)("His pit pops out a little and wobbles back in."))).Put("belly", ((V)("Ticklish pit: it rolls round in its socket while he giggles."))).Put("foot", ((V)("A hop - a bit of guac flies."))).Put("tail", ((V)("His pit bobs, he looks back."))).V).Put("berri", NewObj(5).Put("head", ((V)("His leaves fly up and his stem boings, a drop of juice, a giggle."))).Put("ear", ((V)("His leafy top flaps at the touch."))).Put("belly", ((V)("Ticklish seeds: giggles while his stem boings."))).Put("foot", ((V)("A juicy hop."))).Put("tail", ((V)("His leaves flap, he looks back."))).V).Put("lemmy", NewObj(6).Put("head", ((V)("Puckers up sour, then grins."))).Put("ear", ((V)("A sour little pucker at the touch."))).Put("nose", ((V)("Sniffs your finger - so sour! - shivers, then grins."))).Put("belly", ((V)("Ticklish: a zesty shimmy and a spray of juice."))).Put("foot", ((V)("A hop with a squirt of lemon juice."))).Put("tail", ((V)("Puckers, looks back."))).V).Put("kiwi", NewObj(5).Put("head", ((V)("Bobs his head like a little bird, his stem bobs, a giggle."))).Put("ear", ((V)("His fuzz bristles at the touch."))).Put("belly", ((V)("Ticklish slice: giggles, fuzz puffing up."))).Put("foot", ((V)("A hop - kiwi juice drips."))).Put("tail", ((V)("His fuzz ruffles, he looks back."))).V).Put("melo", NewObj(5).Put("head", ((V)("All his seeds jiggle, he giggles."))).Put("ear", ((V)("His seeds jiggle at the touch."))).Put("belly", ((V)("Ticklish seeds: giggles while they jiggle."))).Put("foot", ((V)("A hop - his seeds jump and juice splashes."))).Put("tail", ((V)("His seeds wobble, he looks back."))).V).Put("peachy", NewObj(6).Put("head", ((V)("Blushes pink and her leaf flaps, she giggles."))).Put("ear", ((V)("Blushes at the touch, her leaf fluttering."))).Put("cheek", ((V)("Leans her fuzzy cheek into your finger and blushes."))).Put("belly", ((V)("Ticklish: giggles and blushes all over."))).Put("foot", ((V)("A gentle hop - a drop of peach juice."))).Put("tail", ((V)("Blushes, looks back."))).V).Put("pitaya", NewObj(5).Put("head", ((V)("His crown flares and he sparkles, a giggle."))).Put("ear", Fn((V _self910, int _argc1750, V s_1756, V _a1753, V _a1754, V _a1755, V[] _rest1751) => {
return ((V)(string.Concat("His ", (GtN(s_1756, 0D) ? "right" : "left"), " wing spreads and flaps.")));
}, 1, "ear", true)).Put("belly", ((V)("Ticklish bracts: giggles, wings flapping."))).Put("foot", ((V)("A hop - dragonfruit juice drips."))).Put("tail", ((V)("His bracts flare, he looks back."))).V).Put("tutti", NewObj(5).Put("head", ((V)("Her fruit crown bounces and her wings flutter, a giggle."))).Put("ear", Fn((V _self910, int _argc1757, V s_1763, V _a1760, V _a1761, V _a1762, V[] _rest1758) => {
return ((V)(string.Concat("Her ", (GtN(s_1763, 0D) ? "right" : "left"), " wing flutters fast, fairy dust falls.")));
}, 1, "ear", true)).Put("belly", Fn((V _self910, int _argc1764, V s_1770, V _a1767, V _a1768, V _a1769, V[] _rest1765) => {
return ((V)(string.Concat("Ticklish basket: giggles - her ", (LtN(s_1770, 0D) ? "cherry" : "pear"), " hops out and back in.")));
}, 1, "belly", true)).Put("foot", ((V)("A hop - fairy juice drips."))).Put("tail", ((V)("Her crown bounces, she looks back."))).V).Put("nana", NewObj(6).Put("head", ((V)("Her curve wobbles like jelly, she giggles."))).Put("ear", Fn((V _self910, int _argc1771, V s_1777, V _a1774, V _a1775, V _a1776, V[] _rest1772) => {
return ((V)((GtN(s_1777, 0D) ? "Her stalk gets a tap - her curve wobbles." : "Her peel gets a tap - her curve wobbles.")));
}, 1, "ear", true)).Put("belly", ((V)("Ticklish: her curve flips side to side while she giggles."))).Put("side", ((V)("Bends away from the poke like a reed and springs back."))).Put("foot", ((V)("A hop - a drop of banana."))).Put("tail", ((V)("Her curve wobbles, she looks back."))).V).Put("bing", NewObj(5).Put("head", ((V)("Her stem spins right round, she giggles."))).Put("ear", Fn((V _self910, int _argc1778, V s_1784, V _a1781, V _a1782, V _a1783, V[] _rest1779) => {
return ((V)((GtN(s_1784, 0D) ? "Her leaf flutters and the stem wobbles." : "Her stem wobbles at the touch.")));
}, 1, "ear", true)).Put("belly", ((V)("Ticklish: giggles while her stem sways."))).Put("foot", ((V)("A bouncy hop - cherry juice drips."))).Put("tail", ((V)("Her stem wobbles, she looks back."))).V).Put("plummy", NewObj(6).Put("head", ((V)("His stem spins right round, he giggles."))).Put("ear", Fn((V _self910, int _argc1785, V s_1791, V _a1788, V _a1789, V _a1790, V[] _rest1786) => {
return ((V)((GtN(s_1791, 0D) ? "His leaf flutters at the touch." : "His stem wobbles at the touch.")));
}, 1, "ear", true)).Put("cheek", ((V)("Leans into your finger and blushes."))).Put("belly", ((V)("Ticklish: giggles - the tickle rubs a shiny spot in his dusty bloom."))).Put("foot", ((V)("Rises on tiptoe and does a little pirouette, giggling."))).Put("tail", ((V)("His leaf flutters, he looks back."))).V).Put("clemmy", NewObj(5).Put("head", ((V)("Her leaves twirl round and she spritzes zest, a giggle."))).Put("ear", ((V)("Her leaf flaps and a little zest sprays."))).Put("belly", ((V)("Ticklish peel: giggles, spritzing zest."))).Put("foot", ((V)("A zippy hop - zest sprays."))).Put("tail", ((V)("A spritz of zest, she looks back."))).V).Put("appy", NewObj(5).Put("head", ((V)("A crisp little bounce with a sparkle, she giggles."))).Put("ear", Fn((V _self910, int _argc1792, V s_1798, V _a1795, V _a1796, V _a1797, V[] _rest1793) => {
return ((V)((GtN(s_1798, 0D) ? "Her leaf flutters at the touch." : "Looks up at the touch, her leaf flutters.")));
}, 1, "ear", true)).Put("belly", ((V)("Ticklish: giggles, leaf fluttering."))).Put("foot", ((V)("A crisp hop - apple juice drips."))).Put("tail", ((V)("Her leaf flutters, she looks back."))).V).Put("blueby", NewObj(6).Put("head", ((V)("Her star crown flares, she giggles."))).Put("ear", ((V)("Her crown flares at the touch."))).Put("belly", ((V)("Ticklish tummy: rocks and rolls with giggles."))).Put("side", Fn((V _self910, int _argc1799, V s_1805, V _a1802, V _a1803, V _a1804, V[] _rest1800) => {
return ((V)("Rolls away from the poke and rocks back onto her feet."));
}, 1, "side", true)).Put("foot", Fn((V _self910, int _argc1806, V s_1812, V _a1809, V _a1810, V _a1811, V[] _rest1807) => {
return ((V)(string.Concat("Rolls right over ", (LtN(s_1812, 0D) ? "to the right" : "to the left"), " and back up, giggling.")));
}, 1, "foot", true)).Put("tail", ((V)("Her crown flares, she looks back."))).V).Put("coco", NewObj(5).Put("head", ((V)("Knock! Hollow - he listens, then grins."))).Put("ear", ((V)("His hair stands up at the touch."))).Put("belly", ((V)("Ticklish hairy tummy: knock, knock, knock - giggles."))).Put("foot", Fn((V _self910, int _argc1813, V s_1819, V _a1816, V _a1817, V _a1818, V[] _rest1814) => {
return ((V)(string.Concat("Rolls right over ", (LtN(s_1819, 0D) ? "to the right" : "to the left"), " and back, giggling.")));
}, 1, "foot", true)).Put("tail", ((V)("His hair bristles, he looks back."))).V).Put("perry", NewObj(6).Put("head", ((V)("Wobbles on his round bottom, he giggles."))).Put("ear", ((V)("Wobbles at the touch on his neck."))).Put("belly", ((V)("Ticklish tummy: giggles, wobbling."))).Put("side", ((V)("Tips far over away from the poke and wobbles back like a roly-poly."))).Put("foot", ((V)("Tips over on his round bottom and wobbles back up, giggling."))).Put("tail", ((V)("A wobble, he looks back."))).V).Put("grana", NewObj(6).Put("head", ((V)("His crown spins and flares - he lifts his chin proudly."))).Put("ear", ((V)("His crown flares and a few ruby seeds fall."))).Put("cheek", ((V)("Leans into your finger with royal dignity."))).Put("belly", ((V)("Ticklish: giggles, ruby seeds falling."))).Put("foot", ((V)("A royal hop - ruby seeds bounce."))).Put("tail", ((V)("His crown flares, he looks back."))).V).Put("mangie", NewObj(6).Put("head", ((V)("Her leaf flicks like a hair toss, she giggles."))).Put("ear", Fn((V _self910, int _argc1820, V s_1826, V _a1823, V _a1824, V _a1825, V[] _rest1821) => {
return ((V)((GtN(s_1826, 0D) ? "Her leaf flicks at the touch." : "Her leaf flicks from the touch.")));
}, 1, "ear", true)).Put("cheek", ((V)("Leans into your finger, blushing like a sunset."))).Put("belly", ((V)("Ticklish: giggles, leaf flicking."))).Put("foot", ((V)("A sunny hop - mango juice drips."))).Put("tail", ((V)("Her leaf flicks, she looks back."))).V).Put("razzy", NewObj(5).Put("head", ((V)("Every bead on her jiggles and sparkles, she giggles."))).Put("ear", ((V)("Her beads jiggle at the touch."))).Put("belly", ((V)("Ticklish beads: giggles, wobbling all over."))).Put("foot", ((V)("A hop - raspberry juice drips."))).Put("tail", ((V)("Her beads jiggle, she looks back."))).V).V;
TXT_951 = NewObj(0).V;
Invoke(Get(Get(R_917, "FRUITLIB"), "KEYS"), "forEach", Fn((V _self910, int _argc1827, V k_1833, V _a1830, V _a1831, V _a1832, V[] _rest1828) => {
V d_1834 = default;
d_1834 = Call(T0_949, V.Undef, k_1833);
SetK(TXT_951, k_1833, Object_assign(NewObj(4).Put("nose", Get(d_1834, "nose")).Put("eye", Get(d_1834, "eye")).Put("cheek", Get(d_1834, "cheek")).Put("side", Get(d_1834, "side")).V, GetK(TX_950, k_1833)));
return default;
}, 1, "", true));
Call(build_934, V.Undef, RE_945, TXT_951, BODY_946);
return default;
}, 0, "boot", false)), V.Undef);
Call(Named(boot_1861 => Fn((V _self1835, int _argc1836, V _a1838, V _a1839, V _a1840, V _a1841, V[] _rest1837) => {
V R_1842 = default;
V hand_1843 = default;
V both_1844 = default;
V o_1845 = default;
V NOHANDS_1846 = default;
V jump_1847 = default;
V swing_1848 = default;
V jelly_1849 = default;
V shake_1850 = default;
V EAR_1851 = default;
V sniffF_1852 = default;
V lipLick_1853 = default;
V hearts_1854 = default;
V pat_1855 = default;
V buildAll_1856 = default;
V JU_1857 = default;
V hop_1858 = default;
V yay_1859 = default;
V C_1860 = default;
if (_self1835.IsNullish) _self1835 = GlobalV;
R_1842 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_1842)) || !(Truthy(Get(R_1842, "EATKIT")))) || !(Truthy(Get(R_1842, "fruitV")))) || !(Truthy(Get(R_1842, "EATLIB"))))) {
Call(G("setTimeout"), V.Undef, boot_1861.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_1842, "fruitEatV"))) {
return default;
}
Set(R_1842, "fruitEatV", ((V)(1D)));
{ V _t1862 = Get(R_1842, "PETLIB");
if (_t1862.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1862));
{ V _t1863 = Get(_t1862, "hand");
hand_1843 = _t1863; }
{ V _t1864 = Get(_t1862, "both");
both_1844 = _t1864; }
{ V _t1865 = Get(_t1862, "o");
o_1845 = _t1865; }
{ V _t1866 = Get(_t1862, "NOHANDS");
NOHANDS_1846 = _t1866; }
{ V _t1867 = Get(_t1862, "jump");
jump_1847 = _t1867; }
{ V _t1868 = Get(_t1862, "swing");
swing_1848 = _t1868; }
{ V _t1869 = Get(_t1862, "jelly");
jelly_1849 = _t1869; }
{ V _t1870 = Get(_t1862, "shake");
shake_1850 = _t1870; } }
{ V _t1871 = Get(R_1842, "EATKIT");
if (_t1871.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t1871));
{ V _t1872 = Get(_t1871, "EAR");
EAR_1851 = _t1872; }
{ V _t1873 = Get(_t1871, "sniffF");
sniffF_1852 = _t1873; }
{ V _t1874 = Get(_t1871, "lipLick");
lipLick_1853 = _t1874; }
{ V _t1875 = Get(_t1871, "hearts");
hearts_1854 = _t1875; }
{ V _t1876 = Get(_t1871, "pat");
pat_1855 = _t1876; }
{ V _t1877 = Get(_t1871, "buildAll");
buildAll_1856 = _t1877; } }
JU_1857 = Get(Get(R_1842, "FRUITLIB"), "JUICE");
Invoke(Get(Get(R_1842, "FRUITLIB"), "KEYS"), "forEach", Fn((V _self1835, int _argc1878, V k_1884, V _a1881, V _a1882, V _a1883, V[] _rest1879) => {
if (GetK(EAR_1851, k_1884).IsNullish) {
SetK(EAR_1851, k_1884, ((V)(0.6)));
}
return default;
}, 1, "", true));
hop_1858 = Fn((V _self1835, int _argc1885, V t_1891, V h_1892, V x_1893, V _a1890, V[] _rest1886) => {
return Call(jump_1847, V.Undef, t_1891, Call(o_1845, V.Undef, NewObj(5).Put("h", (h_1892 is var _t1894 && Truthy(_t1894) ? _t1894 : ((V)(6D)))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).V, (x_1893 is var _t1895 && Truthy(_t1895) ? _t1895 : NewObj(0).V)));
}, 3, "", true);
yay_1859 = Fn((V _self1835, int _argc1896, V t_1902, V _a1899, V _a1900, V _a1901, V[] _rest1897) => {
return Invoke(t_1902, "to", ((V)(160D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
}, 1, "", true);
C_1860 = NewObj(20).Put("pina", NewObj(8).Put("chewMs", ((V)(125D))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.8))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("A happy hula wiggle first, big tropical bites, his crown pops open when he likes it."))).Put("pre", Fn((V _self1835, int _argc1903, V t_1909, V _a1906, V _a1907, V _a1908, V[] _rest1904) => {
return Call(swing_1848, V.Undef, t_1909, ((V)(700D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(4D))).Put("x", ((V)(1D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc1910, V t_1916, V _a1913, V _a1914, V _a1915, V[] _rest1911) => {
return Call(lipLick_1853, V.Undef, t_1916);
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc1917, V t_1923, V _a1920, V _a1921, V _a1922, V[] _rest1918) => {
Call(yay_1859, V.Undef, t_1923);
Invoke(Invoke(Invoke(t_1923, "to", ((V)(140D)), NewObj(1).Put("crw", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("pinjuice")), ((V)("head")), ((V)(2D))), "to", ((V)(360D)), NewObj(1).Put("crw", ((V)(0D))).V, ((V)("io")));
Call(swing_1848, V.Undef, t_1923, ((V)(900D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(5D))).Put("x", ((V)(1.5))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("avo", NewObj(9).Put("savor", ((V)(0.5))).Put("chewMs", ((V)(140D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Calm, buttery bites, pats his pit when he is full, his leaves flap when he likes it."))).Put("pre", Fn((V _self1835, int _argc1924, V t_1930, V _a1927, V _a1928, V _a1929, V[] _rest1925) => {
return Call(sniffF_1852, V.Undef, t_1930, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc1931, V t_1937, V _a1934, V _a1935, V _a1936, V[] _rest1932) => {
Invoke(Invoke(Invoke(Invoke(t_1937, "to", ((V)(300D)), Call(o_1845, V.Undef, Call(both_1844, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(2).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("prw", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("prw", ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), Call(o_1845, V.Undef, NOHANDS_1846, NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc1938, V t_1944, V _a1941, V _a1942, V _a1943, V[] _rest1939) => {
Call(yay_1859, V.Undef, t_1944);
Invoke(Invoke(t_1944, "to", ((V)(200D)), NewObj(2).Put("lfl", ((V)(0.9))).Put("pp", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(400D)), NewObj(2).Put("lfl", ((V)(0D))).Put("pp", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("berri", NewObj(8).Put("chewMs", ((V)(120D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Quick sweet bites, a happy squirt of juice, his leaves flap and his stem boings when he likes it."))).Put("pre", Fn((V _self1835, int _argc1945, V t_1951, V _a1948, V _a1949, V _a1950, V[] _rest1946) => {
return Call(sniffF_1852, V.Undef, t_1951, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc1952, V t_1958, V _a1955, V _a1956, V _a1957, V[] _rest1953) => {
return Call(lipLick_1853, V.Undef, t_1958);
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc1959, V t_1965, V _a1962, V _a1963, V _a1964, V[] _rest1960) => {
Call(yay_1859, V.Undef, t_1965);
Invoke(Invoke(Invoke(t_1965, "to", ((V)(140D)), NewObj(2).Put("lfl", ((V)(1D))).Put("stw", ((V)(0.8))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("juice")), ((V)("head")), ((V)(2D))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0D))).V, ((V)("io")));
Call(jelly_1849, V.Undef, t_1965, ((V)(0.6)), ((V)(3D)), ((V)(240D)), ((V)("stw")));
return default;
}, 1, "yum", true)).V).Put("lemmy", NewObj(9).Put("chewMs", ((V)(110D))).Put("chewN", ((V)(0.9))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Sniffs it suspiciously, quick zesty bites - a sour pucker shiver - then he grins and flaps his leaf."))).Put("pre", Fn((V _self1835, int _argc1966, V t_1972, V _a1969, V _a1970, V _a1971, V[] _rest1967) => {
Call(sniffF_1852, V.Undef, t_1972, ((V)(1D)));
Invoke(Invoke(t_1972, "to", ((V)(120D)), NewObj(2).Put("close", ((V)(0.6))).Put("mw", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc1973, V t_1979, V _a1976, V _a1977, V _a1978, V[] _rest1974) => {
Invoke(t_1979, "to", ((V)(110D)), NewObj(2).Put("close", ((V)(0.85))).Put("mw", ((V)(0.35))).V, ((V)("o")));
Call(shake_1850, V.Undef, t_1979, NewObj(4).Put("P", ((V)(70D))).Put("head", ((V)(0.14))).Put("roll", ((V)(2D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.6)), ((V)(0.3)))).V);
Invoke(t_1979, "to", ((V)(200D)), NewObj(2).Put("close", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc1980, V t_1986, V _a1983, V _a1984, V _a1985, V[] _rest1981) => {
Call(yay_1859, V.Undef, t_1986);
Invoke(Invoke(Invoke(t_1986, "to", ((V)(200D)), NewObj(1).Put("lfl", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("lfl", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("lemjuice")), ((V)("head")), ((V)(2D)));
return default;
}, 1, "yum", true)).V).Put("kiwi", NewObj(9).Put("chewMs", ((V)(100D))).Put("chewN", ((V)(1.2))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Pecks at it like a little bird - lots of quick small bites - and fluffs his fuzz when he likes it."))).Put("pre", Fn((V _self1835, int _argc1987, V t_1993, V _a1990, V _a1991, V _a1992, V[] _rest1988) => {
{
V i_1994 = default;
i_1994 = ((V)(0D));
while (true) {
if (!(LtN(i_1994, 2D))) break;
Invoke(Invoke(t_1993, "to", ((V)(130D)), NewObj(1).Put("pitch", ((V)((-0.12)))).V, ((V)("o"))), "to", ((V)(130D)), NewObj(1).Put("pitch", ((V)(0D))).V, ((V)("i")));
PostInc(ref i_1994, 1D);
}
}
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc1996, V t_2002, V _a1999, V _a2000, V _a2001, V[] _rest1997) => {
return Invoke(Invoke(t_2002, "to", ((V)(200D)), NewObj(1).Put("fzz", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("fzz", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2003, V t_2009, V _a2006, V _a2007, V _a2008, V[] _rest2004) => {
Call(yay_1859, V.Undef, t_2009);
Invoke(Invoke(Invoke(t_2009, "to", ((V)(200D)), NewObj(1).Put("fzz", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("kiwifuzz")), ((V)("head")), ((V)(2D))), "to", ((V)(400D)), NewObj(1).Put("fzz", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("melo", NewObj(9).Put("savor", ((V)(0.4))).Put("chewMs", ((V)(135D))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.85))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Big juicy summer bites, spits a seed after, his seeds jiggle when he likes it."))).Put("pre", Fn((V _self1835, int _argc2010, V t_2016, V _a2013, V _a2014, V _a2015, V[] _rest2011) => {
return Call(sniffF_1852, V.Undef, t_2016, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2017, V t_2023, V _a2020, V _a2021, V _a2022, V[] _rest2018) => {
Invoke(Invoke(Invoke(Invoke(t_2023, "to", ((V)(250D)), NewObj(1).Put("puff", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(80D)), NewObj(3).Put("puff", ((V)((-0.2)))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth")), ((V)(1D))), "to", ((V)(200D)), NewObj(3).Put("puff", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2024, V t_2030, V _a2027, V _a2028, V _a2029, V[] _rest2025) => {
Call(yay_1859, V.Undef, t_2030);
Invoke(Invoke(Invoke(t_2030, "to", ((V)(150D)), NewObj(1).Put("sdj", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("melojuice")), ((V)("head")), ((V)(2D))), "to", ((V)(500D)), NewObj(1).Put("sdj", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("peachy", NewObj(10).Put("savor", ((V)(0.7))).Put("chewMs", ((V)(150D))).Put("chewN", ((V)(1D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Dainty little bites with her eyes closed, blushing - her leaf whirls when she likes it."))).Put("pre", Fn((V _self1835, int _argc2031, V t_2037, V _a2034, V _a2035, V _a2036, V[] _rest2032) => {
return Invoke(t_2037, "to", ((V)(260D)), NewObj(1).Put("blush", ((V)(0.6))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2038, V t_2044, V _a2041, V _a2042, V _a2043, V[] _rest2039) => {
return Invoke(Invoke(Invoke(t_2044, "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0.6))).Put("smile", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(250D)), NewObj(2).Put("close", ((V)(0D))).Put("blush", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2045, V t_2051, V _a2048, V _a2049, V _a2050, V[] _rest2046) => {
Call(yay_1859, V.Undef, t_2051);
Invoke(Invoke(Invoke(t_2051, "to", ((V)(700D)), NewObj(2).Put("lsp", ((V)(1D))).Put("blush", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("lsp", ((V)(0D))).V, ((V)("l"))), "to", ((V)(300D)), NewObj(1).Put("blush", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("pitaya", NewObj(8).Put("chewMs", ((V)(115D))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.9))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Fierce dragon chomps, bracts bristling, then his wings flap and he sparkles when he likes it."))).Put("pre", Fn((V _self1835, int _argc2052, V t_2058, V _a2055, V _a2056, V _a2057, V[] _rest2053) => {
return Invoke(Invoke(t_2058, "to", ((V)(200D)), NewObj(2).Put("brf", ((V)(0.6))).Put("wsp", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("brf", ((V)(0D))).Put("wsp", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2059, V t_2065, V _a2062, V _a2063, V _a2064, V[] _rest2060) => {
return Call(lipLick_1853, V.Undef, t_2065, (true ? V.True : V.False));
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2066, V t_2072, V _a2069, V _a2070, V _a2071, V[] _rest2067) => {
Call(yay_1859, V.Undef, t_2072);
Invoke(Invoke(Invoke(t_2072, "to", ((V)(200D)), NewObj(3).Put("wsp", ((V)(1D))).Put("wfl", ((V)(1.3))).Put("spk", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "to", ((V)(400D)), NewObj(3).Put("wsp", ((V)(0D))).Put("wfl", ((V)(0D))).Put("spk", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("tutti", NewObj(9).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(140D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Flutters up to it, dainty fairy bites, her crown bounces and fairy dust falls when she likes it."))).Put("pre", Fn((V _self1835, int _argc2073, V t_2079, V _a2076, V _a2077, V _a2078, V[] _rest2074) => {
return Invoke(Invoke(t_2079, "to", ((V)(260D)), NewObj(2).Put("wfl", ((V)(1D))).Put("lift", ((V)(2D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(2).Put("wfl", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2080, V t_2086, V _a2083, V _a2084, V _a2085, V[] _rest2081) => {
return Call(lipLick_1853, V.Undef, t_2086);
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2087, V t_2093, V _a2090, V _a2091, V _a2092, V[] _rest2088) => {
Call(yay_1859, V.Undef, t_2093);
Invoke(Invoke(Invoke(t_2093, "to", ((V)(150D)), NewObj(2).Put("cb", ((V)(1D))).Put("wfl", ((V)(1.2))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("fairydust")), ((V)("head")), ((V)(3D))), "to", ((V)(400D)), NewObj(2).Put("cb", ((V)(0D))).Put("wfl", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("nana", NewObj(8).Put("chewMs", ((V)(130D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Curls round the food to look at it, happy bites, and her curve wiggles when she likes it."))).Put("pre", Fn((V _self1835, int _argc2094, V t_2100, V _a2097, V _a2098, V _a2099, V[] _rest2095) => {
return Invoke(Invoke(t_2100, "to", ((V)(320D)), NewObj(2).Put("cv", ((V)(0.7))).Put("pitch", ((V)((-0.1)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("cv", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2101, V t_2107, V _a2104, V _a2105, V _a2106, V[] _rest2102) => {
return Call(lipLick_1853, V.Undef, t_2107);
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2108, V t_2114, V _a2111, V _a2112, V _a2113, V[] _rest2109) => {
Call(yay_1859, V.Undef, t_2114);
Invoke(Invoke(t_2114, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("cv", ((V)(0.7))).V, NewObj(1).Put("cv", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("cv", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("bing", NewObj(8).Put("chewMs", ((V)(115D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.65))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Bouncy little bites, a squirt of cherry juice, her stem twirls when she likes it."))).Put("pre", Fn((V _self1835, int _argc2115, V t_2121, V _a2118, V _a2119, V _a2120, V[] _rest2116) => {
return Call(sniffF_1852, V.Undef, t_2121, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2122, V t_2128, V _a2125, V _a2126, V _a2127, V[] _rest2123) => {
return Call(lipLick_1853, V.Undef, t_2128);
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2129, V t_2135, V _a2132, V _a2133, V _a2134, V[] _rest2130) => {
Call(yay_1859, V.Undef, t_2135);
Invoke(Invoke(Invoke(t_2135, "to", ((V)(600D)), NewObj(2).Put("stw", ((V)(1D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("stw", ((V)((-1D)))).V, ((V)("l"))), "to", ((V)(400D)), NewObj(2).Put("stw", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(hop_1858, V.Undef, t_2135, ((V)(5D)));
return default;
}, 1, "yum", true)).V).Put("plummy", NewObj(9).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(135D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Dainty ballet bites with his eyes closed, then a twirl on tiptoe when he likes it."))).Put("pre", Fn((V _self1835, int _argc2136, V t_2142, V _a2139, V _a2140, V _a2141, V[] _rest2137) => {
return Call(sniffF_1852, V.Undef, t_2142, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2143, V t_2149, V _a2146, V _a2147, V _a2148, V[] _rest2144) => {
return Call(lipLick_1853, V.Undef, t_2149);
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2150, V t_2156, V _a2153, V _a2154, V _a2155, V[] _rest2151) => {
Call(yay_1859, V.Undef, t_2156);
Invoke(Invoke(Invoke(Invoke(t_2156, "to", ((V)(260D)), NewObj(3).Put("lift", ((V)(1.5))).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).V, ((V)("io"))), "to", ((V)(750D)), NewObj(2).Put("spin", ((V)(360D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "to", ((V)(260D)), NewObj(4).Put("lift", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("clemmy", NewObj(9).Put("chewMs", ((V)(105D))).Put("chewN", ((V)(1.1))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.65))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Zippy quick bites, a spritz of zest after every few, a spin when she likes it."))).Put("pre", Fn((V _self1835, int _argc2157, V t_2163, V _a2160, V _a2161, V _a2162, V[] _rest2158) => {
return Call(sniffF_1852, V.Undef, t_2163, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2164, V t_2170, V _a2167, V _a2168, V _a2169, V[] _rest2165) => {
return Invoke(t_2170, "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(3D)));
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2171, V t_2177, V _a2174, V _a2175, V _a2176, V[] _rest2172) => {
Call(yay_1859, V.Undef, t_2177);
Invoke(Invoke(Invoke(Invoke(t_2177, "to", ((V)(600D)), NewObj(2).Put("spin", ((V)(360D))).Put("lf", ((V)(1D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l"))), "e", ((V)("emit")), ((V)("zest")), ((V)("head")), ((V)(4D))), "to", ((V)(200D)), NewObj(1).Put("lf", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("appy", NewObj(8).Put("chewMs", ((V)(120D))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Crisp crunchy bites, wipes her mouth neatly, a shiny sparkle when she likes it."))).Put("pre", Fn((V _self1835, int _argc2178, V t_2184, V _a2181, V _a2182, V _a2183, V[] _rest2179) => {
return Call(sniffF_1852, V.Undef, t_2184, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2185, V t_2191, V _a2188, V _a2189, V _a2190, V[] _rest2186) => {
Invoke(Invoke(Invoke(t_2191, "to", ((V)(260D)), Call(o_1845, V.Undef, Call(hand_1843, V.Undef, ((V)(1D)), ((V)(10D)), ((V)((-14D)))), NewObj(1).Put("armR", ((V)(30D))).V), ((V)("io"))), "to", ((V)(200D)), NewObj(1).Put("hRx", ((V)((-14D)))).V, ((V)("io"))), "to", ((V)(260D)), Call(o_1845, V.Undef, NOHANDS_1846, NewObj(1).Put("armR", ((V)(0D))).V), ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2192, V t_2198, V _a2195, V _a2196, V _a2197, V[] _rest2193) => {
Call(yay_1859, V.Undef, t_2198);
Invoke(Invoke(Invoke(t_2198, "to", ((V)(150D)), NewObj(2).Put("lf", ((V)(1D))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(300D)), NewObj(2).Put("lf", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("blueby", NewObj(8).Put("chewMs", ((V)(120D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Rolls up to it, small round bites, rocks and rolls happily when she likes it."))).Put("pre", Fn((V _self1835, int _argc2199, V t_2205, V _a2202, V _a2203, V _a2204, V[] _rest2200) => {
return Invoke(Invoke(t_2205, "to", ((V)(400D)), NewObj(2).Put("rl", ((V)(20D))).Put("x", ((V)(3D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2206, V t_2212, V _a2209, V _a2210, V _a2211, V[] _rest2207) => {
return Call(lipLick_1853, V.Undef, t_2212);
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2213, V t_2219, V _a2216, V _a2217, V _a2218, V[] _rest2214) => {
Call(yay_1859, V.Undef, t_2219);
Invoke(Invoke(Invoke(Invoke(Invoke(t_2219, "to", ((V)(350D)), NewObj(2).Put("rl", ((V)((-24D)))).Put("x", ((V)((-3D)))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(2).Put("rl", ((V)(24D))).Put("x", ((V)(3D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("rl", ((V)(0D))).Put("x", ((V)(0D))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("coco", NewObj(9).Put("savor", ((V)(0.5))).Put("chewMs", ((V)(145D))).Put("crumbs", ((V)(2D))).Put("open", ((V)(0.8))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Chill, slow island bites, knocks on his belly when he is full, his hair fluffs when he likes it."))).Put("pre", Fn((V _self1835, int _argc2220, V t_2226, V _a2223, V _a2224, V _a2225, V[] _rest2221) => {
return Call(sniffF_1852, V.Undef, t_2226, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2227, V t_2233, V _a2230, V _a2231, V _a2232, V[] _rest2228) => {
Invoke(Invoke(Invoke(Invoke(t_2233, "to", ((V)(250D)), Call(o_1845, V.Undef, Call(both_1844, V.Undef, ((V)(6D)), ((V)(8D))), NewObj(2).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V), ((V)("io"))), "to", ((V)(110D)), NewObj(2).Put("hLy", ((V)(12D))).Put("hRy", ((V)(12D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("knock")), ((V)("body")), ((V)(1D))), "to", ((V)(200D)), Call(o_1845, V.Undef, NOHANDS_1846, NewObj(2).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V), ((V)("io")));
return default;
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2234, V t_2240, V _a2237, V _a2238, V _a2239, V[] _rest2235) => {
Call(yay_1859, V.Undef, t_2240);
Invoke(Invoke(t_2240, "to", ((V)(150D)), NewObj(2).Put("fz", ((V)(0.9))).Put("lf", ((V)(1D))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(2).Put("fz", ((V)(0D))).Put("lf", ((V)(0D))).V, ((V)("io")));
Call(swing_1848, V.Undef, t_2240, ((V)(900D)), ((V)(2D)), NewObj(2).Put("tilt", ((V)(4D))).Put("x", ((V)(1D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("perry", NewObj(9).Put("savor", ((V)(0.5))).Put("chewMs", ((V)(140D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.65))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Leans forward to each bite and wobbles back, juicy bites, a happy roly-poly wobble when he likes it."))).Put("pre", Fn((V _self1835, int _argc2241, V t_2247, V _a2244, V _a2245, V _a2246, V[] _rest2242) => {
Invoke(t_2247, "to", ((V)(300D)), NewObj(1).Put("tilt", ((V)(5D))).V, ((V)("io")));
Call(jelly_1849, V.Undef, t_2247, ((V)(4D)), ((V)(2D)), ((V)(360D)), ((V)("tilt")));
return default;
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2248, V t_2254, V _a2251, V _a2252, V _a2253, V[] _rest2249) => {
return Call(lipLick_1853, V.Undef, t_2254);
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2255, V t_2261, V _a2258, V _a2259, V _a2260, V[] _rest2256) => {
Call(yay_1859, V.Undef, t_2261);
Invoke(t_2261, "to", ((V)(200D)), NewObj(1).Put("tilt", ((V)(8D))).V, ((V)("o")));
Call(jelly_1849, V.Undef, t_2261, ((V)(7D)), ((V)(3D)), ((V)(380D)), ((V)("tilt")));
return default;
}, 1, "yum", true)).V).Put("grana", NewObj(10).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(150D))).Put("chewN", ((V)(1D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.55))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Inspects it like a king, small royal bites, his crown flares and ruby seeds sparkle when he likes it."))).Put("pre", Fn((V _self1835, int _argc2262, V t_2268, V _a2265, V _a2266, V _a2267, V[] _rest2263) => {
return Invoke(Invoke(Invoke(t_2268, "to", ((V)(300D)), NewObj(3).Put("pitch", ((V)(0.08))).Put("close", ((V)(0.5))).Put("htilt", ((V)(4D))).V, ((V)("io"))), "wait", ((V)(250D))), "to", ((V)(260D)), NewObj(3).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2269, V t_2275, V _a2272, V _a2273, V _a2274, V[] _rest2270) => {
return Call(lipLick_1853, V.Undef, t_2275);
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2276, V t_2282, V _a2279, V _a2280, V _a2281, V[] _rest2277) => {
Call(yay_1859, V.Undef, t_2282);
Invoke(Invoke(Invoke(t_2282, "to", ((V)(150D)), NewObj(1).Put("crf", ((V)(1D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("arils")), ((V)("head")), ((V)(4D))), "to", ((V)(400D)), NewObj(1).Put("crf", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("mangie", NewObj(9).Put("savor", ((V)(0.6))).Put("chewMs", ((V)(135D))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.7))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Dramatic first bite with her eyes closed - mmm! - her leaf flicks and she blushes when she likes it."))).Put("pre", Fn((V _self1835, int _argc2283, V t_2289, V _a2286, V _a2287, V _a2288, V[] _rest2284) => {
return Invoke(Invoke(t_2289, "to", ((V)(260D)), NewObj(2).Put("close", ((V)(0.6))).Put("pitch", ((V)(0.06))).V, ((V)("io"))), "to", ((V)(200D)), NewObj(2).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2290, V t_2296, V _a2293, V _a2294, V _a2295, V[] _rest2291) => {
return Invoke(Invoke(Invoke(t_2296, "to", ((V)(300D)), NewObj(3).Put("close", ((V)(0.7))).Put("smile", ((V)(1D))).Put("blush", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0D))).Put("blush", ((V)(0D))).V, ((V)("io")));
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2297, V t_2303, V _a2300, V _a2301, V _a2302, V[] _rest2298) => {
Call(yay_1859, V.Undef, t_2303);
Invoke(Invoke(Invoke(t_2303, "to", ((V)(200D)), NewObj(3).Put("lf", ((V)(1D))).Put("stw", ((V)(0.5))).Put("tilt", ((V)((-4D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("mjuice")), ((V)("head")), ((V)(2D))), "to", ((V)(400D)), NewObj(3).Put("lf", ((V)(0D))).Put("stw", ((V)(0D))).Put("tilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).Put("razzy", NewObj(9).Put("chewMs", ((V)(110D))).Put("chewN", ((V)(1.1))).Put("crumbs", ((V)(1D))).Put("open", ((V)(0.6))).Put("armsUp", ((V)(1D))).Put("txt", ((V)("Bubbly quick bites with her beads jiggling, then a sparkly jiggle when she likes it."))).Put("pre", Fn((V _self1835, int _argc2304, V t_2310, V _a2307, V _a2308, V _a2309, V[] _rest2305) => {
return Call(sniffF_1852, V.Undef, t_2310, ((V)(1D)));
}, 1, "pre", true)).Put("post", Fn((V _self1835, int _argc2311, V t_2317, V _a2314, V _a2315, V _a2316, V[] _rest2312) => {
return Call(lipLick_1853, V.Undef, t_2317);
}, 1, "post", true)).Put("yum", Fn((V _self1835, int _argc2318, V t_2324, V _a2321, V _a2322, V _a2323, V[] _rest2319) => {
Call(yay_1859, V.Undef, t_2324);
Invoke(Invoke(Invoke(t_2324, "to", ((V)(150D)), NewObj(1).Put("jig", ((V)(1.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(3D))), "to", ((V)(600D)), NewObj(1).Put("jig", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "yum", true)).V).V;
Invoke(Get(Get(R_1842, "FRUITLIB"), "KEYS"), "forEach", Fn((V _self1835, int _argc2325, V k_2331, V _a2328, V _a2329, V _a2330, V[] _rest2326) => {
V c_2332 = default;
c_2332 = GetK(C_1860, k_2331);
if (!(Truthy(Get(c_2332, "love")))) {
Set(c_2332, "love", Fn((V _self1835, int _argc2333, V t_2339, V _a2336, V _a2337, V _a2338, V[] _rest2334) => {
Call(hearts_1854, V.Undef, t_2339, ((V)(2D)));
Invoke(c_2332, "yum", t_2339);
return default;
}, 1, "", true));
}
return default;
}, 1, "", true));
Call(buildAll_1856, V.Undef, C_1860);
return default;
}, 0, "boot", false)), V.Undef);
return default;
}, 0, "", false), V.Undef);
        }
    }
}
