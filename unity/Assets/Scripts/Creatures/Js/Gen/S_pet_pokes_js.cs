// pet-pokes.js, compiled to C# by tools/unity/rig/jsc.mjs from the app's script. Generated: don't edit, re-run jsc.mjs.
#pragma warning disable CS0162, CS0164, CS0168, CS0219, CS8321
using static SquishSquad.Creatures.Js.Rt;

namespace SquishSquad.Creatures.Js.Gen
{
    public static class S_pet_pokes_js
    {
        static readonly System.Text.RegularExpressions.Regex RX0 = JsRegExp.Compile("[LR]$", "");
        public static void Run()
        {
Call(Named(boot_57 => Fn((V _self1, int _argc2, V _a4, V _a5, V _a6, V _a7, V[] _rest3) => {
V R_8 = default;
V TL_9 = default;
V S_10 = default;
V hand_11 = default;
V both_12 = default;
V o_13 = default;
V NOHANDS_14 = default;
V jump_15 = default;
V shake_16 = default;
V swing_17 = default;
V steps_18 = default;
V jelly_19 = default;
V popcorn_20 = default;
V croak_21 = default;
V CARD_22 = default;
V DESC_23 = default;
V BODY_24 = default;
V HIT_25 = default;
V SEE_26 = default;
V see_27 = default;
V unsee_28 = default;
V SPOT_29 = default;
V rub_30 = default;
V walkBack_31 = default;
V giggle_32 = default;
V hmph_33 = default;
V sneeze_34 = default;
V sniff_35 = default;
V lick_36 = default;
V wag_37 = default;
V para_38 = default;
V leanIn_39 = default;
V swat_40 = default;
V pawShake_41 = default;
V headShake_42 = default;
V snort_43 = default;
V boof_44 = default;
V wheek_45 = default;
V freeze_46 = default;
V curl_47 = default;
V blushy_48 = default;
V happy_49 = default;
V pat_50 = default;
V smooth_51 = default;
V RE_52 = default;
V TXT_53 = default;
V NAME_54 = default;
V SPOTS_55 = default;
V build_56 = default;
if (_self1.IsNullish) _self1 = GlobalV;
R_8 = Get(G("window"), "RiveRig");
if (((!(Truthy(R_8)) || !(Truthy(Get(R_8, "PETLIB")))) || !(Truthy(Get(Get(R_8, "STATES"), "poke_head"))))) {
Call(G("setTimeout"), V.Undef, boot_57.v, ((V)(25D)));
return default;
}
if (Truthy(Get(R_8, "pokeV"))) {
return default;
}
Set(R_8, "pokeV", ((V)(1D)));
{ V _t58 = Get(R_8, "PETLIB");
if (_t58.IsNullish) throw TypeErr("Cannot destructure " + ToStr(_t58));
{ V _t59 = Get(_t58, "TL");
TL_9 = _t59; }
{ V _t60 = Get(_t58, "S");
S_10 = _t60; }
{ V _t61 = Get(_t58, "hand");
hand_11 = _t61; }
{ V _t62 = Get(_t58, "both");
both_12 = _t62; }
{ V _t63 = Get(_t58, "o");
o_13 = _t63; }
{ V _t64 = Get(_t58, "NOHANDS");
NOHANDS_14 = _t64; }
{ V _t65 = Get(_t58, "jump");
jump_15 = _t65; }
{ V _t66 = Get(_t58, "shake");
shake_16 = _t66; }
{ V _t67 = Get(_t58, "swing");
swing_17 = _t67; }
{ V _t68 = Get(_t58, "steps");
steps_18 = _t68; }
{ V _t69 = Get(_t58, "jelly");
jelly_19 = _t69; }
{ V _t70 = Get(_t58, "popcorn");
popcorn_20 = _t70; }
{ V _t71 = Get(_t58, "croak");
croak_21 = _t71; }
{ V _t72 = Get(_t58, "CARD");
CARD_22 = _t72; }
{ V _t73 = Get(_t58, "DESC");
DESC_23 = _t73; } }
BODY_24 = NewObj(10).Put("mittens", NewObj(2).Put("ear", ((V)(1D))).Put("tail", ((V)(1D))).V).Put("biscuit", NewObj(2).Put("ear", ((V)(0.45))).Put("tail", ((V)(1D))).V).Put("truffle", NewObj(2).Put("ear", ((V)(1D))).Put("tail", ((V)(1D))).V).Put("nibbles", NewObj(1).Put("ear", ((V)(0.8))).V).Put("quill", NewObj(1).Put("ear", ((V)(0.6))).V).Put("waffles", NewObj(2).Put("ear", ((V)(1D))).Put("tail", ((V)(1D))).V).Put("poppy", NewObj(1).Put("ear", ((V)(0.8))).V).Put("duchess", NewObj(2).Put("ear", ((V)(0.9))).Put("tail", ((V)(1D))).V).Put("mamapaws", NewObj(1).Put("ear", ((V)(0.45))).V).Put("ribbit", NewObj(4).Put("ear", ((V)(0D))).Put("noWalk", ((V)(1D))).Put("earTap", Arr(((V)(33D)), ((V)(24D)))).Put("lbl", NewObj(1).Put("ear", ((V)("eye dome"))).V).V).V;
HIT_25 = NewObj(9).Put("head", Fn((V _self74, int _argc75, V t_81, V s_82, V B_83, V _a80, V[] _rest76) => {
double e_84 = 0;
if (_self74.IsNullish) _self74 = GlobalV;
e_84 = (10D * ToNum(Get(B_83, "ear")));
return Invoke(Invoke(Invoke(t_81, "to", ((V)(70D)), NewObj(5).Put("sq", ((V)(0.22))).Put("pitch", ((V)((-0.2)))).Put("sqz", ((V)(1D))).Put("earL", ((V)(e_84))).Put("earR", ((V)(e_84))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(4).Put("sq", ((V)((-0.08)))).Put("pitch", ((V)(0.08))).Put("earL", ((V)(((-e_84) * 0.4)))).Put("earR", ((V)(((-e_84) * 0.4)))).V, ((V)("o"))), "to", ((V)(180D)), NewObj(5).Put("sq", ((V)(0.03))).Put("pitch", ((V)((-0.02)))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).Put("sqz", ((V)(0D))).V, ((V)("io")));
return default;
}, 3, "head", false)).Put("ear", Fn((V _self85, int _argc86, V t_92, V s_93, V B_94, V _a91, V[] _rest87) => {
V k_95 = default;
V e_96 = default;
if (_self85.IsNullish) _self85 = GlobalV;
k_95 = Call(S_10, V.Undef, s_93);
e_96 = Get(B_94, "ear");
return Invoke(Invoke(Invoke(Invoke(t_92, "to", ((V)(60D)), NewObj(5).PutK(Get(k_95, "ear"), ((V)(((-22D) * ToNum(e_96))))).PutK(Get(k_95, "wink"), ((V)(1D))).Put("htilt", ((V)(((-ToNum(s_93)) * 7D)))).Put("hyaw", ((V)(((-ToNum(s_93)) * 0.12)))).Put("sq", ((V)(0.04))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(3).PutK(Get(k_95, "ear"), ((V)((12D * ToNum(e_96))))).Put("htilt", ((V)(((-ToNum(s_93)) * 4D)))).Put("sq", ((V)(0D))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).PutK(Get(k_95, "ear"), ((V)(((-5D) * ToNum(e_96))))).Put("htilt", ((V)(((-ToNum(s_93)) * 5D)))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).PutK(Get(k_95, "ear"), ((V)(0D))).PutK(Get(k_95, "wink"), ((V)(0D))).V, ((V)("io")));
return default;
}, 3, "ear", false)).Put("nose", Fn((V _self97, int _argc98, V t_104, V _a101, V _a102, V _a103, V[] _rest99) => {
if (_self97.IsNullish) _self97 = GlobalV;
return Invoke(Invoke(t_104, "to", ((V)(70D)), NewObj(4).Put("pitch", ((V)(0.2))).Put("sq", ((V)(0.06))).Put("close", ((V)(0.7))).Put("mw", ((V)(0.85))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(6).Put("pitch", ((V)((-0.06)))).Put("sq", ((V)(0D))).Put("close", ((V)(0D))).Put("cross", ((V)(1D))).Put("ly", ((V)(0.6))).Put("mw", ((V)(1D))).V, ((V)("io")));
return default;
}, 1, "nose", false)).Put("eye", Fn((V _self105, int _argc106, V t_112, V s_113, V _a110, V _a111, V[] _rest107) => {
V k_114 = default;
if (_self105.IsNullish) _self105 = GlobalV;
k_114 = Call(S_10, V.Undef, s_113);
return Invoke(Invoke(t_112, "to", ((V)(55D)), NewObj(5).PutK(Get(k_114, "wink"), ((V)(1D))).Put("pitch", ((V)(0.12))).Put("hyaw", ((V)(((-ToNum(s_113)) * 0.15)))).Put("htilt", ((V)(((-ToNum(s_113)) * 4D)))).Put("sq", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(3).Put("pitch", ((V)(0.04))).Put("hyaw", ((V)(((-ToNum(s_113)) * 0.08)))).Put("sq", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "eye", false)).Put("cheek", Fn((V _self115, int _argc116, V t_122, V s_123, V _a120, V _a121, V[] _rest117) => {
V k_124 = default;
if (_self115.IsNullish) _self115 = GlobalV;
k_124 = Call(S_10, V.Undef, s_123);
return Invoke(Invoke(t_122, "to", ((V)(80D)), NewObj(5).Put("htilt", ((V)(((-ToNum(s_123)) * 8D)))).Put("hyaw", ((V)(((-ToNum(s_123)) * 0.1)))).PutK(Get(k_124, "wink"), ((V)(0.7))).Put("sq", ((V)(0.04))).Put("puff", ((V)(0.3))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(4).Put("htilt", ((V)(((-ToNum(s_123)) * 5D)))).Put("sq", ((V)(0D))).Put("puff", ((V)(0.1))).PutK(Get(k_124, "wink"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", false)).Put("belly", Fn((V _self125, int _argc126, V t_132, V _a129, V _a130, V _a131, V[] _rest127) => {
if (_self125.IsNullish) _self125 = GlobalV;
return Invoke(Invoke(t_132, "to", ((V)(80D)), NewObj(5).Put("sq", ((V)(0.16))).Put("pitch", ((V)((-0.2)))).Put("sqz", ((V)(0.8))).Put("armL", ((V)(14D))).Put("armR", ((V)(14D))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(6).Put("sq", ((V)(0.03))).Put("pitch", ((V)((-0.16)))).Put("sqz", ((V)(0D))).Put("ly", ((V)(0.7))).Put("armL", ((V)(6D))).Put("armR", ((V)(6D))).V, ((V)("io")));
return default;
}, 1, "belly", false)).Put("side", Fn((V _self133, int _argc134, V t_140, V s_141, V _a138, V _a139, V[] _rest135) => {
double d_142 = 0;
V j_143 = default;
if (_self133.IsNullish) _self133 = GlobalV;
d_142 = (-ToNum(s_141));
j_143 = Call(S_10, V.Undef, ((V)((-ToNum(s_141)))));
return Invoke(Invoke(Invoke(t_140, "to", ((V)(80D)), NewObj(7).Put("bend", ((V)((d_142 * 6D)))).Put("x", ((V)((d_142 * 1.2)))).Put("sq", ((V)(0.05))).Put("wide", ((V)(0.6))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).PutK(Get(j_143, "foot"), ((V)(2.5))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(5).Put("bend", ((V)((d_142 * 2D)))).Put("x", ((V)((d_142 * 3D)))).PutK(Get(j_143, "foot"), ((V)(0D))).Put("armL", ((V)(12D))).Put("armR", ((V)(12D))).V, ((V)("io"))), "to", ((V)(180D)), NewObj(4).Put("bend", ((V)(((-d_142) * 1D)))).Put("sq", ((V)(0.02))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", false)).Put("foot", Fn((V _self144, int _argc145, V t_151, V s_152, V _a149, V _a150, V[] _rest146) => {
V k_153 = default;
if (_self144.IsNullish) _self144 = GlobalV;
k_153 = Call(S_10, V.Undef, s_152);
return Invoke(Invoke(t_151, "to", ((V)(70D)), NewObj(7).PutK(Get(k_153, "foot"), ((V)(5D))).Put("sq", ((V)((-0.04)))).Put("wide", ((V)(0.7))).Put("bend", ((V)((ToNum(s_152) * 2D)))).Put("x", ((V)(((-ToNum(s_152)) * 0.6)))).Put("armL", ((V)(22D))).Put("armR", ((V)(22D))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(5).PutK(Get(k_153, "foot"), ((V)(3D))).Put("sq", ((V)(0D))).Put("bend", ((V)((ToNum(s_152) * 1D)))).Put("armL", ((V)(10D))).Put("armR", ((V)(10D))).V, ((V)("io")));
return default;
}, 2, "foot", false)).Put("tail", Fn((V _self154, int _argc155, V t_161, V s_162, V B_163, V _a160, V[] _rest156) => {
if (_self154.IsNullish) _self154 = GlobalV;
return Invoke(Invoke(Invoke(Invoke(t_161, "to", ((V)(70D)), (Truthy(Get(B_163, "tail")) ? NewObj(4).Put("curl", ((V)(0.9))).Put("wag", ((V)(28D))).Put("sq", ((V)(0.08))).Put("wide", ((V)(0.8))).V : NewObj(2).Put("sq", ((V)(0.08))).Put("wide", ((V)(0.8))).V), ((V)("o"))), "to", ((V)(240D)), NewObj(6).Put("lift", ((V)(5D))).Put("sq", ((V)((-0.08)))).Put("curl", ((V)((Truthy(Get(B_163, "tail")) ? 0.5 : 0D)))).Put("wag", ((V)((Truthy(Get(B_163, "tail")) ? (-12D) : 0D)))).Put("armL", ((V)(30D))).Put("armR", ((V)(30D))).V, ((V)("o"))), "to", ((V)(220D)), NewObj(5).Put("lift", ((V)(0D))).Put("sq", ((V)(0.08))).Put("wag", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("i"))), "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
return default;
}, 3, "tail", false)).V;
SEE_26 = NewObj(9).Put("head", Fn((V _arrowThis170, int _argc164, V _a166, V _a167, V _a168, V _a169, V[] _rest165) => {
return NewObj(2).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.1))).V;
}, 0, "head", true)).Put("ear", Fn((V _arrowThis178, int _argc171, V s_177, V _a174, V _a175, V _a176, V[] _rest172) => {
return NewObj(4).Put("lx", ((V)((ToNum(s_177) * 0.8)))).Put("ly", ((V)((-0.7)))).Put("hyaw", ((V)((ToNum(s_177) * 0.2)))).Put("htilt", ((V)((ToNum(s_177) * 4D)))).V;
}, 1, "ear", true)).Put("cheek", Fn((V _arrowThis186, int _argc179, V s_185, V _a182, V _a183, V _a184, V[] _rest180) => {
return NewObj(3).Put("lx", ((V)((ToNum(s_185) * 0.6)))).Put("ly", ((V)(0.3))).Put("hyaw", ((V)((ToNum(s_185) * 0.1)))).V;
}, 1, "cheek", true)).Put("belly", Fn((V _arrowThis193, int _argc187, V _a189, V _a190, V _a191, V _a192, V[] _rest188) => {
return NewObj(2).Put("ly", ((V)(0.9))).Put("pitch", ((V)((-0.25)))).V;
}, 0, "belly", true)).Put("side", Fn((V _arrowThis201, int _argc194, V s_200, V _a197, V _a198, V _a199, V[] _rest195) => {
return NewObj(5).Put("lx", ((V)((ToNum(s_200) * 0.9)))).Put("ly", ((V)(0.5))).Put("hyaw", ((V)((ToNum(s_200) * 0.3)))).Put("pitch", ((V)((-0.1)))).Put("twist", ((V)((ToNum(s_200) * 0.1)))).V;
}, 1, "side", true)).Put("foot", Fn((V _arrowThis209, int _argc202, V s_208, V _a205, V _a206, V _a207, V[] _rest203) => {
return NewObj(4).Put("lx", ((V)((ToNum(s_208) * 0.5)))).Put("ly", ((V)(1D))).Put("pitch", ((V)((-0.3)))).Put("hyaw", ((V)((ToNum(s_208) * 0.15)))).V;
}, 1, "foot", true)).Put("tail", Fn((V _arrowThis216, int _argc210, V _a212, V _a213, V _a214, V _a215, V[] _rest211) => {
return NewObj(4).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.3))).Put("hyaw", ((V)(0.6))).Put("twist", ((V)(0.25))).V;
}, 0, "tail", true)).Put("nose", Fn((V _arrowThis223, int _argc217, V _a219, V _a220, V _a221, V _a222, V[] _rest218) => {
return NewObj(2).Put("ly", ((V)(0.6))).Put("cross", ((V)(1D))).V;
}, 0, "nose", true)).Put("eye", Fn((V _arrowThis230, int _argc224, V _a226, V _a227, V _a228, V _a229, V[] _rest225) => {
return NewObj(0).V;
}, 0, "eye", true)).V;
see_27 = Fn((V _arrowThis241, int _argc231, V t_237, V spot_238, V s_239, V hold_240, V[] _rest232) => {
V v_242 = default;
V ey_243 = default;
V hd_244 = default;
v_242 = InvokeK(SEE_26, spot_238, s_239);
ey_243 = NewObj(0).V;
hd_244 = NewObj(0).V;
{
foreach (V _k245 in ForInKeys(v_242)) {
V p_246 = default;
p_246 = _k245;
SetK((((SEqS(p_246, "lx") || SEqS(p_246, "ly")) || SEqS(p_246, "cross")) ? ey_243 : hd_244), p_246, GetK(v_242, p_246));
}
}
Invoke(Invoke(Invoke(t_237, "to", ((V)(110D)), ey_243, ((V)("o"))), "e", ((V)("blink"))), "to", ((V)(320D)), hd_244, ((V)("io")));
return (Truthy(hold_240) ? Invoke(t_237, "wait", hold_240) : t_237);
return default;
}, 4, "", true);
unsee_28 = Fn((V _arrowThis255, int _argc247, V t_253, V d_254, V _a251, V _a252, V[] _rest248) => {
return Invoke(t_253, "to", (d_254 is var _t256 && Truthy(_t256) ? _t256 : ((V)(320D))), NewObj(7).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("twist", ((V)(0D))).Put("cross", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
SPOT_29 = NewObj(7).Put("head", Fn((V _arrowThis264, int _argc257, V s_263, V _a260, V _a261, V _a262, V[] _rest258) => {
return Call(hand_11, V.Undef, s_263, ((V)((-2D))), ((V)((-30D))));
}, 1, "head", true)).Put("ear", Fn((V _arrowThis272, int _argc265, V s_271, V _a268, V _a269, V _a270, V[] _rest266) => {
return Call(hand_11, V.Undef, s_271, ((V)((-6D))), ((V)((-31D))));
}, 1, "ear", true)).Put("eye", Fn((V _arrowThis280, int _argc273, V s_279, V _a276, V _a277, V _a278, V[] _rest274) => {
return Call(hand_11, V.Undef, s_279, ((V)(6D)), ((V)((-27D))));
}, 1, "eye", true)).Put("cheek", Fn((V _arrowThis288, int _argc281, V s_287, V _a284, V _a285, V _a286, V[] _rest282) => {
return Call(hand_11, V.Undef, s_287, ((V)(2D)), ((V)((-18D))));
}, 1, "cheek", true)).Put("nose", Fn((V _arrowThis295, int _argc289, V _a291, V _a292, V _a293, V _a294, V[] _rest290) => {
return Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-18D))));
}, 0, "nose", true)).Put("side", Fn((V _arrowThis303, int _argc296, V s_302, V _a299, V _a300, V _a301, V[] _rest297) => {
return Call(hand_11, V.Undef, s_302, ((V)((-3D))), ((V)((-2D))));
}, 1, "side", true)).Put("mouth", Fn((V _arrowThis311, int _argc304, V s_310, V _a307, V _a308, V _a309, V[] _rest305) => {
return Call(hand_11, V.Undef, s_310, ((V)(13D)), ((V)((-15D))));
}, 1, "mouth", true)).V;
rub_30 = Fn((V _arrowThis323, int _argc312, V t_318, V s_319, V where_320, V n_321, V[] _rest313) => {
V h_324 = default;
V k_325 = default;
V x_322 = default;
x_322 = (_argc312 > 4 ? _rest313[0] : V.Undef);
s_319 = (s_319 is var _t326 && Truthy(_t326) ? _t326 : ((V)(1D)));
h_324 = InvokeK(SPOT_29, where_320, s_319);
k_325 = Call(S_10, V.Undef, s_319);
Invoke(t_318, "to", ((V)(300D)), Call(o_13, V.Undef, h_324, NewObj(1).PutK(Get(k_325, "arm"), ((V)((SEqS(where_320, "side") ? 0D : 22D)))).V, (x_322 is var _t327 && Truthy(_t327) ? _t327 : NewObj(0).V)), ((V)("io")));
{
double i_328 = 0;
i_328 = 0D;
while (true) {
if (!(Lt(((V)(i_328)), (n_321 is var _t330 && Truthy(_t330) ? _t330 : ((V)(3D)))))) break;
Invoke(Invoke(t_318, "to", ((V)(170D)), NewObj(2).PutK(Get(k_325, "hx"), Add(GetK(h_324, Get(k_325, "hx")), ((V)((LtN(s_319, 0D) ? 3D : (-3D)))))).PutK(Get(k_325, "hy"), ((V)((ToNum(GetK(h_324, Get(k_325, "hy"))) - 1.5)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(2).PutK(Get(k_325, "hx"), GetK(h_324, Get(k_325, "hx"))).PutK(Get(k_325, "hy"), GetK(h_324, Get(k_325, "hy"))).V, ((V)("io")));
i_328++;
}
}
return Invoke(t_318, "to", ((V)(280D)), NewObj(5).PutK(Get(k_325, "hx"), ((V)(0D))).PutK(Get(k_325, "hy"), ((V)(0D))).PutK(Get(k_325, "arm"), ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
return default;
}, 5, "", true);
walkBack_31 = Fn((V _arrowThis339, int _argc331, V t_337, V dur_338, V _a335, V _a336, V[] _rest332) => {
V a_340 = default;
a_340 = Get(t_337, "t");
Invoke(t_337, "to", (dur_338 is var _t341 && Truthy(_t341) ? _t341 : ((V)(450D))), NewObj(2).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
return Call(para_38, V.Undef, t_337, a_340, Fn((V _arrowThis349, int _argc342, V u_348, V _a345, V _a346, V _a347, V[] _rest343) => {
return Call(steps_18, V.Undef, u_348, (dur_338 is var _t350 && Truthy(_t350) ? _t350 : ((V)(450D))), ((V)(2D)), ((V)(2.2)));
}, 1, "", true));
return default;
}, 2, "", true);
giggle_32 = Fn((V _arrowThis360, int _argc351, V t_357, V n_358, V a_359, V _a356, V[] _rest352) => {
a_359 = (a_359 is var _t361 && Truthy(_t361) ? _t361 : ((V)(1D)));
Invoke(t_357, "to", ((V)(160D)), NewObj(5).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("sqz", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("o")));
{
double i_362 = 0;
i_362 = 0D;
while (true) {
if (!(Lt(((V)(i_362)), (n_358 is var _t364 && Truthy(_t364) ? _t364 : ((V)(3D)))))) break;
Invoke(Invoke(t_357, "to", ((V)(130D)), NewObj(4).Put("sq", ((V)((0.05 * ToNum(a_359))))).Put("armL", ((V)((8D * ToNum(a_359))))).Put("armR", ((V)((8D * ToNum(a_359))))).Put("htilt", ((V)(((NumTruthy((i_362 % 2D)) ? 2D : (-2D)) * ToNum(a_359))))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
i_362++;
}
}
return Invoke(t_357, "to", ((V)(200D)), NewObj(2).Put("open", ((V)(0.1))).Put("htilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 3, "", true);
hmph_33 = Fn((V _arrowThis373, int _argc365, V t_371, V away_372, V _a369, V _a370, V[] _rest366) => {
return Invoke(Invoke(Invoke(Invoke(t_371, "to", ((V)(250D)), NewObj(3).Put("frown", ((V)(0.55))).Put("puff", ((V)(0.35))).Put("close", ((V)(0.35))).V, ((V)("io"))), "to", ((V)(380D)), NewObj(4).Put("hyaw", ((V)((ToNum(away_372) * 0.38)))).Put("lx", ((V)((ToNum(away_372) * 0.6)))).Put("pitch", ((V)(0.12))).Put("htilt", ((V)(((-ToNum(away_372)) * 3D)))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(350D)), NewObj(7).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("frown", ((V)(0D))).Put("puff", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
sneeze_34 = Fn((V _arrowThis382, int _argc374, V t_380, V a_381, V _a378, V _a379, V[] _rest375) => {
a_381 = (a_381 is var _t383 && Truthy(_t383) ? _t383 : ((V)(1D)));
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_380, "to", ((V)(260D)), NewObj(6).Put("pitch", ((V)((0.3 * ToNum(a_381))))).Put("open", ((V)(0.4))).Put("close", ((V)(0.6))).Put("sq", ((V)(((-0.06) * ToNum(a_381))))).Put("cross", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(3).Put("pitch", ((V)((0.22 * ToNum(a_381))))).Put("open", ((V)(0.3))).Put("sq", ((V)((-0.03)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(4).Put("pitch", ((V)((0.4 * ToNum(a_381))))).Put("open", ((V)(0.55))).Put("close", ((V)(0.85))).Put("sq", ((V)(((-0.1) * ToNum(a_381))))).V, ((V)("io"))), "to", ((V)(80D)), NewObj(5).Put("pitch", ((V)(((-0.3) * ToNum(a_381))))).Put("open", ((V)((0.9 * ToNum(a_381))))).Put("sqz", ((V)(1D))).Put("close", ((V)(0D))).Put("sq", ((V)((0.2 * ToNum(a_381))))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("sneeze")), ((V)("nose")), ((V)(Round((9D * ToNum(a_381)))))), "to", ((V)(260D)), NewObj(3).Put("pitch", ((V)((-0.02)))).Put("open", ((V)(0.1))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("sqz", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
sniff_35 = Fn((V _arrowThis392, int _argc384, V t_390, V n_391, V _a388, V _a389, V[] _rest385) => {
return Invoke(t_390, "osc", ((V)((ToNum((n_391 is var _t393 && Truthy(_t393) ? _t393 : ((V)(3D)))) * 240D))), (n_391 is var _t394 && Truthy(_t394) ? _t394 : ((V)(3D))), NewObj(3).Put("sq", ((V)(0.03))).Put("pitch", ((V)(0.05))).Put("mw", ((V)(0.85))).V, NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o")));
}, 2, "", true);
lick_36 = Fn((V _arrowThis403, int _argc395, V t_401, V n_402, V _a399, V _a400, V[] _rest396) => {
{
double i_404 = 0;
i_404 = 0D;
while (true) {
if (!(Lt(((V)(i_404)), (n_402 is var _t406 && Truthy(_t406) ? _t406 : ((V)(2D)))))) break;
Invoke(Invoke(t_401, "to", ((V)(150D)), NewObj(3).Put("tongue", ((V)(1D))).Put("open", ((V)(0.3))).Put("pitch", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0.15))).Put("open", ((V)(0.05))).Put("pitch", ((V)(0D))).V, ((V)("io")));
i_404++;
}
}
return Invoke(t_401, "to", ((V)(150D)), NewObj(2).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
wag_37 = Fn((V _arrowThis417, int _argc407, V t_413, V dur_414, V a_415, V n_416, V[] _rest408) => {
V e_418 = default;
e_418 = Add(Get(t_413, "t"), ((V)((ToNum(dur_414) * 0D))));
return Call(swing_17, V.Undef, t_413, dur_414, (n_416 is var _t419 && Truthy(_t419) ? _t419 : ((V)(Max(3D, Round((ToNum(dur_414) / 160D)))))), NewObj(1).Put("wag", (a_415 is var _t420 && Truthy(_t420) ? _t420 : ((V)(28D)))).V);
return default;
}, 4, "", true);
para_38 = Fn((V _arrowThis430, int _argc421, V t_427, V from_428, V fn_429, V _a426, V[] _rest422) => {
V e_431 = default;
e_431 = Get(t_427, "t");
Invoke(t_427, "at", from_428);
Call(fn_429, V.Undef, t_427);
return Invoke(t_427, "at", ((V)(Max(ToNum(e_431), ToNum(Get(t_427, "t"))))));
return default;
}, 3, "", true);
leanIn_39 = Fn((V _arrowThis441, int _argc432, V t_438, V s_439, V x_440, V _a437, V[] _rest433) => {
return Invoke(Invoke(Invoke(Invoke(t_438, "to", ((V)(320D)), Call(o_13, V.Undef, NewObj(7).Put("htilt", ((V)((ToNum(s_439) * 10D)))).Put("hyaw", ((V)((ToNum(s_439) * 0.12)))).Put("close", ((V)(0.85))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("blush", ((V)(0.6))).Put("pitch", ((V)((-0.05)))).V, (x_440 is var _t442 && Truthy(_t442) ? _t442 : NewObj(0).V)), ((V)("io"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(2).Put("htilt", ((V)((ToNum(s_439) * 12D)))).Put("x", ((V)((ToNum(s_439) * 0.6)))).V, NewObj(2).Put("htilt", ((V)((ToNum(s_439) * 7D)))).Put("x", ((V)((ToNum(s_439) * 0.2)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "to", ((V)(300D)), NewObj(4).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("x", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
}, 3, "", true);
swat_40 = Fn((V _arrowThis452, int _argc443, V t_449, V s_450, V n_451, V _a448, V[] _rest444) => {
V k_453 = default;
k_453 = Call(S_10, V.Undef, s_450);
{
double i_454 = 0;
i_454 = 0D;
while (true) {
if (!(Lt(((V)(i_454)), (n_451 is var _t456 && Truthy(_t456) ? _t456 : ((V)(2D)))))) break;
Invoke(Invoke(t_449, "to", ((V)(90D)), NewObj(5).PutK(Get(k_453, "arm"), ((V)(78D))).PutK(Get(k_453, "hx"), ((V)((LtN(s_450, 0D) ? (-4D) : 4D)))).PutK(Get(k_453, "hy"), ((V)((-6D)))).Put("sq", ((V)((-0.03)))).Put("frown", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(4).PutK(Get(k_453, "arm"), ((V)(10D))).PutK(Get(k_453, "hx"), ((V)(0D))).PutK(Get(k_453, "hy"), ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_454++;
}
}
return t_449;
return default;
}, 3, "", true);
pawShake_41 = Fn((V _arrowThis466, int _argc457, V t_463, V s_464, V a_465, V _a462, V[] _rest458) => {
V k_467 = default;
k_467 = Call(S_10, V.Undef, s_464);
a_465 = (a_465 is var _t468 && Truthy(_t468) ? _t468 : ((V)(1D)));
Invoke(t_463, "to", ((V)(160D)), NewObj(2).PutK(Get(k_467, "foot"), ((V)((4D * ToNum(a_465))))).Put("bend", ((V)((ToNum(s_464) * 1.5)))).V, ((V)("io")));
Invoke(Arr(((V)(1D)), ((V)(0.75)), ((V)(0.5)), ((V)(0.25))), "forEach", Fn((V _arrowThis477, int _argc469, V m_475, V i_476, V _a473, V _a474, V[] _rest470) => {
return Invoke(t_463, "to", ((V)(110D)), NewObj(2).PutK(Get(k_467, "foot"), ((V)((((NumTruthy((ToNum(i_476) % 2D)) ? 4D : 2D) * ToNum(a_465)) + (1D - ToNum(m_475)))))).Put("htilt", ((V)(((NumTruthy((ToNum(i_476) % 2D)) ? 2D : (-2D)) * ToNum(m_475))))).V, ((V)("io")));
}, 2, "", true));
return Invoke(t_463, "to", ((V)(220D)), NewObj(3).PutK(Get(k_467, "foot"), ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("i")));
return default;
}, 3, "", true);
headShake_42 = Fn((V _arrowThis487, int _argc478, V t_484, V a_485, V P_486, V _a483, V[] _rest479) => {
return Call(shake_16, V.Undef, t_484, NewObj(6).Put("P", (P_486 is var _t488 && Truthy(_t488) ? _t488 : ((V)(95D)))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)((0.32 * ToNum((a_485 is var _t489 && Truthy(_t489) ? _t489 : ((V)(1D)))))))).Put("roll", ((V)(4D))).Put("ear", ((V)(12D))).Put("chest", ((V)(0.08))).V);
}, 3, "", true);
snort_43 = Fn((V _arrowThis498, int _argc490, V t_496, V n_497, V _a494, V _a495, V[] _rest491) => {
{
double i_499 = 0;
i_499 = 0D;
while (true) {
if (!(Lt(((V)(i_499)), (n_497 is var _t501 && Truthy(_t501) ? _t501 : ((V)(2D)))))) break;
Invoke(Invoke(t_496, "to", ((V)(80D)), NewObj(4).Put("sq", ((V)(0.06))).Put("pitch", ((V)(0.1))).Put("mw", ((V)(0.75))).Put("close", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(4).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("io")));
i_499++;
}
}
return t_496;
return default;
}, 2, "", true);
boof_44 = Fn((V _arrowThis509, int _argc502, V t_508, V _a505, V _a506, V _a507, V[] _rest503) => {
return Invoke(Invoke(Invoke(Invoke(t_508, "to", ((V)(110D)), NewObj(6).Put("open", ((V)(0.85))).Put("mw", ((V)(0.85))).Put("sq", ((V)((-0.07)))).Put("pitch", ((V)(0.12))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), NewObj(6).Put("open", ((V)(0.15))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.03))).Put("pitch", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
wheek_45 = Fn((V _arrowThis517, int _argc510, V t_516, V _a513, V _a514, V _a515, V[] _rest511) => {
return Invoke(Invoke(Invoke(Invoke(t_516, "to", ((V)(130D)), NewObj(4).Put("pitch", ((V)(0.2))).Put("open", ((V)(0.65))).Put("mw", ((V)(0.75))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(220D)), NewObj(2).Put("pitch", ((V)(0.16))).Put("open", ((V)(0.45))).V, ((V)("io"))), "to", ((V)(180D)), NewObj(4).Put("pitch", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
freeze_46 = Fn((V _arrowThis526, int _argc518, V t_524, V ms_525, V _a522, V _a523, V[] _rest519) => {
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_524, "to", ((V)(70D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "wait", (ms_525 is var _t527 && Truthy(_t527) ? _t527 : ((V)(500D)))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.7)))).V, ((V)("o"))), "wait", ((V)(260D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.7))).V, ((V)("o"))), "wait", ((V)(260D))), "to", ((V)(120D)), NewObj(3).Put("lx", ((V)(0D))).Put("wide", ((V)(0.3))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
curl_47 = Fn((V _arrowThis537, int _argc528, V t_534, V hold_535, V tremble_536, V _a533, V[] _rest529) => {
Invoke(t_534, "to", ((V)(220D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(4D)), ((V)(2D))), NewObj(5).Put("sq", ((V)(0.17))).Put("pitch", ((V)((-0.6)))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V), ((V)("o")));
if (Truthy(tremble_536)) {
Invoke(Invoke(t_534, "osc", hold_535, ((V)(Round((ToNum(hold_535) / 90D)))), NewObj(1).Put("x", ((V)(0.4))).V, NewObj(1).Put("x", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(60D)), NewObj(1).Put("x", ((V)(0D))).V);
} else {
Invoke(t_534, "wait", hold_535);
}
return Invoke(t_534, "to", ((V)(500D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(7).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("blush", ((V)(0.9))).Put("smile", ((V)(0.6))).V), ((V)("io")));
return default;
}, 3, "", true);
blushy_48 = Fn((V _arrowThis546, int _argc538, V t_544, V away_545, V _a542, V _a543, V[] _rest539) => {
return Invoke(Invoke(Invoke(t_544, "to", ((V)(350D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(2D)), ((V)((-18D)))), NewObj(6).Put("blush", ((V)(1D))).Put("smile", ((V)(0.6))).Put("hyaw", ((V)((ToNum(away_545) * 0.25)))).Put("lx", ((V)((ToNum(away_545) * 0.5)))).Put("ly", ((V)(0.5))).Put("pitch", ((V)((-0.08)))).V), ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(350D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(4).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).V), ((V)("io")));
}, 2, "", true);
happy_49 = Fn((V _arrowThis555, int _argc547, V t_553, V n_554, V _a551, V _a552, V[] _rest548) => {
Invoke(t_553, "to", ((V)(180D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
{
double i_556 = 0;
i_556 = 0D;
while (true) {
if (!(Lt(((V)(i_556)), (n_554 is var _t558 && Truthy(_t558) ? _t558 : ((V)(2D)))))) break;
Invoke(Invoke(Invoke(t_553, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.08))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(2).Put("sq", ((V)((-0.04)))).Put("lift", ((V)(1.5))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i")));
i_556++;
}
}
return t_553;
return default;
}, 2, "", true);
pat_50 = Fn((V _arrowThis567, int _argc559, V t_565, V n_566, V _a563, V _a564, V[] _rest560) => {
Invoke(t_565, "to", ((V)(260D)), Call(both_12, V.Undef, ((V)(9D)), ((V)(0D))), ((V)("io")));
{
double i_568 = 0;
i_568 = 0D;
while (true) {
if (!(Lt(((V)(i_568)), (n_566 is var _t570 && Truthy(_t570) ? _t570 : ((V)(3D)))))) break;
Invoke(Invoke(t_565, "to", ((V)(140D)), NewObj(3).Put("hLy", ((V)(2D))).Put("hRy", ((V)((-1D)))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(3).Put("hLy", ((V)((-1D)))).Put("hRy", ((V)(2D))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_568++;
}
}
return Invoke(t_565, "to", ((V)(260D)), NOHANDS_14, ((V)("io")));
return default;
}, 2, "", true);
smooth_51 = Fn((V _arrowThis580, int _argc571, V t_577, V s_578, V where_579, V _a576, V[] _rest572) => {
V h_581 = default;
V k_582 = default;
h_581 = InvokeK(SPOT_29, where_579, s_578);
k_582 = Call(S_10, V.Undef, s_578);
return Invoke(Invoke(Invoke(t_577, "to", ((V)(320D)), Call(o_13, V.Undef, h_581, NewObj(2).PutK(Get(k_582, "arm"), ((V)(20D))).Put("close", ((V)(0.5))).V), ((V)("io"))), "to", ((V)(420D)), NewObj(2).PutK(Get(k_582, "hy"), Add(GetK(h_581, Get(k_582, "hy")), ((V)(9D)))).PutK(Get(k_582, "hx"), Add(GetK(h_581, Get(k_582, "hx")), ((V)((LtN(s_578, 0D) ? (-2D) : 2D))))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(4).PutK(Get(k_582, "hx"), ((V)(0D))).PutK(Get(k_582, "hy"), ((V)(0D))).PutK(Get(k_582, "arm"), ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return default;
}, 3, "", true);
RE_52 = NewObj(10).Put("mittens", NewObj(9).Put("head", Fn((V _arrowThis591, int _argc583, V t_589, V s_590, V _a587, V _a588, V[] _rest584) => {
Call(see_27, V.Undef, t_589, ((V)("head")), s_590, ((V)(150D)));
Call(rub_30, V.Undef, t_589, ((V)(1D)), ((V)("head")), ((V)(3D)), NewObj(2).Put("frown", ((V)(0.4))).Put("puff", ((V)(0.3))).V);
Invoke(t_589, "to", ((V)(200D)), NewObj(3).Put("frown", ((V)(0D))).Put("puff", ((V)(0D))).Put("smile", ((V)(0.5))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis600, int _argc592, V t_598, V s_599, V _a596, V _a597, V[] _rest593) => {
Call(headShake_42, V.Undef, t_598);
Call(giggle_32, V.Undef, t_598, ((V)(2D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis609, int _argc601, V t_607, V s_608, V _a605, V _a606, V[] _rest602) => {
Invoke(t_607, "wait", ((V)(350D)));
Call(sneeze_34, V.Undef, t_607);
Call(rub_30, V.Undef, t_607, ((V)(1D)), ((V)("nose")), ((V)(2D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis618, int _argc610, V t_616, V s_617, V _a614, V _a615, V[] _rest611) => {
Call(rub_30, V.Undef, t_616, s_617, ((V)("eye")), ((V)(3D)));
Invoke(Invoke(t_616, "e", ((V)("blink2"))), "to", ((V)(250D)), NewObj(1).Put("frown", ((V)(0.35))).V, ((V)("io")));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis627, int _argc619, V t_625, V s_626, V _a623, V _a624, V[] _rest620) => {
Call(leanIn_39, V.Undef, t_625, s_626);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis636, int _argc628, V t_634, V s_635, V _a632, V _a633, V[] _rest629) => {
Call(giggle_32, V.Undef, t_634, ((V)(2D)), ((V)(1.3)));
Call(swat_40, V.Undef, t_634, ((V)((-1D))), ((V)(1D)));
Call(swat_40, V.Undef, t_634, ((V)(1D)), ((V)(1D)));
Call(giggle_32, V.Undef, t_634, ((V)(2D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis645, int _argc637, V t_643, V s_644, V _a641, V _a642, V[] _rest638) => {
Call(see_27, V.Undef, t_643, ((V)("side")), s_644, ((V)(200D)));
Call(rub_30, V.Undef, t_643, s_644, ((V)("side")), ((V)(2D)), NewObj(1).Put("frown", ((V)(0.35))).V);
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis654, int _argc646, V t_652, V s_653, V _a650, V _a651, V[] _rest647) => {
Call(see_27, V.Undef, t_652, ((V)("foot")), s_653);
Call(pawShake_41, V.Undef, t_652, s_653);
Call(unsee_28, V.Undef, t_652);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis664, int _argc655, V t_661, V s_662, V B_663, V _a660, V[] _rest656) => {
Call(see_27, V.Undef, t_661, ((V)("tail")), s_662, ((V)(100D)));
Invoke(t_661, "to", ((V)(200D)), NewObj(2).Put("frown", ((V)(0.5))).Put("puff", ((V)(0.2))).V, ((V)("io")));
Call(wag_37, V.Undef, t_661, ((V)(900D)), ((V)(20D)), ((V)(3D)));
return default;
}, 3, "tail", true)).V).Put("biscuit", NewObj(9).Put("head", Fn((V _arrowThis673, int _argc665, V t_671, V s_672, V _a669, V _a670, V[] _rest666) => {
Invoke(t_671, "to", ((V)(320D)), NewObj(6).Put("pitch", ((V)(0.15))).Put("close", ((V)(0.85))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.3))).V, ((V)("io")));
Call(wag_37, V.Undef, t_671, ((V)(1100D)), ((V)(32D)), ((V)(7D)));
Invoke(t_671, "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis682, int _argc674, V t_680, V s_681, V _a678, V _a679, V[] _rest675) => {
Invoke(Invoke(t_680, "to", ((V)(380D)), NewObj(2).Put("htilt", ((V)((ToNum(s_681) * 12D)))).Put("lx", ((V)((ToNum(s_681) * 0.3)))).V, ((V)("io"))), "wait", ((V)(250D)));
Call(headShake_42, V.Undef, t_680, ((V)(1D)), ((V)(100D)));
Invoke(t_680, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(wag_37, V.Undef, t_680, ((V)(700D)), ((V)(28D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis691, int _argc683, V t_689, V s_690, V _a687, V _a688, V[] _rest684) => {
Invoke(t_689, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_35, V.Undef, t_689, ((V)(4D)));
Call(lick_36, V.Undef, t_689, ((V)(2D)));
Invoke(t_689, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(wag_37, V.Undef, t_689, ((V)(700D)), ((V)(30D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis700, int _argc692, V t_698, V s_699, V _a696, V _a697, V[] _rest693) => {
Invoke(t_698, "e", ((V)("blink2")));
Call(rub_30, V.Undef, t_698, s_699, ((V)("eye")), ((V)(2D)));
Invoke(t_698, "to", ((V)(160D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.6))).V, ((V)("io")));
Call(wag_37, V.Undef, t_698, ((V)(700D)), ((V)(30D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis709, int _argc701, V t_707, V s_708, V _a705, V _a706, V[] _rest702) => {
Call(leanIn_39, V.Undef, t_707, s_708, NewObj(2).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.25))).V);
Call(wag_37, V.Undef, t_707, ((V)(600D)), ((V)(30D)));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis718, int _argc710, V t_716, V s_717, V _a714, V _a715, V[] _rest711) => {
V k_719 = default;
V a_720 = default;
k_719 = Call(S_10, V.Undef, ((V)(1D)));
Invoke(t_716, "to", ((V)(300D)), NewObj(8).Put("pitch", ((V)(0.2))).Put("sq", ((V)((-0.03)))).Put("close", ((V)(0.9))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.35))).Put("ly", ((V)(0D))).V, ((V)("io")));
a_720 = Get(t_716, "t");
Invoke(Invoke(t_716, "osc", ((V)(1200D)), ((V)(5D)), NewObj(1).PutK(Get(k_719, "foot"), ((V)(3.5))).V, NewObj(1).PutK(Get(k_719, "foot"), ((V)(0.5))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).PutK(Get(k_719, "foot"), ((V)(0D))).V, ((V)("i")));
Call(para_38, V.Undef, t_716, a_720, Fn((V _arrowThis728, int _argc721, V u_727, V _a724, V _a725, V _a726, V[] _rest722) => {
return Call(wag_37, V.Undef, u_727, ((V)(1320D)), ((V)(34D)), ((V)(9D)));
}, 1, "", true));
Invoke(t_716, "to", ((V)(250D)), NewObj(3).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis737, int _argc729, V t_735, V s_736, V _a733, V _a734, V[] _rest730) => {
Invoke(t_735, "to", ((V)(300D)), NewObj(7).Put("pitch", ((V)((-0.3)))).Put("sq", ((V)(0.1))).Put("armL", ((V)((-12D)))).Put("armR", ((V)((-12D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("io")));
Call(wag_37, V.Undef, t_735, ((V)(800D)), ((V)(34D)), ((V)(5D)));
Call(boof_44, V.Undef, t_735);
Invoke(t_735, "to", ((V)(250D)), NewObj(4).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis746, int _argc738, V t_744, V s_745, V _a742, V _a743, V[] _rest739) => {
V k_747 = default;
k_747 = Call(S_10, V.Undef, s_745);
Invoke(Invoke(t_744, "to", ((V)(260D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, s_745, ((V)((-6D))), ((V)((-8D)))), NewObj(4).PutK(Get(k_747, "arm"), ((V)(55D))).PutK(Get(k_747, "foot"), ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(450D)));
Call(wag_37, V.Undef, t_744, ((V)(600D)), ((V)(30D)));
Invoke(t_744, "to", ((V)(260D)), NewObj(3).PutK(Get(k_747, "arm"), ((V)(0D))).PutK(Get(k_747, "hx"), ((V)(0D))).PutK(Get(k_747, "hy"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis756, int _argc748, V t_754, V s_755, V _a752, V _a753, V[] _rest749) => {
Call(see_27, V.Undef, t_754, ((V)("tail")), s_755, ((V)(0D)));
Invoke(Invoke(Invoke(t_754, "to", ((V)(500D)), NewObj(6).Put("spin", ((V)(200D))).Put("twist", ((V)(0D))).Put("hyaw", ((V)(0.3))).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(450D)), NewObj(3).Put("spin", ((V)(360D))).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Call(wag_37, V.Undef, t_754, ((V)(600D)), ((V)(30D)));
return default;
}, 2, "tail", true)).V).Put("truffle", NewObj(9).Put("head", Fn((V _arrowThis765, int _argc757, V t_763, V s_764, V _a761, V _a762, V[] _rest758) => {
Call(jelly_19, V.Undef, t_763, ((V)(0.1)), ((V)(4D)), ((V)(220D)));
Call(snort_43, V.Undef, t_763, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis774, int _argc766, V t_772, V s_773, V _a770, V _a771, V[] _rest767) => {
Call(headShake_42, V.Undef, t_772, ((V)(0.9)), ((V)(105D)));
Call(snort_43, V.Undef, t_772, ((V)(1D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis783, int _argc775, V t_781, V s_782, V _a779, V _a780, V[] _rest776) => {
Invoke(t_781, "to", ((V)(120D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.3))).V, ((V)("io")));
Call(snort_43, V.Undef, t_781, ((V)(2D)));
Call(sniff_35, V.Undef, t_781, ((V)(3D)));
Invoke(t_781, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis792, int _argc784, V t_790, V s_791, V _a788, V _a789, V[] _rest785) => {
Invoke(t_790, "e", ((V)("blink2")));
Call(rub_30, V.Undef, t_790, s_791, ((V)("eye")), ((V)(2D)));
Call(snort_43, V.Undef, t_790, ((V)(1D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis801, int _argc793, V t_799, V s_800, V _a797, V _a798, V[] _rest794) => {
Invoke(t_799, "to", ((V)(180D)), NewObj(3).Put("puff", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o")));
Call(jelly_19, V.Undef, t_799, ((V)(0.3)), ((V)(3D)), ((V)(220D)), ((V)("puff")));
Call(giggle_32, V.Undef, t_799, ((V)(3D)));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis810, int _argc802, V t_808, V s_809, V _a806, V _a807, V[] _rest803) => {
Invoke(t_808, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("io")));
Call(jelly_19, V.Undef, t_808, ((V)(0.14)), ((V)(5D)), ((V)(240D)));
Call(giggle_32, V.Undef, t_808, ((V)(2D)));
Call(pat_50, V.Undef, t_808, ((V)(2D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis819, int _argc811, V t_817, V s_818, V _a815, V _a816, V[] _rest812) => {
Call(jelly_19, V.Undef, t_817, ((V)(4D)), ((V)(4D)), ((V)(260D)), ((V)("bend")));
Call(snort_43, V.Undef, t_817, ((V)(1D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis828, int _argc820, V t_826, V s_827, V _a824, V _a825, V[] _rest821) => {
V k_829 = default;
k_829 = Call(S_10, V.Undef, s_827);
Invoke(Invoke(Invoke(Invoke(t_826, "to", ((V)(200D)), NewObj(2).PutK(Get(k_829, "foot"), ((V)(5D))).Put("frown", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(110D)), NewObj(2).PutK(Get(k_829, "foot"), ((V)(0D))).Put("sq", ((V)(0.1))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), Get(k_829, "foot"), ((V)(3D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(snort_43, V.Undef, t_826, ((V)(2D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis838, int _argc830, V t_836, V s_837, V _a834, V _a835, V[] _rest831) => {
Call(see_27, V.Undef, t_836, ((V)("tail")), s_837, ((V)(100D)));
Invoke(t_836, "osc", ((V)(600D)), ((V)(3D)), NewObj(1).Put("curl", ((V)(0.9))).V, NewObj(1).Put("curl", ((V)(0.2))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_836, "to", ((V)(160D)), NewObj(2).Put("open", ((V)(0.5))).Put("mw", ((V)(0.8))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(220D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("curl", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "tail", true)).V).Put("nibbles", NewObj(9).Put("head", Fn((V _arrowThis847, int _argc839, V t_845, V s_846, V _a843, V _a844, V[] _rest840) => {
Call(freeze_46, V.Undef, t_845, ((V)(450D)));
Call(sniff_35, V.Undef, t_845, ((V)(3D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis856, int _argc848, V t_854, V s_855, V _a852, V _a853, V[] _rest849) => {
V k_857 = default;
k_857 = Call(S_10, V.Undef, s_855);
Invoke(Invoke(t_854, "osc", ((V)(700D)), ((V)(4D)), NewObj(1).PutK(Get(k_857, "ear"), ((V)((-14D)))).V, NewObj(1).PutK(Get(k_857, "ear"), ((V)(3D))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).PutK(Get(k_857, "ear"), ((V)(0D))).V, ((V)("io")));
Call(headShake_42, V.Undef, t_854, ((V)(0.7)), ((V)(75D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis866, int _argc858, V t_864, V s_865, V _a862, V _a863, V[] _rest859) => {
Invoke(t_864, "to", ((V)(100D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Invoke(t_864, "osc", ((V)(900D)), ((V)(7D)), NewObj(3).Put("sq", ((V)(0.025))).Put("pitch", ((V)(0.05))).Put("mw", ((V)(0.8))).V, NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o")));
Invoke(Invoke(Invoke(t_864, "to", ((V)(200D)), NewObj(1).Put("puff", ((V)(0.7))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(250D)), NewObj(1).Put("puff", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis875, int _argc867, V t_873, V s_874, V _a871, V _a872, V[] _rest868) => {
Invoke(t_873, "to", ((V)(260D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(4D)), ((V)((-18D)))), NewObj(1).Put("close", ((V)(1D))).V), ((V)("io")));
Invoke(t_873, "osc", ((V)(1000D)), ((V)(4D)), NewObj(3).Put("hLy", ((V)((-20D)))).Put("hRy", ((V)((-16D)))).Put("pitch", ((V)((-0.05)))).V, NewObj(3).Put("hLy", ((V)((-16D)))).Put("hRy", ((V)((-20D)))).Put("pitch", ((V)(0.03))).V, ((V)("io")));
Invoke(t_873, "to", ((V)(260D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(4).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V), ((V)("io")));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis884, int _argc876, V t_882, V s_883, V _a880, V _a881, V[] _rest877) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_882, "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(1D))).Put("wide", ((V)(0.5))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(70D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth")), ((V)(2D))), "to", ((V)(160D)), NewObj(2).Put("open", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
Call(giggle_32, V.Undef, t_882, ((V)(3D)), ((V)(0.8)));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis893, int _argc885, V t_891, V s_892, V _a889, V _a890, V[] _rest886) => {
Invoke(t_891, "to", ((V)(180D)), Call(both_12, V.Undef, ((V)(6D)), ((V)((-8D)))), ((V)("io")));
Call(giggle_32, V.Undef, t_891, ((V)(4D)), ((V)(0.8)));
Invoke(t_891, "to", ((V)(200D)), NOHANDS_14, ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis902, int _argc894, V t_900, V s_901, V _a898, V _a899, V[] _rest895) => {
Invoke(t_900, "to", ((V)(200D)), NewObj(2).Put("x", ((V)(((-ToNum(s_901)) * 5D)))).Put("lean", ((V)(((-ToNum(s_901)) * 1.5)))).V, ((V)("o")));
Call(steps_18, V.Undef, t_900, ((V)(200D)), ((V)(2D)), ((V)(2.5)));
Call(freeze_46, V.Undef, t_900, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis911, int _argc903, V t_909, V s_910, V _a907, V _a908, V[] _rest904) => {
Call(jump_15, V.Undef, t_909, NewObj(5).Put("h", ((V)(5D))).Put("ant", ((V)(80D))).Put("up", ((V)(140D))).Put("c", ((V)(0.1))).Put("arm", ((V)(20D))).V);
Call(steps_18, V.Undef, t_909, ((V)(700D)), ((V)(6D)), ((V)(3D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis920, int _argc912, V t_918, V s_919, V _a916, V _a917, V[] _rest913) => {
Invoke(Invoke(Invoke(Invoke(t_918, "to", ((V)(420D)), NewObj(3).Put("spin", ((V)(150D))).Put("hyaw", ((V)(0.3))).Put("lx", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(420D)), NewObj(3).Put("spin", ((V)(360D))).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Call(sniff_35, V.Undef, t_918, ((V)(2D)));
return default;
}, 2, "tail", true)).V).Put("quill", NewObj(9).Put("head", Fn((V _arrowThis929, int _argc921, V t_927, V s_928, V _a925, V _a926, V[] _rest922) => {
Invoke(Invoke(Invoke(Invoke(t_927, "to", ((V)(180D)), NewObj(3).Put("sq", ((V)(0.14))).Put("pitch", ((V)((-0.35)))).Put("close", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0.4))).Put("ly", ((V)((-0.5)))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(t_927, "to", ((V)(400D)), NewObj(6).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("ly", ((V)(0D))).Put("blush", ((V)(0.9))).Put("smile", ((V)(0.5))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis938, int _argc930, V t_936, V s_937, V _a934, V _a935, V[] _rest931) => {
Invoke(t_936, "to", ((V)(250D)), NewObj(4).Put("armL", ((V)(25D))).Put("armR", ((V)(25D))).Put("htilt", ((V)((ToNum(s_937) * 5D)))).Put("sq", ((V)(0.04))).V, ((V)("io")));
Call(blushy_48, V.Undef, t_936, ((V)((-ToNum(s_937)))));
Invoke(t_936, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis947, int _argc939, V t_945, V s_946, V _a943, V _a944, V[] _rest940) => {
Invoke(t_945, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.3))).V, ((V)("io")));
Invoke(t_945, "osc", ((V)(500D)), ((V)(3D)), NewObj(2).Put("mw", ((V)(0.8))).Put("sq", ((V)(0.02))).V, NewObj(2).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_945, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-18D)))), Call(hand_11, V.Undef, ((V)((-1D))), ((V)(13D)), ((V)((-18D)))), NewObj(1).Put("blush", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(300D)), NOHANDS_14, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis956, int _argc948, V t_954, V s_955, V _a952, V _a953, V[] _rest949) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_954, "to", ((V)(280D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(6D)), ((V)((-27D)))), NewObj(1).PutK(Get(Call(S_10, V.Undef, s_955), "wink"), ((V)(0D))).V), ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(260D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)((-ToNum(s_955)))), ((V)((-1D))), ((V)((-19D)))), NewObj(1).Put("lx", ((V)(((-ToNum(s_955)) * 0.4)))).V), ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(300D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(2).Put("lx", ((V)(0D))).Put("blush", ((V)(0.8))).V), ((V)("io")));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis965, int _argc957, V t_963, V s_964, V _a961, V _a962, V[] _rest958) => {
Call(blushy_48, V.Undef, t_963, ((V)((-ToNum(s_964)))));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis974, int _argc966, V t_972, V s_973, V _a970, V _a971, V[] _rest967) => {
Call(curl_47, V.Undef, t_972, ((V)(700D)), (true ? V.True : V.False));
Call(giggle_32, V.Undef, t_972, ((V)(2D)), ((V)(0.7)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis983, int _argc975, V t_981, V s_982, V _a979, V _a980, V[] _rest976) => {
V a_984 = default;
Invoke(t_981, "to", ((V)(220D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(4D)), ((V)(2D))), NewObj(5).Put("sq", ((V)(0.17))).Put("pitch", ((V)((-0.6)))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V), ((V)("o")));
a_984 = Get(t_981, "t");
Invoke(Invoke(t_981, "to", ((V)(700D)), NewObj(2).Put("spin", ((V)(((-ToNum(s_982)) * 360D)))).Put("x", ((V)(((-ToNum(s_982)) * 3D)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(t_981, "at", Add(a_984, ((V)(701D)))), "wait", ((V)(150D)));
Invoke(t_981, "to", ((V)(500D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(6).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("blush", ((V)(0.9))).V), ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis993, int _argc985, V t_991, V s_992, V _a989, V _a990, V[] _rest986) => {
Call(see_27, V.Undef, t_991, ((V)("foot")), s_992);
Invoke(Invoke(t_991, "osc", ((V)(500D)), ((V)(2D)), NewObj(1).PutK(Get(Call(S_10, V.Undef, s_992), "foot"), ((V)(2D))).V, NewObj(1).PutK(Get(Call(S_10, V.Undef, s_992), "foot"), ((V)(0.5))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).PutK(Get(Call(S_10, V.Undef, s_992), "foot"), ((V)(0D))).V);
Invoke(t_991, "to", ((V)(250D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
Call(unsee_28, V.Undef, t_991);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1002, int _argc994, V t_1000, V s_1001, V _a998, V _a999, V[] _rest995) => {
Call(curl_47, V.Undef, t_1000, ((V)(400D)), (false ? V.True : V.False));
Call(see_27, V.Undef, t_1000, ((V)("tail")), s_1001, ((V)(300D)));
Call(unsee_28, V.Undef, t_1000);
return default;
}, 2, "tail", true)).V).Put("waffles", NewObj(9).Put("head", Fn((V _arrowThis1011, int _argc1003, V t_1009, V s_1010, V _a1007, V _a1008, V[] _rest1004) => {
Invoke(t_1009, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(boof_44, V.Undef, t_1009);
Invoke(Invoke(Invoke(t_1009, "to", ((V)(350D)), NewObj(3).Put("htilt", ((V)(12D))).Put("earL", ((V)(4D))).Put("earR", ((V)((-6D)))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(300D)), NewObj(3).Put("htilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1020, int _argc1012, V t_1018, V s_1019, V _a1016, V _a1017, V[] _rest1013) => {
Call(shake_16, V.Undef, t_1018, NewObj(8).Put("P", ((V)(105D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(1D)), ((V)(0.7)), ((V)(0.4)), ((V)(0.15)))).Put("head", ((V)(0.36))).Put("roll", ((V)(5D))).Put("ear", ((V)(14D))).Put("chest", ((V)(0.22))).Put("body", ((V)(0.8))).Put("tail", ((V)(30D))).V);
Invoke(t_1018, "to", ((V)(200D)), NewObj(4).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1029, int _argc1021, V t_1027, V s_1028, V _a1025, V _a1026, V[] _rest1022) => {
Invoke(t_1027, "to", ((V)(120D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_35, V.Undef, t_1027, ((V)(3D)));
Call(sneeze_34, V.Undef, t_1027, ((V)(0.7)));
Invoke(t_1027, "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1038, int _argc1030, V t_1036, V s_1037, V _a1034, V _a1035, V[] _rest1031) => {
Invoke(t_1036, "e", ((V)("blink2")));
Invoke(Invoke(Invoke(t_1036, "to", ((V)(200D)), NewObj(5).PutK(Get(Call(S_10, V.Undef, s_1037), "wink"), ((V)(0D))).PutK(Get(Call(S_10, V.Undef, ((V)((-ToNum(s_1037))))), "wink"), ((V)(1D))).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.3))).Put("htilt", ((V)(((-ToNum(s_1037)) * 6D)))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(250D)), NewObj(2).PutK(Get(Call(S_10, V.Undef, ((V)((-ToNum(s_1037))))), "wink"), ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1047, int _argc1039, V t_1045, V s_1046, V _a1043, V _a1044, V[] _rest1040) => {
Call(leanIn_39, V.Undef, t_1045, s_1046, NewObj(2).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.25))).V);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1056, int _argc1048, V t_1054, V s_1055, V _a1052, V _a1053, V[] _rest1049) => {
V a_1057 = default;
Invoke(t_1054, "to", ((V)(260D)), NewObj(8).Put("sq", ((V)(0.3))).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.35))).Put("pitch", ((V)(0.1))).V, ((V)("i")));
a_1057 = Get(t_1054, "t");
Invoke(Invoke(t_1054, "osc", ((V)(900D)), ((V)(4D)), NewObj(2).Put("footL", ((V)(3D))).Put("footR", ((V)(0.5))).V, NewObj(2).Put("footL", ((V)(0.5))).Put("footR", ((V)(3D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V);
Call(para_38, V.Undef, t_1054, a_1057, Fn((V _arrowThis1065, int _argc1058, V u_1064, V _a1061, V _a1062, V _a1063, V[] _rest1059) => {
return Call(wag_37, V.Undef, u_1064, ((V)(1020D)), ((V)(36D)), ((V)(9D)));
}, 1, "", true));
Invoke(t_1054, "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1074, int _argc1066, V t_1072, V s_1073, V _a1070, V _a1071, V[] _rest1067) => {
Invoke(t_1072, "to", ((V)(280D)), NewObj(6).Put("pitch", ((V)((-0.3)))).Put("sq", ((V)(0.1))).Put("armL", ((V)((-12D)))).Put("armR", ((V)((-12D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(swing_17, V.Undef, t_1072, ((V)(800D)), ((V)(5D)), NewObj(2).Put("tilt", ((V)(4D))).Put("wag", ((V)(36D))).V);
Call(boof_44, V.Undef, t_1072);
Invoke(t_1072, "to", ((V)(250D)), NewObj(4).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1083, int _argc1075, V t_1081, V s_1082, V _a1079, V _a1080, V[] _rest1076) => {
V k_1084 = default;
k_1084 = Call(S_10, V.Undef, s_1082);
Invoke(t_1081, "to", ((V)(220D)), NewObj(2).PutK(Get(k_1084, "foot"), ((V)(4D))).PutK(Get(k_1084, "arm"), ((V)(30D))).V, ((V)("io")));
Invoke(t_1081, "osc", ((V)(600D)), ((V)(3D)), NewObj(1).PutK(Get(k_1084, "foot"), ((V)(5.5))).V, NewObj(1).PutK(Get(k_1084, "foot"), ((V)(3.5))).V, ((V)("io")));
Invoke(t_1081, "to", ((V)(220D)), NewObj(4).PutK(Get(k_1084, "foot"), ((V)(0D))).PutK(Get(k_1084, "arm"), ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("i")));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1093, int _argc1085, V t_1091, V s_1092, V _a1089, V _a1090, V[] _rest1086) => {
Call(see_27, V.Undef, t_1091, ((V)("tail")), s_1092, ((V)(0D)));
Call(swing_17, V.Undef, t_1091, ((V)(1000D)), ((V)(9D)), NewObj(3).Put("tilt", ((V)(5D))).Put("x", ((V)(0.8))).Put("wag", ((V)(38D))).V);
Call(unsee_28, V.Undef, t_1091);
return default;
}, 2, "tail", true)).V).Put("poppy", NewObj(9).Put("head", Fn((V _arrowThis1102, int _argc1094, V t_1100, V s_1101, V _a1098, V _a1099, V[] _rest1095) => {
Call(freeze_46, V.Undef, t_1100, ((V)(400D)));
Call(wheek_45, V.Undef, t_1100);
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1111, int _argc1103, V t_1109, V s_1110, V _a1107, V _a1108, V[] _rest1104) => {
Call(popcorn_20, V.Undef, t_1109, ((V)(9D)), ((V)((-ToNum(s_1110)))), ((V)(480D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1120, int _argc1112, V t_1118, V s_1119, V _a1116, V _a1117, V[] _rest1113) => {
Invoke(t_1118, "to", ((V)(100D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Invoke(t_1118, "osc", ((V)(700D)), ((V)(5D)), NewObj(2).Put("sq", ((V)(0.025))).Put("mw", ((V)(0.8))).V, NewObj(2).Put("sq", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o")));
Call(wheek_45, V.Undef, t_1118);
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1129, int _argc1121, V t_1127, V s_1128, V _a1125, V _a1126, V[] _rest1122) => {
V a_1130 = default;
Invoke(t_1127, "e", ((V)("blink2")));
a_1130 = Get(t_1127, "t");
Invoke(t_1127, "to", ((V)(300D)), NewObj(3).Put("x", ((V)(((-ToNum(s_1128)) * 4D)))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("o")));
Call(para_38, V.Undef, t_1127, a_1130, Fn((V _arrowThis1138, int _argc1131, V u_1137, V _a1134, V _a1135, V _a1136, V[] _rest1132) => {
return Call(steps_18, V.Undef, u_1137, ((V)(300D)), ((V)(3D)), ((V)(1.8)));
}, 1, "", true));
Invoke(t_1127, "wait", ((V)(300D)));
Call(walkBack_31, V.Undef, t_1127, ((V)(500D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1147, int _argc1139, V t_1145, V s_1146, V _a1143, V _a1144, V[] _rest1140) => {
Invoke(t_1145, "to", ((V)(350D)), NewObj(4).Put("close", ((V)(0.85))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("htilt", ((V)((ToNum(s_1146) * 6D)))).V, ((V)("io")));
Invoke(t_1145, "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("sq", ((V)(0.02))).V, NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_1145, "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1156, int _argc1148, V t_1154, V s_1155, V _a1152, V _a1153, V[] _rest1149) => {
Call(popcorn_20, V.Undef, t_1154, ((V)(12D)), ((V)(1D)), ((V)(520D)));
Call(popcorn_20, V.Undef, t_1154, ((V)(9D)), ((V)((-1D))), ((V)(460D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1165, int _argc1157, V t_1163, V s_1164, V _a1161, V _a1162, V[] _rest1158) => {
V a_1166 = default;
a_1166 = Get(t_1163, "t");
Invoke(t_1163, "to", ((V)(380D)), NewObj(2).Put("x", ((V)(((-ToNum(s_1164)) * 6D)))).Put("lean", ((V)(((-ToNum(s_1164)) * 2D)))).V, ((V)("o")));
Call(para_38, V.Undef, t_1163, a_1166, Fn((V _arrowThis1174, int _argc1167, V u_1173, V _a1170, V _a1171, V _a1172, V[] _rest1168) => {
return Call(steps_18, V.Undef, u_1173, ((V)(380D)), ((V)(5D)), ((V)(2D)));
}, 1, "", true));
Call(wheek_45, V.Undef, t_1163);
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1183, int _argc1175, V t_1181, V s_1182, V _a1179, V _a1180, V[] _rest1176) => {
Call(steps_18, V.Undef, t_1181, ((V)(500D)), ((V)(4D)), ((V)(2D)));
Call(popcorn_20, V.Undef, t_1181, ((V)(10D)), s_1182, ((V)(500D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1192, int _argc1184, V t_1190, V s_1191, V _a1188, V _a1189, V[] _rest1185) => {
Call(popcorn_20, V.Undef, t_1190, ((V)(11D)), ((V)(1D)), ((V)(520D)));
Call(see_27, V.Undef, t_1190, ((V)("tail")), s_1191, ((V)(200D)));
Call(unsee_28, V.Undef, t_1190);
Call(wheek_45, V.Undef, t_1190);
return default;
}, 2, "tail", true)).V).Put("duchess", NewObj(9).Put("head", Fn((V _arrowThis1201, int _argc1193, V t_1199, V s_1200, V _a1197, V _a1198, V[] _rest1194) => {
Invoke(Invoke(Invoke(t_1199, "to", ((V)(180D)), NewObj(4).Put("wide", ((V)(1D))).Put("pitch", ((V)(0.12))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(400D))), "to", ((V)(200D)), NewObj(3).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
Call(smooth_51, V.Undef, t_1199, ((V)(1D)), ((V)("head")));
Invoke(Invoke(t_1199, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0.15))).Put("close", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(300D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1210, int _argc1202, V t_1208, V s_1209, V _a1206, V _a1207, V[] _rest1203) => {
Call(hmph_33, V.Undef, t_1208, ((V)((-ToNum(s_1209)))));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1219, int _argc1211, V t_1217, V s_1218, V _a1215, V _a1216, V[] _rest1212) => {
Invoke(t_1217, "to", ((V)(120D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_35, V.Undef, t_1217, ((V)(2D)));
Invoke(t_1217, "to", ((V)(250D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-18D))))), ((V)("io")));
Call(sneeze_34, V.Undef, t_1217, ((V)(0.45)));
Invoke(t_1217, "to", ((V)(250D)), NOHANDS_14, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1228, int _argc1220, V t_1226, V s_1227, V _a1224, V _a1225, V[] _rest1221) => {
Invoke(Invoke(Invoke(Invoke(t_1226, "to", ((V)(500D)), NewObj(1).Put("close", ((V)(1D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(4).Put("close", ((V)(0.4))).Put("frown", ((V)(0.45))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0D))).Put("frown", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1237, int _argc1229, V t_1235, V s_1236, V _a1233, V _a1234, V[] _rest1230) => {
Call(leanIn_39, V.Undef, t_1235, s_1236, NewObj(1).Put("pitch", ((V)(0.08))).V);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1246, int _argc1238, V t_1244, V s_1245, V _a1242, V _a1243, V[] _rest1239) => {
Invoke(t_1244, "to", ((V)(150D)), NewObj(3).Put("wide", ((V)(0.6))).Put("frown", ((V)(0.5))).Put("ly", ((V)(0.6))).V, ((V)("o")));
Call(swat_40, V.Undef, t_1244, ((V)(1D)), ((V)(2D)));
Call(hmph_33, V.Undef, t_1244, ((V)((-1D))));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1255, int _argc1247, V t_1253, V s_1254, V _a1251, V _a1252, V[] _rest1248) => {
Invoke(t_1253, "to", ((V)(200D)), NewObj(2).Put("frown", ((V)(0.4))).Put("pitch", ((V)(0.12))).V, ((V)("io")));
Call(smooth_51, V.Undef, t_1253, s_1254, ((V)("side")));
Invoke(t_1253, "to", ((V)(250D)), NewObj(2).Put("frown", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1264, int _argc1256, V t_1262, V s_1263, V _a1260, V _a1261, V[] _rest1257) => {
Call(pawShake_41, V.Undef, t_1262, s_1263, ((V)(0.6)));
Invoke(Invoke(t_1262, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0.15))).Put("close", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(300D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1273, int _argc1265, V t_1271, V s_1272, V _a1269, V _a1270, V[] _rest1266) => {
Call(see_27, V.Undef, t_1271, ((V)("tail")), s_1272, ((V)(0D)));
Invoke(t_1271, "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0.45))).Put("frown", ((V)(0.5))).V, ((V)("io")));
Call(swing_17, V.Undef, t_1271, ((V)(1100D)), ((V)(3D)), NewObj(2).Put("wag", ((V)(26D))).Put("curl", ((V)(0.3))).V);
Call(unsee_28, V.Undef, t_1271);
return default;
}, 2, "tail", true)).V).Put("mamapaws", NewObj(9).Put("head", Fn((V _arrowThis1282, int _argc1274, V t_1280, V s_1281, V _a1278, V _a1279, V[] _rest1275) => {
Invoke(t_1280, "to", ((V)(300D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_1280, "to", ((V)(400D)), NewObj(3).Put("pitch", ((V)((-0.28)))).Put("ly", ((V)(0.8))).Put("htilt", ((V)((-5D)))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(1D)), NewObj(1).Put("htilt", ((V)((-9D)))).V, NewObj(1).Put("htilt", ((V)((-5D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
Call(unsee_28, V.Undef, t_1280, ((V)(400D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1291, int _argc1283, V t_1289, V s_1290, V _a1287, V _a1288, V[] _rest1284) => {
Call(headShake_42, V.Undef, t_1289, ((V)(0.7)), ((V)(110D)));
Call(giggle_32, V.Undef, t_1289, ((V)(2D)), ((V)(0.7)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1300, int _argc1292, V t_1298, V s_1299, V _a1296, V _a1297, V[] _rest1293) => {
Invoke(t_1298, "to", ((V)(120D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_35, V.Undef, t_1298, ((V)(2D)));
Call(lick_36, V.Undef, t_1298, ((V)(1D)));
Invoke(t_1298, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1309, int _argc1301, V t_1307, V s_1308, V _a1305, V _a1306, V[] _rest1302) => {
Invoke(Invoke(t_1307, "e", ((V)("blink2"))), "wait", ((V)(200D)));
Invoke(Invoke(t_1307, "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)((-0.25)))).Put("ly", ((V)(0.8))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(500D)));
Call(unsee_28, V.Undef, t_1307, ((V)(400D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1318, int _argc1310, V t_1316, V s_1317, V _a1314, V _a1315, V[] _rest1311) => {
Call(leanIn_39, V.Undef, t_1316, s_1317);
Invoke(t_1316, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1327, int _argc1319, V t_1325, V s_1326, V _a1323, V _a1324, V[] _rest1320) => {
Invoke(t_1325, "to", ((V)(250D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(8D)), ((V)((-5D)))), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
Call(giggle_32, V.Undef, t_1325, ((V)(3D)), ((V)(0.8)));
Invoke(Invoke(t_1325, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.7))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
Call(unsee_28, V.Undef, t_1325, ((V)(300D)));
Invoke(t_1325, "to", ((V)(200D)), Call(both_12, V.Undef, ((V)(6D)), ((V)((-6D)))), ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1336, int _argc1328, V t_1334, V s_1335, V _a1332, V _a1333, V[] _rest1329) => {
Call(jelly_19, V.Undef, t_1334, ((V)(3D)), ((V)(3D)), ((V)(300D)), ((V)("bend")));
Invoke(Invoke(t_1334, "to", ((V)(400D)), NewObj(2).Put("pitch", ((V)((-0.25)))).Put("ly", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(300D)));
Call(unsee_28, V.Undef, t_1334, ((V)(350D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1345, int _argc1337, V t_1343, V s_1344, V _a1341, V _a1342, V[] _rest1338) => {
Call(see_27, V.Undef, t_1343, ((V)("foot")), s_1344, ((V)(200D)));
Invoke(t_1343, "to", ((V)(300D)), NewObj(1).PutK(Get(Call(S_10, V.Undef, s_1344), "foot"), ((V)(0D))).V, ((V)("io")));
Call(unsee_28, V.Undef, t_1343);
Invoke(t_1343, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1354, int _argc1346, V t_1352, V s_1353, V _a1350, V _a1351, V[] _rest1347) => {
Call(see_27, V.Undef, t_1352, ((V)("tail")), s_1353, ((V)(200D)));
Call(unsee_28, V.Undef, t_1352);
Invoke(Invoke(t_1352, "to", ((V)(400D)), NewObj(2).Put("pitch", ((V)((-0.25)))).Put("ly", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(300D)));
Call(unsee_28, V.Undef, t_1352, ((V)(300D)));
return default;
}, 2, "tail", true)).V).Put("ribbit", NewObj(9).Put("head", Fn((V _arrowThis1363, int _argc1355, V t_1361, V s_1362, V _a1359, V _a1360, V[] _rest1356) => {
Invoke(Invoke(t_1361, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(200D)));
Call(jump_15, V.Undef, t_1361, NewObj(6).Put("h", ((V)(10D))).Put("ant", ((V)(60D))).Put("up", ((V)(220D))).Put("c", ((V)(0.3))).Put("arm", ((V)(50D))).Put("st", ((V)(1.1))).V);
return default;
}, 2, "head", true)).Put("ear", Fn((V _arrowThis1372, int _argc1364, V t_1370, V s_1371, V _a1368, V _a1369, V[] _rest1365) => {
Invoke(t_1370, "e", ((V)("blink")));
Invoke(t_1370, "to", ((V)(300D)), NewObj(1).PutK(Get(Call(S_10, V.Undef, s_1371), "wink"), ((V)(0D))).V, ((V)("io")));
Call(croak_21, V.Undef, t_1370, ((V)(1D)), ((V)(420D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _arrowThis1381, int _argc1373, V t_1379, V s_1380, V _a1377, V _a1378, V[] _rest1374) => {
Invoke(t_1379, "to", ((V)(120D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.1))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_1379, "to", ((V)(80D)), NewObj(4).Put("tongue", ((V)(1D))).Put("open", ((V)(0.5))).Put("pitch", ((V)(0.12))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(4).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.05)))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0.06))).Put("puff", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(5).Put("sq", ((V)(0D))).Put("puff", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _arrowThis1390, int _argc1382, V t_1388, V s_1389, V _a1386, V _a1387, V[] _rest1383) => {
Invoke(Invoke(t_1388, "e", ((V)("blink2"))), "to", ((V)(250D)), NewObj(2).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
Call(croak_21, V.Undef, t_1388, ((V)(1D)), ((V)(400D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _arrowThis1399, int _argc1391, V t_1397, V s_1398, V _a1395, V _a1396, V[] _rest1392) => {
Call(croak_21, V.Undef, t_1397, ((V)(2D)), ((V)(420D)));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _arrowThis1408, int _argc1400, V t_1406, V s_1407, V _a1404, V _a1405, V[] _rest1401) => {
V a_1409 = default;
Invoke(t_1406, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
a_1409 = Get(t_1406, "t");
Call(croak_21, V.Undef, t_1406, ((V)(3D)), ((V)(330D)));
Call(para_38, V.Undef, t_1406, a_1409, Fn((V _arrowThis1417, int _argc1410, V u_1416, V _a1413, V _a1414, V _a1415, V[] _rest1411) => {
return Call(jelly_19, V.Undef, u_1416, ((V)(0.1)), ((V)(4D)), ((V)(250D)));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _arrowThis1426, int _argc1418, V t_1424, V s_1425, V _a1422, V _a1423, V[] _rest1419) => {
Call(jump_15, V.Undef, t_1424, NewObj(6).Put("h", ((V)(9D))).Put("ant", ((V)(120D))).Put("up", ((V)(200D))).Put("c", ((V)(0.22))).Put("arm", ((V)(45D))).Put("x", ((V)(((-ToNum(s_1425)) * 6D)))).V);
Invoke(t_1424, "wait", ((V)(200D)));
Call(jump_15, V.Undef, t_1424, NewObj(6).Put("h", ((V)(8D))).Put("ant", ((V)(120D))).Put("up", ((V)(200D))).Put("c", ((V)(0.2))).Put("arm", ((V)(40D))).Put("x", ((V)(0D))).V);
return default;
}, 2, "side", true)).Put("foot", Fn((V _arrowThis1435, int _argc1427, V t_1433, V s_1434, V _a1431, V _a1432, V[] _rest1428) => {
Call(jump_15, V.Undef, t_1433, NewObj(6).Put("h", ((V)(14D))).Put("ant", ((V)(100D))).Put("up", ((V)(250D))).Put("c", ((V)(0.26))).Put("arm", ((V)(60D))).Put("st", ((V)(1.1))).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _arrowThis1444, int _argc1436, V t_1442, V s_1443, V _a1440, V _a1441, V[] _rest1437) => {
V a_1445 = default;
a_1445 = Get(t_1442, "t");
Invoke(Invoke(t_1442, "osc", ((V)(500D)), ((V)(2D)), NewObj(1).Put("footR", ((V)(4D))).V, NewObj(1).Put("footR", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("footR", ((V)(0D))).V);
Call(jump_15, V.Undef, t_1442, NewObj(5).Put("h", ((V)(10D))).Put("ant", ((V)(100D))).Put("up", ((V)(220D))).Put("c", ((V)(0.22))).Put("arm", ((V)(45D))).V);
return default;
}, 2, "tail", true)).V).V;
TXT_53 = NewObj(10).Put("mittens", NewObj(9).Put("head", ((V)("Bonk: rubs his head with a little pout."))).Put("ear", ((V)("Ear flicks, a quick cat head shake, giggles."))).Put("nose", ((V)("Cross-eyed, sneezes, rubs his nose."))).Put("eye", ((V)("Flinches, rubs his eye, blinks it clear."))).Put("cheek", ((V)("Leans into your finger and rubs against it, purring."))).Put("belly", ((V)("Ticklish: giggles and bats at your finger."))).Put("side", ((V)("Steps to catch his balance, looks, rubs the spot, walks back."))).Put("foot", ((V)("Shakes his paw like a cat stepping in water."))).Put("tail", ((V)("Tail puffs up, he hops, glares back at it, tail lashes."))).V).Put("biscuit", NewObj(9).Put("head", ((V)("Thinks it is a pat: pushes up into it, tongue out, tail wagging."))).Put("ear", ((V)("Ear flips, puppy head tilt, then a shake."))).Put("nose", ((V)("Sniffs your finger and licks it."))).Put("eye", ((V)("Blinks, paw rub, wags it off."))).Put("cheek", ((V)("Leans in with his tongue out."))).Put("belly", ((V)("Belly-rub bliss: eyes shut, his back leg kicks, tail thumping."))).Put("side", ((V)("Stumbles into a play bow and a happy boof."))).Put("foot", ((V)("Offers you his paw to shake."))).Put("tail", ((V)("Spins round after his tail."))).V).Put("truffle", NewObj(9).Put("head", ((V)("His whole round body jiggles, two snorts."))).Put("ear", ((V)("A piggy head shake and a snort."))).Put("nose", ((V)("Snorts at your finger and sniffs it."))).Put("eye", ((V)("Blinks, rubs it with a hoof, snorts."))).Put("cheek", ((V)("His cheeks wobble and he giggles."))).Put("belly", ((V)("Belly jiggles like jelly, he giggles and pats it."))).Put("side", ((V)("Wobbles side to side like jelly."))).Put("foot", ((V)("Stomps his hoof, dust puffs up, snorts."))).Put("tail", ((V)("Curly tail springs, looks back, oinks."))).V).Put("nibbles", NewObj(9).Put("head", ((V)("The hamster freeze, eyes dart, nose twitches."))).Put("ear", ((V)("Quick ear twitches, little head shake."))).Put("nose", ((V)("Nose twitches like crazy, cheeks puff."))).Put("eye", ((V)("Hamster face-wash with both paws."))).Put("cheek", ((V)("Cheek balloons and pops a seed out, giggles."))).Put("belly", ((V)("Quick ticklish giggles, paws clasped."))).Put("side", ((V)("Zips sideways, freezes, eyes dart."))).Put("foot", ((V)("Tiny jump, runs on the spot."))).Put("tail", ((V)("Spins round to see what touched him, sniffs."))).V).Put("quill", NewObj(9).Put("head", ((V)("Ducks with his eyes shut, peeks up, blushes."))).Put("ear", ((V)("Shy shrug, hides his face, blushes."))).Put("nose", ((V)("Nose wiggles, covers it with both paws."))).Put("eye", ((V)("Covers his eyes, peeks through one side."))).Put("cheek", ((V)("Blushes deep and looks away shyly."))).Put("belly", ((V)("Curls into a ball and trembles, then giggles."))).Put("side", ((V)("Curls up and rolls away, uncurls blushing."))).Put("foot", ((V)("Wiggles his foot, looks down, blushes."))).Put("tail", ((V)("Curls up, then peeks back over his shoulder."))).V).Put("waffles", NewObj(9).Put("head", ((V)("Happy boof and a head tilt."))).Put("ear", ((V)("A full dog shake, tongue out."))).Put("nose", ((V)("Sniffs, a little play-sneeze."))).Put("eye", ((V)("Goofy wink with his tongue out."))).Put("cheek", ((V)("Leans in, tongue out."))).Put("belly", ((V)("Flops flat, legs kicking, stub tail going."))).Put("side", ((V)("Play bow, butt wiggle, boof."))).Put("foot", ((V)("Lifts his paw and waves it."))).Put("tail", ((V)("Frantic butt wiggle, looks back."))).V).Put("poppy", NewObj(9).Put("head", ((V)("Freezes, then wheeks."))).Put("ear", ((V)("A sudden popcorn hop."))).Put("nose", ((V)("Nose twitches, wheeks."))).Put("eye", ((V)("Blinks and scoots back on pattering feet."))).Put("cheek", ((V)("Leans in with her eyes shut, content."))).Put("belly", ((V)("Two popcorn hops."))).Put("side", ((V)("Zips sideways, wheeks, creeps back."))).Put("foot", ((V)("Pitter-pats, then pops."))).Put("tail", ((V)("Pops straight up, looks back, wheeks."))).V).Put("duchess", NewObj(9).Put("head", ((V)("Appalled, then smooths her fur and lifts her chin."))).Put("ear", ((V)("Hmph: frowns and turns her head away."))).Put("nose", ((V)("Dainty sniff, a tiny sneeze behind her paw."))).Put("eye", ((V)("A slow blink, then a glare."))).Put("cheek", ((V)("Leans into it, purring - she likes that one."))).Put("belly", ((V)("NOT the belly: swats at your finger, hmph."))).Put("side", ((V)("Smooths her fur where you poked."))).Put("foot", ((V)("Shakes her paw daintily, chin up."))).Put("tail", ((V)("Tail lashes, glares back over her shoulder."))).V).Put("mamapaws", NewObj(9).Put("head", ((V)("Warm smile, nuzzles her pup."))).Put("ear", ((V)("Gentle head shake and a soft laugh."))).Put("nose", ((V)("Sniffs your finger, a gentle lick."))).Put("eye", ((V)("Blinks, then checks her pup."))).Put("cheek", ((V)("Leans in, hearts."))).Put("belly", ((V)("Hugs her pup closer, giggles."))).Put("side", ((V)("Wobbles like jelly, checks her pup."))).Put("foot", ((V)("Looks down at her paw, smiles."))).Put("tail", ((V)("Looks back, then checks her pup."))).V).Put("ribbit", NewObj(9).Put("head", ((V)("Squashed flat, springs back up."))).Put("ear", ((V)("That eye blinks, a croak."))).Put("nose", ((V)("Zaps your finger with his tongue, gulps."))).Put("eye", ((V)("Double blink, a croak."))).Put("cheek", ((V)("Two big throat-puffing croaks."))).Put("belly", ((V)("Giggly croaks, belly jiggles."))).Put("side", ((V)("Hops away to the side and back."))).Put("foot", ((V)("Springs straight up."))).Put("tail", ((V)("Kicks his back leg, hops."))).V).V;
NAME_54 = NewObj(9).Put("head", ((V)("Top of head"))).Put("ear", ((V)("ear"))).Put("nose", ((V)("Nose"))).Put("eye", ((V)("eye"))).Put("cheek", ((V)("cheek"))).Put("belly", ((V)("Belly"))).Put("side", ((V)("side"))).Put("foot", ((V)("foot"))).Put("tail", ((V)("Tail"))).V;
SPOTS_55 = Arr(Arr(((V)("head")), ((V)(0D))), Arr(((V)("earL")), ((V)((-1D)))), Arr(((V)("earR")), ((V)(1D))), Arr(((V)("nose")), ((V)(0D))), Arr(((V)("eyeL")), ((V)((-1D)))), Arr(((V)("eyeR")), ((V)(1D))), Arr(((V)("cheekL")), ((V)((-1D)))), Arr(((V)("cheekR")), ((V)(1D))), Arr(((V)("belly")), ((V)(0D))), Arr(((V)("sideL")), ((V)((-1D)))), Arr(((V)("sideR")), ((V)(1D))), Arr(((V)("footL")), ((V)((-1D)))), Arr(((V)("footR")), ((V)(1D))), Arr(((V)("tail")), ((V)(1D))));
build_56 = Fn((V _arrowThis1455, int _argc1446, V RE_1452, V TXT_1453, V BODY_1454, V _a1451, V[] _rest1447) => {
V ST_1456 = default;
ST_1456 = NewObj(0).V;
{
foreach (V _k1457 in ForInKeys(RE_1452)) {
V key_1458 = default;
key_1458 = _k1457;
V B_1459 = default;
V T_1460 = default;
V D_1461 = default;
B_1459 = (GetK(BODY_1454, key_1458) is var _t1462 && Truthy(_t1462) ? _t1462 : NewObj(0).V);
T_1460 = ((GetK(CARD_22, key_1458) is var _t1463 && !Truthy(_t1463) ? _t1463 : Get(GetK(CARD_22, key_1458), "T")) is var _t1464 && Truthy(_t1464) ? _t1464 : ((V)(1D)));
D_1461 = SetK(DESC_23, key_1458, (GetK(DESC_23, key_1458) is var _t1465 && Truthy(_t1465) ? _t1465 : NewObj(0).V));
Invoke(SPOTS_55, "forEach", Fn((V _arrowThis1477, int _argc1466, V _a1468, V _a1469, V _a1470, V _a1471, V[] _rest1467) => {
V spot_1478 = default;
V t_1479 = default;
V tap_1480 = default;
V tp_1481 = default;
V side_1482 = default;
V L_1483 = default;
V label_1484 = default;
V tx_1485 = default;
V nm_1474 = default;
V s_1476 = default;
{ V _t1472 = ListOf(_a1468);
{ V _t1473 = GetIdx(_t1472, 0D);
nm_1474 = _t1473; }
{ V _t1475 = GetIdx(_t1472, 1D);
s_1476 = _t1475; }
}
spot_1478 = Invoke(nm_1474, "replace", NewRegExp(RX0, "[LR]$", ""), ((V)("")));
t_1479 = Call(TL_9, V.Undef, NewObj(0).V, T_1460);
InvokeK(HIT_25, spot_1478, t_1479, s_1476, B_1459);
InvokeK(GetK(RE_1452, key_1458), spot_1478, t_1479, s_1476, B_1459);
if ((SEqS(spot_1478, "side") && !(Truthy(Get(B_1459, "noWalk"))))) {
if (Truthy(Get(B_1459, "hopBack"))) {
Call(jump_15, V.Undef, t_1479, NewObj(6).Put("h", ((V)(4D))).Put("ant", ((V)(120D))).Put("up", ((V)(170D))).Put("c", ((V)(0.1))).Put("arm", ((V)(20D))).Put("x", ((V)(0D))).V);
} else {
Call(walkBack_31, V.Undef, t_1479, ((V)(480D)));
}
}
Invoke(t_1479, "rest", ((V)(420D)));
tap_1480 = Get((GetK(Get(R_8, "STATES"), ((V)(JsStrBuf.Begin().S("poke_").V(nm_1474).End()))) is var _t1486 && Truthy(_t1486) ? _t1486 : NewObj(0).V), "tap");
tp_1481 = tap_1480;
if (Truthy((Get(B_1459, "earTap") is var _t1487 && !Truthy(_t1487) ? _t1487 : (SEqS(spot_1478, "ear") ? V.True : V.False)))) {
tp_1481 = Arr((LtN(s_1476, 0D) ? GetIdx(Get(B_1459, "earTap"), 0D) : ((V)((100D - ToNum(GetIdx(Get(B_1459, "earTap"), 0D)))))), GetIdx(Get(B_1459, "earTap"), 1D));
}
if ((SEqS(spot_1478, "tail") && !(Truthy(Get(B_1459, "tail"))))) {
tp_1481 = (Get(B_1459, "tailTap") is var _t1488 && Truthy(_t1488) ? _t1488 : Arr(((V)(78D)), ((V)(72D))));
}
SetK(ST_1456, ((V)(JsStrBuf.Begin().S("poke_").V(nm_1474).S("@").V(key_1458).End())), Invoke(t_1479, "done", NewObj(2).Put("tap", tp_1481).Put("stretch", ((V)(0.5))).V));
side_1482 = ((V)((LtN(s_1476, 0D) ? "Left " : ((GtN(s_1476, 0D) && !SEqS(spot_1478, "tail")) ? "Right " : ""))));
L_1483 = (Get(B_1459, "lbl") is var _t1489 && !Truthy(_t1489) ? _t1489 : GetK(Get(B_1459, "lbl"), spot_1478));
label_1484 = (Truthy(L_1483) ? (string.Equals(Typeof(L_1483), "function") ? Call(L_1483, V.Undef, s_1476) : Add(((((SEqS(spot_1478, "head") || SEqS(spot_1478, "nose")) || SEqS(spot_1478, "belly")) || SEqS(spot_1478, "tail")) ? ((V)("")) : side_1482), L_1483)) : (((SEqS(spot_1478, "head") || SEqS(spot_1478, "nose")) || SEqS(spot_1478, "belly")) ? GetK(NAME_54, spot_1478) : (SEqS(spot_1478, "tail") ? ((V)((Truthy(Get(B_1459, "tail")) ? "Tail" : "Back end"))) : Add(side_1482, GetK(NAME_54, spot_1478)))));
tx_1485 = GetK(GetK(TXT_1453, key_1458), spot_1478);
SetK(D_1461, ((V)(JsStrBuf.Begin().S("poke_").V(nm_1474).End())), Arr(label_1484, (string.Equals(Typeof(tx_1485), "function") ? Call(tx_1485, V.Undef, s_1476) : tx_1485)));
return default;
}, 1, "", true));
}
}
Invoke(R_8, "add", ST_1456);
return default;
}, 3, "", true);
Set(R_8, "POKELIB", NewObj(25).Put("HIT", HIT_25).Put("SEE", SEE_26).Put("see", see_27).Put("unsee", unsee_28).Put("SPOT", SPOT_29).Put("rub", rub_30).Put("walkBack", walkBack_31).Put("giggle", giggle_32).Put("hmph", hmph_33).Put("sneeze", sneeze_34).Put("sniff", sniff_35).Put("lick", lick_36).Put("para", para_38).Put("leanIn", leanIn_39).Put("swat", swat_40).Put("pawShake", pawShake_41).Put("headShake", headShake_42).Put("snort", snort_43).Put("freeze", freeze_46).Put("curl", curl_47).Put("blushy", blushy_48).Put("happy", happy_49).Put("pat", pat_50).Put("smooth", smooth_51).Put("build", build_56).V);
Call(build_56, V.Undef, RE_52, TXT_53, BODY_24);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
