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
SEE_26 = NewObj(9).Put("head", Fn((V _self1, int _argc164, V _a166, V _a167, V _a168, V _a169, V[] _rest165) => {
return NewObj(2).Put("ly", ((V)((-0.9)))).Put("pitch", ((V)(0.1))).V;
}, 0, "head", true)).Put("ear", Fn((V _self1, int _argc170, V s_176, V _a173, V _a174, V _a175, V[] _rest171) => {
return NewObj(4).Put("lx", ((V)((ToNum(s_176) * 0.8)))).Put("ly", ((V)((-0.7)))).Put("hyaw", ((V)((ToNum(s_176) * 0.2)))).Put("htilt", ((V)((ToNum(s_176) * 4D)))).V;
}, 1, "ear", true)).Put("cheek", Fn((V _self1, int _argc177, V s_183, V _a180, V _a181, V _a182, V[] _rest178) => {
return NewObj(3).Put("lx", ((V)((ToNum(s_183) * 0.6)))).Put("ly", ((V)(0.3))).Put("hyaw", ((V)((ToNum(s_183) * 0.1)))).V;
}, 1, "cheek", true)).Put("belly", Fn((V _self1, int _argc184, V _a186, V _a187, V _a188, V _a189, V[] _rest185) => {
return NewObj(2).Put("ly", ((V)(0.9))).Put("pitch", ((V)((-0.25)))).V;
}, 0, "belly", true)).Put("side", Fn((V _self1, int _argc190, V s_196, V _a193, V _a194, V _a195, V[] _rest191) => {
return NewObj(5).Put("lx", ((V)((ToNum(s_196) * 0.9)))).Put("ly", ((V)(0.5))).Put("hyaw", ((V)((ToNum(s_196) * 0.3)))).Put("pitch", ((V)((-0.1)))).Put("twist", ((V)((ToNum(s_196) * 0.1)))).V;
}, 1, "side", true)).Put("foot", Fn((V _self1, int _argc197, V s_203, V _a200, V _a201, V _a202, V[] _rest198) => {
return NewObj(4).Put("lx", ((V)((ToNum(s_203) * 0.5)))).Put("ly", ((V)(1D))).Put("pitch", ((V)((-0.3)))).Put("hyaw", ((V)((ToNum(s_203) * 0.15)))).V;
}, 1, "foot", true)).Put("tail", Fn((V _self1, int _argc204, V _a206, V _a207, V _a208, V _a209, V[] _rest205) => {
return NewObj(4).Put("lx", ((V)(0.9))).Put("ly", ((V)(0.3))).Put("hyaw", ((V)(0.6))).Put("twist", ((V)(0.25))).V;
}, 0, "tail", true)).Put("nose", Fn((V _self1, int _argc210, V _a212, V _a213, V _a214, V _a215, V[] _rest211) => {
return NewObj(2).Put("ly", ((V)(0.6))).Put("cross", ((V)(1D))).V;
}, 0, "nose", true)).Put("eye", Fn((V _self1, int _argc216, V _a218, V _a219, V _a220, V _a221, V[] _rest217) => {
return NewObj(0).V;
}, 0, "eye", true)).V;
see_27 = Fn((V _self1, int _argc222, V t_228, V spot_229, V s_230, V hold_231, V[] _rest223) => {
V v_232 = default;
V ey_233 = default;
V hd_234 = default;
v_232 = InvokeK(SEE_26, spot_229, s_230);
ey_233 = NewObj(0).V;
hd_234 = NewObj(0).V;
{
foreach (V _k235 in ForInKeys(v_232)) {
V p_236 = default;
p_236 = _k235;
SetK((((SEqS(p_236, "lx") || SEqS(p_236, "ly")) || SEqS(p_236, "cross")) ? ey_233 : hd_234), p_236, GetK(v_232, p_236));
}
}
Invoke(Invoke(Invoke(t_228, "to", ((V)(110D)), ey_233, ((V)("o"))), "e", ((V)("blink"))), "to", ((V)(320D)), hd_234, ((V)("io")));
return (Truthy(hold_231) ? Invoke(t_228, "wait", hold_231) : t_228);
return default;
}, 4, "", true);
unsee_28 = Fn((V _self1, int _argc237, V t_243, V d_244, V _a241, V _a242, V[] _rest238) => {
return Invoke(t_243, "to", (d_244 is var _t245 && Truthy(_t245) ? _t245 : ((V)(320D))), NewObj(7).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("twist", ((V)(0D))).Put("cross", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
SPOT_29 = NewObj(7).Put("head", Fn((V _self1, int _argc246, V s_252, V _a249, V _a250, V _a251, V[] _rest247) => {
return Call(hand_11, V.Undef, s_252, ((V)((-2D))), ((V)((-30D))));
}, 1, "head", true)).Put("ear", Fn((V _self1, int _argc253, V s_259, V _a256, V _a257, V _a258, V[] _rest254) => {
return Call(hand_11, V.Undef, s_259, ((V)((-6D))), ((V)((-31D))));
}, 1, "ear", true)).Put("eye", Fn((V _self1, int _argc260, V s_266, V _a263, V _a264, V _a265, V[] _rest261) => {
return Call(hand_11, V.Undef, s_266, ((V)(6D)), ((V)((-27D))));
}, 1, "eye", true)).Put("cheek", Fn((V _self1, int _argc267, V s_273, V _a270, V _a271, V _a272, V[] _rest268) => {
return Call(hand_11, V.Undef, s_273, ((V)(2D)), ((V)((-18D))));
}, 1, "cheek", true)).Put("nose", Fn((V _self1, int _argc274, V _a276, V _a277, V _a278, V _a279, V[] _rest275) => {
return Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-18D))));
}, 0, "nose", true)).Put("side", Fn((V _self1, int _argc280, V s_286, V _a283, V _a284, V _a285, V[] _rest281) => {
return Call(hand_11, V.Undef, s_286, ((V)((-3D))), ((V)((-2D))));
}, 1, "side", true)).Put("mouth", Fn((V _self1, int _argc287, V s_293, V _a290, V _a291, V _a292, V[] _rest288) => {
return Call(hand_11, V.Undef, s_293, ((V)(13D)), ((V)((-15D))));
}, 1, "mouth", true)).V;
rub_30 = Fn((V _self1, int _argc294, V t_300, V s_301, V where_302, V n_303, V[] _rest295) => {
V h_305 = default;
V k_306 = default;
V x_304 = default;
x_304 = (_argc294 > 4 ? _rest295[0] : V.Undef);
s_301 = (s_301 is var _t307 && Truthy(_t307) ? _t307 : ((V)(1D)));
h_305 = InvokeK(SPOT_29, where_302, s_301);
k_306 = Call(S_10, V.Undef, s_301);
Invoke(t_300, "to", ((V)(300D)), Call(o_13, V.Undef, h_305, NewObj(1).PutK(Get(k_306, "arm"), ((V)((SEqS(where_302, "side") ? 0D : 22D)))).V, (x_304 is var _t308 && Truthy(_t308) ? _t308 : NewObj(0).V)), ((V)("io")));
{
double i_309 = 0;
i_309 = 0D;
while (true) {
if (!(Lt(((V)(i_309)), (n_303 is var _t311 && Truthy(_t311) ? _t311 : ((V)(3D)))))) break;
Invoke(Invoke(t_300, "to", ((V)(170D)), NewObj(2).PutK(Get(k_306, "hx"), Add(GetK(h_305, Get(k_306, "hx")), ((V)((LtN(s_301, 0D) ? 3D : (-3D)))))).PutK(Get(k_306, "hy"), ((V)((ToNum(GetK(h_305, Get(k_306, "hy"))) - 1.5)))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(2).PutK(Get(k_306, "hx"), GetK(h_305, Get(k_306, "hx"))).PutK(Get(k_306, "hy"), GetK(h_305, Get(k_306, "hy"))).V, ((V)("io")));
i_309++;
}
}
return Invoke(t_300, "to", ((V)(280D)), NewObj(5).PutK(Get(k_306, "hx"), ((V)(0D))).PutK(Get(k_306, "hy"), ((V)(0D))).PutK(Get(k_306, "arm"), ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
return default;
}, 5, "", true);
walkBack_31 = Fn((V _self1, int _argc312, V t_318, V dur_319, V _a316, V _a317, V[] _rest313) => {
V a_320 = default;
a_320 = Get(t_318, "t");
Invoke(t_318, "to", (dur_319 is var _t321 && Truthy(_t321) ? _t321 : ((V)(450D))), NewObj(2).Put("x", ((V)(0D))).Put("lean", ((V)(0D))).V, ((V)("io")));
return Call(para_38, V.Undef, t_318, a_320, Fn((V _self1, int _argc322, V u_328, V _a325, V _a326, V _a327, V[] _rest323) => {
return Call(steps_18, V.Undef, u_328, (dur_319 is var _t329 && Truthy(_t329) ? _t329 : ((V)(450D))), ((V)(2D)), ((V)(2.2)));
}, 1, "", true));
return default;
}, 2, "", true);
giggle_32 = Fn((V _self1, int _argc330, V t_336, V n_337, V a_338, V _a335, V[] _rest331) => {
a_338 = (a_338 is var _t339 && Truthy(_t339) ? _t339 : ((V)(1D)));
Invoke(t_336, "to", ((V)(160D)), NewObj(5).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.35))).Put("sqz", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("o")));
{
double i_340 = 0;
i_340 = 0D;
while (true) {
if (!(Lt(((V)(i_340)), (n_337 is var _t342 && Truthy(_t342) ? _t342 : ((V)(3D)))))) break;
Invoke(Invoke(t_336, "to", ((V)(130D)), NewObj(4).Put("sq", ((V)((0.05 * ToNum(a_338))))).Put("armL", ((V)((8D * ToNum(a_338))))).Put("armR", ((V)((8D * ToNum(a_338))))).Put("htilt", ((V)(((NumTruthy((i_340 % 2D)) ? 2D : (-2D)) * ToNum(a_338))))).V, ((V)("o"))), "to", ((V)(150D)), NewObj(3).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
i_340++;
}
}
return Invoke(t_336, "to", ((V)(200D)), NewObj(2).Put("open", ((V)(0.1))).Put("htilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 3, "", true);
hmph_33 = Fn((V _self1, int _argc343, V t_349, V away_350, V _a347, V _a348, V[] _rest344) => {
return Invoke(Invoke(Invoke(Invoke(t_349, "to", ((V)(250D)), NewObj(3).Put("frown", ((V)(0.55))).Put("puff", ((V)(0.35))).Put("close", ((V)(0.35))).V, ((V)("io"))), "to", ((V)(380D)), NewObj(4).Put("hyaw", ((V)((ToNum(away_350) * 0.38)))).Put("lx", ((V)((ToNum(away_350) * 0.6)))).Put("pitch", ((V)(0.12))).Put("htilt", ((V)(((-ToNum(away_350)) * 3D)))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(350D)), NewObj(7).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("pitch", ((V)(0D))).Put("htilt", ((V)(0D))).Put("frown", ((V)(0D))).Put("puff", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
sneeze_34 = Fn((V _self1, int _argc351, V t_357, V a_358, V _a355, V _a356, V[] _rest352) => {
a_358 = (a_358 is var _t359 && Truthy(_t359) ? _t359 : ((V)(1D)));
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_357, "to", ((V)(260D)), NewObj(6).Put("pitch", ((V)((0.3 * ToNum(a_358))))).Put("open", ((V)(0.4))).Put("close", ((V)(0.6))).Put("sq", ((V)(((-0.06) * ToNum(a_358))))).Put("cross", ((V)(0D))).Put("ly", ((V)(0D))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(3).Put("pitch", ((V)((0.22 * ToNum(a_358))))).Put("open", ((V)(0.3))).Put("sq", ((V)((-0.03)))).V, ((V)("io"))), "to", ((V)(240D)), NewObj(4).Put("pitch", ((V)((0.4 * ToNum(a_358))))).Put("open", ((V)(0.55))).Put("close", ((V)(0.85))).Put("sq", ((V)(((-0.1) * ToNum(a_358))))).V, ((V)("io"))), "to", ((V)(80D)), NewObj(5).Put("pitch", ((V)(((-0.3) * ToNum(a_358))))).Put("open", ((V)((0.9 * ToNum(a_358))))).Put("sqz", ((V)(1D))).Put("close", ((V)(0D))).Put("sq", ((V)((0.2 * ToNum(a_358))))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("sneeze")), ((V)("nose")), ((V)(Round((9D * ToNum(a_358)))))), "to", ((V)(260D)), NewObj(3).Put("pitch", ((V)((-0.02)))).Put("open", ((V)(0.1))).Put("sq", ((V)(0D))).V, ((V)("io"))), "to", ((V)(220D)), NewObj(2).Put("sqz", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
sniff_35 = Fn((V _self1, int _argc360, V t_366, V n_367, V _a364, V _a365, V[] _rest361) => {
return Invoke(t_366, "osc", ((V)((ToNum((n_367 is var _t368 && Truthy(_t368) ? _t368 : ((V)(3D)))) * 240D))), (n_367 is var _t369 && Truthy(_t369) ? _t369 : ((V)(3D))), NewObj(3).Put("sq", ((V)(0.03))).Put("pitch", ((V)(0.05))).Put("mw", ((V)(0.85))).V, NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o")));
}, 2, "", true);
lick_36 = Fn((V _self1, int _argc370, V t_376, V n_377, V _a374, V _a375, V[] _rest371) => {
{
double i_378 = 0;
i_378 = 0D;
while (true) {
if (!(Lt(((V)(i_378)), (n_377 is var _t380 && Truthy(_t380) ? _t380 : ((V)(2D)))))) break;
Invoke(Invoke(t_376, "to", ((V)(150D)), NewObj(3).Put("tongue", ((V)(1D))).Put("open", ((V)(0.3))).Put("pitch", ((V)(0.06))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0.15))).Put("open", ((V)(0.05))).Put("pitch", ((V)(0D))).V, ((V)("io")));
i_378++;
}
}
return Invoke(t_376, "to", ((V)(150D)), NewObj(2).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "", true);
wag_37 = Fn((V _self1, int _argc381, V t_387, V dur_388, V a_389, V n_390, V[] _rest382) => {
V e_391 = default;
e_391 = Add(Get(t_387, "t"), ((V)((ToNum(dur_388) * 0D))));
return Call(swing_17, V.Undef, t_387, dur_388, (n_390 is var _t392 && Truthy(_t392) ? _t392 : ((V)(Max(3D, Round((ToNum(dur_388) / 160D)))))), NewObj(1).Put("wag", (a_389 is var _t393 && Truthy(_t393) ? _t393 : ((V)(28D)))).V);
return default;
}, 4, "", true);
para_38 = Fn((V _self1, int _argc394, V t_400, V from_401, V fn_402, V _a399, V[] _rest395) => {
V e_403 = default;
e_403 = Get(t_400, "t");
Invoke(t_400, "at", from_401);
Call(fn_402, V.Undef, t_400);
return Invoke(t_400, "at", ((V)(Max(ToNum(e_403), ToNum(Get(t_400, "t"))))));
return default;
}, 3, "", true);
leanIn_39 = Fn((V _self1, int _argc404, V t_410, V s_411, V x_412, V _a409, V[] _rest405) => {
return Invoke(Invoke(Invoke(Invoke(t_410, "to", ((V)(320D)), Call(o_13, V.Undef, NewObj(7).Put("htilt", ((V)((ToNum(s_411) * 10D)))).Put("hyaw", ((V)((ToNum(s_411) * 0.12)))).Put("close", ((V)(0.85))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("blush", ((V)(0.6))).Put("pitch", ((V)((-0.05)))).V, (x_412 is var _t413 && Truthy(_t413) ? _t413 : NewObj(0).V)), ((V)("io"))), "osc", ((V)(1000D)), ((V)(2D)), NewObj(2).Put("htilt", ((V)((ToNum(s_411) * 12D)))).Put("x", ((V)((ToNum(s_411) * 0.6)))).V, NewObj(2).Put("htilt", ((V)((ToNum(s_411) * 7D)))).Put("x", ((V)((ToNum(s_411) * 0.2)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D))), "to", ((V)(300D)), NewObj(4).Put("htilt", ((V)(0D))).Put("hyaw", ((V)(0D))).Put("x", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
}, 3, "", true);
swat_40 = Fn((V _self1, int _argc414, V t_420, V s_421, V n_422, V _a419, V[] _rest415) => {
V k_423 = default;
k_423 = Call(S_10, V.Undef, s_421);
{
double i_424 = 0;
i_424 = 0D;
while (true) {
if (!(Lt(((V)(i_424)), (n_422 is var _t426 && Truthy(_t426) ? _t426 : ((V)(2D)))))) break;
Invoke(Invoke(t_420, "to", ((V)(90D)), NewObj(5).PutK(Get(k_423, "arm"), ((V)(78D))).PutK(Get(k_423, "hx"), ((V)((LtN(s_421, 0D) ? (-4D) : 4D)))).PutK(Get(k_423, "hy"), ((V)((-6D)))).Put("sq", ((V)((-0.03)))).Put("frown", ((V)(0.4))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(4).PutK(Get(k_423, "arm"), ((V)(10D))).PutK(Get(k_423, "hx"), ((V)(0D))).PutK(Get(k_423, "hy"), ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_424++;
}
}
return t_420;
return default;
}, 3, "", true);
pawShake_41 = Fn((V _self1, int _argc427, V t_433, V s_434, V a_435, V _a432, V[] _rest428) => {
V k_436 = default;
k_436 = Call(S_10, V.Undef, s_434);
a_435 = (a_435 is var _t437 && Truthy(_t437) ? _t437 : ((V)(1D)));
Invoke(t_433, "to", ((V)(160D)), NewObj(2).PutK(Get(k_436, "foot"), ((V)((4D * ToNum(a_435))))).Put("bend", ((V)((ToNum(s_434) * 1.5)))).V, ((V)("io")));
Invoke(Arr(((V)(1D)), ((V)(0.75)), ((V)(0.5)), ((V)(0.25))), "forEach", Fn((V _self1, int _argc438, V m_444, V i_445, V _a442, V _a443, V[] _rest439) => {
return Invoke(t_433, "to", ((V)(110D)), NewObj(2).PutK(Get(k_436, "foot"), ((V)((((NumTruthy((ToNum(i_445) % 2D)) ? 4D : 2D) * ToNum(a_435)) + (1D - ToNum(m_444)))))).Put("htilt", ((V)(((NumTruthy((ToNum(i_445) % 2D)) ? 2D : (-2D)) * ToNum(m_444))))).V, ((V)("io")));
}, 2, "", true));
return Invoke(t_433, "to", ((V)(220D)), NewObj(3).PutK(Get(k_436, "foot"), ((V)(0D))).Put("bend", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("i")));
return default;
}, 3, "", true);
headShake_42 = Fn((V _self1, int _argc446, V t_452, V a_453, V P_454, V _a451, V[] _rest447) => {
return Call(shake_16, V.Undef, t_452, NewObj(6).Put("P", (P_454 is var _t455 && Truthy(_t455) ? _t455 : ((V)(95D)))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(0.8)), ((V)(0.5)), ((V)(0.25)))).Put("head", ((V)((0.32 * ToNum((a_453 is var _t456 && Truthy(_t456) ? _t456 : ((V)(1D)))))))).Put("roll", ((V)(4D))).Put("ear", ((V)(12D))).Put("chest", ((V)(0.08))).V);
}, 3, "", true);
snort_43 = Fn((V _self1, int _argc457, V t_463, V n_464, V _a461, V _a462, V[] _rest458) => {
{
double i_465 = 0;
i_465 = 0D;
while (true) {
if (!(Lt(((V)(i_465)), (n_464 is var _t467 && Truthy(_t467) ? _t467 : ((V)(2D)))))) break;
Invoke(Invoke(t_463, "to", ((V)(80D)), NewObj(4).Put("sq", ((V)(0.06))).Put("pitch", ((V)(0.1))).Put("mw", ((V)(0.75))).Put("close", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(170D)), NewObj(4).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).Put("close", ((V)(0D))).V, ((V)("io")));
i_465++;
}
}
return t_463;
return default;
}, 2, "", true);
boof_44 = Fn((V _self1, int _argc468, V t_474, V _a471, V _a472, V _a473, V[] _rest469) => {
return Invoke(Invoke(Invoke(Invoke(t_474, "to", ((V)(110D)), NewObj(6).Put("open", ((V)(0.85))).Put("mw", ((V)(0.85))).Put("sq", ((V)((-0.07)))).Put("pitch", ((V)(0.12))).Put("earL", ((V)((-6D)))).Put("earR", ((V)((-6D)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(200D)), NewObj(6).Put("open", ((V)(0.15))).Put("mw", ((V)(1D))).Put("sq", ((V)(0.03))).Put("pitch", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("sq", ((V)(0D))).Put("open", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
wheek_45 = Fn((V _self1, int _argc475, V t_481, V _a478, V _a479, V _a480, V[] _rest476) => {
return Invoke(Invoke(Invoke(Invoke(t_481, "to", ((V)(130D)), NewObj(4).Put("pitch", ((V)(0.2))).Put("open", ((V)(0.65))).Put("mw", ((V)(0.75))).Put("sq", ((V)((-0.04)))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(220D)), NewObj(2).Put("pitch", ((V)(0.16))).Put("open", ((V)(0.45))).V, ((V)("io"))), "to", ((V)(180D)), NewObj(4).Put("pitch", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 1, "", true);
freeze_46 = Fn((V _self1, int _argc482, V t_488, V ms_489, V _a486, V _a487, V[] _rest483) => {
return Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(Invoke(t_488, "to", ((V)(70D)), NewObj(2).Put("wide", ((V)(1D))).Put("sq", ((V)(0.05))).V, ((V)("o"))), "wait", (ms_489 is var _t490 && Truthy(_t490) ? _t490 : ((V)(500D)))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)((-0.7)))).V, ((V)("o"))), "wait", ((V)(260D))), "to", ((V)(90D)), NewObj(1).Put("lx", ((V)(0.7))).V, ((V)("o"))), "wait", ((V)(260D))), "to", ((V)(120D)), NewObj(3).Put("lx", ((V)(0D))).Put("wide", ((V)(0.3))).Put("sq", ((V)(0D))).V, ((V)("io")));
}, 2, "", true);
curl_47 = Fn((V _self1, int _argc491, V t_497, V hold_498, V tremble_499, V _a496, V[] _rest492) => {
Invoke(t_497, "to", ((V)(220D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(4D)), ((V)(2D))), NewObj(5).Put("sq", ((V)(0.17))).Put("pitch", ((V)((-0.6)))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V), ((V)("o")));
if (Truthy(tremble_499)) {
Invoke(Invoke(t_497, "osc", hold_498, ((V)(Round((ToNum(hold_498) / 90D)))), NewObj(1).Put("x", ((V)(0.4))).V, NewObj(1).Put("x", ((V)((-0.4)))).V, ((V)("io"))), "to", ((V)(60D)), NewObj(1).Put("x", ((V)(0D))).V);
} else {
Invoke(t_497, "wait", hold_498);
}
return Invoke(t_497, "to", ((V)(500D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(7).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("blush", ((V)(0.9))).Put("smile", ((V)(0.6))).V), ((V)("io")));
return default;
}, 3, "", true);
blushy_48 = Fn((V _self1, int _argc500, V t_506, V away_507, V _a504, V _a505, V[] _rest501) => {
return Invoke(Invoke(Invoke(t_506, "to", ((V)(350D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(2D)), ((V)((-18D)))), NewObj(6).Put("blush", ((V)(1D))).Put("smile", ((V)(0.6))).Put("hyaw", ((V)((ToNum(away_507) * 0.25)))).Put("lx", ((V)((ToNum(away_507) * 0.5)))).Put("ly", ((V)(0.5))).Put("pitch", ((V)((-0.08)))).V), ((V)("io"))), "wait", ((V)(700D))), "to", ((V)(350D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(4).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).Put("ly", ((V)(0D))).Put("pitch", ((V)(0D))).V), ((V)("io")));
}, 2, "", true);
happy_49 = Fn((V _self1, int _argc508, V t_514, V n_515, V _a512, V _a513, V[] _rest509) => {
Invoke(t_514, "to", ((V)(180D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
{
double i_516 = 0;
i_516 = 0D;
while (true) {
if (!(Lt(((V)(i_516)), (n_515 is var _t518 && Truthy(_t518) ? _t518 : ((V)(2D)))))) break;
Invoke(Invoke(Invoke(t_514, "to", ((V)(150D)), NewObj(1).Put("sq", ((V)(0.08))).V, ((V)("io"))), "to", ((V)(170D)), NewObj(2).Put("sq", ((V)((-0.04)))).Put("lift", ((V)(1.5))).V, ((V)("o"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0D))).Put("lift", ((V)(0D))).V, ((V)("i")));
i_516++;
}
}
return t_514;
return default;
}, 2, "", true);
pat_50 = Fn((V _self1, int _argc519, V t_525, V n_526, V _a523, V _a524, V[] _rest520) => {
Invoke(t_525, "to", ((V)(260D)), Call(both_12, V.Undef, ((V)(9D)), ((V)(0D))), ((V)("io")));
{
double i_527 = 0;
i_527 = 0D;
while (true) {
if (!(Lt(((V)(i_527)), (n_526 is var _t529 && Truthy(_t529) ? _t529 : ((V)(3D)))))) break;
Invoke(Invoke(t_525, "to", ((V)(140D)), NewObj(3).Put("hLy", ((V)(2D))).Put("hRy", ((V)((-1D)))).Put("sq", ((V)(0.03))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(3).Put("hLy", ((V)((-1D)))).Put("hRy", ((V)(2D))).Put("sq", ((V)(0D))).V, ((V)("io")));
i_527++;
}
}
return Invoke(t_525, "to", ((V)(260D)), NOHANDS_14, ((V)("io")));
return default;
}, 2, "", true);
smooth_51 = Fn((V _self1, int _argc530, V t_536, V s_537, V where_538, V _a535, V[] _rest531) => {
V h_539 = default;
V k_540 = default;
h_539 = InvokeK(SPOT_29, where_538, s_537);
k_540 = Call(S_10, V.Undef, s_537);
return Invoke(Invoke(Invoke(t_536, "to", ((V)(320D)), Call(o_13, V.Undef, h_539, NewObj(2).PutK(Get(k_540, "arm"), ((V)(20D))).Put("close", ((V)(0.5))).V), ((V)("io"))), "to", ((V)(420D)), NewObj(2).PutK(Get(k_540, "hy"), Add(GetK(h_539, Get(k_540, "hy")), ((V)(9D)))).PutK(Get(k_540, "hx"), Add(GetK(h_539, Get(k_540, "hx")), ((V)((LtN(s_537, 0D) ? (-2D) : 2D))))).V, ((V)("io"))), "to", ((V)(300D)), NewObj(4).PutK(Get(k_540, "hx"), ((V)(0D))).PutK(Get(k_540, "hy"), ((V)(0D))).PutK(Get(k_540, "arm"), ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return default;
}, 3, "", true);
RE_52 = NewObj(10).Put("mittens", NewObj(9).Put("head", Fn((V _self1, int _argc541, V t_547, V s_548, V _a545, V _a546, V[] _rest542) => {
Call(see_27, V.Undef, t_547, ((V)("head")), s_548, ((V)(150D)));
Call(rub_30, V.Undef, t_547, ((V)(1D)), ((V)("head")), ((V)(3D)), NewObj(2).Put("frown", ((V)(0.4))).Put("puff", ((V)(0.3))).V);
Invoke(t_547, "to", ((V)(200D)), NewObj(3).Put("frown", ((V)(0D))).Put("puff", ((V)(0D))).Put("smile", ((V)(0.5))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc549, V t_555, V s_556, V _a553, V _a554, V[] _rest550) => {
Call(headShake_42, V.Undef, t_555);
Call(giggle_32, V.Undef, t_555, ((V)(2D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc557, V t_563, V s_564, V _a561, V _a562, V[] _rest558) => {
Invoke(t_563, "wait", ((V)(350D)));
Call(sneeze_34, V.Undef, t_563);
Call(rub_30, V.Undef, t_563, ((V)(1D)), ((V)("nose")), ((V)(2D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc565, V t_571, V s_572, V _a569, V _a570, V[] _rest566) => {
Call(rub_30, V.Undef, t_571, s_572, ((V)("eye")), ((V)(3D)));
Invoke(Invoke(t_571, "e", ((V)("blink2"))), "to", ((V)(250D)), NewObj(1).Put("frown", ((V)(0.35))).V, ((V)("io")));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc573, V t_579, V s_580, V _a577, V _a578, V[] _rest574) => {
Call(leanIn_39, V.Undef, t_579, s_580);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc581, V t_587, V s_588, V _a585, V _a586, V[] _rest582) => {
Call(giggle_32, V.Undef, t_587, ((V)(2D)), ((V)(1.3)));
Call(swat_40, V.Undef, t_587, ((V)((-1D))), ((V)(1D)));
Call(swat_40, V.Undef, t_587, ((V)(1D)), ((V)(1D)));
Call(giggle_32, V.Undef, t_587, ((V)(2D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc589, V t_595, V s_596, V _a593, V _a594, V[] _rest590) => {
Call(see_27, V.Undef, t_595, ((V)("side")), s_596, ((V)(200D)));
Call(rub_30, V.Undef, t_595, s_596, ((V)("side")), ((V)(2D)), NewObj(1).Put("frown", ((V)(0.35))).V);
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc597, V t_603, V s_604, V _a601, V _a602, V[] _rest598) => {
Call(see_27, V.Undef, t_603, ((V)("foot")), s_604);
Call(pawShake_41, V.Undef, t_603, s_604);
Call(unsee_28, V.Undef, t_603);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc605, V t_611, V s_612, V B_613, V _a610, V[] _rest606) => {
Call(see_27, V.Undef, t_611, ((V)("tail")), s_612, ((V)(100D)));
Invoke(t_611, "to", ((V)(200D)), NewObj(2).Put("frown", ((V)(0.5))).Put("puff", ((V)(0.2))).V, ((V)("io")));
Call(wag_37, V.Undef, t_611, ((V)(900D)), ((V)(20D)), ((V)(3D)));
return default;
}, 3, "tail", true)).V).Put("biscuit", NewObj(9).Put("head", Fn((V _self1, int _argc614, V t_620, V s_621, V _a618, V _a619, V[] _rest615) => {
Invoke(t_620, "to", ((V)(320D)), NewObj(6).Put("pitch", ((V)(0.15))).Put("close", ((V)(0.85))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.3))).V, ((V)("io")));
Call(wag_37, V.Undef, t_620, ((V)(1100D)), ((V)(32D)), ((V)(7D)));
Invoke(t_620, "to", ((V)(200D)), NewObj(2).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc622, V t_628, V s_629, V _a626, V _a627, V[] _rest623) => {
Invoke(Invoke(t_628, "to", ((V)(380D)), NewObj(2).Put("htilt", ((V)((ToNum(s_629) * 12D)))).Put("lx", ((V)((ToNum(s_629) * 0.3)))).V, ((V)("io"))), "wait", ((V)(250D)));
Call(headShake_42, V.Undef, t_628, ((V)(1D)), ((V)(100D)));
Invoke(t_628, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(wag_37, V.Undef, t_628, ((V)(700D)), ((V)(28D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc630, V t_636, V s_637, V _a634, V _a635, V[] _rest631) => {
Invoke(t_636, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_35, V.Undef, t_636, ((V)(4D)));
Call(lick_36, V.Undef, t_636, ((V)(2D)));
Invoke(t_636, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(wag_37, V.Undef, t_636, ((V)(700D)), ((V)(30D)));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc638, V t_644, V s_645, V _a642, V _a643, V[] _rest639) => {
Invoke(t_644, "e", ((V)("blink2")));
Call(rub_30, V.Undef, t_644, s_645, ((V)("eye")), ((V)(2D)));
Invoke(t_644, "to", ((V)(160D)), NewObj(3).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.6))).V, ((V)("io")));
Call(wag_37, V.Undef, t_644, ((V)(700D)), ((V)(30D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc646, V t_652, V s_653, V _a650, V _a651, V[] _rest647) => {
Call(leanIn_39, V.Undef, t_652, s_653, NewObj(2).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.25))).V);
Call(wag_37, V.Undef, t_652, ((V)(600D)), ((V)(30D)));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc654, V t_660, V s_661, V _a658, V _a659, V[] _rest655) => {
V k_662 = default;
V a_663 = default;
k_662 = Call(S_10, V.Undef, ((V)(1D)));
Invoke(t_660, "to", ((V)(300D)), NewObj(8).Put("pitch", ((V)(0.2))).Put("sq", ((V)((-0.03)))).Put("close", ((V)(0.9))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.35))).Put("ly", ((V)(0D))).V, ((V)("io")));
a_663 = Get(t_660, "t");
Invoke(Invoke(t_660, "osc", ((V)(1200D)), ((V)(5D)), NewObj(1).PutK(Get(k_662, "foot"), ((V)(3.5))).V, NewObj(1).PutK(Get(k_662, "foot"), ((V)(0.5))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(1).PutK(Get(k_662, "foot"), ((V)(0D))).V, ((V)("i")));
Call(para_38, V.Undef, t_660, a_663, Fn((V _self1, int _argc664, V u_670, V _a667, V _a668, V _a669, V[] _rest665) => {
return Call(wag_37, V.Undef, u_670, ((V)(1320D)), ((V)(34D)), ((V)(9D)));
}, 1, "", true));
Invoke(t_660, "to", ((V)(250D)), NewObj(3).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc671, V t_677, V s_678, V _a675, V _a676, V[] _rest672) => {
Invoke(t_677, "to", ((V)(300D)), NewObj(7).Put("pitch", ((V)((-0.3)))).Put("sq", ((V)(0.1))).Put("armL", ((V)((-12D)))).Put("armR", ((V)((-12D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("open", ((V)(0.3))).V, ((V)("io")));
Call(wag_37, V.Undef, t_677, ((V)(800D)), ((V)(34D)), ((V)(5D)));
Call(boof_44, V.Undef, t_677);
Invoke(t_677, "to", ((V)(250D)), NewObj(4).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc679, V t_685, V s_686, V _a683, V _a684, V[] _rest680) => {
V k_687 = default;
k_687 = Call(S_10, V.Undef, s_686);
Invoke(Invoke(t_685, "to", ((V)(260D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, s_686, ((V)((-6D))), ((V)((-8D)))), NewObj(4).PutK(Get(k_687, "arm"), ((V)(55D))).PutK(Get(k_687, "foot"), ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(450D)));
Call(wag_37, V.Undef, t_685, ((V)(600D)), ((V)(30D)));
Invoke(t_685, "to", ((V)(260D)), NewObj(3).PutK(Get(k_687, "arm"), ((V)(0D))).PutK(Get(k_687, "hx"), ((V)(0D))).PutK(Get(k_687, "hy"), ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc688, V t_694, V s_695, V _a692, V _a693, V[] _rest689) => {
Call(see_27, V.Undef, t_694, ((V)("tail")), s_695, ((V)(0D)));
Invoke(Invoke(Invoke(t_694, "to", ((V)(500D)), NewObj(6).Put("spin", ((V)(200D))).Put("twist", ((V)(0D))).Put("hyaw", ((V)(0.3))).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).V, ((V)("io"))), "to", ((V)(450D)), NewObj(3).Put("spin", ((V)(360D))).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Call(wag_37, V.Undef, t_694, ((V)(600D)), ((V)(30D)));
return default;
}, 2, "tail", true)).V).Put("truffle", NewObj(9).Put("head", Fn((V _self1, int _argc696, V t_702, V s_703, V _a700, V _a701, V[] _rest697) => {
Call(jelly_19, V.Undef, t_702, ((V)(0.1)), ((V)(4D)), ((V)(220D)));
Call(snort_43, V.Undef, t_702, ((V)(2D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc704, V t_710, V s_711, V _a708, V _a709, V[] _rest705) => {
Call(headShake_42, V.Undef, t_710, ((V)(0.9)), ((V)(105D)));
Call(snort_43, V.Undef, t_710, ((V)(1D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc712, V t_718, V s_719, V _a716, V _a717, V[] _rest713) => {
Invoke(t_718, "to", ((V)(120D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.3))).V, ((V)("io")));
Call(snort_43, V.Undef, t_718, ((V)(2D)));
Call(sniff_35, V.Undef, t_718, ((V)(3D)));
Invoke(t_718, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc720, V t_726, V s_727, V _a724, V _a725, V[] _rest721) => {
Invoke(t_726, "e", ((V)("blink2")));
Call(rub_30, V.Undef, t_726, s_727, ((V)("eye")), ((V)(2D)));
Call(snort_43, V.Undef, t_726, ((V)(1D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc728, V t_734, V s_735, V _a732, V _a733, V[] _rest729) => {
Invoke(t_734, "to", ((V)(180D)), NewObj(3).Put("puff", ((V)(0.6))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("o")));
Call(jelly_19, V.Undef, t_734, ((V)(0.3)), ((V)(3D)), ((V)(220D)), ((V)("puff")));
Call(giggle_32, V.Undef, t_734, ((V)(3D)));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc736, V t_742, V s_743, V _a740, V _a741, V[] _rest737) => {
Invoke(t_742, "to", ((V)(160D)), NewObj(1).Put("sq", ((V)(0.12))).V, ((V)("io")));
Call(jelly_19, V.Undef, t_742, ((V)(0.14)), ((V)(5D)), ((V)(240D)));
Call(giggle_32, V.Undef, t_742, ((V)(2D)));
Call(pat_50, V.Undef, t_742, ((V)(2D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc744, V t_750, V s_751, V _a748, V _a749, V[] _rest745) => {
Call(jelly_19, V.Undef, t_750, ((V)(4D)), ((V)(4D)), ((V)(260D)), ((V)("bend")));
Call(snort_43, V.Undef, t_750, ((V)(1D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc752, V t_758, V s_759, V _a756, V _a757, V[] _rest753) => {
V k_760 = default;
k_760 = Call(S_10, V.Undef, s_759);
Invoke(Invoke(Invoke(Invoke(t_758, "to", ((V)(200D)), NewObj(2).PutK(Get(k_760, "foot"), ((V)(5D))).Put("frown", ((V)(0.3))).V, ((V)("io"))), "to", ((V)(110D)), NewObj(2).PutK(Get(k_760, "foot"), ((V)(0D))).Put("sq", ((V)(0.1))).V, ((V)("i"))), "e", ((V)("emit")), ((V)("dust")), Get(k_760, "foot"), ((V)(3D))), "to", ((V)(200D)), NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Call(snort_43, V.Undef, t_758, ((V)(2D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc761, V t_767, V s_768, V _a765, V _a766, V[] _rest762) => {
Call(see_27, V.Undef, t_767, ((V)("tail")), s_768, ((V)(100D)));
Invoke(t_767, "osc", ((V)(600D)), ((V)(3D)), NewObj(1).Put("curl", ((V)(0.9))).V, NewObj(1).Put("curl", ((V)(0.2))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_767, "to", ((V)(160D)), NewObj(2).Put("open", ((V)(0.5))).Put("mw", ((V)(0.8))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("note")), ((V)("head"))), "to", ((V)(220D)), NewObj(3).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).Put("curl", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "tail", true)).V).Put("nibbles", NewObj(9).Put("head", Fn((V _self1, int _argc769, V t_775, V s_776, V _a773, V _a774, V[] _rest770) => {
Call(freeze_46, V.Undef, t_775, ((V)(450D)));
Call(sniff_35, V.Undef, t_775, ((V)(3D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc777, V t_783, V s_784, V _a781, V _a782, V[] _rest778) => {
V k_785 = default;
k_785 = Call(S_10, V.Undef, s_784);
Invoke(Invoke(t_783, "osc", ((V)(700D)), ((V)(4D)), NewObj(1).PutK(Get(k_785, "ear"), ((V)((-14D)))).V, NewObj(1).PutK(Get(k_785, "ear"), ((V)(3D))).V, ((V)("io"))), "to", ((V)(140D)), NewObj(1).PutK(Get(k_785, "ear"), ((V)(0D))).V, ((V)("io")));
Call(headShake_42, V.Undef, t_783, ((V)(0.7)), ((V)(75D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc786, V t_792, V s_793, V _a790, V _a791, V[] _rest787) => {
Invoke(t_792, "to", ((V)(100D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Invoke(t_792, "osc", ((V)(900D)), ((V)(7D)), NewObj(3).Put("sq", ((V)(0.025))).Put("pitch", ((V)(0.05))).Put("mw", ((V)(0.8))).V, NewObj(3).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o")));
Invoke(Invoke(Invoke(t_792, "to", ((V)(200D)), NewObj(1).Put("puff", ((V)(0.7))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(250D)), NewObj(1).Put("puff", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc794, V t_800, V s_801, V _a798, V _a799, V[] _rest795) => {
Invoke(t_800, "to", ((V)(260D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(4D)), ((V)((-18D)))), NewObj(1).Put("close", ((V)(1D))).V), ((V)("io")));
Invoke(t_800, "osc", ((V)(1000D)), ((V)(4D)), NewObj(3).Put("hLy", ((V)((-20D)))).Put("hRy", ((V)((-16D)))).Put("pitch", ((V)((-0.05)))).V, NewObj(3).Put("hLy", ((V)((-16D)))).Put("hRy", ((V)((-20D)))).Put("pitch", ((V)(0.03))).V, ((V)("io")));
Invoke(t_800, "to", ((V)(260D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(4).Put("close", ((V)(0D))).Put("pitch", ((V)(0D))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V), ((V)("io")));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc802, V t_808, V s_809, V _a806, V _a807, V[] _rest803) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_808, "to", ((V)(200D)), NewObj(2).Put("puff", ((V)(1D))).Put("wide", ((V)(0.5))).V, ((V)("o"))), "wait", ((V)(200D))), "to", ((V)(70D)), NewObj(2).Put("puff", ((V)(0D))).Put("open", ((V)(0.4))).V, ((V)("o"))), "e", ((V)("emit")), ((V)("seed")), ((V)("mouth")), ((V)(2D))), "to", ((V)(160D)), NewObj(2).Put("open", ((V)(0D))).Put("wide", ((V)(0D))).V, ((V)("io")));
Call(giggle_32, V.Undef, t_808, ((V)(3D)), ((V)(0.8)));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc810, V t_816, V s_817, V _a814, V _a815, V[] _rest811) => {
Invoke(t_816, "to", ((V)(180D)), Call(both_12, V.Undef, ((V)(6D)), ((V)((-8D)))), ((V)("io")));
Call(giggle_32, V.Undef, t_816, ((V)(4D)), ((V)(0.8)));
Invoke(t_816, "to", ((V)(200D)), NOHANDS_14, ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc818, V t_824, V s_825, V _a822, V _a823, V[] _rest819) => {
Invoke(t_824, "to", ((V)(200D)), NewObj(2).Put("x", ((V)(((-ToNum(s_825)) * 5D)))).Put("lean", ((V)(((-ToNum(s_825)) * 1.5)))).V, ((V)("o")));
Call(steps_18, V.Undef, t_824, ((V)(200D)), ((V)(2D)), ((V)(2.5)));
Call(freeze_46, V.Undef, t_824, ((V)(300D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc826, V t_832, V s_833, V _a830, V _a831, V[] _rest827) => {
Call(jump_15, V.Undef, t_832, NewObj(5).Put("h", ((V)(5D))).Put("ant", ((V)(80D))).Put("up", ((V)(140D))).Put("c", ((V)(0.1))).Put("arm", ((V)(20D))).V);
Call(steps_18, V.Undef, t_832, ((V)(700D)), ((V)(6D)), ((V)(3D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc834, V t_840, V s_841, V _a838, V _a839, V[] _rest835) => {
Invoke(Invoke(Invoke(Invoke(t_840, "to", ((V)(420D)), NewObj(3).Put("spin", ((V)(150D))).Put("hyaw", ((V)(0.3))).Put("lx", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(300D))), "to", ((V)(420D)), NewObj(3).Put("spin", ((V)(360D))).Put("hyaw", ((V)(0D))).Put("lx", ((V)(0D))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Call(sniff_35, V.Undef, t_840, ((V)(2D)));
return default;
}, 2, "tail", true)).V).Put("quill", NewObj(9).Put("head", Fn((V _self1, int _argc842, V t_848, V s_849, V _a846, V _a847, V[] _rest843) => {
Invoke(Invoke(Invoke(Invoke(t_848, "to", ((V)(180D)), NewObj(3).Put("sq", ((V)(0.14))).Put("pitch", ((V)((-0.35)))).Put("close", ((V)(1D))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0.4))).Put("ly", ((V)((-0.5)))).V, ((V)("io"))), "wait", ((V)(250D)));
Invoke(t_848, "to", ((V)(400D)), NewObj(6).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("ly", ((V)(0D))).Put("blush", ((V)(0.9))).Put("smile", ((V)(0.5))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc850, V t_856, V s_857, V _a854, V _a855, V[] _rest851) => {
Invoke(t_856, "to", ((V)(250D)), NewObj(4).Put("armL", ((V)(25D))).Put("armR", ((V)(25D))).Put("htilt", ((V)((ToNum(s_857) * 5D)))).Put("sq", ((V)(0.04))).V, ((V)("io")));
Call(blushy_48, V.Undef, t_856, ((V)((-ToNum(s_857)))));
Invoke(t_856, "to", ((V)(200D)), NewObj(4).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("htilt", ((V)(0D))).Put("sq", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc858, V t_864, V s_865, V _a862, V _a863, V[] _rest859) => {
Invoke(t_864, "to", ((V)(150D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.3))).V, ((V)("io")));
Invoke(t_864, "osc", ((V)(500D)), ((V)(3D)), NewObj(2).Put("mw", ((V)(0.8))).Put("sq", ((V)(0.02))).V, NewObj(2).Put("mw", ((V)(1D))).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_864, "to", ((V)(300D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-18D)))), Call(hand_11, V.Undef, ((V)((-1D))), ((V)(13D)), ((V)((-18D)))), NewObj(1).Put("blush", ((V)(1D))).V), ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(300D)), NOHANDS_14, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc866, V t_872, V s_873, V _a870, V _a871, V[] _rest867) => {
Invoke(Invoke(Invoke(Invoke(Invoke(t_872, "to", ((V)(280D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(6D)), ((V)((-27D)))), NewObj(1).PutK(Get(Call(S_10, V.Undef, s_873), "wink"), ((V)(0D))).V), ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(260D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)((-ToNum(s_873)))), ((V)((-1D))), ((V)((-19D)))), NewObj(1).Put("lx", ((V)(((-ToNum(s_873)) * 0.4)))).V), ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(300D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(2).Put("lx", ((V)(0D))).Put("blush", ((V)(0.8))).V), ((V)("io")));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc874, V t_880, V s_881, V _a878, V _a879, V[] _rest875) => {
Call(blushy_48, V.Undef, t_880, ((V)((-ToNum(s_881)))));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc882, V t_888, V s_889, V _a886, V _a887, V[] _rest883) => {
Call(curl_47, V.Undef, t_888, ((V)(700D)), (true ? V.True : V.False));
Call(giggle_32, V.Undef, t_888, ((V)(2D)), ((V)(0.7)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc890, V t_896, V s_897, V _a894, V _a895, V[] _rest891) => {
V a_898 = default;
Invoke(t_896, "to", ((V)(220D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(4D)), ((V)(2D))), NewObj(5).Put("sq", ((V)(0.17))).Put("pitch", ((V)((-0.6)))).Put("close", ((V)(1D))).Put("armL", ((V)((-10D)))).Put("armR", ((V)((-10D)))).V), ((V)("o")));
a_898 = Get(t_896, "t");
Invoke(Invoke(t_896, "to", ((V)(700D)), NewObj(2).Put("spin", ((V)(((-ToNum(s_897)) * 360D)))).Put("x", ((V)(((-ToNum(s_897)) * 3D)))).V, ((V)("io"))), "to", ((V)(1D)), NewObj(1).Put("spin", ((V)(0D))).V, ((V)("l")));
Invoke(Invoke(t_896, "at", Add(a_898, ((V)(701D)))), "wait", ((V)(150D)));
Invoke(t_896, "to", ((V)(500D)), Call(o_13, V.Undef, NOHANDS_14, NewObj(6).Put("sq", ((V)(0D))).Put("pitch", ((V)(0D))).Put("close", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("blush", ((V)(0.9))).V), ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc899, V t_905, V s_906, V _a903, V _a904, V[] _rest900) => {
Call(see_27, V.Undef, t_905, ((V)("foot")), s_906);
Invoke(Invoke(t_905, "osc", ((V)(500D)), ((V)(2D)), NewObj(1).PutK(Get(Call(S_10, V.Undef, s_906), "foot"), ((V)(2D))).V, NewObj(1).PutK(Get(Call(S_10, V.Undef, s_906), "foot"), ((V)(0.5))).V, ((V)("io"))), "to", ((V)(150D)), NewObj(1).PutK(Get(Call(S_10, V.Undef, s_906), "foot"), ((V)(0D))).V);
Invoke(t_905, "to", ((V)(250D)), NewObj(1).Put("blush", ((V)(1D))).V, ((V)("io")));
Call(unsee_28, V.Undef, t_905);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc907, V t_913, V s_914, V _a911, V _a912, V[] _rest908) => {
Call(curl_47, V.Undef, t_913, ((V)(400D)), (false ? V.True : V.False));
Call(see_27, V.Undef, t_913, ((V)("tail")), s_914, ((V)(300D)));
Call(unsee_28, V.Undef, t_913);
return default;
}, 2, "tail", true)).V).Put("waffles", NewObj(9).Put("head", Fn((V _self1, int _argc915, V t_921, V s_922, V _a919, V _a920, V[] _rest916) => {
Invoke(t_921, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(boof_44, V.Undef, t_921);
Invoke(Invoke(Invoke(t_921, "to", ((V)(350D)), NewObj(3).Put("htilt", ((V)(12D))).Put("earL", ((V)(4D))).Put("earR", ((V)((-6D)))).V, ((V)("io"))), "wait", ((V)(350D))), "to", ((V)(300D)), NewObj(3).Put("htilt", ((V)(0D))).Put("earL", ((V)(0D))).Put("earR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc923, V t_929, V s_930, V _a927, V _a928, V[] _rest924) => {
Call(shake_16, V.Undef, t_929, NewObj(8).Put("P", ((V)(105D))).Put("env", Arr(((V)(0.6)), ((V)(1D)), ((V)(1D)), ((V)(0.7)), ((V)(0.4)), ((V)(0.15)))).Put("head", ((V)(0.36))).Put("roll", ((V)(5D))).Put("ear", ((V)(14D))).Put("chest", ((V)(0.22))).Put("body", ((V)(0.8))).Put("tail", ((V)(30D))).V);
Invoke(t_929, "to", ((V)(200D)), NewObj(4).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc931, V t_937, V s_938, V _a935, V _a936, V[] _rest932) => {
Invoke(t_937, "to", ((V)(120D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_35, V.Undef, t_937, ((V)(3D)));
Call(sneeze_34, V.Undef, t_937, ((V)(0.7)));
Invoke(t_937, "to", ((V)(200D)), NewObj(3).Put("tongue", ((V)(0.6))).Put("open", ((V)(0.3))).Put("hap", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc939, V t_945, V s_946, V _a943, V _a944, V[] _rest940) => {
Invoke(t_945, "e", ((V)("blink2")));
Invoke(Invoke(Invoke(t_945, "to", ((V)(200D)), NewObj(5).PutK(Get(Call(S_10, V.Undef, s_946), "wink"), ((V)(0D))).PutK(Get(Call(S_10, V.Undef, ((V)((-ToNum(s_946))))), "wink"), ((V)(1D))).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.3))).Put("htilt", ((V)(((-ToNum(s_946)) * 6D)))).V, ((V)("io"))), "wait", ((V)(400D))), "to", ((V)(250D)), NewObj(2).PutK(Get(Call(S_10, V.Undef, ((V)((-ToNum(s_946))))), "wink"), ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc947, V t_953, V s_954, V _a951, V _a952, V[] _rest948) => {
Call(leanIn_39, V.Undef, t_953, s_954, NewObj(2).Put("tongue", ((V)(0.7))).Put("open", ((V)(0.25))).V);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc955, V t_961, V s_962, V _a959, V _a960, V[] _rest956) => {
V a_963 = default;
Invoke(t_961, "to", ((V)(260D)), NewObj(8).Put("sq", ((V)(0.3))).Put("armL", ((V)(34D))).Put("armR", ((V)(34D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("tongue", ((V)(0.8))).Put("open", ((V)(0.35))).Put("pitch", ((V)(0.1))).V, ((V)("i")));
a_963 = Get(t_961, "t");
Invoke(Invoke(t_961, "osc", ((V)(900D)), ((V)(4D)), NewObj(2).Put("footL", ((V)(3D))).Put("footR", ((V)(0.5))).V, NewObj(2).Put("footL", ((V)(0.5))).Put("footR", ((V)(3D))).V, ((V)("io"))), "to", ((V)(120D)), NewObj(2).Put("footL", ((V)(0D))).Put("footR", ((V)(0D))).V);
Call(para_38, V.Undef, t_961, a_963, Fn((V _self1, int _argc964, V u_970, V _a967, V _a968, V _a969, V[] _rest965) => {
return Call(wag_37, V.Undef, u_970, ((V)(1020D)), ((V)(36D)), ((V)(9D)));
}, 1, "", true));
Invoke(t_961, "to", ((V)(300D)), NewObj(4).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc971, V t_977, V s_978, V _a975, V _a976, V[] _rest972) => {
Invoke(t_977, "to", ((V)(280D)), NewObj(6).Put("pitch", ((V)((-0.3)))).Put("sq", ((V)(0.1))).Put("armL", ((V)((-12D)))).Put("armR", ((V)((-12D)))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Call(swing_17, V.Undef, t_977, ((V)(800D)), ((V)(5D)), NewObj(2).Put("tilt", ((V)(4D))).Put("wag", ((V)(36D))).V);
Call(boof_44, V.Undef, t_977);
Invoke(t_977, "to", ((V)(250D)), NewObj(4).Put("pitch", ((V)(0D))).Put("sq", ((V)(0D))).Put("armL", ((V)(0D))).Put("armR", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc979, V t_985, V s_986, V _a983, V _a984, V[] _rest980) => {
V k_987 = default;
k_987 = Call(S_10, V.Undef, s_986);
Invoke(t_985, "to", ((V)(220D)), NewObj(2).PutK(Get(k_987, "foot"), ((V)(4D))).PutK(Get(k_987, "arm"), ((V)(30D))).V, ((V)("io")));
Invoke(t_985, "osc", ((V)(600D)), ((V)(3D)), NewObj(1).PutK(Get(k_987, "foot"), ((V)(5.5))).V, NewObj(1).PutK(Get(k_987, "foot"), ((V)(3.5))).V, ((V)("io")));
Invoke(t_985, "to", ((V)(220D)), NewObj(4).PutK(Get(k_987, "foot"), ((V)(0D))).PutK(Get(k_987, "arm"), ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("i")));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc988, V t_994, V s_995, V _a992, V _a993, V[] _rest989) => {
Call(see_27, V.Undef, t_994, ((V)("tail")), s_995, ((V)(0D)));
Call(swing_17, V.Undef, t_994, ((V)(1000D)), ((V)(9D)), NewObj(3).Put("tilt", ((V)(5D))).Put("x", ((V)(0.8))).Put("wag", ((V)(38D))).V);
Call(unsee_28, V.Undef, t_994);
return default;
}, 2, "tail", true)).V).Put("poppy", NewObj(9).Put("head", Fn((V _self1, int _argc996, V t_1002, V s_1003, V _a1000, V _a1001, V[] _rest997) => {
Call(freeze_46, V.Undef, t_1002, ((V)(400D)));
Call(wheek_45, V.Undef, t_1002);
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc1004, V t_1010, V s_1011, V _a1008, V _a1009, V[] _rest1005) => {
Call(popcorn_20, V.Undef, t_1010, ((V)(9D)), ((V)((-ToNum(s_1011)))), ((V)(480D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc1012, V t_1018, V s_1019, V _a1016, V _a1017, V[] _rest1013) => {
Invoke(t_1018, "to", ((V)(100D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Invoke(t_1018, "osc", ((V)(700D)), ((V)(5D)), NewObj(2).Put("sq", ((V)(0.025))).Put("mw", ((V)(0.8))).V, NewObj(2).Put("sq", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("o")));
Call(wheek_45, V.Undef, t_1018);
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc1020, V t_1026, V s_1027, V _a1024, V _a1025, V[] _rest1021) => {
V a_1028 = default;
Invoke(t_1026, "e", ((V)("blink2")));
a_1028 = Get(t_1026, "t");
Invoke(t_1026, "to", ((V)(300D)), NewObj(3).Put("x", ((V)(((-ToNum(s_1027)) * 4D)))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("o")));
Call(para_38, V.Undef, t_1026, a_1028, Fn((V _self1, int _argc1029, V u_1035, V _a1032, V _a1033, V _a1034, V[] _rest1030) => {
return Call(steps_18, V.Undef, u_1035, ((V)(300D)), ((V)(3D)), ((V)(1.8)));
}, 1, "", true));
Invoke(t_1026, "wait", ((V)(300D)));
Call(walkBack_31, V.Undef, t_1026, ((V)(500D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc1036, V t_1042, V s_1043, V _a1040, V _a1041, V[] _rest1037) => {
Invoke(t_1042, "to", ((V)(350D)), NewObj(4).Put("close", ((V)(0.85))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).Put("htilt", ((V)((ToNum(s_1043) * 6D)))).V, ((V)("io")));
Invoke(t_1042, "osc", ((V)(1200D)), ((V)(4D)), NewObj(1).Put("sq", ((V)(0.02))).V, NewObj(1).Put("sq", ((V)(0D))).V, ((V)("io")));
Invoke(t_1042, "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0D))).Put("htilt", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc1044, V t_1050, V s_1051, V _a1048, V _a1049, V[] _rest1045) => {
Call(popcorn_20, V.Undef, t_1050, ((V)(12D)), ((V)(1D)), ((V)(520D)));
Call(popcorn_20, V.Undef, t_1050, ((V)(9D)), ((V)((-1D))), ((V)(460D)));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc1052, V t_1058, V s_1059, V _a1056, V _a1057, V[] _rest1053) => {
V a_1060 = default;
a_1060 = Get(t_1058, "t");
Invoke(t_1058, "to", ((V)(380D)), NewObj(2).Put("x", ((V)(((-ToNum(s_1059)) * 6D)))).Put("lean", ((V)(((-ToNum(s_1059)) * 2D)))).V, ((V)("o")));
Call(para_38, V.Undef, t_1058, a_1060, Fn((V _self1, int _argc1061, V u_1067, V _a1064, V _a1065, V _a1066, V[] _rest1062) => {
return Call(steps_18, V.Undef, u_1067, ((V)(380D)), ((V)(5D)), ((V)(2D)));
}, 1, "", true));
Call(wheek_45, V.Undef, t_1058);
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc1068, V t_1074, V s_1075, V _a1072, V _a1073, V[] _rest1069) => {
Call(steps_18, V.Undef, t_1074, ((V)(500D)), ((V)(4D)), ((V)(2D)));
Call(popcorn_20, V.Undef, t_1074, ((V)(10D)), s_1075, ((V)(500D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc1076, V t_1082, V s_1083, V _a1080, V _a1081, V[] _rest1077) => {
Call(popcorn_20, V.Undef, t_1082, ((V)(11D)), ((V)(1D)), ((V)(520D)));
Call(see_27, V.Undef, t_1082, ((V)("tail")), s_1083, ((V)(200D)));
Call(unsee_28, V.Undef, t_1082);
Call(wheek_45, V.Undef, t_1082);
return default;
}, 2, "tail", true)).V).Put("duchess", NewObj(9).Put("head", Fn((V _self1, int _argc1084, V t_1090, V s_1091, V _a1088, V _a1089, V[] _rest1085) => {
Invoke(Invoke(Invoke(t_1090, "to", ((V)(180D)), NewObj(4).Put("wide", ((V)(1D))).Put("pitch", ((V)(0.12))).Put("open", ((V)(0.3))).Put("mw", ((V)(0.6))).V, ((V)("o"))), "wait", ((V)(400D))), "to", ((V)(200D)), NewObj(3).Put("wide", ((V)(0D))).Put("open", ((V)(0D))).Put("mw", ((V)(1D))).V, ((V)("io")));
Call(smooth_51, V.Undef, t_1090, ((V)(1D)), ((V)("head")));
Invoke(Invoke(t_1090, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0.15))).Put("close", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(300D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc1092, V t_1098, V s_1099, V _a1096, V _a1097, V[] _rest1093) => {
Call(hmph_33, V.Undef, t_1098, ((V)((-ToNum(s_1099)))));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc1100, V t_1106, V s_1107, V _a1104, V _a1105, V[] _rest1101) => {
Invoke(t_1106, "to", ((V)(120D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_35, V.Undef, t_1106, ((V)(2D)));
Invoke(t_1106, "to", ((V)(250D)), Call(o_13, V.Undef, Call(hand_11, V.Undef, ((V)(1D)), ((V)(13D)), ((V)((-18D))))), ((V)("io")));
Call(sneeze_34, V.Undef, t_1106, ((V)(0.45)));
Invoke(t_1106, "to", ((V)(250D)), NOHANDS_14, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc1108, V t_1114, V s_1115, V _a1112, V _a1113, V[] _rest1109) => {
Invoke(Invoke(Invoke(Invoke(t_1114, "to", ((V)(500D)), NewObj(1).Put("close", ((V)(1D))).V, ((V)("io"))), "to", ((V)(500D)), NewObj(4).Put("close", ((V)(0.4))).Put("frown", ((V)(0.45))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(500D))), "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0D))).Put("frown", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc1116, V t_1122, V s_1123, V _a1120, V _a1121, V[] _rest1117) => {
Call(leanIn_39, V.Undef, t_1122, s_1123, NewObj(1).Put("pitch", ((V)(0.08))).V);
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc1124, V t_1130, V s_1131, V _a1128, V _a1129, V[] _rest1125) => {
Invoke(t_1130, "to", ((V)(150D)), NewObj(3).Put("wide", ((V)(0.6))).Put("frown", ((V)(0.5))).Put("ly", ((V)(0.6))).V, ((V)("o")));
Call(swat_40, V.Undef, t_1130, ((V)(1D)), ((V)(2D)));
Call(hmph_33, V.Undef, t_1130, ((V)((-1D))));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc1132, V t_1138, V s_1139, V _a1136, V _a1137, V[] _rest1133) => {
Invoke(t_1138, "to", ((V)(200D)), NewObj(2).Put("frown", ((V)(0.4))).Put("pitch", ((V)(0.12))).V, ((V)("io")));
Call(smooth_51, V.Undef, t_1138, s_1139, ((V)("side")));
Invoke(t_1138, "to", ((V)(250D)), NewObj(2).Put("frown", ((V)(0D))).Put("pitch", ((V)(0D))).V, ((V)("io")));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc1140, V t_1146, V s_1147, V _a1144, V _a1145, V[] _rest1141) => {
Call(pawShake_41, V.Undef, t_1146, s_1147, ((V)(0.6)));
Invoke(Invoke(t_1146, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)(0.15))).Put("close", ((V)(0.4))).V, ((V)("io"))), "wait", ((V)(300D)));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc1148, V t_1154, V s_1155, V _a1152, V _a1153, V[] _rest1149) => {
Call(see_27, V.Undef, t_1154, ((V)("tail")), s_1155, ((V)(0D)));
Invoke(t_1154, "to", ((V)(300D)), NewObj(2).Put("close", ((V)(0.45))).Put("frown", ((V)(0.5))).V, ((V)("io")));
Call(swing_17, V.Undef, t_1154, ((V)(1100D)), ((V)(3D)), NewObj(2).Put("wag", ((V)(26D))).Put("curl", ((V)(0.3))).V);
Call(unsee_28, V.Undef, t_1154);
return default;
}, 2, "tail", true)).V).Put("mamapaws", NewObj(9).Put("head", Fn((V _self1, int _argc1156, V t_1162, V s_1163, V _a1160, V _a1161, V[] _rest1157) => {
Invoke(t_1162, "to", ((V)(300D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
Invoke(Invoke(Invoke(t_1162, "to", ((V)(400D)), NewObj(3).Put("pitch", ((V)((-0.28)))).Put("ly", ((V)(0.8))).Put("htilt", ((V)((-5D)))).V, ((V)("io"))), "osc", ((V)(800D)), ((V)(1D)), NewObj(1).Put("htilt", ((V)((-9D)))).V, NewObj(1).Put("htilt", ((V)((-5D)))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
Call(unsee_28, V.Undef, t_1162, ((V)(400D)));
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc1164, V t_1170, V s_1171, V _a1168, V _a1169, V[] _rest1165) => {
Call(headShake_42, V.Undef, t_1170, ((V)(0.7)), ((V)(110D)));
Call(giggle_32, V.Undef, t_1170, ((V)(2D)), ((V)(0.7)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc1172, V t_1178, V s_1179, V _a1176, V _a1177, V[] _rest1173) => {
Invoke(t_1178, "to", ((V)(120D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.2))).V, ((V)("io")));
Call(sniff_35, V.Undef, t_1178, ((V)(2D)));
Call(lick_36, V.Undef, t_1178, ((V)(1D)));
Invoke(t_1178, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc1180, V t_1186, V s_1187, V _a1184, V _a1185, V[] _rest1181) => {
Invoke(Invoke(t_1186, "e", ((V)("blink2"))), "wait", ((V)(200D)));
Invoke(Invoke(t_1186, "to", ((V)(400D)), NewObj(4).Put("pitch", ((V)((-0.25)))).Put("ly", ((V)(0.8))).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io"))), "wait", ((V)(500D)));
Call(unsee_28, V.Undef, t_1186, ((V)(400D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc1188, V t_1194, V s_1195, V _a1192, V _a1193, V[] _rest1189) => {
Call(leanIn_39, V.Undef, t_1194, s_1195);
Invoke(t_1194, "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc1196, V t_1202, V s_1203, V _a1200, V _a1201, V[] _rest1197) => {
Invoke(t_1202, "to", ((V)(250D)), Call(o_13, V.Undef, Call(both_12, V.Undef, ((V)(8D)), ((V)((-5D)))), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V), ((V)("io")));
Call(giggle_32, V.Undef, t_1202, ((V)(3D)), ((V)(0.8)));
Invoke(Invoke(t_1202, "to", ((V)(300D)), NewObj(2).Put("pitch", ((V)((-0.2)))).Put("ly", ((V)(0.7))).V, ((V)("io"))), "e", ((V)("emit")), ((V)("heart")), ((V)("head")), ((V)(1D)));
Call(unsee_28, V.Undef, t_1202, ((V)(300D)));
Invoke(t_1202, "to", ((V)(200D)), Call(both_12, V.Undef, ((V)(6D)), ((V)((-6D)))), ((V)("io")));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc1204, V t_1210, V s_1211, V _a1208, V _a1209, V[] _rest1205) => {
Call(jelly_19, V.Undef, t_1210, ((V)(3D)), ((V)(3D)), ((V)(300D)), ((V)("bend")));
Invoke(Invoke(t_1210, "to", ((V)(400D)), NewObj(2).Put("pitch", ((V)((-0.25)))).Put("ly", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(300D)));
Call(unsee_28, V.Undef, t_1210, ((V)(350D)));
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc1212, V t_1218, V s_1219, V _a1216, V _a1217, V[] _rest1213) => {
Call(see_27, V.Undef, t_1218, ((V)("foot")), s_1219, ((V)(200D)));
Invoke(t_1218, "to", ((V)(300D)), NewObj(1).PutK(Get(Call(S_10, V.Undef, s_1219), "foot"), ((V)(0D))).V, ((V)("io")));
Call(unsee_28, V.Undef, t_1218);
Invoke(t_1218, "to", ((V)(200D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc1220, V t_1226, V s_1227, V _a1224, V _a1225, V[] _rest1221) => {
Call(see_27, V.Undef, t_1226, ((V)("tail")), s_1227, ((V)(200D)));
Call(unsee_28, V.Undef, t_1226);
Invoke(Invoke(t_1226, "to", ((V)(400D)), NewObj(2).Put("pitch", ((V)((-0.25)))).Put("ly", ((V)(0.8))).V, ((V)("io"))), "wait", ((V)(300D)));
Call(unsee_28, V.Undef, t_1226, ((V)(300D)));
return default;
}, 2, "tail", true)).V).Put("ribbit", NewObj(9).Put("head", Fn((V _self1, int _argc1228, V t_1234, V s_1235, V _a1232, V _a1233, V[] _rest1229) => {
Invoke(Invoke(t_1234, "to", ((V)(120D)), NewObj(1).Put("sq", ((V)(0.3))).V, ((V)("io"))), "wait", ((V)(200D)));
Call(jump_15, V.Undef, t_1234, NewObj(6).Put("h", ((V)(10D))).Put("ant", ((V)(60D))).Put("up", ((V)(220D))).Put("c", ((V)(0.3))).Put("arm", ((V)(50D))).Put("st", ((V)(1.1))).V);
return default;
}, 2, "head", true)).Put("ear", Fn((V _self1, int _argc1236, V t_1242, V s_1243, V _a1240, V _a1241, V[] _rest1237) => {
Invoke(t_1242, "e", ((V)("blink")));
Invoke(t_1242, "to", ((V)(300D)), NewObj(1).PutK(Get(Call(S_10, V.Undef, s_1243), "wink"), ((V)(0D))).V, ((V)("io")));
Call(croak_21, V.Undef, t_1242, ((V)(1D)), ((V)(420D)));
return default;
}, 2, "ear", true)).Put("nose", Fn((V _self1, int _argc1244, V t_1250, V s_1251, V _a1248, V _a1249, V[] _rest1245) => {
Invoke(t_1250, "to", ((V)(120D)), NewObj(2).Put("cross", ((V)(0D))).Put("ly", ((V)(0.1))).V, ((V)("io")));
Invoke(Invoke(Invoke(Invoke(t_1250, "to", ((V)(80D)), NewObj(4).Put("tongue", ((V)(1D))).Put("open", ((V)(0.5))).Put("pitch", ((V)(0.12))).Put("sq", ((V)((-0.05)))).V, ((V)("o"))), "to", ((V)(140D)), NewObj(4).Put("tongue", ((V)(0D))).Put("open", ((V)(0D))).Put("sq", ((V)(0.06))).Put("pitch", ((V)((-0.05)))).V, ((V)("io"))), "to", ((V)(160D)), NewObj(2).Put("sq", ((V)(0.06))).Put("puff", ((V)(0.5))).V, ((V)("o"))), "to", ((V)(200D)), NewObj(5).Put("sq", ((V)(0D))).Put("puff", ((V)(0D))).Put("pitch", ((V)(0D))).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
return default;
}, 2, "nose", true)).Put("eye", Fn((V _self1, int _argc1252, V t_1258, V s_1259, V _a1256, V _a1257, V[] _rest1253) => {
Invoke(Invoke(t_1258, "e", ((V)("blink2"))), "to", ((V)(250D)), NewObj(2).Put("winkL", ((V)(0D))).Put("winkR", ((V)(0D))).V, ((V)("io")));
Call(croak_21, V.Undef, t_1258, ((V)(1D)), ((V)(400D)));
return default;
}, 2, "eye", true)).Put("cheek", Fn((V _self1, int _argc1260, V t_1266, V s_1267, V _a1264, V _a1265, V[] _rest1261) => {
Call(croak_21, V.Undef, t_1266, ((V)(2D)), ((V)(420D)));
return default;
}, 2, "cheek", true)).Put("belly", Fn((V _self1, int _argc1268, V t_1274, V s_1275, V _a1272, V _a1273, V[] _rest1269) => {
V a_1276 = default;
Invoke(t_1274, "to", ((V)(150D)), NewObj(2).Put("hap", ((V)(1D))).Put("smile", ((V)(1D))).V, ((V)("io")));
a_1276 = Get(t_1274, "t");
Call(croak_21, V.Undef, t_1274, ((V)(3D)), ((V)(330D)));
Call(para_38, V.Undef, t_1274, a_1276, Fn((V _self1, int _argc1277, V u_1283, V _a1280, V _a1281, V _a1282, V[] _rest1278) => {
return Call(jelly_19, V.Undef, u_1283, ((V)(0.1)), ((V)(4D)), ((V)(250D)));
}, 1, "", true));
return default;
}, 2, "belly", true)).Put("side", Fn((V _self1, int _argc1284, V t_1290, V s_1291, V _a1288, V _a1289, V[] _rest1285) => {
Call(jump_15, V.Undef, t_1290, NewObj(6).Put("h", ((V)(9D))).Put("ant", ((V)(120D))).Put("up", ((V)(200D))).Put("c", ((V)(0.22))).Put("arm", ((V)(45D))).Put("x", ((V)(((-ToNum(s_1291)) * 6D)))).V);
Invoke(t_1290, "wait", ((V)(200D)));
Call(jump_15, V.Undef, t_1290, NewObj(6).Put("h", ((V)(8D))).Put("ant", ((V)(120D))).Put("up", ((V)(200D))).Put("c", ((V)(0.2))).Put("arm", ((V)(40D))).Put("x", ((V)(0D))).V);
return default;
}, 2, "side", true)).Put("foot", Fn((V _self1, int _argc1292, V t_1298, V s_1299, V _a1296, V _a1297, V[] _rest1293) => {
Call(jump_15, V.Undef, t_1298, NewObj(6).Put("h", ((V)(14D))).Put("ant", ((V)(100D))).Put("up", ((V)(250D))).Put("c", ((V)(0.26))).Put("arm", ((V)(60D))).Put("st", ((V)(1.1))).V);
return default;
}, 2, "foot", true)).Put("tail", Fn((V _self1, int _argc1300, V t_1306, V s_1307, V _a1304, V _a1305, V[] _rest1301) => {
V a_1308 = default;
a_1308 = Get(t_1306, "t");
Invoke(Invoke(t_1306, "osc", ((V)(500D)), ((V)(2D)), NewObj(1).Put("footR", ((V)(4D))).V, NewObj(1).Put("footR", ((V)(0.5))).V, ((V)("io"))), "to", ((V)(100D)), NewObj(1).Put("footR", ((V)(0D))).V);
Call(jump_15, V.Undef, t_1306, NewObj(5).Put("h", ((V)(10D))).Put("ant", ((V)(100D))).Put("up", ((V)(220D))).Put("c", ((V)(0.22))).Put("arm", ((V)(45D))).V);
return default;
}, 2, "tail", true)).V).V;
TXT_53 = NewObj(10).Put("mittens", NewObj(9).Put("head", ((V)("Bonk: rubs his head with a little pout."))).Put("ear", ((V)("Ear flicks, a quick cat head shake, giggles."))).Put("nose", ((V)("Cross-eyed, sneezes, rubs his nose."))).Put("eye", ((V)("Flinches, rubs his eye, blinks it clear."))).Put("cheek", ((V)("Leans into your finger and rubs against it, purring."))).Put("belly", ((V)("Ticklish: giggles and bats at your finger."))).Put("side", ((V)("Steps to catch his balance, looks, rubs the spot, walks back."))).Put("foot", ((V)("Shakes his paw like a cat stepping in water."))).Put("tail", ((V)("Tail puffs up, he hops, glares back at it, tail lashes."))).V).Put("biscuit", NewObj(9).Put("head", ((V)("Thinks it is a pat: pushes up into it, tongue out, tail wagging."))).Put("ear", ((V)("Ear flips, puppy head tilt, then a shake."))).Put("nose", ((V)("Sniffs your finger and licks it."))).Put("eye", ((V)("Blinks, paw rub, wags it off."))).Put("cheek", ((V)("Leans in with his tongue out."))).Put("belly", ((V)("Belly-rub bliss: eyes shut, his back leg kicks, tail thumping."))).Put("side", ((V)("Stumbles into a play bow and a happy boof."))).Put("foot", ((V)("Offers you his paw to shake."))).Put("tail", ((V)("Spins round after his tail."))).V).Put("truffle", NewObj(9).Put("head", ((V)("His whole round body jiggles, two snorts."))).Put("ear", ((V)("A piggy head shake and a snort."))).Put("nose", ((V)("Snorts at your finger and sniffs it."))).Put("eye", ((V)("Blinks, rubs it with a hoof, snorts."))).Put("cheek", ((V)("His cheeks wobble and he giggles."))).Put("belly", ((V)("Belly jiggles like jelly, he giggles and pats it."))).Put("side", ((V)("Wobbles side to side like jelly."))).Put("foot", ((V)("Stomps his hoof, dust puffs up, snorts."))).Put("tail", ((V)("Curly tail springs, looks back, oinks."))).V).Put("nibbles", NewObj(9).Put("head", ((V)("The hamster freeze, eyes dart, nose twitches."))).Put("ear", ((V)("Quick ear twitches, little head shake."))).Put("nose", ((V)("Nose twitches like crazy, cheeks puff."))).Put("eye", ((V)("Hamster face-wash with both paws."))).Put("cheek", ((V)("Cheek balloons and pops a seed out, giggles."))).Put("belly", ((V)("Quick ticklish giggles, paws clasped."))).Put("side", ((V)("Zips sideways, freezes, eyes dart."))).Put("foot", ((V)("Tiny jump, runs on the spot."))).Put("tail", ((V)("Spins round to see what touched him, sniffs."))).V).Put("quill", NewObj(9).Put("head", ((V)("Ducks with his eyes shut, peeks up, blushes."))).Put("ear", ((V)("Shy shrug, hides his face, blushes."))).Put("nose", ((V)("Nose wiggles, covers it with both paws."))).Put("eye", ((V)("Covers his eyes, peeks through one side."))).Put("cheek", ((V)("Blushes deep and looks away shyly."))).Put("belly", ((V)("Curls into a ball and trembles, then giggles."))).Put("side", ((V)("Curls up and rolls away, uncurls blushing."))).Put("foot", ((V)("Wiggles his foot, looks down, blushes."))).Put("tail", ((V)("Curls up, then peeks back over his shoulder."))).V).Put("waffles", NewObj(9).Put("head", ((V)("Happy boof and a head tilt."))).Put("ear", ((V)("A full dog shake, tongue out."))).Put("nose", ((V)("Sniffs, a little play-sneeze."))).Put("eye", ((V)("Goofy wink with his tongue out."))).Put("cheek", ((V)("Leans in, tongue out."))).Put("belly", ((V)("Flops flat, legs kicking, stub tail going."))).Put("side", ((V)("Play bow, butt wiggle, boof."))).Put("foot", ((V)("Lifts his paw and waves it."))).Put("tail", ((V)("Frantic butt wiggle, looks back."))).V).Put("poppy", NewObj(9).Put("head", ((V)("Freezes, then wheeks."))).Put("ear", ((V)("A sudden popcorn hop."))).Put("nose", ((V)("Nose twitches, wheeks."))).Put("eye", ((V)("Blinks and scoots back on pattering feet."))).Put("cheek", ((V)("Leans in with her eyes shut, content."))).Put("belly", ((V)("Two popcorn hops."))).Put("side", ((V)("Zips sideways, wheeks, creeps back."))).Put("foot", ((V)("Pitter-pats, then pops."))).Put("tail", ((V)("Pops straight up, looks back, wheeks."))).V).Put("duchess", NewObj(9).Put("head", ((V)("Appalled, then smooths her fur and lifts her chin."))).Put("ear", ((V)("Hmph: frowns and turns her head away."))).Put("nose", ((V)("Dainty sniff, a tiny sneeze behind her paw."))).Put("eye", ((V)("A slow blink, then a glare."))).Put("cheek", ((V)("Leans into it, purring - she likes that one."))).Put("belly", ((V)("NOT the belly: swats at your finger, hmph."))).Put("side", ((V)("Smooths her fur where you poked."))).Put("foot", ((V)("Shakes her paw daintily, chin up."))).Put("tail", ((V)("Tail lashes, glares back over her shoulder."))).V).Put("mamapaws", NewObj(9).Put("head", ((V)("Warm smile, nuzzles her pup."))).Put("ear", ((V)("Gentle head shake and a soft laugh."))).Put("nose", ((V)("Sniffs your finger, a gentle lick."))).Put("eye", ((V)("Blinks, then checks her pup."))).Put("cheek", ((V)("Leans in, hearts."))).Put("belly", ((V)("Hugs her pup closer, giggles."))).Put("side", ((V)("Wobbles like jelly, checks her pup."))).Put("foot", ((V)("Looks down at her paw, smiles."))).Put("tail", ((V)("Looks back, then checks her pup."))).V).Put("ribbit", NewObj(9).Put("head", ((V)("Squashed flat, springs back up."))).Put("ear", ((V)("That eye blinks, a croak."))).Put("nose", ((V)("Zaps your finger with his tongue, gulps."))).Put("eye", ((V)("Double blink, a croak."))).Put("cheek", ((V)("Two big throat-puffing croaks."))).Put("belly", ((V)("Giggly croaks, belly jiggles."))).Put("side", ((V)("Hops away to the side and back."))).Put("foot", ((V)("Springs straight up."))).Put("tail", ((V)("Kicks his back leg, hops."))).V).V;
NAME_54 = NewObj(9).Put("head", ((V)("Top of head"))).Put("ear", ((V)("ear"))).Put("nose", ((V)("Nose"))).Put("eye", ((V)("eye"))).Put("cheek", ((V)("cheek"))).Put("belly", ((V)("Belly"))).Put("side", ((V)("side"))).Put("foot", ((V)("foot"))).Put("tail", ((V)("Tail"))).V;
SPOTS_55 = Arr(Arr(((V)("head")), ((V)(0D))), Arr(((V)("earL")), ((V)((-1D)))), Arr(((V)("earR")), ((V)(1D))), Arr(((V)("nose")), ((V)(0D))), Arr(((V)("eyeL")), ((V)((-1D)))), Arr(((V)("eyeR")), ((V)(1D))), Arr(((V)("cheekL")), ((V)((-1D)))), Arr(((V)("cheekR")), ((V)(1D))), Arr(((V)("belly")), ((V)(0D))), Arr(((V)("sideL")), ((V)((-1D)))), Arr(((V)("sideR")), ((V)(1D))), Arr(((V)("footL")), ((V)((-1D)))), Arr(((V)("footR")), ((V)(1D))), Arr(((V)("tail")), ((V)(1D))));
build_56 = Fn((V _self1, int _argc1309, V RE_1315, V TXT_1316, V BODY_1317, V _a1314, V[] _rest1310) => {
V ST_1318 = default;
ST_1318 = NewObj(0).V;
{
foreach (V _k1319 in ForInKeys(RE_1315)) {
V key_1320 = default;
key_1320 = _k1319;
V B_1321 = default;
V T_1322 = default;
V D_1323 = default;
B_1321 = (GetK(BODY_1317, key_1320) is var _t1324 && Truthy(_t1324) ? _t1324 : NewObj(0).V);
T_1322 = ((GetK(CARD_22, key_1320) is var _t1325 && !Truthy(_t1325) ? _t1325 : Get(GetK(CARD_22, key_1320), "T")) is var _t1326 && Truthy(_t1326) ? _t1326 : ((V)(1D)));
D_1323 = SetK(DESC_23, key_1320, (GetK(DESC_23, key_1320) is var _t1327 && Truthy(_t1327) ? _t1327 : NewObj(0).V));
Invoke(SPOTS_55, "forEach", Fn((V _self1, int _argc1328, V _a1330, V _a1331, V _a1332, V _a1333, V[] _rest1329) => {
V spot_1339 = default;
V t_1340 = default;
V tap_1341 = default;
V tp_1342 = default;
V side_1343 = default;
V L_1344 = default;
V label_1345 = default;
V tx_1346 = default;
V nm_1336 = default;
V s_1338 = default;
{ V _t1334 = ListOf(_a1330);
{ V _t1335 = GetIdx(_t1334, 0D);
nm_1336 = _t1335; }
{ V _t1337 = GetIdx(_t1334, 1D);
s_1338 = _t1337; }
}
spot_1339 = Invoke(nm_1336, "replace", NewRegExp(RX0, "[LR]$", ""), ((V)("")));
t_1340 = Call(TL_9, V.Undef, NewObj(0).V, T_1322);
InvokeK(HIT_25, spot_1339, t_1340, s_1338, B_1321);
InvokeK(GetK(RE_1315, key_1320), spot_1339, t_1340, s_1338, B_1321);
if ((SEqS(spot_1339, "side") && !(Truthy(Get(B_1321, "noWalk"))))) {
if (Truthy(Get(B_1321, "hopBack"))) {
Call(jump_15, V.Undef, t_1340, NewObj(6).Put("h", ((V)(4D))).Put("ant", ((V)(120D))).Put("up", ((V)(170D))).Put("c", ((V)(0.1))).Put("arm", ((V)(20D))).Put("x", ((V)(0D))).V);
} else {
Call(walkBack_31, V.Undef, t_1340, ((V)(480D)));
}
}
Invoke(t_1340, "rest", ((V)(420D)));
tap_1341 = Get((GetK(Get(R_8, "STATES"), ((V)(JsStrBuf.Begin().S("poke_").V(nm_1336).End()))) is var _t1347 && Truthy(_t1347) ? _t1347 : NewObj(0).V), "tap");
tp_1342 = tap_1341;
if (Truthy((Get(B_1321, "earTap") is var _t1348 && !Truthy(_t1348) ? _t1348 : (SEqS(spot_1339, "ear") ? V.True : V.False)))) {
tp_1342 = Arr((LtN(s_1338, 0D) ? GetIdx(Get(B_1321, "earTap"), 0D) : ((V)((100D - ToNum(GetIdx(Get(B_1321, "earTap"), 0D)))))), GetIdx(Get(B_1321, "earTap"), 1D));
}
if ((SEqS(spot_1339, "tail") && !(Truthy(Get(B_1321, "tail"))))) {
tp_1342 = (Get(B_1321, "tailTap") is var _t1349 && Truthy(_t1349) ? _t1349 : Arr(((V)(78D)), ((V)(72D))));
}
SetK(ST_1318, ((V)(JsStrBuf.Begin().S("poke_").V(nm_1336).S("@").V(key_1320).End())), Invoke(t_1340, "done", NewObj(2).Put("tap", tp_1342).Put("stretch", ((V)(0.5))).V));
side_1343 = ((V)((LtN(s_1338, 0D) ? "Left " : ((GtN(s_1338, 0D) && !SEqS(spot_1339, "tail")) ? "Right " : ""))));
L_1344 = (Get(B_1321, "lbl") is var _t1350 && !Truthy(_t1350) ? _t1350 : GetK(Get(B_1321, "lbl"), spot_1339));
label_1345 = (Truthy(L_1344) ? (string.Equals(Typeof(L_1344), "function") ? Call(L_1344, V.Undef, s_1338) : Add(((((SEqS(spot_1339, "head") || SEqS(spot_1339, "nose")) || SEqS(spot_1339, "belly")) || SEqS(spot_1339, "tail")) ? ((V)("")) : side_1343), L_1344)) : (((SEqS(spot_1339, "head") || SEqS(spot_1339, "nose")) || SEqS(spot_1339, "belly")) ? GetK(NAME_54, spot_1339) : (SEqS(spot_1339, "tail") ? ((V)((Truthy(Get(B_1321, "tail")) ? "Tail" : "Back end"))) : Add(side_1343, GetK(NAME_54, spot_1339)))));
tx_1346 = GetK(GetK(TXT_1316, key_1320), spot_1339);
SetK(D_1323, ((V)(JsStrBuf.Begin().S("poke_").V(nm_1336).End())), Arr(label_1345, (string.Equals(Typeof(tx_1346), "function") ? Call(tx_1346, V.Undef, s_1338) : tx_1346)));
return default;
}, 1, "", true));
}
}
Invoke(R_8, "add", ST_1318);
return default;
}, 3, "", true);
Set(R_8, "POKELIB", NewObj(25).Put("HIT", HIT_25).Put("SEE", SEE_26).Put("see", see_27).Put("unsee", unsee_28).Put("SPOT", SPOT_29).Put("rub", rub_30).Put("walkBack", walkBack_31).Put("giggle", giggle_32).Put("hmph", hmph_33).Put("sneeze", sneeze_34).Put("sniff", sniff_35).Put("lick", lick_36).Put("para", para_38).Put("leanIn", leanIn_39).Put("swat", swat_40).Put("pawShake", pawShake_41).Put("headShake", headShake_42).Put("snort", snort_43).Put("freeze", freeze_46).Put("curl", curl_47).Put("blushy", blushy_48).Put("happy", happy_49).Put("pat", pat_50).Put("smooth", smooth_51).Put("build", build_56).V);
Call(build_56, V.Undef, RE_52, TXT_53, BODY_24);
return default;
}, 0, "boot", false)), V.Undef);
        }
    }
}
