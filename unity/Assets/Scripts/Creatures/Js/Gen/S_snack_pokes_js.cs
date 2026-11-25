// snack-pokes.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_snack_pokes_js
    {

        public static void Run()
        {
Call(Named(boot_37 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V R_8 = default;
V S_9 = default;
V hand_10 = default;
V both_11 = default;
V o_12 = default;
V NOHANDS_13 = default;
V jump_14 = default;
V shake_15 = default;
V swing_16 = default;
V jelly_17 = default;
V see_18 = default;
V unsee_19 = default;
V giggle_20 = default;
V sniff_21 = default;
V lick_22 = default;
V para_23 = default;
V leanIn_24 = default;
V happy_25 = default;
V build_26 = default;
V armUp_27 = default;
V eyeRub_28 = default;
V wobble_29 = default;
V lookBack_30 = default;
V hop_31 = default;
V tickle_32 = default;
V tasteHeart_33 = default;
V BODY_34 = default;
V RE_35 = default;
V TXT_36 = default;
if (_self1.IsNullish) _self1 = GlobalV;
R_8 = Get(G("window"), "RiveRig");
if ((((!(Truthy(R_8)) || !(Truthy(Get(R_8, "POKELIB")))) || !(Truthy(Get(R_8, "SNACKLIB")))) || !(Truthy(Get(Get(R_8, "STATES"), "poke_head"))))) {
Call(G("setTimeout"), V.Undef, boot_37.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_8, "snackPokeV"))) {
return default;
}
Set(R_8, "snackPokeV", ((V)(1D)));
{ V _t38 = Get(R_8, "PETLIB");
if (_t38.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t38));
{ V _t39 = Get(_t38, "S");
S_9 = _t39; }
{ V _t40 = Get(_t38, "hand");
hand_10 = _t40; }
{ V _t41 = Get(_t38, "both");
both_11 = _t41; }
{ V _t42 = Get(_t38, "o");
o_12 = _t42; }
{ V _t43 = Get(_t38, "NOHANDS");
NOHANDS_13 = _t43; }
{ V _t44 = Get(_t38, "jump");
jump_14 = _t44; }
{ V _t45 = Get(_t38, "shake");
shake_15 = _t45; }
{ V _t46 = Get(_t38, "swing");
swing_16 = _t46; }
{ V _t47 = Get(_t38, "jelly");
jelly_17 = _t47; } }
{ V _t48 = Get(R_8, "POKELIB");
if (_t48.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t48));
{ V _t49 = Get(_t48, "see");
see_18 = _t49; }
{ V _t50 = Get(_t48, "unsee");
unsee_19 = _t50; }
{ V _t51 = Get(_t48, "giggle");
giggle_20 = _t51; }
{ V _t52 = Get(_t48, "sniff");
sniff_21 = _t52; }
{ V _t53 = Get(_t48, "lick");
lick_22 = _t53; }
{ V _t54 = Get(_t48, "para");
para_23 = _t54; }
{ V _t55 = Get(_t48, "leanIn");
leanIn_24 = _t55; }
{ V _t56 = Get(_t48, "happy");
happy_25 = _t56; }
{ V _t57 = Get(_t48, "build");
build_26 = _t57; } }
armUp_27 = Fn((V _arrowThis69, int _argc58, V t_64, V s_65, V n_66, V a_67, V[] _rest59) => {
V k_70 = default;
V x_68 = default;
x_68 = (_argc58 > 4 ? _rest59[0] : V.Undef);
k_70 = Call(S_9, V.Undef, s_65);
a_67 = (a_67 is var _t71 && Truthy(_t71) ? _t71 : ((V)(150D)));
Invoke(t_64, "to", ((V)(300D)), Call(o_12, V.Undef, NewObj(1).PutK(Get(k_70, "arm"), a_67).V, (x_68 is var _t72 && Truthy(_t72) ? _t72 : NewObj(0).V)), ((V)("io")));
{
double i_73 = 0;
i_73 = 0D;
while (true) {
if (!(Lt(((V)(i_73)), (n_66 is var _t75 && Truthy(_t75) ? _t75 : ((V)(2D)))))) break;
Invoke(Invoke(t_64, "to", ((V)(170D)), NewObj(1).PutK(Get(k_70, "arm"), ((V)((ToNum(a_67) - 16D)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(1).PutK(Get(k_70, "arm"), a_67).V, ((V)("io")));
i_73++;
}
}
return Invoke(t_64, "to", ((V)(300D)), NewObj(3).PutK(Get(k_70, "arm"), ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
return default;
}, 5, "", true);
eyeRub_28 = Fn((V _arrowThis84, int _argc76, V t_82, V s_83, V _a80, V _a81, V[] _rest77) => {
V k_85 = default;
V h_86 = default;
k_85 = Call(S_9, V.Undef, s_83);
h_86 = Call(hand_10, V.Undef, s_83, ((V)(12D)), ((V)((-20D))));
Invoke(Invoke(t_82, "e", ((V)("blink2"))), "to", ((V)(300D)), Call(o_12, V.Undef, h_86, NewObj(2).PutK(Get(k_85, "arm"), ((V)(20D))).PutK(Get(k_85, "wink"), ((V)(1D))).V), ((V)("io")));
{
double i_87 = 0;
i_87 = 0D;
while (true) {
if (!((i_87 < 2D))) break;
Invoke(Invoke(t_82, "to", ((V)(170D)), NewObj(2).PutK(Get(k_85, "hx"), Add(GetK(h_86, Get(k_85, "hx")), ((V)((LtN(s_83, 0D) ? 3D : (-3D)))))).PutK(Get(k_85, "hy"), ((V)((ToNum(GetK(h_86, Get(k_85, "hy"))) - 1.5)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(2).PutK(Get(k_85, "hx"), GetK(h_86, Get(k_85, "hx"))).PutK(Get(k_85, "hy"), GetK(h_86, Get(k_85, "hy"))).V, ((V)("io")));
i_87++;
}
}
return Invoke(Invoke(t_82, "to", ((V)(300D)), NewObj(4).PutK(Get(k_85, "hx"), ((V)(0D))).PutK(Get(k_85, "hy"), ((V)(0D))).PutK(Get(k_85, "arm"), ((V)(0D))).PutK(Get(k_85, "wink"), ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink")));
return default;
}, 2, "", true);
wobble_29 = Fn((V _arrowThis98, int _argc89, V t_95, V a_96, V ch_97, V _a94, V[] _rest90) => {
return Call(jelly_17, V.Undef, t_95, (a_96 is var _t99 && Truthy(_t99) ? _t99 : ((V)(0.12))), ((V)(3D)), ((V)(300D)), ch_97);
}, 3, "", true);
lookBack_30 = Fn((V _arrowThis108, int _argc100, V t_106, V hold_107, V _a104, V _a105, V[] _rest101) => {
Call(see_18, V.Undef, t_106, ((V)("tail")), ((V)(1D)), (hold_107 is var _t109 && Truthy(_t109) ? _t109 : ((V)(350D))));
return Call(unsee_19, V.Undef, t_106, ((V)(380D)));
return default;
}, 2, "", true);
hop_31 = Fn((V _arrowThis119, int _argc110, V t_116, V h_117, V ev_118, V _a115, V[] _rest111) => {
return Call(jump_14, V.Undef, t_116, NewObj(6).Put("h", (h_117 is var _t120 && Truthy(_t120) ? _t120 : ((V)(6D)))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).Put("ev", ev_118).V);
}, 3, "", true);
tickle_32 = Fn((V _arrowThis129, int _argc121, V t_127, V extra_128, V _a125, V _a126, V[] _rest122) => {
V a_130 = default;
Invoke(t_127, "to", ((V)(220D)), Call(o_12, V.Undef, Call(both_11, V.Undef, ((V)(8D)), ((V)((-4D)))), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
a_130 = Get(t_127, "t");
Call(giggle_20, V.Undef, t_127, ((V)(3D)), ((V)(0.9)));
if (Truthy(extra_128)) {
Call(para_23, V.Undef, t_127, a_130, extra_128);
}
return Invoke(t_127, "to", ((V)(260D)), NOHANDS_13, ((V)("io")));
return default;
}, 2, "", true);
tasteHeart_33 = Fn((V _arrowThis138, int _argc131, V t_137, V _a134, V _a135, V _a136, V[] _rest132) => {
Call(lick_22, V.Undef, t_137, ((V)(2D)));
return Invoke(Invoke(Invoke(Invoke(t_137, "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(320D))), "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true);
BODY_34 = NewObj(9).Put("mallow", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(3).Put("ear", ((V)("top corner"))).Put("nose", ((V)("Mouth"))).Put("tail", ((V)("Back"))).V).V).Put("bao", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(3).Put("ear", ((V)("pleats"))).Put("nose", ((V)("Mouth"))).Put("tail", ((V)("Back"))).V).V).Put("dunkie", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(3).Put("ear", Fn((V _arrowThis146, int _argc139, V s_145, V _a142, V _a143, V _a144, V[] _rest140) => {
return ((V)((GtN(s_145, 0D) ? "Bite mark" : "Left of his icing")));
}, 1, "ear", true)).Put("nose", ((V)("Mouth"))).Put("tail", ((V)("Back"))).V).V).Put("frybo", NewObj(2).Put("ear", ((V)(1D))).Put("lbl", NewObj(3).Put("ear", ((V)("fries"))).Put("nose", ((V)("Mouth"))).Put("tail", ((V)("Box"))).V).V).Put("bunbun", NewObj(3).Put("ear", ((V)(0.6))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("ear", ((V)("top bun"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Patty"))).Put("side", ((V)("side"))).Put("foot", ((V)("bottom bun"))).Put("tail", ((V)("Back"))).V).V).Put("choco", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(4).Put("ear", Fn((V _arrowThis154, int _argc147, V s_153, V _a150, V _a151, V _a152, V[] _rest148) => {
return ((V)((GtN(s_153, 0D) ? "Bite mark" : "Left top corner")));
}, 1, "ear", true)).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Wrapper"))).Put("tail", ((V)("Wrapper (back)"))).V).V).Put("scoop", NewObj(3).Put("ear", ((V)(0.6))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("head", ((V)("Cherry"))).Put("ear", ((V)("scoop"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Cone"))).Put("foot", ((V)("cone tip"))).Put("tail", ((V)("Cone (back)"))).V).V).Put("boba", NewObj(3).Put("ear", ((V)(1D))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("ear", Fn((V _arrowThis162, int _argc155, V s_161, V _a158, V _a159, V _a160, V[] _rest156) => {
return ((V)((GtN(s_161, 0D) ? "Straw" : "Left of his lid")));
}, 1, "ear", true)).Put("head", ((V)("Lid"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Pearls"))).Put("foot", ((V)("cup bottom"))).Put("tail", ((V)("Cup (back)"))).V).V).Put("chefbun", NewObj(2).Put("ear", ((V)(1D))).Put("lbl", NewObj(4).Put("head", ((V)("Chef hat"))).Put("ear", ((V)("side of his hat"))).Put("nose", ((V)("Mouth"))).Put("tail", ((V)("Back"))).V).V).V;
RE_35 = NewObj(9).Put("mallow", NewObj(9).Put("head", Fn((V _arrowThis171, int _argc163, V t_169, V s_170, V _a167, V _a168, V[] _rest164) => {
Invoke(Invoke(Invoke(t_169, "to", ((V)(260D)), NewObj(3).Put("sq", ((V)(0.3))).Put("close", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(1300D)), NewObj(3).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("o")));
Call(giggle_20, V.Undef, t_169, ((V)(2D)), ((V)(0.8)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis180, int _argc172, V t_178, V s_179, V _a176, V _a177, V[] _rest173) => {
Call(see_18, V.Undef, t_178, ((V)("ear")), s_179, ((V)(150D)));
Invoke(Invoke(t_178, "to", ((V)(320D)), NewObj(2).Put("puff", ((V)(0.5))).Put("wide", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(450D)), NewObj(2).Put("puff", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
Call(unsee_19, V.Undef, t_178);
Call(happy_25, V.Undef, t_178, ((V)(1D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis189, int _argc181, V t_187, V s_188, V _a185, V _a186, V[] _rest182) => {
Invoke(t_187, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.3))).V, ((V)("io")));
Call(tasteHeart_33, V.Undef, t_187);
Invoke(t_187, "to", ((V)(200D)), NewObj(1).Put("ly", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis198, int _argc190, V t_196, V s_197, V _a194, V _a195, V[] _rest191) => {
Call(eyeRub_28, V.Undef, t_196, s_197);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis207, int _argc199, V t_205, V s_206, V _a203, V _a204, V[] _rest200) => {
Call(leanIn_24, V.Undef, t_205, s_206, NewObj(1).Put("sq", ((V)(0.06))).V);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis216, int _argc208, V t_214, V s_215, V _a212, V _a213, V[] _rest209) => {
Call(tickle_32, V.Undef, t_214, Fn((V _arrowThis224, int _argc217, V u_223, V _a220, V _a221, V _a222, V[] _rest218) => {
return Call(jelly_17, V.Undef, u_223, ((V)(0.1)), ((V)(4D)), ((V)(280D)));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis233, int _argc225, V t_231, V s_232, V _a229, V _a230, V[] _rest226) => {
Call(jelly_17, V.Undef, t_231, ((V)(4D)), ((V)(3D)), ((V)(340D)), ((V)("bend")));
Call(see_18, V.Undef, t_231, ((V)("side")), s_232, ((V)(250D)));
Call(unsee_19, V.Undef, t_231, ((V)(350D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis242, int _argc234, V t_240, V s_241, V _a238, V _a239, V[] _rest235) => {
Call(see_18, V.Undef, t_240, ((V)("foot")), s_241, ((V)(200D)));
Invoke(t_240, "to", ((V)(260D)), NewObj(1).PutK(Get(Call(S_9, V.Undef, s_241), "foot"), ((V)(0D))).V, ((V)("io")));
Call(unsee_19, V.Undef, t_240);
Call(hop_31, V.Undef, t_240, ((V)(4D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis251, int _argc243, V t_249, V s_250, V _a247, V _a248, V[] _rest244) => {
Call(wobble_29, V.Undef, t_249, ((V)(0.14)));
Call(lookBack_30, V.Undef, t_249);
return default;
}, 2, "tail", true)).V).Put("bao", NewObj(9).Put("head", Fn((V _arrowThis260, int _argc252, V t_258, V s_259, V _a256, V _a257, V[] _rest253) => {
Invoke(Invoke(Invoke(t_258, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(5D))), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0.35))).Put("close", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Call(giggle_20, V.Undef, t_258, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis269, int _argc261, V t_267, V s_268, V _a265, V _a266, V[] _rest262) => {
Call(see_18, V.Undef, t_267, ((V)("ear")), s_268, ((V)(100D)));
Invoke(Invoke(t_267, "osc", ((V)(520D)), ((V)(2D)), NewObj(1).Put("htilt", ((V)((ToNum(s_268) * 5D)))).V, NewObj(1).Put("htilt", ((V)((ToNum(s_268) * 1D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
Call(unsee_19, V.Undef, t_267);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis278, int _argc270, V t_276, V s_277, V _a274, V _a275, V[] _rest271) => {
Invoke(t_276, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_21, V.Undef, t_276, ((V)(3D)));
Invoke(Invoke(Invoke(Invoke(t_276, "to", ((V)(240D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis287, int _argc279, V t_285, V s_286, V _a283, V _a284, V[] _rest280) => {
Call(eyeRub_28, V.Undef, t_285, s_286);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis296, int _argc288, V t_294, V s_295, V _a292, V _a293, V[] _rest289) => {
Call(leanIn_24, V.Undef, t_294, s_295, NewObj(1).Put("puff", ((V)(0.2))).V);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis305, int _argc297, V t_303, V s_304, V _a301, V _a302, V[] _rest298) => {
Call(tickle_32, V.Undef, t_303, Fn((V _arrowThis313, int _argc306, V u_312, V _a309, V _a310, V _a311, V[] _rest307) => {
return Call(jelly_17, V.Undef, u_312, ((V)(0.09)), ((V)(4D)), ((V)(260D)));
}, 1, "", true));
Invoke(t_303, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis322, int _argc314, V t_320, V s_321, V _a318, V _a319, V[] _rest315) => {
Call(jelly_17, V.Undef, t_320, ((V)(3D)), ((V)(3D)), ((V)(320D)), ((V)("bend")));
Invoke(t_320, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
Call(see_18, V.Undef, t_320, ((V)("side")), s_321, ((V)(200D)));
Call(unsee_19, V.Undef, t_320, ((V)(320D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis331, int _argc323, V t_329, V s_330, V _a327, V _a328, V[] _rest324) => {
Call(hop_31, V.Undef, t_329, ((V)(5D)), Arr(Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis340, int _argc332, V t_338, V s_339, V _a336, V _a337, V[] _rest333) => {
Invoke(t_338, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D)));
Call(lookBack_30, V.Undef, t_338);
return default;
}, 2, "tail", true)).V).Put("dunkie", NewObj(9).Put("head", Fn((V _arrowThis349, int _argc341, V t_347, V s_348, V _a345, V _a346, V[] _rest342) => {
Invoke(t_347, "e", ((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(4D)));
Call(see_18, V.Undef, t_347, ((V)("head")), s_348, ((V)(200D)));
Call(unsee_19, V.Undef, t_347, ((V)(300D)));
Call(giggle_20, V.Undef, t_347, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis358, int _argc350, V t_356, V s_357, V _a354, V _a355, V[] _rest351) => {
if (GtN(s_357, 0D)) {
Call(see_18, V.Undef, t_356, ((V)("ear")), s_357, ((V)(100D)));
Invoke(t_356, "to", ((V)(220D)), NewObj(3).Put("frown", ((V)(0.45))).Put("puff", ((V)(0.3))).Put("wide", ((V)(0.4))).V, ((V)("io")));
Call(armUp_27, V.Undef, t_356, ((V)(1D)), ((V)(2D)), ((V)(132D)));
Call(unsee_19, V.Undef, t_356);
Invoke(Invoke(t_356, "to", ((V)(250D)), NewObj(5).Put("frown", ((V)(0D))).Put("puff", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D)));
} else {
Call(see_18, V.Undef, t_356, ((V)("ear")), s_357, ((V)(150D)));
Call(unsee_19, V.Undef, t_356);
Call(giggle_20, V.Undef, t_356, ((V)(2D)));
}
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis367, int _argc359, V t_365, V s_366, V _a363, V _a364, V[] _rest360) => {
Invoke(t_365, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_21, V.Undef, t_365, ((V)(2D)));
Call(tasteHeart_33, V.Undef, t_365);
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis376, int _argc368, V t_374, V s_375, V _a372, V _a373, V[] _rest369) => {
Call(eyeRub_28, V.Undef, t_374, s_375);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis385, int _argc377, V t_383, V s_384, V _a381, V _a382, V[] _rest378) => {
Call(leanIn_24, V.Undef, t_383, s_384);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis394, int _argc386, V t_392, V s_393, V _a390, V _a391, V[] _rest387) => {
Call(tickle_32, V.Undef, t_392, Fn((V _arrowThis402, int _argc395, V u_401, V _a398, V _a399, V _a400, V[] _rest396) => {
return Call(swing_16, V.Undef, u_401, ((V)(900D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(8D))).Put("x", ((V)(2D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis411, int _argc403, V t_409, V s_410, V _a407, V _a408, V[] _rest404) => {
double d_412 = 0;
d_412 = (-ToNum(s_410));
Invoke(Invoke(Invoke(Invoke(t_409, "to", ((V)(420D)), NewObj(3).Put("x", ((V)((d_412 * 6D)))).Put("tilt", ((V)((d_412 * 24D)))).Put("wide", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(380D)), NewObj(1).Put("tilt", ((V)((d_412 * 18D)))).V, ((V)("io"))), "to", ((V)(520D)), NewObj(3).Put("x", ((V)(0D))).Put("tilt", ((V)(((-d_412) * 3D)))).Put("wide", ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(giggle_20, V.Undef, t_409, ((V)(2D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis421, int _argc413, V t_419, V s_420, V _a417, V _a418, V[] _rest414) => {
Call(hop_31, V.Undef, t_419, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(4D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis430, int _argc422, V t_428, V s_429, V _a426, V _a427, V[] _rest423) => {
Invoke(t_428, "e", ((V)("emit")), ((V)("sprinkle")), ((V)("body")), ((V)(3D)));
Call(lookBack_30, V.Undef, t_428);
return default;
}, 2, "tail", true)).V).Put("frybo", NewObj(9).Put("head", Fn((V _arrowThis439, int _argc431, V t_437, V s_438, V _a435, V _a436, V[] _rest432) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_437, "to", ((V)(120D)), NewObj(3).Put("earL", ((V)(12D))).Put("earR", ((V)(12D))).Put("fw", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(3).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).Put("sq", ((V)((-0.1)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(5D))), "to", ((V)(240D)), NewObj(3).Put("earL", ((V)(3D))).Put("earR", ((V)(3D))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(4).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("sq", ((V)(0D))).Put("fw", ((V)(0D))).V, ((V)("io")));
Call(giggle_20, V.Undef, t_437, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis448, int _argc440, V t_446, V s_447, V _a444, V _a445, V[] _rest441) => {
V a_449 = default;
a_449 = Get(t_446, "t");
Invoke(Invoke(t_446, "to", ((V)(500D)), NewObj(1).Put("fw", ((V)(1.3))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("fw", ((V)(0D))).V, ((V)("io")));
Call(para_23, V.Undef, t_446, a_449, Fn((V _arrowThis457, int _argc450, V u_456, V _a453, V _a454, V _a455, V[] _rest451) => {
Call(see_18, V.Undef, u_456, ((V)("ear")), s_447, ((V)(120D)));
Call(unsee_19, V.Undef, u_456);
return default;
}, 1, "", true));
Call(giggle_20, V.Undef, t_446, ((V)(2D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis466, int _argc458, V t_464, V s_465, V _a462, V _a463, V[] _rest459) => {
Invoke(t_464, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_21, V.Undef, t_464, ((V)(3D)));
Invoke(Invoke(Invoke(t_464, "to", ((V)(260D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("ly", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(220D)), NewObj(3).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis475, int _argc467, V t_473, V s_474, V _a471, V _a472, V[] _rest468) => {
Call(eyeRub_28, V.Undef, t_473, s_474);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis484, int _argc476, V t_482, V s_483, V _a480, V _a481, V[] _rest477) => {
Call(leanIn_24, V.Undef, t_482, s_483, NewObj(2).Put("earL", ((V)(((-ToNum(s_483)) * 6D)))).Put("earR", ((V)(((-ToNum(s_483)) * 6D)))).V);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis493, int _argc485, V t_491, V s_492, V _a489, V _a490, V[] _rest486) => {
Call(tickle_32, V.Undef, t_491, Fn((V _arrowThis501, int _argc494, V u_500, V _a497, V _a498, V _a499, V[] _rest495) => {
return Invoke(Invoke(u_500, "to", ((V)(500D)), NewObj(1).Put("fw", ((V)(1D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("fw", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis510, int _argc502, V t_508, V s_509, V _a506, V _a507, V[] _rest503) => {
V a_511 = default;
a_511 = Get(t_508, "t");
Invoke(Invoke(Invoke(t_508, "to", ((V)(300D)), NewObj(2).Put("earL", ((V)(((-ToNum(s_509)) * 14D)))).Put("earR", ((V)(((-ToNum(s_509)) * 14D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("earL", ((V)((ToNum(s_509) * 6D)))).Put("earR", ((V)((ToNum(s_509) * 6D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(para_23, V.Undef, t_508, a_511, Fn((V _arrowThis519, int _argc512, V u_518, V _a515, V _a516, V _a517, V[] _rest513) => {
Call(see_18, V.Undef, u_518, ((V)("side")), s_509, ((V)(200D)));
Call(unsee_19, V.Undef, u_518, ((V)(300D)));
return default;
}, 1, "", true));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis528, int _argc520, V t_526, V s_527, V _a524, V _a525, V[] _rest521) => {
Call(hop_31, V.Undef, t_526, ((V)(7D)), Arr(Arr(((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(4D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis537, int _argc529, V t_535, V s_536, V _a533, V _a534, V[] _rest530) => {
Invoke(Invoke(t_535, "osc", ((V)(420D)), ((V)(3D)), NewObj(2).Put("earL", ((V)(5D))).Put("earR", ((V)((-5D)))).V, NewObj(2).Put("earL", ((V)((-5D)))).Put("earR", ((V)(5D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(lookBack_30, V.Undef, t_535);
return default;
}, 2, "tail", true)).V).Put("bunbun", NewObj(9).Put("head", Fn((V _arrowThis546, int _argc538, V t_544, V s_545, V _a542, V _a543, V[] _rest539) => {
Invoke(Invoke(Invoke(Invoke(t_544, "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0.2))).Put("fan", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head")), ((V)(1D))), "to", ((V)(160D)), NewObj(3).Put("sq", ((V)((-0.08)))).Put("split", ((V)(0.5))).Put("fan", ((V)(0D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("sq", ((V)(0D))).Put("split", ((V)(0D))).V, ((V)("io")));
Call(giggle_20, V.Undef, t_544, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis555, int _argc547, V t_553, V s_554, V _a551, V _a552, V[] _rest548) => {
Call(see_18, V.Undef, t_553, ((V)("ear")), s_554, ((V)(100D)));
Invoke(Invoke(Invoke(t_553, "to", ((V)(240D)), NewObj(1).Put("fan", ((V)((ToNum(s_554) * 0.9)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("fan", ((V)(((-ToNum(s_554)) * 0.3)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(1).Put("fan", ((V)(0D))).V, ((V)("io")));
Call(unsee_19, V.Undef, t_553);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis564, int _argc556, V t_562, V s_563, V _a560, V _a561, V[] _rest557) => {
Invoke(t_562, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_21, V.Undef, t_562, ((V)(2D)));
Call(tasteHeart_33, V.Undef, t_562);
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis573, int _argc565, V t_571, V s_572, V _a569, V _a570, V[] _rest566) => {
Call(eyeRub_28, V.Undef, t_571, s_572);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis582, int _argc574, V t_580, V s_581, V _a578, V _a579, V[] _rest575) => {
Call(leanIn_24, V.Undef, t_580, s_581);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis591, int _argc583, V t_589, V s_590, V _a587, V _a588, V[] _rest584) => {
Call(tickle_32, V.Undef, t_589, Fn((V _arrowThis599, int _argc592, V u_598, V _a595, V _a596, V _a597, V[] _rest593) => {
return Invoke(Invoke(u_598, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("shuf", ((V)(0.6))).V, NewObj(1).Put("shuf", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("shuf", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis608, int _argc600, V t_606, V s_607, V _a604, V _a605, V[] _rest601) => {
Invoke(t_606, "to", ((V)(200D)), NewObj(2).Put("shuf", ((V)(((-ToNum(s_607)) * 0.9)))).Put("wide", ((V)(0.5))).V, ((V)("o")));
Call(see_18, V.Undef, t_606, ((V)("side")), s_607, ((V)(100D)));
Invoke(Invoke(t_606, "to", ((V)(300D)), Call(o_12, V.Undef, Call(both_11, V.Undef, ((V)(9D)), ((V)(2D))), NewObj(1).Put("shuf", ((V)(((-ToNum(s_607)) * 0.4)))).V), ((V)("io"))), "to", ((V)(300D)), Call(o_12, V.Undef, NOHANDS_13, NewObj(2).Put("shuf", ((V)(0D))).Put("wide", ((V)(0D))).V), ((V)("io")));
Call(unsee_19, V.Undef, t_606, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis617, int _argc609, V t_615, V s_616, V _a613, V _a614, V[] _rest610) => {
Call(jump_14, V.Undef, t_615, NewObj(7).Put("h", ((V)(7D))).Put("ant", ((V)(140D))).Put("up", ((V)(200D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).Put("air", NewObj(1).Put("split", ((V)(0.5))).V).Put("fall", NewObj(1).Put("split", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis626, int _argc618, V t_624, V s_625, V _a622, V _a623, V[] _rest619) => {
Invoke(Invoke(t_624, "to", ((V)(160D)), NewObj(1).Put("split", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("split", ((V)(0D))).V, ((V)("io")));
Call(lookBack_30, V.Undef, t_624);
return default;
}, 2, "tail", true)).V).Put("choco", NewObj(9).Put("head", Fn((V _arrowThis635, int _argc627, V t_633, V s_634, V _a631, V _a632, V[] _rest628) => {
Invoke(Invoke(Invoke(Invoke(t_633, "to", ((V)(80D)), NewObj(1).Put("tw", ((V)(1.2))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(1).Put("tw", ((V)(0D))).V, ((V)("io")));
Call(giggle_20, V.Undef, t_633, ((V)(1D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis644, int _argc636, V t_642, V s_643, V _a640, V _a641, V[] _rest637) => {
if (GtN(s_643, 0D)) {
Call(see_18, V.Undef, t_642, ((V)("ear")), s_643, ((V)(100D)));
Invoke(t_642, "to", ((V)(220D)), NewObj(2).Put("frown", ((V)(0.4))).Put("puff", ((V)(0.3))).V, ((V)("io")));
Call(armUp_27, V.Undef, t_642, ((V)(1D)), ((V)(2D)), ((V)(132D)));
Call(unsee_19, V.Undef, t_642);
Invoke(Invoke(t_642, "to", ((V)(250D)), NewObj(4).Put("frown", ((V)(0D))).Put("puff", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D)));
} else {
Invoke(Invoke(Invoke(t_642, "to", ((V)(80D)), NewObj(1).Put("tw", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(150D))), "to", ((V)(300D)), NewObj(1).Put("tw", ((V)(0D))).V, ((V)("io")));
Call(see_18, V.Undef, t_642, ((V)("ear")), s_643, ((V)(150D)));
Call(unsee_19, V.Undef, t_642);
}
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis653, int _argc645, V t_651, V s_652, V _a649, V _a650, V[] _rest646) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_651, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(4).Put("melt", ((V)(0.45))).Put("blush", ((V)(0.8))).Put("sq", ((V)(0.05))).Put("close", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(140D)), NewObj(4).Put("melt", ((V)(0D))).Put("sq", ((V)((-0.05)))).Put("tw", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0D))).Put("tw", ((V)(0D))).Put("blush", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis662, int _argc654, V t_660, V s_661, V _a658, V _a659, V[] _rest655) => {
Call(eyeRub_28, V.Undef, t_660, s_661);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis671, int _argc663, V t_669, V s_670, V _a667, V _a668, V[] _rest664) => {
Call(leanIn_24, V.Undef, t_669, s_670, NewObj(1).Put("melt", ((V)(0.3))).V);
Invoke(t_669, "to", ((V)(250D)), NewObj(1).Put("melt", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis680, int _argc672, V t_678, V s_679, V _a676, V _a677, V[] _rest673) => {
Call(tickle_32, V.Undef, t_678, Fn((V _arrowThis688, int _argc681, V u_687, V _a684, V _a685, V _a686, V[] _rest682) => {
return Invoke(Invoke(u_687, "to", ((V)(600D)), NewObj(1).Put("melt", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("melt", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis697, int _argc689, V t_695, V s_696, V _a693, V _a694, V[] _rest690) => {
Call(jelly_17, V.Undef, t_695, ((V)(3D)), ((V)(2D)), ((V)(300D)), ((V)("bend")));
Invoke(Invoke(t_695, "to", ((V)(80D)), NewObj(1).Put("tw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("tw", ((V)(0D))).V, ((V)("io")));
Call(see_18, V.Undef, t_695, ((V)("side")), s_696, ((V)(200D)));
Call(unsee_19, V.Undef, t_695, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis706, int _argc698, V t_704, V s_705, V _a702, V _a703, V[] _rest699) => {
Call(hop_31, V.Undef, t_704, ((V)(5D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis715, int _argc707, V t_713, V s_714, V _a711, V _a712, V[] _rest708) => {
Invoke(Invoke(t_713, "to", ((V)(200D)), NewObj(1).Put("wrap", ((V)(0.35))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("wrap", ((V)(0.1))).V, ((V)("io")));
Call(lookBack_30, V.Undef, t_713, ((V)(250D)));
Invoke(t_713, "to", ((V)(260D)), NewObj(1).Put("wrap", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "tail", true)).V).Put("scoop", NewObj(9).Put("head", Fn((V _arrowThis724, int _argc716, V t_722, V s_723, V _a720, V _a721, V[] _rest717) => {
Invoke(Invoke(t_722, "to", ((V)(150D)), NewObj(1).Put("chy", ((V)(1D))).V, ((V)("o"))), "to", ((V)(280D)), NewObj(1).Put("chy", ((V)(0D))).V, ((V)("i")));
Call(see_18, V.Undef, t_722, ((V)("head")), s_723, ((V)(150D)));
Call(unsee_19, V.Undef, t_722);
Call(giggle_20, V.Undef, t_722, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis733, int _argc725, V t_731, V s_732, V _a729, V _a730, V[] _rest726) => {
Call(see_18, V.Undef, t_731, ((V)("ear")), s_732, ((V)(100D)));
Invoke(t_731, "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("chb", ((V)(1D))).Put("htilt", ((V)((ToNum(s_732) * 3D)))).V, NewObj(2).Put("chb", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
Call(unsee_19, V.Undef, t_731);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis742, int _argc734, V t_740, V s_741, V _a738, V _a739, V[] _rest735) => {
Invoke(t_740, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(lick_22, V.Undef, t_740, ((V)(2D)));
Invoke(t_740, "to", ((V)(150D)), NewObj(1).Put("close", ((V)(0.4))).V, ((V)("io")));
Call(shake_15, V.Undef, t_740, NewObj(6).Put("P", ((V)(70D))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(0.7)), ((V)(0.35)))).Put("head", ((V)(0.1))).Put("roll", ((V)(2D))).Put("ear", ((V)(0D))).Put("body", ((V)(0.5))).V);
Invoke(Invoke(t_740, "to", ((V)(260D)), NewObj(4).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis751, int _argc743, V t_749, V s_750, V _a747, V _a748, V[] _rest744) => {
Call(eyeRub_28, V.Undef, t_749, s_750);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis760, int _argc752, V t_758, V s_759, V _a756, V _a757, V[] _rest753) => {
Call(leanIn_24, V.Undef, t_758, s_759, NewObj(1).Put("chb", ((V)(0.6))).V);
Invoke(t_758, "to", ((V)(200D)), NewObj(1).Put("chb", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis769, int _argc761, V t_767, V s_768, V _a765, V _a766, V[] _rest762) => {
Call(tickle_32, V.Undef, t_767, Fn((V _arrowThis777, int _argc770, V u_776, V _a773, V _a774, V _a775, V[] _rest771) => {
return Invoke(u_776, "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("chb", ((V)(1D))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis786, int _argc778, V t_784, V s_785, V _a782, V _a783, V[] _rest779) => {
double d_787 = 0;
d_787 = (-ToNum(s_785));
Invoke(Invoke(Invoke(t_784, "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)((d_787 * 9D)))).Put("chb", ((V)(1D))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(2).Put("tilt", ((V)(((-d_787) * 4D)))).Put("chb", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("tilt", ((V)(0D))).Put("chb", ((V)(0D))).V, ((V)("io")));
Call(see_18, V.Undef, t_784, ((V)("side")), s_785, ((V)(200D)));
Call(unsee_19, V.Undef, t_784, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis796, int _argc788, V t_794, V s_795, V _a792, V _a793, V[] _rest789) => {
Call(jump_14, V.Undef, t_794, NewObj(7).Put("h", ((V)(5D))).Put("ant", ((V)(140D))).Put("up", ((V)(180D))).Put("c", ((V)(0.12))).Put("arm", ((V)(35D))).Put("air", NewObj(1).Put("chy", ((V)(0.6))).V).Put("fall", NewObj(1).Put("chy", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis805, int _argc797, V t_803, V s_804, V _a801, V _a802, V[] _rest798) => {
Invoke(t_803, "osc", ((V)(360D)), ((V)(2D)), NewObj(1).Put("chb", ((V)(1D))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("io")));
Call(lookBack_30, V.Undef, t_803);
return default;
}, 2, "tail", true)).V).Put("boba", NewObj(9).Put("head", Fn((V _arrowThis814, int _argc806, V t_812, V s_813, V _a810, V _a811, V[] _rest807) => {
Invoke(Invoke(Invoke(t_812, "to", ((V)(90D)), NewObj(2).Put("sup", ((V)(1.1))).Put("pop", ((V)(1.6))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(400D)), NewObj(2).Put("sup", ((V)(0D))).Put("pop", ((V)(0D))).V, ((V)("io")));
Call(giggle_20, V.Undef, t_812, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis823, int _argc815, V t_821, V s_822, V _a819, V _a820, V[] _rest816) => {
Call(see_18, V.Undef, t_821, ((V)("ear")), s_822, ((V)(100D)));
if (GtN(s_822, 0D)) {
Invoke(Invoke(t_821, "to", ((V)(500D)), NewObj(1).Put("stw", ((V)(1.6))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
} else {
Invoke(Invoke(t_821, "to", ((V)(400D)), NewObj(1).Put("swirl", ((V)((-1.5)))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("io")));
}
Call(unsee_19, V.Undef, t_821);
if (GtN(s_822, 0D)) {
Call(giggle_20, V.Undef, t_821, ((V)(2D)));
}
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis832, int _argc824, V t_830, V s_831, V _a828, V _a829, V[] _rest825) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_830, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("slurp", ((V)(1D))).Put("mw", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(200D)), NewObj(2).Put("slurp", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io"))), "e", ((V)("gulp")));
Invoke(Invoke(Invoke(t_830, "to", ((V)(260D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("swirl", ((V)(1.2))).Put("ly", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(300D)), NewObj(3).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("swirl", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis841, int _argc833, V t_839, V s_840, V _a837, V _a838, V[] _rest834) => {
Call(eyeRub_28, V.Undef, t_839, s_840);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis850, int _argc842, V t_848, V s_849, V _a846, V _a847, V[] _rest843) => {
Call(leanIn_24, V.Undef, t_848, s_849, NewObj(1).Put("swirl", ((V)((ToNum(s_849) * 1D)))).V);
Invoke(t_848, "to", ((V)(200D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis859, int _argc851, V t_857, V s_858, V _a855, V _a856, V[] _rest852) => {
Call(tickle_32, V.Undef, t_857, Fn((V _arrowThis867, int _argc860, V u_866, V _a863, V _a864, V _a865, V[] _rest861) => {
return Invoke(Invoke(u_866, "to", ((V)(300D)), NewObj(2).Put("pop", ((V)(1.4))).Put("swirl", ((V)(1.5))).V, ((V)("o"))), "to", ((V)(700D)), NewObj(2).Put("pop", ((V)(0D))).Put("swirl", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis876, int _argc868, V t_874, V s_875, V _a872, V _a873, V[] _rest869) => {
Invoke(Invoke(Invoke(t_874, "to", ((V)(300D)), NewObj(1).Put("swirl", ((V)(((-ToNum(s_875)) * 2.2)))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(1).Put("swirl", ((V)((ToNum(s_875) * 0.8)))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("io")));
Call(see_18, V.Undef, t_874, ((V)("side")), s_875, ((V)(150D)));
Call(unsee_19, V.Undef, t_874, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis885, int _argc877, V t_883, V s_884, V _a881, V _a882, V[] _rest878) => {
Call(jump_14, V.Undef, t_883, NewObj(7).Put("h", ((V)(6D))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.12))).Put("arm", ((V)(35D))).Put("air", NewObj(1).Put("pop", ((V)(1.5))).V).Put("fall", NewObj(1).Put("pop", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis894, int _argc886, V t_892, V s_893, V _a890, V _a891, V[] _rest887) => {
Invoke(Invoke(t_892, "to", ((V)(300D)), NewObj(1).Put("swirl", ((V)(1.5))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("io")));
Call(lookBack_30, V.Undef, t_892);
return default;
}, 2, "tail", true)).V).Put("chefbun", NewObj(9).Put("head", Fn((V _arrowThis903, int _argc895, V t_901, V s_902, V _a899, V _a900, V[] _rest896) => {
Invoke(Invoke(Invoke(t_901, "to", ((V)(300D)), Call(o_12, V.Undef, Call(both_11, V.Undef, ((V)((-4D))), ((V)((-30D)))), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("close", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(2).Put("armL", ((V)(140D))).Put("armR", ((V)(140D))).V, NewObj(2).Put("armL", ((V)(154D))).Put("armR", ((V)(154D))).V, ((V)("io"))), "to", ((V)(320D)), Call(o_12, V.Undef, NOHANDS_13, NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).V), ((V)("io")));
Call(happy_25, V.Undef, t_901, ((V)(1D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis912, int _argc904, V t_910, V s_911, V _a908, V _a909, V[] _rest905) => {
V k_913 = default;
k_913 = Call(S_9, V.Undef, s_911);
Call(see_18, V.Undef, t_910, ((V)("ear")), s_911, ((V)(80D)));
Invoke(t_910, "to", ((V)(260D)), NewObj(1).PutK(Get(k_913, "ear"), ((V)((-18D)))).V, ((V)("o")));
Call(armUp_27, V.Undef, t_910, s_911, ((V)(1D)), ((V)(145D)), NewObj(1).PutK(Get(k_913, "ear"), ((V)(0D))).V);
Call(unsee_19, V.Undef, t_910);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis922, int _argc914, V t_920, V s_921, V _a918, V _a919, V[] _rest915) => {
Invoke(t_920, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(lick_22, V.Undef, t_920, ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_920, "to", ((V)(400D)), NewObj(3).Put("close", ((V)(0.85))).Put("htilt", ((V)(6D))).Put("pitch", ((V)(0.1))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(140D)), NewObj(2).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(9).Put("armR", ((V)(80D))).Put("open", ((V)(0.2))).Put("mw", ((V)(1D))).Put("close", ((V)(0D))).Put("htilt", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("ly", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("pawR")), ((V)(3D))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis931, int _argc923, V t_929, V s_930, V _a927, V _a928, V[] _rest924) => {
Call(eyeRub_28, V.Undef, t_929, s_930);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis940, int _argc932, V t_938, V s_939, V _a936, V _a937, V[] _rest933) => {
Call(leanIn_24, V.Undef, t_938, s_939);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis949, int _argc941, V t_947, V s_948, V _a945, V _a946, V[] _rest942) => {
Invoke(t_947, "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D)));
Call(tickle_32, V.Undef, t_947);
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis958, int _argc950, V t_956, V s_957, V _a954, V _a955, V[] _rest951) => {
V k_959 = default;
Call(jelly_17, V.Undef, t_956, ((V)(3D)), ((V)(2D)), ((V)(300D)), ((V)("bend")));
Invoke(t_956, "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D)));
k_959 = Call(S_9, V.Undef, s_957);
Invoke(Invoke(Invoke(t_956, "to", ((V)(260D)), NewObj(1).PutK(Get(k_959, "arm"), ((V)(40D))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).PutK(Get(k_959, "arm"), ((V)(20D))).V, NewObj(1).PutK(Get(k_959, "arm"), ((V)(40D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).PutK(Get(k_959, "arm"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis968, int _argc960, V t_966, V s_967, V _a964, V _a965, V[] _rest961) => {
Call(hop_31, V.Undef, t_966, ((V)(5D)), Arr(Arr(((V)("emit")), ((V)("dust")), ((V)("footL")), ((V)(2D))), Arr(((V)("emit")), ((V)("dust")), ((V)("footR")), ((V)(2D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis977, int _argc969, V t_975, V s_976, V _a973, V _a974, V[] _rest970) => {
Invoke(t_975, "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D)));
Call(lookBack_30, V.Undef, t_975);
return default;
}, 2, "tail", true)).V).V;
TXT_36 = NewObj(9).Put("mallow", NewObj(9).Put("head", ((V)("Squashes like a marshmallow, rises back slowly, giggles."))).Put("ear", ((V)("Looks up at the dent and puffs back out."))).Put("nose", ((V)("Licks your finger: sweet! A heart."))).Put("eye", ((V)("Blinks hard and rubs the eye with a paw."))).Put("cheek", ((V)("Leans into your finger, soft as a pillow."))).Put("belly", ((V)("Ticklish: giggles, wobbling all over."))).Put("side", ((V)("Wobbles like jelly, looks at the spot, walks back."))).Put("foot", ((V)("Looks down at the foot, a tiny bounce."))).Put("tail", ((V)("A soft wobble, looks over the shoulder."))).V).Put("bao", NewObj(9).Put("head", ((V)("Steam puffs out of his knot, he giggles."))).Put("ear", ((V)("His pleats wiggle, a little steam."))).Put("nose", ((V)("Sniffs your finger, a warm steamy smile."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his doughy cheek squishing."))).Put("belly", ((V)("Doughy belly wobbles, he giggles, steam."))).Put("side", ((V)("Wobbles like soft dough, a puff of steam."))).Put("foot", ((V)("A little hop, steam puffs."))).Put("tail", ((V)("Steam puffs, he looks back."))).V).Put("dunkie", NewObj(9).Put("head", ((V)("Sprinkles bounce off his icing, he looks up, giggles."))).Put("ear", Fn((V _arrowThis985, int _argc978, V s_984, V _a981, V _a982, V _a983, V[] _rest979) => {
return ((V)((GtN(s_984, 0D) ? "Ouch, his bite mark! Reaches up and rubs it, then smiles." : "Looks up at the poke and giggles.")));
}, 1, "ear", true)).Put("nose", ((V)("Sniffs your finger and gives it a lick."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Rocks with giggles like a rolling wheel."))).Put("side", ((V)("Rolls away like a wheel, rolls back, giggles."))).Put("foot", ((V)("Hops, sprinkles fly."))).Put("tail", ((V)("Sprinkles drop off, he looks back."))).V).Put("frybo", NewObj(9).Put("head", ((V)("His fries squash down and spring back up, salt flies."))).Put("ear", ((V)("The fries flick, all of them wave, he giggles."))).Put("nose", ((V)("Sniffs your finger, hoping for ketchup, and grins."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his fries tipping with him."))).Put("belly", ((V)("Giggles, his fries rustling."))).Put("side", ((V)("His fries sway over and back, he looks at the spot."))).Put("foot", ((V)("Hops, salt sprinkles out."))).Put("tail", ((V)("His fries shiver, he looks back."))).V).Put("bunbun", NewObj(9).Put("head", ((V)("Top bun pressed down: a cheesy squeak, his layers pop apart and back."))).Put("ear", ((V)("His top bun tips and the layers fan out and settle."))).Put("nose", ((V)("Sniffs and licks: a little cheesy! A heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Ticklish: his layers shuffle as he giggles."))).Put("side", ((V)("His layers slide sideways, he pushes them back in line."))).Put("foot", ((V)("Hops, his layers lifting apart and back."))).Put("tail", ((V)("His layers lift a little, he looks back."))).V).Put("choco", NewObj(9).Put("head", ((V)("Snap! His segments flash, he stays firm, a giggle."))).Put("ear", Fn((V _arrowThis993, int _argc986, V s_992, V _a989, V _a990, V _a991, V[] _rest987) => {
return ((V)((GtN(s_992, 0D) ? "Ouch, his bite mark! Reaches up and rubs it." : "His segments flash, he looks up.")));
}, 1, "ear", true)).Put("nose", ((V)("Your warm finger makes him melt a little and blush, then he firms up."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in and goes a little melty."))).Put("belly", ((V)("Giggles and goes gooey."))).Put("side", ((V)("Wobbles, then snaps back stiff."))).Put("foot", ((V)("A crisp little hop."))).Put("tail", ((V)("His wrapper crinkles, he looks back."))).V).Put("scoop", NewObj(9).Put("head", ((V)("His cherry pops up and lands back, he giggles."))).Put("ear", ((V)("His cherry bobs side to side."))).Put("nose", ((V)("Licks your finger - brr, cold! - a shiver."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his cherry bobbing."))).Put("belly", ((V)("Giggles, cherry bopping."))).Put("side", ((V)("Wobbles on his cone, cherry bobbing, looks."))).Put("foot", ((V)("A little hop, the cherry lifts."))).Put("tail", ((V)("Cherry bobs, he looks back."))).V).Put("boba", NewObj(9).Put("head", ((V)("His straw pops up and the pearls jump, he giggles."))).Put("ear", Fn((V _arrowThis1001, int _argc994, V s_1000, V _a997, V _a998, V _a999, V[] _rest995) => {
return ((V)((GtN(s_1000, 0D) ? "His straw wiggles, he giggles." : "His pearls swirl round.")));
}, 1, "ear", true)).Put("nose", ((V)("Takes a sip through his straw, gulp, pearls swirl happily."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his pearls drifting over."))).Put("belly", ((V)("Pearls pop and swirl as he giggles."))).Put("side", ((V)("The pearls slosh away and back."))).Put("foot", ((V)("A hop, the pearls jump."))).Put("tail", ((V)("Pearls swirl, he looks back."))).V).Put("chefbun", NewObj(9).Put("head", ((V)("Holds his chef hat and straightens it."))).Put("ear", ((V)("His hat tips, he reaches up and sets it straight."))).Put("nose", ((V)("Tastes your finger, thinks about it, chef's kiss."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Giggles in a puff of flour."))).Put("side", ((V)("Wobbles and dusts the flour off."))).Put("foot", ((V)("A little hop, flour puffs."))).Put("tail", ((V)("A puff of flour, he looks back."))).V).V;
Call(build_26, V.Undef, RE_35, TXT_36, BODY_34);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
