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
armUp_27 = Fn((V _self1, int _argc58, V t_64, V s_65, V n_66, V a_67, V[] _rest59) => {
V k_69 = default;
V x_68 = default;
x_68 = (_argc58 > 4 ? _rest59[0] : V.Undef);
k_69 = Call(S_9, V.Undef, s_65);
a_67 = (a_67 is var _t70 && Truthy(_t70) ? _t70 : ((V)(150D)));
Invoke(t_64, "to", ((V)(300D)), Call(o_12, V.Undef, NewObj(1).PutK(Get(k_69, "arm"), a_67).V, (x_68 is var _t71 && Truthy(_t71) ? _t71 : NewObj(0).V)), ((V)("io")));
{
V i_72 = default;
i_72 = ((V)(0D));
while (true) {
if (!(Lt(i_72, (n_66 is var _t74 && Truthy(_t74) ? _t74 : ((V)(2D)))))) break;
Invoke(Invoke(t_64, "to", ((V)(170D)), NewObj(1).PutK(Get(k_69, "arm"), ((V)((ToNum(a_67) - 16D)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(1).PutK(Get(k_69, "arm"), a_67).V, ((V)("io")));
PostInc(ref i_72, 1D);
}
}
return Invoke(t_64, "to", ((V)(300D)), NewObj(3).PutK(Get(k_69, "arm"), ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
return default;
}, 5, "", true);
eyeRub_28 = Fn((V _self1, int _argc75, V t_81, V s_82, V _a79, V _a80, V[] _rest76) => {
V k_83 = default;
V h_84 = default;
k_83 = Call(S_9, V.Undef, s_82);
h_84 = Call(hand_10, V.Undef, s_82, ((V)(12D)), ((V)((-20D))));
Invoke(Invoke(t_81, "e", ((V)("blink2"))), "to", ((V)(300D)), Call(o_12, V.Undef, h_84, NewObj(2).PutK(Get(k_83, "arm"), ((V)(20D))).PutK(Get(k_83, "wink"), ((V)(1D))).V), ((V)("io")));
{
V i_85 = default;
i_85 = ((V)(0D));
while (true) {
if (!(LtN(i_85, 2D))) break;
Invoke(Invoke(t_81, "to", ((V)(170D)), NewObj(2).PutK(Get(k_83, "hx"), Add(GetK(h_84, Get(k_83, "hx")), ((V)((LtN(s_82, 0D) ? 3D : (-3D)))))).PutK(Get(k_83, "hy"), ((V)((ToNum(GetK(h_84, Get(k_83, "hy"))) - 1.5)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(2).PutK(Get(k_83, "hx"), GetK(h_84, Get(k_83, "hx"))).PutK(Get(k_83, "hy"), GetK(h_84, Get(k_83, "hy"))).V, ((V)("io")));
PostInc(ref i_85, 1D);
}
}
return Invoke(Invoke(t_81, "to", ((V)(300D)), NewObj(4).PutK(Get(k_83, "hx"), ((V)(0D))).PutK(Get(k_83, "hy"), ((V)(0D))).PutK(Get(k_83, "arm"), ((V)(0D))).PutK(Get(k_83, "wink"), ((V)(0D))).V, ((V)("io"))), "e", ((V)("blink")));
return default;
}, 2, "", true);
wobble_29 = Fn((V _self1, int _argc87, V t_93, V a_94, V ch_95, V _a92, V[] _rest88) => {
return Call(jelly_17, V.Undef, t_93, (a_94 is var _t96 && Truthy(_t96) ? _t96 : ((V)(0.12))), ((V)(3D)), ((V)(300D)), ch_95);
}, 3, "", true);
lookBack_30 = Fn((V _self1, int _argc97, V t_103, V hold_104, V _a101, V _a102, V[] _rest98) => {
Call(see_18, V.Undef, t_103, ((V)("tail")), ((V)(1D)), (hold_104 is var _t105 && Truthy(_t105) ? _t105 : ((V)(350D))));
return Call(unsee_19, V.Undef, t_103, ((V)(380D)));
return default;
}, 2, "", true);
hop_31 = Fn((V _self1, int _argc106, V t_112, V h_113, V ev_114, V _a111, V[] _rest107) => {
return Call(jump_14, V.Undef, t_112, NewObj(6).Put("h", (h_113 is var _t115 && Truthy(_t115) ? _t115 : ((V)(6D)))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).Put("ev", ev_114).V);
}, 3, "", true);
tickle_32 = Fn((V _self1, int _argc116, V t_122, V extra_123, V _a120, V _a121, V[] _rest117) => {
V a_124 = default;
Invoke(t_122, "to", ((V)(220D)), Call(o_12, V.Undef, Call(both_11, V.Undef, ((V)(8D)), ((V)((-4D)))), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
a_124 = Get(t_122, "t");
Call(giggle_20, V.Undef, t_122, ((V)(3D)), ((V)(0.9)));
if (Truthy(extra_123)) {
Call(para_23, V.Undef, t_122, a_124, extra_123);
}
return Invoke(t_122, "to", ((V)(260D)), NOHANDS_13, ((V)("io")));
return default;
}, 2, "", true);
tasteHeart_33 = Fn((V _self1, int _argc125, V t_131, V _a128, V _a129, V _a130, V[] _rest126) => {
Call(lick_22, V.Undef, t_131, ((V)(2D)));
return Invoke(Invoke(Invoke(Invoke(t_131, "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "wait", ((V)(320D))), "to", ((V)(220D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 1, "", true);
BODY_34 = NewObj(9).Put("mallow", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(3).Put("ear", ((V)("top corner"))).Put("nose", ((V)("Mouth"))).Put("tail", ((V)("Back"))).V).V).Put("bao", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(3).Put("ear", ((V)("pleats"))).Put("nose", ((V)("Mouth"))).Put("tail", ((V)("Back"))).V).V).Put("dunkie", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(3).Put("ear", Fn((V _self1, int _argc132, V s_138, V _a135, V _a136, V _a137, V[] _rest133) => {
return ((V)((GtN(s_138, 0D) ? "Bite mark" : "Left of his icing")));
}, 1, "ear", true)).Put("nose", ((V)("Mouth"))).Put("tail", ((V)("Back"))).V).V).Put("frybo", NewObj(2).Put("ear", ((V)(1D))).Put("lbl", NewObj(3).Put("ear", ((V)("fries"))).Put("nose", ((V)("Mouth"))).Put("tail", ((V)("Box"))).V).V).Put("bunbun", NewObj(3).Put("ear", ((V)(0.6))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("ear", ((V)("top bun"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Patty"))).Put("side", ((V)("side"))).Put("foot", ((V)("bottom bun"))).Put("tail", ((V)("Back"))).V).V).Put("choco", NewObj(2).Put("ear", ((V)(0.6))).Put("lbl", NewObj(4).Put("ear", Fn((V _self1, int _argc139, V s_145, V _a142, V _a143, V _a144, V[] _rest140) => {
return ((V)((GtN(s_145, 0D) ? "Bite mark" : "Left top corner")));
}, 1, "ear", true)).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Wrapper"))).Put("tail", ((V)("Wrapper (back)"))).V).V).Put("scoop", NewObj(3).Put("ear", ((V)(0.6))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("head", ((V)("Cherry"))).Put("ear", ((V)("scoop"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Cone"))).Put("foot", ((V)("cone tip"))).Put("tail", ((V)("Cone (back)"))).V).V).Put("boba", NewObj(3).Put("ear", ((V)(1D))).Put("hopBack", ((V)(1D))).Put("lbl", NewObj(6).Put("ear", Fn((V _self1, int _argc146, V s_152, V _a149, V _a150, V _a151, V[] _rest147) => {
return ((V)((GtN(s_152, 0D) ? "Straw" : "Left of his lid")));
}, 1, "ear", true)).Put("head", ((V)("Lid"))).Put("nose", ((V)("Mouth"))).Put("belly", ((V)("Pearls"))).Put("foot", ((V)("cup bottom"))).Put("tail", ((V)("Cup (back)"))).V).V).Put("chefbun", NewObj(2).Put("ear", ((V)(1D))).Put("lbl", NewObj(4).Put("head", ((V)("Chef hat"))).Put("ear", ((V)("side of his hat"))).Put("nose", ((V)("Mouth"))).Put("tail", ((V)("Back"))).V).V).V;
RE_35 = NewObj(9).Put("mallow", NewObj(9).Put("head", Fn((V _self1, int _argc153, V t_159, V s_160, V _a157, V _a158, V[] _rest154) => {
Invoke(Invoke(Invoke(t_159, "to", ((V)(260D)), NewObj(3).Put("sq", ((V)(0.3))).Put("close", ((V)(1D))).Put("hap", ((V)(0.6))).V, ((V)("io"))), "wait", ((V)(200D))), "to", ((V)(1300D)), NewObj(3).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).Put("hap", ((V)(0D))).V, ((V)("o")));
Call(giggle_20, V.Undef, t_159, ((V)(2D)), ((V)(0.8)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc161, V t_167, V s_168, V _a165, V _a166, V[] _rest162) => {
Call(see_18, V.Undef, t_167, ((V)("ear")), s_168, ((V)(150D)));
Invoke(Invoke(t_167, "to", ((V)(320D)), NewObj(2).Put("puff", ((V)(0.5))).Put("wide", ((V)(0.4))).V, ((V)("io"))), "to", ((V)(450D)), NewObj(2).Put("puff", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
Call(unsee_19, V.Undef, t_167);
Call(happy_25, V.Undef, t_167, ((V)(1D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc169, V t_175, V s_176, V _a173, V _a174, V[] _rest170) => {
Invoke(t_175, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.3))).V, ((V)("io")));
Call(tasteHeart_33, V.Undef, t_175);
Invoke(t_175, "to", ((V)(200D)), NewObj(1).Put("ly", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc177, V t_183, V s_184, V _a181, V _a182, V[] _rest178) => {
Call(eyeRub_28, V.Undef, t_183, s_184);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc185, V t_191, V s_192, V _a189, V _a190, V[] _rest186) => {
Call(leanIn_24, V.Undef, t_191, s_192, NewObj(1).Put("sq", ((V)(0.06))).V);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc193, V t_199, V s_200, V _a197, V _a198, V[] _rest194) => {
Call(tickle_32, V.Undef, t_199, Fn((V _self1, int _argc201, V u_207, V _a204, V _a205, V _a206, V[] _rest202) => {
return Call(jelly_17, V.Undef, u_207, ((V)(0.1)), ((V)(4D)), ((V)(280D)));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc208, V t_214, V s_215, V _a212, V _a213, V[] _rest209) => {
Call(jelly_17, V.Undef, t_214, ((V)(4D)), ((V)(3D)), ((V)(340D)), ((V)("bend")));
Call(see_18, V.Undef, t_214, ((V)("side")), s_215, ((V)(250D)));
Call(unsee_19, V.Undef, t_214, ((V)(350D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc216, V t_222, V s_223, V _a220, V _a221, V[] _rest217) => {
Call(see_18, V.Undef, t_222, ((V)("foot")), s_223, ((V)(200D)));
Invoke(t_222, "to", ((V)(260D)), NewObj(1).PutK(Get(Call(S_9, V.Undef, s_223), "foot"), ((V)(0D))).V, ((V)("io")));
Call(unsee_19, V.Undef, t_222);
Call(hop_31, V.Undef, t_222, ((V)(4D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc224, V t_230, V s_231, V _a228, V _a229, V[] _rest225) => {
Call(wobble_29, V.Undef, t_230, ((V)(0.14)));
Call(lookBack_30, V.Undef, t_230);
return default;
}, 2, "tail", true)).V).Put("bao", NewObj(9).Put("head", Fn((V _self1, int _argc232, V t_238, V s_239, V _a236, V _a237, V[] _rest233) => {
Invoke(Invoke(Invoke(t_238, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(5D))), "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(0.35))).Put("close", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("puff", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
Call(giggle_20, V.Undef, t_238, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc240, V t_246, V s_247, V _a244, V _a245, V[] _rest241) => {
Call(see_18, V.Undef, t_246, ((V)("ear")), s_247, ((V)(100D)));
Invoke(Invoke(t_246, "osc", ((V)(520D)), ((V)(2D)), NewObj(1).Put("htilt", ((V)((ToNum(s_247) * 5D)))).V, NewObj(1).Put("htilt", ((V)((ToNum(s_247) * 1D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
Call(unsee_19, V.Undef, t_246);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc248, V t_254, V s_255, V _a252, V _a253, V[] _rest249) => {
Invoke(t_254, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_21, V.Undef, t_254, ((V)(3D)));
Invoke(Invoke(Invoke(Invoke(t_254, "to", ((V)(240D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D))), "wait", ((V)(300D))), "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc256, V t_262, V s_263, V _a260, V _a261, V[] _rest257) => {
Call(eyeRub_28, V.Undef, t_262, s_263);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc264, V t_270, V s_271, V _a268, V _a269, V[] _rest265) => {
Call(leanIn_24, V.Undef, t_270, s_271, NewObj(1).Put("puff", ((V)(0.2))).V);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc272, V t_278, V s_279, V _a276, V _a277, V[] _rest273) => {
Call(tickle_32, V.Undef, t_278, Fn((V _self1, int _argc280, V u_286, V _a283, V _a284, V _a285, V[] _rest281) => {
return Call(jelly_17, V.Undef, u_286, ((V)(0.09)), ((V)(4D)), ((V)(260D)));
}, 1, "", true));
Invoke(t_278, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc287, V t_293, V s_294, V _a291, V _a292, V[] _rest288) => {
Call(jelly_17, V.Undef, t_293, ((V)(3D)), ((V)(3D)), ((V)(320D)), ((V)("bend")));
Invoke(t_293, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(2D)));
Call(see_18, V.Undef, t_293, ((V)("side")), s_294, ((V)(200D)));
Call(unsee_19, V.Undef, t_293, ((V)(320D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc295, V t_301, V s_302, V _a299, V _a300, V[] _rest296) => {
Call(hop_31, V.Undef, t_301, ((V)(5D)), Arr(Arr(((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc303, V t_309, V s_310, V _a307, V _a308, V[] _rest304) => {
Invoke(t_309, "e", ((V)("emit")), ((V)("steam")), ((V)("head")), ((V)(3D)));
Call(lookBack_30, V.Undef, t_309);
return default;
}, 2, "tail", true)).V).Put("dunkie", NewObj(9).Put("head", Fn((V _self1, int _argc311, V t_317, V s_318, V _a315, V _a316, V[] _rest312) => {
Invoke(t_317, "e", ((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(4D)));
Call(see_18, V.Undef, t_317, ((V)("head")), s_318, ((V)(200D)));
Call(unsee_19, V.Undef, t_317, ((V)(300D)));
Call(giggle_20, V.Undef, t_317, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc319, V t_325, V s_326, V _a323, V _a324, V[] _rest320) => {
if (GtN(s_326, 0D)) {
Call(see_18, V.Undef, t_325, ((V)("ear")), s_326, ((V)(100D)));
Invoke(t_325, "to", ((V)(220D)), NewObj(3).Put("frown", ((V)(0.45))).Put("puff", ((V)(0.3))).Put("wide", ((V)(0.4))).V, ((V)("io")));
Call(armUp_27, V.Undef, t_325, ((V)(1D)), ((V)(2D)), ((V)(132D)));
Call(unsee_19, V.Undef, t_325);
Invoke(Invoke(t_325, "to", ((V)(250D)), NewObj(5).Put("frown", ((V)(0D))).Put("puff", ((V)(0D))).Put("wide", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(250D)));
} else {
Call(see_18, V.Undef, t_325, ((V)("ear")), s_326, ((V)(150D)));
Call(unsee_19, V.Undef, t_325);
Call(giggle_20, V.Undef, t_325, ((V)(2D)));
}
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc327, V t_333, V s_334, V _a331, V _a332, V[] _rest328) => {
Invoke(t_333, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_21, V.Undef, t_333, ((V)(2D)));
Call(tasteHeart_33, V.Undef, t_333);
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc335, V t_341, V s_342, V _a339, V _a340, V[] _rest336) => {
Call(eyeRub_28, V.Undef, t_341, s_342);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc343, V t_349, V s_350, V _a347, V _a348, V[] _rest344) => {
Call(leanIn_24, V.Undef, t_349, s_350);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc351, V t_357, V s_358, V _a355, V _a356, V[] _rest352) => {
Call(tickle_32, V.Undef, t_357, Fn((V _self1, int _argc359, V u_365, V _a362, V _a363, V _a364, V[] _rest360) => {
return Call(swing_16, V.Undef, u_365, ((V)(900D)), ((V)(3D)), NewObj(2).Put("tilt", ((V)(8D))).Put("x", ((V)(2D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc366, V t_372, V s_373, V _a370, V _a371, V[] _rest367) => {
V d_374 = default;
d_374 = ((V)((-ToNum(s_373))));
Invoke(Invoke(Invoke(Invoke(t_372, "to", ((V)(420D)), NewObj(3).Put("x", ((V)((ToNum(d_374) * 6D)))).Put("tilt", ((V)((ToNum(d_374) * 24D)))).Put("wide", ((V)(0.6))).V, ((V)("io"))), "to", ((V)(380D)), NewObj(1).Put("tilt", ((V)((ToNum(d_374) * 18D)))).V, ((V)("io"))), "to", ((V)(520D)), NewObj(3).Put("x", ((V)(0D))).Put("tilt", ((V)(((-ToNum(d_374)) * 3D)))).Put("wide", ((V)(0D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).Put("tilt", ((V)(0D))).V, ((V)("io")));
Call(giggle_20, V.Undef, t_372, ((V)(2D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc375, V t_381, V s_382, V _a379, V _a380, V[] _rest376) => {
Call(hop_31, V.Undef, t_381, ((V)(6D)), Arr(Arr(((V)("emit")), ((V)("sprinkle")), ((V)("head")), ((V)(4D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc383, V t_389, V s_390, V _a387, V _a388, V[] _rest384) => {
Invoke(t_389, "e", ((V)("emit")), ((V)("sprinkle")), ((V)("body")), ((V)(3D)));
Call(lookBack_30, V.Undef, t_389);
return default;
}, 2, "tail", true)).V).Put("frybo", NewObj(9).Put("head", Fn((V _self1, int _argc391, V t_397, V s_398, V _a395, V _a396, V[] _rest392) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_397, "to", ((V)(120D)), NewObj(3).Put("earL", ((V)(12D))).Put("earR", ((V)(12D))).Put("fw", ((V)(0.6))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(3).Put("earL", ((V)((-16D)))).Put("earR", ((V)((-16D)))).Put("sq", ((V)((-0.1)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(5D))), "to", ((V)(240D)), NewObj(3).Put("earL", ((V)(3D))).Put("earR", ((V)(3D))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(4).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("sq", ((V)(0D))).Put("fw", ((V)(0D))).V, ((V)("io")));
Call(giggle_20, V.Undef, t_397, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc399, V t_405, V s_406, V _a403, V _a404, V[] _rest400) => {
V a_407 = default;
a_407 = Get(t_405, "t");
Invoke(Invoke(t_405, "to", ((V)(500D)), NewObj(1).Put("fw", ((V)(1.3))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("fw", ((V)(0D))).V, ((V)("io")));
Call(para_23, V.Undef, t_405, a_407, Fn((V _self1, int _argc408, V u_414, V _a411, V _a412, V _a413, V[] _rest409) => {
Call(see_18, V.Undef, u_414, ((V)("ear")), s_406, ((V)(120D)));
Call(unsee_19, V.Undef, u_414);
return default;
}, 1, "", true));
Call(giggle_20, V.Undef, t_405, ((V)(2D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc415, V t_421, V s_422, V _a419, V _a420, V[] _rest416) => {
Invoke(t_421, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_21, V.Undef, t_421, ((V)(3D)));
Invoke(Invoke(Invoke(t_421, "to", ((V)(260D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).Put("ly", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(220D)), NewObj(3).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc423, V t_429, V s_430, V _a427, V _a428, V[] _rest424) => {
Call(eyeRub_28, V.Undef, t_429, s_430);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc431, V t_437, V s_438, V _a435, V _a436, V[] _rest432) => {
Call(leanIn_24, V.Undef, t_437, s_438, NewObj(2).Put("earL", ((V)(((-ToNum(s_438)) * 6D)))).Put("earR", ((V)(((-ToNum(s_438)) * 6D)))).V);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc439, V t_445, V s_446, V _a443, V _a444, V[] _rest440) => {
Call(tickle_32, V.Undef, t_445, Fn((V _self1, int _argc447, V u_453, V _a450, V _a451, V _a452, V[] _rest448) => {
return Invoke(Invoke(u_453, "to", ((V)(500D)), NewObj(1).Put("fw", ((V)(1D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(1).Put("fw", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc454, V t_460, V s_461, V _a458, V _a459, V[] _rest455) => {
V a_462 = default;
a_462 = Get(t_460, "t");
Invoke(Invoke(Invoke(t_460, "to", ((V)(300D)), NewObj(2).Put("earL", ((V)(((-ToNum(s_461)) * 14D)))).Put("earR", ((V)(((-ToNum(s_461)) * 14D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("earL", ((V)((ToNum(s_461) * 6D)))).Put("earR", ((V)((ToNum(s_461) * 6D)))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(para_23, V.Undef, t_460, a_462, Fn((V _self1, int _argc463, V u_469, V _a466, V _a467, V _a468, V[] _rest464) => {
Call(see_18, V.Undef, u_469, ((V)("side")), s_461, ((V)(200D)));
Call(unsee_19, V.Undef, u_469, ((V)(300D)));
return default;
}, 1, "", true));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc470, V t_476, V s_477, V _a474, V _a475, V[] _rest471) => {
Call(hop_31, V.Undef, t_476, ((V)(7D)), Arr(Arr(((V)("emit")), ((V)("salt")), ((V)("head")), ((V)(4D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc478, V t_484, V s_485, V _a482, V _a483, V[] _rest479) => {
Invoke(Invoke(t_484, "osc", ((V)(420D)), ((V)(3D)), NewObj(2).Put("earL", ((V)(5D))).Put("earR", ((V)((-5D)))).V, NewObj(2).Put("earL", ((V)((-5D)))).Put("earR", ((V)(5D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(2).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
Call(lookBack_30, V.Undef, t_484);
return default;
}, 2, "tail", true)).V).Put("bunbun", NewObj(9).Put("head", Fn((V _self1, int _argc486, V t_492, V s_493, V _a490, V _a491, V[] _rest487) => {
Invoke(Invoke(Invoke(Invoke(t_492, "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0.2))).Put("fan", ((V)(0.3))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head")), ((V)(1D))), "to", ((V)(160D)), NewObj(3).Put("sq", ((V)((-0.08)))).Put("split", ((V)(0.5))).Put("fan", ((V)(0D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(2).Put("sq", ((V)(0D))).Put("split", ((V)(0D))).V, ((V)("io")));
Call(giggle_20, V.Undef, t_492, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc494, V t_500, V s_501, V _a498, V _a499, V[] _rest495) => {
Call(see_18, V.Undef, t_500, ((V)("ear")), s_501, ((V)(100D)));
Invoke(Invoke(Invoke(t_500, "to", ((V)(240D)), NewObj(1).Put("fan", ((V)((ToNum(s_501) * 0.9)))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("fan", ((V)(((-ToNum(s_501)) * 0.3)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(1).Put("fan", ((V)(0D))).V, ((V)("io")));
Call(unsee_19, V.Undef, t_500);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc502, V t_508, V s_509, V _a506, V _a507, V[] _rest503) => {
Invoke(t_508, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_21, V.Undef, t_508, ((V)(2D)));
Call(tasteHeart_33, V.Undef, t_508);
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc510, V t_516, V s_517, V _a514, V _a515, V[] _rest511) => {
Call(eyeRub_28, V.Undef, t_516, s_517);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc518, V t_524, V s_525, V _a522, V _a523, V[] _rest519) => {
Call(leanIn_24, V.Undef, t_524, s_525);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc526, V t_532, V s_533, V _a530, V _a531, V[] _rest527) => {
Call(tickle_32, V.Undef, t_532, Fn((V _self1, int _argc534, V u_540, V _a537, V _a538, V _a539, V[] _rest535) => {
return Invoke(Invoke(u_540, "osc", ((V)(900D)), ((V)(3D)), NewObj(1).Put("shuf", ((V)(0.6))).V, NewObj(1).Put("shuf", ((V)((-0.6)))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).Put("shuf", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc541, V t_547, V s_548, V _a545, V _a546, V[] _rest542) => {
Invoke(t_547, "to", ((V)(200D)), NewObj(2).Put("shuf", ((V)(((-ToNum(s_548)) * 0.9)))).Put("wide", ((V)(0.5))).V, ((V)("o")));
Call(see_18, V.Undef, t_547, ((V)("side")), s_548, ((V)(100D)));
Invoke(Invoke(t_547, "to", ((V)(300D)), Call(o_12, V.Undef, Call(both_11, V.Undef, ((V)(9D)), ((V)(2D))), NewObj(1).Put("shuf", ((V)(((-ToNum(s_548)) * 0.4)))).V), ((V)("io"))), "to", ((V)(300D)), Call(o_12, V.Undef, NOHANDS_13, NewObj(2).Put("shuf", ((V)(0D))).Put("wide", ((V)(0D))).V), ((V)("io")));
Call(unsee_19, V.Undef, t_547, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc549, V t_555, V s_556, V _a553, V _a554, V[] _rest550) => {
Call(jump_14, V.Undef, t_555, NewObj(7).Put("h", ((V)(7D))).Put("ant", ((V)(140D))).Put("up", ((V)(200D))).Put("c", ((V)(0.14))).Put("arm", ((V)(40D))).Put("air", NewObj(1).Put("split", ((V)(0.5))).V).Put("fall", NewObj(1).Put("split", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc557, V t_563, V s_564, V _a561, V _a562, V[] _rest558) => {
Invoke(Invoke(t_563, "to", ((V)(160D)), NewObj(1).Put("split", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("split", ((V)(0D))).V, ((V)("io")));
Call(lookBack_30, V.Undef, t_563);
return default;
}, 2, "tail", true)).V).Put("choco", NewObj(9).Put("head", Fn((V _self1, int _argc565, V t_571, V s_572, V _a569, V _a570, V[] _rest566) => {
Invoke(Invoke(Invoke(Invoke(t_571, "to", ((V)(80D)), NewObj(1).Put("tw", ((V)(1.2))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("head")), ((V)(2D))), "wait", ((V)(200D))), "to", ((V)(300D)), NewObj(1).Put("tw", ((V)(0D))).V, ((V)("io")));
Call(giggle_20, V.Undef, t_571, ((V)(1D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc573, V t_579, V s_580, V _a577, V _a578, V[] _rest574) => {
if (GtN(s_580, 0D)) {
Call(see_18, V.Undef, t_579, ((V)("ear")), s_580, ((V)(100D)));
Invoke(t_579, "to", ((V)(220D)), NewObj(2).Put("frown", ((V)(0.4))).Put("puff", ((V)(0.3))).V, ((V)("io")));
Call(armUp_27, V.Undef, t_579, ((V)(1D)), ((V)(2D)), ((V)(132D)));
Call(unsee_19, V.Undef, t_579);
Invoke(Invoke(t_579, "to", ((V)(250D)), NewObj(4).Put("frown", ((V)(0D))).Put("puff", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(200D)));
} else {
Invoke(Invoke(Invoke(t_579, "to", ((V)(80D)), NewObj(1).Put("tw", ((V)(1D))).V, ((V)("o"))), "wait", ((V)(150D))), "to", ((V)(300D)), NewObj(1).Put("tw", ((V)(0D))).V, ((V)("io")));
Call(see_18, V.Undef, t_579, ((V)("ear")), s_580, ((V)(150D)));
Call(unsee_19, V.Undef, t_579);
}
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc581, V t_587, V s_588, V _a585, V _a586, V[] _rest582) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_587, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(700D)), NewObj(4).Put("melt", ((V)(0.45))).Put("blush", ((V)(0.8))).Put("sq", ((V)(0.05))).Put("close", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(140D)), NewObj(4).Put("melt", ((V)(0D))).Put("sq", ((V)((-0.05)))).Put("tw", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0D))).Put("tw", ((V)(0D))).Put("blush", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc589, V t_595, V s_596, V _a593, V _a594, V[] _rest590) => {
Call(eyeRub_28, V.Undef, t_595, s_596);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc597, V t_603, V s_604, V _a601, V _a602, V[] _rest598) => {
Call(leanIn_24, V.Undef, t_603, s_604, NewObj(1).Put("melt", ((V)(0.3))).V);
Invoke(t_603, "to", ((V)(250D)), NewObj(1).Put("melt", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc605, V t_611, V s_612, V _a609, V _a610, V[] _rest606) => {
Call(tickle_32, V.Undef, t_611, Fn((V _self1, int _argc613, V u_619, V _a616, V _a617, V _a618, V[] _rest614) => {
return Invoke(Invoke(u_619, "to", ((V)(600D)), NewObj(1).Put("melt", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("melt", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc620, V t_626, V s_627, V _a624, V _a625, V[] _rest621) => {
Call(jelly_17, V.Undef, t_626, ((V)(3D)), ((V)(2D)), ((V)(300D)), ((V)("bend")));
Invoke(Invoke(t_626, "to", ((V)(80D)), NewObj(1).Put("tw", ((V)(1D))).V, ((V)("o"))), "to", ((V)(300D)), NewObj(1).Put("tw", ((V)(0D))).V, ((V)("io")));
Call(see_18, V.Undef, t_626, ((V)("side")), s_627, ((V)(200D)));
Call(unsee_19, V.Undef, t_626, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc628, V t_634, V s_635, V _a632, V _a633, V[] _rest629) => {
Call(hop_31, V.Undef, t_634, ((V)(5D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc636, V t_642, V s_643, V _a640, V _a641, V[] _rest637) => {
Invoke(Invoke(t_642, "to", ((V)(200D)), NewObj(1).Put("wrap", ((V)(0.35))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(1).Put("wrap", ((V)(0.1))).V, ((V)("io")));
Call(lookBack_30, V.Undef, t_642, ((V)(250D)));
Invoke(t_642, "to", ((V)(260D)), NewObj(1).Put("wrap", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "tail", true)).V).Put("scoop", NewObj(9).Put("head", Fn((V _self1, int _argc644, V t_650, V s_651, V _a648, V _a649, V[] _rest645) => {
Invoke(Invoke(t_650, "to", ((V)(150D)), NewObj(1).Put("chy", ((V)(1D))).V, ((V)("o"))), "to", ((V)(280D)), NewObj(1).Put("chy", ((V)(0D))).V, ((V)("i")));
Call(see_18, V.Undef, t_650, ((V)("head")), s_651, ((V)(150D)));
Call(unsee_19, V.Undef, t_650);
Call(giggle_20, V.Undef, t_650, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc652, V t_658, V s_659, V _a656, V _a657, V[] _rest653) => {
Call(see_18, V.Undef, t_658, ((V)("ear")), s_659, ((V)(100D)));
Invoke(t_658, "osc", ((V)(600D)), ((V)(3D)), NewObj(2).Put("chb", ((V)(1D))).Put("htilt", ((V)((ToNum(s_659) * 3D)))).V, NewObj(2).Put("chb", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
Call(unsee_19, V.Undef, t_658);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc660, V t_666, V s_667, V _a664, V _a665, V[] _rest661) => {
Invoke(t_666, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(lick_22, V.Undef, t_666, ((V)(2D)));
Invoke(t_666, "to", ((V)(150D)), NewObj(1).Put("close", ((V)(0.4))).V, ((V)("io")));
Call(shake_15, V.Undef, t_666, NewObj(6).Put("P", ((V)(70D))).Put("env", Arr(((V)(0.5)), ((V)(1D)), ((V)(0.7)), ((V)(0.35)))).Put("head", ((V)(0.1))).Put("roll", ((V)(2D))).Put("ear", ((V)(0D))).Put("body", ((V)(0.5))).V);
Invoke(Invoke(t_666, "to", ((V)(260D)), NewObj(4).Put("close", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(200D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc668, V t_674, V s_675, V _a672, V _a673, V[] _rest669) => {
Call(eyeRub_28, V.Undef, t_674, s_675);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc676, V t_682, V s_683, V _a680, V _a681, V[] _rest677) => {
Call(leanIn_24, V.Undef, t_682, s_683, NewObj(1).Put("chb", ((V)(0.6))).V);
Invoke(t_682, "to", ((V)(200D)), NewObj(1).Put("chb", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc684, V t_690, V s_691, V _a688, V _a689, V[] _rest685) => {
Call(tickle_32, V.Undef, t_690, Fn((V _self1, int _argc692, V u_698, V _a695, V _a696, V _a697, V[] _rest693) => {
return Invoke(u_698, "osc", ((V)(900D)), ((V)(4D)), NewObj(1).Put("chb", ((V)(1D))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc699, V t_705, V s_706, V _a703, V _a704, V[] _rest700) => {
V d_707 = default;
d_707 = ((V)((-ToNum(s_706))));
Invoke(Invoke(Invoke(t_705, "to", ((V)(260D)), NewObj(2).Put("tilt", ((V)((ToNum(d_707) * 9D)))).Put("chb", ((V)(1D))).V, ((V)("o"))), "to", ((V)(320D)), NewObj(2).Put("tilt", ((V)(((-ToNum(d_707)) * 4D)))).Put("chb", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("tilt", ((V)(0D))).Put("chb", ((V)(0D))).V, ((V)("io")));
Call(see_18, V.Undef, t_705, ((V)("side")), s_706, ((V)(200D)));
Call(unsee_19, V.Undef, t_705, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc708, V t_714, V s_715, V _a712, V _a713, V[] _rest709) => {
Call(jump_14, V.Undef, t_714, NewObj(7).Put("h", ((V)(5D))).Put("ant", ((V)(140D))).Put("up", ((V)(180D))).Put("c", ((V)(0.12))).Put("arm", ((V)(35D))).Put("air", NewObj(1).Put("chy", ((V)(0.6))).V).Put("fall", NewObj(1).Put("chy", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc716, V t_722, V s_723, V _a720, V _a721, V[] _rest717) => {
Invoke(t_722, "osc", ((V)(360D)), ((V)(2D)), NewObj(1).Put("chb", ((V)(1D))).V, NewObj(1).Put("chb", ((V)(0D))).V, ((V)("io")));
Call(lookBack_30, V.Undef, t_722);
return default;
}, 2, "tail", true)).V).Put("boba", NewObj(9).Put("head", Fn((V _self1, int _argc724, V t_730, V s_731, V _a728, V _a729, V[] _rest725) => {
Invoke(Invoke(Invoke(t_730, "to", ((V)(90D)), NewObj(2).Put("sup", ((V)(1.1))).Put("pop", ((V)(1.6))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(400D)), NewObj(2).Put("sup", ((V)(0D))).Put("pop", ((V)(0D))).V, ((V)("io")));
Call(giggle_20, V.Undef, t_730, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc732, V t_738, V s_739, V _a736, V _a737, V[] _rest733) => {
Call(see_18, V.Undef, t_738, ((V)("ear")), s_739, ((V)(100D)));
if (GtN(s_739, 0D)) {
Invoke(Invoke(t_738, "to", ((V)(500D)), NewObj(1).Put("stw", ((V)(1.6))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("stw", ((V)(0D))).V, ((V)("io")));
} else {
Invoke(Invoke(t_738, "to", ((V)(400D)), NewObj(1).Put("swirl", ((V)((-1.5)))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("io")));
}
Call(unsee_19, V.Undef, t_738);
if (GtN(s_739, 0D)) {
Call(giggle_20, V.Undef, t_738, ((V)(2D)));
}
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc740, V t_746, V s_747, V _a744, V _a745, V[] _rest741) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_746, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(2).Put("slurp", ((V)(1D))).Put("mw", ((V)(0.5))).V, ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(200D)), NewObj(2).Put("slurp", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io"))), "e", ((V)("gulp")));
Invoke(Invoke(Invoke(t_746, "to", ((V)(260D)), NewObj(4).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("swirl", ((V)(1.2))).Put("ly", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(300D)), NewObj(3).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("swirl", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc748, V t_754, V s_755, V _a752, V _a753, V[] _rest749) => {
Call(eyeRub_28, V.Undef, t_754, s_755);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc756, V t_762, V s_763, V _a760, V _a761, V[] _rest757) => {
Call(leanIn_24, V.Undef, t_762, s_763, NewObj(1).Put("swirl", ((V)((ToNum(s_763) * 1D)))).V);
Invoke(t_762, "to", ((V)(200D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc764, V t_770, V s_771, V _a768, V _a769, V[] _rest765) => {
Call(tickle_32, V.Undef, t_770, Fn((V _self1, int _argc772, V u_778, V _a775, V _a776, V _a777, V[] _rest773) => {
return Invoke(Invoke(u_778, "to", ((V)(300D)), NewObj(2).Put("pop", ((V)(1.4))).Put("swirl", ((V)(1.5))).V, ((V)("o"))), "to", ((V)(700D)), NewObj(2).Put("pop", ((V)(0D))).Put("swirl", ((V)(0D))).V, ((V)("io")));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc779, V t_785, V s_786, V _a783, V _a784, V[] _rest780) => {
Invoke(Invoke(Invoke(t_785, "to", ((V)(300D)), NewObj(1).Put("swirl", ((V)(((-ToNum(s_786)) * 2.2)))).V, ((V)("o"))), "to", ((V)(500D)), NewObj(1).Put("swirl", ((V)((ToNum(s_786) * 0.8)))).V, ((V)("io"))), "to", ((V)(400D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("io")));
Call(see_18, V.Undef, t_785, ((V)("side")), s_786, ((V)(150D)));
Call(unsee_19, V.Undef, t_785, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc787, V t_793, V s_794, V _a791, V _a792, V[] _rest788) => {
Call(jump_14, V.Undef, t_793, NewObj(7).Put("h", ((V)(6D))).Put("ant", ((V)(140D))).Put("up", ((V)(190D))).Put("c", ((V)(0.12))).Put("arm", ((V)(35D))).Put("air", NewObj(1).Put("pop", ((V)(1.5))).V).Put("fall", NewObj(1).Put("pop", ((V)(0D))).V).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc795, V t_801, V s_802, V _a799, V _a800, V[] _rest796) => {
Invoke(Invoke(t_801, "to", ((V)(300D)), NewObj(1).Put("swirl", ((V)(1.5))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(1).Put("swirl", ((V)(0D))).V, ((V)("io")));
Call(lookBack_30, V.Undef, t_801);
return default;
}, 2, "tail", true)).V).Put("chefbun", NewObj(9).Put("head", Fn((V _self1, int _argc803, V t_809, V s_810, V _a807, V _a808, V[] _rest804) => {
Invoke(Invoke(Invoke(t_809, "to", ((V)(300D)), Call(o_12, V.Undef, Call(both_11, V.Undef, ((V)((-4D))), ((V)((-30D)))), NewObj(3).Put("armL", ((V)(150D))).Put("armR", ((V)(150D))).Put("close", ((V)(0.6))).V), ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(2).Put("armL", ((V)(140D))).Put("armR", ((V)(140D))).V, NewObj(2).Put("armL", ((V)(154D))).Put("armR", ((V)(154D))).V, ((V)("io"))), "to", ((V)(320D)), Call(o_12, V.Undef, NOHANDS_13, NewObj(3).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("close", ((V)(0D))).V), ((V)("io")));
Call(happy_25, V.Undef, t_809, ((V)(1D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc811, V t_817, V s_818, V _a815, V _a816, V[] _rest812) => {
V k_819 = default;
k_819 = Call(S_9, V.Undef, s_818);
Call(see_18, V.Undef, t_817, ((V)("ear")), s_818, ((V)(80D)));
Invoke(t_817, "to", ((V)(260D)), NewObj(1).PutK(Get(k_819, "ear"), ((V)((-18D)))).V, ((V)("o")));
Call(armUp_27, V.Undef, t_817, s_818, ((V)(1D)), ((V)(145D)), NewObj(1).PutK(Get(k_819, "ear"), ((V)(0D))).V);
Call(unsee_19, V.Undef, t_817);
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc820, V t_826, V s_827, V _a824, V _a825, V[] _rest821) => {
Invoke(t_826, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(lick_22, V.Undef, t_826, ((V)(1D)));
Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_826, "to", ((V)(400D)), NewObj(3).Put("close", ((V)(0.85))).Put("htilt", ((V)(6D))).Put("pitch", ((V)(0.1))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(140D)), NewObj(2).Put("open", ((V)(0.3))).Put("mw", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(260D)), NewObj(9).Put("armR", ((V)(80D))).Put("open", ((V)(0.2))).Put("mw", ((V)(1D))).Put("close", ((V)(0D))).Put("htilt", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("ly", ((V)(0D))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("spark")), ((V)("pawR")), ((V)(3D))), "wait", ((V)(250D))), "to", ((V)(300D)), NewObj(4).Put("armR", ((V)(0D))).Put("hap", ((V)(0D))).Put("smile", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc828, V t_834, V s_835, V _a832, V _a833, V[] _rest829) => {
Call(eyeRub_28, V.Undef, t_834, s_835);
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc836, V t_842, V s_843, V _a840, V _a841, V[] _rest837) => {
Call(leanIn_24, V.Undef, t_842, s_843);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc844, V t_850, V s_851, V _a848, V _a849, V[] _rest845) => {
Invoke(t_850, "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D)));
Call(tickle_32, V.Undef, t_850);
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc852, V t_858, V s_859, V _a856, V _a857, V[] _rest853) => {
V k_860 = default;
Call(jelly_17, V.Undef, t_858, ((V)(3D)), ((V)(2D)), ((V)(300D)), ((V)("bend")));
Invoke(t_858, "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D)));
k_860 = Call(S_9, V.Undef, s_859);
Invoke(Invoke(Invoke(t_858, "to", ((V)(260D)), NewObj(1).PutK(Get(k_860, "arm"), ((V)(40D))).V, ((V)("io"))), "osc", ((V)(500D)), ((V)(2D)), NewObj(1).PutK(Get(k_860, "arm"), ((V)(20D))).V, NewObj(1).PutK(Get(k_860, "arm"), ((V)(40D))).V, ((V)("io"))), "to", ((V)(260D)), NewObj(1).PutK(Get(k_860, "arm"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc861, V t_867, V s_868, V _a865, V _a866, V[] _rest862) => {
Call(hop_31, V.Undef, t_867, ((V)(5D)), Arr(Arr(((V)("emit")), ((V)("dust")), ((V)("footL")), ((V)(2D))), Arr(((V)("emit")), ((V)("dust")), ((V)("footR")), ((V)(2D)))));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc869, V t_875, V s_876, V _a873, V _a874, V[] _rest870) => {
Invoke(t_875, "e", ((V)("emit")), ((V)("dust")), ((V)("body")), ((V)(2D)));
Call(lookBack_30, V.Undef, t_875);
return default;
}, 2, "tail", true)).V).V;
TXT_36 = NewObj(9).Put("mallow", NewObj(9).Put("head", ((V)("Squashes like a marshmallow, rises back slowly, giggles."))).Put("ear", ((V)("Looks up at the dent and puffs back out."))).Put("nose", ((V)("Licks your finger: sweet! A heart."))).Put("eye", ((V)("Blinks hard and rubs the eye with a paw."))).Put("cheek", ((V)("Leans into your finger, soft as a pillow."))).Put("belly", ((V)("Ticklish: giggles, wobbling all over."))).Put("side", ((V)("Wobbles like jelly, looks at the spot, walks back."))).Put("foot", ((V)("Looks down at the foot, a tiny bounce."))).Put("tail", ((V)("A soft wobble, looks over the shoulder."))).V).Put("bao", NewObj(9).Put("head", ((V)("Steam puffs out of his knot, he giggles."))).Put("ear", ((V)("His pleats wiggle, a little steam."))).Put("nose", ((V)("Sniffs your finger, a warm steamy smile."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his doughy cheek squishing."))).Put("belly", ((V)("Doughy belly wobbles, he giggles, steam."))).Put("side", ((V)("Wobbles like soft dough, a puff of steam."))).Put("foot", ((V)("A little hop, steam puffs."))).Put("tail", ((V)("Steam puffs, he looks back."))).V).Put("dunkie", NewObj(9).Put("head", ((V)("Sprinkles bounce off his icing, he looks up, giggles."))).Put("ear", Fn((V _self1, int _argc877, V s_883, V _a880, V _a881, V _a882, V[] _rest878) => {
return ((V)((GtN(s_883, 0D) ? "Ouch, his bite mark! Reaches up and rubs it, then smiles." : "Looks up at the poke and giggles.")));
}, 1, "ear", true)).Put("nose", ((V)("Sniffs your finger and gives it a lick."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Rocks with giggles like a rolling wheel."))).Put("side", ((V)("Rolls away like a wheel, rolls back, giggles."))).Put("foot", ((V)("Hops, sprinkles fly."))).Put("tail", ((V)("Sprinkles drop off, he looks back."))).V).Put("frybo", NewObj(9).Put("head", ((V)("His fries squash down and spring back up, salt flies."))).Put("ear", ((V)("The fries flick, all of them wave, he giggles."))).Put("nose", ((V)("Sniffs your finger, hoping for ketchup, and grins."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his fries tipping with him."))).Put("belly", ((V)("Giggles, his fries rustling."))).Put("side", ((V)("His fries sway over and back, he looks at the spot."))).Put("foot", ((V)("Hops, salt sprinkles out."))).Put("tail", ((V)("His fries shiver, he looks back."))).V).Put("bunbun", NewObj(9).Put("head", ((V)("Top bun pressed down: a cheesy squeak, his layers pop apart and back."))).Put("ear", ((V)("His top bun tips and the layers fan out and settle."))).Put("nose", ((V)("Sniffs and licks: a little cheesy! A heart."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Ticklish: his layers shuffle as he giggles."))).Put("side", ((V)("His layers slide sideways, he pushes them back in line."))).Put("foot", ((V)("Hops, his layers lifting apart and back."))).Put("tail", ((V)("His layers lift a little, he looks back."))).V).Put("choco", NewObj(9).Put("head", ((V)("Snap! His segments flash, he stays firm, a giggle."))).Put("ear", Fn((V _self1, int _argc884, V s_890, V _a887, V _a888, V _a889, V[] _rest885) => {
return ((V)((GtN(s_890, 0D) ? "Ouch, his bite mark! Reaches up and rubs it." : "His segments flash, he looks up.")));
}, 1, "ear", true)).Put("nose", ((V)("Your warm finger makes him melt a little and blush, then he firms up."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in and goes a little melty."))).Put("belly", ((V)("Giggles and goes gooey."))).Put("side", ((V)("Wobbles, then snaps back stiff."))).Put("foot", ((V)("A crisp little hop."))).Put("tail", ((V)("His wrapper crinkles, he looks back."))).V).Put("scoop", NewObj(9).Put("head", ((V)("His cherry pops up and lands back, he giggles."))).Put("ear", ((V)("His cherry bobs side to side."))).Put("nose", ((V)("Licks your finger - brr, cold! - a shiver."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his cherry bobbing."))).Put("belly", ((V)("Giggles, cherry bopping."))).Put("side", ((V)("Wobbles on his cone, cherry bobbing, looks."))).Put("foot", ((V)("A little hop, the cherry lifts."))).Put("tail", ((V)("Cherry bobs, he looks back."))).V).Put("boba", NewObj(9).Put("head", ((V)("His straw pops up and the pearls jump, he giggles."))).Put("ear", Fn((V _self1, int _argc891, V s_897, V _a894, V _a895, V _a896, V[] _rest892) => {
return ((V)((GtN(s_897, 0D) ? "His straw wiggles, he giggles." : "His pearls swirl round.")));
}, 1, "ear", true)).Put("nose", ((V)("Takes a sip through his straw, gulp, pearls swirl happily."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans in, his pearls drifting over."))).Put("belly", ((V)("Pearls pop and swirl as he giggles."))).Put("side", ((V)("The pearls slosh away and back."))).Put("foot", ((V)("A hop, the pearls jump."))).Put("tail", ((V)("Pearls swirl, he looks back."))).V).Put("chefbun", NewObj(9).Put("head", ((V)("Holds his chef hat and straightens it."))).Put("ear", ((V)("His hat tips, he reaches up and sets it straight."))).Put("nose", ((V)("Tastes your finger, thinks about it, chef's kiss."))).Put("eye", ((V)("Blinks and rubs his eye."))).Put("cheek", ((V)("Leans into your finger."))).Put("belly", ((V)("Giggles in a puff of flour."))).Put("side", ((V)("Wobbles and dusts the flour off."))).Put("foot", ((V)("A little hop, flour puffs."))).Put("tail", ((V)("A puff of flour, he looks back."))).V).V;
Call(build_26, V.Undef, RE_35, TXT_36, BODY_34);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
